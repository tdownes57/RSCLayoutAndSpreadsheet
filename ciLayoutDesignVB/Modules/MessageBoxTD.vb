Public Class MessageBoxTD

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


    Public Shared Function Show_Confirm(pstrConfirmationQuestion As String) As Boolean
        ''
        ''Added 2/17/2022 thomas downes
        ''
        Dim res As DialogResult

        res = MessageBox.Show(pstrConfirmationQuestion & vbCrLf_Deux &
                               "Confirm by pressing Yes.", "MessageBoxTD-Confirm",
                               MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

        Return (res = DialogResult.Yes)

    End Function

End Class
