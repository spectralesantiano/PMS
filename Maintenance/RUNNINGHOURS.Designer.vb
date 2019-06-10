<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RUNNINGHOURS
    Inherits BaseControl.BaseControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.gridBand6 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.UnitDesc = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PrevBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.PrevCounter = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PrevDate = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PrevReading = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.CurrBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.CurrCounter = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.CurrDate = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.CurrReading = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.NewBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.NewDate = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.NewReading = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gSummary = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.HoursRun = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.HoursPerDay = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.AvgHoursPerDay = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.UnitCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.CounterCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.CounterReadingID = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Edited = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.CatCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.DeptCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.header = New DevExpress.XtraEditors.GroupControl()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainGrid
        '
        Me.MainGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainGrid.Location = New System.Drawing.Point(2, 23)
        Me.MainGrid.LookAndFeel.SkinName = "iMaginary"
        Me.MainGrid.MainView = Me.MainView
        Me.MainGrid.Name = "MainGrid"
        Me.MainGrid.Size = New System.Drawing.Size(1194, 329)
        Me.MainGrid.TabIndex = 0
        Me.MainGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MainView})
        '
        'MainView
        '
        Me.MainView.Appearance.GroupPanel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainView.Appearance.GroupPanel.Options.UseFont = True
        Me.MainView.Appearance.GroupRow.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Transparent
        Me.MainView.Appearance.GroupRow.Options.UseFont = True
        Me.MainView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.MainView.Appearance.RowSeparator.Options.UseBackColor = True
        Me.MainView.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand6, Me.PrevBand, Me.CurrBand, Me.NewBand, Me.gSummary})
        Me.MainView.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.UnitCode, Me.CounterCode, Me.CounterReadingID, Me.UnitDesc, Me.PrevDate, Me.PrevReading, Me.CurrDate, Me.CurrReading, Me.NewDate, Me.NewReading, Me.HoursRun, Me.HoursPerDay, Me.Edited, Me.CatCode, Me.DeptCode, Me.CurrCounter, Me.PrevCounter, Me.AvgHoursPerDay})
        Me.MainView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.MainView.GridControl = Me.MainGrid
        Me.MainView.GroupFormat = ""
        Me.MainView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "VslCode", Nothing, "(Number Of Vessels: {0})"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalNC", Nothing, "(Total NC: {0:f0})"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Average, "AvgWorkHours", Nothing, "(Average Work Hours: {0:f})"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AvgNC", Nothing, "(Average NC: {0:f})")})
        Me.MainView.Name = "MainView"
        Me.MainView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.MainView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.MainView.OptionsBehavior.AutoPopulateColumns = False
        Me.MainView.OptionsBehavior.AutoSelectAllInEditor = False
        Me.MainView.OptionsCustomization.AllowBandMoving = False
        Me.MainView.OptionsCustomization.AllowBandResizing = False
        Me.MainView.OptionsCustomization.AllowFilter = False
        Me.MainView.OptionsCustomization.AllowGroup = False
        Me.MainView.OptionsCustomization.AllowQuickHideColumns = False
        Me.MainView.OptionsCustomization.ShowBandsInCustomizationForm = False
        Me.MainView.OptionsFind.AlwaysVisible = True
        Me.MainView.OptionsMenu.EnableColumnMenu = False
        Me.MainView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.MainView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.MainView.OptionsSelection.EnableAppearanceHideSelection = False
        Me.MainView.OptionsSelection.UseIndicatorForSelection = False
        Me.MainView.OptionsView.ShowGroupPanel = False
        '
        'gridBand6
        '
        Me.gridBand6.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.gridBand6.AppearanceHeader.Options.UseFont = True
        Me.gridBand6.Caption = "Machines & Equipments"
        Me.gridBand6.Columns.Add(Me.UnitDesc)
        Me.gridBand6.Name = "gridBand6"
        Me.gridBand6.VisibleIndex = 0
        Me.gridBand6.Width = 249
        '
        'UnitDesc
        '
        Me.UnitDesc.Caption = "Description"
        Me.UnitDesc.FieldName = "UnitDesc"
        Me.UnitDesc.Name = "UnitDesc"
        Me.UnitDesc.OptionsColumn.AllowEdit = False
        Me.UnitDesc.OptionsColumn.ReadOnly = True
        Me.UnitDesc.Visible = True
        Me.UnitDesc.Width = 249
        '
        'PrevBand
        '
        Me.PrevBand.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.PrevBand.AppearanceHeader.Options.UseFont = True
        Me.PrevBand.Caption = "Previous Readings"
        Me.PrevBand.Columns.Add(Me.PrevCounter)
        Me.PrevBand.Columns.Add(Me.PrevDate)
        Me.PrevBand.Columns.Add(Me.PrevReading)
        Me.PrevBand.Name = "PrevBand"
        Me.PrevBand.VisibleIndex = 1
        Me.PrevBand.Width = 210
        '
        'PrevCounter
        '
        Me.PrevCounter.Caption = "Counter"
        Me.PrevCounter.FieldName = "PrevCounter"
        Me.PrevCounter.MinWidth = 60
        Me.PrevCounter.Name = "PrevCounter"
        Me.PrevCounter.OptionsColumn.AllowEdit = False
        Me.PrevCounter.OptionsColumn.ReadOnly = True
        Me.PrevCounter.Visible = True
        Me.PrevCounter.Width = 60
        '
        'PrevDate
        '
        Me.PrevDate.Caption = "Date"
        Me.PrevDate.DisplayFormat.FormatString = "d"
        Me.PrevDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.PrevDate.FieldName = "PrevDate"
        Me.PrevDate.MinWidth = 80
        Me.PrevDate.Name = "PrevDate"
        Me.PrevDate.OptionsColumn.AllowEdit = False
        Me.PrevDate.OptionsColumn.ReadOnly = True
        Me.PrevDate.UnboundType = DevExpress.Data.UnboundColumnType.DateTime
        Me.PrevDate.Visible = True
        Me.PrevDate.Width = 80
        '
        'PrevReading
        '
        Me.PrevReading.Caption = "Reading"
        Me.PrevReading.DisplayFormat.FormatString = "f0"
        Me.PrevReading.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.PrevReading.FieldName = "PrevReading"
        Me.PrevReading.MinWidth = 70
        Me.PrevReading.Name = "PrevReading"
        Me.PrevReading.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        Me.PrevReading.Visible = True
        Me.PrevReading.Width = 70
        '
        'CurrBand
        '
        Me.CurrBand.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CurrBand.AppearanceHeader.Options.UseFont = True
        Me.CurrBand.Caption = "Current Readings"
        Me.CurrBand.Columns.Add(Me.CurrCounter)
        Me.CurrBand.Columns.Add(Me.CurrDate)
        Me.CurrBand.Columns.Add(Me.CurrReading)
        Me.CurrBand.Name = "CurrBand"
        Me.CurrBand.VisibleIndex = 2
        Me.CurrBand.Width = 210
        '
        'CurrCounter
        '
        Me.CurrCounter.Caption = "Counter"
        Me.CurrCounter.FieldName = "CurrCounter"
        Me.CurrCounter.MinWidth = 60
        Me.CurrCounter.Name = "CurrCounter"
        Me.CurrCounter.OptionsColumn.AllowEdit = False
        Me.CurrCounter.OptionsColumn.ReadOnly = True
        Me.CurrCounter.Visible = True
        Me.CurrCounter.Width = 60
        '
        'CurrDate
        '
        Me.CurrDate.Caption = "Date"
        Me.CurrDate.DisplayFormat.FormatString = "d"
        Me.CurrDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.CurrDate.FieldName = "CurrDate"
        Me.CurrDate.MinWidth = 80
        Me.CurrDate.Name = "CurrDate"
        Me.CurrDate.UnboundType = DevExpress.Data.UnboundColumnType.DateTime
        Me.CurrDate.Visible = True
        Me.CurrDate.Width = 80
        '
        'CurrReading
        '
        Me.CurrReading.Caption = "Reading"
        Me.CurrReading.DisplayFormat.FormatString = "f0"
        Me.CurrReading.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.CurrReading.FieldName = "CurrReading"
        Me.CurrReading.MinWidth = 70
        Me.CurrReading.Name = "CurrReading"
        Me.CurrReading.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        Me.CurrReading.Visible = True
        Me.CurrReading.Width = 70
        '
        'NewBand
        '
        Me.NewBand.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.NewBand.AppearanceHeader.Options.UseFont = True
        Me.NewBand.Caption = "New Reading"
        Me.NewBand.Columns.Add(Me.NewDate)
        Me.NewBand.Columns.Add(Me.NewReading)
        Me.NewBand.Name = "NewBand"
        Me.NewBand.VisibleIndex = 3
        Me.NewBand.Width = 167
        '
        'NewDate
        '
        Me.NewDate.Caption = "Date"
        Me.NewDate.DisplayFormat.FormatString = "d"
        Me.NewDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.NewDate.FieldName = "NewDate"
        Me.NewDate.MinWidth = 80
        Me.NewDate.Name = "NewDate"
        Me.NewDate.UnboundType = DevExpress.Data.UnboundColumnType.DateTime
        Me.NewDate.Visible = True
        Me.NewDate.Width = 97
        '
        'NewReading
        '
        Me.NewReading.Caption = "Reading"
        Me.NewReading.DisplayFormat.FormatString = "f0"
        Me.NewReading.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.NewReading.FieldName = "NewReading"
        Me.NewReading.MinWidth = 70
        Me.NewReading.Name = "NewReading"
        Me.NewReading.UnboundType = DevExpress.Data.UnboundColumnType.DateTime
        Me.NewReading.Visible = True
        Me.NewReading.Width = 70
        '
        'gSummary
        '
        Me.gSummary.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.gSummary.AppearanceHeader.Options.UseFont = True
        Me.gSummary.Caption = "Summary"
        Me.gSummary.Columns.Add(Me.HoursRun)
        Me.gSummary.Columns.Add(Me.HoursPerDay)
        Me.gSummary.Columns.Add(Me.AvgHoursPerDay)
        Me.gSummary.Name = "gSummary"
        Me.gSummary.VisibleIndex = 4
        Me.gSummary.Width = 343
        '
        'HoursRun
        '
        Me.HoursRun.Caption = "Hours since prev. reading"
        Me.HoursRun.FieldName = "HoursRun"
        Me.HoursRun.Name = "HoursRun"
        Me.HoursRun.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        Me.HoursRun.Visible = True
        Me.HoursRun.Width = 141
        '
        'HoursPerDay
        '
        Me.HoursPerDay.Caption = "Hours per Day"
        Me.HoursPerDay.DisplayFormat.FormatString = "f2"
        Me.HoursPerDay.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.HoursPerDay.FieldName = "HoursPerDay"
        Me.HoursPerDay.Name = "HoursPerDay"
        Me.HoursPerDay.OptionsColumn.AllowEdit = False
        Me.HoursPerDay.OptionsColumn.ReadOnly = True
        Me.HoursPerDay.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.HoursPerDay.Visible = True
        Me.HoursPerDay.Width = 87
        '
        'AvgHoursPerDay
        '
        Me.AvgHoursPerDay.Caption = "Avg Hours Per Day"
        Me.AvgHoursPerDay.FieldName = "AvgHoursPerDay"
        Me.AvgHoursPerDay.Name = "AvgHoursPerDay"
        Me.AvgHoursPerDay.OptionsColumn.AllowEdit = False
        Me.AvgHoursPerDay.OptionsColumn.ReadOnly = True
        Me.AvgHoursPerDay.Visible = True
        Me.AvgHoursPerDay.Width = 115
        '
        'UnitCode
        '
        Me.UnitCode.Caption = "UnitCode"
        Me.UnitCode.FieldName = "UnitCode"
        Me.UnitCode.Name = "UnitCode"
        '
        'CounterCode
        '
        Me.CounterCode.Caption = "CounterCode"
        Me.CounterCode.FieldName = "CounterCode"
        Me.CounterCode.Name = "CounterCode"
        Me.CounterCode.Visible = True
        '
        'CounterReadingID
        '
        Me.CounterReadingID.Caption = "CounterReadingID"
        Me.CounterReadingID.FieldName = "CounterReadingID"
        Me.CounterReadingID.Name = "CounterReadingID"
        Me.CounterReadingID.Visible = True
        '
        'Edited
        '
        Me.Edited.Caption = "Edited"
        Me.Edited.FieldName = "Edited"
        Me.Edited.Name = "Edited"
        Me.Edited.Visible = True
        '
        'CatCode
        '
        Me.CatCode.Caption = "CatCode"
        Me.CatCode.FieldName = "CatCode"
        Me.CatCode.Name = "CatCode"
        '
        'DeptCode
        '
        Me.DeptCode.Caption = "DeptCode"
        Me.DeptCode.FieldName = "DeptCode"
        Me.DeptCode.Name = "DeptCode"
        '
        'header
        '
        Me.header.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.header.AppearanceCaption.Options.UseFont = True
        Me.header.Controls.Add(Me.MainGrid)
        Me.header.Dock = System.Windows.Forms.DockStyle.Fill
        Me.header.Location = New System.Drawing.Point(0, 0)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(1198, 354)
        Me.header.TabIndex = 37
        '
        'RUNNINGHOURS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.header)
        Me.LookAndFeel.SkinName = "iMaginary"
        Me.Name = "RUNNINGHOURS"
        Me.Size = New System.Drawing.Size(1198, 354)
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents MainView As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents PrevDate As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents CurrDate As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents NewDate As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents CurrReading As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents NewReading As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents UnitDesc As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents CounterCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents HoursRun As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents PrevReading As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents CounterReadingID As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents HoursPerDay As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents Edited As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents UnitCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents CatCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents DeptCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents CurrCounter As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents PrevCounter As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents AvgHoursPerDay As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand6 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents PrevBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents CurrBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents NewBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gSummary As DevExpress.XtraGrid.Views.BandedGrid.GridBand

End Class
