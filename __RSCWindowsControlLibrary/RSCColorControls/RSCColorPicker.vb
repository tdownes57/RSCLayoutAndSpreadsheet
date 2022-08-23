''
''Added 7/6/2022
''
Imports ciBadgeInterfaces ''Added 8/10/2022 td

Public Class RSCColorPicker
    ''
    ''Added 7/6/2022
    ''
    ''July9 2022''Private Property DisplayColor As Color
    Public Property DisplayRSCColor As RSCColor
    Private mboolLoading As Boolean

    ''Public Overrides Property BackColor As Color
    ''    Get
    ''        ''Return MyBase.BackColor
    ''        Return RscColorDisplay1.DisplayRSCColor.MSNetColor

    ''    End Get
    ''    Set(value As Color)
    ''        ''---MyBase.BackColor = value
    ''        RscColorDisplay1.DisplayRSCColor = New RSCColor(value)

    ''    End Set
    ''End Property

    Public Sub LoadAndDisplayRSCColor(par_rsccolor As ciBadgeInterfaces.RSCColor)
        ''
        ''Added 8/22/2022 
        ''
        Me.DisplayRSCColor = par_rsccolor
        Me.RscColorDisplay1.DisplayRSCColor = par_rsccolor
        Me.RscColorDisplay1.LoadAndDisplayRSCColor(par_rsccolor)

    End Sub ''End of ""Public Sub LoadAndDisplayRSCColor""



    Private Sub LinkLabelOpenDialog_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelOpenDialog.LinkClicked
        ''
        ''Added 7/8/2022
        ''
        Dim diagColor As ColorDialog
        diagColor = ColorDialog1

        diagColor.AnyColor = True
        diagColor.ShowDialog()

        mboolLoading = True

        ''July9 2022 ''Me.DisplayRSCColor = diagColor.Color
        Me.DisplayRSCColor = New RSCColor(diagColor.Color)
        RscColorDisplay1.LoadAndDisplayRSCColor(Me.DisplayRSCColor)

        Dim intDisplayColorArgb As Double
        Dim strDisplayColor As String

        intDisplayColorArgb = Me.DisplayRSCColor.MSNetColor.ToArgb
        strDisplayColor = Me.DisplayRSCColor.MSNetColor.ToString

        HScrollBar1Alpha.Value = Me.DisplayRSCColor.MSNetColor.A
        HScrollBar2Red.Value = Me.DisplayRSCColor.MSNetColor.R
        HScrollBar3Green.Value = Me.DisplayRSCColor.MSNetColor.G
        HScrollBar4Blue.Value = Me.DisplayRSCColor.MSNetColor.B

ExitHander:
        Application.DoEvents()
        mboolLoading = False

    End Sub

    Private Sub HScrollBar1Alpha_ValueChanged(sender As Object, e As EventArgs) Handles HScrollBar1Alpha.ValueChanged

        ''Added 7/8/2022 
        If (mboolLoading) Then Exit Sub

        Dim newColor As Drawing.Color
        Dim strName As String ''Added 7/09/2022
        Dim strDescription As String ''Added 7/09/2022

        ''Added 7/09/2022
        strName = Me.DisplayRSCColor.Name
        strDescription = Me.DisplayRSCColor.Description

        newColor = New Drawing.Color()
        newColor = Color.FromArgb(HScrollBar1Alpha.Value,
                                  HScrollBar2Red.Value,
                                  HScrollBar3Green.Value,
                                  HScrollBar4Blue.Value)

        ''July9 ''Me.DisplayColor = newColor
        Me.DisplayRSCColor = New RSCColor(newColor, strName, strDescription)
        RscColorDisplay1.LoadAndDisplayRSCColor(Me.DisplayRSCColor)

    End Sub


    Private Sub HScrollBar2Red_ValueChanged(sender As Object, e As EventArgs) Handles HScrollBar2Red.ValueChanged
        ''Added 7/8/2022 
        If (mboolLoading) Then Exit Sub

        Dim newColor As Drawing.Color
        Dim strName As String ''Added 7/09/2022
        Dim strDescription As String ''Added 7/09/2022

        ''Added 7/09/2022
        strName = Me.DisplayRSCColor.Name
        strDescription = Me.DisplayRSCColor.Description

        newColor = New Drawing.Color()
        newColor = Color.FromArgb(HScrollBar1Alpha.Value,
                                  HScrollBar2Red.Value,
                                  HScrollBar3Green.Value,
                                  HScrollBar4Blue.Value)

        ''--Me.Display = newColor
        ''--RscColorDisplay1.LoadColor(Me.DisplayColor)
        Me.DisplayRSCColor = New RSCColor(newColor, strName, strDescription)
        RscColorDisplay1.LoadAndDisplayRSCColor(Me.DisplayRSCColor)

    End Sub


    Private Sub HScrollBar3Green_ValueChanged(sender As Object, e As EventArgs) Handles HScrollBar3Green.ValueChanged
        ''Added 7/8/2022 
        If (mboolLoading) Then Exit Sub

        Dim newColor As Drawing.Color
        Dim strName As String ''Added 7/09/2022
        Dim strDescription As String ''Added 7/09/2022

        ''Added 7/09/2022
        strName = Me.DisplayRSCColor.Name
        strDescription = Me.DisplayRSCColor.Description

        newColor = New Drawing.Color()
        newColor = Color.FromArgb(HScrollBar1Alpha.Value,
                                  HScrollBar2Red.Value,
                                  HScrollBar3Green.Value,
                                  HScrollBar4Blue.Value)

        ''--Me.Display = newColor
        ''--RscColorDisplay1.LoadColor(Me.DisplayColor)
        Me.DisplayRSCColor = New RSCColor(newColor, strName, strDescription)
        RscColorDisplay1.LoadAndDisplayRSCColor(Me.DisplayRSCColor)

    End Sub


    Private Sub HScrollBar4Blue_ValueChanged(sender As Object, e As EventArgs) Handles HScrollBar4Blue.ValueChanged
        ''Added 7/8/2022 
        If (mboolLoading) Then Exit Sub

        Dim newColor As Drawing.Color
        Dim strName As String ''Added 7/09/2022
        Dim strDescription As String ''Added 7/09/2022

        ''Added 7/09/2022
        strName = Me.DisplayRSCColor.Name
        strDescription = Me.DisplayRSCColor.Description

        newColor = New Drawing.Color()
        newColor = Color.FromArgb(HScrollBar1Alpha.Value,
                                  HScrollBar2Red.Value,
                                  HScrollBar3Green.Value,
                                  HScrollBar4Blue.Value)

        ''--Me.Display = newColor
        ''--RscColorDisplay1.LoadColor(Me.DisplayColor)
        Me.DisplayRSCColor = New RSCColor(newColor, strName, strDescription)
        RscColorDisplay1.LoadAndDisplayRSCColor(Me.DisplayRSCColor)

    End Sub

    Private Sub checkAdvancedControls_CheckedChanged(sender As Object, e As EventArgs) Handles checkAdvancedControls.CheckedChanged

        ''Added 8/22/2002
        For Each eachControl As Control In Me.Controls
            ''Added 8/22/2002
            If (eachControl.Tag = "advanced") Then
                ''Toggle the visibility of the "advanced" control.
                eachControl.Visible = checkAdvancedControls.Checked
            End If

        Next eachControl

    End Sub
End Class
