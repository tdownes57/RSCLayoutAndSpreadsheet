
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
Public Class Operations_FieldColumn
    Implements ICurrentElement ''Added 3/19/2022 td
    Implements IRightClickMouseInfo ''Added 3/19/2022 td

    ''
    ''Added 1/04/2022 td
    ''
    Public Property Element_Type As Enum_ElementType = Enum_ElementType.FieldColumn ''Added 1/21/2022 td

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


    ''Public Sub Insert_New_Column_To_The_Left_FC2003(sender As Object, e As EventArgs)
    ''End Sub


    Public Sub Clear_Data_From_Column_FC2001(sender As Object, e As EventArgs)
        ''
        ''Copy-pasted 1/24/2022 thomas downes
        ''Added 8/17/2019 thomas downes
        ''         
        Dim objRSCFieldColumn As RSCFieldColumn
        Dim boolConfirmed As Boolean

        boolConfirmed = (MessageBoxTD.Show_Confirmed("Clear all data from this column?",
                                                     "(To undo, hit Cancel or select Undo.)", True))
        If (boolConfirmed) Then
            objRSCFieldColumn = CType(CtlCurrentControl, RSCFieldColumn)
            objRSCFieldColumn.ClearDataFromColumn_Do()
        End If ''End of "If (boolConfirmed) Then"

    End Sub ''end of Public Sub Clear_Data_From_Column_FC2001


    Public Sub Undo_of_Clearing_Data_From_Column_FC2002(sender As Object, e As EventArgs)
        ''
        ''Copy-pasted 1/24/2022 thomas downes
        ''Added 8/17/2019 thomas downes
        ''         
        Dim objRSCFieldColumn As RSCFieldColumn
        Dim boolConfirmed1 As Boolean
        Dim boolConfirmed2 As Boolean
        Dim intCountData As Integer
        Dim dialogKeepAnyEdits As DialogResult
        Dim boolKeepAnyEdits As Boolean

        boolConfirmed1 = MessageBoxTD.Show_Confirmed("Restore all prior-cleared data from this column?", "", False)
        ''      "(Warning, any edits performed after the Clear will be lost.)", True))

        If (boolConfirmed1) Then

            objRSCFieldColumn = CType(CtlCurrentControl, RSCFieldColumn)
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
            objRSCFieldColumn = CType(CtlCurrentControl, RSCFieldColumn)
            objRSCFieldColumn.ClearDataFromColumn_Undo(boolKeepAnyEdits)


        End If ''End of "If (boolConfirmed) Then"

    End Sub ''Public Sub Undo_of_Clearing_Data_From_Column_FC2002


    Public Sub Insert_New_Column_To_The_Left_FC2003(sender As Object, e As EventArgs)
        ''
        ''Added 3/20/2022 thomas downes
        ''
        Dim rscParentSpreadsheet As RSCFieldSpreadsheet
        rscParentSpreadsheet = Me.ParentSpreadsheet
        rscParentSpreadsheet.InsertNewColumnByIndex(Me.ColumnIndex)


    End Sub ''End of "Public Sub Insert_New_Column_To_The_Left_FC2003"


    Public Sub Insert_New_Column_To_The_Right_FC2004(sender As Object, e As EventArgs)
        ''
        ''Added 3/20/2022 thomas downes
        ''
        Dim rscParentSpreadsheet As RSCFieldSpreadsheet
        rscParentSpreadsheet = Me.ParentSpreadsheet
        rscParentSpreadsheet.InsertNewColumnByIndex(Me.ColumnIndex + 1)

    End Sub ''End of "Public Sub Insert_New_Column_To_The_Right_FC2003"





End Class
