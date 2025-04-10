﻿''
''Added 9/13/2019 td
''Modified 10/12/2019 td
''
Imports ciBadgeInterfaces

Public Class CtlPropertyLeftRight
    ''
    ''Added 9/13/2019 thomas downes
    ''
    Private mod_sPropertyName As String = "Property"
    Private mod_iPropertyValue As Integer = 10
    Private mod_iMinimumValue As Integer = 0 ''Added 9/18/2019 td  

    Public ElementInfo_Base As IElement_Base
    ''Renamed 7/22/22022 Public Element_Base As ciBadgeElements.ClassElementBase ''Added 7/20/2022 thomas
    Public ElementObject_Base As ciBadgeElements.ClassElementBase ''Added 7/20/2022 thomas

    ''10/12/2019 td''Publ ic ElementInfo_Text As IElement_TextField
    ''12/31/2021 td''Public ElementInfo_Text As IElement_TextOnly
    Public ElementInfo_TextOnly As IElement_TextOnly
    Public ElementInfo_TextField As IElement_TextField

    Public Event EventUpdateRequest()

    Public Shared ReminderMsg1_BeenGiven As Boolean = False ''Added 9/18/2019 td 

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


    Public Sub LoadControls()
        ''
        ''Added 7/22/2022 thomas downes
        ''
        UpdateUserFeedbackLabel()
        InitiateLocalValue()

    End Sub ''End of ""Public Sub LoadControls()""


    Private Sub ButtonDecrease_Click(sender As Object, e As EventArgs) Handles ButtonDecrease.Click

        ''9/18/2019 td''mod_iPropertyValue -= 1
        mod_iPropertyValue -= CInt(Numeric1.Value) ''Numeric1.Value 

        ''9/18/2019 td''If (mod_iPropertyValue < 0) Then mod_iPropertyValue = 0
        If (mod_iPropertyValue < Me.MinimumValue) Then mod_iPropertyValue = Me.MinimumValue

        ''9/13/2019 td''LabelProperty.Text = (mod_sPropertyName & ": " & CStr(mod_iPropertyValue))
        ''9/19/2019 td''UpdateUserFeedbackLabel()

        UpdateElementInfo(mod_iPropertyValue)
        UpdateUserFeedbackLabel()

        RaiseEvent EventUpdateRequest()

    End Sub

    Private Sub ButtonIncrease_Click(sender As Object, e As EventArgs) Handles ButtonIncrease.Click

        ''9/18/2019 td''mod_iPropertyValue += 1
        mod_iPropertyValue += CInt(Numeric1.Value) ''12/2021 Numeric1.Value

        ''9/18/2019 td''If (mod_iPropertyValue < 0) Then mod_iPropertyValue = 0
        If (mod_iPropertyValue < Me.MinimumValue) Then mod_iPropertyValue = Me.MinimumValue

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
        Me.Refresh()

    End Sub ''end of ""Private Sub UpdateUserFeedbackLabel()""


    Private Sub UpdateElementInfo(par_value As Single)  ''Jan2 2022 '' Integer)
        ''
        ''Added 9/13/2019 thomas d. 
        ''
        With mod_sPropertyName

            Select Case True

                Case (.StartsWith("Text") Or .StartsWith("Off"))

                    ''Jan2 2022''Me.ElementInfo_Text.FontOffset_X = par_value
                    Me.ElementInfo_TextOnly.FontOffset_X = CInt(par_value)


                Case (.StartsWith("Font"))

                    ''Jan2 2022''Me.ElementInfo_Text.FontSize_Pixels = par_value
                    Me.ElementInfo_TextOnly.FontSize_Pixels = CSng(par_value)

                Case (.StartsWith("Total") Or .StartsWith("Label"))

                    Me.ElementInfo_Base.Width_Pixels = CInt(par_value)

                Case (.StartsWith("Border"))

                    ''Added 7/20/2022 thomas downes
                    If (Me.ElementObject_Base IsNot Nothing) Then
                        With Me.ElementObject_Base
                            ''9/5/20222 .Border_bWidthInPixels = CInt(par_value)
                            .Border_WidthInPixels = CInt(par_value)
                        End With

                    ElseIf (Me.ElementInfo_Base IsNot Nothing) Then
                        ''Condition added 7/20/2022 thomas downes
                        ''Added 9/14/2019 td  
                        With Me.ElementInfo_Base
                            .Border_WidthInPixels = CInt(par_value)
                        End With

                    End If ''End of ""If (Me.ElementObject_Base IsNot Nothing) Then ... ElseIf..""

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
        ''Jan2 2022 td''InitiateLocalValue(Me.ElementInfo_Base, Me.ElementInfo_Text)
        ''7/22/2022 td''InitiateLocalValue(Me.ElementInfo_Base, Me.ElementInfo_TextOnly)
        InitiateLocalValue(Me.ElementInfo_Base, Me.ElementInfo_TextOnly,
                           Me.ElementObject_Base)

    End Sub ''End of ""Public Sub InitiateLocalValue()""


    Public Sub InitiateLocalValue(par_infoBase As IElement_Base,
                                   par_infoText As IElement_TextOnly,
                 Optional par_objectBase As ciBadgeElements.ClassElementBase = Nothing)
        ''
        ''Added 9/14/2019 thomas d. 
        ''
        With mod_sPropertyName

            Select Case True

                Case (.StartsWith("Text") Or .StartsWith("Off"))

                    mod_iPropertyValue = par_infoText.FontOffset_X ''= par_value

                Case (.StartsWith("Font"))

                    ''Dec31 2021''mod_iPropertyValue = par_Text.FontSize_Pixels ''= par_value
                    mod_iPropertyValue = CInt(par_infoText.FontSize_Pixels) ''= par_value

                Case (.StartsWith("Total") Or .StartsWith("Label"))

                    mod_iPropertyValue = par_infoBase.Width_Pixels ''= par_value

                Case (.StartsWith("Border")) ''Added 7/22/2022 thomas downes

                    ''Added 7/22/2022 thomas downes
                    If (par_objectBase IsNot Nothing) Then
                        ''9/5/2022 mod_iPropertyValue = Me.ElementObject_Base.Border_bWidthInPixels
                        mod_iPropertyValue = Me.ElementObject_Base.Border_WidthInPixels
                    Else
                        mod_iPropertyValue = par_infoBase.Border_WidthInPixels
                    End If

                Case Else
                    ''Added 7/22/2022 thomas 
                    System.Diagnostics.Debugger.Break()

            End Select ''End of "Select Case True"

        End With ''End of " With mod_sPropertyName"

        ''Added 9/19/2019 td  
        UpdateUserFeedbackLabel()

    End Sub ''End of "Public Sub InitiateLocalValue(par_Base As IElement_Base, ...)"

    Private Sub LabelProperty_Click(sender As Object, e As EventArgs) Handles LabelProperty.Click

    End Sub

    Private Sub Numeric1_ValueChanged(sender As Object, e As EventArgs) Handles Numeric1.ValueChanged

        If (Numeric1.Value = 1) Then
            ''
            ''The Control is probably initializing. ---9/19/2019 td 
            ''
        ElseIf (Not ReminderMsg1_BeenGiven) Then
            ''
            ''Added 9/18/2019 td  
            ''
            MessageBox.Show("Please note, this number determines by how much the buttons < and > affect the value.", "",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            ReminderMsg1_BeenGiven = True

        End If ''End of "If (Not ReminderMsg1_BeenGiven) Then"

    End Sub

End Class ''End of Class CtlPropertyLeftRight

