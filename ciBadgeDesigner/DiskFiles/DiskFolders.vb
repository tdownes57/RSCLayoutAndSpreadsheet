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


    Public Shared Function PathToFolder_BackImagesUploaded() As String
        ''
        ''Added 5/23/2022 Thomas Downes    
        ''
        Return System.IO.Path.Combine(My.Application.Info.DirectoryPath,
                                      "Images\BackgroundImagesUploaded")

    End Function ''End of "Public Shared Function PathToFolder_BackImagesUploaded() As String"


    Public Shared Function PathToFolder_BackImageExamples() As String
        ''5/23/2022 Public Shared Function PathToFolder_BackImageExamples() As String
        ''
        ''The syllable "Back" means "Background (of Layout)". 
        ''
        ''Added 10/12/2019 Thomas Downes    
        ''
        ''May23 2022 Return System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Images\BackExamples")
        Return System.IO.Path.Combine(My.Application.Info.DirectoryPath,
                                      "Images\BackgroundExampleDemos")

    End Function ''End of "Public Shared Function PathToFolder_BackExamples() As String"


    Public Shared Function PathToFolder_Graphics() As String
        ''
        ''Added 10/12/2019 Thomas Downes    
        ''
        Return System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Images\Graphics")

    End Function ''End of "Public Shared Function PathToFolder_BackExamples() As String"


    Public Shared Function PathToFolder_PicExamples() As String
        ''
        ''Added 10/12/2019 Thomas Downes    
        ''
        Return System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Images\PictureExamples")

    End Function ''End of "Public Shared Function PathToFolder_PicExamples() As String"


    Public Shared Function PathToFolder_XML() As String
        ''
        ''Added 12/20/2021 Thomas Downes    
        ''
        Return System.IO.Path.Combine(My.Application.Info.DirectoryPath, "XML")

    End Function ''End of "Public Shared Function PathToFolder_PicExamples() As String"


    Public Shared Function PathToFolder_BadgeLayoutImages() As String
        ''
        ''Added 12/09/2021 Thomas Downes    
        ''
        ''        Badge Layout Images - Read Me 
        ''
        ''This folder (Images\BadgeLayoutImages) Is for storing badge layouts, Not in XML,
        ''  but in Image form (Jpeg).
        ''
        ''This will allow the user To quickly see what the Layout looks Like, in particular 
        ''   when reviewing multiple layouts.  
        ''
        ''This will allow the user To pick among >1 attempt at designing the right badge, 
        ''   With the look & information that Is required.  Especially If a year has gone 
        ''   by since the previous year's badge. 
        ''
        ''            The images will probably be full-sized And will probably be named via the 6-digit Guid 
        ''   which is associated with the Elements (Or perhaps "Layout") cache.  On second thought, why not
        ''   simply name the image the same as the XML file of the cache?  E.g. "Yellow and black.jpg" for 
        ''   "Yellow and black.xml" or "Seniors 2021.jpg" for "Seniors 2021.xml".  
        ''
        ''-----12/9/2021 thomas downes
        ''
        Return System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Images\BadgeLayoutImages")

    End Function ''End of "Public Shared Function PathToFolder_PicExamples() As String"

    Public Shared Function PathToFolder_Notes() As String
        ''
        ''Added 12/12/2021 Thomas Downes    
        ''
        Return System.IO.Path.Combine(My.Application.Info.DirectoryPath, "__Notes")

    End Function ''End of "Public Shared Function PathToFolder_Notes() As String"

    Public Shared Function PathToFolder_Images() As String
        ''
        ''Added 1/21/2021 Thomas Downes    
        ''
        Return System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Images")

    End Function ''End of "Public Shared Function PathToFolder_Notes() As String"


End Class ''eND OF "Public Class DiskFolders"
