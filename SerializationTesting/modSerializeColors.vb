''
''Added 9/1/2019 thomas downes
''
''  https://stackoverflow.com/questions/376234/best-solution-for-xmlserializer-and-system-drawing-color
''
''
Module modSerializeColors
    ''
    ''https://stackoverflow.com/questions/376234/best-solution-for-xmlserializer-and-system-drawing-color
    ''
    ''   String HtmlColor = System.Drawing.ColorTranslator.ToHtml(MyColorInstance)
    ''
    ''   Color MyColor = System.Drawing.ColorTranslator.FromHtml(MyColorString)
    ''
    Public Function Color_ToString(par_color As System.Drawing.Color) As String
        ''
        ''  https://stackoverflow.com/questions/376234/best-solution-for-xmlserializer-and-system-drawing-color
        ''
        Dim htmlColor As String

        htmlColor = System.Drawing.ColorTranslator.ToHtml(par_color)
        Return htmlColor

    End Function

    Public Function Color_FromString(par_htmlColor As String) As System.Drawing.Color
        ''
        ''  https://stackoverflow.com/questions/376234/best-solution-for-xmlserializer-and-system-drawing-color
        ''
        Return System.Drawing.ColorTranslator.FromHtml(par_htmlColor)

    End Function











End Module
