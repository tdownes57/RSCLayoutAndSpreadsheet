''
''Added 11/02/2023 Thomas Downes
''
Public Interface IDoublyLinkedItem
    ''
    ''Added 11/02/2023 Thomas Downes
    ''
    Function DLL_NotAnyNext() As Boolean
    Function DLL_NotAnyPrior() As Boolean

    Function DLL_GetItemNext() As IDoublyLinkedItem
    Function DLL_GetItemPrior() As IDoublyLinkedItem

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
    Sub DLL_ClearReferencePrior()
    Sub DLL_ClearReferenceNext()

End Interface
