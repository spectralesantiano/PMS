<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PARTPURCHASE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PARTPURCHASE))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.MainGrid = New DevExpress.XtraGrid.GridControl()
        Me.MainView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PartPurchaseDetailID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PartCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PartEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.PartNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Storage = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.VendorCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.VendorEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.Quantity = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Received = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DateReceived = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ReceivedQuantity = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Edited = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Delete = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DeleteEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.cboUnit = New DevExpress.XtraEditors.TreeListLookUpEdit()
        Me.UnitTree = New DevExpress.XtraTreeList.TreeList()
        Me.ParentCode = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.UnitCode = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.UnitDesc = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cmdAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.pGrid = New DevExpress.XtraGrid.GridControl()
        Me.pView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pPartCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Part = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.pPartNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Selected = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UnitList = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.txtPurchaseDate = New DevExpress.XtraEditors.DateEdit()
        Me.txtStatus = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.MainPanel = New DevExpress.XtraEditors.SplitContainerControl()
        Me.cmdReceiveAll = New DevExpress.XtraEditors.SimpleButton()
        Me.txtDefaultDate = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PartEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendorEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DeleteEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.cboUnit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UnitTree, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPurchaseDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPurchaseDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainPanel.SuspendLayout()
        CType(Me.txtDefaultDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDefaultDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'header
        '
        Me.header.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.header.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.header.AppearanceCaption.Options.UseFont = True
        Me.header.Controls.Add(Me.MainGrid)
        Me.header.Location = New System.Drawing.Point(1, 53)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(838, 453)
        Me.header.TabIndex = 36
        Me.header.Text = "Purchase Details"
        '
        'MainGrid
        '
        Me.MainGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainGrid.Location = New System.Drawing.Point(2, 23)
        Me.MainGrid.LookAndFeel.SkinName = "iMaginary"
        Me.MainGrid.MainView = Me.MainView
        Me.MainGrid.Name = "MainGrid"
        Me.MainGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.PartEdit, Me.DeleteEdit, Me.VendorEdit})
        Me.MainGrid.Size = New System.Drawing.Size(834, 428)
        Me.MainGrid.TabIndex = 8
        Me.MainGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MainView})
        '
        'MainView
        '
        Me.MainView.Appearance.GroupRow.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.MainView.Appearance.GroupRow.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.MainView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black
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
        Me.MainView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.PartPurchaseDetailID, Me.PartCode, Me.PartNumber, Me.Storage, Me.VendorCode, Me.Quantity, Me.Received, Me.DateReceived, Me.ReceivedQuantity, Me.Edited, Me.Delete})
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
        Me.MainView.OptionsCustomization.AllowFilter = False
        Me.MainView.OptionsCustomization.AllowGroup = False
        Me.MainView.OptionsCustomization.AllowQuickHideColumns = False
        Me.MainView.OptionsFilter.AllowFilterEditor = False
        Me.MainView.OptionsFind.AllowFindPanel = False
        Me.MainView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.MainView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.MainView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.MainView.OptionsSelection.UseIndicatorForSelection = False
        Me.MainView.OptionsView.ColumnAutoWidth = False
        Me.MainView.OptionsView.ShowGroupPanel = False
        Me.MainView.RowHeight = 0
        '
        'PartPurchaseDetailID
        '
        Me.PartPurchaseDetailID.Caption = "PartPurchaseDetailID"
        Me.PartPurchaseDetailID.FieldName = "PartPurchaseDetailID"
        Me.PartPurchaseDetailID.Name = "PartPurchaseDetailID"
        '
        'PartCode
        '
        Me.PartCode.Caption = "Part"
        Me.PartCode.ColumnEdit = Me.PartEdit
        Me.PartCode.FieldName = "PartCode"
        Me.PartCode.Name = "PartCode"
        Me.PartCode.OptionsColumn.AllowEdit = False
        Me.PartCode.OptionsColumn.ReadOnly = True
        Me.PartCode.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value
        Me.PartCode.Visible = True
        Me.PartCode.VisibleIndex = 0
        Me.PartCode.Width = 128
        '
        'PartEdit
        '
        Me.PartEdit.AutoHeight = False
        Me.PartEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PartCode", "Name1"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Part", "Name2"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Storage", "Name17"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PartNumber", "Name18")})
        Me.PartEdit.DisplayMember = "Part"
        Me.PartEdit.DropDownRows = 10
        Me.PartEdit.Name = "PartEdit"
        Me.PartEdit.NullText = ""
        Me.PartEdit.ShowFooter = False
        Me.PartEdit.ShowHeader = False
        Me.PartEdit.ValueMember = "PartCode"
        '
        'PartNumber
        '
        Me.PartNumber.Caption = "Number"
        Me.PartNumber.Name = "PartNumber"
        Me.PartNumber.OptionsColumn.AllowEdit = False
        Me.PartNumber.OptionsColumn.ReadOnly = True
        Me.PartNumber.Visible = True
        Me.PartNumber.VisibleIndex = 1
        '
        'Storage
        '
        Me.Storage.Caption = "Storage"
        Me.Storage.Name = "Storage"
        Me.Storage.OptionsColumn.AllowEdit = False
        Me.Storage.OptionsColumn.ReadOnly = True
        Me.Storage.Visible = True
        Me.Storage.VisibleIndex = 2
        Me.Storage.Width = 148
        '
        'VendorCode
        '
        Me.VendorCode.Caption = "Vendor"
        Me.VendorCode.ColumnEdit = Me.VendorEdit
        Me.VendorCode.FieldName = "VendorCode"
        Me.VendorCode.Name = "VendorCode"
        Me.VendorCode.Visible = True
        Me.VendorCode.VisibleIndex = 3
        Me.VendorCode.Width = 118
        '
        'VendorEdit
        '
        Me.VendorEdit.AutoHeight = False
        Me.VendorEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.VendorEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Vendor", "Name5"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("VendorCode", "Name6", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.VendorEdit.DisplayMember = "Vendor"
        Me.VendorEdit.DropDownRows = 10
        Me.VendorEdit.Name = "VendorEdit"
        Me.VendorEdit.NullText = ""
        Me.VendorEdit.ShowFooter = False
        Me.VendorEdit.ShowHeader = False
        Me.VendorEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.VendorEdit.ValueMember = "VendorCode"
        '
        'Quantity
        '
        Me.Quantity.Caption = "Quantity"
        Me.Quantity.FieldName = "Quantity"
        Me.Quantity.MaxWidth = 60
        Me.Quantity.MinWidth = 60
        Me.Quantity.Name = "Quantity"
        Me.Quantity.Visible = True
        Me.Quantity.VisibleIndex = 4
        Me.Quantity.Width = 60
        '
        'Received
        '
        Me.Received.Caption = "Received"
        Me.Received.FieldName = "Received"
        Me.Received.MaxWidth = 60
        Me.Received.MinWidth = 60
        Me.Received.Name = "Received"
        Me.Received.Visible = True
        Me.Received.VisibleIndex = 5
        Me.Received.Width = 60
        '
        'DateReceived
        '
        Me.DateReceived.Caption = "Date Received"
        Me.DateReceived.DisplayFormat.FormatString = "d"
        Me.DateReceived.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateReceived.FieldName = "DateReceived"
        Me.DateReceived.MaxWidth = 90
        Me.DateReceived.MinWidth = 90
        Me.DateReceived.Name = "DateReceived"
        Me.DateReceived.Visible = True
        Me.DateReceived.VisibleIndex = 6
        Me.DateReceived.Width = 90
        '
        'ReceivedQuantity
        '
        Me.ReceivedQuantity.Caption = "Received Quantity"
        Me.ReceivedQuantity.DisplayFormat.FormatString = "f0"
        Me.ReceivedQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ReceivedQuantity.FieldName = "ReceivedQuantity"
        Me.ReceivedQuantity.MaxWidth = 100
        Me.ReceivedQuantity.MinWidth = 100
        Me.ReceivedQuantity.Name = "ReceivedQuantity"
        Me.ReceivedQuantity.Visible = True
        Me.ReceivedQuantity.VisibleIndex = 7
        Me.ReceivedQuantity.Width = 100
        '
        'Edited
        '
        Me.Edited.Caption = "Edited"
        Me.Edited.FieldName = "Edited"
        Me.Edited.Name = "Edited"
        '
        'Delete
        '
        Me.Delete.ColumnEdit = Me.DeleteEdit
        Me.Delete.MaxWidth = 18
        Me.Delete.MinWidth = 18
        Me.Delete.Name = "Delete"
        Me.Delete.Visible = True
        Me.Delete.VisibleIndex = 8
        Me.Delete.Width = 18
        '
        'DeleteEdit
        '
        Me.DeleteEdit.AutoHeight = False
        Me.DeleteEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, CType(resources.GetObject("DeleteEdit.Buttons"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.DeleteEdit.Name = "DeleteEdit"
        Me.DeleteEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'GroupControl3
        '
        Me.GroupControl3.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupControl3.AppearanceCaption.Options.UseFont = True
        Me.GroupControl3.Controls.Add(Me.LabelControl1)
        Me.GroupControl3.Controls.Add(Me.cboUnit)
        Me.GroupControl3.Controls.Add(Me.cmdAdd)
        Me.GroupControl3.Controls.Add(Me.pGrid)
        Me.GroupControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl3.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(266, 510)
        Me.GroupControl3.TabIndex = 205
        Me.GroupControl3.Text = "Parts"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(6, 26)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(59, 13)
        Me.LabelControl1.TabIndex = 14
        Me.LabelControl1.Text = "Component:"
        '
        'cboUnit
        '
        Me.cboUnit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboUnit.Location = New System.Drawing.Point(99, 23)
        Me.cboUnit.Name = "cboUnit"
        Me.cboUnit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Close)})
        Me.cboUnit.Properties.DisplayMember = "UnitDesc"
        Me.cboUnit.Properties.NullText = ""
        Me.cboUnit.Properties.ShowFooter = False
        Me.cboUnit.Properties.TreeList = Me.UnitTree
        Me.cboUnit.Properties.ValueMember = "UnitCode"
        Me.cboUnit.Size = New System.Drawing.Size(165, 20)
        Me.cboUnit.TabIndex = 13
        '
        'UnitTree
        '
        Me.UnitTree.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.ParentCode, Me.UnitCode, Me.UnitDesc})
        Me.UnitTree.KeyFieldName = "UnitCode"
        Me.UnitTree.Location = New System.Drawing.Point(18, 134)
        Me.UnitTree.Name = "UnitTree"
        Me.UnitTree.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.[False]
        Me.UnitTree.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.[True]
        Me.UnitTree.OptionsCustomization.AllowBandMoving = False
        Me.UnitTree.OptionsCustomization.AllowBandResizing = False
        Me.UnitTree.OptionsView.ShowColumns = False
        Me.UnitTree.OptionsView.ShowIndentAsRowStyle = True
        Me.UnitTree.OptionsView.ShowIndicator = False
        Me.UnitTree.ParentFieldName = "ParentCode"
        Me.UnitTree.Size = New System.Drawing.Size(307, 200)
        Me.UnitTree.TabIndex = 0
        Me.UnitTree.TreeLevelWidth = 25
        '
        'ParentCode
        '
        Me.ParentCode.Caption = "ParentCode"
        Me.ParentCode.FieldName = "ParentCode"
        Me.ParentCode.Name = "ParentCode"
        '
        'UnitCode
        '
        Me.UnitCode.Caption = "UnitCode"
        Me.UnitCode.FieldName = "UnitCode"
        Me.UnitCode.Name = "UnitCode"
        Me.UnitCode.Width = 133
        '
        'UnitDesc
        '
        Me.UnitDesc.Caption = "UnitDesc"
        Me.UnitDesc.FieldName = "UnitDesc"
        Me.UnitDesc.Name = "UnitDesc"
        Me.UnitDesc.Visible = True
        Me.UnitDesc.VisibleIndex = 0
        Me.UnitDesc.Width = 200
        '
        'cmdAdd
        '
        Me.cmdAdd.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAdd.Location = New System.Drawing.Point(5, 483)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(256, 23)
        Me.cmdAdd.TabIndex = 12
        Me.cmdAdd.Text = "Add Part(s)"
        '
        'pGrid
        '
        Me.pGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pGrid.Location = New System.Drawing.Point(1, 44)
        Me.pGrid.LookAndFeel.SkinName = "iMaginary"
        Me.pGrid.MainView = Me.pView
        Me.pGrid.Name = "pGrid"
        Me.pGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemLookUpEdit1})
        Me.pGrid.Size = New System.Drawing.Size(263, 437)
        Me.pGrid.TabIndex = 11
        Me.pGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.pView})
        '
        'pView
        '
        Me.pView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.pView.Appearance.RowSeparator.Options.UseBackColor = True
        Me.pView.Appearance.ViewCaption.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.pView.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Black
        Me.pView.Appearance.ViewCaption.Options.UseFont = True
        Me.pView.Appearance.ViewCaption.Options.UseForeColor = True
        Me.pView.Appearance.ViewCaption.Options.UseTextOptions = True
        Me.pView.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.pView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.pPartCode, Me.Part, Me.pPartNumber, Me.Selected, Me.UnitList})
        Me.pView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.pView.GridControl = Me.pGrid
        Me.pView.Name = "pView"
        Me.pView.NewItemRowText = "Click here to add new record"
        Me.pView.OptionsBehavior.AutoPopulateColumns = False
        Me.pView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.pView.OptionsCustomization.AllowColumnMoving = False
        Me.pView.OptionsCustomization.AllowColumnResizing = False
        Me.pView.OptionsCustomization.AllowFilter = False
        Me.pView.OptionsCustomization.AllowGroup = False
        Me.pView.OptionsCustomization.AllowQuickHideColumns = False
        Me.pView.OptionsCustomization.AllowSort = False
        Me.pView.OptionsFilter.AllowFilterEditor = False
        Me.pView.OptionsFind.AlwaysVisible = True
        Me.pView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.pView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.pView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.pView.OptionsSelection.UseIndicatorForSelection = False
        Me.pView.OptionsView.RowAutoHeight = True
        Me.pView.OptionsView.ShowColumnHeaders = False
        Me.pView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.pView.OptionsView.ShowGroupPanel = False
        Me.pView.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.Part, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'pPartCode
        '
        Me.pPartCode.Caption = "PartCode"
        Me.pPartCode.FieldName = "pPartCode"
        Me.pPartCode.Name = "pPartCode"
        Me.pPartCode.OptionsColumn.AllowEdit = False
        Me.pPartCode.OptionsColumn.ReadOnly = True
        Me.pPartCode.Width = 159
        '
        'Part
        '
        Me.Part.Caption = "Part"
        Me.Part.FieldName = "Part"
        Me.Part.MinWidth = 120
        Me.Part.Name = "Part"
        Me.Part.OptionsColumn.AllowEdit = False
        Me.Part.OptionsColumn.ReadOnly = True
        Me.Part.Visible = True
        Me.Part.VisibleIndex = 0
        Me.Part.Width = 120
        '
        'pPartNumber
        '
        Me.pPartNumber.Caption = "PartNumber"
        Me.pPartNumber.FieldName = "PartNumber"
        Me.pPartNumber.Name = "pPartNumber"
        Me.pPartNumber.OptionsColumn.AllowEdit = False
        Me.pPartNumber.OptionsColumn.ReadOnly = True
        Me.pPartNumber.Visible = True
        Me.pPartNumber.VisibleIndex = 1
        Me.pPartNumber.Width = 100
        '
        'Selected
        '
        Me.Selected.Caption = "Selected"
        Me.Selected.FieldName = "Selected"
        Me.Selected.MaxWidth = 20
        Me.Selected.Name = "Selected"
        Me.Selected.Visible = True
        Me.Selected.VisibleIndex = 2
        Me.Selected.Width = 20
        '
        'UnitList
        '
        Me.UnitList.Caption = "UnitList"
        Me.UnitList.FieldName = "UnitList"
        Me.UnitList.Name = "UnitList"
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
        'LabelControl9
        '
        Me.LabelControl9.Location = New System.Drawing.Point(3, 7)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(75, 13)
        Me.LabelControl9.TabIndex = 1
        Me.LabelControl9.Text = "* Date Ordered"
        '
        'txtPurchaseDate
        '
        Me.txtPurchaseDate.EditValue = Nothing
        Me.txtPurchaseDate.Location = New System.Drawing.Point(3, 26)
        Me.txtPurchaseDate.Name = "txtPurchaseDate"
        Me.txtPurchaseDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtPurchaseDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtPurchaseDate.Properties.MaxLength = 30
        Me.txtPurchaseDate.Size = New System.Drawing.Size(147, 20)
        Me.txtPurchaseDate.TabIndex = 0
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(149, 26)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Properties.MaxLength = 30
        Me.txtStatus.Size = New System.Drawing.Size(198, 20)
        Me.txtStatus.TabIndex = 207
        '
        'LabelControl12
        '
        Me.LabelControl12.Location = New System.Drawing.Point(151, 7)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl12.TabIndex = 208
        Me.LabelControl12.Text = "Status"
        '
        'MainPanel
        '
        Me.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainPanel.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None
        Me.MainPanel.Location = New System.Drawing.Point(0, 0)
        Me.MainPanel.Name = "MainPanel"
        Me.MainPanel.Panel1.Controls.Add(Me.GroupControl3)
        Me.MainPanel.Panel2.Controls.Add(Me.cmdReceiveAll)
        Me.MainPanel.Panel2.Controls.Add(Me.txtDefaultDate)
        Me.MainPanel.Panel2.Controls.Add(Me.LabelControl2)
        Me.MainPanel.Panel2.Controls.Add(Me.header)
        Me.MainPanel.Panel2.Controls.Add(Me.txtStatus)
        Me.MainPanel.Panel2.Controls.Add(Me.txtPurchaseDate)
        Me.MainPanel.Panel2.Controls.Add(Me.LabelControl12)
        Me.MainPanel.Panel2.Controls.Add(Me.LabelControl9)
        Me.MainPanel.Panel2.Text = "Panel2"
        Me.MainPanel.Size = New System.Drawing.Size(1153, 510)
        Me.MainPanel.SplitterPosition = 266
        Me.MainPanel.TabIndex = 209
        '
        'cmdReceiveAll
        '
        Me.cmdReceiveAll.Location = New System.Drawing.Point(746, 24)
        Me.cmdReceiveAll.Name = "cmdReceiveAll"
        Me.cmdReceiveAll.Size = New System.Drawing.Size(93, 23)
        Me.cmdReceiveAll.TabIndex = 3
        Me.cmdReceiveAll.Text = "Receive All"
        '
        'txtDefaultDate
        '
        Me.txtDefaultDate.EditValue = Nothing
        Me.txtDefaultDate.Location = New System.Drawing.Point(576, 27)
        Me.txtDefaultDate.Name = "txtDefaultDate"
        Me.txtDefaultDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtDefaultDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtDefaultDate.Properties.MaxLength = 30
        Me.txtDefaultDate.Size = New System.Drawing.Size(164, 20)
        Me.txtDefaultDate.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(576, 8)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(102, 13)
        Me.LabelControl2.TabIndex = 209
        Me.LabelControl2.Text = "Default Date Receive"
        '
        'PARTPURCHASE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.MainPanel)
        Me.Name = "PARTPURCHASE"
        Me.Size = New System.Drawing.Size(1153, 510)
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PartEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendorEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DeleteEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        Me.GroupControl3.PerformLayout()
        CType(Me.cboUnit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UnitTree, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPurchaseDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPurchaseDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainPanel.ResumeLayout(False)
        CType(Me.txtDefaultDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDefaultDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents MainGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents MainView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PartPurchaseDetailID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents VendorCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Quantity As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ReceivedQuantity As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DateReceived As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Received As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PartCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Edited As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents pGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents pView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents pPartCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Part As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Selected As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPurchaseDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents cmdAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cboUnit As DevExpress.XtraEditors.TreeListLookUpEdit
    Friend WithEvents UnitTree As DevExpress.XtraTreeList.TreeList
    Friend WithEvents ParentCode As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents UnitCode As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents UnitDesc As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents pPartNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UnitList As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PartEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents Delete As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DeleteEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents PartNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents VendorEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents txtStatus As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MainPanel As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents Storage As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtDefaultDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdReceiveAll As DevExpress.XtraEditors.SimpleButton

End Class
