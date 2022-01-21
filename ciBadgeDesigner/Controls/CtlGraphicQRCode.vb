Option Explicit On ''Added 7/31/2019 td 
Option Strict On ''Added 7/31/2019 td 

''
''Added 10/10/2019 thomas d 
''
Imports ciBadgeInterfaces ''Added 8/14/2019 thomas d. 
''10/1/2019 td''Imports ciBadgeFields ''Added 9/18/2019 td 
Imports ciBadgeElements ''Added 9/18/2019 td 
Imports System.Windows.Forms ''Added 10/01/2019 td 
Imports System.Drawing ''Added 10/01/2019 td 
Imports __RSCWindowsControlLibrary ''Added 12/30/2021 thomas downes

Public Class CtlGraphicQRCode
    ''See the Partial Class.Dec30 2021''Inherits RSCMoveableControlVB ''Added 12/30/2021 thomas
    Implements ISaveToModel ''Added 12/17/2021 td 
    Implements IClickableElement ''Added 12/17/2021 td
    Implements IMoveableElement ''Added 12/17/2021 td
    ''
    ''Added 10/10/2019 thomas d 
    ''
    ''7/31/2019 td''Public Shared Generator As ClassLabelToImage
    ''7/31/2019 td''Public FieldInfo As ICIBFieldStandardOrCustom
    ''7/31/2019 td''Public ElementInfo As ClassElementPic

    ''---Nov29 2021''Public ElementClass_Obj As ClassElementPic ''Added 9/17/2019 thomas downes
    Public ElementClass_Obj As ClassElementQRCode ''Added 9/17/2019 thomas downes
    ''---Nov29 2021''Public ElementInfo_Pic As IElementPic ''Added 7/31/2019 thomas d 
    Public ElementInfo_QR As IElementQRCode ''Modified 11/29/2021 thomas d 
    Public Overrides Property ElementInfo_Base As IElement_Base ''Added 7/31/2019 thomas d 

    Public Event ElementQR_RightClicked(par_control As CtlGraphicPortrait) ''Added 10/10/2019 td

    ''9/9/2019 td''Public FormDesigner As FormDesignProtoTwo ''Added 9/4/2019 td
    ''9/20/2019 td''Public FormDesigner As ILayoutFunctions ''Modified 9/9/2019 td
    Public LayoutFunctions As ILayoutFunctions ''Modified 9/9/2019 td

    Public Pic_CloneOfInitialImage As Image ''Added 9/23/2019 thomas downes. 


    Public Shared Function GetQRCode(par_parameters As ClassGetElementControlParams,
                                           par_elementQRCode As ClassElementQRCode,
                                        par_formParent As Form,
                        par_nameOfControl As String,
                        par_iLayoutFun As ILayoutFunctions,
                        par_bProportionSizing As Boolean,
                par_iControlLastTouched As ILastControlTouched,
                        par_oMoveEventsGroupedCtls As GroupMoveEvents_Singleton,
                        Optional pbHandleMouseEventsThroughFormVB6 As Boolean = True) As CtlGraphicQRCode
        ''              1/2/2022 td''par_iSaveToModel As ISaveToModel,
        ''
        ''Added 12/29/2021 td
        ''
        Const c_enumElemType As EnumElementType = EnumElementType.QRCode
        Const bAddFunctionalitySooner As Boolean = False
        Const bAddFunctionalityLater As Boolean = True

        Dim typeOps As Type
        Dim objOperations As Object ''Added 12/29/2021 td 
        Dim objOperations1Gen As Operations__Generic = Nothing
        Dim objOperations2Use As Operations__Useless = Nothing
        Dim objOperationsQR As Operations_QRCode ''Added 12/31/2021 td 

        ''Instantiate the Operations Object. 
        ''//If (enumElemType = EnumElementType.Signature) Then objOperations2Use = New Operations__Useless()
        ''//If (enumElemType = EnumElementType.StaticGraphic) Then objOperations1Gen = New Operations__Generic()
        ''//If (enumElemType = EnumElementType.StaticText) Then objOperations2Use = New Operations__Useless()
        ''====If (c_enumElemType = EnumElementType.QRCode) Then objOperationsQR = New Operations_QRCode()

        ''Assign to typeOps. 
        ''If (par_enum = EnumElementType.Field) Then typeOps = objOperations1Gen.GetType()
        ''If (par_enum = EnumElementType.Portrait) Then typeOps = objOperations2Use.GetType()
        ''====If (par_enum = EnumElementType.QRCode) Then typeOps = objOperationsQR.GetType()
        ''If (par_enum = EnumElementType.Signature) Then typeOps = objOperations2Use.GetType()
        ''If (par_enum = EnumElementType.StaticGraphic) Then typeOps = objOperations1Gen.GetType()
        ''If (par_enum = EnumElementType.StaticText) Then typeOps = objOperations2Use.GetType()

        ''Assign to objOperations. 
        ''====If (c_enumElemType = EnumElementType.QRCode) Then objOperations = objOperationsQR
        ''If (par_enum = EnumElementType.Signature) Then objOperations = objOperations2Use
        ''If (par_enum = EnumElementType.StaticGraphic) Then objOperations = objOperations1Gen
        ''If (par_enum = EnumElementType.StaticText) Then objOperations = objOperations2Use

        ''Modified 1/2/2022 td
        objOperationsQR = New Operations_QRCode() ''Added 1/1/2022 td
        typeOps = objOperationsQR.GetType()
        objOperations = objOperationsQR

        If (objOperations Is Nothing) Then
            ''Added 12/29/2021
            Throw New Exception("Ops is Nothing, so I guess Element Type is Undetermined.")
        End If ''end of "If (objOperations Is Nothing) Then"

        ''Added 12/2/2022 td
        Dim enumElementType_Enum As EnumElementType = EnumElementType.QRCode

        ''Create the control. 
        ''Jan2 2022''Dim CtlQRCode1 = New CtlGraphicQRCode(par_elementQRCode, par_iLayoutFun,
        ''Jan2 2022''                        enumElementType_Enum, par_bProportionSizing,
        Dim CtlQRCode1 = New CtlGraphicQRCode(par_elementQRCode, par_formParent,
                                                   par_iLayoutFun,
                                                   par_bProportionSizing,
                                                   typeOps, objOperations,
                                                   bAddFunctionalitySooner,
                                                   bAddFunctionalitySooner,
                                                   par_iControlLastTouched,
                                                    par_oMoveEventsGroupedCtls,
                                                    pbHandleMouseEventsThroughFormVB6)
        ''Jan2 2022 ''                       ''Jan2 2022 ''par_iSaveToModel, typeOps,

        With CtlQRCode1
            .Name = par_nameOfControl
            ''Jan11 2022 td ''If (bAddFunctionalityLater) Then .AddMoveability(par_oMoveEvents, par_iLayoutFun)
            ''Jan11 2022 td ''If (bAddFunctionalityLater) Then .AddClickability()
            If (bAddFunctionalityLater) Then
                .AddMoveability(par_iLayoutFun, par_oMoveEventsGroupedCtls, Nothing)
                .AddClickability()
            End If ''ENd of "If (bAddFunctionalityLater) Then"
        End With ''eNd of "With CtlQRCode1"

        ''
        ''Specify the current element to the Operations object. 
        ''
        Dim infoOps = CType(objOperations, ICurrentElement) ''.CtlCurrentElement = MoveableControlVB1
        infoOps.CtlCurrentElement = CtlQRCode1

        ''Added 1/17/2022 td 
        infoOps.ElementsCacheManager = par_parameters.ElementsCacheManager

        Return CtlQRCode1

    End Function ''end of "Public Shared Function GetQRCode() As CtlGraphicQRCode"


    Public ReadOnly Property Picture_Box As PictureBox
        Get
            ''Added 7/31/2019 td 
            Return Me.pictureQRCode
        End Get
    End Property


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

    End Sub


    Public Sub New(par_elementQR As ClassElementQRCode,
                   par_formParent As Form,
                   par_iLayoutFun As ILayoutFunctions,
                  pboolResizeProportionally As Boolean,
                   par_operationsType As Type,
                   par_operationsAny As Object,
                   pboolAddMoveability As Boolean,
                   pboolAddClickability As Boolean,
                   par_iLastTouched As ILastControlTouched,
                   par_oMoveEvents As GroupMoveEvents_Singleton,
                   Optional pbHandleMouseEventsThroughFormVB6 As Boolean = True)
        ''         ''Not needed. 1/2/2022'' par_iSaveToModel As ISaveToModel,
        ''         ''Not needed. 1/2/2022'' par_enumElementType As EnumElementType,
        ''
        ''Added 12/30/2021 td
        ''
        ''Jan1 2022 td''MyBase.New(par_enumElementType, pboolResizeProportionally,
        MyBase.New(EnumElementType.QRCode,
                   par_formParent,
                    pboolResizeProportionally,
                        par_iLayoutFun,
                        par_operationsType, par_operationsAny,
                        pboolAddMoveability, pboolAddClickability,
                        par_iLastTouched, par_oMoveEvents,
                        CSng(172 / 170),
                        pbHandleMouseEventsThroughFormVB6)
        ''          Jan2 2022'' par_iSaveToModel, par_iLayoutFun,

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ''Encapsulated 12/30/2021 td
        New_QRCode(par_elementQR, par_iLayoutFun)

    End Sub



    Public Sub New_QRCode(par_elementQR As ClassElementQRCode, par_iLayoutFunctions As ILayoutFunctions)
        ''Dec30 2021 td''Public Sub New(par_elementPic As ClassElementPic, par_formLayout As ILayoutFunctions)
        ''Public Sub New(par_elementPic As ClassElementPic, par_formLayout As ILayoutFunctions)
        ''
        ''Added 9/17/2019 td
        ''
        ' This call is required by the designer.
        ''1/4/2022 td''InitializeComponent()

        ''9/17/2019 td''Me.ElementInfo_Base = par_infoForPic_Base
        ''9/17/2019 td''Me.ElementInfo_Pic = par_infoForPic_Pic

        Me.ElementClass_Obj = par_elementQR ''par_elementPic
        Me.ElementInfo_Base = CType(par_elementQR, IElement_Base)
        ''Me.ElementInfo_Pic = CType(par_elementPic, IElementPic)
        Me.ElementInfo_QR = CType(par_elementQR, IElementQRCode)

        ''9/20/2019 td''Me.FormDesigner = par_formLayout ''Added 9/4/2019 td
        Me.LayoutFunctions = par_iLayoutFunctions ''Added 9/4/2019 td

        ''
        ''Added 8/12/2019 thomas downes 
        ''
        ''8/22/2019 td''picturePortrait.Image = ciPictures_VB.PictureExamples.GetImageByIndex(par_infoForPic_Pic.PicFileIndex)

        Dim strErrorMessage As String = "" ''Added 8/22/2019 td

        ''9/17/2019 td''picturePortrait.Image =
        ''   ciPictures_VB.PictureExamples.GetImageByIndex(par_infoForPic_Pic.PicFileIndex, strErrorMessage)

        ''9/23/2019 td''picturePortrait.Image =
        ''    ciPictures_VB.PictureExamples.GetImageByIndex(par_elementPic.PicFileIndex, strErrorMessage)

        ''Added 9/23/2019 thomas d. 
        ''Me.Pic_CloneOfInitialImage = CType(ciPictures_VB.PictureExamples.GetImageByIndex(par_elementPic.PicFileIndex, strErrorMessage).Clone(), Image)
        Dim bUseForegroundImageOfBox As Boolean ''Added 12/7/2021 td 
        Dim bUseBackgroundImageOfBox As Boolean ''Added 12/7/2021 td 

        bUseForegroundImageOfBox = (Me.pictureQRCode.Image IsNot Nothing)
        bUseBackgroundImageOfBox = (Me.pictureQRCode.BackgroundImage IsNot Nothing)

        ''Not sure this is helpful.---12/7/2021 td''pictureQRCode.Image = CType(Me.Pic_CloneOfInitialImage.Clone(), Image)
        If (bUseForegroundImageOfBox) Then
            ''Try #1 of 2. Let's clone the Foreground Image. 
            Me.Pic_CloneOfInitialImage = CType(Me.pictureQRCode.Image.Clone(), Image)
        ElseIf (bUseBackgroundImageOfBox) Then
            ''Try #2 of 2. Let's clone the Background Image. 
            Me.Pic_CloneOfInitialImage = CType(Me.pictureQRCode.BackgroundImage.Clone(), Image)
        Else
            ''Added 12/7/2021 td 
            Throw New Exception("We need a way to get the Image of the QR code.")
        End If

        If ("" <> strErrorMessage) Then
            ''Added 8/22/2019  
            MessageBox.Show(strErrorMessage, "192032 #4",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation)
            Exit Sub
        End If ''End of "If ("" <> strErrorMessage) Then"

        ''
        ''Rotate the image 90 degrees, as many times as needed.  ---8/12/2019 td  
        ''
        ''9/23/2019 td''Me.RefreshImage_NoMajorCalls()
        Me.RefreshImage_ViaElemImage()

    End Sub ''End of "Public Sub New_QRCode(par_elementPic As ClassElementPic, par_formLayout As ILayoutFunctions)"


    Public Sub New_Deprecated(par_infoForQR_Base As IElement_Base,
                              par_infoFor_QR As IElementQRCode,
                              par_formLayout As ILayoutFunctions)
        ''
        ''Added 7/31/2019 td
        ''
        ' This call is required by the designer.
        InitializeComponent()

        ''Me.ElementInfo_Base = par_infoForPic_Base
        Me.ElementInfo_Base = par_infoForQR_Base
        ''Me.ElementInfo_Pic = par_infoForPic_Pic
        Me.ElementInfo_QR = par_infoFor_QR

        ''9/20/2019 td''Me.FormDesigner = par_formLayout ''Added 9/4/2019 td
        Me.LayoutFunctions = par_formLayout ''Added 9/4/2019 td

        ''
        ''Added 8/12/2019 thomas downes 
        ''
        ''8/22/2019 td''picturePortrait.Image = ciPictures_VB.PictureExamples.GetImageByIndex(par_infoForPic_Pic.PicFileIndex)

        Dim strErrorMessage As String = "" ''Added 8/22/2019 td
        ''pictureQRCode.Image =
        ''    ciPictures_VB.PictureExamples.GetImageByIndex(par_infoFor_QR.PicFileIndex, strErrorMessage)

        If ("" <> strErrorMessage) Then
            ''Added 8/22/2019  
            MessageBox.Show(strErrorMessage, "192032 #3",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation)
            Exit Sub
        End If ''End of "If ("" <> strErrorMessage) Then"

        ''
        ''Rotate the image 90 degrees, as many times as needed.  ---8/12/2019 td  
        ''
        ''#1 9/23/2019 td''Me.RefreshImage()
        '' #2 9/23/2019 td''Me.RefreshImage_NoMajorCalls()
        Me.RefreshImage_ViaElemImage()

    End Sub ''End of "Public Sub New_Deprecated(par_infoForPic_Base As IElement_Base, par_infoForPic_Pic As IElementPic, par_formLayout As ILayoutFunctions)"

    Public Sub Refresh_Master()
        ''
        ''Added 9/17 & 9/5/2019 thomas d 
        ''
        Refresh_PositionAndSize()

        ''#1 9/15 td''Refresh_Image
        '' #2 9/15 tdRefresh_Image(False)

        ''#1 9/23/2019 td''Refresh_Image(False)
        '' #2 9/23/2019 td''RefreshImage_NoMajorCalls()
        RefreshImage_ViaElemImage()

    End Sub ''End of "Public Sub Refresh_Master()"

    Public Sub Refresh_PositionAndSize()
        ''
        ''Added 9/17 & 9/5/2019 thomas d 
        ''
        ''9/20/2019 td''Me.Left = Me.FormDesigner.Layout_Margin_Left_Add(Me.ElementInfo_Base.LeftEdge_Pixels)
        ''9/20/2019 td''Me.Top = Me.FormDesigner.Layout_Margin_Top_Add(Me.ElementInfo_Base.TopEdge_Pixels)

        Me.Left = Me.LayoutFunctions.Layout_Margin_Left_Add(Me.ElementInfo_Base.LeftEdge_Pixels)
        Me.Top = Me.LayoutFunctions.Layout_Margin_Top_Add(Me.ElementInfo_Base.TopEdge_Pixels)

        Me.Width = Me.ElementInfo_Base.Width_Pixels
        Me.Height = Me.ElementInfo_Base.Height_Pixels

    End Sub ''End of "Public Sub Refresh_PositionAndSize()"

    Public Sub Refresh_Image_NotInUse(pbRefreshSize As Boolean)
        ''
        ''Added 9/17/2019 thomas d 
        ''



    End Sub ''ENd of "Public Sub Refresh_Image(pbRefreshSize As Boolean)"

    Private Sub DisplayAnotherImage(sender As Object, e As EventArgs)
        ''
        ''Added 8/18/2019 td
        ''
        ''---Me.ElementInfo_Pic.PicFileIndex += 1

        ''8/22/2019 td''picturePortrait.Image = ciPictures_VB.PictureExamples.GetImageByIndex(Me.ElementInfo_Pic.PicFileIndex)

        Dim strErrorMessage As String = ""
        ''pictureQRCode.Image = ciPictures_VB.PictureExamples.GetImageByIndex(Me.ElementInfo_QR.PicFileIndex, strErrorMessage)

        ''Added 9/20/2019 td
        Me.LayoutFunctions.AutoPreview_IfChecked()

        ''Added 8/22/2019 td
        If ("" <> strErrorMessage) Then MessageBox.Show(strErrorMessage, "229124",
                                                        MessageBoxButtons.OK,
                                                        MessageBoxIcon.Exclamation)

    End Sub ''End of "Private Sub DisplayAnotherImage(sender As Object, e As EventArgs)"

    ''7/31/2019 td''Public Sub New_NotInUse(par_field As ICIBFieldStandardOrCustom)
    ''
    ''    ' This call is required by the designer.
    ''    InitializeComponent()
    ''
    ''    ' Add any initialization after the InitializeComponent() call.
    ''    ''7/31/2019 td''Me.FieldInfo = par_field
    ''
    ''    ''7/31/2019 td''Me.ElementInfo = New ClassElementText(Me)
    ''    Me.ElementInfo = New ClassElementPic(Me)
    ''
    ''End Sub

    ''7/31/2019 td'Public Sub New(par_field As ClassFieldStandard)
    ''
    ''    ' This call is required by the designer.
    ''    InitializeComponent()
    ''
    ''    ' Add any initialization after the InitializeComponent() call.
    ''    ''7/31/2019 td'Me.FieldInfo = par_field
    ''
    ''    ''7/31/2019 td''Me.ElementInfo = par_field.ElementInfo
    ''    Me.ElementInfo = New ClassElementPic(Me)
    ''
    ''End Sub

    ''7/31/2019 td'Public Sub New(par_field As ClassFieldCustomized)
    ''
    ''    ' This call is required by the designer.
    ''    InitializeComponent()
    ''
    ''    ' Add any initialization after the InitializeComponent() call.
    ''    Me.FieldInfo = par_field
    ''
    ''    Me.ElementInfo = par_field.ElementInfo
    ''
    ''End Sub

    Public Function FullNameOfMyBaseClass() As String
        ''
        ''Added 1/5/2022 thomas downes
        ''
        ''  Should return "__RSC_WindowsControlLibrary.RSCMoveableControl".
        ''
        Return MyBase.FullNameOfThisBaseClass()

    End Function ''Added Public Function FullNameOfThisBaseClass() As String

    Public Sub RefreshImage_ViaElemImage()
        ''
        ''Refactored 7/25/2019 thomas d 
        ''
        Const c_boolUse_ciBadgeElemImage As Boolean = True
        ''Dim imgPortrait_withRotationIfAny As Image ''Added 9/24/2019 td
        Dim imageQRCode As Image ''Added 11/29/2019 td

        If (c_boolUse_ciBadgeElemImage) Then
            ''
            ''Added 9/23/2019 td 
            ''
            ''--If (TypeOf ElementClass_Obj Is ClassElementPic) Then
            ''Try to pull out the image. 
            ''imgPortrait_withRotationIfAny =
            ''ciBadgeElemImage.modGenerate.PicImage_ByElement(ElementClass_Obj,
            ''                                   Me.Pic_CloneOfInitialImage)
            imageQRCode = Me.pictureQRCode.Image
            ''--End If ''end of "If (TypeOf ElementClass_Obj Is ClassElementPic) Then"

            ''Added 9/24/2019 td
            ''Nov29 2021''pictureQRCode.Image = imgPortrait_withRotationIfAny
            pictureQRCode.Image = imageQRCode

            ''Added 9/24/2019 td
            SwitchControl_WidthAndHeight_Master()

            pictureQRCode.SizeMode = PictureBoxSizeMode.Zoom
            pictureQRCode.Refresh()

        Else
            RefreshImage_NoMajorCalls()

        End If ''end of "If (c_boolUse_ciBadgeElemImage) Then ..... Else ...."

    End Sub ''ENd of "Public Sub RefreshImage_ViaElemImage()"

    Private Sub SwitchControl_WidthAndHeight_Master()
        ''
        ''Added 9/24/2019 td  
        ''
        Dim boolRotatedToLandscape As Boolean
        Static s_Landscape_Prior As Boolean ''Added 9/24/2019 td  

        boolRotatedToLandscape = (90 = (ElementClass_Obj.OrientationInDegrees Mod 180))
        If (boolRotatedToLandscape) Then
            If (s_Landscape_Prior) Then
                ''Fine, no change.
            Else
                SwitchControl_WidthAndHeight_Sub()
                s_Landscape_Prior = True ''Retain for the next call to this procedure. 
            End If
        Else
            If (Not s_Landscape_Prior) Then
                ''Fine, no change. 
            Else
                SwitchControl_WidthAndHeight_Sub()
                s_Landscape_Prior = False ''Retain for the next call to this procedure. 
            End If
        End If ''eNd of "If (boolRotatedToLandscape) Then"

    End Sub ''ENd of "Private Sub SwitchControl_WidthAndHeight_Master()"

    Private Sub SwitchControl_WidthAndHeight_Sub()
        ''
        ''Added 9/24/2019 td  
        ''
        Dim intWidth As Integer
        intWidth = Me.Width
        Me.Width = Me.Height
        Me.Height = intWidth

    End Sub ''ENd of "Private Sub SwitchControl_WidthAndHeight_Sub()"

    Private Sub RefreshImage_NoMajorCalls()
        ''
        ''Added 7/25/2019 thomas d 
        ''
        ''7/31/2019 td'If (String.IsNullOrEmpty(Me.ElementInfo.Text)) Then ElementInfo.Text = LabelText()

        ''7/31/2019 td'If (Me.ElementInfo.Font_DrawingClass Is Nothing) Then 
        ''7/31/2019 td'   Me.ElementInfo.Font_DrawingClass = New Font("Times New Roman", 15, FontStyle.Regular)
        ''7/31/2019 td''End If ''End of "If (Me.ElementInfo.Font_DrawingClass Is Nothing) Then "

        ''7/31/2019 td''If (Generator Is Nothing) Then Generator = New ClassLabelToImage

        ''7/31/2019 td''Generator.TextImage(pictureLabel.Image, Me.ElementInfo, Me.ElementInfo)

        ''
        ''Added 8/7/2019 thomas downes 
        ''
        Dim image_Pic As Image ''Added 8/7/2019 thomas downes 
        ''Dim image_Rotated As Image ''Added 8/7/2019 thomas downes  
        Dim bm_rotation As Bitmap ''Added 8/7/2019 thomas downes 
        Dim boolSeemsInPortraitMode As Boolean
        Dim boolLetsRotate90 As Boolean
        Dim intStarting_Width As Integer ''Added 8/8/2019 thomas 
        Dim intStarting_Height As Integer ''Added 8/8/2019 thomas

        intStarting_Width = pictureQRCode.Width
        intStarting_Height = pictureQRCode.Height

        ''9/2/2019''Select Case Me.ElementInfo_Pic.OrientationToLayout
        Select Case Me.ElementInfo_Base.OrientationToLayout
            Case "H", "L", "P", "", " " '' H = Horizontal, P = Portrait     
                ''
                ''Added 8/7/2019 thomas downes 
                ''
                image_Pic = pictureQRCode.Image
                boolSeemsInPortraitMode = (image_Pic.Height > image_Pic.Width)
                boolLetsRotate90 = True ''boolSeemsInPortraitMode
                boolLetsRotate90 = (Me.ElementInfo_Base.OrientationInDegrees > 0)

                ''Added 8/7/2019 thomas downes 
                If (boolLetsRotate90) Then

                    Dim intRotateIndex As Integer ''Added 8/18/2019 td  

                    For intRotateIndex = 1 To CInt(Me.ElementInfo_Base.OrientationInDegrees / 90)

                        ''Added 8/7/2019 thomas downes 
                        ''8/7 td''image_Rotated = CType(image_Pic.Clone, Image)

                        image_Pic = pictureQRCode.Image
                        bm_rotation = New Bitmap(image_Pic)
                        bm_rotation.RotateFlip(RotateFlipType.Rotate90FlipNone)

                        ''8/7 td''picturePortrait.Image = image_Rotated

                        ''8/7 td''picturePortrait.Width = image_Rotated.Width
                        ''8/7 td''picturePortrait.Height = image_Rotated.Height

                        ''8/8 td''picturePortrait.Width = bm_rotation.Width
                        ''8/8 td''picturePortrait.Height = bm_rotation.Height

                        pictureQRCode.Width = intStarting_Height ''Switching!! Height & Width are switched.
                        pictureQRCode.Height = intStarting_Width ''Switching!! Height & Width are switched.

                        Me.Width = intStarting_Height ''Switching!!  Height & Width are switched. ---8/8/2019 td
                        Me.Height = intStarting_Width ''Switching!!  Height & Width are switched. ---8/8/2019 td 

                        pictureQRCode.Refresh()

                        pictureQRCode.Image = bm_rotation
                        pictureQRCode.SizeMode = PictureBoxSizeMode.Zoom
                        pictureQRCode.Refresh()

                        ''8/7 td''Me.Width = image_Rotated.Width
                        ''8/7 td'' Me.Height = image_Rotated.Height

                        ''8/7 td'' Me.Width = picturePortrait.Width
                        ''8/7 td'' Me.Height = picturePortrait.Height

                    Next intRotateIndex

                End If ''End of "If (boolLetsRotate90) Then"

            Case "n/a" '' "P" ----Anything can be rotated by the program code above.  The operations are exactly the same !!
                ''
                ''Added 8/7/2019 thomas downes 
                ''

        End Select ''End of "Select Case Me.ElementInfo_Pic.OrientationToLayout "

    End Sub ''End of Public Sub RefreshImage_NoMajorCalls

    Public Overrides Sub SaveToModel() Implements ISaveToModel.SaveToModel
        ''
        ''Added 7/31/2019 thomas d 
        ''
        Dim bRotated90degrees As Boolean ''Added 9/24/2019 thomas d. 
        Dim boolSuccess As Boolean ''Added 9/24/2019 td  

        If (Me.ElementInfo_Base IsNot Nothing) Then

            ''9/10/2019 td''Me.ElementInfo_Base.TopEdge_Pixels = Me.Top
            ''9/10/2019 td''Me.ElementInfo_Base.LeftEdge_Pixels = Me.Left

            ''9/20/2019 td''Me.ElementInfo_Base.TopEdge_Pixels = Me.FormDesigner.Layout_Margin_Top_Omit(Me.Top)
            ''Oops, nasty bug!!!  ---9/19/2019 td''Me.ElementInfo_Base.LeftEdge_Pixels = Me.FormDesigner.Layout_Margin_Top_Omit(Me.Left)
            ''9/20/2019 td''Me.ElementInfo_Base.LeftEdge_Pixels = Me.FormDesigner.Layout_Margin_Left_Omit(Me.Left)

            Me.ElementInfo_Base.TopEdge_Pixels = Me.LayoutFunctions.Layout_Margin_Top_Omit(Me.Top)
            Me.ElementInfo_Base.LeftEdge_Pixels = Me.LayoutFunctions.Layout_Margin_Left_Omit(Me.Left)

            ''Added 9/24/2019 td
            ''  Let's avoid violating the Pic's (Height >= Width) constraint, when 
            ''  the Pic has been rotated 90 degrees. 
            Static s_bRotated90degrees As Boolean
            bRotated90degrees = (90 = (Me.ElementInfo_Base.OrientationInDegrees Mod 180))
            If (bRotated90degrees And (Not s_bRotated90degrees)) Then
                ''We don't need to "SaveToModel" just because the Portrait has just been rotated. ---9/24/2019 td 
                s_bRotated90degrees = True ''
                Exit Sub
            Else
                s_bRotated90degrees = bRotated90degrees ''Save for next call to this procedure.  ---9/24 td. 
            End If ''End of ""If (bRotated90degrees And (Not s_bRotated90degrees)) Then .... Else ..."

            If (bRotated90degrees) Then
                ''
                ''Rotation will cause problems if we are not carefull!! 
                ''
                Dim bHeightIsCloseToBaseWidth As Boolean
                bHeightIsCloseToBaseWidth = (Math.Abs(Me.Height - Me.ElementInfo_Base.Width_Pixels) <
                                             Math.Abs(Me.Height - Me.ElementInfo_Base.Height_Pixels))
                If (bHeightIsCloseToBaseWidth And (Me.Width > Me.Height)) Then
                    ''---DIFFICULT & CONFUSING               ----
                    ''---    Rotation Switcheroo   ---9/24 td----
                    Me.ElementInfo_Base.Height_Pixels = Me.Width ''Me.Width vs. Me.Height switcheroo.... confusing but correct!!!!!!!
                    Me.ElementInfo_Base.Width_Pixels = Me.Height ''Me.Width vs. Me.Height switcheroo.... confusing but correct!!!!!!!
                End If ''End of "If (bHeightIsCloseToBaseWidth) Then"

            Else
                Try
                    ''First try-- Set Width first, and then height.  ---9/23/2019 
                    Me.ElementInfo_Base.Width_Pixels = Me.Width
                    Me.ElementInfo_Base.Height_Pixels = Me.Height
                    boolSuccess = True ''Added 9/24/2019 td
                Catch
                    ''An error, related to the constraint of the height always being greater than the width
                    ''  since it's a portrait object, not a landscape object.  ---9/23/2019 td
                    ''
                Finally
                    ''Second try--Set height first, and then width. ----9/23/2019 td 
                    If (Not boolSuccess) Then
                        Me.ElementInfo_Base.Height_Pixels = Me.Height
                        Me.ElementInfo_Base.Width_Pixels = Me.Width
                    End If ''End of "If (Not boolSuccess) Then"
                End Try
            End If ''ENd of "If (bRotated90degrees) Then ..... Else ...."

            ''Added 9/4/2019 td
            ''9/12 td''Me.ElementInfo_Base.LayoutWidth_Pixels = Me.FormDesigner.Layout_Width_Pixels()

            ''9/20/2019 td''Me.ElementInfo_Base.BadgeLayout.Width_Pixels = Me.FormDesigner.Layout_Width_Pixels()
            ''9/20/2019 td''Me.ElementInfo_Base.BadgeLayout.Height_Pixels = Me.FormDesigner.Layout_Height_Pixels()

            Me.ElementInfo_Base.BadgeLayout.Width_Pixels = Me.LayoutFunctions.Layout_Width_Pixels()
            Me.ElementInfo_Base.BadgeLayout.Height_Pixels = Me.LayoutFunctions.Layout_Height_Pixels()

        End If ''End of "If (Me.ElementInfo_Base IsNot Nothing) Then"

    End Sub ''End of Public Sub SaveToModel

    Public Sub Rotate90Degrees(sender As Object, e As EventArgs)
        ''
        ''Added 7/30/2019 thomas downes
        ''  
        ''Me.ElementInfo_Pic.OrientationToLayout = "L"

        ''9/2/2019 td''Select Case Me.ElementInfo_Pic.OrientationToLayout
        Select Case Me.ElementInfo_Base.OrientationToLayout
            Case "", " ", "P"
                Me.ElementInfo_Base.OrientationToLayout = "L"
            Case "L"
                Me.ElementInfo_Base.OrientationToLayout = "P"
            Case Else
                Me.ElementInfo_Base.OrientationToLayout = "P"
        End Select ''End of "Select Case Me.ElementInfo_Base.OrientationToLayout"

        ''Added 8/12/2019 thomas downes 
        ''   Increment by 90 degrees.  
        ''   This will enable the badge to be printed with the element oriented
        ''   correctly (with one out of four choices of orientation). 
        ''
        ''9/2/2019 td''Me.ElementInfo_Pic.OrientationDegrees += 90
        ''9/24/2019 td''  Me.ElementInfo_Base.OrientationInDegrees += 90

        With Me.ElementInfo_Base

            .OrientationInDegrees += 90

            ''Added 9/23/2019 td
            If (360 <= .OrientationInDegrees) Then
                ''Remove 360 degrees (the full circle) from the 
                ''    property value.   We don't want to have to 
                ''    do modulo arithmetic (divide by 360 & get 
                ''    the remainder).  ---9/23/2019 td 
                ''     
                .OrientationInDegrees = (.OrientationInDegrees - 360)
            End If ''End of "If (360 <= .OrientationInDegrees) Then"

        End With ''End of " With Me.ElementInfo_Base"

        ''#1 9/23/2019 td''RefreshImage()
        '' #2 9/23/2019 td''RefreshImage_NoMajorCalls()
        RefreshImage_ViaElemImage()

        Me.Refresh()

        ''Added 9/20/2019 td
        Me.LayoutFunctions.AutoPreview_IfChecked()

    End Sub ''eNd of "Private Sub Rotate90()"

    Public Overrides Function Rotated_90_270() As Boolean
        ''
        ''Added 9/23/2019 thomas d.  
        ''
        ''  This function is the numerical equivalent of, Portrait vs. Landscape.
        ''   (This function purposely _ignores_ the rotational distinction
        ''   between 180 degrees & 360 degrees. ----9/23/2019 td)
        ''
        Dim boolImageRotated_0_180 As Boolean ''Added 9/23/2019 thomas d.  

        Select Case Me.ElementClass_Obj.OrientationInDegrees

            Case 90, 270

                ''Double-check the orientation.  ----9/23/2019 td
                boolImageRotated_0_180 = (Me.pictureQRCode.Image.Width < Me.pictureQRCode.Image.Height)
                If (boolImageRotated_0_180) Then
                    Throw New Exception("Image dimensions are not expected.")
                End If ''End of "If (boolImageRotated_0_180) Then"

                Return True

            Case Else : Return False

        End Select ''ENd of "Select Case Me.ElementClass_Obj.OrientationInDegrees"

    End Function ''End of "Public Function Rotated_90_270() As Boolean"

    Public Overrides Function Rotated_0degrees() As Boolean
        ''
        ''Added 9/23/2019 thomas d.  
        ''
        Dim boolPortraitRotated_0_360 As Boolean ''Added 9/23/2019 thomas d.  
        Dim boolReturnValue As Boolean
        Dim boolRotationExpected As Boolean

        Select Case Me.ElementClass_Obj.OrientationInDegrees

            Case 0, 360

                ''''Double-check the orientation.  ----9/23/2019 td
                ''boolPortraitRotated_90_270 = (Me.picturePortrait.Image.Width >
                ''                           Me.picturePortrait.Image.Height)

                ''If (boolPortraitRotated_90_270) Then
                ''    Throw New Exception("Image dimensions are not expected.")
                ''End If ''End of "If (boolImageRotated_90_270) Then"

                ''Return True

                boolPortraitRotated_0_360 = True

            Case Else '': Return False

                boolPortraitRotated_0_360 = False

        End Select ''ENd of "Select Case Me.ElementClass_Obj.OrientationInDegrees"

ExitHandler:
        boolReturnValue = boolPortraitRotated_0_360

        ''Encapsulated 9/23/2019 td 
        Const c_SemiCircle_Degrees As Integer = 180
        boolRotationExpected = (0 <> Me.ElementClass_Obj.OrientationInDegrees Mod c_SemiCircle_Degrees)
        ClassElementField.CheckWidthVsLength_OfText(Me.pictureQRCode.Image.Width, Me.pictureQRCode.Image.Height, boolRotationExpected)

        Return boolReturnValue

    End Function ''End of "Public Function Rotated_0degrees() As Boolean"

    Public Overrides Function Rotated_180_360() As Boolean
        ''
        ''Added 9/23/2019 thomas d.  
        ''
        ''  This function is the numerical equivalent of, Portrait vs. Landscape.
        ''   (This function purposely _ignores_ the rotational distinction
        ''   between 180 degrees & 360 degrees. ----9/23/2019 td)
        ''
        Dim boolReturnValue As Boolean
        ''Dim boolPortraitRotated_90_270 As Boolean ''Added 9/23/2019 thomas d.  
        Dim boolPortraitRotated_180_360 As Boolean ''Added 9/23/2019 thomas d.  
        Dim boolRotationExpected As Boolean
        Const c_SemiCircle_Degrees As Integer = 180

        boolPortraitRotated_180_360 = (0 = (Me.ElementClass_Obj.OrientationInDegrees Mod c_SemiCircle_Degrees))
        boolReturnValue = boolPortraitRotated_180_360

        ''Double-check the orientation.  ----9/23/2019 td
        ''If (boolReturnValue) Then
        ''    boolPortraitRotated_90_270 = (Me.picturePortrait.Image.Width >
        ''                              Me.picturePortrait.Image.Height)

        ''    If (boolPortraitRotated_90_270) Then
        ''        Throw New Exception("Image dimensions are not expected.")
        ''    End If ''End of "If (boolImageRotated_90_360) Then"
        ''End If ''End of "If (boolReturnValue) Then"

        ''Encapsulated 9/23/2019 td 
        boolRotationExpected = (0 <> Me.ElementClass_Obj.OrientationInDegrees Mod c_SemiCircle_Degrees)
        ClassElementField.CheckWidthVsLength_OfText(Me.pictureQRCode.Image.Width, Me.pictureQRCode.Image.Height, boolRotationExpected)

        Return boolReturnValue

    End Function ''End of "Public Function Rotated_180_360() As Boolean"


    Public Sub DisableRightClickMenu() Implements IClickableElement.DisableRightClickMenu
        ''
        ''Added 12/17/2021 td
        ''
        Throw New NotImplementedException()
    End Sub

    Public Sub EnableRightClickMenu() Implements IClickableElement.EnableRightClickMenu
        ''
        ''Added 12/17/2021 td
        ''
        Throw New NotImplementedException()
    End Sub


    Public Sub EnableDragAndDrop_Moveable() Implements IMoveableElement.EnableDragAndDrop_Moveable
        ''
        ''Added 12/17/2021 td
        ''
        Throw New NotImplementedException()

    End Sub

    Public Sub DisableDragAndDrop_Unmoveable() Implements IMoveableElement.DisableDragAndDrop_Unmoveable
        ''
        ''Added 12/17/2021 td
        ''
        Throw New NotImplementedException()

    End Sub


    Public Function GetPictureBox() As PictureBox Implements IMoveableElement.GetPictureBox

        ''Added 12/17/2021 td  
        Return pictureQRCode

    End Function

    ''Private Sub PictureLabel_MouseClick(sender As Object, e As MouseEventArgs) Handles pictureQRCode.MouseClick, MyBase.MouseClick
    ''
    ''    ''Added 1/3/2022 thomas downes
    ''    ''Not needed. 1/3/2022 td''MyBase.PerformRightClick(e.X + pictureQRCode.Left, e.Y + pictureQRCode.Top)
    ''
    ''End Sub


    Private Sub pictureQRCode_MouseMove(sender As Object, par_e As MouseEventArgs) Handles pictureQRCode.MouseMove '', Me.MouseMove

        ''Added 1/3/2022 thomas downes
        ''Jan11 2022''MyBase.MoveableControl_MouseMove(Me, par_e)
        If mod_bHandleMouseMoveEvents_ByVB6 Then
            If mod_bHandleMouseMoveEvents_ChildClass Then
                ''----Nasty bug.  Don't use par_sender here. ---1/11/2022 td''
                ''--MyBase.MoveableControl_MouseMove(par_sender, par_e)
                Dim objParentControl As Control = Me ''Added 1/11/2022
                MyBase.MoveableControl_MouseMove(objParentControl, par_e)
            End If
        End If

    End Sub

    Private Sub pictureQRCode_MouseDown(sender As Object, par_e As MouseEventArgs) Handles pictureQRCode.MouseDown '', Me.MouseDown
        ''
        ''Added 1/4/2022 td 
        ''
        ''---MyBase.MoveableControl_MouseDown(sender, par_e)
        ''Jan11 2022''MyBase.MoveableControl_MouseDown(Me, par_e)
        If mod_bHandleMouseMoveEvents_ByVB6 Then
            If mod_bHandleMouseMoveEvents_ChildClass Then
                ''----Nasty bug.  Don't use par_sender here. ---1/11/2022 td''
                ''--MyBase.MoveableControl_MouseDown(par_sender, par_e)
                Dim objParentControl As Control = Me ''Added 1/11/2022
                MyBase.MoveableControl_MouseDown(objParentControl, par_e)
            End If
        End If

    End Sub

    Private Sub pictureQRCode_MouseUp(par_sender As Object, par_e As MouseEventArgs) Handles pictureQRCode.MouseUp '', Me.MouseDown
        ''
        ''Added 1/4/2022 td 
        ''
        ''---MyBase.MoveableControl_MouseUp(sender, par_e)
        ''Jan11 2022MyBase.MoveableControl_MouseUp(Me, par_e)
        If mod_bHandleMouseMoveEvents_ByVB6 Then
            If mod_bHandleMouseMoveEvents_ChildClass Then
                ''----Nasty bug.  Don't use par_sender here. ---1/11/2022 td''
                ''--MyBase.MoveableControl_MouseUp(par_sender, par_e)
                Dim objParentControl As Control = Me ''Added 1/11/2022
                ''Jan20 2022 ''MyBase.MoveableControl_MouseUp(objParentControl, par_e)

                Const c_bOptimizeProgramCode As Boolean = True ''Added 1/20/2022 td
                Const c_bTestingSoMarkOriginViaMouseButtons As Boolean = True ''Added 1/20/2022 td

                If (c_bOptimizeProgramCode) Then
                    ''----Nasty bug.  Don't use par_sender here. ---1/11/2022 td''
                    ''--MyBase.MoveableControl_MouseUp(par_sender, par_e)
                    MyBase.MoveableControl_MouseUp(objParentControl, par_e)

                ElseIf (c_bTestingSoMarkOriginViaMouseButtons) Then

                    ''Added 1/20/2022 td 
                    ''   For testing only!!!!  Use enumerated value "MouseButtons.Middle" as a marker,
                    ''   to indicate that this event was handled by the child class.
                    ''    ---1/20/2022 td 
                    Dim objMouseEventArgs As MouseEventArgs ''Added 1/20/2022 td
                    objMouseEventArgs = New MouseEventArgs(MouseButtons.Middle, par_e.Clicks,
                                                          par_e.X, par_e.Y, par_e.Delta)
                    MyBase.MoveableControl_MouseUp(objParentControl, objMouseEventArgs)

                End If ''end if "If (c_bOptimizeProgramCode) Then ... ElseIf ..."


            End If
        End If

    End Sub


    Public Overrides Sub RemoveMouseEventHandlers_ChildClass()
        ''
        ''Added 1/12/2022 
        ''
        RemoveHandler pictureQRCode.MouseDown, AddressOf pictureQRCode_MouseDown
        RemoveHandler pictureQRCode.MouseMove, AddressOf pictureQRCode_MouseMove
        RemoveHandler pictureQRCode.MouseUp, AddressOf pictureQRCode_MouseUp

    End Sub ''End of "Public Overrides Sub RemoveMouseEventHandlers()"


    Public Overrides Sub AddMouseEventHandlers_ChildClass()
        ''
        ''Added 1/12/2022 
        ''
        RemoveHandler pictureQRCode.MouseDown, AddressOf pictureQRCode_MouseDown
        RemoveHandler pictureQRCode.MouseMove, AddressOf pictureQRCode_MouseMove
        RemoveHandler pictureQRCode.MouseUp, AddressOf pictureQRCode_MouseUp

        AddHandler pictureQRCode.MouseDown, AddressOf pictureQRCode_MouseDown
        AddHandler pictureQRCode.MouseMove, AddressOf pictureQRCode_MouseMove
        AddHandler pictureQRCode.MouseUp, AddressOf pictureQRCode_MouseUp

    End Sub ''End of "Public Overrides Sub AddMouseEventHandlers()"


End Class ''End of Public Class CtlGraphicQRCode 

