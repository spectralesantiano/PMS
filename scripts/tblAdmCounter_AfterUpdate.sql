USE [pms_db]
GO
/****** Object:  Trigger [dbo].[tblAdmCounter_AfterUpdate]    Script Date: 02/07/2019 17:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER TRIGGER [dbo].[tblAdmCounter_AfterUpdate]
   ON  [dbo].[tblAdmCounter]
   AFTER UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    IF NOT UPDATE(DateUpdated) BEGIN
		UPDATE t SET t.DateUpdated=CURRENT_TIMESTAMP
		FROM dbo.tblAdmCounter t INNER JOIN inserted i ON t.CounterCode=i.CounterCode
    END

END

