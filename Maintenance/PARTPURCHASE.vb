Imports System.Drawing
Imports DevExpress.XtraGrid.Columns

Public Class PARTPURCHASE
    Dim strPartCodes As String = "", sqls As New ArrayList, strDeletedImages As String = ""
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String '= clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName) 'neil

    Public Overrides Sub ExecCustomFunction(ByVal param() As Object)
        Select Case param(0)
            Case "FilterCriticalParts"
                Me.pView.ActiveFilterString = IIf(CURRENT_CRITICAL_CHECKED, "OnStock<Minimum", "")
            Case "Preview"
                Dim frm As New frmInventoryPrintSelection
                frm.cboVendorCode.Properties.DataSource = VendorEdit.DataSource
                DB.BeginReader("EXEC dbo.GETSETTINGS")
                If DB.Read Then
                    frm.chkAddressToVendor.Checked = CBool(DB.ReaderItem("SPARE_VENDOR_SELECTED", "True"))
                    frm.chkOffice.Checked = Not frm.chkAddressToVendor.Checked
                    If frm.chkAddressToVendor.Checked Then
                        frm.cboVendorCode.EditValue = DB.ReaderItem("SPARE_ADDRESS_VALUE", "")
                    Else
                        frm.txtOfficeAddress.EditValue = DB.ReaderItem("SPARE_ADDRESS_VALUE", "")
                    End If
                End If
                DB.CloseReader()
                frm.ShowDialog()
                If frm.bPreview_Clicked Then
                    If frm.chkSpare.Checked Then
                        Dim strSent As String
                        DB.SaveConfig("SPARE_VENDOR_SELECTED", frm.chkAddressToVendor.Checked, APP_SHORT_NAME)
                        If frm.chkAddressToVendor.Checked Then
                            Dim nrow As DataRowView = frm.cboVendorCode.Properties.GetDataSourceRowByKeyValue(frm.cboVendorCode.EditValue)
                            DB.SaveConfig("SPARE_ADDRESS_VALUE", frm.cboVendorCode.EditValue, APP_SHORT_NAME)
                            strSent = IfNull(nrow("Address"), "")
                        Else
                            strSent = frm.txtOfficeAddress.EditValue
                            DB.SaveConfig("SPARE_ADDRESS_VALUE", frm.txtOfficeAddress.EditValue, APP_SHORT_NAME)
                        End If
                        RaiseCustomEvent(Name, New Object() {"Preview", "SPAREPARTREQ", "PMSReports", strID & "|" & strSent})
                    Else
                        RaiseCustomEvent(Name, New Object() {"Preview", "DELIVERCON", "PMSReports", strID & "|" & cboPortCode.Text})
                    End If
                End If
                'If MainView.RowCount = 0 Then
                '    MsgBox("Please select at least one record to preview.", MsgBoxStyle.Information, GetAppName)
                'Else
                '    RaiseCustomEvent(Name, New Object() {"Preview", "PURCHASEREP", "PMSReports", "|" & strID & "|"})
                'End If
        End Select
    End Sub

    'Overriden From Base Control
    Public Overrides Sub SaveData()
        If ValidateFields(New DevExpress.XtraEditors.BaseEdit() {txtPurchaseDate}) Then
            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_REAL, "", 10, System.Environment.MachineName, "Requisition", strCaption) 'neil

            If MainView.RowCount = 0 Then
                MsgBox("Please fill in the Purchase Details section.", MsgBoxStyle.Critical, GetAppName)
                Exit Sub
            End If
            Dim i As Integer, strDateReceived As String = "NULL", bHasUnreceived As Boolean = False, bHasReceived As Boolean = False
            sqls.Clear()
            If bAddMode Then
                strID = GenerateID(DB, "PartPurchaseCode", "tblPartPurchase")
                sqls.Add("INSERT INTO dbo.tblPartPurchase(PartPurchaseCode,PurchaseDate, PortCode,Status,LastUpdatedBy) VALUES('" & strID & "', " & ChangeToSQLDate(txtPurchaseDate.EditValue) & ",'" & IfNull(cboPortCode.EditValue, "") & "', 'Pending', '" & LastUpdatedBy & "')")
            Else
                sqls.Add("UPDATE dbo.tblPartPurchase SET PurchaseDate=" & ChangeToSQLDate(txtPurchaseDate.EditValue) & ",PortCode='" & IfNull(cboPortCode.EditValue, "") & "', LastUpdatedBy='" & LastUpdatedBy & "', DateUpdated=Getdate() WHERE PartPurchaseCode='" & strID & "'")
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
                    ElseIf MainView.GetRowCellValue(i, "Received") And IfNull(MainView.GetRowCellValue(i, "ReceivedQuantity"), 0) = 0 Then
                        MsgBox("Please enter the Received Quantity for " & MainView.GetRowCellDisplayText(i, "PartCode"), MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    If MainView.GetRowCellValue(i, "DateReceived") Is DBNull.Value Then
                        strDateReceived = "NULL"
                    Else
                        strDateReceived = ChangeToSQLDate(MainView.GetRowCellValue(i, "DateReceived"))
                    End If

                    If IfNull(MainView.GetRowCellValue(i, "PartPurchaseDetailID"), 0) = 0 Then
                        sqls.Add("INSERT Into dbo.tblPartPurchaseDetail([PartPurchaseCode],[PartCode],[MakerCode],[VendorCode],[Quantity],[DateReceived],[ReceivedQuantity],[Price],[LastUpdatedBy]) Values('" & strID & "','" & MainView.GetRowCellValue(i, "PartCode") & "','" & MainView.GetRowCellValue(i, "MakerCode") & "','" & MainView.GetRowCellValue(i, "VendorCode") & "'," & MainView.GetRowCellValue(i, "Quantity") & "," & strDateReceived & "," & IfNull(MainView.GetRowCellValue(i, "ReceivedQuantity"), "NULL") & "," & IfNull(MainView.GetRowCellValue(i, "Price"), "NULL") & ",'" & LastUpdatedBy & "')")
                    Else
                        sqls.Add("UPDATE dbo.tblPartPurchaseDetail SET [MakerCode]='" & MainView.GetRowCellValue(i, "MakerCode") & "',[VendorCode]='" & MainView.GetRowCellValue(i, "VendorCode") & "',[Quantity]=" & MainView.GetRowCellValue(i, "Quantity") & ",[DateReceived]=" & strDateReceived & ",[ReceivedQuantity]=" & IfNull(MainView.GetRowCellValue(i, "ReceivedQuantity"), "NULL") & ",[Price]=" & IfNull(MainView.GetRowCellValue(i, "Price"), "NULL") & ",[LastUpdatedBy]='" & LastUpdatedBy & "' WHERE PartPurchaseDetailID=" & MainView.GetRowCellValue(i, "PartPurchaseDetailID"))
                    End If
                End If
                If MainView.GetRowCellValue(i, "Received") Then bHasReceived = True
                If Not MainView.GetRowCellValue(i, "Received") Then bHasUnreceived = True
            Next
            If bHasReceived And bHasUnreceived Then
                sqls.Add("UPDATE dbo.tblPartPurchase SET Status='Partially Delivered', LastUpdatedBy='" & LastUpdatedBy & "', DateUpdated=Getdate() WHERE PartPurchaseCode='" & strID & "'")
            ElseIf Not bHasUnreceived Then
                sqls.Add("UPDATE dbo.tblPartPurchase SET Status='Delivered', LastUpdatedBy='" & LastUpdatedBy & "', DateUpdated=Getdate() WHERE PartPurchaseCode='" & strID & "'")
            Else
                sqls.Add("UPDATE dbo.tblPartPurchase SET Status='Pending', LastUpdatedBy='" & LastUpdatedBy & "', DateUpdated=Getdate() WHERE PartPurchaseCode='" & strID & "'")
            End If

            If strDeletedImages <> "" Then
                Dim strDeletedID() As String = strDeletedImages.ToString.Split(";"c), strDocID As String
                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_REAL, "", 10, System.Environment.MachineName, "", strcaption) 'neil

                For Each strDocID In strDeletedID
                    clsAudit.saveAuditPreDelDetails("tblDocuments", strDocID, LastUpdatedBy)
                    sqls.Add("DELETE FROM dbo.tblDocuments WHERE DocID=" & strDocID)
                Next
            End If

            IView.CloseEditor()
            IView.UpdateCurrentRow()

            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_REAL, "", 10, System.Environment.MachineName, "", strCaption) 'neil

            For i = 0 To IView.RowCount - 1
                If IfNull(IView.GetRowCellValue(i, "DocID"), 0) = 0 Then
                    sqls.Add("INSERT INTO dbo.tblDocuments(RefID, DocType, FileName, Doc, LastUpdatedBy) VALUES('" & strID & "','PURCHASE', '" & IView.GetRowCellValue(i, "FileName") & "','" & SetDefaultImageSizeToString(New Bitmap(IView.GetRowCellValue(i, "FileName").ToString)) & "','" & LastUpdatedBy & "')")
                End If
            Next

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
            Me.cboPortCode.EditValue = DBNull.Value
            Me.cboPortCode.Tag = 0
            Me.cboPortCode.BackColor = Color.White
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
            AddEditListener(Me.cboPortCode)
            SetAddVisibility(Name, IIf((bPermission And 2) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never))
            SetSaveVisibility(Name, IIf((bPermission And 4) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never))
            SetDeleteVisibility(Name, IIf((bPermission And 8) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never))
            VendorEdit.DataSource = DB.CreateTable("SELECT VendorCode, Name Vendor,[Address] FROM dbo.tblAdmVendor")
            MakerEdit.DataSource = DB.CreateTable("SELECT * FROM dbo.MAKERLIST")
            cboPortCode.Properties.DataSource = DB.CreateTable("SELECT * FROM dbo.PORTLIST")
            cboUnit.Properties.DataSource = DB.CreateTable("EXEC dbo.GETCOMPONENT @strUnitCode=''")
            bLoaded = True
        End If
        pGrid.DataSource = DB.CreateTable("SELECT PartCode, PartCode pPartCode, p.Name Part, PartNumber, OnStock, Minimum, ISNULL(l.Name,'') + ' ' + ISNULL(s.Name,'') Storage, CAST(0 AS BIT) Selected, STUFF((SELECT '|' + up.UnitCode FROM dbo.tblUnitPart up WHERE up.PartCode=p.PartCode FOR XML PATH('')),1,1,'') UnitList FROM dbo.tblAdmPart p LEFT JOIN dbo.tblAdmLocation l ON p.LocCode=l.LocCode LEFT JOIN dbo.tblAdmStorage s ON p.StorageCode=s.StorageCode")
        PartEdit.DataSource = pGrid.DataSource
        If (bPermission And 4) = 0 Then
            RemoveEditListener(txtPurchaseDate)
        End If
        If blList.GetID = "" Then
            AddData()
        Else
            Me.txtPurchaseDate.EditValue = blList.GetFocusedRowData("PurchaseDate")
            Me.txtStatus.Text = blList.GetFocusedRowData("Status")
            Me.cboPortCode.EditValue = blList.GetFocusedRowData("PortCode")
        End If
        Me.txtPurchaseDate.Tag = 0
        Me.txtPurchaseDate.BackColor = REQUIRED_SELECTED_COLOR
        Me.cboPortCode.Tag = 0
        Me.cboPortCode.BackColor = Color.White
        MyBase.RefreshData()
        RemoveEditListener(txtStatus)
        MainGrid.DataSource = DB.CreateTable("SELECT *, CAST(CASE WHEN DateReceived IS NULL THEN 0 ELSE 1 END AS BIT) Received, CAST(0 AS BIT) Edited FROM dbo.tblPartPurchaseDetail WHERE PartPurchaseCode='" & strID & "'")
        IGrid.DataSource = DB.CreateTable("SELECT * FROM [dbo].[DOCUMENTLIST] WHERE [DocType]='PURCHASE' AND [RefID]='" & strID & "'")
        strPartCodes = ""
        For i = 0 To MainView.RowCount - 1
            strPartCodes = strPartCodes & ",'" & MainView.GetRowCellValue(i, "PartCode") & "'"
        Next

        clsAudit.propSQLConnStr = DB.GetConnectionString & "Password=" & SQL_PASSWORD  'neil

        FilterParts()
        txtPurchaseDate.Focus()
    End Sub

    Private Sub pView_RowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles pView.RowCellStyle
        If e.RowHandle = pView.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        End If
        If IfNull(pView.GetRowCellValue(e.RowHandle, "Minimum"), 0) > IfNull(pView.GetRowCellValue(e.RowHandle, "OnStock"), 0) Then
            e.Appearance.ForeColor = Drawing.Color.Red
        End If
    End Sub

    Private Sub header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles header.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            OnRightClick(Name)
        End If
    End Sub

    Public Overrides Sub DeleteData()
        If txtStatus.Text = "Delivered" Then
            MsgBox("Deleting delivered purchases is not allowed.", MsgBoxStyle.Information)
        ElseIf MsgBox("Are you sure want to remove this Purchase?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
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
            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_REAL, "", 10, System.Environment.MachineName, "", strcaption) 'neil
            clsAudit.saveAuditPreDelDetails("tblPartPurchaseDetail", MainView.GetFocusedRowCellValue("PartPurchaseDetailID"), LastUpdatedBy)
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

        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_REAL, "", 10, System.Environment.MachineName, "", strcaption) 'neil

        DB.RunSql("INSERT INTO dbo.tblAdmVendor(VendorCode, Name, LastUpdatedBy) VALUES('" & strVendorCode & "', '" & e.DisplayValue & "','" & LastUpdatedBy & "')")
        row("VendorCode") = strVendorCode
        row("Vendor") = e.DisplayValue
        tbl.Rows.Add(row)
        e.Handled = True
        AllowSaving(Name, (bPermission And 4) > 0)
        bRecordUpdated = True
    End Sub

    Private Sub MakerEdit_ProcessNewValue(sender As Object, e As DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs) Handles MakerEdit.ProcessNewValue
        Dim row As DataRow, tbl As DataTable, strMakerCode As String = GenerateID(DB, "MakerCode", "tblAdmMaker")
        tbl = MakerEdit.DataSource
        If IfNull(e.DisplayValue, "") = "" Then Exit Sub
        row = tbl.NewRow

        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_REAL, "", 10, System.Environment.MachineName, "", strcaption) 'neil

        DB.RunSql("INSERT INTO dbo.tblAdmMaker(MakerCode, Name, LastUpdatedBy) VALUES('" & strMakerCode & "', '" & e.DisplayValue & "','" & LastUpdatedBy & "')")
        row("MakerCode") = strMakerCode
        row("Maker") = e.DisplayValue
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

    Private Sub txtPurchaseDate_EditValueChanged(sender As Object, e As System.EventArgs) Handles txtPurchaseDate.EditValueChanged
        If Not txtPurchaseDate.EditValue Is DBNull.Value Then
            DateReceiveEdit.MinValue = txtPurchaseDate.EditValue
            txtDefaultDate.Properties.MinValue = txtPurchaseDate.EditValue
        End If

    End Sub

    Private Sub DateReceiveEdit_EditValueChanged(sender As Object, e As System.EventArgs) Handles DateReceiveEdit.EditValueChanged, NumberEdit.EditValueChanged
        If MainView.FocusedColumn.Name = "ReceivedQuantity" Or MainView.FocusedColumn.Name = "DateReceived" Then
            If Not CBool(MainView.GetFocusedRowCellValue("Received")) Then MainView.SetFocusedRowCellValue("Received", True)
        End If
    End Sub

    Private Sub cmdBrowse_Click(sender As System.Object, e As System.EventArgs) Handles cmdBrowse.Click
        Dim odMain As New System.Windows.Forms.OpenFileDialog, strFile As String
        'odMain.Filter = "Files (*.jpg, *.jpeg, *.pdf) | *.jpg; *.jpeg; *.pdf"
        odMain.Filter = "Image Files (*.jpg, *.jpeg) | *.jpg; *.jpeg"
        odMain.Multiselect = True
        If odMain.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            For Each strFile In odMain.FileNames
                IView.AddNewRow()
                IView.SetRowCellValue(IView.FocusedRowHandle, "FileDesc", GetFileName(strFile))
                IView.SetRowCellValue(IView.FocusedRowHandle, "FileName", strFile)
                IView.SetRowCellValue(IView.FocusedRowHandle, "Edited", True)
                IView.SetRowCellValue(IView.FocusedRowHandle, "Doc", FileStreamToString(strFile))
                IView.UpdateCurrentRow()
                IView.CloseEditor()
            Next
            AllowSaving(Name, (bPermission And 4) > 0)
            bRecordUpdated = True
        End If
    End Sub

    Private Sub IDeleteEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles iDeleteEdit.ButtonClick
        'If MsgBox("Are you sure want to delete this attachment?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        If IfNull(IView.GetFocusedRowCellValue("DocID"), 0) > 0 Then 'Existing Image.
            strDeletedImages = strDeletedImages & IView.GetFocusedRowCellValue("DocID") & ";"
            AllowSaving(Name, (bPermission And 4) > 0)
            bRecordUpdated = True
        End If
        IView.DeleteRow(IView.FocusedRowHandle)
        'End If
    End Sub
End Class
