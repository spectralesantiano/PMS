<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMaintenance
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMaintenance))
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.txtInsDesc = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtInsCrossRef = New DevExpress.XtraEditors.TextEdit()
        Me.txtInsDateIssued = New DevExpress.XtraEditors.DateEdit()
        Me.txtInsEditor = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.cboWorkCode = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.txtNumber = New DevExpress.XtraEditors.TextEdit()
        Me.cboIntCode = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboRankCode = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.chkPreventive = New DevExpress.XtraEditors.CheckEdit()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.cmdClear = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdBrowse = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.txtInsDesc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInsCrossRef.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInsDateIssued.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInsDateIssued.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInsEditor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboWorkCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboIntCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboRankCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPreventive.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(304, 353)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(65, 23)
        Me.cmdOk.TabIndex = 9
        Me.cmdOk.Text = "Done"
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(373, 353)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(61, 23)
        Me.cmdCancel.TabIndex = 10
        Me.cmdCancel.Text = "Cancel"
        '
        'txtInsDesc
        '
        Me.txtInsDesc.Location = New System.Drawing.Point(22, 241)
        Me.txtInsDesc.Name = "txtInsDesc"
        Me.txtInsDesc.Size = New System.Drawing.Size(283, 93)
        Me.txtInsDesc.TabIndex = 8
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(22, 222)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(123, 13)
        Me.LabelControl10.TabIndex = 196
        Me.LabelControl10.Text = "Instruction to be followed"
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(209, 171)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(28, 13)
        Me.LabelControl8.TabIndex = 194
        Me.LabelControl8.Text = "Editor"
        '
        'LabelControl9
        '
        Me.LabelControl9.Location = New System.Drawing.Point(22, 171)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(58, 13)
        Me.LabelControl9.TabIndex = 192
        Me.LabelControl9.Text = "Date Issued"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(22, 123)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(113, 13)
        Me.LabelControl1.TabIndex = 188
        Me.LabelControl1.Text = "Cross Ref. from manual"
        '
        'txtInsCrossRef
        '
        Me.txtInsCrossRef.Location = New System.Drawing.Point(22, 142)
        Me.txtInsCrossRef.Name = "txtInsCrossRef"
        Me.txtInsCrossRef.Size = New System.Drawing.Size(412, 20)
        Me.txtInsCrossRef.TabIndex = 5
        '
        'txtInsDateIssued
        '
        Me.txtInsDateIssued.EditValue = Nothing
        Me.txtInsDateIssued.Location = New System.Drawing.Point(22, 190)
        Me.txtInsDateIssued.Name = "txtInsDateIssued"
        Me.txtInsDateIssued.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtInsDateIssued.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtInsDateIssued.Properties.MaxLength = 30
        Me.txtInsDateIssued.Size = New System.Drawing.Size(187, 20)
        Me.txtInsDateIssued.TabIndex = 6
        '
        'txtInsEditor
        '
        Me.txtInsEditor.Location = New System.Drawing.Point(208, 190)
        Me.txtInsEditor.Name = "txtInsEditor"
        Me.txtInsEditor.Properties.MaxLength = 30
        Me.txtInsEditor.Size = New System.Drawing.Size(226, 20)
        Me.txtInsEditor.TabIndex = 7
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(22, 18)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(70, 13)
        Me.LabelControl3.TabIndex = 200
        Me.LabelControl3.Text = "* Maintenance"
        '
        'cboWorkCode
        '
        Me.cboWorkCode.Location = New System.Drawing.Point(22, 37)
        Me.cboWorkCode.Name = "cboWorkCode"
        Me.cboWorkCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboWorkCode.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("WorkCode", "WorkCode", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Maintenance", "Maintenance")})
        Me.cboWorkCode.Properties.DisplayMember = "Maintenance"
        Me.cboWorkCode.Properties.DropDownRows = 10
        Me.cboWorkCode.Properties.NullText = ""
        Me.cboWorkCode.Properties.ShowFooter = False
        Me.cboWorkCode.Properties.ShowHeader = False
        Me.cboWorkCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboWorkCode.Properties.ValueMember = "WorkCode"
        Me.cboWorkCode.Size = New System.Drawing.Size(187, 20)
        Me.cboWorkCode.TabIndex = 0
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(208, 18)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(73, 13)
        Me.LabelControl5.TabIndex = 204
        Me.LabelControl5.Text = "To be done by:"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(209, 65)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl6.TabIndex = 207
        Me.LabelControl6.Text = "Number"
        '
        'txtNumber
        '
        Me.txtNumber.EditValue = ""
        Me.txtNumber.Location = New System.Drawing.Point(208, 82)
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.Properties.Appearance.Options.UseTextOptions = True
        Me.txtNumber.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtNumber.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtNumber.Properties.Mask.EditMask = "f0"
        Me.txtNumber.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtNumber.Size = New System.Drawing.Size(96, 20)
        Me.txtNumber.TabIndex = 3
        '
        'cboIntCode
        '
        Me.cboIntCode.Location = New System.Drawing.Point(303, 82)
        Me.cboIntCode.Name = "cboIntCode"
        Me.cboIntCode.Properties.AutoSearchColumnIndex = 1
        Me.cboIntCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboIntCode.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("IntCode", "", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("IntName", "Name")})
        Me.cboIntCode.Properties.DisplayMember = "IntName"
        Me.cboIntCode.Properties.DropDownRows = 10
        Me.cboIntCode.Properties.NullText = ""
        Me.cboIntCode.Properties.ShowFooter = False
        Me.cboIntCode.Properties.ShowHeader = False
        Me.cboIntCode.Properties.ValueMember = "IntCode"
        Me.cboIntCode.Size = New System.Drawing.Size(131, 20)
        Me.cboIntCode.TabIndex = 4
        '
        'cboRankCode
        '
        Me.cboRankCode.Location = New System.Drawing.Point(208, 37)
        Me.cboRankCode.Name = "cboRankCode"
        Me.cboRankCode.Properties.AutoSearchColumnIndex = 1
        Me.cboRankCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboRankCode.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("RankCode", "", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("RankDesc", "Name")})
        Me.cboRankCode.Properties.DisplayMember = "RankDesc"
        Me.cboRankCode.Properties.DropDownRows = 10
        Me.cboRankCode.Properties.NullText = ""
        Me.cboRankCode.Properties.ShowFooter = False
        Me.cboRankCode.Properties.ShowHeader = False
        Me.cboRankCode.Properties.ValueMember = "RankCode"
        Me.cboRankCode.Size = New System.Drawing.Size(226, 20)
        Me.cboRankCode.TabIndex = 1
        '
        'LabelControl11
        '
        Me.LabelControl11.Location = New System.Drawing.Point(304, 66)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl11.TabIndex = 206
        Me.LabelControl11.Text = "Type"
        '
        'chkPreventive
        '
        Me.chkPreventive.EditValue = True
        Me.chkPreventive.Location = New System.Drawing.Point(22, 79)
        Me.chkPreventive.Name = "chkPreventive"
        Me.chkPreventive.Properties.AutoWidth = True
        Me.chkPreventive.Properties.Caption = "Preventive Maintenance"
        Me.chkPreventive.Size = New System.Drawing.Size(138, 19)
        Me.chkPreventive.TabIndex = 2
        '
        'imgLogo
        '
        Me.imgLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.imgLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imgLogo.Location = New System.Drawing.Point(304, 241)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(130, 93)
        Me.imgLogo.TabIndex = 208
        Me.imgLogo.TabStop = False
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(373, 216)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(61, 23)
        Me.cmdClear.TabIndex = 210
        Me.cmdClear.Text = "Clear"
        '
        'cmdBrowse
        '
        Me.cmdBrowse.Location = New System.Drawing.Point(304, 216)
        Me.cmdBrowse.Name = "cmdBrowse"
        Me.cmdBrowse.Size = New System.Drawing.Size(64, 23)
        Me.cmdBrowse.TabIndex = 209
        Me.cmdBrowse.Text = "Browse"
        '
        'frmMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(460, 393)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdBrowse)
        Me.Controls.Add(Me.imgLogo)
        Me.Controls.Add(Me.chkPreventive)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.txtNumber)
        Me.Controls.Add(Me.cboIntCode)
        Me.Controls.Add(Me.cboRankCode)
        Me.Controls.Add(Me.LabelControl11)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.cboWorkCode)
        Me.Controls.Add(Me.txtInsDesc)
        Me.Controls.Add(Me.LabelControl10)
        Me.Controls.Add(Me.LabelControl8)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.LabelControl9)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.txtInsEditor)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.txtInsDateIssued)
        Me.Controls.Add(Me.txtInsCrossRef)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.LookAndFeel.SkinName = "iMaginary"
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMaintenance"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Maintenance"
        Me.TopMost = True
        CType(Me.txtInsDesc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInsCrossRef.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInsDateIssued.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInsDateIssued.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInsEditor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboWorkCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboIntCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboRankCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPreventive.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtInsCrossRef As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtInsDesc As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtInsDateIssued As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtInsEditor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboWorkCode As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cboIntCode As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cboRankCode As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkPreventive As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents cmdClear As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdBrowse As DevExpress.XtraEditors.SimpleButton
End Class
