''
''Added 2/27/2024 thomas downes
''
Imports ciBadgeInterfaces

Public Class TwoCharacterDLLVertical
    Inherits TwoCharacterDLLItem
    Implements IDoublyLinkedItem(Of TwoCharacterDLLVertical)
    ''
    ''Added 2/27/2024 thomas downes
    ''
    Public Sub New(par_twoChars As String)

        MyBase.New(par_twoChars)


    End Sub



    Public Overloads Sub DLL_SetItemNext_OfT(param As IDoublyLinkedItem(Of TwoCharacterDLLVertical)) Implements IDoublyLinkedItem(Of TwoCharacterDLLVertical).DLL_SetItemNext_OfT
        ''Throw New NotImplementedException()
        MyBase.DLL_SetItemNext_OfT(param)
    End Sub

    Public Overloads Sub DLL_SetItemPrior_OfT(param As IDoublyLinkedItem(Of TwoCharacterDLLVertical)) Implements IDoublyLinkedItem(Of TwoCharacterDLLVertical).DLL_SetItemPrior_OfT
        ''Throw New NotImplementedException()
        MyBase.DLL_SetItemPrior_OfT(param)
    End Sub

    Public Function GetItemNext_OfT() As IDoublyLinkedItem(Of TwoCharacterDLLVertical) Implements IDoublyLinkedItem(Of TwoCharacterDLLVertical).DLL_GetItemNext_OfT
        ''Throw New NotImplementedException()
        Return MyBase.DLL_GetItemNext_OfT()
    End Function

    Public Overloads Function DLL_GetItemNext_OfT(param_iterationsOfNext As Integer) As IDoublyLinkedItem(Of TwoCharacterDLLVertical) Implements IDoublyLinkedItem(Of TwoCharacterDLLVertical).DLL_GetItemNext_OfT
        ''Throw New NotImplementedException()
        Return MyBase.DLL_GetItemNext_OfT(param_iterationsOfNext)
    End Function

    Public Overloads Function DLL_GetItemPrior_OfT() As IDoublyLinkedItem(Of TwoCharacterDLLVertical) Implements IDoublyLinkedItem(Of TwoCharacterDLLVertical).DLL_GetItemPrior_OfT
        ''Throw New NotImplementedException()
        Return MyBase.DLL_GetItemNext_OfT()
    End Function

    Public Overloads Function IDoublyLinkedItem_DLL_GetItemPrior_OfT(param_iterationsOfPrior As Integer) As IDoublyLinkedItem(Of TwoCharacterDLLVertical) Implements IDoublyLinkedItem(Of TwoCharacterDLLVertical).DLL_GetItemPrior_OfT
        Throw New NotImplementedException()
    End Function

    Public Overloads Function DLL_UnboxControl_OfT() As TwoCharacterDLLVertical Implements IDoublyLinkedItem(Of TwoCharacterDLLVertical).DLL_UnboxControl_OfT
        Throw New NotImplementedException()
    End Function

    Public Overloads Function DLL_GetNextItemFollowingRange_OfT(param_rangeSize As Integer, param_mayBeNull As Boolean) As IDoublyLinkedItem(Of TwoCharacterDLLVertical) Implements IDoublyLinkedItem(Of TwoCharacterDLLVertical).DLL_GetNextItemFollowingRange_OfT
        Throw New NotImplementedException()
    End Function

End Class
