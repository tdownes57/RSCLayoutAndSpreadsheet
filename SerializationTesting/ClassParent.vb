''
''Added 7/19/2019 td 
''

Imports System.Runtime.Serialization
Imports System.IO

Public Class ClassParent
    ''
    ''Added 7/19/2019  
    ''
    Public MyChild As New ClassChild

    Public Property ElementType As String ''Implements IElement.ElementType ''Text, Pic, or Logo

    Public Property LayoutWidth As Integer ''Implements IElement.LayoutWidth_Pixels ''This provides sizing context & scaling factors. 

    Public Property TopEdge As Integer ''Implements IElement.TopEdge_Pixels
    Public Property LeftEdge As Integer ''Implements IElement.LeftEdge_Pixels

    Public Sub SerializeMe()
        ''
        ''Added  7/19/2019 thomas d.  
        ''




    End Sub



End Class
