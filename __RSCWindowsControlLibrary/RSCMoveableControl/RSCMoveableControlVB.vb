Option Explicit On
Option Strict On

Imports MoveAndResizeControls_Monem ''Added 12/22/2021 td
Imports ciBadgeInterfaces ''Added 12/22/2021 td
''--Imports windows.Forms ''Added 12/22/2021
Imports System.Windows.Forms
Imports ciBadgeDesigner ''Added 12/27/2021 td 
Imports ciBadgeElements ''added 1/22/2022

''
''Added 12/22/2021 td  
''
Public Class RSCMoveableControlVB
    Implements ISaveToModel ''Added 1/2/2022 td 
    Implements IRefreshElementImage ''Added 1/28/2022 td

    ''Jan12 2022 td ''Public MustInherit Class RSCMoveableControlVB
    ''Jan12 2022 td''Implements IElement_Base ''Added 1/12/2022 td

    ''
    ''Added 12/22/2021 td  
    ''
    Public Shared LastControlTouched_Deprecated As RSCMoveableControlVB
    Public Shadows ParentForm As Form ''Added 1/15/2022 td 

    ''Added 5/5/2022 td
    Public ElementsCache As ciBadgeCachePersonality.ClassElementsCache_Deprecated
    Public ElementBase As ciBadgeElements.ClassElementBase ''Added 5/5/2022 td

    ''Added 5/5/2022 td
    Public ConditionalExpressionInUse As Boolean
    Public ConditionalExpressionField As EnumCIBFields
    Public ConditionalExpressionValue As String
    Public ConditionalExp_LastEdited As Date ''Added 5/5/2022

    ''Jan11 2022 td''Public Shared Function GetControl(par_enum As EnumElementType,
    ''                                  par_nameOfControl As String,
    ''                                  par_iLayoutFun As ILayoutFunctions,
    ''                                  par_bProportionSizing As Boolean,
    ''                            par_iControlLastTouched As ILastControlTouched,
    ''                                  par_oMoveEventsFromForm As GroupMoveEvents_Singleton,
    ''                       Optional par_ratioWH_ifApplicable As Single = 0,
    ''                       Optional pbHandleMouseEventsThroughVB6 As Boolean = True) As RSCMoveableControlVB
    ''    ''                      ''Jan2 2022 td''  par_iSaveToModel As ISaveToModel,
    ''    ''                      ''Dec29 2021 td'' par_designer As ClassDesigner,
    ''    ''
    ''    ''Added 12/29/2021 td
    ''    ''
    ''    Const bAddFunctionalitySooner As Boolean = False
    ''    Const bAddFunctionalityLater As Boolean = True

    ''    Dim typeOps As Type
    ''    Dim objOperations As Object ''Added 12/29/2021 td 
    ''    Dim objOperations1Gen As Operations__Generic = Nothing
    ''    Dim objOperations2Use As Operations__Useless = Nothing

    ''    ''Instantiate the Operations Object. 
    ''    If (par_enum = EnumElementType.Field) Then objOperations1Gen = New Operations__Generic()
    ''    If (par_enum = EnumElementType.Portrait) Then objOperations2Use = New Operations__Useless()
    ''    If (par_enum = EnumElementType.QRCode) Then objOperations1Gen = New Operations__Generic()
    ''    If (par_enum = EnumElementType.Signature) Then objOperations2Use = New Operations__Useless()
    ''    If (par_enum = EnumElementType.StaticGraphic) Then objOperations1Gen = New Operations__Generic()
    ''    If (par_enum = EnumElementType.StaticText) Then objOperations2Use = New Operations__Useless()

    ''    ''Assign to typeOps. 
    ''    If (par_enum = EnumElementType.Field) Then typeOps = objOperations1Gen.GetType()
    ''    If (par_enum = EnumElementType.Portrait) Then typeOps = objOperations2Use.GetType()
    ''    If (par_enum = EnumElementType.QRCode) Then typeOps = objOperations1Gen.GetType()
    ''    If (par_enum = EnumElementType.Signature) Then typeOps = objOperations2Use.GetType()
    ''    If (par_enum = EnumElementType.StaticGraphic) Then typeOps = objOperations1Gen.GetType()
    ''    If (par_enum = EnumElementType.StaticText) Then typeOps = objOperations2Use.GetType()

    ''    ''Assign to objOperations. 
    ''    If (par_enum = EnumElementType.Field) Then objOperations = objOperations1Gen
    ''    If (par_enum = EnumElementType.Portrait) Then objOperations = objOperations2Use
    ''    If (par_enum = EnumElementType.QRCode) Then objOperations = objOperations1Gen
    ''    If (par_enum = EnumElementType.Signature) Then objOperations = objOperations2Use
    ''    If (par_enum = EnumElementType.StaticGraphic) Then objOperations = objOperations1Gen
    ''    If (par_enum = EnumElementType.StaticText) Then objOperations = objOperations2Use

    ''    If (objOperations Is Nothing) Then
    ''        ''Added 12/29/2021
    ''        Throw New Exception("Ops is Nothing, so I guess Element Type is Undetermined.")
    ''    End If ''end of "If (objOperations Is Nothing) Then"

    ''    ''Create the control. 
    ''    Dim MoveableControlVB1 = New RSCMoveableControlVB(par_enum, par_bProportionSizing,
    ''                                               par_iLayoutFun,
    ''                                               typeOps,
    ''                                               objOperations,
    ''                                               bAddFunctionalitySooner,
    ''                                               bAddFunctionalitySooner,
    ''                                               par_iControlLastTouched,
    ''                                               par_oMoveEventsFromForm,
    ''                                               par_ratioWH_ifApplicable,
    ''                                               pbHandleMouseEventsThroughVB6)
    ''    ''                                         ''Jan2 2022 ''par_iSaveToModel,

    ''    With MoveableControlVB1
    ''        .Name = par_nameOfControl
    ''        ''Jan4 2022''If (bAddFunctionalityLater) Then .AddMoveability(par_oMoveEventsFromForm)
    ''        ''Jan10 2022''If (bAddFunctionalityLater) Then .AddMoveability(par_oMoveEventsFromForm, par_iLayoutFun)
    ''        ''Jan11 2022''If (bAddFunctionalityLater) Then .AddMoveability(par_oMoveEventsFromForm, Nothing, par_iLayoutFun)

    ''        If (bAddFunctionalityLater) Then ''1/11/2022 .AddClickability()
    ''            ''Refactored 1/11/2022 td
    ''            .AddClickability()
    ''            .AddMoveability(par_iLayoutFun, par_oMoveEventsFromForm)

    ''        End If ''End of "If (bAddFunctionalityLater) Then"

    ''        ''In the constructor. Dec31 2021 ''.LastControlTouched_Info = par_iControlLastTouched ''Added 12/31/2021 td
    ''    End With ''eNd of "With MoveableControlVB1"

    ''    ''
    ''    ''Specify the current element to the Operations object. 
    ''    ''
    ''    Dim infoOps = CType(objOperations, ICurrentElement) ''.CtlCurrentElement = MoveableControlVB1
    ''    infoOps.CtlCurrentElement = MoveableControlVB1

    ''    Return MoveableControlVB1

    ''End Function ''End of Public Shared Function GetControl


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

    ''Public Property ElementType As String Implements IElement_Base.ElementType
    ''Public Property PositionalMode As String Implements IElement_Base.PositionalMode
    ''Public Property FormControl As Control Implements IElement_Base.FormControl
    ''Public Property BadgeLayout As BadgeLayoutClass Implements IElement_Base.BadgeLayout
    ''Public Property TopEdge_Pixels As Integer Implements IElement_Base.TopEdge_Pixels
    ''Public Property LeftEdge_Pixels As Integer Implements IElement_Base.LeftEdge_Pixels
    ''Public Property Width_Pixels As Integer Implements IElement_Base.Width_Pixels
    ''Public Property Height_Pixels As Integer Implements IElement_Base.Height_Pixels
    ''Public Property BadgeDisplayIndex As Integer Implements IElement_Base.BadgeDisplayIndex
    ''Public Property Border_Displayed As Boolean Implements IElement_Base.Border_Displayed
    ''Public Property Border_WidthInPixels As Integer Implements IElement_Base.Border_WidthInPixels
    ''Public Property Border_Color As Color Implements IElement_Base.Border_Color
    ''Public Property Back_Color As Color Implements IElement_Base.Back_Color
    ''Public Property Back_Transparent As Boolean Implements IElement_Base.Back_Transparent
    ''Public Property SelectedHighlighting As Boolean Implements IElement_Base.SelectedHighlighting
    ''Public Property OrientationToLayout As String Implements IElement_Base.OrientationToLayout
    ''Public Property OrientationInDegrees As Integer Implements IElement_Base.OrientationInDegrees
    ''Public Property Image_BL As Image Implements IElement_Base.Image_BL
    ''Public Property IElement_Base_Visible As Boolean Implements IElement_Base.Visible
    ''Public Property WhichSideOfCard As EnumWhichSideOfCard Implements IElement_Base.WhichSideOfCard
    ''Public Property DateEdited As Date Implements IElement_Base.DateEdited
    ''Public Property DateSaved As Date Implements IElement_Base.DateSaved
    ''Public Property ZOrder As Integer Implements IElement_Base.ZOrder


    Public LastControlTouched_Info As ILastControlTouched ''Added 12/28/2021 thomas d. 
    Public MyToolstripItemCollection As ToolStripItemCollection ''Added 12/28/2021 td
    Public ExpectedProportionWH As Single = 0 ''Added 1/4/2022 td  
    Public LayoutFunctions As ciBadgeInterfaces.ILayoutFunctions ''Added 8/9/2019 td 

    Private mod_boolResizeProportionally As Boolean
    Private mod_boolRemoveMoveability As Boolean = False ''Added 3/20/2022 td

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
    Protected mod_bHandleMouseMoveEvents_ByVB6 As Boolean = True ''True, let's handler Mouse-Move events 
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
    Private mod_moveability_Monem As MonemControlMove_AllFunctionality = Nothing

    ''Dec29 2021''Private mod_iMoveOrResize As InterfaceMoveOrResize ''Added 12/28/2021 td
    Protected mod_iMoveOrResizeFunctionality As IMonemMoveOrResizeFunctionality ''Added 12/28/2021 td

    ''1/3/2022 td''Private WithEvents mod_events As New GroupMoveEvents_Singleton ''InterfaceEvents
    ''Jan4 2022''Private WithEvents mod_events As GroupMoveEvents_Singleton ''InterfaceEvents
    Protected mod_eventsForGroupMove_NotNeeded As GroupMoveEvents_Singleton ''InterfaceEvents
    Protected WithEvents mod_eventsForSingleMove As GroupMoveEvents_Singleton ''InterfaceEvents

    Public Overridable Property ElementInfo_Base As ciBadgeInterfaces.IElement_Base ''Added 1/10/2022 thomas d.

    ''Added 5/6/2022 td
    Public ElemIfApplicable_IPic As ciBadgeInterfaces.IElementPic
    Public ElemIfApplicable_ISig As ciBadgeInterfaces.IElementSig
    Public ElemIfApplicable_IQRCode As ciBadgeInterfaces.IElementQRCode
    ''Added 5/16/2022 td
    Public ElemIfApplicable_IGraphic As ciBadgeInterfaces.IElementGraphic
    Public ElemIfApplicable_ITextOnly As ciBadgeInterfaces.IElement_TextOnly

    Public Event RSCControlClicked() ''Added 5/4/2022 td

    ''#1 Jan2 2022''Private mod_iSaveToModel As ISaveToModel 
    ''#2 Jan2 2022''Private mod_iSaveToModel_Deprecated As ISaveToModel = New ClassSaveToModel() ''Suffixed _Deprecated 1/2/2022 td
    ''#3 Jan2 2022''Private mod_iSaveToModel As ISaveToModel = New ClassSaveToModel() 
    ''Dec28 2021 td''Private WithEvents mod_designer As New ClassDesigner ''Added 12/27/2021 td
    Private WithEvents ContextMenuStrip1 As New ContextMenuStrip ''Added 12/28/2021 thomas downes
    ''Jan4 2022''Private mod_iLayoutFunctions As ILayoutFunctions ''Added 12/28/2021 td
    Protected mod_iLayoutFunctions As ILayoutFunctions ''Added 12/28/2021 td
    ''Dec29 2021''Private mod_designer As ClassDesigner ''Added 12/28/2021 td 
    Private Const mc_AddExtraHeadersForContextMenuStrip As Boolean = False ''May 6, 2022 ''True ''Added 12/28/2021 thomas d.
    Private mod_iRefreshCardPreview As IRefreshCardPreview ''Added 1/30/2022 td 

    ''Added 12/28/2021 td
    ''4/245/2022 ''Private mod_objOperationsAny As Object ''Added 12/28/2021 td
    Protected mod_objOperationsAny As Object ''Added 12/28/2021 td
    Private mod_typeOperations As Type ''Added 12/28/2021 td
    Private mod_enumElementType As EnumElementType ''Added 12/28/2021 td
    Private Const mc_intMarginForResize As Integer = 10 ''Added 1/12/2022
    Protected RightclickMouseInfo As IRightclickMouseInfo ''Added 2/5/2022 td

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
        Dim oEventkillingBlackhole As New GroupMoveEvents_Singleton(dummyLayout, False, True)
        InitializeClickability(EnumElementType.Undetermined, oEventkillingBlackhole)

        ''Added 1/3/2022 td
        ''Jan3 2022 td''LastControlTouched_Info = New ClassLast

    End Sub ''End of "Public Sub New()"


    Public Sub New(par_enumElementType As EnumElementType,
                   par_elementBase As ClassElementBase,
                   par_cache As ciBadgeCachePersonality.ClassElementsCache_Deprecated,
                   par_formParent As Form,
                  pboolResizeProportionally As Boolean,
                   par_iLayoutFun As ILayoutFunctions,
                   par_iRefreshCardPreview As IRefreshCardPreview,
                   par_iSizeIfNeeded As Size,
                   par_operationsType As Type,
                   par_operationsAny As Object,
                   pboolAddMoveability As Boolean,
                   pboolAddClickability As Boolean,
                   par_iLastTouched As ILastControlTouched,
                   par_oMoveabilityEventsForGroup As GroupMoveEvents_Singleton,
                   par_proportionWH_IfNeeded As Single,
                   Optional pbHandleMouseEventsThroughVB6 As Boolean = True,
                   Optional pbUseMonemProportionalityClass As Boolean = False) ''----As IOperations)
        ''
        ''         ''Jan2 2022 ''par_iSaveToModel As ISaveToModel,
        ''         ''Dec29 2021 ''par_designer As ClassDesigner,

        ''All LinkLabels to have a transparent BackColor.---5/5/2022
        ''  https://social.msdn.microsoft.com/Forums/windows/en-US/ef3a3a56-118a-40d2-8635-0c2ceffbe0f3/control-does-not-support-transparent-background-colorsvbnet#:~:text=As%20the%20document%20says%20the%20BackColor%20property%20does,value%20of%20a%20form%20is%20set%20to%20false.
        ''  ---Added 5/5/2022
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)

        ' This call is required by the designer.
        InitializeComponent()

        Me.ElementBase = par_elementBase ''Added 5/5/2022 td
        Me.ParentForm = par_formParent ''Added 1/16/2022 td 
        Me.ElementsCache = par_cache ''Added 5/5/2022 td

        ''12/28/2021 td''par_toolstrip As ToolStripItemCollection)
        ''Added 1/4/2022 td
        Me.ExpectedProportionWH = par_proportionWH_IfNeeded

        ''Jan10 2022''mod_events = par_oMoveabilityEvents
        mod_eventsForGroupMove_NotNeeded = par_oMoveabilityEventsForGroup

        ''Added 1/30/2022 td
        mod_iRefreshCardPreview = par_iRefreshCardPreview

        ''Added 1/10/2022 td
        ''We need to instantiate a class. It's just for the movement of a single control, so
        ''  we probably don't need to use a shared class. In fact, it's better if we don't.
        ''  ---1/10/2022 td
        If (pboolAddMoveability) Then
            mod_eventsForSingleMove = New GroupMoveEvents_Singleton(par_iLayoutFun, True)
        End If ''End of "If (pboolAddMoveability) Then"

        ''Added 1/26/2022 thomas 
        If (par_iSizeIfNeeded.Height > 0) Then Me.Height = par_iSizeIfNeeded.Height
        If (par_iSizeIfNeeded.Width > 0) Then Me.Width = par_iSizeIfNeeded.Width

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
                            pbHandleMouseEventsThroughVB6,
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
                   Optional pbHandleMouseEventsThroughVB6 As Boolean = True,
                   Optional pbUseMonemProportionalityClass As Boolean = False)
        ''
        ''Encapsulated 1/3/2022
        ''
        ''Encapsulated 12/22/2021 thomas downes
        ''====InitializeMoveability(pboolResizeProportionally, par_iSaveToModel)
        ''Jan2 2022 td''mod_iSaveToModel = par_iSaveToModel ''Added 12/28/2021 td
        mod_boolResizeProportionally = pboolResizeProportionally ''Added 12/28/2021 td
        mod_iLayoutFunctions = par_iLayoutFun
        Me.LayoutFunctions = par_iLayoutFun ''Added 1/24/2022 td
        Me.LastControlTouched_Info = par_iLastTouched ''Added 12/29/2021 thomas d. 

        ''12/28/2021 td''InitializeMoveability(pboolResizeProportionally, par_iSaveToModel, par_iLayoutFun)
        ''#2 Dec28_2021 td''AddMoveability()
        ''Jan4 2022 td''If (pboolAddMoveability) Then AddMoveability()
        ''#2 Jan4 2022 td''If (pboolAddMoveability) Then AddMoveability(par_oMoveEventsFromForm)
        If (pboolAddMoveability) Then

            ''Jan7 2022 td''AddMoveability(par_oMoveEventsFromForm, par_iLayoutFun)
            ''Jan11 2022 td''AddMoveability(par_oMoveEventsGroupOfCtls,
            ''               par_oMoveEventsSingleCtl, par_iLayoutFun,
            AddMoveability(par_iLayoutFun, par_oMoveEventsGroupOfCtls,
                           par_oMoveEventsSingleCtl,
                           pboolResizeProportionally,
                           pbHandleMouseEventsThroughVB6,
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
        If (pboolAddClickability) Then

            AddClickability()

        End If ''eND OF ""If (pboolAddClickability) Then""

        ''Not needed. 1/10/2022 td. ---Added 1/5/2022 td
        ''Added 1/5/2022 td
        ''  Trying to prevent multiple event-handler connections. 
        ''RemoveHandler mod_events.Moving_End, AddressOf mod_events_Moving_End
        ''RemoveHandler mod_events.Moving_End, AddressOf mod_events_Moving_End
        ''RemoveHandler mod_events.Moving_End, AddressOf mod_events_Moving_End
        ''AddHandler mod_events.Moving_End, AddressOf mod_events_Moving_End

    End Sub ''End of "Public Sub Load_Functionality()"


    Public Sub AddMoveability(par_iLayoutFunctions As ILayoutFunctions,
                              Optional par_objEventsMoveGroupOfCtls As GroupMoveEvents_Singleton = Nothing,
                              Optional par_objEventsMoveSingleControl As GroupMoveEvents_Singleton = Nothing,
                              Optional pbAddProportionality As Boolean = False,
                              Optional pbHandleMouseEventsThroughUseControlVB As Boolean = True,
                              Optional pbUseMonemProportionalityClass As Boolean = False)
        ''Jan3 2022 ''Public Sub AddMoveability()
        ''
        ''Added 12/28/2021 td
        ''
        ''Dec28 2021''InitializeMoveability(mod_boolResizeProportionally, mod_iSaveToModel, mod_iLayoutFunctions)

        Dim boolInstantiated As Boolean ''Added 12/28/2021 td

        mod_boolRemoveMoveability = False ''Added 3/20/2022 td

        ''Jan11 2022 td''boolInstantiated = (mod_moveInAGroup IsNot Nothing) OrElse (mod_moveResizeKeepRatio IsNot Nothing)
        boolInstantiated = (mod_eventsForSingleMove IsNot Nothing)

        ''Added 1/10/2022 td
        If (par_objEventsMoveGroupOfCtls Is Nothing) Then

            par_objEventsMoveGroupOfCtls = Me.MoveabilityEventsForGroupCtls ''Added 1/11/2022

            ''The parameter object-reference is for the movement of a group of controls, so
            ''  we probably can't simple instantiate a class. In fact, it's certain we have to
            ''  throw an exception. ---1/10/2022 td
            If (par_objEventsMoveGroupOfCtls Is Nothing) Then
                Throw New NullReferenceException("Group-related events must be shared across controls.")
            End If ''End of If (par_objEventsMoveGroupOfCtls Is Nothing) Then

        ElseIf (par_objEventsMoveSingleControl Is Nothing) Then

            par_objEventsMoveSingleControl = Me.MoveabilityEventsForSingleMove ''Added 1/11/2022

            ''We need to instantiate a class. It's just for the movement of a single control, so
            ''  we probably don't need to use a shared class. In fact, it's better if we don't.
            ''  ---1/10/2022 td
            If (par_objEventsMoveSingleControl Is Nothing) Then
                par_objEventsMoveSingleControl = New GroupMoveEvents_Singleton(par_iLayoutFunctions, True)
            End If ''End of If (par_objEventsMoveSingleControl Is Nothing) Then

        End If ''End of "If (par_objEventsMoveGroupOfCtls Is Nothing) Then .... ElseIf (par_objEventsMoveSingleControl Is Nothing) Then"

        ''
        ''Save the parameter object references. ----1/11/2022 td
        ''
        Me.MoveabilityEventsForGroupCtls = par_objEventsMoveGroupOfCtls
        Me.MoveabilityEventsForSingleMove = par_objEventsMoveSingleControl

        ''
        ''First major step....
        ''
        If (boolInstantiated) Then ''Added 12/28/2021 td
            ''Added 12/28/2021 td
            ''  If instantiated, then set the Boolean property to false. 
            ''
            mod_iMoveOrResizeFunctionality.RemoveAllFunctionality = False
            ''Jan11 2022''If (mod_moveInAGroup IsNot Nothing) Then mod_moveInAGroup.RemoveAllFunctionality = False
            ''Jan11 2022''If (mod_moveResizeKeepRatio IsNot Nothing) Then mod_moveResizeKeepRatio.RemoveAllFunctionality = False

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
            ''      par_objEventsMoveGroupOfCtls, pbHandleMouseEventsThroughVB6,
            ''      pbUseMonemProportionalityClass)
            InitializeMoveability(mod_boolResizeProportionally, mod_iLayoutFunctions,
                                  par_objEventsMoveGroupOfCtls,
                                  par_objEventsMoveSingleControl,
                                  pbHandleMouseEventsThroughUseControlVB,
                                  pbUseMonemProportionalityClass)

        End If ''End of "If (boolInstantiated) Then ... Else ...."

    End Sub ''End of Public Sub AddMoveability 


    Public Sub AddMoveability_ViaLabel(par_Label As Label)
        ''
        ''Added 1/4/2022 td
        ''
        mod_iMoveOrResizeFunctionality.AddMoveability_ViaLabel(par_Label)

        mod_boolRemoveMoveability = False ''Added 3/20/2022 td 

    End Sub


    Public Sub AddMoveability_ViaPictureBox(par_PictureBox As PictureBox)
        ''
        ''Added 1/4/2022 td
        ''
        mod_boolRemoveMoveability = False ''Added 3/20/2022 td

    End Sub


    Public Sub RemoveMoveability(Optional pboolUseEasyWay As Boolean = True,
                                 Optional pbBlackholeMethed As Boolean = False)
        ''
        ''Added 12/28/2021 td
        ''
        mod_boolRemoveMoveability = True ''Added 3/20/2022 thomas d. 

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
        ''Jan11 2022''Me.mod_moveResizeKeepRatio = Nothing
        ''Jan11 2022''Me.mod_moveInAGroup = Nothing
        Me.mod_moveability_Monem = Nothing

    End Sub ''End of "Public Sub AddClickability()"

    ''Added 3/4/2022 thomas downes 
    ''Not needed. --3/4/2022''Private c_blankParams As StructResizeParams = New StructResizeParams()
    ''Not needed. --3/4/2022''Private Const c_blankParams_NotUsed As StructResizeParams_NotInUse = 0
    ''Not needed. --3/4/2022''Private c_blankParams_NotUsed As New StructResizeParams_NotInUse

    Public Sub AddSizeability(Optional pboolUseEasyWay As Boolean = True,
                              Optional par_structResizeParams As ClassStructResizeParams = Nothing)
        ''
        ''Added 12/28/2021 td
        ''
        Dim bAddSizing As Boolean = True ''True, because we want sizing.''Dec 29 2021 td

        mod_boolRemoveMoveability = False ''Added 3/20/2022 td

        ''----DIFFICULT & CONFUSING-------
        ''     We need to negate the Boolean variable (Not bAddSizing).
        ''
        mod_iMoveOrResizeFunctionality.RemoveSizeability = (Not bAddSizing) ''Added 12/28/2021 td

        ''
        ''Added 3/3/2022 td
        ''
        If (par_structResizeParams IsNot Nothing) Then

            mod_iMoveOrResizeFunctionality.ResizeParams = par_structResizeParams

        End If ''End of "If (par_structResizeParams IsNot Nothing) Then"

    End Sub ''End of ""Public Sub AddSizeability""


    Public Sub RemoveSizeability(Optional pboolUseEasyWay As Boolean = True)
        ''
        ''Added 12/28/2021 td
        ''
        Dim bAddSizing As Boolean = False ''False, as we are stopping sizing. ---Dec 29 2021 td

        ''----DIFFICULT & CONFUSING-------
        ''     We need to negate the Boolean variable (Not bAddSizing).
        ''
        mod_iMoveOrResizeFunctionality.RemoveSizeability = (Not bAddSizing) ''Added 12/28/2021 td

    End Sub ''End of ""Public Sub RemoveSizeability""


    Public Sub ShowConditionalExpression()
        ''
        ''Added 5/5/2022 td
        ''
        Dim objFormToShow As New FormConditional(Me.ElementsCache)
        Dim boolConfirmed As Boolean

        objFormToShow.ShowDialog()
        boolConfirmed = (objFormToShow.DialogResult = DialogResult.OK)
        If boolConfirmed Then

            Me.ConditionalExpressionInUse = objFormToShow.ConditionalExpressionInUse
            Me.ConditionalExpressionField = objFormToShow.ConditionalExpressionField
            Me.ConditionalExpressionValue = objFormToShow.ConditionalExpressionValue
            Me.ConditionalExp_LastEdited = Now ''Added 5/05/2022 td
            ''Added 5/05/2022 td
            LinkLabelConditional.Visible = Me.ConditionalExpressionInUse

        End If ''End of ""If boolConfirmed Then""

    End Sub ''End of ""Public Sub ShowConditionialExpression()""


    Public Sub InitializeMoveability(pboolResizeProportionally As Boolean,
                                     par_iLayoutFunctions As ILayoutFunctions,
                                     par_objMoveEventsForGroupMove As GroupMoveEvents_Singleton,
                                     par_objMoveEventsForSingleCtl As GroupMoveEvents_Singleton,
                      Optional pbHandleMouseEventsThroughVB6 As Boolean = True,
                      Optional pbUseMonemProportionalityClass As Boolean = False)
        ''
        ''Jan2 2022''       par_iSaveToModel As ISaveToModel,
        ''
        ''Added 12/22/2021 thomas downes
        ''
        Dim objPictureBox As PictureBox
        Dim resizeParamsStruct As New ClassStructResizeParams ''Added 3/4/2022 td

        ' Add any initialization after the InitializeComponent() call.
        mod_boolResizeProportionally = pboolResizeProportionally ''Added 12/22/2021 td

        resizeParamsStruct.InitiateResizing = True ''Added 3/13/2022 td
        resizeParamsStruct.ResizeProportionally = pboolResizeProportionally ''Added 3/4/2022 td

        ''Jan2 2022 td''mod_iSaveToModel = par_iSaveToModel
        Const c_bRepaintAfterResize As Boolean = True ''Added 7/31/2019 td

        ''Added 12/28/2021 td
        ''  Prepare for the next steps.
        ''
        ''Jan11 2022 td''mod_moveResizeKeepRatio = Nothing
        ''Jan11 2022 td''mod_moveInAGroup = Nothing
        mod_moveability_Monem = Nothing ''Added 1/11/2022 td

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
            ''  object mod_moveability_Monem), we will now remove
            ''  proportionality.  ---1/10/2022 td
            ''
            Dim bRemoveProportionality As Boolean = (Not pboolResizeProportionally)
            mod_moveability_Monem.RemoveProportionality = bRemoveProportionality


        Else
            ''
            ''We don't need to enforce "Proportionality", a constant Width-Height ratio. 
            ''
            ''Jan11 2022 td''mod_moveInAGroup = New MoveAndResizeControls_Monem.ControlMove_Group_NonStatic()
            mod_moveability_Monem = New MoveAndResizeControls_Monem.MonemControlMove_AllFunctionality

            ''mod_iLayoutFunctions = par_iLayoutFunctions
            ''mod_movingInAGroup.LayoutFunctions = par_iLayoutFunctions

            ''Jan10 2022 ''mod_events.LayoutFunctions = par_iLayoutFunctions ''Added 12/27/2021
            mod_eventsForSingleMove.LayoutFunctions = par_iLayoutFunctions ''Added 12/27/2021

            ''#1 Jan4 2022''mod_moveInAGroup.Init(Me, Me, 10, c_bRepaintAfterResize,
            ''                        mod_events, False, Me) ''1/2/2022 td''mod_iSaveToModel)
            ''#2 Jan4 2022''mod_moveInAGroup.Init(Nothing, Me, 10, c_bRepaintAfterResize,
            ''                        mod_events, False, Me) ''1/2/2022 td''mod_iSaveToModel)

            ''Added 1/7/2022 thomas d. 
            If (pbHandleMouseEventsThroughVB6) Then
                mod_bHandleMouseMoveEvents_ByVB6 = True
                mod_bHandleMouseMoveEvents_Monem = False
            Else
                mod_bHandleMouseMoveEvents_ByVB6 = False
                mod_bHandleMouseMoveEvents_Monem = True
            End If ''eNd of "If (pbHandleMouseEventsThroughVB6) Then ... Else"

            ''Added 1/4/2022 td
            objPictureBox = Find_PictureBox()

            ''Jan10 2022''mod_moveInAGroup.Init(objPictureBox, Me, 10, c_bRepaintAfterResize,
            ''Jan10 2022''                  mod_events, False, Me, False,
            ''Jan10 2022''                  mod_bHandleMouseMoveEvents_Monem)
            ''Jan11 2022''mod_moveInAGroup.Init(objPictureBox, Me, 10, c_bRepaintAfterResize,

            ''Jan11 2022 td''Const c_intMarginForResize As Integer = 10 ''Added 1/12/2022
            ''Jan27 2022 td  ''mod_moveability_Monem.Init(objPictureBox, Me,

            ''Feb02 2022 td ''mod_moveability_Monem.Init_V1(objPictureBox, Me,
            ''                           mc_intMarginForResize,
            ''                           c_bRepaintAfterResize,
            ''                                par_objMoveEventsForGroupMove,
            ''                                par_objMoveEventsForSingleCtl,
            ''                                False, Me, False,
            ''                                mod_bHandleMouseMoveEvents_Monem)

            ''Added 2/2/2022 td
            Const c_UndoEverything_False As Boolean = False
            Dim infoRefreshElem As IRefreshElementImage = Me
            Dim infoRefreshPrev As IRefreshCardPreview = Me.mod_iRefreshCardPreview

            ''Added 2/2/2022 td
            ''3/4/2022 ''mod_moveability_Monem.Init_V2(objPictureBox, Me,
            ''                           mc_intMarginForResize,
            ''                           c_bRepaintAfterResize,
            ''                                par_objMoveEventsForGroupMove,
            ''                                par_objMoveEventsForSingleCtl,
            ''                                False, Me, infoRefreshElem, infoRefreshPrev,
            ''                                c_UndoEverything_False,
            ''                                mod_bHandleMouseMoveEvents_Monem)

            ''Added 3/4/2022 td
            mod_moveability_Monem.Init_V3(objPictureBox, Me,
                                       mc_intMarginForResize,
                                            par_objMoveEventsForGroupMove,
                                            par_objMoveEventsForSingleCtl,
                                            False, Me, infoRefreshElem, infoRefreshPrev,
                                            resizeParamsStruct,
                                            c_UndoEverything_False,
                                            mod_bHandleMouseMoveEvents_Monem)

            ''1/11/2022 td''mod_iMoveOrResizeFunctionality = mod_moveInAGroup ''Added 12/28/2021 td
            mod_iMoveOrResizeFunctionality = mod_moveability_Monem ''Added 12/28/2021 td

        End If ''End of "If pboolResizeProportionally Then .... Else ..."


        ''
        ''Add Handlers to the Picture Box control /// IN THE CHILD USER CONTROL CLASS !! //
        ''
        If (mod_bHandleMouseMoveEvents_ByVB6) Then

            AddHandlersToPictureBoxInChildControl()

        End If ''End of 'If (mod_bHandleMouseMoveEvents_ByVB6) Then'

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
        Dim resizeClassStruct As New ClassStructResizeParams ''Added 3/4/2022 td

        ''1/10/2022 td''mod_events.LayoutFunctions = par_iLayoutFunctions ''Added 12/27/2021
        mod_eventsForSingleMove.LayoutFunctions = par_iLayoutFunctions ''Added 12/27/2021

        ''1/10/2022 td''mod_moveResizeKeepRatio = New MoveAndResizeControls_Monem.ControlResizeProportionally_TD()
        ''1/11/2022 td''mod_moveability_MonemClass = New MoveAndResizeControls_Monem.ControlMove_Group_NonStatic()
        mod_moveability_Monem = New MoveAndResizeControls_Monem.MonemControlMove_AllFunctionality()

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

        ''Added 3/4/2022 td
        resizeClassStruct.InitiateResizing = True ''Added 3/13/2022 td
        resizeClassStruct.KeepProportional_HtoW = True
        ''We have to take the reciprocal of the ratio, but check to see it's non-zero.
        resizeClassStruct.ProportionalRatio_HtoW =
            CInt(IIf(singleProportionWH <> 0, 1 / singleProportionWH, 0))

        ''1/4/2022 td''mod_moveResizeKeepRatio.Init(objPictureBox, Me, 10, c_bRepaintAfterResize,
        ''      mod_events, False, Me)
        ''1/11/2022 td''mod_moveResizeKeepRatio.Init(par_objPictureBox, Me, 10, par_bRepaintAfterResize,

        ''Jan11 2022''Const c_intMarginForResize As Integer = 10 ''Added 1/12/2022
        ''Jan27 2022 ''mod_moveability_Monem.Init(par_objPictureBox, Me, mc_intMarginForResize,

        Const c_bReverseInitiation_False As Boolean = False ''Added 1/27/2022 td

        ''3/4/2022 td''mod_moveability_Monem.Init_V1(par_objPictureBox, Me, mc_intMarginForResize,
        ''                                    par_bRepaintAfterResize,
        ''                                    mod_eventsForGroupMove_NotNeeded,
        ''                                    mod_eventsForSingleMove,
        ''                                    False, CType(Me, ISaveToModel),
        ''                                    c_bReverseInitiation_False,
        ''                                    mod_bHandleMouseMoveEvents_Monem,
        ''                                    True, singleProportionWH)

        ''Modified V1-->V3 on 3/4/2022 thomas d.
        mod_moveability_Monem.Init_V3(par_objPictureBox, Me, mc_intMarginForResize,
                                            mod_eventsForGroupMove_NotNeeded,
                                            mod_eventsForSingleMove,
                                            False, CType(Me, ISaveToModel),
                                            Me, mod_iRefreshCardPreview,
                                            resizeClassStruct,
                                            c_bReverseInitiation_False,
                                            mod_bHandleMouseMoveEvents_Monem)

        ''            ''1/2/2022 td '' mod_events, False, mod_iSaveToModel)
        ''---mod_resizingProportionally.LayoutFunctions = par_iLayoutFunctions 
        ''Jan11 2022''mod_iMoveOrResizeFunctionality = mod_moveResizeKeepRatio ''Added 12/28/2021 td
        mod_iMoveOrResizeFunctionality = mod_moveability_Monem ''Modified 1/11/2022 td Added 12/28/2021 td


    End Sub ''End of "Private Sub InitializeMoveability_Proportional()"

    ''Added 1/12/2022 td
    Private Delegate Sub SomeMouseEventHandler(sender As Object, e As MouseEventArgs) ''Added 1/12/2022 td
    Private Sub AddHandlersToPictureBoxInChildControl()
        ''
        ''  User Control Click - Windows Forms
        ''  https://stackoverflow.com/questions/1071579/user-control-click-windows-forms
        ''  User control's click event won't fire when another control is clicked on the user control. 
        ''  need to manually bind each element's click event. You can do this with a simple loop on
        ''  the user control's codebehind:
        ''
        Dim each_control As Windows.Forms.Control

        If (mod_bHandleMouseMoveEvents_ByVB6) Then

            If (mod_bHandleMouseMoveEvents_BaseClass) Then

                ''Added 1/12/2022 td
                ''
                ''Major call!!  Let's put a hard preference on the subprocedures in this base class,
                ''   versus subprocedures in the child classes (e.g. CtlGraphicFieldLabel), to 
                ''   handle MouseEvents on PictureBox controls defined in the child class.
                ''   ---1/12/2022 td 
                ''
                RemoveMouseEventHandlers_ChildClass()

                ''
                ''Let's tie the PictureBox controls in the child classes (defined in CIBadgeDesigner\Controls)
                ''  to subprocedures in this base class (RSCMoveableControlVB). ---1/12/2022 TD
                ''
                For Each each_control In Me.Controls

                    If (TypeOf each_control Is PictureBox) Then
                        ''
                        ''This control is 99% likely to be in the child (derived) user control,
                        ''   not in this base user control (the parent class).  ---1/7/2022 td
                        ''
                        ''// I am assuming MyUserControl_Click handles the click event of the user control.
                        ''Jan7 2022''AddHandler each_control.MouseClick, AddressOf MoveableControl_MouseClick

                        ''Step 1 of 2. We need to try to remove any existing handlers, likely implemented
                        ''   at design-time, to prevent ugly wiggling controls.  Looks unprofessional.
                        ''   ---January 11, 2022 thomas d.
                        ''
                        ''1/11 RemoveHandler each_control.MouseDown, SomeMouseEventHandler
                        RemoveHandler each_control.MouseDown, AddressOf MoveableControl_MouseDown

                        ''1/11 RemoveHandler each_control.MouseMove, SomeMouseEventHandler
                        RemoveHandler each_control.MouseMove, AddressOf MoveableControl_MouseMove

                        ''1/11 RemoveHandler each_control.MouseUp, SomeMouseEventHandler
                        RemoveHandler each_control.MouseUp, AddressOf MoveableControl_MouseUp

                        ''Step 2 of 2. Add the handlers which are needed, but might not be there. 
                        AddHandler each_control.MouseDown, AddressOf MoveableControl_MouseDown
                        AddHandler each_control.MouseMove, AddressOf MoveableControl_MouseMove
                        AddHandler each_control.MouseUp, AddressOf MoveableControl_MouseUp

                    End If ''end of "For Each each_control In Me.Controls"

                Next each_control

            End If ''End of 'If (mod_bHandleMouseMoveEvents_ByBaseClass) Then'

        End If ''ENd of "If (mod_bHandleMouseMoveEvents_ByVB6) Then"

    End Sub ''End of "Public Sub InitializeMoveability(..., ..., ...., ....)"


    ''Added 12/28/2021 td  
    Private mod_menuCacheNonShared As MenuCache_ActualInUse = Nothing ''New Operations_Generic(Me)
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
                mod_menuCacheNonShared = New MenuCache_ActualInUse(EnumElementType.Field,
                                                       mod_objOperationsGeneric.GetType(),
                                                       mod_objOperationsGeneric)

            Case EnumElementType.Portrait
                mod_menuCacheNonShared = New MenuCache_ActualInUse(EnumElementType.Portrait,
                                                       mod_objOperationsUseless.GetType(),
                                                       mod_objOperationsUseless)

            Case EnumElementType.QRCode
                mod_menuCacheNonShared = New MenuCache_ActualInUse(EnumElementType.QRCode,
                                                       mod_objOperationsGeneric.GetType(),
                                                       mod_objOperationsGeneric)

            Case EnumElementType.Signature
                mod_menuCacheNonShared = New MenuCache_ActualInUse(EnumElementType.Signature,
                                                       mod_objOperationsUseless.GetType(),
                                                       mod_objOperationsUseless)

            Case EnumElementType.StaticGraphic
                mod_menuCacheNonShared = New MenuCache_ActualInUse(EnumElementType.StaticGraphic,
                                                       mod_objOperationsGeneric.GetType(),
                                                       mod_objOperationsGeneric)

            Case EnumElementType.StaticText
                mod_menuCacheNonShared = New MenuCache_ActualInUse(EnumElementType.StaticText,
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


    Private Sub mod_events_Moving_End(par_control As Control, par_iSaveToModel As ISaveToModel) Handles mod_eventsForSingleMove.Moving_End '', mod_events.Resizing_End, mod_events.Moving_InProgress
        ''
        ''Added 12/27/2021 td 
        ''
        ''----mod_iSaveToModel.SaveToModel()
        par_iSaveToModel.SaveToModel()

        ''Added 1/5/2022 td
        ''  Trying to prevent multiple calls. 
        RemoveHandler mod_eventsForSingleMove.Moving_End, AddressOf mod_events_Moving_End
        RemoveHandler mod_eventsForSingleMove.Moving_End, AddressOf mod_events_Moving_End
        AddHandler mod_eventsForSingleMove.Moving_End, AddressOf mod_events_Moving_End

    End Sub


    Private Sub mod_events_Resizing_EndV1(par_iSaveToModel As ISaveToModel) Handles mod_eventsForSingleMove.Resizing_EndV1
        ''Jan26 2022''Private Sub mod_events_Resizing_End(par_iSaveToModel As ISaveToModel)
        ''
        ''Added 12/27/2021 td 
        ''
        ''---mod_iSaveToModel.SaveToModel()
        par_iSaveToModel.SaveToModel()

    End Sub ''End of "Private Sub mod_events_Resizing_EndV1(.....)"


    Private Sub mod_events_Resizing_EndV2(par_iSaveToModel As ISaveToModel,
                                              par_iRefreshImage As IRefreshElementImage,
                                              par_iRefreshPreview As IRefreshCardPreview) _
                                              Handles mod_eventsForSingleMove.Resizing_EndV2
        ''Feb2 2022''Private Sub mod_events_Resizing_End(par_iSaveToModel As ISaveToModel)
        ''
        ''Added 2/02/2022 td 
        ''
        par_iSaveToModel.SaveToModel()

        ''Added 2/02/2022 td
        par_iRefreshImage.RefreshElementImage()
        par_iRefreshPreview.RefreshCardPreview()

    End Sub ''End of "Private Sub mod_events_Resizing_EndV2(.....)"


    ''Private Sub mod_events_MovingInProgress(par_control As Control) Handles mod_eventsForSingleMove.Moving_InProgress
    ''    ''
    ''    ''Added 12/27/2021 td 
    ''    ''
    ''    ''---mod_iSaveToModel.SaveToModel()
    ''    ''---par_iSaveToModel.SaveToModel()
    ''    ''---mod_iSaveToModel.SaveToModel()
    ''End Sub


    Private Sub mod_events_MoveInUnison(deltaLeft As Integer, deltaTop As Integer,
                                        deltaWidth As Integer, deltaHeight As Integer, pbLeadControlLocationWasEdited As Boolean) Handles mod_eventsForSingleMove.MoveInUnison
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
                ''If (deltaTop > 5) Then System.Diagnostics.Debugger.Break()
                ''If (deltaTop < -5) Then System.Diagnostics.Debugger.Break()

                Const c_bMonemWritesToControlLocation As Boolean = True ''Added 1/11/2022 td
                If (c_bMonemWritesToControlLocation) Then
                    ''
                    '' We don't need to change the Location (.Top, .Left) here,
                    '' since the Monem class writes to the .Location property
                    '' ("par_controlG.Location = new Point(newLocation_x, newLocation_y);")
                    '' !!! --1/11/2022 td
                    ''
                Else
                    .Top += deltaTop
                    .Left += deltaLeft
                End If ''end of "If (c_bMonem.....) ... Else ...."
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
        MenuCache_Generic_NotUsed.CtlCurrentElement = Me ''par_control ''Added 10/14/2019 td  
        ''#1 Dec28 2021 td''MenuCache_Generic.Operations_Edit.CtlCurrentElement = Me ''par_control ''Added 10/14/2019 td
        ''#2 Dec28 2021 td''mod_operationsGenericEdits.CtlCurrentElement = Me ''Modified 12/28/2021 td

        ''Added 12/28/2021 thomas downes
        mod_menuCacheNonShared = New MenuCache_ActualInUse(mod_enumElementType,
                                                         mod_objOperationsAny.GetType(), mod_objOperationsAny)
        ''Added 12/28/2021 thomas downes
        mod_menuCacheNonShared.GenerateMenuItems_IfNeeded()

        ContextMenuStrip1.Items.Clear()

        Dim bool_addExtraHeadersToContextMenus As Boolean ''Added 12/13/2021 td
        ''Dec.28 2021 td''bool_addExtraHeadersToContextMenus = AddExtraHeadersToolStripMenuItem.Checked
        bool_addExtraHeadersToContextMenus = mc_AddExtraHeadersForContextMenuStrip

        ''Added header items. 
        If (bool_addExtraHeadersToContextMenus) Then

            ''Add a ToolStripMenuItem which will tell which Field is being displayed 
            ''  on the selected (right-clicked) control. 
            ''Dec28 ''ContextMenuStrip1.Items.Add(MenuCache_Generic.Tools_MenuHeader0) ''Added 12/13/2021 
            ''Dec28 ''ContextMenuStrip1.Items.Add(MenuCache_Generic.Tools_MenuHeader1) ''Added 12/12/2021 
            ContextMenuStrip1.Items.Add(mod_menuCacheNonShared.Tools_MenuHeader0) ''Added 12/13/2021 
            ContextMenuStrip1.Items.Add(mod_menuCacheNonShared.Tools_MenuHeader1) ''Added 12/12/2021 

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

            ''Let's add a separator bar. 
            ''Dec28 2021 td''ContextMenuStrip1.Items.Add(MenuCache_Generic.Tools_MenuSeparator) ''Added 12/13/2021
            ContextMenuStrip1.Items.Add(mod_menuCacheNonShared.Tools_MenuSeparator) ''Added 12/13/2021

        End If ''End of "If (bool_addExtraHeadersToContextMenus) Then"

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
        If (bool_addExtraHeadersToContextMenus) Then ''Added May 6, 2022 
            With mod_menuCacheNonShared.Tools_MenuHeader1
                ''Dim objHeader1 As ToolStripItem = MenuCache_ElemFlds.Tools_MenuHeader1
                ''Dec28 2021 td''.Text = String.Format(.Tag.ToString(), par_control.FieldInfo.FieldLabelCaption,
                ''Dec28 2021 td''          par_control.FieldInfo.CIBadgeField)
                .Text = String.Format(.Tag.ToString(), Me.Name, "[CI Badge Field is n/a]")
            End With ''End of "With mod_menuCacheNonShared.Tools_MenuHeader1"
        End If ''End of "If (bool_addExtraHeadersToContextMenus) Then"

        ''Added 12/13/2021 td
        ''  Change the text "Context-Menu for Control: {0}" to "Context-Menu for Control: ....".
        ''
        ''Dec28 2021 td''With MenuCache_Generic.Tools_MenuHeader0
        If (bool_addExtraHeadersToContextMenus) Then ''Added May 6, 2022 
            With mod_menuCacheNonShared.Tools_MenuHeader0
                ''Dec28 2021''.Text = String.Format(.Tag.ToString(), par_control.Name)
                .Text = String.Format(.Tag.ToString(), Me.Name)
            End With ''End of "With MenuCache_ElemFlds.Tools_MenuHeader0"
        End If ''End of "If (bool_addExtraHeadersToContextMenus) Then"

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

        ''Added 2/5/2022 thomas downes
        ''Feb5 2022 ''mod_objOperationsAny.MouseClickX = par_intX
        ''Feb5 2022 ''mod_objOperationsAny.MouseClickY = par_intY
        RightclickMouseInfo.MouseclickX = par_intX ''Added 2/5/2022 td
        RightclickMouseInfo.MouseclickY = par_intY ''Added 2/5/2022 td

        ''Added 3/19/2022 thomas downes
        If (ContextMenuStrip1.Items.Count = 0) Then
            ''Added 3/19/2022 thomas downes
            MessageBoxTD.Show_Statement("The context menu is currently empty.")
        End If ''End of "If (ContextMenuStrip1.Items.Count = 0) Then"

        ''Feb4 2022 td''ContextMenuStrip1.Show()
        ContextMenuStrip1.Show(Me.Left + par_intX, Me.Top + par_intY)

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
        ''Public Overridable Sub SaveToModel() Implements ISaveToModel.SaveToModel
        ''
        ''Added 1/2/2022 td 
        ''
        ''1/2/2022 td''DirectCast(LastControlTouched_Deprecated, ISaveToModel).SaveToModel()
        ''5/5/2022 td''MessageBoxTD.Show_Statement("SaveToModel(). Programmer must override this base-class method, using the keyword Overrides.")
        ''5/5/2022 td''System.Diagnostics.Debugger.Break()

        ''Added 5/5/2022 td
        If (Me.ElementBase IsNot Nothing) Then
            With Me.ElementBase
                .ConditionalExp_LastEdited = Me.ConditionalExp_LastEdited
                .ConditionalExpressionField = Me.ConditionalExpressionField
                .ConditionalExpressionInUse = Me.ConditionalExpressionInUse
                .ConditionalExpressionValue = Me.ConditionalExpressionValue
            End With
        End If ''end of ""If (Me.ElementBase IsNot Nothing) Then""

    End Sub ''End of ""Public Overridable Sub SaveToModel()""


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
    ''    If (mod_bHandleMouseMoveEvents_ByVB6) Then
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
        If (mod_bHandleMouseMoveEvents_ByVB6 AndAlso (par_e.Button = MouseButtons.Left)) Then
            ''
            ''It's a Left-Hand click. (Think, "Click-and-Drag".)
            ''
            ''Added 3/20/2022 td
            If (mod_boolRemoveMoveability) Then Exit Sub

            ''Let the module know that a MouseMove took place. 
            mod_iMoveOrResizeFunctionality.StartMovingOrResizing(CType(sender, Control), par_e)

        End If ''End of "If (mod_bHandleMouseMoveEvents And par_e.Button = MouseButtons.Left) Then"

    End Sub


    Protected Sub MoveableControl_MouseMove(sender As Object, par_e As MouseEventArgs) Handles MyBase.MouseMove
        ''
        ''Added 1/4/2022 thomas d.
        ''
        ''1/7/2022 td''If (mod_bHandleMouseMoveEvents_ByVB6 AndAlso (par_e.Button = MouseButtons.Left)) Then

        Dim boolButtonIsOkay As Boolean ''Added 1/7/2022 td

        ''Added 3/02/2022 thomas downes
        ''3/20/22 ''If (mod_iMoveOrResizeFunctionality Is Nothing) Then
        If (mod_boolRemoveMoveability) Then
            Return ''Added 3/20/2022 td

        ElseIf (mod_iMoveOrResizeFunctionality Is Nothing) Then
            ''Throw New Exception("Moving object is nothing.")
            ''System.Diagnostics.Debugger.Break()
            Exit Sub
        End If

        ''1/7/2022 td''boolButtonIsOkay = (par_e.Button = MouseButtons.Left)
        boolButtonIsOkay = ((par_e.Button = MouseButtons.Left) Or
            (par_e.Button = MouseButtons.None)) ''Added 1/7/2022 td

        If (mod_bHandleMouseMoveEvents_ByVB6 And boolButtonIsOkay) Then

            ''Added 1/10/2022 td
            With mod_iMoveOrResizeFunctionality

                ''Added 1/10/2022 td
                If (.NowInMotion()) Then
                    Dim bDummy As Boolean = True
                End If ''End of "If (.NowInMotion()) Then"

                ''
                ''Let the Monem module know that a MouseMove took place.
                ''
                ''---{---Nasty bug!!!!!!! 1/11/2022 td
                ''---{mod_iMoveOrResizeFunctionality.MoveParentControl(CType(sender, Control), par_e)

                Dim objParentControl As Control ''Added 1/11/20222
                objParentControl = Me ''Added 1/11/20222
                mod_iMoveOrResizeFunctionality.MoveParentControl(objParentControl, par_e)

            End With ''End of "With mod_iMoveOrResizeFunctionality"

        End If ''Endof "If (mod_bHandleMouseMoveEvents_ByVB6) Then"

    End Sub ''ENd of "Protected Sub MoveableControl_MouseMove"


    Protected Sub MoveableControl_MouseUp(par_sender As Object, par_e As MouseEventArgs) Handles Me.MouseUp
        ''
        ''Added 1/4/2022 thomas d.
        ''
        Dim bHandledByChildControl As Boolean ''Added Jan14 2022
        ''Jan14 2022''bHandledByChildControl = (par_e.Button = MouseButtons.Middle)
        ''Jan14 2022''If (bHandledByChildControl) Then par_e.Button = MouseButtons.Left
        bHandledByChildControl = (TypeOf par_sender Is PictureBox)

        If (mod_bHandleMouseMoveEvents_ByVB6 AndAlso (par_e.Button = MouseButtons.Left)) Then
            ''
            ''It's a Left-Button click.    (i.e. a Click-And-Drag action by user)
            ''
            ''Added 3/20/2022 td
            If (mod_boolRemoveMoveability) Then Exit Sub

            ''Let the module know that a MouseUp took place. 
            ''Jan14 2022 td''mod_iMoveOrResizeFunctionality.StopDragOrResizing(CType(par_sender, Control), Me)

            ''----Nasty bug.  Don't use par_sender here, since it could be a PictureBox. ---1/11/2022 td
            ''
            ''--MyBase.MoveableControl_MouseUp(par_sender, par_e)
            Dim info_SaveToModel As ISaveToModel ''Added 1/14/2022 td
            Dim info_RefreshElementImage As IRefreshElementImage ''Added 1/28/2022 td
            Dim info_RefreshCardPreview As IRefreshCardPreview ''Added 1/28/2022 td
            Dim objCTLGraphicOrRSCMoveable As Control ''Added 1/14/2022

            ''Added 1/14/2022
            info_SaveToModel = CType(Me, ISaveToModel)

            ''Added 1/28/2022
            info_RefreshElementImage = CType(Me, IRefreshElementImage)
            ''Jan30 2022 td''info_RefreshCardPreview = CType(Me, IRefreshCardPreview)
            info_RefreshCardPreview = CType(Me.mod_iRefreshCardPreview, IRefreshCardPreview)

            If (TypeOf par_sender Is PictureBox) Then
                objCTLGraphicOrRSCMoveable = Me
            Else
                objCTLGraphicOrRSCMoveable = CType(par_sender, Control)
            End If ''End of "If (TypeOf par_sender Is PictureBox) Then ... Else"

            ''Jan14 2022 td''mod_iMoveOrResizeFunctionality.StopDragOrResizing(CType(par_sender, Control), Me)
            ''   Let's don't use par_sender here, since it could be a PictureBox. ---1/11/2022 td
            ''Jan27 2022 td ''mod_iMoveOrResizeFunctionality.StopDragOrResizing(objCTLGraphicOrRSCMoveable, info_SaveToModel)
            ''Jan28 2022 td ''mod_iMoveOrResizeFunctionality.StopDragOrResizingV1(objCTLGraphicOrRSCMoveable, info_SaveToModel)
            mod_iMoveOrResizeFunctionality.StopDragOrResizingV2(objCTLGraphicOrRSCMoveable,
                                                                info_SaveToModel,
                                                                info_RefreshElementImage,
                                                                info_RefreshCardPreview)


        ElseIf (par_e.Button = MouseButtons.Right) Then
            ''            ''
            ''  Right-Button click, i.e. a context-menu request by user.          
            ''            ''-----Added 12/28/2021 td
            ''            ''
            mod_designer_ElementRightClicked(par_e.X, par_e.Y)

        End If ''End of "If (mod_bHandleMouseMoveEvents And par_e.Button = MouseButtons.Left) Then"

    End Sub ''End of Protected Sub MoveableControl_MouseUp


    Public Overridable Sub RemoveMouseEventHandlers_ChildClass()
        ''
        ''Added this dummy Sub on 1/12/2022 
        ''
        Throw New Exception("Must be overridden by the child user control, e.g. CtlGraphicsStaticText")

    End Sub


    Public Overridable Sub AddMouseEventHandlers_ChildClass()
        ''    ''
        ''    ''Added this dummy Sub on 1/12/2022 
        ''    ''
        Throw New Exception("Must be overridden by the child user control, e.g. CtlGraphicsStaticText")

    End Sub



    ''Private Sub mod_eventsForSingleMove_ControlIsMoving() Handles mod_eventsForSingleMove.ControlIsMoving
    ''End Sub

    Private Sub RSCMoveableControlVB_Move(sender As Object, e As EventArgs) ''1/12/2022 Handles Me.Move

        ''1/12/2022 ''---- Testing Code, added 1/11/2022 td ----
        ''1/12/2022 ''Static static_iTop As Integer = Me.Top
        ''1/12/2022 ''If (Me.Top < static_iTop) Then System.Diagnostics.Debugger.Break()
        ''1/12/2022 ''static_iTop = Me.Top


    End Sub

    ''Jan12 2022 td''Public MustOverride Function ImageForBadgeImage(par_recipient As IRecipient) As Image Implements IElement_Base.ImageForBadgeImage

    ''Added 1/12/2022 td
    Public Overridable Function Rotated_0degrees() As Boolean ''Added 1/12/2022 td
        ''Added 1/12/2022 td
        Return False

    End Function


    Public Overridable Function Rotated_180_360() As Boolean ''Added 1/12/2022 td
        ''Added 1/12/2022 td
        Return False

    End Function


    Public Overridable Function Rotated_90_270(pbCheckRotationIsDone As Boolean,
                          Optional ByRef pref_bRotationIsDone As Boolean = False) As Boolean ''Added 1/12/2022 td
        ''Added 1/12/2022 td
        Return False

    End Function


    ''1/12/2022 td''Public ElementInfo_Base As IElement_Base ''Added 1/12/2022 td 

    Public Overridable Sub Refresh_Master()
        ''
        ''Added 1/24/2022 td
        ''
        Refresh_PositionAndSize()
        ''Feb1 2022 td''Refresh_Image(True, True, True)
        Refresh_ImageV3(True, True, True)

    End Sub ''End of "Public Overridable Sub Refresh_Master()"


    Public Overridable Sub Refresh_PositionAndSize()
        ''
        ''Copy-pasted 1/24/2022 thomas d 
        ''Added 9/5/2019 thomas d 
        ''
        ''9/19/2019 td''Me.Left = Me.FormDesigner.Layout_Margin_Left_Add(Me.ElementInfo_Base.LeftEdge_Pixels)
        ''9/19/2019 td''Me.Top = Me.FormDesigner.Layout_Margin_Top_Add(Me.ElementInfo_Base.TopEdge_Pixels)

        Me.Left = Me.LayoutFunctions.Layout_Margin_Left_Add(Me.ElementInfo_Base.LeftEdge_Pixels)
        Me.Top = Me.LayoutFunctions.Layout_Margin_Top_Add(Me.ElementInfo_Base.TopEdge_Pixels)

        Me.Width = Me.ElementInfo_Base.Width_Pixels
        Me.Height = Me.ElementInfo_Base.Height_Pixels

    End Sub ''End of "Public Overridable Sub Refresh_PositionAndSize()"


    Public Sub RefreshElementImage() Implements IRefreshElementImage.RefreshElementImage
        ''
        ''Added 1/28/2022 td
        ''
        ''Feb1 2022 td''Refresh_Image(True)
        ''Feb1 2022 td''Refresh_ImageV3(True)
        Refresh_ImageV4(True)

    End Sub ''end of "Public Sub RefreshElementImage()"

    Public Overridable Sub Refresh_ImageV3(pbRefreshSize As Boolean,
                             Optional pboolResizePictureControl As Boolean = True,
                             Optional pboolRefreshPictureControl As Boolean = True,
                             Optional pboolRefreshUserControl As Boolean = False,
                             Optional pobjElementFieldV3 As ClassElementFieldV3 = Nothing)
        ''
        ''Stubbed 1/13/2022 td
        ''

    End Sub ''End of "Public Overridable Sub Refresh_ImageV3"


    Public Overridable Sub Refresh_ImageV4(pbRefreshSize As Boolean,
                             Optional pboolResizePictureControl As Boolean = True,
                             Optional pboolRefreshPictureControl As Boolean = True,
                             Optional pboolRefreshUserControl As Boolean = False,
                             Optional pobjElementField As ClassElementFieldV4 = Nothing)
        ''
        ''Stubbed 1/31/2022 td
        ''

    End Sub ''End of "Public Overridable Sub Refresh_Image"


    Public Function InsideMe(par_intX As Integer, par_intY As Integer) As Boolean
        ''
        ''Added 9/20/2019 td  
        ''
        Dim boolInsideHorizontally As Boolean
        Dim boolInsideVertically As Boolean
        Dim boolInside_BothWays As Boolean

        boolInsideHorizontally = (Me.Left <= par_intX And par_intX <= (Me.Left + Me.Width))
        boolInsideVertically = (Me.Top <= par_intY And par_intY <= (Me.Top + Me.Height))

        boolInside_BothWays = (boolInsideHorizontally And boolInsideVertically)
        Return boolInside_BothWays

    End Function ''eND OF "Public Function InsideMe(par_intX, par_intY As Integer) As Boolean"


    Public Sub Highlight_IfInsideRubberband(par_rubberband As Rectangle,
                     Optional par_bRedrawElement As Boolean = False)
        ''
        ''Added 9/20/2019 thomas downes
        ''
        Dim boolRubBandIsAll_LeftOfMe As Boolean
        Dim boolRubBandIsAll_RightOfMe As Boolean
        Dim boolRubBandIsAll_AboveMe As Boolean
        Dim boolRubBandIsAll_BelowMe As Boolean

        Dim boolBandIsInsideMeHorizontally As Boolean
        Dim boolBandIsInsideMeVertically As Boolean
        Dim boolBandIsInsideMe_BothWays As Boolean
        Dim boolBandOverlapsWithMe As Boolean

        Dim obj_rectangleAdjusted As Rectangle

        Dim intRbandInDesignForm_Left As Integer
        Dim intRbandInDesignForm_Top As Integer

        With par_rubberband ''Added 9/20/2019 td

            ''Rband = Rubberband 
            ''1/13/2022 ''intRbandInDesignForm_Left = Me.LayoutFunctions.Layout_Margin_Left_Add(.Left)
            ''1/13/2022 ''intRbandInDesignForm_Top = Me.LayoutFunctions.Layout_Margin_Top_Add(.Top)
            intRbandInDesignForm_Left = mod_iLayoutFunctions.Layout_Margin_Left_Add(.Left)
            intRbandInDesignForm_Top = mod_iLayoutFunctions.Layout_Margin_Top_Add(.Top)

            ''Added 9/20/2019 td
            obj_rectangleAdjusted =
                New Rectangle(intRbandInDesignForm_Left,
                              intRbandInDesignForm_Top,
                                     .Width, .Height)

        End With ''End of "With par_rubberband"

        With obj_rectangleAdjusted

            boolRubBandIsAll_AboveMe = ((.Top + .Height) < Me.Top)
            boolRubBandIsAll_BelowMe = ((Me.Top + Me.Height) < .Top)

            boolRubBandIsAll_LeftOfMe = (.Left + .Width < Me.Left)
            boolRubBandIsAll_RightOfMe = ((Me.Left + Me.Width) < .Left)

        End With ''End of " With par_rubberband"

        boolBandIsInsideMeHorizontally = (Not (boolRubBandIsAll_LeftOfMe Or boolRubBandIsAll_RightOfMe))
        boolBandIsInsideMeVertically = (Not (boolRubBandIsAll_AboveMe Or boolRubBandIsAll_BelowMe))

        boolBandIsInsideMe_BothWays = (boolBandIsInsideMeHorizontally And boolBandIsInsideMeVertically)
        boolBandOverlapsWithMe = boolBandIsInsideMe_BothWays

        If (boolBandOverlapsWithMe) Then
            ''1/13/2022 td''Me.ElementClass_Obj.SelectedHighlighting = True
            ElementInfo_Base.SelectedHighlighting = True

            ''10/13/2019 td''Me.Refresh_Image(False)
            ''02/01/2022 td''If (par_bRedrawElement) Then Me.Refresh_Image(False)
            If (par_bRedrawElement) Then Me.Refresh_ImageV3(False)

        End If ''End of "If (boolBandOverlapsWithMe) Then"

    End Sub ''End of "Public Sub Highlight_IfInsideRubberband()"


    Public Sub RaiseEvent_ControlClicked()

        ''Added 5/4/2022 td
        RaiseEvent RSCControlClicked()

    End Sub


    Private Sub RSCMoveableControlVB_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint

        ''Added 3/07/2022 & 3/02/2022 thomas downes
        ''--If (mod_iMoveOrResizeFunctionality Is Nothing) Then Throw New Exception("Moving object is nothing.")

    End Sub

    Private Sub LinkLabelConditional_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelConditional.LinkClicked

        ''Added 5/5/2022 thomas Downes
        ShowConditionalExpression()

        ''Dim objFormToShow As New FormConditional(Me.ElementsCache)
        ''Dim boolConfirmed As Boolean

        ''objFormToShow.ShowDialog()
        ''boolConfirmed = (objFormToShow.DialogResult = DialogResult.OK)
        ''If boolConfirmed Then

        ''    Me.ConditionalExpressionInUse = objFormToShow.ConditionalExpressionInUse
        ''    Me.ConditionalExpressionField = objFormToShow.ConditionalExpressionField
        ''    Me.ConditionalExpressionValue = objFormToShow.ConditionalExpressionValue
        ''    Me.ConditionalExp_LastEdited = Now ''Added 5/05/2022 td

        ''End If ''End of ""If boolConfirmed Then""

    End Sub



End Class
