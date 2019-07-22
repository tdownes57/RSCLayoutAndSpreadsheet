Public Class UserAddFieldControl

    Private mod_MyParentContainer As FlowLayoutPanel ''ContainerControl

    Private Sub ButtonAddField_Click(sender As Object, e As EventArgs) Handles buttonAddField.Click

        If (mod_MyParentContainer Is Nothing) Then mod_MyParentContainer = Me.Parent

        Me.Parent.Controls.Remove(Me)

        Dim newfieldControl As New UserCustomFieldCtl
        mod_MyParentContainer.Controls.Add(newfieldControl)
        mod_MyParentContainer.Controls.Add(Me)
        mod_MyParentContainer.ScrollControlIntoView(Me)

    End Sub
End Class
