Option Explicit On
Option Strict On
Option Infer Off

''
''Added 9/9/2019 td  
''
Imports ciBadgeInterfaces ''added 9/8 
''9/9/2019 td''Imports ControlManager
Imports MoveAndResizeControls_Monem
Imports ciLayoutPrintLib ''Added 8/28/2019 thomas d. 
Imports System.Collections.Generic ''Added 9.6.2019 td 

Partial Public Class FormMainEntry_v90
    ''
    ''Added 9/09/2019 thomas downes  
    ''
    Private mod_imageLady As Image
    Private mod_imagePortrait As CtlGraphicPortrait
    Private Const mc_boolMoveableElements As Boolean = True
    Private vbCrLf_Deux As String = (vbCrLf & vbCrLf) ''Added 7/31/2019 td 
    Private Const mc_boolAllowGroupMovements As Boolean = False ''True ''False ''True ''False ''Added 8/3/2019 td  
    Private WithEvents mod_groupedMove As New ClassGroupMove() ''8/4/2019 td''New ClassGroupMove

    Public Function Layout_Width_Pixels() As Integer Implements ILayoutFunctions.Layout_Width_Pixels
        ''Added 9/3/2019 thomas downes

        ''9/9 td''Return pictureBack.Width
        Return Me.BackgroundImage.Width

    End Function ''End of "Public Function Layout_Width_Pixels() As Integer"

    Public Function Layout_Height_Pixels() As Integer Implements ILayoutFunctions.Layout_Height_Pixels
        ''Added 9/12/2019 thomas downes

        Return Me.BackgroundImage.Height

    End Function ''End of "Public Function Layout_Width_Pixels() As Integer"

    Public Function Layout_Margin_Left_Omit(par_intPixelsLeft As Integer) As Integer Implements ILayoutFunctions.Layout_Margin_Left_Omit
        ''Added 9/5/2019 thomas downes
        Return (par_intPixelsLeft - 0) ''9/9 td''pictureBack.Left)
    End Function ''End of "Public Function Layout_Margin_Left_Omit() As Integer"

    Public Function Layout_Margin_Left_Add(par_intPixelsLeft As Integer) As Integer Implements ILayoutFunctions.Layout_Margin_Left_Add
        ''Added 9/5/2019 thomas downes
        Return (par_intPixelsLeft + 0) ''9/9 td''pictureBack.Left)
    End Function ''End of "Public Function Layout_Margin_Left_Add() As Integer"

    Public Function Layout_Margin_Top_Omit(par_intPixelsTop As Integer) As Integer Implements ILayoutFunctions.Layout_Margin_Top_Omit
        ''Added 9/5/2019 thomas downes
        Return (par_intPixelsTop - 0) ''9/9 td''pictureBack.Top)
    End Function ''End of "Public Function Layout_Margin_Top_Omit() As Integer"

    Public Function Layout_Margin_Top_Add(par_intPixelsTop As Integer) As Integer Implements ILayoutFunctions.Layout_Margin_Top_Add
        ''Added 9/5/2019 thomas downes
        Return (par_intPixelsTop + 0) ''9/9 td''pictureBack.Top)
    End Function ''End of "Public Function Layout_Margin_Top_Add() As Integer"

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 9/08/2019 thomas downes 
        ''
        mod_imagePortrait = CtlGraphicPortrait_v90

        ''
        ''Major call !!
        ''
        LoadForm_LayoutElements()

        ''ControlMoverOrResizer_TD.Init(picturePreview,
        ''   picturePreview, 10, False) ''Added 9/08/2019 thomas downes

    End Sub ''End of "Private Sub FormDesignProtoTwo_Load"

    Private Sub LoadForm_LayoutElements()
        ''
        ''Added 9/9/2019 td
        ''
        Const c_boolLoadingForm As Boolean = True ''Added 8/28/2019 thomas downes  

        LoadElements_Fields_Master(c_boolLoadingForm)

        LoadElements_Picture()

        If (mc_boolMoveableElements) Then
            MakeElementsMoveable()
        End If ''End of "If (mc_boolMoveableElements) Then"

    End Sub ''ENd of "Private Sub LoadForm_LayoutElements()"

    Private Sub LoadElements_Fields_Master(par_boolLoadingForm As Boolean, Optional par_bUnloading As Boolean = False)
        ''
        ''Added 9/03/2019 thomas downes 
        ''
        ''9/4 td''Const c_boolUseConsolidatedList As Boolean = False ''True
        Const c_boolUseConsolidatedList As Boolean = True ''Added 9/5/2019 td  

        If (c_boolUseConsolidatedList) Then

            ''9/6/2019 td''LoadElements_Fields_OneList(par_boolLoadingForm, par_bUnloading)
            LoadElements_OneListOfFields(par_boolLoadingForm, par_bUnloading)

        Else

            ''9/9 td''LoadElements_Fields_TwoLists(par_boolLoadingForm, par_bUnloading)
            Throw New NotImplementedException("The consolidated list works fine, thankfully!")

        End If ''End of "If (boolUseConsolidatedList) Then ..... Else ...."

    End Sub ''ENd of "Private Sub LoadElements_Fields_Master()"

    Private Sub LoadElements_OneListOfFields(par_boolLoadingForm As Boolean, Optional par_bUnloading As Boolean = False)
        ''
        ''Added 9/6/2019 td  
        ''
        LoadElements_ByListOfFields(ClassFields.ListAllFields(), par_boolLoadingForm)

    End Sub

    Private Sub LoadField_JustOne(par_field As ICIBFieldStandardOrCustom)
        ''
        ''Added 9/6/2019 thomas d. 
        ''
        Dim new_list As New List(Of ICIBFieldStandardOrCustom)
        Const c_bAddToMoveableClass As Boolean = True ''Added 9/8/2019 td 

        new_list.Add(par_field)

        LoadElements_ByListOfFields(new_list, True, False,
                                    c_bAddToMoveableClass)

    End Sub ''End of "Private Sub LoadField_JustOne(...)"

    Private Sub LoadElements_ByListOfFields(par_list As List(Of ICIBFieldStandardOrCustom),
                                           par_boolLoadingForm As Boolean,
                                           Optional par_bUnloading As Boolean = False,
                                            Optional par_bAddMoveability As Boolean = False)
        ''
        ''Added 9/03/2019 thomas downes 
        ''Modified 9/5/2019 thomas downes
        ''
        Dim intCountControlsAdded As Integer = 0 ''Added 9/03/2019 td 
        ''9/5/2019 td''Dim intTopEdge As Integer ''Added 7/28/2019 td
        ''9/5/2019 td''Dim intLeftEdge As Integer ''Added 9/03/2019 td
        Dim boolIncludeOnBadge As Boolean = False ''Added 9/03/2019 td
        Dim intStagger As Integer = 0 ''Added 9.6.2019 td 

        For Each each_field As ICIBFieldStandardOrCustom In par_list ''9/6/2019 td''ClassFields.ListAllFields()

            ''9/9/2019 td''Dim label_control As CtlGraphicFldLabel
            Dim label_control As CtlMainEntryBox_v90

            ''Added 9/3/2019 thomas d. 
            boolIncludeOnBadge = (par_boolLoadingForm And each_field.IsDisplayedOnBadge)
            If (Not boolIncludeOnBadge) Then
                AddToFlowPanelOfOmittedFlds(each_field)
                Continue For
            End If ''End of "If (Not boolIncludeOnBadge) Then"

            ''
            ''Has the user moved the field into place (and pressed the Save & Refresh link)??
            ''
            If (each_field.ElementInfo_Base Is Nothing) Then

                Dim new_element_text As New ClassElementText

                new_element_text.Height_Pixels = 30
                new_element_text.FontSize_Pixels = 25

                ''''9/6/2019 td''new_element_text.TopEdge_Pixels = (30 + (30 * intCountControlsAdded))
                ''intStagger = intCountControlsAdded
                ''new_element_text.TopEdge_Pixels = (intStagger * new_element_text.Height_Pixels)
                ''intCountControlsAdded += 1 ''Added 9/6/2019 td 

                ''new_element_text.LeftEdge_Pixels = new_element_text.TopEdge_Pixels ''Left = Top !! By setting Left = Top, we will create 
                ''''   a nice diagonally-cascading effect. ---9/3/2019 td

                each_field.ElementInfo_Base = new_element_text
                each_field.ElementInfo_Text = new_element_text

            End If ''ENd of "If (each_field.ElementInfo_Base Is Nothing) Then"

            ''Added 9/5/2019 thomas d.
            ''9/12/2019 td''each_field.ElementInfo_Base.LayoutWidth_Pixels = Me.Layout_Width_Pixels()
            each_field.ElementInfo_Base.BadgeLayout.Width_Pixels = Me.Layout_Width_Pixels()
            each_field.ElementInfo_Base.BadgeLayout.Height_Pixels = Me.Layout_Height_Pixels()

            ''#1 9/4/2019 td''label_control = New CtlGraphicFldLabel(each_field, Me)
            '' #2 9/4/2019 td''label_control = New CtlGraphicFldLabel(each_field, new_element_text, Me)
            ''9/9/2019 td''label_control = New CtlGraphicFldLabel(each_field, Me)

            label_control = New CtlMainEntryBox_v90(each_field, Me)

            ''Moved below. 9/5 td''label_control.Refresh_Master()
            label_control.Visible = each_field.IsDisplayedOnBadge ''BL = Badge Layout
            intCountControlsAdded += 1
            label_control.Name = "FieldControl" & CStr(intCountControlsAdded)

            ''9/8 td''label_control.BorderStyle = BorderStyle.FixedSingle

            ''Added 9/6/2019 thomas downes 
            ''
            ''   Stagger the elements on the badge layout, in a cascade from
            '' the upper-left to the lower-right. 
            '' ------9/6/2019 td
            ''
            If (0 = each_field.ElementInfo_Base.TopEdge_Pixels) Then

                ''Added 9/6/2019 thomas downes 
                ''9/9/2019 td''label_control.Width = CInt(pictureBack.Width / 3)
                label_control.Width = CInt(Me.BackgroundImage.Width / 7)

                With each_field.ElementInfo_Base
                    .Width_Pixels = label_control.Width
                    .Height_Pixels = label_control.Height
                    intStagger = intCountControlsAdded
                    .TopEdge_Pixels = (intStagger * .Height_Pixels)
                    .LeftEdge_Pixels = .TopEdge_Pixels ''Left = Top !! By setting Left = Top, we will create 
                    ''   a nice diagonally-cascading effect. ---9/3/2019 td
                    ''See above. 9/6/2019 td''intCountControlsAdded += 1 ''Added 9/6/2019 td 
                End With ''End of " With each_field.ElementInfo_Base"
            End If ''ENd of "If (0 = each_field.ElementInfo_Base.TopEdge_Pixels) Then"

            boolIncludeOnBadge = (par_boolLoadingForm And each_field.IsDisplayedOnBadge)

            If (boolIncludeOnBadge) Then

                Me.Controls.Add(label_control)
                label_control.Visible = True
                label_control.BringToFront() ''Added 9/7/2019 thomas d.  
                ''9/5/2019''label_control.Refresh_Image(True)
                label_control.GroupEdits = CType(Me, ISelectingElements) ''Added 8/1 td

                ''Added 9/7/2019 td
                label_control.Left = Me.Layout_Margin_Left_Add(each_field.ElementInfo_Base.LeftEdge_Pixels)
                label_control.Top = Me.Layout_Margin_Top_Add(each_field.ElementInfo_Base.TopEdge_Pixels)

                ''
                ''Major call !!  ----Thomas DOWNES
                ''
                label_control.Refresh_Master()

                ''Added 9/8/2019 td
                If (par_bAddMoveability) Then ControlMoverResizer_AddFieldCtl(label_control)

            ElseIf (par_bUnloading) Then
                ''9/3/2019 td''Me.Controls.Remove(label_control)
                Throw New NotImplementedException

            End If ''End of "If (boolInludeOnBadge) Then .... ElseIf (....) ...."

        Next each_field

        ''
        ''Added 8/27/2019 thomas downes
        ''
        ''9/9 td''pictureBack.SendToBack() ''Added 9/7/2019 thomas d.
        Me.Refresh() ''Added 8/28/2019 td   

        ''9/5/2019 td''MessageBox.Show($"Number of field controls now on the form: {intCountControlsAdded}", "",
        ''     MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub ''End of ''Private Sub LoadElements_Fields_OneList()''

    Private Sub MakeElementsMoveable()
        ''
        ''Added 7/19/2019 thomas downes  
        ''
        ''8/4/2019 td''Dim boolAllowGroupMovements As Boolean = False ''True ''False ''Added 8/3/2019 td  
        ''
        ''Portrait
        ''
        If (mc_boolAllowGroupMovements) Then

            ControlMove_GroupMove_TD.Init(mod_imagePortrait.Picture_Box,
                      mod_imagePortrait, 10, True, mod_groupedMove, False) ''Added 8/3/2019 thomas downes
        Else
            ControlMoverOrResizer_TD.Init(mod_imagePortrait.Picture_Box,
                  mod_imagePortrait, 10, True, False) ''Added 7/31/2019 thomas downes

        End If ''End of " If (mc_boolAllowGroupMovements) Then .... Else ...."

        ''
        ''Fields
        ''
        Dim each_entryLabelAndBox As CtlMainEntryBox_v90 ''Added 7/19/2019 thomas downes  

        For Each each_control As Control In Me.Controls ''Added 7/19/2019 thomas downes  

            If (TypeOf each_control Is CtlMainEntryBox_v90) Then

                ''9/9/2019 td''each_graphicLabel = CType(each_control, CtlGraphicFldLabel)
                each_entryLabelAndBox = CType(each_control, CtlMainEntryBox_v90)

                ''7/31/2019 td''ControlMoverOrResizer_TD.Init(each_graphicLabel.Picture_Box,
                ''                each_control, 10) ''Added 7/28/2019 thomas downes

                ControlMoverResizer_AddFieldCtl(each_entryLabelAndBox)

            End If ''End of "If (TypeOf each_control Is GraphicFieldLabel) Then"

        Next each_control

    End Sub ''End of "Private Sub MakeElementsMoveable()"

    Private Sub ControlMoverResizer_AddFieldCtl(par_entryFieldCtl As CtlMainEntryBox_v90)
        ''
        ''Encapsulated 9/7/2019 thomas d
        ''
        Const c_bRepaintAfterResize As Boolean = True ''Added 7/31/2019 tdpoint 
        Const c_bBreakpoint As Boolean = True ''Added 9/13/2019 td

        If (mc_boolAllowGroupMovements) Then
            ControlMove_GroupMove_TD.Init(par_entryFieldCtl.LabelCaption,
                          par_entryFieldCtl, 10, c_bRepaintAfterResize,
                          mod_groupedMove, c_bBreakpoint) ''Added 8/3/2019 td 
        Else
            ControlMoverOrResizer_TD.Init(par_entryFieldCtl.LabelCaption,
                          par_entryFieldCtl, 10, c_bRepaintAfterResize,
                          c_bBreakpoint) ''Added 7/28/2019 thomas downes
        End If ''End of "If (boolAllowGroupMovements) Then ...... Else ..."

    End Sub ''End of "Private Sub ControlMoverResizer_AddField"

    Private Sub LoadElements_Picture()
        ''
        ''Added 7/31/2019 thomas downes 
        ''
        ''7/31 td''Dim new_picControl As CtlGraphicPortrait ''Added 7/31/2019 td  

        ''Added 8/22/2019 THOMAS D.
        ciPictures_VB.PictureExamples.PathToFolderOfImages = (My.Application.Info.DirectoryPath & "\Images\PictureExamples")

        If (ClassElementPic.ElementPicture Is Nothing) Then

            ClassElementPic.ElementPicture = New ClassElementPic

            With ClassElementPic.ElementPicture

                .Width = mod_imagePortrait.Width
                .Height = mod_imagePortrait.Height

                .TopEdge = mod_imagePortrait.Top
                .LeftEdge = mod_imagePortrait.Left

                ''Added 8/12/2019 td
                Dim bSwitchWidthHeight As Boolean ''Added 8/12/2019 td
                bSwitchWidthHeight = ("L" = ClassElementPic.ElementPicture.OrientationToLayout)

                ''Added 8/12/2019 td
                ''Switch width & height.  
                If (bSwitchWidthHeight) Then
                    ''Switch width & height.  
                    .Width = mod_imagePortrait.Height
                    .Height = mod_imagePortrait.Width
                End If ''End of "If (bSwitchWidthHeight) Then"

            End With ''End of "With field_standard.ElementInfo"

        End If ''End of "If (ClassElementPic.ElementPicture Is Nothing) Then"

        ''#1 7/31/2019 td''new_picControl = New CtlGraphicPortrait(ClassElementPic.ElementPicture)
        '' #2 7/31/2019 td''new_picControl = New CtlGraphicPortrait(ClassElementPic.ElementPicture,
        ''      CType(ClassElementPic.ElementPicture, IElementPic))
        '' #2 7/31/2019 td''Me.Controls.Add(new_picControl)

        ''
        ''DIFFICULT & CONFUSING.....  Let's regenerate the control referenced above.  
        ''
        mod_imagePortrait = New CtlGraphicPortrait(ClassElementPic.ElementPicture,
                                                 CType(ClassElementPic.ElementPicture, IElementPic), Me)

        Me.Controls.Add(mod_imagePortrait)

        With mod_imagePortrait

            .Top = ClassElementPic.ElementPicture.TopEdge
            .Left = ClassElementPic.ElementPicture.LeftEdge
            .Width = ClassElementPic.ElementPicture.Width
            .Height = ClassElementPic.ElementPicture.Height

            ''Added 8/18/2019 td
            .picturePortrait.Image = mod_imageLady

        End With ''End of "With CtlGraphicPortrait1"

    End Sub ''End of " Private Sub LoadElements_Picture()"

    Private Sub AddToFlowPanelOfOmittedFlds(par_field As ICIBFieldStandardOrCustom)
        ''
        ''Added 9/6/2019 td
        ''
        Dim new_linkLabel As New LinkLabel
        new_linkLabel.Tag = par_field
        new_linkLabel.Text = par_field.FieldLabelCaption
        flowFieldsNotListed.Controls.Add(new_linkLabel)
        new_linkLabel.Visible = True

        ''Added 9/7/2019 thomas downes
        AddHandler new_linkLabel.LinkClicked, AddressOf AddField_LinkClicked

    End Sub ''End of "Private Sub AddToFlowPanelOfOmittedFlds(par_field As ICIBFieldStandardOrCustom)"

    Private Sub AddField_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) ''9/7/2019 td''Handles linkSaveAndRefresh.LinkClicked
        ''
        ''Added 9/7/2019 thomas d
        ''
        Dim field_to_add As ICIBFieldStandardOrCustom
        field_to_add = CType(CType(sender, LinkLabel).Tag, ICIBFieldStandardOrCustom)
        If (field_to_add Is Nothing) Then Exit Sub
        field_to_add.IsDisplayedOnBadge = True
        LoadField_JustOne(field_to_add)
        flowFieldsNotListed.Controls.Remove(CType(sender, LinkLabel))

    End Sub ''End of "Private Sub AddField_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)"

End Class