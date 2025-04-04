﻿Option Explicit On
Option Strict On
Option Infer Off
''
''Added 12/12/2021 td
''
Imports ciBadgeInterfaces
Imports ciBadgeDesigner
''----Imports ciBadgeElements
Imports System.Windows.Forms ''Added 12/30/2021 td
Imports __RSCWindowsControlLibrary ''Added 1/08/2022 thomas d.

Public Class Operations_StaticTextV3
    Inherits Operations__Text
    ''Jan17 2022 ''Implements ICurrentElement ''Added 12/28/2021 td

    ''Jan8 2022 td''Public Property CtlCurrentElement As ciBadgeDesigner.CtlGraphicStaticText ''CtlGraphicFldLabel
    ''Jan17 2022 ''Public Property CtlCurrentElement As RSCMoveableControlVB Implements ICurrentElement.CtlCurrentElement
    Public Property CtlCurrentElementStaticText As ciBadgeDesigner.CtlGraphicStaticTextV3
    Public Property ElementStaticText As ciBadgeElements.ClassElementStaticTextV3 ''Added 1/19/2022
    ''11/2023 td Shadows''Public Shadows Property ElementInfo_TextOnly As IElement_TextOnly ''Added 1/19/2022

    Public Overrides Property Element_Type As Enum_ElementType = Enum_ElementType.StaticGraphic ''Added 1/21/2022 td


    ''
    ''Added 12/12/2021 td
    ''
    ''Dec30 2021 td''Public Property Parent_MenuCache As MenuCache_StaticText ''Added 12/15/2021 td 
    Public Property Parent_MenuCache As MenuCache_Generic_NotUsed ''Modified 12/30/2021 td 

    Public WithEvents MyLinkLabel As New LinkLabel ''Added 10/11/2019 td 
    Public WithEvents MyToolstripItem As New ToolStripMenuItem ''Added 10/11/2019 td 

    ''Added 1/25/2022 td''Public Property LayoutFunctions As ILayoutFunctions ''Added 10/3/2019 td 
    ''11/2023 td Shadows''Public Shadows Property Designer As ciBadgeDesigner.ClassDesigner
    ''11/2023 td Shadows''Public Shadows Property ColorDialog1 As ColorDialog ''Added 10/3/2019 td 
    ''11/2023 td Shadows''Public Shadows Property FontDialog1 As FontDialog ''Added 10/3/2019 td 

    ''---not needed 10/3/2019 td----Public Property GroupEdits As ClassGroupMove ''Added 10/3/2019 td 
    ''11/2023 td Shadows''Public Shadows Property SelectingElements As ISelectingElements ''Added 10/3/2019 td 

    Public Property CacheOfFieldsEtc As ciBadgeCachePersonality.ClassElementsCache_Deprecated

    ''1/18/2022 td''Public Overrides Property CtlCurrentElement As CtlGraphicStaticText


    Public Sub Add_or_Revise_Text_Of_Element_EST1050(sender As Object, e As MouseEventArgs)
        ''
        ''Added 1/18/2022
        ''
        Dim strCurrentText As String
        Dim objControlStaticText As CtlGraphicStaticTextV3
        Dim objElementStaticTextV3 As ciBadgeElements.ClassElementStaticTextV3

        objControlStaticText = CType(Me.CtlCurrentElement, CtlGraphicStaticTextV3)
        objElementStaticTextV3 = objControlStaticText.Element_StaticText

        strCurrentText = objElementStaticTextV3.Text_StaticLine

        ''Added 1/18/2022 thomas downes  
        ''May31 2022  objElementStaticTextV3.Text_StaticLine =
        ''             InputBox("Enter the static text you want to appear.  You can revise it later.",
        ''             "Enter text", strCurrentText, e.X, e.Y)

        ''Added 5/30/2022 
        ''
        With objElementStaticTextV3

            Dim objFormToShow As DialogStaticText ''Added 5/30/2022
            Dim res_dia As DialogResult ''Added 5/30/2022
            ''Added 5/30/2022 
            objFormToShow = New DialogStaticText(.Text_IsMultiLine, .Text_StaticLine,
                                         .Text_ListOfLines)
            res_dia = objFormToShow.ShowDialog()
            If (res_dia = DialogResult.OK) Then
                .Text_StaticLine = objFormToShow.Output_SingleLine
                .Text_IsMultiLine = objFormToShow.Output_IsMultiLine

                ''12/2022 .Text_ListOfLines = objFormToShow.Output_ListOfLines
                .Text_ListOfLines.Clear() ''Added 12/2022
                .Text_ListOfLines.AddRange(objFormToShow.Output_ListOfLines)

                .DateEdited = Now
            End If ''End of ""If (res_dia = DialogResult.OK) Then"" 

        End With ''End of ""With objElementStaticTextV3""

        objElementStaticTextV3.DateEdited = Now
        objControlStaticText.SaveToModel()
        objControlStaticText.Refresh_Image(False)

        ''Added 1/28/2022 td 
        Me.Designer.AutoPreview_IfChecked(Me.CtlCurrentElement)

    End Sub ''end of "Public Sub Revise_Text_Of_Element_EST1050"




    Private Sub GiveSizeInfo_Field_EST1000(sender As Object, e As EventArgs)
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

    End Sub ''End of "Private Sub GiveSizeInfo_Field_EST1000(sender As Object, e As EventArgs)"


    Public Sub Open_Dialog_For_Color_EST1001(sender As Object, e As EventArgs)
        ''
        ''Added 7/30/2019 thomas downes
        ''       ''
        ''   We will use Reflection to convert the procedures in class Operations_EditFieldElement to clickable LinkLabels.
        ''      (See procedure MenuCache_FieldElements.Generate_BasicEdits().)
        ''
        If (ColorDialog1 Is Nothing) Then ColorDialog1 = New ColorDialog

        ColorDialog1.ShowDialog()

        ''''7/30/2019 td''Me.ElementInfo.FontColor = ColorDialog1.Color
        ''''8/29/2019 td''Me.ElementInfo.BackColor = ColorDialog1.Color
        Me.ElementInfo_Base.Back_Color = ColorDialog1.Color

        ''Me.ElementInfo_Base.Width_Pixels = Me.Width
        ''Me.ElementInfo_Base.Height_Pixels = Me.Height

        ''Application.DoEvents()
        ''Application.DoEvents()

        Me.CtlCurrentElementStaticText.Refresh_Image(True)
        Me.CtlCurrentElementStaticText.Refresh()

    End Sub ''eNd of "Private Sub Open_Dialog_For_Color_EST1001()"


    Public Sub Open_Dialog_For_Font_EE1012(sender As Object, e As EventArgs)
        ''
        ''Added 7/30/2019 thomas downes
        ''
        If (FontDialog1 Is Nothing) Then FontDialog1 = New FontDialog
        FontDialog1.Font = Me.ElementInfo_TextOnly.FontDrawingClass
        FontDialog1.ShowDialog()

        ''6/2022 Me.ElementInfo_TextOnly.Font_DrawingClass = FontDialog1.Font
        Me.ElementInfo_TextOnly.FontDrawingClass = FontDialog1.Font

        Application.DoEvents()
        Application.DoEvents()

        Me.CtlCurrentElementStaticText.Refresh_Image(True)
        Me.CtlCurrentElementStaticText.Refresh()

    End Sub ''eNd of "Private Sub Open_Dialog_For_Font()"


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


    Public Sub Rotate90_Degrees_EE1015(sender As Object, e As EventArgs)
        ''
        ''Copy-pasted 1/24/2022 thomas downes
        ''Added 8/17/2019 thomas downes
        ''         
        ''   We will use Reflection to convert the procedures in class Operations_EditFieldElement
        ''   to clickable LinkLabels.
        ''      (See procedure MenuCache_FieldElements.Generate_BasicEdits().)
        ''
        Dim objElementStaticText As ciBadgeElements.ClassElementStaticTextV3
        Dim objControlStaticText As CtlGraphicStaticTextV3

        objControlStaticText = CType(Me.CtlCurrentElement, CtlGraphicStaticTextV3)
        objElementStaticText = objControlStaticText.Element_StaticText

        ''Jan24 2022 td''With Me.CtlCurrentElementField.ElementInfo_Base
        ''Jan28 2022 td''With Me.CtlCurrentElement.ElementInfo_Base
        With objElementStaticText

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

            ''Added 1/28/2022 td
            If (180 <= .OrientationInDegrees) Then
                ''This will make things a lot simpler & easier to debug!!!! 
                ''  ----1/28/2022 td
                .OrientationInDegrees = 0
            End If ''End of "If (180 <= .OrientationInDegrees) Then"

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
        ''Look below. Jan28 2022 ''Me.CtlCurrentElement.Refresh_Master()

        ''Added 9/13/2019 td
        ''9/19/2019 td''Me.FormDesigner.AutoPreview_IfChecked()
        ''#1 1/28/2022 td''Me.LayoutFunctions.AutoPreview_IfChecked()

        ''#2 1/28/2022 td''Me.CtlCurrentElement.DateEdited = Now
        ''#2 1/28/2022 td''Me.CtlCurrentElement.SaveToModel()
        ''#1 Jan28 2022 ''Me.CtlCurrentElement.Refresh_Image(False)
        ''#2 1/28/2022 td''Me.CtlCurrentElement.Refresh_Master()

        objElementStaticText.DateEdited = Now
        objControlStaticText.SaveToModel()
        ''#3 1/28/2022 td''objControlStaticText.Refresh_Image(False)
        objControlStaticText.Refresh_Master()

        ''Added 1/28/2022 td 
        Me.Designer.AutoPreview_IfChecked(Me.CtlCurrentElement)

    End Sub ''eNd of "Public Sub Rotate90_Degrees_EE1001(sender As Object, e As EventArgs)"


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


    ''Public Sub Delete_Element_From_Badge_BA1019(sender As Object, e As EventArgs)
    ''    ''
    ''    ''Stubbed 1/19/2022 thomas downes
    ''    ''
    ''    ElementsCacheManager.DeleteElementFromCache(CtlCurrentElement.ElementInfo_Base, Me.Element_Type)
    ''
    ''    MessageBoxTD.Show_Statement("For the change to have a visible effect, you will need to save & refresh.")
    ''
    ''End Sub ''End of Public Sub Delete_Element_From_Badge_BA1001


End Class
