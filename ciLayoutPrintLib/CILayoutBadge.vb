Option Explicit On
Option Strict On

''Added 6/27/2019 thomas downes 

''Imports System.Web.Mvc ''Added 6/27/2019 td
Imports System.ComponentModel.DataAnnotations ''Added 6/27/2019 td
Imports System.Web.Mvc ''Added 6/27/2019 td  

Public Class CILayoutBadge

    <Key> <Display(Name:="CI Layout ID")>
    Public Property CILayoutBadgeId() As Integer

    Public FullName As New CILayoutText
    Public HolderID As New CILayoutText
    ''6/27 td''Public CustomField1 As CILayoutText
    ''6/27 td''Public CustomField2 As CILayoutText
    Public PicPortrait As New CILayoutPic

    Public T1 As New CILayoutText
    Public T2 As New CILayoutText

    ''Added 7/10/2019 TD
    Public T3 As CILayoutText ''Added 7/10/2019 TD
    Public T4 As CILayoutText ''Added 7/10/2019 TD

    Public Property T1_FieldName() As String
    Public Property T1_TopEdgePositionPixels() As Integer
    Public Property T1_LeftEdgePositionPixels() As Integer
    Public Property T1_WidthLengthPixels() As Integer
    Public Property T1_HeightPixels() As Integer
    Public Property T1_FontFamilyName() As String
    Public Property T1_FontSize() As Integer
    Public Property T1_FontColor() As String
    Public Property T1_BackgroundColor() As String

    Public Property T2_FieldName() As String
    Public Property T2_TopEdgePositionPixels() As Integer
    Public Property T2_LeftEdgePositionPixels() As Integer
    Public Property T2_WidthLengthPixels() As Integer
    Public Property T2_HeightPixels() As Integer
    Public Property T2_FontFamilyName() As String
    Public Property T2_FontSize() As Integer
    Public Property T2_FontColor() As String
    Public Property T2_BackgroundColor() As String

    ''Added 7/10/2019 thomas downes
    '' 
    Public Property T3_FieldName() As String
    Public Property T3_TopEdgePositionPixels() As Integer
    Public Property T3_LeftEdgePositionPixels() As Integer
    Public Property T3_WidthLengthPixels() As Integer
    Public Property T3_HeightPixels() As Integer
    Public Property T3_FontFamilyName() As String
    Public Property T3_FontSize() As Integer
    Public Property T3_FontColor() As String
    Public Property T3_BackgroundColor() As String

    ''Added 7/10/2019 thomas downes
    '' 
    Public Property T4_FieldName() As String
    Public Property T4_TopEdgePositionPixels() As Integer
    Public Property T4_LeftEdgePositionPixels() As Integer
    Public Property T4_WidthLengthPixels() As Integer
    Public Property T4_HeightPixels() As Integer
    Public Property T4_FontFamilyName() As String
    Public Property T4_FontSize() As Integer
    Public Property T4_FontColor() As String
    Public Property T4_BackgroundColor() As String

    ''Added 7/07/2019 thomas downes
    '' 
    ''   Ratio of Badge Height to Width (for Landscape Mode Designing)
    ''
    Public Const RatioBadge_HeightToWidth_Land_Eg1 As Single = (695 / 1081) '' ORO835 - OrovilleHS
    Public Const RatioBadge_HeightToWidth_Land_Eg2a As Single = (633 / 1009) '' SOU735 - IVC-VENDOR 
    Public Const RatioBadge_HeightToWidth_Land_Eg2b As Single = (633 / 1009) '' SOU735 - SADDLEBACK-VENDOR

    Public Const RatioBadge_HeightToWidth_Land_1 As Single = (0.643) '' SOU735 - SADDLEBACK-VENDOR
    Public Const RatioBadge_HeightToWidth_Land_2 As Single = (0.627) '' SOU735 - SADDLEBACK-VENDOR

    Public Sub New()
        ''
        ''Added 6/27/2019 thomas downes
        ''
        T2.TopEdgePositionPixels = 2 * T1.TopEdgePositionPixels
        T2.LeftEdgePositionPixels = 2 * T1.LeftEdgePositionPixels

    End Sub

    Public Sub Update_T1()
        ''
        ''Added 6/27/2019 thomas downes
        ''
        T1.BackgroundColor = T1_BackgroundColor
        T1.FieldName = T1_BackgroundColor
        T1.FontColor = T1_FontColor
        T1.FontFamilyName = T1_FontFamilyName
        T1.FontSize = T1_FontSize
        T1.HeightPixels = T1_HeightPixels
        T1.LeftEdgePositionPixels = T1_LeftEdgePositionPixels
        T1.TopEdgePositionPixels = T1_TopEdgePositionPixels
        T1.WidthLengthPixels = T1_WidthLengthPixels

    End Sub ''End of "Public Sub Update_T1"

    Public Sub Update_T2()
        ''
        ''Added 6/27/2019 thomas downes
        ''
        T2.BackgroundColor = T2_BackgroundColor
        T2.FieldName = T2_BackgroundColor
        T2.FontColor = T2_FontColor
        T2.FontFamilyName = T2_FontFamilyName
        T2.FontSize = T2_FontSize
        T2.HeightPixels = T2_HeightPixels
        T2.LeftEdgePositionPixels = T2_LeftEdgePositionPixels
        T2.TopEdgePositionPixels = T2_TopEdgePositionPixels
        T2.WidthLengthPixels = T2_WidthLengthPixels

    End Sub ''End of "Public Sub Update_T2"

    Public Sub Update_T3()
        ''
        ''Added 7/10/2019 thomas downes
        ''
        If (T3 Is Nothing) Then T3 = New CILayoutText ''Added 7/10/2019 td

        T3.BackgroundColor = T3_BackgroundColor
        T3.FieldName = T3_BackgroundColor
        T3.FontColor = T3_FontColor
        T3.FontFamilyName = T3_FontFamilyName
        T3.FontSize = T3_FontSize
        T3.HeightPixels = T3_HeightPixels
        T3.LeftEdgePositionPixels = T3_LeftEdgePositionPixels
        T3.TopEdgePositionPixels = T3_TopEdgePositionPixels
        T3.WidthLengthPixels = T3_WidthLengthPixels

    End Sub ''End of "Public Sub Update_T3"

    Public Sub Update_T4()
        ''
        ''Added 7/10/2019 thomas downes
        ''
        If (T4 Is Nothing) Then T4 = New CILayoutText ''Added 7/10/2019 td

        T4.BackgroundColor = T4_BackgroundColor
        T4.FieldName = T4_BackgroundColor
        T4.FontColor = T4_FontColor
        T4.FontFamilyName = T4_FontFamilyName
        T4.FontSize = T4_FontSize
        T4.HeightPixels = T4_HeightPixels
        T4.LeftEdgePositionPixels = T4_LeftEdgePositionPixels
        T4.TopEdgePositionPixels = T4_TopEdgePositionPixels
        T4.WidthLengthPixels = T4_WidthLengthPixels

    End Sub ''End of "Public Sub Update_T4"

    Public Function FormValues_T1(par_formValues As FormCollection) As FormCollection

        Dim outputCollection1 As New FormCollection
        Dim outputCollection2 As New FormCollection
        Dim each_key As String
        ''Dim each_value As String

        ''
        ''   https://stackoverflow.com/questions/6995285/how-to-access-my-formcollection-in-action-method-asp-net-mvc 
        ''
        outputCollection1.Add(par_formValues)

        For Each each_key In outputCollection1.AllKeys

            ''each_value = par_formValues(each_key)

            If (each_key.ToString().StartsWith("T1.")) Then

                outputCollection2.Add(each_key.Replace("T1.", ""),
                                      par_formValues.GetValue(each_key).AttemptedValue)

            Else

                ''outputCollection.Add(par_formValues[each_key])
                outputCollection1.Remove(each_key)

            End If

        Next each_key

        Return outputCollection2

    End Function ''end of "Public Function FormValues_T1"

    Public Function FormValues_T2(par_formValues As FormCollection) As FormCollection

        Dim outputCollection1 As New FormCollection
        Dim outputCollection2 As New FormCollection
        Dim each_key As String
        ''Dim each_value As String

        ''
        ''   https://stackoverflow.com/questions/6995285/how-to-access-my-formcollection-in-action-method-asp-net-mvc 
        ''
        outputCollection1.Add(par_formValues)

        For Each each_key In outputCollection1.AllKeys

            ''each_value = par_formValues(each_key)

            If (each_key.ToString().StartsWith("T2.")) Then

                outputCollection2.Add(each_key.Replace("T2.", ""),
                                      par_formValues.GetValue(each_key).AttemptedValue)

            Else

                ''outputCollection.Add(par_formValues[each_key])
                outputCollection1.Remove(each_key)

            End If

        Next each_key

        Return outputCollection2

    End Function ''end of "Public Function FormValues_T2"

    Public Function FormValues_T3(par_formValues As FormCollection) As FormCollection
        ''
        ''Added 7/10/2019 Thomas downes
        ''
        Dim outputCollection1 As New FormCollection
        Dim outputCollection2 As New FormCollection
        Dim each_key As String
        ''Dim each_value As String

        ''
        ''   https://stackoverflow.com/questions/6995285/how-to-access-my-formcollection-in-action-method-asp-net-mvc 
        ''
        outputCollection1.Add(par_formValues)

        For Each each_key In outputCollection1.AllKeys

            ''each_value = par_formValues(each_key)

            If (each_key.ToString().StartsWith("T3.")) Then

                outputCollection2.Add(each_key.Replace("T3.", ""),
                                      par_formValues.GetValue(each_key).AttemptedValue)

            Else

                outputCollection1.Remove(each_key)

            End If

        Next each_key

        Return outputCollection2

    End Function ''end of "Public Function FormValues_T3"

    Public Function FormValues_T4(par_formValues As FormCollection) As FormCollection
        ''
        ''Added 7/10/2019 Thomas downes
        ''
        Dim outputCollection1 As New FormCollection
        Dim outputCollection2 As New FormCollection
        Dim each_key As String

        ''
        ''   https://stackoverflow.com/questions/6995285/how-to-access-my-formcollection-in-action-method-asp-net-mvc 
        ''
        outputCollection1.Add(par_formValues)

        For Each each_key In outputCollection1.AllKeys

            ''each_value = par_formValues(each_key)

            If (each_key.ToString().StartsWith("T4.")) Then

                outputCollection2.Add(each_key.Replace("T4.", ""),
                                      par_formValues.GetValue(each_key).AttemptedValue)

            Else

                outputCollection1.Remove(each_key)

            End If

        Next each_key

        Return outputCollection2

    End Function ''end of "Public Function FormValues_T4"

    Public Sub UpdateByFormValues(par_formValues As FormCollection)
        ''
        ''Added 6/27/2019 thomas downes
        ''
        ''   https://stackoverflow.com/questions/6995285/how-to-access-my-formcollection-in-action-method-asp-net-mvc 
        ''
        ''        think you should attempt To stear clear Of the formcollection Object If you are able To, in favour of a 
        ''  strongly typed viewmodel. there are a few examples here on SO And i've linked the 1st one that I searched for:
        ''
        ''passing FormCollection to controller via JQuery Post method And getting data back...
        ''
        ''however, If you're keen to tie yourself in knots :), then here's an example iterating thro a formcollection:
        ''
        ''    http://stack247.wordpress.com/2011/03/20/iterate-through-system-web-mvc-formcollection/
        ''
        Dim each_key As String
        Dim each_value As String

        ''
        ''   https://stackoverflow.com/questions/6995285/how-to-access-my-formcollection-in-action-method-asp-net-mvc 
        ''

        For Each each_key In par_formValues.AllKeys

            each_value = par_formValues(each_key)

            Select Case each_key

                Case "T1.TopEdgePositionInPixels"

                    T1.TopEdgePositionPixels = Integer.Parse(each_value)









            End Select


        Next each_key

    End Sub ''End of "Public Sub UpdateByFormValues(par_formValues As FormCollection)"

End Class
