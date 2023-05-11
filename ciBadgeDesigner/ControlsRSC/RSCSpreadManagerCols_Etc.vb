''
''Added 4/28/2023  
''

Imports ciBadgeCachePersonality

Partial Public Class RSCSpreadManagerCols
    ''
    ''Added 4/28/2023  
    ''
    Public Sub RefreshFieldDropdowns()
        ''
        ''Added 4/13/2022 thomas downes
        ''
        Dim each_column As RSCFieldColumnV2 ''Added 5/8/2023
        each_column = mod_dlist_RSCColumns.GetFirst()

        ''5/8/2023 For Each each_column As RSCFieldColumnV2 In mod_dict_RSCColumns.Values
        Do While (each_column IsNot Nothing)
            ''Added 4/13/2022 thomas downes
            If (each_column IsNot Nothing) Then
                each_column.RefreshFieldDropdown()
            End If ''end of "If (each_column IsNot Nothing) Then"

            ''5/8/2023 Next each_column
            each_column = each_column.FieldColumnNextRight
        Loop

    End Sub ''End of "Public Sub RefreshFieldDropdowns()"


    Public Sub SaveToRecipient(par_objRecipient As ciBadgeRecipients.ClassRecipient,
                               par_iRowIndex As Integer,
                               Optional ByRef pboolFailure As Boolean = False,
                               Optional ByRef pintHowManyColumnsFailed As Integer = 0)
        ''
        ''Added 5/19/2022 
        ''
        Dim each_column As RSCFieldColumnV2
        Dim each_failure As Boolean  ''Added 5/25/2022 

        ''Track how many columns have failures. 
        pintHowManyColumnsFailed = 0 ''Initialize.  5/245/2022 

        ''5/9/2023 For Each each_column In mod_dict_RSCColumns.Values ''4/17/2023 mod_array_RSCColumns
        For Each each_column In mod_dlist_RSCColumns ''5/9/2023 .Values ''4/17/2023 mod_array_RSCColumns

            ''Added 5/20/2022 td
            If (each_column Is Nothing) Then Continue For

            With each_column
                ''#1 5/25/2022 ''.SaveToRecipient(par_objRecipient, par_iRowIndex)
                ''#2 5/25/2022 ''.SaveToRecipient(par_objRecipient, par_iRowIndex, pboolFailure)
                each_failure = False ''Initialize. 5/25/2022
                .SaveToRecipient(par_objRecipient, par_iRowIndex, each_failure)
            End With

            If (each_failure) Then pboolFailure = True
            If (each_failure) Then pintHowManyColumnsFailed += 1

        Next each_column

    End Sub ''End of ""Public Sub SaveToRecipient(...)""



    Public Sub SaveDataColumnByColumnXML(Optional pboolOpenXML As Boolean = False)
        ''---June29 2022---Public Sub SaveDataColumnByColumn
        ''
        ''Added 3/17/2022 thomas downes
        ''
        ''STEP 0 of 5 
        ''
        '' Save the form-size & form-location data to the ColumnDataCache. 
        ''
        Me.ColumnDataCache.FormSize = Me.mod_designer.DesignerForm.Size
        Me.ColumnDataCache.FormLocation = Me.mod_designer.DesignerForm.Location

        ''STEP 1 of 5 
        ''
        '' Save the column data to the ColumnDataCache. 
        ''
        ''5/10/2023 For intIndex As Integer = 1 To Me.ColumnDataCache.ListOfColumns.Count
        ''    eachColumn = mod_dlist_RSCColumns.GetColumnAtIndex(intIndex)
        ''    eachColumn.SaveDataTo_ColumnCache()
        ''Next intIndex

        ''Added 5/10/2023 
        Dim each_columnData As ClassRSCColumnWidthAndData ''Added 5/10/2023 
        Dim each_RSCColumn As RSCFieldColumnV2 ''Added 3/18/2022 thomas downes
        Dim each_ctlWindows As Windows.Forms.Control ''Added 5/2023 thomas downes
        Dim boolNotDeleted As Boolean ''Added 5/2023 thomas downes

        ''Added 5/10/2023 
        For Each each_columnData In Me.ColumnDataCache.ListOfColumns
            ''Added 5/10/2023 
            each_ctlWindows = each_columnData.GetRSCColumnAsControl()
            each_RSCColumn = CType(each_ctlWindows, RSCFieldColumnV2)
            boolNotDeleted = (mod_dlist_RSCColumns.IsStillInList(each_RSCColumn))
            If (boolNotDeleted) Then
                each_RSCColumn.SaveDataTo_ColumnCache()
            End If ''End of "If (boolNotDeleted) Then"
        Next each_columnData

        ''
        ''Resize the form based on the save form size.---3/20/2022
        ''
        ''4/26/2023 Me.ColumnDataCache.FormSize = Me.ParentForm_DesignerDialog.Size

        ''
        ''STEP 3 of 5 
        ''
        '' Save the ColumnDataCache to disk. 
        ''
        Dim strPathToXML_Opened As String = Me.ColumnDataCache.PathToXml_Opened
        Dim strPathToXML_Saved As String = Me.ColumnDataCache.PathToXml_Saved

        If String.IsNullOrEmpty(strPathToXML_Opened) Then strPathToXML_Opened = strPathToXML_Saved
        If String.IsNullOrEmpty(strPathToXML_Opened) Then strPathToXML_Opened =
            DiskFilesVB.PathToFile_XML_RSCFieldSpreadsheet()

        Me.ColumnDataCache.SaveToXML(strPathToXML_Opened)
        Me.ColumnDataCache.PathToXml_Saved = strPathToXML_Opened

        ''
        ''STEP 4 of 5 
        ''
        ''  Column by column, save the current data value to the appropriate recipient field.  
        ''
        For intIndex As Integer = 1 To Me.ColumnDataCache.ListOfColumns.Count

            Dim eachColumn As RSCFieldColumnV2 ''Added 3/18/2022 thomas downes
            ''5/9/2023 eachColumn = mod_dict_RSCColumns(intIndex)
            eachColumn = mod_dlist_RSCColumns.GetColumnAtIndex(intIndex)
            ''4/12/2022 td''eachColumn.SaveDataToColumn()
            eachColumn.SaveDataTo_RecipientCache()

        Next intIndex

        ''
        ''Resize the form based on the save form size.---3/20/2022
        ''
        ''Moved up.3/20/22 ''Me.ColumnDataCache.FormSize = Me.ParentForm_DesignerDialog.Size

        ''Added 3/18/2022 td
        If (pboolOpenXML) Then
            System.Diagnostics.Process.Start(Me.ColumnDataCache.PathToXml_Saved)
        End If ''End of "If (pboolOpenXML) Then"

    End Sub ''End of "Public Sub SaveDataColumnByColumnXML()"



    Public Sub ClearHighlightingOfSelectedColumns()
        ''
        ''Added 5/13/2022 thomas downes
        ''
        Dim objRSCFieldColumn As RSCFieldColumnV2
        For Each each_column As RSCFieldColumnV2 In Me.ListOfColumns
            objRSCFieldColumn = each_column ''---CType(each_column, RSCFieldColumn)
            objRSCFieldColumn.FocusRelated_UserHasSelectedColumn = False
            objRSCFieldColumn.FocusRelated_SetHighlightingOff()
        Next each_column

    End Sub ''End of ""Public Sub ClearHighlightingOfSelectedColumns()""


    Public Sub ClearDataFromSpreadsheet_NoConfirm()
        ''
        ''Added 4/01/2022 thomas downes
        ''
        Dim objRSCFieldColumn As RSCFieldColumnV2
        ''4/26/2023 Dim boolConfirmed As Boolean

        ''5/2023 For Each each_column As RSCFieldColumnV2 In mod_dict_RSCColumns.Values
        For Each each_column As RSCFieldColumnV2 In mod_dlist_RSCColumns ''5/2023 .Values
            objRSCFieldColumn = each_column ''---CType(each_column, RSCFieldColumn)
            objRSCFieldColumn.ClearDataFromColumn_Do()
        Next each_column

    End Sub ''End of ""Public Sub ClearDataFromSpreadsheet_NoConfirm()""


    Public Sub EmphasizeRows_Highlight(par_intRowIndex_Start As Integer,
                  Optional par_intRowIndex_End As Integer = -1)
        ''
        ''Added 4/29/2022 td
        ''
        ''5/2023 For Each each_column As RSCFieldColumnV2 In mod_dict_RSCColumns.Values
        For Each each_column As RSCFieldColumnV2 In mod_dlist_RSCColumns ''5/2023 .Values

            If (each_column Is Nothing) Then Continue For ''Added 4/29/2022 thomas d

            ''---each_col.PaintEmphasisOfRows(par_intRowIndex_Start, par_intRowIndex_End)
            each_column.EmphasizeRows_Highlight(par_intRowIndex_Start, par_intRowIndex_End)

        Next each_column


    End Sub ''End of ""Public Sub EmphasizeRows_Highlight"


    Public Sub DeemphasizeRows_NoHighlight(par_intRowIndex_Start As Integer,
                      Optional par_intRowIndex_End As Integer = -1)
        ''
        ''Added 4/29/2022 td
        ''
        ''5/2023 For Each each_col As RSCFieldColumnV2 In mod_dict_RSCColumns.Values
        For Each each_col As RSCFieldColumnV2 In mod_dlist_RSCColumns ''5/2023 .Values

            If (each_col Is Nothing) Then Continue For ''Added 4/29/2022 td 

            each_col.DeemphasizeRows_NoHighlight(par_intRowIndex_Start, par_intRowIndex_End)

        Next each_col

    End Sub ''End of ""Public Sub EmphasizeRows_Highlight"



    Public Sub ReviewForAbnormalLengthValues_NotInUse(Optional ByRef pboolOneOrMore As Boolean = False,
                                             Optional ByVal pboolGiveMessageIfNeeded As Boolean = False)
        ''
        ''Added 4/26/2022 td
        ''
        Dim each_RSCColumn As RSCFieldColumnV2
        Dim each_isAbnormal As Boolean

        ''
        '' Looping each column. ---4/10/2022 td
        ''
        ''4/17/2023 For Each each_RSCColumn In mod_array_RSCColumns
        ''5/2023 For Each each_RSCColumn As RSCFieldColumnV2 In mod_dict_RSCColumns.Values
        For Each each_RSCColumn In mod_dlist_RSCColumns ''5/2023 .Values

            each_RSCColumn.ReviewForAbnormalLengthValues(each_isAbnormal)
            pboolOneOrMore = (pboolOneOrMore Or each_isAbnormal)

        Next each_RSCColumn

        ''
        ''Possibly give a message. 
        ''
        If (pboolOneOrMore And pboolGiveMessageIfNeeded) Then

            ''Added 4/26/2022 td 
            MessageBoxTD.Show_Statement("Please review cell values. One of more cells have unexpected values.")

        End If ''End of "If (pboolOneOrMore And pboolGiveMessageIfNeeded) Then"


    End Sub ''End of ""Public Sub ReviewForAbnormalLengthValues_NotInUse()""


    Public Sub MoveTextCaret_IfNeeded(par_intNewRowIndex As Integer)
        ''
        ''Added 5/13/2022 thomas downes
        ''
        Const c_bMustHaveCaret As Boolean = False ''False, since when the user clicks on the 
        ''  spreadsheet's row-header control, the Textbox in the RSCDataCell no longer
        ''  pass "True" from the function Textbox.HasFocus(). ----5/13/2022

        ''4/17/2023 For Each each_RSColumn As RSCFieldColumnV2 In mod_array_RSCColumns
        ''5/2023 For Each each_RSColumn As RSCFieldColumnV2 In mod_dict_RSCColumns.Values
        For Each each_RSColumn As RSCFieldColumnV2 In mod_dlist_RSCColumns ''5/2023 .Values

            If (each_RSColumn Is Nothing) Then Continue For

            If (each_RSColumn.FocusRelated_ColumnHasCellFocus(c_bMustHaveCaret)) Then

                each_RSColumn.MoveTextCaretToNewRow(par_intNewRowIndex)
                Exit For ''Leave the "For Each" loop.

            End If ''End of ""If (each_RSColumn.FocusRelated_ColumnHasCellFocus()) Then""

        Next each_RSColumn

    End Sub ''End of ""Public Sub MoveTextCaret_IfNeeded()" 


    ''Public Sub CompactColumnsAfterDeletion(par_columnAboutToDelete As RSCFieldColumnV2,
    ''                                       par_intColumnIndex As Integer)
    ''    ''
    ''    ''Step 1b of 6.  Move the columns to the left, in place of the soon-to-be-deleted column. 
    ''    ''
    ''    Dim intFirstBumpedColumn_Left As Integer ''Added 4/1/2022 thomas downes
    ''    Dim intColumnAboutToDelete_Left As Integer ''Added 4/15/2022
    ''    Dim intWidthOfDeletedColumn As Integer ''Added 4/15/2022
    ''
    ''    intWidthOfDeletedColumn = par_columnAboutToDelete.Width
    ''
    ''    intFirstBumpedColumn_Left = Integer.MaxValue ''Default value
    ''
    ''    ''5/2023 For Each each_RSCColumn As RSCFieldColumnV2 In mod_dict_RSCColumns.Values
    ''    For Each each_RSCColumn As RSCFieldColumnV2 In mod_dlist_RSCColumns ''5/2023 .Values
    ''        ''---For intColIndex As Integer = (1 + par_intColumnIndex) To (intNewLengthOfArray) '' (-1 + intNewLengthOfArray)
    ''        ''
    ''        ''If the column's Left edge is greater (bigger in X value) then 
    ''        ''   the column we are deleting....
    ''        ''   Then move the column to the left, in place of the deleted column. 
    ''        ''   ----4/15/2022
    ''        ''
    ''        If (each_RSCColumn Is Nothing) Then
    ''            ''
    ''            ''Don't process a Null reference. ---4/15/2022
    ''            ''
    ''        ElseIf (each_RSCColumn.Left > intColumnAboutToDelete_Left) Then
    ''
    ''            each_RSCColumn.Left -= (intWidthOfDeletedColumn + mc_ColumnMarginGap)
    ''
    ''            ''Added 4/1/2022 thomas downes
    ''            ''   Save the new location of the leftmost column.
    ''            ''   Whichever is furthest left, supplies the final value.
    ''            If (each_RSCColumn.Left < intFirstBumpedColumn_Left) Then
    ''                intFirstBumpedColumn_Left = each_RSCColumn.Left
    ''            End If
    ''
    ''        End If ''End of ""ElseIf (each_col.Left > intColumnAboutToDelete_Left) Then""
    ''
    ''    Next each_RSCColumn
    ''
    ''    ''
    ''    ''Step 7 of 7.  Remove the deleted column as a "Bump Column" for all the columns to the left.  
    ''    ''
    ''    Dim bIgnoreIndex0 As Boolean ''Added 4/14/2022 td 
    ''
    ''    For intColIndex As Integer = 0 To (-1 + par_intColumnIndex) ''To (-1 + intNewLength)
    ''        ''---For intColIndex As Integer = 0 To (-1 + par_intColumnIndex) 
    ''        ''
    ''        ''Add the column as a "Bump Column" for all the columns to the left. 
    ''        ''
    ''        ''#1 5/9/2023 bIgnoreIndex0 = (intColIndex = 0 And mod_dict_RSCColumns(intColIndex) Is Nothing)
    ''        bIgnoreIndex0 = (intColIndex = 0 And mod_dlist_RSCColumns(intColIndex) Is Nothing)
    ''        If bIgnoreIndex0 Then Continue For
    ''
    ''        ''#1 5/9/2023 mod_dict_RSCColumns(intColIndex).RemoveBumpColumn(par_columnAboutToDelete)
    ''        ''#2 5/9/2023 mod_dlist_RSCColumns(intColIndex).RemoveBumpColumn(par_columnAboutToDelete)
    ''
    ''    Next intColIndex
    ''
    ''    ''
    ''    ''Remove the column from the controls.
    ''    ''
    ''    ''4/26/2023 Me.Controls.Remove(columnAboutToDelete)
    ''    mod_controlSpread.Controls.Remove(par_columnAboutToDelete)
    ''
    ''    ''
    ''    ''Remove the column from the column-width cache 
    ''    ''
    ''    Dim delete_columnWidthAndData As ClassRSCColumnWidthAndData
    ''    delete_columnWidthAndData = par_columnAboutToDelete.ColumnWidthAndData
    ''    Me.ColumnDataCache.ListOfColumns.Remove(delete_columnWidthAndData)
    ''
    ''    ''
    ''    ''Check to see if RSCColumn1 is affected. 
    ''    ''
    ''    ''Not needed. 4/26/2023 If (RscFieldColumn1 Is columnAboutToDelete) Then
    ''    ''    RscFieldColumn1 = mod_dict_RSCColumns(0) ''Probably a null reference,
    ''    ''    '' as 0 is not being used!?  ----4/15/2022
    ''    ''    If (RscFieldColumn1 Is Nothing) Then
    ''    ''        RscFieldColumn1 = mod_dict_RSCColumns(1)
    ''    ''    End If ''End of ""If (RscFieldColumn1 Is Nothing) Then""
    ''    ''End If ''ENdof ""If (RscFieldColumn1 = columnAboutToDelete) Then""
    ''
    ''End Sub ''End of "Public Sub CompactColumnsAfterDeletion()"



End Class ''End of ""Partial Public Class RSCSpreadManagerCols""
