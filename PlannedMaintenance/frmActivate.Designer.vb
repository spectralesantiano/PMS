<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmActivate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmActivate))
        Me.cmdSave = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.captionLabel = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControl4 = New DevExpress.XtraEditors.GroupControl()
        Me.lblServerName = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.cmdBrowse = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdOpentroubleshooter = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdServerConfig = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.GroupControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl4.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(524, 319)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(78, 23)
        Me.cmdSave.TabIndex = 10
        Me.cmdSave.Text = "Save ID"
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(609, 319)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(78, 23)
        Me.cmdOk.TabIndex = 6
        Me.cmdOk.Text = "Open PMS"
        '
        'GroupControl1
        '
        Me.GroupControl1.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupControl1.AppearanceCaption.Options.UseFont = True
        Me.GroupControl1.Controls.Add(Me.captionLabel)
        Me.GroupControl1.Location = New System.Drawing.Point(13, 15)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(664, 66)
        Me.GroupControl1.TabIndex = 14
        Me.GroupControl1.Text = "License Information"
        '
        'captionLabel
        '
        Me.captionLabel.Location = New System.Drawing.Point(18, 34)
        Me.captionLabel.Name = "captionLabel"
        Me.captionLabel.Size = New System.Drawing.Size(59, 13)
        Me.captionLabel.TabIndex = 15
        Me.captionLabel.Text = "Lock System"
        '
        'GroupControl2
        '
        Me.GroupControl2.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupControl2.AppearanceCaption.Options.UseFont = True
        Me.GroupControl2.Controls.Add(Me.LabelControl1)
        Me.GroupControl2.Location = New System.Drawing.Point(13, 90)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(664, 66)
        Me.GroupControl2.TabIndex = 16
        Me.GroupControl2.Text = "License Application"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(18, 34)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(615, 13)
        Me.LabelControl1.TabIndex = 15
        Me.LabelControl1.Text = "To apply for a new license, please click the Save ID button to save the computer " & _
    "ID file and email it to spectral@spectralasia.net"
        '
        'GroupControl3
        '
        Me.GroupControl3.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupControl3.AppearanceCaption.Options.UseFont = True
        Me.GroupControl3.Controls.Add(Me.LabelControl2)
        Me.GroupControl3.Location = New System.Drawing.Point(13, 165)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(664, 66)
        Me.GroupControl3.TabIndex = 17
        Me.GroupControl3.Text = "License Activation"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(18, 34)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(581, 13)
        Me.LabelControl2.TabIndex = 15
        Me.LabelControl2.Text = "If you already received the license file from Spectral Tech. Inc., browse the lic" & _
    "ense file by clicking Browse License button."
        '
        'GroupControl4
        '
        Me.GroupControl4.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupControl4.AppearanceCaption.Options.UseFont = True
        Me.GroupControl4.Controls.Add(Me.lblServerName)
        Me.GroupControl4.Controls.Add(Me.LabelControl3)
        Me.GroupControl4.Location = New System.Drawing.Point(13, 240)
        Me.GroupControl4.Name = "GroupControl4"
        Me.GroupControl4.Size = New System.Drawing.Size(664, 66)
        Me.GroupControl4.TabIndex = 18
        Me.GroupControl4.Text = "Server Information"
        '
        'lblServerName
        '
        Me.lblServerName.Location = New System.Drawing.Point(90, 34)
        Me.lblServerName.Name = "lblServerName"
        Me.lblServerName.Size = New System.Drawing.Size(62, 13)
        Me.lblServerName.TabIndex = 16
        Me.lblServerName.Text = "Server Name"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(18, 34)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(66, 13)
        Me.LabelControl3.TabIndex = 15
        Me.LabelControl3.Text = "Server Name:"
        '
        'cmdBrowse
        '
        Me.cmdBrowse.Location = New System.Drawing.Point(428, 319)
        Me.cmdBrowse.Name = "cmdBrowse"
        Me.cmdBrowse.Size = New System.Drawing.Size(89, 23)
        Me.cmdBrowse.TabIndex = 9
        Me.cmdBrowse.Text = "Browse License"
        '
        'cmdOpentroubleshooter
        '
        Me.cmdOpentroubleshooter.Location = New System.Drawing.Point(290, 319)
        Me.cmdOpentroubleshooter.Name = "cmdOpentroubleshooter"
        Me.cmdOpentroubleshooter.Size = New System.Drawing.Size(130, 23)
        Me.cmdOpentroubleshooter.TabIndex = 8
        Me.cmdOpentroubleshooter.Text = "License Troubleshooter"
        '
        'cmdServerConfig
        '
        Me.cmdServerConfig.Location = New System.Drawing.Point(141, 319)
        Me.cmdServerConfig.Name = "cmdServerConfig"
        Me.cmdServerConfig.Size = New System.Drawing.Size(141, 23)
        Me.cmdServerConfig.TabIndex = 7
        Me.cmdServerConfig.Text = "Open Server Configuration"
        '
        'frmActivate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(699, 354)
        Me.Controls.Add(Me.cmdServerConfig)
        Me.Controls.Add(Me.cmdOpentroubleshooter)
        Me.Controls.Add(Me.cmdBrowse)
        Me.Controls.Add(Me.GroupControl4)
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmActivate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "License Status Information"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        Me.GroupControl3.PerformLayout()
        CType(Me.GroupControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl4.ResumeLayout(False)
        Me.GroupControl4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents captionLabel As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl4 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblServerName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdBrowse As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOpentroubleshooter As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdServerConfig As DevExpress.XtraEditors.SimpleButton
End Class
