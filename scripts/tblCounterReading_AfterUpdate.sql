USE [pms_db]
GO
/****** Object:  Trigger [dbo].[tblCounterReading_AfterUpdate]    Script Date: 10/21/2019 13:53:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER TRIGGER [dbo].[tblCounterReading_AfterUpdate]
   ON  [dbo].[tblCounterReading]
   AFTER UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    IF NOT UPDATE(DateUpdated) BEGIN
		UPDATE t SET t.DateUpdated=CURRENT_TIMESTAMP
		FROM dbo.tblCounterReading t INNER JOIN inserted i ON t.CounterReadingID=i.CounterReadingID
		
		--UPDATE t SET t.RunningHours=tx.Reading, t.ReadingDate=tx.ReadingDate
		--FROM [dbo].[tblAdmUnit] t LEFT JOIN [dbo].[COUNTERLATESTREADING] tx ON t.UnitCode=tx.UnitCode
		--WHERE t.UnitCode IN(SELECT ac.UnitCode FROM dbo.tblAdmCounter ac INNER JOIN inserted  i ON ac.CounterCode=i.CounterCode)
		
		UPDATE t SET t.RunningHours=clr.Reading, t.ReadingDate=clr.ReadingDate, t.HoursPerDay=cah.HoursPerDay
		FROM [dbo].[tblAdmUnit] t LEFT JOIN 
			(SELECT UnitCode, SUM(Reading) Reading, MAX(ReadingDate) ReadingDate FROM dbo.COUNTERLATESTREADING GROUP BY UnitCode) clr ON t.UnitCode=clr.UnitCode LEFT JOIN
			(SELECT [UnitCode],AVG([HoursPerDay])  HoursPerDay FROM [dbo].[COUNTER_AVG_HPD] WHERE RowNum<=12 GROUP BY UnitCode) cah  ON t.UnitCode=cah.UnitCode
		WHERE t.UnitCode IN(SELECT ac.UnitCode FROM dbo.tblAdmCounter ac INNER JOIN inserted i ON ac.CounterCode=i.CounterCode)
    END

END

