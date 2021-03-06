use pms_db
/*
   Wednesday, February 12, 20201:39:22 AM
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
ALTER TABLE dbo.tblMaintenanceWork
	DROP CONSTRAINT FK_tblMaintenanceWork_tblAdmUnit
GO
ALTER TABLE dbo.tblAdmUnit SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.tblAdmUnit', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.tblAdmUnit', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.tblAdmUnit', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.tblMaintenanceWork
	DROP CONSTRAINT FK_tblMaintenanceWork_tblAdmMaintenance
GO
ALTER TABLE dbo.tblAdmMaintenance SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.tblAdmMaintenance', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.tblAdmMaintenance', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.tblAdmMaintenance', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.tblMaintenanceWork
	DROP CONSTRAINT DF_tblMaintenanceWork_DateUpdated
GO
ALTER TABLE dbo.tblMaintenanceWork
	DROP CONSTRAINT DF_tblMaintenanceWork_bLatest
GO
ALTER TABLE dbo.tblMaintenanceWork
	DROP CONSTRAINT DF_tblMaintenanceWork_bNC
GO
CREATE TABLE dbo.Tmp_tblMaintenanceWork
	(
	MaintenanceWorkID int NOT NULL IDENTITY (1, 1),
	UnitCode varchar(15) NOT NULL,
	MaintenanceCode varchar(15) NOT NULL,
	RankCode varchar(15) NULL,
	WorkDate date NOT NULL,
	WorkCounter int NULL,
	ExecutedBy varchar(100) NULL,
	Remarks varchar(500) NULL,
	DueCounter int NULL,
	DueDate date NULL,
	LastUpdatedBy varchar(200) NULL,
	DateUpdated datetime NULL,
	bLatest bit NULL,
	bNC bit NULL,
	HasImage bit NULL,
	Locked bit NULL,
	DateAdded date NULL,
	PrevDueDate date NULL,
	PrevDueCounter int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_tblMaintenanceWork SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_tblMaintenanceWork ADD CONSTRAINT
	DF_tblMaintenanceWork_DateUpdated DEFAULT (getdate()) FOR DateUpdated
GO
ALTER TABLE dbo.Tmp_tblMaintenanceWork ADD CONSTRAINT
	DF_tblMaintenanceWork_bLatest DEFAULT ((1)) FOR bLatest
GO
ALTER TABLE dbo.Tmp_tblMaintenanceWork ADD CONSTRAINT
	DF_tblMaintenanceWork_bNC DEFAULT ((0)) FOR bNC
GO
SET IDENTITY_INSERT dbo.Tmp_tblMaintenanceWork ON
GO
IF EXISTS(SELECT * FROM dbo.tblMaintenanceWork)
	 EXEC('INSERT INTO dbo.Tmp_tblMaintenanceWork (MaintenanceWorkID, UnitCode, MaintenanceCode, RankCode, WorkDate, WorkCounter, ExecutedBy, Remarks, DueCounter, DueDate, LastUpdatedBy, DateUpdated, bLatest, bNC, HasImage, Locked, DateAdded, PrevDueDate, PrevDueCounter)
		SELECT MaintenanceWorkID, UnitCode, MaintenanceCode, RankCode, WorkDate, WorkCounter, ExecutedBy, CONVERT(varchar(500), Remarks), DueCounter, DueDate, LastUpdatedBy, DateUpdated, bLatest, bNC, HasImage, Locked, DateAdded, PrevDueDate, PrevDueCounter FROM dbo.tblMaintenanceWork WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_tblMaintenanceWork OFF
GO
ALTER TABLE dbo.tblPartConsumption
	DROP CONSTRAINT FK_tblPartConsumption_tblPartConsumption
GO
DROP TABLE dbo.tblMaintenanceWork
GO
EXECUTE sp_rename N'dbo.Tmp_tblMaintenanceWork', N'tblMaintenanceWork', 'OBJECT' 
GO
ALTER TABLE dbo.tblMaintenanceWork ADD CONSTRAINT
	PK_tblMaintenanceWork PRIMARY KEY CLUSTERED 
	(
	MaintenanceWorkID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

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
ALTER TABLE dbo.tblMaintenanceWork ADD CONSTRAINT
	FK_tblMaintenanceWork_tblAdmUnit FOREIGN KEY
	(
	UnitCode
	) REFERENCES dbo.tblAdmUnit
	(
	UnitCode
	) ON UPDATE  CASCADE 
	 ON DELETE  CASCADE 
	
GO
CREATE TRIGGER [dbo].[tblMaintenanceWork_AFTERDELETE] ON dbo.tblMaintenanceWork FOR DELETE
AS	
	DELETE FROM dbo.tblPlannedWork WHERE MaintenanceWorkID IN (SELECT MaintenanceWorkID FROM deleted)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.tblMaintenanceWork', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.tblMaintenanceWork', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.tblMaintenanceWork', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.tblPartConsumption ADD CONSTRAINT
	FK_tblPartConsumption_tblPartConsumption FOREIGN KEY
	(
	MaintenanceWorkID
	) REFERENCES dbo.tblMaintenanceWork
	(
	MaintenanceWorkID
	) ON UPDATE  CASCADE 
	 ON DELETE  CASCADE 
	
GO
ALTER TABLE dbo.tblPartConsumption SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.tblPartConsumption', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.tblPartConsumption', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.tblPartConsumption', 'Object', 'CONTROL') as Contr_Per 