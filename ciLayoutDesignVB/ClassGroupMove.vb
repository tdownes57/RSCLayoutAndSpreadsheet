''
'' <summary>
''
''  Added 8/3/2019 thomas downes
''
'' </summary>

Imports MoveAndResizeControls_Monem

Public Class ClassGroupMove
    Implements InterfaceEvents

    ''Added 8/3/2019 thomas downes
    Public Event MoveInUnison(deltaLeft As Integer, deltaTop As Integer, deltaWidth As Integer, deltaHeight As Integer)

    ''Added 8/3/2019 thomas downes
    Public Event Resizing_Start()
    Public Event Resizing_End()

    Public ParentLayoutForm As FormDesignProtoTwo ''Added 8/4/2019

    Public Sub New(par_form As FormDesignProtoTwo)

        ''Added 8/4/2019 td  
        ParentLayoutForm = par_form

    End Sub

    Public Sub Resizing_Initiate() Implements InterfaceEvents.Resizing_Initiate

        ''Added 8/4/2019 td  
        RaiseEvent Resizing_Start()

    End Sub

    Public Sub GroupMove_Change(deltaLeft As Integer, deltaTop As Integer, deltaWidth As Integer, deltaHeight As Integer) _
        Implements InterfaceEvents.GroupMove_Change

        ''
        ''Added 8/3/2019 td
        ''
        If (deltaHeight > 20 Or deltaHeight < -20) Then
            System.Diagnostics.Debugger.Break()
        End If

        RaiseEvent MoveInUnison(deltaLeft, deltaTop, deltaWidth, deltaHeight)

    End Sub ''End of "Public Sub GroupMove_Change"

    Public Sub ControlBeingMoved(par_control As Control) Implements InterfaceEvents.ControlBeingMoved
        ''
        ''Added 8/4/2019 td
        ''
        ParentLayoutForm.ControlBeingMoved = par_control

    End Sub

    Public Sub Resizing_Terminate() Implements InterfaceEvents.Resizing_Terminate

        ''Added 8/4/2019 td  
        RaiseEvent Resizing_End()

    End Sub


End Class
