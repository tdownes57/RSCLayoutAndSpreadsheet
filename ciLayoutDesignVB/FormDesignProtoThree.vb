Option Explicit On
Option Infer Off
Option Strict On

''
''Added 10/01/2019 Thomas DOWNES
''
Imports ciBadgeDesigner
Imports ciBadgeInterfaces
Imports ciBadgeElements

Public Class FormDesignProtoThree
    ''
    ''Added 10/01/2019 Thomas DOWNES
    ''
    Public Property ElementsCache_Saved As New ClassElementsCache ''Added 9/16/2019 thomas downes
    Public Property ElementsCache_Edits As New ClassElementsCache ''Added 9/16/2019 thomas downes

    Private WithEvents mod_designer As ClassDesigner

    Private Sub FormDesignProtoThree_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 10/1/2019 td
        ''
        mod_designer = New ClassDesigner

        With mod_designer

            .BackgroundBox = Me.pictureBack
            .PreviewBox = Me.picturePreview
            .DesignerForm = Me
            .FlowFieldsNotListed = Me.flowFieldsNotListed
            .CheckboxAutoPreview = Me.checkAutoPreview

            ''10/1/2019''intPicLeft = CtlGraphicPortrait_Lady.Left - pictureBack.Left
            ''10/1/2019''intPicTop = CtlGraphicPortrait_Lady.Top - pictureBack.Top
            ''10/1/2019''intPicWidth = CtlGraphicPortrait_Lady.Width
            ''10/1/2019''intPicHeight = CtlGraphicPortrait_Lady.Height

            .PicInitialize_Left = .Layout_Margin_Left_Omit(Me.CtlGraphicPortrait_Lady.Left)
            .PicInitialize_Top = .Layout_Margin_Top_Omit(Me.CtlGraphicPortrait_Lady.Top)
            .PicInitialize_Width = Me.CtlGraphicPortrait_Lady.Width
            .PicInitialize_Height = Me.CtlGraphicPortrait_Lady.Height

            .LoadDesigner()

        End With ''End of "With mod_designer"

    End Sub

    Private Sub mod_designer_ElementRightClicked(par_control As ciBadgeDesigner.CtlGraphicFldLabel) Handles mod_designer.ElementRightClicked
        ''
        ''Added 10/1/2019 td
        ''
        FlowMenu.Visible = True

        MessageBox.Show(par_control.ElementClass_Obj.FieldInfo.CIBadgeField, "",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
End Class