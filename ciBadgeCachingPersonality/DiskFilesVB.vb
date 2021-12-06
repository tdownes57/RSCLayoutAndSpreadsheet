Option Explicit On ''Added 12/5/2021 thomas downes 
Option Strict On ''Added 12/5/2021 thomas downes
''
''Added 12/5/2021 thomas downes 
''
Imports System.IO ''Added 12/5/2021 thomas downes

Module DiskFilesVB
    ''
    ''Added 12/5/2021 thomas downes 
    ''
    Public Sub DisplayStringDataInNotepad(ByRef par_stringData As String)
        ''
        ''Copied from Form__Main_Demo.vb on 12/5/2021 td   
        ''Added 11/28/2021 thomas downes  
        ''
        Dim strRandomFolder As String
        Dim strRandomFilePath As String
        Dim strRandomTitle As String

        strRandomFolder = DiskFolders.PathToFolder_Preview()
        strRandomTitle = String.Format("Elements {0:HHmmss}.txt", DateTime.Now)
        strRandomFilePath = System.IO.Path.Combine(strRandomFolder, strRandomTitle)
        System.IO.File.WriteAllText(strRandomFilePath, par_stringData)
        System.Threading.Thread.Sleep(1000)
        System.Threading.Thread.Sleep(1000)
        System.Diagnostics.Process.Start(strRandomFilePath)

    End Sub ''ENd of "Public Shared Sub DisplayStringDataInNotepad()"


End Module
