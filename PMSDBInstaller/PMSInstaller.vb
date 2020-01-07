Imports System.IO
Imports System.Reflection
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Configuration.Install

Public Class PMSInstaller

    Dim SQLVERSION As String = "2012" ' values should be ( 2008 | 2012 | 2014 )

    'Dim strMasterCon As String = "Data Source=.\STISQLSERVER;Initial Catalog=master;Integrated Security=True"
    Dim strMasterCon As String = "Data Source=.\STISQLSERVER;Initial Catalog=master;Persist Security Info=True;User ID=sa;Password=sffSDfsdfdfSDFsdffDFSF2164564DFSD2Df2345ABCSTFS"

    Dim masterConnection As New System.Data.SqlClient.SqlConnection

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add initialization code after the call to InitializeComponent

    End Sub

    Private Function GetSql(ByVal Name As String) As String
        Try

            ' Gets the current assembly.
            Dim Asm As [Assembly] = [Assembly].GetExecutingAssembly()

            ' Resources are named using a fully qualified name.
            Dim strm As Stream = Asm.GetManifestResourceStream(
              Asm.GetName().Name + "." + Name)

            ' Reads the contents of the embedded file.
            Dim reader As StreamReader = New StreamReader(strm)
            Return reader.ReadToEnd()

        Catch ex As Exception
            MsgBox("In GetSQL: " & ex.Message)
            Throw ex
        End Try
    End Function

    Private Sub ExecuteSql(ByVal DatabaseName As String, ByVal Sql As String, Optional ByVal bFContinue As Boolean = False)
        Dim Command As New SqlClient.SqlCommand(Sql, masterConnection)

        ' Initialize the connection, open it, and set it to the "master" database
        masterConnection.ConnectionString = strMasterCon
        Command.Connection.Open()
        Command.Connection.ChangeDatabase(DatabaseName)
        Try
            If bFContinue Then
                ' ignore errors
                Try
                    Command.ExecuteNonQuery()
                Catch ex As Exception
                End Try
            Else
                Command.ExecuteNonQuery()
            End If
        Finally
            ' Closing the connection should be done in a Finally block
            Command.Connection.Close()
        End Try
    End Sub

    Protected Sub AttachDatabases(ByVal strDBName As String, ByVal installdir As String)
        Try
            ' Attaches database.
            Select Case SQLVERSION

                Case "2008"
                    ExecuteSql("master", "CREATE DATABASE [pms_db] ON " & _
                        "( FILENAME = N'C:\Spectral\Microsoft SQL Server\MSSQL10_50.STISQLSERVER\MSSQL\Data\pms_db.mdf' )," & _
                        "( FILENAME = N'C:\Spectral\Microsoft SQL Server\MSSQL10_50.STISQLSERVER\MSSQL\Data\pms_db_log.ldf' ) " & _
                        "FOR ATTACH;")

                    ExecuteSql("master", "CREATE DATABASE [sas_tbl] ON " & _
                        "( FILENAME = N'C:\Spectral\Microsoft SQL Server\MSSQL10_50.STISQLSERVER\MSSQL\Data\sas_tbl.mdf' )," & _
                        "( FILENAME = N'C:\Spectral\Microsoft SQL Server\MSSQL10_50.STISQLSERVER\MSSQL\Data\sas_tbl_log.ldf' ) " & _
                        "FOR ATTACH;")

                    ExecuteSql("master", "CREATE DATABASE [sasa_tbl] ON " & _
                        "( FILENAME = N'C:\Spectral\Microsoft SQL Server\MSSQL10_50.STISQLSERVER\MSSQL\Data\sasa_tbl.mdf' )," & _
                        "( FILENAME = N'C:\Spectral\Microsoft SQL Server\MSSQL10_50.STISQLSERVER\MSSQL\Data\sasa_tbl_log.ldf' ) " & _
                        "FOR ATTACH;")

                Case "2012"
                    ExecuteSql("master", "CREATE DATABASE [pms_db] ON " & _
                        "( FILENAME = N'C:\Spectral\Microsoft SQL Server\MSSQL11.STISQLSERVER\MSSQL\Data\pms_db.mdf' )," & _
                        "( FILENAME = N'C:\Spectral\Microsoft SQL Server\MSSQL11.STISQLSERVER\MSSQL\Data\pms_db_log.ldf' ) " & _
                        "FOR ATTACH;")

                    ExecuteSql("master", "CREATE DATABASE [sas_tbl] ON " & _
                        "( FILENAME = N'C:\Spectral\Microsoft SQL Server\MSSQL11.STISQLSERVER\MSSQL\Data\sas_tbl.mdf' )," & _
                        "( FILENAME = N'C:\Spectral\Microsoft SQL Server\MSSQL11.STISQLSERVER\MSSQL\Data\sas_tbl_log.ldf' ) " & _
                        "FOR ATTACH;")

                    ExecuteSql("master", "CREATE DATABASE [sasa_tbl] ON " & _
                        "( FILENAME = N'C:\Spectral\Microsoft SQL Server\MSSQL11.STISQLSERVER\MSSQL\Data\sasa_tbl.mdf' )," & _
                        "( FILENAME = N'C:\Spectral\Microsoft SQL Server\MSSQL11.STISQLSERVER\MSSQL\Data\sasa_tbl_log.ldf' ) " & _
                        "FOR ATTACH;")

                Case "2014"

            End Select
            

            ' Creates the tables.
            'ExecuteSql(strDBName, GetSql("sql.txt"))



        Catch ex As Exception
            ' Reports any errors and abort.
            MsgBox("In exception handler: " & ex.Message)
            Throw ex
        End Try
    End Sub

    Public Overrides Sub Install(ByVal stateSaver As System.Collections.IDictionary)

        MyBase.Install(stateSaver)
        'Dim ssss As String = ""
        'For Each Str As String In Context.Parameters.Keys
        '    ssss = ssss & "Key:" & Str & "Value:" & Context.Parameters(Str) & vbNewLine
        'Next
        'MsgBox(ssss)
        AttachDatabases(Me.Context.Parameters.Item("dbname"), Me.Context.Parameters.Item("assemblypath"))
    End Sub

    Public Overrides Sub Uninstall(savedState As System.Collections.IDictionary)
        MyBase.Uninstall(savedState)
        'run these scripts and force continue
        ExecuteSql("master", "ALTER DATABASE pms_db SET SINGLE_USER with rollback immediate", True)
        ExecuteSql("master", "DROP DATABASE [pms_db]", True)
        ExecuteSql("master", "ALTER DATABASE sas_tbl SET SINGLE_USER with rollback immediate", True)
        ExecuteSql("master", "DROP DATABASE [sas_tbl]", True)
        ExecuteSql("master", "ALTER DATABASE sasa_tbl SET SINGLE_USER with rollback immediate", True)
        ExecuteSql("master", "DROP DATABASE [sasa_tbl]", True)
        ExecuteSql("master", "DROP TABLE [sti_sys].[dbo].[tblPMSConfig]", True)
        ExecuteSql("master", "DROP TABLE [sti_sys].[dbo].[tblPMSVersion]", True)
    End Sub

End Class
