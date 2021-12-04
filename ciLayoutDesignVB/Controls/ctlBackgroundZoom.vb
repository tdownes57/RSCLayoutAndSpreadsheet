Option Explicit On
Option Strict On

Imports System.IO

Public Class ctlBackgroundZoom
    ''
    ''Added 12/3/2021 thomas downes  
    ''
    Private mod_strBackgroundImagePath As String = ""
    Private mod_bitmapBackgroundImage As Bitmap

    Public ReadOnly Property PictureBackgroundBox() As PictureBox
        Get
            ''
            ''Added 12/3/2021 thomas downes  
            ''
            Return pictureBackZoom
        End Get

    End Property

    Public ReadOnly Property BackgroundImage() As Image
        Get
            ''
            ''Added 12/3/2021 thomas downes  
            ''
            Return pictureBackZoom.BackgroundImage

        End Get

    End Property


    Public Property BackgroundImageLocation() As String
        Get
            ''
            ''Added 12/3/2021 thomas downes  
            ''
            Return mod_strBackgroundImagePath
        End Get
        Set(value As String)
            ''
            ''Added 12/3/2021 thomas downes  
            ''
            If (String.IsNullOrEmpty(value)) Then Throw New Exception("Background Image Path is null or empty.")
            If (Not File.Exists(value)) Then Throw New Exception("Background Image Path is not an existing file.")
            If (value.Trim() = "") Then Throw New Exception("Background Image Path is a bunch of spaces.")

            mod_strBackgroundImagePath = value
            mod_bitmapBackgroundImage = New Bitmap(mod_strBackgroundImagePath)
            pictureBackZoom.BackgroundImage = mod_bitmapBackgroundImage

        End Set
    End Property

    Private Sub pictureBackZoom_Paint(sender As Object, e As PaintEventArgs) Handles pictureBackZoom.Paint
        ''
        ''Added 12/3/2021 td 
        ''
        ''pictureBackZoom.Refresh()

    End Sub

    Private Sub ctlBackgroundZoom_MouseClick(sender As Object, e As MouseEventArgs) Handles MyBase.MouseClick

        ''Added 12/3/2021  
        ''Me.Refresh()

    End Sub

    Private Sub pictureBackZoom_MouseClick(sender As Object, e As MouseEventArgs) Handles pictureBackZoom.MouseClick

        ''Added 12/3/2021  
        ''Me.Refresh()

    End Sub
End Class
