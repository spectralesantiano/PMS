<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConnect
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConnect))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtServer = New DevExpress.XtraEditors.TextEdit()
        Me.cmdConnect = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdClose = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.cboAuthType = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtLogin = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.txtPassword = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.txtServer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboAuthType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLogin.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(25, 29)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(66, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Server Name:"
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(108, 26)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(224, 20)
        Me.txtServer.TabIndex = 1
        '
        'cmdConnect
        '
        Me.cmdConnect.Location = New System.Drawing.Point(165, 174)
        Me.cmdConnect.Name = "cmdConnect"
        Me.cmdConnect.Size = New System.Drawing.Size(78, 23)
        Me.cmdConnect.TabIndex = 7
        Me.cmdConnect.Text = "Connect"
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(254, 174)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(78, 23)
        Me.cmdClose.TabIndex = 6
        Me.cmdClose.Text = "Cancel"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(25, 65)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(74, 13)
        Me.LabelControl2.TabIndex = 8
        Me.LabelControl2.Text = "Authentication:"
        '
        'cboAuthType
        '
        Me.cboAuthType.Location = New System.Drawing.Point(108, 62)
        Me.cboAuthType.Name = "cboAuthType"
        Me.cboAuthType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboAuthType.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("AuthType", "Name1", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("AuthDesc", "Name2")})
        Me.cboAuthType.Properties.DisplayMember = "AuthDesc"
        Me.cboAuthType.Properties.DropDownRows = 3
        Me.cboAuthType.Properties.NullText = ""
        Me.cboAuthType.Properties.ShowFooter = False
        Me.cboAuthType.Properties.ShowHeader = False
        Me.cboAuthType.Properties.ValueMember = "AuthType"
        Me.cboAuthType.Size = New System.Drawing.Size(224, 20)
        Me.cboAuthType.TabIndex = 9
        '
        'txtLogin
        '
        Me.txtLogin.Location = New System.Drawing.Point(125, 101)
        Me.txtLogin.Name = "txtLogin"
        Me.txtLogin.Size = New System.Drawing.Size(207, 20)
        Me.txtLogin.TabIndex = 11
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(49, 104)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(29, 13)
        Me.LabelControl3.TabIndex = 10
        Me.LabelControl3.Text = "Login:"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(125, 135)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Properties.UseSystemPasswordChar = True
        Me.txtPassword.Size = New System.Drawing.Size(207, 20)
        Me.txtPassword.TabIndex = 13
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(49, 138)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(50, 13)
        Me.LabelControl4.TabIndex = 12
        Me.LabelControl4.Text = "Password:"
        '
        'frmConnect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(361, 216)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.txtLogin)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.cmdConnect)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.txtServer)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.cboAuthType)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConnect"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configure Server Connection"
        CType(Me.txtServer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboAuthType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLogin.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtServer As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cmdConnect As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboAuthType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtLogin As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPassword As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
End Class
