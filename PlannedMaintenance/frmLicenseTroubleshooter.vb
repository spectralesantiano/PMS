Public Class frmLicenseTroubleshooter

    Public strAction As String = ""

    Dim _app As New Working_App

    Sub New(ByVal _xapp As Working_App)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        _app = _xapp
    End Sub

    Private Sub frmLicenseTroubleshooter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboAction.Properties.DataSource = Populate_cboAction()
    End Sub

    Private Function Populate_cboAction() As DataTable
        Dim dt As New DataTable, ccolumn As DataColumn
        ccolumn = New DataColumn
        ccolumn.ColumnName = "ActionID"
        ccolumn.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "ActionDesc"
        ccolumn.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(ccolumn)

        Dim crow() As Object = {"getLicenseInfo", "Generate License Information"}
        dt.Rows.Add(crow)

        crow(0) = "restoreLicense"
        crow(1) = "Restore my license"
        dt.Rows.Add(crow)

        crow(0) = "getLicenseReport"
        crow(1) = "Generate License Report"
        dt.Rows.Add(crow)

        Return dt
    End Function

    Private Sub cmdProceed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdProceed.Click
        Dim strLogFile As String = ""
        Dim cPath As String = ""
        If cboAction.Text = "" Then
            MsgBox("Please select action in order to proceed.", MsgBoxStyle.Information, GetAppName)
        Else
            Select Case cboAction.EditValue
                Case "getLicenseInfo"
                    strLogFile = "MyLicenseStatus_" & getServerDateTime() & ".txt"
                    cPath = _app.App_LogFolder & "\" & strLogFile
                    RunLicenseStatusInfo(_app, strLogFile)
                    If MsgBox("Would you like to view log?", MsgBoxStyle.Question + vbYesNo) = vbYes Then
                        If IO.File.Exists(cPath) Then
                            Dim cLog As String = IO.File.ReadAllText(cPath)
                            ShowLog(cLog)
                        End If
                    End If
                Case "restoreLicense"
                    strLogFile = "RepairMyLicense_" & getServerDateTime() & ".txt"
                    cPath = _app.App_LogFolder & "\" & strLogFile
                    RestoreMyLicenseFile(_app, strLogFile)
                    If MsgBox("Would you like to view log?", MsgBoxStyle.Question + vbYesNo) = vbYes Then
                        If IO.File.Exists(cPath) Then
                            Dim cLog As String = IO.File.ReadAllText(cPath)
                            ShowLog(cLog)
                        End If
                    End If
                Case "getLicenseReport"
                    Dim bSuccess As Boolean = True
                    Dim strLogFileName As String = ""
                    strLogFileName = _app.App_Name & "_LogFile_" & getServerDateTime()
                    cPath = _app.App_LogFolder & "\Generated Report Logs"

                    If Not System.IO.Directory.Exists(cPath) Then
                        System.IO.Directory.CreateDirectory(cPath)
                    End If

                    Dim strInfile As String = cPath & "\LicenseLogReport.txt"
                    strLogFile = cPath & "\" & strLogFileName & ".txt"

                    bSuccess = GenerateLicenseReport(_app, strLogFile, strInfile)

                    If bSuccess Then
                        Dim odMain As New System.Windows.Forms.SaveFileDialog
                        odMain.Filter = "Log File (*.logf)|*.logf"
                        odMain.FileName = strLogFileName
                        If odMain.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                            Try
                                System.IO.File.Copy(GetFileDir(strLogFile) & GetFileNameWithoutExtension(strLogFile) & ".logf", odMain.FileName, True)
                                Log_Append(_app, "License Log File file created in: " & odMain.FileName, , , True)
                                MsgBox("License Log file created in: " & odMain.FileName, MsgBoxStyle.Information)
                            Catch ex As Exception
                                AnErrorOccured(_app, ex.Message)
                            End Try
                        End If
                    Else
                        AnErrorOccured(_app, "An error occured creating an license report.", True, True) 'this will create a log and also save to db
                    End If

            End Select

            Me.Close()
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Public Sub ShowLog(ByVal cLog As String)
        Dim frmLogViewer As New frmLog
        frmLogViewer.txtLog.Text = cLog
        frmLogViewer.ShowDialog()
    End Sub
End Class