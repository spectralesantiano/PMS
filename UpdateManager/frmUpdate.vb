Imports System.ComponentModel
Imports System.Text
Imports System.IO

Public Class frmUpdate

    Private Const cTable_config As String = "[sti_sys].[dbo].[tblPMSConfig]"

    Dim cDatabaseName As String = "pms_db"
    Dim cServerName As String
    Dim cServerUser As String
    Dim cServerPwd As String
    Dim bUSE_SPECTRAL_CON As Boolean
    Dim bUSE_TRUSTED_CON As Boolean

    Dim tmr As Integer = 0
    Dim cActionType As String
    Dim cCurVersion As String
    Dim cUsername As String
    Dim cObxPath As String
    Dim oDb As clsDB

    Dim sbLog As New StringBuilder("") 'stores log for whole update process
    Dim sbVersionLog As New StringBuilder("") 'stores log for every version update process
    Private nColStandard As Integer = 50
    Dim cErr As String = ""

    Dim nFilesUpdated As Integer = 0
    Dim nFilesError As Integer = 0
    Dim nFilesInvalid As Integer = 0

    Dim cUpdatesFolder As String
    Dim cTemp_Folder As String

    Dim versionNumber As String
    Dim versionDate As String
    Dim versionDesc As String

    Private Sub _timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _timer.Tick
        tmr += 10
        If tmr = 100 Then
            _timer.Enabled = False
            Try
                UpdateProgram()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If
    End Sub

    Public Sub New()
        InitializeComponent()

        Dim args() As String = Environment.GetCommandLineArgs()

        'Dim args() As String = {"APP.exe", "UPDATE", "1.00", "localhost\SQLEXPRESS", "sa", "stiteam"} 'test update
        'Dim args() As String = {"APP.exe", "LOAD", "5.01.00", "C:\Spectral\UpdateSM5.obx", "Administrator", "Data Source=.\STISQLSERVER;Persist Security Info=True;User ID=sa;Password=sffSDfsdfdfSDFsdffDFSF2164564DFSD2Df2345ABCSTFS"} 'test load

        'Dim args() As String = {"APP.exe", "LOAD", "1.00.00", "C:\Spectral\Developments\Source Codes\PMS\PlannedMaintenance\bin\x86\Debug\temp_update\1.00.00", "Admin", ".", "", "", "True", "False"}
        If args.Count = 8 Then
            'Update Version
            'sample: {"APP.exe", "UPDATE", "1.00", "localhost\SQLEXPRESS", "sa", "stiteam", "False", "False"}
            cActionType = args(1)
            cCurVersion = args(2)
            cServerName = args(3)
            cServerUser = args(4)
            cServerPwd = args(5)
            bUSE_SPECTRAL_CON = CType(args(6), Boolean)
            bUSE_TRUSTED_CON = CType(args(7), Boolean)
            Dim oparamClsDb As New clsDB(ConstructConnString(cDatabaseName))
            oDb = oparamClsDb
        ElseIf args.Count = 10 Then
            'Load Version
            'sample: {"APP.exe", "LOAD","1.00","C:\update.obx", Administrator, "localhost\SQLEXPRESS", "sa", "stiteam", "False", "False"}
            cActionType = args(1)
            cCurVersion = args(2)
            cObxPath = args(3)
            cUsername = args(4)
            cServerName = args(5)
            cServerUser = args(6)
            cServerPwd = args(7)
            bUSE_SPECTRAL_CON = CType(args(8), Boolean)
            bUSE_TRUSTED_CON = CType(args(9), Boolean)
            Dim oparamClsDb As New clsDB(ConstructConnString(cDatabaseName))
            oDb = oparamClsDb
        End If

        Return
    End Sub

    Sub UpdateProgram()
        '******** Shared Parameters *******
        Dim bSuccess As Boolean = False
        Dim dStart As DateTime
        Dim cVersion As String
        Dim cVersionDate As String = ""
        Dim cDesc As String = ""
        Dim cBuilderDesc As New StringBuilder("")
        Dim cFolder As String
        Dim cFullBak_folder As String = ""
        Dim cBak_folder As String = ""

        Try
            dStart = oDb.MSSql_GetServerTime()

            '******** End Parameters **********

            Select Case UCase(cActionType)

                Case "UPDATE" ' check latest version and try to update

                    Init("UPDATE", bSuccess)

                    If bSuccess Then
                        Log_Append(StrDup(100, "-"))
                        Log_Append("Getting update versions")
                        Log_Append(StrDup(100, "-"))

                        'get latest versions
                        Dim dtVersions As DataTable = Nothing
                        Try
                            dtVersions = oDb.oGetLatestVersions(cCurVersion)
                        Catch ex As Exception
                            MessageBox.Show("Getting version " & ex.Message)
                        End Try

                        If dtVersions.Rows.Count > 0 Then
                            Dim dr As DataRow
                            For Each dr In dtVersions.Rows
                                cVersion = IfNull(dr("AppVersion").ToString, "")
                                cVersionDate = IfNull(CType(dr("VersionDate"), DateTime).ToString("yyyy-MM-dd"), "")
                                cDesc = IfNull(dr("VersionDesc").ToString, "")
                                cFolder = IfNull(dr("ObjectPath").ToString, "")

                                If cVersion <> "" And UCase(cDesc) <> "BASE VERSION" Then

                                    If Not bSuccess Then Exit For

                                    'reset files var
                                    nFilesUpdated = 0
                                    nFilesError = 0
                                    nFilesInvalid = 0

                                    sbVersionLog.Clear()
                                    Log_Append(sbVersionLog, "")
                                    Log_Append(sbVersionLog, "Update Version to : ".PadRight(nColStandard) & cVersion)

                                    'create temp folder
                                    SetStatus("Creating temp_update folder ..")
                                    cTemp_Folder = CleanPath(GetAppFolder) & "temp_update"
                                    bSuccess = CreateUpdateFolder(cTemp_Folder)

                                    Log_Append(sbVersionLog, "Create temp_folder :".PadRight(nColStandard) & GetResult(bSuccess, ""))

                                    'collect updates
                                    If bSuccess Then
                                        Log_Append(sbVersionLog, "Collecting required files from version: ".PadRight(nColStandard) & cVersion)
                                        SetStatus("Collecting required files from version: " & cVersion)
                                        Dim cFullUpdatesFolder As String = CleanPath(cUpdatesFolder) & cFolder
                                        If IsPathExist(cFullUpdatesFolder, True) Then
                                            If HasFolderPermission(cFullUpdatesFolder) Then
                                                Try
                                                    Application.DoEvents()
                                                    My.Computer.FileSystem.CopyDirectory(cFullUpdatesFolder, cTemp_Folder, True)
                                                    Application.DoEvents()
                                                    bSuccess = True
                                                Catch ex As Exception
                                                    cErr = "Error occurred copying files."
                                                    bSuccess = False
                                                End Try
                                            Else
                                                cErr = "No permission on Update folder :" & cFullUpdatesFolder
                                                bSuccess = False
                                            End If
                                        Else
                                            cErr = "Cannot locate Update folder :" & cFullUpdatesFolder
                                            bSuccess = False
                                        End If
                                    End If
                                    Log_Append(sbVersionLog, "Collection Status :".PadRight(nColStandard) & GetResult(bSuccess, cErr))


                                    'clean temp_update folder
                                    SetStatus("Cleaning temp update folder..")
                                    CleanFolder(cTemp_Folder, "*.obx", IO.SearchOption.TopDirectoryOnly)

                                    Log_Append(StrDup(100, "="))

                                    'perform updates
                                    cBak_folder = "Update_" & dStart.ToString("yyyy-MM-dd.HH.mm.ss") & "_Version_" & cCurVersion & " - " & cVersion
                                    cFullBak_folder = CleanPath(GetAppFolder() & "\obj_bak\" & cBak_folder)

                                    If bSuccess Then
                                        'PerformObjectUpdates(cBak_folder, dStart)
                                        PerformObjectUpdates(cTemp_Folder, cBak_folder, dStart, cFolder)
                                    End If

                                    Log_Write(cFullBak_folder & cBak_folder & ".txt", sbVersionLog)

                                    If nFilesUpdated > 0 Then
                                        'zip files
                                        'zip all files
                                        Dim bTmpSuccess As Boolean
                                        Dim cZipFiles As String
                                        Dim cObjectsBakFile As String = cFullBak_folder & cBak_folder & ".obxbak"
                                        cZipFiles = cFullBak_folder & "*.*"
                                        bTmpSuccess = ZipFiles(cObjectsBakFile, cZipFiles, cErr)
                                        bSuccess = bSuccess And bTmpSuccess

                                        'deletes files
                                        If bTmpSuccess Then
                                            CleanFolder(cFullBak_folder, "*.dll|*.DLL|*.exe|*.EXE|*.txt", IO.SearchOption.TopDirectoryOnly)
                                            CleanFolder(cTemp_Folder, "*.dll|*.DLL|*.exe|*.EXE|*.txt|*.sql", IO.SearchOption.TopDirectoryOnly)
                                        End If

                                        Log_Append(sbVersionLog, "Compressing backup")
                                        Log_Append(sbVersionLog, StrDup(100, "-"))
                                        Log_Append(sbVersionLog, "File: " & cObjectsBakFile & " ... " & GetResult(bTmpSuccess, cErr))
                                        Log_Append(sbVersionLog, StrDup(100, "-"))
                                    End If

                                    If bSuccess Then
                                        bSuccess = WriteSettingsIni("VERSION", cVersion, cErr)
                                        bSuccess = bSuccess And WriteSettingsIni("VERSIONDATE", cVersionDate, cErr)
                                        Log_Append(sbVersionLog, StrDup(100, "-"))
                                        Log_Append(sbVersionLog, "Update Version INI File :".PadRight(nColStandard) & GetResult(bSuccess, cErr))

                                        If bSuccess Then cCurVersion = cVersion 'update current version

                                    End If
                                    Log_Append(sbLog, sbVersionLog)

                                End If
                            Next
                        Else
                            Log_Append(StrDup(100, "-"))
                            Log_Append("No Valid Version Available")
                            Log_Append(StrDup(100, "-"))
                            Log_Append()
                        End If

                    End If

                Case "LOAD" 'load update from obx file

                    Init("LOAD", bSuccess)

                    If Not bSuccess Then Exit Select

                    sbVersionLog.Clear()
                    Dim nServerVersion As String = oDb.oGetServerVersion()
                    Log_Append(StrDup(100, "-"))
                    Log_Append("Getting latest version :".PadRight(nColStandard) & nServerVersion)
                    Log_Append(StrDup(100, "-"))

                    SetStatus("Reading extracted files..")

                    Log_Append(sbVersionLog, "Reading files :".PadRight(nColStandard) & GetResult(bSuccess, ""))

                    If Not bSuccess Then Exit Select

                    Dim tempVersion As ArrayList = GetVersionInfo(cObxPath & "\UPDATE.txt")
                                    If (tempVersion.Count >= 1) Then
                        cCurVersion = tempVersion(1).ToString()
                    End If

                    'cCurVersion = GetVersionValueForDB(GetVersionInfo(cObxPath & "\Update.txt")(1)).ToString() '-> Get version number.
                    cTemp_Folder = cObxPath
                    cVersion = ""

                    'Revised using the update process for PMS - 20190715 *****************************************
                    Try
                        Try
                            'If oDb.IsNewVersion(cCurVersion, nServerVersion) Then
                            Log_Append(sbVersionLog, "Object Update Version :".PadRight(nColStandard) & cCurVersion)
                            cVersion = cCurVersion
                            cBak_folder = "Load_" & dStart.ToString("yyyy-MM-dd.HH.mm.ss") & "_Version_" & cCurVersion
                            cFullBak_folder = CleanPath(GetAppFolder() & "\obj_bak\" & cBak_folder)
                            PerformObjectUpdates(cTemp_Folder, cBak_folder, dStart, cCurVersion)
                            bSuccess = True
                        Catch ex As Exception
                            Log_Append(sbVersionLog, "Status :".PadRight(nColStandard) & "Error occured validating object update version.")
                            bSuccess = False
                        End Try
                    Catch ex As Exception
                        cErr = ex.Message
                        bSuccess = False
                    End Try
                    'End Revise *****************************************

                    If Not bSuccess Then Exit Select
                    If cVersion <> "" Then
                        'put files in updates folder
                        Try
                            My.Computer.FileSystem.CopyDirectory(cTemp_Folder, CleanPath(cUpdatesFolder) & cVersion, True)
                            bSuccess = True
                            cErr = ""
                        Catch ex As Exception
                            cErr = ex.Message
                            bSuccess = False
                        End Try
                        Log_Append(sbVersionLog, "Put Files in Updates Folder :".PadRight(nColStandard) & GetResult(bSuccess, cErr))

                        If Not bSuccess Then Exit Select

                        'insert to update table
                        cUsername = cUsername & " - ( " & My.Computer.Name & " )"
                        cUsername = cUsername.Replace("'", "''")
                        bSuccess = oDb.UpdateServerVersion(versionNumber, versionDate, versionDesc.Replace("'", "''"), cUsername, cErr)
                        Log_Append(sbVersionLog, "Update Server Version :".PadRight(nColStandard) & GetResult(bSuccess, cErr))
                        Log_Write(cFullBak_folder & cBak_folder & ".txt", sbVersionLog)
                        'bakup files in local
                        If nFilesUpdated > 0 Then
                            'zip files
                            'zip all files
                            Dim bTmpSuccess As Boolean
                            Dim cZipFiles As String
                            Dim cObjectsBakFile As String = cFullBak_folder & cBak_folder & ".obxbak"
                            cZipFiles = cFullBak_folder & "*.*"

                            bTmpSuccess = ZipFiles(cObjectsBakFile, cZipFiles, cErr)
                            bSuccess = bSuccess And bTmpSuccess

                            'deletes files
                            If bTmpSuccess Then
                                CleanFolder(cFullBak_folder, "*.dll|*.DLL|*.exe|*.EXE|*.txt", IO.SearchOption.TopDirectoryOnly)
                            End If

                            Log_Append(sbVersionLog, "Compressing backup")
                            Log_Append(sbVersionLog, StrDup(100, "-"))
                            Log_Append(sbVersionLog, "File: " & cObjectsBakFile & " ... " & GetResult(bTmpSuccess, cErr))
                            Log_Append(sbVersionLog, StrDup(100, "-"))
                        End If

                        'evaluate process
                        If bSuccess Then
                            If cVersion <> "" Then
                                bSuccess = WriteSettingsIni("VERSION", versionNumber, cErr)
                                bSuccess = bSuccess And WriteSettingsIni("VERSIONDATE", versionDate, cErr)
                                Log_Append(sbVersionLog, "Update Version INI File :".PadRight(nColStandard) & GetResult(bSuccess, cErr))
                            End If
                        End If
                    End If
            End Select

            Select Case UCase(cActionType)
                Case "UPDATE"
                    Finish("UPDATE", "Version Update_" & dStart.ToString("yyyy-MM-dd.HH.mm.ss") & ".txt") ' finish process
                Case "LOAD"
                    Log_Append(sbLog, sbVersionLog)
                    Finish("LOAD", "Load Version_" & dStart.ToString("yyyy-MM-dd.HH.mm.ss") & ".txt") 'finish process
            End Select
        Catch ex As Exception
            Log_Append("There is a problem on update : " & ex.Message)
            Finish(IIf(cActionType.Equals("UPDATE"), "UPDATE", "LOAD"), "Version Update_" & dStart.ToString("yyyy-MM-dd.HH.mm.ss") & ".txt") ' finish process
        End Try

    End Sub

#Region "Updated Object Update Feature"

    Private Sub RunScripts(path As String, ByVal scripts As String(), Optional ByRef cErr As String = "")
        Try
            Dim queries As New List(Of String)
            Dim result As Boolean = oDb.oVersionRunSql("IF NOT EXISTS (SELECT * FROM pms_db.INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='MSysScripts_Loaded')" & _
                   "CREATE TABLE [pms_db].[dbo].[MSysScripts_Loaded]([ID] [int] IDENTITY(1,1) NOT NULL,[ScriptFile] [varchar](200) NULL,[RunFrom] [varchar](200) NULL,[DateRun] [datetime] NULL, CONSTRAINT [PK_pms_db_MSysScripts_Loaded] PRIMARY KEY CLUSTERED ( [ID] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] ) ON [PRIMARY]")

            For Each query As String In scripts
                If (query.EndsWith(".sql")) Then
                    If oDb.oVersionDLookUp("[ScriptFile]", "[pms_db].[dbo].[MSysScripts_Loaded]", "", "[ScriptFile]='" & query & "'").Equals("") Then
                        Using sqlw As New System.IO.StreamReader(CleanPath(path) & "\" & Trim(query))
                            Dim scriptToAdd As String = sqlw.ReadToEnd()
                            queries.Add(scriptToAdd)
                            queries.Add("INSERT INTO [pms_db].[dbo].[MSysScripts_Loaded]([ScriptFile],[RunFrom],[DateRun]) VALUES ('" & query & "','" & My.Computer.Name.Replace("'", "") & "',GETDATE())")
                        End Using
                    Else
                        cErr = "Script File Already Executed."
                        'File.AppendAllText(statusFilePath, oDb.MSSql_GetServerTime() & " - SCRIPT FILE ALREADY EXECUTED : " & query & Environment.NewLine)
                    End If
                Else   '-> This is a sql script in Update.txt
                    cErr = ""
                    queries.Add(query)
                End If
                'construct Log
                Dim cDisplayLine As String = ""
                If query.Length >= 40 Then
                    cDisplayLine = query.Substring(0, 40) & " .. "
                Else
                    cDisplayLine = query & " .. "
                End If
                Log_Append(sbVersionLog, cDisplayLine.PadRight(nColStandard) & GetResult(True, cErr))
            Next
            If (queries.Count >= 1) Then
                oDb.RunTransaction(queries, cErr)

            End If
        Catch ex As Exception
            cErr = "Error encountered: " & ex.Message
        End Try
    End Sub




    Private Function RunSqlScriptForUpdate(val As String(), sourceFolder As String) As Boolean
        Log_Append(sbVersionLog, StrDup(100, "-"))
        Log_Append(sbVersionLog, "Running Script(s)")
        Log_Append(sbVersionLog, StrDup(100, "-"))
        Log_Append(sbVersionLog, "Run Script".PadRight(nColStandard) & "Status")
        Try
            Dim bTemp As Boolean = False
            bTemp = oDb.oVersionRunSql("IF NOT EXISTS (SELECT * FROM " & cDatabaseName & ".INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='MSysScripts_Loaded')" & _
                    "CREATE TABLE [" & cDatabaseName & "].[dbo].[MSysScripts_Loaded]([ID] [int] IDENTITY(1,1) NOT NULL,[ScriptFile] [varchar](200) NULL,[RunFrom] [varchar](200) NULL,[DateRun] [datetime] NULL, CONSTRAINT [PK_pms_db_MSysScripts_Loaded] PRIMARY KEY CLUSTERED ( [ID] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] ) ON [PRIMARY]")
            RunScripts(sourceFolder, val, cErr)

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function GetItemsOnLineItem(arr As String(), val As String) As String()
        Dim retVal As New List(Of String)
        Dim started As Boolean = False
        For Each item As String In arr
            If (item.Equals(val)) Then
                started = True
                Continue For
            End If
            If (item.Equals("UpdateManager.exe")) Then Continue For 'Ignore UpdateManager.exe
            If (started And (Not val.Equals("[SQLS]")) And item.Contains("[")) Then Exit For
            If (started) Then retVal.Add(item)
        Next
        Return retVal.ToArray()
    End Function

    Private Function GetFileContentsToUpdate(arr As String()) As List(Of String)
        Dim retVal As New List(Of String)
        For Each contents As String In arr
            If (IsNotVersionKeywords(UCase(contents))) Then
                retVal.Add(contents)
            End If
        Next
        Return retVal
    End Function

    Private Function GetVersionValueForDB(val As String)
        Try
            If (val.Length > 0) Then
                Dim r = val.Split("=")
                If (r.Length > 1) Then
                    Return r(1).Trim()
                End If
            End If
        Catch ex As Exception
            Dim msg = ex.Message
        End Try
        Return ""
    End Function

    Private Function GetVersionInfo(scriptFile As String) As ArrayList
        Dim retVal As New ArrayList
        Try
            Dim contents = System.IO.File.ReadAllLines(scriptFile)
            For i As Integer = 0 To contents.Length - 1
                If (contents(i).Equals("[OBJECTS]") Or contents(i).Equals("[SQLS]")) Then
                    Return retVal
                Else
                    retVal.Add(contents(i))
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("GetVersionInfo - " & ex.Message)
        End Try
        Return retVal
    End Function

    Private Function IsNotVersionKeywords(val As String) As Boolean
        If (val.Contains("[INFO]") Or
            val.Contains("VERSION=") Or
            val.Contains("DATE=") Or
            val.Contains("DESC=")) Then
            Return False
        End If
        Return True
    End Function

    Private Function GetUpdateFile(arr As String(), valToFind As String) As String
        For Each content As String In arr
             If ((GetFileWithoutExtension(content) + GetFileExtension(content)).ToLower().Equals(valToFind.ToLower())) Then
                Return content
            End If
        Next
        Return ""
    End Function

    Public Sub PerformObjectUpdates(ByVal sourceFolder As String, ByVal backupFolder As String, ByVal startDate As DateTime, cFolder As String)
        Try
            SetStatus("Performing updates..")
            Log_Append(sbVersionLog, StrDup(100, "-"))
            Log_Append(sbVersionLog, "Performing updates ..")
            Log_Append(sbVersionLog, StrDup(100, "-"))
            Log_Append(sbVersionLog, "OBJECT NAME".PadRight(nColStandard) & "STATUS".PadRight(30) & "CREATE BACKUP")

            Dim arrProgramFiles() As String = UCase(oDb.oVersionDLookUp("Value", cTable_config, "", "Code='PROGRAMFILES'").ToString).Split(";"c)
            Dim arrUpdateFiles() As String = getFiles(cTemp_Folder, "*.*", IO.SearchOption.TopDirectoryOnly)
            Dim updateFile = GetUpdateFile(arrUpdateFiles, "Update.txt")
            If (updateFile <> "" And System.IO.File.Exists(updateFile)) Then '-> If the Update.txt exists, read to contents, ignore the version portion. 
                Dim versionInfo = GetVersionInfo(updateFile)
                If (Not IsNothing(versionInfo) And versionInfo.Count > 0) Then
                    versionNumber = GetVersionValueForDB(versionInfo(1).ToString()) '-> Get version number of Update.txt
                    versionDate = GetVersionValueForDB(versionInfo(2).ToString())   '-> Get version Date number of Update.txt
                    versionDesc = GetVersionValueForDB(versionInfo(3).ToString())   '-> Get version Description of Update.txt
                 Else
                    versionNumber = oDb.oVersionDLookUp("AppVersion", "[sti_sys].[dbo].[tblPMSVersion]", "", "1=1 ORDER BY AppVersion DESC")
                    versionDate = oDb.oVersionDLookUp("VersionDate", "[sti_sys].[dbo].[tblPMSVersion]", "", "1=1 ORDER BY AppVersion DESC")
                    versionDesc = oDb.oVersionDLookUp("VersionDesc", "[sti_sys].[dbo].[tblPMSVersion]", "", "1=1 ORDER BY AppVersion DESC")               
                End If
                Dim contentsToUpdate As List(Of String) = GetFileContentsToUpdate(System.IO.File.ReadAllLines(updateFile))

                'Get update files based on type.
                Dim scripts As String() = GetItemsOnLineItem(contentsToUpdate.ToArray(), "[SQLS]")    '-> For script files .sql or hardcoded sql command on Update.txt
                Dim objects As String() = GetItemsOnLineItem(contentsToUpdate.ToArray(), "[OBJECTS]") '-> For files like .dll, .exe, etc.
                Dim images As String() = GetItemsOnLineItem(contentsToUpdate.ToArray(), "[IMAGES]")   '-> For files like .png, .jpg, .ico, .gif, .etc
                Dim docFiles As String() = GetItemsOnLineItem(contentsToUpdate.ToArray(), "[DOCS]")   '-> For files like .xlsx, .doc, .txt, .etc

                'Process each update files.
                Dim isScriptsUpdated As Boolean = RunSqlScriptForUpdate(scripts, IIf(sourceFolder.Contains(cFolder), sourceFolder, sourceFolder & "\" & cFolder)) 'Execute sql scripts first.
                Dim isObjectsUpdated As Boolean = ProcessUpdateFiles(arrProgramFiles, sourceFolder, backupFolder, objects, startDate) 'Execute for Objects, DLLs, and exes.
                Dim isImagesUpdated As Boolean = ProcessUpdateFiles(arrProgramFiles, sourceFolder, backupFolder, images, startDate)
                Dim isDocFilesUpdated As Boolean = ProcessUpdateFiles(arrProgramFiles, sourceFolder, backupFolder, docFiles, startDate)
          Else
                Log_Append(sbVersionLog, StrDup(100, "-"))
                Log_Append(sbVersionLog, "FILE Update.txt Does not exists on the given obx file.".PadRight(nColStandard))
                Log_Append(sbVersionLog, StrDup(100, "-"))  
          End If
            Log_Append(sbVersionLog, StrDup(100, "-"))
            Log_Append(sbVersionLog, "Files Updated :".PadRight(nColStandard) & nFilesUpdated.ToString)
            Log_Append(sbVersionLog, "Files Error :".PadRight(nColStandard) & nFilesError.ToString)
            Log_Append(sbVersionLog, "Invalid Files :".PadRight(nColStandard) & nFilesInvalid.ToString)
            Log_Append(sbVersionLog, StrDup(100, "-"))
        Catch ex As Exception
            Dim str As String = ex.Message
        End Try
    End Sub


    Private Function ProcessProgramObjects(ByVal programObjects As String(), fileName As String, cBak_Folder As String, dStart As DateTime) As Boolean
        Try
            SetStatus("Updating Object [ " & fileName & " ] ..")
            Dim cErr() As String = {"", ""}
            Dim bCopiedUpdated() As Boolean = UpdateObjectFile(fileName, cBak_Folder, cTemp_Folder, dStart, cErr)
            Log_Append(sbVersionLog, fileName.PadRight(nColStandard) & GetResult(bCopiedUpdated(1), cErr(1)).PadRight(30) & GetResult(bCopiedUpdated(0), cErr(0)))
        Catch ex As Exception

        End Try
    End Function

    Private Sub BackUpFileIfExists(fullFileName As String, file As String, sourceFolder As String, backupFolder As String, dStart As DateTime, ByRef errorMessages As String(), ByRef updateResult As Boolean())
        Try
            If (FileIO.FileSystem.FileExists(fullFileName)) Then 'If it exists in the destination folder, backup the file.
                FileIO.FileSystem.CopyFile(sourceFolder & "\" & file, backupFolder & "\" & GetFileWithoutExtension(file) & "_" & dStart.ToString("yyyyMMddHHmmss") & GetFileExtension(file), True) 'The backup folder usually named as the current date with the updated version number.
                errorMessages(0) = "OK"
                updateResult(0) = True
            Else
                errorMessages(0) = "N/A"
                updateResult(0) = True
            End If
        Catch ex As Exception
            errorMessages(0) = ex.Message
            updateResult(0) = False
        End Try
    End Sub

    Private Function GetFolderHeirarchy(val As String) As String()
        Dim retVal As String() = {}
        If (val.Length > 0) Then
            If (val.StartsWith("\")) Then
                retVal = val.Substring(1).Split("\")
            Else
                retVal = val.Split("\")
            End If
        End If
        Return retVal
    End Function

    Private Function ProcessUpdateFiles(ByVal programObjects As String(), ByVal sourceFolder As String, ByVal backupFolder As String, itemsToProcess As String(), dStart As DateTime) As Boolean

        Dim file As String = ""
        Dim fullFileName As String = ""
        Dim errorMessages() As String = {"", ""}
        Dim updateResult() As Boolean = {False, False}
        For Each item As String In itemsToProcess
            Try
                Dim itemPart As String() = GetFolderHeirarchy(item) '-> Extract folder heirarchy to create. Format should be \Folder\SubFolder\..\..\File.dll
                If (IsNothing(itemPart) Or itemPart.Count.Equals(0)) Then Return False '-> If there is no item to process, halt the function. 
                Dim rootPath As String = Application.StartupPath
                If (itemPart.Count = 1) Then 'Save file to Root.
                    file = itemPart(0) 'Get file.
                ElseIf (itemPart.Count > 1) Then 'Has subfolders
                    For i As Integer = 0 To itemPart.Count - 2 'Ignore the last part, which contains the file name to update.
                        If (CreateFolder(rootPath & "\" & itemPart(i))) Then 'Check if folder exists. If so, create it, otherwise do nothing.
                            rootPath &= "\" & itemPart(i) 'Contruct the destination folder for this update.
                        End If
                    Next
                    file = itemPart(itemPart.Count - 1) 'Get the file name.
                End If
                fullFileName = rootPath & "\" & file 'Construct the full path of the file to update.
                If (programObjects.Contains(UCase(file))) Then
                    ProcessProgramObjects(programObjects, file, backupFolder, dStart) '-> From original code of ProcessUpdateFiles() method, 
                Else
                    SetStatus("Updating Other Object [ " & file & " ] ..")
                    BackUpFileIfExists(fullFileName, file, sourceFolder, backupFolder, dStart, errorMessages, updateResult)
                    FileIO.FileSystem.CopyFile(sourceFolder & "\" & file, fullFileName, True) 'Copy the file
                    nFilesUpdated = nFilesUpdated + 1
                    errorMessages(1) = "OK"
                    updateResult(1) = True
                    Log_Append(sbVersionLog, file.PadRight(nColStandard) & GetResult(updateResult(1), errorMessages(1)).PadRight(30) & GetResult(updateResult(0), errorMessages(0)))
                End If
            Catch ex As Exception
                nFilesError = nFilesError + 1
                errorMessages(1) = ex.Message
                updateResult(1) = False
            End Try
            'Log_Append(sbVersionLog, file.PadRight(nColStandard) & GetResult(updateResult(1), errorMessages(1)).PadRight(30) & GetResult(updateResult(0), errorMessages(0)))
        Next
        Return True
    End Function

    Private Function CreateFolder(path As String) As Boolean
        Try
            If (FileIO.FileSystem.DirectoryExists(path)) Then
                Return True
            Else
                FileIO.FileSystem.CreateDirectory(path)
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function


#End Region

#Region "Main Methods/Functions"
    Private Sub Init(ByVal cActionType As String, ByRef bSuccess As Boolean)

        Select Case UCase(cActionType)
            Case "UPDATE"
                sbLog.Clear()
                Log_Append(StrDup(100, "*"))
                Log_Append("Starting Update Version")
                Log_Append(StrDup(100, "*"))

            Case "LOAD"
                sbLog.Clear()
                Log_Append(StrDup(100, "*"))
                Log_Append("Starting Load Version")
                Log_Append(StrDup(100, "*"))

        End Select

        Log_Append()
        Log_Append()
        Log_Append("Update Log")
        Log_Append("Gathering Information from the server..")

        SetStatus("Gathering Information from the server..")
        cUpdatesFolder = oDb.oVersionDLookUp("Value", cTable_config, "", "Code='UpdatesFolder'")

        Log_Append("Checking updates folder: ".PadRight(nColStandard) & cUpdatesFolder)
        SetStatus("Checking updates folder: " & cUpdatesFolder)
        If cUpdatesFolder <> "" Then
            bSuccess = IsPathExist(cUpdatesFolder, True)
            If bSuccess Then
                bSuccess = HasFolderPermission(cUpdatesFolder)
            Else
                cErr = "No Read and Write Permission"
            End If
        Else
            cErr = "Path does not exist"
        End If
        Log_Append("Updates folder Status: ".PadRight(nColStandard) & " " & GetResult(bSuccess, cErr))

    End Sub

    Private Sub Finish(ByVal cActionType As String, ByVal cFileName As String)
        SetStatus("Update Done.")
        MarqueeProgressBarControl1.Enabled = False
        EndProcess()

        Select Case UCase(cActionType)
            Case "UPDATE"
                Log_Write(CleanPath(GetAppFolder() & "\logs\update") & cFileName, sbLog)
                ShowLog(sbLog.ToString)
                Me.Close()
            Case "LOAD"
                Log_Write(CleanPath(GetAppFolder() & "\logs\update") & cFileName, sbLog)
                ShowLog(sbLog.ToString)
                Me.Close()
        End Select
    End Sub

    Private Sub EndProcess()
        Log_Append(StrDup(100, "*"))
        Log_Append("END")
        Log_Append(StrDup(100, "*"))
    End Sub

    Private Sub RunScript(ByVal cLine As String, Optional ByRef cErr As String = "")
        Dim bSuccess As Boolean = False, strsql As String = "", isSQLFile As Boolean = False
        Dim cLineClean As String = Trim(cLine)
        If cLineClean.Substring(cLineClean.Length - 4, 4).ToLower = ".sql" Then 'Run a scripts saved on a .sql file.
            isSQLFile = True
            'check if not on the script logs
            If oDb.oVersionDLookUp("[ScriptFile]", "[pms_db].[dbo].[MSysScripts_Loaded]", "", "[ScriptFile]='" & cLineClean & "'") = "" Then

                Dim oSchema As String() = cLineClean.Split("-"c)
                If oSchema(0) <> "" Then
                    Dim oDBScript As New clsDB(ConstructConnString(oSchema(0).ToString))
                    bSuccess = oDBScript.TesTConn(cErr)
                    If bSuccess Then
                        Try
                            Using sqlw As New System.IO.StreamReader(CleanPath(cTemp_Folder) & Trim(cLineClean))
                                strsql = sqlw.ReadToEnd()
                            End Using
                            bSuccess = oDBScript.oVersionRunSql(strsql, cErr, False)
                        Catch ex As Exception
                            bSuccess = False
                            cErr = "Error Reading SQL File."
                        End Try

                        Application.DoEvents()
                        Try
                            Kill(CleanPath(cTemp_Folder) & Trim(cLineClean))
                        Catch ex As Exception
                        End Try
                    Else
                        bSuccess = False
                        cErr = "Invalid SQL File Format." & oSchema(0) & " is not a valid Schema." & "Error Msg:" & cErr
                    End If
                Else
                    'invalid file format {sample Valid: "viewYYYYMMdd.sql"}
                    bSuccess = False
                    cErr = "Invalid SQL File Format."
                End If

            Else
                'already on script log
                bSuccess = False
                cErr = "Script File already loaded."
            End If

        Else 'Run script written on the Update.txt
            isSQLFile = False
            Application.DoEvents()
            bSuccess = oDb.oVersionRunSql(cLineClean, cErr, False)
        End If


        'construct Log
        Dim cDisplayLine As String = ""
        If cLineClean.Length >= 40 Then
            cDisplayLine = cLineClean.Substring(0, 40) & " .. "
        Else
            cDisplayLine = cLineClean & " .. "
        End If
        Log_Append(sbVersionLog, cDisplayLine.PadRight(nColStandard) & GetResult(bSuccess, cErr))

        'log SQL file
        If isSQLFile Then
            If bSuccess Then
                bSuccess = oDb.oVersionRunSql("INSERT INTO [pms_db].[dbo].[MSysScripts_Loaded]([ScriptFile],[RunFrom],[DateRun]) VALUES ('" & cLineClean & "','" & My.Computer.Name.Replace("'", "") & "',GETDATE())")
            End If
        End If

    End Sub
#End Region

#Region "Private Functions"

    Public Function ConstructConnString(Optional ByVal DBName As String = "") As String
        If bUSE_SPECTRAL_CON Then
            cServerName = cServerName.Replace("\STISQLSERVER", "")
            Return "Data Source=" & cServerName & "\STISQLSERVER;" & IIf(DBName.Length > 0, "Database=" & DBName & ";", "") & "Persist Security Info=True;User ID=sa;Password=sffSDfsdfdfSDFsdffDFSF2164564DFSD2Df2345ABCSTFS;"
            'Return "Data Source=" & cServerName & "\STISQLSERVER;" & IIf(DBName.Length > 0, "Database=" & DBName & ";", "") & "Persist Security Info=True;User ID=sa;Password=admin1234"
        ElseIf bUSE_TRUSTED_CON Then
            Return "Server=" & cServerName & ";" & IIf(DBName.Length > 0, "Database=" & DBName & ";", "") & "Trusted_Connection=True;"
        Else
            Return "Server=" & cServerName & ";" & IIf(DBName.Length > 0, "Database=" & DBName & ";", "") & "User Id=" & cServerUser & ";Password=" & cServerPwd & ";"
        End If
    End Function

    Private Sub SetStatus(ByVal cMsg As String)
        txtStatus.Text = "Status: " & cMsg
        txtStatus.Update()
    End Sub

    'this will delete filtered files from given directory
    Private Sub CleanFolder(ByVal cPath As String, ByVal Filter As String, ByVal searchOption As System.IO.SearchOption)
        Dim arrFiles() As String = getFiles(cPath, Filter, searchOption)
        Dim arrFile As String
        For Each arrFile In arrFiles
            Try
                Application.DoEvents()
                My.Computer.FileSystem.DeleteFile(arrFile)
                Application.DoEvents()
            Catch ex As Exception
            End Try
        Next
    End Sub

    'update object files (DLLs and EXEs)
    Private Function UpdateObjectFile(ByVal cFileName As String, ByVal cFolderName As String, ByVal cTemp_UpdateFolder As String, ByVal dStart As DateTime, ByRef cErr() As String) As Boolean()
        Dim bReturn() As Boolean = {False, False}
        cErr = {"", ""}
        Try
            If cFileName <> "" Then
                'create a backup file
                Dim nFile As String = GetAppFolder() & "\" & cFileName
                If System.IO.File.Exists(nFile) Then
                    Try
                        My.Computer.FileSystem.CopyFile(nFile, GetAppFolder() & "\obj_bak\" & cFolderName & "\" & GetFileWithoutExtension(nFile) & "_" & dStart.ToString("yyyyMMddHHmmss") & GetFileExtension(nFile))
                        bReturn(0) = True
                    Catch ex As Exception
                        cErr(0) = ex.Message
                        bReturn(0) = False
                    End Try
                Else
                    cErr(0) = "Not Exist"
                    bReturn(0) = False
                End If

                'update object file
                Try
                    Application.DoEvents()
                    My.Computer.FileSystem.CopyFile(CleanPath(cTemp_UpdateFolder) & GetFile(nFile), nFile, True)
                    nFilesUpdated += 1
                    bReturn(1) = True
                Catch ex As Exception
                    nFilesError += 1
                    cErr(1) = ex.Message
                    bReturn(1) = True
                End Try

            End If
        Catch ex As Exception
            'cErr = ex.Message
            bReturn(0) = False
            bReturn(1) = False
        End Try
        Return bReturn
    End Function

    'update other objects that follow certain filename format
    Private Function UpdateOtherObjects(ByVal cFileName As String, ByVal cFolderName As String, ByVal cTemp_UpdateFolder As String, ByVal dStart As DateTime, ByRef cErr() As String) As Boolean()
        Dim bReturn() As Boolean = {False, False}
        Dim arrFileDesc() As String = cFileName.Split(";"c)

        Dim cTag As String
        Dim cPasteType As String
        Dim cSubfolder As String
        Dim cFile As String
        If arrFileDesc.Count = 3 Then

            'other objects to be paste in top directory
            cTag = UCase(arrFileDesc(0))
            cPasteType = UCase(arrFileDesc(1))
            cSubfolder = ""
            cFile = arrFileDesc(2)

            If cTag = "MUSTHAVE" Then
                If cPasteType = "TOPDIR" Then
                    Try
                        Dim nUpFile As String = GetAppFolder() & "\" & cFile
                        If System.IO.File.Exists(nUpFile) Then
                            Try
                                Application.DoEvents()
                                My.Computer.FileSystem.CopyFile(nUpFile, GetAppFolder() & "\obj_bak\" & cFolderName & "\" & GetFileWithoutExtension(nUpFile) & "_" & dStart.ToString("yyyyMMddHHmmss") & GetFileExtension(nUpFile))
                                bReturn(0) = True
                            Catch ex As Exception
                                cErr(0) = ex.Message
                                bReturn(0) = False
                            End Try
                        Else
                            cErr(0) = "Not Exist"
                            bReturn(0) = False
                        End If

                        'update
                        Try
                            Application.DoEvents()
                            My.Computer.FileSystem.CopyFile(CleanPath(cTemp_UpdateFolder) & GetFile(cFileName), nUpFile, True)
                            nFilesUpdated += 1
                            bReturn(1) = True
                        Catch ex As Exception
                            nFilesError += 1
                            cErr(1) = ex.Message
                            bReturn(1) = False
                        End Try
                    Catch ex As Exception
                        'cErr = ex.Message
                        bReturn = {False, False}
                    End Try
                End If
            End If

        ElseIf arrFileDesc.Count = 4 Then
            'other objects to be paste in sub folder
            cTag = UCase(arrFileDesc(0))
            cPasteType = UCase(arrFileDesc(1))
            cSubfolder = arrFileDesc(2)
            cSubfolder = cSubfolder.Replace("-", "\")
            cFile = arrFileDesc(3)

            If cTag = "MUSTHAVE" Then
                If cPasteType = "SUBDIR" Then
                    Try
                        Dim nUpFile As String = CleanPath(GetAppFolder()) & cSubfolder & "\" & cFile
                        If System.IO.File.Exists(nUpFile) Then
                            Try
                                Application.DoEvents()
                                My.Computer.FileSystem.CopyFile(nUpFile, GetAppFolder() & "\obj_bak\" & cFolderName & "\" & GetFileWithoutExtension(nUpFile) & "_" & Now.ToString("yyyyMMddHHmmss") & GetFileExtension(nUpFile))
                                bReturn(0) = True
                            Catch ex As Exception
                                cErr(0) = ex.Message
                                bReturn(0) = False
                            End Try
                        Else
                            cErr(0) = "Not Exist"
                            bReturn(0) = False
                        End If
                        'update
                        Try
                            Application.DoEvents()
                            My.Computer.FileSystem.CopyFile(CleanPath(cTemp_UpdateFolder) & cSubfolder & "\" & GetFile(cFileName), nUpFile, True)
                            nFilesUpdated += 1
                            bReturn(1) = True
                        Catch ex As Exception
                            nFilesError += 1
                            cErr(1) = ex.Message
                            bReturn(1) = False
                        End Try

                    Catch ex As Exception
                        cErr = {"", ""}
                        bReturn = {False, False}
                    End Try
                End If
            End If

        Else
            nFilesInvalid += 1
            'no action.. doesnt meet the filename requirements.
            cErr = {"INVALID FILE", "INVALID FILE"}
        End If
        Return bReturn
    End Function

    Public Sub ShowLog(ByVal cLog As String)
        Dim frmLogViewer As New frmLogViewer
        frmLogViewer.txtLogText.Text = cLog
        frmLogViewer.ShowDialog()
    End Sub

    Public Sub Log_Append(ByRef sbLog As StringBuilder, ByVal cLine As String)
        sbLog = sbLog.Append(Format(Now, "hh:mm:ss tt | ") & cLine & vbCrLf)
    End Sub

    Public Sub Log_Append(ByRef sbLog As StringBuilder, ByVal sbLine As StringBuilder)
        If sbLine Is Nothing Then
            sbLine = New StringBuilder("")
        End If
        sbLog.Append(sbLine.ToString)
        sbLog.Append(vbCrLf)
    End Sub

    Public Sub Log_Append(Optional ByVal cLine As String = "")
        sbLog = sbLog.Append(Format(Now, "hh:mm:ss tt | ") & cLine & vbCrLf)
    End Sub

    Public Sub Log_Append(ByVal sbTmpLog As StringBuilder)
        sbLog = sbLog.Append(Format(Now, "hh:mm:ss tt | ") & sbTmpLog.ToString & vbCrLf)
    End Sub

    Private Sub Log_Write(ByVal cPath As String, ByVal cLog As StringBuilder)
        Dim cDir As String
        cDir = GetFileDirectory(cPath)
        Try
            'write log.txt
            If Not IsPathExist(cDir, True) Then
                System.IO.Directory.CreateDirectory(cDir)
            End If
            System.IO.File.WriteAllText(cPath, cLog.ToString)
        Catch ex As Exception
            MsgBox("An error occurred writing log!", MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function Log_FileName(ByVal clog_filename As String) As String
        Dim cInstallFolder As String = CleanPath(GetAppFolder)
        Dim cUpdateLogFolder As String = CleanPath(cInstallFolder & "logs\updates")
        Dim cCopyLogFile As String = ""
        Dim cRetVal As String = ""


        cCopyLogFile = Format(Now, "yyyyMMddHHmmss") & "-" & clog_filename & ".txt"

        If Not IsPathExist(cUpdateLogFolder, True) Then
            System.IO.Directory.CreateDirectory(cUpdateLogFolder)
        End If

        cRetVal = cUpdateLogFolder & cCopyLogFile

        Return cRetVal
    End Function

    Private Function GetResult(ByVal bSuccess As Boolean, ByVal cErr As String, Optional ByVal cAltOKText As String = "OK", Optional ByVal cAltFAILEDText As String = "FAILED") As String
        Return IIf(bSuccess, cAltOKText, cAltFAILEDText) & IIf(cErr.Length > 0, " (" & cErr & ")", "")
    End Function


#End Region

#Region "ChilKat"
    'FUNCTION : zip files given by cFileSpec (a semi-colon delimited list of masks)
    '           ex: cFileSpec = "*.csv;*log.txt"
    Private Function ZipFiles(ByVal cZipFile As String, ByVal cFileSpec As String, Optional ByRef cErr As String = "") As Boolean
        Dim bSuccess As Boolean = True
        Dim zip As New Chilkat.Zip()
        Dim nCtr As Integer

        '  Any string unlocks the component for the 1st 30-days.
        If bSuccess Then
            bSuccess = zip.UnlockComponent("SPCTASZIP_4gpKXqstjEuf")
            If Not bSuccess Then
                cErr = zip.LastErrorText
            End If
        End If

        If bSuccess Then
            bSuccess = zip.NewZip(cZipFile)
            If (bSuccess <> True) Then
                cErr = zip.LastErrorText
            End If
        End If

        '  Append a directory tree.  The call to AppendFiles does
        '  not read the file contents or append them to the zip
        '  object in memory.  It simply appends references
        '  to the files so that when WriteZip or WriteZipAndClose
        '  is called, the referenced files are streamed and compressed
        '  into the .zip output file.

        If bSuccess Then
            Dim recurse As Boolean
            recurse = False
            For nCtr = 1 To CountItemDelimited(cFileSpec, ";")
                bSuccess = bSuccess And zip.AppendFiles(GetItemDelimited(cFileSpec, nCtr, ";"), recurse)
                If (bSuccess <> True) Then
                    cErr = cErr & IIf(cErr.Length > 0, vbCrLf, "") & zip.LastErrorText
                End If
            Next
        End If

        If bSuccess Then
            bSuccess = zip.WriteZipAndClose()
            If (bSuccess <> True) Then
                cErr = zip.LastErrorText
            End If
        End If

        Return bSuccess
    End Function

    'FUNCTION : unzip files in [cZipFile] and extract to folder [cExtractTo]
    Private Function ZipExtract(ByVal cZipFile As String, ByVal cExtractTo As String, Optional ByRef cErr As String = "", Optional ByRef nFileCount As Integer = 0) As Boolean
        Dim bSuccess As Boolean = True
        Dim zip As New Chilkat.Zip()

        '  Any string unlocks the component for the 1st 30-days.
        If bSuccess Then
            bSuccess = zip.UnlockComponent("SPCTASZIP_4gpKXqstjEuf")
            If (bSuccess <> True) Then
                cErr = zip.LastErrorText
            End If
        End If

        If bSuccess Then
            bSuccess = zip.OpenZip(cZipFile)
            If (bSuccess <> True) Then
                cErr = zip.LastErrorText
            End If
        End If

        If bSuccess Then
            nFileCount = zip.Unzip(cExtractTo)
            If nFileCount = -1 Then
                cErr = zip.LastErrorText
            End If
        End If

        Return bSuccess

    End Function
#End Region

End Class
