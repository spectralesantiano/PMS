Public Class CATEGORY


    '/// audit
    'Dim FormName As String = "Admin Cash Advances"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String '= clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName) 'neil

    Public Overrides Sub DeleteData()
        If MsgBox("Are you sure want to delete the " & strDesc & " Category?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_REAL, "", 10, System.Environment.MachineName, "Category", strCaption) 'neil
            clsAudit.saveAuditPreDelDetails("tblAdmCategory", strID, LastUpdatedBy)

            DB.RunSql("DELETE FROM dbo.tblAdmCategory WHERE CatCode='" & strID & "'")
        End If
        blList.RefreshData()
        RefreshData()
    End Sub

    'Overriden From Base Control
    Public Overrides Sub SaveData()
        If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName}) Then

            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_REAL, "", 10, System.Environment.MachineName, "Category", strCaption) 'neil

            If bAddMode Then
                strID = GenerateID(DB, "CatCode", "tblAdmCategory")
                DB.RunSql(GenerateInsertScript(Me.header, 3, "tblAdmCategory", "CatCode, LastUpdatedBy", "'" & strID & "', '" & LastUpdatedBy & "'"))
                bRecordUpdated = False
                blList.RefreshData()
                blList.SetSelection(strID)
                RefreshData()
            Else
                DB.RunSql(GenerateUpdateScript(Me.header, 3, "tblAdmCategory", "LastUpdatedBy='" & LastUpdatedBy & "', DateUpdated=GETDATE()", "CatCode='" & strID & "'"))
                bRecordUpdated = False
                blList.RefreshData()
                RefreshData()
            End If
            bAddMode = False
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
            bRecordUpdated = False
        End If
    End Sub

    'Overriden From Base Control
    Public Overrides Function GetDesc() As String
        Return "Category - " & strDesc
    End Function

    'Overriden From Base Control
    Public Overrides Sub RefreshData()
        strRequiredFields = "txtName"
        If Not bLoaded Then
            AllowAddition(Name, (bPermission And 2) > 0)
            AllowDeletion(Name, (bPermission And 8) > 0)
            RaiseCustomEvent(Name, New Object() {"EnableImport", IIf((bPermission And 16) > 0, "True", "False")})
            AddEditListener(Me.header)
            bLoaded = True
        End If
        If (bPermission And 4) = 0 Then
            RemoveEditListener(Me.header)
        End If
        If blList.GetID = "" Then
            AddData()
        Else
            Me.txtName.EditValue = blList.GetDesc
        End If
        ClearFields(Me.header, True)
        MyBase.RefreshData()
        Me.header.Text = "EDIT CATEGORY DETAILS - " & blList.GetDesc.ToUpper

        clsAudit.propSQLConnStr = DB.GetConnectionString '& "Password=" & SQL_PASSWORD  'neil
    End Sub

    Private Sub header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles header.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            OnRightClick(Name)
        End If
    End Sub
End Class
