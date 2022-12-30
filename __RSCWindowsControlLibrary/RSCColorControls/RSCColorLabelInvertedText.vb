''Public Class RSCColorLabelInvertedText
''
''Added 8/22/2022 td
''
Imports ciBadgeInterfaces ''Added 10/28/2022
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class RSCColorLabelInvertedText
    ''
    ''Added 12/30/2022 & 8/22/2022 td
    ''
    ''  (Copy-pasted from RSCColorDisplayLabel.) 
    ''
    Private mod_rscDisplayColor As ciBadgeInterfaces.RSCColor
    Private mod_strMSNetColorName As String ''Added 10/24/2022

    Public Event ColorClick(sender As Object, e As EventArgs)

    Public Shared Function GetLabel(par_colorMS As Drawing.Color) As RSCColorLabelInvertedText
        '' Added 10/28/2022 td 
        Dim objControl As New RSCColorLabelInvertedText(par_colorMS)

        objControl.BackColor = par_colorMS
        objControl.Text = par_colorMS.Name
        Return objControl

    End Function ''Public Shared Function GetLabel  


    Public Shared Function GetLabel(par_colorRSC As RSCColor) As RSCColorLabelInvertedText
        '' Added 10/28/2022 td 
        Dim objControl As New RSCColorLabelInvertedText(par_colorRSC)
        objControl.BackColor = par_colorRSC.MSNetColor
        objControl.Text = par_colorRSC.MSNetColor.Name
        Return objControl

    End Function ''Public Shared Function GetLabel  


    Public Sub New(par_colorMS As Drawing.Color)
        ''Added 10/28/2022
        ' This call is required by the designer.
        InitializeComponent()

        ''Added 11/21/2022
        mod_rscDisplayColor = New RSCColor(par_colorMS)

        ' Add any initialization after the InitializeComponent() call.
        Me.BackColor = par_colorMS
        Me.Text = par_colorMS.Name
        ''LabelBackcolorLeft.ToolTip = Me.Text
        ''LabelBackcolorLeft.ToolTip = Me.Text
        ToolTip1.SetToolTip(LabelBackcolorLeft, Me.Text)
        ''12/2022 ToolTip1.SetToolTip(LabelBackcolorRight, Me.Text)

    End Sub ''End of Public Sub New  (par_colorMS As Drawing.Color)


    Public Sub New(par_colorRSC As RSCColor)
        ''Added 10/28/2022
        ' This call is required by the designer.
        InitializeComponent()

        ''Added 11/21/2022 
        mod_rscDisplayColor = par_colorRSC

        ' Add any initialization after the InitializeComponent() call.
        Me.BackColor = par_colorRSC.MSNetColor
        ''----Me.Text = par_colorRSC.MSNetColor.Name

        Me.Text = par_colorRSC.MSNetColorName()

        ''Added 10/28/2022
        ToolTip1.SetToolTip(LabelBackcolorLeft,
                        (par_colorRSC.Name_andDescription()))
        ''12/2022 ToolTip1.SetToolTip(LabelBackcolorRight,
        ''                (par_colorRSC.Name_andDescription()))

    End Sub ''End of Public Sub New  (paraM_colorMS As Drawing.Color)


    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Overrides Property BackColor As Color
        Get
            ''Added 8/22/2022 td
            Return LabelBackcolorLeft.BackColor
        End Get
        Set(value As Color)
            ''Added 8/22/2022 td
            ''----LoadColor(New RSCColor(value))
            LabelBackcolorLeft.BackColor = value
            ''12/2022 LabelBackcolorRight.BackColor = value

            ''Added 12/30/2022
            ''  Inverse color!!!!
            ''
            LabelBackcolorLeft.ForeColor = RSCColor.GetInverseMSColor(value)

        End Set
    End Property ''Ednof ""Public Property BackColor""


    Public Sub LoadAndDisplayRSCColor(par_rscColor As RSCColor)
        ''
        ''Added 10/28/2022
        ''
        ' Add any initialization after the InitializeComponent() call.
        ''11/18/2022 Me.BackColor = par_rscColor.MSNetColor

        ''Added 11/18/2022
        Dim objColorMSNet As Drawing.Color
        objColorMSNet = par_rscColor.MSNetColor
        If (objColorMSNet = Color.Empty) Then
            objColorMSNet = Color.Black
            par_rscColor.MSNetColor = Color.Black
        End If ''End of ""If (objColorMSNet = Color.Empty) Then""
        Me.BackColor = objColorMSNet

        Me.Text = par_rscColor.MSNetColor.Name

        LabelBackcolorLeft.Text = par_rscColor.MSNetColor.Name
        LabelBackcolorLeft.BackColor = par_rscColor.MSNetColor
        ''Added 12/30/2022
        ''  Inverse color!!!!
        LabelBackcolorLeft.ForeColor = par_rscColor.GetInverseMSColor()

        mod_rscDisplayColor = par_rscColor

    End Sub ''End of ""Public Sub LoadAndDisplayRSCColor""


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

            ''12.2022 LabelBackcolorRight.BackColor = mod_rscDisplayColor.MSNetColor
            LabelBackcolorLeft.BackColor = mod_rscDisplayColor.MSNetColor
            ''Added 12/30/2022
            ''  Inverse color!!!!
            LabelBackcolorLeft.ForeColor = mod_rscDisplayColor.GetInverseMSColor()

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
            ''12.2022 LabelBackcolorRight.Text = value

            ''Text-Position Alignment
            LabelBackcolorLeft.TextAlign = ContentAlignment.MiddleLeft
            ''12.2022 LabelBackcolorRight.TextAlign = ContentAlignment.MiddleRight

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
            ''12.2022 LabelBackcolorRight.Font = fontSmallerIfLongColorname

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

    Private Sub LabelBackcolorRight_Click(sender As Object, e As EventArgs)
        ''12.2022 Handles LabelBackcolorRight.Click, Me.Click

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

