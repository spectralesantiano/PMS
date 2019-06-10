Imports System.Drawing
Imports DevExpress.XtraGrid.Columns

Public Class PARTPURCHASE
    Dim strPartCodes As String = "", sqls As New ArrayList

    'Overriden From Base Control
    Public Overrides Sub SaveData()
        If ValidateFields(New DevExpress.XtraEditors.BaseEdit() {txtPurchaseDate}) Then
            Dim i As Integer, strDateReceived As String = "NULL", bHasUnreceived As Boolean = False, bHasReceived As Boolean = False
            sqls.Clear()
            If bAddMode Then
                strID = GenerateID(DB, "PartPurchaseCode", "tblPartPurchase")
                sqls.Add("INSERT INTO dbo.tblPartPurchase(PartPurchaseCode,PurchaseDate,Status,LastUpdatedBy) VALUES('" & strID & "', " & ChangeToSQLDate(txtPurchaseDate.EditValue) & ", 'Pending', '" & GetUserName() & "')")
            Else
                sqls.Add("UPDATE dbo.tblPartPurchase SET PurchaseDate=" & ChangeToSQLDate(txtPurchaseDate.EditValue) & ", LastUpdatedBy='" & GetUserName() & "', DateUpdated=Getdate() WHERE PartPurchaseCode='" & strID & "'")
            End If
            MainView.CloseEditor()
            MainView.UpdateCurrentRow()
            For i = 0 To MainView.RowCount - 1
                If MainView.GetRowCellValue(i, "Edited") Then
                    If IfNull(MainView.GetRowCellValue(i, "Quantity"), 0) = 0 Then
                        MsgBox("Please enter the quantity for " & MainView.GetRowCellDisplayText(i, "PartCode"), MsgBoxStyle.Critical)
                        Exit Sub
                    ElseIf MainView.GetRowCellValue(i, "Received") And MainView.GetRowCellValue(i, "DateReceived") Is DBNull.Value Then
                        MsgBox("Please enter the Date Received for " & MainView.GetRowCellDisplayText(i, "PartCode"), MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    If Not MainView.GetRowCellValue(i, "DateReceived") Is DBNull.Value Then strDateReceived = ChangeToSQLDate(MainView.GetRowCellValue(i, "DateReceived"))

                    If IfNull(MainView.GetRowCellValue(i, "PartPurchaseDetailID"), 0) = 0 Then
                        sqls.Add("INSERT Into dbo.tblPartPurchaseDetail([PartPurchaseCode],[PartCode],[VendorCode],[Quantity],[DateReceived],[ReceivedQuantity],[LastUpdatedBy]) Values('" & strID & "','" & MainView.GetRowCellValue(i, "PartCode") & "','" & MainView.GetRowCellValue(i, "VendorCode") & "'," & MainView.GetRowCellValue(i, "Quantity") & "," & strDateReceived & "," & IfNull(MainView.GetRowCellValue(i, "ReceivedQuantity"), "NULL") & ",'" & GetUserName() & "')")
                    Else
                        sqls.Add("UPDATE dbo.tblPartPurchaseDetail SET [VendorCode]='" & MainView.GetRowCellValue(i, "VendorCode") & "',[Quantity]=" & MainView.GetRowCellValue(i, "Quantity") & ",[DateReceived]=" & strDateReceived & ",[ReceivedQuantity]=" & IfNull(MainView.GetRowCellValue(i, "ReceivedQuantity"), "NULL") & ",[LastUpdatedBy]='" & GetUserName() & "' WHERE PartPurchaseDetailID=" & MainView.GetRowCellValue(i, "PartPurchaseDetailID"))
                    End If
                End If
                If MainView.GetRowCellValue(i, "Received") Then bHasReceived = True
                If Not MainView.GetRowCellValue(i, "Received") Then bHasUnreceived = True
            Next
            If bHasReceived And bHasUnreceived Then
                sqls.Add("UPDATE dbo.tblPartPurchase SET Status='Partially Delivered', LastUpdatedBy='" & GetUserName() & "', DateUpdated=Getdate() WHERE PartPurchaseCode='" & strID & "'")
            ElseIf Not bHasUnreceived Then
                sqls.Add("UPDATE dbo.tblPartPurchase SET Status='Delivered', LastUpdatedBy='" & GetUserName() & "', DateUpdated=Getdate() WHERE PartPurchaseCode='" & strID & "'")
            Else
                sqls.Add("UPDATE dbo.tblPartPurchase SET Status='Pending', LastUpdatedBy='" & GetUserName() & "', DateUpdated=Getdate() WHERE PartPurchaseCode='" & strID & "'")
            End If
            DB.RunSqls(sqls)
            bRecordUpdated = False
            blList.RefreshData()
            If bAddMode Then blList.SetSelection(strID)
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
            Me.txtPurchaseDate.EditValue = DBNull.Value
            Me.txtPurchaseDate.Focus()
            Me.txtPurchaseDate.Tag = 0
            Me.txtPurchaseDate.BackColor = REQUIRED_SELECTED_COLOR
            Me.txtStatus.Text = "Pending"
            MainGrid.DataSource = DB.CreateTable("SELECT *, CAST(CASE WHEN DateReceived IS NULL THEN 0 ELSE 1 END AS BIT) Received, CAST(0 AS BIT) Edited FROM dbo.tblPartPurchaseDetail WHERE PartPurchaseCode='xyz'")
            strPartCodes = ""
            cboUnit.EditValue = ""
            If pView.ActiveFilterString <> "" Then pView.ActiveFilterString = ""
            bRecordUpdated = False
        End If
    End Sub

    'Overriden From Base Control
    Public Overrides Function GetDesc() As String
        Return "Purchase - " & strDesc
    End Function

    'Overriden From Base Control
    Public Overrides Sub RefreshData()
        Dim i As Integer
        If Not bLoaded Then
            AllowAddition(Name, (bPermission And 2) > 0)
            AllowSaving(Name, False)
            AllowDeletion(Name, (bPermission And 8) > 0)
            AddEditListener(Me.txtPurchaseDate)
            SetAddVisibility(Name, IIf((bPermission And 2) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never))
            SetSaveVisibility(Name, IIf((bPermission And 4) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never))
            SetDeleteVisibility(Name, IIf((bPermission And 8) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never))
            VendorEdit.DataSource = DB.CreateTable("SELECT VendorCode, Name Vendor FROM dbo.tblAdmVendor")
            cboUnit.Properties.DataSource = DB.CreateTable("SELECT UnitCode, UnitDesc, ParentCode FROM dbo.tblAdmUnit")
            bLoaded = True
        End If
        pGrid.DataSource = DB.CreateTable("SELECT PartCode, PartCode pPartCode, p.Name Part, PartNumber, ISNULL(l.Name,'') + ' ' + ISNULL(s.Name,'') Storage, CAST(0 AS BIT) Selected, STUFF((SELECT '|' + up.UnitCode FROM dbo.tblUnitPart up WHERE up.PartCode=p.PartCode FOR XML PATH('')),1,1,'') UnitList FROM dbo.tblAdmPart p LEFT JOIN dbo.tblAdmLocation l ON p.LocCode=l.LocCode LEFT JOIN dbo.tblAdmStorage s ON p.StorageCode=s.StorageCode")
        PartEdit.DataSource = pGrid.DataSource
        If (bPermission And 4) = 0 Then
            RemoveEditListener(txtPurchaseDate)
        End If
        If blList.GetID = "" Then
            AddData()
        Else
            Me.txtPurchaseDate.EditValue = blList.GetFocusedRowData("PurchaseDate")
            Me.txtStatus.Text = blList.GetFocusedRowData("Status")
        End If
        Me.txtPurchaseDate.Tag = 0
        Me.txtPurchaseDate.BackColor = REQUIRED_SELECTED_COLOR
        MyBase.RefreshData()
        RemoveEditListener(txtStatus)
        MainGrid.DataSource = DB.CreateTable("SELECT *, CAST(CASE WHEN DateReceived IS NULL THEN 0 ELSE 1 END AS BIT) Received, CAST(0 AS BIT) Edited FROM dbo.tblPartPurchaseDetail WHERE PartPurchaseCode='" & strID & "'")
        strPartCodes = ""
        For i = 0 To MainView.RowCount - 1
            strPartCodes = strPartCodes & ",'" & MainView.GetRowCellValue(i, "PartCode") & "'"
        Next
        FilterParts()
    End Sub

    Private Sub pView_RowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles pView.RowCellStyle
        If e.RowHandle = pView.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        End If
    End Sub

    Private Sub header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles header.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            OnRightClick(Name)
        End If
    End Sub

    Public Overrides Sub DeleteData()
        If MsgBox("Are you sure want to remove this Purchase?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            DB.RunSql("DELETE FROM dbo.tblPartPurchase  WHERE PartPurchaseCode='" & strID & "'")
            bRecordUpdated = False
            blList.RefreshData()
            RefreshData()
        End If
    End Sub

    Private Sub MainView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles MainView.CellValueChanged
        If e.Column.Name <> "Edited" Then
            MainView.SetRowCellValue(e.RowHandle, "Edited", True)
        End If
    End Sub

    Private Sub MainView_CellValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles MainView.CellValueChanging
        AllowSaving(Name, (bPermission And 4) > 0)
        bRecordUpdated = True

        If e.Column.Name = "Received" Then
            If e.Value Then
                If MainView.GetRowCellValue(e.RowHandle, "DateReceived") Is DBNull.Value And Not (txtDefaultDate.EditValue Is DBNull.Value Or txtDefaultDate.EditValue Is Nothing) Then
                    MainView.SetRowCellValue(e.RowHandle, "DateReceived", txtDefaultDate.EditValue)
                End If
                If IfNull(MainView.GetRowCellValue(e.RowHandle, "ReceivedQuantity"), 0) = 0 Then
                    MainView.SetRowCellValue(e.RowHandle, "ReceivedQuantity", IfNull(MainView.GetRowCellValue(e.RowHandle, "Quantity"), 0))
                End If
            Else
                MainView.SetRowCellValue(e.RowHandle, "DateReceived", DBNull.Value)
                MainView.SetRowCellValue(e.RowHandle, "ReceivedQuantity", 0)
            End If
        End If

    End Sub

    Private Sub MainView_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles MainView.CustomColumnDisplayText
        If e.Column.Name = "Storage" Or e.Column.Name = "PartNumber" Then
            Dim nRowHandle As Integer = MainView.GetRowHandle(e.ListSourceRowIndex), row As DataRowView = PartEdit.GetDataSourceRowByKeyValue(MainView.GetRowCellValue(nRowHandle, "PartCode"))
            e.DisplayText = IfNull(row(e.Column.Name), "")
        End If
    End Sub

    Private Sub MainView_RowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
        Dim bIsEdited As Boolean = IfNull(MainView.GetRowCellValue(e.RowHandle, "Edited"), True)
        If e.Column.OptionsColumn.ReadOnly Then
            e.Appearance.BackColor = DISABLED_COLOR
        ElseIf bIsEdited And MainView.FocusedRowHandle = e.RowHandle Then
            e.Appearance.BackColor = EDITED_FOCUSED_COLOR
        ElseIf bIsEdited Then
            e.Appearance.BackColor = EDITED_COLOR
        ElseIf e.RowHandle = MainView.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        End If
    End Sub

    Private Sub cboUnit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboUnit.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Close Then
            cboUnit.EditValue = ""
        End If
    End Sub

    Private Sub cboUnit_EditValueChanged(sender As Object, e As System.EventArgs) Handles cboUnit.EditValueChanged
        FilterParts()
    End Sub

    Sub FilterParts()
        Dim strFilter As String = ""
        If IfNull(cboUnit.EditValue, "") <> "" Then
            strFilter = strFilter & "AND UnitList LIKE '%" & cboUnit.EditValue & "%'"
        End If
        If strPartCodes <> "" Then
            strFilter = strFilter & "AND NOT pPartCode IN (" & strPartCodes.Remove(0, 1) & ")"
        End If
        If strFilter = "" Then
            pView.ActiveFilterString = ""
        Else
            pView.ActiveFilterString = strFilter.Remove(0, 3)
        End If
    End Sub

    Private Sub DeleteEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles DeleteEdit.ButtonClick
        If IfNull(MainView.GetFocusedRowCellValue("PartPurchaseDetailID"), 0) > 0 Then
            DB.RunSql("DELETE FROM dbo.tblPartPurchaseDetail WHERE PartPurchaseDetailID=" & MainView.GetFocusedRowCellValue("PartPurchaseDetailID"))
        End If
        strPartCodes = strPartCodes.Replace(",'" & MainView.GetFocusedRowCellValue("PartCode") & "'", "")
        MainView.DeleteRow(MainView.FocusedRowHandle)
        FilterParts()
    End Sub

    Private Sub cmdAdd_Click(sender As System.Object, e As System.EventArgs) Handles cmdAdd.Click
        Dim i As Integer
        For i = 0 To pView.RowCount - 1
            If pView.GetRowCellValue(i, "Selected") Then
                strPartCodes = strPartCodes & ",'" & pView.GetRowCellValue(i, "pPartCode") & "'"
                pView.SetRowCellValue(i, Selected, False)
                MainView.AddNewRow()
                MainView.SetRowCellValue(MainView.FocusedRowHandle, PartCode, pView.GetRowCellValue(i, "pPartCode"))
                MainView.SetRowCellValue(MainView.FocusedRowHandle, Received, False)
                'MainView.SetRowCellValue(MainView.FocusedRowHandle, Edited, True)
                MainView.UpdateCurrentRow()
            End If
        Next
        FilterParts()
    End Sub

    Private Sub VendorEdit_ProcessNewValue(sender As Object, e As DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs) Handles VendorEdit.ProcessNewValue
        Dim row As DataRow, tbl As DataTable, strVendorCode As String = GenerateID(DB, "VendorCode", "tblAdmVendor")
        tbl = VendorEdit.DataSource
        If IfNull(e.DisplayValue, "") = "" Then Exit Sub
        row = tbl.NewRow
        DB.RunSql("INSERT INTO dbo.tblAdmVendor(VendorCode, Name, LastUpdatedBy) VALUES('" & strVendorCode & "', '" & e.DisplayValue & "','" & GetUserName() & "')")
        row("VendorCode") = strVendorCode
        row("Vendor") = e.DisplayValue
        tbl.Rows.Add(row)
        e.Handled = True
        AllowSaving(Name, (bPermission And 4) > 0)
        bRecordUpdated = True
    End Sub

    Private Sub cmdReceiveAll_Click(sender As System.Object, e As System.EventArgs) Handles cmdReceiveAll.Click
        If txtDefaultDate.EditValue Is Nothing Then
            MsgBox("Please enter the default received date.", MsgBoxStyle.Critical)
        Else
            Dim i As Integer, bHasUpdated As Boolean = False
            For i = 0 To MainView.RowCount - 1
                If Not MainView.GetRowCellValue(i, "Received") Then
                    MainView.SetRowCellValue(i, "Received", True)
                    MainView.SetRowCellValue(i, "DateReceived", txtDefaultDate.EditValue)
                    MainView.SetRowCellValue(i, "ReceivedQuantity", IfNull(MainView.GetRowCellValue(i, "Quantity"), 0))
                    bHasUpdated = True
                End If
            Next
            If bHasUpdated Then
                AllowSaving(Name, (bPermission And 4) > 0)
                bRecordUpdated = True
            End If
        End If
    End Sub
End Class
