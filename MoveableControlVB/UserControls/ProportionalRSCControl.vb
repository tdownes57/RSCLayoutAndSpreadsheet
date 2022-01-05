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
                                         par_iLastControlTouched As ILastControlTouched) As ProportionalRSCControl
        ''
        ''Added 1/4/2022 thomas downes 
        ''
        Dim ctlRSC As ProportionalRSCControl

        ctlRSC = New ProportionalRSCControl(par_iLayoutFunctions, par_events, par_iLastControlTouched)
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

        ''Added 1/4/2022
        ''---lblSavedCount.Tag = 0 '' "0"

        MyTimerOneSecond = New Timer
        MyTimerOneSecond.Interval = 1000

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

            ''Added 1/4/2022 td 
            If (lblSavedCount Is Nothing) Then
                lblSavedCount = New Label()
                lblSavedCount.Tag = 0
                lblSavedCount.Text = "Saved count:"
                Me.Controls.Add(lblSavedCount)
            End If ''end of "If (lblSavedCount Is Nothing) Then"

            lblSavedCount.Tag = CInt(lblSavedCount.Tag.ToString()) + 1
            lblSavedCount.Text = ("Saved count: " & lblSavedCount.Tag.ToString())
            lblSavedCount.Visible = True
            MyTimerOneSecond.Enabled = True ''Set the timer for one(1) second, to prevent multiple calls to this procedure
            ''   from causing multiple increments of lblSavedCount.Tag. ----1/4/2022 td

        End If ''End of If (Not mod_runSaveToModel_1secAgo) Then

    End Sub

    Private Sub MyTimerOneSecond_Tick(sender As Object, e As EventArgs) Handles MyTimerOneSecond.Tick

        ''Added 1/4/2022 td
        mod_runSaveToModel_1secAgo = False ''Refresh. 
        MyTimerOneSecond.Enabled = False ''Just one iteration!!

    End Sub
End Class
