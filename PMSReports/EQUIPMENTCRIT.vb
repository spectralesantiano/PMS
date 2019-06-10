Imports DevExpress.XtraReports.UI
Public Class EQUIPMENTCRIT
    Private report As New rptEquipmentList
    Public Sub New(ByVal db As SQLDB, ByVal args As String)
        report.lblDate.Text = Now.Date.ToShortDateString
        report.Vessel.Text = VESSEL
        report.IMO.Text = IMO_NUMBER
        report.Flag.Text = FLAG_DESC
        If Not LOGO Is Nothing Then report.imgLogo.Image = LOGO
        report.Title.Text = "EQUIPMENT - CRITICAL"
        report.MainField.DataBindings.Add(New XRBinding("Text", Nothing, "Category"))
        report.Equipment.DataBindings.Add(New XRBinding("Text", Nothing, "Equipment"))
        report.Critical.DataBindings.Add(New XRBinding("Text", Nothing, "Critical"))
        report.Field1.DataBindings.Add(New XRBinding("Text", Nothing, "Department"))
        report.Field2.DataBindings.Add(New XRBinding("Text", Nothing, "RankDesc"))
        report.HField1.Text = "Department"
        report.HField2.Text = "Responsible"
        report.DataSource = db.CreateTable("SELECT [Equipment],[Critical],[Department],[Category],[RankDesc] FROM [dbo].[EQUIPMENT_GROUP] WHERE Critical='Yes'")
        AddHandler report.MainField.BeforePrint, AddressOf MainField_BeforePrint
        report.ShowPreviewDialog()
    End Sub

    Private Sub MainField_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs)
        Dim xCell As DevExpress.XtraReports.UI.XRLabel = CType(sender, DevExpress.XtraReports.UI.XRLabel)
        xCell.Text = "EQUIPMENTS FOR " & xCell.Text.ToUpper & " CATEGORY."
    End Sub
End Class
