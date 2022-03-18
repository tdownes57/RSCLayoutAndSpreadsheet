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


Public Class RSCFieldColumn
    ''
    ''Added 2/21/2022 thomas downes  
    ''
    Public ColumnDataCache As CacheRSCFieldColumnWidthsEtc ''Added 3/15/2022 td
    Public ColumnWidthAndData As ClassColumnWidthAndData ''Added 3/15/2022 td
    Private mod_listOfColumnsToBumpRight As List(Of RSCFieldColumn)

    Public Property ListOfColumnsToBumpRight As List(Of RSCFieldColumn) ''Added 3/12/2022 td 
        Get
            Return mod_listOfColumnsToBumpRight
        End Get
        Set(value As List(Of RSCFieldColumn))
            mod_listOfColumnsToBumpRight = value
            Dim listUserControls As New List(Of UserControl)(value)
            ''March13 2022 td''MyBase.mod_iMoveOrResizeFunctionality.ListOfColumnsToBumpRight = value
            MyBase.mod_iMoveOrResizeFunctionality.ListOfColumnsToBumpRight = listUserControls
        End Set
    End Property


    Public Shared Function GetRSCFieldColumn(par_parametersGetElementControl As ClassGetElementControlParams,
                                           par_field As ClassFieldAny,
                                       par_formParent As Form,
                                      par_nameOfControl As String,
                                      par_iLayoutFun As ILayoutFunctions,
                                      par_bProportionSizing As Boolean,
                                      par_iControlLastTouched As ILastControlTouched,
                                     par_iRecordLastControl As IRecordElementLastTouched,
                                     par_oMoveEventsForGroupedCtls As GroupMoveEvents_Singleton) As RSCFieldColumn
        ''
        ''Added 3/8/2022 & 1/04/2022 td
        ''
        ''Unused. Jan17 2022''Const c_enumElemType As EnumElementType = EnumElementType.Portrait
        Const bAddFunctionalitySooner As Boolean = False
        Const bAddFunctionalityLater As Boolean = True

        Dim typeOps As Type
        Dim objOperations As Object ''Added 12/29/2021 td 
        Dim objOperationsFieldColumn As Operations_FieldColumn ''Modified 3/13/2022 td 
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
        objOperationsFieldColumn = New Operations_FieldColumn() ''Added 3/13/2022 td
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
            ''3/13/2022 td''If (bAddFunctionalityLater) Then .AddClickability()

            ''Added 2/5/2022 td
            ''3/13/2022 td''.RightclickMouseInfo = objOperationsPortrait ''Added 2/5/2022 td

        End With ''eNd of "With CtlPortrait1"

        ''
        ''Specify the current element to the Operations object. 
        ''
        ''Dim infoOps = CType(objOperations, ICurrentElement) ''.CtlCurrentElement = MoveableControlVB1
        ''infoOps.CtlCurrentElement = CtlFieldColumn1
        ''''Added 1/17/2022 td 
        ''infoOps.ElementsCacheManager = par_parametersGetElementControl.ElementsCacheManager

        ''Added 1/24/2022 thomas d. 
        ''With objOperationsPortrait
        ''    .CtlCurrentControl = CtlFieldColumn1
        ''    .CtlCurrentElement = CtlFieldColumn1
        ''    ''.Designer = par_oMoveEventsForGroupedCtls.
        ''    .Designer = par_parametersGetElementControl.DesignerClass
        ''    .ElementInfo_Base = Nothing ''3/9/2022 t*d*''par_elementPortrait
        ''    .ElementsCacheManager = par_parametersGetElementControl.ElementsCacheManager
        ''    ''Feb3 2022 td''.Element_Type = Enum_ElementType.StaticGraphic
        ''    .Element_Type = Enum_ElementType.Portrait ''Added 2/3/2022 thomas d.
        ''    .EventsForMoveability_Group = par_oMoveEventsForGroupedCtls
        ''    .EventsForMoveability_Single = Nothing
        ''    ''Added 1/24/2022 thomas downes
        ''    .LayoutFunctions = .Designer
        ''End With ''End of "With objOperationsPortrait"

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

        RscSelectCIBField1.Load_FieldsFromCache(par_cache)

        ''
        ''Added 3/15/2022 td
        ''
        RscSelectCIBField1.SelectedValue = Me.ColumnWidthAndData.CIBField

    End Sub ''end of "Public Sub Load_FieldsFromCache"


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


    Private Function ListOfData() As List(Of String)
        ''
        ''Added 3/18/2022 td   
        ''
        Dim objListData As New List(Of String)
        Dim objListOfTextboxes As New List(Of TextBox)
        ''Dim objListOfTextboxes_Ordered ''As New IOrderedEnumerable(Of(Of TextBox)

        For Each eachCtl As Control In Me.Controls
            If (TypeOf eachCtl Is TextBox) Then
                If (eachCtl.Visible) Then
                    objListOfTextboxes.Add(CType(eachCtl, TextBox))
                End If
            End If
        Next eachCtl

        ''
        ''Order them in order of top-down (i.e. the Top property).
        ''
        Dim objListOfTextboxes_Ordered As IOrderedEnumerable(Of TextBox) =
            From objTextbox In objListOfTextboxes
            Select objTextbox
            Order By objTextbox.Top

        For Each each_textbox In objListOfTextboxes_Ordered

            objListData.Add(each_textbox.Text)

        Next each_textbox

        ''
        ''ExitHandler
        ''
        Return objListData

    End Function ''end of Private Function ListOfData() As List(Of String)


    Public Sub SaveDataToColumn()
        ''
        ''Added 3/18/2022 t1h1o1m1a1s1 d1o1w1n1e1s1
        ''
        Dim objFieldColumnControl As RSCFieldColumn

        objFieldColumnControl = Me
        With Me.ColumnWidthAndData

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


End Class
