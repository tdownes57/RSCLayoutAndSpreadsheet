Imports ciBadgeInterfaces

Public Class FormTestTwoLists2x2
    ''
    ''Added 2/27/2024 thomas downes
    ''
    Private mod_managerOfOps As DLLOperationsManager2x2(Of TwoCharacterDLLHorizontal,
                                      TwoCharacterDLLVertical)

    Private Enum EnumTwoListsMode
        Undetermined
        HorizontalCols
        VerticalRows
    End Enum


    Private Function GetCurrentListMode() As EnumTwoListsMode
        ''
        ''Added 1/24/2024 
        ''
        Dim colorMode1 As Drawing.Color
        Dim colorMode2 As Drawing.Color
        Dim colorModeCurrent As Drawing.Color
        Dim boolMode1 As Boolean
        Dim boolMode2 As Boolean
        Dim return_enumMode As EnumTwoListsMode

        colorMode1 = labelItemsDisplay1.BackColor
        colorMode2 = labelItemsDisplay2.BackColor
        colorModeCurrent = userControlOperationBoth.BackColor

        boolMode1 = (colorModeCurrent = colorMode1)
        boolMode2 = (colorModeCurrent = colorMode2)
        If (boolMode1) Then return_enumMode = EnumTwoListsMode.HorizontalCols
        If (boolMode2) Then return_enumMode = EnumTwoListsMode.VerticalRows
        Return return_enumMode

    End Function ''End of ""Private Function CurrentListMode() As EnumTwoListsMode""


    Private Sub labelItemsDisplay_Click(sender As Object, e As EventArgs) Handles labelItemsDisplay1.Click
        ''
        ''Added 1/24/2024 
        ''
        userControlOperationBoth.BackColor = CType(sender, Control).BackColor

    End Sub

    Private Sub labelItemsDisplay2_Click(sender As Object, e As EventArgs) Handles labelItemsDisplay2.Click

        ''Added 1/24/2024 
        userControlOperationBoth.BackColor = CType(sender, Control).BackColor

    End Sub


    Private Sub DLLOperationCreated_Delete(par_operation As ciBadgeInterfaces.DLL_OperationV1, par_inverseAnchor_PriorToRange As TwoCharacterDLLItem, par_inverseAnchor_NextToRange As TwoCharacterDLLItem) Handles userControlOperationBoth.DLLOperationCreated_Delete
        ''
        ''Added 2/27/2024 thomas downes
        ''
        Dim enumMode As EnumTwoListsMode = GetCurrentListMode()

        If (enumMode = EnumTwoListsMode.HorizontalCols) Then

        ElseIf (enumMode = EnumTwoListsMode.VerticalRows) Then

        End If

    End Sub


    Private Sub userControlOperationBoth_DLLOperationCreated_Insert(par_operation As DLL_OperationV1) Handles userControlOperationBoth.DLLOperationCreated_Insert
        ''
        ''Added 2/27/2024 td
        ''
        Dim enumMode As EnumTwoListsMode = GetCurrentListMode()

        If (enumMode = EnumTwoListsMode.HorizontalCols) Then

        ElseIf (enumMode = EnumTwoListsMode.VerticalRows) Then

        End If


    End Sub

    Private Sub userControlOperationBoth_DLLOperationCreated_MoveRange(par_operationV1 As DLL_OperationV1, par_inverseAnchor_PriorToRange As TwoCharacterDLLItem, par_inverseAnchor_NextToRange As TwoCharacterDLLItem) Handles userControlOperationBoth.DLLOperationCreated_MoveRange
        ''
        ''Added 2/27/2024 td
        ''
        Dim enumMode As EnumTwoListsMode = GetCurrentListMode()

        If (enumMode = EnumTwoListsMode.HorizontalCols) Then

        ElseIf (enumMode = EnumTwoListsMode.VerticalRows) Then

        End If


    End Sub

    Private Sub userControlOperationBoth_DLLOperationCreated_SortAscending(par_operationV1 As DLL_OperationV1, par_isUndoOfSort As Boolean) Handles userControlOperationBoth.DLLOperationCreated_SortAscending
        ''
        ''Added 2/27/2024 td
        ''
        Dim enumMode As EnumTwoListsMode = GetCurrentListMode()

        If (enumMode = EnumTwoListsMode.HorizontalCols) Then

        ElseIf (enumMode = EnumTwoListsMode.VerticalRows) Then

        End If



    End Sub

    Private Sub userControlOperationBoth_DLLOperationCreated_SortDescending(par_operationV1 As DLL_OperationV1, par_isUndoOfSort As Boolean) Handles userControlOperationBoth.DLLOperationCreated_SortDescending
        ''
        ''Added 2/27/2024 td
        ''
        Dim enumMode As EnumTwoListsMode = GetCurrentListMode()

        If (enumMode = EnumTwoListsMode.HorizontalCols) Then

        ElseIf (enumMode = EnumTwoListsMode.VerticalRows) Then

        End If


    End Sub

    Private Sub Display1_MouseUp(sender As Object, e As MouseEventArgs) Handles labelItemsDisplay1.MouseUp
        ''
        ''Added 2/29/2024 thomas downes
        ''




    End Sub

    Private Sub Display2_MouseUp(sender As Object, e As MouseEventArgs) Handles labelItemsDisplay2.MouseUp
        ''
        ''Added 2/29/2024 thomas downes
        ''



    End Sub


End Class