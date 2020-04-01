use pms_db
select 'alter table '  + r.TABLE_NAME + ' alter column [LastUpdatedBy] varchar(2000)'
 from (select tb.TABLE_NAME from INFORMATION_SCHEMA.TABLES tb inner join
		INFORMATION_SCHEMA.COLUMNS c on tb.TABLE_NAME = c.table_name
		where c.COLUMN_NAME = 'LastUpdatedBy' and tb.TABLE_TYPE = 'BASE TABLE') r
		