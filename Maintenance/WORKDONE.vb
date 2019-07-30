Imports System.Drawing

Public Class WORKDONE
    Dim strNCSql As String = "", ncSQLs As New ArrayList

    Public Overrides Sub ExecCustomFunction(ByVal param() As Object)
        Select Case param(0)
            Case "ViewImage"
                Dim frm As New frmImageViewer
                frm.imgLogo.BackgroundImage = StringToImage(MainView.GetFocusedRowCellValue("ImageDoc"))
                frm.ShowDialog()
            Case "Preview"
                If MainView.RowCount = 0 Then
                    MsgBox("Please select at least one record to preview.", MsgBoxStyle.Information, GetAppName)
                Else
                    RaiseCustomEvent(Name, New Object() {"Preview", "WORKRECORD", "PMSReports", "|" & strID & "|"})
                End If
            Case "COPY"
                CopyData()
            Case "EditNC"
                EditNC()
            Case "Edit"
                EditData()
        End Select
    End Sub

    Sub CopyData()
        If CURRENT_WORK > 0 Then
            If MainView.GetRowCellValue(MainView.FocusedRowHandle, "MaintenanceWorkID") = CURRENT_WORK Then
                Dim strMaintenanceCode As String = MainView.GetRowCellValue(MainView.FocusedRowHandle, "MaintenanceCode"), strRankCode As String = MainView.GetRowCellValue(MainView.FocusedRowHandle, "RankCode"), dDateDue As Object = MainView.GetRowCellValue(MainView.FocusedRowHandle, "DueDate")
                MainView.AddNewRow()
                MainView.SetFocusedRowCellValue("MaintenanceCode", strMaintenanceCode)
                MainView.SetFocusedRowCellValue("RankCode", strRankCode)
                MainView.SetFocusedRowCellValue("WorkDate", dDateDue)
            End If
        End If

    End Sub

    Private Sub EditData()
        Dim frm As New frmWork
        frm.Text = "Edit " & strDesc & " maintenance."
        frm.db = DB
        frm.cboUnit.Properties.DataSource = DB.CreateTable("[dbo].[GETCOMPONENT] @strUnitCode='" & strID & "'")
        frm.cboUnit.ReadOnly = True
        frm.cboUnit.EditValue = MainView.GetFocusedRowCellValue("UnitCode")
        frm.cboRankCode.Properties.DataSource = AdmRank
        frm.cboMaintenance.EditValue = MainView.GetFocusedRowCellValue("MaintenanceCode")
        frm.cboMaintenance.Enabled = False
        frm.cboMaintenance.ReadOnly = True
        frm.cboRankCode.EditValue = MainView.GetFocusedRowCellValue("RankCode")
        frm.txtWorkDate.EditValue = MainView.GetFocusedRowCellValue("WorkDate")
        frm.txtExecutedBy.EditValue = MainView.GetFocusedRowCellValue("ExecutedBy")
        frm.txtWorkCounter.EditValue = MainView.GetFocusedRowCellValue("WorkCounter")
        frm.txtRemarks.EditValue = MainView.GetFocusedRowCellValue("Remarks")
        frm.nMaintenanceID = MainView.GetFocusedRowCellValue("MaintenanceWorkID")
        If IfNull(MainView.GetFocusedRowCellValue("ImageDoc"), "") <> "" Then
            frm.imgLogo.BackgroundImage = StringToImage(MainView.GetFocusedRowCellValue("ImageDoc"))
        End If
        frm.ShowDialog()
        If frm.IS_SAVED Then
            Dim strDueCounter As String = "null", dDueDate As Date, strDateDue As String = "null", strCounter As String = "null", i As Integer, sqls As New ArrayList, strImage As String = ""
            If IfNull(frm.txtWorkCounter.EditValue, 0) > 0 Then
                strCounter = frm.txtWorkCounter.EditValue.ToString
            End If
            Select Case frm.strIntCode
                Case "SYSHOURS"
                    Dim nHoursPerDay As Double = IfNull(blList.GetFocusedRowData("HoursPerDay"), 0)
                    If nHoursPerDay > 0 Then
                        nHoursPerDay = CDbl(frm.nInterval) / nHoursPerDay
                        dDueDate = CDate(frm.txtWorkDate.EditValue).AddDays(CInt(nHoursPerDay))
                        strDateDue = ChangeToSQLDate(dDueDate)
                    End If
                    strDueCounter = frm.txtWorkCounter.EditValue + frm.nInterval
                Case "SYSDAYS"
                    dDueDate = CDate(frm.txtWorkDate.EditValue).AddDays(frm.nInterval)
                    strDateDue = ChangeToSQLDate(dDueDate)
                Case "SYSWEEKS"
                    dDueDate = CDate(frm.txtWorkDate.EditValue).AddDays(frm.nInterval * 7)
                    strDateDue = ChangeToSQLDate(dDueDate)
                Case "SYSMONTHS"
                    dDueDate = CDate(frm.txtWorkDate.EditValue).AddMonths(frm.nInterval)
                    strDateDue = ChangeToSQLDate(dDueDate)
                Case "SYSYEARS"
                    dDueDate = CDate(frm.txtWorkDate.EditValue).AddYears(frm.nInterval)
                    strDateDue = ChangeToSQLDate(dDueDate)
            End Select
            If Not frm.imgLogo.BackgroundImage Is Nothing Then strImage = ImageToString(frm.imgLogo.BackgroundImage)
            sqls.Add("Update dbo.tblMaintenanceWork set ExecutedBy='" & frm.txtExecutedBy.EditValue.ToString.Replace("'", "''") & "', RankCode='" & frm.cboRankCode.EditValue & "', WorkDate=" & ChangeToSQLDate(frm.txtWorkDate.EditValue) & ", WorkCounter=" & strCounter & ", Remarks='" & frm.txtRemarks.EditValue.ToString.Replace("'", "''") & "', DueCounter=" & strDueCounter & ", DueDate=" & strDateDue & ", ImageDoc='" & strImage & "', LastUpdatedBy='" & GetUserName() & "' Where MaintenanceWorkID=" & MainView.GetFocusedRowCellValue("MaintenanceWorkID"))

            frm.MainView.CloseEditor()
            frm.MainView.UpdateCurrentRow()
            For i = 0 To frm.MainView.RowCount - 1
                If frm.MainView.GetRowCellValue(i, "Edited") Then
                    If IfNull(frm.MainView.GetRowCellValue(i, "PartConsumptionID"), 0) > 0 Then
                        sqls.Add("UPDATE [dbo].[tblPartConsumption] SET Number=" & frm.MainView.GetRowCellValue(i, "Number") & " WHERE PartConsumptionID=" & frm.MainView.GetRowCellValue(i, "PartConsumptionID"))
                    Else
                        sqls.Add("INSERT INTO [dbo].[tblPartConsumption]([PartCode],[MaintenanceWorkID],[DateConsumed],[Number],[Remarks])" & _
                        "SELECT '" & frm.MainView.GetRowCellValue(i, "PartCode") & "',[MaintenanceWorkID],[WorkDate]," & frm.MainView.GetRowCellValue(i, "Number") & ",'" & strDesc & " - " & frm.cboMaintenance.Text & "' FROM [dbo].[tblMaintenanceWork] WHERE UnitCode='" & frm.cboUnit.EditValue & "' AND MaintenanceCode='" & frm.cboMaintenance.EditValue & "' AND bLatest=1")
                    End If
                End If
            Next

            DB.RunSqls(sqls)
            MainView.SetRowCellValue(MainView.FocusedRowHandle, "RankCode", frm.cboRankCode.EditValue)
            MainView.SetRowCellValue(MainView.FocusedRowHandle, "WorkDate", frm.txtWorkDate.EditValue)
            MainView.SetRowCellValue(MainView.FocusedRowHandle, "ExecutedBy", frm.txtExecutedBy.EditValue)
            MainView.SetRowCellValue(MainView.FocusedRowHandle, "WorkCounter", frm.txtWorkCounter.EditValue)
            MainView.SetRowCellValue(MainView.FocusedRowHandle, "Remarks", frm.txtRemarks.EditValue)
            If strDueCounter <> "null" Then MainView.SetRowCellValue(MainView.FocusedRowHandle, "DueCounter", strDueCounter)
            If strDateDue <> "null" Then MainView.SetRowCellValue(MainView.FocusedRowHandle, "DueDate", dDueDate)
            If frm.bImageUpdated Then
                If frm.imgLogo.BackgroundImage Is Nothing Then
                    MainView.SetRowCellValue(MainView.FocusedRowHandle, "ImageDoc", "")
                Else
                    MainView.SetRowCellValue(MainView.FocusedRowHandle, "ImageDoc", ImageToString(frm.imgLogo.BackgroundImage))
                End If
            End If
            MainView.RefreshRow(MainView.FocusedRowHandle)
        End If
    End Sub

    'Overriden From Base Control
    Public Overrides Sub AddData()
        Dim frm As New frmWork, sqls As New ArrayList
        frm.Text = "New " & strDesc & " maintenance."
        frm.db = DB
        frm.cboUnit.Properties.DataSource = DB.CreateTable("EXEC dbo.GETCOMPONENT @strUnitCode='" & strID & "'")
        frm.cboUnit.ReadOnly = DB.RecordCount = 1
        frm.cboUnit.EditValue = strID
        frm.cboRankCode.Properties.DataSource = AdmRank
        frm.ShowDialog()
        If frm.IS_SAVED Then
            Dim strDueCounter As String = "null", strDateDue As String = "null", strCounter As String = "null", i As Integer, strImage As String = ""
            Select Case frm.strIntCode
                Case "SYSHOURS"
                    Dim nHoursPerDay As Double = IfNull(blList.GetFocusedRowData("HoursPerDay"), 0)
                    If nHoursPerDay > 0 Then
                        Dim dDueDate As Date
                        nHoursPerDay = CDbl(frm.nInterval) / nHoursPerDay
                        dDueDate = CDate(frm.txtWorkDate.EditValue).AddDays(CInt(nHoursPerDay))
                        strDateDue = ChangeToSQLDate(dDueDate)
                    End If
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
            If Not frm.imgLogo.BackgroundImage Is Nothing Then strImage = ImageToString(frm.imgLogo.BackgroundImage)
            sqls.Add("UPDATE dbo.tblMaintenanceWork SET bLatest=0 WHERE [UnitCode]='" & frm.cboUnit.EditValue & "' AND [MaintenanceCode]='" & frm.cboMaintenance.EditValue & "'")
            sqls.Add("Insert Into dbo.tblMaintenanceWork([UnitCode],[MaintenanceCode],[ExecutedBy],[RankCode],[WorkDate],[WorkCounter],[Remarks],[DueCounter],[DueDate],[LastUpdatedBy],[bNC],[ImageDoc]) Values('" & frm.cboUnit.EditValue & "', '" & frm.cboMaintenance.EditValue & "', '" & frm.txtExecutedBy.EditValue.ToString.Replace("'", "''") & "', '" & frm.cboRankCode.EditValue & "'," & ChangeToSQLDate(frm.txtWorkDate.EditValue) & "," & strCounter & ",'" & frm.txtRemarks.EditValue.ToString.Replace("'", "''") & "'," & strDueCounter & "," & strDateDue & ",'" & GetUserName() & "',0,'" & strImage & "')")
            frm.MainView.CloseEditor()
            frm.MainView.UpdateCurrentRow()
            For i = 0 To frm.MainView.RowCount - 1
                If frm.MainView.GetRowCellValue(i, "Edited") Then
                    sqls.Add("INSERT INTO [dbo].[tblPartConsumption]([PartCode],[MaintenanceWorkID],[DateConsumed],[Number],[Remarks])" & _
                     "SELECT '" & frm.MainView.GetRowCellValue(i, "PartCode") & "',[MaintenanceWorkID],[WorkDate]," & frm.MainView.GetRowCellValue(i, "Number") & ",'" & strDesc & " - " & frm.cboMaintenance.Text & "' FROM [dbo].[tblMaintenanceWork] WHERE UnitCode='" & frm.cboUnit.EditValue & "' AND MaintenanceCode='" & frm.cboMaintenance.EditValue & "' AND bLatest=1")
                End If
            Next
            DB.RunSqls(sqls)
            RefreshData()
        End If
    End Sub

    'Overriden From Base Control
    Public Overrides Function GetDesc() As String
        Return "Unit - " & strDesc
    End Function

    Private Sub MainView_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles MainView.CustomColumnDisplayText
        If e.Column.Name = "Maintenance" Then
            e.DisplayText = e.Value.ToString.Remove(0, 1)
        End If
    End Sub

    'Overriden From Base Control
    Public Overrides Sub RefreshData()
        Dim nCurrWork As Integer = CURRENT_WORK
        strNCSql = ""
        If Not bLoaded Then
            RaiseCustomEvent(Name, New Object() {"RenameNC", "Add/Edit NC"})
            AllowAddition(Name, (bPermission And 2) > 0)
            AllowDeletion(Name, (bPermission And 8) > 0)
            AddEditListener(Me.header)
            bLoaded = True
        End If
        MyBase.RefreshData()
        SetSaveVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        Me.header.Text = "MAINTENANCE DETAILS - " & blList.GetDesc.ToUpper
        MainGrid.DataSource = DB.CreateTable("EXEC dbo.[MAINTENANCEWORK] @strUnitCode='" & strID & "'")
        MainView.BeginSort()
        MainView.Columns("Maintenance").GroupIndex = 1
        MainView.Columns("WorkDate").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
        MainView.EndSort()
        MainView.ExpandAllGroups()
        MainView.TopRowIndex = 0
        If MainView.RowCount > 0 Then
            If nCurrWork >= 0 Then
                Dim RowHandle As Integer = 0
                Dim Col As DevExpress.XtraGrid.Columns.GridColumn = MainView.Columns("MaintenanceWorkID")
                RowHandle = MainView.LocateByValue(0, Col, nCurrWork)
                MainView.FocusedRowHandle = RowHandle
                CURRENT_WORK = nCurrWork
            End If
        End If
        RaiseCustomEvent(Name, New Object() {"EnableEdit", IIf(MainView.FocusedRowHandle > 0, "True", "False")})
    End Sub

    Private Sub MainView_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles MainView.FocusedRowChanged
        If MainView.FocusedRowHandle >= 0 Then
            If bLoaded Then
                CURRENT_WORK = IfNull(MainView.GetRowCellValue(MainView.FocusedRowHandle, "MaintenanceWorkID"), -1)
                RaiseCustomEvent(Name, New Object() {"EnableEdit", "TRUE"})
                RaiseCustomEvent(Name, New Object() {"EnableImageViewer", IIf(MainView.GetRowCellValue(MainView.FocusedRowHandle, "ImageDoc") = "", "False", "True")})
            End If
        Else
            RaiseCustomEvent(Name, New Object() {"EnableEdit", "FALSE"})
            RaiseCustomEvent(Name, New Object() {"EnableImageViewer", "False"})
        End If
    End Sub

    Private Sub header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles header.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            OnRightClick(Name)
        End If
    End Sub

    Private Sub MainView_RowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
        If e.RowHandle = MainView.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
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

    Private Sub EditNC()
        strNCSql = ""
        Dim frm As New frmNC, bNCExist As Boolean = IfNull(MainView.GetFocusedRowCellValue("bNC"), 0), strNCID As String, i As Integer, strDueDate As String = "NULL", strDoneDate As String = "NULL"
        frm.RankEdit.DataSource = AdmRank
        frm.nMaintenanceWorkID = IfNull(MainView.GetFocusedRowCellValue("MaintenanceWorkID"), 0)
        frm.txtWorkDate.EditValue = MainView.GetFocusedRowCellValue("WorkDate")
        frm.txtWorkCounter.EditValue = MainView.GetFocusedRowCellValue("WorkCounter")
        If bNCExist Then
            DB.BeginReader("SELECT * FROM dbo.tblNC WHERE MaintenanceWorkID=" & frm.nMaintenanceWorkID)
            If DB.Read Then
                strNCID = DB.ReaderItem("NCID")
                frm.txtDiscoveredBy.EditValue = DB.ReaderItem("DiscoveredBy", "")
                frm.txtReportedTo.EditValue = DB.ReaderItem("ReportedTo", "")
                frm.txtDescription.EditValue = DB.ReaderItem("Description", "")
                frm.txtImmediateAction.EditValue = DB.ReaderItem("ImmediateAction", "")
                frm.txtCauses.EditValue = DB.ReaderItem("Cause", "")
                frm.txtObjectives.EditValue = DB.ReaderItem("Objective", "")
                frm.txtStatus.EditValue = IIf(DB.ReaderItem("IsStatusClosed", True), "Closed", "Open")
            End If
            DB.CloseReader()
            frm.MainGrid.DataSource = DB.CreateTable("SELECT *, CAST(0 AS BIT) Edited FROM dbo.tblNCCorrectiveMeasure WHERE NCID='" & strNCID & "'")
        Else
            frm.txtDiscoveredBy.EditValue = MainView.GetFocusedRowCellValue("ExecutedBy")
            frm.txtReportedTo.EditValue = ""
            frm.txtObjectives.EditValue = ""
            frm.txtCauses.EditValue = ""
            frm.txtImmediateAction.EditValue = ""
            frm.txtStatus.EditValue = "Open"
            frm.MainGrid.DataSource = DB.CreateTable("SELECT *, CAST (0 AS BIT) Edited FROM dbo.tblNCCorrectiveMeasure WHERE NCID='xxyyzzoo'")
        End If
        frm.gDetails.Text = frm.gDetails.Text & " " & GetDesc()
        frm.ShowDialog()
        If frm.IS_SAVED Then
            If Not bNCExist Then strNCID = GenerateID(DB, "NCID", "tblNC")
            ncSQLs.Clear()
            If frm.nMaintenanceWorkID = 0 Then
                strNCSql = "INSERT INTO [dbo].[tblNC]([NCID],[MaintenanceWorkID],[DiscoveredBy],[ReportedTo],[IsStatusClosed],[Description],[ImmediateAction],[Cause],[Objective])" & _
                              "VALUES('" & strNCID & "',<MaintenanceWorkID>,'" & frm.txtDiscoveredBy.EditValue.ToString.Replace("'", "''") & "','" & frm.txtReportedTo.EditValue.ToString.Replace("'", "''") & "',0,'" & frm.txtDescription.EditValue.ToString.Replace("'", "''") & "','" & frm.txtImmediateAction.EditValue.ToString.Replace("'", "''") & "','" & frm.txtCauses.EditValue.ToString.Replace("'", "''") & "','" & frm.txtObjectives.EditValue.ToString.Replace("'", "''") & "')"
                MainView.SetFocusedRowCellValue("bNC", True)
                MainView.RefreshRow(MainView.FocusedRowHandle)
                AllowSaving(Name, True)
                bRecordUpdated = True
            Else
                If bNCExist Then
                    DB.RunSql("UPDATE [dbo].[tblNC] SET [DiscoveredBy]='" & frm.txtDiscoveredBy.EditValue.ToString.Replace("'", "''") & "',[ReportedTo]='" & frm.txtReportedTo.EditValue.ToString.Replace("'", "''") & "',[Description]='" & frm.txtDescription.EditValue.ToString.Replace("'", "''") & "',[ImmediateAction]='" & frm.txtImmediateAction.EditValue.ToString.Replace("'", "''") & "',[Cause]='" & frm.txtCauses.EditValue.ToString.Replace("'", "''") & "',[Objective]='" & frm.txtObjectives.EditValue.ToString.Replace("'", "''") & "' WHERE NCID='" & strNCID & "'")
                Else
                    Dim bTmpEdited As Boolean = MainView.GetFocusedRowCellValue("Edited")
                    DB.RunSql("INSERT INTO [dbo].[tblNC]([NCID],[MaintenanceWorkID],[DiscoveredBy],[ReportedTo],[IsStatusClosed],[Description],[ImmediateAction],[Cause],[Objective])" & _
                              "VALUES('" & strNCID & "'," & frm.nMaintenanceWorkID & ",'" & frm.txtDiscoveredBy.EditValue.ToString.Replace("'", "''") & "','" & frm.txtReportedTo.EditValue.ToString.Replace("'", "''") & "',0,'" & frm.txtDescription.EditValue.ToString.Replace("'", "''") & "','" & frm.txtImmediateAction.EditValue.ToString.Replace("'", "''") & "','" & frm.txtCauses.EditValue.ToString.Replace("'", "''") & "','" & frm.txtObjectives.EditValue.ToString.Replace("'", "''") & "')")

                    MainView.SetFocusedRowCellValue("bNC", True)
                    MainView.SetFocusedRowCellValue("Edited", bTmpEdited)
                    MainView.RefreshRow(MainView.FocusedRowHandle)
                    ncSQLs.Add("Update dbo.tblMaintenanceWork set bNC=1 Where MaintenanceWorkID=" & frm.nMaintenanceWorkID)
                End If
            End If
            frm.MainView.CloseEditor()
            frm.MainView.UpdateCurrentRow()
            For i = 0 To frm.MainView.RowCount - 1
                If frm.MainView.GetRowCellValue(i, "Edited") Then
                    If Not frm.MainView.GetRowCellValue(i, "DueDate") Is System.DBNull.Value Then strDueDate = ChangeToSQLDate(frm.MainView.GetRowCellValue(i, "DueDate"))
                    If Not frm.MainView.GetRowCellValue(i, "DoneDate") Is System.DBNull.Value Then strDoneDate = ChangeToSQLDate(frm.MainView.GetRowCellValue(i, "DoneDate"))
                    If IfNull(frm.MainView.GetRowCellValue(i, "NCCorrectiveMeasureID"), 0) = 0 Then
                        ncSQLs.Add("INSERT INTO [dbo].[tblNCCorrectiveMeasure]([NCID],[Description],[RankCode],[DueDate],[DoneDate],[LastUpdatedBy]) Values('" & strNCID & "', '" & frm.MainView.GetRowCellValue(i, "Description") & "', '" & frm.MainView.GetRowCellValue(i, "RankCode") & "', " & strDueDate & ", " & strDoneDate & ",'" & GetUserName() & "')")
                    Else
                        ncSQLs.Add("UPDATE [dbo].[tblNCCorrectiveMeasure] SET [Description]='" & frm.MainView.GetRowCellValue(i, "Description") & "',[RankCode]='" & frm.MainView.GetRowCellValue(i, "RankCode") & "',[DueDate]=" & strDueDate & ",[DoneDate]=" & strDoneDate & ",[LastUpdatedBy]='" & GetUserName() & "' WHERE NCCorrectiveMeasureID=" & frm.MainView.GetRowCellValue(i, "NCCorrectiveMeasureID"))
                    End If
                End If
            Next
            If frm.nMaintenanceWorkID > 0 Then
                If frm.delsqls.Count > 0 Then
                    Dim strTemp As String
                    For Each strTemp In frm.delsqls
                        ncSQLs.Add(strTemp)
                    Next
                End If
                If ncSQLs.Count > 0 Then
                    DB.RunSqls(ncSQLs)
                    ncSQLs.Clear()
                End If
            End If
        End If
    End Sub

    Private Sub MainView_DoubleClick(sender As Object, e As System.EventArgs) Handles MainView.DoubleClick
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim pt As Drawing.Point = view.GridControl.PointToClient(System.Windows.Forms.Control.MousePosition)
        Dim info As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(pt)
        If (info.InRow Or info.InRowCell) Then
            If Not MainView.IsGroupRow(MainView.FocusedRowHandle) Then
                EditData()
            End If
        End If
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
        If IfNull(MainView.GetRowCellValue(e.RowHandle, "ImageDoc"), "") <> "" Then
            e.Info.ImageIndex = -1
            e.Painter.DrawObject(e.Info)
            e.Graphics.DrawImage(DevExpress.Images.ImageResourceCache.Default.GetImage("images/mail/attachment_16X16.png".ToLower().Replace(" ", "%20")), New RectangleF(e.Bounds.X + 1, e.Bounds.Y + 1, e.Bounds.Width - 2, e.Bounds.Height - 2))
            e.Handled = True
        End If
    End Sub
End Class
