Public Class VLOCATION

    Public Overrides Sub DeleteData()
        If MsgBox("Are you sure want to delete the " & strDesc & " Location?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            DB.RunSql("DELETE FROM dbo.tblAdmLocation WHERE LocCode='" & strID & "'")
        End If
        blList.RefreshData()
        RefreshData()
    End Sub

    'Overriden From Base Control
    Public Overrides Sub SaveData()
        If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName}) Then
            If bAddMode Then
                strID = GenerateID(DB, "LocCode", "tblAdmLocation")
                DB.RunSql(GenerateInsertScript(Me.header, 3, "tblAdmLocation", "LocCode, LastUpdatedBy", "'" & strID & "', '" & GetUserName() & "'"))
                bRecordUpdated = False
                blList.RefreshData()
                blList.SetSelection(strID)
            Else
                DB.RunSql(GenerateUpdateScript(Me.header, 3, "tblAdmLocation", "LastUpdatedBy='" & GetUserName() & "', DateUpdated=GETDATE()", "LocCode='" & strID & "'"))
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
        Return "Location - " & strDesc
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
        Me.header.Text = "EDIT LOCATION DETAILS - " & blList.GetDesc.ToUpper
    End Sub

    Private Sub header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles header.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            OnRightClick(Name)
        End If
    End Sub
End Class
