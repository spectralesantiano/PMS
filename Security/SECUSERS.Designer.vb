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
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.chkActive = New DevExpress.XtraEditors.CheckEdit()
        Me.txtUserName = New DevExpress.XtraEditors.TextEdit()
        Me.GroupList = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtFamilyName = New DevExpress.XtraEditors.TextEdit()
        Me.txtMiddleName = New DevExpress.XtraEditors.TextEdit()
        Me.txtFirstName = New DevExpress.XtraEditors.TextEdit()
        Me.dteDateSON = New DevExpress.XtraEditors.DateEdit()
        Me.lkuRank = New DevExpress.XtraEditors.LookUpEdit()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup4 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        CType(Me.header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.header.SuspendLayout()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl2.SuspendLayout()
        CType(Me.chkActive.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUserName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupList.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFamilyName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMiddleName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFirstName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dteDateSON.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dteDateSON.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lkuRank.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'header
        '
        Me.header.AppearanceCaption.Options.UseFont = True
        Me.header.Controls.Add(Me.LayoutControl2)
        Me.header.Controls.Add(Me.LayoutControl1)
        Me.header.Dock = System.Windows.Forms.DockStyle.Fill
        Me.header.Location = New System.Drawing.Point(0, 0)
        Me.header.Name = "header"
        Me.header.Size = New System.Drawing.Size(843, 569)
        Me.header.TabIndex = 36
        Me.header.Text = "Edit Users"
        '
        'LayoutControl2
        '
        Me.LayoutControl2.Controls.Add(Me.chkActive)
        Me.LayoutControl2.Controls.Add(Me.txtUserName)
        Me.LayoutControl2.Controls.Add(Me.GroupList)
        Me.LayoutControl2.Controls.Add(Me.txtFamilyName)
        Me.LayoutControl2.Controls.Add(Me.txtMiddleName)
        Me.LayoutControl2.Controls.Add(Me.txtFirstName)
        Me.LayoutControl2.Controls.Add(Me.dteDateSON)
        Me.LayoutControl2.Controls.Add(Me.lkuRank)
        Me.LayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl2.Location = New System.Drawing.Point(2, 20)
        Me.LayoutControl2.Name = "LayoutControl2"
        Me.LayoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(523, 167, 622, 350)
        Me.LayoutControl2.Root = Me.LayoutControlGroup2
        Me.LayoutControl2.Size = New System.Drawing.Size(839, 547)
        Me.LayoutControl2.TabIndex = 21
        Me.LayoutControl2.Text = "LayoutControl2"
        '
        'chkActive
        '
        Me.chkActive.Location = New System.Drawing.Point(620, 230)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Properties.Caption = ""
        Me.chkActive.Properties.ValueChecked = 1
        Me.chkActive.Properties.ValueGrayed = 0
        Me.chkActive.Properties.ValueUnchecked = 0
        Me.chkActive.Size = New System.Drawing.Size(195, 19)
        Me.chkActive.StyleController = Me.LayoutControl2
        Me.chkActive.TabIndex = 16
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(24, 228)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(393, 20)
        Me.txtUserName.StyleController = Me.LayoutControl2
        Me.txtUserName.TabIndex = 5
        '
        'GroupList
        '
        Me.GroupList.Location = New System.Drawing.Point(421, 228)
        Me.GroupList.Name = "GroupList"
        Me.GroupList.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.GroupList.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("GroupID", "Name6", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("GroupName", "Name7")})
        Me.GroupList.Properties.DisplayMember = "GroupName"
        Me.GroupList.Properties.DropDownRows = 10
        Me.GroupList.Properties.NullText = ""
        Me.GroupList.Properties.ShowFooter = False
        Me.GroupList.Properties.ShowHeader = False
        Me.GroupList.Properties.ValueMember = "GroupID"
        Me.GroupList.Size = New System.Drawing.Size(195, 20)
        Me.GroupList.StyleController = Me.LayoutControl2
        Me.GroupList.TabIndex = 8
        '
        'txtFamilyName
        '
        Me.txtFamilyName.Location = New System.Drawing.Point(24, 58)
        Me.txtFamilyName.Name = "txtFamilyName"
        Me.txtFamilyName.Size = New System.Drawing.Size(227, 20)
        Me.txtFamilyName.StyleController = Me.LayoutControl2
        Me.txtFamilyName.TabIndex = 11
        '
        'txtMiddleName
        '
        Me.txtMiddleName.Location = New System.Drawing.Point(454, 58)
        Me.txtMiddleName.Name = "txtMiddleName"
        Me.txtMiddleName.Size = New System.Drawing.Size(361, 20)
        Me.txtMiddleName.StyleController = Me.LayoutControl2
        Me.txtMiddleName.TabIndex = 12
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(255, 58)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(195, 20)
        Me.txtFirstName.StyleController = Me.LayoutControl2
        Me.txtFirstName.TabIndex = 14
        '
        'dteDateSON
        '
        Me.dteDateSON.EditValue = Nothing
        Me.dteDateSON.Location = New System.Drawing.Point(255, 112)
        Me.dteDateSON.Name = "dteDateSON"
        Me.dteDateSON.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dteDateSON.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dteDateSON.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.dteDateSON.Size = New System.Drawing.Size(195, 20)
        Me.dteDateSON.StyleController = Me.LayoutControl2
        Me.dteDateSON.TabIndex = 15
        '
        'lkuRank
        '
        Me.lkuRank.Location = New System.Drawing.Point(24, 112)
        Me.lkuRank.Name = "lkuRank"
        Me.lkuRank.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lkuRank.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Abbrv", "Abbrv"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("RankCode", "RankCode", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.lkuRank.Properties.DisplayMember = "Abbrv"
        Me.lkuRank.Properties.NullText = ""
        Me.lkuRank.Properties.ShowFooter = False
        Me.lkuRank.Properties.ShowHeader = False
        Me.lkuRank.Properties.ValueMember = "RankCode"
        Me.lkuRank.Size = New System.Drawing.Size(227, 20)
        Me.lkuRank.StyleController = Me.LayoutControl2
        Me.lkuRank.TabIndex = 13
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup2.GroupBordersVisible = False
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup3, Me.LayoutControlGroup4})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "Root"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(839, 547)
        Me.LayoutControlGroup2.TextVisible = False
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlGroup3.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem7, Me.LayoutControlItem6, Me.EmptySpaceItem1, Me.LayoutControlItem8})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 170)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(819, 357)
        Me.LayoutControlGroup3.Text = "Log-in Information"
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.txtUserName
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem7.MinSize = New System.Drawing.Size(154, 24)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(397, 41)
        Me.LayoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem7.Text = "* Username"
        Me.LayoutControlItem7.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(77, 13)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.GroupList
        Me.LayoutControlItem6.Location = New System.Drawing.Point(397, 0)
        Me.LayoutControlItem6.MinSize = New System.Drawing.Size(154, 24)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(199, 41)
        Me.LayoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem6.Text = "Assign to Group"
        Me.LayoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(77, 13)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 41)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(795, 274)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.chkActive
        Me.LayoutControlItem8.Location = New System.Drawing.Point(596, 0)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(199, 41)
        Me.LayoutControlItem8.Text = "Active"
        Me.LayoutControlItem8.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem8.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(30, 13)
        Me.LayoutControlItem8.TextToControlDistance = 5
        '
        'LayoutControlGroup4
        '
        Me.LayoutControlGroup4.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlGroup4.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup4.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlItem5, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem1, Me.EmptySpaceItem2})
        Me.LayoutControlGroup4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup4.Name = "LayoutControlGroup4"
        Me.LayoutControlGroup4.Size = New System.Drawing.Size(819, 170)
        Me.LayoutControlGroup4.Text = "Personal Information"
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtFamilyName
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(100, 40)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(231, 54)
        Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem2.Text = "* Family Name:"
        Me.LayoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(77, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.txtFirstName
        Me.LayoutControlItem5.Location = New System.Drawing.Point(231, 0)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(100, 40)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.OptionsTableLayoutItem.ColumnIndex = 1
        Me.LayoutControlItem5.Size = New System.Drawing.Size(199, 54)
        Me.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem5.Text = "* First Name:"
        Me.LayoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(77, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtMiddleName
        Me.LayoutControlItem3.Location = New System.Drawing.Point(430, 0)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(100, 40)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.OptionsTableLayoutItem.ColumnIndex = 1
        Me.LayoutControlItem3.OptionsTableLayoutItem.RowIndex = 1
        Me.LayoutControlItem3.Size = New System.Drawing.Size(365, 54)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.Text = "Middle Name:"
        Me.LayoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(77, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.lkuRank
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 54)
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(50, 25)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.OptionsTableLayoutItem.RowIndex = 2
        Me.LayoutControlItem4.Size = New System.Drawing.Size(231, 74)
        Me.LayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem4.Text = "* Rank:"
        Me.LayoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(77, 13)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.dteDateSON
        Me.LayoutControlItem1.Location = New System.Drawing.Point(231, 54)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(50, 25)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.OptionsTableLayoutItem.RowIndex = 1
        Me.LayoutControlItem1.Size = New System.Drawing.Size(199, 74)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.Text = "* Date Sign-On:"
        Me.LayoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(77, 13)
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Location = New System.Drawing.Point(300, 187)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(8, 10)
        Me.LayoutControl1.TabIndex = 10
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(20, 20)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(430, 54)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(365, 74)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'SECUSERS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.header)
        Me.Name = "SECUSERS"
        Me.Size = New System.Drawing.Size(843, 569)
        CType(Me.header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.header.ResumeLayout(False)
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl2.ResumeLayout(False)
        CType(Me.chkActive.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUserName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupList.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFamilyName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMiddleName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFirstName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dteDateSON.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dteDateSON.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lkuRank.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents header As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupList As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtUserName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControl2 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents txtFamilyName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtMiddleName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtFirstName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlGroup4 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents chkActive As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents dteDateSON As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lkuRank As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem

End Class
