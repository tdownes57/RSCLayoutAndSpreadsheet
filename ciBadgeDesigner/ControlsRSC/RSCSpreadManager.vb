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
                   par_designer As ClassDesigner,
                   par_columnDesignV2 As RSCFieldColumnV2,
                   par_cacheElemements As ClassElementsCache_Deprecated,
                   par_cacheColumnWidthsEtc As CacheRSCFieldColumnWidthsEtc)
        ''
        ''Added 4/18/2023  
        ''
        mod_controlSpread = par_controlSpread

        ''4/26/2023 mod_manageCols = New RSCSpreadManagerCols(par_controlSpread, par_columnDesignV2,
        ''                                          par_cacheElemements,
        ''                                          par_cacheColumnWidthsEtc)
        mod_manageCols = New RSCSpreadManagerCols(par_controlSpread, par_designer,
                                                  par_columnDesignV2,
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


    Public Function GetRowIndexOfCell(par_objDataCell As RSCDataCell) As Integer
        ''
        ''Added 4/27/2022 thomas downes
        ''
        Return mod_manageCols.GetRowIndexOfCell(par_objDataCell)

    End Function ''End of ""Public Function GetRowIndexOfCell(par_objDataCell As RSCDataCell)""


    Public Sub ClearDataFromSpreadsheet_NoConfirm()
        ''
        ''Added 4/26/2022 thomas downes
        ''
        mod_manageCols.ClearDataFromSpreadsheet_NoConfirm()

    End Sub ''End of ""Public Sub ClearDataFromSpreadsheet_NoConfirm()""


    Public Sub EmphasizeRows_Highlight(par_intRowIndex_Start As Integer,
                  Optional par_intRowIndex_End As Integer = -1)
        ''
        ''Added 4/29/2022 td
        ''
        mod_manageCols.EmphasizeRows_Highlight(par_intRowIndex_Start,
                                                par_intRowIndex_End)

    End Sub ''End of ""Public Sub EmphasizeRows_Highlight"


    Public Sub LoadRowHeadersControl()
        ''
        ''Step 1b of 5.  Load run-time row-header control (RSCRowHeaders1). ----3/24/2022 
        ''
        ''   Step 1b(1):  Remove design-time control
        ''   Step 1b(2):  Load run-time control
        ''
        ''Step 1b(1):  Remove design-time control
        mod_controlSpread.RscRowHeaders1.Visible = False ''Hardly matters, but go ahead. 
        mod_controlSpread.Controls.Remove(mod_controlSpread.RscRowHeaders1)

        ''Step 1b(2):  Load run-time control
        Dim intCurrentPropertyLeft As Integer = 0
        Dim intNextPropertyLeft As Integer = 0
        RscRowHeaders1 = RSCRowHeaders.GetRSCRowHeaders(Me.Designer, Me.ParentForm,
             "RscRowHeaders1", Me)
        Me.Controls.Add(RscRowHeaders1)
        RscRowHeaders1.Visible = True
        RscRowHeaders1.Top = (intSavePropertyTop_RSCColumnCtl +
            intSavePropertyTop_FirstRow - 2)
        RscRowHeaders1.Left = (intCurrentPropertyLeft)

        ''---RscRowHeaders1.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right), AnchorStyles)
        ''4/29/2023 intNextPropertyLeft += (RscRowHeaders1.Width + mc_ColumnMarginGap)
        intNextPropertyLeft += (RscRowHeaders1.Width + RSCSpreadManagerCols.mc_ColumnMarginGap)

        ''Assigned within the loop below.--3/24/2022 td''intCurrentPropertyLeft = intNextPropertyLeft
        RscRowHeaders1.PixelsFromRowToRow = mc_intPixelsFromRowToRow ''Added 4/5/2022
        RscRowHeaders1.ParentRSCSpreadsheet = Me ''Added 4/29/2022 thomas  



    End Sub ''End of ""Public Sub LoadRowHeaders()""



End Class
