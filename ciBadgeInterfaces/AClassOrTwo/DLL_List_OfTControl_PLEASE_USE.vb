''12/2023 Imports System.Data.SqlTypes

''-----------------------------------------------------------
''  Please see CIBadgeDesigner / Classes RSC / RSC_DLL_OperationsManager.
''
''    ---12/07/2023 thomas dow_nes 
''-----------------------------------------------------------
''
''---- DIFFICULT AND CONFUSING ----
''  Here is the "secret sauce" that allows this Generic Type (DLL_List_OfTControl_PLEASE_USE(Of TControl))
''  to work... EXPLICIT CASTING!!!   ---12/18/2023
''  EXPLICIT CASTING...
''    Dim itemToInsert As IDoublyLinkedItem = CType(toBeInsertedSingleItem, IDoublyLinkedItem)
''    Dim itemForAnchoring As IDoublyLinkedItem = CType(toUseAsAnchor, IDoublyLinkedItem)
''-----------------------------------------------------------------------------------------------------
''

''' <summary>
''' We use explicit casting as a way to access crucial methods. 
''' TControl is RSCFieldColumn, RSCDataHeader, or RSCDataCell.
''' </summary>
''' <typeparam name="TControl"></typeparam>
Public Class DLL_List_OfTControl_PLEASE_USE(Of TControl)
    Implements IDoublyLinkedList(Of TControl)

    Private mod_dllControlFirst As IDoublyLinkedItem ''Not necessarily needed, except for testing. DLL = Doubly-Linked List. 
    Private ReadOnly mod_bTesting As Boolean
    Private mod_dllControlLast As IDoublyLinkedItem ''May not be needed.  DLL = Doubly-Linked List. 
    Private mod_intCountOfItems As Integer ''Added 12/19/2023

    ''Added 2/29/2024
    ''The first integer is the unshifted (no use of shift-key) integer.
    Private mod_tupSelect_NoShiftToShift As Tuple(Of Integer, Integer) ''Added 2/29/2024
    ''The first integer is the lower-endpoint index.
    Private mod_tupSelect_LowToUpper As Tuple(Of Integer, Integer) ''Added 2/29/2024

    Private Const WE_CHECK_RANGE_ENDPOINTS_ALWAYS As Boolean = False ''Added 12/18/2023
    Private Const WE_CHECK_RANGE_ENDPOINTS_TESTING As Boolean = True ''Added 12/18/2023
    Private Const WE_CLEAN_RANGE_ENDPOINTS_ALWAYS As Boolean = True ''Added 12/18/2023

    '' 12/2023
    ''Public Sub DLL_SetNextAs(toBeNext As TControl) Implements IDoublyLinkedList(Of TControl).DLL_SetNextAs
    ''    ''Throw New NotImplementedException()
    ''E nd Sub
    '' 12/2023
    ''Public Sub DLL_SetPriorAs(toBePrior As TControl) Implements IDoublyLinkedList(Of TControl).DLL_SetPriorAs
    ''    Throw New NotImplementedException()
    ''End Sub

    Public Sub New(par_firstItem As TControl)
        ''
        ''Set the initial instance variable. 
        ''
        ''  (Also, we'll test the TControl can be converted to IDoublyLinkedItem.)
        ''  
        mod_dllControlFirst = CType(par_firstItem, IDoublyLinkedItem)
        ''Set the Last equal to the First, as there is only one(1) item currently.
        mod_dllControlLast = mod_dllControlFirst ''Nothing 

        mod_bTesting = Testing.TestingByDefault

        ''Added 12/2023
        mod_intCountOfItems = 0

        ''
        ''Test the TControl can be converted to IDoublyLinkedItem. 
        ''  Oh... we already are doing that!!  
        ''


    End Sub ''Public Sub New


    Public Sub New(par_firstItem As TControl, par_lastItem As TControl)
        ''
        ''Set the initial instance variable. 
        ''
        ''  (Also, we'll test the TControl can be converted to IDoublyLinkedItem.) 
        ''
        mod_dllControlFirst = CType(par_firstItem, IDoublyLinkedItem)

        mod_bTesting = Testing.TestingByDefault

        ''Added 12/2023
        ''
        ''Test the TControl can be converted to IDoublyLinkedItem. 
        ''
        mod_dllControlLast = CType(par_lastItem, IDoublyLinkedItem)

        ''Added 12/2023
        mod_intCountOfItems = 0

    End Sub ''Public Sub New


    ''' <summary>
    ''' Re-initialize the list.
    ''' </summary>
    Public Sub DLL_ClearAllItems()

        mod_dllControlFirst = Nothing
        mod_intCountOfItems = 0
        mod_dllControlLast = Nothing


    End Sub ''End of ""Public Sub DLL_ClearAllItems()""



    ''For IDoublyLinkedItem.---Public Sub DLL_InsertItemAfter(toBeInserted As TControl) Implements IDoublyLinkedList(Of TControl).DLL_InsertItemAfter
    ''    ''Throw New NotImplementedException()
    ''End Sub

    Public Sub DLL_AddFirstOnlyRange(p_toAddFirstItemToEmptyList As TControl, p_intNumberOfItems As Integer)
        ''
        ''          Insert 1 2 3 4 5 6 7 8 9 10 into empty list. 
        ''          |
        '' Start:   
        '' Result:  1 2 3 4 5 6 7 A 8 9 10
        ''
        Dim bTesting As Boolean = ciBadgeInterfaces.Testing.TestingByDefault
        Dim itemFirst As IDoublyLinkedItem

        ''Testing...
        If ((bTesting And WE_CHECK_RANGE_ENDPOINTS_TESTING) Or
            WE_CHECK_RANGE_ENDPOINTS_ALWAYS) Then
            ''Items passed as primary-operational (vs. anchors) must be cleaned
            ''  of references.
            If (mod_dllControlFirst IsNot Nothing) Then
                Debugger.Break()
                Throw New RSCEndpointException("First is already there")
            ElseIf (mod_dllControlLast IsNot Nothing) Then
                Debugger.Break()
                Throw New RSCEndpointException("Last is already there")
            ElseIf (mod_intCountOfItems <> 0) Then
                Debugger.Break()
                Throw New RSCEndpointException("Count is nonzero")
            End If

        End If ''Testing

        itemFirst = CType(p_toAddFirstItemToEmptyList, IDoublyLinkedItem)
        mod_dllControlFirst = itemFirst ''toAddFirstItemToEmptyList
        mod_dllControlLast = itemFirst.DLL_GetItemNext(-1 + p_intNumberOfItems)
        mod_intCountOfItems = p_intNumberOfItems

    End Sub ''End of ""Public Sub DLL_AddFirstOnlyRange""


    Public Sub DLL_AddFirstAndOnlyItem(each_twoCharsItem)
        ''
        ''Add a single item to an empty list. 
        ''
        ''          Insert 1 into empty list. 
        ''          |
        '' Start:   
        '' Result:  1
        ''
        ''Added 12/19/2023
        DLL_AddFirstOnlyRange(each_twoCharsItem, 1)

    End Sub ''end Public Sub DLL_AddFirstAndOnlyItem(each_twoCharsItem)


    Public Sub DLL_AppendRange(p_firstItemOfRange As TControl, p_intNumberOfItems As Integer)
        ''
        ''          Insert 1 2 3 4 5 6 7 8 9 10 into empty list. 
        ''          |
        '' Start:   
        '' Result:  1 2 3 4 5 6 7 A 8 9 10
        ''
        DLL_InsertRangeAfter(p_firstItemOfRange, p_intNumberOfItems, mod_dllControlLast, True)

    End Sub ''End of Public Sub DLL_AppendRange


    Public Sub DLL_InsertOneItemAfter(p_toBeInsertedSingleItem As TControl,
                                      p_toUseAsAnchor_ItemPriorToSingle As TControl,
                                      p_atEitherEndpoint As Boolean) _
                                      Implements IDoublyLinkedList(Of TControl).DLL_InsertOneItemAfter
        ''
        ''                Insert A after 7, the preceding anchor.
        ''                       |
        ''          1 2 3 4 5 6 7 8 9 10
        '' Result:  1 2 3 4 5 6 7 A 8 9 10
        ''
        ''12/2023 Throw New NotImplementedException()
        Dim itemSingleToInsert As IDoublyLinkedItem '' = CType(p_toBeInsertedSingleItem, IDoublyLinkedItem)
        ''Reminder, anchors are applicable AFTER (or DURING) the operation takes place.
        Dim itemForAnchoring_ItemPriorToSingle As IDoublyLinkedItem ''Will ultimately precede the range of inserted items.
        Dim bTesting As Boolean = ciBadgeInterfaces.Testing.TestingByDefault

        ''-----------------------------------------------------------------------------------------------------
        ''---- DIFFICULT AND CONFUSING ----
        ''  Here is the "secret sauce" that allows this Generic Type (DLL_List_OfTControl_PLEASE_USE(Of TControl))
        ''  to work... EXPLICIT CASTING!!!  ---12/18/2023
        ''-----------------------------------------------------------------------------------------------------
        itemSingleToInsert = CType(p_toBeInsertedSingleItem, IDoublyLinkedItem)
        itemForAnchoring_ItemPriorToSingle = CType(p_toUseAsAnchor_ItemPriorToSingle, IDoublyLinkedItem)

        ''Testing...
        If ((bTesting And WE_CHECK_RANGE_ENDPOINTS_TESTING) Or
            WE_CHECK_RANGE_ENDPOINTS_ALWAYS) Then
            ''Items passed as primary-operational (vs. anchors) must be cleaned
            ''  of references.
            If (itemSingleToInsert.DLL_HasNext()) Then Debugger.Break()
            If (itemSingleToInsert.DLL_HasPrior()) Then Debugger.Break()
        End If ''Testing

        ''
        ''Save the item prior to the anchor, if it exists.
        ''
        Dim temp_itemNextToAnchor As IDoublyLinkedItem = Nothing
        Dim anchorHasItemNext As Boolean
        anchorHasItemNext = itemForAnchoring_ItemPriorToSingle.DLL_HasNext()
        If (anchorHasItemNext) Then
            ''We are _NOT_ at the end of the list.
            ''Oops temp_itemNextToAnchor = itemForAnchoring_ItemPriorToSingle.DLL_GetItemPrior()
            temp_itemNextToAnchor = itemForAnchoring_ItemPriorToSingle.DLL_GetItemNext()
        Else
            ''
            ''We _ARE_ at the end of the list.
            ''
            ''Testing...
            If (bTesting) Then
                Dim bMismatch As Boolean
                bMismatch = (mod_dllControlLast IsNot itemForAnchoring_ItemPriorToSingle)
                If (bMismatch) Then Debugger.Break()
            End If ''End of ""If (bTesting) Then""

            ''Added 12/18/2023 td
            mod_dllControlLast = p_toBeInsertedSingleItem

        End If ''end of ""If (anchorHasItemNext) Then... Else..."

        ''Set references #1 & #2 of 4
        Dim temp = itemForAnchoring_ItemPriorToSingle.DLL_GetItemNext()
        itemForAnchoring_ItemPriorToSingle.DLL_SetItemNext(itemSingleToInsert)
        itemSingleToInsert.DLL_SetItemPrior(itemForAnchoring_ItemPriorToSingle)

        ''If there is a next element, set references #3 & #4 of 4
        If (anchorHasItemNext) Then
            ''Set references #3 & #4 of 4
            temp_itemNextToAnchor.DLL_SetItemPrior(itemSingleToInsert)
            itemSingleToInsert.DLL_SetItemNext(temp_itemNextToAnchor)

        ElseIf (p_atEitherEndpoint) Then
            ''
            ''Do nothing. The calling procedure is already aware of the change of endpoint.
            ''
        Else
            ''Inform the calling procedures that the endpoint has changed. 
            Throw New RSCEndpointException("New starting ending point of list.")

        End If ''end of ""If (anchorHasItemNext) Then ... ElseIf... Else...""

        ''Added 12/19/2023
        mod_intCountOfItems += 1

    End Sub ''Public Sub DLL_InsertOneItemAfter


    ''Public Sub DLL_InsertItemBefore(toBeInserted As TControl) Implements IDoublyLinkedList(Of TControl).DLL_InsertItemBefore
    ''    Throw New NotImplementedException()
    ''End Sub

    Public Sub DLL_InsertOneItemBefore(ByVal p_toBeInsertedSingleItem As TControl,
                                       ByVal p_toUseAsAnchor_ItemNextToSingle As TControl,
                                       ByVal p_isChangeOfEndpoint As Boolean) _
                                       Implements IDoublyLinkedList(Of TControl).DLL_InsertOneItemBefore
        ''
        ''            Insert x before 6, the terminating anchor (6).
        ''                   |
        ''          1 2 3 4 5 6 7 8 9 10
        '' Result:  1 2 3 4 5 x 6 7 8 9 10
        ''
        ''12/2023 Throw New NotImplementedException()

        Dim itemSingleToInsert As IDoublyLinkedItem
        ''Reminder, anchors are applicable AFTER (or DURING) the operation takes place.
        Dim itemForAnchoring_ItemNextToSingle As IDoublyLinkedItem ''Will ultimate follow the inserted item.
        Dim bTesting As Boolean = ciBadgeInterfaces.Testing.TestingByDefault

        ''-----------------------------------------------------------------------------------------------------
        ''---- DIFFICULT AND CONFUSING ----
        ''  Here is the "secret sauce" that allows this Generic Type (DLL_List_OfTControl_PLEASE_USE(Of TControl))
        ''  to work... EXPLICIT CASTING!!!  ---12/18/2023
        ''-----------------------------------------------------------------------------------------------------
        itemSingleToInsert = CType(p_toBeInsertedSingleItem, IDoublyLinkedItem)
        itemForAnchoring_ItemNextToSingle = CType(p_toUseAsAnchor_ItemNextToSingle, IDoublyLinkedItem)

        If ((bTesting And WE_CHECK_RANGE_ENDPOINTS_TESTING) Or
            WE_CHECK_RANGE_ENDPOINTS_ALWAYS) Then
            ''
            ''-----POSSIBLY DIFFICULT AND CONFUSING----
            ''Items passed as primary-operational (vs. anchors) must be cleaned
            ''  of references.
            ''
            If (itemSingleToInsert.DLL_HasNext()) Then Debugger.Break()
            If (itemSingleToInsert.DLL_HasPrior()) Then Debugger.Break()
        End If ''Testing for clean endpoints

        ''Save the item prior to the anchor, if it exists. 
        Dim temp_itemPriorToAnchor As IDoublyLinkedItem = Nothing
        Dim anchorHasItemPrior As Boolean ''Added 12/18/2023
        anchorHasItemPrior = itemForAnchoring_ItemNextToSingle.DLL_HasPrior()
        If (anchorHasItemPrior) Then
            temp_itemPriorToAnchor = itemForAnchoring_ItemNextToSingle.DLL_GetItemPrior()
        Else
            ''
            ''We _ARE_ at the beginning of the list.
            ''
            ''Testing...
            If (bTesting) Then
                Dim bMismatch As Boolean
                ''bMismatch = (mod_dllControlLast IsNot itemForAnchoring_ItemNextToSingle)
                bMismatch = (mod_dllControlFirst IsNot itemForAnchoring_ItemNextToSingle)
                If (bMismatch) Then Debugger.Break()
            End If ''End of ""If (bTesting) Then""

            ''Added 12/18/2023 td
            mod_dllControlFirst = p_toBeInsertedSingleItem

        End If ''end of ""If (anchorHasItemPrior) Then ... Else...""

        ''Set references #1 & #2 of 4
        itemForAnchoring_ItemNextToSingle.DLL_SetItemPrior(itemSingleToInsert)
        itemSingleToInsert.DLL_SetItemNext(itemForAnchoring_ItemNextToSingle)

        ''Set references #3 & #4 of 4
        If (anchorHasItemPrior) Then
            ''Set references #3 & #4 of 4
            temp_itemPriorToAnchor.DLL_SetItemNext(itemSingleToInsert)
            itemSingleToInsert.DLL_SetItemPrior(temp_itemPriorToAnchor)

        ElseIf (p_isChangeOfEndpoint) Then
            ''Do nothing. The calling procedure is already aware of
            ''  the change of endpoint.
        Else
            ''Inform the calling procedures that the endpoint has changed. 
            Throw New RSCEndpointException("New starting point of list.")

        End If ''end of ""If (anchorHasItemPrior) Then ... Else...""

        ''Added 12/19/2023
        mod_intCountOfItems += 1

    End Sub ''Public Sub DLL_InsertOneItemBefore


    Public Sub DLL_InsertRangeEmptyList(p_toBeInsertedRange_FirstItem As TControl,
                                     p_toBeInsertedRange_ItemCount As Integer) _
                                     Implements IDoublyLinkedList(Of TControl).DLL_InsertRangeEmptyList
        ''
        ''Added 12/31/2023 td  
        ''
        Dim itemFirstItemToInsert As IDoublyLinkedItem '' 
        Dim itemLastItemToInsert As IDoublyLinkedItem '' 
        Dim intHowManyItems As Integer

        intHowManyItems = p_toBeInsertedRange_ItemCount

        ''-----------------------------------------------------------------------------------------------------
        ''---- DIFFICULT AND CONFUSING ----
        ''  Here is the "secret sauce" that allows this Generic Type (DLL_List_OfTControl_PLEASE_USE(Of TControl))
        ''  to work... EXPLICIT CASTING!!!  ---12/18/2023
        ''-----------------------------------------------------------------------------------------------------
        itemFirstItemToInsert = CType(p_toBeInsertedRange_FirstItem, IDoublyLinkedItem)
        itemLastItemToInsert = itemFirstItemToInsert.DLL_GetItemNext(-1 + intHowManyItems)

        mod_dllControlFirst = itemFirstItemToInsert
        mod_dllControlLast = itemLastItemToInsert

        ''Let's make 100% sure we have the correct count. 
        If (True Or Testing.TestingByDefault) Then
            Dim tempItem As IDoublyLinkedItem = itemFirstItemToInsert
            Dim intCount As Integer
            While (tempItem IsNot Nothing)
                intCount += 1
                tempItem = tempItem.DLL_GetItemNext()
            End While
            ''Process the manually-counted number,
            ''  throwing an exception if needed. 
            If (intCount = p_toBeInsertedRange_ItemCount) Then
                mod_intCountOfItems = intCount
            Else
                Throw New RSCEndpointException("The count is wrong.")
            End If
        End If ''eND OF ""If (True Or Testing.TestingByDefault) Then""

        ''Administrative.
        If (WE_CLEAN_RANGE_ENDPOINTS_ALWAYS) Then
            itemFirstItemToInsert.DLL_ClearReferencePrior("I"c)
            itemLastItemToInsert.DLL_ClearReferenceNext("I"c)
        End If

    End Sub ''End of ""Public Sub DLL_InsertRangeEmptyList""


    Public Sub DLL_InsertRangeAfter(p_toBeInsertedRange_FirstItem As TControl,
                                    p_toBeInsertedRange_ItemCount As Integer,
                                    p_toUseAsAnchor_ItemPriorToRange As TControl,
                                    p_bIsChangeOfEndPoint As Boolean,
                        Optional ByVal p_toBeInserted_LastItem_Nullable As TControl = Nothing) _
                                    Implements IDoublyLinkedList(Of TControl).DLL_InsertRangeAfter
        ''
        ''                Insert A B C after 7, the preceding anchor (7). (Three items.)
        ''                       |
        ''          1 2 3 4 5 6 7 8 9 10
        '' Result:  1 2 3 4 5 6 7 A B C 8 9 10
        ''
        ''Throw New NotImplementedException()
        ''12/2023 Throw New NotImplementedException()
        Dim itemFirstItemToInsert As IDoublyLinkedItem '' 
        Dim itemLastItemToInsert As IDoublyLinkedItem '' 
        ''Reminder, anchors are applicable AFTER (or DURING) the operation takes place.
        Dim itemForAnchoring_ItemPriorToRange As IDoublyLinkedItem ''Will ultimately precede the range.
        Dim bTesting As Boolean = ciBadgeInterfaces.Testing.TestingByDefault

        ''-----------------------------------------------------------------------------------------------------
        ''---- DIFFICULT AND CONFUSING ----
        ''  Here is the "secret sauce" that allows this Generic Type (DLL_List_OfTControl_PLEASE_USE(Of TControl))
        ''  to work... EXPLICIT CASTING!!!  ---12/18/2023
        ''-----------------------------------------------------------------------------------------------------
        itemFirstItemToInsert = CType(p_toBeInsertedRange_FirstItem, IDoublyLinkedItem)
        ''Reminder, anchors are applicable AFTER (or DURING) the operation takes place.
        itemForAnchoring_ItemPriorToRange = CType(p_toUseAsAnchor_ItemPriorToRange, IDoublyLinkedItem)

        ''Calculate the final item in the range.
        ''
        ''Major call !!
        ''
        ''---itemLastItemToInsert = itemFirstItemToInsert.DLL_GetItemNext(-1 + p_toBeInsertedRange_ItemCount)
        itemLastItemToInsert = GetLastItemInRange(p_toBeInsertedRange_FirstItem,
                                                  p_toBeInsertedRange_ItemCount,
                                                  p_toBeInserted_LastItem_Nullable)

        ''Testing...
        If ((bTesting And WE_CHECK_RANGE_ENDPOINTS_TESTING) Or
                          WE_CHECK_RANGE_ENDPOINTS_ALWAYS) Then
            ''Items passed as primary-operational (vs. anchors) must be cleaned
            ''  of references.
            If (itemFirstItemToInsert.DLL_HasPrior()) Then Debugger.Break()
            ''Check the last item.
            If (itemLastItemToInsert.DLL_HasNext()) Then Debugger.Break()
        End If ''Testing for clean endpoints.

        ''
        ''Save the item prior to the anchor, if it exists.
        ''
        Dim temp_itemNextToAnchor As IDoublyLinkedItem = Nothing
        Dim anchorHasItemNext As Boolean
        anchorHasItemNext = itemForAnchoring_ItemPriorToRange.DLL_HasNext()
        If (anchorHasItemNext) Then
            ''We are _NOT_ at the end of the list.
            ''temp_itemNextToAnchor = itemForAnchoring_ItemPriorToRange.DLL_GetItemPrior()
            temp_itemNextToAnchor = itemForAnchoring_ItemPriorToRange.DLL_GetItemNext()
        Else
            ''
            ''We _ARE_ at the end of the list.
            ''
            ''Testing...
            If (bTesting) Then
                Dim bMismatch As Boolean
                bMismatch = (mod_dllControlLast IsNot itemForAnchoring_ItemPriorToRange)
                If (bMismatch) Then Debugger.Break()
            End If ''End of ""If (bTesting) Then""

            ''Added 12/18/2023 td
            mod_dllControlLast = itemLastItemToInsert

        End If ''end of ""If (anchorHasItemNext) Then... Else..."

        ''Set references #1 & #2 of 4
        Dim temp = itemForAnchoring_ItemPriorToRange.DLL_GetItemNext()
        itemForAnchoring_ItemPriorToRange.DLL_SetItemNext(itemFirstItemToInsert)
        itemFirstItemToInsert.DLL_SetItemPrior(itemForAnchoring_ItemPriorToRange)

        ''If there is a next element, set references #3 & #4 of 4
        If (anchorHasItemNext) Then
            ''Set references #3 & #4 of 4
            temp_itemNextToAnchor.DLL_SetItemPrior(itemLastItemToInsert)
            itemLastItemToInsert.DLL_SetItemNext(temp_itemNextToAnchor)

        ElseIf (p_bIsChangeOfEndPoint) Then
            ''
            ''Do nothing. The calling procedure is already aware of the change of endpoint.
            ''
        Else
            ''Inform  the calling procedures that the endpoint has changed. 
            Throw New RSCEndpointException("New ending point of list.")
            Debugger.Break()

        End If ''end of ""If (anchorHasItemNext) Then ... ElseIf... Else...""

        ''Added 12/19/2023
        mod_intCountOfItems += p_toBeInsertedRange_ItemCount

    End Sub ''ENd Public Sub DLL_InsertRangeAfter


    Public Sub DLL_InsertRangeBefore(p_toBeInsertedRange_FirstItem As TControl,
                                     p_toBeInsertedRange_ItemCount As Integer,
                                     p_toUseAsAnchor_ItemNextToRange As TControl,
                                     p_bIsChangeOfEndPoint As Boolean,
                        Optional ByVal p_toBeInserted_rangeEnd_Nullable As TControl = Nothing) _
                                     Implements IDoublyLinkedList(Of TControl).DLL_InsertRangeBefore
        ''
        ''                Insert A B C before 8, the terminating anchor. (Three items.)
        ''                       |
        ''          1 2 3 4 5 6 7 8 9 10
        '' Result:  1 2 3 4 5 6 7 A B C 8 9 10
        ''
        ''12/2023 Throw New NotImplementedException()
        Dim itemFirstItemToInsert As IDoublyLinkedItem
        Dim itemLastItemToInsert As IDoublyLinkedItem '' 
        ''Reminder, anchors are applicable AFTER (or DURING) the operation takes place.
        Dim itemForAnchoring_ItemNextToRange As IDoublyLinkedItem ''Will ultimately follow the range.
        Dim bTesting As Boolean = ciBadgeInterfaces.Testing.TestingByDefault

        ''-----------------------------------------------------------------------------------------------------
        ''---- DIFFICULT AND CONFUSING ----
        ''  Here is the "secret sauce" that allows this Generic Type (DLL_List_OfTControl_PLEASE_USE(Of TControl))
        ''  to work... EXPLICIT CASTING!!!  ---12/18/2023
        ''-----------------------------------------------------------------------------------------------------
        itemFirstItemToInsert = CType(p_toBeInsertedRange_FirstItem, IDoublyLinkedItem)
        itemForAnchoring_ItemNextToRange = CType(p_toUseAsAnchor_ItemNextToRange, IDoublyLinkedItem)

        ''Calculate the final item in the range.
        ''
        ''Major call !!
        ''
        ''---itemLastItemToInsert = itemFirstItemToInsert.DLL_GetItemNext(-1 + p_toBeInsertedRange_ItemCount)
        itemLastItemToInsert = GetLastItemInRange(p_toBeInsertedRange_FirstItem,
                                                  p_toBeInsertedRange_ItemCount,
                                                  p_toBeInserted_rangeEnd_Nullable)

        If ((bTesting And WE_CHECK_RANGE_ENDPOINTS_TESTING) Or
                          WE_CHECK_RANGE_ENDPOINTS_ALWAYS) Then
            ''
            ''-----POSSIBLY DIFFICULT AND CONFUSING----
            ''Items passed as primary-operational (vs. anchors) must be cleaned
            ''  of references.
            ''
            If (itemFirstItemToInsert.DLL_HasPrior()) Then Debugger.Break()
            If (itemLastItemToInsert.DLL_HasNext()) Then Debugger.Break()

        End If ''Testing for clean endpoints

        ''Save the item prior to the anchor, if it exists. 
        Dim temp_itemPriorToAnchor As IDoublyLinkedItem = Nothing
        Dim bAnchorHasItemPrior As Boolean ''Added 12/18/2023

        If (itemForAnchoring_ItemNextToRange Is Nothing) Then
            ''We are starting from scratch, i.e. an empty list. ---12/31/2023
        Else
            bAnchorHasItemPrior = itemForAnchoring_ItemNextToRange.DLL_HasPrior()
        End If ''If (itemForAnchoring_ItemNextToRange Is Nothing) Then... Else...

        ''-------------------------------------------------------------------
        ''-----------------------DIFFICULT & CONFUSING-----------------------
        ''If possible, capture a reference to the item _BEFORE_ the anchor...
        ''    so that the Inserted Range can be _NEXT_ to that same item. 
        ''    ---12/31/2023 TDOWNES
        If (bAnchorHasItemPrior) Then
            ''Since we are inserting items BEFORE the anchor, we need the
            ''  item pre-operationally located BEFORE the anchor... 
            ''  so that the Inserted Range can be _NEXT_ to that same item. 
            ''
            temp_itemPriorToAnchor = itemForAnchoring_ItemNextToRange.DLL_GetItemPrior()
        Else
            ''
            ''We _ARE_ at the beginning of the list.
            ''
            ''Testing...
            If (bTesting) Then
                Dim bMismatch As Boolean
                ''---bMismatch = (mod_dllControlLast IsNot itemForAnchoring_ItemNextToRange)
                bMismatch = (mod_dllControlFirst IsNot itemForAnchoring_ItemNextToRange)
                If (bMismatch) Then Debugger.Break()
            End If ''End of ""If (bTesting) Then""

            ''Added 12/18/2023 td
            mod_dllControlFirst = p_toBeInsertedRange_FirstItem

        End If ''end of ""If (anchorHasItemPrior) Then ... Else...""

        ''Set references #1 & #2 of 4
        itemForAnchoring_ItemNextToRange.DLL_SetItemPrior(itemLastItemToInsert)
        itemLastItemToInsert.DLL_SetItemNext(itemForAnchoring_ItemNextToRange)

        ''Set references #3 & #4 of 4
        If (bAnchorHasItemPrior) Then
            ''Set references #3 & #4 of 4
            temp_itemPriorToAnchor.DLL_SetItemNext(itemFirstItemToInsert)
            itemFirstItemToInsert.DLL_SetItemPrior(temp_itemPriorToAnchor)

        ElseIf (p_bIsChangeOfEndPoint) Then
            ''Do nothing. The calling procedure is already aware of
            ''  the change of endpoint.
        Else
            ''Inform the calling procedures that the endpoint has changed. 
            Throw New RSCEndpointException("New starting point of list.")

        End If ''end of ""If (anchorHasItemPrior) Then ... Else...""

        ''Added 12/19/2023
        mod_intCountOfItems += p_toBeInsertedRange_ItemCount

    End Sub ''End of Public Sub DLL_InsertRangeBefore


    Public Sub DLL_DeleteItem(ByVal p_item_toDelete As TControl,
                              ByVal p_isChangeOfEndpoint As Boolean) _
                              Implements IDoublyLinkedList(Of TControl).DLL_DeleteItem
        ''
        ''        Delete "4". (Single item.)
        ''                |
        ''          1 2 3 4 5 6 7 8 9 10
        '' Result:  1 2 3 - 5 6 7 8 9 10
        '' Result:  1 2 3 5 6 7 8 9 10
        ''
        ''12/2023 Throw New NotImplementedException()

        Dim itemToDelete = CType(p_item_toDelete, IDoublyLinkedItem)
        Dim itemPriorToDelete As IDoublyLinkedItem = Nothing
        Dim itemFollowingDelete As IDoublyLinkedItem = Nothing
        Dim bDeletingEndOfList As Boolean
        Dim bDeletingStartOfList As Boolean

        bDeletingEndOfList = itemToDelete.DLL_NotAnyNext
        bDeletingStartOfList = itemToDelete.DLL_NotAnyPrior

        ''
        ''Consider start of List 
        ''
        If (bDeletingStartOfList) Then

            If (Not p_isChangeOfEndpoint) Then Throw New RSCEndpointException("No endpoint specified.")
            ''
            ''We are at the beginning of the list.  12/28/2023
            ''
            itemFollowingDelete = itemToDelete.DLL_GetItemNext()

            ''itemFollowingDelete.DLL_ClearReferencePrior("D"c)
            If (itemFollowingDelete Is Nothing) Then
                ''We are probably deleting the ONE & ONLY item in the list.--12/31/2023
            Else
                itemFollowingDelete.DLL_ClearReferencePrior("D"c)
            End If

        ElseIf (bDeletingEndOfList) Then

            If (Not p_isChangeOfEndpoint) Then Throw New RSCEndpointException("No endpoint specified.")
            ''
            ''We are at the end of the list.  12/28/2023
            ''
            itemPriorToDelete = itemToDelete.DLL_GetItemPrior()
            itemPriorToDelete.DLL_ClearReferenceNext("D"c)

        Else
            ''
            ''Modified 12/28/2023
            ''
            itemPriorToDelete = itemToDelete.DLL_GetItemPrior()
            itemFollowingDelete = itemToDelete.DLL_GetItemNext()
            itemPriorToDelete.DLL_SetItemNext(itemFollowingDelete)
            itemFollowingDelete.DLL_SetItemPrior(itemPriorToDelete)

        End If ''End of If (bDeletingStartOfList) Then... Else...

        ''''
        ''''Consider end of List 
        ''''
        ''If (bDeletingEndOfList) Then
        ''
        ''    If (Not p_isChangeOfEndpoint) Then Throw New RSCEndpointException("No endpoint specified.")
        ''
        ''ElseIf (p_isChangeOfEndpoint And itemPriorToDelete Is Nothing) Then
        ''    ''
        ''    ''We are at the beginning of the list.
        ''    ''
        ''    itemFollowingDelete = itemToDelete.DLL_GetItemNext()
        ''    itemFollowingDelete.DLL_ClearReferencePrior("D"c)
        ''
        ''Else
        ''    itemFollowingDelete = itemToDelete.DLL_GetItemNext()
        ''    itemFollowingDelete.DLL_SetItemPrior(itemPriorToDelete)
        ''
        ''End If ''End of If (bDeletingEndOfList) Then... ElseIf... Else...

        ''
        ''Maintain start & end of list. 
        ''
        If (bDeletingStartOfList And bDeletingEndOfList) Then
            ''The list is now empty of the one(1) item it had. 
            mod_dllControlFirst = Nothing
            mod_dllControlLast = Nothing

        ElseIf (bDeletingStartOfList) Then
            ''Save the new starting list item. 
            mod_dllControlFirst = itemFollowingDelete ''itemToDelete

        ElseIf (bDeletingEndOfList) Then
            mod_dllControlLast = itemPriorToDelete ''itemToDelete

        End If ''End of If (bDeletingStartOfList and bDeleting EndOfList) Then... Else...

        ''
        ''Clean range-of-items endpoints!!
        ''
        If (WE_CLEAN_RANGE_ENDPOINTS_ALWAYS) Then

            itemToDelete.DLL_ClearReferencePrior("D"c)
            itemToDelete.DLL_ClearReferenceNext("D"c)

        End If ''If (WE_CLEAN_RANGE_ENDPOINTS_ALWAYS) Then

        ''Added 12/19/2023
        mod_intCountOfItems -= 1

    End Sub ''End of Public Sub DLL_DeleteItem


    ''' <summary>
    ''' To get the last item in a range, this function encapsulates 
    ''' the decision making which either leverages the range count, 
    ''' or utilizes the passed object references.  And checks both
    ''' if we are in a testing mode. 
    ''' </summary>
    ''' <param name="p_itemFirstInRange">The first item in a doubly-linked sublist (a.k.a. range).</param>
    ''' <param name="p_countOfItemsInRange"></param>
    ''' <param name="p_itemLast_Nullable"></param>
    ''' <returns></returns>
    Private Function GetLastItemInRange(p_itemFirstInRange As IDoublyLinkedItem,
                                        p_countOfItemsInRange As Integer,
                                        p_itemLast_Nullable As IDoublyLinkedItem)

        ''Get the last item in the operational range, 
        ''   i.e. the last item that's going to be deleted.
        ''   ---1/11/2024 thomas d. 
        ''
        Dim result_itemLast As IDoublyLinkedItem
        Dim bNoLastItemProvided As Boolean
        bNoLastItemProvided = (p_itemLast_Nullable Is Nothing)

        If (bNoLastItemProvided) Then
            ''
            ''No last item provided, so we have to leverage var. p_count_of_deleteds
            ''
            result_itemLast = p_itemFirstInRange.DLL_GetItemNext(-1 + p_countOfItemsInRange)

        ElseIf (Testing.TestingByDefault) Then

            ''We are testing everything.  So, we will used parameter p_item_toDeleteFirst, and
            ''   compare it to what we get by using var. p_count_of_deleteds.
            ''   ---1/11/2024 td
            Dim itemTemp1 As IDoublyLinkedItem ''   ---1/11/2024 td
            Dim itemTemp2 As IDoublyLinkedItem ''   ---1/11/2024 td
            itemTemp1 = p_itemLast_Nullable
            itemTemp2 = p_itemFirstInRange.DLL_GetItemNext(-1 + p_countOfItemsInRange)
            Dim boolMatches As Boolean ''   ---1/11/2024 td
            boolMatches = itemTemp1 Is itemTemp2
            If (Not boolMatches) Then Debugger.Break()
            result_itemLast = p_itemLast_Nullable

        Else
            ''We will use parameter p_item_toDeleteFirst, and
            ''   simple ignore var. p_count_of_deleteds.
            ''  --1/11/2024 td
            result_itemLast = p_itemLast_Nullable

        End If ''End of ""If (p_item_toDeleteEnd Is Nothing) Then... ElseIf... Else..." 

        Return result_itemLast

    End Function ''ENd of ""Private Function GetLastItemInRange""


    ''Public Sub DLL_DeleteRange_NotUsed(item_toDeleteBegin As TControl, item_toDeleteEndInclusive As TControl,
    ''                           yes_return_list_of_deleteds As Boolean,
    ''                           ByRef count_of_deleteds As Integer,
    ''                           ByRef item_prior_undeleted As TControl, ByRef item_first_deleted As TControl) _
    ''                           Implements IDoublyLinkedList(Of TControl).DLL_DeleteRange_NotUsed
    ''12/18/2023
    ''    Throw New NotImplementedException()
    ''End Sub


    Public Sub DLL_DeleteRange(ByVal p_item_toDeleteFirst As TControl,
                                       ByVal p_count_of_deleteds As Integer,
                                       ByVal p_isChangeOfEndpoint As Boolean,
                              Optional ByVal p_item_toDeleteEnd_Nullable As TControl = Nothing) _
                        Implements IDoublyLinkedList(Of TControl).DLL_DeleteRange
        ''Not needed.            ByRef item_prior_undeleted As TControl,
        ''Not needed.            ByRef item_first_deleted As TControl) _
        ''Throw New NotImplementedException()

        ''
        ''        Delete "4 5 6". (Range of 3 items.)
        ''                | | |
        ''          1 2 3 4 5 6 7 8 9 10
        '' Result:  1 2 3 - - - 7 8 9 10 
        '' Result:  1 2 3 7 8 9 10 
        ''
        Dim itemToDeleteFirst = CType(p_item_toDeleteFirst, IDoublyLinkedItem)
        Dim itemToDeleteLast As IDoublyLinkedItem

        ''Encapsulated 1/11/2024 td
        ''
        ''Major call !!
        ''
        itemToDeleteLast = GetLastItemInRange(p_item_toDeleteFirst, p_count_of_deleteds,
                                              p_item_toDeleteEnd_Nullable)

        Dim itemPriorToDeleteRange As IDoublyLinkedItem = Nothing
        Dim itemFollowingDeleteRange As IDoublyLinkedItem = Nothing
        Dim bDeletingListStartingPoint As Boolean
        Dim bDeletingListEndingPoint As Boolean

        ''bDeletingEndOfList = itemToDeleteFirst.DLL_NotAnyNext()

        bDeletingListStartingPoint = itemToDeleteFirst.DLL_NotAnyPrior()
        bDeletingListEndingPoint = itemToDeleteLast.DLL_NotAnyNext() ''(itemToDeleteFirst Is mod_dllControlLast)

        ''-----------------------------------------------------------------------------------------
        ''-------------------------------Step 1 of 4-----------------------------------------------
        ''Step 1 of 4.  If possible, assign a reference to local var. itemPriorToDeleteRange.
        ''
        If (bDeletingListStartingPoint) Then

            If (Not p_isChangeOfEndpoint) Then Throw New RSCEndpointException("No endpoint specified.")

            ''Save the new starting list item. 
            ''Moved below. 12/31/2023 mod_dllControlFirst = itemFollowingDeleteRange ''itemToDeleteFirst

        Else
            ''Hook together what comes BEFORE range & what comes AFTER range.
            itemPriorToDeleteRange = itemToDeleteFirst.DLL_GetItemPrior()

        End If ''End of ""If (bDeletingListStartpoint) Then... Else..."
        ''-----------------------------------------------------------------------------------------

        ''-----------------------------------------------------------------------------------------
        ''-------------------------------Step 2 of 4-----------------------------------------------
        ''Step 2 of 4.  If possible, assign a reference to local var. itemFollowingDeleteRange.
        ''
        If (bDeletingListEndingPoint) Then

            '' We CANNOT hook together what comes BEFORE range to what comes AFTER, 
            ''   since NOTHING comes after. 
            If (Not p_isChangeOfEndpoint) Then
                Throw New RSCEndpointException("No endpoint specified.")
            End If ''End of ""If (Not p_isChangeOfEndpoint) Then""

            ''Save the new final list item. 
            ''Moved below. 12/31/2023 mod_dllControlLast = itemPriorToDeleteRange ''itemToDeleteLast

        Else
            itemFollowingDeleteRange = itemToDeleteLast.DLL_GetItemNext()

        End If ''End of ""If (bDeletingListStartpoint) Then... Else..."
        ''-----------------------------------------------------------------------------------------

        ''-----------------------------------------------------------------------------------------
        ''-------------------------------Step 3 of 4-----------------------------------------------
        ''Step 3 of 4.  Maintain start & end of list. 
        ''
        If (bDeletingListStartingPoint And bDeletingListEndingPoint) Then
            ''The list is now empty of the one(1) item it had. 
            mod_dllControlFirst = Nothing
            mod_dllControlLast = Nothing

        ElseIf (bDeletingListStartingPoint) Then
            ''Save the new starting list item. 
            mod_dllControlFirst = itemFollowingDeleteRange ''itemToDelete
            ''Clear the "Prior" reference, since
            ''   there are not any "Prior" items... as
            ''   they've been deleted.---12/31/2023
            mod_dllControlFirst.DLL_ClearReferencePrior("D"c)

        ElseIf (bDeletingListEndingPoint) Then
            mod_dllControlLast = itemPriorToDeleteRange ''itemToDelete
            ''Clear the "Next" reference, since
            ''   there are not any "Prior" items... as
            ''   they've been deleted.---12/31/2023
            mod_dllControlLast.DLL_ClearReferenceNext("D"c)

        Else
            ''Added 12/28/2023 Thomas Downes 
            ''
            ''     Create the Indiana-Jones-Temple-of-Doom "rope bridge" that
            ''   bypasses the deleted items.
            ''     (The "Prior" item is the left bank of the narrow canyon, 
            ''   the "Following" item is the right bank of the river gorge.)
            ''
            itemPriorToDeleteRange.DLL_SetItemNext(itemFollowingDeleteRange)
            itemFollowingDeleteRange.DLL_SetItemPrior(itemPriorToDeleteRange)

        End If ''End of If (bDeletingStartOfList and bDeleting EndOfList) Then... Else...
        ''-----------------------------------------------------------------------------------------

        ''-----------------------------------------------------------------------------------------
        ''-------------------------------Step 4 of 5-----------------------------------------------
        ''Step 4 of 5. Clean range-of-items endpoints!!
        ''
        If (WE_CLEAN_RANGE_ENDPOINTS_ALWAYS) Then

            itemToDeleteFirst.DLL_ClearReferencePrior("D"c)
            itemToDeleteLast.DLL_ClearReferenceNext("D"c)

        End If ''If (WE_CLEAN_RANGE_ENDPOINTS_ALWAYS) Then
        ''-----------------------------------------------------------------------------------------

        ''-----------------------------------------------------------------------------------------
        ''-------------------------------Step 5 of 5-----------------------------------------------
        ''Step 5 of 5.  Update the count of items.
        '' 
        mod_intCountOfItems -= p_count_of_deleteds
        ''-----------------------------------------------------------------------------------------

    End Sub ''End Public Sub DLL_DeleteRange

    '' 12/2023
    ''Public Function DLL_ItemNext() As TControl Implements IDoublyLinkedList(Of TControl).DLL_ItemNext
    ''    Throw New NotImplementedException()
    ''End Function
    '' 12/2023
    ''Public Function DLL_ItemPrior() As TControl Implements IDoublyLinkedList(Of TControl).DLL_ItemPrior
    ''    Throw New NotImplementedException()
    ''End Function

    Public Function DLL_GetItemAtIndex(par_index As Integer) As TControl Implements IDoublyLinkedList(Of TControl).DLL_GetItemAtIndex
        ''Throw New NotImplementedException()

        If (par_index = 0) Then

            Return mod_dllControlFirst

        Else

            Dim each_item As IDoublyLinkedItem = mod_dllControlFirst

            For indexFor = 1 To par_index

                If (True Or mod_bTesting) Then
                    If (each_item.DLL_NotAnyNext()) Then
                        Debugger.Break()
                    End If ''End of ""If (each_item.DLL_NotAnyNext()) Then""
                End If ''End of ""If (mod_bTesting) Then""

                each_item = each_item.DLL_GetItemNext()

            Next indexFor

            Return each_item

        End If ''End of ""If (par_index = 0) Then... Else..."

    End Function ''End of ""Public Function DLL_GetItemAtIndex""


    Public Function DLL_IsListEmpty() As Boolean
        ''
        ''Added 12/31/2023 
        ''
        Dim result_bEmptyList As Boolean
        Dim bMatchesCount As Boolean
        result_bEmptyList = (mod_dllControlFirst Is Nothing)
        bMatchesCount = (result_bEmptyList = (mod_intCountOfItems = 0))
        If (Not bMatchesCount) Then Debugger.Break()
        Return result_bEmptyList ''(mod_dllControlFirst Is Nothing)

    End Function ''End of ""Public Function DLL_IsListEmpty() As Boolean""


    ''' <summary>
    ''' Determine whether an logical error exists--the anchor being WITHIN the range.
    ''' </summary>
    ''' <param name="p_rangeStart"></param>
    ''' <param name="p_rangeCount"></param>
    ''' <param name="p_anchor"></param>
    ''' <returns></returns>
    Public Function DLL_RangeIncludesAnchor_Error(p_rangeStart As IDoublyLinkedItem,
                                            p_rangeCount As Integer,
                                            p_anchor As IDoublyLinkedItem) As Boolean
        ''
        ''Added 12/31/2023 
        ''
        Dim bLocatedAnchor As Boolean
        Dim result_bAnchorIsInRange As Boolean
        Dim tempItem As IDoublyLinkedItem = p_rangeStart

        For index = 1 To p_rangeCount
            ''Check to see if it's a match. 
            bLocatedAnchor = (tempItem Is p_anchor)
            result_bAnchorIsInRange = bLocatedAnchor
            ''If needed, throw an RSCException. 
            If (result_bAnchorIsInRange) Then
                ''Exit For
                ''Throw New RSCRangeAnchorException("Range cannot include Anchor")
                Exit For
            End If ''bAnchorIsInRange = bLocatedAnchor

            ''Prepare for next iteration.
            tempItem = tempItem.DLL_GetItemNext()

        Next index

        Return result_bAnchorIsInRange

    End Function ''End of ""Public Function DLL_IsListEmpty() As Boolean""



    ''' <summary>
    ''' Get the indexed item, and if it's a data-cell, check the horizontal alignment.
    ''' </summary>
    ''' <param name="par_index"></param>
    ''' <param name="ptest_cellAlignswHeader">The Row Header's (.Top + .Height/2).</param>
    ''' <returns></returns>
    Public Function DLL_GetItemAtIndex(par_index As Integer,
                                       ptest_cellAlignswHeader As Integer) As TControl Implements IDoublyLinkedList(Of TControl).DLL_GetItemAtIndex
        ''Throw New NotImplementedException()

        Dim resultControl As Windows.Forms.Control ''IDoublyLinkedItem
        ''12/2023 resultControl = CType(DLL_GetItemAtIndex(par_index), TControl) ''Windows.Forms.Control)
        resultControl = CType(DLL_GetItemAtIndex(par_index),
                                IDoublyLinkedItem).DLL_UnboxControl()

        If (mod_bTesting) Then
            ''
            '' Confirm that the Data Cell is along the same horizontal line 
            '' as the Row Header.  (The parameter confirm_alignedHLine)
            ''
            Dim intHorizontalLineRow As Integer ''Added 12/2023 td
            Dim boolNearby As Boolean ''Added 12/2023 td
            Dim boolAtOrBelowTop As Boolean ''Added 12/2023 td
            Dim boolAboveBottom As Boolean ''Added 12/2023 td
            With resultControl
                intHorizontalLineRow = ptest_cellAlignswHeader
                boolAtOrBelowTop = (.Top <= intHorizontalLineRow)
                boolAboveBottom = (intHorizontalLineRow < (.Top + .Height))
                boolNearby = (boolAtOrBelowTop And boolAboveBottom)
            End With
            If (Not boolNearby) Then
                Debugger.Break()
            End If ''End of ""If (Not boolNearby) Then""
        End If ''End of ""If (mod_bTesting) Then""

    End Function ''enD OF ""Public Function DLL_GetItemAtIndex""


    Public Function DLL_GetFirstItem() As TControl

        ''Added 12/27/2023 
        Return mod_dllControlFirst

    End Function ''End of "" Public Function DLL_GetFirstItem()""


    Public Function DLL_GetLastItem() As TControl Implements IDoublyLinkedList(Of TControl).DLL_GetLastItem

        ''Added 12/27/2023 
        Return mod_dllControlLast

    End Function ''End of "" Public Function DLL_GetLastItem()""


    Public Function DLL_GetIndexOfItem(input_item As TControl) As Integer Implements IDoublyLinkedList(Of TControl).DLL_GetIndexOfItem
        ''Throw New NotImplementedException()

        Dim linkedItem As IDoublyLinkedItem
        Dim index As Integer
        linkedItem = CType(input_item, IDoublyLinkedItem)
        index = linkedItem.DLL_CountItemsPrior()
        Return index

    End Function


    Public Function DLL_CountItemsBefore() As Integer Implements IDoublyLinkedList(Of TControl).DLL_CountItemsBefore
        Throw New NotImplementedException()
    End Function


    Public Function DLL_CountItemsAfter() As Integer Implements IDoublyLinkedList(Of TControl).DLL_CountItemsAfter
        Throw New NotImplementedException()
    End Function


    Public Function DLL_CountAllItems() As Integer Implements IDoublyLinkedList(Of TControl).DLL_CountAllItems
        ''Throw New NotImplementedException()
        Return mod_intCountOfItems

    End Function ''End of ""Public Function DLL_CountAllItems()""

    Public Function DLL_IndexExists(par_index As Integer) As Boolean ''Implements IDoublyLinkedList(Of TControl).DLL_CountAllItems
        ''Throw New NotImplementedException()
        Return (par_index < mod_intCountOfItems AndAlso
                par_index >= 0)

    End Function ''End of ""Public Function DLL_IndexExists()""


    Public Function DLL_BuildListToIndex_DEPRECATED(index As Integer) As TControl _
           Implements IDoublyLinkedList(Of TControl).DLL_BuildListToIndex_DEPRECATED
        ''This is suffixed as _DEPRECATED.  --12/31/2023
        Throw New NotImplementedException()
    End Function


    Public Function DLL_BuildListToIndex_DEPRECATED(index As Integer,
                         ByRef count_of_new_items As Integer) As TControl _
           Implements IDoublyLinkedList(Of TControl).DLL_BuildListToIndex_DEPRECATED
        ''This is suffixed as _DEPRECATED.  --12/31/2023
        Throw New NotImplementedException()
    End Function


    Public Function DLL_PopItem(item_toDelete As TControl) As TControl Implements IDoublyLinkedList(Of TControl).DLL_PopItem
        Throw New NotImplementedException()
    End Function


    Public Function DLL_PopItem(index As Integer) As TControl Implements IDoublyLinkedList(Of TControl).DLL_PopItem
        Throw New NotImplementedException()
    End Function


    Public Function DLL_PopRange(indexStart As Integer, countOfItemsToPop As Integer) As TControl Implements IDoublyLinkedList(Of TControl).DLL_PopRange
        Throw New NotImplementedException()
    End Function


    ''' <summary>
    ''' This returns the updated range of selected items, but doesn't flag any individual items.  
    ''' It also allows the user to select a range, by using the Shift key. 
    ''' </summary>
    ''' <param name="par_indexClicked">Indicates the index of the newly-clicked item.</param>
    ''' <param name="par_bShiftKeyPressed">Indicates that the user is using the keyboard Shift key to select a 2nd item to act as the endpoint of a range of items.</param>
    ''' <returns>The range of selected items, as expressed by a tuple of inclusive indices [begin, end].</returns>
    Public Function SelectionRange_DontProcess(par_indexClicked As Integer,
                                               par_bShiftKeyPressed As Boolean) As Tuple(Of Integer, Integer)
        ''
        ''Added 2/29/2024 
        ''
        ''  We will return the new selection-range, but we don't flag individual
        ''  items in the list (.Selected property is unmodified).
        ''
        Const DONT_PROCESS_LIST As Boolean = False
        Dim result_tuple As Tuple(Of Integer, Integer)

        ''Major call!!
        result_tuple = SelectionRange_ProcessList(par_indexClicked, par_bShiftKeyPressed,
                                          DONT_PROCESS_LIST, True)

        Return result_tuple

    End Function ''End of ""Public Function SelectionRange_DontProcess""


    ''' <summary>
    ''' This sets the .Selected property for ALL items in the list, whether
    ''' to True or False.  The .Selected property will be set to True for the item
    ''' whose index matches par_indexClicked.  It also allows the user to select a range, 
    ''' by using the Shift key. 
    ''' </summary>
    ''' <param name="par_indexClicked">Indicates the index of the newly-clicked item.</param>
    ''' <param name="par_bShiftKeyPressed">Indicates that the user is using the keyboard Shift key to select a 2nd item to act as the endpoint of a range of items.</param>
    ''' <param name="par_bDontProcessList">Only return the Range, don't set the .Selected property for all items.</param>
    ''' <param name="par_bDontCleanPriors">Allows more than one range to be selected, through multiple calls.</param>
    ''' <returns>The range of selected items, as expressed by a tuple of inclusive indices [begin, end].</returns>
    Public Function SelectionRange_ProcessList(par_indexClicked As Integer,
                                               par_bShiftKeyPressed As Boolean,
                Optional par_bDontProcessList As Boolean = False,
                Optional par_bDontCleanPriors As Boolean = False) As Tuple(Of Integer, Integer)
        ''
        ''Added 2/29/2024 thomas downes
        ''
        Dim bShift As Boolean = par_bShiftKeyPressed
        Dim priorShifted As Integer
        Dim priorUnshifted As Integer
        Dim lowerIndex As Integer
        Dim upperIndex As Integer

        Const PLACEHOLDER As Integer = -1

        If (mod_tupSelect_LowToUpper Is Nothing) Then

            ''The first integer is the unshifted (no use of shift-key) integer.
            If (bShift) Then
                ''
                ''I considered whether it makes any sense to have -1 as the Unshifted Index.
                ''   However, I don't want to confuse myself by loading a "Shift" index in the 
                ''   first position.     ---2/29/2024 thomas downes
                ''
                ''(Since the user hasn't used the Shift key (yet),
                ''   put PLACEHOLDER as the 2nd value.)
                ''
                mod_tupSelect_NoShiftToShift = New Tuple(Of Integer, Integer)(PLACEHOLDER, par_indexClicked)

            Else
                ''Set the unshifted index, and use PLACEHOLDER for the missing value
                ''   (since the user hasn't used the Shift key, yet)
                mod_tupSelect_NoShiftToShift = New Tuple(Of Integer, Integer)(par_indexClicked, PLACEHOLDER)

            End If ''End of "If (bShift) Then...Ese..."

            ''The first integer is the lower integer.
            mod_tupSelect_LowToUpper = New Tuple(Of Integer, Integer)(par_indexClicked, par_indexClicked)

        Else
            ''
            '' We need to accomodate prior data, prior item clicks. 
            ''
            ''Localize the data into local variables.
            priorUnshifted = mod_tupSelect_NoShiftToShift.Item1
            priorShifted = mod_tupSelect_NoShiftToShift.Item2

            ''The first integer is the unshifted (no use of shift-key) integer.
            If (bShift) Then
                ''Adjust the second integer, the shift-keyed index.
                mod_tupSelect_NoShiftToShift =
                    New Tuple(Of Integer, Integer)(priorUnshifted, par_indexClicked)

            Else
                ''Adjust the first integer, the N0N-shift-keyed index.
                ''  (The shift-keyed index is NOT retained.)
                mod_tupSelect_NoShiftToShift =
                    New Tuple(Of Integer, Integer)(par_indexClicked, PLACEHOLDER)

            End If ''End of "If (bShift) Then...Ese..."

            ''
            ''Prepare the "final" tuple.
            ''
            Dim index_unshifted As Integer
            Dim index_shifted As Integer

            index_unshifted = mod_tupSelect_NoShiftToShift.Item1
            index_shifted = mod_tupSelect_NoShiftToShift.Item2

            lowerIndex = IIf(index_unshifted <= index_shifted, index_unshifted, index_shifted)
            upperIndex = IIf(index_unshifted > index_shifted, index_unshifted, index_shifted)

            ''Account for the fact that we use -1 as a placeholder.
            If (lowerIndex = PLACEHOLDER) Then lowerIndex = upperIndex
            ''The first integer is the lower integer.
            mod_tupSelect_LowToUpper = New Tuple(Of Integer, Integer)(lowerIndex, upperIndex)

        End If ''End of ""If (mod_tupSelect_LowToUpper Is Nothing) Then""

        ''
        ''Process the list.  This will set (or re-set) the .Selected Property,
        ''   for all items in the list.
        ''
        If (par_bDontProcessList) Then
            ''Nothing to do.
        Else
            SelectionRange_ProcessList(mod_tupSelect_LowToUpper, par_bDontCleanPriors)
        End If ''end of  '' If (par_bDontProcessList) Then / Else""

        ''
        ''In the chance that the caller might need feedback...
        ''
        Return mod_tupSelect_LowToUpper

    End Function ''End of ""Public Function SelectionRange_ProcessList""


    Private Sub SelectionRange_ProcessList(par_range As Tuple(Of Integer, Integer),
                    Optional par_bDontCleanPriors As Boolean = False)
        ''
        ''Added 2/29/2024 td
        ''
        '' Set the .Selected property, for all items.
        ''
        Dim currentItem As IDoublyLinkedItem = mod_dllControlFirst
        Dim currIndex As Integer = 0
        Dim bLoopIsDone As Boolean = False
        Dim bPriorToRange As Boolean
        Dim bInsideRange As Boolean
        Dim bNoMoreSettingOrCleaningLeft As Boolean

        Do While (Not bLoopIsDone)

            bPriorToRange = (currIndex < par_range.Item1)
            bInsideRange = (Not bPriorToRange) And (currIndex <= par_range.Item2)

            If (par_bDontCleanPriors) Then
                ''Allow prior [.Selected = True] values to stay True.
                currentItem.Selected = (bInsideRange Or currentItem.Selected)
            Else
                currentItem.Selected = (bInsideRange)
            End If ''End of ""If (par_bDontCleanPriors) Then... Else..."

            ''
            ''Should we continue? 
            ''
            ''Can we terminate the processing?  
            bNoMoreSettingOrCleaningLeft = (par_bDontCleanPriors And (currIndex > par_range.Item2))
            bLoopIsDone = (currentItem.DLL_NotAnyNext() Or
                bNoMoreSettingOrCleaningLeft)
            If (bLoopIsDone) Then Exit Do
            If (currentItem.DLL_NotAnyNext()) Then Exit Do
            ''
            ''Prepare the next iteration.
            ''
            currentItem = currentItem.DLL_GetItemNext()
            currIndex += 1

        Loop ''end of ""Do While (Not bLoopIsDone)""

    End Sub ''Private Sub SelectionRange_ProcessList





End Class
