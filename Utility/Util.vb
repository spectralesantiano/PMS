Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Module Util
    Public Declare Function GetWindowThreadProcessId Lib "user32.dll" (ByVal hWnd As IntPtr, ByRef lpdwProcessId As Integer) As Integer
    Public Declare Function FindWindow Lib "user32.dll" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
    Public USE_SPECTRAL_CON As Boolean = True, USE_TRUSTED_CON As Boolean, SQL_SERVER As String, SQL_USER_NAME As String, SQL_PASSWORD As String
    Public VERSION_NUMBER As String, VERSION_DATE As Date, HDD_ID As String
    Public SEL_COLOR As System.Drawing.Color = System.Drawing.Color.FromArgb(200, 247, 200)
    Public EDITED_COLOR As System.Drawing.Color = System.Drawing.Color.FromArgb(87, 191, 200)
    Public EDITED_FOCUSED_COLOR As System.Drawing.Color = System.Drawing.Color.FromArgb(144, 219, 200)
    Public DISABLED_COLOR As System.Drawing.Color = System.Drawing.Color.FromArgb(230, 230, 230) 'System.Drawing.Color.FromArgb(235, 236, 239)
    Public DISABLED_SELECTED_COLOR As System.Drawing.Color = System.Drawing.Color.FromArgb(215, 238, 215)
    Public DISABLED_EDITED_COLOR As System.Drawing.Color = System.Drawing.Color.FromArgb(187, 224, 215)
    Public REQUIRED_COLOR As System.Drawing.Color = System.Drawing.Color.FromArgb(253, 249, 234)
    Public REQUIRED_SELECTED_COLOR As System.Drawing.Color = System.Drawing.Color.FromArgb(226, 248, 217)
    Public USER_NAME As String = "ADMIN", USER_ID As Integer = 0, GROUP_ID As Integer = 0, DEFAULT_PASSWORD As String = "12345", USER_PASSWORD As String
    Public IMO_NUMBER As String = "", VESSEL As String, FLAG_DESC As String, TYPE_DESC As String
    Public APP_PATH As String, DATE_LAST_EXPORT As String = "2000-01-01", SHORE_ID As String, EXPORT_DIR
    Private ReadOnly EXPIMPCHARACTERS As String = "d3]c)Q-I|@%^&*_+=efghij0k:lno(p8qrs`tuv}w{[;'x2yzAB>C9.,<?DbEF!G6$H5J KL#MN/O7PaR""STUVWXYZ~1\m4"
    Public GRID_ROW_SEP As Byte = 0, LOGO As Bitmap, FONT_INCREASE As Double = 2
    Public CURRENT_DEPARTMENT As String, CURRENT_RANK As String, CURRENT_MAINUNIT As String, CURRENT_CATEGORY As String, CURRENT_UNIT As String = "", CURRENT_WORK As Integer, CURRENT_DUEDAYS As String = "30", CURRENT_DUEHOURS As Integer = "100", CURRENT_PERIOD As Integer, CURRENT_WOMAINTENANCE As Boolean = False, CURRENT_CONDITION_CHECKED As Boolean = False, CURRENT_CRITICAL_CHECKED As Boolean = False, CURRENT_FLATVIEW_CHECKED As Boolean = False, CURRENT_SHOW_WARNING As Boolean = False
    Public AdmRank As DataTable, AdmDept As DataTable
    Public Const APP_SHORT_NAME = "PMS", DAY_MAX_HOURS As Integer = 25

#Region "Utility functions"

    Function GetDefaultFont() As Font
        Return New System.Drawing.Font("Tahoma", 8.25 + FONT_INCREASE, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    End Function

    ''' <summary>
    ''' Get the application directory.
    ''' </summary>
    ''' <returns>Application Directory</returns>
    ''' <remarks>
    ''' Value of APP_PATH which is set via SetAppPath(System.Windows.Forms.Application.StartupPath) called on the Application Events of the Main Form.
    ''' </remarks>
    Public Function GetAppPath() As String
        Return APP_PATH
    End Function

    ''' <summary>
    ''' Set the application directory.
    ''' </summary>
    ''' <param name="nPath">System.Windows.Forms.Application.StartupPath</param>
    ''' <remarks>called on the Application Events of the Main Form.</remarks>
    Public Sub SetAppPath(ByVal nPath As String)
        APP_PATH = nPath
    End Sub

    ''' <summary>
    ''' Convert integer mCode/Period with YYYYmm format to Date. If cDay is 0, it will return days of month.
    ''' </summary>
    ''' <param name="nPeriod">Serve as Year and Month for the date</param>
    ''' <param name="nDay">Day part of the date</param>
    ''' <returns>Date based on MCode/Period and cDay</returns>
    ''' <remarks>If nDay is 0 then it will return Days of Month.</remarks>
    Public Function NumCodeToDate(ByVal nPeriod As Integer, ByVal nDay As Integer) As Date
        Return DateSerial(nPeriod \ 100, nPeriod Mod 100, IIf(nDay > 0, nDay, GetDaysOfMonth(DateSerial(nPeriod \ 100, nPeriod Mod 100, 1))))
    End Function

    ''' <summary>
    ''' Gets the number of days in a month.
    ''' </summary>
    ''' <param name="dDate">Applicable date</param>
    ''' <returns>Number of days of given date.</returns>
    ''' <remarks></remarks>
    Public Function GetDaysOfMonth(ByVal dDate As Date) As Integer
        dDate = DateAdd(DateInterval.Month, 1, dDate)
        Return DateAdd(DateInterval.Day, -1, DateSerial(dDate.Year, dDate.Month, 1)).Day
    End Function

    ''' <summary>
    ''' Gets the number of days in a month.
    ''' </summary>
    ''' <param name="nPeriod">Applicable Period</param>
    ''' <returns>Number of days of given Period.</returns>
    ''' <remarks></remarks>
    Public Function GetDaysOfMonth(ByVal nPeriod As Integer) As Integer
        Dim dDate = DateAdd(DateInterval.Month, 1, DateSerial(nPeriod \ 100, nPeriod Mod 100, 1))
        Return DateAdd(DateInterval.Day, -1, dDate).Day
    End Function

    ''' <summary>
    ''' Add default value to a nullable object.
    ''' </summary>
    ''' <param name="obj">Object to be replaced if it's null</param>
    ''' <param name="objValueIfNull">Replacement value</param>
    ''' <returns>The obj if not null, otherwise objValueIfNull</returns>
    ''' <remarks></remarks>
    Public Function IfNull(ByVal obj As Object, ByVal objValueIfNull As Object) As Object
        If obj Is System.DBNull.Value Or obj Is Nothing Then
            Return objValueIfNull
        Else
            Return obj
        End If
    End Function

    ''' <summary>
    ''' Get the age based on Birth date.
    ''' </summary>
    ''' <param name="bday">Date of Birth</param>
    ''' <returns>The age based on birthday.</returns>
    ''' <remarks></remarks>
    Public Function GetAge(ByVal bday As Date) As Integer
        Return Now.Year - bday.Year - IIf(Now.Month < bday.Month OrElse (Now.Month = bday.Month And Now.Day < bday.Day), 1, 0)
    End Function

    ''' <summary>
    ''' Check if the string is Unicode.
    ''' </summary>
    ''' <param name="str">String to be checked.</param>
    ''' <returns>True if the string is Unicode, otherwise false.</returns>
    ''' <remarks></remarks>
    Public Function ISUnicode(ByVal str As String) As Boolean
        Dim c As Integer
        For c = 0 To str.Length - 1
            If AscW(str.Chars(c)) > 255 Then
                Return True
            End If
        Next
        Return False
    End Function

    ''' <summary>
    ''' Converts a memory stream to string.
    ''' </summary>
    ''' <param name="str">Stream</param>
    ''' <returns>Converted string from stream</returns>
    ''' <remarks></remarks>
    Public Function StreamToString(str As System.IO.MemoryStream) As String
        Dim reader As New System.IO.StreamReader(str)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Return reader.ReadToEnd()
    End Function

    ''' <summary>
    ''' Removes invalid characters on specified path.
    ''' </summary>
    ''' <param name="path"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RemoveInvalidFileNameChars(path As String)
        Dim c As Char, invalidChar As String = System.IO.Path.GetInvalidFileNameChars()
        For Each c In invalidChar
            path = path.Replace(c.ToString(), "")
        Next
        Return path
    End Function

    ''' <summary>
    ''' Logs error on the App_Dir\Errors directory. 
    ''' </summary>
    ''' <param name="ErrMsg">Error message</param>
    ''' <remarks>Writes error message on Errors directory.</remarks>
    Public Sub LogErrors(ErrMsg As String)
        Dim strFileName As String, stTrace As New System.Diagnostics.StackTrace()
        Dim sfFrame As System.Diagnostics.StackFrame, sfFrames() As System.Diagnostics.StackFrame = stTrace.GetFrames, strMethods As String = ""
        For Each sfFrame In sfFrames
            Dim strMethodName As String = sfFrame.GetMethod.Name
            If strMethodName = "Invoke" Then Exit For
            'Exclude current sub
            If strMethodName <> "LogErrors" Then strMethods = strMethods & "<" & strMethodName & ">"
        Next
        If Not System.IO.Directory.Exists(GetAppPath() & "\Errors") Then
            MkDir(GetAppPath() & "\Errors")
        End If
        strFileName = GetAppPath() & "\Errors" & "\Error_" & Now.ToString("yyyyMMdd") & ".txt"
        Using sw As New System.IO.StreamWriter(strFileName, True)
            sw.WriteLine(Format(Now, "yyyy-MM-dd hh:mm:ss") & " " & strMethods & " : " & ErrMsg)
        End Using
    End Sub

    ''' <summary>
    ''' Converts date into a YYYYMM number code.
    ''' </summary>
    ''' <param name="dDay">Date to be converted</param>
    ''' <returns>Integer YYYYMM</returns>
    ''' <remarks></remarks>
    Public Function DateToNumCode(ByVal dDay As Date) As Int32
        Return CType(dDay.Year.ToString("0000") & dDay.Month.ToString("00"), Int32)
    End Function

    ''' <summary>
    ''' Converts image into Bytes.
    ''' </summary>
    ''' <param name="img">Image to be converted</param>
    ''' <returns>Binary version of the image</returns>
    ''' <remarks></remarks>
    Public Function ImageToByte(ByVal img As System.Drawing.Image) As Byte()
        Dim ms = New IO.MemoryStream()
        img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg) ' Use appropriate format here
        Return ms.ToArray()
    End Function

#End Region

#Region "SQL Encryption"

    ''' <summary>
    ''' Replaces the default database in a connection string.
    ''' </summary>
    ''' <param name="strConnection">Connection String</param>
    ''' <param name="strNewDB">Name of the default database.</param>
    ''' <returns>Connection string with a new default database</returns>
    ''' <remarks></remarks>
    Public Function Replace_DB_Connection(strConnection As String, strNewDB As String) As String
        Dim strTmp As String, strRetVal As String = ""
        For Each strTmp In strConnection.Split(";"c)
            If strTmp.Split("="c).GetValue(0).ToString.ToLower = "database" Then
                If strNewDB <> "" Then strRetVal = strRetVal & "Database=" & strNewDB & ";"
            Else
                If strTmp <> "" Then strRetVal = strRetVal & strTmp & ";"
            End If
        Next
        Return strRetVal
    End Function

    ''' <summary>
    ''' Get the database on a specified connection string.
    ''' </summary>
    ''' <param name="strConnection">Connect string</param>
    ''' <returns>Database name from the connection string</returns>
    ''' <remarks></remarks>
    Private Function GetConnectionDbName(strConnection As String) As String
        Dim strTmp As String
        For Each strTmp In strConnection.Split(";"c)
            If strTmp.Split("="c).GetValue(0).ToString.ToLower = "database" Then
                Return strTmp.Split("="c).GetValue(1).ToString.ToLower
            End If
        Next
        Return ""
    End Function

    ''' <summary>
    ''' Create Master Key for STI_SYS database which will be used to encrypt the details of the main(wrh_db, sas_tbl e.t.c.) database key
    ''' </summary>
    ''' <param name="strConnection">Connection string to the server.</param>
    ''' <param name="strClientPassword">Password supplied by client.</param>
    ''' <remarks></remarks>
    Function Create_STI_SYS_Key(strConnection As String, strClientPassword As String) As String
        Dim strRandomPass As String = System.Guid.NewGuid.ToString
        Dim con As SqlClient.SqlConnection, cmd As SqlClient.SqlCommand, strSQL As String
        con = New SqlClient.SqlConnection(Replace_DB_Connection(strConnection, "sti_sys"))
        Try
            strSQL = "CREATE MASTER KEY ENCRYPTION BY PASSWORD = '" & strRandomPass & "'" & Environment.NewLine & _
                     "CREATE CERTIFICATE STICertificate WITH SUBJECT= 'STI Certificate'" & Environment.NewLine & _
                     "CREATE SYMMETRIC KEY STIKEy WITH ALGORITHM =AES_256 ENCRYPTION BY CERTIFICATE STICertificate" & Environment.NewLine & _
                     "OPEN SYMMETRIC KEY STIKEy DECRYPTION BY CERTIFICATE STICertificate" & Environment.NewLine & _
                     "DELETE FROM [sti_sys].[dbo].[sys_config] WHERE CONVERT(VARCHAR(max), DECRYPTBYKEY(Code)) IN('VAL','KEY')" & Environment.NewLine & _
                     "INSERT INTO [dbo].[sys_config] VALUES (ENCRYPTBYKEY(KEY_GUID('STIKEy'),'VAL'),ENCRYPTBYKEY(KEY_GUID('STIKEy'),'" & sysMpsUserPassword("ENCRYPT", strClientPassword) & "'))" & Environment.NewLine & _
                     "INSERT INTO [dbo].[sys_config] VALUES (ENCRYPTBYKEY(KEY_GUID('STIKEy'),'KEY'),ENCRYPTBYKEY(KEY_GUID('STIKEy'),'" & sysMpsUserPassword("ENCRYPT", strRandomPass) & "'))" & Environment.NewLine & _
                     "CLOSE symmetric key STIKEy"
            cmd = New SqlClient.SqlCommand(strSQL, con)
            con.Open()
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            con.Close()
            Return strRandomPass
        Catch ex As Exception
            LogErrors(ex.Message)
            If con.State <> ConnectionState.Closed Then
                con.Close()
            End If
            Return ""
        End Try
    End Function

#End Region

#Region "MPS Encryption functions"
    Function usrRailFence(ByVal cMode As String, ByVal nInterval As Integer, ByVal cDocument As String) As String
        Dim nCtr As Integer, cTopSum As String = "", cBottomSum As String = ""
        Dim cTempSum As String = "", nCutPos As Integer

        Select Case UCase(cMode)
            Case "ENCRYPT"
                'do railfence encryption
                nCtr = 1
                Do
                    If (nCtr Mod 2) = 1 Then
                        'odd positions on top
                        cTopSum = cTopSum & Mid$(cDocument, ((nCtr - 1) * nInterval) + 1, nInterval)
                    Else
                        cBottomSum = cBottomSum & Mid$(cDocument, ((nCtr - 1) * nInterval) + 1, nInterval)
                    End If

                    If (nCtr * nInterval) > Len(cDocument) Then
                        Exit Do
                    End If

                    nCtr = nCtr + 1

                Loop

                Return cTopSum & cBottomSum

            Case "DECRYPT"

                'split top & bottom sums
                Do While Len(cDocument) > 0
                    cTopSum = cTopSum & Left$(cDocument, nInterval)
                    cDocument = Mid(cDocument, nInterval + 1)
                    If Len(cDocument) > 0 Then
                        cBottomSum = Right$(cDocument, CType(IIf(Len(cDocument) >= nInterval, nInterval, Len(cDocument)), Integer)) & cBottomSum
                        cDocument = Mid$(cDocument, 1, CType(Len(cDocument) - CType(IIf(Len(cDocument) >= nInterval, nInterval, Len(cDocument)), Integer), Integer))
                    End If
                Loop

                nCutPos = Len(cTopSum)

                'do railfence decryption
                For nCtr = 1 To nCutPos Step nInterval
                    cTempSum = cTempSum & Mid$(cTopSum, nCtr, nInterval) & CType(IIf((Len(cDocument) Mod (nInterval + 1)) = 0 Or nCtr < nCutPos, Mid$(cBottomSum, nCtr, nInterval), ""), String)
                Next

                Return cTempSum
            Case Else
                Return ""
        End Select

    End Function

    Function usrCryptography(ByVal cMode As String, ByVal cDocument As String) As String
        On Error Resume Next
        Dim nCtr As Integer, cCheckSum As String, cOrigString As String
        Dim nCutPos As Integer, cTopSum As String, cBottomSum As String, cTempSum As String

        Select Case UCase(cMode)
            Case "ENCRYPT"
                cTopSum = ""
                cBottomSum = ""
                cCheckSum = ""

                'get ascii value
                For nCtr = 1 To Len(cDocument)
                    cCheckSum = cCheckSum & Format$(Asc(Mid$(cDocument, nCtr, 1)), "000")
                Next

                'do railfence encryption
                Return usrRailFence("ENCRYPT", 1, cCheckSum)

            Case "DECRYPT"
                cOrigString = ""

                cTempSum = usrRailFence("DECRYPT", 1, cDocument)
                'convert to ascii
                For nCtr = 1 To Len(cTempSum) Step 3
                    cOrigString = cOrigString & Chr(CType(Mid$(cTempSum, nCtr, 3), Integer))
                Next

                Return cOrigString
            Case Else
                Return ""
        End Select

    End Function

    Public Function sysMpsUserPassword(ByVal cMode As String, ByVal cPassword As String) As String
        Dim cRetVal As String, x() As String
        Select Case UCase(cMode)
            Case "ENCRYPT"
                Randomize()
                cPassword = Format(Rnd() * 999, "000") & "|" & cPassword & "|" & Format(Rnd() * 999, "000")
                cRetVal = usrRailFence("encrypt", 1, cPassword)
                Return usrCryptography("encrypt", cRetVal)
            Case "DECRYPT"
                cRetVal = usrCryptography("decrypt", cPassword)
                x = Split(usrRailFence("decrypt", 1, cRetVal), "|")
                Try
                    If x.Length > 1 Then
                        Return x(1)
                    Else
                        Return ""
                    End If
                Catch ex As Exception
                    Return ""
                End Try
            Case Else
                Return ""
        End Select

    End Function
#End Region

#Region "Chilkat Functions"

    'Send email using the Email Account saved in tblSTIService_internet_settings
    Public Function SendEmail(INET_Host As String, INET_Port As Integer, INET_User As String, INET_Pwd As String, INET_UseSSL As Boolean, INET_TLS As Boolean, strEmailFrom As String, strEmailTo As String, ByVal subject As String, ByVal body As String, ByVal attachment As String) As Boolean
        Try
            Dim smtp As New Chilkat.MailMan, email As New Chilkat.Email
            If smtp.UnlockComponent("SPCTASMAILQ_8962DBBgnC9s") Then
                smtp.SmtpHost = INET_Host
                smtp.SmtpPort = INET_Port
                smtp.SmtpUsername = INET_User
                smtp.SmtpPassword = INET_Pwd
                smtp.ConnectTimeout = 60
                smtp.SmtpSsl = INET_UseSSL
                smtp.StartTLS = INET_TLS
                email.AddTo("SM Office Email Address", strEmailTo)
                email.From = strEmailFrom
                email.Subject = subject
                email.Body = body
                If attachment <> "" Then email.AddFileAttachment(attachment)
                If smtp.SendEmail(email) Then
                    smtp.CloseSmtpConnection()
                    Return True
                Else
                    LogErrors("Send Email Error: " & smtp.LastErrorText)
                    smtp.CloseSmtpConnection()
                    Return False
                End If
            Else
                LogErrors("Send Email Error: " & smtp.LastErrorText)
                Return False
            End If
        Catch ex As Exception
            LogErrors("Send Email Error: " & ex.Message)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' FUNCTION : zip files given by cFileSpec (a semi-colon delimited list of masks) ex: cFileSpec = "*.csv;*log.txt"
    ''' </summary>
    ''' <param name="cZipFile"></param>
    ''' <param name="cFileSpec"></param>
    ''' <param name="cErr"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ZipFiles(ByVal cZipFile As String, ByVal cFileSpec As String, Optional ByRef cErr As String = "") As Boolean
        Dim bSuccess As Boolean = True
        Dim zip As New Chilkat.Zip()
        Dim nCtr As Integer

        '  Any string unlocks the component for the 1st 30-days.
        If bSuccess Then
            bSuccess = zip.UnlockComponent("SPCTASZIP_4gpKXqstjEuf")
            If Not bSuccess Then
                cErr = zip.LastErrorText
            End If
        End If

        If bSuccess Then
            bSuccess = zip.NewZip(cZipFile)
            If (bSuccess <> True) Then
                cErr = zip.LastErrorText
            End If
        End If

        '  Append a directory tree.  The call to AppendFiles does
        '  not read the file contents or append them to the zip
        '  object in memory.  It simply appends references
        '  to the files so that when WriteZip or WriteZipAndClose
        '  is called, the referenced files are streamed and compressed
        '  into the .zip output file.

        If bSuccess Then
            Dim recurse As Boolean
            recurse = False
            For nCtr = 1 To CountItemDelimited(cFileSpec, ";")
                bSuccess = bSuccess And zip.AppendFiles(GetItemDelimited(cFileSpec, nCtr, ";"), recurse)
                If (bSuccess <> True) Then
                    cErr = cErr & IIf(cErr.Length > 0, vbCrLf, "") & zip.LastErrorText
                End If
            Next
        End If

        If bSuccess Then
            bSuccess = zip.WriteZipAndClose()
            If (bSuccess <> True) Then
                cErr = zip.LastErrorText
            End If
        End If

        Return bSuccess
    End Function

    ''' <summary>
    ''' Unzip files in [cZipFile] and extract to folder [cExtractTo]
    ''' </summary>
    ''' <param name="cZipFile"></param>
    ''' <param name="cExtractTo"></param>
    ''' <param name="cErr"></param>
    ''' <param name="nFileCount"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ZipExtract(ByVal cZipFile As String, ByVal cExtractTo As String, Optional ByRef cErr As String = "", Optional ByRef nFileCount As Integer = 0) As Boolean
        Dim bSuccess As Boolean = True
        Dim zip As New Chilkat.Zip()

        '  Any string unlocks the component for the 1st 30-days.
        If bSuccess Then
            bSuccess = zip.UnlockComponent("SPCTASZIP_4gpKXqstjEuf")
            If (bSuccess <> True) Then
                cErr = zip.LastErrorText
            End If
        End If

        If bSuccess Then
            bSuccess = zip.OpenZip(cZipFile)
            If (bSuccess <> True) Then
                cErr = zip.LastErrorText
            End If
        End If

        If bSuccess Then
            nFileCount = zip.Unzip(cExtractTo)
            If nFileCount = -1 Then
                cErr = zip.LastErrorText
            End If
        End If

        Return bSuccess

    End Function

    Public Function ZipFile(ByVal cSourceFiles() As String, ByVal cDestFile As String) As Boolean
        Try
            Dim zip As New Chilkat.Zip(), cFile As String
            zip.UnlockComponent("SPCTASZIP_4gpKXqstjEuf")
            zip.NewZip(cDestFile)
            For Each cFile In cSourceFiles
                zip.AppendOneFileOrDir(cFile, AcceptRejectRule.Cascade)
            Next
            Return zip.WriteZipAndClose()
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function ZipFile(ByVal cSourceFile As String, ByVal cDestFile As String) As Boolean
        Try
            Dim zip As New Chilkat.Zip()
            zip.UnlockComponent("SPCTASZIP_4gpKXqstjEuf")
            zip.NewZip(cDestFile)
            zip.AppendOneFileOrDir(cSourceFile, False)
            Return zip.WriteZipAndClose()
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function UnzipFile(ByVal cSourceFile As String, ByVal cDestFile As String) As String
        Dim zip As New Chilkat.Zip, nFile As String
        Try
            zip.UnlockComponent("SPCTASZIP_4gpKXqstjEuf")
            zip.OpenZip(cSourceFile)
            nFile = zip.FirstEntry.FileName
            zip.Unzip(cDestFile)
            zip.CloseZip()
            If nFile = "" Then
                LogErrors(String.Format("UZF: {0}", zip.LastErrorText))
                Return ""
            Else
                Return nFile
            End If
        Catch ex As Exception
            LogErrors(String.Format("UZF: {0}", zip.LastErrorText))
            Return ""
        End Try
    End Function

    Public Function UnzipFile(ByVal cSourceFile As String, ByVal cDestFile As String, ByVal OverwriteExisting As Boolean) As String
        Dim zip As New Chilkat.Zip, nFile As String
        Try
            zip.UnlockComponent("SPCTASZIP_4gpKXqstjEuf")
            zip.OverwriteExisting = OverwriteExisting
            zip.OpenZip(cSourceFile)
            nFile = zip.FirstEntry.FileName
            zip.Unzip(cDestFile)
            zip.CloseZip()
            If nFile = "" Then
                LogErrors(String.Format("UZF: {0}", zip.LastErrorText))
                Return ""
            Else
                Return nFile
            End If
        Catch ex As Exception
            LogErrors(String.Format("UZF: {0}", zip.LastErrorText))
            Return ""
        End Try
    End Function

#End Region

#Region "ItemDelimited: Legacy functions from MPS"

    'RETURNS: <nItemNo> value item in <cPairedList> being delimited by <cPairSet>
    '   example:
    '                             "[]"  <--- <cPairSet>
    '       "[item1][item2]...[itemN]"   <--- <cPairedList>
    '
    '
    '       ** setting <nItemNo> parameter to 2 will make the function return the text "item2"
    '
    Public Function usrGetPairedValue(ByVal cPairedList As String, ByVal cPairSet As String, ByVal nItemNo As Integer) As String
        Dim cDelimiter As String, nItemCnt As Integer
        Dim cRetVal As String

        If Len(cPairSet) <> 2 Then
            'Msgbox("<cPairSet> parameter must be 2 characters in length. This will denote the starting and ending delimiter for each item in <cPairedList> parameter.", vbCritical, "usrGetPairedValue()")
            Return ""
            Exit Function
        End If

        cDelimiter = Right$(cPairSet, 1) & Left$(cPairSet, 1) 'reverse pair set
        nItemCnt = CountItemDelimited(cPairedList, cDelimiter)
        cRetVal = GetItemDelimited(cPairedList, nItemNo, cDelimiter)

        If nItemNo = 1 Then
            cRetVal = Mid$(cRetVal, 2, IIf(nItemCnt = 1, Len(cRetVal) - 2, Len(cRetVal) - 1))
        ElseIf nItemNo = nItemCnt Then
            If Len(cRetVal) > 0 Then
                cRetVal = Left$(cRetVal, Len(cRetVal) - 1)
            Else
                cRetVal = ""
            End If
        End If

        usrGetPairedValue = cRetVal

    End Function
    'RETURNS: item index of cSearchStr in cItemList
    '
    'NOTES:
    'Search is CASE-SENSITIVE
    '
    Public Function SearchItemDelimited(ByVal cItemList, ByVal cDelimitedBy, ByVal cSearchStr)
        Dim nPos As Integer

        cItemList = cDelimitedBy & cItemList & cDelimitedBy
        nPos = InStr(cItemList, cDelimitedBy & cSearchStr & cDelimitedBy)
        If nPos > 1 Then
            nPos = nPos - 1
        End If
        SearchItemDelimited = IndexItemDelimited(cItemList, cDelimitedBy, nPos) 'get index number

    End Function

    Public Function CountItemDelimited(ByVal cItemList, ByVal cDelimitedBy)
        Dim nCount As Integer
        nCount = CountStr(cItemList, cDelimitedBy)
        If nCount > 0 Then
            nCount = nCount + 1
        ElseIf Len(cItemList) > 0 Then
            nCount = 1
        End If
        CountItemDelimited = nCount
    End Function


    Public Function DeleteItemDelimited(ByVal cItemList As String, ByVal nItemNo As Integer, ByVal cDelimitedBy As String)
        Dim nPlace As Integer, nCount As Integer, nStart As Integer, bAppended As Integer
        Dim cNewItemList As String

        DeleteItemDelimited = cItemList

        If nItemNo > 0 Then

            bAppended = False

            If CountStr(cItemList, cDelimitedBy) < nItemNo Then
                cItemList = cItemList & cDelimitedBy
                bAppended = True
            End If
            nStart = 1
            nCount = 0
            nPlace = InStr(nStart, cItemList, cDelimitedBy)
            Do While nPlace
                nCount = nCount + 1
                If nCount = nItemNo Then
                    cNewItemList = Mid$(cItemList, 1, nStart - 1) & Mid$(cItemList, nPlace + Len(cDelimitedBy))
                    If bAppended And Len(cNewItemList) > 0 Then
                        cNewItemList = Left$(cNewItemList, Len(cNewItemList) - Len(cDelimitedBy))
                    End If
                    DeleteItemDelimited = cNewItemList
                    Exit Do
                Else
                    nStart = nPlace + Len(cDelimitedBy)
                    nPlace = InStr(nStart, cItemList, cDelimitedBy)
                End If
            Loop

        End If

    End Function

    Public Function GetItemDelimited(ByVal cItemList As String, ByVal nItemNo As Integer, ByVal cDelimitedBy As String)
        Dim nPlace As Integer, nCount As Integer, nStart As Integer
        Dim bAppended

        GetItemDelimited = ""

        If CountStr(cItemList, cDelimitedBy) < nItemNo Then
            cItemList = cItemList & cDelimitedBy
            bAppended = True
        End If
        nStart = 1
        nCount = 0
        nPlace = InStr(nStart, cItemList, cDelimitedBy)
        Do While nPlace
            nCount = nCount + 1
            If nCount = nItemNo Then
                GetItemDelimited = Mid$(cItemList, nStart, (nPlace) - nStart)
                Exit Do
            Else
                nStart = nPlace + Len(cDelimitedBy)
                nPlace = InStr(nStart, cItemList, cDelimitedBy)
            End If
        Loop

    End Function

    'FUNCTION: Returns the Index of the item occupied by
    'a certain character position
    '
    '
    Public Function IndexItemDelimited(ByVal cItemList, ByVal cDelimitedBy, ByVal nCharPos)
        Dim nTotItems As Integer, nEndCount As Integer
        If nCharPos <= Len(cItemList) And Len(cItemList) <> 0 And nCharPos <> 0 Then
            nTotItems = CountItemDelimited(cItemList, cDelimitedBy)
            cItemList = Mid$(cItemList, nCharPos)
            nEndCount = CountItemDelimited(cItemList, cDelimitedBy)
            IndexItemDelimited = nTotItems - nEndCount + 1
        Else
            IndexItemDelimited = 0
        End If
    End Function


    Public Function SaveItemDelimited(ByRef cItemList As String, ByVal nItemNo As Integer, ByVal cDelimitedBy As String, ByVal cSaveStr As String)
        Dim nPlace As Integer, nCount As Integer, nStart As Integer
        Dim cNewItemList As String
        Dim bFound As Boolean = False, nCtr As Integer

        SaveItemDelimited = False

        If CountItemDelimited(cItemList, cDelimitedBy) = 1 And nItemNo = 1 Then
            cItemList = cSaveStr
        Else
            If CountStr(cItemList, cDelimitedBy) < nItemNo Then
                For nCtr = 1 To (nItemNo - CountItemDelimited(cItemList, cDelimitedBy))
                    cItemList = cItemList & cDelimitedBy & "?"
                Next
            End If
            nStart = 1
            nCount = 0
            nPlace = InStr(nStart, cItemList, cDelimitedBy)

            Do While nPlace
                nCount = nCount + 1
                If nCount = nItemNo Then
                    'first position to (last position - 1)
                    cNewItemList = Mid$(cItemList, 1, nStart - 1) & cSaveStr & Mid$(cItemList, nPlace)
                    SaveItemDelimited = True
                    cItemList = cNewItemList
                    bFound = True
                    Exit Do
                Else
                    nStart = nPlace + Len(cDelimitedBy)
                    nPlace = InStr(nStart, cItemList, cDelimitedBy)
                    If nPlace = 0 And nCount = (nItemNo - 1) Then
                        'last position
                        cNewItemList = Mid$(cItemList, 1, nStart - 1) & cSaveStr
                        SaveItemDelimited = True
                        cItemList = cNewItemList
                        bFound = True
                        Exit Do
                    End If
                End If
            Loop
        End If

    End Function
    'FUNCTION: Counts the occurence of cCountWhat in cCount string
    '
    '
    Public Function CountStr(ByVal cCount, ByVal cCountWhat) As Integer
        Dim nCount As Integer, nnCtr As Integer
        If Not IsNull(cCount) And Not IsNull(cCountWhat) Then
            cCount = UCase(cCount)
            cCountWhat = UCase(cCountWhat)
            nCount = 0
            For nnCtr = 1 To Len(cCount)
                If Len(cCount) - nnCtr + 1 >= Len(cCountWhat) Then
                    If Mid$(cCount, nnCtr, Len(cCountWhat)) = cCountWhat Then
                        nCount = nCount + 1
                    End If
                End If
            Next
        End If
        CountStr = nCount
    End Function

    Private Function IsNull(ByVal xItem) As Boolean
        If xItem Is Nothing Then
            Return True
        Else
            Return False
        End If
    End Function

#End Region

    Public Sub ExportPMSData(db As SQLDB, nExpType As Integer, strFile As String, dStartDate As Object, dEndDate As Object, bAuto As Boolean)
        Dim sqls As New ArrayList, tbl As DataTable, drRow As DataRow ', strAdminFilter As String = ""
        DATE_LAST_EXPORT = ChangeToSQLDate(Now.date).Replace("'", "")
        sqls.Add(IMO_NUMBER & "|" & nExpType & "|" & DATE_LAST_EXPORT & "|" & "PMS Data.")
        strFile = GetFileDir(strFile) & GetFileNameWithoutExtension(strFile)
        If (nExpType And 1) > 0 Then
            tbl = db.CreateTable("SELECT TOP 1 * FROM [dbo].[VESSELINFO]")
            sqls.Add("tblAdmVsl")
            For Each drRow In tbl.Rows
                sqls.Add("'" & drRow("VslCode") & "','" & drRow("Vessel").ToString.Replace("'", "''") & "','" & drRow("IMONo") & "','" & drRow("Email") & "','" & drRow("VslTypeCode") & "','" & drRow("Flag") & "','" & VERSION_NUMBER & "'")
            Next
            sqls.Add("END")

            tbl = db.CreateTable("SELECT [LocCode],[Name],[LastUpdatedBy] FROM [dbo].[tblAdmLocation]")
            sqls.Add("tblAdmLocation")
            For Each drRow In tbl.Rows
                sqls.Add("'" & drRow("LocCode") & "','" & drRow("Name").ToString.Replace("'", "''") & "','" & drRow("LastUpdatedBy").ToString.Replace("'", "''") & "'")
            Next
            sqls.Add("END")

            tbl = db.CreateTable("SELECT [StorageCode],[Name],[LastUpdatedBy] FROM [dbo].[tblAdmStorage]")
            sqls.Add("tblAdmStorage")
            For Each drRow In tbl.Rows
                sqls.Add("'" & drRow("StorageCode") & "','" & drRow("Name").ToString.Replace("'", "''") & "','" & drRow("LastUpdatedBy").ToString.Replace("'", "''") & "'")
            Next
            sqls.Add("END")

            tbl = db.CreateTable("SELECT [CatCode],[Name],[LastUpdatedBy] FROM [dbo].[tblAdmCategory]")
            sqls.Add("tblAdmCategory")
            For Each drRow In tbl.Rows
                sqls.Add("'" & drRow("CatCode") & "','" & drRow("Name").ToString.Replace("'", "''") & "','" & drRow("LastUpdatedBy").ToString.Replace("'", "''") & "'")
            Next
            sqls.Add("END")

            tbl = db.CreateTable("SELECT [WorkCode],[Name],[LastUpdatedBy],ISNULL([SortCode],0) SortCode FROM [dbo].[tblAdmWork] WHERE LEFT([WorkCode],3)<>'SYS'")
            sqls.Add("tblAdmWork")
            For Each drRow In tbl.Rows
                sqls.Add("'" & drRow("WorkCode") & "','" & drRow("Name").ToString.Replace("'", "''") & "','" & drRow("LastUpdatedBy").ToString.Replace("'", "''") & "'," & drRow("SortCode"))
            Next
            sqls.Add("END")

            tbl = db.CreateTable("SELECT [PartCode],[Name],[PartNumber],[OnStock],[Minimum],[InitStock],[LocCode],[StorageCode],[LastUpdatedBy] FROM [dbo].[tblAdmPart]")
            sqls.Add("tblAdmPart")
            For Each drRow In tbl.Rows
                sqls.Add("'" & drRow("PartCode") & "','" & drRow("Name").ToString.Replace("'", "''") & "','" & drRow("PartNumber") & "'," & IfNull(drRow("OnStock"), "0") & "," & IfNull(drRow("Minimum"), "0") & "," & IfNull(drRow("InitStock"), 0) & ",'" & drRow("LocCode") & "','" & drRow("StorageCode") & "','" & drRow("LastUpdatedBy").ToString.Replace("'", "''") & "'")
            Next
            sqls.Add("END")

            tbl = db.CreateTable("SELECT [ComponentCode],[Name],[LastUpdatedBy] FROM [dbo].[tblAdmComponent]")
            sqls.Add("tblAdmComponent")
            For Each drRow In tbl.Rows
                sqls.Add("'" & drRow("ComponentCode") & "','" & drRow("Name").ToString.Replace("'", "''") & "','" & drRow("LastUpdatedBy").ToString.Replace("'", "''") & "'")
            Next
            sqls.Add("END")

            tbl = db.CreateTable("SELECT [UnitCode],[UnitDesc],[ParentCode],[ComponentCode],[UnitNumber],[SerialNumber],[LastUpdatedBy],[Critical],[DeptCode],[CatCode],[RunningHours],[ReadingDate],[Active],[MakerCode],[Type],[Model],[RefNo],[LocCode],[VendorCode],[HoursPerDay],[HasCritical],[HasInactive] FROM [dbo].[tblAdmUnit]")
            sqls.Add("tblAdmUnit")
            For Each drRow In tbl.Rows
                sqls.Add("'" & drRow("UnitCode") & "','" & drRow("UnitDesc").ToString.Replace("'", "''") & "'," & ChangeToExportString(drRow("ParentCode")) & ",'" & drRow("ComponentCode") & "','" & drRow("UnitNumber") & "','" & drRow("SerialNumber") & "','" & drRow("LastUpdatedBy") & "'," & IIf(drRow("Critical"), 1, 0) & ",'" & drRow("DeptCode") & "','" & drRow("CatCode") & "'," & IfNull(drRow("RunningHours"), "0") & "," & ChangeToExportDate(drRow("ReadingDate")) & "," & IIf(drRow("Active"), 1, 0) & ",'" & drRow("MakerCode") & "','" & drRow("Type") & "','" & drRow("Model") & "','" & drRow("RefNo") & "','" & drRow("LocCode") & "','" & drRow("VendorCode") & "'," & IfNull(drRow("HoursPerDay"), "NULL") & "," & IIf(drRow("HasCritical"), 1, 0) & "," & IIf(drRow("HasInactive"), 1, 0))
            Next
            sqls.Add("END")

            tbl = db.CreateTable("SELECT [MaintenanceCode],[WorkCode],[UnitCode],[RankCode],[Number],[IntCode],[InsCrossRef],[InsEditor],[InsDocument],[InsDateIssue],[InsDesc],[LastUpdatedBy] FROM [dbo].[tblAdmMaintenance] WHERE LEFT([MaintenanceCode],3)<>'SYS'")
            sqls.Add("tblAdmMaintenance")
            For Each drRow In tbl.Rows
                sqls.Add("'" & drRow("MaintenanceCode") & "','" & drRow("WorkCode") & "','" & drRow("UnitCode") & "','" & drRow("RankCode") & "'," & IfNull(drRow("Number"), "NULL") & ",'" & drRow("IntCode") & "','" & drRow("InsCrossRef") & "','" & drRow("InsEditor") & "','" & drRow("InsDocument") & "'," & ChangeToExportDate(drRow("InsDateIssue")) & ",'" & drRow("InsDesc") & "','" & drRow("LastUpdatedBy").ToString.Replace("'", "''") & "'")
            Next
            sqls.Add("END")

            tbl = db.CreateTable("SELECT '" & IMO_NUMBER & "' + RIGHT('00000000' + RTRIM( [UnitPartID]),8) UnitPartID,[UnitCode],[PartCode] FROM [dbo].[tblUnitPart]")
            sqls.Add("tblUnitPart")
            For Each drRow In tbl.Rows
                sqls.Add("'" & drRow("UnitPartID") & "','" & drRow("UnitCode") & "','" & drRow("PartCode") & "'")
            Next
            sqls.Add("END")

            tbl = db.CreateTable("SELECT [CounterCode],[Name],[UnitCode],[SortCode],[LastUpdatedBy] FROM [dbo].[tblAdmCounter]")
            sqls.Add("tblAdmCounter")
            For Each drRow In tbl.Rows
                sqls.Add("'" & drRow("CounterCode") & "','" & drRow("Name") & "','" & drRow("UnitCode") & "'," & drRow("SortCode") & ",'" & drRow("LastUpdatedBy").ToString.Replace("'", "''") & "'")
            Next
            sqls.Add("END")
        End If

        If (nExpType And 2) > 0 Then
            tbl = db.CreateTable("SELECT [MaintenanceWorkID],[UnitCode],[MaintenanceCode],[RankCode],[WorkDate],[WorkCounter],[ExecutedBy],[Remarks],[DueCounter],[DueDate],[LastUpdatedBy] FROM [dbo].[tblMaintenanceWork] WHERE WorkDate>=" & ChangeToExportDate(dStartDate) & " AND WorkDate<=" & ChangeToExportDate(dEndDate))
            sqls.Add("tblMaintenanceWork")
            For Each drRow In tbl.Rows
                sqls.Add("'" & Trim(drRow("MaintenanceWorkID")) & "','" & drRow("UnitCode") & "','" & drRow("MaintenanceCode") & "','" & drRow("RankCode") & "'," & ChangeToExportDate(drRow("WorkDate")) & ",'" & drRow("WorkCounter") & "','" & drRow("ExecutedBy").ToString.Replace("'", "''") & "','" & drRow("Remarks").ToString.Replace("'", "''") & "','" & drRow("DueCounter") & "'," & ChangeToExportDate(drRow("DueDate")) & ",'" & drRow("LastUpdatedBy").ToString.Replace("'", "''") & "'")
            Next
            sqls.Add("END")

            tbl = db.CreateTable("SELECT [PartCode],[MaintenanceWorkID],[DateConsumed],[Number],[Remarks] FROM [dbo].[tblPartConsumption]")
            sqls.Add("tblPartConsumption")
            For Each drRow In tbl.Rows
                sqls.Add("'" & drRow("PartCode") & "','" & drRow("MaintenanceWorkID") & "'," & ChangeToExportDate(drRow("DateConsumed")) & "," & drRow("Number") & ",'" & drRow("Remarks").ToString.Replace("'", "''") & "'")
            Next
            sqls.Add("END")

            tbl = db.CreateTable("SELECT [PartPurchaseCode],[PurchaseDate],[Status],[LastUpdatedBy],[VendorCode] FROM [dbo].[tblPartPurchase]")
            sqls.Add("tblPartPurchase")
            For Each drRow In tbl.Rows
                sqls.Add("'" & drRow("PartPurchaseCode") & "'," & ChangeToExportDate(drRow("PurchaseDate")) & ",'" & drRow("Status") & "','" & drRow("VendorCode") & "','" & drRow("LastUpdatedBy").ToString.Replace("'", "''") & "'")
            Next
            sqls.Add("END")

            tbl = db.CreateTable("SELECT [PartPurchaseCode],[PartCode],[VendorCode],[Quantity],[DateReceived],[ReceivedQuantity],[LastUpdatedBy] FROM [dbo].[tblPartPurchaseDetail]")
            sqls.Add("tblPartPurchaseDetail")
            For Each drRow In tbl.Rows
                sqls.Add("'" & drRow("PartPurchaseCode") & "','" & drRow("PartCode") & "','" & drRow("VendorCode") & "'," & drRow("Quantity") & "," & ChangeToExportDate(drRow("DateReceived")) & ",'" & drRow("ReceivedQuantity") & "','" & drRow("LastUpdatedBy").ToString.Replace("'", "''") & "'")
            Next
            sqls.Add("END")

            tbl = db.CreateTable("SELECT [CounterCode],[ReadingDate],[Reading],[HoursPerDay],[LastUpdatedBy] FROM [dbo].[tblCounterReading]")
            sqls.Add("tblCounterReading")
            For Each drRow In tbl.Rows
                sqls.Add("'" & drRow("CounterCode") & "'," & ChangeToExportDate(drRow("ReadingDate")) & "," & drRow("Reading") & "," & drRow("HoursPerDay") & ",'" & drRow("LastUpdatedBy").ToString.Replace("'", "''") & "'")
            Next
            sqls.Add("END")
        End If

        Using sw As New System.IO.StreamWriter(strFile & ".txt", False, System.Text.Encoding.Unicode)
            Dim strTemp As String
            For Each strTemp In sqls
                sw.Write(Shuffle(strTemp, True) & "Ç")
            Next
        End Using

        If ZipFile(strFile & ".txt", strFile & ".pmsf") Then
            System.Windows.Forms.Application.DoEvents()
            Kill(strFile & ".txt")
        End If

    End Sub

    Public Function ExtractFromTextFile(strFile As String) As String
        Dim strRetval As String = ""
        Using sr As New System.IO.StreamReader(strFile)
            strRetval = sr.ReadToEnd
        End Using
        Return strRetval
    End Function

    Public Function ImportFromFile(strField1 As String, strField2 As String) As DataRow()
        Dim strFileText As String, strTemp As String
        Dim ctable As New DataTable, ccolumn As DataColumn, frm As New frmImport
        Dim odMain As New System.Windows.Forms.OpenFileDialog
        '"Files (*.jpg, *.jpeg, *.png, *.txt, *.doc, *.docx, *.pdf) | *.jpg; *.jpeg; *.png; *.txt, *.doc, *.docx, *.pdf"
        odMain.Filter = "Files (*.txt, *.pdf) | *.txt; *.pdf"
        If odMain.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Select Case GetFileNameExtension(odMain.FileName)
                Case ".pdf"
                    strFileText = ExtractTextFromPDF(odMain.FileName)
                Case ".txt"
                    strFileText = ExtractFromTextFile(odMain.FileName)
            End Select
            ccolumn = New DataColumn
            ccolumn.ColumnName = strField1
            ccolumn.DataType = System.Type.GetType("System.String")
            ctable.Columns.Add(ccolumn)

            If strField2 <> "" Then
                ccolumn = New DataColumn
                ccolumn.ColumnName = strField2
                ccolumn.DataType = System.Type.GetType("System.String")
                ctable.Columns.Add(ccolumn)
            End If

            ccolumn = New DataColumn
            ccolumn.ColumnName = "Selected"
            ccolumn.DataType = System.Type.GetType("System.Boolean")
            ctable.Columns.Add(ccolumn)

            For Each strTemp In strFileText.Split(Environment.NewLine)
                strTemp = strTemp.Replace(vbLf, "")
                If strTemp <> "" Then
                    If strField2 = "" Then
                        Dim strRows() As String = strTemp.Split(vbTab)
                        Dim crow() As Object = {strRows(0), True}
                        ctable.Rows.Add(crow)
                    Else
                        Dim strRows() As String = strTemp.Split(vbTab)
                        If strRows.Length > 1 Then
                            Dim crow() As Object = {strRows(0), strRows(1), True}
                            ctable.Rows.Add(crow)
                        Else
                            Dim crow() As Object = {strRows(0), "", True}
                            ctable.Rows.Add(crow)
                        End If
                    End If
                End If
            Next
            frm.MainGrid.DataSource = ctable
            frm.gDetails.Text = "Import " & strField1
            frm.Field1.Caption = strField1
            frm.Field1.FieldName = strField1
            If strField2 <> "" Then
                frm.Field2.Caption = strField2
                frm.Field2.FieldName = strField2
            Else
                frm.Field2.Visible = False
            End If
            frm.ShowDialog()
            If frm.bSaved Then
                frm.MainView.CloseEditor()
                frm.MainView.UpdateCurrentRow()
                Return ctable.Select("Selected=True")
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
    End Function

    Public Function ImportFromClipboard(strField1 As String, strField2 As String) As DataRow()
        Dim strFromClip As String = System.Windows.Forms.Clipboard.GetText, strTemp As String
        Dim ctable As New DataTable, ccolumn As DataColumn, frm As New frmImport
        ccolumn = New DataColumn
        ccolumn.ColumnName = strField1
        ccolumn.DataType = System.Type.GetType("System.String")
        ctable.Columns.Add(ccolumn)

        If strField2 <> "" Then
            ccolumn = New DataColumn
            ccolumn.ColumnName = strField2
            ccolumn.DataType = System.Type.GetType("System.String")
            ctable.Columns.Add(ccolumn)
        End If

        ccolumn = New DataColumn
        ccolumn.ColumnName = "Selected"
        ccolumn.DataType = System.Type.GetType("System.Boolean")
        ctable.Columns.Add(ccolumn)

        For Each strTemp In strFromClip.Split(Environment.NewLine)
            strTemp = strTemp.Replace(vbLf, "")
            If strTemp <> "" Then
                If strField2 = "" Then
                    Dim strRows() As String = strTemp.Split(vbTab)
                    Dim crow() As Object = {strRows(0), True}
                    ctable.Rows.Add(crow)
                Else
                    Dim strRows() As String = strTemp.Split(vbTab)
                    If strRows.Length > 1 Then
                        Dim crow() As Object = {strRows(0), strRows(1), True}
                        ctable.Rows.Add(crow)
                    Else
                        Dim crow() As Object = {strRows(0), "", True}
                        ctable.Rows.Add(crow)
                    End If
                End If
            End If
        Next
        frm.MainGrid.DataSource = ctable
        frm.gDetails.Text = "Import " & strField1
        frm.Field1.Caption = strField1
        frm.Field1.FieldName = strField1
        If strField2 <> "" Then
            frm.Field2.Caption = strField2
            frm.Field2.FieldName = strField2
        Else
            frm.Field2.Visible = False
        End If
        frm.ShowDialog()
        If frm.bSaved Then
            frm.MainView.CloseEditor()
            frm.MainView.UpdateCurrentRow()
            Return ctable.Select("Selected=True")
        Else
            Return Nothing
        End If
    End Function

    Public Function PasteAdminData(db As SQLDB, strKey As String, strTable As String, ByRef strValue As String, ByRef bExist As Boolean) As String
        strValue = strValue.ToString.Replace("'", "''")
        Dim strCode As String = db.DLookUp(strKey, "dbo." & strTable, "", "Name='" & strValue & "'")
        If strCode = "" Then
            bExist = False
            strCode = GenerateID(db, strKey, strTable)
            db.RunSql("INSERT INTO dbo." & strTable & "(" & strKey & ", Name, LastUpdatedBy) VALUES('" & strCode & "', '" & strValue & "','" & GetUserName() & "')")
        End If
        Return strCode
    End Function

    Public Function PastePartData(db As SQLDB, strKey As String, strTable As String, ByRef strValue As String, ByRef strPartNumber As String, ByRef bExist As Boolean) As String
        strValue = strValue.ToString.Replace("'", "''")
        Dim strCode As String = db.DLookUp(strKey, "dbo." & strTable, "", "Name='" & strValue & "' AND PartNumber='" & strPartNumber & "'")
        If strCode = "" Then
            bExist = False
            strCode = GenerateID(db, strKey, strTable)
            db.RunSql("INSERT INTO dbo." & strTable & "(" & strKey & ", Name, PartNumber, LastUpdatedBy) VALUES('" & strCode & "', '" & strValue & "', '" & strPartNumber & "','" & GetUserName() & "')")
        End If
        Return strCode
    End Function

    Public Function ExtractTextFromPDF(file As String)
        Dim strText As String = ""
        Try
            Using pdf As New DevExpress.Pdf.PdfDocumentProcessor
                pdf.LoadDocument(file)
                strText = pdf.Text
            End Using
        Catch ex As Exception
        End Try
        Return strText
    End Function

    'Sub importexldata(db As SQLDB)
    '    Dim exl As ExcelFile, sqls As New ArrayList, cnt As Integer
    '    exl = New ExcelFile("C:\Projects\Intervalle.xlsx")
    '    If exl._initialized Then
    '        For cnt = 1 To 520
    '            sqls.Add("INSERT INTO [pms5_db].[dbo].[tblAdmPlanningx]([PlanningCode],[MachineCode],[Number],[Type],[WorkDescription],[RankCode],[InsCrossRef],[InsDesc],[InsEditor],[InsDateIssue],[Hours],[Days]) " & _
    '                 "VALUES('1234567" & CInt(exl.GetValue(cnt, 1)).ToString("00000000") & "','" & exl.GetValue(cnt, 2) & "'," & exl.GetValue(cnt, 3) & ",'" & exl.GetValue(cnt, 4) & "','" & exl.GetValue(cnt, 5) & "','" & exl.GetValue(cnt, 6) & "','" & exl.GetValue(cnt, 7) & "','" & exl.GetValue(cnt, 8).ToString.Replace("'", "''") & "','" & exl.GetValue(cnt, 9) & "'," & ChangeToSQLDate(exl.GetValue(cnt, 10)) & "," & exl.GetValue(cnt, 11) & "," & exl.GetValue(cnt, 12) & ")")
    '        Next
    '    End If
    '    exl.Dispose()
    '    db.RunSqls(sqls)
    'End Sub

    Public Function ImageToString(img As Bitmap) As String
        Dim objstream As New System.IO.MemoryStream
        img.Save(objstream, Imaging.ImageFormat.Jpeg)
        Return Convert.ToBase64String(objstream.ToArray)
    End Function

    Public Function StringToImage(strBase64 As String) As Image
        Dim arrBytes() As Byte = Convert.FromBase64String(strBase64), retImg As Image
        Using ms As New IO.MemoryStream(arrBytes)
            retImg = Image.FromStream(ms)
        End Using
        Return retImg
    End Function

    Public Function StringToStream(strStream As String) As System.IO.MemoryStream
        Dim arrByte As Byte() = System.Text.Encoding.UTF8.GetBytes(strStream)
        Return New System.IO.MemoryStream(arrByte)
    End Function

    Public Function StringToFileStream(strStream As String) As System.IO.FileStream
        Dim msStream As System.IO.MemoryStream = StringToStream(strStream)
        Dim fs As New System.IO.FileStream("x.pdf", IO.FileMode.Create)
        msStream.CopyTo(fs)
        Return fs
    End Function

    Public Function FileStreamToString(strFile As String) As String
        Dim fs As New System.IO.FileStream(strFile, IO.FileMode.Open, IO.FileAccess.Read)
        Dim msStream As New System.IO.MemoryStream
        fs.CopyTo(msStream)
        Return Convert.ToBase64String(msStream.ToArray)
    End Function

    Public Function ValidateSQLString(ByVal Value As String) As String
        If String.IsNullOrEmpty(Value) OrElse Value = "" Then
            Return ""
        Else
            Return Value.Replace("'", "''")
        End If
    End Function

    Public Function CleanDirPath(ByVal cDir As String, Optional ByVal cSeparator As String = "\") As String
        Return cDir & IIf(Microsoft.VisualBasic.Right(cDir, 1) = cSeparator, "", cSeparator)
    End Function


    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetUserName() As String
        Return USER_NAME & "@" & System.Environment.MachineName
    End Function

    'Public Function GetPlanType() As DataTable
    '    Dim ctable As New DataTable, ccolumn As DataColumn
    '    ccolumn = New DataColumn
    '    ccolumn.ColumnName = "Type"
    '    ccolumn.DataType = System.Type.GetType("System.String")
    '    ctable.Columns.Add(ccolumn)
    '    ccolumn = New DataColumn
    '    ccolumn.ColumnName = "TypeDesc"
    '    ccolumn.DataType = System.Type.GetType("System.String")
    '    ctable.Columns.Add(ccolumn)
    '    ctable.Rows.Add(New Object() {"SYSHOURS", "Hours"})
    '    ctable.Rows.Add(New Object() {"SYSDAYS", "Days"})
    '    ctable.Rows.Add(New Object() {"SYSWEEKS", "Weeks"})
    '    ctable.Rows.Add(New Object() {"SYSMONTHS", "Months"})
    '    ctable.Rows.Add(New Object() {"SYSYEARS", "Years"})
    '    Return ctable
    'End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetAppName() As String
        Return "Planned Maintenance System v" & VERSION_NUMBER
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function ChangeLongDateStrToDate(ByVal StrDate As String) As Date
        Dim xYear As Integer, xMonth As Integer, xDay As Integer, xHour As Integer, xMinute As Integer, xSeconds As Integer
        StrDate = StrDate.Replace("'", "").Trim

        If StrDate.Length = 14 And Not (StrDate.Contains("-") Or StrDate.Contains(" ")) Then
            xYear = CInt(StrDate.Substring(0, 4))

            xMonth = CInt(StrDate.Substring(4, 2))

            xDay = CInt(StrDate.Substring(6, 2))

            xHour = CInt(StrDate.Substring(8, 2))

            xMinute = CInt(StrDate.Substring(10, 2))

            xSeconds = CInt(StrDate.Substring(12, 2))
        Else
            xYear = CInt(StrDate.Substring(0, 4))
            StrDate = StrDate.Remove(0, 5)

            xMonth = CInt(StrDate.Substring(0, InStr(StrDate, "-") - 1))
            StrDate = StrDate.Remove(0, InStr(StrDate, "-"))

            xDay = CInt(StrDate.Substring(0, InStr(StrDate, " ") - 1))
            StrDate = StrDate.Remove(0, InStr(StrDate, " "))

            xHour = CInt(StrDate.Substring(0, 2))
            StrDate = StrDate.Remove(0, InStr(StrDate, " "))

            xMinute = CInt(StrDate.Substring(0, 2))
            StrDate = StrDate.Remove(0, InStr(StrDate, ":"))

            xSeconds = CInt(StrDate.Substring(0, 2))
        End If

        Return New Date(xYear, xMonth, xDay, xHour, xMinute, xSeconds)
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function ChangeSQLDateStrToDate(ByVal StrDate As String) As Date
        Dim xYear As Integer, xMonth As Integer, xDay As Integer
        StrDate = StrDate.Replace("'", "").Trim

        xYear = CInt(StrDate.Substring(0, 4))
        StrDate = StrDate.Remove(0, 5)

        xMonth = CInt(StrDate.Substring(0, InStr(StrDate, "-") - 1))
        StrDate = StrDate.Remove(0, InStr(StrDate, "-"))

        If StrDate.Length > 2 Then
            xDay = CInt(StrDate.Substring(0, InStr(StrDate, " ") - 1))
        Else
            xDay = CInt(StrDate)
        End If
        Return DateSerial(xYear, xMonth, xDay)
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function ChangeToSQLDate(ByVal nDate As Date) As String
        Return "'" & nDate.Year.ToString("0000") & "-" & nDate.Month.ToString("00") & "-" & nDate.Day.ToString("00") & " " & nDate.Hour.ToString("00") & ":" & nDate.Minute.ToString("00") & ":" & nDate.Second.ToString("00") & "'"
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function ChangeToSQLDate(ByVal mCode As Integer, ByVal cDay As Integer) As String
        Return "'" & (mCode \ 100).ToString("0000") & "-" & (mCode Mod 100).ToString("00") & "-" & cDay.ToString("00") & "'"
    End Function

    Public Function ChangeToSQLDate(ByVal nDate As Date, ByVal cTime As DateTime) As String
        Return "'" & nDate.Year.ToString("0000") & "-" & nDate.Month.ToString("00") & "-" & nDate.Day.ToString("00") & " " & cTime.Hour.ToString("00") & ":" & cTime.Minute.ToString("00") & ":" & cTime.Second.ToString("00") & "'"
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function ChangeToDateSerial(ByVal nDate As Date) As String
        Return "DateSerial(" & nDate.Year.ToString("0000") & "," & nDate.Month.ToString("00") & "," & nDate.Day.ToString("00") & ")"
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function ChangeToDateSerial(ByVal mCode As Integer, ByVal cDay As Integer) As String
        Return "DateSerial(" & (mCode \ 100).ToString("0000") & "," & (mCode Mod 100).ToString("00") & "," & cDay.ToString("00") & ")"
    End Function


    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function MultiString(ByVal _Number As Integer, ByVal _Char As Char)
        Dim RetVal As String = "", cnt
        For cnt = 1 To _Number
            RetVal = RetVal & _Char
        Next
        Return RetVal
    End Function

    Public Function ValidateFields(ByVal view As DevExpress.XtraGrid.Views.Grid.GridView, ByVal strReqFields As String) As Boolean
        Dim xrow As DataRowView, i As Integer, c As Integer
        For i = 0 To view.RowCount - 1
            xrow = view.GetRow(i)
            For c = 0 To view.Columns.Count - 1
                If InStr(1, ";" & strReqFields & ";", ";" & view.Columns(c).Name & ";") > 0 Then
                    If (xrow.Item(view.Columns(c).Name) Is System.DBNull.Value Or xrow.Item(view.Columns(c).Name) Is Nothing) Then
                        MsgBox("Please fill in all the (*)required fields.", MsgBoxStyle.Critical)
                        Return False
                    End If
                End If
            Next
        Next
        Return True
    End Function

    Public Function ValidateFields(ByVal ctrs() As DevExpress.XtraEditors.BaseEdit) As Boolean
        Dim ctr As DevExpress.XtraEditors.BaseEdit
        For Each ctr In ctrs
            If ctr.Visible Then
                If ctr.EditValue Is System.DBNull.Value Or ctr.EditValue Is Nothing Then
                    MsgBox("Please fill in all the (*)required fields.", MsgBoxStyle.Critical, GetAppName)
                    Return False
                Else
                    If TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Then
                        If Not CType(ctr, DevExpress.XtraEditors.CheckEdit).Checked Then
                            MsgBox("Please fill in all the (*)required fields.", MsgBoxStyle.Critical, GetAppName)
                            Return False
                        End If
                    ElseIf Not TypeOf (ctr) Is DevExpress.XtraEditors.DateEdit Then
                        If TypeOf (ctr.EditValue) Is String Then
                            If ctr.EditValue = "" Then
                                MsgBox("Please fill in all the (*)required fields.", MsgBoxStyle.Critical, GetAppName)
                                Return False
                            End If
                        ElseIf ctr.EditValue = 0 Then
                            MsgBox("Please fill in all the (*)required fields.", MsgBoxStyle.Critical, GetAppName)
                            Return False
                        End If
                    End If
                End If
            End If
        Next
        Return True
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetPeriods() As DataTable
        Dim ctable As New DataTable, ccolumn As DataColumn
        Dim dDate As Date = Now.Date
        ccolumn = New DataColumn
        ccolumn.ColumnName = "Period"
        ccolumn.DataType = System.Type.GetType("System.Int32")
        ctable.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "PeriodDesc"
        ccolumn.DataType = System.Type.GetType("System.String")
        ctable.Columns.Add(ccolumn)
        While Date.Compare(dDate, Now.AddMonths(11).Date) <= 0
            Dim crow() As String = {dDate.ToString("yyyy") & dDate.ToString("MM"), dDate.ToString("MMMM-yyyy")}
            ctable.Rows.Add(crow)
            dDate = dDate.AddMonths(1)
        End While
        Return ctable
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetCharTypes() As DataTable
        Dim ctable As New DataTable, ccolumn As DataColumn
        ccolumn = New DataColumn
        ccolumn.ColumnName = "ChartType"
        ccolumn.DataType = System.Type.GetType("System.String")
        ctable.Columns.Add(ccolumn)
        ctable.Rows.Add(New String() {"BAR"})
        ctable.Rows.Add(New String() {"LINE"})
        ctable.Rows.Add(New String() {"AREA"})
        Return ctable
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetTempFolder() As String
        Dim cDir As String = System.IO.Path.GetTempPath & "sas_temp"
        If Not System.IO.Directory.Exists(cDir) Then
            MkDir(cDir)
        End If
        Return cDir & "\"
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetFileNameWithoutExtension(ByVal FullPath As String) As String
        Return System.IO.Path.GetFileNameWithoutExtension(FullPath)
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetFileNameExtension(ByVal FullPath As String) As String
        Return System.IO.Path.GetExtension(FullPath)
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetFileName(ByVal FullPath As String) As String
        Return System.IO.Path.GetFileName(FullPath)
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetFileDir(ByVal FullPath As String) As String
        Return System.IO.Path.GetDirectoryName(FullPath) & "\"
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetSortCode(ByVal DB As SQLDB, ByVal _tbl As String) As Double
        Return CType(DB.DLookUp("Max(SortCode)", "dbo." & _tbl, "0"), Double) + 10
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetConfig(ByVal DB As SQLDB, ByVal cCode As String) As String
        Return DB.DLookUp("Value", "sti_sys.dbo.tblPMS5Config", "", "CODE='" & cCode & "'")
    End Function

    Public Sub SaveConfig(ByVal DB As SQLDB, ByVal cCode As String, ByVal cValue As String)
        Dim has_rec As Boolean = False
        DB.BeginReader("Select Value from sti_sys.dbo.tblPMS5Config Where Code='" & cCode & "'")
        has_rec = DB.HasRows
        DB.CloseReader()
        If has_rec Then
            DB.RunSql("Update sti_sys.dbo.tblPMS5Config set Value='" & cValue & "' Where CODE='" & cCode & "'")
        Else
            DB.RunSql("Insert into sti_sys.dbo.tblPMS5Config(Code,Value) Values('" & cCode & "','" & cValue & "')")
        End If
    End Sub

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GenerateID(ByVal DB As SQLDB, ByVal _Key As String, ByVal _table As String, Optional _database As String = "") As String
        Dim ValidChars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"
        Dim cnt As Integer, ctemp As String = "", prefix As String = IMO_NUMBER
        Randomize()
        Do
            For cnt = 1 To 8
                ctemp = ctemp & ValidChars.Substring(Int(ValidChars.Length * Rnd()), 1)
            Next
        Loop While DB.DLookUp(_Key, IIf(_database = "", "", _database & ".") & "dbo." & _table, "", _Key & "='" & prefix & ctemp & "'") <> ""
        Return prefix & ctemp
    End Function

    'Utility disable all the controls in a certain container.
    'param
    '_container - a control that holds the fields to be disabled.
    Public Sub DisableFields(ByVal _container As System.Windows.Forms.Control)
        Dim ctr As System.Windows.Forms.Control
        For Each ctr In _container.Controls
            ctr.Enabled = False
        Next
    End Sub

    'Utility create an update sql statement from a certain contnainer
    '_container - source of the controls, all of the controls that has an AddListener will be added.
    '_trimstr number of prefix to be removed on controls name. e.t.c txtLName the _trimstr will be set to 3 it will remove txt the leaves LName on the fields.
    '_tbl - the table name that will be used on Update statement.
    '_criteria - the criteria that will be used on Update statement.

    'Additional notes
    'If you intend to used this function make sure you properly set the control's name similar on the datasource. e.t.c data source LName you the name would be txtLName, cboLName, chkLName e.t.c and set the _trimstr to the number of prefix.
    'If you're using DevExpress's TextEdit make sure you set the Masking property. This adds validation to the user's input also set what's the proper data type for the control. If this is unset to program will use the default data type which is string.
    Public Function GenerateUpdateScript(ByVal _container As System.Windows.Forms.Control, ByVal _trimstr As Integer, ByVal _tbl As String, ByVal _criteria As String)
        Dim ctr As System.Windows.Forms.Control, retval As String = ""
        For Each ctr In _container.Controls
            If ctr.Tag = 1 Then
                If TypeOf (ctr) Is DevExpress.XtraEditors.DateEdit Then
                    If CType(ctr, DevExpress.XtraEditors.DateEdit).EditValue Is Nothing Then
                        retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=NULL, "
                    Else
                        retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & ChangeToSQLDate(CType(CType(ctr, DevExpress.XtraEditors.DateEdit).EditValue, Date)) & ", "
                    End If
                ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                    If CType(ctr, DevExpress.XtraEditors.TextEdit).Properties.UseSystemPasswordChar Then
                        Dim str As String = CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue.ToString
                        retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & "'" & sysMpsUserPassword("ENCRYPT", str) & "', "
                    ElseIf TypeOf (CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue) Is String Then
                        Dim str As String = CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue.ToString.Replace("'", "''")
                        retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & If(ISUnicode(str), "N", "") & "'" & str & "', "
                    Else
                        retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue & ", "
                    End If
                ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Then
                    If CType(ctr, DevExpress.XtraEditors.CheckEdit).Checked Then
                        retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=1, "
                    Else
                        retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=0, "
                    End If
                End If
            End If
        Next
        If retval = "" Then
            Return ""
        Else
            Return "Update dbo." & _tbl & " set " & retval.Substring(0, retval.Length - 2) & " Where " & _criteria
        End If

    End Function

    'Utility create an update sql statement from a certain contnainer
    '_container - source of the controls, all of the controls that has an AddListener will be added.
    '_trimstr number of prefix to be removed on controls name. e.t.c txtLName the _trimstr will be set to 3 it will remove txt the leaves LName on the fields.
    '_tbl - the table name that will be used on Update statement.
    '_criteria - the criteria that will be used on Update statement.
    '_additionalfield - field you want to add on the insert statement.

    'Additional notes
    'If you intend to used this function make sure you properly set the control's name similar on the datasource. e.t.c data source LName you the name would be txtLName, cboLName, chkLName e.t.c and set the _trimstr to the number of prefix.
    'If you're using DevExpress's TextEdit make sure you set the Masking property. This adds validation to the user's input also set what's the proper data type for the control. If this is unset to program will use the default data type which is string.    
    Public Function GenerateUpdateScript(ByVal _container As System.Windows.Forms.Control, ByVal _trimstr As Integer, ByVal _tbl As String, ByVal _additionalfield As String, ByVal _criteria As String)
        Dim ctr As System.Windows.Forms.Control, retval As String = ""
        For Each ctr In _container.Controls
            If ctr.Tag = 1 Then
                If TypeOf (ctr) Is DevExpress.XtraEditors.DateEdit Then
                    If CType(ctr, DevExpress.XtraEditors.DateEdit).EditValue Is System.DBNull.Value Or CType(ctr, DevExpress.XtraEditors.DateEdit).EditValue Is Nothing Then
                        retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & " Null, "
                    Else
                        retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & ChangeToSQLDate(CType(CType(ctr, DevExpress.XtraEditors.DateEdit).EditValue, Date)) & ", "
                    End If
                ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                    If CType(ctr, DevExpress.XtraEditors.TextEdit).Properties.UseSystemPasswordChar Then
                        Dim str As String = CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue.ToString
                        retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & "'" & sysMpsUserPassword("ENCRYPT", str) & "', "
                    ElseIf TypeOf (CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue) Is String Then
                        Dim str As String = CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue.ToString.Replace("'", "''")
                        retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & If(ISUnicode(str), "N", "") & "'" & str & "', "
                    Else
                        retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue & ", "
                    End If
                ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Then
                    If CType(ctr, DevExpress.XtraEditors.CheckEdit).Checked Then
                        retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=1, "
                    Else
                        retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=0, "
                    End If
                End If
            End If
        Next
        If retval = "" Then
            Return "Update dbo." & _tbl & " set " & _additionalfield & " Where " & _criteria
        Else
            Return "Update dbo." & _tbl & " set " & retval & _additionalfield & " Where " & _criteria
        End If
    End Function

    'Utility create an insert sql statement from a certain contnainer
    '_container - source of the controls, all of the controls that has an AddListener will be added.
    '_trimstr number of prefix to be removed on controls name. e.t.c txtLName the _trimstr will be set to 3 it will remove txt the leaves LName on the fields.
    '_tbl - the table name that will be used on insert statement.
    '_additionalfield - field you want to add on the insert statement.
    '_additionalfieldval - value of the field you want to add on the insert statement.

    'Additional notes
    'If you intend to used this function make sure you properly set the control's name similar on the datasource. e.t.c data source LName you the name would be txtLName, cboLName, chkLName e.t.c and set the _trimstr to the number of prefix.
    'If you're using DevExpress's TextEdit make sure you set the Masking property. This adds validation to the user's input also set what's the proper data type for the control. If this is unset to program will use the default data type which is string.
    Public Function GenerateInsertScript(ByVal _container As System.Windows.Forms.Control, ByVal _trimstr As Integer, ByVal _tbl As String, ByVal _additionalfield As String, ByVal _additionalfieldval As String)
        Dim ctr As System.Windows.Forms.Control, fields As String = "", values As String = ""
        For Each ctr In _container.Controls
            If ctr.Tag = 1 Then
                If TypeOf (ctr) Is DevExpress.XtraEditors.DateEdit Then
                    fields = fields & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "], "
                    values = values & ChangeToSQLDate(CType(CType(ctr, DevExpress.XtraEditors.DateEdit).EditValue, Date)) & ", "
                ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                    If CType(ctr, DevExpress.XtraEditors.TextEdit).Properties.UseSystemPasswordChar Then
                        fields = fields & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "], "
                        Dim str As String = CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue.ToString
                        values = values & "'" & sysMpsUserPassword("ENCRYPT", str) & "', "
                    ElseIf TypeOf (CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue) Is String Then
                        fields = fields & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "], "
                        Dim str As String = CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue.ToString.Replace("'", "''")
                        values = values & If(ISUnicode(str), "N", "") & "'" & str & "', "
                    Else
                        fields = fields & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "], "
                        values = values & CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue & ", "
                    End If
                ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Then
                    If CType(ctr, DevExpress.XtraEditors.CheckEdit).Checked Then
                        fields = fields & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "], "
                        values = values & "1, "
                    Else
                        fields = fields & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "], "
                        values = values & "0, "
                    End If
                End If
            End If
        Next
        If fields = "" Then
            Return ""
        Else
            Return "Insert Into dbo." & _tbl & "(" & _additionalfield & ", " & fields.Substring(0, fields.Length - 2) & ") values(" & _additionalfieldval & ", " & values.Substring(0, values.Length - 2) & ")"
        End If
    End Function

    Public Function FormatVersion(ByVal bToString As Boolean, ByVal value As Object) As Object
        If bToString Then
            Dim strTemp As String = value.ToString
            If strTemp.Length = 5 Then strTemp = "0" & strTemp
            Return strTemp.Substring(0, 2) + "." + strTemp.Substring(2, 2) + "." + strTemp.Substring(4, 2)
        Else
            Dim param() As String = value.ToString.Split(".")
            Return CType(param(0) & CInt(param(1)).ToString("00") & CInt(param(2)).ToString("00"), Integer)
        End If
        Return 0
    End Function

    'A simple encryption functions that just shuffle the characters to prevents the increase of file size.
    Public Function Shuffle(ByVal str As String, ByVal bExp As Boolean) As String
        Dim OrigString As String = EXPIMPCHARACTERS.Substring(0, 90), NewString As New System.Text.StringBuilder, nSlice As Integer, cnt As Integer
        Dim RetvalBuilder As New System.Text.StringBuilder, RetVal As String
        Dim any_int_val As Int16
        If bExp Then
            Randomize()
            any_int_val = CType(1 + Int(Rnd() * 9), Integer)
            nSlice = CType(2 + Int(Rnd() * 5), Integer)
            If nSlice = 4 Then nSlice = 9 '90 is not divisible by 4
            RetvalBuilder.Append(String.Format("{0}{1}", EXPIMPCHARACTERS.Substring(any_int_val, 1), EXPIMPCHARACTERS.Substring(nSlice, 1)))
            While OrigString.Length > 0
                NewString.Append(StrReverse(OrigString.Substring(0, nSlice)))
                OrigString = OrigString.Remove(0, nSlice)
            End While
            NewString.Append(EXPIMPCHARACTERS.Substring(90, 5))
            OrigString = EXPIMPCHARACTERS
            For cnt = 0 To str.Length - 1
                Dim nPos As Integer = -1
                nPos = OrigString.IndexOf(str.Substring(cnt, 1))
                If nPos >= 0 Then
                    RetvalBuilder.Append(NewString.Chars(nPos))
                Else
                    RetvalBuilder.Append(str.Substring(cnt, 1))
                End If
            Next
            RetvalBuilder.Append(10 - any_int_val)
            RetVal = StrReverse(RetvalBuilder.ToString)
        Else
            str = StrReverse(str)
            nSlice = CType(EXPIMPCHARACTERS.IndexOf(str.Substring(1, 1)), Integer)
            str = str.Substring(2, str.Length - 3)
            While OrigString.Length > 0
                NewString.Append(StrReverse(OrigString.Substring(0, nSlice)))
                OrigString = OrigString.Remove(0, nSlice)
            End While
            NewString.Append(EXPIMPCHARACTERS.Substring(90, 5))
            OrigString = EXPIMPCHARACTERS
            For cnt = 0 To str.Length - 1
                Dim nPos As Integer = -1
                nPos = NewString.ToString.IndexOf(str.Substring(cnt, 1))
                If nPos >= 0 Then
                    RetvalBuilder.Append(OrigString.Chars(nPos))
                Else
                    RetvalBuilder.Append(str.Substring(cnt, 1))
                End If
            Next
            RetVal = RetvalBuilder.ToString
        End If
        Return RetVal
    End Function

    Public Function ViewLog(strFile As String) As String
        Dim sr As New System.IO.StreamReader(strFile)
        Dim strLine As String, retVal As String = ""
        While Not sr.EndOfStream
            strLine = sr.ReadLine
            retVal = retVal & Shuffle(strLine, False)
        End While
        sr.Close()
        sr.Dispose()
        System.Windows.Forms.Application.DoEvents()
        Return retVal
    End Function


    'Public Sub LogErrors(ErrMsg As String)
    '    Dim strFileName As String
    '    If Not System.IO.Directory.Exists(GetAppPath() & "\Errors") Then
    '        MkDir(GetAppPath() & "\Errors")
    '    End If
    '    strFileName = GetAppPath() & "\Errors" & "\Error_" & Now.ToString("yyyyMMdd") & ".txt"
    '    Using sw As New System.IO.StreamWriter(strFileName, True)
    '        sw.Write(ErrMsg)
    '    End Using
    'End Sub    

    Public Function IntTOHour(ByVal nHour As Integer) As String
        Return (nHour \ 2).ToString("00") & ":" & IIf(nHour Mod 2 = 0, "00", "30")
    End Function

    Public Function ChangeToExportString(ByVal strText As Object) As String
        If strText Is System.DBNull.Value Then
            Return "NULL"
        Else
            Return "'" & strText & "'"
        End If
    End Function

    Public Function ChangeToExportDate(ByVal nDate As Object) As String
        If nDate Is System.DBNull.Value Then
            Return "NULL"
        Else
            Return ChangeToSQLDate(CDate(nDate))
        End If
    End Function

    Public Function ResizeImageByHeight(ByVal image As Image, newHeight As Int16) As Image
        Dim newWidth As Integer
        Dim originalWidth As Integer = image.Width
        Dim originalHeight As Integer = image.Height
        newWidth = CInt(image.Width * newHeight / image.Height)
        Dim newImage As Image = New Bitmap(newWidth, newHeight)
        Using graphicsHandle As Graphics = Graphics.FromImage(newImage)
            graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic
            graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight)
        End Using
        Return newImage
    End Function

    'Send email using the WRH Email Account saved in tblSTIService_internet_settings
    Public Function SendEmail(INET_Host As String, INET_Port As Integer, INET_User As String, INET_Pwd As String, INET_UseSSL As Boolean, INET_TLS As Boolean, strEmailFrom As String, strEmailTo As String, ByVal subject As String, ByVal body As String) As Boolean
        Try
            Dim smtp As New Chilkat.MailMan, email As New Chilkat.Email
            If smtp.UnlockComponent("SPCTASMAILQ_8962DBBgnC9s") Then
                smtp.SmtpHost = INET_Host
                smtp.SmtpPort = INET_Port
                smtp.SmtpUsername = INET_User
                smtp.SmtpPassword = INET_Pwd
                smtp.ConnectTimeout = 60
                smtp.SmtpSsl = INET_UseSSL
                smtp.StartTLS = INET_TLS
                email.AddTo("SM Office Email Address", strEmailTo)
                email.From = strEmailFrom
                email.Subject = subject
                email.Body = body
                If smtp.SendEmail(email) Then
                    smtp.CloseSmtpConnection()
                    Return True
                Else
                    LogErrors("Send Email Error: " & smtp.LastErrorText)
                    smtp.CloseSmtpConnection()
                    Return False
                End If
            Else
                LogErrors("Send Email Error: " & smtp.LastErrorText)
                Return False
            End If
        Catch ex As Exception
            LogErrors("Send Email Error: " & ex.Message)
            Return False
        End Try
    End Function

    'Send email using the WRH Email Account saved in tblSTIService_internet_settings
    Public Function SendEmail(INET_Host As String, INET_Port As Integer, INET_User As String, INET_Pwd As String, INET_UseSSL As Boolean, INET_TLS As Boolean, strEmailFrom As String, strEmailTo As String, strReplyTo As String, strCC As String, ByVal subject As String, ByVal body As String) As Boolean
        Try
            Dim smtp As New Chilkat.MailMan, email As New Chilkat.Email
            If smtp.UnlockComponent("SPCTASMAILQ_8962DBBgnC9s") Then
                smtp.SmtpHost = INET_Host
                smtp.SmtpPort = INET_Port
                smtp.SmtpUsername = INET_User
                smtp.SmtpPassword = INET_Pwd
                smtp.ConnectTimeout = 60
                smtp.SmtpSsl = INET_UseSSL
                smtp.StartTLS = INET_TLS
                email.AddMultipleTo(strEmailTo)
                email.From = strEmailFrom
                If strReplyTo <> "" Then email.ReplyTo = strReplyTo
                If strCC <> "" Then email.AddMultipleCC(strCC)
                email.Subject = subject
                email.Body = body
                If smtp.SendEmail(email) Then
                    smtp.CloseSmtpConnection()
                    Return True
                Else
                    LogErrors("Send Email Error: " & smtp.LastErrorText)
                    smtp.CloseSmtpConnection()
                    Return False
                End If
            Else
                LogErrors("Send Email Error: " & smtp.LastErrorText)
                Return False
            End If
        Catch ex As Exception
            LogErrors("Send Email Error: " & ex.Message)
            Return False
        End Try
    End Function

End Module
