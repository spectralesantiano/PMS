Public Class MyLocalization
    Inherits DevExpress.XtraPrinting.Localization.PreviewLocalizer
    Public Overrides Function GetLocalizedString(ByVal id As PreviewStringId) As String
        Select Case (id)
            Case PreviewStringId.Msg_EmptyDocument
                Return "Processing Report"
        End Select
        Return MyBase.GetLocalizedString(id)
    End Function
End Class
