﻿Imports System.Data.SqlClient

Public Class clsAudit

    Private sqlConn As New SqlClient.SqlConnection
    Private sqlConnStr As String

    Public Property propSQLConnStr As String
        Get
            Return sqlConnStr
        End Get
        Set(value As String)
            sqlConnStr = value
        End Set
    End Property

    Public Function getAuditData(ByRef dt As DataTable, Optional crewid As String = "<NOCRITERIA>", Optional crewname As String = "<NOCRITERIA>",
                          Optional updatedby As String = "<NOCRITERIA>", Optional datefrom As Date = Nothing,
                          Optional dateto As Date = Nothing, Optional screen As String = "<NOCRITERIA>",
                          Optional modulecode As Integer = 999, Optional recordstart As Long = 1,
                          Optional rowcount As Long = 25, Optional byPassRecCnt As Integer = 0,
                          Optional typeofwork As Integer = Nothing, Optional critical As Integer = Nothing,
                          Optional machine As String = Nothing, Optional typeofaction As String = Nothing,
                          Optional maintenance As String = Nothing, Optional rank As String = Nothing) As String

        Dim tempreturn As String = ""

        Using sqlConn
            sqlConn.ConnectionString = propSQLConnStr
            'dbconn.closeconn()

            Try

                sqlConn.Open()

                If sqlConn.State <> ConnectionState.Open Then
                    tempreturn = "sql connection is nothing"
                Else

                    Dim sqlComm As New SqlCommand()
                    Dim da As New SqlDataAdapter
                    'Dim dt As New DataTable

                    If dateto = Nothing Then
                        dateto = Now
                    End If
                    If datefrom = Nothing Then
                        datefrom = DateAdd(DateInterval.Day, -5, Now)
                    End If


                    sqlComm.Connection = sqlConn

                    sqlComm.CommandText = "audit_main"
                    sqlComm.CommandType = CommandType.StoredProcedure
                    sqlComm.CommandTimeout = 300

                    'da = New SqlDataAdapter(sqlComm)
                    sqlComm.Parameters.AddWithValue("p_crewid", crewid)
                    sqlComm.Parameters.AddWithValue("p_crewname", crewname)
                    sqlComm.Parameters.AddWithValue("p_updatedby", updatedby)
                    sqlComm.Parameters.AddWithValue("p_datefrom", datefrom)
                    sqlComm.Parameters.AddWithValue("p_dateto", dateto)
                    sqlComm.Parameters.AddWithValue("p_screen", screen)
                    sqlComm.Parameters.AddWithValue("p_modulecode", modulecode)
                    sqlComm.Parameters.AddWithValue("p_recordstart", recordstart)
                    sqlComm.Parameters.AddWithValue("p_rowcount", rowcount)
                    sqlComm.Parameters.AddWithValue("p_bypassreccnt", byPassRecCnt)

                    If typeofwork <> Nothing Then
                        sqlComm.Parameters.AddWithValue("p_typeofwork", typeofwork)
                    End If
                    If critical <> Nothing Then
                        sqlComm.Parameters.AddWithValue("p_critical", critical)
                    End If
                    If maintenance <> Nothing Then
                        sqlComm.Parameters.AddWithValue("p_maintenance", maintenance)
                    End If
                    If machine <> Nothing Then
                        sqlComm.Parameters.AddWithValue("p_machine", machine)
                    End If
                    If typeofaction <> Nothing Then
                        sqlComm.Parameters.AddWithValue("p_typeofaction", typeofaction)
                    End If
                    If rank <> Nothing Then
                        sqlComm.Parameters.AddWithValue("p_rank", rank)
                    End If

                    da.SelectCommand = sqlComm

                    da.Fill(dt)

                    'sqlComm.ExecuteNonQuery()
                    'returnKo = ""
                    sqlConn.Close()
                End If
            Catch SqlEx As SqlException
                Dim myError As SqlError
                Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                For Each myError In SqlEx.Errors
                    tempreturn = tempreturn & " / " & (myError.Number & " - " & myError.Message)
                Next
            End Try
        End Using

        Return tempreturn

    End Function

    Public Function saveAuditLog(sActionDescrip As String, sUserName As String, ByRef iRetLogID As Long,
                                 sComputerName As String, iModuleCode As Integer,
                                 Optional sTablename As String = Nothing, Optional sPKeyVal As String = Nothing,
                                 Optional sAdditionalInfo As String = Nothing, Optional sCrewID As String = "N/A",
                                 Optional sDataDescrip As String = Nothing, Optional sScreenCaption As String = "N/A",
                                 Optional dDateUpdated As Date = Nothing, Optional sPKeyField As String = "pkey",
                                 Optional sMachine As String = Nothing, Optional iTypeofWork As Integer = Nothing,
                                 Optional iCritical As Integer = Nothing, Optional sMaintenance As String = Nothing,
                                 Optional sRank As String = Nothing
                                 ) As String

        '/// for inserting data directly to Audit parent table "AuditLog"

        Dim sRetString As String = ""

        Dim sqlComm As New SqlCommand()

        Using sqlConn
            sqlConn.ConnectionString = propSQLConnStr
            'dbconn.closeconn()

            Try
                sqlConn.Open()

                If sqlConn.State <> ConnectionState.Open Then
                    sRetString = "sql connection is nothing"
                Else
                    sqlComm.Connection = sqlConn

                    sqlComm.CommandText = "auditSaveLog"
                    sqlComm.CommandType = CommandType.StoredProcedure

                    sqlComm.Parameters.AddWithValue("CrewID", sCrewID)
                    sqlComm.Parameters.AddWithValue("ComputerName", sComputerName)
                    sqlComm.Parameters.AddWithValue("ModuleCode", iModuleCode)
                    sqlComm.Parameters.AddWithValue("DataDescrip", sDataDescrip)
                    sqlComm.Parameters.AddWithValue("ScreenCaption", sScreenCaption)
                    sqlComm.Parameters.AddWithValue("ActionDescrip", sActionDescrip)
                    If dDateUpdated = Nothing Then
                        sqlComm.Parameters.AddWithValue("DateUpdated", DBNull.Value)
                    Else
                        sqlComm.Parameters.AddWithValue("DateUpdated", dDateUpdated)
                    End If
                    sqlComm.Parameters.AddWithValue("Tablename", sTablename)
                    sqlComm.Parameters.AddWithValue("PKeyField", sPKeyField)
                    sqlComm.Parameters.AddWithValue("PKeyVal", sPKeyVal)
                    sqlComm.Parameters.AddWithValue("AdditionalInfo", sAdditionalInfo)
                    sqlComm.Parameters.AddWithValue("UserName", sUserName)
                    sqlComm.Parameters.AddWithValue("Machine", sMachine)
                    sqlComm.Parameters.AddWithValue("TypeofWork", iTypeofWork)
                    sqlComm.Parameters.AddWithValue("Critical", iCritical)
                    sqlComm.Parameters.AddWithValue("Maintenance", sMaintenance)
                    sqlComm.Parameters.AddWithValue("Rank", sRank)

                    sqlComm.Parameters.Add("insertedID", SqlDbType.BigInt)
                    sqlComm.Parameters("insertedID").Direction = ParameterDirection.Output


                    sqlComm.ExecuteNonQuery()
                    iRetLogID = sqlComm.Parameters("insertedID").Value

                    sqlConn.Close()

                End If

            Catch SqlEx As SqlException
                Dim myError As SqlError
                Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                For Each myError In SqlEx.Errors
                    sRetString = sRetString & " / " & (myError.Number & " - " & myError.Message)
                Next
            End Try
        End Using

        Return sRetString
    End Function

    Public Function saveAuditDetails(iAuditLogID As Long, sFieldName As String, sNewValue As Object,
                                     Optional sOldValue As Object = Nothing)

        '/// for inserting data directly to Audit child table "AuditDetails"
        '/// Use after function saveAuditLog function
        '/// Use the ouput "AuditlogID" from saveAuditLog function

        Dim sRetString As String = ""

        Dim sqlComm As New SqlCommand()

        Using sqlConn
            sqlConn.ConnectionString = propSQLConnStr
            'dbconn.closeconn()

            Try
                sqlConn.Open()

                If sqlConn.State <> ConnectionState.Open Then
                    sRetString = "sql connection is nothing"
                Else

                    sqlComm.Connection = sqlConn

                    sqlComm.CommandText = "auditSaveDetails"
                    sqlComm.CommandType = CommandType.StoredProcedure

                    sqlComm.Parameters.AddWithValue("AuditLogID", iAuditLogID)
                    sqlComm.Parameters.AddWithValue("FieldName", sFieldName)
                    sqlComm.Parameters.AddWithValue("OldValue ", sOldValue)
                    sqlComm.Parameters.AddWithValue("NewValue", sNewValue)


                    sqlComm.ExecuteNonQuery()
               
                    sqlConn.Close()

                End If

            Catch SqlEx As SqlException
                Dim myError As SqlError
                Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                For Each myError In SqlEx.Errors
                    sRetString = sRetString & " / " & (myError.Number & " - " & myError.Message)
                Next
            End Try
        End Using

        Return sRetString
    End Function

    Public Function saveAuditPreDelDetails(sTableName As String, sPKey As String, sPreLastUBy As String)

        '/// for inserting data directly to Audit child table "AuditDetails"
        '/// Use after function saveAuditLog function
        '/// Use the ouput "AuditlogID" from saveAuditLog function

        Dim sRetString As String = ""

        Dim sqlComm As New SqlCommand()

        Using sqlConn
            Try
                sqlConn.ConnectionString = propSQLConnStr
                'dbconn.closeconn()
                sqlConn.Open()

                If sqlConn.State <> ConnectionState.Open Then
                    sRetString = "sql connection is nothing"
                Else

                    sqlComm.Connection = sqlConn

                    sqlComm.CommandText = "auditSavePreDelDetails"
                    sqlComm.CommandType = CommandType.StoredProcedure

                    sqlComm.Parameters.AddWithValue("TableName", sTableName)
                    sqlComm.Parameters.AddWithValue("PKeyValue", sPKey)
                    sqlComm.Parameters.AddWithValue("PreLastUBy ", sPreLastUBy)


                    sqlComm.ExecuteNonQuery()

                End If

                sqlConn.Close()

            Catch SqlEx As SqlException
                Dim myError As SqlError
                Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                For Each myError In SqlEx.Errors
                    sRetString = sRetString & " / " & (myError.Number & " - " & myError.Message)
                Next
            End Try

        End Using

        Return sRetString
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sUserName"></param>
    ''' <param name="sActionDescrip"> Automatic unless enter any string </param>
    ''' <param name="iModuleCode"></param>
    ''' <param name="sComputerName"></param>
    ''' <param name="sDataDescrip"></param>
    ''' <param name="sScreenCaption"></param>
    ''' <param name="sCrewID"></param>
    ''' <param name="iAuditBa"> pass 1 to trigger audit </param>
    ''' <param name="sMachine"></param>
    ''' <param name="iTypeofWork"></param>
    ''' <param name="iCritical"></param>
    ''' <param name="Maintenance">Skip this. Not Needed</param>
    ''' <param name="Rank"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AssembleLastUBy(sUserName As String, sActionDescrip As String, iModuleCode As Integer, sComputerName As String,
                                    Optional sDataDescrip As String = "", Optional sScreenCaption As String = "N/A",
                                    Optional sCrewID As String = "N/A", Optional iAuditBa As Integer = 0, Optional sMachine As String = "",
                                    Optional iTypeofWork As Integer = Nothing, Optional iCritical As Integer = Nothing,
                                    Optional Maintenance As String = "", Optional Rank As String = "") As String

        Dim tempReturn As String

        Try
            'Pattern is same as in the Stored proc. Pattern should be followed
            tempReturn = "<" & sUserName & "><" & sCrewID & "><" & sComputerName & "><" & iModuleCode & "><" &
                            sDataDescrip.Replace("->", ":") & "><" & sScreenCaption & "><" & sActionDescrip & "><" & iAuditBa & "><" &
                             sMachine & "><" & iTypeofWork & "><" & iCritical & "><" & Maintenance & "><" & Rank & ">"

        Catch ex As Exception
            tempReturn = ""
        End Try

        tempReturn = tempReturn.Replace("'", "''")

        Return tempReturn
    End Function


End Class