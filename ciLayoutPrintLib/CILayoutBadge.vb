Option Explicit On
Option Strict On

''Added 6/27/2019 thomas downes 

''Imports System.Web.Mvc ''Added 6/27/2019 td
Imports System.ComponentModel.DataAnnotations ''Added 6/27/2019 td

Public Class CILayoutBadge

    <Key> <Display(Name:="CI Layout ID")>
    Public Property CILayoutBadgeId() As Integer

    Public FullName As CILayoutText
    Public HolderID As CILayoutText
    ''6/27 td''Public CustomField1 As CILayoutText
    ''6/27 td''Public CustomField2 As CILayoutText
    Public PicPortrait As CILayoutPic

    Public T1 As CILayoutText
    Public T2 As CILayoutText

End Class
