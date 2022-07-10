Option Explicit On
Option Strict On
''
''Added 7/09/2022 thomas downes 
''

Public Class RSCBrowseExistingColors
    ''
    ''Added 7/09/2022 thomas downes 
    ''
    Private mod_listColors As List(Of RSCColor)

    Public Sub New(par_listColors As List(Of RSCColor),
        Optional par_enumGround As EnumRSCBackOrFore = EnumRSCBackOrFore.Undetermined)
        ''July9 2022''Public Sub New(par_listColors As List(Of RSCColor)
        ''
        ''Added 7/09/2022 thomas downes 
        ''
        Dim each_controlDisplay As RSCColorDisplay
        Dim bConfirmAddExample As Boolean

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mod_listColors = par_listColors

        ''Added 7/9/2022 thomas downes 
        If (par_listColors Is Nothing) Then par_listColors = New List(Of RSCColor)()
        If (par_listColors.Count = 0) Then
            ''Added 7/09/2022 thomas downes 
            bConfirmAddExample = MessageBoxTD.Show_Confirmed("No colors have been selected yet. An example might help.",
                     "Would you like to add Chartreuse as an example color?  May be deleted later.", False)
            If (bConfirmAddExample) Then
                ''Add the color Chartreuse 
                par_listColors.Add(New RSCColor("Chartreuse", Color.Chartreuse))
            End If ''End of ""If (bConfirmAddExample) Then""
        End If ''End of ""If (par_listColors.Count = 0) Then""

        ''
        ''Start from scratch by clearing the Flow-Layount container.
        ''
        FlowLayoutPanel1.Controls.Clear()

        For Each eachRSCColor As RSCColor In par_listColors

            each_controlDisplay = RSCColorDisplay.GetColorDisplay(eachRSCColor, par_enumGround)
            FlowLayoutPanel1.Controls.Add(each_controlDisplay)

        Next eachRSCColor

    End Sub


    Private Sub RscColorPicker1_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click

    End Sub

    Private Sub RSCBrowseExistingColors_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAddNewColor_Click(sender As Object, e As EventArgs) Handles ButtonAddNewColor.Click

    End Sub
End Class