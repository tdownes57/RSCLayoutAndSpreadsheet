Public Class FormUploadEditingImage
    ''
    '' Added 11/30/2021 thomas downes
    ''
    Public UploadedImage As Image
    Private mod_bSuppressEvents As Boolean
    Private mod_pathToImageFile As String

    Public Sub UploadedImageFile(par_pathToImageFile As String)
        ''
        ''Added 12/2/2021 td
        ''
        ''We'll set .BackgroundImage instead.  12/2/2012''PictureUploaded.ImageLocation = par_pathToImageFile

        Dim bitmapUploaded As New Bitmap(par_pathToImageFile)
        Me.UploadedImage = bitmapUploaded

        ''Set the background image. 

        ''Center
        pictureLayoutCenter.BackgroundImage = Me.UploadedImage
        pictureLayoutCenter.BackgroundImageLayout = ImageLayout.Center

        ''None
        pictureLayoutNone.BackgroundImage = Me.UploadedImage
        pictureLayoutNone.BackgroundImageLayout = ImageLayout.None

        ''Stretch
        pictureLayoutStretch.BackgroundImage = Me.UploadedImage
        pictureLayoutStretch.BackgroundImageLayout = ImageLayout.Stretch

        ''Zoom
        pictureLayoutZoom.BackgroundImage = Me.UploadedImage
        pictureLayoutZoom.BackgroundImageLayout = ImageLayout.Zoom




    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub FormUploadEditingImage_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class