<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlanning
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPlanning))
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.cboRankCode = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.txtNumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.lblWorkDescription = New DevExpress.XtraEditors.LabelControl()
        Me.cboType = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.gDetails = New DevExpress.XtraEditors.GroupControl()
        Me.cboWork = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboComponent = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.txtCompNum = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.cboRankCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gDetails.SuspendLayout()
        CType(Me.cboWork.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboComponent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCompNum.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(318, 263)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(69, 23)
        Me.cmdOk.TabIndex = 9
        Me.cmdOk.Text = "Done"
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(401, 263)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(69, 23)
        Me.cmdCancel.TabIndex = 10
        Me.cmdCancel.Text = "Cancel"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(196, 107)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl5.TabIndex = 47
        Me.LabelControl5.Text = "Type"
        '
        'cboRankCode
        '
        Me.cboRankCode.Location = New System.Drawing.Point(128, 77)
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
        Me.cboRankCode.Size = New System.Drawing.Size(287, 20)
        Me.cboRankCode.TabIndex = 2
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(28, 127)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(70, 13)
        Me.LabelControl3.TabIndex = 46
        Me.LabelControl3.Text = "Work Interval:"
        '
        'txtNumber
        '
        Me.txtNumber.EditValue = ""
        Me.txtNumber.Location = New System.Drawing.Point(128, 124)
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.Properties.Appearance.Options.UseTextOptions = True
        Me.txtNumber.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtNumber.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtNumber.Properties.Mask.EditMask = "f0"
        Me.txtNumber.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtNumber.Size = New System.Drawing.Size(69, 20)
        Me.txtNumber.TabIndex = 3
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(28, 80)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(73, 13)
        Me.LabelControl2.TabIndex = 45
        Me.LabelControl2.Text = "To be done by:"
        '
        'lblWorkDescription
        '
        Me.lblWorkDescription.Location = New System.Drawing.Point(28, 41)
        Me.lblWorkDescription.Name = "lblWorkDescription"
        Me.lblWorkDescription.Size = New System.Drawing.Size(84, 13)
        Me.lblWorkDescription.TabIndex = 187
        Me.lblWorkDescription.Text = "Work to be done:"
        '
        'cboType
        '
        Me.cboType.Location = New System.Drawing.Point(196, 124)
        Me.cboType.Name = "cboType"
        Me.cboType.Properties.AutoSearchColumnIndex = 1
        Me.cboType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboType.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("IntCode", "", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("IntName", "Name")})
        Me.cboType.Properties.DisplayMember = "IntName"
        Me.cboType.Properties.DropDownRows = 10
        Me.cboType.Properties.NullText = ""
        Me.cboType.Properties.ShowFooter = False
        Me.cboType.Properties.ShowHeader = False
        Me.cboType.Properties.ValueMember = "IntCode"
        Me.cboType.Size = New System.Drawing.Size(219, 20)
        Me.cboType.TabIndex = 4
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(129, 107)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl6.TabIndex = 189
        Me.LabelControl6.Text = "Number"
        '
        'gDetails
        '
        Me.gDetails.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gDetails.AppearanceCaption.Options.UseFont = True
        Me.gDetails.Controls.Add(Me.cboWork)
        Me.gDetails.Controls.Add(Me.LabelControl2)
        Me.gDetails.Controls.Add(Me.LabelControl6)
        Me.gDetails.Controls.Add(Me.txtNumber)
        Me.gDetails.Controls.Add(Me.cboType)
        Me.gDetails.Controls.Add(Me.LabelControl3)
        Me.gDetails.Controls.Add(Me.lblWorkDescription)
        Me.gDetails.Controls.Add(Me.cboRankCode)
        Me.gDetails.Controls.Add(Me.LabelControl5)
        Me.gDetails.Location = New System.Drawing.Point(28, 21)
        Me.gDetails.Name = "gDetails"
        Me.gDetails.Size = New System.Drawing.Size(442, 169)
        Me.gDetails.TabIndex = 0
        Me.gDetails.Text = "* Maintenance Description"
        '
        'cboWork
        '
        Me.cboWork.Location = New System.Drawing.Point(128, 38)
        Me.cboWork.Name = "cboWork"
        Me.cboWork.Properties.AutoSearchColumnIndex = 1
        Me.cboWork.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboWork.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("WorkCode", "", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Maintenance", "Name")})
        Me.cboWork.Properties.DisplayMember = "Maintenance"
        Me.cboWork.Properties.DropDownRows = 10
        Me.cboWork.Properties.NullText = ""
        Me.cboWork.Properties.ShowFooter = False
        Me.cboWork.Properties.ShowHeader = False
        Me.cboWork.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboWork.Properties.ValueMember = "WorkCode"
        Me.cboWork.Size = New System.Drawing.Size(287, 20)
        Me.cboWork.TabIndex = 1
        '
        'cboComponent
        '
        Me.cboComponent.Location = New System.Drawing.Point(107, 216)
        Me.cboComponent.Name = "cboComponent"
        Me.cboComponent.Properties.AutoSearchColumnIndex = 1
        Me.cboComponent.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboComponent.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ComponentCode", "", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Component", "Name")})
        Me.cboComponent.Properties.DisplayMember = "Component"
        Me.cboComponent.Properties.DropDownRows = 10
        Me.cboComponent.Properties.NullText = ""
        Me.cboComponent.Properties.ShowFooter = False
        Me.cboComponent.Properties.ShowHeader = False
        Me.cboComponent.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboComponent.Properties.ValueMember = "ComponentCode"
        Me.cboComponent.Size = New System.Drawing.Size(211, 20)
        Me.cboComponent.TabIndex = 6
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(30, 219)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(59, 13)
        Me.LabelControl8.TabIndex = 187
        Me.LabelControl8.Text = "Component:"
        '
        'txtCompNum
        '
        Me.txtCompNum.EditValue = ""
        Me.txtCompNum.Location = New System.Drawing.Point(401, 216)
        Me.txtCompNum.Name = "txtCompNum"
        Me.txtCompNum.Properties.Appearance.Options.UseTextOptions = True
        Me.txtCompNum.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtCompNum.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtCompNum.Properties.Mask.EditMask = "f0"
        Me.txtCompNum.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtCompNum.Size = New System.Drawing.Size(69, 20)
        Me.txtCompNum.TabIndex = 7
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(352, 219)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(41, 13)
        Me.LabelControl1.TabIndex = 192
        Me.LabelControl1.Text = "Number:"
        '
        'frmPlanning
        '
        Me.AcceptButton = Me.cmdOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(500, 312)
        Me.Controls.Add(Me.txtCompNum)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.cboComponent)
        Me.Controls.Add(Me.gDetails)
        Me.Controls.Add(Me.LabelControl8)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.LookAndFeel.SkinName = "iMaginary"
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPlanning"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Planning Information"
        Me.TopMost = True
        CType(Me.cboRankCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gDetails.ResumeLayout(False)
        Me.gDetails.PerformLayout()
        CType(Me.cboWork.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboComponent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCompNum.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboRankCode As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblWorkDescription As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents gDetails As DevExpress.XtraEditors.GroupControl
    Friend WithEvents cboWork As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cboComponent As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtCompNum As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
End Class
