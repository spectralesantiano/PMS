<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MAKERLIST
    Inherits BaseControl.BaseList

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
        Me.MainGrid = New DevExpress.XtraGrid.GridControl()
        Me.MainView = New DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView()
        Me.gridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.Maker = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.MakerCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainGrid
        '
        Me.MainGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainGrid.Location = New System.Drawing.Point(0, 0)
        Me.MainGrid.LookAndFeel.SkinName = "iMaginary"
        Me.MainGrid.MainView = Me.MainView
        Me.MainGrid.Name = "MainGrid"
        Me.MainGrid.Size = New System.Drawing.Size(303, 323)
        Me.MainGrid.TabIndex = 2
        Me.MainGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MainView})
        '
        'MainView
        '
        Me.MainView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.MainView.Appearance.RowSeparator.Options.UseBackColor = True
        Me.MainView.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand4})
        Me.MainView.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.MakerCode, Me.Maker})
        Me.MainView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.MainView.GridControl = Me.MainGrid
        Me.MainView.Name = "MainView"
        Me.MainView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.MainView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.MainView.OptionsBehavior.AutoPopulateColumns = False
        Me.MainView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.MainView.OptionsBehavior.Editable = False
        Me.MainView.OptionsCustomization.AllowFilter = False
        Me.MainView.OptionsCustomization.AllowGroup = False
        Me.MainView.OptionsCustomization.AllowQuickHideColumns = False
        Me.MainView.OptionsFind.AlwaysVisible = True
        Me.MainView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.MainView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.MainView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.MainView.OptionsSelection.UseIndicatorForSelection = False
        Me.MainView.OptionsView.ColumnAutoWidth = True
        Me.MainView.OptionsView.ShowBands = False
        Me.MainView.OptionsView.ShowGroupPanel = False
        Me.MainView.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.Maker, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'gridBand4
        '
        Me.gridBand4.Caption = "gridBand4"
        Me.gridBand4.Columns.Add(Me.Maker)
        Me.gridBand4.Name = "gridBand4"
        Me.gridBand4.VisibleIndex = 0
        Me.gridBand4.Width = 253
        '
        'Maker
        '
        Me.Maker.Caption = "Maker"
        Me.Maker.FieldName = "Maker"
        Me.Maker.Name = "Maker"
        Me.Maker.Visible = True
        Me.Maker.Width = 253
        '
        'MakerCode
        '
        Me.MakerCode.Caption = "MakerCode"
        Me.MakerCode.FieldName = "MakerCode"
        Me.MakerCode.Name = "MakerCode"
        '
        'MAKERLIST
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.MainGrid)
        Me.Name = "MAKERLIST"
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents MainView As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents Maker As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents MakerCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand

End Class
