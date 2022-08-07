''
''Added 5/06/2022 thomas d. 
''
Imports System.IO

Public Class FormWelcomeNotes
    Private Sub FormWelcomeNotes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 5/06/2022 thomas d. 
        ''
        Dim strPathToNotesTXT As String

        ''strPathToNotesTXT = Path.Combine(DiskFolders.PathToFolder_Notes(), "__WelcomeNotes.txt")

        strPathToNotesTXT = DiskFolders.PathToFolder_Notes_TXT(True, "__WelcomeNotes.txt")

        TextBox1.Text = IO.File.ReadAllText(strPathToNotesTXT)
        Me.TextBox1.Tag = ""

        ''Added 5/07/2022 thomas d.
        ButtonOK.Select()

    End Sub

    Private Sub ButtonCancelEdits_Click(sender As Object, e As EventArgs) Handles ButtonCancelEdits.Click

        Dim boolConfirmed As Boolean

        If (Me.TextBox1.Tag Is Nothing) Then
            ''
            ''Omit the following "ElseIf" from execution. 6/2022
            ''
        ElseIf (Me.TextBox1.Tag.ToString() = "Edited") Then

            boolConfirmed =
               MessageBoxTD.Show_Confirm("Are you cancelling your edits?  If so, please confirm.")
            ''5/23/2022 MessageBoxTD.Show_Confirm("Are you cancelling your edits?")

            If (Not boolConfirmed) Then Exit Sub

        End If ''ENd of ""If (Me.TextBox1.Tag = "Edited") Then""

        Me.DialogResult = DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        ''
        ''Added 5/6/2022 
        ''
        Dim strPathToNotesTXT As String
        ''strPathToNotesTXT = Path.Combine(DiskFolders.PathToFolder_Notes(), "__WelcomeNotes.txt")
        strPathToNotesTXT = DiskFolders.PathToFolder_Notes_TXT(True, "__WelcomeNotes.txt")
        IO.File.WriteAllText(strPathToNotesTXT, TextBox1.Text)
        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        ''added 5/06/2022  
        TextBox1.Tag = "Edited"

    End Sub

    Private Sub LinkLabelShowWarnings_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelShowWarnings.LinkClicked

        ''Added 6/28/2022  
        ciBadgeDesigner.GlobalSettings.ShowWarnings = True
        ciBadgeDesigner.GlobalSettings.Debugging = True
        ''ciBadgeDesigner.GlobalSettings.ShowNewFeatures = False
        MessageBoxTD.Show_Warning("Warnings will be displayed.")
        LinkLabelTurnOffWarnings.Visible = True

    End Sub

    Private Sub LinkLabelTurnOffWarnings_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelTurnOffWarnings.LinkClicked

        ''Added 6/28/2022  
        ciBadgeDesigner.GlobalSettings.ShowWarnings = False
        ciBadgeDesigner.GlobalSettings.Debugging = False
        ''ciBadgeDesigner.GlobalSettings.ShowNewFeatures = False
        MessageBoxTD.Show_Warning("Warnings will be suppressed.")

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles pictureBoxLogo.Click

        ''Added 8/6/2022 thomas downes
        ButtonOK.PerformClick()


    End Sub
End Class