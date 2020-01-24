Public Class frmImageViewer
    Dim img As Drawing.Image
    Private Sub MainView_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles MainView.FocusedRowChanged
        If MainView.FocusedRowHandle >= 0 Then
            img = StringToImage(MainView.GetFocusedRowCellValue("Doc"))
            imgLogo.BackgroundImage = ResizeImage(img, imgLogo.Width, imgLogo.Height)
        End If
    End Sub

    Private Sub MainViewnRowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
        If e.RowHandle = MainView.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        End If
    End Sub

    Private Sub SplitContainerControl1_SplitterMoved(sender As Object, e As System.EventArgs) Handles SplitContainerControl1.SplitterMoved
        imgLogo.BackgroundImage = ResizeImage(img, imgLogo.Width, imgLogo.Height)
    End Sub
End Class