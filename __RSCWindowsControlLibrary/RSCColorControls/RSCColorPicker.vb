''
''Added 7/6/2022
''
Imports ciBadgeInterfaces ''Added 8/10/2022 td

Public Class RSCColorPicker
    ''
    ''Added 7/6/2022
    ''
    ''July9 2022''Private Property DisplayColor As Color
    Public Property RSCColor_Input As RSCColor
    Public ReadOnly Property RSCColor_Output As RSCColor
        Get
            Return mod_RSCColor_Output ''Added 8/23/2022
        End Get
    End Property

    Private mboolLoading As Boolean
    Private mod_RSCColor_Output As RSCColor ''Added 8/23/2022

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
        Me.RSCColor_Input = par_rsccolor
        Me.RscColorDisplay1.DisplayRSCColor = par_rsccolor
        Me.RscColorDisplay1.LoadAndDisplayRSCColor(par_rsccolor)
        mod_RSCColor_Output = par_rsccolor ''The output color's default-value is the input color. 

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
        mod_RSCColor_Output = New RSCColor(diagColor.Color)
        RscColorDisplay1.LoadAndDisplayRSCColor(Me.RSCColor_Output)

        Dim intDisplayColorArgb As Double
        Dim strDisplayColor As String

        intDisplayColorArgb = Me.RSCColor_Output.MSNetColor.ToArgb
        strDisplayColor = Me.RSCColor_Output.MSNetColor.ToString

        HScrollBar1Alpha.Value = Me.RSCColor_Output.MSNetColor.A
        HScrollBar2Red.Value = Me.RSCColor_Output.MSNetColor.R
        HScrollBar3Green.Value = Me.RSCColor_Output.MSNetColor.G
        HScrollBar4Blue.Value = Me.RSCColor_Output.MSNetColor.B

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
        strName = Me.RSCColor_Input.Name
        strDescription = Me.RSCColor_Input.Description

        newColor = New Drawing.Color()
        newColor = Color.FromArgb(HScrollBar1Alpha.Value,
                                  HScrollBar2Red.Value,
                                  HScrollBar3Green.Value,
                                  HScrollBar4Blue.Value)

        ''July9 ''Me.DisplayColor = newColor
        mod_RSCColor_Output = New RSCColor(newColor, strName, strDescription)
        RscColorDisplay1.LoadAndDisplayRSCColor(Me.RSCColor_Output)

    End Sub


    Private Sub HScrollBar2Red_ValueChanged(sender As Object, e As EventArgs) Handles HScrollBar2Red.ValueChanged
        ''Added 7/8/2022 
        If (mboolLoading) Then Exit Sub

        Dim newColor As Drawing.Color
        Dim strName As String ''Added 7/09/2022
        Dim strDescription As String ''Added 7/09/2022

        ''Added 7/09/2022
        strName = Me.RSCColor_Input.Name
        strDescription = Me.RSCColor_Input.Description

        newColor = New Drawing.Color()
        newColor = Color.FromArgb(HScrollBar1Alpha.Value,
                                  HScrollBar2Red.Value,
                                  HScrollBar3Green.Value,
                                  HScrollBar4Blue.Value)

        ''--Me.Display = newColor
        ''--RscColorDisplay1.LoadColor(Me.DisplayColor)
        mod_RSCColor_Output = New RSCColor(newColor, strName, strDescription)
        RscColorDisplay1.LoadAndDisplayRSCColor(Me.RSCColor_Input)

    End Sub


    Private Sub HScrollBar3Green_ValueChanged(sender As Object, e As EventArgs) Handles HScrollBar3Green.ValueChanged
        ''Added 7/8/2022 
        If (mboolLoading) Then Exit Sub

        Dim newColor As Drawing.Color
        Dim strName As String ''Added 7/09/2022
        Dim strDescription As String ''Added 7/09/2022

        ''Added 7/09/2022
        strName = Me.RSCColor_Input.Name
        strDescription = Me.RSCColor_Input.Description

        newColor = New Drawing.Color()
        newColor = Color.FromArgb(HScrollBar1Alpha.Value,
                                  HScrollBar2Red.Value,
                                  HScrollBar3Green.Value,
                                  HScrollBar4Blue.Value)

        ''--Me.Display = newColor
        ''--RscColorDisplay1.LoadColor(Me.DisplayColor)
        mod_RSCColor_Output = New RSCColor(newColor, strName, strDescription)
        RscColorDisplay1.LoadAndDisplayRSCColor(Me.RSCColor_Output)

    End Sub


    Private Sub HScrollBar4Blue_ValueChanged(sender As Object, e As EventArgs) Handles HScrollBar4Blue.ValueChanged
        ''Added 7/8/2022 
        If (mboolLoading) Then Exit Sub

        Dim newColor As Drawing.Color
        Dim strName As String ''Added 7/09/2022
        Dim strDescription As String ''Added 7/09/2022

        ''Added 7/09/2022
        strName = Me.RSCColor_Input.Name
        strDescription = Me.RSCColor_Input.Description

        newColor = New Drawing.Color()
        newColor = Color.FromArgb(HScrollBar1Alpha.Value,
                                  HScrollBar2Red.Value,
                                  HScrollBar3Green.Value,
                                  HScrollBar4Blue.Value)

        ''--Me.Display = newColor
        ''--RscColorDisplay1.LoadColor(Me.DisplayColor)
        mod_RSCColor_Output = New RSCColor(newColor, strName, strDescription)
        RscColorDisplay1.LoadAndDisplayRSCColor(Me.RSCColor_Output)

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
