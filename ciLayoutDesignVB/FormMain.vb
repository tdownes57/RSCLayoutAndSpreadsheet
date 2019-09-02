Option Explicit On
Option Strict On

''
''Added 7/17/2019 thomas downes
''
Imports ciBadgeInterfaces ''Added 9/2/2019 td

Public Class FormMain

    Private Shared mod_currentConfigID As Integer ''Added 7/23/2019 thomas downes  

    Public Shared Function GetCurrentPersonality_Fields_Custom() As List(Of ClassFieldCustomized)
        ''
        ''Added 7/23/2019 thomas downes
        ''
        ClassFieldCustomized.InitializeHardcodedList_Students(True)
        ClassFieldCustomized.InitializeHardcodedList_Staff(True)

        If (2 <> mod_currentConfigID) Then Return ClassFieldCustomized.ListOfFields_Students
        If (2 = mod_currentConfigID) Then Return ClassFieldCustomized.ListOfFields_Staff
        Return Nothing

    End Function ''eNd of "Public Function GetCurrentPersonality_Fields_Custom() As List(Of ClassFieldCustomized)"

    Public Shared Function GetCurrentPersonality_Fields_Standard() As List(Of icibfieldstandardorcustom)
        ''--- Public Shared Function GetCurrentPersonality_Fields_Standard() As List(Of ClassFieldStandard)
        ''
        ''Added 7/26/2019 thomas downes
        ''
        ClassFieldStandard.InitializeHardcodedList_Students(True)
        ClassFieldStandard.InitializeHardcodedList_Staff(True)

        If (2 <> mod_currentConfigID) Then Return ClassFieldStandard.ListOfFields_Students
        If (2 = mod_currentConfigID) Then Return ClassFieldStandard.ListOfFields_Staff
        Return Nothing

    End Function ''eNd of "Public Function GetCurrentPersonality_Fields_Standard() As List(Of ClassFieldStandard)"

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
        ''
        ''Added 7 / 17 / 2019 thomas downes
        ''
        ''7/26/2019 td''Dim frm_ToShow As New FormDesignPrototype()
        Dim frm_ToShow As New FormDesignProtoTwo()
        frm_ToShow.Show()

    End Sub

    Private Sub GridViewTableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GridViewTableToolStripMenuItem.Click
        ''
        ''Added 7/17/2019 thomas downes
        ''
        Dim frm_ToShow As New ListCustomFieldsGrid()
        ''7/26/2019 td''frm_ToShow.ListOfFields = GetCurrentPersonality_Fields()
        frm_ToShow.ListOfFields = GetCurrentPersonality_Fields_Custom()
        frm_ToShow.Show()

    End Sub

    Private Sub UserControlsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserControlsToolStripMenuItem.Click
        ''
        ''Added 7/17/2019 thomas downes
        ''
        Dim frm_ToShow As New ListCustomFieldsFlow()
        ''7/26/2019 td''frm_ToShow.ListOfFields = GetCurrentPersonality_Fields()
        frm_ToShow.ListOfFields = GetCurrentPersonality_Fields_Custom()
        frm_ToShow.Show()

    End Sub

    Private Sub StudentsToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        ''
        ''Added 7/23/2019 thomas downes
        ''
        Dim frm_ToShow As New ListCustomFieldsGrid()
        ClassFieldCustomized.InitializeHardcodedList_Students(True)
        frm_ToShow.ListOfFields = ClassFieldCustomized.ListOfFields_Students
        frm_ToShow.Show()

    End Sub

    Private Sub StudentsToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ''
        ''Added 7/23/2019 thomas downes
        ''
        Dim frm_ToShow As New ListCustomFieldsFlow()
        ClassFieldCustomized.InitializeHardcodedList_Students(True)
        frm_ToShow.ListOfFields = ClassFieldCustomized.ListOfFields_Students
        frm_ToShow.Show()

    End Sub

    Private Sub StaffToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ''
        ''Added 7/23/2019 thomas downes
        ''
        Dim frm_ToShow As New ListCustomFieldsFlow()
        ClassFieldCustomized.InitializeHardcodedList_Staff(True)
        frm_ToShow.ListOfFields = ClassFieldCustomized.ListOfFields_Staff
        frm_ToShow.Show()

    End Sub

    Private Sub StaffToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        '' 
        ''Added 7/23/2019 thomas downes
        ''
        Dim frm_ToShow As New ListCustomFieldsGrid()
        ClassFieldCustomized.InitializeHardcodedList_Staff(True)
        frm_ToShow.ListOfFields = ClassFieldCustomized.ListOfFields_Staff
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

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Version830v1010ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Version830v1010ToolStripMenuItem.Click
        ''
        ''Added 7/31/2019 td  
        ''
        Dim frm_ToShow As New Version830_v101
        frm_ToShow.Show()


    End Sub
End Class