Option Explicit On
Option Strict On

''
''Added 7/17/2019 thomas downes
''

Public Class FormMain

    Private mod_currentConfigID As Integer ''Added 7/23/2019 thomas downes  

    Private Function GetCurrentPersonality_Fields() As List(Of ClassCustomField)
        ''
        ''Added 7/23/2019 thomas downes
        ''
        ClassCustomField.InitializeHardcodedList_Students(True)
        ClassCustomField.InitializeHardcodedList_Staff(True)

        If (2 <> mod_currentConfigID) Then Return ClassCustomField.ListOfFields_Students
        If (2 = mod_currentConfigID) Then Return ClassCustomField.ListOfFields_Staff
        Return Nothing

    End Function

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
        frm_ToShow.ListOfFields = GetCurrentPersonality_Fields()
        frm_ToShow.Show()

    End Sub

    Private Sub UserControlsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserControlsToolStripMenuItem.Click
        ''
        ''Added 7/17/2019 thomas downes
        ''
        Dim frm_ToShow As New FormCustomFieldsFlow()
        frm_ToShow.ListOfFields = GetCurrentPersonality_Fields()
        frm_ToShow.Show()

    End Sub

    Private Sub StudentsToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        ''
        ''Added 7/23/2019 thomas downes
        ''
        Dim frm_ToShow As New FormCustomFieldsGrid()
        ClassCustomField.InitializeHardcodedList_Students(True)
        frm_ToShow.ListOfFields = ClassCustomField.ListOfFields_Students
        frm_ToShow.Show()

    End Sub

    Private Sub StudentsToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ''
        ''Added 7/23/2019 thomas downes
        ''
        Dim frm_ToShow As New FormCustomFieldsFlow()
        ClassCustomField.InitializeHardcodedList_Students(True)
        frm_ToShow.ListOfFields = ClassCustomField.ListOfFields_Students
        frm_ToShow.Show()

    End Sub

    Private Sub StaffToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ''
        ''Added 7/23/2019 thomas downes
        ''
        Dim frm_ToShow As New FormCustomFieldsFlow()
        ClassCustomField.InitializeHardcodedList_Staff(True)
        frm_ToShow.ListOfFields = ClassCustomField.ListOfFields_Staff
        frm_ToShow.Show()

    End Sub

    Private Sub StaffToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        '' 
        ''Added 7/23/2019 thomas downes
        ''
        Dim frm_ToShow As New FormCustomFieldsGrid()
        ClassCustomField.InitializeHardcodedList_Staff(True)
        frm_ToShow.ListOfFields = ClassCustomField.ListOfFields_Staff
        frm_ToShow.Show()

    End Sub

    Private Sub StaffToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles StaffToolStripMenuItem2.Click
        ''
        ''Added 7/23/2019
        ''
        mod_currentConfigID = 2
        StaffToolStripMenuItem2.Checked = True
        StudentsToolStripMenuItem2.Checked = False

    End Sub

    Private Sub StudentsToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles StudentsToolStripMenuItem2.Click
        ''
        ''Added 7/23/2019
        ''
        mod_currentConfigID = 1
        StaffToolStripMenuItem2.Checked = False
        StudentsToolStripMenuItem2.Checked = True

    End Sub
End Class