Option Explicit On
Option Strict On

Imports MoveAndResizeControls_Monem ''Added 12/22/2021 td
Imports ciBadgeInterfaces ''Added 12/22/2021 td
''--Imports windows.Forms ''Added 12/22/2021
Imports System.Windows.Forms
''
''Added 12/22/2021 td  
''
Public Class MoveableControl_Obselete
    ''
    ''Added 12/22/2021 td  
    ''
    Private mod_resizingProportionally As ControlResizeProportionally_TD
    Private mod_movingInAGroup As ControlMove_Group_NonStatic
    Private mod_boolResizeProportionally As Boolean
    Private WithEvents mod_events As New ClassGroupMoveEvents ''InterfaceEvents
    Private mod_iSaveToModel As ISaveToModel
    Private WithEvents mod_designer As New ClassDesigner ''Added 12/27/2021 td

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
                   par_designer As ClassDesigner)

        ' This call is required by the designer.
        InitializeComponent()

        ''Encapsulated 12/22/2021 thomas downes
        ''====InitializeMoveability(pboolResizeProportionally, par_iSaveToModel)
        InitializeMoveability(pboolResizeProportionally, par_iSaveToModel, par_iLayoutFun)

        ''Encapsulated 12/22/2021 thomas downes
        InitializeClickability(par_designer)

    End Sub

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


    Private Sub InitializeClickability(par_designer As ClassDesigner)
        ''
        ''Added 12/22/2021 thomas downes
        ''
        mod_designer = par_designer

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
        ''Added 12/22/2021 td  
        ''


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


    Private Sub mod_designer_ElementRightClicked(par_control As CtlGraphicFldLabel) Handles mod_designer.ElementFieldRightClicked
        ''
        ''Added 10/13/2019 thomas downes  
        ''
        ''MenuCache_FieldElements.CtlCurrentElement = par_control ''Added 10/14/2019 td  
        ''MenuCache_FieldElements.Operations_Edit.CtlCurrentElement = par_control ''Added 10/14/2019 td

        ''ContextMenuStrip1.Items.Clear()

        ''''Add a ToolStripMenuItem which will tell which Field is being displayed 
        ''''  on the selected (right-clicked) control. 
        ''ContextMenuStrip1.Items.Add(MenuCache_FieldElements.Tools_MenuHeader0) ''Added 12/13/2021 
        ''ContextMenuStrip1.Items.Add(MenuCache_FieldElements.Tools_MenuHeader1) ''Added 12/12/2021 

        ''Dim bool_addExtraHeadersToContextMenus As Boolean ''Added 12/13/2021 td
        ''bool_addExtraHeadersToContextMenus = AddExtraHeadersToolStripMenuItem.Checked

        ''''Added header items. 
        ''If (bool_addExtraHeadersToContextMenus) Then
        ''    ''Added 12/13/2021 
        ''    ContextMenuStrip1.Items.Add(MenuCache_FieldElements.Tools_MenuHeader2) ''Added 12/12/2021 
        ''    ContextMenuStrip1.Items.Add(MenuCache_FieldElements.Tools_MenuHeader3) ''Added 12/13/2021 

        ''    Dim objMenuHeader3_1 As New ToolStripMenuItem("mod_designer_ElementRightClicked(...")
        ''    Dim objMenuHeader3_2 As New ToolStripMenuItem("   ... Handles mod_designer.ElementRightClicked")
        ''    ContextMenuStrip1.Items.Add(objMenuHeader3_1) ''Added 12/13/2021 
        ''    ''Dec.13 ''ContextMenuStrip1.Items.Add(objMenuHeader3_2) ''Added 12/13/2021 
        ''    ''  Make 3_2 a sub-item under 3_1. ---12/13/2021 td 
        ''    objMenuHeader3_1.DropDownItems.Add(objMenuHeader3_2)

        ''End If ''End of "If (mod_letsAddExtraHeadersForContextMenus) Then"

        ''''Let's add a separator bar. 
        ''ContextMenuStrip1.Items.Add(MenuCache_FieldElements.Tools_MenuSeparator) ''Added 12/13/2021

        ''''
        ''''Major step!!!   Add all the editing-related menu items!!
        ''''
        ''ContextMenuStrip1.Items.AddRange(MenuCache_FieldElements.Tools_EditElementMenu)

        ''''Added 12/13/2021 td
        ''''  Change the text "Field: {0} ({1})" to "Field: School Name (fstrField1)".
        ''With MenuCache_FieldElements.Tools_MenuHeader1
        ''    ''Dim objHeader1 As ToolStripItem = MenuCache_ElemFlds.Tools_MenuHeader1
        ''    .Text = String.Format(.Tag.ToString(), par_control.FieldInfo.FieldLabelCaption,
        ''                                            par_control.FieldInfo.CIBadgeField)
        ''End With ''End of "With MenuCache_ElemFlds.Tools_MenuHeader1"

        ''''Added 12/13/2021 td
        ''''  Change the text "Context-Menu for Control: {0}" to "Context-Menu for Control: ....".
        ''With MenuCache_FieldElements.Tools_MenuHeader0
        ''    .Text = String.Format(.Tag.ToString(), par_control.Name)
        ''End With ''End of "With MenuCache_ElemFlds.Tools_MenuHeader0"

        ''''10/13 td''ContextMenuStrip1.Show()
        ''''10/13 td''ContextMenuStrip1.Show(par_control, New Point(par_control.Left, par_control.Top))
        ''ContextMenuStrip1.Show(par_control, New Point(0, 0))

    End Sub ''End of "Private Sub mod_designer_ElementRightClicked"





End Class
