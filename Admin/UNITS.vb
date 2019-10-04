Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo
Imports System.Drawing
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraTreeList.Columns

Public Class UNITS

    Dim downHitInfo As GridHitInfo = Nothing, tblUnitSource As DataTable, tblUnitCopy As DataTable, sqls As New ArrayList, strCurrView As String
    Dim nMaxUnitID As Integer, strEditMode As String, bRefreshMaintenance As Boolean, bRefreshCounter As Boolean, bRefreshParts As Boolean, bHasListeners As Boolean = False
    Dim strCounterCode As String, strCounter As String, nReading As Integer, strActiveCounter As String, nRunningHours As Integer, nCurrNode As TreeListNode
    Dim dDateIssue As Object = DBNull.Value, strEditor As String, bUpdating As Boolean

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

    Private Sub DeleteEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles DeleteEdit.ButtonClick
        Dim editor As DevExpress.XtraEditors.ButtonEdit = TryCast(sender, DevExpress.XtraEditors.ButtonEdit)
        Dim grid As DevExpress.XtraGrid.GridControl = TryCast(editor.Parent, DevExpress.XtraGrid.GridControl)
        If grid.Name = "MainGrid" Then
            If MsgBox("Are you sure want to delete the " & MainView.GetFocusedRowCellDisplayText("Component") & " Component?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                DB.RunSql("DELETE FROM dbo.tblAdmComponent WHERE ComponentCode='" & MainView.GetFocusedRowCellValue("ComponentCode") & "'")
                MainView.DeleteRow(MainView.FocusedRowHandle)
                getUnitsData(False)
            End If
        ElseIf grid.Name = "mGrid" Then

        End If
    End Sub

    Private Sub Edit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles Edit.ButtonClick
        Dim editor As DevExpress.XtraEditors.ButtonEdit = TryCast(sender, DevExpress.XtraEditors.ButtonEdit)
        Dim grid As DevExpress.XtraGrid.GridControl = TryCast(editor.Parent, DevExpress.XtraGrid.GridControl)
        If grid.Name = "MainGrid" Then
            Dim frm As New frmComponent
            frm.txtComponent.EditValue = MainView.GetFocusedRowCellValue("Component")
            frm.ShowDialog()
            If frm.bSaved Then
                DB.RunSql("UPDATE dbo.tblAdmComponent SET Name='" & frm.txtComponent.EditValue.ToString.Replace("'", "''") & "' WHERE ComponentCode='" & MainView.GetFocusedRowCellValue("ComponentCode") & "'")
                MainView.SetRowCellValue(MainView.FocusedRowHandle, "Component", frm.txtComponent.EditValue)
                MainView.RefreshRow(MainView.FocusedRowHandle)
            End If
        ElseIf grid.Name = "mGrid" Then

        End If
    End Sub

    Private Sub CounterEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        Dim frm As New frmCounter, nNode As TreeListNode = tlUnits.FocusedNode, strCounterCode As String = IfNull(nNode.GetValue("CounterCode"), "")
        frm.db = DB
        frm.MainGrid.DataSource = DB.CreateTable("SELECT *, CAST(0 AS BIT) Edited, CAST(0 AS BIT) Active FROM dbo.COUNTERHISTORYLIST WHERE UnitCode='" & nNode.GetValue("UnitCode") & "'")
        frm.strUnitCode = nNode.GetValue("UnitCode")
        If strCounterCode = "" Then
            frm.chkAdd.Checked = True
            frm.txtName.EditValue = GetUnitFullName(nNode)
            If Not nNode.ParentNode Is Nothing Then
                frm.strCounterCode = ""
                frm.strCounter = frm.txtName.EditValue & " - Old"
                frm.nReading = IfNull(GetRootNode(nNode).GetValue("RunningHours"), 0)
                frm.MainView.AddNewRow()
            End If
        Else
            frm.strCounterCode = strCounterCode
            frm.strCounter = nNode.GetValue("Counter")
        End If
        frm.ShowDialog()
        If frm.IS_SAVED Then
            nNode.SetValue("CounterCode", frm.strCounterCode)
            nNode.SetValue("Counter", frm.strCounter)
            nNode.SetValue("RunningHours", frm.txtRunningHours.EditValue)
        End If
    End Sub

#Region "cView"

    Private Sub cView_CustomDrawEmptyForeground(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs) Handles cView.CustomDrawEmptyForeground
        Dim strText As String = "Double Click to add Counter"
        e.DefaultDraw()
        e.Appearance.Options.UseFont = True
        e.Appearance.Font = New Font(Me.Font.Name, 12)
        e.Appearance.ForeColor = Color.DimGray
        Dim size As Size = e.Appearance.CalcTextSize(e.Cache, strText, e.Bounds.Width).ToSize()
        Dim x As Integer = (cGrid.Width - size.Width) \ 2
        e.Appearance.DrawString(e.Cache, strText, New Rectangle(New Point(x, 60), size))
    End Sub

    Private Sub cView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles cView.CellValueChanged
        If e.Column.Name <> "cEdited" Then
            cView.SetRowCellValue(e.RowHandle, "cEdited", True)
        End If
    End Sub

    Private Sub cView_DoubleClick(sender As Object, e As System.EventArgs) Handles cView.DoubleClick
        strCounterCode = "NEW"
        strCounter = "Ctr " & cView.RowCount + 1
        nReading = 0
        cView.AddNewRow()
    End Sub

    Private Sub cView_CellValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles cView.CellValueChanging
        AllowSaving(Name, (bPermission And 4) > 0)
        bRefreshCounter = True
        bRecordUpdated = True
    End Sub

    Private Sub cView_RowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles cView.RowCellStyle
        Dim bIsEdited As Boolean = IfNull(cView.GetRowCellValue(e.RowHandle, "cEdited"), True)
        If bIsEdited And cView.FocusedRowHandle = e.RowHandle Then
            e.Appearance.BackColor = EDITED_FOCUSED_COLOR
        ElseIf bIsEdited Then
            e.Appearance.BackColor = EDITED_COLOR
        ElseIf e.RowHandle = cView.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        End If
    End Sub

    Private Sub cView_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles cView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, View.Columns("cEdited"), True)
        View.SetRowCellValue(e.RowHandle, View.Columns("Counter"), strCounter)
        View.SetRowCellValue(e.RowHandle, View.Columns("Reading"), nReading)
        AllowSaving(Name, (bPermission And 4) > 0)
        bRefreshCounter = True
        bRecordUpdated = True
    End Sub

    'Private Sub cView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles cView.ValidatingEditor
    '    Dim nPrevCounterHandle As Integer = IIf(cView.IsNewItemRow(cView.FocusedRowHandle), 0, cView.FocusedRowHandle + 1)
    '    If cView.FocusedColumn.Name = "Reading" AndAlso (cView.RowCount - 1) >= nPrevCounterHandle Then
    '        If cView.GetRowCellValue(cView.FocusedRowHandle, "Counter") = cView.GetRowCellValue(nPrevCounterHandle, "Counter") Then
    '            If e.Value < IfNull(cView.GetRowCellValue(nPrevCounterHandle, "Reading"), 0) Then
    '                e.ErrorText = "Reading should not be less than the previous reading."
    '                e.Valid = False
    '            End If
    '        End If
    '    End If
    'End Sub

#End Region

#Region "pView"

    Private Sub pView_Click(sender As Object, e As System.EventArgs) Handles pView.Click
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim pt As Point = view.GridControl.PointToClient(System.Windows.Forms.Control.MousePosition)
        Dim info As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(pt)
        If (info.InRow Or info.InRowCell) Then
            If pView.FocusedColumn.Name <> "pSelected" Then
                Dim frm As New frmPart
                frm.cboPartCode.Properties.DataSource = DB.CreateTable("SELECT DISTINCT PartCode, Part FROM dbo.PARTLIST")
                If pView.IsNewItemRow(pView.FocusedRowHandle) Then
                    frm.cboPartCode.EditValue = ""
                    frm.txtPartNumber.EditValue = ""
                    frm.IS_NEW = True
                Else
                    frm.cboPartCode.EditValue = pView.GetRowCellValue(pView.FocusedRowHandle, "PartCode")
                    frm.txtPartNumber.EditValue = pView.GetRowCellValue(pView.FocusedRowHandle, "PartNumber")
                    frm.IS_NEW = False
                End If

                frm.ShowDialog()
                If frm.IS_SAVED Then
                    If pView.IsNewItemRow(pView.FocusedRowHandle) Then pView.AddNewRow()
                    pView.SetRowCellValue(pView.FocusedRowHandle, "pEdited", True)
                    If frm.IS_NEW Then pView.SetRowCellValue(pView.FocusedRowHandle, "pSelected", True)
                    pView.SetRowCellValue(pView.FocusedRowHandle, "Part", frm.cboPartCode.Text)
                    pView.SetRowCellValue(pView.FocusedRowHandle, "PartNumber", frm.txtPartNumber.EditValue)
                    pView.UpdateCurrentRow()
                    AllowSaving(Name, (bPermission And 4) > 0)
                    bRecordUpdated = True
                End If
            End If
        End If
    End Sub

    Private Sub pView_CellValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles pView.CellValueChanging
        AllowSaving(Name, (bPermission And 4) > 0)
        bRecordUpdated = True
        bRefreshParts = True
    End Sub

    Private Sub pView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles pView.CellValueChanged
        If e.Column.Name <> "pEdited" Then
            pView.SetRowCellValue(e.RowHandle, "pEdited", True)
        End If
    End Sub

    Private Sub pView_RowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles pView.RowCellStyle
        Dim bIsEdited As Boolean = IfNull(pView.GetRowCellValue(e.RowHandle, "pEdited"), True)
        If bIsEdited And pView.FocusedRowHandle = e.RowHandle Then
            e.Appearance.BackColor = EDITED_FOCUSED_COLOR
        ElseIf bIsEdited Then
            e.Appearance.BackColor = EDITED_COLOR
        ElseIf e.RowHandle = pView.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        End If
    End Sub

    Private Sub pView_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles pView.MouseDown
        Dim view As GridView = CType(sender, GridView)
        downHitInfo = Nothing
        Dim hitInfo As GridHitInfo = view.CalcHitInfo(New Point(e.X, e.Y))
        If Not (Control.ModifierKeys = Keys.Control Or Control.ModifierKeys = Keys.None Or Control.ModifierKeys = Keys.Shift) Then
            Exit Sub
        End If
        If e.Button = MouseButtons.Right Then
            downHitInfo = hitInfo
            strCurrView = "Part"
            pmCustomMenu.ShowPopup(Control.MousePosition)
        End If
    End Sub
    'Private Sub pView_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles pView.InitNewRow
    '    Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
    '    View.SetRowCellValue(e.RowHandle, View.Columns("pEdited"), True)
    '    View.SetRowCellValue(e.RowHandle, View.Columns("pSelected"), True)
    'End Sub

#End Region

#Region "mView"

    Private Sub mView_Click(sender As Object, e As System.EventArgs) Handles mView.Click
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim pt As Point = view.GridControl.PointToClient(System.Windows.Forms.Control.MousePosition)
        Dim info As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(pt)
        If (info.InRow Or info.InRowCell) Then
            If mView.FocusedColumn.Name = "mDelete" Then
                If (mView.FocusedRowHandle < 0) Then
                    mView.DeleteRow(mView.FocusedRowHandle)
                    Exit Sub
                End If
                If MsgBox("Are you sure want to delete the " & mView.GetFocusedRowCellDisplayText("WorkCode") & " Maintenance?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    If IfNull(mView.GetFocusedRowCellValue("MaintenanceCode"), "") <> "" Then
                        DB.RunSql("DELETE FROM dbo.tblAdmMaintenance WHERE MaintenanceCode='" & mView.GetFocusedRowCellValue("MaintenanceCode") & "'")
                    End If
                    mView.DeleteRow(mView.FocusedRowHandle)
                End If
            ElseIf mView.FocusedColumn.Name = "mPreview" Then
                Dim strDateIssue As String = ""
                If Not mView.GetRowCellValue(mView.FocusedRowHandle, "InsDateIssue") Is System.DBNull.Value Then
                    strDateIssue = CDate(mView.GetRowCellValue(mView.FocusedRowHandle, "InsDateIssue")).ToShortDateString
                End If
                RaiseCustomEvent(Name, New Object() {"Preview", "INSTRUCTIONREP", "Admin", strDesc & "|" & mView.GetRowCellDisplayText(mView.FocusedRowHandle, "WorkCode") & "|" & mView.GetRowCellValue(mView.FocusedRowHandle, "mNumber") & " " & mView.GetRowCellDisplayText(mView.FocusedRowHandle, "IntCode") & "|" & mView.GetRowCellDisplayText(mView.FocusedRowHandle, "RankCode") & "|" & IfNull(mView.GetRowCellDisplayText(mView.FocusedRowHandle, "InsCrossRef"), "").ToString & "|" & IfNull(mView.GetRowCellDisplayText(mView.FocusedRowHandle, "InsEditor"), "").ToString & "|" & strDateIssue & "|" & IfNull(mView.GetRowCellDisplayText(mView.FocusedRowHandle, "InsDesc"), "").ToString & "|" & mView.GetRowCellDisplayText(mView.FocusedRowHandle, "ImageDoc")})
            Else
                Dim frm As New frmMaintenance
                frm.DB = DB
                frm.MainGrid.DataSource = DB.CreateTable("SELECT * FROM [dbo].[DOCUMENTLIST] WHERE [DocType]='ADMWORK' AND [RefID]='" & mView.GetRowCellValue(mView.FocusedRowHandle, "MaintenanceCode") & "'")
                frm.cboWorkCode.Properties.DataSource = WorkEdit.DataSource
                frm.cboRankCode.Properties.DataSource = AdmRank
                frm.cboIntCode.Properties.DataSource = IntEdit.DataSource
                If mView.IsNewItemRow(mView.FocusedRowHandle) Then
                    frm.cboWorkCode.EditValue = ""
                    frm.cboRankCode.EditValue = ""
                    frm.cboIntCode.EditValue = ""
                    frm.txtInsCrossRef.EditValue = ""
                    frm.txtInsDateIssued.EditValue = dDateIssue
                    frm.txtInsEditor.EditValue = strEditor
                    frm.txtInsDesc.EditValue = ""
                Else
                    frm.cboWorkCode.EditValue = mView.GetRowCellValue(mView.FocusedRowHandle, "WorkCode")
                    frm.cboRankCode.EditValue = mView.GetRowCellValue(mView.FocusedRowHandle, "RankCode")
                    If IfNull(mView.GetRowCellValue(mView.FocusedRowHandle, "IntCode"), "") = "" Then
                        frm.chkPreventive.Checked = False
                    Else
                        frm.txtNumber.EditValue = mView.GetRowCellValue(mView.FocusedRowHandle, "Number")
                        frm.cboIntCode.EditValue = mView.GetRowCellValue(mView.FocusedRowHandle, "IntCode")
                    End If
                    frm.txtInsCrossRef.EditValue = mView.GetRowCellValue(mView.FocusedRowHandle, "InsCrossRef")
                    frm.txtInsDateIssued.EditValue = mView.GetRowCellValue(mView.FocusedRowHandle, "InsDateIssue")
                    frm.txtInsEditor.EditValue = mView.GetRowCellValue(mView.FocusedRowHandle, "InsEditor")
                    frm.txtInsDesc.EditValue = mView.GetRowCellValue(mView.FocusedRowHandle, "InsDesc")
                End If
                frm.ShowDialog()
                If frm.IS_SAVED Then
                    If mView.IsNewItemRow(mView.FocusedRowHandle) Then mView.AddNewRow()
                    mView.SetRowCellValue(mView.FocusedRowHandle, "mEdited", True)
                    mView.SetRowCellValue(mView.FocusedRowHandle, "HasImage", frm.MainView.RowCount > 0)
                    mView.SetRowCellValue(mView.FocusedRowHandle, "WorkCode", frm.cboWorkCode.EditValue)
                    mView.SetRowCellValue(mView.FocusedRowHandle, "RankCode", frm.cboRankCode.EditValue)
                    mView.SetRowCellValue(mView.FocusedRowHandle, "Number", frm.txtNumber.EditValue)
                    mView.SetRowCellValue(mView.FocusedRowHandle, "IntCode", frm.cboIntCode.EditValue)
                    mView.SetRowCellValue(mView.FocusedRowHandle, "InsCrossRef", frm.txtInsCrossRef.EditValue)
                    mView.SetRowCellValue(mView.FocusedRowHandle, "InsDateIssue", frm.txtInsDateIssued.EditValue)
                    mView.SetRowCellValue(mView.FocusedRowHandle, "InsEditor", frm.txtInsEditor.EditValue)
                    mView.SetRowCellValue(mView.FocusedRowHandle, "InsDesc", frm.txtInsDesc.EditValue)
                    mView.SetRowCellValue(mView.FocusedRowHandle, "AddedImages", frm.strAddedImages)
                    mView.SetRowCellValue(mView.FocusedRowHandle, "DeletedImages", frm.strDeletedImages)
                    dDateIssue = frm.txtInsDateIssued.EditValue
                    strEditor = IfNull(frm.txtInsEditor.EditValue, "")
                    mView.UpdateCurrentRow()
                    AllowSaving(Name, (bPermission And 4) > 0)
                    bRecordUpdated = True
                End If
            End If
        End If

    End Sub

    Private Sub mView_RowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles mView.RowCellStyle
        If Not (e.Column.Name = "mDelete" Or e.Column.Name = "mPreview" Or e.Column.Name = "mEdit") Then
            If mView.GetRowCellValue(e.RowHandle, "mEdited") And mView.FocusedRowHandle = e.RowHandle Then
                e.Appearance.BackColor = EDITED_FOCUSED_COLOR
            ElseIf mView.GetRowCellValue(e.RowHandle, "mEdited") Then
                e.Appearance.BackColor = EDITED_COLOR
            ElseIf e.RowHandle = mView.FocusedRowHandle Then
                e.Appearance.BackColor = SEL_COLOR
            End If
        End If
    End Sub

    Private Sub mView_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles mView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, View.Columns("mEdited"), True)
        AllowSaving(Name, (bPermission And 4) > 0)
        bRecordUpdated = True
    End Sub

    Private Sub mView_cellvaluechanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles mView.CellValueChanged
        If e.Column.Name <> "mEdited" Then
            mView.SetRowCellValue(e.RowHandle, "mEdited", True)
            bbiPaste.Enabled = False
            bbiImport.Enabled = False
            bRefreshMaintenance = True
        End If
    End Sub

    Private Sub mView_CellValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles mView.CellValueChanging
        AllowSaving(Name, (bPermission And 4) > 0)
        bRecordUpdated = True
    End Sub

    Private Sub mView_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles mView.MouseDown
        Dim view As GridView = CType(sender, GridView)
        downHitInfo = Nothing
        Dim hitInfo As GridHitInfo = view.CalcHitInfo(New Point(e.X, e.Y))
        If Not (Control.ModifierKeys = Keys.Control Or Control.ModifierKeys = Keys.None Or Control.ModifierKeys = Keys.Shift) Then
            Exit Sub
        End If

        If e.Button = MouseButtons.Right Then
            downHitInfo = hitInfo
            strCurrView = "Maintenance"
            pmCustomMenu.ShowPopup(Control.MousePosition)
        End If
    End Sub
#End Region

#Region "Tree"

    Private Sub tlUnits_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs) Handles tlUnits.DragEnter
        Dim provider = TryCast(e.Data.GetData(GetType(IDragNodesProvider)), IDragNodesProvider)
        If provider Is Nothing Then
            Return
        End If
        e.Effect = DragDropEffects.Copy
    End Sub

    Private Sub tlUnits_dragover(ByVal sender As Object, ByVal e As DragEventArgs) Handles tlUnits.DragOver
        Dim treeList As TreeList = TryCast(sender, TreeList)
        Dim info As TreeListHitInfo = treeList.CalcHitInfo(treeList.PointToClient(New Point(e.X, e.Y)))
        If e.Data.GetDataPresent(GetType(DataTable)) Then 'Dragged from Datagrid to Tree
            e.Effect = DragDropEffects.Copy
        Else 'Dragged from Tree to Tree
            Dim tree As TreeListNode = TryCast(e.Data.GetData(GetType(TreeListNode)), TreeListNode)
            If tree Is Nothing Then 'Or info.Node Is Nothing Then
                e.Effect = DragDropEffects.None
            ElseIf info.Node Is Nothing Then
                If tree.Level > 0 Then
                    e.Effect = DragDropEffects.Move
                Else
                    e.Effect = DragDropEffects.None
                End If
            ElseIf (info.Node.GetValue("UnitCode") = tree.GetValue("UnitCode")) Then
                e.Effect = DragDropEffects.None
            ElseIf tree.Level = info.Node.Level Then
                e.Effect = DragDropEffects.Move
            ElseIf tree.Level > info.Node.Level Then
                If (info.Node.GetValue("UnitCode") = tree.ParentNode.GetValue("UnitCode")) Then
                    e.Effect = DragDropEffects.None
                Else
                    e.Effect = DragDropEffects.Move
                End If
            Else
                e.Effect = DragDropEffects.None
            End If
        End If
    End Sub

    Private Function DragCanceled(strParent As String, strUnitDesc As String) As Boolean
        Return MsgBox("Do you want to add all selected components to " & strUnitDesc, vbYesNo) = vbNo
    End Function

    Private Sub tlUnits_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles tlUnits.DragDrop
        Dim treeList As TreeList = TryCast(sender, TreeList), bRootUpdated As Boolean = False
        Dim row As DataRow, tbl As DataTable = TryCast(e.Data.GetData(GetType(DataTable)), DataTable), rowNew As DataRow
        Dim info As TreeListHitInfo = treeList.CalcHitInfo(treeList.PointToClient(New Point(e.X, e.Y))), parent As Object, strParent As String = ""
        Dim nCompNum As Integer
        sqls.Clear()
        If info.Node Is Nothing Then 'Root Node
            parent = System.DBNull.Value
            strParent = "NULL"
            bRootUpdated = True
        Else
            parent = info.Node.GetValue(info.Node.TreeList.KeyFieldName)
            strParent = "'" & parent & "'"
        End If
        If tbl Is Nothing Then 'Dragged from the Treelist
            Dim tree As TreeListNode = TryCast(e.Data.GetData(GetType(TreeListNode)), TreeListNode)
            If Not tree Is Nothing Then
                If strParent <> "NULL" And CURRENT_SHOW_WARNING Then
                    If DragCanceled(strParent, info.Node.GetValue("UnitDesc")) Then
                        Exit Sub
                    End If
                End If
                Dim xrow() As DataRow = tblUnitSource.Select("UnitCode='" & tree.GetValue("UnitCode") & "'")
                If info.Node Is Nothing Then
                    If CURRENT_MAINUNIT = "" Then
                        nCompNum = GetMaxNumber(tlUnits.Nodes.GetEnumerator, tree.GetValue("ComponentCode"))
                    Else
                        nCompNum = DB.DLookUp("ISNULL(MAX(UnitNumber),0)", "dbo.tblAdmUnit", "0", "ParentCode IS NULL AND ComponentCode='" & tree.GetValue("ComponentCode") & "'") + 1
                    End If
                Else
                    nCompNum = GetMaxNumber(info.Node.Nodes.GetEnumerator, tree.GetValue("ComponentCode"))
                End If
                xrow(0)("ParentCode") = parent
                xrow(0)("UnitNumber") = nCompNum
                xrow(0)("UnitDesc") = tree.GetValue("Component") & " " & nCompNum
                If IfNull(parent, "") = xrow(0)("UnitCode") Then Exit Sub
                sqls.Add("UPDATE dbo.tblAdmUnit SET ParentCode=" & strParent & ", UnitNumber=" & nCompNum & ", UnitDesc='" & xrow(0)("UnitDesc") & "', LastUpdatedBy='" & GetUserName() & "' WHERE UnitCode='" & xrow(0)("UnitCode") & "'")
            End If
        Else 'Dragged from the Data Grid
            If strParent <> "NULL" And CURRENT_SHOW_WARNING Then
                If DragCanceled(strParent, info.Node.GetValue("UnitDesc")) Then
                    Exit Sub
                End If
            End If
            For Each row In tbl.Rows
                If info.Node Is Nothing Then
                    If CURRENT_MAINUNIT = "" Then
                        nCompNum = GetMaxNumber(tlUnits.Nodes.GetEnumerator, row("ComponentCode"))
                    Else
                        nCompNum = DB.DLookUp("ISNULL(MAX(UnitNumber),0)", "dbo.tblAdmUnit", "0", "ParentCode IS NULL AND ComponentCode='" & row("ComponentCode") & "'") + 1
                    End If
                Else
                    nCompNum = GetMaxNumber(info.Node.Nodes.GetEnumerator, row("ComponentCode"))
                End If
                rowNew = tblUnitSource.NewRow
                rowNew("UnitCode") = IMO_NUMBER & (nMaxUnitID + 1).ToString("00000000")
                rowNew("ParentCode") = parent
                rowNew("ComponentCode") = row("ComponentCode")
                rowNew("Component") = row("Component")
                rowNew("UnitDesc") = row("Component") & " " & nCompNum
                rowNew("UnitNumber") = nCompNum
                rowNew("Critical") = False
                rowNew("HasCritical") = False
                rowNew("HasInactive") = False
                rowNew("Active") = True
                tblUnitSource.Rows.Add(rowNew)
                sqls.Add("INSERT INTO dbo.tblAdmUnit(UnitCode, ParentCode, ComponentCode, UnitDesc, UnitNumber, LastUpdatedBy) VALUES('" & rowNew("UnitCode") & "'," & strParent & ",'" & rowNew("ComponentCode") & "','" & rowNew("UnitDesc") & "'," & rowNew("UnitNumber") & ",'" & GetUserName() & "')")
                nMaxUnitID += 1
            Next
        End If
        tlUnits.RefreshDataSource()
        DB.RunSqls(sqls)
        If Not parent Is System.DBNull.Value Then
            tlUnits.FindNodeByFieldValue("UnitCode", parent).ExpandAll()
        End If
        If bRootUpdated Then
            RaiseCustomEvent(Name, New Object() {"RefreshMainUnits", ""})
        End If
        AllowDeletion(Name, (bPermission And 8) > 0)
    End Sub

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub tlUnits_NodeCellStyle(sender As Object, e As DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs) Handles tlUnits.NodeCellStyle
        If e.Node.Selected Then
            e.Appearance.BackColor = SEL_COLOR
        End If
        If Not IfNull(e.Node.GetValue("Active"), True) Then
            e.Appearance.ForeColor = Color.Red
        ElseIf IfNull(e.Node.GetValue("HasInactive"), False) Then
            e.Appearance.ForeColor = Color.Orange
        End If
    End Sub

    Private Sub tlUnits_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles tlUnits.MouseDown
        Dim tl As TreeList = TryCast(sender, TreeList), info As TreeListHitInfo = tl.CalcHitInfo(e.Location)
        If (e.Button = Windows.Forms.MouseButtons.Right And info.HitInfoType = HitInfoType.Cell) Then
            info.Node.Selected = True
            OnRightClick(Name)
        End If
    End Sub

    Private Sub tlUnits_CellValueChanging(sender As Object, e As DevExpress.XtraTreeList.CellValueChangedEventArgs) Handles tlUnits.CellValueChanging
        AllowSaving(Name, (bPermission And 4) > 0)
        bRecordUpdated = True
        AllowDeletion(Name, (bPermission And 8) > 0)
    End Sub

    Private Sub tlUnits_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles tlUnits.ShowingEditor
        Dim tree As TreeListNode = tlUnits.FocusedNode
        e.Cancel = (Not tree.ParentNode Is Nothing) AndAlso (tlUnits.FocusedColumn.Name = "colLocCode" Or tlUnits.FocusedColumn.Name = "colDeptCode" Or tlUnits.FocusedColumn.Name = "colCatCode")
    End Sub

    Private Sub tlUnits_CustomDrawEmptyArea(sender As Object, e As DevExpress.XtraTreeList.CustomDrawEmptyAreaEventArgs) Handles tlUnits.CustomDrawEmptyArea
        If tlUnits.VisibleNodesCount = 0 Then
            Dim nOffset As Integer = (tlUnits.Height) \ 2, strText As String = "Drag Components Here."
            e.DefaultDraw()
            e.Appearance.Options.UseFont = True
            e.Appearance.Font = New Font(Me.Font.Name, 16)
            e.Appearance.ForeColor = Color.DimGray
            Dim size As Size = e.Appearance.CalcTextSize(e.Cache, strText, e.Bounds.Width).ToSize()
            Dim x As Integer = (tlUnits.Width - size.Width) \ 2
            Dim y As Integer = IIf(nOffset < 80, 80, nOffset)
            e.Appearance.DrawString(e.Cache, strText, New Rectangle(New Point(x, y), size))
            e.Handled = True
        End If
    End Sub

    Private Sub tlUnits_FocusedNodeChanged(sender As Object, e As DevExpress.XtraTreeList.FocusedNodeChangedEventArgs) Handles tlUnits.FocusedNodeChanged
        CheckIFDataUpdated()
        Editable()
        bRefreshMaintenance = False
        bRefreshCounter = False
        bRefreshParts = False
        ClearFields(gUnitInfo, True)
    End Sub

#End Region

#Region "MainView"

    Private Sub MainView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles MainView.KeyDown
        If e.KeyCode = Keys.Enter Then
            MainView.CloseEditor()
            MainView.UpdateCurrentRow()
            e.Handled = True
        End If
    End Sub

    Private Sub MainView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles MainView.CellValueChanged
        If e.Column.Name = "Component" Then
            Dim strComponent As String = MainView.GetFocusedRowCellValue("Component").ToString.Replace("'", "''")
            Dim strComponentCode = GenerateID(DB, "ComponentCode", "tblAdmComponent")
            If DB.DLookUp("Name", "dbo.tblAdmComponent", "", "Name='" & strComponent & "'") <> "" Then
                MsgBox(strComponent & " already exists.", vbCritical, GetAppName)
                MainView.DeleteRow(MainView.FocusedRowHandle)
                Exit Sub
            End If
            DB.RunSql("INSERT INTO dbo.tblAdmComponent(ComponentCode, Name, LastUpdatedBy) VALUES('" & strComponentCode & "', '" & strComponent & "','" & GetUserName() & "')")
            MainView.SetRowCellValue(MainView.FocusedRowHandle, "ComponentCode", strComponentCode)
        End If
    End Sub

    Private Sub MainView_RowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
        If MainView.IsRowSelected(e.RowHandle) Then
            e.Appearance.BackColor = SEL_COLOR
        End If
    End Sub

    Private Sub MainView_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MainView.MouseMove
        Dim view As GridView = CType(sender, GridView)
        If e.Button = Windows.Forms.MouseButtons.Left And Not downHitInfo Is Nothing Then
            Dim dragSize As System.Drawing.Size = SystemInformation.DragSize
            Dim DragRect As Rectangle = New Rectangle(New Point(downHitInfo.HitPoint.X - dragSize.Width / 2, downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize)
            If Not DragRect.Contains(New Point(e.X, e.Y)) Then
                view.GridControl.DoDragDrop(GetSelectedRows(), DragDropEffects.Copy)
                downHitInfo = Nothing
                DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = True
            End If
        End If
    End Sub

    Private Sub MainView_ShowingEditor(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MainView.ShowingEditor
        e.Cancel = Not (MainView.IsNewItemRow(MainView.FocusedRowHandle) Or MainView.FocusedColumn.Name = "cDelete" Or MainView.FocusedColumn.Name = "cEdit")
    End Sub

    Private Sub MainView_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles MainView.MouseDown
        Dim view As GridView = CType(sender, GridView)
        downHitInfo = Nothing
        Dim hitInfo As GridHitInfo = view.CalcHitInfo(New Point(e.X, e.Y))
        If Not (Control.ModifierKeys = Keys.Control Or Control.ModifierKeys = Keys.None Or Control.ModifierKeys = Keys.Shift) Then
            Exit Sub
        End If
        If e.Button = MouseButtons.Right Then
            downHitInfo = hitInfo
            strCurrView = "Component"
            pmCustomMenu.ShowPopup(Control.MousePosition)
        ElseIf e.Button = Windows.Forms.MouseButtons.Left AndAlso hitInfo.InRow Then
            downHitInfo = hitInfo
        End If
    End Sub
#End Region

#Region "Other Functions"

    Sub Editable()
        Dim nNode As TreeListNode = tlUnits.FocusedNode
        bUpdating = True
        If nNode Is Nothing Then
            strID = ""
            strDesc = "New Record"
            mGrid.DataSource = Nothing
            mGrid.Enabled = False
            pGrid.DataSource = Nothing
            pGrid.Enabled = False
            cGrid.DataSource = Nothing
            cGrid.Enabled = False
            mView.NewItemRowText = "Click here to add new maintenance"
            txtUnitDesc.EditValue = ""
            cboDeptCode.EditValue = ""
            cboLocCode.EditValue = ""
            cboCatCode.EditValue = ""
            cboMakerCode.EditValue = ""
            cboVendorCode.EditValue = ""
            txtType.EditValue = ""
            txtModel.EditValue = ""
            txtRefNo.EditValue = ""
            chkCritical.Checked = False
            chkActive.Checked = True
            ClearFields(gUnitInfo, True)
            If bHasListeners Then RemoveEditListener(gUnitInfo)
            bHasListeners = False
        Else
            strID = nNode.GetValue("UnitCode")
            strDesc = GetUnitFullName(nNode)
            txtUnitDesc.EditValue = nNode.GetValue("UnitDesc")
            cboDeptCode.EditValue = nNode.GetValue("DeptCode")
            cboLocCode.EditValue = nNode.GetValue("LocCode")
            cboCatCode.EditValue = nNode.GetValue("CatCode")
            cboMakerCode.EditValue = nNode.GetValue("MakerCode")
            cboVendorCode.EditValue = nNode.GetValue("VendorCode")
            txtType.EditValue = nNode.GetValue("Type")
            txtModel.EditValue = nNode.GetValue("Model")
            txtRefNo.EditValue = nNode.GetValue("RefNo")
            txtSerialNumber.EditValue = nNode.GetValue("SerialNumber")
            chkCritical.Checked = IfNull(nNode.GetValue("Critical"), False)
            chkActive.Checked = IfNull(nNode.GetValue("Active"), True)
            cboDeptCode.Enabled = nNode.Level = 0
            cboLocCode.Enabled = nNode.Level = 0
            cboCatCode.Enabled = nNode.Level = 0
            'Maintenance
            mGrid.DataSource = DB.CreateTable("SELECT *,CAST(0 AS BIT) mEdited, '' AddedImages,'' DeletedImages, CAST(0 AS BIT) HasImage FROM dbo.MAINTENANCELIST WHERE UnitCode='" & strID & "'")
            mView.NewItemRowText = "Click here to add new maintenance for " & strDesc
            mGrid.Enabled = True
            'Part
            pGrid.DataSource = DB.CreateTable("SELECT p.PartCode, Name Part, PartNumber, CAST(0 AS BIT) pEdited, CAST(CASE WHEN up.PartCode IS NULL THEN 0 ELSE 1 END AS BIT) pSelected FROM dbo.tblAdmPart p LEFT JOIN (SELECT PartCode FROM [dbo].[tblUnitPart] WHERE UnitCode='" & strID & "') up ON p.PartCode=up.PartCode ORDER BY CASE WHEN up.PartCode IS NULL THEN 1 ELSE 0 END, p.Name")
            pGrid.Enabled = True
            'Counter
            cGrid.DataSource = DB.CreateTable("SELECT *, CAST(0 AS BIT) cEdited FROM dbo.COUNTERLATESTREADING WHERE UnitCode='" & strID & "' ORDER BY ReadingDate Desc")
            cGrid.Enabled = True
            If cView.RowCount > 0 Then
                strCounterCode = cView.GetRowCellValue(0, "CounterCode")
                strCounter = cView.GetRowCellValue(0, "Counter")
            Else
                strCounterCode = ""
                strCounter = 0
            End If
            If Not bHasListeners Then AddEditListener(Me.gUnitInfo)
            bHasListeners = True
            If Not nNode.ParentNode Is Nothing Then
                chkActive.Enabled = nNode.ParentNode.GetValue("Active")
            Else
                chkActive.Enabled = True
            End If
        End If
        bUpdating = False
    End Sub

    Private Function GetSelectedRows() As DataTable
        Dim _tbl As New DataTable, xrow As Integer
        Dim ccolumn As DataColumn
        ccolumn = New DataColumn
        ccolumn.ColumnName = "ComponentCode"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "Component"
        ccolumn.DataType = System.Type.GetType("System.String")
        _tbl.Columns.Add(ccolumn)
        For Each xrow In MainView.GetSelectedRows
            _tbl.ImportRow(MainView.GetDataRow(xrow))
        Next
        Return _tbl
    End Function

    Public Overrides Sub DeleteData()
        Dim xNode As TreeListNode = tlUnits.FocusedNode, bRootUpdated As Boolean = xNode.Level = 0, strUnitCode As String = xNode.GetValue("UnitCode")
        If MsgBox("Are you sure want to delete the " & xNode.GetValue("UnitDesc") & " Component?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim crow() As DataRow = tblUnitSource.Select("ParentCode='" & strUnitCode & "'")
            sqls.Clear()
            sqls.Add("DELETE FROM dbo.tblAdmUnit WHERE UnitCode='" & strUnitCode & "'")
            If crow.Length > 0 Then
                CreateDeleteSQLs(crow)
            End If
            DB.RunSqls(sqls)
            tlUnits.DeleteSelectedNodes()
            If bRootUpdated Then
                RaiseCustomEvent(Name, New Object() {"RefreshMainUnits", IIf(strUnitCode = CURRENT_MAINUNIT, "DELETE", "")})
            End If
            Editable()
        End If
    End Sub

    Public Overrides Sub SaveData()
        If ValidateFields(New DevExpress.XtraEditors.BaseEdit() {txtUnitDesc}) Then
            Dim i As Integer, strPartID As String
            Dim nNode As TreeListNode = tlUnits.FindNodeByFieldValue("UnitCode", strID)

            sqls.Clear()
            sqls.Add(GenerateUpdateScript(Me.gUnitInfo, 3, "tblAdmUnit", "LastUpdatedBy='" & GetUserName() & "', HasInactive=" & IIf(chkActive.Checked, 0, 1) & ", HasCritical=" & IIf(chkCritical.Checked, 0, 1), "UnitCode='" & strID & "'"))

            RemoveHandler tlUnits.FocusedNodeChanged, AddressOf tlUnits_FocusedNodeChanged

            If chkActive.Tag = 1 Then
                nNode.SetValue("HasInactive", Not chkActive.Checked)
                If Not nNode.ParentNode Is Nothing Then
                    nNode.SetValue("Active", chkActive.Checked)
                    UpdateActiveParent(nNode.ParentNode) 'Updated parents node's HasInactive values
                End If
                UpdateActiveChild(nNode, chkActive.Checked) 'Updated child node's Active values
            End If

            If chkCritical.Tag = 1 Then
                If Not nNode.ParentNode Is Nothing Then
                    nNode.SetValue("Critical", chkCritical.Checked)
                    UpdateCriticalParent(nNode.ParentNode) 'Updated parents node's HasCritical values
                End If
            End If

            AddHandler tlUnits.FocusedNodeChanged, AddressOf tlUnits_FocusedNodeChanged

            ''''''''''''MAINTENANCE'''''''''''
            mView.CloseEditor()
            mView.UpdateCurrentRow()
            For i = 0 To mView.RowCount - 1
                If mView.GetRowCellValue(i, "mEdited") Then
                    If IfNull(mView.GetRowCellValue(i, "WorkCode"), "") = "" Then
                        MsgBox("Please fill in the Maintenance Description field.")
                        Exit Sub
                    End If
                    Dim strDateIssue As String = "NULL"
                    If Not mView.GetRowCellValue(i, "InsDateIssue") Is System.DBNull.Value Then strDateIssue = ChangeToSQLDate(mView.GetRowCellValue(i, "InsDateIssue"))
                    If mView.GetRowCellValue(i, "MaintenanceCode") Is System.DBNull.Value Then
                        sqls.Add("INSERT INTO [dbo].[tblAdmMaintenance]([MaintenanceCode],[WorkCode],[UnitCode],[RankCode],[Number],[IntCode],[InsCrossRef],[InsEditor],[InsDocument],[InsDateIssue],[InsDesc],[LastUpdatedBy],[HasImage]) " & _
                                 "Values(dbo.MAINTENANCEID(),'" & mView.GetRowCellValue(i, "WorkCode") & "', '" & strID & "', '" & mView.GetRowCellValue(i, "RankCode") & "', " & IfNull(mView.GetRowCellValue(i, "Number"), "NULL") & ", '" & mView.GetRowCellValue(i, "IntCode") & "', '" & mView.GetRowCellValue(i, "InsCrossRef").ToString.Replace("'", "''") & "', '" & mView.GetRowCellValue(i, "InsEditor").ToString.Replace("'", "''") & "', '" & mView.GetRowCellValue(i, "InsDocument").ToString.Replace("'", "''") & "', " & strDateIssue & ", '" & mView.GetRowCellValue(i, "InsDesc").ToString.Replace("'", "''") & "','" & GetUserName() & "'," & IIf(mView.GetRowCellValue(i, "HasImage"), 1, 0) & ")")
                    Else
                        sqls.Add("Update dbo.tblAdmMaintenance set WorkCode='" & mView.GetRowCellValue(i, "WorkCode") & "',RankCode='" & mView.GetRowCellValue(i, "RankCode") & "',Number=" & IfNull(mView.GetRowCellValue(i, "Number"), "NULL") & ",IntCode='" & mView.GetRowCellValue(i, "IntCode") & "',InsCrossRef='" & mView.GetRowCellValue(i, "InsCrossRef").ToString.Replace("'", "''") & "',InsEditor='" & mView.GetRowCellValue(i, "InsEditor").ToString.Replace("'", "''") & "',InsDocument='" & mView.GetRowCellValue(i, "InsDocument").ToString.Replace("'", "''") & "',InsDateIssue=" & strDateIssue & ",InsDesc='" & mView.GetRowCellValue(i, "InsDesc").ToString.Replace("'", "''") & "', LastUpdatedBy='" & GetUserName() & "', DateUpdated=GETDATE(), HasImage=" & IIf(mView.GetRowCellValue(i, "HasImage"), 1, 0) & " Where MaintenanceCode='" & mView.GetRowCellValue(i, "MaintenanceCode") & "'")
                    End If

                    If IfNull(mView.GetRowCellValue(i, "DeletedImages"), "") <> "" Then
                        Dim strDeletedID() As String = mView.GetRowCellValue(i, "DeletedImages").ToString.Split(";"c), strDocID As String
                        For Each strDocID In strDeletedID
                            sqls.Add("DELETE FROM dbo.tblDocuments WHERE DocID=" & strDocID)
                        Next
                    End If

                    If IfNull(mView.GetRowCellValue(i, "AddedImages"), "") <> "" Then
                        Dim strImages() As String = mView.GetRowCellValue(i, "AddedImages").ToString.Split(";"c), strImg As String
                        For Each strImg In strImages
                            sqls.Add("INSERT INTO dbo.tblDocuments(RefID, DocType, FileName, Doc) VALUES([dbo].[GETMAINTENANCECODE]('" & mView.GetRowCellValue(i, "WorkCode") & "','" & strID & "'),'ADMWORK', '" & strImg & "','" & ImageToString(New Bitmap(strImg)) & "')")
                        Next
                    End If
                End If
            Next

            ''''''''''''PARTS'''''''''''
            pView.CloseEditor()
            pView.UpdateCurrentRow()
            For i = 0 To pView.RowCount - 1
                If pView.GetRowCellValue(i, "pEdited") Then
                    If pView.GetRowCellValue(i, "PartCode") Is System.DBNull.Value Then
                        strPartID = GenerateID(DB, "PartCode", "tblAdmPart")
                        sqls.Add("INSERT INTO [dbo].[tblAdmPart]([PartCode],[Name],[PartNumber],[LastUpdatedBy]) " & _
                                 "Values('" & strPartID & "', '" & pView.GetRowCellValue(i, "Part") & "','" & pView.GetRowCellValue(i, "PartNumber").ToString & "','" & GetUserName() & "')")
                        pView.SetRowCellValue(i, "PartCode", strPartID)
                    Else
                        sqls.Add("Update dbo.tblAdmPart set [Name]='" & pView.GetRowCellValue(i, "Part") & "',[PartNumber]='" & pView.GetRowCellValue(i, "PartNumber") & "', LastUpdatedBy='" & GetUserName() & "' Where PartCode='" & pView.GetRowCellValue(i, "PartCode") & "'")
                    End If
                    pView.SetRowCellValue(i, "pEdited", False)
                    pView.RefreshRow(i)
                    sqls.Add("EXEC dbo.INSERTUNITPART @strUnitCode='" & strID & "',@strPartCode='" & pView.GetRowCellValue(i, "PartCode") & "', @bSelected=" & IIf(pView.GetRowCellValue(i, "pSelected"), 1, 0))
                End If
            Next

            ''''''''''''COUNTER''''''''''''''''
            cView.CloseEditor()
            cView.UpdateCurrentRow()
            For i = 0 To cView.RowCount - 1
                If cView.GetRowCellValue(i, "cEdited") Then
                    strCounterCode = GenerateID(DB, "CounterCode", "tblAdmCounter")
                    sqls.Add("Insert Into dbo.tblAdmCounter([CounterCode],[Name],[UnitCode],[LastUpdatedBy],[SortCode]) Values('" & strCounterCode & "','" & cView.GetRowCellValue(i, "Counter").ToString.Replace("'", "''") & "','" & strID & "','" & GetUserName() & "',100)")
                End If
            Next

            DB.RunSqls(sqls)

            If bRefreshMaintenance Then
                mGrid.DataSource = DB.CreateTable("SELECT *,CAST(0 AS BIT) mEdited, '' AddedImages,'' DeletedImages, CAST(0 AS BIT) HasImage  FROM dbo.MAINTENANCELIST WHERE UnitCode='" & strID & "'")
                mGrid.RefreshDataSource()
                bRefreshMaintenance = False
            End If
            If bRefreshCounter Then
                'nNode.SetValue("RunningHours", nRunningHours)
                cGrid.DataSource = DB.CreateTable("SELECT *, CAST(0 AS BIT) cEdited FROM dbo.COUNTERLATESTREADING WHERE UnitCode='" & strID & "' ORDER BY ReadingDate Desc")
                bRefreshCounter = False
            End If
            If bRefreshParts Then
                pGrid.DataSource = DB.CreateTable("SELECT p.PartCode, Name Part, PartNumber, CAST(0 AS BIT) pEdited, CAST(CASE WHEN up.PartCode IS NULL THEN 0 ELSE 1 END AS BIT) pSelected FROM dbo.tblAdmPart p LEFT JOIN (SELECT PartCode FROM [dbo].[tblUnitPart] WHERE UnitCode='" & strID & "') up ON p.PartCode=up.PartCode ORDER BY CASE WHEN up.PartCode IS NULL THEN 1 ELSE 0 END, p.Name")
                bRefreshParts = False
            End If
            bRecordUpdated = False

            RemoveHandler tlUnits.FocusedNodeChanged, AddressOf tlUnits_FocusedNodeChanged
            RemoveHandler tlUnits.CellValueChanging, AddressOf tlUnits_CellValueChanging
            If txtUnitDesc.Tag = 1 Then nNode.SetValue("UnitDesc", txtUnitDesc.EditValue)
            If cboDeptCode.Tag = 1 Then nNode.SetValue("DeptCode", cboDeptCode.EditValue)
            If cboLocCode.Tag = 1 Then nNode.SetValue("LocCode", cboLocCode.EditValue)
            If cboCatCode.Tag = 1 Then nNode.SetValue("CatCode", cboCatCode.EditValue)
            If cboMakerCode.Tag = 1 Then nNode.SetValue("MakerCode", cboMakerCode.EditValue)
            If cboVendorCode.Tag = 1 Then nNode.SetValue("VendorCode", cboVendorCode.EditValue)
            If txtType.Tag = 1 Then nNode.SetValue("Type", txtType.EditValue)
            If txtModel.Tag = 1 Then nNode.SetValue("Model", txtModel.EditValue)
            If txtRefNo.Tag = 1 Then nNode.SetValue("RefNo", txtRefNo.EditValue)
            If txtSerialNumber.Tag = 1 Then nNode.SetValue("SerialNumber", txtSerialNumber.EditValue)
            If chkCritical.Tag = 1 Then nNode.SetValue("Critical", chkCritical.Checked)
            If chkActive.Tag = 1 Then nNode.SetValue("Active", chkActive.Checked)
            tlUnits.RefreshNode(nNode)
            AddHandler tlUnits.FocusedNodeChanged, AddressOf tlUnits_FocusedNodeChanged
            AddHandler tlUnits.CellValueChanging, AddressOf tlUnits_CellValueChanging
            bbiPaste.Enabled = (bPermission And 16) > 0
            bbiImport.Enabled = (bPermission And 16) > 0
            ClearFields(gUnitInfo, True)
            'RefreshData()
        End If
    End Sub

    Public Overrides Sub RefreshData()
        strRequiredFields = "txtUnitDesc"
        If Not bLoaded Then
            Mainpanel2.Panel2.AutoScrollPosition = New Point(0, 0)
            SetSaveCaption(Name, "Save")
            SetDeleteCaption(Name, "Delete")
            'Show editing buttons if the user has a permission.
            SetAddVisibility(Name, IIf((bPermission And 2) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never))
            SetSaveVisibility(Name, IIf((bPermission And 4) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never))
            SetDeleteVisibility(Name, IIf((bPermission And 8) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never))
            MainGrid.DataSource = DB.CreateTable("SELECT * FROM dbo.COMPONENTLIST")
            cboLocCode.Properties.DataSource = DB.CreateTable("SELECT * FROM dbo.LOCATIONLIST")
            WorkEdit.DataSource = DB.CreateTable("SELECT * FROM dbo.ADMINWORKLIST WHERE LEFT(WorkCode,3)<>'SYS' ORDER BY Maintenance")
            cboCatCode.Properties.DataSource = DB.CreateTable("SELECT * FROM dbo.CATEGORYLIST")
            cboDeptCode.Properties.DataSource = DB.CreateTable("SELECT * FROM dbo.DEPARTMENTLIST")
            cboMakerCode.Properties.DataSource = DB.CreateTable("SELECT MakerCode, Name Maker FROM dbo.tblAdmMaker")
            cboVendorCode.Properties.DataSource = DB.CreateTable("SELECT VendorCode, Name Vendor FROM dbo.tblAdmVendor")
            IntEdit.DataSource = DB.CreateTable("SELECT * FROM INTERVALLIST")
            RankEdit.DataSource = AdmRank
            AllowDeletion(Name, (bPermission And 8) > 0)
            bLoaded = True
        End If
        If (bPermission And 4) = 0 Then
            RemoveEditListener(Me.gUnitInfo)
        End If
        bbiPaste.Enabled = (bPermission And 16) > 0
        bbiImport.Enabled = (bPermission And 16) > 0
        getUnitsData()
        bRecordUpdated = False
        AllowSaving(Name, False)
        AllowDeletion(Name, (tblUnitSource.Rows.Count > 0 And (bPermission And 8) > 0))
        bRecordUpdated = False
        bLoaded = True
    End Sub

    'Overriden From Base Control
    Public Overrides Function GetDesc() As String
        Return "Unit - " & strDesc
    End Function

    Sub getUnitsData(Optional bHideComponents As Boolean = True)
        Dim strFocusedNode As String = "", strRootNode As String = ""
        If Not tlUnits.FocusedNode Is Nothing Then
            strFocusedNode = tlUnits.FocusedNode.GetValue("UnitCode")
        End If

        tblUnitSource = DB.CreateTable("EXEC dbo.GETUNITS @strUnitCode='" & CURRENT_MAINUNIT & "',@strDeptCode='" & CURRENT_DEPARTMENT & "',@strCatCode='" & CURRENT_CATEGORY & "'" & ",@bCritical=" & IIf(CURRENT_CRITICAL_CHECKED, 1, 0))
        If Not (CURRENT_MAINUNIT = "" Or CURRENT_MAINUNIT = "EMPTY") Then strFocusedNode = CURRENT_MAINUNIT

        Me.tlUnits.DataSource = tblUnitSource

        If strFocusedNode <> "" Then
            Dim nNode As TreeListNode = tlUnits.FindNodeByFieldValue("UnitCode", strFocusedNode)
            If Not nNode Is Nothing Then
                strRootNode = GetRootNode(nNode).GetValue("UnitCode")
                tlUnits.FindNodeByFieldValue("UnitCode", strRootNode).ExpandAll()
                tlUnits.SetFocusedNode(nNode)
            End If
        End If

        Editable()

        nMaxUnitID = DB.DLookUp("ISNULL(MAX(CAST(right(UnitCode,8) AS INT)),0)", "dbo.tblAdmUnit", "0")

        If tblUnitSource.Rows.Count = 0 Then
            MainPanel.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both
            RaiseCustomEvent(Name, New Object() {"ShowComponent", "True"})
        ElseIf bHideComponents Then
            If CURRENT_MAINUNIT = "EMPTY" Then
                MainPanel.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both
                RaiseCustomEvent(Name, New Object() {"ShowComponent", "True"})
            Else
                MainPanel.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2
                RaiseCustomEvent(Name, New Object() {"ShowComponent", "False"})
            End If

        End If
    End Sub

    Public Overrides Sub ExecCustomFunction(ByVal param() As Object)
        Select Case param(0)
            Case "ShowComponent"
                If CBool(param(1)) Then
                    MainPanel.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both
                Else
                    MainPanel.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2
                End If
            Case "CopyMaintenance"
                CopyMaintenance()
            Case "Copy"
                Copy()
            Case "Preview"
                If tlUnits.FocusedNode Is Nothing Then
                    MsgBox("Please select at least one record to preview.", MsgBoxStyle.Information, GetAppName)
                Else
                    RaiseCustomEvent(Name, New Object() {"Preview", "COMPONENTREP", "PMSReports", "|" & tlUnits.FocusedNode.GetValue("UnitCode") & "|"})
                End If
        End Select
    End Sub

    Function GetMaxNumber(en As IEnumerator, strCompCode As String) As Integer
        Dim nRetVal As Integer = 0, nNode As TreeListNode
        While en.MoveNext
            nNode = CType(en.Current, TreeListNode)
            If strCompCode = nNode.GetValue("ComponentCode") Then
                If nRetVal < IfNull(nNode.GetValue("UnitNumber"), 0) Then nRetVal = nNode.GetValue("UnitNumber")
            End If
        End While
        Return nRetVal + 1
    End Function

    Sub CopyMaintenance()
        Dim nNode As TreeListNode = tlUnits.FocusedNode
        If Not nNode Is Nothing Then
            Dim frm As New frmCopyMaintenance
            frm.strUnitCode = nNode.GetValue("UnitCode")
            frm.gMaintenance.Text = nNode.GetValue("Component") & " - Maintenance"
            frm.mGrid.DataSource = DB.CreateTable("SELECT * FROM dbo.MAINTENANCEINTERVALLIST WHERE UnitCode='" & nNode.GetValue("UnitCode") & "'")
            frm.MainGrid.DataSource = DB.CreateTable("SELECT UnitCode, UnitDesc, CAST(0 AS BIT) Selected FROM dbo.UNITCOMPLIST WHERE ComponentCode='" & nNode.GetValue("ComponentCode") & "' AND UnitCode<>'" & nNode.GetValue("UnitCode") & "'")
            frm.ShowDialog()
            If frm.UpdateSQL <> "" Then
                DB.RunSql(frm.UpdateSQL)
            End If
        End If
    End Sub

    Sub UpdateCriticalParent(pNode As TreeListNode)
        Dim nNode As TreeListNode, en As IEnumerator = pNode.Nodes.GetEnumerator(), bHasCritical As Boolean = False
        While en.MoveNext
            nNode = CType(en.Current, TreeListNode)
            If nNode.GetValue("Critical") Or nNode.GetValue("HasCritical") Then bHasCritical = True
        End While
        pNode.SetValue("HasCritical", bHasCritical)
        sqls.Add("UPDATE dbo.tblAdmUnit SET HasCritical=" & IIf(bHasCritical, 1, 0) & " WHERE UnitCode='" & pNode.GetValue("UnitCode") & "'")
        If Not pNode.ParentNode Is Nothing Then
            UpdateCriticalParent(pNode.ParentNode)
        End If
    End Sub

    Sub UpdateActiveParent(pNode As TreeListNode)
        Dim nNode As TreeListNode, en As IEnumerator = pNode.Nodes.GetEnumerator(), bHasInactive As Boolean = False
        While en.MoveNext
            nNode = CType(en.Current, TreeListNode)
            If Not nNode.GetValue("Active") Or nNode.GetValue("HasInactive") Then bHasInactive = True
        End While
        pNode.SetValue("HasInactive", bHasInactive)
        sqls.Add("UPDATE dbo.tblAdmUnit SET HasInactive=" & IIf(bHasInactive, 1, 0) & " WHERE UnitCode='" & pNode.GetValue("UnitCode") & "'")
        If Not pNode.ParentNode Is Nothing Then
            UpdateActiveParent(pNode.ParentNode)
        End If
    End Sub

    Sub UpdateActiveChild(pNode As TreeListNode, bActive As Boolean)
        If pNode.HasChildren Then
            Dim nNode As TreeListNode, en As IEnumerator = pNode.Nodes.GetEnumerator()
            While en.MoveNext
                nNode = CType(en.Current, TreeListNode)
                nNode.SetValue("Active", bActive)
                nNode.SetValue("HasInactive", Not bActive)
                sqls.Add("UPDATE dbo.tblAdmUnit SET HasInactive=" & IIf(bActive, 0, 1) & ", Active=" & IIf(bActive, 1, 0) & " WHERE UnitCode='" & nNode.GetValue("UnitCode") & "'")
                UpdateActiveChild(nNode, bActive)
            End While
        End If
    End Sub

    Sub Copy()
        Dim frm As New frmNumber, nStartNumber As Integer, nMaxUnitID As Integer = DB.DLookUp("ISNULL(MAX(CAST(right(UnitCode,8) AS INT)),0)", "dbo.tblAdmUnit", "0"), bRootUpdated As Boolean = False
        If tlUnits.FocusedNode.ParentNode Is Nothing Then
            nStartNumber = GetMaxNumber(tlUnits.Nodes.GetEnumerator, tlUnits.FocusedNode.GetValue("ComponentCode"))
            bRootUpdated = True
        Else
            nStartNumber = GetMaxNumber(tlUnits.FocusedNode.ParentNode.Nodes.GetEnumerator, tlUnits.FocusedNode.GetValue("ComponentCode"))
        End If
        frm.txtNumber.Properties.MinValue = nStartNumber
        frm.ShowDialog()
        If frm.bCopied Then
            Dim nRow As DataRow, i As Integer
            sqls.Clear()
            tblUnitCopy = tblUnitSource.Clone
            For i = nStartNumber To frm.txtNumber.EditValue
                tblUnitCopy.Rows.Clear()
                CopyNodes(tlUnits.FocusedNode, tlUnits.FocusedNode.GetValue("ParentCode"), i, nMaxUnitID)
                For Each nRow In tblUnitCopy.Rows
                    tblUnitSource.ImportRow(nRow)
                Next
            Next
        End If
        DB.RunSqls(sqls)
        If bRootUpdated Then RaiseCustomEvent(Name, New Object() {"RefreshMainUnits", ""})
    End Sub

    Sub CopyNodes(pNode As TreeListNode, Parent As Object, nNumber As Integer, ByRef nMaxUnitID As Integer)
        Dim rowNew As DataRow, en As IEnumerator = pNode.Nodes.GetEnumerator(), strParent As String, strLoc As String = "NULL", strDept As String = "NULL", strCat As String = "NULL", strMaker As String = "NULL", strVendor As String = "NULL"
        nMaxUnitID += 1
        rowNew = tblUnitCopy.NewRow
        rowNew("UnitCode") = IMO_NUMBER & nMaxUnitID.ToString("00000000")
        rowNew("ParentCode") = Parent
        If nNumber > 0 Then
            rowNew("UnitNumber") = nNumber
        Else
            rowNew("UnitNumber") = pNode.GetValue("UnitNumber")
        End If
        rowNew("ComponentCode") = pNode.GetValue("ComponentCode")
        rowNew("Component") = pNode.GetValue("Component")
        rowNew("UnitDesc") = pNode.GetValue("Component") & " " & rowNew("UnitNumber")
        rowNew("Type") = IfNull(pNode.GetValue("Type"), "")
        rowNew("Model") = IfNull(pNode.GetValue("Model"), "")
        rowNew("RefNo") = IfNull(pNode.GetValue("RefNo"), "")
        rowNew("Critical") = IfNull(pNode.GetValue("Critical"), False)

        If Parent Is System.DBNull.Value Then
            strParent = "NULL"
        Else
            strParent = "'" & Parent & "'"
        End If
        If pNode.GetValue("LocCode") Is System.DBNull.Value Then
            strLoc = "NULL"
        Else
            strLoc = "'" & pNode.GetValue("LocCode") & "'"
            rowNew("LocCode") = pNode.GetValue("LocCode")
        End If
        If pNode.GetValue("CatCode") Is System.DBNull.Value Then
            strCat = "NULL"
        Else
            strCat = "'" & pNode.GetValue("CatCode") & "'"
            rowNew("CatCode") = pNode.GetValue("CatCode")
        End If
        If pNode.GetValue("DeptCode") Is System.DBNull.Value Then
            strDept = "NULL"
        Else
            strDept = "'" & pNode.GetValue("DeptCode") & "'"
            rowNew("DeptCode") = pNode.GetValue("DeptCode")
        End If
        If pNode.GetValue("MakerCode") Is System.DBNull.Value Then
            strMaker = "NULL"
        Else
            strMaker = "'" & pNode.GetValue("MakerCode") & "'"
            rowNew("MakerCode") = pNode.GetValue("MakerCode")
        End If
        If pNode.GetValue("VendorCode") Is System.DBNull.Value Then
            strVendor = "NULL"
        Else
            strVendor = "'" & pNode.GetValue("VendorCode") & "'"
            rowNew("VendorCode") = pNode.GetValue("VendorCode")
        End If
        sqls.Add("[dbo].[COPYUNIT] @OldUnitCode='" & pNode.GetValue("UnitCode") & "', @NewUnitCode='" & rowNew("UnitCode") & "', @ParentCode=" & strParent & ", @ComponentCode='" & rowNew("ComponentCode") & "', @UnitNumber=" & rowNew("UnitNumber") & ", @UnitDesc='" & rowNew("UnitDesc") & "', @LastUpdatedBy='" & GetUserName() & "', @LocCode=" & strLoc & ", @CatCode=" & strCat & ", @DeptCode=" & strDept & ", @MakerCode=" & strMaker & ", @Type='" & rowNew("Type") & "', @Model='" & rowNew("Model") & "', @RefNo='" & rowNew("RefNo") & "', @VendorCode=" & strVendor & ", @Critical=" & IIf(rowNew("Critical"), 1, 0))
        tblUnitCopy.Rows.Add(rowNew)
        While en.MoveNext
            CopyNodes(CType(en.Current, TreeListNode), rowNew("UnitCode"), -1, nMaxUnitID)
        End While
    End Sub

    Sub SetChildNodesValue(xrow() As DataRow, strColumn As String, objValue As Object)
        Dim i As Integer
        For i = 0 To xrow.Length - 1
            Dim crow() As DataRow = tblUnitSource.Select("ParentCode='" & xrow(i)("UnitCode") & "'")
            xrow(i)(strColumn) = objValue
            xrow(i)("Edited") = 1
            If crow.Length > 0 Then
                SetChildNodesValue(crow, strColumn, objValue)
            End If
        Next
    End Sub

    Sub CreateDeleteSQLs(xrow() As DataRow)
        Dim i As Integer
        For i = 0 To xrow.Length - 1
            Dim crow() As DataRow = tblUnitSource.Select("ParentCode='" & xrow(i)("UnitCode") & "'")
            sqls.Add("DELETE FROM dbo.tblAdmUnit WHERE UnitCode='" & xrow(i)("UnitCode") & "'")
            If crow.Length > 0 Then
                CreateDeleteSQLs(crow)
            End If
        Next
    End Sub

    Function GetRootNode(nNode As TreeListNode) As TreeListNode
        If nNode.ParentNode Is Nothing Then
            Return nNode
        Else
            Return GetRootNode(nNode.ParentNode)
        End If
    End Function

    Function GetUnitFullName(nNode As TreeListNode) As String
        Dim strRetVal As String = nNode.GetValue("UnitDesc")
        If nNode.ParentNode Is Nothing Then
            Return strRetVal
        Else
            Return GetUnitFullName(nNode.ParentNode) & " -> " & strRetVal
        End If
    End Function

#End Region

    Private Sub cboCatCode_ProcessNewValue(sender As Object, e As DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs) Handles cboCatCode.ProcessNewValue
        Dim row As DataRow, tbl As DataTable, strCatCode As String = GenerateID(DB, "CatCode", "tblAdmCategory")
        tbl = cboCatCode.Properties.DataSource
        If IfNull(e.DisplayValue, "") = "" Then Exit Sub
        row = tbl.NewRow
        DB.RunSql("INSERT INTO dbo.tblAdmCategory(CatCode, Name, LastUpdatedBy) VALUES('" & strCatCode & "', '" & e.DisplayValue & "','" & GetUserName() & "')")
        row("CatCode") = strCatCode
        row("Category") = e.DisplayValue
        tbl.Rows.Add(row)
        e.Handled = True
        AllowSaving(Name, (bPermission And 4) > 0)
        bRecordUpdated = True
    End Sub

    Private Sub cboMakerCode_ProcessNewValue(sender As Object, e As DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs) Handles cboMakerCode.ProcessNewValue
        Dim row As DataRow, tbl As DataTable, strMakerCode As String = GenerateID(DB, "MakerCode", "tblAdmMaker")
        tbl = cboMakerCode.Properties.DataSource
        If IfNull(e.DisplayValue, "") = "" Then Exit Sub
        row = tbl.NewRow
        DB.RunSql("INSERT INTO dbo.tblAdmMaker(MakerCode, Name, LastUpdatedBy) VALUES('" & strMakerCode & "', '" & e.DisplayValue & "','" & GetUserName() & "')")
        row("MakerCode") = strMakerCode
        row("Maker") = e.DisplayValue
        tbl.Rows.Add(row)
        e.Handled = True
        AllowSaving(Name, (bPermission And 4) > 0)
        bRecordUpdated = True
    End Sub

    Private Sub cboVendorCode_ProcessNewValue(sender As Object, e As DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs) Handles cboVendorCode.ProcessNewValue
        Dim row As DataRow, tbl As DataTable, strVendorCode As String = GenerateID(DB, "VendorCode", "tblAdmVendor")
        tbl = cboVendorCode.Properties.DataSource
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

    'Private Sub bbiPaste_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPaste.ItemClick
    '    If strCurrView = "Component" Then
    '        Dim nRow() As DataRow = ImportFromClipboard("Component", ""), crow As DataRow
    '        If Not nRow Is Nothing Then
    '            For Each crow In nRow
    '                Dim strComponentCode = GenerateID(DB, "ComponentCode", "tblAdmComponent")
    '                DB.RunSql("INSERT INTO dbo.tblAdmComponent(ComponentCode, Name, LastUpdatedBy) VALUES('" & strComponentCode & "', '" & crow("Component").ToString.Replace("'", "''") & "','" & GetUserName() & "')")
    '                MainView.AddNewRow()
    '                MainView.SetRowCellValue(MainView.FocusedRowHandle, "ComponentCode", strComponentCode)
    '                MainView.SetRowCellValue(MainView.FocusedRowHandle, "Component", crow("Component"))
    '            Next
    '            MainView.UpdateCurrentRow()
    '            MainView.CloseEditor()
    '        End If
    '    End If
    'End Sub

    Private Sub bbiImport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiImport.ItemClick, bbiPaste.ItemClick
        Dim nRow() As DataRow, crow As DataRow
        If strCurrView = "Component" Then
            If e.Item.Name = "bbiPaste" Then
                nRow = ImportFromClipboard("Component", "")
            Else
                nRow = ImportFromFile("Component", "")
            End If
            If Not nRow Is Nothing Then
                For Each crow In nRow
                    Dim bExist As Boolean = True, strValue As String = crow("Component")
                    Dim strCode As String = PasteAdminData(DB, "ComponentCode", "tblAdmComponent", strValue, bExist)
                    If Not bExist Then
                        MainView.AddNewRow()
                        MainView.SetRowCellValue(MainView.FocusedRowHandle, "ComponentCode", strCode)
                        MainView.SetRowCellValue(MainView.FocusedRowHandle, "Component", strValue)
                        MainView.UpdateCurrentRow()
                        MainView.CloseEditor()
                    End If
                Next
            End If
        ElseIf strCurrView = "Part" Then
            If e.Item.Name = "bbiPaste" Then
                nRow = ImportFromClipboard("Part", "PartNumber")
            Else
                nRow = ImportFromFile("Part", "PartNumber")
            End If
            If Not nRow Is Nothing Then
                For Each crow In nRow
                    Dim bExist As Boolean = True, strValue As String = crow("Part"), strPartNumber As String = crow("PartNumber")
                    Dim strCode As String = PastePartData(DB, "PartCode", "tblAdmPart", strValue, strPartNumber, bExist)
                    If Not bExist Then
                        pView.AddNewRow()
                        pView.SetRowCellValue(pView.FocusedRowHandle, "PartCode", strCode)
                        pView.SetRowCellValue(pView.FocusedRowHandle, "Part", strValue)
                        pView.SetRowCellValue(pView.FocusedRowHandle, "PartNumber", strPartNumber)
                        pView.UpdateCurrentRow()
                        pView.CloseEditor()
                    End If
                Next
            End If
        ElseIf strCurrView = "Maintenance" Then
            Dim sqls As New ArrayList
            If e.Item.Name = "bbiPaste" Then
                nRow = ImportFromClipboard("Maintenance", "")
            Else
                nRow = ImportFromFile("Maintenance", "")
            End If
            If Not nRow Is Nothing Then
                For Each crow In nRow
                    Dim bExist As Boolean = True, strValue As String = crow("Maintenance")
                    Dim strCode As String = PasteAdminData(DB, "WorkCode", "tblAdmWork", strValue, bExist)
                    sqls.Add("INSERT INTO dbo.tblAdmMaintenance(MaintenanceCode, WorkCode, UnitCode, LastUpdatedBy) VALUES(dbo.MAINTENANCEID(),'" & strCode & "', '" & strID & "', '" & GetUserName() & "')")
                    'If Not bExist Then
                    '    MainView.AddNewRow()
                    '    MainView.SetRowCellValue(MainView.FocusedRowHandle, "WorkCode", strCode)
                    '    MainView.SetRowCellValue(MainView.FocusedRowHandle, "Maintenance", strValue)
                    '    MainView.UpdateCurrentRow()
                    '    MainView.CloseEditor()
                    'End If
                Next
                DB.RunSqls(sqls)
                mGrid.DataSource = DB.CreateTable("SELECT *,CAST(0 AS BIT) mEdited FROM dbo.MAINTENANCELIST WHERE UnitCode='" & strID & "'")
                mGrid.RefreshDataSource()
                WorkEdit.DataSource = DB.CreateTable("SELECT * FROM dbo.ADMINWORKLIST WHERE LEFT(WorkCode,3)<>'SYS' ORDER BY Maintenance")
                bRefreshMaintenance = False
            End If
        End If
    End Sub


End Class
