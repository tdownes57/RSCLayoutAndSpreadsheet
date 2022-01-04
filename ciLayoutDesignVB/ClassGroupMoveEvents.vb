Option Explicit On ''Added 12/17/2021 
Option Strict On ''Added 12/17/2021
''
'' <summary>
''
''  Added 8/3/2019 thomas downes
''
'' </summary>

Imports MoveAndResizeControls_Monem
Imports ciBadgeInterfaces ''Added 9/20/2019 td  

Public Class ClassGroupMoveEvents_NoLongerUsed
    Implements InterfaceMoveEvents

    ''Added 8/3/2019 thomas downes
    Public Event MoveInUnison(deltaLeft As Integer, deltaTop As Integer, deltaWidth As Integer, deltaHeight As Integer)

    ''Added 8/3/2019 thomas downes
    Public Event Resizing_Start()
    ''12/17/2021 td''Public Event Resizing_End()
    Public Event Resizing_End(par_iSave As ISaveToModel)

    ''11/29/2021 td''Public Event Moving_End() ''Added 9/13/2019 td  
    Public Event Moving_End(par_control As Control) ''Added 9/13/2019 td  
    ''Added 12/6/2021 thomas d. 
    Public Event ControlIsMoving()

    ''9/20/2019 td''Public ParentLayoutForm As FormDesignProtoTwo ''Added 8/4/2019
    Public LayoutFunctions As ILayoutFunctions ''Added 9/20/2019 td

    ''----------------------------------10/3/2019 td----------------------------------
    ''Public Sub New(par_form As FormDesignProtoTwo)
    ''
    ''    ''Added 8/4/2019 td  
    ''    ''
    ''    ''9/20/2019 td''ParentLayoutForm = par_form
    ''    LayoutFunctions = CType(par_form, ILayoutFunctions)
    ''
    ''End Sub

    Public Sub New(par_layoutFun As ILayoutFunctions)
        ''
        ''Added 9/20/2019 td  
        ''
        LayoutFunctions = CType(par_layoutFun, ILayoutFunctions)

    End Sub

    Public Sub New() ''9/9 td''New(par_form As FormDesignProtoTwo)

        ''Added 9/9/2019 td  
        ''9/9 td''ParentLayoutForm = par_form

    End Sub

    Public Sub Resizing_Initiate() Implements InterfaceMoveEvents.Resizing_Initiate

        ''Added 8/4/2019 td  
        RaiseEvent Resizing_Start()

    End Sub

    Public Sub GroupMove_Change(deltaLeft As Integer, deltaTop As Integer, deltaWidth As Integer, deltaHeight As Integer) _
        Implements InterfaceMoveEvents.GroupMove_Change

        ''
        ''Added 8/3/2019 td
        ''
        If (deltaHeight > 20 Or deltaHeight < -20) Then
            ''System.Diagnostics.Debugger.Break()
        End If

        RaiseEvent MoveInUnison(deltaLeft, deltaTop, deltaWidth, deltaHeight)

    End Sub ''End of "Public Sub GroupMove_Change"

    Public Sub ControlBeingMoved(par_control As Control) Implements InterfaceMoveEvents.ControlBeingMoved
        ''
        ''Added 8/4/2019 td
        ''
        ''9/20/2019 td''ParentLayoutForm.ControlBeingMoved = par_control
        LayoutFunctions.ControlBeingMoved = par_control

        ''------Added 12/6/2021 td  
        ''----RaiseEvent ControlIsMoving()

    End Sub


    Public Sub Control_IsMoving() Implements InterfaceMoveEvents.Control_IsMoving
        ''
        ''Added 12/6/2021 td
        ''
        RaiseEvent ControlIsMoving()

    End Sub


    Public Sub Resizing_Terminate(par_iSave As ISaveToModel) Implements InterfaceMoveEvents.Resizing_Terminate
        ''Dec17 2021''Public Sub Resizing_Terminate()
        ''Dec17 2021''     Implements InterfaceEvents.Resizing_Terminate

        ''Added 8/4/2019 td  
        ''Dec17 2021''RaiseEvent Resizing_End()
        RaiseEvent Resizing_End(par_iSave)

    End Sub

    Public Sub Moving_Terminate(par_control As Control, par_iSave As ISaveToModel) Implements InterfaceMoveEvents.Moving_Terminate
        ''Dec17 2021''Public Sub Moving_Terminate(par_control As Control) Implements InterfaceEvents.Moving_Terminate

        ''Added 9/13/2019 td  
        ''11/2/2021 td''RaiseEvent Moving_End()
        RaiseEvent Moving_End(par_control)

    End Sub

End Class
