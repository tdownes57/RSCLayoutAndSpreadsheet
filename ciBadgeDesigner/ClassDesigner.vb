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
''Imports MoveAndResizeControls_Monem ''Added 10/3/2019 td
''Imports ciBadgeGenerator ''Added 10/5/2019 thomas d. 
Imports ciBadgeCachePersonality ''Added 12/4/2021 thomas d. 
Imports System.IO ''Added 12/3/2021 thomas d.
Imports __RSCWindowsControlLibrary ''Added 1/02/2022 thomas d. 
Imports ciBadgeSerialize ''Added 6/07/2022 thomas downes

''10/1/2019 td''Public Event ElementField_Clicked(par_elementField As ClassElementField)

Public Class ClassDesigner
    Implements ILayoutFunctions, ISelectingElements, IRecordElementLastTouched, IRefreshCardPreview
    Implements ILastControlTouchedRSC ''Added 1/2/2022 td 
    ''
    ''Added 10/1/2019 thomas downes 
    ''
    Public Event ElementFieldRightClicked(par_control As CtlGraphicFieldV3) ''Added 10/1/2019 td
    Public Event ElementPortraitRightClicked(par_control As CtlGraphicPortrait) ''Added 12/22/2021 td
    Public Event ElementQRCodeRightClicked(par_control As CtlGraphicQRCode) ''Added 12/15/2021 td
    Public Event ElementSignatRightClicked(par_control As CtlGraphicSignature) ''Added 12/15/2021 td
    Public Event ElementStaticTextRightClicked(par_control As CtlGraphicStaticTextV3) ''Added 12/15/2021 td
    Public Event BackgroundRightClicked(par_mouse_x As Integer, par_mouse_y As Integer) ''Added 10/15/2019 td
    Public Event RSC_RightClicked(par_RSC As RSCMoveableControlVB, par_mouse_x As Integer, par_mouse_y As Integer) ''Added 10/15/2019 td

    ''10/1/2019 td''Public Property LayoutFunctions As ILayoutFunctions
    ''10/4/2019 td''Public Property DesignerForm As Form
    ''10/4/2019 td''Public Property BackgroundBox As PictureBox
    Public WithEvents DesignerForm As Form
    Public DesignerForm_DoubleCheckRef As Form
    Public WithEvents BackgroundBox_Front As PictureBox
    Public WithEvents BackgroundBox_Backside As PictureBox ''Added 12/10/2021 thomas downes
    Public BackgroundBox_JustAButton As PictureBox ''Added 1/21/2022 thomas downes
    Public DontAutoRefreshPreview As Boolean ''Added 3/11/2022 td

    ''Added 11/29/2021 thomas downes
    Private mod_designerListener As ClassDesignerEventListener
    Public LetEventListenerAddMoveability As Boolean = False ''1/5/2022 td''True ''Added 12/23/2021 td  
    Public LetBaseControlAddMoveability As Boolean = True ''True. See __RSC WindowsControlLibrary\RSCMoveableControlVB.  ---Added 1/05/2022 td  
    Public StartWithBacksideOfCard As Boolean ''Added 1/26/2022 td

    ''Added 12/8/2021 thomas downes
    ''---Private mod_enumSideOfCard As EnumWhichSideOfCard = EnumWhichSideOfCard.EnumFrontside ''Added 12/8/2021 Thomas downes  
    Public EnumSideOfCard_Current As EnumWhichSideOfCard = EnumWhichSideOfCard.EnumFrontside ''Added 12/8/2021 Thomas downes  

    Public Property PreviewLayoutAsImage As Boolean = True ''Added 10.1.2019 thomas d. 
    Public BadgeLayout_Class As ciBadgeInterfaces.BadgeLayoutDimensionsClass ''Added 10/9/2019 td  
    Private mod_ctlLasttouched As New ClassLastControlTouched ''Added 1/4/2022 td

    ''Use an instance of ClassDesigner instead!!!!! ---1/4/2022 td 
    ''----Jan6 2022---Private mod_iRecLastTouched_UseDesignerInstead As New ClassRecordElementLastTouched_Deprecated ''Added 1/4/2022 td
    Private Const mod_bAddHandlersForRightClick As Boolean = False ''Added 1/5/2022 td

    ''10/4/2019 td''Public Property PreviewBox As PictureBox
    Public WithEvents PreviewBox As PictureBox

    Public CheckboxAutoPreview As CheckBox ''Added 10/1/2019 td
    Public CheckboxInstantPreview As CheckBox ''Added 12/6/2021 td
    Public DesignerForm_Interface As IDesignerForm ''Added 10/13/2019 td  

    Public Property ExampleImage_Portrait As Image ''Added 10/1/2019 td 
    Public Property ExampleImage_QRCode As Image ''Added 10/10/2019 td 
    Public Property ExampleImage_Signature As Image ''Added 10/10/2019 td 

    Public Property FlowFieldsNotListed As FlowLayoutPanel ''Added 10/1/2019 td
    Public Property StatusLabelWarningLabel As ToolStripStatusLabel ''Added 12/22/2021 td


    Public Property PathToSigFile As String ''Added 10/12/2019 td

    ''5/15/2022 Public Property CtlGraphic_Portrait 
    ''5/15/2022 Public Property CtlGraphic_Signat_1st As CtlGraphicSignature ''Deprecated 5/15/2022 Added 10/10/2019 td
    ''5/15/2022 Public Property CtlGraphic_QRCode_1st As CtlGraphicQRCode ''Deprecated 5/15/2022 Added 10/10/2019 td

    Public Function CtlGraphic_Portrait_1st() As CtlGraphicPortrait
        ''5/15/2022 Public Property CtlGraphic_Portrait 

        ''---Return Me.ElementsCache_UseEdits.ListOfElementPics_Front.FirstOrDefault
        For Each each_ctl As RSCMoveableControlVB In mod_listOfDesignerControls
            If (TypeOf each_ctl Is CtlGraphicPortrait) Then
                Return CType(each_ctl, CtlGraphicPortrait)
            End If ''End of ""If (TypeOf each_ctl Is ClassElementPortrait) Then""
        Next each_ctl

    End Function ''End of ""Public Function CtlGraphic_Portrait_1st()""

    Public Function CtlGraphic_Signat_1st() As CtlGraphicSignature
        ''5/15/2022 Public Property CtlGraphic_Signat_1st As CtlGraphicSignature ''Deprecated 5/15/2022 Added 10/10/2019 td

    End Function ''End of ""Public Function CtlGraphic_Signat_1st()""

    Public Function CtlGraphic_QRCode_1st() As CtlGraphicQRCode
        ''5/15/2022 Public Property CtlGraphic_QRCode_1st As CtlGraphicQRCode ''Deprecated 5/15/2022 Added 10/10/2019 td

    End Function ''End of ""Public Function CtlGraphic_QRCode_1st()""


    ''Added 5/12/2022
    Public Function CtlGraphic_Portrait_List() As List(Of CtlGraphicPortrait)
        ''Added 5/15/2022 td
    End Function
    Public Function CtlGraphic_Signat_List() As List(Of CtlGraphicSignature)
        ''Added 5/15/2022 
    End Function
    Public Function CtlGraphic_QRCode_List() As List(Of CtlGraphicQRCode)
        ''Added 5/15/2022 
    End Function


    ''Jan7 2022 td''Public Property CtlGraphic_StaticText_temp As CtlGraphicStaticText ''Added 11/29/2019 td
    Public Property ListCtlGraphic_StaticTextsV3 As New HashSet(Of CtlGraphicStaticTextV3) ''Added 12/18/2021 td
    Public Property ListCtlGraphic_StaticTextsV4 As New HashSet(Of CtlGraphicStaticTextV4) ''Added 1/31/2022 td


    ''Dec14 2021''Public Property ElementsCache_Saved As New ClassElementsCache_Deprecated ''Added 9/16/2019 thomas downes
    Public Property ElementsCache_UseEdits As ClassElementsCache_Deprecated ''Added 9/16/2019 thomas downes
    Public Property ElementsCache_Manager As ClassCacheManagement ''Added 12/14/2021 td

    ''----Public Property ControlMoverOrResizer_TD As New MoveAndResizeControls_Monem.ControlMoverOrResizer_TD ''Added 10/1/2019 td
    ''----Public Property ControlMove_GroupMove_TD As New MoveAndResizeControls_Monem.ControlMove_GroupMove_TD ''Added 10/1/2019 td

    Public Property Initial_Pic_Left As Integer
    Public Property Initial_Pic_Top As Integer
    Public Property Initial_Pic_Width As Integer = 150 ''Default value added 10/1/2019 thomas downes
    Public Property Initial_Pic_Height As Integer = 182 ''Default value added 10/1/2019 thomas downes

    Public Property Initial_QR_Left As Integer
    Public Property Initial_QR_Top As Integer
    Public Property Initial_QR_Width As Integer = 100 ''Default value added 10/10/2019 thomas downes
    Public Property Initial_QR_Height As Integer = 100 ''Default value added 10/10/2019 thomas downes

    Public Property Initial_Sig_Left As Integer
    Public Property Initial_Sig_Top As Integer
    Public Property Initial_Sig_Width As Integer = 314 ''Default value added 10/10/2019 thomas downes
    Public Property Initial_Sig_Height As Integer = 100 ''Default value added 10/10/2019 thomas downes

    Public Property Initial_Text_Left As Integer
    Public Property Initial_Text_Top As Integer
    Public Property Initial_Text_Width As Integer = 350 ''Default value added 10/1/2019 thomas downes
    Public Property Initial_Text_Height As Integer = 30 ''Default value added 10/1/2019 thomas downes

    ''10/17/2019 td''Private mod_selectedCtls As New List(Of CtlGraphicFldLabel)   ''Added 8/03/2019 thomas downes 
    ''1/12/2022 td''Public mod_selectedCtls As New HashSet(Of CtlGraphicFldLabel)   ''Publicized 11/29/2021 ''Added 8/03/2019 thomas downes 
    Public mod_selectedCtls As New HashSet(Of RSCMoveableControlVB)   ''Modified 1/12/2022 td

    ''1/12/2022 TD''Public mod_FieldControlLastTouched As CtlGraphicFldLabel  ''Publicized 11/29/2021 ''Added 8/09/2019 thomas downes 
    Public mod_RSCControlLastTouched As RSCMoveableControlVB  ''Modified 1/12/2021 thomas downes 

    ''11/29/2012 ''Private mod_ControlLastTouched As Control ''Added 8/12/2019 thomas d. 
    Public mod_ControlLastTouched As Control ''Publicized 11/29/2021 td''Added 8/12/2019 thomas d. 

    Private WithEvents mod_oGroupMoveEvents As GroupMoveEvents_Singleton ''Added 1/4/2022 thomas d.
    ''Jan2 2022''Public mod_IControlLastTouched As New ClassLastControlTouched ''Added 1/02/2021 thomas d. 
    ''Jan2 2022''Private mod_ElementLastTouched As Control ''Let's change this to IElement_Base soon. ---Added 9/14/2019 td 
    Private mod_ElementLastTouched As RSCMoveableControlVB ''Modified 1/12/2021 td 

    Private mod_IMoveableElementLastTouched As IMoveableElement ''Added 12/21/2021 td
    Private mod_ISaveableElementLastTouched As ISaveToModel ''Added 12/21/2021 td
    Private Const mc_bAddBorderOnlyWhileResizing As Boolean = True ''Added 9/11/2019 thomas d. 
    Private Const mc_CheckBackgroundProportions As Boolean = False ''Was true "de facto". 5/23/2022 

    ''#1 8-3-2019 td''Private WithEvents mod_moveAndResizeCtls_NA As New MoveAndResizeControls_Monem.ControlMove_RaiseEvents ''Added 8/3/2019 td  
    '' #2 8-3-2019 td''Private WithEvents mod_moveAndResizeCtls As New MoveAndResizeControls_Monem.ControlMove_GroupMove ''Added 8/3/2019 td  
    ''#1 10/1/2019 td''Private WithEvents mod_groupedMove As New ClassGroupMove(Me) ''8/4/2019 td''New ClassGroupMove
    '' #2 10/1/2019 td''Private WithEvents mod_groupedMove As New ClassGroupMove(Me.LayoutFunctions) ''8/4/2019 td''New ClassGroupMove
    ''Private WithEvents mod_groupedMove As New ClassGroupMoveEvents(Me) ''8/4/2019 td''New ClassGroupMove

    ''Private WithEvents mod_sizingEvents_Pics As New ClassGroupMoveEvents(Me) ''Added 10/9/2019 td  
    ''Private WithEvents mod_sizingEvents_QR As New ClassGroupMoveEvents(Me) ''Added 10/12/2019 td  
    ''Private WithEvents mod_sizingEvents_Sig As New ClassGroupMoveEvents(Me) ''Added 10/12/2019 td  

    ''Private Const mc_boolAllowGroupMovements As Boolean = True ''False ''True ''False ''Added 8/3/2019 td  
    ''Private Const mc_boolBreakpoints As Boolean = True
    Private Const mc_boolMoveGrowInUnison As Boolean = True ''Added 10/10/2019 td 

    ''''Added 10/12/2019 td 
    ''Private mod_sizing_portrait As New ControlResizeProportionally_TD
    ''Private mod_sizing_signature As New ControlResizeProportionally_TD
    ''Private mod_sizing_QR As New ControlResizeProportionally_TD

    ''Added 10/10 & 8/18/2019 td
    Private mod_imageExamplePortrait As Image ''8/18/2019 td'' = CtlGraphicPortrait_Lady.picturePortrait.Image
    Private mod_imageExampleQRCode As Image ''Added 10/10/2019 td
    Private mod_imageExampleSignat As Image ''Added 10/10/2019 td

    ''Added 9/8/2019 td
    Private mod_rubberbandClass As ClassRubberbandSelector

    ''Added 9/20/2019 td  
    ''10/17/2019 td''Private mod_listOfFieldControls As New List(Of CtlGraphicFldLabel)
    Private mod_listOfFieldControlsV3 As New HashSet(Of CtlGraphicFieldV3)
    Private mod_listOfFieldControlsV4 As New HashSet(Of CtlGraphicFieldV4) ''Added 2/10/2022 td

    ''Feb1 2022 td''Private mod_listOfTextControls As New HashSet(Of CtlGraphicStaticText) ''Added Jan8 2022 td
    Private mod_listOfTextControlsV3 As New HashSet(Of CtlGraphicStaticTextV3) ''Added Jan8 2022 td
    Private mod_listOfTextControlsV4 As New HashSet(Of CtlGraphicStaticTextV4) ''Added Feb1 2022 td
    Private mod_listOfGraphicControls As New HashSet(Of CtlGraphicStaticGraphic) ''Added Jan8 2022 td

    ''Added 11/28/2021 thomas downes
    ''   Let's keep track of every control created by this object (Of ClassDesigner). 
    ''
    ''1/12/2022 td''Private mod_listOfDesignerControls As New HashSet(Of Control)
    Private mod_listOfDesignerControls As New HashSet(Of RSCMoveableControlVB)

    ''Added 11/29/2021 td  
    ''Private Const mc_bUseNonStaticMovers As Boolean = True ''Added 11/29/2021 td 
    ''Private mod_dictyControlMoveFields As New Dictionary(Of CtlGraphicFldLabel, ControlMove_Group_NonStatic)
    ''Private mod_dictyControlMoveBoxesEtc As New Dictionary(Of Control, ControlMove_NonStatic_TD)

    Private vbCrLf_Deux As String = (vbCrLf & vbCrLf)
    Private mod_bMessageRedux1 As Boolean ''Added 12/02/2021 thomas downes

    Public ReadOnly Property GroupMoveEvents() As GroupMoveEvents_Singleton
        Get
            ''Added 3/21/2022 thomas d.
            Return mod_oGroupMoveEvents
        End Get
    End Property

    Public ReadOnly Property ControlLastTouched() As ClassLastControlTouched
        Get
            ''Added 3/21/2022 thomas d.
            Return mod_ctlLasttouched
        End Get
    End Property


    Public Function ShowingTheBackside() As Boolean
        ''Added 12/10/2021 td
        Return (EnumSideOfCard_Current = EnumWhichSideOfCard.EnumBackside)
    End Function


    Public Function ListOfFieldLabelsV3() As HashSet(Of CtlGraphicFieldV3)
        ''10/17/2019 td''Public Function ListOfFieldLabels() As List(Of CtlGraphicFldLabel)
        ''Added 10/13/2019 thomas downes
        Return mod_listOfFieldControlsV3

    End Function ''End of "Public Function ListOfFieldLabelsV3() As List(Of CtlGraphicFieldV3)"


    Public Function ListOfFieldLabelsV4() As HashSet(Of CtlGraphicFieldV4)
        ''Added 2/10/2022 thomas downes
        Return mod_listOfFieldControlsV4

    End Function ''End of "Public Function ListOfFieldLabelsV4() As List(Of CtlGraphicFieldV4)"


    Public Sub UnloadDesigner(pboolResetToFrontOfCard As Boolean,
                      Optional pbIncludePortrait As Boolean = True)
        ''
        ''Added 11/28/2021 Thomas Downes
        ''
        Dim listFormControls As Control.ControlCollection
        listFormControls = Me.DesignerForm.Controls

        Dim intFormControlCount As Integer
        intFormControlCount = listFormControls.Count ''Initialize. 
        Dim bConfirmDeleted As Boolean '' = False
        Dim bRemovalHadToBeDoneThisPass As Boolean

        ''Added 11/30/2021 td
        ''CtlGraphicQRCode.RemoveHandler
        ''RemoveHandler CtlGraphic_QRCode.Picture_Box.MouseDown,
        ''    AddressOf mod_designerListener.mod_dictyControlMoveBoxesEtc(CtlGraphic_QRCode).
        ''---Dim objListenerQR As MoveAndResizeControls_Monem.ControlMove_NonStatic_TD
        ''Dim objListenerQR As MoveAndResizeControls_Monem.ControlResizeProportionally_TD

        ''''---objListenerQR = mod_designerListener.mod_dictyControlMoveBoxesEtc(CtlGraphic_QRCode)
        ''objListenerQR = mod_designerListener.mod_dictyControlResizing(CtlGraphic_QRCode)
        ''objListenerQR.RemoveEventHandlers()
        ''CtlGraphic_QRCode.Dispose() ''Added Dec. 8, 2021
        ''Me.DesignerForm.Controls.Remove(CtlGraphic_QRCode) ''Added Dec. 8, 2021
        ''mod_listOfDesignerControls.Remove(CtlGraphic_QRCode) ''Added Dec. 8, 2021

        ''Added 1/14/2022 td
        If (pbIncludePortrait) Then
            UnloadDesigner_Portrait()
        End If ''End of "If (pbIncludePortrait) Then"

        ''Encapsulated 12/14/2021 td
        UnloadDesigner_QRCode()
        UnloadDesigner_Signature()
        UnloadDesigner_StaticTexts()

        ''Added 1/21/2022 td
        ''  Must be done, otherwise we will have trouble with the right-click menu,
        ''  in particuler the "Remove Element" and "Switch Element to the Other Side"
        ''  options. ---1/21/2022 td
        ClassListOfElements.UnloadListReferences()

        ''
        ''Address the controls that are contained in mod_listOfDesignerControls.
        ''
        For intPassthroughIndex As Integer = 1 To 2
            ''
            ''Run this loop twice, for good measure!! 
            ''
            bRemovalHadToBeDoneThisPass = False ''Refresh.

            For Each eachCtl As Control In mod_listOfDesignerControls
                ''Shut down the control (created by this designer object)
                ''   and, finally, remove it from the parent form.
                eachCtl.Visible = False
                eachCtl.Dispose()
                If (listFormControls.Contains(eachCtl)) Then
                    bRemovalHadToBeDoneThisPass = True
                    Me.DesignerForm.Controls.Remove(eachCtl)
                    bConfirmDeleted = (listFormControls.Count = (-1 + intFormControlCount))
                    If (Not bConfirmDeleted) Then Throw New Exception("Should be 1 less.")
                End If ''End of "If (listFormControls.Contains(eachCtl)) Then"

                ''Prepare for next iteration.
                intFormControlCount = (listFormControls.Count)
            Next eachCtl
        Next intPassthroughIndex

        ''Added 11/28/2021 td
        Dim bRemovalWorkCompletedAtFirstPass As Boolean
        bRemovalWorkCompletedAtFirstPass = (Not bRemovalHadToBeDoneThisPass)
        If (bRemovalWorkCompletedAtFirstPass) Then
            mod_listOfDesignerControls.Clear()
        Else
            MessageBox.Show("Unfortunately, it's not clear that the designer has fully unloaded.")
        End If ''End of "If (bRemovalWorkCompletedAtFirstPass) Then"

        FlowFieldsNotListed.Controls.Clear()

        ''Clear the background of the badge. 
        ''  If (Me.BackgroundBox_Front.BackgroundImage IsNot Nothing) Then Me.BackgroundBox_Front.BackgroundImage.Dispose()
        ''  Me.BackgroundBox_Front.BackgroundImage = Nothing
        ''  If (Me.BackgroundBox_Front.Image IsNot Nothing) Then Me.BackgroundBox_Front.Image.Dispose()
        ''  Me.BackgroundBox_Front.Image = Nothing
        ''  Me.BackgroundBox_Front.Refresh()

        ''Added 12/12/2021 td
        ''  Clear the background of the badge--front & back sides. 
        Dim objPictureBox As PictureBox
        For Each objPictureBox In New PictureBox() {Me.BackgroundBox_Front, Me.BackgroundBox_Backside}
            If (objPictureBox.BackgroundImage IsNot Nothing) Then objPictureBox.BackgroundImage.Dispose()
            objPictureBox.BackgroundImage = Nothing
            If (objPictureBox.Image IsNot Nothing) Then objPictureBox.Image.Dispose()
            objPictureBox.Image = Nothing
            objPictureBox.Refresh()
        Next objPictureBox

        ''Added 12/10/2021 td
        ''  Go back to the front side of the card. 
        ''
        If (pboolResetToFrontOfCard) Then
            EnumSideOfCard_Current = EnumWhichSideOfCard.EnumFrontside
        End If ''End of "If (pboolResetToFrontOfCard) Then"

    End Sub ''End of "Public Sub UnloadDesigner__()"


    Public Sub UnloadDesigner_Portrait()
        ''
        ''Added 1/14/2021 td 
        ''
        If (CtlGraphic_Portrait_1st() IsNot Nothing) Then
            ''May 15, 2022 ''CtlGraphic_Portrait_Deprecated.Dispose() ''Added Dec. 8, 2021
            ''May 15, 2022 ''Me.DesignerForm.Controls.Remove(CtlGraphic_Portrait_Deprecated) ''Added Dec. 8, 2021
            ''May 15, 2022 ''mod_listOfDesignerControls.Remove(CtlGraphic_Portrait_Deprecated) ''Added Dec. 8, 2021
        End If ''End of "If (CtlGraphic_Portrait_1st() IsNot Nothing) Then"

        ''Added 5/15/2022
        Dim each_control As Control
        Dim each_ctlPortrait As CtlGraphicPortrait
        For Each each_control In Me.DesignerForm.Controls
            If (TypeOf each_control Is CtlGraphicPortrait) Then
                Me.DesignerForm.Controls.Remove(each_control)
                each_ctlPortrait = CType(each_control, CtlGraphicPortrait)
                mod_listOfDesignerControls.Remove(each_ctlPortrait)
            End If ''End of ""If (TypeOf each_control Is ....) Then"
        Next each_control

        ''Added 5/15/2022
        If (Me.CtlGraphic_Portrait_List IsNot Nothing) Then
            For Each each_ctl_portrait As CtlGraphicPortrait In Me.CtlGraphic_Portrait_List
                If (each_ctl_portrait IsNot Nothing) Then ''Added 1/24/2022 td
                    each_ctl_portrait.Dispose() ''Added Dec. 8, 2021
                    Me.DesignerForm.Controls.Remove(each_ctl_portrait) ''Added Dec. 8, 2021
                    mod_listOfDesignerControls.Remove(each_ctl_portrait) ''Added Dec. 8, 2021
                End If ''End of "If (CtlGraphic_QRCode IsNot Nothing) Then"
            Next each_ctl_portrait
        End If ''End of ""If (Me.CtlGraphic_Portrait_List IsNot Nothing) Then""

    End Sub ''End of "Public Sub UnloadDesigner_Portrait()"


    Public Sub UnloadDesigner_QRCode()
        ''
        ''Encapsulated 12/14/2021 td 
        ''
        ''Added 11/30/2021 td
        ''CtlGraphicQRCode.RemoveHandler
        ''RemoveHandler CtlGraphic_QRCode.Picture_Box.MouseDown,
        ''    AddressOf mod_designerListener.mod_dictyControlMoveBoxesEtc(CtlGraphic_QRCode).
        ''---Dim objListenerQR As MoveAndResizeControls_Monem.ControlMove_NonStatic_TD
        ''Jan11 2022 td''Dim objListenerQR As MoveAndResizeControls_Monem.ControlResizeProportionally_TD

        ''Dim intCountKeys As Integer ''Added 12/18/2021

        ''Jan11 2022 td''With mod_designerListener

        ''    intCountKeys = .DictyControlResizing.Keys.Count ''Added 12/18/2021
        ''    ''---objListenerQR = .mod_dictyControlMoveBoxesEtc(CtlGraphic_QRCode)
        ''    If (.DictyControlResizing.ContainsKey(CtlGraphic_QRCode)) Then
        ''        objListenerQR = .DictyControlResizing(CtlGraphic_QRCode)
        ''        objListenerQR.RemoveEventHandlers()
        ''        .DictyControlResizing.Remove(CtlGraphic_QRCode) ''Added 12/17/2021 td
        ''    End If ''End of "If (.DictyControlResizing.ContainsKey(CtlGraphic_QRCode)) Then"
        ''End With ''End of "With mod_designerListener"

        ''If (CtlGraphic_QRCode_Deprecated IsNot Nothing) Then ''Added 1/24/2022 td
        ''    CtlGraphic_QRCode_Deprecated.Dispose() ''Added Dec. 8, 2021
        ''    Me.DesignerForm.Controls.Remove(CtlGraphic_QRCode_Deprecated) ''Added Dec. 8, 2021
        ''    mod_listOfDesignerControls.Remove(CtlGraphic_QRCode_Deprecated) ''Added Dec. 8, 2021
        ''End If ''End of "If (CtlGraphic_QRCode IsNot Nothing) Then"

        ''Added 5/15/2022
        Dim each_control As Control
        Dim each_ctlQRCode As CtlGraphicQRCode
        For Each each_control In Me.DesignerForm.Controls
            If (TypeOf each_control Is CtlGraphicQRCode) Then
                Me.DesignerForm.Controls.Remove(each_control)
                each_ctlQRCode = CType(each_control, CtlGraphicQRCode)
                mod_listOfDesignerControls.Remove(each_ctlQRCode)
            End If ''End of ""If (TypeOf each_control Is ....) Then"
        Next each_control

        ''Added 5/13/2022
        If (Me.CtlGraphic_QRCode_List IsNot Nothing) Then
            For Each each_ctl_qrcode As CtlGraphicQRCode In Me.CtlGraphic_QRCode_List
                If (each_ctl_qrcode IsNot Nothing) Then ''Added 1/24/2022 td
                    each_ctl_qrcode.Dispose() ''Added Dec. 8, 2021
                    Me.DesignerForm.Controls.Remove(each_ctl_qrcode) ''Added Dec. 8, 2021
                    mod_listOfDesignerControls.Remove(each_ctl_qrcode) ''Added Dec. 8, 2021
                End If ''End of "If (CtlGraphic_QRCode IsNot Nothing) Then"
            Next each_ctl_qrcode
        End If ''End of ""If (Me.CtlGraphic_QRCode_List IsNot Nothing) Then""

    End Sub ''End of "Public Sub UnloadDesigner_QRCode()"


    Public Sub UnloadDesigner_Signature()
        ''
        ''Added 12/14/2021 td 
        ''
        ''Dim objListenerSig1 As MoveAndResizeControls_Monem.ControlResizeProportionally_TD
        ''Dim objListenerSig2 As MoveAndResizeControls_Monem.ControlMove_NonStatic_TD
        ''Dim boolListenerFound1 As Boolean ''Added 12/23/2021 td
        ''Dim boolListenerFound2 As Boolean ''Added 12/23/2021 td

        ''''Added 12/23/2021 td
        ''boolListenerFound1 = mod_designerListener.DictyControlResizing.ContainsKey(CtlGraphic_Signat)
        ''boolListenerFound2 = mod_designerListener.mod_dictyControlMoveBoxesEtc.ContainsKey(CtlGraphic_Signat)

        ''If (boolListenerFound1) Then
        ''    objListenerSig1 = mod_designerListener.DictyControlResizing(CtlGraphic_Signat)
        ''    objListenerSig1.RemoveEventHandlers()
        ''    mod_designerListener.DictyControlResizing.Remove(CtlGraphic_Signat) ''Added 12/17/2021 td
        ''ElseIf (boolListenerFound2) Then
        ''    ''Added 12/23/2021 td
        ''    objListenerSig2 = mod_designerListener.mod_dictyControlMoveBoxesEtc(CtlGraphic_Signat)
        ''    objListenerSig2.RemoveEventHandlers()
        ''    mod_designerListener.mod_dictyControlMoveBoxesEtc.Remove(CtlGraphic_Signat) ''Added 12/17/2021 td
        ''Else
        ''    StatusLabelWarningLabel.Text = "Signature's event listener not found."

        ''End If ''End of "If (boolListenerFound1) Then ... ElseIf (...) ... Else ..."

        ''5/15/2022 If (CtlGraphic_Signat IsNot Nothing) Then ''Added 1/24/2022 td
        ''    CtlGraphic_Signat.Dispose() ''Added Dec. 8, 2021
        ''    Me.DesignerForm.Controls.Remove(CtlGraphic_Signat) ''Added Dec. 8, 2021
        ''    mod_listOfDesignerControls.Remove(CtlGraphic_Signat) ''Added Dec. 8, 2021
        ''5/15/2022 End If ''End of "If (CtlGraphic_Signat IsNot Nothing) Then"

        ''Added 5/15/2022
        Dim each_control As Control
        Dim each_ctlSignature As CtlGraphicSignature
        For Each each_control In Me.DesignerForm.Controls
            If (TypeOf each_control Is CtlGraphicSignature) Then
                Me.DesignerForm.Controls.Remove(each_control)
                each_ctlSignature = CType(each_control, CtlGraphicSignature)
                mod_listOfDesignerControls.Remove(each_ctlSignature)
            End If ''End of ""If (TypeOf each_control Is ....) Then"
        Next each_control

        ''Added 5/13/2022
        If (Me.CtlGraphic_Signat_List IsNot Nothing) Then
            For Each each_ctl_signature As CtlGraphicSignature In Me.CtlGraphic_Signat_List
                If (each_ctl_signature IsNot Nothing) Then ''Added 1/24/2022 td
                    each_ctl_signature.Dispose() ''Added Dec. 8, 2021
                    Me.DesignerForm.Controls.Remove(each_ctl_signature) ''Added Dec. 8, 2021
                    mod_listOfDesignerControls.Remove(each_ctl_signature) ''Added Dec. 8, 2021
                End If ''End of "If (CtlGraphic_Signature IsNot Nothing) Then"
            Next each_ctl_signature
        End If ''End of ""If (Me.CtlGraphic_Signat_List IsNot Nothing) Then""

    End Sub ''End of "Public Sub UnloadDesigner_Signature()"


    Public Sub UnloadDesigner_StaticTexts()
        ''
        ''Added 12/14/2021 td 
        ''
        ''Jan11 2022''Dim objListenerStaticText As MoveAndResizeControls_Monem.ControlResizeProportionally_TD
        ''Jan11 2022''Dim boolListenerFound As Boolean ''Added 12/15/2021 td 
        Dim each_ctlStaticTextV3 As CtlGraphicStaticTextV3 ''Added 12/15/2021 td
        Dim each_ctlStaticTextV4 As CtlGraphicStaticTextV4 ''Added 2/01/2022 td

        ''1/8/2022''If (CtlGraphic_StaticText_temp Is Nothing) Then Return ''Don't bother proceeding.--1/5/2022

        ''Feb1 2022 td''If (ListCtlGraphic_StaticTexts Is Nothing) Then Return ''There are no static texts. --1/8/2022
        Dim bMissingStaticTextsV3 As Boolean ''Added 2/1/2022 td
        Dim bMissingStaticTextsV4 As Boolean ''Added 2/1/2022 td
        Dim bMissingStaticTextsV3V4 As Boolean ''Added 2/1/2022 td
        bMissingStaticTextsV3 = (ListCtlGraphic_StaticTextsV3 Is Nothing OrElse
            (0 = ListCtlGraphic_StaticTextsV3.Count))
        bMissingStaticTextsV4 = (ListCtlGraphic_StaticTextsV4 Is Nothing OrElse
            (0 = ListCtlGraphic_StaticTextsV4.Count))
        bMissingStaticTextsV3V4 = (bMissingStaticTextsV3 And bMissingStaticTextsV4)
        If (bMissingStaticTextsV3V4) Then Return ''Don't bother proceeding. ----2/1/2022

        ''
        ''Added 2/1/2022 td
        ''  Make sure the Lists are non-Null.
        ''
        If (bMissingStaticTextsV3 And ListCtlGraphic_StaticTextsV3 Is Nothing) Then
            ListCtlGraphic_StaticTextsV3 = New HashSet(Of CtlGraphicStaticTextV3)
        End If
        If (bMissingStaticTextsV4 And ListCtlGraphic_StaticTextsV4 Is Nothing) Then
            ListCtlGraphic_StaticTextsV4 = New HashSet(Of CtlGraphicStaticTextV4)
        End If

        ''
        ''Added 12/18/2021 thomas 
        ''
        If (Me.ListCtlGraphic_StaticTextsV3 IsNot Nothing) Then
            For Each each_ctlStaticTextV3 In ListCtlGraphic_StaticTextsV3

                ''Jan10 2022 td''boolListenerFound = mod_designerListener.DictyControlResizing.ContainsKey(each_ctlStaticText)
                ''Jan10 2022 td''If (boolListenerFound) Then
                ''    objListenerStaticText = mod_designerListener.DictyControlResizing(each_ctlStaticText)
                ''    objListenerStaticText.RemoveEventHandlers()
                ''    mod_designerListener.DictyControlResizing.Remove(each_ctlStaticText) ''Added 12/17/2021 td
                ''Else
                ''    ''---MessageBox.Show("We don't see the event-listener for the StaticText control.")
                ''    StatusLabelWarningLabel.Text = "We don't see the event-listener for the StaticText control."

                ''End If ''End of "If (boolListenerFound) Then ... Else ..."

                each_ctlStaticTextV3.Dispose() ''Added Dec. 8, 2021
                each_ctlStaticTextV3.Visible = False ''Added Dec. 18, 2021
                Me.DesignerForm.Controls.Remove(each_ctlStaticTextV3) ''Added Dec. 8, 2021
                mod_listOfDesignerControls.Remove(each_ctlStaticTextV3) ''Added Dec. 8, 2021
                each_ctlStaticTextV3 = Nothing

            Next each_ctlStaticTextV3
        End If ''End of ""If (Me.CtlGraphic_StaticTextsV3 IsNot Nothing) Then""

        ''Added 2/01/2022 thomas downes
        If (Me.ListCtlGraphic_StaticTextsV4 IsNot Nothing) Then
            For Each each_ctlStaticTextV4 In ListCtlGraphic_StaticTextsV4
                ''Added 2/01/2022 thomas downes
                each_ctlStaticTextV4.Dispose() ''Added Dec. 8, 2021
                each_ctlStaticTextV4.Visible = False ''Added Dec. 18, 2021
                Me.DesignerForm.Controls.Remove(each_ctlStaticTextV4) ''Added Dec. 8, 2021
                mod_listOfDesignerControls.Remove(each_ctlStaticTextV4) ''Added Dec. 8, 2021
                each_ctlStaticTextV4 = Nothing
            Next each_ctlStaticTextV4
        End If ''End of ""If (Me.CtlGraphic_StaticTextsV4 IsNot Nothing) Then""

        ''added 12/18/2021
        ''
        ''Unload all of the object references. 
        ''
        If (Me.ListCtlGraphic_StaticTextsV3 IsNot Nothing) Then
            Me.ListCtlGraphic_StaticTextsV3.Clear()
        End If ''End of ""If (Me.CtlGraphic_StaticTextsV3 IsNot Nothing) Then""

        If (Me.ListCtlGraphic_StaticTextsV4 IsNot Nothing) Then
            Me.ListCtlGraphic_StaticTextsV4.Clear()
        End If ''End of ""If (Me.CtlGraphic_StaticTextsV4 IsNot Nothing) Then""

    End Sub ''End of "Public Sub UnloadDesigner_StaticText()"


    Public Sub LoadDesigner(pstrWhyCalled As String,
                            par_bAutoLoadMissingBackground As Boolean,
                            par_bAutoLoadMissingElements As Boolean,
                            par_oMoveEvents As GroupMoveEvents_Singleton,
                            Optional pbStartWithBackside As Boolean = False)
        ''10/1/2019 td''        sender As Object, e As EventArgs) Handles MyBase.Load
        ''10/1/2019 td''Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 7/18/2019 thomas downes 
        ''
        ''Moved below.  9/20 td''Initiate_RubberbandSelector() ''Added 9/8/2019 thomas d. 

        ''Added 1/26/2022 thomas downes
        If (pbStartWithBackside) Then EnumSideOfCard_Current = EnumWhichSideOfCard.EnumBackside

        mod_oGroupMoveEvents = par_oMoveEvents ''Added 1/4/2022 td

        ''
        ''Check that the proportions are correct. 
        ''
        ''9/8/2019 td''ClassLabelToImage.Proportions_CorrectWidth(Me.BackgroundBox)
        ''9/8/2019 td''ClassLabelToImage.Proportions_CorrectWidth(Me.PreviewBox)

        ''10/5/2019 td''ClassLabelToImage.Proportions_FixTheWidth(Me.BackgroundBox) ''----- Me.BackgroundBox)
        ''10/5/2019 td''ClassLabelToImage.Proportions_FixTheWidth(Me.PreviewBox) ''---- Me.PreviewBox)

        ClassFixTheControlWidth.Proportions_FixTheWidth(Me.BackgroundBox_Front)
        ClassFixTheControlWidth.Proportions_FixTheWidth(Me.BackgroundBox_Backside) ''Added 12/10/2021 td 
        ClassFixTheControlWidth.Proportions_FixTheWidth(Me.PreviewBox)

        ''Double-check the proportions are correct. ---9/6/2019 td
        ''10/5/2019 td''ClassLabelToImage.ProportionsAreSlightlyOff(Me.BackgroundBox, True) ''-----Me.BackgroundBox, True)
        ''10/5/2019 td''ClassLabelToImage.ProportionsAreSlightlyOff(Me.PreviewBox, True) ''-----(Me.PreviewBox, True)

        ClassFixTheControlWidth.ProportionsAreSlightlyOff(Me.BackgroundBox_Front, True) ''-----Me.BackgroundBox, True)
        ClassFixTheControlWidth.ProportionsAreSlightlyOff(Me.BackgroundBox_Backside, True) ''-----Me.BackgroundBox, True)
        ClassFixTheControlWidth.ProportionsAreSlightlyOff(Me.PreviewBox, True) ''-----(Me.PreviewBox, True)

        ''Added 10/9/2019 td  
        Me.BadgeLayout_Class = New ciBadgeInterfaces.BadgeLayoutDimensionsClass(Me.BackgroundBox_Front.Width, Me.BackgroundBox_Front.Height)

        ''Added 1/13/2022 td
        ''5/23/2022 Load_BackgroundImage()
        Load_BackgroundImage(par_bAutoLoadMissingBackground)

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
        ''10/1/2019 td''mod_imageExamplePortrait = Me.ExamplePortraitImage ''Added 10/1/2019 td
        mod_imageExamplePortrait = Me.ExampleImage_Portrait ''Added 10/1/2019 td

        ''Modified 1/10/2022 td
        If (Me.CtlGraphic_Signat_1st() IsNot Nothing) Then
            mod_imageExampleSignat = Me.CtlGraphic_Signat_1st().pictureSignature.Image ''Added 10/14/2019 td
        End If ''End of "If (Me.CtlGraphic_Signat IsNot Nothing) Then"
        ''---Dec.7 2021---mod_imageExampleQRCode = Me.CtlGraphic_QRCode.pictureQRCode.Image ''Added 10/14/2019 td

        ''Added 12/7/2021 thomas downes
        ''
        ''     Refresh the QR Code control.
        ''      1. Destroy the existing control.
        ''      2. Create a new one & add it to the designer form. 
        ''
        ''Moved to LoadForm_LayoutElements(). Dec22 2021''LoadDesigner_QRCode()

        ''++=++See below. Dec22 2021 ''Me.BackgroundBox_Front.SendToBack() ''Dec. 7
        ''++If (ShowingTheBackside()) Then
        ''++    Me.BackgroundBox_Backside.SendToBack() ''Added 12/10/2021 td
        ''++    Me.BackgroundBox_Front.SendToBack() ''Added 12/10/2021 td
        ''++End If ''End of "If (ShowingBackside()) Then"

        ''[[[['If (Me.CtlGraphic_QRCode IsNot Nothing) Then ''Added 1/10/2022 td 
        ''[[[['mod_imageExampleQRCode = Me.CtlGraphic_QRCode.pictureQRCode.Image ''Added 10/14/2019 td
        ''Jan14 2022 td''With Me.ElementsCache_UseEdits.ElementQRCode
        If (0 < Me.ElementsCache_UseEdits.ListOfElementQRCodes_Front.Count) Then
            With Me.ElementsCache_UseEdits.ListOfElementQRCodes_Front(0)
                ''Populate the Element-Field object with a reference to the image.  ---Dec. 7 2022
                If (.Image_BL Is Nothing) Then
                    If (mod_imageExampleQRCode Is Nothing) Then
                        mod_imageExampleQRCode = My.Resources.QR_Code_BK
                    End If ''End of "If (mod_imageExampleQRCode Is Nothing) Then"
                    .Image_BL = mod_imageExampleQRCode
                End If ''End of "If (.Image_BL Is Nothing) Then"
            End With ''end of "With Me.ElementsCache_Edits.ListOfElementQRCodes(0)"
        End If ''End of "If (0 < Me.ElementsCache_UseEdits.ListOfElementQRCodes_Front.Count) Then"
        ''[[[['End If ''End of "If (Me.CtlGraphic_QRCode IsNot Nothing) Then"

        ''Added 9/23/2019 td 
        ''
        ''   Save a link to the "CIB Version 9.0 Lady" so that the 
        ''   procedure ciBadgeElemImage.modGenerate's Public Sub PicImage_ByElement 
        ''   can have an image to utilize, instead of requiring that the image
        ''   be passed as an parameter.  ---9/23/2019 td
        ''
        ''Dec14 2021 td''Me.ElementsCache_Saved.Pic_InitialDefault = mod_imageExamplePortrait
        ''Dec14 2021 td''Me.ElementsCache_UseEdits.Pic_InitialDefault = mod_imageExamplePortrait
        Me.ElementsCache_Manager.LoadPic_InitialDefault(mod_imageExamplePortrait)

        ''10/1/2019 td''Me.Controls.Remove(CtlGraphicPortrait_Lady) ''Added 7/31/2019 thomas d. 

        ''Encapsulated 7/31/2019 td
        ''
        ''Major call !!
        ''
        ''9/8/2019 td''Load_Form()

        ''
        ''Major call!!
        ''  Load the fields (which are //_not_// the elements (the thing which 
        ''   appears on the badge layout); importantly, the fields are //referenced// 
        ''   by the elements). ----10/10/2019 td
        Dim boolMissingAnyFields As Boolean ''Added 10/10/2019 td 
        boolMissingAnyFields = (Me.ElementsCache_UseEdits.MissingTheFields())
        If (boolMissingAnyFields) Then
            ''Load the fields (which are //_not_// the elements (the thing which 
            ''   appears on the badge layout); importantly, the fields are //referenced// 
            ''   by the elements). ----10/10/2019 td
            Me.ElementsCache_UseEdits.LoadFields()
        End If ''end of "If (boolMissingAnyFields) Then"

        ''
        ''''
        '''''
        Dim boolMissingAnyFieldElements As Boolean ''Added 10/10/2019 td 
        With Me.ElementsCache_UseEdits
            boolMissingAnyFieldElements = (.MissingTheElementFields()) And
                     (Not .UserHasDeletedElements)
            If (boolMissingAnyFieldElements) Then
                ''10/1/2019 td''Me.ElementsCache_Saved.LoadFieldElements(Me.BackgroundBox)
                .LoadFieldElements(Me.BackgroundBox_Front, Me.BadgeLayout_Class)
            End If ''End of "If (boolMissingAnyFields) Then"
        End With ''End of ""With Me.ElementsCache_UseEdits""

        ''
        ''Major call!!  
        ''
        ''9/17/2019 td''LoadForm_LayoutElements()
        ''9/20/2019 td''LoadForm_LayoutElements(Me.ElementsCache_Edits)
        ''12/8/2021 td''LoadForm_LayoutElements(Me.ElementsCache_Edits, mod_listOfFieldControls,
        ''12/8/2021 td''      "ClassDesigner.LoadDesigner " & pstrWhyCalled)
        ''02/10/2022 td''LoadForm_LayoutElements(EnumSideOfCard_Current, Me.ElementsCache_UseEdits,
        ''                 mod_listOfFieldControls,
        ''                 par_oMoveEvents, "ClassDesigner.LoadDesigner " & pstrWhyCalled)

        LoadForm_LayoutElements(EnumSideOfCard_Current, Me.ElementsCache_UseEdits,
                                mod_listOfFieldControlsV3,
                                mod_listOfFieldControlsV4,
                                par_oMoveEvents, "ClassDesigner.LoadDesigner " & pstrWhyCalled)



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
        intPicLeft = Me.Initial_Pic_Left
        intPicTop = Me.Initial_Pic_Top
        intPicWidth = Me.Initial_Pic_Width
        intPicHeight = Me.Initial_Pic_Height

        ''9/19 td''Me.ElementsCache_Saved.LoadPicElement(CtlGraphicPortrait_Lady.picturePortrait, Me.BackgroundBox) ''Added 9/19/2019 td
        ''10/1/2019 td''Me.ElementsCache_Saved.LoadPicElement(intPicLeft, intPicTop, intPicWidth, intPicHeight, Me.BackgroundBox) ''Added 9/19/2019 td

        If (par_bAutoLoadMissingElements) Then ''Added 5/4/2022 td

            If (Me.ElementsCache_UseEdits.MissingTheElementPic()) Then ''Added 10/10/2019 td
                ''10/10/2019 td''Me.ElementsCache_Saved.LoadPicElement(intPicLeft, intPicTop, intPicWidth, intPicHeight, Me.BackgroundBox) ''Added 9/19/2019 td
                ''Jan19 2022 ''Me.ElementsCache_UseEdits.LoadElement_Pic(intPicLeft, intPicTop,
                Me.ElementsCache_UseEdits.LoadNewElement_Pic(intPicLeft, intPicTop,
                                            intPicWidth, intPicHeight,
                                            Me.BackgroundBox_Front,
                                            EnumWhichSideOfCard.EnumFrontside) ''Added 9/19/2019 td
            End If ''End of "If (Me.ElementsCache_Saved.MissingTheElementPic) Then"

            ''Added 10/10/2019 td
            If (Me.ElementsCache_UseEdits.MissingTheQRCode()) Then ''Added 10/10/2019 td
                ''Added 10/10/2019 td
                ''Jan19 2022''Me.ElementsCache_UseEdits.LoadElement_QRCode(Initial_QR_Left, Initial_QR_Top,
                Me.ElementsCache_UseEdits.LoadNewElement_QRCode(Initial_QR_Left, Initial_QR_Top,
                                    Initial_QR_Width, Initial_QR_Height,
                                    Me.BackgroundBox_Front,
                                    EnumWhichSideOfCard.EnumFrontside) ''Added 9/19/2019 td
            End If ''End of "If (Me.ElementsCache_Saved.MissingTheElementPic) Then"

            ''Added 10/10/2019 td
            If (Me.ElementsCache_UseEdits.MissingTheSignature()) Then ''Added 10/10/2019 td
                ''Added 10/10/2019 td
                Me.ElementsCache_UseEdits.LoadNewElement_Signature(Initial_Sig_Left, Initial_Sig_Top,
                                Initial_Sig_Width, Initial_Sig_Height,
                                Me.BackgroundBox_Front,
                                EnumWhichSideOfCard.EnumFrontside) ''Added 9/19/2019 td
            End If ''End of "If (Me.ElementsCache_Saved.MissingTheSignature) Then"

            ''Added 10/10/2019 td
            If (Me.ElementsCache_UseEdits.MissingTheElementTexts()) Then ''Added 10/10/2019 td
                ''Added 10/10/2019 td
                ''Dec17 2021''Me.ElementsCache_UseEdits.LoadElement_Text("This is text which will be the same for everyone.",
                ''Jan19 2022''Me.ElementsCache_UseEdits.LoadElement_StaticText_IfNeeded("This is text which will be the same for everyone.",
                Me.ElementsCache_UseEdits.LoadNewElement_StaticTextV3("The same text for everyone.",
                                    Initial_Text_Left, Initial_Text_Top,
                                    Initial_Text_Width, Initial_Text_Height,
                                    Me.BackgroundBox_Front,
                                    EnumWhichSideOfCard.EnumFrontside) ''Added 9/19/2019 td
            Else
                ''Added 12/22/2021 thomas downes
                ''--Dec22 2021 td--LoadDesigner_StaticTexts
                ''--Moved to Sub LoadForm_LayoutElements().---Dec22 2021 td--LoadElements_StaticTexts()

            End If ''End of "If (Me.ElementsCache_Saved.MissingTheElementTexts) Then .... Else ..."

        End If ''End of ""If (par_bAutoLoadMissingElements) Then""

        ''Added 9/24/2019 thomas 
        ''  10/1/2019 td''Dim serial_tools As New ciBadgeSerialize.ClassSerial
        ''  10/1/2019 td''serial_tools.PathToXML = (System.IO.Path.GetRandomFileName() & ".xml")
        ''  10/1/2019 td''serial_tools.SerializeToXML(Me.ElementsCache_Saved.GetType, Me.ElementsCache_Saved, False, True)

        ''[[-[[ Let the main form handle this sort of thing.
        ''[[-[[    The designer should not mess around with these
        ''[[-[[    objects, unless 100% necessary. ----11/30/2021 td
        ''[[Me.ElementsCache_Edits = Me.ElementsCache_Saved.Copy()


        ''
        ''Major call!!  
        ''
        ''9/17/2019 td''LoadForm_LayoutElements()
        ''9/20/2019 td''LoadForm_LayoutElements(Me.ElementsCache_Edits)
        ''Moved upward in procedure. 11/28/2021''LoadForm_LayoutElements(Me.ElementsCache_Edits, mod_listOfFieldControls,
        ''Moved upward in procedure. 11/28/2021''      "ClassDesigner.LoadDesigner " & pstrWhyCalled)

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

        ResizeLayoutBackgroundImage_ToFitPictureBox() ''Added 8/25/2019 td

        ''1/14/2022''RefreshPreview_Redux_Front() ''Added 8/24/2019 td
        If (Me.DontAutoRefreshPreview) Then
            ''Don't refresh.  ====3/11/2022
        Else
            RefreshPreview_CurrentSide() ''Modified 1/14/2022 td
        End If ''End of "If (Me.DontAutoRefreshPreview) Then ... Else ..."

        ''Dec10 2021 td''Me.BackgroundBox_Front.SendToBack()
        If (ShowingTheBackside()) Then
            ''Show the backside of card. 
            Me.BackgroundBox_Backside.SendToBack() ''Added 12/10/2021 td
            Me.BackgroundBox_Front.SendToBack() ''Added 12/10/2021 td
            Me.BackgroundBox_JustAButton.SendToBack() ''1/21/2022
        Else
            ''Show the frontside of card. 
            Me.BackgroundBox_Front.SendToBack() ''Added 12/10/2021 td
            Me.BackgroundBox_Backside.SendToBack() ''Added 12/10/2021 td
            Me.BackgroundBox_JustAButton.SendToBack() ''Added 1/21/2022 td
        End If ''End of "If (ShowingBackside()) Then ... Else ..."

        ''------------------------------------------------------------------------
        ''Const c_boolBreakpoint As Boolean = True  ''Added 9//13/2019 td

        ''''Badge Preview is also moveable/sizeable, mostly to impress
        ''''    management.  ----9/8/2019 td
        ''''
        ''If (mc_bUseNonStaticMovers) Then
        ''    ''Added 11/29/2021 td 
        ''    Dim objMover As New ControlMove_NonStatic_TD
        ''    objMover.Init(Me.PreviewBox, Me.PreviewBox, 10, False,
        ''                      c_boolBreakpoint)
        ''    mod_dictyControlMoveBoxesEtc.Add(Me.PreviewBox, objMover)

        ''Else
        ''    ControlMoverOrResizer_TD.Init(Me.PreviewBox, Me.PreviewBox, 10, False,
        ''                      c_boolBreakpoint) ''Added 9/08/2019 thomas downes
        ''End If ''End of "If (mc_bUseNonStaticMovers) Then .... Else If...."

        ''If it won't conflict with the Rubber-Band Selector, 
        ''    then let's make the Badge Layout Background 
        ''    also moveable / sizeable.
        ''    ----9/8/2019 td
        ''
        ''Const c_LayoutBackIsMoveable As Boolean = False ''Added 9/8/2019 td 

        ''If (c_LayoutBackIsMoveable And mc_bUseNonStaticMovers) Then
        ''    ''Badge Layout Background is also moveable/sizeable.
        ''    Dim objMover As New ControlMove_NonStatic_TD
        ''    objMover.Init(Me.BackgroundBox,
        ''                  Me.BackgroundBox, 10, False,
        ''                  c_boolBreakpoint) ''Added 9/08/2019 thomas downes
        ''ElseIf (c_LayoutBackIsMoveable) Then
        ''    ''Badge Layout Background is also moveable/sizeable.
        ''    ControlMoverOrResizer_TD.Init(Me.BackgroundBox,
        ''                      Me.BackgroundBox, 10, False,
        ''                      c_boolBreakpoint) ''Added 9/08/2019 thomas downes
        ''End If ''End of "If (c_LayoutBackIsMoveable) Then"
        ''---------------------------------------------------------------------------------

        ''Moved from above, 9/20/2019 td 
        ''1/12/2022 td''Initiate_RubberbandSelector(mod_listOfFieldControls,

        ''This will allow the user to easily select multiple elements at once.
        ''  ----1/14/2022 td  
        Const c_bLoadRubberband As Boolean = False ''False, since I just encountered a runtime error,
        ''  related to the rubberband, and I am not prepared to debug this just yet.
        ''  ----Added 1/4/2022 td
        If (c_bLoadRubberband) Then ''Added 1/4/2022 td
            Initiate_RubberbandSelector(mod_listOfDesignerControls,
                                 mod_selectedCtls) ''Added 9/8/2019 thomas d. 
        End If ''End of "If (c_bLoadRubberband) Then"

        ''
        ''Added 11/29/2021
        ''
        ''Jan5 2022''mod_designerListener = New ClassDesignerEventListener(Me, mc_bAddBorderOnlyWhileResizing)
        mod_designerListener = New ClassDesignerEventListener(Me, mod_oGroupMoveEvents,
                                                              mc_bAddBorderOnlyWhileResizing)

        ''
        ''Major call !!
        ''
        ''Feb102022 td''mod_designerListener.LoadDesigner(mod_listOfFieldControlsV3,
        ''                                       mod_listOfDesignerControls)
        mod_designerListener.LoadDesigner(mod_listOfFieldControlsV3,
                                          mod_listOfFieldControlsV4,
                                          mod_listOfDesignerControls)

        ''Added 1/14/2022 td
        ''  Maybe this will cause the portrait-element control to appear. 
        Me.DesignerForm.Refresh()

        ''Added 1/14/2022 td
        Dim boolRefMatches As Boolean ''Added 1/14/2022 td
        boolRefMatches = (Me.DesignerForm_DoubleCheckRef IsNot Nothing) AndAlso
                  (Me.DesignerForm Is Me.DesignerForm_DoubleCheckRef)
        If (boolRefMatches) Then
            '' Great, as expected. ---1/14/2022
        Else
            ''Added 1/14/2022 td
            MessageBoxTD.Show_Statement("Houston, we have a problem!!!  Our form is orphaned.")
        End If ''End of "If (boolRefMatches) Then .... Else ....."

        ''Copied & modified, from above calls to .SendToBack(). Added 1/14/2022
        If (Not ShowingTheBackside()) Then Me.BackgroundBox_Front.SendToBack()
        If (ShowingTheBackside()) Then Me.BackgroundBox_Backside.SendToBack()
        Me.BackgroundBox_JustAButton.SendToBack() ''Added 1/21/2022 td

        ''Added 1/26/2022 td
        If (pbStartWithBackside) Then
            ''Added 1/26/2022 td
            Me.DesignerForm_Interface.ProceedToBackSide_SetupBacksideLabels()
        End If ''End of "If (pbStartWithBackside) Then"

    End Sub ''End of "Public Sub LoadDesigner"


    Public Sub Load_NewElementToCacheAndForm_FieldV3(par_enumField As EnumCIBFields,
                                     par_rectForElement As Rectangle)
        ''
        ''Added 5/13/2022 td
        ''
        Dim new_elementFieldV3 As ClassElementFieldV3 = Nothing ''Added 5/12/2022 td

        ''
        ''Part 1. Create the Element & load it into the cache. 
        ''
        new_elementFieldV3 = Load_NewElementIntoCache_FieldV3(par_enumField,
                                                   par_rectForElement)

        If (new_elementFieldV3 Is Nothing) Then System.Diagnostics.Debugger.Break()

        ''
        ''Part 2. Display the Element on the Designer Form. 
        ''
        LoadFieldControlIntoForm_JustOneV3(new_elementFieldV3)


    End Sub ''End of ""Public Sub Load_NewElementToCacheAndForm_FieldV3()""


    ''Public Sub Load_NewElementToCacheAndForm_Graphic(par_rectForElement As Rectangle)
    ''    ''
    ''    ''Added 5/13/2022 td
    ''    ''
    ''    Dim new_elementGraphic As ClassElementGraphic = Nothing ''Added 5/12/2022 td

    ''    ''
    ''    ''Part 1. Create the Element & load it into the cache. 
    ''    ''
    ''    new_elementGraphic = Load_NewElementIntoCache_StaticGraphic(par_rectForElement)
    ''
    ''    If (new_elementGraphic Is Nothing) Then System.Diagnostics.Debugger.Break()
    ''
    ''    ''
    ''    ''Part 2. Display the Element on the Designer Form. 
    ''    ''
    ''    Dim new_list As New HashSet(Of ClassElementGraphic)
    ''    ''----Const c_bAddToMoveableClass As Boolean = True ''Added 9/8/2019 td 
    ''    new_list.Add(new_elementGraphic)
    ''    LoadFormwElements_StaticGraphics(new_list)
    ''
    ''End Sub ''End of ""Public Sub Load_NewElementToCacheAndForm_Graphic()""


    Public Sub Load_NewElementToCacheAndForm_Portrait(par_rectForElement As Rectangle)
        ''
        ''Added 5/14/2022 td
        ''
        Dim new_element As ClassElementPortrait = Nothing ''Added 5/12/2022 td
        Dim enumWhichSide As EnumWhichSideOfCard ''Added 5/15/2022 
        ''
        ''Part 1. Create the Element & load it into the cache. 
        ''
        enumWhichSide = Me.EnumSideOfCard_Current
        new_element = Load_NewElementIntoCache_PortraitPic(par_rectForElement,
                          enumWhichSide)

        If (new_element Is Nothing) Then System.Diagnostics.Debugger.Break()

        ''
        ''Part 2. Display the Element on the Designer Form. 
        ''
        ''#1 5/14/2022 td''LoadFieldControl_OnePortrait(new_element)
        ''#2 5/14/2022 td''LoadElementToForm_Picture(new_element)
        Dim new_list As New HashSet(Of ClassElementPortrait)
        new_list.Add(new_element)
        LoadFormwElements_AllPortraits(new_list, mod_oGroupMoveEvents)


    End Sub ''End of ""Public Sub Load_NewElementToCacheAndForm_Portrait()""


    Public Sub Load_NewElementToCacheAndForm_Signature(par_rectForElement As Rectangle)
        ''
        ''Added 5/14/2022 td
        ''
        Dim new_element As ClassElementSignature = Nothing ''Added 5/12/2022 td
        Dim enumWhichCardSide As EnumWhichSideOfCard ''Added 5/12/2022 td
        ''
        ''Part 1. Create the Element & load it into the cache. 
        ''
        enumWhichCardSide = EnumSideOfCard_Current
        new_element = Load_NewElementIntoCache_Signature(par_rectForElement,
                           enumWhichCardSide)

        If (new_element Is Nothing) Then
            System.Diagnostics.Debugger.Break()
        End If

        ''
        ''Part 2. Display the Element on the Designer Form. 
        ''
        ''#1 5/14/2022 td''LoadFieldControl_OnePortrait(new_element)
        ''#2 5/14/2022 td''LoadElementToForm_Picture(new_element)
        Dim new_list As New HashSet(Of ClassElementSignature)
        new_list.Add(new_element)
        LoadFormwElements_AllSignatures(new_list, mod_oGroupMoveEvents)


    End Sub ''End of ""Public Sub Load_NewElementToCacheAndForm_Signature()""


    Public Sub Load_NewElementToCacheAndForm_Graphic(par_rectForElement As Rectangle,
                                                     Optional pintIndex As Integer = 1)
        ''
        ''Added 5/14/2022 td
        ''
        Dim new_element As ClassElementGraphic = Nothing ''Added 5/12/2022 td

        ''
        ''Part 1. Create the Element & load it into the cache. 
        ''
        new_element = Load_NewElementIntoCache_StaticGraphic(par_rectForElement)

        If (new_element Is Nothing) Then System.Diagnostics.Debugger.Break()

        ''
        ''Part 2. Display the Element on the Designer Form. 
        ''
        ''#1 5/14/2022 td''LoadFieldControl_OnePortrait(new_element)
        ''#2 5/14/2022 td''LoadElementToForm_Picture(new_element)
        Dim new_list As New HashSet(Of ClassElementGraphic)
        new_list.Add(new_element)
        LoadFormwElements_StaticGraphics(new_list) '', mod_oGroupMoveEvents)

        ''Added 8/17/2022 td
        If (pintIndex >= 2) Then
            With new_element
                .TopEdge_Pixels += .Height_Pixels * (pintIndex - 1)
                .TopEdge_bPixels += .Height_bPixels * (pintIndex - 1)
            End With
        End If ''End of ""If (pintIndex >= 2) Then""

    End Sub ''End of ""Public Sub Load_NewElementToCacheAndForm_Graphic()""


    Public Sub Load_NewElementToCacheAndForm_QRCode(par_rectForElement As Rectangle)
        ''
        ''Added 5/14/2022 td
        ''
        Dim new_element As ClassElementQRCode = Nothing ''Added 5/12/2022 td
        Dim enumWhichSide As EnumWhichSideOfCard ''Added 5/15/2022 

        ''
        ''Part 1. Create the Element & load it into the cache. 
        ''
        enumWhichSide = EnumSideOfCard_Current
        new_element = Load_NewElementIntoCache_QRCode(par_rectForElement, enumWhichSide)

        If (new_element Is Nothing) Then System.Diagnostics.Debugger.Break()

        ''
        ''Part 2. Display the Element on the Designer Form. 
        ''
        Dim new_list As New HashSet(Of ClassElementQRCode)
        new_list.Add(new_element)
        LoadFormwElements_AllQRCodes(new_list, mod_oGroupMoveEvents)


    End Sub ''End of ""Public Sub Load_NewElementToCacheAndForm_QRCode()""


    Public Sub Load_NewElementToCacheAndForm_StaticTextV4(par_rectForElement As Rectangle,
                           Optional pstrTextForStaticText As String = "",
                           Optional pintIndex As Integer = 1)
        ''
        ''Added 6/01/2022 td
        ''
        ''Text Label... any message you like.
        ''
        Dim new_element As ClassElementStaticTextV4 = Nothing ''Added 6/1/2022 & 5/12/2022 td

        ''
        ''Part 1. Create the Element & load it into the cache. 
        ''
        new_element = Load_NewElementIntoCache_StaticTextV4(par_rectForElement)

        ''Added 6/1/2022 td
        If (pstrTextForStaticText = "") Then
            new_element.Text_StaticLine = "Text Label... any message you like."
        Else
            new_element.Text_StaticLine = pstrTextForStaticText
        End If ''End of ""If (pstrTextForStaticText = "") Then... Else..."

        If (new_element Is Nothing) Then System.Diagnostics.Debugger.Break()

        ''
        ''Part 2. Display the Element on the Designer Form. 
        ''
        Dim new_list As New HashSet(Of ClassElementStaticTextV4)
        new_list.Add(new_element)
        ''Moved below 8/17/2022 LoadFormwElements_StaticTextsV4(new_list) '', mod_oGroupMoveEvents)

        ''Added 8/17/2022 td
        If (pintIndex >= 2) Then
            With new_element
                .TopEdge_Pixels += (.Height_Pixels * (pintIndex - 1))
                .TopEdge_bPixels += (.Height_bPixels * (pintIndex - 1))
            End With
        End If ''End of ""If (pintIndex >= 2) Then""

        ''Moved here 8/17/2022
        LoadFormwElements_StaticTextsV4(new_list) '', mod_oGroupMoveEvents)

    End Sub ''End of ""Public Sub Load_NewElementToCacheAndForm_StaticTextV4()""


    Public Sub Load_NewElementToCacheAndForm_StaticTextV3(par_rectForElement As Rectangle,
                           Optional pstrTextForStaticText As String = "")
        ''
        ''Added 5/14/2022 td
        ''
        ''Text Label... any message you like.
        ''
        Dim new_element As ClassElementStaticTextV3 = Nothing ''Added 5/12/2022 td

        ''
        ''Part 1. Create the Element & load it into the cache. 
        ''
        new_element = Load_NewElementIntoCache_StaticTextV3(par_rectForElement)

        ''Added 6/1/2022 td
        If (pstrTextForStaticText = "") Then
            new_element.Text_StaticLine = "Text Label... any message you like."
        Else
            new_element.Text_StaticLine = pstrTextForStaticText
        End If ''End of ""If (pstrTextForStaticText = "") Then... Else..."

        If (new_element Is Nothing) Then System.Diagnostics.Debugger.Break()

        ''
        ''Part 2. Display the Element on the Designer Form. 
        ''
        Dim new_list As New HashSet(Of ClassElementStaticTextV3)
        new_list.Add(new_element)
        LoadFormwElements_StaticTextsV3(new_list) '', mod_oGroupMoveEvents)


    End Sub ''End of ""Public Sub Load_NewElementToCacheAndForm_StaticTextV3()""


    Public Function Load_NewElementIntoCache_FieldV3(par_enumField As EnumCIBFields,
                                     par_rect As Rectangle) As ClassElementFieldV3
        ''
        ''Added 5/6/2022 thomas d.
        ''
        Dim intPicLeft As Integer
        Dim intPicTop As Integer
        Dim intPicWidth As Integer
        Dim intPicHeight As Integer
        Dim objNewElementFieldV3 As ClassElementFieldV3
        Dim objNewElementFieldV4 As ClassElementFieldV3

        Static s_countCalls As Integer = 0

        ''Added 5/10/2022 td
        If (par_enumField = EnumCIBFields.Undetermined) Then
            System.Diagnostics.Debugger.Break()
            ''-----Exit Sub
        End If ''End of ""If (par_enumField = EnumCIBFields.Undetermined) Then""


        ''Added 10/01/2019 td
        intPicLeft = par_rect.Left '' Me.Initial_Pic_Left
        intPicTop = par_rect.Top '' Me.Initial_Pic_Top
        intPicWidth = par_rect.Width '' Me.Initial_Pic_Width
        intPicHeight = par_rect.Height '' Me.Initial_Pic_Height

        ''TO DO:  Create a form which displays the badge as a white background
        ''        and overlays a blue rectangle which the correct WH ratio 
        ''        and placed on a random part of the badge. Have a heading 
        ''        which says, "We have placed the new element at a random position
        ''        on the badge, as indicated below.  The only reason for this
        ''        dialog is to let you know where it's been placed.  You cannot
        ''        modify use this dialog to move the element.  Hit OK to close dialog."
        ''        That dialog can have the responsibility of calling the Random
        ''        Number generator and determining pixel position. 
        ''        --5/6/2022 thomas d.
        ''
        Const c_boolVersion4_TestingOK As Boolean = False ''Added 5/12/2022 td

        If (c_boolVersion4_TestingOK) Then

            ''''Version 4, is not working at all... bummer! ----5/12/2022 
            ''objNewElementFieldV4 =
            ''Me.ElementsCache_UseEdits.LoadNewElement_FieldV4(par_enumField,
            ''                     intPicLeft, intPicTop,
            ''                     Me.BadgeLayout_Class,
            ''                     EnumSideOfCard_Current)
            ''''---------        ''intPicWidth, intPicHeight,
            ''Return objNewElementFieldV4
            Return Nothing ''Revised 5/13/2022 td

        Else
            ''Version 3, is tried & true. ----5/12/2022
            objNewElementFieldV3 =
            Me.ElementsCache_UseEdits.LoadNewElement_FieldV3(par_enumField,
                                 intPicLeft, intPicTop,
                                 Me.BadgeLayout_Class,
                                 EnumSideOfCard_Current)

            Return objNewElementFieldV3

        End If ''End of ""If (c_boolVersion4_TestingOK) Then... Else...."

    End Function ''End of ""Public Sub Load_NewElementIntoCache_FieldV3()""


    Public Function Load_NewElementIntoCache_FieldV4(par_enumField As EnumCIBFields,
                                     par_rect As Rectangle) As ClassElementFieldV4
        ''
        ''Added 5/13/2022 thomas d.
        ''
        Dim intPicLeft As Integer
        Dim intPicTop As Integer
        Dim intPicWidth As Integer
        Dim intPicHeight As Integer
        ''Dim objNewElementFieldV3 As ClassElementFieldV3
        Dim objNewElementFieldV4 As ClassElementFieldV4

        Static s_countCalls As Integer = 0

        ''Added 5/10/2022 td
        If (par_enumField = EnumCIBFields.Undetermined) Then
            System.Diagnostics.Debugger.Break()
            ''-----Exit Sub
        End If ''End of ""If (par_enumField = EnumCIBFields.Undetermined) Then""


        ''Added 10/01/2019 td
        intPicLeft = par_rect.Left '' Me.Initial_Pic_Left
        intPicTop = par_rect.Top '' Me.Initial_Pic_Top
        intPicWidth = par_rect.Width '' Me.Initial_Pic_Width
        intPicHeight = par_rect.Height '' Me.Initial_Pic_Height

        ''TO DO:  Create a form which displays the badge as a white background
        ''        and overlays a blue rectangle which the correct WH ratio 
        ''        and placed on a random part of the badge. Have a heading 
        ''        which says, "We have placed the new element at a random position
        ''        on the badge, as indicated below.  The only reason for this
        ''        dialog is to let you know where it's been placed.  You cannot
        ''        modify use this dialog to move the element.  Hit OK to close dialog."
        ''        That dialog can have the responsibility of calling the Random
        ''        Number generator and determining pixel position. 
        ''        --5/6/2022 thomas d.
        ''
        Const c_boolVersion4_TestingOK As Boolean = True ''False ''Added 5/12/2022 td

        If (c_boolVersion4_TestingOK) Then

            ''''Version 4, is not working at all... bummer! ----5/12/2022 
            ''objNewElementFieldV4 =
            ''Me.ElementsCache_UseEdits.LoadNewElement_FieldV4(par_enumField,
            ''                     intPicLeft, intPicTop,
            ''                     Me.BadgeLayout_Class,
            ''                     EnumSideOfCard_Current)
            ''''---------        ''intPicWidth, intPicHeight,
            ''Return objNewElementFieldV4
            ''Return Nothing ''Revised 5/13/2022 td
            objNewElementFieldV4 = Nothing
            Return objNewElementFieldV4

        Else
            ''Version 3, is tried & true. ----5/12/2022
            ''objNewElementFieldV3 =
            ''Me.ElementsCache_UseEdits.LoadNewElement_FieldV3(par_enumField,
            ''                     intPicLeft, intPicTop,
            ''                     Me.BadgeLayout_Class,
            ''                     EnumSideOfCard_Current)

            ''Return objNewElementFieldV3

        End If ''End of ""If (c_boolVersion4_TestingOK) Then... Else...."

    End Function ''End of ""Public Sub Load_NewElementIntoCache_FieldV4()""



    Public Function Load_NewElementIntoCache_PortraitPic(par_rect As Rectangle,
                                             par_enumCardSide As EnumWhichSideOfCard) As ClassElementPortrait
        ''
        ''Added 5/6/2022 thomas d.
        ''
        Dim objElement As ClassElementPortrait ''Added 5/14/2022 td
        Dim intPicLeft As Integer
        Dim intPicTop As Integer
        Dim intPicWidth As Integer
        Dim intPicHeight As Integer

        Static s_countCalls As Integer = 0

        ''Added 10/01/2019 td
        intPicLeft = par_rect.Left '' Me.Initial_Pic_Left
        intPicTop = par_rect.Top '' Me.Initial_Pic_Top
        intPicWidth = par_rect.Width '' Me.Initial_Pic_Width
        intPicHeight = par_rect.Height '' Me.Initial_Pic_Height

        ''TO DO:  Create a form which displays the badge as a white background
        ''        and overlays a blue rectangle which the correct WH ratio 
        ''        and placed on a random part of the badge. Have a heading 
        ''        which says, "We have placed the new element at a random position
        ''        on the badge, as indicated below.  The only reason for this
        ''        dialog is to let you know where it's been placed.  You cannot
        ''        modify use this dialog to move the element.  Hit OK to close dialog."
        ''        That dialog can have the responsibility of calling the Random
        ''        Number generator and determining pixel position. 
        ''        --5/6/2022 thomas d.
        ''
        objElement =
        Me.ElementsCache_UseEdits.LoadNewElement_Pic(intPicLeft, intPicTop,
                             intPicWidth, intPicHeight,
                             Me.BackgroundBox_Front,
                             par_enumCardSide) ''---EnumCurrentSideOfCard

        Return objElement ''Added 5/14/2022 

    End Function ''End of ""Public Function Load_NewElementIntoCache_PortraitPic()""


    Public Function Load_NewElementIntoCache_QRCode(par_rect As Rectangle,
                                                    par_enumSide As EnumWhichSideOfCard) As ClassElementQRCode
        ''5/14/2022  Public Sub Load_NewElementIntoCache_QRCode
        ''
        ''Added 5/06/2022 td
        ''
        Dim newElementQRCode As ClassElementQRCode ''Added 5/14/2022 
        Dim intLeft As Integer
        Dim intTop As Integer
        Dim intWidth As Integer
        Dim intHeight As Integer

        Static s_countCalls As Integer = 0

        ''Added 10/01/2019 td
        intLeft = par_rect.Left '' Me.Initial_Pic_Left
        intTop = par_rect.Top '' Me.Initial_Pic_Top
        intWidth = par_rect.Width '' Me.Initial_Pic_Width
        intHeight = par_rect.Height '' Me.Initial_Pic_Height

        ''Added 5/06/2022 td
        newElementQRCode =
        Me.ElementsCache_UseEdits.LoadNewElement_QRCode(intLeft, intTop,
                             intWidth, intHeight,
                             Me.BackgroundBox_Front,
                             par_enumSide)

        Return newElementQRCode

    End Function ''End of ""Public Sub Load_NewElementIntoCache_QRCode()""


    Public Function Load_NewElementIntoCache_Signature(par_rect As Rectangle,
                                         par_enumWhichSide As EnumWhichSideOfCard) As ClassElementSignature
        ''5/14/2022 TD  Public Sub Load_NewElementIntoCache_Signature

        ''Added 5/06/2022 td
        Dim intLeft As Integer
        Dim intTop As Integer
        Dim intWidth As Integer
        Dim intHeight As Integer

        Static s_countCalls As Integer = 0

        intLeft = par_rect.Left '' Me.Initial_Pic_Left
        intTop = par_rect.Top '' Me.Initial_Pic_Top
        intWidth = par_rect.Width '' Me.Initial_Pic_Width
        intHeight = par_rect.Height '' Me.Initial_Pic_Height

        Dim newElement As ClassElementSignature
        newElement =
        Me.ElementsCache_UseEdits.LoadNewElement_Signature(intLeft, intTop,
                             intWidth, intHeight,
                             Me.BackgroundBox_Front,
                             par_enumWhichSide) '' EnumSideOfCard_Current)

        Return newElement

    End Function ''End of ""Public Function Load_NewElementIntoCache_Signature()""


    Public Function Load_NewElementIntoCache_StaticGraphic(par_rect As Rectangle) As ClassElementGraphic
        ''5/14/2022  Public Sub Load_NewElementIntoCache_StaticGraphic

        ''Added 5/06/2022 td
        Dim intLeft As Integer
        Dim intTop As Integer
        Dim intWidth As Integer
        Dim intHeight As Integer

        Static s_countCalls As Integer = 0

        ''Added 10/01/2019 td
        intLeft = par_rect.Left '' Me.Initial_Pic_Left
        intTop = par_rect.Top '' Me.Initial_Pic_Top
        intWidth = par_rect.Width '' Me.Initial_Pic_Width
        intHeight = par_rect.Height '' Me.Initial_Pic_Height

        Dim newElement As ClassElementGraphic ''Added 5/14/2022 

        ''5/14/2022 Me.ElementsCache_UseEdits.LoadNewElement_StaticGraphic(intLeft, intTop,
        newElement =
        Me.ElementsCache_UseEdits.LoadNewElement_Graphic(intLeft, intTop,
                             intWidth, intHeight,
                             Me.BackgroundBox_Front,
                             EnumSideOfCard_Current,
                             Me.BadgeLayout_Class)

        Return newElement

    End Function ''End of ""Public Function Load_NewElementIntoCache_StaticGraphic()""


    Public Function Load_NewElementIntoCache_StaticTextV3(par_rect As Rectangle) As ClassElementStaticTextV3
        ''5/14/2022  Public Sub Load_NewElementIntoCache_StaticText

        ''Added 5/06/2022 td
        Dim intLeft As Integer
        Dim intTop As Integer
        Dim intWidth As Integer
        Dim intHeight As Integer

        Static s_countCalls As Integer = 0

        ''Added 10/01/2019 td
        intLeft = par_rect.Left '' Me.Initial_Pic_Left
        intTop = par_rect.Top '' Me.Initial_Pic_Top
        intWidth = par_rect.Width '' Me.Initial_Pic_Width
        intHeight = par_rect.Height '' Me.Initial_Pic_Height

        Dim newElement As ClassElementStaticTextV3
        newElement =
        Me.ElementsCache_UseEdits.LoadNewElement_StaticTextV3("This is for static text.",
                             intLeft, intTop,
                             intWidth, intHeight,
                             Me.BackgroundBox_Front,
                             EnumSideOfCard_Current)

        Return newElement


    End Function ''End of ""Public Function Load_NewElementIntoCache_StaticTextV3()""


    Public Function Load_NewElementIntoCache_StaticTextV4(par_rect As Rectangle) As ClassElementStaticTextV4
        ''
        ''Added 6/01/2022 td
        ''
        Dim intLeft As Integer
        Dim intTop As Integer
        Dim intWidth As Integer
        Dim intHeight As Integer

        Static s_countCalls As Integer = 0

        intLeft = par_rect.Left '' Me.Initial_Pic_Left
        intTop = par_rect.Top '' Me.Initial_Pic_Top
        intWidth = par_rect.Width '' Me.Initial_Pic_Width
        intHeight = par_rect.Height '' Me.Initial_Pic_Height

        Dim newElement As ClassElementStaticTextV4
        newElement =
        Me.ElementsCache_UseEdits.LoadNewElement_StaticTextV4("This is for static text.",
                             intLeft, intTop,
                             intWidth, intHeight,
                             Me.BackgroundBox_Front,
                             EnumSideOfCard_Current)

        Return newElement


    End Function ''End of ""Public Function Load_NewElementIntoCache_StaticTextV4()""


    Public Function GetBadgeImage_EitherSide(par_enumCurrentSide As EnumWhichSideOfCard,
                        par_objMakeBadgeElements As ClassBadgeSideLayoutV1,
                        Optional par_recipient As ciBadgeRecipients.ClassRecipient = Nothing,
                        Optional par_elementBaseToOmit As ClassElementBase = Nothing,
                        Optional par_objBadgeLayoutClass As BadgeLayoutDimensionsClass = Nothing) As Image
        ''
        ''Added 8/01/2022 Thomas Downes  
        ''
        ''Optional parameter "par_elementBaseToOmit" allows us to focus on individual elements
        ''   against a background which includes visual/non-editable (image only) versions of 
        ''   all other elements (which are not currently being edited).  
        ''   ---8/1/2022 td
        ''
        Dim objImageOfBadgeSide As Image = Nothing
        Dim objBadgeLayoutClass As BadgeLayoutDimensionsClass ''Added 8/18/2022 thomas 

        ''Added 8/18/2022 thomas
        objBadgeLayoutClass = par_objBadgeLayoutClass
        If (objBadgeLayoutClass Is Nothing) Then
            objBadgeLayoutClass = Me.BadgeLayout_Class
        End If ''End of ""If (objBadgeLayoutClass Is Nothing) Then""

        ''8/02/2022 td RefreshPreview_EitherSide(par_enumCurrentSide, par_objMakeBadgeElements,
        ''                Nothing, Nothing, par_recipient, True,
        ''                objImageOfBadgeSide,
        ''                par_elementBaseToOmit)

        RefreshPreview_EitherSide(par_enumCurrentSide, par_objMakeBadgeElements,
                 Nothing, Nothing, par_recipient, True,
                 Me.BadgeLayout_Class,
                 objImageOfBadgeSide,
                 par_elementBaseToOmit)

        Return objImageOfBadgeSide

    End Function ''End of ""Public Function GetBadgeImage_EitherSide""


    Public Sub UnselectHighlightedElements()
        ''
        ''Added 10/15/2019 thomas d.  
        ''
        MsgBox("Okay, we will unselect the highlighted elements.", vbInformation)

    End Sub ''End of "Public Sub UnselectHighlightedElements()"


    Private Sub ResizeLayoutBackgroundImage_ToFitPictureBox()
        ''
        ''Added 8/25/2019 td 
        ''
        Dim obj_image As Image = Nothing ''Added 8/24 td
        ''Dim obj_image_clone As Image ''Added 8/24 td
        Dim obj_image_clone_resized As Image ''Added 8/24/2019 td

        ''Added 8/24/2019 td
        ''---obj_image = Me.BackgroundBox.Image
        If (Me.BackgroundBox_Front.BackgroundImage Is Nothing) Then
            If File.Exists(Me.ElementsCache_UseEdits.BackgroundImage_Front_Path) Then
                Try
                    obj_image = (New Bitmap(Me.ElementsCache_UseEdits.BackgroundImage_Front_Path))
                    Me.BackgroundBox_Front.BackgroundImage = obj_image
                Catch Ex_image As Exception
                    MessageBox.Show(Ex_image.ToString)
                End Try
            End If ''End of " If File.Exists(Me.ElementsCache_Edits.BackgroundImage_Path)) Then"
        End If ''End of "If (Me.BackgroundBox.BackgroundImage Is Nothing) Then"

        ''Added 11/26/2021 td
        If (obj_image Is Nothing) Then
            obj_image = Me.BackgroundBox_Front.BackgroundImage
        End If ''End of "If (obj_image Is Nothing) Then"

        ''obj_image_clone = CType(obj_image.Clone(), Image)

        ''Dim gr_resize As Graphics = New Bitmap(obj_image_clone)

        ''8/25/2019 td''obj_image_clone_resized = ciLayoutPrintLib.LayoutPrint.ResizeImage_ToHeight(obj_image,
        ''                       Me.BackgroundBox.Height)

        ''8/26/2019 td''obj_image_clone_resized = ciLayoutPrintLib.LayoutPrint.ResizeImage_ToWidth(obj_image,
        ''8/26/2019 td''       Me.BackgroundBox.Width)

        If (obj_image Is Nothing) Then
            ''No background image is available or selected. ---3/24/2022 td

        Else
            ''
            ''We have an image which we can clone & resize. 
            ''
            obj_image_clone_resized = LayoutPrint.ResizeBackground_ToFitBox(obj_image, Me.BackgroundBox_Front, True)

            ''-----Dec.3 2021 ---Me.BackgroundBox.Image = obj_image_clone_resized
            Me.BackgroundBox_Front.BackgroundImage = obj_image_clone_resized

        End If ''End of "If (obj_image Is Nothing) Then .... Else ..."

    End Sub ''End of Sub ResizeLayoutBackgroundImage_ToFitPictureBox()


    Public Sub Load_BackgroundImage(par_bAddBackgroundIfMissing As Boolean)
        ''
        ''Encapsulated from code copied from Form__Main_Demo.vb
        ''
        ''Added 12/3/2021 thomas downes
        Dim objectBackgroundImage As Bitmap
        Dim strBackgroundImage_Path As String = ""
        Dim strBackgroundImage_Title As String = ""
        Dim boolBacksideOfCard As Boolean

        ''Added 1/13/2022 td
        boolBacksideOfCard = (Me.EnumSideOfCard_Current = EnumWhichSideOfCard.EnumBackside)

        With ElementsCache_UseEdits
            ''12/14/2021''strBackgroundImage_Path = .ElementsCache_UseEdits.BackgroundImage_Front_Path
            strBackgroundImage_Path = .GetBackgroundImage_Path(EnumSideOfCard_Current)
            If (strBackgroundImage_Path Is Nothing) Then strBackgroundImage_Path = ""

            If ("" = strBackgroundImage_Path) Then

                ''Check if the constant allows us to supply a background image. 5/23/2022
                If (par_bAddBackgroundIfMissing) Then ''Added 5/23/2022 thomas d.

                    strBackgroundImage_Path = DiskFilesVB.PathToFile_Background_FirstOrDefault(strBackgroundImage_Title)

                    If (EnumSideOfCard_Current = EnumWhichSideOfCard.EnumBackside) Then ''Added 1/13/22
                        ''Added 1/13/22
                        .BackgroundImage_Backside_FTitle = strBackgroundImage_Title
                        .BackgroundImage_Backside_Path = strBackgroundImage_Path
                    Else
                        .BackgroundImage_Front_FTitle = strBackgroundImage_Title
                        .BackgroundImage_Front_Path = strBackgroundImage_Path
                    End If ''End of "If (EnumSideOfCard = ...."

                ElseIf (boolBacksideOfCard) Then
                    ''Added 5/23/2022
                    Me.BackgroundBox_Backside.Image = My.Resources.BackgroundIsBlank
                Else
                    ''Frontside of card.  --Added 5/23/2022
                    ''5/23/2022 Me.BackgroundBox_Front.Image = My.Resources.BackgroundIsBlank
                    Me.BackgroundBox_Front.Image = My.Resources.BackgroundIsBlank_MoveableElems

                End If ''End of ""If (par_bAddBackgroundIfMissing) Then ... ElseIf... Else...""

            End If ''End of ''If ("" = strBackgroundImage_Path) The
        End With ''end of "With ElementsCache_UseEdits"

        ''
        ''Load the appropriate picture box with the JPEG or other image file. 
        ''
        If ("" = strBackgroundImage_Path) Then
            ''
            ''Don't proceed with processing an empty path. ---5/23/2022
            ''
        ElseIf (System.IO.File.Exists(strBackgroundImage_Path)) Then
            ''
            ''The path is substantive & valid.
            ''
            objectBackgroundImage = New Bitmap(strBackgroundImage_Path)
            If (boolBacksideOfCard) Then
                BackgroundBox_Backside.Image?.Dispose()
                BackgroundBox_Backside.Image = Nothing
                BackgroundBox_Backside.BackColor = Color.White '' Color.Transparent
                BackgroundBox_Backside.BackgroundImage = objectBackgroundImage
                BackgroundBox_Backside.BackgroundImageLayout = ImageLayout.Zoom
                BackgroundBox_Backside.Visible = True
                BackgroundBox_JustAButton.Visible = True ''Added 1/21/2022 td
                BackgroundBox_Front.Visible = False ''Make the other control invisible. 
                BackgroundBox_JustAButton.SendToBack() ''Added 1/21/2022 td
            Else
                BackgroundBox_Front.Image?.Dispose()
                BackgroundBox_Front.Image = Nothing
                BackgroundBox_Front.BackColor = Color.White '' Color.Transparent
                BackgroundBox_Front.BackgroundImage = objectBackgroundImage
                BackgroundBox_Front.BackgroundImageLayout = ImageLayout.Zoom
                ''Jan16 2022''BackgroundBox_Front.Refresh()
                BackgroundBox_Backside.Visible = False ''Make the other control invisible. 
                BackgroundBox_Front.Visible = True
            End If ''end of "If (boolBacksideOfCard) Then... Else ..."
        End If ''End of "If (System.IO.File.Exists(strBackgroundImage_Path)) Then"

    End Sub ''ENd of "Private Sub Load_BackgroundImage()"


    Private Sub LoadForm_LayoutElements(par_enumSideOfCard As EnumWhichSideOfCard,
                                        par_cache As ClassElementsCache_Deprecated,
                                        ByRef par_listFieldCtlsV3 As HashSet(Of CtlGraphicFieldV3),
                                        ByRef par_listFieldCtlsV4 As HashSet(Of CtlGraphicFieldV4),
                                        par_oMoveEvents As GroupMoveEvents_Singleton,
                                        pstrWhyCalled As String)
        ''10/17/2019 td''Private Sub LoadForm_LayoutElements(par_cache As ClassElementsCache,
        ''                                ByRef par_listFieldCtls As List(Of CtlGraphicFldLabel))
        ''9/20/2019 td''Private Sub LoadForm_LayoutElements(par_cache As ClassElementsCache)
        ''
        ''Added 9/17/2019 td
        ''
        Const c_boolLoadingForm As Boolean = True ''Added 8/28/2019 thomas downes 
        Dim boolMakeMoveableByUser As Boolean ''Added 9/20/2019 td 
        Const c_boolMakeMoveableASAP As Boolean = False ''added 9/20/2019 td

        ElementsCache_UseEdits = par_cache ''Added 11/30/2021 

        ''#1 9/17/2019 td''LoadElements_Fields_Master(c_boolLoadingForm, par_cache.FieldElements())
        '' #2 9/17/2019 td''LoadElements_ByListOfFields(ClassFields.ListAllFields())
        ''9/20/2019 td''LoadFieldControls_ByListOfElements(par_cache.ListFieldElements(), c_boolLoadingForm)

        boolMakeMoveableByUser = c_boolMakeMoveableASAP ''Added 9/20/2019 td  

        ''Added 11/27/2021 thomas downes
        ''Jan8 2022''Dim objListBadgeElems As HashSet(Of ClassElementField)
        Dim objListBadgeElemsV3 As List(Of ClassElementFieldV3)
        Dim objListBadgeElemsV4 As List(Of ClassElementFieldV4)

        If (par_enumSideOfCard = EnumWhichSideOfCard.EnumBackside) Then
            ''Back side of the card.
            objListBadgeElemsV3 = par_cache.ListOfBadgeDisplayElements_Flds_BacksideV3(True)
            objListBadgeElemsV4 = par_cache.ListOfBadgeDisplayElements_Flds_BacksideV4(True)

        Else
            ''Front side of the card. 
            objListBadgeElemsV3 = par_cache.ListOfBadgeDisplayElements_Flds_FrontV3(True)
            objListBadgeElemsV4 = par_cache.ListOfBadgeDisplayElements_Flds_FrontV4(True)
        End If ''End of "If (par_enumSideOfCard = ....) Then ... Else ..."

        ''
        ''Major call !!
        ''
        ''----LoadFieldControls_ByListOfElements(par_cache.ListFieldElements(),
        ''--- Dec21 2021 ''LoadFieldControls_ByListOfElements(objListBadgeElems, 

        LoadElements_FieldElementsV3(objListBadgeElemsV3,
                                           c_boolLoadingForm,
                                           False, boolMakeMoveableByUser,
                                           par_listFieldCtlsV3,
                            "ClassDesigner.LoadForm_LayoutElements " & pstrWhyCalled)

        ''Added 2/9/2022 thomas downes
        LoadElements_FieldElementsV4(objListBadgeElemsV4,
                                           c_boolLoadingForm,
                                           False, boolMakeMoveableByUser,
                                           par_listFieldCtlsV4,
                            "ClassDesigner.LoadForm_LayoutElements " & pstrWhyCalled)

        ''
        ''Load the non-Field Elements. ---12/22/2021 thomas d. 
        ''
        Dim iBadgeSideElements As IBadgeSideLayoutElementsV1
        ''5/20/2022 iBadgeSideElements = par_cache.GetAllBadgeSideLayoutElements(par_enumSideOfCard)
        iBadgeSideElements = par_cache.GetAllBadgeSideLayoutElements(par_enumSideOfCard,
                                                Me.BadgeLayout_Class)

        ''12/22/2021 td''If (par_enumSideOfCard = EnumWhichSideOfCard.EnumBackside) Then
        ''12/22/2021 td''     ''For now, omit the picture and the signature from the back side of the card. 
        ''12/22/2021 td''     ''   ----12/8/2021 td
        ''12/22/2021 td''Else

        ''Added 12/7/2021 thomas downes
        ''
        ''Refresh the QR Code control.
        ''   1. Destroy the existing control.
        ''   2. Create a new one & add it to the designer form. 
        ''
        ''Jan3 2022 td''LoadElements_QRCode(iBadgeSideElements.ElementQR) ''Dec22 2021 td''LoadDesigner_QRCode()


        ''5/5/2022 td''LoadElements_QRCode(iBadgeSideElements.ElementQRCode_1st, par_oMoveEvents) ''Dec22 2021 td''LoadDesigner_QRCode()
        Const c_boolLimitOnePerCustomer_QRCode As Boolean = False ''Added 5/6/2022 thomas
        If (c_boolLimitOnePerCustomer_QRCode) Then
            ''
            ''Only load exactly one(1) QR Code. ---5/14/2022 
            ''
            ''5/14/2022 td''LoadElements_QRCode(iBadgeSideElements.ElementQRCode_1st, par_oMoveEvents) ''Dec22 2021 td''LoadDesigner_QRCode()
            ''5/15/2022 td''LoadElementToForm_QRCode(iBadgeSideElements.ElementQRCode_1st, par_oMoveEvents) ''Dec22 2021 td''LoadDesigner_QRCode()
            If (0 < iBadgeSideElements.ListElementQRCodes.Count) Then
                ''Major call!!
                LoadElementToForm_QRCode(iBadgeSideElements.ListElementQRCodes(0), par_oMoveEvents) ''Dec22 2021 td''LoadDesigner_QRCode()
            End If ''End of ""If (0 < iBadgeSideElements.ListElementQRCodes.Count) Then""

        Else
            ''5/14/2022 td''LoadElements_AllQRCodes(iBadgeSideElements.ListElementQRCodes(), par_oMoveEvents) ''Dec22 2021 td''LoadDesigner_QRCode()
            LoadFormwElements_AllQRCodes(iBadgeSideElements.ListElementQRCodes(), par_oMoveEvents) ''Dec22 2021 td''LoadDesigner_QRCode()

        End If ''End of ""If (c_boolLimitOnePerCustomer_QRCode) Then... Else..."

        ''12/22/2021 td''LoadElements_Picture(par_cache.PicElement_Front())
        ''01/5/2022 td''LoadElements_Picture(iBadgeSideElements.ElementPic)
        ''5/05/2022 td''LoadElements_Picture(iBadgeSideElements.ElementPortrait_1st, True)
        Const c_boolLimitOnePerCustomer_PortPic As Boolean = False ''Added 5/6/2022 thomas
        If (c_boolLimitOnePerCustomer_PortPic) Then
            ''
            ''Only load exactly one(1) Potrait Picture. ---5/14/2022 
            ''
            ''5/15/2022 td''LoadElementToForm_Picture(iBadgeSideElements.ElementPortrait_1st, par_oMoveEvents, True)
            If (0 < iBadgeSideElements.ListElementPortraits.Count) Then
                ''Major call!!
                LoadElementToForm_Picture(iBadgeSideElements.ListElementPortraits(0), par_oMoveEvents, True) ''Dec22 2021 td''LoadDesigner_QRCode()
            End If ''End of ""If (0 < iBadgeSideElements.ListElementPortraits.Count) Then""

        Else
            ''5/14/2022 td'' LoadElement_AllPortraits(iBadgeSideElements.ListElementPortraits(), par_oMoveEvents) ''Dec22 2021 td''LoadDesigner_QRCode()
            LoadFormwElements_AllPortraits(iBadgeSideElements.ListElementPortraits(), par_oMoveEvents) ''Dec22 2021 td''LoadDesigner_QRCode()

        End If ''End of ""If (c_boolLimitOnePerCustomer_PortPic) Then... Else..."

        ''12/22/2021 td''LoadElements_Signature(par_cache.ElementSignature) ''Added 10/12/2019 thomas d.
        ''1/4/2022 td''LoadElements_Signature(iBadgeSideElements.ElementSig) ''Modified 12/22/2021 thomas d.
        ''5/05/2022 td''LoadElements_Signature(iBadgeSideElements.ElementSignature_1st, par_oMoveEvents) ''Modified 12/22/2021 thomas d.

        Const c_boolLimitOnePerCustomer_Sig As Boolean = False ''Added 5/6/2022 thomas
        If (c_boolLimitOnePerCustomer_Sig) Then
            ''
            ''Only load exactly one(1) Signature. ---5/14/2022 
            ''
            ''5/14/2022 td''LoadElements_Signature(iBadgeSideElements.ElementSignature_1st, par_oMoveEvents)
            ''5/15/2022 td''LoadElementToForm_Signature(iBadgeSideElements.ElementSignature_1st, par_oMoveEvents)
            If (0 < iBadgeSideElements.ListElementSignatures.Count) Then
                ''Major call!!
                LoadElementToForm_Signature(iBadgeSideElements.ListElementSignatures(0), par_oMoveEvents) ''Dec22 2021 td''LoadDesigner_QRCode()
            End If ''End of ""If (0 < iBadgeSideElements.ListElementSignatures.Count) Then""

        Else
            ''5/14/2022 td'' LoadElements_AllSignatures(iBadgeSideElements.ListElementSignatures(), par_oMoveEvents) ''Dec22 2021 td''LoadDesigner_QRCode()
            LoadFormwElements_AllSignatures(iBadgeSideElements.ListElementSignatures(), par_oMoveEvents) ''Dec22 2021 td''LoadDesigner_QRCode()

        End If ''End of ""If (c_boolLimitOnePerCustomer_Sig) Then... Else..."

        ''Added 12/18/2021 td 
        '' Dec18 2021''LoadElements_StaticText1(par_cache.ListOfElementTexts_Front.GetEnumerator().Current) ''Added 10/12/2019 thomas d.
        '' Dec22 2021''ListCtlGraphic_StaticTexts = New HashSet(Of CtlGraphicStaticText) ''Added 12/18/2021 thomas d. 
        '' Dec22 2021''LoadElements_StaticTexts(par_cache.ListOfElementTexts_Front) ''Added 12/18/2021 thomas d.

        ''5/14/2022 ''LoadElements_StaticTextsV3(iBadgeSideElements.ListElementStaticTextsV3) ''Added 12/22/2021 thomas d.
        LoadFormwElements_StaticTextsV3(iBadgeSideElements.ListElementStaticTextsV3) ''Added 12/22/2021 thomas d.

        ''Added 1/22/2022 Thomas D.
        ''5/14/2022 ''LoadElements_StaticTextsV4(iBadgeSideElements.ListElementStaticTextsV4) ''Added 1/31/2022 thomas d.
        LoadFormwElements_StaticTextsV4(iBadgeSideElements.ListElementStaticTextsV4) ''Added 1/31/2022 thomas d.

        ''5/14/2022 ''LoadElements_StaticGraphics(iBadgeSideElements.ListElementGraphics) ''Added 1/22/2022 Thomas D.
        LoadFormwElements_StaticGraphics(iBadgeSideElements.ListElementGraphics) ''Added 1/22/2022 Thomas D.

        ''12/22/2021 td''End If ''End of "If (par_enumSideOfCard = EnumWhichSideOfCard.EnumBackside) Then ... Else..."

        ''Added 10/12/2019 td 
        ''mod_sizing_portrait.Init(Me.CtlGraphic_Portrait.picturePortrait, Me.CtlGraphic_Portrait, 10, True, mod_sizingEvents_Pics, False)
        ''mod_sizing_QR.Init(Me.CtlGraphic_QRCode.pictureQRCode, Me.CtlGraphic_QRCode, 10, True, mod_sizingEvents_QR, False)
        ''mod_sizing_signature.Init(Me.CtlGraphic_Signat.pictureSignature, Me.CtlGraphic_Signat, 10, True, mod_sizingEvents_Sig, False)

        ''''Add moveability.   
        ''boolMakeMoveableByUser = (Not c_boolMakeMoveableASAP) ''Added 9/20/2019 td
        ''If (boolMakeMoveableByUser) Then
        ''    ''
        ''    ''Pretty big call!!   Allow the user to "click & drag" the control. 
        ''    ''
        ''    Try
        ''        MakeElementsMoveable_Fields()

        ''    Catch ex_fields As Exception
        ''        ''Added 11/26/2021 thomas downes
        ''        MessageBox.Show(ex_fields.Message)
        ''        MessageBox.Show(ex_fields.ToString)
        ''    End Try

        ''End If ''ENd of "If (boolMakeMoveableByUser) Then"

        ''
        ''Added 7/28/2019 td
        ''
        ''    Make sure that the Badge Background is in the background. 
        ''
        Me.BackgroundBox_Front.SendToBack()
        ''10/1/2019 td''graphicAdjuster.SendToBack() ''Added 8/12/2019 td

        If (Me.PreviewBox IsNot Nothing) Then ''Added 1/10/2022 thomas d. 
            Me.PreviewBox.SendToBack() ''Added 8/12/2019 td
        End If ''End of "If (Me.PreviewBox IsNot Nothing) Then"

    End Sub ''ENd of "Private Sub LoadForm_LayoutElements()"

    ''Private Sub MakeElementsMoveable_Fields()
    ''    ''
    ''    ''Added 7/19/2019 thomas downes  
    ''    ''
    ''    ''10/12/2019 td''Const c_addAfterMoveAddBreakpoint As Boolean = True

    ''    ''8/4/2019 td''Dim boolAllowGroupMovements As Boolean = False ''True ''False ''Added 8/3/2019 td  
    ''    ''
    ''    ''Portrait
    ''    ''
    ''    ''10/9/2019 td''If (mc_boolAllowGroupMovements) Then
    ''    ''10/9/2019 td''    ControlMove_GroupMove_TD.Init(CtlGraphicPortrait_Lady.Picture_Box,
    ''    ''              CtlGraphicPortrait_Lady, 10, True, mod_groupedMove,
    ''    ''              c_addAfterMoveAddBreakpoint) ''Added 8/3/2019 thomas downes
    ''    ''
    ''    ''10/9/2019 td''Else
    ''    ''10/9/2019 td''    ControlMoverOrResizer_TD.Init(CtlGraphicPortrait_Lady.Picture_Box,
    ''    ''          CtlGraphicPortrait_Lady, 10, True,
    ''    ''           c_addAfterMoveAddBreakpoint) ''Added 7/31/2019 thomas downes
    ''    ''10/9/2019 td''End If ''End of " If (mc_boolAllowGroupMovements) Then .... Else ...."

    ''    ''Added 10/9/2019 thomas downes
    ''    ''10/12/2019 td-----ControlResizeProportionally_TD.Init(CtlGraphic_Portrait.Picture_Box,
    ''    ''---      CtlGraphic_Portrait, 10, True,
    ''    ''---      mod_sizingPic_events, c_addAfterMoveAddBreakpoint) ''Added 10/9/2019 thomas downes

    ''    ''Added 10/11/2019 thomas downes
    ''    ''10/12/2019 td-----ControlMoverOrResizer_TD.Init(CtlGraphic_Signat.pictureSignature,
    ''    ''---      CtlGraphic_Signat, 10, True,
    ''    ''---      c_addAfterMoveAddBreakpoint)

    ''    ''
    ''    ''Fields
    ''    ''
    ''    Dim each_graphicLabel As CtlGraphicFldLabel ''Added 7/19/2019 thomas downes  

    ''    For Each each_control As Control In Me.DesignerForm.Controls ''Added 7/19/2019 thomas downes  

    ''        If (TypeOf each_control Is CtlGraphicFldLabel) Then

    ''            each_graphicLabel = CType(each_control, CtlGraphicFldLabel)

    ''            ''7/31/2019 td''ControlMoverOrResizer_TD.Init(each_graphicLabel.Picture_Box,
    ''            ''                each_control, 10) ''Added 7/28/2019 thomas downes

    ''            ControlMoverResizer_AddFieldCtl(each_graphicLabel)

    ''        End If ''End of "If (TypeOf each_control Is GraphicFieldLabel) Then"

    ''    Next each_control

    ''End Sub ''End of "Private Sub MakeElementsMoveable()"


    ''Private Sub ControlMoverResizer_AddFieldCtl(par_graphicFieldCtl As CtlGraphicFldLabel)
    ''    ''
    ''    ''Encapsulated 9/7/2019 thomas d
    ''    ''
    ''    Const c_bRepaintAfterResize As Boolean = True ''Added 7/31/2019 td 

    ''    If (mc_bUseNonStaticMovers And mc_boolAllowGroupMovements) Then
    ''        ''
    ''        ''Added 11/29/2021 td
    ''        ''
    ''        Dim objNonStatic As New ControlMove_Group_NonStatic
    ''        objNonStatic.Init(par_graphicFieldCtl.Picture_Box,
    ''          par_graphicFieldCtl, 10, c_bRepaintAfterResize,
    ''          mod_groupedMove, mc_boolAllowGroupMovements)
    ''        mod_dictyControlMoveFields.Add(par_graphicFieldCtl, objNonStatic)

    ''    ElseIf (mc_boolAllowGroupMovements) Then
    ''        ''
    ''        ''This is essentially deprecated as of 11/29/2021 
    ''        ''
    ''        ControlMove_GroupMove_TD.Init(par_graphicFieldCtl.Picture_Box,
    ''                      par_graphicFieldCtl, 10, c_bRepaintAfterResize,
    ''                      mod_groupedMove, mc_boolAllowGroupMovements) ''Added 8/3/2019 td 
    ''    Else
    ''        ControlMoverOrResizer_TD.Init(par_graphicFieldCtl.Picture_Box,
    ''                      par_graphicFieldCtl, 10,
    ''                      c_bRepaintAfterResize, mc_boolBreakpoints) ''Added 7/28/2019 thomas downes
    ''    End If ''End of "If (boolAllowGroupMovements) Then ...... Else ..."
    ''
    ''End Sub ''End of "Private Sub ControlMoverResizer_AddField"


    Private Sub LoadFormwElements_AllPortraits(par_listElements As HashSet(Of ClassElementPortrait),
                                    par_oMoveEvents As GroupMoveEvents_Singleton,
                                    Optional pbIfNothingThenExit As Boolean = True)
        ''5/14/2022  Private Sub LoadElements_AllPortraits

        ''Added 5/5/2022 td
        For Each each_elem As ClassElementPortrait In par_listElements
            ''Major call!!
            ''5/14/2022 LoadElements_Picture(each_elem, par_oMoveEvents, pbIfNothingThenExit)
            LoadElementToForm_Picture(each_elem, par_oMoveEvents, pbIfNothingThenExit)

        Next each_elem

    End Sub ''End of ""Private Sub LoadFormwElements_AllPortraits""


    Public Sub LoadElementToForm_Picture(par_elementPic As ClassElementPortrait,
                                       par_oGroupMoveEvents As GroupMoveEvents_Singleton,
                        pbIfNothingThenExit As Boolean,
                        Optional pbIfNothingThrowException As Boolean = False)
        ''5/14/2022 Private Sub LoadElements_Picture
        ''
        ''Added 7/31/2019 thomas downes
        ''Parameter par_elementPic added 9/17/2019 td
        ''
        ''7/31 td''Dim new_picControl As CtlGraphicPortrait ''Added 7/31/2019 td  

        ''Added 8/22/2019 THOMAS D.
        ciPictures_VB.PictureExamples.PathToFolderOfImages = (My.Application.Info.DirectoryPath & "\Images\PictureExamples")

        ''Added 1/5/2022 td
        If (par_elementPic Is Nothing) Then
            If (pbIfNothingThenExit) Then Return ''Exit smoothly. ---1/5/22
            ''---Throw New Exception("The Element is missing!")
            If (pbIfNothingThrowException) Then Throw New Exception("The Element is missing!")
            Return ''Exit smoothly, regardless of parameter. ---1/5/22
        End If ''End of "If (par_elementPic Is Nothing) Then"

        Dim oGetControlParameters As ClassGetElementControlParams ''Added 1/17/2022 thomas d.
        oGetControlParameters = Me.GetParametersToGetElementControl() ''Added 1/17/2022 thomas d.

        ''Jan4 2022 td''CtlGraphic_Portrait = New CtlGraphicPortrait(par_elementPic, Me)
        Dim local_CtlGraphic_Portrait As CtlGraphicPortrait ''Added 5/15/2022 td
        local_CtlGraphic_Portrait = CtlGraphicPortrait.GetPortrait(oGetControlParameters,
                                par_elementPic, Me.DesignerForm,
                                "CtlGraphic_Portrait",
                                Me, True, mod_ctlLasttouched, Me,
                                par_oGroupMoveEvents)
        ''                    ''May5 2022  mod_oGroupMoveEvents)

        ''10/1/2019 td''Me.Controls.Add(CtlGraphicPortrait_Lady)
        ''5/15/2022 Me.DesignerForm.Controls.Add(CtlGraphic_Portrait_Deprecated)
        Me.DesignerForm.Controls.Add(local_CtlGraphic_Portrait)

        ''Added 5/15/2022 td
        local_CtlGraphic_Portrait.BringToFront()

        ''Added 11/28/2021 td
        mod_listOfDesignerControls.Add(local_CtlGraphic_Portrait)

        With local_CtlGraphic_Portrait

            ''9/17/2019 td''.Top = ClassElementPic.ElementPicture.TopEdge_Pixels
            ''9/17/2019 td''.Left = ClassElementPic.ElementPicture.LeftEdge_Pixels
            ''9/17/2019 td''.Width = ClassElementPic.ElementPicture.Width_Pixels
            ''9/17/2019 td''.Height = ClassElementPic.ElementPicture.Height_Pixels

            ''5/16/2022 td'' .Top = par_elementPic.TopEdge_Pixels
            ''5/16/2022 td'' .Left = par_elementPic.LeftEdge_Pixels

            ''Added 5/16/2022 td
            .Top = Me.Layout_Margin_Top_Add(par_elementPic.TopEdge_Pixels)
            .Left = Me.Layout_Margin_Left_Add(par_elementPic.LeftEdge_Pixels)

            .Width = par_elementPic.Width_Pixels
            .Height = par_elementPic.Height_Pixels

            ''Added 8/18/2019 td
            .picturePortrait.Image = mod_imageExamplePortrait

            ''Added 1/14/2022 td
            .Visible = True

            ''Added 9/17/2019 td
            .Refresh_Master()

        End With ''End of "With CtlGraphic_Portrait"

        ''Added 12/15/2021 td
        ''   Pass on the event of right-clicking a element-field control. 
        ''----AddHandler label_control.ElementPic_RightClicked, AddressOf ElementPic_Clicked
        ''If (mod_bAddHandlersForRightClick) Then
        ''    AddHandler CtlGraphic_Portrait.ElementPic_RightClicked, AddressOf ElementPic_Clicked
        ''End If ''End of "If (mod_bAddHandlersForRightClick) Then"

        ''
        ''Moveability 
        ''
        If (Me.LetEventListenerAddMoveability) Then
            ''
            ''See ClassDesignerEventListener.LoadForm_LayoutElements_Moveability() ---12/23/2021
            ''
        ElseIf (Me.LetBaseControlAddMoveability) Then ''--Added 1/5/2022
            ''
            ''The element control's base class will add moveability. --Added 1/5/2022
            ''  (See project/subfolder __RSC_WindowsControlLibrary/RSCMoveableControl)
            ''
        Else
            ''
            ''Add moveability - Static Texts
            ''
            ''Jan10 2022 td''Dim bKeepWidthHeightProportional As Boolean = True ''added 12/23/2021
            ''Jan10 2022 td''Add_Moveability(CtlGraphic_Portrait, CtlGraphic_Portrait,
            ''                     CtlGraphic_Portrait, bKeepWidthHeightProportional)
            Throw New Exception("Let the control __RSC_WindowsControlLibrary/RSCMoveableControl " +
                                 "be responsible for moveability.--1/11/2022")

        End If ''End of "If (Me.LetEventListenerAddMoveability) Then ... Else ..."

    End Sub ''End of " Private Sub LoadElementToForm_Picture()"


    Private Sub LoadFormwElements_AllQRCodes(par_listElementsQR As HashSet(Of ClassElementQRCode),
                                    par_oMoveEvents As GroupMoveEvents_Singleton)
        ''5/14/2022  Private Sub LoadElements_AllQRCodes
        ''
        ''Added 5/5/2022 td
        ''
        For Each each_elem As ClassElementQRCode In par_listElementsQR
            ''Major call!!
            ''5/14/2022 LoadElements_QRCode(each_elem, par_oMoveEvents)
            LoadElementToForm_QRCode(each_elem, par_oMoveEvents)
        Next each_elem

    End Sub ''Endof ""Private Sub LoadFormwElements_AllQRCodes""

    Public Sub LoadElementToForm_QRCode(par_elementQR As ClassElementQRCode,
                                    par_oMoveEvents As GroupMoveEvents_Singleton)
        ''5/14/2022 td''Private Sub LoadElements_QRCode
        ''--#2 Dec22 2021 td''--Private Sub LoadElements_QRCode()
        ''--#1 Dec22 2021 td''--Private Sub LoadDesigner_QRCode()
        ''
        ''Added 12/22/2021 thomas downes
        ''
        ''5/14/2022 If (Me.CtlGraphic_QRCode IsNot Nothing) Then
        ''  Me.CtlGraphic_QRCode.Dispose()
        ''  Me.DesignerForm.Controls.Remove(Me.CtlGraphic_QRCode)
        ''End If ''ENd of "If (Me.CtlGraphic_QRCode IsNot Nothing) Then"

        ''Added 1/16/2022 thomas d. 
        ''  Check to see if this badge-side (e.g. front side) contains a QR code. 
        If (par_elementQR Is Nothing) Then
            System.Diagnostics.Debugger.Break() ''Added 5/15/2022
            Return ''Added 1/16/2022 td
        End If ''End of "If (par_elementQR Is Nothing) Then"

        ''Load a brand-new QR-code control. ---12/7/2021 td  
        ''12/22/2021 td''Dim elementQRCode As ClassElementQRCode = Me.ElementsCache_UseEdits.ElementQRCode

        ''12/22/2021 td''If (elementQRCode.WhichSideOfCard = EnumWhichSideOfCard.Undetermined) Then elementQRCode.WhichSideOfCard = EnumWhichSideOfCard.EnumFrontside ''Added 12/15/2021

        If (par_elementQR.WhichSideOfCard = Me.EnumSideOfCard_Current) Then ''Added 12/15/2021

            ''Jan2 2022 td''Dim dummySaveToModel As ClassSaveToModel = Nothing ''This is just a placeholder. 1/2/2022 td
            Const c_proportional As Boolean = True ''Added 1/2/2022 td

            Dim oGetControlParameters As ClassGetElementControlParams ''Added 1/17/2022 thomas d.
            oGetControlParameters = Me.GetParametersToGetElementControl() ''Added 1/17/2022 thomas d.

            Dim sizeDesired As Size = New Size() ''Added 1/26/2022 td

            ''12/30/2021 td''Me.CtlGraphic_QRCode = New CtlGraphicQRCode(par_elementQR, CType(Me, ILayoutFunctions))
            Dim local_ctlGraphic_QRCODE As CtlGraphicQRCode ''Added 5/15/2022 td
            local_ctlGraphic_QRCODE = CtlGraphicQRCode.GetQRCode(oGetControlParameters,
                                                                par_elementQR, Me.DesignerForm,
                                                              "CtlGraphic_QRCode",
                                                              CType(Me, ILayoutFunctions),
                                                              sizeDesired,
                                                              c_proportional,
                                                              mod_ctlLasttouched,
                                                              par_oMoveEvents)
            ''1/2/2022 td''                                   ''Jan2 2022 td''dummySaveToModel,

            ''5/15/2022 td''Me.DesignerForm.Controls.Add(Me.CtlGraphic_QRCode)
            ''5/15/2022 td''mod_listOfDesignerControls.Add(Me.CtlGraphic_QRCode) ''Added 12/8/2021 td
            Me.DesignerForm.Controls.Add(local_ctlGraphic_QRCODE)
            mod_listOfDesignerControls.Add(local_ctlGraphic_QRCODE) ''Added 12/8/2021 td

            ''5/15/2022 With Me.CtlGraphic_QRCode
            With local_ctlGraphic_QRCODE
                ''Me.CtlGraphic_QRCode.Visible = True ''Dec. 7, 2021
                .Visible = True
                .BringToFront() ''Added 5/15/2022 

                ''Dec.8 2021''.Left = elementQRCode.LeftEdge_Pixels
                ''Dec.8 2021''.Top = elementQRCode.TopEdge_Pixels
                .Left = Me.Layout_Margin_Left_Add(par_elementQR.LeftEdge_Pixels)
                .Top = Me.Layout_Margin_Top_Add(par_elementQR.TopEdge_Pixels)

                .Width = par_elementQR.Width_Pixels
                .Height = par_elementQR.Height_Pixels

            End With ''End of "With Me.CtlGraphic_QRCode"

            ''
            ''Moveability 
            ''
            If (Me.LetEventListenerAddMoveability) Then
                ''
                ''See ClassDesignerEventListener.LoadForm_LayoutElements_Moveability() ---12/23/2021
                ''
            ElseIf (Me.LetBaseControlAddMoveability) Then ''--Added 1/5/2022
                ''
                ''The element control's base class will add moveability. --Added 1/5/2022
                ''  (See project/subfolder __RSC_WindowsControlLibrary/RSCMoveableControl)
                ''
            Else
                ''Add moveability - QR Code

                ''Jan11 2022 td''Add_Moveability(CtlGraphic_QRCode, CtlGraphic_QRCode,
                ''                 CtlGraphic_QRCode, True)
                Throw New Exception("Let the control __RSC_WindowsControlLibrary/RSCMoveableControl " +
                                 "be responsible for moveability.--1/11/2022")

            End If ''End of "If (Me.LetEventListenerAddMoveability) Then ... Else ..."

        End If ''End of "If (elementQRCode.WhichSideOfCard = Me.EnumSideOfCard) Then"

    End Sub ''ENd of "Private Sub LoadElementToForm_QRCode"


    Private Sub LoadFormwElements_AllSignatures(par_listElements As HashSet(Of ClassElementSignature),
                                    par_oMoveEvents As GroupMoveEvents_Singleton)
        ''Added 5/5/2022 td
        For Each each_elem As ClassElementSignature In par_listElements
            ''Major call !!
            LoadElementToForm_Signature(each_elem, par_oMoveEvents)

        Next each_elem

    End Sub ''Endof ""Private Sub LoadFormwElements_AllSignatures""


    Public Sub LoadElementToForm_Signature(par_elementSig As ClassElementSignature,
                                       par_oMoveEvents As GroupMoveEvents_Singleton)
        ''5/14/2022 td''Private Sub LoadElements_Signature
        ''
        ''Added 10/12/2019 thomas d. 
        ''
        Const c_proportional As Boolean = True ''Added 1/2/2022 td

        ''Added 1/16/2022 thomas d. 
        ''  Check to see if this badge-side (e.g. frontside, or backside) contains a Signature. 
        If (par_elementSig Is Nothing) Then
            Return ''Added 1/16/2022 td
        End If ''End of "If (par_elementSig Is Nothing) Then"

        Dim oGetControlParameters As ClassGetElementControlParams ''Added 1/17/2022 thomas d.
        oGetControlParameters = Me.GetParametersToGetElementControl() ''Added 1/17/2022 thomas d.

        Dim sizeDesired As New Size() ''Added 1/26/2022 td

        ''10//12/2019 td''CtlGraphic_Signat = New CtlGraphicSignature(par_elementSig, Me)
        ''1/2/2022 td''CtlGraphic_Signat = New CtlGraphicSignature(par_elementSig, Me, Me.PathToSigFile)
        Dim local_ctlGraphic_Signat As CtlGraphicSignature ''Added 5/15/2022 thomas d. 
        local_ctlGraphic_Signat = CtlGraphicSignature.GetSignature(oGetControlParameters,
                                                             par_elementSig, Me.DesignerForm,
                                                             "CtlGraphic_Signat",
                                                CType(Me, ILayoutFunctions), sizeDesired,
                                                c_proportional,
                                                mod_ctlLasttouched, par_oMoveEvents,
                                                Me.PathToSigFile)
        ''1/2/2022 td''              ''Jan2 2022 td''dummySaveToModel,

        Me.DesignerForm.Controls.Add(local_ctlGraphic_Signat)
        local_ctlGraphic_Signat.BringToFront() ''Added 5/15/2022 

        ''Added 11/28/2021 td
        mod_listOfDesignerControls.Add(local_ctlGraphic_Signat)

        With local_ctlGraphic_Signat ''5/15/2022 CtlGraphic_Signat

            ''5/16/2022 .Top = par_elementSig.TopEdge_Pixels
            ''5/16/2022 .Left = par_elementSig.LeftEdge_Pixels

            ''Added 5/16/2022 td
            .Top = Me.Layout_Margin_Top_Add(par_elementSig.TopEdge_Pixels)
            .Left = Me.Layout_Margin_Left_Add(par_elementSig.LeftEdge_Pixels)

            .Width = par_elementSig.Width_Pixels
            .Height = par_elementSig.Height_Pixels

            .pictureSignature.Image = mod_imageExampleSignat

            .Refresh_Master()

        End With ''End of "With local_ctlGraphic_Signat"

        ''Added 12/15/2021 td
        ''   Pass on the event of right-clicking a element-signature control.
        ''   
        ''If (mod_bAddHandlersForRightClick) Then
        ''    AddHandler CtlGraphic_Signat.ElementSig_RightClicked, AddressOf ElementSig_Clicked
        ''End If ''End of "If (mod_bAddHandlersForRightClick) Then"

        ''
        ''Moveability 
        ''
        If (Me.LetEventListenerAddMoveability) Then
            ''
            ''See ClassDesignerEventListener.LoadForm_LayoutElements_Moveability() ---12/23/2021
            ''
        ElseIf (Me.LetBaseControlAddMoveability) Then ''--Added 1/5/2022
            ''
            ''The element control's base class will add moveability. --Added 1/5/2022
            ''  (See project/subfolder __RSC_WindowsControlLibrary/RSCMoveableControl)
            ''
        Else
            ''
            ''Add moveability - Signature
            ''
            ''Jan11 2022''Add_Moveability(CtlGraphic_Signat, CtlGraphic_Signat,
            ''             CtlGraphic_Signat, True)
            Throw New Exception("Let the control __RSC_WindowsControlLibrary/RSCMoveableControl " +
                                 "be responsible for moveability.--1/11/2022")

        End If ''End of "If (Me.LetEventListenerAddMoveability) Then ... Else ..."

    End Sub ''End of "Private Sub LoadElementToForm_Signature"


    Private Sub LoadFormwElements_StaticTextsV3(par_listStaticTexts As HashSet(Of ClassElementStaticTextV3))
        ''5/14/2022  Private Sub LoadElements_StaticTextsV3
        ''
        ''Added 12/18/2021 thomas d. 
        ''
        Dim each_ctlStaticTextV3 As CtlGraphicStaticTextV3 ''Added 1/8/2022 td
        Dim indexControl As Integer = 0 ''Added 1/8/2022 td
        Dim oGetControlParameters As ClassGetElementControlParams ''Added 1/17/2022 thomas d.
        Dim sizeIfNeeded As New Size() ''Added 1/26/2022 thomas d

        oGetControlParameters = Me.GetParametersToGetElementControl() ''Added 1/17/2022 thomas d.

        For Each each_element_staticV3 As ClassElementStaticTextV3 In par_listStaticTexts

            ''Dec18 2021''CtlGraphic_StaticTexts.Add = New CtlGraphicStaticText(each_element_static)
            ''Dec27 2021''CtlGraphic_StaticText_temp = New CtlGraphicStaticText(each_element_static)
            ''Jan8 2022 td''CtlGraphic_StaticText_temp = New CtlGraphicStaticText(each_element_static, Me)

            each_ctlStaticTextV3 = CtlGraphicStaticTextV3.GetStaticText(oGetControlParameters,
                                            each_element_staticV3, Me.DesignerForm,
                    String.Format("CtlGraphicStaticText{0}", indexControl),
                    CType(Me, ILayoutFunctions), sizeIfNeeded,
                    CType(Me, IRefreshCardPreview),
                    mod_ctlLasttouched, mod_oGroupMoveEvents)

            each_ctlStaticTextV3.ParentForm = Me.DesignerForm ''Added 1/16/2022 thomas d.
            ListCtlGraphic_StaticTextsV3.Add(each_ctlStaticTextV3)

            Me.DesignerForm.Controls.Add(each_ctlStaticTextV3)

            ''Added 11/28/2021 td
            mod_listOfDesignerControls.Add(each_ctlStaticTextV3)

            With each_ctlStaticTextV3

                .Visible = True ''Added 5/16/2022 td
                .BringToFront() ''Added 5/16/2022v 

                ''Added 12/18/2021 td
                ''Not needed here. Jan8 2022''.LayoutFunctions = CType(Me, ILayoutFunctions)

                ''5/2022  ''.Top = each_element_staticV3.TopEdge_Pixels
                ''5/2022  ''.Left = each_element_staticV3.LeftEdge_Pixels

                ''5/16/2022 td 
                .Top = Me.Layout_Margin_Top_Add(each_element_staticV3.TopEdge_Pixels)
                .Left = Me.Layout_Margin_Left_Add(each_element_staticV3.LeftEdge_Pixels)

                .Width = each_element_staticV3.Width_Pixels
                .Height = each_element_staticV3.Height_Pixels

                ''.pictureSignature.Image = mod_imageExampleSignat
                .Refresh_Master()

            End With ''End of "With CtlGraphic_StaticText1"

            ''Added 12/15/2021 td
            ''   Pass on the event of right-clicking a element-signature control.
            ''   
            ''If (mod_bAddHandlersForRightClick) Then
            ''    AddHandler each_ctlStaticText.ElementStatic_RightClicked,
            ''         AddressOf ElementStatic_Clicked
            ''End If ''End of "If (mod_bAddHandlersForRightClick) Then"

            ''
            ''Moveability 
            ''
            If (Me.LetEventListenerAddMoveability) Then
                ''
                ''See ClassDesignerEventListener.LoadForm_LayoutElements_Moveability() ---12/23/2021
                ''
            ElseIf (Me.LetBaseControlAddMoveability) Then ''--Added 1/5/2022
                ''
                ''The element control's base class will add moveability. --Added 1/5/2022
                ''  (See project/subfolder __RSC_WindowsControlLibrary/RSCMoveableControl)
                ''
            Else
                ''
                ''Add moveability - Static Texts
                ''
                ''Jan11 2022 td''Const c_boolResizeProportionally As Boolean = False ''Inappropropriate for Static Texts!!

                ''Jan11 2022 td''Add_Moveability(each_ctlStaticText, each_ctlStaticText,
                ''                     each_ctlStaticText,
                ''                     c_boolResizeProportionally)
                Throw New Exception("Let the control __RSC_WindowsControlLibrary/RSCMoveableControl " +
                                 "be responsible for moveability.--1/11/2022")

            End If ''End of "If (Me.LetEventListenerAddMoveability) Then ... Else ..."

        Next each_element_staticV3

    End Sub ''End of "Private Sub LoadFormwElements_StaticTextsV3"


    Private Sub LoadFormwElements_StaticTextsV4(par_listStaticTexts As HashSet(Of ClassElementStaticTextV4))
        ''
        ''Added 1/31/2022 thomas d. 
        ''
        Dim each_ctlStaticTextV4 As CtlGraphicStaticTextV4 ''Added 1/8/2022 td
        Dim indexControl As Integer = 0 ''Added 1/8/2022 td
        Dim oGetControlParameters As ClassGetElementControlParams ''Added 1/17/2022 thomas d.
        Dim sizeIfNeeded As New Size() ''Added 1/26/2022 thomas d

        oGetControlParameters = Me.GetParametersToGetElementControl() ''Added 1/17/2022 thomas d.

        For Each each_element_staticV4 As ClassElementStaticTextV4 In par_listStaticTexts

            ''Dec18 2021''CtlGraphic_StaticTexts.Add = New CtlGraphicStaticText(each_element_static)
            ''Dec27 2021''CtlGraphic_StaticText_temp = New CtlGraphicStaticText(each_element_static)
            ''Jan8 2022 td''CtlGraphic_StaticText_temp = New CtlGraphicStaticText(each_element_static, Me)

            each_ctlStaticTextV4 = CtlGraphicStaticTextV4.GetStaticTextControl(oGetControlParameters,
                                            each_element_staticV4, Me.DesignerForm,
                                            oGetControlParameters.DesignerClass,
                    String.Format("CtlGraphicStaticText{0}", indexControl),
                    CType(Me, ILayoutFunctions), sizeIfNeeded,
                    oGetControlParameters.iRecordElemLastTouched,
                    mod_ctlLasttouched, mod_oGroupMoveEvents)

            each_ctlStaticTextV4.ParentForm = Me.DesignerForm ''Added 1/16/2022 thomas d.
            ListCtlGraphic_StaticTextsV4.Add(each_ctlStaticTextV4)
            Me.DesignerForm.Controls.Add(each_ctlStaticTextV4)
            mod_listOfDesignerControls.Add(each_ctlStaticTextV4)

            With each_ctlStaticTextV4

                .Visible = True ''Added 5/16/2022 td
                .BringToFront() ''Added 5/16/2022v 

                ''Added 12/18/2021 td
                ''Not needed here. Jan8 2022''.LayoutFunctions = CType(Me, ILayoutFunctions)

                ''5/16/2022  .Top = each_element_staticV4.TopEdge_Pixels
                ''5/16/2022  .Left = each_element_staticV4.LeftEdge_Pixels

                ''5/16/2022 td 
                .Top = Me.Layout_Margin_Top_Add(each_element_staticV4.TopEdge_Pixels)
                .Left = Me.Layout_Margin_Left_Add(each_element_staticV4.LeftEdge_Pixels)

                .Width = each_element_staticV4.Width_Pixels
                .Height = each_element_staticV4.Height_Pixels

                ''.pictureSignature.Image = mod_imageExampleSignat
                .Refresh_Master()

            End With ''End of "With CtlGraphic_StaticText1"

            ''
            ''Moveability 
            ''
            If (Me.LetEventListenerAddMoveability) Then
                ''
                ''See ClassDesignerEventListener.LoadForm_LayoutElements_Moveability() ---12/23/2021
                ''
            ElseIf (Me.LetBaseControlAddMoveability) Then ''--Added 1/5/2022
                ''
                ''The element control's base class will add moveability. --Added 1/5/2022
                ''  (See project/subfolder __RSC_WindowsControlLibrary/RSCMoveableControl)
                ''
            Else
                ''
                ''Add moveability - Static Texts
                ''
                Throw New Exception("Let the control __RSC_WindowsControlLibrary/RSCMoveableControl " +
                                 "be responsible for moveability.--1/11/2022")

            End If ''End of "If (Me.LetEventListenerAddMoveability) Then ... Else ..."

        Next each_element_staticV4

    End Sub ''End of "Private Sub LoadFormwElements_StaticTextsV3"


    Private Sub LoadFormwElements_StaticGraphics(par_listStaticGraphics As HashSet(Of ClassElementGraphic))
        ''5/14/2022  Private Sub LoadElements_StaticGraphics
        ''
        ''Added 1/22/2022 thomas d. 
        ''
        Dim each_ctlStaticGraphic As CtlGraphicStaticGraphic ''Added 1/8/2022 td
        Dim indexControl As Integer = 0 ''Added 1/8/2022 td
        Dim oGetControlParameters As ClassGetElementControlParams ''Added 1/17/2022 thomas d.
        Dim sizeGraphic As New Size ''Added 1/26/2022 td

        oGetControlParameters = Me.GetParametersToGetElementControl() ''Added 1/17/2022 thomas d.
        Const c_bProportionalTrue As Boolean = True ''Added 1/26/2022 td

        For Each each_element_static As ClassElementGraphic In par_listStaticGraphics
            ''
            ''Create the graphic control. 
            ''
            each_ctlStaticGraphic = CtlGraphicStaticGraphic.GetStaticGraphic(oGetControlParameters,
                                            each_element_static, Me.DesignerForm,
                    String.Format("CtlGraphicStaticText{0}", indexControl),
                    CType(Me, ILayoutFunctions), sizeGraphic,
                    c_bProportionalTrue, mod_ctlLasttouched, mod_oGroupMoveEvents, False)

            each_ctlStaticGraphic.ParentForm = Me.DesignerForm ''Added 1/16/2022 thomas d.
            ''----ListCtlGraphic_StaticTexts.Add(each_ctlStaticGraphic)

            Me.DesignerForm.Controls.Add(each_ctlStaticGraphic)

            ''Added 11/28/2021 td
            mod_listOfDesignerControls.Add(each_ctlStaticGraphic)

            With each_ctlStaticGraphic

                .Visible = True ''Added 5/16/2022 td
                .BringToFront() ''Added 5/16/2022v 

                ''Added 12/18/2021 td
                ''Not needed here. Jan8 2022''.LayoutFunctions = CType(Me, ILayoutFunctions)

                ''5/16/2022 td .Top = each_element_static.TopEdge_Pixels
                ''5/16/2022 td .Left = each_element_static.LeftEdge_Pixels

                ''5/16/2022 td 
                .Left = Me.Layout_Margin_Left_Add(each_element_static.LeftEdge_Pixels)
                .Top = Me.Layout_Margin_Top_Add(each_element_static.TopEdge_Pixels)

                .Width = each_element_static.Width_Pixels
                .Height = each_element_static.Height_Pixels

                ''.pictureSignature.Image = mod_imageExampleSignat
                .Refresh_Master()

            End With ''End of "With CtlGraphic_StaticText1"

            ''Added 12/15/2021 td
            ''   Pass on the event of right-clicking a element-signature control.
            ''   
            ''If (mod_bAddHandlersForRightClick) Then
            ''    AddHandler each_ctlStaticText.ElementStatic_RightClicked,
            ''         AddressOf ElementStatic_Clicked
            ''End If ''End of "If (mod_bAddHandlersForRightClick) Then"

            ''
            ''Moveability 
            ''
            If (Me.LetEventListenerAddMoveability) Then
                ''
                ''See ClassDesignerEventListener.LoadForm_LayoutElements_Moveability() ---12/23/2021
                ''
            ElseIf (Me.LetBaseControlAddMoveability) Then ''--Added 1/5/2022
                ''
                ''The element control's base class will add moveability. --Added 1/5/2022
                ''  (See project/subfolder __RSC_WindowsControlLibrary/RSCMoveableControl)
                ''
            Else
                ''
                ''Add moveability - Static Texts
                ''
                Const c_boolResizeProportionally As Boolean = False ''Inappropropriate for Static Texts!!

                ''Jan11 2022 td''Add_Moveability(each_ctlStaticText, each_ctlStaticText,
                ''                     each_ctlStaticText,
                ''                     c_boolResizeProportionally)
                Throw New Exception("Let the control __RSC_WindowsControlLibrary/RSCMoveableControl " +
                                 "be responsible for moveability.--1/11/2022")

            End If ''End of "If (Me.LetEventListenerAddMoveability) Then ... Else ..."

        Next each_element_static

    End Sub ''End of "Private Sub LoadFormwElements_StaticGraphics"



    Private Sub Initiate_RubberbandSelector(par_elementControls_All As HashSet(Of RSCMoveableControlVB),
                           par_elementControls_GroupEdit As HashSet(Of RSCMoveableControlVB))

        ''1/12/2022 td''Private Sub Initiate_RubberbandSelector(par_elementControls_All As HashSet(Of CtlGraphicFldLabel),
        ''10/17/2019 td''Private Sub Initiate_RubberbandSelector(par_elementControls_All As HashSet(Of CtlGraphicFldLabel),
        ''10/17/2019 td''     par_elementControls_GroupEdit As HashSet(Of CtlGraphicFldLabel))
        ''9/20 td''Private Sub Initiate_RubberbandSelector() 
        ''
        ''Added 9/8/2019 td
        ''
        mod_rubberbandClass = New ClassRubberbandSelector

        With mod_rubberbandClass

            ''10/1/2019 td''.Me.BackgroundBox = Me.Me.BackgroundBox
            .PictureBack = Me.BackgroundBox_Front

            ''Added 9/20/2019 td  
            .ElementControls_All = par_elementControls_All

            ''Added 9/20/2019 td
            .LayoutFunctions = CType(Me, ILayoutFunctions)

            .ElementControls_GroupEdit = par_elementControls_GroupEdit

            ''AddHandler , AddressOf mod_rubberbandClass.MouseMove
            ''AddHandler .Me.BackgroundBox.MouseMove, AddressOf mod_rubberbandClass.MouseMove
            ''AddHandler .Me.BackgroundBox.MouseMove, AddressOf mod_rubberbandClass.MouseMove
            ''AddHandler .Me.BackgroundBox.MouseMove, AddressOf mod_rubberbandClass.MouseMove

        End With ''end of "With mod_rubberbandClass"

    End Sub ''End of "Private Sub InitiateRubberbandSelector"


    Private Sub LoadElements_FieldElementsV3(par_listElementsV3 As List(Of ClassElementFieldV3),
                               par_boolLoadingForm As Boolean,
                               Optional par_bUnloading As Boolean = False,
                               Optional par_bAddMoveability As Boolean = False,
                                Optional ByRef par_listFieldCtls As HashSet(Of CtlGraphicFieldV3) = Nothing,
                               Optional pstrWhyCalled As String = "")
        ''---Dec21 2021 td''Private Sub LoadFieldControls_ByListOfElements(par_listElements As HashSet(Of ClassElementField), ...
        ''
        ''Added 9/17/2019 thomas downes 
        ''
        Dim intCountControlsAdded As Integer = 0 ''Added 9/03/2019 td 
        Dim boolIncludeOnBadge As Boolean = False ''Added 9/03/2019 td
        Dim intStagger As Integer = 0 ''Added 9.6.2019 td 
        Dim intUndeterminedField As Integer = 0 ''Added 10/13/2019 td  
        Dim dictionaryOfCaptions As New ClassDictionaryOfCaptions() ''Added 12/21/2021 td

        ''9/17/2019 td''For Each each_field As ICIBFieldStandardOrCustom In par_list  
        For Each each_elementV3 As ClassElementFieldV3 In par_listElementsV3

            ''Added 12/21/2021 td
            ''  Let's track the count of the element per repeated caption, e.g. "#4" to make "Last Name #4". 
            each_elementV3.CaptionSuffixIfNeeded = dictionaryOfCaptions.AddCaption_GetSuffix(each_elementV3.FieldNm_CaptionText)

            ''Feb7 2022 td''Dim label_control As CtlGraphicFieldV3
            Dim label_controlV3 As CtlGraphicFieldV3

            ''Added 9/3/2019 thomas d. 
            ''9/17/2019 td''boolIncludeOnBadge = (par_boolLoadingForm And each_element.IsDisplayedOnBadge)

            ''5/11/2022 If (each_elementV3.FieldInfo Is Nothing) Then
            If (each_elementV3.FieldEnum = EnumCIBFields.Undetermined) Then
                intUndeterminedField += 1
            Else
                ''5/11/2022 td ''boolIncludeOnBadge = (par_boolLoadingForm And each_elementV3.FieldInfo.IsDisplayedOnBadge)
                boolIncludeOnBadge = (par_boolLoadingForm And each_elementV3.Visible)
            End If ''END OF "If (each_element.FieldInfo Is Nothing) Then .... Else ...."

            If (Not boolIncludeOnBadge) Then
                ''#1 9/17/2019 td''AddToFlowPanelOfOmittedFlds(each_element)
                '' #2 9/17/2019 td''AddToFlowPanelOfOmittedFlds(each_element.FieldInfo)
                AddToFlowPanelOfOmittedFldsV3(each_elementV3)
                Continue For
            End If ''End of "If (Not boolIncludeOnBadge) Then"

            ''
            ''Added 9/15/2019 td
            ''
            With each_elementV3

                If (0 = .TopEdge_Pixels + .LeftEdge_Pixels) Then

                    .Height_Pixels = 30

                    ''9/6/2019 td''new_element_text.TopEdge_Pixels = (30 + (30 * intCountControlsAdded))
                    intStagger = intCountControlsAdded
                    .TopEdge_Pixels = (intStagger * .Height_Pixels)
                    intCountControlsAdded += 1 ''Added 9/6/2019 td 

                    .LeftEdge_Pixels = .TopEdge_Pixels ''Left = Top !! By setting Left = Top, we will create 
                    ''   a nice diagonally-cascading effect. ---9/3/2019 td

                End If ''end of "If (0 = .Height_Pixels) Then"

                ''Added 9/12/2019 td
                ''10/9/2019 td''.BadgeLayout = New ciBadgeInterfaces.BadgeLayoutClass(Me.BackgroundBox.Width, Me.BackgroundBox.Height)
                .BadgeLayout = Me.BadgeLayout_Class ''Modified 10/9/2019 td  

            End With ''End of ""With each_elementV3""

            ''Added 9/15/2019 td
            With each_elementV3

                ''Added 6/7/2022 thomas
                If (.FontMaxGalkin Is Nothing) Then
                    ''Added 6/7/2022 thomas
                    .FontMaxGalkin = SerializableFontByMaxGalkin.DefaultFont
                    ''6/7/2022 td''.Font_DrawingClass = .FontMaxGalkin.ToFont()
                    .FontDrawingClass = .FontMaxGalkin.ToFont_AnyUnits()
                    .FontFamilyName = .FontMaxGalkin.FontFamily

                    ''6/8/2022 If (.FontMaxGalkin.Graphics_Unit = GraphicsUnit.Pixel) Then ''Is this correct?? ---6/7/2022 
                    ''    ''Should this property (.FontSize_Pixels) be deprecated?  6/2022
                    ''    .FontSize_Pixels = .FontMaxGalkin.Size_Pixels ''6/08/2022 
                    ''End If ''End of ""If (.FontMaxGalkin.Graphics_Unit = GraphicsUnit.Pixel) Then""

                    .FontSize_Pixels = .FontMaxGalkin.Size_Pixels ''6/08/2022 
                    .FontSize_Points = .FontMaxGalkin.Size_Points ''6/08/2022

                    ''Added 6/7/2022
                    .FontBold_Deprecated = (.FontMaxGalkin.Style = FontStyle.Bold)
                    .FontUnderline_Deprecated = (.FontMaxGalkin.Style = FontStyle.Underline)
                    .FontItalics_Deprecated = (.FontMaxGalkin.Style = FontStyle.Italic)

                End If ''End of "If (.FontMaxGalkin Is Nothing) Then"

                ''6/2022 If (.FontFamilyName = "") Then
                If (.FontFamilyName = "" Or .FontFamilyName = "Times New Roman") Then
                    ''6/7/2022 td ''.FontFamilyName = "Times New Roman" ''Added 9/15/2019 thomas d.
                    .FontFamilyName = .FontMaxGalkin.FontFamily
                End If ''End of "If (.FontFamilyName = "") Then"

                If (.FontSize_Pixels = 0) Then
                    ''6/7/2022 td ''.FontSize_Pixels = 25
                    .FontSize_Pixels = .FontMaxGalkin.Size_Pixels
                    .FontSize_Points = .FontMaxGalkin.Size_Points
                End If ''End of "If (.FontSize_Pixels = 0) Then"

                ''Added 9/12/2019 td 
                ''9/12/2019 td''.FontSize_IsLocked = True 
                ''6/02/220 td''If (.FontSize_ScaleToElementRatio = 0) Then
                If (.FontSize_AutoScaleToElementRatio = 0) Then
                    .FontSize_AutoScaleToElementRatio = (.FontSize_Pixels / .Height_Pixels)
                    ''----.FontSize_ScaleToElementYesNo = True
                End If ''End of "If (.FontSize_AutoScaleToElementRatio = 0) Then"

            End With 'End of "With each_element"

            ''Added 9/5/2019 thomas d.
            ''9/11/2019 td''each_field.ElementInfo_Base.LayoutWidth_Pixels = Me.Layout_Width_Pixels()

            ''Not needed. 10/09/2019 td''each_element.BadgeLayout.Width_Pixels = Me.Layout_Width_Pixels()
            ''Not needed. 10/09/2019 td''each_element.BadgeLayout.Height_Pixels = Me.Layout_Height_Pixels

            ''#1 9/4/2019 td''label_control = New CtlGraphicFldLabel(each_field, Me)
            '' #2 9/4/2019 td''label_control = New CtlGraphicFldLabel(each_field, new_element_text, Me)
            ''----label_control = New CtlGraphicFldLabel(each_element, Me)
            ''1/4/2022 td''label_control = New CtlGraphicFldLabel(each_element, Me,
            ''            "WhyWasICreated? LoadFieldControls_ByListOfElements: " & pstrWhyCalled, Me)

            ''Added 1/4/2022 td
            Dim strNameOfControl As String = "Ctl" + each_elementV3.FieldEnum.ToString()

            ''Added 1/17/2022 thomas d. 
            ''Jan17''Dim oGetControlParameters As New ClassGetElementControlParams
            ''Jan17''oGetControlParameters.ElementsCacheManager = ElementsCache_Manager
            Dim oGetControlParameters As ClassGetElementControlParams ''Added 1/17/2022 thomas d.
            oGetControlParameters = Me.GetParametersToGetElementControl() ''Added 1/17/2022 thomas d.

            Dim sizeNeeded As New Size() ''Added 1/26/2022 td

            ''
            ''Get the new Field-Element Control. 
            ''
            label_controlV3 = CtlGraphicFieldV3.GetFieldElement(oGetControlParameters,
                                                               each_elementV3, Me.DesignerForm, Me,
                                                               strNameOfControl,
                                                        CType(Me, ILayoutFunctions),
                                                        sizeNeeded,
                                                        CType(Me, IRecordElementLastTouched),
                                                        mod_ctlLasttouched,
                                                        mod_oGroupMoveEvents)

            ''Moved below. 9/5 td''label_control.Refresh_Master()
            ''5/11/2022 td''label_controlV3.Visible = each_elementV3.FieldInfo.IsDisplayedOnBadge ''BL = Badge Layout
            label_controlV3.Visible = each_elementV3.Visible ''BL = Badge Layout
            intCountControlsAdded += 1
            label_controlV3.Name = "FieldControl" & CStr(intCountControlsAdded)

            ''Added 10/1/2019 td
            ''   Pass on the event of right-clicking a element-field control. 
            ''
            ''If (mod_bAddHandlersForRightClick) Then
            ''    AddHandler label_control.ElementField_RightClicked, AddressOf ElementField_Clicked
            ''End If ''End of "If (mod_bAddHandlersForRightClick) Then"

            ''9/8 td''label_control.BorderStyle = BorderStyle.FixedSingle

            ''Added 9/6/2019 thomas downes 
            ''
            ''   Stagger the elements on the badge layout, in a cascade from
            '' the upper-left to the lower-right. 
            '' ------9/6/2019 td
            ''
            If (0 = each_elementV3.TopEdge_Pixels) Then
                ''Added 9/6/2019 thomas downes 
                label_controlV3.Width = CInt(Me.BackgroundBox_Front.Width / 3)
                With each_elementV3
                    .Width_Pixels = label_controlV3.Width
                    .Height_Pixels = label_controlV3.Height
                    intStagger = intCountControlsAdded
                    .TopEdge_Pixels = (intStagger * .Height_Pixels)
                    .LeftEdge_Pixels = .TopEdge_Pixels ''Left = Top !! By setting Left = Top, we will create 
                    ''   a nice diagonally-cascading effect. ---9/3/2019 td
                    ''See above. 9/6/2019 td''intCountControlsAdded += 1 ''Added 9/6/2019 td 
                End With ''End of " With each_field.ElementInfo_Base"
            End If ''ENd of "If (0 = each_field.ElementInfo_Base.TopEdge_Pixels) Then"

            ''5/11/2022 td''boolIncludeOnBadge = (par_boolLoadingForm And each_elementV3.FieldInfo.IsDisplayedOnBadge)
            boolIncludeOnBadge = (par_boolLoadingForm And each_elementV3.Visible)

            If (boolIncludeOnBadge) Then

                Me.DesignerForm.Controls.Add(label_controlV3)
                par_listFieldCtls.Add(label_controlV3) ''Added 9/20/2019 td

                ''Added 11/28/2021 td
                mod_listOfDesignerControls.Add(label_controlV3)

                label_controlV3.Visible = True
                label_controlV3.BringToFront() ''Added 9/7/2019 thomas d.  
                ''9/5/2019''label_control.Refresh_Image(True)
                label_controlV3.GroupEdits = CType(Me, ISelectingElements) ''Added 8/1 td

                ''Added 9/7/2019 td
                label_controlV3.Left = Me.Layout_Margin_Left_Add(each_elementV3.LeftEdge_Pixels)
                label_controlV3.Top = Me.Layout_Margin_Top_Add(each_elementV3.TopEdge_Pixels)

                ''
                ''Major call !!  ----Thomas DOWNES
                ''
                label_controlV3.Refresh_Master()
                label_controlV3.Refresh() ''Added 11/29/2021 td  

                ''''Added 9/8/2019 td
                ''If (par_bAddMoveability) Then ControlMoverResizer_AddFieldCtl(label_control)

            ElseIf (par_bUnloading) Then
                ''9/3/2019 td''Me.Controls.Remove(label_control)
                Throw New NotImplementedException

            End If ''End of "If (boolInludeOnBadge) Then .... ElseIf (....) ...."

        Next each_elementV3

        ''
        ''Added 8/27/2019 thomas downes
        ''
        Me.BackgroundBox_Front.SendToBack() ''Added 9/7/2019 thomas d.
        Me.BackgroundBox_JustAButton.SendToBack() ''Added 1/21/2022 td

        ''10/1/2019 td''Me.Refresh() ''Added 8/28/2019 td   
        Me.DesignerForm.Refresh() ''Added 8/28/2019 td   

        ''9/5/2019 td''MessageBox.Show($"Number of field controls now on the form: {intCountControlsAdded}", "",
        ''     MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub ''End of ''Private Sub LoadElements_FieldElementsV3()''


    Private Sub LoadElements_FieldElementsV4(par_listElementsV4 As List(Of ClassElementFieldV4),
                               par_boolLoadingForm As Boolean,
                               Optional par_bUnloading As Boolean = False,
                               Optional par_bAddMoveability As Boolean = False,
                                Optional ByRef par_listFieldCtls As HashSet(Of CtlGraphicFieldV4) = Nothing,
                               Optional pstrWhyCalled As String = "")
        ''
        ''Added 2/07/2022 thomas downes 
        ''
        Dim intCountControlsAdded As Integer = 0 ''Added 9/03/2019 td 
        Dim boolIncludeOnBadge As Boolean = False ''Added 9/03/2019 td
        Dim intStagger As Integer = 0 ''Added 9.6.2019 td 
        Dim intUndeterminedField As Integer = 0 ''Added 10/13/2019 td  
        Dim dictionaryOfCaptions As New ClassDictionaryOfCaptions() ''Added 12/21/2021 td

        For Each each_elementV4 As ClassElementFieldV4 In par_listElementsV4

            ''  Let's track the count of the element per repeated caption, e.g. "#4" to make "Last Name #4". 
            each_elementV4.CaptionSuffixIfNeeded =
                dictionaryOfCaptions.AddCaption_GetSuffix(each_elementV4.FieldNameCaptionText)

            Dim label_controlV4 As CtlGraphicFieldV4

            ''5/2022 If (each_elementV4.FieldInfo Is Nothing) Then
            If (each_elementV4.FieldEnum = EnumCIBFields.Undetermined) Then
                intUndeterminedField += 1
            Else
                ''5/11/2022 boolIncludeOnBadge = (par_boolLoadingForm And each_elementV4.FieldInfo.IsDisplayedOnBadge)
                boolIncludeOnBadge = (par_boolLoadingForm And each_elementV4.Visible)
            End If ''END OF "If (each_elementV4.FieldInfo Is Nothing) Then .... Else ...."

            If (Not boolIncludeOnBadge) Then
                AddToFlowPanelOfOmittedFldsV4(each_elementV4)
                Continue For
            End If ''End of "If (Not boolIncludeOnBadge) Then"

            ''
            ''Added 9/15/2019 td
            ''
            With each_elementV4

                If (0 = .TopEdge_Pixels + .LeftEdge_Pixels) Then

                    .Height_Pixels = 30
                    intStagger = intCountControlsAdded
                    .TopEdge_Pixels = (intStagger * .Height_Pixels)
                    intCountControlsAdded += 1 ''Added 9/6/2019 td 
                    .LeftEdge_Pixels = .TopEdge_Pixels ''Left = Top !! By setting Left = Top, we will create 
                    ''   a nice diagonally-cascading effect. ---9/3/2019 td

                End If ''end of "If (0 = .Height_Pixels) Then"

                .BadgeLayout = Me.BadgeLayout_Class ''Modified 10/9/2019 td  

                If (.FontFamilyName = "") Then
                    .FontFamilyName = "Times New Roman" ''Added 9/15/2019 thomas d. 
                End If ''End of "If (.FontFamilyName = "") Then"

                If (.FontSize_Pixels = 0) Then
                    .FontSize_Pixels = 25
                End If ''End of "If (.FontSize_Pixels = 0) Then"

                ''---June2 2022---If (.FontSize_ScaleToElementRatio = 0) Then
                If (.FontSize_AutoScaleToElementRatio = 0) Then
                    .FontSize_AutoScaleToElementRatio = (.FontSize_Pixels / .Height_Pixels)
                    ''----.FontSize_ScaleToElementYesNo = True
                End If ''End of "If (.FontSize_ScaleToElementRatio = 0) Then"

            End With 'End of "With each_elementV4"

            Dim strNameOfControl As String = "Ctl" + each_elementV4.FieldEnum.ToString()
            Dim oGetControlParameters As ClassGetElementControlParams ''Added 1/17/2022 thomas d.
            oGetControlParameters = Me.GetParametersToGetElementControl() ''Added 1/17/2022 thomas d.

            Dim sizeNeeded As New Size() ''Added 1/26/2022 td

            ''
            ''Get the new Field Element. 
            ''
            label_controlV4 = CtlGraphicFieldV4.GetFieldControl(oGetControlParameters,
                                            each_elementV4, Me.DesignerForm, Me,
                                            strNameOfControl,
                                    CType(Me, ILayoutFunctions),
                                    sizeNeeded,
                                    CType(Me, IRecordElementLastTouched),
                                    mod_ctlLasttouched,
                                    mod_oGroupMoveEvents)

            ''5/11/2022 td''label_controlV4.Visible = each_elementV4.FieldInfo.IsDisplayedOnBadge ''BL = Badge Layout
            label_controlV4.Visible = each_elementV4.Visible ''BL = Badge Layout
            intCountControlsAdded += 1
            label_controlV4.Name = "FieldControl" & CStr(intCountControlsAdded)

            ''
            ''   Stagger the elements on the badge layout, in a cascade from
            '' the upper-left to the lower-right. 
            '' ------9/6/2019 td
            ''
            If (0 = each_elementV4.TopEdge_Pixels) Then
                ''Added 9/6/2019 thomas downes 
                label_controlV4.Width = CInt(Me.BackgroundBox_Front.Width / 3)
                With each_elementV4
                    .Width_Pixels = label_controlV4.Width
                    .Height_Pixels = label_controlV4.Height
                    intStagger = intCountControlsAdded
                    .TopEdge_Pixels = (intStagger * .Height_Pixels)
                    .LeftEdge_Pixels = .TopEdge_Pixels ''Left = Top !! By setting Left = Top, we will create 
                    ''   a nice diagonally-cascading effect. ---9/3/2019 td
                    ''See above. 9/6/2019 td''intCountControlsAdded += 1 ''Added 9/6/2019 td 
                End With ''End of " With each_field.ElementInfo_Base"
            End If ''ENd of "If (0 = each_field.ElementInfo_Base.TopEdge_Pixels) Then"

            ''5/11/2022 boolIncludeOnBadge = (par_boolLoadingForm And each_elementV4.FieldInfo.IsDisplayedOnBadge)
            boolIncludeOnBadge = (par_boolLoadingForm And each_elementV4.Visible)

            If (boolIncludeOnBadge) Then

                Me.DesignerForm.Controls.Add(label_controlV4)
                par_listFieldCtls.Add(label_controlV4) ''Added 9/20/2019 td

                ''Added 11/28/2021 td
                mod_listOfDesignerControls.Add(label_controlV4)

                label_controlV4.Visible = True
                label_controlV4.BringToFront() ''Added 9/7/2019 thomas d.  
                ''9/5/2019''label_control.Refresh_Image(True)
                label_controlV4.GroupEdits = CType(Me, ISelectingElements) ''Added 8/1 td

                ''Added 9/7/2019 td
                label_controlV4.Left = Me.Layout_Margin_Left_Add(each_elementV4.LeftEdge_Pixels)
                label_controlV4.Top = Me.Layout_Margin_Top_Add(each_elementV4.TopEdge_Pixels)

                ''
                ''Major call !!  ----Thomas DOWNES
                ''
                label_controlV4.Refresh_Master()
                label_controlV4.Refresh() ''Added 11/29/2021 td  

                ''''Added 9/8/2019 td
                ''If (par_bAddMoveability) Then ControlMoverResizer_AddFieldCtl(label_control)

            ElseIf (par_bUnloading) Then
                ''9/3/2019 td''Me.Controls.Remove(label_control)
                Throw New NotImplementedException

            End If ''End of "If (boolInludeOnBadge) Then .... ElseIf (....) ...."

        Next each_elementV4

        ''
        ''Added 8/27/2019 thomas downes
        ''
        Me.BackgroundBox_Front.SendToBack() ''Added 9/7/2019 thomas d.
        Me.BackgroundBox_JustAButton.SendToBack() ''Added 1/21/2022 td
        Me.DesignerForm.Refresh() ''Added 8/28/2019 td   

    End Sub ''End of ''Private Sub LoadElements_ByListOfElementsV4()''


    Public Sub LoadFieldControlIntoForm_JustOneV3(par_elementField As ClassElementFieldV3)
        ''5/14/2022  Public Sub LoadFieldControl_JustOneV3 
        ''
        ''Added 9/17/2019 thomas d.  
        ''
        ''10/17 td''Dim new_list As New List(Of ClassElementField)
        ''1/8/2022 td''Dim new_list As New HashSet(Of ClassElementField)

        Dim new_list As New List(Of ClassElementFieldV3)

        Const c_bAddToMoveableClass As Boolean = True ''Added 9/8/2019 td 

        new_list.Add(par_elementField)

        ''9/24/2019 td''LoadFieldControls_ByListOfElements(new_list, True, False, c_bAddToMoveableClass)
        LoadElements_FieldElementsV3(new_list, True, False, c_bAddToMoveableClass, mod_listOfFieldControlsV3)

    End Sub ''End of "Public Sub LoadFieldControlIntoForm_JustOneV3(par_elementField As ClassElementFieldV3)"


    Private Sub LoadFieldControlIntoForm_JustOneV4(par_elementField As ClassElementFieldV4)
        ''
        ''Added 9/17/2019 thomas d.  
        ''
        Dim new_list As New List(Of ClassElementFieldV4)
        Const c_bAddToMoveableClass As Boolean = True ''Added 9/8/2019 td 
        new_list.Add(par_elementField)
        LoadElements_FieldElementsV4(new_list, True, False, c_bAddToMoveableClass, mod_listOfFieldControlsV4)

    End Sub ''End of "Private Sub LoadFieldControlIntoForm_JustOneV3(par_elementField As ClassElementFieldV4)"



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

    Private Sub AddToFlowPanelOfOmittedFldsV3(par_elementFieldV3 As ClassElementFieldV3)
        ''
        ''Added 9/17/2019 td
        ''
        Dim new_linkLabel As New LinkLabel

        ''5/11/2022''If (par_elementFieldV3.FieldInfo Is Nothing) Then Exit Sub ''Added 10/13/2019 td
        If (par_elementFieldV3.FieldEnum = EnumCIBFields.Undetermined) Then Exit Sub ''Added 10/13/2019 td

        new_linkLabel.Tag = par_elementFieldV3
        ''5/11/2022 ''new_linkLabel.Text = par_elementFieldV3.FieldInfo.FieldLabelCaption
        new_linkLabel.Text = par_elementFieldV3.FieldEnum.ToString()
        FlowFieldsNotListed.Controls.Add(new_linkLabel)
        new_linkLabel.Visible = True
        AddHandler new_linkLabel.LinkClicked, AddressOf AddField_LinkClicked

    End Sub ''End of "Private Sub AddToFlowPanelOfOmittedFldsV3(par_elementField As ClassElementField)"


    Private Sub AddToFlowPanelOfOmittedFldsV4(par_elementFieldV4 As ClassElementFieldV4)
        ''
        ''Added 2/07/2022 td
        ''
        Dim new_linkLabel As New LinkLabel
        ''5/2022 If (par_elementFieldV4.FieldInfo Is Nothing) Then Exit Sub ''Added 10/13/2019 td
        If (par_elementFieldV4.FieldEnum = EnumCIBFields.Undetermined) Then Exit Sub ''Added 10/13/2019 td
        new_linkLabel.Tag = par_elementFieldV4
        ''5/2022 new_linkLabel.Text = par_elementFieldV4.FieldInfo.FieldLabelCaption
        new_linkLabel.Text = par_elementFieldV4.FieldEnum.ToString()
        FlowFieldsNotListed.Controls.Add(new_linkLabel)
        new_linkLabel.Visible = True
        AddHandler new_linkLabel.LinkClicked, AddressOf AddField_LinkClicked

    End Sub ''End of "Private Sub AddToFlowPanelOfOmittedFldsV4(par_elementField As ClassElementField)"


    Private Sub AddField_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) ''9/7/2019 td''Handles linkSaveAndRefresh.LinkClicked
        ''
        ''Added 9/7/2019 thomas d
        ''
        ''9/17/2019 td''Dim field_to_add As ICIBFieldStandardOrCustom
        ''9/17/2019 td''field_to_add = CType(CType(sender, LinkLabel).Tag, ICIBFieldStandardOrCustom)
        ''9/17/2019 td''If (field_to_add Is Nothing) Then Exit Sub
        ''9/17/2019 td''field_to_add.IsDisplayedOnBadge = True
        ''9/17/2019 td''LoadField_JustOne(field_to_add)

        Dim element_to_add As ClassElementFieldV3 ''Added 9/17/2019 td
        element_to_add = CType(CType(sender, LinkLabel).Tag, ClassElementFieldV3)
        If (element_to_add Is Nothing) Then Exit Sub
        ''5/11/2022 td''element_to_add.FieldInfo.IsDisplayedOnBadge = True
        element_to_add.Visible = True

        ''5/14/2022 LoadFieldControl_JustOneV3(element_to_add) ''Modified 9/17/2019 td
        LoadFieldControlIntoForm_JustOneV3(element_to_add) ''Modified 9/17/2019 td

        FlowFieldsNotListed.Controls.Remove(CType(sender, LinkLabel))

    End Sub ''End of "Private Sub AddField_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)"

    Public Sub SaveLayout(par_bSerializeToDisk As Boolean)
        ''
        ''Added 7/29/2019 td
        ''
        Me.DesignerForm.UseWaitCursor = True

        Dim each_ctl_field As CtlGraphicFieldV3
        Dim each_ctl_portrait As CtlGraphicPortrait ''Added 7/31/2019 td
        ''10/14 td''Dim each_ctl_qrcode As CtlGraphicQRCode ''Added 10/14/2019 td
        ''10/14 td''Dim each_ctl_signat As CtlGraphicSignature ''Added 10/14/2019 td
        Dim each_element_field As ClassElementFieldV3 ''Added 10/14/2019 thomas d.  
        Dim each_infoSaveToModel As ISaveToModel ''Added 1/5/2022 td

        ''Added 10/14/2019 td 
        ''See the For Each loop, Step #1a, below.---1/5/2022 td''Me.CtlGraphic_Portrait.SaveToModel()
        ''See the For Each loop, Step #1a, below.---1/5/2022 td''Me.CtlGraphic_QRCode.SaveToModel()
        ''See the For Each loop, Step #1a, below.---1/5/2022 td''Me.CtlGraphic_Signat.SaveToModel()
        ''See the For Each loop, Step #1a, below.---1/5/2022 td''Me.CtlGraphic_StaticText_temp.SaveToModel() ''Added 12/16/2021 thomas downes

        ''
        ''Step #1 of 2. 
        ''
        For Each each_control As Control In Me.DesignerForm.Controls
            ''
            ''Step #1a. Save the control's position to its corresponding 
            ''   element object. ----1/5/2022 td
            ''
            If (TypeOf each_control Is ISaveToModel) Then
                each_infoSaveToModel = CType(each_control, ISaveToModel)
                each_infoSaveToModel.SaveToModel()
            End If ''End of "If (TypeOf each_control Is ISaveToModel) Then"

            ''
            ''Step #1b. Clear any highlighting. 
            ''
            If (TypeOf each_control Is CtlGraphicFieldV3) Then

                each_ctl_field = CType(each_control, CtlGraphicFieldV3)
                each_ctl_field.SelectedHighlighting_Denigrated = False ''Clear any/all highlighting. ---Added 10/14/2019 td

                each_element_field = each_ctl_field.ElementClass_ObjV3 ''Added 10/14/2019 td 

                ''Clear any/all highlighting.  ---10/14/2019 td 
                With each_element_field
                    If (.SelectedHighlighting) Then
                        ''Clear any/all highlighting.  ---10/14/2019 td 
                        .SelectedHighlighting = False ''Added 10/14/2019 td
                        ''Redraw without highlighting. ---10/14 td
                        each_ctl_field.Refresh_ImageV3(False)
                    End If ''end of "If (.SelectedHighlighting) Then"
                End With

                each_ctl_field.SaveToModel()

            ElseIf (TypeOf each_control Is CtlGraphicPortrait) Then
                ''
                ''Added 7/31/2019 thomas downes  
                ''
                each_ctl_portrait = CType(each_control, CtlGraphicPortrait)
                each_ctl_portrait.SaveToModel()

            End If ''end of "If (TypeOf each_control Is GraphicFieldLabel) Then .... ElseIf ..."

        Next each_control

        ''
        ''
        ''Step #2 of 3.
        ''
        ''   Create a clone of the current-latest edits. 
        ''
        ''Dec14 2021 td''Me.ElementsCache_Saved = Me.ElementsCache_Edits.Copy()
        ''Const c_boolUseDeprecatedFun As Boolean = False
        ''If (c_boolUseDeprecatedFun) Then
        ''    Me.ElementsCache_Saved = Me.ElementsCache_UseEdits.Copy_Deprecated()
        ''ElseIf (Not par_bSerializeToDisk) Then
        ''    ''Not sure, but I think maybe we need to use the Copy_Deprecated() procedure,
        ''    ''  since we won't be saving to a (permanent) disk file.
        ''    ''I wonder, we might instead save to a temporary disk file, de-serialize 
        ''    ''  from the temporary disk file, and then delete that temporary disk file.
        ''    ''   ---12/14/2021 td 
        ''    Me.ElementsCache_Saved = Me.ElementsCache_UseEdits.Copy_Deprecated()
        ''Else
        ''    Me.ElementsCache_Saved = Nothing
        ''End If

        ''Added 10/13/2019 td
        ''Moved to bottom of this procedure. 12/14/2021''Me.DesignerForm_Interface.RefreshElementsCache_Saved(Me.ElementsCache_Saved)

        ''
        ''Step #3 of 3
        ''
        ''   Serialize !!!
        ''
        If (par_bSerializeToDisk) Then

            ''Encapsulated 12/14/2021 td
            ''1/13/2022 td''Me.ElementsCache_Manager.Save(par_bSerializeToDisk)
            Me.ElementsCache_Manager.Save(par_bSerializeToDisk, "", Me.PreviewBox.Image)

            ''Dim objSerializationClass As New ciBadgeSerialize.ClassSerial
            ''
            ''With objSerializationClass
            ''
            ''    ''.TypeOfObject = (TypeOf List(Of ICIBFieldStandardOrCustom))
            ''
            ''    ''10/10/2019 td''SaveFileDialog1.ShowDialog()
            ''    ''10/10/2019 td''.PathToXML = SaveFileDialog1.FileName
            ''
            ''    ''10/13/2019 td''.PathToXML = Me.ElementsCache_Saved.PathToXml_Saved
            ''    .PathToXML = Me.ElementsCache_Edits.PathToXml_Saved
            ''
            ''    ''Added 9/24/2019 thomas 
            ''    .SerializeToXML(Me.ElementsCache_Edits.GetType, Me.ElementsCache_Edits, False, True)
            ''
            ''    Const c_SerializeToBinary As Boolean = False ''Added 9/30/2019 td
            ''    If (c_SerializeToBinary) Then _
            ''    .SerializeToBinary(Me.ElementsCache_Edits.GetType, Me.ElementsCache_Edits)
            ''
            ''End With ''End of "With objSerializationClass"

        End If ''End of "If (par_bSerializeToDisk) Then"

        ''
        ''If appropriate, de-serialize to the "Saved" cache. 
        ''
        ''-----Dec.14 2021---Me.ElementsCache_Saved = Me.ElementsCache_Manager.LoadCache....

        ''Added 12/3/2021 td
        Me.DesignerForm.UseWaitCursor = False

        ''Moved from above on 12/14/2021 td
        ''  Added 10/13/2019 td
        ''Obselete. ---12/14/2021 td''Me.DesignerForm_Interface.RefreshElementsCache_Saved(Me.ElementsCache_UseEdits)

    End Sub ''End of "PRivate Sub SaveLayout()"  

    Private Sub SaveControlPositionsToElement(Optional par_ctlElement As Control = Nothing)
        ''
        ''Save location & sizing data each element that corresponds to each designer control.
        ''  ----10/10/2019 td 
        ''
        Dim each_graphicalFieldCtl As CtlGraphicFieldV3 ''Added 10/10/2019 td
        Dim each_portraitControl As CtlGraphicPortrait ''Added 10/10/2019 td

        Dim each_ctl_QRCode As CtlGraphicQRCode ''Added 10/14/2019 td
        Dim each_ctl_Signat As CtlGraphicSignature ''Added 10/14/2019 td
        Dim each_ctl_Text As CtlGraphicStaticTextV3 ''Added 10/14/2019 td

        If (par_ctlElement IsNot Nothing) Then
            ''
            ''Save the position of the specified control.  
            ''
            If (TypeOf par_ctlElement Is CtlGraphicFieldV3) Then
                ''
                ''Save the Top & Left positional information, for example. 
                ''
                each_graphicalFieldCtl = CType(par_ctlElement, CtlGraphicFieldV3)
                each_graphicalFieldCtl.SaveToModel()
                ''Added 11/29/2021 td  
                each_graphicalFieldCtl.DatetimeSaved = DateTime.Now

            ElseIf (TypeOf par_ctlElement Is CtlGraphicPortrait) Then
                each_portraitControl = CType(par_ctlElement, CtlGraphicPortrait)
                each_portraitControl.SaveToModel()
            ElseIf (TypeOf par_ctlElement Is CtlGraphicQRCode) Then
                each_ctl_QRCode = CType(par_ctlElement, CtlGraphicQRCode)
                each_ctl_QRCode.SaveToModel()
            ElseIf (TypeOf par_ctlElement Is CtlGraphicSignature) Then
                each_ctl_Signat = CType(par_ctlElement, CtlGraphicSignature)
                each_ctl_Signat.SaveToModel()
            ElseIf (TypeOf par_ctlElement Is CtlGraphicStaticTextV3) Then
                each_ctl_Text = CType(par_ctlElement, CtlGraphicStaticTextV3)
                each_ctl_Text.SaveToModel()
            End If

        Else
            ''
            ''Save the position of _all_ the moveable controls. 
            ''
            ''---For Each each_control As Control In Me.DesignerForm.Controls
            For Each each_control As Control In mod_listOfDesignerControls

                If (TypeOf each_control Is CtlGraphicFieldV3) Then

                    each_graphicalFieldCtl = CType(each_control, CtlGraphicFieldV3)
                    each_graphicalFieldCtl.SaveToModel()

                ElseIf (TypeOf each_control Is CtlGraphicPortrait) Then
                    ''
                    ''Added 7/31/2019 thomas downes  
                    ''
                    each_portraitControl = CType(each_control, CtlGraphicPortrait)
                    each_portraitControl.SaveToModel()

                ElseIf (TypeOf each_control Is CtlGraphicQRCode) Then
                    ''Added 10/14/2019 thomas downes  
                    each_ctl_QRCode = CType(each_control, CtlGraphicQRCode)
                    each_ctl_QRCode.SaveToModel()

                ElseIf (TypeOf each_control Is CtlGraphicQRCode) Then
                    ''Added 10/14/2019 thomas downes  
                    each_ctl_Signat = CType(each_control, CtlGraphicSignature)
                    each_ctl_Signat.SaveToModel()

                ElseIf (TypeOf each_control Is CtlGraphicStaticTextV3) Then
                    ''Added 10/14/2019 thomas downes  
                    each_ctl_Text = CType(each_control, CtlGraphicStaticTextV3)
                    each_ctl_Text.SaveToModel()

                End If ''end of "If (TypeOf each_control Is GraphicFieldLabel) Then .... ElseIf ..."

            Next each_control

        End If ''end of "If (par_ctlElement IsNot Nothing) Then ... Else ..."

    End Sub ''End of "Private Sub SaveControlPositionsToElement()"


    Public Sub RefreshPreview_CurrentSide(Optional par_recentlyMovedV3 As ClassElementFieldV3 = Nothing,
                                          Optional par_recentlyMovedV4 As ClassElementFieldV4 = Nothing,
                                    Optional par_recipient As ciBadgeRecipients.ClassRecipient = Nothing)
        ''
        ''Created 1/13/2022 thomas downes
        ''
        Dim objBadgeSide As ClassBadgeSideLayoutV1
        Dim enum_CurrentSide As EnumWhichSideOfCard

        enum_CurrentSide = Me.EnumSideOfCard_Current

        If (Me.DontAutoRefreshPreview) Then
            ''
            ''Either the Preview-Badge feature might be temporarily out of comission,
            ''   or it simply doesn't apply on the present Windows dialog or form.
            ''   ----3/11/2022 td
            ''

        Else

            ''5/20/2022 objBadgeSide = Me.ElementsCache_UseEdits.GetAllBadgeSideLayoutElements(Me.EnumSideOfCard_Current)
            objBadgeSide = Me.ElementsCache_UseEdits.GetAllBadgeSideLayoutElements(Me.EnumSideOfCard_Current,
                   Me.BadgeLayout_Class)

            ''
            ''Major call!! 
            ''
            ''8/1/2022 RefreshPreview_EitherSide(enum_CurrentSide, objBadgeSide,
            ''                          par_recentlyMoved,
            ''                          par_recipient)
            RefreshPreview_EitherSide(enum_CurrentSide, objBadgeSide,
                                      par_recentlyMovedV3,
                                      par_recentlyMovedV4,
                                      par_recipient)

        End If ''End of "If (Me.DontRefreshPreview) Then .... Else..."

    End Sub ''End of ""Public Sub RefreshPreview_CurrentSide()""


    Public Sub RefreshPreview_EitherSide(par_enumCurrentSide As EnumWhichSideOfCard,
                                        par_objMakeBadgeElements As ClassBadgeSideLayoutV1,
                                         Optional par_recentlyMovedV3 As ClassElementFieldV3 = Nothing,
                                         Optional par_recentlyMovedV4 As ClassElementFieldV4 = Nothing,
                                         Optional par_recipient As ciBadgeRecipients.ClassRecipient = Nothing,
                                         Optional pboolReturnImage As Boolean = False,
                                         Optional par_badgeLayout As BadgeLayoutDimensionsClass = Nothing,
                                         Optional ByRef pref_image As Drawing.Image = Nothing,
                                         Optional par_elementBaseToOmit As ClassElementBase = Nothing)
        ''
        ''Stubbed 12/27/2021
        ''
        ''Optional parameter "par_elementBaseToOmit" allows us to focus on individual elements
        ''   against a background which includes visual/non-editable (image only) versions of 
        ''   all other elements (which are not currently being edited).  
        ''   ---8/1/2022 td
        ''
        ''Parameters added 8/01/2022....
        ''     Optional pboolReturnImage As Boolean = False,
        ''     Optional pref_image As Drawing.Image = Nothing,
        ''     Optional par_elementToOmit As ClassElementBase = Nothing)
        ''
        ''--Jan13 2022--RefreshPreview_Redux_Front(par_recentlyMoved, par_recipient)

        Const c_bLetsCloneBackgroundImage As Boolean = False ''Was false "de facto". Added 5/23/2022 

        Dim objPrintLibElems As New ciLayoutPrintLib.LayoutElements
        Dim listOfTextImages As New HashSet(Of Image) ''Added 8/26/2019 thomas downes 
        ''Jan13 2022 ''Dim listOfElementTextFields As HashSet(Of ClassElementField)
        ''Jan13 2022 ''Dim listOfElementStaticTexts As HashSet(Of ClassElementStaticText) ''Added 1/8/2022 td
        ''Jan13 2022 ''Dim listOfElementGraphics As HashSet(Of ClassElementGraphic) ''Added 1/8/2022 td

        Dim obj_image As Image ''Added 8/24 td
        Dim obj_image_clone As Image ''Added 8/24 td
        Dim obj_image_clone_resized As Image ''Added 8/24/2019 td
        Dim bBacksideOfCard As Boolean ''Added 12/10/2021 thomas downes
        Dim bUseBadgeLayoutForBackground As Boolean ''Added 8/2/2022 td
        Dim intPixelsOfBadgeWidth As Integer ''Added 8/02/2022 td
        Dim intPixelsOfBadgeHeight As Integer ''Added 8/02/2022 td
        Dim bIgnorePreviewBox As Boolean ''Added 8/2/2022 td

        ''May 21, 2022 ''Static obj_generator As ciBadgeGenerator.ClassMakeBadge
        Static obj_generator As ciBadgeGenerator.ClassMakeBadge2022

        ''Jan13 2022''Dim bMatchesElementInCache As Boolean ''Added 11/30/2021 thomas d.
        ''Jan13 2022''Dim intCountMatchedElements As Integer ''Added 11/30/2021 thomas d.

        ''May 21, 2022''If (obj_generator Is Nothing) Then obj_generator = New ciBadgeGenerator.ClassMakeBadge
        If (obj_generator Is Nothing) Then obj_generator = New ciBadgeGenerator.ClassMakeBadge2022

        obj_generator.PathToFile_Sig = Me.PathToSigFile ''Added 10/12/2019 td

        ''
        ''QR Code 
        ''
        Dim local_ctlGraphicQRCode As CtlGraphicQRCode ''Added 5/15/2022
        local_ctlGraphicQRCode = Me.CtlGraphic_QRCode_1st() ''Added 5/15/2022
        ''5/15/2022 td'' If (par_objMakeBadgeElements.ElementQRCode_1st IsNot Nothing) Then ''Added 1/24/2022 td
        If (local_ctlGraphicQRCode IsNot Nothing) Then ''Added 1/24/2022 td
            obj_generator.ImageQRCode = local_ctlGraphicQRCode.pictureQRCode.Image ''Added 10/14 td
        End If ''ENd of "If (CtlGraphic_QRCode IsNot Nothing) Then"
        ''5/15/2022 td'' End If ''End of "If (par_objMakeBadgeElements.ElementQRCode_1st IsNot Nothing) Then"

        If (mc_CheckBackgroundProportions) Then ''Conditioned 5/23/2022 td

            Try
                ClassFixTheControlWidth.ProportionsAreSlightlyOff(Me.BackgroundBox_Front.Image, True, "RefreshPreview_Redux #1")

            Catch ex_bgbox As Exception
                ''Added 11/26/2021 td
                If (Not mod_bMessageRedux1) Then MessageBox.Show(ex_bgbox.Message)
                mod_bMessageRedux1 = True ''Added 12/02/2021 thomas downes 
                If (False) Then MessageBox.Show(ex_bgbox.ToString)
            End Try

            Try
                ClassFixTheControlWidth.ProportionsAreSlightlyOff(Me.PreviewBox, True, "RefreshPreview_Redux #2")

            Catch ex_previewbox As Exception
                ''Added 11/26/2021 td
                MessageBox.Show(ex_previewbox.Message)
                MessageBox.Show(ex_previewbox.ToString)
            End Try

        End If ''End of ""If (mod_c_CheckBackgroundProportions) Then""

        ''
        ''Hopefully, we are done checking proportions.
        ''
        ''Jan13 2022''bBacksideOfCard = (EnumSideOfCard_Current = EnumWhichSideOfCard.EnumBackside)
        bBacksideOfCard = (par_enumCurrentSide = EnumWhichSideOfCard.EnumBackside)

        ''Added 8/2/2022 td
        ''We are focused on returning the output image, as if this was a function,
        ''   so it might be good to use the cached background image vs. the UI background
        ''   (we would expect them to be the same image, actually, so it doesn't matter?). 
        ''   ---8/02/2022
        With par_objMakeBadgeElements
            ''8/17/2022 bUseBadgeLayoutForBackground = pboolReturnImage
            bUseBadgeLayoutForBackground = pboolReturnImage AndAlso
                                            .BackgroundImage_Path <> "" AndAlso
                                            IO.File.Exists(.BackgroundImage_Path)
            bIgnorePreviewBox = pboolReturnImage
        End With ''end of ""ith par_objMakeBadgeElements""

        If bUseBadgeLayoutForBackground Then
            ''Added 8/2/2022
            ''We are focused on returning the output image, as if this was a function,
            ''   so it might be good to use the cached background image vs. the UI background
            ''   (we would expect them to be the same image, actually, so it doesn't matter?). 
            ''   ---8/02/2022
            obj_image = New Bitmap(par_objMakeBadgeElements.BackgroundImage_Path)
            ''Added 8/2/2022
            intPixelsOfBadgeWidth = par_badgeLayout.Width_Pixels
            intPixelsOfBadgeHeight = par_badgeLayout.Height_Pixels
        Else
            obj_image = Me.BackgroundBox_Front.BackgroundImage
            If (bBacksideOfCard) Then obj_image = Me.BackgroundBox_Backside.BackgroundImage
            ''Added 8/2/2022
            intPixelsOfBadgeWidth = Me.PreviewBox.Width
            intPixelsOfBadgeHeight = Me.PreviewBox.Height
        End If ''Endof ""If bUseBadgeLayoutForBackground Then... Else...."

        If (c_bLetsCloneBackgroundImage) Then ''Added 5/23/2022 td

            ''8/02/2022 If (obj_image Is Nothing) Then
            If (bUseBadgeLayoutForBackground Or bIgnorePreviewBox) Then
                ''
                ''We don't care about the Preview box. ---8/2/2022
                ''
                If (obj_image IsNot Nothing) Then
                    obj_image_clone = CType(obj_image.Clone(), Image)
                    ''We don't have to resize the image. (We aren't going to put it into the Preview box.)
                    obj_image_clone_resized = obj_image_clone
                End If ''eND OF ""If (obj_image IsNot Nothing) Then""
                ''Added 8/2/2022
                intPixelsOfBadgeWidth = par_badgeLayout.Width_Pixels
                intPixelsOfBadgeHeight = par_badgeLayout.Height_Pixels

            ElseIf (obj_image Is Nothing) Then
                ''Clear the Preview image, since we don't have a background available. ---12/10/2021 
                If (Me.PreviewBox.Image IsNot Nothing) Then Me.PreviewBox.Image.Dispose() ''Added 12/11/2021 td 
                Me.PreviewBox.Image = Nothing
                Me.PreviewBox.Refresh()
                ''Added 8/2/2022
                intPixelsOfBadgeWidth = Me.PreviewBox.Width
                intPixelsOfBadgeHeight = Me.PreviewBox.Height
                Return
            Else
                obj_image_clone = CType(obj_image.Clone(), Image)
                obj_image_clone_resized =
                    LayoutPrint.ResizeBackground_ToFitBox(obj_image, Me.PreviewBox, True)
                ''Added 8/2/2022
                intPixelsOfBadgeWidth = Me.PreviewBox.Width
                intPixelsOfBadgeHeight = Me.PreviewBox.Height

            End If ''End of "If (bUseBadgeLayoutForBackground Or bIgnorePreviewBox) Then ... ElseIf (obj_image Is Nothing) ... Else..."

            ''
            ''Check proportions (again!).
            ''
            If (mc_CheckBackgroundProportions) Then ''Added 5/23/2022 thomas d
                ''Added 9/6/2019 td 
                ClassFixTheControlWidth.ProportionsAreSlightlyOff(obj_image_clone_resized, True, "RefreshPreview_Redux #3")
                If (Not bIgnorePreviewBox) Then
                    ClassFixTheControlWidth.ImageSizeDiffersFromControl(Me.PreviewBox, obj_image_clone_resized, True) ''Added 10/9/2019 td  
                End If ''End of ""If (Not bIgnorePreviewBox) Then""

            End If ''End of ""If (mc_CheckBackgroundProportions) Then""

        End If ''End of ""If (c_bLetsCloneBackgroundImage) Then""

        ''---Const c_boolUseFunction2021 As Boolean = False ''Added 12/26/2021 td
        Const c_boolUseFunction2022 As Boolean = True ''Added 12/26/2021 td

        If (c_boolUseFunction2022) Then
            ''
            ''This was the function we started using 12/26/2021, to accomodate
            ''   either side of the badgecard.  ---12/26/2021 td
            ''
            ''Now parameterized. 1/13/2022 td''Dim objMakeBadgeElements As ClassBadgeSideLayoutV1 ''Added 12/26/2021 td

            ''
            ''Major call !!
            ''
            ''Now parameterized. 1/13/2022 td''objMakeBadgeElements = Me.ElementsCache_UseEdits.GetAllBadgeSideLayoutElements(EnumWhichSideOfCard.EnumFrontside)

            If (c_bLetsCloneBackgroundImage) Then ''Added 5/23/2022
                ''Added 12/26/2021 td
                par_objMakeBadgeElements.BackgroundImage = obj_image_clone_resized
            End If ''End of ""If (c_bLetsCloneBackgroundImage) Then""

            ''Added 12/26/2021 td
            ''
            ''  Get the Portrait Image from the Element-Portrait control. ---1/5/2022
            ''
            Dim objCtlPortrait As CtlGraphicPortrait
            objCtlPortrait = CtlGraphic_Portrait_1st()
            If (objCtlPortrait IsNot Nothing) Then
                If (par_objMakeBadgeElements.RecipientPic Is Nothing) Then
                    ''Take the picture from the Element Control. ---1/5/2022 
                    par_objMakeBadgeElements.RecipientPic = objCtlPortrait.Pic_CloneOfInitialImage
                End If ''End of "If (par_objMakeBadgeElements.RecipientPic Is Nothing) Then"
            End If ''End of "If (objCtlPortrait IsNot Nothing) Then"

            ''
            ''Major call !!
            ''
            ''8/02/2022 td''obj_image = obj_generator.MakeBadgeImage_AnySide(Me.BadgeLayout_Class,
            ''               par_objMakeBadgeElements, Me.ElementsCache_UseEdits,
            ''               Me.PreviewBox.Width,
            ''               Me.PreviewBox.Height,
            ''               par_recipient,
            ''               Nothing, Nothing, Nothing,
            ''               par_recentlyMovedV3,
            ''               par_recentlyMovedV4,
            ''               par_elementBaseToOmit)
            obj_image = obj_generator.MakeBadgeImage_AnySide(Me.BadgeLayout_Class,
                           par_objMakeBadgeElements, Me.ElementsCache_UseEdits,
                           intPixelsOfBadgeWidth,
                           intPixelsOfBadgeHeight,
                           par_recipient,
                           Nothing, Nothing, Nothing,
                           par_recentlyMovedV3,
                           par_recentlyMovedV4,
                           par_elementBaseToOmit)

            ''Added 1/23/2022 td
            ''Provide automated problem-related feedback to user. 
            If (Not String.IsNullOrEmpty(obj_generator.Messages)) Then
                ''Added 1/23/2022 td
                If (Not String.IsNullOrWhiteSpace(obj_generator.Messages)) Then
                    ''Provide automated problem-related feedback to user. 
                    MessageBoxTD.Show_Statement(obj_generator.Messages)
                End If ''End of ""If (Not String.IsNullOrWhiteSpace(obj_generator.Messages)) Then""
            End If ''End of "If (boolGeneratorMessageExists) Then"

        End If ''End of "If (c_boolUseFunction2022) Then ..."

        ClassFixTheControlWidth.ProportionsAreSlightlyOff(obj_image, True, "RefreshPreview_Redux #4")

        ''Added 8/01/2022 thomas d.
        pref_image = Nothing
        If (pboolReturnImage) Then
            pref_image = obj_image
            Return
        End If ''End of ""If (pboolReturnImage) Then""

        Me.PreviewBox.Image = obj_image
        Try
            Me.PreviewBox.Refresh()
            ''Causes crashes.6/13/2022 ''Me.DesignerForm.Refresh() ''Added 1/14/2022 td
        Catch ex As Exception ''Added 6/13/2022 
            ''Added 6/13/2022 
            System.Diagnostics.Debugger.Break()
        End Try

    End Sub ''End of "Public Sub RefreshPreview_EitherSide"


    Public Sub RefreshPreview_Redux_Front(Optional par_recentlyMoved As ClassElementFieldV3 = Nothing,
                                    Optional par_recipient As ciBadgeRecipients.ClassRecipient = Nothing)
        ''---Dec18 2021 td----Public Sub RefreshPreview_Redux
        ''
        ''Added 10/5/2019 & 8/24/2019 td 
        ''
        Dim objPrintLibElems As New ciLayoutPrintLib.LayoutElements
        Dim listOfTextImages As New HashSet(Of Image) ''Added 8/26/2019 thomas downes 
        Dim listOfElementTextFieldsV3 As HashSet(Of ClassElementFieldV3)
        Dim listOfElementTextFieldsV4 As HashSet(Of ClassElementFieldV4) ''Added 2/10/2022 td
        Dim listOfElementStaticTextsV3 As HashSet(Of ClassElementStaticTextV3) ''Added 1/8/2022 td
        Dim listOfElementStaticTextsV4 As HashSet(Of ClassElementStaticTextV4) ''Added 2/01/2022 td
        Dim listOfElementGraphics As HashSet(Of ClassElementGraphic) ''Added 1/8/2022 td

        Dim obj_image As Image ''Added 8/24 td
        Dim obj_image_clone As Image ''Added 8/24 td
        Dim obj_image_clone_resized As Image ''Added 8/24/2019 td
        ''10/14/2019 td''Dim obj_generator As New ciBadgeGenerator.ClassMakeBadge
        ''05/21/2022 td''Static obj_generator As ciBadgeGenerator.ClassMakeBadge
        Static s_obj_generator As ciBadgeGenerator.ClassMakeBadge2022
        Static s_obj_assistant As ciBadgeGenerator.ClassMakeAssistant
        Dim bMatchesElementInCache As Boolean ''Added 11/30/2021 thomas d.
        Dim intCountMatchedElementsV3 As Integer ''Added 11/30/2021 thomas d.
        Dim intCountMatchedElementsV4 As Integer ''Added 02/10/2022 thomas d.

        ''Added 10/14/2019 td 
        If (s_obj_generator Is Nothing) Then
            ''5/21/2022 s_obj_generator = New ciBadgeGenerator.ClassMakeBadge
            s_obj_generator = New ciBadgeGenerator.ClassMakeBadge2022
            ''Added 5/21/2022 Thomas Downes  
            s_obj_assistant = New ciBadgeGenerator.ClassMakeAssistant
        End If ''End of ""If (obj_generator Is Nothing) Then""

        s_obj_generator.PathToFile_Sig = Me.PathToSigFile ''Added 10/12/2019 td

        ''5/15/2022 ''obj_generator.ImageQRCode = CtlGraphic_QRCode.pictureQRCode.Image ''Added 10/14 td
        If (CtlGraphic_QRCode_1st() IsNot Nothing) Then ''Added 5/15/2022
            s_obj_generator.ImageQRCode =
                CtlGraphic_QRCode_1st().pictureQRCode.Image ''Added 10/14 td
        End If ''End of ""If (CtlGraphic_QRCode_1st() IsNot Nothing) Then""

        ''
        ''How is the following list used?   ---11/29/2021 td 
        ''
        ''11/29/2021 td''listOfElementTextFields = Me.ElementsCache_Edits.ListFieldElements()

        ''Pull the Element objects from the CtlGraphicFldLabel Controls.
        ''     ---11/29/2021 td 
        listOfElementTextFieldsV3 = New HashSet(Of ClassElementFieldV3)
        listOfElementTextFieldsV4 = New HashSet(Of ClassElementFieldV4)

        ''
        ''Field Elements, Version #3
        ''
        For Each eachCtlFieldV3 As CtlGraphicFieldV3 In mod_listOfFieldControlsV3
            ''
            ''Add to the list which will be given to the function MakeBadge.
            ''
            listOfElementTextFieldsV3.Add(eachCtlFieldV3.ElementClass_ObjV3)

            ''Debug code.....
            ''Dec18 2021 td''bMatchesElementInCache = Me.ElementsCache_UseEdits.ListOfElementFields.Contains(eachCtlField.ElementClass_Obj)
            bMatchesElementInCache =
                Me.ElementsCache_UseEdits.ListOfElementFields_BothsidesV3().Contains(eachCtlFieldV3.ElementClass_ObjV3)

            If (bMatchesElementInCache) Then intCountMatchedElementsV3 += 1

        Next eachCtlFieldV3

        ''
        ''Field Elements, Version #4   ----added 2/10/2022 td (td = tdownes)
        ''
        For Each eachCtlFieldV4 As CtlGraphicFieldV4 In mod_listOfFieldControlsV4
            ''
            ''Add to the list which will be given to the function MakeBadge.
            ''
            listOfElementTextFieldsV4.Add(eachCtlFieldV4.ElementClass_ObjV4)
            bMatchesElementInCache =
                Me.ElementsCache_UseEdits.ListOfElementFields_BothsidesV4().Contains(eachCtlFieldV4.ElementClass_ObjV4)
            If (bMatchesElementInCache) Then intCountMatchedElementsV4 += 1
        Next eachCtlFieldV4

        ''Pull the Element-StaticText objects from the CtlGraphicStaticText Controls.
        ''     ---11/29/2021 td 
        listOfElementStaticTextsV3 = New HashSet(Of ClassElementStaticTextV3)
        For Each eachCtlStaticText As CtlGraphicStaticTextV3 In mod_listOfTextControlsV3
            listOfElementStaticTextsV3.Add(eachCtlStaticText.ElementClass_Obj)
        Next eachCtlStaticText

        ''Added 2/01/2022 thomas downes
        listOfElementStaticTextsV4 = New HashSet(Of ClassElementStaticTextV4)
        For Each eachCtlStaticText As CtlGraphicStaticTextV4 In mod_listOfTextControlsV4
            With listOfElementStaticTextsV4
                Dim objStaticTextV4 As ClassElementStaticTextV4
                objStaticTextV4 = CType(eachCtlStaticText.ElementClass_Obj,
                     ciBadgeElements.ClassElementStaticTextV4)
                .Add(objStaticTextV4)
            End With ''End of "With listOfElementStaticTextsV4"
        Next eachCtlStaticText

        ''Pull the Element-Graphic objects from the CtlGraphicStaticGraphic Controls.
        ''     ---11/29/2021 td 
        listOfElementGraphics = New HashSet(Of ClassElementGraphic)
        For Each eachCtlGraphic As CtlGraphicStaticGraphic In mod_listOfGraphicControls
            listOfElementGraphics.Add(eachCtlGraphic.ElementClass_Obj)
        Next eachCtlGraphic

        ''obj_image = ciBadgeGenerator.ClassMakeBadge
        Try
            ClassFixTheControlWidth.ProportionsAreSlightlyOff(Me.BackgroundBox_Front.Image, True, "RefreshPreview_Redux #1")

        Catch ex_bgbox As Exception
            ''Added 11/26/2021 td
            If (Not mod_bMessageRedux1) Then MessageBox.Show(ex_bgbox.Message)
            mod_bMessageRedux1 = True ''Added 12/02/2021 thomas downes 
            If (False) Then MessageBox.Show(ex_bgbox.ToString)
        End Try

        Try
            ClassFixTheControlWidth.ProportionsAreSlightlyOff(Me.PreviewBox, True, "RefreshPreview_Redux #2")

        Catch ex_previewbox As Exception
            ''Added 11/26/2021 td
            MessageBox.Show(ex_previewbox.Message)
            MessageBox.Show(ex_previewbox.ToString)
        End Try


        ''Added 8/24/2019 td
        ''----Dec.3, 2021---obj_image = Me.BackgroundBox.Image
        Dim bBacksideOfCard As Boolean ''Added 12/10/2021 thomas downes
        bBacksideOfCard = (EnumSideOfCard_Current = EnumWhichSideOfCard.EnumBackside)
        obj_image = Me.BackgroundBox_Front.BackgroundImage
        If (bBacksideOfCard) Then obj_image = Me.BackgroundBox_Backside.BackgroundImage

        If (obj_image Is Nothing) Then
            ''Clear the Preview image, since we don't have a background available. ---12/10/2021 
            If (Me.PreviewBox.Image IsNot Nothing) Then Me.PreviewBox.Image.Dispose() ''Added 12/11/2021 td 
            Me.PreviewBox.Image = Nothing
            Me.PreviewBox.Refresh()
            Return
        Else
            obj_image_clone = CType(obj_image.Clone(), Image)
        End If ''End of "If (obj_image IsNot Nothing) Then"

        ''Dim gr_resize As Graphics = New Bitmap(obj_image_clone)

        ''8/26/2019 td''obj_image_clone_resized = ciLayoutPrintLib.LayoutPrint.ResizeImage_ToHeight(obj_image_clone, True,
        ''8/26/2019 td''      Me.PreviewBox.Height)

        ''Added 8/26/2019 thomas downes
        obj_image_clone_resized =
            LayoutPrint.ResizeBackground_ToFitBox(obj_image, Me.PreviewBox, True)

        ''Added 9/6/2019 td 
        ''10/5/2019 td''ClassLabelToImage.ProportionsAreSlightlyOff(obj_image_clone_resized, True, "Clone Resized #1")
        ClassFixTheControlWidth.ProportionsAreSlightlyOff(obj_image_clone_resized, True, "RefreshPreview_Redux #3")
        ClassFixTheControlWidth.ImageSizeDiffersFromControl(Me.PreviewBox, obj_image_clone_resized, True) ''Added 10/9/2019 td  

        ''#1 10/09/2019 td''obj_image = obj_generator.MakeBadgeImage(Me.BackgroundBox.Image, Me.ElementsCache_Edits,
        ''     Me.PreviewBox.Width,
        ''     Me.ExamplePortraitImage)
        '' #2 10/09/2019 td''obj_image = obj_generator.MakeBadgeImage(obj_image_clone_resized, Me.ElementsCache_Edits,
        ''                      Me.PreviewBox.Width,
        ''                      Me.ExamplePortraitImage)
        ''  #3 10/09/2019 td''obj_image = obj_generator.MakeBadgeImage(obj_image_clone_resized, Me.ElementsCache_Edits,
        ''           Me.PreviewBox.Width, Me.PreviewBox.Height,
        ''           Me.CtlGraphicPortrait_Lady.picturePortrait.Image)

        Const c_boolUseFunction2021 As Boolean = False ''Added 12/26/2021 td
        Const c_boolUseFunction2022 As Boolean = True ''Added 12/26/2021 td

        If (c_boolUseFunction2021) Then
            ''
            ''This was the function we used through most of 2000 & 2021, maybe 1999 as well.
            ''
            ''May21 2022 ''---obj_image = obj_generator.MakeBadgeImage_Front(Me.BadgeLayout_Class,
            obj_image = s_obj_assistant.MakeBadgeImage_Front(Me.BadgeLayout_Class,
                    obj_image_clone_resized,
                    Me.PreviewBox.Width,
                    Me.PreviewBox.Height,
                    Me.CtlGraphic_Portrait_1st().picturePortrait.Image,
                    Me.ElementsCache_UseEdits,
                    par_recipient,
                    listOfElementTextFieldsV3,
                    listOfElementTextFieldsV4,
                    listOfElementStaticTextsV3,
                    listOfElementStaticTextsV4,
                    listOfElementGraphics,
                    Me.CtlGraphic_Portrait_1st().ElementClass_Obj,
                    Me.CtlGraphic_QRCode_1st().ElementClass_Obj,
                    Me.CtlGraphic_Signat_1st().ElementClass_Obj,
                    Nothing, Nothing, Nothing,
                    par_recentlyMoved)

        ElseIf (c_boolUseFunction2022) Then
            ''
            ''This was the function we started using 12/26/2021, to accomodate
            ''   either side of the badgecard.  ---12/26/2021 td
            ''
            Dim objMakeBadgeElements As ClassBadgeSideLayoutV1 ''Added 12/26/2021 td

            ''
            ''Major call !!
            ''
            ''5/20/2022 td'' objMakeBadgeElements = Me.ElementsCache_UseEdits.GetAllBadgeSideLayoutElements(EnumWhichSideOfCard.EnumFrontside)
            objMakeBadgeElements = Me.ElementsCache_UseEdits.GetAllBadgeSideLayoutElements(EnumWhichSideOfCard.EnumFrontside, Me.BadgeLayout_Class)

            ''Added 12/26/2021 td
            objMakeBadgeElements.BackgroundImage = obj_image_clone_resized

            ''Added 12/26/2021 td
            ''
            ''  Get the Portrait Image from the Element-Portrait control. ---1/5/2022
            ''
            If (objMakeBadgeElements.RecipientPic Is Nothing) Then
                ''Take the picture from the Element Control. ---1/5/2022
                If (CtlGraphic_Portrait_1st() IsNot Nothing) Then
                    objMakeBadgeElements.RecipientPic = CtlGraphic_Portrait_1st().Pic_CloneOfInitialImage
                End If ''End of ""If (CtlGraphic_Portrait_1st() IsNot Nothing) Then""
            End If ''End of "If (objMakeBadgeElements.ElementPic Is Nothing) Then"

            ''
            ''Major call !!
            ''
            ''May21 2022 ''obj_image = sobj_generator.MakeBadgeImage_AnySide
            obj_image = s_obj_generator.MakeBadgeImage_AnySide(Me.BadgeLayout_Class,
                           objMakeBadgeElements, Me.ElementsCache_UseEdits,
                           Me.PreviewBox.Width,
                           Me.PreviewBox.Height,
                           par_recipient,
                           Nothing, Nothing, Nothing, par_recentlyMoved)

        End If ''End of "If (Function2021) Then ... ElseIf (Function2022) Then ..."




        ClassFixTheControlWidth.ProportionsAreSlightlyOff(obj_image, True, "RefreshPreview_Redux #4")

        Me.PreviewBox.Image = obj_image
        Me.PreviewBox.Refresh()

    End Sub ''End of "Public Sub RefreshPreview_Redux()"

    Public Sub RefreshPreview_Deprecated()
        ''
        ''Added 8/24/2019 td
        ''
        ''8/24 td''Dim objPrintLib As New ciLayoutPrintLib.CILayoutBadge
        ''9/18 td''Dim objPrintLib As New ciLayoutPrintLib.LayoutPrint_Redux
        Dim objPrintLibElems As New ciLayoutPrintLib.LayoutElements

        ''Deprecated. 9/18/2019 td''Dim listOfElementText_Stdrd As List(Of IFieldInfo_ElementPositions)
        ''Deprecated. 9/18/2019 td''Dim listOfElementText_Custom As List(Of IFieldInfo_ElementPositions)

        ''10/17 ''Dim listOfTextImages As New List(Of Image) ''Added 8/26/2019 thomas downes 
        ''10/17 ''Dim listOfElementTextFields As List(Of ClassElementField)

        Dim listOfTextImages As New HashSet(Of Image) ''Added 8/26/2019 thomas downes 
        Dim listOfElementTextFieldsV3 As HashSet(Of ClassElementFieldV3)
        Dim listOfElementTextFieldsV4 As HashSet(Of ClassElementFieldV4) ''Feb10 2022

        ''For Each field_standard As ClassFieldStandard In ClassFieldStandard.ListOfFields_Students

        ''objPrintLib.LoadImageWithFieldValues(Me.PreviewBox.Image,
        ''      ClassFieldStandard.ListOfFields_Students,
        ''      ClassFieldCustomized.ListOfFields_Students)

        ''9/4/2019 td''listOfElementText_Stdrd = ClassFieldStandard.ListOfElementsText_Stdrd()
        ''9/4/2019 td''listOfElementText_Custom = ClassFieldCustomized.ListOfElementsText_Custom()

        ''Deprecated. 9/18/2019 td''listOfElementText_Stdrd = ClassFieldStandard.ListOfElementsText_Stdrd(Me.Layout_Width_Pixels())
        ''Deprecated. 9/18/2019 td''listOfElementText_Custom = ClassFieldCustomized.ListOfElementsText_Custom(Me.Layout_Width_Pixels())

        listOfElementTextFieldsV3 = Me.ElementsCache_UseEdits.ListFieldElementsV3()
        listOfElementTextFieldsV4 = Me.ElementsCache_UseEdits.ListFieldElementsV4()

        ''8/24 td''Me.PreviewBox.SizeMode = PictureBoxSizeMode.Zoom
        ''8/24 td''Me.PreviewBox.Image = Me.BackgroundBox.Image
        ''8/24 td''Me.PreviewBox.Image = CType(Me.BackgroundBox.Image.Clone(), Image)

        Dim obj_image As Image ''Added 8/24 td
        Dim obj_image_clone As Image ''Added 8/24 td
        Dim obj_image_clone_resized As Image ''Added 8/24/2019 td

        ''Added 9/6/2019 td 
        ''10/5/2019 td''ClassLabelToImage.ProportionsAreSlightlyOff(Me.BackgroundBox.Image, True, "Background Image")
        ClassFixTheControlWidth.ProportionsAreSlightlyOff(Me.BackgroundBox_Front.Image, True, "Background Image")
        ClassFixTheControlWidth.ImageSizeDiffersFromControl(Me.BackgroundBox_Front, Me.BackgroundBox_Front.Image, True) ''Added 10/9/2019 td  

        ''Added 8/24/2019 td
        obj_image = Me.BackgroundBox_Front.Image
        obj_image_clone = CType(obj_image.Clone(), Image)

        ''Dim gr_resize As Graphics = New Bitmap(obj_image_clone)

        ''8/26/2019 td''obj_image_clone_resized = ciLayoutPrintLib.LayoutPrint.ResizeImage_ToHeight(obj_image_clone, True,
        ''8/26/2019 td''      Me.PreviewBox.Height)

        ''Added 8/26/2019 thomas downes
        obj_image_clone_resized =
            LayoutPrint.ResizeBackground_ToFitBox(obj_image, Me.PreviewBox, True)

        ''Added 9/6/2019 td 
        ''10/5/2019 td''ClassLabelToImage.ProportionsAreSlightlyOff(obj_image_clone_resized, True, "Clone Resized #1")
        ClassFixTheControlWidth.ProportionsAreSlightlyOff(obj_image_clone_resized, True, "Clone Resized #1")
        ClassFixTheControlWidth.ImageSizeDiffersFromControl(Me.PreviewBox, obj_image_clone_resized, True) ''Added 10/9/2019 td  

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
                                             listOfElementTextFieldsV3,
                                             listOfElementTextFieldsV4,
                                             listOfTextImages)

        ''
        ''Major call, let's show the portrait !!  ---9/9/2019 td  
        ''
        objPrintLibElems.LoadImageWithPortrait(obj_image_clone_resized.Width,
                                          Me.Layout_Width_Pixels(),
                                          obj_image_clone_resized,
                                           CtlGraphic_Portrait_1st().ElementInfo_Base,
                                           CtlGraphic_Portrait_1st().ElementInfo_Pic,
                                          CtlGraphic_Portrait_1st().picturePortrait.Image)

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
        ''10/5/2019 td''ClassLabelToImage.ProportionsAreSlightlyOff(Me.BackgroundBox.Image, True, "Clone Resized #1")
        ClassFixTheControlWidth.ProportionsAreSlightlyOff(Me.BackgroundBox_Front.Image, True, "Clone Resized #1")

        ''8/26 td''Me.PreviewBox.Image = obj_image_clone_resized
        Me.PreviewBox.Image = obj_image_clone_resized
        Me.PreviewBox.Refresh()

    End Sub ''end of "Private Sub RefreshPreview_Deprecated()"

    ''
    ''  Simple Drawing Selection Shape (Or Rubberband Shape)       
    ''  https://www.dreamincode.net/forums/topic/59049-simple-drawing-selection-shape-or-rubberband-shape/
    ''
    ''9/8/2019 td''Private _bRubberBandingOn As Boolean = False '-- State to control if we are drawing the rubber banding object
    ''9/8/2019 td''Private _pClickStart As New Point '-- The place where the mouse button went 'down'.
    ''9/8/2019 td''Private _pClickStop As New Point '-- The place where the mouse button went 'up'.
    ''9/8/2019 td''Private _pNow As New Point '-- Holds the current mouse location to make the shape appear to follow the mouse cursor.

    Private Sub Layout_MouseDown(sender As Object, e As MouseEventArgs) Handles BackgroundBox_Front.MouseDown  ''me.pictureBack.MouseDown ''----Me.MouseDown
        ''
        ''  Simple Drawing Selection Shape (Or Rubberband Shape)       
        ''  https://www.dreamincode.net/forums/topic/59049-simple-drawing-selection-shape-or-rubberband-shape/
        ''
        If (mod_rubberbandClass IsNot Nothing) Then
            mod_rubberbandClass.MouseDown(sender, e)
        End If ''End of "If (mod_rubberbandClass IsNot Nothing) Then"

    End Sub

    Private Sub Layout_MouseMove(sender As Object, e As MouseEventArgs) Handles BackgroundBox_Front.MouseMove ''----Me.MouseMove
        ''
        ''  Simple Drawing Selection Shape (Or Rubberband Shape)       
        ''  https://www.dreamincode.net/forums/topic/59049-simple-drawing-selection-shape-or-rubberband-shape/
        ''
        If (mod_rubberbandClass IsNot Nothing) Then
            mod_rubberbandClass.MouseMove(sender, e)
        End If

    End Sub

    Private Sub Layout_MouseUp(sender As Object, e As MouseEventArgs) Handles BackgroundBox_Front.MouseUp ''10/4 td''pictureBack.MouseUp ''----Me.MouseUp
        ''
        ''  Simple Drawing Selection Shape (Or Rubberband Shape)       
        ''  https://www.dreamincode.net/forums/topic/59049-simple-drawing-selection-shape-or-rubberband-shape/
        ''
        ''Jan6 2022 td''mod_rubberbandClass.MouseUp(sender, e)
        If (mod_rubberbandClass IsNot Nothing) Then
            mod_rubberbandClass.MouseUp(sender, e)
        End If ''End of "If (mod_rubberbandClass IsNot Nothing) Then"

    End Sub

    Private Sub Layout_Paint(sender As Object, e As PaintEventArgs) Handles BackgroundBox_Front.Paint ''10/4 td''pictureBack.Paint ''----Me.Paint
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

    ''10/17/2019 td''Private mod_selectedCtls As New List(Of CtlGraphicFldLabel)   ''Added 8/03/2019 thomas downes 
    ''See Line 100.12/21/21'' Public mod_selectedCtls As New HashSet(Of CtlGraphicFldLabel)   ''Publicized 11/29/2021 ''Added 8/03/2019 thomas downes 
    ''See Line 101.12/21/21'' Public mod_FieldControlLastTouched As CtlGraphicFldLabel  ''Publicized 11/29/2021 ''Added 8/09/2019 thomas downes 

    ''''11/29/2012 ''Private mod_ControlLastTouched As Control ''Added 8/12/2019 thomas d. 
    ''See Line 102.12/21/21'' Public mod_ControlLastTouched As Control ''Publicized 11/29/2021 td''Added 8/12/2019 thomas d. 
    ''See Line 103.12/21/21'' Private mod_ElementLastTouched As Control ''Let's change this to IElement_Base soon. ---Added 9/14/2019 td 
    ''See Line 104.12/21/21'' Private mod_IMoveableElementLastTouched As IMoveableElement ''Added 12/21/2021 td
    ''See Line 105.12/21/21'' Private mod_ISaveableElementLastTouched As ISaveToModel ''Added 12/21/2021 td
    ''See Line 106.12/21/21'' Private Const mc_bAddBorderOnlyWhileResizing As Boolean = True ''Added 9/11/2019 thomas d. 

    Public Property ControlBeingMoved() As Control Implements ILayoutFunctions.ControlBeingMoved ''Added 8/4/2019 td
        Get
            ''Added 8/9/2019 td
            Return mod_RSCControlLastTouched
        End Get
        Set(value As Control)
            ''Added 8/9/2019 td
            Try
                ''9/9/2019 td''mod_FieldControlLastTouched = value
                ''Dec21 2021''mod_FieldControlLastTouched = CType(value, CtlGraphicFldLabel)
                mod_RSCControlLastTouched = Nothing
                If (TypeOf value Is CtlGraphicFieldV3) Then mod_RSCControlLastTouched = CType(value, CtlGraphicFieldV3)

                ''1/12/2022''mod_ElementLastTouched = CType(value, Control) ''Added 9/14 
                mod_ElementLastTouched = CType(value, RSCMoveableControlVB) ''Modified 1/12/2022 ''Added 9/14 
                mod_RSCControlLastTouched = CType(value, RSCMoveableControlVB) ''Added 1/28/2022 td
                mod_ControlLastTouched = value ''Added 8/1/2019 
                ''Added 12/21/2021 td
                mod_IMoveableElementLastTouched = Nothing
                If (TypeOf value Is IMoveableElement) Then mod_IMoveableElementLastTouched = CType(value, IMoveableElement)
                mod_ISaveableElementLastTouched = Nothing
                If (TypeOf value Is ISaveToModel) Then mod_ISaveableElementLastTouched = CType(value, ISaveToModel)

            Catch
                ''Added 8/12/2019 td  
                mod_ControlLastTouched = value
                ''1/12/2022 td''mod_ElementLastTouched = CType(value, Control)
                mod_ElementLastTouched = CType(value, RSCMoveableControlVB)
                mod_RSCControlLastTouched = CType(value, RSCMoveableControlVB) ''Added 1/28/2022 td

            End Try
        End Set
    End Property ''End of "Public Property ControlBeingMoved() As Control Implements ILayoutFunctions.ControlBeingMoved"

    Public Property ControlBeingModified() As Control _
        Implements ILayoutFunctions.ControlBeingModified ''Added 8/9/2019 td
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
            mod_ElementLastTouched = CType(value, RSCMoveableControlVB) ''Modified 1/12/2022 Added 9/14/2019 td
            mod_RSCControlLastTouched = CType(value, RSCMoveableControlVB) ''Added 1/28/2022 td

            Try
                ''9/9/2019 td''mod_FieldControlLastTouched = value
                mod_RSCControlLastTouched = CType(value, CtlGraphicFieldV3)

                ''Added 9/11/2019 td  
                If (mc_bAddBorderOnlyWhileResizing) Then
                    mod_RSCControlLastTouched.BorderStyle = BorderStyle.FixedSingle
                End If ''End of "If (mc_bAddBorderOnlyWhileResizing) Then"

            Catch
                ''Not all moveable controls are Field-Label controls. - ----8/12/2019 thomas d.  
            End Try
        End Set
    End Property ''End of "Public Property ControlBeingModified() As Control Implements ILayoutFunctions.ControlBeingModified"

    Public Property ElementsDesignList_AllItems As HashSet(Of RSCMoveableControlVB) _
        Implements ISelectingElements.ElementsDesignList_AllItems
        ''1/12/2022 TD''Property ElementsDesignList_AllItems As HashSet(Of CtlGraphicFldLabel)
        ''
        ''10/17/2019 td''Public Property LabelsDesignList_AllItems As List(Of CtlGraphicFldLabel)
        ''     Implements ISelectingElements.LabelsDesignList_AllItems
        ''
        Get
            ''Added 8/3/2019 thomas downes
            Return mod_selectedCtls
        End Get
        Set
            ''Added 8/3/2019 thomas downes
            mod_selectedCtls = Value
        End Set

    End Property

    Public Sub ElementsDesignList_Add(par_control As CtlGraphicFieldV3) _
        Implements ISelectingElements.ElementsDesignList_Add
        ''
        ''Jan11 2022 td''Public Sub LabelsDesignList_Add(par_control As CtlGraphicFldLabel)
        ''        Implements ISelectingElements.LabelsDesignList_Add
        ''
        ''Added 8/3/2019 thomas downes
        ''
        ''10/17/2019 td''mod_selectedCtls.Add(par_control)

        If (mod_selectedCtls.Contains(par_control)) Then
            ''
            ''I think it's possible to cause problems by adding 
            ''  a control more than once to the same list.
            ''  Let's avoid that, shall we?  
            ''  ---10/17/2019 td 
            ''
        Else

            mod_selectedCtls.Add(par_control)

        End If ''End of "If (mod_selectedCtls.Contains(par_control)) Then ... Else ..."

    End Sub

    Public Sub ElementsDesignList_Remove(par_control As CtlGraphicFieldV3) _
        Implements ISelectingElements.ElementsDesignList_Remove
        ''
        ''Added 8/3/2019 thomas downes
        ''
        mod_selectedCtls.Remove(par_control)

    End Sub


    Private Sub Resizing_Start() Handles mod_oGroupMoveEvents.Resizing_Start
        ''Jan11 2022 ''Private Sub Resizing_Start() Handles mod_groupedMove.Resizing_Start
        ''
        ''Added 8/5/2019 thomas downes  
        ''
        ''1/12/2022 td''For Each each_control As CtlGraphicFldLabel In mod_selectedCtls
        For Each each_control As RSCMoveableControlVB In mod_selectedCtls

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


    Private Sub Move_GroupMove_Continue(DeltaLeft As Integer, DeltaTop As Integer,
                                        DeltaWidth As Integer, DeltaHeight As Integer,
                                        pbLeadControlLocationWasEdited As Boolean) _
                                        Handles mod_oGroupMoveEvents.MoveInUnison
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
        Dim rscControlBeingMoved As RSCMoveableControlVB ''Added 1/28/2022 td
        rscControlBeingMoved = CType(ControlBeingMoved, RSCMoveableControlVB)

        ''Jan11 2022 ''If (TypeOf ControlBeingMoved Is CtlGraphicFldLabel) Then
        Const c_bCheckThatControlIsGrouped As Boolean = True ''8/5/2019 thomas downes

        If (c_bCheckThatControlIsGrouped) Then ''8/5/2019 thomas downes
            ''9/9 td''bControlMovedIsInGroup = LabelsList_IsItemIncluded(ControlBeingMoved)
            ''1/28/2022 TD''bControlMovedIsInGroup = ElementsList_IsItemIncluded(CType(ControlBeingMoved, CtlGraphicFldLabel))
            bControlMovedIsInGroup = ElementsList_IsItemIncluded(rscControlBeingMoved)
            If (Not bControlMovedIsInGroup) Then Exit Sub

        End If ''End of "If (c_bCheckThatControlIsGrouped) Then"

        ''Jan11 2022 ''Else
        ''    ''
        ''    ''Perhaps the Portrait is being moved.   Don't allow other things to be 
        ''    ''  moved around as well.  ---8/5/2019 td
        ''    ''
        ''    Exit Sub
        ''
        ''End If ''End of "If (TypeOf ControlBeingMoved Is CtlGraphicFldLabel) Then .... Else ...."

        ''
        ''The control being moved or resized is part of a group.   
        ''
        ''8/4/2019 td''For Each each_control As CtlGraphicFldLabel In mod_selectedCtls
        ''1/14/2022''For Each each_control As CtlGraphicFldLabel In mod_selectedCtls
        For Each each_control As RSCMoveableControlVB In mod_selectedCtls

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

    End Sub ''End of "Private Sub MoveInUnison"


    Private Sub Resizing_End() Handles mod_oGroupMoveEvents.Resizing_EndV1
        ''
        ''Added 8/5/2019 thomas downes  
        ''
        ''Jan28 2022 td''For Each each_control As CtlGraphicFldLabel In mod_selectedCtls
        For Each each_control As RSCMoveableControlVB In mod_selectedCtls

            ''Added 9/11/2019 td  
            If (mc_bAddBorderOnlyWhileResizing) Then
                each_control.BorderStyle = BorderStyle.None
            End If ''End of "If (mc_boolAddBorderWhileResizing) Then"

            each_control.TempResizeInfo_W = 0
            each_control.TempResizeInfo_H = 0

            ''Added 9/11/2019 td
            ''Feb1 2022 td''each_control.Refresh_Image(True)
            each_control.Refresh_ImageV3(True)

        Next each_control

        ''Added 9/11/2019 Never Forget
        ''   This is needed in case it's not a group of controls being resized, 
        ''   but just a single control. ---9/11 td 
        ''
        ''9/14/2019 td''If (mod_ElementLastTouched = mod_FieldControlLastTouched) Then

        ''Jan2022 ''Dim boolResizedAFieldCtl As Boolean ''Added 9/14/2019 td
        ''Jan2022 ''boolResizedAFieldCtl = (TypeOf mod_ControlLastTouched Is CtlGraphicFldLabel)

        Dim boolResizedATextCtl As Boolean ''Added 1/28/2022 td
        boolResizedATextCtl = (TypeOf mod_ControlLastTouched Is CtlGraphicFieldV3) Or
                              (TypeOf mod_ControlLastTouched Is CtlGraphicStaticTextV3)

        ''10/13/2019 td''If (boolResizedAFieldCtl) Then ''Added 9/14/2019 td
        ''1/28/2022 td''If ((Not mc_boolMoveGrowInUnison) And boolResizedAFieldCtl) Then ''Added 9/14/2019 td
        If ((Not mc_boolMoveGrowInUnison) And boolResizedATextCtl) Then ''Added 9/14/2019 td

            With mod_RSCControlLastTouched

                If (.Rotated_0degrees) Then
                    .ElementInfo_Base.Width_Pixels = mod_RSCControlLastTouched.Width
                    .ElementInfo_Base.Height_Pixels = mod_RSCControlLastTouched.Height
                ElseIf (.Rotated_180_360) Then
                    .ElementInfo_Base.Width_Pixels = mod_RSCControlLastTouched.Width
                    .ElementInfo_Base.Height_Pixels = mod_RSCControlLastTouched.Height
                ElseIf (.Rotated_90_270(False)) Then
                    ''
                    ''---- POTENTIALLY CONFUSING -----
                    ''Switch them up !!  
                    .ElementInfo_Base.Width_Pixels = mod_RSCControlLastTouched.Height
                    .ElementInfo_Base.Height_Pixels = mod_RSCControlLastTouched.Width
                End If ''End of "If (.Rotated_180_360) Then"

                ''Added 9/12/2019 td  
                Dim bAutoscaleConfirmed As Boolean ''Added 6/2/2022 thomas
                If (TypeOf mod_RSCControlLastTouched Is ICtlElement_TextAny) Then ''Added 1/12/2022
                    With CType(mod_RSCControlLastTouched, ICtlElement_TextAny)
                        With .ElementInfo_TextOnly ''Jan11 2022 ''With .ElementInfo_Text
                            If .FontSize_AutoScaleToElementYesNo Then

                                ''Change the Font Size, to account for the new Height of the Element !!
                                ''  ---9/12/2019 td0
                                If (.FontSize_AutoSizePromptUser) Then
                                    bAutoscaleConfirmed = (MessageBoxTD.Show_Confirm("Auto-Scale the font?  (Auto-Size)"))
                                Else
                                    bAutoscaleConfirmed = .FontSize_AutoScaleToElementYesNo
                                End If ''End of"If (.FontSize_AutoSizePromptUser) Then... Else..." 

                                ''Confirmed?  If so, then 
                                If (bAutoscaleConfirmed) Then
                                    .FontSize_Pixels = CSng(mod_RSCControlLastTouched.Height * .FontSize_AutoScaleToElementRatio)
                                End If ''End of ""If (bAutoscaleConfirmed) Then""

                            End If ''End of "If .FontSize_ScaleToElementYesNo Then"
                        End With ''End of "With .ElementInfo_Text"
                    End With ''End of "With CType(mod_RSCControlLastTouched, ICtlElement_TextAny)"
                End If ''End of "If (TypeOf mod_RSCControlLastTouched Is ICtlElement_Text) Then"

                ''Feb01 2022 td''.Refresh_Image(True)
                .Refresh_ImageV3(True)

            End With ''End of "With mod_RSCControlLastTouched"

        End If ''End of "If (mod_ElementLastTouched = mod_FieldControlLastTouched) Then"

        ''Added 9/13/2019 td 
        AutoPreview_IfChecked()

    End Sub ''End of "Private Sub Resizing_End() Handles mod_oGroupMoveEvents.Resizing_End"


    Private Sub MovingElement_End(par_ctlElement As Control, par_iSave As ISaveToModel) _
        Handles mod_oGroupMoveEvents.Moving_End
        ''11/29/2021 ''Private Sub MovingElement_End() Handles mod_groupedMove.Moving_End

        ''Added 11/29/2021 thomas d. 
        If (TypeOf par_ctlElement Is PictureBox) Then
            ''Let the programmer know that the control type 
            ''  should be a custom-control, e.g. ctlGraphicLabel.
            ''  ----11/29/2021 td 
            Throw New Exception("The Element-Control is NOT supposed to be a PictureBox!")
        End If ''End of "If (TypeOf par_ctlElement Is PictureBox) Then"

        ''Added 9/13/2019 td 
        ''11/29/2021 td''AutoPreview_IfChecked()
        AutoPreview_IfChecked(par_ctlElement)

    End Sub ''End of "Private Sub MovingElement_End(par_control As Control)"


    Private Sub SwitchControls_Down(par_ctl As RSCMoveableControlVB) Implements ISelectingElements.SwitchControls_Down
        ''
        ''Added 8/15/2019 thomas downes  
        ''
        If (GetNextLowerControl(par_ctl) Is Nothing) Then Exit Sub ''Added 8/16/2019 td 

        SwitchWithOtherCtl(par_ctl, GetNextLowerControl(par_ctl))

    End Sub ''End of "Private Sub SwitchControls_Down(par_ctl As CtlGraphicFldLabel)"

    Private Sub SwitchControls___Up(par_ctl As RSCMoveableControlVB) Implements ISelectingElements.SwitchControls___Up
        ''
        ''Added 8/15/2019 thomas downes  
        ''
        If (GetNextHigherControl(par_ctl) Is Nothing) Then Exit Sub ''Added 8/16/2019 td 

        SwitchWithOtherCtl(par_ctl, GetNextHigherControl(par_ctl))

    End Sub ''End of "Private Sub SwitchWithNextHigher(par_ctl As RSCMoveableControlVB)"

    Private Sub SwitchWithOtherCtl(par_one As RSCMoveableControlVB, par_two As RSCMoveableControlVB)
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

    Private Function HasAtLeastOne_Down(par_ctl As RSCMoveableControlVB) As Boolean Implements ISelectingElements.HasAtLeastOne_Down
        ''Added 8/15/2019 thomas downes  
        Return (GetNextLowerControl(par_ctl) IsNot Nothing)
    End Function

    Private Function HasAtLeastOne____Up(par_ctl As RSCMoveableControlVB) As Boolean Implements ISelectingElements.HasAtLeastOne__Up
        ''Added 8/15/2019 thomas downes  
        Return (GetNextHigherControl(par_ctl) IsNot Nothing)
    End Function

    Private Function GetNextLowerControl(par_ctl As RSCMoveableControlVB) As RSCMoveableControlVB
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

    Private Function GetNextHigherControl(par_ctl As RSCMoveableControlVB) As RSCMoveableControlVB
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

    Public Function ElementsList_CountItems() As Integer Implements ISelectingElements.ElementsList_CountItems

        ''Added 8/3/2019 td 
        Return mod_selectedCtls.Count

    End Function

    Public Function LabelsList_OneOrMoreItems() As Boolean Implements ISelectingElements.ElementsList_OneOrMoreItems

        ''Added 8/3/2019 td 
        Return (1 <= mod_selectedCtls.Count)

    End Function


    Public Function ElementsList_TwoOrMoreItems() As Boolean _
        Implements ISelectingElements.ElementsList_TwoOrMoreItems

        ''Added 8/3/2019 td 
        Return (2 <= mod_selectedCtls.Count)

    End Function


    Public Function ElementsList_IsItemIncluded(par_control As RSCMoveableControlVB) As Boolean _
        Implements ISelectingElements.ElementsList_IsItemIncluded

        ''Jan11 2022 ''Public Function LabelsList_IsItemIncluded(par_control As CtlGraphicFldLabel) As Boolean
        ''    Implements ISelectingElements.LabelsList_IsItemIncluded

        ''Added 8/3/2019 td 
        Return (mod_selectedCtls.Contains(par_control))

    End Function


    Public Function ElementsList_IsItemUnselected(par_control As RSCMoveableControlVB) As Boolean Implements ISelectingElements.ElementsList_IsItemUnselected

        ''Jan11 2022 ''Public Function LabelsList_IsItemUnselected(par_control As CtlGraphicFldLabel) As Boolean
        ''    Implements ISelectingElements.LabelsList_IsItemUnselected

        ''Added 8/3/2019 td 
        Return (Not (mod_selectedCtls.Contains(par_control)))

    End Function

    Public Function Layout_Width_Pixels() As Integer Implements ILayoutFunctions.Layout_Width_Pixels
        ''Added 9/3/2019 thomas downes
        Return Me.BackgroundBox_Front.Width
    End Function ''End of "Public Function Layout_Width_Pixels() As Integer"

    Public Function Layout_Height_Pixels() As Integer Implements ILayoutFunctions.Layout_Height_Pixels
        ''Added 9/11/2019 Never Forget 
        Return Me.BackgroundBox_Front.Height
    End Function ''End of "Public Function Layout_Height_Pixels() As Integer"

    Public Function Layout_Margin_Left_Omit(par_intPixelsLeft As Integer) As Integer Implements ILayoutFunctions.Layout_Margin_Left_Omit
        ''Added 9/5/2019 thomas downes

        ''Added 9/05/2019 td 
        Return (par_intPixelsLeft - Me.BackgroundBox_Front.Left)

    End Function ''End of "Public Function Layout_Margin_Left_Omit() As Integer"

    Public Function Layout_Margin_Left_Add(par_intPixelsLeft As Integer) As Integer Implements ILayoutFunctions.Layout_Margin_Left_Add
        ''Added 9/5/2019 thomas downes
        Return (par_intPixelsLeft + Me.BackgroundBox_Front.Left)
    End Function ''End of "Public Function Layout_Margin_Left_Add() As Integer"

    Public Function Layout_Margin_Top_Omit(par_intPixelsTop As Integer) As Integer Implements ILayoutFunctions.Layout_Margin_Top_Omit
        ''Added 9/5/2019 thomas downes
        Return (par_intPixelsTop - Me.BackgroundBox_Front.Top)
    End Function ''End of "Public Function Layout_Margin_Top_Omit() As Integer"

    Public Function Layout_Margin_Top_Add(par_intPixelsTop As Integer) As Integer Implements ILayoutFunctions.Layout_Margin_Top_Add
        ''Added 9/5/2019 thomas downes
        Return (par_intPixelsTop + Me.BackgroundBox_Front.Top)
    End Function ''End of "Public Function Layout_Margin_Top_Add() As Integer"

    Public Function OkayToShowFauxContextMenu() As Boolean Implements ILayoutFunctions.OkayToShowFauxContextMenu
        ''
        ''Added 8/14/2019 td 
        ''
        ''OkayToShowFauxContextMenu()
        ''10/1/2019 td''Return DemoModeActiveToolStripMenuItem.Checked
        Return True

    End Function ''End of "Public Function OkayToShowFauxContextMenu() As Boolean"

    Public Sub AutoPreview_IfChecked(Optional par_controlElement As Control = Nothing, Optional par_stillMoving As Boolean = False) Implements ILayoutFunctions.AutoPreview_IfChecked
        ''
        ''Refresh the preview picture box. 
        ''
        Dim bProceedWithRefresh As Boolean ''Added 12/6/2021 thomas d.

        ''Added 12/6/2021 td
        If (par_stillMoving) Then
            ''The control being moved is still in motion, so let's see if "Instant Preview" is checked. 
            bProceedWithRefresh = (CheckboxAutoPreview.Checked And CheckboxInstantPreview.Checked)
        Else
            bProceedWithRefresh = CheckboxAutoPreview.Checked
        End If ''End of "if (par_stillMoving) then ... Else ...."

        ''
        ''Proceed, if applicable.
        ''
        ''---Dec.6 2021---If (CheckboxAutoPreview.Checked) Then
        If (bProceedWithRefresh) Then
            ''--o----No longer needed. The preview is driven by Me.ElementsCache_Edits.---10/10/2019 td
            ''--o--SaveLayout()
            ''11/29/2021 td''SaveControlPositionsToElement() ''Added 10/10/2019 td
            Const c_bSaveIsProbablyNotNeededAnymore As Boolean = True ''Added 5/5/2022
            If (c_bSaveIsProbablyNotNeededAnymore) Then
                ''The element-control has already had .SaveToModel() called. ---5/5/2022 td
            Else
                SaveControlPositionsToElement(par_controlElement) ''Added 10/10/2019 td
            End If ''End of ""If (c_bSaveIsProbablyNotNeededAnymore) Then... Else...."

            ''Refresh the Preview Box (a PictureBox control).
            If (TypeOf par_controlElement Is CtlGraphicFieldV3) Then
                ''Added 11/29/2021 td
                Dim objElementField As ClassElementFieldV3
                objElementField = CType(par_controlElement,
                                 CtlGraphicFieldV3).ElementClass_ObjV3
                ''
                ''Major call!!
                ''
                ''Jan14 2022 td''RefreshPreview_Redux_Front(objElementField)
                RefreshPreview_CurrentSide(objElementField)

            Else
                ''
                ''Major call!!
                ''
                ''Jan14 2022 td''RefreshPreview_Redux_Front()
                RefreshPreview_CurrentSide()

            End If ''End of "If (TypeOf par_controlElement Is CtlGraphicFldLabel) Then... Else"

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


    Public Sub BackgroundImage_Select()

        ''Added 5/12/2022 td
        ''5/17/2022 td''Me.DesignerForm_Interface.BackgroundImage_Select()
        Me.DesignerForm_Interface.BackgroundImage_Select(False)


    End Sub ''End of ""Public Sub BackgroundImage_Select()""


    Public Sub BackgroundImage_Upload()

        ''Added 5/12/2022 td
        Me.DesignerForm_Interface.BackgroundImage_Upload()

    End Sub ''End of ""Public Sub BackgroundImage_Upload()""


    Private Sub ElementField_Clicked(par_control As CtlGraphicFieldV3)
        ''
        ''Added 10/1/2019 thomas d.
        ''
        ''Dec15 2021''RaiseEvent ElementRightClicked(par_control)
        RaiseEvent ElementFieldRightClicked(par_control)

    End Sub


    Private Sub ElementPic_Clicked(par_control As CtlGraphicPortrait)
        ''
        ''Added 12/22/2021 thomas d.
        ''
        RaiseEvent ElementPortraitRightClicked(par_control)

    End Sub



    Private Sub ElementQR_Clicked(par_control As CtlGraphicQRCode)
        ''
        ''Added 12/15/2021 thomas d.
        ''
        RaiseEvent ElementQRCodeRightClicked(par_control)

    End Sub


    Private Sub ElementSig_Clicked(par_control As CtlGraphicSignature)
        ''
        ''Added 12/15/2021 thomas d.
        ''
        RaiseEvent ElementSignatRightClicked(par_control)

    End Sub


    Private Sub ElementStatic_Clicked(par_control As CtlGraphicStaticTextV3)
        ''
        ''Added 12/15/2021 thomas d.
        ''
        RaiseEvent ElementStaticTextRightClicked(par_control)

    End Sub


    ''Private Sub mod_sizingPic_events_Moving_End() Handles mod_sizingEvents_Pics.Moving_End
    ''    ''Added 10/9/2019 td 
    ''    AutoPreview_IfChecked()

    ''End Sub

    ''Private Sub mod_sizingPic_events_Resizing_End() Handles mod_sizingEvents_Pics.Resizing_End
    ''    ''Added 10/9/2019 td 
    ''    AutoPreview_IfChecked()

    ''End Sub

    ''Private Sub mod_sizingQR_events_Moving_End() Handles mod_sizingEvents_QR.Moving_End

    ''    ''Added 10/9/2019 td 
    ''    CtlGraphic_QRCode.SaveToModel()
    ''    AutoPreview_IfChecked()

    ''End Sub

    ''Private Sub mod_sizingQR_events_Resizing_End() Handles mod_sizingEvents_QR.Resizing_End
    ''    ''Added 10/9/2019 td 
    ''    AutoPreview_IfChecked()

    ''End Sub

    ''Private Sub mod_sizingSig_events_Moving_End() Handles mod_sizingEvents_Sig.Moving_End
    ''    ''Added 10/9/2019 td 
    ''    AutoPreview_IfChecked()

    ''End Sub

    ''Private Sub mod_sizingSig_events_Resizing_End() Handles mod_sizingEvents_Sig.Resizing_End
    ''    ''Added 10/9/2019 td 
    ''    AutoPreview_IfChecked()

    ''End Sub

    ''Private Sub mod_sizingPic_events_MoveInUnison(deltaLeft As Integer, deltaTop As Integer, deltaWidth As Integer, deltaHeight As Integer) Handles mod_sizingEvents_Pics.MoveInUnison

    ''    ''Added 10/10/2019 td
    ''    AutoPreview_IfChecked()

    ''End Sub

    ''Private Sub mod_sizingQR_events_MoveInUnison(deltaLeft As Integer, deltaTop As Integer, deltaWidth As Integer, deltaHeight As Integer) Handles mod_sizingEvents_QR.MoveInUnison

    ''    ''Added 10/10/2019 td
    ''    AutoPreview_IfChecked()

    ''End Sub

    ''Private Sub mod_sizingSig_events_MoveInUnison(deltaLeft As Integer, deltaTop As Integer, deltaWidth As Integer, deltaHeight As Integer) Handles mod_sizingEvents_Sig.MoveInUnison

    ''    ''Added 10/10/2019 td
    ''    AutoPreview_IfChecked()

    ''End Sub

    Private Sub BackgroundBox_Click(sender As Object, e As MouseEventArgs) Handles BackgroundBox_Front.MouseClick
        ''
        ''Added 10/15/2019 td  
        ''

        ''Added condition on 12/01/2021 thomas downes
        If (e.Button = MouseButtons.Right) Then

            RaiseEvent BackgroundRightClicked(e.X, e.Y)

        End If ''End of ""If (e.Button = MouseButtons.Right) Then

    End Sub


    Public Sub SwitchSideOfCard(par_bAutoLoadMissingBackground As Boolean,
                                par_bAutoLoadWhatsMissing As Boolean,
                                ByRef pref_success As Boolean)
        ''
        ''Added 12/8/2021 thomas downes
        ''
        If (EnumSideOfCard_Current = EnumWhichSideOfCard.EnumFrontside) Then
            ''Go to backside. 
            EnumSideOfCard_Current = EnumWhichSideOfCard.EnumBackside
        ElseIf (EnumSideOfCard_Current = EnumWhichSideOfCard.EnumBackside) Then
            ''Go to backside. 
            EnumSideOfCard_Current = EnumWhichSideOfCard.EnumFrontside
        ElseIf (EnumSideOfCard_Current = EnumWhichSideOfCard.Undetermined) Then
            ''Go to frontside. 
            EnumSideOfCard_Current = EnumWhichSideOfCard.EnumBackside
        End If

        ''Dec.10 2021''UnloadDesigner()
        UnloadDesigner(False)

        ''1/4/2022 td''LoadDesigner("Called from SwitchSideOfCard")
        ''5/4/2022 td''LoadDesigner("Called from SwitchSideOfCard", mod_oGroupMoveEvents)

        ''Modified to add Boolean parameter on 5/4/2022
        ''5/23/2022 LoadDesigner("Called from SwitchSideOfCard",
        ''             par_bAutoLoadWhatsMissing,
        ''             mod_oGroupMoveEvents)
        LoadDesigner("Called from SwitchSideOfCard",
                     par_bAutoLoadMissingBackground,
                     par_bAutoLoadWhatsMissing,
                     mod_oGroupMoveEvents)

        ''Exit Handler.......
        pref_success = True

    End Sub ''End of "Public Sub SwitchSideOfCard()"

    Public Property LastTouchedMoveableElement As IMoveableElement ''Added 12/17/2021 td
    Public Property LastTouchedClickableElement As IClickableElement ''Added 12/17/2021 td

    Public Property LastControlTouchedRSC As RSCMoveableControlVB Implements ILastControlTouchedRSC.LastControlTouchedRSC
        Get
            ''Throw New NotImplementedException()
            Return CType(mod_ControlLastTouched, RSCMoveableControlVB)
        End Get
        Set(value As RSCMoveableControlVB)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Sub RecordElementLastTouched(par_elementMoved As IMoveableElement, par_elementClicked As IClickableElement) Implements IRecordElementLastTouched.RecordElementLastTouched
        ''
        ''Added 12/17/2021 td
        ''
        ''----Throw New NotImplementedException()
        Me.LastTouchedClickableElement = par_elementClicked
        Me.LastTouchedMoveableElement = par_elementMoved

    End Sub

    ''Private Sub IRecordElementLastTouched_RecordElementLastTouched(par_elementMoved As IMoveableElement, par_elementClicked As IClickableElement) Implements IRecordElementLastTouched.RecordElementLastTouched
    ''    Throw New NotImplementedException()
    ''End Sub

    ''Public Sub Add_Moveability(par_control As Control, par_iSave As ISaveToModel, par_elementMoved As IMoveableElement, par_keepProportions As Boolean) Implements IRecordElementLastTouched.Add_Moveability
    ''    ''
    ''    ''Added 12/17/2021 td
    ''    ''
    ''    ''--Throw New NotImplementedException()
    ''    ''mod_sizing_portrait.Init(mod_designer.CtlGraphic_Portrait.picturePortrait,
    ''    ''  mod_designer.CtlGraphic_Portrait, 10, True,
    ''    ''  mod_sizingElementEvents, False,
    ''    ''  mod_designer.CtlGraphic_Portrait)
    ''    ''''Added 12/1/2021 td 
    ''    ''mod_dictyControlResizing.Add(mod_designer.CtlGraphic_Portrait,
    ''    ''    mod_sizing_portrait)

    ''    Dim objResizeProply As New MoveAndResizeControls_Monem.ControlResizeProportionally_TD()
    ''    Dim objMove As New MoveAndResizeControls_Monem.ControlMove_Group_NonStatic

    ''    Const c_bRepaintAfterResize As Boolean = True ''Added 7/31/2019 td 

    ''    If (par_keepProportions) Then
    ''        ''
    ''        ''We __do__ care about keeping the Width-Height ratio intact. 
    ''        ''Use class ControlResizeProportionally_TD 
    ''        ''
    ''        objResizeProply.Init(par_elementMoved.GetPictureBox(),
    ''                   par_control, 10, c_bRepaintAfterResize,
    ''                mod_designerListener.SizingElementEvents, False,
    ''                par_iSave)
    ''    Else
    ''        ''We __don't__ care about keeping the Width-Height ratio intact. 
    ''        objMove.Init(par_elementMoved.GetPictureBox(),
    ''                   par_control, 10, c_bRepaintAfterResize,
    ''                mod_designerListener.SizingElementEvents, False,
    ''                par_iSave)

    ''    End If ''End of "If (par_keepProportions) Then ... Else ..."

    ''    ''Added 12/1/2021 td 
    ''    mod_designerListener.DictyControlResizing.Add(par_control, objResizeProply)

    ''    ''Added 12/17/2021 td
    ''    If (par_control Is CtlGraphic_Portrait) Then mod_designerListener.Sizing_portrait = objResizeProply
    ''    If (par_control Is CtlGraphic_QRCode) Then mod_designerListener.Sizing_QR = objResizeProply
    ''    If (par_control Is CtlGraphic_Signat) Then mod_designerListener.Sizing_signature = objResizeProply

    ''    ''Do we care about keeing the Width-Height ratio the same?  ("proportionality")
    ''    ''   For the following three(3) controls, Yes, we do.   ---12/23/2021 td 
    ''    Dim bControlProportionedWidthHeight As Boolean = False
    ''    If (par_control Is CtlGraphic_Portrait) Then bControlProportionedWidthHeight = True
    ''    If (par_control Is CtlGraphic_Portrait) Then bControlProportionedWidthHeight = True
    ''    If (par_control Is CtlGraphic_Portrait) Then bControlProportionedWidthHeight = True

    ''    ''--If (bControlProportionedWidthHeight And (par_keepProportions)) Then
    ''    If (bControlProportionedWidthHeight And (objResizeProply Is Nothing)) Then

    ''        Throw New ArgumentException("Boolean parameter par_keepProportions should be False.")

    ''    End If  ''End of "If (bControlProportionedWidthHeight And (objResizeProply Is Nothing)) Then"

    ''    ''12/23/2021 td''If (par_control Is CtlGraphic_StaticText_temp) Then mod_designerListener.Sizing_staticText = objResize

    ''    ''===00==I have removed object-reference CtlGraphic_StaticText_temp from this module, as I
    ''    ''===00==    feel that a List of potentially several controls of type CtlGraphicStaticText
    ''    ''===00==    is more appropriate.   ----1/8/2022 td
    ''    ''===If (par_control Is CtlGraphic_StaticText_temp) Then
    ''    ''===
    ''    ''===If (objMove Is Nothing) Then Throw New ArgumentException("Boolean parameter should be False.")
    ''    ''===      mod_designerListener.Sizing_staticText = objMove
    ''    ''===End If ''End of "If (par_control Is CtlGraphic_StaticText_temp) Then"

    ''End Sub ''end of Sub Add_Moveability

    ''Public Sub Add_Clickability(par_elementClicked As IClickableElement) Implements IRecordElementLastTouched.Add_Clickability
    ''    ''
    ''    ''Added 12/17/2021 td
    ''    ''
    ''    ''--Throw New NotImplementedException()

    ''End Sub

    ''Public Sub Remove_Moveability(par_elementMoved As IMoveableElement) Implements IRecordElementLastTouched.Remove_Moveability
    ''    ''
    ''    ''Added 12/17/2021 td
    ''    ''
    ''    Throw New NotImplementedException()

    ''End Sub

    ''Public Sub Remove_Clickability(par_elementClicked As IClickableElement) Implements IRecordElementLastTouched.Remove_Clickability
    ''    ''
    ''    ''Added 12/17/2021 td
    ''    ''
    ''    Throw New NotImplementedException()

    ''End Sub

    Public Sub RefreshPreview() Implements IRefreshCardPreview.RefreshCardPreview
        ''
        ''Added 12/27/2021 thomas downes 
        ''
        RefreshPreview_CurrentSide()

        ''RefreshPreview_Redux_Front()
        ''---Me.DesignerForm_Interface.RefreshPreview()
        ''Jan14, 2022''If (Me.EnumSideOfCard_Current = EnumWhichSideOfCard.EnumBackside) Then
        ''Jan14    ''---RefreshPreview_Redux_Backside()
        ''Jan14    RefreshPreview_EitherSide(New ClassBadgeSideLayoutV1())
        ''Jan14Else
        ''Jan14    RefreshPreview_Redux_Front()
        ''Jan14End If

    End Sub ''End of "Public Sub RefreshPreview()"


    Public Function GetParametersToGetElementControl() As ClassGetElementControlParams
        ''
        ''Added 1/17/2022 td
        ''
        Dim oGetControlParameters As New ClassGetElementControlParams
        ''
        ''Set the various properties. 
        ''
        With oGetControlParameters
            .ElementsCache = ElementsCache_UseEdits ''Added 5/5/2022
            .ElementsCacheManager = ElementsCache_Manager
            .iLayoutFunctions = CType(Me, ILayoutFunctions)
            .iRefreshPreview = CType(Me, IRefreshCardPreview)
            .DesignerForm = Me.DesignerForm
            .iControlLastTouched = CType(Me.mod_ctlLasttouched, ILastControlTouched)
            .oMoveEventsGroupedControls = mod_oGroupMoveEvents
            .DesignerClass = Me ''Added 1/24/2022 thomas downes  
        End With ''End of "With oGetControlParameters"

        Return oGetControlParameters

    End Function ''End of "Public Function GetParametersToGetElementControl() As ClassGetElementControlParams"


    Public Sub ClearObjectReferences(par_type As Type)
        ''
        ''Added 5/15/2022 thomas d.
        ''
        ''5/15/2022 If (TypeOf par_type Is TypeOf CtlGraphicPortrait) Then
        If (par_type.Equals(GetType(CtlGraphicPortrait))) Then

            Me.CtlGraphic_Portrait_List.Clear()

        End If

        If (par_type.Equals(GetType(CtlGraphicSignature))) Then

            Me.CtlGraphic_Signat_List.Clear()

        End If

        If (par_type.Equals(GetType(CtlGraphicQRCode))) Then

            Me.CtlGraphic_QRCode_List.Clear()

        End If


    End Sub ''End of ""Public Sub ClearObjectReferences(par_type As Type)""


    Private Sub DesignerForm_KeyUp(sender As Object, e As KeyEventArgs) Handles DesignerForm.KeyUp
        ''
        ''Added 8/15/2022 thomas downes
        ''
        If (e.KeyCode = Keys.Delete) Then

            ''8/2022 mod_objOperationsGeneric.DeleteElement()
            ''8/2022 Dim objOpsBase As ciBadgeDesigner.Operations__Base
            ''8/2022 objOpsBase = CType(mod_objOperationsAny, ciBadgeDesigner.Operations__Base)

            ''8/2022 If (True) Then
            ''8/2022 Dim infoDelete As IDeleteElement
            ''infoDelete = CType(mod_objOperationsAny, ciBadgeInterfaces.IDeleteElement)
            ''infoDelete.DeleteElementIfConfirmed()

            If (Me.LastTouchedMoveableElement IsNot Nothing) Then

                ''Added 8/15/2022 thomas downes
                Me.LastTouchedMoveableElement.DeleteIfConfirmed()

            End If ''End of ""If (Me.LastTouchedMoveableElement IsNot Nothing) Then""

        End If ''End of ""If (e.KeyCode = Keys.Delete) Then""

    End Sub


    Private Sub BackgroundBox_Front_KeyUp(sender As Object, e As KeyEventArgs) Handles BackgroundBox_Front.KeyUp
        ''
        ''Added 8/15/2022 thomas downes
        ''
        If (e.KeyCode = Keys.Delete) Then

            ''8/2022 mod_objOperationsGeneric.DeleteElement()
            ''8/2022 Dim objOpsBase As ciBadgeDesigner.Operations__Base
            ''8/2022 objOpsBase = CType(mod_objOperationsAny, ciBadgeDesigner.Operations__Base)

            If (True) Then
                Dim infoDelete As IDeleteElement
                ''infoDelete = CType(mod_objOperationsAny, ciBadgeInterfaces.IDeleteElement)
                ''infoDelete.DeleteElementIfConfirmed()
            End If

        End If ''Endof ""If (e.KeyCode = Keys.Delete) Then""

    End Sub


End Class ''End of "Public Class ClassDesigner"
