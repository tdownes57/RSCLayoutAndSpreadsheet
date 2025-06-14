﻿
''Public Class FormSimpleDemo1DHorizontal ''12/04/2024  FormSimpleDemoOfCSharp1D
''
'' Added 10/14/2024 T_homas C. D_ownes 
''
Imports System.ComponentModel.Design
Imports System.Diagnostics.Metrics
Imports System.Text
Imports ciBadgeInterfaces
Imports ciBadgeSerialize
Imports RSCLibraryDLLOperations

Public Class FormSimpleDemo1DHorizontal
    ''
    '' Added 10/14/2024 thomas c. downes 
    ''
    ''Mar2025 Private mod_manager As DLLOperationsManager1D(Of TwoCharacterDLLHorizontal)
    Private mod_manager As DLLOperationsManager1D(Of TwoCharacterDLLHorizontal, TwoCharacterDLLHorizontal)

    Private WithEvents mod_list As DLLList(Of TwoCharacterDLLHorizontal)
    Private mod_firstItem As TwoCharacterDLLHorizontal
    Private mod_lastItem As TwoCharacterDLLHorizontal
    Private mod_range As DLLRange(Of TwoCharacterDLLHorizontal) ''Added 11/14/2024 t.homas d.ownes

    Private Const INITIAL_ITEM_COUNT_30 As Integer = 5 ''---Added 12/9/2024--- 30
    Private ReadOnly ARRAY_OF_DELIMITERS = New Char() {","c, " "c}


    Private Sub FormSimpleDemoOfCSharp1D_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        '' Added 10/14/2024 thomas c. downes 
        ''
        Dim anchorItemForEmptyList As New DLLAnchorItem_Deprecated(Of TwoCharacterDLLHorizontal)(True, False)
        Dim anchorItemForListOfOneItem As DLLAnchorItem_Deprecated(Of TwoCharacterDLLHorizontal) ''(True, False)
        Dim anchorPairForEmptyList As New DLLAnchorCouplet(Of TwoCharacterDLLHorizontal)(True, False)
        Dim anchorPairForListOfOneItem As DLLAnchorCouplet(Of TwoCharacterDLLHorizontal) ''(True, False)
        ''Nov2024 Dim rangeNew As DLLRange(Of TwoCharacterDLLHorizontal)
        Dim indexNewItem As Integer
        Dim newItem As TwoCharacterDLLHorizontal
        ''Dim priorItem As TwoCharacterDLLHorizontal

        Dim PERFORM_INITIAL_INSERT_MANUALLY As Boolean = False ''---True

        mod_firstItem = New TwoCharacterDLLHorizontal("01")
        mod_lastItem = mod_firstItem
        mod_list = New DLLList(Of TwoCharacterDLLHorizontal)(mod_firstItem, mod_lastItem, 1)

        ''//Added 10/21/2024 td
        anchorItemForListOfOneItem = New DLLAnchorItem_Deprecated(Of TwoCharacterDLLHorizontal)(mod_firstItem)

        ''//Added 11/08/2024 td
        anchorPairForListOfOneItem = New DLLAnchorCouplet(Of TwoCharacterDLLHorizontal)(mod_firstItem, Nothing, True)

        ''//rangeNew = New DLLRange(Of TwoCharacterDLLHorizontal)(mod_firstItem, True)
        ''//For indexNewItem = 2 To INITIAL_ITEM_COUNT_30 ''---30
        ''Nov2024 rangeNew = New DLLRange(Of TwoCharacterDLLHorizontal)(New TwoCharacterDLLHorizontal("02"), True)
        mod_range = New DLLRange(Of TwoCharacterDLLHorizontal)(New TwoCharacterDLLHorizontal("02"), True)

        ''Modified "(2 + 1)" on 11/8/2024 td
        For indexNewItem = (2 + 1) To INITIAL_ITEM_COUNT_30 ''---30
            newItem = New TwoCharacterDLLHorizontal(indexNewItem.ToString("00"))
            ''Nov2024 rangeNew.DLL_InsertItemToTheEnd(newItem)
            mod_range.DLL_InsertItemToTheEnd(newItem)
        Next indexNewItem

        ''
        '' Create the operation, or simply insert the range
        ''   without an operation.
        ''
        If (PERFORM_INITIAL_INSERT_MANUALLY) Then
            ''
            ''No DLLOperation object will be created.
            ''
            mod_list.DLL_InsertRangeIntoEmptyList(mod_range) ''(rangeNew)

        Else
            ''
            ''Added 10/20/2024  
            ''
            Dim operationInitial30 As DLLOperation1D_Of(Of TwoCharacterDLLHorizontal)
            Const LOAD_INSERT As Boolean = True ''Added 12/15/2024 
            Dim type_notAMove As New StructureTypeOfMove(False) ''Added 12/15/2024

            ''operationInitial30 = New DLLOperation1D(Of TwoCharacterDLLHorizontal)(rangeNew, True, False,
            ''                                                          True, False, False,
            ''                                                    anchorForEmptyList, False, False, False)
            operationInitial30 = New DLLOperation1D_Of(Of TwoCharacterDLLHorizontal)(mod_range, True, False,
                                                                      LOAD_INSERT, False, False, type_notAMove,
                                          anchorItemForListOfOneItem,
                                          anchorPairForListOfOneItem)
            ''12/30/2024                    False, False, False, False)

            ''12/16/2024 operationInitial30.OperateOnList(mod_list)
            Dim byrefChangeOfEndpoint As Boolean ''Added 12/16/2024
            operationInitial30.OperateOnParentList(mod_list, byrefChangeOfEndpoint)

            ''Added 10/20/2024  
            ''Removed 12/04/2024 mod_manager = New DLLOperationsManager1D(Of TwoCharacterDLLHorizontal)(mod_firstItem,
            ''      mod_list, operationInitial30)
            ''
            ''March2025 mod_manager = New DLLOperationsManager1D(Of TwoCharacterDLLHorizontal)(mod_firstItem, mod_list)
            mod_manager = New DLLOperationsManager1D(Of TwoCharacterDLLHorizontal,
                TwoCharacterDLLHorizontal)(mod_firstItem, mod_list)

        End If ''End of ""If (PERFORM_INITIAL_INSERT_MANUALLY) Then""  

        ''
        '' Display the list. 
        ''
        RefreshTheUI_DisplayList()

        ''Added 12/09/2024 
        ''  Make sure that the two boxes match in the beginning.
        richtextBenchmark.Text = richtextItemsDisplayH.Text

        ''Added 12/04/2024 
        labelNumOperations.Text = mod_manager.ToString()

    End Sub


    Private Function TestingIndexStructure() As Boolean

        ''Added 1/15/2025 
        Return checkTestNumericConstructor.Checked

    End Function ''/end of ""Private Function TestingIndexStructure() As Boolean""


    Private Sub RefreshTheUI_DisplayList(Optional par_operation As DLLOperation1D_Of(Of TwoCharacterDLLHorizontal) = Nothing)
        ''
        ''Added an optional parameter (par_operation) on 12/02/2024 
        ''
        ''Populate the UI. 
        Dim strListOfLinks As String

        ''Major call!!
        strListOfLinks = StringToFillTheTextboxDisplayingList()
        richtextItemsDisplayH.Text = strListOfLinks

        ''Added 12/28/2023 
        Dim itemCount As Integer = mod_list.DLL_CountAllItems()
        ''userControlOperation1.UpdateTheItemCount(itemCount)

        ''Added 1/04/202
        ''
        ''  Let's maintain the two(2) linklabels which represent
        ''    the list's endpoint & prior-to-endpoint.
        ''
        Dim last_item As TwoCharacterDLLHorizontal = Nothing
        Dim prior_to_last As TwoCharacterDLLHorizontal = Nothing

        last_item = CType(mod_list.DLL_GetLastItem_OfT(), TwoCharacterDLLHorizontal)
        If (last_item Is Nothing) Then
            ''
            ''The user has elected to delete the entire list. 
            ''
        Else
            ''linkToEndpoint.Text = last_item.ToString()
            prior_to_last = CType(last_item.DLL_GetItemPrior(), TwoCharacterDLLHorizontal)
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

        ''Refresh the highlighting, in the rich TextBox. 
        ''----Nov11 2024 ''RefreshHighlightingRichText()
        RefreshHighlightingRichText(richtextBenchmark)
        RefreshHighlightingRichText(richtextItemsDisplayH)

    End Sub ''End of ""Private Sub RefreshTheUI_DisplayList()""


    Private Function StringToFillTheTextboxDisplayingList() As String
        ''
        ''Added 12/26/2023  
        ''
        Dim each_twoChar As TwoCharacterDLLHorizontal
        Dim bDone As Boolean = False
        Dim stringbuilderLinkedItems As New StringBuilder(120)
        Dim intCountLoops As Integer = 0
        Dim boolOpenHighlight As Boolean = True
        Dim boolCloseHighlight As Boolean = False
        Dim boolCloseHighlight_Next As Boolean = False
        Dim bOpenSelection As Boolean = False ''Added 11/12/2024 td
        Dim intLoopIndex As Integer = 0 ''Added 11/12/2024 
        Dim charSpecial As Char = " "c ''---Added 12/9/2024 

        ''richtextItemsDisplay.ResetText()
        ''Not needed here. ----richtextItemsDisplay.Text = ""

        If (mod_firstItem Is Nothing) Then
            ''
            ''All the items have been deleted (most likely).
            ''
            Return "The list is empty."

        Else

            each_twoChar = mod_firstItem

            ''For Each each_twoChar In mod_list
            Do Until bDone

                intLoopIndex += 1
                charSpecial = " "c ''Added 12/09/2024 

                ''La belItemsDisplay.Text.Append(" +++ " + each_twoChar.ToString())
                ''stringbuilderLinkedItems.Append(" " + each_twoChar.ToString())
                If (each_twoChar.Selected Or bOpenSelection) Then
                    ''The item has been selected. 
                    charSpecial = "_"c ''Added 12/09/2024
                    stringbuilderLinkedItems.Append("_" + each_twoChar.ToString())

                    ''
                    ''Carefully determine the value of the "Continuation" boolean. 
                    ''
                    If (each_twoChar.Selected) Then
                        bOpenSelection = True
                    ElseIf (each_twoChar.SelectedAnyItemToFollow()) Then
                        bOpenSelection = True
                    Else
                        bOpenSelection = False
                    End If ''ENd of ""If (each_twoChar.Selected) Then""

                ElseIf (each_twoChar.HighlightInCyan Or
                    each_twoChar.HighlightInGreen) Then
                    ''
                    ''The item has been highlighted.
                    ''
                    If (boolOpenHighlight) Then
                        charSpecial = "["c ''Added 12/09/2024 
                        stringbuilderLinkedItems.Append("[" + each_twoChar.ToString())
                        ''Prepare for future iterations. 
                        boolOpenHighlight = False
                        boolCloseHighlight = True
                    ElseIf (boolCloseHighlight) Then
                        ''
                        ''Prepare for the next item(s).
                        ''
                        ''---stringbuilderLinkedItems.Append(" " + each_twoChar.ToString())
                        charSpecial = " "c ''Added 12/09/2024 
                        stringbuilderLinkedItems.Append(" " + each_twoChar.ToString())
                        boolCloseHighlight_Next = True
                        boolCloseHighlight = False
                        boolOpenHighlight = True
                    End If ''end of ""If (boolOpenHighlight) Then ... ElseIf..."

                ElseIf (boolCloseHighlight_Next) Then
                    ''Added 11/09/2024 thomas downes 
                    charSpecial = "]"c ''Added 12/09/2024 
                    stringbuilderLinkedItems.Append("]" + each_twoChar.ToString())
                    ''Clear the boolean, so it only is used once.
                    boolCloseHighlight_Next = False

                Else
                    ''Added 11/09/2024 thomas downes 
                    charSpecial = " "c ''Added 12/09/2024 
                    stringbuilderLinkedItems.Append(" " + each_twoChar.ToString())

                End If ''End of ""If (each_twoChar.Selected) Then... Else..."

                each_twoChar = each_twoChar.DLL_GetItemNext
                bDone = bDone Or (each_twoChar Is Nothing)
                intCountLoops += 1
                ''If (int CountLoops > 2 * 30) Then Debugger.Break()
                If (intCountLoops > 2 * INITIAL_ITEM_COUNT_30) Then Debugger.Break()

            Loop ''End of ""Do Until bDone""
            ''Next each_twoChar

            ''Added 12/09/2024 
            Select Case True '' charSpecial
                Case (charSpecial = "["c)
                    stringbuilderLinkedItems.Append("]")

                Case (bOpenSelection And charSpecial = "_"c)
                    stringbuilderLinkedItems.Append("_")

            End Select ''End of ""Select Case True""

            ''---MessageBoxTD.Show_Statement("Done loading!!")
            ''Return stringbuilderLinkedItems.ToString()
            Dim result As String
            result = stringbuilderLinkedItems.ToString()
            Return result

        End If ''End of ""If (mod_firstTwoChar Is Nothing) Then... Else..."

    End Function ''End of "Private Function FillTheTextboxDisplayingList()""


    Private Sub RefreshHighlightingRichText(par_control As RichTextBox)
        ''
        ''Added 11/10/2024 thomas d.
        ''
        ''//Dim index As Integer
        Dim tempItem As TwoCharacterDLLHorizontal
        Dim boolHighlighting As Boolean
        Dim indexChar As Integer = 0
        Dim colorDefault As Color
        Dim intCountOfHighlightedItems As Integer = 0

        tempItem = mod_list.DLL_GetFirstItem_OfT()
        ''//boolHighlighting = tempItem.HighlightInGreen

        ''Clear all of the highlighting / backcolor. 
        par_control.SelectAll()
        colorDefault = par_control.BackColor
        par_control.SelectionBackColor = colorDefault
        par_control.SelectionLength = 0 ''Clear the selection.

        Do While (tempItem IsNot Nothing)

            ''//indexChar += 3
            boolHighlighting = tempItem.HighlightInCyan()
            If (boolHighlighting) Then
                intCountOfHighlightedItems += 1
                par_control.Select(indexChar, 3)
                par_control.SelectionBackColor = Color.Cyan
            End If ''ENd of ""If boolHighlighting..."
            ''Prepare.
            tempItem = tempItem.DLL_GetItemNext_OfT()
            indexChar += 3

        Loop ''End of ""Do While (tempItem IsNot Nothing)""

        ''
        ''Checking....
        ''
        Dim bAllAreHighlighted As Boolean
        bAllAreHighlighted = (intCountOfHighlightedItems >= mod_list._itemCount - 1)

    End Sub ''End of ""Private Sub RefreshHighlightingRichText()""


    Private Sub AutoPopulateRangeControls(par_range As DLLRange(Of TwoCharacterDLLHorizontal))
        ''
        ''Added 11/12/2024 td
        ''
        Dim intRangeFirstIndex_b1 As Integer ''This index is 1-based.

        If (par_range Is Nothing) Then
            MessageBoxTD.Show_Statement("To auto-populate the range-related controls...",
                                        "Please select a range of items, by clicking the numbers in the 2nd textbox.")
            Exit Sub
        End If ''End of ""If (par_range Is Nothing) Then""

        intRangeFirstIndex_b1 = par_range.GetFirstItemIndex_base1()
        numInsertAnchorBenchmark.Value = intRangeFirstIndex_b1
        numDeleteRangeBenchmarkStart.Value = intRangeFirstIndex_b1

        ''Count of items. 
        numInsertHowMany.Value = par_range.GetItemCount()
        numDeleteHowMany.Value = par_range.GetItemCount()

        ''
        ''Added 11/14/2024
        ''
        textboxMoveRange.Text = par_range.ToString()



    End Sub ''end of ""Private Sub AutoPopulateRangeControls()"



    Private Sub AdminToDoPriorToAnyOperation(ByVal par_wordForOp As String, ByRef pbyrefUserCancelsOperation As Boolean)
        ''
        '' Added 12/01/2024 
        ''
        CheckManagerForRedoOperations_AskUser(par_wordForOp, pbyrefUserCancelsOperation)

    End Sub ''Private Sub AdminToDoPriorToAnyOperation(ByRef pbyrefUserCancelsOperation As Boolean)


    Private Sub CheckManagerForRedoOperations_AskUser(par_wordForOp As String, ByRef pbyrefUserCancelsOperation As Boolean)
        ''
        '' Added 12/01/2024 
        ''
        Dim bManagerHasRedosQueuedUp As Boolean
        Dim boolUserSaysToCancel As Boolean
        Dim boolUserSaysToProceed As Boolean ''Added 12/08/2024
        Dim dialog_1_Proceed As DialogResult
        Dim dialog_2_Cancel As DialogResult
        ''Added 12/02/2024
        Dim intCountRedos As Integer
        Dim strDialogMessage_Proceed As String
        intCountRedos = mod_manager.CountOfOperations_QueuedForRedo()

        bManagerHasRedosQueuedUp = mod_manager.AreOneOrMoreOpsToRedo_PerMarker()

        If (bManagerHasRedosQueuedUp) Then

            ''//    This is needed if the user has pressed the "Undo" button, " 
            ''//    And now wants to move forward with a "brand new" operation. 
            ''//    Rather than following "Undo" with a "Redo", user wants to 
            ''//    permanently discard the his Or her most recent operation. 
            ''//    (The operation being discarded was definitely a mistake in
            ''//    the user's perspective.)
            ''//    12/02/2024 th.omas do.wnes 
            ''//
            strDialogMessage_Proceed = String.Format("Proceed with {0}?  " +
                                    "This will cancel all {1} pending Redo operations.",
                                    par_wordForOp, intCountRedos)

            ''//dialog_result = MessageBoxTD.Show_QuestionYesNo("Cancel all pending Redo operations?")
            dialog_1_Proceed = MessageBoxTD.Show_QuestionYesNo(strDialogMessage_Proceed)
            boolUserSaysToProceed = (dialog_1_Proceed = DialogResult.OK Or
                                     dialog_1_Proceed = DialogResult.Yes)
            boolUserSaysToCancel = (Not boolUserSaysToProceed)

            If (boolUserSaysToProceed) Then
                ''Added 12/02/2024
                dialog_2_Cancel = MessageBoxTD.Show_Statement_OkayCancel(intCountRedos,
                     "This many pending Redo operations will be cancelled: {0}",
                     "(Press Cancel if you desire to cancel the new " + par_wordForOp + " operation.)")
                boolUserSaysToCancel = (dialog_2_Cancel = DialogResult.Cancel)

            End If ''End of ""If (boolUserSaysToProceed) Then""

        End If ''End of ""If (bManagerHasRedosQueuedUp) Then""

        pbyrefUserCancelsOperation = boolUserSaysToCancel ''boolUserCancels

    End Sub ''Private Sub CheckManagerForRedoOperations_AskUser





    Private Sub buttonInsertMulti_Click(sender As Object, e As EventArgs) Handles buttonInsertMultiple.Click
        ''
        '' Added 10/15/2024  
        ''
        Dim intInsertCount As Integer
        Dim intAnchorPosition As Integer
        Dim indexNewItem As Integer
        ''Nov2024 Dim objectRange As DLLRange(Of TwoCharacterDLLHorizontal)
        Dim prior_newItem As TwoCharacterDLLHorizontal
        Dim newItem As TwoCharacterDLLHorizontal
        Dim first_newItem As TwoCharacterDLLHorizontal
        Dim last_newItem As TwoCharacterDLLHorizontal
        Dim intHowManyInModuleList As Integer
        Dim intNewIndexStart As Integer
        Dim intNewIndexEnd As Integer
        Dim array_sItemsToInsert As String()
        Dim bUserSpecifiedValues
        Dim strNewItem As String
        Dim intModulo As Integer
        Dim boolEndpoint As Boolean
        Dim objAnchor As DLLAnchorItem_Deprecated(Of TwoCharacterDLLHorizontal)

        ''Added 12/01/2024 
        ''   Inform the user of any pending issues, prior to any operations. 
        Dim boolUserHasCancelled As Boolean ''Added 12/01/2024
        AdminToDoPriorToAnyOperation("Insert-Multi", boolUserHasCancelled)
        If (boolUserHasCancelled) Then Exit Sub

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
            If strNewItem.Length = 1 Then strNewItem = "=" & strNewItem
            newItem = New TwoCharacterDLLHorizontal(strNewItem)

            If first_newItem Is Nothing Then
                first_newItem = newItem
                mod_range = New DLLRange(Of TwoCharacterDLLHorizontal)(True, Nothing, Nothing, first_newItem, 1)
            Else
                prior_newItem.DLL_SetItemNext(newItem)
                newItem.DLL_SetItemPrior(prior_newItem)
                mod_range = New DLLRange(Of TwoCharacterDLLHorizontal)(True, Nothing, Nothing, first_newItem, 1)
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
            mod_range = New DLLRange(Of TwoCharacterDLLHorizontal)(first_newItem, True)
        Else
            ''
            '' There are at least two objects in the range. 
            ''
            mod_range = New DLLRange(Of TwoCharacterDLLHorizontal)(False, first_newItem,
                                                               last_newItem, Nothing, intInsertCount)

        End If ''End of ""If (intInsertCount = 1) Then... Else..."

        ''
        ''Set the anchor. 
        ''
        Dim tempAnchorItem As TwoCharacterDLLHorizontal ''Added 10/21/2024 td
        tempAnchorItem = mod_firstItem.DLL_GetItemNext(-1 + intAnchorPosition)
        objAnchor = New DLLAnchorItem_Deprecated(Of TwoCharacterDLLHorizontal)(tempAnchorItem)
        With objAnchor
            ''._anchorItem = mod_firstItem.DLL_GetItemNext(-1 + intAnchorPosition)
            ._doInsertRangeAfterThis = listInsertAfterOrBefore.SelectedIndex < 1
            ._doInsertRangeBeforeThis = False = objAnchor._doInsertRangeAfterThis
        End With

        ''Highlight the range's endpoints.
        mod_range.HighlightEndpoints_Green()
        mod_range.HighlightEndpoints_Cyan()

        ''
        '' Insert range into the list.  
        ''
        Const DIRECT_TO_LIST = False ''Added 10/26/2024 thom dow.nes
        Const INSERT_OPERATION = True '' False ''Added 10/26/2024 thomas downes
        Dim USE_OP_MANAGER = Not DIRECT_TO_LIST ''Added 11/06/2024 thom dow.nes
        Dim anchor_couple As DLLAnchorCouplet(Of TwoCharacterDLLHorizontal)
        Dim operation As DLLOperation1D_Of(Of TwoCharacterDLLHorizontal)
        ''//Dim bChangeOfEndpoint As Boolean ''Added 11/06/2024 
        Dim bChangeOfEndpoint_ByVal As Boolean ''Added 11/06/2024 
        Dim bChangeOfEndpoint_ByRef As Boolean ''Added 12/16/2024 
        Dim type_notMove As New StructureTypeOfMove(False)

        If DIRECT_TO_LIST Then
            If listInsertAfterOrBefore.SelectedIndex < 1 Then
                mod_list.DLL_InsertRangeAfter(mod_range, objAnchor._anchorItem) ''; ''---, boolEndpoint)
            Else
                mod_list.DLL_InsertRangeBefore(mod_range, objAnchor._anchorItem) ''; ''---, boolEndpoint)
            End If

        ElseIf USE_OP_MANAGER And listInsertAfterOrBefore.SelectedIndex < 1 Then
            ''
            ''Added 11/06/2024 td  
            ''
            ''---bChangeOfEndpoint = objectRange.ContainsEndpoint()
            ''anchor_couple = New DLLAnchorCouplet(Of TwoCharacterDLLHorizontal)(tempAnchorItem,
            ''  tempAnchorItem.DLL_GetItemNext_OfT(), bChangeOfEndpoint)
            anchor_couple = New DLLAnchorCouplet(Of TwoCharacterDLLHorizontal)(tempAnchorItem,
                                            tempAnchorItem.DLL_GetItemNext_OfT,
                                            tempAnchorItem.DLL_IsEitherEndpoint)
            operation = New DLLOperation1D_Of(Of TwoCharacterDLLHorizontal)(mod_range, anchor_couple, True, False, type_notMove)
            ''operation.OperateOnList(mod_list)
            mod_manager.ProcessOperation_AnyType(operation, bChangeOfEndpoint_ByVal,
                                                 bChangeOfEndpoint_ByRef, True,
                                                  operation.GetOperationIndexStructure())

        ElseIf USE_OP_MANAGER And listInsertAfterOrBefore.SelectedIndex >= 1 Then
            ''
            ''Added 11/06/2024 td  
            ''
            ''---bChangeOfEndpoint = objectRange.ContainsEndpoint()
            anchor_couple = New DLLAnchorCouplet(Of TwoCharacterDLLHorizontal)(
                                            tempAnchorItem.DLL_GetItemPrior_OfT, tempAnchorItem,
                                            tempAnchorItem.DLL_IsEitherEndpoint)
            operation = New DLLOperation1D_Of(Of TwoCharacterDLLHorizontal)(mod_range, anchor_couple, True, False, type_notMove)
            ''operation.OperateOnList(mod_list)
            ''March2025 mod_manager.ProcessOperation_AnyType(operation, bChangeOfEndpoint_ByVal, bChangeOfEndpoint_ByRef, True)
            mod_manager.ProcessOperation_AnyType(operation, bChangeOfEndpoint_ByVal,
                                                 bChangeOfEndpoint_ByRef, True,
                                                 operation.GetOperationIndexStructure())

        End If ''End of ""If (DIRECT_TO_LIST) Then... Else..."

        ''
        '' Added 11/11/2024 
        ''
        ''//If bChangeOfEndpoint Then
        If bChangeOfEndpoint_ByVal Or bChangeOfEndpoint_ByRef Then

            mod_firstItem = mod_list._itemStart
            mod_lastItem = mod_list._itemEnding

        End If ''End of ""If (bChangeOfEndpoint) Then""

        ''
        '' Display the list. 
        ''
        ''--RefreshTheUI_DisplayList()
        RefreshTheUI_DisplayList() '' (operation)

        ''Remove the highlighting of the range's endpoints.
        mod_range.HighlightEndpoints_Green(False)
        mod_range.HighlightEndpoints_Cyan(False)

        ''Added 11/10/2024 
        buttonUndoLastStep.Enabled = True
        ''Added 11/29/2024 
        buttonUndo.Enabled = True

        ''Added 11/29/2024 
        ''---labelNumOperations.Text = "Count of operations: " + mod_manager.HowManyOpsAreRecorded()
        ''Modified 12/01/2024
        ''Modified 12/02/2024  labelNumOperations.Text = mod_manager.ToString()
        labelNumOperations.Text = mod_manager.ToString(operation)

    End Sub

    Private Sub buttonInsertSingle_Click(sender As Object, e As EventArgs) Handles buttonInsertSingle.Click

        ''
        '' Insert range into the list.  
        ''
        Dim objAnchorItem As DLLAnchorItem_Deprecated(Of TwoCharacterDLLHorizontal)
        Dim objAnchorPair As DLLAnchorCouplet(Of TwoCharacterDLLHorizontal) ''Added 11/08/2024
        Dim intAnchorPosition As Integer
        ''++Dim boolEndpoint As Boolean
        Dim bChangeOfEndpoint As Boolean ''Added 12/17/2024 
        Dim bChangeOfEndpoint_Expected As Boolean ''Added 12/17/2024 
        Dim bChangeOfEndpoint_Occurred As Boolean ''Added 12/17/2024 
        Dim array_sItemsToInsert As String()
        Dim bUserSpecifiedValues
        Dim strNewItem As String
        Dim intHowManyInModuleList As Integer
        Dim newItem As TwoCharacterDLLHorizontal
        Const ZERO_INDEX = 0
        Dim bInsertRangeAfterAnchor As Boolean
        Dim bInsertRangeBeforeAnchor As Boolean
        Dim tempAnchorItem As TwoCharacterDLLHorizontal '''Added 10/21/2024 thomas downes
        Dim operationToInsert As DLLOperation1D_Of(Of TwoCharacterDLLHorizontal) ''Added 10/26/2024
        Dim rangeSingleItem As DLLRange(Of TwoCharacterDLLHorizontal) ''Added 10/26/2024 td 
        Dim boolIsForEmptyList As Boolean ''Added 12/09/2024 thomas d. 
        Dim type_notMove As New StructureTypeOfMove(False) ''Added 12/15/2024

        ''Added 12/01/2024 
        ''   Inform the user of any pending issues, prior to any operations. 
        Dim boolUserHasCancelled As Boolean ''Added 12/01/2024
        AdminToDoPriorToAnyOperation("Insert-Single", boolUserHasCancelled)
        If (boolUserHasCancelled) Then Exit Sub

        ''Added 12/08/2024
        mod_manager.ClearAnyRedoOperations_IfQueued()

        array_sItemsToInsert = textInsertListOfValuesCSV.Text.Split(ARRAY_OF_DELIMITERS)
        intHowManyInModuleList = mod_list.DLL_CountAllItems
        bUserSpecifiedValues = array_sItemsToInsert.Count > 0
        ''intInsertCount = numInsertHowMany.Value
        intAnchorPosition = numInsertAnchorBenchmark.Value

        ''
        ''Set the anchor. 
        ''
        ''----objAnchor = New DLLAnchor(Of TwoCharacterDLLHorizontal)(False)
        ''----objAnchor._anchorItem = mod_firstItem.DLL_GetItemNext(-1 + intAnchorPosition)
        If (mod_firstItem Is Nothing) Then
            ''The list is empty. 
            ''   No items exist in the list.  ---12/09/2024 td  
            boolIsForEmptyList = True ''Added 12/09/2024
            If (mod_list.DLL_IsEmpty() = False) Then System.Diagnostics.Debugger.Break()
            objAnchorItem = New DLLAnchorItem_Deprecated(Of TwoCharacterDLLHorizontal)(boolIsForEmptyList, False) '' (True, False)

        Else
            tempAnchorItem = mod_firstItem.DLL_GetItemNext(-1 + intAnchorPosition)
            objAnchorItem = New DLLAnchorItem_Deprecated(Of TwoCharacterDLLHorizontal)(tempAnchorItem)
        End If ''End of ""If (mod_firstItem Is Nothing) Then ... Else ..."

        bInsertRangeAfterAnchor = listInsertAfterOrBefore.SelectedIndex < 1
        bInsertRangeBeforeAnchor = Not bInsertRangeAfterAnchor ''Added 11/10/2024 
        objAnchorItem._doInsertRangeAfterThis = bInsertRangeAfterAnchor
        objAnchorItem._doInsertRangeBeforeThis = False = bInsertRangeAfterAnchor

        ''Added 11/8/2024 td
        ''---objAnchorPair = objAnchorItem.GetAnchorCouplet()
        objAnchorPair = objAnchorItem.GetAnchorCouplet(bInsertRangeBeforeAnchor)

        ''//boolEndpoint = (intAnchorPosition = 1 Or intAnchorPosition = intHowManyInModuleList)
        ''--12/9/2024--boolEndpoint = intAnchorPosition = 1 And bInsertRangeBeforeAnchor Or
        ''-------------                intAnchorPosition = intHowManyInModuleList And bInsertRangeAfterAnchor
        ''12/17/2024 boolEndpoint = (boolIsForEmptyList Or
        bChangeOfEndpoint_Expected = (boolIsForEmptyList Or
             ((intAnchorPosition = 1) And bInsertRangeBeforeAnchor) Or
            ((intAnchorPosition = intHowManyInModuleList) And bInsertRangeAfterAnchor))

        strNewItem = IIf(bUserSpecifiedValues, array_sItemsToInsert(0),
                             ZERO_INDEX.ToString("00"))

        If strNewItem Is Nothing Then
            strNewItem = "++"
        End If ''End of ""If (strNewItem Is Nothing) Then""
        newItem = New TwoCharacterDLLHorizontal(strNewItem)

        ''---mod_list.DLL_InsertSingly(newItem, objAnchor, boolEndpoint)
        Const KEEP_ANCHOR = True
        ''
        ''What does DLL_SetAnchor() do?  
        ''
        mod_list.DLL_SetAnchor(objAnchorItem, bInsertRangeBeforeAnchor, bInsertRangeAfterAnchor,
              KEEP_ANCHOR)

        ''
        ''Major work!! 
        ''
        Const DIRECT_TO_LIST = False ''Added 10/26/2024 thom dow.nes
        Const INSERT_OPERATION = True '' False ''Added 10/26/2024 thomas downes

        If DIRECT_TO_LIST Then
            ''Without using the DLLManager class, directly editing the list.  
            ''12/17/2024 mod_list.DLL_InsertItemSingly(newItem, boolEndpoint)
            mod_list.DLL_InsertItemSingly(newItem, bChangeOfEndpoint_Expected)

        Else
            ''
            '' Added 10/26/2024 thomas d.
            ''
            rangeSingleItem = New DLLRange(Of TwoCharacterDLLHorizontal)(newItem, True)
            operationToInsert = New DLLOperation1D_Of(Of TwoCharacterDLLHorizontal)(rangeSingleItem, False, False,
                                      INSERT_OPERATION, False, False, type_notMove,
                                      objAnchorItem,
                                      objAnchorPair)
            ''12/30/2024                  False, False, False, False)

            ''12/17/2024  mod_manager.ProcessOperation_AnyType(operationToInsert, boolEndpoint, True)
            ''March2025 mod_manager.ProcessOperation_AnyType(operationToInsert, bChangeOfEndpoint_Expected,
            ''    bChangeOfEndpoint_Occurred, True)
            mod_manager.ProcessOperation_AnyType(operationToInsert, bChangeOfEndpoint_Expected,
                     bChangeOfEndpoint_Occurred, True, operationToInsert.GetOperationIndexStructure())

        End If ''End of ""If (DIRECT_TO_LIST) Then ... Else ..."

        ''Added 11/10/2024 td
        My.Application.DoEvents()

        ''Added 12/17/2024 td
        bChangeOfEndpoint = (bChangeOfEndpoint_Expected Or bChangeOfEndpoint_Occurred Or bChangeOfEndpoint)

        ''Added 11/10/2024 td
        If bChangeOfEndpoint Then
            mod_firstItem = mod_list.DLL_GetFirstItem_OfT()
            mod_lastItem = mod_list.DLL_GetLastItem_OfT()
        End If ''eND OF ""If (boolEndpoint) Then""

        ''
        ''Added 10/20/2024
        ''
        RefreshTheUI_DisplayList()

        ''Remove the highlighting of the range's endpoints.
        If rangeSingleItem IsNot Nothing Then
            rangeSingleItem.HighlightEndpoints_Green(False)
            rangeSingleItem.HighlightEndpoints_Cyan(False)
        End If ''End of " If (rangeSingleItem IsNot Nothing) Then"

        ''Added 11/09/2024
        ''  These two(2) lines are probably not needed. 
        buttonRedoOp.Enabled = mod_manager.MarkerHasOperationNext_Redo()
        buttonReDo.Enabled = mod_manager.MarkerHasOperationNext_Redo()

        ''Added 11/10/2024 
        buttonUndoLastStep.Enabled = mod_manager.MarkerHasOperationPrior_Undo()
        buttonUndo.Enabled = mod_manager.MarkerHasOperationPrior_Undo()

        ''Added 11/29/2024 
        ''---labelNumOperations.Text = "Count of operations: " + mod_manager.HowManyOpsAreRecorded()
        ''Modified 12/01/2024
        labelNumOperations.Text = mod_manager.ToString()

    End Sub


    Private Sub labelItems_MouseUp(sender As Object, e As MouseEventArgs) Handles _
                   labelItemsDisplay.MouseUp, richtextItemsDisplayH.MouseUp
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
        Dim objectListItem As TwoCharacterDLLHorizontal
        Dim bShiftingKey As Boolean ''Added 2/29/2024
        Dim xfactor_a As Double ''Added 2/29/2024
        ''Now modularized. ''Static s_range As DLLRange(Of TwoCharacterDLLHorizontal)
        Dim intDistance As Integer ''Added 11/12/2024 

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
            ''//mod_list.SelectionRange_ProcessList_GetTuple(index_of_item, bShiftingKey)
            mod_range = mod_list.GetSelectionRange_Base1(index_of_item, bShiftingKey)

            ''Added 11/14/2024
            ''---objectListItem = mod_list.DLL_GetItemAtIndex(index_of_item)
            objectListItem = mod_list.DLL_GetItemAtIndex_1based(1 + index_of_item)
            ''Added 11/5/2024
            ''See above called to mod_list.SelectionRange...  ''--objectListItem.Selected = True

        Else
            ''Added 2/27/2024
            If index_of_item > -1 + mod_list.DLL_CountAllItems Then Exit Sub
            ''---objectListItem = mod_list.DLL_GetItemAtIndex(index_of_item)
            objectListItem = mod_list.DLL_GetItemAtIndex_1based(index_of_item)
            ''--objectListItem.Selected = True
            objectListItem.Selected = Not objectListItem.Selected ''Toggle the value. ''True

        End If ''eND OF ""If (ENCAPSULATE) Then... Else..."

        ''Added 2/27/2024 
        RefreshTheUI_DisplayList()

        '''Highlight the range's endpoints.
        ''--objectRange.HighlightEndpoints_Green()'

        If (objectListItem Is Nothing) Then
            ''
            ''Do nothing. 
            ''
        ElseIf (mod_range Is Nothing And objectListItem.Selected = True) Then
            ''
            ''Start a range object. 
            ''
            mod_range = New DLLRange(Of TwoCharacterDLLHorizontal)(objectListItem, False)

        ElseIf (mod_range IsNot Nothing And (objectListItem.Selected)) Then

            intDistance = mod_range._StartingItemOfRange.DLL_GetDistanceTo(objectListItem)

            If (intDistance > 0) Then
                ''The range should be broadened to reach the newly-selected object. 
                mod_range.ExtendRangeToIncludeListItem(objectListItem)

            ElseIf (intDistance < 0) Then
                ''
                '' Since the distance is negative, the range should be re-initiated,
                ''   with newly-selected object being the "lefthand" (starting) item 
                ''   of the range, and the previously-selected item should be the 
                ''   "righthand" (following/ending) item. 
                ''
                Dim tempRangeItem As TwoCharacterDLLHorizontal = mod_range.ItemStart()
                mod_range = New DLLRange(Of TwoCharacterDLLHorizontal)(objectListItem, tempRangeItem)

            End If ''ENd of ""If (intDistance > 0) Then ... Else If (intDistance < 0) Then"

        End If ''end of ""If (objectListItem Is Nothing) Then... ElseIf... ElseIf..."

        ''
        ''Major call!! 
        ''
        Const MOVE_CONTROLS_ENABLED As Boolean = True
        If (MOVE_CONTROLS_ENABLED And mod_range IsNot Nothing) Then
            ''Important for MOVE controls. 
            AutoPopulateRangeControls(mod_range)
        End If ''ENd of ""If (s_range IsNot Nothing) Then""

    End Sub ''End of ""Private Sub labelBenchmark_MouseUp""

    Private Sub buttonUndoLastStep_Click(sender As Object, e As EventArgs) Handles buttonUndoLastStep.Click
        ''
        ''Added 10/16/2024
        ''
        Dim bEndpointAffected As Boolean ''Added 11/10/2024 td

        ''Nov10 2024 ''mod_manager.UndoMarkedOperation()
        mod_manager.UndoMarkedOperation(bEndpointAffected, TestingIndexStructure())

        ''Added 11/10/2024 
        mod_firstItem = mod_list.DLL_GetFirstItem_OfT()
        mod_lastItem = mod_list.DLL_GetLastItem_OfT()

        ''Added 10/27/2024 
        RefreshTheUI_DisplayList()

        ''Added 11/09/2024
        buttonRedoOp.Enabled = True
        buttonReDo.Enabled = True

        ''Added 11/10/2024 
        buttonUndoLastStep.Enabled = mod_manager.MarkerHasOperationPrior_Undo()
        buttonUndo.Enabled = mod_manager.MarkerHasOperationPrior_Undo()

        ''Added 12/04/2024 
        labelNumOperations.Text = mod_manager.ToString()

    End Sub


    Private Sub buttonDelete_Click(sender As Object, e As EventArgs) Handles buttonDelete.Click
        ''
        ''Added 10/31/2024 thomas downes
        ''
        ''BOOLEANS -- TRUE  
        Const RECORD_DEL_OPERATIONS As Boolean = True ''Added 11/11/2024 Thomas Downes
        Const OPERATION_Delete As Boolean = True '' False ''Adde d 10/26/2024 thomas downes

        ''BOOLEANS -- FALSE 
        Const DIRECT_TO_LIST_Not As Boolean = False ''Added 10/26/2024 thom dow.nes
        Const OPERATION_NotInsert As Boolean = False '' False ''Adde d 10/26/2024 thomas downes
        Const OPERATION_NotMove As Boolean = False '' False ''Added 10/26/2024 thomas downes
        Const SORT_123 As Boolean = False
        Const SORT_321 As Boolean = False
        ''Const SORT_UNDO As Boolean = False
        Const UNDO_SORT_ASCENDING As Boolean = False ''Added 12/24/2024 
        Const UNDO_SORT_DESCENDING As Boolean = False ''Added 12/24/2024

        Dim intItemPosition As Integer
        Dim intHowManyToDelete As Integer
        Dim itemFirstToDelete As TwoCharacterDLLHorizontal
        Dim itemLastToDelete As TwoCharacterDLLHorizontal
        Dim rangeToDelete As DLLRange(Of TwoCharacterDLLHorizontal)
        Dim operationToDelete As DLLOperation1D_Of(Of TwoCharacterDLLHorizontal)
        Dim bIncludesListStart As Boolean ''Added 11/10/2024 
        Dim bIncludesList__End As Boolean ''Added 11/10/2024 
        Dim bAnyEndpointAffected As Boolean ''Added 11/11/2024 td
        Dim bAnyEndpointAffected_start As Boolean ''Added 11/11/2024 td
        Dim bAnyEndpointAffected_end As Boolean ''Added 11/11/2024 td
        Dim bChangeOfEndpoint_ByRef As Boolean ''Added 12/17/2024 
        Dim bCannotDeleteThatMany As Boolean ''Added 11/11/2024 td
        Dim type_notMove As New StructureTypeOfMove(False) ''Added 12/15/2024

        ''Added 12/01/2024 
        ''   Inform the user of any pending issues, prior to any operations. 
        Dim boolUserHasCancelled As Boolean ''Added 12/01/2024
        AdminToDoPriorToAnyOperation("Delete", boolUserHasCancelled)
        If (boolUserHasCancelled) Then Exit Sub

        intItemPosition = numDeleteRangeBenchmarkStart.Value
        intHowManyToDelete = numDeleteHowMany.Value

        ''Added 11/11/2024 thomas downes
        bCannotDeleteThatMany = (-1 + intItemPosition + intHowManyToDelete > mod_list._itemCount)

        ''Added 11/11/2024 td
        If (mod_list._isEmpty_OrTreatAsEmpty) Then
            ''Added 11/11/2024 td
            MessageBoxTD.Show_Statement("The list is empty, so no deletions can logically take place.")
            Exit Sub
        ElseIf (bCannotDeleteThatMany) Then
            ''Added 11/11/2024 td
            MessageBoxTD.Show_InsertWordFormat_Line1(-1 + intItemPosition + intHowManyToDelete,
                                                     "The list is not long enough (less than {0} items), " +
                                        "the requested number of deleted consecutive items cannot take place.", )
            Exit Sub
        End If ''eNd of ""If (mod_list._isEmpty_OrTreatAsEmpty) Then""

        ''
        ''Set the anchor. 
        ''
        ''----objAnchor = New DLLAnchor(Of TwoCharacterDLLHorizontal)(False)
        ''----objAnchor._anchorItem = mod_firstItem.DLL_GetItemNext(-1 + intAnchorPosition)
        itemFirstToDelete = mod_firstItem.DLL_GetItemNext(-1 + intItemPosition)
        itemLastToDelete = mod_firstItem.DLL_GetItemNext(-1 + intItemPosition + intHowManyToDelete - 1)

        bAnyEndpointAffected_start = (intItemPosition = 1)
        bAnyEndpointAffected_end = ((intItemPosition + intHowManyToDelete - 1) >= mod_list._itemCount)
        bAnyEndpointAffected = (bAnyEndpointAffected_start Or bAnyEndpointAffected_end)

        rangeToDelete = New DLLRange(Of TwoCharacterDLLHorizontal)(False, itemFirstToDelete,
                                             itemLastToDelete, Nothing, intHowManyToDelete)

        If (DIRECT_TO_LIST_Not) Then
            ''Without using the DLLManager class, directly editing the list.  
            mod_list.DLL_DeleteRange(rangeToDelete)
        Else
            ''
            '' Added 10/26/2024 thomas d.
            ''
            operationToDelete = New DLLOperation1D_Of(Of TwoCharacterDLLHorizontal)(rangeToDelete,
                                      bIncludesListStart, bIncludesList__End,
                                      OPERATION_NotInsert,
                                      OPERATION_Delete,
                                      OPERATION_NotMove, type_notMove, Nothing, Nothing)
            ''12/30/2024              SORT_123, SORT_321, UNDO_SORT_ASCENDING, UNDO_SORT_DESCENDING)

            ''12/17/2024 mod_manager.ProcessOperation_AnyType(operationToDelete, bAnyEndpointAffected, RECORD_DEL_OPERATIONS)
            ''March2025  mod_manager.ProcessOperation_AnyType(operationToDelete, bAnyEndpointAffected,
            ''                 bChangeOfEndpoint_ByRef, RECORD_DEL_OPERATIONS)
            mod_manager.ProcessOperation_AnyType(operationToDelete, bAnyEndpointAffected,
                   bChangeOfEndpoint_ByRef, RECORD_DEL_OPERATIONS,
                   operationToDelete.GetOperationIndexStructure())

            ''Added 12/17/2024 
            bAnyEndpointAffected = (bAnyEndpointAffected Or bChangeOfEndpoint_ByRef)

            ''Administration....
            If (bAnyEndpointAffected) Then
                mod_firstItem = mod_list._itemStart
                mod_lastItem = mod_list._itemEnding
            End If ''End of ""If (bAnyEndpointAffected) Then""

        End If ''End of ""If (DIRECT_TO_LIST_Not) Then ... Else ..."

        ''
        ''Added 10/20/2024
        ''
        RefreshTheUI_DisplayList()

        ''Added 11/10/2024 
        buttonUndoLastStep.Enabled = True
        buttonUndo.Enabled = True

        ''Added 11/29/2024 
        ''---labelNumOperations.Text = "Count of operations: " + mod_manager.HowManyOpsAreRecorded()
        ''Modified 12/01/2024
        labelNumOperations.Text = mod_manager.ToString()

    End Sub ''buttonDelete_Click 


    Private Sub mod_list_EventListWasModified() Handles mod_list.EventListWasModified
        ''
        '' Added 11/02/2024 thomas downes 
        ''
        mod_firstItem = mod_list._itemStart
        mod_lastItem = mod_list._itemEnding

    End Sub ''end of ""Private Sub mod_list_EventListWasModified""


    Private Sub buttonRedoOp_Click(sender As Object, e As EventArgs) Handles buttonRedoOp.Click
        ''
        ''Added 11/09/2024
        ''
        Dim bEndpointAffected As Boolean ''Added 11/10/2024 td
        Dim bTestingIndexStructure As Boolean ''Added 1/14/2025 td

        If (mod_manager.MarkerHasOperationNext_Redo()) Then
            ''
            ''Fine, this is expected. ---Thomas D.
            ''
        Else
            MessageBoxTD.Show_Statement("Sorry, there are no Redo operations in the queue.")
            Exit Sub
        End If ''End of "If (mod_manager.MarkerHasOperationNext_Redo()) Then... Else ..."

        ''Added 1/14/2025 td
        bTestingIndexStructure = TestingIndexStructure() ''---2025 checkTestNumericConstructor.Checked

        ''
        ''Major call!!
        ''
        mod_manager.RedoMarkedOperation(bEndpointAffected, bTestingIndexStructure)

        ''Added 12/09/2024 & 11/10/2024 (but only on the buttonUndoLastStep_Click handler)
        mod_firstItem = mod_list._itemStart
        mod_lastItem = mod_list._itemEnding

        ''Added 11/09/2024 
        RefreshTheUI_DisplayList()

        ''Added 11/09/2024
        ''buttonRedoOp.Enabled = False
        buttonRedoOp.Enabled = mod_manager.MarkerHasOperationNext_Redo()
        buttonReDo.Enabled = mod_manager.MarkerHasOperationNext_Redo()

        ''Added 12/04/2024
        buttonUndoLastStep.Enabled = mod_manager.MarkerHasOperationPrior_Undo()
        buttonUndo.Enabled = mod_manager.MarkerHasOperationPrior_Undo()

        ''Added 12/04/2024 
        labelNumOperations.Text = mod_manager.ToString()

    End Sub

    Private Sub ButtonMoveItems_Click(sender As Object, e As EventArgs) Handles buttonMoveItems.Click
        ''
        ''Added 11/16/2024 
        ''
        Dim tempAnchorItem As TwoCharacterDLLHorizontal ''---DLLAnchorItem(Of TwoCharacterDLLHorizontal)
        Dim tempAnchorPair As DLLAnchorCouplet(Of TwoCharacterDLLHorizontal)
        Dim tempOperation As DLLOperation1D_Of(Of TwoCharacterDLLHorizontal)
        Const OPERATION_MOVE As Boolean = True
        ''Const ALLOW_NULLS As Boolean = True
        Dim bChangeOfEndpoint As Boolean = False
        Dim bChangeOfEndpoint_Expected As Boolean = False ''Added 12/17/2024
        Dim bChangeOfEndpoint_Occurred As Boolean = False ''Added 12/17/2024
        Dim intAnchorIndex As Integer = 0
        Dim bAnchorMoveAfter As Boolean
        Dim bAnchorMoveBefore As Boolean
        Dim bCheck_RangeContainsAnchor As Boolean ''Added 11/18/2024
        Dim bCheck_AnchorEnclosesRange As Boolean ''Added 11/18/2024
        Dim type_move As New StructureTypeOfMove(False) ''Added 12/15/2024

        ''Added 12/01/2024 
        ''   Inform the user of any pending issues, prior to any operations. 
        Dim boolUserHasCancelled As Boolean ''Added 12/01/2024
        AdminToDoPriorToAnyOperation("Move", boolUserHasCancelled)
        If (boolUserHasCancelled) Then Exit Sub

        intAnchorIndex = numMoveAnchorBenchmark.Value
        tempAnchorItem = mod_firstItem.DLL_GetItemNext_OfT(-1 + intAnchorIndex)

        ''Added 12/09/2024  
        If (tempAnchorItem Is Nothing) Then
            MessageBoxTD.Show_Statement("Cannot locate Anchor Item.  May be outside the range of the list.")
            Exit Sub
        End If ''ENd of ""If (tempAnchorItem Is Nothing) Then""

        bAnchorMoveAfter = (listMoveAfterOrBefore.SelectedIndex < 1)
        bAnchorMoveBefore = (listMoveAfterOrBefore.SelectedIndex >= 1)
        bChangeOfEndpoint_Expected = mod_range.ContainsEndpoint()

        tempAnchorPair = New DLLAnchorCouplet(Of TwoCharacterDLLHorizontal)(tempAnchorItem, bAnchorMoveAfter)
        ''Added 12/09/2024  bChangeOfEndpoint = tempAnchorPair.ContainsEndpoint()
        bChangeOfEndpoint_Expected = (bChangeOfEndpoint_Expected Or tempAnchorPair.ContainsEndpoint())

        ''Added 11/18/2024
        ''
        ''  Run sanity-check (warning) functions. 
        ''
        bCheck_RangeContainsAnchor = mod_range.Check_ContainsAnchorPair(tempAnchorPair)
        bCheck_AnchorEnclosesRange = mod_range.Check_EnclosedByAnchorPair(tempAnchorPair)

        ''
        ''  Display sanity-check (warning) messages. 
        ''
        ''12/09/2024 If (bCheck_AnchorEnclosesRange) Then
        If (bCheck_RangeContainsAnchor) Then ''12/09/2024 If (bCheck_AnchorEnclosesRange) Then
            MessageBoxTD.Show_Statement("Not permitted (or hopelessly confusing): Range includes Anchor.")
            Exit Sub
        ElseIf (bCheck_AnchorEnclosesRange) Then
            MessageBoxTD.Show_Statement("Not permitted (or hopelessly confusing): Anchor already encloses Range.")
            Exit Sub
        End If


        ''
        '' Added 11/17/2024 thomas downes
        ''
        tempOperation = New DLLOperation1D_Of(Of TwoCharacterDLLHorizontal)(mod_range, tempAnchorPair,
                                                          False, OPERATION_MOVE, type_move)
        ''operation.OperateOnList(mod_list)
        ''12/17/2024 td  mod_manager.ProcessOperation_AnyType(tempOperation, bChangeOfEndpoint, True)
        ''March2025  mod_manager.ProcessOperation_AnyType(tempOperation, bChangeOfEndpoint_Expected,
        ''   bChangeOfEndpoint_Occurred, True)
        mod_manager.ProcessOperation_AnyType(tempOperation, bChangeOfEndpoint_Expected,
                bChangeOfEndpoint_Occurred, True, tempOperation.GetOperationIndexStructure())

        ''Added 12/17/2024 
        bChangeOfEndpoint = (bChangeOfEndpoint_Expected Or bChangeOfEndpoint_Occurred Or bChangeOfEndpoint)

        ''Added 11/18/2024 
        If (bChangeOfEndpoint) Then
            mod_firstItem = mod_list._itemStart
            mod_lastItem = mod_list._itemEnding
        End If ''End of ""If (bChangeOfEndpoint) Then""

        ''Added 11/17/2024 
        RefreshTheUI_DisplayList()

        ''Added 11/29/2024 
        ''---labelNumOperations.Text = "Count of operations: " + mod_manager.HowManyOpsAreRecorded()
        ''Modified 12/01/2024
        ''Added 12/9/2024  labelNumOperations.Text = mod_manager.ToString()
        labelNumOperations.Text = mod_manager.ToString(tempOperation)

        ''Added 11/10/2024 
        buttonUndoLastStep.Enabled = True
        ''Added 11/29/2024 
        buttonUndo.Enabled = True

    End Sub ''ENd of ""Private Sub ButtonMoveItems_Click""

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listMoveAfterOrBefore.SelectedIndexChanged

    End Sub

    Private Sub buttonReDo_Click(sender As Object, e As EventArgs) Handles buttonReDo.Click

        buttonRedoOp.PerformClick()

        ''Added 11/29/2024 
        ''---labelNumOperations.Text = "Count of operations: " + mod_manager.HowManyOpsAreRecorded()
        ''Modified 12/01/2024
        labelNumOperations.Text = mod_manager.ToString()

    End Sub

    Private Sub buttonUndo_Click(sender As Object, e As EventArgs) Handles buttonUndo.Click

        buttonUndoLastStep.PerformClick()

        ''Added 11/29/2024 
        ''---labelNumOperations.Text = "Count of operations: " + mod_manager.HowManyOpsAreRecorded()
        ''Modified 12/01/2024
        labelNumOperations.Text = mod_manager.ToString()

    End Sub

    Private Sub LinkClearRecordedOps_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkClearRecordedOps.LinkClicked
        ''
        ''Added 12/4./2024 t..homas d..ownes
        ''
        mod_manager.ClearAllRecordedOperations()

        buttonRedoOp.Enabled = mod_manager.MarkerHasOperationNext_Redo()
        buttonReDo.Enabled = mod_manager.MarkerHasOperationNext_Redo()

        buttonUndoLastStep.Enabled = mod_manager.MarkerHasOperationPrior_Undo()
        buttonUndo.Enabled = mod_manager.MarkerHasOperationPrior_Undo()

        labelNumOperations.Text = mod_manager.ToString()

    End Sub


End Class




