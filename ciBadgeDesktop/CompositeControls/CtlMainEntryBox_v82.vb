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

    Public Property FieldValue As String
        ''
        ''Added 8/7/2019 td
        ''
        Get
            Return TextBox1.Text
        End Get
        Set(value As String)
            TextBox1.Text = value
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

    Private Sub CtlMainEntryBox_v82_FontChanged(sender As Object, e As EventArgs) Handles MyBase.FontChanged
        ''
        ''Added 8/7/2019 td
        ''
        Label1.Font = Me.Font
        TextBox1.Font = Me.Font

    End Sub

    Private Sub CtlMainEntryBox_v82_ForeColorChanged(sender As Object, e As EventArgs) Handles MyBase.ForeColorChanged
        ''
        ''Added 8/7/2019 td
        ''
        TextBox1.ForeColor = Me.ForeColor
        Label1.ForeColor = Color.Black

    End Sub
End Class
