''
''Added 8//14/2019 td  
''
Public Class CtlGraphPopMenuAlign
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        ''
        ''Added 8//14/2019 td  
        ''
        Me.SendToBack()
        Me.Visible = False ''Hide it, it's not needed anymore.  ---8/14/2019 td

    End Sub

    Public Sub SizeToExpectations()
        ''
        ''Added 8//14/2019 td  
        ''
        With PictureBox1

            Me.Width = (.Left + .Width + 3)

            Me.Height = (.Top + .Height + 3)

        End With

    End Sub

    Private Sub CtlGraphPopMenuEditGroup_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged

        ''Added 8//14/2019 td  
        SizeToExpectations()

    End Sub

End Class
