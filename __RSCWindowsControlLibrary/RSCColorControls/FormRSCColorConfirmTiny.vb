''
''Added 10/28/2022 
''
Imports ciBadgeInterfaces ''Added 10/28/022

Public Class FormRSCColorConfirmTiny
    ''
    ''Added 10/28/2022 
    ''
    Private mod_msnetColor As Drawing.Color
    Private mod_rscColor As ciBadgeInterfaces.RSCColor

    Public Output_RSCColor As ciBadgeInterfaces.RSCColor
    Public Output_Cancelled As Boolean
    Public Shared DontShowDialogAgain As Boolean ''Added 10/28/2022


    Public Sub New(par_msnetColor As Drawing.Color, par_strColorName As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mod_msnetColor = par_msnetColor
        mod_rscColor = New ciBadgeInterfaces.RSCColor(par_strColorName, par_msnetColor)

        ''Added 10/28/2022 td
        mod_rscColor.MSNetColorName = par_msnetColor.Name
        Me.Output_RSCColor = mod_rscColor

        ''Aug22 2022 rscColorPicker1.BackColor = par_msnetColor
        textboxMSColorName.Text = par_strColorName
        textboxRSCColorName.Text = par_strColorName

        ''Added 8/22/2022 
        ''10/28/2022 Me.BackColor = par_msnetColor
        Me.RscColorDisplayLabel1.LoadAndDisplayRSCColor(mod_rscColor)

    End Sub ''End of ""Public Sub New(par_msnetColor As Drawing.Color, ....


    Public Sub New(par_rscColor As RSCColor)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mod_rscColor = par_rscColor
        mod_msnetColor = par_rscColor.MSNetColor

        textboxMSColorName.Text = par_rscColor.MSNetColor.Name
        textboxRSCColorName.Text = par_rscColor.Name
        textboxRSCDescription.Text = par_rscColor.Description
        ''10/28/2022 Me.BackColor = mod_msnetColor

        ''Added 10/28/2022 
        Me.RscColorDisplayLabel1.LoadAndDisplayRSCColor(mod_rscColor)

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
        ''#2 10/28/2022 Dim objRSCColor As New ciBadgeInterfaces.RSCColor ''Added 8/22/2022

        ''8/23/2022 objRSCColor = New ciBadgeInterfaces.RSCColor(rscColorPicker1.BackColor,
        ''                                             textboxColorName.Text,
        ''                                             textboxDescription.Text)
        ''#1 10/28/2022 ''objRSCColor = rscColorPicker1.RSCColor_Output
        ''#2 10/28/2022 objRSCColor.MSNetColor = Me.mod_msnetColor
        ''#2 10/28/2022 objRSCColor.MSNetColorName = Me.mod_msnetColor.Name
        ''#2 10/28/2022 objRSCColor.Name = textboxRSCColorName.Text
        ''#2 10/28/2022 objRSCColor.Description = textboxRSCDescription.Text

        mod_rscColor.Name = textboxRSCColorName.Text
        mod_rscColor.Description = textboxRSCDescription.Text
        Me.Output_RSCColor = mod_rscColor
        ''Added 11/21/2022
        mod_rscColor.MSNetColorName = mod_rscColor.MSNetColor.Name

ExitHandler:
        Debug.Assert(mod_rscColor.MSNetColorName =
                     mod_rscColor.MSNetColor.Name) ''Added 10/28/2022 
        Me.Output_RSCColor = mod_rscColor ''10/28/2022 objRSCColor
        Me.Close()

    End Sub

    Private Sub FormRSCColorConfirm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 8/22/2022 
        ''
        ''10/29/2022 rscColorPicker1.LoadAndDisplayRSCColor(mod_rscColor)
        RscColorDisplayLabel1.LoadAndDisplayRSCColor(mod_rscColor)

    End Sub

    Private Sub checkDontShowAgain_CheckedChanged(sender As Object, e As EventArgs) Handles checkDontShowAgain.CheckedChanged

        ''Added 10/28/2022
        DontShowDialogAgain = CType(sender, CheckBox).Checked

    End Sub
End Class