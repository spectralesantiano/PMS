--USE [MPS]
USE [pms_db]
GO
/****** Object:  Table [dbo].[MSystblTblNameFld]    Script Date: 2/11/2020 6:34:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MSystblTblNameFld](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[TableName] [nvarchar](50) NOT NULL,
	[RecordKeyFld] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_MSystblTblNameFld] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[TableName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[MSystblTblNameFld] ON 

INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (1, N'MSysSec_GroupObjectPerm', N'ObjectID')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (2, N'MSysSec_GroupObjectPermReports', N'ObjectID')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (3, N'MSysSec_Users_Log', N'UserName')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (4, N'MSysSec_UsersGroup', N'UserID')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (5, N'MSysSecUserDetail', N'SecUser')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (8, N'MSystblAdminCodeUpd', N'tblName')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (9, N'MSystblDataSource', N'Code')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (10, N'MSystblRepOptTemplateValues', N'Value')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (11, N'MSystblReports', N'Caption')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (12, N'MSystblReportsOptions', N'Caption')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (13, N'MSystblTblNameFld', N'TableName')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (14, N'tbl_temp_checklist_documents', N'DocName')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (15, N'tbl_temp_selected_idnbrs', N'idnbrs')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (16, N'tblActivity', N'VslName')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (17, N'tblAddr', N'Bldg')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (18, N'tblAdmAgentPrin_map', N'FKeyAgent')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (19, N'tblAdmCharterer', N'ChartererName')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (20, N'tblAdmCompanyContact', N'LName')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (21, N'tblAdmCompCompanyDefined', N'FKeyCompanyDefined')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (22, N'tblAdmCompCourse', N'FKeyCourse')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (23, N'tblAdmCompDocType', N'CompetenceDocType')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (24, N'tblAdmCompLicCert', N'FKeyDocument')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (25, N'tblAdmCompMedCert', N'FKeyDocument')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (26, N'tblAdmCompNatInfo', N'FKeyDocument')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (27, N'tblAdmCompRank', N'FKeyRank')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (28, N'tblAdmCompRepeatTraining', N'FKeyCompRepeatTraining')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (29, N'tblAdmCompSServ', N'FKeyCompRank')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (30, N'tblAdmCompTravDoc', N'FKeyDocument')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (31, N'tblAdmCompVslType', N'FKeyCompRank')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (32, N'tblAdmCourseDoc_map', N'FKeyCourse')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (33, N'tblAdmCourseInstDet', N'FKeyCourseInst')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (34, N'tblAdmCrewCmplRank', N'FKeyRank')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (35, N'tblAdmDocCntry', N'Validity')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (36, N'tblAdmLicCertCap_Func', N'LevelCode')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (37, N'tblAdmMgFlt', N'LName')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (38, N'tblAdmMgrTech', N'LName')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (39, N'tblAdmMinCrewRank', N'FKeyMinCrew')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (40, N'tblAdmPortAgentContacts', N'Lname')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (41, N'tblAdmSign', N'LName')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (42, N'tblAdmWscaleAsh', N'FKeyWageAsh')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (43, N'tblAdmWscaleAshEmp', N'FKeyWageAshEmp')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (44, N'tblAdmWScaleInfo', N'FKeyWageInfo')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (45, N'tblAdmWscaleOnb', N'FKeyWageOnb')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (46, N'tblAdmWscalePrd', N'FKeyWScalePrd')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (47, N'tblAdmWscaleRank', N'FKeyRank')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (48, N'tblAllottee', N'concat(LName, '''', '''' , FName, '''' '''', MName)')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (49, N'tblAmortization', N'RefNo')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (50, N'tblBookingDetails', N'BookingRef')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (51, N'tblChecklistComments', N'DocComment')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (52, N'tblComment', N'Comment')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (53, N'tblConfig', N'TextValue')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (54, N'tblConfRep', N'RepDate')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (55, N'tblCourse', N'FKeyCourse')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (56, N'tblCourseCertMappedReports', N'FKeyMappedReports')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (57, N'tblCrewReassign', N'RequestedBy')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (58, N'tblCrewReassignCrews', N'FKeyIDNbr')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (59, N'tblDocImage', N'FilePath')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (60, N'tblDocument', N'Number')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (61, N'tblEduc', N'School')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (62, N'tblFlightDetails', N'Flight')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (63, N'tblMCR', N'Salary')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (64, N'tblMedCostMonitor', N'Amount')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (65, N'tblMedHistory', N'Diagnosis')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (66, N'tblMedStatusMonitor', N'Status')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (67, N'tblObjects', N'Caption')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (68, N'tblPlanningEvent', N'PlanningEvent')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (69, N'tblPlanningEventCrew', N'CrewID')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (70, N'tblPrevCo', N'CoName')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (71, N'tblRemitAllot', N'FKeyRemittanceID')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (72, N'tblRemitOtherWage', N'FKeyRemittanceID')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (73, N'tblRemittance', N'LName')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (74, N'tblReportTemplates', N'TemplateName')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (75, N'tblReportTemplatesConfigs', N'TblName')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (76, N'tblSSS', N'Salary')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (77, N'tblTravelEvent', N'DepPlace')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (78, N'tblUserConfig', N'Value')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (79, N'tblUserLayout', N'LayoutFile')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (80, N'tblVMRef_CurrentRank', N'CurrentRankCode')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (81, N'tblWageOnb', N'FKeyWageOnbID')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (82, N'tblWMBPTable', N'Age')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (84, N'view_SelectedCrews', N'FullName')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (85, N'tblCrewInfo', N'concat(LName, '''', '''' , FName, '''' '''', MName)')
INSERT [dbo].[MSystblTblNameFld] ([ID], [TableName], [RecordKeyFld]) VALUES (84, N'tblCounterReading', N'Reading')
SET IDENTITY_INSERT [dbo].[MSystblTblNameFld] OFF
