Public Class frmConnect

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConnect.Click
        SQL_SERVER = Me.txtServer.EditValue
        If cboAuthType.EditValue = 1 Then
            WriteIni("SPECTRAL_CON", "True")
            USE_SPECTRAL_CON = True
        Else
            WriteIni("SPECTRAL_CON", "False")
            USE_SPECTRAL_CON = False
            If cboAuthType.EditValue = 2 Then
                WriteIni("TRUSTED_CON", "True")
                USE_TRUSTED_CON = True
            Else
                USE_TRUSTED_CON = False
                WriteIni("TRUSTED_CON", "False")
                SQL_USER_NAME = txtLogin.EditValue
                WriteIni("SQL_USER_NAME", SQL_USER_NAME)
                SQL_PASSWORD = txtPassword.EditValue
                WriteIni("SQL_PASSWORD", sysMpsUserPassword("ENCRYPT", SQL_PASSWORD))
            End If
        End If
        PMSDB = New SQLDB(GetConnectionString)
        If PMSDB.Connect Then
            WriteIni("SERVER", SQL_SERVER)
            Me.Close()
        Else
            SQL_SERVER = ""
            MsgBox("Unable to connect to the specified server.", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub frmConnect_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cboAuthType.Properties.DataSource = GetAuthType()
        If USE_SPECTRAL_CON Then
            cboAuthType.EditValue = 1
        ElseIf USE_TRUSTED_CON Then
            cboAuthType.EditValue = 2
        Else
            cboAuthType.EditValue = 3
            txtLogin.EditValue = SQL_USER_NAME
            txtPassword.EditValue = SQL_PASSWORD
        End If
    End Sub

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetAuthType() As DataTable
        Dim ctable As New DataTable, ccolumn As DataColumn
        ccolumn = New DataColumn
        ccolumn.ColumnName = "AuthType"
        ccolumn.DataType = System.Type.GetType("System.Int32")
        ctable.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "AuthDesc"
        ccolumn.DataType = System.Type.GetType("System.String")
        ctable.Columns.Add(ccolumn)
        ctable.Rows.Add(New String() {1, "STI Authentication"})
        ctable.Rows.Add(New String() {2, "Windows Authentication"})
        ctable.Rows.Add(New String() {3, "SQL Server Authentication"})
        Return ctable
    End Function

    Private Sub cboAuthType_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboAuthType.EditValueChanged
        txtLogin.Enabled = (cboAuthType.EditValue = 3)
        txtPassword.Enabled = (cboAuthType.EditValue = 3)
    End Sub
End Class