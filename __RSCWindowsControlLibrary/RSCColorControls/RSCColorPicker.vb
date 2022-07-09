''
''Added 7/6/2022
''
Public Class RSCColorPicker
    ''
    ''Added 7/6/2022
    ''
    Private Property DisplayColor As Color
    Private mboolLoading As Boolean

    Private Sub LinkLabelOpenDialog_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelOpenDialog.LinkClicked
        ''
        ''Added 7/8/2022
        ''
        Dim diagColor As ColorDialog
        diagColor = ColorDialog1

        diagColor.AnyColor = True
        diagColor.ShowDialog()

        mboolLoading = True

        Me.DisplayColor = diagColor.Color
        RscColorDisplay1.LoadColor(Me.DisplayColor)

        Dim intDisplayColorArgb As Double
        Dim strDisplayColor As String

        intDisplayColorArgb = Me.DisplayColor.ToArgb
        strDisplayColor = Me.DisplayColor.ToString

        HScrollBar1Alpha.Value = Me.DisplayColor.A
        HScrollBar2Red.Value = Me.DisplayColor.R
        HScrollBar3Green.Value = Me.DisplayColor.G
        HScrollBar4Blue.Value = Me.DisplayColor.B

ExitHander:
        Application.DoEvents()
        mboolLoading = False

    End Sub

    Private Sub HScrollBar1Alpha_ValueChanged(sender As Object, e As EventArgs) Handles HScrollBar1Alpha.ValueChanged

        ''Added 7/8/2022 
        If (mboolLoading) Then Exit Sub

        Dim newColor As Drawing.Color

        newColor = New Drawing.Color()
        newColor = Color.FromArgb(HScrollBar1Alpha.Value,
                                  HScrollBar2Red.Value,
                                  HScrollBar3Green.Value,
                                  HScrollBar4Blue.Value)

        Me.DisplayColor = newColor
        RscColorDisplay1.LoadColor(Me.DisplayColor)

    End Sub

    Private Sub HScrollBar2Red_ValueChanged(sender As Object, e As EventArgs) Handles HScrollBar2Red.ValueChanged
        ''Added 7/8/2022 
        If (mboolLoading) Then Exit Sub

        Dim newColor As Drawing.Color

        newColor = New Drawing.Color()
        newColor = Color.FromArgb(HScrollBar1Alpha.Value,
                                  HScrollBar2Red.Value,
                                  HScrollBar3Green.Value,
                                  HScrollBar4Blue.Value)

        Me.DisplayColor = newColor
        RscColorDisplay1.LoadColor(Me.DisplayColor)
    End Sub

    Private Sub HScrollBar3Green_ValueChanged(sender As Object, e As EventArgs) Handles HScrollBar3Green.ValueChanged
        ''Added 7/8/2022 
        If (mboolLoading) Then Exit Sub

        Dim newColor As Drawing.Color

        newColor = New Drawing.Color()
        newColor = Color.FromArgb(HScrollBar1Alpha.Value,
                                  HScrollBar2Red.Value,
                                  HScrollBar3Green.Value,
                                  HScrollBar4Blue.Value)

        Me.DisplayColor = newColor
        RscColorDisplay1.LoadColor(Me.DisplayColor)
    End Sub

    Private Sub HScrollBar4Blue_ValueChanged(sender As Object, e As EventArgs) Handles HScrollBar4Blue.ValueChanged
        ''Added 7/8/2022 
        If (mboolLoading) Then Exit Sub

        Dim newColor As Drawing.Color

        newColor = New Drawing.Color()
        newColor = Color.FromArgb(HScrollBar1Alpha.Value,
                                  HScrollBar2Red.Value,
                                  HScrollBar3Green.Value,
                                  HScrollBar4Blue.Value)

        Me.DisplayColor = newColor
        RscColorDisplay1.LoadColor(Me.DisplayColor)

    End Sub
End Class
