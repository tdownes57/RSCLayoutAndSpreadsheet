﻿''Added 7/18/2019 thomas downes
''
'' A test object that needs to be serialized.
''
<Serializable()>
Public Class ClassElementText
    Implements IElement
    ''
    ''Added 7/18/2019 thomas downes
    ''
    ''

    Public Property Info As IElementText

    Public Property FormControl As Control Implements IElement.FormControl ''Added 7/19/2019  

    Public Property ElementType As String Implements IElement.ElementType ''Text, Pic, or Logo

    Public Property LayoutWidth As Integer Implements IElement.LayoutWidth_Pixels ''This provides sizing context & scaling factors. 

    Public Property TopEdge As Integer Implements IElement.TopEdge_Pixels
    Public Property LeftEdge As Integer Implements IElement.LeftEdge_Pixels

    Public Property Width As Integer Implements IElement.Width_Pixels
    Public Property Height As Integer Implements IElement.Height_Pixels

    Public Property Border_Pixels As Integer Implements IElement.Border_Pixels
    Public Property Border_Color As System.Drawing.Color Implements IElement.Border_Color

    Public Property Back_Color As System.Drawing.Color Implements IElement.Back_Color

    Public Sub New(par_control As Control)

        ''Added 7/19/2019 td
        ''
        Me.FormControl = par_control

    End Sub


End Class
