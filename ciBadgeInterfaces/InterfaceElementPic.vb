''
''Added 7/18/2019 Thomas DOWNES
''
''  "Program to the Interface, not the Implementation"  
''     Gang of Four
''      https://www.tutorialspoint.com/design_pattern/design_pattern_overview
''

Public Interface IElementPic
    ''
    ''Added 7/18/2019 td
    ''
    Property PicFileType As String ''E.g. Image/PNG or Image/BMP 
    Property PicFileTitleExt As String ''E.g. 12345.jpg or 12345.png

    ''Added 8/12/2019 thomas downes  
    Property PicFileIndex As Integer ''Added 8/12/2019 thomas downes

    ''8/29/2019 td''Property OrientationToLayout As String ''E.g. "P" for Portrait (by far the most common) or "L" (Landscape)

    ''Added 8/12/2019 thomas downes
    ''     This will equal 90, 180, 270, 360 (or better, 0).  
    ''8/29/2019 td''Property OrientationDegrees As Integer ''Added 8/12/2019 thomas downes  

    ''
    ''
    ''For the below, see InterfaceElement.vb. 
    ''
    ''
    ''Property ElementType As String ''Text, Pic, or Logo

    ''Property LayoutWidth_Pixels As Integer ''This provides sizing context & scaling factors. 

    ''Property TopEdge_Pixels As Integer
    ''Property LeftEdge_Pixels As Integer

    ''Property Width_Pixels As Integer
    ''Property Height_Pixels As Integer

    ''Property Border_Pixels As Integer
    ''Property Border_Color As System.Drawing.Color

    ''Property Back_Color As System.Drawing.Color

End Interface
