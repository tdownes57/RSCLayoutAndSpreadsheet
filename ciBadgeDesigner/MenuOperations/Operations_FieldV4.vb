﻿Option Explicit On
Option Strict On
Option Infer Off
''
''Added 2/04/2022 td
''

''----Imports ciBadgeElements
Imports System.Drawing ''Added 1/2/2022 td
Imports __RSCWindowsControlLibrary ''Added 1/5/2022 td 
Imports ciBadgeInterfaces ''Added 12/30/2021 

Public Class Operations_FieldV4
    Inherits Operations__Text
    ''Jan17 2022 ''Implements ICurrentElement ''Added 12/28/2021 td

    ''
    ''Added 10/1/2019 td
    ''
    ''Names of procedures in this module: 
    ''  Public Sub Open_Field_Of_Element_EE1011(sender As Object, e As EventArgs)
    ''  Public Sub Choose_Background_Color_EE1010(sender As Object, e As EventArgs)
    ''  Public Sub Open_Dialog_Font_EE1009(sender As Object, e As EventArgs)
    ''  Public Sub ExampleValue_Edit_EE1006(sender As Object, e As EventArgs)
    ''   Public Sub Open_OffsetText_Dialog_EE1007(sender As Object, e As EventArgs)
    ''  Public Sub Border_Design_EE1000(sender As Object, e As EventArgs)
    ''  Public Sub Rotate90_Degrees_EE1001(sender As Object, e As EventArgs)
    ''  Public Sub How_Context_Menus_Are_Generated_EE1002(sender As Object, e As EventArgs) 
    ''   --- Private Sub CreateVisibleButtonMaster(par_strText As String,
    ''
    ''12/30/2021 td''Public Property Parent_MenuCache As MenuCache_FieldElements ''Added 12/12/2021 td 
    Public Property Parent_MenuCache As MenuCache_Generic_NotUsed ''Added 12/12/2021 td 

    Public WithEvents MyLinkLabel As New LinkLabel ''Added 10/11/2019 td 
    Public WithEvents MyToolstripItem As New ToolStripMenuItem ''Added 10/11/2019 td 

    ''Jan5 2022 td''
    Public Property CtlCurrentElementFieldV4_NotUsed As ciBadgeDesigner.CtlGraphicFieldV4 ''CtlGraphicFldLabel
    ''Jan17 2022 ''Public Property CtlCurrentElement As RSCMoveableControlVB Implements ICurrentElement.CtlCurrentElement

    Public Property ElementFieldV4 As ciBadgeElements.ClassElementFieldV4 ''Added 2/04/2022

    Public Overrides Property Element_Type As Enum_ElementType = Enum_ElementType.Field ''Added 1/21/2022 td 

    ''See base class. 8/01/2022 Public Property LayoutFunctions As ILayoutFunctions ''Added 10/3/2019 td 
    ''See base class. 8/01/2022 Public Property Designer As ciBadgeDesigner.ClassDesigner

    ''Feb2 2022 td''Public Property ColorDialog1 As ColorDialog ''Added 10/3/2019 td 
    ''Feb2 2022 td''Public Property FontDialog1 As FontDialog ''Added 10/3/2019 td 

    ''---not needed 10/3/2019 td----Public Property GroupEdits As ClassGroupMove ''Added 10/3/2019 td 
    ''See base class. 8/01/2022 Public Property SelectingElements As ISelectingElements ''Added 10/3/2019 td 

    ''Added 12/12/2021 thomas 
    ''Public Property ListOfFields_Standard As HashSet(Of ciBadgeFields.ClassFieldStandard)
    ''Public Property ListOfFields_Custom As HashSet(Of ciBadgeFields.ClassFieldCustomized)
    Public Property CacheOfFieldsEtc_Deprecated As ciBadgeCachePersonality.ClassElementsCache_Deprecated

    Private mod_fauxMenuEditSingleton As CtlGraphPopMenuEditSingle ''Added 10/3/2019 td 
    Private Const mod_enumElementType As Enum_ElementType = Enum_ElementType.Field ''Added 1/19/2022 td 

    ''Names of procedures in this module: 
    ''  Public Sub Open_Field_Of_Element_EE1011(sender As Object, e As EventArgs)
    ''  Public Sub Choose_Background_Color_EE1010(sender As Object, e As EventArgs)
    ''  Public Sub Open_Dialog_Font_EE1009(sender As Object, e As EventArgs)
    ''  Public Su./b ExampleValue_Edit_EE1006(sender As Object, e As EventArgs)
    ''   Public Sub Open_OffsetText_Dialog_EE1007(sender As Object, e As EventArgs)
    ''  Public Sub Border_Design_EE1000(sender As Object, e As EventArgs)
    ''  Public Sub Rotate90_Degrees_EE1001(sender As Object, e As EventArgs)
    ''  Public Sub How_Context_Menus_Are_Generated_EE1002(sender As Object, e As EventArgs) 
    ''   --- Private Sub CreateVisibleButtonMaster(par_strText As String,
    ''

    Public Sub Context_Menu_EE9121(sender As Object, e As EventArgs)
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

    End Sub ''end of "Public Sub Context_Menu_EE9121(sender As Object, e As EventArgs)"


    Public Sub Open_Field_Of_Element_EE1011(sender As Object, e As EventArgs)
        ''Private Sub OpenDialog_Field(sender As Object, e As EventArgs)
        ''
        ''Added 7/30/2019 thomas downes
        ''       ''
        ''   We will use Reflection to convert the procedures in class Operations_EditFieldElement to clickable LinkLabels.
        ''      (See procedure MenuCache_FieldElements.Generate_BasicEdits().)
        ''
        ''7/30/2019 td''ColorDialog1.ShowDialog()
        Dim bIsCustomField As Boolean = False ''Added 12/14/2021 
        Const c_boolTryNewSub As Boolean = True ''Added 12/14/2021 td

        ''2/4/2022 td''bIsCustomField = (CtlCurrentElementFieldV4.ElementClass_Obj.FieldObjectCustom IsNot Nothing)
        ''5/11/2022 td''bIsCustomField = (CtlCurrentElementFieldV3.ElementClass_ObjV3.FieldObjectCustom IsNot Nothing)
        bIsCustomField = bIsCustomField OrElse (CtlCurrentElementFieldV3 IsNot Nothing AndAlso
                                                CtlCurrentElementFieldV3.FieldIsCustom)
        bIsCustomField = bIsCustomField OrElse (ElementFieldV4 IsNot Nothing AndAlso
                                                ElementFieldV4.FieldIsCustomizable)

        If (bIsCustomField And c_boolTryNewSub) Then

            ''Added 12/14/2021 thomas d. 
            Open_FieldStandard_OrCustom(New DialogListCustomFields())

        ElseIf (bIsCustomField) Then
            ''Encapsulated 12/14/2021 thomas d. 
            Open_FieldCustomized()

        Else
            ''Added 12/14/2021 thomas d. 
            Open_FieldStandard_OrCustom(New DialogListStandardFields())

        End If ''End of "End of "If (bIsCustomField) Then ... Else ..."

    End Sub ''eNd of "Public Sub Open_Field_Of_Element_EE1011(sender As Object, e As EventArgs)"


    Private Sub Open_FieldCustomized()
        ''
        ''Encapsulated 12/14/2021 thomas d. 
        ''
        Dim form_ToShow As New DialogListCustomFields

        Dim boolExitEarly As Boolean ''Added 8/13/2019 td
        ''10/10/2019 td''CreateVisibleButton_Master("Choose a background color", AddressOf OpenDialog_Color, boolExitEarly)
        If (boolExitEarly) Then Exit Sub ''Added 8/13/2019 td

        ''Can (should) we just show a single field? ''form_ToShow.JustOneField = Me.FieldInfo
        ''10/2/2019 td''form_ToShow.JustOneField_Index = Me.FieldInfo.FieldIndex
        ''5/11/2022 form_ToShow.JustOneField_Index = CtlCurrentElementFieldV4.FieldInfo.FieldIndex
        form_ToShow.JustOneField_Index = GetFieldObjectAny().FieldIndex

        ''Added 12/13/2021 thomas downes
        form_ToShow.JustOneField_Any = GetFieldObjectAny() ''5/2022 CtlCurrentElementFieldV4.ElementClass_ObjV4.FieldObjectAny
        form_ToShow.JustOneField_Custom = GetFieldObjectCustom() ''5/2022 CtlCurrentElementFieldV4.ElementClass_ObjV4.FieldObjectCustom
        form_ToShow.JustOneField_Standard = GetFieldObjectStandard() ''5/2022 CtlCurrentElementFieldV4.ElementClass_ObjV4.FieldObjectStandard

        ''Added 12/12/2021 td
        ''--form_ToShow.ListOfFields_Custom = MenuCache_ElemFlds.CacheOfFieldsEtc.ListOfFields_Custom
        ''--form_ToShow.ListOfFields_Standard = MenuCache_ElemFlds.CacheOfFieldsEtc.ListOfFields_Standard

        Const c_bFormMustSeeEntireListOfFields As Boolean = False ''False, since the form only needs one(1) Field. ---Added 1/5/2022 td
        If (c_bFormMustSeeEntireListOfFields) Then ''Added 1/5/2022 td
            form_ToShow.ListOfFields_Custom = Me.CacheOfFieldsEtc_Deprecated.ListOfFields_Custom ''--MenuCache_ElemFlds.CacheOfFieldsEtc.ListOfFields_Custom
            form_ToShow.ListOfFields_Standard = Me.CacheOfFieldsEtc_Deprecated.ListOfFields_Standard ''--MenuCache_ElemFlds.CacheOfFieldsEtc.ListOfFields_Standard
        End If ''End of "If (c_bFormMustSeeEntireListOfFields) Then"

        form_ToShow.Show()

    End Sub ''eNd of "Public Sub Open_FieldCustomized()"


    Private Sub Open_FieldStandard_OrCustom(par_form_ToShow As InterfaceShowListFields)
        ''
        ''Encapsulated 12/14/2021 thomas d. 
        ''
        ''Dec14 2021''Dim form_ToShow As New ListStandardFields

        Dim boolExitEarly As Boolean ''Added 8/13/2019 td
        ''10/10/2019 td''CreateVisibleButton_Master("Choose a background color", AddressOf OpenDialog_Color, boolExitEarly)
        If (boolExitEarly) Then Exit Sub ''Added 8/13/2019 td

        ''Can (should) we just show a single field? ''form_ToShow.JustOneField = Me.FieldInfo
        ''10/2/2019 td''form_ToShow.JustOneField_Index = Me.FieldInfo.FieldIndex
        ''5/11/2022 td''par_form_ToShow.JustOneField_Index = CtlCurrentElementFieldV4.FieldInfo.FieldIndex
        par_form_ToShow.JustOneField_Index = GetFieldObjectAny().FieldIndex

        ''Added 12/13/2021 thomas downes
        ''5/2022 par_form_ToShow.JustOneField_Any = CtlCurrentElementFieldV4.ElementClass_ObjV4.FieldObjectAny
        ''5/2022 par_form_ToShow.JustOneField_Custom = CtlCurrentElementFieldV4.ElementClass_ObjV4.FieldObjectCustom
        ''5/2022 par_form_ToShow.JustOneField_Standard = CtlCurrentElementFieldV4.ElementClass_ObjV4.FieldObjectStandard
        par_form_ToShow.JustOneField_Any = GetFieldObjectAny()
        par_form_ToShow.JustOneField_Custom = GetFieldObjectCustom()
        par_form_ToShow.JustOneField_Standard = GetFieldObjectStandard()

        ''Added 12/12/2021 td
        ''--form_ToShow.ListOfFields_Custom = MenuCache_ElemFlds.CacheOfFieldsEtc.ListOfFields_Custom
        ''--form_ToShow.ListOfFields_Standard = MenuCache_ElemFlds.CacheOfFieldsEtc.ListOfFields_Standard

        If (Me.CacheOfFieldsEtc_Deprecated IsNot Nothing) Then ''Added 1/5/2022 td  

            par_form_ToShow.ListOfFields_Custom = Me.CacheOfFieldsEtc_Deprecated.ListOfFields_Custom ''--MenuCache_ElemFlds.CacheOfFieldsEtc.ListOfFields_Custom
            par_form_ToShow.ListOfFields_Standard = Me.CacheOfFieldsEtc_Deprecated.ListOfFields_Standard ''--MenuCache_ElemFlds.CacheOfFieldsEtc.ListOfFields_Standard

        End If ''End of "If (Me.CacheOfFieldsEtc_Deprecated IsNot Nothing) Then"

        ''Dec. 14 2021 td''par_form_ToShow.Show()
        par_form_ToShow.ShowDialog()

    End Sub ''eNd of "Public Sub Open_FieldStandard_OrCustom()"



    Public Sub Choose_Background_Color_EE1010(sender As Object, e As EventArgs)

        ''---10/10/2019 td--Private Sub OpenDialog_Color(sender As Object, e As EventArgs)
        ''
        ''Added 7/30/2019 thomas downes
        ''
        ''Dim boolExitEarly As Boolean ''Added 8/13/2019 td

        ''CreateVisibleButton_Master("Choose a background color", AddressOf OpenDialog_Color, boolExitEarly)
        ''Application.DoEvents()
        ''If (boolExitEarly) Then Exit Sub ''Added 8/13/2019 td

        ''Added 10/14/2019 td 
        If (Me.ColorDialog1 Is Nothing) Then Me.ColorDialog1 = New ColorDialog

        ColorDialog1.ShowDialog()

        If (Me.SelectingElements.ElementsList_IsItemUnselected(Me.CtlCurrentElementFieldV4)) Then
            ''10/3 td''If (LabelsList_IsItemUnselected(Me)) Then

            ''7/30/2019 td''Me.ElementInfo.FontColor = ColorDialog1.Color
            ''8/29/2019 td''Me.ElementInfo.BackColor = ColorDialog1.Color
            ''10/3/2019 td''Me.ElementInfo_Base.Back_Color = ColorDialog1.Color
            Me.CtlCurrentElementFieldV4.ElementInfo_Base.Back_Color = Me.ColorDialog1.Color

            ''Me.ElementInfo.Width_Pixels = Me.Width
            ''Me.ElementInfo.Height_Pixels = Me.Height

            Application.DoEvents()
            Application.DoEvents()

            ''9/15/2019 td ''Refresh_Image()
            ''10/3/2019 td ''Refresh_Image(True)
            Me.CtlCurrentElementFieldV4.Refresh_ImageV3(True)
            Me.CtlCurrentElementFieldV4.Refresh()

        ElseIf (Me.SelectingElements.ElementsList_IsItemIncluded(Me.CtlCurrentElementFieldV4)) Then
            ''10/3/2019 td''ElseIf (LabelsList_IsItemIncluded(Me)) Then

            ''Added 8/3/2019 td 
            ''10/17/2019 td''Dim objElements As List(Of CtlGraphicFldLabel)
            ''1/12/2022 td''Dim objElements As HashSet(Of CtlGraphicFldLabel)
            Dim objElements As HashSet(Of RSCMoveableControlVB)

            ''8/4//2019 td'objElements = CType(Me.ParentForm, ISelectingElements).LabelsDesignList_AllItems
            ''10/3/2019 td''objElements = Me.SelectingElements.LabelsDesignList_AllItems
            objElements = Me.SelectingElements.ElementsDesignList_AllItems

            ''If (objElements.Count = 0) Then
            ''   objElements.Add(Me)
            '' End If

            For Each each_ctl As CtlGraphicFieldV3 In objElements
                ''
                ''Added 8/3/2019 td  
                ''
                With each_ctl

                    ''8/29/2019 td''.ElementInfoBase.BackColor = ColorDialog1.Color
                    .ElementInfo_Base.Back_Color = Me.ColorDialog1.Color
                    ''.ElementInfo.Width_Pixels = Me.Width
                    ''.ElementInfo.Height_Pixels = Me.Height

                    .Refresh_ImageV3(True)
                    .Refresh()

                End With

            Next each_ctl

        End If ''End of "If (Me.SelectingElements.ElementsList_IsItemUnselected(Me)) Then ... ElseIf (Me.SelectingElements.ElementsList_IsItemIncluded(Me)) Then"

        ''Added 9/13/2019 td
        ''9/19/2019 td''Me.FormDesigner.AutoPreview_IfChecked()
        Me.LayoutFunctions.AutoPreview_IfChecked()

    End Sub ''eNd of "Public Sub Choose_Background_Color_EE1010(sender As Object, e As EventArgs)"


    ''Private Sub SwitchCtl__Up(sender As Object, e As EventArgs)
    ''    ''
    ''    ''Added 8/16/2019 thomas downes
    ''    ''
    ''    ''10/3/2019 td'Me.SelectingElements.SwitchControls___Up(Me)
    ''    Me.SelectingElements.SwitchControls___Up(Me)

    ''    ''Added 9/13/2019 td
    ''    ''9/19/2019 td'' Me.FormDesigner.AutoPreview_IfChecked()
    ''    Me.LayoutFunctions.AutoPreview_IfChecked()

    ''End Sub ''End of "Private Sub SwitchCtl__Up(sender As Object, e As EventArgs)"


    ''Private Sub SwitchCtl_Down(sender As Object, e As EventArgs)
    ''    ''
    ''    ''Added 8/16/2019 thomas downes
    ''    ''
    ''    ''10/3/2019 td'Me.SelectingElements.SwitchControls_Down(Me)
    ''    Me.SelectingElements.SwitchControls_Down(Me)

    ''    ''Added 9/13/2019 td
    ''    ''9/19/2019 td''Me.FormDesigner.AutoPreview_IfChecked()
    ''    Me.LayoutFunctions.AutoPreview_IfChecked()

    ''End Sub ''ENd of "Private Sub SwitchCtl_Down(sender As Object, e As EventArgs)"


    ''Public Sub Open_Dialog_Font_EE1009(sender As Object, e As EventArgs)
    ''    ''
    ''    ''Added 7/30/2019 thomas downes
    ''    ''       ''
    ''    ''   We will use Reflection to convert the procedures in class Operations_EditFieldElement to clickable LinkLabels.
    ''    ''      (See procedure MenuCache_FieldElements.Generate_BasicEdits().)
    ''    ''
    ''    Dim boolExitEarly As Boolean ''Added 8/13/2019 td

    ''    ''10/10/2019 td''CreateVisibleButton_Master("Choose a text font", AddressOf OpenDialog_Font, boolExitEarly)
    ''    ''10/10/2019 td''Application.DoEvents()

    ''    ''Added 8/17/2019 td
    ''    ''10/10/2019 td''If (mod_fauxMenuEditSingleton Is Nothing) Then mod_fauxMenuEditSingleton = New CtlGraphPopMenuEditSingle

    ''    ''10/10/2019 td''mod_fauxMenuEditSingleton.SizeToExpectations()

    ''    If (boolExitEarly) Then Exit Sub ''Added 8/13/2019 td

    ''    Me.FontDialog1.Font = Me.CtlCurrentElementFieldV4.ElementClass_Obj.Font_DrawingClass ''Added 7/31/2019 td  

    ''    ''
    ''    ''Major call !!   Show the font-selection dialog to the user. 
    ''    '' 
    ''    Me.FontDialog1.ShowDialog()

    ''    ''Me.ElementInfo.Font_DrawingClass = FontDialog1.Font
    ''    ''Application.DoEvents()
    ''    ''Application.DoEvents()
    ''    ''RefreshImage()
    ''    ''Me.Refresh()

    ''    If (Me.SelectingElements.ElementsList_IsItemUnselected(Me.CtlCurrentElementField)) Then

    ''        Me.CtlCurrentElementFieldV4.ElementInfo_TextOnly.Font_DrawingClass = Me.FontDialog1.Font

    ''        ''Added 10/17/2019 td 
    ''        If (Me.FontDialog1.Font.Unit = GraphicsUnit.Pixel) Then
    ''            ''Added 10/17/2019 td 
    ''            MsgBox("Program error, unexpected Font Unit", MsgBoxStyle.Exclamation, "OpenDialog_Font")
    ''        Else
    ''            Me.CtlCurrentElementFieldV4.ElementInfo_TextOnly.FontSize_Pixels = Me.FontDialog1.Font.Size  ''Added 8/17/2019 td
    ''        End If ''End of "If (Me.FontDialog1.Font.Unit = GraphicsUnit.Pixel) Then ... Else ..."

    ''        Application.DoEvents()
    ''        Application.DoEvents()

    ''        ''9/15/2019 td''Refresh_Image()
    ''        ''10/3/2019 td''Refresh_Image(False)
    ''        ''10/3/2019 td''Me.Refresh()
    ''        Me.CtlCurrentElementFieldV4.Refresh_ImageV3(False)
    ''        Me.CtlCurrentElementFieldV4.Refresh()

    ''    ElseIf (Me.SelectingElements.ElementsList_IsItemIncluded(Me.CtlCurrentElementField)) Then

    ''        ''Added 8/3/2019 td 
    ''        ''1/12/2022 td''Dim objElements As HashSet(Of CtlGraphicFldLabel)
    ''        Dim objElements As HashSet(Of RSCMoveableControlVB)

    ''        ''10/3/2019 td''objElements = CType(Me.ParentForm, ISelectingElements).LabelsDesignList_AllItems
    ''        objElements = Me.SelectingElements.ElementsDesignList_AllItems

    ''        For Each each_ctl As CtlGraphicFldLabelV3 In objElements
    ''            ''
    ''            ''Added 8/3/2019 td  
    ''            ''
    ''            With each_ctl

    ''                ''Added 10/17/2019 td  
    ''                If (FontDialog1.Font.Unit <> GraphicsUnit.Pixel) Then Throw New Exception("Unexpected Font Unit")

    ''                .ElementInfo_TextOnly.Font_DrawingClass = FontDialog1.Font
    ''                ''Added 10/17/2019 td  
    ''                .ElementInfo_TextOnly.FontSize_Pixels = FontDialog1.Font.Size

    ''                Application.DoEvents()
    ''                Application.DoEvents()
    ''                .Refresh_ImageV3(True)
    ''                .Refresh()

    ''            End With

    ''        Next each_ctl

    ''    End If ''End of "If (Me.SelectingElements.ElementsList_IsItemUnselected(Me)) Then... Else ..."

    ''    ''Added 9/13/2019 td
    ''    ''9/19/2019 td''Me.FormDesigner.AutoPreview_IfChecked()
    ''    Me.LayoutFunctions.AutoPreview_IfChecked()

    ''End Sub ''eNd of "Private Sub "Open_Dialog_Font_EE1009(sender As Object, e As EventArgs)"


    ''11/2023 td Public Shadows Sub ExampleValue_Edit_EE1006(sender As Object, e As EventArgs)
    ''    ''
    ''    ''Added 8/10/2019 thomas downes
    ''    ''       ''
    ''    ''   We will use Reflection to convert the procedures in class Operations_EditFieldElement to clickable LinkLabels.
    ''    ''      (See procedure MenuCache_FieldElements.Generate_BasicEdits().)
    ''    ''
    ''    ''10/17 td''With textTypeExample
    ''    With Me.CtlCurrentElementFieldV4.Textbox_ExampleValue
    ''11/2023 td
    ''        .Visible = True
    ''        .Text = Me.CtlCurrentElementFieldV4.ElementInfo_TextOnly.Text_StaticLine ''Added 8/16/2019 td
    ''        .SelectAll() ''Added 8/16/2019 td
    ''11/2023 td
    ''        ''Added 9/10/2019 td 
    ''        ''  Put the focus on the textbox. 
    ''        .Select() ''Added 9/10/2019 td 
    ''11/2023 td
    ''    End With ''End of "With Me.CtlCurrentElement.Textbox_Example"
    ''11/2023 td
    ''End Sub ''End of "Public Sub ExampleValue_Edit_EE1006(sender As Object, e As EventArgs)"  


    Public Sub Open_OffsetText_Dialog_EE1007(sender As Object, e As EventArgs)
        ''
        ''Added 8/10/2019 thomas downes
        ''       ''
        ''   We will use Reflection to convert the procedures in class Operations_EditFieldElement to clickable LinkLabels.
        ''      (See procedure MenuCache_FieldElements.Generate_BasicEdits().)
        ''
        ''9/18/2019 td''Dim frm_ToShow As New DialogTextOffset

        With Me.CtlCurrentElementFieldV4

            ''Feb5 2022''Dim frm_ToShow As New DialogTextOffset(.ElementClass_Obj, .ElementClass_Obj.Copy(),
            ''Feb5 2022''           Me.CtlCurrentElementFieldV4)

            ''Added Feb5 2022 td 
            Dim objElementCopyV4 As ciBadgeElements.ClassElementFieldV4
            objElementCopyV4 = CType(.ElementClass_ObjV4.Copy(), ciBadgeElements.ClassElementFieldV4)

            Dim frm_ToShow As New DialogTextOffset(.ElementClass_ObjV4, objElementCopyV4,
                        Me.CtlCurrentElementFieldV4)

            ''
            ''Added 8/10/2019 thomas downes
            ''
            ''8/16/2019 td''frm_ToShow.LoadFieldAndForm(Me.FieldInfo, Me.FormDesigner, Me)
            ''9/03/2019 td''frm_ToShow.LoadFieldAndForm(Me.ElementInfo_Text, Me.FieldInfo, Me.FormDesigner, Me)
            ''9/18/2019 td''frm_ToShow.LoadFieldAndForm(Me.ElementInfo_Base, Me.ElementInfo_Text, Me.FieldInfo, Me.FormDesigner, Me)
            ''9/19/2019 td''frm_ToShow.LoadFieldAndForm(Me.FormDesigner, Me)
            ''2/4/2022 td'' frm_ToShow.LoadFieldAndForm(Me.LayoutFunctions, Me.CtlCurrentElementField)
            frm_ToShow.LoadFieldAndFormV4(Me.LayoutFunctions, Me.CtlCurrentElementFieldV4)

            ''Major call !!
            frm_ToShow.ShowDialog()

            ''Refresh the form. ----8/17/2019 td
            Dim boolUserPressedOK As Boolean
            boolUserPressedOK = (frm_ToShow.DialogResult = DialogResult.OK)

            If (boolUserPressedOK) Then '' ----8/17/2019 td

                ''Obselete.---9/18/2019 td''Me.ElementInfo_Text.FontOffset_X = frm_ToShow.FontOffset_X
                ''Obselete.---9/18/2019 td''Me.ElementInfo_Text.FontOffset_Y = frm_ToShow.FontOffset_Y
                ''Obselete.---9/18/2019 td''Me.ElementInfo_Text.FontSize_Pixels = frm_ToShow.FontSize
                ''Obselete.---9/18/2019 td''Me.ElementInfo_Text.Font_DrawingClass = frm_ToShow.Font_DrawingClass

                If (frm_ToShow.UserConfirmed) Then

                    ''10/17/2019 td''frm_ToShow.UpdateInfo_ViaInterfaces(Me.ElementInfo_Base, Me.ElementInfo_Text)
                    frm_ToShow.UpdateInfo_ViaInterfaces(.ElementInfo_Base, .ElementInfo_TextOnly)
                    .Refresh_ImageV3(True)

                End If ''End of "If (frm_ToShow.UserConfirmed) Then"

                ''
                ''
                ''Group Editimg
                ''
                ''
                ''Added 8/18/2019 td 
                If (Me.SelectingElements.ElementsList_IsItemIncluded(Me.CtlCurrentElementFieldV4)) Then

                    ''Added 8/18/2019 td 
                    ''1/12/2022 td''Dim objElements As HashSet(Of CtlGraphicFldLabel)
                    Dim objElements As HashSet(Of RSCMoveableControlVB) ''Added 1/12/2022 td
                    objElements = Me.SelectingElements.ElementsDesignList_AllItems

                    For Each each_ctl As CtlGraphicFieldV3 In objElements
                        ''
                        ''Added 8/3/2019 td  
                        ''
                        With each_ctl
                            ''.ElementInfo.Alignment = frm_ToShow.Alignment  
                            ''9/18/2019 td''.ElementInfo_Text.FontOffset_X = frm_ToShow.FontOffset_X
                            ''9/18/2019 td''.ElementInfo_Text.FontOffset_Y = frm_ToShow.FontOffset_Y
                            ''9/18/2019 td''.ElementInfo_Text.FontSize_Pixels = frm_ToShow.FontSize

                            ''Added 8/18/2019 thomas d.
                            ''9/18/2019 td''.ElementInfo_Text.Font_DrawingClass = frm_ToShow.Font_DrawingClass
                            ''9/18/2019 td''.ElementInfo_Text.TextAlignment = frm_ToShow.TextAlignment
                            ''9/18/2019 td''.ElementInfo_Text.ExampleValue = frm_ToShow.TextExampleValue.Text

                            frm_ToShow.UpdateInfo_ViaInterfaces(.ElementInfo_Base, .ElementInfo_TextOnly)

                            .Refresh_ImageV3(True)
                            .Refresh()

                        End With ''End of " With each_ctl"

                    Next each_ctl

                End If ''ENdo f "If (Me.SelectingElements.ElementsList_IsItemIncluded(Me)) Then"

            End If ''End of "If (boolUserPressedOK) Then"

        End With ''End of "With Me.CtlCurrentElement"

        ''Added 9/13/2019 td
        ''9/19/2019 td''Me.FormDesigner.AutoPreview_IfChecked()
        Me.LayoutFunctions.AutoPreview_IfChecked()

    End Sub ''End of "Public Sub Open_OffsetTextDialog_EE1005(sender As Object, e As EventArgs)"

    Public Sub Border_Design_EE1000(sender As Object, e As EventArgs)
        ''
        ''Added 9/ 2/2019 thomas downes
        ''
        ''9/18/2019 td''Dim frm_ToShow As New DialogTextBorder
        ''9/18/2019 td''frm_ToShow.LoadFieldAndForm(Me.ElementInfo_Base, Me.ElementInfo_Text, Me.FieldInfo, Me.FormDesigner, Me)

        ''Dec.12 2021''Me.Parent_MenuCache.Cache.CheckEditsCacheIsLatest()
        Dim boolIsLatest As Boolean '' = True ''Dec. 12, 2021 td
        Dim boolIsCopyOfLatest As Boolean ''Dec. 12, 2021 td

        ''Added 12/12/2021 thomas downes
        ''#1 1/5/2022 td''Me.CacheOfFieldsEtc.CheckCacheIsLatestForEdits(boolIsLatest, boolIsCopyOfLatest)
        ''#2 1/5/2022 td''Me.CtlCurrentElement.CheckCacheIsLatestForEdits(boolIsLatest, boolIsCopyOfLatest)

        Dim objCacheOfFieldsEtc As ciBadgeCachePersonality.ClassElementsCache_Deprecated ''Added 1/5/2022
        Me.CtlCurrentElementFieldV4 = CType(Me.CtlCurrentElement, CtlGraphicFieldV4)
        objCacheOfFieldsEtc = Me.CtlCurrentElementFieldV4.ParentDesigner.ElementsCache_UseEdits
        objCacheOfFieldsEtc.CheckCacheIsLatestForEdits(boolIsLatest, boolIsCopyOfLatest)
        If (Not boolIsLatest) Then Throw New Exception("This is not the latest cache of edits.")

        With Me.CtlCurrentElementFieldV4 ''Added 10/17/2019 td

            Dim frm_ToShow As DialogTextBorder
            ''7/19/2022 frm_ToShow = New DialogTextBorder(Me.CtlCurrentElementFieldV4, .ElementClass_ObjV4) ''2/4/2022 '', .ElementClass_Obj.Copy(True))
            frm_ToShow = New DialogTextBorder(Me.CtlCurrentElementFieldV4, .ElementClass_ObjV4) ''2/4/2022 '', .ElementClass_Obj.Copy(True))

            ''Denigrated. 9/19 td''frm_ToShow.LoadFieldAndForm(Me.FormDesigner, Me)
            frm_ToShow.LoadFieldAndFormV4(Me.LayoutFunctions, Me.CtlCurrentElementFieldV4)

            ''Major call !!
            frm_ToShow.ShowDialog()

            ''Refresh the form. ----8/17/2019 td
            Dim boolUserPressedOK As Boolean
            boolUserPressedOK = (frm_ToShow.DialogResult = DialogResult.OK)

            If (boolUserPressedOK) Then '' ----8/17/2019 td

                ''9/18/2019 td''Me.ElementInfo_Base.Border_WidthInPixels = frm_ToShow.Border_SizeInPixels
                ''9/18/2019 td''Me.ElementInfo_Base.Border_Color = frm_ToShow.Border_Color
                ''9/18/2019 td''Me.ElementInfo_Base.Border_Displayed = frm_ToShow.Border_Displayed ''Added 9/9/2019 td

                ''Added 9/18/2019 td
                frm_ToShow.UpdateInfo_ViaInterface(.ElementInfo_Base)

                .Refresh_ImageV3(True)

                ''
                ''
                ''Group Editimg
                ''
                ''
                ''Added 8/18/2019 td 
                If (Me.SelectingElements.ElementsList_IsItemIncluded(Me.CtlCurrentElementFieldV4)) Then

                    ''Added 8/18/2019 td 
                    ''1/12/2022 td''Dim objElements As HashSet(Of CtlGraphicFldLabel)
                    Dim objElements As HashSet(Of RSCMoveableControlVB)
                    objElements = Me.SelectingElements.ElementsDesignList_AllItems

                    For Each each_ctl As CtlGraphicFieldV3 In objElements
                        ''
                        ''Added 8/3/2019 td  
                        ''
                        With each_ctl

                            ''9/18/2019 td''.ElementInfo_Base.Border_WidthInPixels = frm_ToShow.Border_SizeInPixels
                            ''9/18/2019 td''.ElementInfo_Base.Border_Color = frm_ToShow.Border_Color
                            ''9/18/2019 td''.ElementInfo_Base.Border_Displayed = frm_ToShow.Border_Displayed ''9/9 td

                            ''Added 9/18/2019 td 
                            frm_ToShow.UpdateInfo_ViaInterface(.ElementInfo_Base)

                            .Refresh_ImageV3(True)
                            .Refresh()

                        End With

                    Next each_ctl

                End If ''End of "If (Me.SelectingElements.ElementsList_IsItemIncluded(Me)) Then"

            End If ''End of "If (boolUserPressedOK) Then"

        End With ''End of "With Me.CtlCurrentElement"

        ''Added 9/13/2019 td
        ''9/19/2019 td''Me.FormDesigner.AutoPreview_IfChecked()
        Me.LayoutFunctions.AutoPreview_IfChecked()

    End Sub ''End of "Public Sub Border_Design_EE1000(sender As Object, e As EventArgs)"


    Public Sub Rotate90_Degrees_Clockwise_EE1001(sender As Object, e As EventArgs)
        ''
        ''Added 8/17/2019 thomas downes
        ''         ''
        Const c_counterclockwise As Boolean = False ''False, it's actually clockwise, not counter-clockwise. 
        Rotate90_Degrees(c_counterclockwise)

    End Sub

    Public Sub Rotate90_Degrees_Counterclockwise_EE1001(sender As Object, e As EventArgs)
        ''
        ''Added 8/17/2019 thomas downes
        ''         
        Const c_counterclockwise As Boolean = True ''True, counter-clockwise.
        Rotate90_Degrees(c_counterclockwise)

    End Sub

    Private Sub Rotate90_Degrees(Optional pbCounterclockwise As Boolean = False)
        ''Feb2 2022''Public Sub Rotate90_Degrees_EE1001(sender As Object, e As EventArgs)
        ''
        ''Added 8/17/2019 thomas downes
        ''         ''
        ''   We will use Reflection to convert the procedures in class Operations_EditFieldElement to clickable LinkLabels.
        ''      (See procedure MenuCache_FieldElements.Generate_BasicEdits().)
        ''
        With Me.CtlCurrentElementFieldV4.ElementInfo_Base

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
            ''Feb2 2022 td''.OrientationInDegrees += 90
            If (pbCounterclockwise) Then
                .OrientationInDegrees -= 90 ''Added 2/2/2022
            Else
                .OrientationInDegrees += 90 ''Added 2/2/2022
            End If ''End of "If (pbCounterclockwise) Then ... Else ..."

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
        Me.CtlCurrentElementFieldV4.Refresh_Master()

        ''Added 9/13/2019 td
        ''9/19/2019 td''Me.FormDesigner.AutoPreview_IfChecked()
        Me.LayoutFunctions.AutoPreview_IfChecked()

    End Sub ''eNd of "Public Sub Rotate90_Degrees_EE1001(sender As Object, e As EventArgs)"


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


    End Sub


    ''11/2023 td Public Sub How_Context_Menus_Are_Generated_EE9001(sender As Object, e As EventArgs)
    ''    ''---Dec15 2021--Public Sub How_Context_Menus_Are_Generated_EE1001
    ''    ''
    ''    ''Added 12/12/2021 thomas downes  
    ''    ''
    ''    ''   We will use Reflection to convert the procedures in class Operations_EditFieldElement to clickable LinkLabels.
    ''    ''      (See procedure MenuCache_FieldElements.Generate_BasicEdits().)
    ''    ''
    ''    ''
    ''    Dim strPathToNotesFolder As String
    ''    Dim strPathToNotesFileTXT As String
    ''11/2023 
    ''    strPathToNotesFolder = DiskFolders.PathToFolder_Notes()
    ''    strPathToNotesFileTXT = DiskFilesVB.PathToNotes_HowContextMenusAreGenerated()
    ''    System.Diagnostics.Process.Start(strPathToNotesFileTXT)
    ''11/2023 
    ''End Sub ''end of "Public Sub How_Context_Menus_Are_Generated_EE1002(sender As Object, e As EventArgs)"


    Private Sub CreateVisibleButtonMaster(par_strText As String, par_handler As EventHandler, ByRef pboolExitEarly As Boolean,
                                           Optional pboolAlignment As Boolean = False)
        ''10/10/2019 td''Private Sub CreateVisibleButton_Master(
        ''
        ''Added 8/13/2019 td  
        ''
        ''10/2/2019 td''If (mod_bBypassCreateButton) Then
        ''    ''Added 8/13/2019 td  
        ''    pboolExitEarly = False  ''Reinitialize. 
        ''    mod_bBypassCreateButton = False ''Reinitialize. 

        ''10/2/2019 td''ElseIf (Me.LayoutFunctions.OkayToShowFauxContextMenu()) Then
        ''    ''8/14/2019 td''ElseIf (mc_CreateVisibleButtonForDemo) Then
        ''    ''9/19/2019 td''ElseIf (Me.FormDesigner.OkayToShowFauxContextMenu()) Then
        ''    ''
        ''    ''Added 8 / 13 / 2019 td 
        ''    ''
        ''    ''8/14/2019 td''CreateVisibleButton(par_strText, par_handler)
        ''    CreateFauxContextMenu(par_strText, par_handler, pboolAlignment)
        ''    mod_bBypassCreateButton = True ''Reinitialize. 
        ''    pboolExitEarly = True

        ''End If ''End of "If (mod_bBypassCreateButton) Then .... ElseIf (mc_CreateVisibleButtonForDemo) Then ...."

    End Sub ''End of "Private Sub CreateMouseButton_Master(par_strText As String, par_handler As EventHandler)"


    Private Function GetFieldObjectAny() As ciBadgeFields.ClassFieldAny

        ''Added 5/11/2022 thomas downes
        Dim enumCIBField As EnumCIBFields

        ''5/29/2022 enumCIBField = CtlCurrentElementFieldV3.ElementClass_ObjV3.FieldEnum
        enumCIBField = Me.ElementFieldV4.FieldEnum

        With Me.CacheOfFieldsEtc_Deprecated
            Return .GetFieldByFieldEnum(enumCIBField)
        End With

    End Function


    Private Function GetFieldObjectCustom() As ciBadgeFields.ClassFieldCustomized

        ''Added 5/11/2022 thomas downes
        Dim enumCIBField As EnumCIBFields
        enumCIBField = CtlCurrentElementFieldV4.ElementClass_ObjV4.FieldEnum
        With Me.CacheOfFieldsEtc_Deprecated
            Return .GetFieldByFieldEnum_Custom(enumCIBField)
        End With

    End Function


    Private Function GetFieldObjectStandard() As ciBadgeFields.ClassFieldStandard

        ''Added 5/11/2022 thomas downes
        Dim enum_field As EnumCIBFields
        enum_field = CtlCurrentElementFieldV4.ElementClass_ObjV4.FieldEnum
        With Me.CacheOfFieldsEtc_Deprecated
            Return .GetFieldByFieldEnum_Standard(enum_field)
        End With

    End Function


End Class

