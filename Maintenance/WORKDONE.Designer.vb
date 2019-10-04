<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WORKDONE
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
        Me.MaintenanceWorkID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UnitCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Description = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RemarksEdit = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.Maintenance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.WorkDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.WorkCounter = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NumberEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.ExecutedBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Abbrv = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Remarks = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DueDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DueCounter = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.bNC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Edited = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.bLatest = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MaintenanceCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RankCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.AddedImages = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DeletedImages = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Locked = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RemarksEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumberEdit, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.header.Text = "Details"
        '
        'MainGrid
        '
        Me.MainGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainGrid.Location = New System.Drawing.Point(2, 20)
        Me.MainGrid.LookAndFeel.SkinName = "iMaginary"
        Me.MainGrid.MainView = Me.MainView
        Me.MainGrid.Name = "MainGrid"
        Me.MainGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RemarksEdit, Me.NumberEdit})
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
        Me.MainView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.MaintenanceWorkID, Me.UnitCode, Me.Description, Me.Maintenance, Me.WorkDate, Me.WorkCounter, Me.ExecutedBy, Me.Abbrv, Me.Remarks, Me.DueDate, Me.DueCounter, Me.bNC, Me.Edited, Me.bLatest, Me.MaintenanceCode, Me.RankCode, Me.AddedImages, Me.DeletedImages, Me.Locked})
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
        Me.MainView.OptionsFind.AllowFindPanel = False
        Me.MainView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.MainView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.MainView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.MainView.OptionsSelection.UseIndicatorForSelection = False
        Me.MainView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button
        Me.MainView.OptionsView.RowAutoHeight = True
        Me.MainView.OptionsView.ShowGroupPanel = False
        Me.MainView.RowHeight = 0
        Me.MainView.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.Description, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'MaintenanceWorkID
        '
        Me.MaintenanceWorkID.Caption = "MaintenanceWorkID"
        Me.MaintenanceWorkID.FieldName = "MaintenanceWorkID"
        Me.MaintenanceWorkID.Name = "MaintenanceWorkID"
        '
        'UnitCode
        '
        Me.UnitCode.Caption = "UnitCode"
        Me.UnitCode.FieldName = "UnitCode"
        Me.UnitCode.Name = "UnitCode"
        '
        'Description
        '
        Me.Description.Caption = "Description"
        Me.Description.ColumnEdit = Me.RemarksEdit
        Me.Description.FieldName = "Description"
        Me.Description.Name = "Description"
        Me.Description.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText
        Me.Description.Visible = True
        Me.Description.VisibleIndex = 0
        Me.Description.Width = 206
        '
        'RemarksEdit
        '
        Me.RemarksEdit.Appearance.Options.UseTextOptions = True
        Me.RemarksEdit.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.RemarksEdit.Name = "RemarksEdit"
        '
        'Maintenance
        '
        Me.Maintenance.Caption = "Maintenance"
        Me.Maintenance.FieldName = "Maintenance"
        Me.Maintenance.Name = "Maintenance"
        Me.Maintenance.Visible = True
        Me.Maintenance.VisibleIndex = 1
        Me.Maintenance.Width = 155
        '
        'WorkDate
        '
        Me.WorkDate.Caption = "Date Done"
        Me.WorkDate.DisplayFormat.FormatString = "d"
        Me.WorkDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.WorkDate.FieldName = "WorkDate"
        Me.WorkDate.MinWidth = 100
        Me.WorkDate.Name = "WorkDate"
        Me.WorkDate.Visible = True
        Me.WorkDate.VisibleIndex = 4
        Me.WorkDate.Width = 100
        '
        'WorkCounter
        '
        Me.WorkCounter.Caption = "@Running Hours"
        Me.WorkCounter.ColumnEdit = Me.NumberEdit
        Me.WorkCounter.DisplayFormat.FormatString = "n0"
        Me.WorkCounter.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.WorkCounter.FieldName = "WorkCounter"
        Me.WorkCounter.MinWidth = 90
        Me.WorkCounter.Name = "WorkCounter"
        Me.WorkCounter.Visible = True
        Me.WorkCounter.VisibleIndex = 5
        Me.WorkCounter.Width = 99
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
        Me.ExecutedBy.VisibleIndex = 6
        Me.ExecutedBy.Width = 134
        '
        'Abbrv
        '
        Me.Abbrv.Caption = "Rank"
        Me.Abbrv.FieldName = "Abbrv"
        Me.Abbrv.MinWidth = 70
        Me.Abbrv.Name = "Abbrv"
        Me.Abbrv.Visible = True
        Me.Abbrv.VisibleIndex = 7
        Me.Abbrv.Width = 70
        '
        'Remarks
        '
        Me.Remarks.Caption = "Remarks"
        Me.Remarks.ColumnEdit = Me.RemarksEdit
        Me.Remarks.FieldName = "Remarks"
        Me.Remarks.Name = "Remarks"
        Me.Remarks.Visible = True
        Me.Remarks.VisibleIndex = 8
        Me.Remarks.Width = 164
        '
        'DueDate
        '
        Me.DueDate.AppearanceCell.Options.UseFont = True
        Me.DueDate.Caption = "Date Due"
        Me.DueDate.DisplayFormat.FormatString = "d"
        Me.DueDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DueDate.FieldName = "DueDate"
        Me.DueDate.MinWidth = 100
        Me.DueDate.Name = "DueDate"
        Me.DueDate.Visible = True
        Me.DueDate.VisibleIndex = 2
        Me.DueDate.Width = 100
        '
        'DueCounter
        '
        Me.DueCounter.Caption = "Working Hours Due"
        Me.DueCounter.ColumnEdit = Me.NumberEdit
        Me.DueCounter.FieldName = "DueCounter"
        Me.DueCounter.MinWidth = 105
        Me.DueCounter.Name = "DueCounter"
        Me.DueCounter.OptionsColumn.AllowEdit = False
        Me.DueCounter.OptionsColumn.ReadOnly = True
        Me.DueCounter.Visible = True
        Me.DueCounter.VisibleIndex = 3
        Me.DueCounter.Width = 105
        '
        'bNC
        '
        Me.bNC.Caption = "bNC"
        Me.bNC.FieldName = "bNC"
        Me.bNC.Name = "bNC"
        '
        'Edited
        '
        Me.Edited.Caption = "Edited"
        Me.Edited.FieldName = "Edited"
        Me.Edited.Name = "Edited"
        '
        'bLatest
        '
        Me.bLatest.Caption = "bLatest"
        Me.bLatest.FieldName = "bLatest"
        Me.bLatest.Name = "bLatest"
        '
        'MaintenanceCode
        '
        Me.MaintenanceCode.Caption = "MaintenanceCode"
        Me.MaintenanceCode.FieldName = "MaintenanceCode"
        Me.MaintenanceCode.Name = "MaintenanceCode"
        '
        'RankCode
        '
        Me.RankCode.Caption = "RankCode"
        Me.RankCode.FieldName = "RankCode"
        Me.RankCode.Name = "RankCode"
        '
        'AddedImages
        '
        Me.AddedImages.Caption = "AddedImages"
        Me.AddedImages.FieldName = "AddedImages"
        Me.AddedImages.Name = "AddedImages"
        '
        'DeletedImages
        '
        Me.DeletedImages.Caption = "DeletedImages"
        Me.DeletedImages.FieldName = "DeletedImages"
        Me.DeletedImages.Name = "DeletedImages"
        '
        'Locked
        '
        Me.Locked.Caption = "Locked"
        Me.Locked.FieldName = "Locked"
        Me.Locked.Name = "Locked"
        '
        'WORKDONE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.header)
        Me.Name = "WORKDONE"
        Me.Size = New System.Drawing.Size(1153, 510)
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RemarksEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumberEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents MainGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents NumberEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RemarksEdit As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents MainView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents MaintenanceWorkID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents WorkDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents WorkCounter As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Edited As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Remarks As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DueDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DueCounter As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents bLatest As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Abbrv As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ExecutedBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Maintenance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents bNC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MaintenanceCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UnitCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RankCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents AddedImages As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Description As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Locked As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DeletedImages As DevExpress.XtraGrid.Columns.GridColumn

End Class
