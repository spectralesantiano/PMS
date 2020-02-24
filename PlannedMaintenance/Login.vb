Public Class Login

    Public is_loggedon As Boolean = False

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Dim crow As Object = (cboUsers.Properties.GetDataSourceRowByKeyValue(cboUsers.EditValue))
        If Me.cboUsers.EditValue Is Nothing Then
            MsgBox("Please enter your User Name.", MsgBoxStyle.Critical)
        ElseIf sysMpsUserPassword("decrypt", crow("Password")) <> Me.txtPassword.Text Then
            MsgBox("Incorrect password.", MsgBoxStyle.Critical)
        Else
            USER_NAME = crow("UserName")
            USER_ID = crow("UserID")
            GROUP_ID = IfNull(crow("GroupID"), 0)
            USER_PASSWORD = Me.txtPassword.Text
            USER_REAL = crow("LNAME") & ", " & crow("FNAME") & " " & crow("MNAME")
            is_loggedon = True
            Me.Close()
        End If
    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cboUsers.Properties.DataSource = PMSDB.CreateTable("SELECT * FROM dbo.LOGIN")
    End Sub

End Class