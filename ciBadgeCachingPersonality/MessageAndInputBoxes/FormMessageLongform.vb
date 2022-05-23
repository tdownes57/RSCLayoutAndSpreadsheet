Public Class FormMessageLongform

    ''Private mod_boolUseTextbox As Boolean
    Private mod_singFactorHeight As Single
    Private mod_singFactorWidth As Single
    Private mod_strMainHeading As String
    ''Private mod_boolDecimalValuesOK As Boolean
    ''Private mod_singLimitMin As Single
    ''Private mod_singLimitMax As Single

    Public Sub New(pstrMainHeading As String,
                    psingFactorWidth As Single,
                    psingFactorHeight As Single,
                   pstrOriginalTextValue As String,
                   pboolShowCancelButton As Boolean)

        ''psingLimitOfNumberMin As Single,
        ''psingLimitOfNumberMax As Single,
        ''Optional pboolUseTextbox As Boolean = False,
        ''Optional pboolDecimalValuesOK As Boolean = False)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ''mod_boolUseTextbox = pboolUseTextbox
        mod_singFactorHeight = psingFactorHeight
        mod_singFactorWidth = psingFactorWidth
        mod_strMainHeading = pstrMainHeading
        ''mod_boolDecimalValuesOK = pboolDecimalValuesOK
        ''mod_singLimitMin = psingLimitOfNumberMin
        ''mod_singLimitMax = psingLimitOfNumberMax

        ''April 15  2022 ''LabelHowManyCaption.Text = pstrHowManyMsg
        LabelMainPrompt.Text = pstrMainHeading
        TextBox1.Text = pstrOriginalTextValue

        Me.Width = CInt(Me.Width * psingFactorWidth)
        Me.Height = CInt(Me.Height * psingFactorHeight)

        ''Added 5/13/2022
        Me.ButtonCancel.Visible = pboolShowCancelButton

        ''//If (pboolUseTextbox) Then textHowMany.Visible = pboolUseTextbox 
        ''textHowMany.Visible = pboolUseTextbox
        ''NumericUpDown1.Visible = (Not pboolUseTextbox)
        ''NumericUpDown1.Maximum = CDec(psingLimitOfNumberMax)
        ''NumericUpDown1.Minimum = CDec(psingLimitOfNumberMin)

    End Sub


    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click

        ''Added 5/13/2022
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()


    End Sub


    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click

        ''Added 5/13/2022
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub
End Class