USE [pms_db]
GO
/****** Object:  Trigger [dbo].[tblPartConsumption_AfterUpdate]    Script Date: 10/10/2019 15:59:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tblPart_Missing_AfterUpdate]
   ON  [dbo].[tblPart_Missing]
   AFTER UPDATE
AS 
BEGIN
	SET NOCOUNT ON;    	
	UPDATE t SET t.OnStock=t.InitStock + ISNULL(pp.Number,0) - ISNULL(pc.Number,0) - ISNULL(pm.Number,0)
	FROM [dbo].[tblAdmPart] t INNER JOIN inserted i ON t.PartCode=i.PartCode 
	LEFT JOIN
	(SELECT PartCode,SUM(Number) Number FROM [dbo].[tblPartConsumption] GROUP BY PartCode) pc ON t.PartCode=pc.PartCode	
	LEFT JOIN
	(SELECT PartCode,SUM(ReceivedQuantity) Number FROM [dbo].[tblPartPurchaseDetail] GROUP BY PartCode) pp ON t.PartCode=pp.PartCode	
	LEFT JOIN
	(SELECT PartCode,SUM(Number) Number FROM [dbo].[tblPart_Missing] GROUP BY PartCode) pm ON t.PartCode=pm.PartCode	
END


