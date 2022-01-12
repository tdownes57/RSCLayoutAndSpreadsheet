Option Explicit On ''Added 1/4/2022 thomas downes
Option Strict On ''Added 1/4/2022 thomas downes
''
''Added 1/3/2022 thomas downes
''
Imports __RSCWindowsControlLibrary ''Added 1/04/2022 td
Imports ciBadgeInterfaces ''Added 1/04/2022 td

Public Class SimpleChildOfRSCControl2

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Public Sub New(par_iLayoutFunctions As ILayoutFunctions,
                   par_eventsForGroupedControls As GroupMoveEvents_Singleton,
                   par_iLastControlTouched As ILastControlTouched)
        ''
        ''Added 1/4/2022 thomas downes 
        ''
        ' This call is required by the designer.
        InitializeComponent()

        mod_iLayoutFunctions = par_iLayoutFunctions
        ''Jan11 ''mod_events = par_events
        Me.LastControlTouched_Info = par_iLastControlTouched

        ''Added Jan11 2022
        mod_eventsForGroupMove_NotNeeded = par_eventsForGroupedControls

        ''Added Jan11 2022
        mod_eventsForSingleMove = New GroupMoveEvents_Singleton(par_iLayoutFunctions, True)


    End Sub


    Public Shared Function GetRSCControl(par_iLayoutFunctions As ILayoutFunctions,
                                         par_events As GroupMoveEvents_Singleton,
                                         par_iLastControlTouched As ILastControlTouched) As SimpleChildOfRSCControl2
        ''
        ''Added 1/4/2022 thomas downes 
        ''
        Dim ctlRSC As SimpleChildOfRSCControl2

        ctlRSC = New SimpleChildOfRSCControl2(par_iLayoutFunctions, par_events, par_iLastControlTouched)
        Return ctlRSC

    End Function ''End of "Public Shared Function GetRSCControl() As ProportionalRSCControl"



    Private Sub SimpleChildOfRSCControl2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 1/3/2022 thomas downes
        ''
        Const c_RemoveMoveability_Full As Boolean = True
        Const c_RemoveMoveability_Partial As Boolean = False
        MyBase.RemoveMoveability(c_RemoveMoveability_Partial)

        ''AddHandler Label1.MouseClick, Me.MouseClick
        ''MyBase.AddMoveability(mod_)
        ''MyBase.AddMoveability_ViaLabel(Label1)

        ''Jan4 2022 ''If (MyBase.mod_events Is Nothing) Then MyBase.mod_events = Me.EventsSingleton
        If (MyBase.mod_eventsForSingleMove Is Nothing) Then
            ''Unlikely to have any positive effect. ---Jan11 2022
            MyBase.mod_eventsForSingleMove = Me.MoveabilityEventsForSingleMove
        End If

        ''Added 1/11/2022 td
        If (MyBase.mod_eventsForSingleMove Is Nothing) Then
            ''Added 1/11/2022 td
            mod_eventsForSingleMove = New GroupMoveEvents_Singleton(MyBase.mod_iLayoutFunctions, True)
        End If

        If (MyBase.mod_eventsForGroupMove_NotNeeded Is Nothing) Then
            ''Unlikely to have any positive effect. ---Jan11 2022
            MyBase.mod_eventsForGroupMove_NotNeeded = Me.MoveabilityEventsForGroupCtls
        End If

        ''Jan11 2022 ''MyBase.AddMoveability(MyBase.mod_events, MyBase.mod_iLayoutFunctions, True)
        MyBase.AddMoveability(MyBase.mod_iLayoutFunctions,
                              mod_eventsForGroupMove_NotNeeded,
                              mod_eventsForSingleMove)

        ''Added 1/4/2022
        ''---lblSavedCount.Tag = 0 '' "0"

    End Sub

    Public Overrides Sub SaveToModel()
        ''Added 1/4/2022 td 

        ''MyBase.SaveToModel()

    End Sub


    Public Overrides Sub RemoveMouseEventHandlers_ChildClass()
        ''
        ''Added 1/12/2022 
        ''
        ''RemoveHandler pictureLabel.MouseDown, AddressOf pictureLabel_MouseDown
        ''RemoveHandler pictureLabel.MouseMove, AddressOf pictureLabel_MouseMove
        ''RemoveHandler pictureLabel.MouseUp, AddressOf pictureLabel_MouseUp

    End Sub ''End of "Public Overrides Sub RemoveMouseEventHandlers()"


    Public Overrides Sub AddMouseEventHandlers_ChildClass()
        ''
        ''Added 1/12/2022 
        ''
        ''RemoveHandler pictureLabel.MouseDown, AddressOf pictureLabel_MouseDown
        ''RemoveHandler pictureLabel.MouseMove, AddressOf pictureLabel_MouseMove
        ''RemoveHandler pictureLabel.MouseUp, AddressOf pictureLabel_MouseUp

        ''AddHandler pictureLabel.MouseDown, AddressOf pictureLabel_MouseDown
        ''AddHandler pictureLabel.MouseMove, AddressOf pictureLabel_MouseMove
        ''AddHandler pictureLabel.MouseUp, AddressOf pictureLabel_MouseUp

    End Sub ''End of "Public Overrides Sub AddMouseEventHandlers()"

End Class
