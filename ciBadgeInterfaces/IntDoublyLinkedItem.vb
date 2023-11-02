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

End Interface
