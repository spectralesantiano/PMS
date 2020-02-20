Imports System.IO

Public Class MainForm

    Dim extAssembly As System.Reflection.Assembly
    Private WithEvents maincontent As New BaseControl.BaseControl
    Private WithEvents mainlist As New BaseControl.BaseList

    Dim IsLoaded As Boolean = False, strFirstContent As String, ContentsObject As DataView

    Dim clsAudit As New clsAudit 'neil
    Dim auditlogid As Long 'neil

    Private Sub BypassLogonForDebugging(Optional ByVal bloggedon As Boolean = False)
        IsLoaded = False
        USER_NAME = "Admin"
        USER_ID = 1
        GROUP_ID = 0
        PMSDB.BeginReader("SELECT Logo FROM sti_sys.dbo.tblCompanyInfo")
        If PMSDB.Read() Then
            If Not PMSDB.ReaderItem("Logo") Is System.DBNull.Value Then
                Dim imgByte As Byte() = PMSDB.ReaderItem("Logo")
                LOGO = New System.Drawing.Bitmap(New System.IO.MemoryStream(imgByte))
            End If
        End If
        PMSDB.CloseReader()
        LoadUserPref()
        If Not mainlist Is Nothing Then mainlist.RefreshData()
        InitUserSettings()
    End Sub

    Sub RefreshMainUnits()
        ledUnitRep.DataSource = PMSDB.CreateTable("SELECT * FROM (SELECT 'EMPTY' UnitCode,'<EMPTY>' UnitDesc, 0 SortCode UNION SELECT UnitCode, UnitDesc,1 FROM dbo.UNITLIST WHERE ParentCode IS NULL) t ORDER BY t.SortCode, t.UnitDesc")
    End Sub

    Private Sub LoadSettings()
        PMSDB.BeginReader("SELECT Logo FROM sti_sys.dbo.tblCompanyInfo")
        If PMSDB.Read() Then
            If Not PMSDB.ReaderItem("Logo") Is System.DBNull.Value Then
                Dim imgByte As Byte() = PMSDB.ReaderItem("Logo")
                LOGO = New System.Drawing.Bitmap(New System.IO.MemoryStream(imgByte))
            End If
        End If
        PMSDB.CloseReader()
        AdmDept = PMSDB.CreateTable("SELECT * FROM dbo.DEPARTMENTLIST")
        AdmRank = PMSDB.CreateTable("SELECT * FROM dbo.RANKLIST ORDER BY Abbrv")
        ledDepartmentRep.DataSource = AdmDept
        ledPeriodRep.DataSource = GetPeriods()
        RefreshMainUnits()
        ledRankRep.DataSource = AdmRank 'PMSDB.CreateTable("SELECT DISTINCT ar.RankCode,Abbrv,ar.SortCode FROM dbo.RANKLIST ar INNER JOIN dbo.tblAdmEquipment m ON ar.RankCode=m.RankCode ORDER BY ar.Abbrv")
        ledCategoryRep.DataSource = PMSDB.CreateTable("SELECT Category,CatCode FROM dbo.CATEGORYLIST ORDER BY Category")
        'ledEquipmentRep.DataSource = PMSDB.CreateTable("SELECT Equipment,EquipmentCode FROM dbo.EQUIPMENTLIST ORDER BY Equipment")
        PMSDB.BeginReader("EXEC dbo.GETSETTINGS")
        If PMSDB.Read Then
            DATE_LAST_EXPORT = PMSDB.ReaderItem("DATE_LAST_EXPORT", "")
            DATE_LAST_EXPORT_IMG = PMSDB.ReaderItem("DATE_LAST_EXPORT_IMG", "")
            EXPORT_DIR = PMSDB.ReaderItem("EXPORT_DIR", "")
            LOCATION_ID = PMSDB.ReaderItem("LOCATION_ID", "")
            txtDateDue.EditValue = PMSDB.ReaderItem("DUE_DAYS", 30)
            txtDueHours.EditValue = PMSDB.ReaderItem("DUE_HOURS", 100)
            IMAGE_MAX_RES = PMSDB.ReaderItem("IMAGE_MAX_RES", 800)
        End If
        PMSDB.CloseReader()
        'DateDueEdit.MinValue = Now.Date.AddDays(1)
        'txtDateDue.EditValue = Now.Date.AddMonths(1)
        bbSaveLayout.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        bbResetLayout.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.Text = "<< " & GetAppName() & " - " & GetUserName() & " - " & Now.ToShortDateString & GetServerName() & ">>"
    End Sub

    Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        maincontent.CheckIFDataUpdated()
        clsAudit.saveAuditLog("User log out", USER_NAME, auditlogid, System.Environment.MachineName, 0, , , , , , "MPS Crewing", Date.Now) 'neil
    End Sub

    Private Sub Logon(Optional ByVal bloggedon As Boolean = False)
        IsLoaded = False
        Me.Visible = False
        Dim logfrm As New Login
        logfrm.ShowDialog()
        If Not logfrm.is_loggedon Then
            If bloggedon Then
                Me.Visible = True
                Exit Sub
            Else
                End
            End If
        End If
        If USER_PASSWORD = DEFAULT_PASSWORD Then
            Dim frmchangepassword As New ChangePassword
            frmchangepassword.ShowDialog()
            If Not frmchangepassword.is_saved Then
                End
            End If
        End If

        clsAudit.saveAuditLog("User log in", USER_NAME, auditlogid, System.Environment.MachineName, 0,
                               , , , , , "MPS Crewing", Date.Now) 'neil

        LoadUserPref()
        InitUserSettings()
        LoadContent(strFirstContent, True)
    End Sub

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Visible = False
        If SQL_SERVER = "" Then
            Dim frm As New frmConnect
            frm.ShowDialog()
            If SQL_SERVER = "" Then
                Me.Close()
                Exit Sub
            End If
        End If

        If Not Debugger.IsAttached Then
            CheckAppVersion()
            CheckLicense()
        End If

        PMSDB.BeginReader("SELECT TOP 1 * FROM [dbo].[VESSELINFO]")
        If PMSDB.Read Then
            VESSEL = PMSDB.ReaderItem("Vessel")
            IMO_NUMBER = PMSDB.ReaderItem("IMONo")
            TYPE_DESC = PMSDB.ReaderItem("TypeDesc", "")
            FLAG_DESC = PMSDB.ReaderItem("FlagDesc", "")
        End If
        PMSDB.CloseReader()

        If IMO_NUMBER = "" Then
            Dim frm As New frmVesselInfo
            frm.ShowDialog()
            If Not frm.IS_SAVED And IMO_NUMBER = "" Then
                Me.Close()
                Exit Sub
            End If
        End If

        clsAudit.propSQLConnStr = PMSDB.GetConnectionString & "Password=" & SQL_PASSWORD 'neil

        LoadSettings()
        If Debugger.IsAttached Then
            BypassLogonForDebugging()
            LoadContent("WORKDONE", True)
        Else
            Logon()
        End If

        'Lock PMS Records
        PMSDB.RunSql("UPDATE dbo.tblMaintenanceWork SET Locked=1 WHERE GETDATE()>=DATEADD(D,7,DateAdded )")

        EXPDOCUMENTS.Enabled = LOCATION_ID <> ""
        EXPMAINTENANCE.Enabled = LOCATION_ID <> ""
        EXPORTADMIN.Enabled = LOCATION_ID <> ""
        IMPORTDATA.Enabled = LOCATION_ID <> ""
        'rpTools.Visible = False
        IsLoaded = True
        Me.Visible = True

    End Sub

    Private Sub mainlist_OnCellRightClick(ByVal sender As String) Handles mainlist.OnCellRightClick
        pmListMenu.ShowPopup(Control.MousePosition)
    End Sub

    Private Sub mainlist_SelectionChange(ByVal sender As String) Handles mainlist.OnSelectionChange
        If IsLoaded Then
            maincontent.CheckIFDataUpdated()
            Me.Cursor = Cursors.WaitCursor
            maincontent.RefreshData()
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub mainlist_AcceptedDragObject(ByVal sender As String) Handles mainlist.AcceptedDragObject
        maincontent.DeleteData()
    End Sub

    Private Sub EnableAdd(ByVal sender As String, ByVal value As Boolean) Handles maincontent.AllowAdd
        bbAdd.Enabled = value
    End Sub

    Private Sub EnableSave(ByVal sender As String, ByVal value As Boolean) Handles maincontent.AllowSave
        bbSave.Enabled = value
    End Sub

    Private Sub EnableDelete(ByVal sender As String, ByVal value As Boolean) Handles maincontent.AllowDelete
        bbDelete.Enabled = value
    End Sub

    Private Sub CustomEvent(ByVal sender As String, ByVal param() As Object) Handles maincontent.OnCustomEvent
        'Unique commands
        Select Case param(0)
            Case "RANKDEPCAT"
                ledRank.Visibility = IIf(CBool(param(1)), DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
                ledDepartment.Visibility = IIf(CBool(param(1)), DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
                ledCategory.Visibility = IIf(CBool(param(1)), DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
            Case "EnableImport"
                bbPaste.Enabled = CBool(param(1))
                bbImportFromFile.Enabled = CBool(param(1))
            Case "EnableImageViewer"
                bbViewImage.Enabled = CBool(param(1))
            Case "ShowComponent"
                If CBool(param(1)) Then
                    bbShowComponents.Caption = "Hide" & Environment.NewLine & "Components"
                    bbShowComponents.Down = True
                Else
                    bbShowComponents.Caption = "Show" & Environment.NewLine & "Components"
                    bbShowComponents.Down = False
                End If
            Case "RefreshMainUnits"
                RefreshMainUnits()
                Application.DoEvents()
                If param(1) = "DELETE" Then
                    ledMainUnits.EditValue = DBNull.Value
                End If
            Case "RenameEdit"
                bbEdit.Caption = param(1)
            Case "EnableEdit"
                bbEdit.Enabled = CBool(param(1))
                bbAddPlannedDate.Enabled = CBool(param(1))
            Case "DisableEditNC"
                bbUpdateNC.Enabled = False
            Case "EnableEditNC"
                bbUpdateNC.Enabled = True
            Case "RenameNC"
                bbNC.Caption = param(1)
            Case "ShowUpdateButton"
                bbUpdate.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            Case "EnableBackup"
                bbBackUp.Enabled = True
            Case "DisableBackup"
                bbBackUp.Enabled = False
            Case "EnableRestore"
                bbRestore.Enabled = True
            Case "DisableRestore"
                bbRestore.Enabled = False
            Case "HidePreview"
                bbPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            Case "EnablePreview"
                bbPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                bbPreview.Enabled = True
            Case "DisablePreview"
                bbPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                bbPreview.Enabled = False
            Case "Preview"
                Dim extAssembly As System.Reflection.Assembly = System.Reflection.Assembly.LoadFrom(GetAppPath() & "\" & Trim(param(2)) & ".dll")
                extAssembly.CreateInstance(Trim(param(2)) & "." & Trim(param(1)), True, Reflection.BindingFlags.Default, Nothing, New Object() {PMSDB, param(3)}, Nothing, Nothing)
        End Select
    End Sub

    Private Sub HideAdd(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.AddVisibility
        Dim ngroup As DevExpress.XtraBars.Ribbon.RibbonPageGroup
        bbAdd.Visibility = value
        For Each ngroup In RibbonControl.SelectedPage.Groups
            If ngroup.Tag = 2 Then
                SetRibbonPageGroupVisibility(ngroup)
            End If
        Next
    End Sub

    Private Sub HideSave(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.SaveVisibility
        Dim ngroup As DevExpress.XtraBars.Ribbon.RibbonPageGroup
        bbSave.Visibility = value
        For Each ngroup In RibbonControl.SelectedPage.Groups
            If ngroup.Tag = 2 Then
                SetRibbonPageGroupVisibility(ngroup)
            End If
        Next
    End Sub

    Private Sub HideDelete(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.DeleteVisibility
        Dim ngroup As DevExpress.XtraBars.Ribbon.RibbonPageGroup
        bbDelete.Visibility = value
        For Each ngroup In RibbonControl.SelectedPage.Groups
            If ngroup.Tag = 2 Then
                SetRibbonPageGroupVisibility(ngroup)
            End If
        Next
    End Sub

    Private Sub SetSaveCaption(ByVal sender As String, ByVal value As String) Handles maincontent.CustomSaveCaption
        bbSave.Caption = value
    End Sub

    Private Sub SetDeleteCaption(ByVal sender As String, ByVal value As String) Handles maincontent.CustomDeleteCaption
        bbDelete.Caption = value
    End Sub

    Private Sub SetAddCaption(ByVal sender As String, ByVal value As String) Handles maincontent.CustomAddCaption
        bbAdd.Caption = value
    End Sub

    Private Sub cmdSave_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbSave.ItemClick
        maincontent.SaveData()
    End Sub

    Private Sub cmdAdd_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbAdd.ItemClick
        maincontent.AddData()
    End Sub

    Private Sub cmdDelete_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbDelete.ItemClick
        maincontent.DeleteData()
    End Sub

    Private Sub maincontent_OnSwitchContent(ByVal sender As String, ByVal value As String, ByVal cmd() As String) Handles maincontent.OnSwitchContent
        LoadContent(value)
        If value = "WORKDONE" Then
            maincontent.ExecCustomFunction(cmd)
        End If
    End Sub

    Private Sub LoadContent(ByVal cContent As String, Optional ForceRefresh As Boolean = False)
        IsLoaded = False
        Dim gGroup As DevExpress.XtraBars.Ribbon.RibbonPageGroup
        Dim nButton As DevExpress.XtraBars.BarButtonItem = RibbonControl.Items(cContent)
        Dim nGroup As DevExpress.XtraBars.Ribbon.RibbonPageGroupItemLinkCollection = TryCast(nButton.Links(0).Links, DevExpress.XtraBars.Ribbon.RibbonPageGroupItemLinkCollection)
        'Ensure that the select item was selected.
        RibbonControl.SelectedPage = nGroup.PageGroup.Page
        nButton.Down = True
        nButton.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        RibbonControl.Minimized = False
        MainPanel.Visible = True
        If cContent <> maincontent.Name Or ForceRefresh Then
            Dim xrow As DataRowView() = ContentsObject.FindRows(cContent)
            Dim blList As String = Trim(xrow(0)("ObjectList")), strDLL As String = Trim(xrow(0)("DLL")), strFilter As String = Trim(IfNull(xrow(0)("Filter"), "")), bDraggable As Boolean = xrow(0)("Draggable")
            maincontent.CheckIFDataUpdated()
            Me.Cursor = Cursors.WaitCursor
            Try
                maincontent.Dispose()
                MainPanel.Panel2.Controls.Clear()
                extAssembly = System.Reflection.Assembly.LoadFrom(GetAppPath() & "\" & strDLL & ".dll")
                maincontent = extAssembly.CreateInstance(strDLL & "." & cContent, True, Reflection.BindingFlags.Default, Nothing, Nothing, Nothing, Nothing)
                If blList = "" Then
                    MainPanel.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2
                    mainlist.Name = "   "
                Else
                    MainPanel.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both
                    If IfNull(xrow(0)("ListLayout"), "") <> "" Then mainlist.SetLayout(xrow(0)("ListLayout"))
                    If IfNull(xrow(0)("ListWidth"), 0) = 0 Then
                        MainPanel.SplitterPosition = xrow(0)("ObjectListDefaultWidth")
                    Else
                        MainPanel.SplitterPosition = CType(xrow(0)("ListWidth"), Integer)
                    End If
                    If mainlist.Name <> strDLL & "_" & blList Or ForceRefresh Then
                        mainlist.Dispose()
                        MainPanel.Panel1.Controls.Clear()
                        mainlist = extAssembly.CreateInstance(strDLL & "." & blList, True, Reflection.BindingFlags.Default, Nothing, Nothing, Nothing, Nothing)
                        mainlist.Name = strDLL & "_" & blList
                        mainlist.LayoutFileName = GetAppPath() & "\Users\" & strDLL & "_" & blList & "_" & USER_ID & "layout.xml"
                        MainPanel.Panel1.Controls.Add(mainlist)
                        mainlist.DB = PMSDB
                        mainlist.RefreshData()
                    End If
                    mainlist.ClearFilter()
                    If strFilter <> "" Then
                        mainlist.SetFilter(strFilter)
                    End If
                    mainlist.Draggable(bDraggable)
                    mainlist.Dock = DockStyle.Fill
                    maincontent.blList = mainlist
                End If
                maincontent.Dock = DockStyle.Fill
                MainPanel.Panel2.Controls.Add(maincontent)
                maincontent.DB = PMSDB
                maincontent.Name = cContent
                maincontent.strHelpUrl = IfNull(xrow(0)("HelpUrl"), "")
                maincontent.bPermission = xrow(0)("Permission")
                maincontent.strCaption = xrow(0)("Caption")
                If IfNull(xrow(0)("ContentLayout"), "") <> "" Then maincontent.SetLayout(xrow(0)("ContentLayout"))
                SetCustomMenuVisibility(cContent, xrow(0)("Permission"))
                maincontent.RefreshData()
                Me.Text = GetAppName() & " - << " & Trim(xrow(0)("Caption")) & " - " & GetUserName() & GetServerName() & " >>"
                bbPreview.Visibility = IIf(xrow(0)("PrintOption") And (xrow(0)("Permission") And 1) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
                For Each gGroup In RibbonControl.SelectedPage.Groups
                    If gGroup.Tag = 3 Then
                        gGroup.Visible = xrow(0)("PrintOption") And (xrow(0)("Permission") And 1) > 0
                    End If
                Next
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, GetAppName)
            End Try
            bbSaveLayout.Visibility = IIf(blList <> "" Or cContent = "WORKDUE" Or cContent = "RUNNINGHOURS", DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
            bbResetLayout.Visibility = IIf(blList <> "" Or cContent = "WORKDUE" Or cContent = "RUNNINGHOURS", DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
            Me.Cursor = Cursors.Default
        End If
        IsLoaded = True
    End Sub

    Sub SetCustomMenuVisibility(cContent As String, nPermission As Integer)
        Me.bbResetPassword.Visibility = IIf(cContent = "SECUSERS" And USER_ID = 1, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        Me.bbBackUp.Visibility = IIf((cContent = "BACKUPRESTORE") And (nPermission And 4) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        Me.bbCopyMaintenance.Visibility = IIf((cContent = "UNITS") And (nPermission And 4) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        Me.bbEdit.Visibility = IIf((cContent = "BACKUPRESTORE" Or cContent = "WORKDUE" Or cContent = "WORKDONE" Or cContent = "UNITS") And (nPermission And 4) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        Me.bbRestore.Visibility = IIf((cContent = "BACKUPRESTORE" Or cContent = "VERSIONUPDATE") And (nPermission And 4) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        Me.bbUpdate.Visibility = IIf((cContent = "VERSIONUPDATE") And (nPermission And 4) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        Me.ledRank.Visibility = IIf((cContent = "WORKDONE" Or cContent = "WORKDUE" Or cContent = "NCMEASURES") And (nPermission And 1) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        Me.ledDepartment.Visibility = IIf((cContent = "UNITS" Or cContent = "WORKDUE" Or cContent = "WORKDONE" Or cContent = "NONCONFORM" Or cContent = "COUNTER" Or cContent = "RANK" Or cContent = "RUNNINGHOURS") And (nPermission And 1) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        Me.ledCategory.Visibility = IIf((cContent = "UNITS" Or cContent = "WORKDUE" Or cContent = "WORKDONE") And (nPermission And 1) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        Me.ledMainUnits.Visibility = IIf((cContent = "UNITS") And (nPermission And 1) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        Me.bbShowComponents.Visibility = IIf((cContent = "UNITS") And (nPermission And 5) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        Me.rpgAdminFilterOptions.Visible = (cContent = "UNITS" Or cContent = "COUNTER" Or cContent = "RANK") And (nPermission And 1) > 0
        Me.txtDateDue.Visibility = IIf((cContent = "WORKDUE") And (nPermission And 1) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        Me.txtDueHours.Visibility = IIf((cContent = "WORKDUE") And (nPermission And 1) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        Me.bbNC.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbAddPlannedDate.Visibility = IIf((cContent = "WORKDUE") And (nPermission And 4) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        Me.ledPeriod.Visibility = IIf((cContent = "WORKDUE") And (nPermission And 1) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        Me.bbUpdateNC.Visibility = IIf((cContent = "NONCONFORM") And (nPermission And 4) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        Me.bbViewImage.Visibility = IIf((cContent = "WORKDUE" Or cContent = "WORKDONE") And (nPermission And 1) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        Me.bbWOMaintenance.Visibility = IIf((cContent = "COMPONENT") And (nPermission And 4) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        Me.rpgMaintenanceEditingOptions.Visible = (cContent = "WORKDUE" Or cContent = "WORKDONE" Or cContent = "NONCONFORM" Or cContent = "NCMEASURES" Or cContent = "RUNNINGHOURS")
        Me.rpgToolSelectionOption.Visible = (cContent = "RECOVERARCHIVE")
        Me.rpgToolsFilterOptions.Visible = (cContent = "INITWORK")
        Me.rpgInventoryPrintingOptions.Visible = (cContent = "PARTPURCHASE")
        Me.bbCondition.Visibility = IIf((cContent = "WORKDUE") And (nPermission And 1) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        Me.bbShowAllMaintenance.Visibility = IIf((cContent = "WORKDUE") And (nPermission And 1) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        Me.rpgToolsOptions.Visible = nPermission > 1
        Me.bbCopy.Visibility = IIf((cContent = "UNITS") And (nPermission And 1) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        Me.bbPaste.Visibility = IIf((cContent = "CATEGORY" Or cContent = "VLOCATION" Or cContent = "STORAGE" Or cContent = "MAINTENANCE") And (nPermission And 4) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        Me.bbImportFromFile.Visibility = IIf((cContent = "CATEGORY" Or cContent = "VLOCATION" Or cContent = "STORAGE" Or cContent = "MAINTENANCE") And (nPermission And 4) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        Me.bbCritical.Visibility = IIf((cContent = "PARTPURCHASE" Or cContent = "PART" Or cContent = "WORKDUE" Or cContent = "WORKDONE" Or cContent = "UNITS") And (nPermission And 1) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        Me.bbFlatView.Visibility = IIf((cContent = "WORKDONE") And (nPermission And 1) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        If cContent = "WORKDONE" And CURRENT_FLATVIEW_CHECKED Then MainPanel.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2
        Me.rpgInventoryViewingOptions.Visible = (cContent = "PARTPURCHASE" Or cContent = "PART")
    End Sub
    Private Sub RibbonControl_SelectedPageChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RibbonControl.SelectedPageChanged
        Dim container As DevExpress.XtraBars.Ribbon.RibbonPageGroup, nButton As DevExpress.XtraBars.BarButtonItem, i As Integer
        For Each container In RibbonControl.SelectedPage.Groups
            If container.Tag = 1 Then
                For i = 0 To container.ItemLinks.Count - 1
                    nButton = container.ItemLinks.Item(i).Item
                    If nButton.Down And nButton.GroupIndex > 0 And nButton.Visibility = DevExpress.XtraBars.BarItemVisibility.Always Then
                        LoadContent(nButton.Name)
                        Exit Sub
                    End If
                Next
                'No button is selected or the selected button is not visible
                For i = 0 To container.ItemLinks.Count - 1
                    nButton = container.ItemLinks.Item(i).Item
                    If nButton.GroupIndex > 0 And nButton.Visibility = DevExpress.XtraBars.BarItemVisibility.Always Then 'Select the first button.
                        nButton.Down = True
                        Exit Sub
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub Content_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
        LoadContent(e.Item.Name)
    End Sub

    Private Sub SetRibbonPageGroupVisibility(ByVal container As DevExpress.XtraBars.Ribbon.RibbonPageGroup, Optional ByVal HidePage As Boolean = False)
        Dim i As Integer
        container.Visible = True
        For i = 0 To container.ItemLinks.Count - 1
            If CType(container.ItemLinks.Item(i).Item, DevExpress.XtraBars.BarItem).Visibility = DevExpress.XtraBars.BarItemVisibility.Always Then Exit Sub
        Next
        container.Visible = False
        If HidePage Then container.Page.Visible = False
    End Sub

    Private Sub InitRibbonItems(ByVal container As DevExpress.XtraBars.Ribbon.RibbonPageGroup)
        Dim i As Integer, hasDown As Boolean = False, bBeginGroup As Boolean = False
        container.Visible = True
        For i = 0 To container.ItemLinks.Count - 1
            Dim nButton As DevExpress.XtraBars.BarButtonItem = container.ItemLinks.Item(i).Item
            Dim xrow As DataRowView() = ContentsObject.FindRows(nButton.Name)
            If xrow.Length > 0 Then
                If nButton.GroupIndex > 0 Then
                    If nButton.Tag <> 2 Then AddHandler nButton.ItemClick, AddressOf Content_ItemClick
                    nButton.Visibility = IIf((xrow(0)("Permission") And 1) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
                    If ((xrow(0)("Permission") And 1) > 0) And Not hasDown Then 'press the first button
                        If strFirstContent = "" Then strFirstContent = nButton.Name
                        hasDown = True
                        nButton.Down = True
                    End If
                    If bBeginGroup And (xrow(0)("Permission") And 1) > 0 Then 'Assign the start of the group for the previous button is which should be the start of group is not visible.
                        nButton.Links(0).BeginGroup = True
                        bBeginGroup = False
                    End If
                    If (xrow(0)("Permission") And 1) = 0 And nButton.Links(0).BeginGroup Then bBeginGroup = True 'The current button starts a new group but not visible.
                End If
            Else
                If nButton.GroupIndex > 0 Then nButton.Visibility = DevExpress.XtraBars.BarItemVisibility.Never 'Hide buttons that's not on tblObjects
            End If

        Next
        SetRibbonPageGroupVisibility(container, True)
    End Sub

    'Show all the buttons on the ribbon control
    Private Sub ResetRibbon()
        Dim nPage As DevExpress.XtraBars.Ribbon.RibbonPage, nPageGroup As DevExpress.XtraBars.Ribbon.RibbonPageGroup
        For Each nPage In RibbonControl.Pages
            nPage.Visible = True
            For Each nPageGroup In nPage.Groups
                nPageGroup.Visible = True
                If nPageGroup.Tag = 1 Then
                    InitRibbonItems(nPageGroup)
                End If
            Next
        Next
    End Sub

    Sub LoadUserPref()
        PMSDB.BeginReader("SELECT * FROM dbo.tblSec_Users_Pref WHERE [USER ID]=" & USER_ID)
        If PMSDB.Read Then
            FONT_INCREASE = PMSDB.ReaderItem("FontSizeAdjustment", 0)
            CURRENT_RANK = PMSDB.ReaderItem("RankCode", "")
            CURRENT_DUEDAYS = PMSDB.ReaderItem("DueDays", 30)
            CURRENT_DUEHOURS = PMSDB.ReaderItem("DueHours", 100)
            CURRENT_FLATVIEW_CHECKED = PMSDB.ReaderItem("FlatView", 0)
            CURRENT_SHOW_WARNING = PMSDB.ReaderItem("ShowUnitsWarning", 0)
        End If
        PMSDB.CloseReader()
        ledRank.EditValue = CURRENT_RANK
        txtDateDue.EditValue = CURRENT_DUEDAYS
        txtDueHours.EditValue = CURRENT_DUEHOURS
        bbFlatView.Down = CURRENT_FLATVIEW_CHECKED
        bbFlatView.Caption = IIf(CURRENT_FLATVIEW_CHECKED, "Tree View", "Flat View")
        DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = GetDefaultFont()
        DevExpress.XtraEditors.WindowsFormsSettings.DefaultMenuFont = GetDefaultFont()
        dbdController.Controller.AppearancesBar.ItemsFont = GetDefaultFont()
    End Sub

    Private Sub InitUserSettings()
        ContentsObject = New DataView(PMSDB.CreateTable("EXEC USERLOGIN @UserID=" & USER_ID))
        ContentsObject.Sort = "ObjectID"
        strFirstContent = ""
        ResetRibbon()
    End Sub

    Private Sub cmdSaveLayout_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbSaveLayout.ItemClick
        If maincontent.Name = "WORKDONE" Or maincontent.Name = "WORKDUE" Or maincontent.Name = "PART" Then 'new Implementation experiment
            Dim ListLayout As String = IIf(mainlist.Name = "   ", "", mainlist.GetLayout), ListWidth As Integer = IIf(mainlist.Name = "   ", 0, MainPanel.SplitterPosition), ContentLayout As String = maincontent.GetLayout, i As Integer
            PMSDB.InitSqlWithParametersSP("UPDATEUSERSETTINGS")
            PMSDB.AddSqlParameter("@UserID", SqlDbType.Int, USER_ID)
            PMSDB.AddSqlParameter("@ObjectID", SqlDbType.Text, maincontent.Name)
            PMSDB.AddSqlParameter("@ListLayout", SqlDbType.VarChar, ListLayout)
            PMSDB.AddSqlParameter("@ListWidth", SqlDbType.Int, ListWidth)
            PMSDB.AddSqlParameter("@ContentLayout", SqlDbType.VarChar, ContentLayout)
            PMSDB.RunSqlWithParameters()
            For i = 0 To ContentsObject.Count - 1
                If Trim(ContentsObject(i)("ObjectID")) = maincontent.Name Then
                    ContentsObject(i)("ListLayout") = ListLayout
                    ContentsObject(i)("ListWidth") = ListWidth
                    ContentsObject(i)("ContentLayout") = ContentLayout
                    Exit For
                End If
            Next
        Else
            mainlist.SaveLayout(GetAppPath() & "\Users\" & maincontent.Name & "_" & USER_ID & "layout.xml")
            WriteIni(USER_ID & "SplitterPosition" & maincontent.Name, MainPanel.SplitterPosition)
        End If
        'maincontent.SaveLayout()
    End Sub

    Private Sub cmdChangePassword_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdChangePassword.ItemClick
        Dim frm As New ChangePassword
        frm.ShowDialog()
    End Sub

    Private Sub cmdResetPassword_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbResetPassword.ItemClick
        maincontent.ExecCustomFunction(New Object() {"ResetPassword"})
    End Sub

    Private Sub cmdChangeUser_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdChangeUser.ItemClick
        Logon(True)
        Me.Visible = True
    End Sub

    Private Sub bbResetLayout_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbResetLayout.ItemClick
        If MsgBox("Continuing will reset Data List to it's default view. Do you want to continue?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            If maincontent.Name = "WORKDUE" Then
                Try
                    Kill(GetAppPath() & "\Users\WORKDUE_" & USER_ID & "layout.xml")
                Catch ex As Exception
                End Try
            Else
                Try
                    Kill(GetAppPath() & "\Users\" & mainlist.Name & "_" & USER_ID & "layout.xml")
                Catch ex As Exception
                End Try
                WriteIni(USER_ID & "SplitterPosition" & mainlist.Name, "")
            End If

            MsgBox("The settings has been reset please restart the application to view the changes on the settings.", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub bbPreview_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbPreview.ItemClick
        maincontent.ExecCustomFunction(New Object() {"Preview"})
    End Sub

    Private Sub bbBackUp_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbBackUp.ItemClick
        maincontent.ExecCustomFunction(New Object() {"Backup"})
    End Sub

    Private Sub bbRestore_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbRestore.ItemClick
        maincontent.ExecCustomFunction(New Object() {"Restore"})
        Logon(True)
    End Sub

    Private Sub bbUpdate_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbUpdate.ItemClick
        'Manual update for PMS - Jul 11 2019
        If (PMSDB.DLookUp("Value", "[sti_sys].[dbo].[tblPMSConfig]", "", "Code='UpdatesFolder'").Equals("")) Then
            MessageBox.Show("Please select first an update folder location.", APP_SHORT_NAME, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            If MsgBox("This will update the current program, would you like to continue?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim nPMS As Integer = 0
                nPMS = System.Diagnostics.Process.GetProcessesByName("PlannedMaintenance").Count

                If nPMS > 1 Then
                    MsgBox("Cannot proceed update!" & vbCrLf & vbCrLf & "Another instance of " & GetAppName() & " detected. Please close it before continuing.", MsgBoxStyle.Exclamation, GetAppName)
                    Exit Sub
                End If

                Dim odMain As New System.Windows.Forms.OpenFileDialog
                Dim versionNo As String = ""
                odMain.Filter = "Object File (*.obx)|*.obx"
                odMain.InitialDirectory = "C:\Spectral"
                If odMain.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                    If odMain.FileName <> "" Then
                        Dim tempObxFilePath As String = ""
                        Dim extractionSuccess As Boolean = LoadAndExtractObxFile(odMain.FileName, versionNo, tempObxFilePath)
                        'defining arguments should be : [ACTIONTYPE] [CURRENT_INTERFACE_VERSION] [obx file path] [username] [SQLSERVER] [SQLUSER] [SQLPWD] [USE_SPECTRAL_CON] [USE_TRUSTED_CON]
                        'param ACTIONTYPE: [UPDATE or LOAD]
                        Dim strArgs As String = "LOAD " & GetIni("VERSION") & " """ & tempObxFilePath & """ """ & USER_NAME & """ """ & SQL_SERVER & """ """ & SQL_USER_NAME & """ """ & SQL_PASSWORD & """ """ & USE_SPECTRAL_CON.ToString & """ """ & USE_TRUSTED_CON.ToString & """"

                        If (extractionSuccess) Then
                            Try
                                If (ReviseUpdateManager(versionNo, "LOAD") = -1) Then
                                    MessageBox.Show("There is a problem revising the UpdateManager.exe", GetAppName(), MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Return
                                End If
                            Catch ex As Exception
                                MessageBox.Show("Could not update the UpdateManger application - " & ex.Message, GetAppName(), MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Return
                            End Try
                            If System.Environment.OSVersion.Version.Major < 6 Then ' Windows XP
                                Try
                                    Shell("UpdateManager.exe " & strArgs, AppWinStyle.NormalFocus)
                                Catch ex As Exception
                                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, GetAppName)
                                End Try
                                'stop application
                                Process.GetCurrentProcess.Kill()

                            Else ' Higher OS Versions

                                Dim pUpdater As New ProcessStartInfo
                                pUpdater.FileName = "UpdateManager.exe"
                                'defining arguments should be : [ACTIONTYPE] [CURRENT_INTERFACE_VERSION] [obx file path] [username] [SQLSERVER] [SQLUSER] [SQLPWD] [USE_SPECTRAL_CON] [USE_TRUSTED_CON]
                                'param ACTIONTYPE: [UPDATE or LOAD]
                                pUpdater.Arguments = strArgs
                                pUpdater.UseShellExecute = True
                                pUpdater.WindowStyle = ProcessWindowStyle.Normal
                                Try
                                    Dim proc As Process = Process.Start(pUpdater)
                                Catch ex As Exception
                                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, GetAppName)
                                End Try
                                'stop application
                                Process.GetCurrentProcess.Kill()
                            End If
                        Else
                            MessageBox.Show("There is a problem extrancting the obx file. Please contact Spectral for details.", APP_SHORT_NAME, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    Private Function GetVersionValueForDB(val As String)
        Try
            If (val.Length > 0) Then
                Dim r = val.Split("=")
                If (r.Length > 1) Then
                    Return r(1).Trim()
                End If
            End If
        Catch ex As Exception
            Dim msg = ex.Message
        End Try
        Return ""
    End Function

    Private Function GetVersionInfo(scriptFile As String) As ArrayList
        Dim retVal As New ArrayList
        Try
            Dim contents = System.IO.File.ReadAllLines(scriptFile)
            For i As Integer = 0 To contents.Length - 1
                If (contents(i).Equals("[OBJECTS]") Or contents(i).Equals("[SQLS]")) Then
                    Return retVal
                Else
                    retVal.Add(contents(i))
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return retVal
    End Function
    Private Function PeekVesionNo(fileName As String, currVersionNumber As String) As String
        Dim versionNo As String = ""
        Dim path = APP_PATH & "\temp_update\OBJECT_SNAPSHOT\" '-> temp folder to extract contents of obx file.
        Dim updatePath = path & "\Update.txt" '-> the file that we need to look for.
        Dim zipFile As String = path & GetFileNameWithoutExtension(fileName) & ".zip"

        Try
            If (Directory.Exists(path)) Then '-> If there is an existing extracted file on OBJECT_SNAPSHOT, 
                Directory.Delete(path, True) '-> delete those. 
            End If
            MkDir(path) '-> Recreate the OBJECT_SNAPSHOT
            File.Copy(fileName, zipFile) '-> Copy zip files to OBJECT_SNAPSHOT
            UnzipFile(zipFile, path) '-> Extract contents of zip file.
            If (File.Exists(updatePath)) Then '-> If the Update.txt exists.
                Dim tempVersion As ArrayList = GetVersionInfo(updatePath)
                If (tempVersion.Count >= 1) Then
                    versionNo = GetVersionValueForDB(tempVersion(1).ToString())
                Else
                    versionNo = currVersionNumber
                End If
                'versionNo = GetVersionValueForDB(GetVersionInfo(updatePath)(1)).ToString() '-> Get the version no. 
            End If
        Catch ex As Exception
            LogErrors("Error on loading obx file : " & ex.Message)
            versionNo = "NO_UPDATE_FILE"
        Finally
            Directory.Delete(path, True) '-> After the peak, do the cleanup by deleting the OBJECT_SNAPSHOT folder, whether there is an error or not. 
        End Try

        Return versionNo
    End Function

    Private Function LoadAndExtractObxFile(fileName As String, ByRef versionNo As String, ByRef tempObxFilePath As String) As Boolean

        Dim versioningUtil As New clsVersioning(PMSDB.GetConnectionString())
        Try
            Dim updatePath As String = PMSDB.DLookUp("Value", "[sti_sys].[dbo].[tblPMSConfig]", "", "Code='UpdatesFolder'")
            Dim currentVersion As String = PMSDB.DLookUp("AppVersion", "[sti_sys].[dbo].[tblPMSVersion]", "", "1=1 ORDER BY AppVersion DESC")
            Dim localPath As String = APP_PATH & "\temp_update\"
            If (Not Directory.Exists(localPath)) Then 'Create a temporary obx folder locally for Spectral Service
                MkDir(localPath)
            End If

            If (File.Exists(fileName) And fileName.EndsWith(".obx", StringComparison.CurrentCultureIgnoreCase)) Then
                Dim updateVersionNo = PeekVesionNo(fileName, currentVersion) '-> Get the version number included in Update.txt of this obx file.
                If (updateVersionNo.Equals("NO_UPDATE_FILE")) Then
                    MessageBox.Show("The object update does not contain an Update.txt file.", APP_SHORT_NAME & " - Update", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
                'If versioningUtil.IsNewVersion(updateVersionNo, currentVersion) Then
                'Copy the obx file and extract it on local location.

                versionNo = updateVersionNo
                Dim zipFile As String = localPath & GetFileNameWithoutExtension(fileName) & ".zip"
                Dim copiedFile As String = zipFile.Replace(".zip", "") & "_" & DateTime.Now.ToString("MMddyyyy_hhmmss") & "_bak.obx"
                Dim extractedFolder As String = localPath & updateVersionNo
                If (File.Exists(zipFile)) Then
                    File.Delete(zipFile)
                End If
                File.Copy(fileName, zipFile)

                If (Directory.Exists(extractedFolder)) Then
                    Directory.Delete(extractedFolder, True)
                End If

                MkDir(extractedFolder)
                File.Copy(fileName, copiedFile)
                UnzipFile(zipFile, extractedFolder)

                If (File.Exists(extractedFolder & "\Update.txt")) Then
                    File.Delete(zipFile)
                    tempObxFilePath = extractedFolder
                    Return True
                Else
                    MessageBox.Show("The object update does not contain a Update.txt file.", "Update Manager", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Directory.Delete(extractedFolder, True)
                    File.Delete(zipFile)
                    File.Delete(copiedFile)
                    Return False
                End If
            End If
        Catch ex As Exception
            LogErrors("Error while extracting the object update file - " & ex.Message)
            Return False
        End Try
        Return True
    End Function

    Private Sub maincontent_RightClick(ByVal sender As String) Handles maincontent.RightClick
        pmMainMenu.ShowPopup(Control.MousePosition)
    End Sub

    Private Sub bbEdit_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbEdit.ItemClick
        maincontent.ExecCustomFunction(New Object() {"Edit"})
    End Sub

    Private Sub bbDeleteOther_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
        maincontent.ExecCustomFunction(New Object() {"DeleteOther"})
    End Sub

    Private Sub bbSelectAll_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbSelectAll.ItemClick
        maincontent.ExecCustomFunction(New Object() {"SelectAll"})
    End Sub

    Private Sub bbDeselect_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbDeselect.ItemClick
        maincontent.ExecCustomFunction(New Object() {"DeselectAll"})
    End Sub

    Private Sub LICENSEINFO_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles LICENSEINFO.ItemClick
        Dim frmLic As New frmActivate
        LICENSEINFO.Down = True
        frmLic.cmdOk.Text = "Ok"
        frmLic.ShowDialog()
        LICENSEINFO.Down = False
    End Sub

    Private Sub COMPANYINFO_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles COMPANYINFO.ItemClick
        Dim frmComInfo As New CompanyInfo, bAddMode As Boolean
        COMPANYINFO.Down = True
        PMSDB.BeginReader("SELECT * FROM sti_sys.dbo.tblCompanyInfo")
        If PMSDB.Read Then
            bAddMode = False
            frmComInfo.txtName.EditValue = PMSDB.ReaderItem("Name", "")
            frmComInfo.txtPhone.EditValue = PMSDB.ReaderItem("Phone", "")
            frmComInfo.txtEmail.EditValue = PMSDB.ReaderItem("Email", "")
            frmComInfo.txtAddress.EditValue = PMSDB.ReaderItem("Address", "")
            If Not LOGO Is Nothing Then frmComInfo.imgLogo.BackgroundImage = LOGO
        Else
            bAddMode = True
            frmComInfo.txtName.EditValue = ""
            frmComInfo.txtPhone.EditValue = ""
            frmComInfo.txtEmail.EditValue = ""
            frmComInfo.txtAddress.EditValue = ""
        End If
        PMSDB.CloseReader()
        frmComInfo.ShowDialog()
        If frmComInfo.bSaved Then
            If bAddMode Then
                PMSDB.InitSqlWithParameters("INSERT INTO sti_sys.dbo.tblCompanyInfo VALUES(@Name,@Phone,@Email,@Address,@Logo)")
            Else
                PMSDB.InitSqlWithParameters("UPDATE sti_sys.dbo.tblCompanyInfo SET Name=@Name, Phone=@Phone, Email=@Email, Address=@Address, Logo=@Logo")
            End If
            PMSDB.AddSqlParameter("@Name", SqlDbType.Text, frmComInfo.txtName.EditValue)
            PMSDB.AddSqlParameter("@Phone", SqlDbType.Text, frmComInfo.txtPhone.EditValue)
            PMSDB.AddSqlParameter("@Email", SqlDbType.Text, frmComInfo.txtEmail.EditValue)
            PMSDB.AddSqlParameter("@Address", SqlDbType.Text, frmComInfo.txtAddress.EditValue)
            If frmComInfo.imgLogo.BackgroundImage Is Nothing Then
                PMSDB.AddSqlParameter("@Logo", SqlDbType.Image, System.DBNull.Value)
                LOGO = Nothing
            Else
                PMSDB.AddSqlParameter("@Logo", SqlDbType.Image, ImageToByte(frmComInfo.imgLogo.BackgroundImage))
                LOGO = frmComInfo.imgLogo.BackgroundImage
            End If
            PMSDB.RunSqlWithParameters()
        End If
        COMPANYINFO.Down = False
    End Sub

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub RibbonControl_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles RibbonControl.Paint
        If Not LOGO Is Nothing Then
            Dim ribbonViewInfo As DevExpress.XtraBars.Ribbon.ViewInfo.RibbonViewInfo = RibbonControl.ViewInfo
            If ribbonViewInfo Is Nothing Then
                Return
            End If
            Dim panelViewInfo As DevExpress.XtraBars.Ribbon.ViewInfo.RibbonPanelViewInfo = ribbonViewInfo.Panel
            If panelViewInfo Is Nothing Then
                Return
            End If
            Dim bounds As Rectangle = panelViewInfo.Bounds
            Dim minX As Integer = bounds.X
            Dim groups As DevExpress.XtraBars.Ribbon.ViewInfo.RibbonPageGroupViewInfoCollection = panelViewInfo.Groups
            If groups Is Nothing Then
                Return
            End If
            If groups.Count > 0 Then
                minX = groups(groups.Count - 1).Bounds.Right
            End If
            Dim image As Image = ResizeImageByHeight(LOGO, 85)
            If bounds.Height < image.Height Then
                Return
            End If
            Dim offset As Integer = (bounds.Height - image.Height) / 2
            Dim width As Integer = image.Width + 15
            bounds.X = bounds.Width - width
            If bounds.X < minX Then
                Return
            End If
            bounds.Width = width
            bounds.Y += (offset - 2)
            bounds.Height = image.Height
            e.Graphics.DrawImage(image, bounds.Location)
        End If
    End Sub

    Private Sub ledUnitRep_ButtonClick(sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles ledUnitRep.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Close Then
            ledMainUnits.EditValue = DBNull.Value
        End If
    End Sub

    Private Sub ledDepartmentRep_ButtonClick(sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles ledDepartmentRep.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Close Then
            ledDepartment.EditValue = DBNull.Value
        End If
    End Sub

    Private Sub ledPeriodRep_ButtonClick(sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles ledPeriodRep.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Close Then
            ledPeriod.EditValue = DBNull.Value
        End If
    End Sub

    Private Sub ledRankRep_ButtonClick(sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles ledRankRep.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Close Then
            ledRank.EditValue = DBNull.Value
        End If
    End Sub

    Private Sub ledCategoryRep_ButtonClick(sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles ledCategoryRep.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Close Then
            ledCategory.EditValue = DBNull.Value
        End If
    End Sub

    Private Sub ledRank_EditValueChanged(sender As Object, e As System.EventArgs) Handles ledRank.EditValueChanged
        If IsLoaded Then
            CURRENT_RANK = IfNull(ledRank.EditValue, "")
            If maincontent.Name = "PMSREP" Then
                maincontent.ExecCustomFunction(New String() {"Filter"})
            Else
                mainlist.SetFilter("")
                If maincontent.Name = "WORKDONE" Then
                    maincontent.SetFilter("")
                Else
                    maincontent.RefreshData()
                End If
            End If
        End If
    End Sub

    Private Sub ledMainUnits_EditValueChanged(sender As Object, e As System.EventArgs) Handles ledMainUnits.EditValueChanged
        CURRENT_MAINUNIT = IfNull(ledMainUnits.EditValue, "")
        mainlist.SetFilter("")
        maincontent.RefreshData()
    End Sub

    Private Sub ledCategory_EditValueChanged(sender As Object, e As System.EventArgs) Handles ledCategory.EditValueChanged
        CURRENT_CATEGORY = IfNull(ledCategory.EditValue, "")
        If maincontent.Name = "PMSREP" Then
            maincontent.ExecCustomFunction(New String() {"Filter"})
        Else
            mainlist.SetFilter("")
            If (maincontent.Name = "WORKDONE" AndAlso CURRENT_FLATVIEW_CHECKED) Then
                maincontent.SetFilter("")
            Else
                maincontent.RefreshData()
            End If
        End If
    End Sub

    Private Sub ledDepartment_EditValueChanged(sender As Object, e As System.EventArgs) Handles ledDepartment.EditValueChanged
        CURRENT_DEPARTMENT = IfNull(ledDepartment.EditValue, "")
        If maincontent.Name = "RUNNINGHOURS" Or maincontent.Name = "PMSREP" Then
            maincontent.ExecCustomFunction(New String() {"Filter"})
        Else
            mainlist.SetFilter("")
            If maincontent.Name = "WORKDONE" AndAlso CURRENT_FLATVIEW_CHECKED Then
                maincontent.SetFilter("")
            Else
                maincontent.RefreshData()
            End If
        End If
    End Sub

    Private Sub ledPeriod_EditValueChanged(sender As Object, e As System.EventArgs) Handles ledPeriod.EditValueChanged
        Try
            CURRENT_PERIOD = IfNull(ledPeriod.EditValue, 0)
        Catch ex As Exception
            CURRENT_PERIOD = 0
        End Try
        If maincontent.Name = "WORKDUE" Then maincontent.RefreshData()
    End Sub

    Private Sub txtDueDate_EditValueChanged(sender As Object, e As System.EventArgs) Handles txtDateDue.EditValueChanged
        If IsLoaded Then
            Try
                If txtDateDue.EditValue Is Nothing Or txtDateDue.EditValue Is System.DBNull.Value Then
                    CURRENT_DUEDAYS = "NULL"
                Else
                    CURRENT_DUEDAYS = txtDateDue.EditValue
                End If

            Catch ex As Exception
                CURRENT_DUEDAYS = "NULL"
            End Try
            If maincontent.Name = "WORKDUE" Then maincontent.RefreshData()
        End If
    End Sub

    Private Sub txtDueHours_EditValueChanged(sender As Object, e As System.EventArgs) Handles txtDueHours.EditValueChanged
        If IsLoaded Then
            Try
                CURRENT_DUEHOURS = IfNull(txtDueHours.EditValue, 0)
                'PMSDB.RunSql("UPDATE sti_sys.dbo.tblPMSConfig SET Value='" & txtDueHours.EditValue & "' WHERE Code='DUE_HOURS'")
            Catch ex As Exception
                CURRENT_DUEHOURS = 0
            End Try
            If maincontent.Name = "WORKDUE" Then maincontent.RefreshData()
        End If
    End Sub

    Private Sub bbNC_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbNC.ItemClick
        maincontent.ExecCustomFunction(New Object() {"EditNC"})
    End Sub

    Private Sub bbUpdateNC_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbUpdateNC.ItemClick
        maincontent.ExecCustomFunction(New Object() {"UpdateNC"})
    End Sub

    Private Sub EXPMAINTENANCE_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles EXPMAINTENANCE.ItemClick
        Dim nExpType As Integer = 2, frm As New frmExportToSM
        frm.deFrom.EditValue = ChangeSQLDateStrToDate(DATE_LAST_EXPORT)
        frm.deTo.EditValue = Now.Date
        frm.lblLastExp.Text = CDate(frm.deFrom.EditValue).ToShortDateString
        frm.txtExportDir.EditValue = EXPORT_DIR
        frm.ShowDialog()
        If frm.bExported Then
            EXPORT_DIR = frm.txtExportDir.EditValue
            ExportPMSData(PMSDB, 3, frm.txtExportDir.EditValue & "\PMS_Maintenance_" & Now.ToString("yyyyMMddhhmm") & ".xxx", frm.deFrom.EditValue, frm.deTo.EditValue, False)
            PMSDB.SaveConfig("EXPORT_DIR", EXPORT_DIR, APP_SHORT_NAME)
            PMSDB.SaveConfig("DATE_LAST_EXPORT", DATE_LAST_EXPORT, APP_SHORT_NAME)
        End If
    End Sub


    Private Sub EXPORTADMIN_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles EXPORTADMIN.ItemClick
        'ExportPMSData(PMSDB, 1)
        If MsgBox("Please specify where you want to save export files.", MsgBoxStyle.Information Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim odMain As New System.Windows.Forms.SaveFileDialog
            odMain.Filter = "Files (*.pmsf) | *.pmsf"
            odMain.FileName = "AdminData"
            If odMain.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                ExportPMSData(PMSDB, 1, odMain.FileName, System.DBNull.Value, System.DBNull.Value, False)
            End If
        End If
    End Sub

    Private Sub EXPORTADMIN_ItemClick_OLD(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) 'Handles EXPORTADMIN.ItemClick
        Dim frm As New frmExportAdmin, sqls As New ArrayList, drRow As DataRow, tbl As DataTable, strFile As String, strTempCode As String
        frm.ShowDialog()
        If frm.IS_EXPORTED Then
            If MsgBox("Please specify where you want to save export files.", MsgBoxStyle.Information Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim odMain As New System.Windows.Forms.SaveFileDialog
                odMain.FileName = "AdminData"
                If odMain.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                    strFile = odMain.FileName

                    sqls.Add(IMO_NUMBER & "|1|PMS Admin Data") 'header admin data.

                    '''''''''''export categories
                    tbl = PMSDB.CreateTable("SELECT [CatCode],[Name],[DeptCode] FROM [dbo].[tblAdmCategory]")
                    sqls.Add("tblAdmCategory")
                    For Each drRow In tbl.Rows
                        sqls.Add("'" & drRow("CatCode") & "','" & drRow("Name").ToString.Replace("'", "''") & "','" & drRow("DeptCode") & "'")
                    Next
                    sqls.Add("END")

                    '''''''''''export work desc
                    tbl = PMSDB.CreateTable("SELECT [WorkCode],[Name] FROM [dbo].[tblAdmWork] WHERE LEFT(WorkCode,3)<>'SYS'")
                    sqls.Add("tblAdmWork")
                    For Each drRow In tbl.Rows
                        sqls.Add("'" & drRow("WorkCode") & "','" & drRow("Name").ToString.Replace("'", "''") & "'")
                    Next
                    sqls.Add("END")

                    '''''''''''export equipments
                    tbl = PMSDB.CreateTable("SELECT [EquipmentCode],[Name],[DeptCode],[CatCode],[RankCode],[IsCritical],[HasComponent],[HasMaintenance] FROM [dbo].[tblAdmEquipment]")
                    sqls.Add("tblAdmEquipment")
                    For Each drRow In tbl.Rows
                        sqls.Add("'" & drRow("EquipmentCode") & "','" & drRow("Name").ToString.Replace("'", "''") & "','" & drRow("DeptCode") & "','" & drRow("CatCode") & "','" & drRow("RankCode") & "'," & IIf(IfNull(drRow("IsCritical"), False), 1, 0) & "," & IIf(IfNull(drRow("HasComponent"), False), 1, 0) & "," & IIf(IfNull(drRow("HasMaintenance"), False), 1, 0))
                    Next
                    sqls.Add("END")

                    '''''''''''export components
                    tbl = PMSDB.CreateTable("SELECT [ComponentCode],[Name],[Specs] FROM [dbo].[tblAdmComponent]")
                    sqls.Add("tblAdmComponent")
                    For Each drRow In tbl.Rows
                        sqls.Add("'" & drRow("ComponentCode") & "','" & drRow("Name").ToString.Replace("'", "''") & "','" & drRow("Specs").ToString.Replace("'", "''") & "'")
                    Next
                    sqls.Add("END")

                    '''''''''''export equipment/component link
                    tbl = PMSDB.CreateTable("SELECT [EquipmentComponentCode],[EquipmentCode],[ComponentCode],[Number] FROM [dbo].[tblEquipmentComponent]")
                    sqls.Add("tblEquipmentComponent")
                    For Each drRow In tbl.Rows
                        sqls.Add("'" & drRow("EquipmentComponentCode") & "','" & drRow("EquipmentCode") & "','" & drRow("ComponentCode") & "'," & IfNull(drRow("Number"), "NULL"))
                    Next
                    sqls.Add("END")

                    '''''''''''export counters
                    tbl = PMSDB.CreateTable("SELECT [CounterCode],[Name],[UnitCode],[EquipmentComponentCode],[SortCode],[Active] FROM [dbo].[tblAdmCounter] WHERE [Active]=1")
                    sqls.Add("tblAdmCounter")
                    For Each drRow In tbl.Rows
                        If drRow("EquipmentComponentCode") Is DBNull.Value Then
                            strTempCode = "NULL"
                        Else
                            strTempCode = "'" & drRow("EquipmentComponentCode") & "'"
                        End If
                        sqls.Add("'" & drRow("CounterCode") & "','" & drRow("Name").ToString.Replace("'", "''") & "','" & drRow("UnitCode") & "'," & strTempCode & "," & IfNull(drRow("SortCode"), "NULL") & "," & IIf(drRow("Active"), "1", "0"))
                    Next
                    sqls.Add("END")

                    '''''''''''export maintenance
                    tbl = PMSDB.CreateTable("SELECT [MaintenanceCode],[WorkCode],[EquipmentCode],[ComponentCode],[RankCode],[Number],[IntCode],[InsCrossRef],[InsEditor],[InsDocument],[InsDateIssue],[InsDesc] FROM [dbo].[tblAdmMaintenance] WHERE LEFT([MaintenanceCode],3)<>'SYS'")
                    sqls.Add("tblAdmMaintenance")
                    For Each drRow In tbl.Rows
                        If drRow("ComponentCode") Is DBNull.Value Then
                            strTempCode = "NULL"
                        Else
                            strTempCode = "'" & drRow("ComponentCode") & "'"
                        End If
                        sqls.Add("'" & drRow("MaintenanceCode") & "','" & drRow("WorkCode") & "','" & drRow("EquipmentCode") & "'," & strTempCode & ",'" & drRow("RankCode") & "'," & IfNull(drRow("Number"), "NULL") & ", '" & IfNull(drRow("IntCode"), "") & "', '" & drRow("InsCrossRef").ToString.Replace("'", "''") & "','" & drRow("InsEditor").ToString.Replace("'", "''") & "','" & drRow("InsDocument") & "'," & ChangeToExportDate(drRow("InsDateIssue")) & ",'" & drRow("InsDesc").ToString.Replace("'", "''") & "'")
                    Next
                    sqls.Add("END")

                    If frm.chkUnits.Checked Then
                        '''''''''''export locations
                        tbl = PMSDB.CreateTable("SELECT [LocCode],[Name] FROM [dbo].[tblAdmLocation]")
                        sqls.Add("tblAdmLocation")
                        For Each drRow In tbl.Rows
                            sqls.Add("'" & drRow("LocCode") & "','" & drRow("Name").ToString.Replace("'", "''") & "'")
                        Next
                        sqls.Add("END")

                        '''''''''''export units
                        tbl = PMSDB.CreateTable("SELECT [UnitCode],[EquipmentCode],[Name],[IsSpare],[LocCode],[ProductNumber],[Manufacturer],[Specs] FROM [dbo].[tblAdmUnit]")
                        sqls.Add("tblAdmUnit")
                        For Each drRow In tbl.Rows
                            sqls.Add("'" & drRow("UnitCode") & "','" & drRow("EquipmentCode") & "','" & drRow("Name").ToString.Replace("'", "''") & "'," & IIf(drRow("IsSpare"), 1, 0) & ",'" & drRow("LocCode") & "', '" & drRow("ProductNumber") & "', '" & drRow("Manufacturer").ToString.Replace("'", "''") & "','" & drRow("Specs").ToString.Replace("'", "''") & "'")
                        Next
                        sqls.Add("END")
                    End If

                    If frm.chkParts.Checked Then

                        '''''''''''export parts
                        tbl = PMSDB.CreateTable("SELECT [PartCode],[Name],[Specs],[OnStock],[Minimum],[Ordered] FROM [dbo].[tblAdmPart]")
                        sqls.Add("tblAdmPart")
                        For Each drRow In tbl.Rows
                            sqls.Add("'" & drRow("PartCode") & "','" & drRow("Name").ToString.Replace("'", "''") & "','" & drRow("Specs").ToString.Replace("'", "''") & "'," & IfNull(drRow("OnStock"), 0) & "," & IfNull(drRow("Minimum"), 0) & "," & IfNull(drRow("Ordered"), 0))
                        Next
                        sqls.Add("END")

                        '''''''''''export equipment part link
                        tbl = PMSDB.CreateTable("SELECT [EquipmentCode],[PartCode],[ComponentCode],[Number] FROM [dbo].[tblEquipmentPart]")
                        sqls.Add("tblEquipmentPart")
                        For Each drRow In tbl.Rows
                            sqls.Add("'" & drRow("EquipmentCode") & "','" & drRow("PartCode") & "','" & drRow("ComponentCode") & "'," & IfNull(drRow("Number"), 0))
                        Next
                        sqls.Add("END")
                    End If

                    Using sw As New System.IO.StreamWriter(strFile & ".txt", False, System.Text.Encoding.Unicode)
                        Dim strTemp As String
                        For Each strTemp In sqls
                            sw.Write(Shuffle(strTemp, True) & "Ç")
                        Next
                    End Using

                    If ZipFile(strFile & ".txt", strFile & ".pmsf") Then
                        Application.DoEvents()
                        Kill(strFile & ".txt")
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub IMPORTADM_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles IMPORTDATA.ItemClick
        Dim cFile As String, strFile As String
        Dim odMain As New System.Windows.Forms.OpenFileDialog
        odMain.Filter = "PMS File (*.pmsf)|*.pmsf"
        If odMain.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            strFile = odMain.FileName
            cFile = UnzipFile(strFile, GetFileDir(strFile))
            If cFile <> "" Then
                cFile = GetFileDir(strFile) & cFile
                Dim sr As New System.IO.StreamReader(cFile)
                Dim strTag As String = "header", nExpType As String, strDesc As String, sqls As New ArrayList, strLOCID As String
                Dim strLineBuilder As New System.Text.StringBuilder, strLine As String, nTmp As Integer, strTableNames As String = "", strTable As String, strVslCode As String = ""

                While Not sr.EndOfStream
                    nTmp = sr.Read
                    If nTmp = 199 Then
                        strLine = Shuffle(strLineBuilder.ToString, False)
                        Select Case strTag
                            Case "header"
                                strTag = "table"
                                Dim strTemp() As String = strLine.Split("|")
                                nExpType = strTemp(1)
                                strLOCID = strTemp(2)
                                strDesc = strTemp(3)
                                If Not strLOCID.Contains(LOCATION_ID) Then 'Check if the receiver of this export file is this vessel.
                                    MsgBox("Incompatible export file.", vbCritical, GetAppName)
                                    sr.Close()
                                    sr.Dispose()
                                    System.Windows.Forms.Application.DoEvents()
                                    Kill(cFile)
                                    Exit Sub
                                End If
                                sqls.Add("EXEC [dbo].[CLEARIMPDATA] @nExpItem=" & nExpType)
                            Case "table"
                                strTag = "data"
                                strTable = strLine
                            Case "data"
                                If strLine = "END" Then
                                    strTag = "table"
                                Else
                                    sqls.Add("INSERT INTO dbo.imp_" & strTable & " VALUES(" & strLine & ")")
                                End If
                        End Select
                        strLineBuilder.Clear()
                    Else
                        strLineBuilder.Append(ChrW(nTmp))
                    End If
                End While
                sr.Close()
                sr.Dispose()
                System.Windows.Forms.Application.DoEvents()
                Kill(cFile)
                sqls.Add("EXEC [dbo].[IMPORTDATA] @nExpItem =" & nExpType & ", @strVslCode ='" & IMO_NUMBER & "', @strDesc ='" & strDesc & "', @strFileName ='" & strFile & "', @bIsAuto =0")
                PMSDB.RunSqls(sqls)

                'UNCOMMENT TO DEBUG
                'Using sw As New System.IO.StreamWriter(GetFileDir(cFile) & GetFileNameWithoutExtension(cFile) & ".sql", False, System.Text.Encoding.Unicode)
                '    sw.Write(strSQL)
                'End Using                
            End If
        End If
    End Sub

    Private Sub IMPORTADM_ItemClick_old(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) ' Handles IMPORTADM.ItemClick
        Dim cFile As String, strFile As String
        Dim odMain As New System.Windows.Forms.OpenFileDialog
        odMain.Filter = "PMS File (*.pmsf)|*.pmsf"
        If odMain.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            strFile = odMain.FileName
            cFile = UnzipFile(strFile, GetFileDir(strFile))
            If cFile <> "" Then
                cFile = GetFileDir(strFile) & cFile
                Dim strTag As String = "header", nExpType As String, strDesc As String, strVslCode As String, sqls As New ArrayList
                Dim sr As New System.IO.StreamReader(cFile)
                Dim strLineBuilder As New System.Text.StringBuilder, strLine As String, nTmp As Integer, strTableNames As String = "", strTable As String
                sqls.Add("EXEC [dbo].[CLEARIMPDATA]")
                While Not sr.EndOfStream
                    nTmp = sr.Read
                    If nTmp = 199 Then
                        strLine = Shuffle(strLineBuilder.ToString, False)
                        Select Case strTag
                            Case "header"
                                strTag = "table"
                                Dim strTemp() As String = strLine.Split("|")
                                strVslCode = strTemp(0)
                                nExpType = strTemp(1)
                                strDesc = strTemp(2)
                            Case "table"
                                strTag = "data"
                                strTable = strLine
                            Case "data"
                                If strLine = "END" Then
                                    strTag = "table"
                                Else
                                    sqls.Add("INSERT INTO dbo.imp_" & strTable & " VALUES(" & strLine & ")")
                                End If
                        End Select
                        strLineBuilder.Clear()
                    Else
                        strLineBuilder.Append(ChrW(nTmp))
                    End If
                End While
                sr.Close()
                sr.Dispose()
                System.Windows.Forms.Application.DoEvents()
                Kill(cFile)
                sqls.Add("EXEC [dbo].[IMPORTDATA] @nExpItem = " & nExpType & ", @strVslCode = '" & strVslCode & "', @strDesc = '" & strDesc & "', @strFileName = '" & strFile & "', @bIsAuto=0")
                PMSDB.RunSqls(sqls)
            End If

        End If
    End Sub

    Private Sub bbWOMaintenance_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbWOMaintenance.ItemClick
        CURRENT_WOMAINTENANCE = bbWOMaintenance.Down
        mainlist.SetFilter("")
        maincontent.RefreshData()
    End Sub

    Private Sub bbCounterHistory_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        maincontent.ExecCustomFunction(New Object() {"View"})
    End Sub


    Private Sub VESSELINFO_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles VESSELINFO.ItemClick
        Dim frm As New frmVesselInfo
        PMSDB.BeginReader("SELECT TOP 1 * FROM [dbo].[VESSELINFO]")
        If PMSDB.Read Then
            frm.txtVessel.EditValue = PMSDB.ReaderItem("Vessel")
            frm.Type.EditValue = PMSDB.ReaderItem("VslTypeCode", "")
            frm.Flag.EditValue = PMSDB.ReaderItem("Flag", "")
            frm.txtEmail.EditValue = PMSDB.ReaderItem("Email", "")
            frm.txtImo.EditValue = IMO_NUMBER
        End If
        PMSDB.CloseReader()
        frm.txtImo.Enabled = False
        frm.ShowDialog()
    End Sub

    Private Sub bbCopy_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbCopy.ItemClick
        maincontent.ExecCustomFunction(New Object() {"Copy"})
    End Sub

    Private Sub bbInitMaintenance_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        maincontent.ExecCustomFunction(New Object() {"Init"})
    End Sub

    Private Sub bbCopyMaintenance_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbCopyMaintenance.ItemClick
        maincontent.ExecCustomFunction(New Object() {"CopyMaintenance"})
    End Sub

    Private Sub bbShowComponents_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbShowComponents.ItemClick
        If bbShowComponents.Down Then
            bbShowComponents.Caption = "Hide" & Environment.NewLine & "Components"
            maincontent.ExecCustomFunction(New Object() {"ShowComponent", "True"})
        Else
            bbShowComponents.Caption = "Show" & Environment.NewLine & "Components"
            maincontent.ExecCustomFunction(New Object() {"ShowComponent", "False"})
            If IfNull(ledMainUnits.EditValue, "") = "EMPTY" Then
                ledMainUnits.EditValue = ""
            End If
        End If

    End Sub

    Private Sub bbAddPlannedDate_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbAddPlannedDate.ItemClick
        maincontent.ExecCustomFunction(New Object() {"EditDate"})
    End Sub

    Private Sub bbShowAllMaintenance_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbShowAllMaintenance.ItemClick
        CURRENT_SHOW_ALL_CHECKED = bbShowAllMaintenance.Down
        If CURRENT_SHOW_ALL_CHECKED Then
            bbShowAllMaintenance.Caption = "Show Due" & Environment.NewLine & "Maintenance"
            CURRENT_CONDITION_CHECKED = False
            bbCondition.Down = False
            bbCondition.Caption = "Condition Based"
        Else
            bbShowAllMaintenance.Caption = "Show All" & Environment.NewLine & "Maintenance"
        End If
        maincontent.RefreshData()
    End Sub

    Private Sub bbPreventive_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbCondition.ItemClick
        CURRENT_CONDITION_CHECKED = bbCondition.Down
        bbCondition.Caption = IIf(bbCondition.Down, "Preventive", "Condition Based")
        If CURRENT_CONDITION_CHECKED Then
            CURRENT_SHOW_ALL_CHECKED = False
            bbShowAllMaintenance.Down = False
        End If
        maincontent.RefreshData()
    End Sub

    Private Sub bbViewImage_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbViewImage.ItemClick
        maincontent.ExecCustomFunction(New Object() {"ViewImage"})
    End Sub

    Private Sub bbImport_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        maincontent.ExecCustomFunction(New Object() {"Import"})
    End Sub

    Private Sub bbPaste_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbPaste.ItemClick
        mainlist.ExecCustomFunction(New Object() {"Paste"})
    End Sub

    Private Sub bbImportFromFile_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbImportFromFile.ItemClick
        mainlist.ExecCustomFunction(New Object() {"PasteFromFile"})
    End Sub

    Private Sub bbCritical_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbCritical.ItemClick
        CURRENT_CRITICAL_CHECKED = bbCritical.Down
        If maincontent.Name = "PART" Then
            mainlist.SetFilter("")
        ElseIf maincontent.Name = "PARTPURCHASE" Then
            maincontent.ExecCustomFunction(New Object() {"FilterCriticalParts"})
        Else
            If maincontent.Name = "WORKDONE" Then mainlist.SetFilter("")
            maincontent.RefreshData()
        End If
    End Sub

    Private Sub bbFlatView_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbFlatView.ItemClick
        CURRENT_FLATVIEW_CHECKED = bbFlatView.Down
        bbFlatView.Caption = IIf(CURRENT_FLATVIEW_CHECKED, "Tree View", "Flat View")
        'If maincontent.Name = "WORKDONE" Then mainlist.SetFilter("")
        MainPanel.PanelVisibility = IIf(CURRENT_FLATVIEW_CHECKED, DevExpress.XtraEditors.SplitPanelVisibility.Panel2, DevExpress.XtraEditors.SplitPanelVisibility.Both)
        maincontent.RefreshData()
    End Sub

    Private Sub bbUserPreferences_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbUserPreferences.ItemClick
        Dim frm As New frmUserPref
        frm.ShowDialog()
        If frm.IS_SAVED Then
            If PMSDB.DLookUp("[User ID]", "tblSec_Users_Pref", "", "[User ID]=" & USER_ID) = "" Then
                PMSDB.RunSql("INSERT INTO dbo.tblSec_Users_Pref VALUES(" & USER_ID & "," & FONT_INCREASE & ", " & CURRENT_DUEDAYS & "," & CURRENT_DUEHOURS & "," & IIf(CURRENT_SHOW_WARNING, 1, 0) & "," & IIf(CURRENT_FLATVIEW_CHECKED, 1, 0) & ",'" & CURRENT_RANK & "')")
            Else
                PMSDB.RunSql("UPDATE dbo.tblSec_Users_Pref SET [FontSizeAdjustment]=" & FONT_INCREASE & ",[DueDays]=" & CURRENT_DUEDAYS & ",[DueHours]=" & CURRENT_DUEHOURS & ",[ShowUnitsWarning]=" & IIf(CURRENT_SHOW_WARNING, 1, 0) & ",[FlatView]=" & IIf(CURRENT_FLATVIEW_CHECKED, 1, 0) & ",[RankCode]='" & CURRENT_RANK & "' WHERE [User ID]=" & USER_ID)
            End If
            ledRank.EditValue = CURRENT_RANK
            txtDateDue.EditValue = CURRENT_DUEDAYS
            txtDueHours.EditValue = CURRENT_DUEHOURS
            bbFlatView.Down = CURRENT_FLATVIEW_CHECKED
            bbFlatView.Caption = IIf(CURRENT_FLATVIEW_CHECKED, "Tree View", "Flat View")
            If maincontent.Name = "WORKDONE" Then
                MainPanel.PanelVisibility = IIf(CURRENT_FLATVIEW_CHECKED, DevExpress.XtraEditors.SplitPanelVisibility.Panel2, DevExpress.XtraEditors.SplitPanelVisibility.Both)
                maincontent.RefreshData()
            End If
        End If
        DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = GetDefaultFont()
        DevExpress.XtraEditors.WindowsFormsSettings.DefaultMenuFont = GetDefaultFont()
        dbdController.Controller.AppearancesBar.ItemsFont = GetDefaultFont()
    End Sub

    Private Sub EXPDOCUMENTS_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles EXPDOCUMENTS.ItemClick
        Dim nExpType As Integer = 4, frm As New frmExportDocuments
        frm.txtExportDir.EditValue = EXPORT_DIR
        frm.lblLastExp.Text = ChangeSQLDateStrToDate(DATE_LAST_EXPORT_IMG).ToShortDateString
        frm.MainGrid.DataSource = PMSDB.CreateTable("SELECT *, CAST(0 AS BIT) Selected FROM dbo.DOCUMENTLIST WHERE DocType = 'WORKDONE' ORDER BY DateUpdated DESC")
        frm.ShowDialog()
        If frm.bExported Then
            EXPORT_DIR = frm.txtExportDir.EditValue
            ExportPMSDocuments(PMSDB, frm.txtExportDir.EditValue & "\PMS_Documents_" & Now.ToString("yyyyMMddhhmm") & ".xxx", frm.strDocs)
            PMSDB.SaveConfig("EXPORT_DIR", EXPORT_DIR, APP_SHORT_NAME)
            PMSDB.SaveConfig("DATE_LAST_EXPORT_IMG", DATE_LAST_EXPORT_IMG, APP_SHORT_NAME)
        End If
    End Sub

    Private Sub cmdHelp_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdHelp.ItemClick
        Dim frm As New frmHelp
        If maincontent.strHelpUrl = "" Then
            If System.IO.File.Exists(GetAppPath() & "\Help\1.pdf") Then
                frm.LoadPDF(GetAppPath() & "\Help\1.pdf", 1)
            Else
                MsgBox("Unable to locate default help file.", MsgBoxStyle.Critical, GetAppPath)
            End If
        Else
            Dim strHelp() As String = maincontent.strHelpUrl.Split(";"c)
            frm.LoadPDF(GetAppPath() & "\Help\" & strHelp(0), strHelp(1))
        End If
        frm.ShowDialog()
    End Sub

    Private Sub REFRESH_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles REFRESH.ItemClick
        maincontent.DataRefresh()
    End Sub

    Private Sub cmdReportPreview_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdReportPreview.ItemClick
        maincontent.ExecCustomFunction(New Object() {"PREVIEWREPORT", Me.chkAuditWithDetails.Checked})
    End Sub
End Class
