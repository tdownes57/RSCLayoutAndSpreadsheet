Option Explicit On
Option Strict On
''
''Added 9/21/2019 td
''
Imports System.Reflection.Assembly

Public Class ClassMethods
    ''
    ''Added 9/21/2019 td
    ''
    Friend WithEvents MyLinkLabel As New LinkLabel

    Friend Sub Add_Text_Image(sender As Object, e As LinkLabelLinkClickedEventArgs)

        System.Diagnostics.Debugger.Break()


    End Sub

    Friend Sub Create_a_Rotated_Image(sender As Object, e As LinkLabelLinkClickedEventArgs)

        System.Diagnostics.Debugger.Break()

    End Sub

    Private Sub MyLinkLabel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles MyLinkLabel.LinkClicked

    End Sub
End Class
