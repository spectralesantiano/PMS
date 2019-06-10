Imports System.Configuration
Imports System.Security.AccessControl

Public Module mdLicense

    'initializations
    Public wrhsm5_app As New Working_App("WRHSM5", "sm5_db", GetAppFolder() & "License Logs\WRHSM5", "C:\Program Files\Common Files\STI_WSM5Lic.lic", "sys_wsm5_g_p")

#Region "Base Functions"

    'validate physical License file
    Public Function xValidateLicense(ByVal cApp As Working_App, ByVal ServerLicenseType As String, ByRef returnLicense As MyLicense, Optional ByVal strLogFile As String = "", Optional createLog As Boolean = False) As MyLicenseStatus
        Dim returnLicenseStatus As New MyLicenseStatus
        Dim bSuccess As Boolean = True

        Dim dbName As String = cApp.App_DbName
        Dim MyLicenseFilePath As String = cApp.App_LicensePath

        Dim ComputerInfo As New mdComputerInfo
        Dim myHID As String = ComputerInfo.GetHardwareID
        HDD_ID = myHID
        Dim current_date As Integer = getServerDate()

        returnLicenseStatus.LicenseType = ServerLicenseType

        Log_Append(cApp, "********************* Start *********************" & vbNewLine, strLogFile, createLog)

        Select Case ServerLicenseType

            Case "TRIAL"

                Log_Append(cApp, "LICENSE TYPE: TRIAL LICENSE", strLogFile, createLog)
                bSuccess = xGetLicenseFromServer(dbName, returnLicense, "LType='TRIAL'", returnLicenseStatus.ErrMsg)
                Log_Append(cApp, "GETTING LICENSE INFORMATION -- " & IIf(bSuccess, "OK", "NO TRIAL LICENSE IN THE SERVER"), strLogFile, createLog)

                If Not bSuccess And returnLicense.LType <> "TRIAL" Then
                    returnLicenseStatus.StrLicenseMsg = "No trial license in the server."
                    returnLicenseStatus.ExpDays = 0
                    GoTo ReturnLine
                End If

                If returnLicense.LExp = "NULL" And returnLicense.LType = "TRIAL" Then
                    'first run
                    bSuccess = UpdateLicense(dbName, returnLicense.LID, "[LExp],[LStat],[LValid]", ServerAddDays(30).ToString & ",VALID," & getServerDateTime.ToString)
                    returnLicenseStatus.ExpDays = 30
                Else
                    'check expDays
                    If returnLicense.LStat = "VALID" Then
                        Log_Append(cApp, "LICENSE STATUS: VALID", strLogFile, createLog)

                        'check datetime if tampered
                        bSuccess = isDateTimeTampered(dbName, returnLicense, returnLicenseStatus)
                        If bSuccess Then
                            GoTo ReturnLine
                        End If

                        'validate trial license
                        Try
                            returnLicenseStatus.ExpDays = ServerDateDiff(returnLicense.LExp)
                            Log_Append(cApp, "LICENSE EXPIRY: --" & returnLicense.LExp, strLogFile, createLog)
                        Catch ex As Exception
                            returnLicenseStatus.StrLicenseMsg = "Cannot Evaluate License Expiry."
                            Log_Append(cApp, "LICENSE EXPIRY: -- CANNOT EVALUATE", strLogFile, createLog)
                            returnLicenseStatus.ExpDays = 0
                        End Try

                        If returnLicenseStatus.ExpDays > 30 Then
                            returnLicenseStatus.StrLicenseMsg = "Trial License expiry days exceed in 30 days. License expired!."
                            returnLicenseStatus.ErrMsg = "TRIAL LICENSE FORCE EXPIRED"
                            returnLicenseStatus.ExpDays = 0
                            Log_Append(cApp, returnLicenseStatus.StrLicenseMsg & returnLicenseStatus.ErrMsg, strLogFile, createLog)
                            GoTo ReturnLine
                        End If

                    ElseIf returnLicense.LStat = "EXPIRED" Then
                        Log_Append(cApp, "LICENSE STATUS: EXPIRED", strLogFile, createLog)
                        returnLicenseStatus.ExpDays = 0
                    Else
                        Log_Append(cApp, "LICENSE STATUS: INVALID STATUS", strLogFile, createLog)
                        returnLicenseStatus.StrLicenseMsg = "INVALID Trial License."
                        returnLicenseStatus.ExpDays = 0
                    End If
                End If

            Case "NETWORK"

                bSuccess = xGetLicenseFromServer(dbName, returnLicense, "LType='NETWORK'", returnLicenseStatus.ErrMsg)

                If Not bSuccess Then
                    returnLicenseStatus.StrLicenseMsg = "No network license in the server."
                    returnLicenseStatus.ExpDays = 0
                    GoTo ReturnLine
                End If

                'check datetime if tampered
                bSuccess = isDateTimeTampered(dbName, returnLicense, returnLicenseStatus)
                If bSuccess Then
                    GoTo ReturnLine
                End If

                'check last msg status
                If Not returnLicense.LMsg = "LICENSE IS VALID" Then
                    returnLicenseStatus.StrLicenseMsg = returnLicense.LMsg
                    GoTo ReturnLine
                End If

                'check last updated
                Dim dateLastUpdated As String = returnLicense.LDateUpdated

                Dim noDays As Integer = 0

                Try
                    noDays = getServerDate() - CInt(dateLastUpdated)
                Catch ex As Exception
                    noDays = 0
                End Try

                If noDays >= 5 Then
                    returnLicenseStatus.StrLicenseMsg = "License need to be evaluated. Please check Spectral License Service App."
                    returnLicenseStatus.ExpDays = 0
                    returnLicenseStatus.ErrMsg = "NETWORK LICENSE COMPROMISED"
                    GoTo ReturnLine
                End If

                'evaluate license status
                If Not (returnLicense.LStat = "VALID" Or returnLicense.LStat = "EXPIRED") Then
                    returnLicenseStatus.StrLicenseMsg = "Cannot Evaluate License Status."
                    GoTo ReturnLine
                ElseIf returnLicense.LStat = "EXPIRED" Then
                    returnLicenseStatus.ExpDays = 0
                    GoTo ReturnLine
                End If

                'check date effectivity
                If Trim(returnLicense.LExp) = "" Then
                    returnLicenseStatus.StrLicenseMsg = "Cannot Evaluate License Expiry."
                    GoTo ReturnLine
                Else
                    'check expDays
                    Dim DExp As String

                    Try
                        DExp = returnLicense.LExp
                    Catch ex As Exception
                        returnLicenseStatus.StrLicenseMsg = "Invalid License Expiry."
                        GoTo ReturnLine
                    End Try

                    returnLicenseStatus.ExpDays = ServerDateDiff(DExp)

                    If returnLicenseStatus.ExpDays <= 0 Then
                        returnLicenseStatus.ExpDays = 0
                    End If

                End If

            Case "SINGLE"
                Log_Append(cApp, "SINGLE TYPE: SINGLE LICENSE", strLogFile, createLog)

                bSuccess = xReadLicenseFile(MyLicenseFilePath, returnLicense, True, returnLicenseStatus.ErrMsg)

                If bSuccess And returnLicenseStatus.ErrMsg = "" Then 'success reading the local file
                    Log_Append(cApp, "READING LICENSE FILE -- OK", strLogFile, createLog)
                    'get Local File Serial Key
                    Dim strLocalSKey As String = returnLicense.LSKey
                    'get Local File HID 
                    Dim strLocalHID As String = returnLicense.LHID

                    'fetch license from server
                    bSuccess = xGetLicenseFromServer(dbName, returnLicense, "LSKey='" & strLocalSKey & "'", returnLicenseStatus.ErrMsg)
                    Log_Append(cApp, "MATCHING LICENSE DETAILS FROM THE SERVER -- " & IIf(bSuccess, "OK", "NO MATCH"), strLogFile, createLog)
                    If Not bSuccess Then
                        returnLicenseStatus.StrLicenseMsg = "You do not have valid license in the server."
                        returnLicenseStatus.ExpDays = 0
                        GoTo ReturnLine
                    End If

                    'check datetime if tampered
                    bSuccess = isDateTimeTampered(dbName, returnLicense, returnLicenseStatus)
                    If bSuccess Then
                        GoTo ReturnLine
                    End If

                    'compare HIDS
                    'first: DatabasedHID to LocalFileHID
                    If isMatch(returnLicense.LHID, strLocalHID) Then
                        'second: DatabasedHID to CurrentHID
                        If Not isMatch(returnLicense.LHID, myHID) Then
                            returnLicenseStatus.StrLicenseMsg = "Hardware ID changed."
                            Log_Append(cApp, "MATCHING HARDWARE ID: -- " & returnLicenseStatus.StrLicenseMsg, strLogFile, createLog)
                            GoTo ReturnLine
                        Else
                            Log_Append(cApp, "MATCHING HARDWARE ID: -- OK", strLogFile, createLog)
                        End If
                    Else
                        returnLicenseStatus.StrLicenseMsg = "Hardware ID doesn't match."
                        Log_Append(cApp, "MATCHING HARDWARE ID: -- " & returnLicenseStatus.StrLicenseMsg, strLogFile, createLog)
                        GoTo ReturnLine
                    End If

                    'evaluate license status
                    If Not (returnLicense.LStat = "VALID" Or returnLicense.LStat = "EXPIRED") Then
                        returnLicenseStatus.StrLicenseMsg = "Cannot Evaluate License Status."
                        Log_Append(cApp, "EVALUATING LICENSE STATUS: -- " & returnLicenseStatus.StrLicenseMsg, strLogFile, createLog)
                        GoTo ReturnLine
                    ElseIf returnLicense.LStat = "EXPIRED" Then
                        returnLicenseStatus.ExpDays = 0
                        Log_Append(cApp, "EVALUATING LICENSE STATUS: -- EXPIRED", strLogFile, createLog)
                        GoTo ReturnLine
                    End If

                    'check date effectivity
                    If Trim(returnLicense.LExp) = "" Then
                        returnLicenseStatus.StrLicenseMsg = "Cannot Evaluate License Expiry."
                        Log_Append(cApp, "EVALUATING LICENSE EXPIRY: -- " & returnLicenseStatus.StrLicenseMsg, strLogFile, createLog)
                        GoTo ReturnLine
                    Else
                        'check expDays
                        Dim DExp As String

                        Try
                            DExp = returnLicense.LExp
                            Log_Append(cApp, "EVALUATING LICENSE EXPIRY: -- " & returnLicense.LExp, strLogFile, createLog)
                        Catch ex As Exception
                            returnLicenseStatus.StrLicenseMsg = "Invalid License Expiry."
                            Log_Append(cApp, "EVALUATING LICENSE EXPIRY: -- " & returnLicenseStatus.StrLicenseMsg, strLogFile, createLog)
                            GoTo ReturnLine
                        End Try

                        returnLicenseStatus.ExpDays = ServerDateDiff(DExp)
                        If returnLicenseStatus.ExpDays <= 0 Then
                            returnLicenseStatus.ExpDays = 0
                        End If
                    End If

                Else
                    'no local license file
                    Log_Append(cApp, "READING LICENSE FILE -- Unable to read license file." & returnLicenseStatus.ErrMsg, strLogFile, createLog)
                    returnLicenseStatus.StrLicenseMsg = "Unable to read license file."
                End If

            Case Else
                returnLicenseStatus.LicenseType = "NO LICENSE"
                returnLicenseStatus.StrLicenseMsg = "Unable to evaluate License Type."
        End Select

ReturnLine:
        Log_Append(cApp, "", strLogFile, createLog)
        Log_Append(cApp, "********************* End *********************", strLogFile, createLog)

        Return returnLicenseStatus
    End Function

    'evaluate License status
    Public Sub EvaluateMyLicense(ByVal dbName As String, ByVal bak_gPeriod As String, ByRef Mylicense As MyLicense, ByRef MyLicenseStatus As MyLicenseStatus)
        Dim bSuccess As Boolean = True
        Dim gPeriod As Integer

        If MyLicenseStatus.StrLicenseMsg <> "" Then ' there's something went wrong upon validation

            If Mylicense.LType = "NETWORK" Then
                gPeriod = GetGPeriodNetwork(dbName, Mylicense)
            Else
                gPeriod = GetGPeriod(dbName, Mylicense, bak_gPeriod)
            End If

            MyLicenseStatus.ExpDays = ServerDateDiff(gPeriod.ToString)

            If MyLicenseStatus.ExpDays > 10 Then
                MyLicenseStatus.ExpDays = 0
                MyLicenseStatus.StrLicenseMsg = "LICENSE FORCED TO EXPIRED."
                MyLicenseStatus.ErrMsg = "Grace Period exceeded in 10 days."
            End If
        Else ' valid license
            'a valid license expired
            If MyLicenseStatus.ExpDays <= 0 Then
                bSuccess = UpdateLicense(dbName, Mylicense.LID, "[LStat]", "EXPIRED")
            Else
                bSuccess = UpdateLicense(dbName, Mylicense.LID, "[LValid]", getServerDateTime.ToString)
            End If
        End If

        'Update License Row
        If Mylicense.LType = "NETWORK" Or Mylicense.LType = "SINGLE" Then
            Dim xCol As String = ""
            Dim xColVal As String = ""

            xCol = "[LStat],[LMsg]"
            xColVal = IIf(MyLicenseStatus.ExpDays > 0, "VALID", "EXPIRED")
            xColVal = xColVal & "," & IIf(MyLicenseStatus.StrLicenseMsg <> "", MyLicenseStatus.StrLicenseMsg, "LICENSE IS VALID")
            bSuccess = UpdateLicense(dbName, Mylicense.LID, xCol, xColVal)

        End If

    End Sub

    'get Grace Period
    Public Function GetGPeriod(ByVal dbName As String, ByVal Mylicense As MyLicense, ByVal BackUpReg As String) As Integer
        Dim r As Integer
        Dim strGPeriod As String = ""
        Try
            If Mylicense.LGPeriod = "10" Then 'not yet set, first encouter of error
                strGPeriod = ServerAddDays(10).ToString
                UpdateLicense(dbName, Mylicense.LID, "[LGPeriod]", strGPeriod)
                WriteReg(BackUpReg, strGPeriod, True)
            Else ' set
                Try
                    strGPeriod = Mylicense.LGPeriod
                    r = CInt(strGPeriod)
                    If Not isNumDate(r) Then
                        strGPeriod = getServerDate.ToString()
                    End If
                Catch ex As Exception
                    strGPeriod = GetReg(BackUpReg, True)
                    If strGPeriod = "" Then ' no backupreg
                        strGPeriod = getServerDate().ToString ' set to current date
                        r = CInt(strGPeriod)
                    ElseIf strGPeriod = "10" Then
                        strGPeriod = ServerAddDays(10).ToString
                        WriteReg(BackUpReg, strGPeriod, True)
                    Else
                        Try
                            r = CInt(strGPeriod)
                            If Not isNumDate(r) Then
                                strGPeriod = getServerDate.ToString()
                            End If
                        Catch exs As Exception
                            strGPeriod = getServerDate.ToString()
                        End Try
                    End If
                End Try
            End If
        Catch ex As Exception
            'on error return current_date as integer 
            strGPeriod = getServerDate.ToString()
        End Try

        r = CInt(strGPeriod)

        Return r
    End Function

    'get Grace Period of Network License
    Public Function GetGPeriodNetwork(ByVal dbName As String, ByVal Mylicense As MyLicense) As Integer
        Dim r As Integer
        Dim strGPeriod As String = ""
        Try
            If Mylicense.LGPeriod = "10" Then 'not yet set, first encouter of error
                strGPeriod = ServerAddDays(10).ToString
                UpdateLicense(dbName, Mylicense.LID, "[LGPeriod]", strGPeriod)
            Else ' set
                Try
                    strGPeriod = Mylicense.LGPeriod
                    r = CInt(strGPeriod)
                    If Not isNumDate(r) Then
                        r = getServerDate()
                    End If
                Catch ex As Exception
                    r = getServerDate()
                End Try
            End If
        Catch ex As Exception
            'on error return current_date as integer
            r = getServerDate()
        End Try

        Return r
    End Function

    'read physical license file
    Public Function xReadLicenseFile(ByVal xPath As String, ByRef outputLicense As MyLicense, Optional ByVal DecryptValues As Boolean = True, Optional ByRef ErrMsg As String = "") As Boolean
        Dim lst As New List(Of String)
        Dim r As Boolean
        Try

            If Not System.IO.File.Exists(xPath) Then
                r = False
                ErrMsg = "No License File Found."
                Return r
                Exit Function
            End If

            Using sw As System.IO.StreamReader = New System.IO.StreamReader(xPath)
                Dim line As String = ""

                line = sw.ReadLine

                ' Loop over each line in file, While list is Not Nothing.
                Do While (Not line Is Nothing)
                    ' Add this line to list.
                    If DecryptValues Then
                        lst.Add(sysMpsUserPassword("DECRYPT", line))
                    Else
                        lst.Add(line)
                    End If

                    ' Read in the next line.
                    line = sw.ReadLine
                Loop

            End Using

            'convert List of string into License
            If lst.Count = 13 Then
                outputLicense.LID = ""
                outputLicense.LAppName = lst(0)
                outputLicense.LType = lst(1)
                outputLicense.LExp = lst(2)
                outputLicense.LHID = lst(3)
                outputLicense.LImo = lst(4)
                outputLicense.LSKey = lst(5)
                outputLicense.LGPeriod = lst(6)
                outputLicense.LNum = lst(7)
                outputLicense.LValid = lst(8)
                outputLicense.LGen = lst(9)
                outputLicense.LStat = lst(10)
                outputLicense.LMsg = lst(11)
                outputLicense.LRem = lst(12)
                outputLicense.LPath = xPath
                r = True
            Else
                ErrMsg = "Invalid License File." & vbNewLine & vbNewLine & "Please check format."
                r = False
            End If

        Catch ex As Exception
            ErrMsg = "An error occurred reading the license file." & vbNewLine & vbNewLine & ex.Message
            r = False
        End Try
        Return r
    End Function


    'search for a license
    Public Function xGetLicenseFromServer(ByVal dbName As String, ByRef xLicense As MyLicense, Optional ByVal cWhere As String = "", Optional ByRef ErrMsg As String = "") As Boolean
        Dim r As Boolean = False
        Dim dt As New DataTable
        Try
            dt = xLicensesToDatatable(dbName, ErrMsg)
            For Each rw As DataRow In dt.Select(cWhere)
                xLicense.LID = rw("LID")
                xLicense.LAppName = rw("LAppName")
                xLicense.LType = rw("LType")
                xLicense.LExp = rw("LExp")
                xLicense.LHID = rw("LHID")
                xLicense.LImo = rw("LImo")
                xLicense.LSKey = rw("LSKey")
                xLicense.LGPeriod = rw("LGPeriod")
                xLicense.LNum = rw("LNum")
                xLicense.LValid = rw("LValid")
                xLicense.LGen = rw("LGen")
                xLicense.LStat = rw("LStat")
                xLicense.LMsg = rw("LMsg")
                xLicense.LRem = rw("LRem")
                xLicense.LDateUpdated = rw("DateUpdatedFormated")
                r = True
                Exit For
            Next
        Catch ex As Exception
            r = False
            ErrMsg = ex.Message
        End Try
        Return r
    End Function

    'get all licenses in the server pass to datatable
    Public Function xLicensesToDatatable(ByVal dbName As String, Optional ByVal ErrMsg As String = "", Optional ByVal cWhere As String = "") As DataTable
        Dim dt As New DataTable

        Try
            dt = PMSDB.CreateTable("SELECT *, REPLACE(CONVERT(varchar(10),DateUpdated,120),'-','') AS DateUpdatedFormated FROM " & dbName & ".dbo.tblSTI")
            For Each row As DataRow In dt.Rows
                For Each col As DataColumn In dt.Columns
                    If col.ColumnName = "LID" Or col.ColumnName = "DateUpdated" Or col.ColumnName = "DateUpdatedFormated" Then

                    Else
                        Try
                            row(col.ColumnName) = sysMpsUserPassword("DECRYPT", row(col.ColumnName))
                        Catch ex As Exception
                        End Try
                    End If
                Next
            Next
            Return dt
        Catch ex As Exception
            Return dt
            ErrMsg = ex.Message
        End Try
    End Function

    'Save License details to database
    Public Function xSaveLicenseToDB(ByVal dbName As String, ByVal License As MyLicense, ByVal backReg_gp As String, ByRef msg As String) As Boolean
        xSaveLicenseToDB = False
        Dim strBuilder As New System.Text.StringBuilder
        Dim curr_strLicType As String
        Dim new_strLicType As String = sysMpsUserPassword("DECRYPT", License.LType)
        Dim bSuccess As Boolean = True
        msg = ""

        Try
            curr_strLicType = GetConfig(PMSDB, "LTYPE")
            curr_strLicType = sysMpsUserPassword("DECRYPT", curr_strLicType)

            If curr_strLicType = "SINGLE" And new_strLicType = "SINGLE" Then

                'check if Existing SKey

                'fetch license from server

                Dim fetchLicense As New MyLicense

                bSuccess = xGetLicenseFromServer(dbName, fetchLicense, "LSKey='" & sysMpsUserPassword("DECRYPT", License.LSKey) & "'")

                If bSuccess And fetchLicense.LID <> "" Then
                    'update
                    bSuccess = False
                    xSaveLicenseToDB = False
                    msg = "Cannot load license." & vbNewLine & vbNewLine & "License file already loaded!"
                Else
                    'insert
                    bSuccess = True
                    bSuccess = bSuccess And PMSDB.RunSql("INSERT INTO " & dbName & ".dbo.tblSTI (" & _
                                                   "[LAppName],[LType],[LExp],[LHID],[LImo],[LSKey],[LGPeriod],[LNum],[LValid],[LGen],[LStat],[LMsg],[LRem],[DateUpdated]) VALUES(" & _
                                                   "'" & License.LAppName & "','" & License.LType & "','" & License.LExp & "','" & License.LHID & "','" & License.LImo & "','" & License.LSKey & "','" & License.LGPeriod & "','" & License.LNum & "','" & sysMpsUserPassword("ENCRYPT", getServerDateTime()) & "','" & License.LGen & "','" & License.LStat & "','" & License.LMsg & "','" & License.LRem & "',GETDATE()" & _
                                                   ")")

                End If

                If bSuccess Then
                    bSuccess = True
                    bSuccess = CreateReg()
                    WriteReg(backReg_gp, "10")
                    xSaveLicenseToDB = True
                Else
                    xSaveLicenseToDB = False
                    If msg = "" Then
                        msg = "An error occurred loading the license file."
                    End If
                End If

            Else
                strBuilder.Append("This will overwrite your license from " & curr_strLicType & " to " & new_strLicType & " license.")
                strBuilder.AppendLine(vbNewLine & "Continue?")

                If MsgBox(strBuilder.ToString, 36) = MsgBoxResult.Yes Then
                    bSuccess = True
                    bSuccess = bSuccess And PMSDB.RunSql("DELETE FROM " & dbName & ".dbo.tblSTI")
                    bSuccess = bSuccess And PMSDB.RunSql("INSERT INTO " & dbName & ".dbo.tblSTI (" & _
                                                  "[LAppName],[LType],[LExp],[LHID],[LImo],[LSKey],[LGPeriod],[LNum],[LValid],[LGen],[LStat],[LMsg],[LRem],[DateUpdated]) VALUES(" & _
                                                  "'" & License.LAppName & "','" & License.LType & "','" & License.LExp & "','" & License.LHID & "','" & License.LImo & "','" & License.LSKey & "','" & License.LGPeriod & "','" & License.LNum & "','" & sysMpsUserPassword("ENCRYPT", getServerDateTime.ToString) & "','" & License.LGen & "','" & License.LStat & "','" & License.LMsg & "','" & License.LRem & "',GETDATE()" & _
                                                  ")")
                    If bSuccess Then
                        SaveConfig(PMSDB, "LTYPE", sysMpsUserPassword("ENCRYPT", new_strLicType))
                        bSuccess = True
                        bSuccess = CreateReg()
                        WriteReg(backReg_gp, "10")
                        xSaveLicenseToDB = True
                    Else
                        msg = "An error occurred loading the license file."
                        xSaveLicenseToDB = False
                    End If
                Else
                    msg = "Save Cancelled!"
                End If
            End If
        Catch ex As Exception
            msg = ex.Message
            xSaveLicenseToDB = False
        End Try
    End Function

    'check DateTime if altered
    Public Function isDateTimeTampered(ByVal dbName As String, ByVal License As MyLicense, ByRef LicenseStatus As MyLicenseStatus) As Boolean
        Dim r As Boolean = False
        Dim bSuccess As Boolean = False
        Dim curr_datetime As String
        Dim last_successval As String
        Dim LNUM As String
        Try
            LNUM = License.LNum

            'try to convert Last valid date to Datetime
            Try
                curr_datetime = getServerDateTime()
                last_successval = CStr(License.LValid)
            Catch ex As Exception
                LicenseStatus.StrLicenseMsg = "Error reading the last date success validated."
                GoTo ReturnL
            End Try

            If curr_datetime < last_successval Then
                'validate No of runs
                If LNUM <> "NULL" Then
                    'try to convert no of runs 
                    Dim noRuns As Integer
                    Try
                        noRuns = CType(LNUM, Integer)
                    Catch ex As Exception
                        noRuns = 0
                        LicenseStatus.ErrMsg = "Unable to evaluate remaining number of runs."
                    End Try

                    'validate no of runs
                    If ((noRuns > 0) And (noRuns < 10)) Then
                        Dim newRuns As Integer = noRuns - 1
                        bSuccess = UpdateLicense(dbName, License.LID, "[LNum]", newRuns.ToString)
                        If bSuccess Then
                            Log_Append(wrhsm5_app, wrhsm5_app.App_Name & " App status: " & newRuns.ToString & " run(s): Last success license validated: " & last_successval.ToString, , , True)
                            LicenseStatus.ExpDays = newRuns.ToString
                            LicenseStatus.StrLicenseMsg = "DATETIME TAMPERED ERROR"
                        Else
                            Log_Append(wrhsm5_app, wrhsm5_app.App_Name & " App status: error saving no of runs", , , True)
                            LicenseStatus.ExpDays = "0"
                            LicenseStatus.StrLicenseMsg = "DATETIME TAMPERED ERROR"
                        End If

                    ElseIf (noRuns <= 0) Then
                        LicenseStatus.ExpDays = "0"
                        LicenseStatus.StrLicenseMsg = "DATETIME TAMPERED ERROR"
                    Else
                        'excceded in 10 runs
                        LicenseStatus.ExpDays = "0"
                        LicenseStatus.StrLicenseMsg = "DATETIME TAMPERED ERROR"
                    End If

                    r = True
                    GoTo ReturnL
                Else
                    'date/time settings altered! first ecounter
                    bSuccess = UpdateLicense(dbName, License.LID, "[LNum]", "9")
                    If bSuccess Then
                        Log_Append(pms_app, "PMS App status: 9 runs: Last succes license validated: " & last_successval.ToString, , , True)
                        LicenseStatus.ExpDays = "9"
                        LicenseStatus.StrLicenseMsg = "DATETIME TAMPERED ERROR"
                    Else
                        Log_Append(pms_app, "PMS App status: error saving no of runs", , , True)
                        LicenseStatus.ExpDays = "0"
                        LicenseStatus.StrLicenseMsg = "DATETIME TAMPERED ERROR"
                    End If
                End If
                r = True
            Else
                'date/time is ok
                bSuccess = UpdateLicense(dbName, License.LID, "[LNum]", "NULL")
            End If
        Catch ex As Exception
            r = False
        End Try

ReturnL:
        Return r
    End Function

#End Region

#Region "Utils"

    Public Function getServerDate() As Integer
        Try
            PMSDB.BeginReader("SELECT REPLACE(CONVERT(varchar(10),GETDATE(),120),'-','') AS ServerDateTime")
            If PMSDB.Read() Then
                getServerDate = CInt(PMSDB.ReaderItem("ServerDateTime"))
            Else
                getServerDate = Nothing
            End If
            PMSDB.CloseReader()
        Catch ex As Exception
            PMSDB.CloseReader()
            getServerDate = Nothing
            MsgBox("ErrorgetServerDate: " & ex.Message)
        End Try

    End Function

    Public Function ServerAddDays(ByVal noDays As Integer) As Integer
        Try
            PMSDB.BeginReader("SELECT REPLACE(CONVERT(VARCHAR(10),DATEADD(day, " & noDays.ToString & ", GETDATE()),120),'-','') AS ServerDateTime")
            If PMSDB.Read() Then
                ServerAddDays = CInt(PMSDB.ReaderItem("ServerDateTime"))
                'ServerAddDays = Date.ParseExact(SMDB.ReaderItem("ServerDateTime"), "MM/dd/yyyy", MyCultureInfo)
            Else
                ServerAddDays = Nothing
            End If
            PMSDB.CloseReader()
        Catch ex As Exception
            PMSDB.CloseReader()
            ServerAddDays = Nothing
            MsgBox("ErrorServerAddDays: " & ex.Message)
        End Try
    End Function

    Public Function ServerDateDiff(ByVal nStart As String) As Integer
        Dim nRet As Integer = 0
        PMSDB.BeginReader("SELECT DATEDIFF(DAY, GETDATE(),'" & nStart & "' ) AS ServerDateTime")
        If PMSDB.Read() Then
            nRet = CType(PMSDB.ReaderItem("ServerDateTime"), Integer)
        Else
            nRet = 0
        End If
        PMSDB.CloseReader()
        Return nRet
    End Function

    Public Function getServerDateTime(Optional ByRef ErrMsg As String = "") As String
        Try
            PMSDB.BeginReader("SELECT REPLACE(CONVERT(varchar(10),GETDATE(),120),'-','') + REPLACE(SUBSTRING(CONVERT(VARCHAR, GETDATE(),108),1,8),':','') AS ServerDateTime")
            If PMSDB.Read() Then
                getServerDateTime = CStr(PMSDB.ReaderItem("ServerDateTime"))
            Else
                getServerDateTime = Nothing
            End If
            PMSDB.CloseReader()
        Catch ex As Exception
            PMSDB.CloseReader()
            ErrMsg = ex.Message
            getServerDateTime = Nothing
        End Try
    End Function

    Public Function DateToNum(ByVal paramDate As Date) As Integer
        Dim nRet As Integer = 0
        nRet = CInt(paramDate.Year.ToString("0000") & paramDate.Month.ToString("00") & paramDate.Day.ToString("00"))
        Return nRet
    End Function

    Public Function isNumDate(ByVal paramNum As Integer) As Boolean
        Dim bRet As Boolean = False
        Dim paramStr As String = ""
        If paramNum.ToString.Length = 8 Then
            paramStr = paramNum.ToString
            Try
                Dim newDate As New Date(CInt(paramStr.Substring(0, 4)), CInt(paramStr.Substring(4, 2)), CInt(paramStr.Substring(6, 2)))
                bRet = True
            Catch ex As Exception
                bRet = False
            End Try
        Else
            bRet = False
        End If
        Return bRet
    End Function

    'Compare HID
    Public Function isMatch(ByVal str1 As String, ByVal str2 As String) As Boolean
        If String.Compare(str1, str2, False) = 0 Then
            isMatch = True
        Else
            isMatch = False
        End If
    End Function

    'update License
    Public Function UpdateLicense(ByVal dbName As String, ByVal LID As String, ByVal columns As String, ByVal colValues As String) As Boolean
        Dim ret As Boolean = True
        Dim cols() As String = columns.Split(",")
        Dim colval() As String = colValues.Split(",")

        Dim strbuilder As New System.Text.StringBuilder
        Dim i As Integer = 0
        Try
            For i = 0 To cols.Length - 1
                If cols.Length - 1 = i Then
                    strbuilder.Append(cols(i) & "='" & sysMpsUserPassword("ENCRYPT", colval(i)) & "'")
                Else
                    strbuilder.Append(cols(i) & "='" & sysMpsUserPassword("ENCRYPT", colval(i)) & "',")
                End If
            Next

            ret = PMSDB.RunSql("UPDATE " & dbName & ".dbo.tblSTI SET " & strbuilder.ToString & ",DateUpdated=GETDATE() WHERE LID='" & LID & "'")
        Catch ex As Exception
            ret = False
        End Try
        Return ret
    End Function

    'Get/Save license to registry
    Public Function BackupLicenseReg(ByVal strAction As String, ByVal App_Name As String, ByVal AppRegKey As String, ByRef xLicense As MyLicense) As Boolean
        Dim r As Boolean = False
        Try
            Select Case strAction

                Case "GET"
                    xLicense.LAppName = GetReg(AppRegKey & "lappname", False)
                    xLicense.LType = GetReg(AppRegKey & "ltype", False)
                    xLicense.LExp = GetReg(AppRegKey & "lexp", False)
                    xLicense.LHID = GetReg(AppRegKey & "lhid", False)
                    xLicense.LImo = GetReg(AppRegKey & "limo", False)
                    xLicense.LSKey = GetReg(AppRegKey & "lskey", False)
                    xLicense.LGPeriod = GetReg(AppRegKey & "lgperiod", False)
                    xLicense.LNum = GetReg(AppRegKey & "lnum", False)
                    xLicense.LValid = GetReg(AppRegKey & "lvalid", False)
                    xLicense.LGen = GetReg(AppRegKey & "lgen", False)
                    xLicense.LStat = GetReg(AppRegKey & "lstat", False)
                    xLicense.LMsg = GetReg(AppRegKey & "lmsg", False)
                    xLicense.LRem = GetReg(AppRegKey & "lrem", False)
                    r = True

                Case "SET"
                    WriteReg(AppRegKey & "lappname", xLicense.LAppName, False)
                    WriteReg(AppRegKey & "ltype", xLicense.LType, False)
                    WriteReg(AppRegKey & "lexp", xLicense.LExp, False)
                    WriteReg(AppRegKey & "lhid", xLicense.LHID, False)
                    WriteReg(AppRegKey & "limo", xLicense.LImo, False)
                    WriteReg(AppRegKey & "lskey", xLicense.LSKey, False)
                    WriteReg(AppRegKey & "lgperiod", xLicense.LGPeriod, False)
                    WriteReg(AppRegKey & "lnum", xLicense.LNum, False)
                    WriteReg(AppRegKey & "lvalid", xLicense.LValid, False)
                    WriteReg(AppRegKey & "lgen", xLicense.LGen, False)
                    WriteReg(AppRegKey & "lstat", xLicense.LStat, False)
                    WriteReg(AppRegKey & "lmsg", xLicense.LMsg, False)
                    WriteReg(AppRegKey & "lrem", xLicense.LRem, False)
                    r = True
            End Select
        Catch ex As Exception
            r = False
        End Try

        Return r

    End Function

    'simple Checking of License
    Public Function isValidLicense(ByVal user_license As MyLicense) As Boolean
        Dim r As Boolean = False
        'check if all Properties have values
        If user_license.LType <> "" And _
            user_license.LExp <> "" And _
            user_license.LHID <> "" And _
            user_license.LImo <> "" And _
            user_license.LSKey <> "" And _
            user_license.LGPeriod <> "" And _
            user_license.LNum <> "" And _
            user_license.LValid <> "" And _
            user_license.LGen <> "" And _
            user_license.LStat <> "" And _
            user_license.LMsg <> "" And _
            user_license.LRem <> "" Then

            r = True
        End If

        Return r
    End Function


    'create physical license file
    Public Function CreateLicenseFile(ByVal cpath As String, ByVal cLicense As MyLicense) As Boolean
        Dim r As Boolean = False
        Try
            Using sw As System.IO.StreamWriter = System.IO.File.CreateText(cpath)
                sw.WriteLine(cLicense.LAppName)
                sw.WriteLine(cLicense.LType)
                sw.WriteLine(cLicense.LExp)
                sw.WriteLine(cLicense.LHID)
                sw.WriteLine(cLicense.LImo)
                sw.WriteLine(cLicense.LSKey)
                sw.WriteLine(cLicense.LGPeriod)
                sw.WriteLine(cLicense.LNum)
                sw.WriteLine(cLicense.LValid)
                sw.WriteLine(cLicense.LGen)
                sw.WriteLine(cLicense.LStat)
                sw.WriteLine(cLicense.LMsg)
                sw.WriteLine(cLicense.LRem)
            End Using
            r = True
        Catch ex As Exception
            r = False
        End Try
        Return r
    End Function

    Public Sub SaveStatus(ByVal cApp As Working_App, Optional ByVal msg As String = "", Optional ByVal dtime As Date = Nothing)
        Dim b As Boolean = True
        Dim comp As New mdComputerInfo
        Try
            Dim logBy As String = GetAppName() & " in " & My.Computer.Name
            Dim cHid As String = comp.GetHardwareID
            b = PMSDB.RunSql("INSERT INTO " & cApp.App_DbName & ".dbo.tblStiLog ([LogMsg],[LoggedBy],[LogHID],[LoggedDateTime],[App_Name]) VALUES (" & _
                                 "'" & msg & "'," & _
                                 "'" & logBy & "'," & _
                                 "'" & cHid & "'," & _
                                 "'" & dtime.ToString & "'," & _
                                 "'" & cApp.App_Name & "')")
        Catch ex As Exception

        End Try
    End Sub

    'RETURNS : Application Folder
    Public Function GetAppFolder() As String
        Return System.AppDomain.CurrentDomain.BaseDirectory()
    End Function

    'RETURNS : Application Name
    'Public Function GetAppName() As String
    '    Return "Shore Manager 5"
    'End Function


#End Region

#Region "Logs"


    <System.Diagnostics.DebuggerStepThrough()> _
    Public Sub Log_Append(ByVal cApp As Working_App, ByVal strStatus As String, Optional ByVal strFileName As String = "", Optional ByVal createLog As Boolean = True, Optional ByVal savetodb As Boolean = False)

        If Not createLog Then
            Exit Sub
        End If

        Dim StrDirectory As String

        StrDirectory = cApp.App_LogFolder

        If strFileName = "" Then
            strFileName = getServerDate.ToString("dd-MMM-yyyy") & ".txt"
        End If

        If Not System.IO.Directory.Exists(StrDirectory) Then
            System.IO.Directory.CreateDirectory(StrDirectory)
        End If
        Using sw As New System.IO.StreamWriter(StrDirectory & "\" & strFileName, True)
            If strStatus = "" Then
                sw.WriteLine("")
            Else
                Dim dtime As DateTime = Date.Now
                sw.WriteLine(String.Format("{0} {1}", dtime.ToString("dd-MMM-yyyy hh:mm:ss"), strStatus))

                If savetodb Then
                    SaveStatus(cApp, strStatus, dtime)
                End If

            End If

        End Using
    End Sub

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Sub AnErrorOccured(ByVal cApp As Working_App, ByVal ErrMsg As String, Optional ByVal Logged As Boolean = False, Optional ByVal savetodb As Boolean = False)
        If Logged Then
            MsgBox(ErrMsg, MsgBoxStyle.Critical)
            'log error
            Log_Append(cApp, ErrMsg, , , savetodb)
        Else
            MsgBox(ErrMsg, MsgBoxStyle.Critical)
        End If
    End Sub

#End Region

#Region "Troubleshooting"

    'try to get License Information
    Public Sub RunLicenseStatusInfo(ByVal cApp As Working_App, ByVal StrLogFile As String)
        Dim bSuccess As Boolean = True

        Dim strLicType As String = ""
        Dim Mylicense As New MyLicense
        Dim MyLicenseStatus As New MyLicenseStatus

        strLicType = GetConfig(PMSDB, "LTYPE")
        strLicType = sysMpsUserPassword("DECRYPT", strLicType)

        If strLicType = "" Then
            strLicType = "NO"
        End If

        MyLicenseStatus = xValidateLicense(cApp, strLicType, Mylicense, StrLogFile, True)

    End Sub

    'try to restore physical license file
    Public Sub RestoreMyLicenseFile(ByVal cApp As Working_App, ByVal StrLogFile As String)
        Dim bSuccess As Boolean = True
        Dim MyLicenseFromRegistry As New MyLicense
        Dim curr_date As Integer = getServerDate()

        Log_Append(cApp, "********************* Start *********************" & vbNewLine, StrLogFile)

        Log_Append(cApp, "ACTION: TRYING TO RESTORE LICENSE FILE", StrLogFile)
        bSuccess = BackupLicenseReg("GET", cApp.App_Name, "sys_wrhsm5", MyLicenseFromRegistry)
        Log_Append(cApp, "GETTING BACKUP LICENSE -- " & IIf(bSuccess, "OK", "ERROR").ToString.PadLeft(2), StrLogFile)

        If bSuccess Then
            'try create license File
            bSuccess = isValidLicense(MyLicenseFromRegistry)
            Log_Append(cApp, "LICENSE STATUS -- " & IIf(bSuccess, "OK", "NO LICENSE/ INVALID"), StrLogFile)

            If bSuccess Then
                Dim expDate As String = sysMpsUserPassword("DECRYPT", MyLicenseFromRegistry.LExp)
                If isNumDate(CInt(expDate)) Then

                    If ServerDateDiff(expDate) > 0 Then
                        Log_Append(cApp, "LICENSE EXPIRY: " & expDate & " -- VALID", StrLogFile)
                        If MsgBox("Restore License File?", 36) = MsgBoxResult.Yes Then
                            bSuccess = CreateLicenseFile(cApp.App_LicensePath, MyLicenseFromRegistry)
                            Log_Append(cApp, "RESTORING LICENSE FILE -- " & IIf(bSuccess, "OK", "ERROR"), StrLogFile)
                            If bSuccess Then
                                'update reg
                                WriteReg(cApp.App_BackRegGPeriod, "10")
                            End If
                        Else
                            Log_Append(cApp, "RESTORING LICENSE FILE -- CANCELLED", StrLogFile)
                        End If
                    Else
                        Log_Append(cApp, "LICENSE EXPIRY: -- EXPIRED", StrLogFile)
                    End If

                Else
                    Log_Append(cApp, "LICENSE EXPIRY -- CORRUPTED", StrLogFile)
                End If
            Else
                'cannot create License File

            End If

        End If

        Log_Append(cApp, "", StrLogFile)
        Log_Append(cApp, "********************* End *********************", StrLogFile)
    End Sub

    'generate License report
    Public Function GenerateLicenseReport(ByVal cApp As Working_App, ByVal StrLogFile As String, ByVal StrInfile As String) As Boolean
        Dim r As Boolean = True
        Dim dt As DataTable
        Dim strBuilder As New System.Text.StringBuilder
        dt = PMSDB.CreateTable("SELECT * FROM " & cApp.App_DbName & ".dbo.tblSTILog")
        'dt = WRH_DB.CreateTable("SELECT * FROM " & cApp.App_DbName & ".dbo.tblSTILog WHERE LoggedDateTime>='" & DateTimeFrom & "'")

        Dim xmsg As String
        For Each dr As DataRow In dt.Rows
            'strBuilder.AppendLine(Shuffle("INSERT INTO dbo.tblSTILog ([LogId]," & _
            '                                "[LogMsg]" & _
            '                                ",[LoggedBy]" & _
            '                                ",[LogHID]" & _
            '                                ",[LoggedDateTime]" & _
            '                                ",[DateCreated]" & _
            '                                ",[App_Name])" & _
            '                                " VALUES (" & dr("LogId") & "," & _
            '                                "'" & dr("LogMsg") & "'," & _
            '                                "'" & dr("LoggedBy") & "'," & _
            '                                "'" & dr("LogHID") & "'," & _
            '                                "'" & dr("LoggedDateTime") & "'," & _
            '                                "'" & dr("DateCreated") & "'," & _
            '                                "'" & dr("App_Name") & "'" & _
            '                                ")", True))
            xmsg = dr("LogMsg")
            xmsg = xmsg.Replace("'", "''")
            strBuilder.AppendLine("INSERT INTO dbo.tblSTILog ([LogId]," & _
                                            "[LogMsg]" & _
                                            ",[LoggedBy]" & _
                                            ",[LogHID]" & _
                                            ",[LoggedDateTime]" & _
                                            ",[DateCreated]" & _
                                            ",[App_Name])" & _
                                            " VALUES (" & dr("LogId") & "," & _
                                            "'" & xmsg & "'," & _
                                            "'" & dr("LoggedBy") & "'," & _
                                            "'" & dr("LogHID") & "'," & _
                                            "'" & dr("LoggedDateTime") & "'," & _
                                            "'" & dr("DateCreated") & "'," & _
                                            "'" & dr("App_Name") & "'" & _
                                            ")")
        Next

        'attach license info
        Dim dtLInfo As DataTable
        dtLInfo = PMSDB.CreateTable("SELECT * FROM " & cApp.App_DbName & ".dbo.tblSTI")

        For Each drinfo As DataRow In dtLInfo.Rows
            strBuilder.AppendLine("INSERT INTO [LICENSEAPP].[dbo].[tblLicenseLoaded] " & _
                                               "([RecId]" & _
                                               ",[LType]" & _
                                               ",[LExp]" & _
                                               ",[LHID]" & _
                                               ",[LImo]" & _
                                               ",[LSKey]" & _
                                               ",[LGPeriod]" & _
                                               ",[LNum]" & _
                                               ",[LValid]" & _
                                               ",[LGen]" & _
                                               ",[LStat]" & _
                                               ",[LMsg]" & _
                                               ",[LRem]" & _
                                               ",[DateUpdated]) " & _
                                               "VALUES(" & _
                                               "" & drinfo("LID") & "," & _
                                               "'" & sysMpsUserPassword("DECRYPT", drinfo("LType")) & "'," & _
                                               "'" & sysMpsUserPassword("DECRYPT", drinfo("LExp")) & "'," & _
                                               "'" & sysMpsUserPassword("DECRYPT", drinfo("LHID")) & "'," & _
                                               "'" & sysMpsUserPassword("DECRYPT", drinfo("LImo")) & "'," & _
                                               "'" & sysMpsUserPassword("DECRYPT", drinfo("LSKey")) & "'," & _
                                               "'" & sysMpsUserPassword("DECRYPT", drinfo("LGPeriod")) & "'," & _
                                               "'" & sysMpsUserPassword("DECRYPT", drinfo("LNum")) & "'," & _
                                               "'" & sysMpsUserPassword("DECRYPT", drinfo("LValid")) & "'," & _
                                               "'" & sysMpsUserPassword("DECRYPT", drinfo("LGen")) & "'," & _
                                               "'" & sysMpsUserPassword("DECRYPT", drinfo("LStat")) & "'," & _
                                               "'" & sysMpsUserPassword("DECRYPT", drinfo("LMsg")) & "'," & _
                                               "'" & EscapeNewLine(sysMpsUserPassword("DECRYPT", drinfo("LRem"))) & "'," & _
                                               "'" & drinfo("DateUpdated") & "')")
        Next

        Using sw As New System.IO.StreamWriter(StrInfile, True, System.Text.Encoding.Unicode)
            sw.Write(strBuilder.ToString)
        End Using

        Dim strLogFileF As String = GetFileDir(StrLogFile) & GetFileNameWithoutExtension(StrLogFile) & ".logf"

        If ZipFile(StrInfile, strLogFileF) Then
            Kill(StrInfile)
            r = True
        Else
            r = False
        End If

        Return r

    End Function

#End Region

#Region "Security"
    'FUNCTION: Determines if the application is being RUN AS ADMINISTRATOR
    Public Function isElevated() As Boolean
        Dim bRetVal As Boolean = False
        Try
            Dim identity As Security.Principal.WindowsIdentity = Security.Principal.WindowsIdentity.GetCurrent()
            Dim principal As Security.Principal.WindowsPrincipal = New Security.Principal.WindowsPrincipal(identity)
            'check for ADMIN PRIVILEDGE
            bRetVal = principal.IsInRole(Security.Principal.WindowsBuiltInRole.Administrator)
        Catch ex As Exception
        End Try
        Return bRetVal
    End Function
#End Region

    Public Function EscapeNewLine(ByVal str As String) As String
        str = str.Replace(vbLf, " ")
        str = str.Replace(vbCr, " ")
        str = str.Replace(vbTab, " ")
        str = str.Replace(vbNewLine, " ")
        Return str
    End Function

    Private Function pms_app() As Working_App
        Throw New NotImplementedException
    End Function

End Module
