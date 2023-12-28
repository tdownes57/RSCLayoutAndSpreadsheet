Imports System.Runtime.InteropServices.JavaScript.JSType
Imports System.Text
Imports ciBadgeInterfaces
Imports ciBadgeSerialize
''---Imports ciBadgeRecipients

Public Class FormTestRSCViaDigits

    Private mod_list As DLL_List_OfTControl_PLEASE_USE(Of TwoCharacterDLLItem)
    ''Private mod_operations As DLL_OperationsManager_Deprecated(Of TwoCharacterDLLItem)
    Private mod_operations As DLL_OperationsManager(Of TwoCharacterDLLItem)
    Private mod_firstTwoChar As TwoCharacterDLLItem

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ''Initialize the DLL list. (DLL = Doubly-Linked List)
        mod_list = New DLL_List_OfTControl_PLEASE_USE(Of TwoCharacterDLLItem)(mod_firstTwoChar)

        ' Add any initialization after the InitializeComponent() call.
        ''Encapsulated 12/25/2023 thomas downes
        Load_DLL_List(mod_list)
        UserControlOperation1.DLL_List = mod_list

        ''Populate the UI. 
        ''---See the Form_Load procedure / event-handler. 

    End Sub

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ''Encapsulated 12/25/2023 thomas downes
        ''---See Public Sub New.---Load_DLL_List(mod_list)
        ''Dim boolTesting As Boolean = False ''True
        ''Dim strListOfLinks As String

        ''If (Not boolTesting) Then
        ''Populate the UI. 
        ''--strListOfLinks = FillTheTextboxDisplayingList()
        ''--LabelItemsDisplay.Text = strListOfLinks
        RefreshTheUI_DisplayList()

        ''Added 12/26/2023
        ''MessageBoxTD.Show_Statement("Done loading the textbox with the list.")
        ''End If

    End Sub ''end of ""Private Sub Form_Load""


    Private Function FillTheTextboxDisplayingList() As String
        ''
        ''Added 12/26/2023  
        ''
        Dim each_twoChar As TwoCharacterDLLItem
        Dim bDone As Boolean = False
        Dim stringbuilderLinkedItems As New StringBuilder(120)
        Dim intCountLoops As Integer = 0

        ''LabelItemsDisplay.ResetText()
        LabelItemsDisplay.Text = ""
        each_twoChar = mod_firstTwoChar

        ''For Each each_twoChar In mod_list
        Do Until bDone

            ''LabelItemsDisplay.Text.Append(" +++ " + each_twoChar.ToString())
            stringbuilderLinkedItems.Append(" " + each_twoChar.ToString())

            each_twoChar = each_twoChar.DLL_GetItemNext
            bDone = (each_twoChar Is Nothing)
            intCountLoops += 1

        Loop ''End of ""Do Until bDone""
        ''Next each_twoChar

        ''---MessageBoxTD.Show_Statement("Done loading!!")
        ''Return stringbuilderLinkedItems.ToString()
        Dim result As String
        result = stringbuilderLinkedItems.ToString()
        Return result

    End Function ''Ednd of :":"Private Function FillTheTextboxDisplayingList()""



    Private Sub Load_DLL_List(par_list As DLL_List_OfTControl_PLEASE_USE(Of TwoCharacterDLLItem),
                              Optional par_firstItem As TwoCharacterDLLItem = Nothing)
        ''
        ''Encapsulated 12/25/2023 thomas downes
        ''
        Dim each_twoCharsItem As TwoCharacterDLLItem
        Dim each_strTwoChars As String
        Dim prior As TwoCharacterDLLItem = Nothing
        Dim bListIsEmpty As Boolean = True

        ''Clear the list.
        par_list.DLL_ClearAllItems()
        ''prior = par_firstItem
        bListIsEmpty = (0 = par_list.DLL_CountAllItems())
        If (Not bListIsEmpty) Then Debugger.Break()
        mod_firstTwoChar = par_firstItem

        ''Added 12/26/20923
        Dim firstBenchmark_1or2 As Integer = 1
        If (par_firstItem IsNot Nothing) Then
            par_list.DLL_AddFirstAndOnlyItem(par_firstItem)
            bListIsEmpty = (0 = par_list.DLL_CountAllItems())
            firstBenchmark_1or2 = 2
            prior = par_firstItem
        End If ''end of ""If (par_firstItem IsNot Nothing) Then""

        ''
        ''Iterate through the list. 
        ''
        For benchmark = firstBenchmark_1or2 To 30

            each_strTwoChars = String.Format("{0:00}", benchmark)
            ''12/2023 each_twoCharsItem = New TwoCharacterDLLItem(each_strTwoChars, prior)
            each_twoCharsItem = New TwoCharacterDLLItem(each_strTwoChars)

            If (prior Is Nothing) Then
                ''Only occurs on first iteration.
                mod_firstTwoChar = each_twoCharsItem
                ''Add the very first item. 
                par_list.DLL_AddFirstAndOnlyItem(each_twoCharsItem)

            Else
                ''---Not needed here....
                ''---prior.DLL_SetItemNext(each_twoCharsItem)
                par_list.DLL_InsertOneItemAfter(each_twoCharsItem, prior, True)

            End If ''End of ""If (prior Is Nothing) Then... Else... "

            ''If (bListIsEmpty) Then
            ''    ''Add the very first item. 
            ''    par_list.DLL_AddFirstAndOnlyItem(each_twoCharsItem)
            ''Else
            ''    par_list.DLL_InsertOneItemAfter(each_twoCharsItem, prior, True)
            ''End If ''end of If (bListIsEmpty) Then... Else...

            ''
            ''Prepare for next iteration of the loop.
            ''
            prior = each_twoCharsItem
            bListIsEmpty = False

        Next benchmark ''Next index


    End Sub ''End of ""Private Sub Load_DLL_List""


    Private Sub RefreshTheUI_DisplayList()

        ''Populate the UI. 
        Dim strListOfLinks As String
        strListOfLinks = FillTheTextboxDisplayingList()
        LabelItemsDisplay.Text = strListOfLinks

    End Sub ''End of ""Private Sub RefreshTheUI_DisplayList()""


    Private Sub DLL_OperationCreated_Delete(par_operation As DLL_OperationV1,
                                            par_inverseAnchor_PriorToRange As TwoCharacterDLLItem,
                                            par_inverseAnchor_NextToRange As TwoCharacterDLLItem) _
                                            Handles UserControlOperation1.DLLOperationCreated_Delete
        ''
        ''Added 12/25/2023 
        ''
        ''   Version #1 (DLL_OperationV1) exposes more things than Version #2.
        ''
        With par_operation

            ''objItemToInsert_First = mod_list.DLL_GetItemAtIndex(.)
            ''mod_list.DLL_InsertOneItemAfter(each_twoCharsItem, prior, True)
            ''.ImplementForList(mod_list)
            Dim bChangeOfEndpoint As Boolean
            ''V2''bChangeOfEndpoint = (.GetIndexOfStart() <= -1 + mod_list.DLL_CountAllItems())
            bChangeOfEndpoint = (.DeleteRangeStart Is mod_list.DLL_GetLastItem())

            ''V2''mod_list.DLL_DeleteItem(.GetSingleItem(), bChangeOfEndpoint)
            mod_list.DLL_DeleteItem(.DeleteItemSingly, bChangeOfEndpoint)

        End With

        RefreshTheUI_DisplayList()

    End Sub ''End of ""Private Sub DLL_OperationCreated_Delete""


    Private Sub DLLOperationCreated_Insert(par_operation As DLL_OperationV1) _
                           Handles UserControlOperation1.DLLOperationCreated_Insert
        ''
        ''Added 12/25/2023 
        ''
        ''   Version #1 (DLL_OperationV1) exposes more things than Version #2.
        ''
        ''Dim objItemToInsert_First As TwoCharacterDLLItem

        With par_operation

            ''objItemToInsert_First = mod_list.DLL_GetItemAtIndex(.)
            ''mod_list.DLL_InsertOneItemAfter(each_twoCharsItem, prior, True)
            ''.ImplementForList(mod_list)

            ''V2''mod_list.DLL_InsertOneItemAfter(.GetSingleItem(),
            ''                                .GetAnchor_precedingRange(),
            ''                                False)
            If (.AnchorToPrecedeItemOrRange IsNot Nothing) Then
                ''Insert operational item(s) AFTER anchoring item.
                ''
                ''                Insert A after 7, the preceding anchor.
                ''                       |
                ''          1 2 3 4 5 6 7 8 9 10
                '' Result:  1 2 3 4 5 6 7 A 8 9 10
                ''
                mod_list.DLL_InsertOneItemAfter(.InsertItemSingly,
                                            .AnchorToPrecedeItemOrRange,
                                            .IsChangeOfEndpoint) ''False)
            Else
                ''Insert operational item(s) BEFORE anchoring item.
                ''
                ''            Insert x before 6, the terminating anchor.
                ''                   |
                ''          1 2 3 4 5 6 7 8 9 10
                '' Result:  1 2 3 4 5 x 6 7 8 9 10
                ''
                mod_list.DLL_InsertOneItemBefore(.InsertItemSingly,
                                            .AnchorToSucceedItemOrRange,
                                            .IsChangeOfEndpoint) ''False))

            End If ''End of ""If (.AnchorToPrecedeItemOrRange IsNot Nothing) Then ... Else..."

            ''Added 12/28/2023
            If (.IsChangeOfEndpoint) Then
                ''In the 50% chance the starting item is affected...
                mod_firstTwoChar = mod_list.DLL_GetFirstItem()
            End If ''End of ""If (.IsChangeOfEndpoint) Then""

        End With ''End of ""With par_operation""

        RefreshTheUI_DisplayList()

    End Sub


    Private Sub UserControlOperation1_DLLOperationCreated_MoveRange(par_operation As DLL_OperationV1,
                                                                    par_inverseAnchor_PriorToRange As TwoCharacterDLLItem,
                                                                    par_inverseAnchor_NextToRange As TwoCharacterDLLItem) _
                                                                    Handles UserControlOperation1.DLLOperationCreated_MoveRange
        ''
        ''Added 12/25/2023 
        ''
        ''   Version #1 (DLL_OperationV1) exposes more things than Version #2.
        ''

        ''Populate the UI. 
        ''Dim strListOfLinks As String
        ''strListOfLinks = FillTheTextboxDisplayingList()
        ''LabelItemsDisplay.Text = strListOfLinks
        RefreshTheUI_DisplayList()

    End Sub

    Private Sub LinkSingleItem_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkSingleItemOnly.LinkClicked

        ''Added 12/26/2023 td
        UserControlOperation1.ToggleSingleItemMode()

    End Sub
End Class
