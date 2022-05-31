''
''Added 5/30/2022 
''
Public Class DialogStaticText
    ''
    ''Added 5/30/2022 
    ''
    Private mod_loading As Boolean = False ''Added 5/30/2022

    Private Sub New(pboolMultiLine As Boolean, pstrSingleLine As String,
                    pstrMultiArrayOfLines As List(Of String))

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mod_loading = True
        checkboxSingleLine.Checked = (Not pboolMultiLine)
        checkboxMultiLine.Checked = pboolMultiLine

ExitHandler:
        Application.DoEvents()
        mod_loading = False

    End Sub


    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click


        Me.Output_Multiline = checkboxMultiLine.Checked
        Me.Putput_MultipleLines = textboxMultiLine.Lines()
        Me.Output_Singleline = textboxSingleLine.Text
        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click

        Me.DialogResult = DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub checkboxMultiLine_CheckedChanged(sender As Object, e As EventArgs) Handles checkboxMultiLine.CheckedChanged

        ''Added 5/30/2022 td
        If (mod_loading) Then Exit Sub
        textboxMultiLine.Visible = checkboxMultiLine.Checked

        If (checkboxMultiLine.Checked) Then
            mod_loading = True
            ''Undo the other checkbox, if marked. 
            checkboxSingleLine.Checked = False
            ''See below. ''Application.DoEvents()
            ''See below. ''mod_loading = False

        End If ''"End of ""If (checkboxMultiLine.Checked) Then""

ExitHandler:
        Application.DoEvents()
        mod_loading = False

    End Sub

    Private Sub checkboxSingleLine_CheckedChanged(sender As Object, e As EventArgs) Handles checkboxSingleLine.CheckedChanged

        ''Added 5/30/2022 td
        If (mod_loading) Then Exit Sub

        If (checkboxSingleLine.Checked) Then
            mod_loading = True
            ''Undo the other checkbox, if marked. 
            checkboxMultiLine.Checked = False
            ''See below. ''Application.DoEvents()
            ''See below. ''mod_loading = False

        End If ''"End of ""If (checkboxSingleLine.Checked) Then""

ExitHandler:
        Application.DoEvents()
        mod_loading = False

    End Sub
End Class