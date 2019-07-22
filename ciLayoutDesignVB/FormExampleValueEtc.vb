Public Class FormExampleValueEtc

    Private mod_model As ICIBFieldCustom ''Added 7/21/2019 td    

    Public Sub Load_CustomField(par_info As ICIBFieldCustom)
        ''
        ''Added 7/21/2019 Thomas DOWNES   
        ''
        mod_model = par_info

        With par_info

            textExampleValue.Text = .ExampleValue

            If ("" <> .CIBadgeField_Optional) Then
                dropdownCIBadgeField.SelectedValue = .CIBadgeField_Optional
            End If

            textOtherDbField.Text = .OtherDbField_Optional

        End With ''End of "With par_info"  

    End Sub ''End of "Public Sub Load_CustomField"

    Public Sub Save_CustomField(par_info As ICIBFieldCustom)
        ''
        ''Added 7/21/2019 Thomas DOWNES   
        ''
        mod_model = par_info

        With par_info

            .ExampleValue = textExampleValue.Text ''= .ExampleValue

            If (-1 <> dropdownCIBadgeField.SelectedIndex) Then
                .CIBadgeField_Optional = dropdownCIBadgeField.SelectedValue ''= .CIBadgeField_Optional
            End If

            .OtherDbField_Optional = textOtherDbField.Text ''= .OtherDbField_Optional

        End With ''End of "With par_info"  

    End Sub ''End of "Public Sub Load_CustomField"

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click

        Me.Close()

    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click

        Save_CustomField
        Me.Close()

    End Sub

    Private Sub ListPresetValues_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub FormExampleValueEtc_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class