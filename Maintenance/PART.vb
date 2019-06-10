Public Class PART

    Public Overrides Sub DeleteData()
        If MsgBox("Are you sure want to delete the " & strDesc & " Part?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            DB.RunSql("DELETE FROM dbo.tblAdmPart WHERE PartCode='" & strID & "'")
        End If
        blList.RefreshData()
        RefreshData()
    End Sub

    'Overriden From Base Control
    Public Overrides Sub SaveData()
        If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtName, txtPartNumber}) Then
            Dim sqls As New ArrayList, bUpdateList As Boolean = False
            If bAddMode Then
                strID = GenerateID(DB, "PartCode", "tblAdmPart")
                sqls.Add(GenerateInsertScript(Me.header, 3, "tblAdmPart", "PartCode, LastUpdatedBy", "'" & strID & "', '" & GetUserName() & "'"))
                bUpdateList = True
            Else
                sqls.Add(GenerateUpdateScript(Me.header, 3, "tblAdmPart", "LastUpdatedBy='" & GetUserName() & "'", "PartCode='" & strID & "'"))
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

    Private Sub cboLocCode_ProcessNewValue(sender As Object, e As DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs) Handles cboLocCode.ProcessNewValue
        Dim row As DataRow, tbl As DataTable, strLocCode As String = GenerateID(DB, "LocCode", "tblAdmLocation")
        tbl = cboLocCode.Properties.DataSource
        If IfNull(e.DisplayValue, "") = "" Then Exit Sub
        row = tbl.NewRow
        DB.RunSql("INSERT INTO dbo.tblAdmLocation(LocCode, Name, LastUpdatedBy) VALUES('" & strLocCode & "', '" & e.DisplayValue & "','" & GetUserName() & "')")
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
        DB.RunSql("INSERT INTO dbo.tblAdmStorage(StorageCode, Name, LastUpdatedBy) VALUES('" & strStorageCode & "', '" & e.DisplayValue & "','" & GetUserName() & "')")
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
        cGrid.DataSource = DB.CreateTable("SELECT [DateConsumed],[Number],[Remarks] FROM [dbo].[tblPartConsumption] WHERE PartCode='" & strID & "' ORDER BY [DateConsumed] DESC")
        aGrid.DataSource = DB.CreateTable("SELECT * FROM dbo.PURCHASEDETAILLIST WHERE PartCode='" & strID & "' ORDER BY [DateReceived] DESC")
        Me.header.Text = "EDIT PART DETAILS - " & blList.GetDesc.ToUpper
    End Sub

    

    Private Sub header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles header.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            OnRightClick(Name)
        End If
    End Sub

    Private Sub txtInitStock_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles txtInitStock.EditValueChanged
        If IfNull(txtInitStock.EditValue, 0) > 0 Then
            Dim nConsumed As Integer = 0, i As Integer
            For i = 0 To cView.RowCount - 1
                nConsumed += cView.GetRowCellValue(i, "Number")
            Next
            txtOnStock.EditValue = txtInitStock.EditValue - nConsumed
            txtOnStock.Tag = 1
        End If
    End Sub
End Class