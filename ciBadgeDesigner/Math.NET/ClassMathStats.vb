Option Explicit On ''Added 4/22/2022 thomas downes
Option Strict On ''Added 4/22/2022 thomas downes
''
''Added 4/22/2022 thomas downes  
''
Imports MathNet.Numerics ''Added 4/22/2022 thomas downes


Public Structure StructRSCColumnStatistics
    ''
    ''Added 4/22/2022 thomas downes  
    ''
    '' Let's keep track of the number of digits or letters in the column values.
    ''
    '' At present, the case (A vs. a) of the alphabetic letter doesn't matter.
    ''
    Dim singNumDigitsMean As Single ''The average number of digits 0 to 9 within the column cells.
    Dim singNumDigitsStdDeviation As Single
    Dim singNumAlphasMean As Single ''The average number of alphabetic letters Aa to Zz within the column cells. (Case-Insensitive)
    Dim singNumAlphasStdDeviation As Single

    Public Function Populated() As Boolean
        ''Added 4/26/2022 td
        Return (singNumDigitsMean > 0 Or singNumAlphasMean > 0)
    End Function

    Public Function Description() As String
        ''Added 4/26/2022 td

        Dim strLine1 As String = String.Format("The common number of digits is {0, 0.0}.", singNumDigitsMean)
        Dim strLine2 As String = String.Format("The common number of alphabetical letters is {0, 0.0}.", singNumAlphasMean)

        Dim strLine3 As String = String.Format("The standard deviation in count of digits is {0, 0.0}.", singNumDigitsStdDeviation)
        Dim strLine4 As String = String.Format("The standard deviation in count of alphabetical letters is {0, 0.0}.", singNumAlphasStdDeviation)

        Dim strLine5 As String = String.Format("The standard range of digit counts is {0, 0.0} to {1, 0.0}.",
                                               singNumDigitsMean - singNumDigitsStdDeviation,
                                               singNumDigitsMean + singNumDigitsStdDeviation)

        Dim strLine6 As String = String.Format("The standard range of alphabetical letters is {0, 0.0} to {1, 0.0}.",
                                                  singNumAlphasMean - singNumAlphasStdDeviation,
                                                  singNumAlphasMean + singNumAlphasStdDeviation)

        Return (strLine1 & vbCrLf & strLine2 & vbCrLf_Deux &
                strLine3 & vbCrLf & strLine4 & vbCrLf_Deux &
                strLine5 & vbCrLf & strLine6)

    End Function ''End of ""Public Function Description() As String""


End Structure


Public Structure StructMeanAndDev
    ''
    ''Added 4/22/2022 thomas downes  
    ''
    Dim singMean As Single
    Dim singStdDeviation As Single

End Structure

Public Class ClassMathStats
    ''
    ''Added 4/22/2022 thomas downes  
    ''
    Public Shared Function UnexpectedValue(par_strValue As String, par_list As List(Of String)) As Boolean ''StructMeanAndDev
        ''
        ''Added 4/22/2022 thomas downes  
        ''
        Dim boolUnexpected As Boolean
        Dim bUnexpected9s As Boolean
        Dim bUnexpectedAs As Boolean

        bUnexpected9s = UnexpectedAmountOf_Digits(par_strValue, par_list)
        bUnexpectedAs = UnexpectedAmountOf_Alphas(par_strValue, par_list)

        boolUnexpected = (bUnexpected9s Or bUnexpectedAs)
        Return boolUnexpected

    End Function ''End of ""Public Shared Function UnexpectedValue(par_strValue As String, par_list As List(Of String))""


    Public Shared Function UnexpectedValue(par_strValue As String,
                                           par_mean_data As StructRSCColumnStatistics,
                                            ByRef pref_TooLong As Boolean,
                                            ByRef pref_TooShort As Boolean) As Boolean ''StructMeanAndDev
        ''
        ''Added 4/22/2022 thomas downes  
        ''
        Dim boolUnexpected As Boolean
        Dim bUnexpected9s As Boolean ''Unexpected count of numerical digits.
        Dim bUnexpectedZs As Boolean ''Unexpected count of alphabetical characters.

        Dim bTooMany9s As Boolean ''Too many numerical digits.  Added 4/26/2022 td
        Dim bTooFew9s As Boolean ''Too few numerical digits.  Added 4/26/2022 td
        Dim bTooManyZs As Boolean ''Too many alphabetical characters.  Added 4/26/2022 td
        Dim bTooFewZs As Boolean ''Too few alphabetical characters.  Added 4/26/2022 td

        ''bUnexpected9s = UnexpectedAmountOf_Digits(par_strValue, par_mean_data)
        ''bUnexpectedAs = UnexpectedAmountOf_Alphas(par_strValue, par_mean_data)
        bUnexpected9s = UnexpectedAmountOf_Digits(par_strValue, par_mean_data, bTooMany9s, bTooFew9s)
        bUnexpectedZs = UnexpectedAmountOf_Alphas(par_strValue, par_mean_data, bTooManyZs, bTooFewZs)

        ''Added 4/26/2022 td
        pref_TooLong = (bTooMany9s Or bTooManyZs)
        pref_TooShort = (bTooFew9s Or bTooFewZs)

        boolUnexpected = (bUnexpected9s Or bUnexpectedZs)
        Return boolUnexpected

    End Function ''End of ""Public Shared Function UnexpectedValue(par_strValue As String, par_mean_data As StructRSCColumnStatistics) As Boolean""



    Public Shared Function UnexpectedAmountOf_Digits(par_strValue As String,
                                                     par_dataStats As StructRSCColumnStatistics,
                                                     ByRef pref_TooLong As Boolean,
                                                     ByRef pref_TooShort As Boolean) As Boolean ''StructMeanAndDev
        ''
        ''Added 4/22/2022 thomas downes  
        ''
        Dim intValueHasHowMany_Digits As Integer
        Dim intCountDigits As Integer
        Dim boolLessThanStdDev As Boolean
        Dim boolMoreThanStdDev As Boolean
        Dim boolIsAnOutlier As Boolean

        intValueHasHowMany_Digits = HowManyCharsAre_Digits(par_strValue)
        intCountDigits = intValueHasHowMany_Digits

        boolLessThanStdDev = (intCountDigits < (par_dataStats.singNumDigitsMean - par_dataStats.singNumDigitsStdDeviation))
        boolMoreThanStdDev = (intCountDigits > (par_dataStats.singNumDigitsMean + par_dataStats.singNumDigitsStdDeviation))

        ''Added 4/26/2022
        pref_TooLong = boolMoreThanStdDev
        pref_TooShort = boolLessThanStdDev

        boolIsAnOutlier = (boolLessThanStdDev Or boolMoreThanStdDev)
        Return boolIsAnOutlier

    End Function ''End of ""Public Shared Function UnexpectedAmountOf_Digits""


    Public Shared Function UnexpectedAmountOf_Alphas(par_strValue As String,
                                                     par_dataStats As StructRSCColumnStatistics,
                                                     ByRef pref_TooLong As Boolean,
                                                     ByRef pref_TooShort As Boolean) As Boolean ''StructMeanAndDev
        ''
        ''Added 4/22/2022 thomas downes  
        ''
        Dim intValueHasHowMany_Alphas As Integer
        Dim intCountDigits As Integer
        Dim boolLessThanStdDev As Boolean
        Dim boolMoreThanStdDev As Boolean
        Dim boolIsAnOutlier As Boolean

        intValueHasHowMany_Alphas = HowManyCharsAre_Alphas(par_strValue)
        intCountDigits = intValueHasHowMany_Alphas

        With par_dataStats
            boolLessThanStdDev = (intCountDigits < (.singNumAlphasMean - .singNumAlphasStdDeviation))
            boolMoreThanStdDev = (intCountDigits > (.singNumAlphasMean + .singNumAlphasStdDeviation))
        End With

        ''Added 4/26/2022
        pref_TooLong = boolMoreThanStdDev
        pref_TooShort = boolLessThanStdDev

        boolIsAnOutlier = (boolLessThanStdDev Or boolMoreThanStdDev)
        Return boolIsAnOutlier

    End Function ''End of ""Public Shared Function UnexpectedAmountOf_Alphas""


    Public Shared Function UnexpectedAmountOf_Digits(par_strValue As String, par_list As List(Of String)) As Boolean ''StructMeanAndDev
        ''
        ''Added 4/22/2022 thomas downes  
        ''
        Dim intValueHasHowMany_Digits As Integer
        intValueHasHowMany_Digits = HowManyCharsAre_Digits(par_strValue)
        Dim intCountDigits As Integer
        intCountDigits = intValueHasHowMany_Digits

        ''Dim structMS As StructMeanAndDev
        ''structMS = UnexpectedAmountOf_Digits(par_strValue, par_list)

        Dim listOfSingles As New List(Of Single)

        For Each strValue As String In par_list

            listOfSingles.Add(CSng(HowManyCharsAre_Digits(strValue)))

        Next strValue

        Dim structMS As StructMeanAndDev
        structMS = GetMeanAndStdDeviation(listOfSingles)

        Dim boolLessThanStdDev As Boolean
        Dim boolMoreThanStdDev As Boolean
        Dim boolIsAnOutlier As Boolean

        boolLessThanStdDev = (intCountDigits < (structMS.singMean - structMS.singStdDeviation))
        boolMoreThanStdDev = (intCountDigits > (structMS.singMean + structMS.singStdDeviation))

        boolIsAnOutlier = (boolLessThanStdDev Or boolMoreThanStdDev)
        Return boolIsAnOutlier

    End Function ''End of ""Public Shared Function UnexpectedAmountOf_Digits""


    Public Shared Function UnexpectedAmountOf_Alphas(par_strValue As String, par_list As List(Of String)) As Boolean ''StructMeanAndDev
        ''
        ''Added 4/22/2022 thomas downes  
        ''
        Dim intValueHasHowMany_Alphas As Integer
        intValueHasHowMany_Alphas = HowManyCharsAre_Alphas(par_strValue)

        Dim intCountAlphas As Integer
        intCountAlphas = intValueHasHowMany_Alphas

        Dim listOfSingles As New List(Of Single)
        For Each strValue As String In par_list
            listOfSingles.Add(CSng(HowManyCharsAre_Alphas(strValue)))
        Next strValue

        Dim structMS As StructMeanAndDev
        structMS = GetMeanAndStdDeviation(listOfSingles)

        Dim boolLessThanStdDev As Boolean
        Dim boolMoreThanStdDev As Boolean
        Dim boolIsAnOutlier As Boolean

        boolLessThanStdDev = (intCountAlphas < (structMS.singMean - structMS.singStdDeviation))
        boolMoreThanStdDev = (intCountAlphas > (structMS.singMean + structMS.singStdDeviation))

        boolIsAnOutlier = (boolLessThanStdDev Or boolMoreThanStdDev)
        Return boolIsAnOutlier

    End Function


    Public Shared Function GetMeanAndStdDeviation_FourStats(par_listOfValues As List(Of String)) As StructRSCColumnStatistics
        ''
        ''Added 4/22/2022 thomas downes  
        ''
        Dim structOutput As New StructRSCColumnStatistics
        Dim structDataForDigits As StructMeanAndDev
        Dim structDataForAlphas As StructMeanAndDev

        structDataForAlphas = GetMeanAndStdDeviation_Alphas(par_listOfValues)
        structDataForDigits = GetMeanAndStdDeviation_Digits(par_listOfValues)

        With structOutput
            .singNumAlphasMean = structDataForAlphas.singMean
            .singNumAlphasStdDeviation = structDataForAlphas.singStdDeviation
            .singNumDigitsMean = structDataForDigits.singMean
            .singNumDigitsStdDeviation = structDataForDigits.singStdDeviation
        End With

        Return structOutput

    End Function


    Public Shared Function GetMeanAndStdDeviation_Alphas(par_listOfValues As List(Of String)) As StructMeanAndDev
        ''
        ''Added 4/22/2022 thomas downes  
        ''
        Dim listOfSingles As New List(Of Single)
        For Each strValue As String In par_listOfValues
            listOfSingles.Add(CSng(HowManyCharsAre_Alphas(strValue)))
        Next strValue

        Return GetMeanAndStdDeviation(listOfSingles)

    End Function


    Public Shared Function GetMeanAndStdDeviation_Digits(par_listOfValues As List(Of String)) As StructMeanAndDev
        ''
        ''Added 4/22/2022 thomas downes  
        ''
        Dim listOfSingles As New List(Of Single)
        For Each strValue As String In par_listOfValues
            listOfSingles.Add(CSng(HowManyCharsAre_Digits(strValue)))
        Next strValue

        Return GetMeanAndStdDeviation(listOfSingles)

    End Function


    Public Shared Function GetMeanAndStdDeviation(par_listOfSingles As List(Of Single)) As StructMeanAndDev
        ''
        ''Added 4/22/2022 thomas downes  
        ''
        ''Dim objHistogram As MathNet.Numerics.Statistics.Histogram
        ''Dim objArrayStats As MathNet.Numerics.Statistics.ArrayStatistics
        ''Dim objDescriptiveStats As Statistics.DescriptiveStatistics
        ''Dim objBasicStatistics As Statistics.Statistics

        ''objBasicStatistics = New Statistics.Statistics()

        ''---Dim decimalMean As Decimal
        Dim doubleMean As Double
        Dim doubleStdDeviation As Double

        doubleMean = Statistics.Statistics.Mean(par_listOfSingles)

        ''2/2023 Dim tupleStdDeviationA As Tuple(Of Double, Double)
        ''2/2023 Dim tupleStdDeviationB As (Double, Double)
        Dim tupleStdDeviationC As ValueTuple(Of Double, Double)

        ''---tupleStdDeviationB = Statistics.Statistics.MeanStandardDeviation(par_listOfSingles)
        tupleStdDeviationC = Statistics.Statistics.MeanStandardDeviation(par_listOfSingles)

        doubleMean = tupleStdDeviationC.Item1
        doubleStdDeviation = tupleStdDeviationC.Item2

        Dim new_struct As New StructMeanAndDev

        new_struct.singMean = CSng(doubleMean)
        new_struct.singStdDeviation = CSng(doubleStdDeviation)
        Return new_struct

    End Function ''End of ""Public Shared Function GetMeanAndStdDeviation""



    Public Shared Function HowManyCharsAre_Alphas(pstrValue As String) As Integer
        ''
        ''Added 4/22/2022 td
        ''
        Dim intCount_Alphas As Integer = 0
        ''2/2023 Dim boolIsAlpha As Boolean

        For Each each_char As Char In pstrValue

            ''boolIsAlpha =  each_char

            Select Case each_char
                Case "a"c, "b"c, "c"c, "d"c, "e"c, "f"c, "g"c, "h"c, "i"c, "j"c, "k"c, "l"c, "m"c

                    intCount_Alphas += 1

                Case "n"c, "o"c, "p"c, "q"c, "r"c, "s"c, "t"c, "u"c, "v"c, "w"c, "x"c, "y"c, "z"c

                    intCount_Alphas += 1

                Case "A"c, "B"c, "C"c, "D"c, "E"c, "F"c, "G"c, "H"c, "I"c, "J"c, "K"c, "L"c, "M"c

                    intCount_Alphas += 1

                Case "N"c, "O"c, "P"c, "Q"c, "R"c, "S"c, "T"c, "Y"c, "V"c, "W"c, "X"c, "Y"c, "Z"c

                    intCount_Alphas += 1

            End Select

        Next each_char

        Return intCount_Alphas

    End Function


    Public Shared Function HowManyCharsAre_Digits(pstrValue As String) As Integer
        ''
        ''Added 4/22/2022 td
        ''
        Dim intCount_Digits As Integer = 0

        For Each each_char As Char In pstrValue

            Select Case each_char
                Case "0"c, "1"c, "2"c, "3"c, "4"c, "5"c, "6"c, "7"c, "8"c, "9"c

                    intCount_Digits += 1

            End Select

        Next each_char

        Return intCount_Digits

    End Function





End Class
