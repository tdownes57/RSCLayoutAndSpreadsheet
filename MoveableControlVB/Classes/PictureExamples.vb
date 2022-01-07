Option Explicit On
Option Strict On
''
''Added 6/13/2019 td  
''
Imports System.Drawing ''Added 6/13/2019 td
Imports System.Drawing.Text ''added 6/13 td

Public Class PictureExamples
    ''
    ''Added 6/13/2019 td  
    ''
    Private Shared mod_images_Jpegs As List(Of Image)
    Private Shared mod_images_PNGs As List(Of Image) ''Added 7/8/2019 td

    Private Shared mod_imageForNoPicture As Image ''Added 7/8/2019 td 
    Private Shared mod_imageSusanSample As Image ''Added 7/10/2019 td 

    Public Shared PathToFolderOfImages As String = "" ''Added 8/20/2019 td  

    Public Shared Sub CreateExamplePics_Numbered(par_intCountNeeded As Integer, par_imageFormat As Imaging.ImageFormat)
        ''
        ''Added 10/16/2019 Thomas Downes  
        ''
        Dim strPathToFolder As String
        Dim strPathToFile As String
        Dim font_scaled As System.Drawing.Font ''Added 9/8/2019 td

        ''----font_scaled = New Font("Arial", 35, FontStyle.Regular)
        font_scaled = New Font("Arial", 35, FontStyle.Regular)

        strPathToFolder = PathToFolderOfImages

        ''----10/18/2019 td----strPathToFile = IO.Path.Combine(strPathToFolder, "000.jpg")
        strPathToFile = IO.Path.Combine(strPathToFolder, "000.bmp")

        Dim obj_image_unnumbered As Image
        obj_image_unnumbered = (New Bitmap(strPathToFile))

        ''Return (New Bitmap(strPathToFile))

        For intIndex As Integer = 1 To par_intCountNeeded

            Dim gr_num As Graphics
            Dim brush_white As Brush

            gr_num = Graphics.FromImage(obj_image_unnumbered)

            brush_white = New SolidBrush(Color.White)

            gr_num.FillRectangle(brush_white,
                  New Rectangle(22, 203, 127, 82))

            gr_num.TextRenderingHint = TextRenderingHint.AntiAliasGridFit

            ''Dim stringSize = New SizeF()

            gr_num.DrawString(intIndex.ToString("000"), font_scaled, Brushes.Black, 30, 210)

            ''----10/18 td''strPathToFile = IO.Path.Combine(strPathToFolder, (intIndex.ToString("000") & ".jpg"))
            Select Case True ''par_imageFormat
                Case (par_imageFormat.ToString = Imaging.ImageFormat.Bmp.ToString)
                    strPathToFile = IO.Path.Combine(strPathToFolder, (intIndex.ToString("000") & ".bmp"))
                Case (par_imageFormat.ToString = Imaging.ImageFormat.Bmp.ToString)
                    strPathToFile = IO.Path.Combine(strPathToFolder, (intIndex.ToString("000") & ".jpg"))
                Case (par_imageFormat.ToString = Imaging.ImageFormat.Bmp.ToString)
                    strPathToFile = IO.Path.Combine(strPathToFolder, (intIndex.ToString("000") & ".png"))
            End Select

            ''#1 10/18/2019 td''obj_image_unnumbered.Save(strPathToFile)
            '' #2 10/18/2019 td''obj_image_unnumbered.Save(strPathToFile, Imaging.ImageFormat.Bmp)
            obj_image_unnumbered.Save(strPathToFile, par_imageFormat) ''10/18 td''Imaging.ImageFormat.Bmp)

        Next intIndex

    End Sub ''End of "Public Shared Sub CreateExamplePics_Numbered"

    Public Shared Function GetImageByRecipID_Null(pstrRecipientID As String) As Image
        ''
        ''Added 12/11/2019 thomas d.
        ''
        Return Nothing

    End Function ''End of "Public Shared Function GetImageByRecipID_Null(pstrRecipientID As String) As Image"

    Public Shared Function GetImageByRecipID(pstrRecipientID As String) As Image
        ''
        ''Added 10/16/2019 thomas d.
        ''
        Dim strPathToFolder As String
        Dim strPathToFile As String

        ''10/18/2019 td''strPathToFoler = DiskFolder.PathToFolder_Images
        strPathToFolder = PathToFolderOfImages

        ''Added 11//21/2019 thomas downes
        If ("" = PathToFolderOfImages) Then
            PathToFolderOfImages = "C:\Users\tdown\source\repos\ciBadgeForWeb\ciBadgeForWeb\Images\PictureExamples"
            strPathToFolder = PathToFolderOfImages
        End If ''End "If ("" = PathToFolderOfImages) Then"

        strPathToFile = IO.Path.Combine(strPathToFolder, pstrRecipientID & ".jpg")

        Try
            Return (New Bitmap(strPathToFile))
        Catch ex_GetImageByID As Exception
            ''aDDED 11/21/2019 TD
            Return Nothing
        End Try

    End Function ''eND OF "Public Shared Function GetImageByRecipID(pstrRecipientID As String) As Image" 

    Public Shared Function GetImageByIndex(par_indexImage As Integer, Optional ByRef pref_strErrorMessage As String = "") As Image
        ''
        ''Added 8/13/2019  
        ''
        ''8/20/2019 td''If (mod_images_Jpegs Is Nothing) Then mod_images_Jpegs = GetListOfImages_Jpegs()

        ''Added 8/28/2019 thomas d
        If ("" = PathToFolderOfImages) Then ''Added 8/28/2019 thomas d
            pref_strErrorMessage = "Missing path to the folder of images."
            Return Nothing
        End If ''ENd of "If ("" = PathToFolderOfImages) Then"

        If (mod_images_Jpegs Is Nothing) Then mod_images_Jpegs = GetListOfImages_Jpegs(PathToFolderOfImages)

        ''Added 9/24/2019 td
        Dim boolIndexIsPastTheEnd As Boolean
        boolIndexIsPastTheEnd = (par_indexImage > -1 + mod_images_Jpegs.Count)
        If (boolIndexIsPastTheEnd) Then
            ''We have to cycle back to the beginning of the set of Jpeg portraits. ---9/24/2019 td
            par_indexImage -= mod_images_Jpegs.Count
        End If

        Return mod_images_Jpegs(par_indexImage)

    End Function ''End of "Public Shared Function GetImageByIndex() As Image"


    Public Shared Function GetExample(Optional par_strErrMessage As String = "") As Image
        ''
        ''Added 7/9/2019  
        ''
        ''8/20/2019 td''Return GetExample_Jpeg()

        ''Added 8/22/2019 td
        If ("" = PathToFolderOfImages) Then
            par_strErrMessage = "Path to images is not specified."
            Return Nothing ''Exit Function
        End If ''End of "If ("" = PathToFolderOfImages) Then"

        Return GetExample_Jpeg(PathToFolderOfImages)

    End Function ''End of "Public Shared Function GetExample() As Image"

    Public Shared Function GetExample_Jpeg(par_pathToJpegsFolder As String) As Image  ''6/13/2019 td''As System.Drawing.Image
        ''8/20/2019 td'' Public Shared Function GetExample_Jpeg(par_pathToJpegsFolder As String) As Image
        ''7/9/2019 td''Public Shared Function GetExample() As Image
        ''
        ''Added 6/13/2019 td  
        ''
        Static s_intCallIndex As Integer
        Dim output_image As Image

        ''Moved here from below. 6/15/2019
        ''7/8/2019 td''If (mod_images_Jpegs Is Nothing) Then mod_images_Jpegs = GetListOfImages()
        '' 8/20/2019 td''If (mod_images_Jpegs Is Nothing) Then mod_images_Jpegs = GetListOfImages_Jpegs()
        If (mod_images_Jpegs Is Nothing) Then mod_images_Jpegs = GetListOfImages_Jpegs(par_pathToJpegsFolder)

        ''See bottom.''s_intCallIndex += 1
        If (s_intCallIndex >= mod_images_Jpegs.Count) Then s_intCallIndex = 0

        ''Moved up. 6/15 td ''If (mod_images Is Nothing) Then mod_images = GetListOfImages()

        output_image = mod_images_Jpegs(s_intCallIndex)

ExitHandler:

        s_intCallIndex += 1

        ''6/17/2019 td''Return mod_images(s_intCallIndex)
        Return output_image

        ''6/17 td''ExitHandler:
        ''6/17 td''        s_intCallIndex += 1

    End Function ''End of "Public Shared Function GetExample_Jpeg() As Image"

    Public Shared Function GetExample_PNG() As Image
        ''
        ''Added 7/09/2019 td  
        ''
        Static s_intCallIndex As Integer
        Dim output_image As Image

        If (mod_images_PNGs Is Nothing) Then mod_images_PNGs = GetListOfImages_PNGs()

        If (s_intCallIndex >= mod_images_PNGs.Count) Then s_intCallIndex = 0

        output_image = mod_images_Jpegs(s_intCallIndex)

ExitHandler:
        s_intCallIndex += 1
        Return output_image
    End Function ''End of "Public Shared Function GetExample_PNG() As Image"

    Public Shared Function GetImageWithNoPicture() As Image
        ''
        ''Added 7/8/2019 thomas downes 
        '' 
        If (mod_images_Jpegs Is Nothing) Then
            ''
            ''The following function looks for the image "NoPic.jpg".  ---7/10/2019 td
            ''
            ''8/20/2019 td''mod_images_Jpegs = GetListOfImages_Jpegs()
            mod_images_Jpegs = GetListOfImages_Jpegs(PathToFolderOfImages)

        End If ''End of "If (mod_images_Jpegs Is Nothing) Then"

        Return mod_imageForNoPicture

    End Function ''End of "Public Shared Function GetImageWithNoPicture() As Image"

    Public Shared Function GetImageSusanSample() As Image
        ''
        ''Added 7/10/2019 thomas downes 
        '' 
        If (mod_images_Jpegs Is Nothing) Then
            ''
            ''The following function looks for the image "Sample.jpg".  ---7/10/2019 td
            ''
            '' 8/20/2019 td''mod_images_Jpegs = GetListOfImages_Jpegs()
            mod_images_Jpegs = GetListOfImages_Jpegs(PathToFolderOfImages)

        End If ''End of "If (mod_images_Jpegs Is Nothing) Then"

        Return mod_imageSusanSample

    End Function ''End of "Public Shared Function GetImageSusanSample() As Image"

    Private Shared Function GetListOfImages_Jpegs(par_pathToJpegsFolder As String) As List(Of Image)
        ''  8/20 td'' Private Shared Function GetListOfImages_Jpegs() As List(Of Image) 
        '' 7/8 td''Private Shared Function GetListOfImages() As List(Of Image)
        '' 
        ''Added 6/13/2019 thomas downes 
        ''
        Dim strPathToFolderWithPics As String
        Dim all_Jpegs As IEnumerable(Of System.IO.FileInfo) = Nothing
        Dim picture_box As New System.Windows.Forms.PictureBox
        Dim output_list = New List(Of Image)

        ''6/16/2019 td''strPathToFolderWithPics = My.Application.Info.DirectoryPath & "\PictureExamples"
        ''6/22/2019 td''strPathToFolderWithPics = "C:\Users\Jane\source\repos\ciBadgeForWeb\ciPictures_VB\PictureExamples"
        ''#1 8/20/2019 td''strPathToFolderWithPics = "C:\CI Solutions\CI Badge Web\ciPictures_VB\PictureExamples"
        '' #2 8/20/2019 td''strPathToFolderWithPics = (My.Application.Info.DirectoryPath & "\Images\PictureExamples")
        strPathToFolderWithPics = par_pathToJpegsFolder ''(My.Application.Info.DirectoryPath & "\Images\PictureExamples")

        For intTry As Integer = 1 To 2

            '' 7/8/2019 td''all_Jpegs = (New System.IO.DirectoryInfo(strPathToFolderWithPics)).EnumerateFiles()
            If (intTry = 1) Then all_Jpegs = (New System.IO.DirectoryInfo(strPathToFolderWithPics)).EnumerateFiles("*.jpg")
            If (intTry = 2) Then all_Jpegs = (New System.IO.DirectoryInfo(strPathToFolderWithPics)).EnumerateFiles("*.jpeg")

            For Each each_file As System.IO.FileInfo In all_Jpegs

                ''Added 7/8/2019 thomas downes
                If (each_file.Name.StartsWith("NoPic")) Then
                    mod_imageForNoPicture = (New Bitmap(each_file.FullName))
                    Continue For
                End If ''End of "If (each_file.Name.StartsWith("NoPic")) Then"

                ''Added 7/10/2019 thomas downes
                If (each_file.Name.StartsWith("Sample")) Then
                    mod_imageSusanSample = (New Bitmap(each_file.FullName))
                    Continue For
                End If ''End of "If (each_file.Name.StartsWith("Sample")) Then"

                ''7/8/2019 td''With picture_box
                ''    .ImageLocation = each_file.FullName
                ''    .Visible = True
                ''    ''6/16/2019 td''.Refresh()
                ''    .Load()
                ''    If (.Image IsNot Nothing) Then output_list.Add(.Image)
                ''End With

                Dim each_image As Image ''Added 6/16/2019 Thomas DOWNES  

                each_image = (New Bitmap(each_file.FullName))
                output_list.Add(each_image)

            Next each_file

        Next intTry

        Return output_list

    End Function ''End of "Private Shared Function GetListOfImages_Jpegs() As List(Of Image)"

    Private Shared Function GetListOfImages_PNGs() As List(Of Image)
        '' 
        ''Added 7/08/2019 thomas downes 
        ''
        Dim strPathToFolderWithPics As String
        Dim all_PNGs As IEnumerable(Of System.IO.FileInfo) = Nothing
        Dim picture_box As New System.Windows.Forms.PictureBox
        Dim output_list = New List(Of Image)

        strPathToFolderWithPics = "C:\CI Solutions\CI Badge Web\ciPictures_VB\PictureExamples"

        all_PNGs = (New System.IO.DirectoryInfo(strPathToFolderWithPics)).EnumerateFiles("*.png")

        For Each each_file As System.IO.FileInfo In all_PNGs

            Dim each_image As Image ''Added 6/16/2019 Thomas DOWNES  
            each_image = (New Bitmap(each_file.FullName))
            output_list.Add(each_image)

        Next each_file

        Return output_list

    End Function ''End of "Private Shared Function GetListOfImages_PNGs() As List(Of Image)"


End Class  ''End of "Public Class PictureExamples"




