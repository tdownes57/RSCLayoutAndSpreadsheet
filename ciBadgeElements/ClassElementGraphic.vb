﻿''---Public Class ClassElementGraphic

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
Public Class ClassElementGraphic
    Inherits ClassElementBase ''Added 1/8/2022 Thomas Downes
    ''
    ''Added 12/08/2021 thomas downes 
    ''
    ''This is closely modelled after ClassElementQRCode. ---12/08/2021 td
    ''
    ''Dec.8, 2021 td''Implements IElement_Base, IElementQRCode
    Implements IElement_Base, IElementGraphic
    ''
    ''Added 9/30/2019 thomas downes
    ''
    ''What is this for? ---12/8/2021 thomas downes
    ''9/5/2022 Public Shared ElementQRCode As ClassElementQRCode ''Added 9/30/2019 thomas d.

    <Xml.Serialization.XmlIgnore>
    Public Property Info As IElementGraphic ''Dec8 2021 ''IElementQRCode

    ''Public Property BadgeDisplayIndex As Integer Implements IElement_Base.BadgeDisplayIndex ''Added 11/24/2021 td
    ''Public Property WhichSideOfCard As EnumWhichSideOfCard Implements IElement_Base.WhichSideOfCard ''Added 12/13/2021 td
    ''Public Property DateEdited As Date Implements IElement_Base.DateEdited ''Added 12/18/2021 thomas downes  
    ''Public Property DateSaved As Date Implements IElement_Base.DateSaved ''Added 12/18/2021 thomas downes

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
    ''5/28/2022 Public Shadows Property ConditionalExpressionValue As String Implements IElement_Base.ConditionalExpressionValue
    ''5/28/2022 Public Shadows Property ConditionalExpressionField As EnumCIBFields Implements IElement_Base.ConditionalExpressionField
    ''5/28/2022 Public Shadows Property ConditionalExpressionInUse As Boolean Implements IElement_Base.ConditionalExpressionInUse


    ''
    ''If applicable, inform software developer of programming which violates design expectations.
    ''
    ''Set the Boolean constant to False.  That's because, for general graphics, we do //NOT// have
    ''   portrait-vs-landscape expectations. ---1/8/2022 td
    ''
    Private Const mc_bPortraitVsLandscapeExpectations As Boolean = False ''Added 1/8/2022 td


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
    ''        ''If applicable, inform software developer of programming which violates design expectations.
    ''        ''
    ''        ''Set the Boolean constant to False.  That's because, for general graphics, we do //NOT// have
    ''        ''   portrait-vs-landscape expectations. ---1/8/2022 td
    ''        ''
    ''        ''Modularized Jan8 2022''Const c_bPortraitVsLandscapeExpectations As Boolean = False ''Added 1/8/2022 td

    ''        If (mc_bPortraitVsLandscapeExpectations) Then ''Added 1/8/2022 td

    ''            Dim boolShorterThanWidth As Boolean ''Added 9/23/2019 thomas downes
    ''            Dim boolGiveDisallowedMsg As Boolean ''Added 9/23/2019 thomas downes
    ''            ''9/23 td''boolShorterThanWidth = (mod_height_pixels < mod_width_pixels) ''value)
    ''            boolShorterThanWidth = (mod_height_pixels < value)
    ''            boolGiveDisallowedMsg = boolShorterThanWidth
    ''            If (boolGiveDisallowedMsg) Then
    ''                Throw New Exception("The Height cannot be less than the width #1 (rotation is _not_ an exception to this).")
    ''            End If ''End of "If (boolGiveDisallowedMsg) Then"

    ''            ''Added 9/23/2019 td
    ''            Const c_False_RegardlessOfRotation As Boolean = False
    ''            CheckWidthVsLength_OfPic(mod_width_pixels, mod_height_pixels, c_False_RegardlessOfRotation)

    ''        End If ''End of "If (mc_bPortraitVsLandscapeExpectations) Then"

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
    ''        ''If applicable, inform software developer of programming which violates design expectations.
    ''        ''
    ''        ''Set the Boolean constant to False.  That's because, for general graphics, we do //NOT// have
    ''        ''   portrait-vs-landscape expectations. ---1/8/2022 td
    ''        ''
    ''        ''Modularized Jan8 2022''Const c_bPortraitVsLandscapeExpectations As Boolean = False ''Added 1/8/2022 td

    ''        If (mc_bPortraitVsLandscapeExpectations) Then ''Added 1/8/2022 td

    ''            Dim boolShorterThanWidth As Boolean ''Added 9/23/2019 thomas downes
    ''            Dim boolGiveDisallowedMsg As Boolean ''Added 9/23/2019 thomas downes
    ''            ''Added 9/23/2019 thomas downes
    ''            ''9/23/2019 td''boolTallerThanWidth = (mod_height_pixels > mod_width_pixels)
    ''            boolShorterThanWidth = (mod_height_pixels < mod_width_pixels)
    ''            boolGiveDisallowedMsg = boolShorterThanWidth
    ''            If (boolGiveDisallowedMsg) Then
    ''                Throw New Exception("The Height cannot be less than the width #2 (rotation is _not_ an exception to this).")
    ''            End If ''End of "If (boolGiveDisallowedMsg) Then"

    ''            ''Added 9/23/2019 td
    ''            Const c_False_RegardlessOfRotation As Boolean = False
    ''            CheckWidthVsLength_OfPic(mod_width_pixels, mod_height_pixels, c_False_RegardlessOfRotation)

    ''        End If ''End of "If (mc_bPortraitVsLandscapeExpectations) Then"

    ''    End Set
    ''End Property

    ''''8/29/2019 td''Public Property Border_Pixels As Integer Implements IElement_Base.Border_Pixels
    ''12/2022 Public Property Border_WidthInPixels As Integer Implements IElement_Base.Border_WidthInPixels

    ''<XmlIgnore>
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

    ''Added 9/4/2019 td 
    ''12/2022 Public Property Back_Transparent As Boolean Implements IElement_Base.Back_Transparent

    ''12/2022 <XmlIgnore>
    ''12/2022 Public Property Back_Color As System.Drawing.Color Implements IElement_Base.Back_Color

    ''''12/2022 <XmlElement("Back_Color")>
    ''''12/2022 Public Property Back_Color_HTML As String
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
    ''9/2022 Public Property SelectedHighlighting As Boolean Implements IElement_Base.SelectedHighlighting


    ''9/2022 Public Property OrientationToLayout As String Implements IElement_Base.OrientationToLayout
    ''9/2022 Public Property OrientationInDegrees As Integer Implements IElement_Base.OrientationInDegrees

    ''
    ''What does BL stand for?  ----12/8/2021 
    ''Does BL stand for Badge Layout? 
    ''
    ''9/2022 <Xml.Serialization.XmlIgnore>
    ''9/2022 Public Property Image_BL As Image Implements IElement_Base.Image_BL ''Added 9/2/2019 td

    ''9/2022 Public Property Visible As Boolean = True Implements IElement_Base.Visible ''Added 9/19/2019 td  

    ''Dec.8 2021''Public Property QRFormula As String Implements IElementQRCode.QRFormula ''Added 9/30/2019 td
    ''
    <Xml.Serialization.XmlIgnore>
    Public Property GraphicImage As Image Implements IElementGraphic.GraphicImage ''Added 12/8/2021 td
    Public Property GraphicImageName As String Implements IElementGraphic.GraphicImageName ''Added 12/8/2021 td
    Public Property GraphicImageFullPath As String Implements IElementGraphic.GraphicImageFullPath ''Added 1/22/2022 td
    Public Property BackgroundIsTransparent As Boolean Implements IElementGraphic.BackgroundIsTransparent ''Added 12/8/2021 td

    ''''9/2022 Public Property ZOrder As Integer Implements IElement_Base.ZOrder
    ''    Get
    ''        Return 0 ''--Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As Integer)
    ''        ''Throw New NotImplementedException()
    ''    End Set
    ''End Property

#Disable Warning CA1707 ''Underscores?  12/2022

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

    Public Sub New(par_rectangleOfElement As Rectangle,
                   par_badeLayoutDims As BadgeLayoutDimensionsClass,
                   par_strPathToGraphicsFile As String)
        ''
        ''Added 9/16/2019 td
        ''Revised 5/14/2022 td
        ''
        ''5/14/2022 Me.BadgeLayout = New BadgeLayoutClass(par_layout)
        Me.BadgeLayoutDims = par_badeLayoutDims ''5/14/2022  New BadgeLayoutClass(par_layout)

        ''Added 9/16/2019 td
        Me.LeftEdge_Pixels = par_rectangleOfElement.Left
        Me.TopEdge_Pixels = par_rectangleOfElement.Top

        ''Added 9/16/2019 td
        Me.Width_Pixels = par_rectangleOfElement.Width
        Me.Height_Pixels = par_rectangleOfElement.Height

        ''Added 1/22/2022 thomas d.
        If (IO.File.Exists(par_strPathToGraphicsFile)) Then
            Dim objFileInfo = New IO.FileInfo(par_strPathToGraphicsFile)
            Me.GraphicImageName = objFileInfo.Name
            Me.GraphicImageFullPath = par_strPathToGraphicsFile

            ''Added 1/24/2022 thomas downes
            Me.GraphicImage = New Bitmap(par_strPathToGraphicsFile)

        End If ''End of "If (IO.File.Exists(par_strPathToGraphicsFile)) Then"

    End Sub ''ENd of ""Public Sub New(par_rectangle As Rectangle, par_layout As PictureBox)""


    Public Function Copy() As ClassElementGraphic ''Dec8 2021'' ClassElementQRCode
        ''
        ''Added 9/30/2019 
        ''
        ''Dec.8 2021 td''Dim objCopy As New ClassElementQRCode
        Dim objCopy As New ClassElementGraphic

        objCopy.LoadbyCopyingMembers(Me, Me)
        Return objCopy

    End Function ''End of "Public Function Copy() As ClassElementQRCode"

    Public Sub LoadbyCopyingMembers(par_ElementInfo_Base As IElement_Base,
                                  par_ElementInfo_Graphic As IElementGraphic) ''Dec.8 2021''As IElementQRCode)
        ''
        ''Added 9/30/2019 thomas downes
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
        ''Next, QR Code-related information.
        '' 
        ''Dec.8 2021''Me.QRFormula = par_ElementInfo_QR.QRFormula

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


    Public Sub LoadGraphic() Implements IElementGraphic.LoadGraphicImage
        ''
        ''Stubbed 12/8/2021 thomas downes 
        ''
        ''This procedure should provide a substantive value for the current
        ''  class's implementation of property IElementGraphic.GraphicImage. 
        ''
        ''Throw New NotImplementedException("Not coded yet")
        '9/1/2022 Throw New NotImplementedException()
        System.Diagnostics.Debugger.Break()

    End Sub ''End of "Public Sub LoadGraphic() "

    Public Overloads Function ImageForBadgeImage(par_recipient As IRecipient, par_scale As Single) As Image _
        ''3/16/2023 td  Implements IElement_Base.ImageForBadgeImage
        ''Throw New NotImplementedException()

        '9/1/2022 Throw New NotImplementedException()
        System.Diagnostics.Debugger.Break()
        Return New Bitmap(MyBase.Width_Pixels, MyBase.Height_Pixels)

    End Function

End Class


