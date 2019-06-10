use pms_db
go
delete from dbo.tblAdmVendor
delete from dbo.tblAdmMaker
delete from dbo.tblAdmCategory
delete from dbo.tblAdmComponent
delete from dbo.tblAdmCounter
delete from dbo.tblAdmLocation
delete from dbo.tblAdmPart
delete from dbo.tblAdmUnit
delete from dbo.tblAdmWork WHERE LEFT(WorkCode,3)<>'SYS'
delete from dbo.tblMaintenanceWork
delete from dbo.tblNC
delete from dbo.tblPartPurchase
delete from dbo.tblPartConsumption

DBCC CHECKIDENT (tblMaintenanceWork, RESEED, 0)
DBCC CHECKIDENT (tblNCCorrectiveMeasure, RESEED, 0)

DELETE FROM dbo.tblSec_Groups
DBCC CHECKIDENT (tblSec_Groups, RESEED, 0)
DELETE FROM dbo.tblSec_Users WHERE [User ID]>1
DBCC CHECKIDENT (tblSec_Users, RESEED, 1)
DELETE FROM dbo.tblSec_Objects
DBCC CHECKIDENT (tblSec_Objects, RESEED, 0)