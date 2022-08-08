Option Explicit On ''Added 8/7/2022 Thomas Downes
Option Strict On ''Added 8/7/2022 Thomas Downes
''
''Added 8/7/2022 Thomas Downes  
''
Imports ciBadgeDesigner ''Added 8/7/2022 Thomas Downes
Imports ciBadgeElements ''Added 8/7/2022 Thomas Downes
Imports ciBadgeInterfaces ''Added 8/7/2022 Thomas Downes


Public Class Dialog_BaseChooseFont
    ''----Inherits Dialog_Base ''Added 8/7/2022 Thomas Downes  
    ''
    ''Added 8/7/2022 Thomas Downes  
    ''
    Public Sub New(par_controlFieldOrTextV4 As CtlGraphicFieldOrTextV4,
                   par_elementBase As ClassElementBase,
                   par_infoElemBase As IElement_Base,
                   par_designer As ClassDesigner,
                   par_events As GroupMoveEvents_Singleton,
                   Optional par_imageOfBadge As Drawing.Image = Nothing)
        ''
        ''Added 5/31/2022 td 
        ''
        MyBase.New(par_controlFieldOrTextV4,
                   par_elementBase, par_infoElemBase,
                   par_designer, par_events,
                   par_imageOfBadge)

        ' This call is required by the designer.
        InitializeComponent()

    End Sub

    Private Sub LinkLabelAddFont_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelAddFont.LinkClicked
        ''
        ''Add 8/07/2022 
        ''






    End Sub
End Class