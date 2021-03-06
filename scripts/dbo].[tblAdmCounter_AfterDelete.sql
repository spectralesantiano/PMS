USE [pms_db]
GO
/****** Object:  Trigger [dbo].[tblAdmCounter_AfterDelete]    Script Date: 02/07/2019 17:03:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER TRIGGER [dbo].[tblAdmCounter_AfterDelete]
   ON  [dbo].[tblAdmCounter]
   AFTER DELETE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;    	
	UPDATE t SET t.RunningHours=tx.Reading, t.ReadingDate=tx.ReadingDate
	FROM [dbo].[tblAdmUnit] t LEFT JOIN [dbo].[COUNTERLATESTREADING] tx ON t.UnitCode=tx.UnitCode
	WHERE t.UnitCode IN(SELECT i.UnitCode FROM deleted i)
END

