Public Class rptWorkRecords
    Public db As SQLDB, ctable As DataTable

    Private Sub subMaintenance_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles subMaintenance.BeforePrint
        subMaintenance.ReportSource.DataSource = db.CreateTable("EXEC dbo.[MAINTENANCEWORK] @strUnitCode='" & GetCurrentColumnValue("UnitCode") & "',@bFlatView =0,@bCritical=0")
    End Sub

    Private Sub Detail_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Detail.BeforePrint
        'ctable = db.CreateTable("SELECT [WorkDescription],[Interval],[RankDesc] FROM [dbo].[COMPONENT_MAINTENANCELIST] WHERE ComponentCode='" & GetCurrentColumnValue("ComponentCode") & "'")
    End Sub
End Class