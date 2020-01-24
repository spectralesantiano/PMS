Public Class rptChecklist
    Public db As SQLDB

    Private Sub subPlan_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles subMaintenance.BeforePrint
        Dim ctable As DataTable = db.CreateTable("SELECT * FROM [dbo].[MAINTENANCECHECKLIST] WHERE RankCode='" & GetCurrentColumnValue("RankCode") & "'")
        subMaintenance.ReportSource.DataSource = ctable
    End Sub
End Class