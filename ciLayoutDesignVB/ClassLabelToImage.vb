Option Explicit On ''Added 7/17/2019
Option Strict On ''Added 7/17/2019

''
''Added 7/17/2019
''
Imports System.Drawing.Image ''Added 7/17/2019
Imports System.Drawing.Text ''Added 7/30/2019
Imports System.Drawing ''Added 7/30/2019 td 
Imports ciBadgeInterfaces ''Added 8/14/2019 thomas d. 

Public Class ClassLabelToImage
    ''
    ''Added 7/17/2019
    ''
    Public Function TextImage(ByRef par_image As Image, par_design As IElementText, par_element As IElement_Base) As Image
        ''
        ''Added 7/17/2019 thomas downes
        ''
        Dim gr As Graphics ''= Graphics.FromImage(img)
        Dim pen_backcolor As Pen
        Dim pen_highlighting As Pen ''Added 8/2/2019 thomas downes  
        Dim brush_forecolor As Brush

        ''Added 8/17/2019 td
        Dim singleOffsetX As Integer = par_design.FontOffset_X
        Dim singleOffsetY As Integer = par_design.FontOffset_Y

        Application.DoEvents()

        If (par_image Is Nothing) Then
            ''Create the image from scratch, if needed. 
            ''7/29 td''par_image = New Bitmap(par_element.Width_Pixels, par_element.Height_Pixels)
            par_image = New Bitmap(par_element.Width_Pixels, par_element.Height_Pixels)
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
        Using br_brush = New SolidBrush(par_element.Back_Color)
            gr.FillRectangle(br_brush,
                         New Rectangle(0, 0, par_element.Width_Pixels, par_element.Height_Pixels))
        End Using

        ''
        ''Added 8/02/2019 td
        ''
        If (par_element.SelectedHighlighting) Then
            ''Added 8/2/2019 td
            ''8/5/2019 td''gr.DrawRectangle(pen_highlighting,
            ''             New Rectangle(0, 0, par_element.Width_Pixels, par_element.Height_Pixels))
            gr.DrawRectangle(pen_highlighting,
                         New Rectangle(3, 3, par_element.Width_Pixels - 6, par_element.Height_Pixels - 6))
        End If ''End of "If (par_element.SelectedHighlighting) Then"

        ''7/30/2019''gr.DrawString(par_design.Text, par_design.Font_DrawingClass, brush_forecolor, New Point(0, 0))

        ''Font TextFont = New Font("Times New Roman", 25, FontStyle.Italic);
        ''    e.Graphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
        ''    e.Graphics.DrawString("Sample Text", TextFont, Brushes.Black, 20, 20);
        ''    e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
        ''    e.Graphics.DrawString("Sample Text", TextFont, Brushes.Black, 20, 85);
        ''    e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        ''    e.Graphics.DrawString("Sample Text", TextFont, Brushes.Black, 20, 150);
        ''
        gr.TextRenderingHint = TextRenderingHint.AntiAliasGridFit
        Dim stringSize = New SizeF()

        ''Added 8/18/2019 td
        Select Case par_design.TextAlignment''Added 8/18/2019 td

            Case HorizontalAlignment.Left

                gr.DrawString(par_design.Text, par_design.Font_DrawingClass, Brushes.Black, singleOffsetX, singleOffsetY)

            Case HorizontalAlignment.Center
                ''// Measure string.
                stringSize = gr.MeasureString(par_design.Text, par_design.Font_DrawingClass)

                Dim singleOffsetX_AlignRight As Single ''Added 8/18/2019 td 
                ''Added 8/18/2019 td 
                singleOffsetX_AlignRight = (singleOffsetX + (par_image.Width - stringSize.Width) / 2)
                ''Added 8/18/2019 td 
                gr.DrawString(par_design.Text, par_design.Font_DrawingClass, Brushes.Black,
                              singleOffsetX_AlignRight, singleOffsetY)

            Case HorizontalAlignment.Right
                ''// Measure string.
                ''
                stringSize = gr.MeasureString(par_design.Text, par_design.Font_DrawingClass)

                Dim singleOffsetX_AlignRight As Single ''Added 8/18/2019 td 
                singleOffsetX_AlignRight = (par_image.Width - stringSize.Width - singleOffsetX)
                ''Added 8/18/2019 td 
                gr.DrawString(par_design.Text, par_design.Font_DrawingClass, Brushes.Black,
                              singleOffsetX_AlignRight, singleOffsetY)

        End Select ''End of "Select Case par_design.TextAlignment"

        Return par_image ''Return Nothing

    End Function ''End of "Public Function TextImage(par_label As Label) As Image"

    ''Private Sub ApplyTextToImage(ByRef par_image As Image)
    ''    ''
    ''    ''Added 5/7/2019 td  
    ''    ''
    ''    Dim gr As Graphics ''= Graphics.FromImage(img)
    ''    gr = Graphics.FromImage(par_image)

    ''    ''
    ''    ''Resizing Images in VB.NET
    ''    ''  https://stackoverflow.com/questions/2144592/resizing-images-in-vb-net
    ''    ''

    ''    ''gr.DrawString("Drawing text",
    ''    ''              New Font("Tahoma", 14),
    ''    ''              New SolidBrush(Color.Green),
    ''    ''              10, 10)

    ''    ''Draw white space so that the text can be read more easily. 
    ''    ApplyWhiteSpaceToImage(par_image, Me.LabelControlForID)

    ''    gr.DrawString("Person " & Me.RecipientID,
    ''                  New Font("Tahoma", Me.LabelControlForID.Font.SizeInPoints),
    ''                  New SolidBrush(Me.LabelControlForID.ForeColor),
    ''                   Me.LabelControlForID.Left, Me.LabelControlForID.Top)

    ''    ''Draw white space so that the text can be read more easily. 
    ''    ApplyWhiteSpaceToImage(par_image, LabelControlForName)

    ''    gr.DrawString(Me.RecipientName,
    ''                  New Font("Tahoma", Me.LabelControlForName.Font.SizeInPoints),
    ''                  New SolidBrush(Me.LabelControlForName.ForeColor),
    ''                   Me.LabelControlForName.Left, Me.LabelControlForName.Top)

    ''    gr.Dispose()

    ''End Sub ''End of ""Private Sub ApplyTextToImage(ByRef par_image As Image)

    ''Private Sub ApplyWhiteSpaceToImage(ByRef par_image As Image, ByVal par_textboxOrLabel As Control)
    ''    ''
    ''    ''Added 5/10/2019 td  
    ''    ''
    ''    ''    https://docs.microsoft.com/en-us/dotnet/api/system.drawing.graphics.drawimage?view=netframework-4.8
    ''    ''
    ''    Dim gr As Graphics ''= Graphics.FromImage(img)

    ''    ''Added 6/28/2019 td
    ''    Me.PictureOfPureWhite.BackColor = CType((New System.Drawing.ColorConverter()).ConvertFromString("#000000"), Color)

    ''    gr = Graphics.FromImage(par_image)

    ''    With par_textboxOrLabel
    ''        gr.DrawImage(Me.PictureOfPureWhite.Image, .Left, .Top, .Width, .Height)
    ''    End With

    ''    gr.Dispose()

    ''End Sub ''ENd of "Private Sub ApplyWhiteSpaceToImage(ByRef par_image As Image, ByRef par_textboxOrLabel As Control)"


    Public Function MakeImage_FromLabel(par_label As Label) As Image
        ''
        ''Added 7/17/2019 thomas downes
        ''




        Return Nothing

    End Function ''End of "Public Function MakeImage(par_label As Label) As Image"

End Class
