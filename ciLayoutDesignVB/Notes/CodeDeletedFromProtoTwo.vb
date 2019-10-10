'    ''Added 9/28/2019 thomas 
'    ''serial_tools.PathToXML = (System.IO.Path.GetRandomFileName() & ".xml")
'    ''serial_tools.SerializeToXML(Me.ElementsCache_Saved.ListFields(0).GetType,
'    ''                            Me.ElementsCache_Saved.ListFields(0), False, True)
'    ''serial_tools.PathToXML = (System.IO.Path.GetRandomFileName() & ".xml")
'    ''serial_tools.SerializeToXML(Me.ElementsCache_Saved.ListFieldElements(0).GetType,
'    ''                            Me.ElementsCache_Saved.ListFieldElements(0), False, True)

'    ''Added 8/11/2019 thomas d.
'    ''
'    graphicAdjuster.SendToBack()
'    picturePreview.SendToBack()
'    pictureBack.SendToBack()

'    ResizeLayoutBackgroundImage_ToFitPictureBox() ''Added 8/25/2019 td
'    RefreshPreview() ''Added 8/24/2019 td

'    Const c_boolBreakpoint As Boolean = True  ''Added 9//13/2019 td

'    ''Badge Preview is also moveable/sizeable, mostly to impress
'    ''    management.  ----9/8/2019 td
'    ''
'    ControlMoverOrResizer_TD.Init(picturePreview,
'                      picturePreview, 10, False,
'                      c_boolBreakpoint) ''Added 9/08/2019 thomas downes

'    ''If it won't conflict with the Rubber-Band Selector, 
'    ''    then let's make the Badge Layout Background 
'    ''    also moveable / sizeable.
'    ''    ----9/8/2019 td
'    ''
'    Const c_LayoutBackIsMoveable As Boolean = False ''Added 9/8/2019 td 
'    If (c_LayoutBackIsMoveable) Then
'        ''Badge Layout Background is also moveable/sizeable.
'        ControlMoverOrResizer_TD.Init(pictureBack,
'                      picturePreview, 10, False,
'                      c_boolBreakpoint) ''Added 9/08/2019 thomas downes
'    End If ''End of "If (c_LayoutBackIsMoveable) Then"

'    ''Moved from above, 9/20/2019 td 
'    Initiate_RubberbandSelector(mod_listOfFieldControls,
'                                 mod_selectedCtls) ''Added 9/8/2019 thomas d. 

'End Sub ''End of "Private Sub FormDesignProtoTwo_Load"

'Private Sub ResizeLayoutBackgroundImage_ToFitPictureBox()
'    ''
'    ''Added 8/25/2019 td 
'    ''
'    Dim obj_image As Image ''Added 8/24 td
'    ''Dim obj_image_clone As Image ''Added 8/24 td
'    Dim obj_image_clone_resized As Image ''Added 8/24/2019 td

'    ''Added 8/24/2019 td
'    obj_image = pictureBack.Image

'    ''obj_image_clone = CType(obj_image.Clone(), Image)

'    ''Dim gr_resize As Graphics = New Bitmap(obj_image_clone)

'    ''8/25/2019 td''obj_image_clone_resized = ciLayoutPrintLib.LayoutPrint.ResizeImage_ToHeight(obj_image,
'    ''                       pictureBack.Height)

'    ''8/26/2019 td''obj_image_clone_resized = ciLayoutPrintLib.LayoutPrint.ResizeImage_ToWidth(obj_image,
'    ''8/26/2019 td''       pictureBack.Width)

'    obj_image_clone_resized = LayoutPrint.ResizeBackground_ToFitBox(obj_image, pictureBack, True)

'    pictureBack.Image = obj_image_clone_resized

'End Sub ''End of Sub ResizeLayoutBackgroundImage()

'Private Sub LoadForm_LayoutElements(par_cache As ClassElementsCache,
'                                    ByRef par_listFieldCtls As List(Of CtlGraphicFldLabel))
'    ''9/20/2019 td''Private Sub LoadForm_LayoutElements(par_cache As ClassElementsCache)
'    ''
'    ''Added 9/17/2019 td
'    ''
'    Const c_boolLoadingForm As Boolean = True ''Added 8/28/2019 thomas downes 
'    Dim boolMakeMoveableByUser As Boolean ''Added 9/20/2019 td 
'    Const c_boolMakeMoveableASAP As Boolean = False ''added 9/20/2019 td

'    ''#1 9/17/2019 td''LoadElements_Fields_Master(c_boolLoadingForm, par_cache.FieldElements())
'    '' #2 9/17/2019 td''LoadElements_ByListOfFields(ClassFields.ListAllFields())
'    ''9/20/2019 td''LoadFieldControls_ByListOfElements(par_cache.ListFieldElements(), c_boolLoadingForm)

'    boolMakeMoveableByUser = c_boolMakeMoveableASAP ''Added 9/20/2019 td  

'    LoadFieldControls_ByListOfElements(par_cache.ListFieldElements(),
'                                       c_boolLoadingForm,
'                                       False, boolMakeMoveableByUser,
'                                       par_listFieldCtls)

'    LoadElements_Picture(par_cache.PicElement())

'    ''Add moveability.   
'    boolMakeMoveableByUser = (Not c_boolMakeMoveableASAP) ''Added 9/20/2019 td
'    If (boolMakeMoveableByUser) Then
'        ''
'        ''Pretty big call!!   Allow the user to "click & drag" the control. 
'        ''
'        MakeElementsMoveable()

'    End If ''ENd of "If (boolMakeMoveableByUser) Then"

'    ''
'    ''Added 7/28/2019 td
'    ''    Make sure that the Badge Background is in the background. 
'    ''
'    pictureBack.SendToBack()
'    graphicAdjuster.SendToBack() ''Added 8/12/2019 td
'    picturePreview.SendToBack() ''Added 8/12/2019 td

'End Sub ''ENd of "Private Sub LoadForm_LayoutElements()"

''Private Sub LoadForm_LayoutElements()
''    ''Renamed 9/8/2019''PRivate Sub Load_Form()
''    ''
''    ''Encapsulated 7/31/2019 td
''    ''
''    ''7/31/2019 td''LoadElements()
''    ''8/28/2019 td''LoadElements_Fields()
''    Const c_boolLoadingForm As Boolean = True ''Added 8/28/2019 thomas downes  

''    ''9/3/2019 td''LoadElements_Fields(c_boolLoadingForm)
''    LoadElements_Fields_Master(c_boolLoadingForm)

''    ''Added 7/31/2019 td  
''    ''9/17/2019 td''LoadElements_Picture()
''    LoadElements_Picture(Me.ElementsCache_Edits.PicElement())

''    MakeElementsMoveable()

''    ''Added 7/28/2019 td
''    ''    Make sure that the Badge Background is in the background. 
''    ''
''    pictureBack.SendToBack()
''    graphicAdjuster.SendToBack() ''Added 8/12/2019 td
''    picturePreview.SendToBack() ''Added 8/12/2019 td

''End Sub ''ENd of "Private Sub LoadForm_LayoutElements()"

'Private Sub MakeElementsMoveable()
'    ''
'    ''Added 7/19/2019 thomas downes  
'    ''
'    Const c_addAfterMoveAddBreakpoint As Boolean = True

'    ''8/4/2019 td''Dim boolAllowGroupMovements As Boolean = False ''True ''False ''Added 8/3/2019 td  
'    ''
'    ''Portrait
'    ''
'    If (mc_boolAllowGroupMovements) Then

'        ControlMove_GroupMove_TD.Init(CtlGraphicPortrait_Lady.Picture_Box,
'                  CtlGraphicPortrait_Lady, 10, True, mod_groupedMove,
'                  c_addAfterMoveAddBreakpoint) ''Added 8/3/2019 thomas downes
'    Else
'        ControlMoverOrResizer_TD.Init(CtlGraphicPortrait_Lady.Picture_Box,
'              CtlGraphicPortrait_Lady, 10, True,
'               c_addAfterMoveAddBreakpoint) ''Added 7/31/2019 thomas downes

'    End If ''End of " If (mc_boolAllowGroupMovements) Then .... Else ...."

'    ''
'    ''Fields
'    ''
'    Dim each_graphicLabel As CtlGraphicFldLabel ''Added 7/19/2019 thomas downes  

'    For Each each_control As Control In Me.Controls ''Added 7/19/2019 thomas downes  

'        If (TypeOf each_control Is CtlGraphicFldLabel) Then

'            each_graphicLabel = CType(each_control, CtlGraphicFldLabel)

'            ''7/31/2019 td''ControlMoverOrResizer_TD.Init(each_graphicLabel.Picture_Box,
'            ''                each_control, 10) ''Added 7/28/2019 thomas downes

'            ControlMoverResizer_AddFieldCtl(each_graphicLabel)

'        End If ''End of "If (TypeOf each_control Is GraphicFieldLabel) Then"

'    Next each_control

'End Sub ''End of "Private Sub MakeElementsMoveable()"

'Private Sub ControlMoverResizer_AddFieldCtl(par_graphicFieldCtl As CtlGraphicFldLabel)
'    ''
'    ''Encapsulated 9/7/2019 thomas d
'    ''
'    Const c_bRepaintAfterResize As Boolean = True ''Added 7/31/2019 td 

'    If (mc_boolAllowGroupMovements) Then
'        ControlMove_GroupMove_TD.Init(par_graphicFieldCtl.Picture_Box,
'                      par_graphicFieldCtl, 10, c_bRepaintAfterResize,
'                      mod_groupedMove, mc_boolAllowGroupMovements) ''Added 8/3/2019 td 
'    Else
'        ControlMoverOrResizer_TD.Init(par_graphicFieldCtl.Picture_Box,
'                      par_graphicFieldCtl, 10,
'                      c_bRepaintAfterResize, mc_boolBreakpoints) ''Added 7/28/2019 thomas downes
'    End If ''End of "If (boolAllowGroupMovements) Then ...... Else ..."

'End Sub ''End of "Private Sub ControlMoverResizer_AddField"

'Private Sub LoadElements_Picture(par_elementPic As ClassElementPic)
'    ''
'    ''Added 7/31/2019 thomas downes
'    ''Parameter par_elementPic added 9/17/2019 td
'    ''
'    ''7/31 td''Dim new_picControl As CtlGraphicPortrait ''Added 7/31/2019 td  

'    ''Added 8/22/2019 THOMAS D.
'    ciPictures_VB.PictureExamples.PathToFolderOfImages = (My.Application.Info.DirectoryPath & "\Images\PictureExamples")

'    ''9/17/2019 td''If (ClassElementPic.ElementPicture Is Nothing) Then
'    ''
'    ''    ClassElementPic.ElementPicture = New ClassElementPic
'    ''
'    ''    With ClassElementPic.ElementPicture
'    ''
'    ''        .Width_Pixels = CtlGraphicPortrait_Lady.Width
'    ''        .Height_Pixels = CtlGraphicPortrait_Lady.Height
'    ''
'    ''        .TopEdge_Pixels = CtlGraphicPortrait_Lady.Top
'    ''        .LeftEdge_Pixels = CtlGraphicPortrait_Lady.Left
'    ''
'    ''        ''Added 8/12/2019 td
'    ''        Dim bSwitchWidthHeight As Boolean ''Added 8/12/2019 td
'    ''        bSwitchWidthHeight = ("L" = ClassElementPic.ElementPicture.OrientationToLayout)
'    ''
'    ''        ''Added 8/12/2019 td
'    ''        ''Switch width & height.  
'    ''        If (bSwitchWidthHeight) Then
'    ''            ''Switch width & height.  
'    ''            .Width_Pixels = CtlGraphicPortrait_Lady.Height
'    ''            .Height_Pixels = CtlGraphicPortrait_Lady.Width
'    ''        End If ''End of "If (bSwitchWidthHeight) Then"
'    ''
'    ''        ''Added 9/13/2019 td 
'    ''        .BadgeLayout = New BadgeLayoutClass(pictureBack.Width, pictureBack.Height)
'    ''
'    ''End of "''9/17/2019 td''"   ''End With ''End of "With field_standard.ElementInfo"

'    ''End If ''End of "If (ClassElementPic.ElementPicture Is Nothing) Then"

'    ''#1 7/31/2019 td''new_picControl = New CtlGraphicPortrait(ClassElementPic.ElementPicture)
'    '' #2 7/31/2019 td''new_picControl = New CtlGraphicPortrait(ClassElementPic.ElementPicture,
'    ''      CType(ClassElementPic.ElementPicture, IElementPic))
'    '' #2 7/31/2019 td''Me.Controls.Add(new_picControl)

'    ''
'    ''DIFFICULT & CONFUSING.....  Let's regenerate the control referenced above.  
'    ''
'    ''9/17/2019 td''CtlGraphicPortrait_Lady = New CtlGraphicPortrait(ClassElementPic.ElementPicture,
'    ''9/17/2019 td''                                CType(ClassElementPic.ElementPicture, IElementPic), Me)

'    CtlGraphicPortrait_Lady = New CtlGraphicPortrait(par_elementPic, Me)

'    Me.Controls.Add(CtlGraphicPortrait_Lady)

'    With CtlGraphicPortrait_Lady

'        ''9/17/2019 td''.Top = ClassElementPic.ElementPicture.TopEdge_Pixels
'        ''9/17/2019 td''.Left = ClassElementPic.ElementPicture.LeftEdge_Pixels
'        ''9/17/2019 td''.Width = ClassElementPic.ElementPicture.Width_Pixels
'        ''9/17/2019 td''.Height = ClassElementPic.ElementPicture.Height_Pixels

'        .Top = par_elementPic.TopEdge_Pixels
'        .Left = par_elementPic.LeftEdge_Pixels
'        .Width = par_elementPic.Width_Pixels
'        .Height = par_elementPic.Height_Pixels

'        ''Added 8/18/2019 td
'        .picturePortrait.Image = mod_imageLady

'        ''Added 9/17/2019 td
'        .Refresh_Master

'    End With ''End of "With CtlGraphicPortrait1"

'End Sub ''End of " Private Sub LoadElements_Picture()"

'Private Sub Initiate_RubberbandSelector(par_elementControls_All As List(Of CtlGraphicFldLabel),
'                                        par_elementControls_GroupEdit As List(Of CtlGraphicFldLabel))
'    ''9/20 td''Private Sub Initiate_RubberbandSelector() 
'    ''
'    ''Added 9/8/2019 td
'    ''
'    mod_rubberbandClass = New ClassRubberbandSelector

'    With mod_rubberbandClass

'        .PictureBack = Me.pictureBack

'        ''Added 9/20/2019 td  
'        .FieldControls_All = par_elementControls_All

'        ''Added 9/20/2019 td
'        .LayoutFunctions = CType(Me, ILayoutFunctions)

'        .FieldControls_GroupEdit = par_elementControls_GroupEdit

'        ''AddHandler , AddressOf mod_rubberbandClass.MouseMove
'        ''AddHandler .PictureBack.MouseMove, AddressOf mod_rubberbandClass.MouseMove
'        ''AddHandler .PictureBack.MouseMove, AddressOf mod_rubberbandClass.MouseMove
'        ''AddHandler .PictureBack.MouseMove, AddressOf mod_rubberbandClass.MouseMove

'    End With ''end of "With mod_rubberbandClass"

'End Sub ''End of "Private Sub InitiateRubberbandSelector"

''Private Sub LoadElements_Fields_Master(par_boolLoadingForm As Boolean, Optional par_bUnloading As Boolean = False)
''    ''
''    ''Added 9/03/2019 thomas downes 
''    ''
''    ''9/4 td''Const c_boolUseConsolidatedList As Boolean = False ''True
''    Dim boolUseConsolidatedList As Boolean ''Added 9/5/2019 td  

''    ''Added 9/5/2019 td  
''    boolUseConsolidatedList = True ''9/5 td''(2 <= dropdownHowToLoadFlds.SelectedIndex)

''    If (boolUseConsolidatedList) Then

''        ''9/6/2019 td''LoadElements_Fields_OneList(par_boolLoadingForm, par_bUnloading)
''        LoadElements_OneListOfFields(par_boolLoadingForm, par_bUnloading)

''    Else

''        LoadElements_Fields_TwoLists(par_boolLoadingForm, par_bUnloading)

''    End If ''End of "If (boolUseConsolidatedList) Then ..... Else ...."

''End Sub ''ENd of "Private Sub LoadElements_Fields_Master()"

''Private Sub LoadElements_OneListOfFields(par_boolLoadingForm As Boolean, Optional par_bUnloading As Boolean = False)
''    ''
''    ''Added 9/6/2019 td  
''    ''
''    LoadElements_ByListOfFields(ClassFields.ListAllFields(), par_boolLoadingForm)

''End Sub

''Private Sub LoadField_JustOne(par_field As ICIBFieldStandardOrCustom)
''    ''
''    ''Added 9/6/2019 thomas d. 
''    ''
''    Dim new_list As New List(Of ICIBFieldStandardOrCustom)
''    Const c_bAddToMoveableClass As Boolean = True ''Added 9/8/2019 td 

''    new_list.Add(par_field)

''    LoadElements_ByListOfFields(new_list, True, False,
''                                c_bAddToMoveableClass)

''End Sub ''End of "Private Sub LoadField_JustOne(...)"

''Private Sub LoadElements_ByListOfFields(par_list As List(Of ICIBFieldStandardOrCustom),
''                                       par_boolLoadingForm As Boolean,
''                                       Optional par_bUnloading As Boolean = False,
''                                        Optional par_bAddMoveability As Boolean = False)
''    ''
''    ''Added 9/03/2019 thomas downes 
''    ''Modified 9/5/2019 thomas downes
''    ''
''    Dim intCountControlsAdded As Integer = 0 ''Added 9/03/2019 td 
''    ''9/5/2019 td''Dim intTopEdge As Integer ''Added 7/28/2019 td
''    ''9/5/2019 td''Dim intLeftEdge As Integer ''Added 9/03/2019 td
''    Dim boolIncludeOnBadge As Boolean = False ''Added 9/03/2019 td
''    Dim intStagger As Integer = 0 ''Added 9.6.2019 td 

''    For Each each_field As ICIBFieldStandardOrCustom In par_list ''9/6/2019 td''ClassFields.ListAllFields()

''        Dim label_control As CtlGraphicFldLabel

''        ''Added 9/3/2019 thomas d. 
''        boolIncludeOnBadge = (par_boolLoadingForm And each_field.IsDisplayedOnBadge)
''        If (Not boolIncludeOnBadge) Then
''            AddToFlowPanelOfOmittedFlds(each_field)
''            Continue For
''        End If ''End of "If (Not boolIncludeOnBadge) Then"

''        ''
''        ''Has the user moved the field into place (and pressed the Save & Refresh link)??
''        ''
''        If (each_field.ElementInfo_Base Is Nothing) Then

''            ''Added 9/15/2019 thomas d. 
''            Throw New Exception("ElementInfo_Base should _not_ be uninitialized. 896741")

''            ''9/15 td''Dim new_element_text As New ClassElementText
''            ''
''            ''9/15 td''With new_element_text
''            ''    .Height_Pixels = 30 
''            ''    .FontFamilyName = "Times New Roman" ''Added 9/15/2019 thomas d. 
''            ''    .FontSize_Pixels = 25
''            ''    ''Added 9/12/2019 td 
''            ''    ''9/12/2019 td''.FontSize_IsLocked = True 
''            ''    .FontSize_ScaleToElementRatio = (.FontSize_Pixels / .Height_Pixels)
''            ''    .FontSize_ScaleToElementYesNo = True
''            ''
''            ''    ''Added 9/12/2019 td
''            ''    .BadgeLayout = New ciBadgeInterfaces.BadgeLayoutClass(pictureBack.Width, pictureBack.Height)
''            ''
''            ''End With 'End of "With new_element_text"

''            '''9/6/2019 td''new_element_text.TopEdge_Pixels = (30 + (30 * intCountControlsAdded))
''            ''intStagger = intCountControlsAdded
''            ''new_element_text.TopEdge_Pixels = (intStagger * new_element_text.Height_Pixels)
''            ''intCountControlsAdded += 1 ''Added 9/6/2019 td 

''            ''new_element_text.LeftEdge_Pixels = new_element_text.TopEdge_Pixels ''Left = Top !! By setting Left = Top, we will create 
''            '''   a nice diagonally-cascading effect. ---9/3/2019 td

''            ''9/15 td''each_field.ElementInfo_Base = new_element_text
''            ''9/15 td''each_field.ElementInfo_Text = new_element_text

''        Else
''            ''
''            ''Added 9/15/2019 td
''            ''
''            With each_field.ElementInfo_Base
''                .Height_Pixels = 30

''                ''9/6/2019 td''new_element_text.TopEdge_Pixels = (30 + (30 * intCountControlsAdded))
''                intStagger = intCountControlsAdded
''                .TopEdge_Pixels = (intStagger * .Height_Pixels)
''                intCountControlsAdded += 1 ''Added 9/6/2019 td 

''                .LeftEdge_Pixels = .TopEdge_Pixels ''Left = Top !! By setting Left = Top, we will create 
''                ''   a nice diagonally-cascading effect. ---9/3/2019 td

''                ''Added 9/12/2019 td
''                .BadgeLayout = New ciBadgeInterfaces.BadgeLayoutClass(pictureBack.Width, pictureBack.Height)

''            End With

''            ''Added 9/15/2019 td
''            With each_field.ElementInfo_Text
''                .FontFamilyName = "Times New Roman" ''Added 9/15/2019 thomas d. 
''                .FontSize_Pixels = 25
''                ''Added 9/12/2019 td 
''                ''9/12/2019 td''.FontSize_IsLocked = True 
''                .FontSize_ScaleToElementRatio = (.FontSize_Pixels / each_field.ElementInfo_Base.Height_Pixels)
''                .FontSize_ScaleToElementYesNo = True

''            End With 'End of "With new_element_text"

''        End If ''ENd of "If (each_field.ElementInfo_Base Is Nothing) Then ..... Else ...."

''        ''Added 9/5/2019 thomas d.
''        ''9/11/2019 td''each_field.ElementInfo_Base.LayoutWidth_Pixels = Me.Layout_Width_Pixels()
''        each_field.ElementInfo_Base.BadgeLayout.Width_Pixels = Me.Layout_Width_Pixels()
''        each_field.ElementInfo_Base.BadgeLayout.Height_Pixels = Me.Layout_Height_Pixels

''        ''#1 9/4/2019 td''label_control = New CtlGraphicFldLabel(each_field, Me)
''        '' #2 9/4/2019 td''label_control = New CtlGraphicFldLabel(each_field, new_element_text, Me)
''        ''9/17/2019 td''label_control = New CtlGraphicFldLabel(each_field, Me)
''        label_control = New CtlGraphicFldLabel(new_elementField, Me)

''        ''Moved below. 9/5 td''label_control.Refresh_Master()
''        label_control.Visible = each_field.IsDisplayedOnBadge ''BL = Badge Layout
''        intCountControlsAdded += 1
''        label_control.Name = "FieldControl" & CStr(intCountControlsAdded)

''        ''9/8 td''label_control.BorderStyle = BorderStyle.FixedSingle

''        ''Added 9/6/2019 thomas downes 
''        ''
''        ''   Stagger the elements on the badge layout, in a cascade from
''        '' the upper-left to the lower-right. 
''        '' ------9/6/2019 td
''        ''
''        If (0 = each_field.ElementInfo_Base.TopEdge_Pixels) Then
''            ''Added 9/6/2019 thomas downes 
''            label_control.Width = CInt(pictureBack.Width / 3)
''            With each_field.ElementInfo_Base
''                .Width_Pixels = label_control.Width
''                .Height_Pixels = label_control.Height
''                intStagger = intCountControlsAdded
''                .TopEdge_Pixels = (intStagger * .Height_Pixels)
''                .LeftEdge_Pixels = .TopEdge_Pixels ''Left = Top !! By setting Left = Top, we will create 
''                ''   a nice diagonally-cascading effect. ---9/3/2019 td
''                ''See above. 9/6/2019 td''intCountControlsAdded += 1 ''Added 9/6/2019 td 
''            End With ''End of " With each_field.ElementInfo_Base"
''        End If ''ENd of "If (0 = each_field.ElementInfo_Base.TopEdge_Pixels) Then"

''        boolIncludeOnBadge = (par_boolLoadingForm And each_field.IsDisplayedOnBadge)

''        If (boolIncludeOnBadge) Then

''            Me.Controls.Add(label_control)
''            label_control.Visible = True
''            label_control.BringToFront() ''Added 9/7/2019 thomas d.  
''            ''9/5/2019''label_control.Refresh_Image(True)
''            label_control.GroupEdits = CType(Me, ISelectingElements) ''Added 8/1 td

''            ''Added 9/7/2019 td
''            label_control.Left = Me.Layout_Margin_Left_Add(each_field.ElementInfo_Base.LeftEdge_Pixels)
''            label_control.Top = Me.Layout_Margin_Top_Add(each_field.ElementInfo_Base.TopEdge_Pixels)

''            ''
''            ''Major call !!  ----Thomas DOWNES
''            ''
''            label_control.Refresh_Master()

''            ''Added 9/8/2019 td
''            If (par_bAddMoveability) Then ControlMoverResizer_AddFieldCtl(label_control)

''        ElseIf (par_bUnloading) Then
''            ''9/3/2019 td''Me.Controls.Remove(label_control)
''            Throw New NotImplementedException
''
''        End If ''End of "If (boolInludeOnBadge) Then .... ElseIf (....) ...."
''
''    Next each_field
''
''    ''
''    ''Added 8/27/2019 thomas downes
''    ''
''    pictureBack.SendToBack() ''Added 9/7/2019 thomas d.
''    Me.Refresh() ''Added 8/28/2019 td   
''
''    ''9/5/2019 td''MessageBox.Show($"Number of field controls now on the form: {intCountControlsAdded}", "",
''    ''     MessageBoxButtons.OK, MessageBoxIcon.Information)
''
''End Sub ''End of ''Private Sub LoadElements_Fields_OneList()''

'Private Sub LoadFieldControls_ByListOfElements(par_listElements As List(Of ClassElementField),
'                           par_boolLoadingForm As Boolean,
'                           Optional par_bUnloading As Boolean = False,
'                           Optional par_bAddMoveability As Boolean = False,
'                            Optional ByRef par_listFieldCtls As List(Of CtlGraphicFldLabel) = Nothing)
'    ''
'    ''Added 9/17/2019 thomas downes 
'    ''
'    Dim intCountControlsAdded As Integer = 0 ''Added 9/03/2019 td 
'    Dim boolIncludeOnBadge As Boolean = False ''Added 9/03/2019 td
'    Dim intStagger As Integer = 0 ''Added 9.6.2019 td 

'    ''9/17/2019 td''For Each each_field As ICIBFieldStandardOrCustom In par_list  
'    For Each each_element As ClassElementField In par_listElements

'        Dim label_control As CtlGraphicFldLabel

'        ''Added 9/3/2019 thomas d. 
'        ''9/17/2019 td''boolIncludeOnBadge = (par_boolLoadingForm And each_element.IsDisplayedOnBadge)
'        boolIncludeOnBadge = (par_boolLoadingForm And each_element.FieldInfo.IsDisplayedOnBadge)

'        If (Not boolIncludeOnBadge) Then
'            ''#1 9/17/2019 td''AddToFlowPanelOfOmittedFlds(each_element)
'            '' #2 9/17/2019 td''AddToFlowPanelOfOmittedFlds(each_element.FieldInfo)
'            AddToFlowPanelOfOmittedFlds(each_element)
'            Continue For
'        End If ''End of "If (Not boolIncludeOnBadge) Then"

'        ''
'        ''Added 9/15/2019 td
'        ''
'        With each_element
'            .Height_Pixels = 30

'            ''9/6/2019 td''new_element_text.TopEdge_Pixels = (30 + (30 * intCountControlsAdded))
'            intStagger = intCountControlsAdded
'            .TopEdge_Pixels = (intStagger * .Height_Pixels)
'            intCountControlsAdded += 1 ''Added 9/6/2019 td 

'            .LeftEdge_Pixels = .TopEdge_Pixels ''Left = Top !! By setting Left = Top, we will create 
'            ''   a nice diagonally-cascading effect. ---9/3/2019 td

'            ''Added 9/12/2019 td
'            .BadgeLayout = New ciBadgeInterfaces.BadgeLayoutClass(pictureBack.Width, pictureBack.Height)

'        End With

'        ''Added 9/15/2019 td
'        With each_element
'            .FontFamilyName = "Times New Roman" ''Added 9/15/2019 thomas d. 
'            .FontSize_Pixels = 25
'            ''Added 9/12/2019 td 
'            ''9/12/2019 td''.FontSize_IsLocked = True 
'            .FontSize_ScaleToElementRatio = (.FontSize_Pixels / .Height_Pixels)
'            .FontSize_ScaleToElementYesNo = True

'        End With 'End of "With each_element"

'        ''Added 9/5/2019 thomas d.
'        ''9/11/2019 td''each_field.ElementInfo_Base.LayoutWidth_Pixels = Me.Layout_Width_Pixels()
'        each_element.BadgeLayout.Width_Pixels = Me.Layout_Width_Pixels()
'        each_element.BadgeLayout.Height_Pixels = Me.Layout_Height_Pixels

'        ''#1 9/4/2019 td''label_control = New CtlGraphicFldLabel(each_field, Me)
'        '' #2 9/4/2019 td''label_control = New CtlGraphicFldLabel(each_field, new_element_text, Me)
'        label_control = New CtlGraphicFldLabel(each_element, Me)

'        ''Moved below. 9/5 td''label_control.Refresh_Master()
'        label_control.Visible = each_element.FieldInfo.IsDisplayedOnBadge ''BL = Badge Layout
'        intCountControlsAdded += 1
'        label_control.Name = "FieldControl" & CStr(intCountControlsAdded)

'        ''9/8 td''label_control.BorderStyle = BorderStyle.FixedSingle

'        ''Added 9/6/2019 thomas downes 
'        ''
'        ''   Stagger the elements on the badge layout, in a cascade from
'        '' the upper-left to the lower-right. 
'        '' ------9/6/2019 td
'        ''
'        If (0 = each_element.TopEdge_Pixels) Then
'            ''Added 9/6/2019 thomas downes 
'            label_control.Width = CInt(pictureBack.Width / 3)
'            With each_element
'                .Width_Pixels = label_control.Width
'                .Height_Pixels = label_control.Height
'                intStagger = intCountControlsAdded
'                .TopEdge_Pixels = (intStagger * .Height_Pixels)
'                .LeftEdge_Pixels = .TopEdge_Pixels ''Left = Top !! By setting Left = Top, we will create 
'                ''   a nice diagonally-cascading effect. ---9/3/2019 td
'                ''See above. 9/6/2019 td''intCountControlsAdded += 1 ''Added 9/6/2019 td 
'            End With ''End of " With each_field.ElementInfo_Base"
'        End If ''ENd of "If (0 = each_field.ElementInfo_Base.TopEdge_Pixels) Then"

'        boolIncludeOnBadge = (par_boolLoadingForm And each_element.FieldInfo.IsDisplayedOnBadge)

'        If (boolIncludeOnBadge) Then

'            Me.Controls.Add(label_control)
'            par_listFieldCtls.Add(label_control) ''Added 9/20/2019 td

'            label_control.Visible = True
'            label_control.BringToFront() ''Added 9/7/2019 thomas d.  
'            ''9/5/2019''label_control.Refresh_Image(True)
'            label_control.GroupEdits = CType(Me, ISelectingElements) ''Added 8/1 td

'            ''Added 9/7/2019 td
'            label_control.Left = Me.Layout_Margin_Left_Add(each_element.LeftEdge_Pixels)
'            label_control.Top = Me.Layout_Margin_Top_Add(each_element.TopEdge_Pixels)

'            ''
'            ''Major call !!  ----Thomas DOWNES
'            ''
'            label_control.Refresh_Master()

'            ''Added 9/8/2019 td
'            If (par_bAddMoveability) Then ControlMoverResizer_AddFieldCtl(label_control)

'        ElseIf (par_bUnloading) Then
'            ''9/3/2019 td''Me.Controls.Remove(label_control)
'            Throw New NotImplementedException

'        End If ''End of "If (boolInludeOnBadge) Then .... ElseIf (....) ...."

'    Next each_element

'    ''
'    ''Added 8/27/2019 thomas downes
'    ''
'    pictureBack.SendToBack() ''Added 9/7/2019 thomas d.
'    Me.Refresh() ''Added 8/28/2019 td   

'    ''9/5/2019 td''MessageBox.Show($"Number of field controls now on the form: {intCountControlsAdded}", "",
'    ''     MessageBoxButtons.OK, MessageBoxIcon.Information)

'End Sub ''End of ''Private Sub LoadElements_ByListOfElements()''

'Private Sub LoadFieldControl_JustOne(par_elementField As ClassElementField)
'    ''
'    ''Added 9/17/2019 thomas d.  
'    ''
'    Dim new_list As New List(Of ClassElementField)
'    Const c_bAddToMoveableClass As Boolean = True ''Added 9/8/2019 td 

'    new_list.Add(par_elementField)

'    ''9/24/2019 td''LoadFieldControls_ByListOfElements(new_list, True, False, c_bAddToMoveableClass)
'    LoadFieldControls_ByListOfElements(new_list, True, False, c_bAddToMoveableClass, mod_listOfFieldControls)

'End Sub ''End of "Private Sub LoadFieldControl_JustOne(par_elementField As ClassElementField)"

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

'Private Sub AddToFlowPanelOfOmittedFlds(par_elementField As ClassElementField)
'    ''
'    ''Added 9/17/2019 td
'    ''
'    Dim new_linkLabel As New LinkLabel
'    new_linkLabel.Tag = par_elementField
'    new_linkLabel.Text = par_elementField.FieldInfo.FieldLabelCaption
'    flowFieldsNotListed.Controls.Add(new_linkLabel)
'    new_linkLabel.Visible = True
'    AddHandler new_linkLabel.LinkClicked, AddressOf AddField_LinkClicked

'End Sub ''End of "Private Sub AddToFlowPanelOfOmittedFlds(par_elementField As ClassElementField)"

''9/17/2019 td''Private Sub LoadElements_Fields_OneList_NotInUse(par_boolLoadingForm As Boolean, Optional par_bUnloading As Boolean = False)
''    ''
''    ''Added 9/03/2019 thomas downes 
''    ''Suffixed with "_NotInUse" on 9/5/2019 td 
''    ''
''    Dim intCountControlsAdded As Integer ''Added 9/03/2019 td 
''    Dim intTopEdge As Integer ''Added 7/28/2019 td
''    Dim intLeftEdge As Integer ''Added 9/03/2019 td
''    Dim boolIncludeOnBadge As Boolean ''Added 9/03/2019 td

''    For Each each_field As ICIBFieldStandardOrCustom In ClassFields.ListAllFields()

''        Dim label_control As CtlGraphicFldLabel

''        ''Added 9/3/2019 thomas d. 
''        boolIncludeOnBadge = (par_boolLoadingForm And each_field.IsDisplayedOnBadge)
''        If (Not boolIncludeOnBadge) Then Continue For

''        ''
''        ''Has the user moved the field into place (and pressed the Save & Refresh link)??
''        ''
''        If (each_field.ElementInfo_Base Is Nothing) Then

''            Dim new_element_text As New ClassElementField

''            ''Added 9/5/2019 thomas d.
''            ''9/11/2019 td''new_element_text.LayoutWidth_Pixels = Me.Layout_Width_Pixels()
''            new_element_text.BadgeLayout.Width_Pixels = Me.Layout_Width_Pixels()

''            each_field.ElementInfo_Base = new_element_text
''            each_field.ElementInfo_Text = new_element_text

''            ''#1 9/4/2019 td''label_control = New CtlGraphicFldLabel(each_field, Me)
''            '' #2 9/4/2019 td''label_control = New CtlGraphicFldLabel(each_field, new_element_text, Me)
''            label_control = New CtlGraphicFldLabel(each_field, Me, new_element_text)

''            ''If (par_boolLoadingForm) Then
''            ''    Me.Controls.Add(label_control)
''            ''ElseIf (par_bUnloading) Then
''            ''    ''9/3/2019 td''Me.Controls.Remove(label_control)
''            ''    Throw New NotImplementedException
''            ''End If

''            label_control.Width = CInt(pictureBack.Width / 3)

''            With each_field.ElementInfo_Base

''                .Width_Pixels = label_control.Width
''                .Height_Pixels = label_control.Height

''                intTopEdge = (30 + (30 * intCountControlsAdded))
''                intLeftEdge = intTopEdge ''Left = Top !! By setting Left = Top, we will create 
''                ''   a nice diagonally-cascading effect. ---9/3/2019 td

''                .TopEdge_Pixels = intTopEdge
''                .LeftEdge_Pixels = intLeftEdge

''            End With ''End of "With field_standard.ElementInfo"


''        ElseIf (0 = each_field.ElementInfo_Base.TopEdge_Pixels) Then
''            ''
''            ''Added 9/6/2019 thomas downes 
''            ''
''            ''9/11/2019 td''each_field.ElementInfo_Base.LayoutWidth_Pixels = Me.Layout_Width_Pixels()
''            each_field.ElementInfo_Base.BadgeLayout.Width_Pixels = Me.Layout_Width_Pixels()
''            each_field.ElementInfo_Base.BadgeLayout.Height_Pixels = Me.Layout_Height_Pixels()

''            label_control = New CtlGraphicFldLabel(each_field, Me)
''            label_control.Width = CInt(pictureBack.Width / 3)
''            With each_field.ElementInfo_Base
''                .Width_Pixels = label_control.Width
''                .Height_Pixels = label_control.Height
''                intTopEdge = (30 + (30 * intCountControlsAdded))
''                intLeftEdge = intTopEdge ''Left = Top !! By setting Left = Top, we will create 
''                ''   a nice diagonally-cascading effect. ---9/3/2019 td
''                .TopEdge_Pixels = intTopEdge
''                .LeftEdge_Pixels = intLeftEdge
''            End With ''End of " With each_field.ElementInfo_Base"

''        Else

''            ''Added 9/5/2019 thomas d.
''            ''9/11/2019 td''each_field.ElementInfo_Base.LayoutWidth_Pixels = Me.Layout_Width_Pixels()
''            each_field.ElementInfo_Base.BadgeLayout.Width_Pixels = Me.Layout_Width_Pixels()
''            each_field.ElementInfo_Base.BadgeLayout.Height_Pixels = Me.Layout_Height_Pixels() ''Added 9/11/2019 Never Forget

''            label_control = New CtlGraphicFldLabel(each_field, Me)

''            ''If (par_boolLoadingForm) Then
''            ''    Me.Controls.Add(label_control)
''            ''ElseIf (par_bUnloading) Then ''Added 8/28/2019 thomas downes 
''            ''    ''Added 8/28/2019 thomas downes 
''            ''    ''9/3/2019 td''Me.Controls.Remove(label_control)
''            ''    Throw New NotImplementedException
''            ''End If ''End of "If (par_boolLoadingForm) Then .... ElseIf ....."

''            ''Moved far below. ''new_label_control_std.GroupEdits = CType(Me, ISelectingElements) ''Added 8/1 td

''        End If ''end of "If (field_standard.ElementInfo Is Nothing) Then ... Else..."

''        ''Added 9/3/2019 thomas downes
''        ''   Start from the Layout Background's TopLeft corner. 
''        ''
''        ''9/5 td''label_control.Top = pictureBack.Top
''        ''9/5 td''label_control.Left = pictureBack.Left

''        '''Added 9/3/2019 thomas downes
''        '''   Move into position from the Layout Background's TopLeft corner. 
''        '''
''        ''9/5 td''label_control.Top += each_field.ElementInfo_Base.TopEdge_Pixels
''        ''9/5 td''label_control.Left += each_field.ElementInfo_Base.LeftEdge_Pixels

''        ''9/5 td''label_control.Width = each_field.ElementInfo_Base.Width_Pixels
''        ''9/5 td''label_control.Height = each_field.ElementInfo_Base.Height_Pixels

''        With label_control ''Added 9/5/2019 td
''            ''Added 9/5/2019 td
''            .Top = Me.Layout_Margin_Top_Add(each_field.ElementInfo_Base.TopEdge_Pixels)
''            .Left = Me.Layout_Margin_Left_Add(each_field.ElementInfo_Base.LeftEdge_Pixels)

''            .Width = each_field.ElementInfo_Base.Width_Pixels
''            .Height = each_field.ElementInfo_Base.Height_Pixels

''        End With ''End of "With label_control"

''        label_control.Visible = each_field.IsDisplayedOnBadge ''BL = Badge Layout

''        intCountControlsAdded += 1

''        label_control.Name = "FieldControl" & CStr(intCountControlsAdded)

''        ''9/8 td''label_control.BorderStyle = BorderStyle.FixedSingle

''        boolIncludeOnBadge = (par_boolLoadingForm And each_field.IsDisplayedOnBadge)

''        If (boolIncludeOnBadge) Then

''            Me.Controls.Add(label_control)
''            label_control.Visible = True
''            label_control.Refresh_Image(True)
''            label_control.GroupEdits = CType(Me, ISelectingElements) ''Added 8/1 td

''        ElseIf (par_bUnloading) Then
''            ''9/3/2019 td''Me.Controls.Remove(label_control)
''            Throw New NotImplementedException

''        End If ''End of "If (boolInludeOnBadge) Then .... ElseIf (....) ...."

''    Next each_field

''    ''
''    ''Added 8/27/2019 thomas downes
''    ''
''    Me.Refresh() ''Added 8/28/2019 td   

''    MessageBox.Show($"Number of field controls now on the form: {intCountControlsAdded}", "",
''                    MessageBoxButtons.OK, MessageBoxIcon.Information)

''End of "9/17/2019 td"End Sub ''End of ''Private Sub LoadElements_Fields_OneList()''





''9/17/2019 td''Private Sub LoadElements_Fields_TwoLists(par_boolLoadingForm As Boolean, Optional par_bUnloading As Boolean = False)
''    ''
''    ''Added 7/18/2019 thomas downes 
''    ''
''    ''mod_Pic = New ClassElementPic(pictureboxPic)

''    ''mod_RecipientID = mod_generator.GetRecipientID(GraphicFieldLabel1) ''New ClassElementText
''    ''mod_NameFull = mod_generator.GetFullName(GraphicFieldLabel2) ''New ClassElementText

''    ''mod_Text1 = mod_generator.GetTextField1(gr) ''New ClassElementText
''    ''mod_Text2 = mod_generator.GetTextField2(PictureBox13) ''New ClassElementText
''    ''mod_Text3 = mod_generator.GetTextField3(PictureBox14)

''    ''mod_Date1 = mod_generator.GetDateField1(PictureBox15) ''New ClassElementText
''    ''mod_Date2 = mod_generator.GetDateField2(PictureBox16) ''New ClassElementText

''    Dim intNumControlsAlready_std As Integer ''Added 7/26/2019 td 
''    Dim intNumControlsAlready_cust As Integer ''Added 7/26/2019 td 
''    ''7/31 td''Dim intTopEdge_cust As Integer ''Added 7/28/2019 td
''    Dim intTopEdge_std As Integer ''Added 7/28/2019 td

''    Dim intCountControlsAdded As Integer ''Added 8/27/2019 td 
''    Dim boolIncludeOnBadge As Boolean ''Added 9/03/2019 td

''    ''
''    ''Standard Fields 
''    ''
''    ClassFieldStandard.InitializeHardcodedList_Students(True)

''    For Each each_field_standard As ClassFieldStandard In ClassFieldStandard.ListOfFields_Students

''        ''Added 9/5/2019 thomas d.
''        ''9/11/2019 td''each_field_standard.ElementInfo.LayoutWidth_Pixels = Me.Layout_Width_Pixels
''        each_field_standard.ElementFieldClass.BadgeLayout.Width_Pixels = Me.Layout_Width_Pixels
''        each_field_standard.ElementFieldClass.BadgeLayout.Height_Pixels = Me.Layout_Height_Pixels

''        Dim new_label_control_std As CtlGraphicFldLabel

''        ''Added 9/3/2019 thomas d. 
''        boolIncludeOnBadge = (par_boolLoadingForm And each_field_standard.IsDisplayedOnBadge)
''        If (Not boolIncludeOnBadge) Then Continue For

''        ''Added 7/29
''        If (each_field_standard.ElementFieldClass Is Nothing) Then

''            each_field_standard.ElementFieldClass = New ClassElementField()

''            ''8/9/2019 td''new_label_control_std = New CtlGraphicFldLabel(field_standard)
''            new_label_control_std = New CtlGraphicFldLabel(each_field_standard, Me)

''            ''8/28/2019 td''Me.Controls.Add(new_label_control_std)
''            If (par_boolLoadingForm) Then
''                Me.Controls.Add(new_label_control_std)
''            ElseIf (par_bUnloading) Then ''Added 8/28/2019 thomas downes 
''                ''Added 8/28/2019 thomas downes 
''                Me.Controls.Remove(new_label_control_std)
''            End If

''            intCountControlsAdded += 1 ''Added 8/27/2019 td

''            ''Moved far below. ''new_label_control_std.GroupEdits = CType(Me, ISelectingElements) ''Added 8/1 td

''            new_label_control_std.Width = CInt(pictureBack.Width / 3)

''            With each_field_standard.ElementFieldClass

''                .Width_Pixels = new_label_control_std.Width
''                .Height_Pixels = new_label_control_std.Height

''                intTopEdge_std = (30 + 30 * intNumControlsAlready_std)
''                .TopEdge_Pixels = intTopEdge_std
''                .LeftEdge_Pixels = intTopEdge_std ''((10 + intNumControlsAlready_std * .Width_Pixels) + 10)

''            End With ''End of "With field_standard.ElementInfo"

''        Else

''            ''Added 8/9/2019 td''new_label_control_std = New CtlGraphicFldLabel(field_standard)
''            new_label_control_std = New CtlGraphicFldLabel(each_field_standard, Me)

''            ''8/28/2019 td''Me.Controls.Add(new_label_control_std)
''            intCountControlsAdded += 1 ''Added 8/27/2019 td

''            If (par_boolLoadingForm) Then
''                Me.Controls.Add(new_label_control_std)
''            ElseIf (par_bUnloading) Then ''Added 8/28/2019 thomas downes 
''                ''Added 8/28/2019 thomas downes 
''                Me.Controls.Remove(new_label_control_std)
''            End If ''End of "If (par_boolLoadingForm) Then ... ElseIf ...."

''            ''Moved far below. ''new_label_control_std.GroupEdits = CType(Me, ISelectingElements) ''Added 8/1 td

''        End If ''end of "If (field_standard.ElementInfo Is Nothing) Then ... Else..."

''        ''Added 9/3/2019 thomas downes
''        ''   Start from the Layout Background's TopLeft corner. 
''        ''
''        With new_label_control_std

''            ''Start from the Layout Background's TopLeft corner. ---9/3/2019 td

''            ''9/5/2019 td''.Top = pictureBack.Top
''            ''9/5/2019 td''.Left = pictureBack.Left

''            ''9/5/2019 td''.Top += each_field_standard.ElementInfo.TopEdge_Pixels
''            ''9/5/2019 td''.Left += each_field_standard.ElementInfo.LeftEdge_Pixels

''            .Top = Me.Layout_Margin_Top_Add(each_field_standard.ElementFieldClass.TopEdge_Pixels)
''            .Left = Me.Layout_Margin_Left_Add(each_field_standard.ElementFieldClass.LeftEdge_Pixels)

''            .Width = each_field_standard.ElementFieldClass.Width_Pixels
''            .Height = each_field_standard.ElementFieldClass.Height_Pixels

''        End With ''End of "With new_label_control_std"

''        ''intTopEdge_std = (30 + 30 * intNumControlsAlready_std)

''        ''Moved up.''Me.Controls.Add(new_label_control_std)

''        ''Inappropriate. 7/29 td''new_label_control_std.Left = ((10 + intNumControlsAlready_std * new_label_control_std.Width) + 10)
''        ''Inappropriate. 7/29 td'''new_label_control_std.Top = 10
''        ''Inappropriate. 7/29 td''new_label_control_std.Top = intTopEdge_std

''        new_label_control_std.Visible = True
''        intNumControlsAlready_std += 1

''        new_label_control_std.Name = "StandardCtl" & CStr(intNumControlsAlready_std)

''        ''9/8 td''new_label_control_std.BorderStyle = BorderStyle.FixedSingle

''        ''
''        ''Added 7/28/2019 thomas d.
''        ''
''        new_label_control_std.Refresh_Image(True)

''        ''Added 7/28/2019 thomas d.
''        new_label_control_std.GroupEdits = CType(Me, ISelectingElements) ''Added 8/1 td

''    Next each_field_standard

''    ''
''    ''Custom Fields 
''    ''
''    Dim intTopEdge_cust As Integer ''Added 7/28/2019 td
''    ClassFieldCustomized.InitializeHardcodedList_Students(True)

''    For Each each_field_custom As ClassFieldCustomized In ClassFieldCustomized.ListOfFields_Students

''        ''Added 7/29
''        ''If (field_custom.ElementInfo Is Nothing) Then field_custom.ElementInfo = New ClassElementText()

''        ''Dim new_label_control_cust As New GraphicFieldLabel(field_custom)

''        ''intTopEdge_cust = (30 + 30 * intNumControlsAlready_cust)

''        ''Me.Controls.Add(new_label_control_cust)
''        ''new_label_control_cust.Left = ((intNumControlsAlready_cust * new_label_control_cust.Width) + 10)
''        '''7/28 td''new_label_control_cust.Top = (120 + new_label_control_cust.Height)
''        ''new_label_control_cust.Top = intTopEdge_cust
''        ''new_label_control_cust.Visible = True

''        ''7/28/2019 td''ControlMoverOrResizer_TD.Init(new_label_control_cust, 20) ''Added 7/28/2019 thomas downes

''        ''Added 9/5/2019 thomas d.
''        ''9/11/2019 td''each_field_custom.ElementInfo.LayoutWidth_Pixels = Me.Layout_Width_Pixels
''        each_field_custom.ElementFieldClass.BadgeLayout.Width_Pixels = Me.Layout_Width_Pixels
''        each_field_custom.ElementFieldClass.BadgeLayout.Height_Pixels = Me.Layout_Width_Pixels

''        Dim new_label_control_cust As CtlGraphicFldLabel

''        ''Added 9/3/2019 thomas d. 
''        boolIncludeOnBadge = (par_boolLoadingForm And each_field_custom.IsDisplayedOnBadge)
''        If (Not boolIncludeOnBadge) Then Continue For

''        ''Added 7/29
''        If (each_field_custom.ElementFieldClass Is Nothing) Then

''            each_field_custom.ElementFieldClass = New ClassElementField()

''            ''8/9/2019 td''new_label_control_cust = New CtlGraphicFldLabel(field_custom)
''            new_label_control_cust = New CtlGraphicFldLabel(each_field_custom, Me)

''            ''8/28/2019 td''Me.Controls.Add(new_label_control_cust)
''            intCountControlsAdded += 1 ''Added 8/27/2019 td

''            If (par_boolLoadingForm) Then
''                Me.Controls.Add(new_label_control_cust)
''            ElseIf (par_bUnloading) Then ''Added 8/28/2019 thomas downes 
''                ''Added 8/28/2019 thomas downes 
''                Me.Controls.Remove(new_label_control_cust)
''            End If

''            new_label_control_cust.Width = CInt(pictureBack.Width / 3)

''            With each_field_custom.ElementFieldClass

''                .Width_Pixels = new_label_control_cust.Width
''                .Height_Pixels = new_label_control_cust.Height

''                intTopEdge_cust = (30 + 30 * intNumControlsAlready_cust)
''                .TopEdge_Pixels = intTopEdge_cust
''                .LeftEdge_Pixels = intTopEdge_cust '' ((10 + intNumControlsAlready_cust * .Width_Pixels) + 10)

''            End With ''End of "With each_field_custom.ElementInfo"

''        Else

''            ''8/9/2019 td''new_label_control_cust = New CtlGraphicFldLabel(field_custom)
''            new_label_control_cust = New CtlGraphicFldLabel(each_field_custom, Me)

''            ''8/28/2019 td''Me.Controls.Add(new_label_control_cust)
''            intCountControlsAdded += 1 ''Added 8/27/2019 td

''            If (par_boolLoadingForm) Then
''                Me.Controls.Add(new_label_control_cust)
''            ElseIf (par_bUnloading) Then ''Added 8/28/2019 thomas downes 
''                ''Added 8/28/2019 thomas downes 
''                Me.Controls.Remove(new_label_control_cust)
''            End If

''        End If ''end of "If (field_standard.ElementInfo Is Nothing) Then ... Else..."

''        ''9/5 td''new_label_control_cust.Top = each_field_custom.ElementInfo.TopEdge_Pixels
''        ''9/5 td''new_label_control_cust.Left = each_field_custom.ElementInfo.LeftEdge_Pixels
''        ''9/5 td''new_label_control_cust.Width = each_field_custom.ElementInfo.Width_Pixels
''        ''9/5 td''new_label_control_cust.Height = each_field_custom.ElementInfo.Height_Pixels

''        With new_label_control_cust
''            .Top = Me.Layout_Margin_Top_Add(each_field_custom.ElementFieldClass.TopEdge_Pixels)
''            .Left = Me.Layout_Margin_Left_Add(each_field_custom.ElementFieldClass.LeftEdge_Pixels)

''            .Width = each_field_custom.ElementFieldClass.Width_Pixels
''            .Height = each_field_custom.ElementFieldClass.Height_Pixels
''        End With ''End of "With new_label_control_cust"

''        ''intTopEdge_std = (30 + 30 * intNumControlsAlready_std)

''        ''Moved up.''Me.Controls.Add(new_label_control_cust)

''        ''Inappropriate. 7/29 td''new_label_control_std.Left = ((10 + intNumControlsAlready_std * new_label_control_std.Width) + 10)
''        ''Inappropriate. 7/29 td'''new_label_control_std.Top = 10
''        ''Inappropriate. 7/29 td''new_label_control_std.Top = intTopEdge_std

''        intNumControlsAlready_cust += 1
''        new_label_control_cust.Name = "CustCtl" & CStr(intNumControlsAlready_cust)
''        ''9/8 td''new_label_control_cust.BorderStyle = BorderStyle.FixedSingle

''        ''
''        ''Added 7/28/2019 thomas d.
''        ''
''        new_label_control_cust.Refresh_Image(True)

''        ''Added 7/28/2019 thomas d.
''        new_label_control_cust.GroupEdits = CType(Me, ISelectingElements) ''Added 8/1 td

''    Next each_field_custom

''    ''
''    ''Added 8/27/2019 thomas downes
''    ''
''    Me.Refresh() ''Added 8/28/2019 td   
''    MessageBox.Show($"Number of field controls now on the form: {intCountControlsAdded}", "",
''                    MessageBoxButtons.OK, MessageBoxIcon.Information)

''End of "9/17/2019 td" End Sub ''End of ''Private Sub LoadElements_Fields_TwoLists()''