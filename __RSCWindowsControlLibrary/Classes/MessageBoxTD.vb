Public Class MessageBoxTD

    ''Added Feb6 2022
    Private Const _vbCrLf_Deux As String = (vbCrLf & vbCrLf)

    Public Shared Sub Show_Statement(pstrStatement As String)
        ''
        ''Added 12/28/2021 thomas downes
        ''
        MessageBox.Show(pstrStatement, "MessageBoxTD-Statement", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub


    Public Shared Function Show_QuestionYesNo(pstrQuestionYesNo As String) As DialogResult
        ''
        ''Added 12/28/2021 thomas downes
        ''
        Return MessageBox.Show(pstrQuestionYesNo, "MessageBoxTD-Question",
                               MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

    End Function


    Public Shared Function Show_QuestionIsOkay(pstrQuestionIsOkay As String) As DialogResult
        ''
        ''Added 12/28/2021 thomas downes
        ''
        Return MessageBox.Show(pstrQuestionIsOkay, "MessageBoxTD-QuestionIsOkay",
                               MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

    End Function


    Public Shared Function Show_Confirmed(pstrConfirmPrompt1 As String,
                                          pstrConfirmPrompt2 As String,
                                          pbInformOfNonconfirmation As Boolean) As Boolean
        ''
        ''Added 12/28/2021 thomas downes
        ''
        Dim diag_result As DialogResult

        diag_result =
           MessageBox.Show(pstrConfirmPrompt1 & _vbCrLf_Deux &
                pstrConfirmPrompt2, "MessageBoxTD-QuestionIsOkay",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If (diag_result = DialogResult.OK) Then
            Return True
        Else
            Show_Statement("User has not confirmed, for any number of possible reasons.")
            Return False
        End If ''End of "If (diag_result = DialogResult.OK) Then .... Else ...."

    End Function ''End of "Public Shared Function Show_Confirmed"


End Class
