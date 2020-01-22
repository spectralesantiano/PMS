Imports DevExpress.XtraReports.UI
Public Class COUNTERREP
    Private report As New rptRunningHours
    Public Sub New(ByVal db As SQLDB, ByVal args As Object)
        Dim tbl As DataTable
        'report.lblDate.Text = Now.Date.ToShortDateString
        report.Vessel.Text = VESSEL
        report.IMO.Text = IMO_NUMBER
        report.Flag.Text = FLAG_DESC

        If Not LOGO Is Nothing Then report.imgLogo.Image = LOGO
        report.UnitDesc.DataBindings.Add(New XRBinding("Text", Nothing, "UnitDesc"))
        report.CurrDate.DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CurrDate", "{0:d}"))
        report.CurrReading.DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CurrReading", "{0:f0}"))

        If CURRENT_DEPARTMENT = "" Then
            tbl = CType(args, DataTable)
        Else
            Dim dr() As DataRow = CType(args, DataTable).Select("DeptCode='" & CURRENT_DEPARTMENT & "'")
            tbl = dr.CopyToDataTable
        End If

        report.DataSource = tbl

        report.ShowPreviewDialog()
    End Sub

    Private Sub Equipment_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs)
        Dim xCell As DevExpress.XtraReports.UI.XRLabel = CType(sender, DevExpress.XtraReports.UI.XRLabel)
        xCell.Text = xCell.Text.ToUpper
    End Sub
End Class
