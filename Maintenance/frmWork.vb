Imports DevExpress.XtraTreeList.Nodes

Public Class frmWork

    Public IS_SAVED As Boolean = False, strIntCode As String, nInterval As Integer, db As SQLDB, bGetPrevWork As Boolean = True, nMaintenanceID As Integer = 0, bFieldUpdated As Boolean = False, strDeletedImages As String = "", strAddedImages As String = "", bInitialMaintenance As Boolean = False, pDueDate As String, pDueCounter As String
    Dim strRequiredFields = "cboUnit;cboMaintenance;cboRankCode;txtWorkDate;txtExecutedBy", nCurrentRunningHours As Integer, dCurrentReadingDate As Date = Nothing

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        If bFieldUpdated Then
            If ValidateFields(New DevExpress.XtraEditors.TextEdit() {cboUnit, cboMaintenance, cboRankCode, txtExecutedBy, txtWorkDate}) Then
                Dim i As Integer, nrow As DataRowView = cboMaintenance.Properties.GetDataSourceRowByKeyValue(cboMaintenance.EditValue)
                If Not nrow Is Nothing Then
                    strIntCode = IfNull(nrow("IntCode"), "")
                    nInterval = IfNull(nrow("Number"), 0)
                End If
                If strIntCode = "SYSHOURS" Then
                    If IfNull(txtWorkCounter.EditValue, 0) = 0 Then
                        MsgBox("Please enter the current running hours.", MsgBoxStyle.Critical, GetAppName)
                        Exit Sub
                    End If

                    If IfNull(txtPRunningHours.EditValue, 0) > 0 Then
                        If txtWorkCounter.EditValue < txtPRunningHours.EditValue Then
                            If Not (Date.Compare(dCurrentReadingDate, txtPDate.EditValue) > 0 And txtPRunningHours.EditValue > nCurrentRunningHours) Then 'Possible change of counter
                                MsgBox("The running hours should not be lower than the previous running hours reading.", MsgBoxStyle.Critical, GetAppName)
                                Exit Sub
                            End If
                        ElseIf Date.Compare(txtPDate.EditValue, txtWorkDate.EditValue) > 0 Then
                            MsgBox("The reading date should not be earlier than the previous reading date.", MsgBoxStyle.Critical, GetAppName)
                            Exit Sub
                        End If
                    End If

                    If nCurrentRunningHours > 0 Then
                        If nCurrentRunningHours > txtWorkCounter.EditValue And Date.Compare(dCurrentReadingDate, txtWorkDate.EditValue) < 0 Then
                            MsgBox("The running hours and reading date has conflict with the current running hours and reading date.", MsgBoxStyle.Critical, GetAppName)
                            Exit Sub
                        End If
                    End If

                    'ElseIf Not bInitialMaintenance AndAlso IfNull(txtWorkCounter.EditValue, 0) < nCurrentRunningHours Then
                    '    MsgBox("The running hours should not be lower than the latest running hours reading.", MsgBoxStyle.Critical, GetAppName)
                    '    Exit Sub
                End If
                IView.CloseEditor()
                IView.UpdateCurrentRow()
                For i = 0 To IView.RowCount - 1
                    If IfNull(IView.GetRowCellValue(i, "DocID"), 0) = 0 Then
                        strAddedImages = strAddedImages & IView.GetRowCellValue(i, "FileName") & ";"
                    End If
                Next
                If strAddedImages.Length > 0 Then strAddedImages = strAddedImages.Remove(strAddedImages.Length - 1)
                If strDeletedImages.Length > 0 Then strDeletedImages = strDeletedImages.Remove(strDeletedImages.Length - 1)

                IS_SAVED = True
                Me.Close()
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Public Sub AddFormEditListener(ByVal cContainer As DevExpress.XtraEditors.GroupControl)
        Dim ctr As System.Windows.Forms.Control
        For Each ctr In cContainer.Controls
            If ctr.Name <> "txtInsDesc" Then
                If TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                    AddHandler CType(ctr, DevExpress.XtraEditors.TextEdit).EditValueChanged, AddressOf FormField_EditValueChanged
                    AddHandler CType(ctr, DevExpress.XtraEditors.TextEdit).GotFocus, AddressOf FormField_GotFocus
                    AddHandler CType(ctr, DevExpress.XtraEditors.TextEdit).LostFocus, AddressOf FormField_LostFocus
                    If InStr(1, strRequiredFields, ctr.Name) > 0 Then
                        ctr.BackColor = REQUIRED_COLOR
                    Else
                        ctr.BackColor = Drawing.Color.White
                    End If
                    ctr.Tag = 0
                    ctr.Enabled = True
                ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Or TypeOf (ctr) Is DevExpress.XtraEditors.RadioGroup Then
                    AddHandler CType(ctr, DevExpress.XtraEditors.BaseEdit).EditValueChanged, AddressOf FormField_EditValueChanged
                    ctr.Tag = 0
                    ctr.Enabled = True
                End If
            End If
        Next
    End Sub

    'That that will be attached to fields and fires when that field is edited.
    Sub FormField_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not TypeOf (sender) Is DevExpress.XtraGrid.GridControl Then
            If TypeOf (sender) Is DevExpress.XtraEditors.TextEdit Then
                CType(sender, DevExpress.XtraEditors.TextEdit).BackColor = EDITED_FOCUSED_COLOR
            End If
            CType(sender, System.Windows.Forms.Control).Tag = 1
            bFieldUpdated = True
        End If
    End Sub

    'That that will be attached to fields and fires when that field got the focus.
    <System.Diagnostics.DebuggerStepThrough()> _
    Sub FormField_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If TypeOf (sender) Is DevExpress.XtraEditors.TextEdit Then
            If CType(sender, DevExpress.XtraEditors.TextEdit).Tag = 1 Then
                CType(sender, DevExpress.XtraEditors.TextEdit).BackColor = EDITED_FOCUSED_COLOR
            Else
                If InStr(1, strRequiredFields, CType(sender, DevExpress.XtraEditors.TextEdit).Name) > 0 Then
                    CType(sender, DevExpress.XtraEditors.TextEdit).BackColor = REQUIRED_SELECTED_COLOR
                Else
                    CType(sender, DevExpress.XtraEditors.TextEdit).BackColor = SEL_COLOR
                End If
            End If
        End If
    End Sub

    'That that will be attached to fields and fires when that field lost the focus.
    <System.Diagnostics.DebuggerStepThrough()> _
    Sub FormField_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If TypeOf (sender) Is DevExpress.XtraEditors.TextEdit Then
            If CType(sender, DevExpress.XtraEditors.TextEdit).Tag = 1 Then
                CType(sender, DevExpress.XtraEditors.TextEdit).BackColor = EDITED_COLOR
            Else
                If InStr(1, strRequiredFields, CType(sender, DevExpress.XtraEditors.TextEdit).Name) > 0 Then
                    CType(sender, DevExpress.XtraEditors.TextEdit).BackColor = REQUIRED_COLOR
                Else
                    CType(sender, DevExpress.XtraEditors.TextEdit).BackColor = Drawing.Color.White
                End If
            End If
        End If
    End Sub

    Private Sub frmWork_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        AddFormEditListener(gMain)
        If IfNull(cboUnit.EditValue, "") <> "" Then
            cboUnit.Properties.TreeList.FocusedNode = cboUnit.Properties.TreeList.FindNodeByFieldValue("UnitCode", cboUnit.EditValue)
            InitUnit()
        End If
        Me.txtWorkDate.Properties.MaxValue = Now.Date
        InitMaintenance()
    End Sub

    Sub InitUnit()
        Dim nNode As TreeListNode = cboUnit.Properties.TreeList.FocusedNode
        If Not nNode Is Nothing Then
            cboMaintenance.Properties.DataSource = db.CreateTable("SELECT [MaintenanceCode],[RankCode],[WorkDescription],Interval ,[Interval],[IntDue],[IntCode],[Number],[InsDesc] FROM [dbo].[COMPONENT_MAINTENANCELIST] WHERE UnitCode='" & nNode.GetValue("UnitCode") & "' OR LEFT(MaintenanceCode,3)='SYS' ORDER BY SortCode, WorkDescription")
            'PartEdit.DataSource = db.CreateTable("SELECT [PartCode],[Name] [Part],[OnStock] FROM [dbo].[tblAdmPart] WHERE OnStock>0 AND PartCode IN (SELECT [PartCode] FROM [dbo].[tblUnitPart] WHERE UnitCode='" & nNode.GetValue("UnitCode") & "')")
            MainGrid.DataSource = db.CreateTable("SELECT p.PartCode, p.OnStock, p.Name + ISNULL(' - ' + p.PartNumber ,'') AS Part, CAST(0 AS BIT) AS Edited, MaintenanceWorkID, Number, PartConsumptionID FROM dbo.tblAdmPart AS p INNER JOIN (SELECT PartCode FROM dbo.tblUnitPart WHERE (UnitCode = '" & nNode.GetValue("UnitCode") & "')) AS up ON p.PartCode = up.PartCode LEFT JOIN(SELECT PartCode,PartConsumptionID,MaintenanceWorkID,Number FROM dbo.tblPartConsumption WHERE (MaintenanceWorkID = " & nMaintenanceID & ")) AS pc ON p.PartCode = pc.PartCode")
            nCurrentRunningHours = IfNull(nNode.GetValue("RunningHours"), 0)
            If nCurrentRunningHours > 0 Then
                dCurrentReadingDate = nNode.GetValue("ReadingDate")
                lblRunningHours.Text = "Running Hours: " & nCurrentRunningHours
                lblReadingDate.Text = "Latest Reading: " & dCurrentReadingDate.ToShortDateString
            End If
        End If
    End Sub

    Sub InitMaintenance()
        If IfNull(cboMaintenance.EditValue, "") <> "" Then
            Dim nrow As DataRowView = cboMaintenance.Properties.GetDataSourceRowByKeyValue(cboMaintenance.EditValue)
            If Not nrow Is Nothing Then
                strIntCode = IfNull(nrow("IntCode"), "")
                nInterval = IfNull(nrow("Number"), 0)
                If IfNull(nrow("InsDesc"), "") <> "" Then
                    cmdCopy.Enabled = True
                    txtInsDesc.EditValue = IfNull(nrow("InsDesc"), "")
                End If
            End If
            txtWorkCounter.Enabled = strIntCode = "SYSHOURS"
            txtWorkCounter.BackColor = IIf(strIntCode = "SYSHOURS", System.Drawing.Color.White, DISABLED_COLOR)
            txtPDate.EditValue = Nothing
            txtPRunningHours.EditValue = Nothing
            txtPExec.EditValue = Nothing
            txtPRemarks.EditValue = Nothing
            If bGetPrevWork Then
                db.BeginReader("SELECT TOP 1 WorkDate, WorkCounter, ExecutedBy, Remarks,DueDate,DueCounter FROM dbo.tblMaintenanceWork WHERE UnitCode='" & cboUnit.EditValue & "' AND MaintenanceCode='" & cboMaintenance.EditValue & "' " & IIf(nMaintenanceID = 0, "", " AND MaintenanceWorkID<" & nMaintenanceID) & " ORDER BY WorkDate DESC")
                If db.Read Then
                    txtPDate.EditValue = db.ReaderItem("WorkDate")
                    txtPRunningHours.EditValue = db.ReaderItem("WorkCounter")
                    txtPExec.EditValue = db.ReaderItem("ExecutedBy")
                    txtPRemarks.EditValue = db.ReaderItem("Remarks")
                    If db.ReaderItem("DueDate") Is System.DBNull.Value Then
                        pDueDate = "NULL"
                    Else
                        pDueDate = ChangeToSQLDate(db.ReaderItem("DueDate"))
                    End If
                    pDueCounter = db.ReaderItem("DueCounter", "NULL")
                End If
                db.CloseReader()
            End If
        End If
    End Sub

    Private Sub cboUnit_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboUnit.EditValueChanged
        InitUnit()
    End Sub

    Private Sub cboMaintenance_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboMaintenance.EditValueChanged
        InitMaintenance()
    End Sub

    Private Sub cmdCopy_Click(sender As System.Object, e As System.EventArgs) Handles cmdCopy.Click
        txtRemarks.EditValue = txtInsDesc.EditValue
        'MsgBox(MainView.GetFocusedRowCellValue("PartCode"))
    End Sub

    Private Sub MainView_cellvaluechanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles MainView.CellValueChanged
        If e.Column.Name <> "Edited" Then
            MainView.SetRowCellValue(e.RowHandle, "Edited", True)
            bFieldUpdated = True
        End If
    End Sub


    Private Sub MainView_RowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
        If MainView.GetRowCellValue(e.RowHandle, "Edited") And MainView.FocusedRowHandle = e.RowHandle Then
            e.Appearance.BackColor = EDITED_FOCUSED_COLOR
        ElseIf MainView.GetRowCellValue(e.RowHandle, "Edited") Then
            e.Appearance.BackColor = EDITED_COLOR
        ElseIf e.RowHandle = MainView.FocusedRowHandle Then
            If e.Column.ReadOnly Then
                e.Appearance.BackColor = DISABLED_COLOR
            Else
                e.Appearance.BackColor = SEL_COLOR
            End If
        ElseIf e.Column.ReadOnly Then
            e.Appearance.BackColor = DISABLED_COLOR
        End If
    End Sub

    Private Sub DeleteEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles DeleteEdit.ButtonClick
        Dim editor As DevExpress.XtraEditors.ButtonEdit = TryCast(sender, DevExpress.XtraEditors.ButtonEdit)
        Dim grid As DevExpress.XtraGrid.GridControl = TryCast(editor.Parent, DevExpress.XtraGrid.GridControl)
        If IfNull(MainView.GetFocusedRowCellValue("PartConsumptionID"), 0) > 0 Then
            db.RunSql("DELETE FROM dbo.tblPartConsumption WHERE PartConsumptionID=" & MainView.GetFocusedRowCellValue("PartConsumptionID"))
        End If
        MainView.SetFocusedRowCellValue("Number", DBNull.Value)
        MainView.SetFocusedRowCellValue("PartConsumptionID", DBNull.Value)
        MainView.SetFocusedRowCellValue("Edited", False)
    End Sub

    Private Sub MainView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles MainView.ValidatingEditor
        If e.Value.ToString.Length > 0 Then
            If e.Value > IfNull(MainView.GetFocusedRowCellValue("OnStock"), 0) Then
                e.ErrorText = "Total parts consumed should not be greater than the current parts on stock."
                e.Valid = False
            End If
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
            bFieldUpdated = True
        End If
    End Sub

    Private Sub IDeleteEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles iDeleteEdit.ButtonClick
        'If MsgBox("Are you sure want to delete this attachment?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        If IfNull(IView.GetFocusedRowCellValue("DocID"), 0) > 0 Then 'Existing Image.
            strDeletedImages = strDeletedImages & IView.GetFocusedRowCellValue("DocID") & ";"
            bFieldUpdated = True
        End If
        IView.DeleteRow(IView.FocusedRowHandle)
        'End If
    End Sub
End Class