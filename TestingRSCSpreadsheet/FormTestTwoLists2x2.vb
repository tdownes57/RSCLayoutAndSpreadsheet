Imports System.Text
Imports ciBadgeInterfaces ''Added 3/02/2024 td
Imports ciBadgeSerialize ''Added 3/02/2024 td

Public Class FormTestTwoLists2x2
    ''
    ''Added 2/27/2024 thomas downes
    ''
    Private Const INITIAL_ITEM_COUNT_Rows As Integer = 30 ''Added 3/02/2024 td
    Private Const INITIAL_ITEM_COUNT_Cols As Integer = 30 ''Added 3/02/2024 td

    ''Added 3/01/2024 
    ''===Nice but problematic.3/2024
    ''==Private mod_list1Cols As DLL_List_OfTControl_PLEASE_USE(Of TwoCharacterDLLHorizontal)
    ''==Private mod_list2Rows As DLL_List_OfTControl_PLEASE_USE(Of TwoCharacterDLLVertical)
    Private mod_list1Cols As DLL_List_OfTControl_PLEASE_USE(Of TwoCharacterDLLItem)
    Private mod_list2Rows As DLL_List_OfTControl_PLEASE_USE(Of TwoCharacterDLLItem)

    Private mod_managerOfOps As DLLOperationsManager2x2(Of TwoCharacterDLLHorizontal,
                                      TwoCharacterDLLVertical)

    Private Enum EnumTwoListsMode
        Undetermined
        HorizontalCols
        VerticalRows
    End Enum


    Private Function GetCurrentListMode() As EnumTwoListsMode
        ''
        ''Added 1/24/2024 
        ''
        Dim colorMode1 As Drawing.Color
        Dim colorMode2 As Drawing.Color
        Dim colorModeCurrent As Drawing.Color
        Dim boolMode1 As Boolean
        Dim boolMode2 As Boolean
        Dim return_enumMode As EnumTwoListsMode

        colorMode1 = labelItemsDisplay1Cols.BackColor
        colorMode2 = labelItemsDisplay2Rows.BackColor
        colorModeCurrent = userControlOperationBoth.BackColor

        boolMode1 = (colorModeCurrent = colorMode1)
        boolMode2 = (colorModeCurrent = colorMode2)
        If (boolMode1) Then return_enumMode = EnumTwoListsMode.HorizontalCols
        If (boolMode2) Then return_enumMode = EnumTwoListsMode.VerticalRows
        Return return_enumMode

    End Function ''End of ""Private Function CurrentListMode() As EnumTwoListsMode""


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ''
        ''Added 3/01/2024 Thomas D. 
        ''
        Dim opInitialLoad1Cols As DLL_OperationV2
        Dim opInitialLoad2Rows As DLL_OperationV2
        Dim firstTwoCharH As New TwoCharacterDLLHorizontal("01")
        Dim firstTwoCharV As New TwoCharacterDLLVertical("01")

        mod_list1Cols = New DLL_List_OfTControl_PLEASE_USE(Of TwoCharacterDLLItem)(firstTwoCharH)
        mod_list2Rows = New DLL_List_OfTControl_PLEASE_USE(Of TwoCharacterDLLItem)(firstTwoCharV)

        opInitialLoad1Cols = Load_DLL_List_Horizontal(mod_list1Cols, firstTwoCharH)
        opInitialLoad2Rows = Load_DLL_List_Vertical(mod_list2Rows, firstTwoCharV)

        ''--userControlOperation1.DLL_List = mod_list
        userControlOperationBoth.DLL_ListHorizontal = mod_list1Cols
        userControlOperationBoth.DLL_ListVertical = mod_list2Rows

        ''We have a manager.3/2024 mod_opsList = New DLL_List_OfTControl_PLEASE_USE(Of DLL_OperationV2)(opInitialLoad)

        Dim INCLUDE_LOAD_IN_REDO_LIST As Boolean = True ''False
        Try
            Dim my_app_settings As My.MySettings ''Added 2/27/2024 thomas downes
            my_app_settings = My.Settings
            INCLUDE_LOAD_IN_REDO_LIST = my_app_settings.AllowUnloadOfList

        Catch err_config As Exception
            MessageBoxTD.Show_Statement(err_config.Message)
        End Try ''Catch 

        If (INCLUDE_LOAD_IN_REDO_LIST) Then
            ''Do ---REPEAT, DO-- include the loading of the list.
            ''3/2024 mod_opsManager = New DLLOperationsManager(Of TwoCharacterDLLItem)(mod_list,
            ''                              opInitialLoad.GetCopyV1())
            mod_managerOfOps = New DLLOperationsManager2x2(Of TwoCharacterDLLHorizontal,
                   TwoCharacterDLLVertical)(mod_list1Cols, mod_list2Rows,
                                            opInitialLoad1Cols.GetCopyV1(),
                                            opInitialLoad2Rows.GetCopyV1())
        Else
            ''Do ---NOT-- include the loading of the list.
            ''3/2024 mod_managerOfOps = New DLLOperationsManager(Of TwoCharacterDLLItem)(mod_list)
            mod_managerOfOps = New DLLOperationsManager2x2(Of TwoCharacterDLLHorizontal,
                   TwoCharacterDLLVertical)(mod_list1Cols, mod_list2Rows)

        End If ''END OF ::If (INCLUDE_LOAD_IN_REDO_LIST) Then... Else... 


    End Sub ''End of Public Sub New 


    Private Function Load_DLL_List_Horizontal(par_list As DLL_List_OfTControl_PLEASE_USE(Of TwoCharacterDLLItem),
           Optional par_firstItem As TwoCharacterDLLHorizontal = Nothing) As DLL_OperationV2
        ''
        ''Encapsulated 12/25/2023 thomas downes
        ''
        Dim each_twoCharsItem As TwoCharacterDLLItem
        Dim each_strTwoChars As String
        Dim prior As TwoCharacterDLLItem = Nothing
        Dim bListIsEmpty As Boolean = True
        Dim op_result As DLL_OperationV2 ''Added 12/28/2023 td
        Dim firstTwoChar As TwoCharacterDLLItem ''Added 1/22/2024

        ''Clear the list.
        par_list.DLL_ClearAllItems()
        ''prior = par_firstItem
        bListIsEmpty = (0 = par_list.DLL_CountAllItems())
        If (Not bListIsEmpty) Then Debugger.Break()
        ''#1 1/22/2024 mod_firstTwoChar = par_firstItem
        ''#2 1/22/2024 firstTwoChar = mod_list.DLL_GetFirstItem()
        firstTwoChar = par_firstItem

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
        For benchmark = firstBenchmark_1or2 To INITIAL_ITEM_COUNT_Cols

            each_strTwoChars = String.Format("{0:00}", benchmark)
            ''12/2023 each_twoCharsItem = New TwoCharacterDLLItem(each_strTwoChars, prior)
            each_twoCharsItem = New TwoCharacterDLLItem(each_strTwoChars)

            If (prior Is Nothing) Then
                ''Only occurs on first iteration.
                ''1/22/2024 mod_firstTwoChar = each_twoCharsItem

                ''Add the very first item. 
                par_list.DLL_AddFirstAndOnlyItem(each_twoCharsItem)

            Else
                ''---Not needed here....
                ''---prior.DLL_SetItemNext(each_twoCharsItem)
                par_list.DLL_InsertOneItemAfter(each_twoCharsItem, prior, True)

            End If ''End of ""If (prior Is Nothing) Then... Else... "

            ''
            ''Prepare for next iteration of the loop.
            ''
            prior = each_twoCharsItem
            bListIsEmpty = False

        Next benchmark ''Next index

        ''
        ''Added 12/28/2023 
        ''
        op_result = New DLL_OperationV2("I"c, firstTwoChar,
                            INITIAL_ITEM_COUNT_Cols, Nothing, Nothing, True)
        ''added 12/28
        Dim copyOfOpV1 As DLL_OperationV1
        Dim copyOfOpV2 As DLL_OperationV2
        Dim bCopyV2_ofCopyV1_match As Boolean = False

        If (Testing.TestingByDefault) Then
            copyOfOpV1 = op_result.GetCopyV1()
            copyOfOpV2 = copyOfOpV1.GetCopyV2()

            ''--bCopyV2_ofCopyV1_match = Me.Equals(copyOfOpV2)
            bCopyV2_ofCopyV1_match = op_result.Equals(copyOfOpV2)
            If (bCopyV2_ofCopyV1_match) Then
                ''Bravo!!! 12/30/2023 
            Else
                Debugger.Break()
            End If
        End If ''End of ""If (Testing.TestingByDefault) Then""

        ''
        ''This is a function, so return the result!!
        ''
        Return op_result

    End Function ''End of ""Private Function Load_DLL_List_Horizontal""


    Private Function Load_DLL_List_Vertical(par_list As DLL_List_OfTControl_PLEASE_USE(Of TwoCharacterDLLItem),
           Optional par_firstItem As TwoCharacterDLLVertical = Nothing) As DLL_OperationV2
        ''
        ''Encapsulated 12/25/2023 thomas downes
        ''
        Dim each_twoCharsItem As TwoCharacterDLLItem
        Dim each_strTwoChars As String
        Dim prior As TwoCharacterDLLItem = Nothing
        Dim bListIsEmpty As Boolean = True
        Dim op_result As DLL_OperationV2 ''Added 12/28/2023 td
        Dim firstTwoChar As TwoCharacterDLLItem ''Added 1/22/2024

        ''Clear the list.
        par_list.DLL_ClearAllItems()
        ''prior = par_firstItem
        bListIsEmpty = (0 = par_list.DLL_CountAllItems())
        If (Not bListIsEmpty) Then Debugger.Break()
        ''#1 1/22/2024 mod_firstTwoChar = par_firstItem
        ''#2 1/22/2024 firstTwoChar = mod_list.DLL_GetFirstItem()
        firstTwoChar = par_firstItem

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
        For benchmark = firstBenchmark_1or2 To INITIAL_ITEM_COUNT_Cols

            each_strTwoChars = String.Format("{0:00}", benchmark)
            ''12/2023 each_twoCharsItem = New TwoCharacterDLLItem(each_strTwoChars, prior)
            each_twoCharsItem = New TwoCharacterDLLItem(each_strTwoChars)

            If (prior Is Nothing) Then
                ''Only occurs on first iteration.
                ''1/22/2024 mod_firstTwoChar = each_twoCharsItem

                ''Add the very first item. 
                par_list.DLL_AddFirstAndOnlyItem(each_twoCharsItem)

            Else
                ''---Not needed here....
                ''---prior.DLL_SetItemNext(each_twoCharsItem)
                par_list.DLL_InsertOneItemAfter(each_twoCharsItem, prior, True)

            End If ''End of ""If (prior Is Nothing) Then... Else... "

            ''
            ''Prepare for next iteration of the loop.
            ''
            prior = each_twoCharsItem
            bListIsEmpty = False

        Next benchmark ''Next index

        ''
        ''Added 12/28/2023 
        ''
        op_result = New DLL_OperationV2("I"c, firstTwoChar,
                            INITIAL_ITEM_COUNT_Cols, Nothing, Nothing, True)
        ''added 12/28
        Dim copyOfOpV1 As DLL_OperationV1
        Dim copyOfOpV2 As DLL_OperationV2
        Dim bCopyV2_ofCopyV1_match As Boolean = False

        If (Testing.TestingByDefault) Then
            copyOfOpV1 = op_result.GetCopyV1()
            copyOfOpV2 = copyOfOpV1.GetCopyV2()

            ''--bCopyV2_ofCopyV1_match = Me.Equals(copyOfOpV2)
            bCopyV2_ofCopyV1_match = op_result.Equals(copyOfOpV2)
            If (bCopyV2_ofCopyV1_match) Then
                ''Bravo!!! 12/30/2023 
            Else
                Debugger.Break()
            End If
        End If ''End of ""If (Testing.TestingByDefault) Then""

        ''
        ''This is a function, so return the result!!
        ''
        Return op_result

    End Function ''End of ""Private Function Load_DLL_List_Horizontal""


    Private Sub RefreshTheUI_DisplayList_Cols()
        ''
        ''Populate the UI with column-related data. 
        ''
        Dim strListOfLinks_Cols As String
        Dim strListOfLinks_Rows As String

        ''Colums (Horizontal List of two-character numbers)
        strListOfLinks_Cols = FillTheTextboxDisplayingList_Cols()
        labelItemsDisplay1Cols.Text = strListOfLinks_Cols

        ''Rows (Vertical List of two-character numbers)
        strListOfLinks_Rows = FillTheTextboxDisplayingList_Rows()
        labelItemsDisplay2Rows.Text = strListOfLinks_Rows

        ''Added 12/28/2023 
        Dim itemCount_Cols As Integer = mod_list1Cols.DLL_CountAllItems()
        Dim itemCount_Rows As Integer = mod_list2Rows.DLL_CountAllItems()
        ''----userControlOperationBoth.UpdateTheItemCount(itemCount_Rows)
        userControlOperationBoth.UpdateTheItemCount(itemCount_Cols)

        ''Added 1/04/202
        ''
        ''  Let's maintain the two(2) linklabels which represent
        ''    the list's endpoint & prior-to-endpoint.
        ''
        Dim last_item As TwoCharacterDLLItem = Nothing
        Dim prior_to_last As TwoCharacterDLLItem = Nothing

        last_item = CType(mod_list1Cols.DLL_GetLastItem(), TwoCharacterDLLItem)
        If (last_item Is Nothing) Then
            ''
            ''The user has elected to delete the entire list. 
            ''
        Else
            linkToEndpoint.Text = last_item.ToString()
            prior_to_last = CType(last_item.DLL_GetItemPrior(), TwoCharacterDLLItem)
            If (prior_to_last IsNot Nothing) Then
                linkToPenultimate.Text = prior_to_last.ToString()
            End If ''End of ""If (prior_to_last IsNot Nothing) Then""
        End If ''End of ""If (last_item Is Nothing) Then... Else..."

        ''Added 1/04/2024
        linkToEndpoint.Tag = last_item ''.ToString()

        ''Added 1/04/2024
        userControlOperationBoth.Lists_Endpoint = last_item
        userControlOperationBoth.Lists_Penultimate = prior_to_last

        ''Added 1/04/2024
        linkToPenultimate.Tag = prior_to_last ''.ToString()

    End Sub ''End of ""Private Sub RefreshTheUI_DisplayList_Cols()""


    Private Sub RefreshTheUI_DisplayList_Rows()
        ''
        ''Populate the UI with Row-related data. 
        ''
        Dim strListOfLinks_Cols As String
        Dim strListOfLinks_Rows As String

        ''Colums (Horizontal List of two-character numbers)
        strListOfLinks_Rows = FillTheTextboxDisplayingList_Rows()
        labelItemsDisplay2Rows.Text = strListOfLinks_Rows

        ''Rows (Vertical List of two-character numbers)
        strListOfLinks_Rows = FillTheTextboxDisplayingList_Rows()
        labelItemsDisplay2Rows.Text = strListOfLinks_Rows

        ''Added 12/28/2023 
        Dim itemCount_Cols As Integer = mod_list1Cols.DLL_CountAllItems()
        Dim itemCount_Rows As Integer = mod_list2Rows.DLL_CountAllItems()
        ''----userControlOperationBoth.UpdateTheItemCount(itemCount_Rows)
        userControlOperationBoth.UpdateTheItemCount(itemCount_Rows)

        ''Added 1/04/202
        ''
        ''  Let's maintain the two(2) linklabels which represent
        ''    the list's endpoint & prior-to-endpoint.
        ''
        Dim last_item As TwoCharacterDLLItem = Nothing
        Dim prior_to_last As TwoCharacterDLLItem = Nothing

        last_item = CType(mod_list2Rows.DLL_GetLastItem(), TwoCharacterDLLItem)
        If (last_item Is Nothing) Then
            ''
            ''The user has elected to delete the entire list. 
            ''
        Else
            linkToEndpoint.Text = last_item.ToString()
            prior_to_last = CType(last_item.DLL_GetItemPrior(), TwoCharacterDLLItem)
            If (prior_to_last IsNot Nothing) Then
                linkToPenultimate.Text = prior_to_last.ToString()
            End If ''End of ""If (prior_to_last IsNot Nothing) Then""
        End If ''End of ""If (last_item Is Nothing) Then... Else..."

        ''Added 1/04/2024
        linkToEndpoint.Tag = last_item ''.ToString()

        ''Added 1/04/2024
        userControlOperationBoth.Lists_Endpoint = last_item
        userControlOperationBoth.Lists_Penultimate = prior_to_last

        ''Added 1/04/2024
        linkToPenultimate.Tag = prior_to_last ''.ToString()

    End Sub ''End of ""Private Sub RefreshTheUI_DisplayList_Rows()""


    Private Sub RefreshTheUI_OperationsCount()
        ''
        ''Added 1/03/2024 
        ''
        Dim intCountOperations As Integer ''Added 1/22/2024 td
        With labelNumOperations
            ''1/13/24 mod_intCountOperations = mod_stackOperations.Count
            ''1/22/2024 mod_intCountOperations = mod_firstPriorOpV1.DLL_CountItemsAllInList()
            intCountOperations = mod_opsManager.CountOfOperations()

            ''1/22/2024 labelNumOperations.Text = String.Format(.Tag, mod_intCountOperations)
            labelNumOperations.Text = String.Format(.Tag, intCountOperations)

        End With ''End of ""With labelNumOperations""

    End Sub ''End of ""Private Sub RefreshTheUI_OperationsCount()""


    Private Sub RefreshTheUI_UndoRedoButtons()
        ''Added 1/15/2024 
        ''1/24/2024 buttonUndo.Enabled = mod_opRedoMarker.HasOperationPrior()
        ''1/24/2024 buttonReDo.Enabled = mod_opRedoMarker.HasOperationNext()
        buttonUndo.Enabled = mod_opsManager.MarkerHasOperationPrior()
        buttonReDo.Enabled = mod_opsManager.MarkerHasOperationNext()

    End Sub ''end of ""Private Sub RefreshTheUI_UndoRedoButtons()""


    Private Function FillTheTextboxDisplayingList_Cols() As String
        ''
        ''Added 12/26/2023  
        ''
        Dim each_twoChar As TwoCharacterDLLItem
        Dim bDone As Boolean = False
        Dim stringbuilderLinkedItems As New StringBuilder(120)
        Dim intCountLoops As Integer = 0
        Dim firstTwoChar As TwoCharacterDLLItem ''Added 1/22/2024
        Dim each_bIsSelected As Boolean ''Added 2/27/2024 td

        ''LabelItemsDisplay.ResetText()
        ''Not needed here. ----labelItemsDisplay.Text = ""
        firstTwoChar = mod_list1Cols.DLL_GetFirstItem()

        If (firstTwoChar Is Nothing) Then
            ''
            ''All the items have been deleted (most likely).
            ''
            Return "The list is empty."

        Else

            each_twoChar = firstTwoChar

            ''For Each each_twoChar In mod_list
            Do Until bDone

                ''LabelItemsDisplay.Text.Append(" +++ " + each_twoChar.ToString())
                ''stringbuilderLinkedItems.Append(" " + each_twoChar.ToString())
                ''stringbuilderLinkedItems.Append("  " + each_twoChar.ToString())
                each_bIsSelected = each_twoChar.Selected
                If (each_bIsSelected) Then
                    ''Added 2/27/2024 td
                    stringbuilderLinkedItems.Append("_" + each_twoChar.ToString())
                Else
                    stringbuilderLinkedItems.Append(" " + each_twoChar.ToString())
                End If ''End of ""If (each_bIsSelected) Then""

                each_twoChar = each_twoChar.DLL_GetItemNext
                bDone = (each_twoChar Is Nothing)
                intCountLoops += 1
                ''If (intCountLoops > 2 * 30) Then Debugger.Break()
                If (intCountLoops > 4 * INITIAL_ITEM_COUNT_Cols) Then Debugger.Break()

            Loop ''End of ""Do Until bDone""
            ''Next each_twoChar

            ''---MessageBoxTD.Show_Statement("Done loading!!")
            ''Return stringbuilderLinkedItems.ToString()
            Dim result As String
            result = stringbuilderLinkedItems.ToString()
            Return result

        End If ''End of ""If (mod_firstTwoChar Is Nothing) Then... Else..."

    End Function ''End of "Private Function FillTheTextboxDisplayingList_Cols()""


    Private Function FillTheTextboxDisplayingList_Rows() As String
        ''
        ''Added 12/26/2023  
        ''
        Dim each_twoChar As TwoCharacterDLLItem
        Dim bDone As Boolean = False
        Dim stringbuilderLinkedItems As New StringBuilder(120)
        Dim intCountLoops As Integer = 0
        Dim firstTwoChar As TwoCharacterDLLItem ''Added 1/22/2024
        Dim each_bIsSelected As Boolean ''Added 2/27/2024 td

        ''LabelItemsDisplay.ResetText()
        ''Not needed here. ----labelItemsDisplay.Text = ""
        firstTwoChar = mod_list2Rows.DLL_GetFirstItem()

        If (firstTwoChar Is Nothing) Then
            ''
            ''All the items have been deleted (most likely).
            ''
            Return "The list is empty."

        Else

            each_twoChar = firstTwoChar

            ''For Each each_twoChar In mod_list
            Do Until bDone

                ''LabelItemsDisplay.Text.Append(" +++ " + each_twoChar.ToString())
                ''stringbuilderLinkedItems.Append(" " + each_twoChar.ToString())
                ''stringbuilderLinkedItems.Append("  " + each_twoChar.ToString())
                each_bIsSelected = each_twoChar.Selected
                If (each_bIsSelected) Then
                    ''Added 2/27/2024 td
                    stringbuilderLinkedItems.Append("_" + each_twoChar.ToString())
                Else
                    stringbuilderLinkedItems.Append(" " + each_twoChar.ToString())
                End If ''End of ""If (each_bIsSelected) Then""

                each_twoChar = each_twoChar.DLL_GetItemNext
                bDone = (each_twoChar Is Nothing)
                intCountLoops += 1
                ''If (intCountLoops > 2 * 30) Then Debugger.Break()
                If (intCountLoops > 4 * INITIAL_ITEM_COUNT_Rows) Then Debugger.Break()

            Loop ''End of ""Do Until bDone""
            ''Next each_twoChar

            ''---MessageBoxTD.Show_Statement("Done loading!!")
            ''Return stringbuilderLinkedItems.ToString()
            Dim result As String
            result = stringbuilderLinkedItems.ToString()
            Return result

        End If ''End of ""If (mod_firstTwoChar Is Nothing) Then... Else..."

    End Function ''End of "Private Function FillTheTextboxDisplayingList_Cols()""




    Private Sub labelItemsDisplay_Click(sender As Object, e As EventArgs) Handles labelItemsDisplay1Cols.Click
        ''
        ''Added 1/24/2024 
        ''
        userControlOperationBoth.BackColor = CType(sender, Control).BackColor

    End Sub

    Private Sub labelItemsDisplay2_Click(sender As Object, e As EventArgs) Handles labelItemsDisplay2Rows.Click

        ''Added 1/24/2024 
        userControlOperationBoth.BackColor = CType(sender, Control).BackColor

    End Sub


    Private Sub DLLOperationCreated_Delete(par_operation As ciBadgeInterfaces.DLL_OperationV1, par_inverseAnchor_PriorToRange As TwoCharacterDLLItem, par_inverseAnchor_NextToRange As TwoCharacterDLLItem) Handles userControlOperationBoth.DLLOperationCreated_Delete
        ''
        ''Added 2/27/2024 thomas downes
        ''
        Dim enumMode As EnumTwoListsMode = GetCurrentListMode()

        If (enumMode = EnumTwoListsMode.HorizontalCols) Then

        ElseIf (enumMode = EnumTwoListsMode.VerticalRows) Then

        End If

    End Sub


    Private Sub userControlOperationBoth_DLLOperationCreated_Insert(par_operation As DLL_OperationV1) Handles userControlOperationBoth.DLLOperationCreated_Insert
        ''
        ''Added 2/27/2024 td
        ''
        Dim enumMode As EnumTwoListsMode = GetCurrentListMode()

        If (enumMode = EnumTwoListsMode.HorizontalCols) Then

        ElseIf (enumMode = EnumTwoListsMode.VerticalRows) Then

        End If


    End Sub

    Private Sub userControlOperationBoth_DLLOperationCreated_MoveRange(par_operationV1 As DLL_OperationV1, par_inverseAnchor_PriorToRange As TwoCharacterDLLItem, par_inverseAnchor_NextToRange As TwoCharacterDLLItem) Handles userControlOperationBoth.DLLOperationCreated_MoveRange
        ''
        ''Added 2/27/2024 td
        ''
        Dim enumMode As EnumTwoListsMode = GetCurrentListMode()

        If (enumMode = EnumTwoListsMode.HorizontalCols) Then

        ElseIf (enumMode = EnumTwoListsMode.VerticalRows) Then

        End If


    End Sub

    Private Sub userControlOperationBoth_DLLOperationCreated_SortAscending(par_operationV1 As DLL_OperationV1, par_isUndoOfSort As Boolean) Handles userControlOperationBoth.DLLOperationCreated_SortAscending
        ''
        ''Added 2/27/2024 td
        ''
        Dim enumMode As EnumTwoListsMode = GetCurrentListMode()

        If (enumMode = EnumTwoListsMode.HorizontalCols) Then

        ElseIf (enumMode = EnumTwoListsMode.VerticalRows) Then

        End If



    End Sub

    Private Sub userControlOperationBoth_DLLOperationCreated_SortDescending(par_operationV1 As DLL_OperationV1, par_isUndoOfSort As Boolean) Handles userControlOperationBoth.DLLOperationCreated_SortDescending
        ''
        ''Added 2/27/2024 td
        ''
        Dim enumMode As EnumTwoListsMode = GetCurrentListMode()

        If (enumMode = EnumTwoListsMode.HorizontalCols) Then

        ElseIf (enumMode = EnumTwoListsMode.VerticalRows) Then

        End If


    End Sub

    Private Sub Display1_MouseUp(sender As Object, e As MouseEventArgs) Handles labelItemsDisplay1Cols.MouseUp
        ''
        ''Added 2/29/2024 thomas downes
        ''
        ''
        ''Added 2/27/2024 thomas downes  
        ''
        Dim x_intPixelPosition As Integer
        ''Dim xfactor_a1 As Double = ((0.061 * 29.0 * 29.0) / (32.0 * 28.0)) '' (0.061 * 29.0 / 32.0) = 0.05528
        ''Dim xfactor_a2 As Double = 0.05479 * 29.0 / (28.73 * 1.0) ''0.0572556 * 20.0 / 20.9
        ''Dim xfactor_a3 As Double = (0.055305 * 24.0 * 29.0 / (28.2 * 28.9469))
        Dim xfactor_a4 As Double = 0.0471544
        Dim ax_double As Double
        Dim constant_b As Double = -0.14 '' -0.2 '' -0.0 '' -1.0
        Dim index_of_item_double As Double
        Dim index_of_item As Integer
        Dim objectListItem As TwoCharacterDLLItem
        Dim bShiftingKey As Boolean ''Added 2/29/2024
        Dim xfactor_a As Double ''Added 2/29/2024

        xfactor_a = xfactor_a4
        x_intPixelPosition = e.Location.X
        ax_double = (xfactor_a * x_intPixelPosition)
        index_of_item_double = (ax_double + constant_b)
        index_of_item = System.Math.Floor(index_of_item_double)
        ''Added 2/29/2024
        bShiftingKey = (Control.ModifierKeys = Keys.Shift)

        Const ENCAPSULATE As Boolean = True ''Added 2/29/2024
        If (ENCAPSULATE) Then ''Added 2/29/2024

            ''Added 2/29/2024
            mod_list1Cols.SelectionRange_ProcessList(index_of_item, bShiftingKey)

        Else
            ''Added 2/27/2024
            If (index_of_item > (-1 + mod_list1Cols.DLL_CountAllItems())) Then Exit Sub
            objectListItem = mod_list1Cols.DLL_GetItemAtIndex(index_of_item)
            ''--objectListItem.Selected = True
            objectListItem.Selected = (Not objectListItem.Selected) ''Toggle the value. ''True
        End If ''eND OF ""If (ENCAPSULATE) Then... Else..."

        ''Added 2/27/2024 
        ''3/11/2024  RefreshTheUI_DisplayList()
        RefreshTheUI_DisplayList_Cols()

    End Sub



    Private Sub Display2_MouseUp(sender As Object, e As MouseEventArgs) Handles labelItemsDisplay2Rows.MouseUp
        ''
        ''Added 2/29/2024 thomas downes
        ''
        Dim x_intPixelPosition As Integer
        Dim xfactor_a4 As Double = 0.0471544
        Dim ax_double As Double
        Dim constant_b As Double = -0.14 '' -0.2 '' -0.0 '' -1.0
        Dim index_of_item_double As Double
        Dim index_of_item As Integer
        Dim objectListItem As TwoCharacterDLLItem
        Dim bShiftingKey As Boolean ''Added 2/29/2024
        Dim xfactor_a As Double ''Added 2/29/2024

        xfactor_a = xfactor_a4
        x_intPixelPosition = e.Location.X
        ax_double = (xfactor_a * x_intPixelPosition)
        index_of_item_double = (ax_double + constant_b)
        index_of_item = System.Math.Floor(index_of_item_double)
        ''Added 2/29/2024
        bShiftingKey = (Control.ModifierKeys = Keys.Shift)

        Const ENCAPSULATE As Boolean = True ''Added 2/29/2024
        If (ENCAPSULATE) Then ''Added 2/29/2024

            ''Added 2/29/2024
            mod_list2Rows.SelectionRange_ProcessList(index_of_item, bShiftingKey)

        Else
            ''Added 2/27/2024
            If (index_of_item > (-1 + mod_list2Rows.DLL_CountAllItems())) Then Exit Sub
            objectListItem = mod_list2Rows.DLL_GetItemAtIndex(index_of_item)
            ''--objectListItem.Selected = True
            objectListItem.Selected = (Not objectListItem.Selected) ''Toggle the value. ''True
        End If ''eND OF ""If (ENCAPSULATE) Then... Else..."

        ''Added 2/27/2024 
        ''3/11/2024  RefreshTheUI_DisplayList()
        RefreshTheUI_DisplayList_Rows()


    End Sub

    Private Sub FormTestTwoLists2x2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 3/05/2024 thomas
        ''




    End Sub



End Class