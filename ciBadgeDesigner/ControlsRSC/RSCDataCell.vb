''
''Added 4/7/2022 thomas downes
''
Imports ciBadgeInterfaces ''Added 8/14/2019 thomas d. 
''Imports ciBadgeElements ''Added 9/18/2019 td 
''Imports ciBadgeDesigner ''Added 3/8/2022 td  
''Imports System.Drawing ''Added 10/01/2019 td 
''Imports __RSCWindowsControlLibrary ''Added 1/4/2022 td
''Imports ciBadgeFields ''Added 3/8/2022 thomas downes
''Imports ciBadgeCachePersonality ''Added 3/14/2022 
Imports ciBadgeRecipients ''Added 3/22/2022 td

Public Class RSCDataCell
    ''
    ''Added 4/7/2022 thomas downes
    ''
    Public Recipient As ciBadgeRecipients.ClassRecipient ''Added 4/12/2022 td

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


    Public Sub SaveDataToRecipientField(par_enumCIBField As EnumCIBFields)
        ''
        ''Added 4/12/2022 
        ''
        If (Me.Recipient Is Nothing) Then Throw New Exception("Recipient is a null reference")

        ''4/12/2022 td''Me.Recipient.SaveDataByField(par_enumCIBField, Textbox1a.Text)
        Me.Recipient.SaveTextValue(par_enumCIBField, Textbox1a.Text)

        ''Let's indicate that the data has been saved. 
        Textbox1a.Tag = Textbox1a.Text

    End Sub ''End of ""Public Sub SaveDataToRecipientField(enumCIBField As EnumCIBFields)""

End Class
