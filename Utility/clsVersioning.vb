﻿' this is standalone class to support different applications (MPS,WRH,SAS)
Public Class clsVersioning
    Private Const SchemaName As String = "sti_sys"
    Private Const TableName As String = "tblPMSVersion"
    Private nRecordCount As Integer = 0
    Private cErrMsg As String

    'SQL Server connectors
    Private oVersionSqlcon As SqlClient.SqlConnection
    Private oVersionSqladp As SqlClient.SqlDataAdapter
    Private oVersionSqlcmd As SqlClient.SqlCommand
    Private oVersionSqlrdr As SqlClient.SqlDataReader

    'ConnectionString -> Connection string for the specified database or server.
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Sub New(ByVal ConnectionString As String)
        oVersionSqlcon = New SqlClient.SqlConnection(ConnectionString)
    End Sub

#Region "Base Functions"
    'Return the connection string.
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetConnectionString()
        Return oVersionSqlcon.ConnectionString
    End Function

    'Return record count
    <System.Diagnostics.DebuggerStepThrough()> _
    Function RecordCount() As Integer
        Return nRecordCount
    End Function

    'Creates a Recordset, requires sql statement
    <System.Diagnostics.DebuggerStepThrough()> _
    Function oVersionCreateTable(ByVal sql As String) As DataTable
        Dim ctable As New DataTable
        Try
            oVersionSqlcon.Open()
            oVersionSqladp = New SqlClient.SqlDataAdapter(sql, oVersionSqlcon)
            oVersionSqladp.Fill(ctable)
            oVersionSqladp.Dispose()
            oVersionSqlcon.Close()
        Catch ex As Exception
            cErrMsg = ex.Message
            If oVersionSqlcon.State <> ConnectionState.Closed Then
                oVersionSqlcon.Close()
            End If
        End Try
        nRecordCount = ctable.Rows.Count
        Return ctable
    End Function

    'Execute the specified sql statement
    '<System.Diagnostics.DebuggerStepThrough()> _
    Public Function oVersionRunSql(ByVal sql As String, Optional ByVal showErr As Boolean = True) As Boolean
        Dim info As Boolean = True
        Try
            oVersionSqlcmd = New SqlClient.SqlCommand(sql, oVersionSqlcon)
            oVersionSqlcon.Open()

            oVersionSqlcmd.ExecuteNonQuery()
            oVersionSqlcmd.Dispose()
            oVersionSqlcon.Close()
            'Return True
            info = True
        Catch ex As SqlClient.SqlException
            cErrMsg = ex.Message
            LogErrors(cErrMsg)
            info = False
            If showErr Then
                MsgBox(cErrMsg, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, GetAppName)
            End If
            If oVersionSqlcon.State <> ConnectionState.Closed Then
                oVersionSqlcon.Close()
            End If
            Return info
        End Try
        Return info
    End Function

    '<System.Diagnostics.DebuggerStepThrough()> _
    Public Function oVersionDLookUp(ByVal expr As String, ByVal domain As String, ByVal defaultvalue As Object, ByVal Criteria As String) As Object
        Try
            oVersionSqlcon.Open()
            oVersionSqlcmd = New SqlClient.SqlCommand("SELECT TOP 1 " & expr & " FROM " & domain & IIf(Criteria = "", "", " WHERE " & Criteria).ToString, oVersionSqlcon)
            oVersionSqlrdr = oVersionSqlcmd.ExecuteReader()
            If oVersionSqlrdr.HasRows Then
                oVersionSqlrdr.Read()
                If Not (oVersionSqlrdr(0) Is System.DBNull.Value) Then
                    defaultvalue = oVersionSqlrdr(0)
                End If
            End If
            oVersionSqlrdr.Close()
            oVersionSqlcmd.Dispose()
            oVersionSqlcon.Close()
        Catch ex As Exception
            cErrMsg = ex.Message
            If oVersionSqlcon.State <> ConnectionState.Closed Then
                oVersionSqlcon.Close()
            End If
        End Try
        Return defaultvalue
    End Function

#Region "Reader Object"
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Sub BeginReader(ByVal _sql As String)
        Try
            oVersionSqlcon.Open()
            oVersionSqlcmd = New SqlClient.SqlCommand(_sql, oVersionSqlcon)
            oVersionSqlrdr = oVersionSqlcmd.ExecuteReader()
        Catch ex As Exception
            cErrMsg = ex.Message
            If oVersionSqlcon.State <> ConnectionState.Closed Then
                oVersionSqlcon.Close()
            End If
        End Try
    End Sub

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function Read()
        Try
            Return oVersionSqlrdr.Read()
        Catch ex As Exception
            cErrMsg = ex.Message
            Return False
        End Try
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function ReaderItem(ByVal index As Integer) As Object
        Try
            Return oVersionSqlrdr.Item(index)
        Catch ex As Exception
            cErrMsg = ex.Message
            Return System.DBNull.Value
        End Try
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function ReaderItem(ByVal name As String) As Object
        Try
            Return oVersionSqlrdr.Item(name)
        Catch ex As Exception
            cErrMsg = ex.Message
            Return System.DBNull.Value
        End Try
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function ReaderItem(ByVal name As String, ByVal defaultvalue As Object) As Object
        Try
            If oVersionSqlrdr.Item(name) Is System.DBNull.Value Then
                Return defaultvalue
            Else
                Return oVersionSqlrdr.Item(name)
            End If
        Catch ex As Exception
            cErrMsg = ex.Message
            Return defaultvalue
        End Try
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function ReaderItem(ByVal index As Integer, ByVal defaultvalue As Object) As Object
        Try
            If oVersionSqlrdr.Item(index) Is System.DBNull.Value Then
                Return defaultvalue
            Else
                Return oVersionSqlrdr.Item(index)
            End If
        Catch ex As Exception
            cErrMsg = ex.Message
            Return defaultvalue
        End Try
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function ReaderItemCount() As Integer
        Try
            Return oVersionSqlrdr.FieldCount
        Catch ex As Exception
            cErrMsg = ex.Message
            Return 0
        End Try
    End Function

    '<System.Diagnostics.DebuggerStepThrough()> _
    Public Function HasRows() As Boolean
        Try
            Return oVersionSqlrdr.HasRows
        Catch ex As Exception
            cErrMsg = ex.Message
            Return False
        End Try
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Sub CloseReader()
        Try
            oVersionSqlrdr.Close()
            oVersionSqlcmd.Dispose()
            oVersionSqlcon.Close()
        Catch ex As Exception
            cErrMsg = ex.Message
            If oVersionSqlcon.State <> ConnectionState.Closed Then
                oVersionSqlcon.Close()
            End If
        End Try
    End Sub
#End Region

#End Region

#Region "Class Functions"
    ' collection of function related for versioning STI applications
    ' Parameters:
    Public Function IsInitialized(ByVal cCurInterfaceVersion As String) As Boolean
        Dim bSuccess As Boolean = True

        If InitVersionSchema() Then
            'schema exist
            If InitVersionTable() Then
                bSuccess = True
            Else
                bSuccess = False
            End If

            'check if Version Table has a base version
            If bSuccess Then
                bSuccess = CheckVersionTable(cCurInterfaceVersion)
            End If
        Else
            bSuccess = False
        End If

        Return bSuccess
    End Function

    Public Function IsVersionUpdated(ByRef cInterfaceVersion As String, ByRef curDBVersion As String, Optional ByRef cErr As String = "") As Boolean
        Dim bReturn As Boolean = False

        'Get Latest Version
        curDBVersion = CType(oVersionDLookUp("AppVersion", "[" & SchemaName & "].[dbo].[" & TableName & "]", "5.00.00", "1=1 ORDER BY AppVersion DESC"), String)
        If CType(cInterfaceVersion, String) = curDBVersion Then
            bReturn = True
        Else
            bReturn = False
        End If

        Return bReturn
    End Function

    Public Function oGetAllVersionUpdates() As DataTable
        Dim dtReturn As New DataTable
        dtReturn = oVersionCreateTable("SELECT * FROM [" & SchemaName & "].[dbo].[" & TableName & "] ORDER BY AppVersion DESC")
        Return dtReturn
    End Function

    Public Function oGetLatestVersions(ByVal cCurVersion As String) As DataTable
        Dim dtReturn As New DataTable
        dtReturn = oVersionCreateTable("SELECT * FROM [" & SchemaName & "].[dbo].[" & TableName & "] WHERE AppVersion>'" & cCurVersion & "' ORDER BY AppVersion ASC")
        Return dtReturn
    End Function

    Public Function IsNewVersion(ByVal CurDBVersion As String, ByVal cInterfaceVersion As String) As Boolean
        Dim NewVersion() As String = Split(CurDBVersion, "."c)
        Dim OldVersion() As String = Split(cInterfaceVersion, "."c)

        'This is used to count the number of times that the test below finds an equal match
        Dim bNewerVersion As Boolean = False

        For s As Integer = 0 To 2
            If CType(NewVersion(s), Integer) > CType(OldVersion(s), Integer) Then
                bNewerVersion = True
                Exit For
            ElseIf CType(NewVersion(s), Integer) < CType(OldVersion(s), Integer) Then
                bNewerVersion = False
                Exit For
            End If
        Next

        Return bNewerVersion

    End Function

    Private Function InitVersionSchema() As Boolean
        Dim bReturn As Boolean = True
        BeginReader("SELECT DB_ID('" & SchemaName & "') as DatabaseID")
        Read()
        Dim DBID As String = IfNull(ReaderItem("DatabaseID"), "")
        CloseReader()
        If DBID = "" Then
            'no schema
            'try to create
            bReturn = oVersionRunSql("CREATE DATABASE " & SchemaName)
        Else
            bReturn = True
        End If
        Return bReturn
    End Function

    Private Function InitVersionTable() As Boolean
        Dim bReturn As Boolean = True

        BeginReader("select object_id from " & SchemaName & ".sys.tables Where Name='" & TableName & "'")
        Read()
        Dim cObjectID As String = IfNull(ReaderItem("object_id"), "")
        CloseReader()
        If cObjectID <> "" Then
            bReturn = True
        Else
            'try to create TableVersion
            Dim cCreateSql As String = "CREATE TABLE [" & SchemaName & "].[dbo].[" & TableName & "]( [AppVersion] [varchar](8) NOT NULL, [ObjectPath] [varchar](200) NULL, [VersionDesc] [text] NULL, [VersionDate] [datetime] NULL, [LoadedBy] [varchar](200) NULL, [DateLoaded] [datetime] NULL,CONSTRAINT [PK_" & TableName & "] PRIMARY KEY CLUSTERED ( [AppVersion] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]"
            Dim cAlterSql As String = "ALTER TABLE [" & SchemaName & "].[dbo].[" & TableName & "] ADD  CONSTRAINT [DF_" & TableName & "_DateLoaded]  DEFAULT (getdate()) FOR [DateLoaded]"
            bReturn = oVersionRunSql(cCreateSql)
            bReturn = bReturn And oVersionRunSql(cAlterSql)
        End If
        Return bReturn
    End Function

    Private Function CheckVersionTable(ByVal cCurVersion As String) As Boolean
        Dim bVersionTableStat As Boolean = False

        Dim oVersionTable As New DataTable
        oVersionTable = oVersionCreateTable("SELECT * FROM [" & SchemaName & "].[dbo].[" & TableName & "]")

        If oVersionTable.Rows.Count > 0 Then
            bVersionTableStat = True
        Else
            'Add Base Version
            bVersionTableStat = oVersionRunSql("INSERT INTO [" & SchemaName & "].[dbo].[" & TableName & "] " & _
                                               "([AppVersion],[ObjectPath],[VersionDesc],[VersionDate],[LoadedBy],[DateLoaded])" & _
                                               " VALUES('" & cCurVersion & "', NULL, 'Base Version', GETDATE(), '" & TableName & "', GETDATE())")
        End If

        Return bVersionTableStat
    End Function

#End Region

#Region "Misc Functions"
    Public Function GetFileNamesFromPath(ByVal cPathDir As String, Optional ByVal cDelemiter As String = ";", Optional ByVal Filter As String = "*.*", Optional ByVal searchOption As System.IO.SearchOption = IO.SearchOption.TopDirectoryOnly) As String
        Dim cReturnStr As String = ""
        Dim oFilesFiltered() As String = getFiles(cPathDir, Filter, searchOption)
        Dim f As String
        For Each f In oFilesFiltered
            cReturnStr = cReturnStr & System.IO.Path.GetFileName(f.ToString) & cDelemiter
        Next
        Return cReturnStr
    End Function

    Public Function getFiles(ByVal SourceFolder As String, ByVal Filter As String, _
    ByVal searchOption As System.IO.SearchOption) As String()
        ' ArrayList will hold all file names
        Dim alFiles As ArrayList = New ArrayList()

        ' Create an array of filter string
        Dim MultipleFilters() As String = Filter.Split("|")

        ' for each filter find mathing file names
        For Each FileFilter As String In MultipleFilters
            ' add found file names to array list
            alFiles.AddRange(System.IO.Directory.GetFiles(SourceFolder, FileFilter, searchOption))
        Next

        ' returns string array of relevant file names
        Return alFiles.ToArray(Type.GetType("System.String"))
    End Function
#End Region

End Class



