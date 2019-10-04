<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUserPref
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUserPref))
        Me.cmdOK = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.cboRankCode = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.tbcFontIncrease = New DevExpress.XtraEditors.TrackBarControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtDueDate = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.txtDueHours = New DevExpress.XtraEditors.TextEdit()
        Me.chkShowWarning = New DevExpress.XtraEditors.CheckEdit()
        Me.chkTreeView = New DevExpress.XtraEditors.CheckEdit()
        Me.chkFlatView = New DevExpress.XtraEditors.CheckEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.cboRankCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbcFontIncrease, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbcFontIncrease.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDueDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDueHours.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowWarning.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkTreeView.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkFlatView.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(125, 255)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(101, 23)
        Me.cmdOK.TabIndex = 2
        Me.cmdOK.Text = "Ok"
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(251, 255)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(98, 23)
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.Text = "Cancel"
        '
        'cboRankCode
        '
        Me.cboRankCode.Location = New System.Drawing.Point(125, 19)
        Me.cboRankCode.Name = "cboRankCode"
        Me.cboRankCode.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.cboRankCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Close)})
        Me.cboRankCode.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("RankCode", "RankCode", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Abbrv", "Name3"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("RankDesc", "RankDesc")})
        Me.cboRankCode.Properties.DisplayMember = "Abbrv"
        Me.cboRankCode.Properties.DropDownRows = 10
        Me.cboRankCode.Properties.NullText = ""
        Me.cboRankCode.Properties.ShowFooter = False
        Me.cboRankCode.Properties.ShowHeader = False
        Me.cboRankCode.Properties.ValueMember = "RankCode"
        Me.cboRankCode.Size = New System.Drawing.Size(224, 20)
        Me.cboRankCode.TabIndex = 237
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(22, 22)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(66, 13)
        Me.LabelControl4.TabIndex = 238
        Me.LabelControl4.Text = "Default Rank:"
        '
        'tbcFontIncrease
        '
        Me.tbcFontIncrease.EditValue = Nothing
        Me.tbcFontIncrease.Location = New System.Drawing.Point(120, 49)
        Me.tbcFontIncrease.Name = "tbcFontIncrease"
        Me.tbcFontIncrease.Properties.LabelAppearance.Options.UseTextOptions = True
        Me.tbcFontIncrease.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.tbcFontIncrease.Properties.LargeChange = 1
        Me.tbcFontIncrease.Properties.Maximum = 5
        Me.tbcFontIncrease.Size = New System.Drawing.Size(232, 45)
        Me.tbcFontIncrease.TabIndex = 239
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(22, 59)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl1.TabIndex = 240
        Me.LabelControl1.Text = "Font Size:"
        '
        'txtDueDate
        '
        Me.txtDueDate.Location = New System.Drawing.Point(125, 101)
        Me.txtDueDate.Name = "txtDueDate"
        Me.txtDueDate.Properties.MaxLength = 30
        Me.txtDueDate.Size = New System.Drawing.Size(224, 20)
        Me.txtDueDate.TabIndex = 241
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(22, 104)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(84, 13)
        Me.LabelControl2.TabIndex = 242
        Me.LabelControl2.Text = "Days before due:"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(22, 144)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(88, 13)
        Me.LabelControl3.TabIndex = 244
        Me.LabelControl3.Text = "Hours before due:"
        '
        'txtDueHours
        '
        Me.txtDueHours.Location = New System.Drawing.Point(125, 141)
        Me.txtDueHours.Name = "txtDueHours"
        Me.txtDueHours.Properties.MaxLength = 30
        Me.txtDueHours.Size = New System.Drawing.Size(224, 20)
        Me.txtDueHours.TabIndex = 243
        '
        'chkShowWarning
        '
        Me.chkShowWarning.Location = New System.Drawing.Point(125, 218)
        Me.chkShowWarning.Name = "chkShowWarning"
        Me.chkShowWarning.Properties.Caption = "Show warning when dragging components"
        Me.chkShowWarning.Size = New System.Drawing.Size(232, 19)
        Me.chkShowWarning.TabIndex = 245
        '
        'chkTreeView
        '
        Me.chkTreeView.Location = New System.Drawing.Point(125, 181)
        Me.chkTreeView.Name = "chkTreeView"
        Me.chkTreeView.Properties.Caption = "Tree View"
        Me.chkTreeView.Size = New System.Drawing.Size(78, 19)
        Me.chkTreeView.TabIndex = 246
        '
        'chkFlatView
        '
        Me.chkFlatView.Location = New System.Drawing.Point(251, 181)
        Me.chkFlatView.Name = "chkFlatView"
        Me.chkFlatView.Properties.Caption = "Flat View"
        Me.chkFlatView.Size = New System.Drawing.Size(78, 19)
        Me.chkFlatView.TabIndex = 247
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(22, 183)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(90, 13)
        Me.LabelControl5.TabIndex = 248
        Me.LabelControl5.Text = "Maintenance View:"
        '
        'frmUserPref
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(371, 314)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.chkFlatView)
        Me.Controls.Add(Me.chkTreeView)
        Me.Controls.Add(Me.chkShowWarning)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.txtDueHours)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.txtDueDate)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.tbcFontIncrease)
        Me.Controls.Add(Me.cboRankCode)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmdCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUserPref"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User Preferences"
        CType(Me.cboRankCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbcFontIncrease.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbcFontIncrease, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDueDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDueHours.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowWarning.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkTreeView.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkFlatView.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cboRankCode As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tbcFontIncrease As DevExpress.XtraEditors.TrackBarControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtDueDate As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtDueHours As DevExpress.XtraEditors.TextEdit
    Friend WithEvents chkShowWarning As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkTreeView As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkFlatView As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
End Class
