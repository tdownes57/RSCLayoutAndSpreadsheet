''
''Added 8/29/2019 thomas downes 
''
Imports ciBadgeInterfaces ''Added 8/29/2019 thomas d.
Imports ciBadgeFields ''Added 9/18/2019 td 
Imports ciBadgeElements ''Added 9/18/2019 td 
Imports ciBadgeDesigner ''Added 10/3/2019 td   

Public Class DialogTextBorder ''Added 8/29/2019 thomas d.
    ''
    ''Added 8/29/2019 thomas downes 
    ''
    Public FieldInfo As ICIBFieldStandardOrCustom

    ''Added 8/17/2019 td  
    ''8/29 td''Public FontOffset_X As Integer
    ''8/29 td''Public FontOffset_Y As Integer
    ''8/29 td''Public FontSize As Integer
    ''8/29 td''Public Font_DrawingClass As Font ''Added 8/17/2019 td 
    ''8/29 td''Public TextAlignment As System.Windows.Forms.HorizontalAlignment ''Added 8/18/2019 td  

    ''Obselete.  9/18 td''Public Border_SizeInPixels As Integer ''Added 8/29/2019 td
    ''Obselete.  9/18 td''Public Border_Color As Drawing.Color ''Added 8/29/2019 td
    ''Obselete.  9/18 td''Public Border_Displayed As Boolean ''Added 9/9/2019 td  

    Public Property Border_SizeInPixels_NotInUse As Integer
        Get
            ''
            ''Obselete.  Instead, call this form's .UpdateInfo_ViaInterface method. 
            ''   ----9/18/2019 td 
            ''
            Return -1
        End Get
        Set(value As Integer)

        End Set
    End Property

    ''8/29/2019 td''Public ElementInfo As ciBadgeInterfaces.IElementText ''Added 8/16/2019 td
    Public ElementCopy_Info_Text As ciBadgeInterfaces.IElement_TextField ''Added 8/16/2019 td
    Public ElementCopy_Info_Base As ciBadgeInterfaces.IElement_Base ''Added 8/16/2019 td

    Public ElementObject_ForLayout_NotUsed As ClassElementFieldV3 ''Added 9/18/2019 td
    Public ElementObject_Copy As ClassElementFieldV3 ''Added 9/18/2019 td

    Public GroupEdits As ISelectingElements ''Added 8/15/2019 thomas downes  

    ''9/19/2019 td''Public FormDesigner As FormDesignProtoTwo ''Added 8/15/2019 td  
    Public LayoutFunctions As ILayoutFunctions ''Added 9/19/2019 td  

    Public OriginalElementControl As CtlGraphicFieldV3 ''Added 8/15/2019 td  

    Public UserConfirmed As Boolean ''Added 9/18/2019 thomas d. 

    Public Sub New(par_element_fromLayout As ClassElementFieldV3, par_element_copy As ClassElementFieldV3)
        ''
        ''Added 9/18/2019 thomas d. 
        ''
        ' This call is required by the designer.
        InitializeComponent()

        ''
        ' Add any initialization after the InitializeComponent() call.
        ''

        ''Just to be extra cautious, let's use a copy of the copy.   :-)  ----9/18/2019 td
        Me.ElementObject_Copy = par_element_copy.Copy()

        ''9/18/2019 td''Me.ElementObject_ForLayout_NotUsed = par_element_fromLayout
        Me.ElementObject_ForLayout_NotUsed = Nothing ''9/18/2019 td''par_element_fromLayout

        ''Added 9/18/2019 td 
        Me.ElementCopy_Info_Base = CType(Me.ElementObject_Copy, IElement_Base)
        Me.ElementCopy_Info_Text = CType(Me.ElementObject_Copy, IElement_TextField)

    End Sub ''ENd of "Public Sub New(par_element_fromLayout As ClassElementField, par_element_copy As ClassElementField)"

    Public Sub UpdateInfo_ViaInterface(par_elementInfo As IElement_Base, Optional par_overrideConfirmation As Boolean = False)
        ''
        ''This is perhaps like an "dependency injection" to "push" the 
        ''   new settings out to the the parent designer form.
        ''   ----9/18/2019 td 
        ''
        ''      ''added 9/17 td
        ''
        ''This allows the parental designer form to "grab" the new settings.  ---9/18/2019 td
        ''
        With par_elementInfo

            If (Me.UserConfirmed) Then

                ''9/18/2019 td''.Border_Color = Me.Border_Color
                ''9/18/2019 td''.Border_Displayed = Me.Border_Displayed
                ''9/18/2019 td''.Border_WidthInPixels = Me.Border_SizeInPixels

                .Border_Color = Me.ElementCopy_Info_Base.Border_Color
                .Border_Displayed = Me.ElementCopy_Info_Base.Border_Displayed
                .Border_WidthInPixels = Me.ElementCopy_Info_Base.Border_WidthInPixels

            ElseIf (Not par_overrideConfirmation) Then

                ''Added 9/18/2019 td 
                MessageBox.Show("Settings have not been confirmed.", "",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            End If ''End of "If (Me.UserConfirmed) Then .... ElseIf ... "
        End With

    End Sub ''Public Sub UpdateInfo_ViaInterface(par_elementInfo As IElement_Base)

    Public Sub LoadFieldAndForm(par_layoutFun As ILayoutFunctions,
                                par_originalCtl As CtlGraphicFieldV3)

        ''
        ''Added 9/18/2019 td
        ''
        ''Denigrated. 9/19/2019 td''Me.FormDesigner = par_formDesigner
        Me.LayoutFunctions = par_layoutFun ''Added 9/19/2019 td  
        Me.OriginalElementControl = par_originalCtl

        With CtlGraphicFldLabel1

            ''5/11/2022 .FieldInfo = Me.ElementObject_Copy.FieldInfo
            .FieldEnumValue = Me.ElementObject_Copy.FieldEnum

            ''Added 9/18/2019 td 
            .ElementInfo_Base = Me.ElementCopy_Info_Base
            ''6/2022 .ElementInfo_TextOnly = Me.ElementCopy_Info_Text
            .ElementInfo_TextOnly = CType(Me.ElementObject_Copy, IElement_TextOnly)

            ''Denigrated. 9/19/2019 td''.FormDesigner = par_formDesigner
            .LayoutFunctions = par_layoutFun ''Added 9/19/2019 td 

            .Width = .ElementInfo_Base.Width_Pixels
            .Height = .ElementInfo_Base.Height_Pixels
            .Refresh_ImageV3(True)

        End With ''End of "With CtlGraphicFldLabel1"

        ''Added 9/13/2019 thomas downes
        Me.CtlBorderWidth.ElementInfo_Base = Me.ElementCopy_Info_Base
        ''6/2022 td''Me.CtlBorderWidth.ElementInfo_Text = Me.ElementCopy_Info_Text
        Me.CtlBorderWidth.ElementInfo_Text = CType(Me.ElementObject_Copy, IElement_TextOnly)

        ''Position it at the center horizontally. 
        CenterTheFieldControl()

    End Sub ''End of "Public Sub LoadFieldAndForm(par_field As ClassFieldStandard, par_formDesigner As FormDesignProtoTwo)"


    ''--------9/19/2019 td----------------------------------------------------------------------------------------------
    ''Denigrated.  9/19/2019 td''Public Sub LoadFieldAndForm(par_formDesigner As FormDesignProtoTwo,
    ''                            par_originalCtl As CtlGraphicFldLabel)
    ''
    ''    ''
    ''    ''Added 9/18/2019 td
    ''    ''
    ''    Me.FormDesigner = par_formDesigner
    ''    Me.OriginalElementControl = par_originalCtl
    ''
    ''    With CtlGraphicFldLabel1
    ''
    ''        .FieldInfo = Me.ElementObject_Copy.FieldInfo
    ''
    ''        ''Added 9/18/2019 td 
    ''        .ElementInfo_Base = Me.ElementCopy_Info_Base
    ''        .ElementInfo_Text = Me.ElementCopy_Info_Text
    ''
    ''        .FormDesigner = par_formDesigner
    ''        .Width = .ElementInfo_Base.Width_Pixels
    ''        .Height = .ElementInfo_Base.Height_Pixels
    ''        .Refresh_Image(True)
    ''
    ''    End With ''End of "With CtlGraphicFldLabel1"
    ''
    ''    ''Added 9/13/2019 thomas downes
    ''    Me.CtlBorderWidth.ElementInfo_Base = Me.ElementCopy_Info_Base
    ''    Me.CtlBorderWidth.ElementInfo_Text = Me.ElementCopy_Info_Text
    ''
    ''    ''Position it at the center horizontally. 
    ''    CenterTheFieldControl()
    ''
    ''End Sub ''End of "Public Sub LoadFieldAndForm(par_field As ClassFieldStandard, par_formDesigner As FormDesignProtoTwo)"

    ''--------10/3/2019 td----------------------------------------------------------------------------------------------
    ''Public Sub LoadFieldAndForm_NotInUse(par_elementInfo_Base As IElement_Base,
    ''                            par_elementInfo_Text As IElement_TextField,
    ''                            par_fieldInfo As ICIBFieldStandardOrCustom,
    ''                            par_formDesigner As FormDesignProtoTwo,
    ''                            par_originalCtl As CtlGraphicFldLabel)
    ''    ''
    ''    ''Modelled after DialogTextOffset, 8/29/2019  
    ''    ''Modified on 8/29/2019 td
    ''    ''
    ''    Me.FieldInfo = par_fieldInfo

    ''    ''This procedure is obselete. ---9/18/2019 td''Me.ElementInfo_Base = par_elementInfo_Base ''Added 9/3/2019 td
    ''    ''This procedure is obselete. ---9/18/2019 td''Me.ElementInfo_Text = par_elementInfo_Text ''Added 8/16 td

    ''    ''Added 8/17/2019 td
    ''    ''
    ''    ''8/29 td''Me.FontOffset_X = par_elementInfo.FontOffset_X
    ''    ''8/29 td''Me.FontOffset_Y = par_elementInfo.FontOffset_Y
    ''    ''8/29 td''Me.FontSize = par_elementInfo.FontSize
    ''    ''8/29 td''Me.Font_DrawingClass = par_elementInfo.Font_DrawingClass

    ''    ''Obselete/Not is use.---9/18/2019 td''Me.Border_SizeInPixels = par_elementInfo_Base.Border_WidthInPixels
    ''    ''Obselete/Not is use.---9/18/2019 td''Me.Border_Color = par_elementInfo_Base.Border_Color
    ''    ''Obselete/Not is use.---9/18/2019 td''Me.Border_Displayed = par_elementInfo_Base.Border_Displayed ''Added 9/9/2019 td 

    ''    ''Added 8/15/2019 td
    ''    ''Denigrated. ---9/19/2019 td''Me.FormDesigner = par_formDesigner
    ''    Me.OriginalElementControl = par_originalCtl

    ''    With CtlGraphicFldLabel1

    ''        ''8/29/2019 td''.ElementBaseInfo = par_elementBaseInfo ''Added 8/29/2019 thomas downes
    ''        .ElementInfo_Base = par_elementInfo_Base ''Added 8/29/2019 thomas downes
    ''        .ElementInfo_Text = par_elementInfo_Text

    ''        .Width = .ElementInfo_Base.Width_Pixels
    ''        .Height = .ElementInfo_Base.Height_Pixels

    ''        .FieldInfo = par_fieldInfo
    ''        .LabelText()  ''par_elementInfo.Text)
    ''        ''Denigrated. ---9/19/2019 td''.FormDesigner = par_formDesigner
    ''        .Refresh_Image(True)

    ''    End With ''End of "With CtlGraphicFldLabel1"

    ''    ''Added 9/13/2019 thomas downes
    ''    Me.CtlBorderWidth.ElementInfo_Base = par_elementInfo_Base
    ''    Me.CtlBorderWidth.ElementInfo_Text = par_elementInfo_Text

    ''    ''Position it at the center horizontally. 
    ''    CenterTheFieldControl()

    ''    ''Added 8/17/2019 thomas downes 
    ''    ''8/29 td''LabelNumberOffsetX.Text = String.Format(LabelNumberOffsetX.Tag.ToString, Me.FontOffset_X)
    ''    ''8/29 td''LabelNumberOffsetY.Text = String.Format(LabelNumberOffsetY.Tag.ToString, Me.FontOffset_Y)
    ''    ''8/29 td''LabelFontSizeNum.Text = String.Format(LabelFontSizeNum.Tag.ToString, Me.FontSize)

    ''    ''Added 8/17/2019 thomas downes 
    ''    ''9/13/2019 td''LabelBorderWidth.Text = String.Format(LabelBorderWidth.Tag.ToString, Me.Border_SizeInPixels)

    ''    ''Added 9/9/2019 thomas downes 
    ''    ''9/18/2019 td''chkBorderDisplayed.Checked = Me.Border_Displayed
    ''    chkBorderDisplayed.Checked = Me.ElementCopy_Info_Base.Border_Displayed

    ''End Sub ''End of "Public Sub LoadFieldAndForm_NotInUse(par_field As ClassFieldStandard, par_formDesigner As FormDesignProtoTwo)"

    ''Public Sub LoadFieldAndForm_NotInUse(par_field As ClassFieldStandard, par_formDesigner As FormDesignProtoTwo,
    ''                            par_originalCtl As CtlGraphicFldLabel)
    ''
    ''    Me.FieldInfo = par_field
    ''
    ''    ''9/3/2019 td''Me.ElementInfo_Text = par_field.ElementInfo
    ''    ''This procedure is obselete. ---9/18/2019 td''Me.ElementInfo_Text = CType(par_field.ElementFieldClass, IElement_TextField)
    ''    ''This procedure is obselete. ---9/18/2019 td''Me.ElementInfo_Base = CType(par_field.ElementFieldClass, IElement_Base)
    ''
    ''    ''Added 8/15/2019 td
    ''    ''Denigrated. ---9/19/2019 td''Me.FormDesigner = par_formDesigner
    ''    Me.OriginalElementControl = par_originalCtl
    ''
    ''    With CtlGraphicFldLabel1
    ''        .FieldInfo = par_field
    ''
    ''        ''9/3/2019 td''.ElementInfo_Text = par_field.ElementInfo
    ''        ''Deprecated.  9/18/2019 td''.ElementInfo_Text = CType(par_field.ElementFieldClass, IElement_TextField)
    ''        ''Deprecated.  9/18/2019 td''.ElementInfo_Base = CType(par_field.ElementFieldClass, IElement_Base)
    ''
    ''        ''Denigrated. ---9/19/2019 td''.FormDesigner = par_formDesigner
    ''        .Width = .ElementInfo_Base.Width_Pixels
    ''        .Height = .ElementInfo_Base.Height_Pixels
    ''        .Refresh_Image(True)
    ''
    ''    End With ''End of "With CtlGraphicFldLabel1"
    ''
    ''    ''Position it at the center horizontally. 
    ''    CenterTheFieldControl()
    ''
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

    ''Private Sub ButtonIncrease_Click(sender As Object, e As EventArgs)
    ''    ''
    ''    ''Added 8/16/2019 td
    ''    ''
    ''    ''8/29/2019 td''Me.FontOffset_X += 1
    ''    ''8/29/2019 td''Me.ElementInfo_Text.FontOffset_X += 1

    ''    Me.Border_SizeInPixels += 1
    ''    Me.ElementInfo_Base.Border_WidthInPixels += 1

    ''    CtlGraphicFldLabel1.ElementInfo_Text = Me.ElementInfo_Text
    ''    CtlGraphicFldLabel1.Refresh_Image(True)

    ''    ''Added 8/17/2019 thomas downes 
    ''    ''   8/29/2019 td''LabelNumberOffsetY.Text = String.Format(LabelNumberOffsetY.Tag.ToString, Me.FontOffset_X)
    ''    ''
    ''    LabelBorderWidth.Text = String.Format(LabelBorderWidth.Tag.ToString, Me.Border_SizeInPixels)

    ''End Sub

    ''Private Sub ButtonDecrease_Click(sender As Object, e As EventArgs)
    ''    ''
    ''    ''Added 8/29/2019 td
    ''    ''
    ''    ''8/29/2019 td''Me.FontOffset_X -= 1
    ''    ''8/29/2019 td''Me.ElementInfo_Text.FontOffset_X -= 1

    ''    Me.Border_SizeInPixels -= 1
    ''    Me.ElementInfo_Base.Border_WidthInPixels -= 1

    ''    CtlGraphicFldLabel1.ElementInfo_Text = Me.ElementInfo_Text
    ''    CtlGraphicFldLabel1.Refresh_Image(True)

    ''    ''Added 8/17/2019 thomas downes 
    ''    ''  8/29/2019 td''LabelNumberOffsetY.Text = String.Format(LabelNumberOffsetY.Tag.ToString, Me.FontOffset_X)
    ''    ''
    ''    LabelBorderWidth.Text = String.Format(LabelBorderWidth.Tag.ToString, Me.Border_SizeInPixels)

    ''End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click

        Me.UserConfirmed = True ''Added 9/18/2019 td
        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click

        Me.Close()

    End Sub

    Private Sub ChkBorderDisplayed_CheckedChanged(sender As Object, e As EventArgs) Handles chkBorderDisplayed.CheckedChanged

        ''Added 9/9/2019 thomas downes
        ''
        ''9/13/2019 td''ButtonDecrease.Enabled = chkBorderDisplayed.Checked
        ''9/13/2019 td''ButtonIncrease.Enabled = chkBorderDisplayed.Checked
        ''9/13/2019 td''LabelBorderWidth.Enabled = chkBorderDisplayed.Checked

        CtlBorderWidth.Enabled = chkBorderDisplayed.Checked

    End Sub

    Private Sub CtlBorderWidth_EventUpdateRequest() Handles CtlBorderWidth.EventUpdateRequest
        ''
        ''Added 9/14/2019
        ''
        ''Added 9/13/2019 thomas downes
        With Me.CtlGraphicFldLabel1
            ''---Me.CtlGraphicFldLabel1.Width = Me.ElementInfo_Base.Width_Pixels
            ''---Me.CtlGraphicFldLabel1.Height = Me.ElementInfo_Base.Height_Pixels
            Me.CtlGraphicFldLabel1.Refresh_ImageV3(True)
        End With

    End Sub

    Private Sub DialogTextBorder_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class

