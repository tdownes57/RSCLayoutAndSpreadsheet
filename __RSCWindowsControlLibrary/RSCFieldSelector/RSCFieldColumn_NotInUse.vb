Option Explicit On
Option Strict On
''
''Added 2/21/2022 thomas downes
''
Imports ciBadgeInterfaces ''Added 8/14/2019 thomas d. 
Imports ciBadgeElements ''Added 9/18/2019 td 
''Imports ciBadgeDesigner ''Added 3/8/2022 td  
''Imports System.Drawing ''Added 10/01/2019 td 
''Imports __RSCWindowsControlLibrary ''Added 1/4/2022 td

Public Class RSCFieldColumn_NotInUse
    ''
    ''Added 2/21/2022 thomas downes  
    ''
    ''Public Shared Function GetFieldColumn(par_parametersGetElementControl As ClassGetElementControlParams,
    ''                                       par_elementPortrait As ClassElementPortrait,
    ''                                   par_formParent As Form,
    ''                                  par_nameOfControl As String,
    ''                                  par_iLayoutFun As ILayoutFunctions,
    ''                                  par_bProportionSizing As Boolean,
    ''                                  par_iControlLastTouched As ILastControlTouched,
    ''                                 par_iRecordLastControl As IRecordElementLastTouched,
    ''                                 par_oMoveEventsForGroupedCtls As GroupMoveEvents_Singleton) As CtlGraphicPortrait
    ''    ''
    ''    ''Added 1/04/2022 td
    ''    ''
    ''    ''Unused. Jan17 2022''Const c_enumElemType As EnumElementType = EnumElementType.Portrait
    ''    Const bAddFunctionalitySooner As Boolean = False
    ''    Const bAddFunctionalityLater As Boolean = True

    ''    Dim typeOps As Type
    ''    Dim objOperations As Object ''Added 12/29/2021 td 
    ''    Dim objOperationsPortrait As Operations_Portrait ''Added 1/04/2022 td 
    ''    Dim sizeElementPortrait As New Size() ''Added 1/26/2022 td

    ''    ''Added 1/5/2022 td
    ''    If (par_elementPortrait Is Nothing) Then Throw New Exception("The Element is missing!")

    ''    ''Instantiate the Operations Object. 
    ''    ''
    ''    ''//If (enumElemType = EnumElementType.Signature) Then objOperations2Use = New Operations__Useless()
    ''    ''//If (enumElemType = EnumElementType.StaticGraphic) Then objOperations1Gen = New Operations__Generic()
    ''    ''//If (enumElemType = EnumElementType.StaticText) Then objOperations2Use = New Operations__Useless()
    ''    ''====If (c_enumElemType = EnumElementType.QRCode) Then objOperationsQR = New Operations_QRCode()

    ''    ''Modified 1/2/2022 td
    ''    objOperationsPortrait = New Operations_Portrait() ''Added 1/1/2022 td
    ''    typeOps = objOperationsPortrait.GetType()
    ''    objOperations = objOperationsPortrait

    ''    If (objOperations Is Nothing) Then
    ''        ''Added 12/29/2021
    ''        Throw New Exception("Ops is Nothing, so I guess Element Type is Undetermined.")
    ''    End If ''end of "If (objOperations Is Nothing) Then"

    ''    ''Added 12/2/2022 td
    ''    Dim enumElementType_Enum As EnumElementType = EnumElementType.Portrait

    ''    ''Create the control. 
    ''    Dim CtlPortrait1 = New CtlGraphicPortrait(par_elementPortrait, par_formParent,
    ''                                              par_iLayoutFun,
    ''                                  par_parametersGetElementControl.iRefreshPreview,
    ''                                              sizeElementPortrait,
    ''                                               par_bProportionSizing,
    ''                                               typeOps, objOperations,
    ''                                               bAddFunctionalitySooner,
    ''                                               bAddFunctionalitySooner,
    ''                                               par_iControlLastTouched,
    ''                                                par_oMoveEventsForGroupedCtls)
    ''    ''Jan2 2022 ''                       ''Jan2 2022 ''par_iSaveToModel, typeOps,

    ''    With CtlPortrait1
    ''        .Name = par_nameOfControl
    ''        ''1/11/2022''If (bAddFunctionalityLater) Then .AddMoveability(par_oMoveEvents, par_iLayoutFun)
    ''        If (bAddFunctionalityLater) Then .AddMoveability(par_iLayoutFun,
    ''                                                         par_oMoveEventsForGroupedCtls, Nothing)
    ''        If (bAddFunctionalityLater) Then .AddClickability()

    ''        ''Added 2/5/2022 td
    ''        .RightclickMouseInfo = objOperationsPortrait ''Added 2/5/2022 td

    ''    End With ''eNd of "With CtlPortrait1"

    ''    ''
    ''    ''Specify the current element to the Operations object. 
    ''    ''
    ''    Dim infoOps = CType(objOperations, ICurrentElement) ''.CtlCurrentElement = MoveableControlVB1
    ''    infoOps.CtlCurrentElement = CtlPortrait1
    ''    ''Added 1/17/2022 td 
    ''    infoOps.ElementsCacheManager = par_parametersGetElementControl.ElementsCacheManager

    ''    ''Added 1/24/2022 thomas d. 
    ''    With objOperationsPortrait

    ''        .CtlCurrentControl = CtlPortrait1
    ''        .CtlCurrentElement = CtlPortrait1
    ''        ''.Designer = par_oMoveEventsForGroupedCtls.
    ''        .Designer = par_parametersGetElementControl.DesignerClass
    ''        .ElementInfo_Base = par_elementPortrait
    ''        .ElementsCacheManager = par_parametersGetElementControl.ElementsCacheManager
    ''        ''Feb3 2022 td''.Element_Type = Enum_ElementType.StaticGraphic
    ''        .Element_Type = Enum_ElementType.Portrait ''Added 2/3/2022 thomas d.
    ''        .EventsForMoveability_Group = par_oMoveEventsForGroupedCtls
    ''        .EventsForMoveability_Single = Nothing
    ''        ''Added 1/24/2022 thomas downes
    ''        .LayoutFunctions = .Designer

    ''    End With ''End of "With objOperationsPortrait"

    ''    Return CtlPortrait1

    ''End Function ''end of "Public Shared Function GetPortrait() As CtlGraphicPortrait"


    ''Public Sub New()

    ''    ' This call is required by the designer.
    ''    InitializeComponent()

    ''End Sub


    ''Public Sub New(par_elementPic As ClassElementPortrait,
    ''               par_oParentForm As Form,
    ''               par_iLayoutFun As ILayoutFunctions,
    ''               par_iRefreshPreview As IRefreshCardPreview,
    ''               par_iSizeDesired As Size,
    ''              pboolResizeProportionally As Boolean,
    ''               par_operationsType As Type,
    ''               par_operationsAny As Object,
    ''               pboolAddMoveability As Boolean,
    ''               pboolAddClickability As Boolean,
    ''               par_iLastTouched As ILastControlTouched,
    ''               par_oMoveEvents As GroupMoveEvents_Singleton)
    ''    ''         ''Not needed. 1/2/2022'' par_iSaveToModel As ISaveToModel,
    ''    ''         ''Not needed. 1/2/2022'' par_enumElementType As EnumElementType,
    ''    ''
    ''    ''Added 1/04/2022 td
    ''    ''
    ''    ''Jan1 2022 td''MyBase.New(par_enumElementType, pboolResizeProportionally,
    ''    MyBase.New(EnumElementType.Portrait, par_oParentForm,
    ''               pboolResizeProportionally,
    ''                    par_iLayoutFun, par_iRefreshPreview, par_iSizeDesired,
    ''                    par_operationsType, par_operationsAny,
    ''                    pboolAddMoveability, pboolAddClickability,
    ''                    par_iLastTouched, par_oMoveEvents,
    ''                    CSng(100 / 150))
    ''    ''          Jan2 2022'' par_iSaveToModel, par_iLayoutFun,

    ''    ' This call is required by the designer.
    ''    InitializeComponent()

    ''    ' Add any initialization after the InitializeComponent() call.

    ''    ''Encapsulated 12/30/2021 td
    ''    New_Portrait(par_elementPic, par_iLayoutFun)

    ''End Sub



    ''Public Sub New_Portrait(par_elementPic As ClassElementPortrait, par_iLayoutFunctions As ILayoutFunctions)
    ''    ''
    ''    ''Added 1/5/2022 & 9/17/2019 td
    ''    ''
    ''    ''9/17/2019 td''Me.ElementInfo_Base = par_infoForPic_Base
    ''    ''9/17/2019 td''Me.ElementInfo_Pic = par_infoForPic_Pic

    ''    Me.ElementClass_Obj = par_elementPic ''par_elementPic
    ''    Me.ElementInfo_Base = CType(par_elementPic, IElement_Base)
    ''    Me.ElementInfo_Pic = CType(par_elementPic, IElementPic)

    ''    ''9/20/2019 td''Me.FormDesigner = par_formLayout ''Added 9/4/2019 td
    ''    Me.LayoutFunctions = par_iLayoutFunctions ''Added 9/4/2019 td

    ''    ''
    ''    ''Added 1/04/2022 thomas downes 
    ''    ''
    ''    ''8/22/2019 td''picturePortrait.Image = ciPictures_VB.PictureExamples.GetImageByIndex(par_infoForPic_Pic.PicFileIndex)

    ''    Dim strErrorMessage As String = "" ''Added 8/22/2019 td

    ''    ''9/17/2019 td''picturePortrait.Image =
    ''    ''   ciPictures_VB.PictureExamples.GetImageByIndex(par_infoForPic_Pic.PicFileIndex, strErrorMessage)

    ''    ''9/23/2019 td''picturePortrait.Image =
    ''    ''    ciPictures_VB.PictureExamples.GetImageByIndex(par_elementPic.PicFileIndex, strErrorMessage)

    ''    ''Added 9/23/2019 thomas d. 
    ''    ''Me.Pic_CloneOfInitialImage = CType(ciPictures_VB.PictureExamples.GetImageByIndex(par_elementPic.PicFileIndex, strErrorMessage).Clone(), Image)
    ''    Dim bUseForegroundImageOfBox As Boolean ''Added 12/7/2021 td 
    ''    Dim bUseBackgroundImageOfBox As Boolean ''Added 12/7/2021 td 

    ''    bUseForegroundImageOfBox = (Me.picturePortrait.Image IsNot Nothing)
    ''    bUseBackgroundImageOfBox = (Me.picturePortrait.BackgroundImage IsNot Nothing)

    ''    ''Not sure this is helpful.---12/7/2021 td''pictureQRCode.Image = CType(Me.Pic_CloneOfInitialImage.Clone(), Image)
    ''    If (bUseForegroundImageOfBox) Then
    ''        ''Try #1 of 2. Let's clone the Foreground Image. 
    ''        Me.Pic_CloneOfInitialImage = CType(Me.picturePortrait.Image.Clone(), Image)
    ''    ElseIf (bUseBackgroundImageOfBox) Then
    ''        ''Try #2 of 2. Let's clone the Background Image. 
    ''        Me.Pic_CloneOfInitialImage = CType(Me.picturePortrait.BackgroundImage.Clone(), Image)
    ''    Else
    ''        ''Added 12/7/2021 td 
    ''        Throw New Exception("We need a way to get the Portrait Image.")
    ''    End If

    ''    If ("" <> strErrorMessage) Then
    ''        ''Added 8/22/2019  
    ''        MessageBox.Show(strErrorMessage, "192939 #4",
    ''                        MessageBoxButtons.OK,
    ''                        MessageBoxIcon.Exclamation)
    ''        Exit Sub
    ''    End If ''End of "If ("" <> strErrorMessage) Then"

    ''    ''
    ''    ''Rotate the image 90 degrees, as many times as needed.  ---8/12/2019 td  
    ''    ''
    ''    ''9/23/2019 td''Me.RefreshImage_NoMajorCalls()
    ''    Me.RefreshImage_ViaElemImage()

    ''End Sub ''End of "Public Sub New"


    Public Sub Load_ResizeWidthability()
        ''
        ''Added 3/2/2022 td
        ''
        ''Add the ability to adjust the size (width only) of the column. 
        ''
        ''March4 2022 ''Dim sizingParams As New MoveAndResizeControls_Monem.StructResizeParams
        Dim sizingParams As New MoveAndResizeControls_Monem.ClassStructResizeParams

        sizingParams.RightEdgeResizing_Only = True

        MyBase.AddSizeability(True, sizingParams)

    End Sub



    Private Sub textboxExample1_TextChanged(sender As Object, e As EventArgs) Handles textboxExample1.TextChanged

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click

    End Sub

    Private Sub PictureBox12_Click(sender As Object, e As EventArgs) Handles PictureBox12.Click

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs) Handles TextBox11.TextChanged

    End Sub

    Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs) Handles TextBox10.TextChanged

    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click

    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click

    End Sub

    Private Sub PictureBox11_Click(sender As Object, e As EventArgs) Handles PictureBox11.Click

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged

    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click

    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click

    End Sub

    Private Sub PictureBox10_Click(sender As Object, e As EventArgs) Handles PictureBox10.Click

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged

    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click

    End Sub

    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click

    End Sub

    Private Sub RSCFieldColumn_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
