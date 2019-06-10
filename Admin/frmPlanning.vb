Public Class frmPlanning
    Public IS_SAVED As Boolean = False, strParts As String
    Dim strRequiredFields = "cboWork;cboType;txtNumber;cboRankCode"
    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        'If ValidateFields(New DevExpress.XtraEditors.TextEdit() {cboWork, cboType, txtNumber, cboRankCode}) Then
        IS_SAVED = True
        Me.Close()
        'End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub frmPlanning_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddFormEditListener(gDetails)
    End Sub

    Public Sub AddFormEditListener(ByVal cContainer As System.Windows.Forms.Control)
        Dim ctr As System.Windows.Forms.Control
        For Each ctr In cContainer.Controls
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


    Private Sub cboWork_ProcessNewValue(sender As Object, e As DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs) Handles cboWork.ProcessNewValue
        Dim row As DataRow, tbl As DataTable
        tbl = cboWork.Properties.DataSource
        If IfNull(e.DisplayValue, "") = "" Then Exit Sub
        row = tbl.NewRow
        row("WorkCode") = "<USER>"
        row("Maintenance") = e.DisplayValue
        tbl.Rows.Add(row)
        e.Handled = True
    End Sub

    Private Sub cboComponent_ProcessNewValue(sender As Object, e As DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs) Handles cboComponent.ProcessNewValue
        Dim row As DataRow, tbl As DataTable
        tbl = cboComponent.Properties.DataSource
        If IfNull(e.DisplayValue, "") = "" Then Exit Sub
        row = tbl.NewRow
        row("ComponentCode") = "<USER>"
        row("Component") = e.DisplayValue
        tbl.Rows.Add(row)
        e.Handled = True
    End Sub

End Class