Public Class Operations__Useless
    Implements ICurrentElement ''Added 12/28/2021 td
    ''
    ''Added 12/28/2021 thomas downes
    ''
    ''Dec28 2021''Public Property CtlCurrentElement As MoveableControlVB ''Dec28 2021''ciBadgeDesigner.CtlGraphicFldLabel ''CtlGraphicFldLabel
    ''Added 12/28/2021 td
    Public Property CtlCurrentElement As MoveableControlVB Implements ICurrentElement.CtlCurrentElement

    Public Sub New()
        ''
        ''Added 12/28/2021 td
        ''
        ''Dec.28 2021''---Me.CtlCurrentElement = par_currentControlVB

    End Sub ''End of "Public Sub New()"

    Public Sub New(par_currentControlVB As MoveableControlVB)
        ''
        ''Added 12/28/2021 td
        ''
        Me.CtlCurrentElement = par_currentControlVB

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
        CtlCurrentElement.AddMoveability()

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


    Public Sub RightClickability_Remove_GU87007(sender As Object, e As EventArgs)
        ''
        ''Added 12/28/2021 thomas downes  
        ''
        CtlCurrentElement.RemoveClickability()

    End Sub




End Class
