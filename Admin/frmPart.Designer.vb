<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPart
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPart))
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.cboPartCode = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtPartNumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.cboPartCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPartNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(97, 94)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(72, 23)
        Me.cmdOk.TabIndex = 5
        Me.cmdOk.Text = "Done"
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(173, 94)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(74, 23)
        Me.cmdCancel.TabIndex = 10
        Me.cmdCancel.Text = "Cancel"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(12, 27)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(33, 13)
        Me.LabelControl3.TabIndex = 200
        Me.LabelControl3.Text = "* Part:"
        '
        'cboPartCode
        '
        Me.cboPartCode.Location = New System.Drawing.Point(97, 24)
        Me.cboPartCode.Name = "cboPartCode"
        Me.cboPartCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboPartCode.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PartCode", "PartCode", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Part", "Part")})
        Me.cboPartCode.Properties.DisplayMember = "Part"
        Me.cboPartCode.Properties.DropDownRows = 10
        Me.cboPartCode.Properties.NullText = ""
        Me.cboPartCode.Properties.ShowFooter = False
        Me.cboPartCode.Properties.ShowHeader = False
        Me.cboPartCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboPartCode.Properties.ValueMember = "PartCode"
        Me.cboPartCode.Size = New System.Drawing.Size(150, 20)
        Me.cboPartCode.TabIndex = 0
        '
        'txtPartNumber
        '
        Me.txtPartNumber.Location = New System.Drawing.Point(97, 58)
        Me.txtPartNumber.Name = "txtPartNumber"
        Me.txtPartNumber.Properties.MaxLength = 30
        Me.txtPartNumber.Size = New System.Drawing.Size(150, 20)
        Me.txtPartNumber.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 61)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(73, 13)
        Me.LabelControl1.TabIndex = 212
        Me.LabelControl1.Text = "* Part Number:"
        '
        'frmPart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(266, 140)
        Me.Controls.Add(Me.txtPartNumber)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.cboPartCode)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPart"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Part"
        Me.TopMost = True
        CType(Me.cboPartCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPartNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboPartCode As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtPartNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
End Class
