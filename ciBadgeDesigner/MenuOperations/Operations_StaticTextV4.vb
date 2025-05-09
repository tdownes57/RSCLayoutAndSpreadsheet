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

Public Class Operations_StaticTextV4
    Inherits Operations__Text
    ''
    ''Added 1/31/2022 td
    ''

    Public Property CtlCurrentElementStaticText As ciBadgeDesigner.CtlGraphicStaticTextV4

    ''Feb2 2022 td''Public Property ElementStaticText As ciBadgeElements.ClassElementStaticTextV3 ''Added 1/19/2022
    Public Property ElementStaticTextV4 As ciBadgeElements.ClassElementStaticTextV4 ''Added 2/02/2022

    Public Overrides Property ElementInfo_TextOnly As IElement_TextOnly ''Added 1/19/2022

    Public Overrides Property Element_Type As Enum_ElementType = Enum_ElementType.StaticGraphic ''Added 1/21/2022 td

    Public Property Parent_MenuCache As MenuCache_Generic_NotUsed ''Modified 12/30/2021 td 

    Public WithEvents MyLinkLabel As New LinkLabel ''Added 10/11/2019 td 
    Public WithEvents MyToolstripItem As New ToolStripMenuItem ''Added 10/11/2019 td 

    ''Added 1/25/2022 td''Public Property LayoutFunctions As ILayoutFunctions ''Added 10/3/2019 td 

    ''++__Shadows another property of the same name, in a base case.----8/14/2022 d
    ''++_Public Property Designer As ciBadgeDesigner.ClassDesigner
    ''++_Public Property ColorDialog1 As ColorDialog ''Added 10/3/2019 td 
    ''++_Public Property FontDialog1 As FontDialog ''Added 10/3/2019 td 

    ''---not needed 10/3/2019 td----Public Property GroupEdits As ClassGroupMove ''Added 10/3/2019 td 
    ''++_Public Property SelectingElements As ISelectingElements ''Added 10/3/2019 td 

    Public Property CacheOfFieldsEtc As ciBadgeCachePersonality.ClassElementsCache_Deprecated

    ''1/18/2022 td''Public Overrides Property CtlCurrentElement As CtlGraphicStaticText


    Public Sub Context_Menu_EST9121(sender As Object, e As EventArgs)
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

    End Sub ''end of "Public Sub Context_Menu_EST9121(sender As Object, e As EventArgs)"


    Public Sub Add_or_Revise_Text_Of_Element_EST1050(sender As Object, e As MouseEventArgs)
        ''
        ''Added 2/2/2022 & 1/18/2022
        ''
        Dim strCurrentText As String
        Dim objControlStaticTextV4 As CtlGraphicStaticTextV4
        Dim objElementStaticTextV4 As ciBadgeElements.ClassElementStaticTextV4

        objControlStaticTextV4 = CType(Me.CtlCurrentElement, CtlGraphicStaticTextV4)
        ''2/2/022 td''objElementStaticTextV4 = objControlStaticTextV4.Element_StaticText
        objElementStaticTextV4 = objControlStaticTextV4.Element_StaticTextV4

        strCurrentText = objElementStaticTextV4.Text_StaticLine

        ''Added 1/18/2022 thomas downes  
        ''Feb6 2022''objElementStaticTextV4.Text_Static =
        ''May31 2022 ''Dim strTextFromInputBox As String ''Added 2/6/2022 td   
        ''May31 2022 ''strTextFromInputBox =
        ''May31 2022 ''InputBox("Enter the static text you want to appear.  You can revise it later.",
        ''May31 2022 ''             "Enter text", strCurrentText, e.X, e.Y)
        ''
        ''Added 5/30/2022 
        ''
        With objElementStaticTextV4

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
                ''2/21/2022 .Text_ListOfLines.Clear() ''Added 12/2022 td
                .Text_ListOfLines?.Clear() ''Added 12/2022 td
                .Text_ListOfLines?.AddRange(objFormToShow.Output_ListOfLines) ''Added 12/2022 td
                .DateEdited = Now
            End If ''End of ""If (res_dia = DialogResult.OK) Then"" 

        End With ''End of ""With objElementStaticTextV4""

        ''''Added 2/06/2022 thomas downes  
        ''If ("" = strTextFromInputBox) Then
        ''    MessageBoxTD.Show_Statement("User has cancelled, deleted the text, or perhaps made a mistake.")
        ''    Exit Sub
        ''End If ''End of "If ("" = strTextFromInputBox) Then"

        ''Added 2/06/2022 thomas downes  
        ''Dim boolConfirmed As Boolean
        ''boolConfirmed = MessageBoxTD.Show_Confirmed("Please confirm the following text.",
        ''                    strTextFromInputBox, True)
        ''If (Not boolConfirmed) Then Exit Sub
        ''objElementStaticTextV4.Text_StaticLine = strTextFromInputBox
        ''objElementStaticTextV4.DateEdited = Now

        With objControlStaticTextV4
            .SaveToModel()
            ''Feb2 2022 td''.Refresh_Image(False)
            .Refresh_ImageV4(False)
        End With

        ''Added 1/28//2022 td 
        Me.Designer.AutoPreview_IfChecked(Me.CtlCurrentElement)

    End Sub ''end of "Public Sub Revise_Text_Of_Element_EST1050"



End Class
