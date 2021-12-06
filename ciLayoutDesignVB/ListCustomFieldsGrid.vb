''
''Added 7/16/2019 thomas downes 
''
''
Imports System.Collections.Generic
Imports ciBadgeInterfaces ''Added 9/17/2019 td
Imports ciBadgeFields ''Added 9/19/2019 td

Public Class ListCustomFieldsGrid

    Public Shared FieldsList_Static As New List(Of ClassFieldCustomized)

    ''Dec6 2021 ''Public Property ListOfFields As List(Of ClassFieldCustomized)
    Public Property ListOfFields As HashSet(Of ClassFieldCustomized)

    Private Sub FormCustomFields_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 7/17/2019 thomas downes
        ''
        If (0 = FieldsList_Static.Count) Then PopulateStaticList()

        If (ListOfFields IsNot Nothing) Then DataGridView1.DataSource = ListOfFields

    End Sub

    Private Sub PopulateStaticList()

        ''For intTextField As Integer = 1 To 10

        Dim objTextField1 As New ClassFieldCustomized
        With objTextField1
            ''9/17/2019 td.TextFieldId = 1 ''intTextField
            .FieldEnumValue = EnumCIBFields.TextField01
            .Text_orDate = "Text"
            .FieldLabelCaption = "Teacher"
            ''.ExampleValueToUseInLayout = "Mrs. Moosemore"
            .ExampleValue = "Mrs. Moosemore"
        End With
        FieldsList_Static.Add(objTextField1)

        Dim objTextField2 As New ClassFieldCustomized
        With objTextField2
            ''9/17/2019 td.TextFieldId = 2 ''intTextField
            .FieldEnumValue = EnumCIBFields.TextField02
            .Text_orDate = "Text"
            .FieldLabelCaption = "Class Grade"
            ''.ExampleValueToUseInLayout = "9th"
            .ExampleValue = "9th"
        End With
        FieldsList_Static.Add(objTextField2)

        Dim objTextField3 As New ClassFieldCustomized
        With objTextField3
            ''9/17/2019 td.TextFieldId = 3 ''intTextField
            .FieldEnumValue = EnumCIBFields.TextField03
            .Text_orDate = "Text"
            .FieldLabelCaption = "School"
            ''.ExampleValueToUseInLayout = "Westmore High"
            .ExampleValue = "Westmore High"
        End With
        FieldsList_Static.Add(objTextField3)

        Dim objTextField4 As New ClassFieldCustomized
        With objTextField4
            ''9/17/2019 td.TextFieldId = 4 ''intTextField
            .FieldEnumValue = EnumCIBFields.TextField04
            .Text_orDate = "Text"
            .FieldLabelCaption = ""
            ''.ExampleValueToUseInLayout = ""
            .ExampleValue = ""
        End With
        FieldsList_Static.Add(objTextField4)

        Dim objTextField5 As New ClassFieldCustomized
        With objTextField5
            ''9/17/2019 td''.TextFieldId = 5 ''intTextField
            ''9/17/2019 td.TextFieldId = 5 ''intTextField
            .FieldEnumValue = EnumCIBFields.TextField05
            .Text_orDate = "Text"
            .FieldLabelCaption = ""
            ''.ExampleValueToUseInLayout = ""
            .ExampleValue = ""

        End With
        FieldsList_Static.Add(objTextField5)


        ''Next intTextField

        ''
        ''Add date fields
        ''
        For intDateField As Integer = 1 To 1

            Dim objDateField1 As New ClassFieldCustomized
            With objDateField1
                ''9/17 td''.TextFieldId = 0 ''0 since it's not a Textfield. 
                ''9/17 td''.DateFieldId = 1 ''intTextField
                .FieldEnumValue = EnumCIBFields.DateField01
                .Text_orDate = "Date"
                ''9/16/2019 td''.LabelCaption = "First Day"
                .FieldLabelCaption = "First Day"

                ''.ExampleValueToUseInLayout = "7/21/2017"
                .ExampleValue = "7/21/2017"
            End With
            FieldsList_Static.Add(objDateField1)

        Next intDateField

        ClassFieldsBindingSource.DataSource = FieldsList_Static


    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
    '' { New ClassCustomField() {}, New ClassCustomField() {} }






End Class