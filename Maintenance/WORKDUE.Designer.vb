<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WORKDUE
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
        Me.GroupID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UnitDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UnitEdit = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.Maintenance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.WorkDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RunningHours = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NumberEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.Critical = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RankCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RankEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.DueCounter = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MaintenanceCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UnitCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DueDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ComponentCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Interval = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ExecutedBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Remarks = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ReadingDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.WorkCounter = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MaintenanceWorkID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PlannedDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Reason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ApprovedBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.HasImage = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RemarksEdit = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.MaintenanceEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.CriticalEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UnitEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumberEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RankEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RemarksEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MaintenanceEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CriticalEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'header
        '
        Me.header.Controls.Add(Me.MainGrid)
        Me.header.Dock = System.Windows.Forms.DockStyle.Fill
        Me.header.Location = New System.Drawing.Point(0, 0)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(1153, 510)
        Me.header.TabIndex = 36
        Me.header.Text = "DUE MAINTENANCE"
        '
        'MainGrid
        '
        Me.MainGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainGrid.Location = New System.Drawing.Point(2, 20)
        Me.MainGrid.LookAndFeel.SkinName = "iMaginary"
        Me.MainGrid.MainView = Me.MainView
        Me.MainGrid.Name = "MainGrid"
        Me.MainGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RemarksEdit, Me.NumberEdit, Me.RankEdit, Me.MaintenanceEdit, Me.UnitEdit, Me.CriticalEdit})
        Me.MainGrid.Size = New System.Drawing.Size(1149, 488)
        Me.MainGrid.TabIndex = 8
        Me.MainGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MainView})
        '
        'MainView
        '
        Me.MainView.Appearance.GroupRow.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.MainView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black
        Me.MainView.Appearance.GroupRow.Options.UseBackColor = True
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
        Me.MainView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GroupID, Me.UnitDesc, Me.Maintenance, Me.WorkDate, Me.RunningHours, Me.Critical, Me.RankCode, Me.DueCounter, Me.MaintenanceCode, Me.UnitCode, Me.DueDate, Me.ComponentCode, Me.Interval, Me.ExecutedBy, Me.Remarks, Me.ReadingDate, Me.WorkCounter, Me.MaintenanceWorkID, Me.PlannedDate, Me.Reason, Me.ApprovedBy, Me.HasImage})
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
        Me.MainView.OptionsBehavior.Editable = False
        Me.MainView.OptionsBehavior.ReadOnly = True
        Me.MainView.OptionsCustomization.AllowColumnMoving = False
        Me.MainView.OptionsCustomization.AllowFilter = False
        Me.MainView.OptionsCustomization.AllowGroup = False
        Me.MainView.OptionsCustomization.AllowQuickHideColumns = False
        Me.MainView.OptionsFilter.AllowFilterEditor = False
        Me.MainView.OptionsFind.AlwaysVisible = True
        Me.MainView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.MainView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.MainView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.MainView.OptionsSelection.UseIndicatorForSelection = False
        Me.MainView.OptionsView.ColumnAutoWidth = False
        Me.MainView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button
        Me.MainView.OptionsView.RowAutoHeight = True
        Me.MainView.OptionsView.ShowGroupPanel = False
        Me.MainView.RowHeight = 0
        Me.MainView.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.DueDate, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GroupID
        '
        Me.GroupID.Caption = "GroupID"
        Me.GroupID.FieldName = "GroupID"
        Me.GroupID.Name = "GroupID"
        Me.GroupID.Visible = True
        Me.GroupID.VisibleIndex = 0
        Me.GroupID.Width = 82
        '
        'UnitDesc
        '
        Me.UnitDesc.Caption = "Machines & Equipments"
        Me.UnitDesc.ColumnEdit = Me.UnitEdit
        Me.UnitDesc.FieldName = "UnitDesc"
        Me.UnitDesc.Name = "UnitDesc"
        Me.UnitDesc.Visible = True
        Me.UnitDesc.VisibleIndex = 1
        Me.UnitDesc.Width = 253
        '
        'UnitEdit
        '
        Me.UnitEdit.Appearance.Options.UseTextOptions = True
        Me.UnitEdit.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.UnitEdit.Name = "UnitEdit"
        '
        'Maintenance
        '
        Me.Maintenance.Caption = "Maintenance"
        Me.Maintenance.FieldName = "Maintenance"
        Me.Maintenance.Name = "Maintenance"
        Me.Maintenance.Visible = True
        Me.Maintenance.VisibleIndex = 6
        Me.Maintenance.Width = 228
        '
        'WorkDate
        '
        Me.WorkDate.Caption = "Latest Maintenance"
        Me.WorkDate.FieldName = "WorkDate"
        Me.WorkDate.MaxWidth = 120
        Me.WorkDate.MinWidth = 120
        Me.WorkDate.Name = "WorkDate"
        Me.WorkDate.Visible = True
        Me.WorkDate.VisibleIndex = 7
        Me.WorkDate.Width = 120
        '
        'RunningHours
        '
        Me.RunningHours.Caption = "Running Hours"
        Me.RunningHours.ColumnEdit = Me.NumberEdit
        Me.RunningHours.DisplayFormat.FormatString = "n0"
        Me.RunningHours.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RunningHours.FieldName = "RunningHours"
        Me.RunningHours.MinWidth = 120
        Me.RunningHours.Name = "RunningHours"
        Me.RunningHours.Visible = True
        Me.RunningHours.VisibleIndex = 4
        Me.RunningHours.Width = 120
        '
        'NumberEdit
        '
        Me.NumberEdit.AutoHeight = False
        Me.NumberEdit.Mask.EditMask = "n0"
        Me.NumberEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.NumberEdit.Name = "NumberEdit"
        '
        'Critical
        '
        Me.Critical.Caption = "Critical"
        Me.Critical.ColumnEdit = Me.CriticalEdit
        Me.Critical.FieldName = "Critical"
        Me.Critical.MaxWidth = 50
        Me.Critical.Name = "Critical"
        Me.Critical.Visible = True
        Me.Critical.VisibleIndex = 5
        Me.Critical.Width = 50
        '
        'RankCode
        '
        Me.RankCode.Caption = "Rank"
        Me.RankCode.ColumnEdit = Me.RankEdit
        Me.RankCode.FieldName = "RankCode"
        Me.RankCode.MaxWidth = 120
        Me.RankCode.Name = "RankCode"
        Me.RankCode.Visible = True
        Me.RankCode.VisibleIndex = 2
        Me.RankCode.Width = 89
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
        'DueCounter
        '
        Me.DueCounter.Caption = "Running Hours Due"
        Me.DueCounter.ColumnEdit = Me.NumberEdit
        Me.DueCounter.FieldName = "DueCounter"
        Me.DueCounter.MaxWidth = 105
        Me.DueCounter.MinWidth = 105
        Me.DueCounter.Name = "DueCounter"
        Me.DueCounter.Visible = True
        Me.DueCounter.VisibleIndex = 9
        Me.DueCounter.Width = 105
        '
        'MaintenanceCode
        '
        Me.MaintenanceCode.Caption = "MaintenanceCode"
        Me.MaintenanceCode.FieldName = "MaintenanceCode"
        Me.MaintenanceCode.Name = "MaintenanceCode"
        '
        'UnitCode
        '
        Me.UnitCode.Caption = "UnitCode"
        Me.UnitCode.FieldName = "UnitCode"
        Me.UnitCode.Name = "UnitCode"
        '
        'DueDate
        '
        Me.DueDate.Caption = "Due Date"
        Me.DueDate.FieldName = "DueDate"
        Me.DueDate.MinWidth = 70
        Me.DueDate.Name = "DueDate"
        Me.DueDate.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value
        Me.DueDate.Visible = True
        Me.DueDate.VisibleIndex = 10
        Me.DueDate.Width = 70
        '
        'ComponentCode
        '
        Me.ComponentCode.Caption = "ComponentCode"
        Me.ComponentCode.FieldName = "ComponentCode"
        Me.ComponentCode.Name = "ComponentCode"
        '
        'Interval
        '
        Me.Interval.Caption = "Interval"
        Me.Interval.FieldName = "Interval"
        Me.Interval.Name = "Interval"
        Me.Interval.Visible = True
        Me.Interval.VisibleIndex = 8
        Me.Interval.Width = 117
        '
        'ExecutedBy
        '
        Me.ExecutedBy.Caption = "ExecutedBy"
        Me.ExecutedBy.FieldName = "ExecutedBy"
        Me.ExecutedBy.Name = "ExecutedBy"
        '
        'Remarks
        '
        Me.Remarks.Caption = "Remarks"
        Me.Remarks.FieldName = "Remarks"
        Me.Remarks.Name = "Remarks"
        '
        'ReadingDate
        '
        Me.ReadingDate.Caption = "Latest Reading @"
        Me.ReadingDate.FieldName = "ReadingDate"
        Me.ReadingDate.Name = "ReadingDate"
        Me.ReadingDate.Visible = True
        Me.ReadingDate.VisibleIndex = 3
        Me.ReadingDate.Width = 105
        '
        'WorkCounter
        '
        Me.WorkCounter.Caption = "WorkCounter"
        Me.WorkCounter.FieldName = "WorkCounter"
        Me.WorkCounter.Name = "WorkCounter"
        '
        'MaintenanceWorkID
        '
        Me.MaintenanceWorkID.Caption = "MaintenanceWorkID"
        Me.MaintenanceWorkID.FieldName = "MaintenanceWorkID"
        Me.MaintenanceWorkID.Name = "MaintenanceWorkID"
        '
        'PlannedDate
        '
        Me.PlannedDate.Caption = "Planned Date"
        Me.PlannedDate.FieldName = "PlannedDate"
        Me.PlannedDate.MinWidth = 60
        Me.PlannedDate.Name = "PlannedDate"
        Me.PlannedDate.Visible = True
        Me.PlannedDate.VisibleIndex = 11
        Me.PlannedDate.Width = 79
        '
        'Reason
        '
        Me.Reason.Caption = "Reason"
        Me.Reason.FieldName = "Reason"
        Me.Reason.Name = "Reason"
        Me.Reason.Visible = True
        Me.Reason.VisibleIndex = 12
        '
        'ApprovedBy
        '
        Me.ApprovedBy.Caption = "Approved By"
        Me.ApprovedBy.FieldName = "ApprovedBy"
        Me.ApprovedBy.Name = "ApprovedBy"
        Me.ApprovedBy.Visible = True
        Me.ApprovedBy.VisibleIndex = 13
        '
        'HasImage
        '
        Me.HasImage.Caption = "HasImage"
        Me.HasImage.FieldName = "HasImage"
        Me.HasImage.Name = "HasImage"
        '
        'RemarksEdit
        '
        Me.RemarksEdit.Appearance.Options.UseTextOptions = True
        Me.RemarksEdit.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.RemarksEdit.Name = "RemarksEdit"
        '
        'MaintenanceEdit
        '
        Me.MaintenanceEdit.AutoHeight = False
        Me.MaintenanceEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.MaintenanceEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaintenanceCode", "", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("WorkDescription", 40, "WorkDescription"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("RankCode", "Name9", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("IntDue", "Name47", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("IntCode", "Name18", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Number", "Name24", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.MaintenanceEdit.DisplayMember = "WorkDescription"
        Me.MaintenanceEdit.DropDownRows = 10
        Me.MaintenanceEdit.Name = "MaintenanceEdit"
        Me.MaintenanceEdit.NullText = ""
        Me.MaintenanceEdit.ShowFooter = False
        Me.MaintenanceEdit.ShowHeader = False
        Me.MaintenanceEdit.ShowLines = False
        Me.MaintenanceEdit.ValueMember = "MaintenanceCode"
        '
        'CriticalEdit
        '
        Me.CriticalEdit.AutoHeight = False
        Me.CriticalEdit.Name = "CriticalEdit"
        '
        'WORKDUE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.header)
        Me.Name = "WORKDUE"
        Me.Size = New System.Drawing.Size(1153, 510)
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UnitEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumberEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RankEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RemarksEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MaintenanceEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CriticalEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents MainGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents NumberEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RemarksEdit As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents RankEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents MainView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RunningHours As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DueCounter As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RankCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MaintenanceEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents Maintenance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MaintenanceCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UnitDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UnitCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DueDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ComponentCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UnitEdit As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents Interval As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ExecutedBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Remarks As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ReadingDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents WorkCounter As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents WorkDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MaintenanceWorkID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PlannedDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Reason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ApprovedBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents HasImage As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Critical As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CriticalEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit

End Class
