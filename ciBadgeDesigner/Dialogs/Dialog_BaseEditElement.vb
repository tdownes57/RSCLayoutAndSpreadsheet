''
''Added 5/31/2022 thomas downes  
''
Imports ciBadgeElements ''Added 8/1/2022 thomas downes

Public Class Dialog_BaseEditElement
    ''
    ''Added 5/31/2022 thomas downes  
    ''
    Public Sub New(par_controlFieldOrTextV4 As CtlGraphicFieldOrTextV4,
                   par_elementBase As classElementBAse)
        ''
        ''Added 5/31/2022 td 
        ''
        ''7/28/2022''MyBase.PanelDisplayElement.Controls.Add(par_controlFieldOrTextV4)
        MyBase.New(par_controlFieldOrTextV4, par_elementBase)

        ' This call is required by the designer.
        InitializeComponent()

    End Sub


    Private Sub Dialog_BaseEditElement_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

End Class