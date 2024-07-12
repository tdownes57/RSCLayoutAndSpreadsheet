
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

    Function DLL_GetItemNext_OfT() As IDoublyLinkedItem(Of TControl)
    Function DLL_GetItemNext_OfT(param_iterationsOfNext As Integer) As IDoublyLinkedItem(Of TControl)

    Function DLL_GetItemPrior_OfT() As IDoublyLinkedItem(Of TControl)
    Function DLL_GetItemPrior_OfT(param_iterationsOfPrior As Integer) As IDoublyLinkedItem(Of TControl)

    ''' <summary>
    ''' Gets the underlying control.
    ''' </summary>
    ''' <returns></returns>
    Function DLL_UnboxControl_OfT() As TControl
    'Having trouble here. See "using" above. 3/2024  Control DLL_UnboxControl();

    Sub DLL_SetItemNext_OfT(param As IDoublyLinkedItem(Of TControl))
    Sub DLL_SetItemPrior_OfT(param As IDoublyLinkedItem(Of TControl))

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
    Function DLL_GetNextItemFollowingRange_OfT(param_rangeSize As Integer, param_mayBeNull As Boolean) As IDoublyLinkedItem(Of TControl)

End Interface


