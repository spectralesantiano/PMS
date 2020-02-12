Public Class PART
    Dim dDateReported As Date, nNumber As Integer, strRemark As String = ""
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String '= clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName) 'neil

    Public Overrides Sub DeleteData()
        If MsgBox("Are you sure want to delete the " & strDesc & " Part?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Delete", 10, System.Environment.MachineName, "", Me.header.Text) 'neil
            clsAudit.saveAuditPreDelDetails("tblAdmPart", strID, LastUpdatedBy)

            DB.RunSql("DELETE FROM dbo.tblAdmPart WHERE PartCode='" & strID & "'")
        End If
        blList.RefreshData()
        RefreshData()
    End Sub

    'Overriden From Base Control
    Public Overrides Sub SaveData()
        If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName, txtPartNumber}) Then
            Dim sqls As New ArrayList, bUpdateList As Boolean = False, i As Integer
            If bAddMode Then
                strID = GenerateID(DB, "PartCode", "tblAdmPart")
                sqls.Add(GenerateInsertScript(Me.header, 3, "tblAdmPart", "PartCode, LastUpdatedBy", "'" & strID & "', '" & GetUserName() & "'"))
                bUpdateList = True
            Else
                sqls.Add(GenerateUpdateScript(Me.header, 3, "tblAdmPart", "LastUpdatedBy='" & GetUserName() & "', DateUpdated=GETDATE()", "PartCode='" & strID & "'"))
                bUpdateList = True
            End If
            'If strRemark <> "" Then sqls.Add("INSERT INTO [dbo].[tblPart_Missing]([PartCode],[DateMissing],[Number],[Remarks])VALUES('" & strID & "'," & ChangeToSQLDate(dDateReported) & "," & nNumber & ",'" & strRemark.Replace("'", "''") & "')")

            mView.CloseEditor()
            mView.UpdateCurrentRow()

            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", Me.header.Text) 'neil

            For i = 0 To mView.RowCount - 1
                If mView.GetRowCellValue(i, "Edited") Then
                    If mView.GetRowCellValue(i, "DateMissing") Is System.DBNull.Value Or mView.GetRowCellValue(i, "DateMissing") Is Nothing Or IfNull(mView.GetRowCellValue(i, "Number"), 0) = 0 Or IfNull(mView.GetRowCellValue(i, "Remarks"), "") = "" Then
                        MsgBox("Please fill in all the fields on the Missing section.")
                        Exit Sub
                    End If
                    If IfNull(mView.GetFocusedRowCellValue("Part_MissingID"), 0) = 0 Then
                        sqls.Add("INSERT INTO [dbo].[tblPart_Missing]([PartCode],[DateMissing],[Number],[Remarks],[LastupdatedBy])VALUES('" & strID & "'," & ChangeToSQLDate(mView.GetRowCellValue(i, "DateMissing")) & "," & mView.GetRowCellValue(i, "Number") & ",'" & mView.GetRowCellValue(i, "Remarks").ToString.Replace("'", "''") & "','" & LastUpdatedBy & "')")
                    Else
                        sqls.Add("UPDATE tblPart_Missing SET [DateMissing]=" & ChangeToSQLDate(mView.GetRowCellValue(i, "DateMissing")) & ",[Number]=" & mView.GetRowCellValue(i, "Number") & ",[Remarks]='" & mView.GetRowCellValue(i, "Remarks").ToString.Replace("'", "''") & "',[LastUpdatedBy]='" & LastUpdatedBy & "' WHERE Part_MissingID=" & mView.GetFocusedRowCellValue("Part_MissingID"))
                    End If
                End If
            Next

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

    Private Sub cboLocCode_ProcessNewValue(sender As Object, e As DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs) Handles cboLocCode.ProcessNewValue
        Dim row As DataRow, tbl As DataTable, strLocCode As String = GenerateID(DB, "LocCode", "tblAdmLocation")
        tbl = cboLocCode.Properties.DataSource
        If IfNull(e.DisplayValue, "") = "" Then Exit Sub
        row = tbl.NewRow

        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", Me.header.Text) 'neil

        DB.RunSql("INSERT INTO dbo.tblAdmLocation(LocCode, Name, LastUpdatedBy) VALUES('" & strLocCode & "', '" & e.DisplayValue & "','" & LastUpdatedBy & "')")
        row("LocCode") = strLocCode
        row("LocName") = e.DisplayValue
        tbl.Rows.Add(row)
        e.Handled = True
        AllowSaving(Name, (bPermission And 4) > 0)
        bRecordUpdated = True
    End Sub

    Private Sub cboStorageCode_ProcessNewValue(sender As Object, e As DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs) Handles cboStorageCode.ProcessNewValue
        Dim row As DataRow, tbl As DataTable, strStorageCode As String = GenerateID(DB, "StorageCode", "tblAdmStorage")
        tbl = cboStorageCode.Properties.DataSource
        If IfNull(e.DisplayValue, "") = "" Then Exit Sub
        row = tbl.NewRow

        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", Me.header.Text) 'neil

        DB.RunSql("INSERT INTO dbo.tblAdmStorage(StorageCode, Name, LastUpdatedBy) VALUES('" & strStorageCode & "', '" & e.DisplayValue & "','" & LastUpdatedBy & "')")
        row("StorageCode") = strStorageCode
        row("Storage") = e.DisplayValue
        tbl.Rows.Add(row)
        e.Handled = True
        AllowSaving(Name, (bPermission And 4) > 0)
        bRecordUpdated = True
    End Sub

    'Overriden From Base Control
    Public Overrides Function GetDesc() As String
        Return "Part - " & strDesc
    End Function

    'Overriden From Base Control
    Public Overrides Sub RefreshData()
        strRequiredFields = "txtName;txtPartNumber"
        If Not bLoaded Then
            cboLocCode.Properties.DataSource = DB.CreateTable("SELECT * FROM dbo.LOCATIONLIST")
            cboStorageCode.Properties.DataSource = DB.CreateTable("SELECT * FROM dbo.STORAGELIST")
            AllowAddition(Name, (bPermission And 2) > 0)
            AllowDeletion(Name, (bPermission And 8) > 0)
            AddEditListener(Me.header)
            RemoveEditListener(txtOnStock)
            bLoaded = True
        End If
        If (bPermission And 4) = 0 Then
            RemoveEditListener(Me.header)
        End If
        If blList.GetID = "" Then
            AddData()
        Else
            Me.txtName.EditValue = blList.GetDesc
            Me.txtPartNumber.EditValue = IfNull(blList.GetFocusedRowData("PartNumber"), "")
            Me.cboLocCode.EditValue = IfNull(blList.GetFocusedRowData("LocCode"), "")
            Me.cboStorageCode.EditValue = IfNull(blList.GetFocusedRowData("StorageCode"), "")
            Me.txtMinimum.EditValue = IfNull(blList.GetFocusedRowData("Minimum"), 0)
            Me.txtInitStock.EditValue = IfNull(blList.GetFocusedRowData("InitStock"), 0)
            Me.txtOnStock.EditValue = IfNull(blList.GetFocusedRowData("OnStock"), 0)
        End If
        ClearFields(Me.header, True)
        MyBase.RefreshData()
        txtOnStock.BackColor = DISABLED_COLOR
        cGrid.DataSource = DB.CreateTable("SELECT * FROM [dbo].[tblPartConsumption] WHERE PartCode='" & strID & "' ORDER BY [DateConsumed] DESC")
        mGrid.DataSource = DB.CreateTable("SELECT *, CAST(0 AS BIT) Edited FROM [dbo].[tblPart_Missing] WHERE PartCode='" & strID & "' ORDER BY [DateMissing] DESC")
        aGrid.DataSource = DB.CreateTable("SELECT * FROM dbo.PURCHASEDETAILLIST WHERE PartCode='" & strID & "' ORDER BY [DateReceived] DESC")
        txtInitStock.Enabled = aView.RowCount = 0 And cView.RowCount = 0 And mView.RowCount = 0
        Me.header.Text = "EDIT PART DETAILS - " & blList.GetDesc.ToUpper

        clsAudit.propSQLConnStr = DB.GetConnectionString & "Password=" & SQL_PASSWORD  'neil

    End Sub

    

    Private Sub header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles header.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            OnRightClick(Name)
        End If
    End Sub

    Private Sub txtInitStock_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles txtInitStock.EditValueChanged
        If IfNull(txtInitStock.EditValue, 0) > 0 Then
            Dim nConsumed As Integer = 0, nReceived As Integer = 0, i As Integer
            For i = 0 To cView.RowCount - 1
                nConsumed += cView.GetRowCellValue(i, "Number")
            Next
            For i = 0 To aView.RowCount - 1
                nReceived += aView.GetRowCellValue(i, "ReceivedQuantity")
            Next
            txtOnStock.EditValue = txtInitStock.EditValue - nConsumed + nReceived
            txtOnStock.Tag = 1
        End If
    End Sub

    Private Sub DeleteEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles DeleteEdit.ButtonClick
        Dim editor As DevExpress.XtraEditors.ButtonEdit = TryCast(sender, DevExpress.XtraEditors.ButtonEdit)
        Dim grid As DevExpress.XtraGrid.GridControl = TryCast(editor.Parent, DevExpress.XtraGrid.GridControl)
        If mView.RowCount > 0 Then

            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Delete", 10, System.Environment.MachineName, "", Me.header.Text) 'neil

            If mView.GetFocusedRowCellDisplayText("DateMissing").ToString <> "" Then
                If MsgBox("Are you sure want to delete the missing parts on " & CDate(mView.GetFocusedRowCellDisplayText("DateMissing")).ToShortDateString & "?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    If IfNull(mView.GetFocusedRowCellValue("Part_MissingID"), 0) > 0 Then
                        clsAudit.saveAuditPreDelDetails("tblPart_Missing", mView.GetFocusedRowCellValue("Part_MissingID"), LastUpdatedBy)

                        DB.RunSql("DELETE FROM dbo.tblPart_Missing WHERE Part_MissingID=" & mView.GetFocusedRowCellValue("Part_MissingID"))
                        RefreshData()
                    Else
                        mView.DeleteRow(mView.FocusedRowHandle)
                    End If
                End If
            Else
                If IfNull(mView.GetFocusedRowCellValue("Part_MissingID"), 0) > 0 Then
                    clsAudit.saveAuditPreDelDetails("tblPart_Missing", mView.GetFocusedRowCellValue("Part_MissingID"), LastUpdatedBy)

                    DB.RunSql("DELETE FROM dbo.tblPart_Missing WHERE Part_MissingID=" & mView.GetFocusedRowCellValue("Part_MissingID"))
                    RefreshData()
                Else
                    mView.DeleteRow(mView.FocusedRowHandle)
                End If
            End If
        End If
    End Sub

    Private Sub mView_CellValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles mView.CellValueChanging
        AllowSaving(Name, (bPermission And 4) > 0)
        bRecordUpdated = True
    End Sub

    Private Sub mView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles mView.CellValueChanged
        If e.Column.Name <> "Edited" Then
            mView.SetRowCellValue(e.RowHandle, "Edited", True)
        End If
    End Sub

    Private Sub mView_RowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles mView.RowCellStyle
        Dim bIsEdited As Boolean = IfNull(mView.GetRowCellValue(e.RowHandle, "Edited"), True)
        If bIsEdited And mView.FocusedRowHandle = e.RowHandle Then
            e.Appearance.BackColor = EDITED_FOCUSED_COLOR
        ElseIf bIsEdited Then
            e.Appearance.BackColor = EDITED_COLOR
        ElseIf e.RowHandle = mView.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        End If
    End Sub
    'Private Sub cmdAdd_Click(sender As System.Object, e As System.EventArgs) Handles cmdAdd.Click
    '    Dim frm As New frmAddMissingPart
    '    If strRemark <> "" Then
    '        frm.txtDate.EditValue = dDateReported
    '        frm.txtNumber.EditValue = nNumber
    '        frm.txtRemarks.EditValue = strRemark
    '    End If
    '    frm.ShowDialog()
    '    If frm.IS_SAVED Then
    '        dDateReported = frm.txtDate.EditValue
    '        nNumber = frm.txtNumber.EditValue
    '        strRemark = frm.txtRemarks.EditValue
    '        cView.AddNewRow()
    '        cView.SetRowCellValue(cView.FocusedRowHandle, "DateConsumed", dDateReported)
    '        cView.SetRowCellValue(cView.FocusedRowHandle, "Number", nNumber)
    '        cView.SetRowCellValue(cView.FocusedRowHandle, "Remarks", strRemark)
    '        cView.UpdateCurrentRow()
    '        cView.CloseEditor()
    '        AllowSaving(Name, (bPermission And 4) > 0)
    '        bRecordUpdated = True
    '    End If
    'End Sub
End Class