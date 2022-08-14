''
''Added 5/31/2022 thomas downes  
''
Imports ciBadgeElements ''Added 8/1/2022 thomas downes
Imports ciBadgeInterfaces ''Added 8/04/2022

Public Class Dialog_BaseEditElement
    ''
    ''Added 5/31/2022 thomas downes  
    ''
    Public Sub New(par_controlFieldOrTextV4 As CtlGraphicFieldOrTextV4,
                   par_listFontFamilyNames As HashSet(Of String),
                   par_listRSCColors As HashSet(Of RSCColor),
                   par_elementBase As ClassElementBase,
                   par_infoElemBase As IElement_Base,
                   par_designer As ClassDesigner,
                   par_events As GroupMoveEvents_Singleton,
                   Optional par_imageOfBadge As Drawing.Image = Nothing)
        ''
        ''Added 5/31/2022 td 
        ''
        ''7/28/2022''MyBase.PanelDisplayElement.Controls.Add(par_controlFieldOrTextV4)
        ''8/01/2022 MyBase.New(par_controlFieldOrTextV4, par_elementBase)
        ''8/04/2022 MyBase.New(par_controlFieldOrTextV4,
        ''           par_elementBase, par_imageOfBadge)
        MyBase.New(par_controlFieldOrTextV4,
                   par_listFontFamilyNames,
                   par_listRSCColors,
                   par_elementBase, par_infoElemBase,
                   par_designer, par_events,
                   par_imageOfBadge)

        ' This call is required by the designer.
        InitializeComponent()

    End Sub


    Private Sub Dialog_BaseEditElement_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

End Class