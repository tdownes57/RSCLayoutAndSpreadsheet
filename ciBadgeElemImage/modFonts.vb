
''
''Added 8/16/2019 td  
''
Imports System.Drawing ''Added 9/19/2019 td 
Imports System.Drawing.Text ''Added 8/16/2019 td  
Imports ciBadgeSerialize ''Added 6/10/2022 td

Module modFonts
    ''
    ''Added 8/16/2019 td  
    ''
    Public AskedAlignmentQuestion As Boolean ''Added 8/16/2019 td  
    Public Const vbCrLf_Deux As String = (vbCrLf & vbCrLf) ''Added 8/16/2019 td
    Public UseAverageLineForAlignment As Boolean ''Added 8/16/2019 td   

    Public Function ScaledFont(par_font As Font, par_scale As Double) As Font
        ''
        ''Added 9/8/2019 thomas d. 
        ''
        Dim sinNewSize_Pixels As Single ''Integer
        Dim sinNewSize_Points As Single ''Integer

        Select Case par_font.Unit

            Case GraphicsUnit.Pixel

                sinNewSize_Pixels = CInt(par_font.Size * par_scale)

            Case GraphicsUnit.Point

                sinNewSize_Points = CInt(par_font.Size * par_scale)
                sinNewSize_Pixels = ConvertSizeToPixels(par_font.Unit, par_font.Size)

            Case Else

                System.Diagnostics.Debugger.Break()

        End Select ''End of ""Select Case par_font.Unit""


        ''June10 2022  Return MakeFont(par_font.FontFamily.Name, intNewSize)
        Return MakeFont(par_font.FontFamily.Name, sinNewSize_Pixels, par_font.Style)


    End Function ''End of "Public Function ScaledFont()"


    Public Function MakeFont(par_strFamilyName As String, par_sizeInPixels As Single,
                             par_fontStyle As FontStyle)
        ''---                   Optional pboolStyleBold As Boolean = False,
        ''---                   Optional pboolStyleItalics As Boolean = False,
        ''---                   Optional pboolStyleUnderline As Boolean = False) As Font
        ''
        ''9/6/2019 thomas downes  
        ''
        ''   FontFamily 
        ''
        Dim new_font As Font
        Dim new_fontFamily As FontFamily
        ''6/10/2022 Dim new_fontstyle As FontStyle

        new_fontFamily = New FontFamily(par_strFamilyName)

        ''6/10/2022 new_fontstyle = New FontStyle()

        ''6/10/2022 Select Case True
        ''    Case (pboolStyleBold And pboolStyleUnderline And pboolStyleItalics)
        ''        new_fontstyle = (FontStyle.Bold Or FontStyle.Underline Or FontStyle.Italic)
        ''    Case (pboolStyleUnderline And pboolStyleItalics)
        ''        new_fontstyle = (FontStyle.Underline Or FontStyle.Italic)
        ''    Case (pboolStyleBold And pboolStyleItalics)
        ''        new_fontstyle = (FontStyle.Bold Or FontStyle.Italic)
        ''    Case (pboolStyleBold And pboolStyleUnderline)
        ''        new_fontstyle = (FontStyle.Bold Or FontStyle.Underline)
        ''    Case (pboolStyleBold)
        ''        new_fontstyle = (FontStyle.Bold)
        ''    Case (pboolStyleUnderline)
        ''        new_fontstyle = (FontStyle.Underline)
        ''End Select

        ''6/10/2022 new_font = New Font(new_fontFamily, par_sizeInPixels,
        ''                              new_fontstyle, GraphicsUnit.Pixel)
        new_font = New Font(new_fontFamily, par_sizeInPixels,
                            par_fontStyle, GraphicsUnit.Pixel)

ExitHandler:
        Return new_font
    End Function ''Endof "Public Function MakeFont"



    Public Function ConvertSizeToPixels(par_units As GraphicsUnit, par_size As Single) As Single
        ''
        ''Added 6/10/2022 
        ''
        Dim singleOutput As Single
        singleOutput = SerializableFontByMaxGalkin.ConvertSize_ToPixels(par_units, par_size)
        Return singleOutput

    End Function ''End of ""Public Function ConvertSizeToPixels""


    Public Function ConvertSizeToPoints(par_units As GraphicsUnit, par_size As Single) As Single
        ''
        ''Added 6/10/2022 
        ''
        Dim singleOutput As Single
        singleOutput = SerializableFontByMaxGalkin.ConvertSize_ToPoints(par_units, par_size)
        Return singleOutput

    End Function ''End of ""Public Function ConvertSizeToPoints""


    Public Function MakeItBoldEtc(ByRef par_font As Font) As Font
        ''
        ''Added 8/16/2019 td  
        ''
        Dim new_font As Font
        Dim new_fontstyle As FontStyle

        With par_font

            new_fontstyle = New FontStyle()
            ''new_fontstyle.Bold = FontStyle.Bold  ''True 
            new_fontstyle = (FontStyle.Bold Or FontStyle.Underline)
            new_fontstyle = (FontStyle.Bold) ''  Or FontStyle.Underline)
            new_fontstyle = (FontStyle.Bold Or FontStyle.Underline)

            new_font = New Font(.FontFamily, .Size, new_fontstyle)

        End With

ExitHandler:
        par_font = new_font
        Return new_font

    End Function ''End of "Public Function MakeItBold(ByRef par_font As Font) As Font"

    Public Function SetFontSize(ByRef par_font As Font, par_intSize As Integer) As Font
        ''
        ''Added 8/16/2019 td  
        ''
        ''par_font.Size = par_intSize
        ''
        ''   https://docs.microsoft.com/en-us/dotnet/api/system.drawing.graphicsunit?view=netframework-4.8
        ''

        Dim new_font As Font

        If (par_intSize < 7) Then par_intSize = 7

        With par_font

            new_font = New Font(.FontFamily, par_intSize, .Style)

        End With

        par_font = new_font
        Return new_font

    End Function ''End of "Public Function SetFontSize(ByRef par_font As Font, par_intSize As Integer) As Font"

    ''
    ''  https://stackoverflow.com/questions/15419744/fontsize-pixels-c-sharp-equivalent
    ''
    Public Function SetFontSize_Pixels(ByRef par_font As Font, par_intSizeInPixels As Integer) As Font
        ''
        ''  https://stackoverflow.com/questions/15419744/fontsize-pixels-c-sharp-equivalent
        ''
        ''  Added 9/5/2019 td  
        ''
        Dim new_font As Font

        If (par_intSizeInPixels < 7) Then par_intSizeInPixels = 7

        With par_font

            ''#1 9/5/2019 td''new_font = New Font(.FontFamily, par_intSize, .Style)
            '' #2 9/5/2019 td''new_font = New Font(.FontFamily, par_intSizeInPixels, GraphicsUnit.Pixel)

            new_font = New Font(.FontFamily, par_intSizeInPixels, .Style, GraphicsUnit.Pixel)

        End With

        par_font = new_font
        Return new_font

    End Function ''End of "Public Function SetFontSize_Pixels(ByRef par_font As Font, par_intSize As Integer) As Font"

    Public Function SetFontSize_Pixels(ByRef par_font As Font, par_sizeInPixels As Single) As Font
        ''
        ''  https://stackoverflow.com/questions/15419744/fontsize-pixels-c-sharp-equivalent
        ''
        ''  Added 9/5/2019 td  
        ''
        Dim new_font As Font

        If (par_sizeInPixels < 7) Then par_sizeInPixels = 7

        With par_font

            new_font = New Font(.FontFamily, par_sizeInPixels, .Style, GraphicsUnit.Pixel)

        End With

        par_font = new_font
        Return new_font

    End Function ''End of "Public Function SetFontSize_Pixels(ByRef par_font As Font, par_sizeInPixels As Single) As Font"

    Public Function SetFontSize_InPoints(ByRef par_font As Font, par_intSizeInPoints As Integer) As Font
        ''
        ''Added 8/16/2019 td  
        ''
        ''par_font.Size = par_intSize
        ''
        ''   https://docs.microsoft.com/en-us/dotnet/api/system.drawing.graphicsunit?view=netframework-4.8
        ''

        Dim new_font As Font

        If (par_intSizeInPoints < 7) Then par_intSizeInPoints = 7

        With par_font

            new_font = New Font(.FontFamily, par_intSizeInPoints, .Style, GraphicsUnit.Point)

        End With

        par_font = new_font
        Return new_font

    End Function ''End of "Public Function SetFontSize_InPoints(ByRef par_font As Font, par_intSize As Integer) As Font"


    Public Function BarCodeFont_ByDefault(par_sizeFont As Single) As Font
        ''
        ''Added 8/28/2019 td  
        ''
        ''   On Monday 8/19/2019, Erick Madrid sent me Resources\C39FIRA.TTF, which 
        ''   is probably Font Family "Code 39".  
        ''
        ''8/28/2019 td''Return New Font(New FontFamily("BarCode Font"), par_sizeFont)

        ''9/02/2019 td''Return New Font(New FontFamily("Code 39"), par_sizeFont)

        ''9/02/2019 td''Return New Font(New FontFamily("Code39FiveRedA"), par_sizeFont)

        Dim objFontFamily As FontFamily
        Dim objFontObject As Font

        objFontFamily = New FontFamily("Code39FiveRedA")

        objFontObject = New Font(objFontFamily, par_sizeFont)

        Return objFontObject

    End Function ''End of "Public Function BarCodeFont_ByDefault() As Font"

End Module
