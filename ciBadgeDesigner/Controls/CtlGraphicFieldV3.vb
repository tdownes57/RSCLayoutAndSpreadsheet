Option Explicit On ''Added 8/29/2019 td
Option Strict On ''Added 8/29/2019 td
Option Infer Off ''Added 8/29/2019 td  

''
''Added 7/25/2019 thomas d 
''
Imports ciBadgeInterfaces ''Added 8/28/2019 thomas downes 
''10/1/2019 td''Imports ciBadgeFields ''Added 9/18/2019 thomas downes 
Imports ciBadgeElements ''Added 9/18/2019 td 
Imports ciBadgeElemImage ''Added 9/20/2019 td 
Imports System.Windows.Forms ''Added 10/1/2019 td
Imports System.Drawing ''Added 10/1/2019 td  
Imports __RSCWindowsControlLibrary ''Added 1/4/2022 thomas d. 

Public Enum EnumReminderMsg
    Undetermined
    NotCurrentlyInUse
    TransparentBackground
    OpaqueBackground
End Enum ''ENd of "Public Enum EnumReminderMsg"


Public Class CtlGraphicFieldV3
    Implements ISaveToModel ''Added 12/17/2021 td 
    Implements IMoveableElement ''Added 12/17/2021 td
    Implements IClickableElement ''Added 12/17/2021 td 
    ''
    ''Added 7/25/2019 thomas d 
    ''
    ''9/3/2019 td''Public Shared Generator As ClassLabelToImage
    Public Shared LabelToImage As ClassLabelToImage

    ''Added 9/13/2019 td  
    Public Shared UseExampleValues As Boolean

    Public Shared Function GetFieldElement(par_parametersGetElementControl As ClassGetElementControlParams,
                                           par_elementFld As ClassElementFieldV3,
                                           par_formParent As Form,
                                           par_oDesigner As ClassDesigner,
                                      par_nameOfControl As String,
                                      par_iLayoutFun As ILayoutFunctions,
                                           par_sizeNeeded As Size,
                                par_iRecordLastTouched As IRecordElementLastTouched,
                                par_iControlLastTouched As ILastControlTouched,
                                par_oMoveEventsForGroupedCtls As GroupMoveEvents_Singleton) As CtlGraphicFieldV3
        ''
        ''Added 1/04/2021 td
        ''
        ''//Const c_enumElemType As EnumElementType = EnumElementType.Field
        Const bAddFunctionalitySooner As Boolean = False
        Const bAddFunctionalityLater As Boolean = True

        Dim typeOps As Type
        Dim objOperations As Object ''Added 12/29/2021 td 
        Dim objOperationsFldElem As Operations_FieldV3 ''Added 12/31/2021 td 
        Dim sizeFieldElement As Size ''Added 1/26/2022 td

        ''Instantiate the Operations Object. 
        objOperationsFldElem = New Operations_FieldV3() ''Added 1/1/2022 td
        typeOps = objOperationsFldElem.GetType()
        objOperations = objOperationsFldElem

        If (objOperations Is Nothing) Then
            ''Added 12/29/2021
            Throw New Exception("Ops is Nothing, so I guess Element Type is Undetermined.")
        End If ''end of "If (objOperations Is Nothing) Then"

        ''Added 12/2/2022 td
        Dim enumElementType_Enum As EnumElementType = EnumElementType.Field

        ''Create the control.
        Dim CtlFieldElem1 As CtlGraphicFieldV3

        ''Public Sub New(par_elementField As ClassElementField,
        ''                par_layout As ILayoutFunctions,
        ''                pstrWhyWasICreated As String,
        ''                par_formRecordLastTouched As IRecordElementLastTouched)

        CtlFieldElem1 = New CtlGraphicFieldV3(par_elementFld,
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

        With CtlFieldElem1
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
        infoOps.CtlCurrentElement = CtlFieldElem1

        ''Added 1/17/2022 td 
        infoOps.ElementsCacheManager = par_parametersGetElementControl.ElementsCacheManager

        ''Added 1/24/2022 thomas d. 
        With objOperationsFldElem

            .CtlCurrentControl = CtlFieldElem1
            .CtlCurrentElement = CtlFieldElem1
            .CtlCurrentElementField = CtlFieldElem1 ''Added 1/24/2022 td
            ''.Designer = par_oMoveEventsForGroupedCtls.
            .Designer = par_parametersGetElementControl.DesignerClass
            .ElementInfo_Base = par_elementFld
            .ElementInfo_TextOnly = par_elementFld ''Added 2/2/2022 td
            .ElementsCacheManager = par_parametersGetElementControl.ElementsCacheManager
            .Element_Type = Enum_ElementType.StaticGraphic
            .EventsForMoveability_Group = par_oMoveEventsForGroupedCtls
            .EventsForMoveability_Single = Nothing
            .LayoutFunctions = .Designer ''Added 1/24/2022 td
            ''Feb2 2022 td''.MonemMovement_SingleCntrl = CtlFieldElem1.mod_iMoveOrResizeFunctionality ''Added 2/02/2022 td
            .Monem_iMoveOrResizeFun = CtlFieldElem1.mod_iMoveOrResizeFunctionality ''Added 2/02/2022 td

        End With ''End of "With objOperationsFldElem"

        Return CtlFieldElem1

    End Function ''end of "Public Shared Function GetFieldElement() As CtlGraphicFldLabel"


    Public DatetimeSaved As Date ''Added 11/29/2021 

    Public Event ElementField_RightClicked(par_control As CtlGraphicFieldV3) ''Added 10/1/2019 td

    ''7/26/2019 td''Public FieldInfo As ClassFieldCustomized
    ''7/26/2019 td''Public ElementInfo As ClassElementText
    Public FieldInfo As ICIBFieldStandardOrCustom

    Public Enum_ReminderMsg As EnumReminderMsg = EnumReminderMsg.NotCurrentlyInUse ''Added 10/17/2019 td 

    ''#1 8/29/2019 td''Public ElementInfo As ClassElementText
    '' #2 8/29/2019 td''Public ElementInfo_Text As ClassElementText

    Public ElementClass_ObjV3 As ClassElementFieldV3 ''Added 9/4/2019 thomas downes
    Public ElementClass_ObjV4 As ClassElementFieldOrTextV4 ''Added 2/04/2022 thomas downes

    ''Jan5 2022''Public ElementClass_Obj_Copy As ClassElementField ''Added 1/05/2022 thomas downes
    Public ElementInfo_TextOnly As ciBadgeInterfaces.IElement_TextOnly ''Modifield 10/12/2019
    ''1/12/2022 td''Public ElementInfo_Base As ciBadgeInterfaces.IElement_Base
    ''12/31/2021 td''Public ElementInfo_Field As ciBadgeInterfaces.IElement_TextField ''Added 10/12/2019 td
    Public ElementInfo_TextField As ciBadgeInterfaces.IElement_TextField ''Added 12/31/2021 td

    Public GroupEdits As ISelectingElements ''Added 7/31/2019 thomas downes  
    Public SelectedHighlighting_Denigrated As Boolean ''Added 8/2/2019 td
    Public ExampleTextToDisplay As String = "" ''Added 9/19/2019 td

    ''Added 11/28/2021 thomas downes
    Public WhyWasICreated As String = "" ''Added 11/28/2021 td

    ''
    ''Added 8/5/2019 td
    ''   This is to store the initial Width & Height, when resizing.
    ''
    ''Denigrated. 9/19/2019 td''Public FormDesigner As FormDesignProtoTwo ''Added 8/9/2019 td  
    Public LayoutFunctions As ciBadgeInterfaces.ILayoutFunctions ''Added 8/9/2019 td  
    Public ParentDesigner As ClassDesigner = Nothing ''Added 1/5/2022 td

    ''Jan10 2022 td''Public TempResizeInfo_W As Integer = 0 ''Intial resizing width.  (Before any adjustment is made.)
    ''Jan10 2022 td''Public TempResizeInfo_H As Integer = 0 ''Intial resizing height.  (Before any adjustment is made.)

    ''''Added 8/12/2019 Thomas Downes 
    ''Jan10 2022 td''Public TempResizeInfo_Left As Integer = 0 ''Intial resizing Left.  (Before any adjustment is made.)
    ''Jan10 2022 td''Public TempResizeInfo_Top As Integer = 0 ''Intial resizing Top.  (Before any adjustment is made.)

    ''
    ''Private variables.  
    ''

    ''10/17/2019 td''Private mod_includedInGroupEdit As Boolean ''Added 8/1/2019 thomas downes 

    Private Const mod_c_boolMustSetBackColor As Boolean = False ''False, since we have an alternate Boolean 
    ''   below which works fine (i.e. mod_c_bRefreshMustReinitializeImage = True).
    ''   We don't need to set the Background Color of the PictureBox control.  ----7/31/2019 thomas d. 

    Private Const mod_c_bRefreshMustResizeImage As Boolean = True ''True, since otherwise the background color 
    ''  is (frustratingly) limited to the original control size, _NOT_ the resized control's full area
    ''  (enlarged via user click-and-drag), unfortunately.  ----7/31/2019 thomas d.  
    Private mod_singleDummy As Single = 0 ''Added 1/4/2022 td

    Public ReadOnly Property Picture_Box As PictureBox
        Get
            ''Added 7/28/2019 td 
            Return Me.pictureLabel
        End Get
    End Property

    Public ReadOnly Property Textbox_ExampleValue As TextBox
        Get
            ''Added 10/17/2019 td 
            Return Me.textTypeExample
        End Get
    End Property

    Public Sub New(pstrWhyCreated As String)

        ' This call is required by the designer.
        InitializeComponent()

        ''Added 9/19/2019 td
        ''9/19/2019 td''Throw New NotImplementedException("This initializer is not allowed.  A element-of-field must be supplied.")

        ''Added 11/28/2021 thomas d.
        WhyWasICreated = pstrWhyCreated

    End Sub


    Public Sub New(par_elementField As ClassElementFieldV3,
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
                        par_oParentForm, False,
                        par_iLayoutFun, par_iRefreshPreview, par_iSizeDesired,
                        par_operationsType, par_operationsAny,
                        pboolAddMoveability, pboolAddClickability,
                        par_iLastTouched, par_oMoveEvents,
                        par_singleDummy) ''---mod_singleDummy)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.FieldInfo = par_elementField.FieldInfo
        Me.ParentDesigner = par_oDesigner ''Added 1/5/2022 td

        Me.ElementClass_ObjV3 = par_elementField
        Me.ElementInfo_Base = CType(par_elementField, IElement_Base)
        ''10/12/2019 td''Me.ElementInfo_Text = CType(par_elementField, IElement_TextField)
        Me.ElementInfo_TextOnly = CType(par_elementField, IElement_TextOnly) ''Modified 10/12/2019 td
        ''1/2/2022 td''Me.ElementInfo_Field = CType(par_elementField, IElement_TextField) ''Added 10/12/2019 td
        Me.ElementInfo_TextField = CType(par_elementField, IElement_TextField) ''Added 10/12/2019 td

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

    ''Public Sub New_NotInUse(par_field As ICIBFieldStandardOrCustom)

    ''    ' This call is required by the designer.
    ''    InitializeComponent()

    ''    ' Add any initialization after the InitializeComponent() call.
    ''    Me.FieldInfo = par_field

    ''    ''9/4/2019 td''Me.ElementInfo_Text = New ClassElementText(Me)

    ''    Dim obj_elementText As ClassElementField ''Added 9/4/2019 thomas d.
    ''    obj_elementText = New ClassElementField(Me) ''Added 9/4/2019 thomas d.
    ''    Me.ElementClass_Obj = obj_elementText ''Added 9/4/2019 thomas d.
    ''    Me.ElementInfo_Base = CType(obj_elementText, IElement_Base) ''Added 9/4/2019 thomas d.
    ''    Me.ElementInfo_Text = CType(obj_elementText, IElement_TextField)  ''Added 9/4/2019 thomas d.

    ''End Sub

    ''Public Sub New_Deprecated(par_field As ClassFieldStandard,
    ''               Optional par_formDesigner As FormDesignProtoTwo = Nothing,
    ''               Optional par_elementText As ClassElementField = Nothing)

    ''    ' This call is required by the designer.
    ''    InitializeComponent()

    ''    ' Add any initialization after the InitializeComponent() call.
    ''    Me.FieldInfo = par_field

    ''    ''Added 9/3/2019 thomas downes
    ''    ''9/4/2019 td''Me.ElementInfo_Base = CType(par_field.ElementInfo, IElement_Base)

    ''    ''9/3/2019 td''Me.ElementInfo_Text = par_field.ElementInfo
    ''    ''9/4/2019 td''Me.ElementInfo_Text = CType(par_field.ElementInfo, IElement_Text)

    ''    ''
    ''    ''Refactored 9/4/2019 td  
    ''    ''
    ''    If (par_elementText Is Nothing) Then
    ''        ''This Sub New is deprecated.---9/18/2019 td''Me.ElementClass_Obj = par_field.ElementFieldClass
    ''        Me.ElementInfo_Base = CType(Me.ElementClass_Obj, IElement_Base)
    ''        Me.ElementInfo_Text = CType(Me.ElementClass_Obj, IElement_TextField)
    ''    Else
    ''        ''
    ''        ''Added 9/4/2019 thomas d.
    ''        ''
    ''        ''This Sub New is deprecated.---9/18/2019 td''Me.ElementClass_Obj = par_elementText
    ''        Me.ElementInfo_Base = CType(par_elementText, IElement_Base)
    ''        Me.ElementInfo_Text = CType(par_elementText, IElement_TextField)
    ''    End If ''End of "If (par_elementText Is Nothing) Then .... Else ...."

    ''    ''Added 8/9/2019 td
    ''    ''Denigrated. ---9/19/2019 td''Me.FormDesigner = par_formDesigner

    ''End Sub

    ''Public Sub New_Deprecated(par_field As ClassFieldCustomized,
    ''               Optional par_formDesigner As FormDesignProtoTwo = Nothing,
    ''               Optional par_elementText As ClassElementField = Nothing)

    ''    ' This call is required by the designer.
    ''    InitializeComponent()

    ''    ' Add any initialization after the InitializeComponent() call.
    ''    Me.FieldInfo = par_field

    ''    ''Added 9/3/2019 thomas downes
    ''    ''9/4/2019 td''Me.ElementInfo_Base = CType(par_field.ElementInfo, IElement_Base)

    ''    ''9/3/2019 td''Me.ElementInfo_Text = par_field.ElementInfo
    ''    ''#1 9/4/2019 td''Me.ElementInfo_Text = CType(par_field.ElementInfo, IElement_Text)

    ''    ''
    ''    ''Refactored 9/4/2019 td  
    ''    ''
    ''    '' #2 9/4/2019 td''Me.ElementClass_Obj = par_field.ElementInfo
    ''    '' #2 9/4/2019 td''Me.ElementInfo_Base = CType(Me.ElementClass_Obj, IElement_Base)
    ''    '' #2 9/4/2019 td''Me.ElementInfo_Text = CType(Me.ElementClass_Obj, IElement_Text)

    ''    ''
    ''    ''Refactored 9/4/2019 td  
    ''    ''
    ''    If (par_elementText Is Nothing) Then
    ''        ''This Sub New is deprecated.  ---9/18/2019 td''Me.ElementClass_Obj = par_field.ElementFieldClass
    ''        Me.ElementInfo_Base = CType(Me.ElementClass_Obj, IElement_Base)
    ''        Me.ElementInfo_Text = CType(Me.ElementClass_Obj, IElement_TextField)
    ''    Else
    ''        ''
    ''        ''Added 9/4/2019 thomas d.
    ''        ''
    ''        Me.ElementClass_Obj = par_elementText
    ''        Me.ElementInfo_Base = CType(par_elementText, IElement_Base)
    ''        Me.ElementInfo_Text = CType(par_elementText, IElement_TextField)
    ''    End If ''End of "If (par_elementText Is Nothing) Then .... Else ...."

    ''    ''Added 8/9/2019 td
    ''    ''Denigrated. ---9/19/2019 td''Me.FormDesigner = par_formDesigner

    ''End Sub ''ENd of "Public Sub New_Deprecated"

    ''Public Sub New_Deprecated(par_field As ICIBFieldStandardOrCustom,
    ''               Optional par_formDesigner As FormDesignProtoTwo = Nothing,
    ''               Optional par_elementText As ClassElementField = Nothing)

    ''    ' This call is required by the designer.
    ''    InitializeComponent()

    ''    ''
    ''    ' Add any initialization after the InitializeComponent() call.
    ''    ''
    ''    Me.FieldInfo = par_field

    ''    ''Added 9/3/2019 td
    ''    ''  9/4/2019 td''Me.ElementInfo_Base = CType(par_field.ElementInfo_Base, IElement_Base)
    ''    ''  9/4/2019 td''Me.ElementInfo_Text = CType(par_field.ElementInfo_Text, IElement_Text)

    ''    ''
    ''    ''Refactored 9/4/2019 td  
    ''    ''
    ''    If (par_elementText Is Nothing) Then
    ''        ''9/15/2019 td''Me.ElementClass_Obj = Nothing ''9/4/2019 td''par_field.ElementInfo

    ''        Me.ElementClass_Obj = New ClassElementField

    ''        ''
    ''        ''------ IMPORTANT ------------------
    ''        ''------ POTENTIALLY CONFUSING-------
    ''        ''
    ''        ''-------Fields no longer contain links to Elements. ---9/18/2019 td 
    ''        ''-----Me.ElementClass_Obj.LoadbyCopyingMembers(par_field.ElementInfo_Base, par_field.ElementInfo_Text)

    ''        ''  9/15/2019 td''Me.ElementInfo_Base = CType(par_field.ElementInfo_Base, IElement_Base)
    ''        ''  9/15/2019 td''Me.ElementInfo_Text = CType(par_field.ElementInfo_Text, IElement_Text)

    ''        Me.ElementInfo_Base = CType(Me.ElementClass_Obj, IElement_Base)
    ''        Me.ElementInfo_Text = CType(Me.ElementClass_Obj, IElement_TextField)

    ''    Else
    ''        ''
    ''        ''Added 9/4/2019 thomas d.
    ''        ''
    ''        Me.ElementClass_Obj = par_elementText
    ''        Me.ElementInfo_Base = CType(par_elementText, IElement_Base)
    ''        Me.ElementInfo_Text = CType(par_elementText, IElement_TextField)

    ''    End If ''End of "If (par_elementText Is Nothing) Then .... Else ...."

    ''    ''Added 9/3/2019 td
    ''    ''Denigrated. ---9/19/2019 td''Me.FormDesigner = par_formDesigner

    ''End Sub ''ENd of "Public Sub New_Deprecated"

    Public Sub Refresh_Master(Optional pboolDialogApplyButton As Boolean = False)
        ''
        ''Added 9/5/2019 thomas d 
        ''
        If (pboolDialogApplyButton) Then System.Diagnostics.Debugger.Break() ''Added 9/19/2019 td  
        If (pboolDialogApplyButton) Then MessageBox.Show(Me.LayoutFunctions.NameOfForm()) ''Added 9/19/2019 td  

        Refresh_PositionAndSize()

        ''#1 9/15 td''Refresh_Image
        '' #2 9/15 tdRefresh_Image(False)
        Refresh_ImageV3(False)

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


    Public Sub Refresh_PositionAndSize()
        ''
        ''Added 9/5/2019 thomas d 
        ''
        ''9/19/2019 td''Me.Left = Me.FormDesigner.Layout_Margin_Left_Add(Me.ElementInfo_Base.LeftEdge_Pixels)
        ''9/19/2019 td''Me.Top = Me.FormDesigner.Layout_Margin_Top_Add(Me.ElementInfo_Base.TopEdge_Pixels)

        Me.Left = Me.LayoutFunctions.Layout_Margin_Left_Add(Me.ElementInfo_Base.LeftEdge_Pixels)
        Me.Top = Me.LayoutFunctions.Layout_Margin_Top_Add(Me.ElementInfo_Base.TopEdge_Pixels)

        Me.Width = Me.ElementInfo_Base.Width_Pixels
        Me.Height = Me.ElementInfo_Base.Height_Pixels

    End Sub ''End of "Public Sub Refresh_PositionAndSize()"


    Public Overrides Sub Refresh_ImageV3(pbRefreshSize As Boolean,
                             Optional pboolResizeLabelControl As Boolean = True,
                             Optional pboolRefreshLabelControl As Boolean = True,
                             Optional pboolRefreshUserControl As Boolean = False,
                             Optional pobjElementField As ClassElementFieldV3 = Nothing)
        ''Feb1 2022 td''Public Overrides Sub Refresh_ImageV3(pbRefreshSize As Boolean,
        ''
        ''Added 7/25/2019 thomas d 
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
        ElementInfo_TextOnly.Text_Static = LabelText(pobjElementField)

        ''Me.ElementInfo.Width = pictureLabel.Width
        ''Me.ElementInfo.Height = pictureLabel.Height

        ''7/30/2019 td''Me.ElementInfo.Font_DrawingClass = Me.ParentForm.Font ''Me.Font
        ''7/30/2019 td''Me.ElementInfo.Font_DrawingClass = New Font("Times New Roman", 25, FontStyle.Italic)

        boolScaleFontSize = (Me.ElementInfo_TextOnly.FontSize_ScaleToElementYesNo)
        If (boolScaleFontSize And Me.ElementClass_ObjV3 Is Nothing) Then
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
                ''Jan28 2022''Me.ElementClass_Obj.Font_ScaleAdjustment(Me.ElementInfo_Base.Height_Pixels)
                ''Added 9/15/2019 thomas d.
                With Me.ElementInfo_Base ''Added 1/28/2022 td
                    If (Rotated_90_270(False) Or (.Width_Pixels < .Height_Pixels)) Then ''Added 1/28/2022 td
                        ''Use .Width_Pixels, since .Height_Pixels & .Width_Pixels
                        ''   have been switched due to rotation. ----1/28/2022 td
                        Me.ElementClass_ObjV3.Font_ScaleAdjustment(.Width_Pixels)
                    Else
                        Me.ElementClass_ObjV3.Font_ScaleAdjustment(.Height_Pixels)
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
        intBadgeLayoutWidth = Me.LayoutFunctions.Layout_Width_Pixels()

        ''9/4/2019 td''LabelToImage.TextImage(intLayoutWidth, pictureLabel.Image, Me.ElementInfo_Text, Me.ElementInfo_Base, boolRotated)

        ''
        ''Major call !!
        ''
        Dim newTextImage As Image ''Added 9/20/2019 td  

        Const c_boolUseNewestProjectReference As Boolean = True ''Added 9/20/2019 td 
        If (c_boolUseNewestProjectReference) Then

            ''Added 11-18-2019 td 
            Dim strTextToDisplay As String ''Added 11/18/2019 td
            strTextToDisplay = Me.ElementClass_ObjV3.LabelText_ToDisplay(True, Nothing,
                         CtlGraphicFieldV3.UseExampleValues)

            ''Added 12/21/2021 td
            strTextToDisplay = (strTextToDisplay & (" " & Me.ElementClass_ObjV3.CaptionSuffixIfNeeded).TrimEnd())

            ''11/18 td''newTextImage =
            ''   modGenerate.TextImage_ByElemInfo(Me.ElementClass_Obj.LabelText_ToDisplay(True),
            newTextImage =
            modGenerate.TextImage_ByElemInfo(strTextToDisplay,
                                             intBadgeLayoutWidth,
                                   Me.ElementInfo_TextOnly,
                                   Me.ElementInfo_Base,
                                   boolRotated, True)
        Else
            ''9/20/2019 td''pictureLabel.Image =
            newTextImage =
            LabelToImage.TextImage_Field(intBadgeLayoutWidth, Me.ElementInfo_TextOnly,
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
                pictureLabel.Width = intNewImageWidth ''Straightforward.   No reversal is needed here, despite the rotation. ---9/20 td
                Application.DoEvents()
                pictureLabel.Height = intNewImageHeight ''Straightforward.   No reversal is needed here, despite the rotation. ---9/20 td 
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

    End Sub ''End of Public Sub Refresh_ImageV3


    Public Sub SaveToModel() Implements ISaveToModel.SaveToModel
        ''
        ''Added 7/29/2019 thomas d 
        ''
        ''7/29 td''Me.ElementInfo.Info = CType(Me.ElementInfo, IElementText)

        ''Me.ElementInfo.Text = Me.LabelText()

        ''9/5/2019 td''Me.ElementInfo_Base.TopEdge_Pixels = Me.Top
        ''9/5/2019 td''Me.ElementInfo_Base.LeftEdge_Pixels = Me.Left

        ''9/19/2019 td''Me.ElementInfo_Base.TopEdge_Pixels = Me.FormDesigner.Layout_Margin_Top_Omit(Me.Top)
        ''9/19/2019 td''Me.ElementInfo_Base.LeftEdge_Pixels = Me.FormDesigner.Layout_Margin_Left_Omit(Me.Left)

        Me.ElementInfo_Base.TopEdge_Pixels = Me.LayoutFunctions.Layout_Margin_Top_Omit(Me.Top)
        Me.ElementInfo_Base.LeftEdge_Pixels = Me.LayoutFunctions.Layout_Margin_Left_Omit(Me.Left)

        ''Added 11/29/2021 td
        Me.ElementClass_ObjV3.DatetimeUpdated = Now ''Added 11/29/2021 td
        Dim intPixelsTop As Integer = Me.ElementClass_ObjV3.TopEdge_Pixels
        Dim intPixelsLeft As Integer = Me.ElementClass_ObjV3.LeftEdge_Pixels
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


    Public Overrides Function Rotated_90_270(pbCheckRotationIsDone As Boolean,
                          Optional ByRef pref_bRotationIsDone As Boolean = False) As Boolean
        ''Jan2022 ''Public Overrides Function Rotated_90_270() As Boolean
        ''
        ''Added 9/23/2019 thomas d.  
        ''
        ''  This function is the numerical equivalent of, Portrait vs. Landscape.
        ''   (This function purposely _ignores_ the rotational distinction
        ''   between 180 degrees & 360 degrees. ----9/23/2019 td)
        ''
        Dim boolTextImageRotated_0_180 As Boolean ''Added 9/23/2019 thomas d.  

        Select Case Me.ElementClass_ObjV3.OrientationInDegrees

            Case 90, 270

                If (pbCheckRotationIsDone) Then
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


    Public Overrides Function Rotated_0degrees() As Boolean
        ''
        ''Added 9/23/2019 thomas d.  
        ''
        Dim boolTextImageRotated_90_270 As Boolean ''Added 9/23/2019 thomas d.  

        Select Case Me.ElementClass_ObjV3.OrientationInDegrees

            Case 0, 360

                ''Double-check the orientation.  ----9/23/2019 td
                boolTextImageRotated_90_270 = (Me.pictureLabel.Image.Width < Me.pictureLabel.Image.Height)
                If (boolTextImageRotated_90_270) Then
                    Throw New Exception("Image dimensions are Not expected.")
                End If ''End of "If (boolImageRotated_90_270) Then"

                Return True

            Case Else : Return False

        End Select ''ENd of "Select Case Me.ElementClass_Obj.OrientationInDegrees"

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
        Dim boolTextImageRotated_90_270 As Boolean ''Added 9/23/2019 thomas d.  
        Const c_SemiCircle_Degrees As Integer = 180

        boolReturnValue = (0 = (Me.ElementClass_ObjV3.OrientationInDegrees Mod c_SemiCircle_Degrees))

        ''Double-check the orientation.  ----9/23/2019 td
        If (boolReturnValue) Then
            boolTextImageRotated_90_270 = (Me.pictureLabel.Image.Width < Me.pictureLabel.Image.Height)
            If (boolTextImageRotated_90_270) Then
                Throw New Exception("Image dimensions are Not expected.")
            End If ''End of "If (boolImageRotated_90_360) Then"
        End If ''End of "If (boolReturnValue) Then"

        Return boolReturnValue

    End Function ''End of "Public Function Rotated_180_360() As Boolean"


    Public Function LabelText(Optional par_objElementCopy As ClassElementFieldV3 = Nothing) As String
        ''
        ''Added 7/25/2019 thomas d 
        ''
        ''----Return Me.ElementClass_Obj.LabelText_ToDisplay(True)
        If (Me.ElementClass_ObjV3 Is Nothing) Then

            If (par_objElementCopy Is Nothing) Then
                ''Added 12/2/2021 thomas downes
                MessageBox.Show("Error, ElementClassObject is null.")
                Return "Error, ElementClassObject is null."
            Else
                ''Added 1/5/2022 td 
                Return par_objElementCopy.LabelText_ToDisplay(True)

            End If ''End of "If (par_objElementCopy Is Nothing) Then ... Else ...."

        Else
            Return Me.ElementClass_ObjV3.LabelText_ToDisplay(True)

        End If ''ENd of "If (Me.ElementClass_Obj Is Nothing) Then ... Else ...."

        ''---------------Obselete as of 10/16/2019 thomas d.-------------
        ''Select Case True

        ''    Case (Me.ExampleTextToDisplay.Trim() <> "")
        ''        ''
        ''        ''Added 9/18/2019 td 
        ''        ''
        ''        Return Me.ExampleTextToDisplay

        ''    Case (Me.ElementInfo_Field.ExampleValue_ForElement <> "")
        ''        ''
        ''        ''Added 9/18/2019 td 
        ''        ''
        ''        Return Me.ElementInfo_Field.ExampleValue_ForElement

        ''    Case (UseExampleValues And (Me.FieldInfo.ExampleValue <> ""))

        ''        ''Me.ElementInfo.Info.Text = Me.FieldInfo.ExampleValue
        ''        Return Me.FieldInfo.ExampleValue

        ''    Case (Me.FieldInfo.FieldLabelCaption <> "")

        ''        ''Me.ElementInfo.Info.Text = Me.FieldInfo.ExampleValue
        ''        Return Me.FieldInfo.FieldLabelCaption

        ''    Case Else

        ''        ''Default value.
        ''        ''7/29 td''Me.ElementInfo.Info.Text = $"Field #{Me.FieldInfo.FieldIndex}"
        ''        Return $"Field #{Me.FieldInfo.FieldIndex}"

        ''End Select ''End of "Select Case True"

        ''Return "Field Information"

    End Function ''End of "Public Function LabelText() As String"


    Public Function InsideMe(par_intX As Integer, par_intY As Integer) As Boolean
        ''
        ''Added 9/20/2019 td  
        ''
        Dim boolInsideHorizontally As Boolean
        Dim boolInsideVertically As Boolean
        Dim boolInside_BothWays As Boolean

        boolInsideHorizontally = (Me.Left <= par_intX And par_intX <= (Me.Left + Me.Width))
        boolInsideVertically = (Me.Top <= par_intY And par_intY <= (Me.Top + Me.Height))

        boolInside_BothWays = (boolInsideHorizontally And boolInsideVertically)
        Return boolInside_BothWays

    End Function ''eND OF "Public Function InsideMe(par_intX, par_intY As Integer) As Boolean"


    Public Sub Highlight_IfInsideRubberband(par_rubberband As Rectangle,
                     Optional par_bRedrawElement As Boolean = False)
        ''
        ''Added 9/20/2019 thomas downes
        ''
        Dim boolRubBandIsAll_LeftOfMe As Boolean
        Dim boolRubBandIsAll_RightOfMe As Boolean
        Dim boolRubBandIsAll_AboveMe As Boolean
        Dim boolRubBandIsAll_BelowMe As Boolean

        Dim boolBandIsInsideMeHorizontally As Boolean
        Dim boolBandIsInsideMeVertically As Boolean
        Dim boolBandIsInsideMe_BothWays As Boolean
        Dim boolBandOverlapsWithMe As Boolean

        Dim obj_rectangleAdjusted As Rectangle

        Dim intRbandInDesignForm_Left As Integer
        Dim intRbandInDesignForm_Top As Integer

        With par_rubberband ''Added 9/20/2019 td

            ''Rband = Rubberband 
            intRbandInDesignForm_Left = Me.LayoutFunctions.Layout_Margin_Left_Add(.Left)
            intRbandInDesignForm_Top = Me.LayoutFunctions.Layout_Margin_Top_Add(.Top)

            ''Added 9/20/2019 td
            obj_rectangleAdjusted =
                New Rectangle(intRbandInDesignForm_Left,
                              intRbandInDesignForm_Top,
                                     .Width, .Height)

        End With ''End of "With par_rubberband"

        With obj_rectangleAdjusted

            boolRubBandIsAll_AboveMe = ((.Top + .Height) < Me.Top)
            boolRubBandIsAll_BelowMe = ((Me.Top + Me.Height) < .Top)

            boolRubBandIsAll_LeftOfMe = (.Left + .Width < Me.Left)
            boolRubBandIsAll_RightOfMe = ((Me.Left + Me.Width) < .Left)

        End With ''End of " With par_rubberband"

        boolBandIsInsideMeHorizontally = (Not (boolRubBandIsAll_LeftOfMe Or boolRubBandIsAll_RightOfMe))
        boolBandIsInsideMeVertically = (Not (boolRubBandIsAll_AboveMe Or boolRubBandIsAll_BelowMe))

        boolBandIsInsideMe_BothWays = (boolBandIsInsideMeHorizontally And boolBandIsInsideMeVertically)
        boolBandOverlapsWithMe = boolBandIsInsideMe_BothWays

        If (boolBandOverlapsWithMe) Then
            Me.ElementClass_ObjV3.SelectedHighlighting = True

            ''10/13/2019 td''Me.Refresh_Image(False)
            If (par_bRedrawElement) Then Me.Refresh_ImageV3(False)

        End If ''End of "If (boolBandOverlapsWithMe) Then"

    End Sub ''End of "Public Sub Highlight_IfInsideRubberband()"


    Public Sub ManageResizingByUser(par_bUseTempInfo As Boolean,
                                    par_deltaWidth As Integer, par_deltaHeight As Integer,
                                    par_deltaTop As Integer, par_deltaLeft As Integer)
        ''
        ''Added 10/14/2019 
        ''
        If (par_bUseTempInfo) Then

            Me.ElementClass_ObjV3.Width_Pixels = (TempResizeInfo_W + par_deltaWidth)
            Me.ElementClass_ObjV3.Height_Pixels = (TempResizeInfo_H + par_deltaHeight)
        Else
            Me.ElementClass_ObjV3.Width_Pixels += (par_deltaWidth)
            Me.ElementClass_ObjV3.Height_Pixels += (par_deltaHeight)
            Me.ElementClass_ObjV3.TopEdge_Pixels += (par_deltaTop)
            Me.ElementClass_ObjV3.LeftEdge_Pixels += (par_deltaLeft)
        End If ''End of "If (par_bUseTempInfo) Then ... Else ..."

        Me.Width = Me.ElementClass_ObjV3.Width_Pixels
        Me.Height = Me.ElementClass_ObjV3.Height_Pixels
        Me.Top = Me.ElementClass_ObjV3.TopEdge_Pixels
        Me.Left = Me.ElementClass_ObjV3.LeftEdge_Pixels

    End Sub ''End of "Public Sub ManageResizingByUser(par_intWidth As Integer, par_intHeight As Integer)"


    Private Sub RefreshElement_Field(sender As Object, e As EventArgs)
        ''
        ''Added 7/31/2019 thomas downes
        ''
        If (Me.Rotated_0degrees) Then
            Me.ElementInfo_Base.Width_Pixels = Me.Width
            Me.ElementInfo_Base.Height_Pixels = Me.Height
        ElseIf (Me.Rotated_180_360) Then
            Me.ElementInfo_Base.Width_Pixels = Me.Width
            Me.ElementInfo_Base.Height_Pixels = Me.Height

        ElseIf (Me.Rotated_90_270(False)) Then
            ''---DIFFICULT & CONFUSING---
            ''   It's rotated to 90 or 270 degrees, so let's 
            ''   pull a "switcheroo" on the Width & Height. 
            Me.ElementInfo_Base.Width_Pixels = Me.Height
            Me.ElementInfo_Base.Height_Pixels = Me.Width
        Else
            Throw New Exception("Logical error #42")
        End If ''ENd of "If (Me.Rotated_0degrees) Then ... ElseIf .... ElseIf ...."

        ''Added 9/5/2019 td 
        Me.ElementInfo_Base.TopEdge_Pixels = Me.LayoutFunctions.Layout_Margin_Top_Omit(Me.Top)
        Me.ElementInfo_Base.LeftEdge_Pixels = Me.LayoutFunctions.Layout_Margin_Left_Omit(Me.Left)

        ''Added 9/4/2019 td
        ''9/12/2019 td''Me.ElementInfo_Base.LayoutWidth_Pixels = Me.FormDesigner.Layout_Width_Pixels()
        Me.ElementInfo_Base.BadgeLayout.Width_Pixels = Me.LayoutFunctions.Layout_Width_Pixels()
        Me.ElementInfo_Base.BadgeLayout.Height_Pixels = Me.LayoutFunctions.Layout_Height_Pixels()

        Application.DoEvents()
        Me.Refresh_ImageV3(True)
        Application.DoEvents()
        Me.Refresh()

    End Sub ''End of "Private Sub RefreshElement_Field(sender As Object, e As EventArgs)"


    Public Function FullNameOfMyBaseClass() As String
        ''
        ''Added 1/5/2022 thomas downes
        ''
        ''  Should return "__RSC_WindowsControlLibrary.RSCMoveableControl".
        ''
        Return MyBase.FullNameOfThisBaseClass()

    End Function ''Added Public Function FullNameOfThisBaseClass() As String


    Private Sub GiveSizeInfo_Field(sender As Object, e As EventArgs)
        ''
        ''Added 7/31/2019 thomas downes
        ''
        Dim strMessageToUser As String = ""

        strMessageToUser &= (vbCrLf & $"Height of Picture control: {pictureLabel.Height}")
        strMessageToUser &= (vbCrLf & $"Height of Custom Graphics control: {Me.Height}")
        strMessageToUser &= (vbCrLf & $"Element-Info Property (Height): {Me.ElementInfo_Base.Height_Pixels}")
        strMessageToUser &= (vbCrLf & $"Picture control's Image Height: {pictureLabel.Image.Height}")

        MessageBox.Show(strMessageToUser, "", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub ''End of "Private Sub GiveSizeInfo_Field(sender As Object, e As EventArgs)"

    Private Sub CtlGraphicFldLabel_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        ''
        ''Addd 7/31/2019 td
        ''
        ''9/4/2019 td''If (Me.ElementInfo_Text IsNot Nothing) Then
        If (Me.ElementInfo_Base IsNot Nothing) Then

            Const c_bAvoidAntiflowDesign As Boolean = True ''Avoid "BadDesign" / "bad design".  ---Added 9/23/2019 td

            If (c_bAvoidAntiflowDesign) Then
                ''
                ''The "Else" code (below) violates the "Fields-->Elements-->UserGraphicsControl-->Layout"
                ''   sequence, since it supports a "UserGraphicsControl-->Element" flow.   That 
                ''   flow (UserGraphicsControl-->Element) is maybe okay in some respects, !perhaps!, 
                ''   but probably not here.
                ''   -----9/23/2019 td
                ''
            Else

                Me.ElementInfo_Base.Width_Pixels = Me.Width
                Me.ElementInfo_Base.Height_Pixels = Me.Height
                ''Me.RefreshImage()

                ''Added 9/5/2019 td 
                ''9/19/2019 td''Me.ElementInfo_Base.TopEdge_Pixels = Me.FormDesigner.Layout_Margin_Top_Omit(Me.Top)
                ''9/19/2019 td''Me.ElementInfo_Base.LeftEdge_Pixels = Me.FormDesigner.Layout_Margin_Left_Omit(Me.Left)

                Me.ElementInfo_Base.TopEdge_Pixels = Me.LayoutFunctions.Layout_Margin_Top_Omit(Me.Top)
                Me.ElementInfo_Base.LeftEdge_Pixels = Me.LayoutFunctions.Layout_Margin_Left_Omit(Me.Left)

                ''Added 9/4/2019 td
                ''9/12/2019 td''Me.ElementInfo_Base.LayoutWidth_Pixels = Me.FormDesigner.Layout_Width_Pixels()
                ''9/19/2019 td''Me.ElementInfo_Base.BadgeLayout.Width_Pixels = Me.FormDesigner.Layout_Width_Pixels()
                ''9/19/2019 td''Me.ElementInfo_Base.BadgeLayout.Height_Pixels = Me.FormDesigner.Layout_Height_Pixels()

                Me.ElementInfo_Base.BadgeLayout.Width_Pixels = Me.LayoutFunctions.Layout_Width_Pixels()
                Me.ElementInfo_Base.BadgeLayout.Height_Pixels = Me.LayoutFunctions.Layout_Height_Pixels()

            End If ''ENd of "If (c_boolAvoidAntidesignedCode) Then .... Else ..."

        End If ''End of "If (Me.ElementInfo_Base IsNot Nothing) Then"

    End Sub ''Private Sub CtlGraphicFldLabel_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint

    Private Sub TextTypeExample_KeyUp(sender As Object, e As KeyEventArgs) Handles textTypeExample.KeyDown

        ''Added 8/10/2019 thomas downes  
        If (e.KeyCode = Keys.Enter) Then

            Me.FieldInfo.ExampleValue = textTypeExample.Text
            Me.ElementInfo_TextOnly.Text_Static = textTypeExample.Text
            Me.textTypeExample.Visible = False

            ''Added 9/20/2019 td  
            ''Jan2 2022 td''Me.ElementInfo_Field.ExampleValue_ForElement = textTypeExample.Text
            Me.ElementInfo_TextField.ExampleValue_ForElement = textTypeExample.Text
            Me.ElementClass_ObjV3.ExampleValue_ForElement = textTypeExample.Text ''Redundant command. 

            ''Added 9/10/2019 td
            Me.Refresh_Master()

            ''Added 9/20/2019 td
            Me.LayoutFunctions.AutoPreview_IfChecked()

        End If ''End If ''End of "If (e.KeyCode = Keys.Enter) Then"

    End Sub

    Private Sub LinkMessageFYI_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkMessageFYI.LinkClicked
        ''
        ''Added 9/19/2019 td  
        ''
        Dim intResult As DialogResult
        Dim bUserDesiresTo_Display As Boolean

        Select Case Me.Enum_ReminderMsg

            Case EnumReminderMsg.NotCurrentlyInUse

                intResult = MessageBox.Show("Want this element to appear on the Badge?", "",
                  MessageBoxButtons.OK, MessageBoxIcon.Question)

                bUserDesiresTo_Display = (intResult = DialogResult.OK Or intResult = DialogResult.Yes)

                If (bUserDesiresTo_Display) Then

                    ''Added 9/20/2019 td 
                    ''   Add an alert to the user that the element is not rendered
                    ''   on the Badge.  ----9/20/2019 td
                    ''
                    Me.ElementInfo_Base.Visible = True

                    Dim bElementInvisibleOnBadge As Boolean
                    bElementInvisibleOnBadge = False ''False, since invisible is the opposite of "Displayed". 
                    LinkMessageFYI.Visible = bElementInvisibleOnBadge ''Hide the link-label, it's not needed anymore. 

                End If ''End of "If (bUserDesiresTo_Display) Then"


        End Select  ''End of "Select Case Me.Enum_ReminderMsg"

    End Sub

    Private Sub pictureLabel_Click(sender As Object, e As MouseEventArgs) Handles pictureLabel.MouseClick
        ''
        ''Added 10/1/2019 td
        ''
        If (e.Button = MouseButtons.Right) Then

            RaiseEvent ElementField_RightClicked(Me)

        End If ''end of "If (e.Button = MouseButtons.Right) Then"

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
        Return pictureLabel

    End Function


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


    Private mod_formRecordLastTouched As IRecordElementLastTouched ''Added 12/17/2021 td
    Private Sub CtlGraphicFldLabel_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        ''
        ''Added 12/17/2021 td
        ''
        mod_formRecordLastTouched.RecordElementLastTouched(Me, Me)

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


    Private Sub pictureLabel_MouseDown(par_sender As Object, par_e As MouseEventArgs) Handles pictureLabel.MouseDown
        ''
        ''Added 1/07/2022 td 
        ''
        If mod_bHandleMouseMoveEvents_ByVB6 Then
            If mod_bHandleMouseMoveEvents_ChildClass Then
                ''----Nasty bug.  Don't use par_sender here. ---1/11/2022 td''
                ''--MyBase.MoveableControl_MouseDown(par_sender, par_e)
                Dim objParentControl As Control = Me ''Added 1/11/2022
                MyBase.MoveableControl_MouseDown(objParentControl, par_e)
            End If
        End If

    End Sub

    Private Sub pictureLabel_MouseMove(par_sender As Object, par_e As MouseEventArgs) Handles pictureLabel.MouseMove

        If mod_bHandleMouseMoveEvents_ByVB6 Then
            If mod_bHandleMouseMoveEvents_ChildClass Then
                ''Added 1/07/2022 thomas downes
                ''----Nasty bug.  Don't use par_sender here. ---1/11/2022 td''
                ''--MyBase.MoveableControl_MouseMove(par_sender, par_e)
                Dim objParentControl As Control = Me ''Added 1/11/2022
                MyBase.MoveableControl_MouseMove(objParentControl, par_e)
            End If
        End If

    End Sub

    Private Sub pictureLabel_MouseUp(par_sender As Object, par_e As MouseEventArgs) Handles pictureLabel.MouseUp

        If mod_bHandleMouseMoveEvents_ByVB6 Then
            If mod_bHandleMouseMoveEvents_ChildClass Then
                ''Added 1/07/2022 thomas downes
                ''----Nasty bug.  Don't use par_sender here. ---1/11/2022 td''
                ''--MyBase.MoveableControl_MouseUp(par_sender, par_e)
                Dim objParentControl As Control = Me ''Added 1/11/2022
                MyBase.MoveableControl_MouseUp(objParentControl, par_e)
            End If
        End If

    End Sub

    Private Sub See_MouseDown_Events(sender As Object, e As EventArgs) Handles pictureLabel.Click
        ''
        ''
        ''
    End Sub
End Class
