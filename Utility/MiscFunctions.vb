Public Module MiscFunctions
    Public Const BACKUP_CODE As String = "SYS_BACKUP_PMS"
    Public Const BACKUP_NAME As String = "PMSBACKUP"
    Public Const BACKUP_DIR As String = "C:\Spectral\PMS Backups"


    'RETURNS : hh:mm:ss from input string <nSeconds>
    Public Function TimeElapsed(ByVal nSecond As Double) As String
        Dim tSpan As TimeSpan = TimeSpan.FromSeconds(nSecond)
        Dim cRetVal As String = ""

        If tSpan.Hours > 0 Then
            cRetVal = cRetVal & IIf(cRetVal.Length > 0, " ", "") & tSpan.Hours & " hour" & IIf(tSpan.Hours > 1, "s", "")
        End If
        If tSpan.Minutes > 0 Then
            cRetVal = cRetVal & IIf(cRetVal.Length > 0, " ", "") & tSpan.Minutes & " minute" & IIf(tSpan.Minutes > 1, "s", "")
        End If
        If tSpan.Seconds > 0 Then
            cRetVal = cRetVal & IIf(cRetVal.Length > 0, " ", "") & tSpan.Seconds & " second" & IIf(tSpan.Seconds > 1, "s", "")
        End If
        If cRetVal = "" Then
            cRetVal = "0 second"
        End If

        Return cRetVal
    End Function

#Region "DISK IO Functions"
    'RETURNS : a nice foldername <cDir> with "\" appended at the end
    Public Function CleanPath(ByVal cDir As String, Optional ByVal cSeparator As String = "\") As String
        Return cDir & IIf(Right(cDir, 1) = cSeparator, "", cSeparator)
    End Function
#End Region

End Module
