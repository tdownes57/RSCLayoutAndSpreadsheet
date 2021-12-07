''
''Added 11/25/2021 thomas downes
''
Imports ciLayoutPrintLib ''added 11/25 

Public Class FormListBackgrounds

    Public ImageFilePath As String
    Public ImageFileInfo As System.IO.FileInfo

    Public TemporarySelectedFileInfo As System.IO.FileInfo

    ''
    ''Added 11/25/2021 thomas downes
    ''
    Public Sub LoadSelection(par_controlBack As CtlBackground)
        ''
        ''Added 11/25/2021 thomas downes
        ''
        Dim boolNotParameter As Boolean

        Me.TemporarySelectedFileInfo = par_controlBack.ImageFileInfo

        For Each ctlBack As CtlBackground In FlowLayoutPanel1.Controls

            boolNotParameter = (ctlBack IsNot par_controlBack)
            If (boolNotParameter) Then ctlBack.LoadIsSelectedValue(False)

        Next ctlBack

    End Sub

    Private Sub FormListBackgrounds_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 11/25/2021 thomas downes
        ''
        DeleteControlsDevoidOfData()

        LoadControlsFromFolderImagesBack()

    End Sub

    Private Sub buttonOK_Click(sender As Object, e As EventArgs) Handles buttonOK.Click
        ''
        ''Added 11/25/2021 thomas downes
        ''
        Me.ImageFileInfo = Me.TemporarySelectedFileInfo
        Me.ImageFilePath = Me.TemporarySelectedFileInfo.FullName

        ''
        ''Open the dialog for addressing dimensional ratios.
        ''---12/2/2021 thomas d.
        ''
        Dim objChildDialog As New FormUploadDimensionsMsg
        objChildDialog.UploadedImageFile(Me.ImageFilePath)
        objChildDialog.ShowDialog()

        ''Close the form.  
        Me.Close()

    End Sub


    Private Sub DeleteControlsDevoidOfData()
        ''Added 11/25/2021 td
        ''---FlowLayoutPanel1.Controls.Clear()
        For Each each_ctlBack As CtlBackground In FlowLayoutPanel1.Controls
            If (each_ctlBack.ImageFileInfo Is Nothing) Then
                FlowLayoutPanel1.Controls.Remove(each_ctlBack)
            End If
        Next each_ctlBack
        ''Fuck it, let's just make sure it's all cleared. 
        If (0 < FlowLayoutPanel1.Controls.Count) Then
            ''Throw New Exception("Controls still left in FlowLayoutPanel.")
            FlowLayoutPanel1.Controls.Clear()
        End If
    End Sub



    Private Sub LoadControlsFromFolderImagesBack()
        ''
        '' added 11/25
        ''
        Dim boolNoneFound As Boolean ''Added 10/15/2019 td 
        Dim strFolderPath As String

        BackImageExamples.CurrentIndex += 1

        strFolderPath = DiskFolders.PathToFolder_BackExamples
        BackImageExamples.PathToFolderWithBacks = strFolderPath

        ''//------Me.Designer.BackgroundBox.Image = BackImageExamples.GetCurrentImage(boolNoneFound)

        Dim listFiles As IO.FileInfo()
        listFiles = (New IO.DirectoryInfo(strFolderPath)).GetFiles("*.jpg") '' ("*.jpg,*.png")

        For Each eachFileInfo As IO.FileInfo In listFiles
            ''Added 11/25/2021 td
            Dim new_ctlBack As New CtlBackground()
            new_ctlBack.Visible = True
            FlowLayoutPanel1.Controls.Add(new_ctlBack)
            new_ctlBack.LoadImageFileByFileInfo(eachFileInfo, False)
            ''new_ctlBack.ParentForm = Me
            new_ctlBack.ParentListingForm = Me
        Next eachFileInfo

    End Sub ''End of "Private Sub LoadControlsFromFolderImagesBack()"

    Private Sub buttonCancel_Click(sender As Object, e As EventArgs) Handles buttonCancel.Click

        Me.Close() ''Added 11/26/2021 thomas downes 

    End Sub
End Class