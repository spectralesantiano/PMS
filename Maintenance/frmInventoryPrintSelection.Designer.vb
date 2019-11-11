<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInventoryPrintSelection
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInventoryPrintSelection))
        Me.cmdOK = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.chkSpare = New DevExpress.XtraEditors.CheckEdit()
        Me.chkDeliveryCon = New DevExpress.XtraEditors.CheckEdit()
        Me.chkAddressToVendor = New DevExpress.XtraEditors.CheckEdit()
        Me.chkOffice = New DevExpress.XtraEditors.CheckEdit()
        Me.cboVendorCode = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtOfficeAddress = New DevExpress.XtraEditors.TextEdit()
        CType(Me.chkSpare.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDeliveryCon.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkAddressToVendor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkOffice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboVendorCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOfficeAddress.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(157, 167)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(78, 23)
        Me.cmdOK.TabIndex = 2
        Me.cmdOK.Text = "Ok"
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(250, 167)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(78, 23)
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.Text = "Cancel"
        '
        'chkSpare
        '
        Me.chkSpare.EditValue = True
        Me.chkSpare.Location = New System.Drawing.Point(22, 21)
        Me.chkSpare.Name = "chkSpare"
        Me.chkSpare.Properties.Caption = "Spare Part Requisition Report"
        Me.chkSpare.Size = New System.Drawing.Size(184, 19)
        Me.chkSpare.TabIndex = 12
        '
        'chkDeliveryCon
        '
        Me.chkDeliveryCon.Location = New System.Drawing.Point(22, 129)
        Me.chkDeliveryCon.Name = "chkDeliveryCon"
        Me.chkDeliveryCon.Properties.Caption = "Delivery Confirmation Report"
        Me.chkDeliveryCon.Size = New System.Drawing.Size(184, 19)
        Me.chkDeliveryCon.TabIndex = 13
        '
        'chkAddressToVendor
        '
        Me.chkAddressToVendor.Location = New System.Drawing.Point(52, 54)
        Me.chkAddressToVendor.Name = "chkAddressToVendor"
        Me.chkAddressToVendor.Properties.Caption = "Sent To Vendor:"
        Me.chkAddressToVendor.Size = New System.Drawing.Size(107, 19)
        Me.chkAddressToVendor.TabIndex = 14
        '
        'chkOffice
        '
        Me.chkOffice.Location = New System.Drawing.Point(52, 88)
        Me.chkOffice.Name = "chkOffice"
        Me.chkOffice.Properties.Caption = "Sent To Office:"
        Me.chkOffice.Size = New System.Drawing.Size(107, 19)
        Me.chkOffice.TabIndex = 15
        '
        'cboVendorCode
        '
        Me.cboVendorCode.Location = New System.Drawing.Point(157, 54)
        Me.cboVendorCode.Name = "cboVendorCode"
        Me.cboVendorCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboVendorCode.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("VendorCode", "Name5", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Vendor", "Name6"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Address", "Name5")})
        Me.cboVendorCode.Properties.DisplayMember = "Vendor"
        Me.cboVendorCode.Properties.DropDownRows = 10
        Me.cboVendorCode.Properties.NullText = ""
        Me.cboVendorCode.Properties.NullValuePrompt = "Select Vendor"
        Me.cboVendorCode.Properties.ShowFooter = False
        Me.cboVendorCode.Properties.ShowHeader = False
        Me.cboVendorCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboVendorCode.Properties.ValueMember = "VendorCode"
        Me.cboVendorCode.Size = New System.Drawing.Size(171, 20)
        Me.cboVendorCode.TabIndex = 16
        '
        'txtOfficeAddress
        '
        Me.txtOfficeAddress.Location = New System.Drawing.Point(157, 88)
        Me.txtOfficeAddress.Name = "txtOfficeAddress"
        Me.txtOfficeAddress.Properties.MaxLength = 30
        Me.txtOfficeAddress.Size = New System.Drawing.Size(171, 20)
        Me.txtOfficeAddress.TabIndex = 17
        '
        'frmInventoryPrintSelection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(350, 214)
        Me.Controls.Add(Me.txtOfficeAddress)
        Me.Controls.Add(Me.cboVendorCode)
        Me.Controls.Add(Me.chkOffice)
        Me.Controls.Add(Me.chkAddressToVendor)
        Me.Controls.Add(Me.chkDeliveryCon)
        Me.Controls.Add(Me.chkSpare)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmdCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInventoryPrintSelection"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Print Selection"
        CType(Me.chkSpare.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDeliveryCon.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkAddressToVendor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkOffice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboVendorCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOfficeAddress.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkSpare As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkDeliveryCon As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkAddressToVendor As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkOffice As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cboVendorCode As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtOfficeAddress As DevExpress.XtraEditors.TextEdit
End Class
