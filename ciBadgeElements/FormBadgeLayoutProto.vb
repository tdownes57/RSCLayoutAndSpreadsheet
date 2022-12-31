
''Added 12/2022
#Disable Warning CA2211 ''Warning "Non-constant fields should not be visible." 12/2022

Public Class FormBadgeLayoutProto

    ''---pictureBack 
    Public Shared pictureBack_Top As Integer = 9 '' = pictureBack.Top
    Public Shared pictureBack_Left As Integer = 8 '' = pictureBack.Left
    Public Shared pictureBack_Width As Integer = 511 '' = pictureBack.Width
    Public Shared pictureBack_Height As Integer = 346 '' = pictureBack.Height

    ''---picturePortrait
    Public Shared picturePortrait_Top As Integer = 0 '' = picturePortrait.Top
    Public Shared picturePortrait_Left As Integer = 0 '' = picturePortrait.Left
    Public Shared picturePortrait_Width As Integer = 0 '' = picturePortrait.Width
    Public Shared picturePortrait_Height As Integer = 0 '' = picturePortrait.Height

    Private Sub pictureQRCode_Click(sender As Object, e As EventArgs) Handles pictureQRCode.Click

    End Sub

    Private Sub FormBadgeLayoutProto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 2/3/2020 thomas d.
        ''
        ''---pictureBack 
        ''pictureBack.Top = pictureBack.Top ''9
        ''pictureBack.Left = pictureBack.Left ''8
        ''pictureBack.Width = pictureBack.Width ''511
        ''pictureBack.Height = pictureBack.Height ''346

        ''---picturePortrait 
        ''picturePortrait.Top = picturePortrait.Top ''20
        ''picturePortrait.Left = picturePortrait.Left ''154
        ''picturePortrait.Width = picturePortrait.Width ''100
        ''picturePortrait.Height = picturePortrait.Height ''135

        ''---pictureSignature
        ''pictureSignature.Top = pictureSignature.Top
        ''pictureSignature.Left = pictureSignature.Left
        ''pictureSignature.Width = pictureSignature.Width
        ''pictureSignature.Height = pictureSignature.Height

        ''---picturePortrait
        ''pictureQRCode.Top = pictureQRCode.Top
        ''pictureQRCode.Left = pictureQRCode.Left
        ''pictureQRCode.Width = pictureQRCode.Width
        ''pictureQRCode.Height = pictureQRCode.Height


    End Sub
End Class