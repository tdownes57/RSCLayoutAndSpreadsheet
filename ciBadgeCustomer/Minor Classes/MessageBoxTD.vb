Option Explicit On ''Added 2/17/2022 thomas 
Option Strict On
''
''  Added 2/17/2022 & 12/28/2021 thomas downes  
''
Imports System.Windows.Forms ''Added 2/17/2022 thomas downes

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


End Class
