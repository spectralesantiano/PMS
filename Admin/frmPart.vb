Public Class frmPart
    Public IS_SAVED As Boolean = False, IS_NEW As Boolean

    Private Sub cboPartCode_ProcessNewValue(sender As Object, e As DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs) Handles cboPartCode.ProcessNewValue
        If IfNull(e.DisplayValue, "") = "" Then
            e.Handled = True
            Exit Sub
        End If
        Dim row As DataRow, tbl As DataTable, strPartCode As String = Guid.NewGuid.ToString
        tbl = cboPartCode.Properties.DataSource
        row = tbl.NewRow
        row("PartCode") = strPartCode
        row("Part") = e.DisplayValue
        tbl.Rows.Add(row)
        e.Handled = True
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        If ValidateFields(New DevExpress.XtraEditors.BaseEdit() {Me.txtPartNumber, Me.cboPartCode}) Then
            IS_SAVED = True
            Me.Close()
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Sub RemoveEditListener(ByVal Ctr As DevExpress.XtraEditors.BaseEdit)
        If TypeOf (Ctr) Is DevExpress.XtraEditors.TextEdit Then
            RemoveHandler CType(Ctr, DevExpress.XtraEditors.TextEdit).EditValueChanged, AddressOf FormField_EditValueChanged
        ElseIf TypeOf (Ctr) Is DevExpress.XtraEditors.LookUpEdit Then
            RemoveHandler CType(Ctr, DevExpress.XtraEditors.LookUpEdit).EditValueChanged, AddressOf FormField_EditValueChanged
        End If
        RemoveHandler Ctr.GotFocus, AddressOf FormField_GotFocus
        RemoveHandler Ctr.LostFocus, AddressOf FormField_LostFocus
        Ctr.BackColor = DISABLED_COLOR
        Ctr.Enabled = False
        Ctr.ForeColor = Drawing.Color.Black
    End Sub

    Public Sub AddEditListener(ctr As System.Windows.Forms.Control)
        If TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
            AddHandler CType(ctr, DevExpress.XtraEditors.TextEdit).EditValueChanged, AddressOf FormField_EditValueChanged
            AddHandler CType(ctr, DevExpress.XtraEditors.TextEdit).GotFocus, AddressOf FormField_GotFocus
            AddHandler CType(ctr, DevExpress.XtraEditors.TextEdit).LostFocus, AddressOf FormField_LostFocus
            ctr.BackColor = Drawing.Color.White
            ctr.Tag = 0
            ctr.Enabled = True
        ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Or TypeOf (ctr) Is DevExpress.XtraEditors.RadioGroup Then
            AddHandler CType(ctr, DevExpress.XtraEditors.BaseEdit).EditValueChanged, AddressOf FormField_EditValueChanged
            ctr.Tag = 0
            ctr.Enabled = True
        End If
    End Sub

    Public Sub AddFormEditListener(ByVal cContainer As System.Windows.Forms.Control)
        Dim ctr As System.Windows.Forms.Control
        For Each ctr In cContainer.Controls
            If TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                AddHandler CType(ctr, DevExpress.XtraEditors.TextEdit).EditValueChanged, AddressOf FormField_EditValueChanged
                AddHandler CType(ctr, DevExpress.XtraEditors.TextEdit).GotFocus, AddressOf FormField_GotFocus
                AddHandler CType(ctr, DevExpress.XtraEditors.TextEdit).LostFocus, AddressOf FormField_LostFocus
                ctr.BackColor = Drawing.Color.White
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
                CType(sender, DevExpress.XtraEditors.TextEdit).BackColor = SEL_COLOR
            End If
        End If
    End Sub

    'That that will be attached to fields and fires when that field lost the focus.
    Sub FormField_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If TypeOf (sender) Is DevExpress.XtraEditors.TextEdit Then
            If CType(sender, DevExpress.XtraEditors.TextEdit).Tag = 1 Then
                CType(sender, DevExpress.XtraEditors.TextEdit).BackColor = EDITED_COLOR
            Else
                CType(sender, DevExpress.XtraEditors.TextEdit).BackColor = Drawing.Color.White
            End If
        End If
    End Sub

    Private Sub frmPart_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        AddFormEditListener(Me)
    End Sub
End Class