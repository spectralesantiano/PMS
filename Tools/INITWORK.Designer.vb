<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class INITWORK
    Inherits BaseControl.BaseControl

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
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.MainGrid = New DevExpress.XtraGrid.GridControl()
        Me.MainView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.MaintenanceCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.EquipmentCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ComponentCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Equipment = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Component = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Maintenance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.WorkDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.WorkCounter = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NumberEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.ExecutedBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RankCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RankEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.Remarks = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RemarksEdit = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.DueDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DueCounter = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Edited = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.IntCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Interval = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumberEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RankEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RemarksEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'header
        '
        Me.header.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.header.AppearanceCaption.Options.UseFont = True
        Me.header.Controls.Add(Me.MainGrid)
        Me.header.Dock = System.Windows.Forms.DockStyle.Fill
        Me.header.Location = New System.Drawing.Point(0, 0)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(1347, 510)
        Me.header.TabIndex = 36
        Me.header.Text = "Details"
        '
        'MainGrid
        '
        Me.MainGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainGrid.Location = New System.Drawing.Point(2, 23)
        Me.MainGrid.LookAndFeel.SkinName = "iMaginary"
        Me.MainGrid.MainView = Me.MainView
        Me.MainGrid.Name = "MainGrid"
        Me.MainGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RemarksEdit, Me.NumberEdit, Me.RankEdit})
        Me.MainGrid.Size = New System.Drawing.Size(1343, 485)
        Me.MainGrid.TabIndex = 8
        Me.MainGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MainView})
        '
        'MainView
        '
        Me.MainView.Appearance.GroupRow.BackColor = System.Drawing.Color.Gray
        Me.MainView.Appearance.GroupRow.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.MainView.Appearance.GroupRow.ForeColor = System.Drawing.Color.White
        Me.MainView.Appearance.GroupRow.Options.UseBackColor = True
        Me.MainView.Appearance.GroupRow.Options.UseFont = True
        Me.MainView.Appearance.GroupRow.Options.UseForeColor = True
        Me.MainView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.MainView.Appearance.RowSeparator.Options.UseBackColor = True
        Me.MainView.Appearance.ViewCaption.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.MainView.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Black
        Me.MainView.Appearance.ViewCaption.Options.UseFont = True
        Me.MainView.Appearance.ViewCaption.Options.UseForeColor = True
        Me.MainView.Appearance.ViewCaption.Options.UseTextOptions = True
        Me.MainView.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.MainView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.MainView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.MaintenanceCode, Me.EquipmentCode, Me.ComponentCode, Me.Equipment, Me.Component, Me.Maintenance, Me.WorkDate, Me.WorkCounter, Me.ExecutedBy, Me.RankCode, Me.Remarks, Me.DueDate, Me.DueCounter, Me.Edited, Me.IntCode, Me.Interval})
        Me.MainView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.MainView.GridControl = Me.MainGrid
        Me.MainView.GroupFormat = "{1} {2}"
        Me.MainView.LevelIndent = 0
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
        Me.MainView.RowHeight = 0
        Me.MainView.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.Equipment, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.Component, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.Maintenance, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'MaintenanceCode
        '
        Me.MaintenanceCode.Caption = "MaintenanceCode"
        Me.MaintenanceCode.FieldName = "MaintenanceCode"
        Me.MaintenanceCode.Name = "MaintenanceCode"
        Me.MaintenanceCode.Width = 187
        '
        'EquipmentCode
        '
        Me.EquipmentCode.Caption = "EquipmentCode"
        Me.EquipmentCode.FieldName = "EquipmentCode"
        Me.EquipmentCode.Name = "EquipmentCode"
        '
        'ComponentCode
        '
        Me.ComponentCode.Caption = "ComponentCode"
        Me.ComponentCode.FieldName = "ComponentCode"
        Me.ComponentCode.Name = "ComponentCode"
        '
        'Equipment
        '
        Me.Equipment.Caption = "Equipment"
        Me.Equipment.FieldName = "Equipment"
        Me.Equipment.Name = "Equipment"
        Me.Equipment.Visible = True
        Me.Equipment.VisibleIndex = 0
        Me.Equipment.Width = 135
        '
        'Component
        '
        Me.Component.Caption = "Component"
        Me.Component.FieldName = "Component"
        Me.Component.Name = "Component"
        Me.Component.Visible = True
        Me.Component.VisibleIndex = 1
        Me.Component.Width = 146
        '
        'Maintenance
        '
        Me.Maintenance.Caption = "Maintenance"
        Me.Maintenance.FieldName = "Maintenance"
        Me.Maintenance.Name = "Maintenance"
        Me.Maintenance.Visible = True
        Me.Maintenance.VisibleIndex = 2
        Me.Maintenance.Width = 156
        '
        'WorkDate
        '
        Me.WorkDate.Caption = "Date"
        Me.WorkDate.DisplayFormat.FormatString = "d"
        Me.WorkDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.WorkDate.FieldName = "WorkDate"
        Me.WorkDate.MaxWidth = 100
        Me.WorkDate.MinWidth = 100
        Me.WorkDate.Name = "WorkDate"
        Me.WorkDate.Visible = True
        Me.WorkDate.VisibleIndex = 3
        Me.WorkDate.Width = 100
        '
        'WorkCounter
        '
        Me.WorkCounter.Caption = "Running Hours"
        Me.WorkCounter.ColumnEdit = Me.NumberEdit
        Me.WorkCounter.DisplayFormat.FormatString = "n0"
        Me.WorkCounter.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.WorkCounter.FieldName = "WorkCounter"
        Me.WorkCounter.MaxWidth = 90
        Me.WorkCounter.MinWidth = 90
        Me.WorkCounter.Name = "WorkCounter"
        Me.WorkCounter.Visible = True
        Me.WorkCounter.VisibleIndex = 4
        Me.WorkCounter.Width = 90
        '
        'NumberEdit
        '
        Me.NumberEdit.AutoHeight = False
        Me.NumberEdit.Mask.EditMask = "n0"
        Me.NumberEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.NumberEdit.Name = "NumberEdit"
        '
        'ExecutedBy
        '
        Me.ExecutedBy.Caption = "ExecutedBy"
        Me.ExecutedBy.FieldName = "ExecutedBy"
        Me.ExecutedBy.Name = "ExecutedBy"
        Me.ExecutedBy.Visible = True
        Me.ExecutedBy.VisibleIndex = 5
        Me.ExecutedBy.Width = 176
        '
        'RankCode
        '
        Me.RankCode.Caption = "Rank"
        Me.RankCode.ColumnEdit = Me.RankEdit
        Me.RankCode.FieldName = "RankCode"
        Me.RankCode.MaxWidth = 70
        Me.RankCode.MinWidth = 70
        Me.RankCode.Name = "RankCode"
        Me.RankCode.Visible = True
        Me.RankCode.VisibleIndex = 6
        Me.RankCode.Width = 70
        '
        'RankEdit
        '
        Me.RankEdit.AutoHeight = False
        Me.RankEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RankEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("RankCode", "Name7", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Abbrv", "Name8")})
        Me.RankEdit.DisplayMember = "Abbrv"
        Me.RankEdit.DropDownRows = 10
        Me.RankEdit.Name = "RankEdit"
        Me.RankEdit.NullText = ""
        Me.RankEdit.ShowFooter = False
        Me.RankEdit.ShowHeader = False
        Me.RankEdit.ValueMember = "RankCode"
        '
        'Remarks
        '
        Me.Remarks.Caption = "Remarks"
        Me.Remarks.ColumnEdit = Me.RemarksEdit
        Me.Remarks.FieldName = "Remarks"
        Me.Remarks.Name = "Remarks"
        Me.Remarks.Visible = True
        Me.Remarks.VisibleIndex = 7
        Me.Remarks.Width = 372
        '
        'RemarksEdit
        '
        Me.RemarksEdit.Appearance.Options.UseTextOptions = True
        Me.RemarksEdit.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.RemarksEdit.Name = "RemarksEdit"
        '
        'DueDate
        '
        Me.DueDate.AppearanceCell.Options.UseFont = True
        Me.DueDate.Caption = "Date Due"
        Me.DueDate.DisplayFormat.FormatString = "d"
        Me.DueDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DueDate.FieldName = "DueDate"
        Me.DueDate.MaxWidth = 100
        Me.DueDate.MinWidth = 100
        Me.DueDate.Name = "DueDate"
        Me.DueDate.Visible = True
        Me.DueDate.VisibleIndex = 8
        Me.DueDate.Width = 100
        '
        'DueCounter
        '
        Me.DueCounter.Caption = "Working Hours Due"
        Me.DueCounter.ColumnEdit = Me.NumberEdit
        Me.DueCounter.FieldName = "DueCounter"
        Me.DueCounter.MaxWidth = 105
        Me.DueCounter.MinWidth = 105
        Me.DueCounter.Name = "DueCounter"
        Me.DueCounter.OptionsColumn.AllowEdit = False
        Me.DueCounter.OptionsColumn.ReadOnly = True
        Me.DueCounter.Visible = True
        Me.DueCounter.VisibleIndex = 9
        Me.DueCounter.Width = 105
        '
        'Edited
        '
        Me.Edited.Caption = "Edited"
        Me.Edited.FieldName = "Edited"
        Me.Edited.Name = "Edited"
        '
        'IntCode
        '
        Me.IntCode.Caption = "IntCode"
        Me.IntCode.FieldName = "IntCode"
        Me.IntCode.Name = "IntCode"
        '
        'Interval
        '
        Me.Interval.Caption = "Interval"
        Me.Interval.FieldName = "Interval"
        Me.Interval.Name = "Interval"
        '
        'INITWORK
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.header)
        Me.Name = "INITWORK"
        Me.Size = New System.Drawing.Size(1347, 510)
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumberEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RankEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RemarksEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents MainGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents NumberEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RemarksEdit As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents RankEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents MainView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents WorkDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents WorkCounter As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Edited As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Remarks As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DueDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DueCounter As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RankCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ExecutedBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MaintenanceCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents EquipmentCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ComponentCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Equipment As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Component As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Maintenance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents IntCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Interval As DevExpress.XtraGrid.Columns.GridColumn

End Class
