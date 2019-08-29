Public Class CtlAddCustomField

    Private mod_MyParentContainer As FlowLayoutPanel ''ContainerControl

    Private Sub ButtonAddField_Click(sender As Object, e As EventArgs) Handles buttonAddField.Click

        If (mod_MyParentContainer Is Nothing) Then mod_MyParentContainer = Me.Parent

        Me.Parent.Controls.Remove(Me)

        Dim newfieldControl As New CtlConfigFldCustom
        mod_MyParentContainer.Controls.Add(newfieldControl)
        mod_MyParentContainer.Controls.Add(Me)
        ''Moved down.''mod_MyParentContainer.ScrollControlIntoView(Me)

        ''Add 7/23/2019 td 
        Dim new_field As New ClassFieldCustomized ''Add 7/23/2019 td 

        newfieldControl.NewlyAdded = True ''Added 7/27/2019 td 
        newfieldControl.Load_CustomControl(new_field)

        CType(Me.ParentForm, ListCustomFieldsFlow).AdjustHeightOfWindow

        mod_MyParentContainer.ScrollControlIntoView(Me)

    End Sub

    Private Sub CtlAddCustomField_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
