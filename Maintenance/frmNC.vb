Public Class frmNC
    Public IS_SAVED As Boolean = False, bLoaded As Boolean, nMaintenanceWorkID As Integer, strID As String, nNCID As String
    Dim strRequiredFields = "cboPlanningPartID;txtWorkDate"
    Public delsqls As New ArrayList

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        If ValidateFields(New DevExpress.XtraEditors.TextEdit() {txtDescription, txtImmediateAction, txtCauses}) Then
            IS_SAVED = True
            Me.Close()
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub frmNC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cmdOk.Text = IIf(nMaintenanceWorkID = 0, "Done", "Save")
        Me.cmdOk.Enabled = Me.txtStatus.EditValue = "Open"
        AddFormEditListener(gDetails)
    End Sub

    Private Sub MainView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles MainView.InitNewRow
        Dim View As DevExpress.XtraGrid.Views.Base.ColumnView = sender
        View.SetRowCellValue(e.RowHandle, View.Columns("Edited"), True)
    End Sub

    Private Sub MainView_RowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MainView.RowCellStyle
        If IfNull(MainView.GetRowCellValue(e.RowHandle, "Edited"), False) And MainView.FocusedRowHandle = e.RowHandle Then
                e.Appearance.BackColor = EDITED_FOCUSED_COLOR
        ElseIf MainView.GetRowCellValue(e.RowHandle, "Edited") Then
            e.Appearance.BackColor = EDITED_COLOR
        ElseIf e.RowHandle = MainView.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        End If
    End Sub

    Private Sub MainView_cellvaluechanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles MainView.CellValueChanged
        If e.Column.Name <> "Edited" Then
            MainView.SetRowCellValue(e.RowHandle, "Edited", True)
        End If
    End Sub
    Public Sub AddFormEditListener(ByVal cContainer As System.Windows.Forms.Control)
        Dim ctr As System.Windows.Forms.Control
        For Each ctr In cContainer.Controls
            If Not (ctr.Name = "txtWorkDate" Or ctr.Name = "txtWorkCounter" Or ctr.Name = "txtStatus") Then
                If TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                    AddHandler CType(ctr, DevExpress.XtraEditors.TextEdit).EditValueChanged, AddressOf FormField_EditValueChanged
                    AddHandler CType(ctr, DevExpress.XtraEditors.TextEdit).GotFocus, AddressOf FormField_GotFocus
                    AddHandler CType(ctr, DevExpress.XtraEditors.TextEdit).LostFocus, AddressOf FormField_LostFocus
                    If InStr(1, strRequiredFields, ctr.Name) > 0 Then
                        ctr.BackColor = REQUIRED_COLOR
                    Else
                        ctr.BackColor = Drawing.Color.White
                    End If
                    ctr.Tag = 0
                    ctr.Enabled = True
                ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Or TypeOf (ctr) Is DevExpress.XtraEditors.RadioGroup Then
                    AddHandler CType(ctr, DevExpress.XtraEditors.BaseEdit).EditValueChanged, AddressOf FormField_EditValueChanged
                    ctr.Tag = 0
                    ctr.Enabled = True
                End If
            End If
            
        Next
    End Sub

    'That that will be attached to fields and fires when that field is edited.
    Sub FormField_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not TypeOf (sender) Is DevExpress.XtraGrid.GridControl Then
            If TypeOf (sender) Is DevExpress.XtraEditors.TextEdit Then
                CType(sender, DevExpress.XtraEditors.TextEdit).BackColor = EDITED_FOCUSED_COLOR
            End If
            CType(sender, System.Windows.Forms.Control).Tag = 1
        End If
    End Sub

    'That that will be attached to fields and fires when that field got the focus.
    Sub FormField_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If TypeOf (sender) Is DevExpress.XtraEditors.TextEdit Then
            If CType(sender, DevExpress.XtraEditors.TextEdit).Tag = 1 Then
                CType(sender, DevExpress.XtraEditors.TextEdit).BackColor = EDITED_FOCUSED_COLOR
            Else
                If InStr(1, strRequiredFields, CType(sender, DevExpress.XtraEditors.TextEdit).Name) > 0 Then
                    CType(sender, DevExpress.XtraEditors.TextEdit).BackColor = REQUIRED_SELECTED_COLOR
                Else
                    CType(sender, DevExpress.XtraEditors.TextEdit).BackColor = SEL_COLOR
                End If
            End If
        End If
    End Sub

    'That that will be attached to fields and fires when that field lost the focus.
    Sub FormField_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If TypeOf (sender) Is DevExpress.XtraEditors.TextEdit Then
            If CType(sender, DevExpress.XtraEditors.TextEdit).Tag = 1 Then
                CType(sender, DevExpress.XtraEditors.TextEdit).BackColor = EDITED_COLOR
            Else
                If InStr(1, strRequiredFields, CType(sender, DevExpress.XtraEditors.TextEdit).Name) > 0 Then
                    CType(sender, DevExpress.XtraEditors.TextEdit).BackColor = REQUIRED_COLOR
                Else
                    CType(sender, DevExpress.XtraEditors.TextEdit).BackColor = Drawing.Color.White
                End If
            End If
        End If
    End Sub

    Private Sub DeleteEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles DeleteEdit.ButtonClick
        If (MainView.FocusedRowHandle >= 0) Then
            If IfNull(MainView.GetFocusedRowCellValue("NCCorrectiveMeasureID"), 0) > 0 Then
                delsqls.Add("DELETE FROM [dbo].[tblNCCorrectiveMeasure] WHERE NCCorrectiveMeasureID=" & MainView.GetFocusedRowCellValue("NCCorrectiveMeasureID"))
            End If
        End If
        MainView.DeleteRow(MainView.FocusedRowHandle)
    End Sub
End Class