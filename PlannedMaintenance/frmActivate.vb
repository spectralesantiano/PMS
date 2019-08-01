Imports System.Runtime.InteropServices

Public Class frmActivate

    Dim strLictype As String = Nothing
    Dim MyLicense As New MyLicense
    Dim MyLicenseStatus As New MyLicenseStatus

    Public Sub New(Optional ByVal xStrLicenseType As String = Nothing, Optional ByVal xMylicense As MyLicense = Nothing, Optional ByVal xMyLicenseStatus As MyLicenseStatus = Nothing)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If xStrLicenseType = Nothing Then
        Else
            strLictype = xStrLicenseType
            MyLicense = xMylicense
            MyLicenseStatus = xMyLicenseStatus
        End If

    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        If cmdOk.Text = "Close" Then
            Process.GetCurrentProcess.Kill()
        Else
            Me.Close()
        End If
        'Me.Close()
    End Sub

    Private Sub frmActivate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ''Added by Elmer
        Dim bSuccess As Boolean = True

        If strLictype = Nothing Then
            strLictype = GetConfig(PMSDB, "LTYPE")
            strLictype = sysMpsUserPassword("DECRYPT", strLictype)

            If strLictype = "" Then
                strLictype = "NO"
            End If

            MyLicenseStatus = xValidateLicense(pms_app, strLictype, MyLicense)
            If MyLicenseStatus.ErrMsg <> "NETWORK LICENSE COMPROMISED" And MyLicenseStatus.StrLicenseMsg <> "DATETIME TAMPERED ERROR" Then
                EvaluateMyLicense(pms_app.App_DbName, pms_app.App_BackRegGPeriod, MyLicense, MyLicenseStatus)
            End If

        End If

        Me.GroupControl1.Text = "License Information - " & strLictype & " LICENSE"


        If MyLicenseStatus.StrLicenseMsg = "DATETIME TAMPERED ERROR" Then
            'expdays is = to num of runs
            If MyLicenseStatus.ExpDays <= 0 Then
                Me.captionLabel.Text = "Your license has been locked. Please contact WRH-SM 5 Support"
                Me.cmdOk.Text = "Close"
            Else
                Me.captionLabel.Text = " You only have " & MyLicenseStatus.ExpDays & " runs left. Changes on Computer Time/Date setting was detected"
            End If
        Else
            If MyLicenseStatus.ExpDays <= 60 Then
                If MyLicenseStatus.ExpDays <= 0 Then
                    Me.captionLabel.Text = IIf(MyLicenseStatus.StrLicenseMsg = "", " Your license has expired.", MyLicenseStatus.StrLicenseMsg)
                    Me.cmdOk.Text = "Close"
                Else
                    Me.captionLabel.Text = MyLicenseStatus.StrLicenseMsg & " You only have " & MyLicenseStatus.ExpDays & " days left. Please apply for a new License to continue using this application"
                End If
            Else
                Me.captionLabel.Text = "You still have " & MyLicenseStatus.ExpDays & " days using this application."
            End If
        End If


        'create log
        If MyLicenseStatus.StrLicenseMsg <> "" Then
            Log_Append(pms_app, MyLicenseStatus.StrLicenseMsg.PadRight(25) & MyLicenseStatus.ErrMsg, , , True)
        ElseIf MyLicenseStatus.ExpDays = 0 Then
            Log_Append(pms_app, "License has expired.".PadRight(25) & MyLicenseStatus.ErrMsg, , , True)
        End If

        'Set button access
        If strLictype = "SINGLE" Or strLictype = "TRIAL" Then
            cmdOpentroubleshooter.Enabled = True
        Else
            cmdOpentroubleshooter.Enabled = False
        End If

        If strLictype = "NETWORK" Then
            cmdBrowse.Enabled = False
        Else
            cmdBrowse.Enabled = True
        End If

        If SQL_SERVER = "." Then
            lblServerName.Text = "LOCALHOST"
        Else
            lblServerName.Text = SQL_SERVER
        End If
        'End Elmer


    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim mdCompInfo As New mdComputerInfo

        Dim odMain As New System.Windows.Forms.SaveFileDialog
        odMain.Filter = "Text Documents (*.txt)|*.txt"
        odMain.FileName = "HardwareID"
        If odMain.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Using sw As System.IO.StreamWriter = System.IO.File.CreateText(odMain.FileName)
                sw.WriteLine(mdCompInfo.GetHardwareID)
            End Using
            MsgBox("Text file created in: " & odMain.FileName, MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub cmdBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowse.Click
        If Not isElevated() Then
            MsgBox("You need to run SM as an Administrator before loading license file.", MsgBoxStyle.Exclamation, GetAppName)
            Exit Sub
        End If

        Dim cApp As New Working_App
        Try
            cApp = pms_app

            Dim back_reg_gp As String = cApp.App_BackRegGPeriod

            Dim lst As New List(Of String)
            Dim x As Integer = 0
            Dim bSuccess As Boolean = True
            Dim cls As New mdComputerInfo
            Dim odMain As New System.Windows.Forms.OpenFileDialog
            odMain.Filter = "License Key File (*.license)|*.license"

            Dim dirName As String = "C:\Program Files\Common Files\"

            If odMain.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

                If Not My.Computer.FileSystem.DirectoryExists(dirName) Then
                    My.Computer.FileSystem.CreateDirectory(dirName)
                End If

                Dim browsedLicense As New MyLicense
                Dim ErrMsg As String = ""

                bSuccess = xReadLicenseFile(odMain.FileName, browsedLicense, False, ErrMsg)

                If bSuccess Then

                    'check AppName 
                    Dim LAppName As String = sysMpsUserPassword("DECRYPT", browsedLicense.LAppName)
                    If Trim(UCase(LAppName)) <> Trim(UCase("WRH-SM5")) Then
                        AnErrorOccured(cApp, "Invalid License File." & vbNewLine & vbNewLine & "This license is not for " & GetAppName() & " Application.", True)
                        Exit Sub
                    End If

                    'check if same Hardware ID
                    Dim curr_HID As String = cls.GetHardwareID
                    Dim lic_HID As String = sysMpsUserPassword("DECRYPT", browsedLicense.LHID)

                    If Not (curr_HID = lic_HID) Then
                        AnErrorOccured(cApp, "Invalid License File." & vbNewLine & vbNewLine & "Hardware id mismatch!", True)
                        Exit Sub
                    End If

                    'check Date Generated license if valid
                    Dim DLGen As String = sysMpsUserPassword("DECRYPT", browsedLicense.LGen)
                    Dim DateGen As Integer
                    Try
                        DateGen = CInt(DLGen)
                    Catch ex As Exception
                        AnErrorOccured(cApp, "Cannot load license!. Please check date/time settings.", True)
                        Exit Sub
                    End Try

                    Dim currdate As Integer = getServerDate()

                    If DateGen > currdate Then
                        'invalid datetime settings
                        AnErrorOccured(cApp, "Cannot load license!. Please check date/time settings.", True)
                        Exit Sub
                    End If

                    'Dim appIMO As String = SMDB.DLookUp("IMONo", "sas_tbl.dbo.tblAdmVsl", "", "")
                    'Dim licenseIMO As String = sysMpsUserPassword("DECRYPT", browsedLicense.LImo)

                    'If Not (appIMO = licenseIMO) Then
                    '    AnErrorOccured(cApp, "Invalid License File." & vbNewLine & vbNewLine & "IMO Number mismatch!", True)
                    '    Exit Sub
                    'End If

                    Dim strLicenseType As String = sysMpsUserPassword("DECRYPT", browsedLicense.LType)

                    If strLicenseType = "NETWORK" Then
                        AnErrorOccured(cApp, "Import Cancel. You are trying to import NETWORK LINCENSE. Please import it using the Spectral License Service App.", True, True)
                        Exit Sub
                    End If

                    Dim strBuilder As New System.Text.StringBuilder
                    strBuilder.Append("Load License?")
                    strBuilder.AppendLine()
                    strBuilder.AppendLine()
                    strBuilder.AppendLine("LICENSE TYPE : " & strLicenseType)
                    strBuilder.AppendLine("DATE EXPIRY : " & sysMpsUserPassword("DECRYPT", browsedLicense.LExp))

                    If MsgBox(strBuilder.ToString, 36) = MsgBoxResult.Yes Then
                        Dim msg As String = ""
                        bSuccess = xSaveLicenseToDB(cApp.App_DbName, browsedLicense, back_reg_gp, msg)
                        If Not bSuccess Then
                            If msg <> "" Then
                                AnErrorOccured(cApp, msg, True)
                                Exit Sub
                            End If
                        End If
                    Else
                        AnErrorOccured(cApp, "Activation cancelled!", True)
                        Exit Sub
                    End If

                Else
                    AnErrorOccured(cApp, ErrMsg, True)
                    Exit Sub
                End If

                Dim strbackupLicense As String = ""
                If cApp.App_Name = "WRHSM5" Then
                    strbackupLicense = dirName & "obj_Wbak\STI_WSM5Lic_" & getServerDateTime() & ".lic"
                End If

                If My.Computer.FileSystem.FileExists(cApp.App_LicensePath) Then
                    My.Computer.FileSystem.CopyFile(cApp.App_LicensePath, strbackupLicense, True)
                End If

                'copy License File
                My.Computer.FileSystem.CopyFile(odMain.FileName, cApp.App_LicensePath, True)

                MsgBox("The license file has been successfuly loaded!")

                'create backup to registry
                bSuccess = BackupLicenseReg("SET", cApp.App_Name, "sys_wrhsm5", browsedLicense)


                Me.Close()
            End If
        Catch ex As Exception
            AnErrorOccured(cApp, ex.Message, True)
        End Try

    End Sub

    Private Sub frmActivate_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.cmdOk.Text = "Close" Then
            'avoid inevitable crash
            Process.GetCurrentProcess.Kill()
        End If
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Must be 64 bits, 8 bytes.
        Dim sSecretKey As String

        ' Get the key for the file to encrypt.
        ' You can distribute this key to the user who will decrypt the file.
        sSecretKey = "?`D)??61"

        ' For additional security, pin the key.
        Dim gch As GCHandle = GCHandle.Alloc(sSecretKey, GCHandleType.Pinned)


        '' Encrypt the file.        
        EncryptFile("C:\Elmer.txt", _
                        "C:\ElmerEn.txt", _
                        sSecretKey)

        ' Decrypt the file.
        DecryptFile("C:\ElmerEn.txt", _
                    "C:\ElmerDe.txt", _
                    sSecretKey)

        ' Remove the key from memory. 
        ZeroMemory(gch.AddrOfPinnedObject(), sSecretKey.Length * 2)
        gch.Free()
    End Sub

    Private Sub cmdOpentroubleshooter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpentroubleshooter.Click
        Dim frm As New frmLicenseTroubleshooter(pms_app)
        frm.ShowDialog()

    End Sub

    Private Sub cmdServerConfig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdServerConfig.Click
        Dim tempWRHSM_CON As String = ""
        tempWRHSM_CON = SQL_SERVER

        Dim frm As New frmConnect
        frm.ShowDialog()
        If (tempWRHSM_CON <> SQL_SERVER) And (SQL_SERVER <> "") Then
            MsgBox("Successfully change the server!" & vbNewLine & vbNewLine & "Please restart WRH-SM5 app.", MsgBoxStyle.Information, GetAppName)
            End
        End If
    End Sub
End Class