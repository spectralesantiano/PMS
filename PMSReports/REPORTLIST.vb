Public Class REPORTLIST

    Private Sub MainView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MainView.Click
        bAddMode = False
        SelectionChange(Name)
        MainView.RefreshRow(MainView.FocusedRowHandle)
    End Sub

    Private Sub MainView_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles MainView.FocusedRowChanged
        If MainView.RowCount > 0 Then
            SelectionChange(Name)
            bAddMode = False
        End If
    End Sub

    Private Sub MainView_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MainView.MouseUp
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim pt As System.Drawing.Point = view.GridControl.PointToClient(System.Windows.Forms.Control.MousePosition)
        Dim info As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(pt)
        If (info.InRow Or info.InRowCell) And e.Button = Windows.Forms.MouseButtons.Right Then
            CellRightClick(Name)
        End If
    End Sub

    Private Sub MainViewnRowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
        If MainView.IsRowSelected(e.RowHandle) And Not bAddMode Then
            e.Appearance.BackColor = SEL_COLOR
            e.Appearance.ForeColor = System.Drawing.Color.Black
        End If
    End Sub

    Public Overrides Function GetFocusedRowData(ByVal _columnname As String) As Object
        Try
            Return MainView.GetRowCellValue(MainView.FocusedRowHandle, _columnname)
        Catch ex As Exception
            Return System.DBNull.Value
        End Try

    End Function

    Public Overrides Sub HideSelection()
        bAddMode = True
        MainView.RefreshRow(MainView.FocusedRowHandle)
    End Sub

    Public Overrides Sub SetSelection(ByVal id As String)
        Try
            bAddMode = False
            Dim RowHandle As Integer = 0
            Dim Col As DevExpress.XtraGrid.Columns.GridColumn = MainView.Columns("ObjectID")
            RowHandle = MainView.LocateByValue(0, Col, id)
            MainView.FocusedRowHandle = RowHandle
        Catch ex As Exception
        End Try
    End Sub

    Public Overrides Sub RefreshData()
        Dim nRow As Integer = -1
        If MainView.RowCount > 0 Then
            nRow = MainView.FocusedRowHandle
        End If
        bDisableSelectionEvent = True
        Me.MainGrid.DataSource = DB.CreateTable("EXEC [dbo].[USERREPORTS] @UserID='" & USER_ID & "'")
        If MainView.RowCount > 0 Then
            MainView.FocusedRowHandle = nRow
            MainView.SelectRow(nRow)
        End If
        bDisableSelectionEvent = False
    End Sub

    Public Overrides Function GetID() As String
        If MainView.RowCount > 0 Then
            Return MainView.GetRowCellValue(MainView.FocusedRowHandle, "ObjectID")
        Else
            Return ""
        End If
    End Function

    Public Overrides Function GetDesc() As String
        If MainView.RowCount > 0 Then
            Return MainView.GetRowCellValue(MainView.FocusedRowHandle, "Caption")
        Else
            Return ""
        End If
    End Function


    Public Overrides Sub SetFilter(ByVal _criteria As String)
        MainView.ActiveFilterString = _criteria
    End Sub

    Public Overrides Sub ClearFilter()
        bDisableSelectionEvent = True
        MainView.ClearColumnsFilter()
        MainView.RefreshData()
        bDisableSelectionEvent = False
    End Sub


    Private Sub MainView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MainView.KeyDown
        If e.KeyData = System.Windows.Forms.Keys.Down Then
            MainView.MoveNext()
            e.Handled = True
        ElseIf e.KeyData = System.Windows.Forms.Keys.Up Then
            MainView.MovePrev()
            e.Handled = True
        End If
    End Sub

End Class
