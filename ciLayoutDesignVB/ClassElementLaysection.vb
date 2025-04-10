﻿Option Explicit On
Option Strict On

''
''Added 9/17/2019 td  
''
Imports ciBadgeInterfaces

Public Class ClassElementLaysection
    Implements IElement_Base
    ''
    ''Added 9/17/2019 td  
    ''
    Private mod_cache As ClassElementsCache

    Public Property SubLayout As ciBadgeInterfaces.BadgeLayoutClass ''Added 9/17/2019 thomas downes

    Public Property FormControl As Control Implements IElement_Base.FormControl ''Added 7/19/2019  

    Public Property ElementType As String = "Text" Implements IElement_Base.ElementType ''Text, Pic, or Logo

    ''9/11/2019 td''Public Property LayoutWidth_Pixels As Integer Implements IElement_Base.LayoutWidth_Pixels ''This provides sizing context & scaling factors. 
    Public Property BadgeLayout As BadgeLayoutClass Implements IElement_Base.BadgeLayout ''Added 9/11/2019 td  

    Public Property TopEdge_Pixels As Integer = 0 Implements IElement_Base.TopEdge_Pixels
    Public Property LeftEdge_Pixels As Integer = 0 Implements IElement_Base.LeftEdge_Pixels

    Public Property Width_Pixels As Integer = 253 Implements IElement_Base.Width_Pixels
    Public Property Height_Pixels As Integer = 33 Implements IElement_Base.Height_Pixels

    ''8/29/2019 td''Public Property Border_Pixels As Integer Implements IElement_Base.Border_Pixels
    Public Property Border_WidthInPixels As Integer = 1 Implements IElement_Base.Border_WidthInPixels
    Public Property Border_Color As System.Drawing.Color = Color.Black Implements IElement_Base.Border_Color
    Public Property Border_Displayed As Boolean = True Implements IElement_Base.Border_Displayed ''Added 9/9/2019 td 

    Public Property Back_Color As System.Drawing.Color = Color.White Implements IElement_Base.Back_Color
    Public Property Back_Transparent As Boolean = False Implements IElement_Base.Back_Transparent ''Added 9/4/2019 thomas d. 

    Public Property SelectedHighlighting As Boolean Implements IElement_Base.SelectedHighlighting ''Added 8/2/2019 td 

    Public Property PositionalMode As String Implements IElement_Base.PositionalMode ''Added 8/14/2019 td 

    Public Property OrientationToLayout As String Implements IElement_Base.OrientationToLayout ''E.g. "L" (Landscape) (by far the most common) or "P" for Portrait  

    Public Property OrientationInDegrees As Integer Implements IElement_Base.OrientationInDegrees ''Default is 0, normal.  90 would be 1/4 turn clockwise.  180 is upside-down.  270 is the printing on the spine of a book sitting on the bookshelf.

    Public Property Image_BL As Image Implements IElement_Base.Image_BL ''Added 8/27/2019 td



End Class ''ENd of "Public Class ClassElementLaysection"
