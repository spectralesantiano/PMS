Public Class frmCounter
    Public IS_SAVED As Boolean = False, db As SQLDB, strUnitCode As String, strCounter As String, strCounterCode As String, nReading As Integer
    Dim sqls As New ArrayList

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim i As Integer, strActiveCounter As String = ""
        sqls.Clear()
        For i = 0 To MainView.RowCount - 1
            If MainView.GetRowCellValue(i, "Edited") Then
                If MainView.GetRowCellValue(i, "ReadingDate") Is Nothing Or MainView.GetRowCellValue(i, "ReadingDate") Is System.DBNull.Value Then
                    MsgBox("Please enter the Reading Date.")
                    Exit Sub
                End If
                If MainView.GetRowCellValue(i, "CounterCode") = "" Then
                    strCounterCode = GenerateID(db, "CounterCode", "tblAdmCounter")
                    sqls.Add("Insert Into dbo.tblAdmCounter([CounterCode],[Name],[UnitCode],[LastUpdatedBy]) Values('" & strCounterCode & "','" & MainView.GetRowCellValue(i, "Counter").ToString.Replace("'", "''") & "','" & strUnitCode & "','" & GetUserName() & "')")
                ElseIf MainView.GetRowCellValue(i, "CounterCode") = "NEW" Then
                    strCounterCode = GenerateID(db, "CounterCode", "tblAdmCounter")
                    strActiveCounter = strCounterCode
                    sqls.Add("Insert Into dbo.tblAdmCounter([CounterCode],[Name],[UnitCode],[LastUpdatedBy]) Values('" & strCounterCode & "','" & MainView.GetRowCellValue(i, "Counter").ToString.Replace("'", "''") & "','" & strUnitCode & "','" & GetUserName() & "')")
                Else
                    strCounterCode = MainView.GetRowCellValue(i, "CounterCode")
                End If

                If MainView.GetRowCellValue(i, "CounterReadingID") Is System.DBNull.Value Then
                    sqls.Add("INSERT INTO [dbo].[tblCounterReading]([CounterCode],[ReadingDate],[Reading],[LastUpdatedBy]) Values('" & strCounterCode & "'," & ChangeToSQLDate(MainView.GetRowCellValue(i, "ReadingDate")) & ", " & MainView.GetRowCellValue(i, "Reading") & ",'" & GetUserName() & "')")
                Else
                    sqls.Add("Update [dbo].[tblCounterReading] set ReadingDate=" & ChangeToSQLDate(MainView.GetRowCellValue(i, "ReadingDate")) & ",Reading=" & MainView.GetRowCellValue(i, "Reading") & ", LastUpdatedBy='" & GetUserName() & "' Where CounterReadingID=" & MainView.GetRowCellValue(i, "CounterReadingID"))
                End If
            End If
        Next
        If strActiveCounter <> "" Then sqls.Add("UPDATE dbo.tblAdmCounter SET Active = 0 WHERE UnitCode='" & strUnitCode & "' AND CounterCode<>'" & strActiveCounter & "'")
        sqls.Add("UPDATE dbo.tblAdmUnit SET RunningHours=" & txtRunningHours.EditValue & " WHERE UnitCode='" & strUnitCode & "'")
        db.RunSqls(sqls)

        IS_SAVED = True
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub MainView_CellValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles MainView.CellValueChanging
        cmdSave.Enabled = True
    End Sub

    Private Sub MainView_ShowingEditor(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MainView.ShowingEditor
        e.Cancel = Not IfNull(MainView.GetRowCellValue(MainView.FocusedRowHandle, "Latest"), True)
    End Sub

    Private Sub MainView_RowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
        Dim bIsEdited As Boolean = IfNull(MainView.GetRowCellValue(e.RowHandle, "Edited"), True)
        If IfNull(MainView.GetRowCellValue(e.RowHandle, "Latest"), True) Then
            If bIsEdited And MainView.FocusedRowHandle = e.RowHandle Then
                e.Appearance.BackColor = EDITED_FOCUSED_COLOR
            ElseIf bIsEdited Then
                e.Appearance.BackColor = EDITED_COLOR
            ElseIf e.RowHandle = MainView.FocusedRowHandle Then
                e.Appearance.BackColor = SEL_COLOR
            End If
        Else
            e.Appearance.BackColor = DISABLED_COLOR
        End If
    End Sub

    Private Sub MainView_cellvaluechanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles MainView.CellValueChanged
        If e.Column.Name = "Reading" Then
            GetTotalHours()
        End If
        If e.Column.Name <> "Edited" Then
            MainView.SetRowCellValue(e.RowHandle, "Edited", True)
        End If

    End Sub

    Private Sub MainView_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles MainView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, View.Columns("Edited"), True)
        View.SetRowCellValue(e.RowHandle, View.Columns("Latest"), True)
        View.SetRowCellValue(e.RowHandle, View.Columns("CounterCode"), strCounterCode)
        View.SetRowCellValue(e.RowHandle, View.Columns("Counter"), strCounter)
        View.SetRowCellValue(e.RowHandle, View.Columns("Reading"), nReading)
    End Sub

    Sub GetTotalHours()
        Dim i As Integer, nSum As Integer = 0
        MainView.UpdateCurrentRow()
        MainView.CloseEditor()
        For i = 0 To MainView.RowCount - 1
            If IfNull(MainView.GetRowCellValue(i, "Latest"), True) Then
                nSum = nSum + MainView.GetRowCellValue(i, "Reading")
            End If
        Next
        txtRunningHours.EditValue = nSum
    End Sub

    Private Sub cmdAdd_Click(sender As System.Object, e As System.EventArgs) Handles cmdAdd.Click
        sqls.Clear()
        strCounterCode = "NEW"
        strCounter = txtName.EditValue
        nReading = 0
        MainView.AddNewRow()
        cmdSave.Enabled = True
        chkAdd.Checked = False
        chkAdd.Enabled = False
    End Sub
    Private Sub chkAdd_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkAdd.CheckedChanged
        txtName.Enabled = chkAdd.Checked
        cmdAdd.Enabled = chkAdd.Checked
        If chkAdd.Checked Then
            txtName.EditValue = MainView.GetRowCellDisplayText(0, "Counter") & " - Replacement"
        End If
    End Sub
    

    Private Sub frmCounter_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'CounterEdit.DataSource = db.CreateTable("SELECT * FROM dbo.COUNTERLIST WHERE UnitCode='" & strUnitCode & "'")
        GetTotalHours()
    End Sub

    

    

End Class