<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VERSIONUPDATE
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
        Me.XtraScrollableControl1 = New DevExpress.XtraEditors.XtraScrollableControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.lblNote = New DevExpress.XtraEditors.LabelControl()
        Me.txtUpdatesFolder = New DevExpress.XtraEditors.ButtonEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.MainGrid = New DevExpress.XtraGrid.GridControl()
        Me.MainView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.VersionNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.VersionDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.VersionDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.memoDesc = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.lblDir = New DevExpress.XtraEditors.LabelControl()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        Me.XtraScrollableControl1.SuspendLayout()
        CType(Me.txtUpdatesFolder.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.memoDesc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'header
        '
        Me.header.AppearanceCaption.Options.UseFont = True
        Me.header.Controls.Add(Me.XtraScrollableControl1)
        Me.header.Dock = System.Windows.Forms.DockStyle.Fill
        Me.header.Location = New System.Drawing.Point(0, 0)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(859, 367)
        Me.header.TabIndex = 46
        Me.header.Text = "PRODUCT VERSION"
        '
        'XtraScrollableControl1
        '
        Me.XtraScrollableControl1.Controls.Add(Me.LabelControl2)
        Me.XtraScrollableControl1.Controls.Add(Me.lblNote)
        Me.XtraScrollableControl1.Controls.Add(Me.txtUpdatesFolder)
        Me.XtraScrollableControl1.Controls.Add(Me.LabelControl1)
        Me.XtraScrollableControl1.Controls.Add(Me.MainGrid)
        Me.XtraScrollableControl1.Controls.Add(Me.lblDir)
        Me.XtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraScrollableControl1.Location = New System.Drawing.Point(2, 30)
        Me.XtraScrollableControl1.Name = "XtraScrollableControl1"
        Me.XtraScrollableControl1.Size = New System.Drawing.Size(855, 335)
        Me.XtraScrollableControl1.TabIndex = 47
        '
        'LabelControl2
        '
        Me.LabelControl2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl2.Appearance.ForeColor = System.Drawing.Color.Red
        Me.LabelControl2.Location = New System.Drawing.Point(26, 71)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(341, 13)
        Me.LabelControl2.TabIndex = 82
        Me.LabelControl2.Text = "(  Example : * Updates Folder: \\server\shared_folder\PMS_UPDATES )"
        '
        'lblNote
        '
        Me.lblNote.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNote.Appearance.ForeColor = System.Drawing.Color.Red
        Me.lblNote.Location = New System.Drawing.Point(26, 44)
        Me.lblNote.Name = "lblNote"
        Me.lblNote.Size = New System.Drawing.Size(838, 13)
        Me.lblNote.TabIndex = 81
        Me.lblNote.Text = "Note:  It is mandatory that the updates folder set on this section is a dedicated" & _
    " common SHARED folder on your network in order for the auto update of PMS to wor" & _
    "k properly."
        '
        'txtUpdatesFolder
        '
        Me.txtUpdatesFolder.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUpdatesFolder.Location = New System.Drawing.Point(115, 13)
        Me.txtUpdatesFolder.Name = "txtUpdatesFolder"
        Me.txtUpdatesFolder.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)})
        Me.txtUpdatesFolder.Size = New System.Drawing.Size(719, 20)
        Me.txtUpdatesFolder.TabIndex = 80
        '
        'LabelControl1
        '
        Me.LabelControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl1.Location = New System.Drawing.Point(23, 16)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(86, 13)
        Me.LabelControl1.TabIndex = 79
        Me.LabelControl1.Text = "* Updates Folder:"
        '
        'MainGrid
        '
        Me.MainGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MainGrid.Location = New System.Drawing.Point(22, 96)
        Me.MainGrid.LookAndFeel.SkinName = "iMaginary"
        Me.MainGrid.MainView = Me.MainView
        Me.MainGrid.Name = "MainGrid"
        Me.MainGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.memoDesc})
        Me.MainGrid.Size = New System.Drawing.Size(812, 225)
        Me.MainGrid.TabIndex = 78
        Me.MainGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MainView})
        '
        'MainView
        '
        Me.MainView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.MainView.Appearance.RowSeparator.Options.UseBackColor = True
        Me.MainView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.VersionNo, Me.VersionDate, Me.VersionDesc})
        Me.MainView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.MainView.GridControl = Me.MainGrid
        Me.MainView.Name = "MainView"
        Me.MainView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.MainView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.MainView.OptionsBehavior.AutoPopulateColumns = False
        Me.MainView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.MainView.OptionsBehavior.Editable = False
        Me.MainView.OptionsCustomization.AllowColumnMoving = False
        Me.MainView.OptionsCustomization.AllowFilter = False
        Me.MainView.OptionsCustomization.AllowGroup = False
        Me.MainView.OptionsCustomization.AllowQuickHideColumns = False
        Me.MainView.OptionsCustomization.AllowSort = False
        Me.MainView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.MainView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.MainView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.MainView.OptionsSelection.UseIndicatorForSelection = False
        Me.MainView.OptionsView.RowAutoHeight = True
        Me.MainView.OptionsView.ShowGroupPanel = False
        Me.MainView.OptionsView.ShowIndicator = False
        '
        'VersionNo
        '
        Me.VersionNo.Caption = "Version"
        Me.VersionNo.DisplayFormat.FormatString = "f"
        Me.VersionNo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.VersionNo.FieldName = "VersionNo"
        Me.VersionNo.Name = "VersionNo"
        Me.VersionNo.Visible = True
        Me.VersionNo.VisibleIndex = 0
        Me.VersionNo.Width = 162
        '
        'VersionDate
        '
        Me.VersionDate.Caption = "Date"
        Me.VersionDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.VersionDate.FieldName = "VersionDate"
        Me.VersionDate.Name = "VersionDate"
        Me.VersionDate.OptionsColumn.ReadOnly = True
        Me.VersionDate.Visible = True
        Me.VersionDate.VisibleIndex = 1
        Me.VersionDate.Width = 351
        '
        'VersionDesc
        '
        Me.VersionDesc.Caption = "Description"
        Me.VersionDesc.ColumnEdit = Me.memoDesc
        Me.VersionDesc.FieldName = "VersionDesc"
        Me.VersionDesc.Name = "VersionDesc"
        Me.VersionDesc.Visible = True
        Me.VersionDesc.VisibleIndex = 2
        Me.VersionDesc.Width = 651
        '
        'memoDesc
        '
        Me.memoDesc.Name = "memoDesc"
        '
        'lblDir
        '
        Me.lblDir.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        Me.lblDir.Location = New System.Drawing.Point(105, 26)
        Me.lblDir.Name = "lblDir"
        Me.lblDir.Size = New System.Drawing.Size(522, 13)
        Me.lblDir.TabIndex = 14
        Me.lblDir.Text = " "
        '
        'VERSIONUPDATE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScroll = True
        Me.Controls.Add(Me.header)
        Me.Name = "VERSIONUPDATE"
        Me.Size = New System.Drawing.Size(859, 367)
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        Me.XtraScrollableControl1.ResumeLayout(False)
        Me.XtraScrollableControl1.PerformLayout()
        CType(Me.txtUpdatesFolder.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.memoDesc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents XtraScrollableControl1 As DevExpress.XtraEditors.XtraScrollableControl
    Friend WithEvents lblDir As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MainGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents MainView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents VersionNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents VersionDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents VersionDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtUpdatesFolder As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblNote As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents memoDesc As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit

End Class
