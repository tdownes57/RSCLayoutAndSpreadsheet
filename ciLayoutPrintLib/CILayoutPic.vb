Option Explicit On
Option Strict On

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
''Imports System.Web.Mvc ''Added 5/28/2019 td
Imports System.ComponentModel.DataAnnotations ''Added 5/28/2019 td
Imports System.Drawing ''Added 6/13/2019 thomas d. 

Public Class CILayoutPic

    <Key> <Display(Name:="CI Layout Pic ID")>
    Public Property CILayoutPicId() As Integer


    <Display(Name:="Top-Edge Position in Pixels")>
    Public Property TopEdgePositionPixels() As Integer

    <Display(Name:="Left-Edge Position in Pixels")>
    Public Property LeftEdgePositionPixels() As Integer

    <Display(Name:="Width (or Length) in Pixels")>
    Public Property WidthLengthPixels() As Integer

    <Display(Name:="Height in Pixels")>
    Public Property HeightPixels() As Integer

    Public Sub New()
        ''
        ''Added 6/25/2019 thomas downes
        ''
        Me.CILayoutPicId = 1

        Me.LeftEdgePositionPixels = 160
        Me.TopEdgePositionPixels = 40

        Me.HeightPixels = 200
        Me.WidthLengthPixels = 160

    End Sub

End Class

