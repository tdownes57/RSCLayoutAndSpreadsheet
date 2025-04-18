﻿''
''Added 6/10/2023
''
Partial Public Class RSCFieldSpreadsheet
    ''
    ''Added 6/10/2023
    ''
    ''  Commented code....
    ''




    ''Public Function GetIndexOfColumn_NotInUse(par_column As RSCFieldColumnV2) As Integer
    ''    ''
    ''    ''Added 4/15/2022 td
    ''    ''
    ''    ''4/17/23  For intColIndex As Integer = 0 To (-1 + mod_array_RSCColumns.Length)
    ''    For intColIndex As Integer = 0 To (-1 + mod_dict_RSCColumns.Values.Count) ''4/17/23 mod_array_RSCColumns.Length)
    ''
    ''        If (mod_dict_RSCColumns(intColIndex) Is par_column) Then Return intColIndex
    ''
    ''    Next intColIndex
    ''
    ''    Return -1
    ''
    ''End Function ''end of Public Function GetIndexOfColumn(par_column As RSCFieldColumnV2) As Integer



    ''Public Sub ReviewForAbnormalLengthValues(Optional ByRef pboolOneOrMore As Boolean = False,
    ''                                         Optional ByVal pboolGiveMessageIfNeeded As Boolean = False)
    ''    ''
    ''    ''Added 4/26/2022 td
    ''    ''
    ''    Dim each_RSCColumn As RSCFieldColumnV2
    ''    Dim each_isAbnormal As Boolean
    ''
    ''    ''
    ''    '' Looping each column. ---4/10/2022 td
    ''    ''
    ''    ''4/17/2023 For Each each_RSCColumn In mod_array_RSCColumns
    ''    For Each each_RSCColumn In mod_dict_RSCColumns.Values
    ''
    ''        each_RSCColumn.ReviewForAbnormalLengthValues(each_isAbnormal)
    ''        pboolOneOrMore = (pboolOneOrMore Or each_isAbnormal)
    ''
    ''    Next each_RSCColumn
    ''
    ''    ''
    ''    ''Possibly give a message. 
    ''    ''
    ''    If (pboolOneOrMore And pboolGiveMessageIfNeeded) Then
    ''
    ''        ''Added 4/26/2022 td 
    ''        MessageBoxTD.Show_Statement("Please review cell values. One of more cells have unexpected values.")
    ''
    ''    End If ''End of "If (pboolOneOrMore And pboolGiveMessageIfNeeded) Then"
    ''
    ''
    ''End Sub ''End of ""Public Sub ReviewForAbnormalLengthValues()""


    ''Public Sub MoveTextCaret_IfNeeded(par_intNewRowIndex As Integer)
    ''    ''
    ''    ''Added 5/13/2022 thomas downes
    ''    ''
    ''    Const c_bMustHaveCaret As Boolean = False ''False, since when the user clicks on the 
    ''    ''  spreadsheet's row-header control, the Textbox in the RSCDataCell no longer
    ''    ''  pass "True" from the function Textbox.HasFocus(). ----5/13/2022
    ''
    ''    ''4/17/2023 For Each each_RSColumn As RSCFieldColumnV2 In mod_array_RSCColumns
    ''    For Each each_RSColumn As RSCFieldColumnV2 In mod_dict_RSCColumns.Values
    ''
    ''        If (each_RSColumn Is Nothing) Then Continue For
    ''
    ''        If (each_RSColumn.FocusRelated_ColumnHasCellFocus(c_bMustHaveCaret)) Then
    ''
    ''            each_RSColumn.MoveTextCaretToNewRow(par_intNewRowIndex)
    ''            Exit For ''Leave the "For Each" loop.
    ''
    ''        End If ''End of ""If (each_RSColumn.FocusRelated_ColumnHasCellFocus()) Then""
    ''
    ''    Next each_RSColumn
    ''
    ''End Sub ''End of ""Public Sub MoveTextCaret_IfNeeded()" 


    ''Public Sub SaveToRecipient_NotInUse(par_objRecipient As ciBadgeRecipients.ClassRecipient,
    ''                           par_iRowIndex As Integer,
    ''                           Optional ByRef pboolFailure As Boolean = False,
    ''                           Optional ByRef pintHowManyColumnsFailed As Integer = 0)
    ''    ''
    ''    ''Added 5/19/2022 
    ''    ''
    ''    Dim each_column As RSCFieldColumnV2
    ''    Dim each_failure As Boolean  ''Added 5/25/2022 
    ''
    ''    ''Track how many columns have failures. 
    ''    pintHowManyColumnsFailed = 0 ''Initialize.  5/245/2022 
    ''
    ''    For Each each_column In mod_dict_RSCColumns.Values ''4/17/2023 mod_array_RSCColumns
    ''
    ''        ''Added 5/20/2022 td
    ''        If (each_column Is Nothing) Then Continue For
    ''
    ''        With each_column
    ''            ''#1 5/25/2022 ''.SaveToRecipient(par_objRecipient, par_iRowIndex)
    ''            ''#2 5/25/2022 ''.SaveToRecipient(par_objRecipient, par_iRowIndex, pboolFailure)
    ''            each_failure = False ''Initialize. 5/25/2022
    ''            .SaveToRecipient(par_objRecipient, par_iRowIndex, each_failure)
    ''        End With
    ''
    ''        If (each_failure) Then pboolFailure = True
    ''        If (each_failure) Then pintHowManyColumnsFailed += 1
    ''
    ''    Next each_column
    ''
    ''End Sub ''End of ""Public Sub SaveToRecipient(...)""


    ''Public Function CountOfColumnsWithoutFields_NotInUse(Optional ByRef pref_intCountAllColumns As Integer = 0) As Integer
    ''    ''
    ''    '' Added 5/25/2022  
    ''    ''
    ''    Dim intCountColsAll As Integer = 0
    ''    Dim intCountColsWithout As Integer = 0
    ''    Dim eachRSCColumn As RSCFieldColumnV2
    ''
    ''    For Each eachRSCColumn In mod_dict_RSCColumns.Values ''4/17/2023  mod_array_RSCColumns
    ''        ''
    ''        ''Build the dictionaries. 
    ''        ''
    ''        If (eachRSCColumn Is Nothing) Then Continue For
    ''
    ''        intCountColsAll += 1
    ''
    ''        If (Not eachRSCColumn.HasField_Selected()) Then intCountColsWithout += 1
    ''
    ''    Next eachRSCColumn
    ''
    ''    pref_intCountAllColumns = intCountColsAll
    ''    Return intCountColsWithout
    ''
    ''End Function ''End of ""Public Function CountOfColumnsWithoutFields() As Integer""



    ''Public Function ReviewColumnDisplayForRelevantFields_1to1_NotInUse(pboolMessageUser As Boolean) As DialogResult
    ''    ''5/2022 ''Public Sub ReviewColumnDisplayForRelevantFields_1to1
    ''    ''
    ''    ''Added 4/26/2022 thomas 
    ''    ''
    ''    ''Populate both dictionaries. 
    ''    ''   1FC. Field-->Column. (EnumCIBFields-->RSCFieldColumn dictionary. 
    ''    ''   2CF. Column-->Field. (RSCFieldColumn-->EnumCIBFields) dictionary. 
    ''    ''
    ''    Dim dictionary1FC_FieldsToRSCColumn As New Dictionary(Of EnumCIBFields, RSCFieldColumnV2)
    ''    Dim dictionary2CF_ColumnToEnumField As New Dictionary(Of RSCFieldColumnV2, EnumCIBFields)
    ''    Dim eachRSCColumn As RSCFieldColumnV2
    ''    Dim objectStringBuilder1FC As New System.Text.StringBuilder(150)
    ''    Dim objectStringBuilder2CF As New System.Text.StringBuilder(150)
    ''    Dim objectStringBuilder1FC_Expanded As System.Text.StringBuilder
    ''    Dim dictionary1FC_Expanded As New Dictionary(Of EnumCIBFields, RSCFieldColumnV2)
    ''    Dim bUserWantsFieldsManager As Boolean = False ''Added 5/13/2022
    ''    Dim output_dialogResult As DialogResult ''Added 5/13/2022 
    ''
    ''    For Each eachRSCColumn In mod_dict_RSCColumns.Values
    ''        ''
    ''        ''Build the dictionaries. 
    ''        ''
    ''        If (eachRSCColumn Is Nothing) Then Continue For
    ''
    ''        eachRSCColumn.ReviewColumnDisplayForRelevantFields(dictionary1FC_FieldsToRSCColumn,
    ''            dictionary2CF_ColumnToEnumField,
    ''            objectStringBuilder1FC,
    ''            objectStringBuilder2CF)
    ''
    ''    Next eachRSCColumn
    ''
    ''    ''Refresh the module-level objects.
    ''    m_dictionary1FC_FieldsToRSCColumn = dictionary1FC_FieldsToRSCColumn
    ''    m_dictionary2CF_ColumnToEnumField = dictionary2CF_ColumnToEnumField
    ''
    ''    ''Message the user, if required by parameter. ---4/30 td
    ''    If (pboolMessageUser) Then
    ''        ''
    ''        ''   2CF. Column-->Field. (RSCFieldColumn-->EnumCIBFields) dictionary. 
    ''        ''
    ''        ''
    ''        ''5/13/2022 MessageBoxTD.Show_Statement("Here is the list of Columns & corresponding Fields:",
    ''        ''                  objectStringBuilder2CF.ToString())
    ''        output_dialogResult =
    ''        MessageBoxTD.Show_StatementLongform("Here is the list of Columns && corresponding Relevant Fields:",
    ''                                    objectStringBuilder2CF.ToString(),
    ''                                    1.7, 1.0, False)
    ''
    ''        ''
    ''        ''   1FC. Field-->Column. (EnumCIBFields-->RSCFieldColumn dictionary. 
    ''        ''
    ''        Const c_expandToShowAllRelevantFields As Boolean = True ''Added 4/30/2022 td
    ''        If (c_expandToShowAllRelevantFields) Then
    ''
    ''            ''Added 4/30/2022 td
    ''            objectStringBuilder1FC_Expanded = New System.Text.StringBuilder(200)
    ''            dictionary1FC_Expanded =
    ''               ExpandDictionary1FC(dictionary1FC_FieldsToRSCColumn, objectStringBuilder1FC_Expanded)
    ''            ''MessageBoxTD.Show_Statement("Here is the list of Relevant Fields & corresponding columns.",
    ''            ''    objectStringBuilder1FC_Expanded.ToString())
    ''            Const c_showFieldsButton As Boolean = True ''Added 5/13/2022
    ''            Dim bUserPressedButton As Boolean = False ''Added 5/13/2022
    ''
    ''            If (c_showFieldsButton) Then
    ''                ''Added 5/13/2022
    ''                output_dialogResult =
    ''                MessageBoxTD.Show_SpecialButton("Here is the list of Relevant Fields && corresponding columns:",
    ''                                        objectStringBuilder1FC_Expanded.ToString(),
    ''                                        1.7, 2.0, "Manage Relevant Fields", bUserPressedButton)
    ''                bUserWantsFieldsManager = bUserPressedButton
    ''
    ''            Else
    ''                ''Added 5/13/2022
    ''                output_dialogResult =
    ''                MessageBoxTD.Show_StatementLongform("Here is the list of Fields && corresponding columns:",
    ''                                        objectStringBuilder1FC_Expanded.ToString(),
    ''                                        1.7, 2.0)
    ''            End If ''End of ""If (c_showFieldsButton) Then.... Else..."
    ''
    ''        Else
    ''            ''Added 4/30/2022
    ''            ''MessageBoxTD.Show_Statement("Here is the list of Fields & corresponding columns.",
    ''            ''                        objectStringBuilder1FC.ToString())
    ''            output_dialogResult =
    ''            MessageBoxTD.Show_StatementLongform("Here is the list of Fields & corresponding columns:",
    ''                                    objectStringBuilder1FC.ToString(),
    ''                                    1.0, 2.0)
    ''
    ''        End If ''End of "If (c_expandToShowAllRelevantFields) Then... Else..."
    ''
    ''    End If ''End of ""If (pboolMessageUser) Then""
    ''
    ''    ''
    ''    ''Show Fields Manager, if appopriate.  ---5/13/2022 td
    ''    ''
    ''    If (bUserWantsFieldsManager) Then ShowFieldsManagement()
    ''
    ''    ''Added 5/13/2022 td
    ''    Return output_dialogResult
    ''
    ''End Function ''End of ""Public Sub ReviewColumnDisplayForRelevantFields()""




    ''Public Sub Load_EmptyRowsToAllNewColumns_NotInUse()
    ''    ''
    ''    ''Added 4/15/2022 td
    ''    ''
    ''    Dim intEachRowCount As Integer = 1
    ''    Dim intMaxRowCount As Integer = 1
    ''    Dim list_columns As List(Of RSCFieldColumnV2)
    ''    Dim boolMissingRows As Boolean
    ''
    ''    list_columns = ListOfColumns()
    ''
    ''    For Each each_column As RSCFieldColumnV2 In list_columns ''March30 2022 td''Me.ListOfColumns()
    ''        intEachRowCount = each_column.CountOfRows()
    ''        If (intEachRowCount > intMaxRowCount) Then intMaxRowCount = intEachRowCount
    ''    Next each_column
    ''
    ''    For Each each_column As RSCFieldColumnV2 In list_columns ''March30 2022 td''Me.ListOfColumns()
    ''        boolMissingRows = (each_column.CountOfRows() < intMaxRowCount)
    ''        If (boolMissingRows) Then
    ''            each_column.Load_EmptyRows(intMaxRowCount)
    ''        End If ''End of ""If (boolMissingRows) Then""
    ''    Next each_column
    ''
    ''End Sub ''End of ""Public Sub Load_EmptyRowsToAllNewColumns()""



    ''Private Function ExpandDictionary1FC_NotInUse(par_dictionary1FC_FieldsToColumn As Dictionary(Of EnumCIBFields, RSCFieldColumnV2),
    ''                                par_stringbuilder As System.Text.StringBuilder) _
    ''                            As Dictionary(Of EnumCIBFields, RSCFieldColumnV2)
    ''    ''
    ''    ''Added 4/30/2022 thomas d.
    ''    ''
    ''    Dim output_dictionary As Dictionary(Of EnumCIBFields, RSCFieldColumnV2)
    ''    ''--Dim list_enumFieldsRelevant As List(Of EnumCIBFields)
    ''    Dim list_fieldsRelevant As List(Of ClassFieldAny)
    ''    ''---list_enumFieldsRelevant = ModEnumsAndStructs.GetListOfAllFieldEnums_Relevant()
    ''    Dim each_fieldRelevant As ClassFieldAny
    ''    Dim each_enumRelevant As EnumCIBFields
    ''    Dim each_RSCColumn As RSCFieldColumnV2
    ''    Dim boolFoundColumn As Boolean
    ''
    ''    par_stringbuilder.AppendLine()
    ''
    ''    list_fieldsRelevant = Me.ElementsCache_Deprecated.ListOfFields_AnyRelevent()
    ''    output_dictionary = New Dictionary(Of EnumCIBFields, RSCFieldColumnV2)()
    ''
    ''    For Each each_fieldRelevant In list_fieldsRelevant
    ''
    ''        each_RSCColumn = Nothing ''Reinitialize. 
    ''        each_enumRelevant = each_fieldRelevant.FieldEnumValue
    ''        boolFoundColumn = par_dictionary1FC_FieldsToColumn.ContainsKey(each_enumRelevant)
    ''
    ''        ''Will this return a Null value?
    ''        If (boolFoundColumn) Then
    ''            each_RSCColumn = par_dictionary1FC_FieldsToColumn.Item(each_enumRelevant)
    ''            output_dictionary.Add(each_enumRelevant, each_RSCColumn)
    ''            ''Added 5/13/2022
    ''            par_stringbuilder.AppendLine("Field """ + each_fieldRelevant.FieldLabelCaption + """" +
    ''                                         " is assigned to Column # " +
    ''                                         each_RSCColumn.GetIndexOfColumn().ToString())
    ''
    ''        Else
    ''            ''Enter a null value.  
    ''            output_dictionary.Add(each_enumRelevant, Nothing)
    ''            ''Added 5/13/2022
    ''            par_stringbuilder.AppendLine("Field """ + each_fieldRelevant.FieldLabelCaption + """" +
    ''                                         " is not assigned to any column.")
    ''
    ''        End If ''end of ""If (boolFoundColumn) Then ... Else ""
    ''
    ''    Next each_fieldRelevant
    ''
    ''    ''
    ''    ''Exit Handler
    ''    ''
    ''    Return output_dictionary
    ''
    ''End Function ''End of ""Private Sub ExpandDictionary1FC""



    ''Public Sub LoadRuntimeColumns_AfterClearingDesign_NotInUse(par_designer As ClassDesigner)
    ''    ''
    ''    ''Added 3/8/2022 thomas downes 
    ''    ''
    ''    Dim intSavePropertyTop_RSCColumnCtl As Integer
    ''    Dim intSavePropertyTop_FirstRow As Integer ''Added 3/24/2022 td
    ''
    ''    intSavePropertyTop_RSCColumnCtl = RscFieldColumn1.Top
    ''    ''4/9/2022 td''intSavePropertyTop_FirstRow = RscFieldColumn1.GetFirstTextboxPropertyTop()
    ''    intSavePropertyTop_FirstRow = RscFieldColumn1.GetFirstRSCDataCellPropertyTop()
    ''
    ''    ''Step 1a of 5.     Remove design-time columns..... Clearing (removing) design-time columns (which are placed
    ''    ''   to give a visual preview of how the run-time columns will look). 
    ''    ''
    ''    Const c_boolRemoveDesignColumns_Step1a As Boolean = True ''4/10 False ''True ''Added 4/4/2023 td
    ''    If (c_boolRemoveDesignColumns_Step1a) Then
    ''        ''Remove design-time RSC Columns.  
    ''        RemoveRSCColumnsFromDesignTime()
    ''    End If ''End of ""If (c_boolRemoveDesignColumns_Step1a) Then""
    ''
    ''    ''Added 3/15/2022 td
    ''    If (Me.ElementsCache_Deprecated Is Nothing) Then
    ''        ''Throw New Exception("Cache is missing")
    ''        MessageBoxTD.Show_Statement("Cache is missing")
    ''    End If ''end of ""If (Me.ElementsCache_Deprecated Is Nothing) Then"'
    ''
    ''    ''Added 3/15/2022 td
    ''    If (Me.ColumnDataCache Is Nothing) Then
    ''        ''Throw New Exception("Cache is missing")
    ''        MessageBoxTD.Show_Statement("Cache is missing")
    ''    End If ''end of ""If (Me.ElementsCache_Deprecated Is Nothing) Then"'
    ''
    ''    ''
    ''    ''Step 1b of 5.  Load run-time row-header control (RSCRowHeaders1). ----3/24/2022 
    ''    ''
    ''    ''   Step 1b(1):  Remove design-time control
    ''    ''   Step 1b(2):  Load run-time control
    ''    ''
    ''    ''Step 1b(1):  Remove design-time control
    ''    RscRowHeaders1.Visible = False ''Hardly matters, but go ahead. 
    ''    Me.Controls.Remove(RscRowHeaders1)
    ''
    ''    ''Step 1b(2):  Load run-time control
    ''    Dim intCurrentPropertyLeft As Integer = 0
    ''    Dim intNextPropertyLeft As Integer = 0
    ''    RscRowHeaders1 = RSCRowHeaders.GetRSCRowHeaders(Me.Designer, Me.ParentForm,
    ''         "RscRowHeaders1", Me)
    ''    Me.Controls.Add(RscRowHeaders1)
    ''    RscRowHeaders1.Visible = True
    ''    RscRowHeaders1.Top = (intSavePropertyTop_RSCColumnCtl + intSavePropertyTop_FirstRow - 2)
    ''    RscRowHeaders1.Left = (intCurrentPropertyLeft)
    ''    ''---RscRowHeaders1.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right), AnchorStyles)
    ''    intNextPropertyLeft += (RscRowHeaders1.Width + mc_ColumnMarginGap)
    ''    ''Assigned within the loop below.--3/24/2022 td''intCurrentPropertyLeft = intNextPropertyLeft
    ''    RscRowHeaders1.PixelsFromRowToRow = mc_intPixelsFromRowToRow ''Added 4/5/2022
    ''    RscRowHeaders1.ParentRSCSpreadsheet = Me ''Added 4/29/2022 thomas  
    ''
    ''    ''
    ''    ''Step 2 of 5.  Load run- time columns. 
    ''    ''
    ''    ''Step 2a of 5.  Create a local array for storing indexed columns. 
    ''    ''
    ''    ''Added a Number N of Required Columns. 
    ''    ''
    ''    Dim intNeededIndex As Integer = 1
    ''    Dim each_Column As RSCFieldColumnV2
    ''    Dim priorColumn As RSCFieldColumnV2 = Nothing
    ''    Dim intNeededMax As Integer = 4
    ''
    ''    ''Added 3/16/2022 td
    ''    If (0 = Me.ColumnDataCache.ListOfColumns.Count) Then
    ''        ''Added 3/16/2022 td
    ''        Me.ColumnDataCache.AddColumns(intNeededMax)
    ''    Else
    ''        intNeededMax = Me.ColumnDataCache.ListOfColumns.Count
    ''    End If ''End of "If (0 = Me.ColumnDataCache.ListOfColumns.Count) Then ... Else ..."
    ''
    ''    ''---Dim mod_array_RSCColumns As RSCFieldColumn()
    ''    If (intNeededMax > 1) Then ''Added 5/30/2022
    ''        ''added 5/30/2022 & 5/13/2022
    ''        If mc_boolKeepUILookingClean Then
    ''            ''Hide the buttons which formerly occupied the blank area
    ''            '' of the spreadsheet. ---5/13/2022 
    ''            ButtonAddColumns2.Visible = False
    ''            ButtonPasteData2.Visible = False
    ''        End If ''End of ""If c_boolKeepUILookingClean Then""
    ''    End If ''End of ""If (intNeededMax > 1) Then""
    ''
    ''
    ''    ''The number passed to ReDim Preserve is the upper bound of the array, 
    ''    ''  not the length. ---4/15/2022
    ''    ''
    ''    ReDim mod_dict_RSCColumns(intNeededMax)
    ''    Dim each_field As ciBadgeFields.ClassFieldAny
    ''
    ''    ''
    ''    ''Step 2b of 5.  Generate columns (type: RSCFieldColumn).
    ''    ''
    ''    Const c_bUseEncapsulation As Boolean = True ''4/7 False ''3/31/2023 True ''Added 3/20/2022 td
    ''
    ''    For intNeededIndex = 1 To intNeededMax
    ''
    ''        If (c_bUseEncapsulation) Then
    ''            ''
    ''            ''Encapsulated 3/20/2022 td
    ''            ''
    ''            intCurrentPropertyLeft = intNextPropertyLeft ''Check prior iteration.
    ''            ''
    ''            ''Major call!!
    ''            ''
    ''            each_Column = GenerateRSCFieldColumn_General(intNeededIndex,
    ''                                                        intCurrentPropertyLeft,
    ''                                                        intNextPropertyLeft,
    ''                                                        priorColumn)
    ''
    ''            ''Added 3/25/2022 td 
    ''            If (intNeededIndex = 1) Then RscFieldColumn1 = each_Column
    ''
    ''            ''Added 4/11/2023 thomas downes
    ''            each_Column.RemoveMoveability()
    ''
    ''            ''Prepare for next iteration.
    ''            priorColumn = each_Column
    ''
    ''        Else
    ''            ''
    ''            ''Original unencapsulated code. 
    ''            ''
    ''            each_field = New ciBadgeFields.ClassFieldAny()
    ''            ''each_field.FieldEnumValue = ciBadgeInterfaces.EnumCIBFields.Undetermined
    ''            each_field.FieldEnumValue = Me.ColumnDataCache.ListOfColumns(-1 + intNeededMax).CIBField
    ''
    ''            ''3/20/2022 td''eachColumn = GenerateRSCFieldColumn(each_field, intNeededIndex)
    ''            each_Column = GenerateRSCFieldColumn_Special(each_field, intNeededIndex)
    ''            intCurrentPropertyLeft = intNextPropertyLeft ''Check prior iteration.
    ''            each_Column.Left = intCurrentPropertyLeft
    ''            each_Column.Visible = True
    ''            ''Prepare for next iteration. 
    ''            ''----intNextPropertyLeft = (eachColumn.Left + eachColumn.Width + 3)
    ''            intNextPropertyLeft = (each_Column.Left + each_Column.Width + mc_ColumnMarginGap)
    ''            Me.Controls.Add(each_Column)
    ''            ''Added 3/12/2022 thomas downes 
    ''            mod_dict_RSCColumns(intNeededIndex) = each_Column
    ''
    ''            ''Added 3/16/2022 td
    ''            ''  Redundant, assigned in Step 4 below.
    ''            ''Oops....3/18/2022 ''eachColumn.ColumnWidthAndData = Me.ColumnDataCache.ListOfColumns(-1 + intNeededMax)
    ''            each_Column.ElementsCache_Deprecated = Me.ElementsCache_Deprecated
    ''            each_Column.ColumnWidthAndData = Me.ColumnDataCache.ListOfColumns(-1 + intNeededIndex)
    ''            ''Added 4/11/2022 thomas d.
    ''            each_Column.ParentSpreadsheet = Me
    ''
    ''            ''Test for uniqueness. 
    ''            Dim bUnexpectedMatch As Boolean
    ''            If (priorColumn IsNot Nothing) Then
    ''                bUnexpectedMatch = (each_Column.ColumnWidthAndData Is
    ''                    priorColumn.ColumnWidthAndData)
    ''                If (bUnexpectedMatch) Then Throw New Exception
    ''            End If ''ENd of "If (priorColumn IsNot Nothing) Then"
    ''
    ''        End If ''End of "I
    ''        ''
    ''        ''f (c_bUseEncapsulation) Then .... Else ...."
    ''
    ''        ''
    ''        ''Prepare for next iteration. 
    ''        ''
    ''        priorColumn = each_Column
    ''
    ''    Next intNeededIndex
    ''
    ''    ''
    ''    ''Step 3 of 5.  Link the columns together.  
    ''    ''
    ''    Dim listColumnsRight = New List(Of RSCFieldColumnV2)
    ''    Dim each_list As List(Of RSCFieldColumnV2)
    ''    Dim prior_list As List(Of RSCFieldColumnV2)
    ''    Dim bNotTheRightmostColumn As Boolean
    ''
    ''    For intNeededIndex = intNeededMax To 1 Step -1 ''Going backward, i.e. decrementing the index,
    ''        '' i.e. going from right to left (vs. the standard of going left to right).  
    ''        ''     ---3/12/20022 td
    ''
    ''        each_Column = mod_dict_RSCColumns(intNeededIndex)
    ''        ''Moved below. 3/13/2022 td''listColumnsRight.Add(eachColumn)
    ''
    ''        ''Let's initialize the list "each_list" with the list "listColumnsRight"
    ''        ''   because  we want "each_list" to be a partial listing of the columns.
    ''        ''   By "a partial listing", I mean only those columns which are on the //right-hand//
    ''        ''   side of column #intNeededIndex.      ---3/12/20022 td
    ''        ''   
    ''        each_list = New List(Of RSCFieldColumnV2)(listColumnsRight) ''Basically, a copy of listColumnsRight.
    ''
    ''        ''Added 3/12/2022 thomas d. 
    ''        bNotTheRightmostColumn = (intNeededIndex < intNeededMax)
    ''        If (bNotTheRightmostColumn) Then
    ''
    ''            If (each_list.Contains(each_Column)) Then Throw New Exception("self-referential")
    ''            each_Column.ListOfColumnsToBumpRight = each_list
    ''
    ''        End If ''End of "If (bNotTheRightmostColumn) Then"
    ''
    ''        ''Prepare for next iteration.
    ''        prior_list = each_list
    ''        listColumnsRight.Add(each_Column)
    ''
    ''    Next intNeededIndex
    ''
    ''    ''
    ''    ''Step 4 of 5.  Load the list of editable fields.  
    ''    ''
    ''    ''4/13/2022 td ''Dim each_columnWidthEtc As ciBadgeDesigner.ClassColumnWidthAndData
    ''    Dim each_columnWidthEtc As ciBadgeCachePersonality.ClassRSCColumnWidthAndData
    ''    For intNeededIndex = 1 To intNeededMax
    ''
    ''        each_Column = mod_dict_RSCColumns(intNeededIndex)
    ''        ''Moved below. 3/16/2022 td''eachColumn.Load_FieldsFromCache(Me.ElementsCache_Deprecated)
    ''        ''Added 3/15/2022 td
    ''        ''  This may not be needed.  See eachColumn.ColumnWidthAndData.
    ''        each_Column.ColumnDataCache = Me.ColumnDataCache ''Added 3/15/2022 td
    ''        ''Added 3/15/2022 td
    ''        ''  Tell the column what width, field & field values to display.
    ''        each_columnWidthEtc = Me.ColumnDataCache.ListOfColumns(intNeededIndex - 1)
    ''        each_Column.ColumnWidthAndData = each_columnWidthEtc
    ''        each_Column.Top = intSavePropertyTop_RSCColumnCtl ''Added 3/21/2022
    ''        each_Column.BackColor = RscRowHeaders1.BackColor ''Added 4/11/2022 td
    ''
    ''        ''
    ''        ''Ensure the needed # of RSCDataCells are present.----4/15/2022
    ''        ''
    ''        ''Dim intRowCount As Integer = mod_array_RSCColumns(0)
    ''        each_Column.Load_EmptyRows(RscFieldColumn1.CountOfRows())
    ''        Dim intRowCount As Integer = NumberOfRowsNeededToStart
    ''        If (intRowCount = 0) Then intRowCount = Me.DefaultBlankRowCount
    ''        each_Column.Load_EmptyRows(intRowCount)
    ''
    ''        ''
    ''        ''Major call!
    ''        ''
    ''        each_Column.ParentSpreadsheet = Me ''Added 4/11/2022 thomas d. 
    ''        each_Column.Load_FieldsFromCache(Me.ElementsCache_Deprecated)
    ''
    ''        ''
    ''        ''Load the data which is saved in the Column-Widths-and-Data cache.  
    ''        ''    -----4/15/2022 td
    ''        ''
    ''        each_Column.Load_ColumnListDataToColumnEtc()
    ''
    ''
    ''    Next intNeededIndex
    ''
    ''    ''
    ''    ''Step 5 of 5.  Adjust the .Left property of the columns, to accomodate
    ''    ''   the width of the columns determined by the user's resizing behavior
    ''    ''   in the prior session.  
    ''    ''
    ''    For intNeededIndex = 2 To intNeededMax
    ''
    ''        priorColumn = mod_dict_RSCColumns(intNeededIndex - 1)
    ''        each_Column = mod_dict_RSCColumns(intNeededIndex)
    ''
    ''        each_Column.Left = (priorColumn.Left + priorColumn.Width + 4)
    ''
    ''    Next intNeededIndex
    ''
    ''    ''
    ''    ''Step 6 of 6.  Resize the form itself. 
    ''    ''
    ''    If (Me.ColumnDataCache.FormSize.Width > mc_ColumnWidthDefault) Then
    ''        ''
    ''        ''Resize the form based on the save form size.
    ''        ''
    ''        Me.ParentForm_DesignerDialog.Size = Me.ColumnDataCache.FormSize
    ''
    ''    End If ''end of ""If Me.ColumnDataCache.FormSize.Width > 100 Then""
    ''
    ''    ''
    ''    ''Step 7 of 7.  Align the row headers.
    ''    ''
    ''    ''Might be causing call-stack problems.''RscRowHeaders1.RSCSpreadsheet = Me
    ''    ''Moved to calling function. 3/25/2022 td''RscRowHeaders1.AlignControlsWithSpreadsheet()
    ''
    ''    ''
    ''    ''Step 8 of 8.  Make sure that the Row Headers match the longest column of data
    ''    ''       inside the cache collection Me.ColumnDataCache. 
    ''    ''       ----6/22/2022 thomas d. 
    ''    ''
    ''    With Me.ColumnDataCache
    ''        RscRowHeaders1.ColumnDataCache = Me.ColumnDataCache
    ''        RscRowHeaders1.Load_ColumnListDataToColumnEtc()
    ''    End With
    ''
    ''End Sub ''End of Public Sub LoadRuntimeColumns_AfterClearingDesign



    ''Public Sub AddToEdgeOfSpreadsheet_Row_NotInUse()
    ''    ''4/2022 Public Sub AddRowToBottomOfSpreadsheet() 
    ''
    ''    ''Added 4/30/2022 thomas downes
    ''    ''Me.ParentSpreadsheet.AddRowToBottomOfSpreadsheet()
    ''    Dim intRowCount As Integer
    ''    Dim intRowCount_PlusOne As Integer
    ''    intRowCount = RscRowHeaders1.CountOfRows()
    ''    intRowCount_PlusOne = (intRowCount + 1)
    ''    RscRowHeaders1.Load_OneEmptyRow_IfNeeded(intRowCount_PlusOne) ''(1 + intRowCount)
    ''
    ''    ''Add a new textbox to each column. 
    ''    For Each each_RSCCol As RSCFieldColumnV2 In mod_dict_RSCColumns.Values
    ''        If (each_RSCCol Is Nothing) Then Continue For
    ''        each_RSCCol.Load_EmptyRows(intRowCount_PlusOne)
    ''    Next each_RSCCol
    ''
    ''End Sub ''End of ""Public Sub AddToEdgeOfSpreadsheet_Row()""


    ''Public Sub AddToEdgeOfSpreadsheet_Column_NotInUse()
    ''
    ''    ''Added 4/30/2022 thomas downes
    ''    Dim intColumnCount As Integer
    ''    Dim intColumnCount_PlusOne As Integer
    ''
    ''    If (mod_dict_RSCColumns Is Nothing) Then ''Added 4/17/2023 td
    ''        ''4/2023 mod_dict_RSCColumns = {} ''Added 4/17/2023 td
    ''        mod_dict_RSCColumns = New Dictionary(Of Integer, RSCFieldColumnV2) ''Added 4/17/2023 td
    ''        intColumnCount = 0 ''Added 4/17/2022 td
    ''    Else
    ''        ''4/2023 intColumnCount = mod_array_RSCColumns.Length
    ''        intColumnCount = mod_dict_RSCColumns.Values.Count ''.Length
    ''        If (mod_dict_RSCColumns(0) Is Nothing) Then intColumnCount -= 1
    ''    End If ''End of ""If (mod_array_RSCColumns Is Nothing) Then ... Else ..."  
    ''
    ''    intColumnCount_PlusOne = (1 + intColumnCount)
    ''    InsertNewColumnByIndex(intColumnCount_PlusOne)
    ''
    ''End Sub ''End of ""Public Sub AddToEdgeOfSpreadsheet_Column()""



    ''Private Function GenerateRSCFieldColumn_General_NotInUse(p_intIndexCurrent As Integer,
    ''                                                p_intCurrentPropertyLeft As Integer,
    ''                                                ByRef pref_intNextPropertyLeft As Integer,
    ''                                                p_priorColumn As RSCFieldColumnV2) As RSCFieldColumnV2
    ''    ''
    ''    '' Added 3/20/2022 td
    ''    ''
    ''    Dim newRSCColumn_output As RSCFieldColumnV2
    ''    Dim dataOfColumn As ClassRSCColumnWidthAndData ''Added 4/14/2022
    ''    Dim fieldForNewColumn As ciBadgeFields.ClassFieldAny
    ''
    ''    fieldForNewColumn = New ciBadgeFields.ClassFieldAny()
    ''    ''each_field.FieldEnumValue = ciBadgeInterfaces.EnumCIBFields.Undetermined
    ''
    ''    dataOfColumn = Me.ColumnDataCache.ListOfColumns(-1 + p_intIndexCurrent)
    ''    If (dataOfColumn IsNot Nothing) Then
    ''        fieldForNewColumn.FieldEnumValue = dataOfColumn.CIBField
    ''    End If ''End of ""If (dataOfColumn IsNot Nothing) Then""
    ''
    ''    ''
    ''    ''Major call, call the other, "..._Special" version of this column-generating function (suffixed "..._General"). 
    ''    ''
    ''    newRSCColumn_output = GenerateRSCFieldColumn_Special(fieldForNewColumn, p_intIndexCurrent)
    ''    ''----intCurrentPropertyLeft = intNextPropertyLeft ''Check prior iteration.
    ''
    ''    ''
    ''    ''Add additional properties. 
    ''    ''
    ''    With newRSCColumn_output
    ''        ''
    ''        ''Set the properties of the newly-generated column. 
    ''        ''
    ''        newRSCColumn_output.Left = p_intCurrentPropertyLeft
    ''        newRSCColumn_output.Width = mc_ColumnWidthDefault ''Added 3/20/2022 td
    ''        newRSCColumn_output.Visible = True
    ''
    ''        ''Added 3/30/2022 td
    ''        ''4/4/2022 td ''newRSCColumn_output.Height = (Me.Height - mod_intRscFieldColumn1_Top - mc_ColumnMarginGap)
    ''        .Height = newRSCColumn_output.GetRSCDataCellAtBottom_Bottom() + mc_ColumnMarginGap
    ''        ''4/4/2022 td ''newRSCColumn_output.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Bottom), AnchorStyles)
    ''        ''4/6/2022 td ''newRSCColumn_output.Anchor = CType((AnchorStyles.Top Or AnchorStyles.None), AnchorStyles)
    ''        .Anchor = CType((AnchorStyles.Top Or AnchorStyles.Left), AnchorStyles)
    ''
    ''        ''Prepare for next iteration. 
    ''        pref_intNextPropertyLeft = (.Left + .Width + 3)
    ''        Me.Controls.Add(newRSCColumn_output)
    ''
    ''        ''Added 3/12/2022 thomas downes 
    ''        mod_dict_RSCColumns(p_intIndexCurrent) = newRSCColumn_output
    ''        ''Added 3/16/2022 td
    ''        ''  Redundant, assigned in Step 4 below.
    ''        ''Oops....3/18/2022 ''eachColumn.ColumnWidthAndData = Me.ColumnDataCache.ListOfColumns(-1 + intNeededMax)
    ''
    ''        .ElementsCache_Deprecated = Me.ElementsCache_Deprecated
    ''        .ColumnWidthAndData = Me.ColumnDataCache.ListOfColumns(-1 + p_intIndexCurrent)
    ''
    ''        ''Added 4/14/2022 td
    ''        If (.ColumnWidthAndData Is Nothing) Then
    ''            ''Added 4/14/2022 td
    ''            .ColumnWidthAndData = New ClassRSCColumnWidthAndData()
    ''            .ColumnWidthAndData.CIBField = EnumCIBFields.Undetermined
    ''            .ColumnWidthAndData.Width = mc_ColumnWidthDefault
    ''            .ColumnWidthAndData.ColumnData = New List(Of String)
    ''            Me.ColumnDataCache.ListOfColumns.Add(.ColumnWidthAndData)
    ''        End If ''End of ""If (.ColumnWidthAndData Is Nothing) Then""
    ''
    ''        ''Added 4/5/2022
    ''        .PixelsFromRowToRow = mc_intPixelsFromRowToRow ''Added 4/5/2022
    ''
    ''    End With ''END OF "With newRSCColumn_output"
    ''
    ''    ''Test for uniqueness. 
    ''    Dim bUnexpectedPriorPropertyMatch As Boolean
    ''
    ''    If (p_priorColumn IsNot Nothing) Then
    ''        ''
    ''        ''Check that the prior output's property-object differs from the current property-object. 
    ''        ''
    ''        bUnexpectedPriorPropertyMatch = (newRSCColumn_output.ColumnWidthAndData Is
    ''                                         p_priorColumn.ColumnWidthAndData)
    ''        If (bUnexpectedPriorPropertyMatch) Then Throw New Exception
    ''
    ''    End If ''ENd of "If (p_priorColumn IsNot Nothing) Then"
    ''
    ''    ''
    ''    ''Added 4/14/2022 td
    ''    ''
    ''    Dim intRowsNeeded As Integer
    ''    intRowsNeeded = Me.GetFirstColumn().CountOfRows()
    ''    newRSCColumn_output.Load_EmptyRows(intRowsNeeded)
    ''
    ''    ''Exit Handler.....
    ''    Return newRSCColumn_output
    ''
    ''End Function ''End of "Private Function GenerateRSCFieldColumn_General"


    ''Private Function GenerateRSCFieldColumn_Special_NotInUse(par_objField As ClassFieldAny, par_intFieldIndex As Integer) As RSCFieldColumnV2
    ''    ''
    ''    ''Added 3/8/2022 td
    ''    ''
    ''    Dim objNewColumn As RSCFieldColumnV2 ''Added 3/8/2022 td
    ''
    ''    ''March9 2022 ''objNewColumn = RSCFieldColumn.GetFieldColumn()
    ''    ''Added 1/17/2022 td
    ''    Dim objGetParametersForGetControl As ciBadgeDesigner.ClassGetElementControlParams
    ''    objGetParametersForGetControl = Me.Designer.GetParametersToGetElementControl()
    ''    objGetParametersForGetControl.ElementObject = New ciBadgeElements.ClassElementBase()
    ''
    ''    Const c_boolProportional As Boolean = False ''Added 3/11/2022 td 
    ''
    ''    objNewColumn = RSCFieldColumnV2.GetRSCFieldColumn(objGetParametersForGetControl,
    ''                                                     par_objField, Me.ParentForm,
    ''                                                     "RSCFieldColumn" & CStr(par_intFieldIndex),
    ''                                                      Me.Designer, c_boolProportional,
    ''                                                      mod_ctlLasttouched, Me.Designer,
    ''                                                      mod_eventsSingleton,
    ''                                                      Me, par_intFieldIndex)
    ''
    ''    ''Added 3/13/2022 thomas downes
    ''    objNewColumn.BackColor = mod_colorOfColumnsBackColor
    ''
    ''    Return objNewColumn
    ''
    ''End Function ''End of "Private Function GenerateRSCFieldColumn_Special() As RSCFieldColumn"



    ''Private Sub RemoveRSCColumnsFromDesignTime_NotInUse()
    ''    ''
    ''    ''Added 3/8/2022 thomas d
    ''    ''
    ''    Dim listRSCColumns As New List(Of RSCFieldColumnV2)
    ''
    ''    For Each each_control As Control In Me.Controls
    ''        If (TypeOf each_control Is RSCFieldColumnV2) Then
    ''
    ''            each_control.Dispose()
    ''            each_control.Visible = False
    ''            listRSCColumns.Add(CType(each_control, RSCFieldColumnV2))
    ''
    ''        End If
    ''    Next each_control
    ''
    ''    For Each each_control As RSCFieldColumnV2 In listRSCColumns
    ''
    ''        Me.Controls.Remove(each_control)
    ''
    ''    Next each_control
    ''
    ''    ''Added 3/25/2022 td
    ''    RscFieldColumn1 = Nothing ''Added 3/25/2022 td 
    ''
    ''End Sub ''end of "Private Sub RemoveRSCColumnsFromDesignTime()"



    ''Public Sub AddColumnsToRighthandSide_NotInUse(par_intNumber As Integer)
    ''    ''
    ''    ''Added 3/16/2022 Thomas Downes 
    ''    ''
    ''    ''Not needed.''Dim objLastColumnGoingRight As RSCFieldColumnV2
    ''    ''Not needed.''objLastColumnGoingRight = GetLastColumn()
    ''    For intIndex As Integer = 1 To par_intNumber
    ''        ''Not needed.''objLastColumnGoingRight.AddToEdgeOfSpreadsheet_Column()
    ''        AddToEdgeOfSpreadsheet_Column()
    ''    Next intIndex
    ''
    ''    ''Dim each_columnData As ClassRSCColumnWidthAndData ''4/13/2022 As ClassColumnWidthAndData
    ''    ''
    ''    ''For intIndex = 1 To par_intNumber
    ''    ''
    ''    ''    each_columnData = New ClassRSCColumnWidthAndData ''4/13/2022 ClassColumnWidthAndData
    ''    ''    each_columnData.CIBField = EnumCIBFields.Undetermined
    ''    ''    each_columnData.Width = -1
    ''    ''    each_columnData.Rows = -1
    ''    ''    each_columnData.ColumnData = New List(Of String)()
    ''    ''
    ''    ''    Me.ColumnDataCache.ListOfColumns.Add(each_columnData)
    ''    ''
    ''    ''Next intIndex
    ''
    ''End Sub ''End of "Public Sub AddColumnsToRighthandSide()"






















    ''Private Sub Timer1_Tick(sender As Object, e As EventArgs)
    ''
    ''    ''Added 3/25/2022 thomas downes 
    ''    ''Timer1.Enabled = False ''Make this one-time only. 
    ''    ''RscRowHeaders1.RSCSpreadsheet = Me
    ''    ''AlignRowHeadersWithSpreadsheet()
    ''
    ''End Sub


    ''4/30/2023 Private Sub RscFieldColumn1_Load(sender As Object, e As EventArgs) Handles RscFieldColumn1.Load
    ''
    ''End Sub


    ''Public Sub SaveDataColumnByColumnXML_NotInUse(Optional pboolOpenXML As Boolean = False)
    ''---June29 2022---Public Sub SaveDataColumnByColumn
    ''
    ''Added 3/17/2022 thomas downes
    ''
    ''STEP 1 of 5 
    ''
    '' Save the column data to the ColumnDataCache. 
    ''
    ''4/26/2023 For intIndex As Integer = 1 To Me.ColumnDataCache.ListOfColumns.Count
    ''    Dim eachColumn As RSCFieldColumnV2 ''Added 3/18/2022 thomas downes
    ''    eachColumn = mod_dict_RSCColumns(intIndex)
    ''    ''4/12/2022 td''eachColumn.SaveDataToColumn()
    ''    eachColumn.SaveDataTo_ColumnCache()
    ''Next intIndex
    ''
    ''Encapsulated 4/26/2023 td
    ''mod_manager.Cols.SaveDataColumnByColumnXML(pboolOpenXML)
    ''
    ''
    ''Resize the form based on the save form size.---3/20/2022
    ''
    ''Me.ColumnDataCache.FormSize = Me.ParentForm_DesignerDialog.Size
    ''
    ''''
    ''''STEP 3 of 5 
    ''''
    '''' Save the ColumnDataCache to disk. 
    ''''
    ''Dim strPathToXML_Opened As String = Me.ColumnDataCache.PathToXml_Opened
    ''Dim strPathToXML_Saved As String = Me.ColumnDataCache.PathToXml_Saved
    ''If String.IsNullOrEmpty(strPathToXML_Opened) Then strPathToXML_Opened = strPathToXML_Saved
    ''If String.IsNullOrEmpty(strPathToXML_Opened) Then strPathToXML_Opened =
    ''    DiskFilesVB.PathToFile_XML_RSCFieldSpreadsheet()
    ''Me.ColumnDataCache.SaveToXML(strPathToXML_Opened)
    ''Me.ColumnDataCache.PathToXml_Saved = strPathToXML_Opened
    ''''
    ''''STEP 4 of 5 
    ''''
    ''''  Column by column, save the current data value to the appropriate recipient field.  
    ''''
    ''For intIndex As Integer = 1 To Me.ColumnDataCache.ListOfColumns.Count
    ''    Dim eachColumn As RSCFieldColumnV2 ''Added 3/18/2022 thomas downes
    ''    eachColumn = mod_dict_RSCColumns(intIndex)
    ''    ''4/12/2022 td''eachColumn.SaveDataToColumn()
    ''    eachColumn.SaveDataTo_RecipientCache()
    ''Next intIndex
    ''''
    ''''Resize the form based on the save form size.---3/20/2022
    ''''
    ''''Moved up.3/20/22 ''Me.ColumnDataCache.FormSize = Me.ParentForm_DesignerDialog.Size
    ''''Added 3/18/2022 td
    ''If (pboolOpenXML) Then
    ''    System.Diagnostics.Process.Start(Me.ColumnDataCache.PathToXml_Saved)
    ''End If ''End of "If (pboolOpenXML) Then"
    ''
    ''End Sub ''End of "Public Sub SaveDataColumnByColumnXML()"



    ''Public Sub InsertNewColumnByIndex_NotInUse(par_intColumnIndex As Integer)
    ''    Dim objCacheOfData As CacheRSCFieldColumnWidthsEtc
    ''    Dim newRSCColumn As RSCFieldColumnV2
    ''    Dim intNewLength As Integer
    ''    Dim intNewColumnPropertyLeft As Integer
    ''    Dim intNewColumnWidth As Integer
    ''    Dim intFirstBumpedColumn_Left As Integer ''Added 4/1/2022 thomas downes
    ''
    ''    ''
    ''    ''Step 1 of 11.  Record the Left position which the new column will occupy. 
    ''    ''
    ''    Dim existingColumn As RSCFieldColumnV2 ''Added 4/14/2022
    ''    Dim boolPlaceWithinArray As Boolean ''Added 4/14/2022
    ''    Dim intIndexLastColumn As Integer ''Added 4/14/2022
    ''
    ''    ''4/2023 If (0 = mod_array_RSCColumns.Length) Then
    ''    If (0 = mod_dict_RSCColumns.Values.Count) Then ''Added 4/17/2022
    ''        ''
    ''        ''Added 4/17/2022 td
    ''        ''
    ''        intNewColumnPropertyLeft = RscFieldColumn1.Left
    ''
    ''    Else
    ''        ''Added 4/14/2022
    ''        boolPlaceWithinArray = (par_intColumnIndex < mod_dict_RSCColumns.Values.Count) ''Length)
    ''
    ''        If boolPlaceWithinArray Then
    ''            existingColumn = mod_dict_RSCColumns(par_intColumnIndex)
    ''            intNewColumnPropertyLeft = existingColumn.Left
    ''        Else
    ''            ''Added 4/14/2022 td
    ''            ''  Use -1 to shift our focus to the last column in the array.
    ''            intIndexLastColumn = (-1 + mod_dict_RSCColumns.Values.Count) '' .Length)
    ''            existingColumn = mod_dict_RSCColumns(intIndexLastColumn)
    ''            intNewColumnPropertyLeft = (existingColumn.Left + existingColumn.Width + mc_ColumnMarginGap)
    ''        End If ''End of ""If boolPlaceWithinArray Then ... Else ..."
    ''
    ''    End If ''End of ""If (0 = mod_array_RSCColumns.Length) Then... Else..."
    ''
    ''    intNewColumnWidth = mc_ColumnWidthDefault
    ''
    ''    ''
    ''    ''Step 2a of 11.  Make room in the array which tracks the columns.  
    ''    ''
    ''
    ''    ''----objCacheOfData =
    ''    ''For intIndex As Integer = 1 To Me.ColumnDataCache.ListOfColumns.Count
    ''    ''    Dim eachColumn As RSCFieldColumn ''Added 3/18/2022 thomas downes
    ''    ''    eachColumn = mod_array_RSCColumns(intIndex)
    ''    ''Next intIndex
    ''
    ''    intNewLength = (1 + mod_dict_RSCColumns.Values.Count) ''4/2023 .Length)
    ''    ''3/21/2022 td''ReDim Preserve mod_array_RSCColumns(intNewLength)  ''---(1 + mod_array_RSCColumns.Length)
    ''
    ''    ''The number passed to ReDim Preserve is the upper bound of the array, 
    ''    ''  not the length. ---4/15/2022
    ''    ''
    ''    ''4/18/2023 ReDim Preserve mod_dict_RSCColumns(intNewLength - 1)  ''Modified 3/21/2022 td
    ''    ''4/2023 If (mod_dict_RSCColumns.Length <> intNewLength) Then Throw New Exception
    ''    If (mod_dict_RSCColumns.Values.Count <> intNewLength) Then Throw New Exception
    ''
    ''    For intColIndex As Integer = (-1 + intNewLength) To (1 + par_intColumnIndex) Step -1
    ''        ''Move the object references to the right (new-higher index). 
    ''        ''
    ''        ''The qualification of "Step -1" makes the index run from a large value to a smaller value.
    ''        ''
    ''        mod_dict_RSCColumns(intColIndex) = mod_dict_RSCColumns(-1 + intColIndex)
    ''
    ''    Next intColIndex
    ''
    ''    ''The place will be filled by the new column. --Added 4/1/2022
    ''    Try
    ''        mod_dict_RSCColumns(par_intColumnIndex) = Nothing ''The place will be filled by the new column. --Added 4/1/2022  
    ''    Catch ex As Exception
    ''        ''Nothing needs to be done.04/17/2023 
    ''    End Try
    ''
    ''    ''
    ''    ''Step 2b of 11.  Move the columns to the right, to make room for the new column. 
    ''    ''
    ''    For intColIndex As Integer = (1 + par_intColumnIndex) To (-1 + intNewLength)
    ''        ''
    ''        ''Move the columns to the right, to make room for the new column. 
    ''        ''
    ''        mod_dict_RSCColumns(intColIndex).Left += (intNewColumnWidth + mc_ColumnMarginGap)
    ''
    ''        ''Added 4/1/2022 thomas downes
    ''        If (0 = intFirstBumpedColumn_Left) Then
    ''            intFirstBumpedColumn_Left = mod_dict_RSCColumns(intColIndex).Left
    ''        End If ''End of "If (0 = intFirstBumpedColumn_Left) Then"
    ''
    ''    Next intColIndex
    ''
    ''    ''
    ''    ''Step 3 of 11.  Make a new column.   
    ''    ''
    ''    ''
    ''    Dim intNextColumnPropertyLeft As Integer
    ''    Dim objColumnAdjacent As RSCFieldColumnV2 = Nothing
    ''
    ''    If (par_intColumnIndex > 0) Then
    ''        objColumnAdjacent = mod_dict_RSCColumns(-1 + par_intColumnIndex)
    ''    Else
    ''        objColumnAdjacent = mod_dict_RSCColumns(+1 + par_intColumnIndex)
    ''    End If
    ''
    ''    ''
    ''    ''Major call!!
    ''    ''
    ''    newRSCColumn = GenerateRSCFieldColumn_General(par_intColumnIndex,
    ''                                                intNewColumnPropertyLeft,
    ''                                                intNextColumnPropertyLeft,
    ''                                                objColumnAdjacent)
    ''
    ''    ''
    ''    ''Step 4 of 11. 
    ''    ''
    ''    newRSCColumn.ParentSpreadsheet = Me ''Added 4/30/2022 td
    ''    newRSCColumn.Top = RscFieldColumn1.Top
    ''    newRSCColumn.Height = RscFieldColumn1.Height
    ''    ''April 1st 2022 ''newRSCColumn.ListOfColumnsToBumpRight = New List(Of RSCFieldColumn)
    ''    Dim list_columnsToBumpRight As New List(Of RSCFieldColumnV2)
    ''
    ''    For intColIndex As Integer = (1 + par_intColumnIndex) To (intNewLength - 1)
    ''        ''
    ''        ''Move the columns to the right, to make room for the new column. 
    ''        ''
    ''        ''----With newRSCColumn.ListOfColumnsToBumpRight
    ''        With list_columnsToBumpRight
    ''            .Add(mod_dict_RSCColumns(intColIndex))
    ''        End With
    ''
    ''        ''Added 4/1/2022 thomas downes 
    ''        newRSCColumn.AddBumpColumn(mod_dict_RSCColumns(intColIndex))
    ''
    ''    Next intColIndex
    ''
    ''    ''
    ''    ''This will set the MoveAndResizeControls_Monem functionality as well. 
    ''    ''
    ''    newRSCColumn.ListOfColumnsToBumpRight = list_columnsToBumpRight
    ''
    ''    ''Added 4/14/2022 td
    ''    With newRSCColumn
    ''        If (.ColumnWidthAndData Is Nothing) Then
    ''            ''Added 4/14/2022 td
    ''            .ColumnWidthAndData = New ClassRSCColumnWidthAndData()
    ''            .ColumnWidthAndData.CIBField = EnumCIBFields.Undetermined
    ''            .ColumnWidthAndData.Width = mc_ColumnWidthDefault
    ''        End If ''End of ""If (.ColumnWidthAndData Is Nothing) Then""
    ''    End With ''End of ""With newRSCColumn""
    ''
    ''    ''
    ''    ''Step 5 of 11. 
    ''    ''
    ''    newRSCColumn.Load_FieldsFromCache(Me.ElementsCache_Deprecated)
    ''
    ''    ''
    ''    ''Step 6 of 11. 
    ''    ''
    ''    Dim boolTestNewColumn_OK As Boolean ''Added 4/1/2022 thomas d
    ''    Dim intExpectedFirstBumped_Left As Integer
    ''    Dim intDifferenceDelta As Integer
    ''
    ''    intExpectedFirstBumped_Left = (newRSCColumn.Left + newRSCColumn.Width + mc_ColumnMarginGap)
    ''    intDifferenceDelta = (intExpectedFirstBumped_Left - intFirstBumpedColumn_Left)
    ''
    ''    boolTestNewColumn_OK = (newRSCColumn.Left + newRSCColumn.Width +
    ''        mc_ColumnMarginGap <= intFirstBumpedColumn_Left)
    ''    If (Not boolTestNewColumn_OK) Then
    ''        ''System.Diagnostics.Debugger.Break()
    ''    ElseIf (intDifferenceDelta > 0) Then
    ''        ''System.Diagnostics.Debugger.Break()
    ''    End If ''End of "If (Not boolTestNewColumn_OK) Then"
    ''
    ''    ''
    ''    ''Step 7 of 11.   Move the columns to the right, to make room for the new column. 
    ''    ''     (This is similar to Step 1(b) of 6 above, but is a further adjustment.) 
    ''    ''
    ''    If (intDifferenceDelta > 0) Then
    ''        For intColIndex As Integer = (1 + par_intColumnIndex) To (-1 + intNewLength)
    ''            ''
    ''            ''Move the columns to the right, as a 2nd, final attempt to make room for the new column. 
    ''            ''
    ''            ''---mod_array_RSCColumns(intIndex).Left += (intNewColumnWidth + mc_ColumnMarginGap)
    ''            mod_dict_RSCColumns(intColIndex).Left += intDifferenceDelta
    ''
    ''        Next intColIndex
    ''    End If ''End of "If (intDifferenceDelta > 0) Then"
    ''
    ''    ''
    ''    ''Step 8 of 11.  Add the column as a "Bump Column" for all the columns to the left.  
    ''    ''
    ''    Dim bIgnoreIndex0 As Boolean ''Added 4/14/2022 td 
    ''
    ''    For intColIndex As Integer = 0 To (-1 + par_intColumnIndex) ''To (-1 + intNewLength)
    ''        ''---For intColIndex As Integer = 0 To (-1 + par_intColumnIndex) 
    ''        ''
    ''        ''Add the column as a "Bump Column" for all the columns to the left. 
    ''        ''
    ''        bIgnoreIndex0 = (intColIndex = 0 And mod_dict_RSCColumns(intColIndex) Is Nothing)
    ''        If bIgnoreIndex0 Then Continue For
    ''
    ''        ''4/14/2022 mod_array_RSCColumns(intColIndex).ListOfColumnsToBumpRight.Add(newRSCColumn)
    ''        mod_dict_RSCColumns(intColIndex).AddBumpColumn(newRSCColumn)
    ''
    ''    Next intColIndex
    ''
    ''    ''
    ''    ''Step 9 of 11. 
    ''    ''
    ''    Load_EmptyRowsToAllNewColumns()
    ''
    ''    ''
    ''    ''Step 10 of 11.  Add the new column to the list of columns in the cache. 
    ''    ''
    ''    Me.ColumnDataCache.ListOfColumns.Add(newRSCColumn.ColumnWidthAndData)
    ''
    ''    ''
    ''    ''Step 11 of 11.  Display the corrected column index on each columns to the right.  
    ''    ''
    ''    For intColIndex As Integer = (1 + par_intColumnIndex) To (-1 + intNewLength)
    ''        ''
    ''        ''Display the corrected column index on each columns to the right. 
    ''        ''
    ''        mod_dict_RSCColumns(intColIndex).DisplayColumnIndex(intColIndex)
    ''
    ''    Next intColIndex
    ''
    ''    ''Added 5/30/2022 
    ''    If mc_boolKeepUILookingClean Then
    ''        ''Hide the buttons which formerly occupied the blank area
    ''        '' of the spreadsheet. ---5/13/2022 
    ''        ButtonAddColumns2.Visible = False
    ''        ButtonPasteData2.Visible = False
    ''    End If ''End of ""If mc_boolKeepUILookingClean Then""
    ''
    ''End Sub ''End of "Public Sub InsertNewColumnByIndex(Me.ColumnIndex)"


    ''4/26/2023 td Public Sub DeleteColumnByIndex_NotInUse(par_intColumnIndex As Integer)
    ''    ''
    ''    ''Added 4/14/2022 thomas downes 
    ''    ''
    ''    ''Dim objCacheOfData As CacheRSCFieldColumnWidthsEtc
    ''    ''Dim newRSCColumn As RSCFieldColumnV2
    ''    Dim intCurrentLengthOfArray As Integer
    ''    Dim intNewLengthOfArray_ByMinus1 As Integer
    ''    Dim intNewLengthOfArray As Integer
    ''    ''Dim intNewColumnPropertyLeft As Integer
    ''    ''Dim intNewColumnWidth As Integer
    ''    Dim intFirstBumpedColumn_Left As Integer ''Added 4/1/2022 thomas downes

    ''    ''
    ''    ''Step 0 of 5.  Run some basic checks. 
    ''    ''
    ''    Dim columnAboutToDelete As RSCFieldColumnV2 ''Added 4/14/2022
    ''    Dim intColumnAboutToDelete_Left As Integer ''Added 4/15/2022
    ''    Dim boolPlaceWithinArray As Boolean ''Added 4/14/2022
    ''    Dim intIndexLastColumn As Integer ''Added 4/14/2022
    ''    Dim intWidthOfDeletedColumn As Integer ''Added 4/15/2022

    ''    ''
    ''    ''Added 4/14/2022
    ''    ''
    ''    ''4/15/2022 td ''boolPlaceWithinArray = (par_intColumnIndex <= mod_array_RSCColumns.Length)
    ''    boolPlaceWithinArray = (par_intColumnIndex < mod_dict_RSCColumns.Values.Count) ''4/2023 .Length)

    ''    If boolPlaceWithinArray Then
    ''        columnAboutToDelete = mod_dict_RSCColumns(par_intColumnIndex)
    ''        ''intNewColumnPropertyLeft = existingColumn.Left
    ''        columnAboutToDelete.Visible = False ''Render it invisible.
    ''        ''Added 4/15/2022 td
    ''        intColumnAboutToDelete_Left = columnAboutToDelete.Left
    ''
    ''        ''Added 4/15/2022 td
    ''        If (columnAboutToDelete Is RscFieldColumn1) Then
    ''            Try
    ''                RscFieldColumn1 = mod_dict_RSCColumns(par_intColumnIndex + 1)
    ''            Catch
    ''                ''If the user has deleted all of the columns, then this is the result.
    ''                ''   (Zero columns left.) ---4/15/2022 thomas d
    ''                RscFieldColumn1 = Nothing
    ''            End Try
    ''        End If ''End of ""If (columnAboutToDelete Is RscFieldColumn1) Then""
    ''
    ''    Else
    ''        ''
    ''        ''Shouldn't happen. 
    ''        ''
    ''        System.Diagnostics.Debugger.Break() ''Throw new Exception("Why wasn't the column found?")
    ''
    ''        ''Added 4/14/2022 td
    ''        ''  Use -1 to shift our focus to the last column in the array.
    ''        intIndexLastColumn = (-1 + mod_dict_RSCColumns.Values.Count)  ''4/2023 .Length)
    ''        columnAboutToDelete = mod_dict_RSCColumns(intIndexLastColumn)
    ''        ''intNewColumnPropertyLeft = (existingColumn.Left + existingColumn.Width + mc_ColumnMarginGap)
    ''        columnAboutToDelete.Visible = False ''Render it invisible.
    ''
    ''    End If ''End of ""If boolPlaceWithinArray Then ... Else ..."
    ''
    ''    ''intNewColumnWidth = mc_ColumnWidthDefault
    ''
    ''    ''
    ''    ''Step 1a of 6.  Make room in the array which tracks the columns.  
    ''    ''
    ''
    ''    ''----objCacheOfData =
    ''    ''For intIndex As Integer = 1 To Me.ColumnDataCache.ListOfColumns.Count
    ''    ''    Dim eachColumn As RSCFieldColumn ''Added 3/18/2022 thomas downes
    ''    ''    eachColumn = mod_array_RSCColumns(intIndex)
    ''    ''Next intIndex
    ''
    ''    ''Moved below. intNewLengthOfArray_Minus1 = (-1 + mod_array_RSCColumns.Length)
    ''    ''Moved below. ''3/21/2022 td''ReDim Preserve mod_array_RSCColumns(intNewLength)  ''---(1 + mod_array_RSCColumns.Length)
    ''    ''Moved below. ReDim Preserve mod_array_RSCColumns(intNewLengthOfArray_Minus1)  ''Modified 3/21/2022 td
    ''    ''Moved below. If (mod_array_RSCColumns.Length <> intNewLengthOfArray_Minus1) Then Throw New Exception
    ''
    ''    intCurrentLengthOfArray = mod_dict_RSCColumns.Values.Count ''4/2023 .Length
    ''
    ''    For intColIndex As Integer = par_intColumnIndex To (-1 - 1 + intCurrentLengthOfArray)
    ''        ''---For intColIndex As Integer = par_intColumnIndex To (-1 + intCurrentLengthOfArray)
    ''        ''
    ''        ''Move the object references to the left (lower-higher index). 
    ''        ''
    ''        mod_dict_RSCColumns(intColIndex) = mod_dict_RSCColumns(intColIndex + 1)
    ''
    ''    Next intColIndex
    ''
    ''    ''
    ''    ''Remove the last item in the array.  
    ''    ''
    ''    ''April 18 2023 intNewLengthOfArray_ByMinus1 = (-1 + mod_dict_RSCColumns.Length)
    ''    intNewLengthOfArray_ByMinus1 = (-1 + mod_dict_RSCColumns.Count)
    ''    ''3/21/2022 td''ReDim Preserve mod_array_RSCColumns(intNewLength)  ''---(1 + mod_array_RSCColumns.Length)
    ''    ''
    ''    ''The number passed to ReDim Preserve is the upper bound of the array, 
    ''    ''  not the length. ---4/15/2022
    ''    ''
    ''    ReDim Preserve mod_dict_RSCColumns(-1 + intNewLengthOfArray_ByMinus1)  ''Modified 3/21/2022 td
    ''    If (mod_dict_RSCColumns.Count <> intNewLengthOfArray_ByMinus1) Then Throw New Exception
    ''    intNewLengthOfArray = intNewLengthOfArray_ByMinus1 ''We don't need the suffix anymore. 
    ''
    ''    ''
    ''    ''Step 1b of 6.  Move the columns to the left, in place of the soon-to-be-deleted column. 
    ''    ''
    ''    intWidthOfDeletedColumn = columnAboutToDelete.Width
    ''
    ''    intFirstBumpedColumn_Left = Integer.MaxValue ''Default value
    ''    For Each each_col As RSCFieldColumnV2 In mod_dict_RSCColumns.Values
    ''        ''---For intColIndex As Integer = (1 + par_intColumnIndex) To (intNewLengthOfArray) '' (-1 + intNewLengthOfArray)
    ''        ''
    ''        ''If the column's Left edge is greater (bigger in X value) then 
    ''        ''   the column we are deleting....
    ''        ''   Then move the column to the left, in place of the deleted column. 
    ''        ''   ----4/15/2022
    ''        ''
    ''        If (each_col Is Nothing) Then
    ''            ''
    ''            ''Don't process a Null reference. ---4/15/2022
    ''            ''
    ''        ElseIf (each_col.Left > intColumnAboutToDelete_Left) Then
    ''
    ''            each_col.Left -= (intWidthOfDeletedColumn + mc_ColumnMarginGap)
    ''
    ''            ''Added 4/1/2022 thomas downes
    ''            ''   Save the new location of the leftmost column.
    ''            ''   Whichever is furthest left, supplies the final value.
    ''            If (each_col.Left < intFirstBumpedColumn_Left) Then
    ''                intFirstBumpedColumn_Left = each_col.Left
    ''            End If
    ''
    ''        End If ''End of ""ElseIf (each_col.Left > intColumnAboutToDelete_Left) Then""
    ''
    ''    Next each_col
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
    ''        bIgnoreIndex0 = (intColIndex = 0 And mod_dict_RSCColumns(intColIndex) Is Nothing)
    ''        If bIgnoreIndex0 Then Continue For
    ''
    ''        mod_dict_RSCColumns(intColIndex).RemoveBumpColumn(columnAboutToDelete)
    ''
    ''    Next intColIndex
    ''
    ''    ''
    ''    ''Remove the column from the controls.
    ''    ''
    ''    Me.Controls.Remove(columnAboutToDelete)
    ''
    ''    ''
    ''    ''Remove the column from the column-width cache 
    ''    ''
    ''    Dim delete_columnWidthAndData As ClassRSCColumnWidthAndData
    ''    delete_columnWidthAndData = columnAboutToDelete.ColumnWidthAndData
    ''    Me.ColumnDataCache.ListOfColumns.Remove(delete_columnWidthAndData)
    ''
    ''    ''
    ''    ''Check to see if RSCColumn1 is affected. 
    ''    ''
    ''    If (RscFieldColumn1 Is columnAboutToDelete) Then
    ''        RscFieldColumn1 = mod_dict_RSCColumns(0) ''Probably a null reference,
    ''        '' as 0 is not being used!?  ----4/15/2022
    ''        If (RscFieldColumn1 Is Nothing) Then
    ''            RscFieldColumn1 = mod_dict_RSCColumns(1)
    ''        End If ''End of ""If (RscFieldColumn1 Is Nothing) Then""
    ''    End If ''ENdof ""If (RscFieldColumn1 = columnAboutToDelete) Then""
    ''
    ''End Sub ''End of "Public Sub DeleteColumnByIndex(Me.ColumnIndex)"



End Class
