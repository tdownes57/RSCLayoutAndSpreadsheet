''
''Added 8/01/2019 thomas d 
''
Imports ciBadgeInterfaces ''Added 9/18/2019 td
''10/1/2019 td''Imports ciBadgeFields ''Added 9/18/2019 td
Imports ciBadgeElements ''Added 9/18/2019 td  
Imports System.Windows.Forms ''Added 10/1/2019 thomas d.  
Imports System.Drawing ''Added 10/1/2019 td 
Imports ciBadgeElemImage ''Added 10/12/2019 td
Imports __RSCWindowsControlLibrary ''Added 1/4/2022 td 

Public Class CtlGraphicStaticTextV3
    Implements ISaveToModel ''Added 12/17/2021 td 
    Implements IMoveableElement ''Added 12/17/2021 td
    ''
    ''Added 8/01/2019 thomas d 
    ''
    ''9/3/2019 td''Public Shared Generator As ClassLabelToImage
    Public Shared LabelToImage As ClassLabelToImage

    ''8/29/2019 td''Public ElementInfo As ClassElementText
    Public Element_StaticText As New ClassElementStaticTextV3 ''Added 10/11/2019 td
    Public Overrides Property ElementInfo_Base As ciBadgeInterfaces.IElement_Base ''Added 8/29/2019 td
    ''9/18/2019 td''Public ElementInfo_Text As ciBadgeInterfaces.IElement_TextField ''Added 8/29/2019 td
    Public ElementInfo_TextOnly As ciBadgeInterfaces.IElement_TextOnly ''Added 8/29/2019 td
    Public ElementClass_Obj As ClassElementStaticTextV3 ''Added 8/29/2019 td

    ''These properties are making use of the Dependency Injection pattern.
    Public ParentDesignForm_iSelecting As ISelectingElements ''Added 7/31/2019 thomas downes  

    ''1/8/2022 td''Public ReadOnly ParentDesignForm_iRefreshPreview As IRefreshPreview ''Added 12/27/2021 thomas downes  
    Public ParentDesignForm_iRefreshPreview As IRefreshCardPreview ''Added 12/27/2021 thomas downes  

    Public Event ElementStatic_RightClicked(par_control As CtlGraphicStaticTextV3) ''Added 12/15/2021 td

    Private Const mod_c_boolMustSetBackColor As Boolean = False ''False, since we have an alternate Boolean 
    ''   below which works fine (i.e. mod_c_bRefreshMustReinitializeImage = True).
    ''   We don't need to set the Background Color of the PictureBox control.  ----7/31/2019 thomas d. 

    Private Const mod_c_bRefreshMustResizeImage As Boolean = True ''True, since otherwise the background color 
    ''  is (frustratingly) limited to the original control size, _NOT_ the resized control's full area
    ''  (enlarged via user click-and-drag), unfortunately.  ----7/31/2019 thomas d.  

    Private mod_strTextToDisplay As String = "This is text which will be the same for everyone." ''Added 10/10/2019 td 

    Private mod_bDisplayVisibilityLink As Boolean = False ''Added 12/27/2021 td
    Private Const mod_c_bResizeProportionally As Boolean = False ''Added 1/8/2022 thomas d. 


    Public ReadOnly Property Picture_Box As PictureBox
        Get
            ''Added 7/28/2019 td 
            Return Me.pictureLabel
        End Get
    End Property

    Public Property TextToDisplay As String
        Get
            ''Added 10/10/2019 td 
            Return mod_strTextToDisplay
        End Get
        Set(value As String)
            ''Added 10/10/2019 td 
            mod_strTextToDisplay = value

            If (Me.ElementInfo_TextOnly Is Nothing) Then Me.ElementInfo_TextOnly = Me.Element_StaticText
            Me.ElementInfo_TextOnly.Text_StaticLine = value

            textTypeExample.Text = mod_strTextToDisplay
        End Set
    End Property


    Public Shared Function GetStaticText(par_parametersGetElementControl As ClassGetElementControlParams,
                                           par_elementStaticText As ClassElementStaticTextV3,
                                         par_oParentForm As Form,
                                      par_nameOfControl As String,
                                      par_iLayoutFun As ILayoutFunctions,
                                         par_sizeDesired As Size,
                                         par_iRefreshPreview As IRefreshCardPreview,
                                par_iControlLastTouched As ILastControlTouched,
                 par_oMoveEventsGroupedControls As GroupMoveEvents_Singleton) As CtlGraphicStaticTextV3
        ''              1/6/2022 td'' par_bProportionSizing As Boolean,
        ''              1/2/2022 td'' par_iSaveToModel As ISaveToModel,
        ''
        ''Added 1/07/2021 td
        ''
        Const c_enumElemType As EnumElementType = EnumElementType.StaticText
        Const bAddFunctionalitySooner As Boolean = False
        Const bAddFunctionalityLater As Boolean = True

        Dim typeOps As Type
        Dim objOperations As Object ''Added 12/29/2021 td 
        ''Dim objOperations1Gen As Operations__Generic = Nothing
        ''Dim objOperations2Use As Operations__Useless = Nothing
        Dim objOperationsST_V3 As Operations_StaticTextV3 ''Added 12/31/2021 td 

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
        objOperationsST_V3 = New Operations_StaticTextV3() ''Added 1/1/2022 td
        typeOps = objOperationsST_V3.GetType()
        objOperations = objOperationsST_V3

        If (objOperations Is Nothing) Then
            ''Added 12/29/2021
            Throw New Exception("Ops is Nothing, so I guess Element Type is Undetermined.")
        End If ''end of "If (objOperations Is Nothing) Then"

        ''Added 12/2/2022 td
        Dim enumElementType_Enum As EnumElementType = __RSCWindowsControlLibrary.EnumElementType.StaticText

        ''
        ''Create the control. 
        ''
        ''Jan2 2022''Dim CtlQRCode1 = New CtlGraphicQRCode(par_elementQRCode, par_iLayoutFun,
        ''Jan2 2022''           enumElementType_Enum, par_bProportionSizing,

        Dim CtlStaticText1 = New CtlGraphicStaticTextV3(par_elementStaticText,
                                                        par_parametersGetElementControl,
                                                        par_oParentForm,
                                    par_iLayoutFun, par_sizeDesired,
                                    par_iRefreshPreview,
                                typeOps, objOperations,
                                bAddFunctionalitySooner,
                                bAddFunctionalitySooner,
                                par_iControlLastTouched,
                                par_oMoveEventsGroupedControls)

        ''Jan8 2022 td''         par_bProportionSizing,
        ''Jan2 2022 ''          --------''Jan2 2022 ''par_iSaveToModel, typeOps,

        With CtlStaticText1
            .Name = par_nameOfControl

            ''Jan11 2022 ''If (bAddFunctionalityLater) Then .AddMoveability(par_oMoveEvents, par_iLayoutFun)
            ''Jan11 2022 ''If (bAddFunctionalityLater) Then .AddClickability()

            If (bAddFunctionalityLater) Then
                ''
                ''Major calls !!
                ''
                .AddMoveability(par_iLayoutFun, par_oMoveEventsGroupedControls, Nothing)
                .AddClickability()

            End If ''End of "If (bAddFunctionalityLater) Then"

            ''Added 2/5/2022 td
            .RightclickMouseInfo = objOperationsST_V3 ''Added 2/5/2022 td

        End With ''eNd of "With CtlStaticText1"

        ''
        ''Specify the current element to the Operations object. 
        ''
        Dim infoOps = CType(objOperations, ICurrentElement) ''.CtlCurrentElement = MoveableControlVB1
        infoOps.CtlCurrentElement = CtlStaticText1

        ''Added 1/17/2022 td 
        infoOps.ElementsCacheManager = par_parametersGetElementControl.ElementsCacheManager

        ''Added 1/19/2022 td
        With objOperationsST_V3
            .CtlCurrentForm = par_oParentForm ''Added 5/16/2022
            .CtlCurrentElement = CtlStaticText1
            .CtlCurrentControl = CtlStaticText1 ''Added 6/1/2022 td

            .CtlCurrentElementStaticText = CtlStaticText1
            .ElementInfo_Base = par_elementStaticText
            .ElementStaticText = par_elementStaticText
            .ElementInfo_TextOnly = par_elementStaticText
            .Element_Type = ciBadgeInterfaces.Enum_ElementType.StaticTextV3
            ''Added 1/25/2022 td
            .Designer = par_parametersGetElementControl.DesignerClass
            .LayoutFunctions = par_parametersGetElementControl.DesignerClass
            .InfoRefresh = par_parametersGetElementControl.iRefreshPreview ''Added 5/10/2022

        End With ''End of ""With objOperationsST_V3""

        Return CtlStaticText1

    End Function ''end of "Public Shared Function GetStaticText() As CtlGraphicStaticText"


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ''Added 10/11/2019 thomas downes
        ''
        If (False) Then ''Added 1/9/2022 to see if it helps w/ Moveability.
            Me.Element_StaticText = New ClassElementStaticTextV3
            Me.ElementInfo_Base = CType(Me.Element_StaticText, IElement_Base)
            Me.ElementInfo_TextOnly = CType(Me.Element_StaticText, IElement_TextOnly)
            Me.ElementClass_Obj = Me.Element_StaticText ''Added 1/8/2022 td
        End If

        ''Added 12/27/2021 td 
        Me.LinkInvisible.Text = Me.LinkInvisible.Tag.ToString()

    End Sub


    Public Sub New(par_elementST As ClassElementStaticTextV3,
                   par_parameters As IGetElementControlParameters,
                   par_oForm As Form,
                   par_iLayoutFun As ILayoutFunctions,
                   par_iSizeDesired As Size,
                   par_iRefreshPreview As IRefreshCardPreview,
                   par_operationsType As Type,
                   par_operationsAny As Object,
                   pboolAddMoveability As Boolean,
                   pboolAddClickability As Boolean,
                   par_iLastTouched As ILastControlTouched,
                   par_oMoveEvents As GroupMoveEvents_Singleton,
                   Optional pbHandleMouseEventsThroughFormVB6 As Boolean = True)
        ''Jan8 2022 td''      pboolResizeProportionally As Boolean,
        ''
        ''Added 1/07/2022 td
        ''
        ''Jan1 2022 td''MyBase.New(par_enumElementType, pboolResizeProportionally,
        MyBase.New(EnumElementType.StaticText, par_elementST,
                        par_parameters.ElementsCache, par_oForm,
                        mod_c_bResizeProportionally,
                        par_iLayoutFun, par_iRefreshPreview, par_iSizeDesired,
                        par_operationsType, par_operationsAny,
                        pboolAddMoveability, pboolAddClickability,
                        par_iLastTouched, par_oMoveEvents, 0,
                        pbHandleMouseEventsThroughFormVB6)
        ''          Jan2 2022'' par_iSaveToModel, par_iLayoutFun,

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ''Encapsulated 12/30/2021 td
        New_StaticText(par_elementST, par_iRefreshPreview)

    End Sub


    Public Sub New_StaticText(par_element As ClassElementStaticTextV3, par_iRefreshPreview As IRefreshCardPreview)

        ' This call is required by the designer.
        ''Jan7 2022 td''InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ''_Deprecated 9/18/2019 td''''Me.ElementInfo_Text = par_field.ElementFieldClass
        ''9/18/2019 td''Me.ElementInfo_Text = par_element

        ''Added 12/18/2021 Thomas Downes  
        Me.ElementInfo_TextOnly = par_element
        Me.ElementInfo_Base = par_element
        Me.Element_StaticText = par_element
        Me.ElementClass_Obj = par_element ''Added 1/8/2022 td

        ''Added 5/16/2022 td
        ''  This will be used by Operations__Base.Delete_Element_From_Badge_BA1019
        Me.ElemIfApplicable_ITextOnly = CType(par_element, IElement_TextOnly)

        ''Added 12/27/2021 thomas downes
        ''   This is making use of the Dependency Injection pattern.
        ''
        ParentDesignForm_iRefreshPreview = par_iRefreshPreview
        Dim bInvisibleOnBadge As Boolean

        ''Added 12/27/2021 thomas downes
        bInvisibleOnBadge = (Not par_element.Visible)
        mod_bDisplayVisibilityLink = bInvisibleOnBadge ''Added 12/27/2021 
        LinkInvisible.Visible = bInvisibleOnBadge

        ''Added 12/27/2021 td 
        If (bInvisibleOnBadge) Then
            Me.LinkInvisible.Text = Me.LinkInvisible.Tag.ToString()
        Else
            Me.LinkInvisible.Text = "Visible on badge."
        End If ''End of "If (bInvisibleOnBadge) Then... Else ..."

    End Sub ''End of "Public Sub New(par_element As ClassElementStaticText)"

    Public Sub New_Deprecated(par_element As ClassElementStaticTextV3)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ''_Deprecated 9/18/2019 td''''Me.ElementInfo_Text = par_field.ElementFieldClass
        ''9/18/2019 td''Me.ElementInfo_Text = par_element
        Me.ElementInfo_TextOnly = par_element

    End Sub

    ''Public Sub New_Deprecated(par_field As ClassFieldStandard)
    ''
    ''    ' This call is required by the designer.
    ''    InitializeComponent()
    ''
    ''    ' Add any initialization after the InitializeComponent() call.
    ''    ''_Deprecated 9/18/2019 td''''Me.ElementInfo_Text = par_field.ElementFieldClass
    ''
    ''End Sub

    ''Public Sub New_Deprecated(par_field As ClassFieldCustomized)
    ''
    ''    ' This call is required by the designer.
    ''    InitializeComponent()
    ''
    ''    ' Add any initialization after the InitializeComponent() call.
    ''    ''_Deprecated 9/18/2019 td''Me.ElementInfo_Text = par_field.ElementFieldClass
    ''
    ''End Sub

    Public Sub Refresh_Master()
        ''
        ''Added 9/17 & 9/5/2019 thomas d 
        ''
        Refresh_PositionAndSize()
        Refresh_Image(True)

ExitHandler:
        ''
        ''Check for Label-Control size discrepancies.  ---9/23 thomas d.    
        ''
        Dim boolWidthDisparity As Boolean ''Added 9/23/2019 td 
        Dim boolHeightDisparity As Boolean ''Added 9/23/2019 td 
        Dim intTry As Integer ''Why this is needed, is not clear.
        Dim bDisparity_Neither As Boolean ''Added 9/23/2019 td 

        For intTry = 1 To 3 ''Why this is needed, is not clear. It's needed in conjunction with rotations. 

            ''Check for Label-Control size discrepancies.  ---9/23 thomas d.    
            boolWidthDisparity = (Math.Abs(Me.Width - Me.pictureLabel.Width) > 5) Or
                            (Math.Abs(Me.pictureLabel.Width - Me.pictureLabel.Image.Width) > 5)
            boolHeightDisparity = (Math.Abs(Me.Height - Me.pictureLabel.Height) > 5) Or
                                (Math.Abs(Me.pictureLabel.Height - Me.pictureLabel.Image.Height) > 5)

            bDisparity_Neither = (Not (boolWidthDisparity Or boolHeightDisparity))
            If (bDisparity_Neither) Then Exit For

            ''Let's try to make the controls match the dimensions of the image. ----1/24/2022
            ''  Docked PictureBox controls will likely prevent the following code 
            ''  from having any numerical effect. ---1/24/2022 td
            Me.pictureLabel.Width = Me.pictureLabel.Image.Width ''If Me.pictureLabel is docked to be "Full Docking" this command will be useless.  ----1/24/2022
            Me.pictureLabel.Height = Me.pictureLabel.Image.Height ''If Me.pictureLabel is docked to be "Full Docking" this command will be useless.  ----1/24/2022

            ''Added 1/24/2022 td
            Me.Width = Me.pictureLabel.Image.Width
            Me.Height = Me.pictureLabel.Image.Height

        Next intTry

        ''Issue a program-execuation break, if needed.     
        If (boolWidthDisparity) Then System.Diagnostics.Debugger.Break()
        If (boolHeightDisparity) Then System.Diagnostics.Debugger.Break()

    End Sub ''End of "Public Sub Refresh_Master()"

    Public Overrides Sub Refresh_PositionAndSize()
        ''
        ''Added 9/17 & 9/5/2019 thomas d 
        ''

        ''Jan8 2022''Me.Left = Me.LayoutFunctions.Layout_Margin_Left_Add(Me.ElementInfo_Base.LeftEdge_Pixels)
        ''Jan8 2022''Me.Top = Me.LayoutFunctions.Layout_Margin_Top_Add(Me.ElementInfo_Base.TopEdge_Pixels)
        Me.Left = mod_iLayoutFunctions.Layout_Margin_Left_Add(Me.ElementInfo_Base.LeftEdge_Pixels)
        Me.Top = mod_iLayoutFunctions.Layout_Margin_Top_Add(Me.ElementInfo_Base.TopEdge_Pixels)

        Me.Width = Me.ElementInfo_Base.Width_Pixels
        Me.Height = Me.ElementInfo_Base.Height_Pixels

    End Sub ''End of "Public Sub Refresh_PositionAndSize()"


    Public Sub Refresh_Image(pbRefreshSize As Boolean,
                             Optional pboolResizeLabelControl As Boolean = True,
                             Optional pboolRefreshLabelControl As Boolean = True,
                             Optional pboolRefreshUserControl As Boolean = False,
                             Optional par_intBadgeLayoutWidth As Integer = 681)
        ''
        ''Added 7/25/2019 thomas d 
        ''
        ''7/29 td''Me.ElementInfo.Info = CType(Me.ElementInfo, IElementText)

        ''Me.ElementInfo.Text = Me.LabelText(
        ''8/4/2019''If (String.IsNullOrEmpty(Me.ElementInfo.Text)) Then ElementInfo.Text = LabelText()

        Dim boolScaleFontSize As Boolean ''Added 9/15/2019 thomas d. 
        Dim strLabelText_EditedByUser As String ''Added 1/22/2022 td

        ''Added 10/12/2019 td
        If (Me.ElementInfo_TextOnly Is Nothing) Then Me.ElementInfo_TextOnly = Me.Element_StaticText
        ''Added 5/31/20122 td
        If (Me.ElementInfo_TextOnly.Text_StaticLine Is Nothing) Then
            Me.ElementInfo_TextOnly.Text_StaticLine = String.Empty
        End If ''End of ""If (Me.ElementInfo_TextOnly.Text_StaticLine Is Nothing) Then""

        ''Jan22 2022''ElementInfo_TextOnly.Text_Static = LabelText()
        Const c_boolPromptUserForMissingText As Boolean = False ''Added 5/31/2022 
        If (c_boolPromptUserForMissingText) Then
            strLabelText_EditedByUser = LabelText_Static() ''Get the text by prompting the user. 
            If (strLabelText_EditedByUser = "") Then
                MessageBoxTD.Show_Statement("User has declined to provide any text, and/or has cancelled.")
                Exit Sub
                ''Me.ElementClass_Obj.Text_StaticLine
                ''Me.Element_StaticText.Text_StaticLine
            End If ''ENd of "If (strLabelText_EditedByUser = "") Then"
            ElementInfo_TextOnly.Text_StaticLine = strLabelText_EditedByUser
        End If ''End of ""If (c_boolPromptUserForMissingText) Then""

        ''Me.ElementInfo.Width = pictureLabel.Width
        ''Me.ElementInfo.Height = pictureLabel.Height

        ''7/30/2019 td''Me.ElementInfo.Font_DrawingClass = Me.ParentForm.Font ''Me.Font
        ''7/30/2019 td''Me.ElementInfo.Font_DrawingClass = New Font("Times New Roman", 25, FontStyle.Italic)

        boolScaleFontSize = (Me.ElementInfo_TextOnly.FontSize_ScaleToElementYesNo)
        If (boolScaleFontSize And Me.Element_StaticText Is Nothing) Then
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
            pictureLabel.Width = Me.ElementInfo_Base.Width_Pixels
            pictureLabel.Height = Me.ElementInfo_Base.Height_Pixels

            ''Added 9/15/2019 thomas d.
            boolScaleFontSize = (Me.ElementInfo_TextOnly.FontSize_ScaleToElementYesNo)
            If (boolScaleFontSize) Then
                ''Added 9/15/2019 thomas d.
                With Me.ElementInfo_Base ''Added 1/28/2022 td
                    If (Rotated_90_270(False) Or (.Width_Pixels < .Height_Pixels)) Then ''Added 1/28/2022 td
                        ''Use .Width_Pixels, since .Height_Pixels & .Width_Pixels
                        ''   have been switched due to rotation. ----1/28/2022 td
                        Me.ElementClass_Obj.Font_ScaleAdjustment(.Width_Pixels)
                    Else
                        Me.Element_StaticText.Font_ScaleAdjustment(.Height_Pixels)
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
        boolReinitializeImage = (c_bMustReinitializeToResize And mod_c_bRefreshMustResizeImage)

        If (boolReinitializeImage) Then
            ''
            ''Destroy & recreate the .Image member from scratch, to allow for a new size. ----7/31/2019 td
            ''
            pictureLabel.Image = Nothing

            If (pictureLabel.Width > 0 And pictureLabel.Height > 0) Then
                pictureLabel.Image = (New Bitmap(pictureLabel.Width, pictureLabel.Height))
            ElseIf (pictureLabel.Width > 0 And pictureLabel.Height = 0) Then
                ''Don't allow a run-time error to occur, due to a parameter of Height = Zero (0). ----8/3/2019 td
                pictureLabel.Image = (New Bitmap(pictureLabel.Width, 15))
            ElseIf (pictureLabel.Width = 0 And pictureLabel.Height > 0) Then
                ''Don't allow a run-time error to occur, due to a parameter of Width = Zero (0).  ----8/3/2019 td
                pictureLabel.Image = (New Bitmap(15, pictureLabel.Height))
            End If

        End If ''End of "If (boolReinitializeImage) Then"

        ''7/29/2019 td''pictureLabel.Image = Generator.TextImage(Me.ElementInfo, Me.ElementInfo)
        ''8/18/2019 td''Generator.TextImage(pictureLabel.Image, Me.ElementInfo, Me.ElementInfo)

        Dim boolRotated As Boolean ''Added 8/18/2019 td

        ''Added 8/18/2019 td
        ''9/3/2019 td''LabelToImage.TextImage(pictureLabel.Image, Me.ElementInfo_Text, Me.ElementInfo_Base, boolRotated)

        Dim intBadgeLayoutWidth As Integer ''Added 9/3/2019 thomas d.

        ''9/19/2019 td''intLayoutWidth = Me.FormDesigner.Layout_Width_Pixels()
        ''1/08/2022 td''If (Me.LayoutFunctions IsNot Nothing) Then
        ''1/08/2022 td''   intBadgeLayoutWidth = Me.LayoutFunctions.Layout_Width_Pixels()

        If (mod_iLayoutFunctions IsNot Nothing) Then
            intBadgeLayoutWidth = mod_iLayoutFunctions.Layout_Width_Pixels()
        Else
            ''Added 11/24/2021 td
            intBadgeLayoutWidth = par_intBadgeLayoutWidth
        End If ''End of "If (mod_iLayoutFunctions IsNot Nothing) Then ... Else ...."

        ''9/4/2019 td''LabelToImage.TextImage(intLayoutWidth, pictureLabel.Image, Me.ElementInfo_Text, Me.ElementInfo_Base, boolRotated)

        ''
        ''Major call !!
        ''
        Dim newTextImage As Image ''Added 9/20/2019 td  

        ''Added 11/24/2021 thomas d. 
        If (0 = Me.ElementInfo_Base.BadgeLayout.Width_Pixels) Then
            ''Added 11/24/2021 thomas d. 
            Me.ElementInfo_Base.BadgeLayout.Width_Pixels = 681
            Me.ElementInfo_Base.BadgeLayout.Height_Pixels = 425
        End If ''End of "If (0 = Me.ElementInfo_Base.BadgeLayout.Width_Pixels) Then"

        Const c_boolUseNewestProjectReference As Boolean = True ''False ''True ''False ''True ''Added 9/20/2019 td 
        If (c_boolUseNewestProjectReference) Then

            newTextImage =
            modGenerate.TextImage_ByElemInfo(Me.Element_StaticText.Text_StaticLine,
                                             intBadgeLayoutWidth,
                                   Me.ElementInfo_TextOnly,
                                   Me.ElementInfo_Base,
                                   boolRotated, True)
        Else
            ''9/20/2019 td''pictureLabel.Image =
            newTextImage =
            LabelToImage.TextImage_Field(intBadgeLayoutWidth,
                                    Me.ElementInfo_TextOnly,
                                   Me.ElementInfo_Base,
                                   boolRotated, True)

        End If ''End of "If (c_boolUseNewestProjectReference) Then ..... Else ...."

        ''Added 9/20/2019 td
        pictureLabel.Image = newTextImage

        ''Added 9/23/2019 td
        Application.DoEvents() ''Give the PictureBox control time to make any adjustments it might want to do. 

ExitHandler:
        If (pboolResizeLabelControl) Then ''Added9/23/2019 td 

            ''Added 8/18/2019 td
            Dim intNewImageWidth As Integer ''Added 8/18/2019 td
            Dim intNewImageHeight As Integer ''Added 9/20/2019 td

            ''9/20/2019 td''intNewImageWidth = pictureLabel.Image.Width
            intNewImageWidth = newTextImage.Width ''Added 9/20/2019 td
            intNewImageHeight = newTextImage.Height ''Added 9/20/2019 td

            If (boolRotated) Then ''Added 8/18/2019 td
                ''
                ''Rotated Images ---  Any special programming needed? 
                ''
                ''Adjust the controls to the image size.
                ''   Is there any special programming for rotated images?   Probably not! ---9/3/2019 td 
                ''
                ''9/20/2019 td''pictureLabel.Width = pictureLabel.Image.Width
                ''9/20/2019 td''pictureLabel.Height = pictureLabel.Image.Height

                Dim bPictureBoxSizeIsReadOnly As Boolean ''Added 1/28/2022 td 
                bPictureBoxSizeIsReadOnly = (pictureLabel.Dock = DockStyle.Fill) ''Added 1/28/2022 td

                If (bPictureBoxSizeIsReadOnly) Then ''Added 1/28/2022 td
                    ''
                    ''PictureBox.Dock = "Fill", so trying to directly adjust the size of the PictureBox
                    ''  will likely have __ZERO__ effect, as the size of the PictureBox is controlled
                    ''  by the size of the UserControl.  ----1/28/2022 td 
                    ''
                    ''------DIFFICULT & CONFUSING / POINTLESS PROGRAMMING !!!-----------------
                    pictureLabel.Width = intNewImageWidth ''This will --NOT-- work as expected. --Jan2022
                    pictureLabel.Height = intNewImageHeight ''This will --NOT-- work as expected. --Jan2022 
                    ''------End of "DIFFICULT & CONFUSING / POINTLESS PROGRAMMING !!!"-------

                Else
                    pictureLabel.Width = intNewImageWidth ''Straightforward.   No reversal is needed here, despite the rotation. ---9/20 td
                    Application.DoEvents()
                    pictureLabel.Height = intNewImageHeight ''Straightforward.   No reversal is needed here, despite the rotation. ---9/20 td 
                    Application.DoEvents()

                End If ''End of "If (bPictureBoxSizeIsReadOnly) Then .... Else ...."

                ''===+++++Possibly has unintended consequences. 1/28/2022 td
                ''===+++pictureLabel.Invalidate() ''Forces it to be repainted.
                pictureLabel.Invalidate() ''Forces it to be repainted.---Reinstated 1/28/2022 td

                If (bPictureBoxSizeIsReadOnly) Then
                    ''Since the PictureBox.Dock property is set to "Fill", we need to reference 
                    ''  the Integer variables rather than the PictureLabel properties. ---1/28/2022
                    Me.Height = intNewImageHeight ''Jan28 2022 td''pictureLabel.Height
                    Application.DoEvents()
                    Me.Width = intNewImageWidth ''Jan28 2022 td''pictureLabel.Width
                Else
                    Me.Height = pictureLabel.Height
                    Application.DoEvents()
                    Me.Width = pictureLabel.Width

                End If ''End of "If (bPictureBoxSizeIsReadOnly) Then... Else ...."

            Else
                ''
                ''Adjust the controls to the image size. ---9/3/2019 td 
                ''
                ''9/20/2019 td''pictureLabel.Width = pictureLabel.Image.Width
                ''9/20/2019 td''pictureLabel.Height = pictureLabel.Image.Height
                pictureLabel.Width = intNewImageWidth
                Application.DoEvents()
                pictureLabel.Height = intNewImageHeight
                Application.DoEvents()
                Me.Height = pictureLabel.Height
                Application.DoEvents()
                Me.Width = pictureLabel.Width

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

            pictureLabel.BackColor = Me.ElementInfo_Base.Back_Color
            ''8/29/2019 td''pictureLabel.BackColor = Me.ElementInfo_Text.BackColor
            pictureLabel.BackColor = Me.ElementInfo_Base.Back_Color

        End If ''End of "If (mod_c_boolMustSetBackColor And (ElementInfo IsNot Nothing)) Then"

        If (pboolRefreshLabelControl) Then
            ''8/19/2019 td''pictureLabel.Refresh()
            pictureLabel.Invalidate() ''Forces it to be re-painted. ---9/21/2019 td 
            pictureLabel.Refresh()
        End If ''End of "If (par_boolRefreshLabelControl) Then"

        If (pboolRefreshUserControl) Then
            Me.Refresh()
        End If ''ENd of "If (par_boolRefreshUserControl) Then"

    End Sub ''End of Public Sub Refresh_Image


    Public Sub Refresh_SizeToMatchImage()

        ''Copy-pasted 1/28/2022 td  
        ''Added 1/24/2022 td
        Me.Width = Me.pictureLabel.Image.Width
        Me.Height = Me.pictureLabel.Image.Height

    End Sub ''End of "Public Sub Refresh_SizeToMatchImage()"


    Public Overrides Sub SaveToModel() Implements ISaveToModel.SaveToModel
        ''
        ''Added 8/01/2019 thomas d 
        ''
        ''Dec17 2021''Me.ElementInfo_Base.TopEdge_Pixels = Me.Top
        ''Dec17 2021''Me.ElementInfo_Base.LeftEdge_Pixels = Me.Left

        ''Added 12/17/2021 td 
        Dim strLeftEdge_WasBefore As String = ""
        strLeftEdge_WasBefore = Me.ElementInfo_Base.LeftEdge_Pixels.ToString

        MyBase.SaveToModel() ''Added 5/5/2022 td

        ''Jan8 2022''Me.ElementInfo_Base.TopEdge_Pixels = Me.LayoutFunctions.Layout_Margin_Top_Omit(Me.Top)
        ''Jan8 2022''Me.ElementInfo_Base.LeftEdge_Pixels = Me.LayoutFunctions.Layout_Margin_Left_Omit(Me.Left)
        Me.ElementInfo_Base.TopEdge_Pixels = mod_iLayoutFunctions.Layout_Margin_Top_Omit(Me.Top)
        Me.ElementInfo_Base.LeftEdge_Pixels = mod_iLayoutFunctions.Layout_Margin_Left_Omit(Me.Left)

        ''Added 12/18/2021 td
        Me.ElementInfo_Base.DateSaved = DateTime.Now

        Dim strLeftEdge_IsNow As String = ""
        strLeftEdge_IsNow = Me.ElementInfo_Base.LeftEdge_Pixels.ToString

        ''Added 12/17/2021 td
        '' Dec19 2021 td''MessageBox.Show(String.Format("The left edge was {0}, is now {1}.",
        ''                   strLeftEdge_WasBefore, strLeftEdge_IsNow))

        Me.ElementInfo_Base.Width_Pixels = Me.Width
        Me.ElementInfo_Base.Height_Pixels = Me.Height

        ''ADded 9/4/2019 td
        ''
        ''9/12/2019 td''Me.ElementInfo_Base.LayoutWidth_Pixels = Me.FormDesigner.Layout_Width_Pixels()
        ''10/01/2019 td''Me.ElementInfo_Base.BadgeLayout.Width_Pixels = Me.FormDesigner.Layout_Width_Pixels()
        ''10/01/2019 td''Me.ElementInfo_Base.BadgeLayout.Height_Pixels = Me.FormDesigner.Layout_Height_Pixels()

        ''1/08/2022 td''Me.ElementInfo_Base.BadgeLayout.Width_Pixels = Me.LayoutFunctions.Layout_Width_Pixels()
        ''1/08/2022 td''Me.ElementInfo_Base.BadgeLayout.Height_Pixels = Me.LayoutFunctions.Layout_Height_Pixels()

        Me.ElementInfo_Base.BadgeLayout.Width_Pixels = mod_iLayoutFunctions.Layout_Width_Pixels()
        Me.ElementInfo_Base.BadgeLayout.Height_Pixels = mod_iLayoutFunctions.Layout_Height_Pixels()

    End Sub ''End of Public Sub SaveToModel


    Public Function LabelText_Static() As String
        ''6/1/2022 Public Function LabelText
        ''
        ''This function is similarly-named & matches the function name "LabelText()" in the following classes:
        ''   CtlGraphicFieldV3.vb
        ''   CtlGraphicFieldOrTextV4.vb
        ''   CtlGraphicStaticTextV3.vb  (now renamed to LabelText_Static(), 6/1/2022)  
        ''---6/1/2022 thomas d. 
        ''
        ''Added 7/25/2019 thomas d 
        ''
        Return Me.ElementInfo_TextOnly.Text_StaticLine

    End Function ''End of "Public Function LabelText() As String"


    Private Sub RefreshElement_Field(sender As Object, e As EventArgs)
        ''
        ''Added 7/31/2019 thomas downes
        ''
        Me.ElementInfo_Base.Width_Pixels = Me.Width
        Me.ElementInfo_Base.Height_Pixels = Me.Height

        ''Added 9/4/2019 td
        ''9/12/2019 td''Me.ElementInfo_Base.LayoutWidth_Pixels = Me.FormDesigner.Layout_Width_Pixels()
        ''10/01/2019 td''Me.ElementInfo_Base.BadgeLayout.Width_Pixels = Me.FormDesigner.Layout_Width_Pixels()
        ''10/01/2019 td''Me.ElementInfo_Base.BadgeLayout.Height_Pixels = Me.FormDesigner.Layout_Height_Pixels()

        ''#1 Jan8 2022''Me.ElementInfo_Base.BadgeLayout.Width_Pixels = Me.LayoutFunctions.Layout_Width_Pixels()
        ''#1 Jan8 2022''Me.ElementInfo_Base.BadgeLayout.Height_Pixels = Me.LayoutFunctions.Layout_Height_Pixels()
        Me.ElementInfo_Base.BadgeLayout.Width_Pixels = mod_iLayoutFunctions.Layout_Width_Pixels()
        Me.ElementInfo_Base.BadgeLayout.Height_Pixels = mod_iLayoutFunctions.Layout_Height_Pixels()

        Application.DoEvents()
        Me.Refresh_Image(True)
        Application.DoEvents()
        Me.Refresh()

    End Sub ''End of "Private Sub RefreshElement_Field(sender As Object, e As EventArgs)"


    Private Sub GiveSizeInfo_Field(sender As Object, e As EventArgs)
        ''
        ''Added 7/31/2019 thomas downes
        ''
        Dim strMessageToUser As String = ""

        strMessageToUser &= (vbCrLf & $"Height of Picture control: {pictureLabel.Height}")
        strMessageToUser &= (vbCrLf & $"Height of Custom Graphics control: {Me.Height}")
        strMessageToUser &= (vbCrLf & $"Element-Base-Info Property (Height): {Me.ElementInfo_Base.Height_Pixels}")
        strMessageToUser &= (vbCrLf & $"Picture control's Image Height: {pictureLabel.Image.Height}")

        MessageBox.Show(strMessageToUser, "994938", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub ''End of "Private Sub GiveSizeInfo_Field(sender As Object, e As EventArgs)"


    Private Sub Open_Dialog_Color(sender As Object, e As EventArgs)
        ''
        ''Added 7/30/2019 thomas downes
        ''
        ColorDialog1.ShowDialog()

        ''7/30/2019 td''Me.ElementInfo.FontColor = ColorDialog1.Color
        ''8/29/2019 td''Me.ElementInfo.BackColor = ColorDialog1.Color
        Me.ElementInfo_Base.Back_Color = ColorDialog1.Color

        Me.ElementInfo_Base.Width_Pixels = Me.Width
        Me.ElementInfo_Base.Height_Pixels = Me.Height

        Application.DoEvents()
        Application.DoEvents()

        Refresh_Image(True)
        Me.Refresh()

    End Sub ''eNd of "Private Sub Open_Dialog_Color()"


    Private Sub Open_Dialog_Font(sender As Object, e As EventArgs)
        ''
        ''Added 7/30/2019 thomas downes
        ''
        FontDialog1.Font = Me.ElementInfo_TextOnly.Font_DrawingClass
        FontDialog1.ShowDialog()

        Me.ElementInfo_TextOnly.Font_DrawingClass = FontDialog1.Font

        Application.DoEvents()
        Application.DoEvents()

        Refresh_Image(True)
        Me.Refresh()

    End Sub ''eNd of "Private Sub opendialog_Color()"


    Private Sub SaveInfo_ToModel(sender As Object, e As EventArgs)
        ''
        ''Added 12/17/2019 thomas downes
        ''
        SaveToModel()

    End Sub ''eNd of "Private Sub Save_ToModel()"


    Public Overrides Function Rotated_90_270(pbCheckRotationIsDone As Boolean,
                          Optional ByRef pref_bRotationIsDone As Boolean = False) As Boolean
        ''
        ''Added 9/23/2019 thomas d.  
        ''
        ''  This function is the numerical equivalent of, Portrait vs. Landscape.
        ''   (This function purposely _ignores_ the rotational distinction
        ''   between 180 degrees & 360 degrees. ----9/23/2019 td)
        ''
        Dim boolTextImageRotated_0_180 As Boolean ''Added 9/23/2019 thomas d.  

        Select Case Me.ElementClass_Obj.OrientationInDegrees

            Case 90, 270

                If (pbCheckRotationIsDone) Then ''Added 1/28/2022
                    ''Double-check the orientation.  ----9/23/2019 td
                    boolTextImageRotated_0_180 = (Me.pictureLabel.Image.Width > Me.pictureLabel.Image.Height)
                    If (boolTextImageRotated_0_180) Then
                        ''Jan2022 ''Throw New Exception("Image dimensions are Not expected.")
                        pref_bRotationIsDone = False ''Added 1/28/2022 
                    Else
                        pref_bRotationIsDone = True ''Added 1/28/2022 
                    End If ''End of "If (boolImageRotated_0_180) Then ... Else .."
                End If ''End of ""If (pbCheckRotationIsDone) Then""

                Return True

            Case Else : Return False

        End Select ''ENd of "Select Case Me.ElementClass_Obj.OrientationInDegrees"

    End Function ''End of "Public Function Rotated_90_270() As Boolean"


    Private Sub PictureLabel_MouseClick(sender As Object, e As MouseEventArgs) Handles pictureLabel.MouseClick
        ''
        ''Added 7/30/2019 thomas downes
        ''
        Dim boolRightClick As Boolean
        Dim boolHoldingCtrlKey As Boolean ''Added 7/31/2019 thomas downes  

        ''8/1/2019 td''Dim new_item_fieldname As ToolStripMenuItem
        ''8/1/2019 td''Dim new_item_field As ToolStripMenuItem

        Dim new_item_menuHeader1 As ToolStripMenuItem ''Added 12/15/2021 td
        Dim new_item_menuHeader2 As ToolStripMenuItem ''Added 12/15/2021 td
        Dim new_item_menuHeader3 As ToolStripMenuItem ''Added 12/15/2021 td
        Dim new_item_separator As ToolStripMenuItem ''Added 12/15/2021 td

        Dim new_item_colors As ToolStripMenuItem
        Dim new_item_font As ToolStripMenuItem
        Dim new_item_refresh As ToolStripMenuItem ''Added 7/31/2019 td
        Dim new_item_sizeInfo As ToolStripMenuItem ''Added 7/31/2019 td
        Dim new_item_saveToModel As ToolStripMenuItem ''Added 12/17/2021 td

        boolRightClick = (e.Button = MouseButtons.Right)

        ''I need to be able to determine if the SHIFT or CTRL keys were pressed when the application is launched
        ''     https://stackoverflow.com/questions/22476342/how-to-determine-if-the-shift-or-ctrl-key-was-pressed-when-launching-the-applica
        ''
        boolHoldingCtrlKey = (My.Computer.Keyboard.CtrlKeyDown) ''Added 7/31/2019 td

        ''Added 7/30/2019 thomas downes
        If (boolRightClick) Then

            ''Added 7/30/2019 thomas downes
            ''ContextMenuStrip1.Items.Clear()

            If (0 = ContextMenuStrip1.Items.Count) Then
                ''
                ''Information about programmatical context. 
                ''
                new_item_menuHeader1 = New ToolStripMenuItem("CtlGraphicStaticText.vb")
                new_item_menuHeader2 = New ToolStripMenuItem("  (in ciBadgeDesigner\Controls\ )")
                new_item_menuHeader3 = New ToolStripMenuItem("  (Private Sub pictureLabel_MouseClick)")
                new_item_separator = New ToolStripMenuItem("-----------")

                new_item_menuHeader1.BackColor = Color.Aqua
                new_item_menuHeader2.BackColor = Color.Aqua
                new_item_menuHeader3.BackColor = Color.Aqua
                new_item_separator.BackColor = Color.Aqua

                new_item_refresh = New ToolStripMenuItem("Refresh Element - EST100") ''Added 7/31/2019 td
                new_item_sizeInfo = New ToolStripMenuItem("Size Information - EST101") ''Added 7/31/2019 td
                new_item_saveToModel = New ToolStripMenuItem("Save Position To Model - EST102") ''Added 12/13/2021 td

                new_item_colors = New ToolStripMenuItem("Set Colors - EST102")
                new_item_font = New ToolStripMenuItem("Set Font - EST103")

                AddHandler new_item_colors.Click, AddressOf Open_Dialog_Color
                AddHandler new_item_font.Click, AddressOf Open_Dialog_Font

                AddHandler new_item_refresh.Click, AddressOf RefreshElement_Field ''Added 7/31/2019 thomas d.
                AddHandler new_item_sizeInfo.Click, AddressOf GiveSizeInfo_Field ''Added 7/31/2019 thomas d.

                ''Added 12/17/2021 td
                AddHandler new_item_saveToModel.Click, AddressOf SaveInfo_ToModel ''Added 12/17/2021 thomas d.

                ''Added 12/15/2021 td
                ContextMenuStrip1.Items.Add(new_item_menuHeader1) ''Added 12/15/2021 thomas d. 
                ContextMenuStrip1.Items.Add(new_item_menuHeader2) ''Added 12/15/2021 thomas d. 
                ContextMenuStrip1.Items.Add(new_item_menuHeader3) ''Added 12/15/2021 thomas d. 
                ContextMenuStrip1.Items.Add(new_item_separator) ''Added 12/15/2021 thomas d.

                ContextMenuStrip1.Items.Add(new_item_colors)
                ContextMenuStrip1.Items.Add(new_item_font)

                ContextMenuStrip1.Items.Add(new_item_refresh) ''Added 7/31/2019 thomas d.  
                ContextMenuStrip1.Items.Add(new_item_sizeInfo) ''Added 7/31/2019 thomas d.  
                ContextMenuStrip1.Items.Add(new_item_saveToModel) ''Added 12/17/2021 thomas d.  

            End If ''End of "If (0 = ContextMenuStrip1.Items.Count) Then"

            ''Dec.15 2021''ContextMenuStrip1.Show(e.Location.X + Me.ParentForm.Left,
            ''Dec.15 2021''                       e.Location.Y + Me.Top + Me.ParentForm.Top)
            ContextMenuStrip1.Show(e.Location.X + Me.Left + Me.ParentForm.Left,
                                   e.Location.Y + Me.Top + Me.ParentForm.Top)


        ElseIf (boolHoldingCtrlKey) Then ''Added 7/31/2019 thomas downes
            ''
            ''Added 7/31/2019 thomas downes  
            ''
            ''pictureLabel.BorderStyle = BorderStyle.FixedSingle
            ''
            ''Place a 6-pixel margin around the control, with a yellow color.
            ''   (This will indicate selection.)   ----7/3/2019
            ''
            Me.BackColor = Color.Yellow
            pictureLabel.Top = 6
            pictureLabel.Left = 6
            pictureLabel.Width = Me.Width - 2 * 6
            pictureLabel.Height = Me.Height - 2 * 6

        End If ''End of "If (boolRightClick) Then .... Else ...."

    End Sub

    Private Sub CtlGraphicFldLabel_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        ''
        ''Addd 7/31/2019 td
        ''
        If (Me.ElementInfo_Base IsNot Nothing) Then

            Const c_bAvoidAntiflowDesign As Boolean = True ''Avoid "BadDesign" / "bad design".  ---Added 12/21/2021 & 9/23/2019 td

            If (c_bAvoidAntiflowDesign) Then

                ''The "Else" code (below) violates the "Fields-->Elements-->UserGraphicsControl-->Layout"
                ''   sequence, since it supports a "UserGraphicsControl-->Element" flow.   That 
                ''   flow (UserGraphicsControl-->Element) is maybe okay in some respects, !perhaps!, 
                ''   but probably not here.
                ''   -----12/21/2021 & 9/23/2019 td
                ''
            Else

                Me.ElementInfo_Base.Width_Pixels = Me.Width
                Me.ElementInfo_Base.Height_Pixels = Me.Height

                ''Added 9/4/2019 td
                ''9/12/2019 td''Me.ElementInfo_Base.LayoutWidth_Pixels = Me.FormDesigner.Layout_Width_Pixels()
                ''10/01/2019 td''Me.ElementInfo_Base.BadgeLayout.Width_Pixels = Me.FormDesigner.Layout_Width_Pixels()
                ''10/01/2019 td''Me.ElementInfo_Base.BadgeLayout.Height_Pixels = Me.FormDesigner.Layout_Height_Pixels()

                ''Jan8 2022 td''If (Me.LayoutFunctions IsNot Nothing) Then
                ''Jan8 2022 td''   Me.ElementInfo_Base.BadgeLayout.Width_Pixels = Me.LayoutFunctions.Layout_Width_Pixels()
                ''Jan8 2022 td''   Me.ElementInfo_Base.BadgeLayout.Height_Pixels = Me.LayoutFunctions.Layout_Height_Pixels()
                ''Jan8 2022 td''End If ''End of "If (Me.LayoutFunctions IsNot Nothing) Then"

                If (mod_iLayoutFunctions IsNot Nothing) Then
                    Me.ElementInfo_Base.BadgeLayout.Width_Pixels = mod_iLayoutFunctions.Layout_Width_Pixels()
                    Me.ElementInfo_Base.BadgeLayout.Height_Pixels = mod_iLayoutFunctions.Layout_Height_Pixels()
                End If ''End of "If (mod_iLayoutFunctions IsNot Nothing) Then"

                ''12/21/2021''Me.Refresh_Image(True)
                Me.Refresh_Image(False, False, False, False)

            End If ''End of "If (c_bAvoidAntiflowDesign) Then ... Else ...."

        End If ''End of "If (Me.ElementInfo_Base IsNot Nothing) Then"

    End Sub

    Private Sub PictureLabel_Click(sender As Object, par_event As EventArgs) Handles pictureLabel.Click

        ''Added 12/15/2021 td
        ''
        ''  See "Handles pictureLabel.MouseClick()".  ----12/15/2021 td 
        ''
        Dim objArgs As New MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0) ''Added 1/1/2022 td
        ''objArgs.X = par_event.

        ''Jan1 2022 td''If (False) Then PictureLabel_MouseClick(sender, e))
        If (False) Then PictureLabel_MouseClick(sender, CType(par_event, MouseEventArgs))

    End Sub

    Public Sub EnableDragAndDrop_Moveable() Implements IMoveableElement.EnableDragAndDrop_Moveable
        ''Added 12/17/2021 td  
        Throw New NotImplementedException()
    End Sub

    Public Sub DisableDragAndDrop_Unmoveable() Implements IMoveableElement.DisableDragAndDrop_Unmoveable
        ''Added 12/17/2021 td  
        Throw New NotImplementedException()
    End Sub

    Public Function GetPictureBox() As PictureBox Implements IMoveableElement.GetPictureBox
        ''Added 12/17/2021 td  
        ''---Throw New NotImplementedException()
        Return pictureLabel

    End Function

    Private Sub LinkInvisible_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkInvisible.LinkClicked
        ''
        ''Confirm, then render visible on the Badge. 
        ''
        Dim diagReply As DialogResult
        Dim bPriorlyInvisible As Boolean

        bPriorlyInvisible = (Not ElementInfo_Base.Visible)

        If (bPriorlyInvisible) Then

            ''Added 12/27/2021 td
            diagReply = MessageBox.Show("Confirm via Yes (or OK) that you want this element to be rendered visibly on the Badge.", "", MessageBoxButtons.YesNoCancel,
               MessageBoxIcon.Question)

            If (diagReply = DialogResult.OK) Then diagReply = DialogResult.Yes

            If (diagReply = DialogResult.Yes) Then

                LinkInvisible.Text = "Now visible."
                ElementInfo_Base.Visible = True
                ''Added 12/27/2021 td
                ''   This is making use of the Dependency Injection pattern.
                ParentDesignForm_iRefreshPreview.RefreshCardPreview()

            End If ''End of "If (diagReply = DialogResult.Yes) Then"

        Else

            ''Added 12/27/2021 td
            diagReply = MessageBox.Show("Confirm via Yes (or OK) that you want this element to be NOT! repeat NOT! rendered (display) on the Badge.", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            If (diagReply = DialogResult.OK) Then diagReply = DialogResult.Yes

            If (diagReply = DialogResult.Yes) Then

                LinkInvisible.Text = LinkInvisible.Tag.ToString() ''Says "Won't appear on ID Card".
                ElementInfo_Base.Visible = False
                ''Added 12/27/2021 td
                ''   This is making use of the Dependency Injection pattern.
                ParentDesignForm_iRefreshPreview.RefreshCardPreview()

            End If ''End of "If (diagReply = DialogResult.Yes) Then"

        End If ''End of "If (bPriorlyInvisible) Then ... Else ..."

    End Sub

    Private Sub LinkInvisible_DpiChangedAfterParent(sender As Object, e As EventArgs) ''---Handles LinkInvisible.DpiChangedAfterParent

    End Sub

    Private Sub pictureLabel_MouseDown(par_sender As Object, par_e As MouseEventArgs) Handles pictureLabel.MouseDown
        ''
        ''Added 1/07/2022 td 
        ''
        ''----Nasty bug.  Don't use par_sender here. ---1/11/2022 td''
        ''--MyBase.MoveableControl_MouseDown(par_sender, par_e)

        If MyBase.mod_bHandleMouseMoveEvents_ByVB6 Then
            If MyBase.mod_bHandleMouseMoveEvents_BaseClass Then
                ''
                ''I highly recommend putting breakpoints in the base class, instead of here. 
                ''
            ElseIf MyBase.mod_bHandleMouseMoveEvents_ChildClass Then
                ''----Nasty bug.  Don't use par_sender here. ---1/11/2022 td''
                ''--MyBase.MoveableControl_MouseDown(par_sender, par_e)
                Dim objParentControl As Control = Me ''Added 1/11/2022
                MyBase.MoveableControl_MouseDown(objParentControl, par_e)
            End If
        End If

    End Sub

    Private Sub pictureLabel_MouseMove(par_sender As Object, par_e As MouseEventArgs) Handles pictureLabel.MouseMove

        ''Added 1/07/2022 thomas downes

        ''----Nasty bug.  Don't use par_sender here. ---1/11/2022 td''
        ''--MyBase.MoveableControl_MouseMove(par_sender, par_e)

        If MyBase.mod_bHandleMouseMoveEvents_ByVB6 Then
            If MyBase.mod_bHandleMouseMoveEvents_BaseClass Then
                ''
                ''I highly recommend putting breakpoints in the base class, instead of here. 
                ''
            ElseIf MyBase.mod_bHandleMouseMoveEvents_ChildClass Then
                ''----Nasty bug.  Don't use par_sender here. ---1/11/2022 td''
                ''--MyBase.MoveableControl_MouseMove(par_sender, par_e)
                Dim objParentControl As Control = Me ''Added 1/11/2022
                MyBase.MoveableControl_MouseMove(objParentControl, par_e)
            End If
        End If

    End Sub

    Private Sub pictureLabel_MouseUp(par_sender As Object, par_e As MouseEventArgs) Handles pictureLabel.MouseUp

        ''Added 1/07/2022 thomas downes

        ''----Nasty bug.  Don't use par_sender here. ---1/11/2022 td''
        ''--MyBase.MoveableControl_MouseUp(par_sender, par_e)

        If MyBase.mod_bHandleMouseMoveEvents_ByVB6 Then
            If MyBase.mod_bHandleMouseMoveEvents_BaseClass Then
                ''
                ''I highly recommend putting breakpoints in the base class, instead of here. 
                ''
            ElseIf MyBase.mod_bHandleMouseMoveEvents_ChildClass Then
                ''----Nasty bug.  Don't use par_sender here. ---1/11/2022 td''
                ''--MyBase.MoveableControl_MouseUp(par_sender, par_e)
                Dim objParentControl As Control = Me ''Added 1/11/2022
                MyBase.MoveableControl_MouseUp(objParentControl, par_e)
            End If
        End If

    End Sub


    Public Overrides Sub RemoveMouseEventHandlers_ChildClass()
        ''
        ''Added 1/12/2022 
        ''
        RemoveHandler pictureLabel.MouseDown, AddressOf pictureLabel_MouseDown
        RemoveHandler pictureLabel.MouseMove, AddressOf pictureLabel_MouseMove
        RemoveHandler pictureLabel.MouseUp, AddressOf pictureLabel_MouseUp

    End Sub ''End of "Public Overrides Sub RemoveMouseEventHandlers()"


    Public Overrides Sub AddMouseEventHandlers_ChildClass()
        ''
        ''Added 1/12/2022 
        ''
        RemoveHandler pictureLabel.MouseDown, AddressOf pictureLabel_MouseDown
        RemoveHandler pictureLabel.MouseMove, AddressOf pictureLabel_MouseMove
        RemoveHandler pictureLabel.MouseUp, AddressOf pictureLabel_MouseUp

        AddHandler pictureLabel.MouseDown, AddressOf pictureLabel_MouseDown
        AddHandler pictureLabel.MouseMove, AddressOf pictureLabel_MouseMove
        AddHandler pictureLabel.MouseUp, AddressOf pictureLabel_MouseUp

    End Sub ''End of "Public Overrides Sub AddMouseEventHandlers()"


End Class
