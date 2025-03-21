/****** Object:  Database CIBadge    Script Date: 1/11/2006 2:41:22 PM ******/
--IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'CIBadge')
--	DROP DATABASE [CIBadge]
--GO

CREATE DATABASE [CIBadge]  ON (NAME = N'CIBadge_Data', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL$TEST\Data\CIBadge_Data.MDF' , SIZE = 2, FILEGROWTH = 10%) LOG ON (NAME = N'CIBadge_Log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL$TEST\Data\CIBadge_Log.LDF' , SIZE = 1, FILEGROWTH = 10%)
 COLLATE SQL_Latin1_General_CP1_CI_AS
GO

exec sp_dboption N'CIBadge', N'autoclose', N'false'
GO

exec sp_dboption N'CIBadge', N'bulkcopy', N'false'
GO

exec sp_dboption N'CIBadge', N'trunc. log', N'false'
GO

exec sp_dboption N'CIBadge', N'torn page detection', N'true'
GO

exec sp_dboption N'CIBadge', N'read only', N'false'
GO

exec sp_dboption N'CIBadge', N'dbo use', N'false'
GO

exec sp_dboption N'CIBadge', N'single', N'false'
GO

exec sp_dboption N'CIBadge', N'autoshrink', N'false'
GO

exec sp_dboption N'CIBadge', N'ANSI null default', N'false'
GO

exec sp_dboption N'CIBadge', N'recursive triggers', N'false'
GO

exec sp_dboption N'CIBadge', N'ANSI nulls', N'false'
GO

exec sp_dboption N'CIBadge', N'concat null yields null', N'false'
GO

exec sp_dboption N'CIBadge', N'cursor close on commit', N'false'
GO

exec sp_dboption N'CIBadge', N'default to local cursor', N'false'
GO

exec sp_dboption N'CIBadge', N'quoted identifier', N'false'
GO

exec sp_dboption N'CIBadge', N'ANSI warnings', N'false'
GO

exec sp_dboption N'CIBadge', N'auto create statistics', N'true'
GO

exec sp_dboption N'CIBadge', N'auto update statistics', N'true'
GO

if( ( (@@microsoftversion / power(2, 24) = 8) and (@@microsoftversion & 0xffff >= 724) ) or ( (@@microsoftversion / power(2, 24) = 7) and (@@microsoftversion & 0xffff >= 1082) ) )
	exec sp_dboption N'CIBadge', N'db chaining', N'false'
GO

use [CIBadge]
GO

/****** Object:  Table [dbo].[tblAssignIDAccess]    Script Date: 1/11/2006 2:41:22 PM ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblAssignIDAccess]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblAssignIDAccess]
GO

/****** Object:  Table [dbo].[tblAssignMemberTypeAccess]    Script Date: 1/11/2006 2:41:22 PM ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblAssignMemberTypeAccess]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblAssignMemberTypeAccess]
GO

/****** Object:  Table [dbo].[tblAssignedCats]    Script Date: 1/11/2006 2:41:22 PM ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblAssignedCats]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblAssignedCats]
GO

/****** Object:  Table [dbo].[tblBLOBs]    Script Date: 1/11/2006 2:41:22 PM ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblBLOBs]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblBLOBs]
GO

/****** Object:  Table [dbo].[tblCardData]    Script Date: 1/11/2006 2:41:22 PM ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblCardData]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblCardData]
GO

/****** Object:  Table [dbo].[tblCategory]    Script Date: 1/11/2006 2:41:22 PM ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblCategory]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblCategory]
GO

/****** Object:  Table [dbo].[tblGroupVerify]    Script Date: 1/11/2006 2:41:22 PM ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblGroupVerify]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblGroupVerify]
GO

/****** Object:  Table [dbo].[tblPicture]    Script Date: 1/11/2006 2:41:22 PM ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblPicture]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblPicture]
GO

/****** Object:  Table [dbo].[tblSpecialDay]    Script Date: 1/11/2006 2:41:22 PM ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblSpecialDay]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblSpecialDay]
GO

/****** Object:  Table [dbo].[tblVCfg]    Script Date: 1/11/2006 2:41:22 PM ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblVCfg]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblVCfg]
GO

/****** Object:  Table [dbo].[tblVFieldmap]    Script Date: 1/11/2006 2:41:22 PM ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblVFieldmap]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblVFieldmap]
GO

/****** Object:  Table [dbo].[tblVerify]    Script Date: 1/11/2006 2:41:22 PM ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblVerify]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblVerify]
GO

/****** Object:  Table [dbo].[tblVisits]    Script Date: 1/11/2006 2:41:22 PM ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblVisits]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblVisits]
GO

/****** Object:  Table [dbo].[tlkpAcctStatus]    Script Date: 1/11/2006 2:41:22 PM ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tlkpAcctStatus]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tlkpAcctStatus]
GO

/****** Object:  Table [dbo].[tlkpMemberType]    Script Date: 1/11/2006 2:41:22 PM ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tlkpMemberType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tlkpMemberType]
GO

/****** Object:  Table [dbo].[tlkpTimePeriods]    Script Date: 1/11/2006 2:41:22 PM ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tlkpTimePeriods]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tlkpTimePeriods]
GO

/****** Object:  Table [dbo].[tblAssignIDAccess]    Script Date: 1/11/2006 2:41:24 PM ******/
CREATE TABLE [dbo].[tblAssignIDAccess] (
	[fstrID] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[flngPort] [int] NOT NULL ,
	[fbooGrantAccess] [bit] NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblAssignMemberTypeAccess]    Script Date: 1/11/2006 2:41:24 PM ******/
CREATE TABLE [dbo].[tblAssignMemberTypeAccess] (
	[fstrID] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[flngPort] [int] NOT NULL ,
	[fbooGrantAccess] [bit] NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblAssignedCats]    Script Date: 1/11/2006 2:41:24 PM ******/
CREATE TABLE [dbo].[tblAssignedCats] (
	[fstrID] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[fidfConfigID] [int] NOT NULL ,
	[fdatAssignDate] [datetime] NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblBLOBs]    Script Date: 1/11/2006 2:41:24 PM ******/
CREATE TABLE [dbo].[tblBLOBs] (
	[fstrID] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fimgPic] [image] NULL ,
	[fdatDate] [datetime] NULL ,
	[flngPicNum] [int] NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblCardData]    Script Date: 1/11/2006 2:41:24 PM ******/
CREATE TABLE [dbo].[tblCardData] (
	[idsCardDataID] [numeric](18, 0) IDENTITY (1, 1) NOT NULL ,
	[idfConfigID] [int] NULL ,
	[fstrLastName] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fstrFirstName] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fstrMidName] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fstrID] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[fdatRecDate] [datetime] NULL ,
	[idfReportID] [int] NULL ,
	[fstrBarcode] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[TextField01] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[TextField02] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[TextField03] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[TextField04] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[TextField05] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[TextField06] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[TextField07] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[TextField08] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[TextField09] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[TextField10] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[TextField11] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[TextField12] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[TextField13] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[TextField14] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[TextField15] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[TextField16] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[TextField17] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[TextField18] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[TextField19] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[TextField20] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[TextField21] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[TextField22] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[TextField23] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[TextField24] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[TextField25] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[DateField01] [datetime] NULL ,
	[DateField02] [datetime] NULL ,
	[DateField03] [datetime] NULL ,
	[DateField04] [datetime] NULL ,
	[DateField05] [datetime] NULL ,
	[fstrAddress] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fstrCity] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fstrState] [char] (2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fstrZip] [varchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[blnBatchPrint] [bit] NULL ,
	[intTimesPrinted] [int] NULL ,
	[fdatTimeStamp] [datetime] NULL ,
	[fintRecPool] [int] NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblCategory]    Script Date: 1/11/2006 2:41:25 PM ******/
CREATE TABLE [dbo].[tblCategory] (
	[fidsCatID] [int] NOT NULL ,
	[fstrCatName] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fstrCatDesc] [varchar] (80) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fbooCatDeleted] [bit] NULL ,
	[fstrCatRemoteValue] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblGroupVerify]    Script Date: 1/11/2006 2:41:25 PM ******/
CREATE TABLE [dbo].[tblGroupVerify] (
	[fstrID] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[fstrGroupName] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[fstrRemoteValue] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fbooOpFlag] [bit] NULL ,
	[fstrComments] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fstrAcctStatus] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fstrMemberType] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fccyAllowance] [money] NULL ,
	[fccyPastDue] [money] NULL ,
	[fdatExpDate] [datetime] NULL ,
	[flngVisits] [int] NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblPicture]    Script Date: 1/11/2006 2:41:25 PM ******/
CREATE TABLE [dbo].[tblPicture] (
	[fstrID] [char] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[fintPicNum] [int] NOT NULL ,
	[fidfConfigID] [int] NULL ,
	[dtmPictureDate] [datetime] NULL ,
	[chrFileName] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[chrYBFileName] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fintSavedPicShape] [int] NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblSpecialDay]    Script Date: 1/11/2006 2:41:25 PM ******/
CREATE TABLE [dbo].[tblSpecialDay] (
	[fstrID] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[fdatDate] [datetime] NOT NULL ,
	[fstrDesc] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fstrMsg] [varchar] (40) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fbooFlag] [bit] NULL ,
	[fbooOnceOnly] [bit] NULL ,
	[fbooBefore] [bit] NULL ,
	[fbooAfter] [bit] NULL ,
	[fbooOn] [bit] NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblVCfg]    Script Date: 1/11/2006 2:41:25 PM ******/
CREATE TABLE [dbo].[tblVCfg] (
	[fstrOrg] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fstrPicFileType] [varchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fbooPicNameIsID] [bit] NULL ,
	[fbooAddress] [bit] NULL ,
	[fstrIDLabel] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fstrFirstNameLabel] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fstrLastNameLabel] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fbooMidName] [bit] NULL ,
	[fstrMidNameLabel] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fbooRecDate] [bit] NULL ,
	[fstrRecDateLabel] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fbooAutoIncBC] [bit] NULL ,
	[fstrAutoIncBCLabel] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblVFieldmap]    Script Date: 1/11/2006 2:41:25 PM ******/
CREATE TABLE [dbo].[tblVFieldmap] (
	[fstrControlName] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fstrFieldName] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fstrNativeFieldName] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fstrNativeTableName] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fbooUsed] [bit] NULL ,
	[fbooGroup] [bit] NULL ,
	[fstrFriendlyName] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fbooFieldSearch] [bit] NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblVerify]    Script Date: 1/11/2006 2:41:25 PM ******/
CREATE TABLE [dbo].[tblVerify] (
	[fstrID] [char] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fbooOpFlag] [bit] NULL ,
	[fstrComments] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fstrAcctStatus] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fstrMemberType] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fstrGroupID] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fccyAllowance] [money] NULL ,
	[fccyPastDue] [money] NULL ,
	[fdatExpDate] [datetime] NULL ,
	[flngVisits] [int] NULL ,
	[fbooUnrestrictedMember] [bit] NULL ,
	[fstrSmallGroupID] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tblVisits]    Script Date: 1/11/2006 2:41:25 PM ******/
CREATE TABLE [dbo].[tblVisits] (
	[flngVisitID] [numeric](18, 0) IDENTITY (1, 1) NOT NULL ,
	[fstrID] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fstrAccessNumber] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fdatIn] [datetime] NULL ,
	[fdatOut] [datetime] NULL ,
	[fstrStationID] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fstrFlag] [varchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fstrFirstName] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fstrMidName] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fstrLastName] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[flngReaderID] [int] NULL ,
	[fstrGroupID] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fstrMemberType] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fstrAcctStatus] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fstrCategory] [varbinary] (30) NULL ,
	[fstrSmallGroupID] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tlkpAcctStatus]    Script Date: 1/11/2006 2:41:25 PM ******/
CREATE TABLE [dbo].[tlkpAcctStatus] (
	[fstrName] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fstrRemoteValue] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fbooFlag] [bit] NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tlkpMemberType]    Script Date: 1/11/2006 2:41:25 PM ******/
CREATE TABLE [dbo].[tlkpMemberType] (
	[fstrName] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fstrRemoteValue] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fbooFlag] [bit] NULL ,
	[fccyCharge] [money] NULL ,
	[flngVisits] [int] NULL ,
	[fdatExpDate] [datetime] NULL ,
	[fstrTimePeriod] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[tlkpTimePeriods]    Script Date: 1/11/2006 2:41:26 PM ******/
CREATE TABLE [dbo].[tlkpTimePeriods] (
	[flngID] [int] NULL ,
	[fstrName] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[fdatFrom] [datetime] NULL ,
	[fdatTo] [datetime] NULL ,
	[fccyAmount] [money] NULL ,
	[fstrWeekday] [varchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblAssignIDAccess] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblAssignIDAccess] PRIMARY KEY  CLUSTERED 
	(
		[fstrID],
		[flngPort]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblAssignMemberTypeAccess] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblAssignMemberTypeAccess] PRIMARY KEY  CLUSTERED 
	(
		[fstrID],
		[flngPort]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblAssignedCats] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblAssignedCats] PRIMARY KEY  CLUSTERED 
	(
		[fstrID],
		[fidfConfigID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblCardData] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblCardData] PRIMARY KEY  CLUSTERED 
	(
		[fstrID]
	) WITH  FILLFACTOR = 70  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblCategory] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblCategory] PRIMARY KEY  CLUSTERED 
	(
		[fidsCatID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblGroupVerify] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblGroupVerify] PRIMARY KEY  CLUSTERED 
	(
		[fstrID],
		[fstrGroupName]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblPicture] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblPicture] PRIMARY KEY  CLUSTERED 
	(
		[fstrID],
		[fintPicNum]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblSpecialDay] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblSpecialDay] PRIMARY KEY  CLUSTERED 
	(
		[fstrID],
		[fdatDate]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tblVisits] WITH NOCHECK ADD 
	CONSTRAINT [PK_tblVisits] PRIMARY KEY  CLUSTERED 
	(
		[flngVisitID]
	)  ON [PRIMARY] 
GO

