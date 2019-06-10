Public Class BaseList

    Public DB As SQLDB ' A class used to communicate with the SQL Server
    Protected bAddMode As Boolean = False 'Utility variable will be set to true when the AddData function is called.
    Public bDisableSelectionEvent As Boolean = False
    Protected bDraggable As Boolean = False
    Public LayoutFileName As String
    'Event that will fire  when the user edit sub class data. This will enable the save button on main form.
    Public Event OnCustomEvent(ByVal sender As String, ByVal param() As Object)
    'Event that will fire when the sub classes Gridview cell was right clicked.
    Public Event OnCellRightClick(ByVal sender As String)
    'Event that will fire when the sub classes Gridview selection was changed.
    Public Event OnSelectionChange(ByVal sender As String)
    'Event that will fire when the sub classes Gridview accepted object via drog and drop.
    Public Event AcceptedDragObject(ByVal sender As String)
    'Filter of the list.
    Protected strFilter As String = ""

    'Raise custom event.
    Public Overridable Sub RaiseCustomEvent(ByVal sender As String, ByVal param() As Object)
        RaiseEvent OnCustomEvent(sender, param)
    End Sub

    'Called from the sub classes to trigger the CellRightClick Event
    Protected Sub CellRightClick(ByVal sender As String)
        RaiseEvent OnCellRightClick(sender)
    End Sub

    'Called from the sub classes to trigger the CellRightClick Event
    Protected Sub AcceptDragObject(ByVal sender As String)
        RaiseEvent AcceptedDragObject(sender)
    End Sub

    'Called from the sub classes to trigger the SelectionChange Event
    Protected Sub SelectionChange(ByVal sender As String)
        If Not bDisableSelectionEvent Then RaiseEvent OnSelectionChange(sender)
    End Sub

    'Refresh the datasource of the sub classes
    Public Overridable Function GetFocusedRowData(ByVal _columnname As String) As Object
        Return System.DBNull.Value
    End Function

    'Refresh the datasource of the sub classes
    Public Overridable Sub RefreshData()

    End Sub

    'Hides the selection to the datagrid of sub classes
    Public Overridable Sub HideSelection()

    End Sub


    'Set the filter on the datagrid
    Public Overridable Sub SetFilter(ByVal _criteria As String)

    End Sub

    'Remove the filter on the datagrid
    Public Overridable Sub ClearFilter()

    End Sub

    'Set selection to a certain record
    Public Overridable Sub SetSelection(ByVal id As String)

    End Sub

    'Set selection to a certain record
    Public Overridable Sub SetSelection(ByVal id As String, ByVal column As String)

    End Sub

    'Returns the primary key of the data source
    Public Overridable Function GetID() As String
        Return ""
    End Function

    'Returns the description of the class
    Public Overridable Function GetDesc() As String
        Return ""
    End Function

    Public Overridable Sub SaveLayout(ByVal fileName As String)

    End Sub
    

    'Returns the primary key of the data source
    Public Overridable Sub Draggable(ByVal value As Boolean)

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
End Class
