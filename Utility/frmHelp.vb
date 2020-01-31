Public Class frmHelp

    Public Sub LoadPDF(strFile As String, nPageNum As Integer)
        PdfViewer.LoadDocument(strFile)
        PdfViewer.CurrentPageNumber = nPageNum
    End Sub
End Class