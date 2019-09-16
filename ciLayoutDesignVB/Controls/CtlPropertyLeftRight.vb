
Imports ciBadgeInterfaces
Public Class CtlPropertyLeftRight
    ''
    ''Added 9/13/2019 thomas downes
    ''
    Private mod_sPropertyName As String = "Property"
    Private mod_iPropertyValue As Integer = 10

    Public ElementInfo_Base As IElement_Base
    Public ElementInfo_Text As IElement_Field

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

    Private Sub ButtonFontDecrease_Click(sender As Object, e As EventArgs) Handles ButtonDecrease.Click

        mod_iPropertyValue -= 1
        If (mod_iPropertyValue < 0) Then mod_iPropertyValue = 0

        ''9/13/2019 td''LabelProperty.Text = (mod_sPropertyName & ": " & CStr(mod_iPropertyValue))
        UpdateUserFeedbackLabel()
        UpdateElementInfo(mod_iPropertyValue)
        RaiseEvent EventUpdateRequest()

    End Sub

    Private Sub ButtonFontIncrease_Click(sender As Object, e As EventArgs) Handles ButtonIncrease.Click

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

                    Me.ElementInfo_Text.FontOffset_X = par_value

                Case (.StartsWith("Font"))

                    Me.ElementInfo_Text.FontSize_Pixels = par_value

                Case (.StartsWith("Total") Or .StartsWith("Label"))

                    Me.ElementInfo_Base.Width_Pixels = par_value

                Case (.StartsWith("Border"))

                    ''Added 9/14/2019 td  
                    Me.ElementInfo_Base.Border_WidthInPixels = par_value

                Case Else

                    ''Added 9/14/2019 td
                    ''
                    MessageBox.Show("The element property is not being determined, and hence nothing will happen.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            End Select

        End With ''End of " With mod_sPropertyName"

    End Sub ''End of "Private Sub UpdateElementInfo()"

    Public Sub InitiateLocalValue()
        ''
        ''Added 9/14/2019 td
        ''
        InitiateLocalValue(Me.ElementInfo_Base, Me.ElementInfo_Text)

    End Sub

    Public Sub InitiateLocalValue(par_Base As IElement_Base,
                                   par_Text As IElement_Field)
        ''
        ''Added 9/14/2019 thomas d. 
        ''
        With mod_sPropertyName

            Select Case True

                Case (.StartsWith("Text") Or .StartsWith("Off"))

                    mod_iPropertyValue = par_Text.FontOffset_X ''= par_value

                Case (.StartsWith("Font"))

                    mod_iPropertyValue = par_Text.FontSize_Pixels ''= par_value

                Case (.StartsWith("Total") Or .StartsWith("Label"))

                    mod_iPropertyValue = par_Base.Width_Pixels ''= par_value

            End Select ''End of "Select Case True"

        End With ''End of " With mod_sPropertyName"

    End Sub ''End of "Public Sub InitiateLocalValue()"

End Class

