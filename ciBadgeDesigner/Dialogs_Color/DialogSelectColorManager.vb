''
'' Added 9/30/2022 thomas downes
''
Imports ciBadgeInterfaces ''Added 9/30/2022
Imports __RSCWindowsControlLibrary ''Added 10/24/2022

Public Class DialogSelectColorManager

    Private mod_listRSCColors As List(Of RSCColor)
    Private mod_hashRSCColors As HashSet(Of RSCColor) ''Added 10/'12/2022
    Private mod_panelLastSelected As RSCColorFlowPanel ''Added 10/24/20222

    Public Sub New(par_listRSCColors As List(Of RSCColor))

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mod_listRSCColors = par_listRSCColors

    End Sub

    Public Sub New(par_hashRSCColors As HashSet(Of RSCColor))

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mod_hashRSCColors = par_hashRSCColors

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
        mod_panelLastSelected = RscColorFlowPanel1

    End Sub


    Private Sub RscColorFlowPanel2_ColorSelected(par_color As RSCColor) Handles RscColorFlowPanel2.ColorSelected
        ''
        ''Added 10/24/2022 Thomas Downes
        ''
        RscColorDisplayLabel1.Visible = True
        RscColorDisplayLabel1.RSCDisplayColor = par_color
        mod_panelLastSelected = RscColorFlowPanel2

    End Sub

    Private Sub RscElementArrowLeft1_Click(sender As Object, e As EventArgs) Handles RscElementArrowLeft1.Click

        ''Added 10/24/2022 td
        If (mod_panelLastSelected Is RscColorFlowPanel2) Then
            ''Added 10/24/2022 td
            MessageBoxTD.Show_Statement_TwoLines("That color is already selected & exists in the righthand panel.",
                  "Use the other arrow, or select a color from the lefthand panel.")
            Exit Sub
        End If ''End of ""If (mod_panelLastSelected Is RscColorFlowPanel2) Then""

        ''Added 10/24/2022 td
        mod_panelLastSelected.AddColor(RscColorDisplayLabel1.RSCDisplayColor)
        mod_listRSCColors.Add(RscColorDisplayLabel1.RSCDisplayColor)
        RscColorDisplayLabel1.Visible = False ''No longer needed.--10/24/2022
        LabelSelectedColor.Visible = False

    End Sub

    Private Sub RscElementArrowRight1_Click(sender As Object, e As EventArgs) Handles RscElementArrowRight1.Click,
              RscElementArrowLeft1.Element_LeftClicked

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

    Private Sub RscElementArrowLeft1_Load(sender As Object, e As EventArgs) Handles RscElementArrowLeft1.Load

    End Sub
End Class