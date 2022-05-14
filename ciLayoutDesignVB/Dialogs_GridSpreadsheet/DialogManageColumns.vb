''
''Added 5/14/2022 td
''
Public Class DialogManageColumns
    Private Sub DialogAddColumns_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        ''
        ''Added 5/14/2022 td
        ''
        Dim boolKeyLeft As Boolean
        Dim boolKeyRight As Boolean

        boolKeyLeft = (e.KeyCode = Keys.Left)
        boolKeyLeft = (e.KeyCode = Keys.Right)



    End Sub
End Class