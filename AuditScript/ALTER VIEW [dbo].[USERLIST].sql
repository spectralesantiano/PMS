USE [pms_db]
GO

/****** Object:  View [dbo].[USERLIST]    Script Date: 2/20/2020 8:29:45 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[USERLIST]
AS
SELECT        dbo.tblSec_Users.[User ID] AS UserID, dbo.tblSec_Groups.[Group Name] AS GroupName, dbo.tblSec_Users.[User Name] AS UserName, 
                         dbo.tblSec_Users.[Group ID] AS GroupID, dbo.tblSec_Users.LName, dbo.tblSec_Users.FName, dbo.tblSec_Users.MName, dbo.tblSec_Users.RankCode, 
                         dbo.tblSec_Users.DateSOn, dbo.tblSec_Users.Active
FROM            dbo.tblSec_Users LEFT OUTER JOIN
                         dbo.tblSec_Groups ON dbo.tblSec_Users.[Group ID] = dbo.tblSec_Groups.[Group ID]
WHERE        (dbo.tblSec_Users.[User ID] > 1)

GO


