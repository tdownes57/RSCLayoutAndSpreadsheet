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

    Public Shared Function PathToFile_XML_Personality() As String
        ''
        ''Added 1/14/2020 Thomas Downes    
        ''
        Dim strPathToXML As String

        ''The following line will allow the File | Save As....
        ''   menu item to be effective. ----10/13/2019 td
        strPathToXML = My.Settings.PathToXML_Saved_Personality

        If ("" = strPathToXML) Then
            ''1/24 td''strPathToXML = (My.Application.Info.DirectoryPath & "\ciLayoutDesignVB_Saved.xml").Replace("\\", "\")
            strPathToXML = (My.Application.Info.DirectoryPath & "\ciPersonality_Saved.xml").Replace("\\", "\")
        End If ''End of "If ("" = strPathToXML) Then"

        Return strPathToXML

    End Function ''End of "Public Shared Function PathToFile_XML_Personality() As String"

    Public Shared Function PathToFile_XML_ElementsCache() As String
        ''1/14/2020 td'Public Shared Function PathToFile_XML_ElementsCache() As String
        ''
        ''Added 10/12/2019 Thomas Downes    
        ''
        Dim strPathToXML As String

        ''The following line will allow the File | Save As....
        ''   menu item to be effective. ----10/13/2019 td
        strPathToXML = My.Settings.PathToXML_Saved_ElementsCache

        If ("" = strPathToXML) Then
            strPathToXML = (My.Application.Info.DirectoryPath & "\ciLayoutDesignVB_Saved.xml").Replace("\\", "\")
        End If ''End of "If ("" = strPathToXML) Then"

        Return strPathToXML

    End Function ''End of "Public Shared Function PathToFile_XML_ElementsCache() As String"



End Class ''eND OF "Public Class DiskFiles"
