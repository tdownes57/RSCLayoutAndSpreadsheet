Option Explicit On ''Added 8/24/2019 td 
Option Strict On ''Added 8/24/2019 td 
''
''Added 8/24/2019 thomas downes 
''
Imports System.Drawing ''Added 8/24/2019 thomas downes 
Imports System.Windows.Forms ''Added 8/24/2019 thomas downes 
Imports ciBadgeInterfaces ''Added 8/24/2019 thomas d. 
Imports ciBadgeElements ''Added 9/18/2019 thomas d. 
Imports ciBadgeElemImage ''Added 9/19/2019 td 

Public Class LayoutElements
    ''
    ''Added 9/18/2019 & 8/24/2019 td  
    ''
    ''Now a Public Property, PictureBoxReview.''Private mod_panelLayout As New System.Windows.Forms.Panel
    ''Now a Public Property, PictureBoxReview.''Private mod_pictureboxReview As System.Windows.Forms.PictureBox

    ''Added 6/13/2019 thomas downes
    ''
    Public Property RecipientID As String ''Added 6/13/2019
    Public Property RecipientName As String ''Added 6/13/2019
    Public Property RecipientPic As Image ''Added 6/20/2019 Thomas DOWNES

    ''Added 1/15/2020 thomas downes
    Public Property RecipientInfo As IRecipient ''Added 1/15/2020

    Public Property PanelLayout As System.Windows.Forms.Panel

    Public Property LabelControlForID As Label ''Added 6/13/2019
    Public Property LabelControlForName As Label ''Added 6/13/2019

    Public Property PictureOfPureWhite As PictureBox ''Added 6/13/2019
    Public Property PicturePersonWithinLayout As PictureBox ''Added 6/13/2019
    Public Property PicturePersonImageLarge As PictureBox ''Added 6/13/2019
    Public Property PictureBoxReview As PictureBox ''Added 6/13/2019

    Public Sub New()
        ''
        ''Added 1/15/2020 thomas downes
        ''
    End Sub ''End of Public Sub New

    Public Sub New(par_iRecipientInfo As IRecipient)
        ''
        ''Added 1/15/2020 thomas downes
        ''
        RecipientInfo = par_iRecipientInfo
        ciBadgeElements.ClassElementField.iRecipientInfo = par_iRecipientInfo

    End Sub ''End of Public Sub New(par_iRecipientInfo As IRecipient)

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
        Dim doubleExpected_27_17 As Double ''Added 9/8/2019 
        Dim doubleDifference As Double ''Added 9/8/2019 
        Dim doubleDifference_x100 As Double ''Added 9/8/2019 
        Dim boolReturnValue As Boolean ''Added 9/8

        ''9/8/2019 td''RatioIsLikelyBad = (1 > (100 * Math.Abs(par_doubleW_div_H - LongSideToShortRatio())))

        doubleExpected_27_17 = LongSideToShortRatio()

        ''9/8/2019 td''RatioIsLikelyBad = (1 > (100 * Math.Abs(par_doubleW_div_H - doubleExpected_27_17)))

        doubleDifference = Math.Abs(par_doubleW_div_H - doubleExpected_27_17)
        doubleDifference_x100 = (100 * doubleDifference)

        boolReturnValue = (1 < doubleDifference_x100)

        Return boolReturnValue

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
        Me.ApplyWhiteSpaceToImage(par_image, Me.LabelControlForID)

        gr.DrawString("Person " & Me.RecipientID,
                      New Font("Tahoma", Me.LabelControlForID.Font.SizeInPoints),
                      New SolidBrush(Me.LabelControlForID.ForeColor),
                       Me.LabelControlForID.Left, Me.LabelControlForID.Top)

        ''Draw white space so that the text can be read more easily. 
        Me.ApplyWhiteSpaceToImage(par_image, LabelControlForName)

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

    Public Sub LoadImageWithElements(ByRef par_imageBadgeCard As Image,
                                   par_elements As HashSet(Of ClassElementField),
                                        Optional par_listTextImages As HashSet(Of Image) = Nothing,
                                     Optional pboolShowPopupMessages As Boolean = False,
                                     Optional par_bOutputListsOfFields As Boolean = False,
                                     Optional par_listFieldsIncluded As List(Of String) = Nothing,
                                     Optional par_listFieldsNotIncluded As List(Of String) = Nothing)
        ''9/18/2019 td---Public Sub LoadImageWithFieldValues(ByRef par_imageBadgeCard As Image,
        ''---                                par_standardFields As List(Of IFieldInfo_ElementPositions),
        ''---                                par_customFields As List(Of IFieldInfo_ElementPositions),
        ''---                                     Optional par_listTextImages As List(Of Image) = Nothing)        ''
        ''Added 8/14/2019 td  
        ''
        Dim gr_Badge As Graphics ''= Graphics.FromImage(img)
        Dim intEachIndex As Integer ''Added 8/24/2019 td
        Dim bOutputAllImages As Boolean ''Added 8/26/2019 thomas d. 
        Dim strTextToDisplay As String ''Added 10/17/2019 thomas d. 

        ''9/8/2019 thomas d.
        ProportionsAreSlightlyOff(par_imageBadgeCard, True, "par_imageBadgeCard")

        bOutputAllImages = (par_listTextImages IsNot Nothing) ''Added 8/26/2019 thomas d. 

        gr_Badge = Graphics.FromImage(par_imageBadgeCard)

        ''Added 11/9/2021 Thomas Downes
        If (par_bOutputListsOfFields) Then
            par_listFieldsIncluded = New List(Of String)
            par_listFieldsNotIncluded = New List(Of String)
        End If ''End of "If (par_bOutputListsOfFields) Then"

        ''
        ''
        ''All Fields 
        ''
        ''
        ''9/18/2019 td''For Each each_elementField As IFieldInfo_ElementPositions In par_standardFields
        For Each each_elementField As ClassElementField In par_elements

            intEachIndex += 1

            ''9/3/2019 td''If (not each_elementField.IsDiplayedOnBadge) Then Continue for

            ''
            ''Added 8/24/2019 thomas d.
            ''
            ''9/18 td''With each_elementField.Position_BL

            With each_elementField

                Select Case True
                    Case (.LeftEdge_Pixels < 0)
                        Continue For
                    Case (.TopEdge_Pixels < 0) ''Then 
                        Continue For
                    Case (.LeftEdge_Pixels + .Width_Pixels > par_imageBadgeCard.Width) ''Then 
                        ''Continue For
                    Case (.TopEdge_Pixels + .Height_Pixels > par_imageBadgeCard.Height) ''Then 
                        ''Continue For
                End Select
            End With ''End of "With each_elementField"

            With each_elementField

                Dim image_textStandard As Image
                ''9/20/2019 td''Dim intLeft As Integer
                ''9/20/2019 td''Dim intTop As Integer

                ''9/3/2019 td''If (Not .IsDisplayedOnBadge) Then Continue For
                Dim bWeWontIncludeField As Boolean = False ''Added 11/9/2021 td
                If (.FieldInfo Is Nothing) Then bWeWontIncludeField = True ''11/9/2021 Continue For ''Added 10/13/2019 td
                If (Not .FieldInfo.IsDisplayedOnBadge) Then bWeWontIncludeField = True ''11/9/2021 Continue For

                If (bWeWontIncludeField) Then
                    If (par_bOutputListsOfFields) Then
                        ''List fields which are being skipped/omitted.
                        par_listFieldsNotIncluded.Add(each_elementField.FieldInfo.CIBadgeField)
                    End If ''End of "If (par_bListFieldsForOutput) Then"
                    ''
                    ''Skip this element.
                    ''
                    Continue For
                End If ''End if "If (bWeWontIncludeField) Then"

                ''Added 9/4/2019 thomas downes
                ''9/12/2019 td''If (0 = .Position_BL.LayoutWidth_Pixels) Then
                If (0 = .Width_Pixels) Then
                    ''Added 9/4/2019 thomas downes
                    If (pboolShowPopupMessages) Then
                        MessageBox.Show("We cannot scale the placement of the image.", "LayoutPrint_Redux",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If ''End of "If (pboolShowPopupMessages) Then"
                End If ''ENd of "If (0 = .Position_BL.BadgeLayout.Width_Pixels) Then"

                Try
                    ''gr.DrawImage(.TextDisplay.GenerateImage(.Position_BL.Height_Pixels),
                    ''   .Position_BL.LeftEdge_Pixels, .Position_BL.TopEdge_Pixels,
                    ''   .Position_BL.Width_Pixels, .Position_BL.Height_Pixels)

                    ''#1 8/26/2019 td''image_textStandard = .TextDisplay.GenerateImage(.Position_BL.Height_Pixels)
                    '' #2 8/26/2019 td''image_textStandard = .TextDisplay.GenerateImage_ByHeight(.Position_BL.Height_Pixels)

                    ''9/5/2019 td''image_textStandard = .TextDisplay.GenerateImage_ByDesiredLayoutWidth(par_imageBadgeCard.Width)
                    ''9/8/2019 td''image_textStandard = .TextDisplay.GenerateImage_ByDesiredLayoutWidth(each_elementField.BadgeLayout_Width)

                    Dim intDesiredLayout_Width As Integer ''added 9/8/2019 td
                    intDesiredLayout_Width = par_imageBadgeCard.Width

                    ''9/19/2019 td''image_textStandard =
                    ''9/19/2019 td''    .TextDisplay.GenerateImage_ByDesiredLayoutWidth(intDesiredLayout_Width)

                    strTextToDisplay = each_elementField.LabelText_ToDisplay(False)

                    ''10/17 td''image_textStandard =
                    ''             modGenerate.TextImage_ByElemInfo(intDesiredLayout_Width,
                    ''            each_elementField, each_elementField, False, False) ''9/20/2019 td'', True)
                    image_textStandard =
                        modGenerate.TextImage_ByElemInfo(strTextToDisplay, intDesiredLayout_Width,
                            each_elementField, each_elementField, False, False) ''9/20/2019 td'', True)

                    If (bOutputAllImages) Then par_listTextImages.Add(image_textStandard) ''Added 8/26/2019 td

                    ''8/30/2019 td''.TextDisplay.Image_BL = image_textStandard ''Added 8/27/2019 td
                    ''9/19/2019 td''.Position_BL.Image_BL = image_textStandard ''Added 8/27/2019 td
                    .Image_BL = image_textStandard ''Added 8/27/2019 td

                    ''9/4/2019 td''intLeft = .Position_BL.LeftEdge_Pixels
                    ''9/4/2019 td''intTop = .Position_BL.TopEdge_Pixels

                    Dim decScalingFactor As Double ''Added 9/4/2019 thomas downes ''9/4 td''Decimal

                    ''9/12/2019 td''decScalingFactor = (par_imageBadgeCard.Width / .Position_BL.LayoutWidth_Pixels)
                    ''9/19/2019 td''decScalingFactor = (par_imageBadgeCard.Width / .Position_BL.BadgeLayout.Width_Pixels)

                    ''---+--9/20/2019 td''decScalingFactor = (par_imageBadgeCard.Width / .Width_Pixels)
                    ''---+--9/20/2019 td''intLeft = CInt(.LeftEdge_Pixels * decScalingFactor)
                    ''---+--9/20/2019 td''intTop = CInt(.TopEdge_Pixels * decScalingFactor)
                    ''---+--9/20/2019 td''gr_Badge.DrawImage(image_textStandard,
                    ''---+--9/20/2019 td''             New PointF(intLeft, intTop))

                    ''Added 9/20/2019 td 
                    decScalingFactor = (par_imageBadgeCard.Width / each_elementField.BadgeLayout.Width_Pixels)

                    Dim intDesignedLeft As Integer ''Designed = layout pre-production = The Left value when designed via the Layout Designer tool. --9/20
                    Dim intDesignedTop As Integer ''Designed = layout pre-production = The Top value when designed via the Layout Designer tool.  --9/20
                    Dim intDesiredLeft As Integer ''Desired = preview/print/production = The Left value on the print/preview version of the badge.  --9/20
                    Dim intDesiredTop As Integer ''Desired = preview/print/production = The Top value on the print/preview version of the badge.  --9/20

                    intDesignedLeft = .LeftEdge_Pixels
                    intDesignedTop = .TopEdge_Pixels

                    intDesiredLeft = CInt(intDesignedLeft * decScalingFactor)
                    intDesiredTop = CInt(intDesignedTop * decScalingFactor)

                    gr_Badge.DrawImage(image_textStandard,
                                 New PointF(intDesiredLeft, intDesiredTop))

                    ''
                    ''List the element's field among the included fields.
                    ''---11/9/2021 thomas
                    ''
                    If (par_bOutputListsOfFields) Then
                        ''Add it to the list of included fields.
                        par_listFieldsIncluded.Add(each_elementField.FieldInfo.CIBadgeField)
                    End If ''End of "If (par_bOutputListsOfFields) Then"

                Catch ex_draw_invalid As InvalidOperationException
                    ''Error:  Object not available.
                    Dim strMessage_Invalid As String
                    strMessage_Invalid = ex_draw_invalid.Message
                    ''Added 8/24 thomas d.
                    MessageBox.Show(strMessage_Invalid, "10303",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation)
                Catch ex_draw_any As System.Exception
                    ''Error:  Object not available.
                    Dim strMessage_any As String
                    strMessage_any = ex_draw_any.Message
                    ''Added 8/24 thomas d.
                    MessageBox.Show(strMessage_any, "99943800",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation)
                End Try
            End With ''End of "With each_elementField"

            ''---gr.Dispose()

        Next each_elementField

        gr_Badge.Dispose()

    End Sub ''End of ''Private Sub LoadImageWithElements()''

    Public Sub LoadImageWithPortrait(pintDesiredLayoutWidth As Integer,
                                     pintDesignedLayoutWidth As Integer,
                                    ByRef par_imageBadgeCard As Image,
                                     ByVal par_elementBase As IElement_Base,
                                     ByVal par_elementPic As IElementPic,
                                     ByRef par_imagePortrait As Image)
        ''
        ''Added 9/9/2019 thomas d. 
        ''
        Dim imagePortraitResized As Image
        Dim gr_Badge As Graphics ''= Graphics.FromImage(img)
        Dim decScalingFactor As Double ''Added 9/4/2019 thomas downes ''9/4 td''Decimal
        Dim intLeft_Desired As Integer
        Dim intTop_Desired As Integer
        Dim intWidth_Desired As Integer

        ProportionsAreSlightlyOff(par_imageBadgeCard, True, "par_imageBadgeCard")

        gr_Badge = Graphics.FromImage(par_imageBadgeCard)

        decScalingFactor = (pintDesiredLayoutWidth /
                            pintDesignedLayoutWidth)

        With par_elementBase
            intLeft_Desired = CInt(.LeftEdge_Pixels * decScalingFactor)
            intTop_Desired = CInt(.TopEdge_Pixels * decScalingFactor)
            intWidth_Desired = CInt(.Width_Pixels * decScalingFactor)
        End With

        ''9/9/2019 td''gr_Badge.DrawImage(par_imagePortrait, New PointF(intLeft_Desired, intTop_Desired))

        imagePortraitResized = ResizeImage_ToWidth(par_imagePortrait, intWidth_Desired)

        gr_Badge.DrawImage(imagePortraitResized, New PointF(intLeft_Desired, intTop_Desired))

        gr_Badge.Dispose()

    End Sub ''end of "Public Sub LoadImageWithPortrait()"

    Public Shared Function ProportionsAreSlightlyOff(par_image As Image, pboolVerbose As Boolean,
                                                     Optional par_strNameOfImage As String = "") As Boolean
        ''
        ''Added 9/5/2019 thomas downes  
        ''
        Dim doubleW_div_H As Double

        doubleW_div_H = (par_image.Width / par_image.Height)

        ''9/6 td''Return ProportionsAreSlightlyOff(doubleW_div_H, pboolVerbose, par_strNameOfImage)
        Return ProportionsAreSlightlyOff(doubleW_div_H, pboolVerbose, par_strNameOfImage)

    End Function ''End of "Public Shared Function RatioIsLikelyBad(par_doubleW_div_H As Double) As Boolean"

    Public Shared Function ProportionsAreSlightlyOff(par_doubleW_div_H As Double, pboolVerbose As Boolean,
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

        ''9/8 td''Select Case par_enum
        ''    Case EnumImageOrControl.Image : strObjectType = "(image)"
        ''    Case EnumImageOrControl.Contl : strObjectType = "(control)"
        ''End Select
        strObjectType = "(image)"

        If (pboolVerbose And boolRatioIsBad) Then
            ''Added 9/6/2019 Thomasd.
            strRatioDesired = LongSideToShortRatio().ToString("0.00")
            strRatioCurrent = par_doubleW_div_H.ToString("0.00")
            MessageBox.Show($"Uh-oh, the proportions of {strObjectType} [{par_strImageOrControl}] are {strRatioCurrent} instead of {strRatioDesired}.", "",
                                               MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If ''End of "If (pboolVerbose) Then"

        Return boolRatioIsBad

    End Function ''End of "Public Shared Function RatioIsLikelyBad(par_doubleW_div_H As Double) As Boolean"

    Public Shared Function ResizeImage(ByVal InputImage As Image, ByVal parSizingBox As Control) As Image
        ''
        ''https://stackoverflow.com/questions/2144592/resizing-images-in-vb-net 
        ''
        ''5/7/2019 td''Return New Bitmap(InputImage, New Size(64, 64))
        Return New Bitmap(InputImage, New Size(parSizingBox.Width, parSizingBox.Height))

    End Function ''Public Shared Function ResizeImage(ByVal InputImage As Image, ByVal parSizingBox As Control) As Image

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

End Class

