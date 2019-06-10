USE [pms_db]
GO
/****** Object:  Trigger [dbo].[tblCounterReading_AFTERINSERT]    Script Date: 02/07/2019 17:01:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TRIGGER [dbo].[tblCounterReading_AFTERINSERT] ON [dbo].[tblCounterReading] AFTER INSERT
AS
	UPDATE t SET t.RunningHours=tx.Reading, t.ReadingDate=tx.ReadingDate
	FROM [dbo].[tblAdmUnit] t LEFT JOIN [dbo].[COUNTERLATESTREADING] tx ON t.UnitCode=tx.UnitCode
	WHERE t.UnitCode IN(SELECT ac.UnitCode FROM dbo.tblAdmCounter ac INNER JOIN inserted i ON ac.CounterCode=i.CounterCode)
	--FROM dbo.tblAdmMaintenance WHERE UnitCode IN (SELECT UnitCode FROM deleted)