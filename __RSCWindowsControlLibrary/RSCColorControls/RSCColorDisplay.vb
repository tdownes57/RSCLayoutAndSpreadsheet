﻿''
''Added 7/8/2022
''
Imports ciBadgeInterfaces ''Added 8/10/2022 thomas downes

Public Enum EnumRSCBackOrFore
    Undetermined
    Backcolor
    Forecolor
    Either
End Enum ''End of ""Public Enum EnumRSCBackOrFore"" 


Public Class RSCColorDisplay
    ''
    ''Added 7/8/2022
    ''
    Public Shared Function GetColorDisplay(par_RSCColor As RSCColor,
        par_enumGround As EnumRSCBackOrFore) As RSCColorDisplay
        ''
        ''Added 7/9/2022
        ''
        Dim objOutputControl As RSCColorDisplay

        objOutputControl = New RSCColorDisplay()
        ''7/09/2022 thomas downes''objOutputControl.LoadColor(par_RSCColor.DColor, par_enumGround)
        objOutputControl.LoadAndDisplayRSCColor(par_RSCColor, par_enumGround)
        Return objOutputControl

    End Function ''End of ""Public Shared Function GetColorDisplay""

    ''7/09/2022 thomas''Public Property DisplayColor As Drawing.Color
    Public Property DisplayRSCColor As RSCColor ''8/10/2022 RSCColor_seeCIBInterfaces

    Public Property HideForegroundLabels As Boolean
        Get
            ''7/9/2022 td
            Return LabelForecolorLeft.Visible
        End Get
        Set(value As Boolean)
            ''7/9/2022 td
            LabelForecolorLeft.Visible = (Not value) ''Turn forecolor labels off/OFF. 
            LabelForecolorRight.Visible = (Not value) ''Turn forecolor labels off/OFF.
            LabelBackcolorBottom.Visible = (Not value) ''Turn backcolor labels off/OFF.
            LabelBackcolorTop.Visible = (Not value) ''Turn backcolor labels off/OFF.
        End Set
    End Property


    Public Property HideBackgroundLabels As Boolean
        Get
            ''7/9/2022 td
            Return LabelForecolorLeft.Visible
        End Get
        Set(value As Boolean)
            ''7/9/2022 td
            LabelBackcolorBottom.Visible = (Not value) ''Turn backcolor labels off/OFF.
            LabelBackcolorTop.Visible = (Not value) ''Turn backcolor labels off/OFF.
        End Set
    End Property


    Public Sub LoadAndDisplayRSCColor(par_RSCcolor As RSCColor,
               Optional par_enum As EnumRSCBackOrFore = EnumRSCBackOrFore.Undetermined)
        ''7/9/2022 Public Sub LoadColor(par_color As Drawing.Color,
        ''
        ''Added 7/8/2022 th9omas downes
        ''
        ''July9 2022 ''DisplayColor = par_color
        DisplayRSCColor = par_RSCcolor

        ''Set the color. 
        LabelForecolorLeft.ForeColor = par_RSCcolor.MSNetColor
        LabelForecolorRight.ForeColor = par_RSCcolor.MSNetColor
        LabelBackcolorBottom.BackColor = par_RSCcolor.MSNetColor
        LabelBackcolorTop.BackColor = par_RSCcolor.MSNetColor

        ''Added 7/09/2022 thomas downes 
        Select Case par_enum
            Case EnumRSCBackOrFore.Backcolor

                LabelBackcolorBottom.Visible = True ''Turn backcolor labels on/ON.
                LabelBackcolorTop.Visible = True ''Turn backcolor labels on/OFN.
                LabelForecolorLeft.Visible = False ''Turn forecolor labels off/OFF. 
                LabelForecolorRight.Visible = False ''Turn forecolor labels off/OFF.

            Case EnumRSCBackOrFore.Forecolor

                LabelForecolorLeft.Visible = True ''Turn forecolor labels on/ON. 
                LabelForecolorRight.Visible = True ''Turn forecolor labels on/ON.
                LabelBackcolorBottom.Visible = False ''Turn backcolor labels off/OFF.
                LabelBackcolorTop.Visible = False ''Turn backcolor labels off/OFF.

            Case Else
                ''
                ''Default
                ''
                LabelForecolorLeft.Visible = True ''Turn forecolor labels on/ON. 
                LabelForecolorRight.Visible = True ''Turn forecolor labels on/ON.
                LabelBackcolorBottom.Visible = True ''Turn backcolor labels on/ON.
                LabelBackcolorTop.Visible = True ''Turn backcolor labels on/OFN.

        End Select ''End of ""Select Case par_enum""


    End Sub ''End of ""Public Sub LoadRSCColor""    


    Private Sub LabelBottom_Click(sender As Object, e As EventArgs) Handles LabelBackcolorBottom.Click

    End Sub
End Class
