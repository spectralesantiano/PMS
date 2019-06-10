<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProgress
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
        Me.CurrentProgress = New DevExpress.XtraEditors.ProgressBarControl
        Me.OverallProgress = New DevExpress.XtraEditors.ProgressBarControl
        Me.lblProgress = New DevExpress.XtraEditors.LabelControl
        Me.lblOverallText = New DevExpress.XtraEditors.LabelControl
        Me.lblOverallPercent = New DevExpress.XtraEditors.LabelControl
        Me.lblCurrentPercent = New DevExpress.XtraEditors.LabelControl
        Me.cmdHide = New DevExpress.XtraEditors.SimpleButton
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton
        Me.lblStatus = New DevExpress.XtraEditors.LabelControl
        CType(Me.CurrentProgress.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OverallProgress.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CurrentProgress
        '
        Me.CurrentProgress.Location = New System.Drawing.Point(58, 45)
        Me.CurrentProgress.Name = "CurrentProgress"
        Me.CurrentProgress.Properties.Step = 1
        Me.CurrentProgress.Size = New System.Drawing.Size(323, 18)
        Me.CurrentProgress.TabIndex = 0
        '
        'OverallProgress
        '
        Me.OverallProgress.Location = New System.Drawing.Point(59, 80)
        Me.OverallProgress.Name = "OverallProgress"
        Me.OverallProgress.Properties.Step = 1
        Me.OverallProgress.Size = New System.Drawing.Size(323, 18)
        Me.OverallProgress.TabIndex = 1
        '
        'lblProgress
        '
        Me.lblProgress.Location = New System.Drawing.Point(12, 47)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(41, 13)
        Me.lblProgress.TabIndex = 2
        Me.lblProgress.Text = "Current:"
        '
        'lblOverallText
        '
        Me.lblOverallText.Location = New System.Drawing.Point(12, 82)
        Me.lblOverallText.Name = "lblOverallText"
        Me.lblOverallText.Size = New System.Drawing.Size(38, 13)
        Me.lblOverallText.TabIndex = 3
        Me.lblOverallText.Text = "Overall:"
        '
        'lblOverallPercent
        '
        Me.lblOverallPercent.Location = New System.Drawing.Point(388, 82)
        Me.lblOverallPercent.Name = "lblOverallPercent"
        Me.lblOverallPercent.Size = New System.Drawing.Size(23, 13)
        Me.lblOverallPercent.TabIndex = 5
        Me.lblOverallPercent.Text = "00%"
        '
        'lblCurrentPercent
        '
        Me.lblCurrentPercent.Location = New System.Drawing.Point(388, 47)
        Me.lblCurrentPercent.Name = "lblCurrentPercent"
        Me.lblCurrentPercent.Size = New System.Drawing.Size(23, 13)
        Me.lblCurrentPercent.TabIndex = 4
        Me.lblCurrentPercent.Text = "00%"
        '
        'cmdHide
        '
        Me.cmdHide.Location = New System.Drawing.Point(185, 115)
        Me.cmdHide.LookAndFeel.SkinName = "iMaginary"
        Me.cmdHide.Name = "cmdHide"
        Me.cmdHide.Size = New System.Drawing.Size(87, 24)
        Me.cmdHide.TabIndex = 38
        Me.cmdHide.Text = "Hide"
        Me.cmdHide.UseWaitCursor = True
        Me.cmdHide.Visible = False
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(292, 115)
        Me.cmdCancel.LookAndFeel.SkinName = "iMaginary"
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(89, 24)
        Me.cmdCancel.TabIndex = 39
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.Visible = False
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(12, 14)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(31, 13)
        Me.lblStatus.TabIndex = 40
        Me.lblStatus.Text = "Status"
        '
        'frmProgress
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(426, 151)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.cmdHide)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.lblOverallPercent)
        Me.Controls.Add(Me.lblCurrentPercent)
        Me.Controls.Add(Me.lblOverallText)
        Me.Controls.Add(Me.lblProgress)
        Me.Controls.Add(Me.OverallProgress)
        Me.Controls.Add(Me.CurrentProgress)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmProgress"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Action Progress"
        Me.TopMost = True
        CType(Me.CurrentProgress.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OverallProgress.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CurrentProgress As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents OverallProgress As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents lblProgress As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblOverallText As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblOverallPercent As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblCurrentPercent As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdHide As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblStatus As DevExpress.XtraEditors.LabelControl
End Class
