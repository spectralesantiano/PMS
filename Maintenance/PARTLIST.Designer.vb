<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PARTLIST
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
        Me.Part = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PartNumber = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.OnStock = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Minimum = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.InitStock = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PartCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.LocCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.StorageCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Critical = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.CriticalDisp = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
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
        Me.MainGrid.Size = New System.Drawing.Size(568, 323)
        Me.MainGrid.TabIndex = 2
        Me.MainGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MainView})
        '
        'MainView
        '
        Me.MainView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.MainView.Appearance.RowSeparator.Options.UseBackColor = True
        Me.MainView.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand4})
        Me.MainView.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.PartCode, Me.Part, Me.PartNumber, Me.OnStock, Me.Minimum, Me.InitStock, Me.LocCode, Me.StorageCode, Me.Critical, Me.CriticalDisp})
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
        Me.MainView.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.Part, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'Part
        '
        Me.Part.Caption = "Part"
        Me.Part.FieldName = "Part"
        Me.Part.Name = "Part"
        Me.Part.Visible = True
        Me.Part.Width = 212
        '
        'PartNumber
        '
        Me.PartNumber.Caption = "Part Number"
        Me.PartNumber.FieldName = "PartNumber"
        Me.PartNumber.Name = "PartNumber"
        Me.PartNumber.Visible = True
        Me.PartNumber.Width = 376
        '
        'OnStock
        '
        Me.OnStock.Caption = "Current Stock"
        Me.OnStock.FieldName = "OnStock"
        Me.OnStock.MinWidth = 80
        Me.OnStock.Name = "OnStock"
        Me.OnStock.Visible = True
        Me.OnStock.Width = 102
        '
        'Minimum
        '
        Me.Minimum.Caption = "Minimum"
        Me.Minimum.FieldName = "Minimum"
        Me.Minimum.MinWidth = 80
        Me.Minimum.Name = "Minimum"
        Me.Minimum.Width = 80
        '
        'InitStock
        '
        Me.InitStock.Caption = "InitStock"
        Me.InitStock.FieldName = "InitStock"
        Me.InitStock.MinWidth = 80
        Me.InitStock.Name = "InitStock"
        Me.InitStock.Width = 80
        '
        'PartCode
        '
        Me.PartCode.Caption = "PartCode"
        Me.PartCode.FieldName = "PartCode"
        Me.PartCode.Name = "PartCode"
        '
        'LocCode
        '
        Me.LocCode.Caption = "LocCode"
        Me.LocCode.FieldName = "LocCode"
        Me.LocCode.Name = "LocCode"
        '
        'StorageCode
        '
        Me.StorageCode.Caption = "StorageCode"
        Me.StorageCode.FieldName = "StorageCode"
        Me.StorageCode.Name = "StorageCode"
        '
        'Critical
        '
        Me.Critical.Caption = "Criticalx"
        Me.Critical.FieldName = "Critical"
        Me.Critical.Name = "Critical"
        '
        'CriticalDisp
        '
        Me.CriticalDisp.Caption = "Critical"
        Me.CriticalDisp.MinWidth = 50
        Me.CriticalDisp.Name = "CriticalDisp"
        Me.CriticalDisp.Visible = True
        Me.CriticalDisp.Width = 60
        '
        'gridBand4
        '
        Me.gridBand4.Caption = "gridBand4"
        Me.gridBand4.Columns.Add(Me.Part)
        Me.gridBand4.Columns.Add(Me.PartNumber)
        Me.gridBand4.Columns.Add(Me.OnStock)
        Me.gridBand4.Columns.Add(Me.CriticalDisp)
        Me.gridBand4.Columns.Add(Me.Minimum)
        Me.gridBand4.Columns.Add(Me.InitStock)
        Me.gridBand4.Name = "gridBand4"
        Me.gridBand4.VisibleIndex = 0
        Me.gridBand4.Width = 750
        '
        'PARTLIST
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.MainGrid)
        Me.Name = "PARTLIST"
        Me.Size = New System.Drawing.Size(568, 323)
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents MainView As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents PartNumber As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Part As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents PartCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents OnStock As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Minimum As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents InitStock As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents LocCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents StorageCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Critical As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents CriticalDisp As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand

End Class
