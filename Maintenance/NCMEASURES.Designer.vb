<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NCMEASURES
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
        Me.NCID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NCNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.WorkDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NCDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RemarksEdit = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.Unit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Description = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RankCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RankEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.DueDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DoneDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Edited = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NCCorrectiveMeasureID = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RemarksEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RankEdit, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.header.Size = New System.Drawing.Size(1153, 510)
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
        Me.MainGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RemarksEdit, Me.RankEdit})
        Me.MainGrid.Size = New System.Drawing.Size(1149, 485)
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
        Me.MainView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.NCID, Me.NCNo, Me.WorkDate, Me.NCDesc, Me.Unit, Me.Description, Me.RankCode, Me.DueDate, Me.DoneDate, Me.Edited, Me.NCCorrectiveMeasureID})
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
        Me.MainView.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.NCNo, DevExpress.Data.ColumnSortOrder.Descending)})
        '
        'NCID
        '
        Me.NCID.Caption = "NCID"
        Me.NCID.FieldName = "NCID"
        Me.NCID.Name = "NCID"
        '
        'NCNo
        '
        Me.NCNo.Caption = "NC No."
        Me.NCNo.FieldName = "NCNo"
        Me.NCNo.MaxWidth = 55
        Me.NCNo.MinWidth = 55
        Me.NCNo.Name = "NCNo"
        Me.NCNo.OptionsColumn.AllowEdit = False
        Me.NCNo.OptionsColumn.ReadOnly = True
        Me.NCNo.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value
        Me.NCNo.Visible = True
        Me.NCNo.VisibleIndex = 0
        Me.NCNo.Width = 55
        '
        'WorkDate
        '
        Me.WorkDate.Caption = "NC Date"
        Me.WorkDate.FieldName = "WorkDate"
        Me.WorkDate.Name = "WorkDate"
        Me.WorkDate.OptionsColumn.AllowEdit = False
        Me.WorkDate.OptionsColumn.ReadOnly = True
        Me.WorkDate.Visible = True
        Me.WorkDate.VisibleIndex = 1
        Me.WorkDate.Width = 101
        '
        'NCDesc
        '
        Me.NCDesc.Caption = "NC Descripction"
        Me.NCDesc.ColumnEdit = Me.RemarksEdit
        Me.NCDesc.FieldName = "NCDesc"
        Me.NCDesc.Name = "NCDesc"
        Me.NCDesc.OptionsColumn.AllowEdit = False
        Me.NCDesc.OptionsColumn.ReadOnly = True
        Me.NCDesc.Visible = True
        Me.NCDesc.VisibleIndex = 2
        Me.NCDesc.Width = 317
        '
        'RemarksEdit
        '
        Me.RemarksEdit.Appearance.Options.UseTextOptions = True
        Me.RemarksEdit.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.RemarksEdit.Name = "RemarksEdit"
        '
        'Unit
        '
        Me.Unit.Caption = "Unit"
        Me.Unit.FieldName = "Unit"
        Me.Unit.Name = "Unit"
        Me.Unit.OptionsColumn.AllowEdit = False
        Me.Unit.OptionsColumn.ReadOnly = True
        Me.Unit.Visible = True
        Me.Unit.VisibleIndex = 3
        Me.Unit.Width = 332
        '
        'Description
        '
        Me.Description.Caption = "Description"
        Me.Description.ColumnEdit = Me.RemarksEdit
        Me.Description.FieldName = "Description"
        Me.Description.Name = "Description"
        Me.Description.Visible = True
        Me.Description.VisibleIndex = 4
        Me.Description.Width = 371
        '
        'RankCode
        '
        Me.RankCode.Caption = "Responsible"
        Me.RankCode.ColumnEdit = Me.RankEdit
        Me.RankCode.FieldName = "RankCode"
        Me.RankCode.MinWidth = 105
        Me.RankCode.Name = "RankCode"
        Me.RankCode.Visible = True
        Me.RankCode.VisibleIndex = 5
        Me.RankCode.Width = 196
        '
        'RankEdit
        '
        Me.RankEdit.AutoHeight = False
        Me.RankEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RankEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("RankDesc", "Name1"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("RankCode", "Name2", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.RankEdit.DisplayMember = "RankDesc"
        Me.RankEdit.DropDownRows = 10
        Me.RankEdit.Name = "RankEdit"
        Me.RankEdit.NullText = ""
        Me.RankEdit.ShowFooter = False
        Me.RankEdit.ShowHeader = False
        Me.RankEdit.ValueMember = "RankCode"
        '
        'DueDate
        '
        Me.DueDate.AppearanceCell.Options.UseFont = True
        Me.DueDate.Caption = "Due Date"
        Me.DueDate.FieldName = "DueDate"
        Me.DueDate.MinWidth = 100
        Me.DueDate.Name = "DueDate"
        Me.DueDate.Visible = True
        Me.DueDate.VisibleIndex = 6
        Me.DueDate.Width = 139
        '
        'DoneDate
        '
        Me.DoneDate.Caption = "Done Date"
        Me.DoneDate.FieldName = "DoneDate"
        Me.DoneDate.Name = "DoneDate"
        Me.DoneDate.Visible = True
        Me.DoneDate.VisibleIndex = 7
        Me.DoneDate.Width = 123
        '
        'Edited
        '
        Me.Edited.Caption = "Edited"
        Me.Edited.FieldName = "Edited"
        Me.Edited.MaxWidth = 60
        Me.Edited.Name = "Edited"
        Me.Edited.Width = 55
        '
        'NCCorrectiveMeasureID
        '
        Me.NCCorrectiveMeasureID.Caption = "NCCorrectiveMeasureID"
        Me.NCCorrectiveMeasureID.FieldName = "NCCorrectiveMeasureID"
        Me.NCCorrectiveMeasureID.Name = "NCCorrectiveMeasureID"
        '
        'NCMEASURES
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.header)
        Me.Name = "NCMEASURES"
        Me.Size = New System.Drawing.Size(1153, 510)
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RemarksEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RankEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents MainGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents RemarksEdit As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents MainView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents NCID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Description As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DueDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RankCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NCNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Unit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Edited As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents WorkDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NCDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DoneDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RankEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents NCCorrectiveMeasureID As DevExpress.XtraGrid.Columns.GridColumn

End Class
