''
''Added 9/16/2019 Thomas DOWNES
''
''  "Program to the Interface, not the Implementation"  
''     Gang of Four
''      https://www.tutorialspoint.com/design_pattern/design_pattern_overview
''
Imports System.Drawing ''Added 8/14/2019 td  
Imports System.Windows.Forms ''Added 8/14/2019 td  

Public Interface IElement_TextOnly
    ''
    ''Added 9/16/2019 td
    ''
    Property Font_DrawingClass As System.Drawing.Font ''Formerly called Font__AllInfo.  8/17/2019 td
    Property Font_Name As String ''Added 6/06/2022 td

    Property FontColor As System.Drawing.Color

    Property FontSize_Pixels As Single ''Added 8/12/2019 thomas downes  
    Property FontFamilyName As String ''Added 9/6/2019 thomas downes  

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

    Property FontBold As Boolean ''Added 8/12/2019 thomas downes  
    Property FontItalics As Boolean ''Added 8/12/2019 thomas downes  
    Property FontUnderline As Boolean ''Added 8/12/2019 thomas downes  

    ''See Interface IElement_Base. ---8/29/2019 td''Property BackColor As System.Drawing.Color

    Property Text_StaticLine As String ''E.g. "This is the same for everyone." or "The holder of this badge has all rights and responsibilities subject thereto." 
    Property Text_IsMultiLine As Boolean ''Added 5/31/2022
    Property Text_ListOfLines As List(Of String) ''Added 5/31/2022


    Property Text_Formula As String ''E.g. "This is the same for everyone." or "The holder of this badge has all rights and responsibilities subject thereto." 

    ''Needed?  Compare to IElement_TextField.ExampleValue_ForElement. 5/31/2022 
    Property Text_ExampleValue As String ''Added 5/31/2022 td

    Property TextAlignment As System.Windows.Forms.HorizontalAlignment

    Function GenerateImage_ByDesiredLayoutHeight(pintDesiredLayoutHeight As Integer) As Image ''Added 8/14/2019 td 
    Function GenerateImage_ByDesiredLayoutWidth(pintDesiredLayoutWidth As Integer) As Image ''Added 8/26/2019 td 

End Interface ''End of "Interface IElement_TextOnly"

