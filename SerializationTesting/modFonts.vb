
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

            ''9/6/2019 td''new_font = New Font(.FontFamily, .Size, new_fontstyle)
            new_font = New Font(.FontFamily, .Size, new_fontstyle, GraphicsUnit.Pixel)

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

        Dim new_font As Font

        If (par_intSize < 7) Then par_intSize = 7

        With par_font

            ''9/6/2019 td''new_font = New Font(.FontFamily, par_intSize, .Style)
            new_font = New Font(.FontFamily, par_intSize, .Style, GraphicsUnit.Pixel)

        End With

        par_font = new_font
        Return new_font

    End Function ''End of "Public Function SetFontSize(ByRef par_font As Font, par_intSize As Integer) As Font"


    Public Function BarCodeFont_ByDefault(par_sizeFont As Single) As Font
        ''
        ''Added 8/28/2019 td  
        ''
        ''   On Monday 8/19/2019, Erick Madrid sent me Resources\C39FIRA.TTF, which 
        ''   is probably Font Family "Code 39".  
        ''
        ''8/28/2019 td''Return New Font(New FontFamily("BarCode Font"), par_sizeFont)
        Return New Font(New FontFamily("Code 39"), par_sizeFont)

    End Function ''End of "Public Function BarCodeFont_ByDefault() As Font"

End Module
