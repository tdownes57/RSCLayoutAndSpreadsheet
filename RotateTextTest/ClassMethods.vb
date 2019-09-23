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

    Friend Sub AddEventHandler_LinkClicked(par_link As LinkLabel)
        ''
        ''Added 9/22/2019 thomas d. 
        ''
        Select Case par_link.Text
            Case "Add Text Image" : AddHandler par_link.LinkClicked, AddressOf Add_Text_Image

            Case "Create A Rotated Image" : AddHandler par_link.LinkClicked, AddressOf Me.Create_a_Rotated_Image

            Case Else
                MessageBox.Show("The link is unpaired with a class method.")

        End Select




    End Sub



End Class
