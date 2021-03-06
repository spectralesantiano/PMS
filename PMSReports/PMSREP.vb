Public Class PMSREP

    Private Property GetHeaderFont As Drawing.Font

    Public Overrides Sub ExecCustomFunction(ByVal param() As Object)
        Select Case param(0)
            Case "Export"
                Export()
            Case "Filter"
                Dim strFilter As String = ""
                If CURRENT_DEPARTMENT <> "" Then strFilter = strFilter & "AND DeptCode='" & CURRENT_DEPARTMENT & "'"
                If CURRENT_CATEGORY <> "" Then strFilter = strFilter & "AND CatCode='" & CURRENT_CATEGORY & "'"
                If CURRENT_RANK <> "" Then strFilter = strFilter & "AND RankCode='" & CURRENT_RANK & "'"
                If strFilter.Length > 0 Then strFilter = strFilter.Remove(0, 4)
                Me.MainView.ActiveFilterString = strFilter
            Case "Preview"
                Preview()
            Case "SelectAll"
                MainView.SelectAll()
            Case "DeselectAll"
                MainView.ClearSelection()
        End Select
    End Sub

    Public Overrides Function GetDesc() As String
        Return "PMS REPORTS DATA"
    End Function

    Private Sub Export()
        
    End Sub

    Private Sub Preview()
        Dim otherparam As String = "|"
        Dim cnt As Integer
        For cnt = 0 To MainView.RowCount - 1
            If MainView.IsRowSelected(cnt) Then
                otherparam = otherparam & MainView.GetRowCellValue(cnt, "RecID") & "|"
            End If
        Next
        If otherparam.Length > 1 Or MainGrid.DataSource Is Nothing Or strID = "EQUIPMENTCRIT" Then
            RaiseCustomEvent(Name, New Object() {"Preview", strID, blList.GetFocusedRowData("DLL"), otherparam})
        Else
            MsgBox("Please select at least one record to preview.", MsgBoxStyle.Information, GetAppName)
        End If

    End Sub

    Private Sub MainViewnRowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
        If MainView.IsRowSelected(e.RowHandle) Then
            e.Appearance.BackColor = SEL_COLOR
        End If
    End Sub

    Public Overrides Sub RefreshData()
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        strID = Trim(blList.GetID)
        'Get Data Displayed        
        Me.MainGrid.DataSource = DB.CreateTable("SELECT * FROM " & strID & "_REP ORDER BY [Description]")
        header.Text = GetDesc()
        MainView.ClearSelection()
        RaiseCustomEvent(Name, New Object() {"RANKDEPCAT", IIf(strID = "WORKRECORD", "True", "False")})
        RaiseCustomEvent(Name, New Object() {"EnablePreview"})
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub MainView_ShowingEditor(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MainView.ShowingEditor
        e.Cancel = (bPermission And 4) = 0
    End Sub

    Private Sub MainView_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MainView.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            OnRightClick(Name)
        End If
    End Sub
    
End Class
