Option Explicit On
Option Strict On
Option Infer Off
''
''Added 10/1/2019 thomas downes 
''
Imports System.Windows.Forms ''Added 10/1/2019 thomas downes 
Imports ciBadgeInterfaces ''Added 10/1/2019 thomas downes 
Imports ciBadgeElements ''Added 10/1/2019 thomas downes 
Imports System.Drawing ''Added 10/1/2019 thomas downes 
Imports ciLayoutPrintLib ''Added 10/1/2019 td
Imports MoveAndResizeControls_Monem ''Added 10/3/2019 td

''10/1/2019 td''Public Event ElementField_Clicked(par_elementField As ClassElementField)

Public Class ClassDesigner
    Implements ILayoutFunctions, ISelectingElements
    ''
    ''Added 10/1/2019 thomas downes 
    ''
    Public Event ElementRightClicked(par_control As CtlGraphicFldLabel) ''Added 10/1/2019 td

    ''10/1/2019 td''Public Property LayoutFunctions As ILayoutFunctions
    Public Property DesignerForm As Form
    Public Property BackgroundBox As PictureBox

    Public Property PreviewLayoutAsImage As Boolean = True ''Added 10.1.2019 thomas d. 
    Public Property PreviewBox As PictureBox

    Public Property CheckboxAutoPreview As CheckBox ''Added 10/1/2019 td
    Public Property ExamplePortraitImage As Image ''Added 10/1/2019 td 

    Public Property FlowFieldsNotListed As FlowLayoutPanel ''Added 10/1/2019 td
    Public Property CtlGraphicPortrait_Lady As CtlGraphicPortrait ''Added 10/1/2019 td

    Public Property ElementsCache_Saved As New ClassElementsCache ''Added 9/16/2019 thomas downes
    Public Property ElementsCache_Edits As New ClassElementsCache ''Added 9/16/2019 thomas downes

    ''----Public Property ControlMoverOrResizer_TD As New MoveAndResizeControls_Monem.ControlMoverOrResizer_TD ''Added 10/1/2019 td
    ''----Public Property ControlMove_GroupMove_TD As New MoveAndResizeControls_Monem.ControlMove_GroupMove_TD ''Added 10/1/2019 td

    Public Property PicInitialize_Left As Integer
    Public Property PicInitialize_Top As Integer
    Public Property PicInitialize_Width As Integer = 150 ''Default value added 10/1/2019 thomas downes
    Public Property PicInitialize_Height As Integer = 182 ''Default value added 10/1/2019 thomas downes

    ''#1 8-3-2019 td''Private WithEvents mod_moveAndResizeCtls_NA As New MoveAndResizeControls_Monem.ControlMove_RaiseEvents ''Added 8/3/2019 td  
    '' #2 8-3-2019 td''Private WithEvents mod_moveAndResizeCtls As New MoveAndResizeControls_Monem.ControlMove_GroupMove ''Added 8/3/2019 td  
    ''#1 10/1/2019 td''Private WithEvents mod_groupedMove As New ClassGroupMove(Me) ''8/4/2019 td''New ClassGroupMove
    '' #2 10/1/2019 td''Private WithEvents mod_groupedMove As New ClassGroupMove(Me.LayoutFunctions) ''8/4/2019 td''New ClassGroupMove
    Private WithEvents mod_groupedMove As New ClassGroupMove(Me) ''8/4/2019 td''New ClassGroupMove

    Private Const mc_boolAllowGroupMovements As Boolean = True ''False ''True ''False ''Added 8/3/2019 td  
    Private Const mc_boolBreakpoints As Boolean = True

    ''Added 8/18/2019 td
    Private mod_imageLady As Image ''8/18/2019 td'' = CtlGraphicPortrait_Lady.picturePortrait.Image

    ''Added 9/8/2019 td
    Private mod_rubberbandClass As ClassRubberbandSelector

    ''Added 9/20/2019 td  
    Private mod_listOfFieldControls As New List(Of CtlGraphicFldLabel)

    Private vbCrLf_Deux As String = (vbCrLf & vbCrLf)

    Public Sub LoadDesigner() ''10/1/2019 td''sender As Object, e As EventArgs) Handles MyBase.Load
        ''10/1/2019 td''Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 7/18/2019 thomas downes 
        ''
        ''Moved below.  9/20 td''Initiate_RubberbandSelector() ''Added 9/8/2019 thomas d. 

        ''
        ''Check that the proportions are correct. 
        ''
        ''9/8/2019 td''ClassLabelToImage.Proportions_CorrectWidth(Me.BackgroundBox)
        ''9/8/2019 td''ClassLabelToImage.Proportions_CorrectWidth(Me.PreviewBox)
        ClassLabelToImage.Proportions_FixTheWidth(Me.BackgroundBox) ''----- Me.BackgroundBox)
        ClassLabelToImage.Proportions_FixTheWidth(Me.PreviewBox) ''---- Me.PreviewBox)

        ''Double-check the proportions are correct. ---9/6/2019 td
        ClassLabelToImage.ProportionsAreSlightlyOff(Me.BackgroundBox, True) ''-----Me.BackgroundBox, True)
        ClassLabelToImage.ProportionsAreSlightlyOff(Me.PreviewBox, True) ''-----(Me.PreviewBox, True)

        ''
        ''I forget, what was this going to do originally?  ---9/6/2019 td
        ''
        ''9/8/2019 td''LoadElementGenerator_NotInUse()

        ''Deleted 9/4/2019 td''Me.Controls.Remove(GraphicFieldLabel1)
        ''Deleted 9/4/2019 td''Me.Controls.Remove(GraphicFieldLabel2)
        ''Deleted 9/4/2019 td''Me.Controls.Remove(GraphicFieldLabel3)
        ''Deleted 9/4/2019 td''Me.Controls.Remove(GraphicFieldLabel4)
        ''Deleted 9/4/2019 td''Me.Controls.Remove(GraphicFieldLabel5)

        ''7/31/2019 td''Me.Controls.Remove(pictureboxPic) ''Added 7/31/2019 thomas d. 
        ''10/1/2019 td''mod_imageLady = CtlGraphicPortrait_Lady.picturePortrait.Image
        mod_imageLady = Me.ExamplePortraitImage ''Added 10/1/2019 td

        ''Added 9/23/2019 td 
        ''
        ''   Save a link to the "CIB Version 9.0 Lady" so that the 
        ''   procedure ciBadgeElemImage.modGenerate's Public Sub PicImage_ByElement 
        ''   can have an image to utilize, instead of requiring that the image
        ''   be passed as an parameter.  ---9/23/2019 td
        ''
        Me.ElementsCache_Saved.Pic_InitialDefault = mod_imageLady
        Me.ElementsCache_Edits.Pic_InitialDefault = mod_imageLady

        ''10/1/2019 td''Me.Controls.Remove(CtlGraphicPortrait_Lady) ''Added 7/31/2019 thomas d. 

        ''Encapsulated 7/31/2019 td
        ''
        ''Major call !!
        ''
        ''9/8/2019 td''Load_Form()

        ''
        ''Major call!!
        ''
        Me.ElementsCache_Saved.LoadFields()
        ''10/1/2019 td''Me.ElementsCache_Saved.LoadFieldElements(Me.BackgroundBox)
        Me.ElementsCache_Saved.LoadFieldElements(Me.BackgroundBox)

        ''Added 9/19/2019 td
        Dim intPicLeft As Integer
        Dim intPicTop As Integer
        Dim intPicWidth As Integer
        Dim intPicHeight As Integer

        ''Added 9/19/2019 td
        ''10/1/2019 td''intPicLeft = CtlGraphicPortrait_Lady.Left - Me.BackgroundBox.Left
        ''10/1/2019 td''intPicTop = CtlGraphicPortrait_Lady.Top - Me.BackgroundBox.Top
        ''10/1/2019 td''intPicWidth = CtlGraphicPortrait_Lady.Width
        ''10/1/2019 td''intPicHeight = CtlGraphicPortrait_Lady.Height

        ''Added 10/01/2019 td
        intPicLeft = Me.PicInitialize_Left
        intPicTop = Me.PicInitialize_Top
        intPicWidth = Me.PicInitialize_Width
        intPicHeight = Me.PicInitialize_Height

        ''9/19 td''Me.ElementsCache_Saved.LoadPicElement(CtlGraphicPortrait_Lady.picturePortrait, Me.BackgroundBox) ''Added 9/19/2019 td
        ''10/1/2019 td''Me.ElementsCache_Saved.LoadPicElement(intPicLeft, intPicTop, intPicWidth, intPicHeight, Me.BackgroundBox) ''Added 9/19/2019 td
        Me.ElementsCache_Saved.LoadPicElement(intPicLeft, intPicTop, intPicWidth, intPicHeight, Me.BackgroundBox) ''Added 9/19/2019 td

        ''Added 9/24/2019 thomas 
        ''10/1/2019 td''Dim serial_tools As New ciBadgeSerialize.ClassSerial
        ''10/1/2019 td''serial_tools.PathToXML = (System.IO.Path.GetRandomFileName() & ".xml")
        ''10/1/2019 td''serial_tools.SerializeToXML(Me.ElementsCache_Saved.GetType, Me.ElementsCache_Saved, False, True)

        Me.ElementsCache_Edits = Me.ElementsCache_Saved.Copy()

        ''
        ''Major call!!  
        ''
        ''9/17/2019 td''LoadForm_LayoutElements()
        ''9/20/2019 td''LoadForm_LayoutElements(Me.ElementsCache_Edits)
        LoadForm_LayoutElements(Me.ElementsCache_Edits, mod_listOfFieldControls)

        ''Added 9/24/2019 thomas 
        ''9/29/2019 td''serial_tools.PathToXML = (System.IO.Path.GetRandomFileName() & ".xml")
        ''10/1/2019 td''serial_tools.PathToXML = (My.Application.Info.DirectoryPath & "\Serialization_" & DateTime.Today.ToString("mmm_dd") & ".xml")
        ''10/1/2019 td''serial_tools.SerializeToXML(Me.ElementsCache_Saved.PicElement().GetType,
        ''10/1/2019 td''                            Me.ElementsCache_Saved.PicElement,
        ''10/1/2019 td''                            False, False)

        ''Added 9/28/2019 thomas 
        ''serial_tools.PathToXML = (System.IO.Path.GetRandomFileName() & ".xml")
        ''serial_tools.SerializeToXML(Me.ElementsCache_Saved.ListFields(0).GetType,
        ''                            Me.ElementsCache_Saved.ListFields(0), False, True)
        ''serial_tools.PathToXML = (System.IO.Path.GetRandomFileName() & ".xml")
        ''serial_tools.SerializeToXML(Me.ElementsCache_Saved.ListFieldElements(0).GetType,
        ''                            Me.ElementsCache_Saved.ListFieldElements(0), False, True)

        ''Added 8/11/2019 thomas d.
        ''
        ''10/1/2019 td''graphicAdjuster.SendToBack()

        ''10/1/2019 td''Me.PreviewBox.SendToBack()
        ''10/1/2019 td''Me.BackgroundBox.SendToBack()
        Me.PreviewBox.SendToBack()
        Me.BackgroundBox.SendToBack()

        ResizeLayoutBackgroundImage_ToFitPictureBox() ''Added 8/25/2019 td
        RefreshPreview() ''Added 8/24/2019 td

        Const c_boolBreakpoint As Boolean = True  ''Added 9//13/2019 td

        ''Badge Preview is also moveable/sizeable, mostly to impress
        ''    management.  ----9/8/2019 td
        ''
        ControlMoverOrResizer_TD.Init(Me.PreviewBox, Me.PreviewBox, 10, False,
                          c_boolBreakpoint) ''Added 9/08/2019 thomas downes

        ''If it won't conflict with the Rubber-Band Selector, 
        ''    then let's make the Badge Layout Background 
        ''    also moveable / sizeable.
        ''    ----9/8/2019 td
        ''
        Const c_LayoutBackIsMoveable As Boolean = False ''Added 9/8/2019 td 
        If (c_LayoutBackIsMoveable) Then
            ''Badge Layout Background is also moveable/sizeable.
            ControlMoverOrResizer_TD.Init(Me.BackgroundBox,
                          Me.PreviewBox, 10, False,
                          c_boolBreakpoint) ''Added 9/08/2019 thomas downes
        End If ''End of "If (c_LayoutBackIsMoveable) Then"

        ''Moved from above, 9/20/2019 td 
        Initiate_RubberbandSelector(mod_listOfFieldControls,
                                     mod_selectedCtls) ''Added 9/8/2019 thomas d. 

    End Sub ''End of "Private Sub FormDesignProtoTwo_Load"

    Private Sub ResizeLayoutBackgroundImage_ToFitPictureBox()
        ''
        ''Added 8/25/2019 td 
        ''
        Dim obj_image As Image ''Added 8/24 td
        ''Dim obj_image_clone As Image ''Added 8/24 td
        Dim obj_image_clone_resized As Image ''Added 8/24/2019 td

        ''Added 8/24/2019 td
        obj_image = Me.BackgroundBox.Image

        ''obj_image_clone = CType(obj_image.Clone(), Image)

        ''Dim gr_resize As Graphics = New Bitmap(obj_image_clone)

        ''8/25/2019 td''obj_image_clone_resized = ciLayoutPrintLib.LayoutPrint.ResizeImage_ToHeight(obj_image,
        ''                       Me.BackgroundBox.Height)

        ''8/26/2019 td''obj_image_clone_resized = ciLayoutPrintLib.LayoutPrint.ResizeImage_ToWidth(obj_image,
        ''8/26/2019 td''       Me.BackgroundBox.Width)

        obj_image_clone_resized = LayoutPrint.ResizeBackground_ToFitBox(obj_image, Me.BackgroundBox, True)

        Me.BackgroundBox.Image = obj_image_clone_resized

    End Sub ''End of Sub ResizeLayoutBackgroundImage_ToFitPictureBox()

    Private Sub LoadForm_LayoutElements(par_cache As ClassElementsCache,
                                        ByRef par_listFieldCtls As List(Of CtlGraphicFldLabel))
        ''9/20/2019 td''Private Sub LoadForm_LayoutElements(par_cache As ClassElementsCache)
        ''
        ''Added 9/17/2019 td
        ''
        Const c_boolLoadingForm As Boolean = True ''Added 8/28/2019 thomas downes 
        Dim boolMakeMoveableByUser As Boolean ''Added 9/20/2019 td 
        Const c_boolMakeMoveableASAP As Boolean = False ''added 9/20/2019 td

        ''#1 9/17/2019 td''LoadElements_Fields_Master(c_boolLoadingForm, par_cache.FieldElements())
        '' #2 9/17/2019 td''LoadElements_ByListOfFields(ClassFields.ListAllFields())
        ''9/20/2019 td''LoadFieldControls_ByListOfElements(par_cache.ListFieldElements(), c_boolLoadingForm)

        boolMakeMoveableByUser = c_boolMakeMoveableASAP ''Added 9/20/2019 td  

        LoadFieldControls_ByListOfElements(par_cache.ListFieldElements(),
                                           c_boolLoadingForm,
                                           False, boolMakeMoveableByUser,
                                           par_listFieldCtls)

        LoadElements_Picture(par_cache.PicElement())

        ''Add moveability.   
        boolMakeMoveableByUser = (Not c_boolMakeMoveableASAP) ''Added 9/20/2019 td
        If (boolMakeMoveableByUser) Then
            ''
            ''Pretty big call!!   Allow the user to "click & drag" the control. 
            ''
            MakeElementsMoveable()

        End If ''ENd of "If (boolMakeMoveableByUser) Then"

        ''
        ''Added 7/28/2019 td
        ''
        ''    Make sure that the Badge Background is in the background. 
        ''
        Me.BackgroundBox.SendToBack()
        ''10/1/2019 td''graphicAdjuster.SendToBack() ''Added 8/12/2019 td
        Me.PreviewBox.SendToBack() ''Added 8/12/2019 td

    End Sub ''ENd of "Private Sub LoadForm_LayoutElements()"

    Private Sub MakeElementsMoveable()
        ''
        ''Added 7/19/2019 thomas downes  
        ''
        Const c_addAfterMoveAddBreakpoint As Boolean = True

        ''8/4/2019 td''Dim boolAllowGroupMovements As Boolean = False ''True ''False ''Added 8/3/2019 td  
        ''
        ''Portrait
        ''
        If (mc_boolAllowGroupMovements) Then

            ControlMove_GroupMove_TD.Init(CtlGraphicPortrait_Lady.Picture_Box,
                      CtlGraphicPortrait_Lady, 10, True, mod_groupedMove,
                      c_addAfterMoveAddBreakpoint) ''Added 8/3/2019 thomas downes
        Else
            ControlMoverOrResizer_TD.Init(CtlGraphicPortrait_Lady.Picture_Box,
                  CtlGraphicPortrait_Lady, 10, True,
                   c_addAfterMoveAddBreakpoint) ''Added 7/31/2019 thomas downes

        End If ''End of " If (mc_boolAllowGroupMovements) Then .... Else ...."

        ''
        ''Fields
        ''
        Dim each_graphicLabel As CtlGraphicFldLabel ''Added 7/19/2019 thomas downes  

        For Each each_control As Control In Me.DesignerForm.Controls ''Added 7/19/2019 thomas downes  

            If (TypeOf each_control Is CtlGraphicFldLabel) Then

                each_graphicLabel = CType(each_control, CtlGraphicFldLabel)

                ''7/31/2019 td''ControlMoverOrResizer_TD.Init(each_graphicLabel.Picture_Box,
                ''                each_control, 10) ''Added 7/28/2019 thomas downes

                ControlMoverResizer_AddFieldCtl(each_graphicLabel)

            End If ''End of "If (TypeOf each_control Is GraphicFieldLabel) Then"

        Next each_control

    End Sub ''End of "Private Sub MakeElementsMoveable()"

    Private Sub ControlMoverResizer_AddFieldCtl(par_graphicFieldCtl As CtlGraphicFldLabel)
        ''
        ''Encapsulated 9/7/2019 thomas d
        ''
        Const c_bRepaintAfterResize As Boolean = True ''Added 7/31/2019 td 

        If (mc_boolAllowGroupMovements) Then
            ControlMove_GroupMove_TD.Init(par_graphicFieldCtl.Picture_Box,
                          par_graphicFieldCtl, 10, c_bRepaintAfterResize,
                          mod_groupedMove, mc_boolAllowGroupMovements) ''Added 8/3/2019 td 
        Else
            ControlMoverOrResizer_TD.Init(par_graphicFieldCtl.Picture_Box,
                          par_graphicFieldCtl, 10,
                          c_bRepaintAfterResize, mc_boolBreakpoints) ''Added 7/28/2019 thomas downes
        End If ''End of "If (boolAllowGroupMovements) Then ...... Else ..."

    End Sub ''End of "Private Sub ControlMoverResizer_AddField"

    Private Sub LoadElements_Picture(par_elementPic As ClassElementPic)
        ''
        ''Added 7/31/2019 thomas downes
        ''Parameter par_elementPic added 9/17/2019 td
        ''
        ''7/31 td''Dim new_picControl As CtlGraphicPortrait ''Added 7/31/2019 td  

        ''Added 8/22/2019 THOMAS D.
        ciPictures_VB.PictureExamples.PathToFolderOfImages = (My.Application.Info.DirectoryPath & "\Images\PictureExamples")

        CtlGraphicPortrait_Lady = New CtlGraphicPortrait(par_elementPic, Me)

        ''10/1/2019 td''Me.Controls.Add(CtlGraphicPortrait_Lady)
        Me.DesignerForm.Controls.Add(CtlGraphicPortrait_Lady)

        With CtlGraphicPortrait_Lady

            ''9/17/2019 td''.Top = ClassElementPic.ElementPicture.TopEdge_Pixels
            ''9/17/2019 td''.Left = ClassElementPic.ElementPicture.LeftEdge_Pixels
            ''9/17/2019 td''.Width = ClassElementPic.ElementPicture.Width_Pixels
            ''9/17/2019 td''.Height = ClassElementPic.ElementPicture.Height_Pixels

            .Top = par_elementPic.TopEdge_Pixels
            .Left = par_elementPic.LeftEdge_Pixels
            .Width = par_elementPic.Width_Pixels
            .Height = par_elementPic.Height_Pixels

            ''Added 8/18/2019 td
            .picturePortrait.Image = mod_imageLady

            ''Added 9/17/2019 td
            .Refresh_Master

        End With ''End of "With CtlGraphicPortrait1"

    End Sub ''End of " Private Sub LoadElements_Picture()"

    Private Sub Initiate_RubberbandSelector(par_elementControls_All As List(Of CtlGraphicFldLabel),
                                            par_elementControls_GroupEdit As List(Of CtlGraphicFldLabel))
        ''9/20 td''Private Sub Initiate_RubberbandSelector() 
        ''
        ''Added 9/8/2019 td
        ''
        mod_rubberbandClass = New ClassRubberbandSelector

        With mod_rubberbandClass

            ''10/1/2019 td''.Me.BackgroundBox = Me.Me.BackgroundBox
            .PictureBack = Me.BackgroundBox

            ''Added 9/20/2019 td  
            .FieldControls_All = par_elementControls_All

            ''Added 9/20/2019 td
            .LayoutFunctions = CType(Me, ILayoutFunctions)

            .FieldControls_GroupEdit = par_elementControls_GroupEdit

            ''AddHandler , AddressOf mod_rubberbandClass.MouseMove
            ''AddHandler .Me.BackgroundBox.MouseMove, AddressOf mod_rubberbandClass.MouseMove
            ''AddHandler .Me.BackgroundBox.MouseMove, AddressOf mod_rubberbandClass.MouseMove
            ''AddHandler .Me.BackgroundBox.MouseMove, AddressOf mod_rubberbandClass.MouseMove

        End With ''end of "With mod_rubberbandClass"

    End Sub ''End of "Private Sub InitiateRubberbandSelector"

    Private Sub LoadFieldControls_ByListOfElements(par_listElements As List(Of ClassElementField),
                               par_boolLoadingForm As Boolean,
                               Optional par_bUnloading As Boolean = False,
                               Optional par_bAddMoveability As Boolean = False,
                                Optional ByRef par_listFieldCtls As List(Of CtlGraphicFldLabel) = Nothing)
        ''
        ''Added 9/17/2019 thomas downes 
        ''
        Dim intCountControlsAdded As Integer = 0 ''Added 9/03/2019 td 
        Dim boolIncludeOnBadge As Boolean = False ''Added 9/03/2019 td
        Dim intStagger As Integer = 0 ''Added 9.6.2019 td 

        ''9/17/2019 td''For Each each_field As ICIBFieldStandardOrCustom In par_list  
        For Each each_element As ClassElementField In par_listElements

            Dim label_control As CtlGraphicFldLabel

            ''Added 9/3/2019 thomas d. 
            ''9/17/2019 td''boolIncludeOnBadge = (par_boolLoadingForm And each_element.IsDisplayedOnBadge)
            boolIncludeOnBadge = (par_boolLoadingForm And each_element.FieldInfo.IsDisplayedOnBadge)

            If (Not boolIncludeOnBadge) Then
                ''#1 9/17/2019 td''AddToFlowPanelOfOmittedFlds(each_element)
                '' #2 9/17/2019 td''AddToFlowPanelOfOmittedFlds(each_element.FieldInfo)
                AddToFlowPanelOfOmittedFlds(each_element)
                Continue For
            End If ''End of "If (Not boolIncludeOnBadge) Then"

            ''
            ''Added 9/15/2019 td
            ''
            With each_element
                .Height_Pixels = 30

                ''9/6/2019 td''new_element_text.TopEdge_Pixels = (30 + (30 * intCountControlsAdded))
                intStagger = intCountControlsAdded
                .TopEdge_Pixels = (intStagger * .Height_Pixels)
                intCountControlsAdded += 1 ''Added 9/6/2019 td 

                .LeftEdge_Pixels = .TopEdge_Pixels ''Left = Top !! By setting Left = Top, we will create 
                ''   a nice diagonally-cascading effect. ---9/3/2019 td

                ''Added 9/12/2019 td
                .BadgeLayout = New ciBadgeInterfaces.BadgeLayoutClass(Me.BackgroundBox.Width, Me.BackgroundBox.Height)

            End With

            ''Added 9/15/2019 td
            With each_element
                .FontFamilyName = "Times New Roman" ''Added 9/15/2019 thomas d. 
                .FontSize_Pixels = 25
                ''Added 9/12/2019 td 
                ''9/12/2019 td''.FontSize_IsLocked = True 
                .FontSize_ScaleToElementRatio = (.FontSize_Pixels / .Height_Pixels)
                .FontSize_ScaleToElementYesNo = True

            End With 'End of "With each_element"

            ''Added 9/5/2019 thomas d.
            ''9/11/2019 td''each_field.ElementInfo_Base.LayoutWidth_Pixels = Me.Layout_Width_Pixels()
            each_element.BadgeLayout.Width_Pixels = Me.Layout_Width_Pixels()
            each_element.BadgeLayout.Height_Pixels = Me.Layout_Height_Pixels

            ''#1 9/4/2019 td''label_control = New CtlGraphicFldLabel(each_field, Me)
            '' #2 9/4/2019 td''label_control = New CtlGraphicFldLabel(each_field, new_element_text, Me)
            label_control = New CtlGraphicFldLabel(each_element, Me)

            ''Moved below. 9/5 td''label_control.Refresh_Master()
            label_control.Visible = each_element.FieldInfo.IsDisplayedOnBadge ''BL = Badge Layout
            intCountControlsAdded += 1
            label_control.Name = "FieldControl" & CStr(intCountControlsAdded)

            ''Added 10/1/2019 td
            ''   Pass on the event of right-clicking a element-field control. 
            AddHandler label_control.ElementField_RightClicked, AddressOf ElementField_Clicked

            ''9/8 td''label_control.BorderStyle = BorderStyle.FixedSingle

            ''Added 9/6/2019 thomas downes 
            ''
            ''   Stagger the elements on the badge layout, in a cascade from
            '' the upper-left to the lower-right. 
            '' ------9/6/2019 td
            ''
            If (0 = each_element.TopEdge_Pixels) Then
                ''Added 9/6/2019 thomas downes 
                label_control.Width = CInt(Me.BackgroundBox.Width / 3)
                With each_element
                    .Width_Pixels = label_control.Width
                    .Height_Pixels = label_control.Height
                    intStagger = intCountControlsAdded
                    .TopEdge_Pixels = (intStagger * .Height_Pixels)
                    .LeftEdge_Pixels = .TopEdge_Pixels ''Left = Top !! By setting Left = Top, we will create 
                    ''   a nice diagonally-cascading effect. ---9/3/2019 td
                    ''See above. 9/6/2019 td''intCountControlsAdded += 1 ''Added 9/6/2019 td 
                End With ''End of " With each_field.ElementInfo_Base"
            End If ''ENd of "If (0 = each_field.ElementInfo_Base.TopEdge_Pixels) Then"

            boolIncludeOnBadge = (par_boolLoadingForm And each_element.FieldInfo.IsDisplayedOnBadge)

            If (boolIncludeOnBadge) Then

                Me.DesignerForm.Controls.Add(label_control)
                par_listFieldCtls.Add(label_control) ''Added 9/20/2019 td

                label_control.Visible = True
                label_control.BringToFront() ''Added 9/7/2019 thomas d.  
                ''9/5/2019''label_control.Refresh_Image(True)
                label_control.GroupEdits = CType(Me, ISelectingElements) ''Added 8/1 td

                ''Added 9/7/2019 td
                label_control.Left = Me.Layout_Margin_Left_Add(each_element.LeftEdge_Pixels)
                label_control.Top = Me.Layout_Margin_Top_Add(each_element.TopEdge_Pixels)

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

        Next each_element

        ''
        ''Added 8/27/2019 thomas downes
        ''
        Me.BackgroundBox.SendToBack() ''Added 9/7/2019 thomas d.

        ''10/1/2019 td''Me.Refresh() ''Added 8/28/2019 td   
        Me.DesignerForm.Refresh() ''Added 8/28/2019 td   

        ''9/5/2019 td''MessageBox.Show($"Number of field controls now on the form: {intCountControlsAdded}", "",
        ''     MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub ''End of ''Private Sub LoadElements_ByListOfElements()''

    Private Sub LoadFieldControl_JustOne(par_elementField As ClassElementField)
        ''
        ''Added 9/17/2019 thomas d.  
        ''
        Dim new_list As New List(Of ClassElementField)
        Const c_bAddToMoveableClass As Boolean = True ''Added 9/8/2019 td 

        new_list.Add(par_elementField)

        ''9/24/2019 td''LoadFieldControls_ByListOfElements(new_list, True, False, c_bAddToMoveableClass)
        LoadFieldControls_ByListOfElements(new_list, True, False, c_bAddToMoveableClass, mod_listOfFieldControls)

    End Sub ''End of "Private Sub LoadFieldControl_JustOne(par_elementField As ClassElementField)"

    ''9/17/2019 td''Private Sub AddToFlowPanelOfOmittedFlds(par_field As ICIBFieldStandardOrCustom)
    ''    ''
    ''    ''Added 9/6/2019 td
    ''    ''
    ''    Dim new_linkLabel As New LinkLabel
    ''    new_linkLabel.Tag = par_field
    ''    new_linkLabel.Text = par_field.FieldLabelCaption
    ''    flowFieldsNotListed.Controls.Add(new_linkLabel)
    ''    new_linkLabel.Visible = True

    ''    ''Added 9/7/2019 thomas downes
    ''    AddHandler new_linkLabel.LinkClicked, AddressOf AddField_LinkClicked

    ''End Sub ''End of "Private Sub AddToFlowPanelOfOmittedFlds(par_field As ICIBFieldStandardOrCustom)"

    Private Sub AddToFlowPanelOfOmittedFlds(par_elementField As ClassElementField)
        ''
        ''Added 9/17/2019 td
        ''
        Dim new_linkLabel As New LinkLabel
        new_linkLabel.Tag = par_elementField
        new_linkLabel.Text = par_elementField.FieldInfo.FieldLabelCaption
        flowFieldsNotListed.Controls.Add(new_linkLabel)
        new_linkLabel.Visible = True
        AddHandler new_linkLabel.LinkClicked, AddressOf AddField_LinkClicked

    End Sub ''End of "Private Sub AddToFlowPanelOfOmittedFlds(par_elementField As ClassElementField)"

    Private Sub AddField_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) ''9/7/2019 td''Handles linkSaveAndRefresh.LinkClicked
        ''
        ''Added 9/7/2019 thomas d
        ''
        ''9/17/2019 td''Dim field_to_add As ICIBFieldStandardOrCustom
        ''9/17/2019 td''field_to_add = CType(CType(sender, LinkLabel).Tag, ICIBFieldStandardOrCustom)
        ''9/17/2019 td''If (field_to_add Is Nothing) Then Exit Sub
        ''9/17/2019 td''field_to_add.IsDisplayedOnBadge = True
        ''9/17/2019 td''LoadField_JustOne(field_to_add)

        Dim element_to_add As ClassElementField ''Added 9/17/2019 td
        element_to_add = CType(CType(sender, LinkLabel).Tag, ClassElementField)
        If (element_to_add Is Nothing) Then Exit Sub
        element_to_add.FieldInfo.IsDisplayedOnBadge = True
        LoadFieldControl_JustOne(element_to_add) ''Modified 9/17/2019 td

        FlowFieldsNotListed.Controls.Remove(CType(sender, LinkLabel))

    End Sub ''End of "Private Sub AddField_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)"

    Public Sub SaveLayout()
        ''
        ''Added 7/29/2019 td
        ''
        Dim each_graphicalLabel As CtlGraphicFldLabel
        Dim each_portraitLabel As CtlGraphicPortrait ''Added 7/31/2019 td

        ''
        ''Step #1 of 2. 
        ''
        For Each each_control As Control In Me.DesignerForm.Controls

            If (TypeOf each_control Is CtlGraphicFldLabel) Then

                each_graphicalLabel = CType(each_control, CtlGraphicFldLabel)

                each_graphicalLabel.SaveToModel()

            ElseIf (TypeOf each_control Is CtlGraphicPortrait) Then
                ''
                ''Added 7/31/2019 thomas downes  
                ''
                each_portraitLabel = CType(each_control, CtlGraphicPortrait)
                each_portraitLabel.SaveToModel()

            End If ''end of "If (TypeOf each_control Is GraphicFieldLabel) Then .... ElseIf ..."

        Next each_control

        ''
        ''
        ''Step #2 of 3.
        ''
        Me.ElementsCache_Saved = Me.ElementsCache_Edits.Copy()

        ''
        ''Step #3 of 3
        ''
        ''   Serialize !!!
        ''


    End Sub ''End of "PRivate Sub SaveLayout()"  

    Public Sub RefreshPreview()
        ''
        ''Added 8/24/2019 td
        ''
        ''8/24 td''Dim objPrintLib As New ciLayoutPrintLib.CILayoutBadge
        ''9/18 td''Dim objPrintLib As New ciLayoutPrintLib.LayoutPrint_Redux
        Dim objPrintLibElems As New ciLayoutPrintLib.LayoutElements

        ''Deprecated. 9/18/2019 td''Dim listOfElementText_Stdrd As List(Of IFieldInfo_ElementPositions)
        ''Deprecated. 9/18/2019 td''Dim listOfElementText_Custom As List(Of IFieldInfo_ElementPositions)

        Dim listOfTextImages As New List(Of Image) ''Added 8/26/2019 thomas downes 
        Dim listOfElementTextFields As List(Of ClassElementField)

        ''For Each field_standard As ClassFieldStandard In ClassFieldStandard.ListOfFields_Students

        ''objPrintLib.LoadImageWithFieldValues(Me.PreviewBox.Image,
        ''      ClassFieldStandard.ListOfFields_Students,
        ''      ClassFieldCustomized.ListOfFields_Students)

        ''9/4/2019 td''listOfElementText_Stdrd = ClassFieldStandard.ListOfElementsText_Stdrd()
        ''9/4/2019 td''listOfElementText_Custom = ClassFieldCustomized.ListOfElementsText_Custom()

        ''Deprecated. 9/18/2019 td''listOfElementText_Stdrd = ClassFieldStandard.ListOfElementsText_Stdrd(Me.Layout_Width_Pixels())
        ''Deprecated. 9/18/2019 td''listOfElementText_Custom = ClassFieldCustomized.ListOfElementsText_Custom(Me.Layout_Width_Pixels())

        listOfElementTextFields = Me.ElementsCache_Edits.ListFieldElements()

        ''8/24 td''Me.PreviewBox.SizeMode = PictureBoxSizeMode.Zoom
        ''8/24 td''Me.PreviewBox.Image = Me.BackgroundBox.Image
        ''8/24 td''Me.PreviewBox.Image = CType(Me.BackgroundBox.Image.Clone(), Image)

        Dim obj_image As Image ''Added 8/24 td
        Dim obj_image_clone As Image ''Added 8/24 td
        Dim obj_image_clone_resized As Image ''Added 8/24/2019 td

        ''Added 9/6/2019 td 
        ClassLabelToImage.ProportionsAreSlightlyOff(Me.BackgroundBox.Image, True, "Background Image")

        ''Added 8/24/2019 td
        obj_image = Me.BackgroundBox.Image
        obj_image_clone = CType(obj_image.Clone(), Image)

        ''Dim gr_resize As Graphics = New Bitmap(obj_image_clone)

        ''8/26/2019 td''obj_image_clone_resized = ciLayoutPrintLib.LayoutPrint.ResizeImage_ToHeight(obj_image_clone, True,
        ''8/26/2019 td''      Me.PreviewBox.Height)

        ''Added 8/26/2019 thomas downes
        obj_image_clone_resized =
            LayoutPrint.ResizeBackground_ToFitBox(obj_image, Me.PreviewBox, True)

        ''Added 9/6/2019 td 
        ClassLabelToImage.ProportionsAreSlightlyOff(obj_image_clone_resized, True, "Clone Resized #1")

        ''
        ''Major call !!
        ''
        ''9/18 td''objPrintLib.LoadImageWithFieldValues(obj_image_clone_resized,
        ''     listOfElementText_Stdrd,
        ''     listOfElementText_Custom,
        ''     listOfTextImages)
        ''9/19 td''objPrintLib.LoadImageWithFieldValues(obj_image_clone_resized,
        ''9/19 td''    listOfElementTextFields,
        ''9/19 td''    listOfTextImages)
        objPrintLibElems.LoadImageWithElements(obj_image_clone_resized,
                                             listOfElementTextFields,
                                             listOfTextImages)

        ''
        ''Major call, let's show the portrait !!  ---9/9/2019 td  
        ''
        objPrintLibElems.LoadImageWithPortrait(obj_image_clone_resized.Width,
                                          Me.Layout_Width_Pixels(),
                                          obj_image_clone_resized,
                                           CtlGraphicPortrait_Lady.ElementInfo_Base,
                                           CtlGraphicPortrait_Lady.ElementInfo_Pic,
                                          CtlGraphicPortrait_Lady.picturePortrait.Image)

        ''Added 9/8/2019 td
        ''Const c_bListEachElementImage As Boolean = False ''Added 9/8/2019 td
        ''Const c_bTestingReview As Boolean = False ''Added 9/8/2019 td

        ''If (c_bListEachElementImage And c_bTestingReview) Then ''Added 9/8/2019 td
        ''    ''Added 8/26/2019 thomas downes  
        ''    Dim frm_ToShow1 As New FormDisplayImageList1(listOfTextImages)
        ''    frm_ToShow1.Show()

        ''    ''Added 8/27/2019 thomas downes  
        ''    ''9/19 td''Dim frm_ToShow2 As New FormDisplayImageList2(ClassFieldStandard.ListOfFields_Students,
        ''    ''9/19 td''    ClassFieldCustomized.ListOfFields_Students)

        ''    Dim frm_ToShow2 As New FormDisplayImageList2(listOfElementTextFields)
        ''    frm_ToShow2.Show()

        ''End If ''End of "If (c_bHelpProgrammer And c_bTestingReview) Then"

        ''Added 9/6/2019 td 
        ClassLabelToImage.ProportionsAreSlightlyOff(Me.BackgroundBox.Image, True, "Clone Resized #1")

        ''8/26 td''Me.PreviewBox.Image = obj_image_clone_resized
        Me.PreviewBox.Image = obj_image_clone_resized
        Me.PreviewBox.Refresh()

    End Sub ''end of "Private Sub RefreshPreview()"

    ''
    ''  Simple Drawing Selection Shape (Or Rubberband Shape)       
    ''  https://www.dreamincode.net/forums/topic/59049-simple-drawing-selection-shape-or-rubberband-shape/
    ''
    ''9/8/2019 td''Private _bRubberBandingOn As Boolean = False '-- State to control if we are drawing the rubber banding object
    ''9/8/2019 td''Private _pClickStart As New Point '-- The place where the mouse button went 'down'.
    ''9/8/2019 td''Private _pClickStop As New Point '-- The place where the mouse button went 'up'.
    ''9/8/2019 td''Private _pNow As New Point '-- Holds the current mouse location to make the shape appear to follow the mouse cursor.

    Private Sub Layout_MouseDown(sender As Object, e As MouseEventArgs) Handles pictureBack.MouseDown ''----Me.MouseDown
        ''
        ''  Simple Drawing Selection Shape (Or Rubberband Shape)       
        ''  https://www.dreamincode.net/forums/topic/59049-simple-drawing-selection-shape-or-rubberband-shape/
        ''
        mod_rubberbandClass.MouseDown(sender, e)

    End Sub

    Private Sub Layout_MouseMove(sender As Object, e As MouseEventArgs) Handles pictureBack.MouseMove ''----Me.MouseMove
        ''
        ''  Simple Drawing Selection Shape (Or Rubberband Shape)       
        ''  https://www.dreamincode.net/forums/topic/59049-simple-drawing-selection-shape-or-rubberband-shape/
        ''
        If (mod_rubberbandClass IsNot Nothing) Then
            mod_rubberbandClass.MouseMove(sender, e)
        End If

    End Sub

    Private Sub Layout_MouseUp(sender As Object, e As MouseEventArgs) Handles pictureBack.MouseUp ''----Me.MouseUp
        ''
        ''  Simple Drawing Selection Shape (Or Rubberband Shape)       
        ''  https://www.dreamincode.net/forums/topic/59049-simple-drawing-selection-shape-or-rubberband-shape/
        ''
        mod_rubberbandClass.MouseUp(sender, e)

    End Sub

    Private Sub Layout_Paint(sender As Object, e As PaintEventArgs) Handles pictureBack.Paint ''----Me.Paint
        ''
        ''  Simple Drawing Selection Shape (Or Rubberband Shape)       
        ''  https://www.dreamincode.net/forums/topic/59049-simple-drawing-selection-shape-or-rubberband-shape/
        ''
        If (mod_rubberbandClass IsNot Nothing) Then
            mod_rubberbandClass.Paint(sender, e)
        End If ''End of "If (mod_rubberbandClass IsNot Nothing) Then"

    End Sub

    ''-----------------------------------------------------------------------
    ''-----------------------------------------------------------------------
    ''-----------------------------------------------------------------------
    ''-----------------------------------------------------------------------
    ''
    ''Copied from FormPartial_Two.vb  
    ''
    ''-----------------------------------------------------------------------
    ''-----------------------------------------------------------------------
    ''-----------------------------------------------------------------------
    ''-----------------------------------------------------------------------

    Private mod_selectedCtls As New List(Of CtlGraphicFldLabel)   ''Added 8/03/2019 thomas downes 
    Private mod_FieldControlLastTouched As CtlGraphicFldLabel   ''Added 8/09/2019 thomas downes 
    Private mod_ControlLastTouched As Control ''Added 8/12/2019 thomas d. 
    Private mod_ElementLastTouched As Control ''Let's change this to IElement_Base soon. ---Added 9/14/2019 td 
    Private Const mc_bAddBorderOnlyWhileResizing As Boolean = True ''Added 9/11/2019 thomas d. 

    Public Property ControlBeingMoved() As Control Implements ILayoutFunctions.ControlBeingMoved ''Added 8/4/2019 td
        Get
            ''Added 8/9/2019 td
            Return mod_FieldControlLastTouched
        End Get
        Set(value As Control)
            ''Added 8/9/2019 td
            Try
                ''9/9/2019 td''mod_FieldControlLastTouched = value
                mod_FieldControlLastTouched = CType(value, CtlGraphicFldLabel)
                mod_ElementLastTouched = CType(value, Control) ''Added 9/14 
                mod_ControlLastTouched = value ''Added 8/1/2019 
            Catch
                ''Added 8/12/2019 td  
                mod_ControlLastTouched = value
                mod_ElementLastTouched = CType(value, Control)
            End Try
        End Set
    End Property ''End of "Public Property ControlBeingMoved() As Control Implements ILayoutFunctions.ControlBeingMoved"

    Public Property ControlBeingModified() As Control Implements ILayoutFunctions.ControlBeingModified ''Added 8/9/2019 td
        Get
            ''
            ''Added 8/9/2019 td
            ''
            ''8/12/2019 td''Return mod_FieldControlLastTouched
            Return mod_ControlLastTouched ''Added 8/12/2019 td  
        End Get
        Set(value As Control)
            ''Added 8/9/2019 td
            mod_ControlLastTouched = value ''Added 8/12/2019 td
            mod_ElementLastTouched = value ''Added 9/14/2019 td
            Try
                ''9/9/2019 td''mod_FieldControlLastTouched = value
                mod_FieldControlLastTouched = CType(value, CtlGraphicFldLabel)

                ''Added 9/11/2019 td  
                If (mc_bAddBorderOnlyWhileResizing) Then
                    mod_FieldControlLastTouched.BorderStyle = BorderStyle.FixedSingle
                End If ''End of "If (mc_bAddBorderOnlyWhileResizing) Then"

            Catch
                ''Not all moveable controls are Field-Label controls. - ----8/12/2019 thomas d.  
            End Try
        End Set
    End Property ''End of "Public Property ControlBeingModified() As Control Implements ILayoutFunctions.ControlBeingModified"

    Public Property LabelsDesignList_AllItems As List(Of CtlGraphicFldLabel) Implements ISelectingElements.LabelsDesignList_AllItems
        Get
            ''Added 8/3/2019 thomas downes
            Return mod_selectedCtls
        End Get
        Set
            ''Added 8/3/2019 thomas downes
            mod_selectedCtls = Value
        End Set
    End Property

    Public Sub LabelsDesignList_Add(par_control As CtlGraphicFldLabel) Implements ISelectingElements.LabelsDesignList_Add
        ''
        ''Added 8/3/2019 thomas downes
        ''
        mod_selectedCtls.Add(par_control)

    End Sub

    Public Sub LabelsDesignList_Remove(par_control As CtlGraphicFldLabel) Implements ISelectingElements.LabelsDesignList_Remove
        ''
        ''Added 8/3/2019 thomas downes
        ''
        mod_selectedCtls.Remove(par_control)

    End Sub

    Private Sub Resizing_Start() Handles mod_groupedMove.Resizing_Start
        ''
        ''Added 8/5/2019 thomas downes  
        ''
        For Each each_control As CtlGraphicFldLabel In mod_selectedCtls

            ''Added 9/11/2019 td  
            If (mc_bAddBorderOnlyWhileResizing) Then
                each_control.BorderStyle = BorderStyle.FixedSingle
            End If ''End of "If (mc_boolAddBorderWhileResizing) Then"

            ''Added 8/5/2019 thomas downes  
            each_control.TempResizeInfo_W = each_control.Width
            each_control.TempResizeInfo_H = each_control.Height

            ''Added 8/12/2019 thomas downes  
            ''   The user might want might to resize using the left edge (or the top edge). 
            ''
            each_control.TempResizeInfo_Left = each_control.Left
            each_control.TempResizeInfo_Top = each_control.Top

        Next each_control

    End Sub ''End of "Private Sub Resizing_Start"  

    Private Sub Move_GroupMove_Continue(DeltaLeft As Integer, DeltaTop As Integer, DeltaWidth As Integer, DeltaHeight As Integer) Handles mod_groupedMove.MoveInUnison
        ''
        ''Added 8/3/2019 thomas downes  
        ''
        Dim boolMoving As Boolean ''Added 8/5/2/019 td  
        Dim boolResizing As Boolean ''Added 8/5/2/019 td  
        Dim bResize_RightOrBottom As Boolean ''Added 8/12/019 td  
        Dim bResize_LeftOrTop As Boolean ''Added 8/12/019 td  
        Dim bControlMovedIsInGroup As Boolean ''Added 8/5/2019 td  

        ''
        ''8/5/2019 thomas downes
        ''
        If (TypeOf ControlBeingMoved Is CtlGraphicFldLabel) Then
            Const c_bCheckThatControlIsGrouped As Boolean = True ''8/5/2019 thomas downes
            If (c_bCheckThatControlIsGrouped) Then ''8/5/2019 thomas downes
                ''9/9 td''bControlMovedIsInGroup = LabelsList_IsItemIncluded(ControlBeingMoved)
                bControlMovedIsInGroup = LabelsList_IsItemIncluded(CType(ControlBeingMoved, CtlGraphicFldLabel))
                If (Not bControlMovedIsInGroup) Then Exit Sub
            End If ''End of "If (c_bCheckThatControlIsGrouped) Then"
        Else
            ''
            ''Perhaps the Portrait is being moved.   Don't allow other things to be 
            ''  moved around as well.  ---8/5/2019 td
            ''
            Exit Sub

        End If ''End of "If (TypeOf ControlBeingMoved Is CtlGraphicFldLabel) Then .... Else ...."

        ''
        ''The control being moved or resized is part of a group.   
        ''
        ''8/4/2019 td''For Each each_control As CtlGraphicFldLabel In mod_selectedCtls
        For Each each_control As CtlGraphicFldLabel In mod_selectedCtls

            ''Don't re-move the control being directly moved...!! 
            ''  Causes ugly screen flicker!!
            ''     --8/4/2019 td
            If (each_control Is Me.ControlBeingMoved) Then Continue For
            If (each_control Is Me.ControlBeingMoved.Parent) Then Continue For

            With each_control

                ''Added 8/3/2019 th omas downes  
                ''8/12/2019 td''boolMoving = (DeltaTop <> 0 Or DeltaLeft <> 0)
                boolMoving = ((DeltaTop <> 0 And DeltaHeight = 0) Or
                              (DeltaLeft <> 0 And DeltaWidth = 0))

                If (boolMoving) Then
                    .Top += DeltaTop
                    .Left += DeltaLeft
                End If ''End if ''End of "If (boolMoving) Then"

                ''8/5/2019 TD''.Width += DeltaWidth
                ''8/5/2019 TD''.Height += DeltaHeight

                ''Modified 8/5/2019 thomas downes
                boolResizing = ((Not boolMoving) And (.TempResizeInfo_W > 0 And .TempResizeInfo_H > 0))

                If (boolResizing) Then
                    ''
                    ''Added 8/12/2019 thomas d. 
                    ''
                    bResize_LeftOrTop = (DeltaLeft <> 0 Or DeltaTop <> 0) ''-----DIFFICULT AND CONFUSING !!!!!    The user might want might to resize 
                    ''    using the left edge (Or the top edge).  ----8/12/2019 td
                    bResize_RightOrBottom = ((Not bResize_LeftOrTop) And (DeltaWidth <> 0 Or DeltaHeight <> 0))

                    If (bResize_RightOrBottom) Then
                        ''
                        ''This is the simpler situation !! 
                        ''
                        .Width = (.TempResizeInfo_W + DeltaWidth)
                        .Height = (.TempResizeInfo_H + DeltaHeight)

                    ElseIf (bResize_LeftOrTop) Then
                        ''
                        ''Added 8/12/2019 thomas d.
                        ''
                        ''-----DIFFICULT AND CONFUSING !!!!!
                        ''    The user might want might to resize using the left edge (Or the top edge). 
                        ''
                        ''8/12/2019 TD''.Top = (.TempResizeInfo_Top + DeltaTop)
                        ''8/12/2019 TD''.Left = (.TempResizeInfo_Left + DeltaLeft)

                        .Top += DeltaTop
                        .Left += DeltaLeft
                        .Width += DeltaWidth
                        .Height += DeltaHeight

                    End If ''End of "If (bResize_RightOrBottom) Then .... ElseIf (bResize_LeftOrTop) Then ..."

                End If ''End of "If (boolResizing) Then"

                ''8/5/2019 td''txtWidthDeltas.AppendText($"Width: {DeltaWidth}" & vbCrLf)
                ''8/5/2019 td''txtWidthDeltas.AppendText($"   Height: {DeltaHeight}" & vbCrLf)

            End With ''End of "With each_control"

        Next each_control

    End Sub ''End of "Private Sub MoveInUnison"

    Private Sub Resizing_End() Handles mod_groupedMove.Resizing_End
        ''
        ''Added 8/5/2019 thomas downes  
        ''

        For Each each_control As CtlGraphicFldLabel In mod_selectedCtls

            ''Added 9/11/2019 td  
            If (mc_bAddBorderOnlyWhileResizing) Then
                each_control.BorderStyle = BorderStyle.None
            End If ''End of "If (mc_boolAddBorderWhileResizing) Then"

            each_control.TempResizeInfo_W = 0
            each_control.TempResizeInfo_H = 0

            ''Added 9/11/2019 td
            each_control.Refresh_Image(True)

        Next each_control

        ''Added 9/11/2019 Never Forget
        ''   This is needed in case it's not a group of controls being resized, 
        ''   but just a single control. ---9/11 td 
        ''
        ''9/14/2019 td''If (mod_ElementLastTouched = mod_FieldControlLastTouched) Then

        Dim boolResizedAFieldCtl As Boolean ''Added 9/14/2019 td
        boolResizedAFieldCtl = (TypeOf mod_ControlLastTouched Is CtlGraphicFldLabel)

        If (boolResizedAFieldCtl) Then ''Added 9/14/2019 td

            With mod_FieldControlLastTouched

                If (.Rotated_0degrees) Then
                    .ElementInfo_Base.Width_Pixels = mod_FieldControlLastTouched.Width
                    .ElementInfo_Base.Height_Pixels = mod_FieldControlLastTouched.Height
                ElseIf (.Rotated_180_360) Then
                    .ElementInfo_Base.Width_Pixels = mod_FieldControlLastTouched.Width
                    .ElementInfo_Base.Height_Pixels = mod_FieldControlLastTouched.Height
                ElseIf (.Rotated_90_270) Then
                    ''
                    ''---- POTENTIALLY CONFUSING -----
                    ''Switch them up !!  
                    .ElementInfo_Base.Width_Pixels = mod_FieldControlLastTouched.Height
                    .ElementInfo_Base.Height_Pixels = mod_FieldControlLastTouched.Width
                End If ''End of "If (.Rotated_180_360) Then"

                ''Added 9/12/2019 td  
                With .ElementInfo_Text
                    If .FontSize_ScaleToElementYesNo Then
                        ''Change the Font Size, to account for the new Height of the Element !!
                        ''  ---9/12/2019 td 
                        .FontSize_Pixels = CSng(mod_FieldControlLastTouched.Height * .FontSize_ScaleToElementRatio)
                    End If ''End of "If .FontSize_ScaleToElementYesNo Then"
                End With ''End of "With .ElementInfo_Text"

                .Refresh_Image(True)

            End With ''End of "With mod_FieldControlLastTouched"

        End If ''End of "If (mod_ElementLastTouched = mod_FieldControlLastTouched) Then"

        ''Added 9/13/2019 td 
        AutoPreview_IfChecked()

    End Sub ''End of "Private Sub Resizing_End() Handles mod_groupedMove.Resizing_End"

    Private Sub MovingElement_End() Handles mod_groupedMove.Moving_End

        ''Added 9/13/2019 td 
        AutoPreview_IfChecked()

    End Sub

    Private Sub SwitchControls_Down(par_ctl As CtlGraphicFldLabel) Implements ISelectingElements.SwitchControls_Down
        ''
        ''Added 8/15/2019 thomas downes  
        ''
        If (GetNextLowerControl(par_ctl) Is Nothing) Then Exit Sub ''Added 8/16/2019 td 

        SwitchWithOtherCtl(par_ctl, GetNextLowerControl(par_ctl))

    End Sub ''End of "Private Sub SwitchControls_Down(par_ctl As CtlGraphicFldLabel)"

    Private Sub SwitchControls___Up(par_ctl As CtlGraphicFldLabel) Implements ISelectingElements.SwitchControls___Up
        ''
        ''Added 8/15/2019 thomas downes  
        ''
        If (GetNextHigherControl(par_ctl) Is Nothing) Then Exit Sub ''Added 8/16/2019 td 

        SwitchWithOtherCtl(par_ctl, GetNextHigherControl(par_ctl))

    End Sub ''End of "Private Sub SwitchWithNextHigher(par_ctl As CtlGraphicFldLabel)"

    Private Sub SwitchWithOtherCtl(par_one As CtlGraphicFldLabel, par_two As CtlGraphicFldLabel)
        ''
        ''Added 8/15/2019 thomas downes  
        ''
        Dim intTemp_Left, intTemp_Top As Integer

        intTemp_Left = par_one.Left
        intTemp_Top = par_one.Top

        par_one.Left = par_two.Left
        par_one.Top = par_two.Top

        par_two.Left = intTemp_Left
        par_two.Top = intTemp_Top

    End Sub ''End of "Private Sub SwitchWithOtherCtl(par_one As CtlGraphicFldLabel, par_two As .....)"

    Private Function HasAtLeastOne_Down(par_ctl As CtlGraphicFldLabel) As Boolean Implements ISelectingElements.HasAtLeastOne_Down
        ''Added 8/15/2019 thomas downes  
        Return (GetNextLowerControl(par_ctl) IsNot Nothing)
    End Function

    Private Function HasAtLeastOne____Up(par_ctl As CtlGraphicFldLabel) As Boolean Implements ISelectingElements.HasAtLeastOne__Up
        ''Added 8/15/2019 thomas downes  
        Return (GetNextHigherControl(par_ctl) IsNot Nothing)
    End Function

    Private Function GetNextLowerControl(par_ctl As CtlGraphicFldLabel) As CtlGraphicFldLabel
        ''
        ''Added 8/15/2019 thomas downes  
        ''
        ''---For Each each_control As CtlGraphicFldLabel In mod_selectedCtls
        ''---Next each_control
        Try
            Return mod_selectedCtls.Where(Function(ctl) ctl.Top > par_ctl.Top).OrderBy(Function(ctl) ctl.Top).First
        Catch ex_linq As Exception
            ''Apparently the command above fails is there are not any lower controls.  --8/16 td 
            Return Nothing
        End Try

    End Function ''End of "Private Function GetNextLowerControl"

    Private Function GetNextHigherControl(par_ctl As CtlGraphicFldLabel) As CtlGraphicFldLabel
        ''
        ''Added 8/15/2019 thomas downes  
        ''
        ''---For Each each_control As CtlGraphicFldLabel In mod_selectedCtls
        ''---Next each_control

        Try
            Return mod_selectedCtls.Where(Function(ctl) ctl.Top < par_ctl.Top).OrderByDescending(Function(ctl) ctl.Top).First
        Catch ex_linq As Exception
            ''Apparently the command above fails is there are not any higher controls.  --8/16 td 
            Return Nothing
        End Try

    End Function ''End of "Private Function GetNextHigherControl"

    Public Function LabelsList_CountItems() As Integer Implements ISelectingElements.LabelsList_CountItems

        ''Added 8/3/2019 td 
        Return mod_selectedCtls.Count

    End Function

    Public Function LabelsList_OneOrMoreItems() As Boolean Implements ISelectingElements.LabelsList_OneOrMoreItems

        ''Added 8/3/2019 td 
        Return (1 <= mod_selectedCtls.Count)

    End Function

    Public Function LabelsList_TwoOrMoreItems() As Boolean Implements ISelectingElements.LabelsList_TwoOrMoreItems

        ''Added 8/3/2019 td 
        Return (2 <= mod_selectedCtls.Count)

    End Function

    Public Function LabelsList_IsItemIncluded(par_control As CtlGraphicFldLabel) As Boolean Implements ISelectingElements.LabelsList_IsItemIncluded

        ''Added 8/3/2019 td 
        Return (mod_selectedCtls.Contains(par_control))

    End Function


    Public Function LabelsList_IsItemUnselected(par_control As CtlGraphicFldLabel) As Boolean Implements ISelectingElements.LabelsList_IsItemUnselected

        ''Added 8/3/2019 td 
        Return (Not (mod_selectedCtls.Contains(par_control)))

    End Function

    Public Function Layout_Width_Pixels() As Integer Implements ILayoutFunctions.Layout_Width_Pixels
        ''Added 9/3/2019 thomas downes
        Return Me.BackgroundBox.Width
    End Function ''End of "Public Function Layout_Width_Pixels() As Integer"

    Public Function Layout_Height_Pixels() As Integer Implements ILayoutFunctions.Layout_Height_Pixels
        ''Added 9/11/2019 Never Forget 
        Return Me.BackgroundBox.Height
    End Function ''End of "Public Function Layout_Height_Pixels() As Integer"

    Public Function Layout_Margin_Left_Omit(par_intPixelsLeft As Integer) As Integer Implements ILayoutFunctions.Layout_Margin_Left_Omit
        ''Added 9/5/2019 thomas downes
        Return (par_intPixelsLeft - Me.BackgroundBox.Left)
    End Function ''End of "Public Function Layout_Margin_Left_Omit() As Integer"

    Public Function Layout_Margin_Left_Add(par_intPixelsLeft As Integer) As Integer Implements ILayoutFunctions.Layout_Margin_Left_Add
        ''Added 9/5/2019 thomas downes
        Return (par_intPixelsLeft + Me.BackgroundBox.Left)
    End Function ''End of "Public Function Layout_Margin_Left_Add() As Integer"

    Public Function Layout_Margin_Top_Omit(par_intPixelsTop As Integer) As Integer Implements ILayoutFunctions.Layout_Margin_Top_Omit
        ''Added 9/5/2019 thomas downes
        Return (par_intPixelsTop - Me.BackgroundBox.Top)
    End Function ''End of "Public Function Layout_Margin_Top_Omit() As Integer"

    Public Function Layout_Margin_Top_Add(par_intPixelsTop As Integer) As Integer Implements ILayoutFunctions.Layout_Margin_Top_Add
        ''Added 9/5/2019 thomas downes
        Return (par_intPixelsTop + Me.BackgroundBox.Top)
    End Function ''End of "Public Function Layout_Margin_Top_Add() As Integer"

    Public Function OkayToShowFauxContextMenu() As Boolean Implements ILayoutFunctions.OkayToShowFauxContextMenu
        ''
        ''Added 8/14/2019 td 
        ''
        ''OkayToShowFauxContextMenu()
        ''10/1/2019 td''Return DemoModeActiveToolStripMenuItem.Checked
        Return True

    End Function ''End of "Public Function OkayToShowFauxContextMenu() As Boolean"

    Public Sub AutoPreview_IfChecked() Implements ILayoutFunctions.AutoPreview_IfChecked
        ''
        ''Refresh the preview picture box. 
        ''
        If (CheckboxAutoPreview.Checked) Then
            SaveLayout()
            RefreshPreview()
        End If ''End of "If (checkAutoPreview.Checked) Then"

    End Sub ''End of  "Private Sub AutoPreview_IfChecked()"

    Public Function RightClickMenu_Parent() As ToolStripMenuItem Implements ILayoutFunctions.RightClickMenu_Parent

        ''Added 9/19/2019 td
        ''10/1/2019 td''Return RightClickMenuParent

        Throw New NotImplementedException("This class is not in charge of displaying context menus!!")

    End Function

    Public Function NameOfForm() As String Implements ILayoutFunctions.NameOfForm

        ''Added 9/19/2019
        ''10/1/2019 td''Return Me.Name
        Return Me.DesignerForm.Name

    End Function

    Public Sub RedrawForm() Implements ILayoutFunctions.RedrawForm
        ''Added 9/23/2019
        ''Not needed. ---9/23 td''Me.Invalidate() ''Causes the form to be re-painted.
        ''Not needed. ---9/23 td''Application.DoEvents()
    End Sub

    Private Sub ElementField_Clicked(par_control As CtlGraphicFldLabel)
        ''
        ''Added 10/1/2019 thomas d.
        ''
        RaiseEvent ElementRightClicked(par_control)

    End Sub

End Class ''End of "Public Class ClassDesigner"
