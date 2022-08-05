''
''Added 7/18/2019 Thomas DOWNES
''
''  "Program to the Interface, not the Implementation"  
''     Gang of Four
''      https://www.tutorialspoint.com/design_pattern/design_pattern_overview
''
''
Imports System.Drawing ''Added 8/14/2019 td  
Imports System.Windows.Forms ''Added 8/14/2019 td  

Public Interface IElement_Base_InDevelopment
    ''Jan23 2022 td ''Public Interface InterfaceElementBase_InDevelopment
    ''
    ''
    ''Added 1/23/2022 td
    ''
    ''
    Property WhyOmitted As WhyOmitted_StructV2

    Property Border_bDisplayed As Boolean ''Added 7/19/2022 thomas d. 
    Property Border_bWidthInPixels As Integer ''Added 7/19/2022 thomas d. 
    Property Border_bColor As System.Drawing.Color ''Added 7/19/2022 thoma d. 

    ''Added 8/3/2022 thomas downes
    Property TopEdge_bPixels As Integer ''Added 8/3/2022 thomas downes
    Property LeftEdge_bPixels As Integer ''Added 8/3/2022 thomas downes

    ''Added 8/4/2022 thomas downes
    Property Width_bPixels As Integer ''Added 8/4/2022 thomas downes
    Property Height_bPixels As Integer ''Added 8/4/2022 thomas downes




End Interface
