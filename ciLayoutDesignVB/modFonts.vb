
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

        Dim new_font As Font

        With par_font

            new_font = New Font(.FontFamily, par_intSize, .Style)

        End With

        par_font = new_font
        Return new_font

    End Function

End Module
