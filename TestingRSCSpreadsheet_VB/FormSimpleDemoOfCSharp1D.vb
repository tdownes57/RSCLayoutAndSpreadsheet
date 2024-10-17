''
'' Added 10/14/2024 T_homas C. D_ownes 
''
Imports System.Text
Imports RSCLibraryDLLOperations

Public Class FormSimpleDemoOfCSharp1D
    ''
    '' Added 10/14/2024 thomas c. downes 
    ''
    Private mod_list As DLLList(Of TwoCharacterDLLItem)
    Private mod_firstItem As TwoCharacterDLLItem
    Private mod_lastItem As TwoCharacterDLLItem
    Private Const INITIAL_ITEM_COUNT_30 As Integer = 30
    Private ReadOnly ARRAY_OF_DELIMITERS = New Char() {","c, " "c}


    Private Sub FormSimpleDemoOfCSharp1D_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        '' Added 10/14/2024 thomas c. downes 
        ''
        Dim indexNewItem As Integer
        Dim newItem As TwoCharacterDLLItem

        mod_firstItem = New TwoCharacterDLLItem("01")
        mod_lastItem = mod_firstItem
        mod_list = New DLLList(Of TwoCharacterDLLItem)(mod_firstItem, mod_lastItem, 1)

        For indexNewItem = 2 To INITIAL_ITEM_COUNT_30 ''---30

            newItem = New TwoCharacterDLLItem(indexNewItem.ToString("00"))
            mod_list.DLL_AddItemAtEnd(newItem)

        Next indexNewItem

        ''
        '' Display the list. 
        ''
        RefreshTheUI_DisplayList()

    End Sub


    Private Sub RefreshTheUI_DisplayList()

        ''Populate the UI. 
        Dim strListOfLinks As String
        strListOfLinks = FillTheTextboxDisplayingList()
        labelItemsDisplay.Text = strListOfLinks

        ''Added 12/28/2023 
        Dim itemCount As Integer = mod_list.DLL_CountAllItems()
        ''userControlOperation1.UpdateTheItemCount(itemCount)

        ''Added 1/04/202
        ''
        ''  Let's maintain the two(2) linklabels which represent
        ''    the list's endpoint & prior-to-endpoint.
        ''
        Dim last_item As TwoCharacterDLLItem = Nothing
        Dim prior_to_last As TwoCharacterDLLItem = Nothing

        last_item = CType(mod_list.DLL_GetLastItem_OfT(), TwoCharacterDLLItem)
        If (last_item Is Nothing) Then
            ''
            ''The user has elected to delete the entire list. 
            ''
        Else
            ''linkToEndpoint.Text = last_item.ToString()
            prior_to_last = CType(last_item.DLL_GetItemPrior(), TwoCharacterDLLItem)
            If (prior_to_last IsNot Nothing) Then
                ''linkToPenultimate.Text = prior_to_last.ToString()
            End If ''End of ""If (prior_to_last IsNot Nothing) Then""
        End If ''End of ""If (last_item Is Nothing) Then... Else..."

        ''Added 1/04/2024
        ''linkToEndpoint.Tag = last_item ''.ToString()

        ''Added 1/04/2024
        ''userControlOperation1.Lists_Endpoint = last_item
        ''userControlOperation1.Lists_Penultimate = prior_to_last

        ''Added 1/04/2024
        ''linkToPenultimate.Tag = prior_to_last ''.ToString()

    End Sub ''End of ""Private Sub RefreshTheUI_DisplayList()""


    Private Function FillTheTextboxDisplayingList() As String
        ''
        ''Added 12/26/2023  
        ''
        Dim each_twoChar As TwoCharacterDLLItem
        Dim bDone As Boolean = False
        Dim stringbuilderLinkedItems As New StringBuilder(120)
        Dim intCountLoops As Integer = 0

        ''LabelItemsDisplay.ResetText()
        ''Not needed here. ----labelItemsDisplay.Text = ""

        If (mod_firstItem Is Nothing) Then
            ''
            ''All the items have been deleted (most likely).
            ''
            Return "The list is empty."

        Else

            each_twoChar = mod_firstItem

            ''For Each each_twoChar In mod_list
            Do Until bDone

                ''LabelItemsDisplay.Text.Append(" +++ " + each_twoChar.ToString())
                ''stringbuilderLinkedItems.Append(" " + each_twoChar.ToString())
                stringbuilderLinkedItems.Append("  " + each_twoChar.ToString())

                each_twoChar = each_twoChar.DLL_GetItemNext
                bDone = (each_twoChar Is Nothing)
                intCountLoops += 1
                ''If (intCountLoops > 2 * 30) Then Debugger.Break()
                If (intCountLoops > 4 * INITIAL_ITEM_COUNT_30) Then Debugger.Break()

            Loop ''End of ""Do Until bDone""
            ''Next each_twoChar

            ''---MessageBoxTD.Show_Statement("Done loading!!")
            ''Return stringbuilderLinkedItems.ToString()
            Dim result As String
            result = stringbuilderLinkedItems.ToString()
            Return result

        End If ''End of ""If (mod_firstTwoChar Is Nothing) Then... Else..."

    End Function ''End of "Private Function FillTheTextboxDisplayingList()""

    Private Sub buttonInsert_Click(sender As Object, e As EventArgs) Handles buttonInsertMultiple.Click
        ''
        '' Added 10/15/2024  
        ''
        Dim intInsertCount As Integer
        Dim intAnchorPosition As Integer
        Dim indexNewItem As Integer
        Dim objectRange As DLLRange(Of TwoCharacterDLLItem)
        Dim prior_newItem As TwoCharacterDLLItem
        Dim newItem As TwoCharacterDLLItem
        Dim first_newItem As TwoCharacterDLLItem
        Dim last_newItem As TwoCharacterDLLItem
        Dim intHowManyInModuleList As Integer
        Dim intNewIndexStart As Integer
        Dim intNewIndexEnd As Integer
        Dim array_sItemsToInsert As String()
        Dim bUserSpecifiedValues
        Dim strNewItem As String
        Dim intModulo As Integer
        Dim boolEndpoint As Boolean
        Dim objAnchor As DLLAnchor(Of TwoCharacterDLLItem)

        intInsertCount = numInsertHowMany.Value
        intAnchorPosition = numInsertAnchorBenchmark.Value
        intHowManyInModuleList = mod_list.DLL_CountAllItems
        boolEndpoint = intAnchorPosition = 1 Or intAnchorPosition = intHowManyInModuleList

        intNewIndexStart = 1 + intHowManyInModuleList
        intNewIndexEnd = intInsertCount + intHowManyInModuleList
        array_sItemsToInsert = textInsertListOfValuesCSV.Text.Split(New Char() {","c, " "c})
        bUserSpecifiedValues = array_sItemsToInsert.Count > 0

        For indexNewItem = intNewIndexStart To intNewIndexEnd

            intModulo = indexNewItem Mod intInsertCount
            strNewItem = IIf(bUserSpecifiedValues, array_sItemsToInsert(intModulo),
                             indexNewItem.ToString("00"))
            newItem = New TwoCharacterDLLItem(strNewItem)

            If first_newItem Is Nothing Then
                first_newItem = newItem
                objectRange = New DLLRange(Of TwoCharacterDLLItem)(True, Nothing, Nothing, first_newItem, 1)
            Else
                prior_newItem.DLL_SetItemNext(newItem)
                newItem.DLL_SetItemPrior(prior_newItem)
                objectRange = New DLLRange(Of TwoCharacterDLLItem)(True, Nothing, Nothing, first_newItem, 1)
            End If

            ''Prepare for next iteration.
            prior_newItem = newItem

        Next indexNewItem

        ''
        ''Save the last. 
        ''
        last_newItem = prior_newItem

        ''
        '' Set the range. 
        ''
        If intInsertCount = 1 Then
            objectRange = New DLLRange(Of TwoCharacterDLLItem)(first_newItem, True)
        Else
            ''
            '' There are at least two objects in the range. 
            ''
            objectRange = New DLLRange(Of TwoCharacterDLLItem)(False, first_newItem,
                                                               last_newItem, Nothing, intInsertCount)

        End If ''End of ""If (intInsertCount = 1) Then... Else..."

        ''
        ''Set the anchor. 
        ''
        objAnchor = New DLLAnchor(Of TwoCharacterDLLItem)
        objAnchor._anchorItem = mod_firstItem.DLL_GetItemNext(-1 + intAnchorPosition)
        objAnchor._doInsertRangeAfterThis = (listInsertAfterOr.SelectedIndex < 1)
        objAnchor._doInsertRangeBeforeThis = (False = objAnchor._doInsertRangeAfterThis)

        ''
        '' Insert range into the list.  
        ''
        mod_list.DLL_InsertRangeBefore(objectRange, objAnchor, boolEndpoint)

        ''
        '' Display the list. 
        ''
        RefreshTheUI_DisplayList()

    End Sub

    Private Sub buttonInsertSingle_Click(sender As Object, e As EventArgs) Handles buttonInsertSingle.Click

        ''
        '' Insert range into the list.  
        ''
        Dim objAnchor As DLLAnchor(Of TwoCharacterDLLItem)
        Dim intAnchorPosition As Integer
        Dim boolEndpoint As Boolean
        Dim array_sItemsToInsert As String()
        Dim bUserSpecifiedValues
        Dim strNewItem As String
        Dim intHowManyInModuleList As Integer
        Dim newItem As TwoCharacterDLLItem
        Const ZERO_INDEX As Integer = 0
        Dim bInsertRangeAfterAnchor As Boolean
        Dim bInsertRangeBeforeAnchor As Boolean

        array_sItemsToInsert = textInsertListOfValuesCSV.Text.Split(ARRAY_OF_DELIMITERS)
        intHowManyInModuleList = mod_list.DLL_CountAllItems
        bUserSpecifiedValues = array_sItemsToInsert.Count > 0

        ''
        ''Set the anchor. 
        ''
        objAnchor = New DLLAnchor(Of TwoCharacterDLLItem)
        objAnchor._anchorItem = mod_firstItem.DLL_GetItemNext(-1 + intAnchorPosition)

        bInsertRangeAfterAnchor = (listInsertAfterOr.SelectedIndex < 1)
        objAnchor._doInsertRangeAfterThis = bInsertRangeAfterAnchor
        objAnchor._doInsertRangeBeforeThis = (False = bInsertRangeAfterAnchor)

        ''intInsertCount = numInsertHowMany.Value
        intAnchorPosition = numInsertAnchorBenchmark.Value
        boolEndpoint = intAnchorPosition = 1 Or intAnchorPosition = intHowManyInModuleList

        strNewItem = IIf(bUserSpecifiedValues, array_sItemsToInsert(0),
                             ZERO_INDEX.ToString("00"))
        newItem = New TwoCharacterDLLItem(strNewItem)

        ''---mod_list.DLL_InsertSingly(newItem, objAnchor, boolEndpoint)
        mod_list.DLL_SetAnchor(objAnchor, bInsertRangeBeforeAnchor, bInsertRangeAfterAnchor)

        ''
        ''Major work!! 
        ''
        mod_list.DLL_InsertItemSingly(newItem)

    End Sub


End Class
