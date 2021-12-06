Option Explicit On
Option Strict On

''
''Added 7/17/2019 thomas downes
''
Imports ciBadgeInterfaces ''Added 9/2/2019 td
Imports ciBadgeFields ''Added 9/19/2019 td
Imports ciBadgeElements ''Added 9/30/2019 td  
Imports ciBadgeCachePersonality ''Added 12/4/2021 thomas d. 

Public Class Form__Main_PreDemo

    Private Shared mod_currentConfigID As Integer ''Added 7/23/2019 thomas downes  

    Public Shared Sub OpenElementsCache(par_cache As ClassElementsCache_Deprecated)
        ''
        ''Added 9/30/2019 thomas downes
        ''
        ''------------Dim objFormToShow As New FormDesignProtoTwo






    End Sub ''End of "Public Shared Function OpenElementsCache(par_cache As classel)"

    Public Shared Function GetCurrentPersonality_Fields_Custom() As HashSet(Of ClassFieldCustomized) ''Dec6 2021''List(Of ClassFieldCustomized)
        ''
        ''Added 7/23/2019 thomas downes
        ''
        ClassFieldCustomized.InitializeHardcodedList_Students(True)
        ClassFieldCustomized.InitializeHardcodedList_Staff(True)

        If (2 <> mod_currentConfigID) Then Return ClassFieldCustomized.ListOfFields_Students
        If (2 = mod_currentConfigID) Then Return ClassFieldCustomized.ListOfFields_Staff

        Return Nothing

    End Function ''eNd of "Public Function GetCurrentPersonality_Fields_Custom() As List(Of ClassFieldCustomized)"

    Public Shared Function GetCurrentPersonality_Fields_Custom_HashSet() As HashSet(Of ClassFieldCustomized)
        ''
        ''Added 12/5/2019 thomas downes
        ''

    End Function

    Public Shared Function GetCurrentPersonality_Fields_Standard() As HashSet(Of ClassFieldStandard)
        ''
        ''Added 7/26/2019 thomas downes
        ''
        ClassFieldStandard.InitializeHardcodedList_Students(True)
        ClassFieldStandard.InitializeHardcodedList_Staff(True)

        If (2 <> mod_currentConfigID) Then Return ClassFieldStandard.ListOfFields_Students
        If (2 = mod_currentConfigID) Then Return ClassFieldStandard.ListOfFields_Staff

        Return Nothing

    End Function ''eNd of "Public Function GetCurrentPersonality_FieldInfos_Standard() As List(Of ClassFieldStandard)"

    Public Shared Function GetCurrentPersonality_FieldInfos_Standard() As List(Of ICIBFieldStandardOrCustom)
        ''
        ''--- Public Shared Function GetCurrentPersonality_Fields_Standard() As List(Of ClassFieldStandard)
        ''
        ''Added 7/26/2019 thomas downes
        ''
        ClassFieldStandard.InitializeHardcodedList_Students(True)
        ClassFieldStandard.InitializeHardcodedList_Staff(True)

        '' 9/2/2019 td''If (2 <> mod_currentConfigID) Then Return ClassFieldStandard.ListOfFields_Students
        '' 9/2/2019 td''If (2 = mod_currentConfigID) Then Return ClassFieldStandard.ListOfFields_Staff

        If (2 <> mod_currentConfigID) Then Return ClassFieldStandard.ListOfFieldInfos_Students()
        If (2 = mod_currentConfigID) Then Return ClassFieldStandard.ListOfFieldInfos_Staff()

        Return Nothing

    End Function ''eNd of "Public Function GetCurrentPersonality_FieldInfos_Standard() As List(Of ClassFieldStandard)"

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

        ''-----10/3 td-----Dim frm_ToShow As New FormDesignProtoTwo()
        Dim frm_ToShow As New FormDesignProtoThree()
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

    Private Sub CustomFields_PreDemo_Click(sender As Object, e As EventArgs) Handles UserControlsToolStripMenuItem.Click
        ''
        ''Added 7/17/2019 thomas downes
        ''
        Dim frm_ToShow As New ListCustomFieldsFlow()

        ''7/26/2019 td''frm_ToShow.ListOfFields = GetCurrentPersonality_Fields()
        ''12/5/2021 td''frm_ToShow.ListOfFields = GetCurrentPersonality_Fields_Custom()

        frm_ToShow.ListOfFields_Custom = GetCurrentPersonality_Fields_Custom_HashSet()
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
        frm_ToShow.ListOfFields_Custom = ClassFieldCustomized.ListOfFields_Students
        frm_ToShow.Show()

    End Sub

    Private Sub StaffToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ''
        ''Added 7/23/2019 thomas downes
        ''
        Dim frm_ToShow As New ListCustomFieldsFlow()
        ClassFieldCustomized.InitializeHardcodedList_Staff(True)
        frm_ToShow.ListOfFields_Custom = ClassFieldCustomized.ListOfFields_Staff
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
        ''
        ''Added 9/3/2019 thomas downes
        ''
        ''-----10/3/2019 td----Dim frm_ToShow As New FormDesignProtoTwo()
        Dim frm_ToShow As New FormDesignProtoThree()
        frm_ToShow.Show()

    End Sub

    Private Sub Version830v1010ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Version830v1010ToolStripMenuItem.Click
        ''
        ''Added 7/31/2019 td  
        ''
        Dim frm_ToShow As New Version830_v101
        frm_ToShow.Show()


    End Sub
End Class