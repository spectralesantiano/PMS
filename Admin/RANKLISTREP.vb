Public Class RANKLISTREP
    Private report As New rptRank
    Public Sub New(ByVal db As SQLDB, ByVal args As String)
        report.lblDate.Text = Now.Date.ToShortDateString
        report.RankDesc.DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "RankDesc"))
        report.Abbrv.DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Abbrv"))
        report.Department.DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Department"))
        report.Type.DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Type"))
        report.DataSource = db.CreateTable("SELECT * FROM dbo.RANKLIST ORDER BY SortCode")
        report.ShowPreviewDialog()
    End Sub
End Class
