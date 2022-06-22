''
''Added 7/26/2019 td  
''Modified 9/19/2019 td
''
Imports ciBadgeInterfaces
Imports ciBadgeFields

Public Class DialogPresetValues

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
        Dim frm_ToShow As New DialogSubsection
        frm_ToShow.Show()

    End Sub

    Private Sub ButtonAddValue_Click(sender As Object, e As EventArgs) Handles ButtonAddValue.Click

        Dim strNewPresetValue As String ''Added 7/27/2019 td
        strNewPresetValue = textNewPresetValue.Text

        With listPresetValues
            .Items.Add(strNewPresetValue)
            ''Added 7/28/2019 td 
            .SelectedItem = strNewPresetValue
        End With

        ''Added 7/28/2019 td  
        With LinkCreateSubsection
            ''.Text = String.Format(.Tag, strNewPresetValue)
            .Text = String.Format(.Tag.ToString(), strNewPresetValue)
            .Visible = True
        End With

    End Sub
End Class