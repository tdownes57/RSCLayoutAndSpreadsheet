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
                   par_events As GroupMoveEvents_Singleton,
                   par_iLastControlTouched As ILastControlTouched)
        ''
        ''Added 1/4/2022 thomas downes 
        ''
        ' This call is required by the designer.
        InitializeComponent()

        mod_iLayoutFunctions = par_iLayoutFunctions
        mod_events = par_events
        Me.LastControlTouched_Info = par_iLastControlTouched

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
        If (MyBase.mod_events Is Nothing) Then MyBase.mod_events = Me.MoveabilityEvents

        MyBase.AddMoveability(MyBase.mod_events, MyBase.mod_iLayoutFunctions, True)

        ''Added 1/4/2022
        ''---lblSavedCount.Tag = 0 '' "0"

    End Sub

    Public Overrides Sub SaveToModel()
        ''Added 1/4/2022 td 

        ''MyBase.SaveToModel()

    End Sub



End Class
