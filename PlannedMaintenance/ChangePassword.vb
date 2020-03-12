Public Class ChangePassword
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String '= clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName) 'neil

    Public is_saved As Boolean = False

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        If Me.txtOldPassword.Text <> USER_PASSWORD Then
            MsgBox("The current password you entered is incorrect.", MsgBoxStyle.Critical)
        ElseIf Me.txtNewPass.Text = DEFAULT_PASSWORD Then
            MsgBox("The new password should not be the same as the default password.", MsgBoxStyle.Critical)
        ElseIf Me.txtNewPass.Text = Me.txtOldPassword.Text Then
            MsgBox("The new password should not be the same as the old password.", MsgBoxStyle.Critical)
        ElseIf Me.txtNewPass.Text <> Me.txtConfirmPassword.Text Then
            MsgBox("The new and confirm password is not the same.", MsgBoxStyle.Critical)
        ElseIf Me.txtNewPass.Text.Length < 4 Then
            MsgBox("The new password should at least 4 characters.", MsgBoxStyle.Critical)
        Else
            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_REAL, "", 10, System.Environment.MachineName, "Change Password", Me.Text) 'neil

            PMSDB.RunSql("Update dbo.tblSec_Users set [Password]='" & sysMpsUserPassword("encrypt", txtNewPass.Text) & "', LastUpdatedBy='" & LastUpdatedBy & "' WHERE [User ID]=" & USER_ID)
            USER_PASSWORD = txtNewPass.Text
            is_saved = True
            Me.Close()
        End If
    End Sub
End Class