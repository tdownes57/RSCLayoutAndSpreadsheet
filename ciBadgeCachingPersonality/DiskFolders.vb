Option Explicit On
Option Strict On
''
''Added 10/14/2019 Thomas Downes    
''
Public Class DiskFolders
    ''
    ''Added 10/14/2019 Thomas Downes    
    ''
    Public Shared Function PathToFolder_Production(par_strSuffix As String) As String
        ''
        ''Added 10/18/2019 Thomas Downes    
        ''
        Dim strOutput As String
        strOutput = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Prod_" & par_strSuffix)
        System.IO.Directory.CreateDirectory(strOutput)
        Return strOutput

    End Function ''End of "Public Shared Function PathToFile_Production() As String"

    Public Shared Function PathToFolder_Preview() As String
        ''
        ''Added 10/12/2019 Thomas Downes    
        ''
        ''10/14/2019 td''Return System.IO.Directory.GetCurrentDirectory()
        Dim strOutput As String
        strOutput = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "LayoutPreview")
        System.IO.Directory.CreateDirectory(strOutput)
        Return strOutput

    End Function ''Endo f "Public Shared Function PathToFile_Preview() As String"

    Public Shared Function PathToFolder_BackExamples() As String
        ''
        ''Added 10/12/2019 Thomas Downes    
        ''
        Return System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Images\BackExamples")

    End Function ''End of "Public Shared Function PathToFolder_BackExamples() As String"

    Public Shared Function PathToFolder_PicExamples() As String
        ''
        ''Added 10/12/2019 Thomas Downes    
        ''
        Return System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Images\PictureExamples")

    End Function ''End of "Public Shared Function PathToFolder_PicExamples() As String"




End Class ''eND OF "Public Class DiskFolders"
