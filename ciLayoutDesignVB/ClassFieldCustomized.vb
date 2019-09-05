Option Explicit On
Option Strict On

Imports ciLayoutDesignVB
Imports ciBadgeInterfaces ''Added 8/24/2019 thomas d.

''
''Added 7/16/2019 thomas downes  
''

Public Class ClassFieldCustomized
    Implements ICIBFieldStandardOrCustom ''Added 7/21/2019 td
    ''
    ''Added 7/16/2019 thomas d. 
    ''
    ''Public TextFieldId As Integer
    Public Property TextFieldId As Integer = 1

    Public Property IsStandard As Boolean = False Implements ICIBFieldStandardOrCustom.IsStandard ''Added 7/26/2019 td
    Public Property IsCustomizable As Boolean = False Implements ICIBFieldStandardOrCustom.IsCustomizable ''Added 7/26/2019 td

    Public Property DateFieldId As Integer = 0
    Public Property IsDateField As Boolean = False

    ''Added 8/23/2019 thomas d. 
    Public Property IsDisplayedOnBadge As Boolean = False Implements ICIBFieldStandardOrCustom.IsDisplayedOnBadge
    Public Property IsDisplayedForEdits As Boolean = False Implements ICIBFieldStandardOrCustom.IsDisplayedForEdits

    Public Property Text_orDate As String = "Text"

    Public Property LabelCaption As String = ""

    ''Redundant. See ExampleValue. ---7/26/2019 td''Public Property ExampleValueToUseInLayout As String = ""

    ''7/21 td''Public Property CIBadgeFieldname As String ''Added 7/21/2019 Thomas DOWNES 
    Public Property CIBadgeField_Optional As String Implements ICIBFieldStandardOrCustom.CIBadgeField_Optional ''Added 7/21/2019 Thomas DOWNES 
    Public Property OtherDbField_Optional As String Implements ICIBFieldStandardOrCustom.OtherDbField_Optional ''Added 7/21/2019 Thomas DOWNES 

    Public Property FieldLabelCaption As String Implements ICIBFieldStandardOrCustom.FieldLabelCaption
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As String)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property FieldType_TD As Char Implements ICIBFieldStandardOrCustom.FieldType_TD
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As Char)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property FieldIndex As Integer Implements ICIBFieldStandardOrCustom.FieldIndex
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As Integer)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property IsFieldForDates As Boolean Implements ICIBFieldStandardOrCustom.IsFieldForDates
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As Boolean)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property IsLocked As Boolean Implements ICIBFieldStandardOrCustom.IsLocked
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As Boolean)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property ExampleValue As String Implements ICIBFieldStandardOrCustom.ExampleValue
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As String)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property HasPresetValues As Boolean Implements ICIBFieldStandardOrCustom.HasPresetValues
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As Boolean)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property ArrayOfValues As String() Implements ICIBFieldStandardOrCustom.ArrayOfValues
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As String())
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    ''Public Property OtherDbFieldname As String Implements ICIBFieldStandardOrCustom.OtherDbField_Optional
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As String)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property IsAdditionalField As Boolean Implements ICIBFieldStandardOrCustom.IsAdditionalField
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As Boolean)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property IsBarcodeField As Boolean Implements ICIBFieldStandardOrCustom.IsBarcodeField

    ''
    ''Added 7/29/2019 thomas downes
    ''
    ''9/3/2019 td''Public Property ElementInfo As ClassElementText
    Public Property ElementInfo() As ClassElementText
        Get
            ''Added 9/3/2019 thomas d. 
            Return mod_elementInfo
        End Get
        Set(value As ClassElementText)
            ''Added 9/3/2019 thomas d. 
            mod_elementInfo = value
            ''Added 9/3/2019 thomas d. 
            Me.ElementInfo_Base = CType(value, IElement_Base)
            Me.ElementInfo_Text = CType(value, IElement_Text)
        End Set
    End Property

    ''Added 9/3/2019 td
    Public Property ElementInfo_Base As IElement_Base Implements ICIBFieldStandardOrCustom.ElementInfo_Base
    ''Added 9/3/2019 td
    Public Property ElementInfo_Text As IElement_Text Implements ICIBFieldStandardOrCustom.ElementInfo_Text

    ''8/27/2019 td''Public Property Image_BL As Image Implements ICIBFieldStandardOrCustom.Image_BL ''Added 8/27/2019 

    Private mod_elementInfo As ClassElementText ''Added 9/3/2019 td   

    ''
    ''Added 7/16/2019 thomas d. 
    ''
    Public Shared ListOfFields_Students As New List(Of ClassFieldCustomized)
    Public Shared ListOfFields_Staff As New List(Of ClassFieldCustomized)

    Public Shared Function ListOfElementsText_Custom(Optional par_intLayoutWidth As Integer = 0) As List(Of IElementWithText)
        ''9/4/2019 td''Public Shared Function ListOfElementsText_Custom() As List(Of IElementWithText)
        ''
        ''Added 8/24/2019 Thomas D.  
        ''
        Dim obj_listOutput As New List(Of IElementWithText)

        For Each each_obj In ListOfFields_Students

            Dim new_ElementWithText As New IElementWithText
            Dim obj_ElementText As IElement_Text
            Dim obj_Element_Base As IElement_Base

            new_ElementWithText.FieldInfo = each_obj ''Added 9/3/2019 td  

            obj_ElementText = CType(each_obj.ElementInfo, IElement_Text)
            obj_Element_Base = CType(each_obj.ElementInfo, IElement_Base)

            new_ElementWithText.Position_BL = obj_Element_Base
            new_ElementWithText.TextDisplay = obj_ElementText

            ''Added 9/4/2019 td
            new_ElementWithText.BadgeLayout_Width = par_intLayoutWidth
            new_ElementWithText.Position_BL.LayoutWidth_Pixels = par_intLayoutWidth

            obj_listOutput.Add(new_ElementWithText)

        Next each_obj

        Return obj_listOutput

    End Function ''eND OF Public Shared Function ListOfElementsText_Custom()  

    Public Shared Sub InitializeHardcodedList_Students(pboolOnlyIfNeeded As Boolean)
        ''
        ''Stubbed 7/16/2019 td
        ''
        ''  Add Schoolname, Teacher name, Grade. 
        ''
        ''Dim intIndex As Integer ''= 1 To 3

        ''For intIndex = 1 To 3

        ''Added 7/23/2019 thomas
        With ListOfFields_Students
            If (pboolOnlyIfNeeded And .Count > 0) Then Exit Sub
        End With

        Dim new_object1 As New ClassFieldCustomized
        With new_object1
            .TextFieldId = 1 ''TextField01 
            .IsCustomizable = True ''Added 7/26/2019 td 
            .FieldLabelCaption = "School Name"
            .CIBadgeField_Optional = "" ''Optional. 
            .FieldType_TD = "T"c
            .HasPresetValues = True
            .IsAdditionalField = False
            ''.IsDateField = False
            .IsFieldForDates = False
            .ExampleValue = "Willcrest School"
            .ArrayOfValues = New String() {"Willcrest School", "Woodbridge School"}

            ''Added 9/3/2019 td
            .ElementInfo = New ClassElementText()

        End With
        ListOfFields_Students.Add(new_object1)

        Dim new_object2 As New ClassFieldCustomized
        With new_object2
            .TextFieldId = 2 ''TextField02
            .IsCustomizable = True ''Added 7/26/2019 td 
            .FieldLabelCaption = "Teacher Name"
            .CIBadgeField_Optional = "" ''Optional. 
            .FieldType_TD = "T"c
            .HasPresetValues = True
            .IsAdditionalField = False
            ''.IsDateField = False
            .IsFieldForDates = False
            .ArrayOfValues = New String() {"Mrs. Ross", "Mr. Smudge", "Ms. Randall"}

            ''Added 9/3/2019 td
            .ElementInfo = New ClassElementText()

        End With
        ListOfFields_Students.Add(new_object2)

        Dim new_object3 As New ClassFieldCustomized
        With new_object3
            .TextFieldId = 3 ''TextField03 
            .IsCustomizable = True ''Added 7/26/2019 td 
            .FieldLabelCaption = "Grade Level"
            .CIBadgeField_Optional = "" ''Optional. 
            .FieldType_TD = "T"c
            .HasPresetValues = True
            .IsAdditionalField = False
            ''.IsDateField = False
            .IsFieldForDates = False
            .ArrayOfValues = New String() {"9th", "10th", "11th", "12th"}

            ''Added 9/3/2019 td
            .ElementInfo = New ClassElementText()

        End With
        ListOfFields_Students.Add(new_object3)

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

        Dim new_object1 As New ClassFieldCustomized
        With new_object1
            .TextFieldId = 1
            .IsCustomizable = True ''Added 7/26/2019 td 
            .FieldLabelCaption = "School Name"
            .CIBadgeField_Optional = "" ''Optional. 
            .FieldType_TD = "T"c
            .HasPresetValues = True
            .IsAdditionalField = False
            ''.IsDateField = False
            .IsFieldForDates = False
            .ExampleValue = "Willcrest School"
            .ArrayOfValues = New String() {"Willcrest School", "Woodbridge School"}
        End With
        ListOfFields_Staff.Add(new_object1)

        Dim new_object2 As New ClassFieldCustomized
        With new_object1
            .TextFieldId = 2
            .IsCustomizable = True ''Added 7/26/2019 td 
            .FieldLabelCaption = "Job Title"
            .CIBadgeField_Optional = "" ''Optional. 
            .FieldType_TD = "T"c
            .HasPresetValues = True
            .IsAdditionalField = False
            ''.IsDateField = False
            .IsFieldForDates = False
            .ArrayOfValues = New String() {"Teacher", "Custodian", "Security", "Admin"}
        End With
        ListOfFields_Staff.Add(new_object2)

        Dim new_object3 As New ClassFieldCustomized
        With new_object3
            .TextFieldId = 3
            .IsCustomizable = True ''Added 7/26/2019 td 
            .FieldLabelCaption = "Grade Level If Applicable"
            .CIBadgeField_Optional = "" ''Optional. 
            .FieldType_TD = "T"c
            .HasPresetValues = True
            .IsAdditionalField = False
            ''.IsDateField = False
            .IsFieldForDates = False
            .ArrayOfValues = New String() {"9th", "10th", "11th", "12th"}
        End With
        ListOfFields_Staff.Add(new_object3)

    End Sub ''End of "InitializeHardcodedList_Staff()"

    Public Sub Load_ByCopyingMembers(par_info As ICIBFieldStandardOrCustom)
        ''
        ''Added 7/23/2019 td
        ''
        Me.ArrayOfValues = par_info.ArrayOfValues
        Me.CIBadgeField_Optional = par_info.CIBadgeField_Optional
        Me.ExampleValue = par_info.ExampleValue
        Me.FieldIndex = par_info.FieldIndex
        Me.FieldLabelCaption = par_info.FieldLabelCaption
        Me.HasPresetValues = par_info.HasPresetValues
        Me.IsAdditionalField = par_info.IsAdditionalField
        Me.IsFieldForDates = par_info.IsFieldForDates
        Me.IsLocked = par_info.IsLocked

        Me.FieldType_TD = par_info.FieldType_TD
        Me.OtherDbField_Optional = par_info.OtherDbField_Optional  ''Added 7/23/2019 td 

    End Sub

End Class
