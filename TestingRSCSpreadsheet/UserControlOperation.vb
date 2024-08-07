Imports System.ComponentModel
Imports System.IO
Imports System.Runtime.CompilerServices
Imports ciBadgeInterfaces
Imports ciBadgeSerialize
Imports RSCLibraryDLLOperations

''
''Compiler code. 
''
#Const USE_PARENT_CLASS = False ''Determines if we are able to fully leverage child classes. ''True ''Added 3/12/2024 
#Const USE_SPECIFIC_CLASS = True ''Determines if we are able to fully leverage child classes. ''True ''Added 3/12/2024 

#If (USE_PARENT_CLASS) Then ''Added 3/12/2024 td
    ''Scale back to the base class. Hence you see, "(Of TwoCharacterDLLItem)".
#ElseIf (USE_SPECIFIC_CLASS) Then ''Added 3/12/2024 td
''Leverage the derived subclasses. Hence you see, "(Of TwoCharacterDLLHorizontal)", etc.
#End If


''' <summary>
''' This will allow the user to create DLLOperations.
''' </summary>
Friend Class UserControlOperation

    ''Added 3/29/2024
    Public ModeColumns As Boolean ''Columns are arranged horizontally.
    Public Mode___Rows As Boolean ''Rows are arranged vertically.

    ''Added 3/29/2024
    Public ModeColumns_Color As Color ''Columns are arranged horizontally.
    Public Mode___Rows_Color As Color ''Rows are arranged vertically.

    Public DLLOperationHorizontal As DLL_OperationV2
    Public DLLOperationVertical As DLL_OperationV2 ''Added 3/2/2024 td
    Public DLL_ListItems As DLL_List_OfTControl_PLEASE_USE(Of TwoCharacterDLLItem) ''Restored 3/12/2024

#If (USE_PARENT_CLASS) Then ''Added 3/12/2024 td
    ''Scale back to the base class. Hence you see, "(Of TwoCharacterDLLItem)".
    Public DLL_ListHorizontal As DLL_List_OfTControl_PLEASE_USE(Of TwoCharacterDLLItem)
    Public DLL_ListVertical As DLL_List_OfTControl_PLEASE_USE(Of TwoCharacterDLLItem)
#ElseIf (USE_SPECIFIC_CLASS) Then ''Added 3/12/2024 td
    ''Leverage the derived subclasses. Hence you see, "(Of TwoCharacterDLLHorizontal)", etc.
    Public DLL_ListHorizontal As DLL_List_OfTControl_PLEASE_USE(Of TwoCharacterDLLHorizontal)
    Public DLL_ListVertical As DLL_List_OfTControl_PLEASE_USE(Of TwoCharacterDLLVertical)
#End If

    ''Added 1/4/2024
    Public Lists_Endpoint As TwoCharacterDLLItem ''Added 1/4/2024
    Public Lists_Penultimate As TwoCharacterDLLItem ''Added 1/4/2024
    Public Struct_endpoint As StructEndPoint ''Added 1/5/2024

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
    ''3/2024 td Public Event DLLOperationCreated_Insert(par_operation As DLL_OperationV1)
    Public Event DLLOperationCreated_Insert(par_operation As DLL_OperationV1)
    Public Event DLLOperationCreated_InsertRow(par_operation As DLL_OperationV1)
    Public Event DLLOperationCreated_InsertCol(par_operation As DLL_OperationV1)

    ''Adde 8/4/2024 td
    Public Event DLLOperationV2_Insert(par_operation As DLLOperation(Of TwoCharacterDLLHorizontal, TwoCharacterDLLVertical),
                                par_inverseAnchor_PriorToRange As TwoCharacterDLLItem,
                                par_inverseAnchor_NextToRange As TwoCharacterDLLItem)


    Public Event DLLOperationCreated_Delete(par_operation As DLL_OperationV1)

    ''' <summary>
    ''' This will communicate the details of an INSERT operation, 
    ''' which the user has requested, and which hasn't yet been performed.
    ''' </summary>
    ''' <param name="par_operation">Gives detail of operation.</param>
    ''' <param name="par_inverseAnchor_PriorToRange">Needed in case of a later UNDO-OF-DELETE.</param>
    ''' <param name="par_inverseAnchor_NextToRange">Needed in case of a later UNDO-OF-DELETE.</param>
    ''Public Event DLLOperationCreated_Delete(par_operation As DLL_OperationV1,
    ''                            par_inverseAnchor_PriorToRange As TwoCharacterDLLItem,
    ''                            par_inverseAnchor_NextToRange As TwoCharacterDLLItem)
    Public Event DLLOperationV1_Delete(par_operation As DLL_OperationV1,
                                par_inverseAnchor_PriorToRange As TwoCharacterDLLItem,
                                par_inverseAnchor_NextToRange As TwoCharacterDLLItem)

    Public Event DLLOperationV2_Delete(par_operation As DLLOperation(Of TwoCharacterDLLHorizontal, TwoCharacterDLLVertical),
                                par_inverseAnchor_PriorToRange As TwoCharacterDLLItem,
                                par_inverseAnchor_NextToRange As TwoCharacterDLLItem)

    ''' <summary>
    ''' This will communicate the details of an INSERT operation, 
    ''' which the user has requested, and which hasn't yet been performed.
    ''' </summary>
    ''' <param name="par_operation">Gives detail of operation.</param>
    Public Event DLLOperationCreated_MoveRange(par_operationV1 As DLL_OperationV1,
                                par_inverseAnchor_PriorToRange As TwoCharacterDLLItem,
                                par_inverseAnchor_NextToRange As TwoCharacterDLLItem)

    ''Added 1/1/2024 thomas 
    Public Event DLLOperationCreated_UndoOfInsert(par_operationV1 As DLL_OperationV1,
                                par_isUndoOfInsert As Boolean)
    Public Event DLLOperationCreated_UndoOfDelete(par_operationV1 As DLL_OperationV1,
                                par_isUndoOfDelete As Boolean)
    Public Event DLLOperationCreated_UndoOfMove(par_operation As DLL_OperationV1,
                                par_isUndoOfMove As Boolean)

    ''Added 2/10/2024 thomas 
    Public Event DLLOperationCreated_SortAscending(par_operationV1 As DLL_OperationV1,
                                par_isUndoOfSort As Boolean)
    Public Event DLLOperationCreated_SortDescending(par_operationV1 As DLL_OperationV1,
                                par_isUndoOfSort As Boolean)

    ''Added 1/1/2024 thomas 
    Public Event UndoOfDelete_NoParams()
    Public Event UndoOfInsert_NoParams()
    Public Event UndoOfMoveRange_NoParams()

    ''Added 1/1/2024 thomas 
    Public Event Sort_Ascending()
    Public Event Sort_Descending()

    ''Added 1/01/2024 td
    Private mod_lastPriorOpV2 As DLL_OperationV2 = Nothing ''Added 1/01/2024 td
    Private mod_intCountOperations As Integer = 0 ''Added 1/1/2024


    Public Sub SetRangeEndpoint(par_endOfRange As TwoCharacterDLLItem)

        ''Added 1/4/2024 
        checkMoveRangeExpandsToEndpoint.Tag = par_endOfRange ''Me.Lists_Endpoint
        checkDeleteToEndpoint.Tag = par_endOfRange ''Me.Lists_Endpoint

        checkMoveRangeExpandsToEndpoint.Checked = True
        checkDeleteToEndpoint.Checked = True

    End Sub ''end of ""Public Sub SetRangeEndpoint""


    Public Sub ToggleFinalEndpointItemMode()
        ''
        ''Added 12/31/2023 thomas downes
        ''
        Static stat_bMode As Boolean = False
        stat_bMode = Not stat_bMode
        checkDeleteToEndpoint.Checked = stat_bMode
        checkMoveRangeExpandsToEndpoint.Checked = stat_bMode

    End Sub ''Public Sub ToggleFinalEndpointItemMode()


    Public Sub ToggleSingleItemMode()
        ''
        ''Added 12/27/2023 thomas downes
        ''
        Static s_insertCount As Integer = 1
        Static s_deleteCount As Integer = 1
        Static s_moveCount As Integer = 1
        Dim bSingleItemMode As Boolean

        ''---If (numDeleteHowMany.ReadOnly) Then
        bSingleItemMode = (numDeleteHowMany.Enabled = False)

        ''12/2023  If (numDeleteHowMany.Enabled = False) Then
        If (bSingleItemMode) Then

            ''numDeleteHowMany.ReadOnly = False
            ''numInsertHowMany.ReadOnly = False
            ''numMoveRangeHowMany.ReadOnly = False
            numDeleteHowMany.Enabled = True ''False
            numInsertHowMany.Enabled = True ''False
            numMoveRangeHowMany.Enabled = True ''False

            numDeleteHowMany.Value = s_deleteCount
            numInsertHowMany.Value = s_insertCount
            numMoveRangeHowMany.Value = s_moveCount

        Else

            s_insertCount = numInsertHowMany.Value
            s_deleteCount = numDeleteHowMany.Value
            s_moveCount = numMoveRangeHowMany.Value

            numDeleteHowMany.Value = 1
            numInsertHowMany.Value = 1
            numMoveRangeHowMany.Value = 1

            ''numDeleteHowMany.ReadOnly = True
            ''numInsertHowMany.ReadOnly = True
            ''numMoveRangeHowMany.ReadOnly = True
            numDeleteHowMany.Enabled = False
            numInsertHowMany.Enabled = False
            numMoveRangeHowMany.Enabled = False

        End If ''End of ""If (bSingleItemMode) Then... Else..."


    End Sub ''ENd of ""Public Sub ToggleSingleItemMode()


    Public Sub SetModeToColumns()

        ''Added 4/6/2024 
        Me.BackColor = Me.ModeColumns_Color
        Me.ModeColumns = True '' = Me.ColorForColumns
        Me.Mode___Rows = False

        ''Added 4/6/2024 
        If (Me.ModeColumns_Color = Me.Mode___Rows_Color) Then
            Debugger.Break()
        End If

    End Sub ''end of ""Public Sub SetModeToColumns()""


    Public Sub SetModeTo___Rows()

        ''Added 4/6/2024 
        Me.BackColor = Me.Mode___Rows_Color
        Me.Mode___Rows = True '' = Me.ColorForColumns
        Me.ModeColumns = False

        ''Added 4/6/2024 
        If (Me.ModeColumns_Color = Me.Mode___Rows_Color) Then
            Debugger.Break()
        End If

    End Sub ''end of ""Public Sub SetModeTo___Rows()""


    Private Sub ButtonInsert_Click(sender As Object, e As EventArgs) Handles buttonInsert.Click
        ''
        ''Create a DLL-Insert operation and publish it as an event,
        ''    so that the user-interface form can detect it and 
        ''    leverage this new operation.
        ''
        Dim objDLLOperation As DLL_OperationV2 = Nothing
        Dim firstRangeItem As TwoCharacterDLLItem
        ''Dim indexOfRangeFirst As Integer
        Dim indexOfAnchor As Integer
        Dim bBefore_LetsInsertRangeBeforeAnchor As Boolean ''Added 12/23/2023
        Dim bAfter_LetsInsertRangeAfterAnchor As Boolean ''Added 12/23/2023
        Dim intHowManyItemsToInsert As Integer
        Dim anchorItem As TwoCharacterDLLItem
        Dim anchorItem_ToBePriorToRange As TwoCharacterDLLItem
        Dim anchorItem_ToFollowRange As TwoCharacterDLLItem
        Dim enumRowOrColumns As EnumModeRowsOrColumns ''Added 4/8/2024 

        ''Adeded 4/8/2024 td
        enumRowOrColumns = EnumModeRowsOrColumns.Undetermined
        If (Me.ModeColumns) Then enumRowOrColumns = EnumModeRowsOrColumns.Cols
        If (Me.Mode___Rows) Then enumRowOrColumns = EnumModeRowsOrColumns.Rows

        ''intHowManyItemsToInsert = numInsertHowMany.Value
        intHowManyItemsToInsert = GetHowManyItems("I"c)

        ''0 = After, 1 = Before
        bBefore_LetsInsertRangeBeforeAnchor = (1 = listInsertAfterOr.SelectedIndex) ''After (0) or Before (1)
        bAfter_LetsInsertRangeAfterAnchor = (0 = listInsertAfterOr.SelectedIndex) ''After (0) or Before (1)

        ''indexOfRangeFirst = numInsertRangeFirst.Value
        ''indexOfAnchor = (-1 + numInsertAnchorBenchmark.Value)
        indexOfAnchor = GetIndex_BenchmarkMinusOne("I"c, True)

        ''Added 12/27/2023 td
        Dim bAnchorAtStartingPoint As Boolean ''Added 12/27/2023 td
        Dim bAnchorAtEndingPoint As Boolean ''Added 12/27/2023 td
        Dim bChangeOfEitherEndPoint As Boolean
        Dim bLikelyFillingEmptyList As Boolean ''Added 12/31/2023 td

        ''Added 12/27/2023 td
        bAnchorAtStartingPoint = (indexOfAnchor = 0)
        bAnchorAtEndingPoint = (indexOfAnchor = -1 + DLL_ListHorizontal.DLL_CountAllItems())
        bChangeOfEitherEndPoint = (bAnchorAtEndingPoint And bAfter_LetsInsertRangeAfterAnchor) Or
              (bAnchorAtStartingPoint And bBefore_LetsInsertRangeBeforeAnchor)
        bLikelyFillingEmptyList = (Me.DLL_ListHorizontal.DLL_IsListEmpty())

        anchorItem = Me.DLL_ListHorizontal.DLL_GetItemAtIndex(indexOfAnchor)

        ''-----------DIFFICULT & CONFUSING---------
        If (bAfter_LetsInsertRangeAfterAnchor) Then
            ''-----------DIFFICULT & CONFUSING---------
            anchorItem_ToBePriorToRange = anchorItem
        ElseIf (bBefore_LetsInsertRangeBeforeAnchor) Then
            ''-----------DIFFICULT & CONFUSING---------
            anchorItem_ToFollowRange = anchorItem
        End If

        firstRangeItem = BuildNewItemsDLL_FirstInRange(intHowManyItemsToInsert)

        If (firstRangeItem Is Nothing) Then
            ''added 12/2023
            ''Debugger.Break()
            MessageBoxTD.Show_Statement("No insert will be done.")

        Else
            ''12/2023 objDLLOperation = New DLL_OperationV2("I"c, firstRangeItem,
            ''            intHowManyItemsToInsert, anchorItem)
            If (bLikelyFillingEmptyList) Then
                ''
                ''Added 12/31/2023 thomas downes
                ''
                bChangeOfEitherEndPoint = True
                objDLLOperation = New DLL_OperationV2("I"c, firstRangeItem, firstRangeItem._Control,
                          intHowManyItemsToInsert,
                          anchorItem, enumRowOrColumns, Nothing,
                          bChangeOfEitherEndPoint, bLikelyFillingEmptyList)

            ElseIf (bAfter_LetsInsertRangeAfterAnchor) Then
                ''
                ''                Insert A B C after 7, as 7 is the preceding anchor. (7, then three(3) items.)
                ''                       |
                ''          1 2 3 4 5 6 7 8 9 10
                '' Result:  1 2 3 4 5 6 7_A_B_C_8 9 10
                ''
                objDLLOperation = New DLL_OperationV2("I"c, firstRangeItem, firstRangeItem._Control,
                          intHowManyItemsToInsert,
                          anchorItem, enumRowOrColumns, Nothing,
                          bChangeOfEitherEndPoint)

            ElseIf (bBefore_LetsInsertRangeBeforeAnchor) Then
                ''
                ''            Insert x before 6, the terminating anchor (6). (...x 6...)
                ''                   |
                ''          1 2 3 4 5 6 7 8 9 10
                '' Result:  1 2 3 4 5_x_6 7 8 9 10
                ''
                objDLLOperation = New DLL_OperationV2("I"c, firstRangeItem, firstRangeItem._Control,
                intHowManyItemsToInsert, Nothing, enumRowOrColumns, anchorItem,
                bChangeOfEitherEndPoint)

            End If ''end of ""ElseIf (bBefore_LetsInsertRangeBeforeAnchor) Then""

            ''
            ''Check the mode (Rows or Columns).
            ''
            ''Added 4/6/2024 td
            If (Me.ModeColumns) Then
                RaiseEvent DLLOperationCreated_InsertCol(objDLLOperation.GetCopyV1())
            ElseIf (Me.Mode___Rows) Then
                RaiseEvent DLLOperationCreated_InsertRow(objDLLOperation.GetCopyV1())
            Else
                RaiseEvent DLLOperationCreated_Insert(objDLLOperation.GetCopyV1())
            End If ''End of ""If (Me.ModeColumns) Then... ElseIf... Else...

            ''Added 3/29/2024 td
            If (Me.ModeColumns) Then
                ''Columns are arranged horizontally.
                RaiseEvent DLLOperationCreated_InsertCol(objDLLOperation.GetCopyV1())
            ElseIf (Me.Mode___Rows) Then
                ''Rows are arranged vertically.
                RaiseEvent DLLOperationCreated_InsertRow(objDLLOperation.GetCopyV1())
            End If

            ''Administrative.
            ''  Inserts do NOT have an "inverse anchor".
            DLL_InverseAnchor_PriorToRange = Nothing
                DLL_InverseAnchor_NextToRange = Nothing

            End If ''end of ""If (firstRangeItem Is Nothing) Then... ElseIf..."

            ''Added 1/01/2024 td
            ''mod_lastPriorOpV2 = objDLLOperation
            RecordLastPriorOperation(objDLLOperation)

    End Sub ''End of ""Private Sub ButtonInsert_Click""


    Private Sub ButtonDelete_Click(sender As Object, e As EventArgs) Handles buttonDelete.Click
        ''
        ''Create a DLL-Delete operation and publish it as an event,
        ''    so that the user-interface form can detect it and 
        ''    leverage this new operation.
        ''
        Dim objDLLOperationV2 As DLL_OperationV2
        Dim lastRangeItem As TwoCharacterDLLItem = Nothing
        Dim indexOfRangeFirst As Integer
        indexOfRangeFirst = GetIndex_BenchmarkMinusOne("D"c)
        Dim firstRangeItem As TwoCharacterDLLItem
        firstRangeItem = Me.DLL_ListHorizontal.DLL_GetItemAtIndex(indexOfRangeFirst)

        ''Added 1/5/2024 td
        If (Me.checkDeleteToEndpoint.Checked) Then

            ''Added 1/5/2024 td
            Dim bInclusive As Boolean ''Added 1/5/2024 td
            ''Added 1/5/2024 td
            bInclusive = Me.Struct_endpoint.EndpointIsInclusive
            lastRangeItem = Me.Struct_endpoint.Endpoint

            ''Major call.
            objDLLOperationV2 = GetOperation_Delete_ByEndpt()

        Else
            Dim intHowManyItemsToDelete As Integer
            intHowManyItemsToDelete = GetHowManyItems("D"c)
            ''lastRangeItem = firstRangeItem.DLL_GetItemNext(-1 + intHowManyItemsToDelete)
            ''
            ''Major call.  (Var. lastRangeItem will populate via ByRef.)
            ''
            objDLLOperationV2 = GetOperation_Delete_ByCount(intHowManyItemsToDelete, lastRangeItem)

        End If ''ENd of ""If (Me.checkDeleteToEndpoint.Checked) Then ... Else...""


        If (objDLLOperationV2 Is Nothing) Then
            ''
            ''A well-formed operation could not be made. 
            ''
            ''We will asssume that the user has been notified
            ''  via a pop-up message. 
            ''
        Else
            ''
            ''Publish the operation to the Parent Form.
            ''
            ''//RaiseEvent DLLOperationCreated_Insert(objDLLOperation)
            RaiseEvent DLLOperationCreated_Delete(objDLLOperationV2.GetCopyV1()) '',
            ''  firstRangeItem.DLL_GetItemPrior(),
            ''  lastRangeItem.DLL_GetItemNext())

            ''//inverse_anchorItem = objDLLOperation.
            ''Added 1/01/2024
            objDLLOperationV2.Set_InverseAnchor(firstRangeItem.DLL_GetItemPrior(),
                                          lastRangeItem.DLL_GetItemNext())

            ''Administrative.
            ''   We need the inverse anchor for the "Undo" operation. 
            Me.DLL_InverseAnchor_PriorToRange = firstRangeItem.DLL_GetItemPrior()
            Me.DLL_InverseAnchor_NextToRange = lastRangeItem.DLL_GetItemNext()

            ''
            ''Record the operation internally (i.e. for this usercontrol).
            ''
            ''Added 1/01/2024 td
            ''mod_lastPriorOpV2 = objDLLOperation
            RecordLastPriorOperation(objDLLOperationV2)

        End If ''End opf ""If (objDLLOperation Is Nothing) Then... Else..."

    End Sub ''end of ""Private Sub ButtonDelete_Click""


    Private Sub ButtonSort_Click(sender As Object, e As EventArgs) Handles buttonSortList.Click

        ''Added 1/08/2024
        ''Me.DLL_List.DLL_SortItems()

        Dim objDLLOperationV2 As DLL_OperationV2
        Dim boolDescending As Boolean

        If (listBoxAscendDescend.SelectedIndex > 0) Then
            ''RaiseEvent Sort_Descending()
            boolDescending = True
        Else
            ''RaiseEvent Sort_Ascending()
            boolDescending = False ''False
        End If

        ''Added 2/10/2024 td
        ''2/12/2024  objDLLOperationV2 = New DLL_OperationV2("S"c, True, boolDescending)
        objDLLOperationV2 = New DLL_OperationV2("S"c, True, boolDescending,
                                                Me.DLL_ListHorizontal.GetQueue_OfDLLItems())

        RaiseEvent DLLOperationCreated_SortAscending(objDLLOperationV2.GetCopyV1(), False)

        ''
        ''Record the operation internally (i.e. for this usercontrol).
        ''
        RecordLastPriorOperation(objDLLOperationV2)

    End Sub ''ENd of ""'Private Sub ButtonSort_Click""


    Public Function GetOperation_Delete_ByEndpt() As DLL_OperationV2
        ''
        ''Encapsulated 1/5/2024 thomas d.  
        ''
        Dim result As DLL_OperationV2
        Dim struct_end As StructEndPoint
        Dim dummy As TwoCharacterDLLItem = Nothing
        Dim intHowManyItems As Integer
        Dim intStartIndex As Integer

        struct_end = Me.Struct_endpoint
        intStartIndex = GetIndex_BenchmarkMinusOne("D"c)
        intHowManyItems = (1 + struct_end.EndpointIndex - intStartIndex)
        result = GetOperation_Delete_ByCount(intHowManyItems, dummy)
        ''Set the Ending Point of the Range. 
        result.Set_LastItemInRange(struct_end.Endpoint)
        Return result

    End Function ''End of Public Function GetOperation_Delete_ByEndpt()


    Public Function GetOperation_Delete_ByCount(ByVal pintHowManyItemsInRange As Integer,
                                                ByRef pref_lastRangeItem As TwoCharacterDLLItem) As DLL_OperationV2
        ''
        ''Encapsulated 1/5/2024 thomas d.  
        ''
        Dim result_dllOperation As DLL_OperationV2
        Dim firstRangeItem As TwoCharacterDLLItem
        Dim indexOfRangeFirst As Integer
        Dim bIsForEitherEndpoint As Boolean

        ''12/23/2023 intHowManyItemsToDelete = numInsertHowMany.Value
        ''#2 12/23/2023 intHowManyItemsToDelete = numDeleteHowMany.Value
        ''1/5/2024 intHowManyItemsToDelete = GetHowManyItems("D"c)

        ''boolInsertAfter = (1 <> listInsertAfterOr.SelectedIndex)
        ''indexOfRangeFirst = numDeleteRangeBenchmarkStart.Value
        indexOfRangeFirst = GetIndex_BenchmarkMinusOne("D"c)

        ''Added 12/26/2023
        bIsForEitherEndpoint = ((indexOfRangeFirst = 0) Or
             (indexOfRangeFirst >= -1 + DLL_ListHorizontal.DLL_CountAllItems()))

        ''Added 12/28/2023
        Dim bOutOfRange_Upper As Boolean
        bOutOfRange_Upper = (indexOfRangeFirst > -1 + DLL_ListHorizontal.DLL_CountAllItems())
        If (bOutOfRange_Upper) Then
            MessageBoxTD.Show_Statement("Out of range / Greater than item count")
            ''Exit Function ''Exit Sub
            Return Nothing
        End If ''Endof ""If (bOutOfRange_Upper) Then""

        ''indexOfAnchor = (-1 + numInsertAnchorBenchmark.Value)
        ''anchorItem = Me.DLL_List.DLL_GetItemAtIndex(indexOfAnchor)
        ''firstRangeItem = BuildNewItemsDLL_FirstInRange(intHowManyItemsToInsert)
        firstRangeItem = Me.DLL_ListHorizontal.DLL_GetItemAtIndex(indexOfRangeFirst)

        ''Added 1/18/2024 
        Dim cleaned_howManyItemsInRange As Integer ''Added 1/18/2024 
        Dim bNeedsCleaning As Boolean ''Added 1/18/2024 
        cleaned_howManyItemsInRange = pintHowManyItemsInRange
        bNeedsCleaning = ((indexOfRangeFirst + pintHowManyItemsInRange) > DLL_ListHorizontal.DLL_CountAllItems())
        ''Added 1/18/2024 
        If bNeedsCleaning Then
            ''Added 1/18/2024 
            cleaned_howManyItemsInRange = (DLL_ListHorizontal.DLL_CountAllItems() - indexOfRangeFirst)
        End If ''End of ""If bNeedsCleaning Then""

        ''result_dllOperation = New DLL_OperationV2("D"c, firstRangeItem,
        ''       intHowManyItemsToDelete, Nothing, Nothing, bIsForEitherEndpoint)
        ''1/2024 result_dllOperation = New DLL_OperationV2("D"c, firstRangeItem,
        ''1/2024   pintHowManyItemsInRange, Nothing, Nothing, bIsForEitherEndpoint)
        result_dllOperation = New DLL_OperationV2("D"c, firstRangeItem, firstRangeItem._Control,
                cleaned_howManyItemsInRange, Nothing,
                GetModeRowOrColumns(), Nothing,
                bIsForEitherEndpoint)

        ''
        ''Populate the ByRef parameter.
        ''
        ''pref_lastRangeItem = firstRangeItem.DLL_GetItemNext(-1 + intHowManyItemsToDelete)
        pref_lastRangeItem = firstRangeItem.DLL_GetItemNext(-1 + pintHowManyItemsInRange)

        Return result_dllOperation

    End Function  ''End of ""Private Function GetOperation_Delete_ByCount""


    Private Sub buttonMoveItems_Click(sender As Object, e As EventArgs) Handles buttonMoveItems.Click
        ''
        ''Create a DLL-Move operation and publish it as an event,
        ''    so that the user-interface form can detect it and 
        ''    leverage this new operation.
        ''
        Dim objDLLOperation As DLL_OperationV2
        Dim firstRangeItem As TwoCharacterDLLItem
        Dim lastRangeItem As TwoCharacterDLLItem = Nothing
        Dim indexOfRangeFirst As Integer
        Dim intHowManyItemsToMove As Integer
        Dim indexOfAnchor As Integer
        Dim anchorItem As TwoCharacterDLLItem
        Dim anchorItem_ToBePriorToRange As TwoCharacterDLLItem = Nothing ''Added 12/23/2023
        Dim anchorItem_ToFollowRange As TwoCharacterDLLItem = Nothing ''Added 12/23/2023
        Dim bLetsInsertRangeBeforeAnchor As Boolean ''Added 12/23/2023
        Dim bLetsInsertRangeAfterAnchor As Boolean ''Added 12/23/2023
        Dim bChangeOfEndPoint1_Cut As Boolean ''Added 12/31/2023 thomas
        Dim bChangeOfEndPoint2_Cut As Boolean ''Added 12/31/2023 thomas
        Dim bChangeOfEndPoint3_Paste As Boolean ''Added 12/31/2023 thomas
        Dim bChangeOfEndPoint4_Paste As Boolean ''Added 12/31/2023 thomas
        Dim bChangeOfEndPointAny As Boolean ''Added 12/31/2023 thomas

        ''12/2023 intHowManyItemsToMove = numMoveRangeHowMany.Value
        intHowManyItemsToMove = GetHowManyItems("M"c) '' "M" for "Move"

        ''indexOfRangeFirst = numMoveRangeStartBenchmark.Value
        indexOfRangeFirst = GetIndex_BenchmarkMinusOne("M"c, pbAnchor:=False)

        firstRangeItem = Me.DLL_ListHorizontal.DLL_GetItemAtIndex(indexOfRangeFirst)
        If (firstRangeItem Is Nothing) Then
            ''
            ''The user may have ALL (or partially) deleted the list
            ''  (so, not enough items left.)
            MessageBoxTD.Show_InsertWordFormat_Line1(Me.DLL_ListHorizontal.DLL_CountAllItems(),
                                "There are only {0} items in the list.")
            Exit Sub
        Else
            lastRangeItem = firstRangeItem.DLL_GetItemNext(-1 + intHowManyItemsToMove)
        End If ''End of ""If (firstRangeItem Is Nothing) Then... Else..."

        bLetsInsertRangeBeforeAnchor = (0 <> listMoveAfterOr.SelectedIndex) ''After (0) or Before (1)
        bLetsInsertRangeAfterAnchor = (1 <> listMoveAfterOr.SelectedIndex) ''After (0) or Before (1)
        ''---indexOfAnchor = (-1 + numInsertAnchorBenchmark.Value)
        indexOfAnchor = GetIndex_BenchmarkMinusOne("M"c, pbAnchor:=True)

        ''Added 1/8/2024
        Dim bIndexNotFound As Boolean
        Dim benchmarkOfAnchor As Integer ''A 1-based numbering of items.
        ''Added 1/8/2024
        ''   Benchmark = (Index + 1)
        ''   Index = (Benchmark - 1)
        bIndexNotFound = (Not DLL_ListHorizontal.DLL_IndexExists(indexOfAnchor))
        If bIndexNotFound Then
            ''Added 1/8/2024
            benchmarkOfAnchor = (1 + indexOfAnchor)
            MessageBoxTD.Show_InsertWordFormat_Line1(CStr(benchmarkOfAnchor),
                     "Sorry, folks... Anchor benchmark [{0}] is not found.")
            Exit Sub
        End If ''End of ""If bIndexNotFound Then""

        anchorItem = Me.DLL_ListHorizontal.DLL_GetItemAtIndex(indexOfAnchor)

        ''Added 12/31/2023
        ''   Consider all the ways the Move might affect either of two endpoints.
        ''   --12/31/2023
        Dim intListCount_Size As Integer = DLL_ListHorizontal.DLL_CountAllItems()
        bChangeOfEndPoint1_Cut = (0 = indexOfRangeFirst)
        bChangeOfEndPoint2_Cut = (indexOfRangeFirst + intHowManyItemsToMove >= intListCount_Size)
        bChangeOfEndPoint3_Paste = ((0 = indexOfAnchor) And
            bLetsInsertRangeBeforeAnchor)
        bChangeOfEndPoint4_Paste = ((indexOfAnchor = -1 + intListCount_Size) And
            bLetsInsertRangeAfterAnchor)
        bChangeOfEndPointAny = (bChangeOfEndPoint1_Cut Or bChangeOfEndPoint2_Cut) Or
            (bChangeOfEndPoint3_Paste Or bChangeOfEndPoint3_Paste)

        ''Added 1/1/2024 td
        ''  Check to see if an logical contradiction exists--
        ''    the anchor being inside the range. 
        Dim bAnchorInsideRange_Error1 As Boolean ''Added 1/1/2024 td
        ''Dim bAnchorInsideRange_Error2 As Boolean ''Added 1/1/2024 td
        bAnchorInsideRange_Error1 = RangeIncludesAnchor_Error(indexOfRangeFirst,
                              intHowManyItemsToMove, indexOfAnchor)
        ''bAnchorInsideRange_Error2 =
        ''    Me.DLL_List.DLL_RangeIncludesAnchor_Error(firstRangeItem,
        ''                      intHowManyItemsToMove, anchorItem)
        If (bAnchorInsideRange_Error1) Then
            MessageBoxTD.Show_Statement("Error, anchor is inside the range. Can't proceed. #1")
            Exit Sub
            ''ElseIf (bAnchorInsideRange_Error2) Then
            ''    MessageBoxTD.Show_Statement("Error, anchor is inside the range. Can't proceed. #2")
            ''    Exit Sub
        End If ''End of ""If (bAnchorInsideRange_Error1) Then""

        ''See above. Added 1/1/2024
        ''See above. bChangeOfEndPoint1_Cut = (indexOfRangeFirst = 0)
        ''See above. bChangeOfEndPoint2_Cut = (indexOfRangeFirst + intHowManyItemsToMove =
        ''    DLL_List.DLL_CountAllItems())

        If (bLetsInsertRangeAfterAnchor) Then
            anchorItem_ToBePriorToRange = anchorItem
            ''Added 1/20/2024 
            bChangeOfEndPointAny = bChangeOfEndPointAny Or (anchorItem.DLL_NotAnyNext())
            ''Added 1.1.2024
            ''See above. bChangeOfEndPoint3_Paste = (indexOfAnchor = -1 + DLL_List.DLL_CountAllItems())

        ElseIf (bLetsInsertRangeBeforeAnchor) Then
            anchorItem_ToFollowRange = anchorItem
            ''Added 1.1.2024
            ''See above. bChangeOfEndPoint3_Paste = (indexOfAnchor = 0)
        End If ''ENd of ""If (bLetsInsertRangeAfterAnchor) Then... ElseIf..."

        '' "M" for "Move"
        objDLLOperation = New DLL_OperationV2("M"c, firstRangeItem, firstRangeItem._Control,
                intHowManyItemsToMove,
                anchorItem_ToBePriorToRange,
                GetModeRowOrColumns(),
                anchorItem_ToFollowRange,
                bChangeOfEndPointAny) ''Nothing, Nothing)

        ''//RaiseEvent DLLOperationCreated_Insert(objDLLOperat ion)
        RaiseEvent DLLOperationCreated_MoveRange(objDLLOperation.GetCopyV1(),
                         firstRangeItem.DLL_GetItemPrior(),
                         lastRangeItem.DLL_GetItemNext())

        ''Administrative.
        ''   We need the inverse anchor for the "Undo" operation. 
        Me.DLL_InverseAnchor_PriorToRange = firstRangeItem.DLL_GetItemPrior()
        Me.DLL_InverseAnchor_NextToRange = lastRangeItem.DLL_GetItemNext()

        ''//inverse_anchorItem = objDLLOperation.
        ''Added 1/01/2024 td
        ''mod_lastPriorOpV2 = objDLLOperation
        RecordLastPriorOperation(objDLLOperation)

    End Sub  ''End of  Private Sub buttonMoveItems_Click


    Private Sub RecordLastPriorOperation(par_lastPriorOpV2 As DLL_OperationV2)
        ''
        ''Added 1/01/2024
        ''
        mod_intCountOperations += 1
        mod_lastPriorOpV2 = par_lastPriorOpV2

    End Sub ''End of ""Private Sub RecordLastPriorOperation()""


    Public Function LastPriorOperation() As DLL_OperationV2
        ''
        ''Added 1/01/2024
        ''
        Return mod_lastPriorOpV2

    End Function ''ENd of ""Public Function LastPriorOperation() As DLL_OperationV2""

    ''' <summary>
    ''' Indicates whether a logical error exists, that of the anchor being WITHIN the range.
    ''' </summary>
    ''' <param name="pIndexRangeStart">Location of start of range.</param>
    ''' <param name="pHowManyItems">Size of range.</param>
    ''' <param name="pIndexOfAnchor">Location of anchor (where the range will be placed).</param>
    ''' <returns></returns>
    Private Function RangeIncludesAnchor_Error(pIndexRangeStart As Integer,
                                               pHowManyItems As Integer, pIndexOfAnchor As Integer)
        ''
        '' Added 1/01/20
        ''
        Dim bBeforeEnd As Boolean
        Dim bAfterStart As Boolean
        Dim result_bInRange As Boolean
        bAfterStart = (pIndexOfAnchor >= pIndexRangeStart)
        bBeforeEnd = (pIndexOfAnchor < (pIndexRangeStart + pHowManyItems))
        result_bInRange = (bAfterStart And bBeforeEnd)
        Return result_bInRange

    End Function ''End of ""Private Function RangeIncludesAnchor_Error""



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
            MessageBox.Show(strMessage & vbCrLf & "Empty... nothing to be done.")
            Return Nothing ''Exit Function
        End If

        ''---firstRangeItem = DLL_List.DLL_GetItemAtIndex(0)
        ''---valuesTwoChar = textInsertListOfValuesCSV.Text.Substring(0, 2)
        Dim valuesTwoChar = textInsertListOfValuesCSV.Text.Split(" "c)
        Dim bCountMatches As Boolean
        Dim bMultipleTwoDigits As Boolean
        Dim bOnlyOneInsertValue As Boolean ''added 12/30/2023

        bMultipleTwoDigits = (1 < valuesTwoChar.Length)
        bCountMatches = (pintHowManyItemsToInsert = valuesTwoChar.Length)
        If (Not bCountMatches) Then

            bOnlyOneInsertValue = (1 = valuesTwoChar.Length) ''added 12/30/2023
            If (bOnlyOneInsertValue) Then ''added 12/30/2023
                ''
                ''We will repeat the value for every inserted item. 12/30/2023
                ''
            Else
                strMessage = String.Format("The count of Two-Digit pairs is {0} not {1}.",
                 valuesTwoChar.Length, pintHowManyItemsToInsert)
                MessageBox.Show(strMessage & vbCrLf &
                                "Mismatch... not clear what's to be done.")
                Return Nothing '' Exit Function

            End If ''ENd of "":If (bOnlyOneInsertValue) Then... Else..."

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
            End If ''end of ""If (bMultipleTwoDigits) Then...Else..."

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

        ''Added 2/27/2024 
        listBoxAscendDescend.SelectedIndex = 1

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
        Dim intCountCurrentListItems As Integer = DLL_ListHorizontal.DLL_CountAllItems()
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
        Dim intCountCurrentListItems As Integer = DLL_ListHorizontal.DLL_CountAllItems()
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


    Public Sub UpdateTheItemCount()
        ''
        ''Added 1/18/2024 
        ''
        Dim max_count As Integer
        Dim boolUseEndpoint As Boolean
        Dim intEndpointIndex As Integer

        If (Me.Struct_endpoint.Endpoint Is Nothing) Then
            ''
            ''The following code is _NOT_ relevant.
            ''
        Else
            ''Update the Endpoint Index.
            intEndpointIndex = DLL_ListHorizontal.DLL_GetIndexOfItem(Me.Struct_endpoint.Endpoint)
            Me.Struct_endpoint.EndpointIndex = intEndpointIndex

            boolUseEndpoint = checkDeleteToEndpoint.Checked
            max_count = DLL_ListHorizontal.DLL_CountAllItems()
            UpdateTheItemCount(max_count, boolUseEndpoint, Me.Struct_endpoint)

        End If ''End of ""If (Me.Struct_endpoint.Endpoint Is Nothing) Then ... Else""

    End Sub ''End of ""Public Sub UpdateTheItemCount""


    Public Sub UpdateTheItemCount(par_newMaxCount As Integer,
                                  Optional par_bUseEndpoint As Boolean = False,
             Optional par_endPointStructure As StructEndPoint = Nothing)
        ''
        ''Added 12/28/2023 
        ''
        ''Dim boolEndpoint As Boolean ''Added 1/05/2024
        ''boolEndpoint = (par_endPointInclusive IsNot Nothing)
        ''boolEndpoint = (par_endPointStructure IsNot Nothing)

        If (par_newMaxCount <= 0) Then Exit Sub ''Added 12/31/2023

        ''
        ''Delete
        ''
        If (par_bUseEndpoint) Then ''Added 1/05/2024

            ''Added 1/05/2024
            ''  If we know the endpoint, we know the number of items in the range. 
            Dim intStartingIndex As Integer
            Dim intItemsInRange As Integer ''Added 1/05/2024 
            intStartingIndex = (-1 + numDeleteRangeBenchmarkStart.Value)
            intItemsInRange = GetItemCountOfRange(intStartingIndex, par_endPointStructure)
            If (intItemsInRange <= 0) Then
                MessageBoxTD.Show_Statement("There is no discernible range.")
                Exit Sub
            End If ''End of ""If (intItemsInRange <= 0) Then""

            If (numDeleteHowMany.Maximum < intItemsInRange) Then
                numDeleteHowMany.Maximum = intItemsInRange
            End If
            numDeleteHowMany.Value = intItemsInRange

        ElseIf (numDeleteRangeBenchmarkStart.Value > par_newMaxCount) Then
            ''Show the user the new count of items.
            If (numDeleteRangeBenchmarkStart.Maximum < par_newMaxCount) Then
                numDeleteRangeBenchmarkStart.Maximum = par_newMaxCount
            End If
            numDeleteRangeBenchmarkStart.Value = par_newMaxCount

        End If ''End of ""If (par_bUseEndpoint) Then""

        If (numDeleteRangeBenchmarkStart.Maximum > par_newMaxCount) Then
            numDeleteRangeBenchmarkStart.Maximum = par_newMaxCount
        End If

        ''
        ''Insert
        ''
        If (numInsertAnchorBenchmark.Value > par_newMaxCount) Then
            numInsertAnchorBenchmark.Value = par_newMaxCount
        End If
        If (numInsertAnchorBenchmark.Maximum > par_newMaxCount) Then
            numInsertAnchorBenchmark.Maximum = par_newMaxCount
        End If

        ''Added 12/31/2023
        If (numInsertAnchorBenchmark.Maximum < par_newMaxCount) Then
            numInsertAnchorBenchmark.Maximum = par_newMaxCount
        End If

        ''
        ''Move
        ''
        If (par_bUseEndpoint) Then ''Added 1/05/2024

            ''Added 1/05/2024
            ''  If we know the endpoint, we know the number of items in the range. 
            Dim intStartingIndex As Integer
            Dim intItemsInRange As Integer ''Added 1/05/2024 
            intStartingIndex = (-1 + numMoveRangeStartBenchmark.Value)
            intItemsInRange = GetItemCountOfRange(intStartingIndex, par_endPointStructure)
            If (intItemsInRange <= 0) Then
                MessageBoxTD.Show_Statement("There is no discernible range.")
                Exit Sub
            End If ''End of ""If (intItemsInRange <= 0) Then""

            If (numMoveRangeHowMany.Maximum < intItemsInRange) Then
                numMoveRangeHowMany.Maximum = intItemsInRange
            End If
            numMoveRangeHowMany.Value = intItemsInRange

        Else
            ''
            ''We are proceeding by count, not endpoint.
            ''
            If (numMoveAnchorBenchmark.Value > par_newMaxCount) Then
                numMoveAnchorBenchmark.Value = par_newMaxCount
            End If
            If (numMoveAnchorBenchmark.Maximum > par_newMaxCount) Then
                numMoveAnchorBenchmark.Maximum = par_newMaxCount
            End If

            ''Added 12/31/2023
            If (numMoveAnchorBenchmark.Maximum < par_newMaxCount) Then
                numMoveAnchorBenchmark.Maximum = par_newMaxCount
            End If

        End If ''End of ""If (par_bUseEndpoint) Then... Else..."

    End Sub ''End of ""Public Sub UpdateTheItemCount_Rows()"


    Public Function GetModeRowOrColumns() As EnumModeRowsOrColumns
        ''
        ''Added 4/08/2024 thomas downes
        ''
        If (Me.ModeColumns) Then
            Return EnumModeRowsOrColumns.Cols
        ElseIf (Me.Mode___Rows) Then
            Return EnumModeRowsOrColumns.Rows
        Else
            Return EnumModeRowsOrColumns.Undetermined
        End If

    End Function ''End of ""Public Function GetModeRowOrColumns() As EnumModeRowsOrColumns""


    Private Function GetItemCountOfRange(pintStartingIndex As Integer,
                                         par_endPointStructure As StructEndPoint) As Integer
        ''
        ''Added 1/5/2024 td
        ''
        ''Added 1/05/2024
        ''Dim intStartingIndex As Integer
        Dim intEndingIndex As Integer
        Dim result_countItemsInRange As Integer ''Added 1/05/2024 
        Dim bIncludeEndpoint As Boolean ''Integer

        bIncludeEndpoint = (par_endPointStructure.EndpointIsInclusive)
        intEndingIndex = par_endPointStructure.EndpointIndex

        If (bIncludeEndpoint) Then
            result_countItemsInRange = (1 + intEndingIndex - pintStartingIndex)
        Else
            result_countItemsInRange = (intEndingIndex - pintStartingIndex)
        End If ''End of ""If (bIncludeEndpoint) Then... Else..."

        Return result_countItemsInRange

    End Function ''End of ""Private Function GetItemCountOfRange""


    Private Sub LinkUndoInsert_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkUndoInsert.LinkClicked
        ''
        ''Added 1/1/2024 
        ''
        '' Let's undo the Insert operation.
        ''
        Dim objLastPriorOpV2 As DLL_OperationV2
        Dim undoOperationV1 As DLL_OperationV1
        Dim undoOperationV2 As DLL_OperationV2

        objLastPriorOpV2 = mod_lastPriorOpV2
        undoOperationV1 = objLastPriorOpV2.GetCopyV1().GetUndoVersionOfOperation()
        undoOperationV2 = undoOperationV1.GetCopyV2()
        undoOperationV1.CreatedAsUndoOperation = True

        ''Added 1/1/2024 
        RaiseEvent DLLOperationCreated_UndoOfInsert(undoOperationV1, True)

        ''Added 1/03/2024 
        RaiseEvent UndoOfInsert_NoParams()

    End Sub

    Private Sub LinkUndoDelete_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkUndoDelete.LinkClicked
        ''
        ''Added 1/1/2024 
        ''
        '' Let's undo the Delete operation.
        ''
        Dim objLastPriorOpV2 As DLL_OperationV2
        Dim objLastPriorOpV1 As DLL_OperationV1
        Dim undoOperationV1 As DLL_OperationV1
        ''Dim undoOperationV2 As DLL_OperationV2

        objLastPriorOpV2 = mod_lastPriorOpV2
        ''undoOperationV1 = objLastPriorOpV2.GetCopyV1().GetUndoVersionOfOperation()
        ''undoOperationV2 = undoOperationV1.GetCopyV2()
        objLastPriorOpV1 = objLastPriorOpV2.GetCopyV1()

        ''Create the "Undo" version.
        undoOperationV1 = objLastPriorOpV1.GetUndoVersionOfOperation()
        undoOperationV1.CreatedAsUndoOperation = True

        ''Added 1/1/2024 
        ''1/3/2024 RaiseEvent DLLOperationCreated_UndoOfDelete(undoOperationV1, True)
        RaiseEvent DLLOperationCreated_UndoOfDelete(undoOperationV1, True)
        RaiseEvent UndoOfDelete_NoParams()

    End Sub


    Private Sub LinkUndoMove_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkUndoMove.LinkClicked
        ''
        ''Added 1/1/2024 
        ''
        '' Let's undo the Delete operation.
        ''
        Dim objLastPriorOpV2 As DLL_OperationV2
        Dim objLastPriorOpV1 As DLL_OperationV1
        Dim undoOperationV1 As DLL_OperationV1

        objLastPriorOpV2 = mod_lastPriorOpV2
        objLastPriorOpV1 = objLastPriorOpV2.GetCopyV1()

        ''Create the "Undo" version.
        undoOperationV1 = objLastPriorOpV1.GetUndoVersionOfOperation()
        undoOperationV1.CreatedAsUndoOperation = True

        ''Added 1/1/2024 
        RaiseEvent DLLOperationCreated_UndoOfMove(undoOperationV1, True)
        ''Added 1/3/2024 
        RaiseEvent UndoOfMoveRange_NoParams()

    End Sub

    Private Sub checkDeleteToEndpoint_CheckedChanged(sender As Object, e As EventArgs) Handles checkDeleteToEndpoint.CheckedChanged

        ''Added 1/4/2024 
        checkDeleteToEndpoint.Tag = Me.Lists_Endpoint

    End Sub

    Private Sub checkMoveRangeExpandsToEndpoint_CheckedChanged(sender As Object, e As EventArgs) Handles checkMoveRangeExpandsToEndpoint.CheckedChanged

        ''Added 1/4/2024 
        checkMoveRangeExpandsToEndpoint.Tag = Me.Lists_Endpoint

    End Sub


    Private Sub textInsertListOfValuesCSV_TextChanged(sender As Object, e As EventArgs) Handles textInsertListOfValuesCSV.TextChanged

        ''Added 1/15/2024 
        Static s_array_space As String() = {" "c}
        Static s_priorLength As Integer
        Dim split_list As String()
        Dim curr_length As Integer
        Dim bAddedChar As Boolean
        Dim intLengthLastWord As Integer
        Dim bEndsInSpace As Boolean
        Dim bHowManyIsTooSmall As Boolean

        curr_length = textInsertListOfValuesCSV.TextLength
        bEndsInSpace = (curr_length > textInsertListOfValuesCSV.Text.TrimEnd().Length)
        bAddedChar = (curr_length > s_priorLength)

        If (bEndsInSpace) Then
            ''
            ''Ignore.
            ''
        ElseIf (bAddedChar) Then

            split_list = textInsertListOfValuesCSV.Text.Split(s_array_space,
                                         StringSplitOptions.RemoveEmptyEntries)
            intLengthLastWord = split_list.Last().Length
            If (intLengthLastWord = 2) Then
                bHowManyIsTooSmall = (numInsertHowMany.Value < split_list.Length)
                If bHowManyIsTooSmall Then
                    numInsertHowMany.Value = split_list.Length
                End If ''End of ""If (intLengthLastWord = 2) Then""
            ElseIf (intLengthLastWord > 2) Then
                MessageBoxTD.Show_Statement("The two-letter words should be 2 not 3 characters.")
            End If ''ENd of ""If (bAddedChar) Then""

        End If ''end of ""If (bEndsInSpace) Then...Else..."

        s_priorLength = curr_length

    End Sub

End Class
