Imports System.Drawing

Public Class NCMEASURES

    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String '= clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName) 'neil

    Public Overrides Sub ExecCustomFunction(ByVal param() As Object)
        Select Case param(0)
            Case "Preview"
                RaiseCustomEvent(Name, New Object() {"Preview", "NCMEASUREREP", "PMSReports", ""})
        End Select
    End Sub

    'Overriden From Base Control
    Public Overrides Sub SaveData()
        Dim i As Integer, strDueDate As String, strDoneDate As String, sqls As New ArrayList
        MainView.CloseEditor()
        MainView.UpdateCurrentRow()

        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", strCaption) 'neil

        For i = 0 To MainView.RowCount - 1
            If MainView.GetRowCellValue(i, "Edited") Then
                If Not MainView.GetRowCellValue(i, "DueDate") Is System.DBNull.Value Then strDueDate = ChangeToSQLDate(MainView.GetRowCellValue(i, "DueDate"))
                If Not MainView.GetRowCellValue(i, "DoneDate") Is System.DBNull.Value Then strDoneDate = ChangeToSQLDate(MainView.GetRowCellValue(i, "DoneDate"))
                sqls.Add("UPDATE [dbo].[tblNCCorrectiveMeasure] SET [Description]='" & MainView.GetRowCellValue(i, "Description") & "',[RankCode]='" & MainView.GetRowCellValue(i, "RankCode") & "',[DueDate]=" & strDueDate & ",[DoneDate]=" & strDoneDate & ",[LastUpdatedBy]='" & LastUpdatedBy & "' WHERE NCCorrectiveMeasureID=" & MainView.GetRowCellValue(i, "NCCorrectiveMeasureID"))
            End If
        Next
        DB.RunSqls(sqls)
        RefreshData()
    End Sub
    'Overriden From Base Control
    Public Overrides Sub RefreshData()
        Dim strFilter As String = ""
        If Not bLoaded Then
            RankEdit.DataSource = DB.CreateTable("SELECT RankCode,RankDesc FROM dbo.RANKLIST")
            AllowAddition(Name, False)
            AllowDeletion(Name, (bPermission And 8) > 0)
            SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
            SetSaveVisibility(Name, IIf((bPermission And 4) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never))
            SetDeleteVisibility(Name, IIf((bPermission And 8) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never))
            bLoaded = True
        End If
        If CURRENT_RANK <> "" Then strFilter = strFilter & " AND RankCode='" & CURRENT_RANK & "'"
        MainGrid.DataSource = DB.CreateTable("SELECT *, CAST(0 AS BIT) Edited FROM CORRECTIVEMEASUREUNITLIST WHERE DoneDate IS NULL" & strFilter)
        AllowSaving(Name, False)
        bRecordUpdated = False
        Me.header.Text = "PENDING CORRECTIVE MEASURES"

        clsAudit.propSQLConnStr = DB.GetConnectionString & "Password=" & SQL_PASSWORD  'neil

    End Sub


    Private Sub header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles header.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            OnRightClick(Name)
        End If
    End Sub

    Public Overrides Sub DeleteData()
        If (MainView.FocusedRowHandle < 0) Then
            MainView.DeleteRow(MainView.FocusedRowHandle)
            Exit Sub
        End If
        If MsgBox("Are you sure want to remove this Non-Conformance?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim sqls As New ArrayList

            If Not MainView.GetFocusedRowCellValue("NCID") Is System.DBNull.Value Then
                LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Delete", 10, System.Environment.MachineName, "", Me.header.Text) 'neil
                clsAudit.saveAuditPreDelDetails("tblNC", MainView.GetFocusedRowCellValue("NCID"), LastUpdatedBy)

                sqls.Add("DELETE FROM dbo.tblNC WHERE NCID='" & MainView.GetFocusedRowCellValue("NCID") & "'")
                sqls.Add("Update dbo.tblMaintenanceWork set bNC=0 Where MaintenanceWorkID=" & MainView.GetFocusedRowCellValue("MaintenanceWorkID"))
                DB.RunSqls(sqls)
                MainView.DeleteRow(MainView.FocusedRowHandle)
            End If
        End If
    End Sub

    Private Sub MainView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles MainView.CellValueChanged
        If e.Column.Name <> "Edited" Then
            MainView.SetRowCellValue(e.RowHandle, "Edited", True)
        End If
    End Sub

    Private Sub View_CellValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles MainView.CellValueChanging
        AllowSaving(Name, (bPermission And 4) > 0)
        bRecordUpdated = True
    End Sub

    Private Sub MainViewnRowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
        If IfNull(MainView.GetRowCellValue(e.RowHandle, "Edited"), False) Then
            If e.Column.ReadOnly Then
                If e.RowHandle = MainView.FocusedRowHandle Then
                    e.Appearance.BackColor = DISABLED_EDITED_COLOR
                Else
                    e.Appearance.BackColor = DISABLED_EDITED_COLOR
                End If
            Else
                If e.RowHandle = MainView.FocusedRowHandle Then
                    e.Appearance.BackColor = EDITED_COLOR
                End If
            End If
        Else
            If e.Column.ReadOnly Then
                If e.RowHandle = MainView.FocusedRowHandle Then
                    e.Appearance.BackColor = DISABLED_SELECTED_COLOR
                Else
                    e.Appearance.BackColor = DISABLED_COLOR
                End If
            Else
                If e.RowHandle = MainView.FocusedRowHandle Then
                    e.Appearance.BackColor = SEL_COLOR
                End If
            End If
        End If

    End Sub

End Class
