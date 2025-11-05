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

    Public Shared Function InputBox_Longform(pstrInstructions As String,
                                             pstrFinalPrompt As String,
                    psingFactorWidth As Single,
                    psingFactorHeight As Single,
                    Optional ByRef prefUserCancelled As Boolean = False,
                    Optional pstrDefaultResponse As String = "") As String
        ''
        ''Added 5/23/2022 thomas downes
        ''
        Dim formToShow As FormInputBox

        formToShow = New FormInputBox(pstrInstructions, pstrFinalPrompt,
                                      psingFactorWidth, psingFactorHeight,
                                      pstrDefaultResponse)

        formToShow.ShowDialog()

        If (formToShow.DialogResult = DialogResult.Cancel) Then
            prefUserCancelled = True  ''Added 5/13/2022
            Return ""
        ElseIf (formToShow.DialogResult <> DialogResult.OK) Then
            prefUserCancelled = True  ''Added 5/13/2022
            Return ""
        End If

        Return formToShow.UsersEditedResponse

    End Function ''End of "Public Shared Function InputBox_Longform"



    Public Shared Function InputBox_NameDescription(pstrInstructions As String,
                                             pstrPrompt_Name As String,
                                             pstrPrompt_Descr As String,
                    psingFactorWidth As Single,
                    psingFactorHeight As Single,
                    Optional ByRef prefUserCancelled As Boolean = False) _
                    As Tuple(Of String, String)
        ''
        ''Added 8/14/2022 thomas downes
        ''
        Dim formToShow As FormInputNameDescription

        ''formToShow = New FormInputBox(pstrInstructions, pstrFinalPrompt,
        ''                              psingFactorWidth, psingFactorHeight,
        ''                              pstrDefaultResponse)
        formToShow = New FormInputNameDescription(pstrInstructions,
                                      pstrPrompt_Name,
                                      pstrPrompt_Descr,
                                      psingFactorWidth,
                                      psingFactorHeight)

        formToShow.ShowDialog()

        If (formToShow.DialogResult = DialogResult.Cancel) Then
            prefUserCancelled = True  ''Aded 5/13/2022
            ''---Return ""
            Return New Tuple(Of String, String)("", "")
        ElseIf (formToShow.DialogResult <> DialogResult.OK) Then
            prefUserCancelled = True  ''Aded 5/13/2022
            ''---Return ""
            Return New Tuple(Of String, String)("", "")
        End If

        Dim tupleND As Tuple(Of String, String)
        tupleND = New Tuple(Of String, String)(formToShow.UserResponse_Name,
                                               formToShow.UserResponse_Description)
        Return tupleND

    End Function ''End of "Public Shared Function InputBox_NameDescription"



End Class
