''
'' Added 3/4/2022 thomas downes
''
Imports ciBadgeElements ''Added 8/01/2022 td
Imports ciBadgeInterfaces ''Added 8/06/2022 thomas downes

Public Class Dialog_BaseChooseColor
    ''
    '' Added 3/4/2022 Thomas Downes
    ''
    Private mod_colors As New List(Of Drawing.Color)


    Public Sub New(par_control As CtlGraphicFieldOrTextV4,
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
        MyBase.New(par_control, par_control.ElementBase,
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
        mod_colors.Add(Drawing.Color.AliceBlue)
        mod_colors.Add(Drawing.Color.AntiqueWhite)
        mod_colors.Add(Drawing.Color.Brown)
        mod_colors.Add(Drawing.Color.BurlyWood)
        mod_colors.Add(Drawing.Color.CadetBlue)
        mod_colors.Add(Drawing.Color.Beige)
        mod_colors.Add(Drawing.Color.Bisque)
        mod_colors.Add(Drawing.Color.Black)
        mod_colors.Add(Drawing.Color.BlanchedAlmond)
        mod_colors.Add(Drawing.Color.Blue)
        mod_colors.Add(Drawing.Color.BlueViolet)
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

        FlowLayoutColors2.Controls.Clear()

        For Each each_color In mod_colors ''List(Of Drawing.Color)

            Dim newLabel As New Label
            newLabel.BackColor = each_color
            newLabel.Text = each_color.Name
            newLabel.Visible = True
            FlowLayoutColors2.Controls.Add(newLabel)

        Next each_color

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ButtonForecolor.Click

    End Sub
End Class