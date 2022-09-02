Option Explicit On ''Added 12/17/2021 
Option Strict On ''Added 12/17/2021
''
'' <summary>
''GroupMoveEvents_Singleton
''  Added 8/3/2019 thomas downes
''
'' </summary>

Imports MoveAndResizeControls_Monem
Imports ciBadgeInterfaces ''Added 9/20/2019 td  
Imports System.Windows.Forms ''Added 1/3/2022 td 

Public Class GroupMoveEvents_Singleton
    Implements InterfaceMoveEvents
    ''Jan3 2022 ''Implements InterfaceEvents

    Public Shared CountInstances As Integer ''Added 1/3/2022 thomas downes

    ''Added 8/3/2019 thomas downes
    ''Modified 1/12/2022 thomas downes
    Public Event MoveInUnison(deltaLeft As Integer, deltaTop As Integer, deltaWidth As Integer, deltaHeight As Integer, pbLocationOfLeadControlIsEdited As Boolean)

    ''Added 8/3/2019 thomas downes
    Public Event Resizing_Start()

    ''12/17/2021 td''Public Event Resizing_End()
    Public Event Resizing_EndV1(par_iSave As ISaveToModel)

    ''Added 1/26/2022 td
    ''June6 2022 Public Event Resizing_EndV2(par_iSave As ISaveToModel,
    ''                          par_iRefreshElement As IRefreshElementImage,
    ''                          par_iRefreshCardPreview As IRefreshCardPreview)
    Public Event Resizing_EndV2(par_iSave As ISaveToModel,
                              par_iRefreshElement As IRefreshElementImage,
                              par_iRefreshCardPreview As IRefreshCardPreview,
                              par_bHeightResized As Boolean)

    ''11/29/2021 td''Public Event Moving_End() ''Added 9/13/2019 td  
    Public Event Moving_End(par_control As Control, par_iSaveToModel As ISaveToModel) ''Added 9/13/2019 td  

    ''Added 12/2/2021 Thomas Downes
    Public Event Moving_InProgress(par_control As Control) ''Added 12/02/2021 td

    ''Added 12/6/2021 thomas d. 
    Public Event ControlIsMoving()

    ''Added 8/31/2021 thomas d. 
    Public Event ControlWasClicked(par_control As Control)

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

    Public Sub New(par_layoutFun As ILayoutFunctions,
                   Optional pboolAutomatedSingleMovement As Boolean = False,
                   Optional pbEventkillingBlackhole As Boolean = False)
        ''
        ''Added 9/20/2019 td  
        ''
        ''Blackhole = Events disappear without effect = Elements cannot be moved.
        ''
        LayoutFunctions = CType(par_layoutFun, ILayoutFunctions)

        ''Blackhole = Events disappear without effect = Elements cannot be moved.
        ''
        Dim bYesToNewBlackhole As Boolean ''Added 1/3/2022 td
        Dim bPleaseNoBlackholes As Boolean ''Added 1/3/2022 td

        ''Blackhole = Events disappear without effect = Elements cannot be moved.
        ''
        bYesToNewBlackhole = pbEventkillingBlackhole ''Added 1/3/2022 td
        bPleaseNoBlackholes = (Not bYesToNewBlackhole) ''Added 1/3/2022 td

        If (pboolAutomatedSingleMovement) Then
            ''
            ''We are allowing the single control to move autonomously, to operate under
            ''  its own power; & not as part of a group of selected controls.  ---1/11/2022 td
            ''

        ElseIf (bPleaseNoBlackholes) Then
            CountInstances += 1 ''Added 1/3/2022 thomas downes
            If (CountInstances > 1) Then
                ''Added 1/3/2022 td
                Throw New Exception("This class has been instantiated already. " +
                                    "More than one instance is dangerous.... " +
                                    " it creates an event black hole!")
            End If ''end of "If (CountInstantiation > 1) Then"
        End If ''End of "If (bPleaseNoBlackholes) Then"

    End Sub

    Public Sub New() ''9/9 td''New(par_form As FormDesignProtoTwo)

        ''Added 9/9/2019 td  
        ''9/9 td''ParentLayoutForm = par_form

        Throw New Exception("This parameterless constructor is dangerous.... It creates an event black hole!")

    End Sub

    Public Sub Resizing_Initiate() Implements InterfaceMoveEvents.Resizing_Initiate

        ''Added 8/4/2019 td  
        RaiseEvent Resizing_Start()

    End Sub


    Public Sub GroupMove_Change(deltaLeft As Integer, deltaTop As Integer, deltaWidth As Integer, deltaHeight As Integer, pbLeadControlLocationEditedAlready As Boolean) _
        Implements InterfaceMoveEvents.GroupMove_Change

        ''
        ''Added 8/3/2019 td
        ''
        If (deltaHeight > 20 Or deltaHeight < -20) Then
            ''System.Diagnostics.Debugger.Break()
        End If

        ''1/12/2022 td ''RaiseEvent MoveInUnison(deltaLeft, deltaTop, deltaWidth, deltaHeight)
        RaiseEvent MoveInUnison(deltaLeft, deltaTop, deltaWidth, deltaHeight,
               pbLeadControlLocationEditedAlready)

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


    Public Sub Control_WasClicked(par_control As Control) Implements InterfaceMoveEvents.Control_WasClicked
        ''
        ''Added 8/31/2022 td
        ''
        RaiseEvent ControlWasClicked(par_control)

    End Sub


    Public Sub Resizing_TerminateV1(par_iSave As ISaveToModel) Implements InterfaceMoveEvents.Resizing_TerminateV1

        ''Dec17 2021''Public Sub Resizing_Terminate()
        ''Dec17 2021''     Implements InterfaceEvents.Resizing_Terminate
        ''Jan26 2022''Public Sub Resizing_Terminate(par_iSave As ISaveToModel)

        ''Added 8/4/2019 td  
        ''Dec17 2021''RaiseEvent Resizing_End()
        ''#1 Jan26 2022''RaiseEvent Resizing_End(par_iSave)
        ''#2 Jan26 2022''RaiseEvent Resizing_End(par_iSave, par_iRefreshElement, par_iRefreshPreview)
        RaiseEvent Resizing_EndV1(par_iSave)

    End Sub ''End of "Public Sub Resizing_TerminateV1"


    Public Sub Resizing_TerminateV2(par_iSave As ISaveToModel,
                                  par_iRefreshElement As IRefreshElementImage,
                                  par_iRefreshPreview As IRefreshCardPreview,
                                  pbResizedElementHeight As Boolean) _
                                  Implements InterfaceMoveEvents.Resizing_TerminateV2

        ''Dec17 2021''Public Sub Resizing_Terminate()
        ''Dec17 2021''     Implements InterfaceEvents.Resizing_Terminate
        ''Jan26 2022''Public Sub Resizing_Terminate(par_iSave As ISaveToModel) Implements InterfaceMoveEvents.Resizing_Terminate

        ''Added 8/4/2019 td  
        ''Dec17 2021''RaiseEvent Resizing_End()
        ''Jan26 2022''RaiseEvent Resizing_End(par_iSave)
        ''June6 2022''RaiseEvent Resizing_EndV2(par_iSave, par_iRefreshElement, par_iRefreshPreview)
        RaiseEvent Resizing_EndV2(par_iSave,
                                  par_iRefreshElement,
                                  par_iRefreshPreview,
                                  pbResizedElementHeight)

    End Sub ''End of "Public Sub Resizing_TerminateV1"

    Public Sub Moving_Terminate(par_control As Control, par_iSave As ISaveToModel) Implements InterfaceMoveEvents.Moving_Terminate
        ''Dec17 2021''Public Sub Moving_Terminate(par_control As Control) Implements InterfaceEvents.Moving_Terminate

        ''Added 9/13/2019 td  
        ''11/2/2021 td''RaiseEvent Moving_End()
        ''01/3/2021 td''RaiseEvent Moving_End(par_control)
        RaiseEvent Moving_End(par_control, par_iSave)

    End Sub

End Class
