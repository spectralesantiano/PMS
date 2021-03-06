use pms_db
/*
   Wednesday, February 12, 20201:31:51 AM
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
ALTER TABLE dbo.tblPart_Missing ADD
	LastUpdatedBy varchar(200) NULL
GO
ALTER TABLE dbo.tblPart_Missing SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
