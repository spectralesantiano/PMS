Imports DevExpress.XtraReports.UI
Public Class NCREP
    Private report As New rptNonConform
    Private reportCorrectiveMeasure As New rptNonConform_sub
    Public Sub New(ByVal db As SQLDB, ByVal args As String)
        report.lblDate.Text = Now.Date.ToShortDateString
        report.Vessel.Text = VESSEL
        report.IMO.Text = IMO_NUMBER
        report.Flag.Text = FLAG_DESC
        report.db = db
        If Not LOGO Is Nothing Then report.imgLogo.Image = LOGO
        report.Unit.DataBindings.Add(New XRBinding("Text", Nothing, "Unit"))
        report.NCNo.DataBindings.Add(New XRBinding("Text", Nothing, "NCNo"))
        report.Description.DataBindings.Add(New XRBinding("Text", Nothing, "Description"))
        report.ImmediateAction.DataBindings.Add(New XRBinding("Text", Nothing, "ImmediateAction"))
        report.Cause.DataBindings.Add(New XRBinding("Text", Nothing, "Cause"))
        report.Objective.DataBindings.Add(New XRBinding("Text", Nothing, "Objective"))
        report.ReportedTo.DataBindings.Add(New XRBinding("Text", Nothing, "ReportedTo"))
        report.DiscoveredBy.DataBindings.Add(New XRBinding("Text", Nothing, "DiscoveredBy"))
        report.WorkDate.DataBindings.Add(New XRBinding("Text", Nothing, "WorkDate", "{0:d}"))
        report.WorkCounter.DataBindings.Add(New XRBinding("Text", Nothing, "WorkCounter"))
        report.Status.DataBindings.Add(New XRBinding("Text", Nothing, "Status"))
        report.DateVerified.DataBindings.Add(New XRBinding("Text", Nothing, "DateVerified"))
        report.VerifiedBy.DataBindings.Add(New XRBinding("Text", Nothing, "VerifiedBy"))
        report.DataSource = db.CreateTable("SELECT * FROM dbo.NCLIST WHERE CHARINDEX('|' + [NCID] + '|','" & args & "') > 0")

        reportCorrectiveMeasure.Description.DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Description"))
        reportCorrectiveMeasure.RankDesc.DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "RankDesc"))
        reportCorrectiveMeasure.DoneDate.DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DoneDate", "{0:d}"))
        reportCorrectiveMeasure.DueDate.DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DueDate", "{0:d}"))
        Dim groupField As New DevExpress.XtraReports.UI.GroupField("NCNo")
        report.GroupHeader.GroupFields.Add(groupField)
        report.subNCCorrective.ReportSource = reportCorrectiveMeasure

        report.ShowPreviewDialog()
    End Sub

End Class
