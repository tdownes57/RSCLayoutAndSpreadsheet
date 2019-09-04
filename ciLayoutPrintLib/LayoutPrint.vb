Option Explicit On ''Added 5/21/2019 td 
Option Strict On ''Added 5/21/2019 td 
''
''Added 5/21/2019 thomas downes 
''
Imports System.Drawing ''Added 5/21/2019 thomas downes 
Imports System.Windows.Forms ''Added 5/21/2019 thomas downes 
Imports ciBadgeInterfaces ''Added 8/14/2019 thomas d. 

Public Class LayoutPrint
    ''
    ''Added 5/21/2019 td  
    ''
    ''Now a Public Property, PictureBoxReview.''Private mod_panelLayout As New System.Windows.Forms.Panel
    ''Now a Public Property, PictureBoxReview.''Private mod_pictureboxReview As System.Windows.Forms.PictureBox

    ''Added 6/13/2019 thomas downes
    ''
    Public Property RecipientID As String ''Added 6/13/2019
    Public Property RecipientName As String ''Added 6/13/2019
    Public Property RecipientPic As Image ''Added 6/20/2019 Thomas DOWNES

    Public Property PanelLayout As System.Windows.Forms.Panel

    Public Property LabelControlForID As Label ''Added 6/13/2019
    Public Property LabelControlForName As Label ''Added 6/13/2019

    Public Property PictureOfPureWhite As PictureBox ''Added 6/13/2019
    Public Property PicturePersonWithinLayout As PictureBox ''Added 6/13/2019
    Public Property PicturePersonImageLarge As PictureBox ''Added 6/13/2019
    Public Property PictureBoxReview As PictureBox ''Added 6/13/2019

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
        RatioIsLikelyBad = (1 > (100 * Math.Abs(par_doubleW_div_H - LongSideToShortRatio())))

    End Function ''End of "Public Shared Function RatioIsLikelyBad(par_doubleW_div_H As Double) As Boolean"

    Public Function GenerateBuildImage_Master(Optional ByRef pref_imageOutput As Image = Nothing,
                                       Optional ByVal pboolLargeLandscape As Boolean = False,
                                       Optional ByVal pboolSmallLandscape As Boolean = False,
                                       Optional ByVal pboolTinyLandscape As Boolean = False) As Image
        ''
        ''Added 7/6/2019 td
        ''
        If (False) Then
            Return GenerateBuildImage_Cropped(pref_imageOutput, pboolLargeLandscape,
                                           pboolSmallLandscape, pboolTinyLandscape)
        End If ''end of "If (False) Then"

        Return GenerateBuildImage_Zoom(pref_imageOutput, pboolLargeLandscape,
                                           pboolSmallLandscape, pboolTinyLandscape)

    End Function ''End of "Public Function GenerateBuildImage_Master"

    Public Function GenerateBuildImage_Zoom(Optional ByRef pref_imageOutput As Image = Nothing,
                                       Optional ByVal pboolLargeLandscape As Boolean = False,
                                       Optional ByVal pboolSmallLandscape As Boolean = False,
                                       Optional ByVal pboolTinyLandscape As Boolean = False) As Image
        ''
        ''Added 7/6/2019 thomas downes  
        ''
        ''panelLayout
        ''
        ''Let's create the image we can write our text on.  
        ''
        ''  https://stackoverflow.com/questions/8022174/how-can-i-write-on-an-image-using-vb-net
        ''
        Dim img_LargeLandscape As System.Drawing.Image
        Dim img_SmallLandscape As System.Drawing.Image ''Added 6/20/2019 td 
        Dim img_TinyLandscape As System.Drawing.Image ''Added 6/21/2019 td 
        Dim img_Rotated As Image
        Dim imgPanelBackground As System.Drawing.Image
        Dim imgPanelZoomed As System.Drawing.Image
        Dim gr As Graphics ''= Graphics.FromImage(img)
        Dim ZoomRect As New Rectangle(0, 0, Me.PanelLayout.Width, Me.PanelLayout.Height)
        Dim sizeTiny As Size ''Added 6/21/2019 thomas downes

        ''labelDefault1.Visible = False
        ''LabelDefault2.Visible = False

        imgPanelBackground = Me.PanelLayout.BackgroundImage
        imgPanelZoomed = ResizeImage(imgPanelBackground, Me.PanelLayout)

        img_LargeLandscape = imgPanelZoomed

        ''Encapsulated 5/7/2019 td
        Const c_boolCallProcedureForText As Boolean = True

        If (c_boolCallProcedureForText) Then

            ''Encapsulated 5/7/2019 td
            ApplyTextToImage(img_LargeLandscape)
            ApplyMemberPicToImage(img_LargeLandscape)

        Else

            gr = Graphics.FromImage(img_LargeLandscape)

            ''
            ''Resizing Images in VB.NET
            ''  https://stackoverflow.com/questions/2144592/resizing-images-in-vb-net
            ''

            ''gr.DrawString("Drawing text",
            ''              New Font("Tahoma", 14),
            ''              New SolidBrush(Color.Green),
            ''              10, 10)

            gr.DrawString("ID " & Me.RecipientID,
                          New Font("Tahoma", Me.LabelControlForID.Font.SizeInPoints),
                          New SolidBrush(Me.LabelControlForID.ForeColor),
                           Me.LabelControlForID.Left, Me.LabelControlForID.Top)

            gr.DrawString(Me.RecipientName,
                          New Font("Tahoma", Me.LabelControlForName.Font.SizeInPoints),
                          New SolidBrush(Me.LabelControlForName.ForeColor),
                           Me.LabelControlForName.Left, Me.LabelControlForName.Top)

            gr.Dispose()

        End If ''End of "If (c_boolCallProcedureForText) Then ..... Else ...."

        ''panelLayout.Refresh()
        ''img.Save("Test.jpg", Imaging.ImageFormat.Png)
        ''System.Diagnostics.Process.Start("Test.jpg")

        If (False) Then
            Convert.ToBase64String(System.IO.File.ReadAllBytes("Test.jpg"))
        End If

        ''6/13/2019 TD''labelDefault1.Visible = True
        ''6/13 TD''LabelDefault2.Visible = True

        ''Really needed??  Let's set Visible = True, but this is vestigial and is likely not needed.
        Me.LabelControlForID.Visible = True ''Keep as True, but this is vestigial and likely not needed.
        Me.LabelControlForName.Visible = True ''Likely not needed.

        ''Added 5/15/2019 td
        img_Rotated = CType(img_LargeLandscape.Clone, Image)

        ''5/15 td''Dim bm_source As New Bitmap(img_LargeLandscape)
        Dim bm_source As New Bitmap(img_Rotated)
        bm_source.RotateFlip(RotateFlipType.Rotate90FlipNone)

        ''img = ResizeImage(img, pictureboxReview)
        Dim imgResized As Image
        imgResized = ResizeImage(bm_source, Me.PictureBoxReview)

        If Me.PictureBoxReview IsNot Nothing Then
            Me.PictureBoxReview.Image = imgResized
        End If ''ENd of " If Me.PictureBoxReview IsNot Nothing Then"

        ''gr.DrawImage()

        If (pboolLargeLandscape) Then
            pref_imageOutput = img_LargeLandscape
            Return img_LargeLandscape ''Added 6/13/2019 td

        ElseIf (pboolSmallLandscape) Then ''Added 6/20/2019 thomas d. 
            ''Added 6/20/2019 thomas d. 
            img_SmallLandscape = Resize_Landscape80x60(img_LargeLandscape, Me.PictureBoxReview.Size)
            pref_imageOutput = img_SmallLandscape ''Added 6/20/2019 td
            Return img_SmallLandscape ''Added 6/20/2019 td

        ElseIf (pboolTinyLandscape) Then ''Added 6/21/2019 thomas d. 
            ''
            ''Added 6 / 21 / 2019 thomas d. 
            ''
            sizeTiny = New Size(CInt(Me.PictureBoxReview.Size.Width / 2), CInt(Me.PictureBoxReview.Size.Height / 2))
            img_TinyLandscape = Resize_Landscape80x60(img_LargeLandscape, sizeTiny)
            pref_imageOutput = img_TinyLandscape ''Added 6/21/2019 td
            Return img_TinyLandscape ''Added 6/21/2019 td

        Else
            pref_imageOutput = imgResized
            Return imgResized ''Added 6/13/2019 td
        End If ''end of "If (pboolLarge...) .... Else...."

    End Function ''End of "Private Sub GenerateBuildImage()"

    Public Function GenerateBuildImage_Cropped(Optional ByRef pref_imageOutput As Image = Nothing,
                                       Optional ByVal pboolLargeLandscape As Boolean = False,
                                       Optional ByVal pboolSmallLandscape As Boolean = False,
                                       Optional ByVal pboolTinyLandscape As Boolean = False) As Image
        ''
        ''6/20 td''Public Function GenerateBuildImage(Optional ByRef pref_imageOutput As Image = Nothing,
        ''6/20 td''           Optional ByVal pboolLargeLandscape As Boolean = False) As Image
        ''
        ''Added 5/6/2019 thomas downes  
        ''
        ''panelLayout
        ''
        ''Let's create the image we can write our text on.  
        ''
        ''  https://stackoverflow.com/questions/8022174/how-can-i-write-on-an-image-using-vb-net
        ''
        Dim img_LargeLandscape As System.Drawing.Image
        Dim img_SmallLandscape As System.Drawing.Image ''Added 6/20/2019 td 
        Dim img_TinyLandscape As System.Drawing.Image ''Added 6/21/2019 td 
        Dim img_Rotated As Image
        Dim imgPanelBackground As System.Drawing.Image
        Dim imgPanelCropped As System.Drawing.Image
        Dim gr As Graphics ''= Graphics.FromImage(img)
        Dim CropRect As New Rectangle(0, 0, Me.PanelLayout.Width, Me.PanelLayout.Height)
        Dim sizeTiny As Size ''Added 6/21/2019 thomas downes

        ''labelDefault1.Visible = False
        ''LabelDefault2.Visible = False

        imgPanelBackground = Me.PanelLayout.BackgroundImage

        ''imgPanelCropped = imgPanelBackground
        imgPanelCropped = New Bitmap(CropRect.Width, CropRect.Height)

        ''Crop the image to what you see in the Panel Layout.
        ''
        ''   (I have (or will soon!) restored the Zoom from the PictureBox, 
        ''   so none of the image might lie outside of the PanelLayout area. ---7/6/2019 td)
        ''
        ''   ------OBSELETE-----(I have removed the Zoom And StretchImage from the PictureBox, 
        ''   so part of the image might lie outside of the PanelLayout area. ---5/7/2019 td)
        ''
        Try
            Using graphicsCroppping = Graphics.FromImage(imgPanelCropped)
                graphicsCroppping.DrawImage(imgPanelBackground, New Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
                ''This can be done when the application closes. -----imgPanelBackground.Dispose()
                ''imgPanelCropped.Save(fileName)
            End Using
        Catch ex As Exception
            ''
            ''Added 5/9/2019 td
            ''
            MessageBox.Show("Resizing error, GenerateBuildImage:  " & ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        img_LargeLandscape = imgPanelCropped

        ''Encapsulated 5/7/2019 td
        Const c_boolCallProcedureForText As Boolean = True

        If (c_boolCallProcedureForText) Then

            ''Encapsulated 5/7/2019 td
            ApplyTextToImage(img_LargeLandscape)
            ApplyMemberPicToImage(img_LargeLandscape)

        Else

            gr = Graphics.FromImage(img_LargeLandscape)

            ''
            ''Resizing Images in VB.NET
            ''  https://stackoverflow.com/questions/2144592/resizing-images-in-vb-net
            ''

            ''gr.DrawString("Drawing text",
            ''              New Font("Tahoma", 14),
            ''              New SolidBrush(Color.Green),
            ''              10, 10)

            gr.DrawString("ID " & Me.RecipientID,
                          New Font("Tahoma", Me.LabelControlForID.Font.SizeInPoints),
                          New SolidBrush(Me.LabelControlForID.ForeColor),
                           Me.LabelControlForID.Left, Me.LabelControlForID.Top)

            gr.DrawString(Me.RecipientName,
                          New Font("Tahoma", Me.LabelControlForName.Font.SizeInPoints),
                          New SolidBrush(Me.LabelControlForName.ForeColor),
                           Me.LabelControlForName.Left, Me.LabelControlForName.Top)

            gr.Dispose()

        End If ''End of "If (c_boolCallProcedureForText) Then ..... Else ...."

        ''panelLayout.Refresh()
        ''img.Save("Test.jpg", Imaging.ImageFormat.Png)
        ''System.Diagnostics.Process.Start("Test.jpg")

        If (False) Then
            Convert.ToBase64String(System.IO.File.ReadAllBytes("Test.jpg"))
        End If

        ''6/13/2019 TD''labelDefault1.Visible = True
        ''6/13 TD''LabelDefault2.Visible = True

        ''Really needed??  Let's set Visible = True, but this is vestigial and is likely not needed.
        Me.LabelControlForID.Visible = True ''Keep as True, but this is vestigial and likely not needed.
        Me.LabelControlForName.Visible = True ''Likely not needed.

        ''Added 5/15/2019 td
        img_Rotated = CType(img_LargeLandscape.Clone, Image)

        ''5/15 td''Dim bm_source As New Bitmap(img_LargeLandscape)
        Dim bm_source As New Bitmap(img_Rotated)
        bm_source.RotateFlip(RotateFlipType.Rotate90FlipNone)

        ''img = ResizeImage(img, pictureboxReview)
        Dim imgResized As Image
        imgResized = ResizeImage(bm_source, Me.PictureBoxReview)

        If Me.PictureBoxReview IsNot Nothing Then
            Me.PictureBoxReview.Image = imgResized
        End If ''ENd of " If Me.PictureBoxReview IsNot Nothing Then"

        ''gr.DrawImage()

        If (pboolLargeLandscape) Then
            pref_imageOutput = img_LargeLandscape
            Return img_LargeLandscape ''Added 6/13/2019 td

        ElseIf (pboolSmallLandscape) Then ''Added 6/20/2019 thomas d. 
            ''Added 6/20/2019 thomas d. 
            img_SmallLandscape = Resize_Landscape80x60(img_LargeLandscape, Me.PictureBoxReview.Size)
            pref_imageOutput = img_SmallLandscape ''Added 6/20/2019 td
            Return img_SmallLandscape ''Added 6/20/2019 td

        ElseIf (pboolTinyLandscape) Then ''Added 6/21/2019 thomas d. 
            ''
            ''Added 6 / 21 / 2019 thomas d. 
            ''
            sizeTiny = New Size(CInt(Me.PictureBoxReview.Size.Width / 2), CInt(Me.PictureBoxReview.Size.Height / 2))
            img_TinyLandscape = Resize_Landscape80x60(img_LargeLandscape, sizeTiny)
            pref_imageOutput = img_TinyLandscape ''Added 6/21/2019 td
            Return img_TinyLandscape ''Added 6/21/2019 td

        Else
            pref_imageOutput = imgResized
            Return imgResized ''Added 6/13/2019 td
        End If ''end of "If (pboolLarge...) .... Else...."

    End Function ''End of "Private Sub GenerateBuildImage_Cropped()"

    Public Function GenBackgroundOnly_Zoom(Optional ByRef pref_imageOutput As Image = Nothing,
                                       Optional ByVal pboolLargeLandscape As Boolean = False,
                                       Optional ByVal pboolSmallLandscape As Boolean = False,
                                       Optional ByVal pboolTinyLandscape As Boolean = False) As Image
        ''
        ''Added 7/07/2019 thomas downes  
        ''
        ''  https://stackoverflow.com/questions/8022174/how-can-i-write-on-an-image-using-vb-net
        ''
        Dim img_LargeLandscape As System.Drawing.Image
        Dim img_SmallLandscape As System.Drawing.Image ''Added 6/20/2019 td 
        Dim img_TinyLandscape As System.Drawing.Image ''Added 6/21/2019 td 
        Dim img_Rotated As Image
        Dim imgPanelBackground As System.Drawing.Image
        Dim sizeTiny As Size ''Added 6/21/2019 thomas downes

        imgPanelBackground = Me.PanelLayout.BackgroundImage
        img_LargeLandscape = ResizeImage(imgPanelBackground, Me.PanelLayout)

        ''Added 5/15/2019 td
        img_Rotated = CType(img_LargeLandscape.Clone, Image)

        ''5/15 td''Dim bm_source As New Bitmap(img_LargeLandscape)
        Dim bm_source As New Bitmap(img_Rotated)
        bm_source.RotateFlip(RotateFlipType.Rotate90FlipNone)

        Dim imgResized As Image
        imgResized = ResizeImage(bm_source, Me.PictureBoxReview)

        If Me.PictureBoxReview IsNot Nothing Then
            Me.PictureBoxReview.Image = imgResized
        End If ''ENd of " If Me.PictureBoxReview IsNot Nothing Then"

        If (pboolLargeLandscape) Then
            pref_imageOutput = img_LargeLandscape
            Return img_LargeLandscape ''Added 6/13/2019 td

        ElseIf (pboolSmallLandscape) Then ''Added 6/20/2019 thomas d. 
            ''Added 6/20/2019 thomas d. 
            img_SmallLandscape = Resize_Landscape80x60(img_LargeLandscape, Me.PictureBoxReview.Size)
            pref_imageOutput = img_SmallLandscape ''Added 6/20/2019 td
            Return img_SmallLandscape ''Added 6/20/2019 td

        ElseIf (pboolTinyLandscape) Then ''Added 6/21/2019 thomas d. 
            ''
            ''Added 6 / 21 / 2019 thomas d. 
            ''
            sizeTiny = New Size(CInt(Me.PictureBoxReview.Size.Width / 2), CInt(Me.PictureBoxReview.Size.Height / 2))
            img_TinyLandscape = Resize_Landscape80x60(img_LargeLandscape, sizeTiny)
            pref_imageOutput = img_TinyLandscape ''Added 6/21/2019 td
            Return img_TinyLandscape ''Added 6/21/2019 td

        Else
            pref_imageOutput = imgResized
            Return imgResized ''Added 6/13/2019 td
        End If ''end of "If (pboolLarge...) .... Else...."

    End Function ''End of "Private Sub GenerateBuildImage_BackgroundOnly()"

    Public Function GenBackgroundOnly_CropIt(Optional ByRef pref_imageOutput As Image = Nothing,
                                       Optional ByVal pboolLargeLandscape As Boolean = False,
                                       Optional ByVal pboolSmallLandscape As Boolean = False,
                                       Optional ByVal pboolTinyLandscape As Boolean = False) As Image
        ''
        ''Added 6/28/2019 thomas downes  
        ''
        ''Formerly named, "GenerateBuildImage_BackgroundOnly".  
        ''
        ''Let's create the image we can write our text on.  
        ''
        ''  https://stackoverflow.com/questions/8022174/how-can-i-write-on-an-image-using-vb-net
        ''
        Dim img_LargeLandscape As System.Drawing.Image
        Dim img_SmallLandscape As System.Drawing.Image ''Added 6/20/2019 td 
        Dim img_TinyLandscape As System.Drawing.Image ''Added 6/21/2019 td 
        Dim img_Rotated As Image
        Dim imgPanelBackground As System.Drawing.Image
        Dim imgPanelCropped As System.Drawing.Image
        ''Dim gr As Graphics ''= Graphics.FromImage(img)
        Dim CropRect As New Rectangle(0, 0, Me.PanelLayout.Width, Me.PanelLayout.Height)
        Dim sizeTiny As Size ''Added 6/21/2019 thomas downes

        imgPanelBackground = Me.PanelLayout.BackgroundImage
        ''imgPanelCropped = imgPanelBackground
        imgPanelCropped = New Bitmap(CropRect.Width, CropRect.Height)

        ''Crop the image to what you see in the Panel Layout.
        ''
        ''   (I have removed the Zoom And StretchImage from the PictureBox, 
        ''   so part of the image might lie outside of the PanelLayout area. ---5/7/2019 td)
        ''
        Try
            Using graphicsCroppping = Graphics.FromImage(imgPanelCropped)
                graphicsCroppping.DrawImage(imgPanelBackground, New Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
                ''This can be done when the application closes. -----imgPanelBackground.Dispose()
                ''imgPanelCropped.Save(fileName)
            End Using
        Catch ex As Exception
            ''
            ''Added 5/9/2019 td
            ''
            MessageBox.Show("Resizing error, GenerateBuildImage:  " & ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        img_LargeLandscape = imgPanelCropped

        ''Added 5/15/2019 td
        img_Rotated = CType(img_LargeLandscape.Clone, Image)

        ''5/15 td''Dim bm_source As New Bitmap(img_LargeLandscape)
        Dim bm_source As New Bitmap(img_Rotated)
        bm_source.RotateFlip(RotateFlipType.Rotate90FlipNone)

        Dim imgResized As Image
        imgResized = ResizeImage(bm_source, Me.PictureBoxReview)

        If Me.PictureBoxReview IsNot Nothing Then
            Me.PictureBoxReview.Image = imgResized
        End If ''ENd of " If Me.PictureBoxReview IsNot Nothing Then"

        If (pboolLargeLandscape) Then
            pref_imageOutput = img_LargeLandscape
            Return img_LargeLandscape ''Added 6/13/2019 td

        ElseIf (pboolSmallLandscape) Then ''Added 6/20/2019 thomas d. 
            ''Added 6/20/2019 thomas d. 
            img_SmallLandscape = Resize_Landscape80x60(img_LargeLandscape, Me.PictureBoxReview.Size)
            pref_imageOutput = img_SmallLandscape ''Added 6/20/2019 td
            Return img_SmallLandscape ''Added 6/20/2019 td

        ElseIf (pboolTinyLandscape) Then ''Added 6/21/2019 thomas d. 
            ''
            ''Added 6 / 21 / 2019 thomas d. 
            ''
            sizeTiny = New Size(CInt(Me.PictureBoxReview.Size.Width / 2), CInt(Me.PictureBoxReview.Size.Height / 2))
            img_TinyLandscape = Resize_Landscape80x60(img_LargeLandscape, sizeTiny)
            pref_imageOutput = img_TinyLandscape ''Added 6/21/2019 td
            Return img_TinyLandscape ''Added 6/21/2019 td

        Else
            pref_imageOutput = imgResized
            Return imgResized ''Added 6/13/2019 td
        End If ''end of "If (pboolLarge...) .... Else...."

    End Function ''End of "Private Sub GenerateBuildImage_BackgroundOnly()"

    Private Sub ApplyTextToImage(ByRef par_image As Image)
        ''
        ''Added 5/7/2019 td  
        ''
        Dim gr As Graphics ''= Graphics.FromImage(img)
        gr = Graphics.FromImage(par_image)

        ''
        ''Resizing Images in VB.NET
        ''  https://stackoverflow.com/questions/2144592/resizing-images-in-vb-net
        ''

        ''gr.DrawString("Drawing text",
        ''              New Font("Tahoma", 14),
        ''              New SolidBrush(Color.Green),
        ''              10, 10)

        ''Draw white space so that the text can be read more easily. 
        ApplyWhiteSpaceToImage(par_image, Me.LabelControlForID)

        gr.DrawString("Person " & Me.RecipientID,
                      New Font("Tahoma", Me.LabelControlForID.Font.SizeInPoints),
                      New SolidBrush(Me.LabelControlForID.ForeColor),
                       Me.LabelControlForID.Left, Me.LabelControlForID.Top)

        ''Draw white space so that the text can be read more easily. 
        ApplyWhiteSpaceToImage(par_image, LabelControlForName)

        gr.DrawString(Me.RecipientName,
                      New Font("Tahoma", Me.LabelControlForName.Font.SizeInPoints),
                      New SolidBrush(Me.LabelControlForName.ForeColor),
                       Me.LabelControlForName.Left, Me.LabelControlForName.Top)

        gr.Dispose()

    End Sub ''End of ""Private Sub ApplyTextToImage(ByRef par_image As Image)

    Private Sub ApplyWhiteSpaceToImage(ByRef par_image As Image, ByVal par_textboxOrLabel As Control)
        ''
        ''Added 5/10/2019 td  
        ''
        ''    https://docs.microsoft.com/en-us/dotnet/api/system.drawing.graphics.drawimage?view=netframework-4.8
        ''
        Dim gr As Graphics ''= Graphics.FromImage(img)

        ''Added 6/28/2019 td
        Me.PictureOfPureWhite.BackColor = CType((New System.Drawing.ColorConverter()).ConvertFromString("#000000"), Color)

        gr = Graphics.FromImage(par_image)

        With par_textboxOrLabel
            gr.DrawImage(Me.PictureOfPureWhite.Image, .Left, .Top, .Width, .Height)
        End With

        gr.Dispose()

    End Sub ''ENd of "Private Sub ApplyWhiteSpaceToImage(ByRef par_image As Image, ByRef par_textboxOrLabel As Control)"

    Private Sub ApplyMemberPicToImage(ByRef par_image As Image)
        ''
        ''Added 5/7/2019 td  
        ''
        ''
        ''    https://docs.microsoft.com/en-us/dotnet/api/system.drawing.graphics.drawimage?view=netframework-4.8
        ''
        Dim gr As Graphics ''= Graphics.FromImage(img)
        Dim imgPicture As Image
        ''Dim imgResized As Image

        ''-----gr = Graphics.FromImage(par_image)
        imgPicture = Me.PicturePersonImageLarge.Image

        ''Dim bm_source As New Bitmap(imgPicture)
        ''imgResized = ResizeImage(bm_source, PicturePersonInLayout)

        gr = Graphics.FromImage(par_image)

        ''
        ''    https://docs.microsoft.com/en-us/dotnet/api/system.drawing.graphics.drawimage?view=netframework-4.8
        ''
        With Me.PicturePersonWithinLayout
            Try
                gr.DrawImage(imgPicture, .Left, .Top, .Width, .Height)
            Catch ex_draw_invalid As InvalidOperationException
                ''Error:  Object not available.
                Dim strMessage_Invalid As String
                strMessage_Invalid = ex_draw_invalid.Message
            Catch ex_draw_any As System.Exception
                ''Error:  Object not available.
                Dim strMessage_any As String
                strMessage_any = ex_draw_any.Message
            End Try
        End With

        gr.Dispose()

ExitHandler:
        ''------gr.Dispose()

    End Sub ''End of ""Private Sub ApplyMemberPicToImage(ByRef par_image As Image)

    Public Sub LoadElements_Fields(ByRef par_image As Image,
                                   par_standardFields As List(Of IElementWithText),
                                   par_customFields As List(Of IElementWithText))
        ''
        ''Added 8/14/2019 td  
        ''
        Dim gr As Graphics ''= Graphics.FromImage(img)
        gr = Graphics.FromImage(par_image)

        ''
        ''
        ''Standard Fields 
        ''
        ''
        For Each each_elementField As IElementWithText In par_standardFields

            With each_elementField
                Try
                    ''8/26/2019 td''gr.DrawImage(.TextDisplay.GenerateImage(.Position_BL.Height_Pixels),
                    ''                   .Position_BL.LeftEdge_Pixels, .Position_BL.TopEdge_Pixels,
                    ''                   .Position_BL.Width_Pixels, .Position_BL.Height_Pixels)
                    gr.DrawImage(.TextDisplay.GenerateImage_ByDesiredLayoutWidth(par_image.Width),
                                 .Position_BL.LeftEdge_Pixels, .Position_BL.TopEdge_Pixels,
                                 .Position_BL.Width_Pixels, .Position_BL.Height_Pixels)

                Catch ex_draw_invalid As InvalidOperationException
                    ''Error:  Object not available.
                    Dim strMessage_Invalid As String
                    strMessage_Invalid = ex_draw_invalid.Message
                Catch ex_draw_any As System.Exception
                    ''Error:  Object not available.
                    Dim strMessage_any As String
                    strMessage_any = ex_draw_any.Message
                End Try
            End With ''End of "With each_elementField"

            gr.Dispose()

        Next each_elementField

        ''
        ''Custom Fields 
        ''
        For Each each_elementField As IElementWithText In par_customFields

            With each_elementField
                Try
                    ''8/26/2019 td''gr.DrawImage(.TextDisplay.GenerateImage(.Position_BL.Height_Pixels),
                    ''                      .Position_BL.LeftEdge_Pixels, .Position_BL.TopEdge_Pixels,
                    ''                      .Position_BL.Width_Pixels, .Position_BL.Height_Pixels)

                    gr.DrawImage(.TextDisplay.GenerateImage_ByDesiredLayoutWidth(par_image.Width),
                                 .Position_BL.LeftEdge_Pixels, .Position_BL.TopEdge_Pixels,
                                 .Position_BL.Width_Pixels, .Position_BL.Height_Pixels)

                Catch ex_draw_invalid As InvalidOperationException
                    ''Error:  Object not available.
                    Dim strMessage_Invalid As String
                    strMessage_Invalid = ex_draw_invalid.Message
                Catch ex_draw_any As System.Exception
                    ''Error:  Object not available.
                    Dim strMessage_any As String
                    strMessage_any = ex_draw_any.Message
                End Try
            End With ''End of "With each_elementField"

            gr.Dispose()

        Next each_elementField

    End Sub ''End of ''Private Sub LoadElements_Fields()''

    Public Shared Function ResizeImage(ByVal par_InputImage As Image, ByVal parSizingBox As Control) As Image
        ''
        ''https://stackoverflow.com/questions/2144592/resizing-images-in-vb-net 
        ''
        ''5/7/2019 td''Return New Bitmap(InputImage, New Size(64, 64))
        ''8/26/2019 td''Return New Bitmap(InputImage, New Size(parSizingBox.Width, parSizingBox.Height))
        Return ResizeBackground_ToFitBox(par_InputImage, parSizingBox, True)

    End Function ''Public Shared Function ResizeImage(ByVal InputImage As Image, ByVal parSizingBox As Control) As Image

    Public Shared Function ResizeBackground_ToFitBox(ByVal parInputImage As Image,
                                                     ByVal parSizingBox As Control,
                                                     ByVal par_bApplyCentering As Boolean) As Image
        ''
        ''https://stackoverflow.com/questions/2144592/resizing-images-in-vb-net 
        ''
        ''5/7/2019 td''Return New Bitmap(InputImage, New Size(64, 64))
        ''8/26/2019 td''Return New Bitmap(InputImage, New Size(parSizingBox.Width, parSizingBox.Height))

        Dim temp_image As Image ''Added 8/27/2019 td
        Dim doubRatioWidthToHeight_Box As Double
        Dim doubRatioWidthToHeight_Image As Double
        Dim bResizeByWidthNotHeight As Boolean
        Dim bImageProportionsArePerfect As Boolean
        Dim boolLandscapeMode As Boolean
        Dim boolPortraitMode As Boolean

        doubRatioWidthToHeight_Box = (parSizingBox.Width / parSizingBox.Height)
        doubRatioWidthToHeight_Image = (parInputImage.Width / parInputImage.Height)

        bImageProportionsArePerfect = (doubRatioWidthToHeight_Image = doubRatioWidthToHeight_Box)
        bResizeByWidthNotHeight = (doubRatioWidthToHeight_Image > doubRatioWidthToHeight_Box)
        boolLandscapeMode = (parSizingBox.Width > parSizingBox.Height)
        boolPortraitMode = (Not boolLandscapeMode)

        If (bImageProportionsArePerfect And (boolLandscapeMode)) Then

            ''Since the image is perfectly proportioned, and we are in landscape mode, 
            ''  let's resize by width.  
            ''
            ''8/27/2019 td''Return ResizeImage_ToWidth(parInputImage, parSizingBox.Width)
            temp_image = ResizeImage_ToWidth(parInputImage, parSizingBox.Width)

        ElseIf (bImageProportionsArePerfect And (boolPortraitMode)) Then

            ''Since the image is perfectly proportioned, and we are in Portrait mode, 
            ''  let's resize by height.  
            Dim boolDummy1 As Boolean

            ''8/27/2019 td''Return ResizeImage_ToHeight(parInputImage, boolDummy1, parSizingBox.Height)
            temp_image = ResizeImage_ToHeight(parInputImage, boolDummy1, parSizingBox.Height)

        ElseIf (bResizeByWidthNotHeight) Then

            ''Since the image is unexpectedly wide, let's resize by width. 
            ''8/27/2019 td''Return ResizeImage_ToWidth(parInputImage, parSizingBox.Width)
            temp_image = ResizeImage_ToWidth(parInputImage, parSizingBox.Width)

        Else
            ''Since the image is unexpectedly tall, let's resize by height. 
            Dim boolDummy2 As Boolean
            ''8/27/2019 td''Return ResizeImage_ToHeight(parInputImage, boolDummy2, parSizingBox.Height)
            temp_image = ResizeImage_ToHeight(parInputImage, boolDummy2, parSizingBox.Height)

        End If ''End of "If (bResizeByWidthNotHeight) Then .... Else ...."

        Dim imgLayout As Image ''Added 8/28/2019 td
        Dim gr As Graphics ''Added 8/28/2019 td
        Dim intLeft As Integer = 0 ''Added 8/28/2019 td
        Dim intTop As Integer = 0 ''Added 8/28/2019 td

        imgLayout = New Bitmap(parSizingBox.Width, parSizingBox.Height)
        gr = Graphics.FromImage(imgLayout)

        If (par_bApplyCentering) Then
            ''
            ''Center the image. ---8/28/2019 thomas d.
            ''
            intLeft = CInt((parSizingBox.Width - temp_image.Width) / 2)
            intTop = CInt((parSizingBox.Height - temp_image.Height) / 2)
        End If ''End of "If (par_bApplyCentering) Then"

        gr.DrawImage(temp_image, New PointF(intLeft, intTop))
        Return imgLayout

    End Function ''Public Shared Function ResizeImage(ByVal InputImage As Image, ByVal parSizingBox) As Image

    Public Shared Function ResizeImage_ToWidth(ByVal InputImage As Image, ByVal par_intWidth As Integer) As Image
        ''
        ''Added 7/13/2019 Thomas Downes
        ''
        Dim intNewHeight As Integer

        intNewHeight = CInt(par_intWidth * (InputImage.Height / InputImage.Width))

        Return New Bitmap(InputImage, New Size(par_intWidth, intNewHeight))

    End Function ''Public Shared Function ResizeImage(ByVal InputImage As Image, ByVal parSizingBox As Control) As Image

    Public Shared Function ResizeImage_ToHeight(ByVal InputImage As Image, ByVal pbDummy As Boolean, ByVal par_intHeight As Integer) As Image
        ''
        ''Added 7/13/2019 Thomas Downes
        ''
        Dim intNewWidth As Integer

        intNewWidth = CInt(par_intHeight * (InputImage.Width / InputImage.Height))

        Return New Bitmap(InputImage, New Size(intNewWidth, par_intHeight))

    End Function ''Public Shared Function ResizeImage(ByVal InputImage As Image, ByVal parSizingBox As Control) As Image

    Public Shared Function Resize_Portrait60x80(ByVal parInputImage As Image, ByVal parSizeOfCard As Size) As Image
        ''
        ''https://stackoverflow.com/questions/2144592/resizing-images-in-vb-net 
        ''
        ''Added 6/20/2019 thomas DOWNES
        ''
        Dim confirmedAsPortrait As Size

        With parSizeOfCard

            If (.Width < .Height) Then

                confirmedAsPortrait = parSizeOfCard

            Else
                ''
                ''We have to do a switch-a-roo.
                ''
                Dim intWidthSwitchedFromHeight As Integer
                Dim intHeightSwitchedFromWidth As Integer

                intWidthSwitchedFromHeight = .Height
                intHeightSwitchedFromWidth = .Width

                confirmedAsPortrait = New Size(intWidthSwitchedFromHeight, intHeightSwitchedFromWidth)

            End If ''End of "If (.Width < .Height) Then .... Else ....."

        End With ''End of "With parSizeOfCard"

        Return New Bitmap(parInputImage, confirmedAsPortrait)

    End Function ''Public Shared Function Resize_Portrait60x80(ByVal InputImage As Image, ByVal parSizeOfCard As Size) As Image

    Public Shared Function Resize_Landscape80x60(ByVal parInputImage As Image, ByVal parSizeOfCard As Size) As Image
        ''
        ''Added 6/20/2019 thomas DOWNES
        ''
        Dim confirmedAsLandscape As Size

        With parSizeOfCard

            If (.Height < .Width) Then

                confirmedAsLandscape = parSizeOfCard

            Else
                ''
                ''We have to do a switch-a-roo.
                ''
                Dim intWidthSwitchedFromHeight As Integer
                Dim intHeightSwitchedFromWidth As Integer

                intWidthSwitchedFromHeight = .Height
                intHeightSwitchedFromWidth = .Width

                confirmedAsLandscape = New Size(intWidthSwitchedFromHeight, intHeightSwitchedFromWidth)

            End If ''End of "If (.Height < .Width) Then .... Else ....."

        End With ''End of "With parSizeOfCard"

        Return New Bitmap(parInputImage, confirmedAsLandscape)

    End Function ''Public Shared Function Resize_Landscape80x60(ByVal parInputImage As Image, ByVal parSizeOfCard As Size) As Image




End Class
