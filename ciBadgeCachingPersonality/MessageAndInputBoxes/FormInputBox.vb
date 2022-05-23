''
''Added 5/23/2022 thomas downes
''
Public Class FormInputBox
    ''
    ''Added 5/23/2022 thomas downes
    ''
    ''
    ''Added 4/14/2022 thomas downes
    ''
    Public UsersEditedResponse As String

    Private mod_singFactorHeight As Single
    Private mod_singFactorWidth As Single
    Private mod_strFinalPrompt As String
    Private mod_strInstructions As String
    Private mod_strDefaultResponse As String

    Public Sub New(pstrInstructions As String,
                   pstrFinalPrompt As String,
                    psingFactorWidth As Single,
                    psingFactorHeight As Single,
                   Optional pstrDefaultResponse As String = "")

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mod_singFactorHeight = psingFactorHeight
        mod_singFactorWidth = psingFactorWidth
        mod_strInstructions = pstrInstructions
        mod_strFinalPrompt = pstrFinalPrompt
        mod_strDefaultResponse = pstrDefaultResponse

        ''April 15  2022 ''LabelHowManyCaption.Text = pstrHowManyMsg
        LabelMainInstructions.Text = pstrInstructions
        LabelFinalPrompt.Text = pstrFinalPrompt
        textUsersResponse.Text = pstrDefaultResponse

        Me.Width = CInt(Me.Width * psingFactorWidth)
        Me.Height = CInt(Me.Height * psingFactorHeight)

    End Sub




    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        ''
        ''Added 5/23/2022 & 4/14/2022 thomas d. 
        ''
        Me.UsersEditedResponse = textUsersResponse.Text
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub


    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click

        ''Added 4/14/2022 thomas d. 
        ''4/26/2022 ''Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub FormInputBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class