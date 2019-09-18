<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExportToSM
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExportToSM))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.cmdExport = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdClose = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.txtExportDir = New DevExpress.XtraEditors.ButtonEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.lblLastExp = New DevExpress.XtraEditors.LabelControl()
        Me.deFrom = New DevExpress.XtraEditors.DateEdit()
        Me.deTo = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.txtExportDir.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(21, 58)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(83, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Export Directory:"
        '
        'cmdExport
        '
        Me.cmdExport.Location = New System.Drawing.Point(262, 145)
        Me.cmdExport.Name = "cmdExport"
        Me.cmdExport.Size = New System.Drawing.Size(66, 23)
        Me.cmdExport.TabIndex = 14
        Me.cmdExport.Text = "Export"
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(334, 145)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(66, 23)
        Me.cmdClose.TabIndex = 15
        Me.cmdClose.Text = "Cancel"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(269, 89)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(12, 13)
        Me.LabelControl3.TabIndex = 10
        Me.LabelControl3.Text = "To"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(126, 89)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl4.TabIndex = 12
        Me.LabelControl4.Text = "From"
        '
        'txtExportDir
        '
        Me.txtExportDir.Location = New System.Drawing.Point(125, 55)
        Me.txtExportDir.Name = "txtExportDir"
        Me.txtExportDir.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtExportDir.Size = New System.Drawing.Size(275, 20)
        Me.txtExportDir.TabIndex = 0
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(21, 27)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(85, 13)
        Me.LabelControl5.TabIndex = 15
        Me.LabelControl5.Text = "Date Last Export:"
        '
        'lblLastExp
        '
        Me.lblLastExp.Location = New System.Drawing.Point(126, 27)
        Me.lblLastExp.Name = "lblLastExp"
        Me.lblLastExp.Size = New System.Drawing.Size(18, 13)
        Me.lblLastExp.TabIndex = 21
        Me.lblLastExp.Text = "N/A"
        '
        'deFrom
        '
        Me.deFrom.EditValue = Nothing
        Me.deFrom.Location = New System.Drawing.Point(125, 104)
        Me.deFrom.Name = "deFrom"
        Me.deFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deFrom.Properties.EditFormat.FormatString = ""
        Me.deFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deFrom.Size = New System.Drawing.Size(139, 20)
        Me.deFrom.TabIndex = 1
        '
        'deTo
        '
        Me.deTo.EditValue = Nothing
        Me.deTo.Location = New System.Drawing.Point(263, 104)
        Me.deTo.Name = "deTo"
        Me.deTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deTo.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deTo.Properties.EditFormat.FormatString = ""
        Me.deTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deTo.Size = New System.Drawing.Size(137, 20)
        Me.deTo.TabIndex = 2
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(21, 107)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl6.TabIndex = 22
        Me.LabelControl6.Text = "Period:"
        '
        'frmExportToSM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(424, 189)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.lblLastExp)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.cmdExport)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.txtExportDir)
        Me.Controls.Add(Me.deFrom)
        Me.Controls.Add(Me.deTo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmExportToSM"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Export to SM"
        CType(Me.txtExportDir.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdExport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtExportDir As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblLastExp As DevExpress.XtraEditors.LabelControl
    Friend WithEvents deFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents deTo As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
End Class
