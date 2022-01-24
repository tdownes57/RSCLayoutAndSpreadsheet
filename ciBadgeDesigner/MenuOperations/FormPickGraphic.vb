''
''Added 1/21/2022 thomas downes
''
Imports System.Drawing
Imports System.Resources

Public Class FormPickGraphic

    Public Property ListOfImages As List(Of Image)
    Public Property PathToImageFileLocation As String
    Public Property RatioWH As Single
    Public Property ImageWidth As Integer
    Public Property ImageHeight As Integer

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
        Dim objFileInfo As System.IO.FileInfo = Nothing ''Added 1/22/2022 td
        Dim intCountImages As Integer = 0 ''Added 1/22/2022 td

        FlowLayoutPanel1.Controls.Clear()
        ''strPathToFolderImages = DiskFolders.PathToFolder_Images
        objFolderInfo = New IO.DirectoryInfo(pstrPathToFolderWithImages)

        ''Jan22 ''For Each objFileInfo As IO.FileInfo In objFolderInfo.EnumerateFiles
        For Each objFileInfo In objFolderInfo.EnumerateFiles
            ''
            ''Iterate through the files. 
            ''
            Load_ImageIntoContainerUsingPath(objFileInfo.FullName)

            intCountImages += 1

        Next objFileInfo

        ''Added 1/22/2022 td
        If (intCountImages = 1) Then textboxPathToImageFile.Text = objFileInfo.FullName

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

        ''
        '' Display the Image.  
        ''
        FlowLayoutPanel1.Controls.Add(objNewPictureBox)

        ''
        ''Added 1/22/2022
        ''
        Me.ImageWidth = objNewPictureBox.Image.Width
        Me.ImageHeight = objNewPictureBox.Image.Height
        Me.RatioWH = CSng(Me.ImageWidth / Me.ImageHeight)

    End Sub ''End of ""Private Sub Load_ImageIntoContainerUsingPath(par_pathToImage As String)""


    Private Sub HandlePictureBoxClicks(objSender As Object, e As EventArgs)
        ''
        ''Added 1/22/2022 td  
        ''
        ''See following line of code
        ''       "AddHandler .Click, AddressOf HandlePictureBoxClicks" 
        ''  in the Private Sub Load_ImageIntoContainerUsingPath.
        ''  ----1/22/2022 td
        ''
        Dim objPictureBox As PictureBox = CType(objSender, PictureBox)
        Dim strPathToImageFile As String
        Dim strPathToImageFile_InGraphicsFolder As String = ""
        Dim strPathFinal_OutputToGraphics As String = ""

        ClearBordersOfPictureBoxes() ''Remove previously-drawn borders. ---1/24/2022 td
        objPictureBox.BorderStyle = BorderStyle.FixedSingle ''Added 1/24/2022 td

        strPathToImageFile = objPictureBox.ImageLocation

        ''Make sure the path to the image leads to the Graphics folder.
        CopyPasteImageFileToGraphics_IfNeeded(strPathToImageFile, strPathFinal_OutputToGraphics)

        ''Jan22 2022 ''textboxPathToImageFile.Text = strPathToImageFile
        strPathToImageFile_InGraphicsFolder = strPathFinal_OutputToGraphics
        textboxPathToImageFile.Text = strPathToImageFile_InGraphicsFolder

        ''
        ''Added 1/22/2022
        ''
        Me.ImageWidth = objPictureBox.Image.Width
        Me.ImageHeight = objPictureBox.Image.Height
        Me.RatioWH = CSng(Me.ImageWidth / Me.ImageHeight)

    End Sub ''End of "Private Sub HandlePictureBoxClicks(objSender As Object, e As EventArgs)"


    Private Sub ClearBordersOfPictureBoxes()
        ''
        ''Added 1/24/2022 td
        ''
        For Each objBox As PictureBox In FlowLayoutPanel1.Controls

            objBox.BorderStyle = BorderStyle.None

        Next objBox

    End Sub ''End of "Private Sub ClearBordersOfPictureBoxes()" 


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


    End Sub ''End of "Private Sub Load_ApplicationResources()"

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
        Dim diag_result As DialogResult
        Dim strPathToSelectedImageFile As String = ""
        Dim strPathToImageFileInGraphics As String = ""
        Dim strPathFinalOutput As String = ""

        OpenFileDialog1.InitialDirectory = DiskFolders.PathToFolder_Graphics()
        OpenFileDialog1.Filter = "JPG|*.jpg"

        diag_result = OpenFileDialog1.ShowDialog()
        If (diag_result = DialogResult.Cancel) Then
            Exit Sub
        End If

        ''Dim strPathToFolderGraphics As String = ""
        ''strPathToFolderGraphics = DiskFolders.PathToFolder_Graphics()
        strPathToSelectedImageFile = OpenFileDialog1.FileName

        ''Encapsulated 1/22/2022 td
        CopyPasteImageFileToGraphics_IfNeeded(strPathToSelectedImageFile,
                                  strPathFinalOutput) '' ,strPathToImageFileInGraphics)
        ''Added 1/22/2022
        strPathToImageFileInGraphics = strPathFinalOutput

        ''If (IO.File.Exists(strPathToSelectedImageFile)) Then
        ''
        ''    Dim objFileInfo As New IO.FileInfo(strPathToSelectedImageFile)
        ''    Dim bAlreadyInFolderGraphics As Boolean
        ''
        ''    bAlreadyInFolderGraphics = (objFileInfo.DirectoryName = strPathToFolderGraphics)
        ''
        ''    If (bAlreadyInFolderGraphics) Then
        ''
        ''        strPathToImageFileInGraphics = strPathToSelectedImageFile
        ''
        ''    Else
        ''        DiskFilesVB.CopyPasteImageFile(strPathToSelectedImageFile,
        ''                         strPathToFolderGraphics,
        ''                         strPathToImageFilePasted)
        ''        strPathToImageFileInGraphics = strPathToImageFilePasted
        ''
        ''    End If ''End of "If (False = bAlreadyInFolderGraphics) Then"
        ''
        ''End If ''End of " If (IO.File.Exists(strPathToSelectedImageFile)) Then"

        ''
        ''Important call !!  
        ''
        Load_ImageIntoContainerUsingPath(strPathToImageFileInGraphics)
        textboxPathToImageFile.Text = strPathToImageFileInGraphics

    End Sub ''End of "Private Sub ButtonBrowseForImageFile_Click"

    Private Sub CopyPasteImageFileToGraphics_IfNeeded(pstrPathToSelectedImageFile As String,
                                      ByRef pstrPathToImageFileInGraphics As String)
        ''
        ''Added 1/22/2022 thomas d. 
        ''
        ''Dim strPathToSelectedImageFile As String = ""
        Dim strPathToFolderGraphics As String = ""
        Dim strPathToImageFilePasted As String = ""
        ''Dim strPathToImageFileInGraphics As String = ""

        If (IO.File.Exists(pstrPathToSelectedImageFile)) Then

            Dim objFileInfo As New IO.FileInfo(pstrPathToSelectedImageFile)
            Dim bAlreadyInFolderGraphics As Boolean

            strPathToFolderGraphics = DiskFolders.PathToFolder_Graphics()
            bAlreadyInFolderGraphics = (objFileInfo.DirectoryName = strPathToFolderGraphics)

            If (bAlreadyInFolderGraphics) Then

                pstrPathToImageFileInGraphics = pstrPathToSelectedImageFile

            Else
                ''
                ''We will need to copy the Image file to the Graphics folder (under the
                ''   deployed application's general Images folder).
                ''
                ''Copy the image file!!!
                ''
                DiskFilesVB.CopyPasteImageFile(pstrPathToSelectedImageFile,
                                 strPathToFolderGraphics,
                                 strPathToImageFilePasted)
                pstrPathToImageFileInGraphics = strPathToImageFilePasted

            End If ''End of "If (False = bAlreadyInFolderGraphics) Then"

        End If ''End of " If (IO.File.Exists(strPathToSelectedImageFile)) Then"

ExitHandler:
        If (IO.File.Exists(pstrPathToImageFileInGraphics)) Then

            Exit Sub

        Else
            Throw New Exception("We haven't been able to copy the image to Graphics.")

        End If

    End Sub ''End of "Private Sub CopyPasteImageFileToGraphics_IfNeeded()"


End Class