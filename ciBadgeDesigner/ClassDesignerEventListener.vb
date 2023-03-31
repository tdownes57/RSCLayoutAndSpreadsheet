Option Explicit On
Option Strict On
Option Infer Off
''
''Added 10/1/2019 thomas downes 
''
Imports System.Windows.Forms ''Added 10/1/2019 thomas downes 
Imports ciBadgeInterfaces ''Added 10/1/2019 thomas downes 
''Imports ciBadgeElements ''Added 10/1/2019 thomas downes 
''Imports System.Drawing ''Added 10/1/2019 thomas downes 
''Imports ciLayoutPrintLib ''Added 10/1/2019 td
Imports MoveAndResizeControls_Monem ''Added 10/3/2019 td
''Imports ciBadgeGenerator ''Added 10/5/2019 thomas d.
Imports __RSCWindowsControlLibrary ''Added 1/12/2022 thomas d. 

Public Class ClassDesignerEventListener
    ''   Implements ILayoutFunctions
    ''
    ''Added 11/29/2021 thomas Downes
    ''
    ''   This class module will assist in listening for MoveAndResize
    ''      events.  
    ''
    ''   See project ciBadgeDesigner for this class,
    ''       ClassDesignerListenToMover. 
    ''
    ''   ----11/29/2021 td 
    ''
    Private m_bAddBorderOnlyWhileResizing As Boolean ''Added 11/29/2021  

    ''#1 8-3-2019 td''Private WithEvents mod_moveAndResizeCtls_NA As New MoveAndResizeControls_Monem.ControlMove_RaiseEvents ''Added 8/3/2019 td  
    '' #2 8-3-2019 td''Private WithEvents mod_moveAndResizeCtls As New MoveAndResizeControls_Monem.ControlMove_GroupMove ''Added 8/3/2019 td  
    ''#1 10/1/2019 td''Private WithEvents mod_groupedMove As New ClassGroupMove(Me) ''8/4/2019 td''New ClassGroupMove
    '' #2 10/1/2019 td''Private WithEvents mod_groupedMove As New ClassGroupMove(Me.LayoutFunctions) ''8/4/2019 td''New ClassGroupMove
    Private WithEvents mod_eventsGroupedMove As GroupMoveEvents_Singleton ''(Me) ''8/4/2019 td''New ClassGroupMove

    ''Not needed''Private WithEvents mod_singletonMove As GroupMoveEvents_Singleton ''Added 12/3/2021  

    ''Dec17 2021''Private WithEvents mod_sizingEvents_Pics As ClassGroupMoveEvents ''(Me) ''Added 10/9/2019 td  
    ''Dec17 2021''Private WithEvents mod_sizingEvents_QR As ClassGroupMoveEvents ''(Me) ''Added 10/12/2019 td  
    ''Dec17 2021''Private WithEvents mod_sizingEvents_Sig As ClassGroupMoveEvents ''(Me) ''Added 10/12/2019 td  
    ''Dec17 2021''Private WithEvents mod_sizingEvents_StaticText As ClassGroupMoveEvents ''(Me) ''Added 10/12/2019 td  
    Public WithEvents SizingElementEvents As GroupMoveEvents_Singleton ''(Me) ''Added 12/17/2021 td  

    Private Const mc_boolAllowGroupMovements As Boolean = True ''False ''True ''False ''Added 8/3/2019 td  
    Private Const mc_boolBreakpoints As Boolean = True
    Private Const mc_boolMoveGrowInUnison As Boolean = True ''Added 10/10/2019 td 

    ''Added 11/29/2021 td  
    ''Jan11 2022''Private Const mc_bUseNonStaticMovers As Boolean = True ''Added 11/29/2021 td 
    ''Jan11 2022''Private mod_dictyControlMoveFields As New Dictionary(Of CtlGraphicFldLabel, ControlMove_Group_NonStatic)
    ''''1/10/2022 td''Public mod_dictyControlMoveBoxesEtc As New Dictionary(Of Control, ControlMove_NonStatic_TD)
    ''''1/10/2022 td''Public DictyControlResizing As New Dictionary(Of Control, ControlResizeProportionally_TD)
    ''Jan11 2022''Public mod_dictyControlGroupMoveEvents As New Dictionary(Of Control, ControlMove_Group_NonStatic)

    ''Added 10/12/2019 td 
    ''Dec12 2021''Private mod_sizing_portrait As New ControlResizeProportionally_TD ''Added 10/12/2019 td 
    ''Dec12 2021''Private mod_sizing_signature As New ControlResizeProportionally_TD ''Added 10/12/2019 td 
    ''Dec12 2021''Private mod_sizing_QR As New ControlResizeProportionally_TD ''Added 10/12/2019 td 
    ''Dec12 2021''Private mod_sizing_staticText As New ControlResizeProportionally_TD ''Added 12/16/2021 td

    ''Added 12/17/2021 td
    ''Public Sizing_portrait As ControlResizeProportionally_TD
    ''Public Sizing_signature As ControlResizeProportionally_TD
    ''Public Sizing_QR As ControlResizeProportionally_TD
    ''''12/23/2021 td''Public Sizing_staticText As ControlResizeProportionally_TD
    ''Public Sizing_staticText As ControlMove_Group_NonStatic ''Modified 12/23/2021 td

    ''Added 11/29/2021 td 
    Private mod_designer As ClassDesigner

    Public Sub New(par_designer As ClassDesigner,
                   par_eventsGroupMove As GroupMoveEvents_Singleton,
                   p_bAddBorderOnlyWhileResizing As Boolean)
        ''
        ''Added 11/29/2021 td
        ''
        mod_designer = par_designer

        ''Added 11/29/2021 td
        ''Jan5 2022 td''mod_groupedMove = New GroupMoveEvents_Singleton(par_designer)
        ''Jan5 2022 td''mod_singletonMove = New GroupMoveEvents_Singleton(par_designer)

        mod_eventsGroupedMove = par_eventsGroupMove
        ''Not needed. Jan10 2022''mod_singletonMove = par_eventsGroupMove

        ''Dec17 2021''mod_sizingEvents_Pics = New ClassGroupMoveEvents(par_designer)
        ''Dec17 2021''mod_sizingEvents_QR = New ClassGroupMoveEvents(par_designer)
        ''Dec17 2021''mod_sizingEvents_Sig = New ClassGroupMoveEvents(par_designer)
        ''Dec17 2021''mod_sizingEvents_StaticText = New ClassGroupMoveEvents(par_designer)
        ''Jan5 2022 td''SizingElementEvents = New GroupMoveEvents_Singleton(par_designer)
        SizingElementEvents = par_eventsGroupMove

        ''Added 11/29/2021 td
        m_bAddBorderOnlyWhileResizing = p_bAddBorderOnlyWhileResizing

        ''Added 12/6/2021 td
        ''--//--// I don't think this is needed anymore. Jan11 2022
        ''--//--AddHandler mod_eventsGroupedMove.ControlIsMoving, AddressOf mod_ControlIsMoving

    End Sub ''End of Public Sub New


    Public Sub LoadDesigner(par_listOfFieldControlsV3 As _
                                HashSet(Of CtlGraphicFieldV3),
                            par_listOfFieldControlsV4 As _
                                HashSet(Of CtlGraphicFieldV4),
                    par_listDesignerControls As HashSet(Of RSCMoveableControlVB)) '',
        ''                    par_strWhyCalled As String)
        ''
        ''Encapsulated 11/29/2021
        ''
        ''This procedure is copied, in part, from the same-named procedure
        ''  in class ClassDesigner. 
        ''   ----11/29/2021 thomas d. 
        ''
        ''Badge Preview is also moveable/sizeable, mostly to impress
        ''    management.  ----9/8/2019 td
        ''
        ''Const c_boolBreakpoint As Boolean = True  ''Added 9//13/2019 td
        ''
        ''If (mc_bUseNonStaticMovers) Then
        ''    ''Added 11/29/2021 td 
        ''    ''
        ''    ''This will use an object instance ("New") to manage movement.
        ''    ''
        ''    Dim objMover As New ControlMove_Group_NonStatic

        ''    ''objMover.Init(Me.PreviewBox, Me.PreviewBox, 10, False,
        ''    ''                  c_boolBreakpoint)
        ''    ''mod_dictyControlMoveBoxesEtc.Add(Me.PreviewBox, objMover)
        ''    objMover.Init(mod_designer.PreviewBox,
        ''                  mod_designer.PreviewBox, 10, False,
        ''                   mod_singletonMove, c_boolBreakpoint, Nothing, True)
        ''    mod_dictyControlMoveBoxesEtc.Add(mod_designer.PreviewBox, objMover)

        ''Else
        ''    ControlMoverOrResizer_TD.Init(mod_designer.PreviewBox,
        ''                                  mod_designer.PreviewBox, 10, False,
        ''                      c_boolBreakpoint, Nothing) ''Added 9/08/2019 thomas downes
        ''End If ''End of "If (mc_bUseNonStaticMovers) Then .... Else If...."
        ''
        ''Const c_LayoutBackIsMoveable As Boolean = False ''Added 9/8/2019 td 
        ''
        ''If (c_LayoutBackIsMoveable And mc_bUseNonStaticMovers) Then
        ''    ''Badge Layout Background is also moveable/sizeable.
        ''    Dim objMover As New ControlMove_NonStatic_TD
        ''    ''objMover.Init(Me.BackgroundBox,
        ''    ''              Me.BackgroundBox, 10, False,
        ''    ''              c_boolBreakpoint) ''Added 9/08/2019 thomas downes
        ''    objMover.Init(mod_designer.BackgroundBox_Front,
        ''                  mod_designer.BackgroundBox_Front, 10, False,
        ''                  mod_singletonMove, c_boolBreakpoint, Nothing) ''Added 9/08/2019 thomas downes
        ''    ''Added 12/1/2021 td
        ''    mod_dictyControlMoveBoxesEtc.Add(mod_designer.BackgroundBox_Front, objMover)
        ''
        ''ElseIf (c_LayoutBackIsMoveable) Then
        ''    ''Badge Layout Background is also moveable/sizeable.
        ''    ''ControlMoverOrResizer_TD.Init(Me.BackgroundBox,
        ''    ''                  Me.BackgroundBox, 10, False,
        ''    ''                  c_boolBreakpoint) ''Added 9/08/2019 thomas downes
        ''    ControlMoverOrResizer_TD.Init(mod_designer.BackgroundBox_Front,
        ''                      mod_designer.BackgroundBox_Front, 10, False,
        ''                      c_boolBreakpoint, Nothing) ''Added 9/08/2019 thomas downes
        ''
        ''End If ''End of "If (c_LayoutBackIsMoveable) Then"


        ''
        ''Major call!!  
        ''
        ''9/17/2019 td''LoadForm_LayoutElements()
        ''9/20/2019 td''LoadForm_LayoutElements(Me.ElementsCache_Edits)
        ''LoadForm_LayoutElements(Me.ElementsCache_Edits, mod_listOfFieldControls,
        ''      "ClassDesigner.LoadDesigner " & pstrWhyCalled)
        ''LoadForm_LayoutElements(mod_designer.ElementsCache_Edits,
        ''                        mod_listOfFieldControls,
        ''      "ClassDesigner.LoadDesigner " & pstrWhyCalled)

        ''LoadForm_LayoutElements(mod_designer.ElementsCache_Edits,
        ''                        par_listOfFieldControls,
        ''      "ClassDesignerEventListener.LoadDesigner " & par_strWhyCalled)

        ''
        ''Major call!!
        ''
        LoadForm_LayoutElements_Moveability(par_listDesignerControls)

    End Sub ''End of Public Sub LoadDesigner


    Private Sub LoadForm_LayoutElements_Moveability(par_listDesignerControls As HashSet(Of RSCMoveableControlVB))
        ''                par_cache As ClassElementsCache_Deprecated,
        ''                ByRef par_listFieldCtls As HashSet(Of CtlGraphicFldLabel),
        ''                pstrWhyCalled As String)
        ''
        ''This procedure is copied, in part, from the same-named procedure
        ''  in class ClassDesigner. 
        ''   ----11/29/2021 thomas d. 
        ''
        ''

        ''Added 10/12/2019 td 
        ''mod_sizing_portrait.Init(mod_designer.CtlGraphic_Portrait.picturePortrait,
        ''        mod_designer.CtlGraphic_Portrait, 10, True,
        ''        SizingElementEvents, False,
        ''        mod_designer.CtlGraphic_Portrait)
        ''''Added 12/1/2021 td 
        ''DictyControlResizing.Add(mod_designer.CtlGraphic_Portrait,
        ''    mod_sizing_portrait)

        ''Dec17 2021 td''mod_designer.Add_Moveability(mod_designer.CtlGraphic_Portrait)
        ''Jan10 2022 td''If (mod_designer.LetEventListenerAddMoveability) Then
        ''    ''Portrait control. 
        ''    mod_designer.Add_Moveability(mod_designer.CtlGraphic_Portrait,
        ''                             mod_designer.CtlGraphic_Portrait,
        ''                             mod_designer.CtlGraphic_Portrait, False)
        ''End If

        ''mod_sizing_QR.Init(mod_designer.CtlGraphic_QRCode.pictureQRCode,
        ''                   mod_designer.CtlGraphic_QRCode, 10, True,
        ''                   SizingElementEvents, False,
        ''                   mod_designer.CtlGraphic_QRCode)

        ''Added 12/1/2021 td 
        ''DictyControlResizing.Add(mod_designer.CtlGraphic_QRCode,
        ''   mod_sizing_QR)
        ''Jan10 2022 td''If (mod_designer.LetEventListenerAddMoveability) Then
        ''    ''Add moveability - QR Code
        ''    mod_designer.Add_Moveability(mod_designer.CtlGraphic_QRCode, mod_designer.CtlGraphic_QRCode,
        ''                             mod_designer.CtlGraphic_QRCode, True)
        ''End If ''End of ""If (mod_designer.LetEventListenerAddMoveability) Then""

        ''mod_sizing_signature.Init(mod_designer.CtlGraphic_Signat.pictureSignature,
        ''                          mod_designer.CtlGraphic_Signat, 10, True,
        ''                          SizingElementEvents, False,
        ''                          mod_designer.CtlGraphic_Signat)
        ''DictyControlResizing.Add(mod_designer.CtlGraphic_Signat,
        ''     mod_sizing_signature) ''Added 12/1/2021 td
        ''jan10 2022 td''If (mod_designer.LetEventListenerAddMoveability) Then
        ''    ''Signature control 
        ''    mod_designer.Add_Moveability(mod_designer.CtlGraphic_Signat, mod_designer.CtlGraphic_Signat,
        ''                             mod_designer.CtlGraphic_Signat, True)
        ''End If ''End of ""If (mod_designer.LetEventListenerAddMoveability) Then""

        ''Added 12/15/2021 td 
        ''mod_sizing_staticText.Init(mod_designer.CtlGraphic_StaticText1.pictureLabel,
        ''                          mod_designer.CtlGraphic_StaticText1, 10, True,
        ''                          SizingElementEvents, False,
        ''                            mod_designer.CtlGraphic_StaticText1)
        ''DictyControlResizing.Add(mod_designer.CtlGraphic_StaticText1,
        ''     mod_sizing_staticText)
        ''Jan10 2022 td''If (mod_designer.LetEventListenerAddMoveability) Then

        ''    ''Jan8 2022 td''mod_designer.Add_Moveability(mod_designer.CtlGraphic_StaticText_Temp,
        ''    ''Jan8 2022 td''                             mod_designer.CtlGraphic_StaticText_Temp,
        ''    ''Jan8 2022 td''                             mod_designer.CtlGraphic_StaticText_Temp, False)

        ''    For Each each_controlST As CtlGraphicStaticText In mod_designer.ListCtlGraphic_StaticTexts

        ''        mod_designer.Add_Moveability(each_controlST, each_controlST, each_controlST, False)

        ''    Next each_controlST

        ''End If ''End of "If (mod_designer.LetEventListenerAddMoveability) Then"

        ''Dim boolMakeMoveableByUser As Boolean ''Added 9/20/2019 td 
        ''Const c_boolMakeMoveableASAP As Boolean = False ''added 9/20/2019 td
        ''boolMakeMoveableByUser = c_boolMakeMoveableASAP ''Added 9/20/2019 td  


        ''Add moveability.   
        ''boolMakeMoveableByUser = (Not c_boolMakeMoveableASAP) ''Added 9/20/2019 td

        ''If (boolMakeMoveableByUser) Then
        ''
        ''Pretty big call!!   Allow the user to "click & drag" the control. 
        ''
        ''Jan10 2022 td''If (mod_designer.LetEventListenerAddMoveability) Then
        ''    Try
        ''        MakeElementsMoveable_Fields(par_listDesignerControls)

        ''    Catch ex_fields As Exception
        ''        ''Added 11/26/2021 thomas downes
        ''        MessageBox.Show(ex_fields.Message)
        ''        MessageBox.Show(ex_fields.ToString)
        ''    End Try
        ''End If

        ''End If ''ENd of "If (boolMakeMoveableByUser) Then


        ''
        ''Major call !!
        ''
        ''----LoadFieldControls_ByListOfElements(par_cache.ListFieldElements(),
        ''LoadFieldControls_ByListOfElements(objListBadgeElems,
        ''                                   c_boolLoadingForm,
        ''                                   False, boolMakeMoveableByUser,
        ''                                   par_listFieldCtls,
        ''                    "ClassDesigner.LoadForm_LayoutElements " & pstrWhyCalled)

        ''
        ''Major call!!
        ''
        ''//-//Redundant, see MakeElementsMoveable_Fields above.
        ''//
        ''//LoadFieldControls_ByListOfElements(par_listDesignerControls) '',
        ''//    "ClassDesigner.LoadForm_LayoutElements " & pstrWhyCalled)

    End Sub ''end of Private Sub LoadForm_LayoutElements()



    Private Sub MakeElementsMoveable_Fields(par_listDesignerControls As HashSet(Of Control))
        ''
        ''Added 11/29/2021 thomas downes  
        ''
        ''10/12/2019 td''Const c_addAfterMoveAddBreakpoint As Boolean = True

        ''8/4/2019 td''Dim boolAllowGroupMovements As Boolean = False ''True ''False ''Added 8/3/2019 td  
        ''
        ''Portrait
        ''
        ''10/9/2019 td''If (mc_boolAllowGroupMovements) Then
        ''10/9/2019 td''    ControlMove_GroupMove_TD.Init(CtlGraphicPortrait_Lady.Picture_Box,
        ''              CtlGraphicPortrait_Lady, 10, True, mod_groupedMove,
        ''              c_addAfterMoveAddBreakpoint) ''Added 8/3/2019 thomas downes
        ''
        ''10/9/2019 td''Else
        ''10/9/2019 td''    ControlMoverOrResizer_TD.Init(CtlGraphicPortrait_Lady.Picture_Box,
        ''          CtlGraphicPortrait_Lady, 10, True,
        ''           c_addAfterMoveAddBreakpoint) ''Added 7/31/2019 thomas downes
        ''10/9/2019 td''End If ''End of " If (mc_boolAllowGroupMovements) Then .... Else ...."

        ''Added 10/9/2019 thomas downes
        ''10/12/2019 td-----ControlResizeProportionally_TD.Init(CtlGraphic_Portrait.Picture_Box,
        ''---      CtlGraphic_Portrait, 10, True,
        ''---      mod_sizingPic_events, c_addAfterMoveAddBreakpoint) ''Added 10/9/2019 thomas downes

        ''Added 10/11/2019 thomas downes
        ''10/12/2019 td-----ControlMoverOrResizer_TD.Init(CtlGraphic_Signat.pictureSignature,
        ''---      CtlGraphic_Signat, 10, True,
        ''---      c_addAfterMoveAddBreakpoint)

        ''
        ''Fields
        ''
        Dim each_graphicLabel As CtlGraphicFieldV3 ''Added 7/19/2019 thomas downes  

        ''----For Each each_control As Control In Me.DesignerForm.Controls ''Added 7/19/2019 thomas downes  

        For Each each_control As Control In par_listDesignerControls

            If (TypeOf each_control Is CtlGraphicFieldV3) Then

                each_graphicLabel = CType(each_control, CtlGraphicFieldV3)

                ''7/31/2019 td''ControlMoverOrResizer_TD.Init(each_graphicLabel.Picture_Box,
                ''                each_control, 10) ''Added 7/28/2019 thomas downes

                ControlMoverResizer_AddFieldCtl(each_graphicLabel)

            End If ''End of "If (TypeOf each_control Is GraphicFieldLabel) Then"

        Next each_control

    End Sub ''End of "Private Sub MakeElementsMoveable()"


    Private Sub ControlMoverResizer_AddFieldCtl(par_graphicFieldCtl As CtlGraphicFieldV3)
        ''
        ''Encapsulated 9/7/2019 thomas d
        ''
        ''Const c_bRepaintAfterResize As Boolean = True ''Added 7/31/2019 td 

        ''Jan10 2022''If (mc_bUseNonStaticMovers And mc_boolAllowGroupMovements) Then
        ''    ''
        ''    ''Added 11/29/2021 td
        ''    ''
        ''    Dim objNonStatic As New ControlMove_Group_NonStatic
        ''    objNonStatic.Init(par_graphicFieldCtl.Picture_Box,
        ''      par_graphicFieldCtl, 10, c_bRepaintAfterResize,
        ''      mod_eventsGroupedMove, mc_boolAllowGroupMovements,
        ''      par_graphicFieldCtl)

        ''    mod_dictyControlMoveFields.Add(par_graphicFieldCtl, objNonStatic)


        ''Jan10 2022''ElseIf (mc_boolAllowGroupMovements) Then
        ''    ''
        ''    ''This is essentially deprecated as of 11/29/2021 
        ''    ''
        ''    ControlMove_GroupMove_TD.Init(par_graphicFieldCtl.Picture_Box,
        ''                  par_graphicFieldCtl, 10, c_bRepaintAfterResize,
        ''                  mod_eventsGroupedMove, mc_boolAllowGroupMovements,
        ''                  par_graphicFieldCtl) ''Added 8/3/2019 td 

        ''Else
        ''    ControlMoverOrResizer_TD.Init(par_graphicFieldCtl.Picture_Box,
        ''                  par_graphicFieldCtl, 10,
        ''                  c_bRepaintAfterResize, mc_boolBreakpoints,
        ''                  par_graphicFieldCtl) ''Added 7/28/2019 thomas downes

        ''End If ''End of "If (boolAllowGroupMovements) Then ...... Else ..."

    End Sub ''End of "Private Sub ControlMoverResizer_AddField"


    Private Sub Resizing_Start() Handles mod_eventsGroupedMove.Resizing_Start
        ''
        ''Added 8/5/2019 thomas downes  
        ''
        ''1/12/2022 td''Dim list_SelectedCtls As HashSet(Of CtlGraphicFldLabel) ''Added 11/29/2021 td
        Dim list_SelectedCtls As HashSet(Of RSCMoveableControlVB) ''Modified 1/12/2022 td
        list_SelectedCtls = mod_designer.mod_selectedCtls ''Added 11/29/2021 td

        For Each each_control As CtlGraphicFieldV3 In list_SelectedCtls ''In mod_selectedCtls

            ''Added 9/11/2019 td  
            If (m_bAddBorderOnlyWhileResizing) Then
                each_control.BorderStyle = BorderStyle.FixedSingle
            End If ''End of "If (m_boolAddBorderWhileResizing) Then"

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


    Private Sub Move_GroupMove_Continue(DeltaLeft As Integer, DeltaTop As Integer,
                                        DeltaWidth As Integer, DeltaHeight As Integer,
                                        pbLeadControlLocationWasEdited As Boolean) _
        Handles mod_eventsGroupedMove.MoveInUnison
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
        ''Jan28 2022''Dim objControlBeingMoved As Control ''Added 11/29/2021  
        ''Jan28 2022''objControlBeingMoved = mod_designer.ControlBeingMoved
        Dim objRSCControlBeingMoved As RSCMoveableControlVB ''Modified 1/28/2022  
        objRSCControlBeingMoved = CType(mod_designer.ControlBeingMoved, RSCMoveableControlVB)

        ''Jan11 2022''If (TypeOf objControlBeingMoved Is CtlGraphicFldLabel) Then

        Const c_bCheckThatControlIsGrouped As Boolean = True ''8/5/2019 thomas downes

        If (c_bCheckThatControlIsGrouped) Then ''8/5/2019 thomas downes
            ''9/9 td''bControlMovedIsInGroup = LabelsList_IsItemIncluded(ControlBeingMoved)
            ''Jan28 2022''bControlMovedIsInGroup = mod_designer
            ''Jan28 2022''    .ElementsList_IsItemIncluded(CType(objControlBeingMoved, CtlGraphicFldLabel))
            bControlMovedIsInGroup = mod_designer.ElementsList_IsItemIncluded(objRSCControlBeingMoved)

            If (Not bControlMovedIsInGroup) Then Exit Sub

        End If ''End of "If (c_bCheckThatControlIsGrouped) Then"

        ''Jan11 2022''Else
        ''    ''
        ''    ''Perhaps the Portrait is being moved.   Don't allow other things to be 
        ''    ''  moved around as well.  ---8/5/2019 td
        ''    ''
        ''    Exit Sub

        ''End If ''End of "If (TypeOf ControlBeingMoved Is CtlGraphicFldLabel) Then .... Else ...."

        ''
        ''The control being moved or resized is part of a group.   
        ''
        ''8/4/2019 td''For Each each_control As CtlGraphicFldLabel In mod_selectedCtls

        ''1/12/2022 td''Dim list_SelectedCtls As HashSet(Of CtlGraphicFldLabel) ''Added 11/29/2021 td
        Dim list_SelectedCtls As HashSet(Of RSCMoveableControlVB) ''Added 11/29/2021 td
        list_SelectedCtls = mod_designer.mod_selectedCtls ''Added 11/29/2021 td

        ''jAN 28 2022''For Each each_control As CtlGraphicFldLabel In list_SelectedCtls
        For Each each_control As RSCMoveableControlVB In list_SelectedCtls '' mod_selectedCtls

            ''Don't re-move the control being directly moved...!! 
            ''  Causes ugly screen flicker!!
            ''     --8/4/2019 td
            ''If (each_control Is Me.ControlBeingMoved) Then Continue For
            ''If (each_control Is Me.ControlBeingMoved.Parent) Then Continue For
            If (each_control Is mod_designer.ControlBeingMoved) Then Continue For
            If (each_control Is mod_designer.ControlBeingMoved.Parent) Then Continue For

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
                        ''10/14 td''.Width = (.TempResizeInfo_W + DeltaWidth)
                        ''10/14 td''.Height = (.TempResizeInfo_H + DeltaHeight)
                        .ManageResizingByUser(True, DeltaWidth, DeltaHeight, 0, 0)


                    ElseIf (bResize_LeftOrTop) Then
                        ''
                        ''Added 8/12/2019 thomas d.
                        ''
                        ''-----DIFFICULT AND CONFUSING !!!!!
                        ''    The user might want might to resize using the left edge (Or the top edge). 
                        ''
                        ''8/12/2019 TD''.Top = (.TempResizeInfo_Top + DeltaTop)
                        ''8/12/2019 TD''.Left = (.TempResizeInfo_Left + DeltaLeft)

                        ''10/14 td''.Top += DeltaTop
                        ''10/14 td''.Left += DeltaLeft
                        ''10/14 td''.Width += DeltaWidth
                        ''10/14 td''.Height += DeltaHeight
                        .ManageResizingByUser(False, DeltaWidth, DeltaHeight, DeltaTop, DeltaLeft)

                    End If ''End of "If (bResize_RightOrBottom) Then .... ElseIf (bResize_LeftOrTop) Then ..."

                End If ''End of "If (boolResizing) Then"

                ''8/5/2019 td''txtWidthDeltas.AppendText($"Width: {DeltaWidth}" & vbCrLf)
                ''8/5/2019 td''txtWidthDeltas.AppendText($"   Height: {DeltaHeight}" & vbCrLf)

            End With ''End of "With each_control"

        Next each_control

        ''
        ''Only update the preview if both "Auto Preview" and "Instant" is checked. 
        ''   ---12/6/2021 td
        ''
        mod_designer.AutoPreview_IfChecked(Nothing, True)

    End Sub ''End of "Private Sub MoveInUnison"


    Private Sub Resizing_End(par_iSave As ISaveToModel) Handles mod_eventsGroupedMove.Resizing_EndV1
        ''
        ''Added 8/5/2019 thomas downes  
        ''
        ''1/12/2022 TD''Dim list_SelectedCtls As HashSet(Of CtlGraphicFldLabel) ''Added 11/29/2021 td
        Dim list_SelectedCtls As HashSet(Of RSCMoveableControlVB) ''Modified 1/12/2022 td
        list_SelectedCtls = mod_designer.mod_selectedCtls ''Added 11/29/2021 td

        For Each each_control As CtlGraphicFieldV3 In list_SelectedCtls '' mod_selectedCtls

            ''Added 9/11/2019 td  
            ''---If (mc_bAddBorderOnlyWhileResizing) Then
            If (m_bAddBorderOnlyWhileResizing) Then
                each_control.BorderStyle = BorderStyle.None
            End If ''End of "If (mc_boolAddBorderWhileResizing) Then"

            each_control.TempResizeInfo_W = 0
            each_control.TempResizeInfo_H = 0

            ''Added 9/11/2019 td
            each_control.Refresh_ImageV3(True)

        Next each_control

        ''Added 9/11/2019 Never Forget
        ''   This is needed in case it's not a group of controls being resized, 
        ''   but just a single control. ---9/11 td 
        ''
        ''9/14/2019 td''If (mod_ElementLastTouched = mod_FieldControlLastTouched) Then

        Dim boolResizedAFieldCtl As Boolean ''Added 9/14/2019 td
        Dim ctl_ControlLastTouched As Control
        Dim ctl_FieldControlLastTouched As CtlGraphicFieldV3 = Nothing ''Added 3/30/2023

        ctl_ControlLastTouched = mod_designer.mod_ControlLastTouched

        ''Added 3/30/2023 td
        If (ctl_FieldControlLastTouched Is Nothing) Then
            Throw New NotImplementedException
        End If ''End of ""If (ctl_FieldControlLastTouched Is Nothing) Then""

        If (TypeOf mod_designer.mod_RSCControlLastTouched Is CtlGraphicFieldV3) Then
            ''We know it's a Element-Field control. ---1/12/2022 td
            ctl_FieldControlLastTouched = CType(mod_designer.mod_RSCControlLastTouched,
                   CtlGraphicFieldV3)
        End If ''End of "If (TypeOf mod_designer.mod_RSCControlLastTouched Is CtlGraphicFldLabel) Then"

        ''boolResizedAFieldCtl = (TypeOf mod_ControlLastTouched Is CtlGraphicFldLabel)
        boolResizedAFieldCtl = (TypeOf ctl_ControlLastTouched Is CtlGraphicFieldV3)

        ''10/13/2019 td''If (boolResizedAFieldCtl) Then ''Added 9/14/2019 td
        If ((Not mc_boolMoveGrowInUnison) And boolResizedAFieldCtl) Then ''Added 9/14/2019 td

            ''With mod_FieldControlLastTouched
            With ctl_FieldControlLastTouched

                If (.Rotated_0degrees) Then
                    ''.ElementInfo_Base.Width_Pixels = ctl_FieldControlLastTouched.Width
                    ''.ElementInfo_Base.Height_Pixels = ctl_FieldControlLastTouched.Height
                    .ElementInfo_Base.Width_Pixels = .Width
                    .ElementInfo_Base.Height_Pixels = .Height

                ElseIf (.Rotated_180_360) Then
                    ''.ElementInfo_Base.Width_Pixels = ctl_FieldControlLastTouched.Width
                    ''.ElementInfo_Base.Height_Pixels = ctl_FieldControlLastTouched.Height
                    .ElementInfo_Base.Width_Pixels = .Width
                    .ElementInfo_Base.Height_Pixels = .Height

                ElseIf (.Rotated_90_270(False)) Then
                    ''
                    ''---- POTENTIALLY CONFUSING -----
                    ''Switch them up !!  
                    ''.ElementInfo_Base.Width_Pixels = mod_FieldControlLastTouched.Height
                    ''.ElementInfo_Base.Height_Pixels = mod_FieldControlLastTouched.Width
                    .ElementInfo_Base.Width_Pixels = .Height
                    .ElementInfo_Base.Height_Pixels = .Width

                End If ''End of "If (.Rotated_180_360) Then"

                ''
                ''Auto-Scaling the Font Size ---6/2/2022 
                ''
                Dim bAutoscaleConfirmed As Boolean ''Added 6/02/2022 td

                ''Added 9/12/2019 td
                With .ElementInfo_TextOnly
                    If .FontSize_AutoScaleToElementYesNo Then
                        ''Change the Font Size, to account for the new Height of the Element !!
                        ''  ---9/12/2019 td 
                        ''6/2/2022 .FontSize_Pixels = CSng(ctl_FieldControlLastTouched.Height *
                        ''                                  .FontSize_ScaleToElementRatio)

                        If (.FontSize_AutoSizePromptUser) Then ''Added 6/02/2022
                            ''Added 6/02/2022
                            bAutoscaleConfirmed = (MessageBoxTD.Show_Confirm("Auto-Scale the font?  (Auto-Size)"))
                        Else
                            bAutoscaleConfirmed = .FontSize_AutoScaleToElementYesNo
                        End If ''End of"If (.FontSize_AutoSizePromptUser) Then... Else..." 

                        ''Confirmed?  If so, then 
                        If (bAutoscaleConfirmed) Then ''Added 6/02/2022
                            .FontSize_Pixels = CSng(ctl_FieldControlLastTouched.Height *
                                                    .FontSize_AutoScaleToElementRatio)
                        End If ''End of ""If (bAutoscaleConfirmed) Then""

                    End If ''End of "If .FontSize_ScaleToElementYesNo Then"
                End With ''End of "With .ElementInfo_Text"

                .Refresh_ImageV3(True)

            End With ''End of "With mod_FieldControlLastTouched"

        End If ''End of "If (mod_ElementLastTouched = mod_FieldControlLastTouched) Then"

        ''Added 9/13/2019 td 
        ''---AutoPreview_IfChecked()
        mod_designer.AutoPreview_IfChecked()

    End Sub ''End of "Private Sub Resizing_EndV1() Handles mod_groupedMove.Resizing_EndV1"


    Private Sub Resizing_EndV2(par_iSave As ISaveToModel,
                               par_iRefreshElement As IRefreshElementImage,
                               par_iRefreshCardPreview As IRefreshCardPreview,
                               par_bHeightResized As Boolean) _
        Handles mod_eventsGroupedMove.Resizing_EndV2
        ''
        ''Added 3/30/2023 Thomas Downes 
        ''
        ''  What is supposed to happen here?   Why does V2 (suffix)
        ''  of this event have all of the following parameters?
        ''
        ''      par_iSave As ISaveToModel,
        ''      par_iRefreshElement As IRefreshElementImage,
        ''      par_iRefreshCardPreview As IRefreshCardPreview,
        ''      par_bHeightResized As Boolean
        ''
        Debugger.Break()

    End Sub ''End of "" ''End of "Private Sub Resizing_EndV1() Handles mod_groupedMove.Resizing_EndV1"""




    Private Sub MovingElement_End(par_ctlElement As Control, par_iSave As ISaveToModel) _
        Handles mod_eventsGroupedMove.Moving_End

        ''12/17/2021 td''Private Sub MovingElement_End(par_ctlElement As Control) Handles mod_groupedMove.Moving_End
        ''11/29/2021 ''Private Sub MovingElement_End() Handles mod_groupedMove.Moving_End

        ''Added 8/15/2022 thomas d
        Try
            ''Added 8/15/2022 thomas d
            mod_designer.LastTouchedMoveableElement = CType(par_ctlElement, IMoveableElement)
        Catch ex_Moveable As Exception
            ''Added 8/15/2022
            System.Diagnostics.Debugger.Break()
        End Try

        ''Added 11/29/2021 thomas d. 
        If (TypeOf par_ctlElement Is PictureBox) Then
            ''Let the programmer know that the control type 
            ''  should be a custom-control, e.g. ctlGraphicLabel.
            ''  ----11/29/2021 td 
            Throw New Exception("The Element-Control is NOT supposed to be a PictureBox!")
        End If ''End of "If (TypeOf par_ctlElement Is PictureBox) Then"

        ''Added 9/13/2019 td 
        ''11/29/2021 td''AutoPreview_IfChecked()
        ''AutoPreview_IfChecked(par_ctlElement)

        ''==/==Needed? ---12/17/2021 td
        ''==par_interfaceSaveToModel.SaveToModel()

        ''5/5/2022 td ''par_iSave.SaveToModel() ''Added 12/17/2021 td  
        Const c_boolLetsHaveRedundantSaves As Boolean = False ''Added 5/5/2022 td
        If (c_boolLetsHaveRedundantSaves) Then ''Added 5/5/2022 td

            par_iSave.SaveToModel() ''Added 12/17/2021 td  

        Else
            ''Added 5/5/2022 td
            ''
            ''To avoid redundant calls to .SaveToModel, we will check to see if 
            ''  the SizingElementsEvents object is instantiated.   ---5/5/2022 td
            ''
            ''Look for "... Handles SizingElementEvents.Moving_End" to see where the 
            ''  handling will take place. ---5/5/2022 td
            ''
            If (SizingElementEvents IsNot Nothing) Then
                ''May 5, 2022 td''----We don't need to exit ("Exit Sub") since I have  
                ''May 5, 2022 td''----  commented out the other, redundant handler. ----5/5/2022 td
                ''May 5, 2022 td''--Exit Sub
            End If ''End of ""If (SizingElementEvents IsNot Nothing) Then""

        End If ''End of ""If (c_boolLetsHaveRedundantSaves) Then... Else....""

        ''
        ''Added 5/5/2022 td 
        ''
        ''  Call .SaveToModel() for the controls in the Grouped-Controls collection.
        ''   ---5/05/2022
        ''
        Dim bSameControlAsParameter As Boolean ''Added 5/5/2022 td

        For Each each_RSC As RSCMoveableControlVB In mod_designer.mod_selectedCtls

            ''Added 5/5/2022 thomas d.
            ''
            ''----DIFFICULT & CONFUSING--------
            ''
            bSameControlAsParameter = (par_iSave Is CType(each_RSC, ISaveToModel))

            If bSameControlAsParameter Then
                ''No need for redundant calls to SaveToModel(), so
                ''   as of 5/5/2022 the following If condition is False.
                If (c_boolLetsHaveRedundantSaves) Then ''Added 5/5/2022 td
                    par_iSave.SaveToModel() ''Added 12/17/2021 td  
                End If ''End of ""If (c_boolLetsHaveRedundantSaves) Then""

            Else
                ''Added 5/5/2022 
                each_RSC.SaveToModel()

            End If ''End of ""If bSameControlAsParameter Then.... Else...."

        Next each_RSC

        ''Update what the user sees (preview).
        mod_designer.AutoPreview_IfChecked(par_ctlElement)

    End Sub ''End of "Private Sub MovingElement_End(par_control As Control)"

    ''May 5, 2022 td''
    ''May 5, 2022 td''---I have commented out this redundant handler. ---5/05/2022 td
    ''May 5, 2022 td''
    ''May 5, 2022 td''''Private Sub mod_sizing_events_Moving_End(par_control As Control, par_iSave As ISaveToModel) Handles SizingElementEvents.Moving_End
    ''May 5, 2022 td''''    ''Dec17 2021    Private Sub mod_sizingPic_events_Moving_End() Handles mod_sizingEvents_Pics.Moving_End
    ''May 5, 2022 td''
    ''
    ''    ''Added 10/9/2019 td
    ''    ''12/17/2021 ''mod_designer.CtlGraphic_Portrait.SaveToModel() ''Added 12/16/2021 td 

    ''    If (par_iSave Is Nothing) Then
    ''        ''5/5/2022 td''mod_designer.CtlGraphic_Portrait.SaveToModel() ''Added 12/16/2021 td 

    ''    Else
    ''        ''5/5/2022 td ''par_iSave.SaveToModel() ''Added 12/17/2021 td  
    ''        Const c_boolLetsHaveRedundantSaves As Boolean = False ''Added 5/5/2022 td
    ''        If (c_boolLetsHaveRedundantSaves) Then ''Added 5/5/2022 td
    ''            par_iSave.SaveToModel() ''Added 12/17/2021 td  
    ''        End If ''End of ""If (c_boolLetsHaveRedundantSaves) Then""

    ''        ''
    ''        ''Added 5/5/2022 td 
    ''        ''
    ''        ''  Call .SaveToModel() for the controls in the Grouped-Controls collection.
    ''        ''   ---5/05/2022
    ''        ''
    ''        Dim bSameControlAsParameter As Boolean ''Added 5/5/2022 td
    ''        For Each each_RSC As RSCMoveableControlVB In mod_designer.mod_selectedCtls

    ''            ''Added 5/5/2022 thomas d.
    ''            ''
    ''            ''----DIFFICULT & CONFUSING--------
    ''            ''
    ''            bSameControlAsParameter = (par_iSave Is CType(each_RSC, ISaveToModel))

    ''            If bSameControlAsParameter Then
    ''                ''No need for redundant calls to SaveToModel(), so
    ''                ''   as of 5/5/2022 the following If condition is False.
    ''                If (c_boolLetsHaveRedundantSaves) Then ''Added 5/5/2022 td
    ''                    par_iSave.SaveToModel() ''Added 12/17/2021 td  
    ''                End If ''End of ""If (c_boolLetsHaveRedundantSaves) Then""

    ''            Else
    ''                ''Added 5/5/2022 
    ''                each_RSC.SaveToModel()

    ''            End If ''End of ""If bSameControlAsParameter Then.... Else...."

    ''        Next each_RSC

    ''    End If ''End of ""If (par_iSave Is Nothing) Then... Else....""

    ''    ''Update what the user sees (preview).
    ''    ''5/5/2022 td''mod_designer.AutoPreview_IfChecked()
    ''    mod_designer.AutoPreview_IfChecked(par_control)

    ''End Sub


    Private Sub mod_sizingEvents_Resizing_End(par_iSave As ISaveToModel,
                                              par_iRefreshImage As IRefreshElementImage,
                                              par_iRefreshPreview As IRefreshCardPreview,
                                              pboolHeightResized As Boolean) _
                                         Handles SizingElementEvents.Resizing_EndV2
        ''Dec12 2021 td''Handles mod_sizingEvents_Pic.Resizing_End
        ''Jan26 2022 td''Private Sub mod_sizingEvents_Resizing_End(par_iSave As ISaveToModel)

        ''Added 10/9/2019 td 
        ''Not needed. 12/17/2021 td''mod_designer.CtlGraphic_Portrait.SaveToModel() ''Added 12/16/2021 td

        par_iSave.SaveToModel() ''Added 12/172021

        ''Update what the user sees (preview).
        mod_designer.AutoPreview_IfChecked()

        ''Added 1/26/2022 td
        ''6/06/2022 par_iRefreshImage.RefreshElementImage()
        par_iRefreshImage.RefreshElementImage(pboolHeightResized)

    End Sub


    ''Private Sub mod_eventsGroupedMove_Resizing_EndV2(par_iSave As ISaveToModel, par_iRefreshElement As IRefreshElementImage, par_iRefreshCardPreview As IRefreshCardPreview, par_bHeightResized As Boolean) _
    ''    Handles mod_eventsGroupedMove.Resizing_EndV2
    ''    ''
    ''    ''Added 3/30/2023 Thomas Downes 
    ''    ''
    ''    ''  What is supposed to happen here?   Why does V2 (suffix)
    ''    ''  of this event have all of the following parameters?
    ''    ''
    ''    ''      par_iSave As ISaveToModel,
    ''    ''      par_iRefreshElement As IRefreshElementImage,
    ''    ''      par_iRefreshCardPreview As IRefreshCardPreview,
    ''    ''      par_bHeightResized As Boolean
    ''    ''
    ''    Debugger.Break()

    ''End Sub


    ''Private Sub mod_sizingQR_events_Moving_End(par_control As Control, par_iSave As ISaveToModel) Handles SizingElementEvents.Moving_End

    ''    ''Added 10/9/2019 td 
    ''    ''12/17/2021 td''mod_designer.CtlGraphic_QRCode.SaveToModel()
    ''    If (par_iSave Is Nothing) Then
    ''        mod_designer.CtlGraphic_QRCode.SaveToModel() ''Added 12/16/2021 td 
    ''    Else
    ''        par_iSave.SaveToModel() ''Added 12/17/2021 td
    ''    End If

    ''    ''Update what the user sees (preview).
    ''    mod_designer.AutoPreview_IfChecked()

    ''End Sub

    Private Sub Move_sizingEvents_Resizing_End(par_iSave As ISaveToModel)
        ''#1 12/17/21 td''Handles mod_sizingElementEvents.Resizing_End
        ''#2 12/17/21 td''Handles mod_sizing_QR_Events.Resizing_End

        ''Added 10/9/2019 td 
        ''5/15/2022 td''mod_designer.CtlGraphic_QRCode.SaveToModel() ''Added 12/16/2021 td 
        par_iSave.SaveToModel() ''Added 12/172021

        ''Update what the user sees (preview).
        mod_designer.AutoPreview_IfChecked()

    End Sub

    ''Private Sub Move_sizingSig_events_Moving_End(par_control As Control, par_iSave As ISaveToModel) Handles SizingElementEvents.Moving_End
    ''    ''12/17/2021 td''Handles mod_sizingEvents_Sig.Moving_End 

    ''    ''Added 10/9/2019 td 
    ''    ''12/17/2021 ''mod_designer.CtlGraphic_Signat.SaveToModel() ''Added 12/11/2021 td 
    ''    If (par_iSave Is Nothing) Then
    ''        mod_designer.CtlGraphic_QRCode.SaveToModel() ''Added 12/16/2021 td 
    ''    Else
    ''        par_iSave.SaveToModel() ''Added 12/17/2021 td
    ''    End If
    ''
    ''    ''Update what the user sees (preview).
    ''    mod_designer.AutoPreview_IfChecked()
    ''
    ''End Sub

    Private Sub Move_sizingSig_events_Resizing_End() ''12/17/2021''Handles mod_sizingEvents_Sig.Resizing_End

        ''Added 10/9/2019 td 
        ''5/15/2022 td ''mod_designer.CtlGraphic_Signat.SaveToModel() ''Added 12/16/2021 td 
        mod_designer.AutoPreview_IfChecked()

    End Sub

    Private Sub Move_sizing_events_MoveInUnison(deltaLeft As Integer, deltaTop As Integer,
                                                deltaWidth As Integer, deltaHeight As Integer,
                           pbLeadControlLocationWasEdited As Boolean) _
                           Handles SizingElementEvents.MoveInUnison

        ''12/17/2021 td''Private Sub mod_sizingPic_events_MoveInUnison
        ''12/17/2021 td''   Handles mod_sizingEvents_Pics.MoveInUnison

        ''Added 10/10/2019 td
        ''Dec17 2021 td''mod_designer.AutoPreview_IfChecked(True)
        mod_designer.AutoPreview_IfChecked(Nothing, True)

    End Sub

    Private Sub mod_sizingQR_events_MoveInUnison(deltaLeft As Integer, deltaTop As Integer, deltaWidth As Integer, deltaHeight As Integer) ''12/17 ''Handles mod_sizingElementEvents.MoveInUnison
        ''12/17/2021 td''Private Sub mod_sizingQR_events_MoveInUnison
        ''12/17/2021 td''   Handles mod_sizingEvents_QR.MoveInUnison

        ''Added 10/10/2019 td
        ''Dec17 2021 td''mod_designer.AutoPreview_IfChecked()
        mod_designer.AutoPreview_IfChecked(Nothing, True)

    End Sub

    Private Sub mod_sizingSig_events_MoveInUnison(deltaLeft As Integer, deltaTop As Integer, deltaWidth As Integer, deltaHeight As Integer) ''12/17 td''Handles mod_sizingEvents_Sig.MoveInUnison
        ''12/17/2021 td''Handles mod_sizingEvents_Sig.MoveInUnison

        ''Added 10/10/2019 td
        ''Dec17 2021 td''mod_designer.AutoPreview_IfChecked()
        mod_designer.AutoPreview_IfChecked(Nothing, True)

    End Sub

    Private Sub mod_groupedMove_Moving_InProgress(par_control As Control) Handles mod_eventsGroupedMove.Moving_InProgress
        ''
        ''Added 12/6/2021 thomas downes 
        ''
        ''Added 10/10/2019 td
        mod_designer.AutoPreview_IfChecked(Nothing, True)

    End Sub


    Private Sub mod_ControlIsMoving() Handles mod_eventsGroupedMove.ControlIsMoving
        ''
        ''Added 12/6/2021 thomas downes 
        ''
        ''Added 10/10/2019 td
        mod_designer.AutoPreview_IfChecked(Nothing, True)

    End Sub


    Private Sub mod_ControlBeingMoved() ''Dec.6, 2021''Handles mod_groupedMove.ControlBeingMoved
        ''
        ''Added 12/6/2021 thomas downes 
        ''
        ''See Public Sub New for the "AddressOf mod_ControlBeingMoved" statement. ---12/6/2021 td 
        ''
        ''Added 10/10/2019 td
        mod_designer.AutoPreview_IfChecked(Nothing, True)

    End Sub


    Private Sub mod_eventsGroupedMove_ControlWasClicked(par_control As Control) Handles mod_eventsGroupedMove.ControlWasClicked
        ''
        ''Added 9/01/2022 thomas downes
        ''
        mod_designer.LastControlTouchedRSC =
            CType(par_control, RSCMoveableControlVB)

        ''Added 9/02/2022 thomas downes
        mod_designer.PositionElementArrow(par_control)

    End Sub


    Private Sub mod_Group_MouseUpCtrlKey(par_control As Control) Handles mod_eventsGroupedMove.MouseUpCtrlKey
        ''
        ''Added 1/09/2023 thomas downes
        ''
        mod_designer.SelectControlCtrlKey(par_control)

    End Sub


    Private Sub mod_Group_MouseUpShiftKey(par_control As Control) Handles mod_eventsGroupedMove.MouseUpShiftKey
        ''
        ''Added 1/09/2023 thomas downes
        ''
        ''3/30/2023 Throw New NotImplementedException("No.")
        mod_designer.SelectControlShiftKey(par_control)

    End Sub

    Private Sub mod_eventsGroupedMove_Resizing_EndV2(par_iSave As ISaveToModel, par_iRefreshElement As IRefreshElementImage, par_iRefreshCardPreview As IRefreshCardPreview, par_bHeightResized As Boolean) Handles mod_eventsGroupedMove.Resizing_EndV2
        ''
        ''Added 3/30/2023 Thomas Downes 
        ''
        ''  What is supposed to happen here?   Why does V2 (suffix)
        ''  of this event have all of the following parameters?
        ''
        ''      par_iSave As ISaveToModel,
        ''      par_iRefreshElement As IRefreshElementImage,
        ''      par_iRefreshCardPreview As IRefreshCardPreview,
        ''      par_bHeightResized As Boolean
        ''
        Debugger.Break()

    End Sub


    ''Private Sub LoadFieldControls_ByListOfElements(par_listDesignerControls As HashSet(Of Control)) '',
    ''    ''           Optional pstrWhyCalled As String = "")
    ''    ''
    ''    ''This procedure is currently thought to be largely redundant. 
    ''    ''   ---11/29/2021 td
    ''    ''
    ''    ''Added 11/29/2021 thomas downes 
    ''    ''
    ''    ''This procedure is copied, in part, from the same-named procedure
    ''    ''  in class ClassDesigner. 
    ''    ''   ----11/29/2021 thomas d. 
    ''    ''
    ''    ''Dim intCountControlsAdded As Integer = 0 ''Added 9/03/2019 td 
    ''    ''Dim boolIncludeOnBadge As Boolean = False ''Added 9/03/2019 td
    ''    ''Dim intStagger As Integer = 0 ''Added 9.6.2019 td 
    ''    ''Dim intUndeterminedField As Integer = 0 ''Added 10/13/2019 td  
    ''    Dim each_label_control As CtlGraphicFldLabel

    ''    ''9/17/2019 td''For Each each_field As ICIBFieldStandardOrCustom In par_list  
    ''    For Each each_control As Control In par_listDesignerControls

    ''        ''Added 9/8/2019 td
    ''        If (TypeOf each_control Is CtlGraphicFldLabel) Then

    ''            each_label_control = CType(each_control, CtlGraphicFldLabel)

    ''            ''---If (par_bAddMoveability) Then ControlMoverResizer_AddFieldCtl(each_label_control)

    ''            ControlMoverResizer_AddFieldCtl(each_label_control)

    ''        End If ''End of "If (TypeOf each_control Is CtlGraphicFldLabel) Then"

    ''    Next each_control

    ''End Sub ''End of "Private Sub LoadFieldControls_ByListOfElements"


End Class
