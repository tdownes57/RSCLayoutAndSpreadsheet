Option Explicit On ''Added 8/24/2019 td 
Option Strict On ''Added 8/24/2019 td 
''
''Added 8/24/2019 thomas downes 
''
Imports System.Drawing ''Added 8/24/2019 thomas downes 
Imports System.Windows.Forms ''Added 8/24/2019 thomas downes 
Imports ciBadgeInterfaces ''Added 8/24/2019 thomas d. 

Public Class LayoutPrint_Redux
    ''
    ''Added 8/24/2019 td  
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

    Public Sub LoadImageWithFieldValues(ByRef par_image As Image,
                                   par_standardFields As List(Of IElementWithText),
                                   par_customFields As List(Of IElementWithText),
                                        Optional par_listTextImages As List(Of Image) = Nothing)
        ''
        ''Added 8/14/2019 td  
        ''
        Dim gr As Graphics ''= Graphics.FromImage(img)
        Dim intEachIndex As Integer ''Added 8/24/2019 td
        Dim bOutputAllImages As Boolean ''Added 8/26/2019 thomas d. 

        bOutputAllImages = (par_listTextImages IsNot Nothing) ''Added 8/26/2019 thomas d. 

        gr = Graphics.FromImage(par_image)

        ''
        ''
        ''Standard Fields 
        ''
        ''
        For Each each_elementField As IElementWithText In par_standardFields

            intEachIndex += 1

            ''Added 8/24/2019 thomas d.
            With each_elementField.Position_BL
                Select Case True
                    Case (.LeftEdge_Pixels < 0)
                        Continue For
                    Case (.TopEdge_Pixels < 0) ''Then 
                        ''Continue For
                    Case (.LeftEdge_Pixels + .Width_Pixels > par_image.Width) ''Then 
                        ''Continue For
                    Case (.TopEdge_Pixels + .Height_Pixels > par_image.Height) ''Then 
                        ''Continue For
                End Select
            End With ''End of "With each_elementField.Position_BL"

            Dim image_textStandard As Image
            Dim intLeft As Integer
            Dim intTop As Integer

            With each_elementField

                Try
                    ''gr.DrawImage(.TextDisplay.GenerateImage(.Position_BL.Height_Pixels),
                    ''   .Position_BL.LeftEdge_Pixels, .Position_BL.TopEdge_Pixels,
                    ''   .Position_BL.Width_Pixels, .Position_BL.Height_Pixels)

                    ''#1 8/26/2019 td''image_textStandard = .TextDisplay.GenerateImage(.Position_BL.Height_Pixels)
                    '' #2 8/26/2019 td''image_textStandard = .TextDisplay.GenerateImage_ByHeight(.Position_BL.Height_Pixels)
                    image_textStandard = .TextDisplay.GenerateImage_ByDesiredLayoutWidth(par_image.Width)

                    If (bOutputAllImages) Then par_listTextImages.Add(image_textStandard) ''Added 8/26/2019 td

                    ''8/30/2019 td''.TextDisplay.Image_BL = image_textStandard ''Added 8/27/2019 td
                    .Position_BL.Image_BL = image_textStandard ''Added 8/27/2019 td

                    intLeft = .Position_BL.LeftEdge_Pixels
                    intTop = .Position_BL.TopEdge_Pixels

                    gr.DrawImage(image_textStandard,
                                 New PointF(intLeft, intTop))

                Catch ex_draw_invalid As InvalidOperationException
                    ''Error:  Object not available.
                    Dim strMessage_Invalid As String
                    strMessage_Invalid = ex_draw_invalid.Message
                    ''Added 8/24 thomas d.
                    MessageBox.Show(strMessage_Invalid, "",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation)
                Catch ex_draw_any As System.Exception
                    ''Error:  Object not available.
                    Dim strMessage_any As String
                    strMessage_any = ex_draw_any.Message
                    ''Added 8/24 thomas d.
                    MessageBox.Show(strMessage_any, "",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation)
                End Try
            End With ''End of "With each_elementField"

            ''----gr.Dispose()

        Next each_elementField

        ''
        ''Custom Fields 
        ''
        For Each each_elementField As IElementWithText In par_customFields

            Dim image_textCustom As Image ''Added 8/26/2019 td  
            Dim intLeft As Integer
            Dim intTop As Integer

            With each_elementField
                Try
                    ''#1 8/26/2019 td''image_textCustom = .TextDisplay.GenerateImage(.Position_BL.Height_Pixels)
                    '' #2 8/26/2019 td''image_textCustom = .TextDisplay.GenerateImage_ByHeight(.Position_BL.Height_Pixels)
                    image_textCustom = .TextDisplay.GenerateImage_ByDesiredLayoutWidth(par_image.Width)

                    If (bOutputAllImages) Then par_listTextImages.Add(image_textCustom) ''Added 8/26/2019 td

                    ''8/30/2019 td''.TextDisplay.Image_BL = image_textCustom ''Added 8/27/2019 td
                    .Position_BL.Image_BL = image_textCustom ''Added 8/27/2019 td

                    ''8/26/2019 td''gr.DrawImage(image_textCustom,
                    ''                    .Position_BL.LeftEdge_Pixels, .Position_BL.TopEdge_Pixels,
                    ''                    .Position_BL.Width_Pixels, .Position_BL.Height_Pixels)

                    intLeft = .Position_BL.LeftEdge_Pixels
                    intTop = .Position_BL.TopEdge_Pixels

                    gr.DrawImage(image_textCustom,
                                 New PointF(intLeft, intTop))

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

            ''---gr.Dispose()

        Next each_elementField

        gr.Dispose()

    End Sub ''End of ''Private Sub LoadElements_Fields()''

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




End Class

