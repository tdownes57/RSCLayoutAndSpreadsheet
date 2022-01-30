Option Explicit On ''Added 9/3/2019 td
Option Strict On ''Added 9/3/2019 td
Option Infer Off ''Added 9/3/2019 td

''
''Added 8/15/2019 thomas downes 
''
Imports ciBadgeInterfaces ''Added 8/16/2019 thomas d.
Imports ciBadgeElements ''Added 9/18/2019 thomas d.
Imports ciBadgeFields ''Added 9/18/2019 thomas d.  
Imports ciBadgeDesigner ''Added 10/3/2019 td   

Public Class DialogTextOffset
    ''
    ''Added 8/15/2019 thomas downes 
    ''
    Public FieldInfo_Denigrated As ICIBFieldStandardOrCustom

    ''Added 8/17/2019 td  
    ''Obselete.  9/18 td''Public FontOffset_X As Integer
    ''Obselete.  9/18 td''Public FontOffset_Y As Integer
    ''Obselete.  9/18 td''Public FontSize As Integer
    ''Obselete.  9/18 td''Public FontSize_ScaleToElement As Boolean ''Added 9/12/2019 td
    ''Obselete.  9/18 td''Public Font_DrawingClass As Font ''Added 8/17/2019 td 
    ''Obselete.  9/18 td''Public TextAlignment As System.Windows.Forms.HorizontalAlignment ''Added 8/18/2019 td 

    ''Obselete.  9/18 td''Public Element_Height As Integer ''Added 9/12/2019 thomas d.
    ''Obselete.  9/18 td''Public Element_Width As Integer ''Added 9/12/2019 thomas d.

    ''8/17/2019 td''Public ObjElementText As ClassElementText
    ''8/29/2019 td''Public ElementInfo As ciBadgeInterfaces.IElementText ''Added 8/16/2019 td

    Public ElementObject_LayoutDesign As ClassElementFieldV3 ''Added 9/18/2019 td
    Public ElementObject_CopyForEditing As ClassElementFieldV3 ''Added 9/18/2019 td

    Public ElementCopy_Info_Base As ciBadgeInterfaces.IElement_Base ''Added 8/29/2019 td
    Public ElementCopy_Info_Text As ciBadgeInterfaces.IElement_TextOnly ''Modified 10/12/2019 td
    Public ElementCopy_Info_Field As ciBadgeInterfaces.IElement_TextField ''Renamed 10/12 & 8/29/2019 td

    Public GroupEdits As ISelectingElements ''Added 8/15/2019 thomas downes  
    ''10/3/2019 td''Public FormDesigner_Denigrated As FormDesignProtoTwo ''Added 8/15/2019 td  
    Public OriginalElementControl_ForApplyOnly As CtlGraphicFldLabelV3 ''Added 8/15/2019 td  

    Public UserConfirmed As Boolean ''Added 9/18/2019 thomas d. 

    Public Sub New(par_element_fromLayout As ClassElementFieldV3, par_element_copy As ClassElementFieldV3,
                   par_parentControl As CtlGraphicFldLabelV3)

        ' This call is required by the designer.
        InitializeComponent()

        ''
        ' Add any initialization after the InitializeComponent() call.
        ''

        ''Just to be extra cautious, let's use a copy of the copy.   :-)  ----9/18/2019 td
        Me.ElementObject_CopyForEditing = par_element_copy.Copy()

        ''#1 9/18/2019 td''Me.ElementObject_ForLayout_NotUsed = par_element_fromLayout
        '' #2 9/18/2019 td''Me.ElementObject_ForLayout_NotUsed = Nothing ''Nothing, since it's not used!!  ---9/18/2019 td''par_element_fromLayout
        Me.ElementObject_LayoutDesign = par_element_fromLayout

        ''Added 9/18/2019 td 
        Me.ElementCopy_Info_Base = CType(Me.ElementObject_CopyForEditing, IElement_Base)

        ''10/12/2019 td''Me.ElementCopy_Info_Text = CType(Me.ElementObject_CopyForEditing, IElement_TextField)
        Me.ElementCopy_Info_Text = CType(Me.ElementObject_CopyForEditing, IElement_TextOnly)

        ''Added 9/18/2019 td 
        OriginalElementControl_ForApplyOnly = par_parentControl

        ''Added 9/18/2019 td 
        Me.FieldInfo_Denigrated = Me.ElementObject_LayoutDesign.FieldInfo ''Added 9/18/2019 td 

    End Sub ''ENd of "Public Sub New(par_element_fromLayout As ClassElementField, par_element_copy As ClassElementField)"

    Public Sub UpdateInfo_ViaInterfaces(par_elementInfo_Base As IElement_Base,
                          par_elementInfo_Text As IElement_TextOnly,
                          Optional par_overrideConfirmation As Boolean = False)
        ''
        ''This is perhaps like an "dependency injection" to "push" the 
        ''   new settings out to the the parent designer form.
        ''   ----9/18/2019 td 
        ''
        ''added 9/17 td
        ''
        Dim boolTransferPropertyValues As Boolean ''Added 9/23/2019 td 
        boolTransferPropertyValues = (Me.UserConfirmed Or par_overrideConfirmation) ''Added 9/23/2019 td 

        ''9/23 td''If (Me.UserConfirmed) Then
        If (boolTransferPropertyValues) Then

            With par_elementInfo_Base

                ''9/18/2019 td''.Height_Pixels = Me.Element_Height
                ''9/18/2019 td''.Width_Pixels = Me.Element_Width

                .Height_Pixels = Me.ElementCopy_Info_Base.Height_Pixels
                .Width_Pixels = Me.ElementCopy_Info_Base.Width_Pixels

            End With ''End of "With par_elementInfo_Base"

            With par_elementInfo_Text

                ''Obselete.---9/18/2019 td''Me.ElementInfo_Text.FontOffset_X = frm_ToShow.FontOffset_X
                ''Obselete.---9/18/2019 td''Me.ElementInfo_Text.FontOffset_Y = frm_ToShow.FontOffset_Y
                ''Obselete.---9/18/2019 td''Me.ElementInfo_Text.FontSize_Pixels = frm_ToShow.FontSize
                ''Obselete.---9/18/2019 td''Me.ElementInfo_Text.Font_DrawingClass = frm_ToShow.Font_DrawingClass

                .FontOffset_X = Me.ElementCopy_Info_Text.FontOffset_X
                .FontOffset_Y = Me.ElementCopy_Info_Text.FontOffset_Y

                .FontSize_Pixels = Me.ElementCopy_Info_Text.FontSize_Pixels

                .Font_DrawingClass = modFonts.SetFontSize_Pixels(Me.ElementCopy_Info_Text.Font_DrawingClass,
                                                                 Me.ElementCopy_Info_Text.FontSize_Pixels)

                ''Added 9/19/2019 td
                .TextAlignment = Me.ElementCopy_Info_Text.TextAlignment ''Added 9/19/2019 td

                ''Added 9/19/2019 td
                .FontSize_ScaleToElementYesNo = Me.ElementCopy_Info_Text.FontSize_ScaleToElementYesNo

            End With

        ElseIf (Not par_overrideConfirmation) Then

            ''Added 9/18/2019 td 
            MessageBox.Show("Settings have not been confirmed.", "",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End If ''End of "If (Me.UserConfirmed) Then .... ElseIf ..."

    End Sub ''Public Sub UpdateInfo_ViaInterfaces(par_elementInfo_Base As IElement_Base, par_elementInfo_Text As IElement_Text)

    Public Sub LoadFieldAndForm(par_layoutFun As ILayoutFunctions,
                                par_originalCtl As CtlGraphicFldLabelV3)
        ''9/19/2019 td''Public Sub LoadFieldAndForm(par_formDesigner As FormDesignProtoTwo,
        ''                  par_originalCtl As CtlGraphicFldLabel)
        ''
        ''Added 9/18/2019 td
        ''
        ''9/19/2019 td''Me.FormDesigner = par_formDesigner
        Me.OriginalElementControl_ForApplyOnly = par_originalCtl

        With CtlGraphicFldLabel1

            .FieldInfo = Me.ElementObject_CopyForEditing.FieldInfo

            ''Added 9/18/2019 td 
            .ElementClass_Obj = Me.ElementObject_CopyForEditing ''Added 9/19/2019 td 
            .ElementInfo_Base = Me.ElementCopy_Info_Base
            .ElementInfo_TextOnly = Me.ElementCopy_Info_Text
            ''1/2/2022 td''.ElementInfo_Field = Me.ElementCopy_Info_Field ''Added 10/12/2019 td
            .ElementInfo_TextField = Me.ElementCopy_Info_Field ''Added 10/12/2019 td

            ''9/19/2019 td''.FormDesigner = par_formDesigner
            ''9/19/2019 td''.LayoutFunctions = CType(par_formDesigner, ILayoutFunctions) ''Added 9/19/2019 td 
            .LayoutFunctions = par_layoutFun

            .Width = .ElementInfo_Base.Width_Pixels
            .Height = .ElementInfo_Base.Height_Pixels

            .Refresh_Image(True)

        End With ''End of "With CtlGraphicFldLabel1"

        ''Position it at the center horizontally. 
        Const c_boolCenterLabelControl As Boolean = False ''Added 9/18/2019 td
        If (c_boolCenterLabelControl) Then ''Added 9/18/2019 td
            ''Added 9/18/2019 td
            CenterTheFieldControl()
        End If ''End of "If (c_boolCenterLabelControl) Then"

        ''
        ''Added 9/13/2019 thomas downes
        ''
        Me.CtlElementHeight.ElementInfo_Base = Me.ElementCopy_Info_Base
        Me.CtlElementHeight.ElementInfo_Text = Me.ElementCopy_Info_Text
        Me.CtlElementHeight.InitiateLocalValue() ''Added 9/19/2019 td

        Me.CtlElementWidth.ElementInfo_Base = Me.ElementCopy_Info_Base
        ''1/2/2022 td''Me.CtlElementWidth.ElementInfo_Text = Me.ElementCopy_Info_Text
        Me.CtlElementWidth.ElementInfo_TextOnly = Me.ElementCopy_Info_Text
        Me.CtlElementWidth.InitiateLocalValue() ''Added 9/19/2019 td

        Me.CtlFontSize.ElementInfo_Base = Me.ElementCopy_Info_Base
        Me.CtlFontSize.ElementInfo_Text = Me.ElementCopy_Info_Text
        Me.CtlFontSize.InitiateLocalValue() ''Added 9/19/2019 td

        Me.CtlTextOffsetX.ElementInfo_Base = Me.ElementCopy_Info_Base
        ''Jan2 2022 td''Me.CtlTextOffsetX.ElementInfo_Text = Me.ElementCopy_Info_Text
        Me.CtlTextOffsetX.ElementInfo_TextOnly = Me.ElementCopy_Info_Text
        Me.CtlTextOffsetX.InitiateLocalValue() ''Added 9/19/2019 td

        Me.ctlTextOffsetY.ElementInfo_Base = Me.ElementCopy_Info_Base
        Me.ctlTextOffsetY.ElementInfo_Text = Me.ElementCopy_Info_Text
        Me.ctlTextOffsetY.InitiateLocalValue() ''Added 9/19/2019 td

        ''Added 9/19/2019 td
        ''
        ''Does the font size scale to the element height???
        ''
        checkFontSizeScalesYN.Checked = Me.ElementCopy_Info_Text.FontSize_ScaleToElementYesNo

    End Sub ''End of "Public Sub LoadFieldAndForm(par_field As ClassFieldStandard, par_formDesigner As FormDesignProtoTwo)"

    ''--------10/3/2019 td----------------------------------------------------------------------------------------------
    ''Public Sub LoadFieldAndForm_NotInUse(par_elementInfo_Base As IElement_Base,
    ''                            par_elementInfo_Text As IElement_TextField,
    ''                            par_fieldInfo As ICIBFieldStandardOrCustom,
    ''                            par_formDesigner As FormDesignProtoTwo,
    ''                            par_originalCtl As CtlGraphicFldLabel)
    ''    ''
    ''    ''Worked on 8/16 & 8/15/2019 td
    ''    ''
    ''    Me.FieldInfo_Denigrated = par_fieldInfo

    ''    ''8/16/2019 td''Me.ElementInfo = par_field.ElementInfo
    ''    ''Obselete. ---9/18/2019 td''Me.ElementInfo_Base = par_elementInfo_Base ''Added 9/3/2019 thomas d. 
    ''    ''Obselete. ---9/18/2019 td''Me.ElementInfo_Text = par_elementInfo_Text ''Added 8/16 td

    ''    ''Added 8/17/2019 td
    ''    ''
    ''    ''Obselete. ---9/18/2019 td''Me.FontOffset_X = par_elementInfo_Text.FontOffset_X
    ''    ''Obselete. ---9/18/2019 td''Me.FontOffset_Y = par_elementInfo_Text.FontOffset_Y
    ''    ''Obselete. ---9/18/2019 td''Me.FontSize = CInt(par_elementInfo_Text.FontSize_Pixels) ''9/3 td''par_elementInfo.FontSize
    ''    ''Obselete. ---9/18/2019 td''Me.Font_DrawingClass = par_elementInfo_Text.Font_DrawingClass

    ''    ''Added 8/15/2019 td
    ''    Me.FormDesigner_Denigrated = par_formDesigner
    ''    Me.OriginalElementControl_ForApplyOnly = par_originalCtl

    ''    With CtlGraphicFldLabel1
    ''        .ElementInfo_Text = par_elementInfo_Text

    ''        ''added 9.6.2019 td
    ''        .ElementClass_Obj = Nothing ''CType(par_elementInfo_Text, ClassElementText)
    ''        .ElementInfo_Base = par_elementInfo_Base
    ''        .ElementInfo_Text = par_elementInfo_Text

    ''        .Width = .ElementInfo_Base.Width_Pixels
    ''        .Height = .ElementInfo_Base.Height_Pixels
    ''        .FieldInfo = par_fieldInfo
    ''        .LabelText()  ''par_elementInfo.Text)
    ''        ''8/17/2019 td''.FieldInfo = par_fieldInfo
    ''        ''8/16/2019 td   ''.ElementInfo = par_field.ElementInfo
    ''        ''Deprecated. ----9/20/2019 td''.FormDesigner = par_formDesigner
    ''        .LayoutFunctions = CType(par_formDesigner, ILayoutFunctions) ''Added 9/20/2019 td 

    ''        .Refresh_Image(True)
    ''    End With

    ''    ''Position it at the center horizontally. 
    ''    CenterTheFieldControl()

    ''    ''Added 8/17/2019 thomas downes 
    ''    ''LabelNumberOffsetX.Text = String.Format(LabelNumberOffsetX.Tag.ToString, Me.FontOffset_X)
    ''    ''LabelNumberOffsetY.Text = String.Format(LabelNumberOffsetY.Tag.ToString, Me.FontOffset_Y)
    ''    ''LabelFontSizeNum.Text = String.Format(LabelFontSizeNum.Tag.ToString, Me.FontSize)

    ''    ''
    ''    ''Added 9/13/2019 thomas downes
    ''    ''
    ''    Me.CtlElementHeight.ElementInfo_Base = par_elementInfo_Base
    ''    Me.CtlElementHeight.ElementInfo_Text = par_elementInfo_Text
    ''    Me.CtlElementHeight.InitiateLocalValue() ''Added 9/19/2019 td

    ''    Me.CtlElementWidth.ElementInfo_Base = par_elementInfo_Base
    ''    Me.CtlElementWidth.ElementInfo_Text = par_elementInfo_Text
    ''    Me.CtlElementWidth.InitiateLocalValue() ''Added 9/19/2019 td

    ''    Me.CtlFontSize.ElementInfo_Base = par_elementInfo_Base
    ''    Me.CtlFontSize.ElementInfo_Text = par_elementInfo_Text
    ''    Me.CtlFontSize.InitiateLocalValue() ''Added 9/19/2019 td

    ''    Me.CtlTextOffsetX.ElementInfo_Base = par_elementInfo_Base
    ''    Me.CtlTextOffsetX.ElementInfo_Text = par_elementInfo_Text
    ''    Me.CtlTextOffsetX.InitiateLocalValue() ''Added 9/19/2019 td

    ''    Me.ctlTextOffsetY.ElementInfo_Base = par_elementInfo_Base
    ''    Me.ctlTextOffsetY.ElementInfo_Text = par_elementInfo_Text
    ''    Me.ctlTextOffsetY.InitiateLocalValue() ''Added 9/19/2019 td

    ''End Sub ''End of "Public Sub LoadFieldAndForm_NotInUse(par_field As ClassFieldStandard, par_formDesigner As FormDesignProtoTwo)"

    ''--------10/3/2019 td----------------------------------------------------------------------------------------------
    ''Public Sub LoadFieldAndForm_NotInUse(par_field As ClassFieldStandard, par_formDesigner As FormDesignProtoTwo,
    ''                             par_originalCtl As CtlGraphicFldLabel)

    ''    Me.FieldInfo_Denigrated = par_field

    ''    ''This procedure is obselete.---9/18/2019 td''Me.ElementInfo_Text = par_field.ElementFieldClass

    ''    ''Added 8/15/2019 td
    ''    Me.FormDesigner_Denigrated = par_formDesigner

    ''    ''Added 9/18/2019 td
    ''    Me.OriginalElementControl_ForApplyOnly = par_originalCtl

    ''    With CtlGraphicFldLabel1
    ''        .FieldInfo = par_field

    ''        ''Deprecated 9/18/2019 td''.ElementClass_Obj = par_field.ElementFieldClass ''Added 9/13/2019 td
    ''        ''Deprecated 9/18/2019 td''.ElementInfo_Base = par_field.ElementInfo_Base ''Added 9/13/2019 td 
    ''        ''Deprecated 9/18/2019 td''.ElementInfo_Text = par_field.ElementInfo_Text ''Added 9/13/2019 td 
    ''        ''Deprecated 9/18/2019 td''.FormDesigner = par_formDesigner
    ''        .LayoutFunctions = CType(par_formDesigner, ILayoutFunctions)

    ''        .Width = .ElementInfo_Base.Width_Pixels
    ''        .Height = .ElementInfo_Base.Height_Pixels
    ''        .Refresh_Image(True)
    ''    End With

    ''    ''Position it at the center horizontally. 
    ''    CenterTheFieldControl()

    ''    ''
    ''    ''Added 9/13/2019 thomas downes
    ''    ''
    ''    ''Deprecated 9/18/2019 td''Me.CtlElementHeight.ElementInfo_Base = par_field.ElementInfo_Base
    ''    ''Deprecated 9/18/2019 td''Me.CtlElementHeight.ElementInfo_Text = par_field.ElementInfo_Text
    ''    Me.CtlElementHeight.InitiateLocalValue()

    ''    ''Deprecated 9/18/2019 td''Me.CtlElementWidth.ElementInfo_Base = par_field.ElementInfo_Base
    ''    ''Deprecated 9/18/2019 td''Me.CtlElementWidth.ElementInfo_Text = par_field.ElementInfo_Text
    ''    Me.CtlElementWidth.InitiateLocalValue()

    ''    ''Deprecated 9/18/2019 td''Me.CtlFontSize.ElementInfo_Base = par_field.ElementInfo_Base
    ''    ''Deprecated 9/18/2019 td''Me.CtlFontSize.ElementInfo_Text = par_field.ElementInfo_Text
    ''    Me.CtlFontSize.InitiateLocalValue()

    ''    ''Deprecated 9/18/2019 td''Me.CtlTextOffsetX.ElementInfo_Base = par_field.ElementInfo_Base
    ''    ''Deprecated 9/18/2019 td''Me.CtlTextOffsetX.ElementInfo_Text = par_field.ElementInfo_Text
    ''    Me.CtlTextOffsetX.InitiateLocalValue()

    ''    ''Deprecated 9/18/2019 td''Me.ctlTextOffsetY.ElementInfo_Base = par_field.ElementInfo_Base
    ''    ''Deprecated 9/18/2019 td''Me.ctlTextOffsetY.ElementInfo_Text = par_field.ElementInfo_Text
    ''    Me.ctlTextOffsetY.InitiateLocalValue()

    ''End Sub ''End of "Public Sub LoadFieldAndForm_NotInUse(par_field As ClassFieldStandard, par_formDesigner As FormDesignProtoTwo)"

    Private Sub CenterTheFieldControl()
        ''
        ''Position it at the center horizontally. 
        ''8/15/2019 td
        ''
        With CtlGraphicFldLabel1

            .Left = CInt((Me.Width - .Width) / 2)

        End With

    End Sub

    Private Sub FormOffsetText_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    ''Private Sub ButtonXIncrease_Click(sender As Object, e As EventArgs) Handles ButtonXIncrease.Click
    ''    ''
    ''    ''Added 8/16/2019 td
    ''    ''
    ''    Me.FontOffset_X += 1
    ''    Me.ElementInfo_Text.FontOffset_X += 1
    ''    CtlGraphicFldLabel1.ElementInfo_Text = Me.ElementInfo_Text
    ''    CtlGraphicFldLabel1.Refresh_Image(True)

    ''    ''Added 8/17/2019 thomas downes 
    ''    LabelNumberOffsetY.Text = String.Format(LabelNumberOffsetY.Tag.ToString, Me.FontOffset_X)

    ''End Sub

    ''Private Sub ButtonXDecrease_Click(sender As Object, e As EventArgs) Handles ButtonXDecrease.Click
    ''    ''
    ''    ''Added 8/16/2019 td
    ''    ''
    ''    Me.FontOffset_X -= 1
    ''    Me.ElementInfo_Text.FontOffset_X -= 1
    ''    CtlGraphicFldLabel1.ElementInfo_Text = Me.ElementInfo_Text
    ''    CtlGraphicFldLabel1.Refresh_Image(True)

    ''    ''Added 8/17/2019 thomas downes 
    ''    LabelNumberOffsetY.Text = String.Format(LabelNumberOffsetY.Tag.ToString, Me.FontOffset_X)

    ''End Sub

    ''Private Sub ButtonYDecrease_Click(sender As Object, e As EventArgs)
    ''    ''
    ''    ''Added 8/16/2019 td
    ''    ''
    ''    Me.FontOffset_Y -= 1
    ''    Me.ElementInfo_Text.FontOffset_Y -= 1
    ''    CtlGraphicFldLabel1.ElementInfo_Text = Me.ElementInfo_Text
    ''    CtlGraphicFldLabel1.Refresh_Image(True)

    ''    ''Added 8/17/2019 thomas downes 
    ''    LabelNumberOffsetX.Text = String.Format(LabelNumberOffsetX.Tag.ToString, Me.FontOffset_Y)

    ''End Sub

    ''Private Sub ButtonYIncrease_Click(sender As Object, e As EventArgs)
    ''    ''
    ''    ''Added 8/16/2019 td
    ''    ''
    ''    Me.FontOffset_Y += 1
    ''    Me.ElementInfo_Text.FontOffset_Y += 1
    ''    CtlGraphicFldLabel1.ElementInfo_Text = Me.ElementInfo_Text
    ''    CtlGraphicFldLabel1.Refresh_Image(True)

    ''    ''Added 8/17/2019 thomas downes 
    ''    LabelNumberOffsetX.Text = String.Format(LabelNumberOffsetX.Tag.ToString, Me.FontOffset_X)

    ''End Sub

    ''Private Sub ButtonFontDecrease_Click(sender As Object, e As EventArgs)

    ''    ''Added 8/16/2019  td
    ''    With Me.ElementInfo_Text
    ''        .FontSize_Pixels -= 1

    ''        Me.FontSize = CInt(.FontSize_Pixels) ''9/3 td'' = .FontSize ''Push change to the level of the dialog form.

    ''        LabelFontSizeNum.Text = String.Format(LabelFontSizeNum.Tag.ToString, .FontSize_Pixels)
    ''        .Font_DrawingClass = modFonts.SetFontSize(.Font_DrawingClass, CInt(.FontSize_Pixels))

    ''        Me.Font_DrawingClass = .Font_DrawingClass ''Push change to the level of the dialog form.

    ''        ''Added 8/17/2019 thomas downes 
    ''        LabelFontSizeNum.Text = String.Format(LabelFontSizeNum.Tag.ToString, .FontSize_Pixels)

    ''    End With

    ''    CtlGraphicFldLabel1.ElementInfo_Text = Me.ElementInfo_Text
    ''    CtlGraphicFldLabel1.Refresh_Image(True)


    ''End Sub

    ''Private Sub ButtonFontIncrease_Click(sender As Object, e As EventArgs)
    ''    ''
    ''    ''Added 8 / 16 / 2019  td
    ''    ''
    ''    With Me.ElementInfo_Text
    ''        .FontSize_Pixels += 1
    ''        Me.FontSize = CInt(.FontSize_Pixels) ''9/3 td '' .FontSize ''Push change to the level of the dialog form.

    ''        LabelFontSizeNum.Text = String.Format(LabelFontSizeNum.Tag.ToString, .FontSize_Pixels)
    ''        .Font_DrawingClass = modFonts.SetFontSize(.Font_DrawingClass, CInt(.FontSize_Pixels)) ''9/3 td '' .FontSize)

    ''        Me.Font_DrawingClass = .Font_DrawingClass ''Push change to the level of the dialog form.

    ''        ''Added 8/17/2019 thomas downes 
    ''        LabelFontSizeNum.Text = String.Format(LabelFontSizeNum.Tag.ToString, .FontSize_Pixels)

    ''    End With

    ''    CtlGraphicFldLabel1.ElementInfo_Text = Me.ElementInfo_Text
    ''    CtlGraphicFldLabel1.Refresh_Image(True)

    ''End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click

        Me.UserConfirmed = True ''Added 9//18/2019 td 
        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click

        Me.Close()

    End Sub

    Private Sub ButtonLeft_Click(sender As Object, e As EventArgs) Handles ButtonLeft.Click

        ''Added 8/18/2019 thomas downes
        ''
        ''Obselete. ---9/18/2019 td''Me.ElementInfo_Text.TextAlignment = HorizontalAlignment.Left
        ''Obselete. ---9/18/2019 td''Me.TextAlignment = HorizontalAlignment.Left

        Me.ElementCopy_Info_Text.TextAlignment = HorizontalAlignment.Left

        Me.CtlGraphicFldLabel1.Refresh_Image(True)

    End Sub

    Private Sub ButtonCenter_Click(sender As Object, e As EventArgs) Handles ButtonCenter.Click

        ''Added 8/18/2019 thomas downes
        ''Obselete. ---9/18/2019 td''Me.ElementInfo_Text.TextAlignment = HorizontalAlignment.Center
        ''Obselete. ---9/18/2019 td''Me.TextAlignment = HorizontalAlignment.Center

        Me.ElementCopy_Info_Text.TextAlignment = HorizontalAlignment.Center

        Me.CtlGraphicFldLabel1.Refresh_Image(True)

    End Sub

    Private Sub ButtonRight_Click(sender As Object, e As EventArgs) Handles ButtonRight.Click

        ''Added 8/18/2019 thomas downes
        ''Obselete. ---9/18/2019 td''Me.ElementInfo_Text.TextAlignment = HorizontalAlignment.Right
        ''Obselete. ---9/18/2019 td''Me.TextAlignment = HorizontalAlignment.Right

        Me.ElementCopy_Info_Text.TextAlignment = HorizontalAlignment.Right

        Me.CtlGraphicFldLabel1.Refresh_Image(True)

    End Sub

    ''Private Sub ButtonElementHghtDecrease_Click(sender As Object, e As EventArgs)

    ''    ''Added 9/12/2019 thomas downes
    ''    Me.ElementInfo_Base.Height_Pixels -= 1
    ''    Me.Element_Height = Me.ElementInfo_Base.Height_Pixels
    ''    Me.CtlGraphicFldLabel1.Refresh_Image(True)
    ''
    ''    ''Added 9/12/2019 thomas downes 
    ''    LabelElementHghtNum.Text = String.Format(LabelElementHghtNum.Tag.ToString, Me.Element_Height)
    ''
    ''End Sub

    ''Private Sub ButtonElementHghtIncrease_Click(sender As Object, e As EventArgs)
    ''
    ''    ''Added 9/12/2019 thomas downes
    ''    Me.ElementInfo_Base.Height_Pixels += 1
    ''    Me.Element_Height = Me.ElementInfo_Base.Height_Pixels
    ''    Me.CtlGraphicFldLabel1.Refresh_Image(True)
    ''
    ''    ''Added 9/12/2019 thomas downes 
    ''    LabelElementHghtNum.Text = String.Format(LabelElementHghtNum.Tag.ToString, Me.Element_Height)
    ''
    ''End Sub

    ''Private Sub ButtonElementWidthDecrease_Click(sender As Object, e As EventArgs) Handles ButtonElementWidthDecrease.Click
    ''
    ''    ''Added 9/12/2019 thomas downes
    ''    Me.ElementInfo_Base.Width_Pixels -= 1
    ''    Me.Element_Width = Me.ElementInfo_Base.Width_Pixels
    ''    Me.CtlGraphicFldLabel1.Refresh_Image(True)
    ''
    ''    ''Added 9/12/2019 thomas downes 
    ''    LabelElementWidthNum.Text = String.Format(LabelElementWidthNum.Tag.ToString, Me.Element_Width)
    ''
    ''End Sub

    ''Private Sub ButtonElementWidthIncrease_Click(sender As Object, e As EventArgs) Handles ButtonElementWidthIncrease.Click

    ''    ''Added 9/12/2019 thomas downes
    ''    Me.ElementInfo_Base.Width_Pixels += 1
    ''    Me.Element_Width = Me.ElementInfo_Base.Width_Pixels
    ''    Me.CtlGraphicFldLabel1.Refresh_Image(True)
    ''
    ''    ''Added 9/12/2019 thomas downes 
    ''    LabelElementWidthNum.Text = String.Format(LabelElementWidthNum.Tag.ToString, Me.Element_Width)
    ''
    ''End Sub

    Private Sub CheckFontSizeScalesYN_CheckedChanged(sender As Object, e As EventArgs) Handles checkFontSizeScalesYN.CheckedChanged

        ''Added 9/12/2019 thomas d.
        ''9/18/2019 td''Me.ElementInfo_Text.FontSize_ScaleToElementYesNo = checkFontSizeScalesYN.Checked
        If (Me.ElementCopy_Info_Text IsNot Nothing) Then
            Me.ElementCopy_Info_Text.FontSize_ScaleToElementYesNo = checkFontSizeScalesYN.Checked
            ''Added 9/23/2019 td
            CtlFontSize.Enabled = (Not checkFontSizeScalesYN.Checked) ''Added 9/23/2019 td
        End If ''End of "If (Me.ElementCopy_Info_Text IsNot Nothing) Then"

    End Sub

    Private Sub For_EventUpdateRequest() Handles ctlTextOffsetY.EventUpdateRequest, CtlFontSize.EventUpdateRequest,
        CtlElementHeight.EventUpdateRequest, CtlTextOffsetX.EventUpdateRequest, CtlElementWidth.EventUpdateRequest

        ''Added 9/13/2019 thomas downes
        With Me.CtlGraphicFldLabel1
            ''9/18/2019 td''Me.CtlGraphicFldLabel1.Width = Me.Element_Info_Base.Width_Pixels
            ''9/18/2019 td''Me.CtlGraphicFldLabel1.Height = Me.ElementInfo_Base.Height_Pixels

            .Width = Me.ElementCopy_Info_Base.Width_Pixels
            .Height = Me.ElementCopy_Info_Base.Height_Pixels

            Me.CtlGraphicFldLabel1.Refresh_Image(True)

        End With ''ENd of "With Me.CtlGraphicFldLabel1"

    End Sub

    Private Sub CtlElementWidth_Load(sender As Object, e As EventArgs) Handles CtlElementWidth.Load

    End Sub

    Private Sub ButtonApply_Click(sender As Object, e As EventArgs) Handles ButtonApply.Click
        ''
        ''Added 9/18/2019 td  
        ''
        ''9/19/2019 td''UpdateInfo_ViaInterfaces(Me.ElementObject_LayoutDesign, Me.ElementObject_LayoutDesign)
        UpdateInfo_ViaInterfaces(Me.ElementObject_LayoutDesign, Me.ElementObject_LayoutDesign, True)

        ''9/23/2019 td''Me.OriginalElementControl_ForApplyOnly.Refresh_Master()
        ''9/23/2019 td''Me.LayoutFunctions.RedrawForm

        With Me.OriginalElementControl_ForApplyOnly
            .Refresh_Master()
            ''Added 9/23/2019 td 
            .LayoutFunctions.RedrawForm
        End With ''ENd of "With Me.OriginalElementControl_ForApplyOnly"

    End Sub

    Private Sub TextExampleValue_TextChanged(sender As Object, e As EventArgs) Handles TextExampleValue.TextChanged
        ''
        ''Added 9/18/2019 thomas d. 
        ''
        With TextExampleValue
            If (Trim(.Text) <> "") Then
                CtlGraphicFldLabel1.ExampleTextToDisplay = .Text  ''.Text.Trim
            End If ''eNd of "If (Trim(.Text) <> "") Then"
        End With

    End Sub

    Private Sub ButtonLeft_Click_1(sender As Object, e As EventArgs) Handles ButtonLeft.Click

    End Sub
End Class