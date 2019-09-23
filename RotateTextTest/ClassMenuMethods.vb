Option Explicit On
Option Strict On
''
''Added 9/21/2019 td
''
Imports System.Reflection.Assembly

Friend Class ClassMenuMethods
    ''
    ''Added 9/21/2019 td
    ''
    ''9/23/2019 td''
    Public WithEvents MyLinkLabel As New LinkLabel

    Public ParentForm As FormRotateText

    Public Sub Add_Text_Image(sender As Object, e As LinkLabelLinkClickedEventArgs)

        ''System.Diagnostics.Debugger.Break()

        ParentForm.BackgroundImage = New Bitmap(250, 30)


    End Sub

    Public Sub Create_a_Rotated_Image(sender As Object, e As LinkLabelLinkClickedEventArgs)

        System.Diagnostics.Debugger.Break()

    End Sub

    ''9/23/2019 td''Private Sub MyLinkLabelLinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles MyLinkLabel.LinkClicked
    ''9/23/2019 td''
    ''9/23/2019 td''End Sub

    Public Sub AddEventHandlerLinkClicked(par_link As LinkLabel)
        ''
        ''Added 9/22/2019 thomas d. 
        ''
        Select Case par_link.Text.ToUpper

            Case "Add Text Image".ToUpper

                AddHandler par_link.LinkClicked,
                    AddressOf Add_Text_Image

            Case "Create A Rotated Image".ToUpper

                AddHandler par_link.LinkClicked,
                    AddressOf Me.Create_a_Rotated_Image

            Case Else
                MessageBox.Show($"The link {par_link.Text} is unpaired with a class method." & vbCrLf & vbCrLf &
                                "Please inform the software developer.", "",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Select ''End of "Select Case par_link.Text.ToUpper"

    End Sub ''End of "Public Sub AddEventHandlerLinkClicked(par_link As LinkLabel)"



End Class
