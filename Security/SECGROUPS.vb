Public Class SECGROUPS
    Dim bDisableCelVal As Boolean = False

    'Overriden From Base Control
    Public Overrides Sub DeleteData()
        If MsgBox("Are you sure want to delete the " & strDesc & " Group?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim sqls As New ArrayList
            sqls.Add("DELETE FROM dbo.tblSec_Objects WHERE SecID=" & strID & " AND SecType=1")
            sqls.Add("UPDATE dbo.tblSec_Users SET [Group ID]=NULL WHERE [Group ID]=" & strID)
            sqls.Add("DELETE FROM dbo.tblSec_Groups WHERE [Group ID]=" & strID)
            DB.RunTransaction(sqls)
        End If
        blList.RefreshData()
        RefreshData()
    End Sub

    'Overriden From Base Control
    Public Overrides Sub SaveData()
        Dim bHasObject As Boolean = False, i As Integer
        MainView.CloseEditor()
        MainView.UpdateCurrentRow()
        For i = 1 To MainView.RowCount - 1
            If MainView.GetRowCellValue(i, "HasOpen") Then
                bHasObject = True
                Exit For
            End If
        Next
        If bHasObject Then
            If ValidateFields(New DevExpress.XtraEditors.TextEdit() {Me.txtName}) Then
                Dim sqls As New ArrayList, bHasWRHRep As Boolean = False, bHasCrewWRH As Boolean = False
                If bAddMode Then
                    If DB.DLookUp("[Group ID]", "dbo.tblSec_Groups", "", "[Group Name]='" & Me.txtName.EditValue.ToString.Replace("'", "''") & "'") <> "" Then
                        MsgBox("The " & Me.txtName.EditValue & " Group already exists.", MsgBoxStyle.Critical, GetAppName)
                        Exit Sub
                    End If
                    DB.RunSql("INSERT INTO dbo.tblSec_Groups([Group Name], LastUpdatedBy) VALUES('" & Me.txtName.EditValue.ToString.Replace("'", "''") & "', '" & GetUserName() & "')")
                    strID = DB.DLookUp("[Group ID]", "dbo.tblSec_Groups", "", "[Group Name]='" & Me.txtName.EditValue.ToString.Replace("'", "''") & "'")
                    For i = 1 To MainView.RowCount - 1
                        Dim xpermission As Int16 = (IIf(MainView.GetRowCellValue(i, "HasOpen"), 1, 0) + IIf(MainView.GetRowCellValue(i, "HasAdd"), 2, 0) + IIf(MainView.GetRowCellValue(i, "HasEdit"), 4, 0) + IIf(MainView.GetRowCellValue(i, "HasDelete"), 8, 0)) + IIf(MainView.GetRowCellValue(i, "HasImport"), 16, 0)
                        If xpermission > 0 Then
                            If MainView.GetRowCellValue(i, "SecObjectID") = 0 Then
                                sqls.Add("INSERT INTO dbo.tblSec_Objects(ObjectID, SecID, SecType, Permission) VALUES('" & MainView.GetRowCellValue(i, "ObjectID") & "', " & strID & ", 1, " & xpermission & ")")
                            Else
                                sqls.Add("UPDATE dbo.tblSec_Objects SET Permission=" & xpermission & " WHERE SecObjectID=" & MainView.GetRowCellValue(i, "SecObjectID"))
                            End If
                            If Trim(MainView.GetRowCellValue(i, "CategoryCode")) = "PMSREPORTS" Then bHasWRHRep = True
                            If Trim(MainView.GetRowCellValue(i, "ObjectID")) = "PMSREP" Then bHasCrewWRH = True
                        End If
                    Next
                    For i = 0 To UserView.RowCount - 1
                        If UserView.GetRowCellValue(i, "UserEdited") = 1 Then
                            sqls.Add("UPDATE dbo.tblSec_Users SET [Group ID]=" & IIf(UserView.GetRowCellValue(i, "Selected"), strID, "NULL") & " WHERE [User ID]=" & UserView.GetRowCellValue(i, "UserID"))
                        End If
                    Next
                Else
                    Dim sql As String = ""
                    If Me.txtName.Tag = 1 Then
                        Dim xID As String = DB.DLookUp("[Group ID]", "dbo.tblSec_Groups", "", "[Group Name]='" & Me.txtName.EditValue.ToString.Replace("'", "''") & "'")
                        If xID <> strID Then
                            MsgBox("The " & Me.txtName.EditValue & " Group already exists.", MsgBoxStyle.Critical, GetAppName)
                            Exit Sub
                        End If
                        sql = sql & "[Group Name]='" & Me.txtName.EditValue.ToString.Replace("'", "''") & "', "
                    End If
                    If sql <> "" Then
                        sqls.Add("UPDATE dbo.tblSec_Groups SET " & sql & " LastUpdatedBy = '" & GetUserName() & "' WHERE [Group ID]=" & strID & "")
                    End If
                    For i = 1 To MainView.RowCount - 1
                        Dim xpermission As Int16 = (IIf(MainView.GetRowCellValue(i, "HasOpen"), 1, 0) + IIf(MainView.GetRowCellValue(i, "HasAdd"), 2, 0) + IIf(MainView.GetRowCellValue(i, "HasEdit"), 4, 0) + IIf(MainView.GetRowCellValue(i, "HasDelete"), 8, 0)) + IIf(MainView.GetRowCellValue(i, "HasImport"), 16, 0)
                        If MainView.GetRowCellValue(i, "Edited") = 1 Then
                            If MainView.GetRowCellValue(i, "SecObjectID") = 0 Then
                                sqls.Add("INSERT INTO dbo.tblSec_Objects(ObjectID, SecID, SecType, Permission) VALUES('" & MainView.GetRowCellValue(i, "ObjectID") & "', " & strID & ", 1, " & xpermission & ")")
                            Else
                                sqls.Add("UPDATE dbo.tblSec_Objects SET Permission=" & xpermission & " WHERE SecObjectID=" & MainView.GetRowCellValue(i, "SecObjectID"))
                            End If
                        End If
                        If Trim(MainView.GetRowCellValue(i, "CategoryCode")) = "PMSREPORTS" And xpermission > 0 Then bHasWRHRep = True
                        If Trim(MainView.GetRowCellValue(i, "ObjectID")) = "PMSREP" And xpermission > 0 Then bHasCrewWRH = True
                    Next
                    UserView.CloseEditor()
                    For i = 0 To UserView.RowCount - 1
                        If UserView.GetRowCellValue(i, "UserEdited") = 1 Then
                            sqls.Add("UPDATE dbo.tblSec_Users SET [Group ID]=" & IIf(UserView.GetRowCellValue(i, "Selected"), strID, "NULL") & " WHERE [User ID]=" & UserView.GetRowCellValue(i, "UserID"))
                        End If
                    Next
                End If
                'Add permission to the WRH Report Section.
                If bHasWRHRep And Not bHasCrewWRH Then
                    sqls.Add("DELETE FROM dbo.tblSec_Objects WHERE ObjectID='PMSREP' AND SecID=" & strID)
                    sqls.Add("INSERT INTO dbo.tblSec_Objects(ObjectID, SecID, SecType, Permission) VALUES('PMSREP', " & strID & ", 1, 1)")
                End If

                DB.RunSqls(sqls)
                bAddMode = False
                bRecordUpdated = False
                blList.RefreshData()
                blList.SetSelection(strID)
                RefreshData()
                
            End If
        Else
            MsgBox("Please assign permission(s) for this group.", MsgBoxStyle.Critical, GetAppName)
        End If
    End Sub

    Private Sub MainView_CellValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles MainView.CellValueChanging
        If Not bDisableCelVal Then
            UpdateAll(e.Column.Name, e.Value, MainView.FocusedRowHandle)
        End If
        AllowSaving(Name, (bPermission And 4) > 0) 'Has Edit permission
        bRecordUpdated = True
    End Sub

    'Overriden From Base Control
    Public Overrides Sub AddData()
        If Not bAddMode Then
            ClearFields(Me.header, False)
            AllowSaving(Name, False) 'Disable save button 
            AllowDeletion(Name, False) 'Disable Delete button
            bAddMode = True
            blList.HideSelection()
            strID = ""
            strDesc = "New Record"
            bRecordUpdated = False
            Me.MainGrid.DataSource = DB.CreateTable("SELECT * FROM dbo.SECOBJECTBLANK ORDER BY SortCode")
            Me.UserGrid.DataSource = DB.CreateTable("EXEC SECGROUP_SEL @GroupID=0")
            txtFilter.EditValue = "ALL"
        End If
    End Sub

    'Overriden From Base Control
    Public Overrides Function GetDesc() As String
        Return "Groups - " & strDesc
    End Function

    Private Sub UpdateAll(ByVal nField As String, ByVal val As Boolean, ByVal rowhandle As Integer)
        bDisableCelVal = True
        If nField = "HasFullPermission" And val Then
            MainView.SetRowCellValue(MainView.FocusedRowHandle, "HasFullPermission", val)
            MainView.SetRowCellValue(MainView.FocusedRowHandle, "HasOpen", val)
            If (MainView.GetRowCellValue(MainView.FocusedRowHandle, "MaxPermission") And 2) > 0 Then MainView.SetRowCellValue(MainView.FocusedRowHandle, "HasAdd", val)
            If (MainView.GetRowCellValue(MainView.FocusedRowHandle, "MaxPermission") And 4) > 0 Then MainView.SetRowCellValue(MainView.FocusedRowHandle, "HasEdit", val)
            If (MainView.GetRowCellValue(MainView.FocusedRowHandle, "MaxPermission") And 8) > 0 Then MainView.SetRowCellValue(MainView.FocusedRowHandle, "HasDelete", val)
            If (MainView.GetRowCellValue(MainView.FocusedRowHandle, "MaxPermission") And 16) > 0 Then MainView.SetRowCellValue(MainView.FocusedRowHandle, "HasImport", val)
        ElseIf nField = "HasFullPermission" Then
            MainView.SetRowCellValue(MainView.FocusedRowHandle, "HasFullPermission", val)
        ElseIf nField = "HasOpen" And val Then
            MainView.SetRowCellValue(MainView.FocusedRowHandle, "HasOpen", val)
        ElseIf nField = "HasOpen" Then
            MainView.SetRowCellValue(MainView.FocusedRowHandle, "HasOpen", val)
            If (MainView.GetRowCellValue(MainView.FocusedRowHandle, "MaxPermission") And 2) > 0 Then MainView.SetRowCellValue(MainView.FocusedRowHandle, "HasAdd", val)
            If (MainView.GetRowCellValue(MainView.FocusedRowHandle, "MaxPermission") And 4) > 0 Then MainView.SetRowCellValue(MainView.FocusedRowHandle, "HasEdit", val)
            If (MainView.GetRowCellValue(MainView.FocusedRowHandle, "MaxPermission") And 8) > 0 Then MainView.SetRowCellValue(MainView.FocusedRowHandle, "HasDelete", val)
            If (MainView.GetRowCellValue(MainView.FocusedRowHandle, "MaxPermission") And 16) > 0 Then MainView.SetRowCellValue(MainView.FocusedRowHandle, "HasImport", val)
        ElseIf nField = "HasAdd" And val Then
            If (MainView.GetRowCellValue(MainView.FocusedRowHandle, "MaxPermission") And 2) > 0 Then MainView.SetRowCellValue(MainView.FocusedRowHandle, "HasOpen", val)
            If (MainView.GetRowCellValue(MainView.FocusedRowHandle, "MaxPermission") And 2) > 0 Then MainView.SetRowCellValue(MainView.FocusedRowHandle, "HasAdd", val)
            If (MainView.GetRowCellValue(MainView.FocusedRowHandle, "MaxPermission") And 4) > 0 And (MainView.GetRowCellValue(MainView.FocusedRowHandle, "MaxPermission") And 2) > 0 Then MainView.SetRowCellValue(MainView.FocusedRowHandle, "HasEdit", val)
        ElseIf nField = "HasAdd" Then
            If (MainView.GetRowCellValue(MainView.FocusedRowHandle, "MaxPermission") And 2) > 0 Then MainView.SetRowCellValue(MainView.FocusedRowHandle, "HasAdd", val)
        ElseIf nField = "HasEdit" And val Then
            If (MainView.GetRowCellValue(MainView.FocusedRowHandle, "MaxPermission") And 4) > 0 Then MainView.SetRowCellValue(MainView.FocusedRowHandle, "HasOpen", val)
            If (MainView.GetRowCellValue(MainView.FocusedRowHandle, "MaxPermission") And 4) > 0 Then MainView.SetRowCellValue(MainView.FocusedRowHandle, "HasEdit", val)
        ElseIf nField = "HasEdit" Then
            If (MainView.GetRowCellValue(MainView.FocusedRowHandle, "MaxPermission") And 4) > 0 Then MainView.SetRowCellValue(MainView.FocusedRowHandle, "HasEdit", val)
            If (MainView.GetRowCellValue(MainView.FocusedRowHandle, "MaxPermission") And 2) > 0 Then MainView.SetRowCellValue(MainView.FocusedRowHandle, "HasAdd", val)
        ElseIf nField = "HasDelete" And val Then
            If (MainView.GetRowCellValue(MainView.FocusedRowHandle, "MaxPermission") And 8) > 0 Then MainView.SetRowCellValue(MainView.FocusedRowHandle, "HasOpen", val)
            If (MainView.GetRowCellValue(MainView.FocusedRowHandle, "MaxPermission") And 8) > 0 Then MainView.SetRowCellValue(MainView.FocusedRowHandle, "HasDelete", val)
        ElseIf nField = "HasDelete" Then
            If (MainView.GetRowCellValue(MainView.FocusedRowHandle, "MaxPermission") And 8) > 0 Then MainView.SetRowCellValue(MainView.FocusedRowHandle, "HasDelete", val)
        ElseIf nField = "HasImport" And val Then
            If (MainView.GetRowCellValue(MainView.FocusedRowHandle, "MaxPermission") And 16) > 0 Then MainView.SetRowCellValue(MainView.FocusedRowHandle, "HasOpen", val)
            If (MainView.GetRowCellValue(MainView.FocusedRowHandle, "MaxPermission") And 16) > 0 Then MainView.SetRowCellValue(MainView.FocusedRowHandle, "HasImport", val)
        ElseIf nField = "HasImport" Then
            If (MainView.GetRowCellValue(MainView.FocusedRowHandle, "MaxPermission") And 16) > 0 Then MainView.SetRowCellValue(MainView.FocusedRowHandle, "HasImport", val)
            If (MainView.GetRowCellValue(MainView.FocusedRowHandle, "MaxPermission") And 2) > 0 Then MainView.SetRowCellValue(MainView.FocusedRowHandle, "HasAdd", val)
        End If
        MainView.SetRowCellValue(MainView.FocusedRowHandle, "HasFullPermission", MainView.GetRowCellValue(MainView.FocusedRowHandle, "MaxPermission") = (IIf(MainView.GetRowCellValue(MainView.FocusedRowHandle, "HasOpen"), 1, 0) + IIf(MainView.GetRowCellValue(MainView.FocusedRowHandle, "HasAdd"), 2, 0) + IIf(MainView.GetRowCellValue(MainView.FocusedRowHandle, "HasEdit"), 4, 0) + IIf(MainView.GetRowCellValue(MainView.FocusedRowHandle, "HasDelete"), 8, 0)))
        MainView.SetRowCellValue(MainView.FocusedRowHandle, "Edited", 1)
        If rowhandle = 0 Then
            Dim i As Integer
            For i = 1 To MainView.RowCount - 1
                If nField = "HasFullPermission" And val Then
                    MainView.SetRowCellValue(i, "HasFullPermission", val)
                    MainView.SetRowCellValue(i, "HasOpen", val)
                    If (MainView.GetRowCellValue(i, "MaxPermission") And 2) > 0 Then MainView.SetRowCellValue(i, "HasAdd", val)
                    If (MainView.GetRowCellValue(i, "MaxPermission") And 4) > 0 Then MainView.SetRowCellValue(i, "HasEdit", val)
                    If (MainView.GetRowCellValue(i, "MaxPermission") And 8) > 0 Then MainView.SetRowCellValue(i, "HasDelete", val)
                    If (MainView.GetRowCellValue(i, "MaxPermission") And 16) > 0 Then MainView.SetRowCellValue(i, "HasImport", val)
                ElseIf nField = "HasFullPermission" Then
                    MainView.SetRowCellValue(i, "HasFullPermission", val)
                ElseIf nField = "HasOpen" And val Then
                    MainView.SetRowCellValue(i, "HasOpen", val)
                ElseIf nField = "HasOpen" Then
                    MainView.SetRowCellValue(i, "HasOpen", val)
                    If (MainView.GetRowCellValue(i, "MaxPermission") And 2) > 0 Then MainView.SetRowCellValue(i, "HasAdd", val)
                    If (MainView.GetRowCellValue(i, "MaxPermission") And 4) > 0 Then MainView.SetRowCellValue(i, "HasEdit", val)
                    If (MainView.GetRowCellValue(i, "MaxPermission") And 8) > 0 Then MainView.SetRowCellValue(i, "HasDelete", val)
                    If (MainView.GetRowCellValue(i, "MaxPermission") And 16) > 0 Then MainView.SetRowCellValue(i, "HasImport", val)
                ElseIf nField = "HasAdd" And val Then
                    If (MainView.GetRowCellValue(i, "MaxPermission") And 2) > 0 Then MainView.SetRowCellValue(i, "HasOpen", val)
                    If (MainView.GetRowCellValue(i, "MaxPermission") And 2) > 0 Then MainView.SetRowCellValue(i, "HasAdd", val)
                    If (MainView.GetRowCellValue(i, "MaxPermission") And 4) > 0 And (MainView.GetRowCellValue(i, "MaxPermission") And 2) > 0 Then MainView.SetRowCellValue(i, "HasEdit", val)
                ElseIf nField = "HasAdd" Then
                    If (MainView.GetRowCellValue(i, "MaxPermission") And 2) > 0 Then MainView.SetRowCellValue(i, "HasAdd", val)
                ElseIf nField = "HasEdit" And val Then
                    If (MainView.GetRowCellValue(i, "MaxPermission") And 4) > 0 Then MainView.SetRowCellValue(i, "HasOpen", val)
                    If (MainView.GetRowCellValue(i, "MaxPermission") And 4) > 0 Then MainView.SetRowCellValue(i, "HasEdit", val)
                ElseIf nField = "HasEdit" Then
                    If (MainView.GetRowCellValue(i, "MaxPermission") And 4) > 0 Then MainView.SetRowCellValue(i, "HasEdit", val)
                    If (MainView.GetRowCellValue(i, "MaxPermission") And 2) > 0 Then MainView.SetRowCellValue(i, "HasAdd", val)
                ElseIf nField = "HasDelete" And val Then
                    If (MainView.GetRowCellValue(i, "MaxPermission") And 8) > 0 Then MainView.SetRowCellValue(i, "HasOpen", val)
                    If (MainView.GetRowCellValue(i, "MaxPermission") And 8) > 0 Then MainView.SetRowCellValue(i, "HasDelete", val)
                ElseIf nField = "HasDelete" Then
                    If (MainView.GetRowCellValue(i, "MaxPermission") And 8) > 0 Then MainView.SetRowCellValue(i, "HasDelete", val)
                ElseIf nField = "HasImport" And val Then
                    If (MainView.GetRowCellValue(i, "MaxPermission") And 16) > 0 Then MainView.SetRowCellValue(i, "HasOpen", val)
                    If (MainView.GetRowCellValue(i, "MaxPermission") And 16) > 0 Then MainView.SetRowCellValue(i, "HasImport", val)
                ElseIf nField = "HasImport" Then
                    If (MainView.GetRowCellValue(i, "MaxPermission") And 16) > 0 Then MainView.SetRowCellValue(i, "HasImport", val)
                    If (MainView.GetRowCellValue(i, "MaxPermission") And 2) > 0 Then MainView.SetRowCellValue(i, "HasAdd", val)
                End If
                MainView.SetRowCellValue(i, "HasFullPermission", MainView.GetRowCellValue(i, "MaxPermission") = (IIf(MainView.GetRowCellValue(i, "HasOpen"), 1, 0) + IIf(MainView.GetRowCellValue(i, "HasAdd"), 2, 0) + IIf(MainView.GetRowCellValue(i, "HasEdit"), 4, 0) + IIf(MainView.GetRowCellValue(i, "HasDelete"), 8, 0) + IIf(MainView.GetRowCellValue(i, "HasImport"), 16, 0)))
                MainView.SetRowCellValue(i, "Edited", 1)
            Next
        End If
        bDisableCelVal = False
    End Sub

    Private Sub UserView_CellValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles UserView.CellValueChanging
        AllowSaving(Name, (bPermission And 4) > 0)
        UserView.SetRowCellValue(UserView.FocusedRowHandle, "UserEdited", 1)
        bRecordUpdated = True
    End Sub

    Private Sub UserViewnRowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles UserView.RowCellStyle
        If UserView.GetRowCellValue(e.RowHandle, "UserEdited") Is System.DBNull.Value Then
            e.Appearance.BackColor = SEL_COLOR
        ElseIf UserView.GetRowCellValue(e.RowHandle, "UserEdited") = 1 And UserView.FocusedRowHandle = e.RowHandle Then
            e.Appearance.BackColor = EDITED_FOCUSED_COLOR
        ElseIf UserView.GetRowCellValue(e.RowHandle, "UserEdited") = 1 Then
            e.Appearance.BackColor = EDITED_COLOR
        ElseIf e.RowHandle = UserView.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        End If
    End Sub

    Private Sub MainViewnRowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
        If MainView.GetRowCellValue(e.RowHandle, "Edited") Is System.DBNull.Value Then
            e.Appearance.BackColor = SEL_COLOR
        ElseIf MainView.GetRowCellValue(e.RowHandle, "Edited") = 1 And MainView.FocusedRowHandle = e.RowHandle Then
            e.Appearance.BackColor = EDITED_FOCUSED_COLOR
        ElseIf MainView.GetRowCellValue(e.RowHandle, "Edited") = 1 Then
            e.Appearance.BackColor = EDITED_COLOR
        ElseIf e.RowHandle = MainView.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        End If
        If e.Column.Name = "HasAdd" AndAlso (MainView.GetRowCellValue(e.RowHandle, "MaxPermission") And 2) = 0 Then
            e.Appearance.BackColor = DISABLED_COLOR
        ElseIf e.Column.Name = "HasEdit" AndAlso (MainView.GetRowCellValue(e.RowHandle, "MaxPermission") And 4) = 0 Then
            e.Appearance.BackColor = DISABLED_COLOR
        ElseIf e.Column.Name = "HasDelete" AndAlso (MainView.GetRowCellValue(e.RowHandle, "MaxPermission") And 8) = 0 Then
            e.Appearance.BackColor = DISABLED_COLOR
        ElseIf e.Column.Name = "HasImport" AndAlso (MainView.GetRowCellValue(e.RowHandle, "MaxPermission") And 16) = 0 Then
            e.Appearance.BackColor = DISABLED_COLOR
        End If
        If e.RowHandle = 0 Then
            e.Appearance.BackColor = System.Drawing.Color.FromArgb(73, 73, 73)
            e.Appearance.ForeColor = Drawing.Color.White
        End If
    End Sub

    Public Overrides Sub RefreshData()
        RemoveEditListener(Me.txtName)
        header.Text = "EDIT GROUPS - " & blList.GetDesc.ToUpper
        Me.MainGrid.DataSource = DB.CreateTable("EXEC SECOBJECT_SEL @SecID=" & IIf(blList.GetID = "", "0", blList.GetID) & ", @SecType=1")
        Me.UserGrid.DataSource = DB.CreateTable("EXEC SECGROUP_SEL @GroupID=" & IIf(blList.GetID = "", "0", blList.GetID))
        If Not bLoaded Then
            AllowAddition(Name, (bPermission And 2) > 0)
            txtFilter.Properties.DataSource = DB.CreateTable("SELECT * FROM dbo.OBJECTCATEGORY")
            bLoaded = True
        End If
        If blList.GetID = "" And (bPermission And 2) > 0 Then
            AddData()
        Else
            Me.txtName.EditValue = blList.GetDesc
            AllowDeletion(Name, (bPermission And 8) > 0)
        End If
        MyBase.RefreshData()
        If (bPermission And 4) > 0 Then
            AddEditListener(Me.txtName)
        End If
        MainView.ClearColumnsFilter()
        MainView.RefreshData()
        txtFilter.EditValue = "ALL"
        txtFilter.BackColor = Drawing.Color.White
    End Sub

    Private Sub MainView_ShowingEditor(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MainView.ShowingEditor
        If (bPermission And 4) = 0 Then
            e.Cancel = True
        ElseIf MainView.FocusedColumn.FieldName = "HasAdd" AndAlso (MainView.GetRowCellValue(MainView.FocusedRowHandle, "MaxPermission") And 2) = 0 Then
            e.Cancel = True
        ElseIf MainView.FocusedColumn.FieldName = "HasEdit" AndAlso (MainView.GetRowCellValue(MainView.FocusedRowHandle, "MaxPermission") And 4) = 0 Then
            e.Cancel = True
        ElseIf MainView.FocusedColumn.FieldName = "HasDelete" AndAlso (MainView.GetRowCellValue(MainView.FocusedRowHandle, "MaxPermission") And 8) = 0 Then
            e.Cancel = True
        ElseIf MainView.FocusedColumn.FieldName = "HasImport" AndAlso (MainView.GetRowCellValue(MainView.FocusedRowHandle, "MaxPermission") And 16) = 0 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub txtFilter_CloseUp(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.CloseUpEventArgs) Handles txtFilter.CloseUp
        If e.Value <> txtFilter.EditValue Then
            If e.Value = "ALL" Then
                MainView.ClearColumnsFilter()
                MainView.RefreshData()
            Else
                Try
                    MainView.ActiveFilterString = "Category='ALL' OR Category='" & e.Value & "'"
                Catch ex As Exception
                End Try

            End If
        End If
    End Sub

    Private Sub UserView_ShowingEditor(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles UserView.ShowingEditor
        e.Cancel = (bPermission And 4) = 0
    End Sub

    Private Sub header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles header.MouseUp, MainView.MouseUp, UserView.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            OnRightClick(Name)
        End If
    End Sub
End Class