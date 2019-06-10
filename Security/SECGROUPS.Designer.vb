<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SECGROUPS
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
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtFilter = New DevExpress.XtraEditors.LookUpEdit()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.UserGrid = New DevExpress.XtraGrid.GridControl()
        Me.UserView = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.UserID = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Selected = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Crew = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.UserEdited = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.txtName = New DevExpress.XtraEditors.TextEdit()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.MainGrid = New DevExpress.XtraGrid.GridControl()
        Me.MainView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.SecObjectID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ObjectID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Caption = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.HasFullPermission = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.HasOpen = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.HasAdd = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.HasEdit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.HasDelete = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Edited = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MaxPermission = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Category = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CategoryCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.lalbel1 = New DevExpress.XtraEditors.LabelControl()
        Me.HasImport = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.txtFilter.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.UserGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UserView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'header
        '
        Me.header.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.header.AppearanceCaption.Options.UseFont = True
        Me.header.Controls.Add(Me.LabelControl1)
        Me.header.Controls.Add(Me.txtFilter)
        Me.header.Controls.Add(Me.GroupControl2)
        Me.header.Controls.Add(Me.txtName)
        Me.header.Controls.Add(Me.GroupControl1)
        Me.header.Controls.Add(Me.lalbel1)
        Me.header.Dock = System.Windows.Forms.DockStyle.Fill
        Me.header.Location = New System.Drawing.Point(0, 0)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(1069, 569)
        Me.header.TabIndex = 36
        Me.header.Text = "Edit Group"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(756, 46)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(28, 13)
        Me.LabelControl1.TabIndex = 14
        Me.LabelControl1.Text = "Filter:"
        '
        'txtFilter
        '
        Me.txtFilter.Location = New System.Drawing.Point(790, 42)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFilter.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Category", "Category")})
        Me.txtFilter.Properties.DisplayMember = "Category"
        Me.txtFilter.Properties.DropDownRows = 10
        Me.txtFilter.Properties.NullText = ""
        Me.txtFilter.Properties.ShowFooter = False
        Me.txtFilter.Properties.ShowHeader = False
        Me.txtFilter.Properties.ValueMember = "Category"
        Me.txtFilter.Size = New System.Drawing.Size(250, 20)
        Me.txtFilter.TabIndex = 13
        '
        'GroupControl2
        '
        Me.GroupControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupControl2.Appearance.Options.UseFont = True
        Me.GroupControl2.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupControl2.AppearanceCaption.Options.UseFont = True
        Me.GroupControl2.Controls.Add(Me.UserGrid)
        Me.GroupControl2.Location = New System.Drawing.Point(27, 80)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(282, 457)
        Me.GroupControl2.TabIndex = 11
        Me.GroupControl2.Text = "Users"
        '
        'UserGrid
        '
        Me.UserGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UserGrid.Location = New System.Drawing.Point(2, 23)
        Me.UserGrid.LookAndFeel.SkinName = "iMaginary"
        Me.UserGrid.MainView = Me.UserView
        Me.UserGrid.Name = "UserGrid"
        Me.UserGrid.Size = New System.Drawing.Size(278, 432)
        Me.UserGrid.TabIndex = 4
        Me.UserGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.UserView})
        '
        'UserView
        '
        Me.UserView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.UserView.Appearance.RowSeparator.Options.UseBackColor = True
        Me.UserView.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1})
        Me.UserView.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.UserID, Me.Selected, Me.Crew, Me.UserEdited})
        Me.UserView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.UserView.GridControl = Me.UserGrid
        Me.UserView.Name = "UserView"
        Me.UserView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.UserView.OptionsBehavior.AutoPopulateColumns = False
        Me.UserView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.UserView.OptionsCustomization.AllowColumnMoving = False
        Me.UserView.OptionsCustomization.AllowColumnResizing = False
        Me.UserView.OptionsCustomization.AllowFilter = False
        Me.UserView.OptionsCustomization.AllowGroup = False
        Me.UserView.OptionsCustomization.AllowQuickHideColumns = False
        Me.UserView.OptionsCustomization.AllowSort = False
        Me.UserView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.UserView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.UserView.OptionsSelection.InvertSelection = True
        Me.UserView.OptionsSelection.UseIndicatorForSelection = False
        Me.UserView.OptionsView.ShowColumnHeaders = False
        Me.UserView.OptionsView.ShowGroupPanel = False
        '
        'GridBand1
        '
        Me.GridBand1.Caption = "Select User"
        Me.GridBand1.Columns.Add(Me.UserID)
        Me.GridBand1.Columns.Add(Me.Selected)
        Me.GridBand1.Columns.Add(Me.Crew)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 105
        '
        'UserID
        '
        Me.UserID.FieldName = "UserID"
        Me.UserID.Name = "UserID"
        '
        'Selected
        '
        Me.Selected.Caption = "Selected"
        Me.Selected.FieldName = "Selected"
        Me.Selected.Name = "Selected"
        Me.Selected.Visible = True
        Me.Selected.Width = 30
        '
        'Crew
        '
        Me.Crew.Caption = "User"
        Me.Crew.FieldName = "Crew"
        Me.Crew.Name = "Crew"
        Me.Crew.OptionsColumn.AllowEdit = False
        Me.Crew.OptionsColumn.ReadOnly = True
        Me.Crew.Visible = True
        '
        'UserEdited
        '
        Me.UserEdited.Caption = "UserEdited"
        Me.UserEdited.FieldName = "UserEdited"
        Me.UserEdited.Name = "UserEdited"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(105, 41)
        Me.txtName.Name = "txtName"
        Me.txtName.Properties.MaxLength = 50
        Me.txtName.Size = New System.Drawing.Size(202, 20)
        Me.txtName.TabIndex = 12
        '
        'GroupControl1
        '
        Me.GroupControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupControl1.Appearance.Options.UseFont = True
        Me.GroupControl1.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupControl1.AppearanceCaption.Options.UseFont = True
        Me.GroupControl1.Controls.Add(Me.MainGrid)
        Me.GroupControl1.Location = New System.Drawing.Point(320, 80)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(720, 457)
        Me.GroupControl1.TabIndex = 10
        Me.GroupControl1.Text = "Permissions"
        '
        'MainGrid
        '
        Me.MainGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainGrid.Location = New System.Drawing.Point(2, 23)
        Me.MainGrid.LookAndFeel.SkinName = "iMaginary"
        Me.MainGrid.MainView = Me.MainView
        Me.MainGrid.Name = "MainGrid"
        Me.MainGrid.Size = New System.Drawing.Size(716, 432)
        Me.MainGrid.TabIndex = 4
        Me.MainGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MainView})
        '
        'MainView
        '
        Me.MainView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.MainView.Appearance.RowSeparator.Options.UseBackColor = True
        Me.MainView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.SecObjectID, Me.ObjectID, Me.Caption, Me.HasFullPermission, Me.HasOpen, Me.HasAdd, Me.HasEdit, Me.HasDelete, Me.HasImport, Me.Edited, Me.MaxPermission, Me.Category, Me.CategoryCode})
        Me.MainView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.MainView.GridControl = Me.MainGrid
        Me.MainView.Name = "MainView"
        Me.MainView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.MainView.OptionsBehavior.AutoPopulateColumns = False
        Me.MainView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.MainView.OptionsCustomization.AllowColumnMoving = False
        Me.MainView.OptionsCustomization.AllowColumnResizing = False
        Me.MainView.OptionsCustomization.AllowFilter = False
        Me.MainView.OptionsCustomization.AllowGroup = False
        Me.MainView.OptionsCustomization.AllowQuickHideColumns = False
        Me.MainView.OptionsCustomization.AllowSort = False
        Me.MainView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.MainView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.MainView.OptionsSelection.InvertSelection = True
        Me.MainView.OptionsSelection.UseIndicatorForSelection = False
        Me.MainView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.MainView.OptionsView.ShowGroupPanel = False
        '
        'SecObjectID
        '
        Me.SecObjectID.Caption = "SecObjectID"
        Me.SecObjectID.FieldName = "SecObjectID"
        Me.SecObjectID.Name = "SecObjectID"
        '
        'ObjectID
        '
        Me.ObjectID.Caption = "ObjectID"
        Me.ObjectID.FieldName = "ObjectID"
        Me.ObjectID.Name = "ObjectID"
        '
        'Caption
        '
        Me.Caption.Caption = "Form/Report"
        Me.Caption.FieldName = "Caption"
        Me.Caption.MinWidth = 170
        Me.Caption.Name = "Caption"
        Me.Caption.OptionsColumn.AllowEdit = False
        Me.Caption.OptionsColumn.ReadOnly = True
        Me.Caption.Visible = True
        Me.Caption.VisibleIndex = 0
        Me.Caption.Width = 170
        '
        'HasFullPermission
        '
        Me.HasFullPermission.Caption = "Full Permission"
        Me.HasFullPermission.FieldName = "HasFullPermission"
        Me.HasFullPermission.MaxWidth = 85
        Me.HasFullPermission.MinWidth = 80
        Me.HasFullPermission.Name = "HasFullPermission"
        Me.HasFullPermission.Visible = True
        Me.HasFullPermission.VisibleIndex = 1
        Me.HasFullPermission.Width = 80
        '
        'HasOpen
        '
        Me.HasOpen.Caption = "Open/Read"
        Me.HasOpen.FieldName = "HasOpen"
        Me.HasOpen.MaxWidth = 70
        Me.HasOpen.Name = "HasOpen"
        Me.HasOpen.Visible = True
        Me.HasOpen.VisibleIndex = 2
        Me.HasOpen.Width = 65
        '
        'HasAdd
        '
        Me.HasAdd.Caption = "Add"
        Me.HasAdd.FieldName = "HasAdd"
        Me.HasAdd.MaxWidth = 60
        Me.HasAdd.Name = "HasAdd"
        Me.HasAdd.Visible = True
        Me.HasAdd.VisibleIndex = 3
        Me.HasAdd.Width = 50
        '
        'HasEdit
        '
        Me.HasEdit.Caption = "Update"
        Me.HasEdit.FieldName = "HasEdit"
        Me.HasEdit.MaxWidth = 60
        Me.HasEdit.Name = "HasEdit"
        Me.HasEdit.Visible = True
        Me.HasEdit.VisibleIndex = 4
        Me.HasEdit.Width = 60
        '
        'HasDelete
        '
        Me.HasDelete.Caption = "Delete"
        Me.HasDelete.FieldName = "HasDelete"
        Me.HasDelete.MaxWidth = 60
        Me.HasDelete.Name = "HasDelete"
        Me.HasDelete.Visible = True
        Me.HasDelete.VisibleIndex = 5
        Me.HasDelete.Width = 60
        '
        'Edited
        '
        Me.Edited.Caption = "Edited"
        Me.Edited.FieldName = "Edited"
        Me.Edited.Name = "Edited"
        '
        'MaxPermission
        '
        Me.MaxPermission.Caption = "MaxPermission"
        Me.MaxPermission.FieldName = "MaxPermission"
        Me.MaxPermission.Name = "MaxPermission"
        '
        'Category
        '
        Me.Category.Caption = "Category"
        Me.Category.FieldName = "Category"
        Me.Category.Name = "Category"
        '
        'CategoryCode
        '
        Me.CategoryCode.Caption = "CategoryCode"
        Me.CategoryCode.FieldName = "CategoryCode"
        Me.CategoryCode.Name = "CategoryCode"
        '
        'lalbel1
        '
        Me.lalbel1.Location = New System.Drawing.Point(27, 44)
        Me.lalbel1.Name = "lalbel1"
        Me.lalbel1.Size = New System.Drawing.Size(72, 13)
        Me.lalbel1.TabIndex = 7
        Me.lalbel1.Text = "* Group Name:"
        '
        'HasImport
        '
        Me.HasImport.Caption = "Import"
        Me.HasImport.FieldName = "HasImport"
        Me.HasImport.MaxWidth = 60
        Me.HasImport.Name = "HasImport"
        Me.HasImport.Visible = True
        Me.HasImport.VisibleIndex = 6
        Me.HasImport.Width = 60
        '
        'SECGROUPS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.header)
        Me.Name = "SECGROUPS"
        Me.Size = New System.Drawing.Size(1069, 569)
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        Me.header.PerformLayout()
        CType(Me.txtFilter.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.UserGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UserView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents MainGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents MainView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ObjectID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Caption As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents HasOpen As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents HasAdd As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents HasEdit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Edited As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lalbel1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents HasDelete As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents HasFullPermission As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MaxPermission As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SecObjectID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents UserGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents UserView As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents UserID As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Selected As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Crew As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents UserEdited As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtFilter As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Category As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CategoryCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents HasImport As DevExpress.XtraGrid.Columns.GridColumn

End Class
