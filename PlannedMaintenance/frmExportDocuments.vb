Public Class frmExportDocuments
    Public bExported As Boolean = False
    Public strDocs As String
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub Browse()
        Dim odMain As New System.Windows.Forms.FolderBrowserDialog
        If odMain.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            txtExportDir.EditValue = odMain.SelectedPath
        End If
    End Sub
    Private Sub txtExportDir_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtExportDir.ButtonClick
        Browse()
    End Sub

    Private Sub cmdExport_Click(sender As System.Object, e As System.EventArgs) Handles cmdExport.Click
        Dim cnt As Integer
        strDocs = "|"
        For cnt = 0 To MainView.RowCount - 1
            If MainView.GetRowCellValue(cnt, "Selected") Then
                strDocs = strDocs & MainView.GetRowCellValue(cnt, "DocID") & "|"
            End If
        Next
        If txtExportDir.EditValue = "" Then
            MsgBox("Please specify where you want to save export files.", vbCritical, GetAppName)
        ElseIf strDocs.Length = 1 Then
            MsgBox("Please select at least one document to export.", MsgBoxStyle.Information, GetAppName)
        Else
            bExported = True
            Me.Close()
        End If
    End Sub

End Class