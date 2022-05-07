''
''Added 1/16/2022 thomas d. 
''
''This components allows & generates a context menu to present to the user when the 
''  ID Card's background (inside the badge outline) is 
''  right-clicked.  ----1/22/2022 td
''
Imports __RSCWindowsControlLibrary ''Added 1/16/2022 thomas d. 
Imports ciBadgeCachePersonality ''Added 1/18/2022 thomas d.
Imports ciBadgeInterfaces ''Added 1/18/2022 thomas d.

Public Class ComponentClickBackground
    ''
    ''Added 1/22/2022 thomas d. 
    ''
    ''This components allows & generates a context menu to present to the user when the 
    ''  ID Card's background (inside the badge outline) is 
    ''  right-clicked.  ----1/22/2022 td
    ''
    Public Property PictureBoxControl As PictureBox ''Added 1/22/2022 

    Public Overrides Sub InitializeClickability(par_formParent As Form,
                                                  par_flowLayoutPanel As FlowLayoutPanel) ''Jan15 2022'' par_designer As ClassDesigner)
        ''
        ''Added 1/15/2022 thomas downes
        ''
        Me.ParentDesignerForm = par_formParent
        Me.MyFlowLayoutPanel = par_flowLayoutPanel ''Added 1/5/2022 td  

        ''InitializeClickability()
        ''AddClickability()

    End Sub ''End of "Public Overridable Sub InitializeClickability"


    Public Sub InitializeFunctionality(par_iDesignerForm As IDesignerForm,
                                                par_formParent As Form,
                                       par_iLayoutFunctions As ILayoutFunctions,
                                       par_objectDesigner As ClassDesigner) ''Jan15 2022'' par_designer As ClassDesigner)
        ''
        ''Added 1/16/2022 td
        ''
        ''Jan22 2022 td''mod_objOperationsDesktop = New Operations_Desktop()
        ''Jan22 2022 td''mod_objOperationsDesktop = New Operations_Background()
        Dim objOperationsBackground As New Operations_Background()

        objOperationsBackground.CtlCurrentPicturebox = Me.PictureBoxControl
        objOperationsBackground.ParentDesignerForm = CType(Me.ParentDesignerForm, IDesignerForm)
        objOperationsBackground.DesignerClass = par_objectDesigner

        mod_objOperationsDesktop = objOperationsBackground ''Added 1/22/2022 thomas d.

        ''Added 1/22/2022 td
        mod_objOperationsDesktop.CtlCurrentControl = Me.PictureBoxControl

        ''----DIFFICULT & CONFUSING----
        ''  Why does it take three(3) lines to assign the .DesignerClass property?
        ''  Answer: Because the property .DesignerClass exists in the child class,
        ''  __NOT__ in the parent class.  The object mod_objOperationsDesktop 
        ''  was declared as the parent type, not the child type.  Plus the syntax
        ''  in VB.NET is less compact than the syntax of C#.  
        ''               ---January 18 2022
        ''
        ''--Jan22 2022--Dim objOperationsDesktop As Operations_Desktop
        ''--Jan22 2022--objOperationsDesktop = CType(mod_objOperationsDesktop, Operations_Desktop)
        ''--Jan22 2022--objOperationsDesktop.DesignerClass = par_objectDesigner
        ''Moved up above.1/22/2022---Dim objOperationsBackground As Operations_Background
        ''--Jan22 2022--objOperationsBackground = CType(mod_objOperationsDesktop, Operations_Background)

        ''--Jan22 2022--mod_objOperationsAny = mod_objOperationsDesktop
        mod_objOperationsAny = objOperationsBackground

        ''--Jan22 2022--mod_menuCacheNonShared = New MenuCache_NonShared(EnumElementType.__Desktop,
        ''--Jan22 2022--                                        mod_objOperationsDesktop.GetType(),
        ''--Jan22 2022--                                        mod_objOperationsDesktop)
        mod_menuCacheNonShared = New MenuCache_ActualInUse(EnumElementType.__Background,
                    objOperationsBackground.GetType(),
                    objOperationsBackground)

        ''Added 1/18/2022 td
        With mod_objOperationsDesktop
            .ParentDesignerForm = par_iDesignerForm
            .ParentForm = par_formParent
            .LayoutFunctions = par_iLayoutFunctions

        End With

    End Sub ''End of "Public Overloads Sub InitializeFunctionality"


    Public Overrides Sub ClickableDesktop_MouseUp(par_sender As Object, par_e As MouseEventArgs) ''Handles Me.MouseUp
        ''
        ''Added 1/4/2022 thomas d.
        ''
        If (par_e.Button = MouseButtons.Right) Then
            ''            ''
            ''  Right-Button click, i.e. a context-menu request by user.          
            ''            ''-----Added 12/28/2021 td
            ''            ''
            ShowContextMenu_ForComponent(par_e.X, par_e.Y)

        End If ''End of "If (mod_bHandleMouseMoveEvents And par_e.Button = MouseButtons.Left) Then"

    End Sub ''End of Public Overridable Sub ClickableDesktop_MouseUp


    Private Sub ShowContextMenu_ForComponent(par_intX As Integer, par_intY As Integer)
        ''
        ''Encapsulated 12/28/2021 td
        ''
        If (MyBase.ContextMenuStrip1 Is Nothing) Then
            ''Added 12/29/2021 thomas downes
            MessageBoxTD.Show_Statement("It's possible that the Right-Click menu has been de-activated.")
            Return
        End If ''end of "If (ContextMenuStrip1 Is Nothing) Then"

        Dim objDisplayMenu As New ClassDisplayContextMenu(MyBase.ContextMenuStrip1)
        Const c_intRandom As Integer = 5
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

    End Sub ''End of Private Sub ShowContextMenu_ForComponent(par_intX As Integer, par_intY As Integer)


    Public Overrides Sub AddClickability()
        ''
        ''Added 1/22/2022 td
        ''
        Init_ForRightClicked()

    End Sub ''End of "Public Sub AddClickability()"


    Private Sub Init_ForRightClicked()
        ''
        ''Copied from RSCClickableDesktop, on 1/22/2022 td 
        ''
        MyBase.ContextMenuStrip1 = New ContextMenuStrip()

        mod_menuCacheNonShared = New MenuCache_ActualInUse(mod_enumElementType,
                 mod_objOperationsAny.GetType(), mod_objOperationsAny)

        mod_menuCacheNonShared.GenerateMenuItems_IfNeeded()

        ContextMenuStrip1.Items.Clear()

        Dim bool_addExtraHeadersToContextMenus As Boolean ''Added 12/13/2021 td
        ''Dec.28 2021 td''bool_addExtraHeadersToContextMenus = AddExtraHeadersToolStripMenuItem.Checked
        bool_addExtraHeadersToContextMenus = mc_AddExtraHeadersForContextMenuStrip

        ''Added header items. 
        If (bool_addExtraHeadersToContextMenus) Then

            ''Add a ToolStripMenuItem which will tell which Field is being displayed 
            ''  on the selected (right-clicked) control. 
            ContextMenuStrip1.Items.Add(mod_menuCacheNonShared.Tools_MenuHeader0) ''Added 12/13/2021 
            ContextMenuStrip1.Items.Add(mod_menuCacheNonShared.Tools_MenuHeader1) ''Added 12/12/2021 

            ContextMenuStrip1.Items.Add(mod_menuCacheNonShared.Tools_MenuHeader2) ''Added 12/12/2021 
            ContextMenuStrip1.Items.Add(mod_menuCacheNonShared.Tools_MenuHeader3) ''Added 12/13/2021 

            Dim objMenuHeader3_1 As New ToolStripMenuItem("Init_RightClicked(...")
            Dim objMenuHeader3_2 As New ToolStripMenuItem("   in module ComponentClickBackground.vb")
            ContextMenuStrip1.Items.Add(objMenuHeader3_1) ''Added 12/13/2021 
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
        If (bool_addExtraHeadersToContextMenus) Then ''Added 5/06/2022 td
            With mod_menuCacheNonShared.Tools_MenuHeader1
                ''Dim objHeader1 As ToolStripItem = MenuCache_ElemFlds.Tools_MenuHeader1
                ''Dec28 2021 td''.Text = String.Format(.Tag.ToString(), par_control.FieldInfo.FieldLabelCaption,
                ''Dec28 2021 td''          par_control.FieldInfo.CIBadgeField)
                .Text = String.Format(.Tag.ToString(), Me.Name, "[CI Badge Field is n/a]")
            End With ''End of "With mod_menuCacheNonShared.Tools_MenuHeader1"
        End If ''End of "If (mod_letsAddExtraHeadersForContextMenus) Then"

        ''Added 12/13/2021 td
        ''  Change the text "Context-Menu for Control: {0}" to "Context-Menu for Control: ....".
        ''
        ''Dec28 2021 td''With MenuCache_Generic.Tools_MenuHeader0
        If (bool_addExtraHeadersToContextMenus) Then ''Added 5/06/2022 td
            With mod_menuCacheNonShared.Tools_MenuHeader0
                ''Dec28 2021''.Text = String.Format(.Tag.ToString(), par_control.Name)
                .Text = String.Format(.Tag.ToString(), Me.Name)
            End With ''End of "With MenuCache_ElemFlds.Tools_MenuHeader0"
        End If ''End of "If (bool_AddExtraHeadersForContextMenus) Then"

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



End Class

