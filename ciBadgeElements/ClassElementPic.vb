Option Infer On
Option Explicit On
Option Strict On

''
''Added 7/18/2019 thomas downes 
''
Imports System.Drawing ''Added 9/18/2019 td
Imports System.Windows.Forms ''Added 9/18/2019 td
Imports ciBadgeInterfaces ''Added 8/14/2019 thomas d. 

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

    Public Property PositionalMode As String Implements IElement_Base.PositionalMode ''Added 8/14/2019 td 

    Public Property FormControl As Control Implements IElement_Base.FormControl ''Added 7/19/2019  

    Public Property ElementType As String Implements IElement_Base.ElementType ''Text, Pic, or Logo

    ''9/12/2019 td''Public Property LayoutWidth As Integer Implements IElement_Base.LayoutWidth_Pixels ''This provides sizing context & scaling factors. 
    Public Property BadgeLayout As BadgeLayoutClass Implements IElement_Base.BadgeLayout ''This provides sizing context & scaling factors. 

    Public Property TopEdge_Pixels As Integer Implements IElement_Base.TopEdge_Pixels
    Public Property LeftEdge_Pixels As Integer Implements IElement_Base.LeftEdge_Pixels

    Public Property Width_Pixels As Integer Implements IElement_Base.Width_Pixels
    Public Property Height_Pixels As Integer Implements IElement_Base.Height_Pixels

    ''8/29/2019 td''Public Property Border_Pixels As Integer Implements IElement_Base.Border_Pixels
    Public Property Border_WidthInPixels As Integer Implements IElement_Base.Border_WidthInPixels
    Public Property Border_Color As System.Drawing.Color Implements IElement_Base.Border_Color
    Public Property Border_Displayed As Boolean Implements IElement_Base.Border_Displayed ''Added 9/9/2019 td

    ''Added 9/4/2019 td 
    Public Property Back_Transparent As Boolean Implements IElement_Base.Back_Transparent

    Public Property Back_Color As System.Drawing.Color Implements IElement_Base.Back_Color

    ''Added 8/2/2019 td
    ''
    Public Property SelectedHighlighting As Boolean Implements IElement_Base.SelectedHighlighting

    ''
    ''Added 7/31/2019 thomas downes
    ''
    Public Property PicFileType As String Implements IElementPic.PicFileType
    Public Property PicFileTitleExt As String Implements IElementPic.PicFileTitleExt

    Public Property PicFileIndex As Integer Implements IElementPic.PicFileIndex ''Added 8/16/2019 thomasd downes


    ''9/2 td''Public Property OrientationToLayout As String Implements IElementPic.OrientationToLayout
    ''9/2 td''Public Property OrientationDegrees As Integer Implements IElementPic.OrientationDegrees

    Public Property OrientationToLayout As String Implements IElement_Base.OrientationToLayout
    Public Property OrientationInDegrees As Integer Implements IElement_Base.OrientationInDegrees

    ''Public Property PicFileIndex As Integer Implements IElementPic.PicFileIndex ''Added 8/13/2019 td  
    ''Public Property OrientationDegrees As Integer Implements IElementPic.OrientationDegrees ''Added 8/13/2019 td  

    Public Property Image_BL As Image Implements IElement_Base.Image_BL ''Added 9/2/2019 td

    Public Property Recipient As IRecipient Implements IElementPic.Recipient ''Added 9/10/2019 td

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

    Public Sub New(par_rectangle As Rectangle, par_layout As PictureBox)
        ''
        ''Added 9/16/2019 td
        ''
        BadgeLayout = New BadgeLayoutClass(par_layout)

        ''Added 9/16/2019 td
        Me.LeftEdge_Pixels = par_rectangle.Left
        Me.TopEdge_Pixels = par_rectangle.Top

        ''Added 9/16/2019 td
        Me.Width_Pixels = par_rectangle.Width
        Me.Height_Pixels = par_rectangle.Height

    End Sub ''ENd of ""Public Sub New(par_rectangle As Rectangle, par_layout As PictureBox)""

    Public Function Copy() As ClassElementPic
        ''
        ''Added 9/17/2019 
        ''
        Dim objCopy As New ClassElementPic
        objCopy.LoadbyCopyingMembers(Me, Me)
        Return objCopy

    End Function ''End of "Public Function Copy() As ClassElementPic"

    Public Sub LoadbyCopyingMembers(par_ElementInfo_Base As IElement_Base,
                                  par_ElementInfo_Pic As IElementPic)
        ''
        ''Added 9/17/2019 thomas downes
        ''
        ''
        ''First, Element-related information.
        ''
        Me.Back_Color = par_ElementInfo_Base.Back_Color
        Me.Back_Transparent = par_ElementInfo_Base.Back_Transparent
        Me.BadgeLayout = par_ElementInfo_Base.BadgeLayout
        Me.Border_Color = par_ElementInfo_Base.Border_Color
        Me.Border_Displayed = par_ElementInfo_Base.Border_Displayed
        Me.Border_WidthInPixels = par_ElementInfo_Base.Border_WidthInPixels

        Me.Height_Pixels = par_ElementInfo_Base.Height_Pixels
        Me.LeftEdge_Pixels = par_ElementInfo_Base.LeftEdge_Pixels
        Me.OrientationInDegrees = par_ElementInfo_Base.OrientationInDegrees
        Me.OrientationToLayout = par_ElementInfo_Base.OrientationToLayout

        Me.PositionalMode = par_ElementInfo_Base.PositionalMode
        Me.SelectedHighlighting = par_ElementInfo_Base.SelectedHighlighting

        Me.TopEdge_Pixels = par_ElementInfo_Base.TopEdge_Pixels
        Me.Width_Pixels = par_ElementInfo_Base.Width_Pixels

        ''
        ''Next, Picture-related information.
        ''
        ''   Public Property PicFileType As String Implements IElementPic.PicFileType
        ''   Public Property PicFileTitleExt As String Implements IElementPic.PicFileTitleExt
        ''
        Me.PicFileIndex = par_ElementInfo_Pic.PicFileIndex
        Me.PicFileTitleExt = par_ElementInfo_Pic.PicFileTitleExt
        Me.PicFileType = par_ElementInfo_Pic.PicFileType

    End Sub ''End of "Public Sub LoadbyCopyingMembers(par_ElementInfo_Base As IElement_Base, .....)"

End Class


