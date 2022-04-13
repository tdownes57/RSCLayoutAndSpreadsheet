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

Public Class RSCFieldColumnV1
    ''
    ''Added 2/21/2022 thomas downes  
    ''
    Public ElementsCache_Deprecated As ciBadgeCachePersonality.ClassElementsCache_Deprecated ''Added 3/10/2022 td
    Public ColumnDataCache As CacheRSCFieldColumnWidthsEtc ''Added 3/15/2022 td
    Public ListRecipients As IEnumerable(Of ClassRecipient) ''Added 3/22/2022 td

    Private mod_listOfColumnsToBumpRight As List(Of RSCFieldColumnV1)
    ''4/13/2022 Private mod_columnWidthAndData As ClassColumnWidthAndData ''Added 3/18/2022  
    Private mod_columnWidthAndData As ClassRSCColumnWidthAndData ''Renamed class 4/13/2022  
    Private mod_arrayOfData_Undo As String() ''Added 3/20/2022 thomas d.
    Private mod_arrayOfData_Undo_Tag As String() ''Added 4/01/2022 thomas d.

    ''Added 4/04/2022 thomas downes
    Private mod_listTextboxesByRow As New Dictionary(Of Integer, TextBox)

    ''Added 4/04/2022 thomas downes
    ''Private Structure StructTextboxAndRowSeparator
    ''    Public Cellbox As TextBox
    ''    Public BottomBar As PictureBox
    ''End Structure
    Private mod_listTextAndBarByRow As New Dictionary(Of Integer, StructTextboxAndRowSeparator)

    Private Const mod_c_intPixelsFromRowToRow As Integer = 24 ''Added 4/04/2022 td
    Private mod_intPixelsFromRowToRow As Integer = 0 ''Added 4/04/2022 td


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
        ''---Public Property ColumnWidthAndData() As ClassColumnWidthAndData_NotInUse ''Added 3/15/2022 td
        ''Added 3/18/2022 thomas 
        Get
            ''Added 3/18/2022 thomas
            ''  Probably only for testing!!
            Return mod_columnWidthAndData
        End Get
        Set(value As ClassRSCColumnWidthAndData)
            ''----4/2022--Set(value As ClassColumnWidthAndData_NotInUse)
            ''Added 3/18/2022 thomas 
            mod_columnWidthAndData = value
        End Set
    End Property


    Public Property ListOfColumnsToBumpRight As List(Of RSCFieldColumnV1) ''Added 3/12/2022 td 
        Get
            Return mod_listOfColumnsToBumpRight
        End Get
        Set(value As List(Of RSCFieldColumnV1))
            ''
            ''Important, set the local list of columns to match the list which
            ''    is part of the composition of MyBase.mod_iMoveOrResizeFunctionality 
            ''    ---04/1/2022 thomas d. 
            ''
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
                                     par_intColumnIndex As Integer) As RSCFieldColumnV1
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
                                     par_intColumnIndex As Integer) As RSCFieldColumnV1
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
        Dim CtlFieldColumn1 = New RSCFieldColumnV1(par_field, par_formParent,
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

        ''
        ''Added 4/4/2022 thomas downes
        ''
        With mod_listTextAndBarByRow

            ''
            '' 1, 2, 3
            ''
            mod_listTextboxesByRow.Add(1, Textbox1a)
            Dim struct1 As New StructTextboxAndRowSeparator()
            struct1.Cellbox = Textbox1a
            struct1.BottomBar = PictureBox1
            .Add(1, struct1)

            mod_listTextboxesByRow.Add(2, TextBox2a)
            Dim struct2 As New StructTextboxAndRowSeparator()
            struct2.Cellbox = TextBox2a
            struct2.BottomBar = PictureBox2
            .Add(2, struct2)

            mod_listTextboxesByRow.Add(3, TextBox3a)
            Dim struct3 As New StructTextboxAndRowSeparator()
            struct3.Cellbox = TextBox3a
            struct3.BottomBar = PictureBox3
            .Add(3, struct3)

            ''
            '' 4, 5, 6
            ''
            mod_listTextboxesByRow.Add(4, TextBox4a)
            Dim struct4 As New StructTextboxAndRowSeparator()
            struct4.Cellbox = TextBox4a
            struct4.BottomBar = PictureBox4
            .Add(4, struct4)

            mod_listTextboxesByRow.Add(5, TextBox5a)
            Dim struct5 As New StructTextboxAndRowSeparator()
            struct5.Cellbox = TextBox5a
            struct5.BottomBar = PictureBox5
            .Add(5, struct5)

            mod_listTextboxesByRow.Add(6, TextBox6a)
            Dim struct6 As New StructTextboxAndRowSeparator()
            struct6.Cellbox = TextBox6a
            struct6.BottomBar = PictureBox6
            .Add(6, struct6)

            ''
            '' 7, 8, 9
            ''
            mod_listTextboxesByRow.Add(7, TextBox7a)
            Dim struct7 As New StructTextboxAndRowSeparator()
            struct7.Cellbox = TextBox7a
            struct7.BottomBar = PictureBox7
            .Add(7, struct7)

            mod_listTextboxesByRow.Add(8, TextBox8a)
            Dim struct8 As New StructTextboxAndRowSeparator()
            struct8.Cellbox = TextBox8a
            struct8.BottomBar = PictureBox8a
            .Add(8, struct8)

            mod_listTextboxesByRow.Add(9, TextBox9a)
            Dim struct9 As New StructTextboxAndRowSeparator()
            struct9.Cellbox = TextBox9a
            struct9.BottomBar = PictureBox9a
            .Add(9, struct9)

            ''
            '' 10, 11, 12
            ''
            mod_listTextboxesByRow.Add(10, TextBox10a)
            Dim struct10 As New StructTextboxAndRowSeparator()
            struct10.Cellbox = TextBox10a
            struct10.BottomBar = PictureBox10a
            .Add(10, struct10)

            mod_listTextboxesByRow.Add(11, TextBox11a)
            Dim struct11 As New StructTextboxAndRowSeparator()
            struct11.Cellbox = TextBox11a
            struct11.BottomBar = PictureBox11a
            .Add(11, struct11)

            mod_listTextboxesByRow.Add(12, TextBox12a)
            Dim struct12 As New StructTextboxAndRowSeparator()
            struct12.Cellbox = TextBox12a
            struct12.BottomBar = PictureBox12a
            .Add(12, struct12)

            ''
            '' 13, 14, 15
            ''
            mod_listTextboxesByRow.Add(13, TextBox13a)
            Dim struct13 As New StructTextboxAndRowSeparator()
            struct13.Cellbox = TextBox13a
            struct13.BottomBar = PictureBox13a
            .Add(13, struct13)

            mod_listTextboxesByRow.Add(14, TextBox14a)
            Dim struct14 As New StructTextboxAndRowSeparator()
            struct14.Cellbox = TextBox14a
            struct14.BottomBar = PictureBox14a
            .Add(14, struct14)

            mod_listTextboxesByRow.Add(15, TextBox15a)
            Dim struct15 As New StructTextboxAndRowSeparator()
            struct15.Cellbox = TextBox15a
            struct15.BottomBar = PictureBox15a
            .Add(15, struct15)

            ''
            '' 16, 17, 18
            ''
            mod_listTextboxesByRow.Add(16, TextBox16a)
            Dim struct16 As New StructTextboxAndRowSeparator()
            struct16.Cellbox = TextBox16a
            struct16.BottomBar = PictureBox16a
            .Add(16, struct16)

            mod_listTextboxesByRow.Add(17, TextBox17a)
            Dim struct17 As New StructTextboxAndRowSeparator()
            struct17.Cellbox = TextBox17a
            struct17.BottomBar = PictureBox17a
            .Add(17, struct17)

            mod_listTextboxesByRow.Add(18, TextBox18a)
            Dim struct18 As New StructTextboxAndRowSeparator()
            struct18.Cellbox = TextBox18a
            struct18.BottomBar = PictureBox18a
            .Add(18, struct18)

            ''
            '' 19
            ''
            ''mod_listTextboxesByRow.Add(19, TextBox19a)
            ''Dim struct19 As New TextboxAndRowSeparator()
            ''struct19.Cellbox = TextBox19a
            ''struct19.BottomBar = PictureBox19a
            ''.Add(19, struct19)

        End With ''End of "With mod_listTextAndBarByRow" 



    End Sub ''End of ""Public Sub New(par_field As .........)"


    Public Sub AddBumpColumn(par_columnToBump As RSCFieldColumnV1)
        ''
        ''Added 4/1/2022 thomas 
        ''
        If (mod_listOfColumnsToBumpRight Is Nothing) Then
            mod_listOfColumnsToBumpRight = New List(Of RSCFieldColumnV1)
        End If

        If (Not mod_listOfColumnsToBumpRight.Contains(par_columnToBump)) Then
            mod_listOfColumnsToBumpRight.Add(par_columnToBump)
        End If

        ''----If (Not mod_iMoveOrResizeFunctionality.ListOfColumnsToBumpRight.Contains(par_columnToBump)) Then
        mod_iMoveOrResizeFunctionality.AddColumnToBumpRight(par_columnToBump)
        ''---End If

    End Sub ''End of "Public Sub AddBumpColumn(par_columnToBump As RSCFieldColumn)"



    Public Sub Load_FieldsFromCache(par_cache As ClassElementsCache_Deprecated)
        ''
        ''Added 3/14/2022 td
        ''
        If (par_cache Is Nothing) Then Throw New ArgumentException("Exception Occured")

        RscSelectCIBField1.Loading = True ''Added 4/1/2022
        RscSelectCIBField1.ElementsCache_Deprecated = Me.ElementsCache_Deprecated
        RscSelectCIBField1.Load_FieldsFromCache(par_cache)

        ''
        ''Added 3/15/2022 td
        ''
        RscSelectCIBField1.SelectedValue = mod_columnWidthAndData.CIBField

        ''Added 4/1/2022 td
        Application.DoEvents()
        RscSelectCIBField1.Loading = False ''Added 4/1/2022 td

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
        ReDim mod_arrayOfData_Undo_Tag(-1 + listTextboxes.Count)

        For Each each_textbox In listTextboxes '' ListOfTextboxes_TopToBottom()

            ''Enable the Undo procedure.
            mod_arrayOfData_Undo(indexItem) = each_textbox.Text

            ''Added 4/1/2022 td
            If (each_textbox.Tag Is Nothing) Then each_textbox.Tag = "" ''Added 4/1/2022
            mod_arrayOfData_Undo_Tag(indexItem) = each_textbox.Tag.ToString() ''Added 4/1/2022td

            indexItem += 1

            ''Clear the textbox of data.  
            each_textbox.Text = ""
            each_textbox.Tag = "" ''Added 4/1/2022

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
                each_textbox.Tag = mod_arrayOfData_Undo_Tag(indexItem) ''Added 4/1/2022
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


    Public Function CountOfRows() As Integer
        ''
        ''Added 4/3/2022 thomas downes  
        ''
        Dim listBoxes As List(Of TextBox)
        Const c_boolSkipSorting As Boolean = True
        listBoxes = ListOfTextboxes_TopToBottom(c_boolSkipSorting)
        Return listBoxes.Count

    End Function ''End of ""Public Function CountOfRows() As Integer""


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


    Public Function CountOfBoxesWithData_Edited(Optional ByRef pref_countOfRows As Integer = 0) As Integer ''Added 3/20/2022
        ''
        ''Added 3/20/2022 t//d//
        ''
        Dim intCountData As Integer = 0
        Dim listTextboxes As IEnumerable(Of TextBox)

        listTextboxes = ListOfTextboxes_TopToBottom()
        pref_countOfRows = listTextboxes.Count ''Added 3/23/2022 td

        For Each each_textbox In listTextboxes '' ListOfTextboxes_TopToBottom()

            ''If (Not String.IsNullOrEmpty(each_textbox.Text)) Then intCountData += 1
            If (each_textbox.Text <> CStr(each_textbox.Tag)) Then intCountData += 1

        Next each_textbox

        Return intCountData

    End Function ''End of "Private Sub LoadDataToColumn_Do()"


    Public Function GetFirstTextbox() As TextBox
        ''
        ''Added 4/04/2022 thomas downes
        ''
        Dim objFirstTextbox As TextBox
        objFirstTextbox = ListOfTextboxes_TopToBottom().First()
        Return objFirstTextbox

    End Function ''End of ""Public Function GetFirstTextbox() As TextBox""


    Public Function GetFirstTextboxPropertyTop() As Integer
        ''
        ''Added 3/24/2022 thomas downes
        ''
        Dim objFirstTextbox As TextBox
        objFirstTextbox = ListOfTextboxes_TopToBottom().First()
        Return objFirstTextbox.Top

    End Function ''end of ""Public Function GetFirstTextboxPropertyTop() As Integer""


    Public Function GetTextboxAtBottom_Bottom() As Integer
        ''
        ''Added 4/4//2022 thomas downes 
        ''
        Dim objBottomTextbox As TextBox
        objBottomTextbox = ListOfTextboxes_TopToBottom().Last
        Return objBottomTextbox.Top + objBottomTextbox.Height

    End Function ''End of ""Public Function GetTextboxAtBottom_Bottom()""


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
                                 Optional ByRef pref_bNoFieldSelected As Boolean = False,
                                 Optional ByRef pref_bNoRecipientList As Boolean = False,
                                 Optional ByRef pref_boolRows_TooFew As Boolean = False,
                                 Optional ByRef pref_boolRows_TooMany As Boolean = False)
        ''
        ''Added 3/22/2022 td
        ''
        Dim intCountAllBoxesOrRows As Integer ''Added 3/23/2022 td
        Dim intCountBoxesEmptyOrNot As Integer ''Addexd 3/23/2022 td

        Dim intCountCellsWithData_Edited As Integer
        ''March23 2022''intCountCellsWithData = CountOfBoxesWithData()
        ''April 01 2023''intCountCellsWithData = CountOfBoxesWithData(intCountBoxesEmptyOrNot)
        intCountCellsWithData_Edited = CountOfBoxesWithData_Edited(intCountBoxesEmptyOrNot)
        If (intCountCellsWithData_Edited <> 0) Then
            pboolErrorCellsHaveValues = True
            Throw New Exception("Warning, non-zero >0 cells with data edited already. Edits would be lost.")
        End If ''End of ""If (intCountCellsWithData_Edited <> 0) Then""

        Dim enumFieldSelected As EnumCIBFields
        enumFieldSelected = RscSelectCIBField1.SelectedValue
        If (enumFieldSelected = EnumCIBFields.Undetermined) Then
            pref_bNoFieldSelected = True
            MessageBoxTD.Show_Statement("Warning, not all columns have a specified field.")
            Return
        End If ''End of ""If (enumFieldSelected = EnumCIBFields.Undetermined) Then""

        Dim boolNoRecipList As Boolean
        boolNoRecipList = (Me.ListRecipients Is Nothing)
        pref_bNoRecipientList = boolNoRecipList
        If (pref_bNoRecipientList) Then
            Throw New Exception("ListRecipients is a Null reference.")
            Return
        End If ''End of ""If (pref_bNoRecipientList) Then""

        Dim intCountRecipients As Integer
        intCountRecipients = Me.ListRecipients.Count

        Dim boolNoRecipients_zero As Boolean
        boolNoRecipients_zero = (0 = intCountRecipients)
        If (boolNoRecipients_zero) Then
            pref_bNoRecipientList = True
            Throw New Exception("ListRecipients has Zero(0) recipient (student) rows.")
            Return
        End If ''ENd of ""If (boo lNoRecipients_zero) Then""

        ''
        ''Added 3/29/2022 thomas downes
        ''
        Load_EmptyRows(intCountRecipients)

        CountOfBoxesWithData(intCountBoxesEmptyOrNot) ''Update the value of var. intCountBoxesEmptyOrNot.

        ''3/29/2022 thomas d.''Dim boolMismatchOfCounts As Boolean
        Dim boolMismatchOfCounts_Less As Boolean
        Dim boolMismatchOfCounts_More As Boolean

        intCountAllBoxesOrRows = intCountBoxesEmptyOrNot
        ''March29 2022''boolMismatchOfCounts_Less = (intCountAllBoxesOrRows <> Me.ListRecipients.Count) ''Then
        boolMismatchOfCounts_Less = (intCountAllBoxesOrRows < Me.ListRecipients.Count) ''Then
        boolMismatchOfCounts_More = (intCountAllBoxesOrRows > Me.ListRecipients.Count) ''Then

        If (boolMismatchOfCounts_Less) Then
            ''3/29/2022 td''pboolErrorCellsHaveValues = True
            pref_boolRows_TooFew = True
            ''---Throw New Exception("Warning, non-zero >0 cells with data already. Data would be lost.")
            Throw New Exception("Warning, we have less textboxes than required. Data would be lost.")

        ElseIf (boolMismatchOfCounts_More) Then
            ''3/29/2022 td''pboolErrorCellsHaveValues = True
            pref_boolRows_TooMany = True
            ''---Throw New Exception("Warning, non-zero >0 cells with data already. Data would be lost.")
            Throw New Exception("Warning, we have more textboxes than required. Rows will be left blank.")
        End If ''End of ""If (boolMismatchOfCounts) then""

        ''-----------------------------------------------------------

        ''March25 2022 td''Dim listBoxes As IOrderedEnumerable(Of TextBox)
        Dim listBoxes As List(Of TextBox)
        Dim intRowIndex As Integer = -1
        listBoxes = ListOfTextboxes_TopToBottom()

        For Each each_box As TextBox In listBoxes

            intRowIndex += 1

            each_box.Text = Me.ListRecipients(intRowIndex).GetTextValue(enumFieldSelected)

            each_box.Tag = each_box.Text ''added 4/1/2022

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


    Public Function ListOfTextboxes_TopToBottom(Optional par_bSkipSorting As Boolean = False) As List(Of TextBox) ''IOrderedEnumerable(Of TextBox)
        ''
        ''Added 3/19/2022 td
        ''
        Dim objListOfTextboxes As New List(Of TextBox)
        ''Dim objListOfTextboxes_Ordered ''As New IOrderedEnumerable(Of(Of TextBox)

        ''Added 3/25/2022 thomas d.
        If (Me.Controls.Count = 0) Then
            Throw New Exception("WTF")
        End If

        For Each eachCtl As Control In Me.Controls
            If (TypeOf eachCtl Is TextBox) Then
                ''Strangely, .Visible is False????---3/25/2022 td''If (eachCtl.Visible) Then
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

        ''objListOfTextboxes.Sort(Function(elementA As TextBox, elementB As TextBox)
        ''                            Return elementA.Length.CompareTo(elementB.Length)
        ''                        End Function)

        ''Added 4/2/2022 td
        If (par_bSkipSorting) Then Return objListOfTextboxes

        Dim objListOfTextboxes_Ordered As List(Of TextBox)
        objListOfTextboxes_Ordered = objListOfTextboxes.OrderBy(Of Integer)(Function(a) a.Top).ToList()

        Return objListOfTextboxes_Ordered

    End Function ''End of "Private Function ListOfTextboxes_TopToBottom() As IOrderedEnumerable(Of TextBox)"


    Public Function ListOfBottomBars_TopToBottom() As List(Of PictureBox) ''IOrderedEnumerable(Of PictureBox)
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
                ''Strangely, .Visible is False????----3/25/2022 td''If (eachCtl.Visible) Then
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

        Dim objListOfTextboxes_Ordered As List(Of PictureBox)
        objListOfTextboxes_Ordered = objListOfBars.OrderBy(Of Integer)(Function(a) a.Top).ToList()
        Return objListOfTextboxes_Ordered

    End Function ''End of "Public Function ListOfBottomBars_TopToBottom() As IOrderedEnumerable(Of PictureBox)"


    Public Sub SaveDataToColumn()
        ''
        ''Added 3/18/2022 t1h1o1m1a1s1 d1o1w1n1e1s1
        ''
        Dim objFieldColumnControl As RSCFieldColumnV1

        objFieldColumnControl = Me
        ''March18 2022''With Me.ColumnWidthAndData
        With mod_columnWidthAndData

            .CIBField = RscSelectCIBField1.SelectedValue
            .Width = Me.Width
            .ColumnData = Me.ListOfData()
            .Rows = Me.ListOfData().Count

        End With ''End of "With Me.ColumnWidthAndData"

    End Sub ''End of Public Sub SaveDataToColumn()


    ''    RscFieldSpreadsheet1.RscFieldColumn1.AlignBottomBars_EvenlySpaced()
    ''            RscFieldSpreadsheet1.RscFieldColumn1.AlignTextboxes_ToBottomBars()
    Public Sub AlignBottomBars_EvenlySpaced()
        ''
        ''Added 3/26/2022
        ''


    End Sub ''Endof ""Public Sub AlignBottomBars_EvenlySpaced()""


    Public Sub AlignTextboxes_ToBottomBars()
        ''
        ''Added 3/26/2022
        ''


    End Sub ''Endof ""Public Sub AlignTextboxes_ToBottomBars()""


    Public Sub Load_OneEmptyRow_IfNeeded(par_intRowIndex As Integer,
                                         Optional pboolForceReposition As Boolean = False)
        ''
        ''Added 4/4/2022 td
        ''
        Dim bRowIndexLocated As Boolean

        With mod_listTextboxesByRow
            bRowIndexLocated = (.ContainsKey(par_intRowIndex))
        End With

        If (pboolForceReposition) Then
            ''
            ''Don't exit. 
            ''
        ElseIf (bRowIndexLocated) Then

            Exit Sub

        End If ''End of "If (pboolForceReposition) Then ... ElseIf....."

        ''
        ''Create the textbox and Bottom Bar. 
        ''

        ''
        ''Create the required textbox. 
        ''
        Dim objTextbox As TextBox ''4/4/2022 td''New TextBox ''Added 3/29/2022 thomas downes
        Dim objBottomBar As PictureBox ''Added 4/5/2022 thomas downes

        If (bRowIndexLocated) Then
            objTextbox = mod_listTextboxesByRow.Item(par_intRowIndex)
            objBottomBar = mod_listTextAndBarByRow.Item(par_intRowIndex).BottomBar
        Else
            ''4/4/2022 td''Dim objTextbox As New TextBox ''Added 3/29/2022 thomas downes
            objTextbox = New TextBox ''Added 3/29/2022 thomas downes
            mod_listTextboxesByRow.Add(par_intRowIndex, objTextbox)
            objBottomBar = GetBottomBarForRow()
            Dim new_struct As New StructTextboxAndRowSeparator
            new_struct.BottomBar = objBottomBar
            new_struct.Cellbox = objTextbox
            mod_listTextAndBarByRow.Item(par_intRowIndex) = new_struct

        End If ''End of ""If (bRowIndexLocated) Then... Else..."

        Dim textbox_Top As TextBox
        textbox_Top = Me.GetFirstTextbox()
        With objTextbox
            .Left = textbox_Top.Left
            .Width = textbox_Top.Width
            .Height = textbox_Top.Height
            .Anchor = textbox_Top.Anchor
            .BackColor = textbox_Top.BackColor
            .ForeColor = textbox_Top.ForeColor
            .BorderStyle = textbox_Top.BorderStyle
            .Font = textbox_Top.Font
            ''---.Top = (textbox_BottomLast.Top + intTopGap)
            ''April 5, 2022 td''.Top = (textbox_Top.Top + mc_intPixelsFromRowToRow * (par_intRowIndex - 1))
            .Top = (textbox_Top.Top + (Me.PixelsFromRowToRow * (par_intRowIndex - 1)))
            .Visible = True

            ''Bottom  row-related horizontal line (below each textbox).
            objBottomBar.Top = .Top + .Height + 1

        End With ''End of ""With objTextbox""

        ''Added 3/30/2022
        If (bRowIndexLocated) Then
            ''Textbox is already one of the controls on the form. ---4/4/2022
        Else
            Me.Controls.Add(objTextbox)
            Me.Controls.Add(objBottomBar)
        End If ''End of ""If (bRowIndexLocated) Then... Else ..."

        Dim textbox_BottomLast As TextBox
        ''Me.Height = (objTextbox.Top + objTextbox.Height + intTopGap)

        Dim listOfBoxes As List(Of TextBox)
        listOfBoxes = ListOfTextboxes_TopToBottom()
        textbox_BottomLast = listOfBoxes(-1 + listOfBoxes.Count) ''.LastOrDefault
        Me.Height = (textbox_BottomLast.Top + textbox_BottomLast.Height +
                    Me.PixelsFromRowToRow) ''----mc_intPixelsFromRowToRow)

    End Sub ''End of ""Public Sub Load_EmptyRow_IfNeeded(par(intRowIndex As Integer)""


    Public Function GetBottomBarForRow() As PictureBox
        ''
        ''Added 4/04/2022 td
        ''
        Dim objNewPicturebox As New PictureBox ''Added 3/29/2022 thomas downes
        Dim objTopBottomBar As PictureBox

        objTopBottomBar = mod_listTextAndBarByRow(1).BottomBar

        With objNewPicturebox
            .Left = objTopBottomBar.Left
            .Width = objTopBottomBar.Width
            .Height = objTopBottomBar.Height
            .Anchor = objTopBottomBar.Anchor
            .BackColor = objTopBottomBar.BackColor
            .ForeColor = objTopBottomBar.ForeColor
            .BorderStyle = objTopBottomBar.BorderStyle
            .Font = objTopBottomBar.Font
            ''---.Top = (textbox_BottomLast.Top + intTopGap)
            .Visible = True
        End With ''End of ""With objTextbox""

        Return objNewPicturebox ''Oops!! Forgot this. ---4/05/2022 td

    End Function ''End of ""Public Function GetBottomBarForRow()""


    Public Sub Load_EmptyRows(par_intRowsRequired As Integer)
        ''
        ''Added 3/29/2022 thomas downes
        ''
        Dim ref_intCountRows As Integer = 0
        Dim intCountRows As Integer = 0

        CountOfBoxesWithData(ref_intCountRows)
        intCountRows = ref_intCountRows

        Const c_bUseFirstTry As Boolean = False

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

        End If ''End of "If (c_bUseFirstTry) Then... Else...."


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
            End With ''End of ""With objTextbox""

            ''Added 3/30/2022
            Me.Controls.Add(objTextbox)
            Me.Height = (objTextbox.Top + objTextbox.Height + intTopGap)

        Next intRowIndex

    End Sub ''End of ""Public Sub Load_EmptyRows_CreateRows()""



    Public Function ToString_ByRow(par_intRowIndex As Integer,
                                   Optional pboolRefresh As Boolean = False) As String
        ''
        ''Added 4/03/2022
        ''
        Dim strValue As String
        Static listTextboxes As List(Of TextBox)

        If (pboolRefresh Or listTextboxes Is Nothing) Then
            listTextboxes = ListOfTextboxes_TopToBottom()
        End If

        strValue = listTextboxes(par_intRowIndex).Text
        Return strValue

    End Function ''End of ""Public Function ToString_ByRow(par_intRowIndex As Integer) As String""


    Private Sub Load_EmptyRows_DeleteRows(par_intRowsToCreate As Integer)
        ''
        ''Added 3/29/2022 thomas downes
        ''





    End Sub ''End of ""Public Sub Load_EmptyRows_DeleteRows()""



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

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox2a.TextChanged

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox4a.TextChanged

    End Sub


    Private Sub RscSelectCIBField1_MouseUp(sender As Object, e As MouseEventArgs) Handles RscSelectCIBField1.MouseUp

        ''Added 4/1/2022 td
        If (e.Button = MouseButtons.Right) Then

            ''Added 4/1/2022 td
            LinkLabelRightClick_LinkClicked(LinkLabelRightClick,
                   New LinkLabelLinkClickedEventArgs(New LinkLabel.Link()))

        End If

    End Sub

    Private Sub RscSelectCIBField1_RSCMouseUp(sender As Object, par_argsEvent As MouseEventArgs) Handles RscSelectCIBField1.RSCMouseUp

        ''Added 4/1/2022 td
        If (par_argsEvent.Button = MouseButtons.Right) Then

            MyBase.MoveableControl_MouseUp(Me, par_argsEvent)

        End If ''End of "If (par_argsEvent.Button = MouseButtons.Right) Then"

    End Sub

    Private Sub RscSelectCIBField1_RSCFieldChanged(newCIBField As EnumCIBFields) Handles RscSelectCIBField1.RSCFieldChanged

        ''Added 4/1/2022 td
        LoadRecipientList() ''_NoChecks(newCIBField)

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox6a.TextChanged

    End Sub
End Class
