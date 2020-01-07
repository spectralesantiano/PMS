use pms_db
go
delete from dbo.tblAdmMaintenance WHERE LEFT(MaintenanceCode,3)<>'SYS'
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
delete from dbo.tblPartPurchase
delete from dbo.tblPartConsumption
delete from dbo.tblSec_Users_Pref
delete from dbo.tblSec_Users_Settings
delete from dbo.tblSTI
delete from dbo.tblSTILicenseLoaded
delete from dbo.tblSTILog
DBCC CHECKIDENT (tblMaintenanceWork, RESEED, 0)

DELETE FROM dbo.tblSec_Groups
DBCC CHECKIDENT (tblSTI, RESEED, 0)
DBCC CHECKIDENT (tblSTILicenseLoaded, RESEED, 0)
DBCC CHECKIDENT (tblSTILog, RESEED, 0)
DBCC CHECKIDENT (tblSec_Groups, RESEED, 0)
DELETE FROM dbo.tblSec_Users WHERE [User ID]>1
DBCC CHECKIDENT (tblSec_Users, RESEED, 1)
DELETE FROM dbo.tblSec_Objects
DBCC CHECKIDENT (tblSec_Objects, RESEED, 0)