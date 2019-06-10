Public Class COUNTER

    Public Overrides Sub DeleteData()
        If MsgBox("Are you sure want to delete the " & strDesc & " Counter?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim sqls As New ArrayList, strUnitCode As String = blList.GetFocusedRowData("UnitCode")
            sqls.Add("DELETE FROM dbo.tblAdmCounter WHERE CounterCode='" & strID & "'")
            DB.RunSqls(sqls)
        End If
        blList.RefreshData()
        RefreshData()
    End Sub

    'Overriden From Base Control
    Public Overrides Sub SaveData()
        If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName}) Then
            If bAddMode Then
                strID = GenerateID(DB, "CounterCode", "tblAdmCounter")
                DB.RunSql(GenerateInsertScript(Me.header, 3, "tblAdmCounter", "CounterCode, LastUpdatedBy", "'" & strID & "', '" & GetUserName() & "'"))
                bRecordUpdated = False
                blList.RefreshData()
                blList.SetSelection(strID)
            Else
                DB.RunSql(GenerateUpdateScript(Me.header, 3, "tblAdmCounter", "LastUpdatedBy='" & GetUserName() & "'", "CounterCode='" & strID & "'"))
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
            Me.txtSortCode.EditValue = GetSortCode(DB, "tblAdmCounter")
            bRecordUpdated = False
        End If
    End Sub

    'Overriden From Base Control
    Public Overrides Function GetDesc() As String
        Return "Counter - " & strDesc
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
        Me.header.Text = "EDIT COUNTER DETAILS - " & blList.GetDesc.ToUpper
    End Sub

    Private Sub header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles header.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            OnRightClick(Name)
        End If
    End Sub
End Class