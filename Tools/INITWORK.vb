Imports System.Drawing

Public Class INITWORK

    Public Overrides Sub ExecCustomFunction(ByVal param() As Object)
        Select Case param(0)
            Case "Filter"
                FilterData()
        End Select
    End Sub

    Sub FilterData()
        Dim strFilter As String = ""
        If CURRENT_DEPARTMENT <> "" Then strFilter = strFilter & "AND DeptCode='" & CURRENT_DEPARTMENT & "'"
        If CURRENT_RANK <> "" Then strFilter = strFilter & "AND RankCode='" & CURRENT_RANK & "'"
        If CURRENT_CATEGORY <> "" Then strFilter = strFilter & "AND CatCode='" & CURRENT_CATEGORY & "'"
        If strFilter.Length > 0 Then strFilter = strFilter.Remove(0, 4)
        Me.MainView.ActiveFilterString = strFilter
    End Sub

    'Overriden From Base Control
    Public Overrides Sub SaveData()
        Dim sqls As New ArrayList, i As Integer, bUpdateList As Boolean = False
        Dim strDateDue As String = "NULL", strEquipmentComponentCode As String = "NULL"
        MainView.CloseEditor()
        MainView.UpdateCurrentRow()
        For i = 0 To MainView.RowCount - 1
            If MainView.GetRowCellValue(i, "Edited") Then
                If Not MainView.GetRowCellValue(i, "DueDate") Is System.DBNull.Value Then
                    strDateDue = ChangeToSQLDate(MainView.GetRowCellValue(i, "DueDate"))
                End If
                If Not MainView.GetRowCellValue(i, "EquipmentComponentCode") Is System.DBNull.Value Then
                    strEquipmentComponentCode = "'" & MainView.GetRowCellValue(i, "EquipmentComponentCode") & "'"
                End If
                sqls.Add("Insert Into dbo.tblMaintenanceWork([UnitCode],[MaintenanceCode],[EquipmentComponentCode],[ExecutedBy],[RankCode],[WorkDate],[WorkCounter],[Remarks],[DueCounter],[DueDate],[LastUpdatedBy],bNC) Values('" & MainView.GetRowCellValue(i, "UnitCode") & "', '" & MainView.GetRowCellValue(i, "MaintenanceCode") & "'," & strEquipmentComponentCode & ", '" & MainView.GetRowCellValue(i, "ExecutedBy") & "', '" & MainView.GetRowCellValue(i, "RankCode") & "'," & ChangeToSQLDate(MainView.GetRowCellValue(i, "WorkDate")) & "," & IfNull(MainView.GetRowCellValue(i, "WorkCounter"), "NULL") & ",'" & MainView.GetRowCellValue(i, "Remarks").ToString.Replace("'", "''") & "'," & IfNull(MainView.GetRowCellValue(i, "DueCounter"), "NULL") & "," & strDateDue & ",'" & GetUserName() & "',0)")
            End If
        Next
        sqls.Add("UPDATE dbo.tblMaintenanceWork SET bLatest=0 WHERE UnitCode='" & strID & "'")
        sqls.Add("UPDATE t SET t.bLatest=1 FROM dbo.tblMaintenanceWork t INNER JOIN dbo.MAXWORKLIST w ON t.UnitCode=w.UnitCode AND t.MaintenanceCode=w.MaintenanceCode AND t.WorkDate=w.WorkDate WHERE t.UnitCode='" & strID & "'")
        DB.RunSqls(sqls)
        bAddMode = False
        bRecordUpdated = False
        RefreshData()
    End Sub

    'Overriden From Base Control
    Public Overrides Sub AddData()
        If MainView.IsGroupRow(MainView.FocusedRowHandle) Then
            MainView.CollapseGroupRow(MainView.FocusedRowHandle)
        End If
    End Sub

    'Overriden From Base Control
    Public Overrides Function GetDesc() As String
        Return "Initial Maintenance"
    End Function

    'Overriden From Base Control
    Public Overrides Sub RefreshData()
        Dim strFilter As String = ""
        If Not bLoaded Then
            AllowAddition(Name, False)
            AllowDeletion(Name, False)
            AddEditListener(Me.header)
            bLoaded = True
            RankEdit.DataSource = AdmRank
            strDesc = ""
            Me.header.Text = "SETUP INITIAL MAINTENANCE"
            SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
            SetSaveVisibility(Name, IIf((bPermission And 4) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never))
            SetDeleteVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        End If
        MainGrid.DataSource = DB.CreateTable("SELECT * FROM dbo.INITIAL_WORKLIST")
        If MainView.RowCount > 0 Then
            MainView.SelectRow(0)
            MainView.RefreshData()
        End If
        bRecordUpdated = False
        AllowSaving(Name, False)
    End Sub

    Private Sub header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles header.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            OnRightClick(Name)
        End If
    End Sub

    Private Sub MainView_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MainView.ShowingEditor
        Dim bIsHour As Boolean = (IfNull(MainView.GetRowCellValue(MainView.FocusedRowHandle, "IntCode"), "") = "SYSHOURS")
        If (Not bIsHour And MainView.FocusedColumn.Name = "WorkCounter") Or MainView.FocusedColumn.Name = "DueCounter" Or MainView.FocusedColumn.Name = "Equipment" Or MainView.FocusedColumn.Name = "Component" Or MainView.FocusedColumn.Name = "Maintenance" Then
            e.Cancel = True
        End If
    End Sub

    Private Sub MainView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles MainView.CellValueChanged
        Dim strIntCode As String
        If e.Column.Name = "MaintenanceCode" Or e.Column.Name = "WorkDate" Or e.Column.Name = "WorkCounter" Then
            If Not (MainView.GetRowCellValue(MainView.FocusedRowHandle, "MaintenanceCode") Is System.DBNull.Value Or IfNull(MainView.GetRowCellValue(MainView.FocusedRowHandle, "MaintenanceCode"), "   ").Substring(0, 3) = "SYS") Then
                'Dim nrow As DataRowView = (MaintenanceEdit.GetDataSourceRowByKeyValue(MainView.GetRowCellValue(e.RowHandle, "MaintenanceCode")))
                strIntCode = IfNull(MainView.GetRowCellValue(MainView.FocusedRowHandle, "IntCode"), "")
                If Not MainView.GetRowCellValue(e.RowHandle, "WorkDate") Is System.DBNull.Value Then
                    Select Case strIntCode
                        Case "SYSDAYS"
                            MainView.SetRowCellValue(e.RowHandle, "DueDate", CDate(MainView.GetRowCellValue(e.RowHandle, "WorkDate")).AddDays(MainView.GetRowCellValue(MainView.FocusedRowHandle, "Interval")))
                        Case "SYSWEEKS"
                            MainView.SetRowCellValue(e.RowHandle, "DueDate", CDate(MainView.GetRowCellValue(e.RowHandle, "WorkDate")).AddDays(MainView.GetRowCellValue(MainView.FocusedRowHandle, "Interval") * 7))
                        Case "SYSMONTHS"
                            MainView.SetRowCellValue(e.RowHandle, "DueDate", CDate(MainView.GetRowCellValue(e.RowHandle, "WorkDate")).AddMonths(MainView.GetRowCellValue(MainView.FocusedRowHandle, "Interval")))
                        Case "SYSYEARS"
                            MainView.SetRowCellValue(e.RowHandle, "DueDate", CDate(MainView.GetRowCellValue(e.RowHandle, "WorkDate")).AddYears(MainView.GetRowCellValue(MainView.FocusedRowHandle, "Interval")))
                    End Select
                End If

                If strIntCode = "SYSHOURS" Then
                    If Not MainView.GetRowCellValue(e.RowHandle, "WorkCounter") Is System.DBNull.Value Then
                        MainView.SetRowCellValue(e.RowHandle, "DueCounter", MainView.GetRowCellValue(e.RowHandle, "WorkCounter") + MainView.GetRowCellValue(MainView.FocusedRowHandle, "Interval"))
                    End If
                End If
            End If
        End If
        If e.Column.Name <> "Edited" Then
            MainView.SetRowCellValue(e.RowHandle, "Edited", True)
        End If
    End Sub

    Private Sub MainViewnRowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
        Dim bIsHour As Boolean = (IfNull(MainView.GetRowCellValue(e.RowHandle, "IntCode"), "") = "SYSHOURS")
        If e.Column.Name <> "Delete" Then
            If IfNull(MainView.GetRowCellValue(e.RowHandle, "Edited"), False) And MainView.FocusedRowHandle = e.RowHandle Then
                e.Appearance.BackColor = IIf(Not bIsHour And (e.Column.Name = "WorkCounter" Or e.Column.Name = "DueCounter"), DISABLED_EDITED_COLOR, EDITED_FOCUSED_COLOR)
            ElseIf MainView.GetRowCellValue(e.RowHandle, "Edited") Then
                e.Appearance.BackColor = IIf(Not bIsHour And (e.Column.Name = "WorkCounter" Or e.Column.Name = "DueCounter"), DISABLED_EDITED_COLOR, EDITED_COLOR)
            ElseIf e.RowHandle = MainView.FocusedRowHandle Then
                e.Appearance.BackColor = IIf(Not bIsHour And (e.Column.Name = "WorkCounter" Or e.Column.Name = "DueCounter"), DISABLED_SELECTED_COLOR, SEL_COLOR)
            ElseIf (Not bIsHour And (e.Column.Name = "WorkCounter" Or e.Column.Name = "DueCounter")) Or e.Column.Name = "Equipment" Or e.Column.Name = "Component" Or e.Column.Name = "Maintenance" Then
                e.Appearance.BackColor = DISABLED_COLOR
            End If
        End If
    End Sub

    Public Overrides Sub DeleteData()
        If (MainView.FocusedRowHandle < 0) Then
            MainView.DeleteRow(MainView.FocusedRowHandle)
            Exit Sub
        End If
        If MsgBox("Are you sure want to remove the <" & IfNull(MainView.GetFocusedRowCellDisplayText("MaintenanceCode"), "New Record") & "> Work Record?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If Not MainView.GetFocusedRowCellValue("MaintenanceWorkID") Is System.DBNull.Value Then
                Dim sqls As New ArrayList
                sqls.Add("DELETE FROM dbo.tblMaintenanceWork WHERE MaintenanceWorkID=" & MainView.GetFocusedRowCellValue("MaintenanceWorkID"))
                sqls.Add("DELETE FROM dbo.tblNC WHERE MaintenanceWorkID=" & MainView.GetFocusedRowCellValue("MaintenanceWorkID"))
                sqls.Add("UPDATE dbo.tblMaintenanceWork SET bLatest=0 WHERE UnitCode='" & strID & "'")
                sqls.Add("UPDATE t SET t.bLatest=1 FROM dbo.tblMaintenanceWork t INNER JOIN dbo.MAXWORKLIST w ON t.UnitCode=w.UnitCode AND t.MaintenanceCode=w.MaintenanceCode AND t.WorkDate=w.WorkDate WHERE t.UnitCode='" & strID & "'")
                DB.RunSqls(sqls)
            End If
            RefreshData()
        End If
    End Sub

    Private Sub View_CellValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles MainView.CellValueChanging
        AllowSaving(Name, (bPermission And 4) > 0)
        bRecordUpdated = True
    End Sub


End Class
