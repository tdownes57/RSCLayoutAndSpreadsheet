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
            ''The three-lines version.  Most popular choice!!   LOL. 
            ''
            MessageBox.Show(pstrStatement, "MessageBoxTD-Statement",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)

        ElseIf (String.IsNullOrEmpty(pstrStatement3)) Then
            ''
            ''The two-lines version.
            ''
            MessageBox.Show(pstrStatement & _vbCrLf_Deux &
                            pstrStatement2, "MessageBoxTD-Statement",
                           MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            ''
            ''The three-lines version.
            ''
            MessageBox.Show(pstrStatement & _vbCrLf_Deux &
                            pstrStatement2 & _vbCrLf_Deux &
                            pstrStatement3, "MessageBoxTD-Statement",
                           MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If ''END OF ""If (String.IsNullOrEmpty(pstrStatement2)) Then ... ElseIf... Else...""


    End Sub ''Public Shared Sub Show_Statement


    Public Shared Sub Show_Statement_TwoLines(pstrStatement_Line1 As String,
                                     Optional pstrStatement_Line2 As String = "")
        ''
        ''Added 12/28/2021 thomas downes
        ''
        ''March21 2022''MessageBox.Show(pstrStatement, "MessageBoxTD-Statement", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ''May 23 2022''MessageBox.Show(pstrStatement_Line1 & _vbCrLf_Deux &
        ''   pstrStatement_Line2, "MessageBoxTD-Statement",
        ''   MessageBoxButtons.OK, MessageBoxIcon.Information)
        MessageBox.Show(Strings.RTrim(pstrStatement_Line1 & _vbCrLf_Deux &
                        pstrStatement_Line2), "MessageBoxTD-Statement",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub ''end of ""Public Shared Sub Show_Statement_TwoLines""



    Public Shared Sub Show_FormatNumbers(pstrStatement_Line1 As String,
                                         pintNumber1 As Integer,
                                        Optional pintNumber2 As Integer = -1)
        ''
        ''Added 5/25/2022 thomas downes
        ''
        Dim strLine1_WithNumbers As String

        If (pintNumber2 = -1) Then
            strLine1_WithNumbers = String.Format(pstrStatement_Line1, pintNumber1)
        Else
            strLine1_WithNumbers = String.Format(pstrStatement_Line1, pintNumber1, pintNumber2)
        End If

        MessageBox.Show(strLine1_WithNumbers, "MessageBoxTD-Statement",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub ''End of ""Public Shared Sub Show_FormatNumbers""



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


    Public Shared Function Show_Confirm(pstrConfirmationQuestion As String,
                                        Optional par_defaultButton As MessageBoxDefaultButton =
                                           MessageBoxDefaultButton.Button1) As Boolean
        ''
        ''Added 2/17/2022 thomas downes
        ''
        Dim res As DialogResult

        ''6/2/2022 res = MessageBox.Show(pstrConfirmationQuestion & _vbCrLf_Deux &
        ''                       "Confirm by pressing Yes.", "MessageBoxTD-Confirm",
        ''                       MessageBoxButtons.YesNoCancel,
        ''                       MessageBoxIcon.Question)

        Const c_strBoxTitle As String = "MessageBoxTD-Confirm"

        res = MessageBox.Show(pstrConfirmationQuestion & _vbCrLf_Deux &
                               "Confirm by pressing Yes.",
                               c_strBoxTitle,
                               MessageBoxButtons.YesNoCancel,
                               MessageBoxIcon.Question,
                               par_defaultButton)

        Return (res = DialogResult.Yes)

    End Function ''End of ""Public Shared Function Show_Confirm"" 


    ''Public Shared Function AskHowMany(pstrHowMany As String,
    ''                psingFactorWidth As Single,
    ''                psingFactorHeight As Single,
    ''                psingLimitOfNumberMin As Single,
    ''                psingLimitOfNumberMax As Single,
    ''                Optional pboolUseTextbox As Boolean = False,
    ''                Optional pboolDecimalValuesOK As Boolean = False,
    ''                Optional ByRef prefUserCancelled As Boolean = False) As Integer
    ''    ''
    ''    ''Added 12/28/2021 thomas downes
    ''    ''
    ''    Dim formToShow As FormHowMany

    ''    formToShow = New FormHowMany(pstrHowMany, psingFactorWidth, psingFactorHeight,
    ''        psingLimitOfNumberMin, psingLimitOfNumberMax, pboolUseTextbox, pboolDecimalValuesOK)

    ''    formToShow.ShowDialog()

    ''    If (formToShow.DialogResult = DialogResult.Cancel) Then
    ''        prefUserCancelled = True  ''Aded 5/13/2022
    ''        Return -1
    ''    ElseIf (formToShow.DialogResult <> DialogResult.OK) Then
    ''        prefUserCancelled = True  ''Aded 5/13/2022
    ''        Return -1
    ''    End If

    ''    Return formToShow.HowManySpecified

    ''End Function ''End of "Public Shared Function AskHowMany"


    ''Public Shared Function Show_Editor(pstrHeading As String,
    ''                                   pstrOriginalTextToEdit As String,
    ''             psingFactorWidth As Single,
    ''             psingFactorHeight As Single,
    ''             ByRef pstrFinalEditedText As String) As DialogResult
    ''    ''
    ''    ''Added 12/28/2021 thomas downes
    ''    ''
    ''    Dim formToShow As FormTextEditor

    ''    formToShow = New FormTextEditor(pstrHeading,
    ''                                 psingFactorWidth, psingFactorHeight,
    ''                                  pstrOriginalTextToEdit)

    ''    formToShow.ShowDialog()

    ''    ''If (formToShow.DialogResult = DialogResult.Cancel) Then Return -1
    ''    ''If (formToShow.DialogResult <> DialogResult.OK) Then Return -1

    ''    If (formToShow.DialogResult = DialogResult.OK) Then

    ''        pstrFinalEditedText = formToShow.EditedOutputValue

    ''    Else
    ''        ''Return the original text, unedited. 
    ''        pstrFinalEditedText = pstrOriginalTextToEdit

    ''    End If ''End of ""If (formToShow.DialogResult = ......)

    ''    Return formToShow.DialogResult

    ''End Function ''End of "Public Shared Function Show_Editor"


    ''Public Shared Function Show_StatementLongform(pstrHeading As String,
    ''                                   pstrTextInLongorm As String,
    ''             psingFactorWidth As Single,
    ''             psingFactorHeight As Single,
    ''             Optional pboolShowCancelButton As Boolean = True) As DialogResult
    ''    ''
    ''    ''Added 5/13/2022 thomas downes
    ''    ''
    ''    Dim formToShow As FormMessageLongform

    ''    formToShow = New FormMessageLongform(pstrHeading,
    ''                                 psingFactorWidth, psingFactorHeight,
    ''                                  pstrTextInLongorm, pboolShowCancelButton)

    ''    formToShow.ShowDialog()
    ''    Return formToShow.DialogResult

    ''End Function ''End of "Public Shared Function Show_StatementLongform"


    ''Public Shared Function Show_SpecialButton(pstrHeading As String,
    ''                                   pstrTextInLongorm As String,
    ''             psingFactorWidth As Single,
    ''             psingFactorHeight As Single,
    ''             pstrCaptionOfButton As String,
    ''             ByRef pref_bUserPressedIt As Boolean) As DialogResult
    ''    ''
    ''    ''Added 5/13/2022 thomas downes
    ''    ''
    ''    Dim formToShow As FormSpecialButton

    ''    formToShow = New FormSpecialButton(pstrHeading,
    ''                                 psingFactorWidth, psingFactorHeight,
    ''                                  pstrTextInLongorm, pstrCaptionOfButton)

    ''    formToShow.ShowDialog()
    ''    pref_bUserPressedIt = formToShow.SpecialButtonWasPressed
    ''    Return formToShow.DialogResult

    ''End Function ''End of "Public Shared Function Show_SpecialButton"


    ''Public Shared Function InputBox_Longform(pstrInstructions As String,
    ''                                         pstrFinalPrompt As String,
    ''                psingFactorWidth As Single,
    ''                psingFactorHeight As Single,
    ''                Optional ByRef prefUserCancelled As Boolean = False,
    ''                Optional pstrDefaultResponse As String = "") As String
    ''    ''
    ''    ''Added 5/23/2022 thomas downes
    ''    ''
    ''    Dim formToShow As FormInputBox

    ''    formToShow = New FormInputBox(pstrInstructions, pstrFinalPrompt,
    ''                                  psingFactorWidth, psingFactorHeight,
    ''                                  pstrDefaultResponse)

    ''    formToShow.ShowDialog()

    ''    If (formToShow.DialogResult = DialogResult.Cancel) Then
    ''        prefUserCancelled = True  ''Aded 5/13/2022
    ''        Return ""
    ''    ElseIf (formToShow.DialogResult <> DialogResult.OK) Then
    ''        prefUserCancelled = True  ''Aded 5/13/2022
    ''        Return ""
    ''    End If

    ''    Return formToShow.UsersEditedResponse

    ''End Function ''End of "Public Shared Function InputBox_Longform"



End Class
