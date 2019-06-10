Public Class MAINTENANCELIST

    Public Overrides Sub HideSelection()
        bAddMode = True
        MainView.RefreshRow(MainView.FocusedRowHandle)
    End Sub

    Private Sub MainView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MainView.Click
        bAddMode = False
        SelectionChange(Name)
        MainView.RefreshRow(MainView.FocusedRowHandle)
    End Sub

    Private Sub MainView_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles MainView.FocusedRowChanged
        If MainView.FocusedRowHandle >= 0 Then
            SelectionChange(Name)
        End If
    End Sub

    Private Sub MainView_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MainView.MouseUp
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim pt As Drawing.Point = view.GridControl.PointToClient(System.Windows.Forms.Control.MousePosition)
        Dim info As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(pt)
        If (info.InRow Or info.InRowCell) And e.Button = Windows.Forms.MouseButtons.Right Then
            CellRightClick(Name)
        End If
    End Sub

    Private Sub MainView_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles MainView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, View.Columns("Edited"), True)
    End Sub

    Private Sub MainViewnRowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
        If e.RowHandle = MainView.FocusedRowHandle And Not bAddMode Then
            e.Appearance.BackColor = SEL_COLOR
        End If
    End Sub

    Public Overrides Sub SetFilter(ByVal _criteria As String)
        strFilter = ""
        Me.MainGrid.DataSource = DB.CreateTable("SELECT * FROM dbo.ADMINWORKLIST c WHERE LEFT(c.WorkCode,3)<>'SYS'")
        If MainView.RowCount > 0 Then
            MainView.SelectRow(0)
            System.Windows.Forms.Application.DoEvents()
            MainView.RefreshData()
        End If
    End Sub

    Public Overrides Sub RefreshData()
        Dim nRow As Integer = -1
        If MainView.RowCount > 0 Then
            nRow = MainView.FocusedRowHandle
        End If
        bDisableSelectionEvent = True
        Me.MainGrid.DataSource = DB.CreateTable("SELECT * FROM dbo.ADMINWORKLIST c WHERE LEFT(c.WorkCode,3)<>'SYS'")
        If System.IO.File.Exists(LayoutFileName) Then
            MainView.RestoreLayoutFromXml(LayoutFileName)
        End If
        If MainView.RowCount > 0 Then
            MainView.FocusedRowHandle = nRow
            MainView.SelectRow(nRow)
        End If
        bDisableSelectionEvent = False
    End Sub

    Public Overrides Function GetID() As String
        If MainView.RowCount > 0 Then
            Return MainView.GetRowCellValue(MainView.FocusedRowHandle, "WorkCode")
        Else
            Return ""
        End If
    End Function

    Public Overrides Function GetDesc() As String
        If MainView.RowCount > 0 Then
            Return MainView.GetRowCellValue(MainView.FocusedRowHandle, "Maintenance")
        Else
            Return ""
        End If
    End Function

    Public Overrides Function GetFocusedRowData(ByVal _columnname As String) As Object
        Try
            Return MainView.GetRowCellValue(MainView.FocusedRowHandle, _columnname)
        Catch ex As Exception
            Return System.DBNull.Value
        End Try

    End Function

    Public Overrides Sub SetSelection(ByVal id As String)
        Try
            bAddMode = False
            Dim RowHandle As Integer = 0
            Dim Col As DevExpress.XtraGrid.Columns.GridColumn = MainView.Columns("WorkCode")
            RowHandle = MainView.LocateByValue(0, Col, id)
            MainView.FocusedRowHandle = RowHandle
        Catch ex As Exception
        End Try
    End Sub

    Public Overrides Sub SaveLayout(ByVal fileName As String)
        MainView.SaveLayoutToXml(fileName)
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

    Public Overrides Sub ExecCustomFunction(ByVal param() As Object)
        Select Case param(0)
            Case "Paste", "PasteFromFile"
                PasteData(param(0))
        End Select
    End Sub

    Sub PasteData(strMode As String)
        Dim nRow() As DataRow, crow As DataRow
        If strMode = "Paste" Then
            nRow = ImportFromClipboard("Maintenance", "")
        Else
            nRow = ImportFromFile("Maintenance", "")
        End If
        If Not nRow Is Nothing Then
            For Each crow In nRow
                Dim bExist As Boolean = True, strValue As String = crow("Maintenance")
                Dim strCode As String = PasteAdminData(DB, "WorkCode", "tblAdmWork", strValue, bExist)
                If Not bExist Then
                    MainView.AddNewRow()
                    MainView.SetRowCellValue(MainView.FocusedRowHandle, "WorkCode", strCode)
                    MainView.SetRowCellValue(MainView.FocusedRowHandle, "Maintenance", strValue)
                    MainView.UpdateCurrentRow()
                    MainView.CloseEditor()
                End If
            Next
        End If
    End Sub
End Class
