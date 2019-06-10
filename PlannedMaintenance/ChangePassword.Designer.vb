<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChangePassword
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChangePassword))
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.txtConfirmPassword = New DevExpress.XtraEditors.TextEdit()
        Me.lbl = New DevExpress.XtraEditors.LabelControl()
        Me.txtNewPass = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtOldPassword = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.txtConfirmPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNewPass.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOldPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(160, 173)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.Text = "Cancel"
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(76, 173)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 3
        Me.cmdOk.Text = "Ok"
        '
        'txtConfirmPassword
        '
        Me.txtConfirmPassword.Location = New System.Drawing.Point(33, 129)
        Me.txtConfirmPassword.Name = "txtConfirmPassword"
        Me.txtConfirmPassword.Properties.UseSystemPasswordChar = True
        Me.txtConfirmPassword.Size = New System.Drawing.Size(203, 20)
        Me.txtConfirmPassword.TabIndex = 2
        '
        'lbl
        '
        Me.lbl.Location = New System.Drawing.Point(34, 113)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(86, 13)
        Me.lbl.TabIndex = 14
        Me.lbl.Text = "Confirm Password"
        '
        'txtNewPass
        '
        Me.txtNewPass.Location = New System.Drawing.Point(32, 83)
        Me.txtNewPass.Name = "txtNewPass"
        Me.txtNewPass.Properties.UseSystemPasswordChar = True
        Me.txtNewPass.Size = New System.Drawing.Size(203, 20)
        Me.txtNewPass.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(33, 67)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(70, 13)
        Me.LabelControl2.TabIndex = 13
        Me.LabelControl2.Text = "New Password"
        '
        'txtOldPassword
        '
        Me.txtOldPassword.Location = New System.Drawing.Point(32, 38)
        Me.txtOldPassword.Name = "txtOldPassword"
        Me.txtOldPassword.Properties.UseSystemPasswordChar = True
        Me.txtOldPassword.Size = New System.Drawing.Size(203, 20)
        Me.txtOldPassword.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(33, 22)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(86, 13)
        Me.LabelControl1.TabIndex = 10
        Me.LabelControl1.Text = "Current Password"
        '
        'ChangePassword
        '
        Me.AcceptButton = Me.cmdOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(269, 222)
        Me.Controls.Add(Me.txtConfirmPassword)
        Me.Controls.Add(Me.lbl)
        Me.Controls.Add(Me.txtNewPass)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.txtOldPassword)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ChangePassword"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Change Password"
        CType(Me.txtConfirmPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNewPass.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOldPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtConfirmPassword As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtNewPass As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtOldPassword As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
End Class
