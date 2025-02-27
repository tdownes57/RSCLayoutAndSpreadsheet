﻿''
''Added 1/15/2022 thomas downes
''
''This is a Component, vs. a UserControl.  ''See https://groups.google.com/g/microsoft.public.dotnet.languages.vb/c/XDDtTx_dySc/m/NZgfN6PqCdcJ?pli=1
''
Option Explicit On
Option Strict On
''
''This is a Component, vs. a UserControl.  See https://groups.google.com/g/microsoft.public.dotnet.languages.vb/c/XDDtTx_dySc/m/NZgfN6PqCdcJ?pli=1
''
''Imports MoveAndResizeControls_Monem ''Added 12/22/2021 td
Imports ciBadgeInterfaces ''Added 12/22/2021 td
''--Imports windows.Forms ''Added 12/22/2021
''Imports System.Windows.Forms
''Imports ciBadgeDesigner ''Added 12/27/2021 td 
''Imports ciBadgeElements ''added 1/22/2022
''
''This is a Component, vs. a UserControl.  ''See https://groups.google.com/g/microsoft.public.dotnet.languages.vb/c/XDDtTx_dySc/m/NZgfN6PqCdcJ?pli=1
''

Public Class RSCClickableDesktop
    ''
    ''Added 1/15/2022 thomas downes
    ''
    Public ParentDesignerForm As Form ''Jan15 2022''IDesignerForm ''Added 1/15/2022 td
    Public ParentControl As Control ''Added 1/15/2022 td
    Public MyFlowLayoutPanel As FlowLayoutPanel ''Added 1/15/2022 td  
    Public Name As String = "RSCClickableDesktop" ''Added 1/15/2022 td
    Public MyToolstripItemCollection As ToolStripItemCollection ''Added 12/28/2021 td
    Public MyLinkLabelCollection As List(Of LinkLabel) ''Added 1/15/2022 td

    ''Added 12/28/2021 td
    Protected mod_objOperationsAny As Object ''Added 12/28/2021 td
    Protected mod_typeOperations As Type ''Added 12/28/2021 td
    Protected mod_enumElementType As EnumElementType ''Added 12/28/2021 td

    ''Added 12/28/2021 td  
    Protected mod_menuCacheNonShared As MenuCache_ActualInUse = Nothing ''New Operations_Generic(Me)
    ''Dec28 2021 td''Private mod_menuCacheUseless As MenuCache_NonShared = Nothing ''New Operations_Useless(Me)
    Protected mod_objOperationsGeneric As Operations__Generic = Nothing ''New Operations_Generic(Me)
    Protected mod_objOperationsUseless As Operations__Useless = Nothing ''New Operations_Useless(Me)
    Protected mod_objOperationsDesktop As Operations__Desktop_Dummy = Nothing ''Added 1/15/2022 td

    Protected Const mc_AddExtraHeadersForContextMenuStrip As Boolean = False ''May 6, 2022 True ''Added 1/15/2022 td

    ''Public Sub New()
    ''    ''    ''Don't expect the Moveability to work, we are sending the events
    ''    ''    ''   into a blackhole!!  ---1/4/2022 td
    ''    ''    Dim dummyLayout As New ClassLayoutFunctions
    ''    ''    Dim oEventkillingBlackhole As New GroupMoveEvents_Singleton(dummyLayout, False, True)
    ''    ''    InitializeClickability(EnumElementType.Undetermined, oEventkillingBlackhole)
    ''    ''
    ''End Sub


    Public Overridable Sub InitializeClickability(par_formParent As Form,
                                                  par_flowLayoutPanel As FlowLayoutPanel) ''Jan15 2022'' par_designer As ClassDesigner)
        ''
        ''Added 1/15/2022 thomas downes
        ''
        Me.ParentDesignerForm = par_formParent
        Me.MyFlowLayoutPanel = par_flowLayoutPanel ''Added 1/5/2022 td  
        InitializeClickability()
        AddClickability()

    End Sub ''End of "Public Overridable Sub InitializeClickability"


    Public Overridable Sub InitializeClickability() ''Jan15 2022'' par_designer As ClassDesigner)

        ''Jan15 2022 td''Private Sub InitializeClickability(par_enum As EnumElementType,
        ''                  par_moveabilityEvents As GroupMoveEvents_Singleton)
        ''Jan4 2022 td''Private Sub InitializeClickability(par_enum As EnumElementType)
        ''Dec29 2021 td''Private Sub InitializeClickability(par_designer As ClassDesigner,
        ''     par_enum As EnumElementType)
        ''
        ''Added 12/22/2021 thomas downes
        ''
        ''Dec28, 2021 td''mod_designer = par_designer
        ''Jan1 2022 ''mod_designer = par_designer

        ''
        ''Jan4 2022 td''mod_objOperationsGeneric = New Operations__Generic(Me)
        ''Jan4 2022 td''mod_objOperationsUseless = New Operations__Useless(Me)
        mod_objOperationsDesktop = New Operations__Desktop_Dummy()
        mod_objOperationsAny = mod_objOperationsDesktop

        ''#2 Jan4 ''mod_objOperationsGeneric = New Operations__Generic(Me, par_moveabilityEvents)
        ''#2 Jan4 ''mod_objOperationsUseless = New Operations__Useless(Me, par_moveabilityEvents)
        ''#3 Jan4 ''mod_objOperationsGeneric = New Operations__Generic(Me, par_moveabilityEvents, mod_iLayoutFunctions)
        ''#3 Jan4 ''mod_objOperationsUseless = New Operations__Useless(Me, par_moveabilityEvents, mod_iLayoutFunctions)

        ''mod_menuCacheGeneric = New MenuCache_NonShared(EnumElementType.Field,
        ''                                               mod_objOperationsGeneric.GetType(),
        ''                                               mod_objOperationsGeneric)

        mod_menuCacheNonShared = New MenuCache_ActualInUse(EnumElementType.__Desktop,
                                                       mod_objOperationsDesktop.GetType(),
                                                       mod_objOperationsDesktop)

        ''Select Case par_enum

        ''    Case EnumElementType.Field
        ''        mod_menuCacheNonShared = New MenuCache_NonShared(EnumElementType.Field,
        ''                                               mod_objOperationsGeneric.GetType(),
        ''                                               mod_objOperationsGeneric)

        ''    Case EnumElementType.Portrait
        ''        mod_menuCacheNonShared = New MenuCache_NonShared(EnumElementType.Portrait,
        ''                                               mod_objOperationsUseless.GetType(),
        ''                                               mod_objOperationsUseless)

        ''    Case EnumElementType.QRCode
        ''        mod_menuCacheNonShared = New MenuCache_NonShared(EnumElementType.QRCode,
        ''                                               mod_objOperationsGeneric.GetType(),
        ''                                               mod_objOperationsGeneric)

        ''    Case EnumElementType.Signature
        ''        mod_menuCacheNonShared = New MenuCache_NonShared(EnumElementType.Signature,
        ''                                               mod_objOperationsUseless.GetType(),
        ''                                               mod_objOperationsUseless)

        ''    Case EnumElementType.StaticGraphic
        ''        mod_menuCacheNonShared = New MenuCache_NonShared(EnumElementType.StaticGraphic,
        ''                                               mod_objOperationsGeneric.GetType(),
        ''                                               mod_objOperationsGeneric)

        ''    Case EnumElementType.StaticText
        ''        mod_menuCacheNonShared = New MenuCache_NonShared(EnumElementType.StaticText,
        ''                                               mod_objOperationsUseless.GetType(),
        ''                                               mod_objOperationsUseless)

        ''End Select ''End of "Select Case par_enum"


    End Sub ''End of "Private Sub InitializeClickability()"


    Public Overridable Sub ClickableDesktop_MouseUp(par_sender As Object, par_e As MouseEventArgs) ''Handles Me.MouseUp
        ''
        ''Added 1/4/2022 thomas d.
        ''
        If (par_e.Button = MouseButtons.Right) Then
            ''            ''
            ''  Right-Button click, i.e. a context-menu request by user.          
            ''            ''-----Added 12/28/2021 td
            ''            ''
            mod_designer_ElementRightClicked(par_e.X, par_e.Y)

        End If ''End of "If (mod_bHandleMouseMoveEvents And par_e.Button = MouseButtons.Left) Then"

    End Sub ''End of Public Overridable Sub ClickableDesktop_MouseUp


    Public Overridable Sub AddClickability()
        ''
        ''Added 12/28/2021 td
        ''
        ''Dec28 2021''InitializeClickability(mod_designer)
        Init_ForRightClicked()

    End Sub ''End of "Public Sub AddClickability()"


    Private Sub Init_ForRightClicked()
        ''
        ''Adapted from the formerly-existing Private Sub mod_designer_ElementRightClicked(par_intX As Integer, par_intY As Integer) on 12/28/2021 td 
        ''
        Me.ContextMenuStrip1 = New ContextMenuStrip()

        ''Dec28 2021 td''Private Sub mod_designer_ElementRightClicked(par_intX As Integer, par_intY As Integer) '' par_control As CtlGraphicFldLabel) ''Handles mod_designer.ElementFieldRightClicked
        ''
        ''Added 10/13/2019 thomas downes  
        ''
        ''Jan15 2022 td''MenuCache_Generic.CtlCurrentElement = Me ''par_control ''Added 10/14/2019 td

        ''#1 Dec28 2021 td''MenuCache_Generic.Operations_Edit.CtlCurrentElement = Me ''par_control ''Added 10/14/2019 td
        ''#2 Dec28 2021 td''mod_operationsGenericEdits.CtlCurrentElement = Me ''Modified 12/28/2021 td

        ''Added 12/28/2021 thomas downes
        mod_menuCacheNonShared = New MenuCache_ActualInUse(mod_enumElementType,
                 mod_objOperationsAny.GetType(), mod_objOperationsAny)
        ''Added 12/28/2021 thomas downes
        mod_menuCacheNonShared.GenerateMenuItems_IfNeeded()

        ContextMenuStrip1.Items.Clear()

        ''Added 5/6/2022 thomas downes
        Dim boolAddHeaders As Boolean ''Added 5/6/2022 t//d//

        With mod_menuCacheNonShared ''Added 5/6/2022 t//d//

            ''Added 5/6/2022
            boolAddHeaders = (.Tools_MenuHeader0 IsNot Nothing)

            ''Add a ToolStripMenuItem which will tell which Field is being displayed 
            ''  on the selected (right-clicked) control. 
            ''Dec28 ''ContextMenuStrip1.Items.Add(MenuCache_Generic.Tools_MenuHeader0) ''Added 12/13/2021 
            ''Dec28 ''ContextMenuStrip1.Items.Add(MenuCache_Generic.Tools_MenuHeader1) ''Added 12/12/2021 

            If (boolAddHeaders) Then
                ContextMenuStrip1.Items.Add(.Tools_MenuHeader0) ''Added 12/13/2021 
                ContextMenuStrip1.Items.Add(.Tools_MenuHeader1) ''Added 12/12/2021 
            End If ''End of ""If (boolAddHeaders) Then""

        End With ''End of ""With mod_menuCacheNonShared""

        Dim bool_addExtraHeadersToContextMenus As Boolean ''Added 12/13/2021 td
        ''Dec.28 2021 td ''bool_addExtraHeadersToContextMenus = AddExtraHeadersToolStripMenuItem.Checked
        ''May 6, 2022 td ''bool_addExtraHeadersToContextMenus = mc_AddExtraHeadersForContextMenuStrip
        bool_addExtraHeadersToContextMenus = (mc_AddExtraHeadersForContextMenuStrip And boolAddHeaders)

        ''Added header items. 
        If (bool_addExtraHeadersToContextMenus) Then

            ''Added 12/13/2021 
            ''Dec28 2021''ContextMenuStrip1.Items.Add(MenuCache_Generic.Tools_MenuHeader2) ''Added 12/12/2021 
            ''Dec28 2021''ContextMenuStrip1.Items.Add(MenuCache_Generic.Tools_MenuHeader3) ''Added 12/13/2021
            With mod_menuCacheNonShared
                ContextMenuStrip1.Items.Add(.Tools_MenuHeader2) ''Added 12/12/2021 
                ContextMenuStrip1.Items.Add(.Tools_MenuHeader3) ''Added 12/13/2021 
            End With

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

        If (bool_addExtraHeadersToContextMenus) Then ''Added 5/06/2022
            With mod_menuCacheNonShared.Tools_MenuHeader1
                ''Dim objHeader1 As ToolStripItem = MenuCache_ElemFlds.Tools_MenuHeader1
                ''Dec28 2021 td''.Text = String.Format(.Tag.ToString(), par_control.FieldInfo.FieldLabelCaption,
                ''Dec28 2021 td''          par_control.FieldInfo.CIBadgeField)
                .Text = String.Format(.Tag.ToString(), Me.Name, "[CI Badge Field is n/a]")
            End With ''End of "With mod_menuCacheNonShared.Tools_MenuHeader1"
        End If ''End of ""If (bool_addExtraHeadersToContextMenus) Then""

        ''Added 12/13/2021 td
        ''  Change the text "Context-Menu for Control: {0}" to "Context-Menu for Control: ....".
        ''
        ''Dec28 2021 td''With MenuCache_Generic.Tools_MenuHeader0
        If (bool_addExtraHeadersToContextMenus) Then ''Added 5/06/2022
            With mod_menuCacheNonShared.Tools_MenuHeader0
                ''Dec28 2021''.Text = String.Format(.Tag.ToString(), par_control.Name)
                .Text = String.Format(.Tag.ToString(), Me.Name)
            End With ''End of "With MenuCache_ElemFlds.Tools_MenuHeader0"
        End If ''End of ""If (bool_addExtraHeadersToContextMenus) Then""

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
        ''Unused. 8/14/2022 ''Const c_intRandom As Integer = 5
        With objDisplayMenu

            Dim objParentControl As Control ''Added 1/15/2022
            ''Jan15 2022''objParentControl = Me.Container ''Added 1/15/2022 td
            objParentControl = Me.ParentControl ''Added 1/15/2022 td

            ''Jan15 2022 td''.ShowContextMenu()
            .ShowContextMenu(par_intX + 20 + Me.ParentDesignerForm.Left,
                             par_intY + 50 + Me.ParentDesignerForm.Top)

            ''If (c_intRandom = 1) Then .ContextMenuDisplay(objParentControl, New Point(par_intX, par_intY))
            ''If (c_intRandom = 2) Then .ContextMenuOpen(objParentControl, New Point(par_intX, par_intY))
            ''If (c_intRandom = 3) Then .ContextMenuShow(objParentControl, New Point(par_intX, par_intY))
            ''If (c_intRandom = 4) Then .DisplayContextMenu(objParentControl, New Point(par_intX, par_intY))
            ''If (c_intRandom = 5) Then .DisplayPopupMenu(objParentControl, New Point(par_intX, par_intY))
            ''If (c_intRandom = 6) Then .DisplayRightclickMenu(objParentControl, New Point(par_intX, par_intY))
            ''If (c_intRandom = 7) Then .OpenContextMenu(objParentControl, New Point(par_intX, par_intY))
            ''If (c_intRandom = 8) Then .OpenPopupMenu(objParentControl, New Point(par_intX, par_intY))
            ''If (c_intRandom = 9) Then .OpenRightclickMenu(objParentControl, New Point(par_intX, par_intY))

        End With ''End of "With objDisplayMenu"

    End Sub ''End of Private Sub mod_designer_ElementRightClicked(par_intX As Integer, par_intY As Integer)


End Class
