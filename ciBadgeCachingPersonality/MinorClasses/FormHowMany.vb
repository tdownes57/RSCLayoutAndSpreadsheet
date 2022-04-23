Option Explicit On ''Added 4/15/2022 td
Option Strict On ''Added 4/15/2022 td

Public Class FormHowMany
    ''
    ''Added 4/14/2022 thomas downes
    ''
    Public HowManySpecified As Integer ''Added 4/14/2022 thomas downes 

    Private mod_boolUseTextbox As Boolean
    Private mod_singFactorHeight As Single
    Private mod_singFactorWidth As Single
    Private mod_strHowManyMsg As String
    Private mod_boolDecimalValuesOK As Boolean
    Private mod_singLimitMin As Single
    Private mod_singLimitMax As Single

    Public Sub New(pstrHowManyMsg As String,
                    psingFactorWidth As Single,
                    psingFactorHeight As Single,
                    psingLimitOfNumberMin As Single,
                    psingLimitOfNumberMax As Single,
                    Optional pboolUseTextbox As Boolean = False,
                    Optional pboolDecimalValuesOK As Boolean = False)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mod_boolUseTextbox = pboolUseTextbox
        mod_singFactorHeight = psingFactorHeight
        mod_singFactorWidth = psingFactorWidth
        mod_strHowManyMsg = pstrHowManyMsg
        mod_boolDecimalValuesOK = pboolDecimalValuesOK
        mod_singLimitMin = psingLimitOfNumberMin
        mod_singLimitMax = psingLimitOfNumberMax

        ''April 15  2022 ''LabelHowManyCaption.Text = pstrHowManyMsg
        LabelMainPrompt.Text = pstrHowManyMsg

        Me.Width = CInt(Me.Width * psingFactorWidth)
        Me.Height = CInt(Me.Height * psingFactorHeight)

        ''//If (pboolUseTextbox) Then textHowMany.Visible = pboolUseTextbox 
        textHowMany.Visible = pboolUseTextbox
        NumericUpDown1.Visible = (Not pboolUseTextbox)
        NumericUpDown1.Maximum = CDec(psingLimitOfNumberMax)
        NumericUpDown1.Minimum = CDec(psingLimitOfNumberMin)

    End Sub


    Private Function IsNumeric_OtherChecks() As Boolean
        ''
        ''Added 4/14/2022 thomas downes
        ''
        Dim boolDecimalFound As Boolean
        boolDecimalFound = textHowMany.Text.Trim().Contains(".")

        If (mod_boolDecimalValuesOK) Then

            Return IsNumeric(textHowMany.Text.Trim())

        ElseIf (boolDecimalFound) Then

            lblRedMessageNonnumeric.Text = "No decimal values allowed."
            lblRedMessageNonnumeric.Visible = True
            Return False

        ElseIf IsNumeric(textHowMany.Text.Trim()) Then

            If (CSng(textHowMany.Text.Trim()) > mod_singLimitMax) Then

                lblRedMessageNonnumeric.Text = "Number is above the limit."
                lblRedMessageNonnumeric.Visible = True
                Return False

            ElseIf (CSng(textHowMany.Text.Trim()) < mod_singLimitMin) Then

                lblRedMessageNonnumeric.Text = "Number is below the limit."
                lblRedMessageNonnumeric.Visible = True
                Return False

            Else
                Return IsNumeric(textHowMany.Text.Trim())

            End If ''End of ""If (CSng(textHowMany.Text.Trim()) > mod_singLimitMax) Then""

        Else

            Return IsNumeric(textHowMany.Text.Trim())

        End If ''End of ""If (mod_boolDecimalValuesOK) Then.... ElseIf.... Else....

    End Function ''End of "" Private Function IsNumeric_OtherChecks() As Boolean""


    Private Sub FormHowMany_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        ''
        ''Added 4/14/2022 thomas d. 
        ''
        If (mod_boolUseTextbox) Then
            ''
            ''The textbox.  
            ''
            textHowMany.Text = textHowMany.Text.Trim()

            If (IsNumeric_OtherChecks()) Then
                ''---If (IsNumeric(textHowMany.Text.Trim()) Then 

                Me.HowManySpecified = CInt(textHowMany.Text.Trim())
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            ElseIf (textHowMany.Text.Trim().Length > 0) Then

                MessageBoxTD.Show_Statement("Your value is not numeric, please type a number.")

            ElseIf (textHowMany.Text.Trim().Length = 0) Then

                MessageBoxTD.Show_Statement("No number is specified, please type a number.")

            End If ''End of ""If (IsNumeric(textHowMany.Text)) Then .... ElseIf ...."

        ElseIf (Not mod_boolUseTextbox) Then

            Me.HowManySpecified = CInt(NumericUpDown1.Value)
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End If ''eNd of "If (mod_boolUseTextbox) Then... ElseIf.... "



    End Sub


    Private Sub textHowMany_TextChanged(sender As Object, e As EventArgs) Handles textHowMany.TextChanged
        ''
        ''Added 4/14/2022 td
        ''
        If ("" = textHowMany.Text) Then
            ''No characters in the box, so no message is needed. 
            lblRedMessageNonnumeric.Visible = False ''Hide any message, not applicable.

        ElseIf ("" = textHowMany.Text.Trim()) Then

            lblRedMessageNonnumeric.Text = "Missing numeric value"
            lblRedMessageNonnumeric.Visible = True

        ElseIf (Not IsNumeric(textHowMany.Text.Trim())) Then
            ''This is the normal reason for the message, so let's use the Tag string. 
            lblRedMessageNonnumeric.Text = lblRedMessageNonnumeric.Tag.ToString()
            lblRedMessageNonnumeric.Visible = True

        ElseIf (Not IsNumeric_OtherChecks()) Then

            lblRedMessageNonnumeric.Text = "No decimal values allowed."
            lblRedMessageNonnumeric.Visible = True

        Else
            ''Numeric value found.  
            lblRedMessageNonnumeric.Visible = False ''False. Not a problem, not applicable.

        End If ''Endof ""If ("" = textHowMany.Text.Trim()) Then.... ElseIf ... ElseIf...""


    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click

        ''Added 4/14/2022 thomas d. 
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub
End Class