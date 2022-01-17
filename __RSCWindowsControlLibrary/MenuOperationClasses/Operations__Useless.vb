Imports ciBadgeInterfaces ''Added 1/3/2022 td

Public Class Operations__Useless
    Implements ICurrentElement ''Added 12/28/2021 td
    ''
    ''Added 12/28/2021 thomas downes
    ''
    ''Dec28 2021''Public Property CtlCurrentElement As MoveableControlVB ''Dec28 2021''ciBadgeDesigner.CtlGraphicFldLabel ''CtlGraphicFldLabel
    ''Added 12/28/2021 td
    Public Property CtlCurrentElement As RSCMoveableControlVB Implements ICurrentElement.CtlCurrentElement
    Public Property EventsForMoveability_Single As GroupMoveEvents_Singleton ''Suffixed 1/11/2022.  Added 1/3/2022 td 
    Public Property EventsForMoveability_Group As GroupMoveEvents_Singleton ''Suffixed 1/11/2022.  Added 1/3/2022 td 
    Public Property LayoutFunctions As ILayoutFunctions ''Added 1/4/2022 td 

    Public Sub New()
        ''
        ''Added 12/28/2021 td
        ''
        ''Dec.28 2021''---Me.CtlCurrentElement = par_currentControlVB

    End Sub ''End of "Public Sub New()"

    Public Sub New(par_currentControlVB As RSCMoveableControlVB,
                   par_eventsForMoveability_Group As GroupMoveEvents_Singleton,
                   par_eventsForMoveability_Single As GroupMoveEvents_Singleton,
                   par_iLayoutFunctions As ILayoutFunctions)
        ''
        ''Added 12/28/2021 td
        ''
        Me.CtlCurrentElement = par_currentControlVB
        ''Jan11 2022''Me.EventsForMoveability = par_eventsForMoveability ''Added 1/3/2022 td
        Me.EventsForMoveability_Group = par_eventsForMoveability_Group ''Added 1/3/2022 td
        Me.EventsForMoveability_Single = par_eventsForMoveability_Single ''Added 1/3/2022 td
        Me.LayoutFunctions = par_iLayoutFunctions ''Added 1/4/2022 td

    End Sub ''End of "Public Sub New(par_currentControlVB As MoveableControlVB)"

    Public Sub This_Is_A_Useless_Operation_GU8001(sender As Object, e As EventArgs)
        ''
        ''Added 12/28/2021 thomas downes  
        ''

    End Sub


    Public Sub This_Is_A_Useless_Operation_GU8002(sender As Object, e As EventArgs)
        ''
        ''Added 12/28/2021 thomas downes  
        ''

    End Sub


    Public Sub This_Is_A_Useless_Operation_GU8003(sender As Object, e As EventArgs)
        ''
        ''Added 12/28/2021 thomas downes  
        ''

    End Sub


    Public Sub Moveability_Add_GU8004(sender As Object, e As EventArgs)
        ''
        ''Added 12/28/2021 thomas downes  
        ''
        ''1/3/2022 td''CtlCurrentElement.AddMoveability()
        ''1/4/2022 td''CtlCurrentElement.AddMoveability(Me.EventsForMoveability)
        CtlCurrentElement.AddMoveability(Me.EventsForMoveability_Single,
                                         Me.EventsForMoveability_Group,
                                         Me.LayoutFunctions,)

    End Sub


    Public Sub Moveability_Remove_GU8005(sender As Object, e As EventArgs)
        ''
        ''Added 12/28/2021 thomas downes  
        ''
        CtlCurrentElement.RemoveMoveability()

    End Sub


    Public Sub RightClickability_Add_GU8006(sender As Object, e As EventArgs)
        ''
        ''Added 12/28/2021 thomas downes  
        ''
        CtlCurrentElement.AddClickability()

    End Sub


    Public Sub RightClickability_Remove_GU8007(sender As Object, e As EventArgs)
        ''
        ''Added 12/28/2021 thomas downes  
        ''
        CtlCurrentElement.RemoveClickability()

    End Sub


    Public Sub Sizeability_Add_GU8008(sender As Object, e As EventArgs)
        ''
        ''Added 12/28/2021 thomas downes  
        ''
        CtlCurrentElement.AddSizeability()

    End Sub


    Public Sub Sizeability_Remove_GU8009(sender As Object, e As EventArgs)
        ''
        ''Added 12/28/2021 thomas downes  
        ''
        CtlCurrentElement.RemoveSizeability()

    End Sub


    Public Sub Name_Of_This_Control_GU8008(sender As Object, e As EventArgs)
        ''
        ''Added 12/28/2021 thomas downes  
        ''
        MessageBoxTD.Show_Statement("The name of this control is: " & Me.CtlCurrentElement.Name)

    End Sub




End Class
