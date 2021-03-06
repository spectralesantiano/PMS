USE [sti_sys]
GO
/****** Object:  Table [dbo].[tblPMSConfig]    Script Date: 03/04/2020 20:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblPMSConfig](
	[Code] [varchar](30) NOT NULL,
	[Value] [varchar](max) NULL,
 CONSTRAINT [PK_tblPMSConfig] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tblPMSConfig] ([Code], [Value]) VALUES (N'DATE_LAST_EXPORT', N'2020-03-04 15:10:13')
INSERT [dbo].[tblPMSConfig] ([Code], [Value]) VALUES (N'DATE_LAST_EXPORT_IMG', N'2020-01-28 00:00:00')
INSERT [dbo].[tblPMSConfig] ([Code], [Value]) VALUES (N'DUE_DAYS', N'30')
INSERT [dbo].[tblPMSConfig] ([Code], [Value]) VALUES (N'DUE_HOURS', N'100')
INSERT [dbo].[tblPMSConfig] ([Code], [Value]) VALUES (N'EXPORT_DIR', N'C:\Users\Teddy.TEDDY-VPC\Desktop\kbs pms')
INSERT [dbo].[tblPMSConfig] ([Code], [Value]) VALUES (N'IMAGE_MAX_RES', N'900')
INSERT [dbo].[tblPMSConfig] ([Code], [Value]) VALUES (N'KPITHRESHOLD', N'4')
INSERT [dbo].[tblPMSConfig] ([Code], [Value]) VALUES (N'LASTBACKUP', N'2020-02-12')
INSERT [dbo].[tblPMSConfig] ([Code], [Value]) VALUES (N'LOCATION_ID', N'UURAPUK')
INSERT [dbo].[tblPMSConfig] ([Code], [Value]) VALUES (N'LTYPE', N'095037062024147016095400808714509203709403')
INSERT [dbo].[tblPMSConfig] ([Code], [Value]) VALUES (N'PROGRAMFILES', N'Admin.dll;BaseControl.dll;Crewing.dll;License.dll;Security.dll;Tools.dll;Utility.dll;Maintenance.dll;PlannedMaintenance.exe;PMSReports.dll')
INSERT [dbo].[tblPMSConfig] ([Code], [Value]) VALUES (N'SHORE_ID', N'SAMPLE_')
INSERT [dbo].[tblPMSConfig] ([Code], [Value]) VALUES (N'SMIMEX', N'PMGLWTR')
INSERT [dbo].[tblPMSConfig] ([Code], [Value]) VALUES (N'SPARE_ADDRESS_VALUE', N'56783877J03HKIL')
INSERT [dbo].[tblPMSConfig] ([Code], [Value]) VALUES (N'SPARE_VENDOR_SELECTED', N'True')
INSERT [dbo].[tblPMSConfig] ([Code], [Value]) VALUES (N'UpdatesFolder', N'C:\SPECTRAL\Updates')
/****** Object:  Table [dbo].[tblPMS_SMConfig]    Script Date: 03/04/2020 20:46:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblPMS_SMConfig](
	[Code] [varchar](30) NOT NULL,
	[Value] [varchar](max) NULL,
 CONSTRAINT [PK_tblPMS_SMConfig] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tblPMS_SMConfig] ([Code], [Value]) VALUES (N'BACKUPDAYS', N'15')
INSERT [dbo].[tblPMS_SMConfig] ([Code], [Value]) VALUES (N'BACKUPDIR', N'')
INSERT [dbo].[tblPMS_SMConfig] ([Code], [Value]) VALUES (N'DUE_DAYS', N'30')
INSERT [dbo].[tblPMS_SMConfig] ([Code], [Value]) VALUES (N'DUE_HOURS', N'100')
INSERT [dbo].[tblPMS_SMConfig] ([Code], [Value]) VALUES (N'EXPORTDIR', N'')
INSERT [dbo].[tblPMS_SMConfig] ([Code], [Value]) VALUES (N'IMPORTDIR', N'')
INSERT [dbo].[tblPMS_SMConfig] ([Code], [Value]) VALUES (N'LASTBACKUP', N'2019-11-26 00:00:00')
INSERT [dbo].[tblPMS_SMConfig] ([Code], [Value]) VALUES (N'LOCATION_ID', N'UURAPUK')
INSERT [dbo].[tblPMS_SMConfig] ([Code], [Value]) VALUES (N'LTYPE', N'025047065065148052055028037015022026145')
INSERT [dbo].[tblPMS_SMConfig] ([Code], [Value]) VALUES (N'PROGRAMFILES', N'Admin.dll;BaseControl.dll;License.dll;Security.dll;Tools.dll;Utility.dll;Maintenance.dll;PMS_SM.exe;PMSReports.dll')
INSERT [dbo].[tblPMS_SMConfig] ([Code], [Value]) VALUES (N'UpdatesFolder', N'')
