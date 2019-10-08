Option Infer On
Option Explicit On
Option Strict On

''
''Added 9/30/2019 thomas downes 
''
Imports System.Drawing ''Added 9/18/2019 td
Imports System.Windows.Forms ''Added 9/18/2019 td
Imports ciBadgeInterfaces ''Added 8/14/2019 thomas d. 
Imports System.Xml.Serialization ''Added 9/24/2019 td
''imports system.serial

<Serializable>
Public Class ClassElementQRCode
    ''
    ''Added 9/30/2019 thomas downes 
    ''
    Implements IElement_Base, IElementQRCode
    ''
    ''Added 9/30/2019 thomas downes
    ''
    ''
    Public Shared ElementQRCode As ClassElementQRCode ''Added 9/30/2019 thomas d.

    <Xml.Serialization.XmlIgnore>
    Public Property Info As IElementQRCode

    Public Property PositionalMode As String Implements IElement_Base.PositionalMode ''Added 8/14/2019 td 

    <Xml.Serialization.XmlIgnore>
    Public Property FormControl As Control Implements IElement_Base.FormControl ''Added 7/19/2019  

    Public Property ElementType As String Implements IElement_Base.ElementType ''Text, Pic, or Logo

    ''9/12/2019 td''Public Property LayoutWidth As Integer Implements IElement_Base.LayoutWidth_Pixels ''This provides sizing context & scaling factors. 
    Public Property BadgeLayout As BadgeLayoutClass Implements IElement_Base.BadgeLayout ''This provides sizing context & scaling factors. 

    Public Property TopEdge_Pixels As Integer Implements IElement_Base.TopEdge_Pixels
    Public Property LeftEdge_Pixels As Integer Implements IElement_Base.LeftEdge_Pixels

    Private mod_width_pixels As Integer ''Added 9/23/2019 td 
    Public Property Width_Pixels As Integer Implements IElement_Base.Width_Pixels
        Get
            Return mod_width_pixels
        End Get
        Set(value As Integer)

            mod_width_pixels = value ''Added 9/23/2019 thomas downes

            ''
            ''Are we initializing Height & Width?   
            ''
            ''Added 9/23/2019 thomas downes
            Dim boolLikelyInitializing As Boolean ''Added 9/23/2019 thomas d. 
            Dim intOtherPropertyValue As Integer ''Added 9/23/2019 thomas d. 
            intOtherPropertyValue = mod_height_pixels
            boolLikelyInitializing = (0 = intOtherPropertyValue)
            If (boolLikelyInitializing) Then Exit Property ''Added 9/23/2019 td 

            ''
            ''Inform software developer of programming which violates design expectations.
            ''
            Dim boolShorterThanWidth As Boolean ''Added 9/23/2019 thomas downes
            Dim boolGiveDisallowedMsg As Boolean ''Added 9/23/2019 thomas downes
            ''9/23 td''boolShorterThanWidth = (mod_height_pixels < mod_width_pixels) ''value)
            boolShorterThanWidth = (mod_height_pixels < value)
            boolGiveDisallowedMsg = boolShorterThanWidth
            If (boolGiveDisallowedMsg) Then
                Throw New Exception("The Height cannot be less than the width #1 (rotation is _not_ an exception to this).")
            End If ''End of "If (boolGiveDisallowedMsg) Then"

            ''Added 9/23/2019 td
            Const c_False_RegardlessOfRotation As Boolean = False
            CheckWidthVsLength_OfPic(mod_width_pixels, mod_height_pixels, c_False_RegardlessOfRotation)

        End Set
    End Property

    Private mod_height_pixels As Integer ''Added 9/23/2019 td 
    Public Property Height_Pixels As Integer Implements IElement_Base.Height_Pixels
        Get
            Return mod_height_pixels
        End Get
        Set(value As Integer)

            mod_height_pixels = value ''Added 9/23/2019 thomas downes

            ''
            ''Are we initializing Height & Width?   
            ''
            Dim boolLikelyInitializing As Boolean ''Added 9/23/2019 thomas d. 
            Dim intOtherPropertyValue As Integer ''Added 9/23/2019 thomas d. 
            intOtherPropertyValue = mod_width_pixels
            boolLikelyInitializing = (0 = intOtherPropertyValue)
            If (boolLikelyInitializing) Then Exit Property ''Added 9/23/2019 td 

            ''
            ''Inform software developer of programming which violates design expectations.
            ''
            Dim boolShorterThanWidth As Boolean ''Added 9/23/2019 thomas downes
            Dim boolGiveDisallowedMsg As Boolean ''Added 9/23/2019 thomas downes
            ''Added 9/23/2019 thomas downes
            ''9/23/2019 td''boolTallerThanWidth = (mod_height_pixels > mod_width_pixels)
            boolShorterThanWidth = (mod_height_pixels < mod_width_pixels)
            boolGiveDisallowedMsg = boolShorterThanWidth
            If (boolGiveDisallowedMsg) Then
                Throw New Exception("The Height cannot be less than the width #2 (rotation is _not_ an exception to this).")
            End If ''End of "If (boolGiveDisallowedMsg) Then"

            ''Added 9/23/2019 td
            Const c_False_RegardlessOfRotation As Boolean = False
            CheckWidthVsLength_OfPic(mod_width_pixels, mod_height_pixels, c_False_RegardlessOfRotation)

        End Set
    End Property

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


    Public Property OrientationToLayout As String Implements IElement_Base.OrientationToLayout
    Public Property OrientationInDegrees As Integer Implements IElement_Base.OrientationInDegrees

    <Xml.Serialization.XmlIgnore>
    Public Property Image_BL As Image Implements IElement_Base.Image_BL ''Added 9/2/2019 td

    Public Property Visible As Boolean Implements IElement_Base.Visible ''Added 9/19/2019 td  

    Public Property QRFormula As String Implements IElementQRCode.QRFormula ''Added 9/30/2019 td  

    Public Sub New(par_control As Control)

        ''Added 7/19/2019 td
        ''
        Me.FormControl = par_control

    End Sub

    Public Sub New()
        ''
        ''Added 9/30/2019 td
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

    Public Function Copy() As ClassElementQRCode
        ''
        ''Added 9/30/2019 
        ''
        Dim objCopy As New ClassElementQRCode
        objCopy.LoadbyCopyingMembers(Me, Me)
        Return objCopy

    End Function ''End of "Public Function Copy() As ClassElementQRCode"

    Public Sub LoadbyCopyingMembers(par_ElementInfo_Base As IElement_Base,
                                  par_ElementInfo_QR As IElementQRCode)
        ''
        ''Added 9/30/2019 thomas downes
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
        ''Next, QR Code-related information.
        '' 
        Me.QRFormula = par_ElementInfo_QR.QRFormula

    End Sub ''End of "Public Sub LoadbyCopyingMembers(par_ElementInfo_Base As IElement_Base, .....)"

    Public Shared Sub CheckWidthVsLength_OfPic(intWidth As Integer, intHeight As Integer, boolRotated As Boolean)
        ''
        ''Double-check the orientation.  ----9/23/2019 td
        ''
        Dim boolTextImageRotated_0_180 As Boolean = (intWidth < intHeight) ''Vs. Textual comparison, (intWidth > intHeight)
        Dim boolTextImageRotated_90_270 As Boolean = (intWidth > intHeight) ''Vs. Textual comparison, (intWidth < intHeight)

        If (boolTextImageRotated_0_180 And boolRotated) Then
            Throw New Exception("Image dimensions are not expected. (Rotation of pic expected)")
        ElseIf (boolTextImageRotated_90_270 And (Not boolRotated)) Then
            Throw New Exception("Image dimensions are not expected.  (Unexpected rotation of pic detected.)")
        End If ''End of "If (boolImageRotated_0_180 and boolRotated) Then .... ElseIf ..."

    End Sub ''ENd of "Public Shared Sub CheckWidthVsLength_OfPic()"

End Class