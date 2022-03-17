''
'' Added 12/13/2021 thomas downes  
''

Public Module ModEnumsAndStructs

    ''
    ''Moved to ciBadgeInterfaces on 12/13/2021. --- thomas.
    ''Added 12/8/2021 Thomas 
    ''
    Public Enum EnumWhichSideOfCard
        Undetermined
        EnumFrontside
        EnumBackside

    End Enum


    ''Added 1/19/2022 thomas downes
    Public Structure StructWhichSideOfCard
        ''Added 1/19/2022 thomas downes
        Dim EnumSide As EnumWhichSideOfCard
        Dim Backside As Boolean
    End Structure


    ''
    ''On 1/19/2022, I found the below code by copying the following Public Enum definition
    ''  from __RSC WindowsControlLibrary.Module1Enumerations.EnumElementType.
    ''
    ''  See __RSC WindowsControlLibrary.Module1Enumerations to see the original code. 
    ''   ----1/19/2022 td
    ''
    Public Enum Enum_ElementType

        Undetermined
        Field
        Portrait
        QRCode
        Signature
        ''Feb2 2022''StaticText
        StaticGraphic

        StaticTextV3
        StaticTextV4

        ''This allows for the users to create a sub-section of elements, which 
        ''  can be moved around as a unit (without having to re-select all of
        ''  the sub-elements, each time the user wants to move them around as a unit).
        ''  -----Thomas Downes, 1/21/2022 td
        LayoutSection ''Added 1/21/2022 td

        __Background ''Added 1/15/2022 td
        __Desktop ''Added 1/15/2022 td

    End Enum


    ''
    ''Moved from InterfaceRecipient.vb 3/17/2022 td 
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

        ''Added 11/25/2021 thomas downes
        fstrFullName ''Added 11/25/2021 thomas downes
        fstrNameAbbreviated ''Added 3/17/2022 thomas downes

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
        ''Moved up, 3/17/2022 td''fstrFullName ''Added 11/25/2021 thomas downes
        ''Moved up, 3/17/2022 td''fstrAbbreviatedName ''Added 3/17/2022 thomas downes

    End Enum ''End of "Public Enum EnumCIBFields"



End Module
