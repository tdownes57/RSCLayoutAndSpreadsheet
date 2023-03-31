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


    ''Added 3/30/2023 td
    Public Enum EnumPrintMode
        Undetermined
        Designer
        PostDesign ''Preview or FinalID.  --Added 3/31/2023 
        Preview
        FinalID
    End Enum


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
        ''Moved below. 3/20/2022 td''FieldColumn ''Added 3/18/2022 for ControlsRSC/RSCSpreadsheet
        ''   & ControlsRSC/RSCFieldColumn.  ----3/18/2022 td

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

        ''Added 3/20/2022 for ControlsRSC/RSCSpreadsheet
        ''   & ControlsRSC/RSCFieldColumn.  ----3/20/2022 td
        RSCSheetColumn ''Added 3/20/2022 td
        RSCSheetSpreadsheet ''Added 3/20/2022 td
        RSCSheetRowHeader ''Added 3/23/2022 td

    End Enum ''End of ""Public Enum Enum_ElementType""


    Public Enum Enum_ElementTypeVersion
        ''
        ''Added 5/20/2022 thomas downes 
        ''
        Undetermined
        NotApplicable

        FieldV3
        FieldV4

        StaticTextV3
        StaticTextV4

    End Enum ''End of ""Public Enum Enum_ElementType""


    ''
    ''Moved from InterfaceRecipient.vb 3/17/2022 td 
    ''
    Public Enum EnumCIBFields

        Undetermined ''Field Index 0 

        ''   [idsCardDataID] [numeric](18, 0) IDENTITY (1, 1) Not NULL ,
        ''   [idfConfigID] [int] NULL ,
        ''   [fstrLastName] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
        ''   [fstrFirstName] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
        ''   [fstrMidName] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
        ''   [fstrID] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS Not NULL ,

        idsCardDataID ''Field Index 1
        idfConfigID ''Field Index 2
        fstrLastName ''Field Index 3
        fstrFirstName ''Field Index 4
        fstrMidName ''Field Index 5
        fstrID ''Field Index 6

        ''Added 11/25/2021 thomas downes
        fstrFullName ''Added 11/25/2021 thomas downes
        fstrNameAbbreviated ''Added 3/17/2022 thomas downes

        ''    [fdatRecDate] [datetime] NULL CONSTRAINT [DF_tblCardData_fdatRecDate] Default getdate() ,
        ''   [idfReportID] [int] NULL ,
        ''   [fstrBarcode] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,

        fdateRecDate  ''Field Index 9
        idfReportID ''Field Index 10
        fstrBarCode ''Field Index 11

        fstrAddress ''F.I.#12  [fstrAddress] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
        fstrCity ''F.I.#13    [fstrCity] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
        fstrState ''F.I.#14  [fstrState] [char] (2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
        fstrZip ''F.I.#15   [fstrZip] [varchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,

        blnBatchPrint ''F.I.#16  [blnBatchPrint] [bit] NULL ,
        ''---- Added 1/28/2019 thomas downes, for https://app.asana.com/0/0/872801181163659/f 
        intTimesPrinted ''F.I.#17  [intTimesPrinted] [int] NULL CONSTRAINT [DF_tblCardData_intTimesPrinted] Default 0 ,
        fdatTimeStamp ''F.I.#18  [fdatTimeStamp] [datetime] NULL ,
        fintRecPool ''F.I.#19
        fstrRFID_Unique ''F.I.#20

        ''Moved below 9/30/2022 PortraitPhotoID ''Added 5/20/2022 thomas downes  

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

        PortraitPhotoID ''Added 9/30/2022 & 5/20/2022 thomas downes  

        ''Moved up. 5/5/2022 ''fstrAddress ''[fstrAddress] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
        ''Moved up. 5/5/2022 ''fstrCity ''[fstrCity] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
        ''Moved up. 5/5/2022 ''fstrState ''[fstrState] [char] (2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
        ''Moved up. 5/5/2022 ''fstrZip ''[fstrZip] [varchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,

        ''Moved up. 5/5/2022 ''blnBatchPrint ''[blnBatchPrint] [bit] NULL ,
        ''''---- Added 1/28/2019 thomas downes, for https://app.asana.com/0/0/872801181163659/f 
        ''Moved up. 5/5/2022 ''intTimesPrinted ''[intTimesPrinted] [int] NULL CONSTRAINT [DF_tblCardData_intTimesPrinted] Default 0 ,
        ''Moved up. 5/5/2022 ''fdatTimeStamp ''[fdatTimeStamp] [datetime] NULL ,
        ''Moved up. 5/5/2022 ''fintRecPool
        ''Moved up. 5/5/2022 ''fstrRFID_Unique

        ''Added 11/25/2021 thomas downes
        ''Moved up, 3/17/2022 td''fstrFullName ''Added 11/25/2021 thomas downes
        ''Moved up, 3/17/2022 td''fstrAbbreviatedName ''Added 3/17/2022 thomas downes

    End Enum ''End of "Public Enum EnumCIBFields"


    Public Class EnumCIBFieldsText
        ''
        '' https://stackoverflow.com/questions/479410/enum-tostring-with-user-friendly-strings
        ''
        Public Function Caption(par_enum As EnumCIBFields)

            Select Case par_enum

                Case EnumCIBFields.fstrID
                    Return "ID of Cardholder"

                Case EnumCIBFields.fstrFirstName
                    Return "First Name"

                Case EnumCIBFields.fstrMidName
                    Return "Middle Name"

                Case EnumCIBFields.fstrLastName
                    Return "Last Name"

                Case EnumCIBFields.fstrAddress
                    Return "Address"

                Case EnumCIBFields.fstrNameAbbreviated
                    Return "Name, Abbreviated"

                Case EnumCIBFields.fstrFullName
                    Return "Full Name"

                Case EnumCIBFields.fstrCity
                    Return "City"

                Case EnumCIBFields.fstrRFID_Unique
                    Return "RFID"

                Case EnumCIBFields.intTimesPrinted
                    Return "Times Printed"

                Case EnumCIBFields.PortraitPhotoID
                    Return "Portrait Photo ID"

                Case EnumCIBFields.fdatTimeStamp
                    Return "Time Stamp"

                Case EnumCIBFields.fstrBarCode
                    Return "Bar Code"

                Case EnumCIBFields.fstrState
                    Return "State or Province"

                Case EnumCIBFields.fstrZip
                    Return "Zip Code"

                Case EnumCIBFields.fdateRecDate
                    Return "Record Date"

            End Select ''End of""Select Case par_enum""

        End Function ''End of ""Public Function Caption(par_enum As EnumCIBFields)""

    End Class ''End of ""Public Class EnumCIBFieldsText""


    Public Function GetListOfAllFieldEnums() As List(Of EnumCIBFields)
        ''
        ''Added 5/5/2022 td
        ''
        ''As currently written (5.5.2022) this will likely produce a run-time error. 
        ''
        Dim objList As New List(Of EnumCIBFields)

        ''objList = new List(Of EnumCIBFields)
        ''For intIndex = 0 To 1000
        ''
        ''    objList.Add(CType(intIndex, EnumCIBFields))
        ''
        ''Next intIndex

        ''https://docs.microsoft.com/en-us/dotnet/visual-basic/programming-guide/language-features/constants-enums/how-to-iterate-through-an-enumeration
        ''To iterate through an enumeration
        ''Declare an array And convert the enumeration to it with the GetValues method before passing the array as you would any other variable. The following example displays each member of the enumeration FirstDayOfWeek as it iterates through the enumeration.()
        ''
        ''    Dim items As Array
        ''    items = System.Enum.GetValues(GetType(FirstDayOfWeek))
        ''    Dim item As String
        ''    For Each item In items
        ''       MsgBox(item)
        ''    Next

        Dim arrayEnumItems As Array
        arrayEnumItems = System.Enum.GetValues(GetType(EnumCIBFields))
        Dim enum_item As EnumCIBFields
        For Each enum_item In arrayEnumItems
            objList.Add(enum_item)
        Next enum_item

        Return objList

    End Function ''End of ""Public Function GetListOfAllFieldEnums() As List(Of EnumCIBFields)""


    Public Function GetListOfAllFieldEnums_Relevant(par_allFieldInfos As List(Of ICIBFieldStandardOrCustom)) _
                                 As List(Of EnumCIBFields)
        ''
        ''Added 5/5/2022 td
        ''
        ''As currently written (5.5.2022) this will likely produce a run-time error. 
        ''
        Dim objList As New List(Of EnumCIBFields)

        ''objList = new List(Of EnumCIBFields)
        ''For intIndex = 0 To 1000
        ''
        ''    objList.Add(CType(intIndex, EnumCIBFields))
        ''
        ''Next intIndex

        ''https://docs.microsoft.com/en-us/dotnet/visual-basic/programming-guide/language-features/constants-enums/how-to-iterate-through-an-enumeration
        ''To iterate through an enumeration
        ''Declare an array And convert the enumeration to it with the GetValues method before passing the array as you would any other variable. The following example displays each member of the enumeration FirstDayOfWeek as it iterates through the enumeration.()
        ''
        ''    Dim items As Array
        ''    items = System.Enum.GetValues(GetType(FirstDayOfWeek))
        ''    Dim item As String
        ''    For Each item In items
        ''       MsgBox(item)
        ''    Next

        Dim arrayEnumItems As Array
        arrayEnumItems = System.Enum.GetValues(GetType(EnumCIBFields))
        Dim enum_item As EnumCIBFields
        Dim each_infoField As ICIBFieldStandardOrCustom ''Added 5/13/2022 td
        Dim each_matchingFieldInfo As ICIBFieldStandardOrCustom ''Added 5/13/2022 td
        Dim boolMatchesEnum As Boolean

        ''
        ''Loop through all of the array items. 
        ''
        For Each enum_item In arrayEnumItems

            each_matchingFieldInfo = Nothing ''Reinitialize. 

            ''
            ''Find the relevant field information (interface). 
            ''
            For Each each_infoField In par_allFieldInfos

                boolMatchesEnum = (each_infoField.FieldEnumValue = enum_item)
                If (boolMatchesEnum) Then
                    each_matchingFieldInfo = each_infoField
                    Exit For
                End If

            Next each_infoField

            ''
            ''If relevant, add it to the output list. 
            ''
            If (each_matchingFieldInfo IsNot Nothing) Then
                If (each_matchingFieldInfo.IsRelevantToPersonality) Then
                    objList.Add(enum_item)
                End If
            End If

        Next enum_item

        ''
        ''ExitHandler 
        ''
        Return objList

    End Function ''End of ""Public Function GetListOfAllFieldEnums() As List(Of EnumCIBFields)""






End Module
