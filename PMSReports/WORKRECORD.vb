Imports DevExpress.XtraReports.UI
Public Class WORKRECORD
    Private report As New rptWorkRecords, subReport As New rptWorkRecords_sub

    Public Sub New(ByVal db As SQLDB, ByVal args As String)
        report.lblDate.Text = Now.Date.ToShortDateString
        report.Vessel.Text = VESSEL
        report.IMO.Text = IMO_NUMBER
        report.Flag.Text = FLAG_DESC
        report.db = db
        If Not LOGO Is Nothing Then report.imgLogo.Image = LOGO
        report.Department.DataBindings.Add(New XRBinding("Text", Nothing, "Department"))
        report.Category.DataBindings.Add(New XRBinding("Text", Nothing, "Category"))
        report.Description.DataBindings.Add(New XRBinding("Text", Nothing, "Description"))
        report.Loc.DataBindings.Add(New XRBinding("Text", Nothing, "LocName"))
        report.DataSource = db.CreateTable("SELECT * FROM dbo.WORKRECORDS WHERE CHARINDEX('|' + [UnitCode] + '|','" & args & "') > 0")
        Dim groupField As New DevExpress.XtraReports.UI.GroupField("Description"), groupField2 As New DevExpress.XtraReports.UI.GroupField("Maintenance")
        report.GroupHeader.GroupFields.Add(groupField)
        subReport.Maintenance.DataBindings.Add(New XRBinding("Text", Nothing, "Maintenance"))
        subReport.WorkCounter.DataBindings.Add(New XRBinding("Text", Nothing, "WorkCounter"))
        subReport.WorkDate.DataBindings.Add(New XRBinding("Text", Nothing, "WorkDate", "{0:d}"))
        subReport.RankDesc.DataBindings.Add(New XRBinding("Text", Nothing, "Abbrv"))
        subReport.ExecutedBy.DataBindings.Add(New XRBinding("Text", Nothing, "ExecutedBy"))
        subReport.Remarks.DataBindings.Add(New XRBinding("Text", Nothing, "Remarks"))
        subReport.GroupHeader1.GroupFields.Add(groupField2)
        report.subMaintenance.ReportSource = Subreport
        report.ShowPreviewDialog()
    End Sub

End Class
