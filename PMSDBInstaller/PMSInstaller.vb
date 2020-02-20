Imports System.IO
Imports System.Reflection
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Configuration.Install

Public Class PMSInstaller

    Dim SQLVERSION As String = "2012" ' values should be ( 2008 | 2012 | 2014 )
    Const APP_SHORT_NAME As String = "PMS", DB_NAME As String = "pms_db"
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

                Case "2012"
                    ExecuteSql("master", "CREATE DATABASE [" & DB_NAME & "] ON " & _
                        "( FILENAME = N'C:\Spectral\Microsoft SQL Server\MSSQL11.STISQLSERVER\MSSQL\Data\" & DB_NAME & ".mdf' )," & _
                        "( FILENAME = N'C:\Spectral\Microsoft SQL Server\MSSQL11.STISQLSERVER\MSSQL\Data\" & DB_NAME & "_log.ldf' ) " & _
                        "FOR ATTACH;")

                    ExecuteSql("master", "IF NOT EXISTS (SELECT Name FROM dbo.sysdatabases WHERE name ='sti_sys') CREATE DATABASE sti_sys")
                    ExecuteSql("master", "IF NOT EXISTS (SELECT Name FROM dbo.sysdatabases WHERE name ='sas_tbl') CREATE DATABASE sas_tbl")
                    ExecuteSql("sti_sys", "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='tbl" & APP_SHORT_NAME & "Config') CREATE TABLE [dbo].[tbl" & APP_SHORT_NAME & "Config]([Code] [varchar](30) NOT NULL,[Value] [varchar](max) NULL, CONSTRAINT [PK_tbl" & APP_SHORT_NAME & "Config] PRIMARY KEY CLUSTERED([Code] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]")
                    ExecuteSql("sti_sys", "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='tblTableConfig') CREATE TABLE [dbo].[tblTableConfig]([AppShortName] [varchar](10) NOT NULL,[DBName] [varchar](15) NOT NULL,[TableName] [varchar](50) NOT NULL,CONSTRAINT [PK_tblTableConfig] PRIMARY KEY CLUSTERED ([AppShortName] ASC,[DBName] ASC,[TableName] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]")
                    ExecuteSql("sti_sys", "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='tblCompanyInfo') CREATE TABLE [dbo].[tblCompanyInfo]([Name] [varchar](50) NOT NULL,[Phone] [varchar](15) NULL,[Email] [varchar](30) NULL,[Address] [varchar](max) NULL,[Logo] [varbinary](max) NULL) ON [PRIMARY]")

                    'ADD SAS ADMIN TABLES
                    ExecuteSql("sas_tbl", "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='tblAdmVsl') CREATE TABLE [dbo].[tblAdmVsl]([VslCode] [varchar](15) NOT NULL,[Name] [varchar](30) NULL,[VslTypeCode] [varchar](15) NULL,[Flag] [varchar](15) NULL,[Email] [varchar](200) NULL,[IMONo] [varchar](50) NULL,CONSTRAINT [tblAdmVsl$PrimaryKey] PRIMARY KEY CLUSTERED ([VslCode] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]")
                    ExecuteSql("sas_tbl", My.Resources.country)
                    ExecuteSql("sas_tbl", My.Resources.Department)
                    ExecuteSql("sas_tbl", My.Resources.rank)
                    ExecuteSql("sas_tbl", My.Resources.port)
                    ExecuteSql("sas_tbl", My.Resources.vesseltype)
                    ExecuteSql("sas_tbl", My.Resources.ranktype)

                    'ADD SAS ADMIN TABLES TO TABLE CONFIG
                    ExecuteSql("sti_sys", "IF NOT EXISTS (SELECT * FROM dbo.tblTableConfig WHERE AppShortName ='" & APP_SHORT_NAME & "' AND DBName='sas_tbl' AND TableName='tblAdmVsl') INSERT INTO dbo.tblTableConfig VALUES('" & APP_SHORT_NAME & "','sas_tbl','tblAdmVsl')")
                    ExecuteSql("sti_sys", "IF NOT EXISTS (SELECT * FROM dbo.tblTableConfig WHERE AppShortName ='" & APP_SHORT_NAME & "' AND DBName='sas_tbl' AND TableName='tblAdmCntry') INSERT INTO dbo.tblTableConfig VALUES('" & APP_SHORT_NAME & "','sas_tbl','tblAdmCntry')")
                    ExecuteSql("sti_sys", "IF NOT EXISTS (SELECT * FROM dbo.tblTableConfig WHERE AppShortName ='" & APP_SHORT_NAME & "' AND DBName='sas_tbl' AND TableName='tblAdmDept') INSERT INTO dbo.tblTableConfig VALUES('" & APP_SHORT_NAME & "','sas_tbl','tblAdmDept')")
                    ExecuteSql("sti_sys", "IF NOT EXISTS (SELECT * FROM dbo.tblTableConfig WHERE AppShortName ='" & APP_SHORT_NAME & "' AND DBName='sas_tbl' AND TableName='tblAdmRank') INSERT INTO dbo.tblTableConfig VALUES('" & APP_SHORT_NAME & "','sas_tbl','tblAdmRank')")
                    ExecuteSql("sti_sys", "IF NOT EXISTS (SELECT * FROM dbo.tblTableConfig WHERE AppShortName ='" & APP_SHORT_NAME & "' AND DBName='sas_tbl' AND TableName='tblAdmPort') INSERT INTO dbo.tblTableConfig VALUES('" & APP_SHORT_NAME & "','sas_tbl','tblAdmPort')")
                    ExecuteSql("sti_sys", "IF NOT EXISTS (SELECT * FROM dbo.tblTableConfig WHERE AppShortName ='" & APP_SHORT_NAME & "' AND DBName='sas_tbl' AND TableName='tblAdmVslType') INSERT INTO dbo.tblTableConfig VALUES('" & APP_SHORT_NAME & "','sas_tbl','tblAdmVslType')")
                    ExecuteSql("sti_sys", "IF NOT EXISTS (SELECT * FROM dbo.tblTableConfig WHERE AppShortName ='" & APP_SHORT_NAME & "' AND DBName='sas_tbl' AND TableName='tblAdmVslType') INSERT INTO dbo.tblTableConfig VALUES('" & APP_SHORT_NAME & "','sas_tbl','tblAdmRankType')")

                    'Default Settings
                    ExecuteSql("sti_sys", "IF NOT EXISTS (SELECT * FROM [dbo].[tbl" & APP_SHORT_NAME & "Config] WHERE [Code] = 'LOCATION_ID') INSERT INTO [dbo].[tbl" & APP_SHORT_NAME & "Config]([Code],[Value]) VALUES('LOCATION_ID','')")
                    ExecuteSql("sti_sys", "IF NOT EXISTS (SELECT * FROM [dbo].[tbl" & APP_SHORT_NAME & "Config] WHERE [Code] = 'HIDE_COPY_INSTRUCTION') INSERT INTO [dbo].[tbl" & APP_SHORT_NAME & "Config]([Code],[Value]) VALUES('HIDE_COPY_INSTRUCTION','0')")
                    ExecuteSql("sti_sys", "IF NOT EXISTS (SELECT * FROM [dbo].[tbl" & APP_SHORT_NAME & "Config] WHERE [Code] = 'KPITHRESHOLD') INSERT INTO [dbo].[tbl" & APP_SHORT_NAME & "Config]([Code],[Value]) VALUES('KPITHRESHOLD','4.0')")
                    ExecuteSql("sti_sys", "IF NOT EXISTS (SELECT * FROM [dbo].[tbl" & APP_SHORT_NAME & "Config] WHERE [Code] = 'DATE_LAST_EXPORT') INSERT INTO [dbo].[tbl" & APP_SHORT_NAME & "Config]([Code],[Value]) VALUES('DATE_LAST_EXPORT','2000-01-01')")
                    ExecuteSql("sti_sys", "IF NOT EXISTS (SELECT * FROM [dbo].[tbl" & APP_SHORT_NAME & "Config] WHERE [Code] = 'DATE_LAST_EXPORT_IMG') INSERT INTO [dbo].[tbl" & APP_SHORT_NAME & "Config]([Code],[Value]) VALUES('DATE_LAST_EXPORT_IMG','2000-01-01')")
                    ExecuteSql("sti_sys", "IF NOT EXISTS (SELECT * FROM [dbo].[tbl" & APP_SHORT_NAME & "Config] WHERE [Code] = 'EXPORT_DIR') INSERT INTO [dbo].[tbl" & APP_SHORT_NAME & "Config]([Code],[Value]) VALUES('EXPORT_DIR','')")
                    ExecuteSql("sti_sys", "IF NOT EXISTS (SELECT * FROM [dbo].[tbl" & APP_SHORT_NAME & "Config] WHERE [Code] = 'DUE_DAYS') INSERT INTO [dbo].[tbl" & APP_SHORT_NAME & "Config]([Code],[Value]) VALUES('DUE_DAYS','30')")
                    ExecuteSql("sti_sys", "IF NOT EXISTS (SELECT * FROM [dbo].[tbl" & APP_SHORT_NAME & "Config] WHERE [Code] = 'DUE_HOURS') INSERT INTO [dbo].[tbl" & APP_SHORT_NAME & "Config]([Code],[Value]) VALUES('DUE_HOURS','100')")
                    ExecuteSql("sti_sys", "IF NOT EXISTS (SELECT * FROM [dbo].[tbl" & APP_SHORT_NAME & "Config] WHERE [Code] = 'SPARE_VENDOR_SELECTED') INSERT INTO [dbo].[tbl" & APP_SHORT_NAME & "Config]([Code],[Value]) VALUES('SPARE_VENDOR_SELECTED','True')")
                    ExecuteSql("sti_sys", "IF NOT EXISTS (SELECT * FROM [dbo].[tbl" & APP_SHORT_NAME & "Config] WHERE [Code] = 'SPARE_ADDRESS_VALUE') INSERT INTO [dbo].[tbl" & APP_SHORT_NAME & "Config]([Code],[Value]) VALUES('SPARE_ADDRESS_VALUE','')")
                    ExecuteSql("sti_sys", "IF NOT EXISTS (SELECT * FROM [dbo].[tbl" & APP_SHORT_NAME & "Config] WHERE [Code] = 'IMAGE_MAX_RES') INSERT INTO [dbo].[tbl" & APP_SHORT_NAME & "Config]([Code],[Value]) VALUES('IMAGE_MAX_RES','800')")

                    '*********Settings for Versioning,License And Program Distribution************
                    ExecuteSql("sti_sys", "IF NOT EXISTS (SELECT * FROM [dbo].[tbl" & APP_SHORT_NAME & "Config] WHERE [Code] = 'UpdatesFolder') INSERT INTO [dbo].[tbl" & APP_SHORT_NAME & "Config]([Code],[Value]) VALUES('UpdatesFolder','')")
                    ExecuteSql("sti_sys", "IF NOT EXISTS (SELECT * FROM [dbo].[tbl" & APP_SHORT_NAME & "Config] WHERE [Code] = 'LTYPE') INSERT INTO [dbo].[tbl" & APP_SHORT_NAME & "Config]([Code],[Value]) VALUES('LTYPE','025047065065148052055028037015022026145')")
                    ExecuteSql("sti_sys", "IF NOT EXISTS (SELECT * FROM [dbo].[tbl" & APP_SHORT_NAME & "Config] WHERE [Code] = 'PROGRAMFILES') INSERT INTO [dbo].[tbl" & APP_SHORT_NAME & "Config]([Code],[Value]) VALUES('PROGRAMFILES','Admin.dll;BaseControl.dll;Crewing.dll;License.dll;Security.dll;Tools.dll;Utility.dll;Maintenance.dll;PlannedMaintenance.exe;PMSReports.dll')")

                    'Add Trial Lic
                    ExecuteSql(DB_NAME, "IF NOT EXISTS (SELECT * FROM [dbo].[tblSTI]) INSERT INTO [dbo].[tblSTI]([LAppName],[LType],[LExp],[LHID],[LImo],[LSKey],[LGPeriod],[LNum],[LValid],[LGen],[LStat],[LMsg],[LRem],[DateUpdated]) VALUES('" & sysMpsUserPassword("ENCRYPT", APP_SHORT_NAME) & "', '" & sysMpsUserPassword("ENCRYPT", "TRIAL") & "','" & sysMpsUserPassword("ENCRYPT", "NULL") & "','" & sysMpsUserPassword("ENCRYPT", "NULL") & "','" & sysMpsUserPassword("ENCRYPT", "NULL") & "','" & sysMpsUserPassword("ENCRYPT", "NULL") & "','" & sysMpsUserPassword("ENCRYPT", "NULL") & "','" & sysMpsUserPassword("ENCRYPT", "NULL") & "','" & sysMpsUserPassword("ENCRYPT", "NULL") & "','" & sysMpsUserPassword("ENCRYPT", "NULL") & "','" & sysMpsUserPassword("ENCRYPT", "NULL") & "','" & sysMpsUserPassword("ENCRYPT", "NULL") & "','" & sysMpsUserPassword("ENCRYPT", "NULL") & "',GETDATE())")

                    'tblSTIService_profile
                    ExecuteSql("sti_sys", "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='tblSTIService_profile')" & _
                             "CREATE TABLE [dbo].[tblSTIService_profile](" & _
                             "[PROF_Code] [varchar](15) NOT NULL," & _
                             "[PROF_Name] [varchar](50) NULL," & _
                             "[PROF_Comment] [text] NULL," & _
                             "[PROF_ExpFolder] [varchar](100) NULL," & _
                             "[DateUpdated] [datetime] NULL," & _
                             "CONSTRAINT [PK_tblSTIService_profile] PRIMARY KEY CLUSTERED" & _
                             "(" & _
                                    "[PROF_Code] Asc " & _
                             ")WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]" & _
                             ") ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]")

                    'tblSTIService_internet_settings
                    ExecuteSql("sti_sys", "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='tblSTIService_internet_settings') " & _
                             "CREATE TABLE [dbo].[tblSTIService_internet_settings](" & _
                             "[INET_Code] [varchar](15) NOT NULL," & _
                             "[INET_ProfileName] [varchar](50) NULL," & _
                             "[INET_User] [text] NULL," & _
                             "[INET_Pwd] [text] NULL," & _
                             "[INET_AutoRemoveFiles] [int] NULL," & _
                             "[FTP_ConnectionTimeout] [int] NULL," & _
                             "[INET_Host] [text] NULL," & _
                             "[FTP_UsePassive] [int] NULL," & _
                             "[FTP_AutoFeat] [int] NULL," & _
                             "[INET_Port] [int] NULL," & _
                             "[INET_UseSSL] [int] NULL," & _
                             "[INET_TLS] [int] NULL," & _
                             "[INET_SPA] [int] NULL," & _
                             "[INET_Type] [int] NULL," & _
                             "[SMTP_SenderEmail] [text] NULL," & _
                             "[EMAIL_TYPE] [int] NULL," & _
                             "[DateUpdated] [datetime] NULL," & _
                             "CONSTRAINT [PK_tblSTIService_internet_settings] PRIMARY KEY CLUSTERED " & _
                             "(" & _
                                    "[INET_Code] Asc " & _
                             ")WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]" & _
                             ") ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]")

                    '*********************** Add Default PMS Backup Profile *********************
                    ExecuteSql("sti_sys", "IF NOT EXISTS (SELECT * FROM [dbo].[tblSTIService_profile] WHERE [PROF_Code] = 'SYS_BACKUP_" & APP_SHORT_NAME & "') INSERT INTO [dbo].[tblSTIService_profile]([PROF_Code],[PROF_Name],[PROF_Comment],[PROF_ExpFolder]) VALUES('SYS_BACKUP_" & APP_SHORT_NAME & "','" & APP_SHORT_NAME & "BACKUP','Default " & APP_SHORT_NAME & " Backup Profile','C:\Spectral\" & APP_SHORT_NAME & " Backups')")
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
        ExecuteSql("master", "ALTER DATABASE " & DB_NAME & " SET SINGLE_USER with rollback immediate", True)
        ExecuteSql("master", "DROP DATABASE [" & DB_NAME & "]", True)
        ExecuteSql("master", "DROP TABLE [sti_sys].[dbo].[tbl" & APP_SHORT_NAME & "Config]", True)
        ExecuteSql("master", "DROP TABLE [sti_sys].[dbo].[tbl" & APP_SHORT_NAME & "Version]", True)

        'DELETE TABLES FROM TableConfig
        ExecuteSql("sti_sys", "DELETE FROM dbo.tblTableConfig WHERE AppShortName ='" & APP_SHORT_NAME & "' AND DBName='sas_tbl' AND TableName IN('tblAdmCntry','tblAdmRank','tblAdmPort','tblAdmDept','tblAdmVsl','tblAdmVslType','tblAdmRankType')")

        'DELETE TABLE IF NO APPLICATION USES IT.
        ExecuteSql("master", "IF NOT EXISTS (SELECT * FROM sti_sys.dbo.tblTableConfig WHERE DBName='sas_tbl' AND TableName='tblAdmCntry') DROP TABLE [sas_tbl].[dbo].[tblAdmCntry]")
        ExecuteSql("master", "IF NOT EXISTS (SELECT * FROM sti_sys.dbo.tblTableConfig WHERE DBName='sas_tbl' AND TableName='tblAdmRank') DROP TABLE [sas_tbl].[dbo].[tblAdmRank]")
        ExecuteSql("master", "IF NOT EXISTS (SELECT * FROM sti_sys.dbo.tblTableConfig WHERE DBName='sas_tbl' AND TableName='tblAdmPort') DROP TABLE [sas_tbl].[dbo].[tblAdmPort]")
        ExecuteSql("master", "IF NOT EXISTS (SELECT * FROM sti_sys.dbo.tblTableConfig WHERE DBName='sas_tbl' AND TableName='tblAdmDept') DROP TABLE [sas_tbl].[dbo].[tblAdmDept]")
        ExecuteSql("master", "IF NOT EXISTS (SELECT * FROM sti_sys.dbo.tblTableConfig WHERE DBName='sas_tbl' AND TableName='tblAdmVsl') DROP TABLE [sas_tbl].[dbo].[tblAdmVsl]")
        ExecuteSql("master", "IF NOT EXISTS (SELECT * FROM sti_sys.dbo.tblTableConfig WHERE DBName='sas_tbl' AND TableName='tblAdmVslType') DROP TABLE [sas_tbl].[dbo].[tblAdmVslType]")
        ExecuteSql("master", "IF NOT EXISTS (SELECT * FROM sti_sys.dbo.tblTableConfig WHERE DBName='sas_tbl' AND TableName='tblAdmRankType') DROP TABLE [sas_tbl].[dbo].[tblAdmRankType]")

        'DELETE DATABASE IF NO APPLISTION USES IT.
        ExecuteSql("master", "IF NOT EXISTS (SELECT * FROM sti_sys.dbo.tblTableConfig WHERE DBName='sas_tbl') DROP DATABASE [sas_tbl]")
    End Sub

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

End Class
