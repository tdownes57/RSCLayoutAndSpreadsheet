''
''Added 7/8/2022
''

Public Class RSCColorDisplay
    ''
    ''Added 7/8/2022
    ''
    Public Property DisplayColor As Drawing.Color


    Public Sub LoadColor(par_color As Drawing.Color)
        ''
        ''Added 7/8/2022 th9omas downes
        ''
        DisplayColor = par_color
        LabelForecolorLeft.ForeColor = par_color
        LabelForecolorRight.ForeColor = par_color
        LabelBackcolorBottom.BackColor = par_color
        LabelBackcolorTop.BackColor = par_color


    End Sub ''End of ""Public Sub LoadColor""    


    Private Sub LabelBottom_Click(sender As Object, e As EventArgs) Handles LabelBackcolorBottom.Click

    End Sub
End Class
