Option Explicit On
Option Strict On

Imports MoveAndResizeControls_Monem ''Added 12/22/2021 td
Imports ciBadgeInterfaces ''Added 12/22/2021 td
''--Imports windows.Forms ''Added 12/22/2021
Imports System.Windows.Forms
Imports ciBadgeDesigner ''Added 12/27/2021 td 

''
''Added 12/22/2021 td  
''
Public Class RSCMoveableControlVB
    Implements ISaveToModel ''Added 1/2/2022 td 

    ''
    ''Added 12/22/2021 td  
    ''
    Public Shared LastControlTouched_Deprecated As RSCMoveableControlVB

    Public Shared Function GetControl(par_enum As EnumElementType,
                                      par_nameOfControl As String,
                                      par_iLayoutFun As ILayoutFunctions,
                                      par_bProportionSizing As Boolean,
                                par_iControlLastTouched As ILastControlTouched,
                                      par_oMoveEventsFromForm As GroupMoveEvents_Singleton) As RSCMoveableControlVB
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
        Dim MoveableControlVB1 = New RSCMoveableControlVB(par_enum, par_bProportionSizing,
                                                   par_iLayoutFun,
                                                   typeOps,
                                                   objOperations,
                                                   bAddFunctionalitySooner,
                                                   bAddFunctionalitySooner,
                                                   par_iControlLastTouched,
                                                   par_oMoveEventsFromForm)
        ''                                         ''Jan2 2022 ''par_iSaveToModel,

        With MoveableControlVB1
            .Name = par_nameOfControl
            ''Jan4 2022''If (bAddFunctionalityLater) Then .AddMoveability(par_oMoveEventsFromForm)
            If (bAddFunctionalityLater) Then .AddMoveability(par_oMoveEventsFromForm, par_iLayoutFun)
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

    Public WriteOnly Property MoveabilityEvents As GroupMoveEvents_Singleton
        Set(value As GroupMoveEvents_Singleton)
            ''Added 1/3/2022 td  
            mod_events = value
        End Set
    End Property


    Public LastControlTouched_Info As ILastControlTouched ''Added 12/28/2021 thomas d. 
    Public MyToolstripItemCollection As ToolStripItemCollection ''Added 12/28/2021 td 
    Private mod_boolResizeProportionally As Boolean

    ''Depending on the above Boolean, one of the following will be instantiated. 
    ''Let's rename. 12/28/2021 td''Private mod_movingInAGroup As ControlMove_Group_NonStatic = Nothing
    ''Let's rename. 12/28/2021 td''Private mod_resizeProportionally As ControlResizeProportionally_TD = Nothing
    Private mod_moveInAGroup As ControlMove_Group_NonStatic = Nothing
    Private mod_moveResizeKeepRatio As ControlResizeProportionally_TD = Nothing
    ''Dec29 2021''Private mod_iMoveOrResize As InterfaceMoveOrResize ''Added 12/28/2021 td
    Private mod_iMoveOrResizeFunctionality As IMoveOrResizeFunctionality ''Added 12/28/2021 td

    ''1/3/2022 td''Private WithEvents mod_events As New GroupMoveEvents_Singleton ''InterfaceEvents
    ''Jan4 2022''Private WithEvents mod_events As GroupMoveEvents_Singleton ''InterfaceEvents
    Protected WithEvents mod_events As GroupMoveEvents_Singleton ''InterfaceEvents

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

    End Sub


    Public Sub New(par_enumElementType As EnumElementType,
                  pboolResizeProportionally As Boolean,
                   par_iLayoutFun As ILayoutFunctions,
                   par_operationsType As Type,
                   par_operationsAny As Object,
                   pboolAddMoveability As Boolean,
                   pboolAddClickability As Boolean,
                   par_iLastTouched As ILastControlTouched,
                   par_oMoveabilityEvents As GroupMoveEvents_Singleton) ''----As IOperations)
        ''         ''Jan2 2022 ''par_iSaveToModel As ISaveToModel,
        ''         ''Dec29 2021 ''par_designer As ClassDesigner,

        ''12/28/2021 td''par_toolstrip As ToolStripItemCollection)

        ' This call is required by the designer.
        InitializeComponent()

        ''Encapsulated 1/3/2022 td 
        Load_Functionality(par_enumElementType, pboolResizeProportionally,
                            par_iLayoutFun,
                            par_operationsType,
                            par_operationsAny,
                            pboolAddMoveability,
                            pboolAddClickability,
                            par_iLastTouched,
                            par_oMoveabilityEvents)

    End Sub ''End of "Public Sub New"


    Public Sub Load_Functionality(par_enumElementType As EnumElementType,
                  pboolResizeProportionally As Boolean,
                   par_iLayoutFun As ILayoutFunctions,
                   par_operationsType As Type,
                   par_operationsAny As Object,
                   pboolAddMoveability As Boolean,
                   pboolAddClickability As Boolean,
                   par_iLastTouched As ILastControlTouched,
                   par_oMoveEventsFromForm As GroupMoveEvents_Singleton)
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
        If (pboolAddMoveability) Then AddMoveability(par_oMoveEventsFromForm, par_iLayoutFun)

        ''Encapsulated 12/22/2021 thomas downes
        ''Dec28 2021 td''Me.MyToolstripItemCollection = par_toolstrip ''Added 12/28/2021 td
        ''Dec29 2021 td''mod_designer = par_designer

        mod_enumElementType = par_enumElementType
        mod_objOperationsAny = par_operationsAny
        mod_typeOperations = par_operationsType

        ''Dec28_2021 td''InitializeClickability(par_designer)
        ''#2 Dec28_2021 td''AddClickability()
        If (pboolAddClickability) Then AddClickability()

    End Sub ''End of "Public Sub Load_Functionality()"


    Public Sub AddMoveability(par_objEventsMove As GroupMoveEvents_Singleton,
                              par_iLayoutFunctions As ILayoutFunctions,
                              Optional pbAddProportionality As Boolean = False)
        ''Jan3 2022 ''Public Sub AddMoveability()
        ''
        ''Added 12/28/2021 td
        ''
        ''Dec28 2021''InitializeMoveability(mod_boolResizeProportionally, mod_iSaveToModel, mod_iLayoutFunctions)

        Dim boolInstantiated As Boolean ''Added 12/28/2021 td
        boolInstantiated = (mod_moveInAGroup IsNot Nothing) OrElse (mod_moveResizeKeepRatio IsNot Nothing)

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
            If (par_objEventsMove IsNot Nothing) Then Me.MoveabilityEvents = par_objEventsMove

        Else
            ''Added 1/2/2022 td''InitializeMoveability(mod_boolResizeProportionally, mod_iSaveToModel, mod_iLayoutFunctions)
            ''Jan2 2022 ''InitializeMoveability(mod_boolResizeProportionally, Me, mod_iLayoutFunctions)
            ''Jan3 2022 ''InitializeMoveability(mod_boolResizeProportionally, mod_iLayoutFunctions)
            If (mod_iLayoutFunctions Is Nothing) Then mod_iLayoutFunctions = par_iLayoutFunctions

            ''Added 1/4/2022 td
            If (pbAddProportionality) Then
                mod_boolResizeProportionally = pbAddProportionality ''Added 1/4/2022 td
            End If ''end if "If (pbAddProportionality) Then"

            ''
            ''Major call !!
            ''
            InitializeMoveability(mod_boolResizeProportionally, mod_iLayoutFunctions, par_objEventsMove)

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
                                     par_objMoveEvents As GroupMoveEvents_Singleton)
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

        mod_events = par_objMoveEvents ''Added 1/3/2022 thomas 
        mod_events.LayoutFunctions = par_iLayoutFunctions

        ''
        ''Instantiate the Resizing or Moving modules (instances).
        ''
        If pboolResizeProportionally Then

            mod_events.LayoutFunctions = par_iLayoutFunctions ''Added 12/27/2021

            mod_moveResizeKeepRatio = New MoveAndResizeControls_Monem.ControlResizeProportionally_TD()
            ''#1 Jan4 2022 ''mod_moveResizeKeepRatio.Init(Me, Me, 10, c_bRepaintAfterResize,
            ''                mod_events, False, Me)
            ''#2 Jan4 2022 ''mod_moveResizeKeepRatio.Init(Nothing, Me, 10, c_bRepaintAfterResize,
            ''                mod_events, False, Me)

            ''Added 1/4/2022 td
            objPictureBox = Find_PictureBox()
            mod_moveResizeKeepRatio.Init(objPictureBox, Me, 10, c_bRepaintAfterResize,
                                            mod_events, False, Me)

            ''            ''1/2/2022 td '' mod_events, False, mod_iSaveToModel)
            ''---mod_resizingProportionally.LayoutFunctions = par_iLayoutFunctions 
            mod_iMoveOrResizeFunctionality = mod_moveResizeKeepRatio ''Added 12/28/2021 td

        Else
            mod_moveInAGroup = New MoveAndResizeControls_Monem.ControlMove_Group_NonStatic()

            ''mod_iLayoutFunctions = par_iLayoutFunctions
            ''mod_movingInAGroup.LayoutFunctions = par_iLayoutFunctions

            mod_events.LayoutFunctions = par_iLayoutFunctions ''Added 12/27/2021

            ''#1 Jan4 2022''mod_moveInAGroup.Init(Me, Me, 10, c_bRepaintAfterResize,
            ''                        mod_events, False, Me) ''1/2/2022 td''mod_iSaveToModel)
            ''#2 Jan4 2022''mod_moveInAGroup.Init(Nothing, Me, 10, c_bRepaintAfterResize,
            ''                        mod_events, False, Me) ''1/2/2022 td''mod_iSaveToModel)

            ''Added 1/4/2022 td
            objPictureBox = Find_PictureBox()
            mod_moveInAGroup.Init(objPictureBox, Me, 10, c_bRepaintAfterResize,
                                            mod_events, False, Me)

            mod_iMoveOrResizeFunctionality = mod_moveInAGroup ''Added 12/28/2021 td

        End If ''End of "If pboolResizeProportionally Then .... Else ..."

        ''
        ''  User Control Click - Windows Forms
        ''  https://stackoverflow.com/questions/1071579/user-control-click-windows-forms
        ''  User control's click event won't fire when another control is clicked on the user control. 
        ''  need to manually bind each element's click event. You can do this with a simple loop on
        ''  the user control's codebehind:
        ''
        Dim each_control As Windows.Forms.Control
        For Each each_control In Me.Controls

            ''// I am assuming MyUserControl_Click handles the click event of the user control.
            AddHandler each_control.MouseClick, AddressOf MoveableControl_MouseClick
            AddHandler each_control.MouseDown, AddressOf MoveableControl_MouseDown
            AddHandler each_control.MouseUp, AddressOf MoveableControl_MouseUp

        Next each_control

    End Sub ''End of "Public Sub New(pboolResizeProportionally As Boolean, par_iSaveToModel As ISaveToModel)"


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
        mod_objOperationsGeneric = New Operations__Generic(Me, par_moveabilityEvents, mod_iLayoutFunctions)
        mod_objOperationsUseless = New Operations__Useless(Me, par_moveabilityEvents, mod_iLayoutFunctions)

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


    Protected Sub MoveableControl_MouseClick(sender As Object, e As Windows.Forms.MouseEventArgs) Handles MyBase.MouseClick
        ''
        ''Added 12/28/2021 td  
        ''
        If (e.Button = MouseButtons.Right) Then
            ''
            ''Added 12/28/2021 td
            ''
            mod_designer_ElementRightClicked(e.X, e.Y)

        End If ''End of "If (e.Button = MouseButtons.Right) Then"

    End Sub

    Protected Sub MoveableControl_MouseDown(sender As Object, e As Windows.Forms.MouseEventArgs) ''Handles MyBase.MouseDown
        ''
        ''Added 12/22/2021 thomas downes
        ''
    End Sub


    Protected Sub MoveableControl_MouseUp(sender As Object, e As Windows.Forms.MouseEventArgs) ''Handles MyBase.MouseUp
        ''
        ''Added 12/22/2021 thomas downes
        ''
    End Sub

    Private Sub mod_events_Moving_End(par_control As Control, par_iSaveToModel As ISaveToModel) Handles mod_events.Moving_End '', mod_events.Resizing_End, mod_events.Moving_InProgress
        ''
        ''Added 12/27/2021 td 
        ''
        ''----mod_iSaveToModel.SaveToModel()
        par_iSaveToModel.SaveToModel()

    End Sub

    Private Sub mod_events_Resizing_End(par_iSaveToModel As ISaveToModel) Handles mod_events.Resizing_End
        ''
        ''Added 12/27/2021 td 
        ''
        ''---mod_iSaveToModel.SaveToModel()
        par_iSaveToModel.SaveToModel()

    End Sub

    Private Sub mod_events_MovingInProgress(par_control As Control) Handles mod_events.Moving_InProgress
        ''
        ''Added 12/27/2021 td 
        ''
        ''---mod_iSaveToModel.SaveToModel()
        ''---par_iSaveToModel.SaveToModel()
        ''---mod_iSaveToModel.SaveToModel()

    End Sub

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



End Class
