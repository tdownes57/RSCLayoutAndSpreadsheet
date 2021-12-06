Option Explicit On
Option Strict On

''9/19/2019 td''Imports ciLayoutDesignVB
Imports ciBadgeInterfaces ''Added 8/24/2019 thomas d.

''
''Added 7/16/2019 thomas downes  
''
<Serializable>
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
    ''--Dec.5 2021--Public Shared ListOfFields_Students As New List(Of ClassFieldCustomized)
    ''--Dec.5 2021--Public Shared ListOfFields_Staff As New List(Of ClassFieldCustomized)

    Public Shared ListOfFields_Students As New HashSet(Of ClassFieldCustomized)
    Public Shared ListOfFields_Staff As New HashSet(Of ClassFieldCustomized)

    Public Sub New()
        ''
        ''Added 4/22/2020 thomas downes
        ''
        Me.FieldIndex = ClassFieldAny.LastUsedFieldIndex
        ClassFieldAny.LastUsedFieldIndex += 1

    End Sub

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


        intFieldIndex = 201 ''Added 9/17/2019 td
        Dim new_objectField1 As New ClassFieldCustomized
        With new_objectField1

            .FieldIndex = intFieldIndex ''Added 4/22/2020 td

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


        intFieldIndex = 202 ''Added 9/17/2019 td
        Dim new_objectField2 As New ClassFieldCustomized
        With new_objectField2

            .FieldIndex = intFieldIndex ''Added 4/22/2020 td

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


        intFieldIndex = 203 ''Added 9/17/2019 td
        Dim new_objectField3 As New ClassFieldCustomized
        With new_objectField3

            .FieldIndex = intFieldIndex ''Added 4/22/2020 td

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
        intFieldIndex = 204 ''Added 9/17/2019 td
        Dim new_objectField61 As New ClassFieldCustomized
        With new_objectField61

            .FieldIndex = intFieldIndex ''Added 4/22/2020 td

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
        intFieldIndex = 205 ''Added 4/22/2020 td
        Dim new_objectField62 As New ClassFieldCustomized
        With new_objectField62

            .FieldIndex = intFieldIndex ''Added 4/22/2020 td

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


        intFieldIndex = 301 ''Added 9/17
        Dim new_objectField1 As New ClassFieldCustomized
        With new_objectField1

            .FieldIndex = intFieldIndex ''Added 4/22/2020 td

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


        intFieldIndex = 302 ''Added 9/17
        Dim new_objectField2 As New ClassFieldCustomized
        With new_objectField2

            .FieldIndex = intFieldIndex ''Added 4/22/2020 td

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


        intFieldIndex = 303 ''Added 9/17
        Dim new_objectField3 As New ClassFieldCustomized
        With new_objectField3

            .FieldIndex = intFieldIndex ''Added 4/22/2020 td

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

        ''Added 12/5/2021 thomas downes
        Me.IsRelevantToPersonality = par_info.IsRelevantToPersonality
        Me.DateEdited = par_info.DateEdited
        Me.DateSaved = par_info.DateSaved

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

    Public Function Copy_FieldCustom() As ClassFieldCustomized
        ''
        ''Added 10/14/2019 
        ''
        Dim objCopy_Cust As New ClassFieldCustomized

        ''9/30/2019 td''objCopy.LoadbyCopyingMembers(Me, Me)
        ''10/14/2019 td''objCopy_Cust.LoadbyCopyingMembers(CType(Me, ICIBFieldStandardOrCustom))

        objCopy_Cust.LoadbyCopyingMembers_Custom(Me)

        Return objCopy_Cust

    End Function ''End of "Public Function Copy_FieldCustom() As ClassFieldCustomized"

    Public Sub LoadbyCopyingMembers_Custom(par_objectClass As ClassFieldCustomized)
        ''
        ''Added 10/14 & 9/30/2019 thomas downes
        ''
        ''--------------------------------------------------------------------------
        ''Step 1 of 1 -- Field-related properties.
        ''--------------------------------------------------------------------------
        ''
        Me.CIBadgeField = par_objectClass.CIBadgeField
        Me.DataEntryText = par_objectClass.DataEntryText
        Me.ExampleValue = par_objectClass.ExampleValue

        ''Added 9/30/2019 thomas downes
        Me.FieldEnumValue = par_objectClass.FieldEnumValue
        Me.FieldIndex = par_objectClass.FieldIndex
        Me.FieldLabelCaption = par_objectClass.FieldLabelCaption
        Me.FieldType_TD = par_objectClass.FieldType_TD
        Me.HasPresetValues = par_objectClass.HasPresetValues
        Me.IsAdditionalField = par_objectClass.IsAdditionalField
        Me.IsBarCode = par_objectClass.IsBarCode
        Me.IsCustomizable = par_objectClass.IsCustomizable

        ''Added 10/01/2019 thomas downes
        Me.IsDateField = par_objectClass.IsDateField
        Me.IsDisplayedForEdits = par_objectClass.IsDisplayedForEdits
        Me.IsDisplayedOnBadge = par_objectClass.IsDisplayedOnBadge
        Me.IsFieldForDates = par_objectClass.IsFieldForDates
        Me.IsLinkedToSections = par_objectClass.IsLinkedToSections
        Me.IsLocked = par_objectClass.IsLocked
        Me.IsStandard = par_objectClass.IsStandard
        Me.OtherDbField_Optional = par_objectClass.OtherDbField_Optional
        Me.SublayoutLookup = par_objectClass.SublayoutLookup
        Me.Text_orDate = par_objectClass.Text_orDate

        ''Added 12/5/2021 thomas downes
        Me.IsRelevantToPersonality = par_objectClass.IsRelevantToPersonality
        Me.DateSaved = par_objectClass.DateSaved

        ''Added 10/14/2019 thomas downes
        ''
        ''  This is the only member which is unique to this class. 
        ''
        Me.ArrayOfValues = par_objectClass.ArrayOfValues

        ''Added 9/30/2019 thomas downes
        ''10/01/2019 td''Throw New NotImplementedException("Not all the members are programmed yet (i.e. the commands for copying their values haven't been written yet).")

    End Sub ''End of "Public Sub LoadbyCopyingMembers(par_ElementInfo_Base As IElement_Base, .....)"



End Class
