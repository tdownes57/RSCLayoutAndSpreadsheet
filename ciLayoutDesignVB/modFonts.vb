
''
''Added 8/16/2019 td  
''
Imports System.Drawing.Text ''Added 8/16/2019 td  

Module modFonts
    ''
    ''Added 8/16/2019 td  
    ''
    Public AskedAlignmentQuestion As Boolean ''Added 8/16/2019 td  
    Public Const vbCrLf_Deux As String = (vbCrLf & vbCrLf) ''Added 8/16/2019 td
    Public UseAverageLineForAlignment As Boolean ''Added 8/16/2019 td   

    Public Function MakeFont(par_strFamily As String, par_sizeInPixels As Integer) As Font
        ''
        ''9/6/2019 thomas downes  
        ''
        ''   FontFamily 
        ''


    End Function ''Endof "Public Function MakeFont"

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

    End Function ''End of "Public Function SetFontSize(ByRef par_font As Font, par_intSize As Integer) As Font"

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
