Public Class CompanyInfo
    Public bSaved As Boolean = False
    Private Sub cmdBrowse_Click(sender As System.Object, e As System.EventArgs) Handles cmdBrowse.Click
        Dim odMain As New System.Windows.Forms.OpenFileDialog
        odMain.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png"
        If odMain.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            imgLogo.BackgroundImage = New System.Drawing.Bitmap(odMain.FileName)
        End If
    End Sub

    Private Sub cmdClear_Click(sender As System.Object, e As System.EventArgs) Handles cmdClear.Click
        imgLogo.BackgroundImage = Nothing
    End Sub

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
    
    Private Sub cmdOk_Click(sender As System.Object, e As System.EventArgs) Handles cmdOk.Click
        If txtName.EditValue = "" Then
            MsgBox("Please fill in the name of the Company.", MsgBoxStyle.Critical)
        Else
            bSaved = True
            Me.Close()
        End If
    End Sub
End Class