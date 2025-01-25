Imports System.Drawing.Text
Imports System.Reflection.Emit
Imports System.Runtime.InteropServices.JavaScript
Imports System.Runtime.InteropServices.JavaScript.JSType
Imports System.Text
Imports ciBadgeInterfaces
Imports ciBadgeSerialize
''---Imports ciBadgeRecipients

Public Class FormTestRSC_Obselete

    Private Const INITIAL_ITEM_COUNT_30 As Integer = 30 ''Added 12/28/2023 td
    Private mod_list As DLL_List_OfTControl_OBSELETE(Of TwoCharacterDLLItem)

    Private mod_firstTwoChar As TwoCharacterDLLItem

    ''Added 12/28/2023 Thomas Downes 
    ''12/28 Private mod_opsList As DLL_List_OfTControl_PLEASE_USE(Of DLL_Operation(Of TwoCharacterDLLItem))
    Private mod_opsList As DLL_List_OfTControl_OBSELETE(Of DLL_OperationV2)

    ''Private mod_operations As DLL_OperationsManager_Deprecated(Of TwoCharacterDLLItem)
    ''1/1024 Private mod_operations As ciBadgeInterfaces.DLL_OperationsManager(Of TwoCharacterDLLItem)
    ''1/1024 Private mod_opsManager As ciBadgeInterfaces.DLL_OperationsManager(Of TwoCharacterDLLItem)
    ''----See FormTestUsingManager.1/20/2024
    ''1/1024 Private mod_opsManager As DLLOperationsManager(Of TwoCharacterDLLItem) ''Added 1/19/2024 

    ''Added 1/01/2024 
    Private mod_intCountOperations = 0
    Private mod_firstPriorOpV1 As DLL_OperationV1 = Nothing ''Added 1/11/2024
    Private mod_lastPriorOpV1 As DLL_OperationV1 = Nothing ''par_lastPriorOpV1
    ''DEPRECATED 1/13/24 Private mod_stackOperations As Stack(Of DLL_OperationV1) = New Stack(Of DLL_OperationV1)() ''par_lastPriorOpV1
    Private mod_opRedoMarker As DLL_OperationsRedoMarker


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ''Initialize the DLL list. (DLL = Doubly-Linked List)
        mod_list = New DLL_List_OfTControl_OBSELETE(Of TwoCharacterDLLItem)(mod_firstTwoChar)

        ' Add any initialization after the InitializeComponent() call.
        ''Encapsulated 12/25/2023 thomas downes
        ''12/2023 Load_DLL_List(mod_list)
        ''#2 12/2023  Dim opInitialLoad As DLL_Operation(Of TwoCharacterDLLItem)
        Dim opInitialLoad As DLL_OperationV2
        opInitialLoad =
            Load_DLL_List_AsFunction(mod_list)

        userControlOperation1.DLL_ListItems = mod_list

        ''Populate the UI. 
        ''---See the Form_Load procedure / event-handler. 

        ''Added 12/28/2023 td
        ''12/28/2023 mod_opsList = New DLL_List_OfTControl_PLEASE_USE(Of DLL_Operation(Of TwoCharacterDLLItem))(opInitialLoad)
        mod_opsList = New DLL_List_OfTControl_OBSELETE(Of DLL_OperationV2)(opInitialLoad)

        ''1/2024 mod_opsManager = New DLL_OperationsManager(Of TwoCharacterDLLItem)(mod_opsList)
        ''----See FormTestUsingManager.1/20/2024
        ''---mod_opsManager = New DLLOperationsManager(Of TwoCharacterDLLItem)(mod_list,
        ''---        opInitialLoad.GetCopyV1())

    End Sub ''End of ""Public Sub New()""


    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ''Encapsulated 12/25/2023 thomas downes
        ''---See Public Sub New.---Load_DLL_List(mod_list)
        ''Dim boolTesting As Boolean = False ''True
        ''Dim strListOfLinks As String

        ''If (Not boolTesting) Then
        ''Populate the UI. 
        ''--strListOfLinks = FillTheTextboxDisplayingList()
        ''--LabelItemsDisplay.Text = strListOfLinks
        RefreshTheUI_DisplayList()

        ''Added 12/26/2023
        ''MessageBoxTD.Show_Statement("Done loading the textbox with the list.")
        ''End If

    End Sub ''end of ""Private Sub Form_Load""


    Private Function GetFinalEndpointItem() As TwoCharacterDLLItem

        ''Added 12/31/2023
        Dim result As TwoCharacterDLLItem
        ''result = mod_firstTwoChar.DLL_GetItemNext(mod_list.DLL_CountAllItems())
        result = mod_list.DLL_GetLastItem()
        Return result

    End Function ''Private Function GetFinalEndpointItem()

    Private Sub PrintFinalEndpointItem()

        ''Added 12/31/2023
        Dim final_item As TwoCharacterDLLItem
        final_item = GetFinalEndpointItem()
        linkToEndpoint.Text = final_item.ToString()

    End Sub ''Private Sub PrintFinalEndpointItem()


    Private Function FillTheTextboxDisplayingList() As String
        ''
        ''Added 12/26/2023  
        ''
        Dim each_twoChar As TwoCharacterDLLItem
        Dim bDone As Boolean = False
        Dim stringbuilderLinkedItems As New StringBuilder(120)
        Dim intCountLoops As Integer = 0

        ''LabelItemsDisplay.ResetText()
        ''Not needed here. ----labelItemsDisplay.Text = ""

        If (mod_firstTwoChar Is Nothing) Then
            ''
            ''All the items have been deleted (most likely).
            ''
            Return "The list is empty."

        Else

            each_twoChar = mod_firstTwoChar

            ''For Each each_twoChar In mod_list
            Do Until bDone

                ''LabelItemsDisplay.Text.Append(" +++ " + each_twoChar.ToString())
                ''stringbuilderLinkedItems.Append(" " + each_twoChar.ToString())
                stringbuilderLinkedItems.Append("  " + each_twoChar.ToString())

                each_twoChar = each_twoChar.DLL_GetItemNext
                bDone = (each_twoChar Is Nothing)
                intCountLoops += 1
                ''If (intCountLoops > 2 * 30) Then Debugger.Break()
                If (intCountLoops > 4 * INITIAL_ITEM_COUNT_30) Then Debugger.Break()

            Loop ''End of ""Do Until bDone""
            ''Next each_twoChar

            ''---MessageBoxTD.Show_Statement("Done loading!!")
            ''Return stringbuilderLinkedItems.ToString()
            Dim result As String
            result = stringbuilderLinkedItems.ToString()
            Return result

        End If ''End of ""If (mod_firstTwoChar Is Nothing) Then... Else..."

    End Function ''End of "Private Function FillTheTextboxDisplayingList()""


    ''
    ''Encapsulated 12/28/2023 and 12/25/2023 thomas downes
    ''
    Private Sub Load_DLL_List(par_list As DLL_List_OfTControl_OBSELETE(Of TwoCharacterDLLItem),
                              Optional par_firstItem As TwoCharacterDLLItem = Nothing)

        ''Encapsulated 12/28/2023 
        Load_DLL_List_AsFunction(par_list, par_firstItem)

    End Sub ''End of ""Private Sub Load_DLL_List()""


    Private Function Load_DLL_List_AsFunction(par_list As DLL_List_OfTControl_OBSELETE(Of TwoCharacterDLLItem),
           Optional par_firstItem As TwoCharacterDLLItem = Nothing) As DLL_OperationV2
        ''                     As DLL_Operation(Of TwoCharacterDLLItem)
        ''
        ''Encapsulated 12/25/2023 thomas downes
        ''
        Dim each_twoCharsItem As TwoCharacterDLLItem
        Dim each_strTwoChars As String
        Dim prior As TwoCharacterDLLItem = Nothing
        Dim bListIsEmpty As Boolean = True
        Dim op_result As DLL_OperationV2 ''Added 12/28/2023 td

        ''Clear the list.
        par_list.DLL_ClearAllItems()
        ''prior = par_firstItem
        bListIsEmpty = (0 = par_list.DLL_CountAllItems())
        If (Not bListIsEmpty) Then Debugger.Break()
        mod_firstTwoChar = par_firstItem

        ''Added 12/26/20923
        Dim firstBenchmark_1or2 As Integer = 1
        If (par_firstItem IsNot Nothing) Then
            par_list.DLL_AddFirstAndOnlyItem(par_firstItem)
            bListIsEmpty = (0 = par_list.DLL_CountAllItems())
            firstBenchmark_1or2 = 2
            prior = par_firstItem
        End If ''end of ""If (par_firstItem IsNot Nothing) Then""

        ''
        ''Iterate through the list. 
        ''
        For benchmark = firstBenchmark_1or2 To INITIAL_ITEM_COUNT_30

            each_strTwoChars = String.Format("{0:00}", benchmark)
            ''12/2023 each_twoCharsItem = New TwoCharacterDLLItem(each_strTwoChars, prior)
            each_twoCharsItem = New TwoCharacterDLLItem(each_strTwoChars)

            If (prior Is Nothing) Then
                ''Only occurs on first iteration.
                mod_firstTwoChar = each_twoCharsItem
                ''Add the very first item. 
                par_list.DLL_AddFirstAndOnlyItem(each_twoCharsItem)

            Else
                ''---Not needed here....
                ''---prior.DLL_SetItemNext(each_twoCharsItem)
                par_list.DLL_InsertOneItemAfter(each_twoCharsItem, prior, True)

            End If ''End of ""If (prior Is Nothing) Then... Else... "

            ''If (bListIsEmpty) Then
            ''    ''Add the very first item. 
            ''    par_list.DLL_AddFirstAndOnlyItem(each_twoCharsItem)
            ''Else
            ''    par_list.DLL_InsertOneItemAfter(each_twoCharsItem, prior, True)
            ''End If ''end of If (bListIsEmpty) Then... Else...

            ''
            ''Prepare for next iteration of the loop.
            ''
            prior = each_twoCharsItem
            bListIsEmpty = False

        Next benchmark ''Next index

        ''
        ''Added 12/28/2023 
        ''
        op_result = New DLL_OperationV2("I"c, mod_firstTwoChar, mod_firstTwoChar._Control,
                            INITIAL_ITEM_COUNT_30, Nothing,
                                EnumModeRowsOrColumns.Undetermined, Nothing, True)
        ''added 12/28
        Dim copyOfOpV1 As DLL_OperationV1
        Dim copyOfOpV2 As DLL_OperationV2
        Dim bCopyV2_ofCopyV1_match As Boolean ''= False

        If (Testing.TestingByDefault) Then
            copyOfOpV1 = op_result.GetCopyV1()
            copyOfOpV2 = copyOfOpV1.GetCopyV2()

            ''--bCopyV2_ofCopyV1_match = Me.Equals(copyOfOpV2)
            bCopyV2_ofCopyV1_match = op_result.Equals(copyOfOpV2)
            If (bCopyV2_ofCopyV1_match) Then
                ''Bravo!!! 12/30/2023 
            Else
                Debugger.Break()
            End If
        End If ''End of ""If (Testing.TestingByDefault) Then""

        Return op_result

    End Function ''End of ""Private Function Load_DLL_List_AsFunction""


    ''Public Overrides Function Equals(param As ) As Boolean
    ''    Return MyBase.Equals(obj)
    ''End Function


    Private Sub RefreshTheUI_DisplayList()

        ''Populate the UI. 
        Dim strListOfLinks As String
        strListOfLinks = FillTheTextboxDisplayingList()
        labelItemsDisplay.Text = strListOfLinks

        ''Added 12/28/2023 
        Dim itemCount As Integer = mod_list.DLL_CountAllItems()
        userControlOperation1.UpdateTheItemCount(itemCount)

        ''Added 1/04/202
        ''
        ''  Let's maintain the two(2) linklabels which represent
        ''    the list's endpoint & prior-to-endpoint.
        ''
        Dim last_item As TwoCharacterDLLItem = Nothing
        Dim prior_to_last As TwoCharacterDLLItem = Nothing

        last_item = CType(mod_list.DLL_GetLastItem(), TwoCharacterDLLItem)
        If (last_item Is Nothing) Then
            ''
            ''The user has elected to delete the entire list. 
            ''
        Else
            linkToEndpoint.Text = last_item.ToString()
            prior_to_last = CType(last_item.DLL_GetItemPrior(), TwoCharacterDLLItem)
            If (prior_to_last IsNot Nothing) Then
                linkToPenultimate.Text = prior_to_last.ToString()
            End If ''End of ""If (prior_to_last IsNot Nothing) Then""
        End If ''End of ""If (last_item Is Nothing) Then... Else..."

        ''Added 1/04/2024
        linkToEndpoint.Tag = last_item ''.ToString()

        ''Added 1/04/2024
        userControlOperation1.Lists_Endpoint = last_item
        userControlOperation1.Lists_Penultimate = prior_to_last

        ''Added 1/04/2024
        linkToPenultimate.Tag = prior_to_last ''.ToString()

    End Sub ''End of ""Private Sub RefreshTheUI_DisplayList()""


    Private Sub RefreshTheUI_OperationsCount()
        ''
        ''Added 1/03/2024 
        ''
        With labelNumOperations
            If (mod_firstPriorOpV1 Is Nothing) Then ''Added 1/20/2024 td
                ''Added 1/20/2024 td
                mod_intCountOperations = 0
            Else
                ''1/13/24 mod_intCountOperations = mod_stackOperations.Count
                mod_intCountOperations = mod_firstPriorOpV1.DLL_CountItemsAllInList()
            End If ''ENd of ""If (mod_firstPriorOpV1 Is Nothing) Then... Else..."

            .Text = String.Format(.Tag, mod_intCountOperations)
        End With ''End of ""With labelNumOperations""

    End Sub ''End of ""Private Sub RefreshTheUI_OperationsCount()""


    Private Sub RefreshTheUI_UndoRedoButtons()
        ''Added 1/15/2024 
        If (mod_opRedoMarker Is Nothing) Then
            buttonUndo.Enabled = (mod_intCountOperations > 0) ''False ''mod_opRedoMarker.HasOperationPrior()
            buttonReDo.Enabled = False ''mod_opRedoMarker.HasOperationNext()
        Else
            buttonUndo.Enabled = mod_opRedoMarker.HasOperationPrior()
            buttonReDo.Enabled = mod_opRedoMarker.HasOperationNext()
        End If

    End Sub ''end of ""Private Sub RefreshTheUI_UndoRedoButtons()""


    ''Private Sub DLL_OperationCreated_Delete(par_operationV1 As DLL_OperationV1,
    ''                                        par_inverseAnchor_PriorToRange As TwoCharacterDLLItem,
    ''                                        par_inverseAnchor_NextToRange As TwoCharacterDLLItem) _
    ''                                        Handles userControlOperation1.DLLOperationCreated_Delete
    ''    ''
    ''    ''Added 12/25/2023 
    ''    ''
    ''    ''   Version #1 (DLL_OperationV1) exposes more things than Version #2.
    ''    ''
    ''    ProcessOperation_Delete(par_operationV1, False)

    ''    ''
    ''    '' Make the Delete visible to the user.
    ''    ''
    ''    RefreshTheUI_DisplayList()

    ''    ''Added 1/01/2024
    ''    RecordNewestOperation(par_operationV1)

    ''    ''Added 1/03/2024
    ''    RefreshTheUI_OperationsCount()

    ''    ''Added 1/015/2024
    ''    RefreshTheUI_UndoRedoButtons()

    ''    ''Added 1/18/2024 
    ''    userControlOperation1.UpdateTheItemCount()

    ''End Sub ''End of ""Private Sub DLL_OperationCreated_Delete""


    ''Private Sub ProcessOperation_Delete(par_operationV1 As DLL_OperationV1,
    ''                                    Optional par_bIncludePostOpAdmin As Boolean = False)
    ''    ''
    ''    ''Encapsulated 1/01/2024 
    ''    ''Added 12/25/2023 
    ''    ''
    ''    ''   Version #1 (DLL_OperationV1) exposes more things than Version #2.
    ''    ''
    ''    ''Encapsulated 1/20/2024
    ''    ''----See FormTestUsingManager.1/20/2024
    ''    ''---mod_opsManager.ProcessOperation_Delete(par_operationV1)

    ''    With par_operationV1

    ''        ''objItemToInsert_First = mod_list.DLL_GetItemAtIndex(.)
    ''        ''mod_list.DLL_InsertOneItemAfter(each_twoCharsItem, prior, True)
    ''        ''.ImplementForList(mod_list)
    ''        Dim bChangeOfEndpoint As Boolean
    ''        Dim bChangeOfEndpoint_Start As Boolean
    ''        Dim bChangeOfEndpoint_Endpt As Boolean
    ''        Dim objDeleteRangeStart As TwoCharacterDLLItem ''12/28/2023
    ''        Dim objDeleteRangeEndpt As TwoCharacterDLLItem ''12/28/2023

    ''        If (.DeleteItemSingly IsNot Nothing) Then
    ''            ''Only a single item is being deleted. 
    ''            bChangeOfEndpoint_Start = (.DeleteItemSingly Is mod_firstTwoChar)
    ''            bChangeOfEndpoint_Endpt = (.DeleteItemSingly Is mod_list.DLL_GetLastItem())
    ''        Else
    ''            ''A range of items is being deleted. 
    ''            objDeleteRangeStart = .DeleteRangeStart
    ''            objDeleteRangeEndpt = .DeleteRangeStart.DLL_GetItemNext(-1 + .DeleteCount)
    ''            bChangeOfEndpoint_Start = (.DeleteRangeStart Is mod_firstTwoChar)
    ''            bChangeOfEndpoint_Endpt = (objDeleteRangeEndpt Is mod_list.DLL_GetLastItem())
    ''        End If ''End of ""If (.DeleteItemSingly IsNot Nothing) Then... Else..."

    ''        ''V2''bChangeOfEndpoint = (.GetIndexOfStart() <= -1 + mod_list.DLL_CountAllItems())
    ''        ''12/2023 bChangeOfEndpoint_Start = (.DeleteRangeStart Is mod_list.DLL_GetLastItem())
    ''        bChangeOfEndpoint = (bChangeOfEndpoint_Start Or bChangeOfEndpoint_Endpt)

    ''        ''V2''mod_list.DLL_DeleteItem(.GetSingleItem(), bChangeOfEndpoint)
    ''        If (.DeleteItemSingly IsNot Nothing) Then ''Added 12/28/2023 
    ''            ''Conditioned by If (...) on 12/28/2023 
    ''            mod_list.DLL_DeleteItem(.DeleteItemSingly, bChangeOfEndpoint)

    ''        ElseIf (.DeleteRangeStart IsNot Nothing) Then
    ''            ''Added 12/28/2023 thomas downes 
    ''            mod_list.DLL_DeleteRange(.DeleteRangeStart, .DeleteCount,
    ''                              bChangeOfEndpoint, .DeleteRangeEnd_Null)

    ''        Else
    ''            ''Added 12/28/2023 thomas downes 
    ''            Debugger.Break()

    ''        End If ''End of ""If (.DeleteItemSingly IsNot Nothing) Then... ElseIf... Else...

    ''        ''Added 12/28/2023 
    ''        If (bChangeOfEndpoint_Start) Then
    ''            mod_firstTwoChar = mod_list.DLL_GetFirstItem
    ''        End If ''End of ""If (bChangeOfEndpoint_Start) Then"'

    ''    End With ''End o f ""With par_operationV1"" 

    ''    ''
    ''    ''Admin, if requested.
    ''    ''
    ''    If (par_bIncludePostOpAdmin) Then
    ''        ''
    ''        '' Make the Delete visible to the user.
    ''        ''
    ''        RefreshTheUI_DisplayList()

    ''        ''Added 1/01/2024
    ''        RecordNewestOperation(par_operationV1)

    ''        ''Added 1/03/2024
    ''        RefreshTheUI_OperationsCount()

    ''    End If ''ENd of ""If (par_bIncludePostOpAdmin) Then""

    ''End Sub ''End of ""Private Sub ProcessOperation_Delete""


    ''''' <summary>
    ''''' This handles an event from the large user-control at the center of the form.
    ''''' </summary>
    ''''' <param name="par_operationV1"></param>
    ''Private Sub DLLOperationCreated_Insert(par_operationV1 As DLL_OperationV1) _
    ''                       Handles userControlOperation1.DLLOperationCreated_Insert
    ''    ''
    ''    ''Added 12/25/2023 
    ''    ''
    ''    ''   Version #1 (DLL_OperationV1) exposes more things than Version #2.
    ''    ''
    ''    ''Dim objItemToInsert_First As TwoCharacterDLLItem

    ''    ProcessOperation_Insert(par_operationV1, False)

    ''    ''
    ''    '' Make the Insert visible to the user.
    ''    ''
    ''    RefreshTheUI_DisplayList()

    ''    ''Added 1/01/2024
    ''    RecordNewestOperation(par_operationV1)

    ''    ''Added 1/03/2024
    ''    RefreshTheUI_OperationsCount()

    ''    ''Added 1/015/2024
    ''    RefreshTheUI_UndoRedoButtons()

    ''    ''Added 1/18/2024 
    ''    userControlOperation1.UpdateTheItemCount()

    ''End Sub ''ENd of ""Private Sub DLLOperationCreated_Insert""


    ''Private Sub ProcessOperation_Insert(par_operationV1 As DLL_OperationV1,
    ''                                    Optional par_bIncludePostOpAdmin As Boolean = False)
    ''    ''
    ''    ''Encapsulation 1/1/2024 
    ''    ''
    ''    ''----See FormTestUsingManager.1/20/2024
    ''    ''---mod_opsManager.ProcessOperation_Insert(par_operationV1)

    ''    With par_operationV1

    ''        ''objItemToInsert_First = mod_list.DLL_GetItemAtIndex(.)
    ''        ''mod_list.DLL_InsertOneItemAfter(each_twoCharsItem, prior, True)
    ''        ''.ImplementForList(mod_list)

    ''        ''V2''mod_list.DLL_InsertOneItemAfter(.GetSingleItem(),
    ''        ''                                .GetAnchor_precedingRange(),
    ''        ''                                False)
    ''        If (.AnchorToPrecedeItemOrRange IsNot Nothing) Then
    ''            ''
    ''            ''Option #1 of 3.  Insert operational item(s) AFTER anchoring item.
    ''            ''
    ''            ''                Insert A after 7, the preceding anchor.
    ''            ''                       |
    ''            ''          1 2 3 4 5 6 7 8 9 10
    ''            '' Result:  1 2 3 4 5 6 7 A 8 9 10
    ''            ''
    ''            If (.InsertItemSingly IsNot Nothing) Then
    ''                ''Insert a single item. 
    ''                mod_list.DLL_InsertOneItemAfter(.InsertItemSingly,
    ''                                        .AnchorToPrecedeItemOrRange,
    ''                                        .IsChangeOfEndpoint) ''False)

    ''            ElseIf (.InsertRangeStart IsNot Nothing) Then
    ''                ''Insert a range of items. 
    ''                mod_list.DLL_InsertRangeAfter(.InsertRangeStart, .InsertCount,
    ''                                        .AnchorToPrecedeItemOrRange,
    ''                                        .IsChangeOfEndpoint) ''False)
    ''            Else
    ''                Debugger.Break()

    ''            End If ''End of ""If (.InsertItemSingly IsNot Nothing) Then... ElseIf... Else"


    ''        ElseIf (.AnchorToSucceedItemOrRange IsNot Nothing) Then
    ''            ''
    ''            ''Option #2 of 3. Insert BEFORE anchoring item. 
    ''            ''
    ''            ''Insert operational item(s) BEFORE anchoring item.
    ''            ''
    ''            ''            Insert x before 6, the terminating anchor.
    ''            ''                   |
    ''            ''          1 2 3 4 5 6 7 8 9 10
    ''            '' Result:  1 2 3 4 5 x 6 7 8 9 10
    ''            ''
    ''            If (.InsertItemSingly IsNot Nothing) Then
    ''                ''Insert a single item. 
    ''                mod_list.DLL_InsertOneItemBefore(.InsertItemSingly,
    ''                                        .AnchorToSucceedItemOrRange,
    ''                                        .IsChangeOfEndpoint) ''False))

    ''            ElseIf (.InsertRangeStart IsNot Nothing) Then
    ''                ''Insert a range of items. 
    ''                mod_list.DLL_InsertRangeBefore(.InsertRangeStart, .InsertCount,
    ''                                        .AnchorToSucceedItemOrRange,
    ''                                        .IsChangeOfEndpoint) ''False)
    ''            Else
    ''                Debugger.Break()

    ''            End If ''End of ""If (.InsertItemSingly IsNot Nothing) Then... ElseIf... Else"


    ''        ElseIf (mod_firstTwoChar Is Nothing) Then
    ''            ''
    ''            ''Empty list !!!!
    ''            ''
    ''            ''Added 12/31/2023 thomas 
    ''            ''  We are populating an empty list, or as one might say,
    ''            ''  inserting a range into an empty list. 
    ''            ''
    ''            If (.InsertItemSingly IsNot Nothing) Then
    ''                ''Insert a single item, into an empty list. 
    ''                mod_list.DLL_InsertRangeEmptyList(.InsertItemSingly, 1)

    ''            ElseIf (.InsertRangeStart IsNot Nothing) Then
    ''                ''Insert a range of items, into an empty list. 
    ''                mod_list.DLL_InsertRangeEmptyList(.InsertRangeStart, .InsertCount)
    ''            Else
    ''                Debugger.Break()
    ''            End If ''End of ""If (.InsertItemSingly IsNot Nothing) Then... ElseIf... Else"

    ''            ''Be sure to save the first item.
    ''            mod_firstTwoChar = mod_list.DLL_GetFirstItem()

    ''        End If ''End of ""If (.AnchorToPrecedeItemOrRange IsNot Nothing) Then ... ElseIf... Else..."

    ''        ''Added 12/28/2023
    ''        If (.IsChangeOfEndpoint) Then
    ''            ''In the 50% chance the starting item is affected...
    ''            mod_firstTwoChar = mod_list.DLL_GetFirstItem()
    ''        End If ''End of ""If (.IsChangeOfEndpoint) Then""

    ''    End With ''End of ""With par_operationV1""

    ''    ''
    ''    ''Admin, if requested.
    ''    ''
    ''    If (par_bIncludePostOpAdmin) Then
    ''        ''
    ''        ''Refresh the Display.  (Make the Insert visible to the user.)
    ''        ''
    ''        RefreshTheUI_DisplayList()

    ''        ''Added 1/01/2024
    ''        RecordNewestOperation(par_operationV1)

    ''        ''Added 1/03/2024
    ''        RefreshTheUI_OperationsCount()

    ''    End If ''end of ""If (par_bIncludePostOpAdmin) Then""

    ''End Sub ''End of "Private Sub ProcessOperation_Insert"


    Private Sub DLLOperationCreated_SortAscending(par_operationV1 As DLL_OperationV1, par_isUndoOfSort As Boolean) Handles userControlOperation1.DLLOperationCreated_SortAscending
        ''
        ''Added 2/12/2024 
        ''
        ProcessOperation_Sorting(par_operationV1, False)

        ''
        '' Make the Sorting visible to the user.
        ''
        RefreshTheUI_DisplayList()
        RecordNewestOperation(par_operationV1)
        RefreshTheUI_OperationsCount()
        RefreshTheUI_UndoRedoButtons()

    End Sub ''End of ""DLLOperationCreated_SortAscending""


    Private Sub DLLOperationCreated_SortDescending(par_operationV1 As DLL_OperationV1, par_isUndoOfSort As Boolean) Handles userControlOperation1.DLLOperationCreated_SortDescending
        ''
        ''Added 2/12/2024 
        ''
        ProcessOperation_Sorting(par_operationV1, False)

        ''
        '' Make the Sorting visible to the user.
        ''
        RefreshTheUI_DisplayList()
        RecordNewestOperation(par_operationV1)
        RefreshTheUI_OperationsCount()
        RefreshTheUI_UndoRedoButtons()

    End Sub ''End of ""DLLOperationCreated_SortDescending""


    Private Sub ProcessOperation_Sorting(par_operationV1 As DLL_OperationV1,
                                        Optional par_bIncludePostOpAdmin As Boolean = False)
        ''
        ''Added 2/12/2024 
        ''
        With par_operationV1

            ''Condition added 2/13/2024 td
            If (.Sort_IsByQueue) Then
                ''This is the "undo" sorting operation, which relies on a
                ''  queue to enforce a prior sort order (regardless of rhyme or
                ''  reason).
                ''   --Added 2/13/2024 td
                ''-----mod_list.DLL_SortByQueue(.Sort_UndoQueue)
                Dim objPredeterminedSort As Queue(Of IDoublyLinkedItem)
                ''objPredeterminedSort = .Sort_UndoQueue
                objPredeterminedSort = .Queue_ForPredeterminedSort
                If (objPredeterminedSort Is Nothing) Then Debugger.Break()
                mod_list.DLL_SortByQueue(objPredeterminedSort)

            Else
                ''This is the primary sorting operation.
                mod_list.DLL_SortItems(.Sort_IsDescending)

            End If ''End of ""If (.Sort_IsByQueue) Then... Else..."

            ''Added2/12/2024 
            mod_firstTwoChar = mod_list.DLL_GetFirstItem()

        End With ''End of ""With par_operationV1""

        ''
        ''Admin, if requested.
        ''
        If (par_bIncludePostOpAdmin) Then
            ''
            ''Refresh the Display.  (Make the Insert visible to the user.)
            ''
            RefreshTheUI_DisplayList()

            ''Added 1/01/2024
            RecordNewestOperation(par_operationV1)

            ''Added 1/03/2024
            RefreshTheUI_OperationsCount()

        End If ''end of ""If (par_bIncludePostOpAdmin) Then""

    End Sub ''End of "Private Sub ProcessOperation_Sorting"


    Private Sub DLLOperationCreated_MoveRange(par_operationV1 As DLL_OperationV1,
                                        par_inverseAnchor_PriorToRange As TwoCharacterDLLItem,
                                        par_inverseAnchor_NextToRange As TwoCharacterDLLItem) _
                                        Handles userControlOperation1.DLLOperationCreated_MoveRange
        ''
        ''Added 12/25/2023 
        ''
        ''   Version #1 (DLL_OperationV1) exposes more things than Version #2.
        ''
        ProcessOperation_MoveRange(par_operationV1)

        ''
        ''Refresh the Display.  (Make the Insert visible to the user.)
        ''
        RefreshTheUI_DisplayList()

        ''Added 1/01/2024
        RecordNewestOperation(par_operationV1)

        ''Added 1/03/2024
        RefreshTheUI_OperationsCount()

        ''Added 1/015/2024
        RefreshTheUI_UndoRedoButtons()

    End Sub


    Private Sub ProcessOperation_MoveRange(par_operationV1 As DLL_OperationV1,
                                        Optional par_bIncludePostOpAdmin As Boolean = False)
        ''
        ''   Version #1 (DLL_OperationV1) exposes more things than Version #2.
        ''
        ''  Encapsulated 1/2/2024 td
        ''
        With par_operationV1
            ''
            ''Step 1 of 2.  Cut (via "Delete") the range from the list. 
            ''
            mod_list.DLL_DeleteRange(.MovedRangeStart, .MovedCount,
                                            .IsChangeOfEndpoint) ''False)

            ''Added 12/30/2023 td
            If (Testing.TestingByDefault) Then
                ''Test that the ends are CLEAN OF REFERENCES.
                Dim firstItem As IDoublyLinkedItem = .MovedRangeStart
                Dim lastItem As IDoublyLinkedItem = .MovedRangeStart.DLL_GetItemNext(-1 + .MovedCount)
                ''Test that the ends are CLEAN OF REFERENCES.
                If (firstItem.DLL_HasPrior()) Then Debugger.Break()
                If (lastItem.DLL_HasNext()) Then Debugger.Break()
            End If ''End of ""If (Testing.TestingByDefault) Then""

            ''
            ''Step 2 of 2.  Paste (via "Insert") the range into the list. 
            ''
            If (.AnchorToPrecedeItemOrRange IsNot Nothing) Then
                ''Move operational item(s) AFTER anchoring item.
                ''
                ''                  Move 2_3_4 after 7, the preceding anchor.
                ''                       |
                ''          1 2_3_4 5 6 7 8 9 10
                '' Result:  1 5 6 7 2_3_4 8 9 10   <<< Note that 2_3_4 has been moved.
                ''

                mod_list.DLL_InsertRangeAfter(.MovedRangeStart, .MovedCount,
                                            .AnchorToPrecedeItemOrRange,
                                            .IsChangeOfEndpoint) ''False)

            Else
                ''Move operational item(s) BEFORE anchoring item.
                ''
                ''              Move 2_3_4 before 6, the terminating anchor.
                ''                   |
                ''          1 2_3_4 5 6 7 8 9 10
                '' Result:  1 5 2_3_4 6 7 8 9 10
                ''
                mod_list.DLL_InsertRangeBefore(.MovedRangeStart, .MovedCount,
                                            .AnchorToSucceedItemOrRange,
                                            .IsChangeOfEndpoint) ''False))

            End If ''End of ""If (.AnchorToPrecedeItemOrRange IsNot Nothing) Then ... Else..."

            ''Added 12/28/2023
            If (.IsChangeOfEndpoint) Then
                ''In the 50% chance the starting item is affected...
                mod_firstTwoChar = mod_list.DLL_GetFirstItem()
            End If ''End of ""If (.IsChangeOfEndpoint) Then""

        End With ''End of ""With par_operationV1""

        ''
        ''Admin, if requested.
        ''
        If (par_bIncludePostOpAdmin) Then
            ''
            ''Refresh the Display.  (Make the Insert visible to the user.)
            ''
            RefreshTheUI_DisplayList()

            ''Added 1/01/2024
            RecordNewestOperation(par_operationV1)

            ''Added 1/03/2024
            RefreshTheUI_OperationsCount()

        End If ''end of ""If (par_bIncludePostOpAdmin) Then""

        ''Added 1/015/2024
        RefreshTheUI_UndoRedoButtons()

    End Sub ''ENd of ""Private Sub DLLOperationCreated_MoveRange"


    Private Sub RecordNewestOperation(par_newOpV1 As DLL_OperationV1)
        ''
        ''Added 1/01/2024
        ''
        If (par_newOpV1.CreatedAsUndoOperation) Then
            ''Process the Undo Operation.
            ''---mod_intCountOperations -= 1
            ''1/13/24 mod_intCountOperations = 0
            ''1/13/24 mod_lastPriorOpV1 = Nothing ''Clear the last operation.

            ''Added 1/02/2024
            ''1/13/24 If (0 < mod_stackOperations.Count()) Then
            ''    mod_lastPriorOpV1 = mod_stackOperations.Pop()
            ''End If ''Edn of ""If (0 < mod_stackOperations.Count()) Then""
            Debugger.Break()

        ElseIf (par_newOpV1.CreatedAsUndoOperation) Then
            ''Added 1/16/2024
            Debugger.Break()

        ElseIf (mod_firstPriorOpV1 Is Nothing) Then
            ''
            ''This is the first recorded operation.
            ''
            mod_firstPriorOpV1 = par_newOpV1
            mod_lastPriorOpV1 = par_newOpV1
            mod_intCountOperations = 1
            mod_opRedoMarker = New DLL_OperationsRedoMarker(mod_firstPriorOpV1)

        Else
            ''Increase the count of operations.
            mod_intCountOperations += 1

            ''Added 1/2/2024 
            ''If (mod_lastPriorOpV1 IsNot Nothing) Then
            ''    mod_stackOperations.Append(mod_lastPriorOpV1)
            ''End If ''End of ""If (mod_lastPriorOpV1 IsNot Nothing) Then""

            ''---mod_stackOperations.Append(par_lastPriorOpV1)
            ''1/13/24  mod_stackOperations.Push(par_lastPriorOpV1)

            ''---- SLIGHTLY DIFFICULT AND CONFUSING---------------
            ''
            Dim tempRef_penultimateOpV1 As DLL_OperationV1 ''Penultimate is "next to last". Temporary reference variable.
            Dim tempRef_ultimateOpV1 As DLL_OperationV1 ''Ultimate is "very last". Temporary reference variable.

            tempRef_penultimateOpV1 = mod_lastPriorOpV1 ''The former last item.
            tempRef_ultimateOpV1 = par_newOpV1 ''The brand-new last item.

            If (tempRef_penultimateOpV1 Is Nothing) Then
                ''We either haven't collected an operation before this present function call,
                ''  or we have somehow "dispensed" with all of our recorded 
                ''  operations. --1/15/2024
            Else
                tempRef_penultimateOpV1.DLL_SetItemNext(tempRef_ultimateOpV1)
                tempRef_ultimateOpV1.DLL_SetItemPrior(tempRef_penultimateOpV1)
            End If ''If (tempRef_penultimateOpV1 Is Nothing) Then... Else...

            ''112014 mod_lastPriorOpV1 = par_lastPriorOpV1
            mod_lastPriorOpV1 = tempRef_ultimateOpV1 ''Save tempRef_ultimateOpV1.

            ''Update the redo marker. 
            mod_opRedoMarker.ShiftMarker_DueToNewOperation(par_newOpV1)

        End If ''End of ""If (par_lastPriorOpV1.CreatedAsUndoOperation) Then... Else..."

        ''With LabelNumOperations
        ''    LabelNumOperations.Text = String.Format(.Tag, mod_intCountOperations)
        ''End With
        ''Added 1/03/2024 
        ''RefreshTheUI_OperationsCount()

    End Sub ''End of ""Private Sub RecordLastPriorOperation()""


    Private Sub ProcessOperation_AnyType(parOperation As DLL_OperationV1)
        ''
        ''Added 1/15/2024 
        ''
        Dim opType As Char
        opType = parOperation.OperationType

        ''Select Case opType
        ''    Case "I"c
        ''        ''Insert (the inverse of Delete)
        ''        ProcessOperation_Insert(parOperation) ''.GetUndoVersionOfOperation())
        ''    Case "D"c
        ''        ''Delete (the inverse of Insert)
        ''        ProcessOperation_Delete(parOperation) ''.GetUndoVersionOfOperation())
        ''    Case "M"c
        ''        ''Move Range (the inverse of Move Range)
        ''        ProcessOperation_MoveRange(parOperation) ''.GetUndoVersionOfOperation())
        ''    Case "S"c
        ''        ''Sort the List 
        ''        ProcessOperation_Sorting(parOperation) ''.GetUndoVersionOfOperation())
        ''    Case Else
        ''        Debugger.Break()
        ''End Select ''End of ""Select Case inverse_opType""

    End Sub ''ENd of ""Private Sub ProcessOperation_AnyType""


    Private Sub UndoOperation_ViaInverseOf(parOperationV1 As DLL_OperationV1)
        ''
        ''Added 1/03/2024 td
        ''
        Dim opType As Char
        Dim inverse_opType As Char
        Const ENCAPSULATE As Boolean = True ''Added 1/15/2024

        If (ENCAPSULATE) Then
            ''Added 1/15/2024
            Dim opUndoVersion As DLL_OperationV1 ''Added 11/5/2024
            opUndoVersion = parOperationV1.GetUndoVersionOfOperation()
            ProcessOperation_AnyType(opUndoVersion)

        Else
            opType = parOperationV1.OperationType
            If (opType = "I"c) Then inverse_opType = "D"c
            If (opType = "D"c) Then inverse_opType = "I"c
            If (opType = "M"c) Then inverse_opType = "M"c

            ''Select Case inverse_opType
            ''    Case "I"c
            ''        ''Insert (the inverse of Delete)
            ''        ProcessOperation_Insert(parOperationV1.GetUndoVersionOfOperation())
            ''    Case "D"c
            ''        ''Delete (the inverse of Insert)
            ''        ProcessOperation_Delete(parOperationV1.GetUndoVersionOfOperation())
            ''    Case "M"c
            ''        ''Move Range (the inverse of Move Range)
            ''        ProcessOperation_MoveRange(parOperationV1.GetUndoVersionOfOperation())
            ''    Case Else
            ''        Debugger.Break()
            ''End Select ''End of ""Select Case inverse_opType""

        End If ''END OF ""If (ENCAPSULATE) Then... Else..."

    End Sub ''End of ""Private Sub UndoOperation_ViaInverseOf(eachOperation As DLL_OperationV1)""


    Private Sub LinkSingleItem_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkSingleItemOnly.LinkClicked

        ''Added 12/26/2023 td
        userControlOperation1.ToggleSingleItemMode()

    End Sub

    Private Sub LinkEndpointHeading_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkEndpointHeading.LinkClicked

        ''Added 12/31/2023
        userControlOperation1.ToggleFinalEndpointItemMode()

    End Sub

    Private Sub UserControlOperation1_Load(sender As Object, e As EventArgs) Handles userControlOperation1.Load

    End Sub


    Private Sub DLLOperationCreated_UndoOfInsert(par_operation As DLL_OperationV1,
                                                                       par_isUndoOfInsert As Boolean) _
                                                 Handles userControlOperation1.DLLOperationCreated_UndoOfInsert
        ''
        ''Added 1/1/2024  
        ''
        ''See UndoOfInsert_NoParams().---1/4/2024 
        ''1/4/2024  ProcessOperation_Delete(par_operation)

    End Sub

    Private Sub DLLOperationCreated_UndoOfDelete(par_operation As DLL_OperationV1,
                                                                       par_isUndoOfDelete As Boolean) _
                                       Handles userControlOperation1.DLLOperationCreated_UndoOfDelete
        ''
        ''Added 1/1/2024  
        ''
        ''See UndoOfDelete_NoParams().---1/4/2024 
        ''1/4/2024  ProcessOperation_Insert(par_operation)

    End Sub

    Private Sub DLLOperationCreated_UndoOfMove(par_operation As DLL_OperationV1,
                                                                     par_isUndoOfMove As Boolean) _
                            Handles userControlOperation1.DLLOperationCreated_UndoOfMove
        ''
        ''Added 1/1/2024  
        ''
        ''See UndoOfMove_NoParams().---1/4/2024 
        ''1/4/2024 ProcessOperation_MoveRange(par_operation)


    End Sub


    Private Sub UndoOfDelete_NoParams() Handles userControlOperation1.UndoOfDelete_NoParams
        ''
        ''Added 1/1/2024  
        ''
        UndoOfSpecificOperationType("D"c, "Delete")

        ''Added 1/15/2024 
        RefreshTheUI_UndoRedoButtons()

    End Sub


    Private Sub UndoOfInsert_NoParams() Handles userControlOperation1.UndoOfInsert_NoParams
        ''
        ''Added 1/1/2024  
        ''
        UndoOfSpecificOperationType("I"c, "Insert")

        ''Added 1/15/2024 
        RefreshTheUI_UndoRedoButtons()

    End Sub


    Private Sub UndoOfMoveRange_NoParams() Handles userControlOperation1.UndoOfMoveRange_NoParams
        ''
        ''Added 1/1/2024  
        ''
        UndoOfSpecificOperationType("M"c, "Move")

        ''Added 1/15/2024 
        RefreshTheUI_UndoRedoButtons()

    End Sub


    Private Sub UndoOfSpecificOperationType(par_typeOfOp As Char, par_wordForOperation As String)
        ''--Private Sub UndoOfDelete_NoParams() Handles UserControlOperation1.UndoOfDelete_NoParams
        ''
        ''Encapsulated 1/3/2024 
        ''
        Dim eachOperationType As Char
        Dim bFoundDesiredOperationTypeOnStack As Boolean = False
        ''Dim bNotDone As Boolean = True
        Dim bCompletedWhileLoop As Boolean = False
        Dim eachOperation As DLL_OperationV1
        Dim each_boolIsOfSpecifiedType As Boolean

        If (mod_firstPriorOpV1 Is Nothing) Then
            MessageBoxTD.Show_Statement("Sorry!!", "No operations are found.")
            Exit Sub
        End If

        Dim largestIndex As Integer ''= (-1 + mod_stackOperations.Count())
        largestIndex = -1 + mod_firstPriorOpV1.DLL_CountItemsAllInList()

        ''Dim eachIndex As Integer = largestIn dex ''(-1 + mod_stackOperations.Count())
        Dim currentMarkerIndex_Redo As Integer = mod_opRedoMarker.GetCurrentIndex_Redo()
        Dim currentMarkerIndex_Undo As Integer = mod_opRedoMarker.GetCurrentIndex_Undo()

        ''
        ''Step #1 of 2.  Does the relevant operation type exist on the stack? 
        ''
        bFoundDesiredOperationTypeOnStack = mod_opRedoMarker.HasTypeOfOperation_Prior(par_typeOfOp)

        ''
        ''Step #2 of 2.  Execute "Undo" for all operations, down to & including
        ''   the largest-index Delete operation. 
        ''
        If (bFoundDesiredOperationTypeOnStack) Then
            ''
            ''Pop off the intervening operations, until we reach
            ''  the desired operation.
            ''
            ''1/15/2024 For eachIndex = largestIndex To index_ofDeleteOperation
            ''    ''---eachOperation = mod_stackOperations.ElementAt(eachIndex)
            ''    eachOperation = mod_stackOperations.Pop()
            ''    ''Major call!!
            ''    UndoOperation_ViaInverseOf(eachOperation)
            ''    RefreshTheUI_OperationsCount()
            ''Next eachIndex

            bCompletedWhileLoop = False ''Initialize.
            While (Not bCompletedWhileLoop) ''While bNotDone
                ''
                ''Look for an operation of the specified type (par_typeOfOp).
                ''
                eachOperation = mod_opRedoMarker.GetMarkersPrior_ShiftPositionLeft()
                UndoOperation_ViaInverseOf(eachOperation)
                eachOperationType = eachOperation.OperationType
                each_boolIsOfSpecifiedType = (eachOperationType = par_typeOfOp)
                If each_boolIsOfSpecifiedType Then ''If each_isDelete Then
                    bFoundDesiredOperationTypeOnStack = True
                    bCompletedWhileLoop = True
                Else
                    bCompletedWhileLoop = eachOperation.DLL_NotAnyPrior()
                End If ''END OF "'If each_isDelete Then... Else..."

            End While ''ENd of ""While Not bCompletedWhile""

            ''
            ''Refresh the Display.  (Make the Insert visible to the user.)
            ''
            RefreshTheUI_DisplayList()

            ''Added 1/03/2024
            RefreshTheUI_OperationsCount()

        Else
            ''
            ''Added 1/3/2024
            ''
            ''#1 1/4/2024 MessageBoxTD.Show_Statement("Sorry, no Delete operations are found on the Stack!!")
            '' #2 1/4/2024 MessageBoxTD.Show_Formatting("Sorry, no {0} operations are found on the Stack!!",
            ''                           par_wordForOperation)
            MessageBoxTD.Show_InsertWordFormat_Line1(par_wordForOperation,
                        "Sorry, no {0} operations are found on the Stack!!")

        End If ''ENd of ""If (bFoundDeleteOperationOnStack) Then""


    End Sub ''End of ""Private Sub UndoOfSpecificOperationType()""


    Private Sub UndoOfPriorOperation_AnyType(par_opRedoMarker As DLL_OperationsRedoMarker)
        ''
        ''Added 1/10/2024 thomas downes
        ''
        Dim intCountFurtherUndos As Integer
        Dim operationToUndo As DLL_OperationV1

        If (par_opRedoMarker.HasOperationPrior()) Then
            ''
            ''Great, we will be able to do the "Undo" operation.
            ''
        Else
            MessageBoxTD.Show_Statement("No Undo operation is in queue.") ''1/15/24
            Exit Sub
        End If ''If (par_opRedoMarker.HasOperationPrior()) Then... else

        intCountFurtherUndos = (1 + par_opRedoMarker.GetCurrentIndex_Undo())

        If (0 = intCountFurtherUndos) Then

            ''Added 1/10/2024 
            MessageBoxTD.Show_Statement("Sorry, no more (recorded) operations remain to Undo.")

        Else
            ''
            '' Undo the operation which is the RedoMarker's currently-designated
            ''   Undo operation.
            ''
            operationToUndo = par_opRedoMarker.GetCurrentOp_Undo()

            ''Major call!!
            UndoOperation_ViaInverseOf(operationToUndo)

            ''Major call!!  --1/10/2024
            par_opRedoMarker.ShiftMarker_AfterUndo_ToPrior()

            ''
            ''Refresh the Display.  (Make the Insert visible to the user.)
            ''
            RefreshTheUI_DisplayList()

            ''Added 1/03/2024
            RefreshTheUI_OperationsCount()

        End If ''End of ""If (0 = intCountOpsInStack) Then ... Else..."

    End Sub ''Private Sub UndoOfPriorOperation_AnyType


    Private Sub UndoOfPriorOperation_AnyType(par_stackOperations As Stack(Of DLL_OperationV1))
        ''
        ''Added 1/10/2024 thomas downes
        ''
        Dim lastOperationV1 As DLL_OperationV1
        Dim intCountOpsInStack As Integer

        intCountOpsInStack = par_stackOperations.Count()

        If (0 = intCountOpsInStack) Then

            ''Added 1/10/2024 
            MessageBoxTD.Show_Statement("Sorry, no more (recorded) operations remain to Undo.")

        Else

            lastOperationV1 = par_stackOperations.Pop()
            ''Major call!!
            UndoOperation_ViaInverseOf(lastOperationV1)

            ''
            ''Refresh the Display.  (Make the Insert visible to the user.)
            ''
            RefreshTheUI_DisplayList()

            ''Added 1/03/2024
            RefreshTheUI_OperationsCount()

        End If ''End of ""If (0 = intCountOpsInStack) Then ... Else..."

    End Sub ''ENd of ""Private Sub UndoOfPriorOperation_AnyType()""


    Private Sub LinkToPenultimate_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkToPenultimate.LinkClicked

        ''Added 1/4/2024
        With userControlOperation1

            .SetRangeEndpoint(CType(CType(sender, Control).Tag, TwoCharacterDLLItem))

        End With

    End Sub

    Private Sub LinkToEndpoint_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkToEndpoint.LinkClicked

        ''Added 1/4/2024
        With userControlOperation1

            .SetRangeEndpoint(CType(CType(sender, Control).Tag, TwoCharacterDLLItem))

        End With


    End Sub

    Private Sub LinkToEndpoint_Click(sender As Object, e As EventArgs) Handles linkToEndpoint.Click

        ''Added 1/18/2024 
        If (mod_list.DLL_GetFirstItem() Is Nothing) Then
            ''Added 1/18/2024 
            Debugger.Break()
        End If ''End of ""If (mod_list.DLL_GetFirstItem() Is Nothing) Then""

        ''Added 1/05/2024 thomas downes
        With userControlOperation1

            .Struct_endpoint = New StructEndPoint(mod_list, True)
            .UpdateTheItemCount(mod_list.DLL_CountAllItems(),
                                True, .Struct_endpoint)

        End With ''End of ""With UserControlOperation1""

    End Sub

    Private Sub LinkToPenultimate_Click(sender As Object, e As EventArgs) Handles linkToPenultimate.Click

        ''Added 1/05/2024 thomas downes
        Const PENULTIMATE As Boolean = True

        ''Added 1/18/2024 
        If (mod_list.DLL_GetFirstItem() Is Nothing) Then
            ''Added 1/18/2024 
            Debugger.Break()
        End If ''End of ""If (mod_list.DLL_GetFirstItem() Is Nothing) Then""

        With userControlOperation1
            .Struct_endpoint = New StructEndPoint(mod_list, False, PENULTIMATE)

            ''Added 1/05/2024 
            .UpdateTheItemCount(mod_list.DLL_CountAllItems(),
                                True, .Struct_endpoint)

        End With ''End of ""With UserControlOperation1""

    End Sub

    Private Sub UserControlOperation1_Sort_Ascending() Handles userControlOperation1.Sort_Ascending

        ''Added 1/7/2024
        mod_list.DLL_SortItems()

        ''Added 1/8/2024
        mod_firstTwoChar = mod_list.DLL_GetFirstItem

        ''Added 1/7/2024
        RefreshTheUI_DisplayList()

    End Sub

    Private Sub UserControlOperation1_Sort_Descending() Handles userControlOperation1.Sort_Descending

        ''Added 1/7/2024
        mod_list.DLL_SortItems(True)

        ''Added 1/8/2024
        mod_firstTwoChar = mod_list.DLL_GetFirstItem

        ''Added 1/7/2024
        RefreshTheUI_DisplayList()

    End Sub

    Private Sub buttonUndo_Click(sender As Object, e As EventArgs) Handles buttonUndo.Click

        ''Added 1/10/2024 td 

        ''1/11/2024  UndoOfPriorOperation_AnyType()
        UndoOfPriorOperation_AnyType(mod_opRedoMarker)

        ''Added 1/15/2024 
        RefreshTheUI_UndoRedoButtons()

    End Sub


    Private Sub buttonReDo_Click(sender As Object, e As EventArgs) Handles buttonReDo.Click

        ''Added 1/15/2024
        Dim opReDo As DLL_OperationV1
        ''opReDo =
        ''   mod_opRedoMarker.GetMarkersPrior_ShiftPositionLeft()
        opReDo =
            mod_opRedoMarker.GetMarkersNext_ShiftPositionRight()

        ''added 1/16/2024 td
        opReDo.CreatedAsRedoOperation = True

        ''Major call!!
        ProcessOperation_AnyType(opReDo)

        ''Added 1/15/2024 
        RefreshTheUI_DisplayList()
        RefreshTheUI_UndoRedoButtons()

    End Sub

    Private Sub LinkClearRecordedOps_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkClearRecordedOps.LinkClicked

        ''Added 1/20/2024 
        mod_firstPriorOpV1 = Nothing
        mod_lastPriorOpV1 = Nothing
        mod_opRedoMarker.Clear()

        ''Added 1/20/2024 
        RefreshTheUI_UndoRedoButtons()
        RefreshTheUI_OperationsCount()

    End Sub


    Private Sub LabelNotTestingManager_Click(sender As Object, e As EventArgs) Handles LabelNotTestingManager.Click

        ''Not needed
        LabelNotTestingManager.Visible = False

    End Sub


End Class
