Imports ciBadgeInterfaces ''Added 5/3/2022 td 
Imports __RSCWindowsControlLibrary ''Added 5/3/2022 td
''
''Added 5/3/2022 thomas d. 
''

Public Class FormTypeOfElementsToAdd
    ''
    ''Added 5/3/2022 thomas d. 
    ''
    Public AddPortraitPic As Boolean
    Public AddGraphic As Boolean
    Public AddStaticText As Boolean
    Public AddQRCode As Boolean
    Public AddSignature As Boolean
    Public AddField As Boolean
    Public AddField_Enum As EnumCIBFields

    Private Sub ToggleBorder(par_control As UserControl) ''---As RSCMoveableControlVB) ''As Control)
        ''
        ''Added 5/3/2022 thomas downes 
        ''
        If (par_control.BorderStyle = BorderStyle.None) Then

            par_control.BorderStyle = BorderStyle.Fixed3D

        Else

            par_control.BorderStyle = BorderStyle.None

        End If

    End Sub ''End of ""Private Sub ToggleBorder(par_control As UserControl)""


    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click

        Me.DialogResult = DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click

        ''Added 5/3/2022 td
        Me.AddField = (RscSelectCIBField1.BorderStyle <> BorderStyle.None)
        Me.AddQRCode = (CtlGraphicQRCode1.BorderStyle <> BorderStyle.None)
        Me.AddSignature = (CtlGraphicSignature1.BorderStyle <> BorderStyle.None)
        Me.AddGraphic = (CtlGraphicStaticGraphic1.BorderStyle <> BorderStyle.None)
        Me.AddPortraitPic = (CtlGraphicPortrait1.BorderStyle <> BorderStyle.None)
        Me.AddStaticText = (CtlGraphicStaticText1.BorderStyle <> BorderStyle.None)

        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub

    Private Sub CtlGraphicPortrait1_Click(sender As Object, e As EventArgs) Handles CtlGraphicPortrait1.Click

        ''Added 5/3/2022 td
        ToggleBorder(CType(sender, Control))

    End Sub

    Private Sub CtlGraphicPortrait1_Load(sender As Object, e As EventArgs) Handles CtlGraphicPortrait1.Click

        ''Added 5/3/2022 td
        ToggleBorder(CType(sender, Control))

    End Sub

    Private Sub CtlGraphicStaticGraphic1_Load(sender As Object, e As EventArgs) Handles CtlGraphicStaticGraphic1.Click
        ''Added 5/3/2022 td
        ToggleBorder(CType(sender, Control))

    End Sub

    Private Sub CtlGraphicStaticText1_Load(sender As Object, e As EventArgs) Handles CtlGraphicStaticText1.Click
        ''Added 5/3/2022 td
        ToggleBorder(CType(sender, Control))

    End Sub

    Private Sub RscSelectCIBField1_Load(sender As Object, e As EventArgs) Handles RscSelectCIBField1.Click
        ''Added 5/3/2022 td
        ToggleBorder(CType(sender, Control))

    End Sub

    Private Sub CtlGraphicSignature1_Load(sender As Object, e As EventArgs) Handles CtlGraphicSignature1.Click
        ''Added 5/3/2022 td
        ToggleBorder(CType(sender, Control))

    End Sub

    Private Sub CtlGraphicQRCode1_Load(sender As Object, e As EventArgs) Handles CtlGraphicQRCode1.Click
        ''Added 5/3/2022 td
        ToggleBorder(CType(sender, Control))

    End Sub
End Class