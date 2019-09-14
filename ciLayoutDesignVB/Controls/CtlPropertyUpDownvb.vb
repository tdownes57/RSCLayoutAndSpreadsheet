
Imports ciBadgeInterfaces
Public Class CtlPropertyUpDownvb

    Private mod_sPropertyName As String = "Property"
    Private mod_iPropertyValue As Integer = 10

    Public _ElementInfo_Base As IElement_Base
    Public _ElementInfo_Text As IElement_Text
    Public Event EventUpdateRequest()

    Public Property ElementInfo_Base As IElement_Base
        Get
            Return _ElementInfo_Base
        End Get
        Set(value As IElement_Base)
            _ElementInfo_Base = value
        End Set

    End Property

    Public Property ElementInfo_Text As IElement_Text
        Get
            Return _ElementInfo_Text
        End Get
        Set(value As IElement_Text)
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

    Private Sub ButtonDecrease_Click(sender As Object, e As EventArgs) Handles ButtonFontDecrease.Click

        mod_iPropertyValue -= 1
        If (mod_iPropertyValue < 0) Then mod_iPropertyValue = 0

        ''9/13/2019 td''LabelProperty.Text = (mod_sPropertyName & ": " & CStr(mod_iPropertyValue))
        UpdateUserFeedbackLabel()
        UpdateElementInfo(mod_iPropertyValue)
        RaiseEvent EventUpdateRequest()

    End Sub

    Private Sub ButtonIncrease_Click(sender As Object, e As EventArgs) Handles ButtonFontIncrease.Click

        mod_iPropertyValue += 1
        If (mod_iPropertyValue < 0) Then mod_iPropertyValue = 0

        ''9/13/2019 td''LabelProperty.Text = (mod_sPropertyName & ": " & CStr(mod_iPropertyValue))
        UpdateUserFeedbackLabel()
        UpdateElementInfo(mod_iPropertyValue)
        RaiseEvent EventUpdateRequest()

    End Sub

    Private Sub UpdateUserFeedbackLabel()
        ''
        ''9/13/2019 
        ''
        LabelProperty.Text = (mod_sPropertyName & ": " & CStr(mod_iPropertyValue))
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
                                   par_Text As IElement_Text)
        ''
        ''Added 9/14/2019 thomas d. 
        ''
        With mod_sPropertyName

            Select Case True

                Case (.StartsWith("Text") Or .StartsWith("Off"))

                    mod_iPropertyValue = par_Text.FontOffset_Y ''= par_value

                Case (.StartsWith("Font"))

                    mod_iPropertyValue = par_Text.FontSize_Pixels ''= par_value

                Case (.StartsWith("Total") Or .StartsWith("Label"))

                    mod_iPropertyValue = par_Base.Height_Pixels ''= par_value

            End Select ''End of "Select Case True"

        End With ''End of " With mod_sPropertyName"

    End Sub ''End of "Public Sub InitiateLocalValue()"

End Class
