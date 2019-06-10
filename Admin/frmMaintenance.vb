﻿Public Class frmMaintenance
    Public IS_SAVED As Boolean = False, strParts As String, DB As SQLDB, bEscaped As Boolean = False, bImageUpdated As Boolean = False

    Private Sub cboWorkCode_Closed(sender As Object, e As DevExpress.XtraEditors.Controls.ClosedEventArgs) Handles cboWorkCode.Closed
        If e.CloseMode = DevExpress.XtraEditors.PopupCloseMode.Cancel Then
            bEscaped = True
            cboWorkCode.DoValidate()
        End If
    End Sub

    Private Sub cboWorkCode_ProcessNewValue(sender As Object, e As DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs) Handles cboWorkCode.ProcessNewValue
        If IfNull(e.DisplayValue, "") = "" Or bEscaped Then
            e.Handled = True
            Exit Sub
        End If
        Dim row As DataRow, tbl As DataTable, strWorkCode As String = GenerateID(DB, "WorkCode", "tblAdmWork")
        tbl = cboWorkCode.Properties.DataSource
        row = tbl.NewRow
        DB.RunSql("INSERT INTO dbo.tblAdmWork(WorkCode, Name, LastUpdatedBy) VALUES('" & strWorkCode & "', '" & e.DisplayValue & "','" & GetUserName() & "')")
        row("WorkCode") = strWorkCode
        row("Maintenance") = e.DisplayValue
        tbl.Rows.Add(row)
        bEscaped = False
        e.Handled = True
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        IS_SAVED = True
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

    Private Sub chkPreventive_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkPreventive.CheckedChanged
        EnableInterval()
    End Sub

    Sub EnableInterval()
        If Not chkPreventive.Checked Then
            txtNumber.EditValue = System.DBNull.Value
            RemoveEditListener(txtNumber)
            cboIntCode.EditValue = ""
            RemoveEditListener(cboIntCode)
        Else
            AddEditListener(txtNumber)
            AddEditListener(cboIntCode)
        End If
    End Sub

    Private Sub frmMaintenance_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        AddFormEditListener(Me)
        EnableInterval()
    End Sub

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdClear_Click(sender As System.Object, e As System.EventArgs) Handles cmdClear.Click
        imgLogo.BackgroundImage = Nothing
        bImageUpdated = True
    End Sub

    Private Sub cmdBrowse_Click(sender As System.Object, e As System.EventArgs) Handles cmdBrowse.Click
        Dim odMain As New System.Windows.Forms.OpenFileDialog
        odMain.Filter = "Image files (*.jpg, *.jpeg) | *.jpg; *.jpeg"
        If odMain.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            imgLogo.BackgroundImage = New System.Drawing.Bitmap(odMain.FileName)
            bImageUpdated = True
        End If
    End Sub
End Class