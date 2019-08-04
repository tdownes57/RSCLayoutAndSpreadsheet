''
'' <summary>
''
''  Added 8/3/2019 thomas downes
''
'' </summary>

Imports MoveAndResizeControls_Monem

Public Class ClassGroupMove
    Implements InterfaceEvents

    Public Event MoveInUnison(deltaLeft As Integer, deltaTop As Integer, deltaWidth As Integer, deltaHeight As Integer)

    Public ParentLayoutForm As FormDesignProtoTwo ''Added 8/4/2019

    Public Sub New(par_form As FormDesignProtoTwo)

        ''Added 8/4/2019 td  
        ParentLayoutForm = par_form

    End Sub

    Public Sub GroupMove(deltaLeft As Integer, deltaTop As Integer, deltaWidth As Integer, deltaHeight As Integer) _
        Implements InterfaceEvents.GroupMove

        ''
        ''Added 8/3/2019 td
        ''
        RaiseEvent MoveInUnison(deltaLeft, deltaTop, deltaWidth, deltaHeight)

    End Sub

    Public Sub ControlBeingMoved(par_control As Control) Implements InterfaceEvents.ControlBeingMoved
        ''
        ''Added 8/4/2019 td
        ''
        ParentLayoutForm.ControlBeingMoved = par_control

    End Sub


End Class
