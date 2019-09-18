Namespace My

    ' The following events are availble for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "Black"
            SetAppPath(System.Windows.Forms.Application.StartupPath)
            'DevExpress.XtraEditors.WindowsFormsSettings.DefaultMenuFont = GetDefaultFont()
            'DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = GetDefaultFont()
            Update_UpdateManagerExe() ' check if theres an update for UpdateManager.exe
            Dim scTemp As String = GetIni("SPECTRAL_CON")
            If scTemp <> "" Then
                USE_SPECTRAL_CON = CType(scTemp, Boolean)
                If Not USE_SPECTRAL_CON Then
                    Dim tcTemp As String = GetIni("TRUSTED_CON")
                    USE_TRUSTED_CON = CType(tcTemp, Boolean)
                    If Not USE_TRUSTED_CON Then
                        SQL_USER_NAME = GetIni("SQL_USER_NAME")
                        SQL_PASSWORD = GetIni("SQL_PASSWORD")
                        If SQL_PASSWORD <> "" Then
                            SQL_PASSWORD = sysMpsUserPassword("DECRYPT", SQL_PASSWORD)
                        End If
                    End If
                End If
            End If
            SQL_SERVER = GetIni("SERVER")
            If SQL_SERVER <> "" Then
                PMSDB = New SQLDB(GetConnectionString)
                If Not PMSDB.Connect Then
                    SQL_SERVER = ""
                End If
            End If
        End Sub

        Private Sub Update_UpdateManagerExe()

            Dim strUpdateManager As String = "UpdateManager.exe"
            Dim strUpdate_UpdateManager As String = "Update_UpdateManager.exe"

            'check if theres an update for UpdateManager.exe
            If System.IO.File.Exists(CleanDirPath(GetAppPath) & strUpdate_UpdateManager) Then
                LogUpdate(StrDup(100, "*"))
                LogUpdate("Start Update: UpdateManager.exe")
                If System.IO.File.Exists(CleanDirPath(GetAppPath) & strUpdateManager) Then
                    LogUpdate("Creating Backup : UpdateManager.exe")
                    'create a backup on UpdateManager.exe
                    Try
                        Application.DoEvents()
                        System.IO.File.Move(CleanDirPath(GetAppPath) & strUpdateManager, CleanDirPath(GetAppPath) & "UpdateManagerBackups\UpdateManager_" & Now.ToString("yyyyMMddmmss") & ".exe")
                        LogUpdate("Creating Backup : OK")
                    Catch ex As Exception
                        LogUpdate("Creating Backup : Failed (" & ex.Message & ")")
                    End Try

                End If

                LogUpdate("Performing Update : UpdateManager.exe")
                'perform update UpdateManager.exe
                Try
                    Application.DoEvents()
                    System.IO.File.Copy(CleanDirPath(GetAppPath) & strUpdate_UpdateManager, CleanDirPath(GetAppPath) & strUpdateManager, True)
                    System.IO.File.Delete(CleanDirPath(GetAppPath) & strUpdate_UpdateManager)
                    LogUpdate("Performing Update : OK")
                Catch ex As Exception
                    LogUpdate("Performing Update : Failed (" & ex.Message & ")")
                End Try
                LogUpdate(StrDup(100, "*"))
            End If

        End Sub

        Private Sub LogUpdate(ByVal strMsg As String)
            Dim strFileName As String
            If Not System.IO.Directory.Exists(GetAppPath() & "\UpdateManagerBackups") Then
                MkDir(GetAppPath() & "\UpdateManagerBackups")
            End If
            strFileName = GetAppPath() & "\UpdateManagerBackups" & "\UpdateManager_UpdateLog_" & Now.ToString("yyyyMMdd") & ".txt"
            Using sw As New System.IO.StreamWriter(strFileName, True)
                sw.WriteLine(Now.ToString("yyyy-MM-dd mm:ss") & " : " & strMsg)
            End Using
        End Sub

    End Class

End Namespace

