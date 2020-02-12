Public Class basReports
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Shared Sub BindData(ByVal sender As Object, ByVal nProperty As String, ByVal DbSource As String, ByVal nFieldName As String, Optional ByVal nFormat As String = "")
        '####################################################################################################################################################################################################################################
        '### Description: Binds data to a report control based on the passed parameters
        Try
            Dim nType As Type = sender.GetType
            Select Case nType.Name
                Case "XRLabel"
                    TryCast(sender, DevExpress.XtraReports.UI.XRLabel).DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding(nProperty, DbSource, nFieldName, nFormat))
                Case "XRTableCell"
                    TryCast(sender, DevExpress.XtraReports.UI.XRTableCell).DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding(nProperty, DbSource, nFieldName, nFormat))
                Case "XRPictureBox"
                    TryCast(sender, DevExpress.XtraReports.UI.XRPictureBox).DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding(nProperty, DbSource, nFieldName, nFormat))
                Case "XRCheckBox"
                    TryCast(sender, DevExpress.XtraReports.UI.XRCheckBox).DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding(nProperty, DbSource, nFieldName, nFormat))
            End Select
        Catch ex As Exception
            Throw (New Exception(ex.Message))
        End Try
    End Sub
End Class
