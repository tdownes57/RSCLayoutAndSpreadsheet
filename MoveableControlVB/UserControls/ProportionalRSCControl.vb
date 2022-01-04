Option Explicit On ''Added 1/4/2022 thomas downes
Option Strict On ''Added 1/4/2022 thomas downes
''
''Added 1/3/2022 thomas downes
''
Imports __RSCWindowsControlLibrary ''Added 1/04/2022 td
Imports ciBadgeInterfaces ''Added 1/04/2022 td

Public Class ProportionalRSCControl
    ''
    ''Added 1/3/2022 thomas downes
    ''
    Public EventsSingleton As GroupMoveEvents_Singleton

    Private Sub ProportionalRSCControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 1/3/2022 thomas downes
        ''
        Const c_RemoveMoveability_Full As Boolean = True
        Const c_RemoveMoveability_Partial As Boolean = False
        MyBase.RemoveMoveability(c_RemoveMoveability_Partial)

        ''AddHandler Label1.MouseClick, Me.MouseClick
        ''MyBase.AddMoveability(mod_)
        ''MyBase.AddMoveability_ViaLabel(Label1)

        If (MyBase.mod_events Is Nothing) Then MyBase.mod_events = Me.EventsSingleton

        MyBase.AddMoveability(MyBase.mod_events, MyBase.mod_iLayoutFunctions, True)

    End Sub


    Public Sub AddMoveability_ViaLabel()
        ''
        ''Added 1/4/2022 td 
        ''
        MyBase.AddMoveability_ViaLabel(Label1)

    End Sub


    Public Overrides Sub SaveToModel()
        ''Added 1/4/2022 td 

        ''MyBase.SaveToModel()
        If (False) Then MyBase.SaveToModel()
        MyBase.SaveToModel()

    End Sub


End Class
