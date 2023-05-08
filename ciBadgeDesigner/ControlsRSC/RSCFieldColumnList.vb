''
''Added 5/7/2023 thomas downes
''

Public Class RSCFieldColumnList
    ''
    ''Added 5/7/2023 thomas downes
    ''
    '' This is modelled after the Doubly-Linked List 
    ''   from Orange Coast College's A250 C++ Programming 2 class. 
    ''
    Private mod_columnFirstLeft As RSCFieldColumnV2
    Private mod_columnLastRight As RSCFieldColumnV2
    Private mod_numberOfColumns As Integer = 0

    Public Function Count() As Integer

        Return mod_numberOfColumns

    End Function ''End of ""Public Function Count() As Integer""


    Public Sub InsertColumnAtFarLeft(par_newColumn As RSCFieldColumnV2)
        ''
        ''Add the specified column to the far-left edge of the spreadsheet.
        ''
        If (mod_columnFirstLeft Is Nothing) Then

            mod_columnFirstLeft = par_newColumn
            mod_numberOfColumns += 1
            If (mod_columnLastRight IsNot Nothing) Then Throw New Exception("Both Left & Right should be Null.")
            mod_columnLastRight = par_newColumn

        Else

            mod_columnFirstLeft.FieldColumnNextLeft = par_newColumn
            mod_numberOfColumns += 1
            par_newColumn.FieldColumnNextRight = mod_columnFirstLeft
            mod_columnFirstLeft = par_newColumn

        End If ''|End of ""If (mod_columnFirstLeft Is Nothing) Then... El se..."

    End Sub ''End of ""Public Sub InsertColumnAtFarLeft(par_newColumn As RSCFieldColumnV2)""


    Public Sub InsertColumnAtFarRight(par_newColumn As RSCFieldColumnV2)
        ''
        ''Add the specified column to the far-right edge of the spreadsheet.
        ''
        If (mod_columnLastRight Is Nothing) Then

            mod_columnLastRight = par_newColumn
            mod_numberOfColumns += 1
            If (mod_columnFirstLeft IsNot Nothing) Then Throw New Exception("Both Left & Right should be Null.")
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
                End If

                mod_numberOfColumns -= 1 ''Decrement the count.

            Else
                ''
                ''Move to the next column, to see if it matches the parameter!
                ''
                nextColumn = nextColumn.FieldColumnNextRight

            End If ''End of ""If (nextColumn Is par_columnToDelete) Then... Else..."

        End While ''End of ""While (nextColumn IsNot Nothing)""

    End Sub ''End of ""Public Sub DeleteColumnFromList(par_columnToDelete As RSCFieldColumnV2)""   



    Public Sub InsertColumnLeftOfSpecified(par_newColumn As RSCFieldColumnV2,
                                           par_existingCol As RSCFieldColumnV2)
        ''
        ''Add the specified column to the immediate left of the specified column.
        ''
        Dim boolMatch As Boolean = False
        Dim boolMatchAny As Boolean = False
        Dim boolDone As Boolean = False
        Dim tempColumn As RSCFieldColumnV2 = mod_columnFirstLeft
        Dim tempColumnToTheLeft As RSCFieldColumnV2 = Nothing

        If (par_existingCol Is Nothing) Then Throw New Exception("Parameter is nothing.")

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

                tempColumnToTheLeft = tempColumn.FieldColumnNextLeft
                tempColumn.FieldColumnNextLeft = par_newColumn
                mod_numberOfColumns += 1
                par_newColumn.FieldColumnNextRight = tempColumn
                tempColumnToTheLeft.FieldColumnNextRight = par_newColumn
                boolDone = True

            End If ''|End of ""If (boolMatch) Then"

            ''Prepare for next iteration.
            tempColumn = tempColumn.FieldColumnNextRight

        End While

        If (Not boolMatchAny) Then Throw New Exception("Existing column was not found.")

    End Sub ''End of ""Public Sub InsertColumnLeftOfSpecified(par_newColumn As RSCFieldColumnV2)""



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

        If (par_existingCol Is Nothing) Then Throw New Exception("Parameter is nothing.")

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

                tempColumnToTheRight = tempColumn.FieldColumnNextRight
                tempColumn.FieldColumnNextRight = par_newColumn
                mod_numberOfColumns += 1
                par_newColumn.FieldColumnNextLeft = tempColumn
                tempColumnToTheRight.FieldColumnNextLeft = par_newColumn
                boolDone = True

            End If ''|End of ""If (boolMatch) Then"

            ''Prepare for next iteration.
            tempColumn = tempColumn.FieldColumnNextLeft

        End While

        If (Not boolMatchAny) Then Throw New Exception("Existing column was not found.")

    End Sub ''End of ""Public Sub InsertColumnRightOfSpecified(par_newColumn As RSCFieldColumnV2)""



End Class
