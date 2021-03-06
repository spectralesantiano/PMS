/*
   Wednesday, February 12, 20206:00:22 AM
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
CREATE TABLE dbo.Tmp_AuditDetails
	(
	AuditDetailID bigint NOT NULL IDENTITY (1, 1),
	AuditLogID bigint NOT NULL,
	FieldName varchar(50) NULL,
	OldValue sql_variant NULL,
	NewValue sql_variant NULL,
	SiteID nvarchar(20) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_AuditDetails SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_AuditDetails ON
GO
IF EXISTS(SELECT * FROM dbo.AuditDetails)
	 EXEC('INSERT INTO dbo.Tmp_AuditDetails (AuditDetailID, AuditLogID, FieldName, OldValue, NewValue, SiteID)
		SELECT AuditDetailID, AuditLogID, FieldName, OldValue, NewValue, SiteID FROM dbo.AuditDetails WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_AuditDetails OFF
GO
DROP TABLE dbo.AuditDetails
GO
EXECUTE sp_rename N'dbo.Tmp_AuditDetails', N'AuditDetails', 'OBJECT' 
GO
ALTER TABLE dbo.AuditDetails ADD CONSTRAINT
	PK_AuditDetails PRIMARY KEY CLUSTERED 
	(
	AuditDetailID,
	SiteID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.AuditDetails', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.AuditDetails', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.AuditDetails', 'Object', 'CONTROL') as Contr_Per 