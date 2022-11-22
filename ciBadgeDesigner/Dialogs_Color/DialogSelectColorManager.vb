''
'' Added 9/30/2022 thomas downes
''
Imports ciBadgeInterfaces ''Added 9/30/2022
Imports __RSCWindowsControlLibrary ''Added 10/24/2022

Public Class DialogSelectColorManager

    Public UserCancelled As Boolean ''Added 11/02/2022 td
    Public UserWantsToSave_Okay As Boolean ''Added 11/02/2022 td

    Private mod_listRSCColors As List(Of RSCColor)
    Private mod_hashRSCColors As HashSet(Of RSCColor) ''Added 10/'12/2022
    Private mod_panelLastSelected As RSCColorFlowPanel ''Added 10/24/20222

    Public Sub SaveListOfRSCColors_ToCache(par_cache As ciBadgeCachePersonality.ClassElementsCache_Deprecated)
        ''
        ''This function is to be called if member Me.UserWantsToSave_Okay is True. 
        ''
        ''To be called from the same procedure that opened (Show, ShowDialog) this form.
        ''   ---Added 11/j2/2022
        ''
        Debug.Assert(mod_listRSCColors.Count =
                     mod_hashRSCColors.Count) ''Must be True. 

        par_cache.ListOfRSCColors.Clear()
        For Each eachRSCColor As RSCColor In mod_listRSCColors

            par_cache.ListOfRSCColors.Add(eachRSCColor)

        Next eachRSCColor

    End Sub ''End of ""Public Sub SaveListOfRSCColors_ToCache""


    Public Sub New(par_listRSCColors As List(Of RSCColor),
                   Optional par_bConfirmColor As Boolean = False)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mod_listRSCColors = par_listRSCColors

        ''Added 10/28/2022 thomas downes
        ''11/2022 RscColorFlowPanel1.ConfirmColorSelection = par_bConfirmColor
        ''11/2022 RscColorFlowPanel2.ConfirmColorSelection = par_bConfirmColor
        RSCColorFlowPanel.ConfirmColorSelection = par_bConfirmColor

    End Sub

    Public Sub New(par_hashRSCColors As HashSet(Of RSCColor),
                   Optional par_bConfirmColor As Boolean = False)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mod_hashRSCColors = par_hashRSCColors

        ''Added 10/28/2022 thomas downes
        ''11/2022 RscColorFlowPanel1.ConfirmColorSelection = par_bConfirmColor
        ''11/2022 RscColorFlowPanel2.ConfirmColorSelection = par_bConfirmColor
        RSCColorFlowPanel.ConfirmColorSelection = par_bConfirmColor

    End Sub


    Private Sub DialogSelectColorManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        '' Added 9/30/2022 td
        ''
        RscColorFlowPanel1All.AddColors_AllPossibleColors(True)
        RscColorFlowPanel1All.Refresh()

        If (mod_listRSCColors IsNot Nothing) Then ''Conditioned 10/12/2022 thomas downes

            RscColorFlowPanel2Chosen.AddColors_FromList(mod_listRSCColors, False)

        ElseIf (mod_hashRSCColors IsNot Nothing) Then ''Added 10/12/2022 thomas downes
            ''
            ''Added 10/12/2022 thomas downes
            ''
            mod_listRSCColors = mod_hashRSCColors.ToList()
            RscColorFlowPanel2Chosen.AddColors_FromList(mod_listRSCColors, False)

        End If ''End of ""If (mod_listRSCColors IsNot Nothing) Then.... elseIf...

        RscColorFlowPanel2Chosen.Refresh()

    End Sub

    Private Sub RscColorFlowPanel1_ColorSelected(par_color As RSCColor) Handles RscColorFlowPanel1All.ColorSelected
        ''
        ''Added 10/24/2022 Thomas Downes
        ''
        RscColorDisplayLabel1.Visible = True
        RscColorDisplayLabel1.RSCDisplayColor = par_color
        RscColorDisplayLabel1.BackColor = par_color.MSNetColor
        RscColorDisplayLabel1.Text = par_color.MSNetColor.Name
        mod_panelLastSelected = RscColorFlowPanel1All
        RscColorDisplayLabel1.Invalidate()
        ButtonSelect.Visible = True ''Added 10/28/2022

    End Sub ''end of ""Private Sub RscColorFlowPanel1_ColorSelected


    Private Sub RscColorFlowPanel2_ColorSelected(par_color As RSCColor) Handles RscColorFlowPanel2Chosen.ColorSelected
        ''
        ''Added 10/24/2022 Thomas Downes
        ''
        RscColorDisplayLabel1.Visible = True
        RscColorDisplayLabel1.RSCDisplayColor = par_color
        mod_panelLastSelected = RscColorFlowPanel2Chosen

        ''Added 11/21/2022 td
        AddOrReplaceColorInModuleList(par_color)

    End Sub

    Private Sub AddOrReplaceColorInModuleList(par_color As RSCColor)

        ''Added 11/21/2022 td
        Dim rscToReplace1 As RSCColor = Nothing
        Dim rscToReplace2 As RSCColor = Nothing ''Address/remove duplicated colors. 

        For Each each_rsc As RSCColor In mod_hashRSCColors
            If (each_rsc.Matches(par_color)) Then
                If (rscToReplace1 Is Nothing) Then
                    rscToReplace1 = each_rsc
                ElseIf (rscToReplace2 Is Nothing) Then
                    ''Address/remove duplicated colors.
                    rscToReplace2 = each_rsc
                    Exit For
                End If ''end of ""If (rscToReplace1 Is Nothing) Then...ElseIf..."
            End If ''End of ""If (each_rsc.Matches(par_color)) Then""
        Next each_rsc

        If (rscToReplace1 IsNot Nothing) Then
            mod_hashRSCColors.Remove(rscToReplace1)
            mod_listRSCColors.Remove(rscToReplace1)
        End If ''end of ""If (rscToReplace1 IsNot Nothing) Then""

        ''Address/remove duplicated colors.
        If (rscToReplace2 IsNot Nothing) Then
            mod_hashRSCColors.Remove(rscToReplace2)
            mod_listRSCColors.Remove(rscToReplace2)
        End If ''end of ""If (rscToReplace2 IsNot Nothing) Then""

        ''Add the parameter color, to the module-level list & hashset. 
        mod_hashRSCColors.Add(par_color)
        mod_listRSCColors.Add(par_color)

    End Sub ''end of Private Sub AddOrReplaceColorInModuleList(par_color As RSCColor)


    Private Sub RscElementArrowRight_Click(sender As Object, e As EventArgs) _
        Handles RscElementArrowRight.Click,
              RscElementArrowRight.Element_LeftClicked

        ''Encapsulation 10/25/2022 
        SecondSelectionStep()

    End Sub


    Private Sub SecondSelectionStep()
        ''
        ''As the user has confirmed his color-selection once or even twice,
        ''   we need to add the color to the list of saved colors.---11/16/2022
        ''
        ''Added 10/24/2022 td
        If (mod_panelLastSelected Is RscColorFlowPanel2Chosen) Then
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
        RscColorFlowPanel2Chosen.AddColor(RscColorDisplayLabel1.RSCDisplayColor)

        RscColorFlowPanel2Chosen.Invalidate()

        ''11/2022 mod_listRSCColors.Add(RscColorDisplayLabel1.RSCDisplayColor)
        ''11/2022 mod_hashRSCColors.Add(RscColorDisplayLabel1.RSCDisplayColor)
        ''Added 11/21/2022 td
        AddOrReplaceColorInModuleList(RscColorDisplayLabel1.RSCDisplayColor)

        ''11.01.2022 RscColorDisplayLabel1.Visible = False ''No longer needed.--10/24/2022

ExitHandler:
        ''Remove the control from the bottom-center of the form. ---11/16/2022
        RscColorDisplayLabel1.Visible = False ''No longer needed.--10/24/2022
        Me.Controls.Remove(RscColorDisplayLabel1) ''Added 11/01/2022
        LabelSelectedColor.Visible = False
        ButtonSelect.Visible = False

    End Sub


    Private Sub RscElementArrowLeft_Click(sender As Object, e As EventArgs) _
        Handles RscElementArrowLeft.Click,
              RscElementArrowLeft.Element_LeftClicked

        ''Added 10/24/2022 td
        If (mod_panelLastSelected Is RscColorFlowPanel1All) Then
            ''Added 10/24/2022 td
            MessageBoxTD.Show_Statement_TwoLines("That color is from the left panel of colors. ",
                     "Use the other arrow, or reselect a color from the right panel.")
            Exit Sub
        End If ''End of ""If (mod_panelLastSelected Is RscColorFlowPanel2) Then""

        ''Added 10/24/2022 td
        mod_panelLastSelected.RemoveColor(RscColorDisplayLabel1.RSCDisplayColor)
        mod_listRSCColors.Remove(RscColorDisplayLabel1.RSCDisplayColor)
        mod_hashRSCColors.Remove(RscColorDisplayLabel1.RSCDisplayColor)
        RscColorDisplayLabel1.Visible = False ''No longer needed.--10/24/2022
        LabelSelectedColor.Visible = False

    End Sub

    Private Sub ButtonSelect_Click(sender As Object, e As EventArgs) Handles ButtonSelect.Click

        ''Encapsulation 10/25/2022 
        mod_panelLastSelected = RscColorFlowPanel1All ''Indicate that the source of
        '' the selected color is the left-hand panel, RscColorFlowPanel1.
        SecondSelectionStep()

    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click

        Me.UserWantsToSave_Okay = True
        Me.Close() '' added 10/2/2022

    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click

        Me.UserCancelled = True ' added 10/2/2022
        Me.Close() ' added 10/2/2022

    End Sub

    ''Private Sub RscElementArrowLeft1_Load(sender As Object, e As EventArgs) Handles RscElementArrowRight.Load
    ''End Sub
End Class