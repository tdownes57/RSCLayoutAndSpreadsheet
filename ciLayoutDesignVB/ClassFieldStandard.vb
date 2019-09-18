Option Explicit On
Option Strict On

Imports ciLayoutDesignVB
Imports ciBadgeInterfaces ''Added 8/24/2019 thomas d.

''
''Added 7/26/2019 thomas downes  
''

Public Class ClassFieldStandard
    Inherits ClassFieldAny ''Added 9/16/2019 thomas d.
    ''9/16/2019 td''Implements ICIBFieldStandardOrCustom ''Added 7/21/2019 td
    ''
    ''Added 7/26/2019 thomas d. 
    ''
    ''Public TextFieldId As Integer
    ''Not applicable. 7/26/2019 td''Public Property TextFieldId As Integer = 1

    ''Public Property IsStandard As Boolean = False Implements ICIBFieldStandardOrCustom.IsStandard ''Added 7/26/2019 td
    ''Public Property IsCustomizable As Boolean = False Implements ICIBFieldStandardOrCustom.IsCustomizable ''Added 7/26/2019 td

    ''''Not applicable. 7/26/2019 td''Public Property DateFieldId As Integer = 0
    ''Public Property IsDateField As Boolean = False

    ''Public Property Text_orDate As String = "Text"

    ''Public Property LabelCaption As String = ""

    ''''Redundant. See ExampleValue. ---7/26/2019 td''Public Property ExampleValueToUseInLayout As String = ""

    ''''7/21 td''Public Property CIBadgeFieldname As String ''Added 7/21/2019 Thomas DOWNES 
    ''Public Property CIBadgeField As String Implements ICIBFieldStandardOrCustom.CIBadgeField ''Added 7/21/2019 Thomas DOWNES 
    ''Public Property OtherDbField_Optional As String Implements ICIBFieldStandardOrCustom.OtherDbField_Optional ''Added 7/21/2019 Thomas DOWNES 

    ''Public Property FieldLabelCaption As String Implements ICIBFieldStandardOrCustom.FieldLabelCaption
    ''''    Get
    ''''        Throw New NotImplementedException()
    ''''    End Get
    ''''    Set(value As String)
    ''''        Throw New NotImplementedException()
    ''''    End Set
    ''''End Property

    ''Public Property FieldType_TD As Char Implements ICIBFieldStandardOrCustom.FieldType_TD
    ''''    Get
    ''''        Throw New NotImplementedException()
    ''''    End Get
    ''''    Set(value As Char)
    ''''        Throw New NotImplementedException()
    ''''    End Set
    ''''End Property

    ''Public Property FieldEnumValue As EnumCIBFields Implements ICIBFieldStandardOrCustom.FieldEnumValue ''Added 9/16/2019 td 

    ''Public Property FieldIndex As Integer Implements ICIBFieldStandardOrCustom.FieldIndex
    ''''    Get
    ''''        Throw New NotImplementedException()
    ''''    End Get
    ''''    Set(value As Integer)
    ''''        Throw New NotImplementedException()
    ''''    End Set
    ''''End Property

    ''Public Property IsFieldForDates As Boolean Implements ICIBFieldStandardOrCustom.IsFieldForDates
    ''''    Get
    ''''        Throw New NotImplementedException()
    ''''    End Get
    ''''    Set(value As Boolean)
    ''''        Throw New NotImplementedException()
    ''''    End Set
    ''''End Property

    ''Public Property IsLocked As Boolean Implements ICIBFieldStandardOrCustom.IsLocked
    ''''    Get
    ''''        Throw New NotImplementedException()
    ''''    End Get
    ''''    Set(value As Boolean)
    ''''        Throw New NotImplementedException()
    ''''    End Set
    ''''End Property

    ''''Added 8/23/2019 thomas d.
    ''Public Property IsDisplayedOnBadge As Boolean Implements ICIBFieldStandardOrCustom.IsDisplayedOnBadge
    ''Public Property IsDisplayedForEdits As Boolean Implements ICIBFieldStandardOrCustom.IsDisplayedForEdits

    ''Public Property ExampleValue As String Implements ICIBFieldStandardOrCustom.ExampleValue
    ''''    Get
    ''''        Throw New NotImplementedException()
    ''''    End Get
    ''''    Set(value As String)
    ''''        Throw New NotImplementedException()
    ''''    End Set
    ''''End Property

    ''Public Property HasPresetValues As Boolean Implements ICIBFieldStandardOrCustom.HasPresetValues
    ''''    Get
    ''''        Throw New NotImplementedException()
    ''''    End Get
    ''''    Set(value As Boolean)
    ''''        Throw New NotImplementedException()
    ''''    End Set
    ''''End Property

    ''''Not needed here for Standard fields. ---9/16/2019 td''Public Property ArrayOfValues As String() Implements ICIBFieldStandardOrCustom.ArrayOfValues
    ''''    Get
    ''''        Throw New NotImplementedException()
    ''''    End Get
    ''''    Set(value As String())
    ''''        Throw New NotImplementedException()
    ''''    End Set
    ''''End Property

    ''''Public Property OtherDbFieldname As String Implements ICIBFieldStandardOrCustom.OtherDbField_Optional
    ''''    Get
    ''''        Throw New NotImplementedException()
    ''''    End Get
    ''''    Set(value As String)
    ''''        Throw New NotImplementedException()
    ''''    End Set
    ''''End Property

    ''Public Property IsAdditionalField As Boolean Implements ICIBFieldStandardOrCustom.IsAdditionalField
    ''''    Get
    ''''        Throw New NotImplementedException()
    ''''    End Get
    ''''    Set(value As Boolean)
    ''''        Throw New NotImplementedException()
    ''''    End Set
    ''''End Property

    ''Public Property IsBarCode As Boolean = False Implements ICIBFieldStandardOrCustom.IsBarcodeField ''Added 7/31/2019 td
    ''Public Property DataEntryText As String Implements ICIBFieldStandardOrCustom.DataEntryText ''Added 9/9/2019 td

    ''''8/27/2019 td'' Property Image_BL As Image Implements ICIBFieldStandardOrCustom.Image_BL ''Added 8/27/2019 

    ''Private mod_elementFieldClass As ClassElementField ''Added 9/3/2019 td   

    ''''
    ''''Added 7/29/2019 thomas downes
    ''''
    ''''9/3/2019 td''Public Property ElementInfo As ClassElementText
    ''Public Property ElementFieldClass() As ClassElementField
    ''    Get
    ''        ''Added 9/3/2019 thomas d. 
    ''        Return mod_elementFieldClass
    ''    End Get
    ''    Set(value As ClassElementField)
    ''        ''Added 9/3/2019 thomas d. 
    ''        mod_elementFieldClass = value
    ''        ''Added 9/3/2019 thomas d. 
    ''        Me.ElementInfo_Base = CType(value, IElement_Base)
    ''        Me.ElementInfo_Text = CType(value, IElement_TextField)
    ''    End Set
    ''End Property

    ''''Added 9/3/2019 td
    ''Public Property ElementInfo_Base As IElement_Base Implements ICIBFieldStandardOrCustom.ElementInfo_Base
    ''''Added 9/3/2019 td
    ''Public Property ElementInfo_Text As IElement_TextField Implements ICIBFieldStandardOrCustom.ElementInfo_Text

    ''
    ''Added 7/16/2019 thomas d. 
    ''
    Public Shared ListOfFields_Students As New List(Of ClassFieldStandard)
    Public Shared ListOfFields_Staff As New List(Of ClassFieldStandard)

    Public Shared Function ListOfFieldInfos_Students() As List(Of ICIBFieldStandardOrCustom)
        ''Added 9/2/2019 Thomas DOWNES
        Dim new_list As New List(Of ICIBFieldStandardOrCustom)
        For Each obj_class As ClassFieldStandard In ListOfFields_Students
            ''Added 9/2/2019
            new_list.Add(CType(obj_class, ICIBFieldStandardOrCustom))
        Next obj_class
        Return new_list
    End Function ''End of "Public Shared Function ListOfFieldInfos_Students() As List(Of ICIBFieldStandardOrCustom)"

    Public Shared Function ListOfFieldInfos_Staff() As List(Of ICIBFieldStandardOrCustom)
        ''Added 9/2/2019 Thomas DOWNES
        Dim new_list As New List(Of ICIBFieldStandardOrCustom)
        For Each obj_class As ClassFieldStandard In ListOfFields_Staff
            ''Added 9/2/2019
            new_list.Add(CType(obj_class, ICIBFieldStandardOrCustom))
        Next obj_class
        Return new_list
    End Function ''End of "Public Shared Function ListOfFieldInfos_Students() As List(Of ICIBFieldStandardOrCustom)"

    Public Shared Function ListOfElementsText_Stdrd(Optional par_intLayoutWidth As Integer = 0) As List(Of IFieldInfo_ElementPositions)
        ''9/4/2019 td''Public Shared Function ListOfElementsText_Stdrd() As List(Of IElementWithText)
        ''
        ''Added 8/24/2019 Thomas D.  
        ''
        Dim obj_listOutput As New List(Of IFieldInfo_ElementPositions)

        For Each each_obj In ListOfFields_Students

            Dim new_ElementWithText As New IFieldInfo_ElementPositions
            Dim obj_ElementText As IElement_TextField
            Dim obj_Element_Base As IElement_Base

            new_ElementWithText.FieldInfo = each_obj ''Added 9/3/2019 td  

            obj_ElementText = CType(each_obj.ElementFieldClass, IElement_TextField)
            obj_Element_Base = CType(each_obj.ElementFieldClass, IElement_Base)

            new_ElementWithText.Position_BL = obj_Element_Base
            new_ElementWithText.TextDisplay = obj_ElementText

            ''Added 9/4/2019 td
            new_ElementWithText.BadgeLayout_Width = par_intLayoutWidth
            ''9/12 td''new_ElementWithText.Position_BL.LayoutWidth_Pixels = par_intLayoutWidth
            new_ElementWithText.Position_BL.BadgeLayout.Width_Pixels = par_intLayoutWidth

            obj_listOutput.Add(new_ElementWithText)

        Next each_obj

        Return obj_listOutput

    End Function ''eND OF Public Shared Function ListOfElementsText_Stdrd()  

    Public Shared Sub InitializeHardcodedList_Students(pboolOnlyIfNeeded As Boolean)
        ''
        ''Added 7/26/2019 td
        ''
        Dim intFieldIndex As Integer ''Added 9/17/2019 td 
        Const c_heightPixels As Integer = 30 ''Added 9/17 td
        Dim intLeft_Pixels As Integer = 0
        Dim intTop_Pixels As Integer = 0 ''Added 9/17/2019 td 

        With ListOfFields_Students
            ''8/28/2019 td''If (pboolOnlyIfNeeded And .Count > 0) Then Exit Sub
            If (.Count > 0) Then Exit Sub
        End With ''End of "With ListOfFields_Students"


        intFieldIndex = 1 ''Added 9/17/2019 td
        Dim new_objectField1 As New ClassFieldStandard
        With new_objectField1
            .FieldEnumValue = EnumCIBFields.fstrID ''Added 9/16/2019 td
            ''N/A''.TextFieldId = 1 ''TextField01 
            .IsCustomizable = False ''Added 7/26/2019 td 
            .FieldLabelCaption = "Student ID"
            .CIBadgeField = "fstrID"
            .FieldType_TD = "T"c
            .HasPresetValues = False
            .IsAdditionalField = False
            .IsFieldForDates = False
            .ExampleValue = "12345"
            ''Added 8/23/2019 td
            .IsDisplayedForEdits = True
            .IsDisplayedOnBadge = True
            .IsLocked = True

            ''Added 9/3/2019 td
            ''9/15/2019 td''.ElementInfo = New ClassElementText()
            ''9/17/2019 td''.ElementFieldClass = New ClassElementField(0, 0, 30)
            intLeft_Pixels = (30 * (intFieldIndex - 1))
            intTop_Pixels = intLeft_Pixels ''Let's have a staircase effect!! 

            ''---(---Fields cannot link outward to elements.---9/18/2019 td
            ''--.ElementFieldClass = New ClassElementField(new_objectField1, intLeft_Pixels, intTop_Pixels, c_heightPixels)

            ''Added 9/3/2019 td
            ''---(---Fields cannot link outward to elements.---9/18/2019 td
            ''--.ElementInfo_Base = CType(.ElementFieldClass, ciBadgeInterfaces.IElement_Base)
            ''--.ElementInfo_Text = CType(.ElementFieldClass, ciBadgeInterfaces.IElement_TextField)

        End With
        ListOfFields_Students.Add(new_objectField1)


        intFieldIndex = 2 ''Added 9/17/2019 td
        Dim new_objectField2 As New ClassFieldStandard
        With new_objectField2
            .FieldEnumValue = EnumCIBFields.fstrFirstName ''Added 9/16/2019 td
            ''N/A''.TextFieldId = 2 ''TextField02
            .IsCustomizable = False ''Added 7/26/2019 td 
            .FieldLabelCaption = "First Name"
            .CIBadgeField = "fstrFirstName"
            .FieldType_TD = "T"c
            .HasPresetValues = False
            .IsAdditionalField = False
            .IsFieldForDates = False
            ''Added 8/23/2019 td
            .IsDisplayedForEdits = True
            .IsDisplayedOnBadge = True
            .IsLocked = False

            ''Added 9/3/2019 td
            ''9/15/2019 td''.ElementInfo = New ClassElementText()
            ''#1 9/17/2019 td''.ElementFieldClass = New ClassElementField(30, 30, 30)
            '' #2 9/17/2019 td''.ElementFieldClass = New ClassElementField(new_objectField2, 30, 30, 30)
            intLeft_Pixels = (30 * (intFieldIndex - 1))
            intTop_Pixels = intLeft_Pixels ''Let's have a staircase effect!! 
            ''---(---Fields cannot link outward to elements.---9/18/2019 td.ElementFieldClass = New ClassElementField(new_objectField2, intLeft_Pixels, intTop_Pixels, c_heightPixels)

            ''Added 9/3/2019 td
            ''---(---Fields cannot link outward to elements.---9/18/2019 td.ElementInfo_Base = CType(.ElementFieldClass, ciBadgeInterfaces.IElement_Base)
            ''---(---Fields cannot link outward to elements.---9/18/2019 td.ElementInfo_Text = CType(.ElementFieldClass, ciBadgeInterfaces.IElement_TextField)

        End With
        ListOfFields_Students.Add(new_objectField2)



        intFieldIndex = 3 ''Added 9/17/2019 td
        Dim new_object3 As New ClassFieldStandard
        With new_object3
            .FieldEnumValue = EnumCIBFields.fstrLastName ''Added 9/16/2019 td
            ''N/A''.TextFieldId = 3 ''TextField03 
            .IsCustomizable = False ''Added 7/26/2019 td 
            .FieldLabelCaption = "Last Name"
            .CIBadgeField = "fstrLastName"
            .FieldType_TD = "T"c
            .HasPresetValues = False
            .IsAdditionalField = False
            ''.IsDateField = False
            .IsFieldForDates = False
            ''Added 8/23/2019 td
            .IsDisplayedForEdits = True
            .IsDisplayedOnBadge = True
            .IsLocked = False

            ''Added 9/3/2019 td
            ''9/15/2019 td''.ElementInfo = New ClassElementText()
            ''9/17/2019 td''.ElementFieldClass = New ClassElementField(60, 60, 30)
            intLeft_Pixels = (30 * (intFieldIndex - 1))
            intTop_Pixels = intLeft_Pixels ''Let's have a staircase effect!! 
            ''---(---Fields cannot link outward to elements.---9/18/2019 td.ElementFieldClass = New ClassElementField(new_objectField2, intLeft_Pixels, intTop_Pixels, c_heightPixels)

            ''Added 9/3/2019 td
            ''---(---Fields cannot link outward to elements.---9/18/2019 td.ElementInfo_Base = CType(.ElementFieldClass, ciBadgeInterfaces.IElement_Base)
            ''---(---Fields cannot link outward to elements.---9/18/2019 td.ElementInfo_Text = CType(.ElementFieldClass, ciBadgeInterfaces.IElement_TextField)

        End With
        ListOfFields_Students.Add(new_object3)

        ''Added 8/23/2019 thomas d
        intFieldIndex = 4 ''Added 9/17/2019 td
        Dim new_object4 As New ClassFieldStandard
        With new_object4
            .FieldEnumValue = EnumCIBFields.fstrMidName ''Added 9/16/2019 td
            .IsCustomizable = False ''Added 7/26/2019 td 
            .FieldLabelCaption = "Middle Name"
            .CIBadgeField = "fstrMidName"
            .FieldType_TD = "T"c
            .HasPresetValues = False
            .IsAdditionalField = False
            .IsFieldForDates = False
            .IsDisplayedForEdits = False
            .IsDisplayedOnBadge = False
            .IsLocked = False

            ''Added 9/3/2019 td
            ''---(---Fields cannot link outward to elements.---9/18/2019 td.ElementFieldClass = New ClassElementField()

        End With
        ListOfFields_Students.Add(new_object4)


        ''Added 8/23/2019 thomas d
        intFieldIndex = 5 ''Added 9/17/2019 td
        Dim new_object5 As New ClassFieldStandard
        With new_object5
            .FieldEnumValue = EnumCIBFields.fstrBarCode ''Added 9/16/2019 td
            .IsCustomizable = False ''Added 7/26/2019 td 
            .FieldLabelCaption = "Barcode Value"
            .CIBadgeField = "fstrBarcode"
            .FieldType_TD = "T"c
            .HasPresetValues = False
            .IsAdditionalField = False
            .IsFieldForDates = False
            .IsDisplayedForEdits = False
            .IsDisplayedOnBadge = False
            .IsLocked = False
            .ExampleValue = "1234567890" ''Added 9/12/2019 td 

            ''Added 9/3/2019 td
            ''---(---Fields cannot link outward to elements.---9/18/2019 td.ElementFieldClass = New ClassElementField()

            ''Added 8/28/2019 thomas downes
            ''---(---Fields cannot link outward to elements.---9/18/2019 td.ElementFieldClass.FontSize_Pixels = 16 ''Added 9/12/2019 td  
            ''9/12/2019 td''.ElementInfo.Font_DrawingClass = modFonts.BarCodeFont_ByDefault(16)
            ''---(---Fields cannot link outward to elements.---9/18/2019 td.ElementFieldClass.Font_DrawingClass = modFonts.BarCodeFont_ByDefault(.ElementFieldClass.FontSize_Pixels)

        End With
        ListOfFields_Students.Add(new_object5)


        ''Added 8/23/2019 thomas d
        intFieldIndex = 6 ''Added 9/17/2019 td
        Dim new_object6 As New ClassFieldStandard
        With new_object6
            .FieldEnumValue = EnumCIBFields.fstrAddress ''Added 9/16/2019 td
            .IsCustomizable = False ''Added 7/26/2019 td 
            .FieldLabelCaption = "Address"
            .CIBadgeField = "fstrAddress"
            .FieldType_TD = "T"c
            .HasPresetValues = False
            .IsAdditionalField = False
            .IsFieldForDates = False
            .IsDisplayedForEdits = False
            .IsDisplayedOnBadge = False
            .IsLocked = False

            ''Added 9/3/2019 td
            ''---(---Fields cannot link outward to elements.---9/18/2019 td.ElementFieldClass = New ClassElementField()

        End With
        ListOfFields_Students.Add(new_object6)


        ''Added 8/23/2019 thomas d
        intFieldIndex = 7 ''Added 9/17/2019 td
        Dim new_object7 As New ClassFieldStandard
        With new_object7
            .FieldEnumValue = EnumCIBFields.fstrCity ''Added 9/16/2019 td
            .IsCustomizable = False ''Added 7/26/2019 td 
            .FieldLabelCaption = "City"
            .CIBadgeField = "fstrCity"
            .FieldType_TD = "T"c
            .HasPresetValues = False
            .IsAdditionalField = False
            .IsFieldForDates = False
            .IsDisplayedForEdits = False
            .IsDisplayedOnBadge = False
            .IsLocked = False

            ''Added 9/3/2019 td
            ''---(---Fields cannot link outward to elements.---9/18/2019 td.ElementFieldClass = New ClassElementField()

        End With
        ListOfFields_Students.Add(new_object7)


        ''Added 8/23/2019 thomas d
        intFieldIndex = 8 ''Added 9/17/2019 td
        Dim new_object8 As New ClassFieldStandard
        With new_object8
            .FieldEnumValue = EnumCIBFields.fstrState ''Added 9/16/2019 td
            .IsCustomizable = False ''Added 7/26/2019 td 
            .FieldLabelCaption = "State"
            .CIBadgeField = "fstrState"
            .FieldType_TD = "T"c
            .HasPresetValues = False
            .IsAdditionalField = False
            .IsFieldForDates = False
            .IsDisplayedForEdits = False
            .IsDisplayedOnBadge = False
            .IsLocked = False

            ''Added 9/3/2019 td
            ''---(---Fields cannot link outward to elements.---9/18/2019 td.ElementFieldClass = New ClassElementField()

        End With
        ListOfFields_Students.Add(new_object8)


        ''Added 8/23/2019 thomas d
        intFieldIndex = 9 ''Added 9/17/2019 td
        Dim new_object9 As New ClassFieldStandard
        With new_object9
            .FieldEnumValue = EnumCIBFields.fstrZip ''Added 9/16/2019 td
            .IsCustomizable = False ''Added 7/26/2019 td 
            .FieldLabelCaption = "Zipcode"
            .CIBadgeField = "fstrZip"
            .FieldType_TD = "T"c
            .HasPresetValues = False
            .IsAdditionalField = False
            .IsFieldForDates = False
            .IsDisplayedForEdits = False
            .IsDisplayedOnBadge = False
            .IsLocked = False
            ''---(---Fields cannot link outward to elements.---9/18/2019 td.ElementFieldClass = New ClassElementField()
        End With
        ListOfFields_Students.Add(new_object9)


        ''Added 9/16/2019 thomas d
        intFieldIndex = 10 ''Added 9/17/2019 td
        Dim new_object91 As New ClassFieldStandard
        With new_object91
            .FieldEnumValue = EnumCIBFields.blnBatchPrint ''Added 9/16/2019 td
            .IsCustomizable = False ''Added 9/16/2019 td 
            .FieldLabelCaption = "Printed by Batch"
            .CIBadgeField = "blnBatchPrint"
            .FieldType_TD = "B"c
            .HasPresetValues = False
            .IsAdditionalField = False
            .IsFieldForDates = False
            .IsDisplayedForEdits = False
            .IsDisplayedOnBadge = False
            .IsLocked = True
            ''---(---Fields cannot link outward to elements.---9/18/2019 td.ElementFieldClass = New ClassElementField()
        End With
        ListOfFields_Students.Add(new_object91)


        ''Added 9/16/2019 thomas d
        intFieldIndex = 11 ''Added 9/17/2019 td
        Dim new_object92 As New ClassFieldStandard
        With new_object92
            .FieldEnumValue = EnumCIBFields.idfConfigID ''Added 9/16/2019 td
            .IsCustomizable = False ''Added 7/26/2019 td 
            .FieldLabelCaption = "Personality ID"
            .CIBadgeField = "idfConfigID"
            .FieldType_TD = "I"c
            .HasPresetValues = False
            .IsAdditionalField = False
            .IsFieldForDates = False
            .IsDisplayedForEdits = False
            .IsDisplayedOnBadge = False
            .IsLocked = True
            ''---(---Fields cannot link outward to elements.---9/18/2019 td.ElementFieldClass = New ClassElementField()
        End With
        ListOfFields_Students.Add(new_object92)


        ''Added 9/16/2019 thomas d
        intFieldIndex = 12 ''Added 9/17/2019 td
        Dim new_object93 As New ClassFieldStandard
        With new_object93
            .FieldEnumValue = EnumCIBFields.idfReportID ''Added 9/16/2019 td
            .IsCustomizable = False
            .FieldLabelCaption = "Badge Layout ID"
            .CIBadgeField = "idfReportID"
            .FieldType_TD = "I"c
            .HasPresetValues = False
            .IsAdditionalField = False
            .IsFieldForDates = False
            .IsDisplayedForEdits = False
            .IsDisplayedOnBadge = False
            .IsLocked = True
            ''---(---Fields cannot link outward to elements.---9/18/2019 td.ElementFieldClass = New ClassElementField()
        End With
        ListOfFields_Students.Add(new_object93)


        ''Added 9/16/2019 thomas d
        intFieldIndex = 13 ''Added 9/17/2019 td
        Dim new_object94 As New ClassFieldStandard
        With new_object94
            .FieldEnumValue = EnumCIBFields.fdateRecDate ''Added 9/16/2019 td
            .IsCustomizable = False
            .FieldLabelCaption = "Record Created"
            .CIBadgeField = "fdateRecDate"
            .FieldType_TD = "D"c
            .HasPresetValues = False
            .IsAdditionalField = False
            .IsFieldForDates = True
            .IsDisplayedForEdits = False
            .IsDisplayedOnBadge = False
            .IsLocked = True
            ''---(---Fields cannot link outward to elements.---9/18/2019 td.ElementFieldClass = New ClassElementField()
        End With
        ListOfFields_Students.Add(new_object94)


        ''Added 9/16/2019 thomas d
        intFieldIndex = 14 ''Added 9/17/2019 td
        Dim new_object95 As New ClassFieldStandard
        With new_object95
            .FieldEnumValue = EnumCIBFields.fdatTimeStamp ''Added 9/16/2019 td
            .IsCustomizable = False
            .FieldLabelCaption = "Record Updated"
            .CIBadgeField = "fdatTimeStamp"
            .FieldType_TD = "D"c
            .HasPresetValues = False
            .IsAdditionalField = False
            .IsFieldForDates = True
            .IsDisplayedForEdits = False
            .IsDisplayedOnBadge = False
            .IsLocked = True
            ''---(---Fields cannot link outward to elements.---9/18/2019 td.ElementFieldClass = New ClassElementField()
        End With
        ListOfFields_Students.Add(new_object95)


        ''Added 8/23/2019 thomas d
        intFieldIndex = 15 ''Added 9/17/2019 td
        Dim new_object99 As New ClassFieldStandard
        With new_object99
            .FieldEnumValue = EnumCIBFields.fstrRFID_Unique ''Added 9/16/2019 td
            .IsCustomizable = False ''Added 7/26/2019 td 
            .FieldLabelCaption = "RFID/UID Value"
            .CIBadgeField = "fstrRFID"
            .FieldType_TD = "T"c
            .HasPresetValues = False
            .IsAdditionalField = False
            .IsFieldForDates = False
            .IsDisplayedForEdits = False
            .IsDisplayedOnBadge = False
            .IsLocked = False

            ''Added 9/3/2019 td
            ''---(---Fields cannot link outward to elements.---9/18/2019 td.ElementFieldClass = New ClassElementField()

        End With
        ListOfFields_Students.Add(new_object99)

    End Sub ''End of "InitializeHardcodedList_Students()"

    Public Shared Sub InitializeHardcodedList_Staff(pboolOnlyIfNeeded As Boolean)
        ''
        ''Stubbed 7/16/2019 td
        ''
        ''  Add Schoolname, Job Title, GradeLevel (if applicable). 
        ''
        ''Added 7/23/2019 thomas
        With ListOfFields_Staff
            If (pboolOnlyIfNeeded And .Count > 0) Then Exit Sub
        End With

        Dim new_object1 As New ClassFieldStandard
        With new_object1
            ''N/A''.TextFieldId = 1
            .IsCustomizable = False ''Added 7/26/2019 td 
            .FieldLabelCaption = "Staffperson ID"
            .CIBadgeField = "fstrID"
            .FieldType_TD = "T"c
            .HasPresetValues = False
            .IsAdditionalField = False
            ''.IsDateField = False
            .IsFieldForDates = False
            .ExampleValue = "4014"
        End With
        ListOfFields_Staff.Add(new_object1)

        Dim new_object2 As New ClassFieldStandard
        With new_object1
            ''N/A''.TextFieldId = 2
            .IsCustomizable = False ''Added 7/26/2019 td 
            .FieldLabelCaption = "First Name"
            .CIBadgeField = "fstrFirstName"
            .FieldType_TD = "T"c
            .HasPresetValues = False
            .IsAdditionalField = False
            ''.IsDateField = False
            .IsFieldForDates = False
        End With
        ListOfFields_Staff.Add(new_object2)

        Dim new_object3 As New ClassFieldStandard
        With new_object3
            ''N/A''.TextFieldId = 3
            .IsCustomizable = False ''Added 7/26/2019 td 
            .FieldLabelCaption = "Last Name"
            .CIBadgeField = "fstrLastName"
            .FieldType_TD = "T"c
            .HasPresetValues = True
            .IsAdditionalField = False
            ''.IsDateField = False
            .IsFieldForDates = False
        End With
        ListOfFields_Staff.Add(new_object3)

    End Sub ''End of "InitializeHardcodedList_Staff()"

    Public Shared Sub CopyElementInfo(par_intFieldIndex As Integer,
                                      par_info_base As IElement_Base,
                                      par_info_text As IElement_TextField)
        ''
        ''Added 9/15/2019 td
        ''
        Dim fieldRequested As ClassFieldStandard

        fieldRequested = ListOfFields_Students.Where(Function(x) x.FieldIndex = par_intFieldIndex).First()
        fieldRequested.Load_ByCopyingMembers(par_info_base)
        fieldRequested.Load_ByCopyingMembers(par_info_text)

    End Sub ''End of "Public Shared Sub CopyElementInfo"

    Public Shared Sub CopyElementInfo(par_enumCIBField As EnumCIBFields,
                                      par_info_base As IElement_Base,
                                      par_info_text As IElement_TextField)
        ''
        ''Added 9/16/2019 td
        ''
        Dim fieldRequested As ClassFieldStandard

        fieldRequested = ListOfFields_Students.Where(Function(x) x.FieldEnumValue = par_enumCIBField).First()
        fieldRequested.Load_ByCopyingMembers(par_info_base)
        fieldRequested.Load_ByCopyingMembers(par_info_text)

    End Sub ''End of "Public Shared Sub CopyElementInfo"

    ''9/18/2019 td''Public Sub Load_ByCopyingMembers(par_info As IElement_Base)
    ''    ''
    ''    ''Added 7/23/2019 td
    ''    ''
    ''    With par_info
    ''
    ''        Me.ElementInfo_Base.Back_Color = .Back_Color
    ''        Me.ElementInfo_Base.Back_Transparent = .Back_Transparent
    ''        Me.ElementInfo_Base.BadgeLayout = .BadgeLayout
    ''        Me.ElementInfo_Base.Border_Color = .Border_Color
    ''        Me.ElementInfo_Base.Border_Displayed = .Border_Displayed
    ''        Me.ElementInfo_Base.Border_WidthInPixels = .Border_WidthInPixels
    ''        Me.ElementInfo_Base.ElementType = .ElementType
    ''        Me.ElementInfo_Base.Height_Pixels = .Height_Pixels
    ''        Me.ElementInfo_Base.Image_BL = .Image_BL
    ''        Me.ElementInfo_Base.LeftEdge_Pixels = .LeftEdge_Pixels
    ''        Me.ElementInfo_Base.OrientationInDegrees = .OrientationInDegrees
    ''        Me.ElementInfo_Base.OrientationToLayout = .OrientationToLayout
    ''        Me.ElementInfo_Base.PositionalMode = .PositionalMode
    ''        ''Not needed.''.SelectedHighlighting
    ''        Me.ElementInfo_Base.TopEdge_Pixels = .TopEdge_Pixels
    ''        Me.ElementInfo_Base.Width_Pixels = .Width_Pixels
    ''
    ''    End With
    ''
    ''End Sub ''end of "Public Sub Load_ByCopyingMembers(par_info As IElement_Base)"

    ''9/18/2019 td''Public Sub Load_ByCopyingMembers(par_info As IElement_TextField)
    ''    ''
    ''    ''Added 9/16/2019 td
    ''    ''
    ''    With par_info
    ''
    ''        Me.ElementInfo_Text.ExampleValue = .ExampleValue
    ''        Me.ElementInfo_Text.FieldInCardData = .FieldInCardData
    ''        Me.ElementInfo_Text.FieldLabelCaption = .FieldLabelCaption
    ''        Me.ElementInfo_Text.FontBold = .FontBold
    ''        Me.ElementInfo_Text.FontColor = .FontColor
    ''        Me.ElementInfo_Text.FontFamilyName = .FontFamilyName
    ''        Me.ElementInfo_Text.FontItalics = .FontItalics
    ''        Me.ElementInfo_Text.FontOffset_X = .FontOffset_X
    ''        Me.ElementInfo_Text.FontOffset_Y = .FontOffset_Y
    ''        Me.ElementInfo_Text.FontSize_Pixels = .FontSize_Pixels
    ''        Me.ElementInfo_Text.FontSize_ScaleToElementRatio = .FontSize_ScaleToElementRatio
    ''        Me.ElementInfo_Text.FontSize_ScaleToElementYesNo = .FontSize_ScaleToElementYesNo
    ''
    ''        Me.ElementInfo_Text.FontUnderline = .FontUnderline
    ''        Me.ElementInfo_Text.Font_DrawingClass = .Font_DrawingClass
    ''        Me.ElementInfo_Text.Recipient = .Recipient
    ''        Me.ElementInfo_Text.Text = .Text
    ''        Me.ElementInfo_Text.TextAlignment = .TextAlignment
    ''
    ''    End With ''End of "With par_info"
    ''
    ''End Sub ''end of "Public Sub Load_ByCopyingMembers(par_info As IElement_TextField)"

    Public Sub Load_ByCopyingMembers(par_info As ICIBFieldStandardOrCustom)
        ''
        ''Added 7/23/2019 td
        ''
        ''NOt needed here. 9/16/2019 td''Me.ArrayOfValues = par_info.ArrayOfValues
        Me.CIBadgeField = par_info.CIBadgeField
        Me.ExampleValue = par_info.ExampleValue
        Me.FieldIndex = par_info.FieldIndex
        Me.FieldLabelCaption = par_info.FieldLabelCaption
        Me.HasPresetValues = par_info.HasPresetValues
        Me.IsAdditionalField = par_info.IsAdditionalField
        Me.IsFieldForDates = par_info.IsFieldForDates
        Me.IsLocked = par_info.IsLocked

        Me.FieldType_TD = par_info.FieldType_TD
        Me.OtherDbField_Optional = par_info.OtherDbField_Optional  ''Added 7/23/2019 td 

    End Sub ''End of "Public Sub Load_ByCopyingMembers(par_info As ICIBFieldStandardOrCustom)"

    Public Function GetValue_Recipient_String(par_enum As EnumCIBFields) As String
        ''
        ''Added 9/10/2019 td
        ''
        ''
        Return Me.ElementInfo_Text.Recipient.GetTextValue(par_enum)

    End Function ''End of "Public Function GetValue_Recipient_String(par_enum As EnumCIBFields) As String"

    Public Function GetValue_Recipient_Date(par_enum As EnumCIBFields) As Date
        ''
        ''Added 9/10/2019 td
        ''
        Return Me.ElementInfo_Text.Recipient.GetDateValue(par_enum)

    End Function ''End of "Public Function GetValue_Recipient_Date(par_enum As EnumCIBFields) As Date"

    Public Function GetValue_Recipient_TimesPrinted() As Integer
        ''
        ''Added 9/10/2019 td
        ''
        Return Me.ElementInfo_Text.Recipient.TimesPrinted()

    End Function ''End of "Public Function GetValue_Recipient_TimesPrinted(par_enum As EnumCIBFields) As Integer"




End Class
