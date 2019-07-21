Option Explicit On
Option Strict On
Imports ciLayoutDesignVB
''
''Added 7/16/2019 thomas downes  
''

Public Class ClassCustomField
    Implements ICIBFieldCustom ''Added 7/21/2019 td
    ''
    ''Added 7/16/2019 thomas d. 
    ''
    ''Public TextFieldId As Integer
    Public Property TextFieldId As Integer = 1

    Public Property DateFieldId As Integer = 0
    Public Property IsDateField As Boolean = False

    Public Property Text_orDate As String = "Text"

    Public Property LabelCaption As String = ""
    Public Property ExampleValueToUseInLayout As String = ""

    ''7/21 td''Public Property CIBadgeFieldname As String ''Added 7/21/2019 Thomas DOWNES 
    Public Property CIBadgeField_Optional As String Implements ICIBFieldCustom.CIBadgeField_Optional ''Added 7/21/2019 Thomas DOWNES 
    Public Property OtherDbField_Optional As String Implements ICIBFieldCustom.OtherDbField_Optional ''Added 7/21/2019 Thomas DOWNES 

    Public Property FieldLabelCaption As String Implements ICIBFieldCustom.FieldLabelCaption
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As String)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property FieldType_TD As Char Implements ICIBFieldCustom.FieldType_TD
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Char)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property FieldIndex As Integer Implements ICIBFieldCustom.FieldIndex
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Integer)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property IsFieldForDates As Boolean Implements ICIBFieldCustom.IsFieldForDates
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Boolean)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property IsLocked As Boolean Implements ICIBFieldCustom.IsLocked
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Boolean)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property ExampleValue As String Implements ICIBFieldCustom.ExampleValue
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As String)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property HasPresetValues As Boolean Implements ICIBFieldCustom.HasPresetValues
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Boolean)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property ArrayOfValues As String() Implements ICIBFieldCustom.ArrayOfValues
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As String())
            Throw New NotImplementedException()
        End Set
    End Property

    ''Public Property OtherDbFieldname As String Implements ICIBFieldCustom.OtherDbField_Optional
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As String)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property IsAdditionalField As Boolean Implements ICIBFieldCustom.IsAdditionalField
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Boolean)
            Throw New NotImplementedException()
        End Set
    End Property


    ''
    ''Added 7/16/2019 thomas d. 
    ''
    Public Shared ListOfFields_Students As New List(Of ClassCustomField)
    Public Shared ListOfFields_Staff As New List(Of ClassCustomField)

    Public Shared Sub InitializeHardcodedList_Students()
        ''
        ''Stubbed 7/16/2019 td
        ''
        ''  Add Schoolname, Teacher name, Grade. 
        ''
        ''Dim intIndex As Integer ''= 1 To 3

        ''For intIndex = 1 To 3

        Dim new_object1 As New ClassCustomField
        With new_object1
            .TextFieldId = 1
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
        ListOfFields_Students.Add(new_object1)

        Dim new_object2 As New ClassCustomField
        With new_object1
            .TextFieldId = 2
            .FieldLabelCaption = "Teacher Name"
            .CIBadgeField_Optional = "" ''Optional. 
            .FieldType_TD = "T"c
            .HasPresetValues = True
            .IsAdditionalField = False
            ''.IsDateField = False
            .IsFieldForDates = False
            .ArrayOfValues = New String() {"Mrs. Ross", "Mr. Smudge", "Ms. Randall"}
        End With
        ListOfFields_Students.Add(new_object2)

        Dim new_object3 As New ClassCustomField
        With new_object3
            .TextFieldId = 3
            .FieldLabelCaption = "Grade Level"
            .CIBadgeField_Optional = "" ''Optional. 
            .FieldType_TD = "T"c
            .HasPresetValues = True
            .IsAdditionalField = False
            ''.IsDateField = False
            .IsFieldForDates = False
            .ArrayOfValues = New String() {"9th", "10th", "11th", "12th"}
        End With
        ListOfFields_Students.Add(new_object3)

    End Sub ''End of "InitializeHardcodedList_Students()"

    Public Shared Sub InitializeHardcodedList_Staff()
        ''
        ''Stubbed 7/16/2019 td
        ''
        ''  Add Schoolname, Job Title, GradeLevel (if applicable). 
        ''





    End Sub

End Class
