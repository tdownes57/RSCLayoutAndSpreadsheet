Option Explicit On
Option Strict On
''
''Added 2/21/2022 thomas downes
''
Imports ciBadgeInterfaces ''Added 8/14/2019 thomas d. 
Imports ciBadgeElements ''Added 9/18/2019 td 
Imports ciBadgeDesigner ''Added 3/8/2022 td  
Imports System.Drawing ''Added 10/01/2019 td 
Imports __RSCWindowsControlLibrary ''Added 1/4/2022 td
Imports ciBadgeFields ''Added 3/8/2022 thomas downes
Imports ciBadgeCachePersonality ''Added 3/14/2022 
Imports ciBadgeRecipients ''Added 3/22/2022 td

Public Class RSCFieldColumn
    ''
    ''Added 2/21/2022 thomas downes  
    ''
    Public ElementsCache_Deprecated As ciBadgeCachePersonality.ClassElementsCache_Deprecated ''Added 3/10/2022 td
    Public ColumnDataCache As CacheRSCFieldColumnWidthsEtc ''Added 3/15/2022 td
    Public ListRecipients As IEnumerable(Of ClassRecipient) ''Added 3/22/2022 td

    Private mod_listOfColumnsToBumpRight As List(Of RSCFieldColumn)
    Private mod_columnWidthAndData As ClassColumnWidthAndData ''Added 3/18/2022  
    Private mod_arrayOfData_Undo As String() ''Added 3/20/2022 thomas d.

    Public Property ColumnWidthAndData() As ClassColumnWidthAndData ''Added 3/15/2022 td
        ''Added 3/18/2022 thomas 
        Get
            ''Added 3/18/2022 thomas
            ''  Probably only for testing!!
            Return mod_columnWidthAndData
        End Get
        Set(value As ClassColumnWidthAndData)
            ''Added 3/18/2022 thomas 
            mod_columnWidthAndData = value
        End Set
    End Property


    Public Property ListOfColumnsToBumpRight As List(Of RSCFieldColumn) ''Added 3/12/2022 td 
        Get
            Return mod_listOfColumnsToBumpRight
        End Get
        Set(value As List(Of RSCFieldColumn))
            mod_listOfColumnsToBumpRight = value

            If (MyBase.mod_iMoveOrResizeFunctionality Is Nothing) Then Return

            If (value Is Nothing) Then
                MyBase.mod_iMoveOrResizeFunctionality.ListOfColumnsToBumpRight = Nothing
            Else
                Dim listUserControls As New List(Of UserControl)(value)
                ''March13 2022 td''MyBase.mod_iMoveOrResizeFunctionality.ListOfColumnsToBumpRight = value
                MyBase.mod_iMoveOrResizeFunctionality.ListOfColumnsToBumpRight = listUserControls
            End If

        End Set
    End Property


    Public Shared Function GetRSCFieldColumn(par_designer As ClassDesigner,
                                             par_field As ClassFieldAny,
                                       par_formParent As Form,
                                      par_nameOfControl As String,
                                      par_bProportionSizing As Boolean,
                                     par_oSpreadsheet As RSCFieldSpreadsheet,
                                     par_intColumnIndex As Integer) As RSCFieldColumn
        ''
        ''Added 3/21/2022 td
        ''
        Dim objParametersGetElementCtl As ClassGetElementControlParams
        objParametersGetElementCtl = par_designer.GetParametersToGetElementControl()

        Return GetRSCFieldColumn(objParametersGetElementCtl,
                                 par_field,
                                 par_formParent,
                                 par_nameOfControl,
                                   CType(par_designer, ILayoutFunctions),
                                   par_bProportionSizing,
                                    CType(par_designer.ControlLastTouched, ILastControlTouched),
                                    CType(par_designer, IRecordElementLastTouched),
                                    par_designer.GroupMoveEvents,
                                     par_oSpreadsheet,
                                     par_intColumnIndex)

    End Function ''End of "Public Shared Function GetRSCFieldColumn"


    Public Shared Function GetRSCFieldColumn(par_parametersGetElementControl As ClassGetElementControlParams,
                                           par_field As ClassFieldAny,
                                       par_formParent As Form,
                                      par_nameOfControl As String,
                                      par_iLayoutFun As ILayoutFunctions,
                                      par_bProportionSizing As Boolean,
                                      par_iControlLastTouched As ILastControlTouched,
                                     par_iRecordLastControl As IRecordElementLastTouched,
                                     par_oMoveEventsForGroupedCtls As GroupMoveEvents_Singleton,
                                     par_oSpreadsheet As RSCFieldSpreadsheet,
                                     par_intColumnIndex As Integer) As RSCFieldColumn
        ''
        ''Added 3/8/2022 & 1/04/2022 td
        ''
        ''Unused. Jan17 2022''Const c_enumElemType As EnumElementType = EnumElementType.Portrait
        Const bAddFunctionalitySooner As Boolean = False
        Const bAddFunctionalityLater As Boolean = True

        Dim typeOps As Type
        Dim objOperations As Object ''Added 12/29/2021 td 
        Dim objOperationsFieldColumn As Operations_RSCFieldColumn ''Modified 3/13/2022 td 
        Dim sizeElementPortrait As New Size() ''Added 1/26/2022 td

        ''Added 1/5/2022 td
        If (par_field Is Nothing) Then Throw New Exception("The Field is missing!")

        ''Instantiate the Operations Object. 
        ''
        ''//If (enumElemType = EnumElementType.Signature) Then objOperations2Use = New Operations__Useless()
        ''//If (enumElemType = EnumElementType.StaticGraphic) Then objOperations1Gen = New Operations__Generic()
        ''//If (enumElemType = EnumElementType.StaticText) Then objOperations2Use = New Operations__Useless()
        ''====If (c_enumElemType = EnumElementType.QRCode) Then objOperationsQR = New Operations_QRCode()

        ''Modified 1/2/2022 td
        objOperationsFieldColumn = New Operations_RSCFieldColumn() ''Added 3/13/2022 td
        typeOps = objOperationsFieldColumn.GetType()
        objOperations = objOperationsFieldColumn

        If (objOperations Is Nothing) Then
            ''Added 12/29/2021
            Throw New Exception("Ops is Nothing, so I guess Element Type is Undetermined.")
        End If ''end of "If (objOperations Is Nothing) Then"

        ''Added 12/2/2022 td
        Dim enumElementType_Enum As EnumElementType = EnumElementType.Portrait

        ''Create the control. 
        Dim CtlFieldColumn1 = New RSCFieldColumn(par_field, par_formParent,
                                                  par_iLayoutFun,
                                      par_parametersGetElementControl.iRefreshPreview,
                                                  sizeElementPortrait,
                                                   par_bProportionSizing,
                                                   typeOps, objOperations,
                                                   bAddFunctionalitySooner,
                                                   bAddFunctionalitySooner,
                                                   par_iControlLastTouched,
                                                    par_oMoveEventsForGroupedCtls)
        ''Jan2 2022 ''                       ''Jan2 2022 ''par_iSaveToModel, typeOps,

        With CtlFieldColumn1
            .Name = par_nameOfControl
            ''1/11/2022''If (bAddFunctionalityLater) Then .AddMoveability(par_oMoveEvents, par_iLayoutFun)
            If (bAddFunctionalityLater) Then .AddMoveability(par_iLayoutFun,
                                                             par_oMoveEventsForGroupedCtls, Nothing)
            If (bAddFunctionalityLater) Then .AddClickability()

            ''Added 2/5/2022 td
            ''3/13/2022 td''.RightclickMouseInfo = objOperationsPortrait ''Added 2/5/2022 td
            .RightclickMouseInfo = objOperationsFieldColumn ''Added 3/5/2022 td

        End With ''eNd of "With CtlPortrait1"

        ''
        ''Specify the current element to the Operations object. 
        ''
        ''Dim infoOps = CType(objOperations, ICurrentElement) ''.CtlCurrentElement = MoveableControlVB1
        ''infoOps.CtlCurrentElement = CtlFieldColumn1
        ''''Added 1/17/2022 td 
        ''infoOps.ElementsCacheManager = par_parametersGetElementControl.ElementsCacheManager

        ''Added 1/24/2022 thomas d. 
        With objOperationsFieldColumn
            .CtlCurrentControl = CtlFieldColumn1
            .CtlCurrentElement = CtlFieldColumn1
            ''.Designer = par_oMoveEventsForGroupedCtls.
            .Designer = par_parametersGetElementControl.DesignerClass
            ''.ElementInfo_Base = Nothing ''3/9/2022 t*d*''par_elementPortrait
            .ElementsCacheManager = par_parametersGetElementControl.ElementsCacheManager
            ''Feb3 2022 td''.Element_Type = Enum_ElementType.StaticGraphic
            .Element_Type = Enum_ElementType.Portrait ''Added 2/3/2022 thomas d.
            .EventsForMoveability_Group = par_oMoveEventsForGroupedCtls
            .EventsForMoveability_Single = Nothing
            ''Added 1/24/2022 thomas downes
            .LayoutFunctions = .Designer

            ''Added 3/20/2022 thomas dRRoRRwRRnRReRRsRR
            .ParentSpreadsheet = par_oSpreadsheet
            .ColumnIndex = par_intColumnIndex

        End With ''End of "With objOperationsPortrait"

        ''Added 3/13/2022 thomas downes
        CtlFieldColumn1.Load_ResizeWidthability()

        Return CtlFieldColumn1

    End Function ''end of "Public Shared Function GetRSCFieldColumn() As RSCFieldColumn"


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

    End Sub


    Public Sub New(par_field As ciBadgeFields.ClassFieldAny,
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
        ''         ''Not needed. 1/2/2022'' par_iSaveToModel As ISaveToModel,
        ''         ''Not needed. 1/2/2022'' par_enumElementType As EnumElementType,
        ''
        ''Added 1/04/2022 td
        ''
        ''Jan1 2022 td''MyBase.New(par_enumElementType, pboolResizeProportionally,
        MyBase.New(EnumElementType.Portrait, par_oParentForm,
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

        ''Encapsulated 12/30/2021 td
        New_RSCFieldColumn(par_field, par_iLayoutFun)

    End Sub


    Public Sub Load_FieldsFromCache(par_cache As ClassElementsCache_Deprecated)
        ''
        ''Added 3/14/2022 td
        ''
        If (par_cache Is Nothing) Then Throw New ArgumentException("Exception Occured")

        RscSelectCIBField1.ElementsCache_Deprecated = Me.ElementsCache_Deprecated
        RscSelectCIBField1.Load_FieldsFromCache(par_cache)

        ''
        ''Added 3/15/2022 td
        ''
        RscSelectCIBField1.SelectedValue = mod_columnWidthAndData.CIBField

        ''
        ''Added 3/19/2022  
        ''
        ''Restore the width of the columns determined by the user's resizing behavior
        ''   in the prior session.  
        ''
        Me.Width = mod_columnWidthAndData.Width

        ''
        ''Added 3/19/2022  
        ''
        LoadDataToColumn(mod_columnWidthAndData.ColumnData)


    End Sub ''end of "Public Sub Load_FieldsFromCache"


    Private Sub LoadDataToColumn(par_listData As List(Of String))
        ''
        ''Added 3/19/2022 td
        ''
        Dim indexItem As Integer = 0
        For Each each_textbox In ListOfTextboxes_TopToBottom()

            each_textbox.Text = par_listData.Item(indexItem)
            each_textbox.ForeColor = Color.Black
            indexItem += 1

        Next each_textbox

    End Sub ''End of "Private Sub LoadDataToColumn()"


    Public Sub ClearDataFromColumn_Do() ''Added 3/20/2022
        ''
        ''Added 3/20/2022 t//d//
        ''
        Dim indexItem As Integer = 0
        Dim listTextboxes As IEnumerable(Of TextBox)

        listTextboxes = ListOfTextboxes_TopToBottom()
        ReDim mod_arrayOfData_Undo(-1 + listTextboxes.Count)

        For Each each_textbox In listTextboxes '' ListOfTextboxes_TopToBottom()

            ''Enable the Undo procedure.
            mod_arrayOfData_Undo(indexItem) = each_textbox.Text
            indexItem += 1

            ''Clear the textbox of data.  
            each_textbox.Text = ""

        Next each_textbox

    End Sub ''End of "Private Sub LoadDataToColumn_Do()"


    Public Sub ClearDataFromColumn_Undo(Optional pboolSkipBoxesWithData As Boolean = False)
        ''
        ''Added 3/20/2022 td
        ''
        Dim indexItem As Integer = 0
        Dim listTextboxes As IEnumerable(Of TextBox)
        Dim bExpectedLength As Boolean
        Dim boolHasDataToKeep As Boolean

        listTextboxes = ListOfTextboxes_TopToBottom()
        bExpectedLength = (listTextboxes.Count = mod_arrayOfData_Undo.Length)
        If (bExpectedLength) Then
            For Each each_textbox In listTextboxes '' ListOfTextboxes_TopToBottom()

                ''Added 3/20/2022 td
                boolHasDataToKeep = pboolSkipBoxesWithData And Not String.IsNullOrEmpty(each_textbox.Text)
                If (boolHasDataToKeep) Then
                    indexItem += 1 ''We must increment the index before the next iteration.
                    Continue For ''Skips the execution of this iteration & continues at next iteration.
                End If ''End of "If (boolHasDataToKeep) Then"

                ''Restore the textbox of data.  
                each_textbox.Text = mod_arrayOfData_Undo(indexItem)
                indexItem += 1

            Next each_textbox

        ElseIf (mod_arrayOfData_Undo.Length <= 1) Then
            ''Added 3/20/2022 td
            MessageBoxTD.Show_Statement("Cannot perform Undo. No data found.")
        Else
            ''Length is unexpected.  
            System.Diagnostics.Debugger.Break()

        End If ''End of "If (bExpectedLength) Then..... ElseIf (...) ... Else...."

    End Sub ''End of "Private Sub LoadDataToColumn_Undo()"


    Public Function CountOfBoxesWithData(Optional ByRef pref_countOfRows As Integer = 0) As Integer ''Added 3/20/2022
        ''
        ''Added 3/20/2022 t//d//
        ''
        Dim intCountData As Integer = 0
        Dim listTextboxes As IEnumerable(Of TextBox)

        listTextboxes = ListOfTextboxes_TopToBottom()
        pref_countOfRows = listTextboxes.Count ''Added 3/23/2022 td

        For Each each_textbox In listTextboxes '' ListOfTextboxes_TopToBottom()

            If (Not String.IsNullOrEmpty(each_textbox.Text)) Then intCountData += 1

        Next each_textbox

        Return intCountData

    End Function ''End of "Private Sub LoadDataToColumn_Do()"


    Public Function GetFirstTextboxPropertyTop() As Integer
        ''
        ''Added 3/24/2022 thomas downes
        ''
        Dim objFirstTextbox As TextBox
        objFirstTextbox = ListOfTextboxes_TopToBottom().First()
        Return objFirstTextbox.Top

    End Function ''end of ""Public Function GetFirstTextboxPropertyTop() As Integer""


    Public Sub New_RSCFieldColumn(par_field As ciBadgeFields.ClassFieldAny, par_iLayoutFunctions As ILayoutFunctions)
        ''---Public Sub New_Portrait(par_elementPic As ClassElementPortrait, par_iLayoutFunctions As ILayoutFunctions)
        ''
        ''Added 3/8/2022 TD
        ''

        ''The copy-pasted code has been deleted.  Not needed. ---3/8/2022 td


    End Sub ''End of "Public Sub New"


    Public Sub Load_ResizeWidthability()
        ''
        ''Added 3/2/2022 td
        ''
        ''Add the ability to adjust the size (width only) of the column. 
        ''
        ''March4 2022 ''Dim sizingParams As New MoveAndResizeControls_Monem.StructResizeParams
        Dim sizingParams As New MoveAndResizeControls_Monem.ClassStructResizeParams

        sizingParams.InitiateResizing = True ''Added 3/13/2022 td
        sizingParams.KeepProportional_HtoW = False ''Added 3/13/2022 td
        sizingParams.RightEdgeResizing_Only = True

        MyBase.AddSizeability(True, sizingParams)

    End Sub ''End of "Public Sub Load_ResizeWidthability()"


    Public Overrides Sub RemoveMouseEventHandlers_ChildClass()
        ''
        ''Added 1/12/2022 
        ''
        RemoveHandler Me.MouseDown, AddressOf RSCFieldColumn_MouseDown
        RemoveHandler Me.MouseMove, AddressOf RSCFieldColumn_MouseMove
        RemoveHandler Me.MouseUp, AddressOf RSCFieldColumn_MouseUp

    End Sub ''End of "Protected Overrides Sub RemoveMouseEventHandlers()"


    Public Overrides Sub AddMouseEventHandlers_ChildClass()
        ''
        ''Added 1/12/2022 
        ''
        RemoveHandler Me.MouseDown, AddressOf RSCFieldColumn_MouseDown
        RemoveHandler Me.MouseMove, AddressOf RSCFieldColumn_MouseMove
        RemoveHandler Me.MouseUp, AddressOf RSCFieldColumn_MouseUp

        AddHandler Me.MouseDown, AddressOf RSCFieldColumn_MouseDown
        AddHandler Me.MouseMove, AddressOf RSCFieldColumn_MouseMove
        AddHandler Me.MouseUp, AddressOf RSCFieldColumn_MouseUp

    End Sub ''End of "Protected Overrides Sub AddMouseEventHandlers()"


    Public Overrides Sub SaveToModel()

        ''MyBase.SaveToModel()

        ''Not needed here, as this derived user control does not represent a badge element. -----3/11/2022

    End Sub ''End of Public Overrides SaveToModel"


    Public Sub LoadRecipientList(Optional ByRef pboolErrorCellsHaveValues As Boolean = False,
                                 Optional ByRef pboolNoFieldSelected As Boolean = False,
                                 Optional ByRef pboolNoRecipientList As Boolean = False)
        ''
        ''Added 3/22/2022 td
        ''
        Dim intCountAllBoxesOrRows As Integer ''Added 3/23/2022 td
        Dim intCountBoxesEmptyOrNot As Integer ''Added 3/23/2022 td

        Dim intCountCellsWithData As Integer
        ''March23 2022''intCountCellsWithData = CountOfBoxesWithData()
        intCountCellsWithData = CountOfBoxesWithData(intCountBoxesEmptyOrNot)
        If (intCountCellsWithData <> 0) Then
            pboolErrorCellsHaveValues = True
            Throw New Exception("Warning, non-zero >0 cells with data already. Data would be lost.")
        End If

        Dim enumFieldSelected As EnumCIBFields
        enumFieldSelected = RscSelectCIBField1.SelectedValue
        If (enumFieldSelected = EnumCIBFields.Undetermined) Then
            pboolNoFieldSelected = True
            MessageBoxTD.Show_Statement("Warning, not all columns have a specified field.")
            Return
        End If

        Dim boolNoRecipList As Boolean
        boolNoRecipList = (Me.ListRecipients Is Nothing)
        pboolNoRecipientList = boolNoRecipList
        If (pboolNoRecipientList) Then
            Throw New Exception("ListRecipients is a Null reference.")
            Return
        End If

        Dim intCountRecipients As Integer
        intCountRecipients = Me.ListRecipients.Count

        Dim boolNoRecipients_zero As Boolean
        boolNoRecipients_zero = (0 = intCountRecipients)
        If (boolNoRecipients_zero) Then
            pboolNoRecipientList = True
            Throw New Exception("ListRecipients has Zero(0) recipient (student) rows.")
            Return
        End If

        Dim boolMismatchOfCounts As Boolean
        intCountAllBoxesOrRows = intCountBoxesEmptyOrNot
        boolMismatchOfCounts = (intCountAllBoxesOrRows <> Me.ListRecipients.Count) ''Then
        If (boolMismatchOfCounts) Then
            pboolErrorCellsHaveValues = True
            Throw New Exception("Warning, non-zero >0 cells with data already. Data would be lost.")
        End If ''End of ""If (boolMismatchOfCounts) then""

        ''-----------------------------------------------------------

        Dim listBoxes As IOrderedEnumerable(Of TextBox)
        Dim intRowIndex As Integer = -1
        listBoxes = ListOfTextboxes_TopToBottom()

        For Each each_box As TextBox In listBoxes

            intRowIndex += 1

            each_box.Text = Me.ListRecipients(intRowIndex).GetTextValue(enumFieldSelected)

        Next each_box

    End Sub ''End of "Public Sub LoadRecipientList()"


    Private Function ListOfData() As List(Of String)
        ''
        ''Added 3/18/2022 td   
        ''
        Dim objListData As New List(Of String)

        ''For Each each_textbox In objListOfTextboxes_Ordered
        For Each each_textbox In ListOfTextboxes_TopToBottom()

            objListData.Add(each_textbox.Text)

        Next each_textbox

        ''
        ''ExitHandler
        ''
        Return objListData

    End Function ''end of Private Function ListOfData() As List(Of String)


    Public Function ListOfTextboxes_TopToBottom() As IOrderedEnumerable(Of TextBox)
        ''
        ''Added 3/19/2022 td
        ''
        Dim objListOfTextboxes As New List(Of TextBox)
        ''Dim objListOfTextboxes_Ordered ''As New IOrderedEnumerable(Of(Of TextBox)

        For Each eachCtl As Control In Me.Controls
            If (TypeOf eachCtl Is TextBox) Then
                If (eachCtl.Visible) Then
                    objListOfTextboxes.Add(CType(eachCtl, TextBox))
                End If
            End If ''End of "If (TypeOf eachCtl Is TextBox) Then"
        Next eachCtl ''End of ""For Each eachCtl As Control In Me.Controls""

        ''
        ''Order them in order of top-down (i.e. the Top property).
        ''
        Dim objListOfTextboxes_Ordered As IOrderedEnumerable(Of TextBox) =
            From objTextbox In objListOfTextboxes
            Select objTextbox
            Order By objTextbox.Top

        Return objListOfTextboxes_Ordered

    End Function ''End of "Private Function ListOfTextboxes_TopToBottom() As IOrderedEnumerable(Of TextBox)"


    Public Function ListOfBars_TopToBottom() As IOrderedEnumerable(Of PictureBox)
        ''
        ''Added 3/19/2022 td
        ''
        Dim objListOfBars As New List(Of PictureBox)
        For Each eachCtl As Control In Me.Controls
            If (TypeOf eachCtl Is PictureBox) Then
                If (eachCtl.Visible) Then
                    objListOfBars.Add(CType(eachCtl, PictureBox))
                End If ''End of ""If (eachCtl.Visible) Then""
            End If ''End of "If (TypeOf eachCtl Is TextBox) Then"
        Next eachCtl ''End of ""For Each eachCtl As Control In Me.Controls""

        ''
        ''Order them in order of top-down (i.e. the Top property).
        ''
        Dim objListOfBars_Ordered As IOrderedEnumerable(Of PictureBox) =
            From objBar In objListOfBars
            Select objBar
            Order By objBar.Top

        Return objListOfBars_Ordered

    End Function ''End of "Public Function ListOfBars_TopToBottom() As IOrderedEnumerable(Of PictureBox)"


    Public Sub SaveDataToColumn()
        ''
        ''Added 3/18/2022 t1h1o1m1a1s1 d1o1w1n1e1s1
        ''
        Dim objFieldColumnControl As RSCFieldColumn

        objFieldColumnControl = Me
        ''March18 2022''With Me.ColumnWidthAndData
        With mod_columnWidthAndData

            .CIBField = RscSelectCIBField1.SelectedValue
            .Width = Me.Width
            .ColumnData = Me.ListOfData()
            .Rows = Me.ListOfData().Count

        End With ''End of "With Me.ColumnWidthAndData"

    End Sub ''End of Public Sub SaveDataToColumn()


    ''Private Sub textboxExample1_TextChanged(sender As Object, e As EventArgs) Handles textboxExample1.TextChanged

    ''End Sub

    ''Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click

    ''End Sub

    ''Private Sub PictureBox12_Click(sender As Object, e As EventArgs) Handles PictureBox12.Click

    ''End Sub

    ''Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    ''End Sub

    ''Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs) Handles TextBox11.TextChanged

    ''End Sub

    ''Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs) Handles TextBox10.TextChanged

    ''End Sub

    ''Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click

    ''End Sub

    ''Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click

    ''End Sub

    ''Private Sub PictureBox11_Click(sender As Object, e As EventArgs) Handles PictureBox11.Click

    ''End Sub

    ''Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    ''End Sub

    ''Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    ''End Sub

    ''Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged

    ''End Sub

    ''Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged

    ''End Sub

    ''Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    ''End Sub

    ''Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click

    ''End Sub

    ''Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click

    ''End Sub

    ''Private Sub PictureBox10_Click(sender As Object, e As EventArgs) Handles PictureBox10.Click

    ''End Sub

    ''Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    ''End Sub

    ''Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    ''End Sub

    ''Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged

    ''End Sub

    ''Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged

    ''End Sub

    ''Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    ''End Sub

    ''Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click

    ''End Sub

    ''Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click

    ''End Sub

    Private Sub TextBox_TextChanged(sender As Object, e As EventArgs) ''Handles TextBox2.TextChanged
        ''
        ''Added 3/19/2022 Thomas Downes  
        ''
        Dim objTextbox As TextBox = CType(sender, TextBox)
        objTextbox.ForeColor = Color.Black


    End Sub

    Private Sub RSCFieldColumn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 3/13/2022 thomas d.
        ''
        ''3/13/2022 td''Me.BackColor = Color.AntiqueWhite


    End Sub

    Private Sub RSCFieldColumn_MouseDown(par_sender As Object, par_e As MouseEventArgs) Handles MyBase.MouseDown

        ''Added 3/11/2022 thomad downes
        If mod_bHandleMouseMoveEvents_ByVB6 Then
            If mod_bHandleMouseMoveEvents_ChildClass Then
                ''----Nasty bug.  Don't use par_sender here. ---1/11/2022 td''
                ''--MyBase.MoveableControl_MouseDown(par_sender, par_e)
                Dim objParentControl As Control = Me ''Added 1/11/2022
                MyBase.MoveableControl_MouseDown(objParentControl, par_e)
            End If
        End If

    End Sub

    Private Sub RSCFieldColumn_MouseMove(par_sender As Object, par_e As MouseEventArgs) Handles MyBase.MouseMove

        ''Added 3/11/2022 thomas downes
        If mod_bHandleMouseMoveEvents_ByVB6 Then
            If mod_bHandleMouseMoveEvents_ChildClass Then
                ''----Nasty bug.  Don't use par_sender here. ---1/11/2022 td''
                ''--MyBase.MoveableControl_MouseMove(par_sender, par_e)
                Dim objParentControl As Control = Me ''Added 1/11/2022
                MyBase.MoveableControl_MouseMove(objParentControl, par_e)
            End If
        End If

    End Sub

    Private Sub RSCFieldColumn_MouseUp(par_sender As Object, par_e As MouseEventArgs) Handles MyBase.MouseUp

        ''Added 3/11/2022 thomas downes
        If mod_bHandleMouseMoveEvents_ByVB6 Then
            If mod_bHandleMouseMoveEvents_ChildClass Then
                ''----Nasty bug.  Don't use par_sender here. ---1/11/2022 td''
                ''--MyBase.MoveableControl_MouseUp(par_sender, par_e)
                Dim objParentControl As Control = Me ''Added 1/11/2022
                MyBase.MoveableControl_MouseUp(objParentControl, par_e)
            End If
        End If

    End Sub

    Private Sub LinkLabelRightClick_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelRightClick.LinkClicked
        ''
        ''Added 3/20/2022 td
        ''
        Dim new_mouse As MouseEventArgs
        new_mouse = New MouseEventArgs(MouseButtons.Right, 1, LinkLabelRightClick.Left,
               LinkLabelRightClick.Top, 0)
        MyBase.MoveableControl_MouseUp(sender, new_mouse)


    End Sub


    Private Sub LabelHeader1_Click(sender As Object, e As EventArgs) Handles LabelHeader1.Click
        ''
        ''Added 3/20/2022 td
        ''
        Dim new_mouse As MouseEventArgs
        new_mouse = New MouseEventArgs(MouseButtons.Right, 1, LinkLabelRightClick.Left,
               LinkLabelRightClick.Top, 0)
        MyBase.MoveableControl_MouseUp(sender, new_mouse)

    End Sub

    Private Sub RscSelectCIBField1_Load(sender As Object, e As EventArgs) Handles RscSelectCIBField1.Load

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub
End Class
