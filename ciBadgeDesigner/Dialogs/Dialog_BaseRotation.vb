Option Explicit On ''Added 8/19/2022 td 
Option Strict On ''Added 8/19/2022 td 

Public Class Dialog_BaseRotation
    ''
    ''Added 8/19/2022 td 
    ''
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Public Sub New(par_controlFieldOrTextV4 As CtlGraphicFieldOrTextV4,
                   par_elementBase As ciBadgeElements.ClassElementBase)
        ''
        ''Added 8/19/2022 td 
        ''
        ''7/28/2022''MyBase.PanelDisplayElement.Controls.Add(par_controlFieldOrTextV4)
        ''7/29/2022''MyBase.New(par_controlFieldOrTextV4)
        MyBase.New(par_controlFieldOrTextV4, par_elementBase)


    End Sub


    Public Sub New(par_controlRSC As __RSCWindowsControlLibrary.RSCMoveableControlVB,
                   par_elementBase As ciBadgeElements.ClassElementBase)
        ''
        ''Added 8/19/2022 td 
        ''
        MyBase.New(par_controlRSC, par_elementBase)


    End Sub


End Class