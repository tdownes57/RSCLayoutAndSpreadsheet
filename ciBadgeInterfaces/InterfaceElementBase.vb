''
''Added 7/18/2019 Thomas DOWNES
''
''  "Program to the Interface, not the Implementation"  
''     Gang of Four
''      https://www.tutorialspoint.com/design_pattern/design_pattern_overview
''
Imports System.Drawing ''Added 8/14/2019 td  
Imports System.Windows.Forms ''Added 8/14/2019 td  

Public Interface IElement_Base
    ''
    ''Added 7/18/2019 td
    ''
    Property ElementType As String ''Text, Pic, or Logo

    Property PositionalMode As String ''E.g. "CIBv82", "CIBv83", "CIBv8", "CIBv90", "CIBv9", "BL" ("Badge Layout")  Added 8/14/2019

    Property FormControl As Control ''Added 7/19/2019 td

    Property LayoutWidth_Pixels As Integer ''This provides sizing context & scaling factors. 

    Property TopEdge_Pixels As Integer
    Property LeftEdge_Pixels As Integer

    Property Width_Pixels As Integer
    Property Height_Pixels As Integer

    ''8/29/2019 td''Property Border_Pixels As Integer ''Renamed 8/29/2019 thomas d. 
    Property Border_WidthInPixels As Integer ''Resuffixed 8/29/2019 thomas d. 
    Property Border_Color As System.Drawing.Color ''Rediscovered 8/29/2019 thoma d. 

    Property Back_Color As System.Drawing.Color

    Property Back_Transparent As Boolean ''Added 9/4/2019 thomas downes

    Property SelectedHighlighting As Boolean ''Added 8/2/2019 thomas downes  

    ''See above.''Property Border_Pixels As Integer ''Added 8/29/2019 thoma d. 
    ''See above.''Property Border_Color As Color ''Added 8/29/2019 thoma d. 

    Property OrientationToLayout As String ''E.g. "L" (Landscape) (by far the most common) or "P" for Portrait  

    Property OrientationInDegrees As Integer ''Default is 0, normal.  90 would be 1/4 turn clockwise.  180 is upside-down.  270 is the printing on the spine of a book sitting on the bookshelf.

    Property Image_BL As Image ''Added 8/29 & 8/27/2019 td 

End Interface
