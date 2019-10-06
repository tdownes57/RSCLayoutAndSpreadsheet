Option Explicit On ''Added 7/17/2019
Option Strict On ''Added 7/17/2019

''
''Added 7/17/2019
''
Imports System.Drawing.Image ''Added 7/17/2019
Imports System.Drawing.Text ''Added 7/30/2019
Imports System.Drawing ''Added 7/30/2019 td 
Imports System.Windows.Forms ''Added 10/1/2019 td
Imports ciBadgeInterfaces ''Added 8/14/2019 thomas d. 
Imports ciBadgeElements ''Added 10/1/2019 td 

Public Enum EnumImageOrControl
    Undetermined
    Image
    Contl
End Enum

Public Class ClassFixTheControlWidth
    ''
    ''Created 10/5/2019 td  
    ''

    Public Shared Sub Proportions_FixTheWidth(par_control As Control)
        ''
        ''Added 9/5/2019 thomas downes  
        ''
        par_control.Width = CInt(par_control.Height * LongSideToShortRatio())

    End Sub ''End of "Public Shared Sub Proportions_FixTheWidth(par_control As Control)"

    Public Shared Function LongSideToShortRatio() As Double
        ''
        ''Added 8/26/2019 thomas downes
        ''
        ''The website 
        ''   https://tinyurl.com/yyqyosz3    
        ''    (  https://www.identicard.com/store/id-card-and-credentials/standard-id-cards/pvc-and-composite-id-cards-for-custom-id-badges ) 
        ''
        ''says
        ''
        ''    We offer PVC cards in several different sizes and thickness levels, but the most common PVC ID card size
        ''       is CR80/credit card size (2.13" x 3.38").
        ''
        ''My measurements of the PVC card on my desk is:
        ''
        ''       2 1/8 inches by 3 3/8 inches, 
        ''
        ''      or  17/8 inches by  27/8 inches
        ''
        '' and so leads me to the ratio of 27 to 17.  
        ''
        ''   ------8/26/2019 td 
        ''
        Return (27 / 17) ''Approx. 1.588, or  3.38 / 2.13 

    End Function ''eDN OF "Public Shared Function LongSideToShortRatio() As Double"

End Class
