USE [pms_db]
GO
/****** Object:  Trigger [dbo].[tblAdmUnit_AFTERDELETE]    Script Date: 01/11/2019 14:36:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TRIGGER [dbo].[tblMaintenanceWork_AFTERDELETE] ON [dbo].[tblMaintenanceWork] FOR DELETE
AS
	DELETE FROM dbo.tblNC WHERE MaintenanceWorkID IN (SELECT MaintenanceWorkID FROM deleted)
	DELETE FROM dbo.tblPlannedWork WHERE MaintenanceWorkID IN (SELECT MaintenanceWorkID FROM deleted)