
Option Explicit On
Option Strict On
Option Infer Off

''
''Added 3/23/2022 td
''
Imports ciBadgeInterfaces
Imports ciBadgeDesigner
Imports ciBadgeElements
Imports __RSCWindowsControlLibrary ''Added 1/2/2022 td 
Imports ciBadgeCachePersonality ''Added 1/18/2022 td
Imports System.Drawing ''Added 1/26/2022 td

''
'' Added 3/23/2022 thomas downes
''
Public Class Operations_RSCRowHeaders
    Implements ICurrentElement ''Added 3/19/2022 td
    Implements IRightClickMouseInfo ''Added 3/19/2022 td

    ''
    ''Added 3/29/2022 td
    ''
    Public Property Element_Type As Enum_ElementType = Enum_ElementType.RSCSheetRowHeader ''Added 1/21/2022 td

    ''Added 1/25/2022 td 
    Public Property Designer As ciBadgeDesigner.ClassDesigner ''Added 1/25/2022 td

    Public Property EventsForMoveability_Single As GroupMoveEvents_Singleton ''Suffixed 1/11/2022 Added 1/3/2022 td 
    Public Property EventsForMoveability_Group As GroupMoveEvents_Singleton ''Added 1/11/2022 td 
    Public Property LayoutFunctions As ILayoutFunctions ''Added 1/4/2022 td

    Public Property CtlCurrentControl As Control ''---Implements ICurrentElement.CtlCurrentElement


    Public Overridable Property CtlCurrentElement As RSCMoveableControlVB Implements ICurrentElement.CtlCurrentElement
    Public Property ElementsCacheManager As ciBadgeCachePersonality.ClassCacheManagement Implements ICurrentElement.ElementsCacheManager

    ''Added 2/05/2022 td
    Public Property MouseclickX As Integer Implements IRightClickMouseInfo.MouseclickX
    Public Property MouseclickY As Integer Implements IRightClickMouseInfo.MouseclickY
    Public Property ParentSpreadsheet As RSCFieldSpreadsheet ''Added 3/20/2022 td
    Public Property ParentRowHeaders As RSCRowHeaders ''Added 5/02/2022 td
    Public Property ColumnIndex As Integer ''Added 3/20/2022 td
    ''----Public Property RowIndex As Integer ''Added 4/24/2022 td
    Public Property RowIndex_LastClicked As Integer ''Added 4/25/2022 td

    Public Sub Context_Menu_FS9121(sender As Object, e As EventArgs)
        ''---Dec15 2021--Public Sub How_Context_Menus_Are_Generated_EE1001
        ''
        ''Added 3/22/2023 thomas downes  
        ''
        ''   We will use Reflection to convert the procedures in class Operations_EditFieldElement to clickable LinkLabels.
        ''      (See procedure MenuCache_FieldElements.Generate_BasicEdits().)
        ''
        ''
        Dim strPathToNotesFolder As String
        Dim strPathToNotesFileTXT As String

        strPathToNotesFolder = DiskFolders.PathToFolder_Notes()
        strPathToNotesFileTXT = DiskFilesVB.PathToNotes_HowContextMenusAreGenerated()
        System.Diagnostics.Process.Start(strPathToNotesFileTXT)

    End Sub ''end of "Public Sub Context_Menu_FS9121(sender As Object, e As EventArgs)"


    Public Sub Clear_Data_From_Row_FS2801(sender As Object, e As EventArgs)
        ''
        ''Added 4/24/2022 thomas downes
        ''         
        Dim objRSCFieldColumn As RSCFieldColumnV2 ''4/9/2022 td RSCFieldColumnV1
        Dim boolConfirmed As Boolean

        boolConfirmed = (MessageBoxTD.Show_Confirmed("Clear all data from this row of the spreadsheet?",
                                                     "(To undo, hit Cancel or select Undo.)", True))

        If (boolConfirmed) Then
            ''4/09/2022 td''For Each each_column As RSCFieldColumnV1 In Me.ParentSpreadsheet.ListOfColumns
            For Each each_column As RSCFieldColumnV2 In Me.ParentSpreadsheet.ListOfColumns
                objRSCFieldColumn = each_column ''---CType(each_column, RSCFieldColumn)
                ''4/24/2022 td ''objRSCFieldColumn.ClearDataFromColumn_Do()
                ''4/25/2022 td ''objRSCFieldColumn.ClearDataFromRow_Do(Me.RowIndex_LastClicked)

                ''Added 4/25/2022 thomas downes
                Dim intRowIndex As Integer
                intRowIndex = Me.RowIndex_LastClicked
                If (intRowIndex <= 0) Then
                    ''Added 4/25/2022 thomas downes
                    System.Diagnostics.Debugger.Break()
                ElseIf (intRowIndex > 0) Then
                    objRSCFieldColumn.ClearRow_ByRowIndex(intRowIndex) '' Me.RowIndex_LastClicked)
                End If ''End of ""If (intRowIndex > 0) Then""

            Next each_column
        End If ''End of "If (boolConfirmed) Then"

    End Sub ''end of Public Sub Clear_Data_From_Column_FS2801


    Public Sub Delete_Row_or_Rows_from_Spreadsheet_FS2802(sender As Object, e As EventArgs)
        ''
        ''Added 4/25/2022 thomas downes
        ''         
        Dim objRSCFieldColumn As RSCFieldColumnV2 ''4/9/2022 td RSCFieldColumnV1
        Dim boolConfirmed As Boolean
        Dim intDeleteRow_Start As Integer ''Added 5/2/2022 td
        Dim intDeleteRow_End As Integer ''Added 5/2/2022 td
        Dim bDeleteMultipleRows As Boolean ''Added 5/2/2022 td
        Dim bDeleteSingleRow As Boolean ''Added 5/2/2022 td

        ''Added 5/2/2022 thomas d.
        intDeleteRow_Start = Me.ParentRowHeaders.EmphasisRowIndex_Start
        intDeleteRow_End = Me.ParentRowHeaders.EmphasisRowIndex_End
        bDeleteMultipleRows = (intDeleteRow_End > 0 And (intDeleteRow_Start < intDeleteRow_End))
        bDeleteSingleRow = (Not bDeleteMultipleRows)

        If (bDeleteSingleRow) Then

            boolConfirmed = (MessageBoxTD.Show_Confirmed("Delete this row, thus removing (deleting) all data from this row of the spreadsheet?",
                                "(The data-cells themselves will also be removed/invisible.)" & vbCrLf_Deux &
                                "(Cannot be undone.)", True))

            If (boolConfirmed) Then
                ''4/09/2022 td''For Each each_column As RSCFieldColumnV1 In Me.ParentSpreadsheet.ListOfColumns
                For Each each_column As RSCFieldColumnV2 In Me.ParentSpreadsheet.ListOfColumns
                    objRSCFieldColumn = each_column ''---CType(each_column, RSCFieldColumn)
                    ''4/24/2022 td ''objRSCFieldColumn.ClearDataFromColumn_Do()
                    objRSCFieldColumn.DeleteRow_ByRowIndex(Me.RowIndex_LastClicked)

                Next each_column
            End If ''End of "If (boolConfirmed) Then"

        ElseIf (bDeleteMultipleRows) Then
            ''
            ''Added 5/02/2022 td
            ''
            Dim intNumRows As Integer
            intNumRows = (intDeleteRow_End - intDeleteRow_Start + 1)

            ''Added 5/02/2022 td
            boolConfirmed =
                (MessageBoxTD.Show_Confirmed(String.Format("Delete {0} rows, thus removing (deleting) " &
                                "all data from these rows of the spreadsheet?", intNumRows),
                                "(The data-cells themselves will also be removed/invisible.)" & vbCrLf_Deux &
                                "(Cannot be undone.)", True))
            ''Added 5/02/2022 td
            If (boolConfirmed) Then
                Dim intRowIndex As Integer
                For intRowIndex = intDeleteRow_Start To intDeleteRow_End
                    Try
                        For Each each_column As RSCFieldColumnV2 In Me.ParentSpreadsheet.ListOfColumns
                            objRSCFieldColumn = each_column ''---CType(each_column, RSCFieldColumn)
                            objRSCFieldColumn.DeleteRow_ByRowIndex(intRowIndex)
                        Next each_column
                    Catch ex_fornext As Exception
                        ''Added 6/22/2022 thomas d
                        System.Diagnostics.Debugger.Break()
                        MessageBoxTD.Show_Statement("Unable to delete some or one of the rows.")
                    End Try
                Next intRowIndex
            End If ''End of "If (boolConfirmed) Then"



        End If ''End of ""If (bDeleteSingleRow) Then.... ElseIf (bDeleteMultipleRows) Then


    End Sub ''end of Public Sub Delete_Row_or_Rows_From_Spreadsheet_FS2802


    Public Sub Clear_Data_From_Spreadsheet_FS2001(sender As Object, e As EventArgs)
        ''
        ''Added 3/21/2022 thomas downes
        ''         
        Dim objRSCFieldColumn As RSCFieldColumnV2 ''4/9/2022 td RSCFieldColumnV1
        Dim boolConfirmed As Boolean

        boolConfirmed = (MessageBoxTD.Show_Confirmed("Clear all data from this spreadsheet?",
                                                     "(To undo, hit Cancel or select Undo.)", True))

        If (boolConfirmed) Then
            ''4/09/2022 td''For Each each_column As RSCFieldColumnV1 In Me.ParentSpreadsheet.ListOfColumns
            For Each each_column As RSCFieldColumnV2 In Me.ParentSpreadsheet.ListOfColumns
                objRSCFieldColumn = each_column ''---CType(each_column, RSCFieldColumn)
                objRSCFieldColumn.ClearDataFromColumn_Do()
            Next each_column
        End If ''End of "If (boolConfirmed) Then"

    End Sub ''end of Public Sub Clear_Data_From_Column_FS2001


    Public Sub Undo_of_Clearing_Data_From_Column_FC2002(sender As Object, e As EventArgs)
        ''
        ''Copy-pasted 1/24/2022 thomas downes
        ''Added 8/17/2019 thomas downes
        ''         
        Dim objRSCFieldColumn As RSCFieldColumnV2
        Dim boolConfirmed As Boolean

        boolConfirmed = (MessageBoxTD.Show_Confirmed("Restore the data that was cleared from this spreadsheet?",
                  "(This restoration will overwrite any edits performed after the data was cleared.)", True))

        If (boolConfirmed) Then
            For Each each_column As RSCFieldColumnV2 In Me.ParentSpreadsheet.ListOfColumns
                objRSCFieldColumn = each_column ''---CType(each_column, RSCFieldColumn)
                objRSCFieldColumn.ClearDataFromColumn_Undo()
            Next each_column
        End If ''End of "If (boolConfirmed) Then"

    End Sub ''eND OF ""Public Sub Undo_of_Clearing_Data_From_Column_FC2002""


    Public Sub Add_Rows_To_Spreadsheet_FS2003(sender As Object, e As EventArgs)
        ''
        ''Added 4/2/2022 thomas downes
        ''





    End Sub ''End of ""Public Sub Add_Rows_To_Spreadsheet_FS2003""


End Class


