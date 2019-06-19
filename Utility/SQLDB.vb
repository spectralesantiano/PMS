'On Error Blame Teddy
Public Class SQLDB

    Private nRecordCount As Integer = 0
    Private ErrMsg As String
    Private CommandTimeout As Byte = 150
    Private strSymmetricKey As String, strSymmetricKeyPassword As String, EncryptedObjects As New ArrayList
    Private Const SQL_Key_Source As String = "The Quick Brown Fox Jumps Over The Lazy Dog"
    'SQL Server connectors
    Private sqlcon As SqlClient.SqlConnection
    Private sqladp As SqlClient.SqlDataAdapter
    Private sqlcmd As SqlClient.SqlCommand
    Private sqlrdr As SqlClient.SqlDataReader

    ''' <summary>
    ''' Inserts Open,Close Symmetric key into a specified sql
    ''' </summary>
    ''' <param name="sql">SQL script to be executed.</param>
    ''' <returns>SQL statement with added symmetric statments.</returns>
    ''' <remarks></remarks>
    Private Function InsertSQLSymetricKeys(sql As String) As String
        Dim bHasEnryptedObject As Boolean = False, strSQLObject As String

        For Each strSQLObject In EncryptedObjects
            If sql.ToLower.Contains(strSQLObject.ToLower) Then
                bHasEnryptedObject = True
                Exit For
            End If
        Next

        If bHasEnryptedObject Then
            Return "OPEN SYMMETRIC KEY " & strSymmetricKey & " DECRYPTION BY password='" & strSymmetricKeyPassword & "'" & Environment.NewLine & sql & Environment.NewLine & "CLOSE SYMMETRIC KEY " & strSymmetricKey
        Else
            Return sql
        End If
    End Function

    ''' <summary>
    ''' Check if there's already an existing symmetric key
    ''' </summary>
    ''' <returns>True if the key exists otherwise false.</returns>
    ''' <remarks></remarks>
    Public Function SymmetricKeyExist() As Boolean
        Dim bRetVal As Boolean = False
        BeginReader("IF EXISTS (SELECT name FROM sys.symmetric_keys WHERE name='" & sqlcon.Database.ToLower & "_key" & "') SELECT 1")
        If Read() Then
            bRetVal = True
        End If
        CloseReader()
        Return bRetVal
    End Function

    ''' <summary>
    ''' Get the database symmetric key
    ''' </summary>
    ''' <returns>Name of symmetric key</returns>
    ''' <remarks></remarks>
    Public Function SymmetricKey() As String
        Return strSymmetricKey
    End Function

    ''' <summary>
    ''' Create a symmetric key if not exist.
    ''' </summary>
    ''' <param name="strIdentityValue">Identity Phrase used by sql server</param>
    ''' <param name="strPassword">Symmetric key password.</param>
    ''' <param name="strEncryptedObjects">Objects that has encryption.</param>
    ''' <remarks></remarks>
    Public Sub InitSymmetricKey(strIdentityValue As String, strPassword As String, strEncryptedObjects As String)
        Dim strObjects As String
        strSymmetricKeyPassword = strPassword
        strSymmetricKey = sqlcon.Database.ToLower & "_key"
        For Each strObjects In strEncryptedObjects.Split(";"c)
            If strObjects <> "" Then EncryptedObjects.Add(strObjects)
        Next
        RunSql("IF NOT EXISTS (SELECT name FROM sys.symmetric_keys WHERE name='" & strSymmetricKey & "') CREATE SYMMETRIC KEY " & strSymmetricKey & " WITH ALGORITHM =AES_256, KEY_SOURCE='" & SQL_Key_Source & "', IDENTITY_VALUE='" & strIdentityValue & "' ENCRYPTION BY PASSWORD= '" & strPassword & "'")
    End Sub

    ''' <summary>
    ''' Initialized the DB Object.
    ''' </summary>
    ''' <param name="ConnectionString">Connection to the server</param>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Sub New(ByVal ConnectionString As String)
        sqlcon = New SqlClient.SqlConnection(ConnectionString)
    End Sub

    ''' <summary>
    ''' Get the connection string
    ''' </summary>
    ''' <returns>Connection string.</returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetConnectionString()
        Return sqlcon.ConnectionString
    End Function

    ''' <summary>
    ''' Initialize SQL scripts with parameters
    ''' </summary>
    ''' <param name="sql">SQL Statement</param>
    ''' <remarks></remarks>
    Public Sub InitSqlWithParameters(ByVal sql As String)
        sqlcmd = New SqlClient.SqlCommand(InsertSQLSymetricKeys(sql), sqlcon)
    End Sub

    ''' <summary>
    ''' Add parameters in the SQL statement
    ''' </summary>
    ''' <param name="param">Name of Parameter</param>
    ''' <param name="type">Data Type of parameter</param>
    ''' <param name="value">Value of the parameter</param>
    ''' <remarks></remarks>
    Public Sub AddSqlParameter(ByVal param As String, type As Data.SqlDbType, value As Object)
        sqlcmd.Parameters.Add(param, type)
        sqlcmd.Parameters(param).Value = value
    End Sub

    ''' <summary>
    ''' Execute SQL statements with parameter.
    ''' </summary>
    ''' <returns>True if the process is successful otherwise false</returns>
    ''' <remarks></remarks>
    Public Function RunSqlWithParameters() As Boolean
        Try
            sqlcon.Open()
            sqlcmd.ExecuteNonQuery()
            sqlcmd.Dispose()
            sqlcon.Close()
            Return True
        Catch ex As Exception
            ErrMsg = ex.Message
            LogErrors(ErrMsg)
            If sqlcon.State <> ConnectionState.Closed Then
                sqlcon.Close()
            End If
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Create a data table based on the result of specified SQL statement.
    ''' </summary>
    ''' <param name="sql">SQL statement</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function CreateTable(ByVal sql As String) As DataTable
        Dim ctable As New DataTable
        Try
            sqlcon.Open()
            sqladp = New SqlClient.SqlDataAdapter(InsertSQLSymetricKeys(sql), sqlcon)
            sqladp.Fill(ctable)
            sqladp.Dispose()
            sqlcon.Close()
        Catch ex As Exception
            ErrMsg = ex.Message
            LogErrors(ErrMsg)
            If sqlcon.State <> ConnectionState.Closed Then
                sqlcon.Close()
            End If
        End Try
        nRecordCount = ctable.Rows.Count
        Return ctable
    End Function

    ''' <summary>
    ''' Creates a Recordset, requires sql statement
    ''' </summary>
    ''' <param name="queries">Sql statements</param>
    ''' <param name="relations">Keys to be used.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Function CreateDataSet(ByVal queries() As String, ByVal relations() As String) As DataSet
        Dim data As New DataSet()
        Dim query As String, rel As String
        Try
            sqlcon.Open()
            For Each query In queries
                sqladp = New SqlClient.SqlDataAdapter
                sqladp.TableMappings.Add("Table", query.Split(";").GetValue(0))
                sqlcmd = New SqlClient.SqlCommand(query.Split(";").GetValue(1), sqlcon)
                sqladp.SelectCommand = sqlcmd
                sqladp.Fill(data)
                sqladp.Dispose()
            Next
            For Each rel In relations
                Dim rel_item() As String = rel.Split(";")
                Dim keyColumn As DataColumn = data.Tables(rel_item(1).Split(".").GetValue(0)).Columns(rel_item(1).Split(".").GetValue(1))
                Dim foreignKeyColumn As DataColumn = data.Tables(rel_item(2).Split(".").GetValue(0)).Columns(rel_item(2).Split(".").GetValue(1))
                data.Relations.Add(rel_item(0), keyColumn, foreignKeyColumn)
            Next
            sqlcon.Close()
        Catch ex As Exception
            ErrMsg = ex.Message
            LogErrors(ErrMsg)
            If sqlcon.State <> ConnectionState.Closed Then
                sqlcon.Close()
            End If
        End Try
        Return data
    End Function

    ''' <summary>
    ''' Fill the data table with data based on the output of the SQL Statement.
    ''' </summary>
    ''' <param name="sql">Sql statement</param>
    ''' <param name="ctable">object that will be populated by the query results</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Function FillTable(ByVal sql As String, ByVal ctable As DataTable) As DataTable
        Dim xtable As DataTable = ctable.Clone
        Try
            sqlcon.Open()
            sqladp = New SqlClient.SqlDataAdapter(InsertSQLSymetricKeys(sql), sqlcon)
            sqladp.Fill(xtable)
            sqladp.Dispose()
            sqlcon.Close()
        Catch ex As Exception
            ErrMsg = ex.Message
            LogErrors(ErrMsg)
            If sqlcon.State <> ConnectionState.Closed Then
                sqlcon.Close()
            End If
        End Try
        nRecordCount = xtable.Rows.Count
        Return xtable
    End Function

    ''' <summary>
    ''' Gets the RecordCount of the last query that was executed.
    ''' </summary>
    ''' <returns>Number of records of the last query</returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Function RecordCount() As Integer
        Return nRecordCount
    End Function

    ''' <summary>
    ''' Execute the specified sql statement
    ''' </summary>
    ''' <param name="sql">Sql statment to be processed</param>
    ''' <returns>True if the script was processed successfully</returns>
    ''' <remarks></remarks>
    Public Function RunSql(ByVal sql As String) As Boolean
        Try
            sqlcmd = New SqlClient.SqlCommand(InsertSQLSymetricKeys(sql), sqlcon)
            sqlcmd.CommandTimeout = CommandTimeout
            sqlcon.Open()
            sqlcmd.ExecuteNonQuery()
            sqlcmd.Dispose()
            sqlcon.Close()
            Return True
        Catch ex As Exception
            ErrMsg = ex.Message
            LogErrors(ErrMsg)
            If sqlcon.State <> ConnectionState.Closed Then
                sqlcon.Close()
            End If
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Execute the specified sql statements
    ''' </summary>
    ''' <param name="sqls">Sql statments to be processed</param>
    ''' <returns>True if the script was processed successfully</returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function RunSqls(ByVal sqls As ArrayList) As Boolean
        ErrMsg = ""
        Try
            Dim sql As String
            sqlcmd = New SqlClient.SqlCommand()
            sqlcmd.Connection = sqlcon
            sqlcmd.CommandTimeout = CommandTimeout
            sqlcon.Open()
            For Each sql In sqls
                If sql <> "" Then
                    sqlcmd.CommandText = InsertSQLSymetricKeys(sql)
                    Try
                        sqlcmd.ExecuteNonQuery()
                    Catch ex As Exception
                        ErrMsg = String.Format("{0}Error Message:{1}{2}SQL Statement:{3}{4}", ErrMsg, ex.Message, Environment.NewLine, sql, Environment.NewLine)
                    End Try
                End If
            Next
            sqlcmd.Dispose()
            sqlcon.Close()
            If ErrMsg <> "" Then
                LogErrors(ErrMsg)
            End If
            Return True
        Catch ex As Exception
            ErrMsg = ex.Message
            LogErrors(ErrMsg)
            If sqlcon.State <> ConnectionState.Closed Then
                sqlcon.Close()
            End If
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Updates the settings table on sti_sys database.
    ''' </summary>
    ''' <param name="strCode">Key of the setting</param>
    ''' <param name="strValue">New value for the setting</param>
    ''' <param name="strDBShortName">Short Database description e.g. WRH, SM, SAS e.t.c..</param>
    ''' <remarks></remarks>
    Public Sub SaveConfig(ByVal strCode As String, ByVal strValue As String, strDBShortName As String)
        Dim has_rec As Boolean = False
        BeginReader("Select Value from sti_sys.dbo.tbl" & strDBShortName & "Config Where Code='" & strCode & "'")
        has_rec = HasRows()
        CloseReader()
        If has_rec Then
            RunSql("Update sti_sys.dbo.tbl" & strDBShortName & "Config set Value='" & strValue & "' Where CODE='" & strCode & "'")
        Else
            RunSql("Insert into sti_sys.dbo.tbl" & strDBShortName & "Config(Code,Value) Values('" & strCode & "','" & strValue & "')")
        End If
    End Sub

    ''' <summary>
    ''' Gets the settings on the sti_sys database.
    ''' </summary>
    ''' <param name="strCode">Key of the setting</param>
    ''' <param name="strDBShortName">Short Database description e.g. WRH, SM, SAS e.t.c..</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function Settings(ByVal strCode As String, strDBShortName As String) As String
        Dim retVal As String = ""
        Try
            sqlcon.Open()
            sqlcmd = New SqlClient.SqlCommand("SELECT TOP 1 Value FROM sti_sys.dbo.tbl" & strDBShortName & "Config WHERE Code='" & strCode & "'", sqlcon)
            sqlrdr = sqlcmd.ExecuteReader()
            If sqlrdr.HasRows Then
                sqlrdr.Read()
                If Not (sqlrdr(0) Is System.DBNull.Value) Then
                    retVal = sqlrdr(0)
                End If
            End If
            sqlrdr.Close()
            sqlcmd.Dispose()
            sqlcon.Close()
        Catch ex As Exception
            ErrMsg = ex.Message
            LogErrors(ErrMsg)
            If sqlcon.State <> ConnectionState.Closed Then
                sqlcon.Close()
            End If
        End Try
        Return retVal
    End Function

    ''' <summary>
    ''' Gets the settings on the sti_sys database.
    ''' </summary>
    ''' <param name="strCode">Key of the setting</param>
    ''' <param name="strDefaultValue">the return value if expresion is null, cannot be found or the function encountered error.</param>
    ''' <param name="strDBShortName">Short Database description e.g. WRH, SM, SAS e.t.c..</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function Settings(ByVal strCode As String, strDefaultValue As String, strDBShortName As String) As String
        Dim retVal As Object = strDefaultValue
        Try
            sqlcon.Open()
            sqlcmd = New SqlClient.SqlCommand("SELECT TOP 1 Value FROM sti_sys.dbo.tbl" & strDBShortName & "Config WHERE Code='" & strCode & "'", sqlcon)
            sqlrdr = sqlcmd.ExecuteReader()
            If sqlrdr.HasRows Then
                sqlrdr.Read()
                If Not (sqlrdr(0) Is System.DBNull.Value) Then
                    retVal = sqlrdr(0)
                End If
            End If
            sqlrdr.Close()
            sqlcmd.Dispose()
            sqlcon.Close()
        Catch ex As Exception
            ErrMsg = ex.Message
            LogErrors(ErrMsg)
            If sqlcon.State <> ConnectionState.Closed Then
                sqlcon.Close()
            End If
        End Try
        Return retVal
    End Function

    ''' <summary>
    ''' Execute the specified sql statements in a transaction
    ''' </summary>
    ''' <param name="sqls">SQL Statements</param>
    ''' <returns>True if the script was processed successfully</returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function RunTransaction(ByVal sqls As ArrayList) As Boolean
        Try
            sqlcon.Open()
            sqlcmd = sqlcon.CreateCommand()
            Dim transaction As SqlClient.SqlTransaction = sqlcon.BeginTransaction(), sql As String
            sqlcmd.Connection = sqlcon
            sqlcmd.Transaction = transaction
            Try
                For Each sql In sqls
                    If sql <> "" Then
                        sqlcmd.CommandText = InsertSQLSymetricKeys(sql)
                        sqlcmd.ExecuteNonQuery()
                    End If
                Next
                transaction.Commit()
            Catch ex As Exception
                transaction.Rollback()
            End Try
            sqlcmd.Dispose()
            sqlcon.Close()
            Return True
        Catch ex As Exception
            ErrMsg = ex.Message
            LogErrors(ErrMsg)
            If sqlcon.State <> ConnectionState.Closed Then
                sqlcon.Close()
            End If
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Gets the value of specified expression from a table or view.
    ''' </summary>
    ''' <param name="expr">field or expresion you want to lookup</param>
    ''' <param name="domain">requires table/query name in the specified database or database.table/view name on the specified server.</param>
    ''' <param name="defaultvalue">the return value if expresion is null, cannot be found or the function encountered error.</param>
    ''' <returns>String value of the result</returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function DLookUp(ByVal expr As String, ByVal domain As String, ByVal defaultvalue As String) As String
        Try
            sqlcon.Open()
            sqlcmd = New SqlClient.SqlCommand(InsertSQLSymetricKeys("SELECT TOP 1 " & expr & " FROM " & domain), sqlcon)
            sqlrdr = sqlcmd.ExecuteReader()
            If sqlrdr.HasRows Then
                sqlrdr.Read()
                If Not (sqlrdr(0) Is System.DBNull.Value) Then
                    defaultvalue = sqlrdr(0).ToString
                End If
            End If
            sqlrdr.Close()
            sqlcmd.Dispose()
            sqlcon.Close()
        Catch ex As Exception
            ErrMsg = ex.Message
            LogErrors(ErrMsg)
            If sqlcon.State <> ConnectionState.Closed Then
                sqlcon.Close()
            End If
        End Try
        Return defaultvalue
    End Function

    ''' <summary>
    ''' Gets the value of specified expression from a table or view.
    ''' </summary>
    ''' <param name="expr">field or expresion you want to lookup</param>
    ''' <param name="domain">requires table/query name in the specified database or database.table/view name on the specified server.</param>
    ''' <param name="defaultvalue">the return value if expresion is null, cannot be found or the function encountered error.</param>
    ''' <param name="Criteria">Primary filter expression</param>
    ''' <returns>String value of the result</returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function DLookUp(ByVal expr As String, ByVal domain As String, ByVal defaultvalue As String, ByVal Criteria As String) As String
        Try
            sqlcon.Open()
            sqlcmd = New SqlClient.SqlCommand(InsertSQLSymetricKeys("SELECT TOP 1 " & expr & " FROM " & domain & IIf(Criteria = "", "", " WHERE " & Criteria).ToString), sqlcon)
            sqlrdr = sqlcmd.ExecuteReader()
            If sqlrdr.HasRows Then
                sqlrdr.Read()
                If Not (sqlrdr(0) Is System.DBNull.Value) Then
                    defaultvalue = sqlrdr(0).ToString
                End If
            End If
            sqlrdr.Close()
            sqlcmd.Dispose()
            sqlcon.Close()
        Catch ex As Exception
            ErrMsg = ex.Message
            LogErrors(ErrMsg)
            If sqlcon.State <> ConnectionState.Closed Then
                sqlcon.Close()
            End If
        End Try
        Return defaultvalue
    End Function

    ''' <summary>
    ''' Gets the value of specified expression from a table or view.
    ''' </summary>
    ''' <param name="expr">field or expresion you want to lookup</param>
    ''' <param name="domain">requires table/query name in the specified database or database.table/view name on the specified server.</param>
    ''' <param name="defaultvalue">the return value if expresion is null, cannot be found or the function encountered error.</param>
    ''' <returns>String value of the result</returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function DLookUp(ByVal expr As String, ByVal domain As Date, ByVal defaultvalue As String) As Date
        Try
            sqlcon.Open()
            sqlcmd = New SqlClient.SqlCommand("SELECT TOP 1 " & expr & " FROM " & domain, sqlcon)
            sqlrdr = sqlcmd.ExecuteReader()
            If sqlrdr.HasRows Then
                sqlrdr.Read()
                If Not (sqlrdr(0) Is System.DBNull.Value) Then
                    defaultvalue = sqlrdr(0).ToString
                End If
            End If
            sqlrdr.Close()
            sqlcmd.Dispose()
            sqlcon.Close()
        Catch ex As Exception
            ErrMsg = ex.Message
            LogErrors(ErrMsg)
            If sqlcon.State <> ConnectionState.Closed Then
                sqlcon.Close()
            End If
        End Try
        Return defaultvalue
    End Function

    ''' <summary>
    ''' Gets the value of specified expression from a table or view.
    ''' </summary>
    ''' <param name="expr">field or expresion you want to lookup</param>
    ''' <param name="domain">requires table/query name in the specified database or database.table/view name on the specified server.</param>
    ''' <param name="defaultvalue">the return value if expresion is null, cannot be found or the function encountered error.</param>
    ''' <returns>value of the result</returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function DLookUp(ByVal expr As String, ByVal domain As String, ByVal defaultvalue As Date, ByVal Criteria As String) As Date
        Try
            sqlcon.Open()
            sqlcmd = New SqlClient.SqlCommand("SELECT TOP 1 " & expr & " FROM " & domain & IIf(Criteria = "", "", " WHERE " & Criteria).ToString, sqlcon)
            sqlrdr = sqlcmd.ExecuteReader()
            If sqlrdr.HasRows Then
                sqlrdr.Read()
                If Not (sqlrdr(0) Is System.DBNull.Value) Then
                    defaultvalue = sqlrdr(0)
                End If
            End If
            sqlrdr.Close()
            sqlcmd.Dispose()
            sqlcon.Close()
        Catch ex As Exception
            ErrMsg = ex.Message
            LogErrors(ErrMsg)
            If sqlcon.State <> ConnectionState.Closed Then
                sqlcon.Close()
            End If
        End Try
        Return defaultvalue
    End Function

    ''' <summary>
    ''' Gets the value of specified expression from a table or view.
    ''' </summary>
    ''' <param name="expr">field or expresion you want to lookup</param>
    ''' <param name="defaultvalue">the return value if expresion is null, cannot be found or the function encountered error.</param>
    ''' <returns>Value of the result</returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function DFunction(ByVal expr As String, ByVal defaultvalue As Object) As Object
        Try
            sqlcon.Open()
            sqlcmd = New SqlClient.SqlCommand("SELECT " & expr, sqlcon)
            sqlrdr = sqlcmd.ExecuteReader()
            If sqlrdr.HasRows Then
                sqlrdr.Read()
                If Not (sqlrdr(0) Is System.DBNull.Value) Then
                    defaultvalue = sqlrdr(0)
                End If
            End If
            sqlrdr.Close()
            sqlcmd.Dispose()
            sqlcon.Close()
        Catch ex As Exception
            ErrMsg = ex.Message
            LogErrors(ErrMsg)
            If sqlcon.State <> ConnectionState.Closed Then
                sqlcon.Close()
            End If
        End Try
        Return defaultvalue
    End Function

    ''' <summary>
    ''' Opens data source for reading.
    ''' </summary>
    ''' <param name="sql">SQL statement for the data source</param>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Sub BeginReader(ByVal sql As String)
        Try
            sqlcon.Open()
            sqlcmd = New SqlClient.SqlCommand(InsertSQLSymetricKeys(sql), sqlcon)
            sqlcmd.CommandTimeout = CommandTimeout
            sqlrdr = sqlcmd.ExecuteReader()
        Catch ex As Exception
            ErrMsg = ex.Message
            LogErrors(ErrMsg)
            If sqlcon.State <> ConnectionState.Closed Then
                sqlcon.Close()
            End If
        End Try
    End Sub

    ''' <summary>
    ''' Start's reading from the data source. Will return false if no data.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function Read()
        Try
            Return sqlrdr.Read()
        Catch ex As Exception
            ErrMsg = ex.Message
            LogErrors(ErrMsg)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Get's the data from specific column based on index.
    ''' </summary>
    ''' <param name="index">Position of the column on the table</param>
    ''' <returns>Value of the column on a specified position</returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function ReaderItem(ByVal index As Integer) As Object
        Try
            Return sqlrdr.Item(index)
        Catch ex As Exception
            ErrMsg = ex.Message
            LogErrors(ErrMsg)
            Return System.DBNull.Value
        End Try
    End Function

    ''' <summary>
    ''' Get's the data from specific column.
    ''' </summary>
    ''' <param name="name">Name of the column on specific table.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function ReaderItem(ByVal name As String) As Object
        Try
            Return sqlrdr.Item(name)
        Catch ex As Exception
            ErrMsg = ex.Message
            LogErrors(ErrMsg)
            Return System.DBNull.Value
        End Try
    End Function

    ''' <summary>
    ''' Get's the data from specific column.
    ''' </summary>
    ''' <param name="name">Name of the column on specific table.</param>
    ''' <param name="defaultvalue">Return value when null.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function ReaderItem(ByVal name As String, defaultvalue As Object) As Object
        Try
            If sqlrdr.Item(name) Is System.DBNull.Value Then
                Return defaultvalue
            Else
                Return sqlrdr.Item(name)
            End If
        Catch ex As Exception
            ErrMsg = ex.Message
            LogErrors(ErrMsg)
            Return defaultvalue
        End Try
    End Function

    ''' <summary>
    ''' Get's the data from specific column based on index.
    ''' </summary>
    ''' <param name="index">Position of the column on the table</param>
    ''' <param name="defaultvalue">Return value when null.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function ReaderItem(ByVal index As Integer, defaultvalue As Object) As Object
        Try
            If sqlrdr.Item(index) Is System.DBNull.Value Then
                Return defaultvalue
            Else
                Return sqlrdr.Item(index)
            End If
        Catch ex As Exception
            ErrMsg = ex.Message
            LogErrors(ErrMsg)
            Return defaultvalue
        End Try
    End Function

    ''' <summary>
    ''' Returns numbers of field on the table.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function ReaderItemCount() As Integer
        Try
            Return sqlrdr.FieldCount
        Catch ex As Exception
            ErrMsg = ex.Message
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Checks if the data source has records.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function HasRows() As Boolean
        Try
            Return sqlrdr.HasRows
        Catch ex As Exception
            ErrMsg = ex.Message
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Close the data source.
    ''' </summary>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Sub CloseReader()
        Try
            sqlrdr.Close()
            sqlcmd.Dispose()
            sqlcon.Close()
        Catch ex As Exception
            ErrMsg = ex.Message
            LogErrors(ErrMsg)
            If sqlcon.State <> ConnectionState.Closed Then
                sqlcon.Close()
            End If
        End Try
    End Sub

    ''' <summary>
    ''' Try to open database connection.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function Connect() As Boolean
        Try
            sqlcon.Open()
            sqlcon.Close()
            Return True
        Catch ex As Exception
            ErrMsg = ex.Message
            LogErrors(ErrMsg)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Get the physical location of the database.
    ''' </summary>
    ''' <param name="cDbName">Name of the database.</param>
    ''' <returns>String that contains the physical location of the database</returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetDataDir(ByVal cDbName As String) As String
        Dim cFileName As String = ""
        sqlcon.Open()
        sqlcmd = New SqlClient.SqlCommand("select physical_name from master.sys.master_files WHERE databasestrID = DBstrID(N'" & cDbName & "') AND name='" & cDbName & "'", sqlcon)
        sqlrdr = sqlcmd.ExecuteReader()
        If sqlrdr.HasRows Then
            sqlrdr.Read()
            cFileName = sqlrdr(0).ToString
        End If
        sqlrdr.Close()
        sqlcmd.Dispose()
        sqlcon.Close()
        Return cFileName
    End Function

    ''' <summary>
    ''' Backup the database.
    ''' </summary>
    ''' <param name="cDBName">Database name</param>
    ''' <param name="cFileName">File name for the backup</param>
    ''' <param name="cErr">Logs error if there's any.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function Backup(ByVal cDBName As String, ByVal cFileName As String, ByRef cErr As String) As Boolean
        Dim bSuccess As Boolean = False
        bSuccess = RunSql("BACKUP DATABASE " & cDBName & " TO DISK='" & cFileName & "'")
        If Not bSuccess Then cErr = GetLastErrorMessage()
        Return bSuccess
    End Function

    ''' <summary>
    ''' Restore database
    ''' </summary>
    ''' <param name="cDBName">Name of database to restore</param>
    ''' <param name="cFileName">Name of backup file to be restored</param>
    ''' <param name="cErr">Logs error if there's any.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function Restore(ByVal cDBName As String, ByVal cFileName As String, ByRef cErr As String) As Boolean
        Dim bSuccess As Boolean = False
        bSuccess = RunSql("USE MASTER; ALTER DATABASE " & cDBName & " SET SINGLE_USER WITH ROLLBACK IMMEDIATE; RESTORE DATABASE " & cDBName & " FROM DISK='" & cFileName & "' WITH REPLACE; ALTER DATABASE " & cDBName & " SET MULTI_USER")
        If Not bSuccess Then cErr = GetLastErrorMessage()
        Return bSuccess
    End Function

    ''' <summary>
    ''' Gets the last error encountered.
    ''' </summary>
    ''' <returns>Returns the last error encountered.</returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetLastErrorMessage()
        Return ErrMsg
    End Function

    ''' <summary>
    ''' Displays the last encountered error.
    ''' </summary>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Sub ShowLastErrorMessage()
        MsgBox(ErrMsg, MsgBoxStyle.Critical)
    End Sub

End Class
