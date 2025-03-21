﻿''
''Added 9/16/2019 Thomas DOWNES
''
''  "Program to the Interface, not the Implementation"  
''     Gang of Four
''      https://www.tutorialspoint.com/design_pattern/design_pattern_overview
''
Imports System.Drawing ''Added 8/14/2019 td  
Imports System.Windows.Forms ''Added 8/14/2019 td
Imports ciBadgeSerialize ''Added 6/07/2022 thomas downes

Public Interface IElement_TextOnly
    ''
    ''Added 9/16/2019 td
    ''
    ''Moved down, and underscore removed. td ----Property Font_DrawingClass As System.Drawing.Font ''Formerly called Font__AllInfo.  8/17/2019 td

    ''Redundant, so not needed. 6/7/0222 td ''Property Font_FamilyName As String ''Added 6/06/2022 td

    ''
    '' Oops! Interfaces should not contain properties, but rather methods.
    ''    (Analogously, classes should expose methods, not properties.)  
    '' ---2/07/2023 tcd
    ''

    Property FontColor As System.Drawing.Color

    ''Moved below & suffixed. 6/2022 Property FontSize_Pixels As Single ''Added 8/12/2019 thomas downes  
    ''Moved below & suffixed. 6/2022 Property FontFamilyName As String ''Added 9/6/2019 thomas downes  

    ''6/02/2022  Property FontSize_AutoScaleToElementYesNo As Boolean ''Added 9/12/2019 thomas downes  
    ''6/02/2022  Property FontSize_AutoScaleToElementRatio As Double ''Added 9/12/2019 thomas downes  

    Property FontSize_AutoScaleToElementYesNo As Boolean ''Added 9/12/2019 thomas downes  
    Property FontSize_AutoScaleToElementRatio As Double ''Added 9/12/2019 thomas downes  

    ''Let's use suffix "_AutoSize" instead of the suffix "_AutoScale", since we have already 
    ''   used this suffix in two(2) other properties. This is for the purposes of 
    ''   running Ctrl-F on the following keywords:
    ''   KEYWORDS: Font, AutoSize, AutoScale, FontSize, FontSizing, font-sizing, font-scaling 
    ''       auto-sizing, auto-scaling.   
    ''----June2 2022 td
    Property FontSize_AutoSizePromptUser As Boolean '' = True ''Added 6/02/2022 thomas downes  

    Property FontOffset_X As Integer ''Added 8/15/2019 thomas downes  
    Property FontOffset_Y As Integer ''Added 8/15/2019 thomas downes  

    ''
    ''Deprecated properties. Use FontDrawingClass.Style's properties .Bold, .Italics,
    ''   & .Underline instead.   ----6/7/2022 
    ''
    Property FontBold_Deprecated As Boolean ''Deprecated, not needed. 6/2022 Added 8/12/2019 thomas downes  
    Property FontItalics_Deprecated As Boolean ''Deprecated, not needed. 6/2022 Added 8/12/2019 thomas downes  
    Property FontUnderline_Deprecated As Boolean ''Deprecated, not needed. 6/2022 Added 8/12/2019 thomas downes  

    Property FontSize_Pixels As Single ''Added 8/12/2019 thomas downes  

    ''---Property FontSize_Points As Single ''Added 6/08/2022 thomas downes
    ''
    ''Convert Pixels to Points
    ''
    '' points = pixels * 72 / 96   https://stackoverflow.com/questions/139655/convert-pixels-to-points
    ''
    ''     ---6/8/2022 thomas downes
    ''

    Property FontFamilyName As String ''Added 9/6/2019 thomas downes  

    Property FontMaxGalkin As SerializableFontByMaxGalkin ''Added 6/7/2022 td

    ''Removed underscore 6/7/2022 td''Property Font_DrawingClass As System.Drawing.Font ''Formerly called Font__AllInfo.  8/17/2019 td
    Property FontDrawingClass As System.Drawing.Font ''Formerly called Font__AllInfo.  8/17/2019 td

    ''See Interface IElement_Base. ---8/29/2019 td''Property BackColor As System.Drawing.Color

    Property Text_StaticLine As String ''E.g. "This is the same for everyone." or "The holder of this badge has all rights and responsibilities subject thereto." 
    Property Text_IsMultiLine As Boolean ''Added 5/31/2022

    ''12/31/2022 Property Text_ListOfLines As List(Of String) ''Added 5/31/2022


    Property Text_Formula As String ''E.g. "This is the same for everyone." or "The holder of this badge has all rights and responsibilities subject thereto." 

    ''Needed?  Compare to IElement_TextField.ExampleValue_ForElement. 5/31/2022 
    Property Text_ExampleValue As String ''Added 5/31/2022 td

    Property TextAlignment As System.Windows.Forms.HorizontalAlignment

    Function GenerateImage_ByDesiredLayoutHeight(pintDesiredLayoutHeight As Integer) As Image ''Added 8/14/2019 td 
    Function GenerateImage_ByDesiredLayoutWidth(pintDesiredLayoutWidth As Integer) As Image ''Added 8/26/2019 td 

End Interface ''End of "Interface IElement_TextOnly"

