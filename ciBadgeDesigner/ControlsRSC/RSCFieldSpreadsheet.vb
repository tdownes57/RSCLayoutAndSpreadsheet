''
''Added 2/21/2022 td
''
Imports System.Drawing ''Added 3/20/2022 thomas downes
Imports __RSCWindowsControlLibrary
Imports ciBadgeCachePersonality ''Added 3/14/2.0.2.2. t.//downes
Imports ciBadgeFields ''Added 3/10/2.0.2.2. thomas downes
Imports ciBadgeInterfaces ''Added 3/11/2022 t__homas d__ownes

Public Class RSCFieldSpreadsheet
    ''
    ''Added 2/21/2022 td
    ''
    Public ParentForm_DesignerDialog As Form ''ciBadgeDesigner.DialogEditRecipients 
    Public Designer As ClassDesigner ''Added 3/10/2022 td
    Public ElementsCache_Deprecated As ciBadgeCachePersonality.ClassElementsCache_Deprecated ''Added 3/10/2022 td
    ''April 13 2022 ''Public ColumnDataCache As CacheRSCFieldColumnWidthsEtc ''ClassColumnWidthsEtc ''Added 3/15/2022 td
    Public ColumnDataCache As ciBadgeCachePersonality.CacheRSCFieldColumnWidthsEtc ''ClassColumnWidthsEtc ''Added 3/15/2022 td
    ''Public RscFieldColumn1 As RSCFieldColumn ''Added 3/25/2022 td
    Public RecipientsCache As ClassCacheOnePersonalityConfig ''Added 3/28/2022 thomas downes


    Public Property RowDisplayCardHeight As Integer ''= 0 ''Added 5/30/2022 td
        ''= 0 ''Added 5/30/2022 td
        Get
            Return mod_intRowDisplayCardHeight
        End Get
        Set(value As Integer)
            mod_intRowDisplayCardHeight = value
            ''RscRowHeaders1.RowDisplayCardHeight = value
        End Set
    End Property
    Private mod_intRowDisplayCardHeight As Integer = 0 ''= 0 ''Added 5/30/2022 td

    Private mod_ctlLasttouched As New ClassLastControlTouched ''Added 1/4/2022 td
    Private mod_eventsSingleton As New GroupMoveEvents_Singleton(Me.Designer, False, True) ''Added 1/4/2022 td  
    Private mod_colorOfColumnsBackColor As System.Drawing.Color = Drawing.Color.AntiqueWhite ''Added 3/13/2022 thomas downes
    Private mod_array_RSCColumns As RSCFieldColumnV2() ''Added 3/14/2022 td

    Private Const mc_ColumnWidthDefault As Integer = 150 ''72 ''Added 3/20/2022 td
    Private Const mc_ColumnMarginGap As Integer = 3 ''---4 ''Added 3/20/2022 td
    Private Const mod_intRscFieldColumn1_Top As Integer = 19 ''Added 4/3/2022 thomas downes
    Private Const mc_intPixelsFromRowToRow As Integer = 24 ''Added 4/05/2022 td
    Private Const mc_boolKeepUILookingClean As Boolean = True ''Moved to module-level 5/30/2022

    ''Added 4/29/2022 td
    Private mod_intEmphasisRowIndex_Start As Integer = -1 ''= par_intRowIndex_Start
    Private mod_intEmphasisRowIndex_End As Integer = -1 ''= par_intRowIndex_End

    ''Added 4/30/2022 td
    ''April 30, 2022 ''Private mod_dictionaryFieldsToColumnIndex As New Dictionary(Of EnumCIBFields, Integer)
    Private m_dictionary1FC_FieldsToRSCColumn As New Dictionary(Of EnumCIBFields, RSCFieldColumnV2)
    Private m_dictionary2CF_ColumnToEnumField As New Dictionary(Of RSCFieldColumnV2, EnumCIBFields)


    Public Function RSCFieldColumn_Leftmost() As RSCFieldColumnV2
        ''Added 3/31/2022 td
        Return RscFieldColumn1
    End Function

    Public Function ListOfColumns() As List(Of RSCFieldColumnV2)

        ''Added 3/21/2022 thomas downes
        ''\\---Return New List(Of RSCFieldColumn)(mod_array_RSCColumns)
        Dim oList As List(Of RSCFieldColumnV2)
        oList = New List(Of RSCFieldColumnV2)(mod_array_RSCColumns)
        oList.Remove(Nothing) ''Item #0 is Nothing, so let's omit the Null reference. 
        Return oList

    End Function ''End of ""Public Function ListOfColumns() As List(Of RSCFieldColumn)""


    Public Shared Function GetRSCSpreadsheet(par_designer As ClassDesigner,
                                       par_formParent As Form,
                                      par_nameOfControl As String) As RSCFieldSpreadsheet
        ''
        ''Added 3/21/2022 td
        ''
        Dim objParametersGetElementCtl As ClassGetElementControlParams
        objParametersGetElementCtl = par_designer.GetParametersToGetElementControl()

        ''Added 5/30/2022 td
        Dim objElementForSpreadsheet As New ciBadgeElements.ClassElementBase
        objParametersGetElementCtl.ElementObject = objElementForSpreadsheet

        Return GetRSCSpreadsheet(objParametersGetElementCtl, par_formParent, par_nameOfControl,
                                    par_designer, False,
                                    CType(par_designer.ControlLastTouched, ILastControlTouched),
                                    CType(par_designer, IRecordElementLastTouched),
                                    par_designer.GroupMoveEvents)

    End Function ''End of "Public Shared Function GetRSCSpreadsheet"

    Public Shared Function GetRSCSpreadsheet(par_parametersGetElementControl As ClassGetElementControlParams,
                                       par_formParent As Form,
                                      par_nameOfControl As String,
                                      par_iLayoutFun As ILayoutFunctions,
                                      par_bProportionSizing As Boolean,
                                      par_iControlLastTouched As ILastControlTouched,
                                     par_iRecordLastControl As IRecordElementLastTouched,
                                     par_oMoveEventsForGroupedCtls As GroupMoveEvents_Singleton) _
                                     As RSCFieldSpreadsheet
        ''
        ''Added 3/20/2022 td
        ''
        ''Unused. Jan17 2022''Const c_enumElemType As EnumElementType = EnumElementType.Portrait
        Const bAddFunctionalitySooner As Boolean = False
        Const bAddFunctionalityLater As Boolean = True

        Dim typeOps As Type
        Dim objOperations As Object ''Added 12/29/2021 td 
        Dim objOperationsFieldSheet As Operations_RSCSpreadsheet ''Modified 3/13/2022 td 
        Dim sizeElementPortrait As New Size() ''Added 1/26/2022 td

        ''Added 1/5/2022 td
        ''If (par_field Is Nothing) Then Throw New Exception("The Field is missing!")

        ''Instantiate the Operations Object. 
        ''
        objOperationsFieldSheet = New Operations_RSCSpreadsheet() ''Added 3/20/2022 td
        typeOps = objOperationsFieldSheet.GetType()
        objOperations = objOperationsFieldSheet

        If (objOperations Is Nothing) Then
            ''Added 12/29/2021
            Throw New Exception("Ops is Nothing, so I guess Element Type is Undetermined.")
        End If ''end of "If (objOperations Is Nothing) Then"

        ''Added 12/2/2022 td
        Dim enumElementType_Enum As EnumElementType = EnumElementType.RSCSheetSpreadsheet ''March 23 2022''.FieldSheetSpreadsheet

        ''Create the control. 
        Dim CtlFieldSheet1 = New RSCFieldSpreadsheet(par_parametersGetElementControl,
                                                     par_formParent,
                                        par_iLayoutFun,
                                        par_parametersGetElementControl.iRefreshPreview,
                                        sizeElementPortrait,
                                        par_bProportionSizing,
                                        typeOps, objOperations,
                                        bAddFunctionalitySooner,
                                        bAddFunctionalitySooner,
                                        par_iControlLastTouched,
                                        par_oMoveEventsForGroupedCtls)
        ''Jan2 2022 ''        ''Jan2 2022 ''par_iSaveToModel, typeOps,

        With CtlFieldSheet1
            .Name = par_nameOfControl
            ''1/11/2022''If (bAddFunctionalityLater) Then .AddMoveability(par_oMoveEvents, par_iLayoutFun)
            ''03/20/2022 ''If (bAddFunctionalityLater) Then .AddMoveability(par_iLayoutFun,
            ''                               par_oMoveEventsForGroupedCtls, Nothing)
            If (bAddFunctionalityLater) Then .AddClickability()

            .RightclickMouseInfo = objOperationsFieldSheet ''Added 3/5/2022 td

        End With ''eNd of "With CtlPortrait1"

        ''
        ''Specify the current element to the Operations object. 
        ''
        With objOperationsFieldSheet

            .CtlCurrentControl = CtlFieldSheet1
            .CtlCurrentElement = CtlFieldSheet1
            ''.Designer = par_oMoveEventsForGroupedCtls.
            .Designer = par_parametersGetElementControl.DesignerClass
            ''.ElementInfo_Base = Nothing ''3/9/2022 t*d*''par_elementPortrait
            .ElementsCacheManager = par_parametersGetElementControl.ElementsCacheManager
            ''Feb3 2022 td''.Element_Type = Enum_ElementType.StaticGraphic
            .Element_Type = Enum_ElementType.RSCSheetSpreadsheet ''Added 3/20/2022 thomas d.
            .EventsForMoveability_Group = Nothing ''par_oMoveEventsForGroupedCtls
            .EventsForMoveability_Single = Nothing
            ''Added 1/24/2022 thomas downes
            .LayoutFunctions = .Designer

            ''Added 3/20/2022 thomas dRRoRRwRRnRReRRsRR
            .ParentSpreadsheet = CtlFieldSheet1 ''----par_oSpreadsheet
            ''.ColumnIndex = par_intColumnIndex

        End With ''End of "With objOperationsPortrait"

        ''
        ''Return output value.
        ''
        Return CtlFieldSheet1

    End Function ''end of "Public Shared Function GetRSCSpreadsheet() As RSCFieldSpreadsheet"


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

    End Sub


    Public Sub New(par_parameters As IGetElementControlParameters,
                   par_oParentForm As Form,
                   par_iLayoutFun As ILayoutFunctions,
                   par_iRefreshPreview As IRefreshCardPreview,
                   par_iSizeDesired As Size,
                  pboolResizeProportionally As Boolean,
                   par_operationsType As Type,
                   par_operationsAny As Object,
                   pboolAddMoveability As Boolean,
                   pboolAddClickability As Boolean,
                   par_iLastTouched As ILastControlTouched,
                   par_oMoveEvents As GroupMoveEvents_Singleton)
        ''
        ''Added 3/20/2022 td
        ''
        ''May2022 MyBase.New(EnumElementType.RSCSheetSpreadsheet, Nothing,
        MyBase.New(EnumElementType.RSCSheetSpreadsheet,
                   par_parameters.ElementObject,
                   par_parameters.ElementsCache,
                   par_oParentForm,
                   pboolResizeProportionally,
                        par_iLayoutFun, par_iRefreshPreview, par_iSizeDesired,
                        par_operationsType, par_operationsAny,
                        pboolAddMoveability, pboolAddClickability,
                        par_iLastTouched, par_oMoveEvents,
                        CSng(100 / 150))
        ''          Jan2 2022'' par_iSaveToModel, par_iLayoutFun,

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ''
        ''The spreadsheet doesn't need any moveability. ---3/20/2022 thomas 
        ''
        MyBase.RemoveMoveability() ''Added 3/20/2022 td

        ''Encapsulated 12/30/2021 td
        ''New_RSCFieldSheet(par_field, par_iLayoutFun)

    End Sub


    Public Property BackColorOfColumns() As System.Drawing.Color ''Added 3/13/2022 td
        Get
            Return mod_colorOfColumnsBackColor
        End Get
        Set(value As System.Drawing.Color)
            mod_colorOfColumnsBackColor = value
        End Set
    End Property


    Public Sub PasteData_FirstTry_NotInUse(par_stringPastedData As String)
        ''
        ''Added 2/22/2022 td
        ''
        Dim boolDataIsOkay As Boolean
        Dim strWarningMessage As String = ""
        Dim intNumRowLines As Integer = 0
        Dim intNumColumns As Integer = 0

        boolDataIsOkay = ReviewPastedData_IsOkay(Clipboard.GetText(), strWarningMessage,
              intNumRowLines, intNumColumns)

        ''
        ''Not completed.  See Public Sub PasteData_SecondTry()
        ''
        System.Diagnostics.Debugger.Break()

    End Sub ''ENd of "Public Sub PasteData(par_stringPastedData As String)"


    Public Sub PasteData_SecondTry()
        ''
        ''Added 5/13/2022 thomas downes  
        ''
        Dim columnLeftHandMost As RSCFieldColumnV2 = Nothing
        Dim boolException As Boolean
        Dim exceptionRSC As Exception
        Dim bColumnHasFocus As Boolean
        Dim boolDataIsOkay As Boolean
        Dim strWarningMsg As String = ""
        Dim intNumLines As Integer
        Dim intNumColumns As Integer

        boolDataIsOkay = ReviewPastedData_IsOkay(Clipboard.GetText(), strWarningMsg,
                                                 intNumLines, intNumColumns)


        Try
            columnLeftHandMost = mod_array_RSCColumns(0)
            If (columnLeftHandMost Is Nothing) Then
                columnLeftHandMost = mod_array_RSCColumns(1)
            End If ''End of ""If (columnLeftHandMost Is Nothing) Then""

        Catch exceptionRSC
            boolException = True
        End Try

        ''---bColumnHasFocus = columnLeftHandMost.HasFocus
        Const c_bNeedsToHaveTextCaret As Boolean = False ''Added 5/13/2022
        bColumnHasFocus = columnLeftHandMost.FocusRelated_ColumnHasCellFocus(c_bNeedsToHaveTextCaret)

        If (bColumnHasFocus) Then
            ''Major data.  
            columnLeftHandMost.PasteDataFromClipboard()

        Else
            ''Modified 5/13/2022 thomas downes
            MessageBoxTD.Show_Statement("To use the Paste button, " +
                                        "please select the left-most column.",
               "(To select a column, click one of the cells inside the column.)" + vbCrLf_Deux +
               "(Alternatively, you may perform the CTRL-V operation from inside any data cell.")

        End If ''End of ""If (bColumnHasFocus) Then... Else..."

    End Sub ''End of ""Public Sub PasteData_SecondTry()""


    Public Sub ReviewForAbnormalLengthValues(Optional ByRef pboolOneOrMore As Boolean = False,
                                             Optional ByVal pboolGiveMessageIfNeeded As Boolean = False)
        ''
        ''Added 4/26/2022 td
        ''
        Dim each_RSCColumn As RSCFieldColumnV2
        Dim each_isAbnormal As Boolean

        ''
        '' Looping each column. ---4/10/2022 td
        ''
        For Each each_RSCColumn In mod_array_RSCColumns

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


    End Sub ''End of ""Public Sub ReviewForAbnormalLengthValues()""


    Public Sub MoveTextCaret_IfNeeded(par_intNewRowIndex As Integer)
        ''
        ''Added 5/13/2022 thomas downes
        ''
        Const c_bMustHaveCaret As Boolean = False ''False, since when the user clicks on the 
        ''  spreadsheet's row-header control, the Textbox in the RSCDataCell no longer
        ''  pass "True" from the function Textbox.HasFocus(). ----5/13/2022

        For Each each_RSColumn As RSCFieldColumnV2 In mod_array_RSCColumns

            If (each_RSColumn Is Nothing) Then Continue For

            If (each_RSColumn.FocusRelated_ColumnHasCellFocus(c_bMustHaveCaret)) Then

                each_RSColumn.MoveTextCaretToNewRow(par_intNewRowIndex)
                Exit For ''Leave the "For Each" loop.

            End If ''End of ""If (each_RSColumn.FocusRelated_ColumnHasCellFocus()) Then""

        Next each_RSColumn

    End Sub ''End of ""Public Sub MoveTextCaret_IfNeeded()" 


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

        For Each each_column In mod_array_RSCColumns

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


    Public Function GetRecipientByRowIndex(par_intRowIndex As Integer) As ciBadgeRecipients.ClassRecipient
        ''
        ''Added 4/14/2022 td
        ''
        ''May 20, 2022 Return RecipientsCache.ListOfRecipients(par_intRowIndex)
        With RecipientsCache.ListOfRecipients
            If (par_intRowIndex >= .Count) Then
                Return Nothing
            Else
                Return .Item(par_intRowIndex)
            End If ''End of ""If (par_intRowIndex >= .count) Then... Else...""
        End With

    End Function


    Public Function GetIndexOfColumn(par_column As RSCFieldColumnV2) As Integer
        ''
        ''Added 4/15/2022 td
        ''
        For intColIndex As Integer = 0 To (-1 + mod_array_RSCColumns.Length)

            If (mod_array_RSCColumns(intColIndex) Is par_column) Then Return intColIndex

        Next intColIndex

        Return -1

    End Function ''end of Public Function GetIndexOfColumn(par_column As RSCFieldColumnV2) As Integer


    Public Function RunChecksAtClose_Okay() As Boolean
        ''
        ''Alias function added 6/29/2022 thomas 
        ''
        Return CheckAllOkay_AtClose()

    End Function ''End of ""Public Function RunChecksAtClose_Okay() As Boolean""


    Public Function Okay_ChecksForClosing() As Boolean
        ''
        ''Alias function added 6/29/2022 thomas 
        ''
        Return CheckAllOkay_AtClose()

    End Function ''End of ""Public Function Okay_ChecksForClosing() As Boolean""


    Public Function CheckAllOkay_AtClose(Optional pboolSaveToXML As Boolean = True) As Boolean
        ''
        ''Added 6/28/2022 thomas downes  
        ''
        Dim intCountUnassigned As Integer
        Dim boolMatchesRecips As Boolean
        Dim boolOutputOkay As Boolean
        Dim objTestSpreadsheet As New RSCFieldSpreadsheet()

        ''Save to XML, if requested. 
        If (pboolSaveToXML) Then
            ''Save to XML, as requested. 
            SaveDataColumnByColumnXML()
            SaveToRecipientsCacheXML()
        End If ''Endof ""If (pboolSaveToXML) Then"" 

        intCountUnassigned = CountOfColumnsWithoutFields()
        boolMatchesRecips = Equals_RecipientListAtClose()

        boolOutputOkay = boolMatchesRecips And (0 = intCountUnassigned)

        If (boolOutputOkay) Then

            MessageBoxTD.Show_Statement("Spreadsheet data matches Recipient List.")

        ElseIf (GlobalSettings.ShowWarnings Or GlobalSettings.Debugging) Then

            MessageBoxTD.Show_Warning("Warning, spreadsheet data doesn't match Recipient List.")

        End If



    End Function ''End of "Public Function CheckAllOkay_AtClose() As Boolean"


    Public Function CountOfColumnsWithoutFields(Optional ByRef pref_intCountAllColumns As Integer = 0) As Integer
        ''
        '' Added 5/25/2022  
        ''
        Dim intCountColsAll As Integer = 0
        Dim intCountColsWithout As Integer = 0
        Dim eachRSCColumn As RSCFieldColumnV2

        For Each eachRSCColumn In mod_array_RSCColumns
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



    Public Function ReviewColumnDisplayForRelevantFields_1to1(pboolMessageUser As Boolean) As DialogResult
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
        Dim bUserWantsFieldsManager As Boolean = False ''Added 5/13/2022
        Dim output_dialogResult As DialogResult ''Added 5/13/2022 

        For Each eachRSCColumn In mod_array_RSCColumns
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
                    bUserWantsFieldsManager = bUserPressedButton

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
        If (bUserWantsFieldsManager) Then ShowFieldsManagement()

        ''Added 5/13/2022 td
        Return output_dialogResult

    End Function ''End of ""Public Sub ReviewColumnDisplayForRelevantFields()""


    Private Sub ShowFieldsManagement()
        ''
        ''Added 5/13/2022 td
        ''
        Dim form_ToShow As New DialogListBothTypeFields
        Dim dialog_result As DialogResult ''Added 3/23/2022 td

        ''Added 3/21/2022 td
        form_ToShow.ListOfFields_Standard = Me.ElementsCache_Deprecated.ListOfFields_Standard
        form_ToShow.ListOfFields_Custom = Me.ElementsCache_Deprecated.ListOfFields_Custom

        dialog_result =
           form_ToShow.ShowDialog()

        ''Added 3/23/2022 td
        If (dialog_result = DialogResult.OK) Then
            ''Added 3/23/2022 td
            Me.ElementsCache_Deprecated.SaveToXML()

            ''Added 4/13/2022 td
            ''----For Each each_colV2 As RSCFieldColumnV2 In mod_array_RSCColumns

            Load_FieldsFromCache(Me.ElementsCache_Deprecated)

            ''---Next each_colV2

        End If ''End of ""If (dialog_result = ...)"


    End Sub ''End of ""Private Sub ShowFieldsManagement()""


    Public Sub ShowRecipientsIDCard(par_objRecipient As ciBadgeRecipients.ClassRecipient)
        ''
        ''Added 5/19/2022 thomas d
        ''
        Dim objBadgeSideElementsFront As ClassBadgeSideLayoutV1
        Dim objBadgeSideElementsBackside As ClassBadgeSideLayoutV1
        Dim objBadgeSideElems As ClassBadgeSideLayoutV1
        ''May21 2022 ''Dim obj_generator As ciBadgeGenerator.ClassMakeBadge
        Dim obj_generator As ciBadgeGenerator.ClassMakeBadge2022
        Dim dialog_ToShow As DialogDisplayIDCardSides
        Dim objbadgeLayoutClass As New BadgeLayoutClass
        Dim objBadgeImageFront As Drawing.Image = Nothing
        Dim objBadgeImageBackside As Drawing.Image = Nothing

        With objbadgeLayoutClass
            dialog_ToShow = New DialogDisplayIDCardSides
            .Width_Pixels = dialog_ToShow.pictureBadgeFrontside.Width
            .Height_Pixels = dialog_ToShow.pictureBadgeFrontside.Height
        End With

        With Me.ElementsCache_Deprecated
            ''5/20/2022 objBadgeSideElementsFront = .GetAllBadgeSideLayoutElements(EnumWhichSideOfCard.EnumFrontside)
            ''5/20/2022 objBadgeSideElementsBackside = .GetAllBadgeSideLayoutElements(EnumWhichSideOfCard.EnumBackside)
            objBadgeSideElementsFront = .GetAllBadgeSideLayoutElements(EnumWhichSideOfCard.EnumFrontside, objbadgeLayoutClass)
            objBadgeSideElementsBackside = .GetAllBadgeSideLayoutElements(EnumWhichSideOfCard.EnumBackside, objbadgeLayoutClass)
        End With

        ''May21 2022 thomas downes''obj_generator = New ciBadgeGenerator.ClassMakeBadge_Corrupt
        obj_generator = New ciBadgeGenerator.ClassMakeBadge2022

        ''
        ''Major call !!
        ''
        ''
        ''Step #1 of 2. Frontside of the card.  
        ''
        objBadgeSideElems = objBadgeSideElementsFront

        ''Aded 5/20/2022 thomas downes
        If (objBadgeSideElems.BackgroundImage Is Nothing) Then
            ''Aded 5/20/2022 thomas downes
            MessageBoxTD.Show_Statement("Problem loading the background image. (Front of card)")
            ''May20 2022 ''Exit Sub
        End If ''End of ""If (objBadgeSideElems.BackgroundImage Is Nothing) Then"

        ''
        ''Mahor call!!  
        ''
        objBadgeImageFront = obj_generator.MakeBadgeImage_AnySide(objbadgeLayoutClass,
                        objBadgeSideElems, Me.ElementsCache_Deprecated,
                        dialog_ToShow.pictureBadgeFrontside.Width,
                        dialog_ToShow.pictureBadgeFrontside.Height,
                        par_objRecipient,
                        Nothing, Nothing, Nothing, Nothing, Nothing)

        ''
        ''Step #2 of 2. Backside of the card.  
        ''
        Dim boolBacksideExists As Boolean ''Added 5/20/2022 td 
        boolBacksideExists = Me.ElementsCache_Deprecated.BadgeHasTwoSidesOfCard

        If (boolBacksideExists) Then

            objBadgeSideElems = objBadgeSideElementsBackside

            ''Aded 5/20/2022 thomas downes
            If (objBadgeSideElems.BackgroundImage Is Nothing) Then
                ''Aded 5/20/2022 thomas downes
                MessageBoxTD.Show_Statement("Problem loading the background image.  (Backside of card)")
                ''May20 2022 ''Exit Sub
            End If ''End of ""If (objBadgeSideElems.BackgroundImage Is Nothing) Then"

            ''
            ''Major call !! 
            ''
            objBadgeImageBackside = obj_generator.MakeBadgeImage_AnySide(objbadgeLayoutClass,
                            objBadgeSideElems, Me.ElementsCache_Deprecated,
                            dialog_ToShow.pictureBadgeFrontside.Width,
                            dialog_ToShow.pictureBadgeFrontside.Height,
                            par_objRecipient,
                            Nothing, Nothing, Nothing, Nothing, Nothing)

        End If ''End of ""If (boolBacksideExists) Then""

        ''Added 1/23/2022 td
        If (Not String.IsNullOrEmpty(obj_generator.Messages)) Then
            ''Added 1/23/2022 td
            MessageBoxTD.Show_Statement(obj_generator.Messages)
        End If ''End of "If (boolGeneratorMessageExists) Then"

        ''Added 5/19/2022
        dialog_ToShow.BadgeImage_FrontSide = objBadgeImageFront
        dialog_ToShow.BadgeImage_BackSide = objBadgeImageBackside
        dialog_ToShow.ShowDialog()


    End Sub ''End of ""Public Sub ShowRecipientsIDCard""


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

        list_fieldsRelevant = Me.ElementsCache_Deprecated.ListOfFields_AnyRelevent()
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


    Private Function ReviewPastedData_IsOkay(par_stringPastedData As String,
                                             ByRef pref_message As String,
                                             ByRef pref_numLines As Integer,
                                             ByRef pref_numColumns As Integer) As Boolean
        ''
        ''Added 2/22/2022 Thomas Downes  
        ''
        Dim boolOneMoreLines As Boolean
        Dim intNumberOfColumns As Integer
        Dim intNumberOfColumns_Prior As Integer
        Dim boolOneOrMoreColumns As Boolean
        Dim array_rowsPasted As String()
        Dim array_values As String()
        Dim boolMismatchedColumnCount As Boolean
        Dim intRowIndex As Integer

        par_stringPastedData = "" ''Added 2/22/2022 

        ''Added 2/22/2022 thomas downes   
        If (String.IsNullOrEmpty(par_stringPastedData)) Then
            ''Messaging 
            pref_message = "Pasted data is null or zero-length string."
            Return False
        End If ''End of "If (String.IsNullOrEmpty(par_stringPastedData)) Then"

        array_rowsPasted = par_stringPastedData.Split(New String() {vbCrLf, vbCr, vbLf}, StringSplitOptions.None)

        ''
        ''Iterate through the rows of pasted data. 
        ''
        For Each each_row As String In array_rowsPasted

            intRowIndex += 1
            array_values = each_row.Split(New String() {vbTab}, StringSplitOptions.None)
            intNumberOfColumns = array_values.Count()
            If (intNumberOfColumns_Prior > 0) Then
                If (intNumberOfColumns <> intNumberOfColumns_Prior) Then
                    boolMismatchedColumnCount = True
                    pref_message = String.Format("Irregular data set. The number of columns goes from {0} to {1}, in row {2} of {3}.",
                             intNumberOfColumns_Prior, intNumberOfColumns,
                             intRowIndex, array_rowsPasted.Count())
                    Exit For
                End If ''end of "If (intNumberOfColumns <> intNumberOfColumns_Prior) Then"
            End If ''end of "If (intNumberOfColumns_Prior > 0) Then"
            intNumberOfColumns_Prior = intNumberOfColumns
        Next each_row

        pref_numColumns = CInt(IIf(boolMismatchedColumnCount, -1, intNumberOfColumns))
        pref_numLines = array_rowsPasted.Count
        Return (Not boolMismatchedColumnCount)

    End Function ''End of "Private Function ReviewPastedData_IsOkay()"


    Public Function GetNextColumn_RightOf(par_column As RSCFieldColumnV2) As RSCFieldColumnV2
        ''
        ''Added 4/12/2022 thomas downes
        ''
        Dim each_column As RSCFieldColumnV2
        Dim boolMatches As Boolean
        Dim boolMatches_Prior As Boolean

        For Each each_column In mod_array_RSCColumns

            boolMatches = (each_column Is par_column)
            If (boolMatches_Prior) Then Return each_column
            ''Prepare for the next iteration. 
            boolMatches_Prior = boolMatches

        Next each_column

        Return Nothing

    End Function ''End of ""Public Function GetNextColumn_RightOf(....)""


    Public Function GetNextColumn_LeftOf(par_column As RSCFieldColumnV2) As RSCFieldColumnV2
        ''
        ''Added 4/12/2022 thomas downes
        ''
        Dim each_column As RSCFieldColumnV2
        Dim prior_column As RSCFieldColumnV2 = Nothing
        Dim boolMatches As Boolean
        Dim boolMatches_Prior As Boolean

        For Each each_column In mod_array_RSCColumns

            boolMatches = (each_column Is par_column)
            If (boolMatches) Then Return prior_column

            ''
            ''Prepare for the next iteration.
            ''
            prior_column = each_column
            boolMatches_Prior = boolMatches

        Next each_column

        Return Nothing

    End Function ''End of ""Public Function GetNextColumn_RightOf(....)""


    Public Function GetFirstColumn() As RSCFieldColumnV2
        ''
        ''Added 4/12/2022 thomas downes
        ''
        If (0 = mod_array_RSCColumns.Length) Then Return Nothing
        If (mod_array_RSCColumns(0) Is Nothing) Then Return mod_array_RSCColumns(1)
        Return mod_array_RSCColumns(0)

    End Function ''End of ""Public Function GetNextColumn_RightOf(....)""


    Public Function GetRowHeaderByRowIndex(par_intRowIndex As Integer) As RSCRowHeader

        ''Added 5/13/2002 
        Dim objRowHeader As RSCRowHeader

        objRowHeader =
        RscRowHeaders1.GetRowHeaderByRowIndex(par_intRowIndex)

        Return objRowHeader

    End Function ''Endof ""Public Function GetRowHeaderByRowIndex""


    Private Sub RSCFieldSpreadsheet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 3/10/2022 
        ''



    End Sub ''End of event handler Private Sub RSCFieldSpreadsheet_Load

    Public Sub Load_Form()
        ''
        ''Encapsulated 3/15/2022 & 3/10/2022 
        ''
        Const c_boolLetsAutoLoadColumns As Boolean = False ''False, as it may cause weird design-time behavior.

        ''added 3/14/2022 td
        ''If (Me.ElementsCache_Deprecated Is Nothing) Then
        ''    ''Throw New Exception("Cache is missing")
        ''    MessageBoxTD.Show_Statement("Cache is missing")
        ''End If ''end of ""If (Me.ElementsCache_Deprecated Is Nothing) Then"'

        If (c_boolLetsAutoLoadColumns) Then
            ''
            ''We might not have a designer object at load-time.... set the parameter to Nothing. 
            ''
            Dim objDesigner As ClassDesigner = Nothing
            objDesigner = Me.Designer  ''Added 3/14/2022 td

            ''
            ''Major call!!
            ''
            LoadRuntimeColumns_AfterClearingDesign(objDesigner)

        End If ''End of " If (c_boolLetsAutoLoadColumns) Then"

        ''
        ''Added 3/28/'2022 thomas downes 
        ''
        Load_Recipients()

        ''
        ''Added 4/11/2022 td
        ''
        Dim intTopOfGrid As Integer
        intTopOfGrid = (RscFieldColumn1.Top + RscFieldColumn1.GetFirstRSCDataCell().Top)
        RscRowHeaders1.Top = intTopOfGrid

    End Sub ''End of event handler Private Sub RSCFieldSpreadsheet_Load


    Public Sub Load_Recipients()
        ''
        ''Added 3/28/'2022 thomas downes 
        ''
        If (Me.RecipientsCache Is Nothing) Then

            ''Added 3/29/2022 thomas d.
            MessageBoxTD.Show_Statement("Not any recipients cache.")

        Else
            ''
            ''Added 3/28/2022 thomas downes
            ''
            Dim bAreData_DangerOfOverwritten As Boolean
            Dim bColumnHasNoField As Boolean
            Dim bListHasNoRecipients As Boolean
            Dim list_columns As List(Of RSCFieldColumnV2)
            Dim intNumberOfRecipients As Integer ''Added 4/5/2022

            list_columns = ListOfColumns() ''Added 3/30/2022 thomas d. 

            ''Added 4/5/2022 td
            ''
            ''Create row headers. 
            ''
            intNumberOfRecipients = Me.RecipientsCache.ListOfRecipients.Count
            RscRowHeaders1.Load_EmptyRows(intNumberOfRecipients)
            ''Moved below. 4/6/2022 ''RscRowHeaders1.RefreshHeightOfHeaders(intNumberOfRecipients) ''Added 4/6/2022 td

            ''
            ''Load the data into the RSCRowHeaders control.---5/14/2022
            ''
            RscRowHeaders1.ListRecipients = Me.RecipientsCache.ListOfRecipients
            RscRowHeaders1.LoadRecipientList(bListHasNoRecipients)

            ''
            ''Fill each of the columns. 
            ''
            For Each each_column As RSCFieldColumnV2 In list_columns ''March30 2022 td''Me.ListOfColumns()

                ''Added 3/29/2022 thomas d.
                ''
                ''Clear out the existing data from the column.
                ''
                ''March29 2022 td''If (each_column.CountOfBoxesWithData() > 0) Then
                bAreData_DangerOfOverwritten = (0 < each_column.CountOfBoxesWithData())
                If (bAreData_DangerOfOverwritten) Then
                    ''3/29/2022 td''each_column.ClearDataFromColumn_Do()
                    Dim bUserCancelled As Boolean ''March29 2022
                    ''April 1, 2022 td'' Me.ClearDataFromSpreadsheet_1stConfirm(bUserCancelled)
                    ''April 15, 2022''Me.ClearDataFromSpreadsheet_NoConfirm() '' (bUserCancelled)
                    ''April 15, 2022''Threading.Thread.Sleep(500)
                    Application.DoEvents()
                    If (bUserCancelled) Then Exit Sub
                End If ''End of ""If (bAreData_DangerOfOverwritten) Then""

                ''Add an needed object reference. ----3/29/2022 thomas d.
                each_column.ListRecipients = Me.RecipientsCache.ListOfRecipients

                bAreData_DangerOfOverwritten = False ''Reinitialize.

                ''Added 3/28/2022 thomas d.
                ''
                ''Load the data into the column.
                ''
                each_column.LoadRecipientList(bAreData_DangerOfOverwritten,
                                              bColumnHasNoField, bListHasNoRecipients)

                If (bAreData_DangerOfOverwritten) Then
                    Exit For
                End If

                If (bColumnHasNoField) Then
                    Continue For
                End If

                If (bListHasNoRecipients) Then
                    Exit For
                End If

            Next each_column


            ''Added 4/6/2022 thomas downes
            RscRowHeaders1.RefreshHeightOfHeaders(intNumberOfRecipients) ''Added 4/6/2022 td

            ''
            ''Ensure the needed # of RSCDataCells are present across all columns.----4/15/2022
            ''
            Load_EmptyRowsToAllNewColumns()
            ''Dim intEachRowCount As Integer = 1
            ''Dim intMaxRowCount As Integer = 1
            ''For Each each_column As RSCFieldColumnV2 In list_columns ''March30 2022 td''Me.ListOfColumns()
            ''    intEachRowCount = each_column.CountOfRows()
            ''    If (intEachRowCount > intMaxRowCount) Then intMaxRowCount = intEachRowCount
            ''Next each_column

            ''For Each each_column As RSCFieldColumnV2 In list_columns ''March30 2022 td''Me.ListOfColumns()
            ''    each_column.Load_EmptyRows(intMaxRowCount)
            ''Next each_column


        End If ''End of ""If (Me.RecipientsCache Is Nothing) Then.... Else....""


    End Sub ''End of event handler Private Sub RSCFieldSpreadsheet_Load


    Public Sub Load_EmptyRowsToAllNewColumns()
        ''
        ''Added 4/15/2022 td
        ''
        Dim intEachRowCount As Integer = 1
        Dim intMaxRowCount As Integer = 1
        Dim list_columns As List(Of RSCFieldColumnV2)
        Dim boolMissingRows As Boolean

        list_columns = ListOfColumns()

        For Each each_column As RSCFieldColumnV2 In list_columns ''March30 2022 td''Me.ListOfColumns()
            intEachRowCount = each_column.CountOfRows()
            If (intEachRowCount > intMaxRowCount) Then intMaxRowCount = intEachRowCount
        Next each_column

        For Each each_column As RSCFieldColumnV2 In list_columns ''March30 2022 td''Me.ListOfColumns()
            boolMissingRows = (each_column.CountOfRows() < intMaxRowCount)
            If (boolMissingRows) Then
                each_column.Load_EmptyRows(intMaxRowCount)
            End If ''End of ""If (boolMissingRows) Then""
        Next each_column

    End Sub ''End of ""Public Sub Load_EmptyRowsToAllNewColumns()""


    Public Sub ClearBorderStyle_PriorCell(par_objNextCell As RSCDataCell)
        ''Added 4/28/2022 td
        Static s_objPriorCell As RSCDataCell
        If (s_objPriorCell IsNot Nothing) Then
            If (s_objPriorCell IsNot par_objNextCell) Then
                s_objPriorCell.BorderStyle_Textbox = BorderStyle.None
                ''Added 4/29/2022 thomas downes
                SetBackColor_ToRowDefault(s_objPriorCell)

            End If ''End of ""If (s_objPriorCell IsNot par_objNextCell) Then""
        End If ''End of ""If (s_objPriorCell IsNot Nothing) Then""

        ''Prepare for next calling to this procedure.
        If (s_objPriorCell Is Nothing) Then
            s_objPriorCell = par_objNextCell
        ElseIf (s_objPriorCell IsNot par_objNextCell) Then
            ''Only assign the object reference if it's different than the existing reference.
            s_objPriorCell = par_objNextCell
        End If ''End of ""If (s_objPriorCell IsNot par_objNextCell) Then""

    End Sub ''End of ""Public Sub ClearBorderStyle_PriorCellaaa(par_objNextCell As RSCDataCell)""


    Public Sub SetBackColor_ToRowDefault(par_objDataCell As RSCDataCell,
                         Optional pboolCheckForEmphasis As Boolean = True)
        ''
        ''Added 4/29/2022 td
        ''
        Dim intRowEmphasis_Start As Integer
        Dim intRowEmphasis_End As Integer
        Dim intRowOfDataCell As Integer

        If (pboolCheckForEmphasis) Then

            intRowEmphasis_Start = mod_intEmphasisRowIndex_Start
            intRowEmphasis_End = mod_intEmphasisRowIndex_End

            For Each each_column As RSCFieldColumnV2 In mod_array_RSCColumns
                If (each_column Is Nothing) Then Continue For
                intRowOfDataCell = -1
                intRowOfDataCell = each_column.GetRowIndexOfCell(par_objDataCell)
                If (intRowOfDataCell > 0) Then Exit For
            Next each_column

            Dim boolRowHasEmphasis As Boolean

            If (intRowEmphasis_Start > 0 And intRowOfDataCell > 0) Then
                ''Check that the Data-Cell Row is within the range of emphasis.
                If (intRowEmphasis_End = -1) Then intRowEmphasis_End = intRowEmphasis_Start
                boolRowHasEmphasis = (intRowEmphasis_Start <= intRowOfDataCell) And
                                 (intRowOfDataCell <= intRowEmphasis_End)
            End If ''End of ""If (intRowEmphasis_Start > 0) Then""

            If (boolRowHasEmphasis) Then

                ''--par_objDataCell.BackColor = RSCDataCell.BackColorWithEmphasis
                par_objDataCell.BackColor = RSCDataCell.Backcolor_WithEmphasisOnRow

            Else
                par_objDataCell.BackColor = RSCDataCell.Backcolor_NoEmphasis

            End If ''End of ""If (boolRowHasEmphasis) Then... Else...""

        Else
            par_objDataCell.BackColor = RSCDataCell.Backcolor_NoEmphasis

        End If ''End of ""If (pboolCheckForEmphasis) Then ... Else ...."

    End Sub ''Endof ""Public Sub SetBackColor_ToRowDefault(par_objDataCell As RSCDataCell)""


    Public Sub ClearDataFromSpreadsheet_1stConfirm(Optional ByRef pboolUserCancelled As Boolean = False)
        ''
        ''Added 3/29/2022 thomas downes
        ''
        Dim objRSCFieldColumn As RSCFieldColumnV2
        Dim boolConfirmed As Boolean

        boolConfirmed = (MessageBoxTD.Show_Confirmed("Clear all data from this spreadsheet?",
                          "(To undo this later, right-click & select Undo Clear Data.)", True))

        If (boolConfirmed) Then
            ''Confirmed, so clear the data from each column.  
            For Each each_column As RSCFieldColumnV2 In Me.ListOfColumns
                objRSCFieldColumn = each_column ''---CType(each_column, RSCFieldColumn)
                objRSCFieldColumn.ClearDataFromColumn_Do()
            Next each_column
        Else
            ''Added 3/29/2022 td
            pboolUserCancelled = True

        End If ''End of "If (boolConfirmed) Then"

    End Sub ''End of ""Public Sub ClearDataFromSpreadsheet_1stConfirm()""


    Public Sub ClearDataFromSpreadsheet_NoConfirm()
        ''
        ''Added 4/01/2022 thomas downes
        ''
        Dim objRSCFieldColumn As RSCFieldColumnV2
        Dim boolConfirmed As Boolean

        For Each each_column As RSCFieldColumnV2 In Me.ListOfColumns
            objRSCFieldColumn = each_column ''---CType(each_column, RSCFieldColumn)
            objRSCFieldColumn.ClearDataFromColumn_Do()
        Next each_column

    End Sub ''End of ""Public Sub ClearDataFromSpreadsheet_NoConfirm()""


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

    End Sub


    Public Sub LoadRuntimeColumns_AfterClearingDesign(par_designer As ClassDesigner)
        ''
        ''Added 3/8/2022 thomas downes 
        ''
        Dim intSavePropertyTop_RSCColumnCtl As Integer
        Dim intSavePropertyTop_FirstRow As Integer ''Added 3/24/2022 td

        intSavePropertyTop_RSCColumnCtl = RscFieldColumn1.Top
        ''4/9/2022 td''intSavePropertyTop_FirstRow = RscFieldColumn1.GetFirstTextboxPropertyTop()
        intSavePropertyTop_FirstRow = RscFieldColumn1.GetFirstRSCDataCellPropertyTop()

        ''Step 1a of 5.  Remove design-time columns..... Clearing (removing) design-time columns (which are placed
        ''   to give a visual preview of how the run-time columns will look). 
        ''
        RemoveRSCColumnsFromDesignTime()

        ''Added 3/15/2022 td
        If (Me.ElementsCache_Deprecated Is Nothing) Then
            ''Throw New Exception("Cache is missing")
            MessageBoxTD.Show_Statement("Cache is missing")
        End If ''end of ""If (Me.ElementsCache_Deprecated Is Nothing) Then"'

        ''Added 3/15/2022 td
        If (Me.ColumnDataCache Is Nothing) Then
            ''Throw New Exception("Cache is missing")
            MessageBoxTD.Show_Statement("Cache is missing")
        End If ''end of ""If (Me.ElementsCache_Deprecated Is Nothing) Then"'

        ''
        ''Step 1b of 5.  Load run-time row-header control (RSCRowHeaders1). ----3/24/2022 
        ''
        ''   Step 1b(1):  Remove design-time control
        ''   Step 1b(2):  Load run-time control
        ''
        ''Step 1b(1):  Remove design-time control
        RscRowHeaders1.Visible = False ''Hardly matters, but go ahead. 
        Me.Controls.Remove(RscRowHeaders1)

        ''Step 1b(2):  Load run-time control
        Dim intCurrentPropertyLeft As Integer = 0
        Dim intNextPropertyLeft As Integer = 0
        RscRowHeaders1 = RSCRowHeaders.GetRSCRowHeaders(Me.Designer, Me.ParentForm,
             "RscRowHeaders1", Me)
        Me.Controls.Add(RscRowHeaders1)
        RscRowHeaders1.Visible = True
        RscRowHeaders1.Top = (intSavePropertyTop_RSCColumnCtl + intSavePropertyTop_FirstRow - 2)
        RscRowHeaders1.Left = (intCurrentPropertyLeft)
        ''---RscRowHeaders1.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right), AnchorStyles)
        intNextPropertyLeft += (RscRowHeaders1.Width + mc_ColumnMarginGap)
        ''Assigned within the loop below.--3/24/2022 td''intCurrentPropertyLeft = intNextPropertyLeft
        RscRowHeaders1.PixelsFromRowToRow = mc_intPixelsFromRowToRow ''Added 4/5/2022
        RscRowHeaders1.ParentRSCSpreadsheet = Me ''Added 4/29/2022 thomas  

        ''
        ''Step 2 of 5.  Load run- time columns. 
        ''
        ''Step 2a of 5.  Create a local array for storing indexed columns. 
        ''
        ''Added a Number N of Required Columns. 
        ''
        Dim intNeededIndex As Integer = 1
        Dim each_Column As RSCFieldColumnV2
        Dim priorColumn As RSCFieldColumnV2 = Nothing
        Dim intNeededMax As Integer = 4

        ''Added 3/16/2022 td
        If (0 = Me.ColumnDataCache.ListOfColumns.Count) Then
            ''Added 3/16/2022 td
            Me.ColumnDataCache.AddColumns(intNeededMax)
        Else
            intNeededMax = Me.ColumnDataCache.ListOfColumns.Count
        End If ''End of "If (0 = Me.ColumnDataCache.ListOfColumns.Count) Then ... Else ..."

        ''---Dim mod_array_RSCColumns As RSCFieldColumn()
        If (intNeededMax > 1) Then ''Added 5/30/2022
            ''added 5/30/2022 & 5/13/2022
            If mc_boolKeepUILookingClean Then
                ''Hide the buttons which formerly occupied the blank area
                '' of the spreadsheet. ---5/13/2022 
                ButtonAddColumns2.Visible = False
                ButtonPasteData2.Visible = False
            End If ''End of ""If c_boolKeepUILookingClean Then""
        End If ''End of ""If (intNeededMax > 1) Then""


        ''The number passed to ReDim Preserve is the upper bound of the array, 
        ''  not the length. ---4/15/2022
        ''
        ReDim mod_array_RSCColumns(intNeededMax)
        Dim each_field As ciBadgeFields.ClassFieldAny

        ''
        ''Step 2b of 5.  Generate columns (type: RSCFieldColumn).
        ''
        Const c_bUseEncapsulation As Boolean = True ''Added 3/20/2022 td

        For intNeededIndex = 1 To intNeededMax

            If (c_bUseEncapsulation) Then
                ''
                ''Encapsulated 3/20/2022 td
                ''
                intCurrentPropertyLeft = intNextPropertyLeft ''Check prior iteration.
                ''
                ''Major call!!
                ''
                each_Column = GenerateRSCFieldColumn_General(intNeededIndex,
                                                            intCurrentPropertyLeft,
                                                            intNextPropertyLeft,
                                                            priorColumn)

                ''Added 3/25/2022 td 
                If (intNeededIndex = 1) Then RscFieldColumn1 = each_Column

                ''Prepare for next iteration.
                priorColumn = each_Column

            Else
                ''
                ''Original unencapsulated code. 
                ''
                each_field = New ciBadgeFields.ClassFieldAny()
                ''each_field.FieldEnumValue = ciBadgeInterfaces.EnumCIBFields.Undetermined
                each_field.FieldEnumValue = Me.ColumnDataCache.ListOfColumns(-1 + intNeededMax).CIBField

                ''3/20/2022 td''eachColumn = GenerateRSCFieldColumn(each_field, intNeededIndex)
                each_Column = GenerateRSCFieldColumn_Special(each_field, intNeededIndex)
                intCurrentPropertyLeft = intNextPropertyLeft ''Check prior iteration.
                each_Column.Left = intCurrentPropertyLeft
                each_Column.Visible = True
                ''Prepare for next iteration. 
                ''----intNextPropertyLeft = (eachColumn.Left + eachColumn.Width + 3)
                intNextPropertyLeft = (each_Column.Left + each_Column.Width + mc_ColumnMarginGap)
                Me.Controls.Add(each_Column)
                ''Added 3/12/2022 thomas downes 
                mod_array_RSCColumns(intNeededIndex) = each_Column

                ''Added 3/16/2022 td
                ''  Redundant, assigned in Step 4 below.
                ''Oops....3/18/2022 ''eachColumn.ColumnWidthAndData = Me.ColumnDataCache.ListOfColumns(-1 + intNeededMax)
                each_Column.ElementsCache_Deprecated = Me.ElementsCache_Deprecated
                each_Column.ColumnWidthAndData = Me.ColumnDataCache.ListOfColumns(-1 + intNeededIndex)
                ''Added 4/11/2022 thomas d.
                each_Column.ParentSpreadsheet = Me

                ''Test for uniqueness. 
                Dim bUnexpectedMatch As Boolean
                If (priorColumn IsNot Nothing) Then
                    bUnexpectedMatch = (each_Column.ColumnWidthAndData Is
                        priorColumn.ColumnWidthAndData)
                    If (bUnexpectedMatch) Then Throw New Exception
                End If ''ENd of "If (priorColumn IsNot Nothing) Then"

            End If ''End of "I
            ''
            ''f (c_bUseEncapsulation) Then .... Else ...."

            ''
            ''Prepare for next iteration. 
            ''
            priorColumn = each_Column

        Next intNeededIndex

        ''
        ''Step 3 of 5.  Link the columns together.  
        ''
        Dim listColumnsRight = New List(Of RSCFieldColumnV2)
        Dim each_list As List(Of RSCFieldColumnV2)
        Dim prior_list As List(Of RSCFieldColumnV2)
        Dim bNotTheRightmostColumn As Boolean

        For intNeededIndex = intNeededMax To 1 Step -1 ''Going backward, i.e. decrementing the index,
            '' i.e. going from right to left (vs. the standard of going left to right).  
            ''     ---3/12/20022 td

            each_Column = mod_array_RSCColumns(intNeededIndex)
            ''Moved below. 3/13/2022 td''listColumnsRight.Add(eachColumn)

            ''Let's initialize the list "each_list" with the list "listColumnsRight"
            ''   because  we want "each_list" to be a partial listing of the columns.
            ''   By "a partial listing", I mean only those columns which are on the //right-hand//
            ''   side of column #intNeededIndex.      ---3/12/20022 td
            ''   
            each_list = New List(Of RSCFieldColumnV2)(listColumnsRight) ''Basically, a copy of listColumnsRight.

            ''Added 3/12/2022 thomas d. 
            bNotTheRightmostColumn = (intNeededIndex < intNeededMax)
            If (bNotTheRightmostColumn) Then

                If (each_list.Contains(each_Column)) Then Throw New Exception("self-referential")
                each_Column.ListOfColumnsToBumpRight = each_list

            End If ''End of "If (bNotTheRightmostColumn) Then"

            ''Prepare for next iteration.
            prior_list = each_list
            listColumnsRight.Add(each_Column)

        Next intNeededIndex

        ''
        ''Step 4 of 5.  Load the list of editable fields.  
        ''
        ''4/13/2022 td ''Dim each_columnWidthEtc As ciBadgeDesigner.ClassColumnWidthAndData
        Dim each_columnWidthEtc As ciBadgeCachePersonality.ClassRSCColumnWidthAndData
        For intNeededIndex = 1 To intNeededMax

            each_Column = mod_array_RSCColumns(intNeededIndex)
            ''Moved below. 3/16/2022 td''eachColumn.Load_FieldsFromCache(Me.ElementsCache_Deprecated)
            ''Added 3/15/2022 td
            ''  This may not be needed.  See eachColumn.ColumnWidthAndData.
            each_Column.ColumnDataCache = Me.ColumnDataCache ''Added 3/15/2022 td
            ''Added 3/15/2022 td
            ''  Tell the column what width, field & field values to display.
            each_columnWidthEtc = Me.ColumnDataCache.ListOfColumns(intNeededIndex - 1)
            each_Column.ColumnWidthAndData = each_columnWidthEtc
            each_Column.Top = intSavePropertyTop_RSCColumnCtl ''Added 3/21/2022
            each_Column.BackColor = RscRowHeaders1.BackColor ''Added 4/11/2022 td

            ''
            ''Ensure the needed # of RSCDataCells are present.----4/15/2022
            ''
            each_Column.Load_EmptyRows(RscFieldColumn1.CountOfRows())

            ''
            ''Major call!
            ''
            each_Column.ParentSpreadsheet = Me ''Added 4/11/2022 thomas d. 
            each_Column.Load_FieldsFromCache(Me.ElementsCache_Deprecated)

            ''
            ''Load the data which is saved in the Column-Widths-and-Data cache.  
            ''    -----4/15/2022 td
            ''
            each_Column.Load_ColumnListDataToColumnEtc()


        Next intNeededIndex

        ''
        ''Step 5 of 5.  Adjust the .Left property of the columns, to accomodate
        ''   the width of the columns determined by the user's resizing behavior
        ''   in the prior session.  
        ''
        For intNeededIndex = 2 To intNeededMax

            priorColumn = mod_array_RSCColumns(intNeededIndex - 1)
            each_Column = mod_array_RSCColumns(intNeededIndex)

            each_Column.Left = (priorColumn.Left + priorColumn.Width + 4)

        Next intNeededIndex

        ''
        ''Step 6 of 6.  Resize the form itself. 
        ''
        If (Me.ColumnDataCache.FormSize.Width > mc_ColumnWidthDefault) Then
            ''
            ''Resize the form based on the save form size.
            ''
            Me.ParentForm_DesignerDialog.Size = Me.ColumnDataCache.FormSize

        End If ''end of ""If Me.ColumnDataCache.FormSize.Width > 100 Then""

        ''
        ''Step 7 of 7.  Align the row headers.
        ''
        ''Might be causing call-stack problems.''RscRowHeaders1.RSCSpreadsheet = Me
        ''Moved to calling function. 3/25/2022 td''RscRowHeaders1.AlignControlsWithSpreadsheet()

        ''
        ''Step 8 of 8.  Make sure that the Row Headers match the longest column of data
        ''       inside the cache collection Me.ColumnDataCache. 
        ''       ----6/22/2022 thomas d. 
        ''
        With Me.ColumnDataCache
            RscRowHeaders1.ColumnDataCache = Me.ColumnDataCache
            RscRowHeaders1.Load_ColumnListDataToColumnEtc()
        End With

    End Sub ''End of Public Sub LoadRuntimeColumns_AfterClearingDesign


    Public Sub AddToEdgeOfSpreadsheet_Row()
        ''4/2022 Public Sub AddRowToBottomOfSpreadsheet() 

        ''Added 4/30/2022 thomas downes
        ''Me.ParentSpreadsheet.AddRowToBottomOfSpreadsheet()
        Dim intRowCount As Integer
        Dim intRowCount_PlusOne As Integer
        intRowCount = RscRowHeaders1.CountOfRows()
        intRowCount_PlusOne = (intRowCount + 1)
        RscRowHeaders1.Load_OneEmptyRow_IfNeeded(intRowCount_PlusOne) ''(1 + intRowCount)
        ''Add a new textbox to each column. 
        For Each each_RSCCol As RSCFieldColumnV2 In mod_array_RSCColumns
            If (each_RSCCol Is Nothing) Then Continue For
            each_RSCCol.Load_EmptyRows(intRowCount_PlusOne)
        Next each_RSCCol

    End Sub ''End of ""Public Sub AddToEdgeOfSpreadsheet_Row()""


    Public Sub AddToEdgeOfSpreadsheet_Column()

        ''Added 4/30/2022 thomas downes
        Dim intColumnCount As Integer
        Dim intColumnCount_PlusOne As Integer

        intColumnCount = mod_array_RSCColumns.Length
        If (mod_array_RSCColumns(0) Is Nothing) Then intColumnCount -= 1
        intColumnCount_PlusOne = (1 + intColumnCount)
        InsertNewColumnByIndex(intColumnCount_PlusOne)

    End Sub ''End of ""Public Sub AddToEdgeOfSpreadsheet_Column()""


    Public Sub AlignRowHeadersWithSpreadsheet()
        ''
        ''Added 3/25/2022 thomas downes
        ''
        ''3/25/2022 td''RscRowHeaders1.AlignControlsWithSpreadsheet()
        ''4/09/2022 td''Dim listBoxesColumn As List(Of TextBox)
        Dim listBoxesColumn As List(Of RSCDataCell)
        ''4/5/2022 Dim listBoxesRowHeader As List(Of TextBox)
        ''4/6/2022 Dim listBoxesRowHeader As List(Of Label)
        Dim listBoxesRowHeader As List(Of RSCRowHeader)

        ''4/09/2022 td ''listBoxesColumn = RscFieldColumn1.ListOfTextBoxes_TopToBottom()
        listBoxesColumn = RscFieldColumn1.ListOfRSCDataCells_TopToBottom()
        listBoxesRowHeader = RscRowHeaders1.ListOfRowHeaders_TopToBottom()

        ''March25 2022''RscRowHeaders1.AlignControlsWithSpreadsheet(listBoxesColumn)
        RscRowHeaders1.AlignControlsWithSpreadsheet(RscFieldColumn1)

    End Sub ''End of "Public Sub AlignRowHeadersWithSpreadsheet()"


    Public Sub RefreshHeightOfRowHeaders()
        ''
        ''Added 4/6/2022 thomas d.
        ''
        RscRowHeaders1.RefreshHeightOfHeaders()

    End Sub ''End of "Public Sub RefreshHeightOfRowHeaders()"


    Public Sub Load_FieldsFromCache(par_cache As ClassElementsCache_Deprecated)
        ''
        ''Added 2/16/2022 thomas downes
        ''
        LoadRuntimeColumns_AfterClearingDesign(Nothing) ''mod_designer)

    End Sub ''end of sub "Public Sub Load_FieldsFromCache(par_cache As ClassElementsCache_Deprecated)"


    Public Sub EmphasizeRows_Highlight(par_intRowIndex_Start As Integer,
                     Optional par_intRowIndex_End As Integer = -1)
        ''
        ''Added 4/29/2022 td
        ''
        mod_intEmphasisRowIndex_Start = par_intRowIndex_Start
        mod_intEmphasisRowIndex_End = par_intRowIndex_End
        If (-1 = mod_intEmphasisRowIndex_End) Then
            mod_intEmphasisRowIndex_End = mod_intEmphasisRowIndex_Start
        End If

        For Each each_col As RSCFieldColumnV2 In mod_array_RSCColumns

            If (each_col Is Nothing) Then Continue For ''Added 4/29/2022 thomas d

            ''---each_col.PaintEmphasisOfRows(par_intRowIndex_Start, par_intRowIndex_End)
            each_col.EmphasizeRows_Highlight(par_intRowIndex_Start, par_intRowIndex_End)

        Next each_col


    End Sub ''End of ""Public Sub EmphasizeRows_Highlight"


    Public Sub DeemphasizeRows_NoHighlight(par_intRowIndex_Start As Integer,
                      Optional par_intRowIndex_End As Integer = -1)
        ''
        ''Added 4/29/2022 td
        ''
        For Each each_col As RSCFieldColumnV2 In mod_array_RSCColumns

            If (each_col Is Nothing) Then Continue For ''Added 4/29/2022 td 

            each_col.DeemphasizeRows_NoHighlight(par_intRowIndex_Start, par_intRowIndex_End)

        Next each_col

    End Sub ''End of ""Public Sub EmphasizeRows_Highlight"


    Public Function HasIndentifyingData() As Boolean
        ''
        ''Added 5/14/2022 thomas downes 
        ''
        Dim each_column As RSCFieldColumnV2
        Dim bColHasIdentifyingData As Boolean

        For Each each_column In mod_array_RSCColumns

            If (each_column Is Nothing) Then Continue For

            bColHasIdentifyingData = each_column.HasIdentifyingData()
            If (bColHasIdentifyingData) Then Return True

        Next each_column

        Return False

    End Function ''End of ""Public Function HasIndentifyingData() As Boolean""


    Private Function GenerateRSCFieldColumn_General(p_intIndexCurrent As Integer,
                                                    p_intCurrentPropertyLeft As Integer,
                                                    ByRef pref_intNextPropertyLeft As Integer,
                                                    p_priorColumn As RSCFieldColumnV2) As RSCFieldColumnV2
        ''
        '' Added 3/20/2022 td
        ''
        Dim newRSCColumn_output As RSCFieldColumnV2
        Dim dataOfColumn As ClassRSCColumnWidthAndData ''Added 4/14/2022
        Dim fieldForNewColumn As ciBadgeFields.ClassFieldAny

        fieldForNewColumn = New ciBadgeFields.ClassFieldAny()
        ''each_field.FieldEnumValue = ciBadgeInterfaces.EnumCIBFields.Undetermined

        dataOfColumn = Me.ColumnDataCache.ListOfColumns(-1 + p_intIndexCurrent)
        If (dataOfColumn IsNot Nothing) Then
            fieldForNewColumn.FieldEnumValue = dataOfColumn.CIBField
        End If ''End of ""If (dataOfColumn IsNot Nothing) Then""

        ''
        ''Major call, call the other, "..._Special" version of this column-generating function (suffixed "..._General"). 
        ''
        newRSCColumn_output = GenerateRSCFieldColumn_Special(fieldForNewColumn, p_intIndexCurrent)
        ''----intCurrentPropertyLeft = intNextPropertyLeft ''Check prior iteration.

        ''
        ''Add additional properties. 
        ''
        With newRSCColumn_output
            ''
            ''Set the properties of the newly-generated column. 
            ''
            newRSCColumn_output.Left = p_intCurrentPropertyLeft
            newRSCColumn_output.Width = mc_ColumnWidthDefault ''Added 3/20/2022 td
            newRSCColumn_output.Visible = True

            ''Added 3/30/2022 td
            ''4/4/2022 td ''newRSCColumn_output.Height = (Me.Height - mod_intRscFieldColumn1_Top - mc_ColumnMarginGap)
            .Height = newRSCColumn_output.GetRSCDataCellAtBottom_Bottom() + mc_ColumnMarginGap
            ''4/4/2022 td ''newRSCColumn_output.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Bottom), AnchorStyles)
            ''4/6/2022 td ''newRSCColumn_output.Anchor = CType((AnchorStyles.Top Or AnchorStyles.None), AnchorStyles)
            .Anchor = CType((AnchorStyles.Top Or AnchorStyles.Left), AnchorStyles)

            ''Prepare for next iteration. 
            pref_intNextPropertyLeft = (.Left + .Width + 3)
            Me.Controls.Add(newRSCColumn_output)

            ''Added 3/12/2022 thomas downes 
            mod_array_RSCColumns(p_intIndexCurrent) = newRSCColumn_output
            ''Added 3/16/2022 td
            ''  Redundant, assigned in Step 4 below.
            ''Oops....3/18/2022 ''eachColumn.ColumnWidthAndData = Me.ColumnDataCache.ListOfColumns(-1 + intNeededMax)

            .ElementsCache_Deprecated = Me.ElementsCache_Deprecated
            .ColumnWidthAndData = Me.ColumnDataCache.ListOfColumns(-1 + p_intIndexCurrent)

            ''Added 4/14/2022 td
            If (.ColumnWidthAndData Is Nothing) Then
                ''Added 4/14/2022 td
                .ColumnWidthAndData = New ClassRSCColumnWidthAndData()
                .ColumnWidthAndData.CIBField = EnumCIBFields.Undetermined
                .ColumnWidthAndData.Width = mc_ColumnWidthDefault
                .ColumnWidthAndData.ColumnData = New List(Of String)
                Me.ColumnDataCache.ListOfColumns.Add(.ColumnWidthAndData)
            End If ''End of ""If (.ColumnWidthAndData Is Nothing) Then""

            ''Added 4/5/2022
            .PixelsFromRowToRow = mc_intPixelsFromRowToRow ''Added 4/5/2022

        End With ''END OF "With newRSCColumn_output"

        ''Test for uniqueness. 
        Dim bUnexpectedPriorPropertyMatch As Boolean

        If (p_priorColumn IsNot Nothing) Then
            ''
            ''Check that the prior output's property-object differs from the current property-object. 
            ''
            bUnexpectedPriorPropertyMatch = (newRSCColumn_output.ColumnWidthAndData Is
                                             p_priorColumn.ColumnWidthAndData)
            If (bUnexpectedPriorPropertyMatch) Then Throw New Exception

        End If ''ENd of "If (p_priorColumn IsNot Nothing) Then"

        ''
        ''Added 4/14/2022 td
        ''
        Dim intRowsNeeded As Integer
        intRowsNeeded = Me.GetFirstColumn().CountOfRows()
        newRSCColumn_output.Load_EmptyRows(intRowsNeeded)

        ''Exit Handler.....
        Return newRSCColumn_output

    End Function ''End of "Private Function GenerateRSCFieldColumn_General"


    Private Function GenerateRSCFieldColumn_Special(par_objField As ClassFieldAny, par_intFieldIndex As Integer) As RSCFieldColumnV2
        ''
        ''Added 3/8/2022 td
        ''
        Dim objNewColumn As RSCFieldColumnV2 ''Added 3/8/2022 td

        ''March9 2022 ''objNewColumn = RSCFieldColumn.GetFieldColumn()
        ''Added 1/17/2022 td
        Dim objGetParametersForGetControl As ciBadgeDesigner.ClassGetElementControlParams
        objGetParametersForGetControl = Me.Designer.GetParametersToGetElementControl()
        objGetParametersForGetControl.ElementObject = New ciBadgeElements.ClassElementBase()

        Const c_boolProportional As Boolean = False ''Added 3/11/2022 td 

        objNewColumn = RSCFieldColumnV2.GetRSCFieldColumn(objGetParametersForGetControl,
                                                         par_objField, Me.ParentForm,
                                                         "RSCFieldColumn" & CStr(par_intFieldIndex),
                                                          Me.Designer, c_boolProportional,
                                                          mod_ctlLasttouched, Me.Designer,
                                                          mod_eventsSingleton,
                                                          Me, par_intFieldIndex)

        ''Added 3/13/2022 thomas downes
        objNewColumn.BackColor = mod_colorOfColumnsBackColor

        Return objNewColumn

    End Function ''End of "Private Function GenerateRSCFieldColumn_Special() As RSCFieldColumn"


    Private Sub RemoveRSCColumnsFromDesignTime()
        ''
        ''Added 3/8/2022 thomas d
        ''
        Dim listRSCColumns As New List(Of RSCFieldColumnV2)

        For Each each_control As Control In Me.Controls
            If (TypeOf each_control Is RSCFieldColumnV2) Then

                each_control.Dispose()
                each_control.Visible = False
                listRSCColumns.Add(CType(each_control, RSCFieldColumnV2))

            End If
        Next each_control

        For Each each_control As RSCFieldColumnV2 In listRSCColumns

            Me.Controls.Remove(each_control)

        Next each_control

        ''Added 3/25/2022 td
        RscFieldColumn1 = Nothing ''Added 3/25/2022 td 

    End Sub ''end of "Private Sub RemoveRSCColumnsFromDesignTime()"


    Public Sub AddColumnsToRighthandSide(par_intNumber As Integer)
        ''
        ''Added 3/16/2022 Thomas Downes 
        ''
        ''Not needed.''Dim objLastColumnGoingRight As RSCFieldColumnV2
        ''Not needed.''objLastColumnGoingRight = GetLastColumn()
        For intIndex As Integer = 1 To par_intNumber
            ''Not needed.''objLastColumnGoingRight.AddToEdgeOfSpreadsheet_Column()
            AddToEdgeOfSpreadsheet_Column()
        Next intIndex

        ''Dim each_columnData As ClassRSCColumnWidthAndData ''4/13/2022 As ClassColumnWidthAndData
        ''
        ''For intIndex = 1 To par_intNumber
        ''
        ''    each_columnData = New ClassRSCColumnWidthAndData ''4/13/2022 ClassColumnWidthAndData
        ''    each_columnData.CIBField = EnumCIBFields.Undetermined
        ''    each_columnData.Width = -1
        ''    each_columnData.Rows = -1
        ''    each_columnData.ColumnData = New List(Of String)()
        ''
        ''    Me.ColumnDataCache.ListOfColumns.Add(each_columnData)
        ''
        ''Next intIndex

    End Sub ''End of "Public Sub AddColumns()"


    Public Sub SaveDataColumnByColumnXML(Optional pboolOpenXML As Boolean = False)
        ''---June29 2022---Public Sub SaveDataColumnByColumn
        ''
        ''Added 3/17/2022 thomas downes
        ''
        ''STEP 1 of 5 
        ''
        '' Save the column data to the ColumnDataCache. 
        ''
        For intIndex As Integer = 1 To Me.ColumnDataCache.ListOfColumns.Count

            Dim eachColumn As RSCFieldColumnV2 ''Added 3/18/2022 thomas downes
            eachColumn = mod_array_RSCColumns(intIndex)
            ''4/12/2022 td''eachColumn.SaveDataToColumn()
            eachColumn.SaveDataTo_ColumnCache()

        Next intIndex

        ''
        ''Resize the form based on the save form size.---3/20/2022
        ''
        Me.ColumnDataCache.FormSize = Me.ParentForm_DesignerDialog.Size

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
            eachColumn = mod_array_RSCColumns(intIndex)
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


    Public Sub InsertNewColumnByIndex(par_intColumnIndex As Integer)
        ''
        ''Added 3/20/2022 thomas downes 
        ''
        Dim objCacheOfData As CacheRSCFieldColumnWidthsEtc
        Dim newRSCColumn As RSCFieldColumnV2
        Dim intNewLength As Integer
        Dim intNewColumnPropertyLeft As Integer
        Dim intNewColumnWidth As Integer
        Dim intFirstBumpedColumn_Left As Integer ''Added 4/1/2022 thomas downes

        ''
        ''Step 1 of 11.  Record the Left position which the new column will occupy. 
        ''
        Dim existingColumn As RSCFieldColumnV2 ''Added 4/14/2022
        Dim boolPlaceWithinArray As Boolean ''Added 4/14/2022
        Dim intIndexLastColumn As Integer ''Added 4/14/2022
        ''Added 4/14/2022
        boolPlaceWithinArray = (par_intColumnIndex < mod_array_RSCColumns.Length)

        If boolPlaceWithinArray Then
            existingColumn = mod_array_RSCColumns(par_intColumnIndex)
            intNewColumnPropertyLeft = existingColumn.Left
        Else
            ''Added 4/14/2022 td
            ''  Use -1 to shift our focus to the last column in the array.
            intIndexLastColumn = (-1 + mod_array_RSCColumns.Length)
            existingColumn = mod_array_RSCColumns(intIndexLastColumn)
            intNewColumnPropertyLeft = (existingColumn.Left + existingColumn.Width + mc_ColumnMarginGap)
        End If ''End of ""If boolPlaceWithinArray Then ... Else ..."

        intNewColumnWidth = mc_ColumnWidthDefault

        ''
        ''Step 2a of 11.  Make room in the array which tracks the columns.  
        ''

        ''----objCacheOfData =
        ''For intIndex As Integer = 1 To Me.ColumnDataCache.ListOfColumns.Count
        ''    Dim eachColumn As RSCFieldColumn ''Added 3/18/2022 thomas downes
        ''    eachColumn = mod_array_RSCColumns(intIndex)
        ''Next intIndex

        intNewLength = (1 + mod_array_RSCColumns.Length)
        ''3/21/2022 td''ReDim Preserve mod_array_RSCColumns(intNewLength)  ''---(1 + mod_array_RSCColumns.Length)

        ''The number passed to ReDim Preserve is the upper bound of the array, 
        ''  not the length. ---4/15/2022
        ''
        ReDim Preserve mod_array_RSCColumns(intNewLength - 1)  ''Modified 3/21/2022 td
        If (mod_array_RSCColumns.Length <> intNewLength) Then Throw New Exception

        For intColIndex As Integer = (-1 + intNewLength) To (1 + par_intColumnIndex) Step -1
            ''Move the object references to the right (new-higher index). 
            ''
            ''The qualification of "Step -1" makes the index run from a large value to a smaller value.
            ''
            mod_array_RSCColumns(intColIndex) = mod_array_RSCColumns(-1 + intColIndex)

        Next intColIndex

        ''The place will be filled by the new column. --Added 4/1/2022
        mod_array_RSCColumns(par_intColumnIndex) = Nothing ''The place will be filled by the new column. --Added 4/1/2022  

        ''
        ''Step 2b of 11.  Move the columns to the right, to make room for the new column. 
        ''
        For intColIndex As Integer = (1 + par_intColumnIndex) To (-1 + intNewLength)
            ''
            ''Move the columns to the right, to make room for the new column. 
            ''
            mod_array_RSCColumns(intColIndex).Left += (intNewColumnWidth + mc_ColumnMarginGap)

            ''Added 4/1/2022 thomas downes
            If (0 = intFirstBumpedColumn_Left) Then
                intFirstBumpedColumn_Left = mod_array_RSCColumns(intColIndex).Left
            End If ''End of "If (0 = intFirstBumpedColumn_Left) Then"

        Next intColIndex

        ''
        ''Step 3 of 11.  Make a new column.   
        ''
        ''
        Dim intNextColumnPropertyLeft As Integer
        Dim objColumnAdjacent As RSCFieldColumnV2 = Nothing

        If (par_intColumnIndex > 0) Then
            objColumnAdjacent = mod_array_RSCColumns(-1 + par_intColumnIndex)
        Else
            objColumnAdjacent = mod_array_RSCColumns(+1 + par_intColumnIndex)
        End If

        ''
        ''Major call!!
        ''
        newRSCColumn = GenerateRSCFieldColumn_General(par_intColumnIndex,
                                                    intNewColumnPropertyLeft,
                                                    intNextColumnPropertyLeft,
                                                    objColumnAdjacent)

        ''
        ''Step 4 of 11. 
        ''
        newRSCColumn.ParentSpreadsheet = Me ''Added 4/30/2022 td
        newRSCColumn.Top = RscFieldColumn1.Top
        newRSCColumn.Height = RscFieldColumn1.Height
        ''April 1st 2022 ''newRSCColumn.ListOfColumnsToBumpRight = New List(Of RSCFieldColumn)
        Dim list_columnsToBumpRight As New List(Of RSCFieldColumnV2)

        For intColIndex As Integer = (1 + par_intColumnIndex) To (intNewLength - 1)
            ''
            ''Move the columns to the right, to make room for the new column. 
            ''
            ''----With newRSCColumn.ListOfColumnsToBumpRight
            With list_columnsToBumpRight
                .Add(mod_array_RSCColumns(intColIndex))
            End With

            ''Added 4/1/2022 thomas downes 
            newRSCColumn.AddBumpColumn(mod_array_RSCColumns(intColIndex))

        Next intColIndex

        ''
        ''This will set the MoveAndResizeControls_Monem functionality as well. 
        ''
        newRSCColumn.ListOfColumnsToBumpRight = list_columnsToBumpRight

        ''Added 4/14/2022 td
        With newRSCColumn
            If (.ColumnWidthAndData Is Nothing) Then
                ''Added 4/14/2022 td
                .ColumnWidthAndData = New ClassRSCColumnWidthAndData()
                .ColumnWidthAndData.CIBField = EnumCIBFields.Undetermined
                .ColumnWidthAndData.Width = mc_ColumnWidthDefault
            End If ''End of ""If (.ColumnWidthAndData Is Nothing) Then""
        End With ''End of ""With newRSCColumn""

        ''
        ''Step 5 of 11. 
        ''
        newRSCColumn.Load_FieldsFromCache(Me.ElementsCache_Deprecated)

        ''
        ''Step 6 of 11. 
        ''
        Dim boolTestNewColumn_OK As Boolean ''Added 4/1/2022 thomas d
        Dim intExpectedFirstBumped_Left As Integer
        Dim intDifferenceDelta As Integer

        intExpectedFirstBumped_Left = (newRSCColumn.Left + newRSCColumn.Width + mc_ColumnMarginGap)
        intDifferenceDelta = (intExpectedFirstBumped_Left - intFirstBumpedColumn_Left)

        boolTestNewColumn_OK = (newRSCColumn.Left + newRSCColumn.Width +
            mc_ColumnMarginGap <= intFirstBumpedColumn_Left)
        If (Not boolTestNewColumn_OK) Then
            ''System.Diagnostics.Debugger.Break()
        ElseIf (intDifferenceDelta > 0) Then
            ''System.Diagnostics.Debugger.Break()
        End If ''End of "If (Not boolTestNewColumn_OK) Then"

        ''
        ''Step 7 of 11.   Move the columns to the right, to make room for the new column. 
        ''     (This is similar to Step 1(b) of 6 above, but is a further adjustment.) 
        ''
        If (intDifferenceDelta > 0) Then
            For intColIndex As Integer = (1 + par_intColumnIndex) To (-1 + intNewLength)
                ''
                ''Move the columns to the right, as a 2nd, final attempt to make room for the new column. 
                ''
                ''---mod_array_RSCColumns(intIndex).Left += (intNewColumnWidth + mc_ColumnMarginGap)
                mod_array_RSCColumns(intColIndex).Left += intDifferenceDelta

            Next intColIndex
        End If ''End of "If (intDifferenceDelta > 0) Then"

        ''
        ''Step 8 of 11.  Add the column as a "Bump Column" for all the columns to the left.  
        ''
        Dim bIgnoreIndex0 As Boolean ''Added 4/14/2022 td 

        For intColIndex As Integer = 0 To (-1 + par_intColumnIndex) ''To (-1 + intNewLength)
            ''---For intColIndex As Integer = 0 To (-1 + par_intColumnIndex) 
            ''
            ''Add the column as a "Bump Column" for all the columns to the left. 
            ''
            bIgnoreIndex0 = (intColIndex = 0 And mod_array_RSCColumns(intColIndex) Is Nothing)
            If bIgnoreIndex0 Then Continue For

            ''4/14/2022 mod_array_RSCColumns(intColIndex).ListOfColumnsToBumpRight.Add(newRSCColumn)
            mod_array_RSCColumns(intColIndex).AddBumpColumn(newRSCColumn)

        Next intColIndex

        ''
        ''Step 9 of 11. 
        ''
        Load_EmptyRowsToAllNewColumns()

        ''
        ''Step 10 of 11.  Add the new column to the list of columns in the cache. 
        ''
        Me.ColumnDataCache.ListOfColumns.Add(newRSCColumn.ColumnWidthAndData)

        ''
        ''Step 11 of 11.  Display the corrected column index on each columns to the right.  
        ''
        For intColIndex As Integer = (1 + par_intColumnIndex) To (-1 + intNewLength)
            ''
            ''Display the corrected column index on each columns to the right. 
            ''
            mod_array_RSCColumns(intColIndex).DisplayColumnIndex(intColIndex)

        Next intColIndex

        ''Added 5/30/2022 
        If mc_boolKeepUILookingClean Then
            ''Hide the buttons which formerly occupied the blank area
            '' of the spreadsheet. ---5/13/2022 
            ButtonAddColumns2.Visible = False
            ButtonPasteData2.Visible = False
        End If ''End of ""If mc_boolKeepUILookingClean Then""

    End Sub ''End of "Public Sub InsertNewColumnByIndex(Me.ColumnIndex)"


    Public Sub DeleteRecipientFromCache(par_recipient As ciBadgeRecipients.ClassRecipient)
        ''
        ''Added 5/1/2022 td
        ''
        Me.RecipientsCache.ListOfRecipients.Remove(par_recipient)

    End Sub ''End of ""Public Sub DeleteRecipientFromCache(....)""


    Public Sub DeleteColumnByIndex(par_intColumnIndex As Integer)
        ''
        ''Added 4/14/2022 thomas downes 
        ''
        ''Dim objCacheOfData As CacheRSCFieldColumnWidthsEtc
        ''Dim newRSCColumn As RSCFieldColumnV2
        Dim intCurrentLengthOfArray As Integer
        Dim intNewLengthOfArray_ByMinus1 As Integer
        Dim intNewLengthOfArray As Integer
        ''Dim intNewColumnPropertyLeft As Integer
        ''Dim intNewColumnWidth As Integer
        Dim intFirstBumpedColumn_Left As Integer ''Added 4/1/2022 thomas downes

        ''
        ''Step 0 of 5.  Run some basic checks. 
        ''
        Dim columnAboutToDelete As RSCFieldColumnV2 ''Added 4/14/2022
        Dim intColumnAboutToDelete_Left As Integer ''Added 4/15/2022
        Dim boolPlaceWithinArray As Boolean ''Added 4/14/2022
        Dim intIndexLastColumn As Integer ''Added 4/14/2022
        Dim intWidthOfDeletedColumn As Integer ''Added 4/15/2022

        ''
        ''Added 4/14/2022
        ''
        ''4/15/2022 td ''boolPlaceWithinArray = (par_intColumnIndex <= mod_array_RSCColumns.Length)
        boolPlaceWithinArray = (par_intColumnIndex < mod_array_RSCColumns.Length)

        If boolPlaceWithinArray Then
            columnAboutToDelete = mod_array_RSCColumns(par_intColumnIndex)
            ''intNewColumnPropertyLeft = existingColumn.Left
            columnAboutToDelete.Visible = False ''Render it invisible.
            ''Added 4/15/2022 td
            intColumnAboutToDelete_Left = columnAboutToDelete.Left

            ''Added 4/15/2022 td
            If (columnAboutToDelete Is RscFieldColumn1) Then
                Try
                    RscFieldColumn1 = mod_array_RSCColumns(par_intColumnIndex + 1)
                Catch
                    ''If the user has deleted all of the columns, then this is the result.
                    ''   (Zero columns left.) ---4/15/2022 thomas d
                    RscFieldColumn1 = Nothing
                End Try
            End If ''End of ""If (columnAboutToDelete Is RscFieldColumn1) Then""

        Else
            ''
            ''Shouldn't happen. 
            ''
            System.Diagnostics.Debugger.Break() ''Throw new Exception("Why wasn't the column found?")

            ''Added 4/14/2022 td
            ''  Use -1 to shift our focus to the last column in the array.
            intIndexLastColumn = (-1 + mod_array_RSCColumns.Length)
            columnAboutToDelete = mod_array_RSCColumns(intIndexLastColumn)
            ''intNewColumnPropertyLeft = (existingColumn.Left + existingColumn.Width + mc_ColumnMarginGap)
            columnAboutToDelete.Visible = False ''Render it invisible.

        End If ''End of ""If boolPlaceWithinArray Then ... Else ..."

        ''intNewColumnWidth = mc_ColumnWidthDefault

        ''
        ''Step 1a of 6.  Make room in the array which tracks the columns.  
        ''

        ''----objCacheOfData =
        ''For intIndex As Integer = 1 To Me.ColumnDataCache.ListOfColumns.Count
        ''    Dim eachColumn As RSCFieldColumn ''Added 3/18/2022 thomas downes
        ''    eachColumn = mod_array_RSCColumns(intIndex)
        ''Next intIndex

        ''Moved below. intNewLengthOfArray_Minus1 = (-1 + mod_array_RSCColumns.Length)
        ''Moved below. ''3/21/2022 td''ReDim Preserve mod_array_RSCColumns(intNewLength)  ''---(1 + mod_array_RSCColumns.Length)
        ''Moved below. ReDim Preserve mod_array_RSCColumns(intNewLengthOfArray_Minus1)  ''Modified 3/21/2022 td
        ''Moved below. If (mod_array_RSCColumns.Length <> intNewLengthOfArray_Minus1) Then Throw New Exception

        intCurrentLengthOfArray = mod_array_RSCColumns.Length

        For intColIndex As Integer = par_intColumnIndex To (-1 - 1 + intCurrentLengthOfArray)
            ''---For intColIndex As Integer = par_intColumnIndex To (-1 + intCurrentLengthOfArray)
            ''
            ''Move the object references to the left (lower-higher index). 
            ''
            mod_array_RSCColumns(intColIndex) = mod_array_RSCColumns(intColIndex + 1)

        Next intColIndex

        ''
        ''Remove the last item in the array.  
        ''
        intNewLengthOfArray_ByMinus1 = (-1 + mod_array_RSCColumns.Length)
        ''3/21/2022 td''ReDim Preserve mod_array_RSCColumns(intNewLength)  ''---(1 + mod_array_RSCColumns.Length)
        ''
        ''The number passed to ReDim Preserve is the upper bound of the array, 
        ''  not the length. ---4/15/2022
        ''
        ReDim Preserve mod_array_RSCColumns(-1 + intNewLengthOfArray_ByMinus1)  ''Modified 3/21/2022 td
        If (mod_array_RSCColumns.Length <> intNewLengthOfArray_ByMinus1) Then Throw New Exception
        intNewLengthOfArray = intNewLengthOfArray_ByMinus1 ''We don't need the suffix anymore. 

        ''
        ''Step 1b of 6.  Move the columns to the left, in place of the soon-to-be-deleted column. 
        ''
        intWidthOfDeletedColumn = columnAboutToDelete.Width

        intFirstBumpedColumn_Left = Integer.MaxValue ''Default value
        For Each each_col As RSCFieldColumnV2 In mod_array_RSCColumns
            ''---For intColIndex As Integer = (1 + par_intColumnIndex) To (intNewLengthOfArray) '' (-1 + intNewLengthOfArray)
            ''
            ''If the column's Left edge is greater (bigger in X value) then 
            ''   the column we are deleting....
            ''   Then move the column to the left, in place of the deleted column. 
            ''   ----4/15/2022
            ''
            If (each_col Is Nothing) Then
                ''
                ''Don't process a Null reference. ---4/15/2022
                ''
            ElseIf (each_col.Left > intColumnAboutToDelete_Left) Then

                each_col.Left -= (intWidthOfDeletedColumn + mc_ColumnMarginGap)

                ''Added 4/1/2022 thomas downes
                ''   Save the new location of the leftmost column.
                ''   Whichever is furthest left, supplies the final value.
                If (each_col.Left < intFirstBumpedColumn_Left) Then
                    intFirstBumpedColumn_Left = each_col.Left
                End If

            End If ''End of ""ElseIf (each_col.Left > intColumnAboutToDelete_Left) Then""

        Next each_col

        ''
        ''Step 7 of 7.  Remove the deleted column as a "Bump Column" for all the columns to the left.  
        ''
        Dim bIgnoreIndex0 As Boolean ''Added 4/14/2022 td 

        For intColIndex As Integer = 0 To (-1 + par_intColumnIndex) ''To (-1 + intNewLength)
            ''---For intColIndex As Integer = 0 To (-1 + par_intColumnIndex) 
            ''
            ''Add the column as a "Bump Column" for all the columns to the left. 
            ''
            bIgnoreIndex0 = (intColIndex = 0 And mod_array_RSCColumns(intColIndex) Is Nothing)
            If bIgnoreIndex0 Then Continue For

            mod_array_RSCColumns(intColIndex).RemoveBumpColumn(columnAboutToDelete)

        Next intColIndex

        ''
        ''Remove the column from the controls.
        ''
        Me.Controls.Remove(columnAboutToDelete)

        ''
        ''Remove the column from the column-width cache 
        ''
        Dim delete_columnWidthAndData As ClassRSCColumnWidthAndData
        delete_columnWidthAndData = columnAboutToDelete.ColumnWidthAndData
        Me.ColumnDataCache.ListOfColumns.Remove(delete_columnWidthAndData)

        ''
        ''Check to see if RSCColumn1 is affected. 
        ''
        If (RscFieldColumn1 Is columnAboutToDelete) Then
            RscFieldColumn1 = mod_array_RSCColumns(0) ''Probably a null reference,
            '' as 0 is not being used!?  ----4/15/2022
            If (RscFieldColumn1 Is Nothing) Then
                RscFieldColumn1 = mod_array_RSCColumns(1)
            End If ''End of ""If (RscFieldColumn1 Is Nothing) Then""
        End If ''ENdof ""If (RscFieldColumn1 = columnAboutToDelete) Then""

    End Sub ''End of "Public Sub DeleteColumnByIndex(Me.ColumnIndex)"


    Public Sub ReviewRelevantFieldsViaDialogForm()
        ''
        ''We will open the All-Fields dialog (Standard & Custom fields).  ---4/13/2022 td
        ''
        Static s_bMsgOnce As Boolean
        If (Not s_bMsgOnce) Then
            ''Added 4/13/2022 td
            MessageBoxTD.Show_Statement("We will open the Fields dialog, " &
                  "to allow the user to add more fields." & vbCrLf_Deux &
                  "Hit the Relevant checkbox to include the field.",
                   "((one-time message)")
            s_bMsgOnce = True
        End If ''End of ""If (Not s_bMsgOnce) Then""

        ''Major call!!!!   4/13/2022 thomas 
        ''Dim obj_show As DialogListBothTypeFields
        ''obj_show = New DialogListBothTypeFields()
        ''obj_show.ShowDialog()
        ''RscFieldSpreadsheet1.RefreshFieldDropdowns()

        Dim form_ToShow As New DialogListBothTypeFields
        Dim dialog_result As DialogResult ''Added 4/13 & 3/23/2022 td

        ''Added 4/13 & 3/21/2022 td
        form_ToShow.ListOfFields_Standard = Me.ElementsCache_Deprecated.ListOfFields_Standard
        form_ToShow.ListOfFields_Custom = Me.ElementsCache_Deprecated.ListOfFields_Custom

        dialog_result =
           form_ToShow.ShowDialog()

        ''Added 4/13 & 3/23/2022 td
        If (dialog_result = DialogResult.OK) Then
            ''Added 3/23/2022 td
            Me.ElementsCache_Deprecated.SaveToXML()

            ''Refresh the list of fields above each column. 
            RefreshFieldDropdowns()

        End If ''End of ""If (dialog_result = ...)"


    End Sub ''End of ""Public Sub ReviewRelevantFieldsViaDialogForm()""


    Public Sub RefreshFieldDropdowns()
        ''
        ''Added 4/13/2022 thomas downes
        ''
        For Each each_column As RSCFieldColumnV2 In mod_array_RSCColumns
            ''Added 4/13/2022 thomas downes
            If (each_column IsNot Nothing) Then
                each_column.RefreshFieldDropdown()
            End If ''end of "If (each_column IsNot Nothing) Then"

        Next each_column

    End Sub ''End of "Public Sub RefreshFieldDropdowns()"


    Public Function ToString_ByRow(par_intRowIndex As Integer,
                        Optional pboolRowIndices As Boolean = False) As String
        ''
        ''Added 4/03/2022
        ''
        Dim intCountColumns As Integer
        Dim list_columns As List(Of RSCFieldColumnV2)
        Dim each_column As RSCFieldColumnV2
        Dim strValue As String
        Dim strLine As String = ""

        ''Added 4/12/2022 td
        If (pboolRowIndices) Then strLine = par_intRowIndex.ToString

        list_columns = ListOfColumns()
        intCountColumns = list_columns.Count()

        For intColIndex As Integer = 0 To intCountColumns - 1

            each_column = list_columns(intColIndex)
            strValue = each_column.ToString_ByRow(par_intRowIndex)
            If (strValue = "") Then
                strLine &= (strValue)
            Else
                strLine &= (vbTab & strValue)
            End If

        Next intColIndex

        Return strLine

    End Function ''Ednd of ""Public Function ToString_ByRow()""


    Public Function Equals_RecipientListAtClose() As Boolean
        ''
        ''Added 6/28/2022 thomas downes  
        ''
        Dim exampleColumnMaxCells As RSCFieldColumnV2
        Dim exampleColumnMaxVals As ClassRSCColumnWidthAndData
        Dim list_enumsRelevant As List(Of EnumCIBFields)
        Dim intHowManyRecips As Integer
        Dim intHowManyDataValues As Integer
        Dim intHowManyRowHeaders As Integer
        Dim intHowManyCellRows As Integer

        If Me.RecipientsCache Is Nothing Then System.Diagnostics.Debugger.Break()
        If Me.RecipientsCache.ListOfRecipients Is Nothing Then
            System.Diagnostics.Debugger.Break()
        End If

        list_enumsRelevant = ElementsCache.ListOfFieldEnums_Relevant()

        exampleColumnMaxVals = Me.ColumnDataCache.RSCColumnWithMaximalDataCells()
        exampleColumnMaxCells = mod_array_RSCColumns(0)

        intHowManyCellRows = exampleColumnMaxCells.CountOfRows()
        intHowManyDataValues = exampleColumnMaxVals.ColumnData.Count
        intHowManyRecips = Me.RecipientsCache.ListOfRecipients.Count
        intHowManyRowHeaders = RscRowHeaders1.CountOfRows()

        If (intHowManyCellRows <> intHowManyDataValues) Then
            System.Diagnostics.Debugger.Break()
        ElseIf (intHowManyCellRows <> intHowManyCellRows) Then
            System.Diagnostics.Debugger.Break()
        ElseIf (intHowManyCellRows <> intHowManyRowHeaders) Then
            System.Diagnostics.Debugger.Break()
        ElseIf (intHowManyDataValues <> intHowManyRecips) Then
            System.Diagnostics.Debugger.Break()
        ElseIf (intHowManyRecips <> intHowManyRowHeaders) Then
            System.Diagnostics.Debugger.Break()
        End If

        Dim each_column As RSCFieldColumnV2
        Dim each_match1of2 As Boolean
        Dim sum_matches1of2 As Boolean = True ''Default to true

        ''
        ''Matching-Checks routine #1 of 2--Column by Column  
        ''
        For Each each_column In mod_array_RSCColumns

            If (each_column Is Nothing) Then Continue For

            each_match1of2 = each_column.Equals_RecipientListAtClose()
            sum_matches1of2 = (sum_matches1of2 And each_match1of2)

        Next each_column

        ''
        ''Matching-Checks routine #2 of 2--Row by Row    
        ''
        Dim each_match2of2 As Boolean
        Dim sum_matches2of2 As Boolean = True ''Default to true

        Dim each_recip As ciBadgeRecipients.ClassRecipient
        Dim each_RowHeaderRecipient As ciBadgeRecipients.ClassRecipient
        Dim each_strGuid6 As String

        For Each each_recip In Me.RecipientsCache.ListOfRecipients()

            If (each_recip Is Nothing) Then Continue For
            each_strGuid6 = each_recip.ID_Guid6chars
            each_RowHeaderRecipient = Me.RscRowHeaders1.GetRecipient_ByGuid6(each_strGuid6).Recipient

            If (each_RowHeaderRecipient Is Nothing) Then
                System.Diagnostics.Debugger.Break()
            End If

            each_match2of2 = each_recip.Equals(each_RowHeaderRecipient, list_enumsRelevant)
            sum_matches2of2 = (sum_matches2of2 And each_match2of2)

        Next each_recip




    End Function ''ENd of ""Public Function Equals_RecipientListAtClose() As Boolean""




    Private Sub Timer1_Tick(sender As Object, e As EventArgs)

        ''Added 3/25/2022 thomas downes 
        ''Timer1.Enabled = False ''Make this one-time only. 
        ''RscRowHeaders1.RSCSpreadsheet = Me
        ''AlignRowHeadersWithSpreadsheet()


    End Sub

    Private Sub RscFieldColumn1_Load(sender As Object, e As EventArgs) Handles RscFieldColumn1.Load

    End Sub

    Private Sub RSCFieldSpreadsheet_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint

        Static s_priorAutoScrollPositionX As Integer
        Static s_priorAutoScrollPositionY As Integer

        Dim intAutoscrollPositionX As Integer
        Dim intAutoscrollPositionY As Integer

        intAutoscrollPositionX = Me.AutoScrollPosition.X
        intAutoscrollPositionY = Me.AutoScrollPosition.Y

        If (0 <> intAutoscrollPositionY) Then
            s_priorAutoScrollPositionX = intAutoscrollPositionX
            s_priorAutoScrollPositionY = intAutoscrollPositionY
        End If

    End Sub

    Private Sub LinkLabelReviewFields_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelReviewFields.LinkClicked

        ''Added 4/13/2022
        ReviewRelevantFieldsViaDialogForm()

    End Sub

    Private Sub LinkLabelRightClickMenu_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelRightClickMenu.LinkClicked

        ''Added 4/13/2022 thomas downes 
        Static s_bMsgOnce As Boolean
        If (Not s_bMsgOnce) Then
            MessageBoxTD.Show_Statement("Right-clicking spreadsheet " &
                                        "items will often display a menu.",
                                     "(one-time message)")
        End If ''End of "If (Not s_bMsgOnce) Then"

        ''Added 4/13/2022 td
        Dim new_args As MouseEventArgs
        new_args = New MouseEventArgs(MouseButtons.Right, 1,
                                      LinkLabelRightClickMenu.Left,
                                      LinkLabelRightClickMenu.Top, 0)
        ''Major call....
        MyBase.MoveableControl_MouseUp(Me, new_args)

    End Sub

    Private Sub ButtonAddColumns_Click(sender As Object, e As EventArgs) _
        Handles ButtonAddColumns1.Click, ButtonAddColumns2.Click
        ''
        ''Added 5/13/2022 thomas downes  
        ''
        Dim intHowMany As Integer
        Dim boolCancelled As Boolean = False

        intHowMany = MessageBoxTD.AskHowMany("How many columns do you want?",
                1.0, 1.0, 1, 9, False, False, boolCancelled)
        If (boolCancelled) Then
            MessageBoxTD.Show_Statement("User has cancelled.")
        Else
            ''Major call!!
            AddColumnsToRighthandSide(intHowMany)

            ''added 5/13/2022
            If mc_boolKeepUILookingClean Then
                ''Hide the buttons which formerly occupied the blank area
                '' of the spreadsheet. ---5/13/2022 
                ButtonAddColumns2.Visible = False
                ButtonPasteData2.Visible = False
            End If ''End of ""If c_boolKeepUILookingClean Then""

        End If ''End of""If (boolCancelled) Then.... Else...."

        ''Dim columnRighHandMost As RSCFieldColumnV2 = Nothing
        ''Dim boolException As Boolean
        ''Dim exceptionRSC As Exception

        ''Try
        ''    columnLeftHandMost = mod_array_RSCColumns(0)
        ''    If (columnLeftHandMost Is Nothing) Then
        ''        columnLeftHandMost = mod_array_RSCColumns(1)
        ''    End If
        ''Catch exceptionRSC
        ''    boolException = True
        ''End Try

        ''AddColumns(5)

    End Sub

    Private Sub ButtonPasteData_Click(sender As Object, e As EventArgs) _
        Handles ButtonPasteData1.Click, ButtonPasteData2.Click
        ''
        ''Added 5/13/2022 thomas downes  
        ''
        PasteData_SecondTry()

    End Sub








End Class
