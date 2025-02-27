﻿Option Explicit On
Option Strict On

Imports ciLayoutDesignVB
Imports ciBadgeInterfaces ''Added 8/24/2019 thomas d.

''
''Added 7/16/2019 thomas downes  
''

Public Class ClassFieldCustomized
    Inherits ClassFieldAny ''Added 9/16/2019 thomas d. 
    ''9/16/2019 td''Implements ICIBFieldStandardOrCustom ''Added 7/21/2019 td
    ''
    ''Added 7/16/2019 thomas d. 
    ''
    ''Public TextFieldId As Integer
    ''Public Property TextFieldId As Integer = 1

    ''Public Property IsStandard As Boolean = False Implements ICIBFieldStandardOrCustom.IsStandard ''Added 7/26/2019 td
    ''Public Property IsCustomizable As Boolean = False Implements ICIBFieldStandardOrCustom.IsCustomizable ''Added 7/26/2019 td

    ''Public Property DateFieldId As Integer = 0
    ''Public Property IsDateField As Boolean = False

    ''''Added 8/23/2019 thomas d. 
    ''Public Property IsDisplayedOnBadge As Boolean = False Implements ICIBFieldStandardOrCustom.IsDisplayedOnBadge
    ''Public Property IsDisplayedForEdits As Boolean = False Implements ICIBFieldStandardOrCustom.IsDisplayedForEdits

    ''Public Property Text_orDate As String = "Text"

    ''Public Property LabelCaption As String = ""

    ''''Redundant. See ExampleValue. ---7/26/2019 td''Public Property ExampleValueToUseInLayout As String = ""

    ''''7/21 td''Public Property CIBadgeFieldname As String ''Added 7/21/2019 Thomas DOWNES 
    ''Public Property CIBadgeField_Optional As String Implements ICIBFieldStandardOrCustom.CIBadgeField_Optional ''Added 7/21/2019 Thomas DOWNES 
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

    ''Public Property ArrayOfValues As String() Implements ICIBFieldStandardOrCustom.ArrayOfValues
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

    ''Public Property IsBarcodeField As Boolean Implements ICIBFieldStandardOrCustom.IsBarcodeField ''Added 7/31/2019 thomas downes

    ''Public Property DataEntryText As String Implements ICIBFieldStandardOrCustom.DataEntryText ''Added 9/9/2019 td

    ''
    ''Added 7/29/2019 thomas downes
    ''
    ''9/3/2019 td''Public Property ElementInfo As ClassElementText
    ''Public Property ElementFieldClass() As ClassElementField
    ''    '' 9/16/2019 td'' Public Property ElementInfo() As ClassElementField
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

    ''8/27/2019 td''Public Property Image_BL As Image Implements ICIBFieldStandardOrCustom.Image_BL ''Added 8/27/2019 

    ''#1 9/16 td''Private mod_elementInfo As ClassElementField ''Added 9/3/2019 td   
    '' #2 9/16 td''Private mod_elementFieldClass As ClassElementField ''Added 9/3/2019 td   

    Private mod_arrayOfListItems() As String ''Added 9/17/2019 td  

    ''
    ''Added 7/16/2019 thomas d. 
    ''
    Public Shared ListOfFields_Students As New List(Of ClassFieldCustomized)
    Public Shared ListOfFields_Staff As New List(Of ClassFieldCustomized)

    ''9/18/2019 td''Public Shared Function ListOfElementsText_Custom(Optional par_intLayoutWidth As Integer = 0) As List(Of IFieldInfo_ElementPositions)
    ''    ''9/4/2019 td''Public Shared Function ListOfElementsText_Custom() As List(Of IElementWithText)
    ''    ''
    ''    ''Added 8/24/2019 Thomas D.  
    ''    ''
    ''    Dim obj_listOutput As New List(Of IFieldInfo_ElementPositions)
    ''
    ''    For Each each_obj In ListOfFields_Students
    ''
    ''        Dim new_ElementWithText As New IFieldInfo_ElementPositions
    ''        Dim obj_ElementText As IElement_TextField
    ''        Dim obj_Element_Base As IElement_Base
    ''
    ''        new_ElementWithText.FieldInfo = each_obj ''Added 9/3/2019 td  
    ''
    ''        obj_ElementText = CType(each_obj.ElementFieldClass, IElement_TextField)
    ''        obj_Element_Base = CType(each_obj.ElementFieldClass, IElement_Base)
    ''
    ''        new_ElementWithText.Position_BL = obj_Element_Base
    ''        new_ElementWithText.TextDisplay = obj_ElementText
    ''
    ''        ''Added 9/4/2019 td
    ''        new_ElementWithText.BadgeLayout_Width = par_intLayoutWidth
    ''        ''9/12/2019 td''new_ElementWithText.Position_BL.LayoutWidth_Pixels = par_intLayoutWidth
    ''        new_ElementWithText.Position_BL.BadgeLayout.Width_Pixels = par_intLayoutWidth
    ''
    ''        obj_listOutput.Add(new_ElementWithText)
    ''
    ''    Next each_obj
    ''
    ''    Return obj_listOutput
    ''
    ''End Function ''eND OF Public Shared Function ListOfElementsText_Custom()  

    Public Shared Sub InitializeHardcodedList_Students(pboolOnlyIfNeeded As Boolean)
        ''
        ''Stubbed 7/16/2019 td
        ''
        ''  Add Schoolname, Teacher name, Grade. 
        ''
        ''Dim intIndex As Integer ''= 1 To 3
        Dim intFieldIndex As Integer ''Added 9/17/2019 td 
        Const c_heightPixels As Integer = 30 ''Added 9/17 td
        Dim intLeft_Pixels As Integer = 0
        Dim intTop_Pixels As Integer = 0 ''Added 9/17/2019 td 

        ''For intIndex = 1 To 3

        ''Added 7/23/2019 thomas
        With ListOfFields_Students
            If (pboolOnlyIfNeeded And .Count > 0) Then Exit Sub
        End With


        intFieldIndex = 1 ''Added 9/17/2019 td
        Dim new_objectField1 As New ClassFieldCustomized
        With new_objectField1
            .FieldEnumValue = EnumCIBFields.TextField01
            ''9/16/2019 td''.TextFieldId = 1 ''TextField01 
            .IsCustomizable = True ''Added 7/26/2019 td 
            .FieldLabelCaption = "School Name"
            ''9/16/2019 td''.CIBadgeField_Optional = "" ''Optional. 
            .CIBadgeField = "TextField01" ''Optional. 
            .FieldType_TD = "T"c
            .HasPresetValues = True
            .IsAdditionalField = False
            ''.IsDateField = False
            .IsFieldForDates = False
            .ExampleValue = "Willcrest School"
            .ArrayOfValues = New String() {"Willcrest School", "Woodbridge School"}

            ''Added 9/17/2019 td
            ''9/18/2019 td''intLeft_Pixels = (30 * (intFieldIndex - 1))
            intLeft_Pixels = (c_heightPixels * (intFieldIndex - 1))
            intTop_Pixels = intLeft_Pixels ''Let's have a staircase effect!! 

            ''Added 9/3/2019 td
            ''9/16/2019 td''.ElementFieldClass = New ClassElementField()
            ''#1 9/17/2019 td''.ElementFieldClass = New ClassElementField(0, 0, 30)
            '' #2 9/17/2019 td''.ElementFieldClass = New ClassElementField(new_objectField1, 0, 200, 30)
            ''---(---Fields cannot link outward to elements.---9/18/2019 td
            ''---(-.ElementFieldClass = New ClassElementField(new_objectField1, intLeft_Pixels, intTop_Pixels, c_heightPixels)

        End With
        ListOfFields_Students.Add(new_objectField1)


        intFieldIndex = 2 ''Added 9/17/2019 td
        Dim new_objectField2 As New ClassFieldCustomized
        With new_objectField2
            .FieldEnumValue = EnumCIBFields.TextField02
            ''9/16/2019 td''.TextFieldId = 2 ''TextField02
            .IsCustomizable = True ''Added 7/26/2019 td 
            .FieldLabelCaption = "Teacher Name"
            .CIBadgeField = "TextField02" ''Optional. 
            .FieldType_TD = "T"c
            .HasPresetValues = True
            .IsAdditionalField = False
            ''.IsDateField = False
            .IsFieldForDates = False
            .ArrayOfValues = New String() {"Mrs. Ross", "Mr. Smudge", "Ms. Randall"}

            ''Added 9/17/2019 td
            intLeft_Pixels = (30 * (intFieldIndex - 1))
            intTop_Pixels = intLeft_Pixels ''Let's have a staircase effect!! 

            ''Added 9/3/2019 td
            ''9/16/2019 td''.ElementFieldClass = New ClassElementField()
            ''#1 9/17/2019 td''.ElementFieldClass = New ClassElementField(0, 0, 30)
            '' #2 9/17/2019 td''.ElementFieldClass = New ClassElementField(new_objectField2, 30, 230, 30)

            ''---(---Fields cannot link outward to elements.---9/18/2019 td
            ''---(-.ElementFieldClass = New ClassElementField(new_objectField2, intLeft_Pixels, intTop_Pixels, c_heightPixels)

        End With
        ListOfFields_Students.Add(new_objectField2)


        intFieldIndex = 3 ''Added 9/17/2019 td
        Dim new_objectField3 As New ClassFieldCustomized
        With new_objectField3
            .FieldEnumValue = EnumCIBFields.TextField03
            ''9/16/2019 td''.TextFieldId = 3 ''TextField03 
            .IsCustomizable = True ''Added 7/26/2019 td 
            .FieldLabelCaption = "Grade Level"
            .CIBadgeField = "TextField03" ''Optional. 
            .FieldType_TD = "T"c
            .HasPresetValues = True
            .IsAdditionalField = False
            ''.IsDateField = False
            .IsFieldForDates = False
            .ArrayOfValues = New String() {"9th", "10th", "11th", "12th"}

            ''Added 9/17/2019 td
            intLeft_Pixels = (30 * (intFieldIndex - 1))
            intTop_Pixels = intLeft_Pixels ''Let's have a staircase effect!! 

            ''Added 9/3/2019 td
            ''9/16/2019 td''.ElementFieldClass = New ClassElementField()
            ''#1 9/17/2019 td''.ElementFieldClass = New ClassElementField(0, 0, 30)
            '' #2 9/17/2019 td''.ElementFieldClass = New ClassElementField(new_objectField3, 60, 260, 30)

            ''---(---Fields cannot link outward to elements.---9/18/2019 td
            ''.ElementFieldClass = New ClassElementField(new_objectField3, intLeft_Pixels, intTop_Pixels, c_heightPixels)

        End With
        ListOfFields_Students.Add(new_objectField3)


        ''Added 9/16/2019 td
        intFieldIndex = 4 ''Added 9/17/2019 td
        Dim new_objectField61 As New ClassFieldCustomized
        With new_objectField61
            .FieldEnumValue = EnumCIBFields.DateField01
            .IsCustomizable = True ''Added 7/26/2019 td 
            .FieldLabelCaption = "Date of Birth"
            .CIBadgeField = "DateField01" ''Optional. 
            .FieldType_TD = "D"c
            .HasPresetValues = False
            .IsAdditionalField = False
            .IsFieldForDates = True
            .IsDisplayedForEdits = True
            .IsDisplayedOnBadge = True

            ''Added 9/17/2019 td
            intLeft_Pixels = (30 * (intFieldIndex - 1))
            intTop_Pixels = intLeft_Pixels ''Let's have a staircase effect!! 

            ''#1 9/17/2019 td''.ElementFieldClass = New ClassElementField(0, 0, 30)
            '' #2 9/17/2019 td''.ElementFieldClass = New ClassElementField(new_objectField61, 90, 290, 30)

            ''---(---Fields cannot link outward to elements.---9/18/2019 td
            ''--.ElementFieldClass = New ClassElementField(new_objectField61, intLeft_Pixels, intTop_Pixels, c_heightPixels)

        End With
        ListOfFields_Students.Add(new_objectField61)


        ''Added 9/16/2019 td
        Dim new_objectField62 As New ClassFieldCustomized
        With new_objectField62
            .FieldEnumValue = EnumCIBFields.DateField02
            .IsCustomizable = True
            .FieldLabelCaption = "ExpirationDate"
            .CIBadgeField = "DateField02" ''Optional. 
            .FieldType_TD = "D"c
            .HasPresetValues = False
            .IsAdditionalField = False
            .IsFieldForDates = True

            ''Added 9/17/2019 td
            intLeft_Pixels = (30 * (intFieldIndex - 1))
            intTop_Pixels = intLeft_Pixels ''Let's have a staircase effect!! 

            ''#1 9/17/2019 td''.ElementFieldClass = New ClassElementField(0, 0, 30)
            '' #2 9/17/2019 td''.ElementFieldClass = New ClassElementField(new_objectField62, 120, 320, 30)

            ''---(---Fields cannot link outward to elements.---9/18/2019 td
            ''--.ElementFieldClass = New ClassElementField(new_objectField62, intLeft_Pixels, intTop_Pixels, c_heightPixels)

        End With
        ListOfFields_Students.Add(new_objectField62)


    End Sub ''End of "InitializeHardcodedList_Students()"

    Public Shared Sub InitializeHardcodedList_Staff(pboolOnlyIfNeeded As Boolean)
        ''
        ''Stubbed 7/16/2019 td
        ''
        ''  Add Schoolname, Job Title, GradeLevel (if applicable). 
        ''
        Dim intFieldIndex As Integer = 0 ''Added 9/17/2019 td
        Const c_heightPixels As Integer = 30 ''Added 9/17 td
        Dim intLeft_Pixels As Integer = 0
        Dim intTop_Pixels As Integer = 0 ''Added 9/17/2019 td 

        ''Added 7/23/2019 thomas
        With ListOfFields_Staff
            If (pboolOnlyIfNeeded And .Count > 0) Then Exit Sub
        End With


        intFieldIndex = 1 ''Added 9/17
        Dim new_objectField1 As New ClassFieldCustomized
        With new_objectField1
            .FieldEnumValue = EnumCIBFields.TextField01
            ''9/16/2019 td''.TextFieldId = 1 ''TextField01 
            .IsCustomizable = True ''Added 7/26/2019 td 
            .FieldLabelCaption = "School Name"
            .CIBadgeField = "TextField01" ''Optional. 
            .FieldType_TD = "T"c
            .HasPresetValues = True
            .IsAdditionalField = False
            ''.IsDateField = False
            .IsFieldForDates = False
            .ExampleValue = "Willcrest School"
            .ArrayOfValues = New String() {"Willcrest School", "Woodbridge School"}

            ''Added 9/17/2019 td
            ''9/18/2019 td''intLeft_Pixels = (30 * (intFieldIndex - 1))
            intTop_Pixels = (c_heightPixels * (intFieldIndex - 1))
            intLeft_Pixels = intTop_Pixels ''Let's have a staircase effect!! 

            ''Added 9/3/2019 td
            ''9/16/2019 td''.ElementFieldClass = New ClassElementField()
            ''9/16/2019 td''.ElementFieldClass = New ClassElementField(0, 0, 30)
            ''#2 9/17/2019 td''.ElementFieldClass = New ClassElementField(new_objectField1, 0, 0, 30)

            ''---(---Fields cannot link outward to elements.---9/18/2019 td
            ''--.ElementFieldClass = New ClassElementField(new_objectField1, intLeft_Pixels, intTop_Pixels, c_heightPixels)

        End With
        ListOfFields_Staff.Add(new_objectField1)


        intFieldIndex = 2 ''Added 9/17
        Dim new_objectField2 As New ClassFieldCustomized
        With new_objectField2
            .FieldEnumValue = EnumCIBFields.TextField02
            ''9/16/2019 td''.TextFieldId = 2 ''TextField02 
            .IsCustomizable = True ''Added 7/26/2019 td 
            .FieldLabelCaption = "Job Title"
            .CIBadgeField = "TextField02" ''Optional. 
            .FieldType_TD = "T"c
            .HasPresetValues = True
            .IsAdditionalField = False
            ''.IsDateField = False
            .IsFieldForDates = False
            .ArrayOfValues = New String() {"Teacher", "Custodian", "Security", "Admin"}

            ''Added 9/17/2019 td
            intLeft_Pixels = (30 * (intFieldIndex - 1))
            intTop_Pixels = intLeft_Pixels ''Let's have a staircase effect!! 

            ''Added 9/3/2019 td
            ''9/16/2019 td''.ElementFieldClass = New ClassElementField()
            ''#1 9/17/2019 td''.ElementFieldClass = New ClassElementField(0, 0, 30)
            '' #2 9/17/2019 td''.ElementFieldClass = New ClassElementField(new_objectField2, 0, 0, 30)

            ''---(---Fields cannot link outward to elements.---9/18/2019 td
            ''--.ElementFieldClass = New ClassElementField(new_objectField2, intLeft_Pixels, intTop_Pixels, c_heightPixels)

        End With
        ListOfFields_Staff.Add(new_objectField2)


        intFieldIndex = 3 ''Added 9/17
        Dim new_objectField3 As New ClassFieldCustomized
        With new_objectField3
            .FieldEnumValue = EnumCIBFields.TextField03
            ''9/16/2019 td''.TextFieldId = 3 ''TextField03 
            .IsCustomizable = True ''Added 7/26/2019 td 
            .FieldLabelCaption = "Grade Level If Applicable"
            .CIBadgeField = "TextField03" ''Optional. 
            .FieldType_TD = "T"c
            .HasPresetValues = True
            .IsAdditionalField = False
            ''.IsDateField = False
            .IsFieldForDates = False
            .ArrayOfValues = New String() {"9th", "10th", "11th", "12th"}

            ''Added 9/17/2019 td
            intLeft_Pixels = (30 * (intFieldIndex - 1))
            intTop_Pixels = intLeft_Pixels ''Let's have a staircase effect!! 

            ''Added 9/3/2019 td
            ''9/16/2019 td''.ElementFieldClass = New ClassElementField()
            ''#1 9/17/2019 td''.ElementFieldClass = New ClassElementField(0, 0, 30)
            '' #2 9/17/2019 td''.ElementFieldClass = New ClassElementField(new_objectField3, 0, 0, 30)

            ''---(---Fields cannot link outward to elements.---9/18/2019 td
            ''--.ElementFieldClass = New ClassElementField(new_objectField3, intLeft_Pixels, intTop_Pixels, c_heightPixels)

        End With
        ListOfFields_Staff.Add(new_objectField3)

    End Sub ''End of "InitializeHardcodedList_Staff()"

    ''9/18/2019 td''Public Shared Sub CopyElementInfo(par_enumCIBField As EnumCIBFields,
    ''                                  par_info_base As IElement_Base,
    ''                                  par_info_text As IElement_TextField)
    ''    ''
    ''    ''Added 9/16/2019 td
    ''    ''
    ''    Dim fieldRequested As ClassFieldCustomized

    ''    fieldRequested = ListOfFields_Students.Where(Function(x) x.FieldEnumValue = par_enumCIBField).First()
    ''    fieldRequested.Load_ByCopyingMembers(par_info_base)
    ''    fieldRequested.Load_ByCopyingMembers(par_info_text)

    ''End Sub ''End of "Public Shared Sub CopyElementInfo"

    Public Property ArrayOfValues As String() ''Implements ICIBFieldStandardOrCustom.ArrayOfValues
        Get
            ''9/18/2019 td''Throw New NotImplementedException()
            Return mod_arrayOfListItems
        End Get
        Set(value As String())
            ''9/18/2019 td''Throw New NotImplementedException()
            mod_arrayOfListItems = value
        End Set
    End Property

    ''9/18/2019 td''Public Sub Load_ByCopyingMembers(par_info As IElement_Base)
    ''    ''
    ''    ''Added 7/23/2019 td
    ''    ''
    ''    With par_info

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

    ''    End With

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
        ''9/16/2019 td''Me.ArrayOfValues = par_info.ArrayOfValues

        Me.CIBadgeField = par_info.CIBadgeField
        Me.DataEntryText = par_info.DataEntryText

        ''Added 9/13/2019 td
        ''Fields cannot link outward to elements.---9/18/2019 td''Dim objElementText As New ClassElementField ''Added 9/13 td
        ''Fields cannot link outward to elements.---9/18/2019 td''Me.ElementFieldClass = objElementText ''Added 9/13/2019 td
        ''Fields cannot link outward to elements.---9/18/2019 td''Me.ElementFieldClass.LoadbyCopyingMembers(par_info.ElementInfo_Base,
        ''     par_info.ElementInfo_Text)

        Me.ExampleValue = par_info.ExampleValue
        Me.FieldIndex = par_info.FieldIndex
        Me.FieldLabelCaption = par_info.FieldLabelCaption
        Me.FieldType_TD = par_info.FieldType_TD
        Me.HasPresetValues = par_info.HasPresetValues
        Me.IsAdditionalField = par_info.IsAdditionalField
        Me.IsCustomizable = par_info.IsCustomizable
        Me.IsDisplayedForEdits = par_info.IsDisplayedForEdits
        Me.IsDisplayedOnBadge = par_info.IsDisplayedOnBadge
        Me.IsFieldForDates = par_info.IsFieldForDates
        Me.IsLocked = par_info.IsLocked
        Me.IsStandard = par_info.IsStandard

        Me.OtherDbField_Optional = par_info.OtherDbField_Optional  ''Added 7/23/2019 td 

    End Sub ''End of "Public Sub Load_ByCopyingMembers(par_info As ICIBFieldStandardOrCustom)"

    ''9/18/2019 td''Public Function GetValue_Recipient_String(par_enum As EnumCIBFields) As String
    ''    ''
    ''    ''Added 9/10/2019 td
    ''    ''
    ''    ''
    ''    Return Me.ElementInfo_Text.Recipient.GetTextValue(par_enum)
    ''
    ''End Function ''End of "Public Function GetValue_Recipient_String(par_enum As EnumCIBFields) As String"

    ''9/18/2019 td''Public Function GetValue_Recipient_Date(par_enum As EnumCIBFields) As Date
    ''    ''
    ''    ''Added 9/10/2019 td
    ''    ''
    ''    Return Me.ElementInfo_Text.Recipient.GetDateValue(par_enum)
    ''
    ''End Function ''End of "Public Function GetValue_Recipient_Date(par_enum As EnumCIBFields) As Date"

    ''9/18/2019 td''Public Function GetValue_Recipient_TimesPrinted() As Integer
    ''    ''
    ''    ''Added 9/10/2019 td
    ''    ''
    ''    Return Me.ElementInfo_Text.Recipient.TimesPrinted()
    ''
    ''End Function ''End of "Public Function GetValue_Recipient_TimesPrinted(par_enum As EnumCIBFields) As Integer"

    Public Shared Function Javascript() As String ''----(par_personality As IPersonality) As String
        ''
        ''Added 9/13/2019 td  
        ''
        Dim stringbldrJavascript As New System.Text.StringBuilder(700)
        ''9/18/2019 td''Dim each_field As ClassFieldStandard

        ''---Fields cannot link outward to elements.---9/18/2019 td
        ''---9/18/2019 td''For Each each_field In ClassFieldStandard.ListOfFields_Students
        ''
        ''    With stringbldrJavascript
        ''
        ''        .AppendLine("ctl_" + each_field.CIBadgeField +
        ''                    ".Left = " + each_field.ElementInfo_Base.LeftEdge_Pixels.ToString() + " ; ")
        ''
        ''    End With
        ''
        ''Next each_field

        Return ""

    End Function ''End of "Public Shared Functionn Javascript() As String"

End Class
