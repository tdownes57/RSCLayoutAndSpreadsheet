''
''Added 2/21/2022 td
''
Imports __RSCWindowsControlLibrary ''Added 3/20/2022 Thomas Downes
Imports ciBadgeDesigner
Imports ciBadgeFields ''Added 3/10/2.0.2.2. thomas downes
Imports ciBadgeInterfaces ''Added 3/11/2022 t__homas d__ownes
Imports ciBadgeCachePersonality ''Added 3/14/2.0.2.2. t.//downes
Imports System.Drawing ''Added 3/20/2022 thomas downes

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

    Private mod_ctlLasttouched As New ClassLastControlTouched ''Added 1/4/2022 td
    Private mod_eventsSingleton As New GroupMoveEvents_Singleton(Me.Designer, False, True) ''Added 1/4/2022 td  
    Private mod_colorOfColumnsBackColor As System.Drawing.Color = Drawing.Color.AntiqueWhite ''Added 3/13/2022 thomas downes
    Private mod_array_RSCColumns As RSCFieldColumnV2() ''Added 3/14/2022 td

    Private Const mc_ColumnWidthDefault As Integer = 150 ''72 ''Added 3/20/2022 td
    Private Const mc_ColumnMarginGap As Integer = 3 ''---4 ''Added 3/20/2022 td
    Private Const mod_intRscFieldColumn1_Top As Integer = 19 ''Added 4/3/2022 thomas downes
    Private Const mc_intPixelsFromRowToRow As Integer = 24 ''Added 4/05/2022 td


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
        Dim CtlFieldSheet1 = New RSCFieldSpreadsheet(par_formParent,
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


    Public Sub New(par_oParentForm As Form,
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
        MyBase.New(EnumElementType.RSCSheetSpreadsheet, par_oParentForm,
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


    Public Sub PasteData(par_stringPastedData As String)
        ''
        ''Added 2/22/2022 td
        ''




    End Sub ''ENd of "Public Sub PasteData(par_stringPastedData As String)"


    Public Function GetRecipientByRowIndex(par_intRowIndex As Integer) As ciBadgeRecipients.ClassRecipient
        ''
        ''Added 4/14/2022 td
        ''
        Return RecipientsCache.ListOfRecipients(par_intRowIndex)

    End Function


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
                    Me.ClearDataFromSpreadsheet_NoConfirm() '' (bUserCancelled)
                    Threading.Thread.Sleep(500)
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


        End If ''End of ""If (Me.RecipientsCache Is Nothing) Then.... Else....""


    End Sub ''End of event handler Private Sub RSCFieldSpreadsheet_Load


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
            ''Major call!
            ''
            each_Column.ParentSpreadsheet = Me ''Added 4/11/2022 thomas d. 
            each_Column.Load_FieldsFromCache(Me.ElementsCache_Deprecated)

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


    End Sub ''End of Public Sub LoadRuntimeColumns_AfterClearingDesign


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
        listBoxesRowHeader = RscRowHeaders1.ListOfTextboxes_TopToBottom()

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


    Public Sub AddColumns(par_intNumber As Integer)
        ''
        ''Added 3/16/2022 Thomas Downes 
        ''
        Dim each_columnData As ClassRSCColumnWidthAndData ''4/13/2022 As ClassColumnWidthAndData

        For intIndex = 1 To par_intNumber

            each_columnData = New ClassRSCColumnWidthAndData ''4/13/2022 ClassColumnWidthAndData
            each_columnData.CIBField = EnumCIBFields.Undetermined
            each_columnData.Width = -1
            each_columnData.Rows = -1
            each_columnData.ColumnData = New List(Of String)()

            Me.ColumnDataCache.ListOfColumns.Add(each_columnData)

        Next intIndex

    End Sub ''End of "Public Sub AddColumns()"


    Public Sub SaveDataColumnByColumn(Optional pboolOpenXML As Boolean = False)
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

    End Sub ''End of "Public Sub SaveDataColumnByColumn()"


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
        ''Step 0 of 5.  Record the Left position which the new column will occupy. 
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
        ''Step 1a of 6.  Make room in the array which tracks the columns.  
        ''

        ''----objCacheOfData =
        ''For intIndex As Integer = 1 To Me.ColumnDataCache.ListOfColumns.Count
        ''    Dim eachColumn As RSCFieldColumn ''Added 3/18/2022 thomas downes
        ''    eachColumn = mod_array_RSCColumns(intIndex)
        ''Next intIndex

        intNewLength = (1 + mod_array_RSCColumns.Length)
        ''3/21/2022 td''ReDim Preserve mod_array_RSCColumns(intNewLength)  ''---(1 + mod_array_RSCColumns.Length)
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
        ''Step 1b of 6.  Move the columns to the right, to make room for the new column. 
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
        ''Step 2 of 6.  Make a new column.   
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
        ''Step 3 of 6. 
        ''
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
        ''Step 4 of 6. 
        ''
        newRSCColumn.Load_FieldsFromCache(Me.ElementsCache_Deprecated)

        ''
        ''Step 5 of 6. 
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
        ''Step 6 of 6.   Move the columns to the right, to make room for the new column. 
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
        ''Step 7 of 7.  Add the column as a "Bump Column" for all the columns to the left.  
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

    End Sub ''End of "Public Sub InsertNewColumnByIndex(Me.ColumnIndex)"



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
        ''Dim intFirstBumpedColumn_Left As Integer ''Added 4/1/2022 thomas downes

        ''
        ''Step 0 of 5.  Run some basic checks. 
        ''
        Dim existingColumn As RSCFieldColumnV2 ''Added 4/14/2022
        Dim boolPlaceWithinArray As Boolean ''Added 4/14/2022
        Dim intIndexLastColumn As Integer ''Added 4/14/2022

        ''Added 4/14/2022
        boolPlaceWithinArray = (par_intColumnIndex < mod_array_RSCColumns.Length)

        If boolPlaceWithinArray Then
            existingColumn = mod_array_RSCColumns(par_intColumnIndex)
            ''intNewColumnPropertyLeft = existingColumn.Left

        Else
            ''
            ''Shouldn't happen. 
            ''
            System.Diagnostics.Debugger.Break() ''Throw new Exception("Why wasn't the column found?")

            ''Added 4/14/2022 td
            ''  Use -1 to shift our focus to the last column in the array.
            intIndexLastColumn = (-1 + mod_array_RSCColumns.Length)
            existingColumn = mod_array_RSCColumns(intIndexLastColumn)
            ''intNewColumnPropertyLeft = (existingColumn.Left + existingColumn.Width + mc_ColumnMarginGap)

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
        ReDim Preserve mod_array_RSCColumns(intNewLengthOfArray_ByMinus1)  ''Modified 3/21/2022 td
        If (mod_array_RSCColumns.Length <> intNewLengthOfArray_ByMinus1) Then Throw New Exception
        intNewLengthOfArray = intNewLengthOfArray_ByMinus1 ''We don't need the suffix anymore. 

        ''
        ''Step 1b of 6.  Move the columns to the left, in place of the soon-to-be-deleted column. 
        ''
        intColumnWidthDeleted = existingColumn.Width

        For intColIndex As Integer = (1 + par_intColumnIndex) To (intNewLengthOfArray)
            ''
            ''Move the columns to the left, in place of the deleted column. 
            ''
            mod_array_RSCColumns(intColIndex).Left -= (intColumnWidthDeleted + mc_ColumnMarginGap)

            ''Added 4/1/2022 thomas downes
            If (0 = intFirstBumpedColumn_Left) Then
                intFirstBumpedColumn_Left = mod_array_RSCColumns(intColIndex).Left
            End If ''End of "If (0 = intFirstBumpedColumn_Left) Then"

        Next intColIndex

        ''
        ''Step 2 of 6.  Make a new column.   
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
        ''Step 3 of 6. 
        ''
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
        ''Step 4 of 6. 
        ''
        newRSCColumn.Load_FieldsFromCache(Me.ElementsCache_Deprecated)

        ''
        ''Step 5 of 6. 
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
        ''Step 6 of 6.   Move the columns to the right, to make room for the new column. 
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
        ''Step 7 of 7.  Add the column as a "Bump Column" for all the columns to the left.  
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

    End Sub ''End of "Public Sub DeleteColumnByIndex(Me.ColumnIndex)"


    Public Sub ReviewFieldsViaDialog()
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


    End Sub ''End of ""Public Sub ReviewFieldsViaDialog()""


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
        ReviewFieldsViaDialog()

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
End Class
