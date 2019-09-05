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
    Public Function TextImage(pintDesiredLayoutWidth As Integer,
                              par_elementInfo_Text As IElement_Text,
                              par_elementInfo_Base As IElement_Base,
                              ByRef pref_rotated As Boolean,
                              Optional par_pictureBox As PictureBox = Nothing,
                              Optional par_graphicalCtl As CtlGraphicFldLabel = Nothing) As Image
        ''
        ''Added 7/17/2019 thomas downes
        ''
        Dim local_image As Bitmap ''Added 9/4/2019 td  
        Dim gr_element As Graphics ''= Graphics.FromImage(img)
        Dim pen_backcolor As Pen
        Dim pen_highlighting As Pen ''Added 8/2/2019 thomas downes  
        Dim pen_border As Pen ''Added 9/3/2019 thomas downes  
        Dim brush_forecolor As Brush

        ''Added 8/17/2019 td
        Dim singleOffsetX As Integer = par_elementInfo_Text.FontOffset_X
        Dim singleOffsetY As Integer = par_elementInfo_Text.FontOffset_Y
        Dim intStarting_Width As Integer ''Added 8/19/2019 thomas 
        Dim intStarting_Height As Integer ''Added 8/19/2019 thomas

        ''Added 8/19/2019 td
        ''Moved downward. 9/3/2019 td''intStarting_Width = par_image.Width
        ''Moved downward. 9/3/2019 td''intStarting_Height = par_image.Height

        Application.DoEvents()

        ''Copied from ClassElementText.GenerateImage_NotInUse, 9/3/2019 thomas d. 
        Dim doubleW_div_H As Double ''Added 8/15/2019 td  
        Dim doubleScaling As Double ''Added 8/15/2019 td  
        Dim intNewElementWidth As Integer ''Added 8/15 
        Dim intNewElementHeight As Integer ''Added 8/15

        ''Added 9/4/2019 thomas d.
        Dim doub_LongToShort As Double ''Added 9/4/2019 thomas d.
        Dim boo_LikelyRatioIsMistaken As Boolean ''Added 9/4/2019 thomas d.
        doub_LongToShort = ciLayoutPrintLib.LayoutPrint.LongSideToShortRatio()

        ''
        ''Copied from ClassElementText.GenerateImage_NotInUse, 9/3/2019 & 8/15/2019 thomas d. 
        ''
        doubleW_div_H = (par_elementInfo_Base.Width_Pixels / par_elementInfo_Base.Height_Pixels)

        ''Added 9/4/2019 thomas downes
        boo_LikelyRatioIsMistaken = ciLayoutPrintLib.LayoutPrint.RatioIsLikelyBad(doubleW_div_H)

        ''8/24 td''doubleScaling = (pintFinalLayoutWidth / par_element.LayoutWidth_Pixels)
        doubleScaling = (pintDesiredLayoutWidth / par_elementInfo_Base.Width_Pixels)

        ''Added 8/15/2019 td
        intNewElementWidth = CInt(doubleScaling * par_elementInfo_Base.Width_Pixels)
        intNewElementHeight = CInt(doubleScaling * par_elementInfo_Base.Height_Pixels)

        ''Copied from ClassElementText.GenerateImage_NotInUse, 9/3/2019 & 8/15/2019 thomas d. 
        ''9/4/2019 td''If (par_image Is Nothing) Then
        ''
        ''Create the image from scratch, If needed. 
        ''
        ''7/29 td''par_image = New Bitmap(par_element.Width_Pixels, par_element.Height_Pixels)

        ''9/3/2019 td''par_image = New Bitmap(par_elementInfo_Base.Width_Pixels,
        ''9/3/2019 td''                       par_elementInfo_Base.Height_Pixels)

        ''Added 8/15/2019 td
        ''#1 9/4/2019 td''par_image = New Bitmap(intNewElementWidth, intNewElementHeight)
        '' #2 9/4/2019 td''par_image = New Bitmap(intNewElementWidth, intNewElementWidth, Imaging.PixelFormat.Format32bppPArgb)
        local_image = New Bitmap(intNewElementWidth, intNewElementHeight, Imaging.PixelFormat.Format32bppPArgb)

        ''Set the resolution to 300 DPI
        ''  https://stackoverflow.com/questions/2478502/when-creating-an-bitmap-image-from-scratch-in-vb-net-the-quality-stinks
        ''
        ''9/4/2019 td''par_image.SetResolution(300, 300)
        local_image.SetResolution(300, 300)

        ''9/4/2019 td''End If ''End of "If (par_image Is Nothing) Then"

        ''Moved here from above. ---9.3.2019 td 
        intStarting_Width = local_image.Width
        intStarting_Height = local_image.Height

        gr_element = Graphics.FromImage(local_image)

        With gr_element
            ''
            'Set various modes to higher quality
            ''  https://stackoverflow.com/questions/2478502/when-creating-an-bitmap-image-from-scratch-in-vb-net-the-quality-stinks
            ''
            .InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            .SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            .TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
        End With

        ''8/29/2019 td''pen_backcolor = New Pen(par_design.BackColor)
        pen_backcolor = New Pen(par_elementInfo_Base.Back_Color)

        ''Added 9/3/2019 td
        ''pen_border = New Pen(par_elementInfo_Base.Border_Color,
        ''     par_elementInfo_Base.Border_WidthInPixels)
        pen_border = New Pen(Color.Black,
                             par_elementInfo_Base.Border_WidthInPixels)

        ''8/28/2019 td''pen_backcolor = New Pen(Color.White)
        ''8/5/2019 td''pen_highlighting = New Pen(Color.YellowGreen, 5)
        pen_highlighting = New Pen(Color.Yellow, 6)

        brush_forecolor = New SolidBrush(par_elementInfo_Text.FontColor)

        ''
        ''Added 8/28/2019 td
        ''
        Dim boolClashOfColors As Boolean ''Added 8/28/2019 td
        Static s_boolRunOnce As Boolean ''Added 8/28/2019 td

        boolClashOfColors = (par_elementInfo_Base.Back_Color <>
                              par_elementInfo_Base.Back_Color)

        If (boolClashOfColors) Then
            If (Not s_boolRunOnce) Then
                ''Added 8/28/2019 td
                s_boolRunOnce = True
                ''Added 8/28/2019 td
                MessageBox.Show("A clash of colors--which Property is reliable?", "",
                     MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ''Added 8/29/2019 td
                DialogDisplayColor.ShowColor("par_design.BackColor", par_elementInfo_Base.Back_Color)

                ''8/29/2019 td''DialogDisplayColor.ShowColor("par_element.BackColor", par_elementInfo_Text.BackColor)

            End If ''eND OF "If (Not s_boolRunOnce) Then"
        End If ''Endof "If (boolClashOfColors) Then"

        ''
        ''Draw the select background color, so that hopefully the text can be read easily.
        ''
        ''7/30/2019 td''gr.DrawRectangle(Brushes.White....

        ''
        ''  https://stackoverflow.com/questions/5183856/converting-from-a-color-to-a-brush
        ''
        If (par_elementInfo_Base.Back_Transparent) Then
            ''
            ''Don't apply any background color. ----9/4/2019 thomas downes
            ''
        Else

            Using br_brush = New SolidBrush(par_elementInfo_Base.Back_Color)
                ''Major call.  
                ''----9/4 td---gr.FillRectangle(br_brush,
                ''           New Rectangle(0, 0, par_elementInfo_Base.Width_Pixels, par_elementInfo_Base.Height_Pixels))
                gr_element.FillRectangle(br_brush,
                             New Rectangle(0, 0, intNewElementWidth, intNewElementHeight))
            End Using

            ''
            '' https://stackoverflow.com/questions/2478502/when-creating-an-bitmap-image-from-scratch-in-vb-net-the-quality-stinks
            ''
            gr_element.Clear(par_elementInfo_Base.Back_Color) ''Added 9/4/2019 td 

        End If

        ''
        ''Added 9/03/2019 td
        ''
        ''   Draw the border about the element.  
        ''
        If (0 < par_elementInfo_Base.Border_WidthInPixels) Then
            ''Added 9/03/2019 td
            gr_element.DrawRectangle(pen_border, New Rectangle(3, 3, intNewElementWidth - 6, intNewElementHeight - 6))
        End If ''End of "If (par_element.SelectedHighlighting) Then"

        ''
        ''Added 8/02/2019 td
        ''
        If (par_elementInfo_Base.SelectedHighlighting) Then
            ''Added 8/2/2019 td
            ''8/5/2019 td''gr.DrawRectangle(pen_highlighting,
            ''       New Rectangle(0, 0, par_element.Width_Pixels, par_element.Height_Pixels))

            ''9/4/2019 td''gr.DrawRectangle(pen_highlighting,
            ''     New Rectangle(3, 3, par_elementInfo_Base.Width_Pixels - 6,
            ''     par_elementInfo_Base.Height_Pixels - 6))

            gr_element.DrawRectangle(pen_highlighting,
                         New Rectangle(3, 3, intNewElementWidth - 6,
                                             intNewElementHeight - 6))
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
        gr_element.TextRenderingHint = TextRenderingHint.AntiAliasGridFit
        Dim stringSize = New SizeF()

        With par_elementInfo_Text

            ''Added 8/18/2019 td
            Select Case par_elementInfo_Text.TextAlignment''Added 8/18/2019 td

                Case HorizontalAlignment.Left

                    gr_element.DrawString(.Text, .Font_DrawingClass, Brushes.Black, singleOffsetX, singleOffsetY)

                Case HorizontalAlignment.Center
                    ''// Measure string.
                    stringSize = gr_element.MeasureString(.Text, .Font_DrawingClass)

                    Dim singleOffsetX_AlignRight As Single ''Added 8/18/2019 td 
                    ''Added 8/18/2019 td 
                    singleOffsetX_AlignRight = (singleOffsetX + (local_image.Width - stringSize.Width) / 2)

                    ''Added 8/18/2019 td 
                    gr_element.DrawString(.Text, .Font_DrawingClass, Brushes.Black,
                                  singleOffsetX_AlignRight, singleOffsetY)

                Case HorizontalAlignment.Right
                    ''// Measure string.
                    ''
                    stringSize = gr_element.MeasureString(.Text, .Font_DrawingClass)

                    Dim singleOffsetX_AlignRight As Single ''Added 8/18/2019 td 
                    singleOffsetX_AlignRight = (local_image.Width - stringSize.Width - singleOffsetX)

                    ''Added 8/18/2019 td 
                    gr_element.DrawString(.Text, .Font_DrawingClass, Brushes.Black,
                                  singleOffsetX_AlignRight, singleOffsetY)

            End Select ''End of "Select Case par_design.TextAlignment"

        End With ''ENd of "With par_elementInfo_Text"

        ''
        ''Added 8/7/2019 thomas downes 
        ''
        ''8/18 td''image_Pic = picturePortrait.Image
        ''8/18 td''boolSeemsInPortraitMode = (image_Pic.Height > image_Pic.Width)
        ''8/18 td''boolLetsRotate90 = True ''boolSeemsInPortraitMode

        Dim boolLetsRotate90 As Boolean ''Added 8/18/2019 td 
        boolLetsRotate90 = False ''(par_design.OrientationInDegrees > 0)

        ''Added 8/7/2019 thomas downes 
        If (boolLetsRotate90) Then

            Dim intRotateIndex As Integer ''Added 8/18/2019 td  

            For intRotateIndex = 1 To CInt(par_elementInfo_Base.OrientationInDegrees / 90)

                pref_rotated = (Not pref_rotated) ''Added 8/18/2019 td 

                ''Added 8/7/2019 thomas downes 
                ''8/7 td''image_Rotated = CType(image_Pic.Clone, Image)

                ''8/18 td''image_Pic = picturePortrait.Image
                Dim bm_rotation As Bitmap
                bm_rotation = New Bitmap(local_image)
                bm_rotation.RotateFlip(RotateFlipType.Rotate90FlipNone)

                If (par_pictureBox IsNot Nothing) Then
                    ''
                    ''Added 8/19/2019 thomas downes
                    ''
                    par_pictureBox.Width = intStarting_Height ''Switching!! Height & Width are switched.
                    par_pictureBox.Height = intStarting_Width ''Switching!! Height & Width are switched.

                    par_graphicalCtl.Width = intStarting_Height ''Switching!!  Height & Width are switched. ---8/8/2019 td
                    par_graphicalCtl.Height = intStarting_Width ''Switching!!  Height & Width are switched. ---8/8/2019 td 

                    par_pictureBox.Refresh()

                    par_pictureBox.Image = bm_rotation
                    ''8/19/2019 td''par_pictureBox.SizeMode = PictureBoxSizeMode.Zoom
                    par_pictureBox.Refresh()

                    ''9/4/2019 td''local_image = par_pictureBox.Image
                    local_image = New Bitmap(par_pictureBox.Image)

                Else

                    local_image = bm_rotation

                End If ''End of "If (par_pictureBox IsNot Nothing) Then .... Else ...."

            Next intRotateIndex

        End If ''End of "If (boolLetsRotate90) Then"

        gr_element.Dispose() ''Added 9/4/2019 thomas downes

        ''#1 9/4/2019 td''Return par_image ''Return Nothing
        '' #2 9/4/2019 td''par_image = local_image

        Return local_image ''Return Nothing

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

    Private Sub ApplyWhiteSpaceToImage(ByRef par_image As Image, ByVal par_textboxOrLabel As Control)
        ''
        ''Added 5/10/2019 td  
        ''
        ''    https://docs.microsoft.com/en-us/dotnet/api/system.drawing.graphics.drawimage?view=netframework-4.8
        ''
        Dim gr As Graphics ''= Graphics.FromImage(img)

        ''Added 6/28/2019 td
        ''9/4/2019 td''Me.PictureOfPureWhite.BackColor = CType((New System.Drawing.ColorConverter()).ConvertFromString("#000000"), Color)

        gr = Graphics.FromImage(par_image)

        With par_textboxOrLabel
            ''9/4/2019 td''gr.DrawImage(Me.PictureOfPureWhite.Image, .Left, .Top, .Width, .Height)
        End With

        gr.Clear(Color.White) '' https://stackoverflow.com/questions/2478502/when-creating-an-bitmap-image-from-scratch-in-vb-net-the-quality-stinks

        gr.Dispose()

    End Sub ''ENd of "Private Sub ApplyWhiteSpaceToImage(ByRef par_image As Image, ByRef par_textboxOrLabel As Control)"


    Public Function MakeImage_FromLabel(par_label As Label) As Image
        ''
        ''Added 7/17/2019 thomas downes
        ''




        Return Nothing

    End Function ''End of "Public Function MakeImage(par_label As Label) As Image"

End Class
