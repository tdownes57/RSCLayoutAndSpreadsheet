''
''Added 9/9/2019 thomasd
''
Imports System.Drawing ''Added 10/11/2019 td 

''
''-----n-------This was moved to ModEnumsAndStructs, on 3/17/2022 t//D//o//w//n//e//s// 
''
''-----n---Public Enum EnumCIBFields
''-----n---
''-----n---    Undetermined
''-----n---
''-----n---    ''   [idsCardDataID] [numeric](18, 0) IDENTITY (1, 1) Not NULL ,
''-----n---    ''   [idfConfigID] [int] NULL ,
''-----n---    ''   [fstrLastName] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
''-----n---    ''   [fstrFirstName] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
''-----n---    ''   [fstrMidName] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
''-----n---    ''   [fstrID] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS Not NULL ,

''-----n---    idsCardDataID
''-----n---    idfConfigID
''-----n---    fstrLastName
''-----n---    fstrFirstName
''-----n---    fstrMidName
''-----n---    fstrID

''-----n---    ''    [fdatRecDate] [datetime] NULL CONSTRAINT [DF_tblCardData_fdatRecDate] Default getdate() ,
''-----n---    ''   [idfReportID] [int] NULL ,
''-----n---    ''   [fstrBarcode] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,

''-----n---    fdateRecDate
''-----n---    idfReportID
''-----n---    fstrBarCode

''-----n---    TextField01 ''  [TextField01] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
''-----n---    TextField02 ''[TextField02] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
''-----n---    TextField03 ''[TextField03] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
''-----n---    TextField04 ''[TextField04] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
''-----n---    TextField05 ''[TextField05] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
''-----n---    TextField06 ''[TextField06] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
''-----n---    TextField07 ''[TextField07] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
''-----n---    TextField08 ''[TextField08] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
''-----n---    TextField09 ''[TextField09] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
''-----n---    TextField10 ''[TextField10] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
''-----n---    TextField11 ''[TextField11] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
''-----n---    TextField12 ''[TextField12] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
''-----n---    TextField13 ''[TextField13] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
''-----n---    TextField14 ''[TextField14] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
''-----n---    TextField15 ''[TextField15] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,

''-----n---    TextField16 ''[TextField16] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
''-----n---    TextField17 ''[TextField17] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
''-----n---    TextField18 ''[TextField18] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
''-----n---    TextField19 ''[TextField19] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
''-----n---    TextField20 ''[TextField20] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
''-----n---    TextField21 ''[TextField21] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
''-----n---    TextField22 ''[TextField22] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
''-----n---    TextField23 ''[TextField23] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
''-----n---    TextField24 ''[TextField24] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
''-----n---    TextField25 ''[TextField25] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,

''-----n---    DateField01 ''[DateField01] [datetime] NULL ,
''-----n---    DateField02 ''[DateField02] [datetime] NULL ,
''-----n---    DateField03 ''[DateField03] [datetime] NULL ,
''-----n---    DateField04 ''[DateField04] [datetime] NULL ,
''-----n---    DateField05 ''[DateField05] [datetime] NULL ,

''-----n---    fstrAddress ''[fstrAddress] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
''-----n---    fstrCity ''[fstrCity] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
''-----n---    fstrState ''[fstrState] [char] (2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
''-----n---    fstrZip ''[fstrZip] [varchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,

''-----n---    blnBatchPrint ''[blnBatchPrint] [bit] NULL ,
''-----n---    ''---- Added 1/28/2019 thomas downes, for https://app.asana.com/0/0/872801181163659/f 
''-----n---    intTimesPrinted ''[intTimesPrinted] [int] NULL CONSTRAINT [DF_tblCardData_intTimesPrinted] Default 0 ,
''-----n---    fdatTimeStamp ''[fdatTimeStamp] [datetime] NULL ,
''-----n---    fintRecPool
''-----n---    fstrRFID_Unique

''-----n---    ''Added 11/25/2021 thomas downes
''-----n---    fstrFullName

''-----n---End Enum ''End of "Public Enum EnumCIBFields"

Public Interface IRecipient
    ''
    ''Added 9/9/2019 thomasd
    ''
    Function GetPortraitImage() As System.Drawing.Image ''Added 10/11/2019 td 

    Property Picture As System.Drawing.Image ''Added 10/16/2019 thomas d.  
    Property BadgeImage As System.Drawing.Image ''Added 9/29/2021 thomas d.  

    Function GetTextValue(par_enum As EnumCIBFields) As String

    Function GetDateValue(par_enum As EnumCIBFields) As Date

    Function RecipientID() As String

    Property idsCardDataID As Integer
    Property idfConfigID As Integer
    Property fstrLastName As String
    Property fstrFirstName As String
    Property fstrMidName As String
    Property fstrID As String

    ''Added 11/25/2021 Thomas 
    Property fstrFullName As String

    ''Added 2/15/2022 Thomas 
    Property fstrNameAbbreviated As String
    Property fstrEmailAddress As String ''Added 2/15/2022 td


    Property intTimesPrinted As Integer

    Property fstrBarcode As String ''Added 10/11/2019 td
    Property fstrRFID_Unique As String ''Added 10/11/2019 td

    Property fstrCity As String ''Added 12/6/2021 td 
    Property fstrAddress As String ''Added 12/7/2021 td 
    Property fstrState As String ''Added 12/7/2021 td 
    Property fstrZip As String ''Added 12/7/2021 td 

    ''-------------------------------------------------------
    ''Custom fields 
    ''   ----10/4/2019 thomas d
    ''-------------------------------------------------------
    Property DateField01 As DateTime
    Property DateField02 As DateTime
    Property DateField03 As DateTime
    Property DateField04 As DateTime
    Property DateField05 As DateTime


    Property TextField01 As String
    Property TextField02 As String
    Property TextField03 As String
    Property TextField04 As String
    Property TextField05 As String
    Property TextField06 As String
    Property TextField07 As String
    Property TextField08 As String
    Property TextField09 As String
    Property TextField10 As String
    Property TextField11 As String
    Property TextField12 As String
    Property TextField13 As String
    Property TextField14 As String
    Property TextField15 As String



End Interface ''End of "Public Interface IRecipient"
