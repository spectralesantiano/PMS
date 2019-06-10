Public Class frmProgress
    Public Event Canceled()
    Public Event Hidden()

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        RaiseEvent Canceled()
    End Sub

    Private Sub cmdHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHide.Click
        RaiseEvent Hidden()
    End Sub
End Class