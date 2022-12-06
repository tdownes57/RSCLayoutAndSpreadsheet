''
'' Added 9/30/2022 thomas downes
''
Imports ciBadgeInterfaces ''Added 9/30/2022
Imports __RSCWindowsControlLibrary ''Added 10/24/2022
Imports ciBadgeElements
Imports System.Drawing
Imports ciBadgeSerialize

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


    Private Sub RscColorFlowPanel1_ColorSelected(par_color As RSCColor) Handles RscColorFlowPanel1All.Color_Selected
        ''
        ''Added 10/24/2022 Thomas Downes
        ''
        Const c_bSelect As Boolean = True
        ''Encapsulation 12/6/2022
        DisplayOneColor(par_color, c_bSelect, (Not c_bSelect))
        mod_panelLastSelected = RscColorFlowPanel1All

    End Sub


    Private Sub DisplayOneColor(par_color As RSCColor, pbForSelection As Boolean,
                                                    pbForRemoval As Boolean)
        ''
        ''Added 12/6/2022
        ''
        If (Not (pbForSelection Xor pbForRemoval)) Then
            ''Calling procedure has failed to make things clear,
            ''  so let's default to the following.
            pbForSelection = True
            pbForRemoval = False
        End If ''End of ""If (Not (pbForSelection Xor pbForRemoval)) Then""
        Debug.Assert(pbForSelection Xor pbForRemoval)

        RscColorDisplayLabel1.Visible = True
        RscColorDisplayLabel1.RSCDisplayColor = par_color
        RscColorDisplayLabel1.BackColor = par_color.MSNetColor
        RscColorDisplayLabel1.Text = par_color.MSNetColor.Name
        RscColorDisplayLabel1.Invalidate() ''Will prompt a refresh.

        ButtonSelect.Visible = pbForSelection ''True ''Added 10/28/2022
        RscArrowRightSelect.Visible = pbForSelection ''True True
        RscArrowLeftRemove.Visible = pbForRemoval ''False, since the left-pointing arrow is not applicable.
        ButtonRemove.Visible = pbForRemoval ''False, since the "Remove" buttion
        ''  is not applicable.   ---Added 11/28/2022

    End Sub ''end of ""Private Sub DisplayOneColor


    Private Sub AddOrRemoveColor(par_rsColor As RSCColor, par_bConfirmedAddSelect As Boolean,
                                                          par_bConfirmedRemoval As Boolean)
        ''
        ''Added 12/6/2022 
        ''
        ''Double-check
        ''---Debug.Assert(par_bConfirmedAddSelect Xor par_bConfirmedRemoval)
        If (Not (par_bConfirmedAddSelect Xor par_bConfirmedRemoval)) Then
            ''Calling procedure has failed to make things clear,
            ''  so let's default to the following.
            par_bConfirmedAddSelect = True
            par_bConfirmedRemoval = False
        End If ''End of ""If (Not (pbForSelection Xor pbForRemoval)) Then""

        If (par_rsColor Is Nothing) Then
            MessageBoxTD.Show_StatementLongform("Color not found", "Please try selecting " &
                    "the color again in a different way, prior to removal.", 1.3, 1.0)
            Exit Sub ''Return
        End If ''ENd of ""If (rsColor Is Nothing) Then""

        If (par_bConfirmedAddSelect) Then

            ''Added 12/6/2022
            AddOrReplaceColorInModuleList(par_rsColor)

        ElseIf (par_bConfirmedRemoval) Then

            ''Added 12/6/2022 & 10/24/2022 td
            ''12/6/2022 mod_panelLastSelected.RemoveColor(par_color) ''RscColorDisplayLabel1.RSCDisplayColor)
            mod_listRSCColors.Remove(par_rsColor) ''(RscColorDisplayLabel1.RSCDisplayColor)
            mod_hashRSCColors.Remove(par_rsColor) ''(RscColorDisplayLabel1.RSCDisplayColor)
            ''Moved below.12/2022 ''RscColorDisplayLabel1.Visible = False ''No longer needed.--10/24/2022
            ''Moved below.12/2022 ''LabelSelectedColor.Visible = False

        End If ''ENd of ""If (par_bConfirmedAddSelect) Then... ElseIf..."

        ''Important, refresh the list of selected colors. 
        RscColorFlowPanel2Chosen.RefreshColors_FromList(mod_listRSCColors)

ExitHandler:
        LabelSelectedColor.Visible = False
        ButtonRemove.Visible = False ''Remove button from view.  Added 11/28/2022
        RscArrowLeftRemove.Visible = False ''Remove button from view.  Added 11/28/2022 
        RscColorDisplayLabel1.Visible = False ''Remove usercontrol from view.  Added 11/28/2022  
        mod_panelLastSelected = Nothing

    End Sub ''End of ""Private Sub AddOrRemoveColor""



    Private Sub RscColorFlowPanel2_ColorSelected(par_color As RSCColor) Handles RscColorFlowPanel2Chosen.Color_Selected
        ''
        ''Added 10/24/2022 Thomas Downes
        ''
        Const c_bPossibleRemoval As Boolean = True ''True, since the user might want to remove the color. 
        Const c_bNewColor As Boolean = False ''False.  It's not a new color. We are not adding it, as it's already been added.
        DisplayOneColor(par_color, c_bNewColor, c_bPossibleRemoval)
        mod_panelLastSelected = RscColorFlowPanel2Chosen

    End Sub

    Private Sub AddOrReplaceColorInModuleList(par_color As RSCColor)

        ''Added 11/21/2022 td
        Dim rscToReplaceH1 As RSCColor = Nothing
        Dim rscToReplaceH2 As RSCColor = Nothing ''Address/remove duplicated colors. 
        Dim rscToReplaceL1 As RSCColor = Nothing
        Dim rscToReplaceL2 As RSCColor = Nothing ''Address/remove duplicated colors. 
        Dim boolConfirm1 As Boolean ''Added 12/6/2022
        Dim boolConfirm2 As Boolean ''Added 12/6/2022

        For Each each_rscH As RSCColor In mod_hashRSCColors
            If (each_rscH.Matches(par_color)) Then
                ''
                ''First, check with the user.
                ''
                ''Added 12/6/2022
                boolConfirm1 = MessageBoxTD.Show_Confirm("Replace existing selection?", MessageBoxDefaultButton.Button2)
                If (Not boolConfirm1) Then Exit Sub

                If (rscToReplaceH1 Is Nothing) Then
                    rscToReplaceH1 = each_rscH
                ElseIf (rscToReplaceH2 Is Nothing) Then
                    ''Address/remove duplicated colors.
                    rscToReplaceH2 = each_rscH
                    Exit For
                End If ''end of ""If (rscToReplace1 Is Nothing) Then...ElseIf..."
            End If ''End of ""If (each_rscH.Matches(par_color)) Then""
        Next each_rscH

        ''Possibly redundant, however on 11/21/2022 it seemed necessary.--TD
        For Each each_rscL As RSCColor In mod_listRSCColors
            If (each_rscL.Matches(par_color)) Then
                If (rscToReplaceL1 Is Nothing) Then
                    rscToReplaceL1 = each_rscL
                ElseIf (rscToReplaceL2 Is Nothing) Then
                    ''Address/remove duplicated colors.
                    rscToReplaceL2 = each_rscL
                    Exit For
                End If ''end of ""If (rscToReplace1 Is Nothing) Then...ElseIf..."
            End If ''End of ""If (each_rsc.Matches(par_color)) Then""
        Next each_rscL

        If (rscToReplaceH1 IsNot Nothing) Then
            mod_hashRSCColors.Remove(rscToReplaceH1)
            mod_listRSCColors.Remove(rscToReplaceH1)
        End If ''end of ""If (rscToReplaceH1 IsNot Nothing) Then""

        ''
        ''Address/remove duplicated colors.
        ''
        If (rscToReplaceH2 IsNot Nothing) Then
            mod_hashRSCColors.Remove(rscToReplaceH2)
            mod_listRSCColors.Remove(rscToReplaceH2)
        End If ''end of ""If (rscToReplaceH2 IsNot Nothing) Then""

        ''Possibly redundant, however on 11/21/2022 it seemed necessary.--TD
        If (rscToReplaceL1 IsNot Nothing) Then
            mod_hashRSCColors.Remove(rscToReplaceL1)
            mod_listRSCColors.Remove(rscToReplaceL1)
        End If ''end of ""If (rscToReplaceL1 IsNot Nothing) Then""

        ''Possibly redundant, however on 11/21/2022 it seemed necessary.--TD
        If (rscToReplaceL2 IsNot Nothing) Then
            mod_hashRSCColors.Remove(rscToReplaceL2)
            mod_listRSCColors.Remove(rscToReplaceL2)
        End If ''end of ""If (rscToReplaceH2 IsNot Nothing) Then""

        ''Add the parameter color, to the module-level list & hashset. 
        mod_hashRSCColors.Add(par_color)
        mod_listRSCColors.Add(par_color)

        If (mod_listRSCColors.Count <>
            mod_hashRSCColors.Count) Then ''Must be True. 

            Diagnostics.Debugger.Break()

        End If ''ENd of ""If (mod_listRSCColors.Count <>....)

        ''Added 11/21/2022 
        ''11/2022 Debug.Assert(mod_listRSCColors.Count =
        ''11/2022               mod_hashRSCColors.Count) ''Must be True. 

    End Sub ''end of Private Sub AddOrReplaceColorInModuleList(par_color As RSCColor)


    Private Sub RscElementArrowRight_Click(sender As Object, e As EventArgs) _
        Handles RscArrowRightSelect.Click,
              RscArrowRightSelect.Element_LeftClicked

        ''Encapsulation 10/25/2022 
        ''12/6/2022 SecondSelectionStep()
        Const c_bConfirmSelect As Boolean = True
        AddOrRemoveColor(RscColorDisplayLabel1.RSCDisplayColor, c_bConfirmSelect, False)

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
        ''12/6/2022 Oops!!!!! Me.Controls.Remove(RscColorDisplayLabel1) ''Added 11/01/2022
        LabelSelectedColor.Visible = False
        ButtonSelect.Visible = False
        RscArrowRightSelect.Visible = False ''Added 11/28/2022 

    End Sub


    Private Sub RscElementArrowLeft_Click(sender As Object, e As EventArgs) _
        Handles RscArrowLeftRemove.Click,
              RscArrowLeftRemove.Element_LeftClicked
        ''
        ''Remove the selected color from the "Selected/Chosen" panel, on the 
        ''  right-hand side of the dialog. 
        ''
        ''Added 10/24/2022 td
        ''If (mod_panelLastSelected Is RscColorFlowPanel1All) Then
        ''    ''Added 10/24/2022 td
        ''    MessageBoxTD.Show_Statement_TwoLines("That color is from the left panel of colors. ",
        ''             "Use the other arrow, or reselect a color from the right panel.")
        ''    Exit Sub
        ''End If ''End of ""If (mod_panelLastSelected Is RscColorFlowPanel2) Then""

        ''12/2022 Added 10/24/2022 td
        ''12/2022 mod_panelLastSelected.RemoveColor(RscColorDisplayLabel1.RSCDisplayColor)
        ''12/2022 mod_listRSCColors.Remove(RscColorDisplayLabel1.RSCDisplayColor)
        ''12/2022 mod_hashRSCColors.Remove(RscColorDisplayLabel1.RSCDisplayColor)
        ''12/2022 RscColorDisplayLabel1.Visible = False ''No longer needed.--10/24/2022
        ''12/2022 LabelSelectedColor.Visible = False

        ''Encapsulated 12/6/2022 
        Const c_bRemoveColor As Boolean = True
        AddOrRemoveColor(RscColorDisplayLabel1.RSCDisplayColor,
                          False, c_bRemoveColor)

    End Sub



    Private Sub ButtonSelect_Click(sender As Object, e As EventArgs) Handles ButtonSelect.Click

        ''Encapsulation 10/25/2022 
        mod_panelLastSelected = RscColorFlowPanel1All ''Indicate that the source of
        '' the selected color is the left-hand panel, RscColorFlowPanel1.
        ''12/6/2022 SecondSelectionStep()
        AddOrRemoveColor(RscColorDisplayLabel1.RSCDisplayColor, True, False)

    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click

        Me.UserWantsToSave_Okay = True
        Me.Close() '' added 10/2/2022

    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click

        Me.UserCancelled = True ' added 10/2/2022
        Me.Close() ' added 10/2/2022

    End Sub


    Private Sub RscElementArrowRight_Click(par_control As RSCMoveableControlVB, par_e As EventArgs) _
        Handles RscArrowRightSelect.Element_LeftClicked '', RscArrowRightSelect.Click '', RscArrowRightSelect.Click '', RscElementArrowRight.Click

        ''Added 11/28/2022
        ''---ButtonSelect.PerformClick()
        Const c_bSelect As Boolean = True
        AddOrRemoveColor(RscColorDisplayLabel1.RSCDisplayColor, c_bSelect, False)

    End Sub

    Private Sub ButtonRemove_Click(sender As Object, e As EventArgs) Handles ButtonRemove.Click

        ''Added 11/28/2022 td
        Dim rsColor As RSCColor
        rsColor = RscColorDisplayLabel1.RSCDisplayColor
        If (rsColor Is Nothing) Then
            MessageBoxTD.Show_StatementLongform("Color not found", "Please try selecting " &
                    "the color again in a different way, prior to removal.", 1.3, 1.0)
            Exit Sub ''Return
        End If ''ENd of ""If (rsColor Is Nothing) Then""

        ''mod_listRSCColors.Remove(rsColor)
        ''mod_hashRSCColors.Remove(rsColor)
        ''RscColorFlowPanel2Chosen.RefreshColors_FromList(mod_listRSCColors)
        ''ButtonRemove.Visible = False ''Added 11/28/2022
        ''RscArrowLeftRemove.Visible = False ''Added 11/28/2022 
        ''RscColorDisplayLabel1.Visible = False ''Added 11/28/2022  

        ''Encapsulated 12/6/2022 
        Const c_bRemoveColor As Boolean = True
        AddOrRemoveColor(RscColorDisplayLabel1.RSCDisplayColor,
                          False, c_bRemoveColor)

    End Sub


    ''Private Sub RscElementArrowLeft1_Load(sender As Object, e As EventArgs) Handles RscElementArrowRight.Load
    ''End Sub
End Class