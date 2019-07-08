Option Explicit On ''Added 7/7/2019 td
Option Strict On ''Added 7/7/2019 td
''
''Added 7/7/2019 td 
''
''  In your mind, please picture a bar of colors, about the height of a TextBox, 
''  providing a nice mix of colors (in clear sequential order).   
''  The user would select a color by clicking inside the bar.
''  This class would translate the Click Position (in Pixels) into
''  the appropriate color, in Hexadecimal RGB format (string of 6 hex digits).  
''
Imports System.Drawing ''Added 7/7/2019 td 

Public Class ciLayoutColors
    ''
    ''Added 7/7/2019 td 
    ''
    Public Shared ListOfColors As New List(Of Color)
    Public Const ColorWidthInPixels As Integer = 20

    Public Shared Sub LoadColors()
        ''
        ''Added 7/7/2019 td 
        ''
        ListOfColors.AddRange({Color.Black, Color.White,
                              Color.Blue, Color.Beige,
                              Color.LightYellow, Color.Lime,
                              Color.Brown, Color.LightBlue,
                              Color.Red, Color.LightPink})

    End Sub ''End of "Public Shared Sub LoadColors()"

    Public Shared Function GetColorByOffsetPixels(ByVal par_intOffset As Integer) As Color
        ''
        ''Added 7/7/2019 td 
        ''
        Dim intMultiple As Integer

        intMultiple = CInt(Math.Floor(par_intOffset / ColorWidthInPixels))

        Return ListOfColors(intMultiple)

    End Function ''End of "Public Shared Function GetColorByOffsetPixels() As Color"

    Public Shared Function GetColorByOffsetPixels_HexRGB(ByVal par_intOffset As Integer) As String
        ''
        ''Added 7/7/2019 td 
        ''
        ''  In your mind, please picture a bar of colors, about the height of a TextBox, 
        ''  providing a nice mix of colors (in clear sequential order).   
        ''  The user would select a color by clicking inside the bar.
        ''  This function would translate the Click Position (in Pixels) into
        ''  the appropriate color.  
        ''
        Dim colorOutput As Color ''Added 7/7/2019 td

        Dim intColorRed As Integer ''Added 7/7/2019 td
        Dim intColorGreen As Integer ''Added 7/7/2019 td
        Dim intColorBlue As Integer ''Added 7/7/2019 td

        Dim strHexadecimalRed As String
        Dim strHexadecimalGreen As String
        Dim strHexadecimalBlue As String

        ''Added 7/07/2019 td
        colorOutput = GetColorByOffsetPixels(par_intOffset)

        intColorRed = CInt(colorOutput.R())
        intColorGreen = CInt(colorOutput.G())
        intColorBlue = CInt(colorOutput.B())

        strHexadecimalRed = Strings.Right("0" & intColorRed.ToString("X"), 2)
        strHexadecimalGreen = Strings.Right("0" & intColorGreen.ToString("X"), 2)
        strHexadecimalBlue = Strings.Right("0" & intColorBlue.ToString("X"), 2)

        Return (strHexadecimalRed & strHexadecimalGreen & strHexadecimalBlue)

    End Function ''End of "Public Shared Function GetColorByOffsetPixels_HexRGB() As Color"



End Class
