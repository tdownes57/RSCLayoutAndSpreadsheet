''
'' Added 3/4/2022 thomas downes
''
Imports ciBadgeElements ''Added 8/01/2022 td
Imports ciBadgeInterfaces ''Added 8/06/2022 thomas downes
Imports __RSCWindowsControlLibrary ''Added 8/07/2022 thomas 

Public Enum EnumForeOrBackground
    Undetermined
    Foreground
    Background
End Enum

Public Class Dialog_BaseChooseColor
    ''
    '' Added 3/4/2022 Thomas Downes
    ''
    ''8/07/2022 td''Private mod_colors As New List(Of Drawing.Color)
    Private mod_listRSCColors As HashSet(Of RSCColor)
    Private mod_listMSColors As List(Of Drawing.Color)


    ''Added 8/22/2022 td
    Private mod_rscColorLastSelected As RSCColor
    Private mod_msColorLastSelected As Drawing.Color
    Private mod_msColorLastReplaced As Drawing.Color
    Private mod_enumForeOrBack As EnumForeOrBackground

    Public Sub New(par_control As CtlGraphicFieldOrTextV4,
                   par_listFontFamilyNames As HashSet(Of String),
                   par_listRSCColors As HashSet(Of RSCColor),
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
                   par_listRSCColors,
                   par_control.ElementBase,
                   par_infoElementBase,
                   par_designer, par_events,
                   par_imageBadge)

        ' This call is required by the designer.
        InitializeComponent()


    End Sub


    Private Sub Dialog_BaseChooseColor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        '' Added 3/4/2022 thomas downes
        ''
        If (mod_listMSColors Is Nothing) Then
            mod_listMSColors = New List(Of Drawing.Color)
        End If ''If (mod_listMSColors Is Nothing) Then

        With mod_listMSColors

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


        End With

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

        FlowLayoutColors1.Controls.Clear()

        For Each each_color In mod_listMSColors ''List(Of Drawing.Color)

            Dim newLabel As New RSCColorDisplayLabel
            newLabel.BackColor = each_color
            newLabel.Text = each_color.Name
            newLabel.Visible = True
            AddHandler newLabel.ColorClick, AddressOf NetDrawingColor_Click

            ''newLabel.ToolTip
            ''Me.ToolTip1.SetToolTip(Me.ButtonBackground, "Set Background Color of the Element")
            Me.ToolTip1.SetToolTip(newLabel, each_color.Name)

            FlowLayoutColors1.Controls.Add(newLabel)

        Next each_color

    End Sub ''Handles Form_Load 


    Private Sub LinkLabelAddColors_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelAddColors.LinkClicked

        ''Added 8/7/2022 thomas downes
        Dim objFormToShow As __RSCWindowsControlLibrary.RSCBrowseExistingColors

        objFormToShow = New RSCBrowseExistingColors(mod_listRSCColors)
        objFormToShow.ShowDialog()

    End Sub


    Private Sub NetDrawingColor_Click(sender As Object, e As EventArgs)
        ''
        ''8/22/2022 thomas downes
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

            End If ''End of ""If (Not .Output_Cancelled) Then""  

        End With ''End of ""With objFormToShow""


        ''---End If ''End of ""If (Not objFormToShow.Output_Cancelled) Then""

    End Sub

    Private Sub ButtonBackground_Click(sender As Object, e As EventArgs) Handles ButtonBackground.Click

        ''Added 8/22/2022 thomas  
        With rscLabelDisplayColorSelected

            mod_msColorLastSelected = .BackColor
            mod_rscColorLastSelected = .RSCDisplayColor

            With mod_controlFieldOrTextV4
                mod_msColorLastReplaced = .ElementClass_Obj.Back_Color
                .ElementClass_Obj.Back_Color = .BackColor
                .RefreshElementImage()
            End With
            mod_enumForeOrBack = EnumForeOrBackground.Background

        End With

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

        End With ''End of ""With rscLabelDisplayColorSelected""


    End Sub

    Private Sub ButtonUndo_Click(sender As Object, e As EventArgs) Handles ButtonUndo.Click

        ''Added 8/22/2022 thomas  
        With mod_controlFieldOrTextV4
            If (mod_enumForeOrBack = EnumForeOrBackground.Foreground) Then
                .ElementClass_Obj.FontColor = mod_msColorLastReplaced
            ElseIf (mod_enumForeOrBack = EnumForeOrBackground.Background) Then
                .ElementClass_Obj.Back_Color = mod_msColorLastReplaced
            End If
        End With ''End of ""With mod_controlFieldOrTextV4""

    End Sub

End Class