Option Explicit On
Option Strict On
''
''Added 5/6/2022 thomas downes  
''
Imports __RSCWindowsControlLibrary ''Added 5/06/2022 
''
''Added 5/6/2022 thomas downes  
''

Public Class FormRandomLocation

    ''Added 5/6/2022 thomas downes
    Public rsc_MoveableControlVB As RSCMoveableControlVB

    ''Added 5/6/2022 thomas downes
    Public ElementTop As Integer = 0
    Public ElementLeft As Integer = 0
    Public ElementHeight As Integer = 0
    Public ElementWidth As Integer = 0

    Private mod_imagePreview As Image ''Added 5/06/2022 

    Public Sub New(par_controlRSC As RSCMoveableControlVB,
                   par_imagePreview As Image)

        ' This call is required by the designer.
        InitializeComponent()

        ''Added 5/6/2022
        mod_imagePreview = par_imagePreview
        rsc_MoveableControlVB = par_controlRSC

        ' Add any initialization after the InitializeComponent() call.
        ''    ---Added 5/06/2022 thomas downes
        With pictureBackgroundFront
            .BackgroundImage = Nothing
            .Image = Nothing
        End With

    End Sub

    Public Property IDCardPreview As Image
        Get
            ''
            ''Added 5/6/2022 thomas downes
            ''
            ''With pictureBackgroundFront
            ''    If .Image IsNot Nothing Then Return .Image
            ''    If .BackgroundImage IsNot Nothing Then Return .BackgroundImage
            ''End With
            Return mod_imagePreview '' = value

        End Get
        Set(value As Image)
            ''
            ''Added 5/6/2022 thomas downes
            ''
            mod_imagePreview = value
            ''pictureBackgroundFront.BackgroundImage = value
            ''pictureBackgroundFront.BackgroundImageLayout = ImageLayout.Zoom
            ''''Redundancy is the best policy. LOL  
            ''pictureBackgroundFront.Image = value
            ''pictureBackgroundFront.SizeMode = ImageLayout.Zoom

        End Set
    End Property

    Private Sub FormRandomLocation_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ''Added 5/06/2022 thomas downes
        With pictureBackgroundFront
            .BackgroundImage = Nothing
            .Image = Nothing
            .BackgroundImage = mod_imagePreview ''<<<<<<<<<< See Public Sub New.

            .BackgroundImageLayout = ImageLayout.Zoom
            ''Redundancy is the best policy. LOL  
            .Image = mod_imagePreview
            .SizeMode = PictureBoxSizeMode.Zoom

        End With ''With pictureBackgroundFront

    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click

        ''Added 5/06/2022 td 
        Me.ElementTop = 0
        Me.ElementLeft = 0
        Me.ElementHeight = 0
        Me.ElementWidth = 0

        ''Added 5/06/2022 td 
        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub
End Class