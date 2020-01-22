<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExportDocuments
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExportDocuments))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.cmdExport = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdClose = New DevExpress.XtraEditors.SimpleButton()
        Me.txtExportDir = New DevExpress.XtraEditors.ButtonEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.lblLastExp = New DevExpress.XtraEditors.LabelControl()
        Me.MainGrid = New DevExpress.XtraGrid.GridControl()
        Me.MainView = New DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView()
        Me.gridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.FileDesc = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.DocDesc = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.DateUpdated = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Selected = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.DocID = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        CType(Me.txtExportDir.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(244, 27)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(83, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Export Directory:"
        '
        'cmdExport
        '
        Me.cmdExport.Location = New System.Drawing.Point(521, 487)
        Me.cmdExport.Name = "cmdExport"
        Me.cmdExport.Size = New System.Drawing.Size(66, 23)
        Me.cmdExport.TabIndex = 14
        Me.cmdExport.Text = "Export"
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(593, 487)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(66, 23)
        Me.cmdClose.TabIndex = 15
        Me.cmdClose.Text = "Cancel"
        '
        'txtExportDir
        '
        Me.txtExportDir.Location = New System.Drawing.Point(348, 24)
        Me.txtExportDir.Name = "txtExportDir"
        Me.txtExportDir.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtExportDir.Size = New System.Drawing.Size(311, 20)
        Me.txtExportDir.TabIndex = 0
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(21, 27)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(85, 13)
        Me.LabelControl5.TabIndex = 15
        Me.LabelControl5.Text = "Date Last Export:"
        '
        'lblLastExp
        '
        Me.lblLastExp.Location = New System.Drawing.Point(126, 27)
        Me.lblLastExp.Name = "lblLastExp"
        Me.lblLastExp.Size = New System.Drawing.Size(18, 13)
        Me.lblLastExp.TabIndex = 21
        Me.lblLastExp.Text = "N/A"
        '
        'MainGrid
        '
        Me.MainGrid.Location = New System.Drawing.Point(21, 83)
        Me.MainGrid.LookAndFeel.SkinName = "iMaginary"
        Me.MainGrid.MainView = Me.MainView
        Me.MainGrid.Name = "MainGrid"
        Me.MainGrid.Size = New System.Drawing.Size(638, 387)
        Me.MainGrid.TabIndex = 22
        Me.MainGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MainView})
        '
        'MainView
        '
        Me.MainView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.MainView.Appearance.RowSeparator.Options.UseBackColor = True
        Me.MainView.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand4})
        Me.MainView.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.DocID, Me.FileDesc, Me.DocDesc, Me.DateUpdated, Me.Selected})
        Me.MainView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.MainView.GridControl = Me.MainGrid
        Me.MainView.Name = "MainView"
        Me.MainView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.MainView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.MainView.OptionsBehavior.AutoPopulateColumns = False
        Me.MainView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.MainView.OptionsCustomization.AllowFilter = False
        Me.MainView.OptionsCustomization.AllowGroup = False
        Me.MainView.OptionsCustomization.AllowQuickHideColumns = False
        Me.MainView.OptionsFind.AllowFindPanel = False
        Me.MainView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.MainView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.MainView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.MainView.OptionsSelection.UseIndicatorForSelection = False
        Me.MainView.OptionsView.ColumnAutoWidth = True
        Me.MainView.OptionsView.ShowBands = False
        Me.MainView.OptionsView.ShowGroupPanel = False
        '
        'gridBand4
        '
        Me.gridBand4.Caption = "gridBand4"
        Me.gridBand4.Columns.Add(Me.FileDesc)
        Me.gridBand4.Columns.Add(Me.DocDesc)
        Me.gridBand4.Columns.Add(Me.DateUpdated)
        Me.gridBand4.Columns.Add(Me.Selected)
        Me.gridBand4.Name = "gridBand4"
        Me.gridBand4.VisibleIndex = 0
        Me.gridBand4.Width = 655
        '
        'FileDesc
        '
        Me.FileDesc.Caption = "File"
        Me.FileDesc.FieldName = "FileDesc"
        Me.FileDesc.Name = "FileDesc"
        Me.FileDesc.OptionsColumn.ReadOnly = True
        Me.FileDesc.Visible = True
        Me.FileDesc.Width = 297
        '
        'DocDesc
        '
        Me.DocDesc.Caption = "Doc. Type"
        Me.DocDesc.FieldName = "DocDesc"
        Me.DocDesc.Name = "DocDesc"
        Me.DocDesc.OptionsColumn.ReadOnly = True
        Me.DocDesc.Visible = True
        Me.DocDesc.Width = 204
        '
        'DateUpdated
        '
        Me.DateUpdated.Caption = "Date Added"
        Me.DateUpdated.DisplayFormat.FormatString = "d"
        Me.DateUpdated.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateUpdated.FieldName = "DateUpdated"
        Me.DateUpdated.Name = "DateUpdated"
        Me.DateUpdated.OptionsColumn.AllowSize = False
        Me.DateUpdated.OptionsColumn.ReadOnly = True
        Me.DateUpdated.Visible = True
        Me.DateUpdated.Width = 134
        '
        'Selected
        '
        Me.Selected.Caption = " "
        Me.Selected.FieldName = "Selected"
        Me.Selected.Name = "Selected"
        Me.Selected.Visible = True
        Me.Selected.Width = 20
        '
        'DocID
        '
        Me.DocID.Caption = "DocID"
        Me.DocID.FieldName = "DocID"
        Me.DocID.Name = "DocID"
        '
        'frmExportDocuments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(682, 526)
        Me.Controls.Add(Me.MainGrid)
        Me.Controls.Add(Me.lblLastExp)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.cmdExport)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.txtExportDir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmExportDocuments"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Export Documents"
        CType(Me.txtExportDir.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdExport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtExportDir As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblLastExp As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MainGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents MainView As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents FileDesc As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents DocID As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents DateUpdated As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Selected As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents DocDesc As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
End Class
