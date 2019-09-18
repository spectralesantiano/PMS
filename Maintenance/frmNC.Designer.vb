<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNC))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.lblDate = New DevExpress.XtraEditors.LabelControl()
        Me.gDetails = New DevExpress.XtraEditors.GroupControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.txtObjectives = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.txtCauses = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.txtImmediateAction = New DevExpress.XtraEditors.MemoEdit()
        Me.txtDiscoveredBy = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.txtReportedTo = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.txtStatus = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.txtDescription = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtWorkCounter = New DevExpress.XtraEditors.TextEdit()
        Me.txtWorkDate = New DevExpress.XtraEditors.DateEdit()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.MainGrid = New DevExpress.XtraGrid.GridControl()
        Me.MainView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.NCCorrectiveMeasureID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Description = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RankCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RankEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.DueDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DoneDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Edited = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Delete = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DeleteEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        CType(Me.gDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gDetails.SuspendLayout()
        CType(Me.txtObjectives.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCauses.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtImmediateAction.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDiscoveredBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtReportedTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWorkCounter.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWorkDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWorkDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RankEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DeleteEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(508, 576)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(96, 23)
        Me.cmdOk.TabIndex = 7
        Me.cmdOk.Text = "Save"
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(610, 576)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(96, 23)
        Me.cmdCancel.TabIndex = 8
        Me.cmdCancel.Text = "Cancel"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(393, 44)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(58, 13)
        Me.LabelControl2.TabIndex = 45
        Me.LabelControl2.Text = "Reported to"
        '
        'lblDate
        '
        Me.lblDate.Location = New System.Drawing.Point(22, 42)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(32, 13)
        Me.lblDate.TabIndex = 189
        Me.lblDate.Text = "* Date"
        '
        'gDetails
        '
        Me.gDetails.Controls.Add(Me.LabelControl6)
        Me.gDetails.Controls.Add(Me.txtObjectives)
        Me.gDetails.Controls.Add(Me.LabelControl8)
        Me.gDetails.Controls.Add(Me.txtCauses)
        Me.gDetails.Controls.Add(Me.LabelControl5)
        Me.gDetails.Controls.Add(Me.txtImmediateAction)
        Me.gDetails.Controls.Add(Me.txtDiscoveredBy)
        Me.gDetails.Controls.Add(Me.LabelControl7)
        Me.gDetails.Controls.Add(Me.txtReportedTo)
        Me.gDetails.Controls.Add(Me.LabelControl4)
        Me.gDetails.Controls.Add(Me.txtStatus)
        Me.gDetails.Controls.Add(Me.LabelControl3)
        Me.gDetails.Controls.Add(Me.txtDescription)
        Me.gDetails.Controls.Add(Me.LabelControl1)
        Me.gDetails.Controls.Add(Me.txtWorkCounter)
        Me.gDetails.Controls.Add(Me.LabelControl2)
        Me.gDetails.Controls.Add(Me.lblDate)
        Me.gDetails.Controls.Add(Me.txtWorkDate)
        Me.gDetails.Location = New System.Drawing.Point(20, 22)
        Me.gDetails.Name = "gDetails"
        Me.gDetails.Size = New System.Drawing.Size(686, 248)
        Me.gDetails.TabIndex = 190
        Me.gDetails.Text = "Non-Conformity for:"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(346, 167)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(51, 13)
        Me.LabelControl6.TabIndex = 208
        Me.LabelControl6.Text = "Objectives"
        '
        'txtObjectives
        '
        Me.txtObjectives.Location = New System.Drawing.Point(344, 186)
        Me.txtObjectives.Name = "txtObjectives"
        Me.txtObjectives.Size = New System.Drawing.Size(322, 43)
        Me.txtObjectives.TabIndex = 5
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(25, 167)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(44, 13)
        Me.LabelControl8.TabIndex = 206
        Me.LabelControl8.Text = "* Causes"
        '
        'txtCauses
        '
        Me.txtCauses.Location = New System.Drawing.Point(23, 186)
        Me.txtCauses.Name = "txtCauses"
        Me.txtCauses.Size = New System.Drawing.Size(322, 43)
        Me.txtCauses.TabIndex = 4
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(346, 93)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(121, 13)
        Me.LabelControl5.TabIndex = 204
        Me.LabelControl5.Text = "* Immediate action taken"
        '
        'txtImmediateAction
        '
        Me.txtImmediateAction.Location = New System.Drawing.Point(344, 112)
        Me.txtImmediateAction.Name = "txtImmediateAction"
        Me.txtImmediateAction.Size = New System.Drawing.Size(322, 43)
        Me.txtImmediateAction.TabIndex = 3
        '
        'txtDiscoveredBy
        '
        Me.txtDiscoveredBy.Location = New System.Drawing.Point(195, 61)
        Me.txtDiscoveredBy.Name = "txtDiscoveredBy"
        Me.txtDiscoveredBy.Properties.MaxLength = 30
        Me.txtDiscoveredBy.Size = New System.Drawing.Size(199, 20)
        Me.txtDiscoveredBy.TabIndex = 0
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(195, 44)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(68, 13)
        Me.LabelControl7.TabIndex = 201
        Me.LabelControl7.Text = "Discovered by"
        '
        'txtReportedTo
        '
        Me.txtReportedTo.Location = New System.Drawing.Point(393, 61)
        Me.txtReportedTo.Name = "txtReportedTo"
        Me.txtReportedTo.Properties.MaxLength = 30
        Me.txtReportedTo.Size = New System.Drawing.Size(199, 20)
        Me.txtReportedTo.TabIndex = 1
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(592, 44)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl4.TabIndex = 198
        Me.LabelControl4.Text = "Status"
        '
        'txtStatus
        '
        Me.txtStatus.EditValue = ""
        Me.txtStatus.Enabled = False
        Me.txtStatus.Location = New System.Drawing.Point(591, 61)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtStatus.Properties.Appearance.Options.UseBackColor = True
        Me.txtStatus.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtStatus.Properties.Mask.EditMask = "f0"
        Me.txtStatus.Size = New System.Drawing.Size(75, 20)
        Me.txtStatus.TabIndex = 5
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(25, 93)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(62, 13)
        Me.LabelControl3.TabIndex = 194
        Me.LabelControl3.Text = "* Description"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(23, 112)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(322, 43)
        Me.txtDescription.TabIndex = 2
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(121, 42)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(39, 13)
        Me.LabelControl1.TabIndex = 192
        Me.LabelControl1.Text = "Counter"
        '
        'txtWorkCounter
        '
        Me.txtWorkCounter.EditValue = ""
        Me.txtWorkCounter.Enabled = False
        Me.txtWorkCounter.Location = New System.Drawing.Point(121, 61)
        Me.txtWorkCounter.Name = "txtWorkCounter"
        Me.txtWorkCounter.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtWorkCounter.Properties.Appearance.Options.UseBackColor = True
        Me.txtWorkCounter.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtWorkCounter.Properties.Mask.EditMask = "f0"
        Me.txtWorkCounter.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtWorkCounter.Size = New System.Drawing.Size(75, 20)
        Me.txtWorkCounter.TabIndex = 2
        '
        'txtWorkDate
        '
        Me.txtWorkDate.EditValue = Nothing
        Me.txtWorkDate.Enabled = False
        Me.txtWorkDate.Location = New System.Drawing.Point(23, 61)
        Me.txtWorkDate.Name = "txtWorkDate"
        Me.txtWorkDate.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtWorkDate.Properties.Appearance.Options.UseBackColor = True
        Me.txtWorkDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtWorkDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtWorkDate.Properties.EditFormat.FormatString = ""
        Me.txtWorkDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtWorkDate.Size = New System.Drawing.Size(99, 20)
        Me.txtWorkDate.TabIndex = 1
        '
        'GroupControl1
        '
        Me.GroupControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupControl1.Controls.Add(Me.MainGrid)
        Me.GroupControl1.Location = New System.Drawing.Point(20, 287)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(686, 274)
        Me.GroupControl1.TabIndex = 191
        Me.GroupControl1.Text = "List of Measures"
        '
        'MainGrid
        '
        Me.MainGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainGrid.Location = New System.Drawing.Point(2, 23)
        Me.MainGrid.LookAndFeel.SkinName = "iMaginary"
        Me.MainGrid.MainView = Me.MainView
        Me.MainGrid.Name = "MainGrid"
        Me.MainGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.DeleteEdit, Me.RankEdit})
        Me.MainGrid.Size = New System.Drawing.Size(682, 249)
        Me.MainGrid.TabIndex = 37
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
        Me.MainView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.MainView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.NCCorrectiveMeasureID, Me.Description, Me.RankCode, Me.DueDate, Me.DoneDate, Me.Edited, Me.Delete})
        Me.MainView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.MainView.GridControl = Me.MainGrid
        Me.MainView.Name = "MainView"
        Me.MainView.NewItemRowText = "Click here to add new record"
        Me.MainView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
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
        Me.MainView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.MainView.OptionsView.RowAutoHeight = True
        Me.MainView.OptionsView.ShowGroupPanel = False
        Me.MainView.RowSeparatorHeight = 3
        '
        'NCCorrectiveMeasureID
        '
        Me.NCCorrectiveMeasureID.Caption = "NCCorrectiveMeasureID"
        Me.NCCorrectiveMeasureID.FieldName = "NCCorrectiveMeasureID"
        Me.NCCorrectiveMeasureID.Name = "NCCorrectiveMeasureID"
        '
        'Description
        '
        Me.Description.Caption = "Corrective measures"
        Me.Description.FieldName = "Description"
        Me.Description.Name = "Description"
        Me.Description.Visible = True
        Me.Description.VisibleIndex = 0
        Me.Description.Width = 211
        '
        'RankCode
        '
        Me.RankCode.Caption = "Responsible"
        Me.RankCode.ColumnEdit = Me.RankEdit
        Me.RankCode.FieldName = "RankCode"
        Me.RankCode.Name = "RankCode"
        Me.RankCode.Visible = True
        Me.RankCode.VisibleIndex = 1
        Me.RankCode.Width = 128
        '
        'RankEdit
        '
        Me.RankEdit.AutoHeight = False
        Me.RankEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RankEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("RankCode", "Name10", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Abbrv", "Name12")})
        Me.RankEdit.DisplayMember = "Abbrv"
        Me.RankEdit.DropDownRows = 10
        Me.RankEdit.Name = "RankEdit"
        Me.RankEdit.NullText = ""
        Me.RankEdit.ShowFooter = False
        Me.RankEdit.ShowHeader = False
        Me.RankEdit.ValueMember = "RankCode"
        '
        'DueDate
        '
        Me.DueDate.Caption = "Due Date"
        Me.DueDate.FieldName = "DueDate"
        Me.DueDate.Name = "DueDate"
        Me.DueDate.Visible = True
        Me.DueDate.VisibleIndex = 2
        Me.DueDate.Width = 69
        '
        'DoneDate
        '
        Me.DoneDate.AppearanceCell.Options.UseFont = True
        Me.DoneDate.Caption = "Done Date"
        Me.DoneDate.FieldName = "DoneDate"
        Me.DoneDate.Name = "DoneDate"
        Me.DoneDate.Visible = True
        Me.DoneDate.VisibleIndex = 3
        Me.DoneDate.Width = 69
        '
        'Edited
        '
        Me.Edited.Caption = "Edited"
        Me.Edited.FieldName = "Edited"
        Me.Edited.Name = "Edited"
        Me.Edited.Width = 26
        '
        'Delete
        '
        Me.Delete.ColumnEdit = Me.DeleteEdit
        Me.Delete.MaxWidth = 26
        Me.Delete.MinWidth = 26
        Me.Delete.Name = "Delete"
        Me.Delete.Visible = True
        Me.Delete.VisibleIndex = 4
        Me.Delete.Width = 26
        '
        'DeleteEdit
        '
        Me.DeleteEdit.AutoHeight = False
        Me.DeleteEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, CType(resources.GetObject("DeleteEdit.Buttons"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.DeleteEdit.Name = "DeleteEdit"
        Me.DeleteEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'frmNC
        '
        Me.AcceptButton = Me.cmdOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(725, 621)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.gDetails)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNC"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Non-Conformity"
        Me.TopMost = True
        CType(Me.gDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gDetails.ResumeLayout(False)
        Me.gDetails.PerformLayout()
        CType(Me.txtObjectives.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCauses.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtImmediateAction.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDiscoveredBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtReportedTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWorkCounter.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWorkDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWorkDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RankEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DeleteEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblDate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents gDetails As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtWorkCounter As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtWorkDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtStatus As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtDescription As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents txtReportedTo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtObjectives As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtCauses As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtImmediateAction As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents txtDiscoveredBy As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents MainGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents RankEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents DeleteEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents MainView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents NCCorrectiveMeasureID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Description As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RankCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DueDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DoneDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Edited As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Delete As DevExpress.XtraGrid.Columns.GridColumn
End Class
