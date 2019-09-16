Option Explicit On ''Added 9/3/2019 td
Option Strict On ''Added 9/3/2019 td
Option Infer Off ''Added 9/3/2019 td

''
''Added 8/15/2019 thomas downes 
''
Imports ciBadgeInterfaces ''Added 8/16/2019 thomas d.

Public Class DialogTextOffset
    ''
    ''Added 8/15/2019 thomas downes 
    ''
    Public FieldInfo As ICIBFieldStandardOrCustom

    ''Added 8/17/2019 td  
    Public FontOffset_X As Integer
    Public FontOffset_Y As Integer
    Public FontSize As Integer
    Public FontSize_ScaleToElement As Boolean ''Added 9/12/2019 td
    Public Font_DrawingClass As Font ''Added 8/17/2019 td 
    Public TextAlignment As System.Windows.Forms.HorizontalAlignment ''Added 8/18/2019 td 

    Public Element_Height As Integer ''Added 9/12/2019 thomas d.
    Public Element_Width As Integer ''Added 9/12/2019 thomas d.

    ''8/17/2019 td''Public ObjElementText As ClassElementText
    ''8/29/2019 td''Public ElementInfo As ciBadgeInterfaces.IElementText ''Added 8/16/2019 td
    Public ElementInfo_Text As ciBadgeInterfaces.IElement_Field ''Renamed 8/29/2019 td
    Public ElementInfo_Base As ciBadgeInterfaces.IElement_Base ''Added 8/29/2019 td

    Public GroupEdits As ISelectingElements ''Added 8/15/2019 thomas downes  
    Public FormDesigner As FormDesignProtoTwo ''Added 8/15/2019 td  
    Public OriginalElementControl As CtlGraphicFldLabel ''Added 8/15/2019 td  

    Public Sub LoadFieldAndForm(par_elementInfo_Base As IElement_Base,
                                par_elementInfo_Text As IElement_Field,
                                par_fieldInfo As ICIBFieldStandardOrCustom,
                                par_formDesigner As FormDesignProtoTwo,
                                par_originalCtl As CtlGraphicFldLabel)
        ''
        ''Worked on 8/16 & 8/15/2019 td
        ''
        Me.FieldInfo = par_fieldInfo

        ''8/16/2019 td''Me.ElementInfo = par_field.ElementInfo
        Me.ElementInfo_Base = par_elementInfo_Base ''Added 9/3/2019 thomas d. 
        Me.ElementInfo_Text = par_elementInfo_Text ''Added 8/16 td

        ''Added 8/17/2019 td
        ''
        Me.FontOffset_X = par_elementInfo_Text.FontOffset_X
        Me.FontOffset_Y = par_elementInfo_Text.FontOffset_Y
        Me.FontSize = CInt(par_elementInfo_Text.FontSize_Pixels) ''9/3 td''par_elementInfo.FontSize
        Me.Font_DrawingClass = par_elementInfo_Text.Font_DrawingClass

        ''Added 8/15/2019 td
        Me.FormDesigner = par_formDesigner
        Me.OriginalElementControl = par_originalCtl

        With CtlGraphicFldLabel1
            .ElementInfo_Text = par_elementInfo_Text

            ''added 9.6.2019 td
            .ElementClass_Obj = Nothing ''CType(par_elementInfo_Text, ClassElementText)
            .ElementInfo_Base = par_elementInfo_Base
            .ElementInfo_Text = par_elementInfo_Text

            .Width = .ElementInfo_Base.Width_Pixels
            .Height = .ElementInfo_Base.Height_Pixels
            .FieldInfo = par_fieldInfo
            .LabelText()  ''par_elementInfo.Text)
            ''8/17/2019 td''.FieldInfo = par_fieldInfo
            ''8/16/2019 td   ''.ElementInfo = par_field.ElementInfo
            .FormDesigner = par_formDesigner
            .Refresh_Image(True)
        End With

        ''Position it at the center horizontally. 
        CenterTheFieldControl()

        ''Added 8/17/2019 thomas downes 
        ''LabelNumberOffsetX.Text = String.Format(LabelNumberOffsetX.Tag.ToString, Me.FontOffset_X)
        ''LabelNumberOffsetY.Text = String.Format(LabelNumberOffsetY.Tag.ToString, Me.FontOffset_Y)
        ''LabelFontSizeNum.Text = String.Format(LabelFontSizeNum.Tag.ToString, Me.FontSize)

        ''
        ''Added 9/13/2019 thomas downes
        ''
        Me.CtlElementHeight.ElementInfo_Base = par_elementInfo_Base
        Me.CtlElementHeight.ElementInfo_Text = par_elementInfo_Text

        Me.CtlElementWidth.ElementInfo_Base = par_elementInfo_Base
        Me.CtlElementWidth.ElementInfo_Text = par_elementInfo_Text

        Me.CtlFontSize.ElementInfo_Base = par_elementInfo_Base
        Me.CtlFontSize.ElementInfo_Text = par_elementInfo_Text

        Me.CtlTextOffsetX.ElementInfo_Base = par_elementInfo_Base
        Me.CtlTextOffsetX.ElementInfo_Text = par_elementInfo_Text

        Me.ctlTextOffsetY.ElementInfo_Base = par_elementInfo_Base
        Me.ctlTextOffsetY.ElementInfo_Text = par_elementInfo_Text

    End Sub ''End of "Public Sub LoadFieldAndForm(par_field As ClassFieldStandard, par_formDesigner As FormDesignProtoTwo)"

    Public Sub LoadFieldAndForm(par_field As ClassFieldStandard, par_formDesigner As FormDesignProtoTwo,
                                 par_originalCtl As CtlGraphicFldLabel)

        Me.FieldInfo = par_field

        Me.ElementInfo_Text = par_field.ElementInfo

        ''Added 8/15/2019 td
        Me.FormDesigner = par_formDesigner
        Me.OriginalElementControl = par_originalCtl

        With CtlGraphicFldLabel1
            .FieldInfo = par_field

            .ElementClass_Obj = par_field.ElementInfo ''Added 9/13/2019 td
            .ElementInfo_Base = par_field.ElementInfo_Base ''Added 9/13/2019 td 
            .ElementInfo_Text = par_field.ElementInfo_Text ''Added 9/13/2019 td 
            .FormDesigner = par_formDesigner
            .Width = .ElementInfo_Base.Width_Pixels
            .Height = .ElementInfo_Base.Height_Pixels
            .Refresh_Image(True)
        End With

        ''Position it at the center horizontally. 
        CenterTheFieldControl()

        ''
        ''Added 9/13/2019 thomas downes
        ''
        Me.CtlElementHeight.ElementInfo_Base = par_field.ElementInfo_Base
        Me.CtlElementHeight.ElementInfo_Text = par_field.ElementInfo_Text
        Me.CtlElementHeight.InitiateLocalValue()

        Me.CtlElementWidth.ElementInfo_Base = par_field.ElementInfo_Base
        Me.CtlElementWidth.ElementInfo_Text = par_field.ElementInfo_Text
        Me.CtlElementWidth.InitiateLocalValue()

        Me.CtlFontSize.ElementInfo_Base = par_field.ElementInfo_Base
        Me.CtlFontSize.ElementInfo_Text = par_field.ElementInfo_Text
        Me.CtlFontSize.InitiateLocalValue()

        Me.CtlTextOffsetX.ElementInfo_Base = par_field.ElementInfo_Base
        Me.CtlTextOffsetX.ElementInfo_Text = par_field.ElementInfo_Text
        Me.CtlTextOffsetX.InitiateLocalValue()

        Me.ctlTextOffsetY.ElementInfo_Base = par_field.ElementInfo_Base
        Me.ctlTextOffsetY.ElementInfo_Text = par_field.ElementInfo_Text
        Me.ctlTextOffsetY.InitiateLocalValue()

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

        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click

        Me.Close()

    End Sub

    Private Sub ButtonLeft_Click(sender As Object, e As EventArgs)

        ''Added 8/18/2019 thomas downes
        ''
        Me.ElementInfo_Text.TextAlignment = HorizontalAlignment.Left
        Me.TextAlignment = HorizontalAlignment.Left
        Me.CtlGraphicFldLabel1.Refresh_Image(True)

    End Sub

    Private Sub ButtonCenter_Click(sender As Object, e As EventArgs) Handles ButtonCenter.Click

        ''Added 8/18/2019 thomas downes
        Me.ElementInfo_Text.TextAlignment = HorizontalAlignment.Center
        Me.TextAlignment = HorizontalAlignment.Center
        Me.CtlGraphicFldLabel1.Refresh_Image(True)

    End Sub

    Private Sub ButtonRight_Click(sender As Object, e As EventArgs) Handles ButtonRight.Click

        ''Added 8/18/2019 thomas downes
        Me.ElementInfo_Text.TextAlignment = HorizontalAlignment.Right
        Me.TextAlignment = HorizontalAlignment.Right
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
        Me.ElementInfo_Text.FontSize_ScaleToElementYesNo = checkFontSizeScalesYN.Checked

    End Sub

    Private Sub For_EventUpdateRequest() Handles ctlTextOffsetY.EventUpdateRequest, CtlFontSize.EventUpdateRequest,
        CtlElementHeight.EventUpdateRequest, CtlTextOffsetX.EventUpdateRequest, CtlElementWidth.EventUpdateRequest

        ''Added 9/13/2019 thomas downes
        With Me.CtlGraphicFldLabel1
            Me.CtlGraphicFldLabel1.Width = Me.ElementInfo_Base.Width_Pixels
            Me.CtlGraphicFldLabel1.Height = Me.ElementInfo_Base.Height_Pixels
            Me.CtlGraphicFldLabel1.Refresh_Image(True)
        End With

    End Sub

    Private Sub CtlElementWidth_Load(sender As Object, e As EventArgs) Handles CtlElementWidth.Load

    End Sub
End Class