Public Class FormPresetValues

    Private mod_model As ClassFieldCustomized

    Public Sub Load_CustomField(par_model As ClassFieldCustomized)




    End Sub

    Public Sub Save_CustomField()




    End Sub

    Private Sub FormPresetValues_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ListPresetValues_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listPresetValues.SelectedIndexChanged

    End Sub

    Private Sub LinkCreateSubsection_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkCreateSubsection.LinkClicked

        ''Added 7/26/2019 td
        Dim frm_ToShow As New FormSubsection
        frm_ToShow.Show()

    End Sub

    Private Sub ButtonAddValue_Click(sender As Object, e As EventArgs) Handles ButtonAddValue.Click

        Dim strNewPresetValue As String ''Added 7/27/2019 td
        strNewPresetValue = textNewPresetValue.Text

        listPresetValues.Items.Add(strNewPresetValue)


    End Sub
End Class