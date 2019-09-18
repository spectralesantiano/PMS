<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class STORAGE
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
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.txtName = New DevExpress.XtraEditors.TextEdit()
        Me.cboLocCode = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblLocation = New DevExpress.XtraEditors.LabelControl()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboLocCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl12
        '
        Me.LabelControl12.Location = New System.Drawing.Point(36, 45)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(47, 13)
        Me.LabelControl12.TabIndex = 31
        Me.LabelControl12.Text = "* Storage"
        '
        'header
        '
        Me.header.Controls.Add(Me.cboLocCode)
        Me.header.Controls.Add(Me.lblLocation)
        Me.header.Controls.Add(Me.txtName)
        Me.header.Controls.Add(Me.LabelControl12)
        Me.header.Dock = System.Windows.Forms.DockStyle.Fill
        Me.header.Location = New System.Drawing.Point(0, 0)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(531, 244)
        Me.header.TabIndex = 36
        Me.header.Text = "Edit Department Details"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(36, 64)
        Me.txtName.Name = "txtName"
        Me.txtName.Properties.MaxLength = 50
        Me.txtName.Size = New System.Drawing.Size(231, 20)
        Me.txtName.TabIndex = 0
        '
        'cboLocCode
        '
        Me.cboLocCode.Location = New System.Drawing.Point(266, 64)
        Me.cboLocCode.Name = "cboLocCode"
        Me.cboLocCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboLocCode.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocCode", "LocCode", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocName", "LocName")})
        Me.cboLocCode.Properties.DisplayMember = "LocName"
        Me.cboLocCode.Properties.DropDownRows = 10
        Me.cboLocCode.Properties.MaxLength = 30
        Me.cboLocCode.Properties.NullText = ""
        Me.cboLocCode.Properties.ShowFooter = False
        Me.cboLocCode.Properties.ShowHeader = False
        Me.cboLocCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboLocCode.Properties.ValueMember = "LocCode"
        Me.cboLocCode.Size = New System.Drawing.Size(187, 20)
        Me.cboLocCode.TabIndex = 210
        '
        'lblLocation
        '
        Me.lblLocation.Location = New System.Drawing.Point(267, 48)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(40, 13)
        Me.lblLocation.TabIndex = 211
        Me.lblLocation.Text = "Location"
        '
        'STORAGE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.header)
        Me.Name = "STORAGE"
        Me.Size = New System.Drawing.Size(531, 244)
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        Me.header.PerformLayout()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboLocCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents txtName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cboLocCode As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblLocation As DevExpress.XtraEditors.LabelControl

End Class
