''
''Added 7/21/2019 thomas downes
''

Public Class FormCustomFieldsFlow
    Private Sub FormCustomFieldsFlow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 7/21/2019 thomas downes
        ''
        '' 7/21 td''ClassCustomField.InitializeHardcodedList_Students()

        LoadCustomFields_All()

    End Sub

    Private Sub LoadCustomFields_All()
        ''
        ''Added 7.21.2019
        ''
        ClassCustomField.InitializeHardcodedList_Students()
        FlowLayoutPanel1.Controls.Clear()

        For Each each_customField In ClassCustomField.ListOfFields_Students
            ''
            ''Add 7/21/2019
            ''
            LoadCustomField_Each(each_customField)

        Next each_customField

        ''
        ''Add 7/21/2019
        ''
        FlowLayoutPanel1.Controls.Add(New UserAddFieldControl())

    End Sub ''End of "Private Sub LoadFields()"  

    Private Sub LoadCustomField_Each(par_customfld As ClassCustomField)
        ''
        ''Added 7/ 21/2019
        ''
        Dim userControl As New UserCustomFieldCtl

        ''7/21/2019 td''FlowLayoutPanel1.Controls.Add(New UserCustomFieldCtl())

        userControl.Load_CustomField(CType(par_customfld, ICIBFieldCustom))

        FlowLayoutPanel1.Controls.Add(userControl)

    End Sub ''End of "Private Sub LoadCustomField_Each(par_customfld As ClassCustomField)"


End Class