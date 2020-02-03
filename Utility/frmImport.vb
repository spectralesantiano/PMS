Public Class frmImport
    Public bSaved As Boolean = False

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim i As Integer
        For i = 0 To MainView.RowCount - 1
            If MainView.GetRowCellValue(i, Field1) = "" Then
                MsgBox("Please enter the value for " & Field1.Caption & " field.", vbCritical)
                Exit Sub
            ElseIf Field2.Visible Then
                If MainView.GetRowCellValue(i, Field2) = "" Then
                    MsgBox("Please enter the value for " & Field2.Caption & " field.", vbCritical)
                    Exit Sub
                End If
            End If
        Next
        bSaved = True
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
        SelectAll(True)
    End Sub

    Private Sub cmdDeselect_Click(sender As System.Object, e As System.EventArgs) Handles cmdDeselect.Click
        SelectAll(False)
    End Sub

    Sub SelectAll(bSelect As Boolean)
        Dim i As Integer
        For i = 0 To MainView.RowCount - 1
            MainView.SetRowCellValue(i, "Selected", bSelect)
        Next
    End Sub

    Sub TrimAll(bStart As Boolean)
        Dim i As Integer
        For i = 0 To MainView.RowCount - 1
            Dim strValue As String = MainView.GetRowCellValue(i, Field1)
            'MainView.SetRowCellValue(i, "Selected", bSelect)
            If strValue.Length > 0 Then
                If bStart Then
                    MainView.SetRowCellValue(i, Field1, strValue.Remove(0, 1))
                Else
                    MainView.SetRowCellValue(i, Field1, strValue.Remove(strValue.Length - 1, 1))
                End If
            End If
        Next
    End Sub

    Private Sub cmdRemoveEnd_Click(sender As System.Object, e As System.EventArgs) Handles cmdRemoveEnd.Click
        TrimAll(False)
    End Sub

    Private Sub cmdRemoveStart_Click(sender As System.Object, e As System.EventArgs) Handles cmdRemoveStart.Click
        TrimAll(True)
    End Sub

End Class