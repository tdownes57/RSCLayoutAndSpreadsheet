
''
''Added 8/16/2019 td  
''
Imports System.Drawing.Text ''Added 8/16/2019 td  

Module modFonts
    ''
    ''Added 8/16/2019 td  
    ''
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




End Module
