﻿''
''Added 5/7/2023 thomas downes
''

Imports ciBadgeInterfaces

Public Class RSCFieldColumnList
    Implements IEnumerable(Of RSCFieldColumnV2)
    ''11/2023 Implements IDoublyLinkedList
    ''5/8/2023 Implements IEnumerator(Of RSCFieldColumnV2)
    ''`
    ''Added 5/7/2023 thomas downes
    ''
    '' This is modelled after the Doubly-Linked List 
    ''   from Orange Coast College's A250 C++ Programming 2 class. 
    ''
    Private mod_columnFirstLeft As RSCFieldColumnV2
    Private mod_columnLastRight As RSCFieldColumnV2
    Private mod_numberOfColumns As Integer = 0
    Private mod_columnCurrent As RSCFieldColumnV2 ''Added 5/8/2023 
    Private disposedValue As Boolean

    ''Added 5/9/2023 td 
    Private mod_stackDeletedRSCColumns As Stack(Of RSCFieldColumnV2)

    Public Sub New()

        ''Added 5/8/2023
        Reset()

    End Sub

    Public Function Count() As Integer

        Return mod_numberOfColumns

    End Function ''End of ""Public Function Count() As Integer""

    ''''For a new generic-type interface... 
    ''Public Sub InsertColumnAtFarLeft(par_newColumn As RSCFieldColumnV2)
    ''Public Sub InsertColumnLeftToRight(par_newColumn As RSCFieldColumnV2)
    ''Public Sub InsertColumnAtFarRight(par_newColumn As RSCFieldColumnV2)
    ''Public Sub DeleteColumnFromList(par_columnToDelete As RSCFieldColumnV2)
    ''Private Sub InsertColumnLeftOfSpecified_Quick(par_newColumn As RSCFieldColumnV2,
    ''                                       par_existingCol As RSCFieldColumnV2)
    ''Public Sub InsertColumnLeftOfSpecified(par_newColumn As RSCFieldColumnV2,
    ''                                       par_existingCol As RSCFieldColumnV2)
    ''Public Sub InsertColumnAtIndex(par_newRSCColumn As RSCFieldColumnV2, par_intColumnIndex As Integer)
    ''Private Sub InsertColumnRightOfSpecified_Quick(par_newColumn As RSCFieldColumnV2,
    ''                                       par_existingCol As RSCFieldColumnV2)
    ''Public Sub InsertColumnRightOfSpecified(par_newColumn As RSCFieldColumnV2,
    ''                                       par_existingCol As RSCFieldColumnV2)
    ''Public Sub UndoLastColumnDeletion(Optional ByRef pref_columnRestored As RSCFieldColumnV2 = Nothing)
    ''Public Function IsStillInList(par_existingCol As RSCFieldColumnV2) As Boolean
    ''Public Function GetIndexOf(par_existingCol As RSCFieldColumnV2) As Integer
    ''Public Function GetFirst() As RSCFieldColumnV2
    ''Public Sub SetFirst(par_column As RSCFieldColumnV2)
    ''Public Function GetColumnAtIndex(par_indexOfCol As Integer) As RSCFieldColumnV2


    Public Sub InsertColumnAtFarLeft(par_newColumn As RSCFieldColumnV2)
        ''
        ''Add the specified column to the far-left edge of the spreadsheet.
        ''
        If (mod_columnFirstLeft Is Nothing) Then

            mod_columnFirstLeft = par_newColumn
            mod_numberOfColumns += 1
            If (mod_columnLastRight IsNot Nothing) Then Throw New Exception("Both Left & Right should be Null.")

            ''For the very first item in the collection,
            ''   both mod_columnLastRight & mod_columnFirstLeft
            ''   need to be specified. ---5/8/2023 td
            mod_columnLastRight = par_newColumn

        Else

            mod_columnFirstLeft.FieldColumnNextLeft = par_newColumn
            mod_numberOfColumns += 1
            par_newColumn.FieldColumnNextRight = mod_columnFirstLeft
            mod_columnFirstLeft = par_newColumn

        End If ''|End of ""If (mod_columnFirstLeft Is Nothing) Then... El se..."

    End Sub ''End of ""Public Sub InsertColumnAtFarLeft(par_newColumn As RSCFieldColumnV2)""


    Public Sub InsertColumnLeftToRight(par_newColumn As RSCFieldColumnV2)
        ''
        ''Add the specified column to the far-right edge of the spreadsheet.
        ''  
        ''If this function is called in the following sequence: 
        ''
        ''      InsertColumnLeftToRight(column1)
        ''      InsertColumnLeftToRight(column2)
        ''      InsertColumnLeftToRight(column3)
        ''
        ''then the spreadsheet will appear as follows:
        ''      --------------------------------------
        ''      '  column1  |   column2  |  column3  |
        ''      --------------------------------------
        ''
        ''as might be hoped/expected.  --Thomas Downes
        ''
        InsertColumnAtFarRight(par_newColumn)

    End Sub ''End of ""Public Sub InsertColumnLeftToRight""


    Public Sub InsertColumnAtFarRight(par_newColumn As RSCFieldColumnV2)
        ''
        ''Add the specified column to the far-right edge of the spreadsheet.
        ''
        If (mod_columnLastRight Is Nothing) Then

            mod_columnLastRight = par_newColumn
            mod_numberOfColumns += 1
            If (mod_columnFirstLeft IsNot Nothing) Then Throw New Exception("Both Left & Right should be Null.")

            ''For the very first item in the collection,
            ''   both mod_columnLastRight & mod_columnFirstLeft
            ''   need to be specified. ---5/8/2023 td
            mod_columnFirstLeft = par_newColumn

        Else

            mod_columnLastRight.FieldColumnNextRight = par_newColumn
            mod_numberOfColumns += 1
            par_newColumn.FieldColumnNextLeft = mod_columnLastRight
            mod_columnLastRight = par_newColumn

        End If ''|End of ""If (mod_columnFirstLeft Is Nothing) Then... El se..."

    End Sub ''End of ""Public Sub InsertColumnAtFarLeft(par_newColumn As RSCFieldColumnV2)""


    Public Sub DeleteColumnFromList(par_columnToDelete As RSCFieldColumnV2)
        ''
        ''Added 5/7/2023 thomas downes
        ''
        Dim nextColumn As RSCFieldColumnV2 = mod_columnFirstLeft
        Dim bDone As Boolean = False

        While ((nextColumn IsNot Nothing) And Not bDone)

            If (nextColumn Is par_columnToDelete) Then

                ''Let's remove the column from the chain, by linking the 
                ''   column to the left (of the column to delete) directly
                ''   to the column to the right (of the column to delete),
                ''   therby effectively erasing the column to be deleted. 
                ''  --5/7/2023 
                Dim columnToTheLeft = nextColumn.FieldColumnNextLeft
                Dim columnToTheRight = nextColumn.FieldColumnNextRight

                bDone = True

                If (columnToTheLeft Is Nothing) Then
                    columnToTheRight.FieldColumnNextLeft = Nothing
                ElseIf (columnToTheRight Is Nothing) Then
                    columnToTheLeft.FieldColumnNextRight = Nothing
                Else
                    columnToTheLeft.FieldColumnNextRight = columnToTheRight
                    ''Added 5/10/2023 
                    columnToTheRight.FieldColumnNextLeft = columnToTheLeft
                End If

                mod_numberOfColumns -= 1 ''Decrement the count.

                ''Added 5/10/2023
                ''  Store the deleted column. 
                If (mod_stackDeletedRSCColumns Is Nothing) Then
                    mod_stackDeletedRSCColumns = New Stack(Of RSCFieldColumnV2)
                End If
                mod_stackDeletedRSCColumns.Push(par_columnToDelete)

            Else
                ''
                ''Move to the next column, to see if it matches the parameter!
                ''
                nextColumn = nextColumn.FieldColumnNextRight

            End If ''End of ""If (nextColumn Is par_columnToDelete) Then... Else..."

        End While ''End of ""While (nextColumn IsNot Nothing)""

    End Sub ''End of ""Public Sub DeleteColumnFromList(par_columnToDelete As RSCFieldColumnV2)""   



    Private Sub InsertColumnLeftOfSpecified_Quick(par_newColumn As RSCFieldColumnV2,
                                           par_existingCol As RSCFieldColumnV2)
        ''
        ''Add the specified column to the immediate left of the specified column.
        ''
        ''This is the quick & easy way, it assumes that the existing column is
        ''  part of the list. 
        ''
        Dim tempColumnToTheLeft As RSCFieldColumnV2 = Nothing

        tempColumnToTheLeft = par_existingCol.FieldColumnNextLeft
        par_existingCol.FieldColumnNextLeft = par_newColumn
        mod_numberOfColumns += 1
        par_newColumn.FieldColumnNextRight = par_existingCol
        tempColumnToTheLeft.FieldColumnNextRight = par_newColumn

    End Sub ''End of ""Private Sub InsertColumnLeftOfSpecified_Quick""


    Public Sub InsertColumnLeftOfSpecified(par_newColumn As RSCFieldColumnV2,
                                           par_existingCol As RSCFieldColumnV2)
        ''
        ''Add the specified column to the immediate left of the specified column.
        ''
        Dim boolMatch As Boolean ''= False
        Dim boolMatchAny As Boolean = False
        Dim boolDone As Boolean = False
        Dim tempColumn As RSCFieldColumnV2 = mod_columnFirstLeft
        ''Dim tempColumnToTheLeft As RSCFieldColumnV2 = Nothing

        If (par_existingCol Is Nothing) Then
            System.Diagnostics.Debugger.Break() ''Added 5/22/2023
            Throw New Exception("Parameter is nothing. (InsertColumnLeftOfSpecified)")
        End If  ''End of ""If (par_existingCol Is Nothing) Then""

        If (par_existingCol Is mod_columnFirstLeft) Then
            InsertColumnAtFarLeft(par_newColumn)
            Return
        End If ''End of ""If (par_existingCol Is mod_columnFirstLeft) Then""

        ''
        ''Find the existing column
        ''
        While ((Not boolDone) AndAlso (tempColumn IsNot Nothing))

            boolMatch = (tempColumn Is par_existingCol)
            boolMatchAny = (boolMatch Or boolMatchAny)

            If (boolMatch) Then

                ''tempColumnToTheLeft = tempColumn.FieldColumnNextLeft
                ''tempColumn.FieldColumnNextLeft = par_newColumn
                ''mod_numberOfColumns += 1
                ''par_newColumn.FieldColumnNextRight = tempColumn
                ''tempColumnToTheLeft.FieldColumnNextRight = par_newColumn
                InsertColumnLeftOfSpecified_Quick(par_newColumn, par_existingCol)
                boolDone = True

            End If ''|End of ""If (boolMatch) Then"

            ''Prepare for next iteration.
            tempColumn = tempColumn.FieldColumnNextRight

        End While

        If (Not boolMatchAny) Then Throw New Exception("Existing column was not found.")

    End Sub ''End of ""Public Sub InsertColumnLeftOfSpecified(par_newColumn As RSCFieldColumnV2)""


    Public Sub InsertColumnAtIndex(par_newRSCColumn As RSCFieldColumnV2, par_intColumnIndex As Integer)
        ''
        ''Added 5/8/2023 thomas d.
        ''
        Dim columnExistingAtIndex As RSCFieldColumnV2

        columnExistingAtIndex = GetColumnAtIndex(par_intColumnIndex)
        InsertColumnLeftOfSpecified_Quick(par_newRSCColumn, columnExistingAtIndex)

    End Sub ''End of ""Public Sub InsertColumnAtIndex""


    Private Sub InsertColumnRightOfSpecified_Quick(par_newColumn As RSCFieldColumnV2,
                                           par_existingCol As RSCFieldColumnV2)
        ''
        ''Add the specified column to the immediate right of the specified column.
        ''
        ''This is the quick & easy way, it assumes that the existing column is
        ''  part of the list. 
        ''
        Dim tempColumnToTheRight As RSCFieldColumnV2 = Nothing

        tempColumnToTheRight = par_existingCol.FieldColumnNextRight
        par_existingCol.FieldColumnNextRight = par_newColumn
        mod_numberOfColumns += 1
        par_newColumn.FieldColumnNextLeft = par_existingCol
        tempColumnToTheRight.FieldColumnNextLeft = par_newColumn

    End Sub ''End of ""Private Sub InsertColumnRightOfSpecified_Quick""


    Public Sub InsertColumnRightOfSpecified(par_newColumn As RSCFieldColumnV2,
                                           par_existingCol As RSCFieldColumnV2)
        ''
        ''Add the specified column to the immediate right of the specified column.
        ''
        Dim boolMatch As Boolean = False
        Dim boolMatchAny As Boolean = False
        Dim boolDone As Boolean = False
        Dim tempColumn As RSCFieldColumnV2 = mod_columnLastRight
        Dim tempColumnToTheRight As RSCFieldColumnV2 = Nothing

        ''5/22/2023 If (par_existingCol Is Nothing) Then Throw New Exception("Parameter is nothing.")
        If (par_existingCol Is Nothing) Then
            System.Diagnostics.Debugger.Break() ''Added 5/22/2023
            Throw New Exception("Parameter is nothing. (InsertColumnRightOfSpecified)")
        End If  ''End of ""If (par_existingCol Is Nothing) Then""

        If (par_existingCol Is mod_columnLastRight) Then
            InsertColumnAtFarRight(par_newColumn)
            Return
        End If ''End of ""If (tempColumn Is mod_columnLastRight) Then""

        ''
        ''Find the existing column
        ''
        While ((Not boolDone) AndAlso (tempColumn IsNot Nothing))

            boolMatch = (tempColumn Is par_existingCol)
            boolMatchAny = (boolMatch Or boolMatchAny)

            If (boolMatch) Then

                ''tempColumnToTheRight = tempColumn.FieldColumnNextRight
                ''tempColumn.FieldColumnNextRight = par_newColumn
                ''mod_numberOfColumns += 1
                ''par_newColumn.FieldColumnNextLeft = tempColumn
                ''tempColumnToTheRight.FieldColumnNextLeft = par_newColumn
                InsertColumnRightOfSpecified_Quick(par_newColumn, par_existingCol)
                boolDone = True

            End If ''|End of ""If (boolMatch) Then"

            ''Prepare for next iteration.
            tempColumn = tempColumn.FieldColumnNextLeft

        End While

        If (Not boolMatchAny) Then Throw New Exception("Existing column was not found.")

    End Sub ''End of ""Public Sub InsertColumnRightOfSpecified(par_newColumn As RSCFieldColumnV2)""


    Public Sub RefreshHorizontalPositions(par_indexToStart As Integer,
                                          par_intPixelsOfGap As Integer)
        ''
        ''Added 5/8/2023  
        ''
        Dim objColumnToStart As RSCFieldColumnV2
        objColumnToStart = GetColumnAtIndex(par_indexToStart)

        If (objColumnToStart Is Nothing) Then
            ''
            ''Possibly one of the columns was just deleted.
            ''---6/12/2023 td
            ''
        Else
            ''Object objColumnToStart has a non-null value. 
            RefreshHorizontalPositions(objColumnToStart, par_intPixelsOfGap)

        End If ''End of ""If (objColumnToStart Is Nothing) Then... Else...""

    End Sub ''End of ""Public Sub RefreshHorizontalPositions""


    Public Sub RefreshHorizontalPositions(par_columnRefreshEtcToRight As RSCFieldColumnV2,
                                          par_intPixelsOfGap As Integer)
        ''
        ''Added 5/8/2023  
        ''
        Dim tempColumn As RSCFieldColumnV2 = par_columnRefreshEtcToRight
        Dim tempColumnToTheLeft As RSCFieldColumnV2 = par_columnRefreshEtcToRight.FieldColumnNextLeft
        Dim intNewLeft As Integer

        If (tempColumnToTheLeft Is Nothing) Then
            Throw New Exception("There should be a column to the left of the specified.")
        End If ''End of ""If (tempColumnToTheLeft Is Nothing) Then""

        While (tempColumn IsNot Nothing)

            tempColumnToTheLeft = tempColumn.FieldColumnNextLeft
            intNewLeft = (tempColumnToTheLeft.Left +
                          tempColumnToTheLeft.Width +
                          par_intPixelsOfGap)
            tempColumn.Left = intNewLeft
            tempColumn = tempColumn.FieldColumnNextRight

        End While

    End Sub ''End of ""Public Sub RefreshHorizontalPositions""


    Public Sub UndoLastColumnDeletion(Optional ByRef pref_columnRestored As RSCFieldColumnV2 = Nothing)
        ''
        ''Added 5/9/2023 
        ''
        Dim objColumnToRestore As RSCFieldColumnV2
        Dim bLeftColumnIsInList As Boolean
        Dim bRightColumnIsInList As Boolean

        ''
        ''Take it from the stack of deleted columns.
        ''
        objColumnToRestore = mod_stackDeletedRSCColumns.Pop()

        ''Added 5/10/2023 
        pref_columnRestored = objColumnToRestore

        bLeftColumnIsInList = ((objColumnToRestore.FieldColumnNextLeft IsNot Nothing) _
              AndAlso IsStillInList(objColumnToRestore.FieldColumnNextLeft))
        bRightColumnIsInList = ((objColumnToRestore.FieldColumnNextRight IsNot Nothing) _
              AndAlso IsStillInList(objColumnToRestore.FieldColumnNextRight))

        If (bLeftColumnIsInList) Then

            InsertColumnRightOfSpecified(objColumnToRestore,
                                         objColumnToRestore.FieldColumnNextLeft)

        ElseIf (bRightColumnIsInList) Then

            InsertColumnLeftOfSpecified(objColumnToRestore,
                                         objColumnToRestore.FieldColumnNextRight)

        Else

            InsertColumnAtFarRight(objColumnToRestore)

        End If ''End of ""If (bLeftColumnIsInList) Then ... Else...""

    End Sub ''End of ""Public Sub UndoLastColumnDeletion()""


    Public Function IsStillInList(par_existingCol As RSCFieldColumnV2) As Boolean
        ''
        ''Added 5/09/2023 td
        ''
        Dim boolMatch As Boolean '' = False
        Dim boolMatchAny As Boolean = False
        Dim boolDone As Boolean = False
        Dim tempColumn As RSCFieldColumnV2 = mod_columnFirstLeft
        ''5/2023 Dim tempIndex As Integer = 1

        ''5/22/2023 If (par_existingCol Is Nothing) Then Throw New Exception("Parameter is nothing.")
        If (par_existingCol Is Nothing) Then
            System.Diagnostics.Debugger.Break()
            Throw New Exception("Parameter is nothing. (Function IsStillInList)")
        End If ''ENd of ""If (par_existingCol Is Nothing) Then""

        ''
        ''Find the existing column
        ''
        While ((Not boolDone) AndAlso (tempColumn IsNot Nothing))

            boolMatch = (tempColumn Is par_existingCol)
            boolMatchAny = (boolMatch Or boolMatchAny)

            If (boolMatch) Then

                boolDone = True

            Else
                ''Prepare for next iteration.
                tempColumn = tempColumn.FieldColumnNextRight
                ''5/2023 tempIndex += 1

            End If ''|End of ""If (boolMatch) Then"

        End While

        Return (boolMatchAny)

    End Function ''End of ""Public Function IsStillInList""


    Public Function GetIndexOf(par_existingCol As RSCFieldColumnV2) As Integer
        ''5/2023  Optional par_bRefreshProperty As Boolean = True) As Integer
        ''
        ''Get the index of the specified column.
        ''
        Dim boolMatch As Boolean '' = False
        Dim boolMatchAny As Boolean = False
        Dim boolDone As Boolean = False
        Dim tempColumn As RSCFieldColumnV2 = mod_columnFirstLeft
        Dim tempIndex As Integer = 1

        If (par_existingCol Is Nothing) Then Throw New Exception("Parameter is nothing.")

        ''
        ''Find the existing column
        ''
        While ((Not boolDone) AndAlso (tempColumn IsNot Nothing))

            boolMatch = (tempColumn Is par_existingCol)
            boolMatchAny = (boolMatch Or boolMatchAny)

            If (boolMatch) Then

                boolDone = True

            Else
                ''Prepare for next iteration.
                tempColumn = tempColumn.FieldColumnNextRight
                tempIndex += 1

            End If ''|End of ""If (boolMatch) Then"

        End While

        If (Not boolMatchAny) Then Throw New Exception("Existing column was not found.")

        Return tempIndex

    End Function ''End of ""Public Function GetIndexOf(par_existingCol As RSCFieldColumnV2)""


    Public Function GetFirst() As RSCFieldColumnV2
        ''
        ''Added 5/08/2023 thomas downes
        ''
        Return mod_columnFirstLeft

    End Function ''End of ""Public Function GetFirst() As RSCFieldColumnV2""


    Public Sub SetFirst(par_column As RSCFieldColumnV2)
        ''
        ''Added 5/08/2023 thomas downes
        ''
        mod_columnFirstLeft = par_column

    End Sub ''End of ""Public Sub SetFirst(par_column As RSCFieldColumnV2)""


    Public Function GetColumnAtIndex(par_indexOfCol As Integer) As RSCFieldColumnV2
        ''
        ''Added 5/08/2023 thomas downes
        ''
        Return Item(par_indexOfCol)

    End Function ''End of ""Public Function GetColumnAtIndex""



    Default Public ReadOnly Property Item(ByVal par_index As Integer) As RSCFieldColumnV2
        ''
        ''Added 5/7/2023  
        ''
        Get
            Dim tempIndex As Integer
            Dim tempColumn As RSCFieldColumnV2 = mod_columnFirstLeft

            If (par_index = 0) Then Throw New Exception("Index of 0 is not allowed.")
            If (par_index = 1) Then Return mod_columnFirstLeft

            For tempIndex = 1 To (-1 + par_index)

                tempColumn = tempColumn.FieldColumnNextRight

            Next tempIndex

            Return tempColumn

        End Get

    End Property ''End of ""Public Property Item(par_index As Integer) As RSCFieldColumnV2""


    ''5/8/2023 Public Sub Reset() Implements IEnumerator.Reset
    ''
    ''    ''Added 5/8/2023 thomas d.
    ''    mod_columnCurrent = Nothing ''mod_columnFirstLeft
    ''
    ''End Sub


    ''5/8/2023 Public ReadOnly Property Current() As RSCFieldColumnV2 _
    ''    Implements IEnumerator(Of RSCFieldColumnV2).Current

    ''    ''Added 5/08/2023
    ''    Get
    ''        Return mod_columnCurrent
    ''    End Get

    ''End Property

    ''Private ReadOnly Property IEnumerator_Current As Object Implements IEnumerator.Current
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''End Property

    ''5/8/2023 Public Function MoveNext() As Boolean Implements IEnumerator(Of RSCFieldColumnV2).MoveNext
    ''
    ''    If (mod_columnCurrent Is Nothing) Then
    ''
    ''        mod_columnCurrent = mod_columnFirstLeft
    ''        Return True ''mod_columnCurrent
    ''
    ''    Else
    ''
    ''        Dim bNotDone As Boolean
    ''        mod_columnCurrent = mod_columnCurrent.FieldColumnNextRight
    ''        bNotDone = (mod_columnCurrent IsNot Nothing)
    ''        Return bNotDone ''True ''mod_columnCurrent
    ''
    ''    End If
    ''
    ''End Function ''End of ""Public Function MoveNext() As Boolean""


    Public Function GetEnumerator() As IEnumerator(Of RSCFieldColumnV2) _
        Implements IEnumerable(Of RSCFieldColumnV2).GetEnumerator
        ''
        ''Added 5/8/2023
        ''
        Return New RSCFieldColumnEnumerator(mod_columnFirstLeft)

    End Function


    Private Function IEnumerable_GetEnumerator() As _
        IEnumerator Implements IEnumerable.GetEnumerator
        ''
        ''Added 5/8/2023
        ''
        ''Throw New NotImplementedException()
        Return GetEnumerator()

    End Function


    ''Protected Overridable Sub Dispose(disposing As Boolean)
    ''    If Not disposedValue Then
    ''        If disposing Then
    ''            ' TODO: dispose managed state (managed objects)
    ''        End If

    ''        ' TODO: free unmanaged resources (unmanaged objects) and override finalizer
    ''        ' TODO: set large fields to null
    ''        disposedValue = True
    ''    End If
    ''End Sub

    ' ' TODO: override finalizer only if 'Dispose(disposing As Boolean)' has code to free unmanaged resources
    ' Protected Overrides Sub Finalize()
    '     ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
    '     Dispose(disposing:=False)
    '     MyBase.Finalize()
    ' End Sub

    ''Public Sub Dispose() Implements IDisposable.Dispose
    ''    ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
    ''    Dispose(disposing:=True)
    ''    GC.SuppressFinalize(Me)
    ''End Sub


    ''5/8/2023 Public Function Enumerator() As IEnumerable(Of RSCFieldColumnV2)
    ''    ''
    ''    ''Added 5/8/2023 thomas d.
    ''    ''
    ''    Dim tempColumn As RSCFieldColumnV2 = mod_columnFirstLeft
    ''
    ''    While (tempColumn IsNot Nothing)
    ''
    ''        tempColumn = tempColumn.FieldColumnNextRight
    ''        Return tempColumn
    ''
    ''    End While
    ''
    ''    Return tempColumn
    ''
    ''End Function


End Class
