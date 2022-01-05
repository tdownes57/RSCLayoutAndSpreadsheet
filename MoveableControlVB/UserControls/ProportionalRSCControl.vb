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
    ''Jan4 2022 ''Public EventsSingleton As GroupMoveEvents_Singleton

    Public WithEvents MyTimerOneSecond As Timer ''Added 1/4/2022 td 
    Private mod_runSaveToModel_1secAgo As Boolean ''Added 1/4/2022 td

    Public Shared Function GetRSCControl() As ProportionalRSCControl
        ''
        ''Added 1/4/2022 thomas downes 
        ''
        Dim ctlRSC As ProportionalRSCControl

        ctlRSC = New ProportionalRSCControl()
        Return ctlRSC

    End Function ''End of "Public Shared Function GetRSCControl() As ProportionalRSCControl"


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

        ''Jan4 2022 ''If (MyBase.mod_events Is Nothing) Then MyBase.mod_events = Me.EventsSingleton
        If (MyBase.mod_events Is Nothing) Then MyBase.mod_events = Me.MoveabilityEvents

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
        ''--MyBase.SaveToModel()

        ''--MessageBoxTD.Show_Statement("SaveToModel(). Programmer must override this base-class method, using the keyword Overrides.")

        If (Not mod_runSaveToModel_1secAgo) Then
            mod_runSaveToModel_1secAgo = True
            ''MessageBoxTD.Show_Statement("SaveToModel() is executed.")
            lblSavedCount.Tag = CInt(lblSavedCount.Tag) + 1
            lblSavedCount.Text = ("Saved count: " & lblSavedCount.Tag.ToString())

        End If ''End of If (Not mod_runSaveToModel_1secAgo) Then

    End Sub

    Private Sub MyTimerOneSecond_Tick(sender As Object, e As EventArgs) Handles MyTimerOneSecond.Tick

        ''Added 1/4/2022 td
        mod_runSaveToModel_1secAgo = False ''Refresh. 

    End Sub
End Class
