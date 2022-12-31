Option Infer On
Option Explicit On
Option Strict On

''
''Added 7/18/2019 thomas downes 
''
Imports System.Drawing ''Added 9/18/2019 td
Imports System.Windows.Forms ''Added 9/18/2019 td
Imports ciBadgeInterfaces ''Added 8/14/2019 thomas d. 
Imports System.Xml.Serialization ''Added 9/24/2019 td
''imports system.serial

#Disable Warning CA1707 ''Warning about using underscores in names. 12/2022

<Xml.Serialization.XmlInclude(GetType(ClassElementPortrait))>
<Serializable>
Public Class ClassElementPortrait ''Renamed to ClassElementPortrait from ClassElementPic. ---1/13/2022 & 10/8/2019 td 
    ''12/30/2022 Inherits ClassElementBase ''Added 1/8/2022 Thomas Downes
    Inherits ClassElementGraphic ''Added 1/8/2022 Thomas Downes
    Implements IElement_Base, IElementPic
    ''
    ''Renamed 1/13/2022 thomas downes
    ''Added 7/18/2019 thomas downes 
    ''
    ''
    ''Added 7/18/2019 thomas downes
    ''
    ''
    <Xml.Serialization.XmlIgnore>
    Public Shared ElementPicture As ClassElementPortrait ''Added 7/31/2019 thomas d.

    ''Public Property Id_GUID As System.Guid ''Added 9/30/2019 td 
    ''Public Property BadgeDisplayIndex As Integer Implements IElement_Base.BadgeDisplayIndex ''Added 11/24/2021 td 
    ''Public Property WhichSideOfCard As EnumWhichSideOfCard Implements IElement_Base.WhichSideOfCard ''Added 12/13/2021 td
    ''Public Property DateEdited As Date Implements IElement_Base.DateEdited ''Added 12/18/2021 thomas downes  
    ''Public Property DateSaved As Date Implements IElement_Base.DateSaved ''Added 12/18/2021 thomas downes

    <Xml.Serialization.XmlIgnore>
    Public Property Info_Pic As IElementPic

    ''Public Property PositionalMode As String Implements IElement_Base.PositionalMode ''Added 8/14/2019 td 

    ''<Xml.Serialization.XmlIgnore>
    ''Public Property FormControl As Control Implements IElement_Base.FormControl ''Added 7/19/2019  

    ''Public Property ElementType As String Implements IElement_Base.ElementType ''Text, Pic, or Logo

    ''''9/12/2019 td''Public Property LayoutWidth As Integer Implements IElement_Base.LayoutWidth_Pixels ''This provides sizing context & scaling factors. 
    ''Public Property BadgeLayoutDims As BadgeLayoutDimensionsClass Implements IElement_Base.BadgeLayoutDims ''This provides sizing context & scaling factors. 

    ''Public Property TopEdge_Pixels As Integer Implements IElement_Base.TopEdge_Pixels
    ''Public Property LeftEdge_Pixels As Integer Implements IElement_Base.LeftEdge_Pixels

    ''
    ''Added 5/27/2022 td
    ''
    ''May 28 2022 Public Shadows Property ConditionalExpressionValue As String Implements IElement_Base.ConditionalExpressionValue
    ''May 28 2022 Public Shadows Property ConditionalExpressionField As EnumCIBFields Implements IElement_Base.ConditionalExpressionField
    ''May 28 2022 Public Shadows Property ConditionalExpressionInUse As Boolean Implements IElement_Base.ConditionalExpressionInUse


    ''12/2022 Private mod_width_pixels As Integer ''Added 9/23/2019 td 
    ''12/2022 Public Property Width_Pixels As Integer Implements IElement_Base.Width_Pixels
    ''    Get
    ''        Return mod_width_pixels
    ''    End Get
    ''    Set(value As Integer)

    ''        mod_width_pixels = value ''Added 9/23/2019 thomas downes

    ''        ''
    ''        ''Are we initializing Height & Width?   
    ''        ''
    ''        ''Added 9/23/2019 thomas downes
    ''        Dim boolLikelyInitializing As Boolean ''Added 9/23/2019 thomas d. 
    ''        Dim intOtherPropertyValue As Integer ''Added 9/23/2019 thomas d. 
    ''        intOtherPropertyValue = mod_height_pixels
    ''        boolLikelyInitializing = (0 = intOtherPropertyValue)
    ''        If (boolLikelyInitializing) Then Exit Property ''Added 9/23/2019 td 

    ''        ''
    ''        ''Inform software developer of programming which violates design expectations.
    ''        ''
    ''        Dim boolShorterThanWidth As Boolean ''Added 9/23/2019 thomas downes
    ''        Dim boolGiveDisallowedMsg As Boolean ''Added 9/23/2019 thomas downes
    ''        ''9/23 td''boolShorterThanWidth = (mod_height_pixels < mod_width_pixels) ''value)
    ''        boolShorterThanWidth = (mod_height_pixels < value)
    ''        boolGiveDisallowedMsg = boolShorterThanWidth
    ''        If (boolGiveDisallowedMsg) Then
    ''            Throw New Exception("The Height cannot be less than the width #1 (rotation is _not_ an exception to this).")
    ''        End If ''End of "If (boolGiveDisallowedMsg) Then"

    ''        ''Added 9/23/2019 td
    ''        Const c_False_RegardlessOfRotation As Boolean = False
    ''        CheckWidthVsLength_OfPic(mod_width_pixels, mod_height_pixels, c_False_RegardlessOfRotation)

    ''    End Set
    ''End Property

    ''12/2022 Private mod_height_pixels As Integer ''Added 9/23/2019 td 
    ''12/2022 Public Property Height_Pixels As Integer Implements IElement_Base.Height_Pixels
    ''    Get
    ''        Return mod_height_pixels
    ''    End Get
    ''    Set(value As Integer)

    ''        mod_height_pixels = value ''Added 9/23/2019 thomas downes

    ''        ''
    ''        ''Are we initializing Height & Width?   
    ''        ''
    ''        Dim boolLikelyInitializing As Boolean ''Added 9/23/2019 thomas d. 
    ''        Dim intOtherPropertyValue As Integer ''Added 9/23/2019 thomas d. 
    ''        intOtherPropertyValue = mod_width_pixels
    ''        boolLikelyInitializing = (0 = intOtherPropertyValue)
    ''        If (boolLikelyInitializing) Then Exit Property ''Added 9/23/2019 td 

    ''        ''
    ''        ''Inform software developer of programming which violates design expectations.
    ''        ''
    ''        Dim boolShorterThanWidth As Boolean ''Added 9/23/2019 thomas downes
    ''        Dim bDisallowedSoBlockIt As Boolean ''Added 10/12 & 9/23/2019 thomas downes
    ''        ''Added 9/23/2019 thomas downes
    ''        ''9/23/2019 td''boolTallerThanWidth = (mod_height_pixels > mod_width_pixels)
    ''        boolShorterThanWidth = (mod_height_pixels < mod_width_pixels)
    ''        bDisallowedSoBlockIt = boolShorterThanWidth

    ''        If (bDisallowedSoBlockIt) Then
    ''            ''10/12/2019 td''Throw New Exception("The Height cannot be less than the width #2 (rotation is _not_ an exception to this).")
    ''            mod_height_pixels = mod_width_pixels
    ''        End If ''End of "If (bGiveDisallowedMsg) Then"

    ''        ''Added 9/23/2019 td
    ''        Const c_False_RegardlessOfRotation As Boolean = False
    ''        CheckWidthVsLength_OfPic(mod_width_pixels, mod_height_pixels, c_False_RegardlessOfRotation)

    ''    End Set
    ''End Property

    ''''8/29/2019 td''Public Property Border_Pixels As Integer Implements IElement_Base.Border_Pixels
    ''12/2022 Public Property Border_WidthInPixels As Integer Implements IElement_Base.Border_WidthInPixels

    ''<Xml.Serialization.XmlIgnore>
    ''12/2022 Public Property Border_Color As System.Drawing.Color Implements IElement_Base.Border_Color

    ''<XmlElement("Border_Color")>
    ''12/2022 Public Property Border_Color_HTML As String
    ''    ''Added 10/13/2019 td
    ''    Get
    ''        ''  https://stackoverflow.com/questions/376234/best-solution-for-xmlserializer-and-system-drawing-color
    ''        Return ColorTranslator.ToHtml(Me.Border_Color)
    ''    End Get
    ''    Set(value As String)
    ''        ''  https://stackoverflow.com/questions/376234/best-solution-for-xmlserializer-and-system-drawing-color
    ''        Me.Border_Color = ColorTranslator.FromHtml(value)
    ''    End Set
    ''End Property


    ''12/2022 Public Property Border_Displayed As Boolean Implements IElement_Base.Border_Displayed ''Added 9/9/2019 td

    ''''Added 9/4/2019 td 
    ''12/2022 Public Property Back_Transparent As Boolean Implements IElement_Base.Back_Transparent

    ''<Xml.Serialization.XmlIgnore>
    ''12/2022 Public Property Back_Color As System.Drawing.Color Implements IElement_Base.Back_Color

    ''<XmlElement("Back_Color")>
    ''12/2022 Public Property Back_Color_HTML As String
    ''    ''Added 10/13/2019 td
    ''    Get
    ''        ''  https://stackoverflow.com/questions/376234/best-solution-for-xmlserializer-and-system-drawing-color
    ''        Return ColorTranslator.ToHtml(Me.Back_Color)
    ''    End Get
    ''    Set(value As String)
    ''        ''  https://stackoverflow.com/questions/376234/best-solution-for-xmlserializer-and-system-drawing-color
    ''        Me.Back_Color = ColorTranslator.FromHtml(value)
    ''    End Set
    ''End Property



    ''Added 8/2/2019 td
    ''
    ''Public Property SelectedHighlighting As Boolean Implements IElement_Base.SelectedHighlighting

    ''
    ''Added 7/31/2019 thomas downes
    ''
    Public Property PicFileType As String Implements IElementPic.PicFileType
    Public Property PicFileTitleExt As String Implements IElementPic.PicFileTitleExt

    Public Property PicFileIndex As Integer Implements IElementPic.PicFileIndex ''Added 8/16/2019 thomasd downes


    ''9/2 td''Public Property OrientationToLayout As String Implements IElementPic.OrientationToLayout
    ''9/2 td''Public Property OrientationDegrees As Integer Implements IElementPic.OrientationDegrees

    ''Public Property OrientationToLayout As String Implements IElement_Base.OrientationToLayout
    ''Public Property OrientationInDegrees As Integer Implements IElement_Base.OrientationInDegrees

    ''''Public Property PicFileIndex As Integer Implements IElementPic.PicFileIndex ''Added 8/13/2019 td  
    ''''Public Property OrientationDegrees As Integer Implements IElementPic.OrientationDegrees ''Added 8/13/2019 td  

    ''<Xml.Serialization.XmlIgnore>
    ''Public Property Image_BL As Image Implements IElement_Base.Image_BL ''Added 9/2/2019 td

    ''Public Property Visible As Boolean = True Implements IElement_Base.Visible ''Added 9/19/2019 td  

    <Xml.Serialization.XmlIgnore>
    Public Property Recipient As IRecipient Implements IElementPic.Recipient ''Add ed 9/10/2019 td

    ''Public Property ZOrder As Integer Implements IElement_Base.ZOrder
    ''    Get
    ''        Return 0 ''Return DirectCast(ElementPicture, IElement_Base).ZOrder
    ''    End Get
    ''    Set(value As Integer)
    ''        Return ''DirectCast(ElementPicture, IElement_Base).ZOrder = value
    ''    End Set
    ''End Property

    Public Sub New(parControl As Control)

        ''Added 7/19/2019 td
        ''
        Me.FormControl = parControl

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
        BadgeLayoutDims = New BadgeLayoutDimensionsClass(par_layout)

        ''Added 9/16/2019 td
        Me.LeftEdge_Pixels = par_rectangle.Left
        Me.TopEdge_Pixels = par_rectangle.Top

        ''Added 9/16/2019 td
        Me.Width_Pixels = par_rectangle.Width
        Me.Height_Pixels = par_rectangle.Height

    End Sub ''ENd of ""Public Sub New(par_rectangle As Rectangle, par_layout As PictureBox)""

    Public Function GetStep3_Picture() As Image
        ''
        ''Added 10/18/2019 thomas d
        ''
        Dim strRecipID As String

        If (ClassElementFieldV3.oRecipient Is Nothing) Then Return Nothing

        strRecipID = ClassElementFieldV3.oRecipient.RecipientID()

        If (strRecipID = "") Then Return Nothing

        Return ciPictures_VB.PictureExamples.GetImageByRecipID(strRecipID)

    End Function ''End of Public Function GetStep3_Picture  


    Public Function Copy_Portrait() As ClassElementPortrait
        ''
        ''Added 9/17/2019 
        ''
        Dim objCopy As New ClassElementPortrait
        objCopy.LoadbyCopyingMembers_Pic(Me, Me)
        Return objCopy

    End Function ''End of "Public Function Copy_Portrait() As ClassElementPic"


#Disable Warning CA1707

    Public Sub LoadbyCopyingMembers_Pic(par_ElementInfo_Base As IElement_Base,
                                  par_ElementInfo_Pic As IElementPic)
        ''
        ''Added 9/17/2019 thomas downes
        ''

        ''
        ''First, Element-related information.
        ''
        Me.Back_Color = par_ElementInfo_Base.Back_Color
        Me.Back_Transparent = par_ElementInfo_Base.Back_Transparent
        Me.BadgeLayoutDims = par_ElementInfo_Base.BadgeLayoutDims
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

#Disable Warning CA1707
#Enable Warning CA1707

    ''12/31/2022 Public Shared Sub CheckWidthVsLength_OfPic(intWidth As Integer, intHeight As Integer, boolRotated As Boolean)
    ''    ''
    ''    ''Double-check the orientation.  ----9/23/2019 td
    ''    ''
    ''    Dim boolTextImageRotated_0_180 As Boolean = (intWidth < intHeight) ''Vs. Textual comparison, (intWidth > intHeight)
    ''    Dim boolTextImageRotated_90_270 As Boolean = (intWidth > intHeight) ''Vs. Textual comparison, (intWidth < intHeight)
    ''
    ''    If (boolTextImageRotated_0_180 And boolRotated) Then
    ''        Throw New Exception("Image dimensions are not expected. (Rotation of pic expected)")
    ''    ElseIf (boolTextImageRotated_90_270 And (Not boolRotated)) Then
    ''        Throw New Exception("Image dimensions are not expected.  (Unexpected rotation of pic detected.)")
    ''    End If ''End of "If (boolImageRotated_0_180 and boolRotated) Then .... ElseIf ..."
    ''
    ''End Sub ''ENd of "Public Shared Sub CheckWidthVsLength_OfPic()"

    Public Overloads Function ImageForBadgeImage(par_recipient As IRecipient,
                                                 par_scale As Single) As Image Implements IElement_Base.ImageForBadgeImage

        ''12/31/2022 Return DirectCast(ElementPicture, IElement_Base).ImageForBadgeImage(par_recipient)
        Return DirectCast(ElementPicture, IElement_Base).ImageForBadgeImage(par_recipient, par_scale)

    End Function
End Class


