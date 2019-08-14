Option Explicit On ''Added 5/21/2019 td 
Option Strict On ''Added 5/21/2019 td 
''
''Added 5/21/2019 thomas downes 
''
Imports System.Drawing ''Added 5/21/2019 thomas downes 
Imports System.Windows.Forms ''Added 5/21/2019 thomas downes 

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




    Public Sub LoadElements_Fields(par_standardFields As List(Of ICIBFieldCustomOrStandard),
                                   par_customFields As List(Of ICIBFieldCustomOrStandard))
        ''
        ''Added 7/18/2019 thomas downes 
        ''
        ''mod_Pic = New ClassElementPic(pictureboxPic)

        ''mod_RecipientID = mod_generator.GetRecipientID(GraphicFieldLabel1) ''New ClassElementText
        ''mod_NameFull = mod_generator.GetFullName(GraphicFieldLabel2) ''New ClassElementText

        ''mod_Text1 = mod_generator.GetTextField1(gr) ''New ClassElementText
        ''mod_Text2 = mod_generator.GetTextField2(PictureBox13) ''New ClassElementText
        ''mod_Text3 = mod_generator.GetTextField3(PictureBox14)

        ''mod_Date1 = mod_generator.GetDateField1(PictureBox15) ''New ClassElementText
        ''mod_Date2 = mod_generator.GetDateField2(PictureBox16) ''New ClassElementText

        Dim intNumControlsAlready_std As Integer ''Added 7/26/2019 td 
        Dim intNumControlsAlready_cust As Integer ''Added 7/26/2019 td 
        ''7/31 td''Dim intTopEdge_cust As Integer ''Added 7/28/2019 td
        Dim intTopEdge_std As Integer ''Added 7/28/2019 td

        ''
        ''
        ''Standard Fields 
        ''
        ''
        ''8/14/2019 td''ClassFieldStandard.InitializeHardcodedList_Students(True)

        For Each field_standard As ClassFieldStandard In ClassFieldStandard.ListOfFields_Students

            Dim new_label_control_std As CtlGraphicFldLabel

            ''Added 7/29
            If (field_standard.ElementInfo Is Nothing) Then

                field_standard.ElementInfo = New ClassElementText()

                ''8/9/2019 td''new_label_control_std = New CtlGraphicFldLabel(field_standard)
                new_label_control_std = New CtlGraphicFldLabel(field_standard, Me)

                Me.Controls.Add(new_label_control_std)

                ''Moved far below. ''new_label_control_std.GroupEdits = CType(Me, ISelectingElements) ''Added 8/1 td

                new_label_control_std.Width = CInt(pictureBack.Width / 3)

                With field_standard.ElementInfo

                    .Width_Pixels = new_label_control_std.Width
                    .Height_Pixels = new_label_control_std.Height

                    intTopEdge_std = (30 + 30 * intNumControlsAlready_std)
                    .TopEdge_Pixels = intTopEdge_std
                    .LeftEdge_Pixels = ((10 + intNumControlsAlready_std * .Width_Pixels) + 10)

                End With ''End of "With field_standard.ElementInfo"

            Else

                ''Added 8/9/2019 td''new_label_control_std = New CtlGraphicFldLabel(field_standard)
                new_label_control_std = New CtlGraphicFldLabel(field_standard, Me)

                Me.Controls.Add(new_label_control_std)

                ''Moved far below. ''new_label_control_std.GroupEdits = CType(Me, ISelectingElements) ''Added 8/1 td

            End If ''end of "If (field_standard.ElementInfo Is Nothing) Then ... Else..."

            new_label_control_std.Top = field_standard.ElementInfo.TopEdge_Pixels
            new_label_control_std.Left = field_standard.ElementInfo.LeftEdge_Pixels
            new_label_control_std.Width = field_standard.ElementInfo.Width_Pixels
            new_label_control_std.Height = field_standard.ElementInfo.Height_Pixels

            ''intTopEdge_std = (30 + 30 * intNumControlsAlready_std)

            ''Moved up.''Me.Controls.Add(new_label_control_std)

            ''Inappropriate. 7/29 td''new_label_control_std.Left = ((10 + intNumControlsAlready_std * new_label_control_std.Width) + 10)
            ''Inappropriate. 7/29 td''''new_label_control_std.Top = 10
            ''Inappropriate. 7/29 td''new_label_control_std.Top = intTopEdge_std

            new_label_control_std.Visible = True
            intNumControlsAlready_std += 1

            new_label_control_std.Name = "StandardCtl" & CStr(intNumControlsAlready_std)
            new_label_control_std.BorderStyle = BorderStyle.FixedSingle

            ''
            ''Added 7/28/2019 thomas d.
            ''
            new_label_control_std.RefreshImage()

            ''Added 7/28/2019 thomas d.
            new_label_control_std.GroupEdits = CType(Me, ISelectingElements) ''Added 8/1 td

        Next field_standard

        ''
        ''Custom Fields 
        ''
        ClassFieldCustomized.InitializeHardcodedList_Students(True)

        For Each field_custom As ClassFieldCustomized In ClassFieldCustomized.ListOfFields_Students

            ''Added 7/29
            ''If (field_custom.ElementInfo Is Nothing) Then field_custom.ElementInfo = New ClassElementText()

            ''Dim new_label_control_cust As New GraphicFieldLabel(field_custom)

            ''intTopEdge_cust = (30 + 30 * intNumControlsAlready_cust)

            ''Me.Controls.Add(new_label_control_cust)
            ''new_label_control_cust.Left = ((intNumControlsAlready_cust * new_label_control_cust.Width) + 10)
            ''''7/28 td''new_label_control_cust.Top = (120 + new_label_control_cust.Height)
            ''new_label_control_cust.Top = intTopEdge_cust
            ''new_label_control_cust.Visible = True

            ''7/28/2019 td''ControlMoverOrResizer_TD.Init(new_label_control_cust, 20) ''Added 7/28/2019 thomas downes

            Dim new_label_control_cust As CtlGraphicFldLabel

            ''Added 7/29
            If (field_custom.ElementInfo Is Nothing) Then

                field_custom.ElementInfo = New ClassElementText()

                ''8/9/2019 td''new_label_control_cust = New CtlGraphicFldLabel(field_custom)
                new_label_control_cust = New CtlGraphicFldLabel(field_custom, Me)

                Me.Controls.Add(new_label_control_cust)

                new_label_control_cust.Width = CInt(pictureBack.Width / 3)

                With field_custom.ElementInfo

                    .Width_Pixels = new_label_control_cust.Width
                    .Height_Pixels = new_label_control_cust.Height

                    intTopEdge_std = (30 + 30 * intNumControlsAlready_std)
                    .TopEdge_Pixels = intTopEdge_std
                    .LeftEdge_Pixels = ((10 + intNumControlsAlready_std * .Width_Pixels) + 10)

                End With

            Else

                ''8/9/2019 td''new_label_control_cust = New CtlGraphicFldLabel(field_custom)
                new_label_control_cust = New CtlGraphicFldLabel(field_custom, Me)

                Me.Controls.Add(new_label_control_cust)

            End If ''end of "If (field_standard.ElementInfo Is Nothing) Then ... Else..."

            new_label_control_cust.Top = field_custom.ElementInfo.TopEdge_Pixels
            new_label_control_cust.Left = field_custom.ElementInfo.LeftEdge_Pixels
            new_label_control_cust.Width = field_custom.ElementInfo.Width_Pixels
            new_label_control_cust.Height = field_custom.ElementInfo.Height_Pixels

            ''intTopEdge_std = (30 + 30 * intNumControlsAlready_std)

            ''Moved up.''Me.Controls.Add(new_label_control_cust)

            ''Inappropriate. 7/29 td''new_label_control_std.Left = ((10 + intNumControlsAlready_std * new_label_control_std.Width) + 10)
            ''Inappropriate. 7/29 td''''new_label_control_std.Top = 10
            ''Inappropriate. 7/29 td''new_label_control_std.Top = intTopEdge_std

            intNumControlsAlready_cust += 1
            new_label_control_cust.Name = "CustCtl" & CStr(intNumControlsAlready_cust)
            new_label_control_cust.BorderStyle = BorderStyle.FixedSingle

            ''
            ''Added 7/28/2019 thomas d.
            ''
            new_label_control_cust.RefreshImage()

            ''Added 7/28/2019 thomas d.
            new_label_control_cust.GroupEdits = CType(Me, ISelectingElements) ''Added 8/1 td

        Next field_custom

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
