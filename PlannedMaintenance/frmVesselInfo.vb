Public Class frmVesselInfo
    Public IS_SAVED As Boolean = False
    Dim retid As Long 'audit
    Dim clsAudit As New clsAudit 'neil
    'Private LastUpdatedBy As String '= clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName) 'neil
    Dim oldVessel As String = ""
    Dim oldFlag As String = ""
    Dim oldType As String = ""
    Dim oldEmail As String = ""

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        If Me.txtVessel.EditValue = "" Then
            MsgBox("Please fill in the name of the Vessel.", MsgBoxStyle.Critical)
            Exit Sub
        ElseIf Me.txtImo.EditValue.ToString.Length < 7 Then
            MsgBox("Please enter a valid IMO Number.", MsgBoxStyle.Critical)
            Exit Sub
        ElseIf Me.Type.EditValue Is Nothing Or Me.Type.EditValue Is System.DBNull.Value Then
            MsgBox("Please fill in the type of the Vessel.", MsgBoxStyle.Critical)
            Exit Sub
        ElseIf Me.Flag.EditValue Is Nothing Or Me.Flag.EditValue Is System.DBNull.Value Then
            MsgBox("Please fill in the flag of the Vessel.", MsgBoxStyle.Critical)
            Exit Sub
        ElseIf Me.txtEmail.EditValue = "" Then
            MsgBox("Please fill in the email address of the Vessel.", MsgBoxStyle.Critical)
            Exit Sub
        Else
            If IMO_NUMBER <> "" Then
                PMSDB.RunSql("UPDATE sas_tbl.dbo.tblAdmVsl SET Name='" & txtVessel.Text.Replace("'", "''") & "', Flag='" & Flag.EditValue & "', VslTypeCode='" & Type.EditValue & "', Email='" & txtEmail.EditValue & "' WHERE VslCode='" & IMO_NUMBER.ToString & "'")

                clsAudit.saveAuditLog("EDIT", USER_REAL, retid, System.Environment.MachineName, 10, "sas_tbl.dbo.tblAdmVsl", , , , "Vessel Info", "Vessel Information")
                clsAudit.saveAuditDetails(retid, "Name", IfNull(txtVessel.Text.Replace("'", "''"), ""), oldVessel)
                clsAudit.saveAuditDetails(retid, "Flag", IfNull(Flag.EditValue, ""), oldFlag)
                clsAudit.saveAuditDetails(retid, "VslTypeCode", IfNull(Type.EditValue, ""), oldType)
                clsAudit.saveAuditDetails(retid, "Email", IfNull(txtEmail.EditValue, ""), oldEmail)

            ElseIf ISIMOConfirmed() Then
                PMSDB.RunSql("INSERT INTO sas_tbl.dbo.tblAdmVsl(VslCode, Name, IMONo, Flag, VslTypeCode, Email) Values('" & Me.txtImo.Text & "','" & Me.txtVessel.Text & "', '" & Me.txtImo.Text & "', '" & Me.Flag.EditValue & "', '" & Me.Type.EditValue & "', '" & Me.txtEmail.Text & "')")

                clsAudit.saveAuditLog("ADD", USER_REAL, retid, System.Environment.MachineName, 10, "sas_tbl.dbo.tblAdmVsl", , , , "Vessel Info", "Vessel Information")
                clsAudit.saveAuditDetails(retid, "Name", IfNull(txtVessel.Text.Replace("'", "''"), ""))
                clsAudit.saveAuditDetails(retid, "Flag", IfNull(Flag.EditValue, ""))
                clsAudit.saveAuditDetails(retid, "VslTypeCode", IfNull(Type.EditValue, ""))
                clsAudit.saveAuditDetails(retid, "Email", IfNull(txtEmail.EditValue, ""))

                IMO_NUMBER = Me.txtImo.Text
            Else
                Me.Close()
                Exit Sub
            End If
            VESSEL = Me.txtVessel.Text
            FLAG_DESC = Me.Flag.Text
            TYPE_DESC = Me.Type.Text
            IS_SAVED = True
            Me.Close()
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub frmVesselInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Type.Properties.DataSource = PMSDB.CreateTable("Select VslTypeCode, Name from sas_tbl.dbo.tblAdmVslType")
        Me.Flag.Properties.DataSource = PMSDB.CreateTable("SELECT * FROM dbo.COUNTRYLIST ORDER BY Country")

        clsAudit.propSQLConnStr = PMSDB.GetConnectionString & "Password=" & SQL_PASSWORD  'neil
        oldVessel = txtVessel.Text
        oldFlag = Flag.EditValue
        oldType = Type.EditValue
        oldEmail = txtEmail.EditValue
    End Sub

    Function ISIMOConfirmed() As Boolean
        Dim frmIMO As New frmIMOWarning, is_confirmed As Boolean
        frmIMO.lblIMO.Text = Me.txtImo.Text
        frmIMO.ShowDialog()
        is_confirmed = frmIMO.is_confirmed
        frmIMO.Dispose()
        Return is_confirmed
    End Function

End Class