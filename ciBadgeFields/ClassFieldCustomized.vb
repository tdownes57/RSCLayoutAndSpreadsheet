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

    ''5/7/2022 td''Public Shared ListOfFields_Students As New HashSet(Of ClassFieldCustomized)
    Public Shared ListOfFields_Staff_NotInUse As New HashSet(Of ClassFieldCustomized)
    Public Shared ListOfFields_Custom As New HashSet(Of ClassFieldCustomized)

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


    ''Public Shared Sub InitializeHardcodedList_Custom(pboolOnlyIfNeeded As Boolean,
    ''            Optional pListOfFields As HashSet(Of ClassFieldCustomized) = Nothing)
    ''
    ''    '' 5/07/2022 td''Public Shared Sub InitializeHardcodedList_Students(pboolOnlyIfNeeded As Boolean,
    ''    ''            Optional pListOfFields As HashSet(Of ClassFieldCustomized) = Nothing)
    ''    ''
    ''    ''Added 5/5/2022 & 3/23/2022 td
    ''    ''
    ''    If (pListOfFields IsNot Nothing) Then
    ''        InitializeHardcodedList_ParamList("Student", pboolOnlyIfNeeded, pListOfFields)
    ''
    ''    Else
    ''        ''5/07/2022 td''InitializeHardcodedList_ParamList("Student", pboolOnlyIfNeeded, ListOfFields_Students)
    ''        InitializeHardcodedList_ParamList("Student", pboolOnlyIfNeeded, ListOfFields_Custom)
    ''
    ''    End If ''End of "If (pListOfFields IsNot Nothing) Then .... Else..."
    ''
    ''End Sub ''End of ""Public Shared Sub InitializeHardcodedList_Custom""


    ''Public Shared Sub InitializeHardcodedList_Staff_NotInUse(pboolOnlyIfNeeded As Boolean,
    ''            Optional pListOfFields As HashSet(Of ClassFieldCustomized) = Nothing)
    ''    ''
    ''    ''Added 5/5/2022 & 3/23/2022 td
    ''    ''
    ''    If (pListOfFields IsNot Nothing) Then
    ''        InitializeHardcodedList_ParamList("Staff", pboolOnlyIfNeeded, pListOfFields)
    ''
    ''    Else
    ''        InitializeHardcodedList_ParamList("Staff", pboolOnlyIfNeeded, ListOfFields_Staff_NotInUse)
    ''
    ''    End If ''End of "If (pListOfFields IsNot Nothing) Then .... Else..."
    ''
    ''End Sub


    ''Public Shared Sub InitializeHardcodedList_ParamList(pstrRecipientClassName As String,
    ''                        pboolOnlyIfNeeded As Boolean,
    ''                        parListOfFields As HashSet(Of ClassFieldCustomized))
    ''    ''
    ''    ''Added 5/5/2022  &  3/23/2022 td
    ''    ''

    ''    ''March23 2022 td''            pboolOnlyIfNeeded As Boolean,
    ''    ''
    ''    ''Added 3/23/2022 & 7/26/2019 td
    ''    ''
    ''    ''March23 2022  Dim intFieldIndex As Integer ''Added 9/17/2019 td 
    ''    ''March23 2022  Const c_heightPixels As Integer = 30 ''Added 9/17 td
    ''    ''March23 2022  Dim intLeft_Pixels As Integer = 0
    ''    ''March23 2022  Dim intTop_Pixels As Integer = 0 ''Added 9/17/2019 td 
    ''
    ''    With parListOfFields ''March23 2022'' ListOfFields_Students
    ''        ''8/28/2019 td''If (pboolOnlyIfNeeded And .Count > 0) Then Exit Sub
    ''        If (pboolOnlyIfNeeded) Then
    ''            If (.Count > 0) Then Exit Sub
    ''        ElseIf (.Count > 0) Then
    ''            Throw New Exception("Already initialized/ has more than zero fields.")
    ''        End If
    ''    End With ''End of "With parListOfFields"
    ''
    ''    ''
    ''    ''Major call!!    Encapsulated 3/23/2022 thomas 
    ''    ''
    ''    InstantiateFields_Custom(pstrRecipientClassName)
    ''
    ''End Sub ''End of "Public Shared Sub InitializeHardcodedList_ParamList"


    Public Shared Sub InitializeHardcodedList_Students_NotInUse(pboolOnlyIfNeeded As Boolean)
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
        ''---5/3/2022 td''With ListOfFields_Students
        With ListOfFields_Custom
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

            ''Added 5/5/2022 td
            .IsRelevantToPersonality = False
            .IsDisplayedForEdits = False
            .IsDisplayedOnBadge = False

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
        ''----5/3/2022 td''ListOfFields_Students.Add(new_objectField1)
        ListOfFields_Custom.Add(new_objectField1)


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
            ''Added 5/5/2022 td
            .IsRelevantToPersonality = False
            .IsDisplayedForEdits = False
            .IsDisplayedOnBadge = False

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
        ''5/7/2022 td ''ListOfFields_Students.Add(new_objectField2)
        ListOfFields_Custom.Add(new_objectField2)


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
            ''Added 5/5/2022 td
            .IsRelevantToPersonality = False
            .IsDisplayedForEdits = False
            .IsDisplayedOnBadge = False

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
        ''5/7/2022 td''ListOfFields_Students.Add(new_objectField3)
        ListOfFields_Custom.Add(new_objectField3)


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
            ''5/5/2022 td''.IsDisplayedForEdits = True
            ''5/5/2022 td''.IsDisplayedOnBadge = True
            ''Added 5/5/2022 td
            .IsRelevantToPersonality = False
            .IsDisplayedForEdits = False
            .IsDisplayedOnBadge = False

            ''Added 9/17/2019 td
            intLeft_Pixels = (30 * (intFieldIndex - 1))
            intTop_Pixels = intLeft_Pixels ''Let's have a staircase effect!! 

            ''#1 9/17/2019 td''.ElementFieldClass = New ClassElementField(0, 0, 30)
            '' #2 9/17/2019 td''.ElementFieldClass = New ClassElementField(new_objectField61, 90, 290, 30)

            ''---(---Fields cannot link outward to elements.---9/18/2019 td
            ''--.ElementFieldClass = New ClassElementField(new_objectField61, intLeft_Pixels, intTop_Pixels, c_heightPixels)

        End With
        ''---5/3/2022 td---ListOfFields_Students.Add(new_objectField61)
        ListOfFields_Custom.Add(new_objectField61)


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
            ''Added 5/5/2022 td
            .IsRelevantToPersonality = False
            .IsDisplayedForEdits = False
            .IsDisplayedOnBadge = False

            ''Added 9/17/2019 td
            intLeft_Pixels = (30 * (intFieldIndex - 1))
            intTop_Pixels = intLeft_Pixels ''Let's have a staircase effect!! 

            ''#1 9/17/2019 td''.ElementFieldClass = New ClassElementField(0, 0, 30)
            '' #2 9/17/2019 td''.ElementFieldClass = New ClassElementField(new_objectField62, 120, 320, 30)

            ''---(---Fields cannot link outward to elements.---9/18/2019 td
            ''--.ElementFieldClass = New ClassElementField(new_objectField62, intLeft_Pixels, intTop_Pixels, c_heightPixels)

        End With
        ''5/3/2022 td ''ListOfFields_Students.Add(new_objectField62)
        ListOfFields_Custom.Add(new_objectField62)


    End Sub ''End of "InitializeHardcodedList_Students()"

    Public Shared Sub InitializeHardcodedList_Staff_NotInUse(pboolOnlyIfNeeded As Boolean)
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
        With ListOfFields_Staff_NotInUse
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
            ''Added 5/5/2022 td
            .IsRelevantToPersonality = False
            .IsDisplayedForEdits = False
            .IsDisplayedOnBadge = False

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
        ListOfFields_Staff_NotInUse.Add(new_objectField1)


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
            ''Added 5/5/2022 td
            .IsRelevantToPersonality = False
            .IsDisplayedForEdits = False
            .IsDisplayedOnBadge = False

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
        ListOfFields_Staff_NotInUse.Add(new_objectField2)


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
            ''Added 5/5/2022 td
            .IsRelevantToPersonality = False
            .IsDisplayedForEdits = False
            .IsDisplayedOnBadge = False

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
        ListOfFields_Staff_NotInUse.Add(new_objectField3)

    End Sub ''End of "InitializeHardcodedList_Staff()"


    Public Shared Function GetField_ByEnum_Custom(par_singleEnum As EnumCIBFields) As ClassFieldCustomized
        ''
        ''  5/8/2022 Public Shared Function BuildField_ByEnum_Standard
        ''
        ''Added 5/05/2022 thomas 
        ''
        Dim outputField As ClassFieldCustomized = Nothing
        Dim intMaxEnumValue As Integer = 0
        Dim each_intEnumValue As Integer = 0

        ''5/30/2022 td ''InstantiateFields_Custom("Member/Employee/Student", True, 
        ''5/30/2022 td ''    par_singleEnum, outputField, True)

        For Each each_field In GetInitializedList_Custom("Students")

            If (each_field.FieldEnumValue = par_singleEnum) Then
                Return each_field
            End If ''End of ""If (each_field.FieldEnumValue = par_singleEnum) Then""

            each_intEnumValue = CInt(each_field.FieldEnumValue)
            intMaxEnumValue = CInt(IIf(intMaxEnumValue > each_intEnumValue,
                                       intMaxEnumValue, each_intEnumValue))

        Next each_field

        Return outputField

    End Function ''End of ""Public Shared Function BuildField_ByEnum_Customized"" 


    Public Shared Function GetInitializedList_Custom(pstrRecipientClassName As String) _
                      As HashSet(Of ClassFieldCustomized)

        ''5/09/2022 td''Public Shared Function InstantiateFields_Custom(pstrRecipientClassName As String,
        ''5/09/2022 td''    Optional pboolSingleField As Boolean = False,
        ''                  Optional par_singleEnum As EnumCIBFields = EnumCIBFields.Undetermined,
        ''                  Optional ByRef pref_singleField As ClassFieldCustomized = Nothing,
        ''                  Optional pbDontSaveToList As Boolean = False) As ClassFieldCustomized
        ''
        ''Added 5/5/2022 td
        ''
        Dim objListOfFields_Custom As HashSet(Of ClassFieldCustomized) ''Added 5/9/2022 td

        Dim intFieldIndex As Integer = -1
        Dim objectEachField As ClassFieldCustomized = Nothing
        ClassFieldStandard.FieldIndexHighest = 20 ''Added 5/5/2022 td 
        Dim intFieldIndex_Min As Integer = (1 + ClassFieldStandard.FieldIndexHighest) '' (17 + 1)
        Static s_intCallCount As Integer = 0
        Dim current_enum As EnumCIBFields ''Added 5/9/2022 td
        Dim prior_enum As EnumCIBFields ''Added 5/9/2022 td

        Const c_NumCustomTextFields As Integer = 25
        Const c_NumCustomDateFields As Integer = 5

        s_intCallCount += 1 ''Added 5/5/2022 td
        ''If (s_intCallCount > 0) Then Return Nothing ''Added 5/5/2022 

        ''
        ''Part 1 of 2. Custom Text Fields 
        ''
        ''May 5, 2022''For intFieldIndex = 18 To (18 - 1 + 25)
        For intFieldIndex = intFieldIndex_Min To (intFieldIndex_Min - 1 + c_NumCustomTextFields)

            ''
            ''Date Fields
            ''
            If (prior_enum = EnumCIBFields.DateField05) Then Exit For
            If (prior_enum = EnumCIBFields.DateField04) Then current_enum = EnumCIBFields.DateField05
            If (prior_enum = EnumCIBFields.DateField03) Then current_enum = EnumCIBFields.DateField04
            If (prior_enum = EnumCIBFields.DateField02) Then current_enum = EnumCIBFields.DateField03
            If (prior_enum = EnumCIBFields.DateField01) Then current_enum = EnumCIBFields.DateField02

            ''
            ''Text Fields
            ''
            If (prior_enum = EnumCIBFields.TextField25) Then current_enum = EnumCIBFields.DateField01
            If (prior_enum = EnumCIBFields.TextField24) Then current_enum = EnumCIBFields.TextField25
            If (prior_enum = EnumCIBFields.TextField23) Then current_enum = EnumCIBFields.TextField24
            If (prior_enum = EnumCIBFields.TextField22) Then current_enum = EnumCIBFields.TextField23
            If (prior_enum = EnumCIBFields.TextField21) Then current_enum = EnumCIBFields.TextField22
            If (prior_enum = EnumCIBFields.TextField20) Then current_enum = EnumCIBFields.TextField21

            If (prior_enum = EnumCIBFields.TextField19) Then current_enum = EnumCIBFields.TextField20
            If (prior_enum = EnumCIBFields.TextField18) Then current_enum = EnumCIBFields.TextField19
            If (prior_enum = EnumCIBFields.TextField17) Then current_enum = EnumCIBFields.TextField18
            If (prior_enum = EnumCIBFields.TextField16) Then current_enum = EnumCIBFields.TextField17
            If (prior_enum = EnumCIBFields.TextField15) Then current_enum = EnumCIBFields.TextField16

            If (prior_enum = EnumCIBFields.TextField14) Then current_enum = EnumCIBFields.TextField15
            If (prior_enum = EnumCIBFields.TextField13) Then current_enum = EnumCIBFields.TextField14
            If (prior_enum = EnumCIBFields.TextField12) Then current_enum = EnumCIBFields.TextField13
            If (prior_enum = EnumCIBFields.TextField11) Then current_enum = EnumCIBFields.TextField12
            If (prior_enum = EnumCIBFields.TextField10) Then current_enum = EnumCIBFields.TextField11

            If (prior_enum = EnumCIBFields.TextField09) Then current_enum = EnumCIBFields.TextField10
            If (prior_enum = EnumCIBFields.TextField08) Then current_enum = EnumCIBFields.TextField09
            If (prior_enum = EnumCIBFields.TextField07) Then current_enum = EnumCIBFields.TextField08
            If (prior_enum = EnumCIBFields.TextField06) Then current_enum = EnumCIBFields.TextField07
            If (prior_enum = EnumCIBFields.TextField05) Then current_enum = EnumCIBFields.TextField06

            If (prior_enum = EnumCIBFields.TextField04) Then current_enum = EnumCIBFields.TextField05
            If (prior_enum = EnumCIBFields.TextField03) Then current_enum = EnumCIBFields.TextField04
            If (prior_enum = EnumCIBFields.TextField02) Then current_enum = EnumCIBFields.TextField03
            If (prior_enum = EnumCIBFields.TextField01) Then current_enum = EnumCIBFields.TextField02

            ''Major call!
            ''5/09/2022  objectEachField =
            ''        GetInstantiatedField_Custom_Text(intFieldIndex, pboolSingleField,
            ''                                      par_singleEnum, pref_singleField)
            objectEachField =
                    GetInstantiatedField_Custom_Text(intFieldIndex, current_enum)

            ''
            ''Decision Tree
            ''
            ''If (pboolSingleField And (pref_singleField IsNot Nothing)) Then
            ''    ''Add it to the list.  ---5/5/2022
            ''    ''5/3/2022 td''If (Not pbDontSaveToList) Then ListOfFields_Students.Add(pref_singleField)
            ''    If (Not pbDontSaveToList) Then objListOfFields_Custom.Add(pref_singleField)
            ''    ''Exit Sub ''Added 3/23/2022
            ''    Return pref_singleField
            ''
            ''ElseIf (pbDontSaveToList) Then
            ''    ''Don't save it to the list of fields. ---5/5/2022
            ''ElseIf (pboolSingleField) Then
            ''    ''Don't save it to the list of fields. ---5/5/2022 
            ''Else

            ''5/3/2022 td ''ListOfFields_Students.Add(objectEachField)
            objListOfFields_Custom.Add(objectEachField)

            ''End If ''End of ""If (pboolSingleField And (pref_singleField IsNot Nothing)) Then""

            ''Added 5/09/2022 thomas downs
            prior_enum = current_enum

        Next intFieldIndex

        ''If (pref_singleField IsNot Nothing) Then Exit Function
        ''5/09/2022 td ''If (pref_singleField IsNot Nothing) Then Return pref_singleField


        ''
        ''Part 2 of 2.   Date fields
        ''
        ''----For intFieldIndex = 43 to 47
        Dim intFieldIndex_Start As Integer = (intFieldIndex + 1)

        ''Prepare to call this by loop.  (Static variable is reset.)
        ''---5/09/2022 td
        ''5/09/2022 td''GetInstantiatedField_Custom_Date(-1, True)

        ''For intFieldIndex = (18 + 25) To ((18 + 25) -1 + 5)
        For intFieldIndex = (intFieldIndex_Start) To (intFieldIndex_Start - 1 + c_NumCustomDateFields)

            If (prior_enum = EnumCIBFields.DateField05) Then System.Diagnostics.Debugger.Break()
            If (prior_enum = EnumCIBFields.DateField04) Then current_enum = EnumCIBFields.DateField05
            If (prior_enum = EnumCIBFields.DateField03) Then current_enum = EnumCIBFields.DateField04
            If (prior_enum = EnumCIBFields.DateField02) Then current_enum = EnumCIBFields.DateField03
            If (prior_enum = EnumCIBFields.DateField01) Then current_enum = EnumCIBFields.DateField02
            If (prior_enum = EnumCIBFields.Undetermined) Then current_enum = EnumCIBFields.DateField01

            ''Major call!
            ''5/09/2022 td objectEachField =
            ''5/09/2022 td      InstantiateFields_Custom_Date(intFieldIndex, pboolSingleField,
            ''5/09/2022 td         par_singleEnum, pref_singleField)
            objectEachField =
                   GetInstantiatedField_Custom_Date(intFieldIndex, current_enum)

            ''
            ''Decision Tree
            ''
            ''If (pboolSingleField And (pref_singleField IsNot Nothing)) Then
            ''    ''Add it to the list.  ---5/5/2022
            ''    ''5/7/2022 td''If (Not pbDontSaveToList) Then ListOfFields_Students.Add(pref_singleField)
            ''    If (Not pbDontSaveToList) Then objListOfFields_Custom.Add(pref_singleField)
            ''    ''Exit Sub ''Added 3/23/2022
            ''    Return pref_singleField

            ''ElseIf (pbDontSaveToList) Then
            ''    ''Don't save it to the list of fields. ---5/5/2022
            ''ElseIf (pboolSingleField) Then
            ''    ''Don't save it to the list of fields. ---5/5/2022 
            ''Else
            ''5/7/2022 td ''ListOfFields_Students.Add(objectEachField)

            objListOfFields_Custom.Add(objectEachField)
            ''End If ''End of ""If (pboolSingleField And (pref_singleField IsNot Nothing)) Then""

            ''Added 5/09/2022 td
            prior_enum = current_enum

        Next intFieldIndex

        ''If (pref_singleField IsNot Nothing) Then Exit Function
        ''5/09/2022 td''If (pref_singleField IsNot Nothing) Then Return pref_singleField

ExitHandler:
        Return objListOfFields_Custom
        ''
        ''Check to see if we __still__ haven't instantiated the output. ---3/23/2022
        ''
        ''If (pboolSingleField And (pref_singleField Is Nothing)) Then
        ''    ''
        ''    ''We __still__ haven't instantiated the output.  Create the field object.
        ''    '' ---3/23/2022
        ''    ''
        ''    Dim new_objectExitHandler As New ClassFieldCustomized
        ''    With new_objectExitHandler
        ''        .FieldIndex = intFieldIndex ''Added 4/22/2020 td
        ''        .FieldEnumValue = par_singleEnum ''Added 9/16/2019 td
        ''        ''Added 3/23/2022
        ''        If (par_singleEnum = .FieldEnumValue) Then
        ''            pref_singleField = new_objectExitHandler
        ''        End If
        ''        .IsCustomizable = True ''Added 7/26/2019 td 
        ''        .FieldLabelCaption = par_singleEnum.ToString() '' "[unknown_FieldLabelCaption]"
        ''        .CIBadgeField = par_singleEnum.ToString() '' "[unknown_CIBadgeField]"
        ''        .FieldType_TD = "T"c
        ''    End With ''end of "With new_object99"

        ''    ''---If (Not pbDontSaveToList) Then _
        ''    ''---      ListOfFields_Students.Add(new_objectExitHandler)
        ''    If (Not pbDontSaveToList) Then _
        ''               objListOfFields_Custom.Add(new_objectExitHandler)
        ''    If (pboolSingleField And (pref_singleField IsNot Nothing)) Then Exit Function ''Added 3/23/2022

        ''End If ''end of "If (pboolSingleField And pref_singleField Is Nothing) Then"

        ''Return Nothing ''aDDED 5/5/2022 

    End Function ''eND OF ""Public Shared Function GetInstantiatedList_Custom""


    Private Shared Function GetInstantiatedField_Custom_Text(par_intFieldIndex As Integer,
                                          par_enumField As EnumCIBFields) As ClassFieldCustomized
        ''5/09/2022                                 Optional par_bResetStaticEnumVariable As Boolean = False) _
        ''5/09/2022                             As ClassFieldCustomized
        ''5/09/2022 Private Shared Function InstantiateFields_Custom_Text(intFieldIndex As Integer,
        ''   pboolSingleField As Boolean,
        ''   par_singleEnum As EnumCIBFields,
        ''   pref_singleField As ClassFieldCustomized) As ClassFieldCustomized
        ''
        ''Added 5/5/2022
        ''
        Dim new_objectCustomText As New ClassFieldCustomized
        ''5/09/2022 td''Dim current_enum As EnumCIBFields = EnumCIBFields.Undetermined

        With new_objectCustomText
            .FieldIndex = par_intFieldIndex ''Added 4/22/2020 td
            .FieldEnumValue = par_enumField
            ''5/9/2022  If (par_singleEnum = .FieldEnumValue) Then
            ''5/9/2022     pref_singleField = new_objectCustomText
            ''5/9/2022  End If
            .IsCustomizable = True ''Added 7/26/2019 td 
            .FieldLabelCaption = "Custom " & par_enumField.ToString() '' "[unknown_FieldLabelCaption]"
            .CIBadgeField = par_enumField.ToString() '' "[unknown_CIBadgeField]"
            .FieldType_TD = "T"c ''T = Text Field
        End With ''end of "With new_objectCustomText"

ExitHandler:
        ''5/09/2022  s_prior_enum = current_enum
        Return new_objectCustomText

        ''Static s_prior_enum As EnumCIBFields = EnumCIBFields.Undetermined
        ''''Added 5/09/2022 td
        ''If (par_bResetStaticEnumVariable) Then s_prior_enum = EnumCIBFields.Undetermined

        ''If (s_prior_enum = EnumCIBFields.TextField25) Then System.Diagnostics.Debugger.Break()
        ''If (s_prior_enum = EnumCIBFields.TextField24) Then current_enum = EnumCIBFields.TextField25
        ''If (s_prior_enum = EnumCIBFields.TextField23) Then current_enum = EnumCIBFields.TextField24
        ''If (s_prior_enum = EnumCIBFields.TextField22) Then current_enum = EnumCIBFields.TextField23
        ''If (s_prior_enum = EnumCIBFields.TextField21) Then current_enum = EnumCIBFields.TextField22
        ''If (s_prior_enum = EnumCIBFields.TextField20) Then current_enum = EnumCIBFields.TextField21
        ''If (s_prior_enum = EnumCIBFields.TextField19) Then current_enum = EnumCIBFields.TextField20
        ''If (s_prior_enum = EnumCIBFields.TextField18) Then current_enum = EnumCIBFields.TextField19
        ''If (s_prior_enum = EnumCIBFields.TextField17) Then current_enum = EnumCIBFields.TextField18
        ''If (s_prior_enum = EnumCIBFields.TextField16) Then current_enum = EnumCIBFields.TextField17
        ''If (s_prior_enum = EnumCIBFields.TextField15) Then current_enum = EnumCIBFields.TextField16
        ''If (s_prior_enum = EnumCIBFields.TextField14) Then current_enum = EnumCIBFields.TextField15
        ''If (s_prior_enum = EnumCIBFields.TextField13) Then current_enum = EnumCIBFields.TextField14
        ''If (s_prior_enum = EnumCIBFields.TextField12) Then current_enum = EnumCIBFields.TextField13
        ''If (s_prior_enum = EnumCIBFields.TextField11) Then current_enum = EnumCIBFields.TextField12
        ''If (s_prior_enum = EnumCIBFields.TextField10) Then current_enum = EnumCIBFields.TextField11
        ''If (s_prior_enum = EnumCIBFields.TextField09) Then current_enum = EnumCIBFields.TextField10
        ''If (s_prior_enum = EnumCIBFields.TextField08) Then current_enum = EnumCIBFields.TextField09
        ''If (s_prior_enum = EnumCIBFields.TextField07) Then current_enum = EnumCIBFields.TextField08
        ''If (s_prior_enum = EnumCIBFields.TextField06) Then current_enum = EnumCIBFields.TextField07
        ''If (s_prior_enum = EnumCIBFields.TextField05) Then current_enum = EnumCIBFields.TextField06
        ''If (s_prior_enum = EnumCIBFields.TextField04) Then current_enum = EnumCIBFields.TextField05
        ''If (s_prior_enum = EnumCIBFields.TextField03) Then current_enum = EnumCIBFields.TextField04
        ''If (s_prior_enum = EnumCIBFields.TextField02) Then current_enum = EnumCIBFields.TextField03
        ''If (s_prior_enum = EnumCIBFields.TextField01) Then current_enum = EnumCIBFields.TextField02
        ''If (s_prior_enum = EnumCIBFields.Undetermined) Then current_enum = EnumCIBFields.TextField01

        ''''Added 5/5/2022
        ''If (current_enum = EnumCIBFields.Undetermined) Then
        ''    System.Diagnostics.Debugger.Break()
        ''    Exit Function
        ''End If ''end of ""If (current_enum = EnumCIBFields.Undetermined) Then""


    End Function ''End of ""Private Shared Sub GetInstantiatedField_Custom_Text""


    Private Shared Function GetInstantiatedField_Custom_Date(intFieldIndex As Integer,
                                 par_currentEnumCIB As EnumCIBFields) _
                                        As ClassFieldCustomized
        ''5/09/2022 td''Private Shared Function InstantiateFields_Custom_Date(intFieldIndex As Integer,
        ''5/09/2022 td''    pboolSingleField As Boolean,
        ''5/09/2022 td''    par_singleEnum As EnumCIBFields,
        ''5/09/2022 td''    pref_singleField As ClassFieldCustomized) As ClassFieldCustomized
        ''
        ''Added 5/5/2022
        ''
        Dim new_objectCustomDate As New ClassFieldCustomized
        Dim current_enum As EnumCIBFields = EnumCIBFields.Undetermined

        Static s_prior_enum As EnumCIBFields = EnumCIBFields.Undetermined

        ''Added 5/09/2022 td
        ''If (par_bResetStaticEnumVariable) Then s_prior_enum = EnumCIBFields.Undetermined

        ''If (s_prior_enum = EnumCIBFields.DateField05) Then System.Diagnostics.Debugger.Break()
        ''If (s_prior_enum = EnumCIBFields.DateField04) Then current_enum = EnumCIBFields.DateField05
        ''If (s_prior_enum = EnumCIBFields.DateField03) Then current_enum = EnumCIBFields.DateField04
        ''If (s_prior_enum = EnumCIBFields.DateField02) Then current_enum = EnumCIBFields.DateField03
        ''If (s_prior_enum = EnumCIBFields.DateField01) Then current_enum = EnumCIBFields.DateField02
        ''If (s_prior_enum = EnumCIBFields.Undetermined) Then current_enum = EnumCIBFields.DateField01

        With new_objectCustomDate
            .FieldIndex = intFieldIndex ''Added 4/22/2020 td
            .FieldEnumValue = par_currentEnumCIB '' current_enum
            ''5/09/2022 td ''If (par_singleEnum = .FieldEnumValue) Then
            ''5/09/2022 td ''    pref_singleField = new_objectCustomDate
            ''5/09/2022 td ''End If
            .IsCustomizable = True ''Added 7/26/2019 td 
            ''5/09/2022 td''.FieldLabelCaption = "Custom " & current_enum.ToString() '' "[unknown_FieldLabelCaption]"
            .FieldLabelCaption = "Custom " & par_currentEnumCIB.ToString() '' "[unknown_FieldLabelCaption]"
            ''5/09/2022 td''.CIBadgeField = current_enum.ToString() '' "[unknown_CIBadgeField]"
            .CIBadgeField = par_currentEnumCIB.ToString() '' "[unknown_CIBadgeField]"
            .FieldType_TD = "D"c ''D = Date Field
        End With ''end of "With new_objectCustomDate"

ExitHandler:
        ''5/09/2022 td''s_prior_enum = current_enum
        Return new_objectCustomDate

    End Function ''End of ""Private Shared Sub InstantiateFields_Custom_Date""



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

        ''Added 5/5/2022 thomas downes
        Me.IsRelevantToPersonality = par_objectClass.IsRelevantToPersonality

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
