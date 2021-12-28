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
Public Class MoveableControlVB
    ''
    ''Added 12/22/2021 td  
    ''
    Public Shared LastControlTouched As MoveableControlVB

    Public MyToolstripItemCollection As ToolStripItemCollection ''Added 12/28/2021 td 
    Private mod_boolResizeProportionally As Boolean

    ''Depending on the above Boolean, one of the following will be instantiated. 
    Private mod_resizingProportionally As ControlResizeProportionally_TD = Nothing
    Private mod_movingInAGroup As ControlMove_Group_NonStatic = Nothing

    Private WithEvents mod_events As New ClassGroupMoveEvents ''InterfaceEvents
    Private mod_iSaveToModel As ISaveToModel
    ''Dec28 2021 td''Private WithEvents mod_designer As New ClassDesigner ''Added 12/27/2021 td
    Private WithEvents ContextMenuStrip1 As New ContextMenuStrip ''Added 12/28/2021 thomas downes
    Private mod_iLayoutFunctions As ILayoutFunctions ''Added 12/28/2021 td
    Private mod_designer As ClassDesigner ''Added 12/28/2021 td 
    Private Const mc_AddExtraHeadersForContextMenuStrip As Boolean = True ''Added 12/28/2021 thomas d.

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ''Encapsulated 12/22/2021 thomas downes
        ''Dec27 2021''InitializeMoveability(False, New ClassSaveToModel)

        Dim objLayoutFun As New ClassDesigner ''Added Dec27 2021
        InitializeMoveability(False, New ClassSaveToModel, New ClassDesigner())

        ''Encapsulated 12/22/2021 thomas downes
        InitializeClickability(New ClassDesigner())

    End Sub

    Public Sub New(pboolResizeProportionally As Boolean,
                   par_iSaveToModel As ISaveToModel,
                   par_iLayoutFun As ILayoutFunctions,
                   par_designer As ClassDesigner,
                   par_toolstrip As ToolStripItemCollection)

        ' This call is required by the designer.
        InitializeComponent()

        ''Encapsulated 12/22/2021 thomas downes
        ''====InitializeMoveability(pboolResizeProportionally, par_iSaveToModel)
        mod_iSaveToModel = par_iSaveToModel ''Added 12/28/2021 td
        mod_boolResizeProportionally = pboolResizeProportionally ''Added 12/28/2021 td
        mod_iLayoutFunctions = par_iLayoutFun
        ''12/28/2021 td''InitializeMoveability(pboolResizeProportionally, par_iSaveToModel, par_iLayoutFun)
        AddMoveability()

        ''Encapsulated 12/22/2021 thomas downes
        Me.MyToolstripItemCollection = par_toolstrip ''Added 12/28/2021 td
        mod_designer = par_designer
        ''Dec28_2021 td''InitializeClickability(par_designer)
        AddClickability()

    End Sub


    Public Sub AddMoveability()
        ''
        ''Added 12/28/2021 td
        ''
        InitializeMoveability(mod_boolResizeProportionally, mod_iSaveToModel, mod_iLayoutFunctions)

    End Sub


    Public Sub RemoveMoveability()
        ''
        ''Added 12/28/2021 td
        ''
        If (True Or Not mod_boolResizeProportionally) Then mod_movingInAGroup = Nothing
        If (True Or mod_boolResizeProportionally) Then mod_resizingProportionally = Nothing

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
        Me.mod_resizingProportionally = Nothing
        Me.mod_movingInAGroup = Nothing

    End Sub ''End of "Public Sub AddClickability()"


    Public Sub InitializeMoveability(pboolResizeProportionally As Boolean,
                                     par_iSaveToModel As ISaveToModel,
                                     par_iLayoutFunctions As ILayoutFunctions)
        ''
        ''Added 12/22/2021 thomas downes
        ''
        ' Add any initialization after the InitializeComponent() call.
        mod_boolResizeProportionally = pboolResizeProportionally ''Added 12/22/2021 td
        mod_iSaveToModel = par_iSaveToModel
        Const c_bRepaintAfterResize As Boolean = True ''Added 7/31/2019 td

        ''Added 12/28/2021 td
        ''  Prepare for the next steps.
        ''
        mod_resizingProportionally = Nothing
        mod_movingInAGroup = Nothing
        mod_events.LayoutFunctions = par_iLayoutFunctions

        ''
        ''Instantiate the Resizing or Moving modules (instances).
        ''
        If pboolResizeProportionally Then

            mod_resizingProportionally = New MoveAndResizeControls_Monem.ControlResizeProportionally_TD()
            mod_events.LayoutFunctions = par_iLayoutFunctions ''Added 12/27/2021
            mod_resizingProportionally.Init(Me, Me, 10, c_bRepaintAfterResize,
                                            mod_events, False, mod_iSaveToModel)
            ''---mod_resizingProportionally.LayoutFunctions = par_iLayoutFunctions 

        Else
            mod_movingInAGroup = New MoveAndResizeControls_Monem.ControlMove_Group_NonStatic()

            ''mod_iLayoutFunctions = par_iLayoutFunctions
            ''mod_movingInAGroup.LayoutFunctions = par_iLayoutFunctions

            mod_events.LayoutFunctions = par_iLayoutFunctions ''Added 12/27/2021

            mod_movingInAGroup.Init(Me, Me, 10, c_bRepaintAfterResize,
                                    mod_events, False, mod_iSaveToModel)

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

        End If ''End of "If (e.Button = MouseButtons.Right) Then"

    End Sub

    Protected Sub MoveableControl_MouseDown(sender As Object, e As Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        ''
        ''Added 12/22/2021 thomas downes
        ''
    End Sub


    Protected Sub MoveableControl_MouseUp(sender As Object, e As Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp
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
        mod_iSaveToModel.SaveToModel()

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

        ContextMenuStrip1.Items.Clear()

        ''Add a ToolStripMenuItem which will tell which Field is being displayed 
        ''  on the selected (right-clicked) control. 
        ContextMenuStrip1.Items.Add(MenuCache_Generic.Tools_MenuHeader0) ''Added 12/13/2021 
        ContextMenuStrip1.Items.Add(MenuCache_Generic.Tools_MenuHeader1) ''Added 12/12/2021 

        Dim bool_addExtraHeadersToContextMenus As Boolean ''Added 12/13/2021 td
        ''Dec.28 2021 td''bool_addExtraHeadersToContextMenus = AddExtraHeadersToolStripMenuItem.Checked
        bool_addExtraHeadersToContextMenus = mc_AddExtraHeadersForContextMenuStrip

        ''Added header items. 
        If (bool_addExtraHeadersToContextMenus) Then
            ''Added 12/13/2021 
            ContextMenuStrip1.Items.Add(MenuCache_Generic.Tools_MenuHeader2) ''Added 12/12/2021 
            ContextMenuStrip1.Items.Add(MenuCache_Generic.Tools_MenuHeader3) ''Added 12/13/2021 

            Dim objMenuHeader3_1 As New ToolStripMenuItem("mod_designer_ElementRightClicked(...")
            Dim objMenuHeader3_2 As New ToolStripMenuItem("   ... Handles mod_designer.ElementRightClicked")
            ContextMenuStrip1.Items.Add(objMenuHeader3_1) ''Added 12/13/2021 
            ''Dec.13 ''ContextMenuStrip1.Items.Add(objMenuHeader3_2) ''Added 12/13/2021 
            ''  Make 3_2 a sub-item under 3_1. ---12/13/2021 td 
            objMenuHeader3_1.DropDownItems.Add(objMenuHeader3_2)

        End If ''End of "If (mod_letsAddExtraHeadersForContextMenus) Then"

        ''Let's add a separator bar. 
        ContextMenuStrip1.Items.Add(MenuCache_Generic.Tools_MenuSeparator) ''Added 12/13/2021

        ''
        ''Major step!!!   Add all the editing-related menu items!!
        ''
        ''Dec28, 2021 td''ContextMenuStrip1.Items.AddRange(MenuCache_Generic.Tools_EditElementMenu)
        ''#2 Dec28 2021 td''ContextMenuStrip1.Items.AddRange(MenuCache_Generic.Get_EditElementMenu(EnumElementType.Field))

        If (Me.MyToolstripItemCollection Is Nothing) Then Throw New Exception("333 3 3 3 3 3 1966")
        ContextMenuStrip1.Items.AddRange(Me.MyToolstripItemCollection)

        ''Added 12/13/2021 td
        ''  Change the text "Field: {0} ({1})" to "Field: School Name (fstrField1)".
        With MenuCache_Generic.Tools_MenuHeader1
            ''Dim objHeader1 As ToolStripItem = MenuCache_ElemFlds.Tools_MenuHeader1
            ''Dec28 2021 td''.Text = String.Format(.Tag.ToString(), par_control.FieldInfo.FieldLabelCaption,
            ''Dec28 2021 td''          par_control.FieldInfo.CIBadgeField)
            .Text = String.Format(.Tag.ToString(), Me.Name, "[CI Badge Field is n/a]")
        End With ''End of "With MenuCache_ElemFlds.Tools_MenuHeader1"

        ''Added 12/13/2021 td
        ''  Change the text "Context-Menu for Control: {0}" to "Context-Menu for Control: ....".
        With MenuCache_Generic.Tools_MenuHeader0
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



End Class
