<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMaintenance
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMaintenance))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.txtInsDesc = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtInsCrossRef = New DevExpress.XtraEditors.TextEdit()
        Me.txtInsDateIssued = New DevExpress.XtraEditors.DateEdit()
        Me.txtInsEditor = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.cboWorkCode = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.txtNumber = New DevExpress.XtraEditors.TextEdit()
        Me.cboIntCode = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboRankCode = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.chkPreventive = New DevExpress.XtraEditors.CheckEdit()
        Me.cmdBrowse = New DevExpress.XtraEditors.SimpleButton()
        Me.MainGrid = New DevExpress.XtraGrid.GridControl()
        Me.MainView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.FileDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DocID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FileName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Delete = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DeleteEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.Doc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        CType(Me.txtInsDesc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInsCrossRef.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInsDateIssued.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInsDateIssued.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInsEditor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboWorkCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboIntCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboRankCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPreventive.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DeleteEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(258, 353)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(86, 23)
        Me.cmdOk.TabIndex = 9
        Me.cmdOk.Text = "Done"
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(352, 353)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(82, 23)
        Me.cmdCancel.TabIndex = 10
        Me.cmdCancel.Text = "Cancel"
        '
        'txtInsDesc
        '
        Me.txtInsDesc.Location = New System.Drawing.Point(22, 241)
        Me.txtInsDesc.Name = "txtInsDesc"
        Me.txtInsDesc.Size = New System.Drawing.Size(236, 98)
        Me.txtInsDesc.TabIndex = 8
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(22, 222)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(123, 13)
        Me.LabelControl10.TabIndex = 196
        Me.LabelControl10.Text = "Instruction to be followed"
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(209, 171)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(28, 13)
        Me.LabelControl8.TabIndex = 194
        Me.LabelControl8.Text = "Editor"
        '
        'LabelControl9
        '
        Me.LabelControl9.Location = New System.Drawing.Point(22, 171)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(58, 13)
        Me.LabelControl9.TabIndex = 192
        Me.LabelControl9.Text = "Date Issued"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(22, 123)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(113, 13)
        Me.LabelControl1.TabIndex = 188
        Me.LabelControl1.Text = "Cross Ref. from manual"
        '
        'txtInsCrossRef
        '
        Me.txtInsCrossRef.Location = New System.Drawing.Point(22, 142)
        Me.txtInsCrossRef.Name = "txtInsCrossRef"
        Me.txtInsCrossRef.Size = New System.Drawing.Size(412, 20)
        Me.txtInsCrossRef.TabIndex = 5
        '
        'txtInsDateIssued
        '
        Me.txtInsDateIssued.EditValue = Nothing
        Me.txtInsDateIssued.Location = New System.Drawing.Point(22, 190)
        Me.txtInsDateIssued.Name = "txtInsDateIssued"
        Me.txtInsDateIssued.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtInsDateIssued.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtInsDateIssued.Properties.MaxLength = 30
        Me.txtInsDateIssued.Size = New System.Drawing.Size(187, 20)
        Me.txtInsDateIssued.TabIndex = 6
        '
        'txtInsEditor
        '
        Me.txtInsEditor.Location = New System.Drawing.Point(208, 190)
        Me.txtInsEditor.Name = "txtInsEditor"
        Me.txtInsEditor.Properties.MaxLength = 30
        Me.txtInsEditor.Size = New System.Drawing.Size(226, 20)
        Me.txtInsEditor.TabIndex = 7
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(22, 18)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(70, 13)
        Me.LabelControl3.TabIndex = 200
        Me.LabelControl3.Text = "* Maintenance"
        '
        'cboWorkCode
        '
        Me.cboWorkCode.Location = New System.Drawing.Point(22, 37)
        Me.cboWorkCode.Name = "cboWorkCode"
        Me.cboWorkCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboWorkCode.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("WorkCode", "WorkCode", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Maintenance", "Maintenance")})
        Me.cboWorkCode.Properties.DisplayMember = "Maintenance"
        Me.cboWorkCode.Properties.DropDownRows = 10
        Me.cboWorkCode.Properties.NullText = ""
        Me.cboWorkCode.Properties.ShowFooter = False
        Me.cboWorkCode.Properties.ShowHeader = False
        Me.cboWorkCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboWorkCode.Properties.ValueMember = "WorkCode"
        Me.cboWorkCode.Size = New System.Drawing.Size(187, 20)
        Me.cboWorkCode.TabIndex = 0
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(208, 18)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(73, 13)
        Me.LabelControl5.TabIndex = 204
        Me.LabelControl5.Text = "To be done by:"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(339, 62)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl6.TabIndex = 207
        Me.LabelControl6.Text = "Number"
        '
        'txtNumber
        '
        Me.txtNumber.EditValue = ""
        Me.txtNumber.Location = New System.Drawing.Point(338, 79)
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.Properties.Appearance.Options.UseTextOptions = True
        Me.txtNumber.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtNumber.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtNumber.Properties.Mask.EditMask = "\d+"
        Me.txtNumber.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.txtNumber.Size = New System.Drawing.Size(96, 20)
        Me.txtNumber.TabIndex = 3
        '
        'cboIntCode
        '
        Me.cboIntCode.Location = New System.Drawing.Point(208, 79)
        Me.cboIntCode.Name = "cboIntCode"
        Me.cboIntCode.Properties.AutoSearchColumnIndex = 1
        Me.cboIntCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboIntCode.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("IntCode", "", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("IntName", "Name")})
        Me.cboIntCode.Properties.DisplayMember = "IntName"
        Me.cboIntCode.Properties.DropDownRows = 10
        Me.cboIntCode.Properties.NullText = ""
        Me.cboIntCode.Properties.ShowFooter = False
        Me.cboIntCode.Properties.ShowHeader = False
        Me.cboIntCode.Properties.ValueMember = "IntCode"
        Me.cboIntCode.Size = New System.Drawing.Size(131, 20)
        Me.cboIntCode.TabIndex = 4
        '
        'cboRankCode
        '
        Me.cboRankCode.Location = New System.Drawing.Point(208, 37)
        Me.cboRankCode.Name = "cboRankCode"
        Me.cboRankCode.Properties.AutoSearchColumnIndex = 1
        Me.cboRankCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboRankCode.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("RankCode", "", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("RankDesc", "Name")})
        Me.cboRankCode.Properties.DisplayMember = "RankDesc"
        Me.cboRankCode.Properties.DropDownRows = 10
        Me.cboRankCode.Properties.NullText = ""
        Me.cboRankCode.Properties.ShowFooter = False
        Me.cboRankCode.Properties.ShowHeader = False
        Me.cboRankCode.Properties.ValueMember = "RankCode"
        Me.cboRankCode.Size = New System.Drawing.Size(226, 20)
        Me.cboRankCode.TabIndex = 1
        '
        'LabelControl11
        '
        Me.LabelControl11.Location = New System.Drawing.Point(209, 63)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl11.TabIndex = 206
        Me.LabelControl11.Text = "Type"
        '
        'chkPreventive
        '
        Me.chkPreventive.EditValue = True
        Me.chkPreventive.Location = New System.Drawing.Point(22, 79)
        Me.chkPreventive.Name = "chkPreventive"
        Me.chkPreventive.Properties.AutoWidth = True
        Me.chkPreventive.Properties.Caption = "Preventive Maintenance"
        Me.chkPreventive.Size = New System.Drawing.Size(138, 19)
        Me.chkPreventive.TabIndex = 2
        '
        'cmdBrowse
        '
        Me.cmdBrowse.Location = New System.Drawing.Point(258, 217)
        Me.cmdBrowse.Name = "cmdBrowse"
        Me.cmdBrowse.Size = New System.Drawing.Size(176, 23)
        Me.cmdBrowse.TabIndex = 209
        Me.cmdBrowse.Text = "Attach"
        '
        'MainGrid
        '
        Me.MainGrid.Location = New System.Drawing.Point(258, 241)
        Me.MainGrid.LookAndFeel.SkinName = "iMaginary"
        Me.MainGrid.MainView = Me.MainView
        Me.MainGrid.Name = "MainGrid"
        Me.MainGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemLookUpEdit2, Me.DeleteEdit})
        Me.MainGrid.Size = New System.Drawing.Size(176, 98)
        Me.MainGrid.TabIndex = 210
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
        Me.MainView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.FileDesc, Me.DocID, Me.FileName, Me.Delete, Me.Doc})
        Me.MainView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.MainView.GridControl = Me.MainGrid
        Me.MainView.Name = "MainView"
        Me.MainView.NewItemRowText = "Click here to add new record"
        Me.MainView.OptionsBehavior.AutoPopulateColumns = False
        Me.MainView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.MainView.OptionsBehavior.ReadOnly = True
        Me.MainView.OptionsCustomization.AllowColumnMoving = False
        Me.MainView.OptionsCustomization.AllowColumnResizing = False
        Me.MainView.OptionsCustomization.AllowFilter = False
        Me.MainView.OptionsCustomization.AllowGroup = False
        Me.MainView.OptionsCustomization.AllowQuickHideColumns = False
        Me.MainView.OptionsCustomization.AllowSort = False
        Me.MainView.OptionsFilter.AllowFilterEditor = False
        Me.MainView.OptionsFind.AllowFindPanel = False
        Me.MainView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.MainView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.MainView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.MainView.OptionsSelection.UseIndicatorForSelection = False
        Me.MainView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button
        Me.MainView.OptionsView.RowAutoHeight = True
        Me.MainView.OptionsView.ShowColumnHeaders = False
        Me.MainView.OptionsView.ShowGroupPanel = False
        '
        'FileDesc
        '
        Me.FileDesc.Caption = "FileDesc"
        Me.FileDesc.FieldName = "FileDesc"
        Me.FileDesc.Name = "FileDesc"
        Me.FileDesc.OptionsColumn.AllowEdit = False
        Me.FileDesc.OptionsColumn.ReadOnly = True
        Me.FileDesc.Visible = True
        Me.FileDesc.VisibleIndex = 0
        Me.FileDesc.Width = 169
        '
        'DocID
        '
        Me.DocID.Caption = "DocID"
        Me.DocID.FieldName = "DocID"
        Me.DocID.Name = "DocID"
        '
        'FileName
        '
        Me.FileName.Caption = "File Name"
        Me.FileName.FieldName = "FileName"
        Me.FileName.MaxWidth = 55
        Me.FileName.MinWidth = 55
        Me.FileName.Name = "FileName"
        Me.FileName.OptionsColumn.AllowEdit = False
        Me.FileName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.FileName.OptionsColumn.ReadOnly = True
        Me.FileName.Width = 55
        '
        'Delete
        '
        Me.Delete.Caption = "Delete"
        Me.Delete.ColumnEdit = Me.DeleteEdit
        Me.Delete.MaxWidth = 20
        Me.Delete.Name = "Delete"
        Me.Delete.Visible = True
        Me.Delete.VisibleIndex = 1
        Me.Delete.Width = 20
        '
        'DeleteEdit
        '
        Me.DeleteEdit.AutoHeight = False
        Me.DeleteEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, CType(resources.GetObject("DeleteEdit.Buttons"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.DeleteEdit.Name = "DeleteEdit"
        Me.DeleteEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'Doc
        '
        Me.Doc.Caption = "Doc"
        Me.Doc.FieldName = "Doc"
        Me.Doc.Name = "Doc"
        '
        'RepositoryItemLookUpEdit2
        '
        Me.RepositoryItemLookUpEdit2.AutoHeight = False
        Me.RepositoryItemLookUpEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit2.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CounterCode", "Name10", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Counter", "Name12")})
        Me.RepositoryItemLookUpEdit2.DisplayMember = "Counter"
        Me.RepositoryItemLookUpEdit2.DropDownRows = 10
        Me.RepositoryItemLookUpEdit2.Name = "RepositoryItemLookUpEdit2"
        Me.RepositoryItemLookUpEdit2.NullText = ""
        Me.RepositoryItemLookUpEdit2.ShowFooter = False
        Me.RepositoryItemLookUpEdit2.ShowHeader = False
        Me.RepositoryItemLookUpEdit2.ValueMember = "CounterCode"
        '
        'frmMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(460, 396)
        Me.Controls.Add(Me.MainGrid)
        Me.Controls.Add(Me.cmdBrowse)
        Me.Controls.Add(Me.chkPreventive)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.txtNumber)
        Me.Controls.Add(Me.cboIntCode)
        Me.Controls.Add(Me.cboRankCode)
        Me.Controls.Add(Me.LabelControl11)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.cboWorkCode)
        Me.Controls.Add(Me.txtInsDesc)
        Me.Controls.Add(Me.LabelControl10)
        Me.Controls.Add(Me.LabelControl8)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.LabelControl9)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.txtInsEditor)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.txtInsDateIssued)
        Me.Controls.Add(Me.txtInsCrossRef)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMaintenance"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Maintenance"
        CType(Me.txtInsDesc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInsCrossRef.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInsDateIssued.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInsDateIssued.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInsEditor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboWorkCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboIntCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboRankCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPreventive.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DeleteEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtInsCrossRef As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtInsDesc As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtInsDateIssued As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtInsEditor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboWorkCode As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cboIntCode As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cboRankCode As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkPreventive As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cmdBrowse As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents MainGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents MainView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents FileDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DocID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FileName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents Delete As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DeleteEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents Doc As DevExpress.XtraGrid.Columns.GridColumn
End Class
