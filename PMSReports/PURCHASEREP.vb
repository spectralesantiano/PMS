Imports DevExpress.XtraReports.UI
Public Class PURCHASEREP
    Private report As New rptPurchase
    Public Sub New(ByVal db As SQLDB, ByVal args As String)
        report.lblDate.Text = Now.Date.ToShortDateString
        report.Vessel.Text = VESSEL
        report.IMO.Text = IMO_NUMBER
        report.Flag.Text = FLAG_DESC

        If Not LOGO Is Nothing Then report.imgLogo.Image = LOGO
        report.DateOrdered.DataBindings.Add(New XRBinding("Text", Nothing, "DateOrdered", "{0:d}"))
        report.Status.DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Status"))
        report.Seller.DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Seller"))
        report.Part.DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Part"))
        report.Number.DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Number"))
        report.Storage.DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Storage"))
        report.Vendor.DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Vendor"))
        report.Quantity.DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Quantity"))
        report.DateReceived.DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DateReceived", "{0:d}"))
        report.ReceivedQuantity.DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ReceivedQuantity"))
        report.DataSource = db.CreateTable("SELECT * FROM PARTPURCHASELIST WHERE CHARINDEX('|' + [PartPurchaseCode] + '|','" & args & "') > 0")
        report.ShowPreviewDialog()
    End Sub


End Class
