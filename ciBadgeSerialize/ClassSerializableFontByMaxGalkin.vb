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
Public Class ClassSerializableFontByMaxGalkin
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
            FontFamily = .FontFamily.Name
            Graphics_Unit = .Unit
            Size = .Size
            Style = .Style
        End With

    End Sub


    Public Shared Function FromFont(par_font As Font) As ClassSerializableFontByMaxGalkin

        Return New ClassSerializableFontByMaxGalkin(par_font)

    End Function

    Public Function ToFont() As Font

        Return New Font(Me.FontFamily, Me.Size, Me.Style, Me.Graphics_Unit)

    End Function

End Class ''End of ""Public Class ClassSerializableFontByMaxGalkin""
