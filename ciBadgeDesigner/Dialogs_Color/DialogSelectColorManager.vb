''
'' Added 9/30/2022 thomas downes
''
Imports ciBadgeInterfaces ''Added 9/30/2022
Imports __RSCWindowsControlLibrary ''Added 10/24/2022

Public Class DialogSelectColorManager

    Private mod_listRSCColors As List(Of RSCColor)
    Private mod_hashRSCColors As HashSet(Of RSCColor) ''Added 10/'12/2022
    Private mod_panelLastSelected As RSCColorFlowPanel ''Added 10/24/20222


    Public Sub New(par_listRSCColors As List(Of RSCColor),
                   Optional par_bConfirmColor As Boolean = False)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mod_listRSCColors = par_listRSCColors

        ''Added 10/28/2022 thomas downes
        RscColorFlowPanel1.ConfirmColorSelection = par_bConfirmColor
        RscColorFlowPanel2.ConfirmColorSelection = par_bConfirmColor

    End Sub

    Public Sub New(par_hashRSCColors As HashSet(Of RSCColor),
                   Optional par_bConfirmColor As Boolean = False)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mod_hashRSCColors = par_hashRSCColors

        ''Added 10/28/2022 thomas downes
        RscColorFlowPanel1.ConfirmColorSelection = par_bConfirmColor
        RscColorFlowPanel2.ConfirmColorSelection = par_bConfirmColor

    End Sub


    Private Sub DialogSelectColorManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        '' Added 9/30/2022 td
        ''
        RscColorFlowPanel1.AddColors_AllPossibleColors(True)
        RscColorFlowPanel1.Refresh()

        If (mod_listRSCColors IsNot Nothing) Then ''Conditioned 10/12/2022 thomas downes

            RscColorFlowPanel2.AddColors_FromList(mod_listRSCColors, False)

        ElseIf (mod_hashRSCColors IsNot Nothing) Then ''Added 10/12/2022 thomas downes
            ''
            ''Added 10/12/2022 thomas downes
            ''
            mod_listRSCColors = mod_hashRSCColors.ToList()
            RscColorFlowPanel2.AddColors_FromList(mod_listRSCColors, False)

        End If ''End of ""If (mod_listRSCColors IsNot Nothing) Then.... elseIf...

        RscColorFlowPanel2.Refresh()

    End Sub

    Private Sub RscColorFlowPanel1_ColorSelected(par_color As RSCColor) Handles RscColorFlowPanel1.ColorSelected
        ''
        ''Added 10/24/2022 Thomas Downes
        ''
        RscColorDisplayLabel1.Visible = True
        RscColorDisplayLabel1.RSCDisplayColor = par_color
        RscColorDisplayLabel1.BackColor = par_color.MSNetColor
        RscColorDisplayLabel1.Text = par_color.MSNetColor.Name
        mod_panelLastSelected = RscColorFlowPanel1
        RscColorDisplayLabel1.Invalidate()
        ButtonSelect.Visible = True ''Added 10/28/2022

    End Sub ''end of ""Private Sub RscColorFlowPanel1_ColorSelected


    Private Sub RscColorFlowPanel2_ColorSelected(par_color As RSCColor) Handles RscColorFlowPanel2.ColorSelected
        ''
        ''Added 10/24/2022 Thomas Downes
        ''
        RscColorDisplayLabel1.Visible = True
        RscColorDisplayLabel1.RSCDisplayColor = par_color
        mod_panelLastSelected = RscColorFlowPanel2

    End Sub


    Private Sub RscElementArrowRight_Click(sender As Object, e As EventArgs) _
        Handles RscElementArrowRight.Click,
              RscElementArrowRight.Element_LeftClicked

        ''Encapsulation 10/25/2022 
        SecondSelectionStep

    End Sub


    Private Sub SecondSelectionStep()

        ''Added 10/24/2022 td
        If (mod_panelLastSelected Is RscColorFlowPanel2) Then
            ''Added 10/24/2022 td
            MessageBoxTD.Show_Statement_TwoLines("That color is already selected & exists in the righthand panel.",
                  "Use the other arrow, or select a color from the lefthand panel.")
            Exit Sub
        End If ''End of ""If (mod_panelLastSelected Is RscColorFlowPanel2) Then""

        ''Added 10/24/2022 td
        ''10/29/2022 mod_panelLastSelected.AddColor(RscColorDisplayLabel1.RSCDisplayColor)
        ''#1 11/01/2022 RscColorFlowPanel2.AddColor(RscColorDisplayLabel1.RSCDisplayColor)
        ''#2 11/01/2022 RscColorFlowPanel2.AddColor(RscColorDisplayLabel1.RSCDisplayColor,
        ''                    RscColorFlowPanel2)
        RscColorFlowPanel2.AddColor(RscColorDisplayLabel1.RSCDisplayColor)

        RscColorFlowPanel2.Invalidate()
        mod_listRSCColors.Add(RscColorDisplayLabel1.RSCDisplayColor)
        ''11.01.2022 RscColorDisplayLabel1.Visible = False ''No longer needed.--10/24/2022
        RscColorDisplayLabel1.Visible = False ''No longer needed.--10/24/2022
        Me.Controls.Remove(RscColorDisplayLabel1) ''Added 11/01/2022
        LabelSelectedColor.Visible = False
        ButtonSelect.Visible = False

    End Sub


    Private Sub RscElementArrowLeft_Click(sender As Object, e As EventArgs) _
        Handles RscElementArrowLeft.Click,
              RscElementArrowLeft.Element_LeftClicked

        ''Added 10/24/2022 td
        If (mod_panelLastSelected Is RscColorFlowPanel1) Then
            ''Added 10/24/2022 td
            MessageBoxTD.Show_Statement_TwoLines("That color is from the left panel of colors. ",
                     "Use the other arrow, or reselect a color from the right panel.")
            Exit Sub
        End If ''End of ""If (mod_panelLastSelected Is RscColorFlowPanel2) Then""

        ''Added 10/24/2022 td
        mod_panelLastSelected.RemoveColor(RscColorDisplayLabel1.RSCDisplayColor)
        mod_listRSCColors.Remove(RscColorDisplayLabel1.RSCDisplayColor)
        RscColorDisplayLabel1.Visible = False ''No longer needed.--10/24/2022
        LabelSelectedColor.Visible = False

    End Sub

    Private Sub ButtonSelect_Click(sender As Object, e As EventArgs) Handles ButtonSelect.Click

        ''Encapsulation 10/25/2022 
        SecondSelectionStep()

    End Sub

    ''Private Sub RscElementArrowLeft1_Load(sender As Object, e As EventArgs) Handles RscElementArrowRight.Load
    ''End Sub
End Class