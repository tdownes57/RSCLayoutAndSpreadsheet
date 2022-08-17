
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
Public Class Operations_RSCFieldColumn
    Implements ICurrentElement ''Added 3/19/2022 td
    Implements IRightClickMouseInfo ''Added 3/19/2022 td

    ''
    ''Added 1/04/2022 td
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
    Public Property FieldColumn As RSCFieldColumnV2 ''Added 4/15/2022 td
    Public Property ColumnIndex As Integer ''Added 3/20/2022 td

    Private mod_bClearingExists_MayBeUndone As Boolean ''Added 3/21/2022

    ''Public Sub Insert_New_Column_To_The_Left_FC2003(sender As Object, e As EventArgs)
    ''End Sub


    Public Sub Context_Menu_FC9121(sender As Object, e As EventArgs)
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

    End Sub ''end of "Public Sub Context_Menu_EE9121(sender As Object, e As EventArgs)"


    Public Sub Clear_Data_From_Column_FC2001(sender As Object, e As EventArgs)
        ''
        ''Copy-pasted 1/24/2022 thomas downes
        ''Added 8/17/2019 thomas downes
        ''         
        Dim objRSCFieldColumn As RSCFieldColumnV1
        Dim boolConfirmed As Boolean

        boolConfirmed = (MessageBoxTD.Show_Confirmed("Clear all data from this column?",
                                                     "(To undo, hit Cancel or select Undo.)", True))
        If (boolConfirmed) Then
            objRSCFieldColumn = CType(CtlCurrentControl, RSCFieldColumnV1)
            objRSCFieldColumn.ClearDataFromColumn_Do()
            mod_bClearingExists_MayBeUndone = True
        End If ''End of "If (boolConfirmed) Then"

    End Sub ''end of Public Sub Clear_Data_From_Column_FC2001


    Public Sub Undo_of_Clearing_Data_From_Column_FC2002(sender As Object, e As EventArgs)
        ''
        ''Copy-pasted 1/24/2022 thomas downes
        ''Added 8/17/2019 thomas downes
        ''         
        '' 4/15/2022 Dim objRSCFieldColumn As RSCFieldColumnV1
        Dim objRSCFieldColumn As RSCFieldColumnV2
        Dim boolConfirmed1 As Boolean
        Dim boolConfirmed2 As Boolean
        Dim intCountData As Integer
        Dim dialogKeepAnyEdits As DialogResult
        Dim boolKeepAnyEdits As Boolean

        boolConfirmed1 = MessageBoxTD.Show_Confirmed("Restore all prior-cleared data from this column?", "", False)
        ''      "(Warning, any edits performed after the Clear will be lost.)", True))

        If (boolConfirmed1) Then

            ''4/15/2022 objRSCFieldColumn = CType(CtlCurrentControl, RSCFieldColumnV1)
            objRSCFieldColumn = Me.FieldColumn ''Added 4/15/2022
            intCountData = objRSCFieldColumn.CountOfBoxesWithData()

            If (intCountData > 0) Then
                dialogKeepAnyEdits = MessageBoxTD.Show_QuestionYesNo_FormatCounts(intCountData,
                                "There are {0} boxes with fresh edits.",
                                "Keep your edits?")
                If (dialogKeepAnyEdits = DialogResult.Cancel) Then Exit Sub
                boolKeepAnyEdits = (dialogKeepAnyEdits = DialogResult.Yes Or dialogKeepAnyEdits = DialogResult.OK)

                If (Not boolKeepAnyEdits) Then

                    ''Added 3/20/2022
                    boolConfirmed2 = MessageBoxTD.Show_Confirmed_FormatCount(intCountData,
                              "Your recent {0} edits will be lost.", "", False)
                    If (Not boolConfirmed2) Then Exit Sub

                End If ''end of If (Not boolKeepAnyEdits) Then


            End If ''End of "If (intCountData > 0) Then"

            ''
            ''Major call. 
            ''
            ''4/15/2022 objRSCFieldColumn = CType(CtlCurrentControl, RSCFieldColumnV1)
            objRSCFieldColumn = CType(CtlCurrentControl, RSCFieldColumnV2)
            objRSCFieldColumn.ClearDataFromColumn_Undo(boolKeepAnyEdits)
            mod_bClearingExists_MayBeUndone = False ''Restore to False

        End If ''End of "If (boolConfirmed) Then"

    End Sub ''Public Sub Undo_of_Clearing_Data_From_Column_FC2002


    Public Sub Insert_New_Column_To_The_Left_FC2003(sender As Object, e As EventArgs)
        ''
        ''Added 3/20/2022 thomas downes
        ''
        Dim rscParentSpreadsheet As RSCFieldSpreadsheet
        rscParentSpreadsheet = Me.ParentSpreadsheet
        ''In case other columns were deleted, we need to refresh the Column Index.---4/15/2022
        Me.ColumnIndex = rscParentSpreadsheet.GetIndexOfColumn(Me.FieldColumn)
        rscParentSpreadsheet.InsertNewColumnByIndex(Me.ColumnIndex)

    End Sub ''End of "Public Sub Insert_New_Column_To_The_Left_FC2003"


    Public Sub Insert_New_Column_To_The_Right_FC2004(sender As Object, e As EventArgs)
        ''
        ''Added 3/20/2022 thomas downes
        ''
        Dim rscParentSpreadsheet As RSCFieldSpreadsheet
        rscParentSpreadsheet = Me.ParentSpreadsheet
        ''In case other columns were deleted, we need to refresh the Column Index.---4/15/2022
        Me.ColumnIndex = rscParentSpreadsheet.GetIndexOfColumn(Me.FieldColumn)
        rscParentSpreadsheet.InsertNewColumnByIndex(Me.ColumnIndex + 1)

    End Sub ''End of "Public Sub Insert_New_Column_To_The_Right_FC2003"


    Public Sub Insert_Up_To_9_Columns_To_The_Right_FC2005(sender As Object, e As EventArgs)
        ''
        ''Added 3/20/2022 thomas downes
        ''
        Dim rscParentSpreadsheet As RSCFieldSpreadsheet
        Dim intHowManyNewColumns As Integer
        Dim intNewColIndex As Integer
        Const c_intDefaultValue As Integer = 1 ''Added 8/17/2022

        ''8/17/2022 intHowManyNewColumns = MessageBoxTD.AskHowMany("How many new columns are needed?  (Up to 9.)",
        ''               1.1, 1.1, 1, 9,
        ''               False, False)
        intHowManyNewColumns = MessageBoxTD.AskHowMany("How many new columns are needed?  (Up to 9.)",
                       1.1, 1.1, 1, 9,
                       c_intDefaultValue,
                       False, False)

        rscParentSpreadsheet = Me.ParentSpreadsheet

        ''In case other columns were deleted, we need to refresh the Column Index.---4/15/2022
        Me.ColumnIndex = rscParentSpreadsheet.GetIndexOfColumn(Me.FieldColumn)

        For intNewColIndex = 1 To intHowManyNewColumns
            ''Insert as many columns to the rightt as needed.  
            rscParentSpreadsheet.InsertNewColumnByIndex(Me.ColumnIndex + 1)
        Next intNewColIndex

    End Sub ''End of "Public Sub Insert_Up_To_9_Columns_To_The_Right_FC2005"


    Public Sub Delete_This_Column_FC2006(sender As Object, e As EventArgs)
        ''
        ''Added 4/14/2022 thomas downes
        ''
        Dim rscParentSpreadsheet As RSCFieldSpreadsheet

        ''If user agrees, delete the RSC column.
        If (MessageBoxTD.Show_Confirmed("Delete the spreadsheet column?", "", True)) Then
            ''User has confirmed. 
            rscParentSpreadsheet = Me.ParentSpreadsheet

            ''4/15/2022 ''rscParentSpreadsheet.DeleteColumnByIndex(Me.ColumnIndex)

            ''In case other columns were deleted, we need to refresh the Column Index.---4/15/2022
            Me.ColumnIndex = rscParentSpreadsheet.GetIndexOfColumn(Me.FieldColumn)
            rscParentSpreadsheet.DeleteColumnByIndex(Me.ColumnIndex)

        End If ''end of ""If (MessageBoxTD.Show_Confirmed("Delete .....") ....

    End Sub ''End of "Public Sub Delete_This_Column_FC2005"



End Class
