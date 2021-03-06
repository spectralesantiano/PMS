--USE [MPS4A]
--replace all pms_db. -> pms_db. / all pms_db. -> pms_db.
USE [pms_db]
GO
/****** Object:  Table [dbo].[AuditDetails]    Script Date: 2/11/2020 5:21:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AuditDetails](
	[AuditDetailID] [bigint] IDENTITY(1,1) NOT NULL,
	[AuditLogID] [bigint] NOT NULL,
	[FieldName] [varchar](50) NULL,
	[OldValue] [sql_variant] NULL,
	[NewValue] [sql_variant] NULL,
 CONSTRAINT [PK_AuditDetails] PRIMARY KEY CLUSTERED 
(
	[AuditDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AuditLog]    Script Date: 2/11/2020 5:21:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditLog](
	[AuditLogID] [bigint] IDENTITY(1,1) NOT NULL,
	[CrewID] [nvarchar](30) NULL,
	[ScreenCaption] [nvarchar](150) NULL,
	[ActionDescrip] [nvarchar](50) NULL,
	[TableName] [nvarchar](50) NULL,
	[PKeyField] [nvarchar](30) NULL,
	[PKeyValue] [nvarchar](20) NULL,
	[DataDescrip] [nvarchar](300) NULL,
	[UserName] [nvarchar](250) NULL,
	[ComputerName] [nvarchar](250) NULL,
	[ModuleCode] [tinyint] NULL,
	[DateUpdated] [datetime2](0) NULL,
	[DExDate] [datetime2](0) NULL,
	[AdditionalInfo] [nvarchar](100) NULL,
	[SiteID] [nvarchar](20) NOT NULL,
	[RecordKeyName] [nvarchar](300) NULL,
	[Machine] [nvarchar](100) NULL,
	[TypeOfWork] [tinyint] NULL,
	[Critical] [tinyint] NULL,
	[Maintenance] [nvarchar](50) NULL,
	[Rank] [nvarchar](50) NULL,
 CONSTRAINT [PK_AuditLog_1] PRIMARY KEY CLUSTERED 
(
	[AuditLogID] ASC,
	[SiteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AuditPreDel]    Script Date: 2/11/2020 5:21:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditPreDel](
	[AuditPreDelID] [bigint] IDENTITY(1,1) NOT NULL,
	[TableName] [nvarchar](50) NOT NULL,
	[PKeyValue] [nvarchar](20) NOT NULL,
	[PreLastUpdatedBy] [nvarchar](200) NOT NULL,
	[DateUpdated] [datetime] NOT NULL CONSTRAINT [DF_AuditPreDel_DateUpdated]  DEFAULT (getdate()),
 CONSTRAINT [PK_AuditPreDel_1] PRIMARY KEY CLUSTERED 
(
	[AuditPreDelID] ASC,
	[TableName] ASC,
	[PKeyValue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  UserDefinedFunction [dbo].[getAuditDetails]    Script Date: 2/11/2020 5:21:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[getAuditDetails]
(	
	-- Add the parameters for the function here
	@auditlogid bigint
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	select * from AuditDetails where AuditLogid = @auditlogid
)

GO
/****** Object:  View [dbo].[AuditTMainGrid_view]    Script Date: 2/11/2020 5:21:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[AuditTMainGrid_view]
AS
SELECT     dbo.AuditLog.AuditLogID, dbo.AuditLog.CrewID, dbo.AuditLog.ScreenCaption, dbo.AuditLog.ActionDescrip, dbo.AuditLog.DataDescrip, dbo.AuditLog.UserName, 
                      dbo.AuditLog.ComputerName, dbo.AuditLog.ModuleCode, dbo.AuditLog.DateUpdated, dbo.AuditLog.AdditionalInfo, dbo.AuditLog.SiteID, dbo.AuditDetails.FieldName, 
                      dbo.AuditDetails.OldValue, dbo.AuditDetails.NewValue
FROM         dbo.AuditDetails INNER JOIN
                      dbo.AuditLog ON dbo.AuditDetails.AuditLogID = dbo.AuditLog.AuditLogID

GO
--ALTER TABLE [dbo].[AuditDetails]  WITH CHECK ADD  CONSTRAINT [FK_AuditDetails_AuditLog] FOREIGN KEY([AuditLogID])
--REFERENCES [dbo].[AuditLog] ([AuditLogID])
--ON UPDATE CASCADE
--ON DELETE CASCADE
--GO
--ALTER TABLE [dbo].[AuditDetails] CHECK CONSTRAINT [FK_AuditDetails_AuditLog]
--GO
/****** Object:  StoredProcedure [dbo].[audit_log_fltrd]    Script Date: 2/12/2020 5:21:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[audit_log_fltrd]
	@crewid nvarchar(20)= '<NOCRITERIA>',
	@crewname nvarchar(100) = '<NOCRITERIA>',
	@updatedby nvarchar(200) ='<NOCRITERIA>',
	@datefrom datetime = NULL,
	@dateto datetime = NULL,
	@screen nvarchar(50) = '<NOCRITERIA>',
	@modulecode smallint = 999,
	@recordstart bigint = 0, ---actually number of rows to skip ex if 0 then no rec to skip. if 2 means skip 2 recs start at rec 3
	@rowcount bigint = 25,
	@bypassreccnt smallint = 0,
	@typeofwork smallint = null,
	@critical smallint = null,
	@machine nvarchar(100) = null,
	@typeofaction nvarchar(20) = null,
	@maintenance nvarchar(50) = null,
	@rank nvarchar(50)= null
	 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	 DECLARE 
            @LocalError     INT,
            @ErrorMessage   VARCHAR(4000),
            @strSQL nvarchar(max)

	begin try
	---///// sql server 2012 onwards //////////////////////////////////////////		
			--set @strSQL = 'select AuditLog.*,NULL as crewname '
			--set @strSQL = @strSQL + 'FROM AuditLog '
			--set @strSQL = @strSQL + 'where 1 = 1 ' 
			----///

			----if @crewid <> '<NOCRITERIA>'
			----			set @strSQL = @strSQL + ' and crewid = ''' + @crewid + ''' '
			
			----if @crewname <> '<NOCRITERIA>'
			----			set @strSQL = @strSQL + ' and crewname like ''%' + @crewname + '%'' '

			--if @updatedby <> '<NOCRITERIA>'
			--			set @strSQL = @strSQL + ' and username like ''%' + @updatedby + '%'' '

			--if @screen <> '<NOCRITERIA>'
			--			set @strSQL = @strSQL + ' and screencaption like ''%' + @screen + '%'' '

			--if @modulecode <> 999
			--	if @modulecode = 0 --or  @modulecode is null
			--				set @strSQL = @strSQL + 'and (ModuleCode = 0 or ModuleCode is null)'
			--	else
			--				set @strSQL = @strSQL + ' and ModuleCode = ' + str(@modulecode) + ' '

			--if @dateto is null 
			--	set @dateto = DATEADD(day, DATEDIFF(day, 0, GETDATE()), 1) -- current date if not specified
			--else
			--	set @dateto = DATEADD(day, DATEDIFF(day, 0, @dateto), 1) -- current date if not specified
			--if @datefrom is null 
			--	set @datefrom = DATEADD(day, DATEDIFF(day, 0, GETDATE()), -5) --5 days before if not specified

			--set @strSQL = @strSQL + ' and dateupdated between ''' + convert(nvarchar,@datefrom) + ''' and ''' + convert(nvarchar,@dateto) + ''' '
			
			--set @strSQL = @strSQL + ' ORDER BY AuditLog.AuditLogID desc '

			--if @bypassreccnt = 0
			--	set @strSQL = @strSQL + ' OFFSET ' + str(@recordstart) + ' ROWS FETCH NEXT ' + str(@rowcount) + ' ROWS ONLY'

--/////////////////////////////////////////////////////////////////////////////////

--example. /////this one should be use for sql server 2008 as "OFFSET" available from 2012 onwards

--select t.*,NULL as crewname
--from
--(
--	select AuditLog.*,NULL as crewname,
--	ROW_NUMBER() OVER (ORDER BY AuditLog.AuditLogID desc)as seq
--	 FROM AuditLog
--)t
--	where 1 = 1  and dateupdated between 'Feb 28 2020 12:00AM' and 'Mar  5 2020 12:00AM'  
--	and seq between 0 and 25

			set @strSQL = 'select AuditLogID ,
							CrewID, 
							ScreenCaption ,
							ActionDescrip ,
							TableName ,
							PKeyField ,
							PKeyValue,
							DataDescrip,
							UserName ,
							ComputerName ,
							ModuleCode ,
							DateUpdated ,
							DExDate ,
							AdditionalInfo ,
							SiteID ,
							RecordKeyName ,
							Machine ,
							TypeOfWork,
							Critical,
							Maintenance,
							Rank,
							crewname  
							from 
							( 
							select AuditLog.*,NULL as crewname, 
							ROW_NUMBER() OVER (ORDER BY AuditLog.AuditLogID desc)as seq 
							FROM AuditLog 
							)t 
							where 1 = 1 '
			
			if @updatedby <> '<NOCRITERIA>'
						set @strSQL = @strSQL + ' and username like ''%' + @updatedby + '%'' '

			if @screen <> '<NOCRITERIA>'
						set @strSQL = @strSQL + ' and screencaption like ''%' + @screen + '%'' '

			if @modulecode <> 999
				if @modulecode = 0 --or  @modulecode is null
							set @strSQL = @strSQL + 'and (ModuleCode = 0 or ModuleCode is null)'
				else
							set @strSQL = @strSQL + ' and ModuleCode = ' + str(@modulecode) + ' '

			if @dateto is null 
				set @dateto = DATEADD(day, DATEDIFF(day, 0, GETDATE()), 1) -- current date if not specified
			else
				set @dateto = DATEADD(day, DATEDIFF(day, 0, @dateto), 1) -- current date if not specified
			if @datefrom is null 
				set @datefrom = DATEADD(day, DATEDIFF(day, 0, GETDATE()), -5) --5 days before if not specified

			set @strSQL = @strSQL + ' and dateupdated between ''' + convert(nvarchar,@datefrom) + ''' and ''' + convert(nvarchar,@dateto) + ''' '
			
			if not @typeofwork is null
				set @strSQL = @strSQL + ' and typeofwork = ' + str(@typeofwork)
			
			if not @critical is null
				set @strSQL = @strSQL + ' and critical = ' + str(@critical)
			
			if not @machine is null
				set @strSQL = @strSQL + ' and Machine = ''' + @machine + ''''
			
			if not @typeofaction is null
				set @strSQL = @strSQL + ' and ActionDescrip = ''' + @typeofaction + ''''
			
			if not @maintenance is null
				set @strSQL = @strSQL + ' and maintenance = ''' + @maintenance + ''''		
				
			if not @rank is null
				set @strSQL = @strSQL + ' and Rank = ''' + @rank + ''''		
			
			set @recordstart = @recordstart + 1 -- to start from the rec next to last skip rec
			
			if @bypassreccnt = 0
				set @strSQL = @strSQL + ' and seq between ' + str(@recordstart) + ' and ' + str((@recordstart + @rowcount) - 1) 

--//////////////////////////////////////////////////////////////
			print @strsql
			EXECUTE sp_executesql @strSQL


	end try
	begin catch
		SELECT 
			@LocalError = ERROR_NUMBER() , -- as ErrorNumber,
			@ErrorMessage = ERROR_MESSAGE();  
			
			RAISERROR(@ErrorMessage,1,200,@LocalError,@ErrorMessage);
			--set @returnKo = 0;
		 -- RETURN(0)
	end catch
END


GO
/****** Object:  StoredProcedure [dbo].[audit_main]    Script Date: 2/12/2020 6:00:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[audit_main]
	@p_crewid nvarchar(20)= '<NOCRITERIA>',
	@p_crewname nvarchar(100) = '<NOCRITERIA>',
	@p_updatedby nvarchar(200) ='<NOCRITERIA>',
	@p_datefrom datetime = NULL,
	@p_dateto datetime = NULL,
	@p_screen nvarchar(50) = '<NOCRITERIA>',
	@p_modulecode smallint = 999,
	@p_recordstart bigint = 0,
	@p_rowcount bigint = 25,
	@p_bypassreccnt smallint = 0,
	@p_typeofwork smallint = null,
	@p_critical smallint = null,
	@p_machine nvarchar(100) = null,
	@p_typeofaction nvarchar(20) = null,
	@p_maintenance nvarchar (50) = null,
	@p_rank nvarchar (50) = null
	 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	 DECLARE 
            @LocalError     INT,
            @ErrorMessage   VARCHAR(4000),
            @strSQL nvarchar(max)

	begin try

		IF OBJECT_ID('tempdb..#AuditTemp') IS NOT NULL
		DROP TABLE #AuditTemp
		
		CREATE TABLE #AuditTemp (
			[AuditLogID] [bigint],
			[CrewID] [nvarchar](50) NULL,
			[ScreenCaption] [nvarchar](50) NULL,
			[ActionDescrip] [nvarchar](50) NULL,
			[TableName] [nvarchar](50) NULL,
			[PKeyField] [nvarchar](30) NULL,
			[PKeyValue] [nvarchar](20) NULL,
			[DataDescrip] [nvarchar](max) NULL,
			[UserName] [nvarchar](50) NULL,
			[ComputerName] [nvarchar](50) NULL,
			[ModuleCode] [tinyint] NULL,
			[DateUpdated] [datetime2](0) NULL,
			[DExDate] [datetime2](0) NULL,
			[AdditionalInfo] [nvarchar](100) NULL,
			[SiteID] [nvarchar](20) NULL,
			[RecordKeyName] [nvarchar](300) NULL,
			[Machine] [nvarchar](100) null,
			[TypeOfWork][tinyint],
			[Critical] [tinyint],
			[Maintenance] [nvarchar](50),
			[Rank] [nvarchar](50),
			[crewname] [nvarchar](300) NULL--,
			--[newvaluename] [nvarchar](300) NULL
		)

		DECLARE	@return_value int
		INSERT INTO #AuditTemp
		
		--filters
		EXEC	@return_value = [dbo].[audit_log_fltrd]
				@crewid =		@p_crewid,
				@crewname =		@p_crewname,
				@updatedby  =   @p_updatedby ,
				@datefrom  =    @p_datefrom ,
				@dateto  = 	    @p_dateto ,
				@screen =       @p_screen ,
				@modulecode  =  @p_modulecode ,
				@recordstart  = @p_recordstart ,
				@rowcount  =    @p_rowcount,
				@bypassreccnt = @p_bypassreccnt ,
				@typeofwork  =	@p_typeofwork,
				@critical  =	@p_critical,
				@machine =		@p_machine,
				@typeofaction = @p_typeofaction,
				@maintenance  = @p_maintenance,
				@rank =			@p_rank
													
		--select * from #Temp t1

		

		--///////////////// get names for code values ////////// START
		IF OBJECT_ID('tempdb..#AuditTempCodeValues') IS NOT NULL
		DROP TABLE #AuditTempCodeValues
		
		CREATE TABLE #AuditTempCodeValues (
			[AuditLogID] [bigint],
			[CrewID] [nvarchar](50) NULL,
			[ScreenCaption] [nvarchar](50) NULL,
			[ActionDescrip] [nvarchar](50) NULL,
			[TableName] [nvarchar](50) NULL,
			[PKeyField] [nvarchar](30) NULL,
			[PKeyValue] [nvarchar](max) NULL,
			[RecordName] [nvarchar](max) NULL,
			[DataDescrip] [nvarchar](max) NULL,
			[UserName] [nvarchar](50) NULL,
			[ComputerName] [nvarchar](50) NULL,
			[ModuleCode] [tinyint] NULL,
			[DateUpdated] [datetime2](0) NULL,
			--[DExDate] [datetime2](0) NULL,
			--[AdditionalInfo] [nvarchar](100) NULL,
			[SiteID] [nvarchar](20) NULL,
			[crewname] [nvarchar](300) NULL,
			[flddesc] [nvarchar](100) NULL,
			[AuditDetailID] [bigint],
			[OldValue] [sql_variant] NULL,
			[NewValue] [sql_variant] NULL,
			[refTable] [nvarchar](100) NULL,
			[OldValueName] [nvarchar](max) NULL,
			[NewValueName] [nvarchar](max) NULL,
			[Machine] [nvarchar] (100),
			[TypeOfWork][tinyint],
			[Critical] [tinyint],
			[Maintenance] [nvarchar](50),
			[Rank] [nvarchar](50),
		)

		insert INTO #AuditTempCodeValues
		SELECT  alog.[AuditLogID]
				, alog.[CrewID]
				, alog.[ScreenCaption]
				, alog.[ActionDescrip]
				, alog.[TableName]
				, alog.[PKeyField]
				, alog.[PKeyValue]
				, alog.[RecordKeyName]
				, alog.[DataDescrip]
				, alog.[UserName]
				, alog.[ComputerName]
				, alog.[ModuleCode]
				, alog.[DateUpdated]
				, alog.[SiteID]       
				, alog.[crewname]
				, AuditDetails.FieldName,AuditDetails.AuditDetailID, AuditDetails.OldValue, AuditDetails.NewValue , pms_db.dbo.getReferencedTable(alog.tablename,FieldName)
				, NULL , NULL, alog.Machine, alog.TypeOfWork, alog.Critical, alog.Maintenance, alog.Rank
		FROM    AuditDetails RIGHT OUTER JOIN
								 #AuditTemp alog ON AuditDetails.AuditLogID = alog.AuditLogID
							--	 where AuditLog.auditlogid = 98
							--outer apply
							--pms_db.dbo.getcrewname(alog.CrewID) as crew

							--//commented below for pms
							--outer apply
							--pms_db.dbo.getfldDescription(alog.TableName,AuditDetails.FieldName) as fld
							
							--where AuditDetails.FieldName <> 'dateupdated' and AuditDetails.FieldName <> 'lastupdatedby'

		--EXECUTE sp_executesql @strSQL

		declare @oldvalcode sql_variant
		declare @newvalcode sql_variant
		declare @reftable nvarchar(100)
		declare @csql nvarchar(max)
		declare @newvaluename nvarchar(max)
		declare @cnewvalcode nvarchar(100)
		declare @oldvaluename nvarchar(max)
		declare @coldvalcode nvarchar(100)
		declare @detailID bigint
		declare @finalOld nvarchar(max)
		declare @finalNew nvarchar(max)
		declare @tablename nvarchar(50)
		declare @pkeyvalue nvarchar(30)
		--declare @recordname nvarchar(100)
		declare @pkeyfield nvarchar(255)

		--declare cur cursor for select AuditDetailID,OldValue,NewValue,refTable,TableName,RecordName,PKeyField from #AuditTempCodeValues open cur
		declare cur cursor for select AuditDetailID,OldValue,NewValue,refTable,TableName,PKeyField from #AuditTempCodeValues open cur

		--fetch next from cur into @detailID,@oldvalcode,@newvalcode,@reftable,@tablename,@pkeyvalue,@pkeyfield
		fetch next from cur into @detailID,@oldvalcode,@newvalcode,@reftable,@tablename,@pkeyfield

		while @@FETCH_STATUS = 0 begin
			print '      '
			--print concat('deatil ID: --- ',@detailID)
			set @cnewvalcode = cast(@newvalcode as nvarchar(100))
			--print concat('ff - ',@cnewvalcode)
			set @coldvalcode = cast(@oldvalcode as nvarchar(100))
			--print  concat('xx - ',@coldvalcode)

			if @reftable is not null begin -- @newvalcode is not null or @oldvalcode is not null begin
					print 'adfasdfds'
					exec pms_db.dbo.getCodeValue_sp @reftable,@cnewvalcode, @newvaluename output ,@pkeyfield
					print 'adfasdfds 2'
					exec pms_db.dbo.getCodeValue_sp @reftable,@coldvalcode, @oldvaluename output,@pkeyfield
					--exec @oldvaluename = pms_db.dbo.getCodeValue_sp @reftable,@coldvalcode

					--select @oldvaluename
				end
			else
				begin
					set @newvaluename = NULL
					set @oldvaluename = NULL
				end
				--set @newvaluename = 'tae'

			if @newvaluename is not null and @newvaluename <> ''
				set @finalNew =''''+  replace(@newvaluename,'''','''''') + ''''
			else
				if @cnewvalcode is null
					set @finalNew = 'NULL'
				else
					set @finalNew = ''''+ replace(@cnewvalcode,'''','''''') + ''''

			if @oldvaluename is not null and @oldvaluename <> ''
				set @finalOld = '''' + replace(@oldvaluename,'''','''''') + ''''
			else
				if @coldvalcode is null
					set @finalOld = 'NULL'
				else
					set @finalOld = '''' + replace(@coldvalcode,'''','''''') + ''''

			print @finalNew
			print @finalOld

			--exec pms_db.dbo.getCodeValue_sp @tablename,@pkeyvalue, @recordname output,@pkeyfield

			--if (@newvaluename is null or @newvaluename = '') and (@oldvaluename is null or @oldvaluename = '')  begin
				set @csql = 'update #AuditTempCodeValues set newvaluename = ' + @finalNew 
				set @csql = @csql + ', oldvaluename = ' + @finalOld
				--20160627 set @csql = @csql + ', RecordName = ''' + @recordname + ''''
				set @csql = @csql + ' where auditdetailid = '+ str(@detailID)
			--	end
			--else begin
			--	print '6'
			--	--set @csql = 'update #AuditTempCodeValues set newvaluename = '''+ @newvaluename + '''' 
			--	set @csql = 'update #AuditTempCodeValues set newvaluename = ''tae''' 
			--	set @csql = @csql +  ', oldvaluename = ''' + @oldvaluename + '''' 
			--	set @csql = @csql + ' where auditdetailid = '+ str(@detailID)
			--	print '7'
			--	end

			print @csql
			EXECUTE sp_executesql @csql
			--20160627 FETCH NEXT FROM cur INTO @detailID,@oldvalcode,@newvalcode,@reftable,@tablename,@pkeyvalue,@pkeyfield
			FETCH NEXT FROM cur INTO @detailID,@oldvalcode,@newvalcode,@reftable,@tablename,@pkeyfield
		end

		close cur
		deallocate cur

		--select * from #AuditTempCodeValues order by DateUpdated desc
		select * from #AuditTempCodeValues order by AuditLogID desc
	end try
	begin catch
		SELECT 
			@LocalError = ERROR_NUMBER() , -- as ErrorNumber,
			@ErrorMessage = ERROR_MESSAGE();  
			
			RAISERROR(@ErrorMessage,1,200,@LocalError,@ErrorMessage);
			--set @returnKo = 0;
		 -- RETURN(0)
		   print error_message()
	end catch
END



GO
/****** Object:  StoredProcedure [dbo].[auditTfilter]    Script Date: 2/11/2020 5:21:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[auditTfilter] 
	-- Add the parameters for the stored procedure here
	@colname nvarchar(20),
	@dateStart date  ,
	@dateend date
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	if @dateStart is null
		set @dateStart = GETDATE()
	if @dateend is null
		set @dateend = GETDATE()
	
	-- should always have two columns. 1st column for value 2nd for text display
	if @colname ='CREWNAME'
		--///// commented below. not applicable for PMS
		--SELECT MPS4A.dbo.tblCrewInfo.pkey,MPS4A.dbo.tblCrewInfo.LName + ',' + MPS4A.dbo.tblCrewInfo.fName AS crewname 
		--		from MPS4A.dbo.tblCrewInfo where MPS4A.dbo.tblCrewInfo.lName + ',' + MPS4A.dbo.tblCrewInfo.fName is not null
		--		order by MPS4A.dbo.tblCrewInfo.lName + ',' + MPS4A.dbo.tblCrewInfo.fName asc		
		--/////		
	if @colname ='USERNAME'
		select username as Colvalue,UserName from pms_db.dbo.AuditLog where UserName is not NULL
		group by username
	--if @colname ='USERNAME'
	--if @colname =''
	--end
    -- Insert statements for procedure here
	
END

GO
/****** Object:  StoredProcedure [dbo].[auditTMainGridSP]    Script Date: 2/11/2020 5:21:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- ==========================--+-+===================
CREATE PROCEDURE [dbo].[auditTMainGridSP]
	-- Add the parameters for the stored procedure here
	@DateFrom date,
	@DateTo date,
	@CrewIDNbrS  nvarchar(max) ='',
	@UserNames nvarchar(max)=''
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @SSql nvarchar(max)
	
    -- Insert statements for procedure here
	--set @SSql = 'SELECT dbo.AuditLog.AuditLogID, dbo.AuditLog.CrewID, dbo.AuditLog.ScreenCaption, dbo.AuditLog.ActionDescrip, dbo.AuditLog.DataDescrip, dbo.AuditLog.UserName, dbo.AuditLog.ComputerName, dbo.AuditLog.ModuleCode, dbo.AuditLog.DateUpdated, dbo.AuditLog.AdditionalInfo, dbo.AuditLog.SiteID, dbo.AuditDetails.FieldName, dbo.AuditDetails.OldValue, dbo.AuditDetails.NewValue FROM dbo.AuditDetails INNER JOIN dbo.AuditLog ON dbo.AuditDetails.AuditLogID = dbo.AuditLog.AuditLogID'
	set @SSql = 'SELECT dbo.AuditLog.AuditLogID, dbo.AuditLog.CrewID, pms_db.dbo.tblCrewInfo.LName,pms_db.dbo.tblCrewInfo.FName, dbo.AuditLog.ScreenCaption, dbo.AuditLog.ActionDescrip, dbo.AuditLog.DataDescrip, 
                      dbo.AuditLog.UserName, dbo.AuditLog.ComputerName, dbo.AuditLog.ModuleCode, dbo.AuditLog.DateUpdated, dbo.AuditLog.AdditionalInfo, dbo.AuditLog.SiteID, 
                      dbo.AuditDetails.FieldName, dbo.AuditDetails.OldValue, dbo.AuditDetails.NewValue
						FROM dbo.AuditDetails INNER JOIN
                      dbo.AuditLog ON dbo.AuditDetails.AuditLogID = dbo.AuditLog.AuditLogID LEFT OUTER JOIN
                      pms_db.dbo.tblCrewInfo ON dbo.AuditLog.CrewID COLLATE Latin1_General_CI_AS = pms_db.dbo.tblCrewInfo.PKey'
	set @SSql = @SSql + ' where (dbo.AuditLog.dateupdated between ''' + cast(@datefrom as varchar(100)) + ''' and ''' + cast(@dateto as varchar(100)) + ''')'
	-- set @SSql = @SSql + ' WHERE dbo.AuditLog.CrewID is not null '
	--where dbo.AuditLog.CrewID in (''xxKXWAR0G4431S7JO'', ''xxKXWAR4C4N0LBBMU'', ''xxKXWAR9EYLI9SCPI'') and dbo.AuditLog.CrewID <> null'

	--set @SSql = 'select * from auditlog where crewid is not null'
   if @CrewIDNbrS <> '' begin
		set @SSql = @SSql + ' and ' 
		set @SSql = @SSql + ' (dbo.AuditLog.CrewID in ( ' + @CrewIDNbrS + ' ))'
		-- exec(@ssql)
   end
   if @UserNames <> '' begin
		set @SSql = @SSql + ' and ' 
		set @SSql = @SSql + ' (dbo.AuditLog.UserName in ( ' + @UserNames + ' ))'
   end
   -- exec ('SELECT dbo.AuditLog.AuditLogID, dbo.AuditLog.CrewID, dbo.AuditLog.ScreenCaption, dbo.AuditLog.ActionDescrip, dbo.AuditLog.DataDescrip, dbo.AuditLog.UserName, dbo.AuditLog.ComputerName, dbo.AuditLog.ModuleCode, dbo.AuditLog.DateUpdated, dbo.AuditLog.AdditionalInfo, dbo.AuditLog.SiteID, dbo.AuditDetails.FieldName, dbo.AuditDetails.OldValue, dbo.AuditDetails.NewValue FROM dbo.AuditDetails INNER JOIN dbo.AuditLog ON dbo.AuditDetails.AuditLogID = dbo.AuditLog.AuditLogID where dbo.AuditLog.CrewID =''xxx''')
   exec(@ssql)
END                                                                     

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'form caption ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditLog', @level2type=N'COLUMN',@level2name=N'ScreenCaption'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Add,Update,Delete, Sign-off, sign-on, mps open, user logs,user log-out, plan crew, MPS close, transfer to archive/active etc' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditLog', @level2type=N'COLUMN',@level2name=N'ActionDescrip'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'primary key field ex ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditLog', @level2type=N'COLUMN',@level2name=N'PKeyField'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'biodata info, sea service, admin, certificates, relatives, payroll' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditLog', @level2type=N'COLUMN',@level2name=N'DataDescrip'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'user log name' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditLog', @level2type=N'COLUMN',@level2name=N'UserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'computer name / ip ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditLog', @level2type=N'COLUMN',@level2name=N'ComputerName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1;mps, 2;mps archive, 3;docreader; 4;mpsi 5;ltp' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditLog', @level2type=N'COLUMN',@level2name=N'ModuleCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'future use..ex for multi degree sub child table. parent table;recordid > child1;recordid > child1.1;recordid' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditLog', @level2type=N'COLUMN',@level2name=N'AdditionalInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[13] 4[5] 2[43] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "AuditDetails"
            Begin Extent = 
               Top = 10
               Left = 315
               Bottom = 245
               Right = 475
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "AuditLog"
            Begin Extent = 
               Top = 23
               Left = 94
               Bottom = 260
               Right = 257
            End
            DisplayFlags = 280
            TopColumn = 3
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 22
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'AuditTMainGrid_view'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'AuditTMainGrid_view'
GO
