Public Class frmHelp

    Public Sub LoadPDF(strFile As String, nPageNum As Integer)
        PdfViewer.LoadDocument(strFile)
        PdfViewer.CurrentPageNumber = nPageNum
    End Sub

    Public Sub LoadPDF(strFile As System.IO.Stream)
        PdfViewer.LoadDocument(strFile)
    End Sub
End Class