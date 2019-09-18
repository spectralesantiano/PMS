<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MAINTENANCE
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
        Me.header = New DevExpress.XtraEditors.GroupControl()
        Me.txtName = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'header
        '
        Me.header.Controls.Add(Me.txtName)
        Me.header.Controls.Add(Me.LabelControl12)
        Me.header.Dock = System.Windows.Forms.DockStyle.Fill
        Me.header.Location = New System.Drawing.Point(0, 0)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(1207, 481)
        Me.header.TabIndex = 36
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(237, 37)
        Me.txtName.Name = "txtName"
        Me.txtName.Properties.MaxLength = 100
        Me.txtName.Size = New System.Drawing.Size(399, 20)
        Me.txtName.TabIndex = 188
        '
        'LabelControl12
        '
        Me.LabelControl12.Location = New System.Drawing.Point(24, 40)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(158, 13)
        Me.LabelControl12.TabIndex = 189
        Me.LabelControl12.Text = "* Maintenance Work Description:"
        '
        'MAINTENANCE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.header)
        Me.Name = "MAINTENANCE"
        Me.Size = New System.Drawing.Size(1207, 481)
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        Me.header.PerformLayout()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents txtName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl

End Class
