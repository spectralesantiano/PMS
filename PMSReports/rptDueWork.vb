Public Class rptDueWork
    Dim bFirstPage As Boolean = True

    Private Sub PageHeader_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PageHeader.BeforePrint
        e.Cancel = Not bFirstPage
        bFirstPage = False
    End Sub
End Class