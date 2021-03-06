/*
   Wednesday, February 12, 20205:56:42 AM
   User: sa
   Server: localhost\sqlexpress
   Database: pms_db
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.AuditLog
	DROP CONSTRAINT DF_AuditLog_DateExport
GO
CREATE TABLE dbo.Tmp_AuditLog
	(
	AuditLogID bigint NOT NULL IDENTITY (1, 1),
	CrewID nvarchar(30) NULL,
	ScreenCaption nvarchar(150) NULL,
	ActionDescrip nvarchar(50) NULL,
	TableName nvarchar(50) NULL,
	PKeyField nvarchar(30) NULL,
	PKeyValue nvarchar(20) NULL,
	DataDescrip nvarchar(300) NULL,
	UserName nvarchar(250) NULL,
	ComputerName nvarchar(250) NULL,
	ModuleCode tinyint NULL,
	DateUpdated datetime2(0) NULL,
	DExDate datetime2(0) NULL,
	AdditionalInfo nvarchar(100) NULL,
	SiteID nvarchar(20) NOT NULL,
	RecordKeyName nvarchar(300) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_AuditLog SET (LOCK_ESCALATION = TABLE)
GO
DECLARE @v sql_variant 
SET @v = N'form caption '
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_AuditLog', N'COLUMN', N'ScreenCaption'
GO
DECLARE @v sql_variant 
SET @v = N'Add,Update,Delete, Sign-off, sign-on, mps open, user logs,user log-out, plan crew, MPS close, transfer to archive/active etc'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_AuditLog', N'COLUMN', N'ActionDescrip'
GO
DECLARE @v sql_variant 
SET @v = N'primary key field ex '
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_AuditLog', N'COLUMN', N'PKeyField'
GO
DECLARE @v sql_variant 
SET @v = N'biodata info, sea service, admin, certificates, relatives, payroll'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_AuditLog', N'COLUMN', N'DataDescrip'
GO
DECLARE @v sql_variant 
SET @v = N'user log name'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_AuditLog', N'COLUMN', N'UserName'
GO
DECLARE @v sql_variant 
SET @v = N'computer name / ip '
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_AuditLog', N'COLUMN', N'ComputerName'
GO
DECLARE @v sql_variant 
SET @v = N'1;mps, 2;mps archive, 3;docreader; 4;mpsi 5;ltp'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_AuditLog', N'COLUMN', N'ModuleCode'
GO
DECLARE @v sql_variant 
SET @v = N'future use..ex for multi degree sub child table. parent table;recordid > child1;recordid > child1.1;recordid'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'Tmp_AuditLog', N'COLUMN', N'AdditionalInfo'
GO
ALTER TABLE dbo.Tmp_AuditLog ADD CONSTRAINT
	DF_AuditLog_DateExport DEFAULT (getdate()) FOR DExDate
GO
SET IDENTITY_INSERT dbo.Tmp_AuditLog ON
GO
IF EXISTS(SELECT * FROM dbo.AuditLog)
	 EXEC('INSERT INTO dbo.Tmp_AuditLog (AuditLogID, CrewID, ScreenCaption, ActionDescrip, TableName, PKeyField, PKeyValue, DataDescrip, UserName, ComputerName, ModuleCode, DateUpdated, DExDate, AdditionalInfo, SiteID, RecordKeyName)
		SELECT AuditLogID, CrewID, ScreenCaption, ActionDescrip, TableName, PKeyField, PKeyValue, DataDescrip, UserName, ComputerName, ModuleCode, DateUpdated, DExDate, AdditionalInfo, SiteID, RecordKeyName FROM dbo.AuditLog WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_AuditLog OFF
GO
ALTER TABLE dbo.AuditDetails
	DROP CONSTRAINT FK_AuditDetails_AuditLog
GO
DROP TABLE dbo.AuditLog
GO
EXECUTE sp_rename N'dbo.Tmp_AuditLog', N'AuditLog', 'OBJECT' 
GO
ALTER TABLE dbo.AuditLog ADD CONSTRAINT
	PK_AuditLog_1 PRIMARY KEY CLUSTERED 
	(
	AuditLogID,
	SiteID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.AuditLog', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.AuditLog', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.AuditLog', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.AuditDetails SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.AuditDetails', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.AuditDetails', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.AuditDetails', 'Object', 'CONTROL') as Contr_Per 