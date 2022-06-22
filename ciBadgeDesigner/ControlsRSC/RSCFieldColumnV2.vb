''
''Added 4/8/2022 thomas downes
''
Option Explicit On
Option Strict On
''
''Added 2/21/2022 thomas downes
''
Imports ciBadgeInterfaces ''Added 8/14/2019 thomas d. 
''Imports ciBadgeElements ''Added 9/18/2019 td 
''Imports ciBadgeDesigner ''Added 3/8/2022 td  
Imports System.Drawing ''Added 10/01/2019 td 
Imports __RSCWindowsControlLibrary ''Added 1/4/2022 td
Imports ciBadgeFields ''Added 3/8/2022 thomas downes
Imports ciBadgeCachePersonality ''Added 3/14/2022 
Imports ciBadgeRecipients ''Added 3/22/2022 td

Public Class RSCFieldColumnV2
    ''
    ''Added 4/8/2022 and 2/21/2022 thomas downes  
    ''
    Public Shared MsgOnce_UnspecifiedField As Boolean = False ''Added 4/13/2022

    Public ElementsCache_Deprecated As ciBadgeCachePersonality.ClassElementsCache_Deprecated ''Added 3/10/2022 td
    Public ColumnDataCache As CacheRSCFieldColumnWidthsEtc ''Added 3/15/2022 td
    ''Added 5/01/2022 td''Public ListRecipients As IEnumerable(Of ClassRecipient) ''Added 3/22/2022 td
    Public ListRecipients As List(Of ClassRecipient) ''Added 3/22/2022 td
    Public ParentSpreadsheet As RSCFieldSpreadsheet ''Added 4/11/2022 td
    Public FocusRelated_UserHasSelectedColumn As Boolean ''Added 5/13/2022 td  

    Public Shared BackColor_NoEmphasis As Drawing.Color = Drawing.Color.Plum ''.Magenta ''Aded 5/13/2022
    Public Shared BackColor_WithEmphasis As Drawing.Color = Drawing.Color.Cyan ''Aded 5/13/2022

    Private mod_listOfColumnsToBumpRight As List(Of RSCFieldColumnV2)
    ''April 13 2022 ''Private mod_columnWidthAndData As ClassColumnWidthAndData_NotInUse ''Added 3/18/2022  
    Private mod_columnWidthAndData As ClassRSCColumnWidthAndData ''Added 3/18/2022  
    Private mod_arrayOfData_Undo As String() ''Added 3/20/2022 thomas d.
    Private mod_arrayOfData_Undo_Tag As String() ''Added 4/01/2022 thomas d.

    ''Added 4/04/2022 thomas downes
    Private mod_listRSCDataCellsByRow As New Dictionary(Of Integer, RSCDataCell) ''4/8/2022 RSCDataCell)
    Private mod_listDeletedRSCDataCells As List(Of RSCDataCell) ''Added 4/25/2022 thomas d.

    ''Added 4/04/2022 thomas downes
    ''Private Structure StructTextboxAndRowSeparator
    ''    Public Cellbox As RSCDataCell
    ''    Public BottomBar As PictureBox
    ''End Structure
    ''4/8/2022 Private mod_listTextAndBarByRow As New Dictionary(Of Integer, StructTextboxAndRowSeparator)

    Private Const mod_c_intPixelsFromRowToRow As Integer = 24 ''Added 4/04/2022 td
    Private mod_intPixelsFromRowToRow As Integer = 0 ''Added 4/04/2022 td
    Private mod_statistics As New StructRSCColumnStatistics ''Added 4/26/2022 td
    Private mod_intDisplayedColumnIndex As Integer = 0 ''Added 4/30/2022 td

    Private mod_emphasizeRows_TopY As Integer = -1 '' = intStartY
    Private mod_emphasizeRows_BottomY As Integer = -1 '' = intEnd__Y

    ''Added 4/29/2022 td
    ''---Private mod_colorCellsBackcolor_NoEmphasis As System.Drawing.Color = System.Drawing.Color.White
    ''---Private mod_colorCellsBackcolor_WithEmphasis As System.Drawing.Color = System.Drawing.Color.LightGray
    ''////Public Shared CellsBackcolor_NoEmphasis As System.Drawing.Color = System.Drawing.Color.White
    ''////Public Shared CellsBackcolor_WithEmphasis As System.Drawing.Color = System.Drawing.Color.LightGray

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
        ''---4/2022--Public Property ColumnWidthAndData() As ClassColumnWidthAndData ''Added 3/15/2022 td
        ''Added 3/18/2022 thomas 
        Get
            ''Added 3/18/2022 thomas
            ''  Probably only for testing!!
            Return mod_columnWidthAndData
        End Get
        Set(value As ClassRSCColumnWidthAndData) ''---As ClassColumnWidthAndData)
            ''Added 3/18/2022 thomas 
            mod_columnWidthAndData = value
        End Set
    End Property


    Public Property ListOfColumnsToBumpRight As List(Of RSCFieldColumnV2) ''Added 3/12/2022 td 
        Get
            Return mod_listOfColumnsToBumpRight
        End Get
        Set(value As List(Of RSCFieldColumnV2))
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
                                     par_intColumnIndex As Integer) As RSCFieldColumnV2
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
                                     par_intColumnIndex As Integer) As RSCFieldColumnV2
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
        Dim CtlFieldColumn1 = New RSCFieldColumnV2(par_field,
                                                   par_parametersGetElementControl,
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
            .FieldColumn = CtlFieldColumn1 ''Added 4/15/2022 td

        End With ''End of "With objOperationsPortrait"

        ''Added 3/13/2022 thomas downes
        CtlFieldColumn1.Load_ResizeWidthability()

        ''Added 4/26/2022 thomas downes
        CtlFieldColumn1.DisplayColumnIndex(par_intColumnIndex)

        Return CtlFieldColumn1

    End Function ''end of "Public Shared Function GetRSCFieldColumn() As RSCFieldColumn"


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

    End Sub


    Public Sub New(par_field As ciBadgeFields.ClassFieldAny,
                   par_parameters As IGetElementControlParameters,
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
        MyBase.New(EnumElementType.Portrait,
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

        ''Encapsulated 12/30/2021 td
        New_RSCFieldColumn(par_field, par_iLayoutFun)

        ''
        ''Added 4/8/2022 & 4/4/2022 thomas downes
        ''
        mod_listRSCDataCellsByRow.Add(1, RscDataCell1)
        mod_listRSCDataCellsByRow.Add(2, RscDataCell2)
        mod_listRSCDataCellsByRow.Add(3, RscDataCell3)
        mod_listRSCDataCellsByRow.Add(4, RscDataCell4)
        mod_listRSCDataCellsByRow.Add(5, RscDataCell5)
        mod_listRSCDataCellsByRow.Add(6, RscDataCell6)
        mod_listRSCDataCellsByRow.Add(7, RscDataCell7)
        mod_listRSCDataCellsByRow.Add(8, RscDataCell8)
        mod_listRSCDataCellsByRow.Add(9, RscDataCell9)
        mod_listRSCDataCellsByRow.Add(10, RscDataCell10)
        mod_listRSCDataCellsByRow.Add(11, RscDataCell11)
        mod_listRSCDataCellsByRow.Add(12, RscDataCell12)
        mod_listRSCDataCellsByRow.Add(13, RscDataCell13)
        mod_listRSCDataCellsByRow.Add(14, RscDataCell14)
        mod_listRSCDataCellsByRow.Add(15, RscDataCell15)
        mod_listRSCDataCellsByRow.Add(16, RscDataCell16)
        mod_listRSCDataCellsByRow.Add(17, RscDataCell17)
        mod_listRSCDataCellsByRow.Add(18, RscDataCell18)
        ''---mod_listRSCDataCellsByRow.Add(19, RscDataCell19a)

        ''With mod_listTextAndBarByRow

        ''    ''
        ''    '' 1, 2, 3
        ''    ''
        ''    mod_listRSCDataCellesByRow.Add(1, RSCDataCell1a)
        ''    Dim struct1 As New StructTextboxAndRowSeparator()
        ''    struct1.Cellbox = RSCDataCell1a
        ''    struct1.BottomBar = PictureBox1
        ''    .Add(1, struct1)

        ''    mod_listRSCDataCellesByRow.Add(2, RSCDataCell2a)
        ''    Dim struct2 As New StructTextboxAndRowSeparator()
        ''    struct2.Cellbox = RSCDataCell2a
        ''    struct2.BottomBar = PictureBox2
        ''    .Add(2, struct2)

        ''    mod_listRSCDataCellesByRow.Add(3, RSCDataCell3a)
        ''    Dim struct3 As New StructTextboxAndRowSeparator()
        ''    struct3.Cellbox = RSCDataCell3a
        ''    struct3.BottomBar = PictureBox3
        ''    .Add(3, struct3)

        ''    ''
        ''    '' 4, 5, 6
        ''    ''
        ''    mod_listRSCDataCellesByRow.Add(4, RSCDataCell4a)
        ''    Dim struct4 As New StructTextboxAndRowSeparator()
        ''    struct4.Cellbox = RSCDataCell4a
        ''    struct4.BottomBar = PictureBox4
        ''    .Add(4, struct4)

        ''    mod_listRSCDataCellesByRow.Add(5, RSCDataCell5a)
        ''    Dim struct5 As New StructTextboxAndRowSeparator()
        ''    struct5.Cellbox = RSCDataCell5a
        ''    struct5.BottomBar = PictureBox5
        ''    .Add(5, struct5)

        ''    mod_listRSCDataCellesByRow.Add(6, RSCDataCell6a)
        ''    Dim struct6 As New StructTextboxAndRowSeparator()
        ''    struct6.Cellbox = RSCDataCell6a
        ''    struct6.BottomBar = PictureBox6
        ''    .Add(6, struct6)

        ''    ''
        ''    '' 7, 8, 9
        ''    ''
        ''    mod_listRSCDataCellesByRow.Add(7, RSCDataCell7a)
        ''    Dim struct7 As New StructTextboxAndRowSeparator()
        ''    struct7.Cellbox = RSCDataCell7a
        ''    struct7.BottomBar = PictureBox7
        ''    .Add(7, struct7)

        ''    mod_listRSCDataCellesByRow.Add(8, RSCDataCell8a)
        ''    Dim struct8 As New StructTextboxAndRowSeparator()
        ''    struct8.Cellbox = RSCDataCell8a
        ''    struct8.BottomBar = PictureBox8a
        ''    .Add(8, struct8)

        ''    mod_listRSCDataCellesByRow.Add(9, RSCDataCell9a)
        ''    Dim struct9 As New StructTextboxAndRowSeparator()
        ''    struct9.Cellbox = RSCDataCell9a
        ''    struct9.BottomBar = PictureBox9a
        ''    .Add(9, struct9)

        ''    ''
        ''    '' 10, 11, 12
        ''    ''
        ''    mod_listRSCDataCellesByRow.Add(10, RSCDataCell10a)
        ''    Dim struct10 As New StructTextboxAndRowSeparator()
        ''    struct10.Cellbox = RSCDataCell10a
        ''    struct10.BottomBar = PictureBox10a
        ''    .Add(10, struct10)

        ''    mod_listRSCDataCellesByRow.Add(11, RSCDataCell11a)
        ''    Dim struct11 As New StructTextboxAndRowSeparator()
        ''    struct11.Cellbox = RSCDataCell11a
        ''    struct11.BottomBar = PictureBox11a
        ''    .Add(11, struct11)

        ''    mod_listRSCDataCellesByRow.Add(12, RSCDataCell12a)
        ''    Dim struct12 As New StructTextboxAndRowSeparator()
        ''    struct12.Cellbox = RSCDataCell12a
        ''    struct12.BottomBar = PictureBox12a
        ''    .Add(12, struct12)

        ''    ''
        ''    '' 13, 14, 15
        ''    ''
        ''    mod_listRSCDataCellesByRow.Add(13, RSCDataCell13a)
        ''    Dim struct13 As New StructTextboxAndRowSeparator()
        ''    struct13.Cellbox = RSCDataCell13a
        ''    struct13.BottomBar = PictureBox13a
        ''    .Add(13, struct13)

        ''    mod_listRSCDataCellesByRow.Add(14, RSCDataCell14a)
        ''    Dim struct14 As New StructTextboxAndRowSeparator()
        ''    struct14.Cellbox = RSCDataCell14a
        ''    struct14.BottomBar = PictureBox14a
        ''    .Add(14, struct14)

        ''    mod_listRSCDataCellesByRow.Add(15, RSCDataCell15a)
        ''    Dim struct15 As New StructTextboxAndRowSeparator()
        ''    struct15.Cellbox = RSCDataCell15a
        ''    struct15.BottomBar = PictureBox15a
        ''    .Add(15, struct15)

        ''    ''
        ''    '' 16, 17, 18
        ''    ''
        ''    mod_listRSCDataCellesByRow.Add(16, RSCDataCell16a)
        ''    Dim struct16 As New StructTextboxAndRowSeparator()
        ''    struct16.Cellbox = RSCDataCell16a
        ''    struct16.BottomBar = PictureBox16a
        ''    .Add(16, struct16)

        ''    mod_listRSCDataCellesByRow.Add(17, RSCDataCell17a)
        ''    Dim struct17 As New StructTextboxAndRowSeparator()
        ''    struct17.Cellbox = RSCDataCell17a
        ''    struct17.BottomBar = PictureBox17a
        ''    .Add(17, struct17)

        ''    mod_listRSCDataCellesByRow.Add(18, RSCDataCell18a)
        ''    Dim struct18 As New StructTextboxAndRowSeparator()
        ''    struct18.Cellbox = RSCDataCell18a
        ''    struct18.BottomBar = PictureBox18a
        ''    .Add(18, struct18)

        ''    ''
        ''    '' 19
        ''    ''
        ''    ''mod_listRSCDataCellesByRow.Add(19, RSCDataCell19a)
        ''    ''Dim struct19 As New RSCDataCellAndRowSeparator()
        ''    ''struct19.Cellbox = RSCDataCell19a
        ''    ''struct19.BottomBar = PictureBox19a
        ''    ''.Add(19, struct19)

        ''End With ''End of "With mod_listTextAndBarByRow" 



    End Sub ''End of ""Public Sub New(par_field As .........)"


    Public Sub DisplayColumnIndex(par_intColumnIndex As Integer)
        ''
        ''Added 4/26/2022 thomas 
        ''
        mod_intDisplayedColumnIndex = par_intColumnIndex
        RscSelectCIBField1.DisplayColumnIndex(par_intColumnIndex)

    End Sub ''End of ""Public Sub DisplayColumnIndex(par_intColumnIndex As Integer)""


    Public Sub MoveTextCaretToNewRow(par_intNewRowIndex As Integer)
        ''
        ''Added 5/13/2022 thomas downes
        ''
        Dim objRSCDatacell As RSCDataCell
        objRSCDatacell = GetRSCDataCell_ByRowIndex(par_intNewRowIndex)
        objRSCDatacell.FocusRelated_SetFocus()

    End Sub ''End of ""Public Sub MoveTextCaretToNewRow()" 


    Public Function HasField_Selected() As Boolean
        '
        'Added 5/25/2022
        '
        Return RscSelectCIBField1.HasField_Selected()

    End Function ''End of ""Public Function HasField_Selected() As Boolean""


    Public Function HasIdentifyingData() As Boolean
        ''
        ''Added 5/14/2022 
        ''
        '' Let's check to see if there are five(5) unique values
        ''   among the top five(5) data cells. 
        ''
        Dim intRowIndex As Integer
        Dim hash_trackData As New Dictionary(Of String, Boolean)

        For intRowIndex = 1 To 5

            Dim objRSCDatacell As RSCDataCell
            objRSCDatacell = GetRSCDataCell_ByRowIndex(intRowIndex)
            Try
                hash_trackData.Add(objRSCDatacell.Text_CellValue, True)
            Catch ex As Exception
                Return False
            End Try
        Next intRowIndex

        Return True

    End Function ''End of ""Public Function HasIdentifyingData() As Boolean""



    Public Function GetIndexOfColumn() As Integer
        ''
        ''Added 4/30/2022 thomas
        ''
        Return mod_intDisplayedColumnIndex

    End Function ''End of ""Public Function GetIndexOfColumn() As Integer""


    Public Function FocusRelated_ColumnHasCellFocus(Optional pboolStrictVersion As Boolean = True) As Boolean
        ''---5/13/2022 Public Function HasFocus() 
        ''
        ''Added 5/13/2022 td
        ''
        Dim each_boolHasFocus As Boolean ''Added 4/30/2022 td
        ''boolHasFocus = Textbox1a.Focused
        Dim each_RSCDataCell As RSCDataCell
        Dim intForRowIndex As Integer
        Dim bWeFoundACellWithFocus As Boolean ''Added 5/13/2022 td

        ''
        ''Looping to check for focus. 
        ''
        ''5/13/2022 ''For Each each_RSCDataCell In ListOfRSCDataCells_TopToBottom()
        ''
        ''    ''5/13/2022 ''each_boolHasFocus = (each_RSCDataCell.HasFocus())
        ''    each_boolHasFocus = (each_RSCDataCell.FocusRelated_CellHasFocus())
        ''    If (each_boolHasFocus) Then Return True
        ''
        ''Next each_RSCDataCell

        For intForRowIndex = 1 To mod_listRSCDataCellsByRow.Count
            If (mod_listRSCDataCellsByRow.ContainsKey(intForRowIndex)) Then

                each_RSCDataCell = mod_listRSCDataCellsByRow(intForRowIndex)

                If (pboolStrictVersion) Then
                    each_boolHasFocus = (each_RSCDataCell.FocusRelated_TextboxHasFocus())
                Else
                    each_boolHasFocus = (each_RSCDataCell.FocusRelated_CellHasFocus())
                End If

                If (each_boolHasFocus) Then
                    ''Return True 
                    bWeFoundACellWithFocus = True
                    Exit For
                End If ''End of ""If (each_boolHasFocus) Then""

            Else
                ''The row has been deleted by the user. 
                ''---5/01/2022 thomas d. 
            End If ''End of ""If (mod_listRSCDataCellsByRow.ContainsKey(intRowIndex)) Then""
        Next intForRowIndex


        ''Added 5/13/2022 thomas downes
        ''5/13/2022 td''Return Me.FocusRelated_UserHasSelectedColumn
        If (pboolStrictVersion) Then
            ''We are strictly concerned with the TextBox having the TextCaret, 
            ''   which is 99% certain to be determined by the TextBox.HasFocus()
            ''   property.  ----5/13/2022 td
            Return bWeFoundACellWithFocus

        ElseIf (bWeFoundACellWithFocus) Then

            Return True ''---Return bWeFoundACellWithFocus

        Else
            ''
            ''We are not using strict mode, so we can check to see if the user has
            ''  somehow selected the column (maybe by clicking on the column header).
            ''  ---5/13/2022 td
            ''
            Return Me.FocusRelated_UserHasSelectedColumn

        End If ''End of ""If (pbStrictVersion) Then... ElseIf... Else ""

    End Function ''End of ""Public Function FocusRelated_ColumnHasCellFocus() As Boolean""  


    Public Sub Handle_CellHasFocus(sender As Object, e As EventArgs)
        ''
        ''Added 5/13/2022 
        ''
        ''Added 5/13/2022 td 
        Me.ParentSpreadsheet.ClearHighlightingOfSelectedColumns()
        Me.FocusRelated_UserHasSelectedColumn = True
        Me.FocusRelated_SetHighlightingOn()

    End Sub ''End of ""Public Sub Handle_CellHasFocus""


    Public Sub AddBumpColumn(par_columnToBump As RSCFieldColumnV2)
        ''
        ''Added 4/1/2022 thomas 
        ''
        If (mod_listOfColumnsToBumpRight Is Nothing) Then
            mod_listOfColumnsToBumpRight = New List(Of RSCFieldColumnV2)
        End If

        If (Not mod_listOfColumnsToBumpRight.Contains(par_columnToBump)) Then
            mod_listOfColumnsToBumpRight.Add(par_columnToBump)
        End If

        ''----If (Not mod_iMoveOrResizeFunctionality.ListOfColumnsToBumpRight.Contains(par_columnToBump)) Then
        mod_iMoveOrResizeFunctionality.AddColumnToBumpRight(par_columnToBump)
        ''---End If

    End Sub ''End of "Public Sub AddBumpColumn(par_columnToBump As RSCFieldColumn)"


    Public Sub RemoveBumpColumn(par_columnToBump As RSCFieldColumnV2)
        ''
        ''Added 4/15/2022 thomas 
        ''
        If (mod_listOfColumnsToBumpRight Is Nothing) Then Return
        ''    mod_listOfColumnsToBumpRight = New List(Of RSCFieldColumnV2)
        ''End If

        If (mod_listOfColumnsToBumpRight.Contains(par_columnToBump)) Then
            mod_listOfColumnsToBumpRight.Remove(par_columnToBump)
        End If

        ''----If (Not mod_iMoveOrResizeFunctionality.ListOfColumnsToBumpRight.Contains(par_columnToBump)) Then
        mod_iMoveOrResizeFunctionality.RemoveColumnToBumpRight(par_columnToBump)
        ''---End If

    End Sub ''End of "Public Sub AddBumpColumn(par_columnToBump As RSCFieldColumn)"


    Public Sub Load_FieldsFromCache(par_cache As ClassElementsCache_Deprecated)
        ''
        ''Added 3/14/2022 td
        ''
        If (par_cache Is Nothing) Then Throw New ArgumentException("Exception Occured")

        RscSelectCIBField1.Loading = True ''Added 4/1/2022
        RscSelectCIBField1.ElementsCache_Deprecated = Me.ElementsCache_Deprecated
        RscSelectCIBField1.ParentSpreadsheet = Me.ParentSpreadsheet
        RscSelectCIBField1.Load_FieldsFromCache(par_cache)

        ''
        ''Added 3/15/2022 td
        ''
        RscSelectCIBField1.SelectedValue = mod_columnWidthAndData.CIBField

        ''Added 4/1/2022 td
        Application.DoEvents()
        RscSelectCIBField1.Loading = False ''Added 4/1/2022 td

    End Sub ''end of "Public Sub Load_FieldsFromCache"


    Public Sub Load_ColumnListDataToColumnEtc()
        ''
        ''Encapsulated 4/15/2022 thomas d.
        ''
        ''
        ''Added 3/19/2022  
        ''
        If (0 <> mod_columnWidthAndData.ColumnData.Count) Then
            ''4/15/2022 thomas d''LoadDataToColumn(mod_columnWidthAndData.ColumnData)
            Load_ColumnListDataToColumn(mod_columnWidthAndData.ColumnData)
        End If ''If (0 <> mod_columnWidthAndData.ColumnData.Count) Then

        ''
        ''Added 3/19/2022  
        ''
        ''Restore the width of the columns determined by the user's resizing behavior
        ''   in the prior session.  
        ''
        If (0 < mod_columnWidthAndData.Width) Then
            Me.Width = mod_columnWidthAndData.Width
        End If ''If (0 < mod_columnWidthAndData.Width) Then

    End Sub ''end of "Public Sub Load_ColumnListDataToColumnEtc"


    Private Sub Load_ColumnListDataToColumn(par_listData As List(Of String))
        ''---4/15/2022 td---Private Sub LoadDataToColumn(par_listData As List(Of String))
        ''
        ''Added 3/19/2022 td
        ''
        Dim indexItem As Integer = 0

        ''Added 4/13/2022
        If (par_listData Is Nothing) Then
            ''Added 4/14/2022
            MessageBoxTD.Show_Statement("No non-null list of data with which to supply the present column.")
            Exit Sub
        ElseIf (par_listData.Count = 0) Then
            ''Added 4/13/2022
            MessageBoxTD.Show_Statement("No data exists with which to supply the present column.")
            Exit Sub
        ElseIf (Me.CountOfRows() < par_listData.Count) Then
            ''Added 4/15/2022
            Load_EmptyRows(par_listData.Count)

        End If ''End of ""If (par_listData.Count = 0) Then .... ElseIf.... ElseIf....""

        ''
        ''Looping to populate the data cells. 
        ''
        indexItem = 0
        For Each each_RSCDataCell In ListOfRSCDataCells_TopToBottom()

            ''Added 4/14/2022 td
            If (indexItem > par_listData.Count) Then Continue For

            ''Added 5/03/2022 thomas downes
            ''  Let's try to avoid run-time errors when it comes to re-opening
            ''  after having deleted a number of rows. 
            If (indexItem >= par_listData.Count) Then Exit For

            each_RSCDataCell.Text = par_listData.Item(indexItem)
            ''If (each_RSCDataCell.Text = "aaa") Then System.Diagnostics.Debugger.Break()
            each_RSCDataCell.Tag_Text = par_listData.Item(indexItem) ''For detecting edits. ---4/13/2022
            each_RSCDataCell.ForeColor = Color.Black

            ''Prepare for next iteration
            indexItem += 1

        Next each_RSCDataCell

        ''
        ''Build statistics to describe the general number of letters & digits in the data. 
        ''
        mod_statistics = ClassMathStats.GetMeanAndStdDeviation_FourStats(par_listData)


    End Sub ''End of "Private Sub LoadDataToColumn()"


    Public Sub ClearBorderStyle_PriorCell(par_objNextCell As RSCDataCell)
        ''Added 4/28/2022 td
        Me.ParentSpreadsheet.ClearBorderStyle_PriorCell(par_objNextCell)

        ''    Static s_objPriorCell As RSCDataCell
        ''    If (s_objPriorCell IsNot Nothing) Then
        ''        s_objPriorCell.BorderStyle_Textbox = BorderStyle.None
        ''    End If ''End of ""If (s_objPriorCell IsNot Nothing) Then""
        ''    ''Prepare for next calling to this procedure.
        ''    s_objPriorCell = par_objNextCell

    End Sub


    Public Sub ClearDataFromColumn_Do() ''Added 3/20/2022
        ''
        ''Added 3/20/2022 t//d//
        ''
        Dim indexItem As Integer = 0
        Dim listRSCDataCells As IEnumerable(Of RSCDataCell)

        listRSCDataCells = ListOfRSCDataCells_TopToBottom()
        ReDim mod_arrayOfData_Undo(-1 + listRSCDataCells.Count)
        ReDim mod_arrayOfData_Undo_Tag(-1 + listRSCDataCells.Count)

        ''
        ''Looping 
        ''
        For Each each_RSCDataCell In listRSCDataCells '' ListOfRSCDataCelles_TopToBottom()

            ''Enable the Undo procedure.
            mod_arrayOfData_Undo(indexItem) = each_RSCDataCell.Text

            ''Added 4/1/2022 td
            If (each_RSCDataCell.Tag Is Nothing) Then each_RSCDataCell.Tag = "" ''Added 4/1/2022
            mod_arrayOfData_Undo_Tag(indexItem) = each_RSCDataCell.Tag.ToString() ''Added 4/1/2022td

            indexItem += 1

            ''Clear the RSCDataCell of data.  
            each_RSCDataCell.Text = ""
            each_RSCDataCell.Tag = "" ''Added 4/1/2022
            each_RSCDataCell.Tag_Text = "" ''Added 4/11/2022

        Next each_RSCDataCell

    End Sub ''End of "Private Sub LoadDataToColumn_Do()"


    Public Sub ClearDataFromColumn_Undo(Optional pboolSkipBoxesWithData As Boolean = False)
        ''
        ''Added 3/20/2022 td
        ''
        Dim indexItem As Integer = 0
        Dim listRSCDataCelles As IEnumerable(Of RSCDataCell)
        Dim bExpectedLength As Boolean
        Dim boolHasDataToKeep As Boolean

        listRSCDataCelles = ListOfRSCDataCells_TopToBottom()
        bExpectedLength = (listRSCDataCelles.Count = mod_arrayOfData_Undo.Length)
        If (bExpectedLength) Then
            For Each each_RSCDataCell In listRSCDataCelles '' ListOfRSCDataCelles_TopToBottom()

                ''Added 3/20/2022 td
                boolHasDataToKeep = pboolSkipBoxesWithData And Not String.IsNullOrEmpty(each_RSCDataCell.Text)
                If (boolHasDataToKeep) Then
                    indexItem += 1 ''We must increment the index before the next iteration.
                    Continue For ''Skips the execution of this iteration & continues at next iteration.
                End If ''End of "If (boolHasDataToKeep) Then"

                ''Restore the RSCDataCell of data.  
                each_RSCDataCell.Text = mod_arrayOfData_Undo(indexItem)
                each_RSCDataCell.Tag = mod_arrayOfData_Undo_Tag(indexItem) ''Added 4/1/2022
                indexItem += 1

            Next each_RSCDataCell

        ElseIf (mod_arrayOfData_Undo.Length <= 1) Then
            ''Added 3/20/2022 td
            MessageBoxTD.Show_Statement("Cannot perform Undo. No data found.")
        Else
            ''Length is unexpected.  
            System.Diagnostics.Debugger.Break()

        End If ''End of "If (bExpectedLength) Then..... ElseIf (...) ... Else...."

    End Sub ''End of "Public Sub ClearDataFromColumn_Undo()"


    Public Sub PasteDataFromClipboard()
        ''
        ''Added 5/13/2022 td 
        ''
        ''5/2022 ''Dim objFirstCell As RSCDataCell
        Dim objTargetCell As RSCDataCell
        Dim boolHasDataAlready As Boolean
        Dim boolUserConfirmedPaste As Boolean
        Dim bCellOrHeaderHasFocus As Boolean

        objTargetCell = GetFirstRSCDataCell()

        ''Added 5/13/2022 thomas downes
        ''  Check the cells to see which has the text-caret focus ("editing focus").
        ''
        For Each each_cell As RSCDataCell In ListOfRSCDataCells_TopToBottom()
            ''May 13, 2022 ''If (each_cell.HasFocus()) Then
            ''May 13, 2022 ''if (each_cell.RowHeaderHasFocus()) Then"

            With each_cell
                bCellOrHeaderHasFocus = (.FocusRelated_CellHasFocus() Or
                                          .FocusRelated_RowHeaderHasFocus())
            End With

            If (bCellOrHeaderHasFocus) Then
                objTargetCell = each_cell
                Exit For
            End If ''End of ""If (each_cell.HasFocus()) Then""
        Next each_cell

        ''
        ''Perform operations on the appropriate cell.  
        ''
        With objTargetCell

            boolHasDataAlready = (Not String.IsNullOrWhiteSpace(.Text_CellValue))
            If (boolHasDataAlready) Then

                boolUserConfirmedPaste = MessageBoxTD.Show_Confirmed("Overwrite existing data?", "", False)

            Else
                boolUserConfirmedPaste = True ''Force to True, since we don't anticipate
                ''  any problems of overwriting data, as no data has been detected. 

            End If ''End of ""If (boolHasDataAlready) Then""

            If (boolUserConfirmedPaste) Then
                ''Major call!! 
                .PasteDataFromClipboard(boolUserConfirmedPaste)

            End If ''end of ""If (boolUserConfirmedPaste) Then""


        End With

    End Sub ''End of ""Public Sub PasteDataFromClipboard()""


    Public Function CountOfRows() As Integer
        ''
        ''Added 4/3/2022 thomas downes  
        ''
        Const c_bWasteProcessingTime As Boolean = False
        If (c_bWasteProcessingTime) Then
            ''
            ''Requires unnecessary processing. 
            ''
            Dim listBoxes As List(Of RSCDataCell)
            Const c_boolSkipSorting As Boolean = True
            listBoxes = ListOfRSCDataCells_TopToBottom(c_boolSkipSorting)
            Return listBoxes.Count
        Else
            Return mod_listRSCDataCellsByRow.Count
        End If ''End of ""If (c_bWasteProcessingTime) Then....Else..."

    End Function ''End of ""Public Function CountOfRows() As Integer""


    Public Function CountOfBoxesWithData(Optional ByRef pref_countOfRows As Integer = 0) As Integer ''Added 3/20/2022
        ''
        ''Added 3/20/2022 t//d//
        ''
        Dim intCountData As Integer = 0
        Dim listRSCDataCelles As IEnumerable(Of RSCDataCell)

        listRSCDataCelles = ListOfRSCDataCells_TopToBottom()
        pref_countOfRows = listRSCDataCelles.Count ''Added 3/23/2022 td

        For Each each_RSCDataCell In listRSCDataCelles '' ListOfRSCDataCelles_TopToBottom()

            If (Not String.IsNullOrEmpty(each_RSCDataCell.Text)) Then intCountData += 1

        Next each_RSCDataCell

        Return intCountData

    End Function ''End of "Public Function CountOfBoxesWithData()"


    Public Sub DeleteRow_ByRowIndex(par_intRowIndex As Integer)
        ''
        '' Added 4/25/2022 thomas d. 
        ''
        Dim objRSCDataCell As RSCDataCell
        Const c_boolDeleteRecipient As Boolean = True ''Added 5/1/2022 thomas

        objRSCDataCell = GetCellWithRowIndex(par_intRowIndex) ''.Text_CellValue = ""

        ''Added 5/01/2022 td
        If (c_boolDeleteRecipient) Then
            Me.ListRecipients.Remove(objRSCDataCell.Recipient)
            Me.ParentSpreadsheet.DeleteRecipientFromCache(objRSCDataCell.Recipient)
        End If ''End of ""If (c_boolDeleteRecipient) Then""

        objRSCDataCell.Text_CellValue = ""
        objRSCDataCell.Visible = False
        mod_listRSCDataCellsByRow.Remove(par_intRowIndex)
        Me.Controls.Remove(objRSCDataCell)

        ''
        ''Exit Handler....
        ''
        objRSCDataCell.RowIndex_NeededIfDeleted = par_intRowIndex
        If (mod_listDeletedRSCDataCells Is Nothing) Then
            mod_listDeletedRSCDataCells = New List(Of RSCDataCell)
        End If ''End of ""If (mod_listDeletedRSCDataCells Is Nothing) Then""

        ''Make a record of the deletion. 
        mod_listDeletedRSCDataCells.Add(objRSCDataCell)

    End Sub ''End of ""Public Sub DeleteRow_ByRowIndex(par_intRowIndex As Integer)""


    Public Sub ClearRow_ByRowIndex(par_intRowIndex As Integer)
        ''
        '' Added 4/25/2022 thomas d. 
        ''
        GetCellWithRowIndex(par_intRowIndex).Text_CellValue = ""


    End Sub ''End of ""Public Sub ClearRow_ByRowIndex(par_intRowIndex As Integer)""


    Public Function CountOfBoxesWithData_Edited(Optional ByRef pref_countOfRows As Integer = 0,
                              Optional ByRef pref_examples As String = "",
                              Optional ByVal par_intHowManyExamples As Integer = 10) As Integer ''Added 3/20/2022
        ''
        ''Added 3/20/2022 t//d//
        ''
        Dim intCountData As Integer = 0
        Dim listRSCDataCells As IEnumerable(Of RSCDataCell)
        Dim bMismatchOfTag As Boolean
        Dim intExamples As Integer
        Dim intCellIndex As Integer = 0

        listRSCDataCells = ListOfRSCDataCells_TopToBottom()
        pref_countOfRows = listRSCDataCells.Count ''Added 3/23/2022 td

        ''
        '' Looping each cell in the column. ---4/10/2022 td
        ''
        For Each each_RSCDataCell In listRSCDataCells '' ListOfRSCDataCelles_TopToBottom()

            intCellIndex += 1
            ''If (Not String.IsNullOrEmpty(each_RSCDataCell.Text)) Then intCountData += 1
            ''April 15 2022 ''bMismatchOfTag = (each_RSCDataCell.Text <> CStr(each_RSCDataCell.Tag))
            ''5/24/2022 td''bMismatchOfTag = (each_RSCDataCell.Text <> CStr(each_RSCDataCell.Tag_Text))
            bMismatchOfTag = (Not String.IsNullOrEmpty(each_RSCDataCell.Tag_Text)) AndAlso
                (each_RSCDataCell.Text <> CStr(each_RSCDataCell.Tag_Text))

            If bMismatchOfTag Then

                intCountData += 1

                ''Added 4/10/2022 td
                If (intExamples < par_intHowManyExamples) Then
                    intExamples += 1
                    pref_examples &= (vbCrLf & String.Format("{0}. Text {1} vs. Tag {2}",
                            intCellIndex.ToString(),
                            each_RSCDataCell.Text,
                            CStr(each_RSCDataCell.Tag)))
                End If ''End of ""If (intExamples < par_intHowManyExamples) Then""

            End If ''End of "If bMismatchOfTag Then"

        Next each_RSCDataCell

        Return intCountData

    End Function ''End of "Private Sub LoadDataToColumn_Do()"


    Public Sub AddToEdgeOfSpreadsheet_Row()
        ''4/30/2022 td''Public Sub AddRowToBottomOfSpreadsheet()

        ''Added 4/30/2022 thomas downes
        ''4/30/2022 td''Me.ParentSpreadsheet.AddRowToBottomOfSpreadsheet()
        Me.ParentSpreadsheet.AddToEdgeOfSpreadsheet_Row()

    End Sub ''End of ""Public Sub AddRowToEdgeOfSpreadsheet_Row()""


    Public Sub AddToEdgeOfSpreadsheet_Column()

        ''Added 4/30/2022 thomas downes
        Me.ParentSpreadsheet.AddToEdgeOfSpreadsheet_Column()

    End Sub ''End of ""Public Sub AddRowToEdgeOfSpreadsheet_Column()""


    Public Function GetFirstRSCDataCell() As RSCDataCell
        ''
        ''Added 4/04/2022 thomas downes
        ''
        ''---Dim objFirstRSCDataCell As RSCDataCell
        Static s_objFirstRSCDataCell As RSCDataCell
        If (s_objFirstRSCDataCell IsNot Nothing) Then Return s_objFirstRSCDataCell
        s_objFirstRSCDataCell = ListOfRSCDataCells_TopToBottom().First()
        Return s_objFirstRSCDataCell

    End Function ''End of ""Public Function GetFirstRSCDataCell() As RSCDataCell""


    Public Function GetFirstRSCDataCellPropertyTop() As Integer
        ''
        ''Added 3/24/2022 thomas downes
        ''
        Dim objFirstRSCDataCell As RSCDataCell
        objFirstRSCDataCell = ListOfRSCDataCells_TopToBottom().First()
        Return objFirstRSCDataCell.Top

    End Function ''end of ""Public Function GetFirstRSCDataCellPropertyTop() As Integer""


    Public Function GetRSCDataCellAtBottom_Bottom() As Integer
        ''
        ''Added 4/4//2022 thomas downes 
        ''
        Dim objBottomRSCDataCell As RSCDataCell
        objBottomRSCDataCell = ListOfRSCDataCells_TopToBottom().Last
        Return objBottomRSCDataCell.Top + objBottomRSCDataCell.Height

    End Function ''End of ""Public Function GetRSCDataCellAtBottom_Bottom()""


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
                                 Optional ByRef pref_boolRows_TooMany As Boolean = False,
                                 Optional pboolCheck_ColumnWidthAndData As Boolean = True)
        ''
        ''Added 3/22/2022 td
        ''
        Dim intCountAllBoxesOrRows As Integer ''Added 3/23/2022 td
        Dim intCountBoxesEmptyOrNot As Integer ''Addexd 3/23/2022 td
        Const c_bExitUponWarning As Boolean = False ''6/2022 td  

        ''Moved here from below.---4/23/2022 td
        Dim intCountRecipients As Integer
        intCountRecipients = Me.ListRecipients.Count
        Load_EmptyRows(intCountRecipients)

        Dim intCountCellsWithData_Edited As Integer
        ''March23 2022''intCountCellsWithData = CountOfBoxesWithData()
        ''April 01 2023''intCountCellsWithData = CountOfBoxesWithData(intCountBoxesEmptyOrNot)
        ''April 10 2023''intCountCellsWithData_Edited = CountOfBoxesWithData_Edited(intCountBoxesEmptyOrNot)
        Dim strListExamples As String = "" ''Added 4/10/2022 thomas
        Dim strMessage As String = "" ''Added 4/11/2022 thomas
        Dim bool_Confirm As Boolean ''4/11 DialogResult ''Added 4/11/2022 td

        intCountCellsWithData_Edited = CountOfBoxesWithData_Edited(intCountBoxesEmptyOrNot, strListExamples)
        If (0 <> intCountCellsWithData_Edited) Then ''.... <> 0) Then
            pboolErrorCellsHaveValues = True
            ''4/11/2022 td''Throw New Exception("Warning, non-zero >0 cells with data edited already. Edits would be lost.")
            strMessage = "Warning, non-zero >0 cells with data edited already. Edits would be lost.  Continue?"
            bool_Confirm = MessageBoxTD.Show_Confirmed(strMessage, strListExamples, True)
            If (Not bool_Confirm) Then Return ''Added 4/11/2022 td
        End If ''End of ""If (intCountCellsWithData_Edited <> 0) Then""

        Dim enumFieldSelected As EnumCIBFields
        enumFieldSelected = RscSelectCIBField1.SelectedValue
        If (enumFieldSelected = EnumCIBFields.Undetermined) Then
            pref_bNoFieldSelected = True
            If (Not MsgOnce_UnspecifiedField) Then
                ''Not needed.6/2022 --MessageBoxTD.Show_Statement("Warning, not all columns have a specified field. GE45")
                MsgOnce_UnspecifiedField = True
            End If ''If (Not MsgUnspecifiedField) Then
            ''6/2022 td ''Return 
            If (c_bExitUponWarning) Then Return ''Added 6/2022 td 
        End If ''End of ""If (enumFieldSelected = EnumCIBFields.Undetermined) Then""

        Dim boolNoRecipList As Boolean
        boolNoRecipList = (Me.ListRecipients Is Nothing)
        pref_bNoRecipientList = boolNoRecipList
        If (pref_bNoRecipientList) Then
            ''6/2022 td ''Throw New Exception("ListRecipients is a Null reference.")
            System.Diagnostics.Debugger.Break() ''Added 6/2022 td
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
                Return ''Added 5/16/2022 td
            Else
                ''Throw an error. Where in heck is the list of fake hard-coded recipients? 
                ''6/2022 td ''Throw New Exception("ListRecipients has Zero(0) recipient (student) rows.")
                System.Diagnostics.Debugger.Break()
                Return
            End If ''ENd of ""If (c_boolAllowForBlankSlate) Then... Else..."
        End If ''ENd of ""If (boo lNoRecipients_zero) Then""

        ''
        ''Added 3/29/2022 thomas downes
        ''
        ''Moved above. 4/23/2022 td''Load_EmptyRows(intCountRecipients)

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
            ''6/2022  Throw New Exception("Warning, we have less RSCDataCells than required. Data would be lost.")
            System.Diagnostics.Debugger.Break()

        ElseIf (boolMismatchOfCounts_More) Then
            ''3/29/2022 td''pboolErrorCellsHaveValues = True
            pref_boolRows_TooMany = True
            ''---Throw New Exception("Warning, non-zero >0 cells with data already. Data would be lost.")
            ''6/2022  Throw New Exception("Warning, we have more RSCDataCells than required. Rows will be left blank.")
            System.Diagnostics.Debugger.Break()

        End If ''End of ""If (boolMismatchOfCounts) then""

        ''-----------------------------------------------------------

        ''March25 2022 td''Dim listBoxes As IOrderedEnumerable(Of RSCDataCell)
        Dim listBoxes As List(Of RSCDataCell)
        Dim intRowIndex As Integer = -1
        Dim each_value As String
        Dim boolMiscountOfRows As Boolean
        Dim intRowsInSpreadsheet As Integer
        Dim listValuesForStatistics As New List(Of String) ''Added 4/26/2022 td

        listBoxes = ListOfRSCDataCells_TopToBottom()

        ''Added 4/11/2022
        intRowsInSpreadsheet = Me.CountOfRows() ''Me.ParentSpreadsheet.RscFieldColumn1.CountOfRows()
        boolMiscountOfRows = (listBoxes.Count <> intRowsInSpreadsheet)
        If (boolMiscountOfRows) Then
            System.Diagnostics.Debugger.Break()
        End If ''End of ""If (boolMiscountOfRows) Then""

        ''
        ''Looping 
        ''
        For Each each_box As RSCDataCell In listBoxes

            intRowIndex += 1

            ''4/11 td''each_box.Text = Me.ListRecipients(intRowIndex).GetTextValue(enumFieldSelected)
            ''Added 4/11/2022 td
            each_value = Me.ListRecipients(intRowIndex).GetTextValue(enumFieldSelected)

            ''Added 4/25/2022 td
            listValuesForStatistics.Add(each_value)

            ''Added 4/15/2022
            Dim strCellDataBeforeLoadingRecip As String
            Dim strCellDataFromColumnData As String
            Dim boolMismatch_ColumnData As Boolean
            If (pboolCheck_ColumnWidthAndData) Then
                ''Compare the Recipient data to the ColumnWidthAndData data.
                ''   ---4/14/2022
                strCellDataBeforeLoadingRecip = each_box.Text.Trim() ''5/01/2022 td''each_box.Text
                strCellDataFromColumnData = ColumnWidthAndData.ColumnData(intRowIndex).Trim() ''Added .Trim() on 5/01/2022
                boolMismatch_ColumnData = (strCellDataFromColumnData <> each_value)
                If (boolMismatch_ColumnData) Then
                    ''---System.Diagnostics.Debugger.Break()
                    MessageBoxTD.Show_Statement("Due to a mismatch of data, we are not able to continue " &
                                                " to load the recipient data into this column.")
                    Exit Sub
                End If ''End of ""If (boolMismatch_ColumnData) Then""
            End If ''End of ""If (pboolCheck_ColumnWidthAndData) Then""

            ''5/1/2022 td''each_box.Text = each_value
            each_box.Text = each_value.Trim()

            ''Added 4/12/2022 thomas d.
            each_box.Recipient = Me.ListRecipients(intRowIndex)

            ''4/11/2022 td''each_box.Tag = each_box.Text ''added 4/1/2022
            each_box.Tag_Text = each_value ''4/11/2022 each_box.Text ''added 4/1/2022
            each_box.Tag = each_value ''4/11/2022 each_box.Text ''added 4/1/2022

        Next each_box

        ''
        ''Build statistics to describe the general number of letters & digits in the data. 
        ''  --4/26/2022 td
        ''
        mod_statistics = ClassMathStats.GetMeanAndStdDeviation_FourStats(listValuesForStatistics)


    End Sub ''End of "Public Sub LoadRecipientList()"


    Public Sub ReviewForAbnormalLengthValues(Optional ByRef pboolOneOrMore As Boolean = False,
                                             Optional ByVal pboolGiveMessageIfNeeded As Boolean = False)
        ''
        ''Added 4/26/2022 td
        ''
        Dim listRSCDataCells As List(Of RSCDataCell)
        Dim each_isAbnormal As Boolean

        listRSCDataCells = ListOfRSCDataCells_TopToBottom()
        ''---pref_countOfRows = listRSCDataCells.Count ''Added 3/23/2022 td

        ''
        '' Looping each cell in the column. ---4/10/2022 td
        ''
        For Each each_RSCDataCell As RSCDataCell In listRSCDataCells '' ListOfRSCDataCelles_TopToBottom()

            each_RSCDataCell.ReviewForAbnormalLengthValues(each_isAbnormal)
            pboolOneOrMore = (pboolOneOrMore Or each_isAbnormal)

        Next each_RSCDataCell

        ''
        ''Possibly give a message. 
        ''
        If (pboolOneOrMore And pboolGiveMessageIfNeeded) Then

            ''Added 4/26/2022 td 
            MessageBoxTD.Show_Statement("Please review cell values. One of more cells have unexpected values.")

        End If ''End of "If (pboolOneOrMore And pboolGiveMessageIfNeeded) Then"


    End Sub ''End of ""Public Sub ReviewForAbnormalLengthValues()""


    Public Function ValueIsAbnormal_Lengthy(par_value As String) As Boolean
        ''
        ''Added 4/26/2022 thomas downes 
        ''
        Dim boolTooLong As Boolean
        Dim boolTooShort As Boolean

        If (mod_statistics.Populated()) Then
            ''---boolTooLong = ClassMathStats.UnexpectedValue(par_value, mod_statistics, boolTooLong, boolTooShort)
            ClassMathStats.UnexpectedValue(par_value, mod_statistics,
                                           boolTooLong, boolTooShort)
            Return boolTooLong ''Return the modified ByRef value.  
        End If ''End of ""If (mod_statistics.Populated()) Then""

        Return False

    End Function ''Endof ""Public Function ValueIsAbnormal_Lengthy(par_value As String)"


    Public Function ValueIsAbnormal_Shorter(par_value As String) As Boolean
        ''
        ''Added 4/26/2022 thomas downes 
        ''
        Dim boolTooLong As Boolean
        Dim boolTooShort As Boolean

        If (mod_statistics.Populated()) Then
            ClassMathStats.UnexpectedValue(par_value, mod_statistics, boolTooLong, boolTooShort)
            Return boolTooShort
        End If ''End of ""If (mod_statistics.Populated()) Then""

        Return False

    End Function ''Endof ""Public Function ValueIsAbnormal_Shorter(par_value As String)"


    Public Sub ReviewColumnDisplayForRelevantFields(par_dictionary1FC As Dictionary(Of EnumCIBFields, RSCFieldColumnV2),
                                      par_dictionary2CF As Dictionary(Of RSCFieldColumnV2, EnumCIBFields),
                              Optional ByRef pref_strDescription1FC As System.Text.StringBuilder = Nothing,
                              Optional ByRef pref_strDescription2CF As System.Text.StringBuilder = Nothing)
        ''
        ''Added 4/26/2022 thomas 
        ''
        ''Supply both dictionaries. 
        ''   1FC. Field-->Column. (EnumCIBFields-->RSCFieldColumn dictionary. 
        ''   2CF. Column-->Field. (RSCFieldColumn-->EnumCIBFields) dictionary. 
        ''
        Dim enumCIB_Field As EnumCIBFields
        Dim boolAlreadyAdded As Boolean
        Dim strDescription1FC As String = ""
        Dim strDescription2CF As String = ""
        Dim intColumnIndex As Integer
        Dim intColumnIndex_prior As Integer

        intColumnIndex = Me.GetIndexOfColumn()

        enumCIB_Field = RscSelectCIBField1.SelectedValue
        boolAlreadyAdded = par_dictionary1FC.ContainsKey(enumCIB_Field)
        If (boolAlreadyAdded) Then
            ''pref_strDescription.AppendLine()
            intColumnIndex_prior = par_dictionary1FC(enumCIB_Field).GetIndexOfColumn()
            strDescription1FC = String.Format("The field {0} appears more than once, ", enumCIB_Field)
            strDescription1FC &= String.Format(" in Columns {0} and {1}", intColumnIndex, intColumnIndex_prior)
            pref_strDescription1FC.AppendLine(strDescription1FC)
            ''Add it to the other, EnumField-->RSCFieldColumn dictionary. 
            par_dictionary2CF.Add(Me, enumCIB_Field)
            strDescription2CF = String.Format("Column {0} has Field {1}.", intColumnIndex, enumCIB_Field)
            pref_strDescription2CF.AppendLine(strDescription2CF)
        Else
            ''Add it to both dictionaries.
            ''
            ''   1FC. Field-->Column. (EnumCIBFields-->RSCFieldColumn dictionary. 
            ''   2CF. Column-->Field. (RSCFieldColumn-->EnumCIBFields) dictionary.
            ''   
            par_dictionary1FC.Add(enumCIB_Field, Me)
            par_dictionary2CF.Add(Me, enumCIB_Field)
            strDescription1FC = String.Format("Field {0} has Column {1}.", enumCIB_Field, intColumnIndex)
            pref_strDescription1FC.AppendLine(strDescription2CF)
            strDescription2CF = String.Format("Column {0} has Field {1}.", intColumnIndex, enumCIB_Field)
            pref_strDescription2CF.AppendLine(strDescription2CF)

        End If ''End of ""If (boolAlread yAdded) Then.... Else....""

    End Sub ''End of ""Public Sub ReviewColumnDisplayForRelevantFields""


    Private Function ListOfData() As List(Of String)
        ''
        ''Added 3/18/2022 td   
        ''
        Dim objListData As New List(Of String)

        ''For Each each_RSCDataCell In objListOfRSCDataCelles_Ordered
        For Each each_RSCDataCell In ListOfRSCDataCells_TopToBottom()

            objListData.Add(each_RSCDataCell.Text)

        Next each_RSCDataCell

        ''
        ''ExitHandler
        ''
        Return objListData

    End Function ''end of Private Function ListOfData() As List(Of String)


    Public Function ListOfRSCDataCells_TopToBottom(Optional par_bSkipSorting As Boolean = False) As List(Of RSCDataCell) ''IOrderedEnumerable(Of RSCDataCell)
        ''
        ''Added 3/19/2022 td
        ''
        Dim objListOfRSCDataCells As New List(Of RSCDataCell)
        ''Dim objListOfRSCDataCelles_Ordered ''As New IOrderedEnumerable(Of(Of RSCDataCell)
        Dim objListOfRSCDataCells_Ordered As List(Of RSCDataCell)
        Dim intCountDataCells As Integer = 0 ''Added 4/15/2022 
        Dim intRowIndex As Integer

        Const c_boolSaveProcessingTime As Boolean = True
        Dim bDictionaryHasCells As Boolean
        Dim each_cell As RSCDataCell ''Added 5/1/2022 td

        bDictionaryHasCells = (0 < mod_listRSCDataCellsByRow.Count)

        If (c_boolSaveProcessingTime And bDictionaryHasCells) Then
            ''
            ''Added 4/15/2022 td
            ''
            objListOfRSCDataCells_Ordered = New List(Of RSCDataCell)
            For intRowIndex = 1 To mod_listRSCDataCellsByRow.Count
                ''5/1/2022 objListOfRSCDataCells_Ordered.Add(mod_listRSCDataCellsByRow(intRowIndex))
                If (mod_listRSCDataCellsByRow.ContainsKey(intRowIndex)) Then
                    each_cell = mod_listRSCDataCellsByRow(intRowIndex)
                    objListOfRSCDataCells_Ordered.Add(each_cell)
                Else
                    ''The row has been deleted by the user. 
                    ''---5/01/2022 thomas d. 
                End If ''End of ""If (mod_listRSCDataCellsByRow.ContainsKey(intRowIndex)) Then""
            Next intRowIndex

        Else
            ''
            ''This sucks up unnecessary processing time. 
            ''
            ''Added 3/25/2022 thomas d.
            If (Me.Controls.Count = 0) Then
                Throw New Exception("WTF")
            End If

            For Each eachCtl As Control In Me.Controls
                If (TypeOf eachCtl Is RSCDataCell) Then
                    ''Strangely, .Visible is False????---3/25/2022 td''If (eachCtl.Visible) Then
                    objListOfRSCDataCells.Add(CType(eachCtl, RSCDataCell))
                    intCountDataCells += 1
                    ''End If
                End If ''End of "If (TypeOf eachCtl Is RSCDataCell) Then"
            Next eachCtl ''End of ""For Each eachCtl As Control In Me.Controls""

            ''
            ''Order them in order of top-down (i.e. the Top property).
            ''
            ''Dim objListOfRSCDataCelles_Ordered As IOrderedEnumerable(Of RSCDataCell) =
            ''    From objRSCDataCell In objListOfRSCDataCelles
            ''    Select objRSCDataCell
            ''    Order By objRSCDataCell.Top

            ''objListOfRSCDataCelles.Sort(Function(elementA As RSCDataCell, elementB As RSCDataCell)
            ''                            Return elementA.Length.CompareTo(elementB.Length)
            ''                        End Function)

            ''Added 4/2/2022 td
            If (par_bSkipSorting) Then Return objListOfRSCDataCells

            ''Dim objListOfRSCDataCells_Ordered As List(Of RSCDataCell)
            objListOfRSCDataCells_Ordered = objListOfRSCDataCells.OrderBy(Of Integer)(Function(a) a.Top).ToList()

        End If ''End of ""If (c_SaveProcessingTime) Then .... Else ...

        ''
        ''Exithandler
        ''
        Return objListOfRSCDataCells_Ordered

    End Function ''End of "Private Function ListOfRSCDataCelles_TopToBottom() As IOrderedEnumerable(Of RSCDataCell)"


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
            End If ''End of "If (TypeOf eachCtl Is RSCDataCell) Then"
        Next eachCtl ''End of ""For Each eachCtl As Control In Me.Controls""

        ''
        ''Order them in order of top-down (i.e. the Top property).
        ''
        ''Dim objListOfBars_Ordered As IOrderedEnumerable(Of PictureBox) =
        ''    From objBar In objListOfBars
        ''    Select objBar
        ''    Order By objBar.Top

        Dim objListOfRSCDataCelles_Ordered As List(Of PictureBox)
        objListOfRSCDataCelles_Ordered = objListOfBars.OrderBy(Of Integer)(Function(a) a.Top).ToList()
        Return objListOfRSCDataCelles_Ordered

    End Function ''End of "Public Function ListOfBottomBars_TopToBottom() As IOrderedEnumerable(Of PictureBox)"


    Public Function GetNextColumn_Right() As RSCFieldColumnV2
        ''
        ''Added 4/12/2022 thomas downes
        ''
        Dim objSpreadsheet As RSCFieldSpreadsheet
        Dim objColumn_Right As RSCFieldColumnV2
        objSpreadsheet = Me.ParentSpreadsheet
        objColumn_Right = objSpreadsheet.GetNextColumn_RightOf(Me)
        Return objColumn_Right

    End Function ''End of ""Public Function GetNextColumn_Right() As RSCFieldColumnV2""


    Public Function GetNextColumn_Left() As RSCFieldColumnV2
        ''
        ''Added 4/12/2022 thomas downes
        ''
        Dim objSpreadsheet As RSCFieldSpreadsheet
        Dim objColumn_Left As RSCFieldColumnV2
        objSpreadsheet = Me.ParentSpreadsheet
        objColumn_Left = objSpreadsheet.GetNextColumn_LeftOf(Me)
        Return objColumn_Left

    End Function ''End of ""Public Function GetNextColumn_Left() As RSCFieldColumnV2""


    Public Function GetFirstRSCFieldColumn() As RSCFieldColumnV2
        ''
        ''Added 4/12/2022 
        ''
        Dim objSpreadsheet As RSCFieldSpreadsheet
        Dim objColumn_First As RSCFieldColumnV2
        objSpreadsheet = Me.ParentSpreadsheet
        objColumn_First = objSpreadsheet.GetFirstColumn()
        Return objColumn_First

    End Function


    Public Function GetRowIndexOfCell(par_cell As RSCDataCell) As Integer
        ''
        ''Added 4/12/2022 thomas downes
        ''
        ''---Dim list_cells As List(Of RSCDataCell)
        ''Dim intRowIndex As Integer
        Dim boolMatches As Boolean

        ''list_cells = ListOfRSCDataCells_TopToBottom()

        ''For intRowIndex = 1 To list_cells.Count

        ''    boolMatches = (list_cells(-1 + intRowIndex) Is par_cell)
        ''    If (boolMatches) Then Return intRowIndex

        ''Next intRowIndex

        For Each each_key As Integer In mod_listRSCDataCellsByRow.Keys

            boolMatches = (mod_listRSCDataCellsByRow(each_key) Is par_cell)

            If (boolMatches) Then Return each_key

        Next each_key

        Return -1

    End Function ''End of ""Public Function GetRowIndexOfCell(par_cell As RSCDataCell) As Integer""


    Public Function GetRSCDataCell_ByRowIndex(par_intRowIndex As Integer) As RSCDataCell
        ''
        ''Added 4/12/2022 thomas downes
        ''
        Return GetCellWithRowIndex(par_intRowIndex)

    End Function ''End of ""Public Function GetRSCDataCell_ByWithRowIndex() As RSCDataCell""

    Public Function GetCellWithRowIndex(par_intRowIndex As Integer) As RSCDataCell
        ''
        ''Added 4/12/2022 thomas downes
        ''
        ''----5/02/2022 td Return ListOfRSCDataCells_TopToBottom()(-1 + par_intRowIndex)
        Return mod_listRSCDataCellsByRow(par_intRowIndex)

    End Function ''End of ""Public Function GetCellWithRowIndex() As RSCDataCell""


    Public Function GetRowIndexOfTextbox(par_textbox As TextBox) As Integer
        ''
        ''Added 4/12/2022 thomas downes
        ''
        Dim list_cells As List(Of RSCDataCell)
        Dim each_textbox As TextBox
        Dim intRowIndex As Integer
        Dim boolMatches As Boolean

        list_cells = ListOfRSCDataCells_TopToBottom()

        For intRowIndex = 1 To list_cells.Count

            ''Check the .Textbox1a property.
            each_textbox = list_cells(-1 + intRowIndex).Textbox1a
            boolMatches = (each_textbox Is par_textbox)
            If (boolMatches) Then Return intRowIndex

        Next intRowIndex

        Return -1

    End Function ''End of ""Public Function GetRowIndexOfTextbox(par_cell As RSCDataCell) As Integer""


    Public Sub SaveDataTo_ColumnCache()
        ''April 12 2022 ''Public Sub SaveDataToColumn()
        ''
        ''We are not really saving to the Column Cache.
        ''  We are saving to the ColumnWidthAndData object which is part of
        ''  the Column Cache.
        ''
        ''Added 3/18/2022 t1h1o1m1a1s1 d1o1w1n1e1s1
        ''
        Dim objFieldColumnControl As RSCFieldColumnV2
        Dim intRowCount As Integer ''4/2022

        objFieldColumnControl = Me
        ''March18 2022''With Me.ColumnWidthAndData
        With mod_columnWidthAndData

            .CIBField = RscSelectCIBField1.SelectedValue
            .Width = Me.Width
            .ColumnData = Me.ListOfData()
            .Rows = Me.ListOfData().Count

            ''Added 4/15/2022
            intRowCount = .Rows

        End With ''End of "With Me.ColumnWidthAndData"

    End Sub ''End of Public Sub SaveDataTo_ColumnCache()


    Public Sub SaveToRecipient(par_objRecipient As ClassRecipient,
                               par_iRowIndex As Integer,
                               Optional ByRef pboolFailure As Boolean = False)
        ''
        ''Added 5/19/2022 thomas downes
        ''
        Dim one_RSCDataCell As RSCDataCell
        Dim enumCIBField As EnumCIBFields

        enumCIBField = RscSelectCIBField1.SelectedValue

        one_RSCDataCell = GetCellWithRowIndex(par_iRowIndex)

        ''one_RSCDataCell.SaveDataToRecipient(par_objRecipient, enumCIBField)
        ''5/25/2022 td ''one_RSCDataCell.SaveDataToRecipientField(par_objRecipient, enumCIBField)
        one_RSCDataCell.SaveDataToRecipientField(par_objRecipient, enumCIBField, pboolFailure)


    End Sub ''End of ""Public Sub SaveToRecipient""


    Public Sub SaveDataTo_RecipientCache()
        ''
        ''We are not really saving to the Recipient Cache.
        ''  We are saving to the Recipient classes which are part of
        ''  the Recipient Cache.
        ''
        ''Added 4/12/2022 t1h1o1m1a1s1 d1o1w1n1e1s1
        ''
        Dim each_RSCDataCell As RSCDataCell
        Dim enumCIBField As EnumCIBFields
        Dim intRowIndex As Integer ''Added 4/14/2022 td 

        enumCIBField = RscSelectCIBField1.SelectedValue

        ''Added 4/14/2022 td
        If (enumCIBField = EnumCIBFields.Undetermined) Then
            Exit Sub ''We need a field if we are to save to the Recipient.
        End If ''End of ""If (enumCIBField = EnumCIBFields.Undetermined) Then""

        For Each eachCtl As Control In Me.Controls
            If (TypeOf eachCtl Is RSCDataCell) Then

                each_RSCDataCell = (CType(eachCtl, RSCDataCell))

                ''Added 4/14/2022 td
                If (each_RSCDataCell.Recipient Is Nothing) Then ''Added 4/14/2022 td
                    intRowIndex = GetRowIndexOfCell(each_RSCDataCell)
                    each_RSCDataCell.Recipient = Me.ParentSpreadsheet.GetRecipientByRowIndex(intRowIndex)
                Else
                    each_RSCDataCell.SaveDataToRecipientField(enumCIBField)
                End If ''If (each_RSCDataCell.Recipient Is Nothing) Then... Else...

            End If ''End of "If (TypeOf eachCtl Is RSCDataCell) Then"
        Next eachCtl ''End of ""For Each eachCtl As Control In Me.Controls""


    End Sub ''End of Public Sub SaveDataTo_RecipientCache()


    ''    RscFieldSpreadsheet1.RscFieldColumn1.AlignBottomBars_EvenlySpaced()
    ''            RscFieldSpreadsheet1.RscFieldColumn1.AlignRSCDataCelles_ToBottomBars()
    Public Sub AlignBottomBars_EvenlySpaced()
        ''
        ''Added 3/26/2022
        ''


    End Sub ''Endof ""Public Sub AlignBottomBars_EvenlySpaced()""


    Public Sub AlignRSCDataCells_ToBottomBars()
        ''
        ''Added 3/26/2022
        ''


    End Sub ''Endof ""Public Sub AlignRSCDataCelles_ToBottomBars()""


    Public Sub RefreshFieldDropdown()
        ''
        ''Added 4/13/2022 thomas downes
        ''
        RscSelectCIBField1.Load_FieldsFromCache(Me.ElementsCache_Deprecated)

    End Sub ''End of "Public Sub RefreshFieldDropdown()"


    Public Sub Load_OneEmptyRow_IfNeeded(par_intRowIndex As Integer,
                                         Optional pboolForceReposition As Boolean = False)
        ''
        ''Added 4/4/2022 td
        ''
        Dim bRowIndexLocated As Boolean
        Dim objRSCDataCell As RSCDataCell ''4/4/2022 td''New RSCDataCell ''Added 3/29/2022 thomas downes
        ''4/8/2022 Dim objBottomBar As PictureBox ''Added 4/5/2022 thomas downes
        Static prior_objRSCDataCell As RSCDataCell ''4/4/2022 td''New RSCDataCell ''Added 3/29/2022 thomas downes

        With mod_listRSCDataCellsByRow
            bRowIndexLocated = (.ContainsKey(par_intRowIndex))

            ''Added 4/11/2022 td
            ''If (par_intRowIndex = 18) Then System.Diagnostics.Debugger.Break()
            ''If (par_intRowIndex = 19) Then System.Diagnostics.Debugger.Break()

        End With

        If (pboolForceReposition) Then
            ''
            ''Don't exit. 
            ''
        ElseIf (bRowIndexLocated) Then

            ''Dim intLeft As Integer ''= .Left
            ''Dim intHeight As Integer ''= .Height
            ''Dim intTop As Integer ''= .Top
            ''Dim intWidth As Integer ''= .Width
            ''Dim boolBelongsToMe As Boolean
            Dim intNumberOfCells As Integer

            ''Dim prior_intLeft As Integer ''= .Left
            ''Dim prior_intHeight As Integer ''= .Height
            ''Dim prior_intTop As Integer ''= .Top
            ''Dim prior_intWidth As Integer ''= .Width
            ''Dim prior_boolBelongsToMe As Boolean

            ''Added 4/11/2022 td
            objRSCDataCell = mod_listRSCDataCellsByRow.Item(par_intRowIndex)

            With objRSCDataCell
                .Visible = True
                ''intLeft = .Left
                ''intHeight = .Height '' As Integer = .Height
                ''intTop = .Top '' As Integer = .Top
                ''intWidth = .Width '' As Integer = .Width
                ''boolBelongsToMe = Me.Controls.Contains(objRSCDataCell)
            End With ''ENd of ""With objRSCDataCell""

            If (prior_objRSCDataCell IsNot Nothing) Then
                With prior_objRSCDataCell
                    ''prior_intLeft = .Left
                    ''prior_intHeight = .Height '' As Integer = .Height
                    ''prior_intTop = .Top '' As Integer = .Top
                    ''prior_intWidth = .Width '' As Integer = .Width
                    ''prior_boolBelongsToMe = Me.Controls.Contains(objRSCDataCell)
                End With ''ENd of ""With objRSCDataCell""
            End If ''End of ""If (prior_objRSCDataCell IsNot Nothing) Then""

            intNumberOfCells = Me.ListOfRSCDataCells_TopToBottom().Count

            ''If (par_intRowIndex = 18) Then System.Diagnostics.Debugger.Break()

            ''Prepare for following call, for debugging!! ---4/11/2022 td 
            prior_objRSCDataCell = objRSCDataCell
            ''April 12, 2022 ''Exit Sub

        End If ''End of "If (pboolForceReposition) Then ... ElseIf....."

        ''
        ''Create the RSCDataCell and Bottom Bar. 
        ''

        ''
        ''Create the required RSCDataCell. 
        ''
        If (bRowIndexLocated) Then
            objRSCDataCell = mod_listRSCDataCellsByRow.Item(par_intRowIndex)
            ''4/8/2022 objBottomBar = mod_listTextAndBarByRow.Item(par_intRowIndex).BottomBar
        Else
            ''4/4/2022 td''Dim objRSCDataCell As New RSCDataCell ''Added 3/29/2022 thomas downes
            objRSCDataCell = New RSCDataCell ''Added 3/29/2022 thomas downes
            mod_listRSCDataCellsByRow.Add(par_intRowIndex, objRSCDataCell)
            ''4/8/2022 objBottomBar = GetBottomBarForRow()
            ''4/8/2022 Dim new_struct As New StructTextboxAndRowSeparator
            ''4/8/2022 new_struct.BottomBar = objBottomBar
            ''4/8/2022 new_struct.Cellbox = objRSCDataCell
            ''4/8/2022 mod_listTextAndBarByRow.Item(par_intRowIndex) = new_struct

        End If ''End of ""If (bRowIndexLocated) Then... Else..."

        Dim RSCDataCell_Top As RSCDataCell
        RSCDataCell_Top = Me.GetFirstRSCDataCell()
        With objRSCDataCell
            ''April 8, 2022 td''.Left = RSCDataCell_Top.Left
            ''April 8, 2022 td''.Width = RSCDataCell_Top.Width
            ''April 8, 2022 td''.Height = RSCDataCell_Top.Height
            ''---.Top = (RSCDataCell_BottomLast.Top + intTopGap)
            ''April 5, 2022 td''.Top = (RSCDataCell_Top.Top + mc_intPixelsFromRowToRow * (par_intRowIndex - 1))
            ''April 8, 2022 td''.Top = (RSCDataCell_Top.Top + (Me.PixelsFromRowToRow * (par_intRowIndex - 1)))
            With objRSCDataCell
                ''
                ''We will write to .Top & .Height through
                ''   the .Location & .Size object properties.
                ''   ---4/8/2022
                ''
                ''.Top = .....See Call To Module ModRSCLayout, just below.--4/8/2022
                ''.Left = .....See Call To Module ModRSCLayout, just below.--4/8/2022
                ''.Height = .....See Call To Module ModRSCLayout, just below.--4/8/2022
                ''.Width = .....See Call To Module ModRSCLayout, just below.--4/8/2022
                ''
                ModRSCLayout.PositionAndSizeControlByRow(objRSCDataCell, par_intRowIndex,
                                                         RSCDataCell_Top.Top,
                                                         RSCDataCell_Top.Width)

            End With ''ENd of ""With objRSCDataCell""

            .Anchor = RSCDataCell_Top.Anchor
            .BackColor = RSCDataCell_Top.BackColor
            .ForeColor = RSCDataCell_Top.ForeColor
            .BorderStyle = RSCDataCell_Top.BorderStyle
            .Font = RSCDataCell_Top.Font
            ''---.Top = (RSCDataCell_BottomLast.Top + intTopGap)
            ''April 5, 2022 td''.Top = (RSCDataCell_Top.Top + mc_intPixelsFromRowToRow * (par_intRowIndex - 1))
            ''April 8, 2022 td''.Top = (RSCDataCell_Top.Top + (Me.PixelsFromRowToRow * (par_intRowIndex - 1)))
            .Visible = True

            ''Bottom  row-related horizontal line (below each RSCDataCell).
            ''4/8/2022 objBottomBar.Top = .Top + .Height + 1

            .ParentColumn = Me ''Added 4/12/2022 thomas d.

        End With ''End of ""With objRSCDataCell""

        ''Added 4/11/2022 thomas downes
        ''If (par_intRowIndex = 18) Then System.Diagnostics.Debugger.Break()
        ''If (par_intRowIndex = 19) Then System.Diagnostics.Debugger.Break()

        ''Added 3/30/2022
        If (bRowIndexLocated) Then
            ''RSCDataCell is already one of the controls on the form. ---4/4/2022
        Else
            Me.Controls.Add(objRSCDataCell)
            ModRSCLayout.PositionAndSizeControlByRow(objRSCDataCell, par_intRowIndex,
                                                         RSCDataCell_Top.Top,
                                                         RSCDataCell_Top.Width)
            ''4/8/2022 Me.Controls.Add(objBottomBar)
        End If ''End of ""If (bRowIndexLocated) Then... Else ..."

        Dim RSCDataCell_BottomLast As RSCDataCell
        ''Me.Height = (objRSCDataCell.Top + objRSCDataCell.Height + intTopGap)

        Dim listOfBoxes As List(Of RSCDataCell)
        listOfBoxes = ListOfRSCDataCells_TopToBottom()
        RSCDataCell_BottomLast = listOfBoxes(-1 + listOfBoxes.Count) ''.LastOrDefault
        Me.Height = (RSCDataCell_BottomLast.Top + RSCDataCell_BottomLast.Height +
                    Me.PixelsFromRowToRow) ''----mc_intPixelsFromRowToRow)

    End Sub ''End of ""Public Sub Load_EmptyRow_IfNeeded(par(intRowIndex As Integer)""


    ''Public Function GetBottomBarForRow() As PictureBox
    ''    ''
    ''    ''Added 4/04/2022 td
    ''    ''
    ''    Dim objNewPicturebox As New PictureBox ''Added 3/29/2022 thomas downes
    ''    ''4/08/2022 Dim objTopBottomBar As PictureBox

    ''    ''4/08/2022 objTopBottomBar = mod_listTextAndBarByRow(1).BottomBar

    ''    With objNewPicturebox
    ''        .Left = objTopBottomBar.Left
    ''        .Width = objTopBottomBar.Width
    ''        .Height = objTopBottomBar.Height
    ''        .Anchor = objTopBottomBar.Anchor
    ''        .BackColor = objTopBottomBar.BackColor
    ''        .ForeColor = objTopBottomBar.ForeColor
    ''        .BorderStyle = objTopBottomBar.BorderStyle
    ''        .Font = objTopBottomBar.Font
    ''        ''---.Top = (RSCDataCell_BottomLast.Top + intTopGap)
    ''        .Visible = True
    ''    End With ''End of ""With objRSCDataCell""

    ''    Return objNewPicturebox ''Oops!! Forgot this. ---4/05/2022 td

    ''End Function ''End of ""Public Function GetBottomBarForRow()""


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
        Dim listOfBoxes As List(Of RSCDataCell)
        Dim RSCDataCell_Top As RSCDataCell
        Dim RSCDataCell_BottomLast As RSCDataCell
        Dim RSCDataCell_BottomDeux As RSCDataCell
        Dim intIndexStart As Integer
        Dim intIndex__End As Integer
        Dim intTopGap As Integer

        listOfBoxes = ListOfRSCDataCells_TopToBottom()
        RSCDataCell_Top = listOfBoxes(0)

        RSCDataCell_BottomLast = listOfBoxes(-1 + listOfBoxes.Count) ''.LastOrDefault
        RSCDataCell_BottomDeux = listOfBoxes(-2 + listOfBoxes.Count) ''.LastOrDefault

        intIndexStart = (listOfBoxes.Count - 1 + 1)
        intIndex__End = (par_intRowsRequired - 1)
        intTopGap = (RSCDataCell_BottomLast.Top - RSCDataCell_BottomDeux.Top)

        For intRowIndex As Integer = intIndexStart To intIndex__End
            ''
            ''Create the required RSCDataCell. 
            ''
            Dim objRSCDataCell As New RSCDataCell ''Added 3/29/2022 thomas downes
            With objRSCDataCell
                .Left = RSCDataCell_Top.Left
                .Width = RSCDataCell_Top.Width
                .Height = RSCDataCell_Top.Height
                .Anchor = RSCDataCell_Top.Anchor
                .BackColor = RSCDataCell_Top.BackColor
                .ForeColor = RSCDataCell_Top.ForeColor
                .BorderStyle = RSCDataCell_Top.BorderStyle
                .Font = RSCDataCell_Top.Font
                .Top = (RSCDataCell_BottomLast.Top + intTopGap)
                .Visible = True
            End With ''End of ""With objRSCDataCell""

            ''Added 3/30/2022
            Me.Controls.Add(objRSCDataCell)
            Me.Height = (objRSCDataCell.Top + objRSCDataCell.Height + intTopGap)

        Next intRowIndex

    End Sub ''End of ""Public Sub Load_EmptyRows_CreateRows()""

    Public Sub FocusRelated_SetHighlightingOn()
        ''
        ''Added 5/13/2022 
        ''
        ''----Me.BackColor = RSCDataCell.BackColor_WithCellFocus
        ''5/13/2022 td''Me.BackColor = RSCDataCell.BackColor_WithEmphasisOnRow
        Me.BackColor = RSCFieldColumnV2.BackColor_WithEmphasis

    End Sub ''End of ""Public Sub FocusRelated_SetHighlightingOn()""


    Public Sub FocusRelated_SetHighlightingOff()
        ''
        ''Added 5/13/2022 
        ''
        ''5/13/2022 ''Me.BackColor = RSCDataCell.BackColor_NoEmphasis
        Me.BackColor = RSCFieldColumnV2.BackColor_NoEmphasis

    End Sub ''End of ""Public Sub FocusRelated_SetHighlightingOff()""


    Public Sub EmphasizeRows_Highlight(par_intRowIndex_Start As Integer,
                                   par_intRowIndex_End As Integer,
                                       Optional pboolRestoreOtherRows As Boolean = False)
        ''---Public Sub PaintEmphasisOfRows
        ''
        ''Added 4/27/2022 thomas downes  
        ''
        Dim intStartY As Integer
        Dim intEnd__Y As Integer

        Dim RSCDataCell_1st_Top As RSCDataCell
        Dim intRSCDataCell_1st_Top_Y As Integer

        ''Added 4/29/2022 thomas downes
        Dim intRowIndex_End As Integer ''Added 4/29/2022 td
        intRowIndex_End = par_intRowIndex_End
        If (par_intRowIndex_End = -1) Then
            par_intRowIndex_End = par_intRowIndex_Start
            intRowIndex_End = par_intRowIndex_Start
        End If ''End of ""If (par_intRowIndex_End = -1) Then""

        RSCDataCell_1st_Top = Me.GetFirstRSCDataCell()
        intRSCDataCell_1st_Top_Y = RSCDataCell_1st_Top.Top

        intStartY = ModRSCLayout.EmphasisOfRows_StartingY(par_intRowIndex_Start,
               intRSCDataCell_1st_Top_Y, RSCDataCell_1st_Top.Height)

        intEnd__Y = ModRSCLayout.EmphasisOfRows_EndingY(intRowIndex_End,
               intRSCDataCell_1st_Top_Y, RSCDataCell_1st_Top.Height)

        mod_emphasizeRows_TopY = intStartY
        mod_emphasizeRows_BottomY = intEnd__Y

        ''----See _Paint event handler, which will leverage the above module-level
        ''----   integer variables (mod_emphasis_TopY, mod_emphasis_BottomY).
        ''----   April 28, 2022
        ''----
        ''---PaintEmphasisOfRows_Repaint()

        ''Dim listCells As List(Of RSCDataCell)
        ''listCells = ListOfRSCDataCells_TopToBottom()
        Dim each_cell As RSCDataCell

        ''Added 4/29/2022 thomas d.
        ''Dim intRowIndex_End As Integer ''Added 4/29/2022 td
        ''If (-1 = par_intRowIndex_End) Then
        ''    intRowIndex_End = par_intRowIndex_Start
        ''Else
        ''    intRowIndex_End = par_intRowIndex_End
        ''End If

        For intRowIndex As Integer = par_intRowIndex_Start To intRowIndex_End ''---par_intRowIndex_End

            If (Not mod_listRSCDataCellsByRow.ContainsKey(intRowIndex)) Then
                ''
                ''It is possible that the row has been deleted. ---4/29/2022 td
                ''
            Else
                each_cell = mod_listRSCDataCellsByRow.Item(intRowIndex)
                ''each_cell.BackColor = Color.LightGray
                ''---each_cell.BackColor = mod_colorCellsBackcolor_WithEmphasis
                each_cell.BackColor = RSCDataCell.BackColor_WithEmphasisOnRow
            End If ''End of "If (mod_listRSCDataCellsByRow.ContainsKey(intRowIndex)) Then"

        Next intRowIndex

        ''
        ''If requested by Boolean parameter, let's de-emphasize the surrounding rows. 
        ''
        If (pboolRestoreOtherRows) Then

            ''-----------CONFUSING----------
            ''We will ---REMOVE EMPHASIS--- for rows outside of the range.
            If (par_intRowIndex_Start > 1) Then
                For intRowIndex As Integer = 1 To (par_intRowIndex_Start - 1)
                    ''-----------CONFUSING----------
                    ''We will ---REMOVE EMPHASIS--- for rows outside of the range.
                    each_cell = mod_listRSCDataCellsByRow.Item(intRowIndex)
                    ''each_cell.BackColor = Color.White
                    ''---each_cell.BackColor = mod_colorCellsBackcolor_NoEmphasis
                    each_cell.BackColor = RSCDataCell.BackColor_NoEmphasis
                Next intRowIndex
            End If ''End of ""If (par_intRowIndex_Start > 1) Then""

            ''
            ''-----------CONFUSING----------
            ''We will ---REMOVE EMPHASIS--- for rows outside of the range.
            Dim intRowIndexMaximum As Integer
            intRowIndexMaximum = mod_listRSCDataCellsByRow.Count
            If (intRowIndex_End < intRowIndexMaximum) Then
                For intRowIndex As Integer = (intRowIndex_End + 1) To intRowIndexMaximum
                    ''-----------CONFUSING----------
                    ''We will ---REMOVE EMPHASIS--- for rows outside of the range.
                    each_cell = mod_listRSCDataCellsByRow.Item(intRowIndex)
                    ''each_cell.BackColor = Color.White
                    ''---each_cell.BackColor = mod_colorCellsBackcolor_NoEmphasis
                    ''///each_cell.BackColor = CellsBackcolor_NoEmphasis
                    each_cell.BackColor = RSCDataCell.BackColor_NoEmphasis
                Next intRowIndex
            End If ''end of If (intRowIndex_End < intRowIndexMaximum) Then

        End If ''End of "" If (pboolRestoreOtherRows) Then""


    End Sub ''End of ""Public Sub EmphasisOfRows_Highlight()""


    Public Sub DeemphasizeRows_NoHighlight(par_intRowIndex_Start As Integer,
                                   par_intRowIndex_End As Integer)
        ''
        ''Added 4/29/2022 thomas downes  
        ''
        Dim each_cell As RSCDataCell
        ''Added 4/29/2022 thomas downes
        Dim intRowIndex_End As Integer ''Added 4/29/2022 td
        Dim boolDeletedRow As Boolean  ''Added 5/01/2022 thomas d. 

        intRowIndex_End = par_intRowIndex_End
        If (par_intRowIndex_End = -1) Then
            par_intRowIndex_End = par_intRowIndex_Start
            intRowIndex_End = par_intRowIndex_Start
        End If ''End of ""If (par_intRowIndex_End = -1) Then""

        For intRowIndex As Integer = par_intRowIndex_Start To intRowIndex_End ''par_intRowIndex_End

            boolDeletedRow = (Not mod_listRSCDataCellsByRow.ContainsKey(intRowIndex))
            If (boolDeletedRow) Then
                ''
                ''Added 5/1/2022 thomas
                ''The row is deleted, so we don't need to be concerned. 
                ''
            Else
                each_cell = mod_listRSCDataCellsByRow.Item(intRowIndex)
                ''each_cell.BackColor = Color.white
                ''---each_cell.BackColor = mod_colorCellsBackcolor_NoEmphasis
                each_cell.BackColor = RSCDataCell.BackColor_NoEmphasis

            End If ''End of ""If (boolDeletedRow) Then ... Else ...""

        Next intRowIndex


    End Sub ''End of ""Public Sub DeemphasisOfRows_NoHighlight()""


    Public Function ToString_ByRow(par_intRowIndex As Integer,
                                   Optional pboolRefresh As Boolean = False) As String
        ''
        ''Added 4/03/2022
        ''
        Dim strValue As String
        Static listRSCDataCelles As List(Of RSCDataCell)

        If (pboolRefresh Or listRSCDataCelles Is Nothing) Then
            listRSCDataCelles = ListOfRSCDataCells_TopToBottom()
        End If

        ''April 12 2022 ''strValue = listRSCDataCelles(par_intRowIndex).Text
        strValue = listRSCDataCelles(-1 + par_intRowIndex).Text
        Return strValue

    End Function ''End of ""Public Function ToString_ByRow(par_intRowIndex As Integer) As String""


    Private Sub Load_EmptyRows_DeleteRows(par_intRowsToCreate As Integer)
        ''
        ''Added 3/29/2022 thomas downes
        ''





    End Sub ''End of ""Public Sub Load_EmptyRows_DeleteRows()""



    ''Private Sub RSCDataCellExample1_TextChanged(sender As Object, e As EventArgs) Handles RSCDataCellExample1.TextChanged

    ''End Sub

    ''Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click

    ''End Sub

    ''Private Sub PictureBox12_Click(sender As Object, e As EventArgs) Handles PictureBox12.Click

    ''End Sub

    ''Private Sub RSCDataCell3_TextChanged(sender As Object, e As EventArgs) Handles RSCDataCell3.TextChanged

    ''End Sub

    ''Private Sub RSCDataCell11_TextChanged(sender As Object, e As EventArgs) Handles RSCDataCell11.TextChanged

    ''End Sub

    ''Private Sub RSCDataCell10_TextChanged(sender As Object, e As EventArgs) Handles RSCDataCell10.TextChanged

    ''End Sub

    ''Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click

    ''End Sub

    ''Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click

    ''End Sub

    ''Private Sub PictureBox11_Click(sender As Object, e As EventArgs) Handles PictureBox11.Click

    ''End Sub

    ''Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    ''End Sub

    ''Private Sub RSCDataCell4_TextChanged(sender As Object, e As EventArgs) Handles RSCDataCell4.TextChanged

    ''End Sub

    ''Private Sub RSCDataCell6_TextChanged(sender As Object, e As EventArgs) Handles RSCDataCell6.TextChanged

    ''End Sub

    ''Private Sub RSCDataCell9_TextChanged(sender As Object, e As EventArgs) Handles RSCDataCell9.TextChanged

    ''End Sub

    ''Private Sub RSCDataCell1_TextChanged(sender As Object, e As EventArgs) Handles RSCDataCell1.TextChanged

    ''End Sub

    ''Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click

    ''End Sub

    ''Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click

    ''End Sub

    ''Private Sub PictureBox10_Click(sender As Object, e As EventArgs) Handles PictureBox10.Click

    ''End Sub

    ''Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    ''End Sub

    ''Private Sub RSCDataCell5_TextChanged(sender As Object, e As EventArgs) Handles RSCDataCell5.TextChanged

    ''End Sub

    ''Private Sub RSCDataCell7_TextChanged(sender As Object, e As EventArgs) Handles RSCDataCell7.TextChanged

    ''End Sub

    ''Private Sub RSCDataCell8_TextChanged(sender As Object, e As EventArgs) Handles RSCDataCell8.TextChanged

    ''End Sub

    ''Private Sub RSCDataCell2_TextChanged(sender As Object, e As EventArgs) Handles RSCDataCell2.TextChanged

    ''End Sub

    ''Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click

    ''End Sub

    ''Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click

    ''End Sub

    Private Sub RSCDataCell_TextChanged(sender As Object, e As EventArgs) ''Handles RSCDataCell2.TextChanged
        ''
        ''Added 3/19/2022 Thomas Downes  
        ''
        Dim objRSCDataCell As RSCDataCell = CType(sender, RSCDataCell)
        objRSCDataCell.ForeColor = Color.Black


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

        ''Added 5/13/2022 td 
        Me.ParentSpreadsheet.ClearHighlightingOfSelectedColumns()
        Me.FocusRelated_UserHasSelectedColumn = True
        Me.FocusRelated_SetHighlightingOn()

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

    ''Private Sub RscSelectCIBField1_Load(sender As Object, e As EventArgs) Handles RscSelectCIBField1.Load

    ''End Sub

    ''Private Sub RSCDataCell1_TextChanged(sender As Object, e As EventArgs) Handles RSCDataCell2a.TextChanged

    ''End Sub

    ''Private Sub RSCDataCell5_TextChanged(sender As Object, e As EventArgs) Handles RSCDataCell4a.TextChanged

    ''End Sub


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

    Private Sub RSCFieldColumnV2_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint

        Dim myPen As Pen

        Dim intTopY As Integer
        Dim intBottomY As Integer

        intTopY = mod_emphasizeRows_TopY
        intBottomY = mod_emphasizeRows_BottomY

        ''Often, we will draw nothing / abort paint operation.
        If (intTopY <= 0) Then
            Exit Sub
        End If

        ''Often, we will draw nothing / abort paint operation.
        If (intBottomY <= 0) Then
            Exit Sub
        End If

        'instantiate a new pen object using the color structure
        myPen = New Pen(color:=Color.Green, width:=1)

        'draw the line on the form using the pen object
        e.Graphics.DrawLine(pen:=myPen, x1:=0, y1:=intTopY, x2:=Me.Width, y2:=intTopY)
        e.Graphics.DrawLine(pen:=myPen, x1:=0, y1:=intBottomY, x2:=Me.Width, y2:=intTopY)



    End Sub

    ''Private Sub RSCDataCell3_TextChanged(sender As Object, e As EventArgs) Handles RSCDataCell6a.TextChanged

    ''End Sub
End Class

