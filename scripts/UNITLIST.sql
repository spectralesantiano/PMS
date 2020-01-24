USE [pms_db]
GO

/****** Object:  View [dbo].[UNITLIST]    Script Date: 10/21/2019 16:05:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[UNITLIST]
AS
SELECT     dbo.tblAdmUnit.UnitCode, dbo.tblAdmUnit.ParentCode, dbo.tblAdmUnit.ComponentCode, dbo.tblAdmComponent.Name AS Component, dbo.tblAdmUnit.LocCode, 
                      dbo.tblAdmUnit.SerialNumber, dbo.tblAdmUnit.UnitDesc, dbo.tblAdmUnit.RunningHours, dbo.tblAdmUnit.Critical, dbo.tblAdmUnit.DeptCode, dbo.tblAdmUnit.CatCode, 
                      dbo.tblAdmUnit.Active, dbo.tblAdmUnit.MakerCode, dbo.tblAdmUnit.Type, dbo.tblAdmUnit.Model, dbo.tblAdmUnit.RefNo, dbo.tblAdmUnit.VendorCode, 
                      dbo.tblAdmUnit.HasInactive, dbo.tblAdmUnit.HasCritical
FROM         dbo.tblAdmUnit INNER JOIN
                      dbo.tblAdmComponent ON dbo.tblAdmUnit.ComponentCode = dbo.tblAdmComponent.ComponentCode

GO


