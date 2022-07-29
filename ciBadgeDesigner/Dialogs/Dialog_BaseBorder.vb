Imports __RSCWindowsControlLibrary ''Added 7/29/2022 td 
''
''Added 5/31/2022
''
Public Class Dialog_BaseBorder

    Public Sub New(par_controlFieldOrTextV4 As CtlGraphicFieldOrTextV4,
                   par_elementBase As ciBadgeElements.ClassElementBase)
        ''
        ''Added 5/31/2022 td 
        ''
        ''7/28/2022''MyBase.PanelDisplayElement.Controls.Add(par_controlFieldOrTextV4)
        ''7/29/2022''MyBase.New(par_controlFieldOrTextV4)
        MyBase.New(par_controlFieldOrTextV4, par_elementBase)


    End Sub


    Public Sub New(par_controlRSC As __RSCWindowsControlLibrary.RSCMoveableControlVB,
                   par_elementBase As ciBadgeElements.ClassElementBase)
        ''
        ''Added 5/31/2022 td 
        ''
        MyBase.New(par_controlRSC, par_elementBase)


    End Sub



    Private Sub Dialog_BaseBorder_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class