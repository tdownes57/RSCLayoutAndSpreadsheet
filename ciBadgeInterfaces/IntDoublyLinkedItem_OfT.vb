
''Public Interface IDoublyLinkedItem(Of TControl)
''    Inherits IDoublyLinkedItem

''    ''' <summary>
''    ''' Gets the underlying control.
''    ''' </summary>
''    ''' <returns></returns>
''    Function DLL_UnboxControl_OfT() As TControl ''Windows.Forms.Control



''End Interface


''' <summary>
''' This is a generically-typed interface. The non-generic base-interface  
''' is a subset of methods, naturally those methods which are NOT repeat NOT 
''' generically-typed.
''' </summary>
''' <typeparam name="TControl">Usually a type of user-control which is repeated many times.</typeparam>
Public Interface IDoublyLinkedItem(Of TControl)
    Inherits IDoublyLinkedItem

    '-----------------------------------------------------------------------------
    '-----------------------------------------------------------------------------
    ' The following are generic-type methods. 
    '
    ' (I am moving these to generically-type public interface IDoublyLinkedItem(Of TControl),
    ' versus public interface IDoublyLinkedItem.)
    '
    ' For the NON-generically-typed methods, see the following, declared below this
    ' current interface.
    '
    ' public interface IDoublyLinkedItem
    '
    ' As you can see, this generically-typed interface derives from the non-generic
    ' interface. (See "... : IDoublyLinkedItem" above).
    '
    ' ---Thomas C. Downes, 3/12/2024
    '
    '-----------------------------------------------------------------------------
    '-----------------------------------------------------------------------------

    Function DLL_GetItemNext_OfT() As TControl ''Sept 2024 'IDoublyLinkedItem(Of TControl)
    Function DLL_GetItemNext_OfT(param_iterationsOfNext As Integer) As TControl ''Sept 2024 'IDoublyLinkedItem(Of TControl)

    Function DLL_GetItemPrior_OfT() As TControl ''Sept 2024 'IDoublyLinkedItem(Of TControl)
    Function DLL_GetItemPrior_OfT(param_iterationsOfPrior As Integer) As TControl ''Sept 2024 'IDoublyLinkedItem(Of TControl)

    ''' <summary>
    ''' Gets the underlying control.
    ''' </summary>
    ''' <returns></returns>
    Function DLL_UnboxControl_OfT() As TControl
    'Having trouble here. See "using" above. 3/2024  Control DLL_UnboxControl();

    Sub DLL_SetItemNext_OfT(param As TControl) ''Sept 2024 'IDoublyLinkedItem(Of TControl))
    Sub DLL_SetItemPrior_OfT(param As TControl) ''Sept 2024 'IDoublyLinkedItem(Of TControl))

    Sub DLL_SetItemNext_OfT(param As TControl, pbAllowNulls As Boolean) ''Sept 2024 'IDoublyLinkedItem(Of TControl))
    Sub DLL_SetItemPrior_OfT(param As TControl, pbAllowNulls As Boolean) ''Sept 2024 'IDoublyLinkedItem(Of TControl))

    ''Added 12/22/2024 thomas downes
    Sub DLL_SetItemNext_OfT(param As TControl, pbAllowNulls As Boolean, pboolDoublyLink As Boolean) ''Sept 2024 'IDoublyLinkedItem(Of TControl))


    Sub DLL_InsertItemToNext(param As TControl, pbSetDoubleLinks As Boolean) ''Sept 2024 'IDoublyLinkedItem(Of TControl))

    Sub DLL_InsertItemToPrior(param As TControl, pbSetDoubleLinks As Boolean) ''Added 10/17/2024  

    ' Added 12/30/2023 
    ' ---DIFFICULT AND CONFUSING---
    ' By CS-related rules of iteration, by moving ahead
    ' a number of jumps equal to the item-count of the range,
    ' we get the first post-range item.
    ' ---12/30/2023
    ''' <summary>
    ''' Get item following a range (if the implicit parameter is the first item in a range). Sometimes we need the Item which follows the Range, to prepare for a possible Undo.
    ''' </summary>
    ''' <param name="param_rangeSize">This is the item-count of the range, or size of the range.</param>
    ''' <returns>The first item which follows the range.</returns>
    Function DLL_GetNextItemFollowingRange_OfT(param_rangeSize As Integer, param_mayBeNull As Boolean) As TControl ''Sept 2024 'IDoublyLinkedItem(Of TControl)

    ''
    '' Added 10/31/2024 
    ''

    Function DLL_GetDistanceTo(paramItem As TControl) As Integer
    Function DLL_GetDistanceTo(paramItem As TControl, ByRef pboolLocatedSuccessfully As Boolean) As Integer

    ''
    '' Added 11/12/2024 
    ''
    Function DLL_GetItemIndex() As Integer

    ''
    ''
    ''DIFFICULT AND CONFUSING -- PRIOR SORT ORDERS -- Added 12/12/2024
    ''
    ''
    ''---------Sub DLL_SetItemNext_PriorSortOrder(param As TControl) ''Added 12/12/2024 th.do.
    ''---------Function DLL_GetItemNext_PriorSortOrder() As TControl ''Added 12/12/2024 th.do.

    ''12/29/2024 td''Sub DLL_RestorePriorSortOrder() ''Added 12/12/2024 th.do.
    Sub DLL_RestorePriorSortOrder(par_countdownItems As Integer) ''Added 12/12/2024 th.do.

    Sub DLL_SaveCurrentSortOrder_ToPrior(pbExecuteInCascade As Boolean) ''Added 12/12/2024 th.do.
    Sub DLL_ClearPriorSortOrder(pbExecuteInCascade As Boolean) ''Added 12/12/2024 th.do.

    Function DLL_GetItemFirst() As TControl ''Added 12/29/2024 th.do.
    Function DLL_GetItemLast() As TControl ''Added 12/12/2024 th.do.

    ''//Not neded here.  See base interface. 12/15/2024
    ''//  Function DLL_GetValue() As String ''Added 12/12/2024 th.do.

    ''
    ''Convert to the same-index item in a list of another type.
    ''
    ''
    ''' <summary>
    ''' Convert to the same-index item in a (parallel) list of a different, specified type.  
    ''' The first item of the parallel list must be provided.
    ''' For example, if the current item is the 3rd item in a list of type T, 
    ''' then the 3rd item of the parallel list is returned.
    ''' Example: RSCRowHeader items will return (using this function) the same-indexed RSCDataCell.
    ''' </summary>
    ''' <typeparam name="T_BaseOrParallel"></typeparam>
    ''' <param name="firstItem"></param>
    ''' <returns></returns>
    Function GetConvertToGeneric_OfT(Of T_BaseOrParallel)(firstItem As T_BaseOrParallel) As T_BaseOrParallel

End Interface


