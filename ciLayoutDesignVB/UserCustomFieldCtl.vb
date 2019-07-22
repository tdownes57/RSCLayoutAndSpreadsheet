''
''Added 7/21/2019 thomas downes 
''

Public Class UserCustomFieldCtl
    ''
    ''Added 7/21/2019 td
    ''
    Private mod_model As ICIBFieldCustom

    Public Sub Load_CustomControl(par_info As ICIBFieldCustom)
        ''
        ''Added 7/21/2019 Thomas DOWNES   
        ''
        mod_model = par_info

        With par_info





        End With ''End of "With par_info"  

    End Sub ''End of "Public Sub Load_CustomControl"

    Private Sub UserCustomFieldCtl_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub LabelFieldLabelCaption_Click(sender As Object, e As EventArgs) Handles LabelFieldLabelCaption.Click

    End Sub

    Private Sub Link_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkSupplementary.LinkClicked
        ''
        ''Added 7/21/2019 thomas downes
        ''
        Dim frm_show As New FormExampleValueEtc

        frm_show.Load_CustomField(mod_model)
        frm_show.ShowDialog()

    End Sub

    Private Sub LinkAddPresetValue_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkAddPresetValue.LinkClicked

    End Sub
End Class
