''
''Added 8/15/2019 thomas downes 
''
Imports ciBadgeInterfaces ''Added 8/16/2019 thomas d.

Public Class FormOffsetText
    ''
    ''Added 8/15/2019 thomas downes 
    ''
    Public FieldInfo As ICIBFieldStandardOrCustom

    ''Added 8/17/2019 td  
    Public FontOffset_X As Integer
    Public FontOffset_Y As Integer
    Public FontSize As Integer

    Public ObjElementText As ClassElementText
    Public ElementInfo As ciBadgeInterfaces.IElementText ''Added 8/16/2019 td

    Public GroupEdits As ISelectingElements ''Added 8/15/2019 thomas downes  
    Public FormDesigner As FormDesignProtoTwo ''Added 8/15/2019 td  
    Public OriginalElementControl As CtlGraphicFldLabel ''Added 8/15/2019 td  

    Public Sub LoadFieldAndForm(par_elementInfo As IElementText,
                                par_fieldInfo As ICIBFieldStandardOrCustom,
                                par_formDesigner As FormDesignProtoTwo,
                                par_originalCtl As CtlGraphicFldLabel)
        ''
        ''Worked on 8/16 & 8/15/2019 td
        ''
        Me.FieldInfo = par_fieldInfo

        ''8/16/2019 td''Me.ElementInfo = par_field.ElementInfo
        Me.ElementInfo = par_elementInfo ''Added 8/16 td

        ''Added 8/17/2019 td
        ''
        Me.FontOffset_X = par_elementInfo.FontOffset_X
        Me.FontOffset_Y = par_elementInfo.FontOffset_Y
        Me.FontSize = par_elementInfo.FontSize

        ''Added 8/15/2019 td
        Me.FormDesigner = par_formDesigner
        Me.OriginalElementControl = par_originalCtl

        With CtlGraphicFldLabel1
            .ElementInfo = par_elementInfo
            .Width = .ElementInfo.Width_Pixels
            .Height = .ElementInfo.Height_Pixels
            .FieldInfo = par_fieldInfo
            .LabelText()  ''par_elementInfo.Text)
            ''8/17/2019 td''.FieldInfo = par_fieldInfo
            ''8/16/2019 td   ''.ElementInfo = par_field.ElementInfo
            .FormDesigner = par_formDesigner
            .RefreshImage()
        End With

        ''Position it at the center horizontally. 
        CenterTheFieldControl()

    End Sub ''End of "Public Sub LoadFieldAndForm(par_field As ClassFieldStandard, par_formDesigner As FormDesignProtoTwo)"

    Public Sub LoadFieldAndForm(par_field As ClassFieldStandard, par_formDesigner As FormDesignProtoTwo,
                                par_originalCtl As CtlGraphicFldLabel)

        Me.FieldInfo = par_field

        Me.ElementInfo = par_field.ElementInfo

        ''Added 8/15/2019 td
        Me.FormDesigner = par_formDesigner
        Me.OriginalElementControl = par_originalCtl

        With CtlGraphicFldLabel1
            .FieldInfo = par_field
            .ElementInfo = par_field.ElementInfo
            .FormDesigner = par_formDesigner
            .Width = .ElementInfo.Width_Pixels
            .Height = .ElementInfo.Height_Pixels
            .RefreshImage()
        End With

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

    Private Sub FormOffsetText_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonXIncrease_Click(sender As Object, e As EventArgs) Handles ButtonXIncrease.Click
        ''
        ''Added 8/16/2019 td
        ''
        Me.FontOffset_X += 1
        Me.ElementInfo.FontOffset_X += 1
        CtlGraphicFldLabel1.ElementInfo = Me.ElementInfo
        CtlGraphicFldLabel1.RefreshImage()

    End Sub

    Private Sub ButtonXDecrease_Click(sender As Object, e As EventArgs) Handles ButtonXDecrease.Click
        ''
        ''Added 8/16/2019 td
        ''
        Me.FontOffset_X -= 1
        Me.ElementInfo.FontOffset_X -= 1
        CtlGraphicFldLabel1.ElementInfo = Me.ElementInfo
        CtlGraphicFldLabel1.RefreshImage()

    End Sub

    Private Sub ButtonYDecrease_Click(sender As Object, e As EventArgs) Handles ButtonYDecrease.Click
        ''
        ''Added 8/16/2019 td
        ''
        Me.FontOffset_Y -= 1
        Me.ElementInfo.FontOffset_Y -= 1
        CtlGraphicFldLabel1.ElementInfo = Me.ElementInfo
        CtlGraphicFldLabel1.RefreshImage()

    End Sub

    Private Sub ButtonYIncrease_Click(sender As Object, e As EventArgs) Handles ButtonYIncrease.Click
        ''
        ''Added 8/16/2019 td
        ''
        Me.FontOffset_Y += 1
        Me.ElementInfo.FontOffset_Y += 1
        CtlGraphicFldLabel1.ElementInfo = Me.ElementInfo
        CtlGraphicFldLabel1.RefreshImage()

    End Sub

    Private Sub ButtonFontDecrease_Click(sender As Object, e As EventArgs) Handles ButtonFontDecrease.Click

        ''Added 8/16/2019  td
        With Me.ElementInfo
            .FontSize -= 1
            LabelFontSizeNum.Text = String.Format(LabelFontSizeNum.Tag.ToString, .FontSize)
            .Font_AllInfo = modFonts.SetFontSize(.Font_AllInfo, .FontSize)

            ''Added 8/17/2019 thomas downes 
            LabelFontSizeNum.Text = String.Format(LabelFontSizeNum.Tag.ToString, .FontSize)

        End With

        CtlGraphicFldLabel1.ElementInfo = Me.ElementInfo
        CtlGraphicFldLabel1.RefreshImage()


    End Sub

    Private Sub ButtonFontIncrease_Click(sender As Object, e As EventArgs) Handles ButtonFontIncrease.Click
        ''
        ''Added 8 / 16 / 2019  td
        ''
        With Me.ElementInfo
            .FontSize += 1
            LabelFontSizeNum.Text = String.Format(LabelFontSizeNum.Tag.ToString, .FontSize)
            .Font_AllInfo = modFonts.SetFontSize(.Font_AllInfo, .FontSize)

            ''Added 8/17/2019 thomas downes 
            LabelFontSizeNum.Text = String.Format(LabelFontSizeNum.Tag.ToString, .FontSize)

        End With

        CtlGraphicFldLabel1.ElementInfo = Me.ElementInfo
        CtlGraphicFldLabel1.RefreshImage()

    End Sub
End Class