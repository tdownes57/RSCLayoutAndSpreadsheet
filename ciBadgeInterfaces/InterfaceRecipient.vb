''
''Added 9/9/2019 thomasd
''
Public Enum EnumCIBFields

    Undetermined

    ''   [idsCardDataID] [numeric](18, 0) IDENTITY (1, 1) Not NULL ,
    ''   [idfConfigID] [int] NULL ,
    ''   [fstrLastName] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
    ''   [fstrFirstName] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
    ''   [fstrMidName] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
    ''   [fstrID] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS Not NULL ,

    idsCardDataID
    idfConfigID
    fstrLastName
    fstrFirstName
    fstrMidName
    fstrID

    ''    [fdatRecDate] [datetime] NULL CONSTRAINT [DF_tblCardData_fdatRecDate] Default getdate() ,
    ''   [idfReportID] [int] NULL ,
    ''   [fstrBarcode] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,

    fdateRecDate
    idfReportID
    fstrBarCode

    TextField01 ''  [TextField01] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
    TextField02 ''[TextField02] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
    TextField03 ''[TextField03] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
    TextField04 ''[TextField04] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
    TextField05 ''[TextField05] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
    TextField06 ''[TextField06] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
    TextField07 ''[TextField07] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
    TextField08 ''[TextField08] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
    TextField09 ''[TextField09] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
    TextField10 ''[TextField10] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
    TextField11 ''[TextField11] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
    TextField12 ''[TextField12] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
    TextField13 ''[TextField13] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
    TextField14 ''[TextField14] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
    TextField15 ''[TextField15] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,

    TextField16 ''[TextField16] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
    TextField17 ''[TextField17] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
    TextField18 ''[TextField18] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
    TextField19 ''[TextField19] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
    TextField20 ''[TextField20] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
    TextField21 ''[TextField21] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
    TextField22 ''[TextField22] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
    TextField23 ''[TextField23] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
    TextField24 ''[TextField24] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
    TextField25 ''[TextField25] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,

    DateField01 ''[DateField01] [datetime] NULL ,
    DateField02 ''[DateField02] [datetime] NULL ,
    DateField03 ''[DateField03] [datetime] NULL ,
    DateField04 ''[DateField04] [datetime] NULL ,
    DateField05 ''[DateField05] [datetime] NULL ,

    fstrAddress ''[fstrAddress] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
    fstrCity ''[fstrCity] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
    fstrState ''[fstrState] [char] (2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
    fstrZip ''[fstrZip] [varchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,

    blnBatchPrint ''[blnBatchPrint] [bit] NULL ,
    ''---- Added 1/28/2019 thomas downes, for https://app.asana.com/0/0/872801181163659/f 
    intTimesPrinted ''[intTimesPrinted] [int] NULL CONSTRAINT [DF_tblCardData_intTimesPrinted] Default 0 ,
    fdatTimeStamp ''[fdatTimeStamp] [datetime] NULL ,
    fintRecPool
    fstrRFID_Unique

End Enum

Public Interface IRecipient
    ''
    ''Added 9/9/2019 thomasd
    ''
    Function GetTextValue(par_enum As EnumCIBFields) As String

    Function GetDateValue(par_enum As EnumCIBFields) As Date

    Function RecipientID() As String
    Function FirstName() As String
    Function LastName() As String

    Function TimesPrinted() As Integer

End Interface
