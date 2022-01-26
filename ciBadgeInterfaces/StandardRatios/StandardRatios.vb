Option Explicit On
Option Strict On
''
''Added 1/25/2022 thomas downes
''
Public Module StandardRatios
    ''
    ''Added 1/25/2022 thomas downes
    ''
    ''   Most of these functions are copied from the Library/Project ciLayoutPrintLib, class LayoutPrint.
    ''   ----1/25/2022 td 
    ''

    Public Function ShortSideToLongSideRatio_HW_63() As Double
        ''
        ''Added 1/25/2022 thomas downes
        ''
        Return 0.63

    End Function ''End of "Public Shared Function ShortSideToLongSideRatio_WH() As Double"


    Public Function LongSideToShortRatio_WH_16() As Double
        ''Jan25 2022 td''Public Shared Function LongSideToShortRatio() As Double
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


    Public Function RatioIsLikelyBad_HW(par_doubleW_div_H As Double) As Boolean
        ''
        ''Added 9/4/2019 thomas downes  
        ''
        ''9/8/2019 td''RatioIsLikelyBad = (1 > (100 * Math.Abs(par_doubleW_div_H - LongSideToShortRatio())))

        Dim doubleExpected_27_17 As Double ''Added 9/8/2019 
        Dim doubleDifference As Double ''Added 9/8/2019 
        Dim doubleDifference_x100 As Double ''Added 9/8/2019 
        Dim boolReturnValue As Boolean ''Added 9/8

        ''9/8/2019 td''RatioIsLikelyBad = (1 > (100 * Math.Abs(par_doubleW_div_H - LongSideToShortRatio())))

        ''Jan25 2022 td''doubleExpected_27_17 = LongSideToShortRatio()
        doubleExpected_27_17 = LongSideToShortRatio_WH_16()

        ''9/8/2019 td''RatioIsLikelyBad = (1 > (100 * Math.Abs(par_doubleW_div_H - doubleExpected_27_17)))

        doubleDifference = Math.Abs(par_doubleW_div_H - doubleExpected_27_17)
        doubleDifference_x100 = (100 * doubleDifference)

        boolReturnValue = (1 < doubleDifference_x100)

        Return boolReturnValue

    End Function ''End of "Public Shared Function RatioIsLikelyBad_HW(par_doubleW_div_H As Double) As Boolean"


End Module


