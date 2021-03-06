--USE [MPS]
--replace all MPS4A. -> pms_db. / all MPS. -> pms_db.
USE [pms_db]
GO


/****** Object:  UserDefinedFunction [dbo].[getItemtblUserConfig]    Script Date: 2/11/2020 9:22:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[getItemtblUserConfig](@Code VARCHAR(50))
RETURNS VARCHAR(50)
AS
BEGIN
DECLARE @TextValue VARCHAR(50)
SELECT TOP 1 @TextValue = [Value]
FROM tblUserConfig
WHERE Code=@Code

RETURN @TextValue
END
GO

/****** Object:  UserDefinedFunction [dbo].[getItemtblConfig]    Script Date: 2/11/2020 9:21:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [dbo].[getItemtblConfig](@Code VARCHAR(15))
RETURNS VARCHAR(50)
AS
BEGIN
DECLARE @TextValue VARCHAR(50)
SELECT TOP 1 @TextValue = Value
FROM tblPMSConfig
WHERE Code=@Code

RETURN @TextValue
END
GO

/****** Object:  UserDefinedFunction [dbo].[GetTblNameFld]    Script Date: 2/11/2020 6:25:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
CREATE FUNCTION [dbo].[GetTblNameFld]
(
	-- Add the parameters for the function here
	@parTableName nvarchar(200) ,
	@FldIfNull nvarchar(200)
)
RETURNS nvarchar(200)
AS
BEGIN
	-- Declare the return variable here
	declare @tempRes nvarchar(200) 

    -- Insert statements for procedure here

	--if @parTableName = 'tblcrewinfo' begin
	--		set @tempRes = 'concat(LName, '', '' , FName, '' '', MName)'
	--	end
	--else begin
		if dbo.isTblHasFld(@parTableName,'name') =1 begin
					set @tempRes = 'name'
				end
		else
			begin
				SELECT @tempRes = RecordKeyFld
				FROM MSystblTblNameFld
				WHERE TableName = @parTableName

				if @tempRes is null begin
						set @tempRes = @FldIfNull
					end
			end
		--end

	return @tempRes 
END

GO

/****** Object:  UserDefinedFunction [dbo].[getPkeyORfirstColumn]    Script Date: 2/11/2020 6:24:02 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[getPkeyORfirstColumn]
(
	-- Add the parameters for the function here
	@tablename nvarchar(200)
)
RETURNS nvarchar(30)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @ResultVar nvarchar(30),@tempresultVar nvarchar(30)

	-- Add the T-SQL statements to compute the return value here
	SELECT top 1 @tempresultVar = COLUMN_NAME
	FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
	WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA+'.'+CONSTRAINT_NAME), 'IsPrimaryKey') = 1
	  AND TABLE_NAME = @tablename --'MSysSec_UsersGroup'

	if @tempresultvar is null
		
		SELECT top 1 @tempresultvar = column_name
	  FROM INFORMATION_SCHEMA.COLUMNS
	  WHERE table_name = @tablename
	  ORDER BY ordinal_position

	set @ResultVar = @tempresultvar

	RETURN @ResultVar

END

GO

/****** Object:  UserDefinedFunction [dbo].[isTblHasFld]    Script Date: 2/11/2020 6:14:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
create FUNCTION [dbo].[isTblHasFld]
(
	-- Add the parameters for the function here
	@parTableName nvarchar(200) ,
	@fldname nvarchar(200)
)
RETURNS tinyint
AS
BEGIN
	-- Declare the return variable here
	declare @tblcount int = 0, @tempRes tinyint

    -- Insert statements for procedure here
	SELECT @tblcount = count(TABLE_NAME)
	FROM INFORMATION_SCHEMA.COLUMNS 
	WHERE COLUMN_NAME = @fldname and TABLE_name = @parTableName
	
	if @tblcount > 0 
		set @tempRes =  1
	else
		set @tempRes =  0

	return @tempRes 
END

GO
/****** Object:  UserDefinedFunction [dbo].[isTblHasLastUpdBy]    Script Date: 2/11/2020 6:14:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
CREATE FUNCTION [dbo].[isTblHasLastUpdBy]
(
	-- Add the parameters for the function here
	@parTableName nvarchar(200) 
)
RETURNS tinyint
AS
BEGIN
	-- Declare the return variable here
	declare @tblcount int = 0, @tempRes tinyint

    -- Insert statements for procedure here
	SELECT @tblcount = count(TABLE_NAME)
	FROM INFORMATION_SCHEMA.COLUMNS 
	WHERE COLUMN_NAME = 'lastupdatedby' and TABLE_name = @parTableName
	
	if @tblcount > 0 
		set @tempRes =  1
	else
		set @tempRes =  0

	return @tempRes 
END

GO
/****** Object:  UserDefinedFunction [dbo].[isTblHasTriggerAsideAudit_func]    Script Date: 2/11/2020 6:14:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[isTblHasTriggerAsideAudit_func]
(
	-- Add the parameters for the function here
	@auditTriggerName nvarchar(200),
	@parTableName nvarchar(200),
	@Operation nvarchar(3) -- 'upd','ins','del'
)
RETURNS tinyint
AS
BEGIN
	-- Declare the return variable here
	declare @sqlstr nvarchar(max),@tempReturnloc integer,@iret tinyint

    -- Insert statements for procedure here
		if @operation = 'ins'
			SELECT 
				top 1 @tempReturnloc = count(sysobjects.name) 
			FROM sysobjects 

			INNER JOIN sysusers 
				ON sysobjects.uid = sysusers.uid 

			INNER JOIN sys.tables t 
				ON sysobjects.parent_obj = t.object_id 

			INNER JOIN sys.schemas s 
				ON t.schema_id = s.schema_id 

			WHERE sysobjects.type = 'TR' and OBJECT_NAME(parent_obj) =   @parTableName 
			and OBJECTPROPERTY( id, 'ExecIsAfterTrigger') = 1 and sysobjects.name <>  @auditTriggerName 
				 and OBJECTPROPERTY( id, 'ExecIsInsertTrigger') = 1 

		else if @operation = 'upd' 
			SELECT 
			top 1 @tempReturnloc = count(sysobjects.name) 
			FROM sysobjects 

			INNER JOIN sysusers 
				ON sysobjects.uid = sysusers.uid 

			INNER JOIN sys.tables t 
				ON sysobjects.parent_obj = t.object_id 

			INNER JOIN sys.schemas s 
				ON t.schema_id = s.schema_id 

			WHERE sysobjects.type = 'TR' and OBJECT_NAME(parent_obj) =   @parTableName 
			and OBJECTPROPERTY( id, 'ExecIsAfterTrigger') = 1 and sysobjects.name <>  @auditTriggerName 
			and OBJECTPROPERTY( id, 'ExecIsUpdateTrigger') = 1 
			
		
		else if @operation = 'del'

			SELECT 
				top 1 @tempReturnloc = count(sysobjects.name) 
			FROM sysobjects 

			INNER JOIN sysusers 
				ON sysobjects.uid = sysusers.uid 

			INNER JOIN sys.tables t 
				ON sysobjects.parent_obj = t.object_id 

			INNER JOIN sys.schemas s 
				ON t.schema_id = s.schema_id 

			WHERE sysobjects.type = 'TR' and OBJECT_NAME(parent_obj) =   @parTableName 
			and OBJECTPROPERTY( id, 'ExecIsAfterTrigger') = 1 and sysobjects.name <>  @auditTriggerName 
			and OBJECTPROPERTY( id, 'ExecIsDeleteTrigger') = 1 

		--EXECUTE sp_executesql @sqlstr,N'@tempReturn integer output',@tempReturn = @tempReturnloc output

		if @tempReturnloc > 0 
			set @iret = 1
		else
			set @iret = 0

	RETURN @iret

END

GO


/****** Object:  StoredProcedure [dbo].[getCodeValue_sp]    Script Date: 2/11/2020 5:59:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getCodeValue_sp]
	-- Add the parameters for the stored procedure here
	@tableRef nvarchar(50),
	@code nvarchar(255),
	@cname nvarchar(255) output,
	@pkeyfld nvarchar(255) = 'PKey'
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @tempReturnloc nvarchar(255)
	declare @strSQL nvarchar(max)

	--set @strsql =  'select top 1 '+ @tempReturn + '= [name] from ' + QUOTENAME(@tableref)
	--set @strSQL = @strSQL + ' where PKey = ''' + @code + ''';'
	
	--set @strsql =  'Declare @tempReturn '
	if @tableRef = 'tblcrewinfo' begin
			set @strsql = 'select top 1 @tempReturn = concat(LName, '', '' , FName, '' '', MName) from ' + QUOTENAME(@tableref)
			set @strSQL = @strSQL + ' where '+ @pkeyfld +' = ''' + @code + '''';
		end
	else begin
			if dbo.isTblHasFld(@tableref,'name') =1 begin
					set @strsql = 'select top 1 @tempReturn = [name] from ' + QUOTENAME(@tableref)
					set @strSQL = @strSQL + ' where '+ @pkeyfld +' = ''' + @code + '''';
				end
			else
				begin
					set @strsql = 'select top 1 @tempReturn = ['+ @pkeyfld +'] from ' + QUOTENAME(@tableref)
					set @strSQL = @strSQL + ' where '+ @pkeyfld +' = ''' + @code + '''';
				end
		end
	print @strsql
	--set @strsql = @strSQL + 'select top 1 @tempReturn = [name] from  QUOTENAME(@tableref) '
	--set @strSQL = @strSQL + ' where PKey =  @code '

	--set @strsql =  'select top 1 [name] from ' + QUOTENAME(@tableref) 
	--set @strSQL = @strSQL +  ' where PKey = ''' + @code + ''';'

	--print @strsql
	--set @strsql =  'select top 1 [name] from ' + QUOTENAME(@tableref)
	--set @strSQL = @strSQL + ' where PKey = ''' + @code + ''';'

	EXECUTE sp_executesql @strSQL,N'@tempReturn nvarchar(255) output',@tempReturn = @tempReturnloc output
	--EXECUTE @tempReturn = sp_executesql @strSQL
	print @tempReturnloc
	set @cname = @tempReturnloc
	RETURN 0
END


GO

/****** Object:  UserDefinedFunction [dbo].[getReferencedTable]    Script Date: 2/11/2020 5:56:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[getReferencedTable] 
(
	-- Add the parameters for the function here
	@table_child nvarchar(50),
	@fld_child nvarchar(50)
)
RETURNS nvarchar(50)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @tempReturn nvarchar(50)

	-- Add the T-SQL statements to compute the return value here
		SELECT 
		--fk.name 'FK Name',
		--tp.name 'Parent table',
		--cp.name, cp.column_id,
		@tempReturn = tr.name -- 'Refrenced table'
		--cr.name, cr.column_id
		FROM 
			sys.foreign_keys fk
		INNER JOIN 
			sys.tables tp ON fk.parent_object_id = tp.object_id
		INNER JOIN 
			sys.tables tr ON fk.referenced_object_id = tr.object_id
		INNER JOIN 
			sys.foreign_key_columns fkc ON fkc.constraint_object_id = fk.object_id
		INNER JOIN 
			sys.columns cp ON fkc.parent_column_id = cp.column_id AND fkc.parent_object_id = cp.object_id
		INNER JOIN 
			sys.columns cr ON fkc.referenced_column_id = cr.column_id AND fkc.referenced_object_id = cr.object_id
		where tp.name = @table_child and cp.name = @fld_child
		--ORDER BY
		--tp.name, cp.column_id

	-- Return the result of the function
	RETURN @tempReturn

END

GO




/****** Object:  UserDefinedFunction [dbo].[getfldDescription]    Script Date: 2/11/2020 5:55:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[getfldDescription]
(	
	-- Add the parameters for the function here
	@tblname nvarchar(50) ,
	@colname nvarchar(50) 
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	 select 
        st.name as Tablename,
        sc.name as ColumnName,
        sep.value [Description]
		,case when not sep.value is null then
		   case when left(cast(sep.value as nvarchar(50)),1) = 'Y' then
				right(cast(sep.value as nvarchar(50)), len(cast(sep.value as nvarchar(50))) - 1 )
		   else
				 sc.name
		   end
		else
			@colname
		end
	   as flddesc

    from sys.tables st
    inner join sys.columns sc on st.object_id = sc.object_id
    left join sys.extended_properties sep on st.object_id = sep.major_id
                                         and sc.column_id = sep.minor_id
                                         and sep.name = 'MS_Description'
    where st.name = @tblname
    and sc.name = @colname
	
--	SELECT sys.objects.name AS TableName, sys.columns.name AS ColumnName,
--       ep.name AS PropertyName, ep.value AS Description
--	   , case when (Not ep.value Is Null) And (Not ep.value = '') then --case when ep.value is not null then
--		   case when left(cast(ep.value as nvarchar(50)),1) = 'Y' then
--				right(cast(ep.value as nvarchar(50)), len(cast(ep.value as nvarchar(50))) - 1 )
--		   else
--				sys.columns.name
--		   end
--		else
--			@colname
--		end
--	   as fltdesc
--FROM sys.objects
--INNER JOIN sys.columns ON sys.objects.object_id = sys.columns.object_id
--cross APPLY fn_listextendedproperty(default,
--                  'SCHEMA', schema_name(schema_id),
--                  'TABLE',  sys.objects.name, 'COLUMN', sys.columns.name) ep
-- where sys.objects.name = @tblname and sys.columns.name = @colname
----ORDER BY sys.objects.name, sys.columns.column_id
)


GO

/****** Object:  UserDefinedFunction [dbo].[countOccurence]    Script Date: 2/11/2020 5:45:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[countOccurence] 
(
	-- Add the parameters for the function here
	@srcString nvarchar(300),
    @chkString nvarchar(5)
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @ResultVar int
	declare @index int
	declare @srcLen int
	declare @chkLen int
	declare @Cnt int =0
	
	-- declare @srcString nvarchar(200)
	-- declare @chkString nvarchar (200)
	

	-- Add the T-SQL statements to compute the return value here
	-- set @srcString = 'taenae'
	-- set @chkString = 'ae'
	set @srcLen = len(@srcString)
	set @chkLen = LEN(@chkString) 
	set @index = 1
	
	while @index <=  @srcLen
		begin
			if SUBSTRING(@srcString,@index ,@chkLen) = @chkString
			begin
				set @Cnt = @Cnt + 1
			end;
			set @index = @index + 1;
		end;
		
	set @ResultVar =  @Cnt
	-- set @ResultVar =  LEN(@chkString)
	
	-- Return the result of the function
	RETURN @ResultVar

END

GO




/****** Object:  UserDefinedFunction [dbo].[AuditGetDelLastUBy]    Script Date: 2/11/2020 5:17:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[AuditGetDelLastUBy]
(
	-- Add the parameters for the function here
	@TableName nvarchar(50),
	@PKeyValue nvarchar(20)
)
RETURNS nvarchar(700)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @ResultVar nvarchar(700) = ''

	-- Add the T-SQL statements to compute the return value here
	SELECT @ResultVar = prelastupdatedby from pms_db.dbo.AuditPreDel 
		where tablename = @TableName and PKeyValue = @PKeyValue

	-- Return the result of the function
	RETURN @ResultVar

END

GO
/****** Object:  UserDefinedFunction [dbo].[AuditHeaderPart]    Script Date: 2/20/2020 2:49:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[AuditHeaderPart]
(
	@tblname nvarchar(200),
	@option nvarchar(3), -- 'upd','ins','del' 
	@forDropTrigger tinyint = 0 -- if 1, drop script for triggers only will be created no create script
)
RETURNS nvarchar(max)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @ResultVar nvarchar(max),@pkfld nvarchar(30) = 'PKey'
	declare @tblkeyfldname nvarchar(255)
	declare @Actiondesc nvarchar(20)
	
	set @ResultVar = 'IF EXISTS (select * from sysobjects where name = '''+ @tblname + '_' + @option + ''' and xtype =''TR'')' + CHAR(13) + 
	'	DROP TRIGGER '+ @tblname + '_' + @option + CHAR(13) 
	
	if @forDropTrigger = 0 begin
	
		set @ResultVar = @ResultVar + 'begin' + CHAR(13) + 
		'	exec(''' + CHAR(13) +  CHAR(13) + 	
		
		--'USE [MPS]' + CHAR(13) +
		--'GO' + CHAR(13) + CHAR(13) + 

		--'SET ANSI_NULLS ON' + CHAR(13) +
		--'GO' + CHAR(13) +
		--'SET QUOTED_IDENTIFIER ON' + CHAR(13) +
		--'GO' + CHAR(13) + CHAR(13) +

		--'IF EXISTS (select * from sysobjects where name = ''''' + @tblname + ''''' and xtype =''''u'''') ' + CHAR(13) +
		--'DROP TRIGGER '+ @tblname + 'Upd' + CHAR(13) +
		--'go' + CHAR(13) +  CHAR(13) +

		'CREATE TRIGGER [dbo].[' + @tblname + '_' + @option +'] ' + CHAR(13) +
		'   ON  [dbo].[' + @tblname + ']' + CHAR(13) 
	
		if @option ='upd' begin
			set @ResultVar = @resultvar + '   AFTER UPDATE' + CHAR(13) 
			set @Actiondesc = 'Edit'
			end
		if @option ='ins' begin
			set @ResultVar = @resultvar + '   AFTER insert' + CHAR(13) 
			set @Actiondesc = 'Add'
			end
		if @option ='del' begin
			set @ResultVar = @resultvar + '   AFTER delete' + CHAR(13) 
			set @Actiondesc = 'Delete'
		end		

		set @ResultVar = @resultvar + 
		'AS ' + CHAR(13) +
		'BEGIN' + CHAR(13) +CHAR(13) +
		
		'	if @@ROWCOUNT = 0 ' + CHAR(13) +
		'		return	' + CHAR(13) +								
		'	SET NOCOUNT ON;' + CHAR(13) +CHAR(13) +

		'	DECLARE @ColumnName nvarchar(200)' + CHAR(13) +
		'	DECLARE @sql NVARCHAR(500)' + CHAR(13) +
		'	DECLARE @valueOld sql_variant' + CHAR(13) +
		'	DECLARE @valueNew sql_variant' + CHAR(13) +CHAR(13) 
		
		-- '	SELECT * INTO #tblInserted FROM inserted' + CHAR(13) 
	
		--if @option ='ins' begin
		--	set @ResultVar = @resultvar + '	SELECT * INTO #tblInserted FROM inserted' + CHAR(13) +
		--	'	SELECT * INTO #tblDeleted FROM deleted' + CHAR(13) +CHAR(13) 
		--	end
		--if @option = 'upd'
			set @ResultVar = @resultvar + 'select NULL mykey, * into #tblInserted from inserted ' + CHAR(13) +
			' select NULL mykey, * into #tblDeleted from deleted ' + CHAR(13) + CHAR(13) 
		--if @option = 'del' begin
		--	set @ResultVar = @resultvar + '	SELECT * INTO #tblInserted FROM inserted' + CHAR(13) +
		--	' select NULL mykey, * into #tblDeleted from deleted -- this is for looping if more than one record' + CHAR(13) + CHAR(13) 
		--	end
	
		set @ResultVar = @resultvar + 
		'	DECLARE @lastupdatedby nvarchar(500)' + CHAR(13) +
		'	DECLARE @CrewID nvarchar(20)' + CHAR(13) +
		'	DECLARE @ComputerName nvarchar(50)' + CHAR(13) +
		'	DECLARE @ModuleCode nvarchar(10)' + CHAR(13) +
		'	DECLARE @DataDescrip nvarchar(300)' + CHAR(13) +
		'	DECLARE @ScreenCaption nvarchar(50)' + CHAR(13) +
		'	DECLARE @ActionDescrip nvarchar(300)' + CHAR(13) +
		'	DECLARE @AuditBa tinyint' + CHAR(13) +
		'	DECLARE @InsertedID nvarchar(20)' + CHAR(13) +
		'	DECLARE @RecordKeyName nvarchar(300) = Null ' + CHAR(13) + CHAR(13) +
		'	DECLARE @Machine nvarchar(100) = Null ' + CHAR(13) + CHAR(13) +
		'	DECLARE @TypeofWork tinyint = Null ' + CHAR(13) + CHAR(13) +
		'	DECLARE @Critical tinyint = Null ' + CHAR(13) + CHAR(13) +
		'	DECLARE @Maintenance nvarchar(100) = Null ' + CHAR(13) + CHAR(13) +
		'	DECLARE @Rank nvarchar(50) = Null ' + CHAR(13) + CHAR(13) +
		
		
		'	DECLARE @DateUpdated datetime2' + CHAR(13) +
		'	DECLARE @PKey nvarchar(20)' + CHAR(13) + CHAR(13) +

		'	SET XACT_ABORT off ' + CHAR(13) + CHAR(13) 
	
		if @option = 'del' or @option = 'upd' begin
				set @ResultVar = @resultvar + 'set rowcount 1' + CHAR(13) 
				if @option = 'upd'
					set @ResultVar = @resultvar + 'update #tblInserted set mykey = 1' + CHAR(13) 
			
				set @ResultVar = @resultvar + 
				'update #tblDeleted set mykey = 1' + CHAR(13) + CHAR(13) +
		
				'while @@rowcount > 0' + CHAR(13) +
				'begin	' + CHAR(13) +
				'	set rowcount 0' + CHAR(13) +
				'	set @ActionDescrip = ''''''''' + CHAR(13) + CHAR(13) 
			end
	
		if dbo.istblhasfld(@tblname,'PKey') = 0 begin
				set @pkfld = dbo.getPkeyORfirstColumn(@tblname)
			end
		else
			set @pkfld = 'PKey'

		if @option ='del' begin
			set @ResultVar = @resultvar + '	select @DateUpdated = getdate(),@PKey = ['+ @pkfld + '] from #tblDeleted where mykey = 1 ' + CHAR(13) +CHAR(13) +
				--'	select @lastupdatedby = lastupdatedby from #tblDeleted where mykey = 1 ' + CHAR(13) 
				'	select @lastupdatedby =  dbo.AuditGetDelLastUBy('''''+ @tblname +''''',@PKey)' + CHAR(13) 
			end
		if @option ='upd' begin
			set @ResultVar = @resultvar +'	select @DateUpdated = getdate(),@PKey = ['+ @pkfld + '] from #tblInserted  where mykey = 1' + CHAR(13) +CHAR(13) +		
				'	select @lastupdatedby = lastupdatedby from #tblInserted where mykey = 1' + CHAR(13) 
			end
		if @option ='ins' begin 
			set @ResultVar = @resultvar +'	select @DateUpdated = getdate(),@PKey = ['+ @pkfld + '] from #tblInserted' + CHAR(13) +CHAR(13) +		
			'	select @lastupdatedby = lastupdatedby from #tblInserted' + CHAR(13) 
		end
		
		set @ResultVar = @resultvar +  CHAR(13) + '	if @lastupdatedby is null or @lastupdatedby = '''''''' '  + CHAR(13) 
		
				
			
		--  --20170815 // this bug is realize on tblCrewConflict delete trigger. deleting multi rows in one transaction. 
		--	--perhaps not applicable to all table. Therefore line below will still remain
		set @ResultVar = @resultvar +'		return ' + CHAR(13) + CHAR(13)
		--  --lines below should be implemented if needed. (multiple rows affected in one transaction.)
		--	--this is a correction so the while loop through the deleted table will continue instead of return and ends the trigger. 
		--	set @ResultVar = @resultvar +'		begin ' + CHAR(13) + CHAR(13) 
		--	set @ResultVar = @resultvar +'			delete #tblDeleted where mykey = 1  ' + CHAR(13) + CHAR(13) 
		--	set @ResultVar = @resultvar +'			set rowcount 1  ' + CHAR(13) + CHAR(13) 
		--	set @ResultVar = @resultvar +'			update #tblDeleted set mykey = 1  ' + CHAR(13) + CHAR(13) 
		--	set @ResultVar = @resultvar +'			continue ' + CHAR(13) + CHAR(13) 
		--	set @ResultVar = @resultvar +'		end  ' + CHAR(13) + CHAR(13) 
		
		if @option ='upd' or @option ='ins' begin
			set @ResultVar = @resultvar +  CHAR(13) + '	IF not	UPDATE ([LastUpdatedBy]) '  + CHAR(13) 
			set @ResultVar = @resultvar +'		return ' + CHAR(13) + CHAR(13)
		end
		
	
		set @ResultVar = @resultvar +
		'	exec pms_db.dbo.splitLastUpdatedby @lastupdatedby output,@CrewID output,@ComputerName output,@ModuleCode output,@DataDescrip output,' + CHAR(13) +
		'				@ScreenCaption output,@ActionDescrip output,@AuditBa output,@Machine output, @TypeofWork output, @Critical output, @Maintenance output, @Rank output' + CHAR(13) +CHAR(13) +

		'	if @AuditBa = 0 ' + CHAR(13) +
		'		return  ' + CHAR(13) +CHAR(13) +

		--'	set @ActionDescrip = ''''' + @Actiondesc + ''''' + ISNULL(@ActionDescrip,'''''''') ' + CHAR(13) + CHAR(13) 		
		'if @ActionDescrip = '''''''' ' + CHAR(13) +		
		'	set @ActionDescrip = ''''' + @Actiondesc + ''''' ' + CHAR(13) + CHAR(13) 		

		set @tblkeyfldname = [dbo].[GetTblNameFld] (@tblname,@pkfld)

		if @option ='del' begin
			set @ResultVar = @resultvar +'	select @RecordKeyName = [' + @tblkeyfldname + '] from #tblDeleted ' + CHAR(13) + CHAR(13) 
		end
		if @option ='upd' or @option ='ins' begin
			set @ResultVar = @resultvar +'	select @RecordKeyName = [' + @tblkeyfldname + '] from #tblInserted ' + CHAR(13) + CHAR(13) 
		end

		set @ResultVar = @resultvar +
		'	exec pms_db.dbo.auditSaveLog @CrewID,@ComputerName,@ModuleCode,@DataDescrip,@ScreenCaption,@ActionDescrip,' + CHAR(13) +
		'				@DateUpdated,''''' + @tblname + ''''',''''['+ @pkfld + ']'''',@PKey,'''''''',@lastupdatedby,@InsertedID output,@RecordKeyName,@Machine,@TypeofWork,@Critical,@Maintenance,@Rank' + CHAR(13) + CHAR(13) 
		
		end
	
	-- Return the result of the function
	RETURN @ResultVar

END


GO
/****** Object:  UserDefinedFunction [dbo].[AuditSetupTrigger]    Script Date: 2/11/2020 5:17:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[AuditSetupTrigger]
(
	@parTableName nvarchar(200) ='',
	@Operation nvarchar(3), -- 'upd','ins','del'
	@forDropTrigger tinyint = 0
	--@excemptTbl nvarchar(max)='dummy' --delimited with comma ex. tbl1,tbl2
)
RETURNS nvarchar (max)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @ResultVar nvarchar(max)=''

	-- Add the T-SQL statements to compute the return value here
	
    DECLARE @ColumnName nvarchar(200)
    DECLARE @TableName nvarchar(200)
	declare @iAside tinyint
	declare @auditTriggerName nvarchar(200)
    
	if len(@parTableName) > 0 and @parTableName <> '' begin
			if pms_db.dbo.isTblHasLastUpdBy(@parTableName) = 1 begin
				set @auditTriggerName =  @parTableName + '_' + @Operation
				--//if dbo.isTblHasTriggerAsideAudit_func( @auditTriggerName,@parTableName,@Operation) <> 1  begin --table do not have any trigger yet
				--if @iAside <> 1  begin 
						DECLARE TableCursor CURSOR FOR
						select TABLE_NAME FROM pms_db.INFORMATION_SCHEMA.TABLES where TABLE_NAME ='' + @parTableName + ''  and TABLE_catalog ='pms_db' --and TABLE_NAME not in(@excemptTbl)
					--//end
				--//else
					--//return '-- XXXX already have trigger aside from audit triggers, table ' + @partablename
				end
			else
				return '-- ///// no lastupdatedby column, table ' + @partablename
			
			--return ''
		end
	else begin
			Return 'Sorry, please enter table name, Operation and (0 or 1)'
			--DECLARE TableCursor CURSOR FOR			
			--select TABLE_NAME FROM pms_db.INFORMATION_SCHEMA.TABLES where TABLE_TYPE ='base table'  and TABLE_catalog ='pms_db' order by TABLE_NAME
		end
		
	OPEN TableCursor
	FETCH NEXT FROM TableCursor INTO @TableName
		WHILE @@FETCH_STATUS =0
		BEGIN
		
			set @ResultVar = @ResultVar + dbo.AuditHeaderPart(@TableName,@Operation,@forDropTrigger)
		
		if @forDropTrigger = 0 begin

			DECLARE ColumnCursor CURSOR FOR
			SELECT COLUMN_name FROM pms_db.INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @TableName
	
			OPEN ColumnCursor
			FETCH NEXT FROM ColumnCursor INTO @ColumnName
				WHILE @@FETCH_STATUS =0
				BEGIN
							

							--set @ResultVar = @ResultVar +  ' select @valueNew = [' + @ColumnName + '] from #tblInserted' + CHAR(13)
							set @ColumnName = @ColumnName 
							--set @ResultVar = @ResultVar + 'if UPDATE([' + @ColumnName + '])begin' + CHAR(13) 
							if @Operation = 'del' begin
								set @ResultVar = @ResultVar + '		select @valueOld = [' + @ColumnName + '] from #tblDeleted where mykey = 1' + CHAR(13)
														+  '		select @valueNew = [' + @ColumnName + '] from #tblInserted' + CHAR(13) + CHAR(13)
								end
							if @Operation = 'ins' begin 
								set @ResultVar = @ResultVar + '	select @valueOld = [' + @ColumnName + '] from #tblDeleted' + CHAR(13)
													+  '	select @valueNew = [' + @ColumnName + '] from #tblInserted' + CHAR(13) + CHAR(13)
							end


							if @Operation = 'ins' 
								set @ResultVar = @ResultVar + '	if @valueNew is not null begin' + CHAR(13) 
							if @Operation = 'upd' 
								set @ResultVar = @ResultVar + '	if UPDATE([' + @ColumnName + '])begin' + CHAR(13) 
							if @Operation = 'del' 
								set @ResultVar = @ResultVar + '	if @valueOld is not NULL begin' + CHAR(13) 
							
							--if @ColumnName = 'LastUpdatedBy'
							--	set @ResultVar = @ResultVar + '	   exec pms_db.dbo.auditSaveDetails @InsertedID,''''[' + @ColumnName + ']'''', @valueOld, @lastupdatedby' + CHAR(13)
							--else

							--set @ColumnName = '[[' + @ColumnName + ']]'
														
							if @Operation = 'upd' begin
								set @ResultVar = @ResultVar + '		select @valueOld = [' + @ColumnName + '] from #tblDeleted where mykey = 1' + CHAR(13)
														+  '	select @valueNew = [' + @ColumnName + '] from #tblInserted where mykey = 1' + CHAR(13) + CHAR(13)
							end
													
							--if @ColumnName = 'PKey' begin
							--	set @ResultVar = @ResultVar + 
							--		' update '+ @TableName + ' set lastupdatedby = ''''<'''' + @lastupdatedby + ''''>'''' where [PKey] =  @valuenew' + CHAR(13) + CHAR(13)
							--end


								set @ResultVar = @ResultVar + '	   exec pms_db.dbo.auditSaveDetails @InsertedID,''''[' + @ColumnName + ']'''', @valueOld, @valueNew' + CHAR(13)

							set @ResultVar = @ResultVar + '	end' + CHAR(13) + CHAR(13)
					
					FETCH NEXT FROM ColumnCursor into @ColumnName
				END
			CLOSE ColumnCursor
			DEALLOCATE ColumnCursor
			
			if @Operation = 'del' or @Operation ='upd' begin
				if @Operation ='upd'
					set @ResultVar = @ResultVar + '	delete #tblinserted where mykey = 1' + char(13)
				
				set @ResultVar = @ResultVar +
				'	delete #tblDeleted where mykey = 1' + char(13) +
				'	set rowcount 1' + char(13) 
				
				if @Operation ='upd'
					set @ResultVar = @ResultVar + '	update #tblinserted set mykey = 1' + char(13)
					
				set @ResultVar = @ResultVar + '	update #tblDeleted set mykey = 1' + char(13) +
				'end' + char(13) +
				'set rowcount 0' + char(13) 
			end
			
			set @ResultVar = @ResultVar + char(13) + char(13) + 'End' + char(13) 
											
			set @ResultVar = @ResultVar + ''')' + char(13) +
			'end' + char(13) + char(13)
		
			end

			FETCH NEXT FROM TableCursor into @TableName
		END
	CLOSE TableCursor
	DEALLOCATE TableCursor
	
	RETURN @ResultVar
END

GO
/****** Object:  StoredProcedure [dbo].[auditSaveDetails]    Script Date: 2/11/2020 5:17:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[auditSaveDetails]
	-- Add the parameters for the stored procedure here
	@AuditLogID bigint,
	@FieldName nvarchar(50),
	@OldValue sql_variant = NULL,
	@NewValue sql_variant
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	 DECLARE 
            @LocalError     INT,
            @ErrorMessage   VARCHAR(4000)

	begin try
		-- Insert statements for procedure here
		INSERT INTO pms_db.dbo.AuditDetails(AuditLogID,FieldName,OldValue,NewValue)
			values (@AuditLogID,@FieldName,@OldValue,@NewValue )

	end try
	
	begin catch
		SELECT 
			@LocalError = ERROR_NUMBER() , -- as ErrorNumber,
			@ErrorMessage = ERROR_MESSAGE();  

			RAISERROR(@ErrorMessage,1,200,@LocalError,@ErrorMessage);
				 
				 --set @returnKo = 0;
				 RETURN(0)
	end catch

END


GO
/****** Object:  StoredProcedure [dbo].[auditSaveLog]    Script Date: 2/11/2020 5:17:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: SQLQuery16.sql|7|0|C:\Users\DeveloperOne\AppData\Local\Temp\~vs7570.sql
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[auditSaveLog] 
	-- Add the parameters for the stored procedure here
	 @CrewID nvarchar(20) = 'N/A',
	 @ComputerName nvarchar(100)= NULL,
	 @ModuleCode tinyint =Null,
	 @DataDescrip nvarchar(300) = NULL,
	 @ScreenCaption nvarchar(100) = NULL ,
	 @ActionDescrip nvarchar(300),
	 @DateUpdated datetime2 = NULL,
	 @Tablename nvarchar(30) = NULL,
	 @PKeyField nvarchar(30) = 'pkey',
	 @PKeyVal nvarchar(20) = NULL,
	 @AdditionalInfo nvarchar(300) = null,
	 @UserName nvarchar(30),
	 @insertedID bigint output ,
	 @RecordKeyName nvarchar(300) = null,
	 @Machine nvarchar(100)=null,
	 @TypeofWork nvarchar(50) = null output,
	 @Critical tinyint =0 output,
	 @Maintenance nvarchar(100) = null output,
	 @Rank nvarchar(100) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE 
            @LocalError     INT,
            @ErrorMessage   VARCHAR(4000)
	
	declare @SiteID nvarchar(20) --to be get automatically
	DECLARE @TmpTbl TABLE ( ID bigint)
	declare @TEMPdateupdated datetime2

	if @DateUpdated is null
		set @TEMPdateupdated = GETDATE()
	else
		set @TEMPdateupdated = @DateUpdated

	begin try

		--set @SiteID = dbo.getItemtblConfig('LOCATION_ID')
		select @SiteID = IMONo from VESSELINFO
	
		-- Insert statements for procedure here
		-- SELECT <@Param1, sysname, @p1>, <@Param2, sysname, @p2>
		INSERT INTO pms_db.dbo.AuditLog(crewID,ComputerName,ModuleCode,DataDescrip,ScreenCaption,ActionDescrip,DateUpdated,
			Tablename,PKeyField,PKeyValue,AdditionalInfo,UserName,SiteID,RecordKeyName,Machine,TypeofWork,Critical,Maintenance,Rank)
		OUTPUT INSERTED.AuditLogID INTO @TmpTbl(ID)
		VALUES(@CrewID,@ComputerName,@ModuleCode,@DataDescrip,@ScreenCaption,@ActionDescrip,@TEMPdateupdated,
			@Tablename,@PKeyField,@PKeyVal,@AdditionalInfo,@UserName,@SiteID,@RecordKeyName,@Machine,@TypeofWork,@Critical,@Maintenance,@Rank)

		SELECT @insertedID=ID FROM @TmpTbl

	end try
	
	begin catch
		set @insertedID = 0
		
		SELECT 
			@LocalError = ERROR_NUMBER() , -- as ErrorNumber,
			@ErrorMessage = ERROR_MESSAGE();  

			RAISERROR(@ErrorMessage,1,200,@LocalError,@ErrorMessage);
				
				 --set @returnKo = 0;
				-- RETURN(0)
	end catch
END


GO
/****** Object:  StoredProcedure [dbo].[auditSavePreDelDetails]    Script Date: 2/11/2020 5:17:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[auditSavePreDelDetails]
	-- Add the parameters for the stored procedure here
	@TableName nvarchar(50),
	@PKeyValue nvarchar(20),
	@PreLastUBy nvarchar(700) 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	 DECLARE 
            @LocalError     INT,
            @ErrorMessage   VARCHAR(4000)

	begin try
		-- Insert statements for procedure here
		INSERT INTO pms_db.dbo.AuditPreDel(TableName,PKeyValue,PreLastUpdatedBy)
			values (@TableName,@PKeyValue,@PreLastUBy)

	end try
	
	begin catch
		SELECT 
			@LocalError = ERROR_NUMBER() , -- as ErrorNumber,
			@ErrorMessage = ERROR_MESSAGE();  

			RAISERROR(@ErrorMessage,1,200,@LocalError,@ErrorMessage);
				 
				 --set @returnKo = 0;
				 RETURN(0)
	end catch

END


GO
/****** Object:  StoredProcedure [dbo].[AuditSetup]    Script Date: 2/11/2020 5:17:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Neil
-- Create date: 2016/05/10
-- Description:	Audit Triggers Setup

-- Steps:
-- Run this SP to produce triggers for all tables
-- Inspect existing triggers that are going to be replaced
-- Export the result set to sql file
-- Execute in MSSMS interface 
-- =============================================
CREATE PROCEDURE [dbo].[AuditSetup]
	-- Add the parameters for the stored procedure here
	 @forDropTrigger tinyint = 0
	 --@excemptTbl nvarchar(max)='dummy'
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT 
     sysobjects.name AS EXISTING_TRIGGERS
    ,USER_NAME(sysobjects.uid) AS trigger_owner 
    ,s.name AS table_schema 
    ,OBJECT_NAME(parent_obj) AS table_name 
    ,OBJECTPROPERTY( id, 'ExecIsUpdateTrigger') AS isupdate 
    ,OBJECTPROPERTY( id, 'ExecIsDeleteTrigger') AS isdelete 
    ,OBJECTPROPERTY( id, 'ExecIsInsertTrigger') AS isinsert 
    ,OBJECTPROPERTY( id, 'ExecIsAfterTrigger') AS isafter 
    ,OBJECTPROPERTY( id, 'ExecIsInsteadOfTrigger') AS isinsteadof 
    ,OBJECTPROPERTY(id, 'ExecIsTriggerDisabled') AS [disabled] 
FROM sysobjects 

INNER JOIN sysusers 
    ON sysobjects.uid = sysusers.uid 

INNER JOIN sys.tables t 
    ON sysobjects.parent_obj = t.object_id 

INNER JOIN sys.schemas s 
    ON t.schema_id = s.schema_id 

WHERE sysobjects.type = 'TR' 

	select dbo.AuditSetupTrigger(TABLE_NAME,'ins',@forDropTrigger) as 'Insert_Triggers' FROM pms_db.INFORMATION_SCHEMA.TABLES where TABLE_TYPE ='base table'  and TABLE_catalog ='pms_db' order by TABLE_NAME
	select dbo.AuditSetupTrigger(TABLE_NAME,'upd',@forDropTrigger) as 'Update_Triggers' FROM pms_db.INFORMATION_SCHEMA.TABLES where TABLE_TYPE ='base table'  and TABLE_catalog ='pms_db' order by TABLE_NAME
	select dbo.AuditSetupTrigger(TABLE_NAME,'del',@forDropTrigger) as 'Delete_Triggers' FROM pms_db.INFORMATION_SCHEMA.TABLES where TABLE_TYPE ='base table'  and TABLE_catalog ='pms_db' order by TABLE_NAME


END


GO
/****** Object:  StoredProcedure [dbo].[splitLastUpdatedby]    Script Date: 2/11/2020 5:17:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[splitLastUpdatedby]
	-- Important! order should be follow
	-- <LastUpdatedBy><CrewID><@ComputerName><@ModuleCode><@DataDescrip><ScreenCaption><@ActionDescrip><@AuditBa>
	
	 @LastUpdatedBy nvarchar(700) output,
	 @CrewID nvarchar(20) output,
	 @ComputerName nvarchar(50) output,
	 @ModuleCode tinyint output,
	 @DataDescrip nvarchar(300) output,
	 @ScreenCaption nvarchar(50) output,
	 @ActionDescrip nvarchar(300) output,
	 @AuditBa tinyint = 1 output,
	 @Machine nvarchar(100) = null output,
	 @TypeofWork nvarchar(50) = null output,
	 @Critical tinyint =0 output,
	 @Maintenance nvarchar(100) = null output,
	 @Rank nvarchar(50) = null output
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	
	declare @tempLastupdatedBy nvarchar(300)
	declare @index int
	declare @itemCnt int = 1
	declare @updatedLen int
	declare @tempString nvarchar(200) =''
	declare @subChar char
	
	SET NOCOUNT ON;

	-- 13 count of items 
	if pms_db.dbo.countOccurence(@LastUpdatedBy,'<') = 13 and pms_db.dbo.countOccurence(@LastUpdatedBy,'>') = 13
	begin
		
		set @index = 1;
		set @updatedlen = len(@LastUpdatedBy);

		while  @index <=  @updatedlen
		begin
			set @subChar = SUBSTRING(@LastUpdatedBy,@index,1);
		
			if @subChar <> '<' and @subChar <> '>'
				begin	
					set @tempString = @tempString +  @subChar;
					
				end
			else
				--if @tempString <> '' 
				if @subChar = '>' 
					begin
						--print @itemcnt
						--print @tempstring
						if @itemCnt = 1  
								set @tempLastupdatedBy = @tempString;
						if @itemCnt = 2  
								set @CrewID = @tempString;				
						if @itemCnt = 3  
								set @ComputerName = @tempString;				
						if @itemCnt = 4  begin
								--print @tempString + 'dfd'
								set @ModuleCode = cast(@tempString as tinyint);				
								end
						if @itemCnt = 5  
								set @DataDescrip = @tempString;					
						if @itemCnt = 6  
								set @ScreenCaption = @tempString;					
						if @itemCnt = 7
								set @ActionDescrip = @tempString;
						if @itemCnt = 8
								set @AuditBa = cast(@tempString as tinyint);
						if @itemCnt = 9
								set @Machine = @tempString;
						if @itemCnt = 10
								set @TypeofWork = @tempString;
						if @itemCnt = 11
								set @Critical = cast(@tempString as tinyint);
						if @itemCnt = 12
								set @Maintenance = @tempString;
						if @itemCnt = 13
								set @Rank = @tempString;
						
						set @itemCnt = @itemCnt + 1	;
						set @tempString = '';
						
					end	
			set @index = @index + 1;
		end;
		
		set @LastUpdatedBy = @tempLastupdatedBy;						
	
	end
	else
		begin
			set @LastUpdatedBy = @LastUpdatedBy;
			set @AuditBa = 0;
		end
	-- set @ScreenCaption = 'sfds'
    -- Insert statements for procedure here
	-- SELECT <@Param1, sysname, @p1>, <@Param2, sysname, @p2>
END


GO
