Imports System.Drawing

Public Class WORKDUE
    Public Sub SaveLayout(ByVal fileName As String)
        MainView.SaveLayoutToXml(fileName)
    End Sub

    Public Overrides Sub ExecCustomFunction(ByVal param() As Object)
        Select Case param(0)
            Case "ViewImage"
                Dim frm As New frmImageViewer
                frm.imgLogo.BackgroundImage = StringToImage(DB.DLookUp("ImageDoc", "tblAdmMaintenance", "", "MaintenanceCode='" & MainView.GetFocusedRowCellValue("MaintenanceCode") & "'"))
                frm.ShowDialog()
            Case "SaveLayout"
                MainView.SaveLayoutToXml(param(1))
            Case "RestoreLayout"
                If System.IO.File.Exists(param(1)) Then
                    MainView.RestoreLayoutFromXml(param(1))
                End If
            Case "Preview"
                RaiseCustomEvent(Name, New Object() {"Preview", "DUEWORK", "PMSReports", MainGrid.DataSource})
            Case "Edit"
                EditData()
            Case "EditDate"
                EditDate()
        End Select
    End Sub

    Private Sub EditDate()
        Dim frm As New frmPlannedDate, bAdd As Boolean = True
        If Not MainView.GetFocusedRowCellValue("PlannedDate") Is System.DBNull.Value Then
            bAdd = False
            frm.txtPlannedDate.EditValue = MainView.GetFocusedRowCellValue("PlannedDate")
            frm.txtReason.EditValue = MainView.GetFocusedRowCellValue("Reason")
            frm.txtApprovedBy.EditValue = MainView.GetFocusedRowCellValue("ApprovedBy")
        End If
        frm.ShowDialog()
        If frm.IS_SAVED Then
            If bAdd Then
                DB.RunSql("INSERT INTO dbo.tblPlannedWork VALUES(" & MainView.GetFocusedRowCellValue("MaintenanceWorkID") & "," & ChangeToSQLDate(frm.txtPlannedDate.EditValue) & ",'" & frm.txtReason.EditValue.ToString.Replace("'", "''") & "', '" & frm.txtApprovedBy.EditValue.ToString.Replace("'", "''") & "')")
            Else
                DB.RunSql("UPDATE dbo.tblPlannedWork SET PlannedDate=" & ChangeToSQLDate(frm.txtPlannedDate.EditValue) & ", Reason='" & frm.txtReason.EditValue.ToString.Replace("'", "''") & "', ApprovedBy='" & frm.txtApprovedBy.EditValue.ToString.Replace("'", "''") & "' WHERE MaintenanceWorkID=" & MainView.GetFocusedRowCellValue("MaintenanceWorkID"))
            End If
            MainView.SetRowCellValue(MainView.FocusedRowHandle, "PlannedDate", frm.txtPlannedDate.EditValue)
            MainView.SetRowCellValue(MainView.FocusedRowHandle, "Reason", frm.txtReason.EditValue)
            MainView.SetRowCellValue(MainView.FocusedRowHandle, "ApprovedBy", frm.txtApprovedBy.EditValue)
            MainView.RefreshRow(MainView.FocusedRowHandle)
        End If
    End Sub

    Private Sub EditData()
        If Not MainView.IsGroupRow(MainView.FocusedRowHandle) Then
            Dim frm As New frmWork, sqls As New ArrayList
            frm.db = DB
            frm.bGetPrevWork = False
            frm.Text = "Edit " & MainView.GetFocusedRowCellValue("UnitDesc") & " maintenance."
            frm.cboUnit.Properties.DataSource = DB.CreateTable("[dbo].[GETCOMPONENT]  @strUnitCode='" & MainView.GetFocusedRowCellValue("UnitCode") & "'")
            frm.cboUnit.ReadOnly = True
            frm.cboUnit.EditValue = MainView.GetFocusedRowCellValue("UnitCode")
            frm.cboRankCode.Properties.DataSource = AdmRank
            frm.cboMaintenance.EditValue = MainView.GetFocusedRowCellValue("MaintenanceCode")
            frm.cboMaintenance.ReadOnly = True
            frm.cboRankCode.EditValue = MainView.GetFocusedRowCellValue("RankCode")
            frm.txtExecutedBy.EditValue = MainView.GetFocusedRowCellValue("ExecutedBy")
            frm.txtPDate.EditValue = MainView.GetFocusedRowCellValue("WorkDate")
            frm.txtPRunningHours.EditValue = MainView.GetFocusedRowCellValue("WorkCounter")
            frm.txtPExec.EditValue = MainView.GetFocusedRowCellValue("ExecutedBy")
            frm.txtPRemarks.EditValue = MainView.GetFocusedRowCellValue("Remarks")
            If IfNull(MainView.GetFocusedRowCellValue("RunningHours"), 0) > 0 Then
                frm.lblRunningHours.Text = "Running Hours: " & MainView.GetFocusedRowCellValue("RunningHours")
                frm.lblReadingDate.Text = "Latest Reading: " & CDate(MainView.GetFocusedRowCellValue("ReadingDate")).ToShortDateString
            End If
            frm.ShowDialog()
            If frm.IS_SAVED Then
                Dim strDueCounter As String = "null", strDateDue As String = "null", strCounter As String = "null"
                Select Case frm.strIntCode
                    Case "SYSHOURS"
                        strCounter = frm.txtWorkCounter.EditValue.ToString
                        strDueCounter = frm.txtWorkCounter.EditValue + frm.nInterval
                    Case "SYSDAYS"
                        strDateDue = ChangeToSQLDate(CDate(frm.txtWorkDate.EditValue).AddDays(frm.nInterval))
                    Case "SYSWEEKS"
                        strDateDue = ChangeToSQLDate(CDate(frm.txtWorkDate.EditValue).AddDays(frm.nInterval * 7))
                    Case "SYSMONTHS"
                        strDateDue = ChangeToSQLDate(CDate(frm.txtWorkDate.EditValue).AddMonths(frm.nInterval))
                    Case "SYSYEARS"
                        strDateDue = ChangeToSQLDate(CDate(frm.txtWorkDate.EditValue).AddYears(frm.nInterval))
                End Select
                sqls.Add("UPDATE dbo.tblMaintenanceWork SET bLatest=0 WHERE [UnitCode]='" & frm.cboUnit.EditValue & "' AND [MaintenanceCode]='" & frm.cboMaintenance.EditValue & "'")
                sqls.Add("Insert Into dbo.tblMaintenanceWork([UnitCode],[MaintenanceCode],[ExecutedBy],[RankCode],[WorkDate],[WorkCounter],[Remarks],[DueCounter],[DueDate],[LastUpdatedBy],bNC) Values('" & MainView.GetFocusedRowCellValue("UnitCode") & "', '" & frm.cboMaintenance.EditValue & "', '" & frm.txtExecutedBy.EditValue.ToString.Replace("'", "''") & "', '" & frm.cboRankCode.EditValue & "'," & ChangeToSQLDate(frm.txtWorkDate.EditValue) & "," & strCounter & ",'" & frm.txtRemarks.EditValue.ToString.Replace("'", "''") & "'," & strDueCounter & "," & strDateDue & ",'" & GetUserName() & "',0)")
                DB.RunSqls(sqls)
                MainView.DeleteRow(MainView.FocusedRowHandle)
            End If
        End If
    End Sub

    'Overriden From Base Control
    Public Overrides Sub AddData()
        Dim frm As New frmWork
        frm.Text = "New " & strDesc & " maintenance."
        frm.cboMaintenance.Properties.DataSource = DB.CreateTable("SELECT [MaintenanceCode],[RankCode],[WorkDescription],Interval ,[Interval],[IntDue],[IntCode],[Number] FROM [dbo].[COMPONENT_MAINTENANCELIST] WHERE ComponentCode='" & blList.GetFocusedRowData("ComponentCode") & "' OR LEFT(MaintenanceCode,3)='SYS' ORDER BY SortCode, WorkDescription")
        frm.cboRankCode.Properties.DataSource = AdmRank


        frm.ShowDialog()
        If frm.IS_SAVED Then
            Dim strDueCounter As String = "null", strDateDue As String = "null", strCounter As String = "null"
            Select Case frm.strIntCode
                Case "SYSHOURS"
                    strCounter = frm.txtWorkCounter.EditValue.ToString
                    strDueCounter = frm.txtWorkCounter.EditValue + frm.nInterval
                Case "SYSDAYS"
                    strDateDue = ChangeToSQLDate(CDate(frm.txtWorkDate.EditValue).AddDays(frm.nInterval))
                Case "SYSWEEKS"
                    strDateDue = ChangeToSQLDate(CDate(frm.txtWorkDate.EditValue).AddDays(frm.nInterval * 7))
                Case "SYSMONTHS"
                    strDateDue = ChangeToSQLDate(CDate(frm.txtWorkDate.EditValue).AddMonths(frm.nInterval))
                Case "SYSYEARS"
                    strDateDue = ChangeToSQLDate(CDate(frm.txtWorkDate.EditValue).AddYears(frm.nInterval))
            End Select
            DB.RunSql("Insert Into dbo.tblMaintenanceWork([UnitCode],[MaintenanceCode],[ExecutedBy],[RankCode],[WorkDate],[WorkCounter],[Remarks],[DueCounter],[DueDate],[LastUpdatedBy],bNC) Values('" & strID & "', '" & frm.cboMaintenance.EditValue & "', '" & frm.txtExecutedBy.EditValue.ToString.Replace("'", "''") & "', '" & frm.cboRankCode.EditValue & "'," & ChangeToSQLDate(frm.txtWorkDate.EditValue) & "," & strCounter & ",'" & frm.txtRemarks.EditValue.ToString.Replace("'", "''") & "'," & strDueCounter & "," & strDateDue & ",'" & GetUserName() & "',0)")
        End If
        RefreshData()
    End Sub

    'Overriden From Base Control
    Public Overrides Function GetDesc() As String
        Return "Unit - " & strDesc
    End Function

    'Overriden From Base Control
    Public Overrides Sub RefreshData()
        If Not bLoaded Then
            AllowAddition(Name, (bPermission And 2) > 0)
            AllowDeletion(Name, (bPermission And 8) > 0)
            AddEditListener(Me.header)
            bLoaded = True
            RankEdit.DataSource = AdmRank
        End If
        SetSaveVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetDeleteVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        Me.header.Text = "DUE MAINTENANCE"
        MainGrid.DataSource = DB.CreateTable("EXEC dbo.[GETDUEWORK] @nPeriod = " & CURRENT_PERIOD & ", @dDate =" & CURRENT_DUEDAYS & ", @nHours = " & CURRENT_DUEHOURS & ", @strRankCode='" & CURRENT_RANK & "', @strDeptCode='" & CURRENT_DEPARTMENT & "', @strCatCode='" & CURRENT_CATEGORY & "', @bPreventive=" & IIf(CURRENT_CONDITION_CHECKED, 0, 1))
        DueCounter.Visible = Not CURRENT_CONDITION_CHECKED
        DueDate.Visible = Not CURRENT_CONDITION_CHECKED
        Interval.Visible = Not CURRENT_CONDITION_CHECKED
        MainView.BeginSort()
        MainView.Columns("GroupID").GroupIndex = 0
        MainView.EndSort()
        MainView.ExpandAllGroups()
        MainView.TopRowIndex = 0
    End Sub

    Private Sub MainView_Click(sender As Object, e As System.EventArgs) Handles MainView.Click
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim pt As Drawing.Point = view.GridControl.PointToClient(System.Windows.Forms.Control.MousePosition)
        Dim info As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(pt)
        If (info.HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowIndicator) Then
            Dim frm As New frmImageViewer
            frm.imgLogo.BackgroundImage = StringToImage(DB.DLookUp("ImageDoc", "tblAdmMaintenance", "", "MaintenanceCode='" & MainView.GetFocusedRowCellValue("MaintenanceCode") & "'"))
            frm.ShowDialog()
        End If
    End Sub

    Private Sub MainView_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles MainView.CustomDrawRowIndicator
        If MainView.GetRowCellValue(e.RowHandle, "HasImage") Then
            e.Info.ImageIndex = -1
            e.Painter.DrawObject(e.Info)
            e.Graphics.DrawImage(DevExpress.Images.ImageResourceCache.Default.GetImage("images/mail/attachment_16X16.png".ToLower().Replace(" ", "%20")), New RectangleF(e.Bounds.X + 1, e.Bounds.Y + 1, e.Bounds.Width - 2, e.Bounds.Height - 2))
            e.Handled = True
        End If
    End Sub

    Private Sub MainView_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles MainView.FocusedRowChanged
        If MainView.FocusedRowHandle >= 0 Then
            If bLoaded Then
                CURRENT_WORK = IfNull(MainView.GetRowCellValue(MainView.FocusedRowHandle, "MaintenanceWorkID"), -1)
                RaiseCustomEvent(Name, New Object() {"EnableEdit", "TRUE"})
                RaiseCustomEvent(Name, New Object() {"EnableImageViewer", IIf(MainView.GetRowCellValue(MainView.FocusedRowHandle, "HasImage"), "True", "False")})
            End If
        Else
            RaiseCustomEvent(Name, New Object() {"EnableEdit", "FALSE"})
            RaiseCustomEvent(Name, New Object() {"EnableImageViewer", "False"})
        End If
    End Sub

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub MainViewnRowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
        If e.RowHandle = MainView.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        End If
        If Not CURRENT_CONDITION_CHECKED Then
            If e.Column.Name = "UnitDesc" Then
                If MainView.GetRowCellValue(e.RowHandle, "IsDue") Then
                    e.Appearance.ForeColor = Drawing.Color.Red
                Else
                    e.Appearance.ForeColor = Drawing.Color.Blue
                End If
            End If
        End If
    End Sub

    Public Overrides Sub DeleteData()
        If Not MainView.IsGroupRow(MainView.FocusedRowHandle) Then
            If MsgBox("Are you sure want to remove the <" & IfNull(MainView.GetFocusedRowCellDisplayText("Maintenance"), "New Record") & "> Work Record?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If Not MainView.GetFocusedRowCellValue("MaintenanceWorkID") Is System.DBNull.Value Then
                    Dim sqls As New ArrayList
                    sqls.Add("DELETE FROM dbo.tblMaintenanceWork WHERE MaintenanceWorkID=" & MainView.GetFocusedRowCellValue("MaintenanceWorkID"))
                    sqls.Add("DELETE FROM dbo.tblNC WHERE MaintenanceWorkID=" & MainView.GetFocusedRowCellValue("MaintenanceWorkID"))
                    DB.RunSqls(sqls)
                End If
                RefreshData()
            End If
        End If
    End Sub

    Private Sub MainView_DoubleClick(sender As Object, e As System.EventArgs) Handles MainView.DoubleClick
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim pt As Drawing.Point = view.GridControl.PointToClient(System.Windows.Forms.Control.MousePosition)
        Dim info As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(pt)
        If (info.InRow Or info.InRowCell) Then
            EditData()
        End If
    End Sub

    Private Sub MainView_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles MainView.MouseUp
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim pt As Drawing.Point = view.GridControl.PointToClient(System.Windows.Forms.Control.MousePosition)
        Dim info As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(pt)
        If (info.InRow Or info.InRowCell) Then
            If e.Button = Windows.Forms.MouseButtons.Right Then
                OnRightClick(Name)
            End If
        End If
    End Sub

End Class