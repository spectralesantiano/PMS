<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptEquipmentList
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.MyTable = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.Equipment = New DevExpress.XtraReports.UI.XRTableCell()
        Me.Critical = New DevExpress.XtraReports.UI.XRTableCell()
        Me.Field1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.Field2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.MainField = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow3 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.lMachine = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.HField1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.HField2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.Title = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Flag = New DevExpress.XtraReports.UI.XRLabel()
        Me.IMO = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine3 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLine2 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Vessel = New DevExpress.XtraReports.UI.XRLabel()
        Me.GroupHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.imgLogo = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDate = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me.MyTable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.MyTable})
        Me.Detail.HeightF = 25.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'MyTable
        '
        Me.MyTable.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.MyTable.LocationFloat = New DevExpress.Utils.PointFloat(0.00009698383!, 0.0!)
        Me.MyTable.Name = "MyTable"
        Me.MyTable.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100.0!)
        Me.MyTable.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.MyTable.SizeF = New System.Drawing.SizeF(726.9999!, 25.0!)
        Me.MyTable.StylePriority.UseBorders = False
        Me.MyTable.StylePriority.UsePadding = False
        '
        'XrTableRow1
        '
        Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.Equipment, Me.Critical, Me.Field1, Me.Field2})
        Me.XrTableRow1.Name = "XrTableRow1"
        Me.XrTableRow1.Weight = 1.0R
        '
        'Equipment
        '
        Me.Equipment.Name = "Equipment"
        Me.Equipment.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100.0!)
        Me.Equipment.StylePriority.UsePadding = False
        Me.Equipment.Weight = 1.0698727640868646R
        '
        'Critical
        '
        Me.Critical.Name = "Critical"
        Me.Critical.Weight = 0.24535141237312766R
        '
        'Field1
        '
        Me.Field1.Name = "Field1"
        Me.Field1.Text = "Field1"
        Me.Field1.Weight = 0.81419540045992511R
        '
        'Field2
        '
        Me.Field2.Name = "Field2"
        Me.Field2.Text = "Field2"
        Me.Field2.Weight = 0.87471290291841719R
        '
        'XrTable1
        '
        Me.XrTable1.AnchorVertical = DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom
        Me.XrTable1.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTable1.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0.00004768372!, 158.7628!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100.0!)
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow2, Me.XrTableRow3})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(727.0!, 50.0!)
        Me.XrTable1.StylePriority.UseBorders = False
        Me.XrTable1.StylePriority.UseFont = False
        Me.XrTable1.StylePriority.UsePadding = False
        '
        'XrTableRow2
        '
        Me.XrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.MainField})
        Me.XrTableRow2.Name = "XrTableRow2"
        Me.XrTableRow2.Weight = 1.0R
        '
        'MainField
        '
        Me.MainField.BackColor = System.Drawing.Color.Transparent
        Me.MainField.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
        Me.MainField.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.MainField.CanGrow = False
        Me.MainField.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.MainField.Name = "MainField"
        Me.MainField.StylePriority.UseBackColor = False
        Me.MainField.StylePriority.UseBorderDashStyle = False
        Me.MainField.StylePriority.UseBorders = False
        Me.MainField.StylePriority.UseFont = False
        Me.MainField.StylePriority.UseTextAlignment = False
        Me.MainField.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.MainField.Weight = 0.37389612780319259R
        '
        'XrTableRow3
        '
        Me.XrTableRow3.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.lMachine, Me.XrTableCell1, Me.HField1, Me.HField2})
        Me.XrTableRow3.Name = "XrTableRow3"
        Me.XrTableRow3.Weight = 1.0R
        '
        'lMachine
        '
        Me.lMachine.BackColor = System.Drawing.Color.Transparent
        Me.lMachine.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
        Me.lMachine.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lMachine.CanGrow = False
        Me.lMachine.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lMachine.Name = "lMachine"
        Me.lMachine.StylePriority.UseBackColor = False
        Me.lMachine.StylePriority.UseBorderDashStyle = False
        Me.lMachine.StylePriority.UseBorders = False
        Me.lMachine.StylePriority.UseFont = False
        Me.lMachine.Text = "Equipment"
        Me.lMachine.Weight = 0.13101373832693566R
        '
        'XrTableCell1
        '
        Me.XrTableCell1.BackColor = System.Drawing.Color.Transparent
        Me.XrTableCell1.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
        Me.XrTableCell1.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCell1.CanGrow = False
        Me.XrTableCell1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrTableCell1.Name = "XrTableCell1"
        Me.XrTableCell1.StylePriority.UseBackColor = False
        Me.XrTableCell1.StylePriority.UseBorderDashStyle = False
        Me.XrTableCell1.StylePriority.UseBorders = False
        Me.XrTableCell1.StylePriority.UseFont = False
        Me.XrTableCell1.Text = "Critical"
        Me.XrTableCell1.Weight = 0.030045066595414782R
        '
        'HField1
        '
        Me.HField1.BackColor = System.Drawing.Color.Transparent
        Me.HField1.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
        Me.HField1.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.HField1.CanGrow = False
        Me.HField1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HField1.Name = "HField1"
        Me.HField1.StylePriority.UseBackColor = False
        Me.HField1.StylePriority.UseBorderDashStyle = False
        Me.HField1.StylePriority.UseBorders = False
        Me.HField1.StylePriority.UseFont = False
        Me.HField1.Text = "HField1"
        Me.HField1.Weight = 0.09970416190311493R
        '
        'HField2
        '
        Me.HField2.BackColor = System.Drawing.Color.Transparent
        Me.HField2.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
        Me.HField2.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.HField2.CanGrow = False
        Me.HField2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HField2.Name = "HField2"
        Me.HField2.StylePriority.UseBackColor = False
        Me.HField2.StylePriority.UseBorderDashStyle = False
        Me.HField2.StylePriority.UseBorders = False
        Me.HField2.StylePriority.UseFont = False
        Me.HField2.Text = "HField2"
        Me.HField2.Weight = 0.10711495518147343R
        '
        'TopMargin
        '
        Me.TopMargin.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.TopMargin.HeightF = 50.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.StylePriority.UseFont = False
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 50.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'Title
        '
        Me.Title.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Title.LocationFloat = New DevExpress.Utils.PointFloat(186.4794!, 14.0!)
        Me.Title.Multiline = True
        Me.Title.Name = "Title"
        Me.Title.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.Title.SizeF = New System.Drawing.SizeF(323.1665!, 23.0!)
        Me.Title.StylePriority.UseFont = False
        Me.Title.StylePriority.UseTextAlignment = False
        Me.Title.Text = "Title"
        Me.Title.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrLabel4
        '
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(275.3335!, 97.00002!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(125.0!, 22.99998!)
        Me.XrLabel4.Text = "IMO Number (if any):"
        '
        'Flag
        '
        Me.Flag.LocationFloat = New DevExpress.Utils.PointFloat(564.744!, 96.99998!)
        Me.Flag.Name = "Flag"
        Me.Flag.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.Flag.SizeF = New System.Drawing.SizeF(162.256!, 23.0!)
        Me.Flag.StylePriority.UseTextAlignment = False
        Me.Flag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'IMO
        '
        Me.IMO.LocationFloat = New DevExpress.Utils.PointFloat(400.3335!, 97.00002!)
        Me.IMO.Name = "IMO"
        Me.IMO.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.IMO.SizeF = New System.Drawing.SizeF(71.31238!, 23.00003!)
        Me.IMO.StylePriority.UseTextAlignment = False
        Me.IMO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLine3
        '
        Me.XrLine3.LocationFloat = New DevExpress.Utils.PointFloat(400.3335!, 122.0!)
        Me.XrLine3.Name = "XrLine3"
        Me.XrLine3.SizeF = New System.Drawing.SizeF(71.31238!, 2.7174!)
        '
        'XrLine2
        '
        Me.XrLine2.LocationFloat = New DevExpress.Utils.PointFloat(564.744!, 122.0!)
        Me.XrLine2.Name = "XrLine2"
        Me.XrLine2.SizeF = New System.Drawing.SizeF(162.256!, 2.7174!)
        '
        'XrLine1
        '
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(88.00007!, 122.0!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(170.9092!, 2.717384!)
        '
        'XrLabel1
        '
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0.00004849191!, 96.99998!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(85.0!, 23.0!)
        Me.XrLabel1.Text = "Name of Ship:"
        '
        'XrLabel3
        '
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(488.744!, 96.99998!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(75.00003!, 22.99999!)
        Me.XrLabel3.Text = "Flag of Ship:"
        '
        'Vessel
        '
        Me.Vessel.LocationFloat = New DevExpress.Utils.PointFloat(88.00007!, 97.00002!)
        Me.Vessel.Name = "Vessel"
        Me.Vessel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.Vessel.SizeF = New System.Drawing.SizeF(170.9092!, 23.0!)
        Me.Vessel.StylePriority.UseTextAlignment = False
        Me.Vessel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'GroupHeader
        '
        Me.GroupHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.imgLogo, Me.XrTable1, Me.XrLabel1, Me.XrLabel3, Me.Vessel, Me.XrLine1, Me.XrLine2, Me.XrLine3, Me.IMO, Me.Flag, Me.XrLabel4, Me.Title})
        Me.GroupHeader.HeightF = 208.7628!
        Me.GroupHeader.Name = "GroupHeader"
        Me.GroupHeader.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand
        '
        'imgLogo
        '
        Me.imgLogo.LocationFloat = New DevExpress.Utils.PointFloat(627.0!, 0.0!)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.SizeF = New System.Drawing.SizeF(100.0!, 90.0!)
        Me.imgLogo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel9, Me.lblDate})
        Me.PageFooter.HeightF = 15.99999!
        Me.PageFooter.Name = "PageFooter"
        '
        'XrLabel9
        '
        Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(556.9583!, 0.0!)
        Me.XrLabel9.Name = "XrLabel9"
        Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel9.SizeF = New System.Drawing.SizeF(86.92407!, 15.99998!)
        Me.XrLabel9.StylePriority.UseTextAlignment = False
        Me.XrLabel9.Text = "Date printed:"
        Me.XrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'lblDate
        '
        Me.lblDate.LocationFloat = New DevExpress.Utils.PointFloat(644.4583!, 0.0!)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDate.SizeF = New System.Drawing.SizeF(82.54169!, 15.99999!)
        Me.lblDate.StylePriority.UseTextAlignment = False
        Me.lblDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'rptEquipmentList
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.GroupHeader, Me.PageFooter})
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Margins = New System.Drawing.Printing.Margins(50, 50, 50, 50)
        Me.PageHeight = 1169
        Me.PageWidth = 827
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.ShowPreviewMarginLines = False
        Me.Version = "15.2"
        CType(Me.MyTable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents Flag As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents IMO As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine3 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLine2 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents Vessel As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents Title As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents MainField As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents MyTable As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents Equipment As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents GroupHeader As DevExpress.XtraReports.UI.GroupHeaderBand
    Friend WithEvents Critical As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents imgLogo As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents XrTableRow3 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents lMachine As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents HField1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents Field1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents Field2 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents HField2 As DevExpress.XtraReports.UI.XRTableCell
End Class
