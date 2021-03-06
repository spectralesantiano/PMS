Public Class SECUSERS
    Dim _disablecelval As Boolean = False
    Dim strFilter As String
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String '= clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName) 'neil

    Private Sub ResetPassword()
        If MsgBox("Continuing will reset " & strDesc & "'s password to " & DEFAULT_PASSWORD & ", would you like to continue?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_REAL, "", 10, System.Environment.MachineName, "Reset Password", strCaption, , 1) 'neil
            DB.RunSql("UPDATE tblSec_Users SET [Password]='" & sysMpsUserPassword("encrypt", DEFAULT_PASSWORD) & "',LastUpdatedBy='" & LastUpdatedBy & "' WHERE [User ID]=" & strID)
        End If
    End Sub

    Public Overrides Sub ExecCustomFunction(ByVal param() As Object)
        Select Case param(0)
            Case "ResetPassword"
                ResetPassword()
        End Select
    End Sub
    'Overriden From Base Control
    Public Overrides Sub DeleteData()
        If MsgBox("Are you sure want to delete " & strDesc & " as User?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim sqls As New ArrayList

            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_REAL, "", 10, System.Environment.MachineName, "User", strCaption, , 1) 'neil
            clsAudit.saveAuditPreDelDetails("tblSec_Objects", strID, LastUpdatedBy)

            sqls.Add("DELETE FROM dbo.tblSec_Objects WHERE SecID=" & strID & " AND SecType=0")

            clsAudit.saveAuditPreDelDetails("tblSec_Users", strID, LastUpdatedBy)
            sqls.Add("DELETE FROM dbo.tblSec_Users WHERE [User ID]=" & strID)
            DB.RunTransaction(sqls)
        End If
        blList.RefreshData()
        RefreshData()
    End Sub

    'Overriden From Base Control
    Public Overrides Sub SaveData()
        Try

        If ValidateFields(New DevExpress.XtraEditors.TextEdit() {Me.txtUserName, Me.GroupList, Me.txtFamilyName, Me.txtFirstName, Me.lkuRank, Me.dteDateSON}) Then
            Dim groupid As String, strFleetFilter As String = ""
            If Me.GroupList.EditValue Is Nothing Or Me.GroupList.EditValue Is System.DBNull.Value Then
                groupid = "NULL"
            Else
                groupid = Me.GroupList.EditValue.ToString
            End If

            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_REAL, "", 10, System.Environment.MachineName, "User", strCaption, , 1) 'neil

                If bAddMode Then
                    DB.RunSql("INSERT INTO dbo.tblSec_Users([User Name], [Password], [Group ID], LastUpdatedBy, LName, FName, MName, RankCode, DateSOn, Active) " & _
                              "VALUES('" & txtUserName.EditValue & "', '" & sysMpsUserPassword("encrypt", DEFAULT_PASSWORD) & "', " & groupid & ", '" & LastUpdatedBy & "'" & _
                              ",'" & txtFamilyName.EditValue & "','" & txtFirstName.EditValue & "','" & txtMiddleName.EditValue & "','" & lkuRank.EditValue & "'," & ChangeToSQLDate(dteDateSON.EditValue) & "," & chkActive.EditValue & ")")
                    strID = DB.DLookUp("[User ID]", "dbo.tblSec_Users", "", "[User Name]='" & txtUserName.EditValue & "'")
                    bRecordUpdated = False
                    blList.RefreshData()
                    blList.SetSelection(strID)
                    RefreshData()
                Else
                    Dim sql As String = ""
                    If txtUserName.Tag = 1 Then
                        sql = "[User Name]='" & txtUserName.EditValue & "', "
                    End If
                    If GroupList.Tag = 1 Then
                        sql = sql & "[Group ID]=" & groupid & ", "
                    End If
                    If txtFamilyName.Tag = 1 Then
                        sql = sql & "[LName]='" & txtFamilyName.EditValue & "', "
                    End If
                    If txtFirstName.Tag = 1 Then
                        sql = sql & "[FName]='" & txtFirstName.EditValue & "', "
                    End If
                    If txtMiddleName.Tag = 1 Then
                        sql = sql & "[MName]='" & txtMiddleName.EditValue & "', "
                    End If
                    If lkuRank.Tag = 1 Then
                        sql = sql & "[RankCode]='" & lkuRank.EditValue & "', "
                    End If
                    If dteDateSON.Tag = 1 Then
                        sql = sql & "[DateSOn]=" & ChangeToSQLDate(dteDateSON.EditValue) & ", "
                    End If
                    If chkActive.Tag = 1 Then
                        sql = sql & "[Active]=" & chkActive.EditValue & ", "
                    End If

                    If sql <> "" Then
                        DB.RunSql("UPDATE dbo.tblSec_Users SET " & sql & " LastUpdatedBy = '" & LastUpdatedBy & "' WHERE [User ID]=" & strID)
                    End If
                    bRecordUpdated = False
                    blList.RefreshData()
                    RefreshData()
                End If
            bAddMode = False
            End If

        Catch ex As Exception
            MsgBox("Error encountered. " & ex.Message & ":" & ex.Source, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    'Overriden From Base Control
    Public Overrides Sub AddData()
        If Not bAddMode Then
            'ClearFields(Me.header, False)
            ClearFields(LayoutControlGroup2, False)
            AllowSaving(Name, False) 'Disable save button 
            AllowDeletion(Name, False) 'Disable Delete button
            bAddMode = True
            blList.HideSelection()
            strID = ""
            strDesc = "New Record"
            'Me.txtUserName.Focus()
            Me.txtFamilyName.Focus()
            Me.txtUserName.BackColor = REQUIRED_COLOR
            Me.GroupList.BackColor = REQUIRED_COLOR
            Me.txtFamilyName.BackColor = REQUIRED_COLOR
            Me.txtFirstName.BackColor = REQUIRED_COLOR
            chkActive.Checked = True
            bRecordUpdated = False
        End If
    End Sub

    'Overriden From Base Control
    Public Overrides Function GetDesc() As String
        Return "Users - " & strDesc
    End Function

    Public Overrides Sub RefreshData()
        strRequiredFields = "txtUserName;GroupList;txtFammilyName;txtFirstName;lkuRank;dteDateSON"
        RemoveEditListener(Me.txtUserName)
        RemoveEditListener(Me.GroupList)
        header.Text = "EDIT USERS - " & blList.GetDesc.ToUpper
        If Not bLoaded Then
            AllowAddition(Name, (bPermission And 2) > 0)
            GroupList.Properties.DataSource = DB.CreateTable("SELECT * FROM dbo.GROUPLIST ORDER BY GroupName")
            lkuRank.Properties.DataSource = AdmRank
            bLoaded = True
        End If
        If blList.GetID = "" Then
            AddData()
        Else
            Me.txtUserName.EditValue = blList.GetFocusedRowData("UserName")
            Me.GroupList.EditValue = blList.GetFocusedRowData("GroupID")
            Me.txtFamilyName.EditValue = blList.GetFocusedRowData("LName")
            Me.txtFirstName.EditValue = blList.GetFocusedRowData("FName")
            Me.txtMiddleName.EditValue = blList.GetFocusedRowData("MName")
            Me.lkuRank.EditValue = blList.GetFocusedRowData("RankCode")
            Me.dteDateSON.EditValue = blList.GetFocusedRowData("DateSOn")
            Me.chkActive.Checked = IfNull(blList.GetFocusedRowData("Active"), 0)
            AllowDeletion(Name, (bPermission And 8) > 0)
        End If
        MyBase.RefreshData()
        If (bPermission And 4) > 0 Then
            AddEditListener(Me.txtUserName)
            AddEditListener(Me.GroupList)
            AddEditListener(Me.txtFamilyName)
            AddEditListener(Me.txtFirstName)
            AddEditListener(Me.txtMiddleName)
            AddEditListener(Me.lkuRank)
            AddEditListener(Me.dteDateSON)
            AddEditListener(Me.chkActive)

        End If
        'GroupList.Enabled = (USER_ID = 1)
        clsAudit.propSQLConnStr = DB.GetConnectionString '& "Password=" & SQL_PASSWORD  'neil

    End Sub

    Private Sub header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles header.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            OnRightClick(Name)
        End If
    End Sub

    
End Class
