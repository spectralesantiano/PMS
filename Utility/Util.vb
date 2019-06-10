Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Module Util

    Public USE_SPECTRAL_CON As Boolean = True, USE_TRUSTED_CON As Boolean, SQL_SERVER As String, SQL_USER_NAME As String, SQL_PASSWORD As String
    Public VERSION_NUMBER As String, VERSION_DATE As Date, HDD_ID As String
    Public Declare Function GetWindowThreadProcessId Lib "user32.dll" (ByVal hWnd As IntPtr, ByRef lpdwProcessId As Integer) As Integer
    Public Declare Function FindWindow Lib "user32.dll" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
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
    Public APP_PATH As String, DATE_LAST_EXPORT As String = "2000-01-01", SHORE_ID As String
    Private ReadOnly EXPIMPCHARACTERS As String = "d3]c)Q-I|@%^&*_+=efghij0k:lno(p8qrs`tuv}w{[;'x2yzAB>C9.,<?DbEF!G6$H5J KL#MN/O7PaR""STUVWXYZ~1\m4"
    Public GRID_ROW_SEP As Byte = 0, LOGO As Bitmap
    Public CURRENT_DEPARTMENT As String, CURRENT_RANK As String, CURRENT_MAINUNIT As String, CURRENT_CATEGORY As String, CURRENT_UNIT As String = "", CURRENT_WORK As Integer, CURRENT_DUEDAYS As String, CURRENT_DUEHOURS As Integer, CURRENT_PERIOD As Integer, CURRENT_WOMAINTENANCE As Boolean = False, CURRENT_CONDITION_CHECKED As Boolean = False
    Public AdmRank As DataTable, AdmDept As DataTable
    Public Const APP_SHORT_NAME = "PMS"

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

            ccolumn = New DataColumn
            ccolumn.ColumnName = "Selected"
            ccolumn.DataType = System.Type.GetType("System.Boolean")
            ctable.Columns.Add(ccolumn)

            For Each strTemp In strFileText.Split(Environment.NewLine)
                strTemp = strTemp.Replace(vbLf, "")
                If strTemp <> "" Then
                    Dim crow() As Object = {strTemp, True}
                    ctable.Rows.Add(crow)
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

        ccolumn = New DataColumn
        ccolumn.ColumnName = "Selected"
        ccolumn.DataType = System.Type.GetType("System.Boolean")
        ctable.Columns.Add(ccolumn)

        For Each strTemp In strFromClip.Split(Environment.NewLine)
            strTemp = strTemp.Replace(vbLf, "")
            If strTemp <> "" Then
                Dim crow() As Object = {strTemp, True}
                ctable.Rows.Add(crow)
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

    Public Function StreamToString(stream As System.IO.MemoryStream) As String
        stream.Position = 0
        Using sr As New System.IO.StreamReader(stream, System.Text.Encoding.UTF8)
            Return sr.ReadToEnd
        End Using
    End Function

    Public Function StringToStream(strStream As String) As System.IO.MemoryStream
        Dim arrByte As Byte() = System.Text.Encoding.UTF8.GetBytes(strStream)
        Return New System.IO.MemoryStream(arrByte)
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

    Public Function RemoveInvalidFileNameChars(ByVal path As String)
        Dim c As Char, invalidChar As String = System.IO.Path.GetInvalidFileNameChars()
        For Each c In invalidChar
            path = path.Replace(c.ToString(), "")
        Next
        Return path
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

    Public Function GetDaysOfMonth(ByVal dDate As Date) As Integer
        dDate = DateAdd(DateInterval.Month, 1, dDate)
        Return Day(DateAdd(DateInterval.Day, -1, NumCodeToDate(CType(Year(dDate).ToString("0000") & Month(dDate).ToString("00"), Integer), 1)))
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


    Public Function ISUnicode(ByVal str As String) As Boolean
        Dim c As Integer
        For c = 0 To str.Length - 1
            If AscW(str.Chars(c)) > 255 Then
                Return True
            End If
        Next
        Return False
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
