USE [pms_db]
GO

/****** Object:  View [dbo].[LOGIN]    Script Date: 3/4/2020 11:39:53 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[LOGIN]
AS
SELECT        [User ID] AS UserID, [User Name] AS UserName, Password, ISNULL([Group ID], 0) AS GroupID, LName, FName, MName
FROM            dbo.tblSec_Users

GO


