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
    Public ColumnDataCache As CacheRSCFieldColumnWidthsEtc ''ClassColumnWidthsEtc ''Added 3/15/2022 td
    ''Public RscFieldColumn1 As RSCFieldColumn ''Added 3/25/2022 td
    Public RecipientsCache As ClassCacheOnePersonalityConfig ''Added 3/28/2022 thomas downes

    Private mod_ctlLasttouched As New ClassLastControlTouched ''Added 1/4/2022 td
    Private mod_eventsSingleton As New GroupMoveEvents_Singleton(Me.Designer, False, True) ''Added 1/4/2022 td  
    Private mod_colorOfColumnsBackColor As System.Drawing.Color = Drawing.Color.AntiqueWhite ''Added 3/13/2022 thomas downes
    Private mod_array_RSCColumns As RSCFieldColumn() ''Added 3/14/2022 td
    Private Const mc_ColumnWidthDefault As Integer = 150 ''72 ''Added 3/20/2022 td
    Private Const mc_ColumnMarginGap As Integer = 3 ''---4 ''Added 3/20/2022 td

    Public Function RSCFieldColumn_Leftmost() As RSCFieldColumn
        ''Added 3/31/2022 td
        Return RscFieldColumn1
    End Function

    Public Function ListOfColumns() As List(Of RSCFieldColumn)

        ''Added 3/21/2022 thomas downes
        ''\\---Return New List(Of RSCFieldColumn)(mod_array_RSCColumns)
        Dim oList As List(Of RSCFieldColumn)
        oList = New List(Of RSCFieldColumn)(mod_array_RSCColumns)
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
            Dim list_columns As List(Of RSCFieldColumn)

            list_columns = ListOfColumns() ''Added 3/30/2022 thomas d. 

            For Each each_column As RSCFieldColumn In list_columns ''March30 2022 td''Me.ListOfColumns()

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


        End If ''End of ""If (Me.RecipientsCache Is Nothing) Then.... Else....""


    End Sub ''End of event handler Private Sub RSCFieldSpreadsheet_Load


    Public Sub ClearDataFromSpreadsheet_1stConfirm(Optional ByRef pboolUserCancelled As Boolean = False)
        ''
        ''Added 3/29/2022 thomas downes
        ''
        Dim objRSCFieldColumn As RSCFieldColumn
        Dim boolConfirmed As Boolean

        boolConfirmed = (MessageBoxTD.Show_Confirmed("Clear all data from this spreadsheet?",
                          "(To undo this later, right-click & select Undo Clear Data.)", True))

        If (boolConfirmed) Then
            ''Confirmed, so clear the data from each column.  
            For Each each_column As RSCFieldColumn In Me.ListOfColumns
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
        Dim objRSCFieldColumn As RSCFieldColumn
        Dim boolConfirmed As Boolean

        For Each each_column As RSCFieldColumn In Me.ListOfColumns
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
        intSavePropertyTop_FirstRow = RscFieldColumn1.GetFirstTextboxPropertyTop()

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

        ''
        ''Step 2 of 5.  Load run- time columns. 
        ''
        ''Step 2a of 5.  Create a local array for storing indexed columns. 
        ''
        ''Added a Number N of Required Columns. 
        ''
        Dim intNeededIndex As Integer = 1
        Dim each_Column As RSCFieldColumn
        Dim priorColumn As RSCFieldColumn = Nothing
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
        Dim listColumnsRight = New List(Of RSCFieldColumn)
        Dim each_list As List(Of RSCFieldColumn)
        Dim prior_list As List(Of RSCFieldColumn)
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
            each_list = New List(Of RSCFieldColumn)(listColumnsRight) ''Basically, a copy of listColumnsRight.

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
        Dim each_columnWidthEtc As ciBadgeDesigner.ClassColumnWidthAndData
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

            ''
            ''Major call!
            ''
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
        Dim listBoxesColumn As List(Of TextBox)
        Dim listBoxesRowHeader As List(Of TextBox)

        listBoxesColumn = RscFieldColumn1.ListOfTextboxes_TopToBottom()
        listBoxesRowHeader = RscRowHeaders1.ListOfTextboxes_TopToBottom()

        ''March25 2022''RscRowHeaders1.AlignControlsWithSpreadsheet(listBoxesColumn)
        RscRowHeaders1.AlignControlsWithSpreadsheet(RscFieldColumn1)

    End Sub ''End of "Public Sub AlignRowHeadersWithSpreadsheet()"


    Public Sub Load_FieldsFromCache(par_cache As ClassElementsCache_Deprecated)
        ''
        ''Added 2/16/2022 thomas downes
        ''



    End Sub ''end of sub "Public Sub Load_FieldsFromCache(par_cache As ClassElementsCache_Deprecated)"


    Private Function GenerateRSCFieldColumn_General(p_intIndexCurrent As Integer,
                                                    p_intCurrentPropertyLeft As Integer,
                                                    ByRef pref_intNextPropertyLeft As Integer,
                                                    p_priorColumn As RSCFieldColumn) As RSCFieldColumn
        ''
        '' Added 3/20/2022 td
        ''
        Dim newRSCColumn_output As RSCFieldColumn
        Dim fieldForNewColumn As ciBadgeFields.ClassFieldAny

        fieldForNewColumn = New ciBadgeFields.ClassFieldAny()
        ''each_field.FieldEnumValue = ciBadgeInterfaces.EnumCIBFields.Undetermined
        fieldForNewColumn.FieldEnumValue = Me.ColumnDataCache.ListOfColumns(-1 + p_intIndexCurrent).CIBField

        ''
        ''Major call, call the other, "..._Special" version of this column-generating function (suffixed "..._General"). 
        ''
        newRSCColumn_output = GenerateRSCFieldColumn_Special(fieldForNewColumn, p_intIndexCurrent)
        ''----intCurrentPropertyLeft = intNextPropertyLeft ''Check prior iteration.

        ''
        ''Add additional properties. 
        ''
        With newRSCColumn_output
            newRSCColumn_output.Left = p_intCurrentPropertyLeft
            newRSCColumn_output.Width = mc_ColumnWidthDefault ''Added 3/20/2022 td
            newRSCColumn_output.Visible = True

            ''Added 3/30/2022 td
            ''newRSCColumn_output.Height = (Me.Height - newRSCColumn_output.Top)
            ''newRSCColumn_output.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right), AnchorStyles)

            ''Prepare for next iteration. 
            pref_intNextPropertyLeft = (newRSCColumn_output.Left + newRSCColumn_output.Width + 3)
            Me.Controls.Add(newRSCColumn_output)

            ''Added 3/12/2022 thomas downes 
            mod_array_RSCColumns(p_intIndexCurrent) = newRSCColumn_output
            ''Added 3/16/2022 td
            ''  Redundant, assigned in Step 4 below.
            ''Oops....3/18/2022 ''eachColumn.ColumnWidthAndData = Me.ColumnDataCache.ListOfColumns(-1 + intNeededMax)
            newRSCColumn_output.ElementsCache_Deprecated = Me.ElementsCache_Deprecated
            newRSCColumn_output.ColumnWidthAndData = Me.ColumnDataCache.ListOfColumns(-1 + p_intIndexCurrent)

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

        Return newRSCColumn_output

    End Function ''End of "Private Function GenerateRSCFieldColumn_Special"


    Private Function GenerateRSCFieldColumn_Special(par_objField As ClassFieldAny, par_intFieldIndex As Integer) As RSCFieldColumn
        ''
        ''Added 3/8/2022 td
        ''
        Dim objNewColumn As RSCFieldColumn ''Added 3/8/2022 td

        ''March9 2022 ''objNewColumn = RSCFieldColumn.GetFieldColumn()
        ''Added 1/17/2022 td
        Dim objGetParametersForGetControl As ciBadgeDesigner.ClassGetElementControlParams
        objGetParametersForGetControl = Me.Designer.GetParametersToGetElementControl()

        Const c_boolProportional As Boolean = False ''Added 3/11/2022 td 

        objNewColumn = RSCFieldColumn.GetRSCFieldColumn(objGetParametersForGetControl,
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
        Dim listRSCColumns As New List(Of RSCFieldColumn)

        For Each each_control As Control In Me.Controls
            If (TypeOf each_control Is RSCFieldColumn) Then

                each_control.Dispose()
                each_control.Visible = False
                listRSCColumns.Add(CType(each_control, RSCFieldColumn))

            End If
        Next each_control

        For Each each_control As RSCFieldColumn In listRSCColumns

            Me.Controls.Remove(each_control)

        Next each_control

        ''Added 3/25/2022 td
        RscFieldColumn1 = Nothing ''Added 3/25/2022 td 

    End Sub ''end of "Private Sub RemoveRSCColumnsFromDesignTime()"


    Public Sub AddColumns(par_intNumber As Integer)
        ''
        ''Added 3/16/2022 Thomas Downes 
        ''
        Dim each_columnData As ClassColumnWidthAndData

        For intIndex = 1 To par_intNumber

            each_columnData = New ClassColumnWidthAndData
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
        For intIndex As Integer = 1 To Me.ColumnDataCache.ListOfColumns.Count

            Dim eachColumn As RSCFieldColumn ''Added 3/18/2022 thomas downes
            eachColumn = mod_array_RSCColumns(intIndex)
            eachColumn.SaveDataToColumn()

        Next intIndex

        ''
        ''Resize the form based on the save form size.---3/20/2022
        ''
        Me.ColumnDataCache.FormSize = Me.ParentForm_DesignerDialog.Size

        ''
        ''FINAL STEP
        ''
        Dim strPathToXML_Opened As String = Me.ColumnDataCache.PathToXml_Opened
        Dim strPathToXML_Saved As String = Me.ColumnDataCache.PathToXml_Saved

        If String.IsNullOrEmpty(strPathToXML_Opened) Then strPathToXML_Opened = strPathToXML_Saved
        If String.IsNullOrEmpty(strPathToXML_Opened) Then strPathToXML_Opened =
            DiskFilesVB.PathToFile_XML_RSCFieldSpreadsheet()

        Me.ColumnDataCache.SaveToXML(strPathToXML_Opened)
        Me.ColumnDataCache.PathToXml_Saved = strPathToXML_Opened

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
        Dim newRSCColumn As RSCFieldColumn
        Dim intNewLength As Integer
        Dim intNewColumnPropertyLeft As Integer
        Dim intNewColumnWidth As Integer

        ''
        ''Step 0 of 5.  Record the Left position which the new column will occupy. 
        ''
        intNewColumnPropertyLeft = mod_array_RSCColumns(par_intColumnIndex).Left
        intNewColumnWidth = mc_ColumnWidthDefault

        ''
        ''Step 1 of 5.  Make room in the array which tracks the columns.  
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

        For intIndex As Integer = (-1 + intNewLength) To (1 + par_intColumnIndex) Step -1
            ''Move the object references to the right (new-higher index). 
            ''
            ''The qualification of "Step -1" makes the index run from a large value to a smaller value.
            ''
            mod_array_RSCColumns(intIndex) = mod_array_RSCColumns(-1 + intIndex)

            ''
            ''Move the columns to the right, to make room for the new column. 
            ''
            mod_array_RSCColumns(intIndex).Left += (intNewColumnWidth + mc_ColumnMarginGap)

        Next intIndex

        ''
        ''Step 2 of 5.  Make a new column.   
        ''
        ''
        Dim intNextColumnPropertyLeft As Integer
        Dim objColumnAdjacent As RSCFieldColumn = Nothing

        If (par_intColumnIndex > 0) Then
            objColumnAdjacent = mod_array_RSCColumns(-1 + par_intColumnIndex)
        Else
            objColumnAdjacent = mod_array_RSCColumns(+1 + par_intColumnIndex)
        End If

        newRSCColumn = GenerateRSCFieldColumn_General(par_intColumnIndex,
                                                    intNewColumnPropertyLeft,
                                                    intNextColumnPropertyLeft,
                                                    objColumnAdjacent)

        ''
        ''Step 3 of 5. 
        ''
        newRSCColumn.Top = RscFieldColumn1.Top
        ''April 1st 2022 ''newRSCColumn.ListOfColumnsToBumpRight = New List(Of RSCFieldColumn)
        Dim list_columnsToBumpRight As New List(Of RSCFieldColumn)

        For intIndex As Integer = (1 + par_intColumnIndex) To (intNewLength - 1)
            ''
            ''Move the columns to the right, to make room for the new column. 
            ''
            ''----With newRSCColumn.ListOfColumnsToBumpRight
            With list_columnsToBumpRight
                .Add(mod_array_RSCColumns(intIndex))
            End With

            ''Added 4/1/2022 thomas downes 
            newRSCColumn.AddBumpColumn(mod_array_RSCColumns(intIndex))

        Next intIndex

        ''
        ''This will set the MoveAndResizeControls_Monem functionality as well. 
        ''
        newRSCColumn.ListOfColumnsToBumpRight = list_columnsToBumpRight

        ''
        ''Step 4 of 5. 
        ''

        ''
        ''Step 5 of 5. 
        ''


    End Sub ''End of "Public Sub InsertNewColumnByIndex(Me.ColumnIndex)"

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
End Class
