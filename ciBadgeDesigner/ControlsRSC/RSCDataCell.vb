''
''Added 4/7/2022 thomas downes
''
Public Class RSCDataCell
    ''
    ''Added 4/7/2022 thomas downes
    ''
    Public Overrides Property Text() As String
        Get
            ''Added 4/6/2022 td
            Return Textbox1a.Text
        End Get
        Set(value As String)
            ''Added 4/6/2022 td
            Textbox1a.Text = value
        End Set
    End Property


    Public Property Text_CellValue() As String
        Get
            ''Added 4/6/2022 td
            Return Textbox1a.Text
        End Get
        Set(value As String)
            ''Added 4/6/2022 td
            Textbox1a.Text = value
        End Set
    End Property

End Class
