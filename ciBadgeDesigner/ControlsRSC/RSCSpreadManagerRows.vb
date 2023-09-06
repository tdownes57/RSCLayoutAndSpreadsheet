''
''Added 4/18/2023 
''
Imports ciBadgeRecipients

Public Class RSCSpreadManagerRows
    ''
    ''Added 4/18/2023 
    ''
    ''Not currently in use. 5/9/2023 Private mod_controlSpread As RSCFieldSpreadsheet ''Added 4/18/2023 
    ''Obselete. 5/9/2023 Private mod_dict_columns As Dictionary(Of Integer, RSCFieldColumnV2)
    Private mod_dlist_columns As RSCFieldColumnList ''Added 5/09/2023 
    Private mod_columnDesignTemplateV2 As RSCFieldColumnV2
    Private mod_rowHeadersRSCCtl As RSCRowHeaders ''Added 4/26/2023 td
    Private mod_manager_cols As RSCSpreadManagerCols ''Added 9/05/2023 td

    Public Sub New(par_controlSpread As RSCFieldSpreadsheet,
                   par_listOfColumns As RSCFieldColumnList,
                   par_columnDesignTemplate As RSCFieldColumnV2,
                   par_rowHeadersRSCCtl As RSCRowHeaders,
                   par_manager_cols As RSCSpreadManagerCols)
        ''
        ''Added 4/18/2023  
        ''
        ''Not currently in use. 5/9/2023 mod_controlSpread = par_controlSpread
        mod_dlist_columns = par_listOfColumns
        mod_columnDesignTemplateV2 = par_columnDesignTemplate ''Added 4/26/2023
        mod_rowHeadersRSCCtl = par_rowHeadersRSCCtl ''Added 4/26/2023
        mod_manager_cols = par_manager_cols ''Added 9/5/2023 td

    End Sub ''End of Publice Sub New


    ''Obselete as of 5/9/2023
    ''Public Sub New(par_controlSpread As RSCFieldSpreadsheet,
    ''               par_dictionaryColumns As Dictionary(Of Integer, RSCFieldColumnV2),
    ''               par_columnDesignTemplate As RSCFieldColumnV2,
    ''               par_rowHeadersRSCCtl As RSCRowHeaders)
    ''    ''
    ''    ''Added 4/18/2023  
    ''    ''
    ''    mod_controlSpread = par_controlSpread
    ''    mod_dict_columns = par_dictionaryColumns
    ''    mod_columnDesignedV2 = par_columnDesignTemplate ''Added 4/26/2023
    ''    mod_rowHeadersRSCCtl = par_rowHeadersRSCCtl ''Added 4/26/2023
    ''
    ''End Sub ''End of Publice Sub New

    Public Function GetListOfRecipients() As List(Of ClassRecipient)
        ''
        ''Added 8/31/2023  thomas Downes
        ''
        ''Throw NotImplementedException
        Return mod_rowHeadersRSCCtl.GetListOfRecipients()


    End Function ''End of ""Public Function GetListOfRecipients() As List(Of ClassRecipient)"" 


    Public Sub AddToEdgeOfSpreadsheet_Row()
        ''4/2022 Public Sub AddRowToBottomOfSpreadsheet() 

        ''Added 4/30/2022 thomas downes
        ''Me.ParentSpreadsheet.AddRowToBottomOfSpreadsheet()
        Dim intRowCount As Integer
        Dim intRowCount_PlusOne As Integer

        ''4/26/2023 intRowCount = RscRowHeaders1.CountOfRows()
        intRowCount = mod_rowHeadersRSCCtl.CountOfRows()

        intRowCount_PlusOne = (intRowCount + 1)
        ''4/26/2023 td''RscRowHeaders1.Load_OneEmptyRow_IfNeeded(intRowCount_PlusOne) ''(1 + intRowCount)
        mod_rowHeadersRSCCtl.Load_OneEmptyRow_IfNeeded(intRowCount_PlusOne) ''(1 + intRowCount)

        ''Add a new textbox to each column. 
        ''4/26/2023 td''For Each each_RSCCol As RSCFieldColumnV2 In mod_dict_RSCColumns.Values
        ''5/09/2023 For Each each_RSCCol As RSCFieldColumnV2 In mod_dict_columns.Values
        For Each each_RSCCol As RSCFieldColumnV2 In mod_dlist_columns ''5/2023 .Values
            If (each_RSCCol Is Nothing) Then Continue For
            each_RSCCol.Load_EmptyRows(intRowCount_PlusOne)
        Next each_RSCCol

    End Sub ''End of ""Public Sub AddToEdgeOfSpreadsheet_Row()""


    Public Sub LoadEmptyRows()

        ''Use the Row manager for this. --4/19/2023 td
        ''5/09/2023 For Each each_column As RSCFieldColumnV2 In mod_dict_columns.Values
        For Each each_column As RSCFieldColumnV2 In mod_dlist_columns ''5/2023 .Values

            each_column.Load_EmptyRows(mod_columnDesignTemplateV2.CountOfRows())
            ''4/19/2023 Dim intRowCount As Integer = NumberOfRowsNeededToStart
            Dim intRowCount As Integer = mod_columnDesignTemplateV2.CountOfRows()

            ''4/26/2023 If (intRowCount = 0) Then intRowCount = Me.DefaultBlankRowCount
            ''4/26/2023 If (intRowCount = 0) Then intRowCount = Me.Default
            If (intRowCount = 0) Then
                intRowCount = mod_columnDesignTemplateV2.CountOfRows()
            End If ''End of ""If (intRowCount = 0) Then""

            each_column.Load_EmptyRows(intRowCount)

        Next each_column

    End Sub ''End of ""Public Sub LoadEmptyRows()""


    Public Sub Load_EmptyRowsToAllNewColumns()
        ''
        ''Added 4/15/2022 td
        ''
        Dim intEachRowCount As Integer = 1
        Dim intMaxRowCount As Integer = 1
        '5/09/2023 Dim list_columns As List(Of RSCFieldColumnV2)
        Dim boolMissingRows As Boolean

        ''4/26/2023 list_columns = ListOfColumns()
        ''5/09/2023 list_columns = mod_dict_columns.Values.ToList()

        ''5/9/2023 For Each each_column As RSCFieldColumnV2 In list_columns ''March30 2022 td''Me.ListOfColumns()
        For Each each_column As RSCFieldColumnV2 In mod_dlist_columns
            intEachRowCount = each_column.CountOfRows()
            If (intEachRowCount > intMaxRowCount) Then intMaxRowCount = intEachRowCount
        Next each_column

        ''5/9/2023 For Each each_column As RSCFieldColumnV2 In list_columns ''March30 2022 td''Me.ListOfColumns()
        For Each each_column As RSCFieldColumnV2 In mod_dlist_columns
            boolMissingRows = (each_column.CountOfRows() < intMaxRowCount)
            If (boolMissingRows) Then
                each_column.Load_EmptyRows(intMaxRowCount)
            End If ''End of ""If (boolMissingRows) Then""
        Next each_column

    End Sub ''End of ""Public Sub Load_EmptyRowsToAllNewColumns()""


    Public Sub ShowEmptyRowMessage_IfApplicable()
        ''
        ''Added 9/3/2023 thomas downes
        ''
        Dim each_recipient As ClassRecipient
        Dim each_bIsRecipientEmpty As Boolean
        Dim each_bIsSpreadsheetRowEmpty As Boolean
        Dim each_bCompletelyEmpty As Boolean
        Dim each_rowIndex As Integer

        For Each each_rowHeader As RSCRowHeader In
            mod_rowHeadersRSCCtl.ListOfRowHeaders_TopToBottom

            each_rowIndex = each_rowHeader.RowIndex
            each_recipient = each_rowHeader.GetRecipient()
            each_bIsRecipientEmpty = each_recipient.IsEmpty()
            ''each_bIsSpreadsheetRowEmpty = mod_dlist_columns.IsRowEmpty(each_rowIndex)
            each_bIsSpreadsheetRowEmpty = mod_manager_cols.IsRowEmpty(each_rowIndex)
            each_bCompletelyEmpty = (each_bIsRecipientEmpty And
                    each_bIsSpreadsheetRowEmpty)

            If (each_bCompletelyEmpty) Then
                ''
                ''Row is completely empty. 
                ''
                mod_manager_cols.ToggleMessage_RowIsEmpty(each_rowIndex,
                     True, each_bCompletelyEmpty)

            Else
                mod_manager_cols.ToggleMessage_RowIsEmpty(each_rowIndex,
                     True, each_bCompletelyEmpty)

            End If ''End of ""If (each_bCompletelyEmpty) Then... Else"

        Next each_rowHeader


    End Sub ''End of ""Public Sub ShowEmptyRowMessage_IfApplicable()""



    ''--+--See module RSCSpreadManagerRows.vb instead. ---9/3/2023 td
    ''
    ''--+--Public Sub ToggleMessage_RowIsEmpty(par_intRowIndex As Integer,
    ''--+--                                    Optional par_bGuaranteeStatus As Boolean = False,
    ''--+--                                    Optional par_bSetRowToEmpty As Boolean = True)
    ''    ''
    ''    ''Added 9/3/2023 
    ''    ''
    ''    For Each each_column As RSCFieldColumnV2 In mod_dlist_columns
    ''        each_column.ToggleMessage_RowIsEmpty(par_intRowIndex,
    ''                           par_bGuaranteeStatus, par_bSetRowToEmpty)
    ''    Next each_column
    ''End Sub ''End of ""Public Sub ToggleMessage_RowIsEmpty""


    ''Public Function GetListOfRecipients() As List(Of ClassRecipient)
    ''    ''
    ''    ''Added 8/31/2023  thomas Downes
    ''    ''
    ''    ''Throw NotImplementedException
    ''    Return mod_rowHeadersRSCCtl.GetListOfRecipients()
    ''End Function ''End of ""Public Function GetListOfRecipients() As List(Of ClassRecipient)"" 



End Class
