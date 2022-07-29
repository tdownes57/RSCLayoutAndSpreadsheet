''
''Added 7/28/2022 Thomas Downes 
''
Public Class Dialog_Base
    ''
    ''Added 7/28/2022 Thomas Downes 
    ''
    Protected mod_control As CtlGraphicFieldOrTextV4

    Protected ControlBelongsToPanel As Boolean = False ''Added 7/28/2022 td

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

    End Sub

    Public Sub New(par_control As CtlGraphicFieldOrTextV4)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mod_control = par_control

        ''Added 7/28/2022 thomas downes
        With mod_control
            ''
            ''Add the control to the appropriate Controls collection.
            ''Center the control. 
            ''
            If (ControlBelongsToPanel) Then
                ''
                ''Add the control to the panel. Centering will happen at the ExitHandler.
                ''
                Me.PanelDisplayElement.Controls.Add(mod_control)

            Else
                Me.Controls.Add(mod_control)
                ''Center the control within the Panel, even if it doesn't belong to the Panel. 
                .Left = PanelDisplayElement.Left + CInt((PanelDisplayElement.Width - .Width) / 2)
                .Top = PanelDisplayElement.Top + CInt((PanelDisplayElement.Height - .Height) / 2)
                ''Arrow should point to the control
                panelArrow.Top = .Top
                panelArrow.Left = .Left - panelArrow.Width

            End If ''End of ""If (ControlBelongsToPanel) Then... Else..."

        End With

        mod_control.Visible = True
        mod_control.BringToFront()

ExitHandler:

        With mod_control
            ''
            ''Center the control. 
            ''
            If (Me.ControlBelongsToPanel) Then
                .Left = CInt((PanelDisplayElement.Width - .Width) / 2)
                .Top = CInt((PanelDisplayElement.Height - .Height) / 2)

                panelArrow.Top = .Top
                panelArrow.Left = .Left - panelArrow.Width

            End If ''End of ""If (Me.ControlBelongsToPanel) Then""

        End With

    End Sub ''End of ""Public Sub New"" 



    Private Sub Dialog_Base_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 7/28/2022 Thomas Downes 
        ''




    End Sub
End Class