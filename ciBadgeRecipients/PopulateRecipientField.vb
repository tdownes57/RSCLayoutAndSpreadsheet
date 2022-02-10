''
''Added 2/10/2022 td
''

Public Class PopulateRecipientField
    ''
    ''Added 2/10/2022 td
    ''
    Public Property WidthOfLeftPane As Integer
        Get
            Return SplitContainer1.SplitterDistance
        End Get
        Set(value As Integer)

            SplitContainer1.SplitterDistance = value

        End Set

    End Property


    Private Sub PopulateRecipientField_Load(sender As Object, e As EventArgs) Handles MyBase.Load




    End Sub
End Class
