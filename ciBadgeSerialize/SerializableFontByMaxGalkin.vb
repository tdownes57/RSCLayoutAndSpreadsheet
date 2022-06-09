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
    ''---Property FontSize_Points As Single ''Added 6/08/2022 thomas downes
    ''
    ''Convert Pixels to Points
    ''
    '' points = pixels * 72 / 96   https://stackoverflow.com/questions/139655/convert-pixels-to-points
    ''
    ''     ---6/8/2022 thomas downes
    ''
    Public Property FontFamily As String
    Public Property Graphics_Unit As Drawing.GraphicsUnit
    ''6/08/2022 Public Property Size As Single
    Public Property Graphics_UnitSize As Single ''6/08/2022 Public Property Size
    Public Property Size_Pixels As Single ''points = pixels * 72 / 96  Added 6/8/2022 
    Public Property Size_Points As Single ''points = pixels * 72 / 96  Added 6/8/2022 
    Public Property Style As Drawing.FontStyle

    ''/// <summary>
    ''/// Intended for xml serialization purposes only
    ''/// </summary>
    ''Private SerializableFont() { }
    ''6/08/2022 ''Private Sub New()
    Public Sub New()
        ''
        ''This object is utilized in module
        ''
        ''    ciBadgeDesigner.Operations__Text.Open_Dialog_for_Font_TE1009
        ''
        ''---6/8/2022 thomas downes
        ';
    End Sub


    Public Sub New(par_font As Font)

        With par_font

            Me.FontFamily = .FontFamily.Name ''E.g. "Times New Roman". ---6/7/2022
            Me.Style = .Style
            Me.Graphics_Unit = .Unit ''Pixels, I would expect, hope. ---6/7/2022

            ''6/8/2022 Me.Size = .Size ''Size in Pixels !!??
            Me.Graphics_UnitSize = .Size ''Size in Graphics Unit.  ----6/8/2022 td

            ''Added 6/8/2022 thomas 
            Me.Size_Pixels = ConvertSize_ToPixels(.Unit, .Size)
            Me.Size_Points = ConvertSize_ToPoints(.Unit, .Size)

            ''
            ''Important, .Style includes .Bold, .Underline, .Italics. --6/7/2022
            ''
            ''See above.6/8/2022 ''Me.Style = .Style

        End With

    End Sub ''End of "Public Sub New(par_font As Font)"



    Public Shared Function ConvertSize_ToPixels(par_unit As GraphicsUnit, par_size As Single) As Single
        ''
        ''Added 6/8/2022 thomas d. 
        ''
        ''
        ''Convert Pixels to Points
        ''
        '' Ratio points : pixels :: 72 : 96
        '' Ratio pixels : points :: 96 : 72
        ''
        '' points = pixels * 72 / 96   https://stackoverflow.com/questions/139655/convert-pixels-to-points
        ''
        ''     ---6/8/2022 thomas downes
        ''
        Select Case par_unit
            Case GraphicsUnit.Pixel

                Return par_size

            Case GraphicsUnit.Point
                ''
                ''Convert Pixels to Points
                ''
                '' Ratio points : pixels :: 72 : 96
                '' Ratio pixels : points :: 96 : 72
                ''
                '' points = pixels * 72 / 96   https://stackoverflow.com/questions/139655/convert-pixels-to-points
                '' pixels = points * 96 / 72   https://stackoverflow.com/questions/139655/convert-pixels-to-points
                ''
                ''     ---6/8/2022 thomas downes
                ''
                Dim singlePoints As Single
                Dim singlePixelsOverPointsRatio As Single
                Dim singlePixels As Single

                singlePoints = par_size
                ''
                '' Ratio points : pixels :: 72 : 96
                '' Ratio pixels : points :: 96 : 72
                ''
                singlePixelsOverPointsRatio = 96 / 72

                singlePixels = (singlePoints * singlePixelsOverPointsRatio)

                Return singlePixels

            Case Else

                System.Diagnostics.Debugger.Break()

        End Select ''End of ""Select Case par_unit""

        Return 0.0

    End Function ''End of ""Public Shared Function ConvertSize_ToPixels""


    Public Shared Function ConvertSize_ToPoints(par_unit As GraphicsUnit, par_size As Single) As Single
        ''
        ''Added 6/8/2022 thomas d. 
        ''
        ''
        ''Convert Pixels to Points
        ''
        '' Ratio pixels : points :: 96 : 72
        '' Ratio points : pixels :: 72 : 96
        ''
        '' pixels = points * 96 / 72   https://stackoverflow.com/questions/139655/convert-pixels-to-points
        '' points = pixels  / (72 / 96)   https://stackoverflow.com/questions/139655/convert-pixels-to-points
        ''
        ''     ---6/8/2022 thomas downes
        ''
        Select Case par_unit
            Case GraphicsUnit.Point

                Return par_size

            Case GraphicsUnit.Pixel
                ''
                ''Convert Points to Pixels
                ''
                '' Ratio pixels : points :: 96 : 72
                '' Ratio points : pixels :: 72 : 96
                ''
                '' pixels = points * (96 / 72)   https://stackoverflow.com/questions/139655/convert-pixels-to-points
                '' points = pixels * (72 / 96)   https://stackoverflow.com/questions/139655/convert-pixels-to-points
                ''
                ''     ---6/8/2022 thomas downes
                ''
                Dim input_singlePixels As Single
                Dim singlePointsOverPixelsRatio As Single
                Dim output_singlePoints As Single

                input_singlePixels = par_size
                singlePointsOverPixelsRatio = 72 / 96
                output_singlePoints = (input_singlePixels * singlePointsOverPixelsRatio)

                Return output_singlePoints

            Case Else

                System.Diagnostics.Debugger.Break()

        End Select ''End of ""Select Case par_unit""

        Return 0.0

    End Function ''End of ""Public Shared Function ConvertSize_ToPoints""


    Public Sub LoadSizeViaGraphicsUnitSize()
        ''
        ''Added 6/8/2022 thomas d.
        ''


    End Sub ''End of ""Public Sub LoadSizeViaGraphicsUnitSize()""


    Private Function ConvertUnitSize_ToPixels() As Single

        ''Added 6/8/2022
        Return ConvertSize_ToPixels(Graphics_Unit, Graphics_UnitSize)

    End Function


    Private Function ConvertUnitSize_ToPoints() As Single

        ''Added 6/8/2022
        Return ConvertSize_ToPoints(Graphics_Unit, Graphics_UnitSize)

    End Function


    Public Shared Function DefaultFont() As SerializableFontByMaxGalkin
        ''
        ''Added 6/07/2022 thomas downes
        ''
        Dim objNewFontGalkin As New SerializableFontByMaxGalkin
        With objNewFontGalkin
            .FontFamily = "Times New Roman" '' "Arial"
            .Graphics_Unit = GraphicsUnit.Pixel
            .Graphics_UnitSize = 25
            .Style = FontStyle.Regular
            ''.Size_Pixels = ConvertUnitSize_ToPixels()
            ''.Size_Points = ConvertUnitSize_ToPoint()
            .LoadSizeViaGraphicsUnitSize()

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


    Public Function ToFont_AnyUnits() As Drawing.Font

        ''Added 6/7/2022 td
        If (String.IsNullOrEmpty(Me.FontFamily)) Then
            ''Added 6/7/2022 td
            Dim temp_galkin As SerializableFontByMaxGalkin
            temp_galkin = SerializableFontByMaxGalkin.DefaultFont()
            Me.FontFamily = temp_galkin.FontFamily
            ''6/8/2022 Me.Size = temp_galkin.Size
            Me.Style = temp_galkin.Style
            Me.Graphics_Unit = temp_galkin.Graphics_Unit
            Me.Graphics_UnitSize = temp_galkin.Graphics_UnitSize

        End If ''End of ""If (String.IsNullOrEmpty(Me.FontFamily)) Then""

        ''6/8/2022 Return New Drawing.Font(Me.FontFamily, Me.Size, Me.Style, Me.Graphics_Unit)
        Return New Drawing.Font(Me.FontFamily, Me.Graphics_UnitSize,
                                Me.Style, Me.Graphics_Unit)

    End Function ''End of ""Public Function ToFont() As Font""


    Public Function ToFont_UnitPixels() As Drawing.Font

        ''Added 6/7/2022 td
        If (String.IsNullOrEmpty(Me.FontFamily)) Then
            ''Added 6/7/2022 td
            Dim temp_galkin As SerializableFontByMaxGalkin
            temp_galkin = SerializableFontByMaxGalkin.DefaultFont()
            Me.FontFamily = temp_galkin.FontFamily
            ''6/8/2022 Me.Size = temp_galkin.Size
            Me.Style = temp_galkin.Style
            Me.Graphics_Unit = temp_galkin.Graphics_Unit
            Me.Graphics_UnitSize = temp_galkin.Graphics_UnitSize

        End If ''End of ""If (String.IsNullOrEmpty(Me.FontFamily)) Then""

        ''Added 6/8/2022 thomas d.
        Me.Size_Pixels = ConvertSize_ToPixels(Me.Graphics_Unit, Me.Graphics_UnitSize)
        Me.Size_Points = ConvertSize_ToPoints(Me.Graphics_Unit, Me.Graphics_UnitSize)

        ''6/8/2022 Return New Drawing.Font(Me.FontFamily, Me.Size, Me.Style, Me.Graphics_Unit)
        Return New Drawing.Font(Me.FontFamily, GraphicsUnit.Pixel,
                                Me.Style, Me.Size_Pixels)

    End Function ''End of ""Public Function ToFont_UnitPixels() As Font""


    Public Function GetDrawingFont() As Font
        ''
        ''This is an "Alias" function, i.e. it's redundant except for having a 
        ''  memorable name.---6/7/2022 
        ''
        ''Added 6/7/2022 td
        Return Me.ToFont_AnyUnits()

    End Function ''End of ""Public Function GetDrawingFont() As Font""



    Public Function ContainsNumericInconsistencies() As Boolean
        ''
        ''Added 6/8/2022  
        ''
        Dim bInconsistent As Boolean





        If (bInconsistent) Then

            System.Diagnostics.Debugger.Break()

        End If ''End of ""If (bInconsistent) Then""

        Return bInconsistent

    End Function



End Class ''End of ""Public Class ClassSerializableFontByMaxGalkin""
