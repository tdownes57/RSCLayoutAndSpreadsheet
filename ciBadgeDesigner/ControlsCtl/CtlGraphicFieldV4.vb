''Public Class CtlGraphicFieldV4

''
''Added 1/31/2022 td
''
Option Explicit On ''Added 8/29/2019 td
Option Strict On ''Added 8/29/2019 td
Option Infer Off ''Added 8/29/2019 td  

Imports ciBadgeInterfaces
Imports ciBadgeElements ''Added 9/18/2019 td 
Imports ciBadgeElemImage ''Added 9/20/2019 td 
''Imports System.Windows.Forms ''Added 10/1/2019 td
Imports System.Drawing ''Added 10/1/2019 td  
Imports __RSCWindowsControlLibrary ''Added 1/4/2022 thomas d.


Public Class CtlGraphicFieldV4
    Implements ISaveToModel ''Added 12/17/2021 td 
    Implements IRefreshElementImage ''Added 6/6/2022 td
    Implements IMoveableElement ''Added 12/17/2021 td
    Implements IClickableElement ''Added 12/17/2021 td  
    ''
    ''Added 2/03/2022 td
    ''
    Public Element_FieldV4 As ciBadgeElements.ClassElementFieldV4
    Private Shared mod_intFieldTexts As Integer ''Feb01 2022 td'' += 1
    Private Shared mod_intFields As Integer ''Feb01 2022 td'' += 1

    Public Overloads Property ElementClass_ObjV4 As ClassElementFieldV4 ''Added 2/4/2022 thomas downes


    Public ReadOnly Property Textbox_ExampleValue As TextBox
        Get
            ''Added 10/17/2019 td 
            Return Me.textTypeExample
        End Get
    End Property


    Public Shared Function GetFieldControl(par_elementField As ClassElementFieldV4,
                                           par_formParent As Form,
                                           par_oDesigner As ClassDesigner,
                                           par_nameOfControl As String,
                                           par_sizeNeeded As Size) As CtlGraphicFieldV4
        ''
        ''Added 3/21/2022 thomas downes
        ''
        Dim objParametersGetElementCtl As ClassGetElementControlParams
        objParametersGetElementCtl = par_oDesigner.GetParametersToGetElementControl()

        Return GetFieldControl(objParametersGetElementCtl,
                               par_elementField,
                               par_formParent,
                               par_oDesigner,
                               par_nameOfControl,
                            CType(par_oDesigner, ILayoutFunctions),
                            par_sizeNeeded,
                            CType(par_oDesigner, IRecordElementLastTouched),
                            CType(par_oDesigner.ControlLastTouched, ILastControlTouched),
                            par_oDesigner.GroupMoveEvents)

    End Function ''End of "Public Shared Function GetFieldControl"


    Public Shared Function GetFieldControl(par_parametersGetElementControl As ClassGetElementControlParams,
                                           par_elementField As ClassElementFieldV4,
                                           par_formParent As Form,
                                           par_oDesigner As ClassDesigner,
                                      par_nameOfControl As String,
                                      par_iLayoutFun As ILayoutFunctions,
                                           par_sizeNeeded As Size,
                                par_iRecordLastTouched As IRecordElementLastTouched,
                                par_iControlLastTouched As ILastControlTouched,
                                par_oMoveEventsForGroupedCtls As GroupMoveEvents_Singleton) As CtlGraphicFieldV4
        ''
        ''Added 1/31/2021 td
        ''
        ''//Const c_enumElemType As EnumElementType = EnumElementType.Field
        Const bAddFunctionalitySooner As Boolean = False
        Const bAddFunctionalityLater As Boolean = True

        Dim typeOps As Type
        Dim objOperations As Object ''Added 12/29/2021 td 
        Dim objOperationsField_V4 As Operations_FieldV4
        Dim sizeFieldElement As Size ''Added 1/26/2022 td

        ''Instantiate the Operations Object. 
        objOperationsField_V4 = New Operations_FieldV4() ''Added 1/31/2022 td
        typeOps = objOperationsField_V4.GetType()
        objOperations = objOperationsField_V4

        If (objOperations Is Nothing) Then
            ''Added 12/29/2021
            Throw New Exception("Ops is Nothing, so I guess Element Type is Undetermined.")
        End If ''end of "If (objOperations Is Nothing) Then"

        ''Added 12/2/2022 td
        Dim enumElementType_Enum As EnumElementType = EnumElementType.Field

        ''Create the control.
        Dim CtlFieldV4 As CtlGraphicFieldV4

        ''Public Sub New(par_elementField As ClassElementField,
        ''                par_layout As ILayoutFunctions,
        ''                pstrWhyWasICreated As String,
        ''                par_formRecordLastTouched As IRecordElementLastTouched)

        CtlFieldV4 = New CtlGraphicFieldV4(par_elementField,
                                           par_parametersGetElementControl,
                                               par_formParent,
                                               par_oDesigner, par_iLayoutFun,
                                         par_parametersGetElementControl.iRefreshPreview,
                                               par_sizeNeeded,
                                                   "Called by GetFieldElement.",
                                                   typeOps, objOperations,
                                                   bAddFunctionalitySooner,
                                                   bAddFunctionalitySooner,
                                                   par_iRecordLastTouched,
                                                   par_iControlLastTouched,
                                                    par_oMoveEventsForGroupedCtls)
        ''Jan2 2022 ''                       ''Jan2 2022 ''par_iSaveToModel, typeOps,

        With CtlFieldV4
            .Name = par_nameOfControl
            ''Jan11 2022''If (bAddFunctionalityLater) Then .AddMoveability(par_oMoveEvents, par_iLayoutFun)
            If (bAddFunctionalityLater) Then .AddMoveability(par_iLayoutFun,
                                                             par_oMoveEventsForGroupedCtls, Nothing)
            If (bAddFunctionalityLater) Then .AddClickability()

            ''Added 2/5/2022 td
            .RightclickMouseInfo = objOperationsField_V4 ''Added 2/5/2022 td

        End With ''eNd of "With CtlQRCode1"

        ''
        ''Specify the current element to the Operations object. 
        ''
        Dim infoOps As ICurrentElement = CType(objOperations, ICurrentElement)
        infoOps.CtlCurrentElement = CtlFieldV4

        ''Added 1/17/2022 td 
        infoOps.ElementsCacheManager = par_parametersGetElementControl.ElementsCacheManager

        ''Added 1/24/2022 thomas d. 
        With objOperationsField_V4

            .CtlCurrentForm = par_formParent ''Added 5/6/2022 td 
            .CtlCurrentControl = CtlFieldV4
            .CtlCurrentElement = CtlFieldV4
            .CtlCurrentFieldOrTextV4 = CtlFieldV4 ''Added 2/3/2022 td
            .CtlCurrentElementFieldV4 = CtlFieldV4 ''Added 1/24/2022 td

            ''.Designer = par_oMoveEventsForGroupedCtls.
            .Designer = par_parametersGetElementControl.DesignerClass
            .ElementInfo_Base = par_elementField
            .ElementInfo_TextOnly = par_elementField ''Added 2/2/2022 td

            .ElementsCacheManager = par_parametersGetElementControl.ElementsCacheManager

            ''#1 2/1/2022 ''.Element_Type = Enum_ElementType.StaticGraphic
            ''#2 2/1/2022 ''.Element_Type = Enum_ElementType.FieldV3
            .Element_Type = Enum_ElementType.Field

            .EventsForMoveability_Group = par_oMoveEventsForGroupedCtls
            .EventsForMoveability_Single = Nothing
            .LayoutFunctions = .Designer ''Added 1/24/2022 td

            ''Added 2/2/2022 td
            .ElementFieldV4 = CtlFieldV4.Element_FieldV4

            ''Added 2/3/2022 td
            .SelectingElements = par_parametersGetElementControl.DesignerClass ''Added 2/3/2022 td

            ''Added 5/10/2022  
            .InfoRefresh = par_parametersGetElementControl.iRefreshPreview

            ''Added 5/29/2022
            .CacheOfFieldsEtc_Deprecated = par_parametersGetElementControl.ElementsCache

        End With ''End of "With objOperationsFld_V4"

        Return CtlFieldV4

    End Function ''end of "Public Shared Function GetFieldControl() As CtlGraphicFieldV4"


    Public Sub New()

        ''Added 2/01/2022 td
        MyBase.New()

        ' This call is required by the designer.
        InitializeComponent()

    End Sub


    Public Sub New(pstrWhyCreated As String)

        ''Added 1/31/2022 td
        MyBase.New(pstrWhyCreated)

        ' This call is required by the designer.
        InitializeComponent()

    End Sub


    Public Sub New(par_elementField As ClassElementFieldV4,
                   par_parameters As IGetElementControlParameters,
                   par_oParentForm As Form,
                   par_oDesigner As ClassDesigner,
                   par_iLayoutFun As ILayoutFunctions,
                   par_iRefreshPreview As IRefreshCardPreview,
                   par_iSizeDesired As Size,
                   pstrWhyWasICreated As String,
                   par_operationsType As Type,
                   par_operationsAny As Object,
                   pboolAddMoveability As Boolean,
                   pboolAddClickability As Boolean,
                   par_iRecordLastTouched As IRecordElementLastTouched,
                   par_iLastTouched As ILastControlTouched,
                   par_oMoveEvents As GroupMoveEvents_Singleton,
                   Optional par_singleDummy As Single = 0)
        ''Jan4 2022'' par_formRecordLastTouched As IRecordElementLastTouched,

        ''Dim singleDummy As Single = 0 ''Added 1/4/2022 td 

        ''Added 1/4/2022 td
        MyBase.New(EnumElementType.Field, par_parameters,
                        par_elementField,
                        par_oParentForm,
                        par_oDesigner,
                        par_iLayoutFun, par_iRefreshPreview, par_iSizeDesired,
                        pstrWhyWasICreated,
                par_operationsType, par_operationsAny,
                        pboolAddMoveability, pboolAddClickability,
                        par_iRecordLastTouched,
                        par_iLastTouched, par_oMoveEvents,
                        par_singleDummy)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ''Jan31 2022 td''Me.FieldInfo = par_elementField.FieldInfo
        Me.ParentDesigner = par_oDesigner ''Added 1/5/2022 td

        Me.ElementClass_ObjV4 = par_elementField
        Me.ElementInfo_Base = CType(par_elementField, IElement_Base)
        ''10/12/2019 td''Me.ElementInfo_Text = CType(par_elementField, IElement_TextField)
        Me.ElementInfo_TextOnly = CType(par_elementField, IElement_TextOnly) ''Modified 10/12/2019 td
        ''1/2/2022 td''Me.ElementInfo_Field = CType(par_elementField, IElement_TextField) ''Added 10/12/2019 td
        Me.Element_FieldV4 = par_elementField ''Added 2/2/2022 thomas d. 

        Try
            Me.ElementInfo_TextField = CType(par_elementField, IElement_TextField) ''Added 10/12/2019 td
            mod_intFieldTexts += 1
        Catch
            mod_intFields += 1
        End Try

        Me.LayoutFunctions = par_iLayoutFun
        Me.LayoutFunctions = par_iLayoutFun

        ''Added 9/20/2019 td 
        ''   Add an alert to the user that the element is not rendered
        ''   on the Badge.  ----9/20/2019 td 
        Dim bElementInvisibleOnBadge As Boolean
        bElementInvisibleOnBadge = (Not Me.ElementInfo_Base.Visible)
        LinkMessageFYI.Visible = bElementInvisibleOnBadge

        ''Added 11/28/2021 thomas d.
        WhyWasICreated = pstrWhyWasICreated

        ''Added 12/17/2021 td
        mod_formRecordLastTouched = par_iRecordLastTouched

        ''Added 5/27/2022 thomas downes
        ''Per https://stackoverflow.com/questions/3774248/make-the-background-of-a-label-or-linklabel-transparent
        '' ---5/27/2022 td
        LinkLabelConditional.BackColor = Color.Transparent
        Try
            MyBase.LinkLabelConditional.Parent = pictureFieldOrText
            MyBase.LinkLabelConditional.BringToFront()
        Catch
        End Try

    End Sub ''ENd of "Public Sub New "


    Public Overrides Sub RefreshElementImage(Optional pbAfterResizingHeight As Boolean = False) Implements IRefreshElementImage.RefreshElementImage
        ''
        ''Added 6/6/2022 td
        ''
        ''
        ''Added 6/6/2022 td
        ''
        Dim boolSuppressPrompt As Boolean ''Added 6/6/2022
        ''Added 6/6/2022
        ''6/06/2022 td''boolSuppressPrompt = (Not pbAfterResizingEvent)
        boolSuppressPrompt = (Not pbAfterResizingHeight)

        ''6/6/2022 Refresh_ImageV3(True)
        If (boolSuppressPrompt) Then

            ''The user will not be prompted to scale the font. The font won't be resized. ---6/6/2022 td
            Refresh_ImageV4(True, , , , , boolSuppressPrompt)

        Else
            ''
            ''Ask/prompt the user, asking "Do you want to resize the font?"  ---6/6/2022
            ''
            ''Confusing.... two(2) calls instead of one!
            ''
            Refresh_ImageV4(True) ''Initially, refresh without prompting & w/ suppression of auto-sizing. This
            ''   will allow the border to be redrawn, especially needed if the user has enlarged the element. 
            Refresh_ImageV4(True, , , , , boolSuppressPrompt)  ''Next, check w/ user if they want to re-size the font.

        End If ''End of ""If (boolSuppressPrompt) Then.... Else....""

    End Sub ''End of ""Public Overrides Sub RefreshElementImage()""

    Public Overrides Sub Refresh_ImageV3(pbRefreshSize As Boolean,
                             Optional pboolResizeLabelControl As Boolean = True,
                             Optional pboolRefreshLabelControl As Boolean = True,
                             Optional pboolRefreshUserControl As Boolean = False,
                             Optional pobjElementField As ClassElementFieldV3 = Nothing,
                              Optional pbSuppressFontScalingConfirmation As Boolean = True)
        ''
        ''Added 2/01/2022 thomas d. 
        ''
        ''6/2/2022  Refresh_ImageV4(pbRefreshSize,
        ''                pboolResizeLabelControl,
        ''                pboolRefreshLabelControl,
        ''                pboolRefreshUserControl)
        Refresh_ImageV4(pbRefreshSize,
                        pboolResizeLabelControl,
                        pboolRefreshLabelControl,
                        pboolRefreshUserControl,
                        Nothing,
                        pbSuppressFontScalingConfirmation)

    End Sub ''End of "Public Overrides Sub Refresh_ImageV4(....)"


    Public Overrides Sub Refresh_ImageV4(pbRefreshSize As Boolean,
                             Optional pboolResizeLabelControl As Boolean = True,
                             Optional pboolRefreshLabelControl As Boolean = True,
                             Optional pboolRefreshUserControl As Boolean = False,
                             Optional pobjElementField As ClassElementFieldV4 = Nothing,
                             Optional pbSuppressFontScalingConfirmation As Boolean = True)
        ''Feb1 2022 td''Public Overrides Sub Refresh_ImageV3(pbRefreshSize As Boolean,
        ''
        ''Added 2/1/2022 & 7/25/2019 thomas d 
        ''
        ''7/29 td''Me.ElementInfo.Info = CType(Me.ElementInfo, IElementText)

        ''Me.ElementInfo.Text = Me.LabelText(
        ''8/4/2019''If (String.IsNullOrEmpty(Me.ElementInfo.Text)) Then ElementInfo.Text = LabelText()

        ''6/2/2022 Dim boolScaleFontSize As Boolean ''Added 9/15/2019 thomas d. 
        Dim bScaleFontToSizeOfElement As Boolean ''Added 9/15/2019 thomas d. 

        ''Added 1/5/2022 td
        Dim info_TextOnly As IElement_TextOnly ''Added 1/5/2022 

        info_TextOnly = Me.ElementInfo_TextOnly ''Added 1/5/2022
        ''-----If (info_TextOnly Is Nothing) Then info_TextOnly = 

        ''1/5/2022 td''ElementInfo_TextOnly.Text_Static = LabelText()
        ''Not needed. 2/1/2022 td''ElementInfo_TextOnly.Text_Static = LabelText(pobjElementField)

        ''Added 2/1/2022 thomas downes
        Dim strTextToDisplay As String ''Added 2/1/2022 thomas downes
        strTextToDisplay = ElementInfo_TextOnly.Text_StaticLine

        ''Me.ElementInfo.Width = pictureFieldOrText.Width
        ''Me.ElementInfo.Height = pictureFieldOrText.Height

        ''7/30/2019 td''Me.ElementInfo.Font_DrawingClass = Me.ParentForm.Font ''Me.Font
        ''7/30/2019 td''Me.ElementInfo.Font_DrawingClass = New Font("Times New Roman", 25, FontStyle.Italic)

        ''6/02/2022 boolScaleFontSize = (Me.ElementInfo_TextOnly.FontSize_AutoScaleToElementYesNo)
        ''Added 6/2/2022
        With Me.ElementInfo_TextOnly
            ''6/02/2022 boolScaleFontSize = (.FontSize_AutoScaleToElementYesNo)
            bScaleFontToSizeOfElement = (Not pbSuppressFontScalingConfirmation) AndAlso
                                  (.FontSize_AutoScaleToElementYesNo) AndAlso
                                 ((Not .FontSize_AutoSizePromptUser) OrElse
                          MessageBoxTD.Show_Confirm("Resize the font of text?"))
        End With ''ENd of ""With Me.ElementInfo_TextOnly""

        If (bScaleFontToSizeOfElement And Me.ElementClass_ObjV4 Is Nothing) Then
            ''Added 9/19/2019 td 
            MessageBox.Show("Where is the Element-Field Class???   We will need it to scale the Font.", "",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If ''End of "If (boolScaleFontSize) Then"

        ''6/7/2022 If (Me.ElementInfo_TextOnly.FontDrawingClass Is Nothing) Then
        If (Me.ElementInfo_TextOnly.FontFamilyName Is Nothing OrElse
            Me.ElementInfo_TextOnly.FontMaxGalkin Is Nothing) Then
            ''
            ''Initialize the font. 
            ''
            ''9/6/2019 tdMe.ElementInfo_Text.Font_DrawingClass = New Font("Times New Roman", 15, FontStyle.Regular)

            With Me.ElementInfo_TextOnly
                ''9/6/2019 td''.FontSize = 15
                ''.FontSize_Pixels = 25 ''9/6/2019 ''15
                ''.FontBold = False
                ''.FontItalics = False
                ''.FontUnderline = False ''Added 9/6/2019 thomas downes
                ''.FontFamilyName = "Times New Roman"
                ''''9/6/2019 td''.Font_DrawingClass = New Font(.FontFamilyName, .FontSize_Pixels, FontStyle.Regular, GraphicsUnit.Pixel)
                ''.Font_DrawingClass = modFonts.MakeFont(.FontFamilyName, .FontSize_Pixels, .FontBold, .FontItalics, .FontUnderline)

                ''Added 6/7/2022 td 
                .FontMaxGalkin = ciBadgeSerialize.SerializableFontByMaxGalkin.DefaultFont()
                .FontDrawingClass = .FontMaxGalkin.GetDrawingFont()
                .FontFamilyName = .FontMaxGalkin.FontFamily
                .FontSize_Pixels = .FontMaxGalkin.Size_Pixels
                .FontBold_Deprecated = (.FontMaxGalkin.Style = FontStyle.Bold)
                .FontUnderline_Deprecated = (.FontMaxGalkin.Style = FontStyle.Underline)
                .FontItalics_Deprecated = (.FontMaxGalkin.Style = FontStyle.Italic)

                ''Added 11/24/2021 thomas d. 
                If (0 = .FontSize_AutoScaleToElementRatio) Then
                    ''Added 11/24/2021 thomas d. 
                    .FontSize_AutoScaleToElementRatio = 0.8
                End If ''End of "If (0 = FontSize_ScaleToElementRatio) Then"

            End With

        End If ''end of " If (Me.ElementInfo.Font_DrawingClass Is Nothing) Then"

        ''Me.ElementInfo.BackColor = Me.ParentForm.BackColor
        ''Me.ElementInfo.FontColor = Me.ParentForm.ForeColor



        ''Added 8/18/2019 thomas downes 
        If (pbRefreshSize) Then
            ''
            ''Adjust the size of the label graphic. 
            ''
            pictureFieldOrText.Width = Me.ElementInfo_Base.Width_Pixels
            pictureFieldOrText.Height = Me.ElementInfo_Base.Height_Pixels

            ''Added 9/15/2019 thomas d.
            ''June2 2022 boolScaleFontSize = (Me.ElementInfo_TextOnly.FontSize_AutoScaleToElementYesNo)
            With Me.ElementInfo_TextOnly
                ''June2 2022 boolScaleFontSize = (.FontSize_ScaleToElementYesNo)
                bScaleFontToSizeOfElement = ((Not pbSuppressFontScalingConfirmation) Or
                                                 .FontSize_Pixels = 0) AndAlso
                                    (.FontSize_AutoScaleToElementYesNo) AndAlso
                                     ((Not .FontSize_AutoSizePromptUser) OrElse
                                    MessageBoxTD.Show_Confirm("Resize the font of text?"))
            End With ''End of ""With Me.ElementInfo_TextOnly""

            ''June2 2022''If (boolScaleFontSize) Then
            If (bScaleFontToSizeOfElement) Then
                ''Added 9/15/2019 thomas d.
                ''Jan28 2022''Me.ElementClass_Obj.Font_ScaleAdjustment(Me.ElementInfo_Base.Height_Pixels)
                ''Added 9/15/2019 thomas d.
                With Me.ElementInfo_Base ''Added 1/28/2022 td
                    ''2/2/2022 td ''If (Rotated_90_270(False) Or (.Width_Pixels < .Height_Pixels)) Then ''Added 1/28/2022 td
                    If (.Width_Pixels < .Height_Pixels) Then ''Modified 1/28/2022 td

                        ''Use .Width_Pixels, since .Height_Pixels & .Width_Pixels
                        ''   have been switched due to rotation. ----1/28/2022 td
                        Me.ElementClass_ObjV4.Font_AutoScaleAdjustment(.Width_Pixels)
                    Else
                        Me.ElementClass_ObjV4.Font_AutoScaleAdjustment(.Height_Pixels)
                    End If ''End of "If (Rotated_90_270()) Then ... Else ..."
                End With ''End of "With Me.ElementInfo_Base"
            End If ''End of "If (boolScaleFontSize) Then"

        End If ''end if "If (pbRefreshSize) then"

        If (LabelToImage Is Nothing) Then LabelToImage = New ClassLabelToImage

        ''
        ''Added 7/31/2019 thomas 
        ''
        Dim boolReinitializeImage As Boolean ''Added 7/31/2019 thomas
        Const c_bMustReinitializeToResize As Boolean = True ''Added 7/31/2019 thomas
        boolReinitializeImage = (c_bMustReinitializeToResize And MyBase.mod_c_bRefreshMustResizeImage)

        If (boolReinitializeImage) Then
            ''
            ''Destroy & recreate the .Image member from scratch, to allow for a new size. ----7/31/2019 td
            ''
            pictureFieldOrText.Image = Nothing

            If (pictureFieldOrText.Width > 0 And pictureFieldOrText.Height > 0) Then
                pictureFieldOrText.Image = (New Bitmap(pictureFieldOrText.Width, pictureFieldOrText.Height))
            ElseIf (pictureFieldOrText.Width > 0 And pictureFieldOrText.Height = 0) Then
                ''Don't allow a run-time error to occur, due to a parameter of Height = Zero (0). ----8/3/2019 td
                pictureFieldOrText.Image = (New Bitmap(pictureFieldOrText.Width, 15))
            ElseIf (pictureFieldOrText.Width = 0 And pictureFieldOrText.Height > 0) Then
                ''Don't allow a run-time error to occur, due to a parameter of Width = Zero (0).  ----8/3/2019 td
                pictureFieldOrText.Image = (New Bitmap(15, pictureFieldOrText.Height))
            End If

        End If ''End of "If (boolReinitializeImage) Then"

        ''7/29/2019 td''pictureFieldOrText.Image = Generator.TextImage(Me.ElementInfo, Me.ElementInfo)
        ''8/18/2019 td''Generator.TextImage(pictureFieldOrText.Image, Me.ElementInfo, Me.ElementInfo)

        Dim boolRotated As Boolean ''Added 8/18/2019 td

        ''Added 8/18/2019 td
        ''9/3/2019 td''LabelToImage.TextImage(pictureFieldOrText.Image, Me.ElementInfo_Text, Me.ElementInfo_Base, boolRotated)

        Dim intBadgeLayoutWidth As Integer ''Added 9/3/2019 thomas d.
        ''9/19/2019 td''intLayoutWidth = Me.FormDesigner.Layout_Width_Pixels()
        intBadgeLayoutWidth = Me.LayoutFunctions.Layout_Width_Pixels()

        ''9/4/2019 td''LabelToImage.TextImage(intLayoutWidth, pictureFieldOrText.Image, Me.ElementInfo_Text, Me.ElementInfo_Base, boolRotated)

        ''
        ''Major call !!
        ''
        Dim newTextImage As Image ''Added 9/20/2019 td  

        Const c_boolUseNewestProjectReference As Boolean = True ''Added 9/20/2019 td 
        If (c_boolUseNewestProjectReference) Then

            ''Added 5/12/2022 td
            Dim objFieldAny As ciBadgeFields.ClassFieldAny ''Added 5/12/2022 td
            objFieldAny = ElementsCache.GetFieldByFieldEnum(Me.ElementClass_ObjV4.FieldEnum)
            strTextToDisplay = objFieldAny.FieldLabelCaption

            ''Added 11-18-2019 td 
            ''Moved to the top. 2/1/2022 td''Dim strTextToDisplay As String ''Added 11/18/2019 td
            ''Feb1 2022 td''strTextToDisplay = Me.ElementClass_Obj.LabelText_ToDisplay(True, Nothing,
            ''Feb1 2022 td''     CtlGraphicFldLabelV3.UseExampleValues)

            ''Added 12/21/2021 td
            strTextToDisplay = (strTextToDisplay & (" " & Me.ElementClass_ObjV4.CaptionSuffixIfNeeded).TrimEnd())

            ''11/18 td''newTextImage =
            ''   modGenerate.TextImage_ByElemInfo(Me.ElementClass_Obj.LabelText_ToDisplay(True),
            newTextImage =
                 modGenerate.TextImage_ByElemInfo(strTextToDisplay,
                                             intBadgeLayoutWidth,
                                   Me.ElementInfo_TextOnly,
                                   Me.ElementInfo_Base,
                                   boolRotated, True)
        Else
            ''9/20/2019 td''pictureFieldOrText.Image =
            newTextImage =
            LabelToImage.TextImage_Field(intBadgeLayoutWidth, Me.ElementInfo_TextOnly,
                                   Me.ElementInfo_Base,
                                   boolRotated, True)
        End If ''End of "If (c_boolUseNewestProjectReference) Then ..... Else ...."

        ''Added 9/20/2019 td
        pictureFieldOrText.Image = newTextImage

        ''Added 9/23/2019 td
        Application.DoEvents() ''Give the PictureBox control time to make any adjustments it might want to do. 

ExitHandler:
        If (pboolResizeLabelControl) Then ''Added9/23/2019 td 

            ''Added 8/18/2019 td
            Dim intNewImageWidth As Integer ''Added 8/18/2019 td
            Dim intNewImageHeight As Integer ''Added 9/20/2019 td

            ''9/20/2019 td''intNewImageWidth = pictureFieldOrText.Image.Width
            intNewImageWidth = newTextImage.Width ''Added 9/20/2019 td
            intNewImageHeight = newTextImage.Height ''Added 9/20/2019 td

            If (boolRotated) Then ''Added 8/18/2019 td
                ''
                ''Rotated Images ---  Any special programming needed? 
                ''
                ''Adjust the controls to the image size.
                ''   Is there any special programming for rotated images?   Probably not! ---9/3/2019 td 
                ''
                ''9/20/2019 td''pictureFieldOrText.Width = pictureFieldOrText.Image.Width
                ''9/20/2019 td''pictureFieldOrText.Height = pictureFieldOrText.Image.Height

                Dim bPictureBoxSizeIsReadOnly As Boolean ''Added 1/28/2022 td 
                bPictureBoxSizeIsReadOnly = (pictureFieldOrText.Dock = DockStyle.Fill) ''Added 1/28/2022 td

                If (bPictureBoxSizeIsReadOnly) Then ''Added 1/28/2022 td
                    ''
                    ''PictureBox.Dock = "Fill", so trying to directly adjust the size of the PictureBox
                    ''  will likely have __ZERO__ effect, as the size of the PictureBox is controlled
                    ''  by the size of the UserControl.  ----1/28/2022 td 
                    ''
                    ''------DIFFICULT & CONFUSING / POINTLESS PROGRAMMING !!!-----------------
                    pictureFieldOrText.Width = intNewImageWidth ''This will --NOT-- work as expected. --Jan2022
                    pictureFieldOrText.Height = intNewImageHeight ''This will --NOT-- work as expected. --Jan2022 
                    ''------End of "DIFFICULT & CONFUSING / POINTLESS PROGRAMMING !!!"-------

                Else
                    pictureFieldOrText.Width = intNewImageWidth ''Straightforward.   No reversal is needed here, despite the rotation. ---9/20 td
                    Application.DoEvents()
                    pictureFieldOrText.Height = intNewImageHeight ''Straightforward.   No reversal is needed here, despite the rotation. ---9/20 td 
                    Application.DoEvents()

                End If ''End of "If (bPictureBoxSizeIsReadOnly) Then .... Else ...."

                pictureFieldOrText.Invalidate() ''Forces it to be repainted.---Reinstated 1/28/2022 td

                If (bPictureBoxSizeIsReadOnly) Then
                    ''Since the PictureBox.Dock property is set to "Fill", we need to reference 
                    ''  the Integer variables rather than the pictureFieldOrText properties. ---1/28/2022
                    Me.Height = intNewImageHeight ''Jan28 2022 td''pictureFieldOrText.Height
                    Application.DoEvents()
                    Me.Width = intNewImageWidth ''Jan28 2022 td''pictureFieldOrText.Width
                Else
                    Me.Height = pictureFieldOrText.Height
                    Application.DoEvents()
                    Me.Width = pictureFieldOrText.Width

                End If ''End of "If (bPictureBoxSizeIsReadOnly) Then... Else ...."

            Else
                ''
                ''Adjust the controls to the image size. ---9/3/2019 td 
                ''
                ''9/20/2019 td''pictureFieldOrText.Width = pictureFieldOrText.Image.Width
                ''9/20/2019 td''pictureFieldOrText.Height = pictureFieldOrText.Image.Height
                pictureFieldOrText.Width = intNewImageWidth ''Straightforward.   No reversal is needed here, despite the rotation. ---9/20 td
                Application.DoEvents()
                pictureFieldOrText.Height = intNewImageHeight ''Straightforward.   No reversal is needed here, despite the rotation. ---9/20 td 
                Application.DoEvents()

                Me.Height = pictureFieldOrText.Height
                Application.DoEvents()
                Me.Width = pictureFieldOrText.Width

            End If ''End if "If (boolRotated) Then .... Else ...."

        End If ''End of "If (par_boolResizeLabelControl) Then ..... Else ...."

        ''Added 7/31/2019 td
        If (mod_c_boolMustSetBackColor And (ElementInfo_TextOnly IsNot Nothing)) Then
            ''
            ''A desperate attempt to get the background color to extend to the full, resized control.
            ''
            Dim boolColorDiscrepancy As Boolean = False ''Added 7/31/2019 td
            ''8/29 td''boolColorDiscrepancy = (Me.ElementInfo_Text.BackColor <> Me.ElementInfo_Text.Back_Color)

            If (boolColorDiscrepancy) Then
                MessageBox.Show("Warning, there is a discrepancy in the color information.", "ciLayout",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If ''ENd of "If (boolColorDiscrepancy) Then"

            pictureFieldOrText.BackColor = Me.ElementInfo_Base.Back_Color
            ''8/29/2019 td''pictureFieldOrText.BackColor = Me.ElementInfo_Text.BackColor
            pictureFieldOrText.BackColor = Me.ElementInfo_Base.Back_Color

        End If ''End of "If (mod_c_boolMustSetBackColor And (ElementInfo IsNot Nothing)) Then"

        If (pboolRefreshLabelControl) Then
            ''8/19/2019 td''pictureFieldOrText.Refresh()
            pictureFieldOrText.Invalidate() ''Forces it to be re-painted. ---9/21/2019 td 
            pictureFieldOrText.Refresh()
        End If ''End of "If (par_boolRefreshLabelControl) Then"

        If (pboolRefreshUserControl) Then
            Me.Refresh()
        End If ''ENd of "If (par_boolRefreshUserControl) Then"

    End Sub ''End of Public Sub Refresh_ImageV3


    Public Overrides Sub SaveToModel() Implements ISaveToModel.SaveToModel
        ''
        ''Added 7/29/2019 thomas d 
        ''
        ''7/29 td''Me.ElementInfo.Info = CType(Me.ElementInfo, IElementText)

        ''Me.ElementInfo.Text = Me.LabelText()

        ''9/5/2019 td''Me.ElementInfo_Base.TopEdge_Pixels = Me.Top
        ''9/5/2019 td''Me.ElementInfo_Base.LeftEdge_Pixels = Me.Left

        ''9/19/2019 td''Me.ElementInfo_Base.TopEdge_Pixels = Me.FormDesigner.Layout_Margin_Top_Omit(Me.Top)
        ''9/19/2019 td''Me.ElementInfo_Base.LeftEdge_Pixels = Me.FormDesigner.Layout_Margin_Left_Omit(Me.Left)

        MyBase.SaveToModel() ''Added 5/5/2022 td

        Me.ElementInfo_Base.TopEdge_Pixels = Me.LayoutFunctions.Layout_Margin_Top_Omit(Me.Top)
        Me.ElementInfo_Base.LeftEdge_Pixels = Me.LayoutFunctions.Layout_Margin_Left_Omit(Me.Left)

        ''Added 11/29/2021 td
        Me.ElementClass_ObjV4.DatetimeUpdated = Now ''Added 11/29/2021 td
        Dim intPixelsTop As Integer = Me.ElementClass_ObjV4.TopEdge_Pixels
        Dim intPixelsLeft As Integer = Me.ElementClass_ObjV4.LeftEdge_Pixels
        Dim intSum As Integer = (intPixelsTop + intPixelsLeft)

        ''
        ''Width & Height
        ''
        ''       (Account for rotated text, if applicable.) 
        ''
        If (Me.Rotated_0degrees()) Then
            ''
            ''Normal.  Easy-peasy.  The text is not rotated at all. 
            ''
            Me.ElementInfo_Base.Width_Pixels = Me.Width
            Me.ElementInfo_Base.Height_Pixels = Me.Height

        ElseIf (Me.Rotated_180_360()) Then
            ''
            ''Normal, easy-peasy. 
            ''
            Me.ElementInfo_Base.Width_Pixels = Me.Width
            Me.ElementInfo_Base.Height_Pixels = Me.Height

        ElseIf (Me.Rotated_90_270(False)) Then
            ''
            ''-------DIFFICULT/CONFUSING-----
            ''This is rotated, so let's pull a switcheroo. 
            ''   ----9/23/2019 TD  
            ''
            If (Me.Width < Me.Height) Then
                Me.ElementInfo_Base.Width_Pixels = Me.Height
                Me.ElementInfo_Base.Height_Pixels = Me.Width
            Else
                ''Added 9/23/2019 td 
                Throw New Exception("Logically, this should not occur. #1957 " &
                                    "(Because the function Me.Rotated_90_270() says, we are rotated. " &
                                    "  (The function checks the Element.))")
            End If ''End of "If (Me.Width < Me.Height) Then"
        Else
            ''Added 9/23/2019 td 
            Throw New Exception("Logically, this should Not occur. #1958  " &
                                "(because we have accounted for all rotational positions).")
        End If ''End of "If (Me.Rotated_0degrees()) Then .... ElseIf .... ElseIf ...."

        ''Added 9/4/2019 thomas downes
        ''9/12/2019 td''Me.ElementInfo_Base.LayoutWidth_Pixels = Me.FormDesigner.Layout_Width_Pixels()
        ''9/5/2019 td''Me.ElementInfo_Base.BadgeLayout.Width_Pixels = Me.FormDesigner.Layout_Width_Pixels()
        ''9/5/2019 td''Me.ElementInfo_Base.BadgeLayout.Height_Pixels = Me.FormDesigner.Layout_Height_Pixels()

        Me.ElementInfo_Base.BadgeLayout.Width_Pixels = Me.LayoutFunctions.Layout_Width_Pixels()
        Me.ElementInfo_Base.BadgeLayout.Height_Pixels = Me.LayoutFunctions.Layout_Height_Pixels()

        ''Me.ElementInfo.Font_DrawingClass = Me.Font
        ''Me.ElementInfo.BackColor = Me.BackColor
        ''Me.ElementInfo.FontColor = Me.ForeColor

        ''
        ''Added 9/15/2019 thomas d. 
        ''
        ''9/18/2019 td''
        ''Select Case True
        ''    Case Me.FieldInfo.IsStandard
        ''        ''
        ''        ''Standard field. 
        ''        ''
        ''        ''Added 9/15/2019 thomas d.
        ''        ClassFieldStandard.CopyElementInfo(Me.FieldInfo.FieldIndex,
        ''                                           Me.ElementInfo_Base, Me.ElementInfo_Text)
        ''
        ''    Case Else
        ''        ''
        ''        ''Customized field.
        ''        ''
        ''        ''Added 9/15/2019 thomas d.
        ''        ClassFieldCustomized.CopyElementInfo(Me.FieldInfo.FieldEnumValue,
        ''                                           Me.ElementInfo_Base, Me.ElementInfo_Text)
        ''
        ''End Select

    End Sub ''End of Public Sub SaveToModel


    Public Function Copy(pboolDummy As Boolean) As ClassElementFieldV4
        ''
        ''Added 2/4/2022 & 9/17/2019 
        ''
        Dim objCopy As New ClassElementFieldV4

        ''Feb4 2022 td''objCopy.LoadByCopyingMembers(Me, Me, Me, Me.BadgeLayout)
        ''objCopy.LoadByCopyingMembers(Me, Me, Me, MyBase.BadgeLayout)

        Return objCopy

    End Function ''End of "Public Function Copy() As ClassElementFieldV4"


    Public Sub LoadbyCopyingMembers(par_objectElementV4 As ClassElementFieldV4,
                                    par_ElementInfo_Base As IElement_Base,
                                    par_ElementInfo_Text As IElement_TextOnly,
                                    par_badgeLayout As BadgeLayoutClass)
        ''
        ''Added Feb. 4 2022 td 
        ''
        Me.Element_FieldV4.LoadByCopyingMembers(par_objectElementV4, par_ElementInfo_Base,
                     par_ElementInfo_Text,
                     par_objectElementV4,
                     par_badgeLayout)

    End Sub ''End of "Public Sub LoadbyCopyingMembers"



End Class

