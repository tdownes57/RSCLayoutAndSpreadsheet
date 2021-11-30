Option Explicit On
Option Strict On
Option Infer Off

''Added 7/18/2019 thomas downes
Imports System.Drawing ''Added 9/18/2019 td  
Imports System.Drawing.Text ''Added 
Imports System.Windows.Forms ''Added 9/18/2019 td 
Imports ciBadgeInterfaces ''Added 8/14/2019 thomas d. 8/14/2019 td  
Imports ciBadgeFields ''Added 9/18/2019 td  
Imports System.Xml.Serialization ''Added 9/24/2019 thomas d. 
Imports ciBadgeRecipients ''Added 10/16/2019 thomas d. 
''Imports ciBadgeInterfaces ''Added 11/16/2019 thomas d. 
Imports AutoMapper ''Added 11/17/2021 thomas d. 

Public Event ElementField_RightClicked(par_elementField As ClassElementField) ''Added 10/1/2019 td

Public Structure WhyOmitted ''Added 11/10/2021 thomas downes
    Dim NotRelevantField As Boolean ''Added 11/24/2021
    Dim OmitElement As Boolean
    Dim OmitField As Boolean
    Dim OmitCoordinateX As Boolean
    Dim OmitCoordinateY As Boolean
    Dim OmitWidth As Boolean
    Dim OmitHeight As Boolean
    ''Dim increment1 = Function(x As Integer) x + 1
    ''==Const OmitElement_Msg As String = " (Element Property not flagged as True)"
    ''==Const OmitField_Msg As String = " (Field Property not flagged as True)"
    Public Function NotRelevantMsg() As String
        ''Added 11/24/2021 
        If (NotRelevantField) Then Return " (Field not relevant to Personality)"
        Return ""
    End Function
    Public Function OmitElementMsg() As String
        If (OmitElement) Then Return " (Element Property not flagged as True)"
        Return ""
    End Function
    Public Function OmitFieldMsg() As String
        If (OmitField) Then Return " (Field Property not flagged as True)"
        Return ""
    End Function

End Structure

<Serializable>
Public Class ClassElementField
    Implements IElement_Base, IElement_TextOnly, IElement_TextField
    ''
    ''Added 7/18/2019 thomas downes
    ''
    ''
    ''7/29/2019 td''Public Property Info As IElementText
    ''
    ''-------------------------------------------------------------
    ''//
    ''// Auto-Mappers  
    ''//   https://stackoverflow.com/questions/16534253/c-sharp-converting-base-class-to-child-class
    ''//   https://dotnettutorials.net/lesson/automapper-in-c-sharp/
    ''//   https://docs.automapper.org/en/latest/Setup.html
    ''//
    ''
    <Xml.Serialization.XmlIgnore>
    Private Shared _mapConfig_Pic As MapperConfiguration = New MapperConfiguration(Sub(cfg) cfg.CreateMap(Of IElementPic, ClassElementField)())
    <Xml.Serialization.XmlIgnore>
    Private Shared _mapConfig_TextField As MapperConfiguration = New MapperConfiguration(Sub(cfg) cfg.CreateMap(Of IElement_TextField, ClassElementField)())
    <Xml.Serialization.XmlIgnore>
    Private Shared _mapConfig_TextOnly As MapperConfiguration = New MapperConfiguration(Sub(cfg) cfg.CreateMap(Of IElement_TextOnly, ClassElementField)())
    <Xml.Serialization.XmlIgnore>
    Private Shared _mapConfig_Base As MapperConfiguration = New MapperConfiguration(Sub(cfg) cfg.CreateMap(Of IElement_Base, ClassElementField)())

    <Xml.Serialization.XmlIgnore>
    Public Shared Property oRecipient As ClassRecipient ''Added 10/16/2019 td  
    ''11/16/2019 td''Public Shared Property Recipient As ClassRecipient ''Added 10/16/2019 td  

    Private Shared mod_sharedRecipInfo As IRecipient ''Added 12/01/2019 thomas d.
    ''---4/22/2020 td---Private Shared ms_lastFieldIndex As Integer ''Added 4/22/2020 thomas downes

    <Xml.Serialization.XmlIgnore>
    Public Shared Property iRecipientInfo As IRecipient ''Added 10/16/2019 td  
        Get
            Return mod_sharedRecipInfo ''Added 12/01/2019 thomas d.  
        End Get
        Set(value As IRecipient)
            ''Added 12/01/2019 td
            ''1-15-2020 td''mod_sharedRecipInfo = mod_sharedRecipInfo
            mod_sharedRecipInfo = value ''1-15-2020 td'' mod_sharedRecipInfo

            ''----DIFFICULT AND CONFUSING------
            oRecipient = Nothing ''Don't allow an object older reference to interfere with determining Recipient-related data. 12/01/2019 td
        End Set
    End Property

    Public Shared Function GetMapperConfiguration_Pic() As AutoMapper.MapperConfiguration
        ''
        '' Added 11/17/2021 thomas downes
        ''
        ''//
        ''//   https://stackoverflow.com/questions/16534253/c-sharp-converting-base-class-to-child-class
        ''//   https://dotnettutorials.net/lesson/automapper-in-c-sharp/
        ''//   https://docs.automapper.org/en/latest/Setup.html
        ''//
        ''
        ''//Initialize the mapper
        ''[[Dim config As MapperConfiguration

        ''config = New MapperConfiguration(cfg => cfg.CreateMap(IElement_Base, IElementPic))
        ''config = New MapperConfiguration(Sub(cfg) cfg.CreateMap(IElementPic, IElement_Base))
        ''config = New MapperConfiguration()

        ''[[Dim actionX As Action(Of IMapperConfigurationExpression) = Sub(cfg) cfg.CreateMap(IElementPic, IElement_Base)
        ''[[Dim actionX As Action(Of IMapperConfigurationExpression) = Sub(cfg) cfg.CreateMap(Of ClassElementPic, ClassElementField)()
        ''___Dim config As MapperConfiguration
        ''___config = New MapperConfiguration(Sub(cfg) cfg.CreateMap(Of IElementPic, IElement_Base)())

        Return _mapConfig_Pic

    End Function ''End of ""

    Public Property Id_GUID As System.Guid  ''Added 9/30/2019 td 

    Public Property BadgeDisplayIndex As Integer Implements IElement_Base.BadgeDisplayIndex ''Added 11/24/2021 td 

    <Xml.Serialization.XmlIgnore>
    Public Property Font_DrawingClass As System.Drawing.Font Implements IElement_TextOnly.Font_DrawingClass

    Public Property ExampleValue_ForElement As String Implements IElement_TextField.ExampleValue_ForElement ''Added 8/14/2019 td 

    <XmlIgnore>
    Public Property FontColor As System.Drawing.Color Implements IElement_TextOnly.FontColor

    <XmlElement("FontColor")>
    Public Property FontColor_HTML As String
        ''Added 10/14/2019 td
        Get
            ''  https://stackoverflow.com/questions/376234/best-solution-for-xmlserializer-and-system-drawing-color
            Return ColorTranslator.ToHtml(Me.FontColor)
        End Get
        Set(value As String)
            ''  https://stackoverflow.com/questions/376234/best-solution-for-xmlserializer-and-system-drawing-color
            Me.FontColor = ColorTranslator.FromHtml(value)
        End Set
    End Property

    ''Added 8/12/2019 thomas downes  
    Public Property FontSize_Pixels As Single = 25 Implements IElement_TextOnly.FontSize_Pixels ''Added 8/12/2019 thomas downes  
    Public Property FontBold As Boolean Implements IElement_TextOnly.FontBold ''Added 8/12/2019 thomas downes  
    Public Property FontItalics As Boolean Implements IElement_TextOnly.FontItalics ''Added 8/12/2019 thomas downes  
    Public Property FontUnderline As Boolean Implements IElement_TextOnly.FontUnderline ''Added 8/12/2019 thomas downes  
    ''Added 9/6/2019 thomas downes  
    Public Property FontFamilyName As String = "Times New Roman" Implements IElement_TextOnly.FontFamilyName ''Added 9/6/2019 thomas downes  


    ''Added 8/15/2019 thomas downes  
    ''9/12/2019 td''Public Property FontSize_IsLocked As Boolean Implements IElement_Text.FontSize_IsLocked ''Added 8/15/2019 thomas downes  
    Public Property FontSize_ScaleToElementRatio As Double Implements IElement_TextOnly.FontSize_ScaleToElementRatio ''Added 9/12/2019 thomas downes  
    Public Property FontSize_ScaleToElementYesNo As Boolean = True Implements IElement_TextOnly.FontSize_ScaleToElementYesNo ''Added 9/12/2019 thomas downes  


    Public Property FontOffset_X As Integer Implements IElement_TextOnly.FontOffset_X ''Added 8/15/2019 thomas downes  
    Public Property FontOffset_Y As Integer Implements IElement_TextOnly.FontOffset_Y ''Added 8/15/2019 thomas downes  


    ''See Interface IElement_Base. ---8/29/2019 td''Public Property BackColor As System.Drawing.Color Implements IElement_Text.BackColor

    ''This is stored in FieldInfo.--9/18/2019 td''Public Property FieldInCardData As String Implements IElement_TextOnly.FieldInCardData

    ''This is stored in FieldInfo.--9/18/2019 td''Public Property FieldLabelCaption As String Implements IElement_TextOnly.FieldLabelCaption

    ''7/25/2019 td''Prpoerty ExampleText As String ''Added 7/25/2019

    ''
    ''See also, "Public Function LabelText(par_isForLayoutPreview As Boolean) As String".  ---10/16/2019 td 
    ''
    Public Property Text_Static As String Implements IElement_TextOnly.Text_Static ''E.g. "George Washington" for FullName. 
    Public Property Text_Formula As String Implements IElement_TextOnly.Text_Formula ''E.g. "{fstrFirstName} {fstrLastName}" for FullName. 

    ''--16----Replaced by a Shared Property of the same name.---10/16/2019 td
    ''--16--10/16/2019 td''Added 9/10/2019 td     <Xml.Serialization.XmlIgnore>
    ''--16--10/16/2019 td''<Xml.Serialization.XmlIgnore>
    ''--16--10/16/2019 td''Public Property Recipient As IRecipient Implements IElement_TextField.Recipient

    ''Added 9/18/2019
    Public Property FieldObject As ClassFieldAny ''Added 9/18/2019 td

    ''Added 10/12/2019 thomas downes
    Public Property FieldEnum As EnumCIBFields Implements IElement_TextField.FieldEnum

    ''Added 9/17/2019 td 
    <Xml.Serialization.XmlIgnore>
    Public Property FieldInfo As ICIBFieldStandardOrCustom Implements IElement_TextField.FieldInfo

    Public Property TextAlignment As System.Windows.Forms.HorizontalAlignment Implements IElement_TextOnly.TextAlignment


    ''-------------------------------------------------------------
    ''-------------------------------------------------------------
    ''-------------------------------------------------------------

    Public Property PositionalMode As String Implements IElement_Base.PositionalMode ''Added 8/14/2019 td 

    Public Property OrientationToLayout As String Implements IElement_Base.OrientationToLayout ''E.g. "L" (Landscape) (by far the most common) or "P" for Portrait  

    Public Property OrientationInDegrees As Integer Implements IElement_Base.OrientationInDegrees ''Default is 0, normal.  90 would be 1/4 turn clockwise.  180 is upside-down.  270 is the printing on the spine of a book sitting on the bookshelf.

    <Xml.Serialization.XmlIgnore>
    Public Property Image_BL As Image Implements IElement_Base.Image_BL ''Added 8/27/2019 td

    ''Moved below. 8/27/2019 td''Public Property SelectedHighlighting As Boolean Implements IElement_Base.SelectedHighlighting ''Added 8/2/2019 td  


    ''-------------------------------------------------------------
    ''-------------------------------------------------------------
    ''-------------------------------------------------------------

    <Xml.Serialization.XmlIgnore>
    Public Property FormControl As Control Implements IElement_Base.FormControl ''Added 7/19/2019  

    Public Property ElementType As String = "Text" Implements IElement_Base.ElementType ''Text, Pic, or Logo

    ''9/11/2019 td''Public Property LayoutWidth_Pixels As Integer Implements IElement_Base.LayoutWidth_Pixels ''This provides sizing context & scaling factors. 
    Public Property BadgeLayout As BadgeLayoutClass Implements IElement_Base.BadgeLayout ''Added 9/11/2019 td  

    Public Property TopEdge_Pixels As Integer = 0 Implements IElement_Base.TopEdge_Pixels
    Public Property LeftEdge_Pixels As Integer = 0 Implements IElement_Base.LeftEdge_Pixels


    ''9/23/20198 td''Public Property Width_Pixels As Integer = 253 Implements IElement_Base.Width_Pixels
    ''9/23/20198 td''Public Property Height_Pixels As Integer = 33 Implements IElement_Base.Height_Pixels


    Private mod_width_pixels As Integer = 253 ''Added 9/23/2019 td 
    Public Property Width_Pixels As Integer Implements IElement_Base.Width_Pixels
        Get
            Return mod_width_pixels
        End Get
        Set(value As Integer)

            mod_width_pixels = value

            ''
            ''Are we initializing Height & Width?   
            ''
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

            ''Added 9/23/2019 thomas downes
            boolTallerThanWidth = (mod_height_pixels > mod_width_pixels)
            boolGiveDisallowedMsg = boolTallerThanWidth
            If (boolGiveDisallowedMsg) Then
                Throw New Exception("The Height cannot exceed the width #1 (rotation is _not_ an exception to this).")
            End If ''End of "If (boolGiveDisallowedMsg) Then"

            ''Added 9/23/2019 td
            Const c_False_RegardlessOfRotation As Boolean = False
            CheckWidthVsLength_OfText(mod_width_pixels, mod_height_pixels, c_False_RegardlessOfRotation)

        End Set
    End Property


    Private mod_height_pixels As Integer = 33 ''Added 9/23/2019 td 
    Public Property Height_Pixels As Integer Implements IElement_Base.Height_Pixels
        Get
            Return mod_height_pixels
        End Get
        Set(value As Integer)

            mod_height_pixels = value

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
            Dim boolTallerThanWidth As Boolean ''Added 9/23/2019 thomas downes
            Dim boolGiveDisallowedMsg As Boolean ''Added 9/23/2019 thomas downes
            ''Added 9/23/2019 thomas downes
            boolTallerThanWidth = (mod_height_pixels > mod_width_pixels)
            boolGiveDisallowedMsg = boolTallerThanWidth
            If (boolGiveDisallowedMsg) Then
                Throw New Exception("The Height cannot exceed the width #2 (rotation is _not_ an exception to this).")
            End If ''End of "If (boolGiveDisallowedMsg) Then"

            ''Added 9/23/2019 td
            Const c_False_RegardlessOfRotation As Boolean = False
            CheckWidthVsLength_OfText(mod_width_pixels, mod_height_pixels, c_False_RegardlessOfRotation)

        End Set
    End Property


    ''8/29/2019 td''Public Property Border_Pixels As Integer Implements IElement_Base.Border_Pixels
    Public Property Border_WidthInPixels As Integer = 1 Implements IElement_Base.Border_WidthInPixels

    <XmlIgnore>
    Public Property Border_Color As System.Drawing.Color = Color.Black Implements IElement_Base.Border_Color
    Public Property Border_Displayed As Boolean = True Implements IElement_Base.Border_Displayed ''Added 9/9/2019 td 

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

    <XmlIgnore>
    Public Property Back_Color As System.Drawing.Color = Color.White Implements IElement_Base.Back_Color
    Public Property Back_Transparent As Boolean = False Implements IElement_Base.Back_Transparent ''Added 9/4/2019 thomas d. 

    ''  https://stackoverflow.com/questions/376234/best-solution-for-xmlserializer-and-system-drawing-color
    ''    [XmlElement("ClrGrid")]
    ''Public String ClrGridHtml
    ''{
    ''    Get { Return ColorTranslator.ToHtml(clrGrid); }
    ''    Set { ClrGrid = ColorTranslator.FromHtml(value); }
    ''}

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

    Public Property SelectedHighlighting As Boolean Implements IElement_Base.SelectedHighlighting ''Added 8/2/2019 td  

    Public Property Visible As Boolean = True Implements IElement_Base.Visible ''Added 9/19/2019 td  

    Public Property DatetimeUpdated As DateTime = DateTime.MinValue ''Added 11/29/2021 thomas downes

    ''9/18/2019 td''Private _labelToImage As New ClassLabelToImage ''Added 9/3/2019 td  
    ''Moved up. 9/30/2019 td''Public Property Id_GUID As System.Guid ''Added 9/30/2019 td 

    Public Sub New(par_control As Control)

        ''Added 7/19/2019 td
        ''
        Me.FormControl = par_control

    End Sub


    Public Sub New(par_fieldInfo As ICIBFieldStandardOrCustom,
                   par_intLeft_Pixels As Integer, par_intTop_Pixels As Integer, par_intHeight_Pixels As Integer)
        ''9/17 td''Public Sub New(par_intLeft_Pixels As Integer, par_intTop_Pixels As Integer, par_intHeight_Pixels As Integer)
        ''
        ''Added 9/15/2019 td
        ''
        Me.FieldInfo = par_fieldInfo ''Added 9/17/2019 td 
        Me.FieldEnum = par_fieldInfo.FieldEnumValue ''Added 10/12/2019 thomas d. 

        Me.BadgeLayout = New ciBadgeInterfaces.BadgeLayoutClass ''Added 9/12/2019

        Me.LeftEdge_Pixels = par_intLeft_Pixels
        Me.TopEdge_Pixels = par_intTop_Pixels
        Me.Height_Pixels = par_intHeight_Pixels

        ''---''Added 4/22/2020 thomas downes
        ''---Me.FieldIndex`

    End Sub

    Public Sub New()
        ''
        ''Added 7/29/2019 td
        ''
        Me.BadgeLayout = New ciBadgeInterfaces.BadgeLayoutClass ''Added 9/12/2019

    End Sub


    Public Function ElementIndexIsFieldIndex() As Integer
        ''//
        ''// Added 11/18/2021 td 
        ''//
        Return FieldInfo.FieldIndex

    End Function ''End of Public Function ElementIndexIsFieldIndex 



    Public Function FieldNm_CaptionText() As String
        ''//Added 11/10/2021 thomas downes
        Return (FieldInfo.CIBadgeField & "/" & FieldInfo.DataEntryText)
    End Function

    Public Function IsDisplayedOnBadge_Visibly(ByRef par_whyOmit As WhyOmitted) As Boolean
        ''----Public Function IsDisplayedOnBadge_Visibly() As Boolean
        ''
        ''Added 9/19/2019 td  
        ''
        par_whyOmit.NotRelevantField = (Not Me.FieldInfo.IsRelevantToPersonality) ''Added 11/24/2021 
        par_whyOmit.OmitElement = (Not Me.Visible) ''Added 11/10/2021 td  
        par_whyOmit.OmitField = (Not Me.FieldInfo.IsDisplayedOnBadge) ''Added 11/10/20121 td  

        Return (Me.FieldInfo.IsDisplayedOnBadge And Me.Visible)

    End Function ''End of "Public Function IsDisplayedOnBadge_Visibly() As Boolean"

    ''8/26 td''Public Function GenerateImage(pintLayoutHeight As Integer) As Image Implements IElementText.GenerateImage
    ''    ''
    ''    ''Added 8/14/2019 thomas downes 
    ''    ''
    ''    Dim obj_image As Image = Nothing
    ''
    ''    ''8/15/2019 td''GenerateImage(obj_image, Me, Me)
    ''    GenerateImage(pintLayoutHeight, obj_image, Me, Me)
    ''
    ''    Return obj_image
    ''
    ''End of 8/26 td''End Function ''End of "Public Function GenerateImage() As Image Implements IElementText.GenerateImage"

    Public Function GenerateImage_ByDesiredLayoutWidth_Deprecated(pintDesiredLayoutWidth As Integer) As Image _
        Implements IElement_TextOnly.GenerateImage_ByDesiredLayoutWidth
        ''
        ''    8/26 td''Public Function GenerateImage(pintLayoutHeight As Integer) As Image Implements IElementText.GenerateImage
        ''
        ''Added 8/14/2019 thomas downes 
        ''
        Dim obj_image As Image = Nothing

        ''8/15/2019 td''GenerateImage(obj_image, Me, Me)
        ''8/26/2019 td''GenerateImage(pintLayoutHeight, obj_image, Me, Me)

        ''9/3/2019 td''GenerateImage(pintDesiredLayoutWidth, obj_image, Me, Me)
        ''9/4/2019 td''_labelToImage.TextImage(pintDesiredLayoutWidth, obj_image, Me, Me, False)

        Try
            ''
            ''Major call !!
            ''
            ''9/16/2019 td''obj_image = _labelToImage.TextImage(pintDesiredLayoutWidth, Me, Me, False, False)
            ''Deprecated.  9/18/2019 td''obj_image = _labelToImage.TextImage_Field(pintDesiredLayoutWidth, Me, Me, False, False)

        Catch ex As Exception
            ''Added 9/15/2019 td  
            MessageBox.Show(ex.Message, "90022", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        Return obj_image

    End Function ''End of "Public Function GenerateImage_ByDesiredLayoutWidth_Deprecated() As Image Implements IElementText.GenerateImage_ByDesiredLayoutWidth"

    Public Function GenerateImage_ByDesiredLayoutHeight_Deprecated(pintDesiredLayoutHeight As Integer) As Image _
        Implements IElement_TextOnly.GenerateImage_ByDesiredLayoutHeight
        ''
        ''Added 8/26/2019 thomas downes 
        ''
        ''   This assumes the Badge is currently being displayed in Landscape mode, like so: 
        ''
        ''    ----------------------------
        ''    |                          |
        ''    |                          |
        ''    |                          |
        ''    |                          |
        ''    |                          |
        ''    ----------------------------   
        ''
        ''
        Dim obj_image As Image = Nothing
        Dim intDesiredLayoutWidth As Integer
        Dim doubleCorrectRatioW_to_H As Double = 0 ''Added 9/4/2019 td

        ''Added 9/4/2019 td
        ''9/18/2019 td''doubleCorrectRatioW_to_H = ciLayoutPrintLib.LayoutPrint.LongSideToShortRatio()

        ''9/4 td''intDesiredLayoutWidth = CInt(pintDesiredLayoutHeight * ciLayoutPrintLib.LayoutPrint.LongSideToShortRatio())

        intDesiredLayoutWidth = CInt(pintDesiredLayoutHeight * doubleCorrectRatioW_to_H)

        ''9/3/2019 td''GenerateImage(intDesiredLayoutWidth, obj_image, Me, Me)
        ''9/4/2019 td''_labelToImage.TextImage(intDesiredLayoutWidth, obj_image, Me, Me, False)

        ''9/16/2019 td''obj_image = _labelToImage.TextImage(intDesiredLayoutWidth, Me, Me, False, False)
        ''Deprecated. 9/18/2019td''obj_image = _labelToImage.TextImage_Field(intDesiredLayoutWidth, Me, Me, False, False)

        Return obj_image

    End Function ''End of "Public Function GenerateImage_ByDesiredLayoutHeight_Deprecated() As Image Implements IElementText.GenerateImage_ByDesiredLayoutWidth"

    Public Function GenerateImage_NotInUse(pintDesiredLayoutWidth As Integer, ByRef par_image As Image,
                                  par_elementInfo_Text As IElement_TextOnly, par_elementInfo_Base As IElement_Base) As Image
        ''
        ''Added 8/14 & 7/17/2019 thomas downes
        ''
        ''Retired in favor of ClassLabelToImage.TextImage(), on 9/3/2019 td  
        ''
        Dim gr As Graphics ''= Graphics.FromImage(img)
        Dim pen_backcolor As Pen
        Dim pen_highlighting As Pen ''Added 8/2/2019 thomas downes  
        Dim pen_border As Pen ''Added 9/3/2019 thomas downes  
        Dim brush_forecolor As Brush
        Dim brush_backcolor As Brush ''Added 8/28/2019 td
        Dim doubleW_div_H As Double ''Added 8/15/2019 td  
        Dim doubleScaling As Double ''Added 8/15/2019 td  
        Dim intNewElementWidth As Integer ''Added 8/15 
        Dim intNewElementHeight As Integer ''Added 8/15

        Application.DoEvents()

        ''Added 8/15/2019 td
        doubleW_div_H = (par_elementInfo_Base.Width_Pixels / par_elementInfo_Base.Height_Pixels)
        ''8/24 td''doubleScaling = (pintFinalLayoutWidth / par_element.LayoutWidth_Pixels)
        doubleScaling = (pintDesiredLayoutWidth / par_elementInfo_Base.Width_Pixels)

        If (par_image Is Nothing) Then
            ''Create the image from scratch, if needed. 
            ''7/29 td''par_image = New Bitmap(par_element.Width_Pixels, par_element.Height_Pixels)

            ''Added 8/15/2019 td
            intNewElementWidth = CInt(doubleScaling * par_elementInfo_Base.Width_Pixels)
            intNewElementHeight = CInt(doubleScaling * par_elementInfo_Base.Height_Pixels)

            ''Added 8/15/2019 td
            ''
            If (False) Then ''9/18/2019 td''If (ClassLabelToImage.UseHighResolutionTips) Then

                ''9/6/2019 td''par_image = New Bitmap(intNewElementWidth, intNewElementHeight)
                par_image = New Bitmap(intNewElementWidth, intNewElementHeight, Imaging.PixelFormat.Format32bppPArgb)

            Else
                par_image = New Bitmap(intNewElementWidth, intNewElementHeight)

            End If ''end of "If (ClassLabelToImage.UseHighResolutionTips) Then ... Else"

        End If ''End of "If (par_image Is Nothing) Then"

        gr = Graphics.FromImage(par_image)

        ''8/29/2019 td''pen_backcolor = New Pen(par_design.BackColor)
        pen_backcolor = New Pen(par_elementInfo_Base.Back_Color)
        ''pen_backcolor = New Pen(Color.White)

        ''Added 8/28/2019 td
        ''8/29/2019 td''brush_backcolor = New SolidBrush(par_elementInfo_Text.BackColor)
        brush_backcolor = New SolidBrush(par_elementInfo_Base.Back_Color)
        gr.FillRectangle(brush_backcolor, 0, 0, intNewElementWidth, intNewElementHeight)

        ''Added 9/3/2019 td
        pen_border = New Pen(par_elementInfo_Base.Border_Color,
                             par_elementInfo_Base.Border_WidthInPixels)

        ''8/5/2019 td''pen_highlighting = New Pen(Color.YellowGreen, 5)
        pen_highlighting = New Pen(Color.Yellow, 6)

        brush_forecolor = New SolidBrush(par_elementInfo_Text.FontColor)

        ''
        ''Draw the select background color, so that hopefully the text can be read easily.
        ''
        ''7/30/2019 td''gr.DrawRectangle(Brushes.White....

        ''
        ''  https://stackoverflow.com/questions/5183856/converting-from-a-color-to-a-brush
        ''
        Using br_brush As SolidBrush = New SolidBrush(par_elementInfo_Base.Back_Color)
            ''8/15 td''gr.FillRectangle(br_brush,
            ''             New Rectangle(0, 0, par_element.Width_Pixels, par_element.Height_Pixels))
            gr.FillRectangle(br_brush,
                         New Rectangle(0, 0, intNewElementWidth, intNewElementHeight))
        End Using

        ''
        ''Added 9/03/2019 td
        ''
        Dim boolNonzeroBorder As Boolean ''9/9 td 
        If (par_elementInfo_Base.Border_Displayed) Then
            boolNonzeroBorder = (0 < par_elementInfo_Base.Border_WidthInPixels)
            If (boolNonzeroBorder) Then
                ''Added 9/03/2019 td
                gr.DrawRectangle(pen_border, New Rectangle(0, 0, intNewElementWidth, intNewElementHeight))
            End If ''End of "If (boolNonzeroBorder) Then"
        End If ''End of "If (par_elementInfo_Base.Border_Displayed) Then"

        ''
        ''Added 8/02/2019 td
        ''
        If (par_elementInfo_Base.SelectedHighlighting) Then
            ''Added 8/2/2019 td
            ''8/5/2019 td''gr.DrawRectangle(pen_highlighting,
            ''             New Rectangle(0, 0, par_element.Width_Pixels, par_element.Height_Pixels))
            gr.DrawRectangle(pen_highlighting,
                         New Rectangle(3, 3, intNewElementWidth - 6, intNewElementHeight - 6))
        End If ''End of "If (par_element.SelectedHighlighting) Then"

        ''7/30/2019''gr.DrawString(par_design.Text, par_design.Font_DrawingClass, brush_forecolor, New Point(0, 0))

        ''Font TextFont = New Font("Times New Roman", 25, FontStyle.Italic);
        ''    e.Graphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
        ''    e.Graphics.DrawString("Sample Text", TextFont, Brushes.Black, 20, 20);
        ''    e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
        ''    e.Graphics.DrawString("Sample Text", TextFont, Brushes.Black, 20, 85);
        ''    e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        ''    e.Graphics.DrawString("Sample Text", TextFont, Brushes.Black, 20, 150);

        gr.TextRenderingHint = TextRenderingHint.AntiAliasGridFit
        gr.DrawString(par_elementInfo_Text.Text_Static, par_elementInfo_Text.Font_DrawingClass, Brushes.Black, 20, 5)

        Return par_image ''Return Nothing

    End Function ''End of "Public Function GenerateImage_NotInUse(par_label As Label) As Image"

    Public Function Copy() As ClassElementField
        ''
        ''Added 9/17/2019 
        ''
        Dim objCopy As New ClassElementField

        ''10/12/2019 td''objCopy.LoadbyCopyingMembers(Me, Me)
        ''10/13/2019 td''objCopy.LoadbyCopyingMembers(Me, Me, Me)
        objCopy.LoadbyCopyingMembers(Me, Me, Me, Me.BadgeLayout)

        Return objCopy

    End Function ''End of "Public Function Copy() As ClassElementField"

    Public Sub LoadbyCopyingMembers(par_ElementInfo_Base As IElement_Base,
                                    par_ElementInfo_Text As IElement_TextOnly,
                                    par_ElementInfo_Field As IElement_TextField,
                                    par_badgeLayout As BadgeLayoutClass)
        ''
        ''Added 9/13/2019 thomas downes
        ''
        ''--------------------------------------------------------------------------
        ''Step 1 of 2 -- Base properties.
        ''--------------------------------------------------------------------------
        ''
        ''//
        ''// Auto-Mappers  
        ''//   https://stackoverflow.com/questions/16534253/c-sharp-converting-base-class-to-child-class
        ''//   https://dotnettutorials.net/lesson/automapper-in-c-sharp/
        ''//   https://docs.automapper.org/en/latest/Setup.html
        ''//
        ''Dim objMapper As New Mapper(_mapConfig_Base)
        ''objMapper.Map(Of ClassElementField)(par_ElementInfo_Base)

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

        ''--------------------------------------------------------------------------
        ''Step 2 of 2 -- Field-related properties.
        ''--------------------------------------------------------------------------
        ''
        Me.ExampleValue_ForElement = par_ElementInfo_Field.ExampleValue_ForElement
        ''See FieldInfo. ---9/18/2019 td''Me.FieldInCardData = par_ElementInfo_TextFld.FieldInCardData
        ''See FieldInfo. ---9/18/2019 td''Me.FieldLabelCaption = par_ElementInfo_TextFld.FieldLabelCaption
        Me.FieldInfo = par_ElementInfo_Field.FieldInfo ''Added 9/18/2019 td 

        ''Added 10/13/2019 td
        Me.FieldEnum = par_ElementInfo_Field.FieldEnum

        ''Added 10/13/2019 td
        Me.BadgeLayout = New BadgeLayoutClass
        Me.BadgeLayout.Height_Pixels = par_badgeLayout.Height_Pixels
        Me.BadgeLayout.Width_Pixels = par_badgeLayout.Width_Pixels

        Me.FontBold = par_ElementInfo_Text.FontBold
        Me.FontColor = par_ElementInfo_Text.FontColor
        Me.FontFamilyName = par_ElementInfo_Text.FontFamilyName
        Me.FontItalics = par_ElementInfo_Text.FontItalics
        Me.FontOffset_X = par_ElementInfo_Text.FontOffset_X
        Me.FontOffset_Y = par_ElementInfo_Text.FontOffset_Y
        Me.FontSize_Pixels = par_ElementInfo_Text.FontSize_Pixels
        Me.FontSize_ScaleToElementRatio = par_ElementInfo_Text.FontSize_ScaleToElementRatio
        Me.FontSize_ScaleToElementYesNo = par_ElementInfo_Text.FontSize_ScaleToElementYesNo
        Me.FontUnderline = par_ElementInfo_Text.FontUnderline
        Me.Font_DrawingClass = par_ElementInfo_Text.Font_DrawingClass

        ''---See above. ---9/18/2019 td
        ''---Me.ExampleValue = par_ElementInfo_TextFld.ExampleValue

        ''Added 9/19/2019 td 
        Me.TextAlignment = par_ElementInfo_Text.TextAlignment

    End Sub ''End of "Public Sub LoadbyCopyingMembers(par_ElementInfo_Base As IElement_Base, .....)"

    Public Sub Font_ScaleAdjustment(par_intNewHeightInPixels As Integer)
        ''
        ''Added 9/15/2019 td  
        ''
        If FontSize_ScaleToElementYesNo Then

            FontSize_Pixels = CSng(FontSize_ScaleToElementRatio * par_intNewHeightInPixels)
            Font_DrawingClass = modFonts.SetFontSize_Pixels(Font_DrawingClass, FontSize_Pixels)

        End If ''End of "If FontSize_ScaleToElementYesNo Then"

    End Sub ''End of "Public Sub Font_ScaleAdjustment()" 

    Public Shared Sub CheckWidthVsLength_OfText(intWidth As Integer, intHeight As Integer, boolRotated As Boolean)
        ''
        ''Double-check the orientation.  ----9/23/2019 td
        ''
        Dim boolTextImageRotated_0_180 As Boolean = (intWidth > intHeight) ''Vs. Portrait comparison, (intWidth < intHeight)
        Dim boolTextImageRotated_90_270 As Boolean = (intWidth < intHeight) ''Vs. Portrait comparison, (intWidth > intHeight)

        If (boolTextImageRotated_0_180 And boolRotated) Then
            Throw New Exception("Image dimensions are not expected. (Rotation of text expected)")
        ElseIf (boolTextImageRotated_90_270 And (Not boolRotated)) Then
            Throw New Exception("Image dimensions are not expected.  (Unexpected rotation of text is detected)")
        End If ''End of "If (boolImageRotated_0_180 and boolRotated) Then .... ElseIf ..."

    End Sub ''ENd of "Public Shared Sub CheckWidthVsLength_OfText()"

    Public Function LabelText_ToDisplay(par_isForLayout_OrPreview As Boolean,
                                        Optional pbAllowExampleValues As Boolean = True) As String
        ''
        ''Added 10/16/2016 & 7/25/2019 thomas d 
        ''
        ''This was copied from CtlGraphicFldLabel.vb on 10/16/2019 td
        ''
        Dim bOkayToUseExampleValues As Boolean ''Added 10/16/2019 td  

        ''11/18/2019 td''bOkayToUseExampleValues = par_isForLayout_OrPreview
        Dim boolNotAFinalPrint As Boolean ''Added 11/18/2019 td
        boolNotAFinalPrint = par_isForLayout_OrPreview ''Added 11/18/2019 td
        bOkayToUseExampleValues = (boolNotAFinalPrint And pbAllowExampleValues)

        Select Case True

            Case (ClassElementField.oRecipient IsNot Nothing)
                ''
                ''Added 10/16/2019 thomas d. 
                ''
                Return ClassElementField.oRecipient.GetTextValue(Me.FieldEnum)

                ''Case (Me.ExampleTextToDisplay.Trim() <> "")
                ''    ''
                ''    ''Added 9/18/2019 td 
                ''    ''
                ''    Return Me.ExampleTextToDisplay

            Case (ClassElementField.iRecipientInfo IsNot Nothing)

                Return ClassElementField.iRecipientInfo.GetTextValue(Me.FieldEnum)

            Case (bOkayToUseExampleValues And (Me.ExampleValue_ForElement <> ""))
                ''10/16 td''Case (Me.ExampleValue_ForElement <> "")
                ''
                ''Added 9/18/2019 td 
                ''
                Return Me.ExampleValue_ForElement

            Case (bOkayToUseExampleValues And (Me.FieldInfo.ExampleValue <> ""))
                ''10/16 td''Case (UseExampleValues And (Me.FieldInfo.ExampleValue <> ""))

                ''Me.ElementInfo.Info.Text = Me.FieldInfo.ExampleValue
                Return Me.FieldInfo.ExampleValue

            Case (Me.FieldInfo.FieldLabelCaption <> "")

                ''Me.ElementInfo.Info.Text = Me.FieldInfo.ExampleValue
                Return Me.FieldInfo.FieldLabelCaption

            Case Else

                ''Default value.
                ''7/29 td''Me.ElementInfo.Info.Text = $"Field #{Me.FieldInfo.FieldIndex}"
                Return $"Field #{Me.FieldInfo.FieldIndex}"

        End Select ''End of "Select Case True"

        Return "Field Information"

    End Function ''End of "Public Function LabelText(par_previewExample As Boolean) As String"

End Class ''End of "Class ClassElementField"  
