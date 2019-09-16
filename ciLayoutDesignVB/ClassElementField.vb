Option Explicit On
Option Strict On
Option Infer Off

''Added 7/18/2019 thomas downes
Imports ciBadgeInterfaces ''Added 8/14/2019 thomas d. 8/14/2019 td  
Imports System.Drawing.Text ''Added 

Public Class ClassElementField
    Implements IElement_Base, IElement_TextField
    ''
    ''Added 7/18/2019 thomas downes
    ''
    ''
    ''7/29/2019 td''Public Property Info As IElementText
    ''
    ''-------------------------------------------------------------

    Public Property Font_DrawingClass As System.Drawing.Font Implements IElement_TextField.Font_DrawingClass

    Public Property PositionalMode As String Implements IElement_Base.PositionalMode ''Added 8/14/2019 td 
    Public Property ExampleValue As String Implements IElement_TextField.ExampleValue ''Added 8/14/2019 td 

    Public Property FontColor As System.Drawing.Color Implements IElement_TextField.FontColor

    ''Added 8/12/2019 thomas downes  
    Public Property FontSize_Pixels As Single = 25 Implements IElement_TextField.FontSize_Pixels ''Added 8/12/2019 thomas downes  
    Public Property FontBold As Boolean Implements IElement_TextField.FontBold ''Added 8/12/2019 thomas downes  
    Public Property FontItalics As Boolean Implements IElement_TextField.FontItalics ''Added 8/12/2019 thomas downes  
    Public Property FontUnderline As Boolean Implements IElement_TextField.FontUnderline ''Added 8/12/2019 thomas downes  
    ''Added 9/6/2019 thomas downes  
    Public Property FontFamilyName As String = "Times New Roman" Implements IElement_TextField.FontFamilyName ''Added 9/6/2019 thomas downes  


    ''Added 8/15/2019 thomas downes  
    ''9/12/2019 td''Public Property FontSize_IsLocked As Boolean Implements IElement_Text.FontSize_IsLocked ''Added 8/15/2019 thomas downes  
    Public Property FontSize_ScaleToElementRatio As Double Implements IElement_TextField.FontSize_ScaleToElementRatio ''Added 9/12/2019 thomas downes  
    Public Property FontSize_ScaleToElementYesNo As Boolean = True Implements IElement_TextField.FontSize_ScaleToElementYesNo ''Added 9/12/2019 thomas downes  


    Public Property FontOffset_X As Integer Implements IElement_TextField.FontOffset_X ''Added 8/15/2019 thomas downes  
    Public Property FontOffset_Y As Integer Implements IElement_TextField.FontOffset_Y ''Added 8/15/2019 thomas downes  


    ''See Interface IElement_Base. ---8/29/2019 td''Public Property BackColor As System.Drawing.Color Implements IElement_Text.BackColor

    Public Property FieldInCardData As String Implements IElement_TextField.FieldInCardData

    Public Property FieldLabelCaption As String Implements IElement_TextField.FieldLabelCaption

    ''7/25/2019 td''Prpoerty ExampleText As String ''Added 7/25/2019
    Public Property Text As String Implements IElement_TextField.Text ''E.g. "George Washington" for FullName. 

    ''Added 9/10/2019 td 
    Public Property Recipient As IRecipient Implements IElement_TextField.Recipient

    Public Property TextAlignment As System.Windows.Forms.HorizontalAlignment Implements IElement_TextField.TextAlignment


    Public Property OrientationToLayout As String Implements IElement_Base.OrientationToLayout ''E.g. "L" (Landscape) (by far the most common) or "P" for Portrait  

    Public Property OrientationInDegrees As Integer Implements IElement_Base.OrientationInDegrees ''Default is 0, normal.  90 would be 1/4 turn clockwise.  180 is upside-down.  270 is the printing on the spine of a book sitting on the bookshelf.

    Public Property Image_BL As Image Implements IElement_Base.Image_BL ''Added 8/27/2019 td

    ''Moved below. 8/27/2019 td''Public Property SelectedHighlighting As Boolean Implements IElement_Base.SelectedHighlighting ''Added 8/2/2019 td  


    ''-------------------------------------------------------------
    ''-------------------------------------------------------------
    ''-------------------------------------------------------------

    Public Property FormControl As Control Implements IElement_Base.FormControl ''Added 7/19/2019  

    Public Property ElementType As String = "Text" Implements IElement_Base.ElementType ''Text, Pic, or Logo

    ''9/11/2019 td''Public Property LayoutWidth_Pixels As Integer Implements IElement_Base.LayoutWidth_Pixels ''This provides sizing context & scaling factors. 
    Public Property BadgeLayout As BadgeLayoutClass Implements IElement_Base.BadgeLayout ''Added 9/11/2019 td  

    Public Property TopEdge_Pixels As Integer = 0 Implements IElement_Base.TopEdge_Pixels
    Public Property LeftEdge_Pixels As Integer = 0 Implements IElement_Base.LeftEdge_Pixels

    Public Property Width_Pixels As Integer = 253 Implements IElement_Base.Width_Pixels
    Public Property Height_Pixels As Integer = 33 Implements IElement_Base.Height_Pixels

    ''8/29/2019 td''Public Property Border_Pixels As Integer Implements IElement_Base.Border_Pixels
    Public Property Border_WidthInPixels As Integer = 1 Implements IElement_Base.Border_WidthInPixels
    Public Property Border_Color As System.Drawing.Color = Color.Black Implements IElement_Base.Border_Color
    Public Property Border_Displayed As Boolean = True Implements IElement_Base.Border_Displayed ''Added 9/9/2019 td 

    Public Property Back_Color As System.Drawing.Color = Color.White Implements IElement_Base.Back_Color
    Public Property Back_Transparent As Boolean = False Implements IElement_Base.Back_Transparent ''Added 9/4/2019 thomas d. 

    Public Property SelectedHighlighting As Boolean Implements IElement_Base.SelectedHighlighting ''Added 8/2/2019 td  

    Private _labelToImage As New ClassLabelToImage ''Added 9/3/2019 td  

    Public Sub New(par_control As Control)

        ''Added 7/19/2019 td
        ''
        Me.FormControl = par_control

    End Sub

    Public Sub New(par_intLeft_Pixels As Integer, par_intTop_Pixels As Integer, par_intHeight_Pixels As Integer)
        ''
        ''Added 9/15/2019 td
        ''
        Me.BadgeLayout = New ciBadgeInterfaces.BadgeLayoutClass ''Added 9/12/2019

        Me.LeftEdge_Pixels = par_intLeft_Pixels
        Me.TopEdge_Pixels = par_intTop_Pixels
        Me.Height_Pixels = par_intHeight_Pixels

    End Sub

    Public Sub New()
        ''
        ''Added 7/29/2019 td
        ''
        Me.BadgeLayout = New ciBadgeInterfaces.BadgeLayoutClass ''Added 9/12/2019

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
        Implements IElement_TextField.GenerateImage_ByDesiredLayoutWidth
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
            obj_image = _labelToImage.TextImage(pintDesiredLayoutWidth, Me, Me, False, False)

        Catch ex As Exception
            ''Added 9/15/2019 td  
            MessageBox.Show(ex.Message, "90022", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        Return obj_image

    End Function ''End of "Public Function GenerateImage_ByDesiredLayoutWidth() As Image Implements IElementText.GenerateImage_ByDesiredLayoutWidth"

    Public Function GenerateImage_ByDesiredLayoutHeight(pintDesiredLayoutHeight As Integer) As Image _
        Implements IElement_TextField.GenerateImage_ByDesiredLayoutHeight
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
        Dim doubleCorrectRatioW_to_H As Double ''Added 9/4/2019 td

        ''Added 9/4/2019 td
        doubleCorrectRatioW_to_H = ciLayoutPrintLib.LayoutPrint.LongSideToShortRatio()

        ''9/4 td''intDesiredLayoutWidth = CInt(pintDesiredLayoutHeight * ciLayoutPrintLib.LayoutPrint.LongSideToShortRatio())

        intDesiredLayoutWidth = CInt(pintDesiredLayoutHeight * doubleCorrectRatioW_to_H)

        ''9/3/2019 td''GenerateImage(intDesiredLayoutWidth, obj_image, Me, Me)
        ''9/4/2019 td''_labelToImage.TextImage(intDesiredLayoutWidth, obj_image, Me, Me, False)

        obj_image = _labelToImage.TextImage(intDesiredLayoutWidth, Me, Me, False, False)

        Return obj_image

    End Function ''End of "Public Function GenerateImage_ByDesiredLayoutHeight() As Image Implements IElementText.GenerateImage_ByDesiredLayoutWidth"

    Public Function GenerateImage_NotInUse(pintDesiredLayoutWidth As Integer, ByRef par_image As Image,
                                  par_elementInfo_Text As IElement_TextField, par_elementInfo_Base As IElement_Base) As Image
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
            If (ClassLabelToImage.UseHighResolutionTips) Then

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
        gr.DrawString(par_elementInfo_Text.Text, par_elementInfo_Text.Font_DrawingClass, Brushes.Black, 20, 5)

        Return par_image ''Return Nothing

    End Function ''End of "Public Function GenerateImage_NotInUse(par_label As Label) As Image"

    Public Sub LoadbyCopyingMembers(par_ElementInfo_Base As IElement_Base,
                                    par_ElementInfo_Text As IElement_TextField)
        ''
        ''Added 9/13/2019 thomas downes
        ''
        Me.Back_Color = par_ElementInfo_Base.Back_Color
        Me.Back_Transparent = par_ElementInfo_Base.Back_Transparent
        Me.BadgeLayout = par_ElementInfo_Base.BadgeLayout
        Me.Border_Color = par_ElementInfo_Base.Border_Color
        Me.Border_Displayed = par_ElementInfo_Base.Border_Displayed
        Me.Border_WidthInPixels = par_ElementInfo_Base.Border_WidthInPixels

        Me.ExampleValue = par_ElementInfo_Text.ExampleValue
        Me.FieldInCardData = par_ElementInfo_Text.FieldInCardData

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

        Me.Height_Pixels = par_ElementInfo_Base.Height_Pixels
        Me.LeftEdge_Pixels = par_ElementInfo_Base.LeftEdge_Pixels
        Me.OrientationInDegrees = par_ElementInfo_Base.OrientationInDegrees
        Me.OrientationToLayout = par_ElementInfo_Base.OrientationToLayout

        Me.PositionalMode = par_ElementInfo_Base.PositionalMode
        Me.SelectedHighlighting = par_ElementInfo_Base.SelectedHighlighting

        Me.TopEdge_Pixels = par_ElementInfo_Base.TopEdge_Pixels

        Me.Width_Pixels = par_ElementInfo_Base.Width_Pixels

        Me.ExampleValue = par_ElementInfo_Text.ExampleValue

        Me.FieldInCardData = par_ElementInfo_Text.FieldInCardData

        Me.FieldLabelCaption = par_ElementInfo_Text.FieldLabelCaption

        Me.FontBold = par_ElementInfo_Text.FontBold






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


End Class ''End of "Class ClassElementField"  
