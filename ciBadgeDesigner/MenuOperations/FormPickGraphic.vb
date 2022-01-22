''
''Added 1/21/2022 thomas downes
''
Imports System.Drawing
Imports System.Resources

Public Class FormPickGraphic

    Public Property ListOfImages As List(Of Image)
    Public Property PathToImageFileLocation As String

    Private Sub FormPickGraphic_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 1/21/2022 thomas downes
        ''
        ''----Load_ApplicationResources()

        Load_ImagesFromFolderImages()


    End Sub


    Private Sub Load_ImagesFromFolderImages()
        ''
        ''Added 1/21/2022 thomas downes
        ''
        Dim strPathToFolderImages As String
        Dim objNewPictureBox As PictureBox
        Dim objFolderInfo As System.IO.Directory
        Dim intControlsCount As Integer

        strPathToFolderImages = DiskFolders.PathToFolder_Graphics()
        Load_ImagesFromFolderPath(strPathToFolderImages)
        intControlsCount = FlowLayoutPanel1.Controls.Count
        If (intControlsCount > 0) Then Exit Sub

        strPathToFolderImages = DiskFolders.PathToFolder_Images
        Load_ImagesFromFolderPath(strPathToFolderImages)
        intControlsCount = FlowLayoutPanel1.Controls.Count
        If (intControlsCount > 0) Then Exit Sub

        strPathToFolderImages = DiskFolders.PathToFolder_BackExamples
        Load_ImagesFromFolderPath(strPathToFolderImages)
        intControlsCount = FlowLayoutPanel1.Controls.Count
        If (intControlsCount > 0) Then Exit Sub

    End Sub ''End of "Private Sub Load_ImagesFromFolderImages()"


    Private Sub Load_ImagesFromFolderPath(pstrPathToFolderWithImages As String)
        ''
        ''Added 1/21/2022 thomas downes
        ''
        Dim objFolderInfo As System.IO.DirectoryInfo

        FlowLayoutPanel1.Controls.Clear()
        ''strPathToFolderImages = DiskFolders.PathToFolder_Images
        objFolderInfo = New IO.DirectoryInfo(pstrPathToFolderWithImages)

        For Each objFileInfo As IO.FileInfo In objFolderInfo.EnumerateFiles
            ''
            ''Iterate through the files. 
            ''
            Load_ImageIntoContainerUsingPath(objFileInfo.FullName)

        Next objFileInfo

    End Sub ''End of "Private Sub Load_ImagesFromFolderImages()"


    Private Sub Load_ImageIntoContainerUsingPath(par_pathToImage As String)
        ''
        ''Added 1/22/2022 
        ''
        Dim objNewPictureBox As PictureBox
        Dim singleRatioWidth As Single
        Dim singleRatioHeight As Single
        Dim singleRatioLarger As Single

        objNewPictureBox = New PictureBox()
        With objNewPictureBox
            .ImageLocation = par_pathToImage ''Jan22 2022''objFileInfo.FullName
            .Load()
            .SizeMode = PictureBoxSizeMode.Zoom
            .Visible = True
            .Width = .Image.Width
            .Height = .Image.Height
            singleRatioWidth = CSng(.Width / FlowLayoutPanel1.Width)
            singleRatioHeight = CSng(.Height / FlowLayoutPanel1.Height)
            singleRatioLarger = CSng(IIf(singleRatioWidth > singleRatioHeight, singleRatioWidth, singleRatioHeight))
            If (singleRatioLarger > 1) Then
                .Width = CInt((.Width / singleRatioLarger) / 2)
                .Height = CInt((.Height / singleRatioLarger) / 2)
            End If ''End of "If (singleRatioLarger > 1) Then"

            ''Added 1/22/2022 td
            AddHandler .Click, AddressOf HandlePictureBoxClicks

        End With ''Eend of "With objNewPictureBox"

        FlowLayoutPanel1.Controls.Add(objNewPictureBox)

    End Sub ''End of ""Private Sub Load_ImageIntoContainerUsingPath(par_pathToImage As String)""


    Private Sub HandlePictureBoxClicks(objSender As Object, e As EventArgs)
        ''
        ''Added 1/22/2022 td  
        ''
        Dim objPictureBox As PictureBox = CType(objSender, PictureBox)
        Dim strPathToImageFile As String

        strPathToImageFile = objPictureBox.ImageLocation

        textboxPathToImageFile.Text = strPathToImageFile

    End Sub ''End of "Private Sub HandlePictureBoxClicks(objSender As Object, e As EventArgs)"


    Private Sub Load_ApplicationResources()
        ''ListOfImages.AddRange(My.Application)

        ''    // Create a resource manager.
        ''ResourceManager rm = New ResourceManager("rmc",
        ''                         TypeOf (Example).Assembly);

        ''Dim objRM As New resourcemanager("rmc", )
        Dim assembly As System.Reflection.Assembly
        assembly = Me.GetType.Assembly
        Dim myOtherAssembly As System.Reflection.Assembly
        myOtherAssembly = System.Reflection.Assembly.Load("ResourceAssembly")

        ' Creates the ResourceManager'.

        Dim resourceManager As New System.Resources.ResourceManager("ResourceNamespace.myResources", assembly)

        ''Dim resString As System.String
        Dim resObj As System.Drawing.Image
        ''resString = resourceManager.GetString("StringResource")
        resObj = CType(resourceManager.GetObject("ImageResource"),
            System.Drawing.Image)

    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        ''
        ''Added 1/22/2022
        ''
        Me.PathToImageFileLocation = textboxPathToImageFile.Text
        ''Added 1/22/2022
        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click

        ''Added 1/22/2022
        Me.PathToImageFileLocation = ""
        ''Added 1/22/2022
        Me.DialogResult = DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub ButtonBrowseForImageFile_Click(sender As Object, e As EventArgs) Handles ButtonBrowseForImageFile.Click
        ''
        ''Added 1/22/2022 td
        ''
        OpenFileDialog1.InitialDirectory = DiskFolders.PathToFolder_Graphics()
        OpenFileDialog1.Filter = "JPG|*.jpg"

        Dim diag_result As DialogResult
        diag_result = OpenFileDialog1.ShowDialog()
        If (diag_result = DialogResult.Cancel) Then
            Exit Sub
        End If

        Dim strPathToSelectedImageFile As String = ""
        Dim strPathToImageFilePasted As String = ""
        Dim strPathToFolderGraphics As String = ""
        Dim strPathToImageFileInGraphics As String = ""

        strPathToFolderGraphics = DiskFolders.PathToFolder_Graphics()
        strPathToSelectedImageFile = OpenFileDialog1.FileName

        If (IO.File.Exists(strPathToSelectedImageFile)) Then

            Dim objFileInfo As New IO.FileInfo(strPathToSelectedImageFile)
            Dim bAlreadyInFolderGraphics As Boolean

            bAlreadyInFolderGraphics = (objFileInfo.DirectoryName = strPathToFolderGraphics)

            If (bAlreadyInFolderGraphics) Then

                strPathToImageFileInGraphics = strPathToSelectedImageFile

            Else
                DiskFilesVB.CopyPasteImageFile(strPathToSelectedImageFile,
                                 strPathToFolderGraphics,
                                 strPathToImageFilePasted)
                strPathToImageFileInGraphics = strPathToImageFilePasted

            End If ''End of "If (False = bAlreadyInFolderGraphics) Then"

        End If ''End of " If (IO.File.Exists(strPathToSelectedImageFile)) Then"

        ''
        ''Important call !!  
        ''
        Load_ImageIntoContainerUsingPath(strPathToImageFileInGraphics)
        textboxPathToImageFile.Text = strPathToImageFileInGraphics

    End Sub ''End of "Private Sub ButtonBrowseForImageFile_Click"


End Class