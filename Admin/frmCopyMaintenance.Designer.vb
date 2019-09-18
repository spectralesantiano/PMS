<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCopyMaintenance
    Inherits DevExpress.XtraEditors.XtraForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCopyMaintenance))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.cmdSave = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.gDetails = New DevExpress.XtraEditors.GroupControl()
        Me.MainGrid = New DevExpress.XtraGrid.GridControl()
        Me.MainView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.UnitCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UnitDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Selected = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DeleteEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.RankEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.gMaintenance = New DevExpress.XtraEditors.GroupControl()
        Me.mGrid = New DevExpress.XtraGrid.GridControl()
        Me.mView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.WorkDescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Interval = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Abbrv = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmdDeselect = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdSelectAll = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.gDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gDetails.SuspendLayout()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DeleteEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RankEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gMaintenance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gMaintenance.SuspendLayout()
        CType(Me.mGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(338, 467)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(69, 23)
        Me.cmdSave.TabIndex = 4
        Me.cmdSave.Text = "Save"
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(424, 467)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(69, 23)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.Text = "Cancel"
        '
        'gDetails
        '
        Me.gDetails.Controls.Add(Me.MainGrid)
        Me.gDetails.Location = New System.Drawing.Point(17, 178)
        Me.gDetails.Name = "gDetails"
        Me.gDetails.Size = New System.Drawing.Size(476, 281)
        Me.gDetails.TabIndex = 0
        Me.gDetails.Text = "Above maintenance will be applied to selected Components below:"
        '
        'MainGrid
        '
        Me.MainGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainGrid.Location = New System.Drawing.Point(2, 23)
        Me.MainGrid.LookAndFeel.SkinName = "iMaginary"
        Me.MainGrid.MainView = Me.MainView
        Me.MainGrid.Name = "MainGrid"
        Me.MainGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.DeleteEdit, Me.RankEdit})
        Me.MainGrid.Size = New System.Drawing.Size(472, 256)
        Me.MainGrid.TabIndex = 38
        Me.MainGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MainView})
        '
        'MainView
        '
        Me.MainView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.MainView.Appearance.RowSeparator.Options.UseBackColor = True
        Me.MainView.Appearance.ViewCaption.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.MainView.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Black
        Me.MainView.Appearance.ViewCaption.Options.UseFont = True
        Me.MainView.Appearance.ViewCaption.Options.UseForeColor = True
        Me.MainView.Appearance.ViewCaption.Options.UseTextOptions = True
        Me.MainView.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.MainView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.MainView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.UnitCode, Me.UnitDesc, Me.Selected})
        Me.MainView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.MainView.GridControl = Me.MainGrid
        Me.MainView.Name = "MainView"
        Me.MainView.NewItemRowText = "Click here to add new record"
        Me.MainView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.MainView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.MainView.OptionsBehavior.AutoPopulateColumns = False
        Me.MainView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.MainView.OptionsCustomization.AllowColumnMoving = False
        Me.MainView.OptionsCustomization.AllowColumnResizing = False
        Me.MainView.OptionsCustomization.AllowFilter = False
        Me.MainView.OptionsCustomization.AllowGroup = False
        Me.MainView.OptionsCustomization.AllowQuickHideColumns = False
        Me.MainView.OptionsFilter.AllowFilterEditor = False
        Me.MainView.OptionsFind.AllowFindPanel = False
        Me.MainView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.MainView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.MainView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.MainView.OptionsSelection.UseIndicatorForSelection = False
        Me.MainView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button
        Me.MainView.OptionsView.RowAutoHeight = True
        Me.MainView.OptionsView.ShowGroupPanel = False
        Me.MainView.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.UnitDesc, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'UnitCode
        '
        Me.UnitCode.Caption = "UnitCode"
        Me.UnitCode.FieldName = "UnitCode"
        Me.UnitCode.Name = "UnitCode"
        '
        'UnitDesc
        '
        Me.UnitDesc.Caption = "Component"
        Me.UnitDesc.FieldName = "UnitDesc"
        Me.UnitDesc.Name = "UnitDesc"
        Me.UnitDesc.OptionsColumn.AllowEdit = False
        Me.UnitDesc.OptionsColumn.ReadOnly = True
        Me.UnitDesc.Visible = True
        Me.UnitDesc.VisibleIndex = 0
        Me.UnitDesc.Width = 386
        '
        'Selected
        '
        Me.Selected.Caption = "Select"
        Me.Selected.FieldName = "Selected"
        Me.Selected.MaxWidth = 45
        Me.Selected.MinWidth = 45
        Me.Selected.Name = "Selected"
        Me.Selected.Visible = True
        Me.Selected.VisibleIndex = 1
        Me.Selected.Width = 45
        '
        'DeleteEdit
        '
        Me.DeleteEdit.AutoHeight = False
        Me.DeleteEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, CType(resources.GetObject("DeleteEdit.Buttons"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.DeleteEdit.Name = "DeleteEdit"
        Me.DeleteEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'RankEdit
        '
        Me.RankEdit.AutoHeight = False
        Me.RankEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RankEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("RankCode", "Name10", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Abbrv", "Name12")})
        Me.RankEdit.DisplayMember = "Abbrv"
        Me.RankEdit.DropDownRows = 10
        Me.RankEdit.Name = "RankEdit"
        Me.RankEdit.NullText = ""
        Me.RankEdit.ShowFooter = False
        Me.RankEdit.ShowHeader = False
        Me.RankEdit.ValueMember = "RankCode"
        '
        'gMaintenance
        '
        Me.gMaintenance.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gMaintenance.Controls.Add(Me.mGrid)
        Me.gMaintenance.Location = New System.Drawing.Point(17, 17)
        Me.gMaintenance.Name = "gMaintenance"
        Me.gMaintenance.Size = New System.Drawing.Size(476, 153)
        Me.gMaintenance.TabIndex = 13
        Me.gMaintenance.Text = "Maintenance"
        '
        'mGrid
        '
        Me.mGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mGrid.Location = New System.Drawing.Point(2, 23)
        Me.mGrid.LookAndFeel.SkinName = "iMaginary"
        Me.mGrid.MainView = Me.mView
        Me.mGrid.Name = "mGrid"
        Me.mGrid.Size = New System.Drawing.Size(472, 128)
        Me.mGrid.TabIndex = 38
        Me.mGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.mView})
        '
        'mView
        '
        Me.mView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.mView.Appearance.RowSeparator.Options.UseBackColor = True
        Me.mView.Appearance.ViewCaption.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.mView.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Black
        Me.mView.Appearance.ViewCaption.Options.UseFont = True
        Me.mView.Appearance.ViewCaption.Options.UseForeColor = True
        Me.mView.Appearance.ViewCaption.Options.UseTextOptions = True
        Me.mView.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.mView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.mView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.WorkDescription, Me.Interval, Me.Abbrv})
        Me.mView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.mView.GridControl = Me.mGrid
        Me.mView.Name = "mView"
        Me.mView.NewItemRowText = "Click here to add new record"
        Me.mView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.mView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.mView.OptionsBehavior.AutoPopulateColumns = False
        Me.mView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.mView.OptionsBehavior.Editable = False
        Me.mView.OptionsBehavior.ReadOnly = True
        Me.mView.OptionsCustomization.AllowColumnMoving = False
        Me.mView.OptionsCustomization.AllowColumnResizing = False
        Me.mView.OptionsCustomization.AllowFilter = False
        Me.mView.OptionsCustomization.AllowGroup = False
        Me.mView.OptionsCustomization.AllowQuickHideColumns = False
        Me.mView.OptionsFilter.AllowFilterEditor = False
        Me.mView.OptionsFind.AllowFindPanel = False
        Me.mView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.mView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.mView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.mView.OptionsSelection.UseIndicatorForSelection = False
        Me.mView.OptionsView.RowAutoHeight = True
        Me.mView.OptionsView.ShowGroupPanel = False
        Me.mView.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.WorkDescription, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'WorkDescription
        '
        Me.WorkDescription.Caption = "Work Description"
        Me.WorkDescription.FieldName = "WorkDescription"
        Me.WorkDescription.Name = "WorkDescription"
        Me.WorkDescription.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText
        Me.WorkDescription.Visible = True
        Me.WorkDescription.VisibleIndex = 0
        Me.WorkDescription.Width = 204
        '
        'Interval
        '
        Me.Interval.Caption = "Interval"
        Me.Interval.FieldName = "Interval"
        Me.Interval.Name = "Interval"
        Me.Interval.Visible = True
        Me.Interval.VisibleIndex = 1
        Me.Interval.Width = 137
        '
        'Abbrv
        '
        Me.Abbrv.Caption = "Rank"
        Me.Abbrv.FieldName = "Abbrv"
        Me.Abbrv.MinWidth = 80
        Me.Abbrv.Name = "Abbrv"
        Me.Abbrv.Visible = True
        Me.Abbrv.VisibleIndex = 2
        Me.Abbrv.Width = 115
        '
        'cmdDeselect
        '
        Me.cmdDeselect.Location = New System.Drawing.Point(105, 467)
        Me.cmdDeselect.Name = "cmdDeselect"
        Me.cmdDeselect.Size = New System.Drawing.Size(69, 23)
        Me.cmdDeselect.TabIndex = 15
        Me.cmdDeselect.Text = "Deselect All"
        '
        'cmdSelectAll
        '
        Me.cmdSelectAll.Location = New System.Drawing.Point(19, 467)
        Me.cmdSelectAll.Name = "cmdSelectAll"
        Me.cmdSelectAll.Size = New System.Drawing.Size(69, 23)
        Me.cmdSelectAll.TabIndex = 14
        Me.cmdSelectAll.Text = "Select All"
        '
        'frmCopyMaintenance
        '
        Me.AcceptButton = Me.cmdSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(514, 502)
        Me.Controls.Add(Me.cmdDeselect)
        Me.Controls.Add(Me.cmdSelectAll)
        Me.Controls.Add(Me.gMaintenance)
        Me.Controls.Add(Me.gDetails)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCopyMaintenance"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Copy Maintenance"
        Me.TopMost = True
        CType(Me.gDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gDetails.ResumeLayout(False)
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DeleteEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RankEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gMaintenance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gMaintenance.ResumeLayout(False)
        CType(Me.mGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents gDetails As DevExpress.XtraEditors.GroupControl
    Friend WithEvents MainGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents MainView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents UnitCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UnitDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RankEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents Selected As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DeleteEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents gMaintenance As DevExpress.XtraEditors.GroupControl
    Friend WithEvents mGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents mView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents WorkDescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Interval As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Abbrv As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdDeselect As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdSelectAll As DevExpress.XtraEditors.SimpleButton
End Class
