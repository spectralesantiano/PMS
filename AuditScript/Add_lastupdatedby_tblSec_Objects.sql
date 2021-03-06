use pms_db
/*
   Wednesday, February 12, 20201:35:31 AM
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
ALTER TABLE dbo.tblSec_Objects ADD
	LastUpdatedBy varchar(200) NULL
GO
ALTER TABLE dbo.tblSec_Objects SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.tblSec_Objects', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.tblSec_Objects', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.tblSec_Objects', 'Object', 'CONTROL') as Contr_Per 