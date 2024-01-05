''
''Added 1/04/2024
''
Partial Public Class DLL_List_OfTControl_PLEASE_USE
    ''
    ''We will use Merge Sort
    ''
    Public Sub DLL_SortItems()
        ''
        ''Added 1/04/2024
        ''








    End Sub ''eND OF ""Public Sub DLL_SortItems()""


    Private Class DLL_RangeQueue
        ''
        ''Added 1/4/2024 thomas downes
        ''
        Public Count As Integer
        Private mod_firstItem As IDoublyLinkedItem

        Public Sub New(par_first As IDoublyLinkedItem, par_count As Integer)
            mod_firstItem = par_first
            Count = par_count
        End Sub

        Public Function Peek() As IDoublyLinkedItem
            Return mod_firstItem
        End Function

        Public Sub Dequeue()
            If (Count = 0) Then Debugger.Break()
            mod_firstItem = mod_firstItem.DLL_GetItemNext
            Count -= 1 ''Decrease the count
        End Sub ''End of ""Public Sub Dequeue()""

    End Class ''End of ""Private Class DLL_RangeQueue""



    ''' <summary>
    ''' Sorting a sub-list of the overall list. We will break the sub-list into two halves,
    ''' call this same function (recursion) twice (each of the two(2) halves), then finally
    ''' merge the two sorted halves.
    ''' </summary>
    ''' <param name="par_startingItem">First item of the sublist being sorted.</param>
    ''' <param name="par_countOfItems">The count of items in the sublist.</param>
    ''' <param name="par_indexOfStart">Index (location) of starting item of sublist.</param>
    Private Sub SortItemsOfSublist_Recursive(par_startingItem As IDoublyLinkedItem,
                                   par_countOfItems As Integer,
                                   par_indexOfStart As Integer,
                                   ByRef byref_firstOfSort As IDoublyLinkedItem)
        ''
        ''Added 1/04/2024
        ''
        If (par_countOfItems <= 1) Then
            ''
            ''Base Case
            ''
            Exit Sub
        End If ''End of ""If (par_countOfItems <= 1) Then""

        Dim itemPrecedingFirstHalf As IDoublyLinkedItem = Nothing
        Dim hasItemPrecedingFirstHalf As Boolean = False
        If (par_startingItem.DLL_HasPrior()) Then
            ''This preceding item will be used to "Anchor" the first merged item. 
            itemPrecedingFirstHalf = par_startingItem.DLL_GetItemPrior()
            hasItemPrecedingFirstHalf = True
        End If ''End of ""If (par_startingItem.DLL_HasPrior()) Then""

        Dim itemFirstOf_2nd_Half As IDoublyLinkedItem
        Dim countOfFirstHalf As Integer
        Dim countOf_2nd_Half As Integer
        Dim indexOf_2nd_Half As Integer

        countOfFirstHalf = par_countOfItems / 2
        ''The following will get the first item of the second half, 
        ''  _NOT_ the last item of the first half. 
        itemFirstOf_2nd_Half = par_startingItem.DLL_GetItemNext(countOfFirstHalf)
        indexOf_2nd_Half = (par_indexOfStart + countOfFirstHalf)
        countOf_2nd_Half = (par_countOfItems - countOfFirstHalf)

        Dim itemFirstOfSort_1stHalf As IDoublyLinkedItem = Nothing
        Dim itemFirstOfSort_2ndHalf As IDoublyLinkedItem = Nothing

        ''
        ''
        ''
        '' Part One of Two:  Recursive Calls!!
        ''
        ''
        ''
        ''First half.
        SortItemsOfSublist_Recursive(par_startingItem, countOfFirstHalf, par_indexOfStart,
                                     itemFirstOfSort_1stHalf)
        ''Second half.
        SortItemsOfSublist_Recursive(itemFirstOf_2nd_Half, countOf_2nd_Half, indexOf_2nd_Half,
                                     itemFirstOfSort_2ndHalf)

        ''
        ''
        ''
        '' Part Two of Two:  Recursive Calls!!
        ''
        ''
        ''
        Dim postSort_itemFirstOfFirstHalf As IDoublyLinkedItem
        Dim postSort_itemFirstOf_2nd_Half As IDoublyLinkedItem
        postSort_itemFirstOfFirstHalf = itemFirstOfSort_1stHalf
        postSort_itemFirstOf_2nd_Half = itemFirstOfSort_2ndHalf
        Dim postSort_queue1stHalf = New DLL_RangeQueue(postSort_itemFirstOfFirstHalf, countOfFirstHalf)
        Dim postSort_queue2ndHalf = New DLL_RangeQueue(postSort_itemFirstOf_2nd_Half, countOf_2nd_Half)

        ''
        ''Merging the two halves!!
        ''
        Dim itemFirstOfMerge As IDoublyLinkedItem
        Dim bFirstArgumentIsLess As Boolean = False ''This is an output parameter.
        itemFirstOfMerge = DLL_ItemOfLesserValue(postSort_itemFirstOfFirstHalf,
                                                 postSort_itemFirstOf_2nd_Half,
                                                 bFirstArgumentIsLess)
        ''Important for output!!!
        byref_firstOfSort = itemFirstOfMerge

        Dim bFirstHalfItemIsSelected As Boolean
        bFirstHalfItemIsSelected = bFirstArgumentIsLess
        If (bFirstHalfItemIsSelected) Then
            ''Remove the selected item from the queue.
            postSort_queue1stHalf.Dequeue()
        Else
            ''Remove the selected item from the queue.
            postSort_queue2ndHalf.Dequeue()
        End If

        ''The following indices start from zero, regardless of the 
        ''  location of the sublist. 
        Dim intRelativeIndex_1stHalf As Integer = 0
        Dim intRelativeIndex_2ndHalf As Integer = 0
        Dim bCompleted As Boolean = False
        Dim item_toCompare1stHalf As IDoublyLinkedItem
        Dim item_toCompare2ndHalf As IDoublyLinkedItem
        Dim itemLesser As IDoublyLinkedItem
        Dim itemLesser_Prior As IDoublyLinkedItem = itemFirstOfMerge

        ''Create two queues of items.
        ''Dim postSort_queue1stHalf As New Queue(Of IDoublyLinkedItem)
        ''Dim postSort_queue2ndHalf As New Queue(Of IDoublyLinkedItem)

        ''''
        ''''Loop to fill Queue #1 of 2.  (First Half.)
        ''''
        ''bCompleted = False
        ''Dim temp_item As IDoublyLinkedItem = postSort_itemFirstOfFirstHalf
        ''Dim intHowManyEnqueued As Integer = 0
        ''While (Not bCompleted)
        ''    postSort_queue1stHalf.Enqueue(temp_item)
        ''    intHowManyEnqueued += 1
        ''    temp_item = temp_item.DLL_GetItemNext()
        ''    bCompleted = (intHowManyEnqueued >= intCountOfFirstHalf)
        ''End While

        ''''
        ''''Loop to fill Queue #2 of 2.  (Second (2nd) Half.)
        ''''
        ''bCompleted = False
        ''temp_item = postSort_itemFirstOf_2nd_Half
        ''intHowManyEnqueued = 0
        ''While (Not bCompleted)
        ''    postSort_queue2ndHalf.Enqueue(temp_item)
        ''    intHowManyEnqueued += 1
        ''    temp_item = temp_item.DLL_GetItemNext()
        ''    bCompleted = (intHowManyEnqueued >= intCountOf_2nd_Half)
        ''End While

        ''
        ''Loop to accomplish a sorted merge. 
        ''
        bCompleted = False
        Dim hasNoItems_queue1stHalf As Boolean = False
        Dim hasNoItems_queue2ndHalf As Boolean = False

        While (Not bCompleted)

            ''item_toCompare1stHalf = postSort_itemFirstOfFirstHalf.DLL_GetItemNext(intRelativeIndex_1stHalf)
            ''item_toCompare2ndHalf = postSort_itemFirstOf_2nd_Half.DLL_GetItemNext(intRelativeIndex_2ndHalf)

            If (hasNoItems_queue1stHalf) Then
                itemLesser = postSort_queue2ndHalf.Peek()
                ''We must dequeue prior to "Linkage step!!" below.
                postSort_queue2ndHalf.Dequeue()
            ElseIf (hasNoItems_queue2ndHalf) Then
                itemLesser = postSort_queue1stHalf.Peek()
                ''We must dequeue prior to "Linkage step!!" below.
                postSort_queue1stHalf.Dequeue()
            Else
                item_toCompare1stHalf = postSort_queue1stHalf.Peek()
                item_toCompare2ndHalf = postSort_queue2ndHalf.Peek()
                bFirstArgumentIsLess = False ''Re-initialize.
                itemLesser = DLL_ItemOfLesserValue(item_toCompare1stHalf,
                                                   item_toCompare2ndHalf,
                                                   bFirstArgumentIsLess)
                ''
                ''We must dequeue prior to "Linkage step!!" below.
                ''
                If (bFirstArgumentIsLess) Then
                    postSort_queue1stHalf.Dequeue()
                Else
                    postSort_queue2ndHalf.Dequeue()
                End If
            End If ''End of ""If (hasNoItems_queue1stHalf) Then... ElseIf... Else..."

            ''
            ''Linkage step!!
            ''
            ''Link the newly-selected item for the next in the merged sublist.
            ''
            itemLesser_Prior.DLL_SetItemNext(itemLesser)
            itemLesser.DLL_SetItemPrior(itemLesser_Prior)

            ''
            ''Prepare for next iteration of the While loop.
            ''
            itemLesser_Prior = itemLesser

            ''If (bFirstArgumentIsLess) Then
            ''    intRelativeIndex_1stHalf += 1
            ''Else
            ''    intRelativeIndex_2ndHalf += 1
            ''End If
            hasNoItems_queue1stHalf = (0 = postSort_queue1stHalf.Count)
            hasNoItems_queue2ndHalf = (0 = postSort_queue2ndHalf.Count)
            bCompleted = (hasNoItems_queue1stHalf And hasNoItems_queue2ndHalf)

        End While

        ''
        ''Done, so we'll pass back the first of the merged items. 
        ''
        byref_firstOfSort = itemFirstOfMerge

    End Sub ''eND OF ""Public Sub SortItems_Recursive()""






End Class



