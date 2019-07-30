Option Explicit On
Option Strict On

Imports ciLayoutDesignVB
''
''Added 7/26/2019 thomas downes  
''

Public Class ClassFieldStandard
    Implements ICIBFieldStandardOrCustom ''Added 7/21/2019 td
    ''
    ''Added 7/26/2019 thomas d. 
    ''
    ''Public TextFieldId As Integer
    ''Not applicable. 7/26/2019 td''Public Property TextFieldId As Integer = 1

    Public Property IsStandard As Boolean = False Implements ICIBFieldStandardOrCustom.IsStandard ''Added 7/26/2019 td
    Public Property IsCustomizable As Boolean = False Implements ICIBFieldStandardOrCustom.IsCustomizable ''Added 7/26/2019 td

    ''Not applicable. 7/26/2019 td''Public Property DateFieldId As Integer = 0
    Public Property IsDateField As Boolean = False

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

    ''Added 7/29/2019 thomas downes
    ''
    Public Property ElementInfo As ClassElementText

    ''
    ''Added 7/16/2019 thomas d. 
    ''
    Public Shared ListOfFields_Students As New List(Of ClassFieldStandard)
    Public Shared ListOfFields_Staff As New List(Of ClassFieldStandard)

    Public Shared Sub InitializeHardcodedList_Students(pboolOnlyIfNeeded As Boolean)
        ''
        ''Added 7/26/2019 td
        ''
        With ListOfFields_Students
            If (pboolOnlyIfNeeded And .Count > 0) Then Exit Sub
        End With

        Dim new_object1 As New ClassFieldStandard
        With new_object1
            ''N/A''.TextFieldId = 1 ''TextField01 
            .IsCustomizable = False ''Added 7/26/2019 td 
            .FieldLabelCaption = "Student ID"
            .CIBadgeField_Optional = "fstrID"
            .FieldType_TD = "T"c
            .HasPresetValues = False
            .IsAdditionalField = False
            .IsFieldForDates = False
            .ExampleValue = "3012"
        End With
        ListOfFields_Students.Add(new_object1)

        Dim new_object2 As New ClassFieldStandard
        With new_object2
            ''N/A''.TextFieldId = 2 ''TextField02
            .IsCustomizable = False ''Added 7/26/2019 td 
            .FieldLabelCaption = "First Name"
            .CIBadgeField_Optional = "fstrFirstName"
            .FieldType_TD = "T"c
            .HasPresetValues = False
            .IsAdditionalField = False
            .IsFieldForDates = False
        End With
        ListOfFields_Students.Add(new_object2)

        Dim new_object3 As New ClassFieldStandard
        With new_object3
            ''N/A''.TextFieldId = 3 ''TextField03 
            .IsCustomizable = False ''Added 7/26/2019 td 
            .FieldLabelCaption = "Last Name"
            .CIBadgeField_Optional = "fstrLastName"
            .FieldType_TD = "T"c
            .HasPresetValues = False
            .IsAdditionalField = False
            ''.IsDateField = False
            .IsFieldForDates = False
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

        Dim new_object1 As New ClassFieldStandard
        With new_object1
            ''N/A''.TextFieldId = 1
            .IsCustomizable = False ''Added 7/26/2019 td 
            .FieldLabelCaption = "Staffperson ID"
            .CIBadgeField_Optional = "fstrID"
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
            .CIBadgeField_Optional = "fstrFirstName"
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
            .CIBadgeField_Optional = "fstrLastName"
            .FieldType_TD = "T"c
            .HasPresetValues = True
            .IsAdditionalField = False
            ''.IsDateField = False
            .IsFieldForDates = False
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
