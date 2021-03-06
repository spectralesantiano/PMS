/*
   Tuesday, March 24, 202011:52:50 AM
   User: sa
   Server: localhost\stisqlserver
   Database: pms_db
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_tblPlannedWork
	(
	MaintenanceWorkID int NOT NULL,
	PlannedDate date NOT NULL,
	Reason varchar(5000) NOT NULL,
	ApprovedBy varchar(200) NOT NULL,
	LastUpdatedBy varchar(200) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_tblPlannedWork SET (LOCK_ESCALATION = TABLE)
GO
IF EXISTS(SELECT * FROM dbo.tblPlannedWork)
	 EXEC('INSERT INTO dbo.Tmp_tblPlannedWork (MaintenanceWorkID, PlannedDate, Reason, ApprovedBy, LastUpdatedBy)
		SELECT MaintenanceWorkID, PlannedDate, CONVERT(varchar(5000), Reason), ApprovedBy, LastUpdatedBy FROM dbo.tblPlannedWork WITH (HOLDLOCK TABLOCKX)')
GO
ALTER TABLE dbo.tblPlannedWork
	DROP CONSTRAINT FK_tblPlannedWork_tblPlannedWork
GO
DROP TABLE dbo.tblPlannedWork
GO
EXECUTE sp_rename N'dbo.Tmp_tblPlannedWork', N'tblPlannedWork', 'OBJECT' 
GO
ALTER TABLE dbo.tblPlannedWork ADD CONSTRAINT
	PK_tblPlannedWork PRIMARY KEY CLUSTERED 
	(
	MaintenanceWorkID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.tblPlannedWork ADD CONSTRAINT
	FK_tblPlannedWork_tblPlannedWork FOREIGN KEY
	(
	MaintenanceWorkID
	) REFERENCES dbo.tblPlannedWork
	(
	MaintenanceWorkID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
CREATE TRIGGER [dbo].[tblPlannedWork_ins]     ON  dbo.tblPlannedWork    AFTER insert AS  BEGIN   if @@ROWCOUNT = 0    return   SET NOCOUNT ON;   DECLARE @ColumnName nvarchar(200)  DECLARE @sql NVARCHAR(500)  DECLARE @valueOld sql_variant  DECLARE @valueNew sql_variant  select NULL mykey, * into #tblInserted from inserted   select NULL mykey, * into #tblDeleted from deleted    DECLARE @lastupdatedby nvarchar(500)  DECLARE @CrewID nvarchar(20)  DECLARE @ComputerName nvarchar(50)  DECLARE @ModuleCode nvarchar(10)  DECLARE @DataDescrip nvarchar(300)  DECLARE @ScreenCaption nvarchar(50)  DECLARE @ActionDescrip nvarchar(300)  DECLARE @AuditBa tinyint  DECLARE @InsertedID nvarchar(20)  DECLARE @RecordKeyName nvarchar(300) = Null    DECLARE @Machine nvarchar(100) = Null    DECLARE @TypeofWork tinyint = Null    DECLARE @Critical tinyint = Null    DECLARE @Maintenance nvarchar(100) = Null    DECLARE @Rank nvarchar(50) = Null    DECLARE @DateUpdated datetime2  DECLARE @PKey nvarchar(20)   SET XACT_ABORT off    select @DateUpdated = getdate(),@PKey = [MaintenanceWorkID] from #tblInserted   select @lastupdatedby = lastupdatedby from #tblInserted   if @lastupdatedby is null or @lastupdatedby = ''    return     IF not UPDATE ([LastUpdatedBy])    return    exec pms_db.dbo.splitLastUpdatedby @lastupdatedby output,@CrewID output,@ComputerName output,@ModuleCode output,@DataDescrip output,     @ScreenCaption output,@ActionDescrip output,@AuditBa output,@Machine output, @TypeofWork output, @Critical output, @Maintenance output, @Rank output   if @AuditBa = 0    return    if @ActionDescrip = ''   set @ActionDescrip = 'Add'    select @RecordKeyName = [MaintenanceWorkID] from #tblInserted    exec pms_db.dbo.auditSaveLog @CrewID,@ComputerName,@ModuleCode,@DataDescrip,@ScreenCaption,@ActionDescrip,     @DateUpdated,'tblPlannedWork','[MaintenanceWorkID]',@PKey,'',@lastupdatedby,@InsertedID output,@RecordKeyName,@Machine,@TypeofWork,@Critical,@Maintenance,@Rank   select @valueOld = [MaintenanceWorkID] from #tblDeleted  select @valueNew = [MaintenanceWorkID] from #tblInserted   if @valueNew is not null begin     exec pms_db.dbo.auditSaveDetails @InsertedID,'[MaintenanceWorkID]', @valueOld, @valueNew  end   select @valueOld = [PlannedDate] from #tblDeleted  select @valueNew = [PlannedDate] from #tblInserted   if @valueNew is not null begin     exec pms_db.dbo.auditSaveDetails @InsertedID,'[PlannedDate]', @valueOld, @valueNew  end   select @valueOld = [Reason] from #tblDeleted  select @valueNew = [Reason] from #tblInserted   if @valueNew is not null begin     exec pms_db.dbo.auditSaveDetails @InsertedID,'[Reason]', @valueOld, @valueNew  end   select @valueOld = [ApprovedBy] from #tblDeleted  select @valueNew = [ApprovedBy] from #tblInserted   if @valueNew is not null begin     exec pms_db.dbo.auditSaveDetails @InsertedID,'[ApprovedBy]', @valueOld, @valueNew  end   select @valueOld = [LastUpdatedBy] from #tblDeleted  select @valueNew = [LastUpdatedBy] from #tblInserted   if @valueNew is not null begin     exec pms_db.dbo.auditSaveDetails @InsertedID,'[LastUpdatedBy]', @valueOld, @valueNew  end    End
GO
CREATE TRIGGER [dbo].[tblPlannedWork_upd]     ON  dbo.tblPlannedWork    AFTER UPDATE AS  BEGIN   if @@ROWCOUNT = 0    return   SET NOCOUNT ON;   DECLARE @ColumnName nvarchar(200)  DECLARE @sql NVARCHAR(500)  DECLARE @valueOld sql_variant  DECLARE @valueNew sql_variant  select NULL mykey, * into #tblInserted from inserted   select NULL mykey, * into #tblDeleted from deleted    DECLARE @lastupdatedby nvarchar(500)  DECLARE @CrewID nvarchar(20)  DECLARE @ComputerName nvarchar(50)  DECLARE @ModuleCode nvarchar(10)  DECLARE @DataDescrip nvarchar(300)  DECLARE @ScreenCaption nvarchar(50)  DECLARE @ActionDescrip nvarchar(300)  DECLARE @AuditBa tinyint  DECLARE @InsertedID nvarchar(20)  DECLARE @RecordKeyName nvarchar(300) = Null    DECLARE @Machine nvarchar(100) = Null    DECLARE @TypeofWork tinyint = Null    DECLARE @Critical tinyint = Null    DECLARE @Maintenance nvarchar(100) = Null    DECLARE @Rank nvarchar(50) = Null    DECLARE @DateUpdated datetime2  DECLARE @PKey nvarchar(20)   SET XACT_ABORT off   set rowcount 1 update #tblInserted set mykey = 1 update #tblDeleted set mykey = 1  while @@rowcount > 0 begin   set rowcount 0  set @ActionDescrip = ''   select @DateUpdated = getdate(),@PKey = [MaintenanceWorkID] from #tblInserted  where mykey = 1   select @lastupdatedby = lastupdatedby from #tblInserted where mykey = 1   if @lastupdatedby is null or @lastupdatedby = ''    return     IF not UPDATE ([LastUpdatedBy])    return    exec pms_db.dbo.splitLastUpdatedby @lastupdatedby output,@CrewID output,@ComputerName output,@ModuleCode output,@DataDescrip output,     @ScreenCaption output,@ActionDescrip output,@AuditBa output,@Machine output, @TypeofWork output, @Critical output, @Maintenance output, @Rank output   if @AuditBa = 0    return    if @ActionDescrip = ''   set @ActionDescrip = 'Edit'    select @RecordKeyName = [MaintenanceWorkID] from #tblInserted    exec pms_db.dbo.auditSaveLog @CrewID,@ComputerName,@ModuleCode,@DataDescrip,@ScreenCaption,@ActionDescrip,     @DateUpdated,'tblPlannedWork','[MaintenanceWorkID]',@PKey,'',@lastupdatedby,@InsertedID output,@RecordKeyName,@Machine,@TypeofWork,@Critical,@Maintenance,@Rank   if UPDATE([MaintenanceWorkID])begin   select @valueOld = [MaintenanceWorkID] from #tblDeleted where mykey = 1  select @valueNew = [MaintenanceWorkID] from #tblInserted where mykey = 1      exec pms_db.dbo.auditSaveDetails @InsertedID,'[MaintenanceWorkID]', @valueOld, @valueNew  end   if UPDATE([PlannedDate])begin   select @valueOld = [PlannedDate] from #tblDeleted where mykey = 1  select @valueNew = [PlannedDate] from #tblInserted where mykey = 1      exec pms_db.dbo.auditSaveDetails @InsertedID,'[PlannedDate]', @valueOld, @valueNew  end   if UPDATE([Reason])begin   select @valueOld = [Reason] from #tblDeleted where mykey = 1  select @valueNew = [Reason] from #tblInserted where mykey = 1      exec pms_db.dbo.auditSaveDetails @InsertedID,'[Reason]', @valueOld, @valueNew  end   if UPDATE([ApprovedBy])begin   select @valueOld = [ApprovedBy] from #tblDeleted where mykey = 1  select @valueNew = [ApprovedBy] from #tblInserted where mykey = 1      exec pms_db.dbo.auditSaveDetails @InsertedID,'[ApprovedBy]', @valueOld, @valueNew  end   if UPDATE([LastUpdatedBy])begin   select @valueOld = [LastUpdatedBy] from #tblDeleted where mykey = 1  select @valueNew = [LastUpdatedBy] from #tblInserted where mykey = 1      exec pms_db.dbo.auditSaveDetails @InsertedID,'[LastUpdatedBy]', @valueOld, @valueNew  end   delete #tblinserted where mykey = 1  delete #tblDeleted where mykey = 1  set rowcount 1  update #tblinserted set mykey = 1  update #tblDeleted set mykey = 1 end set rowcount 0   End
GO
CREATE TRIGGER [dbo].[tblPlannedWork_del]     ON  dbo.tblPlannedWork    AFTER delete AS  BEGIN   if @@ROWCOUNT = 0    return   SET NOCOUNT ON;   DECLARE @ColumnName nvarchar(200)  DECLARE @sql NVARCHAR(500)  DECLARE @valueOld sql_variant  DECLARE @valueNew sql_variant  select NULL mykey, * into #tblInserted from inserted   select NULL mykey, * into #tblDeleted from deleted    DECLARE @lastupdatedby nvarchar(500)  DECLARE @CrewID nvarchar(20)  DECLARE @ComputerName nvarchar(50)  DECLARE @ModuleCode nvarchar(10)  DECLARE @DataDescrip nvarchar(300)  DECLARE @ScreenCaption nvarchar(50)  DECLARE @ActionDescrip nvarchar(300)  DECLARE @AuditBa tinyint  DECLARE @InsertedID nvarchar(20)  DECLARE @RecordKeyName nvarchar(300) = Null    DECLARE @Machine nvarchar(100) = Null    DECLARE @TypeofWork tinyint = Null    DECLARE @Critical tinyint = Null    DECLARE @Maintenance nvarchar(100) = Null    DECLARE @Rank nvarchar(50) = Null    DECLARE @DateUpdated datetime2  DECLARE @PKey nvarchar(20)   SET XACT_ABORT off   set rowcount 1 update #tblDeleted set mykey = 1  while @@rowcount > 0 begin   set rowcount 0  set @ActionDescrip = ''   select @DateUpdated = getdate(),@PKey = [MaintenanceWorkID] from #tblDeleted where mykey = 1    select @lastupdatedby =  dbo.AuditGetDelLastUBy('tblPlannedWork',@PKey)   if @lastupdatedby is null or @lastupdatedby = ''    return    exec pms_db.dbo.splitLastUpdatedby @lastupdatedby output,@CrewID output,@ComputerName output,@ModuleCode output,@DataDescrip output,     @ScreenCaption output,@ActionDescrip output,@AuditBa output,@Machine output, @TypeofWork output, @Critical output, @Maintenance output, @Rank output   if @AuditBa = 0    return    if @ActionDescrip = ''   set @ActionDescrip = 'Delete'    select @RecordKeyName = [MaintenanceWorkID] from #tblDeleted    exec pms_db.dbo.auditSaveLog @CrewID,@ComputerName,@ModuleCode,@DataDescrip,@ScreenCaption,@ActionDescrip,     @DateUpdated,'tblPlannedWork','[MaintenanceWorkID]',@PKey,'',@lastupdatedby,@InsertedID output,@RecordKeyName,@Machine,@TypeofWork,@Critical,@Maintenance,@Rank    select @valueOld = [MaintenanceWorkID] from #tblDeleted where mykey = 1   select @valueNew = [MaintenanceWorkID] from #tblInserted   if @valueOld is not NULL begin     exec pms_db.dbo.auditSaveDetails @InsertedID,'[MaintenanceWorkID]', @valueOld, @valueNew  end    select @valueOld = [PlannedDate] from #tblDeleted where mykey = 1   select @valueNew = [PlannedDate] from #tblInserted   if @valueOld is not NULL begin     exec pms_db.dbo.auditSaveDetails @InsertedID,'[PlannedDate]', @valueOld, @valueNew  end    select @valueOld = [Reason] from #tblDeleted where mykey = 1   select @valueNew = [Reason] from #tblInserted   if @valueOld is not NULL begin     exec pms_db.dbo.auditSaveDetails @InsertedID,'[Reason]', @valueOld, @valueNew  end    select @valueOld = [ApprovedBy] from #tblDeleted where mykey = 1   select @valueNew = [ApprovedBy] from #tblInserted   if @valueOld is not NULL begin     exec pms_db.dbo.auditSaveDetails @InsertedID,'[ApprovedBy]', @valueOld, @valueNew  end    select @valueOld = [LastUpdatedBy] from #tblDeleted where mykey = 1   select @valueNew = [LastUpdatedBy] from #tblInserted   if @valueOld is not NULL begin     exec pms_db.dbo.auditSaveDetails @InsertedID,'[LastUpdatedBy]', @valueOld, @valueNew  end   delete #tblDeleted where mykey = 1  set rowcount 1  update #tblDeleted set mykey = 1 end set rowcount 0   End
GO
COMMIT
