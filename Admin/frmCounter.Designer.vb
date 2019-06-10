<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCounter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCounter))
        Me.cmdSave = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.gDetails = New DevExpress.XtraEditors.GroupControl()
        Me.MainGrid = New DevExpress.XtraGrid.GridControl()
        Me.MainView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.CounterReadingID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Counter = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ReadingDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Reading = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Edited = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CounterCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Latest = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CounterEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.txtName = New DevExpress.XtraEditors.TextEdit()
        Me.chkAdd = New DevExpress.XtraEditors.CheckEdit()
        Me.cmdAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.txtRunningHours = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.gDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gDetails.SuspendLayout()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CounterEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkAdd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRunningHours.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdSave
        '
        Me.cmdSave.Enabled = False
        Me.cmdSave.Location = New System.Drawing.Point(326, 310)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(69, 23)
        Me.cmdSave.TabIndex = 4
        Me.cmdSave.Text = "Save"
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(412, 310)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(69, 23)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.Text = "Cancel"
        '
        'gDetails
        '
        Me.gDetails.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gDetails.AppearanceCaption.Options.UseFont = True
        Me.gDetails.Controls.Add(Me.MainGrid)
        Me.gDetails.Location = New System.Drawing.Point(22, 52)
        Me.gDetails.Name = "gDetails"
        Me.gDetails.Size = New System.Drawing.Size(461, 241)
        Me.gDetails.TabIndex = 0
        Me.gDetails.Text = "Counter History"
        '
        'MainGrid
        '
        Me.MainGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainGrid.Location = New System.Drawing.Point(2, 23)
        Me.MainGrid.LookAndFeel.SkinName = "iMaginary"
        Me.MainGrid.MainView = Me.MainView
        Me.MainGrid.Name = "MainGrid"
        Me.MainGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CounterEdit})
        Me.MainGrid.Size = New System.Drawing.Size(457, 216)
        Me.MainGrid.TabIndex = 38
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
        Me.MainView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.CounterReadingID, Me.Counter, Me.ReadingDate, Me.Reading, Me.Edited, Me.CounterCode, Me.Latest})
        Me.MainView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.MainView.GridControl = Me.MainGrid
        Me.MainView.Name = "MainView"
        Me.MainView.NewItemRowText = "Click here to add new record"
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
        Me.MainView.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ReadingDate, DevExpress.Data.ColumnSortOrder.Descending)})
        '
        'CounterReadingID
        '
        Me.CounterReadingID.Caption = "CounterReadingID"
        Me.CounterReadingID.FieldName = "CounterReadingID"
        Me.CounterReadingID.Name = "CounterReadingID"
        '
        'Counter
        '
        Me.Counter.Caption = "Counter"
        Me.Counter.FieldName = "Counter"
        Me.Counter.Name = "Counter"
        Me.Counter.OptionsColumn.AllowEdit = False
        Me.Counter.OptionsColumn.ReadOnly = True
        Me.Counter.Visible = True
        Me.Counter.VisibleIndex = 0
        Me.Counter.Width = 159
        '
        'ReadingDate
        '
        Me.ReadingDate.Caption = "Reading Date"
        Me.ReadingDate.DisplayFormat.FormatString = "d"
        Me.ReadingDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ReadingDate.FieldName = "ReadingDate"
        Me.ReadingDate.MaxWidth = 90
        Me.ReadingDate.MinWidth = 90
        Me.ReadingDate.Name = "ReadingDate"
        Me.ReadingDate.Visible = True
        Me.ReadingDate.VisibleIndex = 1
        Me.ReadingDate.Width = 90
        '
        'Reading
        '
        Me.Reading.Caption = "Reading"
        Me.Reading.FieldName = "Reading"
        Me.Reading.MaxWidth = 70
        Me.Reading.MinWidth = 70
        Me.Reading.Name = "Reading"
        Me.Reading.Visible = True
        Me.Reading.VisibleIndex = 2
        Me.Reading.Width = 70
        '
        'Edited
        '
        Me.Edited.Caption = "Edited"
        Me.Edited.FieldName = "Edited"
        Me.Edited.Name = "Edited"
        '
        'CounterCode
        '
        Me.CounterCode.Caption = "CounterCode"
        Me.CounterCode.FieldName = "CounterCode"
        Me.CounterCode.Name = "CounterCode"
        '
        'Latest
        '
        Me.Latest.Caption = "Latest"
        Me.Latest.FieldName = "Latest"
        Me.Latest.Name = "Latest"
        '
        'CounterEdit
        '
        Me.CounterEdit.AutoHeight = False
        Me.CounterEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CounterEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CounterCode", "Name10", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Counter", "Name12")})
        Me.CounterEdit.DisplayMember = "Counter"
        Me.CounterEdit.DropDownRows = 10
        Me.CounterEdit.Name = "CounterEdit"
        Me.CounterEdit.NullText = ""
        Me.CounterEdit.ShowFooter = False
        Me.CounterEdit.ShowHeader = False
        Me.CounterEdit.ValueMember = "CounterCode"
        '
        'txtName
        '
        Me.txtName.Enabled = False
        Me.txtName.Location = New System.Drawing.Point(149, 20)
        Me.txtName.Name = "txtName"
        Me.txtName.Properties.MaxLength = 30
        Me.txtName.Size = New System.Drawing.Size(258, 20)
        Me.txtName.TabIndex = 34
        '
        'chkAdd
        '
        Me.chkAdd.Location = New System.Drawing.Point(24, 20)
        Me.chkAdd.Name = "chkAdd"
        Me.chkAdd.Properties.Caption = "New Counter:"
        Me.chkAdd.Size = New System.Drawing.Size(119, 19)
        Me.chkAdd.TabIndex = 33
        '
        'cmdAdd
        '
        Me.cmdAdd.Enabled = False
        Me.cmdAdd.Location = New System.Drawing.Point(423, 18)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(58, 23)
        Me.cmdAdd.TabIndex = 35
        Me.cmdAdd.Text = "Add"
        '
        'txtRunningHours
        '
        Me.txtRunningHours.Enabled = False
        Me.txtRunningHours.Location = New System.Drawing.Point(105, 312)
        Me.txtRunningHours.Name = "txtRunningHours"
        Me.txtRunningHours.Properties.MaxLength = 30
        Me.txtRunningHours.Properties.ReadOnly = True
        Me.txtRunningHours.Size = New System.Drawing.Size(89, 20)
        Me.txtRunningHours.TabIndex = 40
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(24, 315)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(74, 13)
        Me.LabelControl4.TabIndex = 41
        Me.LabelControl4.Text = "Running Hours:"
        '
        'frmCounter
        '
        Me.AcceptButton = Me.cmdSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(502, 354)
        Me.Controls.Add(Me.txtRunningHours)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.chkAdd)
        Me.Controls.Add(Me.gDetails)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.LookAndFeel.SkinName = "iMaginary"
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCounter"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Counter Information"
        Me.TopMost = True
        CType(Me.gDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gDetails.ResumeLayout(False)
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CounterEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkAdd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRunningHours.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents gDetails As DevExpress.XtraEditors.GroupControl
    Friend WithEvents MainGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents MainView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents CounterReadingID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Counter As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ReadingDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CounterEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents Reading As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Edited As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents chkAdd As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cmdAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtRunningHours As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CounterCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Latest As DevExpress.XtraGrid.Columns.GridColumn
End Class
