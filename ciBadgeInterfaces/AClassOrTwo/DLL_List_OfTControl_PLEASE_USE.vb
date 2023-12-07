''12/2023 Imports System.Data.SqlTypes

''-----------------------------------------------------------
''  Please see CIBadgeDesigner / Classes RSC / RSC_DLL_OperationsManager.
''
''    ---12/07/2023 thomas dow_nes 
''-----------------------------------------------------------
''' <summary>
''' We use casting as a way to access crucial methods. 
''' TControl is RSCFieldColumn, RSCDataHeader, or RSCDataCell.
''' </summary>
''' <typeparam name="TControl"></typeparam>
Public Class DLL_List_OfTControl_PLEASE_USE(Of TControl)
    Implements IDoublyLinkedList(Of TControl)

    Private mod_dllControlFirst As IDoublyLinkedItem ''DLL = Doubly-Linked List. 
    Private mod_bTesting As Boolean

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
        mod_dllControlFirst = CType(par_firstItem, IDoublyLinkedItem)

        mod_bTesting = Testing.TestingByDefault

    End Sub



    Public Sub DLL_InsertItemAfter(toBeInserted As TControl) Implements IDoublyLinkedList(Of TControl).DLL_InsertItemAfter
        ''Throw New NotImplementedException()



    End Sub

    Public Sub DLL_InsertItemAfter(toBeInserted As TControl, toUseAsAnchor As TControl) Implements IDoublyLinkedList(Of TControl).DLL_InsertItemAfter
        Throw New NotImplementedException()
    End Sub

    Public Sub DLL_InsertItemBefore(toBeInserted As TControl) Implements IDoublyLinkedList(Of TControl).DLL_InsertItemBefore
        Throw New NotImplementedException()
    End Sub

    Public Sub DLL_InsertItemBefore(toBeInserted As TControl, toUseAsAnchor As TControl) Implements IDoublyLinkedList(Of TControl).DLL_InsertItemBefore
        Throw New NotImplementedException()
    End Sub

    Public Sub DLL_InsertRangeAfter(toBeInsertedFirst As TControl, toBeInsertedCount As Integer, toUseAsAnchorStart As TControl) Implements IDoublyLinkedList(Of TControl).DLL_InsertRangeAfter
        Throw New NotImplementedException()
    End Sub

    Public Sub DLL_DeleteItem(item_toDelete As TControl) Implements IDoublyLinkedList(Of TControl).DLL_DeleteItem
        Throw New NotImplementedException()
    End Sub

    Public Sub DLL_DeleteRange(item_toDeleteBegin As TControl, item_toDeleteEndInclusive As TControl, yes_return_list_of_deleteds As Boolean, ByRef count_of_deleteds As Integer, ByRef item_prior_undeleted As TControl, ByRef item_first_deleted As TControl) Implements IDoublyLinkedList(Of TControl).DLL_DeleteRange
        Throw New NotImplementedException()
    End Sub

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

    End Function

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

    Public Function DLL_GetIndexOfItem(input_item As TControl) As Integer Implements IDoublyLinkedList(Of TControl).DLL_GetIndexOfItem
        Throw New NotImplementedException()
    End Function

    Public Function DLL_CountItemsBefore() As Integer Implements IDoublyLinkedList(Of TControl).DLL_CountItemsBefore
        Throw New NotImplementedException()
    End Function

    Public Function DLL_CountItemsAfter() As Integer Implements IDoublyLinkedList(Of TControl).DLL_CountItemsAfter
        Throw New NotImplementedException()
    End Function

    Public Function DLL_CountAllItems() As Integer Implements IDoublyLinkedList(Of TControl).DLL_CountAllItems
        Throw New NotImplementedException()
    End Function

    Public Function DLL_BuildListToIndex(index As Integer) As TControl Implements IDoublyLinkedList(Of TControl).DLL_BuildListToIndex
        Throw New NotImplementedException()
    End Function

    Public Function DLL_BuildListToIndex(index As Integer, ByRef count_of_new_items As Integer) As TControl Implements IDoublyLinkedList(Of TControl).DLL_BuildListToIndex
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
End Class
