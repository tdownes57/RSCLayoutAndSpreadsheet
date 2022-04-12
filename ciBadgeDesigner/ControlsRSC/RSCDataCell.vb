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


    ''Public Overrides Property Tag() As Object
    ''    Get
    ''        ''Added 4/6/2022 td
    ''        Return Textbox1a.Text
    ''    End Get
    ''    Set(value As String)
    ''        ''Added 4/6/2022 td
    ''        Textbox1a.Text = value
    ''    End Set
    ''End Property


    Public Property Tag_Text() As String
        Get
            ''Added 4/11/2022 td
            If (Textbox1a Is Nothing) Then Return ""
            If (Textbox1a.Tag Is Nothing) Then Return ""
            Return Textbox1a.Tag.ToString()
        End Get
        Set(value As String)
            ''Added 4/11/2022 td
            Textbox1a.Tag = value
        End Set
    End Property


End Class
