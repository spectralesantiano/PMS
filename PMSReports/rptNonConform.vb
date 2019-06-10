Public Class rptNonConform
    Public db As SQLDB

    Private Sub subNCCorrective_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles subNCCorrective.BeforePrint
        Dim ctable As DataTable = db.CreateTable("SELECT * FROM [dbo].[CORRECTIVEMEASURELIST] WHERE NCID='" & GetCurrentColumnValue("NCID") & "'")
        subNCCorrective.ReportSource.DataSource = ctable
    End Sub
End Class