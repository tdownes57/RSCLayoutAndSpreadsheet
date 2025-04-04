﻿Option Explicit On
Option Strict On
Option Infer Off
''
''Added 10/1/2019 td
''

Imports ciBadgeInterfaces
Imports ciBadgeDesigner
''----Imports ciBadgeElements
Imports System.Windows.Forms ''Added 12/27/2021 td 
Imports System.Drawing ''Added 1/8/2022 thomas d. 

Public Class Operations_EditFieldElement
    ''
    ''Added 10/1/2019 td
    ''
    ''Names of procedures in this module: 
    ''
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
    Public Property Parent_MenuCache As MenuCache_FieldElements ''Added 12/12/2021 td 

    Public WithEvents MyLinkLabel As New LinkLabel ''Added 10/11/2019 td 
    Public WithEvents MyToolstripItem As New ToolStripMenuItem ''Added 10/11/2019 td 

    Public Property CtlCurrentElement As ciBadgeDesigner.CtlGraphicFldLabel ''CtlGraphicFldLabel
    Public Property LayoutFunctions As ILayoutFunctions ''Added 10/3/2019 td 
    Public Property Designer As ciBadgeDesigner.ClassDesigner
    Public Property ColorDialog1 As ColorDialog ''Added 10/3/2019 td 
    Public Property FontDialog1 As FontDialog ''Added 10/3/2019 td 

    ''---not needed 10/3/2019 td----Public Property GroupEdits As ClassGroupMove ''Added 10/3/2019 td 
    Public Property SelectingElements As ISelectingElements ''Added 10/3/2019 td 

    ''Added 12/12/2021 thomas 
    ''Public Property ListOfFields_Standard As HashSet(Of ciBadgeFields.ClassFieldStandard)
    ''Public Property ListOfFields_Custom As HashSet(Of ciBadgeFields.ClassFieldCustomized)
    Public Property CacheOfFieldsEtc As ciBadgeCachePersonality.ClassElementsCache_Deprecated

    Private mod_fauxMenuEditSingleton As CtlGraphPopMenuEditSingle ''Added 10/3/2019 td 

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

    Public Sub Open_Field_Of_Element_EE1011(sender As Object, e As EventArgs)
        ''Private Sub OpenDialog_Field(sender As Object, e As EventArgs)
        ''
        ''Added 7/30/2019 thomas downes
        ''       ''
        ''   We will use Reflection to convert the procedures in class Operations_EditFieldElement to clickable LinkLabels.
        ''      (See procedure MenuCache_FieldElements.Generate_BasicEdits().)
        ''
        ''7/30/2019 td''ColorDialog1.ShowDialog()
        Dim bIsCustomField As Boolean ''Added 12/14/2021 
        Const c_boolTryNewSub As Boolean = True ''Added 12/14/2021 td

        bIsCustomField = (CtlCurrentElement.ElementClass_Obj.FieldObjectCustom IsNot Nothing)

        If (bIsCustomField And c_boolTryNewSub) Then

            ''Added 12/14/2021 thomas d. 
            Open_FieldStandard_OrCustom(New ListCustomFields())

        ElseIf (bIsCustomField) Then
            ''Encapsulated 12/14/2021 thomas d. 
            Open_FieldCustomized()

        Else
            ''Added 12/14/2021 thomas d. 
            Open_FieldStandard_OrCustom(New ListStandardFields())

        End If ''End of "End of "If (bIsCustomField) Then ... Else ..."

    End Sub ''eNd of "Public Sub Open_Field_Of_Element_EE1011(sender As Object, e As EventArgs)"


    Private Sub Open_FieldCustomized()
        ''
        ''Encapsulated 12/14/2021 thomas d. 
        ''
        Dim form_ToShow As New ListCustomFields

        Dim boolExitEarly As Boolean ''Added 8/13/2019 td
        ''10/10/2019 td''CreateVisibleButton_Master("Choose a background color", AddressOf OpenDialog_Color, boolExitEarly)
        If (boolExitEarly) Then Exit Sub ''Added 8/13/2019 td

        ''Can (should) we just show a single field? ''form_ToShow.JustOneField = Me.FieldInfo
        ''10/2/2019 td''form_ToShow.JustOneField_Index = Me.FieldInfo.FieldIndex
        form_ToShow.JustOneField_Index = CtlCurrentElement.FieldInfo.FieldIndex

        ''Added 12/13/2021 thomas downes
        form_ToShow.JustOneField_Any = CtlCurrentElement.ElementClass_Obj.FieldObjectAny
        form_ToShow.JustOneField_Custom = CtlCurrentElement.ElementClass_Obj.FieldObjectCustom
        form_ToShow.JustOneField_Standard = CtlCurrentElement.ElementClass_Obj.FieldObjectStandard

        ''Added 12/12/2021 td
        ''--form_ToShow.ListOfFields_Custom = MenuCache_ElemFlds.CacheOfFieldsEtc.ListOfFields_Custom
        ''--form_ToShow.ListOfFields_Standard = MenuCache_ElemFlds.CacheOfFieldsEtc.ListOfFields_Standard
        form_ToShow.ListOfFields_Custom = Me.CacheOfFieldsEtc.ListOfFields_Custom ''--MenuCache_ElemFlds.CacheOfFieldsEtc.ListOfFields_Custom
        form_ToShow.ListOfFields_Standard = Me.CacheOfFieldsEtc.ListOfFields_Standard ''--MenuCache_ElemFlds.CacheOfFieldsEtc.ListOfFields_Standard

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
        par_form_ToShow.JustOneField_Index = CtlCurrentElement.FieldInfo.FieldIndex

        ''Added 12/13/2021 thomas downes
        par_form_ToShow.JustOneField_Any = CtlCurrentElement.ElementClass_Obj.FieldObjectAny
        par_form_ToShow.JustOneField_Custom = CtlCurrentElement.ElementClass_Obj.FieldObjectCustom
        par_form_ToShow.JustOneField_Standard = CtlCurrentElement.ElementClass_Obj.FieldObjectStandard

        ''Added 12/12/2021 td
        ''--form_ToShow.ListOfFields_Custom = MenuCache_ElemFlds.CacheOfFieldsEtc.ListOfFields_Custom
        ''--form_ToShow.ListOfFields_Standard = MenuCache_ElemFlds.CacheOfFieldsEtc.ListOfFields_Standard
        par_form_ToShow.ListOfFields_Custom = Me.CacheOfFieldsEtc.ListOfFields_Custom ''--MenuCache_ElemFlds.CacheOfFieldsEtc.ListOfFields_Custom
        par_form_ToShow.ListOfFields_Standard = Me.CacheOfFieldsEtc.ListOfFields_Standard ''--MenuCache_ElemFlds.CacheOfFieldsEtc.ListOfFields_Standard

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

        If (Me.SelectingElements.LabelsList_IsItemUnselected(Me.CtlCurrentElement)) Then
            ''10/3 td''If (LabelsList_IsItemUnselected(Me)) Then

            ''7/30/2019 td''Me.ElementInfo.FontColor = ColorDialog1.Color
            ''8/29/2019 td''Me.ElementInfo.BackColor = ColorDialog1.Color
            ''10/3/2019 td''Me.ElementInfo_Base.Back_Color = ColorDialog1.Color
            Me.CtlCurrentElement.ElementInfo_Base.Back_Color = Me.ColorDialog1.Color

            ''Me.ElementInfo.Width_Pixels = Me.Width
            ''Me.ElementInfo.Height_Pixels = Me.Height

            Application.DoEvents()
            Application.DoEvents()

            ''9/15/2019 td ''Refresh_Image()
            ''10/3/2019 td ''Refresh_Image(True)

            Me.CtlCurrentElement.Refresh_Image(True)
            Me.CtlCurrentElement.Refresh()

        ElseIf (Me.SelectingElements.LabelsList_IsItemIncluded(Me.CtlCurrentElement)) Then
            ''10/3/2019 td''ElseIf (LabelsList_IsItemIncluded(Me)) Then

            ''Added 8/3/2019 td 
            ''10/17/2019 td''Dim objElements As List(Of CtlGraphicFldLabel)
            Dim objElements As HashSet(Of CtlGraphicFldLabel)

            ''8/4//2019 td'objElements = CType(Me.ParentForm, ISelectingElements).LabelsDesignList_AllItems
            ''10/3/2019 td''objElements = Me.SelectingElements.LabelsDesignList_AllItems
            objElements = Me.SelectingElements.LabelsDesignList_AllItems

            ''If (objElements.Count = 0) Then
            ''   objElements.Add(Me)
            '' End If

            For Each each_ctl As CtlGraphicFldLabel In objElements
                ''
                ''Added 8/3/2019 td  
                ''
                With each_ctl

                    ''8/29/2019 td''.ElementInfoBase.BackColor = ColorDialog1.Color
                    .ElementInfo_Base.Back_Color = Me.ColorDialog1.Color
                    ''.ElementInfo.Width_Pixels = Me.Width
                    ''.ElementInfo.Height_Pixels = Me.Height

                    .Refresh_Image(True)
                    .Refresh()

                End With

            Next each_ctl

        End If ''End of "If (Me.SelectingElements.LabelsList_IsItemUnselected(Me)) Then ... ElseIf (Me.SelectingElements.LabelsList_IsItemIncluded(Me)) Then"

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


    Public Sub Open_Dialog_Font_EE1009(sender As Object, e As EventArgs)
        ''
        ''Added 7/30/2019 thomas downes
        ''       ''
        ''   We will use Reflection to convert the procedures in class Operations_EditFieldElement to clickable LinkLabels.
        ''      (See procedure MenuCache_FieldElements.Generate_BasicEdits().)
        ''
        Dim boolExitEarly As Boolean ''Added 8/13/2019 td

        ''10/10/2019 td''CreateVisibleButton_Master("Choose a text font", AddressOf OpenDialog_Font, boolExitEarly)
        ''10/10/2019 td''Application.DoEvents()

        ''Added 8/17/2019 td
        ''10/10/2019 td''If (mod_fauxMenuEditSingleton Is Nothing) Then mod_fauxMenuEditSingleton = New CtlGraphPopMenuEditSingle

        ''10/10/2019 td''mod_fauxMenuEditSingleton.SizeToExpectations()

        If (boolExitEarly) Then Exit Sub ''Added 8/13/2019 td

        Me.FontDialog1.Font = Me.CtlCurrentElement.ElementClass_Obj.Font_DrawingClass ''Added 7/31/2019 td  

        ''
        ''Major call !!   Show the font-selection dialog to the user. 
        '' 
        Me.FontDialog1.ShowDialog()

        ''Me.ElementInfo.Font_DrawingClass = FontDialog1.Font
        ''Application.DoEvents()
        ''Application.DoEvents()
        ''RefreshImage()
        ''Me.Refresh()

        If (Me.SelectingElements.LabelsList_IsItemUnselected(Me.CtlCurrentElement)) Then

            Me.CtlCurrentElement.ElementInfo_TextOnly.Font_DrawingClass = Me.FontDialog1.Font

            ''Added 10/17/2019 td 
            If (Me.FontDialog1.Font.Unit = GraphicsUnit.Pixel) Then
                ''Added 10/17/2019 td 
                MsgBox("Program error, unexpected Font Unit", MsgBoxStyle.Exclamation, "OpenDialog_Font")
            Else
                Me.CtlCurrentElement.ElementInfo_TextOnly.FontSize_Pixels = Me.FontDialog1.Font.Size  ''Added 8/17/2019 td
            End If ''End of "If (Me.FontDialog1.Font.Unit = GraphicsUnit.Pixel) Then ... Else ..."

            Application.DoEvents()
            Application.DoEvents()

            ''9/15/2019 td''Refresh_Image()
            ''10/3/2019 td''Refresh_Image(False)
            ''10/3/2019 td''Me.Refresh()
            Me.CtlCurrentElement.Refresh_Image(False)
            Me.CtlCurrentElement.Refresh()

        ElseIf (Me.SelectingElements.LabelsList_IsItemIncluded(Me.CtlCurrentElement)) Then

            ''Added 8/3/2019 td 
            Dim objElements As HashSet(Of CtlGraphicFldLabel)

            ''10/3/2019 td''objElements = CType(Me.ParentForm, ISelectingElements).LabelsDesignList_AllItems
            objElements = Me.SelectingElements.LabelsDesignList_AllItems

            For Each each_ctl As CtlGraphicFldLabel In objElements
                ''
                ''Added 8/3/2019 td  
                ''
                With each_ctl

                    ''Added 10/17/2019 td  
                    If (FontDialog1.Font.Unit <> GraphicsUnit.Pixel) Then Throw New Exception("Unexpected Font Unit")

                    .ElementInfo_TextOnly.Font_DrawingClass = FontDialog1.Font
                    ''Added 10/17/2019 td  
                    .ElementInfo_TextOnly.FontSize_Pixels = FontDialog1.Font.Size

                    Application.DoEvents()
                    Application.DoEvents()
                    .Refresh_Image(True)
                    .Refresh()

                End With

            Next each_ctl

        End If ''End of "If (Me.SelectingElements.LabelsList_IsItemUnselected(Me)) Then... Else ..."

        ''Added 9/13/2019 td
        ''9/19/2019 td''Me.FormDesigner.AutoPreview_IfChecked()
        Me.LayoutFunctions.AutoPreview_IfChecked()

    End Sub ''eNd of "Private Sub "Open_Dialog_Font_EE1009(sender As Object, e As EventArgs)"


    Public Sub ExampleValue_Edit_EE1006(sender As Object, e As EventArgs)
        ''
        ''Added 8/10/2019 thomas downes
        ''       ''
        ''   We will use Reflection to convert the procedures in class Operations_EditFieldElement to clickable LinkLabels.
        ''      (See procedure MenuCache_FieldElements.Generate_BasicEdits().)
        ''
        ''10/17 td''With textTypeExample
        With Me.CtlCurrentElement.Textbox_ExampleValue

            .Visible = True
            .Text = Me.CtlCurrentElement.ElementInfo_TextOnly.Text_Static ''Added 8/16/2019 td
            .SelectAll() ''Added 8/16/2019 td

            ''Added 9/10/2019 td 
            ''  Put the focus on the textbox. 
            .Select() ''Added 9/10/2019 td 

        End With ''End of "With Me.CtlCurrentElement.Textbox_Example"

    End Sub ''End of "Public Sub ExampleValue_Edit_EE1006(sender As Object, e As EventArgs)"  

    Public Sub Open_OffsetText_Dialog_EE1007(sender As Object, e As EventArgs)
        ''
        ''Added 8/10/2019 thomas downes
        ''       ''
        ''   We will use Reflection to convert the procedures in class Operations_EditFieldElement to clickable LinkLabels.
        ''      (See procedure MenuCache_FieldElements.Generate_BasicEdits().)
        ''
        ''9/18/2019 td''Dim frm_ToShow As New DialogTextOffset

        With Me.CtlCurrentElement

            Dim frm_ToShow As New DialogTextOffset(.ElementClass_Obj, .ElementClass_Obj.Copy(), Me.CtlCurrentElement)

            ''
            ''Added 8/10/2019 thomas downes
            ''
            ''8/16/2019 td''frm_ToShow.LoadFieldAndForm(Me.FieldInfo, Me.FormDesigner, Me)
            ''9/03/2019 td''frm_ToShow.LoadFieldAndForm(Me.ElementInfo_Text, Me.FieldInfo, Me.FormDesigner, Me)
            ''9/18/2019 td''frm_ToShow.LoadFieldAndForm(Me.ElementInfo_Base, Me.ElementInfo_Text, Me.FieldInfo, Me.FormDesigner, Me)
            ''9/19/2019 td''frm_ToShow.LoadFieldAndForm(Me.FormDesigner, Me)
            frm_ToShow.LoadFieldAndForm(Me.LayoutFunctions, Me.CtlCurrentElement)

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
                    .Refresh_Image(True)

                End If ''End of "If (frm_ToShow.UserConfirmed) Then"

                ''
                ''
                ''Group Editimg
                ''
                ''
                ''Added 8/18/2019 td 
                If (Me.SelectingElements.LabelsList_IsItemIncluded(Me.CtlCurrentElement)) Then

                    ''Added 8/18/2019 td 
                    Dim objElements As HashSet(Of CtlGraphicFldLabel)
                    objElements = Me.SelectingElements.LabelsDesignList_AllItems

                    For Each each_ctl As CtlGraphicFldLabel In objElements
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

                            .Refresh_Image(True)
                            .Refresh()

                        End With ''End of " With each_ctl"

                    Next each_ctl

                End If ''ENdo f "If (Me.SelectingElements.LabelsList_IsItemIncluded(Me)) Then"

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
        Dim boolIsLatest As Boolean ''Dec. 12, 2021 td
        Dim boolIsCopyOfLatest As Boolean ''Dec. 12, 2021 td

        ''Added 12/12/2021 thomas downes
        Me.CacheOfFieldsEtc.CheckCacheIsLatestForEdits(boolIsLatest, boolIsCopyOfLatest)
        If (Not boolIsLatest) Then Throw New Exception("This is not the latest cache of edits.")

        With Me.CtlCurrentElement ''Added 10/17/2019 td

            Dim frm_ToShow As New DialogTextBorder(.ElementClass_Obj, .ElementClass_Obj.Copy())
            ''Denigrated. 9/19 td''frm_ToShow.LoadFieldAndForm(Me.FormDesigner, Me)
            frm_ToShow.LoadFieldAndForm(Me.LayoutFunctions, Me.CtlCurrentElement)

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

                .Refresh_Image(True)

                ''
                ''
                ''Group Editimg
                ''
                ''
                ''Added 8/18/2019 td 
                If (Me.SelectingElements.LabelsList_IsItemIncluded(Me.CtlCurrentElement)) Then

                    ''Added 8/18/2019 td 
                    Dim objElements As HashSet(Of CtlGraphicFldLabel)
                    objElements = Me.SelectingElements.LabelsDesignList_AllItems

                    For Each each_ctl As CtlGraphicFldLabel In objElements
                        ''
                        ''Added 8/3/2019 td  
                        ''
                        With each_ctl

                            ''9/18/2019 td''.ElementInfo_Base.Border_WidthInPixels = frm_ToShow.Border_SizeInPixels
                            ''9/18/2019 td''.ElementInfo_Base.Border_Color = frm_ToShow.Border_Color
                            ''9/18/2019 td''.ElementInfo_Base.Border_Displayed = frm_ToShow.Border_Displayed ''9/9 td

                            ''Added 9/18/2019 td 
                            frm_ToShow.UpdateInfo_ViaInterface(.ElementInfo_Base)

                            .Refresh_Image(True)
                            .Refresh()

                        End With

                    Next each_ctl

                End If ''End of "If (Me.SelectingElements.LabelsList_IsItemIncluded(Me)) Then"

            End If ''End of "If (boolUserPressedOK) Then"

        End With ''End of "With Me.CtlCurrentElement"

        ''Added 9/13/2019 td
        ''9/19/2019 td''Me.FormDesigner.AutoPreview_IfChecked()
        Me.LayoutFunctions.AutoPreview_IfChecked()

    End Sub ''End of "Public Sub Border_Design_EE1000(sender As Object, e As EventArgs)"

    Public Sub Rotate90_Degrees_EE1001(sender As Object, e As EventArgs)
        ''
        ''Added 8/17/2019 thomas downes
        ''         ''
        ''   We will use Reflection to convert the procedures in class Operations_EditFieldElement to clickable LinkLabels.
        ''      (See procedure MenuCache_FieldElements.Generate_BasicEdits().)
        ''
        With Me.CtlCurrentElement.ElementInfo_Base

            Select Case .OrientationToLayout
                Case "", " ", "P"
                    .OrientationToLayout = "L"
                Case "L"
                    .OrientationToLayout = "P"
                Case Else
                    .OrientationToLayout = "P"
            End Select

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
        Me.CtlCurrentElement.Refresh_Master()

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


    Public Sub How_Context_Menus_Are_Generated_EE9001(sender As Object, e As EventArgs)
        ''---Dec15 2021--Public Sub How_Context_Menus_Are_Generated_EE1001
        ''
        ''Added 12/12/2021 thomas downes  
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

    End Sub ''end of "Public Sub How_Context_Menus_Are_Generated_EE1002(sender As Object, e As EventArgs)"


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


End Class
