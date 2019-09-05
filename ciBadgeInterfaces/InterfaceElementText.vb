''
''Added 7/18/2019 Thomas DOWNES
''
''  "Program to the Interface, not the Implementation"  
''     Gang of Four
''      https://www.tutorialspoint.com/design_pattern/design_pattern_overview
''
Imports System.Drawing ''Added 8/14/2019 td  
Imports System.Windows.Forms ''Added 8/14/2019 td  

Public Structure IElementWithText
    ''
    ''Added 8/14/2019 td  
    ''
    Dim FieldInfo As ICIBFieldStandardOrCustom ''Added 9/3/2019 td  

    ''8/15 td''Dim Position As IElement_Base ''Added 8/14/2019 td 
    Dim TextDisplay As IElement_Text ''Added 8/14/2019 td  

    Dim Position_BL As IElement_Base ''BL = Badge Layout.   ---Added 8/14/2019 td 
    Dim Position_V8 As IElement_Base ''Added 8/14/2019 td 
    Dim Position_V9 As IElement_Base ''Added 8/14/2019 td 
    Dim Position_V8_VM As IElement_Base ''VM = Visitor Management.     Added 8/14/2019 td 
    Dim Position_V9_VM As IElement_Base ''VM = Visitor Management.     Added 8/14/2019 td 

    Dim BadgeLayout_Width As Integer ''Added 9/4/2019 td  

End Structure ''End of "Public Structure IElementWithText"

Public Interface IElement_Text
    ''
    ''Added 7/18/2019 td
    ''
    ''Property FontFamilyName As String
    ''Property FontSize As String
    ''Property FontUnderline As Boolean
    ''Property FontItalics As Boolean
    ''Property FontBold As Boolean

    Property Font_DrawingClass As System.Drawing.Font ''Formerly called Font__AllInfo.  8/17/2019 td

    Property FontColor As System.Drawing.Color

    Property FontSize As Single ''Added 8/12/2019 thomas downes  

    Property FontSize_IsLocked As Boolean ''Added 8/15/2019 thomas downes  
    Property FontOffset_X As Integer ''Added 8/15/2019 thomas downes  
    Property FontOffset_Y As Integer ''Added 8/15/2019 thomas downes  

    Property FontBold As Boolean ''Added 8/12/2019 thomas downes  
    Property FontItalics As Boolean ''Added 8/12/2019 thomas downes  
    Property FontUnderline As Boolean ''Added 8/12/2019 thomas downes  

    ''See Interface IElement_Base. ---8/29/2019 td''Property BackColor As System.Drawing.Color

    Property FieldInCardData As String
    Property FieldLabelCaption As String

    ''7/25/2019 td''Prpoerty ExampleText As String ''Added 7/25/2019
    Property Text As String ''E.g. "George Washington" for FullName. 

    ''Added 8/14/2019 td 
    Property ExampleValue As String ''E.g. "George Washington" for FullName. 

    Property TextAlignment As System.Windows.Forms.HorizontalAlignment


    ''8/29/2019 td''Property OrientationToLayout As String ''E.g. "L" (Landscape) (by far the most common) or "P" for Portrait  

    ''8/29/2019 td''Property OrientationInDegrees As Integer ''Default is 0, normal.  90 would be 1/4 turn clockwise.  180 is upside-down.  270 is the printing on the spine of a book sitting on the bookshelf.

    ''8/26/2019 td''Function GenerateImage(pintHeight As Integer) As Image ''Added 8/14/2019 td 
    Function GenerateImage_ByDesiredLayoutHeight(pintDesiredLayoutHeight As Integer) As Image ''Added 8/14/2019 td 
    Function GenerateImage_ByDesiredLayoutWidth(pintDesiredLayoutWidth As Integer) As Image ''Added 8/26/2019 td 

    ''8/29/2019 td''Property Image_BL As Image ''Added 8/27/2019 td 

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

