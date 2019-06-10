Imports DevExpress.XtraReports.UI
Public Class DUEWORK
    Private report As New rptDueWork

    Public Sub New(ByVal db As SQLDB, ByVal args As Object)
        report.lblDate.Text = Now.Date.ToShortDateString
        report.Vessel.Text = VESSEL
        report.IMO.Text = IMO_NUMBER
        report.Flag.Text = FLAG_DESC
        If Not LOGO Is Nothing Then report.imgLogo.Image = LOGO
        report.GroupID.DataBindings.Add(New XRBinding("Text", Nothing, "GroupID"))
        report.UnitDesc.DataBindings.Add(New XRBinding("Text", Nothing, "UnitDesc"))
        report.Abbrv.DataBindings.Add(New XRBinding("Text", Nothing, "Abbrv"))
        report.Maintenance.DataBindings.Add(New XRBinding("Text", Nothing, "Maintenance"))
        report.PlannedDate.DataBindings.Add(New XRBinding("Text", Nothing, "PlannedDate", "{0:d}"))
        report.DueDate.DataBindings.Add(New XRBinding("Text", Nothing, "DueDate", "{0:d}"))
        report.DataSource = args
        Dim groupField As New DevExpress.XtraReports.UI.GroupField("GroupID")
        report.GroupHeader.GroupFields.Add(groupField)
        report.ShowPreviewDialog()
    End Sub

End Class
