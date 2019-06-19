Public Class ExcelFile
    Dim oXL As Excel.Application
    Dim oWB As Excel.Workbook
    Dim oSheet As Excel.Worksheet
    Dim oRng As Excel.Range
    Dim _file As String
    Public _initialized As Boolean = False
    Public Sub New(ByVal FileName As String, strCaption As String)
        Try
            _file = FileName
            oXL = CreateObject("Excel.Application")
            oXL.Visible = False
            oXL.Caption = strCaption
            oWB = oXL.Workbooks.Add
            oSheet = oWB.ActiveSheet
            _initialized = True
        Catch ex As Exception
        End Try
    End Sub

    Public Sub Dispose()
        Dim proc As System.Diagnostics.Process
        Dim intPID As Integer
        Dim intResult As Integer
        Dim iHandle As IntPtr
        Dim strVer As String
        Try
            strVer = oXL.Version
            iHandle = IntPtr.Zero
            If CInt(strVer) > 9 Then
                iHandle = New IntPtr(CType(oXL.Parent.Hwnd, Integer))
            Else
                iHandle = FindWindow(Nothing, oXL.Caption)
            End If
            oSheet = Nothing
            oWB.Close()
            oWB = Nothing
            oXL.Quit()
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oXL)
            oXL = Nothing
            intResult = GetWindowThreadProcessId(iHandle, intPID)
            proc = System.Diagnostics.Process.GetProcessById(intPID)
            proc.Kill()
        Catch ex As Exception
        End Try
    End Sub


    Public Sub SetValue(ByVal nRow As Integer, ByVal nCol As Integer, ByVal nVal As Object)
        oSheet.Cells(nRow, nCol).Value = nVal
    End Sub

    Public Sub SetFontBold(ByVal nRow As Integer, ByVal nCol As Integer, ByVal nVal As Boolean)
        oSheet.Cells(nRow, nCol).Font.Bold = nVal
    End Sub

    Public Sub ChangeColor(ByVal nRow As Integer, ByVal nCol As Integer, ByVal nColorIndex As Integer)
        oSheet.Cells(nRow, nCol).Interior.ColorIndex = nColorIndex
    End Sub

    Public Sub ChangeWidth(ByVal nCol As Integer, ByVal nWidth As Integer)
        oSheet.Columns(nCol).ColumnWidth = nWidth
    End Sub

    Public Sub SetTopBorder(ByVal nRow As Integer, ByVal nCol As Integer, ByVal nColorIndex As Integer)
        oSheet.Cells(nRow, nCol).borders(Excel.XlBordersIndex.xlEdgeTop).colorindex = nColorIndex
    End Sub

    Public Sub SetBottomBorder(ByVal nRow As Integer, ByVal nCol As Integer, ByVal nColorIndex As Integer)
        oSheet.Cells(nRow, nCol).borders(Excel.XlBordersIndex.xlEdgeBottom).colorindex = nColorIndex
    End Sub

    Public Sub SetLeftBorder(ByVal nRow As Integer, ByVal nCol As Integer, ByVal nColorIndex As Integer)
        oSheet.Cells(nRow, nCol).borders(Excel.XlBordersIndex.xlEdgeLeft).colorindex = nColorIndex
    End Sub

    Public Sub SetRightBorder(ByVal nRow As Integer, ByVal nCol As Integer, ByVal nColorIndex As Integer)
        oSheet.Cells(nRow, nCol).borders(Excel.XlBordersIndex.xlEdgeRight).colorindex = nColorIndex
    End Sub

    Public Sub SetBorder(ByVal nRow As Integer, ByVal nCol As Integer, ByVal nColorIndex As Integer)
        SetTopBorder(nRow, nCol, nColorIndex)
        SetBottomBorder(nRow, nCol, nColorIndex)
        SetLeftBorder(nRow, nCol, nColorIndex)
        SetRightBorder(nRow, nCol, nColorIndex)
    End Sub

    Public Sub WrapText(ByVal nRow As Integer, ByVal nCol As Integer)
        oSheet.Cells(nRow, nCol).WrapText = True
    End Sub

    Public Sub AlignMiddleLeft(ByVal nRow As Integer, ByVal nCol As Integer)
        oSheet.Cells(nRow, nCol).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        oSheet.Cells(nRow, nCol).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
    End Sub

    Public Sub AlignMiddleCenter(ByVal nRow As Integer, ByVal nCol As Integer)
        oSheet.Cells(nRow, nCol).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        oSheet.Cells(nRow, nCol).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
    End Sub

    Public Sub AlignMiddleRight(ByVal nRow As Integer, ByVal nCol As Integer)
        oSheet.Cells(nRow, nCol).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        oSheet.Cells(nRow, nCol).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
    End Sub

    Public Sub Merge(ByVal srow As Integer, ByVal scol As Integer, ByVal erow As Integer, ByVal ecol As Integer)
        oSheet.Range(oSheet.Cells(srow, scol), oSheet.Cells(erow, ecol)).Merge()
    End Sub

    Public Sub Save()
        oWB.SaveAs(_file)
    End Sub

    Public Function GetValue(ByVal nRow As Integer, ByVal nCol As Integer) As String
        Return oSheet.Cells(nRow, nCol).Value
    End Function

End Class
