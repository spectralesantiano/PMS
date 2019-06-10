Public Class MDOCVIEWER


    'Overriden From Base Control
    Public Overrides Function GetDesc() As String
        Return strDesc
    End Function

    'Overriden From Base Control
    Public Overrides Sub RefreshData()
        MyBase.RefreshData()
        If strID <> "" Then
            imgLogo.BackgroundImage = StringToImage(DB.DLookUp("ImageDoc", "tblAdmMaintenance", "", "MaintenanceCode='" & strID & "'"))
            Me.header.Text = strDesc
        End If
    End Sub

    Private Sub header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles header.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            OnRightClick(Name)
        End If
    End Sub
End Class
