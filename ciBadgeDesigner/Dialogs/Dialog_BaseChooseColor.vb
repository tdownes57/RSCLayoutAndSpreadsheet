''
'' Added 3/4/2022 thomas downes
''

Public Class Dialog_BaseChooseColor
    ''
    '' Added 3/4/2022 thomas downes
    ''
    Private mod_colors As New List(Of Drawing.Color)

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

        FlowLayoutPanel1.Controls.Clear()

        For Each each_color In mod_colors ''List(Of Drawing.Color)

            Dim newLabel As New Label
            newLabel.BackColor = each_color
            newLabel.Text = each_color.Name
            newLabel.Visible = True
            FlowLayoutPanel1.Controls.Add(newLabel)

        Next each_color

    End Sub
End Class