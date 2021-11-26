''
''Added 9/9/2019 thomasd
''
Imports System.Drawing ''Added 10/11/2019 td 

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

    ''Added 11/25/2021 thomas downes
    fstrFullName

End Enum ''End of "Public Enum EnumCIBFields"

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

    Property intTimesPrinted As Integer

    Property fstrBarcode As String ''Added 10/11/2019 td
    Property fstrRFID_Unique As String ''Added 10/11/2019 td

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
