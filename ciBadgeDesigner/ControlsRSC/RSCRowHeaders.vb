''
''Added 2/21/2022 td
''
Imports __RSCWindowsControlLibrary ''Added 3/20/2022 Thomas Downes
Imports ciBadgeDesigner
Imports ciBadgeFields ''Added 3/10/2.0.2.2. thomas downes
Imports ciBadgeInterfaces ''Added 3/11/2022 t__homas d__ownes
Imports ciBadgeCachePersonality ''Added 3/14/2.0.2.2. t.//downes
Imports System.Drawing ''Added 3/20/2022 thomas downes
Imports __RSC_Error_Logging
Imports ciBadgeRecipients

Public Class RSCRowHeaders
    ''
    ''Added 2/21/2022 td
    ''
    Public ParentForm_DesignerDialog As Form ''ciBadgeDesigner.DialogEditRecipients 
    Public ParentRSCSpreadsheet As RSCFieldSpreadsheet ''Added 4/29/2022 thomas downes
    Public Designer As ClassDesigner ''Added 3/10/2022 td
    Public ElementsCache_Deprecated As ciBadgeCachePersonality.ClassElementsCache_Deprecated ''Added 3/10/2022 td
    Public ColumnDataCache As CacheRSCFieldColumnWidthsEtc ''ClassColumnWidthsEtc ''Added 3/15/2022 td
    ''Probably not good to have circular references.3/25/2022 ''Public RSCSpreadsheet As RSCFieldSpreadsheet ''Added 3/24/2022 thomas downes
    Public ListRecipients As List(Of ciBadgeRecipients.ClassRecipient) ''Added 5/14/2022 td

    Public EmphasisRowIndex_Start As Integer = -1 ''Added 5/01/2022 thomas d.
    Public EmphasisRowIndex_End As Integer = -1 ''Added 5/01/2022 thomas d.

    Private mod_ctlLasttouched As New ClassLastControlTouched ''Added 1/4/2022 td
    Private mod_eventsSingleton As New GroupMoveEvents_Singleton(Me.Designer, False, True) ''Added 1/4/2022 td  
    Private mod_colorOfColumnsBackColor As System.Drawing.Color = Drawing.Color.AntiqueWhite ''Added 3/13/2022 thomas downes

    ''Added 4/29/2022 td
    Private mod_colorHeadersBackcolor_NoEmphasis As System.Drawing.Color = System.Drawing.SystemColors.ButtonFace
    Private mod_colorHeadersBackcolor_WithEmphasis As System.Drawing.Color = System.Drawing.Color.Cyan ''5/13/2022 .Gray

    ''Probably not needed. 5/2023 Private mod_array_RSCColumns As RSCFieldColumnV1() ''Added 3/14/2022 td

    Private Const mc_ColumnWidthDefault As Integer = 72 ''Added 3/20/2022 td
    Private Const mc_ColumnMarginGap As Integer = 3 ''---4 ''Added 3/20/2022 td
    Private Const mod_c_intPixelsFromRowToRow As Integer = 24 ''Added 4/04/2022 td
    Private mod_intPixelsFromRowToRow As Integer = 0 ''Added 4/04/2022 td
    ''Added 4/04/2022 thomas downes
    ''4/5/2022 Private mod_listTextboxesByRow As New Dictionary(Of Integer, TextBox)
    ''5/14/2022 td''Private mod_listTextboxesByRow As New Dictionary(Of Integer, RSCRowHeader)

    ''
    ''Should be replace this structure with a doubly-linked list?  ---5/17/2023 
    ''
    ''Not needed''Private mod_listRowHeadersByRow As New Dictionary(Of Integer, RSCRowHeader)

    Private mod_columnWidthAndData As ClassRSCColumnWidthAndData ''Added 6/22/2022 & 3/18/2022  

    ''Added 10/06/2023 thomas downes
    ''Private textHeader2 As RSCRowHeader
    ''Private textHeader3 As RSCRowHeader
    ''Private textHeader4 As RSCRowHeader
    ''Private textHeader5 As RSCRowHeader
    ''Private textHeader6 As RSCRowHeader
    ''Private textHeader7 As RSCRowHeader
    ''Private textHeader8 As RSCRowHeader
    ''Private textHeader9 As RSCRowHeader
    ''Private textHeader10 As RSCRowHeader
    ''Private textHeader11 As RSCRowHeader
    ''Private textHeader12 As RSCRowHeader
    ''Private textHeader13 As RSCRowHeader
    ''Private textHeader14 As RSCRowHeader
    ''Private textHeader15 As RSCRowHeader
    ''Private textHeader16 As RSCRowHeader
    ''Private textHeader17 As RSCRowHeader
    Private mod_rowHeaderFirst_Factory As RSCRowHeader = textRowHeader1
    Private mod_rowHeaderLast As RSCRowHeader = textRowHeader1
    Private mod_iCountOfRows As Integer ''Added 10/6/2023
    ''

    ''Added 4/04/2022 thomas downes
    ''Private Structure StructLabelAndRowSeparator
    ''    Public Cellbox As TextBox
    ''    Public BottomBar As PictureBox
    ''End Structure
    ''4/5/2022 Private mod_listTextAndBarByRow As New Dictionary(Of Integer, StructLabelAndRowSeparator)
    ''4/6/2022 Private mod_listTextAndBarByRow As New Dictionary(Of Integer, StructLabelAndRowSeparator)


    Public Property PixelsFromRowToRow() As Integer
        Get
            ''Added 4/05/2022
            If (0 = mod_intPixelsFromRowToRow) Then
                mod_intPixelsFromRowToRow = mod_c_intPixelsFromRowToRow
            End If
            Return mod_intPixelsFromRowToRow
        End Get
        Set(value As Integer)
            ''Added 4/05/2022
            mod_intPixelsFromRowToRow = value
        End Set
    End Property


    Public Property ColumnWidthAndData() As ClassRSCColumnWidthAndData ''Added 3/15/2022 td
        ''Added 6/22/2022 & 3/18/2022 thomas 
        Get
            ''Added 6/22/2022 & 3/18/2022 thomas
            ''  Probably only for testing!!
            Return mod_columnWidthAndData
        End Get
        Set(value As ClassRSCColumnWidthAndData) ''---As ClassColumnWidthAndData)
            ''Added 6/22/2022 & 3/18/2022 thomas 
            mod_columnWidthAndData = value
        End Set
    End Property


    Public Function GetRowCount(Optional pbPerformLoopToCount As Boolean = True) As Integer
        ''Added 11/08/2023 td
        Return CountOfRows(pbPerformLoopToCount)
    End Function

    Public Function CountOfRows(Optional pbPerformLoopToCount As Boolean = True) As Integer
        ''
        ''Added 4/3/2022 thomas downes  
        ''
        ''4/5/2022 Dim listBoxes As List(Of TextBox)
        ''10/24/2023 Dim listBoxes As List(Of RSCRowHeader) ''4/5/2022 TextBox)
        ''10/24/2023 Const c_boolSkipSorting As Boolean = True
        ''10/24/2023 listBoxes = ListOfRowHeaders_TopToBottom(c_boolSkipSorting)
        ''10/24/2023 Return listBoxes.Count

        Dim intCountRows As Integer = 0
        Dim default_count As Integer = mod_rowHeaderFirst_Factory.FactoryMaxIndex
        ''Not needed. Dim currentRow As RSCRowHeader = mod_rowHeaderFirst_Factory
        Dim currentRow As IDoublyLinkedItem = mod_rowHeaderFirst_Factory

        If (pbPerformLoopToCount) Then
            ''Go down the doubly-linked list of row-headers. 
            While (currentRow IsNot Nothing)
                intCountRows += 1
                ''11/2023 currentRow = currentRow.RowHeaderNextBelow
                currentRow = currentRow.DLL_GetItemNext()
            End While
            If (intCountRows <> default_count) Then Debugger.Break()
            Return intCountRows
        Else
            Return mod_rowHeaderFirst_Factory.FactoryMaxIndex

        End If ''ENd of ""If (pbPerformLoopToCount) Then ... Else""

    End Function ''End of ""Public Function CountOfRows() As Integer""



    Public Function CountOfColumnsWithoutFields(Optional ByRef pref_intCountAllColumns As Integer = 0) As Integer
        ''
        '' Added 5/25/2022  
        ''
        Dim intCountCols As Integer = 0

        intCountCols = Me.ParentRSCSpreadsheet.CountOfColumnsWithoutFields(pref_intCountAllColumns)

        Return intCountCols

    End Function ''End of ""Public Function CountOfColumnsWithoutFields() As Integer""



    ''5/17/2023 td Public Function ListOfColumns() As List(Of RSCFieldColumnV1)
    ''5/17/2023 td Public Function ListOfColumns() As List(Of RSCFieldColumnV1)
    ''
    ''    ''Added 3/21/2022 thomas downes
    ''    ''\\---Return New List(Of RSCFieldColumn)(mod_array_RSCColumns)
    ''    Dim oList As List(Of RSCFieldColumnV1)
    ''    oList = New List(Of RSCFieldColumnV1)(mod_array_RSCColumns)
    ''    oList.Remove(Nothing) ''Item #0 is Nothing, so let's omit the Null reference. 
    ''    Return oList
    ''
    ''End Function ''ENd of "Public Function ListOfColumns() As List(Of RSCFieldColumn)"


    Public Function GetRowHeaderByRowIndex(par_intRowIndex As Integer) As RSCRowHeader
        ''
        ''Added 5/13/2022 td
        ''
        Dim eachRowHeader As IDoublyLinkedItem ''RSCRowHeader
        Dim resultRowHeader As RSCRowHeader ''Added 11/8/2023
        Dim intEachRowIndex As Integer ''10/6/2023
        Dim bStillOtherRows As Boolean = True ''Added 10/6/2023
        Dim bReachedRowIndex As Boolean ''Added 10/6/2023 

        eachRowHeader = textRowHeader1 ''Initialize.

        Try
            ''objRowHeader =
            ''   mod_listRowHeadersByRow.Item(par_intRowIndex)
            intEachRowIndex = 1
            Do While (bStillOtherRows) ''(intEachRowIndex < mod_iCountOfRows)

                bReachedRowIndex = (intEachRowIndex = par_intRowIndex)
                If (bReachedRowIndex) Then
                    resultRowHeader = DirectCast(eachRowHeader, RSCRowHeader)
                    Return resultRowHeader
                End If ''End of "If (bReachedRowIndex) Then"

                intEachRowIndex += 1
                ''11/2023 eachRowHeader = eachRowHeader.RowHeaderNextBelow
                eachRowHeader = eachRowHeader.DLL_GetItemNext()

                bStillOtherRows = (intEachRowIndex < mod_iCountOfRows)
            Loop ''End of Do While (bStillOtherRows)

        Catch ex_Get As System.Collections.Generic.KeyNotFoundException
            ''Added 8/30/2023 td
            System.Diagnostics.Debugger.Break()
            RSCErrorLogging.Log(92, "GetRowHeaderByRowIndex", ex_Get.Message)

        End Try

        Return Nothing ''objRowHeader

    End Function ''End of""Public Function GetRowHeaderByRowIndex()"


    Public Shared Function GetRSCRowHeaders(par_designer As ClassDesigner,
                                       par_formParent As Form,
                                      par_nameOfControl As String,
                                      par_objSpreadsheet As RSCFieldSpreadsheet) As RSCRowHeaders
        ''
        ''Added 3/21/2022 td
        ''
        Dim objParametersGetElementCtl As ClassGetElementControlParams
        objParametersGetElementCtl = par_designer.GetParametersToGetElementControl()
        ''May 29 2022
        objParametersGetElementCtl.ElementObject = New ciBadgeElements.ClassElementBase()

        Return GetRSCRowHeaders(objParametersGetElementCtl, par_formParent, par_nameOfControl,
                                    par_designer, False,
                                    CType(par_designer.ControlLastTouched, ILastControlTouched),
                                    CType(par_designer, IRecordElementLastTouched),
                                    par_designer.GroupMoveEvents,
                                    par_objSpreadsheet)

    End Function ''End of "Public Shared Function GetRSCRowHeaders"

    Public Shared Function GetRSCRowHeaders(par_parametersGetElementControl As ClassGetElementControlParams,
                                       par_formParent As Form,
                                      par_nameOfControl As String,
                                      par_iLayoutFun As ILayoutFunctions,
                                      par_bProportionSizing As Boolean,
                                      par_iControlLastTouched As ILastControlTouched,
                                     par_iRecordLastControl As IRecordElementLastTouched,
                                     par_oMoveEventsForGroupedCtls As GroupMoveEvents_Singleton,
                                     par_oSpreadsheet As RSCFieldSpreadsheet) _
                                     As RSCRowHeaders
        ''
        ''Added 3/20/2022 td
        ''
        ''Unused. Jan17 2022''Const c_enumElemType As EnumElementType = EnumElementType.Portrait
        Const bAddFunctionalitySooner As Boolean = False
        Const bAddFunctionalityLater As Boolean = True

        Dim typeOps As Type
        Dim objOperations As Object ''Added 12/29/2021 td 
        Dim objOperationsRSCRowHeaders As Operations_RSCRowHeaders ''Modified 3/13/2022 td 
        Dim sizeElementPortrait As New Size() ''Added 1/26/2022 td

        ''Added 1/5/2022 td
        ''If (par_field Is Nothing) Then Throw New Exception("The Field is missing!")

        ''Instantiate the Operations Object. 
        ''
        objOperationsRSCRowHeaders = New Operations_RSCRowHeaders() ''Added 3/20/2022 td
        typeOps = objOperationsRSCRowHeaders.GetType()
        objOperations = objOperationsRSCRowHeaders

        If (objOperations Is Nothing) Then
            ''Added 12/29/2021
            Throw New Exception("Ops is Nothing, so I guess Element Type is Undetermined.")
        End If ''end of "If (objOperations Is Nothing) Then"

        ''Added 12/2/2022 td
        Dim enumElementType_Enum As EnumElementType = EnumElementType.RSCRowHeaders

        ''Create the control. 
        Dim CtlRowHeaders = New RSCRowHeaders(par_parametersGetElementControl,
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

        With CtlRowHeaders
            .Name = par_nameOfControl
            ''1/11/2022''If (bAddFunctionalityLater) Then .AddMoveability(par_oMoveEvents, par_iLayoutFun)
            ''03/20/2022 ''If (bAddFunctionalityLater) Then .AddMoveability(par_iLayoutFun,
            ''                               par_oMoveEventsForGroupedCtls, Nothing)
            If (bAddFunctionalityLater) Then .AddClickability()

            .RightclickMouseInfo = objOperationsRSCRowHeaders ''Added 3/5/2022 td

        End With ''eNd of "With CtlPortrait1"

        ''
        ''Specify the current element to the Operations object. 
        ''
        With objOperationsRSCRowHeaders

            .CtlCurrentControl = CtlRowHeaders
            .CtlCurrentElement = CtlRowHeaders
            ''.Designer = par_oMoveEventsForGroupedCtls.
            .Designer = par_parametersGetElementControl.DesignerClass
            ''.ElementInfo_Base = Nothing ''3/9/2022 t*d*''par_elementPortrait
            .ElementsCacheManager = par_parametersGetElementControl.ElementsCacheManager
            ''Feb3 2022 td''.Element_Type = Enum_Elem entType.StaticGraphic
            .Element_Type = Enum_ElementType.RSCSheetSpreadsheet ''Added 3/20/2022 thomas d.
            .EventsForMoveability_Group = Nothing ''par_oMoveEventsForGroupedCtls
            .EventsForMoveability_Single = Nothing
            ''Added 1/24/2022 thomas downes
            .LayoutFunctions = .Designer

            ''Added 3/20/2022 thomas dRRoRRwRRnRReRRsRR
            .ParentSpreadsheet = par_oSpreadsheet
            .ParentRowHeaders = CtlRowHeaders ''Added 5/2/2022 td
            ''.ColumnIndex = par_intColumnIndex

        End With ''End of "With objOperationsRSCRowHeaders"

        ''
        ''Return output value.
        ''
        Return CtlRowHeaders

    End Function ''end of "Public Shared Function GetRSCRowHeaders() As RSCRowHeaders"


    Public Function GetRowIndex_OfHeader(par_oRowHeader As RSCRowHeader) As Integer
        ''
        ''Added 4/25/2025 thomas downes
        ''
        ''---For Each obj_header As RSCRowHeader In mod_listTextboxesByRow.
        Dim intRowIndex_SLOW As Integer = 1
        Dim intRowIndex_FAST As Integer
        Dim intCountRowsAbove_FAST As Integer = 0
        Const DO_IT_FAST_AND_SMART As Boolean = True
        Const DO_IT_SLOW_AND_CAREFUL As Boolean = True
        Dim boolDoItBothWays As Boolean = (DO_IT_FAST_AND_SMART And DO_IT_SLOW_AND_CAREFUL)

        If (mod_rowHeaderFirst_Factory Is par_oRowHeader) Then
            Return 1
        End If

        If (DO_IT_FAST_AND_SMART) Then
            ''
            ''This is the _FAST_REVERSE way... we BEGIN at the 
            ''   given Row Header & move up!!   We count the row-headers ABOVE
            ''   the given Row Header.
            ''
            ''11/2023 Dim eachRowHeader_FAST_REVERSE As RSCRowHeader
            Dim eachRowHeader_FAST_REVERSE As IDoublyLinkedItem ''RSCRowHeader
            ''OFF-BY-ONE ERROR 10/2023 eachRowHeader_FAST_REVERSE = par_oRowHeader
            ''11/2023 eachRowHeader_FAST_REVERSE = par_oRowHeader.RowHeaderNextAbove ''Initialize to the one above.
            eachRowHeader_FAST_REVERSE = par_oRowHeader.DLL_GetItemPrior() ''Initialize to the one above.
            Dim bContinue_FAST_REVERSE As Boolean = True ''Initialize.
            intCountRowsAbove_FAST = 0 ''Initialize.

            Do While bContinue_FAST_REVERSE
                If (eachRowHeader_FAST_REVERSE Is Nothing) Then
                    ''By cycling upwards, we've reached the very top row-header. 
                    bContinue_FAST_REVERSE = False
                Else
                    intCountRowsAbove_FAST += 1
                    ''Prepare for the next iteration.
                    ''  We go to the row header ABOVE ("ItemPrior"). 
                    ''11/2023 eachRowHeader_FAST_REVERSE =
                    ''          eachRowHeader_FAST_REVERSE.RowHeaderNextAbove
                    eachRowHeader_FAST_REVERSE =
                        eachRowHeader_FAST_REVERSE.DLL_GetItemPrior()

                End If ''End of If (eachRowHeader_FAST_REVERSE Is Nothing) Then...Else...
            Loop ''End of ""Do While bContinue""

            ''---------------------DIFFICULT & CONFUSING------------------------------------------
            ''-----THE NUMBER OF ROW-HEADERS ABOVE THE GIVEN ROW-HEADER EQUALS (ROW INDEX - 1).
            ''-----Thomas Downes, 10/24/2013
            intRowIndex_FAST = (intCountRowsAbove_FAST + 1)
            ''------------------------------------------------------------------------------------
            If (Not boolDoItBothWays) Then Return intRowIndex_FAST
        End If ''End of ""If (DO_IT_FAST_AND_SMART) Then

        If (DO_IT_SLOW_AND_CAREFUL) Then
            ''
            ''This is the _SLOW way, NOT a clever way.
            ''
            ''11/2023 Dim eachRowHeader_SLOW As RSCRowHeader = mod_rowHeaderFirst_Factory
            Dim eachRowHeader_SLOW As IDoublyLinkedItem = mod_rowHeaderFirst_Factory
            Dim bContinue_SLOW As Boolean = True
            Dim bMatchesGiven_SLOW As Boolean = False

            Do While bContinue_SLOW
                bMatchesGiven_SLOW = (eachRowHeader_SLOW Is par_oRowHeader)
                If (bMatchesGiven_SLOW) Then
                    bContinue_SLOW = False
                    ''10/2023 Return intRowIndex_SLOW
                ElseIf (eachRowHeader_SLOW Is Nothing) Then
                    bContinue_SLOW = False
                    Debugger.Break()
                    ''Throw New Exception("Suprisingly, the row header is not found")
                Else
                    intRowIndex_SLOW += 1
                    ''11/2023 eachRowHeader_SLOW = eachRowHeader_SLOW.RowHeaderNextBelow
                    eachRowHeader_SLOW = eachRowHeader_SLOW.DLL_GetItemNext()
                End If ''End of ""If (bMatchesGiven_SLOW) Then ... ElseIf... Else..."
            Loop ''End of ""Do While bContinue""
            If (Not boolDoItBothWays) Then Return intRowIndex_SLOW
        End If ''End of ""If (DO_IT_SLOW_AND_CAREFUL) Then""

        ''
        ''Consistency check!
        ''
        If (boolDoItBothWays) Then
            If (intRowIndex_FAST <> intRowIndex_SLOW) Then
                Debugger.Break()
                ''Throw New Exception("The row counts are not matching as expected.
            End If ''If (intRowIndex_FAST <> intRowIndex_SLOW) Then
            Return intRowIndex_FAST

        ElseIf (DO_IT_FAST_AND_SMART) Then
            Return intRowIndex_FAST

        ElseIf (DO_IT_SLOW_AND_CAREFUL) Then
            Return intRowIndex_SLOW

        End If ''ENd of ""If (boolDoItBothWays) Then""

        ''Added 8/29/2023
        ''If mod_listRowHeadersByRow.Count = 0 Then
        ''    System.Diagnostics.Debugger.Break()
        ''End If
        ''
        ''''Added 4/25/2022 td
        ''For Each each_key As Integer In mod_listRowHeadersByRow.Keys
        ''    each_header = mod_listRowHeadersByRow.Values(each_key)
        ''    If (each_header Is par_oRowHeader) Then
        ''        Return CInt(each_key)
        ''    End If ''End of ""If (each_header Is par_oRowHeader) Then""
        ''Next each_key ''----obj_header
        ''Return -1

    End Function ''End of ""Public Function GetRowIndex_OfHeader(par_oRowHeader As RSCRowHeader) As Integer""


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
        MyBase.New(EnumElementType.RSCRowHeaders,
                   par_parameters.ElementObject,
                   par_parameters.ElementsCache,
                   par_oParentForm,
                   pboolResizeProportionally,
                        par_iLayoutFun, par_iRefreshPreview, par_iSizeDesired,
                        par_operationsType, par_operationsAny,
                        pboolAddMoveability, False, pboolAddClickability,
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

        ''
        ''Added 4/4/2022 thomas downes
        ''
        ''April 6, 2022 td ''With mod_listTextAndBarByRow

        ''
        '' 1, 2, 3
        ''
        textRowHeader1.RowIndex_Denigrated = 1
        textRowHeader1.Text = "1"
        ''Allow code to navigate to this parent collection.
        textRowHeader1.ParentRSCRowHeaders = Me

        ''Added 9/18/2023 td
        textRowHeader1.ParentRSCSpreadsheet = Me.ParentRSCSpreadsheet

        ''textRowHeader1.Height = mod_c_intPixelsFromRowToRow ''+ 1 ''24
        ''10/2023 td''mod_listRowHeadersByRow.Add(1, textRowHeader1)
        mod_rowHeaderFirst_Factory = textRowHeader1

        ''Dim struct1 As New StructLabelAndRowSeparator()
        ''struct1.Cellbox = textRowHeader1
        ''struct1.BottomBar = PictureBox1a
        ''.Add(1, struct1)

        ''Sept18 2023 textRowHeader2.RowIndex = 2
        ''Sept18 2023 textRowHeader2.Text = "2"
        ''Sept18 2023 textRowHeader2.ParentRSCRowHeaders = Me
        ''textRowHeader2.Height = mod_c_intPixelsFromRowToRow ''+ 1 ''24
        ''Sept18 2023 mod_listRowHeadersByRow.Add(2, textRowHeader2)

        ''Dim struct2 As New StructLabelAndRowSeparator()
        ''struct2.Cellbox = textRowHeader2
        ''struct2.BottomBar = PictureBox2a
        ''.Add(2, struct2)

        ''Sept18 2023 textRowHeader3.RowIndex = 3
        ''Sept18 2023 textRowHeader3.Text = "3"
        ''Sept18 2023 textRowHeader3.ParentRSCRowHeaders = Me
        ''textRowHeader3.Height = mod_c_intPixelsFromRowToRow ''+ 1 ''24
        ''10/2023''mod_listRowHeadersByRow.Add(3, textRowHeader3)


        ''Dim struct3 As New StructLabelAndRowSeparator()
        ''struct3.Cellbox = textRowHeader3
        ''struct3.BottomBar = PictureBox3a
        ''.Add(3, struct3)

        ''
        '' 4, 5, 6
        ''
        ''10/2023 td''ctextRowHeader4.RowIndex = 4
        ''10/2023 td''textRowHeader4.Text = "4"
        ''10/2023 td''textRowHeader4.ParentRSCRowHeaders = Me
        ''textRowHeader4.Height = mod_c_intPixelsFromRowToRow ''+ 1 ''24
        ''10/2023 td''mod_listRowHeadersByRow.Add(4, textRowHeader4)
        ''Dim struct4 As New StructLabelAndRowSeparator()
        ''struct4.Cellbox = textRowHeader4
        ''struct4.BottomBar = PictureBox4a
        ''.Add(4, struct4)

        ''10/2023 td''textRowHeader5.RowIndex = 5
        ''10/2023 td''textRowHeader5.Text = "5"
        ''10/2023 td''textRowHeader5.ParentRSCRowHeaders = Me
        ''10/2023 td''mod_listRowHeadersByRow.Add(5, textRowHeader5)
        ''Dim struct5 As New StructLabelAndRowSeparator()
        ''struct5.Cellbox = textRowHeader5
        ''struct5.BottomBar = PictureBox5a
        ''.Add(5, struct5)

        ''''10/2023 td
        ''textRowHeader6.RowIndex = 6
        ''textRowHeader6.Text = "6"
        ''textRowHeader6.ParentRSCRowHeaders = Me
        ''mod_listRowHeadersByRow.Add(6, textRowHeader6)
        ''''Dim struct6 As New StructLabelAndRowSeparator()
        ''''struct6.Cellbox = textRowHeader6
        ''''struct6.BottomBar = PictureBox6a
        ''''.Add(6, struct6)

        ''''
        '''' 7, 8, 9
        ''''
        ''''10/2023 td
        ''textRowHeader7.RowIndex = 7
        ''textRowHeader7.Text = "7"
        ''textRowHeader7.ParentRSCRowHeaders = Me
        ''mod_listRowHeadersByRow.Add(7, textRowHeader7)
        ''''Dim struct7 As New StructLabelAndRowSeparator()
        ''''struct7.Cellbox = textRowHeader7
        ''''struct7.BottomBar = PictureBox7a
        ''''.Add(7, struct7)

        ''''10/2023 td
        ''textRowHeader8.RowIndex = 8
        ''textRowHeader8.Text = "8"
        ''textRowHeader8.ParentRSCRowHeaders = Me
        ''mod_listRowHeadersByRow.Add(8, textRowHeader8)
        ''''Dim struct8 As New StructLabelAndRowSeparator()
        ''''struct8.Cellbox = textRowHeader8
        ''''struct8.BottomBar = PictureBox8a
        ''''.Add(8, struct8)

        ''''10/2023 td
        ''textRowHeader9.RowIndex = 9
        ''textRowHeader9.Text = "9"
        ''textRowHeader9.ParentRSCRowHeaders = Me
        ''mod_listRowHeadersByRow.Add(9, textRowHeader9)
        ''''Dim struct9 As New StructLabelAndRowSeparator()
        ''''struct9.Cellbox = textRowHeader9
        ''''struct9.BottomBar = PictureBox9a
        ''''.Add(9, struct9)

        ''''
        '''' 10, 11, 12
        ''''
        ''''10/2023 td
        ''textRowHeader10.RowIndex = 10
        ''textRowHeader10.Text = "10"
        ''textRowHeader10.ParentRSCRowHeaders = Me
        ''mod_listRowHeadersByRow.Add(10, textRowHeader10)
        ''''Dim struct10 As New StructLabelAndRowSeparator()
        ''''struct10.Cellbox = textRowHeader10
        ''''struct10.BottomBar = PictureBox10a
        ''''.Add(10, struct10)

        ''''10/2023 td
        ''textRowHeader11.RowIndex = 11
        ''textRowHeader11.Text = "11"
        ''textRowHeader11.ParentRSCRowHeaders = Me
        ''mod_listRowHeadersByRow.Add(11, textRowHeader11)
        ''''Dim struct11 As New StructLabelAndRowSeparator()
        ''''struct11.Cellbox = textRowHeader11
        ''''struct11.BottomBar = PictureBox11a
        ''''.Add(11, struct11)

        ''''10/2023 td
        ''textRowHeader12.RowIndex = 12
        ''textRowHeader12.Text = "12"
        ''textRowHeader12.ParentRSCRowHeaders = Me
        ''mod_listRowHeadersByRow.Add(12, textRowHeader12)
        ''''Dim struct12 As New StructLabelAndRowSeparator()
        ''''struct12.Cellbox = textRowHeader12
        ''''struct12.BottomBar = PictureBox12a
        ''''.Add(12, struct12)

        ''''
        '''' 13, 14, 15
        ''''
        ''''10/2023 td
        ''textRowHeader13.RowIndex = 13
        ''textRowHeader13.Text = "13"
        ''textRowHeader13.ParentRSCRowHeaders = Me
        ''mod_listRowHeadersByRow.Add(13, textRowHeader13)
        ''''Dim struct13 As New StructLabelAndRowSeparator()
        ''''struct13.Cellbox = textRowHeader13
        ''''struct13.BottomBar = PictureBox13a
        ''''.Add(13, struct13)

        ''''10/2023 td
        ''textRowHeader14.RowIndex = 14
        ''textRowHeader14.Text = "14"
        ''textRowHeader14.ParentRSCRowHeaders = Me
        ''mod_listRowHeadersByRow.Add(14, textRowHeader14)
        ''''Dim struct14 As New StructLabelAndRowSeparator()
        ''''struct14.Cellbox = textRowHeader14
        ''''struct14.BottomBar = PictureBox14a
        ''''.Add(14, struct14)

        ''''10/2023 td
        ''textRowHeader15.RowIndex = 15
        ''textRowHeader15.Text = "15"
        ''textRowHeader15.ParentRSCRowHeaders = Me
        ''mod_listRowHeadersByRow.Add(15, textRowHeader15)
        ''''Dim struct15 As New StructLabelAndRowSeparator()
        ''''struct15.Cellbox = textRowHeader15
        ''''struct15.BottomBar = PictureBox15a
        ''''.Add(15, struct15)

        ''''
        '''' 16, 17, 18
        ''''
        ''''10/2023 td
        ''textRowHeader16.RowIndex = 16
        ''textRowHeader16.Text = "16"
        ''textRowHeader16.ParentRSCRowHeaders = Me
        ''mod_listRowHeadersByRow.Add(16, textRowHeader16)
        ''''Dim struct16 As New StructLabelAndRowSeparator()
        ''''struct16.Cellbox = textRowHeader16
        ''''struct16.BottomBar = PictureBox16a
        ''''.Add(16, struct16)

        ''''10/2023 td
        ''textRowHeader17.RowIndex = 17
        ''textRowHeader17.Text = "17"
        ''textRowHeader17.ParentRSCRowHeaders = Me
        ''mod_listRowHeadersByRow.Add(17, textRowHeader17)
        ''''Dim struct17 As New StructLabelAndRowSeparator()
        ''''struct17.Cellbox = textRowHeader17
        ''''struct17.BottomBar = PictureBox17a
        ''''.Add(17, struct17)

        ''''10/2023 td
        ''textRowHeader18.RowIndex = 18
        ''textRowHeader18.Text = "18"
        ''textRowHeader18.ParentRSCRowHeaders = Me
        ''mod_listRowHeadersByRow.Add(18, textRowHeader18)
        ''''Dim struct18 As New StructLabelAndRowSeparator()
        ''''struct18.Cellbox = textRowHeader18
        ''''struct18.BottomBar = PictureBox18a
        ''''.Add(18, struct18)

        ''''
        '''' 19
        ''''
        ''''10/2023 td
        ''textRowHeader19.RowIndex = 19
        ''textRowHeader19.Text = "19"
        ''textRowHeader19.ParentRSCRowHeaders = Me
        ''mod_listRowHeadersByRow.Add(19, textRowHeader19)
        ''''Dim struct19 As New TextboxAndRowSeparator()
        ''''struct19.Cellbox = TextBox19a
        ''''struct19.BottomBar = PictureBox19a
        ''''.Add(19, struct19)

        ''''April 6, 2022 td ''End With ''End of "With mod_listTextAndBarByRow" 


    End Sub ''End of ""Public Sub New(par_oParentForm As .....)"


    Public Function GetFirstTextbox() As RSCRowHeader ''4/5/2022 TextBox
        ''
        ''Added 4/04/2022 thomas downes
        ''
        ''10/2023 Dim objFirstTextbox As RSCRowHeader ''4/5/2022 TextBox
        ''10/2023 objFirstTextbox = ListOfRowHeaders_TopToBottom().First()
        ''10/2023 Return objFirstTextbox
        Return mod_rowHeaderFirst_Factory

    End Function ''End of ""Public Function GetFirstTextbox() As TextBox""


    Public Function GetRecipient_ByGuid(par_guid As Guid) As RSCRowHeader ''4/5/2022 TextBox
        ''
        ''Added 4/04/2022 thomas downes
        ''
        Dim each_header As RSCRowHeader ''4/5/2022 TextBox
        Dim each_Guid_matches As Boolean

        ''11/8/2023 For Each each_header In ListOfRowHeaders_TopToBottom()
        ''Return objFirstTextbox
        each_header = mod_rowHeaderFirst_Factory
        Do Until (each_header Is Nothing)

            each_Guid_matches = (each_header.Recipient.ID_Guid = par_guid)
            If (each_Guid_matches) Then Return each_header

            ''Prepare for next loop.
            each_header = DirectCast(each_header.DLL_GetItemNext(), RSCRowHeader)

        Loop ''11/2023 Next each_header

        Return Nothing

    End Function ''End of ""Public Function GetRecipient_ByGuid(par_guid As Guid) As RSCRowHeader ""


    Public Function GetRecipient_ByGuid6(par_strGuidChars6 As String) As RSCRowHeader ''4/5/2022 TextBox
        ''
        ''Added 4/04/2022 thomas downes
        ''
        Dim each_header As RSCRowHeader ''4/5/2022 TextBox
        Dim each_header_Next As RSCRowHeader ''4/5/2022 TextBox
        Dim each_Guid6_matches As Boolean

        each_header = mod_rowHeaderFirst_Factory
        Do Until (each_header Is Nothing)

            each_Guid6_matches = (each_header.Recipient.ID_Guid6chars = par_strGuidChars6)
            If (each_Guid6_matches) Then Return each_header

            ''
            ''Prepare for next loop.
            ''
            each_header_Next = DirectCast(each_header.DLL_GetItemNext(), RSCRowHeader)
            each_header = each_header_Next

        Loop ''11/2023 Next each_header

        Return Nothing

        ''Dim each_matches As Boolean
        ''For Each each_header In ListOfRowHeaders_TopToBottom()
        ''    ''Return objFirstTextbox
        ''    each_matches = (each_header.Recipient.ID_Guid6chars = par_strGuidChars6)
        ''    If (each_matches) Then Return each_header
        ''11/2023
        ''Next each_header
        ''11/2023
        ''Return Nothing

    End Function ''End of ""Public Function GetRecipient_ByGuid6(par_strGuidChars6 As String) As RSCRowHeader ""


    Public Function GetListOfRecipients() As List(Of ClassRecipient)
        ''
        ''Added 8/31/2023  thomas Downes
        ''
        Dim listOfRecipients As New List(Of ClassRecipient)
        Dim eachRecipient As ClassRecipient
        Dim eachIsRowEmpty As Boolean

        mod_rowHeaderFirst_Factory.GetListOfRecipients_AllHdrs(listOfRecipients)

        ''For Each each_header In ListOfRowHeaders_TopToBottom()
        ''
        ''    eachIsRowEmpty = False
        ''    eachRecipient = each_header.GetRecipient(eachIsRowEmpty)
        ''
        ''    If (eachIsRowEmpty) Then
        ''        ''Don't add the blank recipient.
        ''    Else
        ''        listOfRecipients.Add(each_header.GetRecipient())
        ''    End If
        ''
        ''Next each_header

        Return listOfRecipients

    End Function ''End of ""Public Function GetListOfRecipients() As List(Of ClassRecipient)"" 


    Public Function GetRowHeader_ByIndex(par_intRowIndex As Integer) As RSCRowHeader
        ''
        ''Added 10/2023  
        ''
        Return mod_rowHeaderFirst_Factory.GetRowHeader_ByIndex(par_intRowIndex, True)

    End Function ''Public Function GetRowHeader_ByIndex 


    ''Public Function GetBottomBarForRow() As PictureBox
    ''    ''
    ''    ''Added 4/05/2022 td
    ''    ''
    ''    Dim objNewPicturebox As New PictureBox ''Added 3/29/2022 thomas downes
    ''    Dim objTopBottomBar As PictureBox

    ''    objTopBottomBar = mod_listTextAndBarByRow(1).BottomBar

    ''    With objNewPicturebox
    ''        .Left = objTopBottomBar.Left
    ''        .Width = objTopBottomBar.Width
    ''        .Height = objTopBottomBar.Height
    ''        .Anchor = objTopBottomBar.Anchor
    ''        .BackColor = objTopBottomBar.BackColor
    ''        .ForeColor = objTopBottomBar.ForeColor
    ''        .BorderStyle = objTopBottomBar.BorderStyle
    ''        .Font = objTopBottomBar.Font
    ''        ''---.Top = (textbox_BottomLast.Top + intTopGap)
    ''        .Visible = True
    ''    End With ''End of ""With objTextbox""

    ''    Return objNewPicturebox ''Oops!! Forgot this. ---4/05/2022 td

    ''End Function ''End of ""Public Function GetBottomBarForRow()""


    Public Sub AlignControlsWithSpreadsheet(par_controlColumnOne As RSCFieldColumnV2)
        ''
        ''Added 3/24/2022 td
        ''
        ''  The "Bottom Bars" ("Visual Bars") are the black-backcolor picture boxes which are
        ''  very "landscape"-shaped, i.e. are very wide and very short (less than 5 pixels high).
        ''  They are purely visual, i.e. only serve to create visually-obvious "rows" in the
        ''  spreadsheet.----3/25/2022
        ''
        ''March25 2022''Dim objSpreadsheet As RSCFieldSpreadsheet
        ''March25 2022''Dim objColumnOne As RSCFieldColumn
        ''4/09/2022 td ''Dim listBoxesColumn1 As List(Of TextBox)
        ''11/2023 td ''Dim listBoxesColumn1 As List(Of RSCDataCell)
        ''4/5/2022 td ''Dim listBoxesRowHdrs As List(Of TextBox)
        ''11/2023 td ''Dim listBoxesRowHdrs As List(Of RSCRowHeader)
        ''11/2023 td ''Dim listVisualBarsColumn1 As List(Of PictureBox)
        ''4/8/2022 Dim listVisualBarsRowHdrs As List(Of PictureBox)

        ''March25 2022''objSpreadsheet = Me.RSCSpreadsheet
        ''March25 2022''objColumnOne = objSpreadsheet.RscFieldColumn1
        ''objColumnOne.Refresh()
        ''March25 2022''listBoxesColumn1 = objColumnOne.ListOfTextboxes_TopToBottom
        ''March25 2022''listBoxesColumn1 = par_listColumnBoxes

        ''4/9/2022 td ''listBoxesColumn1 = par_controlColumnOne.ListOfTextboxes_TopToBottom()
        ''11/2023 td ''listBoxesColumn1 = par_controlColumnOne.ListOfRSCDataCells_TopToBottom()
        ''11/2023 td ''listBoxesRowHdrs = ListOfRowHeaders_TopToBottom()
        ''11/2023 td ''listVisualBarsColumn1 = par_controlColumnOne.ListOfBottomBars_TopToBottom()
        ''4/8/2022 listVisualBarsRowHdrs = ListOfBottomBars_TopToBottom()

        ''11/2023 td ''
        Dim topRowHeader As RSCRowHeader = mod_rowHeaderFirst_Factory
        Dim topColumnCell As RSCDataCell = par_controlColumnOne.RscDataCell1

        ''Major call.
        ''April 6, 2022 td ''AlignBottomBars(listVisualBarsColumn1, listVisualBarsRowHdrs, par_controlColumnOne)
        ''11/2023 td ''AlignTextboxes(listBoxesColumn1, listBoxesRowHdrs)
        AlignTextboxes(topColumnCell, topRowHeader)


    End Sub ''End of ""Public Sub AlignControlsWithSpreadsheet()""


    Public Sub EmphasizeRows_Highlight(pboolShiftKeyWasUsed As Boolean,
                                       par_intRowIndex_Start As Integer,
                                       Optional par_intRowIndex_End As Integer = -1)
        ''
        ''Added 4/28/2022 td
        ''
        Static stat_intRowIndex_Start As Integer
        Static stat_intRowIndex_End As Integer

        Dim boolPriorCallNeedsReversal As Boolean

        ''
        ''Step 1 of 3.  Reverse prior work, if needed.  
        ''
        boolPriorCallNeedsReversal = (stat_intRowIndex_Start > 0)
        If boolPriorCallNeedsReversal Then
            ''
            ''Undo the prior call's rows. 
            ''
            Me.EmphasizeRowHeaders_Undo(stat_intRowIndex_Start,
                                    stat_intRowIndex_End)
            Me.ParentRSCSpreadsheet.DeemphasizeRows_NoHighlight(stat_intRowIndex_Start,
                                                        stat_intRowIndex_End)
        End If ''End of ""If (boolPriorCallNeedsReversal) Then""

        ''
        ''Step 2 of 3.  Do the requested emphasis work.  
        ''
        If (pboolShiftKeyWasUsed) Then
            If (par_intRowIndex_End = -1 And stat_intRowIndex_Start > 0) Then
                ''We need to leverage the Static variables, in order to highlight all
                ''   headers in the range of rows (as determined by the user pressing
                ''   the keyboard's Shift key. ----
                par_intRowIndex_End = par_intRowIndex_Start
                par_intRowIndex_Start = stat_intRowIndex_Start
                If (par_intRowIndex_Start > par_intRowIndex_End) Then
                    Dim intRow_Temp As Integer
                    intRow_Temp = par_intRowIndex_End
                    par_intRowIndex_End = par_intRowIndex_Start
                    par_intRowIndex_Start = intRow_Temp
                End If ''End of ""If (par_intRowIndex_Start > par_intRowIndex_End) Then""
            End If ''end of "If (par_intRowIndex_End = -1 And stat_intRowIndex_Start > 0) Then"
        End If ''End of ""If (pboolShiftKeyWasUsed) Then""

        Me.EmphasizeRowHeaders(par_intRowIndex_Start,
                                        par_intRowIndex_End)
        Me.ParentRSCSpreadsheet.EmphasizeRows_Highlight(par_intRowIndex_Start,
                                                        par_intRowIndex_End)

        ''
        ''Step 3 of 3.  Save the row-range for the next call's Part 1. Deemphasize work.
        ''
        stat_intRowIndex_Start = par_intRowIndex_Start
        stat_intRowIndex_End = par_intRowIndex_End


    End Sub ''end of Public Sub EmphasizeRows_Highlight


    Public Sub SaveToRecipient(par_objRecipient As ciBadgeRecipients.ClassRecipient,
                               par_iRowIndex As Integer,
                               Optional ByRef pref_bAnyFailure As Boolean = False,
                               Optional ByRef pref_intCountFailures As Integer = 0,
                               Optional ByRef pref_bRowIsEmpty As Boolean = False)
        ''
        ''Added 5/19/2022 
        ''
        ''#1 5/25/2022 Me.ParentRSCSpreadsheet.SaveToRecipient(par_objRecipient, par_iRowIndex)
        ''#2 5/25/2022 Me.ParentRSCSpreadsheet.SaveToRecipient(par_objRecipient, par_iRowIndex, pboolFailure)
        Me.ParentRSCSpreadsheet.SaveToRecipient(par_objRecipient, par_iRowIndex,
                                                pref_bAnyFailure, pref_intCountFailures)

    End Sub ''End of ""Public Sub SaveToRecipient(...)""


    Public Sub ShowRecipientsIDCard(par_objRecipient As ciBadgeRecipients.ClassRecipient)
        ''
        ''Added 5/19/2022 thomas d
        ''
        Me.ParentRSCSpreadsheet.ShowRecipientsIDCard(par_objRecipient)


    End Sub ''End of ""Public Sub ShowRecipientsIDCard""


    Private Sub EmphasizeRowHeaders(par_intRowIndex_Start As Integer,
                                  Optional par_intRowIndex_End As Integer = -1)
        ''
        ''Added 4/28/2022 td
        ''
        ''---mod_listTextboxesByRow(par_intRowIndex_Start).BackColor = mod_colorHeadersBackcolor_WithEmphasis
        ''
        ''10/2023 mod_listRowHeadersByRow(par_intRowIndex_Start).BackColor = RSCDataCell.BackColor_WithEmphasisOnRow
        Dim objRowHeader As Control ''10/2023

        objRowHeader = GetRowHeader_ByIndex(par_intRowIndex_Start)

        ''Added 5/2/2022 thomas d.
        ''10/2023 Dim intRowIndex As Integer ''Added 5/02/2022 td
        If (par_intRowIndex_End > par_intRowIndex_Start) Then
            ''10/2023     For intRowIndex = par_intRowIndex_Start To par_intRowIndex_End
            ''10/2023         ''---mod_listTextboxesByRow(intRowIndex).BackColor = mod_colorHeadersBackcolor_WithEmphasis
            ''10/2023         ''10/2023 td''mod_listRowHeadersByRow(intRowIndex).BackColor = RSCDataCell.BackColor_WithEmphasisOnRow
            ''10/2023     Next intRowIndex
            mod_rowHeaderFirst_Factory.SetBackColor(par_intRowIndex_Start, RSCDataCell.BackColor_WithEmphasisOnRow,
                                            par_intRowIndex_End)

        End If ''End of ""If (par_intRowIndex_End > par_intRowIndex_Start) Then""


    End Sub ''ENd of ""Private Sub EmphasizeRowHeaders""


    Private Sub EmphasizeRowHeaders_Undo(par_intRowIndex_Start As Integer,
                                  Optional par_intRowIndex_End As Integer = -1)
        ''
        ''Added 4/28/2022 td
        ''
        ''10/2023 mod_listRowHeadersByRow(par_intRowIndex_Start).BackColor = mod_colorHeadersBackcolor_NoEmphasis
        Dim rowHdrStart As RSCRowHeader
        Dim rowHdrNext As RSCRowHeader
        rowHdrStart = mod_rowHeaderFirst_Factory.GetRowHeader_ByIndex(par_intRowIndex_Start, True)
        rowHdrStart.BackColor = mod_colorHeadersBackcolor_NoEmphasis

        ''Added 5/2/2022 thomas d.
        If (par_intRowIndex_End <> -1) Then
            Dim intRowIndex As Integer ''Added 5/02/2022 td
            If (par_intRowIndex_End > par_intRowIndex_Start) Then
                rowHdrNext = rowHdrStart
                For intRowIndex = (+1 + par_intRowIndex_Start) To par_intRowIndex_End
                    ''April 2, 2022''mod_listTextboxesByRow(intRowIndex).BackColor = RSCDataCell.BackColor_NoEmphasis
                    ''10/2023 td''mod_listRowHeadersByRow(intRowIndex).BackColor = mod_colorHeadersBackcolor_NoEmphasis
                    ''11/2023 rowHdrNext = rowHdrNext.RowHeaderNextBelow
                    rowHdrNext = DirectCast(rowHdrNext.DLL_GetItemNext(), RSCRowHeader)

                    ''Use "No Emphasis" since this is an "Undo" function. 
                    rowHdrNext.BackColor = mod_colorHeadersBackcolor_NoEmphasis

                Next intRowIndex
            End If ''End of ""If (par_intRowIndex_End > par_intRowIndex_Start) Then""
        End If ''End of ""If (par_intRowIndex_End <> -1) Then""

    End Sub ''ENd of ""Private Sub EmphasizeRowHeaders_Undo""



    ''Public Sub AlignBottomBars_WithColumnOne(par_controlColumnOne As RSCFieldColumn)
    ''    ''
    ''    ''Added 3/26/2022 thomas Downes 
    ''    ''
    ''    ''Dim listBoxesColumn1 As List(Of TextBox)
    ''    ''Dim listBoxesRowHdrs As List(Of TextBox)
    ''    Dim listVisualBarsColumn1 As List(Of PictureBox)
    ''    Dim listVisualBarsRowHdrs As List(Of PictureBox)

    ''    ''listBoxesColumn1 = par_controlColumnOne.ListOfTextboxes_TopToBottom()
    ''    ''listBoxesRowHdrs = ListOfTextboxes_TopToBottom()
    ''    listVisualBarsColumn1 = par_controlColumnOne.ListOfBottomBars_TopToBottom()
    ''    listVisualBarsRowHdrs = ListOfBottomBars_TopToBottom()

    ''    ''Major call....
    ''    AlignBottomBars(listVisualBarsColumn1, listVisualBarsRowHdrs, par_controlColumnOne)
    ''End Sub ''End of "Public Sub AlignBottomBars_WithColumnOne()"


    ''Public Sub AlignTextBoxes_ToBottomBars(par_controlColumnOne As RSCFieldColumn)
    ''    ''
    ''    ''Added 3/26/2022 thomas Downes 
    ''    ''
    ''    Dim listBoxesColumn1 As List(Of TextBox)
    ''    ''4/5/2022 Dim listBoxesRowHdrs As List(Of TextBox)
    ''    Dim listBoxesRowHdrs As List(Of RSCRowHeader)
    ''    Dim listVisualBarsColumn1 As List(Of PictureBox)
    ''    Dim listVisualBarsRowHdrs As List(Of PictureBox)
    ''    listBoxesColumn1 = par_controlColumnOne.ListOfTextboxes_TopToBottom()
    ''    listBoxesRowHdrs = ListOfTextboxes_TopToBottom()
    ''    listVisualBarsColumn1 = par_controlColumnOne.ListOfBottomBars_TopToBottom()
    ''    listVisualBarsRowHdrs = ListOfBottomBars_TopToBottom()
    ''End Sub ''End of "Public Sub AlignTextBoxes_ToBottomBars()"



    Private Sub AlignTextboxes(par_topDataCell As RSCDataCell,
                               par_topRowHeader As RSCRowHeader)
        ''
        ''Added 11/08/2023
        ''
        Dim eachDataCellInColumn As RSCDataCell = par_topDataCell
        Dim eachRowHeaderBox As RSCRowHeader = par_topRowHeader
        Dim bDone As Boolean = False

        Do While (Not bDone)
            eachRowHeaderBox.Height = eachDataCellInColumn.Height
            eachRowHeaderBox.Top = eachDataCellInColumn.Top
            ''Prepare for next iteration.
            If (eachRowHeaderBox.DLL_NotAnyNext()) Then
                ''Are we done?  Yes
                bDone = True
            Else
                ''Prepare for next iteration.
                eachRowHeaderBox = DirectCast(eachRowHeaderBox.DLL_GetItemNext(), RSCRowHeader)
                eachDataCellInColumn = DirectCast(eachDataCellInColumn.DLL_GetItemNext(), RSCDataCell)
            End If
        Loop

    End Sub ''End of ""Private Sub AlignTextboxes(par_topDataCell As RSCDataCell, ...)"

    ''11/2023 Private Sub AlignTextboxes(par_listBoxesColumn As IEnumerable(Of Control),
    ''   par_listBoxesRowHdrs As IEnumerable(Of RSCRowHeader))
    ''
    ''Added 3/24/2022 thomas d.  
    ''
    ''---For Each eachColumnBox As TextBox In par_listBoxesColumn
    ''Dim eachDataCellInColumn As Control ''4/9/2022 td'' TextBox
    ''    Dim eachRowHeaderBox As RSCRowHeader ''April 5, 2022 TextBox

    ''    Dim TopBoxColumn As Control ''4/9/2922 td''TextBox ''Addded 3/25/2022 td
    ''    ''4/5/2022 Dim TopBoxHeader As TextBox ''Added 3/25/2022 td
    ''    Dim TopBoxHeader As RSCRowHeader ''4/5/2022 As TextBox ''Added 3/25/2022 td
    ''    Dim boolSkipTopBox As Boolean

    ''    TopBoxColumn = par_listBoxesColumn(0) ''Added 3/25/2022 td
    ''    TopBoxHeader = par_listBoxesRowHdrs(0) ''Added 3/25/2022 td
    ''    boolSkipTopBox = True

    ''    ''Added 3/30/2022 thomas downes
    ''    Load_EmptyRows(par_listBoxesColumn.Count)
    ''    par_listBoxesRowHdrs = Me.ListOfRowHeaders_TopToBottom()

    ''    ''
    ''    ''Loop through the rows
    ''    ''
    ''    For intBoxIndex As Integer = 0 To (-1 + par_listBoxesColumn.Count)

    ''        ''Skip the top boxes. 
    ''        If (boolSkipTopBox And intBoxIndex = 0) Then Continue For

    ''        eachDataCellInColumn = Nothing
    ''        eachRowHeaderBox = Nothing

    ''        Try
    ''            eachDataCellInColumn = par_listBoxesColumn(intBoxIndex)
    ''        Catch
    ''        End Try

    ''        Try
    ''            eachRowHeaderBox = par_listBoxesRowHdrs(intBoxIndex)
    ''        Catch
    ''        End Try

    ''        If (eachRowHeaderBox Is Nothing And eachDataCellInColumn Is Nothing) Then
    ''            Exit For
    ''11/2023
    ''        ElseIf (eachDataCellInColumn Is Nothing) Then
    ''            ''Exit Sub
    ''            Throw New Exception("There are more row headers than (column #1's) rows.")
    ''11/2023
    ''        ElseIf (eachRowHeaderBox Is Nothing) Then
    ''            ''Exit Sub
    ''            Throw New Exception("There are more rows than row headers.")
    ''11/2023
    ''        ElseIf (boolSkipTopBox) Then
    ''            ''eachBoxHeader.Height = eachBoxColumn.Height
    ''            eachRowHeaderBox.Height = eachDataCellInColumn.Height
    ''            eachRowHeaderBox.Top = (eachDataCellInColumn.Top - TopBoxColumn.Top) +
    ''                                   TopBoxHeader.Top
    ''11/2023
    ''        Else
    ''            eachRowHeaderBox.Height = eachDataCellInColumn.Height
    ''            eachRowHeaderBox.Top = eachDataCellInColumn.Top
    ''11/2023
    ''        End If ''End of ""If (eachBoxHeader Is Nothing And eachBoxColumn Is Nothing) Then... ElseIf ... ElseIf ... ElseIf ... Else ...
    ''11/2023
    ''    Next intBoxIndex
    ''11/2023
    ''    ''---Next eachColumnBox
    ''End Sub ''End of "Private Sub AlignTextboxes"


    ''Private Sub AlignBottomBars(par_listBottomBarsColumn1 As IEnumerable(Of PictureBox),
    ''                           par_listBottomBarsRowHdrs As IEnumerable(Of PictureBox),
    ''                            par_RSCFieldColumn1 As RSCFieldColumn)
    ''    ''
    ''    ''Added 3/24/2022 thomas d.  
    ''    ''
    ''    ''  The "Bottom Bars" ("Visual Bars") are the black-backcolor picture boxes which are
    ''    ''  very "landscape"-shaped, i.e. are very wide and very short (less than 5 pixels high).
    ''    ''  They are purely visual, i.e. only serve to create visually-obvious "rows" in the
    ''    ''  spreadsheet.----3/25/2022
    ''    ''
    ''    ''---For Each eachColumnBox As TextBox In par_listBoxesColumn
    ''    Dim eachBarColumn As PictureBox
    ''    Dim eachBarHeader As PictureBox
    ''    Dim TopBarColumn As PictureBox ''Addded 3/25/2022 td
    ''    Dim TopBarHeader As PictureBox ''Added 3/25/2022 td
    ''    Dim boolSkipTopBar As Boolean ''Added 3/25/2022 td

    ''    TopBarColumn = par_listBottomBarsColumn1(0) ''Added 3/25/2022 td
    ''    TopBarHeader = par_listBottomBarsRowHdrs(0) ''Added 3/25/2022 td

    ''    ''
    ''    ''Step 1 of 2.  Address the Initial Gap. 
    ''    ''
    ''    ''Added 3/25/2022
    ''    Dim intLocationVertical_1stBarInColumn As Integer
    ''    Dim intLocationVertical_1stBarInRowHdrsCtl As Integer
    ''    Dim intInitialGap As Integer

    ''    intLocationVertical_1stBarInColumn = par_RSCFieldColumn1.Top + TopBarColumn.Top
    ''    intLocationVertical_1stBarInRowHdrsCtl = Me.Top + TopBarHeader.Top
    ''    intInitialGap = (intLocationVertical_1stBarInColumn -
    ''                      intLocationVertical_1stBarInRowHdrsCtl)
    ''    Me.Top += intInitialGap

    ''    ''
    ''    ''Step 2 of 2. Loop through the rows
    ''    ''
    ''    boolSkipTopBar = True
    ''    For intBoxIndex As Integer = 0 To (-1 + par_listBottomBarsColumn1.Count)

    ''        eachBarColumn = Nothing
    ''        eachBarHeader = Nothing

    ''        ''Added 4/5/2022 thomas 
    ''        Load_OneEmptyRow_IfNeeded(intBoxIndex)

    ''        Try
    ''            eachBarColumn = par_listBottomBarsColumn1(intBoxIndex)
    ''        Catch
    ''        End Try

    ''        Try
    ''            eachBarHeader = par_listBottomBarsRowHdrs(intBoxIndex)
    ''        Catch
    ''        End Try

    ''        If (eachBarHeader Is Nothing And eachBarColumn Is Nothing) Then
    ''            Exit For
    ''        ElseIf (eachBarColumn Is Nothing) Then
    ''            ''Exit Sub
    ''            Throw New Exception("There are more row headers than (column #1's) rows.")

    ''        ElseIf (eachBarHeader Is Nothing) Then
    ''            ''Exit Sub
    ''            Throw New Exception("There are more rows than row headers.")

    ''        ElseIf (boolSkipTopBar) Then
    ''            eachBarHeader.Height = eachBarColumn.Height
    ''            eachBarHeader.Top = (eachBarColumn.Top - TopBarColumn.Top) +
    ''                                   TopBarHeader.Top

    ''        Else
    ''            eachBarHeader.Top = eachBarColumn.Top
    ''            eachBarHeader.Height = eachBarColumn.Height

    ''        End If

    ''    Next intBoxIndex

    ''    ''---Next eachColumnBox
    ''End Sub ''End of "Private Sub AlignBottomBars"


    Public Sub Load_OneEmptyRow_IfNeeded(par_intRowIndex As Integer,
                                         Optional pboolForceReposition As Boolean = False)
        ''
        ''Refactored 10/18/2023 td
        ''Added 4/4/2022 td
        ''
        Dim bRowIndexLocated As Boolean
        Dim boolIsNewHeader As Boolean
        Dim boolMoreThanOneNew As Boolean
        ''Not needed. 10/2023 Dim listOfNewHeaders As List(Of RSCRowHeader) = Nothing
        Dim objReturnedRowHeaderPossiblyNew As RSCRowHeader = Nothing
        Dim intExpectedNewRows As Integer ''Added 10/21/2023
        Dim intNumberOfNewRows As Integer ''Added 10/24/2023

        ''Added 10/18/2023
        ''10/18/2023td mod_rowHeaderFirst_Factory.BuildNextRowsHeader(False, False, true)
        With mod_rowHeaderFirst_Factory

            ''Added 10/21/2023
            intExpectedNewRows = CType(IIf(par_intRowIndex > .FactoryMaxIndex,
                              par_intRowIndex - .FactoryMaxIndex, 0), Integer)

            ''Added 10/18/2023
            objReturnedRowHeaderPossiblyNew =
                    .FactoryBuildNextRowHeader_IfNeeded(par_intRowIndex,
                                   intExpectedNewRows, pboolForceReposition,
                                   boolIsNewHeader, boolMoreThanOneNew, intNumberOfNewRows) '', listOfNewHeaders)
            bRowIndexLocated = True
        End With ''End of ""With mod_rowHeaderFirst_Factory""

        ''
        ''
        ''Add the new row headers (if any) to the usercontrol's Controls collection.
        ''
        ''
        ''Added 10/18/2023
        Dim bInconsistency1 As Boolean ''Added 10/18/2023
        Dim bInconsistency2 As Boolean ''Added 10/18/2023
        Dim bInconsistency3 As Boolean ''Added 10/18/2023
        Dim bOnlyOneNewHeader As Boolean ''Added 10/21/2023
        Dim objNewRowHeaderAtGivenIndex As RSCRowHeader = Nothing ''Added 10/24/2023

        ''10/2023 bInconsistency = (boolMoreThanOneNew And listOfNewHeaders Is Nothing)
        bInconsistency1 = (boolMoreThanOneNew And (intNumberOfNewRows <= 1))
        bInconsistency2 = (boolIsNewHeader And (intNumberOfNewRows <= 0))
        bInconsistency3 = (boolMoreThanOneNew And (Not boolIsNewHeader))
        If (bInconsistency1) Then Debugger.Break()
        If (bInconsistency2) Then Debugger.Break()
        If (bInconsistency3) Then Debugger.Break()
        bOnlyOneNewHeader = (boolIsNewHeader And Not boolMoreThanOneNew)
        If (boolIsNewHeader) Then
            objNewRowHeaderAtGivenIndex = objReturnedRowHeaderPossiblyNew
        End If ''End of "If (boolIsNewHeader) Then"

        If (bOnlyOneNewHeader) Then
            ''Added just the one(1) new row header.
            Me.Controls.Add(objNewRowHeaderAtGivenIndex)

        ElseIf (boolMoreThanOneNew) Then
            ''Added 10/21/2023
            ''   Add every new row header to the usercontrol's Controls collection.
            ''For Each eachRowHeader As RSCRowHeader In listOfNewHeaders
            ''    Me.Controls.Add(objRowHeaderPossiblyNew)
            ''    objRowHeaderPossiblyNew.Visible = True
            ''Next eachRowHeader
            Dim currentForRowHeader As RSCRowHeader
            currentForRowHeader = objNewRowHeaderAtGivenIndex
            For intAddIndex As Integer = 1 To intNumberOfNewRows
                Me.Controls.Add(currentForRowHeader)
                currentForRowHeader.Visible = True
                ''Prepare for next loop.
                ''  Find the row header __ABOVE__ the current one.
                ''11/2023 currentForRowHeader = currentForRowHeader.RowHeaderNextAbove
                currentForRowHeader = CType(currentForRowHeader.DLL_GetItemPrior(), RSCRowHeader)
            Next intAddIndex

        End If ''End of ""If (bOnlyOneNewHeader) Then.. ElseIf...""

        ''
        ''This is performed within RSCRowHeader.FactoryBuildRowHeader_IfNeeded
        '' 
        ''   ''Adjust the parent RowHeaders height. ---10/21/2023 td
        ''   With objRowHeaderPossiblyNew
        ''     Me.Height = (.Top + .Height +
        ''            Me.PixelsFromRowToRow)  ''April 5, 2022 td ''mc_intPixelsFromRowToRow)
        ''   End With

        ''--10/18/2023
        ''With mod_listRowHeadersByRow
        ''    bRowIndexLocated = (.ContainsKey(par_intRowIndex))
        ''End With
        ''--10/18/2023
        ''If (pboolForceReposition) Then
        ''    ''
        ''    ''Don't exit. 
        ''    ''
        ''ElseIf (bRowIndexLocated) Then
        ''--10/18/2023
        ''    ''Added 4/29/2022 thomas d. 
        ''    mod_listRowHeadersByRow(par_intRowIndex).RowIndex = par_intRowIndex
        ''--10/18/2023
        ''    Exit Sub
        ''--10/18/2023
        ''End If ''End of "If (pboolForceReposition) Then ... ElseIf....."
        ''--10/18/2023
        ''''
        ''''Create the textbox and Bottom Bar. 
        ''''
        ''--10/18/2023
        ''''
        ''''Create the required textbox. 
        ''''
        ''Dim objRowHeaderByRowIndex As RSCRowHeader ''4/5/2022 TextBox ''4/4/2022 td''New TextBox ''Added 3/29/2022 thomas downes
        ''''Dim objBottomBar As PictureBox ''Added 4/5/2022 thomas downes
        ''--10/18/2023
        ''If (bRowIndexLocated) Then
        ''    objRowHeaderByRowIndex = mod_listRowHeadersByRow.Item(par_intRowIndex)
        ''    ''objBottomBar = mod_listTextAndBarByRow.Item(par_intRowIndex).BottomBar
        ''--10/18/2023
        ''    ''Added 4/25/2022 td
        ''    If (objRowHeaderByRowIndex.RowIndex = 0) Then
        ''        objRowHeaderByRowIndex.RowIndex = par_intRowIndex
        ''    End If
        ''--10/18/2023
        ''Else
        ''    ''4/4/2022 td''Dim objTextbox As New TextBox ''Added 3/29/2022 thomas downes
        ''    objRowHeaderByRowIndex = New RSCRowHeader ''4/5/2022 TextBox ''Added 3/29/2022 thomas downes
        ''    objRowHeaderByRowIndex.RowIndex = par_intRowIndex ''Added 4/25/2022 td
        ''    mod_listRowHeadersByRow.Add(par_intRowIndex, objRowHeaderByRowIndex)
        ''    ''objBottomBar = GetBottomBarForRow()
        ''    ''Dim new_struct As New StructLabelAndRowSeparator
        ''    ''new_struct.BottomBar = objBottomBar
        ''    ''new_struct.Cellbox = objTextbox
        ''    ''mod_listTextAndBarByRow.Item(par_intRowIndex) = new_struct
        ''--10/18/2023
        ''End If ''End of ""If (bRowIndexLocated) Then... Else..."
        ''--10/18/2023
        ''''4/5/2022 Dim rscRowHdrTop As TextBox
        ''Dim rscRowHdrTopTemplate As RSCRowHeader
        ''rscRowHdrTopTemplate = Me.GetFirstTextbox()
        ''--10/18/2023
        ''With objRowHeaderByRowIndex
        ''--10/18/2023
        ''    ''4/7/2022----Obselete.... call to PositionAndSizeControlByRow().---4/7/2022 td
        ''    ''4/7/2022-- .Left = rscRowHdrTop.Left
        ''    ''4/7/2022-- .Width = rscRowHdrTop.Width
        ''    ''Moved below.''.Height = rscRowHdrTop.Height
        ''--10/18/2023
        ''    .Anchor = rscRowHdrTopTemplate.Anchor
        ''    .BackColor = rscRowHdrTopTemplate.BackColor
        ''    .ForeColor = rscRowHdrTopTemplate.ForeColor
        ''    .BorderStyle = rscRowHdrTopTemplate.BorderStyle
        ''    .Font = rscRowHdrTopTemplate.Font
        ''    ''---.Top = (rscRowHdrBottomLast.Top + intTopGap)
        ''    ''April 5 2022 ''.Top = (rscRowHdrTop.Top + mc_intPixelsFromRowToRow * (par_intRowIndex - 1))
        ''--10/18/2023
        ''    ''4/7/2022----Obselete.... call to PositionAndSizeControlByRow().---4/7/2022 td
        ''    ''4/7/2022-- .Top = (rscRowHdrTop.Top + Me.PixelsFromRowToRow * (par_intRowIndex - 1))
        ''    ''4/7/2022-- .Height = rscRowHdrTop.Height
        ''--10/18/2023
        ''    ''4/8 Added 4/7/2022 thomas downes
        ''    ''4/8 Dim temporary_textbox = New TextBox
        ''    ''4/8 ModRSCLayout.PositionAndSizeControlByRow(par_intRowIndex, rscRowHdrTop.Top,
        ''    ''4/8                                 rscRowHdrTop.Width, temporary_textbox)
        ''    ''4/8 .Size = temporary_textbox.Size
        ''    ''4/8 .Location = temporary_textbox.Location
        ''--10/18/2023
        ''    With objRowHeaderByRowIndex
        ''        ''
        ''        ''We will write to .Top & .Height through
        ''        ''   the .Location & .Size object properties.
        ''        ''   ---4/8/2022
        ''        ''
        ''        ''4/8 ModRSCLayout.PositionAndSizeControlByRow(par_intRowIndex, rscRowHdrTop.Top,
        ''        ''4/8                              rscRowHdrTop.Width, Nothing,
        ''        ''4/8                             .Size,
        ''        ''4/8                             .Location)
        ''        ''
        ''        ''.Top = .....See Call To Module ModRSCLayout, just below.--4/8/2022
        ''        ''.Left = .....See Call To Module ModRSCLayout, just below.--4/8/2022
        ''        ''.Height = .....See Call To Module ModRSCLayout, just below.--4/8/2022
        ''        ''.Width = .....See Call To Module ModRSCLayout, just below.--4/8/2022
        ''        ''
        ''        ModRSCLayout.PositionAndSizeControlByRow(objRowHeaderByRowIndex, par_intRowIndex,
        ''                                                 rscRowHdrTopTemplate.Top,
        ''                                                 rscRowHdrTopTemplate.Width)
        ''    End With ''ENd of "with objTextBox"  
        ''--10/18/2023
        ''    ''
        ''    ''Double-check the width property.
        ''    ''
        ''    .Width = rscRowHdrTopTemplate.Width
        ''--10/18/2023
        ''    .Visible = True
        ''    .Text = par_intRowIndex.ToString() ''Added 4/6/2022 thomas downes
        ''    .ParentRSCRowHeaders = Me ''Added 4/6/2022 td
        ''--10/18/2023
        ''    ''Added 4/6/2022 thomas downes
        ''    .Margin = New Padding(0, 0, 0, 0)
        ''    .Padding = New Padding(0, 0, 0, 0)
        ''--10/18/2023
        ''    ''Bottom  row-related horizontal line (below each textbox).
        ''    ''objBottomBar.Top = .Top + .Height + 1
        ''--10/18/2023
        ''End With ''End of ""With objTextbox""

        ''10/21/2023 Added 3/30/2022
        ''10/21/2023 If (bRowIndexLocated) Then
        ''10/21/2023     ''Textbox is already one of the controls on the form. ---4/4/2022
        ''10/21/2023 Else
        ''    Me.Controls.Add(objRowHeaderByRowIndex)
        ''    ''Added 4/08/2022 thomas d.
        ''    ModRSCLayout.PositionAndSizeControlByRow(objRowHeaderByRowIndex, par_intRowIndex,
        ''                                             rscRowHdrTopTemplate.Top,
        ''                                             rscRowHdrTopTemplate.Width)
        ''    Application.DoEvents()
        ''    ''4/8/2022 td''objTextbox.Height = rscRowHdrTop.Height
        ''    ''4/8/2022 td''objTextbox.Width = rscRowHdrTop.Width
        ''    ''Me.Controls.Add(objBottomBar)
        ''End If ''End of ""If (bRowIndexLocated) Then... Else ..."

        ''4/5/2022 Dim rscRowHdrBottomLast As TextBox
        ''Dim rscRowHdrBottomLast As RSCRowHeader
        ''''Me.Height = (objTextbox.Top + objTextbox.Height + intTopGap)

        ''''4/5/2022 td''Dim listOfBoxes As List(Of TextBox)
        ''Dim listOfBoxes As List(Of RSCRowHeader)
        ''listOfBoxes = ListOfRowHeaders_TopToBottom()
        ''rscRowHdrBottomLast = listOfBoxes(-1 + listOfBoxes.Count) ''.LastOrDefault
        ''Me.Height = (rscRowHdrBottomLast.Top + rscRowHdrBottomLast.Height +
        ''            Me.PixelsFromRowToRow)  ''April 5, 2022 td ''mc_intPixelsFromRowToRow

    End Sub ''End of ""Public Sub Load_EmptyRow_IfNeeded(par(intRowIndex As Integer)""



    Public Sub Load_EmptyRows(par_intRowsRequired As Integer)
        ''
        ''Added 3/29/2022 thomas downes
        ''
        Dim ref_intCountRows As Integer = 0
        Dim intCountRows As Integer = 0

        ''CountOfBoxesWithData(ref_intCountRows)
        ''intCountRows = ref_intCountRows
        ''4/8/2022 td''intCountRows = ListOfBottomBars_TopToBottom().Count
        ''11/2023 intCountRows = ListOfRowHeaders_TopToBottom().Count
        intCountRows = CountOfRows(True)

        Const c_bUseFirstTry As Boolean = False ''Added 4/5/2022 td

        If (c_bUseFirstTry) Then
            If (intCountRows = par_intRowsRequired) Then Exit Sub
            If (intCountRows > par_intRowsRequired) Then Load_EmptyRows_DeleteRows(par_intRowsRequired)
            If (intCountRows < par_intRowsRequired) Then Load_EmptyRows_CreateRows(par_intRowsRequired)

        Else
            ''Added 4/4/2022 td
            For intRowIndex As Integer = 1 To par_intRowsRequired

                ''Added 4/4/2022 td
                Load_OneEmptyRow_IfNeeded(intRowIndex)

            Next intRowIndex

        End If ''End of ""If (c_bUseFirstTry) Then .... Else...."

    End Sub ''End of ""Public Sub Load_EmptyRows()""


    Public Sub Load_ColumnListDataToColumnEtc_DepricatedJune2023()
        ''
        ''Encapsulated 4/15/2022 thomas d.
        ''
        ''
        ''Added 3/19/2022  
        ''
        ''6/22/2022 thomas d''If (0 <> mod_columnWidthAndData.ColumnData.Count) Then
        ''4/15/2022 thomas d''LoadDataToColumn(mod_columnWidthAndData.ColumnData)
        ''6/22/2022 thomas d''Load_ColumnListDataToColumn(mod_columnWidthAndData.ColumnData)
        With Me.ColumnDataCache
            ''5/31/ 2023 Load_ColumnListDataToColumn(.RSCColumnWithMaximalDataCells())
            Load_ColumnListDataToColumn_Deprecated(.RSCColumnWithMaximalDataCells())
        End With

        ''6/22/2022 thomas d''End If ''If (0 <> mod_columnWidthAndData.ColumnData.Count) Then

    End Sub ''end of "Public Sub Load_ColumnListDataToColumnEtc_DepricatedJune2023"


    Private Sub Load_ColumnListDataToColumn_Deprecated(par_column As ClassRSCColumnWidthAndData)
        ''---6/22/2022 td---Private Sub Load_ColumnListDataToColumn(par_listData As List(Of String))
        ''---4/15/2022 td---Private Sub LoadDataToColumn(par_listData As List(Of String))
        ''
        ''Added 3/19/2022 td
        ''
        Dim indexItem As Integer = 0
        Dim list_datacells As List(Of String)

        ''Added 6/22/2022 thomas
        If (par_column Is Nothing) Then
            System.Diagnostics.Debugger.Break()
            Exit Sub
        End If ''End of ""If (par_column Is Nothing) Then""

        ''Added 6/22/2022 thomas
        list_datacells = par_column.ColumnData

        ''Added 4/13/2022
        If (list_datacells Is Nothing) Then
            ''Added 4/14/2022
            MessageBoxTD.Show_Statement("No non-null list of data with which to supply the present column.")
            Exit Sub
        ElseIf (list_datacells.Count = 0) Then
            ''Added 4/13/2022
            MessageBoxTD.Show_Statement("No data exists with which to supply the present column.")
            Exit Sub
        ElseIf (Me.CountOfRows() < list_datacells.Count) Then
            ''Added 4/15/2022
            Load_EmptyRows(list_datacells.Count)

        End If ''End of ""If (list_datacells.Count = 0) Then .... ElseIf.... ElseIf....""



    End Sub ''End of "Private Sub Load_ColumnListDataToColumn_Deprecated()"




    Public Sub LoadRecipientList(Optional ByRef pref_bNoRecipientList As Boolean = False,
                                 Optional ByRef pref_boolRows_TooFew As Boolean = False,
                                 Optional ByRef pref_boolRows_TooMany As Boolean = False)
        ''
        ''Added 5/14/2022 & 3/22/2022 td
        ''
        Dim intCountRowHeaders As Integer ''Added 3/23/2022 td

        ''Moved here from below.---4/23/2022 td
        Dim intCountRecipients As Integer
        intCountRecipients = Me.ListRecipients.Count
        Load_EmptyRows(intCountRecipients)

        Dim boolNoRecipList As Boolean
        boolNoRecipList = (Me.ListRecipients Is Nothing)
        pref_bNoRecipientList = boolNoRecipList
        If (pref_bNoRecipientList) Then
            Throw New Exception("ListRecipients is a Null reference.")
            Return
        End If ''End of ""If (pref_bNoRecipientList) Then""

        ''Moved above. 4/23/2022 td''Dim intCountRecipients As Integer
        ''Moved above. 4/23/2022 td''intCountRecipients = Me.ListRecipients.Count

        Dim boolNoRecipients_zero As Boolean
        boolNoRecipients_zero = (0 = intCountRecipients)
        If (boolNoRecipients_zero) Then
            pref_bNoRecipientList = True
            Const c_boolAllowForBlankSlate As Boolean = True
            If (c_boolAllowForBlankSlate) Then
                ''Allow the user to start from scratch.  We are NOT(!) supplying
                ''  the user with a list of hard-coded (fake) recipients.
                ''  ----5/13/2022 td
                Return ''Added 5/16/2022 
            Else
                ''Throw an error. Where in heck is the list of fake hard-coded recipients? 
                Throw New Exception("ListRecipients has Zero(0) recipient (student) rows.")
                Return
            End If ''ENd of ""If (c_boolAllowForBlankSlate) Then... Else..."
        End If ''ENd of ""If (boo lNoRecipients_zero) Then""

        ''
        ''Added 3/29/2022 thomas downes
        ''
        ''Moved above. 4/23/2022 td''Load_EmptyRows(intCountRecipients)

        ''CountOfBoxesWithData(intCountBoxesEmptyOrNot) ''Update the value of var. intCountBoxesEmptyOrNot.

        ''3/29/2022 thomas d.''Dim boolMismatchOfCounts As Boolean
        ''2/2023 Dim boolMismatchOfCounts_Less As Boolean
        ''2/2023 Dim boolMismatchOfCounts_More As Boolean

        ''intCountAllBoxesOrRows = intCountBoxesEmptyOrNot
        ''March29 2022''boolMismatchOfCounts_Less = (intCountAllBoxesOrRows <> Me.ListRecipients.Count) ''Then
        ''boolMismatchOfCounts_Less = (intCountAllBoxesOrRows < Me.ListRecipients.Count) ''Then
        ''boolMismatchOfCounts_More = (intCountAllBoxesOrRows > Me.ListRecipients.Count) ''Then

        ''If (boolMismatchOfCounts_Less) Then
        ''    ''3/29/2022 td''pboolErrorCellsHaveValues = True
        ''    pref_boolRows_TooFew = True
        ''    ''---Throw New Exception("Warning, non-zero >0 cells with data already. Data would be lost.")
        ''    Throw New Exception("Warning, we have less RSCDataCelles than required. Data would be lost.")

        ''ElseIf (boolMismatchOfCounts_More) Then
        ''    ''3/29/2022 td''pboolErrorCellsHaveValues = True
        ''    pref_boolRows_TooMany = True
        ''    ''---Throw New Exception("Warning, non-zero >0 cells with data already. Data would be lost.")
        ''    Throw New Exception("Warning, we have more RSCDataCelles than required. Rows will be left blank.")
        ''End If ''End of ""If (boolMismatchOfCounts) then""

        ''-----------------------------------------------------------

        ''March25 2022 td''Dim listBoxes As IOrderedEnumerable(Of RSCDataCell)
        ''5/14/2022 Dim listBoxes As List(Of RSCDataCell)
        ''11/2023 td''Dim listHeaders As List(Of RSCRowHeader)
        Dim intRowIndex As Integer = -1
        Dim each_value As String
        Dim boolMiscountOfRows As Boolean
        Dim intRowsInSpreadsheet As Integer
        Dim listValuesForStatistics As New List(Of String) ''Added 4/26/2022 td
        Dim each_rowheader As RSCRowHeader ''Added 11/2023 td
        Dim each_rowheader_next As RSCRowHeader ''Added 11/2023 td

        ''5/14/2022 listHeaders = ListOfRSCDataCells_TopToBottom()
        ''11/2023 td''listHeaders = ListOfRowHeaders_TopToBottom()

        ''Added 4/11/2022
        intRowsInSpreadsheet = Me.ParentRSCSpreadsheet.RscFieldColumn1.CountOfRows()
        intCountRowHeaders = Me.CountOfRows(True) ''Me.ParentSpreadsheet.RscFieldColumn1.CountOfRows()
        ''11/2023 td''boolMiscountOfRows = (listHeaders.Count <> intRowsInSpreadsheet)
        boolMiscountOfRows = (intCountRowHeaders <> intRowsInSpreadsheet)
        If (boolMiscountOfRows) Then
            System.Diagnostics.Debugger.Break()
        End If ''End of ""If (boolMiscountOfRows) Then""

        ''
        ''Looping through all row headers. 
        ''
        ''11/2023 td''For Each each_rowheader As RSCRowHeader In listHeaders
        each_rowheader = mod_rowHeaderFirst_Factory
        each_rowheader_next = Nothing
        Do While (each_rowheader IsNot Nothing)

            intRowIndex += 1
            each_rowheader.Recipient = Me.ListRecipients(intRowIndex)

            ''Added 5/20/2022 td 
            With each_rowheader
                ''Show the "Show ID" linklabel.  
                .LinkLabelShowID.Visible = True ''Added 5/20/2022 td 
            End With

            ''''4/11 td''each_box.Text = Me. ListRecipients(intRowIndex).GetTextValue(enumFieldSelected)
            ''Added 4/11/2022 td
            ''4/2/2024 each_value = Me.ListRecipients(intRowIndex).GetTextValue(enumField)

            ''Added 4/25/2022 td
            ''4/2/2024 listValuesForStatistics.Add(each_value)

            ''''Added 4/15/2022
            Dim strCellDataBeforeLoadingRecip As String
            Dim strCellDataFromColumnData As String
            Dim boolMismatch_ColumnData As Boolean
            Const c_bCheck_ColumnWidthAndData As Boolean = False ''Added11/09/2023 td

            If (c_bCheck_ColumnWidthAndData) Then ''Modified 11/09/2023 td
                ''11/2023  If (pboolCheck_ColumnWidthAndData) Then
                ''Compare the Recipient data to the ColumnWidthAndData data.
                ''   ---4/14/2022
                strCellDataBeforeLoadingRecip = each_rowheader.Text.Trim() ''5/01/2022 td''each_box.Text
                strCellDataFromColumnData = ColumnWidthAndData.ColumnData(intRowIndex).Trim() ''Added .Trim() on 5/01/2022
                boolMismatch_ColumnData = (strCellDataFromColumnData <> each_value)
                If (boolMismatch_ColumnData) Then
                    ''---System.Diagnostics.Debugger.Break()
                    MessageBoxTD.Show_Statement("Due to a mismatch of data, we are not able to continue " &
                                                " to load the recipient data into this column.")
                    Exit Sub
                End If ''End of ""If (boolMismatch_ColumnData) Then""
            End If ''End of ""If (pboolCheck_ColumnWidthAndData) Then""

            ''Prepare for (next) iteration
            each_rowheader_next = DirectCast(each_rowheader.DLL_GetItemNext(), RSCRowHeader)
            each_rowheader = each_rowheader_next

        Loop ''11/2023 td''Next each_rowheader

        ''
        ''Build statistics to describe the general number of letters & digits in the data. 
        ''  --4/26/2022 td
        ''
        ''mod_statistics = ClassMathStats.GetMeanAndStdDeviation_FourStats(listValuesForStatistics)


    End Sub ''End of "Public Sub LoadRecipientList()"


    Public Sub RefreshHeightOfHeaders(Optional par_intNumberOfRows As Integer = 0)
        ''
        '' Added 4/6/2022 thomas downes
        ''
        mod_rowHeaderFirst_Factory.RefreshHeightOfHeaders(par_intNumberOfRows)

        ''10/21/2023 If (0 = par_intNumberOfRows) Then
        ''   par_intNumberOfRows = mod_listRowHeadersByRow.Count
        ''End If ''End of ""If (0 = par_intNumberOfRows) Then""

        ''10/21/2023 For intRowIndex As Integer = 1 To par_intNumberOfRows
        ''
        ''    ''Added 4/4/2022 td
        ''    ''Oops!!  mod_listRowHeadersByRow(intRowIndex).Height = (mod_intPixelsFromRowToRow - 1)
        ''    ''mod_listRowHeadersByRow(intRowIndex).Height = Me.GetFirstTextbox().Height
        ''    ''mod_listRowHeadersByRow(intRowIndex).Width = Me.GetFirstTextbox().Width
        ''
        ''Next intRowIndex

    End Sub ''End of "Public Sub RefreshHeightOfHeaders"


    Private Sub Load_EmptyRows_CreateRows(par_intRowsRequired As Integer)
        ''
        ''Added 3/29/2022 thomas downes
        ''
        ''4/5/2022 td ''Dim listOfBoxes As List(Of TextBox)
        ''11/2023 td''Dim listOfBoxes As List(Of RSCRowHeader)
        Dim rowheader_Top As RSCRowHeader ''4/5/2022 td ''TextBox
        Dim rowheader_Next As RSCRowHeader ''4/5/2022 td ''TextBox
        Dim rowheader_BottomLast As RSCRowHeader ''4/5/2022 td ''TextBox
        Dim rowheader_BottomLastPrior As RSCRowHeader ''4/5/2022 td ''TextBox
        Dim intIndexStart As Integer
        Dim intIndex__End As Integer
        Dim intTopGap As Integer
        Dim intCountRows As Integer

        ''11/2023 td''listOfBoxes = ListOfRowHeaders_TopToBottom()
        rowheader_Top = mod_rowHeaderFirst_Factory

        ''
        ''Find the bottom two(2) row headers.
        ''
        ''11/2023 td''rowheader_BottomLast = listOfBoxes(-1 + listOfBoxes.Count) ''.LastOrDefault
        ''11/2023 td''rowheader_BottomDeux = listOfBoxes(-2 + listOfBoxes.Count) ''.LastOrDefault
        rowheader_Next = rowheader_Top
        intCountRows = 1
        Do Until (rowheader_Next.DLL_NotAnyNext())
            rowheader_Next = DirectCast(rowheader_Next.DLL_GetItemNext(), RSCRowHeader)
            intCountRows += 1
        Loop
        rowheader_BottomLast = rowheader_Next
        rowheader_BottomLastPrior = DirectCast(rowheader_BottomLast.DLL_GetItemPrior(), RSCRowHeader)

        intIndexStart = (intCountRows - 1 + 1) ''(listOfBoxes.Count - 1 + 1)
        intIndex__End = (par_intRowsRequired - 1)
        intTopGap = (rowheader_BottomLast.Top - rowheader_BottomLastPrior.Top)

        For intRowIndex As Integer = intIndexStart To intIndex__End
            ''
            ''Create the required textbox. 
            ''
            Dim objTextbox As New TextBox ''Added 3/29/2022 thomas downes
            With objTextbox
                .Left = rowheader_Top.Left
                .Width = rowheader_Top.Width
                .Height = rowheader_Top.Height
                .Anchor = rowheader_Top.Anchor
                .BackColor = rowheader_Top.BackColor
                .ForeColor = rowheader_Top.ForeColor
                .BorderStyle = rowheader_Top.BorderStyle
                .Font = rowheader_Top.Font
                .Top = (rowheader_BottomLast.Top + intTopGap)
                .Visible = True
                .ReadOnly = True ''True. ---Added 4/3/2022 thomas
                AddHandler .MouseUp, AddressOf HeaderBox_MouseUp
            End With

            Me.Controls.Add(objTextbox)

        Next intRowIndex

    End Sub ''End of ""Public Sub Load_EmptyRows_CreateRows()""


    Private Sub Load_EmptyRows_DeleteRows(par_intRowsToCreate As Integer)
        ''
        ''Added 3/29/2022 thomas downes
        ''





    End Sub ''End of ""Public Sub Load_EmptyRows_DeleteRows()""



    Public Function ListOfRowHeaders_TopToBottom_Denigrated(Optional par_noSorting As Boolean = False) As List(Of RSCRowHeader) ''IOrderedEnumerable(Of TextBox)
        ''5/14/2022 Public Function ListOfRowHeaders_TopToBottom
        ''
        ''Added 3/19/2022 td
        ''
        ''5/14/2022 Dim objListOfTextboxes As New List(Of RSCRowHeader) ''4/5/2022 TextBox)
        Dim objListOfRowHeaders As New List(Of RSCRowHeader) ''4/5/2022 TextBox)
        ''Dim objListOfTextboxes_Ordered ''As New IOrderedEnumerable(Of(Of TextBox)

        For Each eachCtl As Control In Me.Controls
            ''4/5/2022 If (TypeOf eachCtl Is TextBox) Then
            If (TypeOf eachCtl Is RSCRowHeader) Then
                ''Strangely, .Visible is False???? 3/25/2022 td''If (eachCtl.Visible) Then
                objListOfRowHeaders.Add(CType(eachCtl, RSCRowHeader)) ''4/5/2022 TextBox))
                ''End If
            End If ''End of "If (TypeOf eachCtl Is RSCRowHeader) Then"
        Next eachCtl ''End of ""For Each eachCtl As Control In Me.Controls""

        ''
        ''Order them in order of top-down (i.e. the Top property).
        ''
        ''Dim objListOfTextboxes_Ordered As IOrderedEnumerable(Of TextBox) =
        ''    From objTextbox In objListOfTextboxes
        ''    Select objTextbox
        ''    Order By objTextbox.Top

        ''Added 4/2/2022 td
        If (par_noSorting) Then Return objListOfRowHeaders

        ''4/5/2022 Dim objListOfTextboxes_Ordered As List(Of TextBox)
        Dim objListOfTextboxes_Ordered As List(Of RSCRowHeader) ''4/5/2022 TextBox)
        objListOfTextboxes_Ordered = objListOfRowHeaders.OrderBy(Of Integer)(Function(a) a.Top).ToList()

        Return objListOfTextboxes_Ordered

    End Function ''End of "Private Function ListOfTextboxes_TopToBottom() As IOrderedEnumerable(Of TextBox)"


    ''Private Function ListOfBottomBars_TopToBottom() As List(Of PictureBox) '' IOrderedEnumerable(Of PictureBox)
    ''    ''
    ''    ''Added 3/19/2022 td
    ''    ''
    ''    ''  The "Bottom Bars" ("Visual Bars") are the black-backcolor picture boxes which are
    ''    ''  very "landscape"-shaped, i.e. are very wide and very short (less than 5 pixels high).
    ''    ''  They are purely visual, i.e. only serve to create visually-obvious "rows" in the
    ''    ''  spreadsheet.----3/25/2022
    ''    ''
    ''    Dim objListOfBars As New List(Of PictureBox)
    ''    For Each eachCtl As Control In Me.Controls
    ''        If (TypeOf eachCtl Is PictureBox) Then
    ''            ''Strangely, .Visible is False???? 3/25/2022 td''If (eachCtl.Visible) Then
    ''            objListOfBars.Add(CType(eachCtl, PictureBox))
    ''            ''End If ''End of ""If (eachCtl.Visible) Then""
    ''        End If ''End of "If (TypeOf eachCtl Is TextBox) Then"
    ''    Next eachCtl ''End of ""For Each eachCtl As Control In Me.Controls""

    ''    ''
    ''    ''Order them in order of top-down (i.e. the Top property).
    ''    ''
    ''    ''Dim objListOfBars_Ordered As IOrderedEnumerable(Of PictureBox) =
    ''    ''    From objBar In objListOfBars
    ''    ''    Select objBar
    ''    ''    Order By objBar.Top
    ''    ''Return objListOfBars_Ordered

    ''    Dim objListOfTextboxes_Ordered As List(Of PictureBox)
    ''    objListOfTextboxes_Ordered = objListOfBars.OrderBy(Of Integer)(Function(a) a.Top).ToList()
    ''    Return objListOfTextboxes_Ordered

    ''End Function ''End of "Public Function ListOfBars_TopToBottom() As IOrderedEnumerable(Of PictureBox)"

    ''Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox2a.Click

    ''End Sub

    Public Sub ToggleEmptyRowMessage_ShowIfApplicable(par_manager_cols As RSCSpreadManagerCols)
        ''
        ''Added 10/23/2023 td
        ''
        mod_rowHeaderFirst_Factory.ToggleEmptyRowMessage_AllRowHdrs(True, par_manager_cols)


    End Sub ''End of ""Public Sub ToggleEmptyRowMessage_ShowIfApplicable()""


    Public Sub HeaderBox_MouseUp(sender As Object, par_eArgs As MouseEventArgs,
                                  Optional par_intRowIndex As Integer = -1) _
        Handles textRowHeader1.MouseUp
        ''
        ''Added 4/3/2022 thomas downes
        ''
        Dim new_eArgs As MouseEventArgs
        Dim controlSender As Control = CType(sender, Control)

        new_eArgs = New MouseEventArgs(par_eArgs.Button, par_eArgs.Clicks,
               par_eArgs.X + controlSender.Left,
               par_eArgs.Y + controlSender.Top,
                par_eArgs.Delta)

        ''Added 4/25/2022 thomas d.
        Dim objOperations As Operations_RSCRowHeaders
        objOperations = CType(MyBase.mod_objOperationsAny, Operations_RSCRowHeaders)
        objOperations.RowIndex_LastClicked = par_intRowIndex ''Added 4/25/2022 td

        MyBase.MoveableControl_MouseUp(Me, new_eArgs)

    End Sub

    Private Sub RSCRowHeaders_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub HeaderBox_MouseUp(sender As Object, e As MouseEventArgs) Handles textRowHeader1.MouseUp

    End Sub

    Private Sub textRowHeader15_Load(sender As Object, e As EventArgs)

    End Sub
End Class
