<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUpdateNC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUpdateNC))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtVerifiedBy = New DevExpress.XtraEditors.TextEdit()
        Me.cmdOK = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtVerifiedDate = New DevExpress.XtraEditors.DateEdit()
        Me.gDetails = New DevExpress.XtraEditors.GroupControl()
        CType(Me.txtVerifiedBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVerifiedDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVerifiedDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gDetails.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(22, 43)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(55, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Verified by:"
        '
        'txtVerifiedBy
        '
        Me.txtVerifiedBy.Location = New System.Drawing.Point(118, 40)
        Me.txtVerifiedBy.Name = "txtVerifiedBy"
        Me.txtVerifiedBy.Size = New System.Drawing.Size(224, 20)
        Me.txtVerifiedBy.TabIndex = 0
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(227, 173)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(78, 23)
        Me.cmdOK.TabIndex = 2
        Me.cmdOK.Text = "Update"
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(311, 173)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(78, 23)
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.Text = "Cancel"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(22, 79)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(83, 13)
        Me.LabelControl2.TabIndex = 8
        Me.LabelControl2.Text = "Verification Date:"
        '
        'txtVerifiedDate
        '
        Me.txtVerifiedDate.EditValue = Nothing
        Me.txtVerifiedDate.Location = New System.Drawing.Point(118, 76)
        Me.txtVerifiedDate.Name = "txtVerifiedDate"
        Me.txtVerifiedDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtVerifiedDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtVerifiedDate.Properties.DisplayFormat.FormatString = ""
        Me.txtVerifiedDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtVerifiedDate.Properties.EditFormat.FormatString = ""
        Me.txtVerifiedDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtVerifiedDate.Size = New System.Drawing.Size(224, 20)
        Me.txtVerifiedDate.TabIndex = 1
        '
        'gDetails
        '
        Me.gDetails.Controls.Add(Me.txtVerifiedDate)
        Me.gDetails.Controls.Add(Me.LabelControl2)
        Me.gDetails.Controls.Add(Me.LabelControl1)
        Me.gDetails.Controls.Add(Me.txtVerifiedBy)
        Me.gDetails.Location = New System.Drawing.Point(24, 28)
        Me.gDetails.Name = "gDetails"
        Me.gDetails.Size = New System.Drawing.Size(365, 124)
        Me.gDetails.TabIndex = 0
        Me.gDetails.Text = "Close Non-Conformance"
        '
        'frmUpdateNC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(417, 216)
        Me.Controls.Add(Me.gDetails)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmdCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUpdateNC"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Update Non-Conformance Status"
        CType(Me.txtVerifiedBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVerifiedDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVerifiedDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gDetails.ResumeLayout(False)
        Me.gDetails.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtVerifiedBy As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cmdOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtVerifiedDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents gDetails As DevExpress.XtraEditors.GroupControl
End Class
