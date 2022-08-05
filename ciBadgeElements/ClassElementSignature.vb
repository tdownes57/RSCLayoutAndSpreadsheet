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

<Serializable>
Public Class ClassElementSignature
    Inherits ClassElementBase ''Added 1/8/2022 Thomas Downes
    Implements IElement_Base, IElementSig
    ''
    ''Added 10/8/2019 & 7/18/2019 thomas downes
    ''
    ''
    Public Shared ElementSignature As ClassElementSignature ''Added 7/31/2019 thomas d.

    Public Property Id_GUID As System.Guid ''Added 9/30/2019 td 
    Public Property BadgeDisplayIndex As Integer Implements IElement_Base.BadgeDisplayIndex ''Added 11/24/2021 td
    Public Property WhichSideOfCard As EnumWhichSideOfCard Implements IElement_Base.WhichSideOfCard ''Added 12/13/2021 td
    Public Property DateEdited As Date Implements IElement_Base.DateEdited ''Added 12/18/2021 thomas downes  
    Public Property DateSaved As Date Implements IElement_Base.DateSaved ''Added 12/18/2021 thomas downes

    <Xml.Serialization.XmlIgnore>
    Public Property Info As IElementSig

    Public Property PositionalMode As String Implements IElement_Base.PositionalMode ''Added 8/14/2019 td 

    <Xml.Serialization.XmlIgnore>
    Public Property FormControl As Control Implements IElement_Base.FormControl ''Added 7/19/2019  

    Public Property ElementType As String Implements IElement_Base.ElementType ''Text, Sig, or Logo

    ''9/12/2019 td''Public Property LayoutWidth As Integer Implements IElement_Base.LayoutWidth_Pixels ''This provides sizing context & scaling factors. 
    Public Property BadgeLayout As BadgeLayoutClass Implements IElement_Base.BadgeLayout ''This provides sizing context & scaling factors. 

    Public Property TopEdge_Pixels As Integer Implements IElement_Base.TopEdge_Pixels
    Public Property LeftEdge_Pixels As Integer Implements IElement_Base.LeftEdge_Pixels

    ''
    ''Added 5/27/2022 td
    ''
    ''5/28/2022 Public Shadows Property ConditionalExpressionValue As String Implements IElement_Base.ConditionalExpressionValue
    ''5/28/2022 Public Shadows Property ConditionalExpressionField As EnumCIBFields Implements IElement_Base.ConditionalExpressionField
    ''5/28/2022 Public Shadows Property ConditionalExpressionInUse As Boolean Implements IElement_Base.ConditionalExpressionInUse


    Private mod_image As Image ''Added 10/12/2019 td

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
            Dim boolTallerThanWidth As Boolean ''Added 9/23/2019 thomas downes
            Dim boolGiveDisallowedMsg As Boolean ''Added 9/23/2019 thomas downes
            ''9/23 td''boolShorterThanWidth = (mod_height_pixels < mod_width_pixels) ''value)
            boolTallerThanWidth = (mod_height_pixels > value)
            boolGiveDisallowedMsg = boolTallerThanWidth
            If (boolGiveDisallowedMsg) Then
                Throw New Exception("The Height cannot be less than the width #1 (rotation is _not_ an exception to this).")
            End If ''End of "If (boolGiveDisallowedMsg) Then"

            ''Added 9/23/2019 td
            Const c_False_RegardlessOfRotation As Boolean = False
            CheckWidthVsLength_OfSig(mod_width_pixels, mod_height_pixels, c_False_RegardlessOfRotation)

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
            ''10/11/2019 td''Dim boolShorterThanWidth As Boolean ''Added 9/23/2019 thomas downes
            Dim boolGiveDisallowedMsg As Boolean ''Added 9/23/2019 thomas downes
            ''Added 9/23/2019 thomas downes
            ''9/23/2019 td''boolTallerThanWidth = (mod_height_pixels > mod_width_pixels)
            ''10/11/2019 td''boolShorterThanWidth = (mod_height_pixels < mod_width_pixels)

            Dim boolTallerThanWidth As Boolean ''Added 10/11/2019 td
            boolTallerThanWidth = (mod_height_pixels > mod_width_pixels)
            boolGiveDisallowedMsg = boolTallerThanWidth
            If (boolGiveDisallowedMsg) Then
                Throw New Exception("The Height cannot be more than the width #2 (rotation is _not_ an exception to this).")
            End If ''End of "If (boolGiveDisallowedMsg) Then"

            ''Added 9/23/2019 td
            Const c_False_RegardlessOfRotation As Boolean = False
            CheckWidthVsLength_OfSig(mod_width_pixels, mod_height_pixels, c_False_RegardlessOfRotation)

        End Set
    End Property

    ''8/29/2019 td''Public Property Border_Pixels As Integer Implements IElement_Base.Border_Pixels
    Public Property Border_WidthInPixels As Integer Implements IElement_Base.Border_WidthInPixels

    <XmlIgnore>
    Public Property Border_Color As System.Drawing.Color Implements IElement_Base.Border_Color

    <XmlElement("Border_Color")>
    Public Property Border_Color_HTML As String
        ''Added 10/13/2019 td
        Get
            ''  https://stackoverflow.com/questions/376234/best-solution-for-xmlserializer-and-system-drawing-color
            Return ColorTranslator.ToHtml(Me.Border_Color)
        End Get
        Set(value As String)
            ''  https://stackoverflow.com/questions/376234/best-solution-for-xmlserializer-and-system-drawing-color
            Me.Border_Color = ColorTranslator.FromHtml(value)
        End Set
    End Property


    Public Property Border_Displayed As Boolean Implements IElement_Base.Border_Displayed ''Added 9/9/2019 td

    ''Added 9/4/2019 td 
    Public Property Back_Transparent As Boolean Implements IElement_Base.Back_Transparent

    <XmlIgnore>
    Public Property Back_Color As System.Drawing.Color Implements IElement_Base.Back_Color

    <XmlElement("Back_Color")>
    Public Property Back_Color_HTML As String
        ''Added 10/13/2019 td
        Get
            ''  https://stackoverflow.com/questions/376234/best-solution-for-xmlserializer-and-system-drawing-color
            Return ColorTranslator.ToHtml(Me.Back_Color)
        End Get
        Set(value As String)
            ''  https://stackoverflow.com/questions/376234/best-solution-for-xmlserializer-and-system-drawing-color
            Me.Back_Color = ColorTranslator.FromHtml(value)
        End Set
    End Property



    ''Added 8/2/2019 td
    ''
    Public Property SelectedHighlighting As Boolean Implements IElement_Base.SelectedHighlighting

    ''
    ''Added 7/31/2019 thomas downes
    ''
    Public Property SigFileType As String Implements IElementSig.SigFileType
    Public Property SigFilePath As String Implements IElementSig.SigFilePath ''Added 10/12/2019 td
    Public Property SigFileTitleExt As String Implements IElementSig.SigFileTitleExt

    Public Property SigFileIndex As Integer Implements IElementSig.SigFileIndex ''Added 8/16/2019 thomasd downes


    ''9/2 td''Public Property OrientationToLayout As String Implements IElementSig.OrientationToLayout
    ''9/2 td''Public Property OrientationDegrees As Integer Implements IElementSig.OrientationDegrees

    Public Property OrientationToLayout As String Implements IElement_Base.OrientationToLayout
    Public Property OrientationInDegrees As Integer Implements IElement_Base.OrientationInDegrees

    ''Public Property SigFileIndex As Integer Implements IElementSig.SigFileIndex ''Added 8/13/2019 td  
    ''Public Property OrientationDegrees As Integer Implements IElementSig.OrientationDegrees ''Added 8/13/2019 td  

    <Xml.Serialization.XmlIgnore>
    Public Property Image_BL As Image Implements IElement_Base.Image_BL ''Added 9/2/2019 td

    Public Property Visible As Boolean = True Implements IElement_Base.Visible ''Added 9/19/2019 td  

    <Xml.Serialization.XmlIgnore>
    Public Property Recipient As IRecipient Implements IElementSig.Recipient ''Added 9/10/2019 td

    Public Property ZOrder As Integer Implements IElement_Base.ZOrder
    ''    Get
    ''        Return DirectCast(ElementSignature, IElement_Base).ZOrder
    ''    End Get
    ''    Set(value As Integer)
    ''        DirectCast(ElementSignature, IElement_Base).ZOrder = value
    ''    End Set
    ''End Property

    Public Sub New(par_control As Control)

        ''Added 7/19/2019 td
        ''
        Me.FormControl = par_control

    End Sub

    ''Public Sub New(par_infoForSig As IElementSig)
    ''    ''
    ''    ''Added 7/31/2019 td
    ''    ''
    ''    Me.Info = par_infoForSig

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

    Public Function GetImage_Signature(par_bRefreshFromFile As Boolean, ByRef pref_strErrorMessage As String) As Image Implements IElementSig.GetImage_Signature
        ''
        ''Added 10/12/2019 td  
        ''
        Dim boolNoWorkToDo As Boolean
        Dim obj_bitmap As Bitmap = Nothing ''Added 10/12/2019 thomas d.

        boolNoWorkToDo = (mod_image IsNot Nothing And (Not par_bRefreshFromFile))

        If (boolNoWorkToDo) Then Return mod_image

        Try
            obj_bitmap = New Bitmap(Me.SigFilePath)
        Catch ex_Bitmap As Exception
            ''Modified 1/2/2022 td
            ''   --pref_strErrorMessage = ex_Bitmap.Message
            pref_strErrorMessage = "The following signature file path is not valid. " & vbCrLf_Deux &
                    Me.SigFilePath & vbCrLf_Deux &
                    "Function GetImage_Signature, ClassElementSignature" & vbCrLf_Deux &
                    "Project ciBadgeElements. Message: " & ex_Bitmap.Message

        End Try

        Return CType(obj_bitmap, Image)

    End Function ''End of "Public Function GetImage_Signature(par_bRefreshFromFile As Boolean)"

    Public Function Copy() As ClassElementSignature
        ''
        ''Added 10/8 & 9/17/2019 
        ''
        Dim objCopy As New ClassElementSignature
        objCopy.LoadbyCopyingMembers(Me, Me)
        Return objCopy

    End Function ''End of "Public Function Copy() As ClassElementSignature"

    Public Sub LoadbyCopyingMembers(par_ElementInfo_Base As IElement_Base,
                                  par_ElementInfo_Sig As IElementSig)
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
        ''Next, Signature-related information.
        ''
        ''   Public Property SigFileType As String Implements IElementSig.SigFileType
        ''   Public Property SigFileTitleExt As String Implements IElementSig.SigFileTitleExt
        ''
        Me.SigFileIndex = par_ElementInfo_Sig.SigFileIndex
        Me.SigFileTitleExt = par_ElementInfo_Sig.SigFileTitleExt
        Me.SigFileType = par_ElementInfo_Sig.SigFileType

    End Sub ''End of "Public Sub LoadbyCopyingMembers(par_ElementInfo_Base As IElement_Base, .....)"

    Public Shared Sub CheckWidthVsLength_OfSig(intWidth As Integer, intHeight As Integer, boolRotated As Boolean)
        ''
        ''Double-check the orientation.  ----9/23/2019 td
        ''
        ''10/8/2019 td''Dim boolTextImageRotated_0_180 As Boolean = (intWidth < intHeight) ''Vs. Textual comparison, (intWidth > intHeight)
        ''10/8/2019 td''Dim boolTextImageRotated_90_270 As Boolean = (intWidth > intHeight) ''Vs. Textual comparison, (intWidth < intHeight)

        Dim boolTextImageRotated_0_180 As Boolean = (intWidth > intHeight) ''Vs. Textual comparison, (intWidth > intHeight)
        Dim boolTextImageRotated_90_270 As Boolean = (intWidth < intHeight) ''Vs. Textual comparison, (intWidth < intHeight)

        If (boolTextImageRotated_0_180 And boolRotated) Then
            Throw New Exception("Image dimensions are not expected. (Rotation of Sig expected)")
        ElseIf (boolTextImageRotated_90_270 And (Not boolRotated)) Then
            Throw New Exception("Image dimensions are not expected.  (Unexpected rotation of Sig detected.)")
        End If ''End of "If (boolImageRotated_0_180 and boolRotated) Then .... ElseIf ..."

    End Sub ''ENd of "Public Shared Sub CheckWidthVsLength_OfSig()"

    Public Function ImageForBadgeImage(par_recipient As IRecipient) As Image Implements IElement_Base.ImageForBadgeImage
        Return DirectCast(ElementSignature, IElement_Base).ImageForBadgeImage(par_recipient)
    End Function
End Class



