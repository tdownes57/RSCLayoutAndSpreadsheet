''
''Added 5/31/2022 
''
Public Class Form1

    Private mod_textBox As TextBox
    Private mod_label As Label

    Private Sub ButtonNaive_Click(sender As Object, e As EventArgs) Handles ButtonNaive.Click
        ''
        ''Added 5/31/2022 
        ''
        Dim objFormSecond As New Form

        ''objForm.Controls.Add(TextBoxHelloWorld)
        ''objForm.Controls.Add(LabelHeader)

        If (mod_textBox Is Nothing) Then
            objFormSecond.Controls.Add(TextBoxHelloWorld)
            objFormSecond.Controls.Add(LabelHeader)
        ElseIf (mod_textBox IsNot Nothing) Then
            objFormSecond.Controls.Add(mod_textBox)
            objFormSecond.Controls.Add(mod_label)
        End If

        objFormSecond.Show()


    End Sub

    Private Sub ButtonImproved_Click(sender As Object, e As EventArgs) Handles ButtonImproved.Click
        ''
        ''Added 5/31/2022 
        ''
        Dim objForm2nd As Form '' As New Form

        objForm2nd = New Form

        ''objForm.Controls.Add(TextBoxHelloWorld)
        ''objForm.Controls.Add(LabelHeader)

        If (mod_textBox Is Nothing) Then
            objForm2nd.Controls.Add(TextBoxHelloWorld)
            objForm2nd.Controls.Add(LabelHeader)
        ElseIf (mod_textBox IsNot Nothing) Then
            objForm2nd.Controls.Add(mod_textBox)
            objForm2nd.Controls.Add(mod_label)
        End If

        ''
        ''Show 2nd form. 
        ''
        objForm2nd.ShowDialog()

        If (Not Me.Controls.Contains(TextBoxHelloWorld)) Then

            Me.Controls.Add(TextBoxHelloWorld)

        End If

        If (Not Me.Controls.Contains(LabelHeader)) Then

            Me.Controls.Add(LabelHeader)

        End If




    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 5/31/2022 
        ''
        mod_label = LabelHeader
        mod_textBox = TextBoxHelloWorld


    End Sub
End Class
