''
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

    ''Added 12/28/2021 td
    Private mod_objOperationsAny As Object ''Added 12/28/2021 td
    Private mod_typeOperations As Type ''Added 12/28/2021 td
    Private mod_enumElementType As EnumElementType ''Added 12/28/2021 td

    ''Added 12/28/2021 td  
    Private mod_menuCacheNonShared As MenuCache_NonShared = Nothing ''New Operations_Generic(Me)
    ''Dec28 2021 td''Private mod_menuCacheUseless As MenuCache_NonShared = Nothing ''New Operations_Useless(Me)
    Private mod_objOperationsGeneric As Operations__Generic = Nothing ''New Operations_Generic(Me)
    Private mod_objOperationsUseless As Operations__Useless = Nothing ''New Operations_Useless(Me)
    Private mod_objOperationsDesktop As Operations__Desktop = Nothing ''Added 1/15/2022 td

    ''    ''Don't expect the Moveability to work, we are sending the events
    ''    ''   into a blackhole!!  ---1/4/2022 td
    ''    Dim dummyLayout As New ClassLayoutFunctions
    ''    Dim oEventkillingBlackhole As New GroupMoveEvents_Singleton(dummyLayout, False, True)
    ''    InitializeClickability(EnumElementType.Undetermined, oEventkillingBlackhole)

    ''End Sub

    Private Sub InitializeClickability()

        ''Jan15 2022 td''Private Sub InitializeClickability(par_enum As EnumElementType,
        ''                  par_moveabilityEvents As GroupMoveEvents_Singleton)
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

        mod_menuCacheNonShared = New MenuCache_NonShared(EnumElementType.__Desktop,
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


    Public Sub ClickableDesktop_MouseUp(par_sender As Object, par_e As MouseEventArgs) ''Handles Me.MouseUp
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

    End Sub ''End of Protected Sub MoveableControl_MouseUp


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

            Dim objParentControl As Control ''Added 1/15/2022
            ''Jan15 2022''objParentControl = Me.Container ''Added 1/15/2022 td
            objParentControl = Me.ParentControl ''Added 1/15/2022 td

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
