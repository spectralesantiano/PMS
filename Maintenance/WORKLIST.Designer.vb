<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WORKLIST
    Inherits BaseControl.BaseList

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tlMain = New DevExpress.XtraTreeList.TreeList()
        Me.treeListBand1 = New DevExpress.XtraTreeList.Columns.TreeListBand()
        Me.colUnitDesc = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colComponentCode = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.Description = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colUnitCode = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colDeptCode = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colCatCode = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colHoursPerDay = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.LocEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.StatusEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        CType(Me.tlMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LocEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlMain
        '
        Me.tlMain.Appearance.BandPanel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tlMain.Appearance.BandPanel.Options.UseFont = True
        Me.tlMain.Bands.AddRange(New DevExpress.XtraTreeList.Columns.TreeListBand() {Me.treeListBand1})
        Me.tlMain.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.colComponentCode, Me.colUnitDesc, Me.Description, Me.colUnitCode, Me.colDeptCode, Me.colCatCode, Me.colHoursPerDay})
        Me.tlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlMain.KeyFieldName = "UnitCode"
        Me.tlMain.Location = New System.Drawing.Point(0, 0)
        Me.tlMain.Name = "tlMain"
        Me.tlMain.OptionsFilter.AllowColumnMRUFilterList = False
        Me.tlMain.OptionsFilter.AllowFilterEditor = False
        Me.tlMain.OptionsFilter.AllowMRUFilterList = False
        Me.tlMain.OptionsFilter.FilterMode = DevExpress.XtraTreeList.FilterMode.Extended
        Me.tlMain.OptionsFilter.ShowAllValuesInCheckedFilterPopup = False
        Me.tlMain.OptionsFind.AllowFindPanel = True
        Me.tlMain.OptionsFind.AlwaysVisible = True
        Me.tlMain.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFullFocus
        Me.tlMain.OptionsView.ShowFilterPanelMode = DevExpress.XtraTreeList.ShowFilterPanelMode.Never
        Me.tlMain.ParentFieldName = "ParentCode"
        Me.tlMain.PreviewFieldName = "UnitDesc"
        Me.tlMain.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.LocEdit, Me.StatusEdit})
        Me.tlMain.RootValue = Nothing
        Me.tlMain.Size = New System.Drawing.Size(449, 323)
        Me.tlMain.TabIndex = 1
        Me.tlMain.TreeLevelWidth = 20
        Me.tlMain.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.Solid
        '
        'treeListBand1
        '
        Me.treeListBand1.Caption = "Machines & Equipments"
        Me.treeListBand1.Columns.Add(Me.colUnitDesc)
        Me.treeListBand1.MinWidth = 33
        Me.treeListBand1.Name = "treeListBand1"
        '
        'colUnitDesc
        '
        Me.colUnitDesc.Caption = "Description"
        Me.colUnitDesc.FieldName = "UnitDesc"
        Me.colUnitDesc.MinWidth = 180
        Me.colUnitDesc.Name = "colUnitDesc"
        Me.colUnitDesc.OptionsColumn.AllowEdit = False
        Me.colUnitDesc.OptionsColumn.ReadOnly = True
        Me.colUnitDesc.SortOrder = System.Windows.Forms.SortOrder.Ascending
        Me.colUnitDesc.UnboundExpression = "[Component] + ' ' + [UnitNumber]"
        Me.colUnitDesc.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.[String]
        Me.colUnitDesc.Visible = True
        Me.colUnitDesc.VisibleIndex = 0
        Me.colUnitDesc.Width = 281
        '
        'colComponentCode
        '
        Me.colComponentCode.Caption = "ComponentCode"
        Me.colComponentCode.FieldName = "ComponentCode"
        Me.colComponentCode.Name = "colComponentCode"
        '
        'Description
        '
        Me.Description.Caption = "Description"
        Me.Description.FieldName = "Description"
        Me.Description.Name = "Description"
        '
        'colUnitCode
        '
        Me.colUnitCode.Caption = "UnitCode"
        Me.colUnitCode.FieldName = "UnitCode"
        Me.colUnitCode.Name = "colUnitCode"
        '
        'colDeptCode
        '
        Me.colDeptCode.Caption = "DeptCode"
        Me.colDeptCode.FieldName = "DeptCode"
        Me.colDeptCode.Name = "colDeptCode"
        '
        'colCatCode
        '
        Me.colCatCode.Caption = "CatCode"
        Me.colCatCode.FieldName = "CatCode"
        Me.colCatCode.Name = "colCatCode"
        '
        'colHoursPerDay
        '
        Me.colHoursPerDay.Caption = "HoursPerDay"
        Me.colHoursPerDay.FieldName = "HoursPerDay"
        Me.colHoursPerDay.Name = "colHoursPerDay"
        '
        'LocEdit
        '
        Me.LocEdit.AutoHeight = False
        Me.LocEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LocEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocName", "Name1"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocCode", "LocCode", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.LocEdit.DisplayMember = "LocName"
        Me.LocEdit.DropDownRows = 10
        Me.LocEdit.Name = "LocEdit"
        Me.LocEdit.NullText = ""
        Me.LocEdit.ShowFooter = False
        Me.LocEdit.ShowHeader = False
        Me.LocEdit.ValueMember = "LocCode"
        '
        'StatusEdit
        '
        Me.StatusEdit.AutoHeight = False
        Me.StatusEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.StatusEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Status", "Status"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("StatCode", "StatCode", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.StatusEdit.DisplayMember = "Status"
        Me.StatusEdit.DropDownRows = 2
        Me.StatusEdit.Name = "StatusEdit"
        Me.StatusEdit.NullText = ""
        Me.StatusEdit.ShowFooter = False
        Me.StatusEdit.ShowHeader = False
        Me.StatusEdit.ValueMember = "StatCode"
        '
        'WORKLIST
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.tlMain)
        Me.Name = "WORKLIST"
        Me.Size = New System.Drawing.Size(449, 323)
        CType(Me.tlMain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LocEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlMain As DevExpress.XtraTreeList.TreeList
    Friend WithEvents treeListBand1 As DevExpress.XtraTreeList.Columns.TreeListBand
    Friend WithEvents colUnitDesc As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colComponentCode As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents LocEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents StatusEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colUnitCode As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colDeptCode As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colCatCode As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents Description As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colHoursPerDay As DevExpress.XtraTreeList.Columns.TreeListColumn

End Class
