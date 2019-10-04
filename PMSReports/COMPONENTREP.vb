Imports DevExpress.XtraReports.UI
Public Class COMPONENTREP
    Private report As New rptComponents, subreport As New rptComponent_maintenance
    Public Sub New(ByVal db As SQLDB, ByVal args As String)
        report.lblDate.Text = Now.Date.ToShortDateString
        report.Vessel.Text = VESSEL
        report.IMO.Text = IMO_NUMBER
        report.Flag.Text = FLAG_DESC
        report.db = db
        If Not LOGO Is Nothing Then report.imgLogo.Image = LOGO
        report.Department.DataBindings.Add(New XRBinding("Text", Nothing, "Department"))
        report.Category.DataBindings.Add(New XRBinding("Text", Nothing, "Category"))
        report.Critical.DataBindings.Add(New XRBinding("Text", Nothing, "Critical"))
        report.RefNo.DataBindings.Add(New XRBinding("Text", Nothing, "RefNo"))
        report.SerialNumber.DataBindings.Add(New XRBinding("Text", Nothing, "SerialNumber"))
        report.Model.DataBindings.Add(New XRBinding("Text", Nothing, "Model"))
        report.Type.DataBindings.Add(New XRBinding("Text", Nothing, "Type"))
        report.Component.DataBindings.Add(New XRBinding("Text", Nothing, "UnitDesc"))
        report.Loc.DataBindings.Add(New XRBinding("Text", Nothing, "Loc"))
        report.Category.DataBindings.Add(New XRBinding("Text", Nothing, "Category"))
        report.Department.DataBindings.Add(New XRBinding("Text", Nothing, "Department"))
        report.DataSource = db.CreateTable("EXEC [dbo].[COMPONENTREP] @strUnitCode ='" & args & "'")
        Dim groupField As New DevExpress.XtraReports.UI.GroupField("GroupCode")
        report.GroupHeader.GroupFields.Add(groupField)
        subreport.WorkDescription.DataBindings.Add(New XRBinding("Text", Nothing, "WorkDescription"))
        subreport.Interval.DataBindings.Add(New XRBinding("Text", Nothing, "Interval"))
        subreport.RankDesc.DataBindings.Add(New XRBinding("Text", Nothing, "RankDesc"))
        report.subMaintenance.ReportSource = subreport
        report.ShowPreviewDialog()
    End Sub

End Class
