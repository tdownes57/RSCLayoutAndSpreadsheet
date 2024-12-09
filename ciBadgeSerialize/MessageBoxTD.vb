''
''Copy-pasted from __RSCWindowsControlLibrary on 1/25/2022 td
''
Imports System.Windows.forms ''Added 1/25/2022 td

Public Class MessageBoxTD

    ''Added 1/04/2024 & 2/06/2022 
    Private Const _vbCrLf_Deux As String = (vbCrLf & vbCrLf)

    Public Shared Sub Show_Statement(pstrStatement As String,
                                     Optional pstrSecondLine As String = "")
        ''
        ''Added 12/28/2021 thomas downes
        ''
        ''---MessageBox.Show(pstrStatement, "MessageBoxTD-Statement", MessageBoxButtons.OK,
        ''     MessageBoxIcon.Information)

        MessageBox.Show(pstrStatement & _vbCrLf_Deux &
                        pstrSecondLine, "MessageBoxTD-Statement",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)

    End Sub ''End of ""Public Shared Sub Show_Statement""


    Public Shared Function Show_Statement_OkayCancel(pstrWord_ForLine1 As String, pstrStatement_Line1 As String,
                                     Optional pstrSecondLine As String = "") As DialogResult
        ''
        ''Added 12/08/2024 thomas downes
        ''
        Dim strLine1_WithWord As String
        Dim result_OkayCancel As DialogResult

        strLine1_WithWord = String.Format(pstrStatement_Line1, pstrWord_ForLine1)

        result_OkayCancel =
            MessageBox.Show(strLine1_WithWord & _vbCrLf_Deux &
                        pstrSecondLine, "MessageBoxTD-Statement_OkayCancel",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Information)

        Return result_OkayCancel

    End Function ''End of ""Public Shared Sub Show_Statement_OkayCancel""



    Public Shared Function Show_QuestionYesNo(pstrQuestionYesNo As String) As DialogResult
        ''
        ''Added 12/28/2021 thomas downes
        ''
        Return MessageBox.Show(pstrQuestionYesNo, "MessageBoxTD-Question",
                               MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

    End Function ''End of ""Public Shared Function Show_QuestionYesNo""


    Public Shared Function Show_QuestionIsOkay(pstrQuestionIsOkay As String) As DialogResult
        ''
        ''Added 12/28/2021 thomas downes
        ''
        Return MessageBox.Show(pstrQuestionIsOkay, "MessageBoxTD-QuestionIsOkay",
                               MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

    End Function ''End of ""Public Shared Function Show_QuestionIsOkay""

    Public Shared Sub Show_InsertWordFormat_Line1(pstrWord_ForLine1 As String,
                                               pstrStatement_Line1 As String,
                                     Optional pstrStatement_Line2 As String = "")
        ''
        ''Added 4/26/2022 thomas downes
        ''
        Dim strLine1_WithWord As String
        strLine1_WithWord = String.Format(pstrStatement_Line1, pstrWord_ForLine1)

        MessageBox.Show(strLine1_WithWord & _vbCrLf_Deux &
                        pstrStatement_Line2, "MessageBoxTD-Statement",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub ''End of ""Public Shared Sub Show_InsertWordFormat_Line1""



End Class
