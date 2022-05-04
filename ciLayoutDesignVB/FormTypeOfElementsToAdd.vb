Imports ciBadgeInterfaces ''Added 5/3/2022 td 
Imports __RSCWindowsControlLibrary ''Added 5/3/2022 td
''
''Added 5/3/2022 thomas d. 
''
''The following Dialog Form is an attempt to fix an ambiguity which has 
''  been vexing my layout-design development for a long time... namely, the
''  ambiguity is as follows....
''Do I want all the various types of Elements (e.g. QR code) to be easily
''  (i.e. automatically) instantiated (and thus present in the layout design at run-time),
''  or would I eventually find it vexing & annoying?
''Sometimes I just want to work with a simple, unadorned layout... no bells & whistles.
''A related question is, if I finally don't want them to keep appearing incessantly,
''  how do I "turn them off" effectively? 
''Solution:  This new dialog-form called FormTypesOfElementsToAdd, and the following
''  Boolean constant, Startup.PreloadElementsForDemo.   -----5/4/2022 td
''  -----5/4/2022 td
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

    Private Sub CtlGraphicPortrait1_Click(sender As Object, e As EventArgs)

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

    Private Sub CtlGraphicPortrait1_Load_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub FormTypeOfElementsToAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class