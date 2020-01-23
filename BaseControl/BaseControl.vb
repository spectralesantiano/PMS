Public Class BaseControl

    Public DB As SQLDB ' A class used to communicate with the SQL Server
    Protected strID As String = "" 'Primary key of each record.
    Protected strDesc As String 'Description of the maincontent
    Public strCaption As String 'Caption of the maincontent
    Protected bLoaded As Boolean = False 'Utility variable will be set to true on the first call of refreshdata function.
    Public bPermission As Byte = 0 '1 View 2 Add 4 Edit/Save 8 Delete 'Max permission 15
    Public bRecordUpdated As Boolean 'Utility variable will be set to false on RefreshData and True Field_EditValueChanged which trigger in when one of the fields is updated.
    Protected bAddMode As Boolean = False 'Utility variable will be set to true when the AddData function is called.
    Protected strFindID As String 'Utility for datasheet if this had a value on RefreshData it will look for this ID.
    Protected strRequiredFields As String 'List of Required fields
    Public blList As BaseList

    Public Event RightClick(ByVal sender As String) 'Event that will fire  when the user right click the sub class data or a portion of the control.
    Public Event AllowSave(ByVal sender As String, ByVal value As Boolean) 'Event that will fire  when the user edit sub class data. This will enable the save button on main form.
    Public Event AllowAdd(ByVal sender As String, ByVal value As Boolean) 'Event that will fire when the user has an add permission. This will enable the add button on main form.
    Public Event AllowDelete(ByVal sender As String, ByVal value As Boolean) 'Event that will fire when the user has an delete permission. This will enable the delete button on main form.
    Public Event SaveVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) 'This will show/hide the save button on main form.
    Public Event AddVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) 'This will show/hide the add button on main form.
    Public Event DeleteVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) 'This will show/hide the delete button on main form.
    Public Event CustomSaveCaption(ByVal sender As String, ByVal value As String) 'This will set the caption of the save button on main form.
    Public Event CustomAddCaption(ByVal sender As String, ByVal value As String) 'This will set the caption of the add button on main form.
    Public Event CustomDeleteCaption(ByVal sender As String, ByVal value As String) 'This will set the caption of the delete button on main form.
    Public Event OnSwitchContent(ByVal sender As String, ByVal value As String, ByVal cmd() As String) 'Event that will let to sub class to switch to another class.
    Public Event OnCustomEvent(ByVal sender As String, ByVal param() As Object) 'Event that will fire  when the user edit sub class data. This will enable the save button on main form.

    'Custom layout saving.
    Public Overridable Sub SetLayout(strLayout As String)

    End Sub

    'Custom layout saving.
    Public Overridable Function GetLayout() As String
        Return ""
    End Function

    'Delete custom layout.
    Public Overridable Sub ResetLayout()

    End Sub

    'This function will be called from sub classes to trigger the event.
    'params
    'sender - Name of the sub class trigger the event
    'cmd - commands that maybe needed when the user right click the control.
    Protected Sub OnRightClick(ByVal sender As String)
        RaiseEvent RightClick(sender)
    End Sub
    'This function will be called from sub classes to trigger the event.
    'params
    'sender - Name of the sub class trigger the event
    'value - string that set the .caption properties of the main forms add button.
    Protected Sub SwitchContent(ByVal sender As String, ByVal value As String, ByVal cmd() As String)
        RaiseEvent OnSwitchContent(sender, value, cmd)
    End Sub

    'This function will be called from sub classes to trigger the event.
    'params
    'sender - Name of the sub class trigger the event
    'value - string that set the .caption properties of the main forms add button.
    Protected Sub SetAddCaption(ByVal sender As String, ByVal value As String)
        RaiseEvent CustomAddCaption(sender, value)
    End Sub

    'This function will be called from sub classes to trigger the event.
    'params
    'sender - Name of the sub class trigger the event
    'value - boolen that set the .caption properties of the main forms add button.
    Protected Sub SetSaveCaption(ByVal sender As String, ByVal value As String)
        RaiseEvent CustomSaveCaption(sender, value)
    End Sub

    'This function will be called from sub classes to trigger the event.
    'params
    'sender - Name of the sub class trigger the event
    'value - boolen that set the .caption properties of the main forms add button.
    Protected Sub SetDeleteCaption(ByVal sender As String, ByVal value As String)
        RaiseEvent CustomDeleteCaption(sender, value)
    End Sub

    'This function will be called from sub classes to trigger the event.
    'params
    'sender - Name of the sub class trigger the event
    'value - boolen that set the .enabled properties of the main forms add button.
    Protected Sub AllowAddition(ByVal sender As String, ByVal value As Boolean)
        RaiseEvent AllowAdd(sender, value)
    End Sub

    'This function will be called from sub classes to trigger the event.
    'params
    'sender - Name of the sub class trigger the event
    'value - boolen that set the .visible properties of the main forms add button.
    Protected Sub SetSaveVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility)
        RaiseEvent SaveVisibility(sender, value)
    End Sub

    'This function will be called from sub classes to trigger the event.
    'params
    'sender - Name of the sub class trigger the event
    'value - boolen that set the .visible properties of the main forms add button.
    Protected Sub SetDeleteVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility)
        RaiseEvent DeleteVisibility(sender, value)
    End Sub

    'This function will be called from sub classes to trigger the event.
    'params
    'sender - Name of the sub class trigger the event
    'value - boolen that set the .visible properties of the main forms add button.
    Protected Sub SetAddVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility)
        RaiseEvent AddVisibility(sender, value)
    End Sub

    'This function will be called from sub classes to trigger the event.
    'params
    'sender - Name of the sub class trigger the event
    'value - boolen that set the .enabled properties of the main forms add button.
    Protected Sub AllowSaving(ByVal sender As String, ByVal value As Boolean)
        RaiseEvent AllowSave(sender, value)
    End Sub

    'This function will be called from sub classes to trigger the event.
    'params
    'sender - Name of the sub class trigger the event
    'value - boolen that set the .enabled properties of the main forms add button.
    Protected Sub AllowDeletion(ByVal sender As String, ByVal value As Boolean)
        RaiseEvent AllowDelete(sender, value)
    End Sub

    'Set the filter on the datagrid
    Public Overridable Sub SetFilter(ByVal _criteria As String)

    End Sub

    'This function will be called when the user clicks the Save button on Main form. This is blank for the actual content of this function is defined on Sub classes
    Public Overridable Sub SaveData()

    End Sub
    'This function will be  called when the user clicks the Add button on Main form. This is blank for the actual content of this function is defined on Sub classes
    Public Overridable Sub AddData()

    End Sub

    'This function will be  called when the user clicks the Delete button on Main form. This is blank for the actual content of this function is defined on Sub classes
    Public Overridable Sub DeleteData()

    End Sub

    'Utility clear the content of all fields in a certain container.
    'param
    'cContainer - a control that holds the fields to be cleared.
    'bFormatOnly - clear only the format if set to false data will also cleared.
    Public Sub ClearFields(ByVal cContainer As System.Windows.Forms.Control, ByVal bFormatOnly As Boolean)
        Dim ctr As System.Windows.Forms.Control
        For Each ctr In cContainer.Controls
            If TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                If Not bFormatOnly Then CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue = System.DBNull.Value
                If InStr(1, strRequiredFields, ctr.Name) > 0 Then
                    ctr.BackColor = REQUIRED_COLOR
                Else
                    ctr.BackColor = Drawing.Color.White
                End If
                ctr.Tag = 0
            End If
            If TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Then
                If Not bFormatOnly Then CType(ctr, DevExpress.XtraEditors.CheckEdit).Checked = False
                ctr.Tag = 0
            End If
        Next
        bRecordUpdated = False
        AllowSaving(Name, False)
    End Sub

    'Utility add event on fields that triggers when the field got the focus, lost the focus and updated.
    Protected Sub AddEditListener(ByVal cContainer As System.Windows.Forms.Control)
        Dim ctr As System.Windows.Forms.Control
        For Each ctr In cContainer.Controls
            If TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                AddHandler CType(ctr, DevExpress.XtraEditors.TextEdit).EditValueChanged, AddressOf Field_EditValueChanged
                AddHandler CType(ctr, DevExpress.XtraEditors.TextEdit).GotFocus, AddressOf Field_GotFocus
                AddHandler CType(ctr, DevExpress.XtraEditors.TextEdit).LostFocus, AddressOf Field_LostFocus
                If InStr(1, strRequiredFields, ctr.Name) > 0 Then
                    ctr.BackColor = REQUIRED_COLOR
                Else
                    ctr.BackColor = Drawing.Color.White
                End If
                ctr.Tag = 0
                ctr.Enabled = True
            ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Or TypeOf (ctr) Is DevExpress.XtraEditors.RadioGroup Then
                AddHandler CType(ctr, DevExpress.XtraEditors.BaseEdit).EditValueChanged, AddressOf Field_EditValueChanged
                ctr.Tag = 0
                ctr.Enabled = True
            End If
        Next
    End Sub

    'Utility add event on fields that triggers when the field got the focus, lost the focus and updated.
    Protected Sub AddEditListener(ByVal ctr As DevExpress.XtraEditors.CheckEdit)
        AddHandler ctr.EditValueChanged, AddressOf Field_EditValueChanged
        ctr.Tag = 0
        ctr.Enabled = True
    End Sub

    'Utility add event on fields that triggers when the field got the focus, lost the focus and updated.
    Protected Sub AddEditListener(ByVal ctr As DevExpress.XtraEditors.TextEdit)
        AddHandler ctr.EditValueChanged, AddressOf Field_EditValueChanged
        AddHandler ctr.GotFocus, AddressOf Field_GotFocus
        AddHandler ctr.LostFocus, AddressOf Field_LostFocus
        If InStr(1, strRequiredFields, ctr.Name) > 0 Then
            ctr.BackColor = REQUIRED_COLOR
        Else
            ctr.BackColor = Drawing.Color.White
        End If
        ctr.Tag = 0
        ctr.Enabled = True
    End Sub

    'Utility add event on fields that triggers when the field got the focus, lost the focus and updated.
    Protected Sub RemoveEditListener(ByVal cContainer As System.Windows.Forms.Control, Optional ByVal Disable As Boolean = True)
        Try
            Dim ctr As System.Windows.Forms.Control
            For Each ctr In cContainer.Controls
                If TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                    RemoveHandler CType(ctr, DevExpress.XtraEditors.TextEdit).EditValueChanged, AddressOf Field_EditValueChanged
                    RemoveHandler CType(ctr, DevExpress.XtraEditors.TextEdit).GotFocus, AddressOf Field_GotFocus
                    RemoveHandler CType(ctr, DevExpress.XtraEditors.TextEdit).LostFocus, AddressOf Field_LostFocus
                    ctr.BackColor = DISABLED_COLOR
                    ctr.Enabled = False
                    If Disable Then
                        ctr.BackColor = DISABLED_COLOR
                        ctr.Enabled = False
                    End If
                End If
                If TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                    RemoveHandler CType(ctr, DevExpress.XtraEditors.CheckEdit).EditValueChanged, AddressOf Field_EditValueChanged
                    If Disable Then ctr.Enabled = False
                End If
                ctr.ForeColor = Drawing.Color.Black
            Next
        Catch ex As Exception
        End Try
    End Sub

    'Utility removed the event on a certain control the one you don't want to to program to edit e.t.c all readonly fields.
    Protected Sub RemoveEditListener(ByVal cCtr() As DevExpress.XtraEditors.BaseControl, Optional ByVal Disable As Boolean = True)
        Dim ctr As DevExpress.XtraEditors.BaseControl
        For Each ctr In cCtr
            If TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then
                RemoveHandler CType(ctr, DevExpress.XtraEditors.TextEdit).EditValueChanged, AddressOf Field_EditValueChanged
                RemoveHandler ctr.GotFocus, AddressOf Field_GotFocus
                RemoveHandler ctr.LostFocus, AddressOf Field_LostFocus
                If Disable Then
                    ctr.BackColor = DISABLED_COLOR
                    ctr.Enabled = False
                    ctr.ForeColor = Drawing.Color.Black
                End If
            ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Then
                RemoveHandler CType(ctr, DevExpress.XtraEditors.CheckEdit).EditValueChanged, AddressOf Field_EditValueChanged
                If Disable Then ctr.Enabled = False
            End If
        Next
    End Sub

    Protected Sub RemoveEditListener(ByVal ctr As DevExpress.XtraEditors.TextEdit, Optional ByVal Disable As Boolean = True)
        RemoveHandler ctr.EditValueChanged, AddressOf Field_EditValueChanged
        RemoveHandler ctr.GotFocus, AddressOf Field_GotFocus
        RemoveHandler ctr.LostFocus, AddressOf Field_LostFocus
        If Disable Then
            ctr.BackColor = DISABLED_COLOR
            ctr.Enabled = False
            ctr.ForeColor = Drawing.Color.Black
        End If
    End Sub

    Protected Sub RemoveEditListener(ByVal ctr As DevExpress.XtraEditors.CheckEdit, Optional ByVal Disable As Boolean = True)
        RemoveHandler ctr.EditValueChanged, AddressOf Field_EditValueChanged
        If Disable Then ctr.Enabled = False
    End Sub

    'Refresh the data source of the sub classes.
    'id - contains the primary key for the data source.
    'desc - description of the sub class
    Public Overridable Sub RefreshData()
        'set defaults
        strID = blList.GetID
        strDesc = IIf(strID = "", "New Record", blList.GetDesc)
        strFindID = ""
        bAddMode = (strID = "")
        bRecordUpdated = False
        AllowSaving(Name, False)
        AllowDeletion(Name, (strID <> "" And (bPermission And 8) > 0))
        AllowAddition(Name, (bPermission And 2) > 0)
        SetAddCaption(Name, "Add")
        SetSaveCaption(Name, "Save")
        SetDeleteCaption(Name, "Delete")
        'Show editing buttons if the user has a permission.
        SetAddVisibility(Name, IIf((bPermission And 2) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never))
        SetSaveVisibility(Name, IIf((bPermission And 4) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never))
        SetDeleteVisibility(Name, IIf((bPermission And 8) > 0, DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never))
    End Sub

    'Returns the description of the class
    Public Overridable Function GetDesc() As String
        Return ""
    End Function

    'That that will be attached to fields and fires when that field is edited.
    Protected Sub Field_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not TypeOf (sender) Is DevExpress.XtraGrid.GridControl Then
            If TypeOf (sender) Is DevExpress.XtraEditors.TextEdit Then
                CType(sender, DevExpress.XtraEditors.TextEdit).BackColor = EDITED_FOCUSED_COLOR
            End If
            CType(sender, System.Windows.Forms.Control).Tag = 1
            AllowSaving(Name, (bPermission And 4) > 0) 'Has Edit permission
            bRecordUpdated = True
        End If
    End Sub

    'That that will be attached to fields and fires when that field got the focus.
    Public Sub Field_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
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
    Public Sub Field_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
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

    'Check if the sub classes was updated and ask prompt to save the changes.
    Public Overridable Sub CheckIFDataUpdated()
        If bRecordUpdated And (bPermission And 4) > 0 Then
            If MsgBox("Would you like to save the changes you made on " & GetDesc() & "?", MsgBoxStyle.YesNo, strCaption) = MsgBoxResult.Yes Then
                SaveData()
            End If
        End If
    End Sub

    'Execute custom function of the subclass that is not available on this class.
    Public Overridable Sub ExecCustomFunction(ByVal param() As Object)
        'Sample Implementation
        'Select Case param(0)
        '    Case "ProcedureNameOnlyNoParameter"
        '        Call ProcedureNameOnlyNoParameter()
        '    Case "ProcedureNameWithParameter"
        '        Call ProcedureNameWithParameter(param(1), param(2), param(etc))
        'End Select
    End Sub
    'Raise custom event.
    Public Overridable Sub RaiseCustomEvent(ByVal sender As String, ByVal param() As Object)
        RaiseEvent OnCustomEvent(sender, param)
    End Sub

End Class
