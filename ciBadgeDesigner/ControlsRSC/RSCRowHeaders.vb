''
''Added 2/21/2022 td
''
Imports __RSCWindowsControlLibrary ''Added 3/20/2022 Thomas Downes
Imports ciBadgeDesigner
Imports ciBadgeFields ''Added 3/10/2.0.2.2. thomas downes
Imports ciBadgeInterfaces ''Added 3/11/2022 t__homas d__ownes
Imports ciBadgeCachePersonality ''Added 3/14/2.0.2.2. t.//downes
Imports System.Drawing ''Added 3/20/2022 thomas downes

Public Class RSCRowHeaders
    ''
    ''Added 2/21/2022 td
    ''
    Public ParentForm_DesignerDialog As Form ''ciBadgeDesigner.DialogEditRecipients 
    Public Designer As ClassDesigner ''Added 3/10/2022 td
    Public ElementsCache_Deprecated As ciBadgeCachePersonality.ClassElementsCache_Deprecated ''Added 3/10/2022 td
    Public ColumnDataCache As CacheRSCFieldColumnWidthsEtc ''ClassColumnWidthsEtc ''Added 3/15/2022 td
    ''Probably not good to have circular references.3/25/2022 ''Public RSCSpreadsheet As RSCFieldSpreadsheet ''Added 3/24/2022 thomas downes

    Private mod_ctlLasttouched As New ClassLastControlTouched ''Added 1/4/2022 td
    Private mod_eventsSingleton As New GroupMoveEvents_Singleton(Me.Designer, False, True) ''Added 1/4/2022 td  
    Private mod_colorOfColumnsBackColor As System.Drawing.Color = Drawing.Color.AntiqueWhite ''Added 3/13/2022 thomas downes
    Private mod_array_RSCColumns As RSCFieldColumn() ''Added 3/14/2022 td
    Private Const mc_ColumnWidthDefault As Integer = 72 ''Added 3/20/2022 td
    Private Const mc_ColumnMarginGap As Integer = 3 ''---4 ''Added 3/20/2022 td


    Public Function CountOfRows() As Integer
        ''
        ''Added 4/3/2022 thomas downes  
        ''
        Dim listBoxes As List(Of TextBox)
        Const c_boolSkipSorting As Boolean = True
        listBoxes = ListOfTextboxes_TopToBottom(c_boolSkipSorting)
        Return listBoxes.Count

    End Function ''End of ""Public Function CountOfRows() As Integer""


    Public Function ListOfColumns() As List(Of RSCFieldColumn)

        ''Added 3/21/2022 thomas downes
        ''\\---Return New List(Of RSCFieldColumn)(mod_array_RSCColumns)
        Dim oList As List(Of RSCFieldColumn)
        oList = New List(Of RSCFieldColumn)(mod_array_RSCColumns)
        oList.Remove(Nothing) ''Item #0 is Nothing, so let's omit the Null reference. 
        Return oList

    End Function ''ENd of "Public Function ListOfColumns() As List(Of RSCFieldColumn)"


    Public Shared Function GetRSCRowHeaders(par_designer As ClassDesigner,
                                       par_formParent As Form,
                                      par_nameOfControl As String,
                                      par_objSpreadsheet As RSCFieldSpreadsheet) As RSCRowHeaders
        ''
        ''Added 3/21/2022 td
        ''
        Dim objParametersGetElementCtl As ClassGetElementControlParams
        objParametersGetElementCtl = par_designer.GetParametersToGetElementControl()

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
        Dim CtlRowHeaders = New RSCRowHeaders(par_formParent,
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
            ''.ColumnIndex = par_intColumnIndex

        End With ''End of "With objOperationsRSCRowHeaders"

        ''
        ''Return output value.
        ''
        Return CtlRowHeaders

    End Function ''end of "Public Shared Function GetRSCRowHeaders() As RSCRowHeaders"


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
        MyBase.New(EnumElementType.RSCRowHeaders, par_oParentForm,
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


    Public Sub AlignControlsWithSpreadsheet(par_controlColumnOne As RSCFieldColumn)
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
        Dim listBoxesColumn1 As List(Of TextBox)
        Dim listBoxesRowHdrs As List(Of TextBox)
        Dim listVisualBarsColumn1 As List(Of PictureBox)
        Dim listVisualBarsRowHdrs As List(Of PictureBox)

        ''March25 2022''objSpreadsheet = Me.RSCSpreadsheet
        ''March25 2022''objColumnOne = objSpreadsheet.RscFieldColumn1
        ''objColumnOne.Refresh()
        ''March25 2022''listBoxesColumn1 = objColumnOne.ListOfTextboxes_TopToBottom
        ''March25 2022''listBoxesColumn1 = par_listColumnBoxes

        listBoxesColumn1 = par_controlColumnOne.ListOfTextboxes_TopToBottom()
        listBoxesRowHdrs = ListOfTextboxes_TopToBottom()
        listVisualBarsColumn1 = par_controlColumnOne.ListOfBottomBars_TopToBottom()
        listVisualBarsRowHdrs = ListOfBottomBars_TopToBottom()

        ''Major call.
        AlignTextboxes(listBoxesColumn1, listBoxesRowHdrs)
        AlignBottomBars(listVisualBarsColumn1, listVisualBarsRowHdrs, par_controlColumnOne)

    End Sub ''End of ""Public Sub AlignControlsWithSpreadsheet()""


    Public Sub AlignBottomBars_WithColumnOne(par_controlColumnOne As RSCFieldColumn)
        ''
        ''Added 3/26/2022 thomas Downes 
        ''
        ''Dim listBoxesColumn1 As List(Of TextBox)
        ''Dim listBoxesRowHdrs As List(Of TextBox)
        Dim listVisualBarsColumn1 As List(Of PictureBox)
        Dim listVisualBarsRowHdrs As List(Of PictureBox)

        ''listBoxesColumn1 = par_controlColumnOne.ListOfTextboxes_TopToBottom()
        ''listBoxesRowHdrs = ListOfTextboxes_TopToBottom()
        listVisualBarsColumn1 = par_controlColumnOne.ListOfBottomBars_TopToBottom()
        listVisualBarsRowHdrs = ListOfBottomBars_TopToBottom()

        ''Major call....
        AlignBottomBars(listVisualBarsColumn1, listVisualBarsRowHdrs, par_controlColumnOne)

    End Sub ''End of "Public Sub AlignBottomBars_WithColumnOne()"


    Public Sub AlignTextBoxes_ToBottomBars(par_controlColumnOne As RSCFieldColumn)
        ''
        ''Added 3/26/2022 thomas Downes 
        ''
        Dim listBoxesColumn1 As List(Of TextBox)
        Dim listBoxesRowHdrs As List(Of TextBox)
        Dim listVisualBarsColumn1 As List(Of PictureBox)
        Dim listVisualBarsRowHdrs As List(Of PictureBox)
        listBoxesColumn1 = par_controlColumnOne.ListOfTextboxes_TopToBottom()
        listBoxesRowHdrs = ListOfTextboxes_TopToBottom()
        listVisualBarsColumn1 = par_controlColumnOne.ListOfBottomBars_TopToBottom()
        listVisualBarsRowHdrs = ListOfBottomBars_TopToBottom()



    End Sub ''End of "Public Sub AlignTextBoxes_ToBottomBars()"



    Private Sub AlignTextboxes(par_listBoxesColumn As IEnumerable(Of TextBox),
                               par_listBoxesRowHdrs As IEnumerable(Of TextBox))
        ''
        ''Added 3/24/2022 thomas d.  
        ''
        ''---For Each eachColumnBox As TextBox In par_listBoxesColumn
        Dim eachBoxColumn As TextBox
        Dim eachBoxHeader As TextBox

        Dim TopBoxColumn As TextBox ''Addded 3/25/2022 td
        Dim TopBoxHeader As TextBox ''Added 3/25/2022 td
        Dim boolSkipTopBox As Boolean

        TopBoxColumn = par_listBoxesColumn(0) ''Added 3/25/2022 td
        TopBoxHeader = par_listBoxesRowHdrs(0) ''Added 3/25/2022 td
        boolSkipTopBox = True

        ''Added 3/30/2022 thomas downes
        Load_EmptyRows(par_listBoxesColumn.Count)
        par_listBoxesRowHdrs = Me.ListOfTextboxes_TopToBottom()

        ''
        ''Loop through the rows
        ''
        For intBoxIndex As Integer = 0 To (-1 + par_listBoxesColumn.Count)

            ''Skip the top boxes. 
            If (boolSkipTopBox And intBoxIndex = 0) Then Continue For

            eachBoxColumn = Nothing
            eachBoxHeader = Nothing

            Try
                eachBoxColumn = par_listBoxesColumn(intBoxIndex)
            Catch
            End Try

            Try
                eachBoxHeader = par_listBoxesRowHdrs(intBoxIndex)
            Catch
            End Try

            If (eachBoxHeader Is Nothing And eachBoxColumn Is Nothing) Then
                Exit For

            ElseIf (eachBoxColumn Is Nothing) Then
                ''Exit Sub
                Throw New Exception("There are more row headers than (column #1's) rows.")

            ElseIf (eachBoxHeader Is Nothing) Then
                ''Exit Sub
                Throw New Exception("There are more rows than row headers.")

            ElseIf (boolSkipTopBox) Then
                ''eachBoxHeader.Height = eachBoxColumn.Height
                eachBoxHeader.Height = eachBoxColumn.Height
                eachBoxHeader.Top = (eachBoxColumn.Top - TopBoxColumn.Top) +
                                       TopBoxHeader.Top

            Else
                eachBoxHeader.Height = eachBoxColumn.Height
                eachBoxHeader.Top = eachBoxColumn.Top

            End If ''End of ""If (eachBoxHeader Is Nothing And eachBoxColumn Is Nothing) Then... ElseIf ... ElseIf ... ElseIf ... Else ...

        Next intBoxIndex

        ''---Next eachColumnBox
    End Sub ''End of "Private Sub AlignTextboxes"


    Private Sub AlignBottomBars(par_listBottomBarsColumn1 As IEnumerable(Of PictureBox),
                               par_listBottomBarsRowHdrs As IEnumerable(Of PictureBox),
                                par_RSCFieldColumn1 As RSCFieldColumn)
        ''
        ''Added 3/24/2022 thomas d.  
        ''
        ''  The "Bottom Bars" ("Visual Bars") are the black-backcolor picture boxes which are
        ''  very "landscape"-shaped, i.e. are very wide and very short (less than 5 pixels high).
        ''  They are purely visual, i.e. only serve to create visually-obvious "rows" in the
        ''  spreadsheet.----3/25/2022
        ''
        ''---For Each eachColumnBox As TextBox In par_listBoxesColumn
        Dim eachBarColumn As PictureBox
        Dim eachBarHeader As PictureBox
        Dim TopBarColumn As PictureBox ''Addded 3/25/2022 td
        Dim TopBarHeader As PictureBox ''Added 3/25/2022 td
        Dim boolSkipTopBar As Boolean ''Added 3/25/2022 td

        TopBarColumn = par_listBottomBarsColumn1(0) ''Added 3/25/2022 td
        TopBarHeader = par_listBottomBarsRowHdrs(0) ''Added 3/25/2022 td

        ''
        ''Step 1 of 2.  Address the Initial Gap. 
        ''
        ''Added 3/25/2022
        Dim intLocationVertical_1stBarInColumn As Integer
        Dim intLocationVertical_1stBarInRowHdrsCtl As Integer
        Dim intInitialGap As Integer

        intLocationVertical_1stBarInColumn = par_RSCFieldColumn1.Top + TopBarColumn.Top
        intLocationVertical_1stBarInRowHdrsCtl = Me.Top + TopBarHeader.Top
        intInitialGap = (intLocationVertical_1stBarInColumn -
                          intLocationVertical_1stBarInRowHdrsCtl)
        Me.Top += intInitialGap

        ''
        ''Step 2 of 2. Loop through the rows
        ''
        boolSkipTopBar = True
        For intBoxIndex As Integer = 0 To (-1 + par_listBottomBarsColumn1.Count)

            eachBarColumn = Nothing
            eachBarHeader = Nothing

            Try
                eachBarColumn = par_listBottomBarsColumn1(intBoxIndex)
            Catch
            End Try

            Try
                eachBarHeader = par_listBottomBarsRowHdrs(intBoxIndex)
            Catch
            End Try

            If (eachBarHeader Is Nothing And eachBarColumn Is Nothing) Then
                Exit For
            ElseIf (eachBarColumn Is Nothing) Then
                ''Exit Sub
                Throw New Exception("There are more row headers than (column #1's) rows.")

            ElseIf (eachBarHeader Is Nothing) Then
                ''Exit Sub
                Throw New Exception("There are more rows than row headers.")

            ElseIf (boolSkipTopBar) Then
                eachBarHeader.Height = eachBarColumn.Height
                eachBarHeader.Top = (eachBarColumn.Top - TopBarColumn.Top) +
                                       TopBarHeader.Top

            Else
                eachBarHeader.Top = eachBarColumn.Top
                eachBarHeader.Height = eachBarColumn.Height

            End If

        Next intBoxIndex

        ''---Next eachColumnBox
    End Sub ''End of "Private Sub AlignBottomBars"


    Public Sub Load_OneEmptyRow_IfNeeded(par_intRowIndex As Integer)
        ''
        ''Added 4/4/2022 td
        ''






    End Sub ''End of ""Public Sub Load_EmptyRow_IfNeeded(par(intRowIndex As Integer)""
    ''



    Public Sub Load_EmptyRows(par_intRowsRequired As Integer)
        ''
        ''Added 3/29/2022 thomas downes
        ''
        Dim ref_intCountRows As Integer = 0
        Dim intCountRows As Integer = 0

        ''CountOfBoxesWithData(ref_intCountRows)
        ''intCountRows = ref_intCountRows
        intCountRows = ListOfBottomBars_TopToBottom().Count

        If (intCountRows = par_intRowsRequired) Then Exit Sub
        If (intCountRows > par_intRowsRequired) Then Load_EmptyRows_DeleteRows(par_intRowsRequired)
        If (intCountRows < par_intRowsRequired) Then Load_EmptyRows_CreateRows(par_intRowsRequired)

    End Sub ''End of ""Public Sub Load_EmptyRows()""


    Private Sub Load_EmptyRows_CreateRows(par_intRowsRequired As Integer)
        ''
        ''Added 3/29/2022 thomas downes
        ''
        Dim listOfBoxes As List(Of TextBox)
        Dim textbox_Top As TextBox
        Dim textbox_BottomLast As TextBox
        Dim textbox_BottomDeux As TextBox
        Dim intIndexStart As Integer
        Dim intIndex__End As Integer
        Dim intTopGap As Integer

        listOfBoxes = ListOfTextboxes_TopToBottom()
        textbox_Top = listOfBoxes(0)

        textbox_BottomLast = listOfBoxes(-1 + listOfBoxes.Count) ''.LastOrDefault
        textbox_BottomDeux = listOfBoxes(-2 + listOfBoxes.Count) ''.LastOrDefault

        intIndexStart = (listOfBoxes.Count - 1 + 1)
        intIndex__End = (par_intRowsRequired - 1)
        intTopGap = (textbox_BottomLast.Top - textbox_BottomDeux.Top)

        For intRowIndex As Integer = intIndexStart To intIndex__End
            ''
            ''Create the required textbox. 
            ''
            Dim objTextbox As New TextBox ''Added 3/29/2022 thomas downes
            With objTextbox
                .Left = textbox_Top.Left
                .Width = textbox_Top.Width
                .Height = textbox_Top.Height
                .Anchor = textbox_Top.Anchor
                .BackColor = textbox_Top.BackColor
                .ForeColor = textbox_Top.ForeColor
                .BorderStyle = textbox_Top.BorderStyle
                .Font = textbox_Top.Font
                .Top = (textbox_BottomLast.Top + intTopGap)
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



    Public Function ListOfTextboxes_TopToBottom(Optional par_noSorting As Boolean = False) As List(Of TextBox) ''IOrderedEnumerable(Of TextBox)
        ''
        ''Added 3/19/2022 td
        ''
        Dim objListOfTextboxes As New List(Of TextBox)
        ''Dim objListOfTextboxes_Ordered ''As New IOrderedEnumerable(Of(Of TextBox)

        For Each eachCtl As Control In Me.Controls
            If (TypeOf eachCtl Is TextBox) Then
                ''Strangely, .Visible is False???? 3/25/2022 td''If (eachCtl.Visible) Then
                objListOfTextboxes.Add(CType(eachCtl, TextBox))
                ''End If
            End If ''End of "If (TypeOf eachCtl Is TextBox) Then"
        Next eachCtl ''End of ""For Each eachCtl As Control In Me.Controls""

        ''
        ''Order them in order of top-down (i.e. the Top property).
        ''
        ''Dim objListOfTextboxes_Ordered As IOrderedEnumerable(Of TextBox) =
        ''    From objTextbox In objListOfTextboxes
        ''    Select objTextbox
        ''    Order By objTextbox.Top

        ''Added 4/2/2022 td
        If (par_noSorting) Then Return objListOfTextboxes

        Dim objListOfTextboxes_Ordered As List(Of TextBox)
        objListOfTextboxes_Ordered = objListOfTextboxes.OrderBy(Of Integer)(Function(a) a.Top).ToList()

        Return objListOfTextboxes_Ordered

    End Function ''End of "Private Function ListOfTextboxes_TopToBottom() As IOrderedEnumerable(Of TextBox)"


    Private Function ListOfBottomBars_TopToBottom() As List(Of PictureBox) '' IOrderedEnumerable(Of PictureBox)
        ''
        ''Added 3/19/2022 td
        ''
        ''  The "Bottom Bars" ("Visual Bars") are the black-backcolor picture boxes which are
        ''  very "landscape"-shaped, i.e. are very wide and very short (less than 5 pixels high).
        ''  They are purely visual, i.e. only serve to create visually-obvious "rows" in the
        ''  spreadsheet.----3/25/2022
        ''
        Dim objListOfBars As New List(Of PictureBox)
        For Each eachCtl As Control In Me.Controls
            If (TypeOf eachCtl Is PictureBox) Then
                ''Strangely, .Visible is False???? 3/25/2022 td''If (eachCtl.Visible) Then
                objListOfBars.Add(CType(eachCtl, PictureBox))
                ''End If ''End of ""If (eachCtl.Visible) Then""
            End If ''End of "If (TypeOf eachCtl Is TextBox) Then"
        Next eachCtl ''End of ""For Each eachCtl As Control In Me.Controls""

        ''
        ''Order them in order of top-down (i.e. the Top property).
        ''
        ''Dim objListOfBars_Ordered As IOrderedEnumerable(Of PictureBox) =
        ''    From objBar In objListOfBars
        ''    Select objBar
        ''    Order By objBar.Top
        ''Return objListOfBars_Ordered

        Dim objListOfTextboxes_Ordered As List(Of PictureBox)
        objListOfTextboxes_Ordered = objListOfBars.OrderBy(Of Integer)(Function(a) a.Top).ToList()
        Return objListOfTextboxes_Ordered

    End Function ''End of "Public Function ListOfBars_TopToBottom() As IOrderedEnumerable(Of PictureBox)"

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click

    End Sub

    Private Sub HeaderBox_MouseUp(sender As Object, par_eArgs As MouseEventArgs) _
        Handles textRowHeader1.MouseUp, textRowHeader2.MouseUp, textRowHeader3.MouseUp,
          textRowHeader4.MouseUp, textRowHeader5.MouseUp, textRowHeade6.MouseUp,
          textRowHeader7.MouseUp, textRowHeader8.MouseUp, textRowHeader9.MouseUp,
          textRowHeader10.MouseUp, textRowHeader11.MouseUp, textRowHeader12.MouseUp
        ''
        ''Added 4/3/2022 thomas downes
        ''
        Dim new_eArgs As MouseEventArgs
        Dim controlSender As Control = CType(sender, Control)

        new_eArgs = New MouseEventArgs(par_eArgs.Button, par_eArgs.Clicks,
               par_eArgs.X + controlSender.Left,
               par_eArgs.Y + controlSender.Top,
                par_eArgs.Delta)

        MyBase.MoveableControl_MouseUp(Me, new_eArgs)

    End Sub

    Private Sub RSCRowHeaders_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
