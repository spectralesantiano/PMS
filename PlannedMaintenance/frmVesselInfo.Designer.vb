<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVesselInfo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVesselInfo))
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtEmail = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.Flag = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.Type = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.txtImo = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtVessel = New DevExpress.XtraEditors.TextEdit()
        CType(Me.txtEmail.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Flag.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Type.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtImo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVessel.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(111, 221)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(96, 23)
        Me.cmdOk.TabIndex = 5
        Me.cmdOk.Text = "Save"
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(229, 221)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(96, 23)
        Me.cmdCancel.TabIndex = 6
        Me.cmdCancel.Text = "Cancel"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(28, 179)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(28, 13)
        Me.LabelControl1.TabIndex = 49
        Me.LabelControl1.Text = "Email:"
        '
        'txtEmail
        '
        Me.txtEmail.EditValue = ""
        Me.txtEmail.Location = New System.Drawing.Point(111, 176)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(214, 20)
        Me.txtEmail.TabIndex = 4
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(28, 138)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl4.TabIndex = 48
        Me.LabelControl4.Text = "Flag:"
        '
        'Flag
        '
        Me.Flag.Location = New System.Drawing.Point(112, 135)
        Me.Flag.Name = "Flag"
        Me.Flag.Properties.AutoSearchColumnIndex = 1
        Me.Flag.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Flag.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CntryCode", "", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Country", "Name")})
        Me.Flag.Properties.DisplayMember = "Country"
        Me.Flag.Properties.DropDownRows = 10
        Me.Flag.Properties.NullText = ""
        Me.Flag.Properties.ShowFooter = False
        Me.Flag.Properties.ShowHeader = False
        Me.Flag.Properties.ValueMember = "CntryCode"
        Me.Flag.Size = New System.Drawing.Size(213, 20)
        Me.Flag.TabIndex = 3
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(28, 95)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(28, 13)
        Me.LabelControl5.TabIndex = 47
        Me.LabelControl5.Text = "Type:"
        '
        'Type
        '
        Me.Type.Location = New System.Drawing.Point(111, 92)
        Me.Type.Name = "Type"
        Me.Type.Properties.AutoSearchColumnIndex = 1
        Me.Type.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Type.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("VslTypeCode", "", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")})
        Me.Type.Properties.DisplayMember = "Name"
        Me.Type.Properties.NullText = ""
        Me.Type.Properties.ShowFooter = False
        Me.Type.Properties.ShowHeader = False
        Me.Type.Properties.ValueMember = "VslTypeCode"
        Me.Type.Size = New System.Drawing.Size(214, 20)
        Me.Type.TabIndex = 2
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(29, 21)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(64, 13)
        Me.LabelControl3.TabIndex = 46
        Me.LabelControl3.Text = "IMO Number:"
        '
        'txtImo
        '
        Me.txtImo.EditValue = ""
        Me.txtImo.Location = New System.Drawing.Point(112, 18)
        Me.txtImo.Name = "txtImo"
        Me.txtImo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtImo.Properties.Mask.EditMask = "f0"
        Me.txtImo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtImo.Properties.MaxLength = 7
        Me.txtImo.Size = New System.Drawing.Size(214, 20)
        Me.txtImo.TabIndex = 0
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(28, 58)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(64, 13)
        Me.LabelControl2.TabIndex = 45
        Me.LabelControl2.Text = "Vessel Name:"
        '
        'txtVessel
        '
        Me.txtVessel.Location = New System.Drawing.Point(111, 55)
        Me.txtVessel.Name = "txtVessel"
        Me.txtVessel.Size = New System.Drawing.Size(214, 20)
        Me.txtVessel.TabIndex = 1
        '
        'frmVesselInfo
        '
        Me.AcceptButton = Me.cmdOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(354, 265)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.Flag)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.Type)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.txtImo)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.txtVessel)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmVesselInfo"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Vessel Information"
        Me.TopMost = True
        CType(Me.txtEmail.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Flag.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Type.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtImo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVessel.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtEmail As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Flag As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Type As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtImo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtVessel As DevExpress.XtraEditors.TextEdit
End Class
