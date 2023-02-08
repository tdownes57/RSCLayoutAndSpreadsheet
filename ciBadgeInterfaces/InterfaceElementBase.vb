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
    ''
    '' Oops! Interfaces should not contain properties, but rather methods.
    ''    (Analogously, classes should expose methods, not properties.)  
    '' ---2/07/2023 tcd
    ''
    Property ElementType As String ''Text, Pic, or Logo

    Property WhyOmitted As WhyOmitted_StructV2 ''Added 9/05/2022 & 1/23/2022 td

    Property PositionalMode As String ''E.g. "CIBv82", "CIBv83", "CIBv8", "CIBv90", "CIBv9", "BL" ("Badge Layout")  Added 8/14/2019

    Property FormControl As Control ''Added 7/19/2019 td

    ''9/11/2019 td''Property LayoutWidth_Pixels As Integer ''---CONFUSING----  This is the width of the "canvas"/layout
    ''   __within which__ the applicable text-label image resides.  Analogous to a child placing a sticker on 
    '    a school notebook, this is the width of the notebook (not the sticker width!!).  This provides sizing
    ''   context & scaling factors.   (Unfortunately, there might not be a good name to eliminate the 
    ''   amiguity--the confusion between an element inside the layout & the layout itself.)
    ''   -----9/11/20019 

    Property BadgeLayoutDims As BadgeLayoutDimensionsClass ''Added 9/11/2019 td   

    Property TopEdge_Pixels As Integer
    Property LeftEdge_Pixels As Integer

    Property Width_Pixels As Integer
    Property Height_Pixels As Integer

    Property BadgeDisplayIndex As Integer ''Added 11/24/2021 thomas d. 

    ''8/29/2019 td''Property Border_Pixels As Integer ''Renamed 8/29/2019 thomas d. 
    Property Border_Displayed As Boolean ''Added 9/9/2019 thomas d. 
    Property Border_WidthInPixels As Integer ''Resuffixed 8/29/2019 thomas d. 
    Property Border_Color As System.Drawing.Color ''Rediscovered 8/29/2019 thoma d. 

    Property Back_Color As System.Drawing.Color

    Property Back_Transparent As Boolean ''Added 9/4/2019 thomas downes

    Property SelectedHighlighting As Boolean ''Added 8/2/2019 thomas downes  

    ''See above.''Property Border_Pixels As Integer ''Added 8/29/2019 thoma d. 
    ''See above.''Property Border_Color As Color ''Added 8/29/2019 thoma d. 

    Property OrientationToLayout As String ''E.g. "L" (Landscape) (by far the most common) or "P" for Portrait  

    Property OrientationInDegrees As Integer ''Default is 0, normal.  90 would be 1/4 turn clockwise.  180 is upside-down.  270 is the printing on the spine of a book sitting on the bookshelf.

    ''
    ''What does BL stand for?  ----12/8/2021 
    ''Does BL stand for Badge Layout?  (See "Property BadgeLayout As BadgeLayoutClass" above.)
    ''  ----12/8/2021 td 
    ''
    Property Image_BL As Image ''Added 8/29 & 8/27/2019 td 

    Property Visible As Boolean ''Added 9/19/2019 td

    Property WhichSideOfCard As EnumWhichSideOfCard ''Added 12/13/2021 thomas downes
    Property DateEdited As Date ''Added 12/18/2021 thomas downes  
    Property DateSaved As Date ''Added 12/18/2021 thomas downes  

    ''
    ''Added 12/19/2021 Thomas 
    ''
    Property ZOrder As Integer ''This is to address the issue of overlapping. ---12/19/2021 thomasd. 
    Function ImageForBadgeImage(par_recipient As IRecipient,
                                par_scale As Single) As Image ''Added 12/19/2021 thomas downes

    ''Added 5/27/2022 td
    ''---May 28 2022 Property ConditionalExpressionInUse As Boolean
    ''---May 28 2022 Property ConditionalExpressionValue As String
    ''---May 28 2022 Property ConditionalExpressionField As EnumCIBFields


End Interface
