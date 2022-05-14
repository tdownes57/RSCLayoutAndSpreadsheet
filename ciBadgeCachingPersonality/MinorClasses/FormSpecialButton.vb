''
''Added 5/13/2022 thomas downes
''
Public Class FormSpecialButton
    ''
    ''Added 5/13/2022 thomas downes
    ''
    Public SpecialButtonWasPressed As Boolean

    Private mod_singFactorHeight As Single
    Private mod_singFactorWidth As Single
    Private mod_strMainHeading As String

    Public Sub New(pstrMainHeading As String,
                    psingFactorWidth As Single,
                    psingFactorHeight As Single,
                   pstrLongformTextValue As String,
                   pstrCaptionSpecialButton As String)
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

        LabelMainPrompt.Text = pstrMainHeading
        TextBox1.Text = pstrLongformTextValue
        ButtonSpecialButton.Text = pstrCaptionSpecialButton ''Added 5/13/2022 td 

        Me.Width = CInt(Me.Width * psingFactorWidth)
        Me.Height = CInt(Me.Height * psingFactorHeight)


    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click

        ''Added 5/13/2022 td
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub ButtonSpecialButton_Click(sender As Object, e As EventArgs) Handles ButtonSpecialButton.Click

        ''Added 5/13/2022 td
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.SpecialButtonWasPressed = True
        Me.Close()

    End Sub

    Private Sub FormSpecialButton_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click

        ''Added 5/13/2022 td
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub
End Class