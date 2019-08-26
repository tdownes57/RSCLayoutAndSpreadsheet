Option Explicit On ''Added 8/26/2019 td 
Option Strict On ''Added 8/26/2019 td 

Public Class FormDisplayImageList ''Added 8/26/2019 td 

    Private _objListImages As List(Of Image) ''Added 8/26/2019 td 

    Public Sub New(par_list As List(Of Image))

        _objListImages = par_list ''Added 8/26/2019 td 

    End Sub

    Private Sub FormDisplayImageList_Load(sender As Object, e As EventArgs) Handles Me.Load

        ''Added 8/26/2019 td 
        LoadAllImagesToUI()

    End Sub


    Private Sub LoadAllImagesToUI()
        ''
        ''Added 8/26/2019 td 
        ''
        For Each par_image As Image In _objListImages

            LoadEachImageToUI(par_image)

        Next par_image

    End Sub

    Private Sub LoadEachImageToUI(par_image As Image)
        ''
        ''Added 8/26/2019 td 
        ''

        Dim new_picturebox As New PictureBox

        With new_picturebox

            .Image = par_image
            .SizeMode = PictureBoxSizeMode.Normal
            .Visible = True
            .Width = par_image.Width + 3
            .Height = par_image.Height + 3

        End With

        Me.FlowLayoutPanel1.Controls.Add(new_picturebox)


    End Sub

End Class