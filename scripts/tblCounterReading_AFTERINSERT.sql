USE [pms_db]
GO
/****** Object:  Trigger [dbo].[tblCounterReading_AFTERINSERT]    Script Date: 10/21/2019 13:54:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TRIGGER [dbo].[tblCounterReading_AFTERINSERT] ON [dbo].[tblCounterReading] AFTER INSERT
AS
	--UPDATE t SET t.RunningHours=tx.Reading, t.ReadingDate=tx.ReadingDate
	--FROM [dbo].[tblAdmUnit] t LEFT JOIN [dbo].[COUNTERLATESTREADING] tx ON t.UnitCode=tx.UnitCode
	--WHERE t.UnitCode IN(SELECT ac.UnitCode FROM dbo.tblAdmCounter ac INNER JOIN inserted i ON ac.CounterCode=i.CounterCode)
	UPDATE t SET t.RunningHours=clr.Reading, t.ReadingDate=clr.ReadingDate, t.HoursPerDay=cah.HoursPerDay
	FROM [dbo].[tblAdmUnit] t LEFT JOIN 
		(SELECT UnitCode, SUM(Reading) Reading, MAX(ReadingDate) ReadingDate FROM dbo.COUNTERLATESTREADING GROUP BY UnitCode) clr ON t.UnitCode=clr.UnitCode LEFT JOIN
		(SELECT [UnitCode],AVG([HoursPerDay])  HoursPerDay FROM [dbo].[COUNTER_AVG_HPD] WHERE RowNum<=12 GROUP BY UnitCode) cah  ON t.UnitCode=cah.UnitCode
	WHERE t.UnitCode IN(SELECT ac.UnitCode FROM dbo.tblAdmCounter ac INNER JOIN inserted i ON ac.CounterCode=i.CounterCode)
	