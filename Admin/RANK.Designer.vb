<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RANK
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
        Me.MainGrid = New DevExpress.XtraGrid.GridControl()
        Me.MainView = New DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView()
        Me.RankDesc = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Abbrv = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Department = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Type = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.SortCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ChineseName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RankCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.DeptCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RankTypeCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
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
        Me.MainGrid.Size = New System.Drawing.Size(329, 333)
        Me.MainGrid.TabIndex = 2
        Me.MainGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MainView})
        '
        'MainView
        '
        Me.MainView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.MainView.Appearance.RowSeparator.Options.UseBackColor = True
        Me.MainView.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand4})
        Me.MainView.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.RankCode, Me.RankDesc, Me.Abbrv, Me.SortCode, Me.Department, Me.Type, Me.DeptCode, Me.RankTypeCode, Me.ChineseName})
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
        '
        'RankDesc
        '
        Me.RankDesc.Caption = "Rank"
        Me.RankDesc.FieldName = "RankDesc"
        Me.RankDesc.Name = "RankDesc"
        Me.RankDesc.Visible = True
        Me.RankDesc.Width = 423
        '
        'Abbrv
        '
        Me.Abbrv.Caption = "Abbreviation"
        Me.Abbrv.FieldName = "Abbrv"
        Me.Abbrv.Name = "Abbrv"
        Me.Abbrv.Visible = True
        Me.Abbrv.Width = 181
        '
        'Department
        '
        Me.Department.Caption = "Department"
        Me.Department.FieldName = "Department"
        Me.Department.Name = "Department"
        Me.Department.Visible = True
        Me.Department.Width = 146
        '
        'Type
        '
        Me.Type.Caption = "Type"
        Me.Type.FieldName = "Type"
        Me.Type.Name = "Type"
        Me.Type.Visible = True
        Me.Type.Width = 194
        '
        'SortCode
        '
        Me.SortCode.Caption = "Sort Code"
        Me.SortCode.FieldName = "SortCode"
        Me.SortCode.Name = "SortCode"
        Me.SortCode.Visible = True
        Me.SortCode.Width = 128
        '
        'ChineseName
        '
        Me.ChineseName.FieldName = "ChineseName"
        Me.ChineseName.Name = "ChineseName"
        Me.ChineseName.RowIndex = 2
        '
        'RankCode
        '
        Me.RankCode.Caption = "RankCode"
        Me.RankCode.FieldName = "RankCode"
        Me.RankCode.Name = "RankCode"
        '
        'DeptCode
        '
        Me.DeptCode.FieldName = "DeptCode"
        Me.DeptCode.Name = "DeptCode"
        '
        'RankTypeCode
        '
        Me.RankTypeCode.FieldName = "RankTypeCode"
        Me.RankTypeCode.Name = "RankTypeCode"
        '
        'gridBand4
        '
        Me.gridBand4.Caption = "gridBand4"
        Me.gridBand4.Columns.Add(Me.RankDesc)
        Me.gridBand4.Columns.Add(Me.Abbrv)
        Me.gridBand4.Columns.Add(Me.Department)
        Me.gridBand4.Columns.Add(Me.Type)
        Me.gridBand4.Columns.Add(Me.SortCode)
        Me.gridBand4.Columns.Add(Me.ChineseName)
        Me.gridBand4.Name = "gridBand4"
        Me.gridBand4.VisibleIndex = 0
        Me.gridBand4.Width = 1072
        '
        'RANK
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.MainGrid)
        Me.Name = "RANK"
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents MainView As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents RankDesc As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents SortCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Abbrv As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Department As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Type As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RankCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents DeptCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RankTypeCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ChineseName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand

End Class
