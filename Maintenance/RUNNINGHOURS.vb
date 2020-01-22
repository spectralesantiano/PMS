Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.BandedGrid

Public Class RUNNINGHOURS

    Public Overrides Sub ExecCustomFunction(ByVal param() As Object)
        Select Case param(0)
            Case "Filter"
                FilterData()
            Case "Preview"
                If MainView.RowCount > 0 Then
                    RaiseCustomEvent(Name, New Object() {"Preview", "COUNTERREP", "PMSReports", MainGrid.DataSource})
                End If
        End Select
    End Sub

    Sub FilterData()
        Dim strFilter As String = ""
        If CURRENT_DEPARTMENT <> "" Then strFilter = "DeptCode='" & CURRENT_DEPARTMENT & "'"
        Me.MainView.ActiveFilterString = strFilter
    End Sub

    'Overriden From Base Control
    Public Overrides Sub AddData()
        If Not bAddMode Then
            Dim frm As New frmDefaultDate
            frm.txtDate.Properties.MaxValue = Now.Date
            frm.ShowDialog()
            If frm.IS_SAVED Then
                Dim i As Integer, bHasLaterDate As Boolean = False
                For i = 0 To MainView.RowCount - 1
                    If Date.Compare(MainView.GetRowCellValue(i, "CurrDate"), frm.txtDate.EditValue) >= 0 Then
                        bHasLaterDate = True
                    Else
                        MainView.SetRowCellValue(i, "NewDate", frm.txtDate.EditValue)
                        MainView.SetRowCellValue(i, "Edited", False)
                    End If
                Next
                If bHasLaterDate Then
                    MsgBox("Some rows are not set to default date. Default Reading Date should be later than the previous reading date.", MsgBoxStyle.Information, GetAppName)
                End If
                AllowSaving(Name, False) 'Disable save button
                bAddMode = True
                NewBand.Visible = True
                PrevBand.Visible = False
                bRecordUpdated = False
            End If
        End If
    End Sub

    'Overriden From Base Control
    Public Overrides Sub SaveData()
        Dim sqls As New ArrayList, i As Integer, bUpdateList As Boolean = False
        Dim strEquipmentComponentCode As String = ""
        MainView.CloseEditor()
        MainView.UpdateCurrentRow()
        For i = 0 To MainView.RowCount - 1
            If MainView.GetRowCellValue(i, "Edited") Then
                If bAddMode Then
                    sqls.Add("INSERT INTO [dbo].[tblCounterReading]([CounterCode],[ReadingDate],[Reading],[HoursPerDay],[LastUpdatedBy]) Values('" & MainView.GetRowCellValue(i, "CounterCode") & "'," & ChangeToSQLDate(MainView.GetRowCellValue(i, "NewDate")) & ", " & MainView.GetRowCellValue(i, "NewReading") & "," & IfNull(MainView.GetRowCellValue(i, "HoursPerDay"), 0) & ",'" & GetUserName() & "')")
                Else
                    If MainView.GetRowCellValue(i, "CounterReadingID") Is System.DBNull.Value Then
                        sqls.Add("INSERT INTO [dbo].[tblCounterReading]([CounterCode],[ReadingDate],[Reading],[HoursPerDay],[LastUpdatedBy]) Values('" & MainView.GetRowCellValue(i, "CounterCode") & "'," & ChangeToSQLDate(MainView.GetRowCellValue(i, "CurrDate")) & ", " & MainView.GetRowCellValue(i, "CurrReading") & "," & IfNull(MainView.GetRowCellValue(i, "HoursPerDay"), 0) & ",'" & GetUserName() & "')")
                    Else
                        sqls.Add("UPDATE [dbo].[tblCounterReading] SET [ReadingDate]=" & ChangeToSQLDate(MainView.GetRowCellValue(i, "CurrDate")) & ", Reading=" & MainView.GetRowCellValue(i, "CurrReading") & ", HoursPerDay=" & IfNull(MainView.GetRowCellValue(i, "HoursPerDay"), 0) & ", LastUpdatedBy='" & GetUserName() & "' WHERE [CounterReadingID]=" & MainView.GetRowCellValue(i, "CounterReadingID"))
                    End If
                End If
            End If
        Next
        DB.RunSqls(sqls)
        bAddMode = False
        bRecordUpdated = False
        RefreshData()
    End Sub

    Public Overrides Sub RefreshData()
        Dim strFilter As String = ""
        bLoaded = False
        If Not bLoaded Then
            AllowAddition(Name, True)
            AllowSaving(Name, False)
            AllowDeletion(Name, False)
            bLoaded = True
            strDesc = ""
            Me.header.Text = "EDIT RUNNING HOURS"
            SetAddVisibility(Name, IIf((bPermission And 2) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never))
            SetSaveVisibility(Name, IIf((bPermission And 4) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never))
            SetDeleteVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
            CurrDateEdit.MaxValue = Now.Date
            NewDateEdit.MaxValue = Now.Date
        End If
        MainGrid.DataSource = DB.CreateTable("EXEC [dbo].[RUNNINGHOURS]")
        SplitContainerControl1.SplitterPosition = MEBand.Width + CurrBand.Width + PrevBand.Width + gSummary.Width + 100
        CurrBand.Visible = False
        If MainView.RowCount > 0 Then
            Dim i As Integer
            For i = 0 To MainView.RowCount - 1
                If Not MainView.GetRowCellValue(i, "CounterReadingID") Is System.DBNull.Value Then
                    CurrBand.Visible = True
                    Exit For
                End If
            Next
        End If
        NewBand.Visible = False
        PrevBand.Visible = True
        bLoaded = True
    End Sub

    'Overriden From Base Control
    Public Overrides Function GetDesc() As String
        Return "Running Hours"
    End Function

    Private Sub MainView_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles MainView.CustomUnboundColumnData
        Dim nRowHandle As Integer = MainView.GetRowHandle(e.ListSourceRowIndex)
        If bAddMode Then
            If e.Column.Name = "HoursRun" And e.IsGetData Then
                If MainView.GetRowCellValue(nRowHandle, "CurrReading") Is System.DBNull.Value Or MainView.GetRowCellValue(nRowHandle, "NewReading") Is System.DBNull.Value Then
                    e.Value = 0
                Else
                    e.Value = MainView.GetRowCellValue(nRowHandle, "NewReading") - MainView.GetRowCellValue(nRowHandle, "CurrReading")
                End If
            ElseIf e.Column.Name = "HoursPerDay" And e.IsGetData Then
                If MainView.GetRowCellValue(nRowHandle, "CurrReading") Is System.DBNull.Value Or MainView.GetRowCellValue(nRowHandle, "NewReading") Is System.DBNull.Value Or MainView.GetRowCellValue(nRowHandle, "CurrDate") Is System.DBNull.Value Or MainView.GetRowCellValue(nRowHandle, "NewDate") Is System.DBNull.Value Then
                    e.Value = 0
                Else
                    Dim dDiff As Integer = DateDiff(DateInterval.Day, MainView.GetRowCellValue(nRowHandle, "CurrDate"), MainView.GetRowCellValue(nRowHandle, "NewDate")) + 1, nDiff As Double = MainView.GetRowCellValue(nRowHandle, "NewReading") - MainView.GetRowCellValue(nRowHandle, "CurrReading")
                    e.Value = nDiff / dDiff
                End If
            End If
        Else
            If e.Column.Name = "HoursRun" And e.IsGetData Then
                If MainView.GetRowCellValue(nRowHandle, "PrevReading") Is System.DBNull.Value Or MainView.GetRowCellValue(nRowHandle, "CurrReading") Is System.DBNull.Value Then
                    e.Value = 0
                ElseIf IfNull(MainView.GetRowCellValue(nRowHandle, "CurrCounter"), "") <> IfNull(MainView.GetRowCellValue(nRowHandle, "PrevCounter"), "") Then
                    e.Value = MainView.GetRowCellValue(nRowHandle, "CurrReading")
                Else
                    e.Value = MainView.GetRowCellValue(nRowHandle, "CurrReading") - MainView.GetRowCellValue(nRowHandle, "PrevReading")
                End If
            ElseIf e.Column.Name = "HoursPerDay" And e.IsGetData Then
                Dim nDiff As Double, dDiff As Integer
                If MainView.GetRowCellValue(nRowHandle, "PrevReading") Is System.DBNull.Value Or MainView.GetRowCellValue(nRowHandle, "CurrReading") Is System.DBNull.Value Or MainView.GetRowCellValue(nRowHandle, "CurrDate") Is System.DBNull.Value Or MainView.GetRowCellValue(nRowHandle, "PrevDate") Is System.DBNull.Value Then
                    e.Value = 0
                ElseIf IfNull(MainView.GetRowCellValue(nRowHandle, "CurrCounter"), "") <> IfNull(MainView.GetRowCellValue(nRowHandle, "PrevCounter"), "") Then
                    nDiff = MainView.GetRowCellValue(nRowHandle, "CurrReading")
                    dDiff = DateDiff(DateInterval.Day, MainView.GetRowCellValue(nRowHandle, "PrevDate"), MainView.GetRowCellValue(nRowHandle, "CurrDate")) + 1
                    e.Value = nDiff / dDiff
                Else
                    nDiff = MainView.GetRowCellValue(nRowHandle, "CurrReading") - MainView.GetRowCellValue(nRowHandle, "PrevReading")
                    dDiff = DateDiff(DateInterval.Day, MainView.GetRowCellValue(nRowHandle, "PrevDate"), MainView.GetRowCellValue(nRowHandle, "CurrDate")) + 1
                    e.Value = nDiff / dDiff
                End If
            End If
        End If
    End Sub

    Private Sub MainView_cellvaluechanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles MainView.CellValueChanged
        If e.Column.Name <> "Edited" Then
            MainView.SetRowCellValue(e.RowHandle, "Edited", True)
        End If
    End Sub

    Private Sub View_CellValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles MainView.CellValueChanging
        AllowSaving(Name, (bPermission And 4) > 0)
        bRecordUpdated = True
    End Sub

    Private Sub MainView_RowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
        If e.Column.Name = "UnitDesc" Or e.Column.Name = "CurrCounter" Or e.Column.Name = "HoursRun" Or e.Column.Name = "HoursPerDay" Or e.Column.Name = "AvgHoursPerDay" Or e.Column.Name.Substring(0, 4) = "Prev" Or (e.Column.Name.Substring(0, 4) = "Curr" And bAddMode) Then
            e.Appearance.BackColor = IIf(MainView.FocusedRowHandle = e.RowHandle, DISABLED_SELECTED_COLOR, DISABLED_COLOR)
        Else
            If MainView.FocusedRowHandle = e.RowHandle Then
                e.Appearance.BackColor = IIf(IfNull(MainView.GetRowCellValue(e.RowHandle, "Edited"), False), EDITED_FOCUSED_COLOR, SEL_COLOR)
            Else
                e.Appearance.BackColor = IIf(IfNull(MainView.GetRowCellValue(e.RowHandle, "Edited"), False), EDITED_COLOR, Color.White)
            End If
        End If
    End Sub

    Private Sub MainView_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MainView.ShowingEditor
        If MainView.FocusedColumn.Name = "CounterName" Or MainView.FocusedColumn.Name = "HoursRun" Or MainView.FocusedColumn.Name = "AvgHR" Or MainView.FocusedColumn.Name.Substring(0, 4) = "Prev" Or (MainView.FocusedColumn.Name.Substring(0, 4) = "Curr" And bAddMode) Then
            e.Cancel = True
        End If
    End Sub

    Private Sub MainView_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles MainView.ValidatingEditor
        If bAddMode Then
            If MainView.FocusedColumn.Name = "NewDate" Then
                If Date.Compare(MainView.GetRowCellValue(MainView.FocusedRowHandle, "CurrDate"), e.Value) >= 0 Then
                    e.ErrorText = "Current Reading Date should be later than the previous reading date."
                    e.Valid = False
                End If
            ElseIf MainView.FocusedColumn.Name = "NewReading" Then
                If e.Value < IfNull(MainView.GetRowCellValue(MainView.FocusedRowHandle, "CurrReading"), 0) Then
                    e.ErrorText = "Current Reading should not be less than the previous reading."
                    e.Valid = False
                ElseIf Not (MainView.GetRowCellValue(MainView.FocusedRowHandle, "CurrReading") Is System.DBNull.Value Or MainView.GetRowCellValue(MainView.FocusedRowHandle, "CurrDate") Is System.DBNull.Value) Then
                    Dim dDiff As Integer = DateDiff(DateInterval.Day, MainView.GetRowCellValue(MainView.FocusedRowHandle, "CurrDate"), MainView.GetRowCellValue(MainView.FocusedRowHandle, "NewDate")) + 1, nDiff As Double = e.Value - MainView.GetRowCellValue(MainView.FocusedRowHandle, "CurrReading")
                    e.ErrorText = "Hours per day is more than " & DAY_MAX_HOURS & " hours."
                    e.Valid = (nDiff / dDiff) <= DAY_MAX_HOURS
                End If
            End If
        Else
            If MainView.FocusedColumn.Name = "CurrDate" Then
                If Date.Compare(MainView.GetRowCellValue(MainView.FocusedRowHandle, "PrevDate"), e.Value) >= 0 Then
                    e.ErrorText = "Current Reading Date should be later than the previous reading date."
                    e.Valid = False
                End If
            ElseIf MainView.FocusedColumn.Name = "CurrReading" Then
                If e.Value < IfNull(MainView.GetRowCellValue(MainView.FocusedRowHandle, "PrevReading"), 0) And IfNull(MainView.GetRowCellValue(MainView.FocusedRowHandle, "CurrCounter"), "") = IfNull(MainView.GetRowCellValue(MainView.FocusedRowHandle, "PrevCounter"), "") Then
                    e.ErrorText = "Current Reading should not be less than the previous reading."
                    e.Valid = False
                ElseIf Not (MainView.GetRowCellValue(MainView.FocusedRowHandle, "PrevReading") Is System.DBNull.Value Or MainView.GetRowCellValue(MainView.FocusedRowHandle, "CurrDate") Is System.DBNull.Value Or MainView.GetRowCellValue(MainView.FocusedRowHandle, "PrevDate") Is System.DBNull.Value) Then
                    Dim dDiff As Integer = DateDiff(DateInterval.Day, MainView.GetRowCellValue(MainView.FocusedRowHandle, "PrevDate"), MainView.GetRowCellValue(MainView.FocusedRowHandle, "CurrDate")) + 1, nDiff As Double = e.Value - MainView.GetRowCellValue(MainView.FocusedRowHandle, "PrevReading")
                    If IfNull(MainView.GetRowCellValue(MainView.FocusedRowHandle, "CurrCounter"), "") <> IfNull(MainView.GetRowCellValue(MainView.FocusedRowHandle, "PrevCounter"), "") Then nDiff = e.Value
                    e.ErrorText = "Hours per day is more than " & DAY_MAX_HOURS & " hours."
                    e.Valid = (nDiff / dDiff) <= DAY_MAX_HOURS
                End If

            End If
        End If
    End Sub

    Private Sub MainView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles MainView.FocusedRowChanged
        If MainView.RowCount > 0 Then
            hGrid.DataSource = DB.CreateTable("SELECT [Counter],[ReadingDate] hDate,[Reading] hReading FROM [dbo].[COUNTERHISTORY] WHERE UnitCode='" & MainView.GetFocusedRowCellValue("UnitCode") & "'")
            hBand.Caption = MainView.GetFocusedRowCellValue("UnitDesc")
        End If
    End Sub
End Class
