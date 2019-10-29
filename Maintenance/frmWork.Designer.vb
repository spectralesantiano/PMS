<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWork
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWork))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.cmdOK = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.cboMaintenance = New DevExpress.XtraEditors.LookUpEdit()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.lblComponent = New DevExpress.XtraEditors.LabelControl()
        Me.cboUnit = New DevExpress.XtraEditors.TreeListLookUpEdit()
        Me.UnitTree = New DevExpress.XtraTreeList.TreeList()
        Me.ParentCode = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.UnitCode = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.UnitDesc = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.RunningHours = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.ReadingDate = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.gPrevMaintenance = New DevExpress.XtraEditors.GroupControl()
        Me.txtPRemarks = New DevExpress.XtraEditors.MemoEdit()
        Me.txtPDate = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.txtPRunningHours = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.txtPExec = New DevExpress.XtraEditors.TextEdit()
        Me.txtRemarks = New DevExpress.XtraEditors.MemoEdit()
        Me.txtWorkDate = New DevExpress.XtraEditors.DateEdit()
        Me.lblDate = New DevExpress.XtraEditors.LabelControl()
        Me.txtWorkCounter = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.txtExecutedBy = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.cboRankCode = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.lblReadingDate = New DevExpress.XtraEditors.LabelControl()
        Me.lblRunningHours = New DevExpress.XtraEditors.LabelControl()
        Me.txtInsDesc = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.cmdCopy = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.MainGrid = New DevExpress.XtraGrid.GridControl()
        Me.MainView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PartConsumptionID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PartCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Part = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.OnStock = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Delete = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DeleteEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.Edited = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.PartEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.gMain = New DevExpress.XtraEditors.GroupControl()
        Me.IGrid = New DevExpress.XtraGrid.GridControl()
        Me.IView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.FileDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DocID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FileName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.iDelete = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.iDeleteEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.Doc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.cmdBrowse = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.cboMaintenance.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboUnit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UnitTree, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gPrevMaintenance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gPrevMaintenance.SuspendLayout()
        CType(Me.txtPRemarks.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPRunningHours.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPExec.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRemarks.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWorkDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWorkDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWorkCounter.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtExecutedBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboRankCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInsDesc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DeleteEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PartEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gMain.SuspendLayout()
        CType(Me.IGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.iDeleteEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(497, 581)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(78, 23)
        Me.cmdOK.TabIndex = 7
        Me.cmdOK.Text = "Ok"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(10, 78)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(70, 13)
        Me.LabelControl2.TabIndex = 8
        Me.LabelControl2.Text = "* Maintenance"
        '
        'cboMaintenance
        '
        Me.cboMaintenance.Location = New System.Drawing.Point(10, 97)
        Me.cboMaintenance.Name = "cboMaintenance"
        Me.cboMaintenance.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboMaintenance.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaintenanceCode", "MaintenanceCode", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("WorkDescription", "WorkDescription"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("RankCode", "RankCode", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("IntDue", "IntDue", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("IntCode", "IntCode", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Number", "Number", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("InsDesc", "InsDesc", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.cboMaintenance.Properties.DisplayMember = "WorkDescription"
        Me.cboMaintenance.Properties.DropDownRows = 10
        Me.cboMaintenance.Properties.NullText = ""
        Me.cboMaintenance.Properties.ShowFooter = False
        Me.cboMaintenance.Properties.ShowHeader = False
        Me.cboMaintenance.Properties.ValueMember = "MaintenanceCode"
        Me.cboMaintenance.Size = New System.Drawing.Size(288, 20)
        Me.cboMaintenance.TabIndex = 1
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(581, 581)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(78, 23)
        Me.cmdCancel.TabIndex = 8
        Me.cmdCancel.Text = "Cancel"
        '
        'lblComponent
        '
        Me.lblComponent.Location = New System.Drawing.Point(10, 33)
        Me.lblComponent.Name = "lblComponent"
        Me.lblComponent.Size = New System.Drawing.Size(64, 13)
        Me.lblComponent.TabIndex = 214
        Me.lblComponent.Text = "* Component"
        '
        'cboUnit
        '
        Me.cboUnit.Location = New System.Drawing.Point(10, 52)
        Me.cboUnit.Name = "cboUnit"
        Me.cboUnit.Properties.AutoExpandAllNodes = False
        Me.cboUnit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboUnit.Properties.DisplayMember = "UnitDesc"
        Me.cboUnit.Properties.NullText = ""
        Me.cboUnit.Properties.ShowFooter = False
        Me.cboUnit.Properties.TreeList = Me.UnitTree
        Me.cboUnit.Properties.ValueMember = "UnitCode"
        Me.cboUnit.Size = New System.Drawing.Size(288, 20)
        Me.cboUnit.TabIndex = 0
        '
        'UnitTree
        '
        Me.UnitTree.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.ParentCode, Me.UnitCode, Me.UnitDesc, Me.RunningHours, Me.ReadingDate})
        Me.UnitTree.KeyFieldName = "UnitCode"
        Me.UnitTree.Location = New System.Drawing.Point(0, 2)
        Me.UnitTree.Name = "UnitTree"
        Me.UnitTree.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.[False]
        Me.UnitTree.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.[True]
        Me.UnitTree.OptionsCustomization.AllowBandMoving = False
        Me.UnitTree.OptionsCustomization.AllowBandResizing = False
        Me.UnitTree.OptionsView.ShowColumns = False
        Me.UnitTree.OptionsView.ShowIndentAsRowStyle = True
        Me.UnitTree.OptionsView.ShowIndicator = False
        Me.UnitTree.ParentFieldName = "ParentCode"
        Me.UnitTree.Size = New System.Drawing.Size(400, 200)
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
        Me.UnitDesc.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText
        Me.UnitDesc.SortOrder = System.Windows.Forms.SortOrder.Ascending
        Me.UnitDesc.Visible = True
        Me.UnitDesc.VisibleIndex = 0
        Me.UnitDesc.Width = 200
        '
        'RunningHours
        '
        Me.RunningHours.Caption = "RunningHours"
        Me.RunningHours.FieldName = "RunningHours"
        Me.RunningHours.Name = "RunningHours"
        '
        'ReadingDate
        '
        Me.ReadingDate.Caption = "ReadingDate"
        Me.ReadingDate.FieldName = "ReadingDate"
        Me.ReadingDate.Name = "ReadingDate"
        '
        'gPrevMaintenance
        '
        Me.gPrevMaintenance.Controls.Add(Me.txtPRemarks)
        Me.gPrevMaintenance.Controls.Add(Me.txtPDate)
        Me.gPrevMaintenance.Controls.Add(Me.LabelControl6)
        Me.gPrevMaintenance.Controls.Add(Me.txtPRunningHours)
        Me.gPrevMaintenance.Controls.Add(Me.LabelControl8)
        Me.gPrevMaintenance.Controls.Add(Me.LabelControl9)
        Me.gPrevMaintenance.Controls.Add(Me.LabelControl10)
        Me.gPrevMaintenance.Controls.Add(Me.txtPExec)
        Me.gPrevMaintenance.Location = New System.Drawing.Point(12, 418)
        Me.gPrevMaintenance.Name = "gPrevMaintenance"
        Me.gPrevMaintenance.Size = New System.Drawing.Size(309, 150)
        Me.gPrevMaintenance.TabIndex = 226
        Me.gPrevMaintenance.Text = "Previous Maintenance"
        '
        'txtPRemarks
        '
        Me.txtPRemarks.Enabled = False
        Me.txtPRemarks.Location = New System.Drawing.Point(12, 96)
        Me.txtPRemarks.Name = "txtPRemarks"
        Me.txtPRemarks.Size = New System.Drawing.Size(286, 42)
        Me.txtPRemarks.TabIndex = 6
        '
        'txtPDate
        '
        Me.txtPDate.EditValue = Nothing
        Me.txtPDate.Enabled = False
        Me.txtPDate.Location = New System.Drawing.Point(12, 51)
        Me.txtPDate.Name = "txtPDate"
        Me.txtPDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtPDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtPDate.Properties.EditFormat.FormatString = ""
        Me.txtPDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtPDate.Size = New System.Drawing.Size(96, 20)
        Me.txtPDate.TabIndex = 2
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(12, 35)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl6.TabIndex = 206
        Me.LabelControl6.Text = "Date"
        '
        'txtPRunningHours
        '
        Me.txtPRunningHours.EditValue = CType(0, Long)
        Me.txtPRunningHours.Enabled = False
        Me.txtPRunningHours.Location = New System.Drawing.Point(107, 51)
        Me.txtPRunningHours.Name = "txtPRunningHours"
        Me.txtPRunningHours.Properties.Appearance.Options.UseTextOptions = True
        Me.txtPRunningHours.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtPRunningHours.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPRunningHours.Properties.Mask.EditMask = "f0"
        Me.txtPRunningHours.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtPRunningHours.Size = New System.Drawing.Size(75, 20)
        Me.txtPRunningHours.TabIndex = 3
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(107, 35)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(70, 13)
        Me.LabelControl8.TabIndex = 207
        Me.LabelControl8.Text = "Running Hours"
        '
        'LabelControl9
        '
        Me.LabelControl9.Location = New System.Drawing.Point(12, 77)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(41, 13)
        Me.LabelControl9.TabIndex = 208
        Me.LabelControl9.Text = "Remarks"
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(184, 35)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(60, 13)
        Me.LabelControl10.TabIndex = 209
        Me.LabelControl10.Text = "Executed by"
        '
        'txtPExec
        '
        Me.txtPExec.Enabled = False
        Me.txtPExec.Location = New System.Drawing.Point(181, 51)
        Me.txtPExec.Name = "txtPExec"
        Me.txtPExec.Properties.MaxLength = 30
        Me.txtPExec.Size = New System.Drawing.Size(117, 20)
        Me.txtPExec.TabIndex = 4
        '
        'txtRemarks
        '
        Me.txtRemarks.EditValue = ""
        Me.txtRemarks.Location = New System.Drawing.Point(10, 232)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(288, 45)
        Me.txtRemarks.TabIndex = 6
        '
        'txtWorkDate
        '
        Me.txtWorkDate.EditValue = Nothing
        Me.txtWorkDate.Location = New System.Drawing.Point(11, 139)
        Me.txtWorkDate.Name = "txtWorkDate"
        Me.txtWorkDate.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtWorkDate.Properties.Appearance.Options.UseBackColor = True
        Me.txtWorkDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtWorkDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtWorkDate.Properties.EditFormat.FormatString = ""
        Me.txtWorkDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtWorkDate.Size = New System.Drawing.Size(159, 20)
        Me.txtWorkDate.TabIndex = 2
        '
        'lblDate
        '
        Me.lblDate.Location = New System.Drawing.Point(11, 123)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(32, 13)
        Me.lblDate.TabIndex = 232
        Me.lblDate.Text = "* Date"
        '
        'txtWorkCounter
        '
        Me.txtWorkCounter.EditValue = CType(0, Long)
        Me.txtWorkCounter.Location = New System.Drawing.Point(169, 139)
        Me.txtWorkCounter.Name = "txtWorkCounter"
        Me.txtWorkCounter.Properties.Appearance.Options.UseTextOptions = True
        Me.txtWorkCounter.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtWorkCounter.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtWorkCounter.Properties.Mask.EditMask = "f0"
        Me.txtWorkCounter.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtWorkCounter.Size = New System.Drawing.Size(129, 20)
        Me.txtWorkCounter.TabIndex = 3
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(10, 213)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(41, 13)
        Me.LabelControl3.TabIndex = 234
        Me.LabelControl3.Text = "Remarks"
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(10, 167)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(69, 13)
        Me.LabelControl7.TabIndex = 235
        Me.LabelControl7.Text = "* Executed by"
        '
        'txtExecutedBy
        '
        Me.txtExecutedBy.Location = New System.Drawing.Point(10, 183)
        Me.txtExecutedBy.Name = "txtExecutedBy"
        Me.txtExecutedBy.Properties.MaxLength = 30
        Me.txtExecutedBy.Size = New System.Drawing.Size(160, 20)
        Me.txtExecutedBy.TabIndex = 4
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(169, 167)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(33, 13)
        Me.LabelControl4.TabIndex = 236
        Me.LabelControl4.Text = "* Rank"
        '
        'cboRankCode
        '
        Me.cboRankCode.Location = New System.Drawing.Point(169, 183)
        Me.cboRankCode.Name = "cboRankCode"
        Me.cboRankCode.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.cboRankCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboRankCode.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("RankCode", "RankCode", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Abbrv", "Name3"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("RankDesc", "RankDesc")})
        Me.cboRankCode.Properties.DisplayMember = "Abbrv"
        Me.cboRankCode.Properties.DropDownRows = 10
        Me.cboRankCode.Properties.NullText = ""
        Me.cboRankCode.Properties.ShowFooter = False
        Me.cboRankCode.Properties.ShowHeader = False
        Me.cboRankCode.Properties.ValueMember = "RankCode"
        Me.cboRankCode.Size = New System.Drawing.Size(129, 20)
        Me.cboRankCode.TabIndex = 5
        '
        'LabelControl12
        '
        Me.LabelControl12.Location = New System.Drawing.Point(169, 123)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(70, 13)
        Me.LabelControl12.TabIndex = 238
        Me.LabelControl12.Text = "Running Hours"
        '
        'lblReadingDate
        '
        Me.lblReadingDate.Location = New System.Drawing.Point(14, 398)
        Me.lblReadingDate.Name = "lblReadingDate"
        Me.lblReadingDate.Size = New System.Drawing.Size(90, 13)
        Me.lblReadingDate.TabIndex = 239
        Me.lblReadingDate.Text = "Reading Date: N/A"
        '
        'lblRunningHours
        '
        Me.lblRunningHours.Location = New System.Drawing.Point(193, 399)
        Me.lblRunningHours.Name = "lblRunningHours"
        Me.lblRunningHours.Size = New System.Drawing.Size(95, 13)
        Me.lblRunningHours.TabIndex = 240
        Me.lblRunningHours.Text = "Running Hours: N/A"
        '
        'txtInsDesc
        '
        Me.txtInsDesc.Enabled = False
        Me.txtInsDesc.Location = New System.Drawing.Point(10, 302)
        Me.txtInsDesc.Name = "txtInsDesc"
        Me.txtInsDesc.Size = New System.Drawing.Size(288, 45)
        Me.txtInsDesc.TabIndex = 241
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(11, 283)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(57, 13)
        Me.LabelControl1.TabIndex = 242
        Me.LabelControl1.Text = "Instructions"
        '
        'cmdCopy
        '
        Me.cmdCopy.Enabled = False
        Me.cmdCopy.Location = New System.Drawing.Point(169, 209)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(129, 18)
        Me.cmdCopy.TabIndex = 243
        Me.cmdCopy.TabStop = False
        Me.cmdCopy.Text = "Copy Instructions"
        '
        'GroupControl3
        '
        Me.GroupControl3.Controls.Add(Me.MainGrid)
        Me.GroupControl3.Location = New System.Drawing.Point(327, 31)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(338, 357)
        Me.GroupControl3.TabIndex = 244
        Me.GroupControl3.Text = "Parts"
        '
        'MainGrid
        '
        Me.MainGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainGrid.Location = New System.Drawing.Point(2, 20)
        Me.MainGrid.LookAndFeel.SkinName = "iMaginary"
        Me.MainGrid.MainView = Me.MainView
        Me.MainGrid.Name = "MainGrid"
        Me.MainGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemLookUpEdit1, Me.DeleteEdit, Me.PartEdit})
        Me.MainGrid.Size = New System.Drawing.Size(334, 335)
        Me.MainGrid.TabIndex = 11
        Me.MainGrid.TabStop = False
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
        Me.MainView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.PartConsumptionID, Me.PartCode, Me.Part, Me.OnStock, Me.Number, Me.Delete, Me.Edited})
        Me.MainView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.MainView.GridControl = Me.MainGrid
        Me.MainView.Name = "MainView"
        Me.MainView.NewItemRowText = "Click here to add new record"
        Me.MainView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.MainView.OptionsCustomization.AllowColumnMoving = False
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
        Me.MainView.OptionsView.RowAutoHeight = True
        Me.MainView.OptionsView.ShowGroupPanel = False
        '
        'PartConsumptionID
        '
        Me.PartConsumptionID.Caption = "PartConsumptionID"
        Me.PartConsumptionID.FieldName = "PartConsumptionID"
        Me.PartConsumptionID.Name = "PartConsumptionID"
        '
        'PartCode
        '
        Me.PartCode.Caption = "PartCode"
        Me.PartCode.FieldName = "PartCode"
        Me.PartCode.Name = "PartCode"
        '
        'Part
        '
        Me.Part.Caption = "Part"
        Me.Part.FieldName = "Part"
        Me.Part.MinWidth = 170
        Me.Part.Name = "Part"
        Me.Part.OptionsColumn.AllowEdit = False
        Me.Part.OptionsColumn.ReadOnly = True
        Me.Part.Visible = True
        Me.Part.VisibleIndex = 0
        Me.Part.Width = 170
        '
        'OnStock
        '
        Me.OnStock.Caption = "On Stock"
        Me.OnStock.FieldName = "OnStock"
        Me.OnStock.MinWidth = 60
        Me.OnStock.Name = "OnStock"
        Me.OnStock.OptionsColumn.AllowEdit = False
        Me.OnStock.OptionsColumn.ReadOnly = True
        Me.OnStock.Visible = True
        Me.OnStock.VisibleIndex = 1
        '
        'Number
        '
        Me.Number.Caption = "Consumed"
        Me.Number.DisplayFormat.FormatString = "f0"
        Me.Number.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Number.FieldName = "Number"
        Me.Number.Name = "Number"
        Me.Number.Visible = True
        Me.Number.VisibleIndex = 2
        Me.Number.Width = 149
        '
        'Delete
        '
        Me.Delete.ColumnEdit = Me.DeleteEdit
        Me.Delete.Name = "Delete"
        Me.Delete.OptionsColumn.FixedWidth = True
        Me.Delete.Visible = True
        Me.Delete.VisibleIndex = 3
        Me.Delete.Width = 20
        '
        'DeleteEdit
        '
        Me.DeleteEdit.AutoHeight = False
        Me.DeleteEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, CType(resources.GetObject("DeleteEdit.Buttons"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.DeleteEdit.Name = "DeleteEdit"
        Me.DeleteEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'Edited
        '
        Me.Edited.Caption = "Edited"
        Me.Edited.FieldName = "Edited"
        Me.Edited.Name = "Edited"
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
        'PartEdit
        '
        Me.PartEdit.AutoHeight = False
        Me.PartEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.PartEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Part", "Part"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PartCode", "Name32", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("OnStock", "Current Stock")})
        Me.PartEdit.DisplayMember = "Part"
        Me.PartEdit.DropDownRows = 10
        Me.PartEdit.Name = "PartEdit"
        Me.PartEdit.NullText = ""
        Me.PartEdit.ShowFooter = False
        Me.PartEdit.ValueMember = "PartCode"
        '
        'gMain
        '
        Me.gMain.Controls.Add(Me.lblComponent)
        Me.gMain.Controls.Add(Me.cboUnit)
        Me.gMain.Controls.Add(Me.cmdCopy)
        Me.gMain.Controls.Add(Me.cboMaintenance)
        Me.gMain.Controls.Add(Me.txtInsDesc)
        Me.gMain.Controls.Add(Me.LabelControl2)
        Me.gMain.Controls.Add(Me.LabelControl1)
        Me.gMain.Controls.Add(Me.cboRankCode)
        Me.gMain.Controls.Add(Me.LabelControl4)
        Me.gMain.Controls.Add(Me.txtExecutedBy)
        Me.gMain.Controls.Add(Me.LabelControl12)
        Me.gMain.Controls.Add(Me.LabelControl7)
        Me.gMain.Controls.Add(Me.txtRemarks)
        Me.gMain.Controls.Add(Me.LabelControl3)
        Me.gMain.Controls.Add(Me.txtWorkDate)
        Me.gMain.Controls.Add(Me.txtWorkCounter)
        Me.gMain.Controls.Add(Me.lblDate)
        Me.gMain.Location = New System.Drawing.Point(12, 31)
        Me.gMain.Name = "gMain"
        Me.gMain.Size = New System.Drawing.Size(309, 357)
        Me.gMain.TabIndex = 227
        Me.gMain.Text = "Current Maintenance"
        '
        'IGrid
        '
        Me.IGrid.Location = New System.Drawing.Point(329, 418)
        Me.IGrid.LookAndFeel.SkinName = "iMaginary"
        Me.IGrid.MainView = Me.IView
        Me.IGrid.Name = "IGrid"
        Me.IGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemLookUpEdit2, Me.iDeleteEdit})
        Me.IGrid.Size = New System.Drawing.Size(334, 150)
        Me.IGrid.TabIndex = 246
        Me.IGrid.TabStop = False
        Me.IGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.IView})
        '
        'IView
        '
        Me.IView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.IView.Appearance.RowSeparator.Options.UseBackColor = True
        Me.IView.Appearance.ViewCaption.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.IView.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Black
        Me.IView.Appearance.ViewCaption.Options.UseFont = True
        Me.IView.Appearance.ViewCaption.Options.UseForeColor = True
        Me.IView.Appearance.ViewCaption.Options.UseTextOptions = True
        Me.IView.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.IView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.FileDesc, Me.DocID, Me.FileName, Me.iDelete, Me.Doc})
        Me.IView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.IView.GridControl = Me.IGrid
        Me.IView.Name = "IView"
        Me.IView.NewItemRowText = "Click here to add new record"
        Me.IView.OptionsBehavior.AutoPopulateColumns = False
        Me.IView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.IView.OptionsBehavior.ReadOnly = True
        Me.IView.OptionsCustomization.AllowColumnMoving = False
        Me.IView.OptionsCustomization.AllowColumnResizing = False
        Me.IView.OptionsCustomization.AllowFilter = False
        Me.IView.OptionsCustomization.AllowGroup = False
        Me.IView.OptionsCustomization.AllowQuickHideColumns = False
        Me.IView.OptionsCustomization.AllowSort = False
        Me.IView.OptionsFilter.AllowFilterEditor = False
        Me.IView.OptionsFind.AllowFindPanel = False
        Me.IView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.IView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.IView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.IView.OptionsSelection.UseIndicatorForSelection = False
        Me.IView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button
        Me.IView.OptionsView.RowAutoHeight = True
        Me.IView.OptionsView.ShowColumnHeaders = False
        Me.IView.OptionsView.ShowGroupPanel = False
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
        'iDelete
        '
        Me.iDelete.Caption = "Delete"
        Me.iDelete.ColumnEdit = Me.iDeleteEdit
        Me.iDelete.MaxWidth = 20
        Me.iDelete.Name = "iDelete"
        Me.iDelete.Visible = True
        Me.iDelete.VisibleIndex = 1
        Me.iDelete.Width = 20
        '
        'iDeleteEdit
        '
        Me.iDeleteEdit.AutoHeight = False
        Me.iDeleteEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, CType(resources.GetObject("iDeleteEdit.Buttons"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, "", Nothing, Nothing, True)})
        Me.iDeleteEdit.Name = "iDeleteEdit"
        Me.iDeleteEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
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
        'cmdBrowse
        '
        Me.cmdBrowse.Location = New System.Drawing.Point(568, 394)
        Me.cmdBrowse.Name = "cmdBrowse"
        Me.cmdBrowse.Size = New System.Drawing.Size(95, 23)
        Me.cmdBrowse.TabIndex = 245
        Me.cmdBrowse.TabStop = False
        Me.cmdBrowse.Text = "Attach"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(329, 399)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(69, 13)
        Me.LabelControl5.TabIndex = 247
        Me.LabelControl5.Text = "Attachment(s)"
        '
        'LabelControl11
        '
        Me.LabelControl11.Appearance.ForeColor = System.Drawing.Color.Red
        Me.LabelControl11.Location = New System.Drawing.Point(13, 13)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(512, 13)
        Me.LabelControl11.TabIndex = 248
        Me.LabelControl11.Text = "* Please note that records will be locked for editing permanently 7 days after th" & _
    "ese were enter and saved."
        '
        'frmWork
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(676, 616)
        Me.Controls.Add(Me.LabelControl11)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.IGrid)
        Me.Controls.Add(Me.cmdBrowse)
        Me.Controls.Add(Me.gMain)
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.lblReadingDate)
        Me.Controls.Add(Me.lblRunningHours)
        Me.Controls.Add(Me.gPrevMaintenance)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmWork"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        CType(Me.cboMaintenance.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboUnit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UnitTree, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gPrevMaintenance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gPrevMaintenance.ResumeLayout(False)
        Me.gPrevMaintenance.PerformLayout()
        CType(Me.txtPRemarks.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPRunningHours.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPExec.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRemarks.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWorkDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWorkDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWorkCounter.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtExecutedBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboRankCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInsDesc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DeleteEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PartEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gMain.ResumeLayout(False)
        Me.gMain.PerformLayout()
        CType(Me.IGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.iDeleteEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboMaintenance As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblComponent As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboUnit As DevExpress.XtraEditors.TreeListLookUpEdit
    Friend WithEvents UnitTree As DevExpress.XtraTreeList.TreeList
    Friend WithEvents ParentCode As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents UnitCode As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents UnitDesc As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents gPrevMaintenance As DevExpress.XtraEditors.GroupControl
    Friend WithEvents txtPRemarks As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents txtPDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPRunningHours As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPExec As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtRemarks As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents txtWorkDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lblDate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtWorkCounter As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtExecutedBy As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboRankCode As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblReadingDate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblRunningHours As DevExpress.XtraEditors.LabelControl
    Friend WithEvents RunningHours As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents ReadingDate As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents txtInsDesc As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdCopy As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents MainGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents MainView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Part As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Edited As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents Delete As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DeleteEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents PartEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents PartConsumptionID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents OnStock As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PartCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gMain As DevExpress.XtraEditors.GroupControl
    Friend WithEvents IGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents IView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents FileDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DocID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FileName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents iDelete As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents iDeleteEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents Doc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents cmdBrowse As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
End Class
