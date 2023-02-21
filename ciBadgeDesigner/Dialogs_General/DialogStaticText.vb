''
''Added 5/30/2022 
''
Public Class DialogStaticText
    ''
    ''Added 5/30/2022 
    ''
    Public Output_IsMultiLine As Boolean
    Public Output_SingleLine As String
    Public Output_ListOfLines As List(Of String)

    Private mod_loading As Boolean = False ''Added 5/30/2022


    Public Sub New(pboolMultiLine As Boolean, pstrSingleLine As String,
                    plist_MultiArrayOfLines As List(Of String))

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mod_loading = True

        checkboxSingleLine.Checked = (Not pboolMultiLine)
        checkboxMultiLine.Checked = pboolMultiLine
        textboxSingleLine.Text = pstrSingleLine ''Added 6/01/2022 td 
        ''6/10/2022 textboxMultiLine.Lines = plist_MultiArrayOfLines.ToArray()
        textboxMultiLine.Visible = pboolMultiLine ''checkboxMultiLine.Checked
        ''6/10/2022 textboxMultiLine.Lines = plist_MultiArrayOfLines.ToArray()
        If (plist_MultiArrayOfLines Is Nothing) Then
            ''Added 2/21/2023
            textboxMultiLine.Lines = New String() {} ''Added 2/21/2023
        Else
            textboxMultiLine.Lines = plist_MultiArrayOfLines.ToArray()
        End If ''end of ""If (plist_MultiArrayOfLines IsNot Nothing) Then""


ExitHandler:
        Application.DoEvents()
        mod_loading = False

    End Sub ''End of ""Public Sub New(pboolMultiLine As Boolean, pstrSingleLine As String,""


    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        ''
        ''5/30/2022 
        ''
        Me.Output_IsMultiLine = checkboxMultiLine.Checked
        Me.Output_ListOfLines = New List(Of String)(textboxMultiLine.Lines())
        Me.Output_SingleLine = textboxSingleLine.Text

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
            textboxMultiLine.Visible = False ''checkboxMultiLine.Checked

        End If ''"End of ""If (checkboxSingleLine.Checked) Then""

ExitHandler:
        Application.DoEvents()
        mod_loading = False

    End Sub

    Private Sub DialogStaticText_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class