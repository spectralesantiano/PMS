Imports System.IO

Module modBasicFuncitons
    Public PMSDB As SQLDB
    Private Declare Ansi Function WritePrivateProfileString Lib "kernel32.dll" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer
    Private Declare Ansi Function GetPrivateProfileString Lib "kernel32.dll" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As System.Text.StringBuilder, ByVal nSize As Integer, ByVal lpFileName As String) As Integer

    Public Function GetConnectionString(Optional ByVal hasUseDB As Boolean = True)
        If USE_SPECTRAL_CON Then
            SQL_SERVER = SQL_SERVER.Replace("\STISQLSERVER", "")
            Return "Data Source=" & SQL_SERVER & "\STISQLSERVER;" & IIf(hasUseDB, "Database=pms_db;", "") & "Persist Security Info=True;User ID=sa;Password=sffSDfsdfdfSDFsdffDFSF2164564DFSD2Df2345ABCSTFS"
        ElseIf USE_TRUSTED_CON Then
            Return "Server=" & SQL_SERVER & ";" & IIf(hasUseDB, "Database=pms_db;", "") & "Trusted_Connection=True;"
        Else
            Return "Server=" & SQL_SERVER & ";" & IIf(hasUseDB, "Database=pms_db;", "") & "User Id=" & SQL_USER_NAME & ";Password=" & SQL_PASSWORD & ";"
        End If
    End Function


    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetServerName() As String
        If SQL_SERVER = "." Then
            Return " Connected on : ( localhost )"
        Else
            Return " Connected on : ( " & SQL_SERVER & " )"
        End If
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetIni(ByVal cKey As String) As String
        Dim retval As New System.Text.StringBuilder(100)
        GetPrivateProfileString("APP", cKey, "", retval, 100, GetAppPath() & "\setting.ini")
        Return retval.ToString
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Sub WriteIni(ByVal ckey As String, ByVal cVal As String)
        WritePrivateProfileString("APP", ckey, cVal, GetAppPath() & "\setting.ini")
    End Sub

    '************** Versioning And Licensing Purposes ******************
    Public Sub CheckAppVersion(Optional ByVal isProgramOpen As Boolean = False, Optional ByRef cErr As String = "")
        Try
            Dim str As String = GetConnectionString(False)
            Dim cCurVersion As String
            Dim nCurDBVersion As String = ""
            Dim cCurVersionDate As String
            Dim oAppVersion As New clsVersioning(str)

            cCurVersion = IIf(Trim(CType(GetIni("VERSION"), String)) = "" Or IsNothing(Trim(CType(GetIni("VERSION"), String))), "", Trim(CType(GetIni("VERSION"), String)))
            cCurVersionDate = IIf(Trim(CType(GetIni("VERSIONDATE"), String)) = "" Or IsNothing(Trim(CType(GetIni("VERSIONDATE"), String))), "", Trim(CType(GetIni("VERSIONDATE"), String)))

            If oAppVersion.IsInitialized(cCurVersion) Then

                If oAppVersion.IsVersionUpdated(cCurVersion, nCurDBVersion) Then
                    VERSION_NUMBER = cCurVersion
                    Try
                        If cCurVersionDate <> "" Then
                            VERSION_DATE = DateSerial(cCurVersionDate.Substring(0, 4), cCurVersionDate.Substring(5, 2), cCurVersionDate.Substring(8, 2))
                        Else
                            VERSION_DATE = Date.Now
                        End If
                    Catch ex As Exception
                        VERSION_DATE = Date.Now
                    End Try
                Else
                    If oAppVersion.IsNewVersion(nCurDBVersion, cCurVersion) Then

                        Dim cMsg As String
                        If isProgramOpen Then
                            cMsg = "A new version of application is available!" & vbNewLine & vbNewLine &
                                  "Latest Version: " & nCurDBVersion.ToString & vbNewLine &
                                  "Your Version: " & cCurVersion & vbNewLine & vbNewLine &
                                  "Please save all your changes before proceeding." & vbNewLine & vbNewLine &
                                  "Do you wish to update?"
                        Else
                            cMsg = "A new version of application is available!" & vbNewLine & vbNewLine &
                                  "Latest Version: " & nCurDBVersion.ToString & vbNewLine &
                                  "Your Version: " & cCurVersion & vbNewLine & vbNewLine &
                                  "Do you wish to update?"
                        End If

                        If MsgBox(cMsg, MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Version not sync.") = MsgBoxResult.Yes Then

                            Dim nSmgr As Integer = 0
                            nSmgr = System.Diagnostics.Process.GetProcessesByName("PlannedMaintenance").Count

                            If nSmgr > 1 Then
                                MsgBox("Cannot proceed update!" & vbCrLf & vbCrLf & "Another instance of " & GetAppName() & " detected. Please close it before continuing.", MsgBoxStyle.Exclamation, GetAppName)
                                Exit Sub
                            End If

                            VERSION_NUMBER = cCurVersion

                            'defining arguments should be : [ACTIONTYPE] [CURRENT_INTERFACE_VERSION] [SQLSERVER] [SQLUSER] [SQLPWD] [USE_SPECTRAL_CON] [USE_TRUSTED_CON]
                            'param ACTIONTYPE: [UPDATE or LOAD]
                            Dim strArgs As String = "UPDATE " & cCurVersion & " " & """" & SQL_SERVER & """ """ & SQL_USER_NAME & """ """ & SQL_PASSWORD & """ """ & USE_SPECTRAL_CON.ToString & """ """ & USE_TRUSTED_CON.ToString & """"
                            Dim result As Integer = ReviseUpdateManager(nCurDBVersion, "UPDATE")

                            If (result = -1) Then
                                MessageBox.Show("There is a problem revising the UpdateManager.exe", "Spectral Service", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Process.GetCurrentProcess.Kill()
                            End If

                            If System.Environment.OSVersion.Version.Major < 6 Then ' Windows XP
                                Try
                                    Shell("UpdateManager.exe " & strArgs, AppWinStyle.NormalFocus)
                                Catch ex As Exception
                                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, GetAppName)
                                End Try
                                'stop application
                                Process.GetCurrentProcess.Kill()

                            Else ' Higher OS Versions

                                Dim pUpdater As New ProcessStartInfo
                                pUpdater.FileName = "UpdateManager.exe"
                                'defining arguments should be : [ACTIONTYPE] [CURRENT_INTERFACE_VERSION] [obx file path] [username] [SQLSERVER] [SQLUSER] [SQLPWD] [USE_SPECTRAL_CON] [USE_TRUSTED_CON]
                                'param ACTIONTYPE: [UPDATE or LOAD]
                                pUpdater.Arguments = strArgs
                                pUpdater.UseShellExecute = True
                                pUpdater.WindowStyle = ProcessWindowStyle.Normal
                                Try
                                    Dim proc As Process = Process.Start(pUpdater)
                                Catch ex As Exception
                                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, GetAppName)
                                End Try
                                'stop application
                                Process.GetCurrentProcess.Kill()
                            End If

                        Else
                            If Not isProgramOpen Then
                                'stop application
                                Process.GetCurrentProcess.Kill()
                            End If
                        End If

                    ElseIf Not oAppVersion.IsNewVersion(nCurDBVersion, cCurVersion) And Not isProgramOpen Then
                        If MsgBox("You are trying to connect to an older version of database." & vbNewLine & vbNewLine &
                                  "This might lead to any database concerned error(s)." & vbNewLine & vbNewLine &
                                  "Database Version: " & nCurDBVersion.ToString & vbNewLine &
                                  "Interface Version: " & cCurVersion & vbNewLine & vbNewLine &
                                  "Continue Anyway?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Database not sync.") = MsgBoxResult.Yes Then
                            VERSION_NUMBER = cCurVersion
                            Try
                                If cCurVersionDate <> "" Then
                                    VERSION_DATE = DateSerial(cCurVersionDate.Substring(0, 4), cCurVersionDate.Substring(5, 2), cCurVersionDate.Substring(8, 2))
                                Else
                                    VERSION_DATE = Date.Now
                                End If
                            Catch ex As Exception
                                VERSION_DATE = Date.Now
                            End Try
                        Else
                            'stop application
                            Process.GetCurrentProcess.Kill()
                        End If
                    End If
                End If
            Else
                'Application Version not initialized
            End If
        Catch ex As Exception
            MsgBox("An error occurred checking Application Version!", MsgBoxStyle.Exclamation)
            Process.GetCurrentProcess.Kill()
        End Try
    End Sub

    Public Function ReviseUpdateManager(Optional ByVal versionNo As String = "", Optional ByVal updateType As String = "") As Integer
        'If an UpdateManager.exe is present on UpdatesFolder, it will be copied to ERB main dir before calling the UpdateManager.exe
        Try
            Dim updatePath As String = PMSDB.DLookUp("Value", "[sti_sys].[dbo].[tblPMSConfig]", "", "CODE='UpdatesFolder'")
            If updatePath.Equals("") Then Return 0
            Dim updateFilesPath As System.IO.FileInfo() = Nothing
            Select Case updateType
                'If the type is UPDATE, look on the share folder (updatePath) where the contents of this version is location, and get all the files. 
                Case "UPDATE"
                    updateFilesPath = New System.IO.DirectoryInfo(updatePath & (IIf(versionNo.Equals(""), "", "\" & versionNo))).GetFiles()
                    'If the type is LOAD, go to temp_update folder, where the obx contents is temporarily extracted when obx is loaded.
                Case "LOAD"
                    updateFilesPath = New System.IO.DirectoryInfo(APP_PATH & "\temp_update\" & versionNo).GetFiles()
            End Select

            If (Not IsNothing(updateFilesPath)) Then
                For Each f As FileInfo In updateFilesPath
                    If (f.Name.Contains("UpdateManager.exe")) Then
                        File.Copy(APP_PATH & "\UpdateManager.exe", APP_PATH & "\temp_update\" & versionNo & "\UpdateManager_bak_" & DateTime.Now.ToString("MMddyyyy_hhmmss") & ".bakobx") 'Backup original UpdateManager.exe
                        File.Copy(updatePath & "\UpdateManager.exe", APP_PATH & "\UpdateManager.exe", True) 'Copy new UpdateManager.exe
                        File.Delete(updatePath & "\UpdateManager.exe") 'Delete UpdateManager.exe from the update source folder.
                        Return 1 'The UpdateManager.exe is found and successfully updated.
                    End If
                Next
            End If
            Return 0 'There is no UpdateManager.exe on this obx update. So skip it.
        Catch ex As Exception
            Return -1 'There is a problem loading the UpdateManager.exe on specified folder (temp_update)
            LogErrors("There is a problem loading the UpdateManager.exe from obx verion no " + versionNo + " : " + ex.Message)
        End Try
    End Function


    '************** Licensing Purposes ******************
    Public Sub CheckLicense(Optional ByRef _notifymsg As String = "")
        'Added by elmer
        Dim strLicType As String = ""

        Dim MyLicense As New MyLicense
        Dim MyLicenseStatus As New MyLicenseStatus

        strLicType = GetConfig(PMSDB, "LTYPE")
        strLicType = sysMpsUserPassword("DECRYPT", strLicType)

        If strLicType = "" Then
            strLicType = "NO"
        End If

        MyLicenseStatus = xValidateLicense(wrhsm5_app, strLicType, MyLicense)
        If MyLicenseStatus.ErrMsg <> "NETWORK LICENSE COMPROMISED" And MyLicenseStatus.StrLicenseMsg <> "DATETIME TAMPERED ERROR" Then
            EvaluateMyLicense(wrhsm5_app.App_DbName, wrhsm5_app.App_BackRegGPeriod, MyLicense, MyLicenseStatus)
        End If

        If MyLicenseStatus.ExpDays <= 30 Then
            Dim frm As New frmActivate(strLicType, MyLicense, MyLicenseStatus)
            frm.ShowDialog()
        ElseIf MyLicenseStatus.ExpDays <= 60 Then
            _notifymsg = _notifymsg & IIf(_notifymsg = "", "", Environment.NewLine) & "This application will expire in " & MyLicenseStatus.ExpDays.ToString & " days."
        End If
        'End elmer
    End Sub

End Module
