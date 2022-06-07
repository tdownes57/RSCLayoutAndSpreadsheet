''
''Added 6/6/2022 thomas downes
''
''  https://stackoverflow.com/questions/1940127/how-to-xmlserialize-system-drawing-font-class?noredirect=1&lq=1
''
''  Answered by Elad https://stackoverflow.com/users/138585/elad
''
Imports System.Drawing

''' <summary>
''' Font descriptor, that can be xml-serialized
''' </summary>
<Serializable>
Public Class SerializableFontByMaxGalkin
    ''
    ''Added 6/6/2022 thomas downes
    ''
    ''  https://stackoverflow.com/questions/1940127/how-to-xmlserialize-system-drawing-font-class?noredirect=1&lq=1
    ''
    ''  Answered by Elad https://stackoverflow.com/users/138585/elad
    ''
    ''Public String FontFamily { Get; Set; }
    ''Public GraphicsUnit GraphicsUnit { Get; Set; }
    ''Public float Size { Get; Set; }
    ''Public FontStyle Style { Get; Set; }

    Public Property FontFamily As String
    Public Property Graphics_Unit As GraphicsUnit
    Public Property Size As Single
    Public Property Style As FontStyle

    ''/// <summary>
    ''/// Intended for xml serialization purposes only
    ''/// </summary>
    ''Private SerializableFont() { }
    Private Sub New()

    End Sub

    Public Sub New(par_font As Font)

        With par_font
            Me.FontFamily = .FontFamily.Name
            Me.Graphics_Unit = .Unit
            Me.Size = .Size
            Me.Style = .Style
        End With

    End Sub


    Public Shared Function DefaultFont() As SerializableFontByMaxGalkin
        ''
        ''Added 6/07/2022 thomas downes
        ''
        Dim objNewFontGalkin As New SerializableFontByMaxGalkin
        With objNewFontGalkin
            .FontFamily = "Times New Roman" '' "Arial"
            .Graphics_Unit = GraphicsUnit.Pixel
            .Size = 25
            .Style = FontStyle.Regular
        End With

    End Function ''End of ""Public Shared Function DefaultFont()""


    Public Shared Function FromFont(par_font As Font) As SerializableFontByMaxGalkin

        Return New SerializableFontByMaxGalkin(par_font)

    End Function


    Public Function ToFont() As Font

        Return New Font(Me.FontFamily, Me.Size, Me.Style, Me.Graphics_Unit)

    End Function

End Class ''End of ""Public Class ClassSerializableFontByMaxGalkin""
