Option Explicit On
Option Strict On

Imports ciBadgeElements ''Added 8/01/2022 thomas downes
''
''Added 5/31/2022 thomas downes  
''
Public Class Dialog_BaseReviseText
    ''
    ''Added 5/31/2022 thomas downes  
    ''
    Public Sub New(par_controlFieldOrTextV4 As CtlGraphicFieldOrTextV4,
                   par_elementBase As classelementbase)
        ''
        ''Added 5/31/2022 td 
        ''
        ''7/28/2022''MyBase.PanelDisplayElement.Controls.Add(par_controlFieldOrTextV4)
        ''8/01/2022''MyBase.New(par_controlFieldOrTextV4)
        MyBase.New(par_controlFieldOrTextV4, par_elementBase)

        ' This call is required by the designer.
        InitializeComponent()

    End Sub





End Class