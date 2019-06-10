USE [pms_db]
GO
/****** Object:  Trigger [dbo].[tblAdmUnit_AFTERDELETE]    Script Date: 01/11/2019 14:36:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TRIGGER [dbo].[tblAdmUnit_AFTERDELETE] ON [dbo].[tblAdmUnit] FOR DELETE
AS
	DELETE FROM dbo.tblAdmMaintenance WHERE UnitCode IN (SELECT UnitCode FROM deleted)