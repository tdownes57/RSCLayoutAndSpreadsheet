''
''Added 8/22/2022 td
''

Public Class RSCColorDisplayLabel ''Public Class RSCColorDisplayMini 
    ''
    ''Added 8/22/2022 td
    ''
    Private mod_rscDisplayColor As ciBadgeInterfaces.RSCColor
    Private mod_strMSNetColorName As String ''Added 10/24/2022

    Public Event ColorClick(sender As Object, e As EventArgs)

    Public Overrides Property BackColor As Color
        Get
            ''Added 8/22/2022 td
            Return LabelBackcolorLeft.BackColor
        End Get
        Set(value As Color)
            ''Added 8/22/2022 td
            ''----LoadColor(New RSCColor(value))
            LabelBackcolorLeft.BackColor = value
            LabelBackcolorRight.BackColor = value
        End Set
    End Property ''Ednof ""Public Property BackColor""


    Public Property RSCDisplayColor As ciBadgeInterfaces.RSCColor
        Get
            ''Added 8/22/2022 td
            ''---UpdatePrivateModuleRSCColor()
            Return mod_rscDisplayColor ''LabelBackcolorLeft.BackColor

        End Get
        Set(value As ciBadgeInterfaces.RSCColor)
            ''Added 8/22/2022 td
            ''----LoadColor(New RSCColor(value))
            If (value Is Nothing) Then
                mod_rscDisplayColor = New ciBadgeInterfaces.RSCColor(Me.BackColor)
            Else
                mod_rscDisplayColor = value
            End If ''End of ""If (value Is Nothing) Then""
            LabelBackcolorLeft.BackColor = mod_rscDisplayColor.MSNetColor
            LabelBackcolorRight.BackColor = mod_rscDisplayColor.MSNetColor

        End Set
    End Property ''Ednof ""Public Property RSCDisplayColor""


    Public Overrides Property Text As String
        Get
            ''Added 8/22/2022 td
            Return LabelBackcolorLeft.Text
        End Get
        Set(value As String)
            ''Added 8/22/2022 td
            Const c_single_emSize As Single = 12
            LabelBackcolorLeft.Text = value
            LabelBackcolorRight.Text = value

            ''Text-Position Alignment
            LabelBackcolorLeft.TextAlign = ContentAlignment.MiddleLeft
            LabelBackcolorRight.TextAlign = ContentAlignment.MiddleRight

            ''
            ''Adjusting the size of the font, according to the length
            '' of the name of the color....
            ''
            ''E.g. "Light Orangewood" will be put into a smaller font. 
            ''
            ''This will require trial and error to perfect the sizing. 
            ''
            Dim fontSmallerIfLongColorname As Font
            Dim font_family As FontFamily

            font_family = LabelBackcolorLeft.Font.FontFamily
            Select Case True
                Case (value.Length < 10)
                    fontSmallerIfLongColorname = New Font(font_family, c_single_emSize)

                Case (value.Length >= 10 And value.Length < 20)
                    fontSmallerIfLongColorname = New Font(font_family, c_single_emSize - 2)

                Case (value.Length >= 20 And value.Length < 100)
                    fontSmallerIfLongColorname = New Font(font_family, c_single_emSize - 4)

                Case Else
                    fontSmallerIfLongColorname = New Font(font_family, c_single_emSize)
            End Select
            LabelBackcolorLeft.Font = fontSmallerIfLongColorname
            LabelBackcolorRight.Font = fontSmallerIfLongColorname

        End Set
    End Property ''Ednof ""Public Property BackColor""


    Public Property MSNetColorName As String
        Get
            ''Added 10/24/2022 td
            Return mod_strMSNetColorName
        End Get
        Set(value As String)
            ''Added 10/24/2022 td
            mod_strMSNetColorName = value
        End Set
    End Property ''Ednof ""Public Property BackColor""


    Private Sub LabelBackcolorLeft_Click(sender As Object, e As EventArgs) Handles LabelBackcolorLeft.Click

        ''Added 8/22/2022
        RaiseEvent ColorClick(Me, New EventArgs())

    End Sub

    Private Sub LabelBackcolorRight_Click(sender As Object, e As EventArgs) _
        Handles LabelBackcolorRight.Click, Me.Click

        ''Added 8/22/2022
        RaiseEvent ColorClick(Me, New EventArgs())

    End Sub


    ''Private Sub UpdatePrivateModuleRSCColor()
    ''    ''
    ''    ''Added 8/22/2022 thomas downes
    ''    ''
    ''    Dim objRSCColor As ciBadgeInterfaces.RSCColor
    ''    objRSCColor = New ciBadgeInterfaces.RSCColor(Text)
    ''End Sub ''end of ""Private Sub UpdatePrivateModuleRSCColor()""




End Class
