USE [pms_db]
GO
/****** Object:  Trigger [dbo].[tblMaintenanceWork_AfterUpdate]    Script Date: 04/07/2020 14:16:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create TRIGGER [dbo].[tblMaintenanceWork_AfterUpdate]
   ON  [dbo].[tblMaintenanceWork]
   AFTER UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    IF NOT UPDATE(DateUpdated) BEGIN
		UPDATE t SET t.DateUpdated=CURRENT_TIMESTAMP
		FROM dbo.tblMaintenanceWork t INNER JOIN inserted i ON t.MaintenanceWorkID=i.MaintenanceWorkID
    END

END