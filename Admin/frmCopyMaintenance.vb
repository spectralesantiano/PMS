Public Class frmCopyMaintenance
    Public UpdateSQL As String = "", strUnitCode As String

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim otherparam As String = "|"
        Dim cnt As Integer
        For cnt = 0 To MainView.RowCount - 1
            If MainView.GetRowCellValue(cnt, "Selected") Then
                otherparam = otherparam & MainView.GetRowCellValue(cnt, "UnitCode") & "|"
            End If
        Next
        If otherparam.Length = 1 Then
            MsgBox("Please select at least one record.", MsgBoxStyle.Information, GetAppName)
            Exit Sub
        End If
        UpdateSQL = "INSERT INTO [dbo].[tblAdmMaintenance]([MaintenanceCode],[WorkCode],[UnitCode],[RankCode],[Number],[IntCode],[InsCrossRef],[InsEditor],[InsDocument],[InsDateIssue],[InsDesc],[LastUpdatedBy]) " & _
            "SELECT dbo.MAINTENANCEID(), t.* " & _
            "FROM (SELECT WorkCode, u.UnitCode, RankCode, Number, IntCode, InsCrossRef, InsEditor, InsDocument, InsDateIssue, InsDesc, '' as LastUpdatedBy " & _
            "FROM dbo.tblAdmUnit u,(SELECT * FROM dbo.tblAdmMaintenance WHERE (UnitCode = '" & strUnitCode & "')) m " & _
            "WHERE  CHARINDEX('|' + u.UnitCode + '|','" & otherparam & "') > 0) t " & _
            "LEFT JOIN dbo.tblAdmMaintenance am ON t.UnitCode=am.UnitCode AND t.WorkCode=am.WorkCode " & _
            "WHERE am.WorkCode IS NULL"
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub View_RowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle ', mView.RowCellStyle
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If view.IsRowSelected(e.RowHandle) Then
            e.Appearance.BackColor = SEL_COLOR
        End If
    End Sub

    Private Sub cmdSelectAll_Click(sender As System.Object, e As System.EventArgs) Handles cmdSelectAll.Click
        SelectUnit(True)
    End Sub


    Sub SelectUnit(bValue As Boolean)
        Dim i As Integer
        For i = 0 To MainView.RowCount - 1
            MainView.SetRowCellValue(i, "Selected", bValue)
        Next
    End Sub

    Private Sub cmdDeselect_Click(sender As System.Object, e As System.EventArgs) Handles cmdDeselect.Click
        SelectUnit(False)
    End Sub
End Class