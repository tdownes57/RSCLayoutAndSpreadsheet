''
''Added 8/29/2019 thomas downes 
''
Imports ciBadgeInterfaces ''Added 8/29/2019 thomas d.

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

    Public Border_SizeInPixels As Integer ''Added 8/29/2019 td
    Public Border_Color As Drawing.Color ''Added 8/29/2019 td
    Public Border_Displayed As Boolean ''Added 9/9/2019 td  

    ''8/29/2019 td''Public ElementInfo As ciBadgeInterfaces.IElementText ''Added 8/16/2019 td
    Public ElementInfo_Text As ciBadgeInterfaces.IElement_TextField ''Added 8/16/2019 td
    Public ElementInfo_Base As ciBadgeInterfaces.IElement_Base ''Added 8/16/2019 td

    Public GroupEdits As ISelectingElements ''Added 8/15/2019 thomas downes  
    Public FormDesigner As FormDesignProtoTwo ''Added 8/15/2019 td  
    Public OriginalElementControl As CtlGraphicFldLabel ''Added 8/15/2019 td  

    Public Sub UpdateInfo(par_elementInfo As IElement_Base)
        ''
        ''added 9/17 td
        ''
        With par_elementInfo

            .Border_Color = Me.Border_Color
            .Border_Displayed = Me.Border_Displayed
            .Border_WidthInPixels = Me.Border_SizeInPixels

        End With

    End Sub ''Public Sub UpdateInfo(par_elementInfo As IElement_Base)

    Public Sub LoadFieldAndForm(par_elementInfo_Base As IElement_Base,
                                par_elementInfo_Text As IElement_TextField,
                                par_fieldInfo As ICIBFieldStandardOrCustom,
                                par_formDesigner As FormDesignProtoTwo,
                                par_originalCtl As CtlGraphicFldLabel)
        ''
        ''Modelled after DialogTextOffset, 8/29/2019  
        ''Modified on 8/29/2019 td
        ''
        Me.FieldInfo = par_fieldInfo

        Me.ElementInfo_Base = par_elementInfo_Base ''Added 9/3/2019 td
        Me.ElementInfo_Text = par_elementInfo_Text ''Added 8/16 td

        ''Added 8/17/2019 td
        ''
        ''8/29 td''Me.FontOffset_X = par_elementInfo.FontOffset_X
        ''8/29 td''Me.FontOffset_Y = par_elementInfo.FontOffset_Y
        ''8/29 td''Me.FontSize = par_elementInfo.FontSize
        ''8/29 td''Me.Font_DrawingClass = par_elementInfo.Font_DrawingClass

        Me.Border_SizeInPixels = par_elementInfo_Base.Border_WidthInPixels
        Me.Border_Color = par_elementInfo_Base.Border_Color
        Me.Border_Displayed = par_elementInfo_Base.Border_Displayed ''Added 9/9/2019 td 

        ''Added 8/15/2019 td
        Me.FormDesigner = par_formDesigner
        Me.OriginalElementControl = par_originalCtl

        With CtlGraphicFldLabel1

            ''8/29/2019 td''.ElementBaseInfo = par_elementBaseInfo ''Added 8/29/2019 thomas downes
            .ElementInfo_Base = par_elementInfo_Base ''Added 8/29/2019 thomas downes
            .ElementInfo_Text = par_elementInfo_Text

            .Width = .ElementInfo_Base.Width_Pixels
            .Height = .ElementInfo_Base.Height_Pixels

            .FieldInfo = par_fieldInfo
            .LabelText()  ''par_elementInfo.Text)
            .FormDesigner = par_formDesigner
            .Refresh_Image(True)

        End With ''End of "With CtlGraphicFldLabel1"

        ''Added 9/13/2019 thomas downes
        Me.CtlBorderWidth.ElementInfo_Base = par_elementInfo_Base
        Me.CtlBorderWidth.ElementInfo_Text = par_elementInfo_Text

        ''Position it at the center horizontally. 
        CenterTheFieldControl()

        ''Added 8/17/2019 thomas downes 
        ''8/29 td''LabelNumberOffsetX.Text = String.Format(LabelNumberOffsetX.Tag.ToString, Me.FontOffset_X)
        ''8/29 td''LabelNumberOffsetY.Text = String.Format(LabelNumberOffsetY.Tag.ToString, Me.FontOffset_Y)
        ''8/29 td''LabelFontSizeNum.Text = String.Format(LabelFontSizeNum.Tag.ToString, Me.FontSize)

        ''Added 8/17/2019 thomas downes 
        ''9/13/2019 td''LabelBorderWidth.Text = String.Format(LabelBorderWidth.Tag.ToString, Me.Border_SizeInPixels)

        ''Added 9/9/2019 thomas downes 
        chkBorderDisplayed.Checked = Me.Border_Displayed

    End Sub ''End of "Public Sub LoadFieldAndForm(par_field As ClassFieldStandard, par_formDesigner As FormDesignProtoTwo)"

    Public Sub LoadFieldAndForm(par_field As ClassFieldStandard, par_formDesigner As FormDesignProtoTwo,
                                par_originalCtl As CtlGraphicFldLabel)

        Me.FieldInfo = par_field

        ''9/3/2019 td''Me.ElementInfo_Text = par_field.ElementInfo
        Me.ElementInfo_Text = CType(par_field.ElementFieldClass, IElement_TextField)
        Me.ElementInfo_Base = CType(par_field.ElementFieldClass, IElement_Base)

        ''Added 8/15/2019 td
        Me.FormDesigner = par_formDesigner
        Me.OriginalElementControl = par_originalCtl

        With CtlGraphicFldLabel1
            .FieldInfo = par_field

            ''9/3/2019 td''.ElementInfo_Text = par_field.ElementInfo
            .ElementInfo_Text = CType(par_field.ElementFieldClass, IElement_TextField)
            .ElementInfo_Base = CType(par_field.ElementFieldClass, IElement_Base)

            .FormDesigner = par_formDesigner
            .Width = .ElementInfo_Base.Width_Pixels
            .Height = .ElementInfo_Base.Height_Pixels
            .Refresh_Image(True)

        End With ''End of "With CtlGraphicFldLabel1"

        ''Position it at the center horizontally. 
        CenterTheFieldControl()

    End Sub ''End of "Public Sub LoadFieldAndForm(par_field As ClassFieldStandard, par_formDesigner As FormDesignProtoTwo)"

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
            Me.CtlGraphicFldLabel1.Refresh_Image(True)
        End With

    End Sub
End Class

