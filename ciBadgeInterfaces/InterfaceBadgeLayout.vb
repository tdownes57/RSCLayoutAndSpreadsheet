''
''Added 9/11/2019 Never Forget  
''

Imports ciBadgeInterfaces
Imports System.Windows.Forms ''Added 9/11/2019 td 
Imports System.Drawing ''Added 9/11/2019 Never Forget 

Public Enum EnumImageOrControl
    ''Added 9/11/2019 & 8/26/2019 thomas downes
    ''   Copied from ciLayoutDesignVB's ClassLabelToImage.vb
    Undetermined
    Image
    Contl
End Enum

Public Interface IBadgeLayout
    ''
    ''Added 9/11/2019 Never Forget 
    ''
    ''This Is the width of the "canvas"/layout
    ''   __within which__ the applicable text-label image resides.  Analogous to a child placing a sticker on 
    '    a school notebook, this is the width of the notebook (not the sticker width!!).  This provides sizing
    ''   context & scaling factors.   (Unfortunately, there might not be a good name to eliminate the 
    ''   amiguity--the confusion between an element inside the layout & the layout itself.)
    ''   -----9/11/20019 

    Property Width_Pixels As Integer ''---CONFUSING----  This is the width of the "canvas"/layout
    ''   __within which__ the applicable text-label image resides.  Analogous to a child placing a sticker on 
    '    a school notebook, this is the width of the notebook (not the sticker width!!).  This provides sizing
    ''   context & scaling factors.   (Unfortunately, there might not be a good name to eliminate the 
    ''   amiguity--the confusion between an element inside the layout & the layout itself.)
    ''   -----9/11/20019 

    Property Height_Pixels As Integer

End Interface ''End of "Public Interface IBadgeLayout"

Public Class BadgeLayoutClass
    Implements IBadgeLayout
    ''
    ''Added 9/11/2019 Never Forget 
    ''

    Public Property Width_Pixels As Integer Implements IBadgeLayout.Width_Pixels

    Public Property Height_Pixels As Integer Implements IBadgeLayout.Height_Pixels

    Public Sub New()
        ''
        ''Added 9/1/2019 td  
        ''
    End Sub ''End of "Public Sub New()"

    Public Sub New(par_pixelsWidth As Integer, par_pixelsHeight As Integer)
        ''
        ''Added 9/1/2019 td  
        ''
        Me.Width_Pixels = par_pixelsWidth
        Me.Height_Pixels = par_pixelsHeight

    End Sub ''End of "Public Sub New(par_pixelsWidth As Integer, par_pixelsHeight As Integer)"

    Public Shared Function LongSideToShortRatio() As Double
        ''
        ''Added 9/11/2019 & 8/26/2019 thomas downes
        ''Copied from ciLayoutDesignVB's ClassLabelToImage.vb, 9/11/2019 Never Forget 
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

    Public Shared Function RatioIsLikelyBad(par_doubleW_div_H As Double) As Boolean
        ''
        ''Added 9/4/2019 thomas downes  
        ''Copied from ciLayoutDesignVB's ClassLabelToImage.vb, 9/11/2019 Never Forget 
        ''
        Dim doubleExpectedRatio As Double ''Added 9/6/2019 td  
        Dim doubleDifference As Double ''Added 9/8/2019 td
        Dim doubleDifference_x100 As Double ''Added 9/8/2019 td

        ''---9/6/2019 td ''RatioIsLikelyBad = (1 > (100 * Math.Abs(par_doubleW_div_H - LongSideToShortRatio())))

        ''Added 9/6/2019 td  
        doubleExpectedRatio = LongSideToShortRatio()

        ''9/6/2019 td''RatioIsLikelyBad = (1 > (100 * Math.Abs(par_doubleW_div_H - doubleExpectedRatio)))
        ''9/8/2019 td''RatioIsLikelyBad = (1 < (100 * Math.Abs(par_doubleW_div_H - doubleExpectedRatio)))

        doubleDifference = Math.Abs(par_doubleW_div_H - doubleExpectedRatio)
        doubleDifference_x100 = (100 * doubleDifference)

        Dim boolDiffersMoreThanPoint99 As Boolean
        Dim boolReturnValue As Boolean

        boolDiffersMoreThanPoint99 = (0.99 < doubleDifference_x100)
        boolReturnValue = boolDiffersMoreThanPoint99
        Return boolReturnValue

    End Function ''End of "Public Shared Function RatioIsLikelyBad(par_doubleW_div_H As Double) As Boolean"

    Public Shared Function ProportionsAreSlightlyOff(par_control As Control, pboolVerbose As Boolean) As Boolean
        ''
        ''Added 9/5/2019 thomas downes  
        ''
        Dim doubleW_div_H As Double

        doubleW_div_H = (par_control.Width / par_control.Height)

        ''9/6 td''Return ProportionsAreSlightlyOff(doubleW_div_H, pboolVerbose, par_control.Name)
        Return ProportionsAreSlightlyOff(doubleW_div_H, pboolVerbose, EnumImageOrControl.Contl, par_control.Name)

    End Function ''End of "Public Shared Function RatioIsLikelyBad(par_doubleW_div_H As Double) As Boolean"

    Public Shared Function ProportionsAreSlightlyOff(par_image As Image, pboolVerbose As Boolean,
                                                     Optional par_strNameOfImage As String = "") As Boolean
        ''
        ''Added 9/5/2019 thomas downes  
        ''
        Dim doubleW_div_H As Double

        doubleW_div_H = (par_image.Width / par_image.Height)

        ''9/6 td''Return ProportionsAreSlightlyOff(doubleW_div_H, pboolVerbose, par_strNameOfImage)
        Return ProportionsAreSlightlyOff(doubleW_div_H, pboolVerbose, EnumImageOrControl.Image, par_strNameOfImage)

    End Function ''End of "Public Shared Function RatioIsLikelyBad(par_doubleW_div_H As Double) As Boolean"

    Public Shared Function ProportionsAreSlightlyOff(par_doubleW_div_H As Double, pboolVerbose As Boolean,
                                                     Optional par_enum As EnumImageOrControl = EnumImageOrControl.Undetermined,
                                                     Optional par_strImageOrControl As String = "") As Boolean
        ''
        ''Added 9/5/2019 thomas downes  
        ''
        Dim strRatioCurrent As String ''Double
        Dim strRatioDesired As String ''Double
        ''Dim doubleW_div_H As Double
        Dim boolRatioIsBad As Boolean
        Dim strObjectType As String = ""

        boolRatioIsBad = RatioIsLikelyBad(par_doubleW_div_H)

        Select Case par_enum
            Case EnumImageOrControl.Image : strObjectType = "(image)"
            Case EnumImageOrControl.Contl : strObjectType = "(control)"
        End Select

        If (pboolVerbose And boolRatioIsBad) Then
            ''Added 9/6/2019 Thomasd.
            strRatioDesired = LongSideToShortRatio().ToString("0.00")
            strRatioCurrent = par_doubleW_div_H.ToString("0.00")
            MessageBox.Show($"Uh-oh, the proportions of {strObjectType} [{par_strImageOrControl}] are {strRatioCurrent} instead of {strRatioDesired}.", "",
                                               MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If ''End of "If (pboolVerbose) Then"

        Return boolRatioIsBad

    End Function ''End of "Public Shared Function RatioIsLikelyBad(par_doubleW_div_H As Double) As Boolean"

    Public Shared Sub Proportions_FixTheWidth(par_control As Control)
        ''
        ''Added 9/5/2019 thomas downes  
        ''
        par_control.Width = CInt(par_control.Height * LongSideToShortRatio())

    End Sub ''End of "Public Shared Sub Proportions_CorrectWidth(par_control As Control)"

End Class
