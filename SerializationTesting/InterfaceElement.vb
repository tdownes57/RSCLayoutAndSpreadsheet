﻿''
''Added 7/18/2019 Thomas DOWNES
''
''  "Program to the Interface, not the Implementation"  
''     Gang of Four
''      https://www.tutorialspoint.com/design_pattern/design_pattern_overview
''

Public Interface IElement
    ''
    ''Added 7/18/2019 td
    ''
    Property ElementType As String ''Text, Pic, or Logo

    Property FormControl As Control ''Added 7/19/2019 td

    Property LayoutWidth_Pixels As Integer ''This provides sizing context & scaling factors. 

    Property TopEdge_Pixels As Integer
    Property LeftEdge_Pixels As Integer

    Property Width_Pixels As Integer
    Property Height_Pixels As Integer

    Property Border_Pixels As Integer
    Property Border_Color As System.Drawing.Color

    Property Back_Color As System.Drawing.Color

End Interface
