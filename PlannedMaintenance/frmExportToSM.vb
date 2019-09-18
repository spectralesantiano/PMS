Public Class frmExportToSM
    Public bExported As Boolean = False

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
        If txtExportDir.EditValue = "" Then
            MsgBox("Please specify where you want to save export files.", vbCritical, GetAppName)
        ElseIf deFrom.EditValue Is Nothing Or deTo.EditValue Is Nothing Then
            MsgBox("Please specify the export period.", vbCritical, GetAppName)
        Else
            bExported = True
            Me.Close()
        End If
    End Sub

    Private Sub deFrom_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles deFrom.EditValueChanged
        deTo.Properties.MinValue = deFrom.EditValue
    End Sub

    Private Sub deTo_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles deTo.EditValueChanged
        deFrom.Properties.MaxValue = deTo.EditValue
    End Sub
    
End Class