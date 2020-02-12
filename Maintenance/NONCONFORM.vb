Imports System.Drawing

Public Class NONCONFORM

    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String '= clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName) 'neil

    Public Overrides Sub ExecCustomFunction(ByVal param() As Object)
        Select Case param(0)
            Case "Preview"
                RaiseCustomEvent(Name, New Object() {"Preview", "NCREP", "PMSReports", "|" & MainView.GetFocusedRowCellValue("NCID") & "|"})
            Case "EditNC"
                EditNC()
            Case "UpdateNC"
                UpdateNC()
        End Select
    End Sub

    Private Sub UpdateNC()
        Dim frm As New frmUpdateNC
        frm.ShowDialog()
        If frm.IS_SAVED Then
            DB.BeginReader("SELECT NCCorrectiveMeasureID FROM dbo.tblNCCorrectiveMeasure WHERE NCID='" & MainView.GetFocusedRowCellValue("NCID") & "' AND DoneDate IS NULL")
            If DB.Read Then
                DB.CloseReader()
                MsgBox("Unable to close Non-Corformance! Required description of corrective action is missing.", MsgBoxStyle.Critical, GetAppName)
                Exit Sub
            End If
            DB.CloseReader()
            DB.RunSql("UPDATE [dbo].[tblNC] SET [VerifiedBy]='" & frm.txtVerifiedBy.EditValue.ToString.Replace("'", "''") & "', [DateVerified]=" & ChangeToSQLDate(frm.txtVerifiedDate.EditValue) & ",[IsStatusClosed]=1  WHERE NCID='" & MainView.GetFocusedRowCellValue("NCID") & "'")
        End If
        MainView.SetRowCellValue(MainView.FocusedRowHandle, "Status", "Closed")
        MainView.RefreshRow(MainView.FocusedRowHandle)
    End Sub
    'Overriden From Base Control
    Public Overrides Sub SaveData()
    End Sub

    'Overriden From Base Control
    Public Overrides Sub AddData()
        If MainView.IsGroupRow(MainView.FocusedRowHandle) Then
            MainView.CollapseGroupRow(MainView.FocusedRowHandle)
        End If
    End Sub

    'Overriden From Base Control
    Public Overrides Function GetDesc() As String
        Return "Equipment - " & strDesc
    End Function

    'Overriden From Base Control
    Public Overrides Sub RefreshData()
        Dim strFilter As String = ""
        If Not bLoaded Then
            RaiseCustomEvent(Name, New Object() {"RenameNC", "Edit NC"})
            AllowAddition(Name, (bPermission And 2) > 0)
            AllowDeletion(Name, (bPermission And 8) > 0)
            SetSaveVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
            SetDeleteVisibility(Name, IIf((bPermission And 8) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never))
            bLoaded = True
        End If
        If CURRENT_DEPARTMENT <> "" Then strFilter = strFilter & "AND DeptCode='" & CURRENT_DEPARTMENT & "'"
        If strFilter.Length > 0 Then strFilter = " WHERE " & strFilter.Remove(0, 4)
        MainGrid.DataSource = DB.CreateTable("SELECT * FROM NCLIST" & strFilter)
        Me.header.Text = "NON-CONFORMANCES"

        clsAudit.propSQLConnStr = DB.GetConnectionString & "Password=" & SQL_PASSWORD  'neil

    End Sub

    Private Sub MainView_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles MainView.FocusedRowChanged
        If MainView.FocusedRowHandle >= 0 Then
            If bLoaded Then
                If MainView.GetRowCellValue(MainView.FocusedRowHandle, "Status") = "Open" Then
                    RaiseCustomEvent(Name, New Object() {"EnableEditNC"})
                Else
                    RaiseCustomEvent(Name, New Object() {"DisableEditNC"})
                End If
            End If

        End If
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
                clsAudit.saveAuditPreDelDetails("tblNC", strID, LastUpdatedBy)

                sqls.Add("DELETE FROM dbo.tblNC WHERE NCID='" & MainView.GetFocusedRowCellValue("NCID") & "'")
                sqls.Add("Update dbo.tblMaintenanceWork set bNC=0 Where MaintenanceWorkID=" & MainView.GetFocusedRowCellValue("MaintenanceWorkID"))
                DB.RunSqls(sqls)
                MainView.DeleteRow(MainView.FocusedRowHandle)
            End If
        End If
    End Sub

    Private Sub EditNC()
        Dim frm As New frmNC, bNCExist As Boolean = IfNull(MainView.GetFocusedRowCellValue("bNC"), 0), strNCID As String, i As Integer, strDueDate As String = "NULL", strDoneDate As String = "NULL"
        frm.RankEdit.DataSource = AdmRank
        frm.nMaintenanceWorkID = MainView.GetFocusedRowCellValue("MaintenanceWorkID")
        frm.txtWorkDate.EditValue = MainView.GetFocusedRowCellValue("WorkDate")
        frm.txtWorkCounter.EditValue = MainView.GetFocusedRowCellValue("WorkCounter")
        strNCID = MainView.GetFocusedRowCellValue("NCID")
        frm.txtDiscoveredBy.EditValue = MainView.GetFocusedRowCellValue("DiscoveredBy")
        frm.txtReportedTo.EditValue = MainView.GetFocusedRowCellValue("ReportedTo")
        frm.txtDescription.EditValue = MainView.GetFocusedRowCellValue("Description")
        frm.txtImmediateAction.EditValue = MainView.GetFocusedRowCellValue("ImmediateAction")
        frm.txtCauses.EditValue = MainView.GetFocusedRowCellValue("Cause")
        frm.txtObjectives.EditValue = MainView.GetFocusedRowCellValue("Objective")
        frm.txtStatus.EditValue = MainView.GetFocusedRowCellValue("Status")
        frm.gDetails.Text = frm.gDetails.Text & " " & MainView.GetFocusedRowCellValue("Unit")
        frm.MainGrid.DataSource = DB.CreateTable("SELECT *, CAST(0 AS BIT) Edited FROM dbo.tblNCCorrectiveMeasure WHERE NCID='" & strNCID & "'")
        frm.ShowDialog()
        If frm.IS_SAVED Then
            Dim sqls As New ArrayList
            sqls.Add("UPDATE [dbo].[tblNC] SET [DiscoveredBy]='" & frm.txtDiscoveredBy.EditValue.ToString.Replace("'", "''") & "',[ReportedTo]='" & frm.txtReportedTo.EditValue.ToString.Replace("'", "''") & "',[Description]='" & frm.txtDescription.EditValue.ToString.Replace("'", "''") & "',[ImmediateAction]='" & frm.txtImmediateAction.EditValue.ToString.Replace("'", "''") & "',[Cause]='" & frm.txtCauses.EditValue.ToString.Replace("'", "''") & "',[Objective]='" & frm.txtObjectives.EditValue.ToString.Replace("'", "''") & "' WHERE NCID='" & strNCID & "'")
            frm.MainView.CloseEditor()
            frm.MainView.UpdateCurrentRow()

            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", Me.header.Text) 'neil

            For i = 0 To frm.MainView.RowCount - 1
                If frm.MainView.GetRowCellValue(i, "Edited") Then
                    If Not frm.MainView.GetRowCellValue(i, "DueDate") Is System.DBNull.Value Then strDueDate = ChangeToSQLDate(frm.MainView.GetRowCellValue(i, "DueDate"))
                    If Not frm.MainView.GetRowCellValue(i, "DoneDate") Is System.DBNull.Value Then strDoneDate = ChangeToSQLDate(frm.MainView.GetRowCellValue(i, "DoneDate"))
                    If IfNull(frm.MainView.GetRowCellValue(i, "NCCorrectiveMeasureID"), 0) = 0 Then
                        sqls.Add("INSERT INTO [dbo].[tblNCCorrectiveMeasure]([NCID],[Description],[RankCode],[DueDate],[DoneDate],[LastUpdatedBy]) Values('" & strNCID & "', '" & frm.MainView.GetRowCellValue(i, "Description") & "', '" & frm.MainView.GetRowCellValue(i, "RankCode") & "', " & strDueDate & ", " & strDoneDate & ",'" & LastUpdatedBy & "')")
                    Else
                        sqls.Add("UPDATE [dbo].[tblNCCorrectiveMeasure] SET [Description]='" & frm.MainView.GetRowCellValue(i, "Description") & "',[RankCode]='" & frm.MainView.GetRowCellValue(i, "RankCode") & "',[DueDate]=" & strDueDate & ",[DoneDate]=" & strDoneDate & ",[LastUpdatedBy]='" & LastUpdatedBy & "' WHERE NCCorrectiveMeasureID=" & frm.MainView.GetRowCellValue(i, "NCCorrectiveMeasureID"))
                    End If
                End If
            Next
            If frm.delsqls.Count > 0 Then
                Dim strTemp As String
                For Each strTemp In frm.delsqls
                    sqls.Add(strTemp)
                Next
            End If
            MainView.SetRowCellValue(MainView.FocusedRowHandle, "DiscoveredBy", frm.txtDiscoveredBy.EditValue)
            MainView.SetRowCellValue(MainView.FocusedRowHandle, "ReportedTo", frm.txtReportedTo.EditValue)
            MainView.SetRowCellValue(MainView.FocusedRowHandle, "Description", frm.txtDescription.EditValue)
            MainView.SetRowCellValue(MainView.FocusedRowHandle, "ImmediateAction", frm.txtImmediateAction.EditValue)
            MainView.SetRowCellValue(MainView.FocusedRowHandle, "Cause", frm.txtCauses.EditValue)
            MainView.SetRowCellValue(MainView.FocusedRowHandle, "Objective", frm.txtObjectives.EditValue)
            DB.RunSqls(sqls)
        End If
    End Sub

    
    Private Sub MainViewnRowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
        If MainView.GetRowCellValue(e.RowHandle, "Status") = "Open" Then
            If e.RowHandle = MainView.FocusedRowHandle Then
                e.Appearance.BackColor = SEL_COLOR
            End If
        Else
            If e.RowHandle = MainView.FocusedRowHandle Then
                e.Appearance.BackColor = DISABLED_SELECTED_COLOR
            Else
                e.Appearance.BackColor = DISABLED_COLOR
            End If
        End If
    End Sub

End Class
