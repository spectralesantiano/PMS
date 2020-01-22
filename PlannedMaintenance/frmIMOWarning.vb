Public Class frmIMOWarning
    Public is_confirmed As Boolean = False
    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        is_confirmed = True
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub frmIMOWarning_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        lblInfo.Text = "The IMO number is an important feature of " & APP_SHORT_NAME & "'s functionality and it's very important that the vessel's correct IMO number is added in " & APP_SHORT_NAME & "."
    End Sub
End Class