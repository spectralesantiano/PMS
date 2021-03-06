use pms_db
/*
   Wednesday, February 12, 20201:48:04 AM
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
ALTER TABLE dbo.tblAdmMaintenance
	DROP CONSTRAINT FK_tblAdmMaintenance_tblAdmWork
GO
ALTER TABLE dbo.tblAdmWork SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.tblAdmWork', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.tblAdmWork', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.tblAdmWork', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_tblAdmMaintenance
	(
	MaintenanceCode varchar(15) NOT NULL,
	WorkCode varchar(15) NOT NULL,
	UnitCode varchar(15) NULL,
	RankCode varchar(15) NULL,
	Number int NULL,
	IntCode varchar(15) NULL,
	InsCrossRef varchar(100) NULL,
	InsEditor varchar(50) NULL,
	InsDocument varchar(1000) NULL,
	InsDateIssue date NULL,
	InsDesc varchar(1000) NULL,
	LastUpdatedBy varchar(200) NULL,
	DateUpdated datetime NULL,
	HasImage bit NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_tblAdmMaintenance SET (LOCK_ESCALATION = TABLE)
GO
IF EXISTS(SELECT * FROM dbo.tblAdmMaintenance)
	 EXEC('INSERT INTO dbo.Tmp_tblAdmMaintenance (MaintenanceCode, WorkCode, UnitCode, RankCode, Number, IntCode, InsCrossRef, InsEditor, InsDocument, InsDateIssue, InsDesc, LastUpdatedBy, DateUpdated, HasImage)
		SELECT MaintenanceCode, WorkCode, UnitCode, RankCode, Number, IntCode, InsCrossRef, InsEditor, CONVERT(varchar(1000), InsDocument), InsDateIssue, CONVERT(varchar(1000), InsDesc), LastUpdatedBy, DateUpdated, HasImage FROM dbo.tblAdmMaintenance WITH (HOLDLOCK TABLOCKX)')
GO
ALTER TABLE dbo.tblMaintenanceWork
	DROP CONSTRAINT FK_tblMaintenanceWork_tblAdmMaintenance
GO
DROP TABLE dbo.tblAdmMaintenance
GO
EXECUTE sp_rename N'dbo.Tmp_tblAdmMaintenance', N'tblAdmMaintenance', 'OBJECT' 
GO
ALTER TABLE dbo.tblAdmMaintenance ADD CONSTRAINT
	PK_tblAdmMaintenance PRIMARY KEY CLUSTERED 
	(
	MaintenanceCode
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.tblAdmMaintenance ADD CONSTRAINT
	FK_tblAdmMaintenance_tblAdmWork FOREIGN KEY
	(
	WorkCode
	) REFERENCES dbo.tblAdmWork
	(
	WorkCode
	) ON UPDATE  CASCADE 
	 ON DELETE  CASCADE 
	
GO
CREATE TRIGGER [dbo].[tblAdmMaintenance_AFTERDELETE] ON dbo.tblAdmMaintenance FOR DELETE
AS
	DELETE FROM dbo.tblDocuments WHERE RefID IN (SELECT MaintenanceCode FROM deleted)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.tblAdmMaintenance', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.tblAdmMaintenance', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.tblAdmMaintenance', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.tblMaintenanceWork ADD CONSTRAINT
	FK_tblMaintenanceWork_tblAdmMaintenance FOREIGN KEY
	(
	MaintenanceCode
	) REFERENCES dbo.tblAdmMaintenance
	(
	MaintenanceCode
	) ON UPDATE  CASCADE 
	 ON DELETE  CASCADE 
	
GO
ALTER TABLE dbo.tblMaintenanceWork SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.tblMaintenanceWork', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.tblMaintenanceWork', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.tblMaintenanceWork', 'Object', 'CONTROL') as Contr_Per 