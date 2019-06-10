Imports DevExpress.XtraReports.UI
Public Class NCMEASUREREP
    Private report As New rptNCMeasure
    Public Sub New(ByVal db As SQLDB, ByVal args As String)
        report.lblDate.Text = Now.Date.ToShortDateString
        report.Vessel.Text = VESSEL
        report.IMO.Text = IMO_NUMBER
        report.Flag.Text = FLAG_DESC

        If Not LOGO Is Nothing Then report.imgLogo.Image = LOGO
        report.Unit.DataBindings.Add(New XRBinding("Text", Nothing, "Unit"))
        report.Description.DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Description"))
        report.RankDesc.DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "RankDesc"))
        report.DueDate.DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DueDate", "{0:d}"))
        report.DataSource = db.CreateTable("SELECT * FROM CORRECTIVEMEASUREUNITLIST WHERE DoneDate IS NULL")
        report.ShowPreviewDialog()
    End Sub


End Class
