Public Class FormInputNameDescription
    ''
    ''Added 8/14/2022 thomas downes
    ''
    ''
    Public UserResponse_Name As String
    Public UserResponse_Description As String

    Private mod_singFactorHeight As Single
    Private mod_singFactorWidth As Single
    ''---Private mod_strFinalPrompt As String
    Private mod_strInstructions As String
    ''---Private mod_strDefaultResponse As String = ""
    Private mod_strPrompt_Name As String
    Private mod_strPrompt_Description As String


    Public Sub New(pstrInstructions As String,
               pstrPrompt_Name As String,
               pstrPrompt_Description As String,
                psingFactorWidth As Single,
                psingFactorHeight As Single)  '',
        ''---Optional pstrDefaultResponse As String = "")

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mod_singFactorHeight = psingFactorHeight
        mod_singFactorWidth = psingFactorWidth
        mod_strInstructions = pstrInstructions
        mod_strPrompt_Name = pstrPrompt_Name
        mod_strPrompt_Description = pstrPrompt_Description
        '----mod_strDefaultResponse = pstrDefaultResponse

        ''April 15  2022 ''LabelHowManyCaption.Text = pstrHowManyMsg
        LabelMainInstructions.Text = pstrInstructions
        LabelPrompt_Name.Text = pstrPrompt_Name
        LabelPrompt_Description.Text = pstrPrompt_Description
        ''---textUsersResponse.Text = pstrDefaultResponse

        Me.Width = CInt(Me.Width * psingFactorWidth)
        Me.Height = CInt(Me.Height * psingFactorHeight)

    End Sub




    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        ''
        ''Added 5/23/2022 & 4/14/2022 thomas d. 
        ''
        ''----Me.UsersEditedResponse = textUsersResponse.Text
        Me.UserResponse_Name = textUsersResponse_Name.Text
        Me.UserResponse_Description = textUsersResponse_Descr.Text
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

    Private Sub textUsersResponse_TextChanged(sender As Object, e As EventArgs) Handles textUsersResponse_Name.TextChanged

    End Sub

End Class