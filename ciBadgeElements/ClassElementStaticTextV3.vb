﻿Option Explicit On
Option Strict On
Option Infer Off

''Added 9/16/2019 thomas downes
Imports System.Drawing ''Added 9/18/2019 td
Imports System.Drawing.Text ''Added 9/18/2019 td
Imports System.Windows.Forms ''Added 9/18/2019 td
Imports ciBadgeInterfaces ''Added 9/61/2019 thomas d. 
Imports System.Xml.Serialization ''Added 10/13/2019 thomas d.
Imports ciBadgeSerialize ''Added 6/7/2022  

<Serializable>
Public Class ClassElementStaticTextV3
    Inherits ClassElementBase ''Added 1/8/2022 Thomas Downes
    ''12/31/2022 Implements IElement_Base, IElement_TextOnly
    Implements IElement_TextOnly
    ''
    ''Added 9/16/2019 thomas downes
    ''
    ''
    ''12/2022 Public Property BadgeDisplayIndex As Integer Implements IElement_Base.BadgeDisplayIndex ''Added 11/24/2021 td 
    ''12/2022 Public Property WhichSideOfCard As EnumWhichSideOfCard Implements IElement_Base.WhichSideOfCard ''Added 12/13/2021 td
    ''12/2022 Public Property DateEdited As Date Implements IElement_Base.DateEdited ''Added 12/18/2021 thomas downes  
    ''12/2022 Public Property DateSaved As Date Implements IElement_Base.DateSaved ''Added 12/18/2021 thomas downes

    ''Moved down & underscore removed. 6/7/2022 <Xml.Serialization.XmlIgnore>
    ''Moved down & underscore removed. 6/7/2022 Public Property Font_DrawingClass As System.Drawing.Font Implements IElement_TextOnly.Font_DrawingClass


    ''9/7/2022 td''Public Property PositionalMode As String Implements IElement_Base.PositionalMode ''Added 8/14/2019 td 
    ''9/16 td''Public Property ExampleValue As String Implements IElement_StaticText.ExampleValue ''Added 8/14/2019 td 

    <XmlIgnore>
    Public Property FontColor As System.Drawing.Color Implements IElement_TextOnly.FontColor

#Disable Warning CA1707 ''Warning "Remove underscores."

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

#Enable Warning CA1707 ''Warning "Remove underscores."


    ''Added 8/12/2019 thomas downes  
    Public Property FontSize_Pixels As Single = 25 Implements IElement_TextOnly.FontSize_Pixels ''Added 8/12/2019 thomas downes  
    Public Property FontBold_Deprecated As Boolean Implements IElement_TextOnly.FontBold_Deprecated ''Added 8/12/2019 thomas downes  
    Public Property FontItalics_Deprecated As Boolean Implements IElement_TextOnly.FontItalics_Deprecated ''Added 8/12/2019 thomas downes  
    Public Property FontUnderline_Deprecated As Boolean Implements IElement_TextOnly.FontUnderline_Deprecated ''Added 8/12/2019 thomas downes  
    ''Added 9/6/2019 thomas downes  
    Public Property FontFamilyName As String = "Times New Roman" Implements IElement_TextOnly.FontFamilyName ''Added 9/6/2019 thomas downes  

    ''Added 6/7/2022 thomas downes 
    Public Property FontMaxGalkin As SerializableFontByMaxGalkin Implements IElement_TextOnly.FontMaxGalkin
    ''Redundant. 6/7/2022 Public Property Font_FamilyName As String Implements IElement_TextOnly.Font_FamilyName

    ''Moved here from above, and underscore ("Font_DrawingClass") removed. 6/7/2022
    ''6/07/2022 Public Property FontDrawingClass As System.Drawing.Font Implements IElement_TextOnly.FontDrawingClass
    <Xml.Serialization.XmlIgnore>
    Public Property FontDrawingClass As System.Drawing.Font Implements IElement_TextOnly.FontDrawingClass
        ''6/7/2022 Public Property Font_DrawingClass As System.Drawing.Font Implements IElement_TextOnly.Font_DrawingClass
        Get
            ''Added 6/07/2022 td
            Return Me.FontMaxGalkin.ToFont_AnyUnits()

        End Get

        Set(value As System.Drawing.Font)
            ''Added 6/07/2022 td
            Me.FontMaxGalkin = SerializableFontByMaxGalkin.FromFont(value)
        End Set

    End Property

    ''Added 8/15/2019 thomas downes  
    ''9/12/2019 td''Public Property FontSize_IsLocked As Boolean Implements IElement_Text.FontSize_IsLocked ''Added 8/15/2019 thomas downes  
    Public Property FontSize_AutoScaleToElementRatio As Double Implements IElement_TextOnly.FontSize_AutoScaleToElementRatio ''Added 9/12/2019 thomas downes  
    Public Property FontSize_AutoScaleToElementYesNo As Boolean = True Implements IElement_TextOnly.FontSize_AutoScaleToElementYesNo ''Added 9/12/2019 thomas downes  
    Public Property FontSize_AutoSizePromptUser As Boolean = True Implements IElement_TextOnly.FontSize_AutoSizePromptUser ''Added 6/2/2022

    Public Property FontOffset_X As Integer Implements IElement_TextOnly.FontOffset_X ''Added 8/15/2019 thomas downes  
    Public Property FontOffset_Y As Integer Implements IElement_TextOnly.FontOffset_Y ''Added 8/15/2019 thomas downes  


    ''See Interface IElement_Base. ---8/29/2019 td''Public Property BackColor As System.Drawing.Color Implements IElement_Text.BackColor

    ''9/16 td''Public Property FieldInCardData As String Implements IElement_StaticText.FieldInCardData

    ''9/16 td''Public Property FieldLabelCaption As String Implements IElement_StaticText.FieldLabelCaption

    ''7/25/2019 td''Prpoerty ExampleText As String ''Added 7/25/2019
    ''10/10/2019 td''Public Property Text As String Implements IElement_TextOnly.Text ''E.g. "George Washington" for FullName. 

    Private mod_strTextToDisplay As String ''Added 10/10/2019 td


    Public Property Text_StaticLine As String Implements IElement_TextOnly.Text_StaticLine ''Added 10/10/2019 td
        Get
            ''Added 10/10/2019 td 
            Return mod_strTextToDisplay
        End Get
        Set(value As String)
            ''Added 10/10/2019 td 
            mod_strTextToDisplay = value
        End Set
    End Property


    Public Property Text_IsMultiLine As Boolean Implements IElement_TextOnly.Text_IsMultiLine ''Added 5/31/2022


#Disable Warning CA1707 ''Warning, underscores.  Added 12/2022

    Private _ListOfLines As List(Of String) ''Added 12/31/2022
    Public ReadOnly Property Text_ListOfLines As List(Of String) ''12/2022 Implements IElement_TextOnly.Text_ListOfLines ''Added 5/31/2022
        Get
            Return _ListOfLines ''Added 12/31/2022
        End Get
    End Property

    Public Property Text_Formula As String Implements IElement_TextOnly.Text_Formula ''Added 10/17/2019
    Public Property Text_ExampleValue As String Implements IElement_TextOnly.Text_ExampleValue ''Added 5/31/2022

    ''Added 9/10/2019 td 
    ''9/16 td''Public Property Recipient As IRecipient Implements IElement_StaticText.Recipient

    Public Property TextAlignment As System.Windows.Forms.HorizontalAlignment Implements IElement_TextOnly.TextAlignment


    ''9/9/2022 Public Property OrientationToLayout As String Implements IElement_Base.OrientationToLayout ''E.g. "L" (Landscape) (by far the most common) or "P" for Portrait  
    ''9/9/2022 Public Property OrientationInDegrees As Integer Implements IElement_Base.OrientationInDegrees ''Default is 0, normal.  90 would be 1/4 turn clockwise.  180 is upside-down.  270 is the printing on the spine of a book sitting on the bookshelf.
    ''9/9/2022 <Xml.Serialization.XmlIgnore>
    ''9/9/2022 Public Property Image_BL As Image Implements IElement_Base.Image_BL ''Added 8/27/2019 td
    ''9/9/2022 Public Property Visible As Boolean = True Implements IElement_Base.Visible ''Added 9/18/2019 td  


    ''Moved below. 8/27/2019 td''Public Property SelectedHighlighting As Boolean Implements IElement_Base.SelectedHighlighting ''Added 8/2/2019 td  


    ''-------------------------------------------------------------
    ''-------------------------------------------------------------
    ''-------------------------------------------------------------
    ''<XmlIgnore>
    ''Public Property FormControl As Control Implements IElement_Base.FormControl ''Added 7/19/2019  

    ''Public Property ElementType As String = "Text" Implements IElement_Base.ElementType ''Text, Pic, or Logo

    ''''9/11/2019 td''Public Property LayoutWidth_Pixels As Integer Implements IElement_Base.LayoutWidth_Pixels ''This provides sizing context & scaling factors. 
    ''Public Property BadgeLayout As BadgeLayoutDimensionsClass Implements IElement_Base.BadgeLayout ''Added 9/11/2019 td  

    ''Public Property TopEdge_Pixels As Integer = 0 Implements IElement_Base.TopEdge_Pixels
    ''Public Property LeftEdge_Pixels As Integer = 0 Implements IElement_Base.LeftEdge_Pixels

    ''Public Property Width_Pixels As Integer = 253 Implements IElement_Base.Width_Pixels
    ''Public Property Height_Pixels As Integer = 33 Implements IElement_Base.Height_Pixels

    ''''8/29/2019 td''Public Property Border_Pixels As Integer Implements IElement_Base.Border_Pixels
    ''Public Property Border_WidthInPixels As Integer = 1 Implements IElement_Base.Border_WidthInPixels

    ''<XmlIgnore>
    ''Public Property Border_Color As System.Drawing.Color = Color.Black Implements IElement_Base.Border_Color

    ''<XmlElement("Border_Color")>
    ''Public Property Border_Color_HTML As String
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


    ''Public Property Border_Displayed As Boolean = True Implements IElement_Base.Border_Displayed ''Added 9/9/2019 td 

    ''<XmlIgnore>
    ''Public Property Back_Color As System.Drawing.Color = Color.White Implements IElement_Base.Back_Color

    ''<XmlElement("Back_Color")>
    ''Public Property Back_Color_HTML As String
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


    ''Public Property Back_Transparent As Boolean = False Implements IElement_Base.Back_Transparent ''Added 9/4/2019 thomas d. 

    ''Public Property SelectedHighlighting As Boolean Implements IElement_Base.SelectedHighlighting ''Added 8/2/2019 td  

    ''Public Property ZOrder As Integer Implements IElement_Base.ZOrder
    ''    Get
    ''        Return 0 ''Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As Integer)
    ''        Return ''Throw New NotImplementedException()
    ''    End Set
    ''End Property

    ''
    ''Added 5/27/2022 td
    ''
    ''5/28/2022 Public Shadows Property ConditionalExpressionValue As String Implements IElement_Base.ConditionalExpressionValue
    ''5/28/2022 Public Shadows Property ConditionalExpressionField As EnumCIBFields Implements IElement_Base.ConditionalExpressionField
    ''5/28/2022 Public Shadows Property ConditionalExpressionInUse As Boolean Implements IElement_Base.ConditionalExpressionInUse


    ''9/18/2019 td''Private _labelToImage As New ClassLabelToImage ''Added 9/3/2019 td  

#Disable Warning CA1707 ''Underscore warning. 12/2022

    Public Sub New(par_control As Control)

        ''Added 7/19/2019 td
        ''
        Me.FormControl = par_control

    End Sub


    Public Sub New(par_DisplayText As String,
                   par_intLeft_Pixels As Integer,
                   par_intTop_Pixels As Integer,
                   par_intHeight_Pixels As Integer,
                   par_intWidth_Pixels As Integer,
                   par_badgeLayout As BadgeLayoutDimensionsClass)
        ''
        ''Added 9/15/2019 td
        ''
        ''9/5/2022 Me.BadgeLayout = New ciBadgeInterfaces.BadgeLayoutDimensionsClass ''Added 9/12/2019
        ''2/21/2023 Me.BadgeLayoutDims = New ciBadgeInterfaces.BadgeLayoutDimensionsClass ''Added 9/12/2019
        Me.BadgeLayoutDims = New BadgeLayoutDimensionsClass(par_badgeLayout.Width_Pixels,
                                      par_badgeLayout.Height_Pixels) ''Added 2/21/2022 td

        Me.LeftEdge_Pixels = par_intLeft_Pixels
        Me.TopEdge_Pixels = par_intTop_Pixels
        Me.Height_Pixels = par_intHeight_Pixels
        Me.Width_Pixels = par_intWidth_Pixels ''Added 8/17/2022

        ''Added 8/17/2022 td
        ''  Let's write to the base class. ("b" = "base")
        ''9/2022 Me.LeftEdge_bPixels = par_intLeft_Pixels
        ''9/2022 Me.TopEdge_bPixels = par_intTop_Pixels
        ''9/2022 Me.Height_bPixels = par_intHeight_Pixels
        ''9/2022 Me.Width_bPixels = par_intWidth_Pixels ''Added 8/17/2022
        Me.LeftEdge_Pixels = par_intLeft_Pixels
        Me.TopEdge_Pixels = par_intTop_Pixels
        Me.Height_Pixels = par_intHeight_Pixels
        Me.Width_Pixels = par_intWidth_Pixels ''Added 8/17/2022

        ''Added 10//10/2019 td
        Me.Text_StaticLine = par_DisplayText

    End Sub

    Public Sub New()
        ''
        ''Added 7/29/2019 td
        ''
        ''9/2022 Me.BadgeLayout = New ciBadgeInterfaces.BadgeLayoutDimensionsClass ''Added 9/12/2019
        Me.BadgeLayoutDims = New ciBadgeInterfaces.BadgeLayoutDimensionsClass ''Added 9/12/2019

    End Sub

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

    Public Function GenerateImage_ByDesiredLayoutWidth(pintDesiredLayoutWidth As Integer) As Image _
        Implements IElement_TextOnly.GenerateImage_ByDesiredLayoutWidth
        ''
        ''    8/26 td''Public Function GenerateImage(pintLayoutHeight As Integer) As Image Implements IElementText.GenerateImage
        ''
        ''Added 8/14/2019 thomas downes 
        ''
        Dim obj_image As Image = Nothing

        Try
            ''
            ''Major call !!
            '' 
            ''Not ready yet. ---9/16 td''obj_image = _labelToImage.TextImage_Static(pintDesiredLayoutWidth, Me, Me, False, False)

        Catch ex As Exception
            ''Added 9/15/2019 td  
            MessageBox.Show(ex.Message, "90022", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        Return obj_image

    End Function ''End of "Public Function GenerateImage_ByDesiredLayoutWidth() As Image Implements IElementText.GenerateImage_ByDesiredLayoutWidth"


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
        ''Deprecated. 9/18 td''doubleCorrectRatioW_to_H = ciLayoutPrintLib.LayoutPrint.LongSideToShortRatio()

        ''9/4 td''intDesiredLayoutWidth = CInt(pintDesiredLayoutHeight * ciLayoutPrintLib.LayoutPrint.LongSideToShortRatio())

        intDesiredLayoutWidth = CInt(pintDesiredLayoutHeight * doubleCorrectRatioW_to_H)

        ''9/3/2019 td''GenerateImage(intDesiredLayoutWidth, obj_image, Me, Me)
        ''9/4/2019 td''_labelToImage.TextImage(intDesiredLayoutWidth, obj_image, Me, Me, False)

        ''Not ready yet!!!!! ----&-9/16/2019 td
        '----&-obj_image = _labelToImage.TextImage_Field(intDesiredLayoutWidth, Me, Me, False, False)

        Return obj_image

    End Function ''End of "Public Function GenerateImage_ByDesiredLayoutHeight() As Image Implements IElementText.GenerateImage_ByDesiredLayoutWidth"


#Disable Warning CA1707

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
        gr.DrawString(par_elementInfo_Text.Text_StaticLine,
                      par_elementInfo_Text.FontDrawingClass, Brushes.Black, 20, 5)
        ''6/2022    par_elementInfo_Text.Font_DrawingClass, Brushes.Black, 20, 5)

        Return par_image ''Return Nothing

    End Function ''End of "Public Function GenerateImage_NotInUse(par_label As Label) As Image"

#Enable Warning CA1707


    Public Function Copy() As ClassElementStaticTextV3
        ''
        ''Added 9/17/2019 
        ''
        Dim objCopy As New ClassElementStaticTextV3
        objCopy.LoadbyCopyingMembers(Me, Me)
        Return objCopy

    End Function ''End of "Public Function Copy() As ClassElementStaticText"

#Disable Warning CA1707 ''Message about underscores in parameter names. 

    Public Sub LoadbyCopyingMembers(par_ElementInfo_Base As IElement_Base,
                                    par_ElementInfo_Text As IElement_TextOnly)
        ''
        ''Added 9/13/2019 thomas downes
        ''
        Me.Back_Color = par_ElementInfo_Base.Back_Color
        Me.Back_Transparent = par_ElementInfo_Base.Back_Transparent
        Me.BadgeLayoutDims = par_ElementInfo_Base.BadgeLayoutDims
        Me.Border_Color = par_ElementInfo_Base.Border_Color
        Me.Border_Displayed = par_ElementInfo_Base.Border_Displayed
        Me.Border_WidthInPixels = par_ElementInfo_Base.Border_WidthInPixels

        ''9/16/2019 td''Me.ExampleValue = par_ElementInfo_Text.ExampleValue
        ''9/16/2019 td''Me.FieldInCardData = par_ElementInfo_Text.FieldInCardData

        ''Added 6/2/2022 td
        If (par_ElementInfo_Text Is Nothing) Then
            Throw New ArgumentNullException("par_ElementInfo_Text")
        End If ''End of ""If (par_ElementInfo_Text Is Nothing) Then""

        Me.FontBold_Deprecated = par_ElementInfo_Text.FontBold_Deprecated ''Deprecated 6/2022 td
        Me.FontColor = par_ElementInfo_Text.FontColor
        Me.FontFamilyName = par_ElementInfo_Text.FontFamilyName
        Me.FontItalics_Deprecated = par_ElementInfo_Text.FontItalics_Deprecated ''Deprecated 6/2022 td
        Me.FontOffset_X = par_ElementInfo_Text.FontOffset_X
        Me.FontOffset_Y = par_ElementInfo_Text.FontOffset_Y
        Me.FontSize_Pixels = par_ElementInfo_Text.FontSize_Pixels
        Me.FontSize_AutoScaleToElementRatio = par_ElementInfo_Text.FontSize_AutoScaleToElementRatio
        Me.FontSize_AutoScaleToElementYesNo = par_ElementInfo_Text.FontSize_AutoScaleToElementYesNo
        Me.FontSize_AutoSizePromptUser = par_ElementInfo_Text.FontSize_AutoSizePromptUser ''Added 6/2/2022 td

        Me.FontUnderline_Deprecated = par_ElementInfo_Text.FontUnderline_Deprecated ''Deprecated 6/2022 td
        ''6/7/2022 Me.Font_DrawingClass = par_ElementInfo_Text.Font_DrawingClass
        Me.FontMaxGalkin = par_ElementInfo_Text.FontMaxGalkin ''Added 6/7/2022 td

        Me.Height_Pixels = par_ElementInfo_Base.Height_Pixels
        Me.LeftEdge_Pixels = par_ElementInfo_Base.LeftEdge_Pixels
        Me.OrientationInDegrees = par_ElementInfo_Base.OrientationInDegrees
        Me.OrientationToLayout = par_ElementInfo_Base.OrientationToLayout

        Me.PositionalMode = par_ElementInfo_Base.PositionalMode
        Me.SelectedHighlighting = par_ElementInfo_Base.SelectedHighlighting

        Me.TopEdge_Pixels = par_ElementInfo_Base.TopEdge_Pixels

        Me.Width_Pixels = par_ElementInfo_Base.Width_Pixels

        ''9/16/2019 td''Me.ExampleValue = par_ElementInfo_Text.ExampleValue

        ''9/16/2019 td''Me.FieldInCardData = par_ElementInfo_Text.FieldInCardData

        ''9/16/2019 td''Me.FieldLabelCaption = par_ElementInfo_Text.FieldLabelCaption

        Me.FontBold_Deprecated = par_ElementInfo_Text.FontBold_Deprecated

    End Sub ''End of "Public Sub LoadbyCopyingMembers(par_ElementInfo_Base As IElement_Base, .....)"

#Enable Warning CA1707 ''Message about underscores in parameter names. 
#Disable Warning CA1707 ''Message about underscores in parameter names. 

    Public Sub Font_ScaleAdjustment(par_intNewHeightInPixels As Integer,
                       Optional pbSuppressFontScalingConfirmation As Boolean = True)
        ''
        ''Added 9/15/2019 td  
        ''
        Dim bScaleFontToElementSize As Boolean ''Added 6/2/2022 

        ''Added 6/2/2022
        bScaleFontToElementSize = (Not pbSuppressFontScalingConfirmation) AndAlso
                                  (FontSize_AutoScaleToElementYesNo) AndAlso
                                 ((Not FontSize_AutoSizePromptUser) OrElse
                          MessageBoxTD.Show_Confirm("Resize the font of text?"))

        ''6/2/2022  If (FontSize_AutoScaleToElementYesNo) Then 
        If (bScaleFontToElementSize) Then

            ''Added 11/24/2021 thomas d. 
            If (0 = FontSize_AutoScaleToElementRatio) Then
                ''Added 11/24/2021 thomas d. 
                FontSize_AutoScaleToElementRatio = 0.8
            End If ''End of "If (0 = FontSize_ScaleToElementRatio) Then"

            FontSize_Pixels = CSng(FontSize_AutoScaleToElementRatio *
                                     par_intNewHeightInPixels)
            ''6/7/2022 Font_DrawingClass = modFonts.SetFontSize_Pixels(Font_DrawingClass, FontSize_Pixels)
            FontDrawingClass = modFonts.SetFontSize_Pixels(FontDrawingClass, FontSize_Pixels)

        End If ''End of "If (bScaleFontToElementSize Then"


    End Sub ''End of "Public Sub Font_ScaleAdjustment()" 

#Enable Warning CA1707 ''Message about underscores in parameter names. 
#Disable Warning CA1707 ''Message about underscores in parameter names. 

    Public Function ImageForBadgeImage_SText(par_recipient As IRecipient, par_scale As Single) As Image _
        ''12/31/2022 Implements IElement_Base.ImageForBadgeImage

        ''Throw New NotImplementedException()
        '9/1/2022 Throw New NotImplementedException()
        System.Diagnostics.Debugger.Break()
        Return New Bitmap(MyBase.Width_Pixels, MyBase.Height_Pixels)

    End Function ''End of ""Public Function ImageForBadgeImage_SText""

#Enable Warning CA1707 ''Message about underscores in parameter names. 


End Class ''End of "Class ClassElementStaticText"  

