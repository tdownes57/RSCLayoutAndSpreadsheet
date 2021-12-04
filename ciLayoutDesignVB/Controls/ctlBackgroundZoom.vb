Option Explicit On
Option Strict On

Imports System.IO

Public Class ctlBackgroundZoom
    ''
    ''Added 12/3/2021 thomas downes  
    ''
    Private mod_strBackgroundImagePath As String = ""
    Private mod_bitmapBackgroundImage_Deprecated As Bitmap

    Public Property PictureBackgroundBox() As PictureBox
        Get
            ''
            ''Added 12/3/2021 thomas downes  
            ''
            Return pictureBackZoom
        End Get
        Set(value As PictureBox)

            ''I'm not happy with this "Set", but I am trying to fix a Loading error. 
            Me.pictureBackZoom = value

        End Set
    End Property

    Public Property BackgroundImage() As Image
        Get
            ''
            ''Added 12/3/2021 thomas downes  
            ''
            Return pictureBackZoom.BackgroundImage

        End Get
        Set(value As Image)

            ''I'm not happy with this "Set", but I am trying to fix a Loading error. 
            pictureBackZoom.BackgroundImage = value

        End Set
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
            mod_strBackgroundImagePath = value

            'If (False) Then

            '    ''If (String.IsNullOrEmpty(value)) Then Throw New Exception("Background Image Path is null or empty.")
            '    ''If (Not File.Exists(value)) Then Throw New Exception("Background Image Path is not an existing file.")
            '    ''If (value.Trim() = "") Then Throw New Exception("Background Image Path is a bunch of spaces.")

            '    ''mod_strBackgroundImagePath = value
            '    ''mod_bitmapBackgroundImage_Deprecated = New Bitmap(mod_strBackgroundImagePath)
            '    ''pictureBackZoom.BackgroundImage = mod_bitmapBackgroundImage_Deprecated

            'End If


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

    Private Sub ctlBackgroundZoom_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint

        ''Added 12/3/2021
        ''If (BackgroundImage Is Nothing) Then

        ''    If (BackgroundImageLocation <> "") Then

        ''        If (File.Exists(BackgroundImageLocation)) Then

        ''            pictureBackZoom.BackgroundImage = (New Bitmap(BackgroundImageLocation))

        ''        End If

        ''    End If

        ''End If

    End Sub
End Class
