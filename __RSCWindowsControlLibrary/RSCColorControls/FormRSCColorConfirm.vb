''
''Added 8/22/2022 
''
Imports ciBadgeInterfaces ''Added 11/27/2022 td

Public Class FormRSCColorConfirm
    ''
    ''Added 8/22/2022 
    ''
    Private mod_msnetColor As Drawing.Color
    Private mod_rscColor As ciBadgeInterfaces.RSCColor

    Public Output_RSCColor As ciBadgeInterfaces.RSCColor
    Public Output_Cancelled As Boolean


    Public Sub New(par_msnetColor As Drawing.Color, par_strColorName As String)


        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mod_msnetColor = par_msnetColor
        mod_rscColor = New ciBadgeInterfaces.RSCColor(par_strColorName, par_msnetColor)

        ''Aug22 2022 rscColorPicker1.BackColor = par_msnetColor
        textboxColorName.Text = par_strColorName

        ''Added 8/28/2022 
        Me.BackColor = par_msnetColor

        ''Added 11/27/2022
        LabelMicrosoftName.Text = par_msnetColor.Name
        LabelMicrosoftName.Visible = True
        LabelMSNetNameCaption.Visible = True

    End Sub


    Public Sub New(par_rscColor As rsccolor)


        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mod_msnetColor = par_rscColor.MSNetColor
        mod_rscColor = par_rscColor
        textboxColorName.Text = par_rscColor.Name
        LabelMicrosoftName.Text = par_rscColor.MSNetColorName
        LabelMicrosoftName.Visible = True
        LabelMSNetNameCaption.Visible = True
        Me.BackColor = mod_msnetColor

    End Sub


    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click

        ''
        ''Added 8/22/2022 
        ''
        Me.Output_Cancelled = True
        Me.Close()

    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        ''
        ''Added 8/22/2022 
        ''
        Dim objRSCColor As ciBadgeInterfaces.RSCColor ''Added 8/22/2022

        ''8/23/2022 objRSCColor = New ciBadgeInterfaces.RSCColor(rscColorPicker1.BackColor,
        ''                                             textboxColorName.Text,
        ''                                             textboxDescription.Text)
        objRSCColor = rscColorPicker1.RSCColor_Output

ExitHandler:
        Me.Output_RSCColor = objRSCColor
        Me.Close()

    End Sub

    Private Sub FormRSCColorConfirm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 8/22/2022 
        ''
        rscColorPicker1.LoadAndDisplayRSCColor(mod_rscColor)

    End Sub
End Class