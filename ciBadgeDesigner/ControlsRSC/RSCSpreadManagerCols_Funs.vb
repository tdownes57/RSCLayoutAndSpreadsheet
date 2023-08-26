''
''Added 4/28/2023  
''
''  These are the functions. 
''
''4/26/2023 Imports System.Drawing ''Added 3/20/2022 thomas downes
''4/26/2023 Imports __RSCWindowsControlLibrary
''4/26/2023 Imports ciBadgeCachePersonality ''Added 3/14/2.0.2.2. t.//downes
''4/26/2023 Imports ciBadgeElements
Imports System.Drawing.Text
Imports ciBadgeCachePersonality
Imports ciBadgeFields ''Added 3/10/2.0.2.2. thomas downes
Imports ciBadgeInterfaces ''Added 3/11/2022 t__homas d__ownes

Partial Public Class RSCSpreadManagerCols


    Public Function CountOfColumnsWithoutFields(Optional ByRef pref_intCountAllColumns As Integer = 0) As Integer
        ''
        '' Added 4/18/2023 & 5/25/2022  
        ''
        Dim intCountColsAll As Integer = 0
        Dim intCountColsWithout As Integer = 0
        Dim eachRSCColumn As RSCFieldColumnV2

        ''5/09/2023 For Each eachRSCColumn In mod_dict_RSCColumns.Values ''4/17/2023  mod_array_RSCColumns
        For Each eachRSCColumn In mod_dlist_RSCColumns ''5/9/2023 .Values ''4/17/2023  mod_array_RSCColumns
            ''
            ''Build the dictionaries. 
            ''
            If (eachRSCColumn Is Nothing) Then Continue For

            intCountColsAll += 1

            If (Not eachRSCColumn.HasField_Selected()) Then intCountColsWithout += 1

        Next eachRSCColumn

        pref_intCountAllColumns = intCountColsAll
        Return intCountColsWithout

    End Function ''End of ""Public Function CountOfColumnsWithoutFields() As Integer""


    Public Function ReviewColumnDisplayForRelevantFields_1to1(pboolMessageUser As Boolean,
                                           ByRef pbUserWantsFieldsManager As Boolean) As DialogResult
        ''5/2022 ''Public Sub ReviewColumnDisplayForRelevantFields_1to1
        ''
        ''Added 4/26/2022 thomas 
        ''
        ''Populate both dictionaries. 
        ''   1FC. Field-->Column. (EnumCIBFields-->RSCFieldColumn dictionary. 
        ''   2CF. Column-->Field. (RSCFieldColumn-->EnumCIBFields) dictionary. 
        ''
        Dim dictionary1FC_FieldsToRSCColumn As New Dictionary(Of EnumCIBFields, RSCFieldColumnV2)
        Dim dictionary2CF_ColumnToEnumField As New Dictionary(Of RSCFieldColumnV2, EnumCIBFields)
        Dim eachRSCColumn As RSCFieldColumnV2
        Dim objectStringBuilder1FC As New System.Text.StringBuilder(150)
        Dim objectStringBuilder2CF As New System.Text.StringBuilder(150)
        Dim objectStringBuilder1FC_Expanded As System.Text.StringBuilder
        Dim dictionary1FC_Expanded As New Dictionary(Of EnumCIBFields, RSCFieldColumnV2)
        ''4/26/2023 Dim bUserWantsFieldsManager As Boolean = False ''Added 5/13/2022
        Dim output_dialogResult As DialogResult ''Added 5/13/2022 

        ''5/9/2023 For Each eachRSCColumn In mod_dict_RSCColumns.Values
        For Each eachRSCColumn In mod_dlist_RSCColumns ''5/9/2023 .Values
            ''
            ''Build the dictionaries. 
            ''
            If (eachRSCColumn Is Nothing) Then Continue For

            eachRSCColumn.ReviewColumnDisplayForRelevantFields(dictionary1FC_FieldsToRSCColumn,
                    dictionary2CF_ColumnToEnumField,
                    objectStringBuilder1FC,
                    objectStringBuilder2CF)

        Next eachRSCColumn

        ''Refresh the module-level objects.
        m_dictionary1FC_FieldsToRSCColumn = dictionary1FC_FieldsToRSCColumn
        m_dictionary2CF_ColumnToEnumField = dictionary2CF_ColumnToEnumField

        ''Message the user, if required by parameter. ---4/30 td
        If (pboolMessageUser) Then
            ''
            ''   2CF. Column-->Field. (RSCFieldColumn-->EnumCIBFields) dictionary. 
            ''
            ''
            ''5/13/2022 MessageBoxTD.Show_Statement("Here is the list of Columns & corresponding Fields:",
            ''                  objectStringBuilder2CF.ToString())
            output_dialogResult =
            MessageBoxTD.Show_StatementLongform("Here is the list of Columns && corresponding Relevant Fields:",
                                        objectStringBuilder2CF.ToString(),
                                        1.7, 1.0, False)

            ''
            ''   1FC. Field-->Column. (EnumCIBFields-->RSCFieldColumn dictionary. 
            ''
            Const c_expandToShowAllRelevantFields As Boolean = True ''Added 4/30/2022 td
            If (c_expandToShowAllRelevantFields) Then

                ''Added 4/30/2022 td
                objectStringBuilder1FC_Expanded = New System.Text.StringBuilder(200)
                dictionary1FC_Expanded =
                   ExpandDictionary1FC(dictionary1FC_FieldsToRSCColumn, objectStringBuilder1FC_Expanded)

                ''MessageBoxTD.Show_Statement("Here is the list of Relevant Fields & corresponding columns.",
                ''    objectStringBuilder1FC_Expanded.ToString())
                Const c_showFieldsButton As Boolean = True ''Added 5/13/2022
                Dim bUserPressedButton As Boolean = False ''Added 5/13/2022

                If (c_showFieldsButton) Then
                    ''Added 5/13/2022
                    output_dialogResult =
                    MessageBoxTD.Show_SpecialButton("Here is the list of Relevant Fields && corresponding columns:",
                                            objectStringBuilder1FC_Expanded.ToString(),
                                            1.7, 2.0, "Manage Relevant Fields", bUserPressedButton)
                    ''4/26/2023 pbUserWantsFieldsManager = bUserPressedButton
                    pbUserWantsFieldsManager = bUserPressedButton

                Else
                    ''Added 5/13/2022
                    output_dialogResult =
                    MessageBoxTD.Show_StatementLongform("Here is the list of Fields && corresponding columns:",
                                            objectStringBuilder1FC_Expanded.ToString(),
                                            1.7, 2.0)
                End If ''End of ""If (c_showFieldsButton) Then.... Else..."

            Else
                ''Added 4/30/2022
                ''MessageBoxTD.Show_Statement("Here is the list of Fields & corresponding columns.",
                ''                        objectStringBuilder1FC.ToString())
                output_dialogResult =
                MessageBoxTD.Show_StatementLongform("Here is the list of Fields & corresponding columns:",
                                        objectStringBuilder1FC.ToString(),
                                        1.0, 2.0)

            End If ''End of "If (c_expandToShowAllRelevantFields) Then... Else..."

        End If ''End of ""If (pboolMessageUser) Then""

        ''
        ''Show Fields Manager, if appopriate.  ---5/13/2022 td
        ''
        ''4/26/2023 If (bUserWantsFieldsManager) Then ShowFieldsManagement()

        ''Added 5/13/2022 td
        Return output_dialogResult

    End Function ''End of ""Public Sub ReviewColumnDisplayForRelevantFields()""


    Private Function ExpandDictionary1FC(par_dictionary1FC_FieldsToColumn As Dictionary(Of EnumCIBFields, RSCFieldColumnV2),
                                    par_stringbuilder As System.Text.StringBuilder) _
                                As Dictionary(Of EnumCIBFields, RSCFieldColumnV2)
        ''
        ''Added 4/30/2022 thomas d.
        ''
        Dim output_dictionary As Dictionary(Of EnumCIBFields, RSCFieldColumnV2)
        ''--Dim list_enumFieldsRelevant As List(Of EnumCIBFields)
        Dim list_fieldsRelevant As List(Of ClassFieldAny)
        ''---list_enumFieldsRelevant = ModEnumsAndStructs.GetListOfAllFieldEnums_Relevant()
        Dim each_fieldRelevant As ClassFieldAny
        Dim each_enumRelevant As EnumCIBFields
        Dim each_RSCColumn As RSCFieldColumnV2
        Dim boolFoundColumn As Boolean

        par_stringbuilder.AppendLine()

        ''4/28/2023 td list_fieldsRelevant = Me.ElementsCache_Deprecated.ListOfFields_AnyRelevent()
        list_fieldsRelevant = mod_cacheElements.ListOfFields_AnyRelevent()

        output_dictionary = New Dictionary(Of EnumCIBFields, RSCFieldColumnV2)()

        For Each each_fieldRelevant In list_fieldsRelevant

            each_RSCColumn = Nothing ''Reinitialize. 
            each_enumRelevant = each_fieldRelevant.FieldEnumValue
            boolFoundColumn = par_dictionary1FC_FieldsToColumn.ContainsKey(each_enumRelevant)

            ''Will this return a Null value?
            If (boolFoundColumn) Then
                each_RSCColumn = par_dictionary1FC_FieldsToColumn.Item(each_enumRelevant)
                output_dictionary.Add(each_enumRelevant, each_RSCColumn)
                ''Added 5/13/2022
                par_stringbuilder.AppendLine("Field """ + each_fieldRelevant.FieldLabelCaption + """" +
                                             " is assigned to Column # " +
                                             each_RSCColumn.GetIndexOfColumn().ToString())

            Else
                ''Enter a null value.  
                output_dictionary.Add(each_enumRelevant, Nothing)
                ''Added 5/13/2022
                par_stringbuilder.AppendLine("Field """ + each_fieldRelevant.FieldLabelCaption + """" +
                                             " is not assigned to any column.")

            End If ''end of ""If (boolFoundColumn) Then ... Else ""

        Next each_fieldRelevant

        ''
        ''Exit Handler
        ''
        Return output_dictionary

    End Function ''End of ""Private Sub ExpandDictionary1FC""


    Public Function Count() As Integer

        ''Added 4/19/2023 thomas d
        ''5/9/2023 Return mod_dict_RSCColumns.Count
        Return mod_dlist_RSCColumns.Count

    End Function ''End of ""Public Function Count() As Integer""


    Public Function LeftHandColumn() As RSCFieldColumnV2
        ''
        ''Added 4/19/2023 td
        ''
        Dim columnLeftHandMost As RSCFieldColumnV2
        ''5/9/2023 columnLeftHandMost = mod_dict_RSCColumns(0)
        columnLeftHandMost = mod_dlist_RSCColumns.GetFirst()

        If (columnLeftHandMost Is Nothing) Then
            ''5/9/2023 columnLeftHandMost = mod_dict_RSCColumns(1)
            System.Diagnostics.Debugger.Break()
        End If ''End of ""If (columnLeftHandMost Is Nothing) Then""

        Return columnLeftHandMost

    End Function ''End of ""Public Function LeftHandColumn()""


    Public Function ListOfColumns() As List(Of RSCFieldColumnV2)

        ''Added 3/21/2022 thomas downes
        ''\\---Return New List(Of RSCFieldColumn)(mod_array_RSCColumns)
        Dim oList As List(Of RSCFieldColumnV2)
        ''4/17/2023 oList = New List(Of RSCFieldColumnV2)(mod_array_RSCColumns)
        ''5/09/2023 oList = New List(Of RSCFieldColumnV2)(mod_dict_RSCColumns.Values)
        oList = New List(Of RSCFieldColumnV2)(mod_dlist_RSCColumns)
        oList.Remove(Nothing) ''Item #0 is Nothing, so let's omit the Null reference. 
        Return oList

    End Function ''End of ""Public Function ListOfColumns() As List(Of RSCFieldColumn)""



    Public Function GetSpreadManagerRows() As RSCSpreadManagerRows
        ''
        ''Added 4/19/2023  
        ''
        Dim output As RSCSpreadManagerRows
        ''5/9/2023 output = New RSCSpreadManagerRows(mod_controlSpread,
        ''                mod_dict_RSCColumns,
        output = New RSCSpreadManagerRows(mod_controlSpread,
                        mod_dlist_RSCColumns,
                        mod_columnDesignedV2,
                        mod_controlSpread.RscRowHeaders1)
        Return output

    End Function ''End of ""Public Function GetSpreadManagerRows()""


    Public Function GetFirstColumn() As RSCFieldColumnV2
        ''
        ''Added 4/12/2022 thomas downes
        ''
        ''4/2023 If (0 = mod_array_RSCColumns.Length) Then Return Nothing
        ''5/2023 If (0 = mod_dict_RSCColumns.Values.Count) Then Return Nothing
        ''5/2023 If (mod_dict_RSCColumns(0) Is Nothing) Then Return mod_dict_RSCColumns(1)
        ''5/2023 Return mod_dict_RSCColumns(0)

        Return mod_dlist_RSCColumns.GetFirst()

    End Function ''End of ""Public Function GetNextColumn_RightOf(....)""


    Public Function GetColumnWithColumnData(par_columnData As ClassRSCColumnWidthAndData) As RSCFieldColumnV2
        ''
        ''Added 6/06/2023
        ''
        Dim each_column As RSCFieldColumnV2
        Dim bColHasIdentifyingData As Boolean

        For Each each_column In mod_dlist_RSCColumns ''mod_dict_RSCColumns.Values

            If (each_column Is Nothing) Then Continue For

            bColHasIdentifyingData =
                (each_column.ColumnWidthAndData Is par_columnData)

            If (bColHasIdentifyingData) Then Return each_column

        Next each_column

        Return Nothing

    End Function ''end of ""Public Function GetColumnWithColumnData""


    Public Function GetNextColumn_LeftOf(par_column As RSCFieldColumnV2) As RSCFieldColumnV2
        ''
        ''Added 4/12/2022 thomas downes
        ''
        Return par_column.FieldColumnNextLeft

        ''Dim each_column As RSCFieldColumnV2
        ''Dim prior_column As RSCFieldColumnV2 = Nothing
        ''Dim boolMatches As Boolean
        ''Dim boolMatches_Prior As Boolean
        ''For Each each_column In mod_dlist_RSCColumns ''5/2023 mod_dict_RSCColumns.Values
        ''    boolMatches = (each_column Is par_column)
        ''    If (boolMatches) Then Return prior_column
        ''    ''Prepare for the next iteration.
        ''    prior_column = each_column
        ''    boolMatches_Prior = boolMatches
        ''Next each_column
        ''Return Nothing

    End Function ''End of ""Public Function GetNextColumn_LeftOf(....)""


    Public Function GetNextColumn_RightOf(par_column As RSCFieldColumnV2) As RSCFieldColumnV2
        ''
        ''Added 4/12/2022 thomas downes
        ''
        Return par_column.FieldColumnNextRight

        ''Dim each_column As RSCFieldColumnV2
        ''Dim boolMatches As Boolean
        ''Dim boolMatches_Prior As Boolean
        ''For Each each_column In mod_dict_RSCColumns.Values
        ''    boolMatches = (each_column Is par_column)
        ''    If (boolMatches_Prior) Then Return each_column
        ''    ''Prepare for the next iteration. 
        ''    boolMatches_Prior = boolMatches
        ''Next each_column
        ''Return Nothing

    End Function ''End of ""Public Function GetNextColumn_RightOf(....)""


    Public Function GetIndexOfColumn(par_column As RSCFieldColumnV2) As Integer
        ''
        ''Added 4/15/2022 td
        ''
        Return mod_dlist_RSCColumns.GetIndexOf(par_column)

        ''Dim strErrorMessage As String ''Added 5/6/2023 td
        ''''4/17/23  For intColIndex As Integer = 0 To (-1 + mod_array_RSCColumns.Length)
        ''For intColIndex As Integer = 0 To (-1 + mod_dict_RSCColumns.Values.Count) ''4/17/23 mod_array_RSCColumns.Length
        ''    Try
        ''        ''5/7/2023 If (mod_dict_RSCColumns.Item(intColIndex) Is par_column) Then Return intColIndex
        ''        If (mod_dict_RSCColumns.ContainsKey(intColIndex)) Then
        ''            If (mod_dict_RSCColumns.Item(intColIndex) Is par_column) Then
        ''                Return intColIndex
        ''            End If ''End of ""If (mod_dict_RSCColumns.Item(intColIndex) Is par_column) Then""
        ''        End If ''End of ""If (mod_dict_RSCColumns.ContainsKey(intColIndex)) Then""
        ''    Catch ex_dict As Exception
        ''        ''Added 5/06/2023 td 
        ''        strErrorMessage = ex_dict.Message
        ''    End Try
        ''Next intColIndex
        ''Return -1

    End Function ''end of Public Function GetIndexOfColumn(par_column As RSCFieldColumnV2) As Integer


    Public Function GetRowIndexOfCell(par_objDataCell As RSCDataCell) As Integer
        ''
        ''Added 4/27/2022 thomas downes
        ''
        Dim intRowOfDataCell As Integer = 0

        For Each each_column As RSCFieldColumnV2 In mod_dlist_RSCColumns ''mod_dict_RSCColumns.Values
            If (each_column Is Nothing) Then Continue For
            intRowOfDataCell = -1
            intRowOfDataCell = each_column.GetRowIndexOfCell(par_objDataCell)
            If (intRowOfDataCell > 0) Then Exit For
        Next each_column

        Return intRowOfDataCell

    End Function ''End of ""Public Function GetRowIndexOfCell(par_objDataCell As RSCDataCell)""


    Public Function HasIdentifyingData() As Boolean
        ''
        ''Added 5/14/2022 thomas downes 
        ''
        Dim each_column As RSCFieldColumnV2
        Dim bColHasIdentifyingData As Boolean

        For Each each_column In mod_dlist_RSCColumns ''mod_dict_RSCColumns.Values

            If (each_column Is Nothing) Then Continue For

            bColHasIdentifyingData = each_column.HasIdentifyingData()
            If (bColHasIdentifyingData) Then Return True

        Next each_column

        Return False

    End Function ''End of ""Public Function HasIdentifyingData() As Boolean""


    Public Function Equals_RecipientListAtClose(par_list_recipients As List(Of ciBadgeRecipients.ClassRecipient)) As Boolean
        ''
        ''Encapsulated 4/28/2023 
        ''
        Dim bEachCol_matches As Boolean
        Dim bSum_matches As Boolean
        Dim each_column As RSCFieldColumnV2

        ''5/8/2023 For Each each_column In mod_dict_RSCColumns.Values

        ''5/8/2023 If (each_column Is Nothing) Then Continue For

        each_column = mod_dlist_RSCColumns.GetFirst()

        Do While (each_column IsNot Nothing)

            bEachCol_matches = each_column.Equals_RecipientListAtClose(par_list_recipients)
            bSum_matches = (bSum_matches And bEachCol_matches)
            each_column = each_column.FieldColumnNextRight

        Loop ''5/8/2023 Next each_column

        Return bSum_matches

    End Function ''End of ""Public Function Equals_RecipientListAtClose() As Boolean""


    Public Function ToString_ByRow(par_intRowIndex As Integer,
                        Optional pboolRowIndices As Boolean = False) As String
        ''
        ''Added 4/03/2022
        ''
        ''5/2023 Dim intCountColumns As Integer
        ''5/2023 Dim list_columns As List(Of RSCFieldColumnV2)
        Dim each_column As RSCFieldColumnV2
        Dim strValue As String
        Dim strLine As String = ""

        ''Added 4/12/2022 td
        If (pboolRowIndices) Then strLine = par_intRowIndex.ToString

        ''5/2023 list_columns = ListOfColumns()
        ''5/2023 intCountColumns = list_columns.Count()
        ''5/2023 For intColIndex As Integer = 0 To intCountColumns - 1
        ''    each_column = list_columns(intColIndex)

        For Each each_column In mod_dlist_RSCColumns
            strValue = each_column.ToString_ByRow(par_intRowIndex)
            If (strValue = "") Then
                strLine &= (strValue)
            Else
                strLine &= (vbTab & strValue)
            End If

            ''5/2023 Next intColIndex
        Next each_column

        Return strLine

    End Function ''End of ""Public Function ToString_ByRow()""


End Class ''End of ""Partial Public Class RSCSpreadManagerCols""
