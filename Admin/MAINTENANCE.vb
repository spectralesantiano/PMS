Public Class MAINTENANCE

    '/// audit
    'Dim FormName As String = "Admin Cash Advances"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String '= clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName) 'neil

    Public Overrides Sub DeleteData()
        If MsgBox("Are you sure want to delete the " & strDesc & " Maintenance Work?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_REAL, "", 10, System.Environment.MachineName, "Maintenance Work", strCaption) 'neil
            clsAudit.saveAuditPreDelDetails("tblAdmWork", strID, LastUpdatedBy)

            DB.RunSql("DELETE FROM dbo.tblAdmWork WHERE WorkCode='" & strID & "'")
        End If
        blList.RefreshData()
        RefreshData()
    End Sub


    Public Overrides Sub SaveData()
        If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName}) Then
            Dim sqls As New ArrayList, bUpdateList As Boolean = False

            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_REAL, "", 10, System.Environment.MachineName, "Maintenance Work", strCaption) 'neil

            If bAddMode Then
                strID = GenerateID(DB, "WorkCode", "tblAdmWork")
                sqls.Add(GenerateInsertScript(Me.header, 3, "tblAdmWork", "WorkCode, LastUpdatedBy", "'" & strID & "', '" & LastUpdatedBy & "'"))
                bUpdateList = True
            Else
                sqls.Add(GenerateUpdateScript(Me.header, 3, "tblAdmWork", "LastUpdatedBy='" & LastUpdatedBy & "', DateUpdated=GETDATE()", "WorkCode='" & strID & "'"))
                bUpdateList = True
            End If

            DB.RunSqls(sqls)
            bRecordUpdated = False
            If bUpdateList Then
                blList.RefreshData()
                If bAddMode Then
                    blList.SetSelection(strID)
                End If
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
    Public Overrides Sub RefreshData()
        strRequiredFields = "txtName"
        If Not bLoaded Then
            AllowAddition(Name, (bPermission And 2) > 0)
            AllowDeletion(Name, (bPermission And 8) > 0)
            RaiseCustomEvent(Name, New Object() {"EnableImport", IIf((bPermission And 16) > 0, "True", "False")})
            AddEditListener(Me.header)
            bLoaded = True
        End If
        If blList.GetID = "" Then
            AddData()
        Else
            Me.txtName.EditValue = blList.GetDesc
        End If
        ClearFields(Me.header, True)
        MyBase.RefreshData()
        Me.header.Text = "EDIT MAINTENANCE DETAILS - " & blList.GetDesc.ToUpper

        clsAudit.propSQLConnStr = DB.GetConnectionString '& "Password=" & SQL_PASSWORD  'neil

    End Sub

End Class
