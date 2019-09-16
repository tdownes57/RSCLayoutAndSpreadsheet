''
''Added 9/16/2019 Thomas DOWNES
''
''  "Program to the Interface, not the Implementation"  
''     Gang of Four
''      https://www.tutorialspoint.com/design_pattern/design_pattern_overview
''
Imports System.Drawing ''Added 8/14/2019 td  
Imports System.Windows.Forms ''Added 8/14/2019 td  

Public Interface IElement_TextRedux
    ''
    ''Added 9/16/2019 td
    ''
    Property Font_DrawingClass As System.Drawing.Font ''Formerly called Font__AllInfo.  8/17/2019 td

    Property FontColor As System.Drawing.Color

    Property FontSize_Pixels As Single ''Added 8/12/2019 thomas downes  
    Property FontFamilyName As String ''Added 9/6/2019 thomas downes  

    Property FontSize_ScaleToElementYesNo As Boolean ''Added 9/12/2019 thomas downes  
    Property FontSize_ScaleToElementRatio As Double ''Added 9/12/2019 thomas downes  

    Property FontOffset_X As Integer ''Added 8/15/2019 thomas downes  
    Property FontOffset_Y As Integer ''Added 8/15/2019 thomas downes  

    Property FontBold As Boolean ''Added 8/12/2019 thomas downes  
    Property FontItalics As Boolean ''Added 8/12/2019 thomas downes  
    Property FontUnderline As Boolean ''Added 8/12/2019 thomas downes  

    ''See Interface IElement_Base. ---8/29/2019 td''Property BackColor As System.Drawing.Color

    Property Text As String ''E.g. "George Washington" for FullName. 

    Property TextAlignment As System.Windows.Forms.HorizontalAlignment

    Function GenerateImage_ByDesiredLayoutHeight(pintDesiredLayoutHeight As Integer) As Image ''Added 8/14/2019 td 
    Function GenerateImage_ByDesiredLayoutWidth(pintDesiredLayoutWidth As Integer) As Image ''Added 8/26/2019 td 

End Interface

