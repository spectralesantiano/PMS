Public Class rptWorkRecords_sub

    Private Sub Maintenance_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Maintenance.BeforePrint
        Dim xCell As DevExpress.XtraReports.UI.XRLabel = CType(sender, DevExpress.XtraReports.UI.XRLabel)
        If xCell.Text.Length > 0 Then Maintenance.Text = xCell.Text.Remove(0, 1)
    End Sub
End Class