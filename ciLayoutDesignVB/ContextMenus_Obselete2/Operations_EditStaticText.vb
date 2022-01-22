Option Explicit On
Option Strict On
Option Infer Off
''
''Added 12/12/2021 td
''
Imports ciBadgeInterfaces
Imports ciBadgeDesigner
''----Imports ciBadgeElements

Public Class Operations_EditStaticText
    ''
    ''Added 12/12/2021 td
    ''
    Public Property Parent_MenuCache As MenuCache_StaticText ''Added 12/15/2021 td 

    Public WithEvents MyLinkLabel As New LinkLabel ''Added 10/11/2019 td 
    Public WithEvents MyToolstripItem As New ToolStripMenuItem ''Added 10/11/2019 td 

    Public Property CtlCurrentElement As ciBadgeDesigner.CtlGraphicStaticText ''CtlGraphicFldLabel
    Public Property LayoutFunctions As ILayoutFunctions ''Added 10/3/2019 td 
    Public Property Designer As ciBadgeDesigner.ClassDesigner
    Public Property ColorDialog1 As ColorDialog ''Added 10/3/2019 td 
    Public Property FontDialog1 As FontDialog ''Added 10/3/2019 td 

    ''---not needed 10/3/2019 td----Public Property GroupEdits As ClassGroupMove ''Added 10/3/2019 td 
    Public Property SelectingElements As ISelectingElements ''Added 10/3/2019 td 

    Public Property CacheOfFieldsEtc As ciBadgeCachePersonality.ClassElementsCache_Deprecated


    Private Sub GiveSizeInfo_Field_EST100(sender As Object, e As EventArgs)
        ''
        ''Added 7/31/2019 thomas downes
        ''       ''
        ''   We will use Reflection to convert the procedures in class Operations_EditFieldElement to clickable LinkLabels.
        ''      (See procedure MenuCache_FieldElements.Generate_BasicEdits().)
        ''
        Dim strMessageToUser As String = ""

        ''strMessageToUser &= (vbCrLf & $"Height of Picture control: {pictureLabel.Height}")
        ''strMessageToUser &= (vbCrLf & $"Height of Custom Graphics control: {Me.Height}")
        ''strMessageToUser &= (vbCrLf & $"Element-Base-Info Property (Height): {Me.ElementInfo_Base.Height_Pixels}")
        ''strMessageToUser &= (vbCrLf & $"Picture control's Image Height: {pictureLabel.Image.Height}")

        MessageBox.Show(strMessageToUser, "994938", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub ''End of "Private Sub GiveSizeInfo_Field(sender As Object, e As EventArgs)"

    Private Sub OpenDialog_Color_EST101(sender As Object, e As EventArgs)
        ''
        ''Added 7/30/2019 thomas downes
        ''       ''
        ''   We will use Reflection to convert the procedures in class Operations_EditFieldElement to clickable LinkLabels.
        ''      (See procedure MenuCache_FieldElements.Generate_BasicEdits().)
        ''
        ColorDialog1.ShowDialog()

        ''''7/30/2019 td''Me.ElementInfo.FontColor = ColorDialog1.Color
        ''''8/29/2019 td''Me.ElementInfo.BackColor = ColorDialog1.Color
        ''Me.ElementInfo_Base.Back_Color = ColorDialog1.Color

        ''Me.ElementInfo_Base.Width_Pixels = Me.Width
        ''Me.ElementInfo_Base.Height_Pixels = Me.Height

        ''Application.DoEvents()
        ''Application.DoEvents()

        ''Refresh_Image(True)
        ''Me.Refresh()

    End Sub ''eNd of "Private Sub opendialog_Color()"

    Private Sub OpenDialog_Font(sender As Object, e As EventArgs)
        ''
        ''Added 7/30/2019 thomas downes
        ''
        ''FontDialog1.Font = Me.ElementInfo_TextOnly.Font_DrawingClass
        ''FontDialog1.ShowDialog()

        ''Me.ElementInfo_TextOnly.Font_DrawingClass = FontDialog1.Font

        ''Application.DoEvents()
        ''Application.DoEvents()

        ''Refresh_Image(True)
        ''Me.Refresh()

    End Sub ''eNd of "Private Sub opendialog_Color()"


    Public Sub Enable_DragAndDrop_EE1012(sender As Object, e As EventArgs)
        ''
        ''Added 12/15/2021 thomas downes
        ''  Remove drag-and-drop functionality, if requested.  
        ''  


    End Sub


    Public Sub Disable_DragAndDrop_EE1013(sender As Object, e As EventArgs)
        ''
        ''Added 12/15/2021 thomas downes
        ''  Reactivate drag-and-drop functionality, if needed.  
        ''


    End Sub ''End of "Public Sub Disable_DragAndDrop_EE1013(sender As Object, e As EventArgs)"


    Public Sub Visibility_Link_To_Be_Displayed_EE1014(sender As Object, e As EventArgs)
        ''
        ''Added 12/27/2021 thomas downes
        ''  Show the link which controls the Visibility of the Element.  
        ''


    End Sub ''End of "Public Sub Visibility_Link_To_Be_Displayed_EE1014(sender As Object, e As EventArgs)"


    Public Sub Visibility_Link_To_Be_Hidden_EE1015(sender As Object, e As EventArgs)
        ''
        ''Added 12/27/2021 thomas downes
        ''  Hide the link which controls the Visibility of the Element.  
        ''


    End Sub ''End of "Public Sub Visibility_Link_To_Be_Hidden_EE1014(sender As Object, e As EventArgs)"


    Public Sub How_Context_Menus_Are_Generated_EE1002(sender As Object, e As EventArgs)
        ''
        ''Added 12/12/2021 thomas downes  
        ''
        Dim strPathToNotesFolder As String
        Dim strPathToNotesFileTXT As String

        strPathToNotesFolder = DiskFolders.PathToFolder_Notes()
        strPathToNotesFileTXT = DiskFilesVB.PathToNotes_HowContextMenusAreGenerated()
        System.Diagnostics.Process.Start(strPathToNotesFileTXT)

    End Sub ''end of "Public Sub How_Context_Menus_Are_Generated_EE1002(sender As Object, e As EventArgs)"


End Class
