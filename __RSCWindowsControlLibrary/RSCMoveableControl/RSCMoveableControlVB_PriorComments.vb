﻿Option Explicit On
Option Strict On

Imports MoveAndResizeControls_Monem ''Added 12/22/2021 td
Imports ciBadgeInterfaces ''Added 12/22/2021 td
''--Imports windows.Forms ''Added 12/22/2021
Imports System.Windows.Forms
Imports ciBadgeDesigner ''Added 12/27/2021 td 

''
''Added 12/22/2021 td  
''
Public Class RSCMoveableControlVB_PriorComments
    Implements ISaveToModel ''Added 1/2/2022 td 

    ''
    ''Added 12/22/2021 td  
    ''
    Public Shared LastControlTouched_Deprecated As RSCMoveableControlVB_PriorComments

    Public Shared Function GetControl(par_enum As EnumElementType,
                                      par_nameOfControl As String,
                                      par_iLayoutFun As ILayoutFunctions,
                                      par_bProportionSizing As Boolean,
                                par_iControlLastTouched As ILastControlTouched,
                                      par_oMoveEventsFromForm As GroupMoveEvents_Singleton,
                           Optional par_ratioWH_ifApplicable As Single = 0,
                           Optional pbHandleMouseEventsThroughFormVB6 As Boolean = True) As RSCMoveableControlVB_PriorComments
        ''                      ''Jan2 2022 td''  par_iSaveToModel As ISaveToModel,
        ''                      ''Dec29 2021 td'' par_designer As ClassDesigner,
        ''
        ''Added 12/29/2021 td
        ''
        Const bAddFunctionalitySooner As Boolean = False
        Const bAddFunctionalityLater As Boolean = True

        Dim typeOps As Type
        Dim objOperations As Object ''Added 12/29/2021 td 
        Dim objOperations1Gen As Operations__Generic = Nothing
        Dim objOperations2Use As Operations__Useless = Nothing

        ''Instantiate the Operations Object. 
        If (par_enum = EnumElementType.Field) Then objOperations1Gen = New Operations__Generic()
        If (par_enum = EnumElementType.Portrait) Then objOperations2Use = New Operations__Useless()
        If (par_enum = EnumElementType.QRCode) Then objOperations1Gen = New Operations__Generic()
        If (par_enum = EnumElementType.Signature) Then objOperations2Use = New Operations__Useless()
        If (par_enum = EnumElementType.StaticGraphic) Then objOperations1Gen = New Operations__Generic()
        If (par_enum = EnumElementType.StaticText) Then objOperations2Use = New Operations__Useless()

        ''Assign to typeOps. 
        If (par_enum = EnumElementType.Field) Then typeOps = objOperations1Gen.GetType()
        If (par_enum = EnumElementType.Portrait) Then typeOps = objOperations2Use.GetType()
        If (par_enum = EnumElementType.QRCode) Then typeOps = objOperations1Gen.GetType()
        If (par_enum = EnumElementType.Signature) Then typeOps = objOperations2Use.GetType()
        If (par_enum = EnumElementType.StaticGraphic) Then typeOps = objOperations1Gen.GetType()
        If (par_enum = EnumElementType.StaticText) Then typeOps = objOperations2Use.GetType()

        ''Assign to objOperations. 
        If (par_enum = EnumElementType.Field) Then objOperations = objOperations1Gen
        If (par_enum = EnumElementType.Portrait) Then objOperations = objOperations2Use
        If (par_enum = EnumElementType.QRCode) Then objOperations = objOperations1Gen
        If (par_enum = EnumElementType.Signature) Then objOperations = objOperations2Use
        If (par_enum = EnumElementType.StaticGraphic) Then objOperations = objOperations1Gen
        If (par_enum = EnumElementType.StaticText) Then objOperations = objOperations2Use

        If (objOperations Is Nothing) Then
            ''Added 12/29/2021
            Throw New Exception("Ops is Nothing, so I guess Element Type is Undetermined.")
        End If ''end of "If (objOperations Is Nothing) Then"

        ''Create the control. 
        Dim MoveableControlVB1 = New RSCMoveableControlVB_PriorComments(par_enum, par_bProportionSizing,
                                                   par_iLayoutFun,
                                                   typeOps,
                                                   objOperations,
                                                   bAddFunctionalitySooner,
                                                   bAddFunctionalitySooner,
                                                   par_iControlLastTouched,
                                                   par_oMoveEventsFromForm,
                                                   par_ratioWH_ifApplicable,
                                                   pbHandleMouseEventsThroughFormVB6)
        ''                                         ''Jan2 2022 ''par_iSaveToModel,

        With MoveableControlVB1
            .Name = par_nameOfControl
            ''Jan4 2022''If (bAddFunctionalityLater) Then .AddMoveability(par_oMoveEventsFromForm)
            ''Jan10 2022''If (bAddFunctionalityLater) Then .AddMoveability(par_oMoveEventsFromForm, par_iLayoutFun)
            If (bAddFunctionalityLater) Then .AddMoveability(par_oMoveEventsFromForm, Nothing, par_iLayoutFun)
            If (bAddFunctionalityLater) Then .AddClickability()
            ''In the constructor. Dec31 2021 ''.LastControlTouched_Info = par_iControlLastTouched ''Added 12/31/2021 td
        End With ''eNd of "With MoveableControlVB1"

        ''
        ''Specify the current element to the Operations object. 
        ''
        Dim infoOps = CType(objOperations, ICurrentElement) ''.CtlCurrentElement = MoveableControlVB1
        infoOps.CtlCurrentElement = MoveableControlVB1

        Return MoveableControlVB1

    End Function ''End of Public Shared Function GetControl


    Public Property MoveabilityEventsForGroupCtls As GroupMoveEvents_Singleton
        ''Jan4 2022''Public WriteOnly Property MoveabilityEvents As GroupMoveEvents_Singleton
        Get
            ''Added 1/4/2022 td 
            Return mod_eventsForGroupMove_NotNeeded
        End Get
        Set(value As GroupMoveEvents_Singleton)
            ''Added 1/3/2022 td  
            mod_eventsForGroupMove_NotNeeded = value
        End Set
    End Property


    Public Property MoveabilityEventsForSingleMove As GroupMoveEvents_Singleton
        Get
            ''Added 1/10/2022 td 
            Return mod_eventsForSingleMove
        End Get
        Set(value As GroupMoveEvents_Singleton)
            ''Added 1/10/2022 td  
            mod_eventsForSingleMove = value
        End Set
    End Property


    Public LastControlTouched_Info As ILastControlTouched ''Added 12/28/2021 thomas d. 
    Public MyToolstripItemCollection As ToolStripItemCollection ''Added 12/28/2021 td
    Public ExpectedProportionWH As Single = 0 ''Added 1/4/2022 td  
    Private mod_boolResizeProportionally As Boolean

    ''Added 1/10/2022 td 
    Public TempResizeInfo_W As Integer = 0 ''Intial resizing width.  (Before any adjustment is made.)
    Public TempResizeInfo_H As Integer = 0 ''Intial resizing height.  (Before any adjustment is made.)
    Public TempResizeInfo_Left As Integer = 0 ''Intial resizing Left.  (Before any adjustment is made.)
    Public TempResizeInfo_Top As Integer = 0 ''Intial resizing Top.  (Before any adjustment is made.)

    ''Added 1/4/2022 thomas d. 
    '' Monem = Seyyed Hamed Monem
    '' https://www.codeproject.com/tips/709121/move-and-resize-controls-on-a-form-at-runtime-with 
    ''
    Protected mod_bHandleMouseMoveEvents_Monem As Boolean = False
    Protected mod_bHandleMouseMoveEvents_ByForm As Boolean = True ''True, let's handler Mouse-Move events 
    ''   the old-fashioned way--by handling events on the Windows form (e.g. VB6-style).
    Protected mod_bHandleMouseMoveEvents_BaseClass As Boolean = True ''Added 1/7/2022
    Protected mod_bHandleMouseMoveEvents_ChildClass As Boolean = False ''Added 1/7/2022
    Protected mod_bHandleMouseMoveEvents_RemoveAll As Boolean = True ''Added 1/7/2022

    ''Depending on the above Boolean, one of the following will be instantiated. 
    ''Let's rename. 12/28/2021 td''Private mod_movingInAGroup As ControlMove_Group_NonStatic = Nothing
    ''Let's rename. 12/28/2021 td''Private mod_resizeProportionally As ControlResizeProportionally_TD = Nothing
    ''
    '' Let's reference two modules written by Seyyed Hamed Monem
    ''     (modified & bifurcated into two, by Thomas C. Downes) 
    ''
    '' https://www.codeproject.com/tips/709121/move-and-resize-controls-on-a-form-at-runtime-with 
    ''
    ''    Move And Resize Controls on a Form at Runtime(With Mouse)
    ''
    ''Jan10 2022''Private mod_moveInAGroup As ControlMove_Group_NonStatic = Nothing
    ''Jan10 2022''Private mod_moveResizeKeepRatio As ControlResizeProportionally_TD = Nothing
    ''Jan11 2022''Private mod_moveability_Monem As ControlMove_Group_NonStatic = Nothing
    Private mod_moveability_Monem As ControlMove_AllFunctionality = Nothing

    ''Dec29 2021''Private mod_iMoveOrResize As InterfaceMoveOrResize ''Added 12/28/2021 td
    Protected mod_iMoveOrResizeFunctionality As IMoveOrResizeFunctionality ''Added 12/28/2021 td

    ''1/3/2022 td''Private WithEvents mod_events As New GroupMoveEvents_Singleton ''InterfaceEvents
    ''Jan4 2022''Private WithEvents mod_events As GroupMoveEvents_Singleton ''InterfaceEvents
    Protected mod_eventsForGroupMove_NotNeeded As GroupMoveEvents_Singleton ''InterfaceEvents
    Private WithEvents mod_eventsForSingleMove As GroupMoveEvents_Singleton ''InterfaceEvents

    Protected ElementInfo_Base As ciBadgeInterfaces.IElement_Base ''Added 1/10/2022 thomas d.

    ''#1 Jan2 2022''Private mod_iSaveToModel As ISaveToModel 
    ''#2 Jan2 2022''Private mod_iSaveToModel_Deprecated As ISaveToModel = New ClassSaveToModel() ''Suffixed _Deprecated 1/2/2022 td
    ''#3 Jan2 2022''Private mod_iSaveToModel As ISaveToModel = New ClassSaveToModel() 
    ''Dec28 2021 td''Private WithEvents mod_designer As New ClassDesigner ''Added 12/27/2021 td
    Private WithEvents ContextMenuStrip1 As New ContextMenuStrip ''Added 12/28/2021 thomas downes
    ''Jan4 2022''Private mod_iLayoutFunctions As ILayoutFunctions ''Added 12/28/2021 td
    Protected mod_iLayoutFunctions As ILayoutFunctions ''Added 12/28/2021 td
    ''Dec29 2021''Private mod_designer As ClassDesigner ''Added 12/28/2021 td 
    Private Const mc_AddExtraHeadersForContextMenuStrip As Boolean = True ''Added 12/28/2021 thomas d.

    ''Added 12/28/2021 td
    Private mod_objOperationsAny As Object ''Added 12/28/2021 td
    Private mod_typeOperations As Type ''Added 12/28/2021 td
    Private mod_enumElementType As EnumElementType ''Added 12/28/2021 td

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ''Encapsulated 12/22/2021 thomas downes
        ''Dec27 2021''InitializeMoveability(False, New ClassSaveToModel)

        ''12/29/2021 td''Dim objLayoutFun As New ClassDesigner ''Added Dec27 2021
        ''12/29/2021 td''InitializeMoveability(False, New ClassSaveToModel, New ClassDesigner())
        ''01/02/2022 ''InitializeMoveability(False, New ClassSaveToModel, New ClassLayoutFunctions())
        ''01/03/2022 ''InitializeMoveability(False, New ClassLayoutFunctions())

        ''Encapsulated 12/22/2021 thomas downes
        ''  Dec28 2021 td''InitializeClickability(New ClassDesigner())
        ''  Dec29 2021 td''InitializeClickability(New ClassDesigner(), EnumElementType.Undetermined)
        ''Jan4 2022 td''InitializeClickability(EnumElementType.Undetermined)

        ''Don't expect the Moveability to work, we are sending the events
        ''   into a blackhole!!  ---1/4/2022 td
        Dim dummyLayout As New ClassLayoutFunctions
        Dim oEventkillingBlackhole As New GroupMoveEvents_Singleton(dummyLayout, True)
        InitializeClickability(EnumElementType.Undetermined, oEventkillingBlackhole)

        ''Added 1/3/2022 td
        ''Jan3 2022 td''LastControlTouched_Info = New ClassLast

    End Sub ''End of "Public Sub New()"


    Public Sub New(par_enumElementType As EnumElementType,
                  pboolResizeProportionally As Boolean,
                   par_iLayoutFun As ILayoutFunctions,
                   par_operationsType As Type,
                   par_operationsAny As Object,
                   pboolAddMoveability As Boolean,
                   pboolAddClickability As Boolean,
                   par_iLastTouched As ILastControlTouched,
                   par_oMoveabilityEventsForGroup As GroupMoveEvents_Singleton,
                   par_proportionWH_IfNeeded As Single,
                   Optional pbHandleMouseEventsThroughFormVB6 As Boolean = True,
                   Optional pbUseMonemProportionalityClass As Boolean = False) ''----As IOperations)
        ''
        ''         ''Jan2 2022 ''par_iSaveToModel As ISaveToModel,
        ''         ''Dec29 2021 ''par_designer As ClassDesigner,

        ''12/28/2021 td''par_toolstrip As ToolStripItemCollection)

        ' This call is required by the designer.
        InitializeComponent()

        ''Added 1/4/2022 td
        Me.ExpectedProportionWH = par_proportionWH_IfNeeded

        ''Jan10 2022''mod_events = par_oMoveabilityEvents
        mod_eventsForGroupMove_NotNeeded = par_oMoveabilityEventsForGroup

        ''Added 1/10/2022 td
        ''We need to instantiate a class. It's just for the movement of a single control, so
        ''  we probably don't need to use a shared class. In fact, it's better if we don't.
        ''  ---1/10/2022 td
        If (pboolAddMoveability) Then mod_eventsForSingleMove = New GroupMoveEvents_Singleton()

        ''Encapsulated 1/3/2022 td 
        Load_Functionality(par_enumElementType, pboolResizeProportionally,
                            par_iLayoutFun,
                            par_operationsType,
                            par_operationsAny,
                            pboolAddMoveability,
                            pboolAddClickability,
                            par_iLastTouched,
                            par_oMoveabilityEventsForGroup,
                            mod_eventsForSingleMove,
                            pbHandleMouseEventsThroughFormVB6,
                            pbUseMonemProportionalityClass)

        ''Not needed. 1/10/2022 td. ---Added 1/5/2022 td
        ''RemoveHandler mod_events.Moving_End, AddressOf mod_events_Moving_End
        ''RemoveHandler mod_events.Moving_End, AddressOf mod_events_Moving_End
        ''RemoveHandler mod_events.Moving_End, AddressOf mod_events_Moving_End
        ''AddHandler mod_events.Moving_End, AddressOf mod_events_Moving_End

    End Sub ''End of "Public Sub New"


    Public Function FullNameOfThisBaseClass() As String
        ''
        ''Added 1/5/2022 thomas downes
        ''
        ''  Should return "__RSC_WindowsControlLibrary.RSCMoveableControl".
        ''
        Return Me.GetType().FullName

    End Function ''Added Public Function FullNameOfThisBaseClass() As String


    Public Sub Load_Functionality(par_enumElementType As EnumElementType,
                  pboolResizeProportionally As Boolean,
                   par_iLayoutFun As ILayoutFunctions,
                   par_operationsType As Type,
                   par_operationsAny As Object,
                   pboolAddMoveability As Boolean,
                   pboolAddClickability As Boolean,
                   par_iLastTouched As ILastControlTouched,
                   par_oMoveEventsGroupOfCtls As GroupMoveEvents_Singleton,
                   par_oMoveEventsSingleCtl As GroupMoveEvents_Singleton,
                   Optional pbHandleMouseEventsThroughFormVB6 As Boolean = True,
                   Optional pbUseMonemProportionalityClass As Boolean = False)
        ''
        ''Encapsulated 1/3/2022
        ''
        ''Encapsulated 12/22/2021 thomas downes
        ''====InitializeMoveability(pboolResizeProportionally, par_iSaveToModel)
        ''Jan2 2022 td''mod_iSaveToModel = par_iSaveToModel ''Added 12/28/2021 td
        mod_boolResizeProportionally = pboolResizeProportionally ''Added 12/28/2021 td
        mod_iLayoutFunctions = par_iLayoutFun
        Me.LastControlTouched_Info = par_iLastTouched ''Added 12/29/2021 thomas d. 

        ''12/28/2021 td''InitializeMoveability(pboolResizeProportionally, par_iSaveToModel, par_iLayoutFun)
        ''#2 Dec28_2021 td''AddMoveability()
        ''Jan4 2022 td''If (pboolAddMoveability) Then AddMoveability()
        ''#2 Jan4 2022 td''If (pboolAddMoveability) Then AddMoveability(par_oMoveEventsFromForm)
        If (pboolAddMoveability) Then

            ''Jan7 2022 td''AddMoveability(par_oMoveEventsFromForm, par_iLayoutFun)
            AddMoveability(par_oMoveEventsGroupOfCtls,
                           par_oMoveEventsSingleCtl, par_iLayoutFun,
                           pboolResizeProportionally,
                           pbHandleMouseEventsThroughFormVB6,
                           pbUseMonemProportionalityClass)

        End If ''EDNOF "If (pboolAddMoveability) Then"

        ''Encapsulated 12/22/2021 thomas downes
        ''Dec28 2021 td''Me.MyToolstripItemCollection = par_toolstrip ''Added 12/28/2021 td
        ''Dec29 2021 td''mod_designer = par_designer

        mod_enumElementType = par_enumElementType
        mod_objOperationsAny = par_operationsAny
        mod_typeOperations = par_operationsType

        ''Dec28_2021 td''InitializeClickability(par_designer)
        ''#2 Dec28_2021 td''AddClickability()
        If (pboolAddClickability) Then AddClickability()

        ''Not needed. 1/10/2022 td. ---Added 1/5/2022 td
        ''Added 1/5/2022 td
        ''  Trying to prevent multiple event-handler connections. 
        ''RemoveHandler mod_events.Moving_End, AddressOf mod_events_Moving_End
        ''RemoveHandler mod_events.Moving_End, AddressOf mod_events_Moving_End
        ''RemoveHandler mod_events.Moving_End, AddressOf mod_events_Moving_End
        ''AddHandler mod_events.Moving_End, AddressOf mod_events_Moving_End

    End Sub ''End of "Public Sub Load_Functionality()"


    Public Sub AddMoveability(par_objEventsMoveGroupOfCtls As GroupMoveEvents_Singleton,
                              par_objEventsMoveSingleControl As GroupMoveEvents_Singleton,
                              par_iLayoutFunctions As ILayoutFunctions,
                              Optional pbAddProportionality As Boolean = False,
                              Optional pbHandleMouseEventsThroughFormVB6 As Boolean = True,
                              Optional pbUseMonemProportionalityClass As Boolean = False)
        ''Jan3 2022 ''Public Sub AddMoveability()
        ''
        ''Added 12/28/2021 td
        ''
        ''Dec28 2021''InitializeMoveability(mod_boolResizeProportionally, mod_iSaveToModel, mod_iLayoutFunctions)

        Dim boolInstantiated As Boolean ''Added 12/28/2021 td

        ''Jan11 2022 td''boolInstantiated = (mod_moveInAGroup IsNot Nothing) OrElse (mod_moveResizeKeepRatio IsNot Nothing)
        boolInstantiated = (mod_eventsForSingleMove IsNot Nothing)

        ''Added 1/10/2022 td
        If (par_objEventsMoveGroupOfCtls Is Nothing) Then

            ''The parameter object-reference is for the movement of a group of controls, so
            ''  we probably can't simple instantiate a class. In fact, it's certain we have to
            ''  throw an exception. ---1/10/2022 td
            Throw New NullReferenceException("Group-related events must be shared across controls.")

        ElseIf (par_objEventsMoveSingleControl Is Nothing) Then

            ''We need to instantiate a class. It's just for the movement of a single control, so
            ''  we probably don't need to use a shared class. In fact, it's better if we don't.
            ''  ---1/10/2022 td
            par_objEventsMoveSingleControl = New GroupMoveEvents_Singleton
            Me.MoveabilityEventsForSingleMove = par_objEventsMoveSingleControl

        End If ''End of "If (par_objEventsMoveGroupOfCtls Is Nothing) Then .... ElseIf (par_objEventsMoveSingleControl Is Nothing) Then"

        ''
        ''First major step....
        ''
        If (boolInstantiated) Then ''Added 12/28/2021 td
            ''Added 12/28/2021 td
            ''  If instantiated, then set the Boolean property to false. 
            ''
            mod_iMoveOrResizeFunctionality.RemoveAllFunctionality = False
            If (mod_moveInAGroup IsNot Nothing) Then mod_moveInAGroup.RemoveAllFunctionality = False
            If (mod_moveResizeKeepRatio IsNot Nothing) Then mod_moveResizeKeepRatio.RemoveAllFunctionality = False

            ''Added 1/3/2022 td
            ''  Refresh the module-level reference with the
            ''  object reference from the Designer-Form itself. 
            ''  ---1/4/2022 td  
            If (par_objEventsMoveGroupOfCtls IsNot Nothing) Then Me.MoveabilityEventsForGroupCtls = par_objEventsMoveGroupOfCtls
            If (par_objEventsMoveSingleControl IsNot Nothing) Then Me.MoveabilityEventsForSingleMove = par_objEventsMoveSingleControl

        Else
            ''Added 1/2/2022 td''InitializeMoveability(mod_boolResizeProportionally, mod_iSaveToModel, mod_iLayoutFunctions)
            ''Jan2 2022 ''InitializeMoveability(mod_boolResizeProportionally, Me, mod_iLayoutFunctions)
            ''Jan3 2022 ''InitializeMoveability(mod_boolResizeProportionally, mod_iLayoutFunctions)
            If (mod_iLayoutFunctions Is Nothing) Then mod_iLayoutFunctions = par_iLayoutFunctions

            ''Added 1/4/2022 td
            If (pbAddProportionality) Then
                ''
                ''Try to make sure that a control maintains its ratio of Width to Height,
                ''   called "Proportionality" in this application. ---1/10/2022 td
                ''
                mod_boolResizeProportionally = pbAddProportionality ''Added 1/4/2022 td
            End If ''end if "If (pbAddProportionality) Then"

            ''
            ''Major call !!
            ''
            ''Jan10 2022 td''InitializeMoveability(mod_boolResizeProportionally, mod_iLayoutFunctions,
            ''      par_objEventsMoveGroupOfCtls, pbHandleMouseEventsThroughFormVB6,
            ''      pbUseMonemProportionalityClass)
            InitializeMoveability(mod_boolResizeProportionally, mod_iLayoutFunctions,
                                  par_objEventsMoveGroupOfCtls,
                                  par_objEventsMoveSingleControl,
                                  pbHandleMouseEventsThroughFormVB6,
                                  pbUseMonemProportionalityClass)

        End If ''End of "If (boolInstantiated) Then ... Else ...."

    End Sub ''End of Public Sub AddMoveability 


    Public Sub AddMoveability_ViaLabel(par_Label As Label)
        ''
        ''Added 1/4/2022 td
        ''
        mod_iMoveOrResizeFunctionality.AddMoveability_ViaLabel(par_Label)

    End Sub


    Public Sub AddMoveability_ViaPictureBox(par_PictureBox As PictureBox)
        ''
        ''Added 1/4/2022 td
        ''


    End Sub


    Public Sub RemoveMoveability(Optional pboolUseEasyWay As Boolean = True,
                                 Optional pbBlackholeMethed As Boolean = False)
        ''
        ''Added 12/28/2021 td
        ''
        If (mod_iMoveOrResizeFunctionality Is Nothing) Then Return ''Added 1/4/2022 td

        If (Not pboolUseEasyWay And pbBlackholeMethed) Then
            ''Added 1/3/2022 td
            ''//Great for removing functionality!  
            ''//  (But potentially depressing, since your app won't work
            ''//       (& you won't know why)!!)
            ''//   ----1/3/2022 td 
            ''//
            mod_iMoveOrResizeFunctionality.KillAllEvents_Blackhole()

        ElseIf (Not pboolUseEasyWay) Then
            mod_iMoveOrResizeFunctionality.Reverse_Init() ''Added 12/28/2021 td

        ElseIf (pboolUseEasyWay) Then
            mod_iMoveOrResizeFunctionality.RemoveAllFunctionality = True ''Added 12/28/2021 td

        End If


        ''If (True Or Not mod_boolResizeProportionally) Then
        ''    ''mod_movingInAGroup.UndloadEventHandlers()
        ''    If (mod_moveInAGroup IsNot Nothing) Then
        ''        ''Doesn't work well. ''mod_movingInAGroup.RemoveEventHandlers()
        ''        ''#1 Dec28 2021 td''mod_movingInAGroup.Reverse_Init() ''Added 12/28/2021 td
        ''        ''#2 Dec28 2021 td''mod_moveInAGroup.RemoveAllFunctionality = True ''Added 12/28/2021 td

        ''        If (Not pboolUseEasyWay) Then mod_moveInAGroup.Reverse_Init() ''Added 12/28/2021 td
        ''        If (pboolUseEasyWay) Then mod_moveInAGroup.RemoveAllFunctionality = True ''Added 12/28/2021 td

        ''        ''Dec28 2021 td''mod_movingInAGroup.Dispose() ''Added 12/28/2021 td

        ''    End If ''End of "If (mod_movingInAGroup IsNot Nothing) Then"
        ''    ''Doesn't work well. Dec28 2021 td''mod_movingInAGroup = Nothing
        ''End If ''End of "If (True Or Not mod_boolResizeProportionally) Then"

        ''If (True Or mod_boolResizeProportionally) Then
        ''    ''mod_resizingProportionally.UnloadEventHandlers()
        ''    If (mod_moveResizeKeepRatio IsNot Nothing) Then
        ''        ''Doesn't work well. Dec28 2021 td''mod_resizingProportionally.RemoveEventHandlers()
        ''        ''#2 Dec28 2021 td''mod_moveResizeKeepRatio.RemoveAllFunctionality = True ''Added 12/28/2021 td

        ''        If (Not pboolUseEasyWay) Then mod_moveResizeKeepRatio.Reverse_Init() ''Added 12/28/2021 td
        ''        If (pboolUseEasyWay) Then mod_moveResizeKeepRatio.RemoveAllFunctionality = True ''Added 12/28/2021 td

        ''        ''Dec28 2021 td''mod_movingInAGroup.Dispose() ''Added 12/28/2021 td

        ''    End If ''end of "If (mod_resizingProportionally IsNot Nothing) Then"
        ''    ''Doesn't work well. Dec28 2021 td''mod_resizingProportionally = Nothing

        ''End If ''ENd of "If (True Or mod_boolResizeProportionally) Then"

    End Sub ''End of "Public Sub RemoveMoveability()"


    Public Sub AddClickability()
        ''
        ''Added 12/28/2021 td
        ''
        ''Dec28 2021''InitializeClickability(mod_designer)
        Init_ForRightClicked()

    End Sub ''End of "Public Sub AddClickability()"


    Public Sub RemoveClickability()
        ''
        ''Added 12/28/2021 td
        ''
        Me.ContextMenuStrip1 = Nothing
        Me.mod_objOperationsGeneric = Nothing
        Me.mod_objOperationsUseless = Nothing
        Me.mod_moveResizeKeepRatio = Nothing
        Me.mod_moveInAGroup = Nothing

    End Sub ''End of "Public Sub AddClickability()"


    Public Sub AddSizeability(Optional pboolUseEasyWay As Boolean = True)
        ''
        ''Added 12/28/2021 td
        ''
        Dim bAddSizing As Boolean = True ''True, because we want sizing.''Dec 29 2021 td

        ''----DIFFICULT & CONFUSING-------
        ''     We need to negate the Boolean variable (Not bAddSizing).
        ''
        mod_iMoveOrResizeFunctionality.RemoveSizeability = (Not bAddSizing) ''Added 12/28/2021 td

    End Sub


    Public Sub RemoveSizeability(Optional pboolUseEasyWay As Boolean = True)
        ''
        ''Added 12/28/2021 td
        ''
        Dim bAddSizing As Boolean = False ''False, as we are stopping sizing. ---Dec 29 2021 td

        ''----DIFFICULT & CONFUSING-------
        ''     We need to negate the Boolean variable (Not bAddSizing).
        ''
        mod_iMoveOrResizeFunctionality.RemoveSizeability = (Not bAddSizing) ''Added 12/28/2021 td

    End Sub


    Public Sub InitializeMoveability(pboolResizeProportionally As Boolean,
                                     par_iLayoutFunctions As ILayoutFunctions,
                                     par_objMoveEventsForGroupMove As GroupMoveEvents_Singleton,
                                     par_objMoveEventsForSingleCtl As GroupMoveEvents_Singleton,
                      Optional pbHandleMouseEventsThroughFormVB6 As Boolean = True,
                      Optional pbUseMonemProportionalityClass As Boolean = False)
        ''
        ''Jan2 2022''       par_iSaveToModel As ISaveToModel,
        ''
        ''Added 12/22/2021 thomas downes
        ''
        Dim objPictureBox As PictureBox

        ' Add any initialization after the InitializeComponent() call.
        mod_boolResizeProportionally = pboolResizeProportionally ''Added 12/22/2021 td
        ''Jan2 2022 td''mod_iSaveToModel = par_iSaveToModel
        Const c_bRepaintAfterResize As Boolean = True ''Added 7/31/2019 td

        ''Added 12/28/2021 td
        ''  Prepare for the next steps.
        ''
        mod_moveResizeKeepRatio = Nothing
        mod_moveInAGroup = Nothing

        ''Jan10 2022 td''mod_events = par_objMoveEvents ''Added 1/3/2022 thomas 
        ''Jan10 2022 td''mod_events.LayoutFunctions = par_iLayoutFunctions

        mod_eventsForGroupMove_NotNeeded = par_objMoveEventsForGroupMove ''Added 1/3/2022 thomas 
        mod_eventsForSingleMove = par_objMoveEventsForSingleCtl ''Added 1/10/2022 thomas 

        ''Jan10 2022 td''mod_events.LayoutFunctions = par_iLayoutFunctions
        If (mod_eventsForGroupMove_NotNeeded.LayoutFunctions Is Nothing) Then ''Added 1/10/2022
            mod_eventsForGroupMove_NotNeeded.LayoutFunctions = par_iLayoutFunctions ''Added 1/10/2022
        End If
        mod_eventsForSingleMove.LayoutFunctions = par_iLayoutFunctions ''Added 1/10/2022

        ''Added 1/4/2022 td
        objPictureBox = Find_PictureBox()

        ''
        ''Instantiate the Resizing or Moving modules (instances).
        ''
        If pboolResizeProportionally Then
            ''
            ''Let's try to make sure that the control's Width-Height ratio stays constant.
            ''  ----1/10/2022 td
            ''
            ''Encapsulated 1/10/2022 td
            InitializeMoveability_MonemProportional(par_iLayoutFunctions, objPictureBox,
                                     c_bRepaintAfterResize)

            ''mod_events.LayoutFunctions = par_iLayoutFunctions ''Added 12/27/2021

            ''mod_moveResizeKeepRatio = New MoveAndResizeControls_Monem.ControlResizeProportionally_TD()

            ''''#1 Jan4 2022 ''mod_moveResizeKeepRatio.Init(Me, Me, 10, c_bRepaintAfterResize,
            ''''                mod_events, False, Me)
            ''''#2 Jan4 2022 ''mod_moveResizeKeepRatio.Init(Nothing, Me, 10, c_bRepaintAfterResize,
            ''''                mod_events, False, Me)

            ''''Added 1/4/2022 td
            ''objPictureBox = Find_PictureBox()

            ''''Added 1/4/2022 td
            ''Dim singleProportionWH As Single = 0 ''Added 1/4/2022 td

            ''''Added 1/4/2022 td
            ''If (Me.ExpectedProportionWH <> 0) Then
            ''    singleProportionWH = Me.ExpectedProportionWH
            ''    Me.Width = CInt(Me.Height * Me.ExpectedProportionWH) ''Added 1/4/2022
            ''ElseIf (objPictureBox IsNot Nothing) Then
            ''    singleProportionWH = CSng(objPictureBox.Width / objPictureBox.Height)
            ''End If ''end of "If (objPictureBox IsNot Nothing) Then"

            ''''1/4/2022 td''mod_moveResizeKeepRatio.Init(objPictureBox, Me, 10, c_bRepaintAfterResize,
            ''''      mod_events, False, Me)
            ''mod_moveResizeKeepRatio.Init(objPictureBox, Me, 10, c_bRepaintAfterResize,
            ''                                mod_events, False, Me, False,
            ''                                mod_bHandleMouseMoveEvents_Monem,
            ''                                singleProportionWH)

            ''''            ''1/2/2022 td '' mod_events, False, mod_iSaveToModel)
            ''''---mod_resizingProportionally.LayoutFunctions = par_iLayoutFunctions 
            ''mod_iMoveOrResizeFunctionality = mod_moveResizeKeepRatio ''Added 12/28/2021 td


        ElseIf (pbUseMonemProportionalityClass And (Not pboolResizeProportionally)) Then
            ''
            ''Added 1/10/2022 td
            ''
            ''Since the parameter pbUseMonemProportionalityClass is True, we will
            ''  instantatiate mod_moveResizeKeepRatio (class ControlResizeProportionally_TD_NonStatic) 
            ''  (NOT class ControlMmove_Group_NonStatic). ----1/10/2022 td
            ''
            ''The object which is of the "Monem Proportionality class" is 
            ''  module-level object mod_moveResizeKeepRatio.  ---1/10/2022 td
            ''
            InitializeMoveability_MonemProportional(par_iLayoutFunctions, objPictureBox,
                                               c_bRepaintAfterResize)
            ''
            ''Having instantiated the "Monem Proportionality class" (module-level  
            ''  object mod_moveResizeKeepRatio, we will now remove
            ''  proportionality.  ---1/10/2022 td
            ''
            Dim bRemoveProportionality As Boolean = (Not pboolResizeProportionally)
            mod_moveResizeKeepRatio.RemoveProportionality = bRemoveProportionality


        Else
            ''
            ''We don't need to enforce "Proportionality", a constant Width-Height ratio. 
            ''
            mod_moveInAGroup = New MoveAndResizeControls_Monem.ControlMove_Group_NonStatic()

            ''mod_iLayoutFunctions = par_iLayoutFunctions
            ''mod_movingInAGroup.LayoutFunctions = par_iLayoutFunctions

            ''Jan10 2022 ''mod_events.LayoutFunctions = par_iLayoutFunctions ''Added 12/27/2021
            mod_eventsForSingleMove.LayoutFunctions = par_iLayoutFunctions ''Added 12/27/2021

            ''#1 Jan4 2022''mod_moveInAGroup.Init(Me, Me, 10, c_bRepaintAfterResize,
            ''                        mod_events, False, Me) ''1/2/2022 td''mod_iSaveToModel)
            ''#2 Jan4 2022''mod_moveInAGroup.Init(Nothing, Me, 10, c_bRepaintAfterResize,
            ''                        mod_events, False, Me) ''1/2/2022 td''mod_iSaveToModel)

            ''Added 1/7/2022 thomas d. 
            If (pbHandleMouseEventsThroughFormVB6) Then
                mod_bHandleMouseMoveEvents_ByForm = True
                mod_bHandleMouseMoveEvents_Monem = False
            Else
                mod_bHandleMouseMoveEvents_ByForm = False
                mod_bHandleMouseMoveEvents_Monem = True
            End If ''eNd of "If (pbHandleMouseEventsThroughFormVB6) Then ... Else"

            ''Added 1/4/2022 td
            objPictureBox = Find_PictureBox()

            ''Jan10 2022''mod_moveInAGroup.Init(objPictureBox, Me, 10, c_bRepaintAfterResize,
            ''Jan10 2022''                  mod_events, False, Me, False,
            ''Jan10 2022''                  mod_bHandleMouseMoveEvents_Monem)
            mod_moveInAGroup.Init(objPictureBox, Me, 10, c_bRepaintAfterResize,
                                            par_objMoveEventsForGroupMove,
                                            par_objMoveEventsForSingleCtl,
                                            False, Me, False,
                                            mod_bHandleMouseMoveEvents_Monem)

            mod_iMoveOrResizeFunctionality = mod_moveInAGroup ''Added 12/28/2021 td

        End If ''End of "If pboolResizeProportionally Then .... Else ..."


        ''
        ''Add Handlers to the Picture Box control /// IN THE CHILD USER CONTROL CLASS !! //
        ''
        If (mod_bHandleMouseMoveEvents_ByForm) Then

            AddHandlersToPictureBoxInChildControl()

        End If ''End of 'If (mod_bHandleMouseMoveEvents_ByForm) Then'

    End Sub ''End of "Public Sub InitializeMoveability(..., ..., ...., ....)"


    Private Sub InitializeMoveability_MonemProportional(par_iLayoutFunctions As ILayoutFunctions,
                                                   par_objPictureBox As PictureBox,
                                                   par_bRepaintAfterResize As Boolean)
        ''
        ''Encapsulated 1/10/2022 td
        ''
        ''We will instantatiate module-level object mod_moveResizeKeepRatio
        ''  (class ControlResizeProportionally_TD_NonStatic) 
        ''  (NOT object mod_moveInAGroup, class ControlMove_Group_NonStatic).
        ''  ----1/10/2022 td
        ''
        ''1/10/2022 td''mod_events.LayoutFunctions = par_iLayoutFunctions ''Added 12/27/2021
        mod_eventsForSingleMove.LayoutFunctions = par_iLayoutFunctions ''Added 12/27/2021

        ''1/10/2022 td''mod_moveResizeKeepRatio = New MoveAndResizeControls_Monem.ControlResizeProportionally_TD()
        mod_moveability_MonemClass = New MoveAndResizeControls_Monem.ControlMove_Group_NonStatic()

        ''#1 Jan4 2022 ''mod_moveResizeKeepRatio.Init(Me, Me, 10, c_bRepaintAfterResize,
        ''                mod_events, False, Me)
        ''#2 Jan4 2022 ''mod_moveResizeKeepRatio.Init(Nothing, Me, 10, c_bRepaintAfterResize,
        ''                mod_events, False, Me)

        ''Added 1/4/2022 td
        par_objPictureBox = Find_PictureBox()

        ''Added 1/4/2022 td
        Dim singleProportionWH As Single = 0 ''Added 1/4/2022 td

        ''Added 1/4/2022 td
        If (Me.ExpectedProportionWH <> 0) Then
            singleProportionWH = Me.ExpectedProportionWH
            Me.Width = CInt(Me.Height * Me.ExpectedProportionWH) ''Added 1/4/2022
        ElseIf (par_objPictureBox IsNot Nothing) Then
            singleProportionWH = CSng(par_objPictureBox.Width / par_objPictureBox.Height)
        End If ''end of "If (Me.ExpectedProportionWH <> 0) Then ... ElseIf (objPictureBox IsNot Nothing) Then"

        ''1/4/2022 td''mod_moveResizeKeepRatio.Init(objPictureBox, Me, 10, c_bRepaintAfterResize,
        ''      mod_events, False, Me)
        mod_moveResizeKeepRatio.Init(par_objPictureBox, Me, 10, par_bRepaintAfterResize,
                                            mod_events, False, Me, False,
                                            mod_bHandleMouseMoveEvents_Monem,
                                            singleProportionWH)

        ''            ''1/2/2022 td '' mod_events, False, mod_iSaveToModel)
        ''---mod_resizingProportionally.LayoutFunctions = par_iLayoutFunctions 
        mod_iMoveOrResizeFunctionality = mod_moveResizeKeepRatio ''Added 12/28/2021 td


    End Sub ''End of "Private Sub InitializeMoveability_Proportional()"



    Private Sub AddHandlersToPictureBoxInChildControl()
        ''
        ''  User Control Click - Windows Forms
        ''  https://stackoverflow.com/questions/1071579/user-control-click-windows-forms
        ''  User control's click event won't fire when another control is clicked on the user control. 
        ''  need to manually bind each element's click event. You can do this with a simple loop on
        ''  the user control's codebehind:
        ''
        Dim each_control As Windows.Forms.Control

        If (mod_bHandleMouseMoveEvents_ByForm) Then

            If (mod_bHandleMouseMoveEvents_BaseClass) Then

                For Each each_control In Me.Controls

                    If (TypeOf each_control Is PictureBox) Then
                        ''
                        ''This control is 99% likely to be in the child (derived) user control,
                        ''   not in this base user control (the parent class).  ---1/7/2022 td
                        ''
                        ''// I am assuming MyUserControl_Click handles the click event of the user control.
                        ''Jan7 2022''AddHandler each_control.MouseClick, AddressOf MoveableControl_MouseClick
                        AddHandler each_control.MouseDown, AddressOf MoveableControl_MouseDown
                        AddHandler each_control.MouseMove, AddressOf MoveableControl_MouseMove
                        AddHandler each_control.MouseUp, AddressOf MoveableControl_MouseUp

                    End If ''end of "For Each each_control In Me.Controls"

                Next each_control

            End If ''End of 'If (mod_bHandleMouseMoveEvents_ByBaseClass) Then'

        End If ''ENd of "If (mod_bHandleMouseMoveEvents_ByForm) Then"

    End Sub ''End of "Public Sub InitializeMoveability(..., ..., ...., ....)"


    ''Added 12/28/2021 td  
    Private mod_menuCacheNonShared As MenuCache_NonShared = Nothing ''New Operations_Generic(Me)
    ''Dec28 2021 td''Private mod_menuCacheUseless As MenuCache_NonShared = Nothing ''New Operations_Useless(Me)
    Private mod_objOperationsGeneric As Operations__Generic = Nothing ''New Operations_Generic(Me)
    Private mod_objOperationsUseless As Operations__Useless = Nothing ''New Operations_Useless(Me)

    Private Sub InitializeClickability(par_enum As EnumElementType,
                                       par_moveabilityEvents As GroupMoveEvents_Singleton)
        ''Jan4 2022 td''Private Sub InitializeClickability(par_enum As EnumElementType)
        ''Dec29 2021 td''Private Sub InitializeClickability(par_designer As ClassDesigner,
        ''     par_enum As EnumElementType)
        ''
        ''Added 12/22/2021 thomas downes
        ''
        ''Dec28, 2021 td''mod_designer = par_designer
        ''
        ''Jan4 2022 td''mod_objOperationsGeneric = New Operations__Generic(Me)
        ''Jan4 2022 td''mod_objOperationsUseless = New Operations__Useless(Me)

        ''#2 Jan4 ''mod_objOperationsGeneric = New Operations__Generic(Me, par_moveabilityEvents)
        ''#2 Jan4 ''mod_objOperationsUseless = New Operations__Useless(Me, par_moveabilityEvents)
        ''#3 Jan4 ''mod_objOperationsGeneric = New Operations__Generic(Me, par_moveabilityEvents, mod_iLayoutFunctions)
        ''#3 Jan4 ''mod_objOperationsUseless = New Operations__Useless(Me, par_moveabilityEvents, mod_iLayoutFunctions)

        ''mod_menuCacheGeneric = New MenuCache_NonShared(EnumElementType.Field,
        ''                                               mod_objOperationsGeneric.GetType(),
        ''                                               mod_objOperationsGeneric)

        Select Case par_enum

            Case EnumElementType.Field
                mod_menuCacheNonShared = New MenuCache_NonShared(EnumElementType.Field,
                                                       mod_objOperationsGeneric.GetType(),
                                                       mod_objOperationsGeneric)

            Case EnumElementType.Portrait
                mod_menuCacheNonShared = New MenuCache_NonShared(EnumElementType.Portrait,
                                                       mod_objOperationsUseless.GetType(),
                                                       mod_objOperationsUseless)

            Case EnumElementType.QRCode
                mod_menuCacheNonShared = New MenuCache_NonShared(EnumElementType.QRCode,
                                                       mod_objOperationsGeneric.GetType(),
                                                       mod_objOperationsGeneric)

            Case EnumElementType.Signature
                mod_menuCacheNonShared = New MenuCache_NonShared(EnumElementType.Signature,
                                                       mod_objOperationsUseless.GetType(),
                                                       mod_objOperationsUseless)

            Case EnumElementType.StaticGraphic
                mod_menuCacheNonShared = New MenuCache_NonShared(EnumElementType.StaticGraphic,
                                                       mod_objOperationsGeneric.GetType(),
                                                       mod_objOperationsGeneric)

            Case EnumElementType.StaticText
                mod_menuCacheNonShared = New MenuCache_NonShared(EnumElementType.StaticText,
                                                       mod_objOperationsUseless.GetType(),
                                                       mod_objOperationsUseless)

        End Select ''End of "Select Case par_enum"


    End Sub ''End of "Private Sub InitializeClickability()"


    ''Private Sub Handle_ElementRightClicked(par_control As CtlGraphicFldLabel) Handles ElementFieldRightClicked
    ''    ''
    ''    ''Added 10/13/2019 thomas downes  
    ''    ''
    ''    MenuCache_FieldElements.CtlCurrentElement = par_control ''Added 10/14/2019 td  
    ''    MenuCache_FieldElements.Operations_Edit.CtlCurrentElement = par_control ''Added 10/14/2019 td

    ''    ContextMenuStrip1.Items.Clear()

    ''    ''Add a ToolStripMenuItem which will tell which Field is being displayed 
    ''    ''  on the selected (right-clicked) control. 
    ''    ContextMenuStrip1.Items.Add(MenuCache_FieldElements.Tools_MenuHeader0) ''Added 12/13/2021 
    ''    ContextMenuStrip1.Items.Add(MenuCache_FieldElements.Tools_MenuHeader1) ''Added 12/12/2021 

    ''    Dim bool_addExtraHeadersToContextMenus As Boolean ''Added 12/13/2021 td
    ''    bool_addExtraHeadersToContextMenus = AddExtraHeadersToolStripMenuItem.Checked

    ''    ''Added header items. 
    ''    If (bool_addExtraHeadersToContextMenus) Then
    ''        ''Added 12/13/2021 
    ''        ContextMenuStrip1.Items.Add(MenuCache_FieldElements.Tools_MenuHeader2) ''Added 12/12/2021 
    ''        ContextMenuStrip1.Items.Add(MenuCache_FieldElements.Tools_MenuHeader3) ''Added 12/13/2021 

    ''        Dim objMenuHeader3_1 As New ToolStripMenuItem("mod_designer_ElementRightClicked(...")
    ''        Dim objMenuHeader3_2 As New ToolStripMenuItem("   ... Handles mod_designer.ElementRightClicked")
    ''        ContextMenuStrip1.Items.Add(objMenuHeader3_1) ''Added 12/13/2021 
    ''        ''Dec.13 ''ContextMenuStrip1.Items.Add(objMenuHeader3_2) ''Added 12/13/2021 
    ''        ''  Make 3_2 a sub-item under 3_1. ---12/13/2021 td 
    ''        objMenuHeader3_1.DropDownItems.Add(objMenuHeader3_2)

    ''    End If ''End of "If (mod_letsAddExtraHeadersForContextMenus) Then"

    ''    ''Let's add a separator bar. 
    ''    ContextMenuStrip1.Items.Add(MenuCache_FieldElements.Tools_MenuSeparator) ''Added 12/13/2021

    ''    ''
    ''    ''Major step!!!   Add all the editing-related menu items!!
    ''    ''
    ''    ContextMenuStrip1.Items.AddRange(MenuCache_FieldElements.Tools_EditElementMenu)

    ''    ''Added 12/13/2021 td
    ''    ''  Change the text "Field: {0} ({1})" to "Field: School Name (fstrField1)".
    ''    With MenuCache_FieldElements.Tools_MenuHeader1
    ''        ''Dim objHeader1 As ToolStripItem = MenuCache_ElemFlds.Tools_MenuHeader1
    ''        .Text = String.Format(.Tag.ToString(), par_control.FieldInfo.FieldLabelCaption,
    ''                                                par_control.FieldInfo.CIBadgeField)
    ''    End With ''End of "With MenuCache_ElemFlds.Tools_MenuHeader1"

    ''    ''Added 12/13/2021 td
    ''    ''  Change the text "Context-Menu for Control: {0}" to "Context-Menu for Control: ....".
    ''    With MenuCache_FieldElements.Tools_MenuHeader0
    ''        .Text = String.Format(.Tag.ToString(), par_control.Name)
    ''    End With ''End of "With MenuCache_ElemFlds.Tools_MenuHeader0"
    ''
    ''    ''10/13 td''ContextMenuStrip1.Show()
    ''    ''10/13 td''ContextMenuStrip1.Show(par_control, New Point(par_control.Left, par_control.Top))
    ''    ContextMenuStrip1.Show(par_control, New Point(0, 0))
    ''
    ''End Sub ''End of "Private Sub mod_designer_ElementRightClicked"


    Private Sub mod_events_Moving_End(par_control As Control, par_iSaveToModel As ISaveToModel) ''Handles mod_events.Moving_End '', mod_events.Resizing_End, mod_events.Moving_InProgress
        ''
        ''Added 12/27/2021 td 
        ''
        ''----mod_iSaveToModel.SaveToModel()
        par_iSaveToModel.SaveToModel()

        ''Added 1/5/2022 td
        ''  Trying to prevent multiple calls. 
        RemoveHandler mod_events.Moving_End, AddressOf mod_events_Moving_End
        RemoveHandler mod_events.Moving_End, AddressOf mod_events_Moving_End
        AddHandler mod_events.Moving_End, AddressOf mod_events_Moving_End

    End Sub

    Private Sub mod_events_Resizing_End(par_iSaveToModel As ISaveToModel) Handles mod_eventsForSingleMove.Resizing_End
        ''
        ''Added 12/27/2021 td 
        ''
        ''---mod_iSaveToModel.SaveToModel()
        par_iSaveToModel.SaveToModel()

    End Sub

    Private Sub mod_events_MovingInProgress(par_control As Control) Handles mod_eventsForSingleMove.Moving_InProgress
        ''
        ''Added 12/27/2021 td 
        ''
        ''---mod_iSaveToModel.SaveToModel()
        ''---par_iSaveToModel.SaveToModel()
        ''---mod_iSaveToModel.SaveToModel()

    End Sub


    Private Sub mod_events_MoveInUnison(deltaLeft As Integer, deltaTop As Integer, deltaWidth As Integer, deltaHeight As Integer) Handles mod_eventsForSingleMove.MoveInUnison
        ''
        ''Added 1/10/2022 thomas downes
        ''
        Dim boolMoving As Boolean ''Added 8/5/2/019 td  
        Dim boolResizing As Boolean ''Added 8/5/2/019 td  
        Dim bResize_RightOrBottom As Boolean ''Added 8/12/019 td  
        Dim bResize_LeftOrTop As Boolean ''Added 8/12/019 td  
        ''Dim bControlMovedIsInGroup As Boolean ''Added 8/5/2019 td  

        With Me

            ''Added 8/3/2019 th omas downes  
            ''8/12/2019 td''boolMoving = (DeltaTop <> 0 Or DeltaLeft <> 0)
            boolMoving = ((deltaTop <> 0 And deltaHeight = 0) Or
                              (deltaLeft <> 0 And deltaWidth = 0))

            If (boolMoving) Then
                .Top += deltaTop
                .Left += deltaLeft
            End If ''End if ''End of "If (boolMoving) Then"

            ''8/5/2019 TD''.Width += DeltaWidth
            ''8/5/2019 TD''.Height += DeltaHeight

            ''Modified 8/5/2019 thomas downes
            boolResizing = ((Not boolMoving) And (.TempResizeInfo_W > 0 And .TempResizeInfo_H > 0))

            If (boolResizing) Then
                ''
                ''Added 8/12/2019 thomas d. 
                ''
                bResize_LeftOrTop = (deltaLeft <> 0 Or deltaTop <> 0) ''-----DIFFICULT AND CONFUSING !!!!!    The user might want might to resize 
                ''    using the left edge (Or the top edge).  ----8/12/2019 td
                bResize_RightOrBottom = ((Not bResize_LeftOrTop) And (deltaWidth <> 0 Or deltaHeight <> 0))

                If (bResize_RightOrBottom) Then
                    ''
                    ''This is the simpler situation !! 
                    ''
                    ''10/14 td''.Width = (.TempResizeInfo_W + DeltaWidth)
                    ''10/14 td''.Height = (.TempResizeInfo_H + DeltaHeight)
                    .ManageResizingByUser(True, deltaWidth, deltaHeight, 0, 0)


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
                    .ManageResizingByUser(False, deltaWidth, deltaHeight, deltaTop, deltaLeft)

                End If ''End of "If (bResize_RightOrBottom) Then .... ElseIf (bResize_LeftOrTop) Then ..."

            End If ''End of "If (boolResizing) Then"

        End With ''End of "With each_control"

    End Sub


    Public Sub ManageResizingByUser(par_bUseTempInfo As Boolean,
                                    par_deltaWidth As Integer, par_deltaHeight As Integer,
                                    par_deltaTop As Integer, par_deltaLeft As Integer)
        ''
        ''Added 10/14/2019 
        ''
        If (par_bUseTempInfo) Then

            ''1/10/2022 td''Me.ElementClass_Obj.Width_Pixels = (TempResizeInfo_W + par_deltaWidth)
            ''1/10/2022 td''Me.ElementClass_Obj.Height_Pixels = (TempResizeInfo_H + par_deltaHeight)
            Me.ElementInfo_Base.Width_Pixels = (TempResizeInfo_W + par_deltaWidth)
            Me.ElementInfo_Base.Height_Pixels = (TempResizeInfo_H + par_deltaHeight)

        Else
            ''1/10/2022 td''Me.ElementClass_Obj.Width_Pixels += (par_deltaWidth)
            ''1/10/2022 td''Me.ElementClass_Obj.Height_Pixels += (par_deltaHeight)
            ''1/10/2022 td''Me.ElementClass_Obj.TopEdge_Pixels += (par_deltaTop)
            ''1/10/2022 td''Me.ElementClass_Obj.LeftEdge_Pixels += (par_deltaLeft)
            Me.ElementInfo_Base.Width_Pixels += (par_deltaWidth)
            Me.ElementInfo_Base.Height_Pixels += (par_deltaHeight)
            Me.ElementInfo_Base.TopEdge_Pixels += (par_deltaTop)
            Me.ElementInfo_Base.LeftEdge_Pixels += (par_deltaLeft)
        End If ''End of "If (par_bUseTempInfo) Then ... Else ..."

        ''1/10/2022 td''Me.Width = Me.ElementClass_Obj.Width_Pixels
        ''1/10/2022 td''Me.Height = Me.ElementClass_Obj.Height_Pixels
        ''1/10/2022 td''Me.Top = Me.ElementClass_Obj.TopEdge_Pixels
        ''1/10/2022 td''Me.Left = Me.ElementClass_Obj.LeftEdge_Pixels

        Me.Width = Me.ElementInfo_Base.Width_Pixels
        Me.Height = Me.ElementInfo_Base.Height_Pixels
        Me.Top = Me.ElementInfo_Base.TopEdge_Pixels
        Me.Left = Me.ElementInfo_Base.LeftEdge_Pixels

    End Sub ''End of "Public Sub ManageResizingByUser(par_intWidth As Integer, par_intHeight As Integer)"


    Private Sub Init_ForRightClicked()
        ''
        ''Adapted from the formerly-existing Private Sub mod_designer_ElementRightClicked(par_intX As Integer, par_intY As Integer) on 12/28/2021 td 
        ''
        Me.ContextMenuStrip1 = New ContextMenuStrip()

        ''Dec28 2021 td''Private Sub mod_designer_ElementRightClicked(par_intX As Integer, par_intY As Integer) '' par_control As CtlGraphicFldLabel) ''Handles mod_designer.ElementFieldRightClicked
        ''
        ''Added 10/13/2019 thomas downes  
        ''
        MenuCache_Generic.CtlCurrentElement = Me ''par_control ''Added 10/14/2019 td  
        ''#1 Dec28 2021 td''MenuCache_Generic.Operations_Edit.CtlCurrentElement = Me ''par_control ''Added 10/14/2019 td
        ''#2 Dec28 2021 td''mod_operationsGenericEdits.CtlCurrentElement = Me ''Modified 12/28/2021 td

        ''Added 12/28/2021 thomas downes
        mod_menuCacheNonShared = New MenuCache_NonShared(mod_enumElementType,
                                                         mod_objOperationsAny.GetType(), mod_objOperationsAny)
        ''Added 12/28/2021 thomas downes
        mod_menuCacheNonShared.GenerateMenuItems_IfNeeded()

        ContextMenuStrip1.Items.Clear()

        ''Add a ToolStripMenuItem which will tell which Field is being displayed 
        ''  on the selected (right-clicked) control. 
        ''Dec28 ''ContextMenuStrip1.Items.Add(MenuCache_Generic.Tools_MenuHeader0) ''Added 12/13/2021 
        ''Dec28 ''ContextMenuStrip1.Items.Add(MenuCache_Generic.Tools_MenuHeader1) ''Added 12/12/2021 
        ContextMenuStrip1.Items.Add(mod_menuCacheNonShared.Tools_MenuHeader0) ''Added 12/13/2021 
        ContextMenuStrip1.Items.Add(mod_menuCacheNonShared.Tools_MenuHeader1) ''Added 12/12/2021 

        Dim bool_addExtraHeadersToContextMenus As Boolean ''Added 12/13/2021 td
        ''Dec.28 2021 td''bool_addExtraHeadersToContextMenus = AddExtraHeadersToolStripMenuItem.Checked
        bool_addExtraHeadersToContextMenus = mc_AddExtraHeadersForContextMenuStrip

        ''Added header items. 
        If (bool_addExtraHeadersToContextMenus) Then

            ''Added 12/13/2021 
            ''Dec28 2021''ContextMenuStrip1.Items.Add(MenuCache_Generic.Tools_MenuHeader2) ''Added 12/12/2021 
            ''Dec28 2021''ContextMenuStrip1.Items.Add(MenuCache_Generic.Tools_MenuHeader3) ''Added 12/13/2021 
            ContextMenuStrip1.Items.Add(mod_menuCacheNonShared.Tools_MenuHeader2) ''Added 12/12/2021 
            ContextMenuStrip1.Items.Add(mod_menuCacheNonShared.Tools_MenuHeader3) ''Added 12/13/2021 

            Dim objMenuHeader3_1 As New ToolStripMenuItem("mod_designer_ElementRightClicked(...")
            Dim objMenuHeader3_2 As New ToolStripMenuItem("   ... Handles mod_designer.ElementRightClicked")
            ContextMenuStrip1.Items.Add(objMenuHeader3_1) ''Added 12/13/2021 
            ''Dec.13 ''ContextMenuStrip1.Items.Add(objMenuHeader3_2) ''Added 12/13/2021 
            ''  Make 3_2 a sub-item under 3_1. ---12/13/2021 td 
            objMenuHeader3_1.DropDownItems.Add(objMenuHeader3_2)

        End If ''End of "If (mod_letsAddExtraHeadersForContextMenus) Then"

        ''Let's add a separator bar. 
        ''Dec28 2021 td''ContextMenuStrip1.Items.Add(MenuCache_Generic.Tools_MenuSeparator) ''Added 12/13/2021
        ContextMenuStrip1.Items.Add(mod_menuCacheNonShared.Tools_MenuSeparator) ''Added 12/13/2021

        ''
        ''Major step!!!   Add all the editing-related menu items!!
        ''
        ''Dec28, 2021 td''ContextMenuStrip1.Items.AddRange(MenuCache_Generic.Tools_EditElementMenu)
        ''#2 Dec28 2021 td''ContextMenuStrip1.Items.AddRange(MenuCache_Generic.Get_EditElementMenu(EnumElementType.Field))

        Me.MyToolstripItemCollection = mod_menuCacheNonShared.Tools_EditElementMenu ''Added 12/28/2021 td 
        If (Me.MyToolstripItemCollection Is Nothing) Then Throw New Exception("333 3 3 3 3 3 1966")
        ContextMenuStrip1.Items.AddRange(Me.MyToolstripItemCollection)

        ''Added 12/13/2021 td
        ''  Change the text "Field: {0} ({1})" to "Field: School Name (fstrField1)".
        ''Dec28 2021''With MenuCache_Generic.Tools_MenuHeader1
        With mod_menuCacheNonShared.Tools_MenuHeader1
            ''Dim objHeader1 As ToolStripItem = MenuCache_ElemFlds.Tools_MenuHeader1
            ''Dec28 2021 td''.Text = String.Format(.Tag.ToString(), par_control.FieldInfo.FieldLabelCaption,
            ''Dec28 2021 td''          par_control.FieldInfo.CIBadgeField)
            .Text = String.Format(.Tag.ToString(), Me.Name, "[CI Badge Field is n/a]")
        End With ''End of "With mod_menuCacheNonShared.Tools_MenuHeader1"

        ''Added 12/13/2021 td
        ''  Change the text "Context-Menu for Control: {0}" to "Context-Menu for Control: ....".
        ''
        ''Dec28 2021 td''With MenuCache_Generic.Tools_MenuHeader0
        With mod_menuCacheNonShared.Tools_MenuHeader0
            ''Dec28 2021''.Text = String.Format(.Tag.ToString(), par_control.Name)
            .Text = String.Format(.Tag.ToString(), Me.Name)
        End With ''End of "With MenuCache_ElemFlds.Tools_MenuHeader0"

        ''10/13 td''ContextMenuStrip1.Show()
        ''10/13 td''ContextMenuStrip1.Show(par_control, New Point(par_control.Left, par_control.Top))
        ''12/28/2021 td''ContextMenuStrip1.Show(par_control, New Point(0, 0))
        ''Added 12/28/2021 Thomas Downes
        ''Dim objDisplayMenu As New ClassDisplayContextMenu(ContextMenuStrip1)
        ''Const c_intRandom As Integer = 5
        ''With objDisplayMenu
        ''    If (c_intRandom = 1) Then .ContextMenuDisplay(Me, New Point(par_intX, par_intY))
        ''    If (c_intRandom = 2) Then .ContextMenuOpen(Me, New Point(par_intX, par_intY))
        ''    If (c_intRandom = 3) Then .ContextMenuShow(Me, New Point(par_intX, par_intY))
        ''    If (c_intRandom = 4) Then .DisplayContextMenu(Me, New Point(par_intX, par_intY))
        ''    If (c_intRandom = 5) Then .DisplayPopupMenu(Me, New Point(par_intX, par_intY))
        ''    If (c_intRandom = 6) Then .DisplayRightclickMenu(Me, New Point(par_intX, par_intY))
        ''    If (c_intRandom = 7) Then .OpenContextMenu(Me, New Point(par_intX, par_intY))
        ''    If (c_intRandom = 8) Then .OpenPopupMenu(Me, New Point(par_intX, par_intY))
        ''    If (c_intRandom = 9) Then .OpenRightclickMenu(Me, New Point(par_intX, par_intY))
        ''End With ''End of "With objDisplayMenu"

    End Sub ''End of "Private Sub Init_ForRightClicked"


    Private Sub mod_designer_ElementRightClicked(par_intX As Integer, par_intY As Integer)
        ''
        ''Encapsulated 12/28/2021 td
        ''
        If (ContextMenuStrip1 Is Nothing) Then
            ''Added 12/29/2021 thomas downes
            MessageBoxTD.Show_Statement("It's possible that the Right-Click menu has been de-activated.")
            Return
        End If ''end of "If (ContextMenuStrip1 Is Nothing) Then"

        Dim objDisplayMenu As New ClassDisplayContextMenu(ContextMenuStrip1)
        Const c_intRandom As Integer = 5
        With objDisplayMenu

            If (c_intRandom = 1) Then .ContextMenuDisplay(Me, New Point(par_intX, par_intY))
            If (c_intRandom = 2) Then .ContextMenuOpen(Me, New Point(par_intX, par_intY))
            If (c_intRandom = 3) Then .ContextMenuShow(Me, New Point(par_intX, par_intY))
            If (c_intRandom = 4) Then .DisplayContextMenu(Me, New Point(par_intX, par_intY))
            If (c_intRandom = 5) Then .DisplayPopupMenu(Me, New Point(par_intX, par_intY))
            If (c_intRandom = 6) Then .DisplayRightclickMenu(Me, New Point(par_intX, par_intY))
            If (c_intRandom = 7) Then .OpenContextMenu(Me, New Point(par_intX, par_intY))
            If (c_intRandom = 8) Then .OpenPopupMenu(Me, New Point(par_intX, par_intY))
            If (c_intRandom = 9) Then .OpenRightclickMenu(Me, New Point(par_intX, par_intY))

        End With ''End of "With objDisplayMenu"

    End Sub ''End of Private Sub mod_designer_ElementRightClicked(par_intX As Integer, par_intY As Integer)


    Private Sub RSCMoveableControlVB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 12/29/2021 td 
        ''

    End Sub

    Private Sub RSCMoveableControlVB_Click(sender As Object, e As EventArgs) Handles Me.Click

        ''Added 12/29/2021 td
        Me.LastControlTouched_Info.LastControlTouched = Me

        ''Added 12/29/2021 td
        ''Not ready yet.''If Me.LastControlTouched_Info.ReactivateMenu Then AddClickability()

    End Sub


    Public Sub PerformRightClick(par_e_X As Integer, par_e_Y As Integer)
        ''
        ''Added 12/30/2021 td
        ''
        mod_designer_ElementRightClicked(par_e_X, par_e_Y)

    End Sub ''End of "Public Sub PerformRightClick"

    Public Overridable Sub SaveToModel() Implements ISaveToModel.SaveToModel
        ''
        ''Added 1/2/2022 td 
        ''
        ''1/2/2022 td''DirectCast(LastControlTouched_Deprecated, ISaveToModel).SaveToModel()
        MessageBoxTD.Show_Statement("SaveToModel(). Programmer must override this base-class method, using the keyword Overrides.")

    End Sub


    Public Function Find_Label() As Label
        ''
        ''Added 1/4/2022 td
        ''
        For Each objControl As Control In Me.Controls

            If TypeOf objControl Is Label Then Return CType(objControl, Label)

        Next objControl

    End Function ''Endof "Public Function Find_PictureBox() As Label"


    Public Function Find_PictureBox() As PictureBox
        ''
        ''Added 1/4/2022 td
        ''
        ''Hopefully this will capture the PictureBox in the 
        ''  child classes CtlGraphicQRCode & CtlGraphicSignature. 
        ''
        For Each objControl As Control In Me.Controls

            If TypeOf objControl Is PictureBox Then Return CType(objControl, PictureBox)

        Next objControl

    End Function ''Endof "Public Function Find_PictureBox() As PictureBox"


    ''Protected Sub MoveableControl_MouseClick(sender As Object, e As Windows.Forms.MouseEventArgs) Handles MyBase.MouseClick
    ''    ''
    ''    ''Added 12/28/2021 td  
    ''    ''
    ''    If (mod_bHandleMouseMoveEvents_ByForm) Then
    ''        If (e.Button = MouseButtons.Right) Then
    ''            ''
    ''            ''Added 12/28/2021 td
    ''            ''
    ''            mod_designer_ElementRightClicked(e.X, e.Y)

    ''        End If ''End of "If (e.Button = MouseButtons.Right) Then"
    ''    End If

    ''End Sub


    Protected Sub MoveableControl_MouseDown(sender As Object, par_e As MouseEventArgs) Handles Me.MouseDown
        ''
        ''Added 1/4/2022 thomas d.
        ''
        If (mod_bHandleMouseMoveEvents_ByForm AndAlso (par_e.Button = MouseButtons.Left)) Then
            ''
            ''It's a Left-Hand click. 
            ''
            ''Let the module know that a MouseMove took place. 
            mod_iMoveOrResizeFunctionality.StartMovingOrResizing(CType(sender, Control), par_e)

        End If ''End of "If (mod_bHandleMouseMoveEvents And par_e.Button = MouseButtons.Left) Then"

    End Sub


    Protected Sub MoveableControl_MouseMove(sender As Object, par_e As MouseEventArgs) Handles MyBase.MouseMove
        ''
        ''Added 1/4/2022 thomas d.
        ''
        ''1/7/2022 td''If (mod_bHandleMouseMoveEvents_ByForm AndAlso (par_e.Button = MouseButtons.Left)) Then

        Dim boolButtonIsOkay As Boolean ''Added 1/7/2022 td

        ''1/7/2022 td''boolButtonIsOkay = (par_e.Button = MouseButtons.Left)
        boolButtonIsOkay = ((par_e.Button = MouseButtons.Left) Or
            (par_e.Button = MouseButtons.None)) ''Added 1/7/2022 td

        If (mod_bHandleMouseMoveEvents_ByForm And boolButtonIsOkay) Then

            ''Added 1/10/2022 td
            With mod_iMoveOrResizeFunctionality

                ''Added 1/10/2022 td
                If (.NowInMotion()) Then
                    Dim bDummy As Boolean = True
                End If ''End of "If (.NowInMotion()) Then"

                ''Let the module know that a MouseMove took place. 
                mod_iMoveOrResizeFunctionality.MoveParentControl(CType(sender, Control), par_e)

            End With ''End of "With mod_iMoveOrResizeFunctionality"

        End If ''Endof "If (mod_bHandleMouseMoveEvents_ByForm) Then"

    End Sub ''ENd of "Protected Sub MoveableControl_MouseMove"


    Protected Sub MoveableControl_MouseUp(sender As Object, par_e As MouseEventArgs) Handles Me.MouseUp
        ''
        ''Added 1/4/2022 thomas d.
        ''
        If (mod_bHandleMouseMoveEvents_ByForm AndAlso (par_e.Button = MouseButtons.Left)) Then
            ''
            ''It's a Left-Button click.    (i.e. a Click-And-Drag action by user)
            ''
            ''Let the module know that a MouseUp took place. 
            mod_iMoveOrResizeFunctionality.StopDragOrResizing(CType(sender, Control), Me)

        ElseIf (par_e.Button = MouseButtons.Right) Then
            ''            ''
            ''  Right-Button click, i.e. a context-menu request by user.          
            ''            ''-----Added 12/28/2021 td
            ''            ''
            mod_designer_ElementRightClicked(par_e.X, par_e.Y)

        End If ''End of "If (mod_bHandleMouseMoveEvents And par_e.Button = MouseButtons.Left) Then"

    End Sub ''End of Protected Sub MoveableControl_MouseUp


End Class
