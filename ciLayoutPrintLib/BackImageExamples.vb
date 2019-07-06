''
''Added 6/13/2019 td  
''
Imports System.Drawing ''Added 6/13/2019 td  
Imports System.Windows.Forms ''added 6/13 td

Public Class BackImageExamples
    ''6/13/2019 td''Public Class PictureExamples
    ''
    ''Added 6/13/2019 td  
    ''
    Private Shared mod_images As List(Of Image)

    Private Shared mod_currentIndex As Integer ''Added 7/5/2019 td  

    Public Shared Function Item(par_intChoice As Integer) As Image

        ''Added 7/5/2019 thomas downes
        ''
        mod_currentIndex = par_intChoice ''Added 7/5/2019 td

        Return mod_images.Item(par_intChoice)

    End Function ''End of "Public Shared Function Item(par_intChoice As Integer) As Image"

    Public Shared Function GetExample() As Image  ''6/13/2019 td''As System.Drawing.Image
        ''
        ''Added 6/13/2019 td  
        ''
        Static s_intCallIndex As Integer

        ''See bottom.''s_intCallIndex += 1

        If (s_intCallIndex >= mod_images.Count) Then s_intCallIndex = 0

        If (mod_images Is Nothing) Then mod_images = GetListOfImages()

        Return mod_images(s_intCallIndex)

ExitHandler:
        mod_currentIndex = s_intCallIndex ''Added 7/5/2019 td 
        s_intCallIndex += 1
    End Function ''End of "Public Shared Function GetExample() As Image"

    Public Function Count() As Integer

        ''Added 7/5/2019 thomas downes 
        Return mod_images.Count()

    End Function

    Public Shared Property CurrentIndex() As Integer
        ''
        ''Added 7/5/2019 Thomas DOWNES
        ''
        Get
            Return mod_currentIndex
        End Get
        Set(value As Integer)
            mod_currentIndex = value
        End Set
    End Property ''End of "Public Shared Function CurrentIndex() As Integer"

    Public Shared Sub AddImage(par_image As Image)
        ''
        ''Added 7/4/2019 thomas downes
        ''
        mod_images.Add(par_image)

    End Sub ''End of "Public Shared Sub AddImage(par_image As Image)"

    Public Shared Function GetLatestImage() As Image
        ''
        ''Added 7/4/2019 thomas downes
        ''
        If (mod_images Is Nothing) Then mod_images = GetListOfImages()

        Return mod_images.Where(Function(a_image) True).Last

    End Function ''End of "Public Shared Function GetLatestImage(par_image As Image)"

    Private Shared Function GetListOfImages() As List(Of Image)
        ''
        ''Added 6/13/2019 thomas downes 
        ''
        Dim strPathToFolderWithPics As String
        Dim all_Jpegs As IEnumerable(Of System.IO.FileInfo)
        Dim picture_box As New System.Windows.Forms.PictureBox
        Dim output_list = New List(Of Image)

        ''6/13 td''strPathToFolderWithPics = My.Application.Info.DirectoryPath & "\PictureExamples"
        ''7/5 td''strPathToFolderWithPics = My.Application.Info.DirectoryPath & "\BackImageExamples"
        strPathToFolderWithPics = "C:\CI Solutions\CI Badge Web\ciPictures_VB\BackExamples"

        all_Jpegs = (New System.IO.DirectoryInfo(strPathToFolderWithPics)).EnumerateFiles()

        For Each each_file As System.IO.FileInfo In all_Jpegs
            With picture_box
                .ImageLocation = each_file.FullName
                .Visible = True
                .Refresh()
                If (.Image IsNot Nothing) Then output_list.Add(.Image)
            End With
        Next each_file

        Return output_list

    End Function

End Class  ''End of "Public Class PictureExamples"





