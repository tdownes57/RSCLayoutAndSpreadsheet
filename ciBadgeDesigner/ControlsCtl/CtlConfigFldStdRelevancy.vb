''
''Added 3/17/2022 thomas downes   
''
''Imports ciBadgeInterfaces ''Added 8/29/2019 thomas downes 
Imports ciBadgeFields ''Added 3/21/2022 td 

Public Class CtlConfigFldStdRelevancy
    ''
    ''Added 3/17/2022 thomas downes   
    ''

    Public Sub Load_StandardControl(par_field As ClassFieldCustomized)
        ''
        ''Added 7/21/2019 Thomas DOWNES   
        ''
        CtlConfigFldStandard1.Load_StandardControl(par_field)

    End Sub ''End of "Public Sub Load_StandardControl"


    Private Sub CheckBoxRelevant_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxRelevant.CheckedChanged
        ''
        ''Added 3/21/2022 thomas downes
        ''
        CtlConfigFldStandard1.checkRelevantToPersonality.Checked =
            CheckBoxRelevant.Checked

        If (CheckBoxRelevant.Checked) Then
            ''Added 3/21/2022 thomas downes
            LabelNotYetRelevant.Text = "Relevant (Press Save to retain.)"
        Else
            LabelNotYetRelevant.Text = LabelNotYetRelevant.Tag.ToString()
        End If ''End of "If (CheckBoxRelevant.Checked) Then ... Else ..."

    End Sub



End Class
