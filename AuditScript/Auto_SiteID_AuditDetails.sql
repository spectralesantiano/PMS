/*
   Wednesday, February 12, 20206:10:23 AM
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
ALTER TABLE dbo.AuditDetails ADD CONSTRAINT
	DF_AuditDetails_SiteID DEFAULT dbo.getItemtblConfig('LOCATION_ID') FOR SiteID
GO
ALTER TABLE dbo.AuditDetails SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.AuditDetails', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.AuditDetails', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.AuditDetails', 'Object', 'CONTROL') as Contr_Per 