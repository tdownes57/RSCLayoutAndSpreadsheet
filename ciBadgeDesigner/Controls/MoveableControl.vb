Option Explicit On
Option Strict On

Imports MoveAndResizeControls_Monem ''Added 12/22/2021 td
Imports ciBadgeInterfaces ''Added 12/22/2021 td
Imports windows.Forms ''Added 12/22/2021
''
''Added 12/22/2021 td  
''
Public Class MoveableControl
    ''
    ''Added 12/22/2021 td  
    ''
    Private mod_resizingProportionally As ControlResizeProportionally_TD
    Private mod_movingInAGroup As ControlMove_Group_NonStatic
    Private mod_boolResizeProportionally As Boolean
    Private mod_events As New ClassGroupMoveEvents ''InterfaceEvents
    Private mod_iSave As iSaveToModel

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(pboolResizeProportionally As Boolean, par_iSaveToModel As ISaveToModel)
        ' This call is required by the designer.
        InitializeComponent()

        ''Encapsulated 12/22/2021 thomas downes
        InitializeMoveability(pboolResizeProportionally, par_iSaveToModel)

        ''Encapsulated 12/22/2021 thomas downes
        InitializeClickability()

    End Sub

    Private Sub InitializeMoveability(pboolResizeProportionally As Boolean, par_iSaveToModel As ISaveToModel)
        ''
        ''Added 12/22/2021 thomas downes
        ''
        ' Add any initialization after the InitializeComponent() call.
        mod_boolResizeProportionally = pboolResizeProportionally ''Added 12/22/2021 td
        mod_iSave = par_iSaveToModel
        Const c_bRepaintAfterResize As Boolean = True ''Added 7/31/2019 td

        If pboolResizeProportionally Then

            mod_resizingProportionally = New MoveAndResizeControls_Monem.ControlResizeProportionally_TD()
            mod_resizingProportionally.Init(Me, Me, 10, c_bRepaintAfterResize,
                                            mod_events, False, mod_iSave)

        Else
            mod_movingInAGroup = New MoveAndResizeControls_Monem.ControlMove_Group_NonStatic()
            mod_movingInAGroup.Init(Me, Me, 10, c_bRepaintAfterResize,
                                    mod_events, False, mod_iSave)

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


    Private Sub InitializeClickability()
        ''
        ''Added 12/22/2021 thomas downes
        ''





    End Sub ''End of "Private Sub InitializeClickability()"

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


End Class
