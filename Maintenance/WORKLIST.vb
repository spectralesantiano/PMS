Imports System.Drawing
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraTreeList.Columns
Imports DevExpress.Data.Filtering

Public Class WORKLIST

    Private Sub tlMain_BeforeCollapse(sender As Object, e As DevExpress.XtraTreeList.BeforeCollapseEventArgs) Handles tlMain.BeforeCollapse
        'e.CanCollapse = False
    End Sub

    Private Sub tlMain_FocusedNodeChanged(sender As Object, e As DevExpress.XtraTreeList.FocusedNodeChangedEventArgs) Handles tlMain.FocusedNodeChanged
        CURRENT_UNIT = tlMain.FocusedNode.GetValue("UnitCode")
        SelectionChange(Name)
    End Sub

    Private Sub tlMain_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tlMain.MouseUp
        Dim tl As TreeList = TryCast(sender, TreeList), info As TreeListHitInfo = tl.CalcHitInfo(e.Location)
        If (e.Button = Windows.Forms.MouseButtons.Right And info.HitInfoType = HitInfoType.Cell) Then
            CellRightClick(Name)
        End If
    End Sub

    Private Sub tlMain_NodeCellStyle(sender As Object, e As DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs) Handles tlMain.NodeCellStyle
        If e.Node.Focused Then
            e.Appearance.BackColor = SEL_COLOR
        End If
    End Sub

    Public Overrides Sub RefreshData()
        Dim nRow As Integer = -1, nTempUnit As String = CURRENT_UNIT, tblTmp As DataTable = DB.CreateTable("SELECT * FROM [dbo].[WORKLIST] ORDER BY CASE WHEN ParentCode IS NULL THEN 0 ELSE 1 END, UnitDesc")
        bDisableSelectionEvent = True
        tlMain.DataSource = tblTmp
        If tblTmp.Rows.Count > 0 Then
            'tlMain.ExpandAll()
            CURRENT_UNIT = nTempUnit
            If CURRENT_UNIT <> "" Then
                tlMain.FocusedNode = tlMain.FindNodeByFieldValue("UnitCode", CURRENT_UNIT)
            End If
        End If
        bDisableSelectionEvent = False
    End Sub

    Public Overrides Sub SetFilter(ByVal _criteria As String)
        strFilter = ""
        If CURRENT_DEPARTMENT <> "" Then strFilter = strFilter & "AND DeptCode='" & CURRENT_DEPARTMENT & "'"
        If CURRENT_CATEGORY <> "" Then strFilter = strFilter & "AND CatCode='" & CURRENT_CATEGORY & "'"
        If CURRENT_CRITICAL_CHECKED Then strFilter = strFilter & "AND Critical=True"
        If strFilter.Length > 0 Then strFilter = strFilter.Remove(0, 4)
        Me.tlMain.ActiveFilterString = strFilter
    End Sub

    Public Overrides Function GetID() As String
        If tlMain.AllNodesCount > 0 Then
            Return tlMain.FocusedNode.GetValue("UnitCode")
        Else
            Return ""
        End If
    End Function

    Public Overrides Function GetDesc() As String
        If tlMain.AllNodesCount > 0 Then
            Return tlMain.FocusedNode.GetValue("Description")
        Else
            Return ""
        End If
    End Function

    Public Overrides Function GetFocusedRowData(ByVal _columnname As String) As Object
        Try
            Return tlMain.FocusedNode.GetValue(_columnname)
        Catch ex As Exception
            Return System.DBNull.Value
        End Try

    End Function

    Public Overrides Sub SetSelection(ByVal id As String)
        Try
            bAddMode = False
            tlMain.FindNodeByKeyID(id)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub MainView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyData = Windows.Forms.Keys.Down Then
            tlMain.MoveNext()
            e.Handled = True
        ElseIf e.KeyData = Windows.Forms.Keys.Up Then
            tlMain.MovePrev()
            e.Handled = True
        End If
    End Sub


    Public Overrides Sub ExecCustomFunction(ByVal param() As Object)
        Select Case param(0)
            Case "RefreshView"
                'MainView.SetRowCellValue(MainView.FocusedRowHandle, "bShowWarning", CBool(param(1)))
                'MainView.SetRowCellValue(MainView.FocusedRowHandle, "bIsDue", CBool(param(2)))
                'MainView.RefreshRow(MainView.FocusedRowHandle)
        End Select
    End Sub

    Private Sub txtOrdered_EditValueChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub tlMain_FilterNode(sender As Object, e As DevExpress.XtraTreeList.FilterNodeEventArgs) Handles tlMain.FilterNode
        'If CURRENT_DEPARTMENT <> "" Then
        '    If e.Node.GetValue("DeptCode") Then
        '    End If

    End Sub
End Class
