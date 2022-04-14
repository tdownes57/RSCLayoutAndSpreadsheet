Option Explicit On
Option Strict On
''
''Added 3/17/2022 thomas downes
''
''Imports ciBadgeInterfaces ''Added 8/29/2019 thomas downes 
Imports ciBadgeFields ''Added 3/21/2022 td 

Public Class CtlConfigFldCustRelevancy
    ''
    ''Added 3/17/2022 thomas downes   
    ''
    Private mod_isLoading As Boolean ''Added 4/13/2022 thomas d.

    Public Property NewlyAdded() As Boolean
        Get
            ''Added 3/23/2022 td
            Return CtlConfigFldCustom1.NewlyAdded
        End Get
        Set(value As Boolean)
            ''Added 3/23/2022 td
            CtlConfigFldCustom1.NewlyAdded = value
        End Set
    End Property


    Public ReadOnly Property Field_Customized() As ClassFieldCustomized
        Get
            ''Added 3/23/2022 td
            Return CtlConfigFldCustom1.Field_Customized
        End Get
        ''Set(value As ClassFieldCustomized)
        ''    ''Added 3/23/2022 td
        ''    CtlConfigFldCustom1.Field_Custom = value
        ''End Set
    End Property


    Public Sub Load_CustomControl(par_field As ClassFieldCustomized)
        ''
        ''Added 7/21/2019 Thomas DOWNES   
        ''
        CtlConfigFldCustom1.Load_CustomControl(par_field)

    End Sub ''End of "Public Sub Load_CustomControl"


    Public Sub Save_CustomControl()

        ''Added 3/23/2022  Thomas D. 
        CtlConfigFldCustom1.Save_CustomControl()

    End Sub ''End of ""Public Sub Save_CustomControl()""

    Private Sub CheckBoxRelevant_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxRelevant.CheckedChanged
        ''
        ''Added 3/21/2022 thomas downes
        ''
        If (mod_isLoading) Then Exit Sub

        CtlConfigFldCustom1.checkRelevantToPersonality.Checked =
            CheckBoxRelevant.Checked

        If (CheckBoxRelevant.Checked) Then
            ''Added 3/21/2022 thomas downes
            LabelNotYetRelevant.Text = "Relevant (Press Save to retain.)"
        Else
            LabelNotYetRelevant.Text = LabelNotYetRelevant.Tag.ToString()
        End If ''End of "If (CheckBoxRelevant.Checked) Then ... Else ..."

        ''Added 4/13/2022 td
        CtlConfigFldCustom1.RelevantToPersonality_CheckedChanged()

    End Sub

    Private Sub CtlConfigFldCustom1_Load(sender As Object, e As EventArgs) Handles CtlConfigFldCustom1.Load

    End Sub

    Private Sub CtlConfigFldCustom1_RelevancyChangedTo(pbRelevant As Boolean) Handles CtlConfigFldCustom1.RelevancyChangedTo

        ''Added 4/13/2022 thomas downes
        mod_isLoading = True
        CheckBoxRelevant.Checked = pbRelevant
        Application.DoEvents()
        mod_isLoading = False

    End Sub
End Class
