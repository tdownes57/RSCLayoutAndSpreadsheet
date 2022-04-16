
Option Explicit On
Option Strict On
Option Infer Off

''
''Added 3/13/2022 td
''
Imports ciBadgeInterfaces
Imports ciBadgeDesigner
Imports ciBadgeElements
Imports __RSCWindowsControlLibrary ''Added 1/2/2022 td 
Imports ciBadgeCachePersonality ''Added 1/18/2022 td
Imports System.Drawing ''Added 1/26/2022 td

''
'' Added 3/13/2022 thomas downes
''
Public Class Operations_RSCSpreadsheet
    Implements ICurrentElement ''Added 3/19/2022 td
    Implements IRightClickMouseInfo ''Added 3/19/2022 td

    ''
    ''Added 3/29/2022 td
    ''
    Public Property Element_Type As Enum_ElementType = Enum_ElementType.RSCSheetColumn ''Added 1/21/2022 td

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
    Public Property ColumnIndex As Integer ''Added 3/20/2022 td

    Private mod_sbSpreadheetData As System.Text.StringBuilder


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


    Public Sub Clear_Data_From_Spreadsheet_FS2001(sender As Object, e As EventArgs)
        ''
        ''Added 3/21/2022 thomas downes
        ''         
        ''Dim objRSCFieldColumn As RSCFieldColumn
        ''Dim boolConfirmed As Boolean

        ''boolConfirmed = (MessageBoxTD.Show_Confirmed("Clear all data from this spreadsheet?",
        ''                                             "(To undo, hit Cancel or select Undo.)", True))

        ''If (boolConfirmed) Then
        ''    For Each each_column As RSCFieldColumn In Me.ParentSpreadsheet.ListOfColumns
        ''        objRSCFieldColumn = each_column ''---CType(each_column, RSCFieldColumn)
        ''        objRSCFieldColumn.ClearDataFromColumn_Do()
        ''    Next each_column
        ''End If ''End of "If (boolConfirmed) Then"

        ''Encapsulated 3/29/2022 thomas downes
        Me.ParentSpreadsheet.ClearDataFromSpreadsheet_1stConfirm()

    End Sub ''end of Public Sub Clear_Data_From_Column_FS2001


    Public Sub Undo_of_Clearing_Data_From_Column_FC2002(sender As Object, e As EventArgs)
        ''
        ''Copy-pasted 1/24/2022 thomas downes
        ''Added 8/17/2019 thomas downes
        ''         
        ''4/09/2022 td''Dim objRSCFieldColumn As RSCFieldColumnV1
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

    End Sub ''End of ""Public Sub Undo_of_Clearing_Data_From_Column_FC2002""


    Public Sub Copy_All_Spreadsheet_Data_with_Headers_FC2003(sender As Object, e As EventArgs)
        ''
        ''Added 4/03/2022 thomas downes
        ''  




    End Sub ''End of ""Public Sub Copy_All_Spreadsheet_Data_with_Headers_FC2003""


    Public Sub Copy_All_Spreadsheet_Data_without_Headers_FC2003(sender As Object, e As EventArgs)
        ''
        ''Added 4/03/2022 thomas downes
        ''  
        CopySpreadsheetData(False, False)

        ''Dim intCountOfRows1 As Integer
        ''Dim intCountOfRows2 As Integer
        ''Dim intCountOfColumns As Integer
        ''Const c_intAverageCellChars As Integer = 5
        ''Dim intGuessAtTextLength As Integer
        ''Dim each_stringRow As String

        ''intCountOfRows1 = Me.ParentSpreadsheet.RscRowHeaders1.CountOfRows()
        ''intCountOfRows2 = Me.ParentSpreadsheet.RscFieldColumn1.CountOfRows()
        ''intCountOfColumns = Me.ParentSpreadsheet.ListOfColumns().Count
        ''intGuessAtTextLength = (intCountOfRows2 *
        ''            intCountOfColumns *
        ''            (c_intAverageCellChars + 1))

        ''mod_sbSpreadheetData = New System.Text.StringBuilder(intGuessAtTextLength)

        ''''
        ''''
        ''''
        ''''April 11, 2022 td ''For intRowIndex As Integer = 0 To (intCountOfRows2 - 1)
        ''For intRowIndex As Integer = 1 To (intCountOfRows2) '' (intCountsOfRows2 - 1)

        ''    each_stringRow = Me.ParentSpreadsheet.ToString_ByRow(intRowIndex)
        ''    mod_sbSpreadheetData.AppendLine(each_stringRow)

        ''Next intRowIndex

        ''''
        ''''Exit Handler
        ''''
        ''Clipboard.SetText(mod_sbSpreadheetData.ToString())
        ''Dim strPathTXT As String
        ''strPathTXT = IO.Path.Combine(DiskFolders.PathToFolder_Notes(),
        ''                              IO.Path.GetRandomFileName() & ".txt")
        ''IO.File.WriteAllText(strPathTXT, mod_sbSpreadheetData.ToString())
        ''System.Diagnostics.Process.Start(strPathTXT)

    End Sub ''End of ""Public Sub Copy_All_Spreadsheet_Data_with_Headers_FC2003""


    Public Sub Copy_Spreadsheet_Data_with_Row_Index_FC2004(sender As Object, e As EventArgs)
        ''
        ''Added 4/11/2022  thomas downes
        ''  
        CopySpreadsheetData(False, True)

    End Sub


    Public Sub CopySpreadsheetData(pboolIncludeFieldnames As Boolean,
                                     pboolIncludeRowIndexes As Boolean) ''_FC2004(sender As Object, e As EventArgs)
        ''
        ''Added 4/11/2022  thomas downes
        ''  
        Dim intCountOfRows1 As Integer
        Dim intCountOfRows2 As Integer
        Dim intCountOfColumns As Integer
        Const c_intAverageCellChars As Integer = 5
        Dim intGuessAtTextLength As Integer
        Dim each_stringRow As String

        If (Me.ParentSpreadsheet Is Nothing) Then
            MessageBoxTD.Show_Statement("Spreadsheet is not found.")
            Return
        ElseIf (Me.ParentSpreadsheet.RscFieldColumn1 Is Nothing) Then
            MessageBoxTD.Show_Statement("Spreadsheet column(s) are not found.")
            Return
        End If

        intCountOfRows1 = Me.ParentSpreadsheet.RscRowHeaders1.CountOfRows()
        intCountOfRows2 = Me.ParentSpreadsheet.RscFieldColumn1.CountOfRows()
        intCountOfColumns = Me.ParentSpreadsheet.ListOfColumns().Count

        intGuessAtTextLength = (intCountOfRows2 *
                    intCountOfColumns *
                    (c_intAverageCellChars + 1))

        mod_sbSpreadheetData = New System.Text.StringBuilder(intGuessAtTextLength)

        ''
        ''
        ''
        ''April 11, 2022 td ''For intRowIndex As Integer = 0 To (intCountOfRows2 - 1)
        For intRowIndex As Integer = 1 To (intCountOfRows2) '' (intCountsOfRows2 - 1)

            ''April 12 2022 ''each_stringRow = Me.ParentSpreadsheet.ToString_ByRow(intRowIndex)
            each_stringRow = Me.ParentSpreadsheet.ToString_ByRow(intRowIndex, pboolIncludeRowIndexes)
            mod_sbSpreadheetData.AppendLine(each_stringRow)

        Next intRowIndex

        ''
        ''Exit Handler
        ''
        Clipboard.SetText(mod_sbSpreadheetData.ToString())
        Dim strPathTXT As String
        strPathTXT = IO.Path.Combine(DiskFolders.PathToFolder_Notes(),
                                      IO.Path.GetRandomFileName() & ".txt")
        IO.File.WriteAllText(strPathTXT, mod_sbSpreadheetData.ToString())
        System.Diagnostics.Process.Start(strPathTXT)

    End Sub ''End of ""Public Sub Copy_All_Spreadsheet_Data_with_Headers_FC2003""


End Class
