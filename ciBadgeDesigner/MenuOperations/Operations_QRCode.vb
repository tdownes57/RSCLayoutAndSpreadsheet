Option Explicit On
Option Strict On
Option Infer Off
''
''Added 12/12/2021 td
''
Imports ciBadgeInterfaces
Imports ciBadgeDesigner
''----Imports ciBadgeElements
Imports __RSCWindowsControlLibrary ''Added 1/2/2022 td 

Public Class Operations_QRCode
    Inherits Operations__Graphic
    ''Jan17 2022 ''Implements ICurrentElement ''Added 12/28/2021 td
    ''Jan17 2022 ''Public Property CtlCurrentElement As RSCMoveableControlVB Implements ICurrentElement.CtlCurrentElement

    ''
    ''Added 12/12/2021 td
    ''
    Public Overrides Property Element_Type As Enum_ElementType = Enum_ElementType.QRCode ''Added 1/21/2022 td



    Public Sub Context_Menu_QR9121(sender As Object, e As EventArgs)
        ''---Dec15 2021--Public Sub How_Context_Menus_Are_Generated_EE1001
        ''
        ''Added 3/22/2023 thomas downes  
        ''
        ''   We will use Reflection to convert the procedures in class Operations_EditFieldElement to clickable LinkLabels.
        ''      (See procedure MenuCache_FieldElements.Generate_BasicEdits().)
        ''
        ''
        Dim strPathToNotesFolder As String
        Dim strPathToNotesFileTXT As String

        strPathToNotesFolder = DiskFolders.PathToFolder_Notes()
        strPathToNotesFileTXT = DiskFilesVB.PathToNotes_HowContextMenusAreGenerated()
        System.Diagnostics.Process.Start(strPathToNotesFileTXT)

    End Sub ''end of "Public Sub Context_Menu_QR9121(sender As Object, e As EventArgs)"


End Class
