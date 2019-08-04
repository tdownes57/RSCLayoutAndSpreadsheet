''
'' <summary>
''
''  Added 8/3/2019 thomas downes
''
'' </summary>

Imports MoveAndResizeControls_Monem

Public Class ClassGroupMove
    Implements InterfaceEvents

    Public Event MoveInUnison(deltaTop As Integer, deltaLeft As Integer, deltaWidth As Integer, deltaHeight As Integer)

    Public Sub GroupMove(deltaTop As Integer, deltaLeft As Integer, deltaWidth As Integer, deltaHeight As Integer) _
        Implements InterfaceEvents.GroupMove

        ''
        ''Added 8/3/2019 td
        ''
        RaiseEvent MoveInUnison(deltaTop, deltaLeft, deltaWidth, deltaHeight)



    End Sub

End Class
