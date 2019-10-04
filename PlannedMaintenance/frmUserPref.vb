Public Class frmUserPref
    Public IS_SAVED As Boolean = False
    Dim bLoaded As Boolean = False, bPrevFontInc As Integer = FONT_INCREASE

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        CURRENT_RANK = cboRankCode.EditValue
        CURRENT_DUEDAYS = txtDueDate.EditValue
        CURRENT_DUEHOURS = txtDueHours.EditValue
        FONT_INCREASE = tbcFontIncrease.EditValue
        CURRENT_FLATVIEW_CHECKED = chkFlatView.Checked
        CURRENT_SHOW_WARNING = chkShowWarning.Checked
        IS_SAVED = True
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        FONT_INCREASE = bPrevFontInc
        Me.Close()
    End Sub

    Private Sub tbcFontIncrease_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles tbcFontIncrease.EditValueChanged
        If bLoaded Then
            FONT_INCREASE = tbcFontIncrease.EditValue
            DevExpress.Utils.AppearanceObject.DefaultFont = GetDefaultFont()
        End If
    End Sub
    
    Private Sub frmUserPref_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cboRankCode.Properties.DataSource = AdmRank
        cboRankCode.EditValue = CURRENT_RANK
        txtDueDate.EditValue = CURRENT_DUEDAYS
        txtDueHours.EditValue = CURRENT_DUEHOURS
        tbcFontIncrease.EditValue = FONT_INCREASE
        chkFlatView.Checked = CURRENT_FLATVIEW_CHECKED
        chkTreeView.Checked = Not CURRENT_FLATVIEW_CHECKED
        chkShowWarning.Checked = CURRENT_SHOW_WARNING
        bLoaded = True
    End Sub

    Private Sub chkTreeView_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkTreeView.CheckedChanged
        If bLoaded Then
            chkFlatView.Checked = Not chkTreeView.Checked
        End If
        'CURRENT_FLATVIEW_CHECKED = chkFlatView.Checked
    End Sub

    Private Sub chkFlatView_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkFlatView.CheckedChanged
        If bLoaded Then
            chkTreeView.Checked = Not chkFlatView.Checked
        End If
        'CURRENT_FLATVIEW_CHECKED = chkFlatView.Checked
    End Sub

    Private Sub cboRankCode_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboRankCode.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Close Then
            cboRankCode.EditValue = ""
        End If
    End Sub
   
End Class