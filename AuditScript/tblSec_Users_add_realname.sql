use pms_db
/*
   Thursday, February 20, 20204:10:22 PM
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
	LName nvarchar(20) COLLATE Latin1_General_CI_AS NULL,
	FName nvarchar(40) COLLATE Latin1_General_CI_AS NULL,
	MName nvarchar(20) COLLATE Latin1_General_CI_AS NULL,
	RankCode nvarchar(15) COLLATE Latin1_General_CI_AS NULL,
	DateSOn date NULL,
	Active bit NULL
GO