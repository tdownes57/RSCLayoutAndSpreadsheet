Public Class MessageBoxTD_NotUsed
    ''    5/23/2022 ''Public Class MessageBoxTD
    ''
    ''Added 12/28/2021 thomas downes
    ''

    Public Shared Sub Show_Statement(pstrStatement As String,
                                     Optional pstrStatement2 As String = "",
                                     Optional pstrStatement3 As String = "")
        ''
        ''This is a statement of fact (or opinion), not a question of any sort. 
        ''
        ''Added 12/28/2021 thomas downes
        ''
        If (String.IsNullOrEmpty(pstrStatement2)) Then
            ''
            ''Just one(1) line.  Most popular choice!!   LOL. 
            ''
            MessageBox.Show(pstrStatement, "MessageBoxTD-Statement", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ElseIf (String.IsNullOrEmpty(pstrStatement3)) Then
            ''
            ''The two-lines version.
            ''
            MessageBox.Show(pstrStatement & vbCrLf_Deux &
            pstrStatement2, "MessageBoxTD-Statement",
                           MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            ''
            ''The three-lines version.
            ''
            MessageBox.Show(pstrStatement & vbCrLf_Deux &
                            pstrStatement2 & vbCrLf_Deux &
                            pstrStatement3, "MessageBoxTD-Statement",
                           MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub ''Public Shared Sub Show_Statement

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
