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
