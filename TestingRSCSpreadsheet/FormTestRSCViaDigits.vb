Imports ciBadgeInterfaces
''---Imports ciBadgeRecipients

Public Class FormTestRSCViaDigits

    Private mod_list As DLL_List_OfTControl_PLEASE_USE(Of TwoCharacterDLLItem)
    Private mod_firstTwoChar As TwoCharacterDLLItem

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

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

        ''Populate the UI. 
        FillTheTextboxDisplayingList


    End Sub


    Private Sub FillTheTextboxDisplayingList()
        ''
        ''Added 12/26/2023  
        ''
        Dim each_twoChar As TwoCharacterDLLItem
        Dim bDone As Boolean = False

        LabelItemsDisplay.ResetText()
        each_twoChar = mod_firstTwoChar

        ''For Each each_twoChar In mod_list
        Do Until bDone

            LabelItemsDisplay.Text.Append(" " + each_twoChar.ToString())

            each_twoChar = each_twoChar.DLL_GetItemNext
            bDone = (each_twoChar Is Nothing)

        Loop
        ''Next each_twoChar

    End Sub ''Ednd of :":"Private Sub FillTheTextboxDisplayingList()""



    Private Sub Load_DLL_List(par_list As DLL_List_OfTControl_PLEASE_USE(Of TwoCharacterDLLItem))
        ''
        ''Encapsulated 12/25/2023 thomas downes
        ''
        Dim each_twoCharsItem As TwoCharacterDLLItem
        Dim each_strTwoChars As String
        Dim prior As TwoCharacterDLLItem = Nothing
        Dim bListIsEmpty As Boolean = True

        ''Clear the list.
        par_list.DLL_ClearAllItems()

        For index = 1 To 30

            each_strTwoChars = String.Format("{0:99}", index)
            each_twoCharsItem = New TwoCharacterDLLItem(each_strTwoChars, prior)

            If (prior Is Nothing) Then
                ''Only occurs on first iteration.
                mod_firstTwoChar = each_twoCharsItem
            Else
                prior.DLL_SetItemNext(each_twoCharsItem)
            End If

            If (bListIsEmpty) Then
                ''Add the very first item. 
                par_list.DLL_AddFirstAndOnlyItem(each_twoCharsItem)
            Else
                par_list.DLL_InsertOneItemAfter(each_twoCharsItem, prior, True)
            End If ''end of If (bListIsEmpty) Then... Else...

            ''Prepare.
            prior = each_twoCharsItem
            bListIsEmpty = False

        Next index


    End Sub ''End of ""Private Sub Load_DLL_List""

    Private Sub DLL_OperationCreated_Delete(par_operation As DLL_OperationV2,
                                            par_inverseAnchor_PriorToRange As TwoCharacterDLLItem,
                                            par_inverseAnchor_NextToRange As TwoCharacterDLLItem) _
                                            Handles UserControlOperation1.DLLOperationCreated_Delete
        ''
        ''Added 12/25/2023 
        ''



    End Sub

    Private Sub UserControlOperation1_DLLOperationCreated_Insert(par_operation As DLL_OperationV2) _
                           Handles UserControlOperation1.DLLOperationCreated_Insert
        ''
        ''Added 12/25/2023 
        ''




    End Sub

    Private Sub UserControlOperation1_DLLOperationCreated_MoveRange(par_operation As DLL_OperationV2,
                                                                    par_inverseAnchor_PriorToRange As TwoCharacterDLLItem,
                                                                    par_inverseAnchor_NextToRange As TwoCharacterDLLItem) _
                                                                    Handles UserControlOperation1.DLLOperationCreated_MoveRange
        ''
        ''Added 12/25/2023 
        ''

    End Sub
End Class
