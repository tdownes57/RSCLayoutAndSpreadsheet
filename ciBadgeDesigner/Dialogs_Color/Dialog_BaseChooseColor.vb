''
'' Added 3/4/2022 thomas downes
''
Imports ciBadgeElements ''Added 8/01/2022 td
Imports ciBadgeInterfaces ''Added 8/06/2022 thomas downes
Imports __RSCWindowsControlLibrary ''Added 8/07/2022 thomas 
Imports ciBadgeCachePersonality ''Added 10/24/2022 thomas downes  
Imports __RSC_Error_Logging ''Added 11/21/2022 Thomas Downes  

Public Enum EnumForeOrBackground
    Undetermined
    Foreground
    Background
    Foreground_AndBackInverse ''Added 12/30/2022
    Background_AndForeInverse ''Added 12/30/2022
End Enum

Public Class Dialog_BaseChooseColor
    ''
    '' Added 3/4/2022 Thomas Downes
    ''
    ''8/07/2022 td''Private mod_colors As New List(Of Drawing.Color)
    Private mod_listRSCColors As List(Of RSCColor)
    Private mod_hashRSCColors As HashSet(Of RSCColor)
    Private mod_listMSColors_Unused As List(Of Drawing.Color)

    ''Added 8/22/2022 td
    ''
    '' Variables related to the Undo button. 
    ''
    Private mod_elementsCache As ciBadgeCachePersonality.ClassElementsCache_Deprecated
    Private mod_rscColorLastSelected As RSCColor
    Private mod_msColorLastSelected As Drawing.Color
    Private mod_msColorLastReplaced As Drawing.Color
    Private mod_enumForeOrBack As EnumForeOrBackground
    ''Undo Tuple Stack
    Private Const mod_c_bUseTupleStack As Boolean = True
    Private mod_stackUndoTuples As New Stack(Of Tuple(Of Drawing.Color, EnumForeOrBackground))
    ''Undo Color Stack(s)
    ''  ---8/30/2022 td  
    Private mod_stackUndoColors_Foreground As New Stack(Of Drawing.Color)
    Private mod_stackUndoColors_Background As New Stack(Of Drawing.Color)

    Public Sub New(par_control As CtlGraphicFieldOrTextV4,
                   par_listFontFamilyNames As HashSet(Of String),
                   par_hashRSCColors As HashSet(Of RSCColor),
                   par_element As ClassElementBase,
                   par_infoElementBase As IElement_Base,
                   par_designer As ClassDesigner,
                   par_events As GroupMoveEvents_Singleton,
                   Optional par_imageBadge As Drawing.Image = Nothing)

        ' Add any initialization after the InitializeComponent() call.

        ''8/4/2022 MyBase.New(par_control, par_control.ElementBase,
        ''8/4/2022     par_imageBadge)
        ''8/7/2022 MyBase.New(par_control, par_control.ElementBase,
        ''            par_control.ElementInfo_Base,
        ''           par_designer, par_events,
        ''           par_imageBadge)
        ''8/10/2022 MyBase.New(par_control,
        ''           par_control.ElementBase,
        ''           par_infoElementBase,
        ''           par_designer, par_events,
        ''           par_imageBadge)
        MyBase.New(par_control,
                   par_listFontFamilyNames,
                   par_hashRSCColors,
                   par_control.ElementBase,
                   par_infoElementBase,
                   par_designer, par_events,
                   par_imageBadge)

        ' This call is required by the designer.
        InitializeComponent()

        ''Added 10/12/2022 thomas 
        mod_hashRSCColors = par_hashRSCColors
        mod_listRSCColors = par_hashRSCColors.ToList()


    End Sub


    Public Sub New(par_control As CtlGraphicFieldOrTextV4,
                   par_elementsCache As ClassElementsCache_Deprecated,
                   par_element As ClassElementBase,
                   par_infoElementBase As IElement_Base,
                   par_designer As ClassDesigner,
                   par_events As GroupMoveEvents_Singleton,
                   Optional par_imageBadge As Drawing.Image = Nothing)

        ' Add any initialization after the InitializeComponent() call.

        MyBase.New(par_control,
                   par_elementsCache,
                   par_control.ElementBase,
                   par_infoElementBase,
                   par_designer, par_events,
                   par_imageBadge)

        ' This call is required by the designer.
        InitializeComponent()

        ''Added 10/12/2022 thomas 
        mod_hashRSCColors = par_elementsCache.ListOfRSCColors()
        mod_listRSCColors = mod_hashRSCColors.ToList()
        ''Added 10/24/2022 td
        mod_elementsCache = par_elementsCache

    End Sub


    Private Sub Dialog_BaseChooseColor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        '' Added 3/4/2022 thomas downes
        ''
        RefreshFlowPanel() ''Encapsulated 11/18/2022

        ''Added 12/6/2022 
        MyBase.DisableOneButton(False, True, False, False, False, False)

        ''Added 12/30/2022 
        ButtonForecolor.BackColor = mod_elementBase.Back_Color
        ButtonBackground.BackColor = mod_elementBase.Back_Color

        ''Added 12/30/2022 
        If (mod_elementText IsNot Nothing) Then
            ButtonForecolor.ForeColor = mod_elementText.FontColor
            ButtonBackground.ForeColor = mod_elementText.FontColor
        End If


    End Sub


    Private Sub RefreshFlowPanel(Optional par_hashsetColors As HashSet(Of RSCColor) = Nothing)
        ''
        ''Encapsulated 11/18/2022
        ''
        ''11/27/2022 RSCColorFlowPanel.RefreshColors_FromList(FlowLayoutPanel1, mod_listRSCColors)

        ''Refresh the alternate panel.  (It's a competition, to see which container will 
        ''  be chosen to be the UI control.)
        RscColorFlowPanel2.RefreshColors_FromList(mod_listRSCColors)

        ''Added 8/30/2022 thomas downes
        ''RscColorFlowPanelNew.Controls.Clear()
        ''''--RscColorFlowPanel1.AddColors_BlackAndWhite()
        ''RscColorFlowPanelNew.AddLinkLabelForAddingColors()
        ''''9/30 td''RscColorFlowPanel1.AddColors_AllPossibleColors(True)
        ''''10/12/2022 td''RscColorFlowPanel1.AddColors_FromCache(mod_listRSCColors)

        ''If (par_hashsetColors IsNot Nothing) Then
        ''    ''Added 11/18/2022  td
        ''    mod_listRSCColors = par_hashsetColors.ToList()
        ''    ''#1 11/18/2022 RscColorFlowPanel1.AddColors_FromList(mod_listRSCColors)
        ''    ''#2 11/19/2022 RscColorFlowPanelNew.AddColors_FromList(mod_listRSCColors, True)
        ''    RscColorFlowPanelNew.RefreshColors_FromList(mod_listRSCColors)

        ''ElseIf (mod_listRSCColors Is Nothing) Then
        ''    ''Added 10/12/2022 td  
        ''    System.Diagnostics.Debugger.Break()
        ''    System.Diagnostics.Debug.Assert(False, "RSC Colors is nothing.")
        ''    RSCErrorLogging.Log(57, "RefreshFlowPanel", "RSC Colors is nothing")

        ''Else

        ''    ''#1 11/18/2022 RscColorFlowPanel1.AddColors_FromList(mod_listRSCColors)
        ''    ''#2 11/19/2022 RscColorFlowPanelNew.AddColors_FromList(mod_listRSCColors, True)
        ''    RscColorFlowPanelNew.RefreshColors_FromList(mod_listRSCColors)

        ''End If ''End of ""If (mod_listRSCColors Is Nothing) Then... ElseIf.... Else..."" 


    End Sub ''End of ""Private Sub RefreshFlowPanel()""


    Private Sub AddColors_AllPossibleColors_NotUsed()
        ''
        ''Obselete as of 8/30/2022 td
        ''
        If (mod_listMSColors_Unused Is Nothing) Then
            mod_listMSColors_Unused = New List(Of Drawing.Color)
        End If ''If (mod_listMSColors Is Nothing) Then

        With mod_listMSColors_Unused

            .Add(Drawing.Color.AliceBlue)
            .Add(Drawing.Color.AntiqueWhite)
            .Add(Drawing.Color.Aqua)
            .Add(Drawing.Color.Aquamarine)
            .Add(Drawing.Color.Azure)

            .Add(Drawing.Color.Beige)
            .Add(Drawing.Color.Bisque)
            .Add(Drawing.Color.Black)
            .Add(Drawing.Color.BlanchedAlmond)
            .Add(Drawing.Color.Blue)
            .Add(Drawing.Color.BlueViolet)
            .Add(Drawing.Color.Brown)
            .Add(Drawing.Color.BurlyWood)

            ''Added 8/7/2022
            .Add(Drawing.Color.CadetBlue)
            .Add(Drawing.Color.Chartreuse)
            .Add(Drawing.Color.Chocolate)
            .Add(Drawing.Color.Coral)
            .Add(Drawing.Color.CornflowerBlue)
            .Add(Drawing.Color.Cornsilk)

            ''Added 8/8/2022
            .Add(Drawing.Color.Crimson)
            .Add(Drawing.Color.Cyan)
            .Add(Drawing.Color.DarkBlue)
            .Add(Drawing.Color.DarkCyan)
            .Add(Drawing.Color.DarkGoldenrod)
            .Add(Drawing.Color.DarkGray)
            .Add(Drawing.Color.DarkGreen)
            .Add(Drawing.Color.DarkKhaki)
            .Add(Drawing.Color.DarkMagenta)
            .Add(Drawing.Color.DarkOliveGreen)
            .Add(Drawing.Color.DarkOrange)
            .Add(Drawing.Color.DarkOrchid)
            .Add(Drawing.Color.DarkRed)
            .Add(Drawing.Color.DarkSalmon)
            .Add(Drawing.Color.DarkSeaGreen)
            .Add(Drawing.Color.DarkSlateBlue)
            .Add(Drawing.Color.DarkSlateGray)

            ''Added 8/8/2022
            .Add(Drawing.Color.Firebrick)
            .Add(Drawing.Color.FloralWhite)
            .Add(Drawing.Color.ForestGreen)
            .Add(Drawing.Color.Fuchsia)


        End With ''End of ""With mod_listMSColors""

        ''mod_colors.Add(Drawing.Color.
        ''        mod_colors.Add(Drawing.Color.
        ''        mod_colors.Add(Drawing.Color.
        ''        mod_colors.Add(Drawing.Color.
        ''        mod_colors.Add(Drawing.Color.
        ''        mod_colors.Add(Drawing.Color.
        ''        mod_colors.Add(Drawing.Color.
        ''        mod_colors.Add(Drawing.Color.
        ''        mod_colors.Add(Drawing.Color.
        ''        mod_colors.Add(Drawing.Color.
        ''        mod_colors.Add(Drawing.Color.
        ''        mod_colors.Add(Drawing.Color.
        ''        mod_colors.Add(Drawing.Color.
        ''        mod_colors.Add(Drawing.Color.

        ''11/2022 RscColorFlowPanelNew.Controls.Clear()

        ''11/2022 For Each each_color In mod_listMSColors_Unused ''List(Of Drawing.Color)

        ''    Dim newLabel As New RSCColorDisplayLabel
        ''    newLabel.BackColor = each_color
        ''    newLabel.Text = each_color.Name
        ''    newLabel.Visible = True
        ''    AddHandler newLabel.ColorClick, AddressOf NetDrawingColor_Click

        ''    ''newLabel.ToolTip
        ''    ''Me.ToolTip1.SetToolTip(Me.ButtonBackground, "Set Background Color of the Element")
        ''    Me.ToolTip1.SetToolTip(newLabel, each_color.Name)

        ''    RscColorFlowPanelNew.Controls.Add(newLabel)

        ''Next each_color

    End Sub ''End of ""Private Sub AddColors_AllPossibleColors_NotUsed""   


    Private Sub LinkLabelAddColors_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

        ''Added 8/7/2022 thomas downes
        Dim objFormToShow As __RSCWindowsControlLibrary.RSCBrowseExistingColors

        ''10/12/2022 ''objFormToShow = New RSCBrowseExistingColors(mod_listRSCColors)
        objFormToShow = New RSCBrowseExistingColors(mod_hashRSCColors)
        objFormToShow.ShowDialog()

    End Sub


    Private Sub NetDrawingColor_Click(sender As Object, e As EventArgs) ''Handles RscColorFlowPanel2.ColorSelected
        ''
        ''8/22/2022 thomas downes
        ''
        ''  See "AddHandler newLabel.ColorClick, AddressOf NetDrawingColor_Click" 
        ''
        Dim objFormToShow As __RSCWindowsControlLibrary.FormRSCColorConfirm
        Dim strColorName As String
        Dim controlRSCColorLabel As RSCColorDisplayLabel
        Dim mscolorSelected As Drawing.Color
        Dim rscColorSelected As RSCColor

        controlRSCColorLabel = CType(sender, RSCColorDisplayLabel)
        strColorName = controlRSCColorLabel.Text
        mscolorSelected = controlRSCColorLabel.BackColor

        objFormToShow = New FormRSCColorConfirm(mscolorSelected, strColorName)

        With objFormToShow

            .ShowDialog()

            If (Not .Output_Cancelled) Then

                rscColorSelected = .Output_RSCColor
                rscLabelDisplayColorSelected.RSCDisplayColor = rscColorSelected
                rscLabelDisplayColorSelected.Visible = True ''Added 8/28/2022 

            End If ''End of ""If (Not .Output_Cancelled) Then""  

        End With ''End of ""With objFormToShow""


        ''---End If ''End of ""If (Not objFormToShow.Output_Cancelled) Then""

    End Sub ''eND OF ""Private Sub NetDrawingColor_Click""


    Private Sub ButtonBackground_Click(sender As Object, e As EventArgs) Handles ButtonBackground.Click

        ''Added 8/22/2022 thomas  
        Dim rscColorSelected As RSCColor ''Added 8/23/2022

        With rscLabelDisplayColorSelected

            ''8/23/2022 mod_msColorLastSelected = .BackColor
            rscColorSelected = .RSCDisplayColor

            With mod_controlFieldOrTextV4
                ''Save module-level variables. 
                mod_msColorLastSelected = rscColorSelected.MSNetColor
                mod_rscColorLastSelected = rscColorSelected
                mod_msColorLastReplaced = .ElementClass_Obj.Back_Color

                ''8/23/2022 .ElementClass_Obj.Back_Color = .BackColor
                .ElementClass_Obj.Back_Color = rscColorSelected.MSNetColor
                .RefreshElementImage()

            End With ''End of ""With mod_controlFieldOrTextV4""
            mod_enumForeOrBack = EnumForeOrBackground.Background

            ''Undo Pop Stack (Last In, First Out)
            ''   is built using Color-Enum pairs (tuples). 
            ''   ----8/23/2022 
            Dim objNewUndoTuple As Tuple(Of Drawing.Color, EnumForeOrBackground)
            objNewUndoTuple =
                New Tuple(Of Drawing.Color,
                EnumForeOrBackground)(mod_msColorLastReplaced,
                                      mod_enumForeOrBack)
            ''Add the Undo Color-Enum Pair to the popstack. 
            mod_stackUndoTuples.Push(objNewUndoTuple)

        End With ''End of ""With rscLabelDisplayColorSelected""

    End Sub

    Private Sub ButtonForecolor_Click(sender As Object, e As EventArgs) Handles ButtonForecolor.Click

        ''Added 8/22/2022 thomas  
        With rscLabelDisplayColorSelected

            mod_msColorLastSelected = .BackColor
            mod_rscColorLastSelected = .RSCDisplayColor

            With mod_controlFieldOrTextV4
                mod_msColorLastReplaced = .ElementClass_Obj.FontColor
                .ElementClass_Obj.FontColor = mod_msColorLastSelected
                .RefreshElementImage()
            End With
            mod_enumForeOrBack = EnumForeOrBackground.Foreground

            ''Undo Pop Stack (Last In, First Out)
            ''   is built using Color-Enum pairs (tuples). 
            ''   ----8/23/2022 
            Dim objNewUndoTuple As Tuple(Of Drawing.Color, EnumForeOrBackground)
            objNewUndoTuple =
                New Tuple(Of Drawing.Color,
                EnumForeOrBackground)(mod_msColorLastReplaced,
                                      mod_enumForeOrBack)
            ''Add the Undo Color-Enum Pair to the popstack. 
            mod_stackUndoTuples.Push(objNewUndoTuple)

        End With ''End of ""With rscLabelDisplayColorSelected""


    End Sub


    Private Sub ButtonUndo_Click(sender As Object, e As EventArgs) Handles ButtonUndoColorFont.Click
        ''
        ''Added 8/22/2022 thomas  
        ''
        Dim objUndoTuple As Tuple(Of Drawing.Color, EnumForeOrBackground)
        Dim color_UndoTuple As Drawing.Color
        Dim enum_UndoTuple As EnumForeOrBackground
        Static s_boolDoneOnce As Boolean ''Added 8/23/2022 td

        If (mod_c_bUseTupleStack) Then
            If (0 <> mod_stackUndoTuples.Count) Then
                objUndoTuple = mod_stackUndoTuples.Pop()
                If (objUndoTuple Is Nothing And s_boolDoneOnce) Then
                    ''Added 8/23/2022 td
                    MessageBoxTD.Show_StatementLongform("Undo", "Sorry, we are at the end of Undo. " &
                    "or we can't perform the Undo for unknown reasons.", 1.0, 1.0)
                    Exit Sub
                ElseIf (objUndoTuple Is Nothing And (Not s_boolDoneOnce)) Then
                    ''Added 8/23/2022 td
                    MessageBoxTD.Show_StatementLongform("Undo", "Sorry, " &
                        "but there is no color-changes yet to Undo.", 1.0, 1.0)
                    Exit Sub
                Else
                    color_UndoTuple = objUndoTuple.Item1
                    enum_UndoTuple = objUndoTuple.Item2
                End If ''End of ""If (objUndoTuple Is Nothing) Then... Else...""
            End If ''End of ""If (0 <> mod_stackUndoTuples.Count) Then""
        End If ''End of ""If (mod_c_bUseTupleStack) Then""

        ''
        ''Check whether to Undo the FontColor (Foreground)
        ''  or Undo the Background Color. 
        ''
        With mod_controlFieldOrTextV4

            If (mod_c_bUseTupleStack) Then
                ''
                ''Let's reference the Tuple-Stack values. 
                ''
                If (enum_UndoTuple = EnumForeOrBackground.Foreground) Then
                    ''Foreground needs the Undo. 
                    .ElementClass_Obj.FontColor = color_UndoTuple
                ElseIf (enum_UndoTuple = EnumForeOrBackground.Background) Then
                    .ElementClass_Obj.Back_Color = color_UndoTuple

                ElseIf (enum_UndoTuple = EnumForeOrBackground.Foreground_AndBackInverse) Then
                    ''Added 12/30/2022
                    .ElementClass_Obj.FontColor = color_UndoTuple
                    .ElementClass_Obj.Back_Color = RSCColor.GetInverseMSColor(color_UndoTuple)

                ElseIf (enum_UndoTuple = EnumForeOrBackground.Background_AndForeInverse) Then
                    ''Added 12/30/2022
                    .ElementClass_Obj.Back_Color = color_UndoTuple
                    .ElementClass_Obj.FontColor = RSCColor.GetInverseMSColor(color_UndoTuple)

                End If

            Else
                ''
                ''Do NOT reference the Tuple-Stack values. 
                ''
                If (mod_enumForeOrBack = EnumForeOrBackground.Foreground) Then
                    .ElementClass_Obj.FontColor = mod_msColorLastReplaced
                ElseIf (mod_enumForeOrBack = EnumForeOrBackground.Background) Then
                    .ElementClass_Obj.Back_Color = mod_msColorLastReplaced
                End If

            End If ''end of ""If (mod_c_bUseTupleStack) Then... Else..."

            ''
            ''Display the "Undo" colors to the user. 
            ''
            .RefreshElementImage()

        End With ''End of ""With mod_controlFieldOrTextV4""


    End Sub

    ''11/2022 Private Sub RscColorFlowPanel1_Load(sender As Object, e As EventArgs) Handles RscColorFlowPanelNew.Load

    ''11/2022 End Sub

    Private Sub LinkLabelAddColor1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelAddColor1.LinkClicked
        ''
        ''Added 9/17/2022 thomas downes 
        ''
        Dim objFormToShow As DialogSelectColorManager
        ''10/28/2022 Dim listRSCColors As HashSet(Of RSCColor)
        Dim hashsetRSCColors As HashSet(Of RSCColor)
        ''Dim objParameters As ciBadgeDesigner.ClassGetElementControlParams

        ''listRSCColors = objParameters.ElementsCache.ListOfRSCColors
        hashsetRSCColors = mod_elementsCache.ListOfRSCColors
        ''10/28 objFormToShow = New DialogSelectColorManager(listRSCColors)

        Dim boolConfirmColor As Boolean = True ''Added 10/28/2022
        ''10/28/2022 objFormToShow = New DialogSelectColorManager(listRSCColors, boolConfirmColor)
        objFormToShow = New DialogSelectColorManager(hashsetRSCColors, boolConfirmColor)
        objFormToShow.ShowDialog()

        ''Added 11/02/2022 
        If (objFormToShow.UserWantsToSave_Okay) Then

            objFormToShow.SaveListOfRSCColors_ToCache(mod_elementsCache)

            ''Added 11/18/2022 
            ''--RscColorFlowPanel1.AddColors_FromList()
            ''11/2022 RefreshFlowPanel(mod_elementsCache.ListOfRSCColors)
            mod_hashRSCColors = mod_elementsCache.ListOfRSCColors()
            mod_listRSCColors = mod_elementsCache.ListOfRSCColors().ToList()
            RefreshFlowPanel(mod_hashRSCColors)

        End If ''End of ""If (objFormToShow.UserWantsToSave_Okay) Then""

    End Sub

    Private Sub LinkLabelRefreshColors_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelRefreshColors.LinkClicked

        ''Added 11/21/2022
        ''RscColorFlowPanelNew.RefreshColors_FromList(mod_listRSCColors)
        ''11/27/2022 RSCColorFlowPanel.RefreshColors_FromList(FlowLayoutPanel1, mod_listRSCColors)
        RscColorFlowPanel2.RefreshColors_FromList(mod_listRSCColors)


    End Sub

    Private Sub RscColorFlowPanel2_Color_Selected(par_rsccolor As RSCColor)
        ''
        ''Added 11/27/2022 
        ''
        ''11/27 Dim objFormToShow As __RSCWindowsControlLibrary.FormRSCColorConfirm
        Dim objFormToShow As __RSCWindowsControlLibrary.FormRSCColorConfirmTiny
        ''11/27 Dim strColorName As String
        ''Dim controlRSCColorLabel As RSCColorDisplayLabel
        ''11/27 Dim mscolorSelected As Drawing.Color
        Dim rscColorSelected As RSCColor

        ''controlRSCColorLabel = CType(sender, RSCColorDisplayLabel)
        ''11/27 ''strColorName = controlRSCColorLabel.Text
        ''11/27 ''mscolorSelected = controlRSCColorLabel.BackColor
        ''objFormToShow = New FormRSCColorConfirm(mscolorSelected, strColorName)
        ''11/27 objFormToShow = New FormRSCColorConfirm(par_color)
        objFormToShow = New FormRSCColorConfirmTiny(par_rsccolor)

        With objFormToShow

            .ShowDialog()

            If (Not .Output_Cancelled) Then

                rscColorSelected = .Output_RSCColor
                rscLabelDisplayColorSelected.RSCDisplayColor = rscColorSelected
                rscLabelDisplayColorSelected.Visible = True ''Added 8/28/2022 

                ''Added 12/30/2022 td
                ButtonApplyBF.Enabled = True
                ButtonApplyFB.Enabled = True
                ButtonBackground.Enabled = True
                ButtonForecolor.Enabled = True

                ''Added 12/30/2022 td
                ButtonApplyBF.BackColor = rscColorSelected.MSNetColor
                ButtonApplyBF.ForeColor = rscColorSelected.GetInverseMSColor()
                ButtonApplyFB.BackColor = rscColorSelected.GetInverseMSColor()
                ButtonApplyFB.ForeColor = rscColorSelected.MSNetColor

            End If ''End of ""If (Not .Output_Cancelled) Then""  

        End With ''End of ""With objFormToShow""

    End Sub

    Private Sub RscColorFlowPanel2_Colors_OpenAddRemove(sender As Object, e As EventArgs)

        ''Added 11/27/2022 td
        Dim objLinkArgs As LinkLabelLinkClickedEventArgs
        Dim objLink As LinkLabel.Link

        ''Added 11/27/2022 td
        objLink = LinkLabelAddColor1.Links(0)
        objLinkArgs = New LinkLabelLinkClickedEventArgs(objLink)
        LinkLabelAddColor1_LinkClicked(LinkLabelAddColor1, objLinkArgs)

    End Sub

    Private Sub ButtonApplyFB_Click(sender As Object, e As EventArgs) Handles ButtonApplyFB.Click

        ''Added 12/30/2022 thomas  
        Dim rscColorSelected As RSCColor ''Added 8/23/2022

        With rscLabelDisplayColorSelected

            rscColorSelected = .RSCDisplayColor

            With mod_controlFieldOrTextV4
                ''Save module-level variables. 
                mod_msColorLastSelected = rscColorSelected.MSNetColor
                mod_rscColorLastSelected = rscColorSelected
                mod_msColorLastReplaced = .ElementClass_Obj.FontColor

                ''Set Foreground color to selected, and set BackgroundColor to the inverse-selected color.
                .ElementClass_Obj.FontColor = rscColorSelected.MSNetColor
                ''Inverse color!!   ---12/30/2022 td
                .ElementClass_Obj.Back_Color = rscColorSelected.GetInverseMSColor()

                .RefreshElementImage()

            End With ''End of ""With mod_controlFieldOrTextV4""

            ''Added 12/30/2022 td
            mod_enumForeOrBack = EnumForeOrBackground.Foreground_AndBackInverse

            ''Undo Pop Stack (Last In, First Out)
            ''   is built using Color-Enum pairs (tuples). 
            ''   ----8/23/2022 
            Dim objNewUndoTuple As Tuple(Of Drawing.Color, EnumForeOrBackground)
            objNewUndoTuple =
                New Tuple(Of Drawing.Color,
                EnumForeOrBackground)(mod_msColorLastReplaced,
                                      mod_enumForeOrBack)
            ''Add the Undo Color-Enum Pair to the popstack. 
            mod_stackUndoTuples.Push(objNewUndoTuple)

        End With ''End of ""With rscLabelDisplayColorSelected""

    End Sub

    Private Sub ButtonApplyBF_Click(sender As Object, e As EventArgs) Handles ButtonApplyBF.Click

        ''Added 12/30/2022 thomas  
        Dim rscColorSelected As RSCColor ''Added 8/23/2022

        With rscLabelDisplayColorSelected

            rscColorSelected = .RSCDisplayColor

            With mod_controlFieldOrTextV4
                ''Save module-level variables. 
                mod_msColorLastSelected = rscColorSelected.MSNetColor
                mod_rscColorLastSelected = rscColorSelected
                mod_msColorLastReplaced = .ElementClass_Obj.Back_Color

                ''Set Background color to selected, and set FontColor to the inverse-selected color.
                .ElementClass_Obj.Back_Color = rscColorSelected.MSNetColor
                ''Inverse color!!   ---12/30/2022 td
                .ElementClass_Obj.FontColor = rscColorSelected.GetInverseMSColor()

                .RefreshElementImage()

            End With ''End of ""With mod_controlFieldOrTextV4""

            ''Added 12/30/2022 td
            mod_enumForeOrBack = EnumForeOrBackground.Background_AndForeInverse

            ''Undo Pop Stack (Last In, First Out)
            ''   is built using Color-Enum pairs (tuples). 
            ''   ----8/23/2022 
            Dim objNewUndoTuple As Tuple(Of Drawing.Color, EnumForeOrBackground)
            objNewUndoTuple =
                New Tuple(Of Drawing.Color,
                EnumForeOrBackground)(mod_msColorLastReplaced,
                                      mod_enumForeOrBack)
            ''Add the Undo Color-Enum Pair to the popstack. 
            mod_stackUndoTuples.Push(objNewUndoTuple)

        End With ''End of ""With rscLabelDisplayColorSelected""


    End Sub


End Class