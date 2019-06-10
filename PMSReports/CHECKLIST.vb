Imports DevExpress.XtraReports.UI
Public Class CHECKLIST
    Private report As New rptChecklist
    Private reportSub As New rptChecklist_sub
    Public Sub New(ByVal db As SQLDB, ByVal args As String)
        report.lblDate.Text = Now.Date.ToShortDateString
        report.Vessel.Text = VESSEL
        report.IMO.Text = IMO_NUMBER
        report.Flag.Text = FLAG_DESC
        report.db = db
        If Not LOGO Is Nothing Then report.imgLogo.Image = LOGO
        report.RankDesc.DataBindings.Add(New XRBinding("Text", Nothing, "RankDesc"))
        AddHandler report.RankDesc.BeforePrint, AddressOf Equipment_BeforePrint
        
        report.DataSource = db.CreateTable("SELECT RankCode, RankDesc FROM dbo.RANKLIST WHERE CHARINDEX('|' + [RankCode] + '|','" & args & "') > 0 ORDER BY SortCode")

        reportSub.Interval.DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Interval"))
        reportSub.Equipment.DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Equipment"))
        reportSub.WorkDescription.DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "WorkDescription"))
        Dim groupField As New DevExpress.XtraReports.UI.GroupField("RankCode")
        Dim groupFieldSub As New DevExpress.XtraReports.UI.GroupField("Interval")
        report.GroupHeader.GroupFields.Add(groupField)
        reportSub.GroupHeader.GroupFields.Add(groupFieldSub)
        report.subMaintenance.ReportSource = reportSub

        report.ShowPreviewDialog()
    End Sub

    Private Sub Equipment_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs)
        Dim xCell As DevExpress.XtraReports.UI.XRLabel = CType(sender, DevExpress.XtraReports.UI.XRLabel)
        xCell.Text = xCell.Text.ToUpper
    End Sub
End Class
