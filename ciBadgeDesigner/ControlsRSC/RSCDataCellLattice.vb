''
''Added 5/15/2023 Thomas Downes  
''

Imports System.Net

Public Class RSCDataCellLattice
    ''
    ''Added 5/15/2023 Thomas Downes  
    ''
    ''Not needed?  Private mod_cellUpperLeft As RSCDataCell
    ''Not needed?  Private mod_cellUpperRight As RSCDataCell
    ''Not needed?  Private mod_cellLowerLeft As RSCDataCell
    ''Not needed?  Private mod_cellLowerRight As RSCDataCell

    Private mod_dictTopmostCells As New Dictionary(Of RSCFieldColumnV2, RSCDataCell)
    Private mod_dictLeftmostCells As New Dictionary(Of RSCRowHeader, RSCDataCell)


    Public Sub AddColumn(par_column As RSCFieldColumnV2,
                         Optional par_doBuildLatice As Boolean = True,
                         Optional par_intNumRows As Integer = -1)
        ''
        ''Added 5/15/2023 td
        ''
        Dim objTopmostCell As RSCDataCell
        objTopmostCell = par_column.GetFirstRSCDataCell()
        mod_dictTopmostCells.Add(par_column, objTopmostCell)

        If (par_doBuildLatice) Then ''5/2023 If (par_doConnectLeftAndRight) Then
            ''Encapsulated 5/15/2023 
            BuildLatticeByColumn(par_column, par_intNumRows)

        End If ''end of ""If (par_doBuildLatice) Then""

    End Sub ''End of ""Public Sub AddColumn()""


    Public Sub DeleteColumn(par_columnToDelete As RSCFieldColumnV2,
                         Optional par_doMaintainLatice As Boolean = True,
                         Optional par_intNumRows As Integer = -1)
        ''
        ''Added 5/15/2023 td
        ''
        ''Remove the column from the dictionary!!!
        mod_dictTopmostCells.Remove(par_columnToDelete)

        ''
        ''Maintain the latice, if requested by default. 
        ''
        If (par_doMaintainLatice) Then

            ''----Dim objTopmostCell As RSCDataCell = par_columnToDelete.GetFirstRSCDataCell()

            ''Get the columns Left & Right of the Deleted Column.
            Dim columnDeletedsLeft As RSCFieldColumnV2 = par_columnToDelete.GetNextColumn_Left ''.GetFirstRSCDataCell()
            Dim columnDeletedsRight As RSCFieldColumnV2 = par_columnToDelete.GetNextColumn_Right ''.GetFirstRSCDataCell()

            ''Encapsulated 5/15/2023
            If (columnDeletedsLeft Is Nothing) Then

                ''Clear the left-hand connections to be all nulls.
                ClearCellLinks_ToTheLeft(columnDeletedsRight)

            ElseIf (columnDeletedsRight Is Nothing) Then

                ''Clear the right-hand connections to be all nulls.
                ClearCellLinks_ToTheRight(columnDeletedsLeft)

            Else
                ''Maintain the right-hand side of the deleted column's left-hand column.
                ''  (The left-hand side of that same column can be ignored.)
                ''
                ''Also, maintain the left-hand side of the deleted column's right-hand column.
                ''  (The right-hand side of that same column can be ignored.)
                ''
                BuildLatticeByColumn_AdjacentCols(columnDeletedsLeft,
                                                  columnDeletedsRight, par_intNumRows)

            End If ''End of ""If (columnDeletedsLeft IsNot Nothing) Then""

        End If ''end of ""If (par_doMaintainLatice) Then""


    End Sub ''End of ""Public Sub DeleteColumn()""



    Public Sub ClearCellLinks_ToTheLeft(par_columnWhoseLinksToClear As RSCFieldColumnV2,
                                                 Optional par_intNumRows As Integer = -1)
        ''
        ''Added 5/15/2023 td  
        ''
        ClearCellLinks_EitherSide(par_columnWhoseLinksToClear, True, False, par_intNumRows)

    End Sub ''ENd of ""Public Sub ClearCellLinks_ToTheLeft""


    Public Sub ClearCellLinks_ToTheRight(par_columnWhoseLinksToClear As RSCFieldColumnV2,
                                                 Optional par_intNumRows As Integer = -1)
        ''
        ''Added 5/15/2023 td  
        ''
        ClearCellLinks_EitherSide(par_columnWhoseLinksToClear, False, True, par_intNumRows)

    End Sub ''ENd of ""Public Sub ClearCellLinks_ToTheRight""


    Public Sub ClearCellLinks_EitherSide(par_columnWhoseLinksToClear As RSCFieldColumnV2,
                                         par_doClearLeftSide As Boolean,
                                         par_doClearRighSide As Boolean,
                                         Optional par_intNumRows As Integer = -1)
        ''
        ''Added 5/15/2023 td  
        ''
        Dim objTopmostCell As RSCDataCell
        objTopmostCell = par_columnWhoseLinksToClear.GetFirstRSCDataCell()

        Dim tempCell As RSCDataCell = objTopmostCell
        Dim intRowIndex As Integer = 0
        Dim intCountCellsNonnull As Integer = 0

        While (tempCell IsNot Nothing)

            intRowIndex += 1

            ''Clear the Lattice links.
            If (par_doClearRighSide) Then tempCell.CellRight = Nothing
            If (par_doClearLeftSide) Then tempCell.Cell_Left = Nothing

            ''Count non-nulls.
            intCountCellsNonnull += 1

            ''Prepare for next row.
            tempCell = tempCell.CellBelow

        End While ''End of ""While (tempCell IsNot Nothing)""

        ''If we have a number to check against, run checks.
        If (par_intNumRows > 0) Then
            ''Run checks.
            If (intCountCellsNonnull <> par_intNumRows) Then System.Diagnostics.Debugger.Break()

        End If ''End of ""If (par_intNumRows > 0) Then""


    End Sub ''ENd of ""Public Sub ClearCellLinks_ToTheRight()""


    Public Sub BuildLatticeByColumn_AdjacentCols(par_columnLeft As RSCFieldColumnV2,
                                                 par_columnRigh As RSCFieldColumnV2,
                                                 Optional par_intNumRows As Integer = -1)
        ''
        ''Added 5/15/2023
        ''
        ''
        ''Added 5/15/2023 td
        ''
        Dim objTopmostCellLeft As RSCDataCell
        Dim objTopmostCellRigh As RSCDataCell

        If (par_columnLeft Is Nothing) Then Throw New Exception("Left is null")
        If (par_columnRigh Is Nothing) Then Throw New Exception("Right is null")

        objTopmostCellLeft = par_columnLeft.GetFirstRSCDataCell()
        objTopmostCellRigh = par_columnRigh.GetFirstRSCDataCell()

        Dim tempCellLeft As RSCDataCell = objTopmostCellLeft
        Dim tempCellRigh As RSCDataCell = objTopmostCellRigh
        Dim intRowIndex As Integer = 0
        Dim intCountCellsNonnull As Integer = 0

        While (tempCellLeft IsNot Nothing)

            intRowIndex += 1

            ''Build the Lattice.
            tempCellLeft.CellRight = tempCellRigh
            tempCellRigh.Cell_Left = tempCellLeft

            ''Count non-nulls.
            intCountCellsNonnull += 1

            ''Prepare for next row.
            tempCellLeft = tempCellLeft.CellBelow
            tempCellRigh = tempCellRigh.CellBelow

        End While ''End of ""While (tempCell IsNot Nothing)""

        ''If we have a number to check against, run checks.
        If (par_intNumRows > 0) Then
            ''Run checks.
            If (intCountCellsNonnull <> par_intNumRows) Then System.Diagnostics.Debugger.Break()
        End If ''End of ""If (par_intNumRows > 0) Then""


    End Sub ''End of ""Public Sub BuildLatticeByColumn_AdjacentCols""


    Public Sub BuildLatticeByColumn_OneCol(par_column As RSCFieldColumnV2,
                         Optional par_intNumRows As Integer = -1,
                                    Optional par_bSkipLeft As Boolean = False,
                                    Optional par_bSkipRigh As Boolean = False)
        ''
        ''Added 5/15/2023 td
        ''
        Dim objTopmostCell As RSCDataCell
        objTopmostCell = par_column.GetFirstRSCDataCell()

        Dim tempCell As RSCDataCell = objTopmostCell
        Dim columnLeft As RSCFieldColumnV2 = par_column.GetNextColumn_Left ''.GetFirstRSCDataCell()
        Dim columnRigh As RSCFieldColumnV2 = par_column.GetNextColumn_Right ''.GetFirstRSCDataCell()

        Dim bHasLeftCells As Boolean = (columnLeft IsNot Nothing)
        Dim bHasRighCells As Boolean = (columnRigh IsNot Nothing)

        Dim tempCellLeft As RSCDataCell = Nothing
        Dim tempCellRigh As RSCDataCell = Nothing

        If (bHasLeftCells) Then tempCellLeft = columnLeft.GetFirstRSCDataCell()
        If (bHasRighCells) Then tempCellRigh = columnRigh.GetFirstRSCDataCell()

        Dim intRowIndex As Integer = 0
        Dim intCountCellsNonnull As Integer = 0
        Dim intCountCellsLeft As Integer = 0
        Dim intCountCellsRigh As Integer = 0
        Dim bAssignLeft As Boolean = (bHasLeftCells AndAlso (Not par_bSkipLeft))
        Dim bAssignRigh As Boolean = (bHasRighCells AndAlso (Not par_bSkipRigh))

        While (tempCell IsNot Nothing)

            intRowIndex += 1

            ''Build the Lattice.
            If (bAssignLeft) Then tempCell.Cell_Left = tempCellLeft
            If (bAssignRigh) Then tempCell.CellRight = tempCellRigh

            ''Count non-nulls.
            intCountCellsNonnull += 1
            If (bAssignLeft) Then If (tempCellLeft IsNot Nothing) Then intCountCellsLeft += 1
            If (bAssignRigh) Then If (tempCellRigh IsNot Nothing) Then intCountCellsRigh += 1

            ''Prepare for next row.
            tempCell = tempCell.CellBelow
            If (bAssignLeft) Then tempCellLeft = tempCellLeft.CellBelow
            If (bAssignRigh) Then tempCellRigh = tempCellRigh.CellBelow

        End While ''End of ""While (tempCell IsNot Nothing)""

        ''If we have a number to check against, run checks.
        If (par_intNumRows > 0) Then
            ''Run checks.
            If (intCountCellsNonnull <> par_intNumRows) Then System.Diagnostics.Debugger.Break()
            Dim bMismatchCountLeft As Boolean = (intCountCellsLeft <> par_intNumRows)
            Dim bMismatchCountRigh As Boolean = (intCountCellsLeft <> par_intNumRows)
            If (bAssignLeft AndAlso bMismatchCountLeft) Then System.Diagnostics.Debugger.Break()
            If (bAssignRigh AndAlso bMismatchCountRigh) Then System.Diagnostics.Debugger.Break()
        End If ''End of ""If (par_intNumRows > 0) Then""


    End Sub ''End of ""Public Sub BuildLatticeByColumn_OneCol()""


    Public Function TopCellByColumn(par_column As RSCFieldColumnV2) As RSCDataCell
        ''
        ''Added 5/15/2023 td  
        ''
        Return mod_dictTopmostCells.Item(par_column)

    End Function ''End of ""Public Function TopCellOfColumn(par_column As RSCFieldColumnV2) As RSCDataCell""


    Public Function LeftCellByRowHeader(par_rowHeader As RSCRowHeader) As RSCDataCell
        ''
        ''Added 5/15/2023 td  
        ''
        Return mod_dictLeftmostCells.Item(par_rowHeader)

    End Function ''End of ""Public Function LeftCellByRowHeader(par_column As RSCFieldColumnV2) As RSCDataCell""




End Class
