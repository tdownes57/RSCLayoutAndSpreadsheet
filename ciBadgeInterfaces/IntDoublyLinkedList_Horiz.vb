Public Interface IntDoublyLinkedList_Horiz(Of TControl)
    ''
    ''For a new generic-type interface, for Horizontal doubly-linked lists. 
    ''  ---10/25/2023 thomas downes
    ''
    ''
    ''Public Sub InsertColumnAtFarLeft(newColumn As RSCFieldColumnV2)
    ''Public Sub InsertColumnLeftToRight(newColumn As RSCFieldColumnV2)
    ''Public Sub InsertColumnAtFarRight(newColumn As RSCFieldColumnV2)
    ''Public Sub DeleteColumnFromList(columnToDelete As RSCFieldColumnV2)
    ''Private Sub InsertColumnLeftOfSpecified_Quick(newColumn As RSCFieldColumnV2,
    ''                                       existingCol As RSCFieldColumnV2)
    ''Public Sub InsertColumnLeftOfSpecified(newColumn As RSCFieldColumnV2,
    ''                                       existingCol As RSCFieldColumnV2)
    ''Public Sub InsertColumnAtIndex(newRSCColumn As RSCFieldColumnV2, intColumnIndex As Integer)
    ''Private Sub InsertColumnRightOfSpecified_Quick(newColumn As RSCFieldColumnV2,
    ''                                       existingCol As RSCFieldColumnV2)
    ''Public Sub InsertColumnRightOfSpecified(newColumn As RSCFieldColumnV2,
    ''                                       existingCol As RSCFieldColumnV2)
    ''Public Sub UndoLastColumnDeletion(Optional ByRef pref_columnRestored As RSCFieldColumnV2 = Nothing)
    ''Public Function IsStillInList(existingCol As RSCFieldColumnV2) As Boolean
    ''Public Function GetIndexOf(existingCol As RSCFieldColumnV2) As Integer
    ''Public Function GetIndexOf(existingCol As RSCFieldColumnV2) As Integer
    ''Public Function GetFirst() As RSCFieldColumnV2
    ''Public Sub SetFirst(column As RSCFieldColumnV2)
    ''Public Function GetColumnAtIndex(indexOfCol As Integer) As RSCFieldColumnV2

    Function IsStillInList(existingCol As TControl) As Boolean
    Function GetIndexOf(existingCol As TControl) As Integer
    Function GetFirst() As TControl
    Function GetColumnAtIndex(indexOfCol As Integer) As TControl

    Sub SetFirst(column As TControl)
    Sub InsertColumnAtFarLeft(newColumn As TControl)
    Sub InsertColumnLeftToRight(newColumn As TControl)
    Sub InsertColumnAtFarRight(newColumn As TControl)
    Sub DeleteColumnFromList(columnToDelete As TControl)
    Sub InsertColumnAtIndex(newRSCColumn As TControl, intColumnIndex As Integer)
    Sub InsertColumnLeftOfSpecified(newColumn As TControl,
                                           existingCol As TControl)
    Sub InsertColumnRightOfSpecified(newColumn As TControl,
                                           existingCol As TControl)
    ''Private Sub InsertColumnRightOfSpecified_Quick(newColumn As TControl,
    ''                                       existingCol As TControl)
    ''PrivateSub InsertColumnLeftOfSpecified_Quick(newColumn As TControl,
    ''                                       existingCol As TControl)

    Sub UndoLastColumnDeletion(Optional ByRef pref_columnRestored As TControl = Nothing)




End Interface
