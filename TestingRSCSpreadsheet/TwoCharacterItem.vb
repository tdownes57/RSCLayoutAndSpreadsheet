
Imports System.Runtime.Intrinsics
Imports ciBadgeInterfaces

Public Class TwoCharacterItem
    Implements IDoublyLinkedItem

    Private mod_prior As TwoCharacterItem
    Private mod_next As TwoCharacterItem
    Private mod_twoChars As String

    Public Sub New(par_twoChars As String, par_prior As TwoCharacterItem)

        mod_prior = par_prior
        ''mod_next = par_next
        mod_twoChars = par_twoChars

    End Sub


    Public Sub New(par_twoChars As String, par_prior As TwoCharacterItem, par_next As TwoCharacterItem)

        mod_prior = par_prior
        mod_next = par_next
        mod_twoChars = par_twoChars

    End Sub


    Public Sub DLL_SetItemNext(param As IDoublyLinkedItem) Implements IDoublyLinkedItem.DLL_SetItemNext
        ''Throw New NotImplementedException()

        mod_next = param

    End Sub


    Public Sub DLL_SetItemPrior(param As IDoublyLinkedItem) Implements IDoublyLinkedItem.DLL_SetItemPrior
        ''Throw New NotImplementedException()
        mod_prior = param

    End Sub

    Public Sub DLL_ClearReferencePrior(par_typeOp As Char) Implements IDoublyLinkedItem.DLL_ClearReferencePrior
        ''Throw New NotImplementedException()
        mod_prior = Nothing

    End Sub

    Public Sub DLL_ClearReferenceNext(par_typeOp As Char) Implements IDoublyLinkedItem.DLL_ClearReferenceNext
        ''Throw New NotImplementedException()
        mod_next = Nothing

    End Sub

    Public Function DLL_NotAnyNext() As Boolean Implements IDoublyLinkedItem.DLL_NotAnyNext
        ''Throw New NotImplementedException()
        Return (mod_next Is Nothing)

    End Function

    Public Function DLL_NotAnyPrior() As Boolean Implements IDoublyLinkedItem.DLL_NotAnyPrior
        ''Throw New NotImplementedException()
        Return (mod_prior Is Nothing)

    End Function

    Public Function DLL_HasNext() As Boolean Implements IDoublyLinkedItem.DLL_HasNext
        ''Throw New NotImplementedException()
        Return (mod_next IsNot Nothing)

    End Function

    Public Function DLL_HasPrior() As Boolean Implements IDoublyLinkedItem.DLL_HasPrior
        ''Throw New NotImplementedException()
        Return (mod_prior IsNot Nothing)

    End Function

    Public Function DLL_GetItemNext() As IDoublyLinkedItem Implements IDoublyLinkedItem.DLL_GetItemNext
        ''Throw New NotImplementedException()
        Return mod_next

    End Function

    Public Function DLL_GetItemNext(param_iterationsOfNext As Integer) As IDoublyLinkedItem Implements IDoublyLinkedItem.DLL_GetItemNext
        ''Throw New NotImplementedException()

        Dim tempNext As TwoCharacterItem = mod_next
        If (param_iterationsOfNext > 1) Then
            For index = 2 To param_iterationsOfNext
                tempNext = tempNext.mod_next
            Next index
        End If
        If (param_iterationsOfNext = 0) Then Return Me
        Return tempNext

    End Function

    Public Function DLL_GetItemPrior() As IDoublyLinkedItem Implements IDoublyLinkedItem.DLL_GetItemPrior
        ''Throw New NotImplementedException()
        Return mod_prior

    End Function

    Public Function DLL_GetItemPrior(param_iterationsOfPrior As Integer) As IDoublyLinkedItem Implements IDoublyLinkedItem.DLL_GetItemPrior
        ''Throw New NotImplementedException()
        ''Dim tempPrior As TwoCharacterItem = mod_prior
        ''If (param_iterationsOfPrior > 1) Then
        ''    For index = 2 To param_iterationsOfPrior
        ''        tempPrior = tempPrior.mod_prior
        ''    Next index
        ''End If
        ''If (param_iterationsOfPrior = 0) Then Return Me
        ''Return tempPrior
        Throw New NotImplementedException

    End Function

    Public Function DLL_UnboxControl() As Control Implements IDoublyLinkedItem.DLL_UnboxControl

        Throw New NotImplementedException()

    End Function
End Class
