''
'' Added 12/2/2021 Thomas Downes  
''
Public Class CtlWidthHeight
    ''
    '' Added 12/2/2021 Thomas Downes  
    ''
    ''Public Sub UploadedImageFile(par_pathToImageFile As String)
    ''    ''
    ''    ''Added 12/2/2021 td
    ''    ''
    ''    PictureUploaded.ImageLocation = par_pathToImageFile
    ''    Dim bitmapUploaded As New Bitmap(par_pathToImageFile)
    ''    Me.UploadedImage = bitmapUploaded

    ''    CtlWidthHeightUploaded.ImageToDescribe = Me.UploadedImage

    ''End Sub

    Private mod_image As Image
    Private Const c_mod_ratioPVCCard_WdivH As Single = 3.38 / 2.13
    Private mod_width As Single
    Private mod_height As Single
    Private mod_keepWidth As Boolean
    Private mod_keepHeight As Boolean

    Private mod_differenceInPixels_Width As Integer
    Private mod_differenceInPixels_Height As Integer

    Public Sub ImageToDescribe(par_image As Image, par_bKeepWidth As Boolean, par_bKeepHeight As Boolean)
        ''
        ''Added 12/2/2021 td
        ''
        mod_image = par_image
        mod_keepHeight = par_bKeepHeight
        mod_keepWidth = par_bKeepWidth

        textWidth.Text = par_image.Width.ToString() ''ToString() needed for Option Strict added 6/18/2022
        textHeight.Text = par_image.Height.ToString() ''ToString() needed for Option Strict added 6/18/2022

        If (par_bKeepHeight And par_bKeepWidth) Then
            mod_height = par_image.Height
            mod_width = par_image.Width

        ElseIf (par_bKeepHeight) Then
            ''The height will _NOT_ be adjusted. The width _will_ be adjusted. 
            mod_height = par_image.Height
            mod_width = CType(mod_height * c_mod_ratioPVCCard_WdivH, Integer)

            ''Calculate the difference, i.e. how many pixels might be cut off. 
            ''6/2022 mod_differenceInPixels_Width = (par_image.Width - mod_width)
            mod_differenceInPixels_Width = CInt(par_image.Width - mod_width)
            LabelLossOfPixelsWidth.Visible = True ''Show
            LabelLossOfPixelsHeight.Visible = False ''Hide 
            LabelLossOfPixelsWidth.Text = String.Format(LabelLossOfPixelsWidth.Tag.ToString,
                                                        mod_differenceInPixels_Width)

        ElseIf (par_bKeepWidth) Then
            ''The width will _NOT_ be adjusted. The height _will_ be adjusted. 
            mod_width = par_image.Width
            mod_height = CType(mod_width / c_mod_ratioPVCCard_WdivH, Integer)

            ''Calculate the difference, i.e. how many pixels might be cut off. 
            mod_differenceInPixels_Height = CInt(par_image.Height - mod_height)
            LabelLossOfPixelsHeight.Visible = True ''Show Loss of Height 
            LabelLossOfPixelsWidth.Visible = False ''Hide Loss of Width 
            LabelLossOfPixelsHeight.Text = String.Format(LabelLossOfPixelsHeight.Tag.ToString,
                                                         mod_differenceInPixels_Height)

        Else
            ''6/2022 Throw New Exception("One or both (width & height) need to be indicated.")
            System.Diagnostics.Debugger.Break()

        End If ''End of "If (par_bKeepHeight And par_bKeepWidth) Then .... ElseIf.... ElseIf...."

        textHeight.Text = mod_height.ToString()
        textWidth.Text = mod_width.ToString()

        LabelRatioMessage.Text = String.Format(LabelRatioMessage.Tag.ToString,
                                  mod_height / mod_width)

    End Sub ''End of "Public Sub ImageToDescribe"


    Public Function GetNumberOfPixelsPotentiallyLost(Optional pboolSuppressNegatives As Boolean = True) As Integer
        ''
        ''Added 12/2/2021 td
        ''
        Dim intPixelsToBeLost As Integer

        If (mod_keepHeight And (Not mod_keepWidth)) Then

            If (Not pboolSuppressNegatives) Then Return mod_differenceInPixels_Width
            ''6/2022 intPixelsToBeLost = IIf(mod_differenceInPixels_Width > 0, mod_differenceInPixels_Width, 0)
            intPixelsToBeLost = CInt(IIf(mod_differenceInPixels_Width > 0, mod_differenceInPixels_Width, 0))
            Return intPixelsToBeLost

        ElseIf (mod_keepWidth And (Not mod_keepHeight)) Then

            If (Not pboolSuppressNegatives) Then Return mod_differenceInPixels_Height
            intPixelsToBeLost = CInt(IIf(mod_differenceInPixels_Height > 0, mod_differenceInPixels_Height, 0))
            Return intPixelsToBeLost

        End If

        Return -1

    End Function ''End of "Public Sub ImageToDescribe"



    Private Sub CtlWidthHeight_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
