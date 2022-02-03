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

Public Class CtlGraphicStaticTextV4
    ''
    ''Added 1/31/2022 td
    ''
    Public Element_StaticTextV4 As ciBadgeElements.ClassElementStaticTextV4
    Private Shared mod_intFieldTexts As Integer ''Feb01 2022 td'' += 1
    Private Shared mod_intStaticTexts As Integer ''Feb01 2022 td'' += 1

    Public Shared Function GetStaticTextControl(par_parametersGetElementControl As ClassGetElementControlParams,
                                           par_elementStaticText As ClassElementStaticTextV4,
                                           par_formParent As Form,
                                           par_oDesigner As ClassDesigner,
                                      par_nameOfControl As String,
                                      par_iLayoutFun As ILayoutFunctions,
                                           par_sizeNeeded As Size,
                                par_iRecordLastTouched As IRecordElementLastTouched,
                                par_iControlLastTouched As ILastControlTouched,
                                par_oMoveEventsForGroupedCtls As GroupMoveEvents_Singleton) As CtlGraphicStaticTextV4
        ''
        ''Added 1/31/2021 td
        ''
        ''//Const c_enumElemType As EnumElementType = EnumElementType.Field
        Const bAddFunctionalitySooner As Boolean = False
        Const bAddFunctionalityLater As Boolean = True

        Dim typeOps As Type
        Dim objOperations As Object ''Added 12/29/2021 td 
        Dim objOperationsStaticText_V4 As Operations_StaticTextV4
        Dim sizeFieldElement As Size ''Added 1/26/2022 td

        ''Instantiate the Operations Object. 
        objOperationsStaticText_V4 = New Operations_StaticTextV4() ''Added 1/31/2022 td
        typeOps = objOperationsStaticText_V4.GetType()
        objOperations = objOperationsStaticText_V4

        If (objOperations Is Nothing) Then
            ''Added 12/29/2021
            Throw New Exception("Ops is Nothing, so I guess Element Type is Undetermined.")
        End If ''end of "If (objOperations Is Nothing) Then"

        ''Added 12/2/2022 td
        Dim enumElementType_Enum As EnumElementType = EnumElementType.Field

        ''Create the control.
        Dim CtlStaticText As CtlGraphicStaticTextV4

        ''Public Sub New(par_elementField As ClassElementField,
        ''                par_layout As ILayoutFunctions,
        ''                pstrWhyWasICreated As String,
        ''                par_formRecordLastTouched As IRecordElementLastTouched)

        CtlStaticText = New CtlGraphicStaticTextV4(par_elementStaticText,
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

        With CtlStaticText
            .Name = par_nameOfControl
            ''Jan11 2022''If (bAddFunctionalityLater) Then .AddMoveability(par_oMoveEvents, par_iLayoutFun)
            If (bAddFunctionalityLater) Then .AddMoveability(par_iLayoutFun,
                                                             par_oMoveEventsForGroupedCtls, Nothing)
            If (bAddFunctionalityLater) Then .AddClickability()
        End With ''eNd of "With CtlQRCode1"

        ''
        ''Specify the current element to the Operations object. 
        ''
        Dim infoOps As ICurrentElement = CType(objOperations, ICurrentElement)
        infoOps.CtlCurrentElement = CtlStaticText

        ''Added 1/17/2022 td 
        infoOps.ElementsCacheManager = par_parametersGetElementControl.ElementsCacheManager

        ''Added 1/24/2022 thomas d. 
        With objOperationsStaticText_V4

            .CtlCurrentControl = CtlStaticText
            .CtlCurrentElement = CtlStaticText
            .CtlCurrentElementStaticText = CtlStaticText ''Added 1/24/2022 td
            ''.Designer = par_oMoveEventsForGroupedCtls.
            .Designer = par_parametersGetElementControl.DesignerClass
            .ElementInfo_Base = par_elementStaticText
            .ElementInfo_TextOnly = par_elementStaticText ''Added 2/2/2022 td

            .ElementsCacheManager = par_parametersGetElementControl.ElementsCacheManager

            ''#1 2/1/2022 ''.Element_Type = Enum_ElementType.StaticGraphic
            ''#2 2/1/2022 ''.Element_Type = Enum_ElementType.StaticTextV3
            .Element_Type = Enum_ElementType.StaticTextV4

            .EventsForMoveability_Group = par_oMoveEventsForGroupedCtls
            .EventsForMoveability_Single = Nothing
            .LayoutFunctions = .Designer ''Added 1/24/2022 td

            ''Added 2/2/2022 td
            .ElementStaticTextV4 = CtlStaticText.Element_StaticTextV4

        End With ''End of "With objOperationsFldElem"

        Return CtlStaticText

    End Function ''end of "Public Shared Function GetStaticTextControl() As CtlGraphicStaticTextV4"


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


    Public Sub New(par_elementField As ClassElementStaticTextV4,
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
        MyBase.New(EnumElementType.Field,
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

        Me.ElementClass_Obj = par_elementField
        Me.ElementInfo_Base = CType(par_elementField, IElement_Base)
        ''10/12/2019 td''Me.ElementInfo_Text = CType(par_elementField, IElement_TextField)
        Me.ElementInfo_TextOnly = CType(par_elementField, IElement_TextOnly) ''Modified 10/12/2019 td
        ''1/2/2022 td''Me.ElementInfo_Field = CType(par_elementField, IElement_TextField) ''Added 10/12/2019 td
        Me.Element_StaticTextV4 = par_elementField ''Added 2/2/2022 thomas d. 

        Try
            Me.ElementInfo_TextField = CType(par_elementField, IElement_TextField) ''Added 10/12/2019 td
            mod_intFieldTexts += 1
        Catch
            mod_intStaticTexts += 1
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

    End Sub ''ENd of "Public Sub New "


    Public Overrides Sub Refresh_ImageV3(pbRefreshSize As Boolean,
                             Optional pboolResizeLabelControl As Boolean = True,
                             Optional pboolRefreshLabelControl As Boolean = True,
                             Optional pboolRefreshUserControl As Boolean = False,
                             Optional pobjElementField As ClassElementFieldV3 = Nothing)
        ''
        ''Added 2/01/2022 thomas d. 
        ''
        Refresh_ImageV4(pbRefreshSize,
                        pboolResizeLabelControl,
                        pboolRefreshLabelControl,
                        pboolRefreshUserControl)

    End Sub ''End of "Public Overrides Sub Refresh_ImageV4(....)"


    Public Overrides Sub Refresh_ImageV4(pbRefreshSize As Boolean,
                             Optional pboolResizeLabelControl As Boolean = True,
                             Optional pboolRefreshLabelControl As Boolean = True,
                             Optional pboolRefreshUserControl As Boolean = False,
                             Optional pobjElementField As ClassElementFieldV4 = Nothing)
        ''Feb1 2022 td''Public Overrides Sub Refresh_ImageV3(pbRefreshSize As Boolean,
        ''
        ''Added 2/1/2022 & 7/25/2019 thomas d 
        ''
        ''7/29 td''Me.ElementInfo.Info = CType(Me.ElementInfo, IElementText)

        ''Me.ElementInfo.Text = Me.LabelText(
        ''8/4/2019''If (String.IsNullOrEmpty(Me.ElementInfo.Text)) Then ElementInfo.Text = LabelText()

        Dim boolScaleFontSize As Boolean ''Added 9/15/2019 thomas d. 

        ''Added 1/5/2022 td
        Dim info_TextOnly As IElement_TextOnly ''Added 1/5/2022 

        info_TextOnly = Me.ElementInfo_TextOnly ''Added 1/5/2022
        ''-----If (info_TextOnly Is Nothing) Then info_TextOnly = 

        ''1/5/2022 td''ElementInfo_TextOnly.Text_Static = LabelText()
        ''Not needed. 2/1/2022 td''ElementInfo_TextOnly.Text_Static = LabelText(pobjElementField)

        ''Added 2/1/2022 thomas downes
        Dim strTextToDisplay As String ''Added 2/1/2022 thomas downes
        strTextToDisplay = ElementInfo_TextOnly.Text_Static

        ''Me.ElementInfo.Width = pictureFieldOrText.Width
        ''Me.ElementInfo.Height = pictureFieldOrText.Height

        ''7/30/2019 td''Me.ElementInfo.Font_DrawingClass = Me.ParentForm.Font ''Me.Font
        ''7/30/2019 td''Me.ElementInfo.Font_DrawingClass = New Font("Times New Roman", 25, FontStyle.Italic)

        boolScaleFontSize = (Me.ElementInfo_TextOnly.FontSize_ScaleToElementYesNo)
        If (boolScaleFontSize And Me.ElementClass_Obj Is Nothing) Then
            ''Added 9/19/2019 td 
            MessageBox.Show("Where is the Element-Field Class???   We will need it to scale the Font.", "",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If ''End of "If (boolScaleFontSize) Then"

        If (Me.ElementInfo_TextOnly.Font_DrawingClass Is Nothing) Then
            ''
            ''Initialize the font. 
            ''
            ''9/6/2019 tdMe.ElementInfo_Text.Font_DrawingClass = New Font("Times New Roman", 15, FontStyle.Regular)

            With Me.ElementInfo_TextOnly
                ''9/6/2019 td''.FontSize = 15
                .FontSize_Pixels = 25 ''9/6/2019 ''15
                .FontBold = False
                .FontItalics = False
                .FontUnderline = False ''Added 9/6/2019 thomas downes
                .FontFamilyName = "Times New Roman"
                ''9/6/2019 td''.Font_DrawingClass = New Font(.FontFamilyName, .FontSize_Pixels, FontStyle.Regular, GraphicsUnit.Pixel)
                .Font_DrawingClass = modFonts.MakeFont(.FontFamilyName, .FontSize_Pixels, .FontBold, .FontItalics, .FontUnderline)
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
            boolScaleFontSize = (Me.ElementInfo_TextOnly.FontSize_ScaleToElementYesNo)
            If (boolScaleFontSize) Then
                ''Added 9/15/2019 thomas d.
                ''Jan28 2022''Me.ElementClass_Obj.Font_ScaleAdjustment(Me.ElementInfo_Base.Height_Pixels)
                ''Added 9/15/2019 thomas d.
                With Me.ElementInfo_Base ''Added 1/28/2022 td
                    ''2/2/2022 td ''If (Rotated_90_270(False) Or (.Width_Pixels < .Height_Pixels)) Then ''Added 1/28/2022 td
                    If (.Width_Pixels < .Height_Pixels) Then ''Modified 1/28/2022 td

                        ''Use .Width_Pixels, since .Height_Pixels & .Width_Pixels
                        ''   have been switched due to rotation. ----1/28/2022 td
                        Me.ElementClass_Obj.Font_ScaleAdjustment(.Width_Pixels)
                    Else
                        Me.ElementClass_Obj.Font_ScaleAdjustment(.Height_Pixels)
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

            ''Added 11-18-2019 td 
            ''Moved to the top. 2/1/2022 td''Dim strTextToDisplay As String ''Added 11/18/2019 td
            ''Feb1 2022 td''strTextToDisplay = Me.ElementClass_Obj.LabelText_ToDisplay(True, Nothing,
            ''Feb1 2022 td''     CtlGraphicFldLabelV3.UseExampleValues)

            ''Added 12/21/2021 td
            strTextToDisplay = (strTextToDisplay & (" " & Me.ElementClass_Obj.CaptionSuffixIfNeeded).TrimEnd())

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



End Class
