Imports System.Drawing

Public Class INTERVAL
    
    'Overriden From Base Control
    Public Overrides Sub SaveData()
        Dim i As Integer, sqls As New ArrayList
        MainView.CloseEditor()
        MainView.UpdateCurrentRow()
        For i = 0 To MainView.RowCount - 1
            If MainView.GetRowCellValue(i, "Edited") Then
                sqls.Add("Update dbo.tblAdmInterval set IntDue=" & MainView.GetRowCellValue(i, "IntDue") & ", LastUpdatedBy='" & GetUserName() & "' Where IntCode='" & MainView.GetRowCellValue(i, "IntCode") & "'")
            End If
        Next
        DB.RunSqls(sqls)
        bRecordUpdated = False
        RefreshData()
    End Sub

    Private Sub MainViewnRowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
        If e.Column.Name <> "IntDue" Then
            If e.RowHandle = MainView.FocusedRowHandle Then
                e.Appearance.BackColor = DISABLED_SELECTED_COLOR
            Else
                e.Appearance.BackColor = DISABLED_COLOR
            End If
        ElseIf e.RowHandle = MainView.FocusedRowHandle And MainView.GetRowCellValue(MainView.FocusedRowHandle, "Edited") Then
            e.Appearance.BackColor = EDITED_FOCUSED_COLOR
        ElseIf MainView.GetRowCellValue(e.RowHandle, "Edited") Then
            e.Appearance.BackColor = EDITED_COLOR
        ElseIf e.RowHandle = MainView.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        Else
            e.Appearance.BackColor = Color.White
        End If
    End Sub

    Public Overrides Sub RefreshData()
        Dim nRow As Integer = -1
        If MainView.RowCount > 0 Then
            nRow = MainView.FocusedRowHandle
        End If
        Me.MainGrid.DataSource = DB.CreateTable("SELECT *,CAST(0 AS BIT) Edited FROM dbo.INTERVALLIST")
        If MainView.RowCount > 0 Then
            MainView.FocusedRowHandle = nRow
            MainView.SelectRow(nRow)
        End If
        AllowSaving(Name, False)
        SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetSaveVisibility(Name, IIf((bPermission And 4) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never))
        SetDeleteVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
    End Sub

    Private Sub MainView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MainView.KeyDown
        If e.KeyData = Windows.Forms.Keys.Down Then
            MainView.MoveNext()
            e.Handled = True
        ElseIf e.KeyData = Windows.Forms.Keys.Up Then
            MainView.MovePrev()
            e.Handled = True
        End If
    End Sub

    Private Sub MainView_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles MainView.CellValueChanging
        MainView.SetRowCellValue(MainView.FocusedRowHandle, "Edited", True)
        bRecordUpdated = True
        AllowSaving(Name, (bPermission And 4) > 0)
    End Sub

End Class
