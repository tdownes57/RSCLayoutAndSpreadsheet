
Imports ciBadgeInterfaces
Imports System.Drawing ''Added 12/30/2021 td

Public Class CtlPropertyUpDownvb

    Private mod_sPropertyName As String = "Property"
    Private mod_iPropertyValue As Integer = 10
    Private mod_iMinimumValue As Integer = 0 ''Added 9/18/2019 td  

    Public _ElementInfo_Base As IElement_Base
    ''10/12/2019 td''Public _ElementInfo_Text As IElement_TextField
    Public _ElementInfo_Text As IElement_TextOnly

    Public Event EventUpdateRequest()

    Public Property ElementInfo_Base As IElement_Base
        Get
            Return _ElementInfo_Base
        End Get
        Set(value As IElement_Base)
            _ElementInfo_Base = value
        End Set

    End Property

    Public Property ElementInfo_Text As IElement_TextOnly
        ''10/12 td''Public Property ElementInfo_Text As IElement_TextField
        Get
            Return _ElementInfo_Text
        End Get
        Set(value As IElement_TextOnly)
            _ElementInfo_Text = value
        End Set

    End Property

    Public Property PropertyName As String

        Get
            Return mod_sPropertyName
        End Get
        Set(value As String)
            mod_sPropertyName = value
            ''9/13/2019 td''LabelProperty.Text = (mod_sPropertyName & ": " & CStr(mod_iPropertyValue))
            UpdateUserFeedbackLabel()
        End Set
    End Property

    Public Property PropertyValue As Integer
        Get
            Return mod_iPropertyValue
        End Get
        Set(value As Integer)
            mod_iPropertyValue = value
            ''9/13/2019 td''LabelProperty.Text = (mod_sPropertyName & ": " & CStr(mod_iPropertyValue))
            UpdateUserFeedbackLabel()
        End Set
    End Property

    Public Property MinimumValue As Integer
        Get
            ''Added 9/18/2019 td
            Return mod_iMinimumValue
        End Get
        Set(value As Integer)
            ''Added 9/18/2019 td
            mod_iMinimumValue = value
        End Set
    End Property

    Public Overloads Property Enabled As Boolean
        Get
            ''Added 9/23/2019 td
            Return ButtonIncrease.Enabled
        End Get
        Set(value As Boolean)
            ''Added 9/23/2019 td
            MyBase.Enabled = value
            ButtonIncrease.Enabled = value
            ButtonDecrease.Enabled = value
            LabelProperty.Enabled = value

        End Set
    End Property ''eNdof "Public Overloads Property Enabled As Boolean"

    Public Overloads Property BackColor As Color
        Get
            ''Added 9/23/2019 td
            Return MyBase.BackColor
        End Get
        Set(value As Color)
            ''Added 9/23/2019 td
            MyBase.BackColor = value
            LabelProperty.BackColor = value
        End Set
    End Property ''eNdof "Public Overloads Property BackColor As Color"

    Private Sub ButtonDecrease_Click(sender As Object, e As EventArgs) Handles ButtonDecrease.Click

        mod_iPropertyValue -= 1
        If (mod_iPropertyValue < 0) Then mod_iPropertyValue = 0

        ''9/13/2019 td''LabelProperty.Text = (mod_sPropertyName & ": " & CStr(mod_iPropertyValue))
        ''9/19/2019 td''UpdateUserFeedbackLabel()
        UpdateElementInfo(mod_iPropertyValue)
        UpdateUserFeedbackLabel()
        RaiseEvent EventUpdateRequest()

    End Sub

    Private Sub ButtonIncrease_Click(sender As Object, e As EventArgs) Handles ButtonIncrease.Click

        mod_iPropertyValue += 1
        If (mod_iPropertyValue < 0) Then mod_iPropertyValue = 0

        ''9/13/2019 td''LabelProperty.Text = (mod_sPropertyName & ": " & CStr(mod_iPropertyValue))
        ''9/19/2019 td''UpdateUserFeedbackLabel()
        UpdateElementInfo(mod_iPropertyValue)
        UpdateUserFeedbackLabel()
        RaiseEvent EventUpdateRequest()

    End Sub

    Private Sub UpdateUserFeedbackLabel()
        ''
        ''9/13/2019 
        ''
        LabelProperty.Text = (mod_sPropertyName & ": " & CStr(mod_iPropertyValue))

        ''Added 9/19/2019 td
        Dim boolVeryLongName As Boolean ''Added 9/19/2019 td
        boolVeryLongName = (mod_sPropertyName.Length >= "Total Height of Label".Length)
        If (boolVeryLongName) Then ''Added 9/19/2019 td
            ''Make the label font smaller. 
            LabelProperty.Font = modFonts.SetFontSize(LabelProperty.Font, -1 + LabelProperty.Font.Size)
        End If ''End of "If (boolVeryLongName) Then"

        Me.Refresh()

    End Sub

    Private Sub UpdateElementInfo(par_value As Integer)
        ''
        ''Added 9/13/2019 thomas d. 
        ''
        With mod_sPropertyName

            Select Case True

                Case (.StartsWith("Text") Or .StartsWith("Off"))

                    Me.ElementInfo_Text.FontOffset_Y = par_value

                Case (.StartsWith("Font"))

                    Me.ElementInfo_Text.FontSize_Pixels = par_value

                Case (.StartsWith("Total") Or .StartsWith("Label"))

                    Me.ElementInfo_Base.Height_Pixels = par_value

                Case (.StartsWith("Border"))

                    ''Added 9/14/2019 td  
                    Me.ElementInfo_Base.Border_WidthInPixels = par_value

                Case Else

                    ''Added 9/14/2019 td
                    ''
                    MessageBox.Show("The element property is not being determined, and hence nothing will happen.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation)


            End Select ''End of "Select Case True"

        End With ''End of " With mod_sPropertyName"

    End Sub ''End of "Private Sub UpdateElementInfo()"

    Public Sub InitiateLocalValue()
        ''
        ''Added 9/14/2019 td
        ''
        InitiateLocalValue(Me.ElementInfo_Base, Me.ElementInfo_Text)

    End Sub

    Public Sub InitiateLocalValue(par_Base As IElement_Base,
                                   par_Text As IElement_TextOnly)
        ''
        ''Added 9/14/2019 thomas d. 
        ''
        With mod_sPropertyName

            Select Case True

                Case (.StartsWith("Text") Or .StartsWith("Off"))

                    mod_iPropertyValue = par_Text.FontOffset_Y ''= par_value

                Case (.StartsWith("Font"))

                    ''Dec31 2021''mod_iPropertyValue = par_Text.FontSize_Pixels ''= par_value
                    mod_iPropertyValue = CInt(par_Text.FontSize_Pixels) ''= par_value

                Case (.StartsWith("Total") Or .StartsWith("Label"))

                    mod_iPropertyValue = par_Base.Height_Pixels ''= par_value

            End Select ''End of "Select Case True"

        End With ''End of " With mod_sPropertyName"

        ''Added 9/19/2019 td  
        UpdateUserFeedbackLabel()

    End Sub ''End of "Public Sub InitiateLocalValue(par_Base As IElement_Base, ...)"

    Private Sub LabelProperty_Click(sender As Object, e As EventArgs) Handles LabelProperty.Click

    End Sub
End Class
