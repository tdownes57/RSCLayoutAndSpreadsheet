Public Class DialogExampleValueEtc

    Private mod_model As ClassFieldCustomized

    Public Sub Load_CustomField(par_model As ClassFieldCustomized)




    End Sub

    Public Sub Save_CustomField()




    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click

    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click

    End Sub

    Private Sub ListPresetValues_SelectedIndexChanged(sender As Object, e As EventArgs) 

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) 

    End Sub

    Private Sub FormExampleValueEtc_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormExampleValueEtc_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ''
        ''Nothing to do here.  It's all done by the parent, UserControlCustomField.
        ''
    End Sub
End Class