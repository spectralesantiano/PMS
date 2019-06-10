Imports System.Text
Imports System.IO
Imports DevExpress.XtraSplashScreen

Public Class BACKUPRESTORE
    Dim strDir As String = ""
    Dim sbLog As New StringBuilder("")
    Private nColStandard As Integer = 20
    Dim cFullDataFileName As String, cDataConcat As String, cErr As String = ""
    Dim dStartTime As DateTime, dEndTime As DateTime

    Public Function Browse()
        If MsgBox("Please specify where you want to store backup files.", MsgBoxStyle.Information Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim odMain As New System.Windows.Forms.FolderBrowserDialog
            If odMain.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                strDir = odMain.SelectedPath
                Try
                    DB.RunSql("UPDATE [sti_sys].[dbo].[tblSTIService_profile] SET [PROF_Name] = '" & BACKUP_NAME & "' ,[PROF_ExpFolder] = '" & strDir & "' ,[DateUpdated] = GETDATE() WHERE [PROF_Code] = '" & BACKUP_CODE & "'")
                    If MainView.RowCount > 0 AndAlso MsgBox("Do you want to copy the previous backup files on the new backup directory?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        Dim c As Integer
                        For c = 0 To MainView.RowCount - 1
                            Try
                                FileCopy(MainView.GetRowCellValue(c, "FileName"), strDir & "\" & GetFileName(MainView.GetRowCellValue(c, "FileName")))
                            Catch ex As Exception
                            End Try
                        Next
                    End If
                    Return True
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                    Return False
                End Try
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Private Sub EditBackupDir()
        If isInstalledonServer() Then
            If Browse() Then
                lblDir.Text = strDir
                RefreshData()
            End If
        Else
            MsgBox("Changing default backup directory has been disabled!" & vbNewLine & vbNewLine & "Please install PMS in the database server then try again.", MsgBoxStyle.Exclamation, GetAppName)
        End If
    End Sub

    Public Overrides Sub DeleteData()
        If MsgBox("Are you sure want to delete " & MainView.GetRowCellValue(MainView.FocusedRowHandle, "Description").ToString.Replace("_", " ") & " Backup?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Try
                System.IO.File.Delete((MainView.GetRowCellValue(MainView.FocusedRowHandle, "FileName")))
                MainView.DeleteRow(MainView.FocusedRowHandle)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
            AllowDeletion(Name, MainView.RowCount > 0)
        End If
    End Sub

    Private Sub Backup()
        Dim cnt As Integer
        MainView.CloseEditor()
        MainView.UpdateCurrentRow()
        For cnt = 0 To MainView.RowCount - 1
            If MainView.GetRowCellValue(cnt, "NewItem") = 1 Then
                SplashScreenManager.ShowForm(GetType(WaitForm))
                Dim errorLog As String = ""
                If RunBackUp(MainView.GetRowCellValue(cnt, "Description").ToString.Replace("_", " ").Replace("\", ""), errorLog) Then
                    DB.SaveConfig("LASTBACKUP", Year(Now).ToString("0000") & "-" & Month(Now).ToString("00") & "-" & Day(Now).ToString("00"), APP_SHORT_NAME)
                    MsgBox("Successfully backup database!", MsgBoxStyle.Information, GetAppName)
                Else
                    MsgBox("Backup completed with error(s)!", MsgBoxStyle.Exclamation, GetAppName)
                    Dim strFile As String = CleanPath(GetAppPath) & "Errors\backup_" & Now.ToString("yyyyMMdd.HHmmss") & ".txt"
                    Dim logwriteError As String = ""
                    Log_Write(strFile, logwriteError)
                    Try
                        System.Diagnostics.Process.Start(strFile)
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If
                SplashScreenManager.CloseForm()
            End If
        Next
        RefreshData()
    End Sub

    Private Sub Restore()
        If MainView.GetRowCellValue(MainView.FocusedRowHandle, "NewItem") = 0 Then
            SplashScreenManager.ShowForm(GetType(WaitForm))
            Dim errorLog As String = ""
            If RunRestore(MainView.GetRowCellValue(MainView.FocusedRowHandle, "FileName"), errorLog) Then
                MsgBox("Successfully restore database!", MsgBoxStyle.Information, GetAppName)
            Else
                MsgBox("Restore completed with error(s)!", MsgBoxStyle.Exclamation, GetAppName)
                Dim strFile As String = CleanPath(GetAppPath) & "Errors\restore_" & Now.ToString("yyyyMMdd.HHmmss") & ".txt"
                Dim logwriteError As String = ""
                Log_Write(strFile, logwriteError)
                Try
                    System.Diagnostics.Process.Start(strFile)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
            SplashScreenManager.CloseForm()
        End If
    End Sub

    Public Overrides Sub ExecCustomFunction(ByVal param() As Object)
        Select Case param(0)
            Case "Restore"
                Restore()
            Case "Backup"
                Backup()
            Case "Edit"
                EditBackupDir()
        End Select
    End Sub

    'Overriden From Base Control
    Public Overrides Sub RefreshData()
        If Not isInstalledonServer() Then
            SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
            SetSaveVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
            SetDeleteVisibility(Name, IIf((bPermission And 8) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never))
            AllowDeletion(Name, MainView.RowCount > 0)
            RaiseCustomEvent(Name, New Object() {"DisableBackup"})
            RaiseCustomEvent(Name, New Object() {IIf(MainView.RowCount > 0, "EnableRestore", "DisableRestore")})
            RaiseCustomEvent(Name, New Object() {"RenameEdit", "Edit Backup Directory"})
            SetDeleteCaption(Name, "Delete Backup")
            Exit Sub
        End If

        Dim ctable As New DataTable, ccolumn As DataColumn
        ccolumn = New DataColumn
        ccolumn.ColumnName = "nDate"
        ccolumn.DataType = System.Type.GetType("System.DateTime")
        ctable.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "Description"
        ccolumn.DataType = System.Type.GetType("System.String")
        ctable.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "NewItem"
        ccolumn.DataType = System.Type.GetType("System.Int16")
        ctable.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "FileName"
        ccolumn.DataType = System.Type.GetType("System.String")
        ctable.Columns.Add(ccolumn)


        GetBackupProfile()
        If strDir = "" Then
            Browse()
        End If
        Me.lblDir.Text = strDir
        If System.IO.Directory.Exists(strDir) Then
            Dim di As New IO.DirectoryInfo(strDir)
            Dim dirFiles As IO.FileInfo() = di.GetFiles()
            Dim dra As IO.FileInfo
            For Each dra In dirFiles
                Try
                    Dim strFile() As String = GetFileNameWithoutExtension(dra.Name).Split("_")
                    If strFile(0) <> "" Then
                        Dim backFilename() As String = strFile(0).Split("-")
                        If backFilename(0) = "PMSBACKUP" Then
                            Dim crow() As Object = {ChangeLongDateStrToDate(backFilename(1).Replace(".", "")), strFile(1), 0, strDir & "\" & dra.Name}
                            ctable.Rows.Add(crow)
                        End If
                    End If
                Catch ex As Exception
                End Try
            Next
            MainGrid.DataSource = ctable
        Else
            MsgBox("Can't find the backup directory.", MsgBoxStyle.Critical, GetAppName)
        End If
        SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetSaveVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetDeleteVisibility(Name, IIf((bPermission And 8) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never))
        AllowDeletion(Name, MainView.RowCount > 0)
        RaiseCustomEvent(Name, New Object() {"DisableBackup"})
        RaiseCustomEvent(Name, New Object() {IIf(MainView.RowCount > 0, "EnableRestore", "DisableRestore")})
        RaiseCustomEvent(Name, New Object() {"RenameEdit", "Edit Backup Directory"})
        SetDeleteCaption(Name, "Delete Backup")
    End Sub

    Private Sub MainView_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles MainView.FocusedRowChanged
        Try
            If MainView.FocusedRowHandle >= 0 Then
                If MainView.GetRowCellValue(MainView.FocusedRowHandle, "NewItem") = 1 Then
                    RaiseCustomEvent(Name, New Object() {"DisableRestore"})
                    RaiseCustomEvent(Name, New Object() {"EnableBackup"})
                    AllowDeletion(Name, False)
                Else
                    RaiseCustomEvent(Name, New Object() {"EnableRestore"})
                    RaiseCustomEvent(Name, New Object() {"DisableBackup"})
                    AllowDeletion(Name, (bPermission And 8) > 0)
                End If
            Else
                RaiseCustomEvent(Name, New Object() {"DisableRestore"})
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MainView_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles MainView.InitNewRow
        MainView.SetRowCellValue(e.RowHandle, "nDate", Now)
        MainView.SetRowCellValue(e.RowHandle, "NewItem", 1)
        RaiseCustomEvent(Name, New Object() {"EnableBackup"})
    End Sub

    Private Sub MainView_RowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
        If MainView.GetRowCellValue(e.RowHandle, "NewItem") = 1 And MainView.FocusedRowHandle = e.RowHandle Then
            e.Appearance.BackColor = EDITED_FOCUSED_COLOR
        ElseIf MainView.GetRowCellValue(e.RowHandle, "NewItem") = 1 Then
            e.Appearance.BackColor = EDITED_COLOR
        ElseIf e.RowHandle = MainView.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        End If
        If e.Column.ReadOnly Then
            e.Appearance.BackColor = DISABLED_COLOR
        End If
    End Sub

    Private Sub MainView_ShowingEditor(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MainView.ShowingEditor
        If MainView.FocusedRowHandle >= 0 Then
            If MainView.GetRowCellValue(MainView.FocusedRowHandle, "NewItem") = 0 Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles header.MouseUp, MainView.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            OnRightClick(Name)
        End If
    End Sub

    Private Sub GetBackupProfile()
        strDir = DB.DLookUp("[PROF_ExpFolder]", "[sti_sys].[dbo].[tblSTIService_profile]", "", "[PROF_Code]='" & BACKUP_CODE & "'")
        If isInstalledonServer() Then
            If Not System.IO.Directory.Exists(strDir) Then
                Try
                    System.IO.Directory.CreateDirectory(strDir)
                Catch ex As Exception
                End Try
            End If
        End If

    End Sub

    Private Function RunBackUp(ByVal cDescription As String, Optional ByRef strlog As String = "") As Boolean
        Dim bReturn As Boolean = False, bSuccess As Boolean = False, filestoZip As String = ""
        Try
            dStartTime = Now
            cDataConcat = Format(dStartTime, "yyyyMMdd") & "." & Format(dStartTime, "HHmmss")
            cFullDataFileName = CleanPath(strDir) & BACKUP_NAME & "-" & cDataConcat & "_" & cDescription.Replace("'", "").Replace("\", "") & ".ZIP"

            'initialize log
            ProcInit("BACKUP")

            'check Backup Directory
            If Not Directory.Exists(strDir) Then
                cErr = "Backup folder is invalid: """ & strDir & """"
                Log_Append(cErr)
                bReturn = False
            Else
                bReturn = True
            End If

            If bReturn Then
                'try to backup schema files
                Dim cBackSchema As String = "pms_db;sas_tbl;sasa_tbl;sti_sys"
                Dim cnt As Integer = 0, workingSchema As String, zErr As String, backupFile As String
                Dim oBackups() As String = cBackSchema.Split(";"c)

                For cnt = 0 To oBackups.Length - 1
                    zErr = ""
                    workingSchema = oBackups(cnt)
                    backupFile = workingSchema & "-" & cDataConcat & ".bak"
                    bSuccess = DB.Backup(workingSchema, CleanPath(strDir) & backupFile, zErr)
                    Log_Append(("BACKUP " & workingSchema & " :").PadRight(nColStandard) & GetResult(bSuccess, zErr))
                    If bSuccess Then
                        filestoZip = filestoZip & CleanPath(strDir) & backupFile & ";"
                    End If
                    bReturn = bReturn And bSuccess
                Next
            End If
        Catch ex As Exception
            cErr = "Error msg: " & ex.Message
            Log_Append(cErr)
            bReturn = False
        End Try

        'end log
        ProcEnd("BACKUP")
        'create log file
        Dim strLogFullFilename As String = CleanPath(strDir) & "backup_log_" & cDataConcat & ".txt"
        Log_Write(strLogFullFilename)

        'format filestozip string
        filestoZip = filestoZip & strLogFullFilename
        'zip files
        bReturn = bReturn And ZipFiles(cFullDataFileName, filestoZip, cErr)
        'delete files
        CleanFiles(filestoZip)

        If Not bReturn Then strlog = sbLog.ToString()

        Return bReturn
    End Function

    Private Function RunRestore(ByVal strFile As String, Optional ByRef strlog As String = "") As Boolean
        Dim bReturn As Boolean = False, bSuccess As Boolean = True
        Dim nFileCount As Integer = 0, cTmpFolder As String = "temp_folder"
        Try
            dStartTime = Now
            cFullDataFileName = strFile
            cDataConcat = Format(dStartTime, "yyyyMMdd") & "." & Format(dStartTime, "HHmmss")

            ProcInit("RESTORE")

            'checking file
            If System.IO.File.Exists(cFullDataFileName) Then
                bReturn = True
                Log_Append("Checking File Location: " & cFullDataFileName)
                Log_Append(StrDup(100, "-"))
                Log_Append("OK: File Found")
                Log_Append(StrDup(100, "-"))
            Else
                cErr = "File Not found: " & cFullDataFileName
                Log_Append(cErr)
                bReturn = False
            End If
            bReturn = True

            If bReturn Then
                Dim allowedRestoreSchema() As String = "sas_tbl;sasa_tbl;pms_db".Split(";"c)

                'extract to TempFolder
                bReturn = bReturn And ZipExtract(cFullDataFileName, CleanPath(strDir) & cTmpFolder, cErr, nFileCount)
                Log_Append()
                Log_Append()
                Log_Append("Extracting to " & cTmpFolder)
                Log_Append(StrDup(100, "-"))
                Log_Append("File: " & cFullDataFileName & " ... " & GetResult(bSuccess, cErr))
                Log_Append(StrDup(100, "-"))
                Log_Append()

                If bReturn Then
                    'try restore schema
                    Dim di As New IO.DirectoryInfo(CleanPath(strDir) & cTmpFolder)
                    Dim dirFiles As IO.FileInfo() = di.GetFiles()
                    Dim dra As IO.FileInfo
                    For Each dra In dirFiles
                        Try
                            Dim strFilename() As String = GetFileNameWithoutExtension(dra.Name).Split("-"c)
                            If strFilename(0) <> "" And allowedRestoreSchema.Contains(strFilename(0)) Then
                                Dim zSchema As String = strFilename(0), zErr As String = "", r As Boolean = False
                                Log_Append("SCHEMA TO RESTORE: ".PadRight(nColStandard) & zSchema)
                                r = DB.Restore(zSchema, CleanPath(strDir) & cTmpFolder & "\" & dra.Name, zErr)
                                Log_Append(("RESTORE RESULT:").PadRight(nColStandard) & GetResult(r, zErr))

                                bReturn = bReturn And r
                            End If
                        Catch ex As Exception
                        End Try
                    Next
                    Log_Append()
                End If
            End If

        Catch ex As Exception
            cErr = "Error Msg: " & ex.Message
            bReturn = False
        End Try

        'end log
        ProcEnd("RESTORE")

        'delete temp Folder
        Try
            System.IO.Directory.Delete(CleanPath(strDir) & cTmpFolder, True)
        Catch ex As Exception
        End Try

        If Not bReturn Then strlog = sbLog.ToString()

        Return bReturn
    End Function


    Private Function isInstalledonServer() As Boolean
        Dim bReturn As Boolean = False
        Dim cTempSQLSERVER As String = SQL_SERVER
        Dim cArr() As String = cTempSQLSERVER.Split("\"c)
        cTempSQLSERVER = cArr(0)
        If cTempSQLSERVER = "." Or UCase(cTempSQLSERVER) = "LOCALHOST" Then
            bReturn = True
        Else
            bReturn = False
        End If
        Return bReturn
    End Function

    Private Sub CleanFiles(ByVal cFiles As String)
        Dim ArrFiles() As String = cFiles.Split(";"c)
        Dim x As Integer = 0
        For x = 0 To ArrFiles.Length - 1
            Try
                If ArrFiles(x) <> "" Then
                    System.IO.File.Delete(ArrFiles(x))
                End If

            Catch ex As Exception
            End Try
        Next
    End Sub

    Private Sub Log_Append(Optional ByVal cLine As String = "")
        sbLog = sbLog.Append(Format(Now, "hh:mm:ss tt | ") & cLine & vbCrLf)
    End Sub

    Private Sub Log_Write(ByVal strLogFileFull As String, Optional ByRef errorMsg As String = "")
        'write log.txt
        Try
            System.IO.File.WriteAllText(strLogFileFull, sbLog.ToString)
        Catch ex As Exception
            errorMsg = ex.Message
        End Try
    End Sub

    Private Sub ProcInit(ByVal ProcessType As String)
        sbLog.Clear()
        Select Case UCase(ProcessType)
            Case "BACKUP"
                Log_Append(StrDup(100, "*"))
                Log_Append("Starting Backup Database")
                Log_Append(StrDup(100, "*"))
                Log_Append()
                Log_Append()
                Log_Append("BACKUP Log")
                Log_Append(StrDup(100, "="))
                Log_Append("PMS Version: ".PadRight(nColStandard) & VERSION_NUMBER)
                Log_Append("Log Description: ".PadRight(nColStandard) & "MANUAL Run Backup")
                Log_Append("Backup File: ".PadRight(nColStandard) & cFullDataFileName)
                Log_Append("Backup Date: ".PadRight(nColStandard) & Format(dStartTime, "yyyy-MM-dd hh:mm:ss"))
                Log_Append("Server Instance: ".PadRight(nColStandard) & SQL_SERVER)
                Log_Append()
                Log_Append()
                Log_Append(StrDup(100, "="))
                Log_Append()
                Log_Append()
                Log_Append("Profile Info")
                Log_Append(StrDup(100, "-"))
                Log_Append("Profile Name: ".PadRight(nColStandard) & BACKUP_NAME & " run from PMS Interface")
                Log_Append("Backup Folder: ".PadRight(nColStandard) & strDir)
                Log_Append()
                Log_Append()
            Case "RESTORE"
                Log_Append(StrDup(100, "*"))
                Log_Append("Starting Restoring Database")
                Log_Append(StrDup(100, "*"))
                Log_Append("Restore Log")
                Log_Append(StrDup(100, "="))
                Log_Append("PMS Version: ".PadRight(nColStandard) & VERSION_NUMBER)
                Log_Append("Log Description: ".PadRight(nColStandard) & "Manual Run Restore")
                Log_Append()
                Log_Append("Server Instance: ".PadRight(nColStandard) & SQL_SERVER)
                Log_Append("Restore Date: ".PadRight(nColStandard) & Format(dStartTime, "yyyy-MM-dd hh:mm:ss"))
        End Select
    End Sub

    Private Sub ProcEnd(ByVal ProcessType As String)
        Select Case UCase(ProcessType)
            Case "BACKUP", "RESTORE"
                'write log file
                dEndTime = Now
                Log_Append()
                Log_Append("Total Time Taken")
                Log_Append(StrDup(100, "-"))
                Log_Append("Start Time: ".PadRight(25) & Format(dStartTime, "yyyy-MM-dd hh:mm:ss"))
                Log_Append("End Time: ".PadRight(25) & Format(dEndTime, "yyyy-MM-dd hh:mm:ss"))
                Log_Append("Elapsed time: ".PadRight(25) & TimeElapsed(DateDiff(DateInterval.Second, dStartTime, dEndTime)))
                Log_Append()
                Log_Append("*** END ***")

        End Select
    End Sub

    Private Function GetResult(ByVal bSuccess As Boolean, ByVal cErr As String, Optional ByVal cAltOKText As String = "OK", Optional ByVal cAltFAILEDText As String = "FAILED") As String
        Return IIf(bSuccess, cAltOKText, cAltFAILEDText) & IIf(cErr.Length > 0, " (" & cErr & ")", "")
    End Function
End Class
