Imports ciBadgeInterfaces

''' <summary>
''' This will allow the user to create DLLOperations.
''' </summary>
Public Class UserControlOperation

    Public DLLOperation As DLL_OperationV2
    Public DLL_List As DLL_List_OfTControl_PLEASE_USE(Of TwoCharacterDLLItem)

    ''Added 12/23/2023
    ''' <summary>
    ''' In case of an UNDO-OF-DELETE operation, we will need to know the
    ''' pre-deletion connecting node(s).  (Obviously, these node are NOT deleted.) 
    ''' </summary>
    Public DLL_InverseAnchor_PriorToRange As TwoCharacterDLLItem = Nothing ''Added 12/23/2023
    ''' <summary>
    ''' In case of an UNDO-OF-DELETE operation, we will need to know the
    ''' pre-deletion connecting node(s).  (Obviously, these node are NOT deleted.) 
    ''' </summary>
    Public DLL_InverseAnchor_NextToRange As TwoCharacterDLLItem = Nothing ''Added 12/23/2023

    ''' <summary>
    ''' This will communicate the details of an INSERT operation, 
    ''' which the user has requested, and which hasn't yet been performed.
    ''' </summary>
    ''' <param name="par_operation">Gives detail of operation.</param>
    Public Event DLLOperationCreated_Insert(par_operation As DLL_OperationV2)
    ''--Public Event DLLOperationCreated_Delete(par_operation As DLL_OperationV2)

    ''' <summary>
    ''' This will communicate the details of an INSERT operation, 
    ''' which the user has requested, and which hasn't yet been performed.
    ''' </summary>
    ''' <param name="par_operation">Gives detail of operation.</param>
    ''' <param name="par_inverseAnchor_PriorToRange">Needed in case of UNDO-OF-DELETE.</param>
    ''' <param name="par_inverseAnchor_NextToRange">Needed in case of UNDO-OF-DELETE.</param>
    Public Event DLLOperationCreated_Delete(par_operation As DLL_OperationV2,
                                par_inverseAnchor_PriorToRange As TwoCharacterDLLItem,
                                par_inverseAnchor_NextToRange As TwoCharacterDLLItem)
    ''' <summary>
    ''' This will communicate the details of an INSERT operation, 
    ''' which the user has requested, and which hasn't yet been performed.
    ''' </summary>
    ''' <param name="par_operation">Gives detail of operation.</param>
    Public Event DLLOperationCreated_MoveRange(par_operation As DLL_OperationV2,
                                par_inverseAnchor_PriorToRange As TwoCharacterDLLItem,
                                par_inverseAnchor_NextToRange As TwoCharacterDLLItem)


    Private Sub ButtonInsert_Click(sender As Object, e As EventArgs) Handles buttonInsert.Click
        ''
        ''Create a DLL-Insert operation and publish it as an event,
        ''    so that the user-interface form can detect it and 
        ''    leverage this new operation.
        ''
        Dim objDLLOperation As DLL_OperationV2
        Dim firstRangeItem As TwoCharacterDLLItem
        ''Dim indexOfRangeFirst As Integer
        Dim indexOfAnchor As Integer
        Dim bBefore_LetsInsertRangeBeforeAnchor As Boolean ''Added 12/23/2023
        Dim bAfter_LetsInsertRangeAfterAnchor As Boolean ''Added 12/23/2023
        Dim intHowManyItemsToInsert As Integer
        Dim anchorItem As TwoCharacterDLLItem
        Dim anchorItem_ToBePriorToRange As TwoCharacterDLLItem
        Dim anchorItem_ToFollowRange As TwoCharacterDLLItem

        ''intHowManyItemsToInsert = numInsertHowMany.Value
        intHowManyItemsToInsert = GetHowManyItems("I"c)

        ''0 = After, 1 = Before
        bBefore_LetsInsertRangeBeforeAnchor = (1 = listInsertAfterOr.SelectedIndex) ''After (0) or Before (1)
        bAfter_LetsInsertRangeAfterAnchor = (0 = listInsertAfterOr.SelectedIndex) ''After (0) or Before (1)

        ''indexOfRangeFirst = numInsertRangeFirst.Value
        ''indexOfAnchor = (-1 + numInsertAnchorBenchmark.Value)
        indexOfAnchor = GetIndex_BenchmarkMinusOne("I"c, True)

        anchorItem = Me.DLL_List.DLL_GetItemAtIndex(indexOfAnchor)

        ''-----------DIFFICULT & CONFUSING---------
        If (bAfter_LetsInsertRangeAfterAnchor) Then
            ''-----------DIFFICULT & CONFUSING---------
            anchorItem_ToBePriorToRange = anchorItem
        ElseIf (bBefore_LetsInsertRangeBeforeAnchor) Then
            ''-----------DIFFICULT & CONFUSING---------
            anchorItem_ToFollowRange = anchorItem
        End If

        firstRangeItem = BuildNewItemsDLL_FirstInRange(intHowManyItemsToInsert)

        objDLLOperation = New DLL_OperationV2("I"c, firstRangeItem,
                intHowManyItemsToInsert, anchorItem)

        RaiseEvent DLLOperationCreated_Insert(objDLLOperation)

        ''Administrative.
        ''  Inserts do NOT have an "inverse anchor".
        DLL_InverseAnchor_PriorToRange = Nothing
        DLL_InverseAnchor_NextToRange = Nothing

    End Sub ''End of ""Private Sub ButtonInsert_Click""


    Private Sub ButtonDelete_Click(sender As Object, e As EventArgs) Handles buttonDelete.Click
        ''
        ''Create a DLL-Delete operation and publish it as an event,
        ''    so that the user-interface form can detect it and 
        ''    leverage this new operation.
        ''
        Dim objDLLOperation As DLL_OperationV2
        Dim firstRangeItem As TwoCharacterDLLItem
        Dim lastRangeItem As TwoCharacterDLLItem
        Dim indexOfRangeFirst As Integer
        ''Dim indexOfAnchor As Integer
        ''---Dim boolInsertAfter As Boolean
        Dim intHowManyItemsToDelete As Integer
        ''Dim inverse_anchorItem As TwoCharacterDLLItem

        ''12/23/2023 intHowManyItemsToDelete = numInsertHowMany.Value
        ''#2 12/23/2023 intHowManyItemsToDelete = numDeleteHowMany.Value
        intHowManyItemsToDelete = GetHowManyItems("D"c)

        ''boolInsertAfter = (1 <> listInsertAfterOr.SelectedIndex)
        ''indexOfRangeFirst = numDeleteRangeBenchmarkStart.Value
        indexOfRangeFirst = GetIndex_BenchmarkMinusOne("D"c)

        ''indexOfAnchor = (-1 + numInsertAnchorBenchmark.Value)
        ''anchorItem = Me.DLL_List.DLL_GetItemAtIndex(indexOfAnchor)
        ''firstRangeItem = BuildNewItemsDLL_FirstInRange(intHowManyItemsToInsert)
        firstRangeItem = Me.DLL_List.DLL_GetItemAtIndex(indexOfRangeFirst)
        lastRangeItem = firstRangeItem.DLL_GetItemNext(-1 + intHowManyItemsToDelete)

        objDLLOperation = New DLL_OperationV2("D"c, firstRangeItem,
                intHowManyItemsToDelete, Nothing, Nothing)

        ''//inverse_anchorItem = objDLLOperation.

        ''//RaiseEvent DLLOperationCreated_Insert(objDLLOperation)
        RaiseEvent DLLOperationCreated_Delete(objDLLOperation,
                         firstRangeItem.DLL_GetItemPrior(),
                         lastRangeItem.DLL_GetItemNext())

        ''Administrative.
        ''   We need the inverse anchor for the "Undo" operation. 
        Me.DLL_InverseAnchor_PriorToRange = firstRangeItem.DLL_GetItemPrior()
        Me.DLL_InverseAnchor_NextToRange = lastRangeItem.DLL_GetItemNext()

    End Sub ''End of ""Private Sub ButtonDelete_Click""


    Private Sub buttonMoveItems_Click(sender As Object, e As EventArgs) Handles buttonMoveItems.Click
        ''
        ''Create a DLL-Move operation and publish it as an event,
        ''    so that the user-interface form can detect it and 
        ''    leverage this new operation.
        ''
        Dim objDLLOperation As DLL_OperationV2
        Dim firstRangeItem As TwoCharacterDLLItem
        Dim lastRangeItem As TwoCharacterDLLItem
        Dim indexOfRangeFirst As Integer
        Dim intHowManyItemsToMove As Integer
        Dim indexOfAnchor As Integer
        Dim anchorItem As TwoCharacterDLLItem
        Dim anchorItem_ToBePriorToRange As TwoCharacterDLLItem ''Added 12/23/2023
        Dim anchorItem_ToFollowRange As TwoCharacterDLLItem ''Added 12/23/2023
        Dim bLetsInsertRangeBeforeAnchor As Boolean ''Added 12/23/2023
        Dim bLetsInsertRangeAfterAnchor As Boolean ''Added 12/23/2023

        ''12/2023 intHowManyItemsToMove = numMoveRangeHowMany.Value
        intHowManyItemsToMove = GetHowManyItems("M"c) '' "M" for "Move"

        ''indexOfRangeFirst = numMoveRangeStartBenchmark.Value
        indexOfRangeFirst = GetIndex_BenchmarkMinusOne("M"c, pbAnchor:=False)

        firstRangeItem = Me.DLL_List.DLL_GetItemAtIndex(indexOfRangeFirst)
        lastRangeItem = firstRangeItem.DLL_GetItemNext(-1 + intHowManyItemsToMove)

        bLetsInsertRangeBeforeAnchor = (0 <> listMoveAfterOr.SelectedIndex) ''After (0) or Before (1)
        bLetsInsertRangeAfterAnchor = (1 <> listMoveAfterOr.SelectedIndex) ''After (0) or Before (1)
        ''---indexOfAnchor = (-1 + numInsertAnchorBenchmark.Value)
        indexOfAnchor = GetIndex_BenchmarkMinusOne("M"c, pbAnchor:=True)

        anchorItem = Me.DLL_List.DLL_GetItemAtIndex(indexOfAnchor)

        If (bLetsInsertRangeAfterAnchor) Then
            anchorItem_ToBePriorToRange = anchorItem
        ElseIf (bLetsInsertRangeBeforeAnchor) Then
            anchorItem_ToFollowRange = anchorItem
        End If

        '' "M" for "Move"
        objDLLOperation = New DLL_OperationV2("M"c, firstRangeItem,
                intHowManyItemsToMove, Nothing, Nothing)

        ''//inverse_anchorItem = objDLLOperation.

        ''//RaiseEvent DLLOperationCreated_Insert(objDLLOperation)
        RaiseEvent DLLOperationCreated_MoveRange(objDLLOperation,
                         firstRangeItem.DLL_GetItemPrior(),
                         lastRangeItem.DLL_GetItemNext())

        ''Administrative.
        ''   We need the inverse anchor for the "Undo" operation. 
        Me.DLL_InverseAnchor_PriorToRange = firstRangeItem.DLL_GetItemPrior()
        Me.DLL_InverseAnchor_NextToRange = lastRangeItem.DLL_GetItemNext()

    End Sub



    ''' <summary>
    ''' Generate a brand-new DLL (w/ brand-new items) for eventual insertion.
    ''' </summary>
    ''' <returns></returns>
    Private Function BuildNewItemsDLL_FirstInRange(pintHowManyItemsToInsert As Integer) As TwoCharacterDLLItem
        ''
        ''Added 12/20/2023
        ''
        Dim firstRangeItem As TwoCharacterDLLItem = Nothing
        Dim strMessage As String

        If ("" = textInsertListOfValuesCSV.Text.Trim()) Then
            strMessage = String.Format("The values box is empty.")
            MessageBox.Show(strMessage & vbCrLf & "Nothing to be done.")
            Return Nothing ''Exit Function
        End If

        ''---firstRangeItem = DLL_List.DLL_GetItemAtIndex(0)
        ''---valuesTwoChar = textInsertListOfValuesCSV.Text.Substring(0, 2)
        Dim valuesTwoChar = textInsertListOfValuesCSV.Text.Split(" "c)
        Dim bCountMatches As Boolean
        Dim bMultipleTwoDigits As Boolean

        bMultipleTwoDigits = (1 < valuesTwoChar.Length)
        bCountMatches = (pintHowManyItemsToInsert = valuesTwoChar.Length)
        If (Not bCountMatches) Then
            strMessage = String.Format("The count of Two-Digit pairs is {0} not {1}.",
                 valuesTwoChar.Length, pintHowManyItemsToInsert)
            MessageBox.Show(strMessage & vbCrLf & "Nothing to be done.")
            Return Nothing '' Exit Function

        End If ''End of ""If (Not bCountMatches) Then""

        Dim bFirstValue As Boolean = True
        Dim each_item As TwoCharacterDLLItem
        Dim prior_item As TwoCharacterDLLItem = Nothing
        Dim each_twoChars As String

        ''
        '' Build the new DLL items. 
        ''
        ''---For Each each_value As String In valuesTwoChar
        For index = 0 To (-1 + pintHowManyItemsToInsert)
            ''
            ''Create a DLL item. 
            ''
            If (bMultipleTwoDigits) Then
                each_twoChars = valuesTwoChar(index)
            Else
                each_twoChars = textInsertListOfValuesCSV.Text.Trim()
            End If

            each_item = New TwoCharacterDLLItem(each_twoChars, Nothing)

            If (bFirstValue) Then
                firstRangeItem = each_item ''New TwoCharacterDLLItem(each_value, Nothing)
            Else
                prior_item.DLL_SetItemNext(each_item)
                each_item.DLL_SetItemPrior(prior_item)
            End If ''End of ""If (bFirstValue) Then... Else..."

            ''Prepare for next iteration.
            prior_item = each_item
            bFirstValue = False

        Next index ''For each_value

        Return firstRangeItem

    End Function


    Private Sub UserControlOperation_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ''Set the After/Before listboxes to "After" 
        ''  by default.   ---12/2023 td
        listInsertAfterOr.SelectedIndex = 0
        listMoveAfterOr.SelectedIndex = 0

    End Sub


    Private Function GetHowManyItems(par_type As Char) As Integer
        ''
        ''Added 12/23/2023  
        ''
        ''---Dim intDesiredCountOfItems As Integer
        Select Case par_type
            Case "I"c, "i"c
                '' "I" = "Insert"
                Return numInsertHowMany.Value
            Case "D"c, "d"c
                '' "D" = "Delete"
                Return numDeleteHowMany.Value

            Case "M"c, "m"c
                '' "M" = "Move"
                Return numMoveRangeHowMany.Value

            Case Else
                Debugger.Break()

        End Select ''End of ""Select Case par_type""
        Return 0

    End Function ''Private Function GetHowManyItems


    Private Sub RandomizeHowManyItems(par_type As Char, pintIndexStart As Integer) ''As Integer
        ''
        ''Added 12/23/2023  
        ''
        Dim intCountCurrentListItems As Integer = DLL_List.DLL_CountAllItems()
        Const MAX_NEW As Integer = 3
        Static random_gen As Random = New Random()

        ''---Dim intDesiredCountOfItems As Integer
        Select Case par_type
            Case "I"c, "i"c
                '' "I" = "Insert"
                ''----numInsertHowMany.Value = (1 + random_gen.Next(intCountCurrentListItems - pintIndexStart))
                numInsertHowMany.Value = (1 + random_gen.Next(MAX_NEW))

            Case "D"c, "d"c
                '' "D" = "Delete"
                numDeleteHowMany.Value = (1 + random_gen.Next(intCountCurrentListItems - pintIndexStart))

            Case "M"c, "m"c
                '' "M" = "Move"
                ''----Return numMoveRangeHowMany.Value
                numMoveRangeHowMany.Value = (1 + random_gen.Next(intCountCurrentListItems - pintIndexStart))

            Case Else
                Debugger.Break()

        End Select ''End of ""Select Case par_type""

    End Sub ''Private Sub RandomizeHowManyItems


    Private Function GetIndex_BenchmarkMinusOne(par_type As Char,
                                     Optional pbAnchor As Boolean = False) As Integer
        ''
        ''Added 12/23/2023  
        ''
        ''---Dim intDesiredCountOfItems As Integer
        Select Case par_type
            Case "I"c, "i"c
                '' "I" = "Insert"
                Return (-1 + numInsertAnchorBenchmark.Value)

            Case "D"c, "d"c
                '' "D" = "Delete"
                Return (-1 + numDeleteRangeBenchmarkStart.Value)

            Case "M"c, "m"c
                '' "M" = "Move"
                If (pbAnchor) Then
                    Return (-1 + numMoveAnchorBenchmark.Value)
                Else
                    Return (-1 + numMoveRangeStartBenchmark.Value)
                End If

            Case Else
                Debugger.Break()

        End Select ''End of ""Select Case par_type""
        Return 0

    End Function ''Private Function GetHowManyItems


    Private Sub RandomizeStartingBenchmark(par_type As Char, Optional pbAnchor As Boolean = False) ''As Integer
        ''
        ''Added 12/23/2023  
        ''
        Dim intCountCurrentListItems As Integer = DLL_List.DLL_CountAllItems()
        Static random_gen As Random = New Random()

        ''---Dim intDesiredCountOfItems As Integer
        Select Case par_type
            Case "I"c, "i"c
                '' "I" = "Insert"
                numInsertAnchorBenchmark.Value = (1 + random_gen.Next(intCountCurrentListItems))

            Case "D"c, "d"c
                '' "D" = "Delete"
                numDeleteRangeBenchmarkStart.Value = (1 + random_gen.Next(intCountCurrentListItems))

            Case "M"c, "m"c
                '' "M" = "Move"
                ''----Return numMoveRangeHowMany.Value
                If (pbAnchor) Then
                    numMoveAnchorBenchmark.Value = (1 + random_gen.Next(intCountCurrentListItems))
                Else
                    numMoveRangeStartBenchmark.Value = (1 + random_gen.Next(intCountCurrentListItems))
                End If

            Case Else
                Debugger.Break()

        End Select ''End of ""Select Case par_type""

    End Sub ''Private Sub RandomizeStartingBenchmark



    Private Sub LinkInsertRandomize_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkInsertRandomize.LinkClicked
        ''
        ''Randomize Insert
        ''
        RandomizeStartingBenchmark("I"c)
        RandomizeHowManyItems("I"c, -1)
        ''
        ''Perform click?
        ''
        ''buttonInsert.PerformClick()

    End Sub

    Private Sub LinkDeleteRandomize_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkDeleteRandomize.LinkClicked
        ''
        ''Randomize Delete
        ''
        RandomizeStartingBenchmark("D"c)
        RandomizeHowManyItems("D"c, GetIndex_BenchmarkMinusOne("D"c))
        ''
        ''Perform click?
        ''
        ''buttonDelete.PerformClick()

    End Sub

    Private Sub LinkMoveRandomize_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkMoveRandomize.LinkClicked
        ''
        ''Randomize Delete
        ''
        RandomizeStartingBenchmark("M"c, pbAnchor:=False)
        RandomizeHowManyItems("M"c, GetIndex_BenchmarkMinusOne("M"c))
        RandomizeStartingBenchmark("M"c, pbAnchor:=True)
        ''
        ''Perform click?
        ''
        ''buttonMove.PerformClick()

    End Sub
End Class
