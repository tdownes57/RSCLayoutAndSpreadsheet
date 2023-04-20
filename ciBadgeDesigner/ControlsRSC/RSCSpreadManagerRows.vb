''
''Added 4/18/2023 
''
Public Class RSCSpreadManagerRows
    ''
    ''Added 4/18/2023 
    ''
    Private mod_controlSpread As RSCFieldSpreadsheet ''Added 4/18/2023 
    Private mod_dict_columns As Dictionary(Of Integer, RSCFieldColumnV2)
    Private mod_columnDesignedV2 As RSCFieldColumnV2

    Public Sub New(par_controlSpread As RSCFieldSpreadsheet,
                   par_dictionaryColumns As Dictionary(Of Integer, RSCFieldColumnV2),
                   par_columnDesignTemplate As RSCFieldColumnV2)
        ''
        ''Added 4/18/2023  
        ''
        mod_controlSpread = par_controlSpread
        mod_dict_columns = par_dictionaryColumns

    End Sub ''End of Publice Sub New


    Public Sub LoadEmptyRows()

        ''Use the Row manager for this. --4/19/2023 td
        For Each each_column As RSCFieldColumnV2 In mod_dict_columns.Values

            each_column.Load_EmptyRows(mod_columnDesignedV2.CountOfRows())
            ''4/19/2023 Dim intRowCount As Integer = NumberOfRowsNeededToStart
            Dim intRowCount As Integer = mod_columnDesignedV2.CountOfRows()
            If (intRowCount = 0) Then intRowCount = Me.DefaultBlankRowCount
            each_column.Load_EmptyRows(intRowCount)

        Next each_column

    End Sub ''End of ""Public Sub LoadEmptyRows()""





End Class
