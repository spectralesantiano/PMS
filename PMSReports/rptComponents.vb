Public Class rptComponents
    Public db As SQLDB, ctable As DataTable

    Private Sub subMaintenance_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles subMaintenance.BeforePrint
        subMaintenance.ReportSource.DataSource = ctable
    End Sub

    Private Sub Detail_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Detail.BeforePrint
        ctable = db.CreateTable("SELECT [WorkDescription],[Interval],[RankDesc] FROM [dbo].[COMPONENT_MAINTENANCELIST] WHERE UnitCode='" & GetCurrentColumnValue("UnitCode") & "'")
        lblMaintenance.Visible = ctable.Rows.Count > 0
    End Sub
End Class