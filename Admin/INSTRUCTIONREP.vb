Imports DevExpress.XtraReports.UI
Public Class INSTRUCTIONREP
    Private report As New rptInstruction
    Public Sub New(ByVal db As SQLDB, ByVal args As String)
        Dim tmp() As String = args.Split("|")
        report.lblDate.Text = Now.Date.ToShortDateString
        report.Vessel.Text = VESSEL
        report.IMO.Text = IMO_NUMBER
        report.Flag.Text = FLAG_DESC
        If Not LOGO Is Nothing Then report.imgLogo.Image = LOGO
        report.Equipment.Text = tmp(0)
        report.Work.Text = tmp(1)
        report.Interval.Text = tmp(2)
        report.RankDesc.Text = tmp(3)
        report.InsCrossRef.Text = tmp(4)
        report.InsEditor.Text = tmp(5)
        report.InsDateIssue.Text = tmp(6)
        report.InsDesc.Text = tmp(7)
        If tmp(8) <> "" Then
            report.ImgDoc.Image = StringToImage(tmp(8))
        End If
        'report.DataSource = db.CreateTable("SELECT [WorkDescription],[RankDesc],[Interval],[InsEditor],[InsDateIssue],[InsDesc],[InsCrossRef] FROM [dbo].[PLANNINGREP] WHERE MaintenanceCode='" & tmp(0) & "'")
        report.ShowPreviewDialog()
    End Sub

End Class
