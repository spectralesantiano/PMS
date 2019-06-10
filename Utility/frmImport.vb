Public Class frmImport
    Public bSaved As Boolean = False

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        bSaved = True
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub View_RowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle ', mView.RowCellStyle
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If view.IsRowSelected(e.RowHandle) Then
            e.Appearance.BackColor = SEL_COLOR
        End If
    End Sub

    Private Sub cmdSelectAll_Click(sender As System.Object, e As System.EventArgs) Handles cmdSelectAll.Click
        SelectAll(True)
    End Sub

    Private Sub cmdDeselect_Click(sender As System.Object, e As System.EventArgs) Handles cmdDeselect.Click
        SelectAll(False)
    End Sub

    Sub SelectAll(bSelect As Boolean)
        Dim i As Integer
        For i = 0 To MainView.RowCount - 1
            MainView.SetRowCellValue(i, "Selected", bSelect)
        Next
    End Sub
End Class