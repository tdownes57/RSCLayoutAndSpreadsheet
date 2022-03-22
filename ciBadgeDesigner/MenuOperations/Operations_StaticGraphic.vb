Option Explicit On
Option Strict On
Option Infer Off
''
''Added 12/13/2021 td
''

Imports ciBadgeInterfaces
''Imports ciBadgeDesigner
''---10/15 td----
''----Imports ciBadgeElements
''Imports ciLayoutPrintLib ''Added 10/15/2019 thomas d. 
Imports System.Windows.Forms ''Added 12/30/2021 
Imports System.Drawing ''Added 12/31/2021 td 
Imports __RSCWindowsControlLibrary ''Added 1/8/2022 td


Public Class Operations_StaticGraphic
    Inherits Operations__Graphic

    ''Jan17 2022 ''Implements ICurrentElement ''Added 1/08/2022 td

    ''Added 1/08/2022 td
    ''Jan17 2022 ''Public Property CtlCurrentElement As RSCMoveableControlVB Implements ICurrentElement.CtlCurrentElement

    ''
    ''Added 12/13/2021 td
    ''
    Public WithEvents MyLinkLabel As New LinkLabel ''Added 10/11/2019 td 
    Public WithEvents MyToolstripItem As New ToolStripMenuItem ''Added 10/11/2019 td 

    ''Jan8 2022 td''Public Property CtlCurrentElement As ciBadgeDesigner.CtlGraphicFldLabel ''CtlGraphicFldLabel

    Public Property LayoutFunctions As ILayoutFunctions ''Added 10/3/2019 td 
    Public Property Designer As ciBadgeDesigner.ClassDesigner
    ''----Public Property ColorDialog1 As ColorDialog ''Added 10/3/2019 td 
    Public Property OpenFileDialog1 As OpenFileDialog ''Added 10/15/2019 td 
    Public Property ColorDialog1 As ColorDialog ''Added 12/13/2021 td 
    Public Overrides Property Element_Type As Enum_ElementType = Enum_ElementType.StaticGraphic ''Added 1/21/2022 td



    ''Private Property ICurrentElement_CtlCurrentElement As __RSCWindowsControlLibrary.RSCMoveableControlVB Implements ICurrentElement.CtlCurrentElement
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''
    ''    Set(value As __RSCWindowsControlLibrary.RSCMoveableControlVB)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''
    ''End Property


    Public Sub Context_Menu_SG9121(sender As Object, e As EventArgs)
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

    End Sub ''end of "Public Sub Context_Menu_SG9121(sender As Object, e As EventArgs)"


    Public Sub Rotate90_Degrees_SG1001(sender As Object, e As EventArgs)
        ''
        ''Copy-pasted 1/24/2022 thomas downes
        ''Added 8/17/2019 thomas downes
        ''         
        ''   We will use Reflection to convert the procedures in class Operations_EditFieldElement
        ''   to clickable LinkLabels.
        ''      (See procedure MenuCache_FieldElements.Generate_BasicEdits().)
        ''
        ''Jan24 2022 td''With Me.CtlCurrentElementField.ElementInfo_Base
        With Me.CtlCurrentElement.ElementInfo_Base

            Select Case .OrientationToLayout
                Case "", " ", "P"
                    .OrientationToLayout = "L"
                Case "L"
                    .OrientationToLayout = "P"
                Case Else
                    .OrientationToLayout = "P"
            End Select ''End of "Select Case .OrientationToLayout"

            ''Added 8/12/2019 thomas downes 
            ''
            ''   Increment by 90 degrees.  
            ''    This will enable the badge to be printed with the element oriented
            ''   correctly (with one out of four choices of orientation). 
            ''
            .OrientationInDegrees += 90

            ''Added 9/23/2019 td
            If (360 <= .OrientationInDegrees) Then
                ''Remove 360 degrees (the full circle) from the 
                ''    property value.   We don't want to have to 
                ''    do modulo arithmetic (divide by 360 & get 
                ''    the remainder).  ---9/23/2019 td 
                ''     
                .OrientationInDegrees = (.OrientationInDegrees - 360)
            End If ''End of "If (360 <= .OrientationInDegrees) Then"

        End With ''End of "With Me.ElementInfo_Base"

        '' 9/15 td''Refresh_Image()
        '' 9/23 td''Refresh_Image(True)
        '' 9/23 td''Me.Refresh()
        ''10/17/2019 td''Me.Refresh_Master()
        ''1/24/2022 td''Me.CtlCurrentElementField.Refresh_Master()
        Me.CtlCurrentElement.Refresh_Master()

        ''Added 9/13/2019 td
        ''9/19/2019 td''Me.FormDesigner.AutoPreview_IfChecked()
        Me.LayoutFunctions.AutoPreview_IfChecked()

    End Sub ''eNd of "Public Sub Rotate90_Degrees_SG1001(sender As Object, e As EventArgs)"


    Public Sub Select_graphics_image__SG1001(sender As Object, e As EventArgs)
        ''--- Public Sub Select_background_image(sender As Object, e As EventArgs)
        ''
        ''Copied 12/13/2021 from the following:
        ''    Operations_EditBackground  
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
            ''---Me.Designer.BackgroundBox_Front.Image = open_image

        End If ''End of "If ("" = strFullPathToBitmap) Then"

    End Sub ''End of "Public Sub Change_Background_Image()"


    Public Sub Move_Graphic_To_Other_Side_Of_Badge_SG1001(sender As Object, e As EventArgs)
        ''
        ''Added 12/13/2021 thomas d. 
        ''



    End Sub ''End of "Public Sub Move_Graphic_To_Other_Side_Of_Badge_EG1001(sender As Object, e As EventArgs)"


End Class
