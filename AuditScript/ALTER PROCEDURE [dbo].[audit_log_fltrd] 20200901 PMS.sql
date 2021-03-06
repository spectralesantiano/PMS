USE [pms_db]
GO
/****** Object:  StoredProcedure [dbo].[audit_log_fltrd]    Script Date: 1/9/2020 3:47:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[audit_log_fltrd]
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
	@rank nvarchar(50)= null,
	@siteid nvarchar(20)= null
	 
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

--/////////////////////// 20200901 /////////////////// commented
			--set @strSQL = 'select AuditLogID ,
			--				CrewID, 
			--				ScreenCaption ,
			--				ActionDescrip ,
			--				TableName ,
			--				PKeyField ,
			--				PKeyValue,
			--				DataDescrip,
			--				UserName ,
			--				ComputerName ,
			--				ModuleCode ,
			--				DateUpdated ,
			--				DExDate ,
			--				AdditionalInfo ,
			--				SiteID ,
			--				RecordKeyName ,
			--				Machine ,
			--				TypeOfWork,
			--				Critical,
			--				Maintenance,
			--				Rank,
			--				crewname  
			--				from 
			--				( 
			--				select AuditLog.*,NULL as crewname, 
			--				ROW_NUMBER() OVER (ORDER BY AuditLog.AuditLogID desc)as seq 
			--				FROM AuditLog 
			--				)t 
			--				where 1 = 1 '
			
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
			
			--if not @typeofwork is null
			--	set @strSQL = @strSQL + ' and typeofwork = ' + str(@typeofwork)
			
			--if not @critical is null
			--	set @strSQL = @strSQL + ' and critical = ' + str(@critical)
			
			--if not @machine is null
			--	set @strSQL = @strSQL + ' and Machine = ''' + @machine + ''''
			
			--if not @typeofaction is null
			--	set @strSQL = @strSQL + ' and ActionDescrip = ''' + @typeofaction + ''''
			
			--if not @maintenance is null
			--	set @strSQL = @strSQL + ' and maintenance = ''' + @maintenance + ''''		
				
			--if not @rank is null
			--	set @strSQL = @strSQL + ' and Rank = ''' + @rank + ''''	
			
			--if not @siteid is null
			--	set @strSQL = @strSQL + ' and SiteID = ''' + @siteid + ''''		
			
			--set @recordstart = @recordstart + 1 -- to start from the rec next to last skip rec
			
			--if @bypassreccnt = 0
			--	set @strSQL = @strSQL + ' and seq between ' + str(@recordstart) + ' and ' + str((@recordstart + @rowcount) - 1) 

--/////////////////////// 20200901
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
							where 1 = 1 '
			
			----------------------- cond 1------------------
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
			
			if not @siteid is null
				set @strSQL = @strSQL + ' and SiteID = ''' + @siteid + ''''		
			-------------------------------------

			set @strSQL = @strSQL + ' 				)t '
			set @strSQL = @strSQL + ' 				where 1 = 1 '
			------------------------------------ cond 2
			
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


