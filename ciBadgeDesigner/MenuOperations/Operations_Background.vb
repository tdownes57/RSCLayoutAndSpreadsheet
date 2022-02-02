Option Explicit On
Option Strict On
Option Infer Off
''
''Added 10/15/2019 td
''

''Imports ciBadgeInterfaces
''Imports ciBadgeDesigner
''Imports System.Windows.Forms ''Added 12/30/2021 td 
''''---10/15 td----
''''----Imports ciBadgeElements
''Imports ciLayoutPrintLib ''Added 10/15/2019 thomas d. 
Imports System.Drawing ''Added 12/30/20021 td

Imports ciBadgeInterfaces
Imports ciBadgeDesigner
Imports ciBadgeElements
Imports __RSCWindowsControlLibrary ''Added 1/2/2022 td 
Imports ciBadgeCachePersonality ''Added 1/18/2022 td


Public Class Operations_Background
    Inherits Operations_Desktop
    ''----Jan30 2022 td''Inherits Operations__Desktop_Dummy
    ''----Jan22 2022 td''Inherits Operations__Graphic
    ''
    ''Added 10/15/2019 td
    ''
    ''Jan22 2022''Public WithEvents MyLinkLabel As New LinkLabel ''Added 10/11/2019 td 
    ''Jan22 2022''Public WithEvents MyToolstripItem As New ToolStripMenuItem ''Added 10/11/2019 td 

    ''Jan22 2022''Public Overrides Property Element_Type As Enum_ElementType = Enum_ElementType.__Background ''Added 1/21/2022 td 


    ''Jan22 2022''Public Property CtlCurrentElement As ciBadgeDesigner.CtlGraphicFldLabel ''CtlGraphicFldLabel
    ''Jan22 2022''Public Property LayoutFunctions As ILayoutFunctions ''Added 10/3/2019 td 
    ''Not needed here. Feb2 2022 ''Public Property DesignerClass As ciBadgeDesigner.ClassDesigner

    Public Property ColorDialog1 As ColorDialog ''Added 10/3/2019 td 
    Public Property OpenFileDialog1 As OpenFileDialog ''Added 10/15/2019 td 
    Public Property GroupedElements As GroupMoveEvents_Singleton ''ClassGroupMove ''Renamed 12/30/2021 td ''Added 10/15/2019 td

    Public Shared Tools_MenuHeader0 As ToolStripItem ''Added 12/15/2021
    Public Shared Tools_MenuHeader1 As ToolStripItem ''Added 12/15/2021
    Public Shared Tools_MenuHeader2 As ToolStripItem ''Added 12/15/2021 
    Public Shared Tools_MenuHeader3 As ToolStripItem ''Added 12/15/2021
    Public Shared Tools_MenuSeparator As ToolStripItem ''Added 12/15/2021

    Private mod_operationsDesktop As Operations_Desktop ''Added 1/22/2022 td
    Public Overloads Property CtlCurrentElement As Control ''Added 1/22/2022  
    Public Property CtlCurrentPicturebox As PictureBox ''Added 1/22/2022 td  


    ''Public Sub Create_New_StaticText_Control_V3_GD2081(sender As Object, par_e As MouseEventArgs)
    ''    ''
    ''    ''Added 1/16/2022 thomas downes  
    ''    ''
    ''    InitializeOperationsDesktop_IfNeeded() ''Must initialize the supporting Operations. 

    ''    ''Dim new_eventArgs As MouseEventArgs
    ''    ''Dim intArgsClick As Integer = 0
    ''    ''Dim intArgsDelta As Integer = 0

    ''    ''new_eventArgs = New MouseEventArgs(MouseButtons.Right, intArgsClick,
    ''    ''        e.X + CtlCurrentPicturebox.Left,
    ''    ''        e.Y + CtlCurrentPicturebox.Top,
    ''    ''        intArgsDelta)

    ''    ''mod_operationsDesktop.Create_New_StaticText_Control_GD2001(sender, new_eventArgs)

    ''    ''
    ''    ''Major call !!
    ''    ''
    ''    ''Jan31 2022 td''mod_operationsDesktop.Create_New_StaticText_Control_GD2001(sender, Get_EventArgs_ShiftPosition(par_e))
    ''    mod_operationsDesktop.Create_New_StaticText_Control_V3_GD2001(sender, Get_EventArgs_ShiftPosition(par_e))

    ''End Sub ''End of "Public Sub Create_New_StaticText_Control_V3_GD2081"


    ''Public Sub Create_New_StaticText_Control_V4_GD2081(sender As Object, par_e As MouseEventArgs)
    ''    ''
    ''    ''Added 1/31/2022 thomas downes  
    ''    ''
    ''    InitializeOperationsDesktop_IfNeeded() ''Must initialize the supporting Operations. 

    ''    mod_operationsDesktop.Create_New_StaticText_Control_V4_GD2001(sender, Get_EventArgs_ShiftPosition(par_e))

    ''End Sub ''End of "Public Sub Create_New_StaticText_Control_V4_GD2081"

    ''Public Sub Create_New_Graphics_Control_GD2041(sender As Object, par_e As MouseEventArgs)
    ''    ''
    ''    ''Added 1/22/2022 thomas downes  
    ''    ''
    ''    InitializeOperationsDesktop_IfNeeded()

    ''    ''
    ''    ''Major call !!
    ''    ''
    ''    mod_operationsDesktop.Create_New_Graphic_Control_GD2002(sender, Get_EventArgs_ShiftPosition(par_e))


    ''End Sub ''End of "Public Sub Create_New_Graphics_Control_GD2041"


    ''Public Sub Create_New_StaticText_Control_GD2001(sender As Object, e As MouseEventArgs)
    ''    ''
    ''    ''Added 1/16/2022 thomas downes  
    ''    ''


    ''End Sub


    Public Sub Unselect_all_selected_Elements_EB102(sender As Object, e As EventArgs)
        ''
        ''Added 10/15/2019 td
        ''       ''
        ''   We will use Reflection to convert the procedures in class Operations_EditFieldElement to clickable LinkLabels.
        ''      (See procedure MenuCache_FieldElements.Generate_BasicEdits().)
        ''
        Me.DesignerClass.UnselectHighlightedElements()

    End Sub ''End of "Public Sub Unselect_all_highlighted_Elements()"

    ''Public Sub Try_next_background_image_EB101(sender As Object, e As EventArgs)
    ''    ''
    ''    ''Added 10/15/2019 td
    ''    ''       ''
    ''    ''   We will use Reflection to convert the procedures in class Operations_EditFieldElement to clickable LinkLabels.
    ''    ''      (See procedure MenuCache_FieldElements.Generate_BasicEdits().)
    ''    ''
    ''    Dim boolNoneFound As Boolean ''Added 10/15/2019 td 
    ''
    ''    BackImageExamples.CurrentIndex += 1
    ''    BackImageExamples.PathToFolderWithBacks = DiskFolders.PathToFolder_BackExamples
    ''    Me.Designer.BackgroundBox_Front.Image = BackImageExamples.GetCurrentImage(boolNoneFound)
    ''End Sub ''End of "Public Sub Change_Background_Image()"

    Public Sub Select_background_image_EB100(sender As Object, e As EventArgs)
        ''
        ''Added 10/15/2019 td
        ''       ''
        ''   We will use Reflection to convert the procedures in class Operations_EditFieldElement to clickable LinkLabels.
        ''      (See procedure MenuCache_FieldElements.Generate_BasicEdits().)
        ''
        Dim open_image As Bitmap ''Added 10/15/2019 thomas d. 
        Dim strFullPathToBitmap As String

        If OpenFileDialog1 Is Nothing Then OpenFileDialog1 = New OpenFileDialog
        OpenFileDialog1.ShowDialog()
        strFullPathToBitmap = OpenFileDialog1.FileName

        If ("" <> strFullPathToBitmap) Then
            open_image = New Bitmap(strFullPathToBitmap)
            Me.DesignerClass.BackgroundBox_Front.Image = open_image
        End If ''End of "If ("" = strFullPathToBitmap) Then"

    End Sub ''End of "Public Sub Change_Background_Image()"


    ''Public Sub How_Context_Menus_Are_Generated_EB9001(sender As Object, e As EventArgs)
    ''    ''
    ''    ''Added 12/15/2021 thomas downes  
    ''    ''       ''
    ''    ''   We will use Reflection to convert the procedures in class Operations_EditFieldElement to clickable LinkLabels.
    ''    ''      (See procedure MenuCache_FieldElements.Generate_BasicEdits().)
    ''    ''
    ''    Dim strPathToNotesFolder As String
    ''    Dim strPathToNotesFileTXT As String

    ''    strPathToNotesFolder = DiskFolders.PathToFolder_Notes()
    ''    strPathToNotesFileTXT = DiskFilesVB.PathToNotes_HowContextMenusAreGenerated()
    ''    System.Diagnostics.Process.Start(strPathToNotesFileTXT)

    ''End Sub ''end of "Public Sub How_Context_Menus_Are_Generated_EE1002(sender As Object, e As EventArgs)"


    Private Sub InitializeOperationsDesktop_IfNeeded()
        ''
        ''Added 1/22/2022 td
        ''
        If (mod_operationsDesktop Is Nothing) Then
            ''
            ''Added 1/22/2022 td
            ''
            mod_operationsDesktop = New Operations_Desktop

            ''mod_operationsDesktop.CtlCurrentElement = Me.CtlCurrentElement
            ''mod_operationsDesktop.CtlCurrentElement = Me.CtlCurrentPicturebox

            With mod_operationsDesktop
                .CtlCurrentControl = Me.CtlCurrentPicturebox
                .ParentDesignerForm = Me.ParentDesignerForm
                .ParentForm = Me.ParentForm
                .DesignerClass = Me.DesignerClass
            End With

        End If ''End of "If (mod_operationsDesktop Is Nothing) Then"

    End Sub


    Private Function Get_EventArgs_ShiftPosition(par_e As MouseEventArgs) As MouseEventArgs
        ''
        ''Added 1/22/2022 td
        ''
        Dim new_eventArgs As MouseEventArgs
        Dim intArgsClick As Integer = 0
        Dim intArgsDelta As Integer = 0

        new_eventArgs = New MouseEventArgs(MouseButtons.Right, intArgsClick,
                par_e.X + CtlCurrentPicturebox.Left,
                par_e.Y + CtlCurrentPicturebox.Top,
                intArgsDelta)

        Return new_eventArgs

    End Function


End Class
