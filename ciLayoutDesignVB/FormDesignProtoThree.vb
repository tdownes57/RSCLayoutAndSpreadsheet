Option Explicit On
Option Infer Off
Option Strict On

''
''Added 10/01/2019 Thomas DOWNES
''
Imports ciBadgeDesigner
Imports ciBadgeInterfaces
Imports ciBadgeElements
Imports ciBadgeCachePersonality ''Added 12/4/2021 td 

Public Class FormDesignProtoThree
    ''
    ''Added 10/01/2019 Thomas DOWNES
    ''
    Public Property ElementsCache_Saved As New ClassElementsCache_Deprecated ''Added 9/16/2019 thomas downes
    Public Property ElementsCache_Edits As New ClassElementsCache_Deprecated ''Added 9/16/2019 thomas downes

    Private WithEvents mod_designer As ClassDesigner
    Private mod_eventsSingleton As New GroupMoveEvents_Singleton ''Added 1/5/2022 td

    Private Sub FormDesignProtoThree_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 10/1/2019 td
        ''
        mod_designer = New ClassDesigner

        With mod_designer

            .BackgroundBox_Front = Me.pictureBack
            .PreviewBox = Me.picturePreview
            .DesignerForm = Me
            .FlowFieldsNotListed = Me.flowFieldsNotListed
            .CheckboxAutoPreview = Me.checkAutoPreview

            ''10/1/2019''intPicLeft = CtlGraphicPortrait_Lady.Left - pictureBack.Left
            ''10/1/2019''intPicTop = CtlGraphicPortrait_Lady.Top - pictureBack.Top
            ''10/1/2019''intPicWidth = CtlGraphicPortrait_Lady.Width
            ''10/1/2019''intPicHeight = CtlGraphicPortrait_Lady.Height

            .Initial_Pic_Left = .Layout_Margin_Left_Omit(Me.CtlGraphicPortrait_Lady.Left)
            .Initial_Pic_Top = .Layout_Margin_Top_Omit(Me.CtlGraphicPortrait_Lady.Top)
            .Initial_Pic_Width = Me.CtlGraphicPortrait_Lady.Width
            .Initial_Pic_Height = Me.CtlGraphicPortrait_Lady.Height

            ''11/28/2021''.LoadDesigner()
            '' 1/02/2022'' .LoadDesigner("FormDesignProtoThree's Form_Load ")
            ''5/4/2022 td''.LoadDesigner("FormDesignProtoThree's Form_Load ", mod_eventsSingleton)

            Dim bAutoLoadBackImg As Boolean ''Added 5/23/2022 td
            Dim bAutoLoadElems As Boolean ''Added 5/4/2022 td

            bAutoLoadBackImg = Startup.PreloadBackgroundForDemo ''Added 5/23/2022 td
            bAutoLoadElems = Startup.PreloadElementsForDemo ''Added 5/4/2022 td

            ''5/23/2022 .LoadDesigner("FormDesignProtoThree's Form_Load ", bAutoLoadElems, mod_eventsSingleton)
            .LoadDesigner("FormDesignProtoThree's Form_Load ",
                          bAutoLoadBackImg, bAutoLoadElems, mod_eventsSingleton)

        End With ''End of "With mod_designer"

    End Sub

    Private Sub mod_designer_ElementRightClicked(par_control As ciBadgeDesigner.CtlGraphicFieldV3) Handles mod_designer.ElementFieldRightClicked
        ''
        ''Added 10/1/2019 td
        ''
        FlowMenu.Visible = True

        ''5/2022 MessageBox.Show(par_control.ElementClass_ObjV3.FieldInfo.CIBadgeField, "",
        ''5/2022      MessageBoxButtons.OK, MessageBoxIcon.Information)
        MessageBoxTD.Show_Statement("The right-clicked  element is for the field...",
                                    par_control.ElementClass_ObjV3.FieldNm_CaptionText())

    End Sub
End Class