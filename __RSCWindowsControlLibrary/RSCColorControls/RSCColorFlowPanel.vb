Option Explicit On ''Added 8/30/2022
Option Strict On ''Added 8/30/2022

Imports ciBadgeInterfaces ''Added 8/30/2022
''
''Added 8/30/2022
''
Public Class RSCColorFlowPanel
    ''
    ''Added 8/30/2022
    ''
    Public Shared Event ColorSelected(par_color As RSCColor) ''Added 10/24/2022
    Public Event Color_Selected(par_color As RSCColor) ''Added 11/27/2022
    Public Event Colors_OpenAddRemove(sender As Object, e As EventArgs) ''Added 11/27/2022

    Private mod_listMSColors_NotUsed As New List(Of Drawing.Color)
    Private Shared mboolConfirm As Boolean ''Added 10/24/2022

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    ''11/21/2022 Public Sub LoadColors_FromList(par_controlPanel As ContainerControl,
    ''                               par_listOfRSCColors As List(Of RSCColor))
    ''    ''
    ''    ''Added this "Alias" function, 11/19/2022 td 
    ''    ''
    ''    AddColors_FromList(par_controlPanel,
    ''                               par_listOfRSCColors, True)
    '' 
    ''End Sub


    Public Shared Property ConfirmColorSelection() As Boolean
        Get ''Added 10/24/2022
            Return mboolConfirm
        End Get
        Set(value As Boolean) ''Added 10/24/2022
            mboolConfirm = value
        End Set
    End Property


    Public ReadOnly Property Controls_RSCLabels() As ControlCollection
        Get
            ''Added 11/27/2022 td
            Return flowPanelDockFull.Controls
        End Get
    End Property


    Public Function ColorExistsInPanel(par_color As RSCColor) As Boolean
        ''
        ''Added 11/27/2022 
        ''
        Dim eachRSCLabel As RSCColorDisplayLabel ''Added 11/27/2022
        ''#1 Nov27 2022 ''For Each eachControl As RSCColorDisplayLabel In Me.Controls
        ''#2 Nov27 2022 ''For Each eachControl As RSCColorDisplayLabel In Me.Controls_RSCLabels
        For Each eachControl As Control In Me.Controls_RSCLabels
            If (TypeOf eachControl Is RSCColorDisplayLabel) Then
                eachRSCLabel = CType(eachControl, RSCColorDisplayLabel)
                If (eachRSCLabel.RSCDisplayColor.Matches(par_color)) Then
                    Return True
                End If ''End of ""If (eachRSCLabel.RSCDisplayColor.Matches(par_color)) Then""
            End If ''End of ""If (TypeOf eachControl Is RSCColorDisplayLabel) Then""
        Next eachControl
        Return False
    End Function ''End of ""Public Function ColorExistsInPanel""


    Public Sub AddColor(par_color As RSCColor) ''#2 11/01/2022 par_panel As RSCColorFlowPanel)
        ''#1 11/01/2022 Public Sub AddColor(par_color As RSCColor, par_panel As FlowLayoutPanel)
        ''
        ''Added 10/24/2022 
        ''
        Dim bColorAlreadyExists As Boolean ''Added 11/27/2022 
        ''Added 11/27/2022
        bColorAlreadyExists = ColorExistsInPanel(par_color)
        If (bColorAlreadyExists) Then Exit Sub

        ''#1 11/1/2022 With FlowLayoutPanel1
        ''#1 11/1/2022 With par_panel
        With flowPanelDockFull

            Dim newLabel As New RSCColorDisplayLabel
            newLabel.BackColor = par_color.MSNetColor ''each_colorMS
            newLabel.MSNetColorName = par_color.MSNetColorName
            newLabel.Text = par_color.MSNetColorName ''each_colorMS.Name
            newLabel.Visible = True
            newLabel.Width = LinkLabelAddColor1.Width ''Added9/30/2022
            newLabel.Height = LinkLabelAddColor1.Height ''Added9/30/2022
            AddHandler newLabel.ColorClick, AddressOf NetDrawingColor_Click
            .Controls.Add(newLabel) ''Added 8/30/2022
            .Refresh() ''Added 11/01/2022 

            ''Added 11/27/2022
            AddHandler newLabel.ColorClick, AddressOf NetDrawingColor_Click

        End With ''End of ""With flowPanelDockFull""

    End Sub ''End of ""Public Sub AddColor(par_color As RSCColor, par_panel as FlowLayoutPanel)""


    Public Sub RemoveColor(par_color As RSCColor)
        ''
        ''Added 10/24/2022 
        ''
        Dim controlToRemove As RSCColorDisplayLabel = Nothing
        Dim controlToRemove_ProbablyNotNeeded As RSCColorDisplayLabel = Nothing

        For Each eachControl As RSCColorDisplayLabel In Me.Controls
            If (eachControl.RSCDisplayColor.Matches(par_color)) Then
                If (controlToRemove Is Nothing) Then
                    controlToRemove = eachControl
                Else
                    ''Just in case we have a duplicate somehow. 
                    controlToRemove_ProbablyNotNeeded = eachControl
                End If ''End of If (controlToRemove Is Nothing) Then... Else...
            End If
        Next eachControl

        If (controlToRemove IsNot Nothing) Then Me.Controls.Remove(controlToRemove)
        If (controlToRemove_ProbablyNotNeeded IsNot Nothing) Then Me.Controls.Remove(controlToRemove_ProbablyNotNeeded)

    End Sub ''End of ""Public Sub RemoveColor(par_color As RSCColor)""


    Public Sub AddColors_AllPossibleColors(Optional pbOmitUIRelatedColors As Boolean = True,
                                           Optional pbClearExistingControls As Boolean = True)
        ''
        ''Added 8/30/2022 td 
        ''
        Dim arrayOfColorNames As String()
        Dim each_colorMS As Drawing.Color
        Dim intNumberOfColors As Integer ''Added 8/30/2022
        Dim boolOmitUI As Boolean
        Dim countColors As Integer ''Added 9/30/2022 

        boolOmitUI = pbOmitUIRelatedColors

        With flowPanelDockFull.Controls

            ''Added 9/30/2022 thomas downes
            If (pbClearExistingControls) Then
                .Clear() ''Remove existing controls.
            End If ''\end of ""If (pbClearExistingControls) Then""

            arrayOfColorNames = [Enum].GetNames(GetType(System.Drawing.KnownColor))
            intNumberOfColors = arrayOfColorNames.Length ''Added 8/30/2022

            ''
            ''Loop through the colors. 
            ''
            For Each each_colorName As String In arrayOfColorNames

                countColors += 1
                If (boolOmitUI AndAlso countColors <= 26) Then Continue For ''Added 9/30/2022 

                If (boolOmitUI AndAlso each_colorName = "Control") Then Continue For
                If (boolOmitUI AndAlso each_colorName = "ControlLight") Then Continue For
                If (boolOmitUI AndAlso each_colorName = "ControlDark") Then Continue For
                If (boolOmitUI AndAlso each_colorName = "Control") Then Continue For
                If (boolOmitUI AndAlso each_colorName = "Control") Then Continue For
                If (boolOmitUI AndAlso each_colorName = "Control") Then Continue For
                ''Added 9/30/2022 
                If (boolOmitUI AndAlso each_colorName = "Highlight") Then Continue For


                each_colorMS = Drawing.Color.FromName(each_colorName)

                Dim newLabel As New RSCColorDisplayLabel
                ''10/28/2022 newLabel.BackColor = each_colorMS
                ''10/28/2022 newLabel.Text = each_colorMS.Name
                newLabel = RSCColorDisplayLabel.GetLabel(each_colorMS) ''Added 10/28/2022

                newLabel.Visible = True
                newLabel.Width = LinkLabelAddColor1.Width ''Added9/30/2022
                newLabel.Height = LinkLabelAddColor1.Height ''Added9/30/2022

                AddHandler newLabel.ColorClick, AddressOf NetDrawingColor_Click
                .Add(newLabel) ''Added 8/30/2022 

            Next each_colorName

        End With ''End of ""With FlowLayoutPanel1.Controls""

        ''Added 9/30/2022 
        intNumberOfColors = flowPanelDockFull.Controls.Count
        flowPanelDockFull.Visible = True
        flowPanelDockFull.Refresh()

    End Sub ''Endof ""Public Sub AddColors_AllPossibleColors()""


    Public Sub RefreshColors_FromList(par_listOfRSCColors As List(Of RSCColor))
        ''
        ''Added this "Alias" function, 11/19/2022 td 
        ''
        AddColors_FromList(par_listOfRSCColors, True)

    End Sub ''Public Sub RefreshColors_FromList(par_listOfRSCColors As List(Of RSCColor)


    Public Sub LoadColors_FromList(par_listOfRSCColors As List(Of RSCColor))
        ''
        ''Added this "Alias" function, 11/19/2022 td 
        ''
        AddColors_FromList(par_listOfRSCColors, True)

    End Sub ''Public Sub LoadColors_FromList(par_listOfRSCColors As List(Of RSCColor)


    Public Sub AddColors_FromList(par_listOfRSCColors As List(Of RSCColor),
                       Optional pbClearExistingControls As Boolean = False,
                       Optional par_FlowPanel As FlowLayoutPanel = Nothing)
        ''
        ''Added this overloaded function, 11/21/2022 td 
        ''
        ''11/2022 AddColors_FromList(flowPanelDockFull, par_listOfRSCColors, True)
        RefreshColors_FromList(flowPanelDockFull, par_listOfRSCColors)

    End Sub ''Public Sub AddColors_FromList(par_listOfRSCColors As List(Of RSCColor)


    Public Sub RefreshColors_FromList(par_FlowPanel As FlowLayoutPanel,
                                         par_listOfRSCColors As List(Of RSCColor))
        ''11/27/2022 Public Shared Sub RefreshColors_FromList
        ''          11/21/2022 Optional pbClearExistingControls As Boolean = False)
        ''
        ''Added 8/30/2022 td 
        ''
        ''Dim arrayOfColorNames As String()
        Dim each_colorMS As Drawing.Color
        Dim intNumberOfColors As Integer ''Added 8/30/2022
        ''Dim boolOmitUI As Boolean
        Dim countColors As Integer ''Added 9/30/2022 

        Dim pbClearExistingControls As Boolean ''Added 11/21/2022 
        pbClearExistingControls = True ''Added 11/21/2022 

        ''boolOmitUI = pbOmitUIRelatedColors
        ''Added 11/21/2022
        ''#2 11/21/2022 If (par_FlowPanel Is Nothing) Then ''Added 11/21/2022
        ''#2 11/21/2022   par_FlowPanel = flowPanelDockFull
        ''#2 11/21/2022 End If

        ''11/21/2022 With flowPanelDockFull.Controls
        With par_FlowPanel ''.Controls

            ''Added 9/30/2022 thomas downes
            If (pbClearExistingControls) Then
                ''11/21/2022 .Controls.Clear() ''Remove existing controls.
                Dim listRSCControlsToDelete As New List(Of RSCColorDisplayLabel)
                For Each each_ctl As Control In .Controls
                    If (TypeOf each_ctl Is RSCColorDisplayLabel) Then
                        listRSCControlsToDelete.Add(CType(each_ctl, RSCColorDisplayLabel))
                    End If
                Next each_ctl
                ''Remove all of the listed controls. 
                For Each each_ctl As Control In listRSCControlsToDelete
                    .Controls.Remove(each_ctl)
                Next each_ctl
            End If ''\end of ""If (pbClearExistingControls) Then""

            ''arrayOfColorNames = [Enum].GetNames(GetType(System.Drawing.KnownColor))
            ''intNumberOfColors = arrayOfColorNames.Length ''Added 8/30/2022

            ''
            ''Loop through the colors. 
            ''
            For Each each_RSCColor As RSCColor In par_listOfRSCColors

                countColors += 1
                each_colorMS = each_RSCColor.MSNetColor
                If (each_colorMS = Color.Empty) Then each_colorMS = Color.Black

                ''11/2022 #2 Dim newLabel As New RSCColorDisplayLabel
                ''11/2022 #2 newLabel.BackColor = each_colorMS
                ''11/2022 newLabel.Text = each_colorMS.Name
                ''11/2022 #2 newLabel.Text = each_RSCColor.MSNetColorName
                ''11/2022 #2 newLabel.Visible = True
                ''11/21/2022 newLabel.Width = LinkLabelAddColor1.Width ''Added9/30/2022
                ''11/21/2022 newLabel.Height = LinkLabelAddColor1.Height ''Added9/30/2022

                ''Added 11/21/2022 
                Dim newLabel As RSCColorDisplayLabel
                newLabel = RSCColorDisplayLabel.GetLabel(each_colorMS)

                AddHandler newLabel.ColorClick, AddressOf NetDrawingColor_Click
                .Controls.Add(newLabel) ''Added 8/30/2022 
                ''Added 11/02/2022 td 
                newLabel.LoadAndDisplayRSCColor(each_RSCColor)

            Next each_RSCColor

        End With ''End of ""With FlowLayoutPanel1.Controls""

        ''Added 9/30/2022 
        ''11/21/2022 intNumberOfColors = flowPanelDockFull.Controls.Count
        ''11/21/2022 flowPanelDockFull.Visible = True
        intNumberOfColors = par_FlowPanel.Controls.Count
        par_FlowPanel.Visible = True
        ''11/2022 flowPanelDockFull.Refresh()
        ''flowPanelDockFull.Invalidate()

    End Sub ''Endof ""Public Sub RefreshColors_FromList()""


    Public Sub AddColors_BlackAndWhite()
        ''
        ''Added 8/30/2022 td 
        ''
        Dim newLabel_Black As New RSCColorDisplayLabel
        Dim newLabel_White As New RSCColorDisplayLabel
        Dim colorMS_Black As Drawing.Color
        Dim colorMS_White As Drawing.Color

        colorMS_Black = Drawing.Color.Black
        colorMS_White = Drawing.Color.White

        With flowPanelDockFull.Controls

            ''Black 
            newLabel_Black.BackColor = colorMS_Black
            newLabel_Black.Text = colorMS_Black.Name
            newLabel_Black.Visible = True
            AddHandler newLabel_Black.ColorClick, AddressOf NetDrawingColor_Click
            .Add(newLabel_Black) ''Added 8/30/2022 
            newLabel_Black.Visible = True

            ''White 
            newLabel_White.BackColor = colorMS_White
            newLabel_White.Text = colorMS_White.Name
            newLabel_White.Visible = True
            AddHandler newLabel_White.ColorClick, AddressOf NetDrawingColor_Click
            .Add(newLabel_White) ''Added 8/30/2022 
            newLabel_White.Visible = True

        End With ''End of ""With FlowLayoutPanel1.Controls""

    End Sub ''End of ""Public Sub AddColors_BlackAndWhite()""


    Public Sub LoadListOfColors_Obselete()
        ''
        '' Added 3/4/2022 thomas downes
        ''
        If (mod_listMSColors_NotUsed Is Nothing) Then
            mod_listMSColors_NotUsed = New List(Of Drawing.Color)
        End If ''If (mod_listMSColors Is Nothing) Then

        With mod_listMSColors_NotUsed

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


        End With ''ENd of ""With mod_listMSColors_NotUsed""

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

        flowPanelDockFull.Controls.Clear()

        For Each each_color In mod_listMSColors_NotUsed ''List(Of Drawing.Color)

            Dim newLabel As New RSCColorDisplayLabel
            newLabel.BackColor = each_color
            newLabel.Text = each_color.Name
            newLabel.Visible = True
            AddHandler newLabel.ColorClick, AddressOf NetDrawingColor_Click

            ''newLabel.ToolTip
            ''Me.ToolTip1.SetToolTip(Me.ButtonBackground, "Set Background Color of the Element")
            Me.ToolTip1.SetToolTip(newLabel, each_color.Name)

            flowPanelDockFull.Controls.Add(newLabel)

        Next each_color


    End Sub ''End of ""Public Sub LoadListOfColors_Obselete()""




    Public Sub AddLinkLabelForAddingColors()
        ''
        ''Added 8/30/2022 td 
        ''
        Dim bMissingFromFlowLayout As Boolean
        LinkLabelAddColor1.Visible = True
        With flowPanelDockFull.Controls
            bMissingFromFlowLayout = (Not .Contains(LinkLabelAddColor1))
            If (bMissingFromFlowLayout) Then
                .Add(LinkLabelAddColor1)
            End If ''End of ""If (bMissingFromFlowLayout) Then""
        End With ''End of ""With FlowLayoutPanel1.Controls""

    End Sub ''Endof ""Public Sub AddLinkLabelForAddingColors()""


    Public Sub NetDrawingColor_Click(sender As Object, e As EventArgs)
        ''Nov17 2022''Public Shared Sub NetDrawingColor_Click
        ''
        ''8/22/2022 thomas downes
        ''
        ''10/2022 If (Not Me.ConfirmColorSelection) Then Exit Sub

        ''10/28/2022 Dim objFormToShow As __RSCWindowsControlLibrary.FormRSCColorConfirm
        Dim objFormToShow As __RSCWindowsControlLibrary.FormRSCColorConfirmTiny
        Dim strColorName As String
        Dim controlRSCColorLabel As RSCColorDisplayLabel
        Static controlRSCColorLabel_Prior As RSCColorDisplayLabel
        Dim mscolorSelected As Drawing.Color
        Dim rscColorSelected As RSCColor = Nothing
        Dim boolUserCancels As Boolean ''Added 10/28/2022

        controlRSCColorLabel = CType(sender, RSCColorDisplayLabel)
        strColorName = controlRSCColorLabel.Text
        mscolorSelected = controlRSCColorLabel.BackColor
        rscColorSelected = controlRSCColorLabel.RSCDisplayColor

        If (rscColorSelected Is Nothing) Then
            System.Diagnostics.Debugger.Break()
            __RSC_Error_Logging.RSCErrorLogging.Log(23, "NetDrawingColor_Click", "RSC Color is missing")
        End If ''End fo ""If (rscColorSelected Is Nothing) Then""

        ''10/28/2022 objFormToShow = New FormRSCColorConfirm(mscolorSelected, strColorName)
        ''11/21/2022 objFormToShow = New FormRSCColorConfirmTiny(mscolorSelected, strColorName)
        objFormToShow = New FormRSCColorConfirmTiny(rscColorSelected)

        With objFormToShow

            ''Show the modal UI to the user. 
            If (ConfirmColorSelection) Then ''Added 10/25/2022
                ''Show the modal UI to the user. 
                .ShowDialog()
            ElseIf (FormRSCColorConfirmTiny.DontShowDialogAgain) Then ''Added 10/28/2022
                ''We are currently skipping the confirmation-of-color step.
                .Output_Cancelled = False ''False, not a cancellation, but rather
                ''  a skipping-of-confirmation.--10/28/2022
            Else
                ''We are currently skipping the confirmation-of-color step,
                ''  and so we will proceed. This is __NOT__ a cancellation,
                ''  so set the following Boolean to FALSE.
                .Output_Cancelled = False ''False, not a cancellation, but a skipping-of-confirmation.
            End If ''Endof ""If (Me.ConfirmColorSelection) Then... Else...""

            If (.Output_Cancelled) Then
                ''
                ''User has changed their mind.  Don't change anything.
                ''
                boolUserCancels = True

            Else

                rscColorSelected = .Output_RSCColor

                ''8/30/2022 rscLabelDisplayColorSelected.RSCDisplayColor = rscColorSelected
                ''8/30/2022 rscLabelDisplayColorSelected.Visible = True ''Added 8/28/2022 
                controlRSCColorLabel.BorderStyle = BorderStyle.FixedSingle ''Added 8/30/2022

                ''Clear the Border Style from the previous label control. ---8/30/2022
                If (controlRSCColorLabel_Prior IsNot Nothing) Then
                    ''Clear the Border Style from the previous label control. 
                    controlRSCColorLabel_Prior.BorderStyle = BorderStyle.None
                End If ''End of ""If (controlRSCColorLabel_Prior IsNot Nothing) Then""

            End If ''End of ""If (.Output_Cancelled) Then ... Else ...""  

        End With ''End of ""With objFormToShow""

        ''---End If ''End of ""If (Not objFormToShow.Output_Cancelled) Then""

ExitHandler:
        ''Prepare for next execution of this procedure. ---8/30/2022
        If (Not boolUserCancels) Then
            controlRSCColorLabel_Prior = controlRSCColorLabel
            RaiseEvent ColorSelected(rscColorSelected) ''Added 10/25/2022
            RaiseEvent Color_Selected(rscColorSelected) ''Added 11/27/2022 
            ''Added 11/27/2022 
            ''Nov27 2022''RaiseEvent controlRSCColorLabel.ColorClick(controlRSCColorLabel, New EventArgs)
        End If ''End of ""If (Not boolUserCancels) Then""

    End Sub ''End of ""Public Shared Sub NetDrawingColor_Click(sender As Object, e As EventArgs)""

    Private Sub LinkLabelAddColor1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelAddColor1.LinkClicked

        ''Added 11/27/2022 thomas d.
        RaiseEvent Colors_OpenAddRemove(Me, New EventArgs)

    End Sub
End Class
