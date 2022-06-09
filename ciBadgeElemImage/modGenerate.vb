Option Explicit On ''Added 9/19/2019 thomas d
Option Strict On ''Added 9/19/2019 thomas d
''
''Added 9/19/2019 thomas d
''
Imports System.Drawing ''Added 9/19/2019 thomas d
Imports System.Drawing.Text ''Added 9/19/2019 thomas d
Imports System.Windows.Forms ''Only for Horizontal Alignment.  ----9/19/2019 td
Imports ciBadgeInterfaces ''Added 9/19/2019 thomas d
Imports ciBadgeLayouts_NoElems ''Added 9/19/2019 thomas d

Public Module modGenerate
    ''
    ''Added 9/19/2019 thomas d
    ''
    Public Function GenerateImage_ByDesiredLayoutWidth_Deprecated(pintDesiredLayoutWidth As Integer) As Image




    End Function


    Public Function TextImage_ByElemInfo(par_Text As String,
                                         pintDesiredLayoutWidth As Integer,
                           par_elementInfo_TextFld As IElement_TextOnly,
                           par_elementInfo_Base As IElement_Base,
                           ByRef pref_rotated As Boolean,
                           ByVal par_bIsDesignStage As Boolean) As Image
        ''9/19/2019 TD                   Optional par_pictureBox As PictureBox = Nothing,
        ''9/19/2019 TD                   Optional par_graphicalCtl As CtlGraphicFldLabel = Nothing) As Image
        ''
        ''Added 9/19/2019 & 7/17/2019 thomas downes
        ''
        ''  This is a refactoring-copy of the following:
        '' 
        ''        vbLayoutDesignVB, ClassLabelToImage
        ''            Public Function TextImage_Field(pintDesiredLayoutWidth As Integer,
        ''                              par_elementInfo_TextFld As IElement_TextField,
        ''                              par_elementInfo_Base As IElement_Base,
        ''                              ByRef pref_rotated As Boolean,
        ''                              ByVal par_bIsDesignStage As Boolean,
        ''                              Optional par_pictureBox As PictureBox = Nothing,
        ''                              Optional par_graphicalCtl As CtlGraphicFldLabel = Nothing) As Image
        ''
        ''
        Dim local_image As Bitmap ''Added 9/4/2019 td  
        Dim gr_element As Graphics ''= Graphics.FromImage(img)
        Dim pen_backcolor As Pen
        Dim pen_highlighting As Pen ''Added 8/2/2019 thomas downes  
        Dim pen_border As Pen ''Added 9/3/2019 thomas downes  
        Dim brush_forecolor As Brush

        ''Added 8/17/2019 td
        Dim singleOffsetX As Integer = par_elementInfo_TextFld.FontOffset_X
        Dim singleOffsetY As Integer = par_elementInfo_TextFld.FontOffset_Y
        Dim intStarting_Width As Integer ''Added 8/19/2019 thomas 
        Dim intStarting_Height As Integer ''Added 8/19/2019 thomas

        ''Added 8/19/2019 td
        ''Moved downward. 9/3/2019 td''intStarting_Width = par_image.Width
        ''Moved downward. 9/3/2019 td''intStarting_Height = par_image.Height

        ''9/19/2019 td''Application.DoEvents()

        ''Copied from ClassElementText.GenerateImage_NotInUse, 9/3/2019 thomas d. 
        Dim doubleW_div_H As Double ''Added 8/15/2019 td  
        Dim doubleScaling As Double ''Added 8/15/2019 td  
        Dim intNewElementWidth As Integer ''Added 8/15 
        Dim intNewElementHeight As Integer ''Added 8/15

        ''Added 9/4/2019 thomas d.
        Dim doub_LongToShort As Double ''Added 9/4/2019 thomas d.
        Dim boo_LikelyRatioIsMistaken As Boolean ''Added 9/4/2019 thomas d.

        ''9/19/2019 td''doub_LongToShort = ciLayoutPrintLib.LayoutPrint.LongSideToShortRatio()
        doub_LongToShort = modLayFunctions.LongSideToShortRatio()

        ''
        ''Copied from ClassElementText.GenerateImage_NotInUse, 9/3/2019 & 8/15/2019 thomas d. 
        ''
        ''Added 11/24/2021 td
        If (0 = par_elementInfo_Base.Height_Pixels) Then Throw New Exception("Division by 0 (par_elementInfo_Base.Height_Pixels)")

        doubleW_div_H = (par_elementInfo_Base.Width_Pixels / par_elementInfo_Base.Height_Pixels)

        ''Added 9/4/2019 thomas downes
        ''9/19/2019 td''boo_LikelyRatioIsMistaken = ciLayoutPrintLib.LayoutPrint.RatioIsLikelyBad(doubleW_div_H)
        boo_LikelyRatioIsMistaken = modLayFunctions.RatioIsLikelyBad(doubleW_div_H)

        ''8/24 td''doubleScaling = (pintFinalLayoutWidth / par_element.LayoutWidth_Pixels)
        ''9/5/2019 td''doubleScaling = (pintDesiredLayoutWidth / par_elementInfo_Base.Width_Pixels)
        ''9/11/2019 td''doubleScaling = (pintDesiredLayoutWidth / par_elementInfo_Base.LayoutWidth_Pixels)

        ''Added 11/24/2021 td
        If (0 = par_elementInfo_Base.BadgeLayout.Width_Pixels) Then Throw New Exception("Division by 0 (par_elementInfo_Base.BadgeLayout.Width_Pixels)")

        doubleScaling = (pintDesiredLayoutWidth / par_elementInfo_Base.BadgeLayout.Width_Pixels)

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
        '' #2 9/4/20 19 td''par_image = New Bitmap(intNewElementWidth, intNewElementWidth, Imaging.PixelFormat.Format32bppPArgb)
        ''  #3 9/4/2019 td''local_image = New Bitmap(intNewElementWidth, intNewElementWidth, Imaging.PixelFormat.Format32bppPArgb)

        ''
        ''  https://stackoverflow.com/questions/2478502/when-creating-an-bitmap-image-from-scratch-in-vb-net-the-quality-stinks
        ''
        Const c_UseHighResolutionTips As Boolean = True ''False ''Hasn't been tested yet. ----Added 9/19/2019 td

        If (c_UseHighResolutionTips) Then

            local_image = New Bitmap(intNewElementWidth, intNewElementHeight,
                                     Imaging.PixelFormat.Format32bppPArgb)

            ''Set the resolution to 300 DPI
            ''  https://stackoverflow.com/questions/2478502/when-creating-an-bitmap-image-from-scratch-in-vb-net-the-quality-stinks
            ''
            ''9/4/2019 td''par_image.SetResolution(300, 300)
            If (False) Then local_image.SetResolution(300, 300)

        Else
            local_image = New Bitmap(intNewElementWidth, intNewElementHeight)

        End If ''End of "If (c_UseHighResolutionTips) Then ... Else ..."

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

        brush_forecolor = New SolidBrush(par_elementInfo_TextFld.FontColor)

        ''
        ''Added 8/28/2019 td
        ''
        ''---*----Obselete. 9/19/2019 td
        ''---*--Dim boolClashOfColors As Boolean ''Added 8/28/2019 td
        ''---*--Static s_boolRunOnce As Boolean ''Added 8/28/2019 td
        ''
        ''---*--boolClashOfColors = (par_elementInfo_Base.Back_Color <>
        ''                      par_elementInfo_Base.Back_Color)
        ''
        ''---*--If (boolClashOfColors) Then
        ''    If (Not s_boolRunOnce) Then
        ''        ''Added 8/28/2019 td
        ''        s_boolRunOnce = True
        ''        ''Added 8/28/2019 td
        ''        MessageBox.Show("A clash of colors--which Property is reliable?", "",
        ''             MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ''        ''Added 8/29/2019 td
        ''        DialogDisplayColor.ShowColor("par_design.BackColor", par_elementInfo_Base.Back_Color)
        ''
        ''        ''8/29/2019 td''DialogDisplayColor.ShowColor("par_element.BackColor", par_elementInfo_Text.BackColor)
        ''
        ''    End If ''eND OF "If (Not s_boolRunOnce) Then"
        ''End If ''Endof "If (boolClashOfColors) Then"

        ''
        ''Draw the select background color, so that hopefully the text can be read easily.
        ''
        ''7/30/2019 td''gr.DrawRectangle(Brushes.White....

        ''
        ''  https://stackoverflow.com/questions/5183856/converting-from-a-color-to-a-brush
        ''
        Dim boolSuppressBackColor As Boolean ''Added 9/8/2019
        boolSuppressBackColor = (par_elementInfo_Base.Back_Transparent)

        If (boolSuppressBackColor) Then
            ''
            ''The Transparent flag is True, so don't apply
            ''  any background color. ----9/4/2019 thomas downes
            ''
        Else

            Using br_brush = New SolidBrush(par_elementInfo_Base.Back_Color)
                ''Major call.  
                ''----#1 9/4 td---gr.FillRectangle(br_brush,
                ''           New Rectangle(0, 0, par_elementInfo_Base.Width_Pixels, par_elementInfo_Base.Height_Pixels))
                ''---- #2 9/4 td---gr_element.FillRectangle(br_brush,
                ''             New Rectangle(0, 0, intNewElementWidth, intNewElementHeight))
            End Using

            ''
            '' https://stackoverflow.com/questions/2478502/when-creating-an-bitmap-image-from-scratch-in-vb-net-the-quality-stinks
            ''
            gr_element.Clear(par_elementInfo_Base.Back_Color) ''Added 9/4/2019 td 

        End If ''End of "If (boolSuppressBackColor) Then ... Else ...."

        ''
        ''Added 9/03/2019 td
        ''
        ''   Draw the border about the element.  
        ''
        Dim boolNonzeroBorder As Boolean ''9/9 td
        If (par_elementInfo_Base.Border_Displayed) Then
            boolNonzeroBorder = (0 < par_elementInfo_Base.Border_WidthInPixels)
            If (boolNonzeroBorder) Then
                ''
                ''Added 9/03/2019 td
                ''
                ''9/6/2019 td''gr_element.DrawRectangle(pen_border, New Rectangle(3, 3, intNewElementWidth - 6, intNewElementHeight - 6))
                DrawBorder_PixelsWide(par_elementInfo_Base.Border_WidthInPixels,
                                      gr_element, intNewElementWidth, intNewElementHeight,
                                      par_elementInfo_Base.Border_Color)

            End If ''End of "If (boolNonzeroBorder) Then"
        End If ''End of "If (par_elementInfo_Base.Border_Displayed) Then"

        ''
        ''Added 8/02/2019 td
        ''
        Dim boolAddHighlighting As Boolean ''Added 9/8/2019 td

        ''Added 9/8/2019 td
        If (par_elementInfo_Base.SelectedHighlighting) Then
            ''
            ''The conditional expression above Is redundant, 
            ''   but the programmer might want to put a 
            ''   breakpoint below. ----9/8/2019 td
            ''
            boolAddHighlighting = (par_bIsDesignStage And
                par_elementInfo_Base.SelectedHighlighting)

        End If ''End of "If (par_elementInfo_Base.SelectedHighlighting) Then"

        If (boolAddHighlighting) Then
            ''Added 8/2/2019 td
            ''8/5/2019 td''gr.DrawRectangle(pen_highlighting,
            ''       New Rectangle(0, 0, par_element.Width_Pixels, par_element.Height_Pixels))

            ''9/4/2019 td''gr.DrawRectangle(pen_highlighting,
            ''     New Rectangle(3, 3, par_elementInfo_Base.Width_Pixels - 6,
            ''     par_elementInfo_Base.Height_Pixels - 6))

            gr_element.DrawRectangle(pen_highlighting,
                         New Rectangle(3, 3, intNewElementWidth - 6,
                                             intNewElementHeight - 6))

        End If ''End of "If (boolHighlighting) Then"

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
        Dim font_scaled As System.Drawing.Font ''Added 9/8/2019 td

        With par_elementInfo_TextFld

            ''Added 11/24/2021 thomas downes
            '']]]If (.FontSize_Pixels < 5) Then .FontSize_Pixels = 7 ''Throw New Exception("Font Size is less than 10. Hard to read.")
            ''//If (.FontSize_Pixels < 5) Then Throw New Exception("Font Size is less than 10. Hard to read.")

            ''Added 9/15/2019 thomas d.
            If (.FontFamilyName Is Nothing) Then
                ''Added 9/15/2019 thomas d.
                System.Diagnostics.Debugger.Break()
            End If ''End of "If (.FontFamilyName Is Nothing) Then"

            ''Added 9/15/2019 td
            ''6/2022  If (.Font_DrawingClass Is Nothing) Then
            If (.FontDrawingClass Is Nothing) Then
                ''Added 9/15/2019 td
                ''6/07/2022 .Font_DrawingClass = modFonts.MakeFont(.FontFamilyName, .FontSize_Pixels, .FontBold, .FontItalics, .FontUnderline)
                .FontDrawingClass = .FontMaxGalkin.ToFont_AnyUnits()

            Else
                Dim bRegenerateFontObjectClass As Boolean ''Added 9/23/2019 td 
                ''6/2022 bRegenerateFontObjectClass = (CInt(.Font_DrawingClass.Size) <> .FontSize_Pixels) ''Added 9/23/2019 td 
                bRegenerateFontObjectClass = (CInt(.FontDrawingClass.Size) <> .FontSize_Pixels) ''Added 9/23/2019 td 
                If (bRegenerateFontObjectClass) Then ''Added 9/23/2019 td 
                    ''Added 9/23/2019 td 
                    .FontDrawingClass = modFonts.SetFontSize_Pixels(.FontDrawingClass, .FontSize_Pixels)
                End If ''End of '"If (bRegenerateFont) Then .... ElseIf ...."
            End If ''End of '"If (.Font_DrawingClass Is Nothing) Then .... ElseIf ...."

            ''Added 9/8/2019 td
            ''6/2022 font_scaled = modFonts.ScaledFont(.Font_DrawingClass, doubleScaling)
            font_scaled = modFonts.ScaledFont(.FontDrawingClass, doubleScaling)

            ''Added 8/18/2019 td
            Select Case par_elementInfo_TextFld.TextAlignment''Added 8/18/2019 td

                Case HorizontalAlignment.Left

                    ''9/8/2019 td''gr_element.DrawString(.Text, .Font_DrawingClass, Brushes.Black, singleOffsetX, singleOffsetY)
                    gr_element.DrawString(par_Text, font_scaled, Brushes.Black,
                                          singleOffsetX, singleOffsetY)

                Case HorizontalAlignment.Center
                    ''// Measure string.
                    ''9/8/2019 td''stringSize = gr_element.MeasureString(.Text, .Font_DrawingClass)
                    stringSize = gr_element.MeasureString(par_Text, font_scaled)

                    Dim singleOffsetX_AlignRight As Single ''Added 8/18/2019 td 
                    ''Added 8/18/2019 td 
                    singleOffsetX_AlignRight = (singleOffsetX + (local_image.Width - stringSize.Width) / 2)

                    ''Added 8/18/2019 td
                    ''
                    ''9/8/2019 td''gr_element.DrawString(.Text, .Font_DrawingClass, Brushes.Black,
                    ''                            singleOffsetX_AlignRight, singleOffsetY)
                    gr_element.DrawString(par_Text, font_scaled, Brushes.Black,
                                  singleOffsetX_AlignRight, singleOffsetY)

                Case HorizontalAlignment.Right
                    ''// Measure string.
                    ''
                    ''9/8/2019 td''stringSize = gr_element.MeasureString(.Text, .Font_DrawingClass)
                    stringSize = gr_element.MeasureString(par_Text, font_scaled)

                    Dim singleOffsetX_AlignRight As Single ''Added 8/18/2019 td 
                    singleOffsetX_AlignRight = (local_image.Width - stringSize.Width - singleOffsetX)

                    ''Added 8/18/2019 td 
                    ''9/8/2019 td''gr_element.DrawString(.Text, .Font_DrawingClass, Brushes.Black,
                    ''                           singleOffsetX_AlignRight, singleOffsetY)
                    gr_element.DrawString(par_Text, font_scaled, Brushes.Black,
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
        boolLetsRotate90 = (par_elementInfo_Base.OrientationInDegrees > 0)

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

                local_image = bm_rotation

                ''Denigrated. ---9/19/2019 td''If (par_pictureBox IsNot Nothing) Then
                ''    ''
                ''    ''Added 8/19/2019 thomas downes
                ''    ''
                ''    par_pictureBox.Width = intStarting_Height ''Switching!! Height & Width are switched.
                ''    par_pictureBox.Height = intStarting_Width ''Switching!! Height & Width are switched.

                ''    par_graphicalCtl.Width = intStarting_Height ''Switching!!  Height & Width are switched. ---8/8/2019 td
                ''    par_graphicalCtl.Height = intStarting_Width ''Switching!!  Height & Width are switched. ---8/8/2019 td 

                ''    par_pictureBox.Refresh()

                ''    par_pictureBox.Image = bm_rotation
                ''    ''8/19/2019 td''par_pictureBox.SizeMode = PictureBoxSizeMode.Zoom
                ''    par_pictureBox.Refresh()

                ''    ''9/4/2019 td''local_image = par_pictureBox.Image
                ''    local_image = New Bitmap(par_pictureBox.Image)

                ''Else

                ''    local_image = bm_rotation

                ''End If ''End of "If (par_pictureBox IsNot Nothing) Then .... Else ...."

            Next intRotateIndex

        End If ''End of "If (boolLetsRotate90) Then"

        gr_element.Dispose() ''Added 9/4/2019 thomas downes

        ''#1 9/4/2019 td''Return par_image ''Return Nothing
        '' #2 9/4/2019 td''par_image = local_image

        Return local_image ''Return Nothing

    End Function ''End of "Public Function TextImage_ByElemInfo(par_label As Label) As Image"




    Public Function PortraitImage_ByElement(par_element As ciBadgeElements.ClassElementPortrait, par_image As Image) As Image
        ''--Jan22 2022--Public Function PicImage_ByElement
        ''
        ''Added 9/22/2019 thomas d 
        ''
        ''7/31/2019 td'If (String.IsNullOrEmpty(Me.ElementInfo.Text)) Then ElementInfo.Text = LabelText()

        ''7/31/2019 td'If (Me.ElementInfo.Font_DrawingClass Is Nothing) Then 
        ''7/31/2019 td'   Me.ElementInfo.Font_DrawingClass = New Font("Times New Roman", 15, FontStyle.Regular)
        ''7/31/2019 td''End If ''End of "If (Me.ElementInfo.Font_DrawingClass Is Nothing) Then "

        ''7/31/2019 td''If (Generator Is Nothing) Then Generator = New ClassLabelToImage

        ''7/31/2019 td''Generator.TextImage(pictureLabel.Image, Me.ElementInfo, Me.ElementInfo)

        ''
        ''Added 8/7/2019 thomas downes 
        ''
        Dim image_Pic As Image ''Added 8/7/2019 thomas downes 
        ''Dim image_Rotated As Image ''Added 8/7/2019 thomas downes  
        Dim bm_rotation As Bitmap ''Added 8/7/2019 thomas downes 
        Dim bm_resized As Bitmap ''Added 9/23/2019 thomas downes 

        Dim boolSeemsInPortraitMode As Boolean
        Dim boolLetsRotate90 As Boolean
        Dim intStarting_Width As Integer ''Added 8/8/2019 thomas 
        Dim intStarting_Height As Integer ''Added 8/8/2019 thomas

        ''---intStarting_Width = picturePortrait.Width
        ''--intStarting_Height = picturePortrait.Height

        image_Pic = par_image

        ''
        ''
        ''Step 1 of 2.   Rotating.  
        ''
        ''
        intStarting_Width = par_element.Width_Pixels
        intStarting_Height = par_element.Height_Pixels

        ''9/2/2019''Select Case Me.ElementInfo_Pic.OrientationToLayout
        Select Case par_element.OrientationToLayout
            Case "H", "L", "P", "", " " '' H = Horizontal, P = Portrait     
                ''
                ''Added 8/7/2019 thomas downes 
                ''
                image_Pic = par_image
                boolSeemsInPortraitMode = (image_Pic.Height > image_Pic.Width)
                boolLetsRotate90 = True ''boolSeemsInPortraitMode
                boolLetsRotate90 = (par_element.OrientationInDegrees > 0)

                ''Added 8/7/2019 thomas downes 
                If (boolLetsRotate90) Then

                    Dim intRotateIndex As Integer ''Added 8/18/2019 td  

                    bm_rotation = New Bitmap(image_Pic)

                    For intRotateIndex = 1 To CInt(par_element.OrientationInDegrees / 90)

                        ''Added 8/7/2019 thomas downes 
                        ''8/7 td''image_Rotated = CType(image_Pic.Clone, Image)

                        ''9/22/2019 td''bm_rotation = New Bitmap(image_Pic)
                        bm_rotation.RotateFlip(RotateFlipType.Rotate90FlipNone)

                        ''8/7 td''picturePortrait.Image = image_Rotated

                        ''8/7 td''picturePortrait.Width = image_Rotated.Width
                        ''8/7 td''picturePortrait.Height = image_Rotated.Height

                        ''8/8 td''picturePortrait.Width = bm_rotation.Width
                        ''8/8 td''picturePortrait.Height = bm_rotation.Height

                        ''picturePortrait.Width = intStarting_Height ''Switching!! Height & Width are switched.
                        ''picturePortrait.Height = intStarting_Width ''Switching!! Height & Width are switched.

                        ''Me.Width = intStarting_Height ''Switching!!  Height & Width are switched. ---8/8/2019 td
                        ''Me.Height = intStarting_Width ''Switching!!  Height & Width are switched. ---8/8/2019 td 

                        ''picturePortrait.Refresh()

                        ''picturePortrait.Image = bm_rotation
                        ''picturePortrait.SizeMode = PictureBoxSizeMode.Zoom
                        ''picturePortrait.Refresh()

                        ''8/7 td''Me.Width = image_Rotated.Width
                        ''8/7 td'' Me.Height = image_Rotated.Height

                        ''8/7 td'' Me.Width = picturePortrait.Width
                        ''8/7 td'' Me.Height = picturePortrait.Height

                    Next intRotateIndex

                    ''
                    ''Added 9/23/2019 td 
                    ''
                    image_Pic = bm_rotation

                End If ''End of "If (boolLetsRotate90) Then"

            Case "n/a" '' "P" ----Anything can be rotated by the program code above.  The operations are exactly the same !!
                ''
                ''Added 8/7/2019 thomas downes 
                ''

        End Select ''End of "Select Case Me.ElementInfo_Pic.OrientationToLayout "

        ''
        ''
        ''Step 2 of 2.   Resizing.  
        ''
        ''
        intStarting_Width = par_element.Width_Pixels
        intStarting_Height = par_element.Height_Pixels

        ''---bm_resized = image_Pic

        ''
        ''Let's postpone this step's programming (Step 2 of 2.  Resizing). 
        ''

        Return image_Pic ''---bm_resized

    End Function ''End of Public Sub PicImage_ByElement


    Private Sub DrawBorder_PixelsWide(par_WidthInPixels As Integer, par_gr As Graphics, par_intWidth As Integer, par_intHeight As Integer, par_color As Color)
        ''
        ''Added 9/6/2019 td  
        ''
        Dim pen_border As System.Drawing.Pen
        Dim intLineIndex As Integer
        Dim intOffsetPixels As Integer

        For intLineIndex = 1 To (par_WidthInPixels)

            pen_border = New Pen(par_color, 1)

            intOffsetPixels = (intLineIndex - 1)

            par_gr.DrawRectangle(pen_border, New Rectangle(intOffsetPixels, intOffsetPixels,
                                                           -1 + par_intWidth - 2 * intOffsetPixels,
                                                           -1 + par_intHeight - 2 * intOffsetPixels))

        Next intLineIndex

    End Sub ''end of "Private Sub DrawBorder_PixelsWide(par_elementInfo_Base.Border_WidthInPixels, gr_element, intNewElementWidth, intNewElementHeight)"

End Module
