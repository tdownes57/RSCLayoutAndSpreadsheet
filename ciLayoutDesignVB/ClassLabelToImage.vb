Option Explicit On ''Added 7/17/2019
Option Strict On ''Added 7/17/2019

''
''Added 7/17/2019
''
Imports System.Drawing.Image ''Added 7/17/2019
Imports System.Drawing.Text ''Added 7/30/2019
Imports System.Drawing ''Added 7/30/2019 td 
Imports ciBadgeInterfaces ''Added 8/14/2019 thomas d. 
Imports ciBadgeDesigner ''Added 10/3/2019 td  

Public Enum EnumImageOrControl
    Undetermined
    Image
    Contl
End Enum

Public Class ClassLabelToImage
    ''
    ''Added 7/17/2019
    ''
    Public Shared UseHighResolutionTips As Boolean = False ''Added 9/8/2019 td

    Public Shared Function LongSideToShortRatio() As Double
        ''
        ''Added 8/26/2019 thomas downes
        ''
        ''The website 
        ''   https://tinyurl.com/yyqyosz3    
        ''    (  https://www.identicard.com/store/id-card-and-credentials/standard-id-cards/pvc-and-composite-id-cards-for-custom-id-badges ) 
        ''
        ''says
        ''
        ''    We offer PVC cards in several different sizes and thickness levels, but the most common PVC ID card size
        ''       is CR80/credit card size (2.13" x 3.38").
        ''
        ''My measurements of the PVC card on my desk is:
        ''
        ''       2 1/8 inches by 3 3/8 inches, 
        ''
        ''      or  17/8 inches by  27/8 inches
        ''
        '' and so leads me to the ratio of 27 to 17.  
        ''
        ''   ------8/26/2019 td 
        ''
        Return (27 / 17) ''Approx. 1.588, or  3.38 / 2.13 

    End Function ''eDN OF "Public Shared Function LongSideToShortRatio() As Double"

    Public Shared Function RatioIsLikelyBad(par_doubleW_div_H As Double) As Boolean
        ''
        ''Added 9/4/2019 thomas downes  
        ''
        Dim doubleExpectedRatio As Double ''Added 9/6/2019 td  
        Dim doubleDifference As Double ''Added 9/8/2019 td
        Dim doubleDifference_x100 As Double ''Added 9/8/2019 td

        ''---9/6/2019 td ''RatioIsLikelyBad = (1 > (100 * Math.Abs(par_doubleW_div_H - LongSideToShortRatio())))

        ''Added 9/6/2019 td  
        doubleExpectedRatio = LongSideToShortRatio()

        ''9/6/2019 td''RatioIsLikelyBad = (1 > (100 * Math.Abs(par_doubleW_div_H - doubleExpectedRatio)))
        ''9/8/2019 td''RatioIsLikelyBad = (1 < (100 * Math.Abs(par_doubleW_div_H - doubleExpectedRatio)))

        doubleDifference = Math.Abs(par_doubleW_div_H - doubleExpectedRatio)
        doubleDifference_x100 = (100 * doubleDifference)

        Dim boolDiffersMoreThanPoint99 As Boolean
        Dim boolReturnValue As Boolean

        boolDiffersMoreThanPoint99 = (0.99 < doubleDifference_x100)
        boolReturnValue = boolDiffersMoreThanPoint99
        Return boolReturnValue

    End Function ''End of "Public Shared Function RatioIsLikelyBad(par_doubleW_div_H As Double) As Boolean"

    Public Shared Function ProportionsAreSlightlyOff(par_control As Control, pboolVerbose As Boolean) As Boolean
        ''
        ''Added 9/5/2019 thomas downes  
        ''
        Dim doubleW_div_H As Double

        doubleW_div_H = (par_control.Width / par_control.Height)

        ''9/6 td''Return ProportionsAreSlightlyOff(doubleW_div_H, pboolVerbose, par_control.Name)
        Return ProportionsAreSlightlyOff(doubleW_div_H, pboolVerbose, EnumImageOrControl.Contl, par_control.Name)

    End Function ''End of "Public Shared Function RatioIsLikelyBad(par_doubleW_div_H As Double) As Boolean"

    Public Shared Function ProportionsAreSlightlyOff(par_image As Image, pboolVerbose As Boolean,
                                                     Optional par_strNameOfImage As String = "") As Boolean
        ''
        ''Added 9/5/2019 thomas downes  
        ''
        Dim doubleW_div_H As Double

        doubleW_div_H = (par_image.Width / par_image.Height)

        ''9/6 td''Return ProportionsAreSlightlyOff(doubleW_div_H, pboolVerbose, par_strNameOfImage)
        Return ProportionsAreSlightlyOff(doubleW_div_H, pboolVerbose, EnumImageOrControl.Image, par_strNameOfImage)

    End Function ''End of "Public Shared Function RatioIsLikelyBad(par_doubleW_div_H As Double) As Boolean"

    Public Shared Function ProportionsAreSlightlyOff(par_doubleW_div_H As Double, pboolVerbose As Boolean,
                                                     Optional par_enum As EnumImageOrControl = EnumImageOrControl.Undetermined,
                                                     Optional par_strImageOrControl As String = "") As Boolean
        ''
        ''Added 9/5/2019 thomas downes  
        ''
        Dim strRatioCurrent As String ''Double
        Dim strRatioDesired As String ''Double
        ''Dim doubleW_div_H As Double
        Dim boolRatioIsBad As Boolean
        Dim strObjectType As String = ""

        boolRatioIsBad = RatioIsLikelyBad(par_doubleW_div_H)

        Select Case par_enum
            Case EnumImageOrControl.Image : strObjectType = "(image)"
            Case EnumImageOrControl.Contl : strObjectType = "(control)"
        End Select

        If (pboolVerbose And boolRatioIsBad) Then
            ''Added 9/6/2019 Thomasd.
            strRatioDesired = LongSideToShortRatio().ToString("0.00")
            strRatioCurrent = par_doubleW_div_H.ToString("0.00")
            MessageBox.Show($"Uh-oh, the proportions of {strObjectType} [{par_strImageOrControl}] are {strRatioCurrent} instead of {strRatioDesired}.", "",
                                               MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If ''End of "If (pboolVerbose) Then"

        Return boolRatioIsBad

    End Function ''End of "Public Shared Function RatioIsLikelyBad(par_doubleW_div_H As Double) As Boolean"

    Public Shared Sub Proportions_FixTheWidth(par_control As Control)
        ''
        ''Added 9/5/2019 thomas downes  
        ''
        par_control.Width = CInt(par_control.Height * LongSideToShortRatio())

    End Sub ''End of "Public Shared Sub Proportions_CorrectWidth(par_control As Control)"

    Public Function TextImage_Field(pintDesiredLayoutWidth As Integer,
                              par_elementInfo_Text As IElement_TextOnly,
                              par_elementInfo_Base As IElement_Base,
                              ByRef pref_rotated As Boolean,
                              ByVal par_bIsDesignStage As Boolean,
                              Optional par_pictureBox As PictureBox = Nothing,
                              Optional par_graphicalCtl As Control = Nothing) As Image
        ''2/4/2022 td    Optional par_graphicalCtl As CtlGraphicFieldV3 = Nothing) As Image
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
        ''Jan25 2022''doub_LongToShort = ciLayoutPrintLib.LayoutPrint.LongSideToShortRatio()
        doub_LongToShort = ciLayoutPrintLib.LayoutPrint.LongSideToShortRatio_WH()

        ''
        ''Copied from ClassElementText.GenerateImage_NotInUse, 9/3/2019 & 8/15/2019 thomas d. 
        ''
        doubleW_div_H = (par_elementInfo_Base.Width_Pixels / par_elementInfo_Base.Height_Pixels)

        ''Added 9/4/2019 thomas downes
        boo_LikelyRatioIsMistaken = ciLayoutPrintLib.LayoutPrint.RatioIsLikelyBad(doubleW_div_H)

        ''8/24 td''doubleScaling = (pintFinalLayoutWidth / par_element.LayoutWidth_Pixels)
        ''9/5/2019 td''doubleScaling = (pintDesiredLayoutWidth / par_elementInfo_Base.Width_Pixels)
        ''9/11/2019 td''doubleScaling = (pintDesiredLayoutWidth / par_elementInfo_Base.LayoutWidth_Pixels)

        doubleScaling = (pintDesiredLayoutWidth / par_elementInfo_Base.BadgeLayoutDims.Width_Pixels)

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
        If (UseHighResolutionTips) Then

            local_image = New Bitmap(intNewElementWidth, intNewElementHeight,
                                     Imaging.PixelFormat.Format32bppPArgb)

            ''Set the resolution to 300 DPI
            ''  https://stackoverflow.com/questions/2478502/when-creating-an-bitmap-image-from-scratch-in-vb-net-the-quality-stinks
            ''
            ''9/4/2019 td''par_image.SetResolution(300, 300)
            local_image.SetResolution(300, 300)

        Else
            local_image = New Bitmap(intNewElementWidth, intNewElementHeight)

        End If ''End of "If (UseHighResolutionTips) Then ... Else ..."

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

        With par_elementInfo_Text

            ''Added 9/15/2019 thomas d.
            If (.FontFamilyName Is Nothing) Then
                ''Added 9/15/2019 thomas d.
                System.Diagnostics.Debugger.Break()
            End If ''End of "If (.FontFamilyName Is Nothing) Then"

            ''Added 9/15/2019 td
            If (.FontDrawingClass Is Nothing) Then ''6/2022 (.Font_DrawingClass Is Nothing) Then
                ''Added 9/15/2019 td
                ''6/2022 .Font_DrawingClass = modFonts.MakeFont(.FontFamilyName, .FontSize_Pixels, .FontBold, .FontItalics, .FontUnderline)
                .FontDrawingClass = .FontMaxGalkin.GetDrawingFont_UnitPixels()
            End If ''End of '"If (.Font_DrawingClass Is Nothing) Then"

            ''Added 9/8/2019 td
            ''6/7/2022 font_scaled = modFonts.ScaledFont(.Font_DrawingClass, doubleScaling)
            font_scaled = modFonts.ScaledFont(.FontDrawingClass, doubleScaling)

            ''Added 8/18/2019 td
            Select Case par_elementInfo_Text.TextAlignment''Added 8/18/2019 td

                Case HorizontalAlignment.Left

                    ''9/8/2019 td''gr_element.DrawString(.Text, .Font_DrawingClass, Brushes.Black, singleOffsetX, singleOffsetY)
                    gr_element.DrawString(.Text_StaticLine, font_scaled, Brushes.Black,
                                          singleOffsetX, singleOffsetY)

                Case HorizontalAlignment.Center
                    ''// Measure string.
                    ''9/8/2019 td''stringSize = gr_element.MeasureString(.Text, .Font_DrawingClass)
                    stringSize = gr_element.MeasureString(.Text_StaticLine, font_scaled)

                    Dim singleOffsetX_AlignRight As Single ''Added 8/18/2019 td 
                    ''Added 8/18/2019 td 
                    singleOffsetX_AlignRight = (singleOffsetX + (local_image.Width - stringSize.Width) / 2)

                    ''Added 8/18/2019 td
                    ''
                    ''9/8/2019 td''gr_element.DrawString(.Text, .Font_DrawingClass, Brushes.Black,
                    ''                            singleOffsetX_AlignRight, singleOffsetY)
                    gr_element.DrawString(.Text_StaticLine, font_scaled, Brushes.Black,
                                  singleOffsetX_AlignRight, singleOffsetY)

                Case HorizontalAlignment.Right
                    ''// Measure string.
                    ''
                    ''9/8/2019 td''stringSize = gr_element.MeasureString(.Text, .Font_DrawingClass)
                    stringSize = gr_element.MeasureString(.Text_StaticLine, font_scaled)

                    Dim singleOffsetX_AlignRight As Single ''Added 8/18/2019 td 
                    singleOffsetX_AlignRight = (local_image.Width - stringSize.Width - singleOffsetX)

                    ''Added 8/18/2019 td 
                    ''9/8/2019 td''gr_element.DrawString(.Text, .Font_DrawingClass, Brushes.Black,
                    ''                           singleOffsetX_AlignRight, singleOffsetY)
                    gr_element.DrawString(.Text_StaticLine, font_scaled, Brushes.Black,
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

    End Function ''End of "Public Function TextImage_Field(par_label As Label) As Image"

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
