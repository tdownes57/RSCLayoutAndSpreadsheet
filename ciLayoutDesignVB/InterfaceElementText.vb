''
''Added 7/18/2019 Thomas DOWNES
''
''  "Program to the Interface, not the Implementation"  
''     Gang of Four
''      https://www.tutorialspoint.com/design_pattern/design_pattern_overview
''

Public Interface IElementText
    ''
    ''Added 7/18/2019 td
    ''
    ''Property FontFamilyName As String
    ''Property FontSize As String
    ''Property FontUnderline As Boolean
    ''Property FontItalics As Boolean
    ''Property FontBold As Boolean

    Property Font_AllInfo As System.Drawing.Font

    Property FontColor As System.Drawing.Color

    Property BackColor As System.Drawing.Color

    Property FieldInCardData As String
    Property FieldLabelCaption As String

    ''7/25/2019 td''Prpoerty ExampleText As String ''Added 7/25/2019
    Property Text As String ''E.g. "George Washington" for FullName. 


    Property Alignment As System.Windows.Forms.HorizontalAlignment


    Property OrientationToLayout As String ''E.g. "L" (Landscape) (by far the most common) or "P" for Portrait  

    Property OrientationInDegrees As Integer ''Default is 0, normal.  90 would be 1/4 turn clockwise.  180 is upside-down.  270 is the printing on the spine of a book sitting on the bookshelf.



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

