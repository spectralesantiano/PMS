<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SECUSERS
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
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupList = New DevExpress.XtraEditors.LookUpEdit()
        Me.lalbel1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtUserName = New DevExpress.XtraEditors.TextEdit()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.GroupList.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUserName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'header
        '
        Me.header.AppearanceCaption.Options.UseFont = True
        Me.header.Controls.Add(Me.LabelControl4)
        Me.header.Controls.Add(Me.GroupList)
        Me.header.Controls.Add(Me.lalbel1)
        Me.header.Controls.Add(Me.txtUserName)
        Me.header.Dock = System.Windows.Forms.DockStyle.Fill
        Me.header.Location = New System.Drawing.Point(0, 0)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(843, 569)
        Me.header.TabIndex = 36
        Me.header.Text = "Edit Users"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(344, 54)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(42, 13)
        Me.LabelControl4.TabIndex = 9
        Me.LabelControl4.Text = "* Group:"
        '
        'GroupList
        '
        Me.GroupList.Location = New System.Drawing.Point(394, 51)
        Me.GroupList.Name = "GroupList"
        Me.GroupList.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.GroupList.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("GroupID", "Name6", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("GroupName", "Name7")})
        Me.GroupList.Properties.DisplayMember = "GroupName"
        Me.GroupList.Properties.DropDownRows = 10
        Me.GroupList.Properties.NullText = ""
        Me.GroupList.Properties.ShowFooter = False
        Me.GroupList.Properties.ShowHeader = False
        Me.GroupList.Properties.ValueMember = "GroupID"
        Me.GroupList.Size = New System.Drawing.Size(192, 20)
        Me.GroupList.TabIndex = 8
        '
        'lalbel1
        '
        Me.lalbel1.Location = New System.Drawing.Point(34, 54)
        Me.lalbel1.Name = "lalbel1"
        Me.lalbel1.Size = New System.Drawing.Size(65, 13)
        Me.lalbel1.TabIndex = 7
        Me.lalbel1.Text = "* User Name:"
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(110, 51)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(205, 20)
        Me.txtUserName.TabIndex = 5
        '
        'SECUSERS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.header)
        Me.Name = "SECUSERS"
        Me.Size = New System.Drawing.Size(843, 569)
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        Me.header.PerformLayout()
        CType(Me.GroupList.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUserName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupList As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lalbel1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtUserName As DevExpress.XtraEditors.TextEdit

End Class
