Imports DevExpress.XtraGrid.Columns

Public Class Switchboard

    Public Overrides Sub RefreshData()
        DB.BeginReader("SELECT * FROM dbo.tblCompanyInfo")
        If DB.Read Then
            lblCompany.Text = DB.ReaderItem("Name", "").ToString.ToUpper()
        End If
        DB.CloseReader()
        lblVersion.Text = VERSION_NUMBER
        lblVersionDate.Text = VERSION_DATE.ToShortDateString
        lblhardware.Text = HDD_ID
        lblComputer.Text = Environment.MachineName
    End Sub

    'Disable prompting the user.
    Public Overrides Sub CheckIFDataUpdated()

    End Sub


End Class
