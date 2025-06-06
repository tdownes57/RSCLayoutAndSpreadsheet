﻿''
''Added 11/02/2023 Thomas Downes
''
Public Interface IDoublyLinkedItem
    ''
    ''Added 11/02/2023 Thomas Downes
    ''
    Property Selected As Boolean
    Property HighlightInGreen As Boolean ''Added 11/06/2024 thomas downes
    Property HighlightInRed As Boolean ''Added 11/06/2024 thomas downes
    Property HighlightInBlue As Boolean ''Added 11/06/2024 thomas downes
    Property HighlightInCyan As Boolean ''Added 11/10/2024 thomas downes

    Sub DLL_DrawColors() ''Implement highlighting &/or selection indicators.  --Added 4/21/2025 td

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

    '' <summary>
    '' Gets the underlying control.
    '' </summary>
    '' <returns></returns>
    ''Not needed anymore. 1/23/2025 td''Function DLL_UnboxControl() As Windows.Forms.Control

    Sub DLL_SetItemNext(param As IDoublyLinkedItem)
    Sub DLL_SetItemPrior(param As IDoublyLinkedItem)

    ''Added 12/22/2024 thomas 
    Sub DLL_SetItemNext(param As IDoublyLinkedItem, pboolAllowNulls As Boolean, pboolDoublyLinkIt As Boolean)

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

    Sub DLL_MarkAsEndOfList(Optional pleaseRemoveMarkFromPrior As Boolean = True,
                            Optional pleaseRemoveMarkFromThis As Boolean = False) ''Added 4/15/2025 thomas d.

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

    ''Added 1/13/2024 thomas downes
    ''' <summary>
    ''' This provides a counting of all items in the entire list, regardless of the location of this item.
    ''' (A count of all items...one(1) for present item, plus prior items, plus next items.)
    ''' </summary>
    ''' <returns>A count of all items...one(1) for present item, plus prior items, plus next items.</returns>
    Function DLL_CountItemsAllInList() As Integer
    Function DLL_CountItemsPrior() As Integer
    ''1/13/2024 Function DLL_CountItemsNext() As Integer

    ''--- Added 11/29/2024 tho.mas dow.nes
    Function DLL_CountItemsAfter() As Integer

    ''Added Feb2025 thomas downes
    Function ToString(par_appendNextToString As Boolean) As String ''Boolean

    ''Added 5/03/2025 
    Sub DLL_NotifyOfFocus() ''Added 5/03/2025 tdow

End Interface
