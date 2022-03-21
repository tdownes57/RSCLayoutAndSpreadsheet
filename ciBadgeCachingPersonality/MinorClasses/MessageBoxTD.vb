Option Explicit On
Option Strict On
''
''Code originally written 12/28/2022 td
''Copy-pasted on 2/8/2022 td
''
Imports System.Windows.Forms ''Added 2/8/2022 td

Public Class MessageBoxTD

    ''Added Feb6 2022
    Private Const _vbCrLf_Deux As String = (vbCrLf & vbCrLf)

    Public Shared Sub Show_Statement(pstrStatement_Line1 As String,
                                     Optional pstrStatement_Line2 As String = "")
        ''
        ''Added 12/28/2021 thomas downes
        ''
        ''March21 2022''MessageBox.Show(pstrStatement, "MessageBoxTD-Statement", MessageBoxButtons.OK, MessageBoxIcon.Information)
        MessageBox.Show(pstrStatement_Line1 & _vbCrLf_Deux &
                        pstrStatement_Line2, "MessageBoxTD-Statement",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub


    Public Shared Function Show_QuestionYesNo(pstrQuestionYesNo_Line1 As String,
                  Optional pstrQuestionYesNo_Line2 As String = "") As DialogResult
        ''
        ''Added 12/28/2021 thomas downes
        ''
        Dim strNextLine As String = ""
        If (Not String.IsNullOrEmpty(pstrQuestionYesNo_Line2)) Then
            strNextLine = (_vbCrLf_Deux & pstrQuestionYesNo_Line2)
        End If

        Return MessageBox.Show(pstrQuestionYesNo_Line1 & strNextLine,
                               "MessageBoxTD-Question",
                               MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

    End Function ''end of ""Public Shared Function Show_QuestionYesNo""


    Public Shared Function Show_QuestionYesNo_FormatCounts(pintCountOfLine1 As Integer,
                                                           pstrQuestionYesNo_Line1 As String,
                  Optional pstrQuestionYesNo_Line2 As String = "",
                  Optional pintCountOfLine2 As Integer = 0) As DialogResult
        ''
        ''Added 12/28/2021 thomas downes
        ''
        ''Format the counts... i.e. use String.Format to replace {0}
        ''  with a number value.
        ''
        Dim strNextLine As String = ""

        ''Format the counts... i.e. use String.Format to replace {0}
        ''  with a number value.
        pstrQuestionYesNo_Line1 = String.Format(pstrQuestionYesNo_Line1, pintCountOfLine1)

        If (Not String.IsNullOrEmpty(pstrQuestionYesNo_Line2)) Then
            strNextLine = (_vbCrLf_Deux & pstrQuestionYesNo_Line2)
            ''Format the counts... i.e. use String.Format to replace {0}
            ''  with a number value.
            strNextLine = String.Format(strNextLine, pintCountOfLine2)
        End If

        Return MessageBox.Show(pstrQuestionYesNo_Line1 & strNextLine,
                               "MessageBoxTD-Question",
                               MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

    End Function ''end of ""Public Shared Function Show_QuestionYesNo""


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


    Public Shared Function Show_Confirmed_FormatCount(pintCountOfLine1 As Integer,
                                                           pstrConfirmPrompt_Line1 As String,
                                        pstrConfirmPrompt_Line2 As String,
                                        pbInformOfNonconfirmation As Boolean) As Boolean
        ''
        ''Added 12/28/2021 thomas downes
        ''
        ''Format the counts... i.e. use String.Format to replace {0}
        ''  with a number value.
        ''
        Dim diag_result As DialogResult

        ''Format the counts... i.e. use String.Format to replace {0}
        ''  with a number value.
        pstrConfirmPrompt_Line1 = String.Format(pstrConfirmPrompt_Line1, pintCountOfLine1)

        diag_result =
           MessageBox.Show(pstrConfirmPrompt_Line1 & _vbCrLf_Deux &
                pstrConfirmPrompt_Line2, "MessageBoxTD-QuestionIsOkay",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If (diag_result = DialogResult.OK) Then
            Return True
        Else
            Show_Statement("User (you) has not confirmed, for any number of possible reasons.")
            Return False
        End If ''End of "If (diag_result = DialogResult.OK) Then .... Else ...."

    End Function ''End of "Public Shared Function Show_Confirmed"



End Class
