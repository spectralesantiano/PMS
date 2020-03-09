Public Class DEPARTMENT

    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String '= clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName) 'neil

    Public Overrides Sub DeleteData()
        If MsgBox("Are you sure want to delete the " & strDesc & " Department?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_REAL, "", 10, System.Environment.MachineName, "Department", strCaption) 'neil
            clsAudit.saveAuditPreDelDetails("tblAdmDept", strID, LastUpdatedBy)

            DB.RunSql("DELETE FROM dbo.tblAdmDept WHERE DeptCode='" & strID & "'")
        End If
        blList.RefreshData()
        RefreshData()
    End Sub

    'Overriden From Base Control
    Public Overrides Sub SaveData()
        If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName}) Then

            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_REAL, "", 10, System.Environment.MachineName, "Department", strCaption) 'neil

            If bAddMode Then
                strID = GenerateID(DB, "DeptCode", "tblAdmDept")
                DB.RunSql(GenerateInsertScript(Me.header, 3, "tblAdmDept", "DeptCode, LastUpdatedBy", "'" & strID & "', '" & LastUpdatedBy & "'"))
                bRecordUpdated = False
                blList.RefreshData()
                blList.SetSelection(strID)
            Else
                DB.RunSql(GenerateUpdateScript(Me.header, 3, "tblAdmDept", "LastUpdatedBy='" & LastUpdatedBy & "'", "DeptCode='" & strID & "'"))
                bRecordUpdated = False
                blList.RefreshData()
            End If
            bAddMode = False
            RefreshData()
        End If
    End Sub

    'Overriden From Base Control
    Public Overrides Sub AddData()
        If Not bAddMode Then
            ClearFields(Me.header, False)
            AllowSaving(Name, False) 'Disable save button 
            AllowDeletion(Name, False) 'Disable Delete button
            bAddMode = True
            blList.HideSelection()
            strID = ""
            strDesc = "New Record"
            Me.txtName.Focus()
            Me.txtName.BackColor = SEL_COLOR
            Me.txtSortCode.EditValue = GetSortCode(DB, "tblAdmDept")
            bRecordUpdated = False
        End If
    End Sub

    'Overriden From Base Control
    Public Overrides Function GetDesc() As String
        Return "Department - " & strDesc
    End Function

    'Overriden From Base Control
    Public Overrides Sub RefreshData()
        strRequiredFields = "txtName"
        If Not bLoaded Then
            AllowAddition(Name, (bPermission And 2) > 0)
            AllowDeletion(Name, (bPermission And 8) > 0)
            AddEditListener(Me.header)
            bLoaded = True
        End If
        If (bPermission And 4) = 0 Then
            RemoveEditListener(Me.header)
        End If
        If blList.GetID = "" Then
            AddData()
        Else
            Me.txtSortCode.Text = IfNull(blList.GetFocusedRowData("SortCode"), 0)
            Me.txtName.EditValue = blList.GetDesc
        End If
        ClearFields(Me.header, True)
        MyBase.RefreshData()
        Me.header.Text = "EDIT DEPARTMENT DETAILS - " & blList.GetDesc.ToUpper

        clsAudit.propSQLConnStr = DB.GetConnectionString '& "Password=" & SQL_PASSWORD  'neil

    End Sub

    Private Sub header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles header.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            OnRightClick(Name)
        End If
    End Sub
End Class
