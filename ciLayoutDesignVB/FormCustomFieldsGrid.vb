''
''Added 7/16/2019 thomas downes 
''
''
Imports System.Collections.Generic

Public Class FormCustomFieldsGrid

    Public Shared FieldsList_Static As New List(Of ClassCustomField)

    Private Sub FormCustomFields_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 7/17/2019 thomas downes
        ''
        If (0 = FieldsList_Static.Count) Then PopulateStaticList()

    End Sub

    Private Sub PopulateStaticList()

        ''For intTextField As Integer = 1 To 10

        Dim objTextField1 As New ClassCustomField
        With objTextField1
            .TextFieldId = 1 ''intTextField
            .Text_orDate = "Text"
            .LabelCaption = "Teacher"
            .ExampleValueToUseInLayout = "Mrs. Moosemore"
        End With
        FieldsList_Static.Add(objTextField1)

        Dim objTextField2 As New ClassCustomField
        With objTextField2
            .TextFieldId = 2 ''intTextField
            .Text_orDate = "Text"
            .LabelCaption = "Class Grade"
            .ExampleValueToUseInLayout = "9th"
        End With
        FieldsList_Static.Add(objTextField2)

        Dim objTextField3 As New ClassCustomField
        With objTextField3
            .TextFieldId = 3 ''intTextField
            .Text_orDate = "Text"
            .LabelCaption = "School"
            .ExampleValueToUseInLayout = "Westmore High"
        End With
        FieldsList_Static.Add(objTextField3)

        Dim objTextField4 As New ClassCustomField
        With objTextField4
            .TextFieldId = 4 ''intTextField
            .Text_orDate = "Text"
            .LabelCaption = ""
            .ExampleValueToUseInLayout = ""
        End With
        FieldsList_Static.Add(objTextField2)

        Dim objTextField5 As New ClassCustomField
        With objTextField5
            .TextFieldId = 5 ''intTextField
            .Text_orDate = "Text"
            .LabelCaption = ""
            .ExampleValueToUseInLayout = ""
        End With
        FieldsList_Static.Add(objTextField5)


        ''Next intTextField

        ''
        ''Add date fields
        ''
        For intDateField As Integer = 1 To 1

            Dim objDateField1 As New ClassCustomField
            With objDateField1
                .TextFieldId = 0 ''0 since it's not a Textfield. 
                .DateFieldId = 1 ''intTextField
                .Text_orDate = "Date"
                .LabelCaption = "First Day"
                .ExampleValueToUseInLayout = "7/21/2017"
            End With
            FieldsList_Static.Add(objDateField1)

        Next intDateField

        ClassFieldsBindingSource.DataSource = FieldsList_Static


    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
    '' { New ClassCustomField() {}, New ClassCustomField() {} }






End Class