Option Explicit On ''Added 8/03/2022 td
Option Strict On ''Added 8/03/2022 td
''
''Added 7/28/2022 Thomas Downes 
''
Imports __RSCWindowsControlLibrary ''Added 7/29/2022 td 
Imports ciBadgeElements ''Added 8/03/2022 td 

Public Class Dialog_Base
    ''
    ''Added 7/28/2022 Thomas Downes 
    ''
    Protected mod_controlFieldOrTextV4 As CtlGraphicFieldOrTextV4
    Protected mod_controlRSCMoveable As RSCMoveableControlVB
    Protected mod_elementBase As ciBadgeElements.ClassElementBase ''Added 7/29/2022 td

    Protected ControlBelongsToPanel As Boolean = False ''Added 7/28/2022 td

    Private mod_bCheckArrowLR As Boolean
    Private mod_enumArrowLeftRight As EnumArrowIsWhere

    Private Enum EnumArrowIsWhere
        Undetermined
        LeftOfElement
        RightOfElement
    End Enum


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

    End Sub


    ''Public Sub New(par_controlFieldOrTextV4 As CtlGraphicFieldOrTextV4,
    ''               par_elementBase As ciBadgeElements.ClassElementBase,
    ''               par_imageOfBadge As Drawing.Image)

    ''    ''Added 7/29/2022 thomas 
    ''    PanelDisplayElement.BackgroundImage = par_imageOfBadge
    ''End Sub


    Public Sub New(par_controlFieldOrTextV4 As CtlGraphicFieldOrTextV4,
                   par_elementBase As ciBadgeElements.ClassElementBase,
                   Optional par_imageOfBadge As Drawing.Image = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mod_controlFieldOrTextV4 = par_controlFieldOrTextV4
        mod_controlRSCMoveable = par_controlFieldOrTextV4 ''Added 7/29/2022 td
        mod_elementBase = par_elementBase ''Added 7/29/2022 thomas d.  

        ''Added 7/29/2022 td
        PanelDisplayElement.BackgroundImage = par_imageOfBadge

        ''Encapsulated 7/29.2022  thomas downes
        PositionElement(mod_controlFieldOrTextV4, mod_elementBase)
        PositionArrow(mod_controlFieldOrTextV4) ''Added 8/03/2022 td

        mod_controlFieldOrTextV4.Visible = True
        mod_controlFieldOrTextV4.BringToFront()

ExitHandler:

        With mod_controlFieldOrTextV4
            ''
            ''Center the control. 
            ''
            If (Me.ControlBelongsToPanel) Then
                .Left = CInt((PanelDisplayElement.Width - .Width) / 2)
                .Top = CInt((PanelDisplayElement.Height - .Height) / 2)

                panelArrowLeft.Top = .Top
                panelArrowLeft.Left = .Left - panelArrowLeft.Width

            End If ''End of ""If (Me.ControlBelongsToPanel) Then""

        End With ''End of ""With mod_controlFieldOrTextV4""

    End Sub ''End of ""Public Sub New"" 


    Public Sub New(par_controlRSCMoveable As RSCMoveableControlVB,
                   par_elementBase As ciBadgeElements.ClassElementBase)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mod_controlRSCMoveable = par_controlRSCMoveable ''Added 7/29/2022 td
        mod_elementBase = par_elementBase ''Added 7/29/2022 thomas d.  

        ''Added 7/29/2022 thomas downes
        ''7/29/2022 td ''With mod_controlFieldOrTextV4
        With mod_controlRSCMoveable
            ''
            ''Add the control to the appropriate Controls collection.
            ''Center the control. 
            ''
            PositionElement(par_controlRSCMoveable, mod_elementBase)
            PositionArrow(par_controlRSCMoveable) ''Added 8/3/2022 td

            ''7/29/2022 If (ControlBelongsToPanel) Then
            ''    ''
            ''    ''Add the control to the panel. Centering will happen at the ExitHandler.
            ''    ''
            ''    ''7/29/2022 Me.PanelDisplayElement.Controls.Add(mod_controlFieldOrTextV4)
            ''    Me.PanelDisplayElement.Controls.Add(mod_controlRSCMoveable)
            ''
            ''7/29/2022 Else
            ''    ''7/29/2022 Me.Controls.Add(mod_controlFieldOrTextV4)
            ''    Me.Controls.Add(mod_controlRSCMoveable)
            ''    ''Center the control within the Panel, even if it doesn't belong to the Panel. 
            ''    .Left = PanelDisplayElement.Left + CInt((PanelDisplayElement.Width - .Width) / 2)
            ''    .Top = PanelDisplayElement.Top + CInt((PanelDisplayElement.Height - .Height) / 2)
            ''    ''Arrow should point to the control
            ''    panelArrow.Top = .Top
            ''    panelArrow.Left = .Left - panelArrow.Width

            ''End If ''End of ""If (ControlBelongsToPanel) Then... Else..."

        End With

        ''7/29/2022 mod_controlFieldOrTextV4.Visible = True
        ''7/29/2022 mod_controlFieldOrTextV4.BringToFront()
        mod_controlRSCMoveable.Visible = True
        mod_controlRSCMoveable.BringToFront()

ExitHandler:

        ''7/29/2022 With mod_controlFieldOrTextV4
        ''With mod_controlRSCMoveable
        ''    ''
        ''    ''Center the control. 
        ''    ''
        ''    If (Me.ControlBelongsToPanel) Then
        ''        .Left = CInt((PanelDisplayElement.Width - .Width) / 2)
        ''        .Top = CInt((PanelDisplayElement.Height - .Height) / 2)
        ''
        ''        panelArrow.Top = .Top
        ''        panelArrow.Left = .Left - panelArrow.Width
        ''
        ''    End If ''End of ""If (Me.ControlBelongsToPanel) Then""
        ''
        ''End With ''End of ""With mod_controlRSCMoveable""

    End Sub ''End of ""Public Sub New"" 


    Protected Sub PositionElement(par_control As RSCMoveableControlVB,
                                  par_element As ClassElementBase)
        ''
        ''Added 7/29/2022, 7/28/2022 thomas downes
        ''
        ''7/29/2022 With mod_controlFieldOrTextV4
        With par_control
            ''
            ''Add the control to the appropriate Controls collection.
            ''Center the control. 
            ''
            If (ControlBelongsToPanel) Then
                ''
                ''Add the control to the panel. Centering will happen at the ExitHandler.
                ''
                Me.PanelDisplayElement.Controls.Add(mod_controlFieldOrTextV4)

                ''7/29/2022 With mod_controlFieldOrTextV4
                With mod_controlRSCMoveable
                    ''
                    ''Center the control within the panel. 
                    ''
                    .Left = CInt((PanelDisplayElement.Width - .Width) / 2)
                    .Top = CInt((PanelDisplayElement.Height - .Height) / 2)

                    panelArrowLeft.Top = .Top
                    panelArrowLeft.Left = .Left - panelArrowLeft.Width

                End With ''End of ""With mod_controlRSCMoveable""

            Else
                Me.Controls.Add(mod_controlFieldOrTextV4)

                ''---''Center the control within the Panel, even if it doesn't belong to the Panel. 
                ''---.Left = PanelDisplayElement.Left + CInt((PanelDisplayElement.Width - .Width) / 2)
                ''---.Top = PanelDisplayElement.Top + CInt((PanelDisplayElement.Height - .Height) / 2)

                ''Added 8/3/2022 td
                .Left = PanelDisplayElement.Left + par_element.Left
                .Top = PanelDisplayElement.Top + par_element.Top

                ''Arrow should point to the control
                panelArrowLeft.Top = .Top
                panelArrowLeft.Left = .Left - panelArrowLeft.Width

                ''Added 8/3/2022
                panelArrowLeft.Visible = True
                panelArrowRight.Visible = False

            End If ''End of ""If (ControlBelongsToPanel) Then... Else..."

        End With ''end of ""With par_control"  

    End Sub ''End of ""Protected Sub PositionElement""


    Private Sub PositionArrow(par_control As RSCMoveableControlVB)
        ''
        ''Added 7/29/2022
        ''
        With par_control

            If (Me.ControlBelongsToPanel) Then

                If (mod_bCheckArrowLR) Then

                    PositionArrow(par_control, mod_enumArrowLeftRight)

                Else

                    PositionArrow(par_control, EnumArrowIsWhere.LeftOfElement)

                    If (panelArrowLeft.Left < 0) Then
                        mod_enumArrowLeftRight = EnumArrowIsWhere.RightOfElement
                        panelArrowLeft.Visible = False
                        panelArrowRight.Visible = True
                        PositionArrow(par_control, mod_enumArrowLeftRight)
                    Else
                        ''Added 8/3/2022
                        panelArrowLeft.Visible = True
                        panelArrowRight.Visible = False

                    End If 'end of ""If (panelArrowLeft.Left < 0) Then... Else....""

                End If ''End of ""If (mod_bCheckArrowLR) Then... Else..."


            Else

                If (mod_bCheckArrowLR) Then

                    PositionArrow(par_control, mod_enumArrowLeftRight)

                Else

                    PositionArrow(par_control, EnumArrowIsWhere.LeftOfElement)

                    If (panelArrowLeft.Left < 0) Then
                        mod_enumArrowLeftRight = EnumArrowIsWhere.RightOfElement
                        panelArrowLeft.Visible = False
                        panelArrowRight.Visible = True
                        PositionArrow(par_control, mod_enumArrowLeftRight)
                    Else
                        ''Added 8/3/2022
                        panelArrowLeft.Visible = True
                        panelArrowRight.Visible = False

                    End If 'end of ""If (panelArrowLeft.Left < 0) Then ... Else...""

                End If ''End of ""If (mod_bCheckArrowLR) Then... Else..."

            End If ''end of ""If (Me.ControlBelongsToPanel) Then.... Else..."

        End With ''End of ""With par_control""


    End Sub ''End of ""Private Sub PositionArrow(par_control As RSCMoveableControlVB)""


    Private Sub PositionArrow(par_control As RSCMoveableControlVB, par_enum As EnumArrowIsWhere)
        ''
        ''Added 7/29/2022
        ''
        If (par_enum = EnumArrowIsWhere.RightOfElement) Then

            PositionArrow_Right(par_control)

        Else
            PositionArrow_Left(par_control)

        End If ''End of ""If (par_enum = EnumArrowIsWhere.RightOfElement) Then.... Else..."

    End Sub ''End of ""Private Sub PositionArrow(par_control As RSCMoveableControlVB)""


    Private Sub PositionArrow_Right(par_control As RSCMoveableControlVB)
        ''
        ''Added 7/29/2022
        ''
        Dim intArrowWidth As Integer

        panelArrowRight.Visible = True
        intArrowWidth = panelArrowRight.Width
        panelArrowLeft.Visible = False

        With par_control

            If (Me.ControlBelongsToPanel) Then

                panelArrowRight.Top = .Top + PanelDisplayElement.Top
                panelArrowRight.Left = .Left - intArrowWidth + PanelDisplayElement.Left

            Else

                panelArrowRight.Top = .Top
                panelArrowRight.Left = .Left - intArrowWidth

            End If ''end of ""If (Me.ControlBelongsToPanel) Then.... Else..."

        End With


    End Sub ''End of ""Private Sub PositionArrow_Right(par_control As RSCMoveableControlVB)""


    Private Sub PositionArrow_Left(par_control As RSCMoveableControlVB)
        ''
        ''Added 7/29/2022
        ''
        Dim intArrowWidth As Integer

        panelArrowLeft.Visible = True
        panelArrowRight.Visible = False
        intArrowWidth = panelArrowLeft.Width

        With par_control

            If (Me.ControlBelongsToPanel) Then

                panelArrowLeft.Top = par_control.Top + PanelDisplayElement.Top
                panelArrowLeft.Left = par_control.Left - intArrowWidth + PanelDisplayElement.Left

            Else

                panelArrowLeft.Top = par_control.Top
                panelArrowLeft.Left = par_control.Left - intArrowWidth

            End If ''end of ""If (Me.ControlBelongsToPanel) Then.... Else..."

        End With


    End Sub ''End of ""Private Sub PositionArrow_Left(par_control As RSCMoveableControlVB)""


    Private Sub Dialog_Base_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 7/28/2022 Thomas Downes 
        ''




    End Sub

    Private Sub CheckBoxArrow_CheckedChanged(sender As Object, e As EventArgs) Handles checkBoxArrow.CheckedChanged

        ''Added 7/29/2022
        If (checkBoxArrow.Checked) Then

            panelArrowLeft.Visible = (mod_enumArrowLeftRight = EnumArrowIsWhere.LeftOfElement)
            panelArrowRight.Visible = (mod_enumArrowLeftRight = EnumArrowIsWhere.RightOfElement)

        Else
            panelArrowLeft.Visible = False
            panelArrowRight.Visible = False

        End If

    End Sub

    Private Sub PanelDisplayElement_Paint(sender As Object, e As PaintEventArgs) Handles PanelDisplayElement.Paint

    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click

        ''Added 8/2/2022
        Me.Close()

    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click

        ''Added 8/2/2022
        Me.Close()

    End Sub
End Class