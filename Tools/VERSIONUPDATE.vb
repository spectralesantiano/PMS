Public Class VERSIONUPDATE
    Dim strUpdatesDir As String = ""

    Public Function Browse()
        Dim odMain As New System.Windows.Forms.FolderBrowserDialog
        If odMain.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            If System.IO.Directory.Exists(odMain.SelectedPath) Then
                strUpdatesDir = odMain.SelectedPath
                txtUpdatesFolder.EditValue = strUpdatesDir
                DB.SaveConfig("UpdatesFolder", txtUpdatesFolder.EditValue, APP_SHORT_NAME)
            End If
        Else
            Return False
        End If
        Return False
    End Function

    'Overriden From Base Control
    Public Overrides Sub RefreshData()
        strUpdatesDir = DB.Settings("UpdatesFolder", APP_SHORT_NAME)
        txtUpdatesFolder.EditValue = strUpdatesDir
        txtUpdatesFolder.Properties.ReadOnly = IIf((bPermission And 4) > 0, False, True)
        AllowFilePathButton(txtUpdatesFolder, IIf((bPermission And 4) > 0, True, False))

        If Not System.IO.Directory.Exists(strUpdatesDir) Then
            MsgBox("Can't find the updates folder. Please specify.", MsgBoxStyle.Critical, GetAppName)
        End If
        SetSaveCaption(Name, "Save")
        SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetSaveVisibility(Name, IIf((bPermission And 4) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never))
        SetDeleteVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        AllowSaving(Name, IIf((bPermission And 4) > 0, True, False))

        MainGrid.DataSource = DB.CreateTable("SELECT * FROM dbo.PMSVERSION ORDER BY VersionNo Desc")
        RaiseCustomEvent(Name, New Object() {"ShowUpdateButton"})
    End Sub

    Public Overrides Sub SaveData()
        If ValidateFields(New DevExpress.XtraEditors.ButtonEdit() {txtUpdatesFolder}) Then
            Try
                DB.SaveConfig("UpdatesFolder", txtUpdatesFolder.EditValue, APP_SHORT_NAME)
                MsgBox("Successfully saved version setting!", MsgBoxStyle.Information, GetAppName)
                RefreshData()
            Catch ex As Exception
                MsgBox("An error occured saving version setting!", MsgBoxStyle.Critical, GetAppName)
            End Try

        End If
    End Sub

    Private Sub AllowFilePathButton(ByVal btn As DevExpress.XtraEditors.ButtonEdit, Optional ByVal value As Boolean = True)
        For i As Integer = 0 To btn.Properties.Buttons.Count - 1
            btn.Properties.Buttons(i).Enabled = value
        Next
    End Sub


    Private Sub MainView_RowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
        If e.RowHandle = MainView.FocusedRowHandle Then e.Appearance.BackColor = SEL_COLOR
    End Sub

    Private Sub header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles header.MouseUp, MainView.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            OnRightClick(Name)
        End If
    End Sub

    Private Sub txtUpdatesFolder_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtUpdatesFolder.ButtonClick
        Dim btn As DevExpress.XtraEditors.ButtonEdit = TryCast(sender, DevExpress.XtraEditors.ButtonEdit)
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            strUpdatesDir = ""
            txtUpdatesFolder.EditValue = ""
            DB.SaveConfig("UpdatesFolder", txtUpdatesFolder.EditValue, APP_SHORT_NAME)
        ElseIf e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Search Then
            Browse()
        End If
    End Sub

   
End Class
