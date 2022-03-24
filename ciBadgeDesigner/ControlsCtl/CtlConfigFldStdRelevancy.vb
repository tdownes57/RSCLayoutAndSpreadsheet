''
''Added 3/17/2022 thomas downes   
''
''Imports ciBadgeInterfaces ''Added 8/29/2019 thomas downes 
Imports ciBadgeFields ''Added 3/21/2022 td 

Public Class CtlConfigFldStdRelevancy
    ''
    ''Added 3/17/2022 thomas downes   
    ''
    Public Property NewlyAdded() As Boolean
        Get
            ''Added 3/23/2022 td
            Return CtlConfigFldStandard1.NewlyAdded
        End Get
        Set(value As Boolean)
            ''Added 3/23/2022 td
            CtlConfigFldStandard1.NewlyAdded = value
        End Set
    End Property


    Public ReadOnly Property Field_Standard() As ClassFieldStandard
        Get
            ''Added 3/23/2022 td
            Return CtlConfigFldStandard1.Field_Standard
        End Get
        ''Set(value As ClassFieldStandard)
        ''    ''Added 3/23/2022 td
        ''    CtlConfigFldStandard1.Field_Standard = value
        ''End Set
    End Property


    Public Sub Load_StandardControl(par_field As ClassFieldStandard)
        ''
        ''Added 7/21/2019 Thomas DOWNES   
        ''
        CtlConfigFldStandard1.Load_StandardControl(par_field)

    End Sub ''End of "Public Sub Load_StandardControl"


    Public Sub Save_StandardControl()

        ''Added 3/23/2022  Thomas D. 
        CtlConfigFldStandard1.Save_StandardControl()

    End Sub ''End of ""Public Sub Save_StandardControl()""


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

    End Sub ''End of Handles  CheckBoxRelevant.CheckedChanged 







End Class
