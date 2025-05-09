
/*********************************************************************************/
/******                                                                       ****/
/****** CreateTables.sql                                                      ****/ 
/******      (in C:/CI Solutions/CI Badge/Support/SQL Server)                 ****/
/******                                                                       ****/
/*********************************************************************************/

/****** Object:  Database CIBadge    Script Date: 8/15/2019 2:41:22 PM ******/
/******       -------Modified 1/28/2019 thomas downes ******/

----
----Prior to running the script below, please do the following.  ----1/28/2019 td
---    1) Press F8 to open Object Explorer.
---    2) Right-click Databases, select New Database...
----   3) Follow the prompts to create a database called [CIBadge] (naturally, you should type "CIBadge" without quotes or braces!).
----   4) Run the script below.  
----
-----------------------------------------------------------
--
--There are four (4) reasons why I am recommending that the database [CIBadge] be created via context-menu selections within SQL Server Management Studio,
--   instead of by a CREATE DATABASE command, as follows:
--
--   1) It's easy to do using Object Explorer, and allows (or forces) the Support person to perform a brief review of the existing databases prior to 
--         creating a (possibly redundant) database.
--   2) Relying on automation (scripting) to create the database could possibly result in a same-named database being deleted via an automated DROP DATABASE command 
--         (resulting in a huge loss of production data).
--   3) The hard-coded specification FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL\Data\CIBadge_Data.MDF' doesn't need to be modified to conform to
--         Windows-directory paths on the customer's server.
--   4) The detailed work of creating the tables is still automated, i.e. performed via the SQL script below.
--
--   ----1/28/2019 Thomas DOWNES
--  
--  At Jayce & Taylor's suggestion, the number of tables has been trimmed from 17 to 5.
--    ---6/7/2019 Thomas DOWNES
--
----  After realizing that CI Badge | Visitor Management uses table tblVisitsCIB, the number of tables has been changed from 5 to 6.
--    ---8/15/2019 Thomas DOWNES
--
--  Reminder to everyone, about 12 months ago the initial CREATE DATABASE command has been replaced by instructions to the Tech Support person to 
--    issue that command manually (or use Sql Server Management Studio's Create Database.... menu item.   It's an very important command (due to the 
--    possibility of database-name collision) & should not be issued by script.   Rather it should be done only after reviewing the existing databases 
--    within the Sql Server instance.
--    ---6/7/2019 Thomas DOWNES
--

BEGIN TRY 
	----
	----Prior to running the following script, please do the following.  ----1/28/2019 td
	---
	---    1) Press F8 to open Object Explorer.
	---    2) Right-click Databases, select New Database...
	----   3) Follow the prompts to create a database called [CIBadge] (naturally, you should type "CIBadge" without quotes or braces!).
	----   4) Run the script below.  
	----
	----Moved below. 6/7/2019 td----USE [CIBadge];
	----
	----THROW 51000, 'The database [CIBadge] should be created manually.', 1; 

	IF (NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'CIBadge'))  --- N'CIBadge'))
	----BEGIN
		----CREATE DATABASE [CIBadge]  ON (NAME = N'CIBadge_Data', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL\Data\CIBadge_Data.MDF' , 
		   ----   SIZE = 2, FILEGROWTH = 10%) LOG ON (NAME = N'CIBadge_Log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL\Data\CIBadge_Log.LDF' , 
			  ----SIZE = 1, FILEGROWTH = 10%) COLLATE SQL_Latin1_General_CP1_CI_AS
		---THROW 51000, 'The database [CIBadge] should be created manually.', 1; 
		THROW 51000, 'Prior to running the script... Go to Object Explorer, right-click Databases, select New Database...and create a database called [CIBadge].', 1; 
	----END  
	--GO

	IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'CIBadge')
	-----------------------------1/28/2019 td------DROP DATABASE [CIBadge]
		 SELECT 'The database CIBadge already exists and might contain production data!!!!!   (Do not issue a DROP command!!)' as FatalErrorMessage; 
	--GO

	USE [CIBadge];

	SELECT 'Start of ALTER DATABASE.'  

	-----Incorrect syntax.  1/28/2019 td--exec sp_dboption N'CIBadge', N'autoclose', N'false'
	ALTER DATABASE [CIBadge] SET AUTO_CLOSE OFF 
	--GO

	-----Incorrect syntax.  1/28/2019 td--exec sp_dboption N'CIBadge', N'bulkcopy', N'false'
	-----Incorrect syntax.  1/28/2019 td--ALTER DATABASE [CIBadge] SET BULK_COPY OFF 
	--GO

	-----Incorrect syntax.  1/28/2019 td--exec sp_dboption N'CIBadge', N'trunc. log', N'false'
	-----Incorrect syntax.  1/28/2019 td--ALTER DATABASE [CIBadge] SET TRUNCATE_LOG OFF 
	--GO

	--exec sp_dboption N'CIBadge', N'torn page detection', N'true'
	ALTER DATABASE [CIBadge] SET TORN_PAGE_DETECTION ON 
	--GO

	-----Incorrect syntax.  1/28/2019 td--exec sp_dboption N'CIBadge', N'read only', N'false'
	-----Incorrect syntax.  1/28/2019 td--ALTER DATABASE [CIBadge] SET READ_ONLY OFF 
	ALTER DATABASE [CIBadge] SET  READ_WRITE 
	--GO

	-----Incorrect syntax.  1/28/2019 td--exec sp_dboption N'CIBadge', N'dbo use', N'false'
	-----Incorrect syntax.  1/28/2019 td--ALTER DATABASE [CIBadge] SET DBO_USE OFF 
	--GO

	-----Incorrect syntax.  1/28/2019 td--exec sp_dboption N'CIBadge', N'single', N'false'
	--GO

	--exec sp_dboption N'CIBadge', N'autoshrink', N'false'
	ALTER DATABASE [CIBadge] SET AUTO_SHRINK OFF 
	--GO

	--exec sp_dboption N'CIBadge', N'ANSI null default', N'false'
	ALTER DATABASE [CIBadge] SET ANSI_NULL_DEFAULT OFF 
	--GO

	--exec sp_dboption N'CIBadge', N'recursive triggers', N'false'
	ALTER DATABASE [CIBadge] SET RECURSIVE_TRIGGERS OFF 
	--GO

	--exec sp_dboption N'CIBadge', N'ANSI nulls', N'false'
	ALTER DATABASE [CIBadge] SET ANSI_NULLS OFF 
	--GO

	--exec sp_dboption N'CIBadge', N'concat null yields null', N'false'
	ALTER DATABASE [CIBadge] SET CONCAT_NULL_YIELDS_NULL OFF 
	--GO

	--exec sp_dboption N'CIBadge', N'cursor close on commit', N'false'
	ALTER DATABASE [CIBadge] SET CURSOR_CLOSE_ON_COMMIT OFF 
	--GO

	--exec sp_dboption N'CIBadge', N'default to local cursor', N'false'
	ALTER DATABASE [CIBadge] SET CURSOR_DEFAULT  GLOBAL 
	--GO

	--exec sp_dboption N'CIBadge', N'quoted identifier', N'false'
	ALTER DATABASE [CIBadge] SET QUOTED_IDENTIFIER OFF 
	--GO

	--exec sp_dboption N'CIBadge', N'ANSI warnings', N'false'
	ALTER DATABASE [CIBadge] SET ANSI_WARNINGS OFF 
	--GO

	--exec sp_dboption N'CIBadge', N'auto create statistics', N'true'
	ALTER DATABASE [CIBadge] SET AUTO_CREATE_STATISTICS ON 
	--GO

	--exec sp_dboption N'CIBadge', N'auto update statistics', N'true'
	ALTER DATABASE [CIBadge] SET AUTO_UPDATE_STATISTICS ON 
	--GO

	if( ( (@@microsoftversion / power(2, 24) = 8) and (@@microsoftversion & 0xffff >= 724) ) or ( (@@microsoftversion / power(2, 24) = 7) and (@@microsoftversion & 0xffff >= 1082) ) )
		-----	exec sp_dboption N'CIBadge', N'db chaining', N'false'
		ALTER DATABASE [CIBadge] SET DB_CHAINING OFF 
	--GO

	 SELECT 'End of ALTER DATABASE.'  


	USE [CIBadge]
	--GO


	 SELECT 'Start of SET Exists_Tablename.'  

	/*** Just 5 tables --6/7/2019 td **/

    /*** Table # 1 of 5 --6/7/2019 td ****/ 
	/****** Object:  Table [dbo].[tblBLOBs]    Script Date: 8/15/2019 2:41:22 PM ******/
	DECLARE @exists_tblBLOBs BIT = 0 
	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblBLOBs]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
	-----------------------------1/28/2019 td------drop table [dbo].[tblBLOBs]
		 ----1/28/2019--SELECT 'The table [tblBLOBs] already exists and might contain production data!!!!!   (Do not issue a DROP command!!)' as FatalErrorMessage; 
		SET @exists_tblBLOBs = 1;
	----GO

    /*** Table # 2 of 5 --6/7/2019 td ****/ 
	/****** Object:  Table [dbo].[tblCardData]    Script Date: 8/15/2019 2:41:22 PM ******/
	DECLARE @exists_tblCardData BIT = 0; 
	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblCardData]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
	-----------------------------1/28/2019 td------drop table [dbo].[tblCardData]
		 ----1/28/2019--SELECT 'The table [tblCardData] already exists and might contain production data!!!!!   (Do not issue a DROP command!!)' as FatalErrorMessage; 
		SET @exists_tblCardData = 1;
	-----GO

    /*** Table # 3 of 5 --6/7/2019 td ****/ 
	/****** Object:  Table [dbo].[tblPicture]    Script Date: 8/15/2019 2:41:22 PM ******/
	DECLARE @exists_tblPicture BIT = 0; 
	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblPicture]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
		SET @exists_tblPicture = 1;
	----GO

    /*** Table # 4 of 5 --6/7/2019 td ****/ 
	/****** Object:  Table [dbo].[tblTrackPrints]    Script Date: 8/15/2019 2:41:22 PM ******/
	DECLARE @exists_tblTrackPrints BIT = 0; 
	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblTrackPrints]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) 
	    SET @exists_tblTrackPrints = 1;
	----GO

    /*** Table # 5 of 5 --6/7/2019 td ****/ 
	/****** Object:  Table [dbo].[tblVisits]    Script Date: 8/15/2019 2:41:22 PM ******/
	DECLARE @exists_tblVisits BIT = 0; 
	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblVisits]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
  		SET @exists_tblVisits = 1;
	----GO

    /*** Table # 6 of 6 --8/15/2019 td ****/ 
	/****** Object:  Table [dbo].[tblVisitsCIB]    Script Date: 8/15/2019 2:41:22 PM ******/
	DECLARE @exists_tblVisitsCIB BIT = 0; 
	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblVisitsCIB]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
  		SET @exists_tblVisitsCIB = 1;
	----GO
 
 	SELECT 'End of SET Exists_tablename.'  

   
	/*** Just 5 tables --6/7/2019 td **/


	/*********************************************************/
	/*****************               *************************/
	/***************** CREATE TABLES *************************/
	/*****************               *************************/
	/*********************************************************/

	SELECT 'Starting to CREATE TABLES.'  


    /*** Table # 1 of 5 --6/7/2019 td ****/ 
	/****** Object:  Table [dbo].[tblBLOBs]    Script Date: 8/15/2019 2:41:24 PM ******/
	if (@exists_tblBLOBs = 0) 
	  CREATE TABLE [dbo].[tblBLOBs] (
		[fintAutoID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
		[fstrID] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
		[fimgPic] [image] NULL ,
		[fdatDate] [datetime] NULL CONSTRAINT [DF_tblBLOBs_fdatDate] DEFAULT getdate(),
		[flngPicNum] [int] NULL CONSTRAINT [DF_tblBLOBs_flngPicNum] DEFAULT 1 
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY] ;
	-----GO


    /*** Table # 2 of 5 --6/7/2019 td ****/ 
	/****** Object:  Table [dbo].[tblCardData]    Script Date: 8/15/2019 2:41:24 PM ******/
	if (@exists_tblCardData = 0) 
	  CREATE TABLE [dbo].[tblCardData] (
		[idsCardDataID] [numeric](18, 0) IDENTITY (1, 1) NOT NULL ,
		[idfConfigID] [int] NULL ,
		[fstrLastName] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
		[fstrFirstName] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
		[fstrMidName] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
		[fstrID] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
		---- Added 1/28/2019 thomas downes, for https://app.asana.com/0/0/872801181163659/f 
		[fdatRecDate] [datetime] NULL CONSTRAINT [DF_tblCardData_fdatRecDate] DEFAULT getdate() ,
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
		---- Added 1/28/2019 thomas downes, for https://app.asana.com/0/0/872801181163659/f 
		[intTimesPrinted] [int] NULL CONSTRAINT [DF_tblCardData_intTimesPrinted] DEFAULT 0 ,
		[fdatTimeStamp] [datetime] NULL ,
		[fintRecPool] [int] NULL 
		, CONSTRAINT [PK_tblCardData] PRIMARY KEY  CLUSTERED 
    		(
		   	[fstrID]
		    ) WITH  FILLFACTOR = 70  ON [PRIMARY] 
	    --------, CONSTRAINT [DF_tblCardData_fdatRecDate] DEFAULT getdate() FOR fdatRecDate 
	    --------, CONSTRAINT [DF_tblCardData_intTimesPrinted] DEFAULT 0 FOR intTimesPrinted
    ) ON [PRIMARY] ;
	----GO


    /*** Table # 3 of 5 --6/7/2019 td ****/ 
	/****** Object:  Table [dbo].[tblPicture]    Script Date: 8/15/2019 2:41:25 PM ******/
	if (@exists_tblPicture = 0) 
	   CREATE TABLE [dbo].[tblPicture] (
		[fstrID] [char] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
		[fintPicNum] [int] NOT NULL ,
		[fidfConfigID] [int] NULL ,
		[dtmPictureDate] [datetime] NULL ,
		[chrFileName] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
		[chrYBFileName] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
		[fintSavedPicShape] [int] NULL ,
		CONSTRAINT [PK_tblPicture] PRIMARY KEY  CLUSTERED 
		(
			[fstrID],
			[fintPicNum]
		)  ON [PRIMARY] 
	) ON [PRIMARY] ;
	-----GO


	---------------------------
	---------------------------Added 1/28/2019 by Thomas DOWNES
	---------------------------
	   ----Added 1/28/2019 thomas downes, for https://app.asana.com/0/491042595046854/1000920416926782/f

    /*** Table # 4 of 5 ----6/7/2019 td ****/ 
	/****** Object:  Table [dbo].[tblTrackPrints]    Script Date: 5/8/2019 & 1/28/2019 2:41:26 PM ******/
	IF (@exists_tblTrackPrints = 0) 
	   ----Added 1/28/2019 thomas downes, for https://app.asana.com/0/491042595046854/1000920416926782/f
	   CREATE TABLE [dbo].[tblTrackPrints](
		[fintAutoID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
		[idfConfigID] [int] NULL,   ----Added 1/28/2019 thomas downes, for https://app.asana.com/0/0/995315658498811/f
		[fstrIDNumber] [varchar](15) NOT NULL,
		[fstrIDForPrint] [varchar](15) NOT NULL,
		[fdatPrtDate] [datetime] NOT NULL CONSTRAINT [DF_tb_TrackPrints_fdatPrtDate]  DEFAULT (getdate()),
		[fstrStationID] [varchar](15) NULL,
		[fstrUserName] [varchar](20) NULL,
		[fstrReportName] [varchar](25) NULL,
		[fstrLastName] [varchar](20) NULL,
		[fstrFirstName] [varchar](20) NULL,
		[fstrMidName] [varchar](10) NULL,
		[fdatRecDate] [datetime] NOT NULL CONSTRAINT [DF_tb_TrackPrints_fdatRecDate]  DEFAULT (getdate()),
		[fintQtyPrinted] [tinyint] NULL,   ----Added 4/19/2019 thomas downes 
		[fstrDataSourceName] [varchar](20) NULL,   ----Added 4/19/2019 thomas downes 
		[fbooBatchPrint] [bit] NULL,   ----Added 4/19/2019 thomas downes 
		[fstrBarcode] [varchar](20) NULL,   ----Added 4/19/2019 thomas downes 
		[fstrSigFileName] [varchar](20) NULL,   ----Added 4/19/2019 thomas downes 
		[fstrReasonBad] [varchar](20) NULL,   ----Added 4/19/2019 thomas downes 
		[fstrRFID] [varchar](20) NULL   ----Added 4/19/2019 thomas downes 
	 CONSTRAINT [PK_tblTrackPrints] PRIMARY KEY CLUSTERED 
	(
		[fintAutoID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] ;


    /*** Table # 5 of 5 ----6/7/2019 td ****/ 
	/****** Object:  Table [dbo].[tblVisits]    Script Date: 8/15/2019 2:41:25 PM ******/
	IF (@exists_tblVisits = 0) 
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
		[fstrSmallGroupID] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,  
		CONSTRAINT [PK_tblVisits] PRIMARY KEY  CLUSTERED 
		(
			[flngVisitID]
		)  ON [PRIMARY] 
	) ON [PRIMARY] ;
	----GO

    /*** Just 5 tables --6/7/2019 td ****/

	/****** Object:  Table [dbo].[tblVisitsCIB]    Script Date: 1/11/2006 2:41:25 PM ******/
	IF (@exists_tblVisitsCIB = 0) 
			CREATE TABLE [dbo].[tblVisitsCIB](
				[fstrVisitID] [varchar](25) NOT NULL,
				[fdatArrival] [datetime] NULL,
				[fdatEstDeparture] [datetime] NULL,
				[fdatDeparture] [datetime] NULL,
				[fstrID] [varchar](30) NULL,
				[fstrFirstName] [varchar](30) NULL,
				[fstrLastName] [varchar](30) NULL,
				[fstrCompany] [varchar](50) NULL,
				[fstrPurpose] [varchar](50) NULL,
				[fstrVisitorType] [varchar](30) NULL,
				[fstrHost] [varchar](30) NULL,
				[fstrHostPhone] [varchar](15) NULL,
				[fstrStationIn] [varchar](20) NULL,
				[fstrStationOut] [varchar](20) NULL,
				[fstrDestination] [varchar](50) NULL,
			 CONSTRAINT [PK_tblVisitsCIB] PRIMARY KEY CLUSTERED 
			(
				[fstrVisitID] ASC
			)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
			) ON [PRIMARY]
	----GO

    /*** Just 6 tables --8/15/2019 td ****/

	SELECT 'End of CREATE TABLES.'  

END TRY 

-----------------------------------------------------------------
BEGIN CATCH 
   ---
   ---    Currently, we have no CATCH commands to execute.  ----1/28/2019 thomas downes 
   ---
	SELECT 'An error occurred!!!!! ' as FatalErrorMessage; 

END CATCH    

--GO

	GO  --- We need to create the tables now. 

	------------------------END OF "CREATE TABLES" -----------------------------------

	/**************************************************************/
	/*****************                    *************************/
	/***************** CREATE CONSTRAINTS *************************/
	/*****************                    *************************/
	/**************************************************************/

BEGIN TRY 

    /*** Just 5 tables --6/7/2019 td ****/
	SELECT 'Start of CREATE CONSTRAINTS.'  

    /*** Table # 1 of 5 ----6/7/2019 td ****/ 
	if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PK_tblBLOBs]'))  
	ALTER TABLE [dbo].[tblBLOBs] WITH NOCHECK ADD 
		CONSTRAINT [PK_tblBLOBs] PRIMARY KEY  CLUSTERED 
		(
			[fintAutoID]
		)  ON [PRIMARY] ;
	--GO

    /*** Table # 2 of 5 ----6/7/2019 td ****/ 
	if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PK_tblCardData]'))  
	ALTER TABLE [dbo].[tblCardData] WITH NOCHECK ADD 
		CONSTRAINT [PK_tblCardData] PRIMARY KEY  CLUSTERED 
		(
			[fstrID]
		) WITH  FILLFACTOR = 70  ON [PRIMARY] ;
	--GO

    /*** Table # 3 of 5 ----6/7/2019 td ****/ 
	if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PK_tblPicture]'))  
	ALTER TABLE [dbo].[tblPicture] WITH NOCHECK ADD 
		CONSTRAINT [PK_tblPicture] PRIMARY KEY  CLUSTERED 
		(
			[fstrID],
			[fintPicNum]
		)  ON [PRIMARY] ;
	--GO

    /*** Table # 4 of 5 ----6/7/2019 td ****/ 
	if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PK_tblTrackPrints]'))  
	ALTER TABLE [dbo].[tblTrackPrints] WITH NOCHECK ADD 
		CONSTRAINT [PK_tblTrackPrints] PRIMARY KEY  CLUSTERED 
		(
			[fintAutoID]
		)  ON [PRIMARY] ;
	--GO

    /*** Table # 5 of 5 ----6/7/2019 td ****/ 
	if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PK_tblVisits]'))  
	ALTER TABLE [dbo].[tblVisits] WITH NOCHECK ADD 
		CONSTRAINT [PK_tblVisits] PRIMARY KEY  CLUSTERED 
		(
			[flngVisitID]
		)  ON [PRIMARY] ;
	--GO

	---------------------------Added 1/14/2019 by Thomas DOWNES

	---CONSTRAINT [DF_tblCardData_fdatRecDate] DEFAULT getdate() FOR fdatRecDate 
	if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DF_tblCardData_fdatRecDate]'))  
	ALTER TABLE tblCardData ADD CONSTRAINT [DF_tblCardData_fdatRecDate] DEFAULT getdate() FOR fdatRecDate ;     

	--CONSTRAINT [DF_tblCardData_intTimesPrinted] DEFAULT 0 FOR intTimesPrinted
	if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DF_tblCardData_intTimesPrinted]'))  
	ALTER TABLE tblCardData ADD CONSTRAINT [DF_tblCardData_intTimesPrinted] DEFAULT 0 FOR intTimesPrinted ;     

	SELECT 'End of CREATE CONSTRAINTS.'  

    /**************************************************************************************************************/

	SELECT 'Success!!  Welcome to CI Badge by CI Solutions!!'  

END TRY 

-----------------------------------------------------------------
BEGIN CATCH 
   ---
   ---    Currently, we have no CATCH commands to execute.  ----5/8/2019 & 1/28/2019 thomas downes 
   ---
   	SELECT 'An error occurred in the 2nd half of the CreateTables script.' as FatalErrorMessage; 
   
END CATCH    

--GO











