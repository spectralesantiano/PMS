Imports DevExpress.XtraReports.UI
Public Class DELIVERCON
    Private report As New rptDeliverCon
    Public Sub New(ByVal db As SQLDB, ByVal args As String)
        Dim strTemp() As String = args.Split("|"c)
        report.lblDate.Text = Now.Date.ToShortDateString
        report.Vessel.Text = VESSEL
        report.IMO.Text = IMO_NUMBER
        report.Flag.Text = FLAG_DESC
        report.Port.Text = strTemp(1)
        If Not LOGO Is Nothing Then report.imgLogo.Image = LOGO
        report.DateOrdered.DataBindings.Add(New XRBinding("Text", Nothing, "PurchaseDate", "{0:d}"))
        report.Part.DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Part"))
        report.Number.DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Number"))
        report.Vendor.DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Vendor"))
        report.UnitPrice.DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Price"))
        report.DateReceived.DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DateReceived", "{0:d}"))
        report.ReceivedQuantity.DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ReceivedQuantity"))
        report.DataSource = db.CreateTable("SELECT * FROM PARTPURCHASELIST WHERE CHARINDEX('|' + [PartPurchaseCode] + '|','|" & strTemp(0) & "|') > 0")
        report.ShowPreviewDialog()
    End Sub


End Class
