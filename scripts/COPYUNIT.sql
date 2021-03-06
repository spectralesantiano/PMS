USE [pms_db]
GO
/****** Object:  StoredProcedure [dbo].[COPYUNIT]    Script Date: 10/21/2019 16:07:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[COPYUNIT] @OldUnitCode VARCHAR(15), @NewUnitCode VARCHAR(15), @ParentCode VARCHAR(15), @ComponentCode VARCHAR(15), @UnitDesc VARCHAR(200), @LastUpdatedBy VARCHAR(200), @LocCode VARCHAR(15), @CatCode VARCHAR(15), @DeptCode VARCHAR(15), @MakerCode VARCHAR(15), @Type VARCHAR(15), @Model VARCHAR(15), @RefNo VARCHAR(15), @VendorCode VARCHAR(15), @Critical BIT
AS
BEGIN
	SET NOCOUNT ON
	
	INSERT INTO [dbo].[tblAdmUnit]([UnitCode],[UnitDesc],[ParentCode],[ComponentCode],[LocCode],[DeptCode],[CatCode],[MakerCode],[Type],[Model],[RefNo],[VendorCode],[LastUpdatedBy],[Critical])
    VALUES(@NewUnitCode, @UnitDesc, @ParentCode, @ComponentCode, @LocCode, @DeptCode, @CatCode, @MakerCode, @Type, @Model, @RefNo, @VendorCode, @LastUpdatedBy, @Critical)
    
    INSERT INTO [dbo].[tblAdmMaintenance]([MaintenanceCode],[WorkCode],[UnitCode],[RankCode],[Number],[IntCode],[InsCrossRef],[InsEditor],[InsDocument],[InsDateIssue],[InsDesc],[LastUpdatedBy])
    SELECT dbo.MAINTENANCEID(),[WorkCode],@NewUnitCode,[RankCode],[Number],[IntCode],[InsCrossRef],[InsEditor],[InsDocument],[InsDateIssue],[InsDesc],@LastUpdatedBy
    FROM [dbo].[tblAdmMaintenance] WHERE UnitCode=@OldUnitCode
    
    INSERT INTO [dbo].[tblUnitPart]([UnitCode],[PartCode])
    SELECT @NewUnitCode,[PartCode] FROM [dbo].[tblUnitPart] WHERE UnitCode=@OldUnitCode
END
