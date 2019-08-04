Option Infer On
Option Explicit On
Option Strict On

''
''Added 7/18/2019 thomas downes 
''
Public Class ClassElementPic
    ''
    ''Added 7/18/2019 thomas downes 
    ''
    Implements IElement_Base, IElementPic
    ''
    ''Added 7/18/2019 thomas downes
    ''
    ''
    Public Shared ElementPicture As ClassElementPic ''Added 7/31/2019 thomas d.

    Public Property Info As IElementPic

    Public Property FormControl As Control Implements IElement_Base.FormControl ''Added 7/19/2019  

    Public Property ElementType As String Implements IElement_Base.ElementType ''Text, Pic, or Logo

    Public Property LayoutWidth As Integer Implements IElement_Base.LayoutWidth_Pixels ''This provides sizing context & scaling factors. 

    Public Property TopEdge As Integer Implements IElement_Base.TopEdge_Pixels
    Public Property LeftEdge As Integer Implements IElement_Base.LeftEdge_Pixels

    Public Property Width As Integer Implements IElement_Base.Width_Pixels
    Public Property Height As Integer Implements IElement_Base.Height_Pixels

    Public Property Border_Pixels As Integer Implements IElement_Base.Border_Pixels
    Public Property Border_Color As System.Drawing.Color Implements IElement_Base.Border_Color

    Public Property Back_Color As System.Drawing.Color Implements IElement_Base.Back_Color

    ''Added 8/2/2019 td
    ''
    Public Property SelectedHighlighting As Boolean Implements IElement_Base.SelectedHighlighting

    ''
    ''Added 7/31/2019 thomas downes
    ''
    Public Property PicFileType As String Implements IElementPic.PicFileType
    Public Property PicFileTitleExt As String Implements IElementPic.PicFileTitleExt
    Public Property OrientationToLayout As String Implements IElementPic.OrientationToLayout


    Public Sub New(par_control As Control)

        ''Added 7/19/2019 td
        ''
        Me.FormControl = par_control

    End Sub

    ''Public Sub New(par_infoForPic As IElementPic)
    ''    ''
    ''    ''Added 7/31/2019 td
    ''    ''
    ''    Me.Info = par_infoForPic

    ''End Sub

    Public Sub New()
        ''
        ''Added 7/31/2019 td
        ''


    End Sub

End Class


