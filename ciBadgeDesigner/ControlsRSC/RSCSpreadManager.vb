''
''Added 4/18/2023 
''

Imports ciBadgeCachePersonality

Public Class RSCSpreadManager
    ''
    ''Added 4/18/2023 
    ''
    Private mod_manageRows As RSCSpreadManagerRows ''Added 4/18/2023 
    Private mod_manageCols As RSCSpreadManagerCols ''Added 4/18/2023 
    Private mod_manageRowHeaders As RSCSpreadManagerRowHeaders ''Added 4/19/2023 
    Private mod_controlSpread As RSCFieldSpreadsheet ''Added 4/18/2023 
    Private mod_cacheElements As ClassElementsCache_Deprecated


    Public Sub New(par_controlSpread As RSCFieldSpreadsheet,
                   par_columnDesignV2 As RSCFieldColumnV2,
                   par_cacheElemements As ClassElementsCache_Deprecated,
                   par_cacheColumnWidthsEtc As CacheRSCFieldColumnWidthsEtc)
        ''
        ''Added 4/18/2023  
        ''
        mod_controlSpread = par_controlSpread
        mod_manageCols = New RSCSpreadManagerCols(par_controlSpread, par_columnDesignV2,
                                                  par_cacheElemements,
                                                  par_cacheColumnWidthsEtc)

        ''4/19/2023 mod_manageRows = New RSCSpreadManagerRows(par_controlSpread)
        mod_manageRows = mod_manageCols.GetSpreadManagerRows()

    End Sub ''End of Public Sub New 


    Public Function GetSpreadManagerRows() As RSCSpreadManagerRows

        ''Added 4/19/2023 td
        Return mod_manageCols.GetSpreadManagerRows()

    End Function ''End of ""Public Function GetSpreadManagerRows()""


    Public ReadOnly Property Cols As RSCSpreadManagerCols
        Get
            ''Added 4/18/2023
            ''  Return the Columns Manager. 
            Return mod_manageCols
        End Get
    End Property


    Public ReadOnly Property Rows As RSCSpreadManagerRows
        Get
            ''Added 4/18/2023
            ''  Return the Rows Manager. 
            Return mod_manageRows
        End Get
    End Property


    Public ReadOnly Property RowHeaders As RSCSpreadManagerRowHeaders
        Get
            ''Added 4/18/2023
            ''  Return the RowHeaders Manager. 
            Return mod_manageRowHeaders
        End Get
    End Property










End Class
