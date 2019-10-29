<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PART
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
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PART))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim GridLevelNode2 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.mGrid = New DevExpress.XtraGrid.GridControl()
        Me.mView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.DateMissing = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.mNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.mRemarks = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Part_MissingID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Edited = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Delete = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DeleteEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.RepositoryItemLookUpEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.cmdAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.cboStorageCode = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.cboLocCode = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblLocation = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.aGrid = New DevExpress.XtraGrid.GridControl()
        Me.aView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.DateReceived = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ReceivedQuantity = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Vendor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.gConsumed = New DevExpress.XtraEditors.GroupControl()
        Me.cGrid = New DevExpress.XtraGrid.GridControl()
        Me.cView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.DateConsumed = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Remarks = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.txtInitStock = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.txtMinimum = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtOnStock = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtPartNumber = New DevExpress.XtraEditors.TextEdit()
        Me.txtName = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.mGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DeleteEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboStorageCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboLocCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.aGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.aView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gConsumed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gConsumed.SuspendLayout()
        CType(Me.cGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInitStock.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMinimum.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOnStock.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPartNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl12
        '
        Me.LabelControl12.Location = New System.Drawing.Point(15, 37)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(29, 13)
        Me.LabelControl12.TabIndex = 31
        Me.LabelControl12.Text = "* Part"
        '
        'header
        '
        Me.header.AppearanceCaption.Options.UseFont = True
        Me.header.Controls.Add(Me.GroupControl2)
        Me.header.Controls.Add(Me.cmdAdd)
        Me.header.Controls.Add(Me.cboStorageCode)
        Me.header.Controls.Add(Me.LabelControl5)
        Me.header.Controls.Add(Me.cboLocCode)
        Me.header.Controls.Add(Me.lblLocation)
        Me.header.Controls.Add(Me.GroupControl1)
        Me.header.Controls.Add(Me.gConsumed)
        Me.header.Controls.Add(Me.txtInitStock)
        Me.header.Controls.Add(Me.LabelControl4)
        Me.header.Controls.Add(Me.txtMinimum)
        Me.header.Controls.Add(Me.LabelControl2)
        Me.header.Controls.Add(Me.txtOnStock)
        Me.header.Controls.Add(Me.LabelControl1)
        Me.header.Controls.Add(Me.txtPartNumber)
        Me.header.Controls.Add(Me.txtName)
        Me.header.Controls.Add(Me.LabelControl3)
        Me.header.Controls.Add(Me.LabelControl12)
        Me.header.Dock = System.Windows.Forms.DockStyle.Fill
        Me.header.Location = New System.Drawing.Point(0, 0)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(834, 604)
        Me.header.TabIndex = 36
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.mGrid)
        Me.GroupControl2.Location = New System.Drawing.Point(429, 335)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(386, 254)
        Me.GroupControl2.TabIndex = 215
        Me.GroupControl2.Text = "Missing"
        '
        'mGrid
        '
        Me.mGrid.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.RelationName = "Level1"
        Me.mGrid.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.mGrid.Location = New System.Drawing.Point(2, 20)
        Me.mGrid.LookAndFeel.SkinName = "iMaginary"
        Me.mGrid.MainView = Me.mView
        Me.mGrid.Name = "mGrid"
        Me.mGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemLookUpEdit3, Me.DeleteEdit})
        Me.mGrid.Size = New System.Drawing.Size(382, 232)
        Me.mGrid.TabIndex = 11
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
        Me.mView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.DateMissing, Me.mNumber, Me.mRemarks, Me.Part_MissingID, Me.Edited, Me.Delete})
        Me.mView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.mView.GridControl = Me.mGrid
        Me.mView.Name = "mView"
        Me.mView.NewItemRowText = "Click here to add new record"
        Me.mView.OptionsBehavior.AutoPopulateColumns = False
        Me.mView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.mView.OptionsCustomization.AllowColumnMoving = False
        Me.mView.OptionsCustomization.AllowColumnResizing = False
        Me.mView.OptionsCustomization.AllowFilter = False
        Me.mView.OptionsCustomization.AllowGroup = False
        Me.mView.OptionsCustomization.AllowQuickHideColumns = False
        Me.mView.OptionsCustomization.AllowSort = False
        Me.mView.OptionsFilter.AllowFilterEditor = False
        Me.mView.OptionsFind.AllowFindPanel = False
        Me.mView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.mView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.mView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.mView.OptionsSelection.UseIndicatorForSelection = False
        Me.mView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button
        Me.mView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.mView.OptionsView.RowAutoHeight = True
        Me.mView.OptionsView.ShowGroupPanel = False
        '
        'DateMissing
        '
        Me.DateMissing.Caption = "Date Missing"
        Me.DateMissing.DisplayFormat.FormatString = "d"
        Me.DateMissing.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateMissing.FieldName = "DateMissing"
        Me.DateMissing.MaxWidth = 90
        Me.DateMissing.MinWidth = 90
        Me.DateMissing.Name = "DateMissing"
        Me.DateMissing.UnboundExpression = "'Counter ' + [Counter]"
        Me.DateMissing.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.DateMissing.Visible = True
        Me.DateMissing.VisibleIndex = 0
        Me.DateMissing.Width = 90
        '
        'mNumber
        '
        Me.mNumber.Caption = "Quantity"
        Me.mNumber.FieldName = "Number"
        Me.mNumber.MaxWidth = 70
        Me.mNumber.MinWidth = 70
        Me.mNumber.Name = "mNumber"
        Me.mNumber.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.mNumber.Visible = True
        Me.mNumber.VisibleIndex = 1
        Me.mNumber.Width = 70
        '
        'mRemarks
        '
        Me.mRemarks.Caption = "Description"
        Me.mRemarks.FieldName = "Remarks"
        Me.mRemarks.Name = "mRemarks"
        Me.mRemarks.Visible = True
        Me.mRemarks.VisibleIndex = 2
        Me.mRemarks.Width = 184
        '
        'Part_MissingID
        '
        Me.Part_MissingID.Caption = "Part_MissingID"
        Me.Part_MissingID.FieldName = "Part_MissingID"
        Me.Part_MissingID.Name = "Part_MissingID"
        '
        'Edited
        '
        Me.Edited.Caption = "Edited"
        Me.Edited.FieldName = "Edited"
        Me.Edited.Name = "Edited"
        '
        'Delete
        '
        Me.Delete.Caption = "Delete"
        Me.Delete.ColumnEdit = Me.DeleteEdit
        Me.Delete.FieldName = "Delete"
        Me.Delete.MaxWidth = 18
        Me.Delete.MinWidth = 18
        Me.Delete.Name = "Delete"
        Me.Delete.Visible = True
        Me.Delete.VisibleIndex = 3
        Me.Delete.Width = 18
        '
        'DeleteEdit
        '
        Me.DeleteEdit.AutoHeight = False
        Me.DeleteEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, CType(resources.GetObject("DeleteEdit.Buttons"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.DeleteEdit.Name = "DeleteEdit"
        Me.DeleteEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'RepositoryItemLookUpEdit3
        '
        Me.RepositoryItemLookUpEdit3.AutoHeight = False
        Me.RepositoryItemLookUpEdit3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit3.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CounterCode", "Name10", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Counter", "Name12")})
        Me.RepositoryItemLookUpEdit3.DisplayMember = "Counter"
        Me.RepositoryItemLookUpEdit3.DropDownRows = 10
        Me.RepositoryItemLookUpEdit3.Name = "RepositoryItemLookUpEdit3"
        Me.RepositoryItemLookUpEdit3.NullText = ""
        Me.RepositoryItemLookUpEdit3.ShowFooter = False
        Me.RepositoryItemLookUpEdit3.ShowHeader = False
        Me.RepositoryItemLookUpEdit3.ValueMember = "CounterCode"
        '
        'cmdAdd
        '
        Me.cmdAdd.Location = New System.Drawing.Point(139, 20)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(143, 23)
        Me.cmdAdd.TabIndex = 214
        Me.cmdAdd.Text = "Add missing part(s)"
        Me.cmdAdd.Visible = False
        '
        'cboStorageCode
        '
        Me.cboStorageCode.Location = New System.Drawing.Point(436, 56)
        Me.cboStorageCode.Name = "cboStorageCode"
        Me.cboStorageCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboStorageCode.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("StorageCode", "StorageCode", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Storage", "Storage")})
        Me.cboStorageCode.Properties.DisplayMember = "Storage"
        Me.cboStorageCode.Properties.DropDownRows = 10
        Me.cboStorageCode.Properties.MaxLength = 30
        Me.cboStorageCode.Properties.NullText = ""
        Me.cboStorageCode.Properties.ShowFooter = False
        Me.cboStorageCode.Properties.ShowHeader = False
        Me.cboStorageCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboStorageCode.Properties.ValueMember = "StorageCode"
        Me.cboStorageCode.Size = New System.Drawing.Size(148, 20)
        Me.cboStorageCode.TabIndex = 3
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(437, 40)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(38, 13)
        Me.LabelControl5.TabIndex = 213
        Me.LabelControl5.Text = "Storage"
        '
        'cboLocCode
        '
        Me.cboLocCode.Location = New System.Drawing.Point(269, 56)
        Me.cboLocCode.Name = "cboLocCode"
        Me.cboLocCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboLocCode.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocCode", "LocCode", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocName", "LocName")})
        Me.cboLocCode.Properties.DisplayMember = "LocName"
        Me.cboLocCode.Properties.DropDownRows = 10
        Me.cboLocCode.Properties.MaxLength = 30
        Me.cboLocCode.Properties.NullText = ""
        Me.cboLocCode.Properties.ShowFooter = False
        Me.cboLocCode.Properties.ShowHeader = False
        Me.cboLocCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboLocCode.Properties.ValueMember = "LocCode"
        Me.cboLocCode.Size = New System.Drawing.Size(168, 20)
        Me.cboLocCode.TabIndex = 2
        '
        'lblLocation
        '
        Me.lblLocation.Location = New System.Drawing.Point(270, 40)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(40, 13)
        Me.lblLocation.TabIndex = 211
        Me.lblLocation.Text = "Location"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.aGrid)
        Me.GroupControl1.Location = New System.Drawing.Point(15, 84)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(800, 239)
        Me.GroupControl1.TabIndex = 205
        Me.GroupControl1.Text = "Acquired"
        '
        'aGrid
        '
        Me.aGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.aGrid.Location = New System.Drawing.Point(2, 20)
        Me.aGrid.LookAndFeel.SkinName = "iMaginary"
        Me.aGrid.MainView = Me.aView
        Me.aGrid.Name = "aGrid"
        Me.aGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemLookUpEdit1})
        Me.aGrid.Size = New System.Drawing.Size(796, 217)
        Me.aGrid.TabIndex = 11
        Me.aGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.aView})
        '
        'aView
        '
        Me.aView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.aView.Appearance.RowSeparator.Options.UseBackColor = True
        Me.aView.Appearance.ViewCaption.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.aView.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Black
        Me.aView.Appearance.ViewCaption.Options.UseFont = True
        Me.aView.Appearance.ViewCaption.Options.UseForeColor = True
        Me.aView.Appearance.ViewCaption.Options.UseTextOptions = True
        Me.aView.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.aView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.DateReceived, Me.ReceivedQuantity, Me.Vendor})
        Me.aView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.aView.GridControl = Me.aGrid
        Me.aView.Name = "aView"
        Me.aView.NewItemRowText = "Click here to add new record"
        Me.aView.OptionsBehavior.AutoPopulateColumns = False
        Me.aView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.aView.OptionsBehavior.Editable = False
        Me.aView.OptionsBehavior.ReadOnly = True
        Me.aView.OptionsCustomization.AllowColumnMoving = False
        Me.aView.OptionsCustomization.AllowColumnResizing = False
        Me.aView.OptionsCustomization.AllowFilter = False
        Me.aView.OptionsCustomization.AllowGroup = False
        Me.aView.OptionsCustomization.AllowQuickHideColumns = False
        Me.aView.OptionsCustomization.AllowSort = False
        Me.aView.OptionsFilter.AllowFilterEditor = False
        Me.aView.OptionsFind.AllowFindPanel = False
        Me.aView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.aView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.aView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.aView.OptionsSelection.UseIndicatorForSelection = False
        Me.aView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button
        Me.aView.OptionsView.RowAutoHeight = True
        Me.aView.OptionsView.ShowGroupPanel = False
        '
        'DateReceived
        '
        Me.DateReceived.Caption = "Date Received"
        Me.DateReceived.DisplayFormat.FormatString = "d"
        Me.DateReceived.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateReceived.FieldName = "DateReceived"
        Me.DateReceived.Name = "DateReceived"
        Me.DateReceived.UnboundExpression = "'Counter ' + [Counter]"
        Me.DateReceived.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.DateReceived.Visible = True
        Me.DateReceived.VisibleIndex = 0
        Me.DateReceived.Width = 88
        '
        'ReceivedQuantity
        '
        Me.ReceivedQuantity.Caption = "Quantity"
        Me.ReceivedQuantity.DisplayFormat.FormatString = "f0"
        Me.ReceivedQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ReceivedQuantity.FieldName = "ReceivedQuantity"
        Me.ReceivedQuantity.Name = "ReceivedQuantity"
        Me.ReceivedQuantity.Visible = True
        Me.ReceivedQuantity.VisibleIndex = 1
        Me.ReceivedQuantity.Width = 71
        '
        'Vendor
        '
        Me.Vendor.Caption = "Vendor"
        Me.Vendor.FieldName = "Vendor"
        Me.Vendor.Name = "Vendor"
        Me.Vendor.OptionsColumn.AllowEdit = False
        Me.Vendor.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.Vendor.OptionsColumn.ReadOnly = True
        Me.Vendor.Visible = True
        Me.Vendor.VisibleIndex = 2
        Me.Vendor.Width = 556
        '
        'RepositoryItemLookUpEdit1
        '
        Me.RepositoryItemLookUpEdit1.AutoHeight = False
        Me.RepositoryItemLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit1.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CounterCode", "Name10", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Counter", "Name12")})
        Me.RepositoryItemLookUpEdit1.DisplayMember = "Counter"
        Me.RepositoryItemLookUpEdit1.DropDownRows = 10
        Me.RepositoryItemLookUpEdit1.Name = "RepositoryItemLookUpEdit1"
        Me.RepositoryItemLookUpEdit1.NullText = ""
        Me.RepositoryItemLookUpEdit1.ShowFooter = False
        Me.RepositoryItemLookUpEdit1.ShowHeader = False
        Me.RepositoryItemLookUpEdit1.ValueMember = "CounterCode"
        '
        'gConsumed
        '
        Me.gConsumed.Controls.Add(Me.cGrid)
        Me.gConsumed.Location = New System.Drawing.Point(15, 335)
        Me.gConsumed.Name = "gConsumed"
        Me.gConsumed.Size = New System.Drawing.Size(408, 254)
        Me.gConsumed.TabIndex = 204
        Me.gConsumed.Text = "Consumed"
        '
        'cGrid
        '
        Me.cGrid.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode2.RelationName = "Level1"
        Me.cGrid.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode2})
        Me.cGrid.Location = New System.Drawing.Point(2, 20)
        Me.cGrid.LookAndFeel.SkinName = "iMaginary"
        Me.cGrid.MainView = Me.cView
        Me.cGrid.Name = "cGrid"
        Me.cGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemLookUpEdit2})
        Me.cGrid.Size = New System.Drawing.Size(404, 232)
        Me.cGrid.TabIndex = 11
        Me.cGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.cView})
        '
        'cView
        '
        Me.cView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cView.Appearance.RowSeparator.Options.UseBackColor = True
        Me.cView.Appearance.ViewCaption.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cView.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Black
        Me.cView.Appearance.ViewCaption.Options.UseFont = True
        Me.cView.Appearance.ViewCaption.Options.UseForeColor = True
        Me.cView.Appearance.ViewCaption.Options.UseTextOptions = True
        Me.cView.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.cView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.DateConsumed, Me.Number, Me.Remarks})
        Me.cView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.cView.GridControl = Me.cGrid
        Me.cView.Name = "cView"
        Me.cView.NewItemRowText = "Click here to add new record"
        Me.cView.OptionsBehavior.AutoPopulateColumns = False
        Me.cView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.cView.OptionsBehavior.Editable = False
        Me.cView.OptionsBehavior.ReadOnly = True
        Me.cView.OptionsCustomization.AllowColumnMoving = False
        Me.cView.OptionsCustomization.AllowColumnResizing = False
        Me.cView.OptionsCustomization.AllowFilter = False
        Me.cView.OptionsCustomization.AllowGroup = False
        Me.cView.OptionsCustomization.AllowQuickHideColumns = False
        Me.cView.OptionsCustomization.AllowSort = False
        Me.cView.OptionsFilter.AllowFilterEditor = False
        Me.cView.OptionsFind.AllowFindPanel = False
        Me.cView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.cView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.cView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.cView.OptionsSelection.UseIndicatorForSelection = False
        Me.cView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button
        Me.cView.OptionsView.RowAutoHeight = True
        Me.cView.OptionsView.ShowGroupPanel = False
        '
        'DateConsumed
        '
        Me.DateConsumed.Caption = "Date Consumed"
        Me.DateConsumed.DisplayFormat.FormatString = "d"
        Me.DateConsumed.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateConsumed.FieldName = "DateConsumed"
        Me.DateConsumed.MaxWidth = 90
        Me.DateConsumed.MinWidth = 90
        Me.DateConsumed.Name = "DateConsumed"
        Me.DateConsumed.UnboundExpression = "'Counter ' + [Counter]"
        Me.DateConsumed.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        Me.DateConsumed.Visible = True
        Me.DateConsumed.VisibleIndex = 0
        Me.DateConsumed.Width = 90
        '
        'Number
        '
        Me.Number.Caption = "Quantity"
        Me.Number.FieldName = "Number"
        Me.Number.MaxWidth = 70
        Me.Number.MinWidth = 70
        Me.Number.Name = "Number"
        Me.Number.OptionsColumn.AllowEdit = False
        Me.Number.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.Number.OptionsColumn.ReadOnly = True
        Me.Number.Visible = True
        Me.Number.VisibleIndex = 1
        Me.Number.Width = 70
        '
        'Remarks
        '
        Me.Remarks.Caption = "Description"
        Me.Remarks.FieldName = "Remarks"
        Me.Remarks.Name = "Remarks"
        Me.Remarks.Visible = True
        Me.Remarks.VisibleIndex = 2
        Me.Remarks.Width = 896
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
        'txtInitStock
        '
        Me.txtInitStock.Location = New System.Drawing.Point(658, 56)
        Me.txtInitStock.Name = "txtInitStock"
        Me.txtInitStock.Properties.Mask.EditMask = "f0"
        Me.txtInitStock.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtInitStock.Properties.NullText = "0"
        Me.txtInitStock.Size = New System.Drawing.Size(74, 20)
        Me.txtInitStock.TabIndex = 5
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(658, 37)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(55, 13)
        Me.LabelControl4.TabIndex = 194
        Me.LabelControl4.Text = "Initial Stock"
        '
        'txtMinimum
        '
        Me.txtMinimum.Location = New System.Drawing.Point(583, 56)
        Me.txtMinimum.Name = "txtMinimum"
        Me.txtMinimum.Properties.Mask.EditMask = "f0"
        Me.txtMinimum.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtMinimum.Properties.NullText = "0"
        Me.txtMinimum.Size = New System.Drawing.Size(76, 20)
        Me.txtMinimum.TabIndex = 4
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(583, 37)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(40, 13)
        Me.LabelControl2.TabIndex = 192
        Me.LabelControl2.Text = "Minimum"
        '
        'txtOnStock
        '
        Me.txtOnStock.Location = New System.Drawing.Point(731, 56)
        Me.txtOnStock.Name = "txtOnStock"
        Me.txtOnStock.Properties.Mask.EditMask = "f0"
        Me.txtOnStock.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtOnStock.Properties.NullText = "0"
        Me.txtOnStock.Size = New System.Drawing.Size(82, 20)
        Me.txtOnStock.TabIndex = 6
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(731, 37)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(66, 13)
        Me.LabelControl1.TabIndex = 190
        Me.LabelControl1.Text = "Current Stock"
        '
        'txtPartNumber
        '
        Me.txtPartNumber.Location = New System.Drawing.Point(139, 56)
        Me.txtPartNumber.Name = "txtPartNumber"
        Me.txtPartNumber.Properties.MaxLength = 30
        Me.txtPartNumber.Size = New System.Drawing.Size(131, 20)
        Me.txtPartNumber.TabIndex = 1
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(15, 56)
        Me.txtName.Name = "txtName"
        Me.txtName.Properties.MaxLength = 50
        Me.txtName.Size = New System.Drawing.Size(125, 20)
        Me.txtName.TabIndex = 0
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(139, 37)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(69, 13)
        Me.LabelControl3.TabIndex = 40
        Me.LabelControl3.Text = "* Part Number"
        '
        'PART
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.header)
        Me.Name = "PART"
        Me.Size = New System.Drawing.Size(834, 604)
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        Me.header.PerformLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.mGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DeleteEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboStorageCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboLocCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.aGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.aView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gConsumed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gConsumed.ResumeLayout(False)
        CType(Me.cGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInitStock.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMinimum.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOnStock.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPartNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPartNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtInitStock As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtMinimum As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtOnStock As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents aGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents aView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents DateReceived As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ReceivedQuantity As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Vendor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents gConsumed As DevExpress.XtraEditors.GroupControl
    Friend WithEvents cGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents cView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents DateConsumed As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Remarks As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents cboLocCode As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblLocation As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboStorageCode As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents mGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents mView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents DateMissing As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents mNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents mRemarks As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Part_MissingID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents Edited As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Delete As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DeleteEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit

End Class
