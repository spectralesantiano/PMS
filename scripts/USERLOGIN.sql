USE [pms_db]
GO
/****** Object:  StoredProcedure [dbo].[USERLOGIN]    Script Date: 05/21/2019 10:46:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[USERLOGIN] @UserID as int  WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON    
	DECLARE @GroupID varchar(15)
	
	SELECT @GroupID = [Group ID] FROM dbo.tblSec_Users WHERE [User ID]=@UserID		
	
	IF @GroupID IS NULL 
	BEGIN
		SELECT  o.ObjectID, 
				ObjectList, 
				DLL, 
				Filter, 
				Draggable, 
				Caption, 			
				ObjectListDefaultWidth, 
				MaxPermission  AS Permission,
				PrintOption,
				ListLayout,
				ListWidth,
				ContentLayout,
				CustomFilter,
				HelpUrl 
		FROM dbo.tblObjects o LEFT JOIN (SELECT * FROM dbo.tblSec_Users_Settings WHERE [User ID]=@UserID) ss ON o.ObjectID=ss.ObjectID
	END
	ELSE
	BEGIN		
		SELECT  so.ObjectID,
				ObjectList, 
				DLL, 
				Filter, 
				Draggable, 
				Caption, 			
				ObjectListDefaultWidth,
				so.Permission,
				PrintOption,
				ListLayout,
				ListWidth,
				ContentLayout,
				CustomFilter,
				HelpUrl
		FROM	dbo.tblObjects o INNER JOIN dbo.tblSec_Objects AS so ON o.ObjectID = so.ObjectID
				LEFT JOIN (SELECT * FROM dbo.tblSec_Users_Settings WHERE [User ID]=@UserID) ss ON so.ObjectID=ss.ObjectID
		WHERE	(so.SecID =@GroupID)
				
	END	    
END

