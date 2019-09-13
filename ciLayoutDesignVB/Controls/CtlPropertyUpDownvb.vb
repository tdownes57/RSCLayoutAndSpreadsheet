
Imports ciBadgeInterfaces
Public Class CtlPropertyUpDownvb

    Private mod_sPropertyName As String = "Property"
    Private mod_iPropertyValue As Integer = 10

    Public ElementInfo_Base As IElement_Base
    Public ElementInfo_Text As IElement_Text
    Public Event EventUpdateRequest()

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

    Private Sub ButtonFontDecrease_Click(sender As Object, e As EventArgs) Handles ButtonFontDecrease.Click

        mod_iPropertyValue -= 1
        ''9/13/2019 td''LabelProperty.Text = (mod_sPropertyName & ": " & CStr(mod_iPropertyValue))
        UpdateUserFeedbackLabel()
        UpdateElementInfo(mod_iPropertyValue)
        RaiseEvent EventUpdateRequest()

    End Sub

    Private Sub ButtonFontIncrease_Click(sender As Object, e As EventArgs) Handles ButtonFontIncrease.Click

        mod_iPropertyValue += 1
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

                    Me.ElementInfo_Base.Width_Pixels = par_value

            End Select
        End With ''End of " With mod_sPropertyName"

    End Sub ''End of "Private Sub UpdateElementInfo()"

End Class
