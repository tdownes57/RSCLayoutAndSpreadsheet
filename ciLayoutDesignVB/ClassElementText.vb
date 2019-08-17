Option Explicit On
Option Strict On
Option Infer Off

''Added 7/18/2019 thomas downes
Imports ciBadgeInterfaces ''Added 8/14/2019 thomas d. 8/14/2019 td  
Imports System.Drawing.Text ''Added 

Public Class ClassElementText
    Implements IElement_Base, IElementText
    ''
    ''Added 7/18/2019 thomas downes
    ''
    ''
    ''7/29/2019 td''Public Property Info As IElementText
    ''
    ''-------------------------------------------------------------

    Public Property Font_DrawingClass As System.Drawing.Font Implements IElementText.Font_DrawingClass

    Public Property PositionalMode As String Implements IElement_Base.PositionalMode ''Added 8/14/2019 td 
    Public Property ExampleValue As String Implements IElementText.ExampleValue ''Added 8/14/2019 td 

    Public Property FontColor As System.Drawing.Color Implements IElementText.FontColor

    ''Added 8/12/2019 thomas downes  
    Public Property FontSize As Single Implements IElementText.FontSize ''Added 8/12/2019 thomas downes  
    Public Property FontBold As Boolean Implements IElementText.FontBold ''Added 8/12/2019 thomas downes  
    Public Property FontItalics As Boolean Implements IElementText.FontItalics ''Added 8/12/2019 thomas downes  
    Public Property FontUnderline As Boolean Implements IElementText.FontUnderline ''Added 8/12/2019 thomas downes  


    ''Added 8/15/2019 thomas downes  
    Public Property FontSize_IsLocked As Boolean Implements IElementText.FontSize_IsLocked ''Added 8/15/2019 thomas downes  
    Public Property FontOffset_X As Integer Implements IElementText.FontOffset_X ''Added 8/15/2019 thomas downes  
    Public Property FontOffset_Y As Integer Implements IElementText.FontOffset_Y ''Added 8/15/2019 thomas downes  


    Public Property BackColor As System.Drawing.Color Implements IElementText.BackColor

    Public Property FieldInCardData As String Implements IElementText.FieldInCardData

    Public Property FieldLabelCaption As String Implements IElementText.FieldLabelCaption

    ''7/25/2019 td''Prpoerty ExampleText As String ''Added 7/25/2019
    Public Property Text As String Implements IElementText.Text ''E.g. "George Washington" for FullName. 


    Public Property Alignment As System.Windows.Forms.HorizontalAlignment Implements IElementText.Alignment


    Public Property OrientationToLayout As String Implements IElementText.OrientationToLayout ''E.g. "L" (Landscape) (by far the most common) or "P" for Portrait  

    Public Property OrientationInDegrees As Integer Implements IElementText.OrientationInDegrees ''Default is 0, normal.  90 would be 1/4 turn clockwise.  180 is upside-down.  270 is the printing on the spine of a book sitting on the bookshelf.

    Public Property SelectedHighlighting As Boolean Implements IElement_Base.SelectedHighlighting ''Added 8/2/2019 td  


    ''-------------------------------------------------------------
    ''-------------------------------------------------------------
    ''-------------------------------------------------------------

    Public Property FormControl As Control Implements IElement_Base.FormControl ''Added 7/19/2019  

    Public Property ElementType As String Implements IElement_Base.ElementType ''Text, Pic, or Logo

    Public Property LayoutWidth As Integer Implements IElement_Base.LayoutWidth_Pixels ''This provides sizing context & scaling factors. 

    Public Property TopEdge_Pixels As Integer Implements IElement_Base.TopEdge_Pixels
    Public Property LeftEdge_Pixels As Integer Implements IElement_Base.LeftEdge_Pixels

    Public Property Width_Pixels As Integer Implements IElement_Base.Width_Pixels
    Public Property Height_Pixels As Integer Implements IElement_Base.Height_Pixels

    Public Property Border_Pixels As Integer Implements IElement_Base.Border_Pixels
    Public Property Border_Color As System.Drawing.Color Implements IElement_Base.Border_Color

    Public Property Back_Color As System.Drawing.Color Implements IElement_Base.Back_Color

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

    Public Function GenerateImage(pintLayoutHeight As Integer) As Image Implements IElementText.GenerateImage
        ''
        ''Added 8/14/2019 thomas downes 
        ''
        Dim obj_image As Image = Nothing

        ''8/15/2019 td''GenerateImage(obj_image, Me, Me)
        GenerateImage(pintLayoutHeight, obj_image, Me, Me)

        Return obj_image

    End Function ''End of "Public Function GenerateImage() As Image Implements IElementText.GenerateImage"

    Public Function GenerateImage(pintFinalLayoutWidth As Integer, ByRef par_image As Image,
                                  par_design As IElementText, par_element As IElement_Base) As Image
        ''
        ''Added 8/14 & 7/17/2019 thomas downes
        ''
        Dim gr As Graphics ''= Graphics.FromImage(img)
        Dim pen_backcolor As Pen
        Dim pen_highlighting As Pen ''Added 8/2/2019 thomas downes  
        Dim brush_forecolor As Brush
        Dim doubleW_div_H As Double ''Added 8/15/2019 td  
        Dim doubleScaling As Double ''Added 8/15/2019 td  
        Dim intNewElementWidth As Integer ''Added 8/15 
        Dim intNewElementHeight As Integer ''Added 8/15

        Application.DoEvents()

        ''Added 8/15/2019 td
        doubleW_div_H = (par_element.Width_Pixels / par_element.Height_Pixels)
        doubleScaling = (pintFinalLayoutWidth / par_element.LayoutWidth_Pixels)

        If (par_image Is Nothing) Then
            ''Create the image from scratch, if needed. 
            ''7/29 td''par_image = New Bitmap(par_element.Width_Pixels, par_element.Height_Pixels)

            ''Added 8/15/2019 td
            intNewElementWidth = CInt(doubleScaling * par_element.Width_Pixels)
            intNewElementHeight = CInt(doubleScaling * par_element.Height_Pixels)

            ''Added 8/15/2019 td
            par_image = New Bitmap(intNewElementWidth, intNewElementHeight)

        End If ''End of "If (par_image Is Nothing) Then"

        gr = Graphics.FromImage(par_image)

        pen_backcolor = New Pen(par_design.BackColor)
        pen_backcolor = New Pen(Color.White)
        ''8/5/2019 td''pen_highlighting = New Pen(Color.YellowGreen, 5)
        pen_highlighting = New Pen(Color.Yellow, 6)

        brush_forecolor = New SolidBrush(par_design.FontColor)

        ''
        ''Draw the select background color, so that hopefully the text can be read easily.
        ''
        ''7/30/2019 td''gr.DrawRectangle(Brushes.White....

        ''
        ''  https://stackoverflow.com/questions/5183856/converting-from-a-color-to-a-brush
        ''
        Using br_brush As SolidBrush = New SolidBrush(par_element.Back_Color)
            ''8/15 td''gr.FillRectangle(br_brush,
            ''             New Rectangle(0, 0, par_element.Width_Pixels, par_element.Height_Pixels))
            gr.FillRectangle(br_brush,
                         New Rectangle(0, 0, intNewElementWidth, intNewElementHeight))
        End Using

        ''
        ''Added 8/02/2019 td
        ''
        If (par_element.SelectedHighlighting) Then
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
        gr.DrawString(par_design.Text, par_design.Font_DrawingClass, Brushes.Black, 20, 5)

        Return par_image ''Return Nothing

    End Function ''End of "Public Function TextImage(par_label As Label) As Image"

End Class
