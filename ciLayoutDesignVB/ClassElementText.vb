Option Explicit On
Option Strict On
Option Infer Off

''Added 7/18/2019 thomas downes
Imports ciBadgeInterfaces ''Added 8/14/2019 thomas d. 8/14/2019 td  
Imports System.Drawing.Text ''Added 

Public Class ClassElementText
    Implements IElement_Base, IElement_Text
    ''
    ''Added 7/18/2019 thomas downes
    ''
    ''
    ''7/29/2019 td''Public Property Info As IElementText
    ''
    ''-------------------------------------------------------------

    Public Property Font_DrawingClass As System.Drawing.Font Implements IElement_Text.Font_DrawingClass

    Public Property PositionalMode As String Implements IElement_Base.PositionalMode ''Added 8/14/2019 td 
    Public Property ExampleValue As String Implements IElement_Text.ExampleValue ''Added 8/14/2019 td 

    Public Property FontColor As System.Drawing.Color Implements IElement_Text.FontColor

    ''Added 8/12/2019 thomas downes  
    Public Property FontSize As Single Implements IElement_Text.FontSize ''Added 8/12/2019 thomas downes  
    Public Property FontBold As Boolean Implements IElement_Text.FontBold ''Added 8/12/2019 thomas downes  
    Public Property FontItalics As Boolean Implements IElement_Text.FontItalics ''Added 8/12/2019 thomas downes  
    Public Property FontUnderline As Boolean Implements IElement_Text.FontUnderline ''Added 8/12/2019 thomas downes  


    ''Added 8/15/2019 thomas downes  
    Public Property FontSize_IsLocked As Boolean Implements IElement_Text.FontSize_IsLocked ''Added 8/15/2019 thomas downes  
    Public Property FontOffset_X As Integer Implements IElement_Text.FontOffset_X ''Added 8/15/2019 thomas downes  
    Public Property FontOffset_Y As Integer Implements IElement_Text.FontOffset_Y ''Added 8/15/2019 thomas downes  


    ''See Interface IElement_Base. ---8/29/2019 td''Public Property BackColor As System.Drawing.Color Implements IElement_Text.BackColor

    Public Property FieldInCardData As String Implements IElement_Text.FieldInCardData

    Public Property FieldLabelCaption As String Implements IElement_Text.FieldLabelCaption

    ''7/25/2019 td''Prpoerty ExampleText As String ''Added 7/25/2019
    Public Property Text As String Implements IElement_Text.Text ''E.g. "George Washington" for FullName. 


    Public Property TextAlignment As System.Windows.Forms.HorizontalAlignment Implements IElement_Text.TextAlignment


    Public Property OrientationToLayout As String Implements IElement_Base.OrientationToLayout ''E.g. "L" (Landscape) (by far the most common) or "P" for Portrait  

    Public Property OrientationInDegrees As Integer Implements IElement_Base.OrientationInDegrees ''Default is 0, normal.  90 would be 1/4 turn clockwise.  180 is upside-down.  270 is the printing on the spine of a book sitting on the bookshelf.

    Public Property Image_BL As Image Implements IElement_Base.Image_BL ''Added 8/27/2019 td

    ''Moved below. 8/27/2019 td''Public Property SelectedHighlighting As Boolean Implements IElement_Base.SelectedHighlighting ''Added 8/2/2019 td  


    ''-------------------------------------------------------------
    ''-------------------------------------------------------------
    ''-------------------------------------------------------------

    Public Property FormControl As Control Implements IElement_Base.FormControl ''Added 7/19/2019  

    Public Property ElementType As String Implements IElement_Base.ElementType ''Text, Pic, or Logo

    Public Property LayoutWidth As Integer Implements IElement_Base.LayoutWidth_Pixels ''This provides sizing context & scaling factors. 

    Public Property TopEdge_Pixels As Integer Implements IElement_Base.TopEdge_Pixels
    Public Property LeftEdge_Pixels As Integer Implements IElement_Base.LeftEdge_Pixels

    Public Property Width_Pixels As Integer = 253 Implements IElement_Base.Width_Pixels
    Public Property Height_Pixels As Integer = 33 Implements IElement_Base.Height_Pixels

    ''8/29/2019 td''Public Property Border_Pixels As Integer Implements IElement_Base.Border_Pixels
    Public Property Border_WidthInPixels As Integer = 0 Implements IElement_Base.Border_WidthInPixels
    Public Property Border_Color As System.Drawing.Color = Color.Black Implements IElement_Base.Border_Color

    Public Property Back_Color As System.Drawing.Color Implements IElement_Base.Back_Color
    Public Property Back_Transparent As Boolean Implements IElement_Base.Back_Transparent ''Added 9/4/2019 thomas d. 

    Public Property SelectedHighlighting As Boolean Implements IElement_Base.SelectedHighlighting ''Added 8/2/2019 td  

    Private _labelToImage As New ClassLabelToImage ''Added 9/3/2019 td  

    Public Sub New(par_control As Control)

        ''Added 7/19/2019 td
        ''
        Me.FormControl = par_control

    End Sub

    Public Sub New()
        ''
        ''Added 7/29/2019 td
        ''

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
        Implements IElement_Text.GenerateImage_ByDesiredLayoutWidth
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

        obj_image = _labelToImage.TextImage(pintDesiredLayoutWidth, Me, Me, False)

        Return obj_image

    End Function ''End of "Public Function GenerateImage_ByDesiredLayoutWidth() As Image Implements IElementText.GenerateImage_ByDesiredLayoutWidth"

    Public Function GenerateImage_ByDesiredLayoutHeight(pintDesiredLayoutHeight As Integer) As Image _
        Implements IElement_Text.GenerateImage_ByDesiredLayoutHeight
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

        obj_image = _labelToImage.TextImage(intDesiredLayoutWidth, Me, Me, False)

        Return obj_image

    End Function ''End of "Public Function GenerateImage_ByDesiredLayoutWidth() As Image Implements IElementText.GenerateImage_ByDesiredLayoutWidth"

    Public Function GenerateImage_NotInUse(pintDesiredLayoutWidth As Integer, ByRef par_image As Image,
                                  par_elementInfo_Text As IElement_Text, par_elementInfo_Base As IElement_Base) As Image
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
            par_image = New Bitmap(intNewElementWidth, intNewElementHeight)

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
        If (0 < par_elementInfo_Base.Border_WidthInPixels) Then
            ''Added 9/03/2019 td
            gr.DrawRectangle(pen_border, New Rectangle(0, 0, intNewElementWidth, intNewElementHeight))
        End If ''End of "If (par_element.SelectedHighlighting) Then"

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

End Class
