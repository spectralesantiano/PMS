Imports DevExpress.XtraTreeList.Nodes

Public Class frmWork

    Public IS_SAVED As Boolean = False, strIntCode As String, nInterval As Integer, db As SQLDB, bGetPrevWork As Boolean = True, nMaintenanceID As Integer = 0, bImageUpdated As Boolean = False
    Dim strRequiredFields = "cboUnit;cboMaintenance;cboRankCode;txtWorkDate;txtExecutedBy"

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        If ValidateFields(New DevExpress.XtraEditors.TextEdit() {cboUnit, cboMaintenance, cboRankCode, txtExecutedBy, txtWorkDate}) Then
            Dim nrow As DataRowView = cboMaintenance.Properties.GetDataSourceRowByKeyValue(cboMaintenance.EditValue)
            If Not nrow Is Nothing Then
                strIntCode = IfNull(nrow("IntCode"), "")
                nInterval = IfNull(nrow("Number"), 0)
            End If
            If strIntCode = "SYSHOURS" And IfNull(txtWorkCounter.EditValue, 0) = 0 Then
                MsgBox("Please enter the current running hours.", MsgBoxStyle.Critical, GetAppName)
                Exit Sub
            End If
            IS_SAVED = True
            Me.Close()
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Public Sub AddFormEditListener(ByVal cContainer As System.Windows.Forms.Form)
        Dim ctr As System.Windows.Forms.Control
        For Each ctr In cContainer.Controls
            If Not (ctr.Name = "gPrevMaintenance" Or ctr.Name = "txtInsDesc") Then
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
        AddFormEditListener(Me)
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
            PartEdit.DataSource = db.CreateTable("SELECT [PartCode],[Name] [Part],[OnStock] FROM [dbo].[tblAdmPart] WHERE OnStock>0 AND PartCode IN (SELECT [PartCode] FROM [dbo].[tblUnitPart] WHERE UnitCode='" & nNode.GetValue("UnitCode") & "')")
            MainGrid.DataSource = db.CreateTable("SELECT *, CAST(0 AS BIT) Edited FROM dbo.tblPartConsumption WHERE MaintenanceWorkID=" & nMaintenanceID)
            If IfNull(nNode.GetValue("RunningHours"), 0) > 0 Then
                lblRunningHours.Text = "Running Hours: " & nNode.GetValue("RunningHours")
                lblReadingDate.Text = "Latest Reading: " & CDate(nNode.GetValue("ReadingDate")).ToShortDateString
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
            If bGetPrevWork Then
                db.BeginReader("SELECT TOP 1 WorkDate, WorkCounter, ExecutedBy, Remarks FROM dbo.tblMaintenanceWork WHERE UnitCode='" & cboUnit.EditValue & "' AND MaintenanceCode='" & cboMaintenance.EditValue & "' " & IIf(nMaintenanceID = 0, "", " AND MaintenanceWorkID<" & nMaintenanceID) & " ORDER BY WorkDate DESC")
                If db.Read Then
                    txtPDate.EditValue = db.ReaderItem("WorkDate")
                    txtPRunningHours.EditValue = db.ReaderItem("WorkCounter")
                    txtPExec.EditValue = db.ReaderItem("ExecutedBy")
                    txtPRemarks.EditValue = db.ReaderItem("Remarks")
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
        End If
    End Sub

    Private Sub MainView_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles MainView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, View.Columns("Edited"), True)
    End Sub

    Private Sub MainView_RowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
        If MainView.GetRowCellValue(e.RowHandle, "Edited") And MainView.FocusedRowHandle = e.RowHandle Then
            e.Appearance.BackColor = EDITED_FOCUSED_COLOR
        ElseIf MainView.GetRowCellValue(e.RowHandle, "Edited") Then
            e.Appearance.BackColor = EDITED_COLOR
        ElseIf e.RowHandle = MainView.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        End If
    End Sub

    Private Sub DeleteEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles DeleteEdit.ButtonClick
        Dim editor As DevExpress.XtraEditors.ButtonEdit = TryCast(sender, DevExpress.XtraEditors.ButtonEdit)
        Dim grid As DevExpress.XtraGrid.GridControl = TryCast(editor.Parent, DevExpress.XtraGrid.GridControl)
        If IfNull(MainView.GetFocusedRowCellValue("PartConsumptionID"), 0) > 0 Then
            db.RunSql("DELETE FROM dbo.tblPartConsumption WHERE PartConsumptionID=" & MainView.GetFocusedRowCellValue("PartConsumptionID"))
        End If
        MainView.DeleteRow(MainView.FocusedRowHandle)
    End Sub

    Private Sub cmdClear_Click(sender As System.Object, e As System.EventArgs) Handles cmdClear.Click
        imgLogo.BackgroundImage = Nothing
        bImageUpdated = True
    End Sub

    Private Sub cmdBrowse_Click(sender As System.Object, e As System.EventArgs) Handles cmdBrowse.Click
        Dim odMain As New System.Windows.Forms.OpenFileDialog
        odMain.Filter = "Image files (*.jpg, *.jpeg) | *.jpg; *.jpeg"
        If odMain.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            imgLogo.BackgroundImage = New System.Drawing.Bitmap(odMain.FileName)
            bImageUpdated = True
        End If
    End Sub
End Class