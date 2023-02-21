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
    '' 2/02/2022 TD ''Public Event Resizing_End(par_iSave As ISaveToModel)
    Public Event Resizing_End_V1(par_iSave As ISaveToModel) ''Renamed 2/2/2022 td

    ''Added 2/2/2022 td
    ''6/6/2022 td''Public Event Resizing_End_V2(par_iSave As ISaveToModel,
    ''                             par_iRefreshElem As IRefreshElementImage,
    ''                             par_iRefreshPrev As IRefreshCardPreview)
    Public Event Resizing_End_V2(par_iSave As ISaveToModel,
                                 par_iRefreshElem As IRefreshElementImage,
                                 par_iRefreshPrev As IRefreshCardPreview,
                                 par_bHeightResized As Boolean)

    ''11/29/2021 td''Public Event Moving_End() ''Added 9/13/2019 td  
    Public Event Moving_End(par_control As Control) ''Added 9/13/2019 td  

    ''Added 12/6/2021 thomas d. 
    Public Event ControlIsMoving()

    ''Added 8/31/2022 thomas d. 
    Public Event ControlWasClicked(par_control As Control)
    ''Added 12/24/2022 thomas d. 
    Public Event MouseDown(par_control As Control)

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

    Public Sub GroupMove_Change(deltaLeft As Integer, deltaTop As Integer,
                                deltaWidth As Integer, deltaHeight As Integer,
                                pbLeadControlLocationWasChanged As Boolean) _
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


    Public Sub MouseUpShiftKey(par_control As Control) Implements InterfaceMoveEvents.MouseUpShiftKey
        ''
        ''Added 2/19/2022
        ''
    End Sub

    Public Sub MouseUpCtrlKey(par_control As Control) Implements InterfaceMoveEvents.MouseUpCtrlKey
        ''
        ''Added 2/19/2022
        ''
    End Sub


    Public Sub Control_IsMoving() Implements InterfaceMoveEvents.Control_IsMoving
        ''
        ''Added 12/6/2021 td
        ''
        RaiseEvent ControlIsMoving()

    End Sub


    Public Sub Control_WasClicked(par_control As Control) Implements InterfaceMoveEvents.Control_WasClicked
        ''
        ''Added 8/31/2022 td
        ''
        ''8/31/2022 td  RaiseEvent ControlWasClicked()
        ''8/31/2022 td  LayoutFunctions.ControlBeingClicked = par_control
        LayoutFunctions.ControlThatWasClicked = par_control
        RaiseEvent ControlWasClicked(par_control)

    End Sub


    Public Sub Control_MouseDown(par_control As Control) Implements InterfaceMoveEvents.MouseDown
        ''
        ''Added 12/24/2022 td
        ''
        LayoutFunctions.ControlThatWasClicked = par_control
        RaiseEvent MouseDown(par_control)

    End Sub


    Public Sub Resizing_TerminateV1(par_iSave As ISaveToModel) Implements InterfaceMoveEvents.Resizing_TerminateV1

        ''Dec17 2021''Public Sub Resizing_Terminate()
        ''Dec17 2021''     Implements InterfaceEvents.Resizing_Terminate
        ''Jan26 2022''Public Sub Resizing_Terminate(par_iSave As ISaveToModel) 

        ''Added 8/4/2019 td  
        ''Dec17 2021''RaiseEvent Resizing_End()
        ''Jan02 2022 td''RaiseEvent Resizing_End(par_iSave)
        RaiseEvent Resizing_End_V1(par_iSave)

    End Sub ''End of "Public Sub Resizing_TerminateV1(....)"


    Public Sub Resizing_TerminateV2(par_iSave As ISaveToModel,
                                              par_iRefreshImage As IRefreshElementImage,
                                              par_iRefreshPreview As IRefreshCardPreview,
                                              par_bResizedHeight As Boolean) _
                                              Implements InterfaceMoveEvents.Resizing_TerminateV2

        ''Dec17 2021''Public Sub Resizing_Terminate()
        ''Dec17 2021''     Implements InterfaceEvents.Resizing_Terminate
        ''Jan26 2022''Public Sub Resizing_Terminate(par_iSave As ISaveToModel) 

        ''Added 8/4/2019 td  
        ''Dec17 2021''RaiseEvent Resizing_End()
        ''Jan02 2022 td''RaiseEvent Resizing_End(par_iSave)

        ''June6 2022 RaiseEvent Resizing_End_V2(par_iSave, par_iRefreshImage, par_iRefreshPreview)
        RaiseEvent Resizing_End_V2(par_iSave,
                                   par_iRefreshImage,
                                   par_iRefreshPreview,
                                   par_bResizedHeight)

    End Sub ''End of "Public Sub Resizing_TerminateV2(....)"


    Public Sub Moving_Terminate(par_control As Control, par_iSave As ISaveToModel) Implements InterfaceMoveEvents.Moving_Terminate
        ''Dec17 2021''Public Sub Moving_Terminate(par_control As Control) Implements InterfaceEvents.Moving_Terminate

        ''Added 9/13/2019 td  
        ''11/2/2021 td''RaiseEvent Moving_End()
        RaiseEvent Moving_End(par_control)

    End Sub

End Class
