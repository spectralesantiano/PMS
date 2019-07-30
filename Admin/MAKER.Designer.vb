<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MAKER
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
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl12
        '
        Me.LabelControl12.Location = New System.Drawing.Point(34, 45)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(38, 13)
        Me.LabelControl12.TabIndex = 31
        Me.LabelControl12.Text = "* Maker"
        '
        'header
        '
        Me.header.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.header.AppearanceCaption.Options.UseFont = True
        Me.header.Controls.Add(Me.txtName)
        Me.header.Controls.Add(Me.LabelControl12)
        Me.header.Dock = System.Windows.Forms.DockStyle.Fill
        Me.header.Location = New System.Drawing.Point(0, 0)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(531, 244)
        Me.header.TabIndex = 36
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(34, 64)
        Me.txtName.Name = "txtName"
        Me.txtName.Properties.MaxLength = 30
        Me.txtName.Size = New System.Drawing.Size(231, 20)
        Me.txtName.TabIndex = 0
        '
        'MAKER
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.header)
        Me.Name = "MAKER"
        Me.Size = New System.Drawing.Size(531, 244)
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        Me.header.PerformLayout()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents txtName As DevExpress.XtraEditors.TextEdit

End Class
