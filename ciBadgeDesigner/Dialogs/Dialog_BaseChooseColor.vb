''
'' Added 3/4/2022 thomas downes
''
Imports ciBadgeElements ''Added 8/01/2022 td
Imports ciBadgeInterfaces ''Added 8/06/2022 thomas downes
Imports __RSCWindowsControlLibrary ''Added 8/07/2022 thomas 

Public Class Dialog_BaseChooseColor
    ''
    '' Added 3/4/2022 Thomas Downes
    ''
    ''8/07/2022 td''Private mod_colors As New List(Of Drawing.Color)
    Private mod_listRSCColors As HashSet(Of RSCColor)
    Private mod_listMSColors As List(Of Drawing.Color)


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
            AddHandler newLabel.Click, AddressOf NetDrawingColor_Click

            ''newLabel.ToolTip
            ''Me.ToolTip1.SetToolTip(Me.ButtonBackground, "Set Background Color of the Element")
            Me.ToolTip1.SetToolTip(newLabel, each_color.Name)

            FlowLayoutColors1.Controls.Add(newLabel)

        Next each_color

    End Sub ''Handles Form_Load 

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ButtonForecolor.Click

    End Sub

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
        Dim objFormToShow As __RSCWindowsControlLibrary.RSCColorPicker




    End Sub




End Class