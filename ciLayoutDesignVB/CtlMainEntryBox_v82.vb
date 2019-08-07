''
''Added 8/7/2019 thomas downes   
''

Public Class CtlMainEntryBox_v82
    ''
    ''Added 8/7/2019 thomas downes   
    ''
    Private mod_intWidthOfBoxByPercent As Integer

    Public Property LabelText As String
        ''
        ''Added 8/7/2019 td
        ''
        Get
            Return Label1.Text
        End Get
        Set(value As String)
            Label1.Text = value
        End Set
    End Property

    Public Property WidthOfBoxByPercent As Integer
        ''
        ''Added 8/7/2019 td
        ''
        Get
            Return mod_intWidthOfBoxByPercent
        End Get
        Set(value As Integer)
            mod_intWidthOfBoxByPercent = value
            If (20 < value And value < 80) Then
                TextBox1.Width = CInt(value * Me.Width / 100)
                TextBox1.Left = Me.Width - 10 - TextBox1.Width
            End If
        End Set
    End Property

    Private Sub CtlFldLabelWithTextbox_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
