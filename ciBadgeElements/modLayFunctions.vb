Option Explicit On ''Added 9/19/2019 thomas d
Option Strict On ''Added 9/19/2019 thomas d
''
''Added 9/19/2019 thomas d
''
''9/19 td''Imports System.Drawing ''Added 9/19/2019 thomas d
''9/19 td''Imports System.Drawing.Text ''Added 9/19/2019 thomas d
''9/19 td''Imports ciBadgeInterfaces ''Added 9/19/2019 thomas d

Public Module modLayFunctions
    ''
    ''Added 9/19/2019 thomas d
    ''
    Public Function LongSideToShortRatio() As Double
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

    Public Function RatioIsLikelyBad(par_doubleW_div_H As Double) As Boolean
        ''
        ''Added 9/4/2019 thomas downes  
        ''
        ''9/8/2019 td''RatioIsLikelyBad = (1 > (100 * Math.Abs(par_doubleW_div_H - LongSideToShortRatio())))

        Dim doubleExpected_27_17 As Double ''Added 9/8/2019 
        Dim doubleDifference As Double ''Added 9/8/2019 
        Dim doubleDifference_x100 As Double ''Added 9/8/2019 
        Dim boolReturnValue As Boolean ''Added 9/8

        ''9/8/2019 td''RatioIsLikelyBad = (1 > (100 * Math.Abs(par_doubleW_div_H - LongSideToShortRatio())))

        doubleExpected_27_17 = LongSideToShortRatio()

        ''9/8/2019 td''RatioIsLikelyBad = (1 > (100 * Math.Abs(par_doubleW_div_H - doubleExpected_27_17)))

        doubleDifference = Math.Abs(par_doubleW_div_H - doubleExpected_27_17)
        doubleDifference_x100 = (100 * doubleDifference)

        boolReturnValue = (1 < doubleDifference_x100)

        Return boolReturnValue

    End Function ''End of "Public Shared Function RatioIsLikelyBad(par_doubleW_div_H As Double) As Boolean"

End Module ''Endof "Public Module modLayFunctions"
