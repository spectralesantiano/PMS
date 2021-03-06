/*
   Thursday, February 20, 20205:25:31 PM
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
ALTER TABLE dbo.tblSec_Users ADD
	Active bit NULL
GO
ALTER TABLE dbo.tblSec_Users ADD CONSTRAINT
	DF_tblSec_Users_Active DEFAULT 1 FOR Active
GO
ALTER TABLE dbo.tblSec_Users SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.tblSec_Users', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.tblSec_Users', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.tblSec_Users', 'Object', 'CONTROL') as Contr_Per 