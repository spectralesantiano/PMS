use pms_db
/*
   Wednesday, February 12, 20201:49:08 AM
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
CREATE TABLE dbo.Tmp_imp_tblAdmMaintenance
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
	LastUpdatedBy varchar(200) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_imp_tblAdmMaintenance SET (LOCK_ESCALATION = TABLE)
GO
IF EXISTS(SELECT * FROM dbo.imp_tblAdmMaintenance)
	 EXEC('INSERT INTO dbo.Tmp_imp_tblAdmMaintenance (MaintenanceCode, WorkCode, UnitCode, RankCode, Number, IntCode, InsCrossRef, InsEditor, InsDocument, InsDateIssue, InsDesc, LastUpdatedBy)
		SELECT MaintenanceCode, WorkCode, UnitCode, RankCode, Number, IntCode, InsCrossRef, InsEditor, CONVERT(varchar(1000), InsDocument), InsDateIssue, CONVERT(varchar(1000), InsDesc), LastUpdatedBy FROM dbo.imp_tblAdmMaintenance WITH (HOLDLOCK TABLOCKX)')
GO
DROP TABLE dbo.imp_tblAdmMaintenance
GO
EXECUTE sp_rename N'dbo.Tmp_imp_tblAdmMaintenance', N'imp_tblAdmMaintenance', 'OBJECT' 
GO
COMMIT
select Has_Perms_By_Name(N'dbo.imp_tblAdmMaintenance', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.imp_tblAdmMaintenance', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.imp_tblAdmMaintenance', 'Object', 'CONTROL') as Contr_Per 