''
''Added 11/02/2023 Thomas Downes
''
Public Interface IDoublyLinkedItem
    ''
    ''Added 11/02/2023 Thomas Downes
    ''
    Function DLL_NotAnyNext() As Boolean
    Function DLL_NotAnyPrior() As Boolean

    ''' <summary>
    ''' Is this the end of the list, either the beginning or the endpoint?
    ''' </summary>
    ''' <returns></returns>
    Function DLL_IsEitherEndpoint() As Boolean

    ''' <summary>
    ''' Is there a Next?
    ''' </summary>
    ''' <returns>Returns a True or False.</returns>
    Function DLL_HasNext() As Boolean
    ''' <summary>
    ''' Is there a Next?
    ''' </summary>
    ''' <returns>Returns a True or False.</returns>
    Function DLL_HasPrior() As Boolean

    Function DLL_GetItemNext() As IDoublyLinkedItem
    Function DLL_GetItemNext(param_iterationsOfNext As Integer) As IDoublyLinkedItem

    Function DLL_GetItemPrior() As IDoublyLinkedItem
    Function DLL_GetItemPrior(param_iterationsOfPrior As Integer) As IDoublyLinkedItem

    ''' <summary>
    ''' Gets the underlying control.
    ''' </summary>
    ''' <returns></returns>
    Function DLL_UnboxControl() As Windows.Forms.Control

    Sub DLL_SetItemNext(param As IDoublyLinkedItem)
    Sub DLL_SetItemPrior(param As IDoublyLinkedItem)

    ''
    '' Whenever a Row or Column is deleted, and saved into a DLL Operation,
    ''   the outer edges ---MUST BE CLEANED--- of obselete references.
    ''   ---OTHERWISE, THE DELETE OPERATION CANNOT BE UNDONE & REDONE---.  
    ''
    '' If a surgeon was removing a section of your spine, so it could be 
    ''   transplanted into aonother person, they would probably clean (in some way) 
    ''   the two(2) exposed ends of the vertebra... would they not?  LOL
    ''
    ''   ---11/07/2023 td
    ''
    Sub DLL_ClearReferencePrior(par_typeOp As Char)
    Sub DLL_ClearReferenceNext(par_typeOp As Char)

    ''Added 12/30/2023 
    ''---DIFFICULT AND CONFUSING---
    ''  By CS-related rules of iteration, by moving ahead
    ''  a number of jumps equal to the item-count of the range,
    ''  we get the first post-range item.
    ''  ---12/30/2023
    ''
    ''' <summary>
    ''' Get item following a range (if the implicit parameter is the first item in a range). Sometimes we need the Item which follows the Range, to prepare for a possible Undo.
    ''' </summary>
    ''' <param name="param_rangeSize">This is the item-count of the range, or size of the range.</param>
    ''' <returns>The first item which follows the range.</returns>
    Function DLL_GetNextItemFollowingRange(param_rangeSize As Integer,
                                           param_mayBeNull As Boolean) As IDoublyLinkedItem

    ''Added 1/4/2024 td
    Function DLL_GetValue() As String ''Added 1/4/2024 td

End Interface
