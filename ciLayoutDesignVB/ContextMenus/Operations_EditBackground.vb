Option Explicit On
Option Strict On
Option Infer Off
''
''Added 10/15/2019 td
''

Imports ciBadgeInterfaces
Imports ciBadgeDesigner
''---10/15 td----
''----Imports ciBadgeElements
Imports ciLayoutPrintLib ''Added 10/15/2019 thomas d. 

Public Class Operations_EditBackground
    ''
    ''Added 10/15/2019 td
    ''
    Public WithEvents MyLinkLabel As New LinkLabel ''Added 10/11/2019 td 
    Public WithEvents MyToolstripItem As New ToolStripMenuItem ''Added 10/11/2019 td 

    Public Property CtlCurrentElement As ciBadgeDesigner.CtlGraphicFldLabel ''CtlGraphicFldLabel
    Public Property LayoutFunctions As ILayoutFunctions ''Added 10/3/2019 td 
    Public Property Designer As ciBadgeDesigner.ClassDesigner
    Public Property ColorDialog1 As ColorDialog ''Added 10/3/2019 td 
    Public Property OpenFileDialog1 As OpenFileDialog ''Added 10/15/2019 td 
    Public Property GroupedElements As ClassGroupMove ''Added 10/15/2019 td

    Public Shared Tools_MenuHeader0 As ToolStripItem ''Added 12/15/2021
    Public Shared Tools_MenuHeader1 As ToolStripItem ''Added 12/15/2021
    Public Shared Tools_MenuHeader2 As ToolStripItem ''Added 12/15/2021 
    Public Shared Tools_MenuHeader3 As ToolStripItem ''Added 12/15/2021
    Public Shared Tools_MenuSeparator As ToolStripItem ''Added 12/15/2021


    Public Sub Unselect_all_selected_Elements_EB102(sender As Object, e As EventArgs)
        ''
        ''Added 10/15/2019 td
        ''
        Me.Designer.UnselectHighlightedElements()

    End Sub ''End of "Public Sub Unselect_all_highlighted_Elements()"

    Public Sub Try_next_background_image_EB101(sender As Object, e As EventArgs)
        ''
        ''Added 10/15/2019 td
        ''
        Dim boolNoneFound As Boolean ''Added 10/15/2019 td 

        BackImageExamples.CurrentIndex += 1
        BackImageExamples.PathToFolderWithBacks = DiskFolders.PathToFolder_BackExamples
        Me.Designer.BackgroundBox_Front.Image = BackImageExamples.GetCurrentImage(boolNoneFound)



    End Sub ''End of "Public Sub Change_Background_Image()"

    Public Sub Select_background_image_EB100(sender As Object, e As EventArgs)
        ''
        ''Added 10/15/2019 td
        ''
        Dim open_image As Bitmap ''Added 10/15/2019 thomas d. 
        Dim strFullPathToBitmap As String

        If OpenFileDialog1 Is Nothing Then OpenFileDialog1 = New OpenFileDialog
        OpenFileDialog1.ShowDialog()
        strFullPathToBitmap = OpenFileDialog1.FileName

        If ("" <> strFullPathToBitmap) Then
            open_image = New Bitmap(strFullPathToBitmap)
            Me.Designer.BackgroundBox_Front.Image = open_image
        End If ''End of "If ("" = strFullPathToBitmap) Then"

    End Sub ''End of "Public Sub Change_Background_Image()"


    Public Sub How_Context_Menus_Are_Generated_EB9001(sender As Object, e As EventArgs)
        ''
        ''Added 12/15/2021 thomas downes  
        ''
        Dim strPathToNotesFolder As String
        Dim strPathToNotesFileTXT As String

        strPathToNotesFolder = DiskFolders.PathToFolder_Notes()
        strPathToNotesFileTXT = DiskFilesVB.PathToNotes_HowContextMenusAreGenerated()
        System.Diagnostics.Process.Start(strPathToNotesFileTXT)

    End Sub ''end of "Public Sub How_Context_Menus_Are_Generated_EE1002(sender As Object, e As EventArgs)"




End Class
