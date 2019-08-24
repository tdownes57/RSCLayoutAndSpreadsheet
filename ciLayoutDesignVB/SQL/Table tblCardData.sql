

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