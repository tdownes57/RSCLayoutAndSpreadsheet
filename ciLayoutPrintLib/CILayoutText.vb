Option Explicit On
Option Strict On

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
''Imports System.Web.Mvc ''Added 5/28/2019 td
Imports System.ComponentModel.DataAnnotations ''Added 5/28/2019 td
Imports System.Drawing ''Added 6/13/2019 thomas d. 

Public Class CILayoutText

    <Key> <Display(Name:="CI Layout Text ID")>
    Public Property CILayoutTextId() As Integer

    <Display(Name:="Field Name")>
    Public Property FieldName() As String

    <Display(Name:="Top-Edge Position in Pixels")>
    Public Property TopEdgePositionPixels() As Integer

    <Display(Name:="Left-Edge Position in Pixels")>
    Public Property LeftEdgePositionPixels() As Integer

    <Display(Name:="Width (or Length) in Pixels")>
    Public Property WidthLengthPixels() As Integer

    <Display(Name:="Height in Pixels")>
    Public Property HeightPixels() As Integer

    <Display(Name:="Font Size in Pixels")>
    Public Property FontSize() As Integer

    ''' <summary>
    ''' Khaki #F0E68C  https://www.w3schools.com/cssref/css_colors.asp
    ''' </summary>
    ''' <returns></returns>
    <Display(Name:="Font Color")>
    Public Property FontColor() As String

    ''' <summary>
    ''' Light Slate Grey #778899  https://www.w3schools.com/cssref/css_colors.asp
    ''' </summary>
    <Display(Name:="Background Color")>
    Public Property BackgroundColor() As String


    ''[Display(Name = "Top-Edge Position in Pixels")]
    ''  Public int TopEdgePositionPixels { Get; Set; }

    ''  [Display(Name = "Left-Edge Position in Pixels")]
    ''  Public int LeftEdgePositionPixels { Get; Set; }

    ''  [Display(Name = "Width (or Length) in Pixels")]
    ''  Public int WidthLengthPixels { Get; Set; }

    ''  [Display(Name = "Height of Text Area in Pixels")]
    ''  Public int HeightPixels { Get; Set; }

    ''  [Display(Name = "Font Size")]
    ''  Public int FontSize { Get; Set; }

    ''  [Display(Name = "Font Family Name")]
    ''  Public String FontFamilyName { Get; Set; }

    Public Sub New()
        ''
        ''Added 6/25/2019 thomas downes
        ''
        Me.CILayoutTextId = 1
        Me.FieldName = "Comic Sans"
        Me.FontSize = 12
        Me.LeftEdgePositionPixels = 20
        Me.TopEdgePositionPixels = 20

        Me.HeightPixels = 30
        Me.WidthLengthPixels = 300

        '' <summary>
        '' Khaki #F0E68C  https://www.w3schools.com/cssref/css_colors.asp
        '' </summary>
        Me.FontColor = "#F0E68C"

        '' <summary>
        '' Light Slate Grey #778899  https://www.w3schools.com/cssref/css_colors.asp
        '' </summary>
        Me.BackgroundColor = "#778899"

    End Sub

End Class
