Public Class frmDefaultDate
    Public IS_SAVED As Boolean = False

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtDate}) Then
            IS_SAVED = True
            Me.Close()
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
    

End Class