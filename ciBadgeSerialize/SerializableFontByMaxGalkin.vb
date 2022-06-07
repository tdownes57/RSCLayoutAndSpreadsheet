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
    Public Property Graphics_Unit As Drawing.GraphicsUnit
    Public Property Size As Single
    Public Property Style As Drawing.FontStyle

    ''/// <summary>
    ''/// Intended for xml serialization purposes only
    ''/// </summary>
    ''Private SerializableFont() { }
    Private Sub New()

    End Sub

    Public Sub New(par_font As Font)

        With par_font

            Me.FontFamily = .FontFamily.Name ''E.g. "Times New Roman". ---6/7/2022
            Me.Graphics_Unit = .Unit ''Pixels, I would expect, hope. ---6/7/2022
            Me.Size = .Size ''Size in Pixels !!??

            ''
            ''Important, .Style includes .Bold, .Underline, .Italics. --6/7/2022
            ''
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
        Return objNewFontGalkin ''Added 6/07/2022 

    End Function ''End of ""Public Shared Function DefaultFont()""


    Public Shared Function FromFont(par_font As Font) As SerializableFontByMaxGalkin

        Return New SerializableFontByMaxGalkin(par_font)

    End Function ''End of ""Public Shared Function FromFont"


    Public Shared Function GetFontMaxGalkin(par_font As Font) As SerializableFontByMaxGalkin
        ''
        ''This is an "Alias" function, i.e. it's redundant except for having a 
        ''  memorable name.---6/7/2022 
        ''
        Return New SerializableFontByMaxGalkin(par_font)

    End Function ''End of ""Public Shared Function FromFont"


    Public Function ToFont() As Drawing.Font

        ''Added 6/7/2022 td
        If (String.IsNullOrEmpty(Me.FontFamily)) Then
            ''Added 6/7/2022 td
            Dim temp_galkin As SerializableFontByMaxGalkin
            temp_galkin = SerializableFontByMaxGalkin.DefaultFont()
            Me.FontFamily = temp_galkin.FontFamily
            Me.Size = temp_galkin.Size
            Me.Style = temp_galkin.Style
            Me.Graphics_Unit = temp_galkin.Graphics_Unit
        End If ''End of ""If (String.IsNullOrEmpty(Me.FontFamily)) Then""

        Return New Drawing.Font(Me.FontFamily, Me.Size, Me.Style, Me.Graphics_Unit)

    End Function ''End of ""Public Function ToFont() As Font""


    Public Function GetDrawingFont() As Font
        ''
        ''This is an "Alias" function, i.e. it's redundant except for having a 
        ''  memorable name.---6/7/2022 
        ''
        ''Added 6/7/2022 td
        Return Me.ToFont()

    End Function ''End of ""Public Function GetDrawingFont() As Font""


End Class ''End of ""Public Class ClassSerializableFontByMaxGalkin""
