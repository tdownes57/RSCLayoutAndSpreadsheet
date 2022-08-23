''
''Added 8/22/2022 
''
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
        RscColorPicker1.BackColor = par_msnetColor
        textboxColorName.Text = par_strColorName

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

        objRSCColor = New ciBadgeInterfaces.RSCColor(RscColorPicker1.BackColor,
                                                     textboxColorName.Text,
                                                     textboxDescription.Text)
        Me.Output_RSCColor = objRSCColor
        Me.Close()

    End Sub

    Private Sub FormRSCColorConfirm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class