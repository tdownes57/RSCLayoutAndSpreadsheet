''
''Added 6/6/2022 thomas downes
''
''  https://stackoverflow.com/questions/1940127/how-to-xmlserialize-system-drawing-font-class?noredirect=1&lq=1
''
''  Answered by Elad https://stackoverflow.com/users/138585/elad
''
Imports System.Xml.Serialization ''Added 6/06/2022  thomas 
Imports System.Drawing


Public Class SerializableFontByElad
    ''
    ''Added 6/6/2022 thomas downes
    ''
    ''  https://stackoverflow.com/questions/1940127/how-to-xmlserialize-system-drawing-font-class?noredirect=1&lq=1
    ''
    ''  Answered by Elad https://stackoverflow.com/users/138585/elad
    ''
    Public Sub New()

        FontValue = Nothing

    End Sub

    Public Sub New(par_font As Font)

        FontValue = par_font

    End Sub


    <XmlIgnore>
    Public Property FontValue As System.Drawing.Font '' { Get; Set; }


    <XmlElement("FontValue")>
    Public Property SerializeFontAttribute As String
        Get
            Return FontXmlConverter.ConvertToString(FontValue)
        End Get
        Set(value As String)
            FontValue = FontXmlConverter.ConvertToFont(value)
        End Set
    End Property









End Class ''End of ""Public Class SerializableFontByElad""
