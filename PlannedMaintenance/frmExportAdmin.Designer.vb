<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExportAdmin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExportAdmin))
        Me.cmdExport = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.chkEquipment = New DevExpress.XtraEditors.CheckEdit()
        Me.chkUnits = New DevExpress.XtraEditors.CheckEdit()
        Me.chkParts = New DevExpress.XtraEditors.CheckEdit()
        Me.gDetails = New DevExpress.XtraEditors.GroupControl()
        CType(Me.chkEquipment.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkUnits.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkParts.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gDetails.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdExport
        '
        Me.cmdExport.Location = New System.Drawing.Point(128, 172)
        Me.cmdExport.Name = "cmdExport"
        Me.cmdExport.Size = New System.Drawing.Size(78, 23)
        Me.cmdExport.TabIndex = 2
        Me.cmdExport.Text = "Export"
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(212, 172)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(78, 23)
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.Text = "Cancel"
        '
        'chkEquipment
        '
        Me.chkEquipment.EditValue = True
        Me.chkEquipment.Enabled = False
        Me.chkEquipment.Location = New System.Drawing.Point(31, 33)
        Me.chkEquipment.Name = "chkEquipment"
        Me.chkEquipment.Properties.Caption = "Equipments/Components/Maintenances"
        Me.chkEquipment.Size = New System.Drawing.Size(219, 19)
        Me.chkEquipment.TabIndex = 6
        '
        'chkUnits
        '
        Me.chkUnits.EditValue = True
        Me.chkUnits.Location = New System.Drawing.Point(31, 63)
        Me.chkUnits.Name = "chkUnits"
        Me.chkUnits.Properties.Caption = "Units and Locations"
        Me.chkUnits.Size = New System.Drawing.Size(219, 19)
        Me.chkUnits.TabIndex = 7
        '
        'chkParts
        '
        Me.chkParts.EditValue = True
        Me.chkParts.Location = New System.Drawing.Point(31, 96)
        Me.chkParts.Name = "chkParts"
        Me.chkParts.Properties.Caption = "Spare Parts"
        Me.chkParts.Size = New System.Drawing.Size(219, 19)
        Me.chkParts.TabIndex = 8
        '
        'gDetails
        '
        Me.gDetails.Controls.Add(Me.chkEquipment)
        Me.gDetails.Controls.Add(Me.chkParts)
        Me.gDetails.Controls.Add(Me.chkUnits)
        Me.gDetails.Location = New System.Drawing.Point(20, 20)
        Me.gDetails.Name = "gDetails"
        Me.gDetails.Size = New System.Drawing.Size(272, 128)
        Me.gDetails.TabIndex = 9
        Me.gDetails.Text = "Include the following on export"
        '
        'frmExportAdmin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(313, 207)
        Me.Controls.Add(Me.gDetails)
        Me.Controls.Add(Me.cmdExport)
        Me.Controls.Add(Me.cmdCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmExportAdmin"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Export Admin Data"
        CType(Me.chkEquipment.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkUnits.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkParts.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gDetails.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdExport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkEquipment As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkUnits As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkParts As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents gDetails As DevExpress.XtraEditors.GroupControl
End Class
