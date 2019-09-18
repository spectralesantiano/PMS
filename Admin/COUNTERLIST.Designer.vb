<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class COUNTERLIST
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
        Me.MainView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.CounterCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CounterName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DeptCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CatCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UnitCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Active = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UnitDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Counter = New DevExpress.XtraGrid.Columns.GridColumn()
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
        Me.MainView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.CounterCode, Me.UnitDesc, Me.CounterName, Me.DeptCode, Me.CatCode, Me.UnitCode, Me.Active, Me.Counter})
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
        Me.MainView.OptionsView.ShowGroupPanel = False
        Me.MainView.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.CounterName, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'CounterCode
        '
        Me.CounterCode.Caption = "CounterCode"
        Me.CounterCode.FieldName = "CounterCode"
        Me.CounterCode.Name = "CounterCode"
        '
        'CounterName
        '
        Me.CounterName.Caption = "Counter"
        Me.CounterName.FieldName = "Name"
        Me.CounterName.Name = "CounterName"
        Me.CounterName.Visible = True
        Me.CounterName.VisibleIndex = 1
        Me.CounterName.Width = 105
        '
        'DeptCode
        '
        Me.DeptCode.Caption = "DeptCode"
        Me.DeptCode.FieldName = "DeptCode"
        Me.DeptCode.Name = "DeptCode"
        '
        'CatCode
        '
        Me.CatCode.Caption = "CatCode"
        Me.CatCode.FieldName = "CatCode"
        Me.CatCode.Name = "CatCode"
        '
        'UnitCode
        '
        Me.UnitCode.Caption = "UnitCode"
        Me.UnitCode.FieldName = "UnitCode"
        Me.UnitCode.Name = "UnitCode"
        '
        'Active
        '
        Me.Active.Caption = "Active"
        Me.Active.FieldName = "Active"
        Me.Active.MaxWidth = 45
        Me.Active.Name = "Active"
        Me.Active.Width = 45
        '
        'UnitDesc
        '
        Me.UnitDesc.Caption = "Unit"
        Me.UnitDesc.FieldName = "UnitDesc"
        Me.UnitDesc.Name = "UnitDesc"
        Me.UnitDesc.Visible = True
        Me.UnitDesc.VisibleIndex = 0
        Me.UnitDesc.Width = 180
        '
        'Counter
        '
        Me.Counter.Caption = "Counter"
        Me.Counter.FieldName = "Counter"
        Me.Counter.Name = "Counter"
        '
        'COUNTERLIST
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.MainGrid)
        Me.Name = "COUNTERLIST"
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents MainView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents CounterCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CounterName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DeptCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CatCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UnitCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Active As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UnitDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Counter As DevExpress.XtraGrid.Columns.GridColumn

End Class
