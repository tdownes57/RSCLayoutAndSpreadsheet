''------Public Class FormDemo1DVertical

''
'' Added 10/14/2024 T_homas C. D_ownes 
''
''Jan2025 Imports System.ComponentModel.Design
''Jan2025 Imports System.Diagnostics.Metrics
Imports System.Text
Imports ciBadgeInterfaces

''Jan2025 Imports ciBadgeInterfaces
Imports ciBadgeSerialize
Imports RSCLibraryDLLOperations

Public Class FormDemo1DVertical
    ''
    '' Added 1/18/2025 & 10/14/2024 thomas c. downes 
    ''
    ''March 2025 Private mod_managerVerticalOps.As DLLOperationsManager1D(Of TwoCharacterDLLVerticalA)
    Private mod_managerVerticalOps As DLLOperationsManager1D(Of TwoCharacterDLLVerticalA, DLLUserControlRichbox)

    ''' <summary>
    ''' Manager of a list of Operation Index Structures. ---6/11/2025 td
    ''' </summary>
    Private mod_managerOperationsByIndexStructures As New DLLOperationsManagerByIndexStructures


    ''The textbox (versus any of the containers!)
    Private WithEvents mod_listA As DLLList(Of TwoCharacterDLLVerticalA)
    Private mod_firstItemA As TwoCharacterDLLVerticalA
    Private mod_lastItemA As TwoCharacterDLLVerticalA
    Private mod_rangeA As DLLRange(Of TwoCharacterDLLVerticalA) ''Added 11/14/2024 t.homas d.ownes

    ''The first (leftmost) container (blue-gray background).
    ''Mar2025 Private mod_listB1 As DLLList(Of DLLUserControlTextbox)

    ''Mar2025 Private WithEvents mod_firstItemB1 As DLLUserControlTextbox
    ''Mar2025 Private WithEvents mod_lastItemB1 As DLLUserControlTextbox
    ''Mar2025 Private mod_rangeB1 As DLLRange(Of DLLUserControlTextbox) ''Added 11/14/2024 t.homas d.ownes

    ''The second (2nd leftmost) container (off-white background).
    ''Mar2025 Private mod_listB2 As DLLList(Of DLLUserControlRichbox)
    Private WithEvents mod_listB1 As DLLList(Of DLLUserControlRichbox)
    Private WithEvents mod_listB2 As DLLList(Of DLLUserControlRichbox)
    Private WithEvents mod_listB3 As DLLList(Of DLLUserControlRichbox)

    ''Added 5/04/2025 thomas downes
    Private WithEvents mod_listCurrentWithFocus As DLLList(Of DLLUserControlRichbox)
    Private WithEvents mod_listPriorWithFocus As DLLList(Of DLLUserControlRichbox)
    Private mod_priorClickedRichbox As DLLUserControlRichbox ''Added 5/04/2025
    Private mod_currentClickedRichbox As DLLUserControlRichbox ''Added 5/04/2025

    Private WithEvents mod_firstItemB1 As DLLUserControlRichbox
    Private WithEvents mod_lastItemB1 As DLLUserControlRichbox

    Private WithEvents mod_firstItemB2 As DLLUserControlRichbox
    Private WithEvents mod_lastItemB2 As DLLUserControlRichbox

    Private WithEvents mod_firstItemB3 As DLLUserControlRichbox
    Private WithEvents mod_lastItemB3 As DLLUserControlRichbox

    Private mod_rangeB1 As DLLRange(Of DLLUserControlRichbox) ''Added 03/28/2025 t.homas d.ownes
    Private mod_rangeB2 As DLLRange(Of DLLUserControlRichbox) ''Added 11/14/2024 t.homas d.ownes
    Private mod_rangeB3 As DLLRange(Of DLLUserControlRichbox) ''Added 03/28/2025 t.homas d.ownes

    Private Const INITIAL_ITEM_COUNT_30 As Integer = 10 ''99 ''5 ''---Added 12/9/2024--- 30
    Private ReadOnly ARRAY_OF_DELIMITERS = New Char() {","c, " "c}
    Private APPLICATION_DOEVENTS As Boolean = False ''---True ''Added 12/18/2024 td
    Private REFRESH_FIRST_ITEM As Boolean = False ''---True ''Added 12/18/2024 td
    Private SORT_PRIMARY_LIST_AFTER_PARALLELS As Boolean = True ''Added 5/18/2025 td

    ''' <summary>
    ''' Puts {mod_listB1, mod_listB2, mod_listB3} into an array of lists.
    ''' </summary>
    ''' <returns>An array of DLLLists (Of DLLUserControlRichbox)</returns>
    Public Function GetParallelLists() As DLLList(Of DLLUserControlRichbox)()

        Return New DLLList(Of DLLUserControlRichbox)() _
            {mod_listB1, mod_listB2, mod_listB3}

    End Function ''End of ""Public Function GetParallelLists()""


    Public Function GetParallelLists_Count() As Integer
        ''
        ''Added 4/08/2025
        ''
        Return GetParallelLists().Count()

    End Function ''End of ""Public Function GetParallelLists()""


    ''' <summary>
    ''' Create an array of DLL Ranges, consisting of new items..
    ''' </summary>
    ''' <returns>An array of DLLRanges (Of DLLUserControlRichbox)</returns>
    Public Function GetParallelRangesOfNewItems(par_countNeededRanges As Integer,
                         par_countNewItemsInRange As Integer,
                         par_stringTwoChars As String) As DLLRange(Of DLLUserControlRichbox)()
        ''
        ''Added 4/08/2025  
        ''
        Dim output_array As DLLRange(Of DLLUserControlRichbox)()
        ReDim output_array(0 To par_countNeededRanges - 1)
        Dim each_range As DLLRange(Of DLLUserControlRichbox)
        Dim each_newBox As DLLUserControlRichbox

        For indexOuter As Integer = 0 To (par_countNeededRanges - 1)

            each_range = New DLLRange(Of DLLUserControlRichbox)(True,
                New DLLUserControlRichbox())

            For indexInner As Integer = 0 To (par_countNewItemsInRange - 1)

                each_newBox = New DLLUserControlRichbox(par_stringTwoChars)
                each_range.AddItemToTheEndOfRange_NewItem(each_newBox)

            Next indexInner

            ''Added 4/08/2025 td
            output_array(indexOuter) = each_range

        Next indexOuter

        Return output_array

    End Function ''End of ""Public Function GetParallelLists()""



    Private Sub FormSimpleDemoOfCSharp1D_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        '' Added 03/22/2025 and 10/14/2024 thomas c. downes 
        ''
        Dim newItemA As TwoCharacterDLLVerticalA
        Dim indexNewItem As Integer
        ''Mar2025 Dim newItemB1 As DLLUserControlTextbox
        Dim newItemB1 As DLLUserControlRichbox
        Dim newItemB2 As DLLUserControlRichbox
        Dim newItemB3 As DLLUserControlRichbox

        ''mod_firstItemA = New TwoCharacterDLLVerticalA("01")
        ''mod_lastItemA = mod_firstItemA
        mod_listA = New DLLList(Of TwoCharacterDLLVerticalA)()
        ''Mar2025 mod_listB1 = New DLLList(Of DLLUserControlTextbox)()
        mod_listB1 = New DLLList(Of DLLUserControlRichbox)()
        mod_listB2 = New DLLList(Of DLLUserControlRichbox)()
        mod_listB3 = New DLLList(Of DLLUserControlRichbox)()

        ''Added 3/05/2025 td
        Dim arrayTwoCharStrings As String()
        ''Added 3/05/2025 td
        ReDim arrayTwoCharStrings(10)
        Dim strTwoChars As String
        Dim index_0based As Integer = 0

        ''
        '' Generate the three (3) ranges of newly-generated  items.
        ''
        For indexNewItem = 1 To INITIAL_ITEM_COUNT_30 ''---30
            ''
            '' Iteratively expand the three (3) ranges of newly-generated  items.
            ''
            strTwoChars = indexNewItem.ToString("00")
            arrayTwoCharStrings(index_0based) = strTwoChars

            ''TwoCharacterDLLVertical
            newItemA = New TwoCharacterDLLVerticalA(strTwoChars)
            mod_listA.DLL_InsertItemAtEnd(newItemA)

            ''DLLUserControlTextbox 
            ''Mar2025 newItemB1 = New DLLUserControlTextbox(strTwoChars)
            ''Mar2025 mod_listB1.DLL_InsertItemAtEnd(newItemB1)

            ''DLLUserControlRichbox 
            newItemB1 = New DLLUserControlRichbox(strTwoChars)
            newItemB1.ColumnLetter = "B1"
            AddHandler newItemB1.DLLUserClickedControlBox, AddressOf DllUserControlRichbox1_Click
            mod_listB1.DLL_InsertItemAtEnd(newItemB1)

            newItemB2 = New DLLUserControlRichbox(strTwoChars)
            newItemB2.ColumnLetter = "B2"
            AddHandler newItemB2.DLLUserClickedControlBox, AddressOf DllUserControlRichbox1_Click
            mod_listB2.DLL_InsertItemAtEnd(newItemB2)

            newItemB3 = New DLLUserControlRichbox(strTwoChars)
            newItemB3.ColumnLetter = "B3"
            AddHandler newItemB3.DLLUserClickedControlBox, AddressOf DllUserControlRichbox1_Click
            mod_listB3.DLL_InsertItemAtEnd(newItemB3)

            ''Prepare for next iteration.
            index_0based += 1
            If (mod_firstItemA Is Nothing) Then mod_firstItemA = newItemA
            If (mod_firstItemB1 Is Nothing) Then mod_firstItemB1 = newItemB1
            If (mod_firstItemB2 Is Nothing) Then mod_firstItemB2 = newItemB2
            If (mod_firstItemB3 Is Nothing) Then mod_firstItemB3 = newItemB3

        Next indexNewItem

        ''//
        ''//   Only --AFTER-- looping...
        ''//
        ''//   Added 4/17/2025
        mod_lastItemA = newItemA
        mod_lastItemB1 = newItemB1
        mod_lastItemB2 = newItemB2
        mod_lastItemB3 = newItemB3

        ''//
        ''//   Only --AFTER-- looping...
        ''//
        ''//   Added 4/17/2025
        mod_lastItemA.DLL_MarkAsEndOfList()
        mod_lastItemB1.DLL_MarkAsEndOfList()
        mod_lastItemB2.DLL_MarkAsEndOfList()
        mod_lastItemB3.DLL_MarkAsEndOfList()

        ''
        '' added 12/30/2024 
        ''
        numDeleteHowMany.Maximum = INITIAL_ITEM_COUNT_30
        numInsertHowMany.Maximum = INITIAL_ITEM_COUNT_30

        mod_managerVerticalOps = New DLLOperationsManager1D(Of TwoCharacterDLLVerticalA,
                DLLUserControlRichbox)(mod_firstItemA, mod_listA)

        ''Added 4/08/2025 thomas d.
        mod_managerVerticalOps.LoadParallelLists(GetParallelLists())   ''//, arrayOfParallelRanges)

        ''
        '' Display the list. 
        ''
        RefreshTheUI_DisplayList()
        ''Mar2025 RefreshTheUI_DisplayListB1(mod_listB1, mod_firstItemB1)
        RefreshTheUI_DisplayList_B1(mod_listB1, mod_firstItemB1)
        RefreshTheUI_DisplayList_B2(mod_listB2, mod_firstItemB2)
        RefreshTheUI_DisplayList_B3(mod_listB3, mod_firstItemB3)
        labelNumOperations.Text = mod_managerVerticalOps.ToString()

    End Sub ''End of ""Private Sub FormSimpleDemoOfCSharp1D_Load""



    Private Sub FormSimpleDemoOfCSharp1D_Load_NotUsed(sender As Object, e As EventArgs) ''3/22/2025 Handles MyBase.Load
        ''
        '' Added 10/14/2024 thomas c. downes 
        ''
        Dim newItemA As TwoCharacterDLLVerticalA
        Dim anchorItemForEmptyListA As New DLLAnchorItem_Deprecated(Of TwoCharacterDLLVerticalA)(True, False)
        Dim anchorItemForListOfOneItemA As DLLAnchorItem_Deprecated(Of TwoCharacterDLLVerticalA) ''(True, False)
        Dim anchorPairForEmptyListA As New DLLAnchorCouplet(Of TwoCharacterDLLVerticalA)(True, False)
        Dim anchorPairForListOfOneItemA As DLLAnchorCouplet(Of TwoCharacterDLLVerticalA) ''(True, False)
        ''Nov2024 Dim rangeNew As DLLRange(Of TwoCharacterDLLVerticalA)
        Dim indexNewItem As Integer
        ''Dim priorItem As TwoCharacterDLLVerticalA
        Dim type_of_move As StructureTypeOfMove ''Added 12/11/2024
        type_of_move = New StructureTypeOfMove(False) ''Added 12/11/2024

        ''Added 1/21/2025 td
        Dim newItemB1 As DLLUserControlRichbox
        Dim anchorItemForEmptyListB1 As New DLLAnchorItem_Deprecated(Of DLLUserControlRichbox)(True, False)
        Dim anchorItemForListOfOneItemB1 As DLLAnchorItem_Deprecated(Of DLLUserControlRichbox) ''(True, False)
        Dim anchorPairForEmptyListB1 As New DLLAnchorCouplet(Of DLLUserControlRichbox)(True, False)
        Dim anchorPairForListOfOneItemB1 As DLLAnchorCouplet(Of DLLUserControlRichbox) ''(True, False)

        ''Added 1/21/2025 td
        Dim newItemB2 As DLLUserControlRichbox
        Dim anchorItemForEmptyListB2 As New DLLAnchorItem_Deprecated(Of DLLUserControlRichbox)(True, False)
        Dim anchorItemForListOfOneItemB2 As DLLAnchorItem_Deprecated(Of DLLUserControlRichbox) ''(True, False)
        Dim anchorPairForEmptyListB2 As New DLLAnchorCouplet(Of DLLUserControlRichbox)(True, False)
        Dim anchorPairForListOfOneItemB2 As DLLAnchorCouplet(Of DLLUserControlRichbox) ''(True, False)

        ''Added 3/29/2025 td
        Dim newItemB3 As DLLUserControlRichbox
        Dim anchorItemForEmptyListB3 As New DLLAnchorItem_Deprecated(Of DLLUserControlRichbox)(True, False)
        Dim anchorItemForListOfOneItemB3 As DLLAnchorItem_Deprecated(Of DLLUserControlRichbox) ''(True, False)
        Dim anchorPairForEmptyListB3 As New DLLAnchorCouplet(Of DLLUserControlRichbox)(True, False)
        Dim anchorPairForListOfOneItemB3 As DLLAnchorCouplet(Of DLLUserControlRichbox) ''(True, False)

        Dim PERFORM_INITIAL_INSERT_MANUALLY As Boolean = False ''---True

        mod_firstItemA = New TwoCharacterDLLVerticalA("01")
        mod_lastItemA = mod_firstItemA
        mod_listA = New DLLList(Of TwoCharacterDLLVerticalA)(mod_firstItemA, mod_lastItemA, 1)
        ''Added 2/14/2025 thomas downes
        ''---mod_rangeA = New DLLRange(Of TwoCharacterDLLVerticalA)(mod_firstItemA, )

        ''Added 1/21/2025 td
        ''
        ''  Flow Container "Flow Column B1"
        ''
        FlowColumnB1.Controls.Clear()
        ''March 2025 mod_firstItemB1 = New DLLUserControlTextbox
        mod_firstItemB1 = New DLLUserControlRichbox
        mod_lastItemB1 = mod_firstItemB1
        ''March2025 mod_listB1 = New DLLList(Of DLLUserControlTextbox)(mod_firstItemB1, mod_lastItemB1, 1)
        mod_listB1 = New DLLList(Of DLLUserControlRichbox)(mod_firstItemB1, mod_lastItemB1, 1)

        ''Added 1/21/2025 td
        ''
        ''  Flow Container "Flow Column B2"
        ''
        FlowColumnB2.Controls.Clear()
        mod_firstItemB2 = New DLLUserControlRichbox
        mod_lastItemB2 = mod_firstItemB2
        mod_listB2 = New DLLList(Of DLLUserControlRichbox)(mod_firstItemB2, mod_lastItemB2, 1)

        ''//Added 10/21/2024 td
        anchorItemForListOfOneItemA = New DLLAnchorItem_Deprecated(Of TwoCharacterDLLVerticalA)(mod_firstItemA)
        ''Added 1/21/2025 td
        ''March 2025 anchorItemForListOfOneItemB1 = New DLLAnchorItem(Of DLLUserControlTextbox)(mod_firstItemB1)
        anchorItemForListOfOneItemB1 = New DLLAnchorItem_Deprecated(Of DLLUserControlRichbox)(mod_firstItemB1)
        anchorItemForListOfOneItemB2 = New DLLAnchorItem_Deprecated(Of DLLUserControlRichbox)(mod_firstItemB2)
        anchorItemForListOfOneItemB3 = New DLLAnchorItem_Deprecated(Of DLLUserControlRichbox)(mod_firstItemB3)

        ''//Added 11/08/2024 td
        anchorPairForListOfOneItemA = New DLLAnchorCouplet(Of TwoCharacterDLLVerticalA)(mod_firstItemA, Nothing, True)
        ''Added 1/21/2025 td
        anchorPairForListOfOneItemB1 = New DLLAnchorCouplet(Of DLLUserControlRichbox)(mod_firstItemB1, Nothing, True)
        anchorPairForListOfOneItemB2 = New DLLAnchorCouplet(Of DLLUserControlRichbox)(mod_firstItemB2, Nothing, True)
        anchorPairForListOfOneItemB3 = New DLLAnchorCouplet(Of DLLUserControlRichbox)(mod_firstItemB3, Nothing, True)

        ''//rangeNew = New DLLRange(Of TwoCharacterDLLVerticalA)(mod_firstItemA, True)
        ''//For indexNewItem = 2 To INITIAL_ITEM_COUNT_30 ''---30
        ''Nov2024 rangeNew = New DLLRange(Of TwoCharacterDLLVerticalA)(New TwoCharacterDLLVerticalA("02"), True)
        mod_rangeA = New DLLRange(Of TwoCharacterDLLVerticalA)(New TwoCharacterDLLVerticalA("01"), True)
        ''Added 1/21/2025 td
        mod_rangeB1 = New DLLRange(Of DLLUserControlRichbox)(New DLLUserControlRichbox("01"), True)
        mod_rangeB2 = New DLLRange(Of DLLUserControlRichbox)(New DLLUserControlRichbox("01"), True)
        mod_rangeB3 = New DLLRange(Of DLLUserControlRichbox)(New DLLUserControlRichbox("01"), True)

        ''Added 2/15/2025 thomas downes 
        FlowColumnB1.Controls.Clear()
        FlowColumnB1.Controls.Add(mod_rangeB1.ItemStart)

        ''Added 2/15/2025 thomas downes 
        FlowColumnB2.Controls.Clear()
        FlowColumnB2.Controls.Add(mod_rangeB2.ItemStart)

        ''Added 2/15/2025 thomas downes 
        FlowColumnB3.Controls.Clear()
        FlowColumnB3.Controls.Add(mod_rangeB3.ItemStart)

        ''Added 3/05/2025 td
        Dim arrayTwoCharStrings As String()
        ''Added 3/05/2025 td
        ReDim arrayTwoCharStrings(10)
        Dim strTwoChars As String
        Dim index_0based As Integer = 0

        ''
        '' Generate the three (3) ranges of newly-generated  items.
        ''
        ''Modified "(2 + 1)" on 11/8/2024 td
        For indexNewItem = (2 + 1) To INITIAL_ITEM_COUNT_30 ''---30
            ''
            '' Iteratively expand the three (3) ranges of newly-generated  items.
            ''
            strTwoChars = indexNewItem.ToString("00")
            arrayTwoCharStrings(index_0based) = strTwoChars

            ''TwoCharacterDLLVertical
            newItemA = New TwoCharacterDLLVerticalA(strTwoChars) ''Feb2025 (indexNewItem.ToString("00"))
            ''Nov2024 rangeNew.DLL_InsertItemToTheEnd(newItem)
            mod_rangeA.DLL_InsertItemToTheEnd(newItemA)

            ''DLLUserControlTextbox 
            newItemB1 = New DLLUserControlRichbox(strTwoChars) ''Feb2025 (indexNewItem.ToString("00"))
            mod_rangeB1.DLL_InsertItemToTheEnd(newItemB1)

            ''DLLUserControlRichbox 
            newItemB2 = New DLLUserControlRichbox(strTwoChars) ''Feb2025 (indexNewItem.ToString("00"))
            mod_rangeB2.DLL_InsertItemToTheEnd(newItemB2)

            ''DLLUserControlRichbox 
            newItemB3 = New DLLUserControlRichbox(strTwoChars) ''Feb2025 (indexNewItem.ToString("00"))
            mod_rangeB3.DLL_InsertItemToTheEnd(newItemB3)

            ''Added 3/5/2025 
            index_0based += 1

        Next indexNewItem

        ''
        '' added 12/30/2024 
        ''
        numDeleteHowMany.Maximum = INITIAL_ITEM_COUNT_30
        numInsertHowMany.Maximum = INITIAL_ITEM_COUNT_30

        Dim operationInitialInsertA As DLLOperation1D_Of(Of TwoCharacterDLLVerticalA)
        ''''Added 1/21/2025  
        ''Dim operationInitialInsertB1 As DLLOperation1D(Of DLLUserControlTextbox)
        ''Dim operationInitialInsertB2 As DLLOperation1D(Of DLLUserControlRichbox)

        ''
        '' Create the operation, or simply insert the range
        ''   without an operation.
        ''
        If (PERFORM_INITIAL_INSERT_MANUALLY) Then
            ''
            ''No DLLOperation object will be created.
            ''
            mod_listA.DLL_InsertRangeIntoEmptyList(mod_rangeA) ''(rangeNew)
            ''Added 1/21/2025 td
            mod_listB1.DLL_InsertRangeIntoEmptyList(mod_rangeB1) ''Added 1/21/2025 td
            mod_listB2.DLL_InsertRangeIntoEmptyList(mod_rangeB2) ''Added 1/21/2025 td

        Else
            ''
            ''Added 10/20/2024  
            ''
            ''See above. Dim operationInitialInsertA As DLLOperation1D(Of TwoCharacterDLLVerticalA)
            ''operationInitial30 = New DLLOperation1D(Of TwoCharacterDLLVerticalA)(rangeNew, True, False,
            ''            True, False, False,
            ''            anchorForEmptyList, False, False, False)
            operationInitialInsertA = New DLLOperation1D_Of(Of TwoCharacterDLLVerticalA)(mod_rangeA, True, False,
                                                                  True, False, False, type_of_move,
                                      anchorItemForListOfOneItemA,
                                      anchorPairForListOfOneItemA)
            ''12/30/2024                     False, False, False, False,
            ''12/30/2024                     Nothing, Nothing, Nothing)

            ''Added March 24, 2025
            ''
            '' It's important to get the index structure PRIOR to execution of the operation. 
            ''
            Dim operationInitialInsertA_Indices As DLLOperationIndexStructure
            operationInitialInsertA_Indices = operationInitialInsertA.GetOperationIndexStructure()

            ''12/16/2024 operationInitial30.OperateOnList(mod_listA)
            Dim byrefChangeOfEndpoint As Boolean ''Added 12/16/2024

            ''Major call!!
            operationInitialInsertA.OperateOnParentList(mod_listA, byrefChangeOfEndpoint)

            ''Added 10/20/2024  
            ''Removed 12/04/2024 mod_managerVerticalOps.= New DLLOperationsManager1D(Of TwoCharacterDLLVerticalA)(mod_firstItemA,
            ''      mod_listA, operationInitial30)
            ''March 2025  mod_managerVerticalOps.= New DLLOperationsManager1D(Of TwoCharacterDLLVerticalA)(mod_firstItemA, mod_listA)
            mod_managerVerticalOps = New DLLOperationsManager1D(Of TwoCharacterDLLVerticalA,
                DLLUserControlRichbox)(mod_firstItemA, mod_listA)

            ''
            ''Encapsulated 2/27/2025 td
            ''
            ''Feb2025  PropagateOperation_ToParallelLists(operationInitialInsertA)
            ''March25 2025  PropagateOperation_ToParallelLists(operationInitialInsertA, True, arrayTwoCharStrings)

            ''Added 3/25/2025 thomas downes
            PropagateOperation_ToParallelLists(operationInitialInsertA_Indices, True, arrayTwoCharStrings)

            ''''Added 1/21/2025  
            ''Dim operationInitialInsertB1 As DLLOperation1D(Of DLLUserControlTextbox)
            ''Dim operationInitialInsertB2 As DLLOperation1D(Of DLLUserControlRichbox)

            ''''Added 1/21/2025  
            ''''  This will hold the numeric skeleton of the initial insert operation. 
            ''Dim opInitialInsertIndexStruct As DLLOperationIndexStructure

            ''''Added 1/21/2025  
            ''opInitialInsertIndexStruct = operationInitialInsertA.GetOperationIndexStructure()

            ''''Added 2/14/2025  
            ''opInitialInsertIndexStruct.IsInsert_SoMustCreateNewItems = True

            ''''Modified to include the applicable insert ranges. 
            ''''    ---2/14/2025 td
            ''''
            ''operationInitialInsertB1 = New DLLOperation1D(Of DLLUserControlTextbox) _
            ''        (opInitialInsertIndexStruct, mod_firstItemB1, mod_rangeB1)
            ''operationInitialInsertB2 = New DLLOperation1D(Of DLLUserControlRichbox) _
            ''        (opInitialInsertIndexStruct, mod_firstItemB2, mod_rangeB2)

            ''''Added 1/21/2025  
            ''operationInitialInsertB1.OperateOnParentList(mod_listB1, byrefChangeOfEndpoint)
            ''operationInitialInsertB2.OperateOnParentList(mod_listB2, byrefChangeOfEndpoint)


        End If ''End of ""If (PERFORM_INITIAL_INSERT_MANUALLY) Then""  

        ''
        '' Display the list. 
        ''
        RefreshTheUI_DisplayList()
        ''---Encapsulated 2/26/25---RefreshTheUI_DisplayList(operationInitialInsertB1)
        ''---Encapsulated 2/26/25---RefreshTheUI_DisplayList(operationInitialInsertB2)

        ''Added 12/09/2024 
        ''  Make sure that the two boxes match in the beginning.
        ''----richtextBenchmark.Text = richtextItemsDisplay.Text

        ''Added 12/04/2024 
        labelNumOperations.Text = mod_managerVerticalOps.ToString()

    End Sub


    Private Sub PropagateOperation_ToParallelLists(par_operation As DLLOperationIndexStructure,
                      par_isInsert As Boolean, par_arrayOfTwoCharStrings() As String)
        ''Mar24 2025 Private Sub PropagateOperation_ToParallelLists(par_operation As DLLOperation1D(Of TwoCharacterDLLVerticalA),
        ''Mar24 2025     par_isInsert As Boolean, par_arrayOfTwoCharStrings() As String)
        ''
        ''Encapsulated 2/27/2025 td
        ''
        ''Added 1/21/2025  
        ''March 2025 Dim operationB1 As DLLOperation1D(Of DLLUserControlTextbox)
        Dim operationB1 As DLLOperation1D_Of(Of DLLUserControlRichbox)
        Dim operationB2 As DLLOperation1D_Of(Of DLLUserControlRichbox)
        Dim operationB3 As DLLOperation1D_Of(Of DLLUserControlRichbox)

        Dim byrefChangeOfEndpointB1 As Boolean ''Added 2/27/2025 td
        Dim byrefChangeOfEndpointB2 As Boolean ''Added 2/27/2025 td
        Dim byrefChangeOfEndpointB3 As Boolean ''Added 2/27/2025 td
        Dim strCurrentItem As String ''Added 3/14/2025 thomas d

        ''Added 1/21/2025  
        ''  This will hold the numeric skeleton of the initial insert operation. 
        ''
        'Mar24 2025     Dim opInitialInsertIndexStruct As DLLOperationIndexStructure
        Dim operationIndexStruct As DLLOperationIndexStructure

        ''Added 1/21/2025  
        ''Mar24 2025  opInitialInsertIndexStruct = par_operation.GetOperationIndexStructure()
        operationIndexStruct = par_operation

        ''Added 2/14/2025  
        ''Mar24 2025  opInitialInsertIndexStruct.IsInsert_SoMustCreateNewItems = True

        ''Added 3/5/2025 td
        Dim intHowManyInRange As Integer
        Const START_EMPTY As Boolean = True ''Added 3/14/2025
        ''March 2025  intHowManyInRange = opInitialInsertIndexStruct.IsInsert_InsertionCount
        intHowManyInRange = operationIndexStruct.IsInsert_InsertionCount
        ''March 2025  Dim dummyTextbox As New DLLUserControlTextbox("du") '' "du" = "dummy"
        Dim dummyRichbox As New DLLUserControlRichbox("du") '' "du" = "dummy"

        mod_rangeB1 = New DLLRange(Of DLLUserControlRichbox)(START_EMPTY, dummyRichbox) '' //TwoCharacterDLLVerticalB)()
        mod_rangeB2 = New DLLRange(Of DLLUserControlRichbox)(START_EMPTY, dummyRichbox) '' //TwoCharacterDLLVerticalB)()
        mod_rangeB3 = New DLLRange(Of DLLUserControlRichbox)(START_EMPTY, dummyRichbox) '' //TwoCharacterDLLVerticalB)()

        ''Added 3/5/2025 
        For index As Integer = 1 To intHowManyInRange
            ''
            ''Added 3/14/2025 td
            ''
            strCurrentItem = par_arrayOfTwoCharStrings(index Mod intHowManyInRange)
            ''---mod_rangeB1.ExtendRangeToIncludeListItem(New DLLUserControlTextbox(strCurrentItem))
            ''---mod_rangeB1.AddItemToTheEndOfRange(New DLLUserControlTextbox(strCurrentItem))
            mod_rangeB1.AddItemToTheEndOfRange_NewItem(New DLLUserControlRichbox(strCurrentItem))
            mod_rangeB2.AddItemToTheEndOfRange_NewItem(New DLLUserControlRichbox(strCurrentItem))
            mod_rangeB3.AddItemToTheEndOfRange_NewItem(New DLLUserControlRichbox(strCurrentItem))

        Next index

        ''Modified to include the applicable insert ranges. 
        ''    ---2/14/2025 td
        ''
        operationB1 = New DLLOperation1D_Of(Of DLLUserControlRichbox) _
                    (operationIndexStruct, mod_firstItemB1, mod_rangeB1)
        operationB2 = New DLLOperation1D_Of(Of DLLUserControlRichbox) _
                    (operationIndexStruct, mod_firstItemB2, mod_rangeB2)
        operationB3 = New DLLOperation1D_Of(Of DLLUserControlRichbox) _
                    (operationIndexStruct, mod_firstItemB3, mod_rangeB3)

        ''Added 1/21/2025  
        operationB1.OperateOnParentList(mod_listB1, byrefChangeOfEndpointB1)
        operationB2.OperateOnParentList(mod_listB2, byrefChangeOfEndpointB2)
        operationB3.OperateOnParentList(mod_listB3, byrefChangeOfEndpointB3)

        ''
        ''Propagate the change to the UI. 
        ''
        ''Apr20256  RefreshTheUI_DisplayList(operationB1)
        ''Apr20256  RefreshTheUI_DisplayList(operationB2)
        ''Apr20256  RefreshTheUI_DisplayList(operationB3)

        RefreshTheUI_DisplayList_B1(mod_listB1, mod_firstItemB1)
        RefreshTheUI_DisplayList_B2(mod_listB2, mod_firstItemB2)
        RefreshTheUI_DisplayList_B3(mod_listB3, mod_firstItemB3)


    End Sub ''End of ""Private Sub PropagateOperation_ToParallelLists()""


    Private Function TestingIndexStructure() As Boolean

        ''Added 1/15/2025 
        ''Return checkTestNumericConstructor.Checked

        ''April 2025  Return True
        Return False

    End Function ''/end of ""Private Function TestingIndexStructure() As Boolean""


    Private Sub RefreshTheUI_DisplayList(Optional par_operation As DLLOperation1D_Of(Of TwoCharacterDLLVerticalA) = Nothing)

        ''Added 12/18/2024  
        ''
        ''  This method is overloaded.  
        ''
        ''  Check for needed but missing updates to the variable mod_firstItemA.
        ''
        Dim bMismatch As Boolean
        bMismatch = (mod_listA._itemStart IsNot mod_firstItemA)
        If (bMismatch) Then System.Diagnostics.Debugger.Break()

        ''Added 12/18/2024  
        ''
        ''Major call!!
        ''
        RefreshTheUI_DisplayList(mod_listA, mod_firstItemA, par_operation)


    End Sub ''end of ""Private Sub RefreshTheUI_DisplayList""

    Private Sub RefreshTheUI_DisplayList(par_list As DLLList(Of TwoCharacterDLLVerticalA),
                                     par_firstItem As TwoCharacterDLLVerticalA,
                                     Optional par_operation As DLLOperation1D_Of(Of TwoCharacterDLLVerticalA) = Nothing)
        ''
        ''  This method is overloaded.  
        ''
        ''Added an optional parameter (par_operation) on 12/02/2024 
        ''
        ''Populate the UI. 
        Dim strListOfLinks As String

        ''Added 12/18/2024 td
        If (APPLICATION_DOEVENTS) Then Application.DoEvents() ''Seems to be needed.

        ''Major call!!
        strListOfLinks = StringToFillTheTextboxDisplayingList()
        ''----2025 richtextItemsDisplay.Text = strListOfLinks
        richtextItemsDisplay.Text = strListOfLinks

        ''Added 12/28/2023 
        Dim itemCount As Integer = mod_listA.DLL_CountAllItems()
        ''userControlOperation1.UpdateTheItemCount(itemCount)

        ''Added 1/04/202
        ''
        ''  Let's maintain the two(2) linklabels which represent
        ''    the list's endpoint & prior-to-endpoint.
        ''
        Dim last_item As TwoCharacterDLLVerticalA = Nothing
        Dim prior_to_last As TwoCharacterDLLVerticalA = Nothing

        last_item = CType(mod_listA.DLL_GetLastItem_OfT(), TwoCharacterDLLVerticalA)
        If (last_item Is Nothing) Then
            ''
            ''The user has elected to delete the entire list. 
            ''
        Else
            ''linkToEndpoint.Text = last_item.ToString()
            prior_to_last = CType(last_item.DLL_GetItemPrior(), TwoCharacterDLLVerticalA)
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
        ''---2025 RefreshHighlightingRichText(richtextBenchmark)
        ''---2025 RefreshHighlightingRichText(richtextItemsDisplay)

    End Sub ''End of ""Private Sub RefreshTheUI_DisplayList()""


    Private Function StringToFillTheTextboxDisplayingList() As String
        ''
        ''Added 12/26/2023  
        ''
        Dim each_twoChar As TwoCharacterDLLVerticalA
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

        If (mod_firstItemA Is Nothing) Then
            ''
            ''All the items have been deleted (most likely).
            ''
            Return "The list is empty."

        Else

            each_twoChar = mod_firstItemA

            ''For Each each_twoChar In mod_listA
            Do Until bDone

                intLoopIndex += 1
                charSpecial = " "c ''Added 12/09/2024 

                ''La belItemsDisplay.Text.Append(" +++ " + each_twoChar.ToString())
                ''stringbuilderLinkedItems.Append(" " + each_twoChar.ToString())
                If (each_twoChar.Selected Or bOpenSelection) Then
                    ''The item has been selected. 
                    charSpecial = "_"c ''Added 12/09/2024
                    stringbuilderLinkedItems.Append("_" + each_twoChar.ToString(False))

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
                        stringbuilderLinkedItems.Append("[" + each_twoChar.ToString(False))
                        ''Prepare for future iterations. 
                        boolOpenHighlight = False
                        boolCloseHighlight = True
                    ElseIf (boolCloseHighlight) Then
                        ''
                        ''Prepare for the next item(s).
                        ''
                        ''---stringbuilderLinkedItems.Append(" " + each_twoChar.ToString())
                        charSpecial = " "c ''Added 12/09/2024 
                        stringbuilderLinkedItems.Append(" " + each_twoChar.ToString(False))
                        boolCloseHighlight_Next = True
                        boolCloseHighlight = False
                        boolOpenHighlight = True
                    End If ''end of ""If (boolOpenHighlight) Then ... ElseIf..."

                ElseIf (boolCloseHighlight_Next) Then
                    ''Added 11/09/2024 thomas downes 
                    charSpecial = "]"c ''Added 12/09/2024 
                    stringbuilderLinkedItems.Append("]" + each_twoChar.ToString(False))
                    ''Clear the boolean, so it only is used once.
                    boolCloseHighlight_Next = False

                Else
                    ''Added 11/09/2024 thomas downes 
                    charSpecial = " "c ''Added 12/09/2024 
                    stringbuilderLinkedItems.Append(" " + each_twoChar.ToString(False))

                End If ''End of ""If (each_twoChar.Selected) Then... Else..."

                each_twoChar = each_twoChar.DLL_GetItemNext
                bDone = bDone Or (each_twoChar Is Nothing)
                intCountLoops += 1
                ''If (int CountLoops > 2 * 30) Then Debugger.Break()
                If (intCountLoops > 5 * INITIAL_ITEM_COUNT_30) Then Debugger.Break()

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


    ''Private Sub RefreshTheUI_DisplayList(par_operation As DLLOperation1D(Of DLLUserControlTextbox)) '' = Nothing)
    ''
    ''    ''Added 1/21/2025 
    ''    ''---RefreshTheUI_DisplayList(mod_listB1, mod_firstItemB1, par_operation)
    ''    RefreshTheUI_DisplayListB1(mod_listB1, mod_firstItemB1, par_operation)
    ''
    ''End Sub


    ''Private Sub RefreshTheUI_DisplayList(par_operation As DLLOperation1D(Of DLLUserControlRichbox)) '' = Nothing)
    ''
    ''    ''Added 1/21/2025 
    ''    ''---RefreshTheUI_DisplayList(mod_listB2, mod_firstItemB2, par_operation)
    ''    RefreshTheUI_DisplayList_B2(mod_listB2, mod_firstItemB2, par_operation)
    ''
    ''End Sub


    Private Sub RefreshTheUI_DisplayList_B1(par_list As DLLList(Of DLLUserControlRichbox),
                                     par_firstItem As DLLUserControlRichbox,
                                     Optional par_operation As DLLOperation1D_Of(Of DLLUserControlRichbox) = Nothing)
        ''
        ''  This method is overloaded.  
        ''
        Dim temp As DLLUserControlRichbox = par_firstItem
        Dim intCountNew As Integer = 0 ''Added 2/15/2025 thomas downes 

        FlowColumnB1.Controls.Clear()
        Do Until (temp Is Nothing)
            FlowColumnB1.Controls.Add(temp)
            temp.Visible = True ''Added 2/15/2025 thomas downes 
            intCountNew += 1 ''Added 2/15/2025 thomas downes
            temp = temp.DLL_GetItemNext_OfT()
        Loop

    End Sub ''---Private Sub RefreshTheUI_DisplayList_B1


    Private Sub RefreshTheUI_DisplayList_B2(par_list As DLLList(Of DLLUserControlRichbox),
                                     par_firstItem As DLLUserControlRichbox,
                                     Optional par_operation As DLLOperation1D_Of(Of DLLUserControlRichbox) = Nothing)
        ''
        ''  This method is overloaded.  
        ''
        Dim temp As DLLUserControlRichbox = par_firstItem
        Dim intCountNew As Integer = 0 ''Added 2/15/2025 thomas downes 

        FlowColumnB2.Controls.Clear()
        Do Until (temp Is Nothing)
            FlowColumnB2.Controls.Add(temp)
            temp.Visible = True ''Added 2/15/2025 thomas downes 
            intCountNew += 1 ''Added 2/15/2025 thomas downes
            temp = temp.DLL_GetItemNext_OfT()
        Loop

    End Sub ''---Private Sub RefreshTheUI_DisplayList_B3


    Private Sub RefreshTheUI_DisplayList_B3(par_list As DLLList(Of DLLUserControlRichbox),
                                     par_firstItem As DLLUserControlRichbox,
                                     Optional par_operation As DLLOperation1D_Of(Of DLLUserControlRichbox) = Nothing)
        ''
        ''  This method is overloaded.  
        ''
        Dim temp As DLLUserControlRichbox = par_firstItem
        Dim intCountNew As Integer = 0 ''Added 2/15/2025 thomas downes 

        FlowColumnB3.Controls.Clear()
        Do Until (temp Is Nothing)
            FlowColumnB3.Controls.Add(temp)
            temp.Visible = True ''Added 2/15/2025 thomas downes 
            intCountNew += 1 ''Added 2/15/2025 thomas downes
            temp = temp.DLL_GetItemNext_OfT()
        Loop

    End Sub ''---Private Sub RefreshTheUI_DisplayList_B3



    Private Sub RefreshHighlightingRichText(par_control As RichTextBox)
        ''
        ''Added 11/10/2024 thomas d.
        ''
        ''//Dim index As Integer
        Dim tempItem As TwoCharacterDLLVerticalA
        Dim boolHighlighting As Boolean
        Dim indexChar As Integer = 0
        Dim colorDefault As Color
        Dim intCountOfHighlightedItems As Integer = 0

        tempItem = mod_listA.DLL_GetFirstItem_OfT()
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
        bAllAreHighlighted = (intCountOfHighlightedItems >= mod_listA._itemCount - 1)

    End Sub ''End of ""Private Sub RefreshHighlightingRichText()""


    Private Sub AutoPopulateRangeControls(par_range As DLLRange(Of TwoCharacterDLLVerticalA))
        ''
        ''Added 11/12/2024 td
        ''
        Dim intRangeFirstIndex_b1 As Integer ''This is 1-based, hence the suffix "_b1".

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

        '' Added 12/023/2024 
        If (mod_firstItemA Is Nothing) Then


        End If ''End of ""If (mod_firstItemA Is Nothing) Then""


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
        intCountRedos = mod_managerVerticalOps.CountOfOperations_QueuedForRedo()

        bManagerHasRedosQueuedUp = mod_managerVerticalOps.AreOneOrMoreOpsToRedo_PerMarker()

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


    Private Sub MoveByShiftingRange(par_goLeft As Boolean, par_goRight As Boolean,
                                Optional par_iShiftDistance As Integer = 1)
        ''
        '' Encapsulated 12/11/2024 td  
        ''
        Dim tempOperation As DLLOperation1D_Of(Of TwoCharacterDLLVerticalA)
        Const OPERATION_MOVE = True
        ''Const ALLOW_NULLS As Boolean = True
        Dim bChangeOfEndpoint_Expected = False
        Dim bChangeOfEndpoint_Occurred = False ''Added 12/15/2024 td 
        Dim intHowManyToMove_RangeCount As Integer ''Added 12/10/2024 td
        Dim bCannotMoveThatMany As Boolean ''Added 12/10/2024 td 

        ''Added 12/01/2024 
        ''   Inform the user of any pending issues, prior to any operations. 
        Dim boolUserHasCancelled As Boolean ''Added 12/01/2024
        AdminToDoPriorToAnyOperation("Move", boolUserHasCancelled)
        If boolUserHasCancelled Then Exit Sub

        ''Added 12/10/2024 td 
        intHowManyToMove_RangeCount = mod_rangeA.GetItemCount

        ''Added 11/11/2024 thomas downes
        bCannotMoveThatMany = (intHowManyToMove_RangeCount >= mod_listA.DLL_CountAllItems)

        ''Added 11/11/2024 td
        If mod_listA._isEmpty_OrTreatAsEmpty Then

            ''Added 11/11/2024 td
            MessageBoxTD.Show_Statement("The list is empty, so no moves can logically take place.")
            Exit Sub

        ElseIf mod_rangeA.ContainsEndpoint(par_goLeft, par_goRight) Then

            ''Added 11/11/2024 td
            MessageBoxTD.Show_Statement("The range is at the edge, so no moves can logically take place.")
            Exit Sub

        ElseIf bCannotMoveThatMany Then

            ''Added 11/11/2024 td
            MessageBoxTD.Show_InsertWordFormat_Line1(mod_listA.DLL_CountAllItems,
                                             "The list is not long enough (less than {0} items), " +
                                "the requested number of items to move cannot take place.", )
            Exit Sub

        End If ''eNd of ""If (mod_listA._isEmpty_OrTreatAsEmpty) Then ... ElseIf... ""

        ''
        ''Build the correct Move Type.
        ''
        Dim intHowManyItemsToShift_Iterations As Integer ''Added 12/11/2024 td 
        Dim currentMoveType As New StructureTypeOfMove(True)

        ''intHowManyItemsToShift = IIf(par_goLeft, numericShiftLeft.Value, numericShiftRight.Value)
        intHowManyItemsToShift_Iterations = par_iShiftDistance

        currentMoveType.IsMoveIncrementalShift = True
        currentMoveType.IsShiftingToLeft = par_goLeft
        currentMoveType.IsShiftingToRight = par_goRight
        currentMoveType.HowManyItemsIncremental = intHowManyItemsToShift_Iterations
        currentMoveType.IsMoveToAnchor = False ''Added 12/15/2024 

        ''Added 4/08/2025 thomas d.
        mod_managerVerticalOps.LoadParallelLists(GetParallelLists())   ''//, arrayOfParallelRanges)

        ''
        '' Added 11/17/2024 thomas downes
        ''
        tempOperation = New DLLOperation1D_Of(Of TwoCharacterDLLVerticalA)(mod_rangeA, Nothing,
                               False, OPERATION_MOVE, currentMoveType)
        ''operation.OperateOnList(mod_listA)
        ''Mar2025 mod_managerVerticalOps.ProcessOperation_AnyType(tempOperation, bChangeOfEndpoint_Expected,
        ''   bChangeOfEndpoint_Occurred, True)
        mod_managerVerticalOps.ProcessOperation_AnyType(tempOperation, bChangeOfEndpoint_Expected,
         bChangeOfEndpoint_Occurred, True, tempOperation.GetOperationIndexStructure())

        ''Added 11/18/2024 
        ''---If bChangeOfEndpoint Then ''Modified 12/15/2024
        If (bChangeOfEndpoint_Expected Or bChangeOfEndpoint_Occurred) Then
            mod_firstItemA = mod_listA._itemStart
            ''Possibly unneeded. td 4/2025
            mod_lastItemA = mod_listA._itemEnding

            ''Added 4/2025 td
            mod_firstItemB1 = mod_listB1.DLL_GetFirstItem_OfT()
            mod_firstItemB2 = mod_listB2.DLL_GetFirstItem_OfT()
            mod_firstItemB3 = mod_listB3.DLL_GetFirstItem_OfT()

            ''Possibly unneeded. td 4/2025
            mod_lastItemB1 = mod_listB1.DLL_GetLastItem_OfT()
            mod_lastItemB2 = mod_listB2.DLL_GetLastItem_OfT()
            mod_lastItemB3 = mod_listB3.DLL_GetLastItem_OfT()

        End If ''End of ""If (bChangeOfEndpoint) Then""

        ''Added 11/17/2024 
        ''---RefreshTheUI_DisplayList()
        RefreshTheUI_DisplayList(mod_listA, mod_firstItemA)

        ''Added 4/2025 td
        RefreshTheUI_DisplayList_B1(mod_listB1, mod_firstItemB1)
        RefreshTheUI_DisplayList_B2(mod_listB2, mod_firstItemB2)
        RefreshTheUI_DisplayList_B3(mod_listB3, mod_firstItemB3)

        ''Added 11/29/2024 
        ''---labelNumOperations.Text = "Count of operations: " + mod_managerVerticalOps.HowManyOpsAreRecorded()
        ''Modified 12/01/2024
        ''Added 12/9/2024  labelNumOperations.Text = mod_managerVerticalOps.ToString()
        labelNumOperations.Text = mod_managerVerticalOps.ToString(tempOperation)

        ''Added 11/10/2024 
        buttonUndoLastStep.Enabled = True
        ''Added 11/29/2024 
        buttonUndoVertical.Enabled = True


    End Sub ''eND OF ""Private Sub MoveByShiftingRange""


    Private Sub AddDescriptionForOpByUser(param_operation As DLLOperation1D_2TypesInParallel(Of TwoCharacterDLLVerticalA, DLLUserControlRichbox))
        ''
        ''Added 11/3/2025 thomas d.
        ''
        If (chkAddOpDescriptions.Checked) Then

            param_operation.DescriptionByUser =
                MessageBoxTD.InputBox("Please enter a description for this Insert-Multiple operation:",
                                        "User Description for Operation")

        End If
        ''AddDescriptByUser(operation)

    End Sub ''Private Sub AddDescriptionForOpByUser


    Private Sub buttonInsertMulti_Click(sender As Object, e As EventArgs) Handles buttonInsertMultiple.Click
        ''
        '' Added 10/15/2024  
        ''
        Dim intInsertCountOfNewItems As Integer
        Dim intAnchorPosition As Integer
        Dim indexNewItem As Integer
        ''Nov2024 Dim objectRange As DLLRange(Of TwoCharacterDLLVerticalA)
        Dim prior_newItem As TwoCharacterDLLVerticalA
        Dim newItem As TwoCharacterDLLVerticalA
        Dim first_newItem As TwoCharacterDLLVerticalA
        Dim last_newItem As TwoCharacterDLLVerticalA
        Dim intHowManyInModuleList As Integer
        Dim intNewIndexStart As Integer
        Dim intNewIndexEnd As Integer
        Dim array_sItemsToInsert As String()
        Dim bUserSpecifiedValues
        Dim strNewItem As String
        Dim intModulo As Integer
        Dim boolEndpoint As Boolean
        Dim objAnchor As DLLAnchorItem_Deprecated(Of TwoCharacterDLLVerticalA)

        ''Added 12/01/2024 
        ''   Inform the user of any pending issues, prior to any operations. 
        Dim boolUserHasCancelled As Boolean ''Added 12/01/2024
        AdminToDoPriorToAnyOperation("Insert-Multi", boolUserHasCancelled)
        If (boolUserHasCancelled) Then Exit Sub

        intInsertCountOfNewItems = numInsertHowMany.Value
        intAnchorPosition = numInsertAnchorBenchmark.Value
        intHowManyInModuleList = mod_listA.DLL_CountAllItems
        boolEndpoint = intAnchorPosition = 1 Or intAnchorPosition = intHowManyInModuleList

        intNewIndexStart = 1 + intHowManyInModuleList
        intNewIndexEnd = intInsertCountOfNewItems + intHowManyInModuleList
        array_sItemsToInsert = textInsertListOfValuesCSV.Text.Split(New Char() {","c, " "c})
        bUserSpecifiedValues = array_sItemsToInsert.Count > 0

        For indexNewItem = intNewIndexStart To intNewIndexEnd

            ''//intModulo = indexNewItem Mod intInsertCount
            intModulo = (indexNewItem - intNewIndexStart) Mod array_sItemsToInsert.Length
            strNewItem = IIf(bUserSpecifiedValues, array_sItemsToInsert(intModulo),
                         indexNewItem.ToString("00"))
            If strNewItem.Length = 1 Then strNewItem = "=" & strNewItem
            newItem = New TwoCharacterDLLVerticalA(strNewItem)

            If first_newItem Is Nothing Then
                first_newItem = newItem
                mod_rangeA = New DLLRange(Of TwoCharacterDLLVerticalA)(True, Nothing, Nothing, first_newItem, 1)
            Else
                prior_newItem.DLL_SetItemNext(newItem)
                newItem.DLL_SetItemPrior(prior_newItem)
                mod_rangeA = New DLLRange(Of TwoCharacterDLLVerticalA)(True, Nothing, Nothing, first_newItem, 1)
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
        If intInsertCountOfNewItems = 1 Then
            mod_rangeA = New DLLRange(Of TwoCharacterDLLVerticalA)(first_newItem, True)
        Else
            ''
            '' There are at least two objects in the range. 
            ''
            mod_rangeA = New DLLRange(Of TwoCharacterDLLVerticalA)(False, first_newItem,
                                                           last_newItem, Nothing,
                                                           intInsertCountOfNewItems)

        End If ''End of ""If (intInsertCountOfNewItems = 1) Then... Else..."

        ''
        ''Set the anchor. 
        ''
        Dim tempAnchorItem As TwoCharacterDLLVerticalA ''Added 10/21/2024 td

        If (mod_firstItemA Is Nothing) Then

            ''Added 12/23/2024
            Const EMPTY As Boolean = True
            objAnchor = New DLLAnchorItem_Deprecated(Of TwoCharacterDLLVerticalA)(EMPTY, False)

        Else
            tempAnchorItem = mod_firstItemA.DLL_GetItemNext(-1 + intAnchorPosition)
            objAnchor = New DLLAnchorItem_Deprecated(Of TwoCharacterDLLVerticalA)(tempAnchorItem)

        End If ''End of ""If (mod_firstItemA Is Nothing) Then... Else..."

        With objAnchor
            ''._anchorItem = mod_firstItemA.DLL_GetItemNext(-1 + intAnchorPosition)
            ._doInsertRangeAfterThis = listInsertAfterOrBefore.SelectedIndex < 1
            ._doInsertRangeBeforeThis = False = objAnchor._doInsertRangeAfterThis
        End With

        ''Highlight the range's endpoints.
        mod_rangeA.HighlightEndpoints_Green()
        mod_rangeA.HighlightEndpoints_Cyan()

        ''
        '' Insert range into the list.  
        ''
        Const DIRECT_TO_LIST = False ''Added 10/26/2024 thom dow.nes
        ''--Const INSERT_OPERATION = True '' False ''Added 10/26/2024 thomas downes
        Dim USE_OP_MANAGER = Not DIRECT_TO_LIST ''Added 11/06/2024 thom dow.nes
        Dim anchor_couple As DLLAnchorCouplet(Of TwoCharacterDLLVerticalA)
        Dim operation As DLLOperation1D_Of(Of TwoCharacterDLLVerticalA)
        ''Dim bChangeOfEndpoint As Boolean ''Added 11/06/2024 
        Dim bChangeOfEndpoint_Expected As Boolean ''Added 11/06/2024 
        Dim bChangeOfEndpoint_PostHoc As Boolean ''Added 11/06/2024 
        Dim null_move As New StructureTypeOfMove(False) ''Added 12/11/2024 td

        ''Added 4/08/2025 thomas d.
        Dim stringTwoChars As String = textInsertListOfValuesCSV.Text.Substring(0, 2)
        Dim arrayOfParallelRanges As DLLRange(Of DLLUserControlRichbox)() ''Added 4/08/2025 thomas d.
        Dim intCountOfParallelLists As Integer = GetParallelLists_Count()

        ''Added 4/08/2025 thomas d.
        arrayOfParallelRanges = GetParallelRangesOfNewItems(intCountOfParallelLists,
                                                intInsertCountOfNewItems,
                                                stringTwoChars)

        If DIRECT_TO_LIST Then
            If listInsertAfterOrBefore.SelectedIndex < 1 Then
                mod_listA.DLL_InsertRangeAfter(mod_rangeA, objAnchor._anchorItem) ''; ''---, boolEndpoint)
            Else
                mod_listA.DLL_InsertRangeBefore(mod_rangeA, objAnchor._anchorItem) ''; ''---, boolEndpoint)
            End If

        ElseIf USE_OP_MANAGER And listInsertAfterOrBefore.SelectedIndex < 1 Then
            ''
            ''Added 11/06/2024 td  
            ''
            ''---bChangeOfEndpoint = objectRange.ContainsEndpoint()
            ''anchor_couple = New DLLAnchorCouplet(Of TwoCharacterDLLVerticalA)(tempAnchorItem,
            ''  tempAnchorItem.DLL_GetItemNext_OfT(), bChangeOfEndpoint)
            anchor_couple = New DLLAnchorCouplet(Of TwoCharacterDLLVerticalA)(tempAnchorItem,
                                        tempAnchorItem.DLL_GetItemNext_OfT,
                                        tempAnchorItem.DLL_IsEitherEndpoint)
            ''Added 12/11/2024 operation = New DLLOperation1D(Of TwoCharacterDLLVerticalA)(mod_range, anchor_couple, True, False)
            operation = New DLLOperation1D_Of(Of TwoCharacterDLLVerticalA)(mod_rangeA, anchor_couple, True, False, null_move)

            ''Added 1/13/2025 td
            ''
            ''   Should we test the new Struct, DLLOperationStructure?
            ''
            If (TestingIndexStructure()) Then
                ''
                ''To test DLLOperationStructure, and the corresponding DLLOperation1D (Of T) constructor,
                ''   we need to create a DLLOperationStructure object, and then pass it to the constructor.
                ''   ---1/13/2025 td
                ''
                Dim op_structure As DLLOperationIndexStructure ''DLLOperation1D(Of TwoCharacterDLLVerticalA)
                op_structure = operation.GetOperationIndexStructure()
                ''Feb2025 operation = New DLLOperation1D(Of TwoCharacterDLLVerticalA)(op_structure, mod_listA.DLL_GetFirstItem_OfT())
                operation = New DLLOperation1D_Of(Of TwoCharacterDLLVerticalA)(op_structure,
                                                                            mod_listA.DLL_GetFirstItem_OfT(),
                                                                            mod_rangeA)

            End If ''End of ""If (TestingIndexStructure()) Then""

            ''operation.OperateOnList(mod_listA)
            ''//mod_manager.ProcessOperation_AnyType(operation, bChangeOfEndpoint, True)
            ''Mar2025  mod_managerVerticalOps.ProcessOperation_AnyType(operation, bChangeOfEndpoint_Expected,
            ''   bChangeOfEndpoint_PostHoc, True)

            ''Added 4/08/2025 thomas d.
            mod_managerVerticalOps.LoadParallelLists(GetParallelLists(), arrayOfParallelRanges)

            ''Added 11/03/2025 td 
            ''If (chkAddOpDescriptions.Checked) Then
            ''    operation.DescriptionByUser =
            ''        MessageBoxTD.InputBox("Please enter a description for this Insert-Multiple operation:",
            ''                                "User Description for Operation")
            ''End If
            AddDescriptionForOpByUser(operation)

            ''
            '' Major call!!
            ''
            mod_managerVerticalOps.ProcessOperation_AnyType(operation, bChangeOfEndpoint_Expected,
                   bChangeOfEndpoint_PostHoc, True, operation.GetOperationIndexStructure())

            ''Added November 2025 
            mod_managerVerticalOps.CheckTermination()


        ElseIf USE_OP_MANAGER And listInsertAfterOrBefore.SelectedIndex >= 1 Then
            ''
            ''Added 11/06/2024 td  
            ''
            ''---bChangeOfEndpoint = objectRange.ContainsEndpoint()
            anchor_couple = New DLLAnchorCouplet(Of TwoCharacterDLLVerticalA)(
                                        tempAnchorItem.DLL_GetItemPrior_OfT, tempAnchorItem,
                                        tempAnchorItem.DLL_IsEitherEndpoint)
            operation = New DLLOperation1D_Of(Of TwoCharacterDLLVerticalA)(mod_rangeA, anchor_couple,
                                   True, False, null_move)

            ''Added 4/08/2025 thomas d.
            mod_managerVerticalOps.LoadParallelLists(GetParallelLists(), arrayOfParallelRanges)

            ''operation.OperateOnList(mod_listA)
            ''//mod_manager.ProcessOperation_AnyType(operation, bChangeOfEndpoint, True)
            ''Mar2025  mod_managerVerticalOps.ProcessOperation_AnyType(operation, bChangeOfEndpoint_Expected,
            ''           bChangeOfEndpoint_PostHoc, True)
            mod_managerVerticalOps.ProcessOperation_AnyType(operation, bChangeOfEndpoint_Expected,
                  bChangeOfEndpoint_PostHoc, True, operation.GetOperationIndexStructure())

        End If ''End of ""If (DIRECT_TO_LIST) Then... Else..."

        ''
        '' Added 11/11/2024 
        ''
        ''//If bChangeOfEndpoint Then
        If bChangeOfEndpoint_Expected Or bChangeOfEndpoint_PostHoc Then

            mod_firstItemA = mod_listA._itemStart
            mod_lastItemA = mod_listA._itemEnding

            mod_firstItemB1 = mod_listB1.DLL_GetFirstItem_OfT()
            mod_firstItemB2 = mod_listB2.DLL_GetFirstItem_OfT()
            mod_firstItemB3 = mod_listB3.DLL_GetFirstItem_OfT()

            mod_lastItemB1 = mod_listB1.DLL_GetLastItem_OfT()
            mod_lastItemB2 = mod_listB2.DLL_GetLastItem_OfT()
            mod_lastItemB3 = mod_listB3.DLL_GetLastItem_OfT()

        End If ''End of ""If (bChangeOfEndpoint) Then""

        ''
        '' Display the list. 
        ''
        ''--RefreshTheUI_DisplayList()
        RefreshTheUI_DisplayList() '' (operation)

        ''Added 4/08/2025 td
        RefreshTheUI_DisplayList_B1(mod_listB1, mod_firstItemB1)
        RefreshTheUI_DisplayList_B2(mod_listB2, mod_firstItemB2)
        RefreshTheUI_DisplayList_B3(mod_listB3, mod_firstItemB3)

        ''Remove the highlighting of the range's endpoints.
        mod_rangeA.HighlightEndpoints_Green(False)
        mod_rangeA.HighlightEndpoints_Cyan(False)

        ''Added 11/10/2024 
        buttonUndoLastStep.Enabled = True
        ''Added 11/29/2024 
        buttonUndoVertical.Enabled = True

        ''Added 11/29/2024 
        ''---labelNumOperations.Text = "Count of operations: " + mod_managerVerticalOps.HowManyOpsAreRecorded()
        ''Modified 12/01/2024
        ''Modified 12/02/2024  labelNumOperations.Text = mod_managerVerticalOps.ToString()
        labelNumOperations.Text = mod_managerVerticalOps.ToString(operation)

    End Sub

    Private Sub buttonInsertSingle_Click(sender As Object, e As EventArgs) Handles buttonInsertSingle.Click

        ''
        '' Insert range into the list.  
        ''
        Dim objAnchorItem As DLLAnchorItem_Deprecated(Of TwoCharacterDLLVerticalA)
        Dim objAnchorPair As DLLAnchorCouplet(Of TwoCharacterDLLVerticalA) ''Added 11/08/2024
        Dim intAnchorPosition As Integer
        ''Dim boolEndpoint As Boolean
        Dim bChangeOfEndpoint As Boolean
        Dim bChangeOfEndpoint_Expected As Boolean
        Dim bChangeOfEndpoint_Occurred As Boolean
        Dim array_sItemsToInsert As String()
        Dim bUserSpecifiedValues
        Dim strNewItem As String
        Dim intHowManyInModuleList As Integer
        Dim newItem As TwoCharacterDLLVerticalA
        Const ZERO_INDEX = 0
        Dim bInsertRangeAfterAnchor As Boolean
        Dim bInsertRangeBeforeAnchor As Boolean
        Dim tempAnchorItem As TwoCharacterDLLVerticalA '''Added 10/21/2024 thomas downes
        Dim operationToInsert As DLLOperation1D_Of(Of TwoCharacterDLLVerticalA) ''Added 10/26/2024
        Dim rangeSingleItem As DLLRange(Of TwoCharacterDLLVerticalA) ''Added 10/26/2024 td 
        Dim boolIsForEmptyList As Boolean ''Added 12/09/2024 thomas d. 
        Dim not_a_moveType As StructureTypeOfMove = New StructureTypeOfMove(False) ''Added 12/11/2024

        ''Added 12/01/2024 
        ''   Inform the user of any pending issues, prior to any operations. 
        Dim boolUserHasCancelled As Boolean ''Added 12/01/2024
        AdminToDoPriorToAnyOperation("Insert-Single", boolUserHasCancelled)
        If (boolUserHasCancelled) Then Exit Sub

        ''Added 12/08/2024
        mod_managerVerticalOps.ClearAnyRedoOperations_IfQueued()

        array_sItemsToInsert = textInsertListOfValuesCSV.Text.Split(ARRAY_OF_DELIMITERS)
        intHowManyInModuleList = mod_listA.DLL_CountAllItems
        bUserSpecifiedValues = array_sItemsToInsert.Count > 0
        ''intInsertCount = numInsertHowMany.Value
        intAnchorPosition = numInsertAnchorBenchmark.Value

        ''
        ''Set the anchor. 
        ''
        ''----objAnchor = New DLLAnchor(Of TwoCharacterDLLVerticalA)(False)
        ''----objAnchor._anchorItem = mod_firstItemA.DLL_GetItemNext(-1 + intAnchorPosition)
        If (mod_firstItemA Is Nothing) Then
            ''The list is empty. 
            ''   No items exist in the list.  ---12/09/2024 td  
            boolIsForEmptyList = True ''Added 12/09/2024
            If (mod_listA.DLL_IsEmpty() = False) Then System.Diagnostics.Debugger.Break()
            objAnchorItem = New DLLAnchorItem_Deprecated(Of TwoCharacterDLLVerticalA)(boolIsForEmptyList, False) '' (True, False)

        Else
            tempAnchorItem = mod_firstItemA.DLL_GetItemNext(-1 + intAnchorPosition)
            objAnchorItem = New DLLAnchorItem_Deprecated(Of TwoCharacterDLLVerticalA)(tempAnchorItem)
        End If ''End of ""If (mod_firstItemA Is Nothing) Then ... Else ..."

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
        newItem = New TwoCharacterDLLVerticalA(strNewItem)

        ''---mod_listA.DLL_InsertSingly(newItem, objAnchor, boolEndpoint)
        Const KEEP_ANCHOR = True
        ''
        ''What does DLL_SetAnchor() do?  
        ''
        mod_listA.DLL_SetAnchor(objAnchorItem, bInsertRangeBeforeAnchor, bInsertRangeAfterAnchor,
          KEEP_ANCHOR)

        ''
        ''Major work!! 
        ''
        Const DIRECT_TO_LIST = False ''Added 10/26/2024 thom dow.nes
        Const INSERT_OPERATION = True '' False ''Added 10/26/2024 thomas downes

        If DIRECT_TO_LIST Then
            ''Without using the DLLManager class, directly editing the list.  
            ''12/17 mod_listA.DLL_InsertItemSingly(newItem, boolEndpoint)
            mod_listA.DLL_InsertItemSingly(newItem, bChangeOfEndpoint_Expected)

        Else
            ''
            '' Added 10/26/2024 thomas d.
            ''
            rangeSingleItem = New DLLRange(Of TwoCharacterDLLVerticalA)(newItem, True)
            operationToInsert = New DLLOperation1D_Of(Of TwoCharacterDLLVerticalA)(rangeSingleItem, False, False,
                                    INSERT_OPERATION, False, False, not_a_moveType,
                                  objAnchorItem, objAnchorPair)
            ''12/30/2024                          False, False, False, False,
            ''12/30/2024                           Nothing, Nothing, Nothing)

            ''Added 3/25/2025
            Dim operationToInsert_Indices = operationToInsert.GetOperationIndexStructure()

            ''Added 4/08/2025 thomas d.
            Dim stringTwoChars As String = textInsertListOfValuesCSV.Text.Substring(0, 2)
            Dim arrayOfParallelRanges As DLLRange(Of DLLUserControlRichbox)() ''Added 4/08/2025 thomas d.
            Dim intCountOfParallelLists As Integer = GetParallelLists_Count()
            Dim intInsertCountOfNewItems As Integer = 1

            ''Added 4/08/2025 thomas d.
            arrayOfParallelRanges = GetParallelRangesOfNewItems(intCountOfParallelLists,
                                                intInsertCountOfNewItems,
                                                stringTwoChars)

            ''Added 4/08/2025 thomas d.
            mod_managerVerticalOps.LoadParallelLists(GetParallelLists(), arrayOfParallelRanges)

            ''mod_manager.ProcessOperation_AnyType(operationToInsert, boolEndpoint, True)
            mod_managerVerticalOps.ProcessOperation_AnyType(operationToInsert, bChangeOfEndpoint_Expected,
                                             bChangeOfEndpoint_Occurred, True,
                                             operationToInsert_Indices)

            ''
            ''Added 2/27/2025 td
            ''
            ''Feb2025  PropagateOperation_ToParallelLists(operationToInsert)
            ''Mar2025  PropagateOperation_ToParallelLists(operationToInsert, True, array_sItemsToInsert)
            PropagateOperation_ToParallelLists(operationToInsert_Indices, True, array_sItemsToInsert)

        End If ''End of ""If (DIRECT_TO_LIST) Then ... Else ..."

        ''Added 11/10/2024 td
        My.Application.DoEvents()

        ''Added 12/17/2024 
        bChangeOfEndpoint = (bChangeOfEndpoint_Expected Or bChangeOfEndpoint_Occurred Or bChangeOfEndpoint)

        ''Added 11/10/2024 td
        If (bChangeOfEndpoint) Then ''If boolEndpoint Then
            mod_firstItemA = mod_listA.DLL_GetFirstItem_OfT()
            mod_lastItemA = mod_listA.DLL_GetLastItem_OfT()

            ''Added 4/08/2025
            mod_firstItemB1 = mod_listB1.DLL_GetFirstItem_OfT()
            mod_firstItemB2 = mod_listB2.DLL_GetFirstItem_OfT()
            mod_firstItemB3 = mod_listB3.DLL_GetFirstItem_OfT()

            ''Added 4/08/2025
            mod_lastItemB1 = mod_listB1.DLL_GetLastItem_OfT()
            mod_lastItemB2 = mod_listB2.DLL_GetLastItem_OfT()
            mod_lastItemB3 = mod_listB3.DLL_GetLastItem_OfT()

        End If ''eND OF ""If (boolEndpoint) Then""

        ''
        ''Added 10/20/2024
        ''
        RefreshTheUI_DisplayList()

        ''Added 4/08/2025 
        RefreshTheUI_DisplayList_B1(mod_listB1, mod_firstItemB1)
        RefreshTheUI_DisplayList_B2(mod_listB2, mod_firstItemB2)
        RefreshTheUI_DisplayList_B3(mod_listB3, mod_firstItemB3)

        ''Remove the highlighting of the range's endpoints.
        If rangeSingleItem IsNot Nothing Then
            rangeSingleItem.HighlightEndpoints_Green(False)
            rangeSingleItem.HighlightEndpoints_Cyan(False)
        End If ''End of " If (rangeSingleItem IsNot Nothing) Then"

        ''Added 11/09/2024
        ''  These two(2) lines are probably not needed. 
        buttonRedoOp.Enabled = mod_managerVerticalOps.MarkerHasOperationNext_Redo()
        buttonRedoVertical.Enabled = mod_managerVerticalOps.MarkerHasOperationNext_Redo()

        ''Added 11/10/2024 
        buttonUndoLastStep.Enabled = mod_managerVerticalOps.MarkerHasOperationPrior_Undo()
        buttonUndoVertical.Enabled = mod_managerVerticalOps.MarkerHasOperationPrior_Undo()

        ''Added 11/29/2024 
        ''---labelNumOperations.Text = "Count of operations: " + mod_managerVerticalOps.HowManyOpsAreRecorded()
        ''Modified 12/01/2024
        labelNumOperations.Text = mod_managerVerticalOps.ToString()

    End Sub ''End of Private Sub buttonInsertSingle_Click() 


    Private Sub labelItems_MouseUp(sender As Object, e As MouseEventArgs) ''---2025 Handles labelItemsDisplay.MouseUp
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
        Dim objectListItem As TwoCharacterDLLVerticalA
        Dim bShiftingKey As Boolean ''Added 2/29/2024
        Dim xfactor_a As Double ''Added 2/29/2024
        ''Now modularized. ''Static s_range As DLLRange(Of TwoCharacterDLLVerticalA)
        Dim intDistance As Integer ''Added 11/12/2024 

        xfactor_a = xfactor_a4
        x_intPixelPosition = e.Location.X
        ax_double = xfactor_a * x_intPixelPosition
        index_of_item_double = ax_double + constant_b
        index_of_item = Math.Floor(index_of_item_double)
        ''Added 12/15/2024 
        ''   Prevent the selector from going beyond the item count.
        index_of_item = IIf(index_of_item <= -1 + mod_listA._itemCount,
                        index_of_item, -1 + mod_listA._itemCount)

        ''Added 2/29/2024
        bShiftingKey = Control.ModifierKeys = Keys.Shift

        Const ENCAPSULATE = True ''Added 2/29/2024
        If ENCAPSULATE Then ''Added 2/29/2024

            ''Added 2/29/2024
            ''//mod_listA.SelectionRange_ProcessList_GetTuple(index_of_item, bShiftingKey)
            mod_rangeA = mod_listA.GetSelectionRange_Base1(index_of_item, bShiftingKey)

            ''Added 11/14/2024
            ''---objectListItem = mod_listA.DLL_GetItemAtIndex(index_of_item)
            objectListItem = mod_listA.DLL_GetItemAtIndex_1based(1 + index_of_item)
            ''Added 11/5/2024
            ''See above called to mod_listA.SelectionRange...  ''--objectListItem.Selected = True

        Else
            ''Added 2/27/2024
            If index_of_item > -1 + mod_listA.DLL_CountAllItems Then Exit Sub
            ''---objectListItem = mod_listA.DLL_GetItemAtIndex(index_of_item)
            objectListItem = mod_listA.DLL_GetItemAtIndex_1based(index_of_item)
            ''--objectListItem.Selected = True
            objectListItem.Selected = Not objectListItem.Selected ''Toggle the value. ''True

        End If ''eND OF ""If (ENCAPSULATE) Then... Else..."

        ''Added 2/27/2024 
        RefreshTheUI_DisplayList()

        '''Highlight the range's endpoints.
        ''--objectRange.HighlightEndpoints_Green()'

        If objectListItem Is Nothing Then
            ''
            ''Do nothing. 
            ''
        ElseIf mod_rangeA Is Nothing And objectListItem.Selected = True Then
            ''
            ''Start a range object. 
            ''
            mod_rangeA = New DLLRange(Of TwoCharacterDLLVerticalA)(objectListItem, False)

        ElseIf mod_rangeA IsNot Nothing And objectListItem.Selected Then

            intDistance = mod_rangeA._StartingItemOfRange.DLL_GetDistanceTo(objectListItem)

            If intDistance > 0 Then
                ''The range should be broadened to reach the newly-selected object. 
                mod_rangeA.ExtendRangeToIncludeListItem(objectListItem)

            ElseIf intDistance < 0 Then
                ''
                '' Since the distance is negative, the range should be re-initiated,
                ''   with newly-selected object being the "lefthand" (starting) item 
                ''   of the range, and the previously-selected item should be the 
                ''   "righthand" (following/ending) item. 
                ''
                Dim tempRangeItem = mod_rangeA.ItemStart
                mod_rangeA = New DLLRange(Of TwoCharacterDLLVerticalA)(objectListItem, tempRangeItem)

            End If ''ENd of ""If (intDistance > 0) Then ... Else If (intDistance < 0) Then"

        End If ''end of ""If (objectListItem Is Nothing) Then... ElseIf... ElseIf..."

        ''
        ''Major call!! 
        ''
        Const MOVE_CONTROLS_ENABLED = True
        If MOVE_CONTROLS_ENABLED And mod_rangeA IsNot Nothing Then
            ''Important for MOVE controls. 
            AutoPopulateRangeControls(mod_rangeA)
        End If ''ENd of ""If (s_range IsNot Nothing) Then""

    End Sub ''End of ""Private Sub labelBenchmark_MouseUp""


    Private Sub buttonUndoLastStep_Click(sender As Object, e As EventArgs) Handles buttonUndoLastStep.Click
        ''
        ''Added 10/16/2024
        ''
        Dim bEndpointAffected As Boolean ''Added 11/10/2024 td
        Dim bTestingIndexStructure As Boolean ''Added 1/14/2025 td

        ''Added 1/14/2025 td
        bTestingIndexStructure = TestingIndexStructure() ''---2025 checkTestNumericConstructor.Checked

        ''Nov10 2024 ''mod_manager.UndoMarkedOperation()
        mod_managerVerticalOps.UndoMarkedOperation(bEndpointAffected, bTestingIndexStructure)

        ''Added 11/10/2024 
        mod_firstItemA = mod_listA.DLL_GetFirstItem_OfT()
        mod_lastItemA = mod_listA.DLL_GetLastItem_OfT()

        ''Added 4/14/2025 td
        mod_firstItemB1 = mod_listB1.DLL_GetFirstItem_OfT()
        mod_firstItemB2 = mod_listB2.DLL_GetFirstItem_OfT()
        mod_firstItemB3 = mod_listB3.DLL_GetFirstItem_OfT()

        ''Added 10/27/2024 
        RefreshTheUI_DisplayList()

        ''Added 4/14/2025 td
        RefreshTheUI_DisplayList_B1(mod_listB1, mod_firstItemB1)
        RefreshTheUI_DisplayList_B2(mod_listB2, mod_firstItemB2)
        RefreshTheUI_DisplayList_B3(mod_listB3, mod_firstItemB3)

        ''Added 11/09/2024
        buttonRedoOp.Enabled = True
        buttonRedoVertical.Enabled = True

        ''Added 11/10/2024 
        buttonUndoLastStep.Enabled = mod_managerVerticalOps.MarkerHasOperationPrior_Undo()
        buttonUndoVertical.Enabled = mod_managerVerticalOps.MarkerHasOperationPrior_Undo()

        ''Added 12/04/2024 
        labelNumOperations.Text = mod_managerVerticalOps.ToString()

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
        Const SORT_UNDO As Boolean = False

        Dim intItemPosition As Integer
        Dim intHowManyToDelete As Integer
        Dim itemFirstToDelete As TwoCharacterDLLVerticalA
        Dim itemLastToDelete As TwoCharacterDLLVerticalA
        Dim rangeToDelete As DLLRange(Of TwoCharacterDLLVerticalA)
        Dim operationToDelete As DLLOperation1D_Of(Of TwoCharacterDLLVerticalA)
        Dim bIncludesListStart As Boolean ''Added 11/10/2024 
        Dim bIncludesList__End As Boolean ''Added 11/10/2024 
        Dim bAnyEndpointAffected As Boolean ''Added 11/11/2024 td
        Dim bAnyEndpointAffected_start As Boolean ''Added 11/11/2024 td
        Dim bAnyEndpointAffected_end As Boolean ''Added 11/11/2024 td
        Dim bAnyEndpointAffected_ByRef As Boolean ''Added 11/11/2024 td
        Dim bCannotDeleteThatMany As Boolean ''Added 11/11/2024 td
        Dim not_a_moveType As StructureTypeOfMove = New StructureTypeOfMove(False) ''Added 12/11/2024 
        Dim operationIndicized As DLLOperationIndexStructure ''Added 3/26/2025

        ''Added 12/01/2024 
        ''   Inform the user of any pending issues, prior to any operations. 
        Dim boolUserHasCancelled As Boolean ''Added 12/01/2024
        AdminToDoPriorToAnyOperation("Delete", boolUserHasCancelled)
        If (boolUserHasCancelled) Then Exit Sub

        ''Added 12/08/2024
        mod_managerVerticalOps.ClearAnyRedoOperations_IfQueued()

        intItemPosition = numDeleteRangeBenchmarkStart.Value
        intHowManyToDelete = numDeleteHowMany.Value

        ''Added 11/11/2024 thomas downes
        bCannotDeleteThatMany = (-1 + intItemPosition + intHowManyToDelete > mod_listA._itemCount)

        ''Added 11/11/2024 td
        If (mod_listA._isEmpty_OrTreatAsEmpty) Then
            ''Added 11/11/2024 td
            MessageBoxTD.Show_Statement("The list is empty, so no deletions can logically take place.")
            Exit Sub
        ElseIf (bCannotDeleteThatMany) Then
            ''Added 11/11/2024 td
            MessageBoxTD.Show_InsertWordFormat_Line1(-1 + intItemPosition + intHowManyToDelete,
                                                 "The list is not long enough (less than {0} items), " +
                                    "the requested number of deleted consecutive items cannot take place.", )
            Exit Sub
        End If ''eNd of ""If (mod_listA._isEmpty_OrTreatAsEmpty) Then""

        ''
        ''Set the anchor. 
        ''
        ''----objAnchor = New DLLAnchor(Of TwoCharacterDLLVerticalA)(False)
        ''----objAnchor._anchorItem = mod_firstItemA.DLL_GetItemNext(-1 + intAnchorPosition)
        itemFirstToDelete = mod_firstItemA.DLL_GetItemNext(-1 + intItemPosition)
        itemLastToDelete = mod_firstItemA.DLL_GetItemNext(-1 + intItemPosition + intHowManyToDelete - 1)

        bAnyEndpointAffected_start = (intItemPosition = 1)
        bAnyEndpointAffected_end = ((intItemPosition + intHowManyToDelete - 1) >= mod_listA._itemCount)
        bAnyEndpointAffected = (bAnyEndpointAffected_start Or bAnyEndpointAffected_end)

        rangeToDelete = New DLLRange(Of TwoCharacterDLLVerticalA)(False, itemFirstToDelete,
                                         itemLastToDelete, Nothing, intHowManyToDelete)

        If (DIRECT_TO_LIST_Not) Then
            ''Without using the DLLManager class, directly editing the list.  
            mod_listA.DLL_DeleteRange(rangeToDelete)
        Else
            ''
            '' Added 10/26/2024 thomas d.
            ''
            operationToDelete = New DLLOperation1D_Of(Of TwoCharacterDLLVerticalA)(rangeToDelete,
                                  bIncludesListStart, bIncludesList__End,
                                  OPERATION_NotInsert,
                                  OPERATION_Delete,
                                  OPERATION_NotMove, not_a_moveType, Nothing, Nothing)
            ''12/20/2024                  SORT_123, SORT_321, SORT_UNDO, SORT_UNDO,
            ''12/20/2024                  Nothing, Nothing, Nothing)

            ''Added 3/26/2025 t/d/
            operationIndicized = operationToDelete.GetOperationIndexStructure()

            ''Added 4/08/2025 thomas d.
            mod_managerVerticalOps.LoadParallelLists(GetParallelLists())

            mod_managerVerticalOps.ProcessOperation_AnyType(operationToDelete, bAnyEndpointAffected,
                                             bAnyEndpointAffected_ByRef, RECORD_DEL_OPERATIONS,
                                             operationIndicized)

            operationToDelete.ExecutionDate = DateTime.Now ''Added 3/26/2025

            ''Administration....
            If (bAnyEndpointAffected Or bAnyEndpointAffected_ByRef) Then
                mod_firstItemA = mod_listA._itemStart
                mod_lastItemA = mod_listA._itemEnding
            End If ''End of ""If (bAnyEndpointAffected) Then""

        End If ''End of ""If (DIRECT_TO_LIST_Not) Then ... Else ..."

        ''
        ''Added 10/20/2024
        ''
        RefreshTheUI_DisplayList()

        ''Added 04/08/2025
        ''
        ''  Refresh the parallel lists.
        ''
        mod_firstItemB1 = mod_listB1.DLL_GetFirstItem_OfT()
        mod_firstItemB2 = mod_listB2.DLL_GetFirstItem_OfT()
        mod_firstItemB3 = mod_listB3.DLL_GetFirstItem_OfT()
        RefreshTheUI_DisplayList_B1(mod_listB1, mod_firstItemB1)
        RefreshTheUI_DisplayList_B2(mod_listB2, mod_firstItemB2)
        RefreshTheUI_DisplayList_B3(mod_listB3, mod_firstItemB3)

        ''Added 11/10/2024 
        buttonUndoLastStep.Enabled = True
        buttonUndoVertical.Enabled = True

        ''Added 11/29/2024 
        ''---labelNumOperations.Text = "Count of operations: " + mod_managerVerticalOps.HowManyOpsAreRecorded()
        ''Modified 12/01/2024
        labelNumOperations.Text = mod_managerVerticalOps.ToString()

    End Sub ''buttonDelete_Click 


    Private Sub mod_listA_EventListWasModified() Handles mod_listA.EventListWasModified
        ''
        '' Added 11/02/2024 thomas downes 
        ''
        mod_firstItemA = mod_listA._itemStart
        mod_lastItemA = mod_listA._itemEnding

    End Sub ''end of ""Private Sub mod_listA_EventListWasModified""


    Private Sub buttonRedoOp_Click(sender As Object, e As EventArgs) Handles buttonRedoOp.Click
        ''
        ''Added 11/09/2024
        ''
        Dim bEndpointAffected As Boolean ''Added 11/10/2024 td
        Dim bTestingIndexStructure As Boolean ''Added 1/14/2025 td

        If (mod_managerVerticalOps.MarkerHasOperationNext_Redo()) Then
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
        ''---mod_manager.RedoMarkedOperation()
        mod_managerVerticalOps.RedoMarkedOperation(bEndpointAffected, bTestingIndexStructure)

        ''Added 12/09/2024 & 11/10/2024 (but only on the buttonUndoLastStep_Click handler)
        mod_firstItemA = mod_listA._itemStart
        mod_lastItemA = mod_listA._itemEnding

        ''''Added 11/09/2024 
        ''RefreshTheUI_DisplayList()

        ''''Added 11/09/2024
        ''''buttonRedoOp.Enabled = False
        ''buttonRedoOp.Enabled = mod_managerVerticalOps.MarkerHasOperationNext_Redo()
        ''buttonReDo.Enabled = mod_managerVerticalOps.MarkerHasOperationNext_Redo()

        ''''Added 12/04/2024
        ''buttonUndoLastStep.Enabled = mod_managerVerticalOps.MarkerHasOperationPrior_Undo()
        ''buttonUndo.Enabled = mod_managerVerticalOps.MarkerHasOperationPrior_Undo()

        ''''Added 12/04/2024 
        ''labelNumOperations.Text = mod_managerVerticalOps.ToString()

        ''Added 4/14/2025 td
        mod_firstItemB1 = mod_listB1.DLL_GetFirstItem_OfT()
        mod_firstItemB2 = mod_listB2.DLL_GetFirstItem_OfT()
        mod_firstItemB3 = mod_listB3.DLL_GetFirstItem_OfT()

        ''Added 10/27/2024 
        RefreshTheUI_DisplayList()

        ''Added 4/14/2025 td
        RefreshTheUI_DisplayList_B1(mod_listB1, mod_firstItemB1)
        RefreshTheUI_DisplayList_B2(mod_listB2, mod_firstItemB2)
        RefreshTheUI_DisplayList_B3(mod_listB3, mod_firstItemB3)

        ''Added 11/09/2024
        ''buttonRedoOp.Enabled = True
        ''buttonReDo.Enabled = True

        ''Added 11/10/2024 
        buttonUndoLastStep.Enabled = mod_managerVerticalOps.MarkerHasOperationPrior_Undo()
        buttonUndoVertical.Enabled = mod_managerVerticalOps.MarkerHasOperationPrior_Undo()

        ''Added 11/10/2024 
        buttonRedoOp.Enabled = mod_managerVerticalOps.MarkerHasOperationNext_Redo()
        buttonRedoVertical.Enabled = mod_managerVerticalOps.MarkerHasOperationNext_Redo()

        ''Added 12/04/2024 
        labelNumOperations.Text = mod_managerVerticalOps.ToString()

    End Sub


    Private Sub ButtonMoveItemsByAnchor_Click(sender As Object, e As EventArgs) Handles buttonMoveItemsByAnchor.Click
        ''
        ''Added 11/16/2024 
        ''
        Dim tempAnchorItem As TwoCharacterDLLVerticalA ''---DLLAnchorItem(Of TwoCharacterDLLVerticalA)
        Dim tempAnchorPair As DLLAnchorCouplet(Of TwoCharacterDLLVerticalA)
        Dim tempOperation As DLLOperation1D_Of(Of TwoCharacterDLLVerticalA)

        Const OPERATION_MOVE = True
        ''Const ALLOW_NULLS As Boolean = True

        ''12/16/2024 Dim bChangeOfEndpoint = False
        Dim bChangeOfEndpoint_Expected = False
        Dim bChangeOfEndpoint_Occurred = False ''Added 12/16/2024 td
        Dim intAnchorIndex = 0
        Dim bAnchorMoveAfter As Boolean
        Dim bAnchorMoveBefore As Boolean
        Dim bCheck_RangeContainsAnchor As Boolean ''Added 11/18/2024
        Dim bCheck_AnchorEnclosesRange As Boolean ''Added 11/18/2024
        Dim intHowManyToMove As Integer ''Added 12/10/2024 td
        Dim bCannotMoveThatMany As Boolean ''Added 12/10/2024 td 

        ''Added 12/01/2024 
        ''   Inform the user of any pending issues, prior to any operations. 
        Dim boolUserHasCancelled As Boolean ''Added 12/01/2024
        AdminToDoPriorToAnyOperation("Move", boolUserHasCancelled)
        If boolUserHasCancelled Then Exit Sub

        ''Added 12/10/2024 td 
        intHowManyToMove = mod_rangeA.GetItemCount

        ''Added 11/11/2024 thomas downes
        bCannotMoveThatMany = intHowManyToMove >= mod_listA.DLL_CountAllItems

        ''Added 11/11/2024 td
        If mod_listA._isEmpty_OrTreatAsEmpty Then
            ''Added 11/11/2024 td
            MessageBoxTD.Show_Statement("The list is empty, so no moves can logically take place.")
            Exit Sub
        ElseIf bCannotMoveThatMany Then
            ''Added 11/11/2024 td
            MessageBoxTD.Show_InsertWordFormat_Line1(mod_listA.DLL_CountAllItems,
                                                 "The list is not long enough (less than {0} items), " +
                                    "the requested number of items to move cannot take place.", )
            Exit Sub
        End If ''eNd of ""If (mod_listA._isEmpty_OrTreatAsEmpty) Then""

        ''
        '' Proceed 
        ''
        intAnchorIndex = numMoveAnchorBenchmark.Value
        tempAnchorItem = mod_firstItemA.DLL_GetItemNext_OfT(-1 + intAnchorIndex)

        ''Added 12/09/2024  
        If tempAnchorItem Is Nothing Then
            MessageBoxTD.Show_Statement("Cannot locate Anchor Item.  May be outside the range of the list.")
            Exit Sub
        End If ''ENd of ""If (tempAnchorItem Is Nothing) Then""

        bAnchorMoveAfter = listMoveAfterOrBefore.SelectedIndex < 1
        bAnchorMoveBefore = listMoveAfterOrBefore.SelectedIndex >= 1
        bChangeOfEndpoint_Expected = mod_rangeA.ContainsEndpoint

        tempAnchorPair = New DLLAnchorCouplet(Of TwoCharacterDLLVerticalA)(tempAnchorItem, bAnchorMoveAfter)
        ''Added 12/09/2024  bChangeOfEndpoint = tempAnchorPair.ContainsEndpoint()
        bChangeOfEndpoint_Expected = (bChangeOfEndpoint_Expected Or tempAnchorPair.ContainsEndpoint)

        ''Added 11/18/2024
        ''
        ''  Run sanity-check (warning) functions. 
        ''
        bCheck_RangeContainsAnchor = mod_rangeA.Check_ContainsAnchorPair(tempAnchorPair)
        bCheck_AnchorEnclosesRange = mod_rangeA.Check_EnclosedByAnchorPair(tempAnchorPair)

        ''
        ''  Display sanity-check (warning) messages. 
        ''
        ''12/09/2024 If (bCheck_AnchorEnclosesRange) Then
        If bCheck_RangeContainsAnchor Then ''12/09/2024 If (bCheck_AnchorEnclosesRange) Then
            MessageBoxTD.Show_Statement("Not permitted (or hopelessly confusing): Range includes Anchor.")
            Exit Sub
        ElseIf bCheck_AnchorEnclosesRange Then
            MessageBoxTD.Show_Statement("Not permitted (or hopelessly confusing): Anchor already encloses Range.")
            Exit Sub
        End If

        ''Added 12/11/2024 
        Dim type_is_anchor = New StructureTypeOfMove(True) ''Added 12/11/2024 
        type_is_anchor.IsMoveToAnchor = True ''Added 12/11/2024 

        ''Added 4/08/2025 thomas d.
        mod_managerVerticalOps.LoadParallelLists(GetParallelLists())   ''//, arrayOfParallelRanges)

        ''
        '' Added 11/17/2024 thomas downes
        ''
        tempOperation = New DLLOperation1D_Of(Of TwoCharacterDLLVerticalA)(mod_rangeA, tempAnchorPair, False, OPERATION_MOVE, type_is_anchor)
        ''operation.OperateOnList(mod_listA)
        ''12/16/2024 mod_managerVerticalOps.ProcessOperation_AnyType(tempOperation, bChangeOfEndpoint, True)
        ''03/25/2025 mod_managerVerticalOps.ProcessOperation_AnyType(tempOperation, bChangeOfEndpoint_Expected,
        ''    bChangeOfEndpoint_Occurred, True)
        mod_managerVerticalOps.ProcessOperation_AnyType(tempOperation, bChangeOfEndpoint_Expected,
                                         bChangeOfEndpoint_Occurred, True,
                                         tempOperation.GetOperationIndexStructure())

        ''Added 11/18/2024 
        If bChangeOfEndpoint_Expected Then
            mod_firstItemA = mod_listA._itemStart
            mod_lastItemA = mod_listA._itemEnding

            ''Added 4/23/2025 
            mod_firstItemB1 = mod_listB1._itemStart
            mod_firstItemB2 = mod_listB2._itemStart
            mod_firstItemB3 = mod_listB3._itemStart

            ''Added 4/23/2025 
            mod_lastItemB1 = mod_listB1._itemEnding
            mod_lastItemB2 = mod_listB2._itemEnding
            mod_lastItemB3 = mod_listB3._itemEnding

        End If ''End of ""If (bChangeOfEndpoint_Expected) Then""

        ''Added 11/17/2024 
        RefreshTheUI_DisplayList()

        ''Added 4/23/2025
        RefreshTheUI_DisplayList_B1(mod_listB1, mod_firstItemB1)
        RefreshTheUI_DisplayList_B2(mod_listB2, mod_firstItemB2)
        RefreshTheUI_DisplayList_B3(mod_listB3, mod_firstItemB3)

        ''Added 11/29/2024 
        ''---labelNumOperations.Text = "Count of operations: " + mod_managerVerticalOps.HowManyOpsAreRecorded()
        ''Modified 12/01/2024
        ''Added 12/9/2024  labelNumOperations.Text = mod_managerVerticalOps.ToString()
        labelNumOperations.Text = mod_managerVerticalOps.ToString(tempOperation)

        ''Added 11/10/2024 
        buttonUndoLastStep.Enabled = True
        ''Added 11/29/2024 
        buttonUndoVertical.Enabled = True

    End Sub ''ENd of ""Private Sub ButtonMoveItems_Click""

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub buttonReDo_Click(sender As Object, e As EventArgs) Handles buttonRedoVertical.Click

        buttonRedoOp.PerformClick()

        ''Added 11/29/2024 
        ''---labelNumOperations.Text = "Count of operations: " + mod_managerVerticalOps.HowManyOpsAreRecorded()
        ''Modified 12/01/2024
        labelNumOperations.Text = mod_managerVerticalOps.ToString()

    End Sub

    Private Sub buttonUndo_Click(sender As Object, e As EventArgs) Handles buttonUndoVertical.Click

        buttonUndoLastStep.PerformClick()

        ''Added 11/29/2024 
        ''---labelNumOperations.Text = "Count of operations: " + mod_managerVerticalOps.HowManyOpsAreRecorded()
        ''Modified 12/01/2024
        labelNumOperations.Text = mod_managerVerticalOps.ToString()

    End Sub

    Private Sub LinkClearRecordedOps_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkClearRecordedOps.LinkClicked
        ''
        ''Added 12/4./2024 t..homas d..ownes
        ''
        mod_managerVerticalOps.ClearAllRecordedOperations()

        buttonRedoOp.Enabled = mod_managerVerticalOps.MarkerHasOperationNext_Redo()
        buttonRedoVertical.Enabled = mod_managerVerticalOps.MarkerHasOperationNext_Redo()

        buttonUndoLastStep.Enabled = mod_managerVerticalOps.MarkerHasOperationPrior_Undo()
        buttonUndoVertical.Enabled = mod_managerVerticalOps.MarkerHasOperationPrior_Undo()

        labelNumOperations.Text = mod_managerVerticalOps.ToString()

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupMoveByShifting.Enter

    End Sub

    Private Sub buttonMoveItems_Click_1(sender As Object, e As EventArgs) ''Handles buttonMoveItems.Click

    End Sub

    Private Sub buttonMoveLeft_Click(sender As Object, e As EventArgs) Handles buttonMoveShiftLeft.Click
        ''
        ''Added 12/11/2024 & 11/16/2024 
        ''
        Const SHIFT_LEFT As Boolean = True
        MoveByShiftingRange(SHIFT_LEFT, False, numericShiftLeft.Value)

        ''Added 12/17/2024
        If (APPLICATION_DOEVENTS) Then Application.DoEvents() ''Added 12/17/2024 

        RefreshTheUI_DisplayList()

    End Sub


    ''Private Sub MoveByShiftingRange(par_goLeft As Boolean, par_goRight As Boolean,
    ''                                Optional par_iShiftDistance As Integer = 1)
    ''    ''
    ''    '' Encapsulated 12/11/2024 td  
    ''    ''
    ''    Dim tempOperation As DLLOperation1D(Of TwoCharacterDLLVerticalA)
    ''    Const OPERATION_MOVE = True
    ''    ''Const ALLOW_NULLS As Boolean = True
    ''    Dim bChangeOfEndpoint = False
    ''    Dim intHowManyToMove As Integer ''Added 12/10/2024 td
    ''    Dim bCannotMoveThatMany As Boolean ''Added 12/10/2024 td 

    ''    ''Added 12/01/2024 
    ''    ''   Inform the user of any pending issues, prior to any operations. 
    ''    Dim boolUserHasCancelled As Boolean ''Added 12/01/2024
    ''    AdminToDoPriorToAnyOperation("Move", boolUserHasCancelled)
    ''    If boolUserHasCancelled Then Exit Sub

    ''    ''Added 12/10/2024 td 
    ''    intHowManyToMove = mod_range.GetItemCount

    ''    ''Added 11/11/2024 thomas downes
    ''    bCannotMoveThatMany = (intHowManyToMove >= mod_listA.DLL_CountAllItems)

    ''    ''Added 11/11/2024 td
    ''    If mod_listA._isEmpty_OrTreatAsEmpty Then

    ''        ''Added 11/11/2024 td
    ''        MessageBoxTD.Show_Statement("The list is empty, so no moves can logically take place.")
    ''        Exit Sub

    ''    ElseIf bCannotMoveThatMany Then

    ''        ''Added 11/11/2024 td
    ''        MessageBoxTD.Show_InsertWordFormat_Line1(mod_listA.DLL_CountAllItems,
    ''                                                 "The list is not long enough (less than {0} items), " +
    ''                                    "the requested number of items to move cannot take place.", )
    ''        Exit Sub

    ''    End If ''eNd of ""If (mod_listA._isEmpty_OrTreatAsEmpty) Then ... ElseIf... ""

    ''    ''
    ''    ''Build the correct Move Type.
    ''    ''
    ''    Dim intHowManyItemsToShift As Integer ''Added 12/11/2024 td 
    ''    Dim currentMoveType As New StructureTypeOfMove(True)
    ''
    ''    ''intHowManyItemsToShift = IIf(par_goLeft, numericShiftLeft.Value, numericShiftRight.Value)
    ''    intHowManyItemsToShift = par_iShiftDistance
    ''
    ''    currentMoveType.IsMoveIncremental = True
    ''    currentMoveType.IsIncrementalToLeft = par_goLeft
    ''    currentMoveType.IsIncrementalToRight = par_goRight
    ''    currentMoveType.HowManyItemsIncremental = intHowManyItemsToShift
    ''
    ''    ''
    ''    '' Added 11/17/2024 thomas downes
    ''    ''
    ''    tempOperation = New DLLOperation1D(Of TwoCharacterDLLVerticalA)(mod_range, Nothing,
    ''                                                               False, OPERATION_MOVE, currentMoveType)
    ''    ''operation.OperateOnList(mod_listA)
    ''    mod_managerVerticalOps.ProcessOperation_AnyType(tempOperation, bChangeOfEndpoint, True)
    ''
    ''    ''Added 11/18/2024 
    ''    If bChangeOfEndpoint Then
    ''        mod_firstItemA = mod_listA._itemStart
    ''        mod_lastItemA = mod_listA._itemEnding
    ''    End If ''End of ""If (bChangeOfEndpoint) Then""
    ''
    ''    ''Added 11/17/2024 
    ''    RefreshTheUI_DisplayList()
    ''
    ''    ''Added 11/29/2024 
    ''    ''---labelNumOperations.Text = "Count of operations: " + mod_managerVerticalOps.HowManyOpsAreRecorded()
    ''    ''Modified 12/01/2024
    ''    ''Added 12/9/2024  labelNumOperations.Text = mod_managerVerticalOps.ToString()
    ''    labelNumOperations.Text = mod_managerVerticalOps.ToString(tempOperation)
    ''
    ''    ''Added 11/10/2024 
    ''    buttonUndoLastStep.Enabled = True
    ''    ''Added 11/29/2024 
    ''    buttonUndo.Enabled = True
    ''
    ''End Sub ''eND OF ""Private Sub MoveByShiftingRange""


    Private Sub buttonMoveShiftRight_Click(sender As Object, e As EventArgs) Handles buttonMoveShiftRight.Click
        ''
        ''Added 12/11/2024 & 11/16/2024 
        ''
        Const SHIFT_RIGHT As Boolean = True
        MoveByShiftingRange(False, SHIFT_RIGHT, numericShiftRight.Value)

    End Sub

    Private Sub LinkRefreshList_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkRefreshList.LinkClicked

        ''Added 12/17/2024
        RefreshTheUI_DisplayList()
        MessageBox.Show("Refreshed")

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkApplicationDoevents.LinkClicked

        ''Added 12/18/2024 td
        APPLICATION_DOEVENTS = Not APPLICATION_DOEVENTS
        If (APPLICATION_DOEVENTS) Then LinkApplicationDoevents.Text = "DoEvents--ON"
        If (Not APPLICATION_DOEVENTS) Then LinkApplicationDoevents.Text = "DoEvents--Off"


    End Sub

    Private Sub LinkRefreshFirstItem_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkRefreshFirstItem.LinkClicked

        ''Added 12/18/2024 td
        REFRESH_FIRST_ITEM = Not REFRESH_FIRST_ITEM
        ''
        ''This setting is checked in the method called RefreshTheUI_DisplayList.
        ''
        If (REFRESH_FIRST_ITEM) Then LinkApplicationDoevents.Text = "REFRESH_FIRST_ITEM--ON"
        If (Not REFRESH_FIRST_ITEM) Then LinkApplicationDoevents.Text = "REFRESH_FIRST_ITEM--Off"


    End Sub

    Private Sub ButtonSortForward_Click(sender As Object, e As EventArgs) Handles ButtonSortForward.Click
        ''
        ''Added 12/20/2024 
        ''
        SortingForwardOrBackward(True, False)


    End Sub


    Private Sub SortingForwardOrBackward(pbSortForward As Boolean, pbSortBackward As Boolean)
        ''
        ''Encapsulated 05/07/2025 td
        ''
        Dim operationSorting_Main As DLLOperation1D_Of(Of TwoCharacterDLLVerticalA)
        Dim operationSorting_Parallel As DLLOperation1D_Of(Of DLLUserControlRichbox) ''Added 5/06/2025
        Dim listParallelToSortByValue As DLLList(Of DLLUserControlRichbox) ''Added 5/06/2025 
        Dim bChangeOfEndpoint_Occurred As Boolean
        Const CHANGE_OF_ENDS_EXPECTED As Boolean = True ''Added 12/23/2024 
        Const USE_MANAGER As Boolean = True ''Added 12/23/2024

        ''Added 6/6/2025 td
        If (mod_listB1._isEmpty_OrTreatAsEmpty) Then
            Dim result As DialogResult
            result =
            MessageBoxTD.Show_Statement_OkayCancel("Sorting", "Lists are empty, so cannot be sorted meaningfully.")
            If (result = DialogResult.OK) Then Exit Sub
        End If ''End pf ""If (mod_listB1._isEmpty_OrTreatAsEmpty) Then""

        ''Added 12/08/2024
        mod_managerVerticalOps.ClearAnyRedoOperations_IfQueued()

        ''Added 05/06/2025 & 04/23/205 
        mod_managerVerticalOps.LoadParallelLists(GetParallelLists())

        ''Added 05/06/2025 
        listParallelToSortByValue = mod_listCurrentWithFocus

        ''---May2025---If (mod_listA._isEmpty_OrTreatAsEmpty) Then
        If (mod_listA._isEmpty_OrTreatAsEmpty And
                 (listParallelToSortByValue Is Nothing _
                 OrElse listParallelToSortByValue._isEmpty_OrTreatAsEmpty)) Then
            ''
            '' The list(s) cannot be sorted, as they are empty. 
            ''

        ElseIf (listParallelToSortByValue IsNot Nothing) Then
            ''
            ''Added 5/06/2025 thomas downes
            ''
            ''  We will sort by the values in the parallel list
            ''     (versus the values in the main list (i.e. the primary list,
            ''     not one of the "parallel lists")).   ---05/06/2025 
            ''
            ''---operationSortForward_Main = New DLLOperation1D_Of(Of TwoCharacterDLLVerticalA)(EnumSortTypes.ByValues_Forward)

            ''Added 5/07/2025 thomas d
            Dim enumSorting As EnumSortTypes = EnumSortTypes.Undetermined ''Added 5/07/2025 thomas d
            If (pbSortForward) Then enumSorting = EnumSortTypes.ByValues_Forward
            If (pbSortBackward) Then enumSorting = EnumSortTypes.ByValues_Backward
            ''Added 5/07/2025 thomas d
            If (enumSorting = EnumSortTypes.Undetermined) Then
                System.Diagnostics.Debugger.Break()
            End If ''end of ""If (enumSorting = EnumSortTypes.Undetermined) Then

            ''Added 5/07/2025 thomas d
            operationSorting_Parallel = New DLLOperation1D_Of(Of DLLUserControlRichbox)(enumSorting)

            ''
            '' Major call!!
            ''
            ''---May2025---mod_manager.ProcessOperation_AnyType(operationSortForward_Parallel,
            mod_managerVerticalOps.ProcessOperation_ToParallelList(listParallelToSortByValue,
                            operationSorting_Parallel,
                            CHANGE_OF_ENDS_EXPECTED,
                            bChangeOfEndpoint_Occurred, True,
                            operationSorting_Parallel.GetOperationIndexStructure(),
                            SORT_PRIMARY_LIST_AFTER_PARALLELS)

        Else
            ''
            ''Main List
            ''  (the left-most vertical list, e.g. row-header controls)
            ''
            operationSorting_Main = New DLLOperation1D_Of(Of TwoCharacterDLLVerticalA)(EnumSortTypes.ByValues_Forward)

            ''12/23/2024 operationSortForward.OperateOnList(mod_listA, bChangeOfEndpoint_Occurred)
            If (USE_MANAGER) Then
                ''Added 12/23/2024 t))d))
                ''March 2025  mod_managerVerticalOps.ProcessOperation_AnyType(operationSortForward, CHANGE_OF_ENDS_EXPECTED,
                ''              bChangeOfEndpoint_Occurred, True)
                mod_managerVerticalOps.ProcessOperation_AnyType(operationSorting_Main, CHANGE_OF_ENDS_EXPECTED,
                       bChangeOfEndpoint_Occurred, True,
                       operationSorting_Main.GetOperationIndexStructure())

            Else
                operationSorting_Main.OperateOnParentList(mod_listA, bChangeOfEndpoint_Occurred)

            End If ''End of ""If (USE_MANAGER) Then... Else..."

        End If ''ENd of ""'If (mod_listA._isEmpty_OrTreatAsEmpty) Then ... Else ..."


        ''Administrative.
        If (True Or bChangeOfEndpoint_Occurred) Then
            mod_firstItemA = mod_listA._itemStart
            mod_lastItemA = mod_listA._itemEnding

            ''Added 4/23/2025 td
            mod_firstItemB1 = mod_listB1._itemStart
            mod_firstItemB2 = mod_listB2._itemStart
            mod_firstItemB3 = mod_listB3._itemStart

        End If ''End of ""If (True or bChangeOfEndpoint_Occurred) Then""

        ''Display the mutated list. 
        RefreshTheUI_DisplayList()

        ''Added 4/23/2025 td
        RefreshTheUI_DisplayList_B1(mod_listB1, mod_firstItemB1)
        RefreshTheUI_DisplayList_B2(mod_listB2, mod_firstItemB2)
        RefreshTheUI_DisplayList_B3(mod_listB3, mod_firstItemB3)

        ''Added 12/29/2024 
        labelNumOperations.Text = mod_managerVerticalOps.ToString()

        ''Added 11/10/2024 
        buttonUndoLastStep.Enabled = mod_managerVerticalOps.MarkerHasOperationPrior_Undo()
        buttonUndoVertical.Enabled = mod_managerVerticalOps.MarkerHasOperationPrior_Undo()


    End Sub ''End of Private Sub SortingForwardOrBackward 


    Private Sub ButtonSortBackward_Click(sender As Object, e As EventArgs) Handles ButtonSortBackward.Click
        ''
        ''Encapsulated 05/06/2025
        ''
        SortingForwardOrBackward(False, True)

        ''Added 12/22/2024 
        ''
        ''Dim operationSortBackward_Main As DLLOperation1D_Of(Of TwoCharacterDLLVerticalA)
        ''Dim operationSortBackward_Parallel As DLLOperation1D_Of(Of DLLUserControlRichbox) ''Added 05/07/2025
        ''Dim listParallelToSortByValue As DLLList(Of DLLUserControlRichbox) ''Added 5/06/2025 
        ''Dim bChangeOfEndpoint_Occurred As Boolean
        ''Const CHANGE_OF_ENDS_EXPECTED As Boolean = True ''Added 12/23/2024 
        ''Const USE_MANAGER As Boolean = True

        ''''Added 12/08/2024
        ''mod_manager.ClearAnyRedoOperations_IfQueued()

        ''''Added 4/23/205 
        ''mod_manager.LoadParallelLists(GetParallelLists())
        ''
        ''''Added 05/06/2025 
        ''listParallelToSortByValue = mod_listCurrentWithFocus
        ''
        ''operationSortBackward_Main = New DLLOperation1D_Of(Of TwoCharacterDLLVerticalA)(EnumSortTypes.ByValues_Backward)
        ''
        ''''Added 12/23/2024 t/d/ operationSortBackward.OperateOnList(mod_listA, bChangeOfEndpoint_Occurred)
        ''If (USE_MANAGER) Then
        ''    ''Added 12/23/2024 t))d))
        ''    ''Mar2025 mod_managerVerticalOps.ProcessOperation_AnyType(operationSortBackward, CHANGE_OF_ENDS_EXPECTED,
        ''    ''           bChangeOfEndpoint_Occurred, True)
        ''    ''
        ''    mod_managerVerticalOps.ProcessOperation_AnyType(operationSortBackward, CHANGE_OF_ENDS_EXPECTED,
        ''                               bChangeOfEndpoint_Occurred, True,
        ''                               operationSortBackward.GetOperationIndexStructure())
        ''
        ''Else
        ''    operationSortBackward.OperateOnParentList(mod_listA, bChangeOfEndpoint_Occurred)
        ''
        ''End If ''End of ""If (USE_MANAGER) Then... Else..."
        ''
        ''''Administrative.
        ''mod_firstItemA = mod_listA._itemStart
        ''mod_lastItemA = mod_listA._itemEnding
        ''
        ''''Added 4/23/2025 td
        ''mod_firstItemB1 = mod_listB1._itemStart
        ''mod_firstItemB2 = mod_listB2._itemStart
        ''mod_firstItemB3 = mod_listB3._itemStart
        ''
        ''''Major call!!
        ''RefreshTheUI_DisplayList()
        ''
        ''''Added 4/23/2025 td
        ''RefreshTheUI_DisplayList_B1(mod_listB1, mod_firstItemB1)
        ''RefreshTheUI_DisplayList_B2(mod_listB2, mod_firstItemB2)
        ''RefreshTheUI_DisplayList_B3(mod_listB3, mod_firstItemB3)
        ''
        ''''
        ''''Added 11/09/2024
        ''''  These two(2) lines are probably not needed. 
        ''''
        ''buttonRedoOp.Enabled = mod_managerVerticalOps.MarkerHasOperationNext_Redo()
        ''buttonReDo.Enabled = mod_managerVerticalOps.MarkerHasOperationNext_Redo()
        ''
        ''''Added 11/10/2024 
        ''buttonUndoLastStep.Enabled = mod_managerVerticalOps.MarkerHasOperationPrior_Undo()
        ''buttonUndo.Enabled = mod_managerVerticalOps.MarkerHasOperationPrior_Undo()
        ''
        ''''Added 11/29/2024 
        ''''    ---labelNumOperations.Text = "Count of operations: " + mod_managerVerticalOps.HowManyOpsAreRecorded()
        ''''Modified 12/01/2024
        ''labelNumOperations.Text = mod_managerVerticalOps.ToString()

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub richtextItemsDisplay_TextChanged(sender As Object, e As EventArgs) Handles richtextItemsDisplay.TextChanged

    End Sub

    Private Sub FlowRowHeaders_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    ''Added 5/05/2025 thomas 
    Private Const TRACK_ITEM_CLICKED_VIA_CSHARP As Boolean = True ''False
    Private Const TRACK_ITEM_CLICKED_VIA_VBNET As Boolean = False


    Private Sub DllUserControlRichbox1_Click(param_sender As Object, par_wShiftKey As Boolean, par_letter As String, par_row_base1 As Integer) _
        Handles DllUserControlRichbox1.DLLUserClickedControlBox
        ''
        ''This is a handler for the event. 
        ''
        If (TRACK_ITEM_CLICKED_VIA_VBNET) Then
            If (mod_currentClickedRichbox Is Nothing) Then
                ''Added 5/03/2025 thomas
                mod_currentClickedRichbox = param_sender
                mod_currentClickedRichbox.HighlightInCyan = True

            Else
                ''Added 5/03/2025 thomas
                mod_priorClickedRichbox = mod_currentClickedRichbox
                mod_priorClickedRichbox.HighlightInCyan = False
                mod_currentClickedRichbox = param_sender
                mod_currentClickedRichbox.HighlightInCyan = True

            End If ''End of ""If (mod_currentClickedRichbox Is Nothing) Then... Else..."
        End If ''End of ""If (TRACK_ITEM_CLICKED_VIA_VBNET) Then""

        If (mod_rangeA Is Nothing) Then
            ''Create a new range. 
            mod_rangeA = New DLLRange(Of TwoCharacterDLLVerticalA)(mod_listA, True, par_row_base1, 1)

        Else
            ''Expand or shift single-item (start of) range.
            mod_rangeA.UpdateEndpoints_UserClick(par_row_base1, par_wShiftKey, mod_listA)

        End If ''End of ""If (mod_rangeA Is Nothing) Then... Else..."

        ''Added 4/20/2025 thomas downes 
        numInsertAnchorBenchmark.Value = par_row_base1
        numDeleteRangeBenchmarkStart.Value = par_row_base1
        numMoveAnchorBenchmark.Value = par_row_base1

        ''Added 4/22/2025 td
        numDeleteHowMany.Value = mod_rangeA.GetItemCount()
        numInsertHowMany.Value = mod_rangeA.GetItemCount()

        ''Added 4/22/2025
        mod_listA.SelectAndDrawRange(mod_rangeA)

        ''Added 4/22/2025
        Dim intFirstIndexInRange = mod_rangeA.GetFirstItemIndex_base1()
        Dim intCountOfRangeItems = mod_rangeA.GetItemCount()
        mod_listB1.SelectAndDrawRange(intFirstIndexInRange, intCountOfRangeItems)
        mod_listB2.SelectAndDrawRange(intFirstIndexInRange, intCountOfRangeItems)
        mod_listB3.SelectAndDrawRange(intFirstIndexInRange, intCountOfRangeItems)


    End Sub

    Private Sub mod_listB1_EventListIsInFocus(param_list As Object, param_item As Object) _
            Handles mod_listB1.EventListIsInFocus,
                    mod_listB2.EventListIsInFocus,
                    mod_listB3.EventListIsInFocus

        Dim intRow_Base1 As Integer ''Added 5/04/2025

        ''Added 5/04/2025 thomas downes
        ''---mod_listCurrentWithFocus = mod_listCurrentWithFocus
        mod_listPriorWithFocus = mod_listCurrentWithFocus
        mod_listCurrentWithFocus = param_list ''sender

        ''Added 5/04/2025 thomas downes
        If (TRACK_ITEM_CLICKED_VIA_CSHARP) Then

            ''Added 5/04/2025 td
            ''---intRow_Base1 = CType(param_item, IDoublyLinkedItem(Of DLLUserControlRichbox)).DLL_GetItemIndex_base0()
            intRow_Base1 = CType(param_item, IDoublyLinkedItem(Of DLLUserControlRichbox)).DLL_GetItemIndex_base1()

            If (mod_currentClickedRichbox Is Nothing) Then
                ''Added 5/03/2025 thomas
                mod_currentClickedRichbox = param_item
                mod_currentClickedRichbox.HighlightInCyan = True

            Else
                ''Added 5/03/2025 thomas
                mod_priorClickedRichbox = mod_currentClickedRichbox
                mod_priorClickedRichbox.HighlightInCyan = False
                mod_currentClickedRichbox = param_item
                mod_currentClickedRichbox.HighlightInCyan = True

            End If ''End of ""If (mod_currentClickedRichbox Is Nothing) Then... Else..."
        End If ''End of ""If (TRACK_ITEM_CLICKED_VIA_CSHARP) Then""

    End Sub


    Private Sub mod_listB2_EventListIsInFocus(param_list As Object, param_item As Object) ''Handles mod_listB2.EventListIsInFocus

        ''Added 5/04/2025 thomas downes
        mod_listCurrentWithFocus = mod_listCurrentWithFocus
        mod_listCurrentWithFocus = param_list ''sender

    End Sub

    Private Sub mod_listB3_EventListIsInFocus(param_list As Object, param_item As Object) ''Handles mod_listB3.EventListIsInFocus

        ''Added 5/04/2025 thomas downes
        mod_listCurrentWithFocus = mod_listCurrentWithFocus
        mod_listCurrentWithFocus = param_list ''sender

    End Sub


End Class




