<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NONCONFORM
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NONCONFORM))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.MainGrid = New DevExpress.XtraGrid.GridControl()
        Me.MainView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.NCID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NCNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.WorkDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Unit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Department = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DiscoveredBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ReportedTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Description = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RemarksEdit = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.ImmediateAction = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Cause = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Objective = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Edited = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.bLatest = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DeptCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DeleteEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RemarksEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DeleteEdit, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.MainGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.DeleteEdit, Me.RemarksEdit})
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
        Me.MainView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.NCID, Me.NCNo, Me.WorkDate, Me.Unit, Me.Department, Me.DiscoveredBy, Me.ReportedTo, Me.Description, Me.ImmediateAction, Me.Cause, Me.Objective, Me.Status, Me.Edited, Me.bLatest, Me.DeptCode})
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
        Me.NCNo.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value
        Me.NCNo.Visible = True
        Me.NCNo.VisibleIndex = 0
        Me.NCNo.Width = 55
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
        Me.WorkDate.VisibleIndex = 1
        Me.WorkDate.Width = 100
        '
        'Unit
        '
        Me.Unit.Caption = "Unit"
        Me.Unit.FieldName = "Unit"
        Me.Unit.Name = "Unit"
        Me.Unit.Visible = True
        Me.Unit.VisibleIndex = 2
        Me.Unit.Width = 252
        '
        'Department
        '
        Me.Department.Caption = "Department"
        Me.Department.FieldName = "Department"
        Me.Department.MaxWidth = 90
        Me.Department.MinWidth = 90
        Me.Department.Name = "Department"
        Me.Department.Visible = True
        Me.Department.VisibleIndex = 3
        Me.Department.Width = 90
        '
        'DiscoveredBy
        '
        Me.DiscoveredBy.Caption = "DiscoveredBy"
        Me.DiscoveredBy.FieldName = "DiscoveredBy"
        Me.DiscoveredBy.Name = "DiscoveredBy"
        Me.DiscoveredBy.Visible = True
        Me.DiscoveredBy.VisibleIndex = 4
        Me.DiscoveredBy.Width = 141
        '
        'ReportedTo
        '
        Me.ReportedTo.Caption = "Reported To"
        Me.ReportedTo.FieldName = "ReportedTo"
        Me.ReportedTo.MinWidth = 75
        Me.ReportedTo.Name = "ReportedTo"
        Me.ReportedTo.Visible = True
        Me.ReportedTo.VisibleIndex = 5
        Me.ReportedTo.Width = 133
        '
        'Description
        '
        Me.Description.Caption = "Description"
        Me.Description.ColumnEdit = Me.RemarksEdit
        Me.Description.FieldName = "Description"
        Me.Description.Name = "Description"
        Me.Description.Visible = True
        Me.Description.VisibleIndex = 6
        Me.Description.Width = 179
        '
        'RemarksEdit
        '
        Me.RemarksEdit.Appearance.Options.UseTextOptions = True
        Me.RemarksEdit.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.RemarksEdit.Name = "RemarksEdit"
        '
        'ImmediateAction
        '
        Me.ImmediateAction.AppearanceCell.Options.UseFont = True
        Me.ImmediateAction.Caption = "Immediate Action"
        Me.ImmediateAction.ColumnEdit = Me.RemarksEdit
        Me.ImmediateAction.FieldName = "ImmediateAction"
        Me.ImmediateAction.MinWidth = 100
        Me.ImmediateAction.Name = "ImmediateAction"
        Me.ImmediateAction.Visible = True
        Me.ImmediateAction.VisibleIndex = 7
        Me.ImmediateAction.Width = 176
        '
        'Cause
        '
        Me.Cause.Caption = "Cause"
        Me.Cause.ColumnEdit = Me.RemarksEdit
        Me.Cause.FieldName = "Cause"
        Me.Cause.MinWidth = 105
        Me.Cause.Name = "Cause"
        Me.Cause.OptionsColumn.AllowEdit = False
        Me.Cause.OptionsColumn.ReadOnly = True
        Me.Cause.Visible = True
        Me.Cause.VisibleIndex = 8
        Me.Cause.Width = 177
        '
        'Objective
        '
        Me.Objective.Caption = "Objective"
        Me.Objective.ColumnEdit = Me.RemarksEdit
        Me.Objective.FieldName = "Objective"
        Me.Objective.Name = "Objective"
        Me.Objective.Visible = True
        Me.Objective.VisibleIndex = 9
        Me.Objective.Width = 276
        '
        'Status
        '
        Me.Status.Caption = "Status"
        Me.Status.FieldName = "Status"
        Me.Status.MaxWidth = 60
        Me.Status.Name = "Status"
        Me.Status.Visible = True
        Me.Status.VisibleIndex = 10
        Me.Status.Width = 55
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
        'DeptCode
        '
        Me.DeptCode.Caption = "DeptCode"
        Me.DeptCode.FieldName = "DeptCode"
        Me.DeptCode.Name = "DeptCode"
        '
        'DeleteEdit
        '
        Me.DeleteEdit.AutoHeight = False
        Me.DeleteEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, CType(resources.GetObject("DeleteEdit.Buttons"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.DeleteEdit.Name = "DeleteEdit"
        Me.DeleteEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'NONCONFORM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.header)
        Me.Name = "NONCONFORM"
        Me.Size = New System.Drawing.Size(1153, 510)
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RemarksEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DeleteEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents MainGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents RemarksEdit As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents DeleteEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents MainView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents NCID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents WorkDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Department As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Edited As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Description As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ImmediateAction As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Cause As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents bLatest As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ReportedTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DiscoveredBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NCNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Unit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Objective As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DeptCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Status As DevExpress.XtraGrid.Columns.GridColumn

End Class
