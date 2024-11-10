''
'' Added 10/14/2024 T_homas C. D_ownes 
''
Imports System.ComponentModel.Design
Imports System.Diagnostics.Metrics
Imports System.Text
Imports RSCLibraryDLLOperations

Public Class FormSimpleDemoOfCSharp1D
    ''
    '' Added 10/14/2024 thomas c. downes 
    ''
    Private mod_manager As DLLOperationsManager1D(Of TwoCharacterDLLItem)
    Private WithEvents mod_list As DLLList(Of TwoCharacterDLLItem)
    Private mod_firstItem As TwoCharacterDLLItem
    Private mod_lastItem As TwoCharacterDLLItem

    Private Const INITIAL_ITEM_COUNT_30 As Integer = 30
    Private ReadOnly ARRAY_OF_DELIMITERS = New Char() {","c, " "c}


    Private Sub FormSimpleDemoOfCSharp1D_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        '' Added 10/14/2024 thomas c. downes 
        ''
        Dim anchorItemForEmptyList As New DLLAnchorItem(Of TwoCharacterDLLItem)(True, False)
        Dim anchorItemForListOfOneItem As DLLAnchorItem(Of TwoCharacterDLLItem) ''(True, False)
        Dim anchorPairForEmptyList As New DLLAnchorCouplet(Of TwoCharacterDLLItem)(True, False)
        Dim anchorPairForListOfOneItem As DLLAnchorCouplet(Of TwoCharacterDLLItem) ''(True, False)
        Dim rangeNew As DLLRange(Of TwoCharacterDLLItem)
        Dim indexNewItem As Integer
        Dim newItem As TwoCharacterDLLItem
        ''Dim priorItem As TwoCharacterDLLItem

        Dim PERFORM_INITIAL_INSERT_MANUALLY As Boolean = False ''---True

        mod_firstItem = New TwoCharacterDLLItem("01")
        mod_lastItem = mod_firstItem
        mod_list = New DLLList(Of TwoCharacterDLLItem)(mod_firstItem, mod_lastItem, 1)

        ''//Added 10/21/2024 td
        anchorItemForListOfOneItem = New DLLAnchorItem(Of TwoCharacterDLLItem)(mod_firstItem)

        ''//Added 11/08/2024 td
        anchorPairForListOfOneItem = New DLLAnchorCouplet(Of TwoCharacterDLLItem)(mod_firstItem, Nothing, True)

        ''//rangeNew = New DLLRange(Of TwoCharacterDLLItem)(mod_firstItem, True)
        ''//For indexNewItem = 2 To INITIAL_ITEM_COUNT_30 ''---30
        rangeNew = New DLLRange(Of TwoCharacterDLLItem)(New TwoCharacterDLLItem("02"), True)

        ''Modified "(2 + 1)" on 11/8/2024 td
        For indexNewItem = (2 + 1) To INITIAL_ITEM_COUNT_30 ''---30
            newItem = New TwoCharacterDLLItem(indexNewItem.ToString("00"))
            rangeNew.DLL_InsertItemToTheEnd(newItem)
        Next indexNewItem

        ''
        '' Create the operation, or simply insert the range
        ''   without an operation.
        ''
        If (PERFORM_INITIAL_INSERT_MANUALLY) Then
            ''
            ''No DLLOperation object will be created.
            ''
            mod_list.DLL_InsertRangeIntoEmptyList(rangeNew)

        Else
            ''
            ''Added 10/20/2024  
            ''
            Dim operationInitial30 As DLLOperation1D(Of TwoCharacterDLLItem)
            ''operationInitial30 = New DLLOperation1D(Of TwoCharacterDLLItem)(rangeNew, True, False,
            ''                                                          True, False, False,
            ''                                                    anchorForEmptyList, False, False, False)
            operationInitial30 = New DLLOperation1D(Of TwoCharacterDLLItem)(rangeNew, True, False,
                                                                      True, False, False,
                                          anchorItemForListOfOneItem,
                                          anchorPairForListOfOneItem,
                                          False, False, False)

            operationInitial30.OperateOnList(mod_list)

            ''Added 10/20/2024  
            mod_manager = New DLLOperationsManager1D(Of TwoCharacterDLLItem)(mod_firstItem,
                                                     mod_list, operationInitial30)

        End If ''End of ""If (PERFORM_INITIAL_INSERT_MANUALLY) Then""  

        ''
        '' Display the list. 
        ''
        RefreshTheUI_DisplayList()


    End Sub


    Private Sub RefreshTheUI_DisplayList()

        ''Populate the UI. 
        Dim strListOfLinks As String
        strListOfLinks = FillTheTextboxDisplayingList()
        labelItemsDisplay.Text = strListOfLinks

        ''Added 12/28/2023 
        Dim itemCount As Integer = mod_list.DLL_CountAllItems()
        ''userControlOperation1.UpdateTheItemCount(itemCount)

        ''Added 1/04/202
        ''
        ''  Let's maintain the two(2) linklabels which represent
        ''    the list's endpoint & prior-to-endpoint.
        ''
        Dim last_item As TwoCharacterDLLItem = Nothing
        Dim prior_to_last As TwoCharacterDLLItem = Nothing

        last_item = CType(mod_list.DLL_GetLastItem_OfT(), TwoCharacterDLLItem)
        If (last_item Is Nothing) Then
            ''
            ''The user has elected to delete the entire list. 
            ''
        Else
            ''linkToEndpoint.Text = last_item.ToString()
            prior_to_last = CType(last_item.DLL_GetItemPrior(), TwoCharacterDLLItem)
            If (prior_to_last IsNot Nothing) Then
                ''linkToPenultimate.Text = prior_to_last.ToString()
            End If ''End of ""If (prior_to_last IsNot Nothing) Then""
        End If ''End of ""If (last_item Is Nothing) Then... Else..."

        ''Added 1/04/2024
        ''linkToEndpoint.Tag = last_item ''.ToString()

        ''Added 1/04/2024
        ''userControlOperation1.Lists_Endpoint = last_item
        ''userControlOperation1.Lists_Penultimate = prior_to_last

        ''Added 1/04/2024
        ''linkToPenultimate.Tag = prior_to_last ''.ToString()

    End Sub ''End of ""Private Sub RefreshTheUI_DisplayList()""


    Private Function FillTheTextboxDisplayingList() As String
        ''
        ''Added 12/26/2023  
        ''
        Dim each_twoChar As TwoCharacterDLLItem
        Dim bDone As Boolean = False
        Dim stringbuilderLinkedItems As New StringBuilder(120)
        Dim intCountLoops As Integer = 0
        Dim boolOpenHighlight As Boolean = True
        Dim boolCloseHighlight As Boolean = False
        Dim boolCloseHighlight_Next As Boolean = False

        ''LabelItemsDisplay.ResetText()
        ''Not needed here. ----labelItemsDisplay.Text = ""

        If (mod_firstItem Is Nothing) Then
            ''
            ''All the items have been deleted (most likely).
            ''
            Return "The list is empty."

        Else

            each_twoChar = mod_firstItem

            ''For Each each_twoChar In mod_list
            Do Until bDone

                ''La belItemsDisplay.Text.Append(" +++ " + each_twoChar.ToString())
                ''stringbuilderLinkedItems.Append(" " + each_twoChar.ToString())
                If (each_twoChar.Selected) Then
                    ''The item has been selected. 
                    stringbuilderLinkedItems.Append("_" + each_twoChar.ToString())

                ElseIf (each_twoChar.HighlightInGreen) Then
                    ''
                    ''The item has been highlighted.
                    ''
                    If (boolOpenHighlight) Then
                        stringbuilderLinkedItems.Append("[" + each_twoChar.ToString())
                        ''Prepare for future iterations. 
                        boolOpenHighlight = False
                        boolCloseHighlight = True
                    ElseIf (boolCloseHighlight) Then
                        ''
                        ''Prepare for the next item(s).
                        ''
                        ''stringbuilderLinkedItems.Append(" " + each_twoChar.ToString())
                        boolCloseHighlight_Next = True
                        boolCloseHighlight = False
                        boolOpenHighlight = True
                    End If ''end of ""If (boolOpenHighlight) Then ... ElseIf..."

                ElseIf (boolCloseHighlight_Next) Then
                    ''Added 11/09/2024 thomas downes 
                    stringbuilderLinkedItems.Append("]" + each_twoChar.ToString())
                    ''Clear the boolean, so it only is used once.
                    boolCloseHighlight_Next = False

                Else
                    ''Added 11/09/2024 thomas downes 
                    stringbuilderLinkedItems.Append(" " + each_twoChar.ToString())

                End If ''End of ""If (each_twoChar.Selected) Then... Else..."

                each_twoChar = each_twoChar.DLL_GetItemNext
                bDone = bDone Or (each_twoChar Is Nothing)
                intCountLoops += 1
                ''If (int CountLoops > 2 * 30) Then Debugger.Break()
                If (intCountLoops > 6 + INITIAL_ITEM_COUNT_30) Then Debugger.Break()

            Loop ''End of ""Do Until bDone""
            ''Next each_twoChar

            ''---MessageBoxTD.Show_Statement("Done loading!!")
            ''Return stringbuilderLinkedItems.ToString()
            Dim result As String
            result = stringbuilderLinkedItems.ToString()
            Return result

        End If ''End of ""If (mod_firstTwoChar Is Nothing) Then... Else..."

    End Function ''End of "Private Function FillTheTextboxDisplayingList()""

    Private Sub buttonInsertMulti_Click(sender As Object, e As EventArgs) Handles buttonInsertMultiple.Click
        ''
        '' Added 10/15/2024  
        ''
        Dim intInsertCount As Integer
        Dim intAnchorPosition As Integer
        Dim indexNewItem As Integer
        Dim objectRange As DLLRange(Of TwoCharacterDLLItem)
        Dim prior_newItem As TwoCharacterDLLItem
        Dim newItem As TwoCharacterDLLItem
        Dim first_newItem As TwoCharacterDLLItem
        Dim last_newItem As TwoCharacterDLLItem
        Dim intHowManyInModuleList As Integer
        Dim intNewIndexStart As Integer
        Dim intNewIndexEnd As Integer
        Dim array_sItemsToInsert As String()
        Dim bUserSpecifiedValues
        Dim strNewItem As String
        Dim intModulo As Integer
        Dim boolEndpoint As Boolean
        Dim objAnchor As DLLAnchorItem(Of TwoCharacterDLLItem)

        intInsertCount = numInsertHowMany.Value
        intAnchorPosition = numInsertAnchorBenchmark.Value
        intHowManyInModuleList = mod_list.DLL_CountAllItems
        boolEndpoint = intAnchorPosition = 1 Or intAnchorPosition = intHowManyInModuleList

        intNewIndexStart = 1 + intHowManyInModuleList
        intNewIndexEnd = intInsertCount + intHowManyInModuleList
        array_sItemsToInsert = textInsertListOfValuesCSV.Text.Split(New Char() {","c, " "c})
        bUserSpecifiedValues = array_sItemsToInsert.Count > 0

        For indexNewItem = intNewIndexStart To intNewIndexEnd

            ''//intModulo = indexNewItem Mod intInsertCount
            intModulo = (indexNewItem - intNewIndexStart) Mod array_sItemsToInsert.Length
            strNewItem = IIf(bUserSpecifiedValues, array_sItemsToInsert(intModulo),
                             indexNewItem.ToString("00"))
            If (strNewItem.Length = 1) Then strNewItem = ("=" & strNewItem)
            newItem = New TwoCharacterDLLItem(strNewItem)

            If first_newItem Is Nothing Then
                first_newItem = newItem
                objectRange = New DLLRange(Of TwoCharacterDLLItem)(True, Nothing, Nothing, first_newItem, 1)
            Else
                prior_newItem.DLL_SetItemNext(newItem)
                newItem.DLL_SetItemPrior(prior_newItem)
                objectRange = New DLLRange(Of TwoCharacterDLLItem)(True, Nothing, Nothing, first_newItem, 1)
            End If

            ''Prepare for next iteration.
            prior_newItem = newItem

        Next indexNewItem

        ''
        ''Save the last. 
        ''
        last_newItem = prior_newItem

        ''
        '' Set the range. 
        ''
        If intInsertCount = 1 Then
            objectRange = New DLLRange(Of TwoCharacterDLLItem)(first_newItem, True)
        Else
            ''
            '' There are at least two objects in the range. 
            ''
            objectRange = New DLLRange(Of TwoCharacterDLLItem)(False, first_newItem,
                                                               last_newItem, Nothing, intInsertCount)

        End If ''End of ""If (intInsertCount = 1) Then... Else..."

        ''
        ''Set the anchor. 
        ''
        Dim tempAnchorItem As TwoCharacterDLLItem ''Added 10/21/2024 td
        tempAnchorItem = mod_firstItem.DLL_GetItemNext(-1 + intAnchorPosition)
        objAnchor = New DLLAnchorItem(Of TwoCharacterDLLItem)(tempAnchorItem)
        With objAnchor
            ''._anchorItem = mod_firstItem.DLL_GetItemNext(-1 + intAnchorPosition)
            ._doInsertRangeAfterThis = (listInsertAfterOr.SelectedIndex < 1)
            ._doInsertRangeBeforeThis = (False = objAnchor._doInsertRangeAfterThis)
        End With

        ''Highlight the range's endpoints.
        objectRange.HighlightEndpoints_Green()

        ''
        '' Insert range into the list.  
        ''
        Const DIRECT_TO_LIST As Boolean = False ''Added 10/26/2024 thom dow.nes
        Const INSERT_OPERATION As Boolean = True '' False ''Added 10/26/2024 thomas downes
        Dim USE_OP_MANAGER As Boolean = (Not DIRECT_TO_LIST) ''Added 11/06/2024 thom dow.nes
        Dim anchor_couple As DLLAnchorCouplet(Of TwoCharacterDLLItem)
        Dim operation As DLLOperation1D(Of TwoCharacterDLLItem)
        Dim bChangeOfEndpoint As Boolean ''Added 11/06/2024 

        If (DIRECT_TO_LIST) Then
            If (listInsertAfterOr.SelectedIndex < 1) Then
                mod_list.DLL_InsertRangeAfter(objectRange, objAnchor._anchorItem) ''; ''---, boolEndpoint)
            Else
                mod_list.DLL_InsertRangeBefore(objectRange, objAnchor._anchorItem) ''; ''---, boolEndpoint)
            End If

        ElseIf (USE_OP_MANAGER And listInsertAfterOr.SelectedIndex < 1) Then
            ''
            ''Added 11/06/2024 td  
            ''
            ''---bChangeOfEndpoint = objectRange.ContainsEndpoint()
            ''anchor_couple = New DLLAnchorCouplet(Of TwoCharacterDLLItem)(tempAnchorItem,
            ''  tempAnchorItem.DLL_GetItemNext_OfT(), bChangeOfEndpoint)
            anchor_couple = New DLLAnchorCouplet(Of TwoCharacterDLLItem)(tempAnchorItem,
                                            tempAnchorItem.DLL_GetItemNext_OfT(),
                                            tempAnchorItem.DLL_IsEitherEndpoint())
            operation = New DLLOperation1D(Of TwoCharacterDLLItem)(objectRange, anchor_couple, True, False)
            ''operation.OperateOnList(mod_list)
            mod_manager.ProcessOperation_AnyType(operation, bChangeOfEndpoint, True)

        ElseIf (USE_OP_MANAGER And listInsertAfterOr.SelectedIndex >= 1) Then
            ''
            ''Added 11/06/2024 td  
            ''
            ''---bChangeOfEndpoint = objectRange.ContainsEndpoint()
            anchor_couple = New DLLAnchorCouplet(Of TwoCharacterDLLItem)(
                                            tempAnchorItem.DLL_GetItemPrior_OfT(), tempAnchorItem,
                                            tempAnchorItem.DLL_IsEitherEndpoint())
            operation = New DLLOperation1D(Of TwoCharacterDLLItem)(objectRange, anchor_couple, True, False)
            ''operation.OperateOnList(mod_list)
            mod_manager.ProcessOperation_AnyType(operation, bChangeOfEndpoint, True)

        End If ''End of ""If (DIRECT_TO_LIST) Then... Else..."

        ''
        '' Display the list. 
        ''
        RefreshTheUI_DisplayList()

        ''Remove the highlighting of the range's endpoints.
        objectRange.HighlightEndpoints_Green(False)

    End Sub

    Private Sub buttonInsertSingle_Click(sender As Object, e As EventArgs) Handles buttonInsertSingle.Click

        ''
        '' Insert range into the list.  
        ''
        Dim objAnchorItem As DLLAnchorItem(Of TwoCharacterDLLItem)
        Dim objAnchorPair As DLLAnchorCouplet(Of TwoCharacterDLLItem) ''Added 11/08/2024
        Dim intAnchorPosition As Integer
        Dim boolEndpoint As Boolean
        Dim array_sItemsToInsert As String()
        Dim bUserSpecifiedValues
        Dim strNewItem As String
        Dim intHowManyInModuleList As Integer
        Dim newItem As TwoCharacterDLLItem
        Const ZERO_INDEX As Integer = 0
        Dim bInsertRangeAfterAnchor As Boolean
        Dim bInsertRangeBeforeAnchor As Boolean
        Dim tempAnchorItem As TwoCharacterDLLItem '''Added 10/21/2024 thomas downes
        Dim operationToInsert As DLLOperation1D(Of TwoCharacterDLLItem) ''Added 10/26/2024
        Dim rangeSingleItem As DLLRange(Of TwoCharacterDLLItem) ''Added 10/26/2024 td 

        array_sItemsToInsert = textInsertListOfValuesCSV.Text.Split(ARRAY_OF_DELIMITERS)
        intHowManyInModuleList = mod_list.DLL_CountAllItems
        bUserSpecifiedValues = array_sItemsToInsert.Count > 0
        ''intInsertCount = numInsertHowMany.Value
        intAnchorPosition = numInsertAnchorBenchmark.Value

        ''
        ''Set the anchor. 
        ''
        ''----objAnchor = New DLLAnchor(Of TwoCharacterDLLItem)(False)
        ''----objAnchor._anchorItem = mod_firstItem.DLL_GetItemNext(-1 + intAnchorPosition)
        tempAnchorItem = mod_firstItem.DLL_GetItemNext(-1 + intAnchorPosition)
        objAnchorItem = New DLLAnchorItem(Of TwoCharacterDLLItem)(tempAnchorItem)

        bInsertRangeAfterAnchor = (listInsertAfterOr.SelectedIndex < 1)
        bInsertRangeBeforeAnchor = (Not bInsertRangeAfterAnchor) ''Added 11/10/2024 
        objAnchorItem._doInsertRangeAfterThis = bInsertRangeAfterAnchor
        objAnchorItem._doInsertRangeBeforeThis = (False = bInsertRangeAfterAnchor)

        ''Added 11/8/2024 td
        ''---objAnchorPair = objAnchorItem.GetAnchorCouplet()
        objAnchorPair = objAnchorItem.GetAnchorCouplet(bInsertRangeBeforeAnchor)

        boolEndpoint = intAnchorPosition = 1 Or intAnchorPosition = intHowManyInModuleList

        strNewItem = IIf(bUserSpecifiedValues, array_sItemsToInsert(0),
                             ZERO_INDEX.ToString("00"))

        If (strNewItem Is Nothing) Then
            strNewItem = "++"
        End If ''End of ""If (strNewItem Is Nothing) Then""
        newItem = New TwoCharacterDLLItem(strNewItem)

        ''---mod_list.DLL_InsertSingly(newItem, objAnchor, boolEndpoint)
        Const KEEP_ANCHOR As Boolean = True
        ''
        ''What does DLL_SetAnchor() do?  
        ''
        mod_list.DLL_SetAnchor(objAnchorItem, bInsertRangeBeforeAnchor, bInsertRangeAfterAnchor,
              KEEP_ANCHOR)

        ''
        ''Major work!! 
        ''
        Const DIRECT_TO_LIST As Boolean = False ''Added 10/26/2024 thom dow.nes
        Const INSERT_OPERATION As Boolean = True '' False ''Added 10/26/2024 thomas downes

        If (DIRECT_TO_LIST) Then
            ''Without using the DLLManager class, directly editing the list.  
            mod_list.DLL_InsertItemSingly(newItem)
        Else
            ''
            '' Added 10/26/2024 thomas d.
            ''
            rangeSingleItem = New DLLRange(Of TwoCharacterDLLItem)(newItem, True)
            operationToInsert = New DLLOperation1D(Of TwoCharacterDLLItem)(rangeSingleItem, False, False,
                                      INSERT_OPERATION, False, False,
                                      objAnchorItem,
                                      objAnchorPair,
                                      False, False, False)
            mod_manager.ProcessOperation_AnyType(operationToInsert, False, True)

        End If ''End of ""If (DIRECT_TO_LIST) Then ... Else ..."

        ''
        ''Added 10/20/2024
        ''
        RefreshTheUI_DisplayList()

        ''Remove the highlighting of the range's endpoints.
        If (rangeSingleItem IsNot Nothing) Then _
        rangeSingleItem.HighlightEndpoints_Green(False)

    End Sub


    Private Sub labelItems_MouseUp(sender As Object, e As MouseEventArgs) Handles labelItemsDisplay.MouseUp
        ''
        ''Added 2/27/2024 thomas downes  
        ''
        Dim x_intPixelPosition As Integer
        ''Dim xfactor_a1 As Double = ((0.061 * 29.0 * 29.0) / (32.0 * 28.0)) '' (0.061 * 29.0 / 32.0) = 0.05528
        ''Dim xfactor_a2 As Double = 0.05479 * 29.0 / (28.73 * 1.0) ''0.0572556 * 20.0 / 20.9
        ''Dim xfactor_a3 As Double = (0.055305 * 24.0 * 29.0 / (28.2 * 28.9469))
        Dim xfactor_a4 = 0.0471544
        Dim ax_double As Double
        Dim constant_b = -0.14 '' -0.2 '' -0.0 '' -1.0
        Dim index_of_item_double As Double
        Dim index_of_item As Integer
        Dim objectListItem As TwoCharacterDLLItem
        Dim bShiftingKey As Boolean ''Added 2/29/2024
        Dim xfactor_a As Double ''Added 2/29/2024

        xfactor_a = xfactor_a4
        x_intPixelPosition = e.Location.X
        ax_double = xfactor_a * x_intPixelPosition
        index_of_item_double = ax_double + constant_b
        index_of_item = Math.Floor(index_of_item_double)
        ''Added 2/29/2024
        bShiftingKey = Control.ModifierKeys = Keys.Shift

        Const ENCAPSULATE = True ''Added 2/29/2024
        If ENCAPSULATE Then ''Added 2/29/2024

            ''Added 2/29/2024
            mod_list.SelectionRange_ProcessList(index_of_item, bShiftingKey)

        Else
            ''Added 2/27/2024
            If index_of_item > -1 + mod_list.DLL_CountAllItems Then Exit Sub
            objectListItem = mod_list.DLL_GetItemAtIndex(index_of_item)
            ''--objectListItem.Selected = True
            objectListItem.Selected = Not objectListItem.Selected ''Toggle the value. ''True
        End If ''eND OF ""If (ENCAPSULATE) Then... Else..."

        ''Added 2/27/2024 
        RefreshTheUI_DisplayList()

        '''Highlight the range's endpoints.
        ''--objectRange.HighlightEndpoints_Green()'

    End Sub ''End of ""Private Sub labelBenchmark_MouseUp""

    Private Sub buttonUndoLastStep_Click(sender As Object, e As EventArgs) Handles buttonUndoLastStep.Click
        ''
        ''Added 10/16/2024
        ''
        mod_manager.UndoMarkedOperation()

        ''Added 10/27/2024 
        RefreshTheUI_DisplayList()

        ''Added 11/09/2024
        buttonRedoOp.Enabled = True

    End Sub

    Private Sub labelItemsDisplay_MouseUp(sender As Object, e As MouseEventArgs)

    End Sub

    Private Sub buttonDelete_Click(sender As Object, e As EventArgs) Handles buttonDelete.Click
        ''
        ''Added 10/31/2024 thomas downes
        ''
        Const DIRECT_TO_LIST As Boolean = False ''Added 10/26/2024 thom dow.nes
        Const DELETE_OPERATION As Boolean = True '' False ''Added 10/26/2024 thomas downes
        Dim intItemPosition As Integer
        Dim intHowManyToDelete As Integer
        Dim itemFirstToDelete As TwoCharacterDLLItem
        Dim itemLastToDelete As TwoCharacterDLLItem
        Dim rangeToDelete As DLLRange(Of TwoCharacterDLLItem)
        Dim operationToDelete As DLLOperation1D(Of TwoCharacterDLLItem)

        intItemPosition = numDeleteRangeBenchmarkStart.Value
        intHowManyToDelete = numDeleteHowMany.Value

        ''
        ''Set the anchor. 
        ''
        ''----objAnchor = New DLLAnchor(Of TwoCharacterDLLItem)(False)
        ''----objAnchor._anchorItem = mod_firstItem.DLL_GetItemNext(-1 + intAnchorPosition)
        itemFirstToDelete = mod_firstItem.DLL_GetItemNext(-1 + intItemPosition)
        itemLastToDelete = mod_firstItem.DLL_GetItemNext(-1 + intItemPosition + intHowManyToDelete - 1)

        rangeToDelete = New DLLRange(Of TwoCharacterDLLItem)(False, itemFirstToDelete,
                                             itemLastToDelete, Nothing, intHowManyToDelete)

        If (DIRECT_TO_LIST) Then
            ''Without using the DLLManager class, directly editing the list.  
            mod_list.DLL_DeleteRange(rangeToDelete)
        Else
            ''
            '' Added 10/26/2024 thomas d.
            ''
            operationToDelete = New DLLOperation1D(Of TwoCharacterDLLItem)(rangeToDelete, False, False,
                                      False, DELETE_OPERATION, False, Nothing, Nothing, False, False, False)
            mod_manager.ProcessOperation_AnyType(operationToDelete, False, True)

            ''Administration....
            mod_firstItem = mod_list._itemStart
            mod_lastItem = mod_list._itemEnding


        End If ''End of ""If (DIRECT_TO_LIST) Then ... Else ..."

        ''
        ''Added 10/20/2024
        ''
        RefreshTheUI_DisplayList()

    End Sub

    Private Sub mod_list_EventListWasModified() Handles mod_list.EventListWasModified
        ''
        '' Added 11/02/2024 thomas downes 
        ''
        mod_firstItem = mod_list._itemStart
        mod_lastItem = mod_list._itemEnding

    End Sub

    Private Sub buttonRedoOp_Click(sender As Object, e As EventArgs) Handles buttonRedoOp.Click
        ''
        ''Added 11/09/2024
        ''
        mod_manager.RedoMarkedOperation()

        ''Added 11/09/2024 
        RefreshTheUI_DisplayList()

        ''Added 11/09/2024
        buttonRedoOp.Enabled = False

    End Sub
End Class
