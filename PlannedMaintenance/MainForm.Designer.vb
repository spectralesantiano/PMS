<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.RibbonControl = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.bbAdd = New DevExpress.XtraBars.BarButtonItem()
        Me.bbSave = New DevExpress.XtraBars.BarButtonItem()
        Me.bbDelete = New DevExpress.XtraBars.BarButtonItem()
        Me.RANK = New DevExpress.XtraBars.BarButtonItem()
        Me.DEPARTMENT = New DevExpress.XtraBars.BarButtonItem()
        Me.bbSaveLayout = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdHelp = New DevExpress.XtraBars.BarButtonItem()
        Me.SECUSERS = New DevExpress.XtraBars.BarButtonItem()
        Me.SECGROUPS = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdChangePassword = New DevExpress.XtraBars.BarButtonItem()
        Me.bbResetPassword = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdChangeUser = New DevExpress.XtraBars.BarButtonItem()
        Me.SWITCHBOARD = New DevExpress.XtraBars.BarButtonItem()
        Me.COMPANYINFO = New DevExpress.XtraBars.BarButtonItem()
        Me.LICENSEINFO = New DevExpress.XtraBars.BarButtonItem()
        Me.bbPreview = New DevExpress.XtraBars.BarButtonItem()
        Me.bbResetLayout = New DevExpress.XtraBars.BarButtonItem()
        Me.BACKUPRESTORE = New DevExpress.XtraBars.BarButtonItem()
        Me.bbBackUp = New DevExpress.XtraBars.BarButtonItem()
        Me.bbRestore = New DevExpress.XtraBars.BarButtonItem()
        Me.VERSIONUPDATE = New DevExpress.XtraBars.BarButtonItem()
        Me.bbUpdate = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdNotification = New DevExpress.XtraBars.BarButtonItem()
        Me.bbExport = New DevExpress.XtraBars.BarButtonItem()
        Me.bbEdit = New DevExpress.XtraBars.BarButtonItem()
        Me.bbSelectAll = New DevExpress.XtraBars.BarButtonItem()
        Me.bbDeselect = New DevExpress.XtraBars.BarButtonItem()
        Me.SETTINGS = New DevExpress.XtraBars.BarButtonItem()
        Me.PMSREP = New DevExpress.XtraBars.BarButtonItem()
        Me.ARCHIVEDATA = New DevExpress.XtraBars.BarButtonItem()
        Me.RECOVERARCHIVE = New DevExpress.XtraBars.BarButtonItem()
        Me.UNITS = New DevExpress.XtraBars.BarButtonItem()
        Me.PART = New DevExpress.XtraBars.BarButtonItem()
        Me.CATEGORY = New DevExpress.XtraBars.BarButtonItem()
        Me.COUNTER = New DevExpress.XtraBars.BarButtonItem()
        Me.VLOCATION = New DevExpress.XtraBars.BarButtonItem()
        Me.ledDepartment = New DevExpress.XtraBars.BarEditItem()
        Me.ledDepartmentRep = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.WORKDONE = New DevExpress.XtraBars.BarButtonItem()
        Me.ledRank = New DevExpress.XtraBars.BarEditItem()
        Me.ledRankRep = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.ledCategory = New DevExpress.XtraBars.BarEditItem()
        Me.ledCategoryRep = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.INTERVAL = New DevExpress.XtraBars.BarButtonItem()
        Me.WORKDUE = New DevExpress.XtraBars.BarButtonItem()
        Me.MAINTENANCE = New DevExpress.XtraBars.BarButtonItem()
        Me.COMPONENT = New DevExpress.XtraBars.BarButtonItem()
        Me.NONCONFORM = New DevExpress.XtraBars.BarButtonItem()
        Me.bbNC = New DevExpress.XtraBars.BarButtonItem()
        Me.bbUpdateNC = New DevExpress.XtraBars.BarButtonItem()
        Me.NCMEASURES = New DevExpress.XtraBars.BarButtonItem()
        Me.EXPORTADMIN = New DevExpress.XtraBars.BarButtonItem()
        Me.IMPORTDATA = New DevExpress.XtraBars.BarButtonItem()
        Me.bbWOMaintenance = New DevExpress.XtraBars.BarButtonItem()
        Me.RUNNINGHOURS = New DevExpress.XtraBars.BarButtonItem()
        Me.txtDueHours = New DevExpress.XtraBars.BarEditItem()
        Me.ledDueHours = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.EXPMAINTENANCE = New DevExpress.XtraBars.BarButtonItem()
        Me.VESSELINFO = New DevExpress.XtraBars.BarButtonItem()
        Me.bbCopy = New DevExpress.XtraBars.BarButtonItem()
        Me.ledMainUnits = New DevExpress.XtraBars.BarEditItem()
        Me.ledUnitRep = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.bbCopyMaintenance = New DevExpress.XtraBars.BarButtonItem()
        Me.bbShowComponents = New DevExpress.XtraBars.BarButtonItem()
        Me.txtDateDue = New DevExpress.XtraBars.BarEditItem()
        Me.ledDueDays = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.bbAddPlannedDate = New DevExpress.XtraBars.BarButtonItem()
        Me.ledPeriod = New DevExpress.XtraBars.BarEditItem()
        Me.ledPeriodRep = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.bbCondition = New DevExpress.XtraBars.BarButtonItem()
        Me.PARTPURCHASE = New DevExpress.XtraBars.BarButtonItem()
        Me.bbViewImage = New DevExpress.XtraBars.BarButtonItem()
        Me.STORAGE = New DevExpress.XtraBars.BarButtonItem()
        Me.MDOCVIEWER = New DevExpress.XtraBars.BarButtonItem()
        Me.WDOCVIEWER = New DevExpress.XtraBars.BarButtonItem()
        Me.bbPaste = New DevExpress.XtraBars.BarButtonItem()
        Me.bbImportFromFile = New DevExpress.XtraBars.BarButtonItem()
        Me.VENDOR = New DevExpress.XtraBars.BarButtonItem()
        Me.MAKER = New DevExpress.XtraBars.BarButtonItem()
        Me.bbCritical = New DevExpress.XtraBars.BarButtonItem()
        Me.bbFlatView = New DevExpress.XtraBars.BarButtonItem()
        Me.bbUserPreferences = New DevExpress.XtraBars.BarButtonItem()
        Me.bbShowAllMaintenance = New DevExpress.XtraBars.BarButtonItem()
        Me.IDOCVIEWER = New DevExpress.XtraBars.BarButtonItem()
        Me.EXPDOCUMENTS = New DevExpress.XtraBars.BarButtonItem()
        Me.AUDIT = New DevExpress.XtraBars.BarButtonItem()
        Me.REFRESH = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdReportPreview = New DevExpress.XtraBars.BarButtonItem()
        Me.chkAuditWithDetails = New DevExpress.XtraBars.BarCheckItem()
        Me.rpMaintenance = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgMaintenance = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgMaintenanceEditingOptions = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgMaintenanceViewingOptions = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgMachineryPrintingOptions = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpInventory = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgInventory = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgInventoryOptions = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgInventoryViewingOptions = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgInventoryPrintingOptions = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpDocViewer = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgDocViewer = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpAdmin = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgAdmin = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgAdminEditingOptions = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgAdminFilterOptions = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgAdminPrintingOptions = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpTools = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgTools = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgToolSelectionOption = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgToolsOptions = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgToolsFilterOptions = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpSecurity = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgSecurity = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgSecEditingOptions = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpAudit = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgAudit = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgAuditReport = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpReports = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgReportsOptions = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgReportsSelectionOptions = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgReportsPrintOptions = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpHome = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.DateDueEdit = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.RibbonStatusBar = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.MainPanel = New DevExpress.XtraEditors.SplitContainerControl()
        Me.pmMainMenu = New DevExpress.XtraBars.PopupMenu()
        Me.pmListMenu = New DevExpress.XtraBars.PopupMenu()
        Me.rpgVslAccount = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.dbdController = New DevExpress.XtraBars.DefaultBarAndDockingController()
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ledDepartmentRep, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ledRankRep, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ledCategoryRep, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ledDueHours, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ledUnitRep, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ledDueDays, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ledPeriodRep, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateDueEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateDueEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainPanel.SuspendLayout()
        CType(Me.pmMainMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pmListMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dbdController.Controller, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl
        '
        Me.RibbonControl.AllowMinimizeRibbon = False
        Me.RibbonControl.ApplicationButtonText = Nothing
        Me.RibbonControl.ApplicationIcon = CType(resources.GetObject("RibbonControl.ApplicationIcon"), System.Drawing.Bitmap)
        Me.RibbonControl.AutoSizeItems = True
        Me.RibbonControl.ExpandCollapseItem.Id = 0
        Me.RibbonControl.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl.ExpandCollapseItem, Me.bbAdd, Me.bbSave, Me.bbDelete, Me.RANK, Me.DEPARTMENT, Me.bbSaveLayout, Me.cmdHelp, Me.SECUSERS, Me.SECGROUPS, Me.cmdChangePassword, Me.bbResetPassword, Me.cmdChangeUser, Me.SWITCHBOARD, Me.COMPANYINFO, Me.LICENSEINFO, Me.bbPreview, Me.bbResetLayout, Me.BACKUPRESTORE, Me.bbBackUp, Me.bbRestore, Me.VERSIONUPDATE, Me.bbUpdate, Me.cmdNotification, Me.bbExport, Me.bbEdit, Me.bbSelectAll, Me.bbDeselect, Me.SETTINGS, Me.PMSREP, Me.ARCHIVEDATA, Me.RECOVERARCHIVE, Me.UNITS, Me.PART, Me.CATEGORY, Me.COUNTER, Me.VLOCATION, Me.ledDepartment, Me.WORKDONE, Me.ledRank, Me.ledCategory, Me.INTERVAL, Me.WORKDUE, Me.MAINTENANCE, Me.COMPONENT, Me.NONCONFORM, Me.bbNC, Me.bbUpdateNC, Me.NCMEASURES, Me.EXPORTADMIN, Me.IMPORTDATA, Me.bbWOMaintenance, Me.RUNNINGHOURS, Me.txtDueHours, Me.EXPMAINTENANCE, Me.VESSELINFO, Me.bbCopy, Me.ledMainUnits, Me.bbCopyMaintenance, Me.bbShowComponents, Me.txtDateDue, Me.bbAddPlannedDate, Me.ledPeriod, Me.bbCondition, Me.PARTPURCHASE, Me.bbViewImage, Me.STORAGE, Me.MDOCVIEWER, Me.WDOCVIEWER, Me.bbPaste, Me.bbImportFromFile, Me.VENDOR, Me.MAKER, Me.bbCritical, Me.bbFlatView, Me.bbUserPreferences, Me.bbShowAllMaintenance, Me.IDOCVIEWER, Me.EXPDOCUMENTS, Me.AUDIT, Me.REFRESH, Me.cmdReportPreview, Me.chkAuditWithDetails})
        Me.RibbonControl.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl.MaxItemId = 278
        Me.RibbonControl.Name = "RibbonControl"
        Me.RibbonControl.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.rpMaintenance, Me.rpInventory, Me.rpDocViewer, Me.rpAdmin, Me.rpTools, Me.rpSecurity, Me.rpAudit, Me.rpReports, Me.rpHome})
        Me.RibbonControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.ledDepartmentRep, Me.ledRankRep, Me.ledCategoryRep, Me.ledDueDays, Me.ledDueHours, Me.ledUnitRep, Me.DateDueEdit, Me.ledPeriodRep})
        Me.RibbonControl.ShowToolbarCustomizeItem = False
        Me.RibbonControl.Size = New System.Drawing.Size(1179, 143)
        Me.RibbonControl.StatusBar = Me.RibbonStatusBar
        Me.RibbonControl.Toolbar.ItemLinks.Add(Me.bbSaveLayout)
        Me.RibbonControl.Toolbar.ItemLinks.Add(Me.bbResetLayout)
        Me.RibbonControl.Toolbar.ItemLinks.Add(Me.bbUserPreferences)
        Me.RibbonControl.Toolbar.ItemLinks.Add(Me.cmdChangePassword, True)
        Me.RibbonControl.Toolbar.ItemLinks.Add(Me.cmdChangeUser)
        Me.RibbonControl.Toolbar.ItemLinks.Add(Me.cmdNotification, True)
        Me.RibbonControl.Toolbar.ItemLinks.Add(Me.cmdHelp)
        Me.RibbonControl.Toolbar.ShowCustomizeItem = False
        '
        'bbAdd
        '
        Me.bbAdd.Caption = "Add"
        Me.bbAdd.Enabled = False
        Me.bbAdd.Glyph = CType(resources.GetObject("bbAdd.Glyph"), System.Drawing.Image)
        Me.bbAdd.Id = 11
        Me.bbAdd.ItemShortcut = New DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N))
        Me.bbAdd.LargeGlyph = CType(resources.GetObject("bbAdd.LargeGlyph"), System.Drawing.Image)
        Me.bbAdd.LargeWidth = 65
        Me.bbAdd.Name = "bbAdd"
        '
        'bbSave
        '
        Me.bbSave.Caption = "Save"
        Me.bbSave.Enabled = False
        Me.bbSave.Glyph = CType(resources.GetObject("bbSave.Glyph"), System.Drawing.Image)
        Me.bbSave.Id = 9
        Me.bbSave.ItemShortcut = New DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S))
        Me.bbSave.LargeGlyph = CType(resources.GetObject("bbSave.LargeGlyph"), System.Drawing.Image)
        Me.bbSave.LargeWidth = 65
        Me.bbSave.Name = "bbSave"
        '
        'bbDelete
        '
        Me.bbDelete.Caption = "Delete"
        Me.bbDelete.Enabled = False
        Me.bbDelete.Glyph = CType(resources.GetObject("bbDelete.Glyph"), System.Drawing.Image)
        Me.bbDelete.Id = 10
        Me.bbDelete.ItemShortcut = New DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D))
        Me.bbDelete.LargeGlyph = CType(resources.GetObject("bbDelete.LargeGlyph"), System.Drawing.Image)
        Me.bbDelete.LargeWidth = 65
        Me.bbDelete.Name = "bbDelete"
        '
        'RANK
        '
        Me.RANK.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.RANK.Caption = "Rank"
        Me.RANK.GroupIndex = 5
        Me.RANK.Id = 16
        Me.RANK.LargeGlyph = CType(resources.GetObject("RANK.LargeGlyph"), System.Drawing.Image)
        Me.RANK.LargeWidth = 55
        Me.RANK.Name = "RANK"
        Me.RANK.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'DEPARTMENT
        '
        Me.DEPARTMENT.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.DEPARTMENT.Caption = "Department"
        Me.DEPARTMENT.GroupIndex = 5
        Me.DEPARTMENT.Id = 17
        Me.DEPARTMENT.LargeGlyph = CType(resources.GetObject("DEPARTMENT.LargeGlyph"), System.Drawing.Image)
        Me.DEPARTMENT.Name = "DEPARTMENT"
        Me.DEPARTMENT.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'bbSaveLayout
        '
        Me.bbSaveLayout.Caption = "Save Layout"
        Me.bbSaveLayout.Glyph = CType(resources.GetObject("bbSaveLayout.Glyph"), System.Drawing.Image)
        Me.bbSaveLayout.Id = 27
        Me.bbSaveLayout.Name = "bbSaveLayout"
        '
        'cmdHelp
        '
        Me.cmdHelp.Caption = "Help"
        Me.cmdHelp.Glyph = CType(resources.GetObject("cmdHelp.Glyph"), System.Drawing.Image)
        Me.cmdHelp.Id = 28
        Me.cmdHelp.ItemShortcut = New DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F1)
        Me.cmdHelp.Name = "cmdHelp"
        '
        'SECUSERS
        '
        Me.SECUSERS.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.SECUSERS.Caption = "Users"
        Me.SECUSERS.GroupIndex = 6
        Me.SECUSERS.Id = 32
        Me.SECUSERS.LargeGlyph = CType(resources.GetObject("SECUSERS.LargeGlyph"), System.Drawing.Image)
        Me.SECUSERS.LargeWidth = 55
        Me.SECUSERS.Name = "SECUSERS"
        Me.SECUSERS.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'SECGROUPS
        '
        Me.SECGROUPS.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.SECGROUPS.Caption = "Groups"
        Me.SECGROUPS.Down = True
        Me.SECGROUPS.GroupIndex = 6
        Me.SECGROUPS.Id = 33
        Me.SECGROUPS.LargeGlyph = CType(resources.GetObject("SECGROUPS.LargeGlyph"), System.Drawing.Image)
        Me.SECGROUPS.Name = "SECGROUPS"
        Me.SECGROUPS.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'cmdChangePassword
        '
        Me.cmdChangePassword.Caption = "Change Password"
        Me.cmdChangePassword.Glyph = CType(resources.GetObject("cmdChangePassword.Glyph"), System.Drawing.Image)
        Me.cmdChangePassword.Id = 34
        Me.cmdChangePassword.Name = "cmdChangePassword"
        '
        'bbResetPassword
        '
        Me.bbResetPassword.Caption = "Reset Password"
        Me.bbResetPassword.Id = 35
        Me.bbResetPassword.LargeGlyph = CType(resources.GetObject("bbResetPassword.LargeGlyph"), System.Drawing.Image)
        Me.bbResetPassword.Name = "bbResetPassword"
        '
        'cmdChangeUser
        '
        Me.cmdChangeUser.Caption = "Change User"
        Me.cmdChangeUser.Glyph = CType(resources.GetObject("cmdChangeUser.Glyph"), System.Drawing.Image)
        Me.cmdChangeUser.Id = 36
        Me.cmdChangeUser.Name = "cmdChangeUser"
        '
        'SWITCHBOARD
        '
        Me.SWITCHBOARD.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.SWITCHBOARD.Caption = "About"
        Me.SWITCHBOARD.Down = True
        Me.SWITCHBOARD.GroupIndex = 1000
        Me.SWITCHBOARD.Id = 39
        Me.SWITCHBOARD.LargeGlyph = CType(resources.GetObject("SWITCHBOARD.LargeGlyph"), System.Drawing.Image)
        Me.SWITCHBOARD.LargeWidth = 55
        Me.SWITCHBOARD.Name = "SWITCHBOARD"
        '
        'COMPANYINFO
        '
        Me.COMPANYINFO.Caption = "Company Information"
        Me.COMPANYINFO.GroupIndex = 1026
        Me.COMPANYINFO.Id = 40
        Me.COMPANYINFO.LargeGlyph = CType(resources.GetObject("COMPANYINFO.LargeGlyph"), System.Drawing.Image)
        Me.COMPANYINFO.Name = "COMPANYINFO"
        Me.COMPANYINFO.Tag = "2"
        '
        'LICENSEINFO
        '
        Me.LICENSEINFO.Caption = "License Information"
        Me.LICENSEINFO.GroupIndex = 1026
        Me.LICENSEINFO.Id = 41
        Me.LICENSEINFO.LargeGlyph = CType(resources.GetObject("LICENSEINFO.LargeGlyph"), System.Drawing.Image)
        Me.LICENSEINFO.Name = "LICENSEINFO"
        Me.LICENSEINFO.Tag = "2"
        '
        'bbPreview
        '
        Me.bbPreview.Caption = "Preview"
        Me.bbPreview.Glyph = CType(resources.GetObject("bbPreview.Glyph"), System.Drawing.Image)
        Me.bbPreview.Id = 45
        Me.bbPreview.LargeGlyph = CType(resources.GetObject("bbPreview.LargeGlyph"), System.Drawing.Image)
        Me.bbPreview.Name = "bbPreview"
        '
        'bbResetLayout
        '
        Me.bbResetLayout.Caption = "Reset Layout"
        Me.bbResetLayout.Glyph = CType(resources.GetObject("bbResetLayout.Glyph"), System.Drawing.Image)
        Me.bbResetLayout.Id = 47
        Me.bbResetLayout.Name = "bbResetLayout"
        '
        'BACKUPRESTORE
        '
        Me.BACKUPRESTORE.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.BACKUPRESTORE.Caption = "Back up and Restore"
        Me.BACKUPRESTORE.Down = True
        Me.BACKUPRESTORE.GroupIndex = 4
        Me.BACKUPRESTORE.Id = 77
        Me.BACKUPRESTORE.LargeGlyph = CType(resources.GetObject("BACKUPRESTORE.LargeGlyph"), System.Drawing.Image)
        Me.BACKUPRESTORE.Name = "BACKUPRESTORE"
        Me.BACKUPRESTORE.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'bbBackUp
        '
        Me.bbBackUp.Caption = "Backup"
        Me.bbBackUp.Glyph = CType(resources.GetObject("bbBackUp.Glyph"), System.Drawing.Image)
        Me.bbBackUp.Id = 78
        Me.bbBackUp.LargeGlyph = CType(resources.GetObject("bbBackUp.LargeGlyph"), System.Drawing.Image)
        Me.bbBackUp.Name = "bbBackUp"
        '
        'bbRestore
        '
        Me.bbRestore.Caption = "Restore"
        Me.bbRestore.Glyph = CType(resources.GetObject("bbRestore.Glyph"), System.Drawing.Image)
        Me.bbRestore.Id = 79
        Me.bbRestore.LargeGlyph = CType(resources.GetObject("bbRestore.LargeGlyph"), System.Drawing.Image)
        Me.bbRestore.Name = "bbRestore"
        '
        'VERSIONUPDATE
        '
        Me.VERSIONUPDATE.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.VERSIONUPDATE.Caption = "Program Version"
        Me.VERSIONUPDATE.GroupIndex = 4
        Me.VERSIONUPDATE.Id = 80
        Me.VERSIONUPDATE.LargeGlyph = CType(resources.GetObject("VERSIONUPDATE.LargeGlyph"), System.Drawing.Image)
        Me.VERSIONUPDATE.Name = "VERSIONUPDATE"
        Me.VERSIONUPDATE.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'bbUpdate
        '
        Me.bbUpdate.Caption = "Update PMS"
        Me.bbUpdate.Glyph = CType(resources.GetObject("bbUpdate.Glyph"), System.Drawing.Image)
        Me.bbUpdate.Id = 81
        Me.bbUpdate.LargeGlyph = CType(resources.GetObject("bbUpdate.LargeGlyph"), System.Drawing.Image)
        Me.bbUpdate.Name = "bbUpdate"
        '
        'cmdNotification
        '
        Me.cmdNotification.Caption = "View Notifications"
        Me.cmdNotification.Glyph = CType(resources.GetObject("cmdNotification.Glyph"), System.Drawing.Image)
        Me.cmdNotification.Id = 87
        Me.cmdNotification.Name = "cmdNotification"
        Me.cmdNotification.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'bbExport
        '
        Me.bbExport.Caption = "Execute Export"
        Me.bbExport.Id = 92
        Me.bbExport.LargeGlyph = CType(resources.GetObject("bbExport.LargeGlyph"), System.Drawing.Image)
        Me.bbExport.LargeWidth = 55
        Me.bbExport.Name = "bbExport"
        '
        'bbEdit
        '
        Me.bbEdit.Caption = "Edit"
        Me.bbEdit.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.bbEdit.Glyph = CType(resources.GetObject("bbEdit.Glyph"), System.Drawing.Image)
        Me.bbEdit.Id = 103
        Me.bbEdit.LargeGlyph = CType(resources.GetObject("bbEdit.LargeGlyph"), System.Drawing.Image)
        Me.bbEdit.Name = "bbEdit"
        '
        'bbSelectAll
        '
        Me.bbSelectAll.Caption = "Select All"
        Me.bbSelectAll.Id = 106
        Me.bbSelectAll.LargeGlyph = CType(resources.GetObject("bbSelectAll.LargeGlyph"), System.Drawing.Image)
        Me.bbSelectAll.LargeWidth = 55
        Me.bbSelectAll.Name = "bbSelectAll"
        '
        'bbDeselect
        '
        Me.bbDeselect.Caption = "Deselect All"
        Me.bbDeselect.Id = 107
        Me.bbDeselect.LargeGlyph = CType(resources.GetObject("bbDeselect.LargeGlyph"), System.Drawing.Image)
        Me.bbDeselect.Name = "bbDeselect"
        '
        'SETTINGS
        '
        Me.SETTINGS.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.SETTINGS.Caption = "Settings"
        Me.SETTINGS.GroupIndex = 4
        Me.SETTINGS.Id = 113
        Me.SETTINGS.LargeGlyph = CType(resources.GetObject("SETTINGS.LargeGlyph"), System.Drawing.Image)
        Me.SETTINGS.Name = "SETTINGS"
        Me.SETTINGS.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'PMSREP
        '
        Me.PMSREP.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.PMSREP.Caption = "PMS Reports"
        Me.PMSREP.GroupIndex = 7
        Me.PMSREP.Id = 138
        Me.PMSREP.LargeGlyph = CType(resources.GetObject("PMSREP.LargeGlyph"), System.Drawing.Image)
        Me.PMSREP.Name = "PMSREP"
        Me.PMSREP.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'ARCHIVEDATA
        '
        Me.ARCHIVEDATA.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.ARCHIVEDATA.Caption = "Archive Data"
        Me.ARCHIVEDATA.Glyph = CType(resources.GetObject("ARCHIVEDATA.Glyph"), System.Drawing.Image)
        Me.ARCHIVEDATA.GroupIndex = 4
        Me.ARCHIVEDATA.Id = 157
        Me.ARCHIVEDATA.LargeGlyph = CType(resources.GetObject("ARCHIVEDATA.LargeGlyph"), System.Drawing.Image)
        Me.ARCHIVEDATA.LargeWidth = 55
        Me.ARCHIVEDATA.Name = "ARCHIVEDATA"
        '
        'RECOVERARCHIVE
        '
        Me.RECOVERARCHIVE.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.RECOVERARCHIVE.Caption = "Recover Data"
        Me.RECOVERARCHIVE.Glyph = CType(resources.GetObject("RECOVERARCHIVE.Glyph"), System.Drawing.Image)
        Me.RECOVERARCHIVE.GroupIndex = 4
        Me.RECOVERARCHIVE.Id = 158
        Me.RECOVERARCHIVE.LargeGlyph = CType(resources.GetObject("RECOVERARCHIVE.LargeGlyph"), System.Drawing.Image)
        Me.RECOVERARCHIVE.LargeWidth = 55
        Me.RECOVERARCHIVE.Name = "RECOVERARCHIVE"
        '
        'UNITS
        '
        Me.UNITS.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.UNITS.Caption = "Machines && Equipments"
        Me.UNITS.GroupIndex = 5
        Me.UNITS.Id = 160
        Me.UNITS.LargeGlyph = CType(resources.GetObject("UNITS.LargeGlyph"), System.Drawing.Image)
        Me.UNITS.Name = "UNITS"
        Me.UNITS.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'PART
        '
        Me.PART.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.PART.Caption = "Spare Parts"
        Me.PART.GroupIndex = 2
        Me.PART.Id = 161
        Me.PART.LargeGlyph = CType(resources.GetObject("PART.LargeGlyph"), System.Drawing.Image)
        Me.PART.LargeWidth = 60
        Me.PART.Name = "PART"
        Me.PART.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'CATEGORY
        '
        Me.CATEGORY.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.CATEGORY.Caption = "Category"
        Me.CATEGORY.GroupIndex = 5
        Me.CATEGORY.Id = 162
        Me.CATEGORY.LargeGlyph = CType(resources.GetObject("CATEGORY.LargeGlyph"), System.Drawing.Image)
        Me.CATEGORY.Name = "CATEGORY"
        Me.CATEGORY.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'COUNTER
        '
        Me.COUNTER.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.COUNTER.Caption = "Counter"
        Me.COUNTER.GroupIndex = 5
        Me.COUNTER.Id = 163
        Me.COUNTER.LargeGlyph = CType(resources.GetObject("COUNTER.LargeGlyph"), System.Drawing.Image)
        Me.COUNTER.Name = "COUNTER"
        Me.COUNTER.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'VLOCATION
        '
        Me.VLOCATION.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.VLOCATION.Caption = "Location"
        Me.VLOCATION.GroupIndex = 5
        Me.VLOCATION.Id = 164
        Me.VLOCATION.LargeGlyph = CType(resources.GetObject("VLOCATION.LargeGlyph"), System.Drawing.Image)
        Me.VLOCATION.Name = "VLOCATION"
        Me.VLOCATION.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'ledDepartment
        '
        Me.ledDepartment.Caption = "Department"
        Me.ledDepartment.Edit = Me.ledDepartmentRep
        Me.ledDepartment.EditWidth = 150
        Me.ledDepartment.Id = 155
        Me.ledDepartment.Name = "ledDepartment"
        '
        'ledDepartmentRep
        '
        Me.ledDepartmentRep.AutoHeight = False
        Me.ledDepartmentRep.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Close)})
        Me.ledDepartmentRep.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("DeptCode", "Name1", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Department", "Name2")})
        Me.ledDepartmentRep.DisplayMember = "Department"
        Me.ledDepartmentRep.DropDownRows = 10
        Me.ledDepartmentRep.Name = "ledDepartmentRep"
        Me.ledDepartmentRep.NullText = ""
        Me.ledDepartmentRep.ShowFooter = False
        Me.ledDepartmentRep.ShowHeader = False
        Me.ledDepartmentRep.ValueMember = "DeptCode"
        '
        'WORKDONE
        '
        Me.WORKDONE.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.WORKDONE.Caption = "Work Done"
        Me.WORKDONE.GroupIndex = 1
        Me.WORKDONE.Id = 166
        Me.WORKDONE.LargeGlyph = CType(resources.GetObject("WORKDONE.LargeGlyph"), System.Drawing.Image)
        Me.WORKDONE.Name = "WORKDONE"
        Me.WORKDONE.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'ledRank
        '
        Me.ledRank.Caption = "Rank           "
        Me.ledRank.Edit = Me.ledRankRep
        Me.ledRank.EditWidth = 150
        Me.ledRank.Id = 168
        Me.ledRank.Name = "ledRank"
        '
        'ledRankRep
        '
        Me.ledRankRep.AutoHeight = False
        Me.ledRankRep.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.ledRankRep.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Close)})
        Me.ledRankRep.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("RankCode", "Name1", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Abbrv", 60, "Name33"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("RankDesc", 250, "Name2")})
        Me.ledRankRep.DisplayMember = "Abbrv"
        Me.ledRankRep.DropDownRows = 10
        Me.ledRankRep.Name = "ledRankRep"
        Me.ledRankRep.NullText = ""
        Me.ledRankRep.ShowFooter = False
        Me.ledRankRep.ShowHeader = False
        Me.ledRankRep.ValueMember = "RankCode"
        '
        'ledCategory
        '
        Me.ledCategory.Caption = "Category    "
        Me.ledCategory.Edit = Me.ledCategoryRep
        Me.ledCategory.EditWidth = 150
        Me.ledCategory.Id = 169
        Me.ledCategory.Name = "ledCategory"
        '
        'ledCategoryRep
        '
        Me.ledCategoryRep.AutoHeight = False
        Me.ledCategoryRep.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Close)})
        Me.ledCategoryRep.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CatCode", "Name1", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Category", "Name2")})
        Me.ledCategoryRep.DisplayMember = "Category"
        Me.ledCategoryRep.DropDownRows = 10
        Me.ledCategoryRep.Name = "ledCategoryRep"
        Me.ledCategoryRep.NullText = ""
        Me.ledCategoryRep.ShowFooter = False
        Me.ledCategoryRep.ShowHeader = False
        Me.ledCategoryRep.ValueMember = "CatCode"
        '
        'INTERVAL
        '
        Me.INTERVAL.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.INTERVAL.Caption = "Alerts"
        Me.INTERVAL.GroupIndex = 5
        Me.INTERVAL.Id = 170
        Me.INTERVAL.LargeGlyph = CType(resources.GetObject("INTERVAL.LargeGlyph"), System.Drawing.Image)
        Me.INTERVAL.LargeWidth = 55
        Me.INTERVAL.Name = "INTERVAL"
        Me.INTERVAL.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'WORKDUE
        '
        Me.WORKDUE.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.WORKDUE.Caption = "Due Work"
        Me.WORKDUE.GroupIndex = 1
        Me.WORKDUE.Id = 171
        Me.WORKDUE.LargeGlyph = CType(resources.GetObject("WORKDUE.LargeGlyph"), System.Drawing.Image)
        Me.WORKDUE.Name = "WORKDUE"
        Me.WORKDUE.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'MAINTENANCE
        '
        Me.MAINTENANCE.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.MAINTENANCE.Caption = "Maintenance"
        Me.MAINTENANCE.GroupIndex = 5
        Me.MAINTENANCE.Id = 174
        Me.MAINTENANCE.LargeGlyph = CType(resources.GetObject("MAINTENANCE.LargeGlyph"), System.Drawing.Image)
        Me.MAINTENANCE.Name = "MAINTENANCE"
        Me.MAINTENANCE.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'COMPONENT
        '
        Me.COMPONENT.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.COMPONENT.Caption = "Component"
        Me.COMPONENT.GroupIndex = 5
        Me.COMPONENT.Id = 175
        Me.COMPONENT.LargeGlyph = CType(resources.GetObject("COMPONENT.LargeGlyph"), System.Drawing.Image)
        Me.COMPONENT.Name = "COMPONENT"
        Me.COMPONENT.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'NONCONFORM
        '
        Me.NONCONFORM.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.NONCONFORM.Caption = "Non Conformance"
        Me.NONCONFORM.GroupIndex = 1
        Me.NONCONFORM.Id = 179
        Me.NONCONFORM.LargeGlyph = CType(resources.GetObject("NONCONFORM.LargeGlyph"), System.Drawing.Image)
        Me.NONCONFORM.LargeWidth = 75
        Me.NONCONFORM.Name = "NONCONFORM"
        Me.NONCONFORM.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'bbNC
        '
        Me.bbNC.Caption = "Add/Edit NC"
        Me.bbNC.Glyph = CType(resources.GetObject("bbNC.Glyph"), System.Drawing.Image)
        Me.bbNC.Id = 180
        Me.bbNC.LargeGlyph = CType(resources.GetObject("bbNC.LargeGlyph"), System.Drawing.Image)
        Me.bbNC.Name = "bbNC"
        '
        'bbUpdateNC
        '
        Me.bbUpdateNC.Caption = "Close NC"
        Me.bbUpdateNC.Glyph = CType(resources.GetObject("bbUpdateNC.Glyph"), System.Drawing.Image)
        Me.bbUpdateNC.Id = 181
        Me.bbUpdateNC.LargeGlyph = CType(resources.GetObject("bbUpdateNC.LargeGlyph"), System.Drawing.Image)
        Me.bbUpdateNC.Name = "bbUpdateNC"
        '
        'NCMEASURES
        '
        Me.NCMEASURES.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.NCMEASURES.Caption = "Pending Measures"
        Me.NCMEASURES.GroupIndex = 1
        Me.NCMEASURES.Id = 182
        Me.NCMEASURES.LargeGlyph = CType(resources.GetObject("NCMEASURES.LargeGlyph"), System.Drawing.Image)
        Me.NCMEASURES.Name = "NCMEASURES"
        Me.NCMEASURES.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'EXPORTADMIN
        '
        Me.EXPORTADMIN.Caption = "Export Admin Data"
        Me.EXPORTADMIN.GroupIndex = 1024
        Me.EXPORTADMIN.Id = 183
        Me.EXPORTADMIN.LargeGlyph = CType(resources.GetObject("EXPORTADMIN.LargeGlyph"), System.Drawing.Image)
        Me.EXPORTADMIN.Name = "EXPORTADMIN"
        Me.EXPORTADMIN.Tag = "2"
        '
        'IMPORTDATA
        '
        Me.IMPORTDATA.Caption = "Import Data"
        Me.IMPORTDATA.GroupIndex = 1024
        Me.IMPORTDATA.Id = 184
        Me.IMPORTDATA.LargeGlyph = CType(resources.GetObject("IMPORTDATA.LargeGlyph"), System.Drawing.Image)
        Me.IMPORTDATA.Name = "IMPORTDATA"
        Me.IMPORTDATA.Tag = "2"
        '
        'bbWOMaintenance
        '
        Me.bbWOMaintenance.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.bbWOMaintenance.Caption = "Without Maintenance"
        Me.bbWOMaintenance.Id = 186
        Me.bbWOMaintenance.LargeGlyph = Global.PlannedMaintenance.My.Resources.Resources.rankDep_2
        Me.bbWOMaintenance.Name = "bbWOMaintenance"
        '
        'RUNNINGHOURS
        '
        Me.RUNNINGHOURS.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.RUNNINGHOURS.Caption = "Running Hours"
        Me.RUNNINGHOURS.GroupIndex = 1
        Me.RUNNINGHOURS.Id = 190
        Me.RUNNINGHOURS.LargeGlyph = CType(resources.GetObject("RUNNINGHOURS.LargeGlyph"), System.Drawing.Image)
        Me.RUNNINGHOURS.Name = "RUNNINGHOURS"
        Me.RUNNINGHOURS.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'txtDueHours
        '
        Me.txtDueHours.Caption = "Hours Before Due"
        Me.txtDueHours.Edit = Me.ledDueHours
        Me.txtDueHours.EditWidth = 130
        Me.txtDueHours.Id = 191
        Me.txtDueHours.Name = "txtDueHours"
        '
        'ledDueHours
        '
        Me.ledDueHours.Appearance.Options.UseTextOptions = True
        Me.ledDueHours.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ledDueHours.AutoHeight = False
        Me.ledDueHours.Name = "ledDueHours"
        Me.ledDueHours.NullText = "0"
        '
        'EXPMAINTENANCE
        '
        Me.EXPMAINTENANCE.Caption = "Export Maintenance"
        Me.EXPMAINTENANCE.GroupIndex = 1024
        Me.EXPMAINTENANCE.Id = 197
        Me.EXPMAINTENANCE.LargeGlyph = CType(resources.GetObject("EXPMAINTENANCE.LargeGlyph"), System.Drawing.Image)
        Me.EXPMAINTENANCE.Name = "EXPMAINTENANCE"
        Me.EXPMAINTENANCE.Tag = "2"
        '
        'VESSELINFO
        '
        Me.VESSELINFO.Caption = "Vessel Information"
        Me.VESSELINFO.GroupIndex = 1026
        Me.VESSELINFO.Id = 198
        Me.VESSELINFO.LargeGlyph = CType(resources.GetObject("VESSELINFO.LargeGlyph"), System.Drawing.Image)
        Me.VESSELINFO.Name = "VESSELINFO"
        Me.VESSELINFO.Tag = "2"
        Me.VESSELINFO.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'bbCopy
        '
        Me.bbCopy.Caption = "Duplicate" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Component"
        Me.bbCopy.Glyph = CType(resources.GetObject("bbCopy.Glyph"), System.Drawing.Image)
        Me.bbCopy.Id = 199
        Me.bbCopy.LargeGlyph = CType(resources.GetObject("bbCopy.LargeGlyph"), System.Drawing.Image)
        Me.bbCopy.Name = "bbCopy"
        '
        'ledMainUnits
        '
        Me.ledMainUnits.Caption = "Machine &" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Equipment"
        Me.ledMainUnits.Edit = Me.ledUnitRep
        Me.ledMainUnits.EditWidth = 150
        Me.ledMainUnits.Id = 206
        Me.ledMainUnits.Name = "ledMainUnits"
        '
        'ledUnitRep
        '
        Me.ledUnitRep.AutoHeight = False
        Me.ledUnitRep.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Close)})
        Me.ledUnitRep.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("SortCode", "Name3", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("UnitCode", "UnitCode", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("UnitDesc", "UnitDesc")})
        Me.ledUnitRep.DisplayMember = "UnitDesc"
        Me.ledUnitRep.DropDownRows = 10
        Me.ledUnitRep.Name = "ledUnitRep"
        Me.ledUnitRep.NullText = ""
        Me.ledUnitRep.ShowFooter = False
        Me.ledUnitRep.ShowHeader = False
        Me.ledUnitRep.ValueMember = "UnitCode"
        '
        'bbCopyMaintenance
        '
        Me.bbCopyMaintenance.Caption = "Copy" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Maintenance"
        Me.bbCopyMaintenance.Glyph = CType(resources.GetObject("bbCopyMaintenance.Glyph"), System.Drawing.Image)
        Me.bbCopyMaintenance.Id = 209
        Me.bbCopyMaintenance.LargeGlyph = CType(resources.GetObject("bbCopyMaintenance.LargeGlyph"), System.Drawing.Image)
        Me.bbCopyMaintenance.Name = "bbCopyMaintenance"
        '
        'bbShowComponents
        '
        Me.bbShowComponents.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.bbShowComponents.Caption = "Show" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Components"
        Me.bbShowComponents.Id = 211
        Me.bbShowComponents.LargeGlyph = CType(resources.GetObject("bbShowComponents.LargeGlyph"), System.Drawing.Image)
        Me.bbShowComponents.Name = "bbShowComponents"
        '
        'txtDateDue
        '
        Me.txtDateDue.Caption = "Days Before Due"
        Me.txtDateDue.Edit = Me.ledDueDays
        Me.txtDateDue.EditValue = CType(30, Short)
        Me.txtDateDue.EditWidth = 130
        Me.txtDateDue.Id = 212
        Me.txtDateDue.Name = "txtDateDue"
        '
        'ledDueDays
        '
        Me.ledDueDays.Appearance.Options.UseTextOptions = True
        Me.ledDueDays.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ledDueDays.AutoHeight = False
        Me.ledDueDays.Mask.EditMask = "f0"
        Me.ledDueDays.Name = "ledDueDays"
        Me.ledDueDays.NullText = "0"
        '
        'bbAddPlannedDate
        '
        Me.bbAddPlannedDate.Caption = "Planned Due Date"
        Me.bbAddPlannedDate.Glyph = CType(resources.GetObject("bbAddPlannedDate.Glyph"), System.Drawing.Image)
        Me.bbAddPlannedDate.Id = 213
        Me.bbAddPlannedDate.LargeGlyph = CType(resources.GetObject("bbAddPlannedDate.LargeGlyph"), System.Drawing.Image)
        Me.bbAddPlannedDate.Name = "bbAddPlannedDate"
        '
        'ledPeriod
        '
        Me.ledPeriod.Caption = "Period"
        Me.ledPeriod.Edit = Me.ledPeriodRep
        Me.ledPeriod.EditWidth = 130
        Me.ledPeriod.Id = 214
        Me.ledPeriod.Name = "ledPeriod"
        '
        'ledPeriodRep
        '
        Me.ledPeriodRep.AutoHeight = False
        Me.ledPeriodRep.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Close)})
        Me.ledPeriodRep.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PeriodDesc", "PeriodDesc"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Period", "Period", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default])})
        Me.ledPeriodRep.DisplayMember = "PeriodDesc"
        Me.ledPeriodRep.DropDownRows = 12
        Me.ledPeriodRep.Name = "ledPeriodRep"
        Me.ledPeriodRep.NullText = ""
        Me.ledPeriodRep.ShowFooter = False
        Me.ledPeriodRep.ShowHeader = False
        Me.ledPeriodRep.ValueMember = "Period"
        '
        'bbCondition
        '
        Me.bbCondition.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.bbCondition.Caption = "Condition Based"
        Me.bbCondition.Id = 217
        Me.bbCondition.LargeGlyph = CType(resources.GetObject("bbCondition.LargeGlyph"), System.Drawing.Image)
        Me.bbCondition.Name = "bbCondition"
        '
        'PARTPURCHASE
        '
        Me.PARTPURCHASE.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.PARTPURCHASE.Caption = "Purchases"
        Me.PARTPURCHASE.GroupIndex = 2
        Me.PARTPURCHASE.Id = 221
        Me.PARTPURCHASE.LargeGlyph = CType(resources.GetObject("PARTPURCHASE.LargeGlyph"), System.Drawing.Image)
        Me.PARTPURCHASE.Name = "PARTPURCHASE"
        '
        'bbViewImage
        '
        Me.bbViewImage.Caption = "View Image"
        Me.bbViewImage.Id = 222
        Me.bbViewImage.LargeGlyph = CType(resources.GetObject("bbViewImage.LargeGlyph"), System.Drawing.Image)
        Me.bbViewImage.Name = "bbViewImage"
        '
        'STORAGE
        '
        Me.STORAGE.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.STORAGE.Caption = "Storage"
        Me.STORAGE.GroupIndex = 5
        Me.STORAGE.Id = 223
        Me.STORAGE.LargeGlyph = CType(resources.GetObject("STORAGE.LargeGlyph"), System.Drawing.Image)
        Me.STORAGE.Name = "STORAGE"
        '
        'MDOCVIEWER
        '
        Me.MDOCVIEWER.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.MDOCVIEWER.Caption = "Planned Maintenance"
        Me.MDOCVIEWER.GroupIndex = 3
        Me.MDOCVIEWER.Id = 224
        Me.MDOCVIEWER.LargeGlyph = CType(resources.GetObject("MDOCVIEWER.LargeGlyph"), System.Drawing.Image)
        Me.MDOCVIEWER.Name = "MDOCVIEWER"
        '
        'WDOCVIEWER
        '
        Me.WDOCVIEWER.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.WDOCVIEWER.Caption = "Completed Maintenance"
        Me.WDOCVIEWER.GroupIndex = 3
        Me.WDOCVIEWER.Id = 225
        Me.WDOCVIEWER.LargeGlyph = CType(resources.GetObject("WDOCVIEWER.LargeGlyph"), System.Drawing.Image)
        Me.WDOCVIEWER.Name = "WDOCVIEWER"
        '
        'bbPaste
        '
        Me.bbPaste.Caption = "Paste"
        Me.bbPaste.Id = 231
        Me.bbPaste.LargeGlyph = CType(resources.GetObject("bbPaste.LargeGlyph"), System.Drawing.Image)
        Me.bbPaste.Name = "bbPaste"
        '
        'bbImportFromFile
        '
        Me.bbImportFromFile.Caption = "Import From File"
        Me.bbImportFromFile.Id = 233
        Me.bbImportFromFile.LargeGlyph = CType(resources.GetObject("bbImportFromFile.LargeGlyph"), System.Drawing.Image)
        Me.bbImportFromFile.Name = "bbImportFromFile"
        '
        'VENDOR
        '
        Me.VENDOR.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.VENDOR.Caption = "Vendor"
        Me.VENDOR.GroupIndex = 5
        Me.VENDOR.Id = 235
        Me.VENDOR.LargeGlyph = CType(resources.GetObject("VENDOR.LargeGlyph"), System.Drawing.Image)
        Me.VENDOR.Name = "VENDOR"
        '
        'MAKER
        '
        Me.MAKER.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.MAKER.Caption = "Maker"
        Me.MAKER.GroupIndex = 5
        Me.MAKER.Id = 236
        Me.MAKER.LargeGlyph = CType(resources.GetObject("MAKER.LargeGlyph"), System.Drawing.Image)
        Me.MAKER.LargeWidth = 60
        Me.MAKER.Name = "MAKER"
        '
        'bbCritical
        '
        Me.bbCritical.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.bbCritical.Caption = "Critical"
        Me.bbCritical.Glyph = CType(resources.GetObject("bbCritical.Glyph"), System.Drawing.Image)
        Me.bbCritical.Id = 246
        Me.bbCritical.LargeGlyph = CType(resources.GetObject("bbCritical.LargeGlyph"), System.Drawing.Image)
        Me.bbCritical.Name = "bbCritical"
        '
        'bbFlatView
        '
        Me.bbFlatView.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.bbFlatView.Caption = "Flat View"
        Me.bbFlatView.Glyph = CType(resources.GetObject("bbFlatView.Glyph"), System.Drawing.Image)
        Me.bbFlatView.Id = 247
        Me.bbFlatView.LargeGlyph = CType(resources.GetObject("bbFlatView.LargeGlyph"), System.Drawing.Image)
        Me.bbFlatView.Name = "bbFlatView"
        '
        'bbUserPreferences
        '
        Me.bbUserPreferences.Caption = "User Preferences"
        Me.bbUserPreferences.Glyph = CType(resources.GetObject("bbUserPreferences.Glyph"), System.Drawing.Image)
        Me.bbUserPreferences.Id = 248
        Me.bbUserPreferences.Name = "bbUserPreferences"
        '
        'bbShowAllMaintenance
        '
        Me.bbShowAllMaintenance.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.bbShowAllMaintenance.Caption = "Show All Maintenance"
        Me.bbShowAllMaintenance.Id = 257
        Me.bbShowAllMaintenance.LargeGlyph = CType(resources.GetObject("bbShowAllMaintenance.LargeGlyph"), System.Drawing.Image)
        Me.bbShowAllMaintenance.Name = "bbShowAllMaintenance"
        '
        'IDOCVIEWER
        '
        Me.IDOCVIEWER.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.IDOCVIEWER.Caption = "Inventory"
        Me.IDOCVIEWER.GroupIndex = 3
        Me.IDOCVIEWER.Id = 260
        Me.IDOCVIEWER.LargeGlyph = CType(resources.GetObject("IDOCVIEWER.LargeGlyph"), System.Drawing.Image)
        Me.IDOCVIEWER.Name = "IDOCVIEWER"
        '
        'EXPDOCUMENTS
        '
        Me.EXPDOCUMENTS.Caption = "Export Documents"
        Me.EXPDOCUMENTS.Id = 271
        Me.EXPDOCUMENTS.LargeGlyph = CType(resources.GetObject("EXPDOCUMENTS.LargeGlyph"), System.Drawing.Image)
        Me.EXPDOCUMENTS.Name = "EXPDOCUMENTS"
        '
        'AUDIT
        '
        Me.AUDIT.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.AUDIT.Caption = "Audit"
        Me.AUDIT.Down = True
        Me.AUDIT.Glyph = CType(resources.GetObject("AUDIT.Glyph"), System.Drawing.Image)
        Me.AUDIT.GroupIndex = 9
        Me.AUDIT.Id = 272
        Me.AUDIT.LargeGlyph = CType(resources.GetObject("AUDIT.LargeGlyph"), System.Drawing.Image)
        Me.AUDIT.Name = "AUDIT"
        Me.AUDIT.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'REFRESH
        '
        Me.REFRESH.Caption = "Refresh"
        Me.REFRESH.Glyph = CType(resources.GetObject("REFRESH.Glyph"), System.Drawing.Image)
        Me.REFRESH.Id = 274
        Me.REFRESH.LargeGlyph = CType(resources.GetObject("REFRESH.LargeGlyph"), System.Drawing.Image)
        Me.REFRESH.Name = "REFRESH"
        '
        'cmdReportPreview
        '
        Me.cmdReportPreview.Caption = "View Report"
        Me.cmdReportPreview.Glyph = CType(resources.GetObject("cmdReportPreview.Glyph"), System.Drawing.Image)
        Me.cmdReportPreview.Id = 275
        Me.cmdReportPreview.LargeGlyph = CType(resources.GetObject("cmdReportPreview.LargeGlyph"), System.Drawing.Image)
        Me.cmdReportPreview.Name = "cmdReportPreview"
        '
        'chkAuditWithDetails
        '
        Me.chkAuditWithDetails.Caption = "With Details"
        Me.chkAuditWithDetails.CheckBoxVisibility = DevExpress.XtraBars.CheckBoxVisibility.AfterText
        Me.chkAuditWithDetails.Id = 276
        Me.chkAuditWithDetails.Name = "chkAuditWithDetails"
        '
        'rpMaintenance
        '
        Me.rpMaintenance.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgMaintenance, Me.rpgMaintenanceEditingOptions, Me.rpgMaintenanceViewingOptions, Me.rpgMachineryPrintingOptions})
        Me.rpMaintenance.Name = "rpMaintenance"
        Me.rpMaintenance.Text = "Maintenance"
        '
        'rpgMaintenance
        '
        Me.rpgMaintenance.ItemLinks.Add(Me.WORKDUE)
        Me.rpgMaintenance.ItemLinks.Add(Me.WORKDONE)
        Me.rpgMaintenance.ItemLinks.Add(Me.RUNNINGHOURS)
        Me.rpgMaintenance.ItemLinks.Add(Me.NONCONFORM)
        Me.rpgMaintenance.ItemLinks.Add(Me.NCMEASURES)
        Me.rpgMaintenance.Name = "rpgMaintenance"
        Me.rpgMaintenance.ShowCaptionButton = False
        Me.rpgMaintenance.Tag = "1"
        Me.rpgMaintenance.Text = "Maintenance Options"
        '
        'rpgMaintenanceEditingOptions
        '
        Me.rpgMaintenanceEditingOptions.ItemLinks.Add(Me.bbAdd)
        Me.rpgMaintenanceEditingOptions.ItemLinks.Add(Me.bbEdit)
        Me.rpgMaintenanceEditingOptions.ItemLinks.Add(Me.bbSave)
        Me.rpgMaintenanceEditingOptions.ItemLinks.Add(Me.bbDelete)
        Me.rpgMaintenanceEditingOptions.ItemLinks.Add(Me.bbNC)
        Me.rpgMaintenanceEditingOptions.ItemLinks.Add(Me.bbUpdateNC)
        Me.rpgMaintenanceEditingOptions.ItemLinks.Add(Me.bbAddPlannedDate)
        Me.rpgMaintenanceEditingOptions.ItemLinks.Add(Me.bbViewImage)
        Me.rpgMaintenanceEditingOptions.Name = "rpgMaintenanceEditingOptions"
        Me.rpgMaintenanceEditingOptions.ShowCaptionButton = False
        Me.rpgMaintenanceEditingOptions.Tag = "2"
        Me.rpgMaintenanceEditingOptions.Text = "Maintenance Editing Options"
        '
        'rpgMaintenanceViewingOptions
        '
        Me.rpgMaintenanceViewingOptions.ItemLinks.Add(Me.bbCondition)
        Me.rpgMaintenanceViewingOptions.ItemLinks.Add(Me.txtDateDue, True)
        Me.rpgMaintenanceViewingOptions.ItemLinks.Add(Me.txtDueHours)
        Me.rpgMaintenanceViewingOptions.ItemLinks.Add(Me.ledPeriod)
        Me.rpgMaintenanceViewingOptions.ItemLinks.Add(Me.ledRank)
        Me.rpgMaintenanceViewingOptions.ItemLinks.Add(Me.ledDepartment)
        Me.rpgMaintenanceViewingOptions.ItemLinks.Add(Me.ledCategory)
        Me.rpgMaintenanceViewingOptions.ItemLinks.Add(Me.bbCritical)
        Me.rpgMaintenanceViewingOptions.ItemLinks.Add(Me.bbShowAllMaintenance)
        Me.rpgMaintenanceViewingOptions.ItemLinks.Add(Me.bbFlatView, True)
        Me.rpgMaintenanceViewingOptions.Name = "rpgMaintenanceViewingOptions"
        Me.rpgMaintenanceViewingOptions.ShowCaptionButton = False
        Me.rpgMaintenanceViewingOptions.Text = "Maintenance Viewing Options"
        '
        'rpgMachineryPrintingOptions
        '
        Me.rpgMachineryPrintingOptions.ItemLinks.Add(Me.bbPreview)
        Me.rpgMachineryPrintingOptions.Name = "rpgMachineryPrintingOptions"
        Me.rpgMachineryPrintingOptions.ShowCaptionButton = False
        Me.rpgMachineryPrintingOptions.Tag = "3"
        Me.rpgMachineryPrintingOptions.Text = "Printing Options"
        Me.rpgMachineryPrintingOptions.Visible = False
        '
        'rpInventory
        '
        Me.rpInventory.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgInventory, Me.rpgInventoryOptions, Me.rpgInventoryViewingOptions, Me.rpgInventoryPrintingOptions})
        Me.rpInventory.Name = "rpInventory"
        Me.rpInventory.Text = "Inventory"
        '
        'rpgInventory
        '
        Me.rpgInventory.ItemLinks.Add(Me.PART)
        Me.rpgInventory.ItemLinks.Add(Me.PARTPURCHASE)
        Me.rpgInventory.Name = "rpgInventory"
        Me.rpgInventory.ShowCaptionButton = False
        Me.rpgInventory.Tag = "1"
        Me.rpgInventory.Text = "Inventory Options"
        '
        'rpgInventoryOptions
        '
        Me.rpgInventoryOptions.ItemLinks.Add(Me.bbAdd)
        Me.rpgInventoryOptions.ItemLinks.Add(Me.bbSave)
        Me.rpgInventoryOptions.ItemLinks.Add(Me.bbDelete)
        Me.rpgInventoryOptions.Name = "rpgInventoryOptions"
        Me.rpgInventoryOptions.ShowCaptionButton = False
        Me.rpgInventoryOptions.Tag = "2"
        Me.rpgInventoryOptions.Text = "Editing Options"
        '
        'rpgInventoryViewingOptions
        '
        Me.rpgInventoryViewingOptions.ItemLinks.Add(Me.bbCritical)
        Me.rpgInventoryViewingOptions.Name = "rpgInventoryViewingOptions"
        Me.rpgInventoryViewingOptions.ShowCaptionButton = False
        Me.rpgInventoryViewingOptions.Text = "Inventory Viewing Options"
        '
        'rpgInventoryPrintingOptions
        '
        Me.rpgInventoryPrintingOptions.ItemLinks.Add(Me.bbPreview)
        Me.rpgInventoryPrintingOptions.Name = "rpgInventoryPrintingOptions"
        Me.rpgInventoryPrintingOptions.ShowCaptionButton = False
        Me.rpgInventoryPrintingOptions.Text = "Inventory Printing Options"
        '
        'rpDocViewer
        '
        Me.rpDocViewer.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgDocViewer})
        Me.rpDocViewer.Name = "rpDocViewer"
        Me.rpDocViewer.Text = "Document Viewer"
        '
        'rpgDocViewer
        '
        Me.rpgDocViewer.ItemLinks.Add(Me.MDOCVIEWER)
        Me.rpgDocViewer.ItemLinks.Add(Me.WDOCVIEWER)
        Me.rpgDocViewer.ItemLinks.Add(Me.IDOCVIEWER)
        Me.rpgDocViewer.Name = "rpgDocViewer"
        Me.rpgDocViewer.Tag = "1"
        Me.rpgDocViewer.Text = "Document Viewer Options"
        '
        'rpAdmin
        '
        Me.rpAdmin.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgAdmin, Me.rpgAdminEditingOptions, Me.rpgAdminFilterOptions, Me.rpgAdminPrintingOptions})
        Me.rpAdmin.Name = "rpAdmin"
        Me.rpAdmin.Text = "Admin"
        '
        'rpgAdmin
        '
        Me.rpgAdmin.ItemLinks.Add(Me.UNITS)
        Me.rpgAdmin.ItemLinks.Add(Me.COMPONENT)
        Me.rpgAdmin.ItemLinks.Add(Me.MAINTENANCE)
        Me.rpgAdmin.ItemLinks.Add(Me.COUNTER)
        Me.rpgAdmin.ItemLinks.Add(Me.CATEGORY)
        Me.rpgAdmin.ItemLinks.Add(Me.INTERVAL)
        Me.rpgAdmin.ItemLinks.Add(Me.VLOCATION)
        Me.rpgAdmin.ItemLinks.Add(Me.STORAGE)
        Me.rpgAdmin.ItemLinks.Add(Me.DEPARTMENT)
        Me.rpgAdmin.ItemLinks.Add(Me.RANK)
        Me.rpgAdmin.ItemLinks.Add(Me.VENDOR)
        Me.rpgAdmin.ItemLinks.Add(Me.MAKER)
        Me.rpgAdmin.Name = "rpgAdmin"
        Me.rpgAdmin.ShowCaptionButton = False
        Me.rpgAdmin.Tag = "1"
        Me.rpgAdmin.Text = "Admin Options"
        '
        'rpgAdminEditingOptions
        '
        Me.rpgAdminEditingOptions.ItemLinks.Add(Me.bbAdd)
        Me.rpgAdminEditingOptions.ItemLinks.Add(Me.bbSave)
        Me.rpgAdminEditingOptions.ItemLinks.Add(Me.bbDelete)
        Me.rpgAdminEditingOptions.ItemLinks.Add(Me.bbCopy)
        Me.rpgAdminEditingOptions.ItemLinks.Add(Me.bbCopyMaintenance)
        Me.rpgAdminEditingOptions.ItemLinks.Add(Me.bbShowComponents)
        Me.rpgAdminEditingOptions.ItemLinks.Add(Me.bbPaste)
        Me.rpgAdminEditingOptions.ItemLinks.Add(Me.bbImportFromFile)
        Me.rpgAdminEditingOptions.Name = "rpgAdminEditingOptions"
        Me.rpgAdminEditingOptions.ShowCaptionButton = False
        Me.rpgAdminEditingOptions.Tag = "2"
        Me.rpgAdminEditingOptions.Text = "Editing Options"
        '
        'rpgAdminFilterOptions
        '
        Me.rpgAdminFilterOptions.ItemLinks.Add(Me.ledMainUnits)
        Me.rpgAdminFilterOptions.ItemLinks.Add(Me.ledDepartment)
        Me.rpgAdminFilterOptions.ItemLinks.Add(Me.ledCategory)
        Me.rpgAdminFilterOptions.ItemLinks.Add(Me.bbCritical)
        Me.rpgAdminFilterOptions.ItemLinks.Add(Me.bbWOMaintenance)
        Me.rpgAdminFilterOptions.Name = "rpgAdminFilterOptions"
        Me.rpgAdminFilterOptions.ShowCaptionButton = False
        Me.rpgAdminFilterOptions.Text = "Admin Filter Options"
        '
        'rpgAdminPrintingOptions
        '
        Me.rpgAdminPrintingOptions.ItemLinks.Add(Me.bbPreview)
        Me.rpgAdminPrintingOptions.Name = "rpgAdminPrintingOptions"
        Me.rpgAdminPrintingOptions.ShowCaptionButton = False
        Me.rpgAdminPrintingOptions.Tag = "3"
        Me.rpgAdminPrintingOptions.Text = "Printing Options"
        Me.rpgAdminPrintingOptions.Visible = False
        '
        'rpTools
        '
        Me.rpTools.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgTools, Me.rpgToolSelectionOption, Me.rpgToolsOptions, Me.rpgToolsFilterOptions})
        Me.rpTools.Name = "rpTools"
        Me.rpTools.Text = "Tools"
        '
        'rpgTools
        '
        Me.rpgTools.ItemLinks.Add(Me.BACKUPRESTORE, True)
        Me.rpgTools.ItemLinks.Add(Me.VERSIONUPDATE)
        Me.rpgTools.ItemLinks.Add(Me.ARCHIVEDATA)
        Me.rpgTools.ItemLinks.Add(Me.RECOVERARCHIVE)
        Me.rpgTools.ItemLinks.Add(Me.EXPMAINTENANCE)
        Me.rpgTools.ItemLinks.Add(Me.EXPDOCUMENTS)
        Me.rpgTools.ItemLinks.Add(Me.EXPORTADMIN)
        Me.rpgTools.ItemLinks.Add(Me.IMPORTDATA)
        Me.rpgTools.Name = "rpgTools"
        Me.rpgTools.ShowCaptionButton = False
        Me.rpgTools.Tag = "1"
        Me.rpgTools.Text = "Tools Options"
        '
        'rpgToolSelectionOption
        '
        Me.rpgToolSelectionOption.ItemLinks.Add(Me.bbSelectAll, True)
        Me.rpgToolSelectionOption.ItemLinks.Add(Me.bbDeselect)
        Me.rpgToolSelectionOption.Name = "rpgToolSelectionOption"
        Me.rpgToolSelectionOption.ShowCaptionButton = False
        Me.rpgToolSelectionOption.Text = "Selection Options"
        '
        'rpgToolsOptions
        '
        Me.rpgToolsOptions.ItemLinks.Add(Me.bbBackUp)
        Me.rpgToolsOptions.ItemLinks.Add(Me.bbRestore)
        Me.rpgToolsOptions.ItemLinks.Add(Me.bbUpdate)
        Me.rpgToolsOptions.ItemLinks.Add(Me.bbAdd)
        Me.rpgToolsOptions.ItemLinks.Add(Me.bbSave)
        Me.rpgToolsOptions.ItemLinks.Add(Me.bbEdit)
        Me.rpgToolsOptions.ItemLinks.Add(Me.bbDelete)
        Me.rpgToolsOptions.Name = "rpgToolsOptions"
        Me.rpgToolsOptions.ShowCaptionButton = False
        Me.rpgToolsOptions.Tag = "2"
        Me.rpgToolsOptions.Text = "Editing Options"
        '
        'rpgToolsFilterOptions
        '
        Me.rpgToolsFilterOptions.ItemLinks.Add(Me.ledDepartment)
        Me.rpgToolsFilterOptions.ItemLinks.Add(Me.ledRank, True)
        Me.rpgToolsFilterOptions.ItemLinks.Add(Me.ledCategory)
        Me.rpgToolsFilterOptions.Name = "rpgToolsFilterOptions"
        Me.rpgToolsFilterOptions.ShowCaptionButton = False
        Me.rpgToolsFilterOptions.Text = "Tools Filter Options"
        '
        'rpSecurity
        '
        Me.rpSecurity.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgSecurity, Me.rpgSecEditingOptions})
        Me.rpSecurity.Name = "rpSecurity"
        Me.rpSecurity.Text = "Security"
        '
        'rpgSecurity
        '
        Me.rpgSecurity.ItemLinks.Add(Me.SECGROUPS)
        Me.rpgSecurity.ItemLinks.Add(Me.SECUSERS)
        Me.rpgSecurity.Name = "rpgSecurity"
        Me.rpgSecurity.ShowCaptionButton = False
        Me.rpgSecurity.Tag = "1"
        Me.rpgSecurity.Text = "Security Options"
        '
        'rpgSecEditingOptions
        '
        Me.rpgSecEditingOptions.ItemLinks.Add(Me.bbAdd)
        Me.rpgSecEditingOptions.ItemLinks.Add(Me.bbSave)
        Me.rpgSecEditingOptions.ItemLinks.Add(Me.bbDelete)
        Me.rpgSecEditingOptions.ItemLinks.Add(Me.bbResetPassword, True)
        Me.rpgSecEditingOptions.Name = "rpgSecEditingOptions"
        Me.rpgSecEditingOptions.ShowCaptionButton = False
        Me.rpgSecEditingOptions.Tag = "2"
        Me.rpgSecEditingOptions.Text = "Editing Options"
        '
        'rpAudit
        '
        Me.rpAudit.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgAudit, Me.rpgAuditReport})
        Me.rpAudit.Name = "rpAudit"
        Me.rpAudit.Text = "Audit"
        '
        'rpgAudit
        '
        Me.rpgAudit.ItemLinks.Add(Me.AUDIT)
        Me.rpgAudit.ItemLinks.Add(Me.REFRESH)
        Me.rpgAudit.Name = "rpgAudit"
        Me.rpgAudit.ShowCaptionButton = False
        Me.rpgAudit.Tag = "1"
        Me.rpgAudit.Text = "Audit Options"
        '
        'rpgAuditReport
        '
        Me.rpgAuditReport.ItemLinks.Add(Me.cmdReportPreview)
        Me.rpgAuditReport.ItemLinks.Add(Me.chkAuditWithDetails)
        Me.rpgAuditReport.Name = "rpgAuditReport"
        Me.rpgAuditReport.Text = "Report Options"
        '
        'rpReports
        '
        Me.rpReports.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgReportsOptions, Me.rpgReportsSelectionOptions, Me.rpgReportsPrintOptions})
        Me.rpReports.Name = "rpReports"
        Me.rpReports.Text = "Reports"
        '
        'rpgReportsOptions
        '
        Me.rpgReportsOptions.ItemLinks.Add(Me.PMSREP)
        Me.rpgReportsOptions.Name = "rpgReportsOptions"
        Me.rpgReportsOptions.ShowCaptionButton = False
        Me.rpgReportsOptions.Tag = "1"
        Me.rpgReportsOptions.Text = "Report Options"
        '
        'rpgReportsSelectionOptions
        '
        Me.rpgReportsSelectionOptions.ItemLinks.Add(Me.ledRank)
        Me.rpgReportsSelectionOptions.ItemLinks.Add(Me.ledDepartment)
        Me.rpgReportsSelectionOptions.ItemLinks.Add(Me.ledCategory)
        Me.rpgReportsSelectionOptions.ItemLinks.Add(Me.bbSelectAll, True)
        Me.rpgReportsSelectionOptions.ItemLinks.Add(Me.bbDeselect)
        Me.rpgReportsSelectionOptions.Name = "rpgReportsSelectionOptions"
        Me.rpgReportsSelectionOptions.ShowCaptionButton = False
        Me.rpgReportsSelectionOptions.Text = "Selection Options"
        '
        'rpgReportsPrintOptions
        '
        Me.rpgReportsPrintOptions.ItemLinks.Add(Me.bbPreview)
        Me.rpgReportsPrintOptions.Name = "rpgReportsPrintOptions"
        Me.rpgReportsPrintOptions.ShowCaptionButton = False
        Me.rpgReportsPrintOptions.Text = "Print Options"
        '
        'rpHome
        '
        Me.rpHome.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1})
        Me.rpHome.Name = "rpHome"
        Me.rpHome.Text = "Info"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.SWITCHBOARD)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.COMPANYINFO, True)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.VESSELINFO)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.LICENSEINFO)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.ShowCaptionButton = False
        Me.RibbonPageGroup1.Tag = "1"
        Me.RibbonPageGroup1.Text = "Program Options"
        '
        'DateDueEdit
        '
        Me.DateDueEdit.AutoHeight = False
        Me.DateDueEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateDueEdit.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateDueEdit.Name = "DateDueEdit"
        '
        'RibbonStatusBar
        '
        Me.RibbonStatusBar.Location = New System.Drawing.Point(0, 418)
        Me.RibbonStatusBar.Name = "RibbonStatusBar"
        Me.RibbonStatusBar.Ribbon = Me.RibbonControl
        Me.RibbonStatusBar.Size = New System.Drawing.Size(1179, 31)
        Me.RibbonStatusBar.Visible = False
        '
        'MainPanel
        '
        Me.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainPanel.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None
        Me.MainPanel.Location = New System.Drawing.Point(0, 143)
        Me.MainPanel.Name = "MainPanel"
        Me.MainPanel.Panel2.Text = "Panel2"
        Me.MainPanel.Size = New System.Drawing.Size(1179, 275)
        Me.MainPanel.SplitterPosition = 452
        Me.MainPanel.TabIndex = 2
        '
        'pmMainMenu
        '
        Me.pmMainMenu.ItemLinks.Add(Me.bbAdd)
        Me.pmMainMenu.ItemLinks.Add(Me.bbSave)
        Me.pmMainMenu.ItemLinks.Add(Me.bbDelete)
        Me.pmMainMenu.ItemLinks.Add(Me.bbCopy)
        Me.pmMainMenu.ItemLinks.Add(Me.bbBackUp)
        Me.pmMainMenu.ItemLinks.Add(Me.bbRestore)
        Me.pmMainMenu.ItemLinks.Add(Me.bbUpdate)
        Me.pmMainMenu.ItemLinks.Add(Me.bbAddPlannedDate)
        Me.pmMainMenu.ItemLinks.Add(Me.bbEdit)
        Me.pmMainMenu.ItemLinks.Add(Me.bbPreview)
        Me.pmMainMenu.ItemLinks.Add(Me.cmdHelp, True)
        Me.pmMainMenu.Name = "pmMainMenu"
        Me.pmMainMenu.Ribbon = Me.RibbonControl
        '
        'pmListMenu
        '
        Me.pmListMenu.ItemLinks.Add(Me.bbSaveLayout, True)
        Me.pmListMenu.ItemLinks.Add(Me.bbResetLayout)
        Me.pmListMenu.ItemLinks.Add(Me.cmdNotification, True)
        Me.pmListMenu.ItemLinks.Add(Me.cmdHelp)
        Me.pmListMenu.Name = "pmListMenu"
        Me.pmListMenu.Ribbon = Me.RibbonControl
        '
        'rpgVslAccount
        '
        Me.rpgVslAccount.Name = "rpgVslAccount"
        Me.rpgVslAccount.ShowCaptionButton = False
        Me.rpgVslAccount.Tag = "1"
        Me.rpgVslAccount.Text = "Vessel Account Options"
        '
        'dbdController
        '
        Me.dbdController.Controller.PropertiesBar.DefaultGlyphSize = New System.Drawing.Size(16, 16)
        Me.dbdController.Controller.PropertiesBar.DefaultLargeGlyphSize = New System.Drawing.Size(32, 32)
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1179, 449)
        Me.Controls.Add(Me.MainPanel)
        Me.Controls.Add(Me.RibbonStatusBar)
        Me.Controls.Add(Me.RibbonControl)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainForm"
        Me.Ribbon = Me.RibbonControl
        Me.StatusBar = Me.RibbonStatusBar
        Me.Text = "PMS - <<Administrator>>"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ledDepartmentRep, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ledRankRep, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ledCategoryRep, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ledDueHours, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ledUnitRep, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ledDueDays, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ledPeriodRep, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateDueEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateDueEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainPanel.ResumeLayout(False)
        CType(Me.pmMainMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pmListMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dbdController.Controller, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonStatusBar As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents MainPanel As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents bbSave As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbDelete As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RANK As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpAdmin As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpgAdmin As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rpgAdminEditingOptions As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents DEPARTMENT As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbSaveLayout As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdHelp As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SECUSERS As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpSecurity As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpgSecurity As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents SECGROUPS As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgSecEditingOptions As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents cmdChangePassword As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbResetPassword As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdChangeUser As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpTools As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpgTools As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rpHome As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpgToolsOptions As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents SWITCHBOARD As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents COMPANYINFO As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents LICENSEINFO As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbPreview As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbResetLayout As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BACKUPRESTORE As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbBackUp As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbRestore As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents VERSIONUPDATE As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbUpdate As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents pmMainMenu As DevExpress.XtraBars.PopupMenu
    Friend WithEvents rpgAdminPrintingOptions As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents cmdNotification As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents pmListMenu As DevExpress.XtraBars.PopupMenu
    Friend WithEvents bbExport As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbAdd As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgVslAccount As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rpReports As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpgReportsOptions As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rpgReportsPrintOptions As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rpgReportsSelectionOptions As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents bbEdit As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbSelectAll As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbDeselect As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgToolSelectionOption As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents SETTINGS As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpMaintenance As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpgMaintenance As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rpgMaintenanceEditingOptions As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents PMSREP As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ledDepartmentRep As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents rpgMachineryPrintingOptions As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents ARCHIVEDATA As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RECOVERARCHIVE As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UNITS As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PART As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents CATEGORY As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents COUNTER As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents VLOCATION As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgAdminFilterOptions As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents ledDepartment As DevExpress.XtraBars.BarEditItem
    Friend WithEvents WORKDONE As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgMaintenanceViewingOptions As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents ledRank As DevExpress.XtraBars.BarEditItem
    Friend WithEvents ledRankRep As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents ledCategory As DevExpress.XtraBars.BarEditItem
    Friend WithEvents ledCategoryRep As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents INTERVAL As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents WORKDUE As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents MAINTENANCE As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents COMPONENT As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ledDueDays As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents NONCONFORM As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbNC As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbUpdateNC As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents NCMEASURES As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents EXPORTADMIN As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IMPORTDATA As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbWOMaintenance As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgToolsFilterOptions As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RUNNINGHOURS As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents txtDueHours As DevExpress.XtraBars.BarEditItem
    Friend WithEvents ledDueHours As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents EXPMAINTENANCE As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents VESSELINFO As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbCopy As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ledMainUnits As DevExpress.XtraBars.BarEditItem
    Friend WithEvents ledUnitRep As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents bbCopyMaintenance As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbShowComponents As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents txtDateDue As DevExpress.XtraBars.BarEditItem
    Friend WithEvents DateDueEdit As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents bbAddPlannedDate As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ledPeriod As DevExpress.XtraBars.BarEditItem
    Friend WithEvents ledPeriodRep As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents bbCondition As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PARTPURCHASE As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpInventory As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpgInventory As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rpgInventoryOptions As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents bbViewImage As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents STORAGE As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents MDOCVIEWER As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents WDOCVIEWER As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpDocViewer As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpgDocViewer As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents bbPaste As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbImportFromFile As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents VENDOR As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents MAKER As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbCritical As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbFlatView As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbUserPreferences As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents dbdController As DevExpress.XtraBars.DefaultBarAndDockingController
    Friend WithEvents rpgInventoryPrintingOptions As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents bbShowAllMaintenance As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IDOCVIEWER As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgInventoryViewingOptions As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents EXPDOCUMENTS As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents AUDIT As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpAudit As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpgAudit As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents REFRESH As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpgAuditReport As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents cmdReportPreview As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents chkAuditWithDetails As DevExpress.XtraBars.BarCheckItem


End Class
