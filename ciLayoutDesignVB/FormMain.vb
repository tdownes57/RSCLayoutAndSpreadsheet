Option Explicit On
Option Strict On
''
''Added 7/17/2019 thomas downes
''

Public Class FormMain
    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        ''Added 7/17/2019 thomas downes
        Dim frm_ToShow As New FormDesignPrototype()
        frm_ToShow.Show()

    End Sub

    Private Sub ConfigureFieldsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfigureFieldsToolStripMenuItem.Click
        ''
        ''Added 7 / 17 / 2019 thomas downes
        ''
        ''7/20/2019 td''Dim frm_ToShow As New FormCustomFieldsGrid()
        ''7/20/2019 td''frm_ToShow.Show()

    End Sub

    Private Sub PlaceElementsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlaceElementsToolStripMenuItem.Click
        ''Added 7/17/2019 thomas downes
        Dim frm_ToShow As New FormDesignPrototype()
        frm_ToShow.Show()

    End Sub

    Private Sub GridViewTableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GridViewTableToolStripMenuItem.Click
        ''
        ''Added 7/17/2019 thomas downes
        ''
        Dim frm_ToShow As New FormCustomFieldsGrid()
        frm_ToShow.Show()

    End Sub

    Private Sub UserControlsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserControlsToolStripMenuItem.Click
        ''
        ''Added 7/17/2019 thomas downes
        ''
        Dim frm_ToShow As New FormCustomFieldsFlow()
        frm_ToShow.Show()

    End Sub
End Class