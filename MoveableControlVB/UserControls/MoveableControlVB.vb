Option Explicit On
Option Strict On

Imports MoveAndResizeControls_Monem ''Added 12/22/2021 td
Imports ciBadgeInterfaces ''Added 12/22/2021 td
''--Imports windows.Forms ''Added 12/22/2021
Imports System.Windows.Forms
Imports ciBadgeDesigner ''Added 12/27/2021 td 
Imports __RSCWindowsControlLibrary ''Added 12/29/2021 thomas d. 

''
''Added 12/22/2021 td  
''
Public Class MoveableControlVB
    Implements ISaveToModel ''Added 1/2/2022 td
    ''
    ''Added 12/22/2021 td  
    ''
    Public Shared LastControlTouched_Deprecated As MoveableControlVB

    Public Shared Function GetControl(par_enum As EnumElementType,
                                par_nameOfControl As String,
                                      par_bProportionSizing As Boolean,
                                      par_designer As ClassDesigner,
                                par_iControlLastTouched As ILastControlTouched) As MoveableControlVB
        ''Jan2 2022 ''     par_iSaveToModel As ISaveToModel,
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
        Dim MoveableControlVB1 = New MoveableControlVB(par_enum, par_bProportionSizing,
                                                   par_designer,
                                                   par_designer,
                                                   typeOps,
                                                   objOperations,
                                                   bAddFunctionalitySooner,
                                                   bAddFunctionalitySooner,
                                                   par_iControlLastTouched)
        ''                           ''Jan2 2022''      par_iSaveToModel,

        With MoveableControlVB1
            .Name = par_nameOfControl
            If (bAddFunctionalityLater) Then .AddMoveability()
            If (bAddFunctionalityLater) Then .AddClickability()
        End With ''eNd of "With MoveableControlVB1"

        ''
        ''Specify the current element to the Operations object. 
        ''
        Dim infoOps = CType(objOperations, ICurrentElement) ''.CtlCurrentElement = MoveableControlVB1
        infoOps.CtlCurrentElement = MoveableControlVB1

        Return MoveableControlVB1

    End Function ''End of Public Shared Function BuildControl

    ''Added 12/29/2021 thomas
    Public AbleMoveable As Boolean
    Public AbleRightClickable As Boolean
    Public AbleSizeable As Boolean
    Public AbleSelectable As Boolean

    Public LastControlTouched_Info As ILastControlTouched ''Added 12/28/2021 thomas d. 
    Public LastControlTouched_Obj As ClassLastControlTouched ''Added 12/29/2021 thomas d. 

    Public MyToolstripItemCollection As ToolStripItemCollection ''Added 12/28/2021 td 
    Private mod_boolResizeProportionally As Boolean

    ''Depending on the above Boolean, one of the following will be instantiated. 
    ''Let's rename. 12/28/2021 td''Private mod_movingInAGroup As ControlMove_Group_NonStatic = Nothing
    ''Let's rename. 12/28/2021 td''Private mod_resizeProportionally As ControlResizeProportionally_TD = Nothing
    ''Jan11 2022''Private mod_moveInAGroup As ControlMove_Group_NonStatic = Nothing
    ''Jan11 2022''Private mod_moveResizeKeepRatio As ControlResizeProportionally_TD = Nothing
    Private mod_moveability As ControlMove_AllFunctionality = Nothing
    Private mod_iMoveOrResizeFunctionality As IMoveOrResizeFunctionality ''InterfaceMoveOrResize ''Added 12/28/2021 td

    ''[[Private WithEvents mod_eventsDesigner As New ciBadgeDesigner.ClassGroupMoveEvents ''InterfaceEvents
    ''[[Private WithEvents mod_eventsRSC As New __RSCWindowsControlLibrary.ClassGroupMoveEvents ''InterfaceEvents
    ''))((Jan10 2022''Private WithEvents mod_eventsMove As New ciBadgeInterfaces.GroupMoveEvents_Singleton ''InterfaceEvents
    Private WithEvents mod_eventsMoveGroupedCtls As New ciBadgeInterfaces.GroupMoveEvents_Singleton ''InterfaceEvents
    Private WithEvents mod_eventsMoveThisControl As New ciBadgeInterfaces.GroupMoveEvents_Singleton ''InterfaceEvents

    Private mod_iSaveToModel_Deprecated As ISaveToModel
    ''Dec28 2021 td''Private WithEvents mod_designer As New ClassDesigner ''Added 12/27/2021 td
    Private WithEvents ContextMenuStrip1 As New ContextMenuStrip ''Added 12/28/2021 thomas downes
    Private mod_iLayoutFunctions As ILayoutFunctions ''Added 12/28/2021 td
    Private mod_designer As ClassDesigner ''Added 12/28/2021 td 
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

        Dim objLayoutFun As New ClassDesigner ''Added Dec27 2021
        ''jan2 2022''InitializeMoveability(False, New ClassSaveToModel, New ClassDesigner())
        InitializeMoveability(False, New ClassDesigner())

        ''Encapsulated 12/22/2021 thomas downes
        ''Dec28 2021 td''InitializeClickability(New ClassDesigner())
        InitializeClickability(New ClassDesigner(), EnumElementType.Undetermined)

    End Sub

    Friend Sub New(par_enumElementType As EnumElementType,
                  pboolResizeProportionally As Boolean,
                   par_iLayoutFun As ILayoutFunctions,
                   par_designer As ClassDesigner,
                   par_operationsType As Type,
                   par_operationsAny As Object,
                   pboolAddMoveability As Boolean,
                   pboolAddClickability As Boolean,
                   par_iLastTouched As ILastControlTouched) ''----As IOperations)

        ''Jan2 2022 td ''par_iSaveToModel As ISaveToModel,
        ''12/28/2021 td''par_toolstrip As ToolStripItemCollection)

        ' This call is required by the designer.
        InitializeComponent()

        ''Encapsulated 12/22/2021 thomas downes
        ''====InitializeMoveability(pboolResizeProportionally, par_iSaveToModel)
        ''Jan2 2022 td''mod_iSaveToModel = par_iSaveToModel ''Added 12/28/2021 td
        mod_boolResizeProportionally = pboolResizeProportionally ''Added 12/28/2021 td
        mod_iLayoutFunctions = par_iLayoutFun

        Me.LastControlTouched_Info = par_iLastTouched ''Added 12/29/2021 thomas d. 
        ''Dec29 2021 td''Me.LastControlTouched_Obj = par_objLastTouched ''Added 12/29/2021 thomas d. 

        ''12/28/2021 td''InitializeMoveability(pboolResizeProportionally, par_iSaveToModel, par_iLayoutFun)
        ''#2 Dec28_2021 td''AddMoveability()
        If (pboolAddMoveability) Then AddMoveability()

        ''Encapsulated 12/22/2021 thomas downes
        ''Dec28 2021 td''Me.MyToolstripItemCollection = par_toolstrip ''Added 12/28/2021 td
        mod_designer = par_designer

        mod_enumElementType = par_enumElementType
        mod_objOperationsAny = par_operationsAny
        mod_typeOperations = par_operationsType

        ''Dec28_2021 td''InitializeClickability(par_designer)
        ''#2 Dec28_2021 td''AddClickability()
        If (pboolAddClickability) Then AddClickability()

    End Sub


    Public Sub AddMoveability()
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
            ''--If (mod_moveInAGroup IsNot Nothing) Then mod_moveInAGroup.RemoveAllFunctionality = False
            ''--If (mod_moveResizeKeepRatio IsNot Nothing) Then mod_moveResizeKeepRatio.RemoveAllFunctionality = False
            mod_iMoveOrResizeFunctionality.RemoveAllFunctionality = False

        Else
            ''#1 Jan2 2022 td''InitializeMoveability(mod_boolResizeProportionally, mod_iSaveToModel, mod_iLayoutFunctions)
            ''#2 Jan2 2022 td''InitializeMoveability(mod_boolResizeProportionally, Me, mod_iLayoutFunctions)

            InitializeMoveability(mod_boolResizeProportionally, mod_iLayoutFunctions)

        End If ''End of "If (boolInstantiated) Then ... Else ...."

        ''Dec29
        AbleMoveable = True

    End Sub


    Public Sub RemoveMoveability(Optional pboolUseEasyWay As Boolean = True)
        ''
        ''Added 12/28/2021 td
        ''
        If (Not pboolUseEasyWay) Then mod_iMoveOrResizeFunctionality.Reverse_Init() ''Added 12/28/2021 td
        If (pboolUseEasyWay) Then mod_iMoveOrResizeFunctionality.RemoveAllFunctionality = True ''Added 12/28/2021 td

        AbleMoveable = False ''Added dec29

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
        AbleRightClickable = True ''Dec29

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
        AbleRightClickable = False ''dec29

    End Sub ''End of "Public Sub RemoveClickability()"


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
                                     par_iLayoutFunctions As ILayoutFunctions)
        ''           Jan2 2022 td''  par_iSaveToModel As ISaveToModel,
        ''
        ''Added 12/22/2021 thomas downes
        ''
        ' Add any initialization after the InitializeComponent() call.
        mod_boolResizeProportionally = pboolResizeProportionally ''Added 12/22/2021 td
        ''Jan2 2022''mod_iSaveToModel = par_iSaveToModel

        Const c_bRepaintAfterResize As Boolean = True ''Added 7/31/2019 td

        ''Added 12/28/2021 td
        ''  Prepare for the next steps.
        ''
        mod_moveResizeKeepRatio = Nothing
        mod_moveInAGroup = Nothing

        ''Not needed. 1/3/2022 td''mod_eventsDesigner.LayoutFunctions = par_iLayoutFunctions
        ''Not needed. 1/3/2022 td''mod_eventsRSC.LayoutFunctions = par_iLayoutFunctions

        ''
        ''Instantiate the Resizing or Moving modules (instances).
        ''
        If pboolResizeProportionally Then

            ''Not needed. This command should happen at the form level. 1/3/2022 td''mod_eventsDesigner.LayoutFunctions = par_iLayoutFunctions ''Added 12/27/2021

            ''Jan11 2022''mod_moveResizeKeepRatio = New MoveAndResizeControls_Monem.ControlResizeProportionally_TD()
            mod_moveability = New MoveAndResizeControls_Monem.ControlMove_AllFunctionality

            ''Jan4 2022''mod_moveResizeKeepRatio.Init(Me, Me, 10, c_bRepaintAfterResize,
            ''              mod_eventsMove, False, Me)  ''1/2/2022 td''mod_iSaveToModel)
            mod_moveability.Init(Nothing, Me, 10, c_bRepaintAfterResize,
                                            mod_eventsMoveGroupedCtls,
                                            mod_eventsMoveThisControl,
                                            False, Me)  ''1/2/2022 td''mod_iSaveToModel)
            ''---mod_resizingProportionally.LayoutFunctions = par_iLayoutFunctions 
            ''Jan11 2022''mod_iMoveOrResizeFunctionality = mod_moveResizeKeepRatio ''Added 12/28/2021 td
            mod_iMoveOrResizeFunctionality = mod_moveability ''Modified 1/11/2022 Added 12/28/2021 td


        Else

            ''Jan11 2022''mod_moveInAGroup = New MoveAndResizeControls_Monem.ControlMove_Group_NonStatic()
            mod_moveability = New MoveAndResizeControls_Monem.ControlMove_AllFunctionality()

            ''mod_iLayoutFunctions = par_iLayoutFunctions
            ''mod_movingInAGroup.LayoutFunctions = par_iLayoutFunctions

            ''Not needed. This command should happen at the form level. 1/3/2022 td''mod_eventsDesigner.LayoutFunctions = par_iLayoutFunctions ''Added 12/27/2021

            ''Jan3 2022 td''mod_moveInAGroup.Init(Me, Me, 10, c_bRepaintAfterResize,
            ''                   mod_eventsDesigner, False, Me) ''Jan2 2022'' mod_iSaveToModel)
            ''#1 Jan4 2022 ''mod_moveInAGroup.Init(Me, Me, 10, c_bRepaintAfterResize,
            ''                        mod_eventsMove, False, Me) ''Jan2 2022'' mod_iSaveToModel)
            ''#2 Jan4 2022 ''mod_moveInAGroup.Init(Nothing, Me, 10, c_bRepaintAfterResize,
            ''       mod_eventsMove, False, Me) ''Jan2 2022'' mod_iSaveToModel)
            mod_moveInAGroup.Init(Nothing, Me, 10, c_bRepaintAfterResize,
                                    mod_eventsMoveGroupedCtls,
                                      mod_eventsMoveThisControl,
                                    False, Me) ''Jan2 2022'' mod_iSaveToModel)

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

    End Sub ''End of "Public Sub InitializeMoveability"


    ''Added 12/28/2021 td  
    Private mod_menuCacheNonShared As MenuCache_NonShared = Nothing ''New Operations_Generic(Me)
    ''Dec28 2021 td''Private mod_menuCacheUseless As MenuCache_NonShared = Nothing ''New Operations_Useless(Me)
    Private mod_objOperationsGeneric As Operations__Generic = Nothing ''New Operations_Generic(Me)
    Private mod_objOperationsUseless As Operations__Useless = Nothing ''New Operations_Useless(Me)

    Private Sub InitializeClickability(par_designer As ClassDesigner, par_enum As EnumElementType)
        ''
        ''Added 12/22/2021 thomas downes
        ''
        ''Dec28, 2021 td''mod_designer = par_designer
        ''
        mod_objOperationsGeneric = New Operations__Generic(Me)
        mod_objOperationsUseless = New Operations__Useless(Me)

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

        Else

            ''Added 12/29/2021 td
            With Me.LastControlTouched_Obj
                ''Dec29 2021 td''Me.LastControlTouched_Info.LastControlTouched = Me
                .LastControlTouched = Me

                ''Added 12/29/2021 td
                If (.ReactivateMenu) Then
                    AddClickability()
                    mod_designer_ElementRightClicked(e.X, e.Y)
                End If ''End of "If (.ReactivateMenu) Then"

            End With

        End If ''End of "If (e.Button = MouseButtons.Right) Then ... Else ...."

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

    Private Sub mod_events_Moving_End(par_control As Control, par_iSaveToModel As ISaveToModel) Handles mod_eventsMoveThisControl.Moving_End '', mod_events.Resizing_End, mod_events.Moving_InProgress
        ''
        ''Added 12/27/2021 td 
        ''
        ''----mod_iSaveToModel.SaveToModel()
        ''Jan2 2022 thomas downes''par_iSaveToModel.SaveToModel()
        SaveToModel()

    End Sub


    Private Sub mod_events_Resizing_End(par_iSaveToModel As ISaveToModel) Handles mod_eventsMoveThisControl.Resizing_End
        ''
        ''Added 12/27/2021 td 
        ''
        ''---mod_iSaveToModel.SaveToModel()
        par_iSaveToModel.SaveToModel()

    End Sub

    Private Sub mod_events_MovingInProgress(par_control As Control) Handles mod_eventsMoveThisControl.Moving_InProgress
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

    Private Sub MoveableControlVB_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub MoveableControlVB_Click(sender As Object, e As EventArgs) Handles Me.Click

        ''Added 12/29/2021 td
        Me.LastControlTouched_Info.LastControlTouched = Me

    End Sub

    Public Overridable Sub SaveToModel() Implements ISaveToModel.SaveToModel

        ''Throw New NotImplementedException()
        MessageBoxTD.Show_Statement("Programmer will override base-class method SaveToModel, using the keyword Overrides.")

    End Sub

    Private Sub mod_eventsMoveThisControl_MoveInUnison(deltaLeft As Integer, deltaTop As Integer, deltaWidth As Integer, deltaHeight As Integer) Handles mod_eventsMoveThisControl.MoveInUnison

        ''Added 1/10/2022 td



    End Sub



End Class
