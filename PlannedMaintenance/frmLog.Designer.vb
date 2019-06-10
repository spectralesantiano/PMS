<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLog))
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.txtLog = New DevExpress.XtraEditors.MemoEdit()
        Me.cmdImport = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.txtLog.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(598, 393)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(78, 23)
        Me.cmdCancel.TabIndex = 6
        Me.cmdCancel.Text = "Close"
        '
        'txtLog
        '
        Me.txtLog.Location = New System.Drawing.Point(13, 13)
        Me.txtLog.Name = "txtLog"
        Me.txtLog.Size = New System.Drawing.Size(663, 371)
        Me.txtLog.TabIndex = 7
        '
        'cmdImport
        '
        Me.cmdImport.Location = New System.Drawing.Point(504, 393)
        Me.cmdImport.Name = "cmdImport"
        Me.cmdImport.Size = New System.Drawing.Size(78, 23)
        Me.cmdImport.TabIndex = 8
        Me.cmdImport.Text = "Import Data"
        Me.cmdImport.Visible = False
        '
        'frmLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(688, 425)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdImport)
        Me.Controls.Add(Me.txtLog)
        Me.Controls.Add(Me.cmdCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.LookAndFeel.SkinName = "iMaginary"
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Log"
        CType(Me.txtLog.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtLog As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents cmdImport As DevExpress.XtraEditors.SimpleButton
End Class
