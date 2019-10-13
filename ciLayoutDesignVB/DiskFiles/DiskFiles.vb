Option Explicit On
Option Strict On
''
''Added 10/12/2019 Thomas Downes    
''
Public Class DiskFiles
    ''
    ''Added 10/12/2019 Thomas Downes    
    ''
    Public Shared Function PathToFile_Sig() As String
        ''
        ''Added 10/12/2019 Thomas Downes    
        ''
        Return My.Application.Info.DirectoryPath & "\Images\Signatures\Declaration_bmp.bmp"

    End Function ''Endo f "Public Shared Function PathToFile_Sig() As String"

    Public Shared Function PathToFile_XML() As String
        ''
        ''Added 10/12/2019 Thomas Downes    
        ''
        Dim strPathToXML As String

        strPathToXML = (My.Application.Info.DirectoryPath & "\ciLayoutDesignVB_Saved.xml").Replace("\\", "\")

        Return strPathToXML

    End Function ''End of "Public Shared Function PathToFile_XML() As String"




End Class ''eND OF "Public Class DiskFiles"
