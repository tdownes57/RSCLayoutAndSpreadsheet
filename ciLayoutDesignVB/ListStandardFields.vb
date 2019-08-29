''
''Added 8/19/2019 thomas downes
''

Public Class ListStandardFields

    Public Property ListOfFields As List(Of ClassFieldStandard) ''Added 8/19/2019 thomas downes 
    Public Property JustOneField_Index As Integer ''Added 7/30/2019 thomas d. 

    Private Const vbCrLf_Deux As String = (vbCrLf & vbCrLf)

    Public Sub AdjustHeightOfWindow()

        ''Added 8/19/2019 thomas downes
        Static s_bEveryOtherCall As Boolean

        If (s_bEveryOtherCall) Then Me.Height -= CtlAddStandardField1.Height / 2
        If (Not s_bEveryOtherCall) Then Me.Height += CtlAddStandardField1.Height / 2
        s_bEveryOtherCall = Not s_bEveryOtherCall

    End Sub ''End of "Public Sub AdjustHeightOfWindow()"

    Private Sub FormCustomFieldsFlow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 8/19/2019 thomas downes
        ''
        '' 7/21 td''ClassCustomField.InitializeHardcodedList_Students()

        LoadStandardFields_All()

    End Sub

    Private Sub LoadStandardFields_All()
        ''
        ''Added 8/19/2019
        ''
        Dim list_local As List(Of ClassFieldStandard) = Nothing

        If (ListOfFields IsNot Nothing) Then list_local = ListOfFields

        If (list_local Is Nothing) Then
            ClassFieldStandard.InitializeHardcodedList_Students(True)
            list_local = ClassFieldStandard.ListOfFields_Students
        End If ''end of "If (list_local Is Nothing) Then"

        FlowLayoutPanel1.Controls.Clear()

        For Each each_standardField In list_local

            ''Add 8/19/2019 td
            ''8/22/2019 td''LoadCustomField_Each(each_standardField)
            LoadStandardField_Each(each_standardField)

        Next each_standardField

        ''
        ''Add 7/21/2019
        ''
        ''8/22/2019 td''FlowLayoutPanel1.Controls.Add(New CtlAddCustomField())
        FlowLayoutPanel1.Controls.Add(New CtlAddStandardField())

    End Sub ''End of "Private Sub LoadFields()"  

    Private Sub LoadStandardField_Each(par_standardFld As ClassFieldStandard)
        ''
        ''Added 8/19/2019
        ''
        Dim userControl As New CtlConfigFldStandard

        userControl.Load_StandardControl(CType(par_standardFld, ICIBFieldStandardOrCustom))
        userControl.Visible = True

        FlowLayoutPanel1.Controls.Add(userControl)

    End Sub ''End of "Private Sub LoadStandardField_Each(par_standardFld As ClassStandardField)"

    Private Sub FormCustomFieldsFlow_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ''
        ''Added 8/19/2019 td  
        ''
        Dim dia_result As DialogResult
        Dim closing_reason As CloseReason

        closing_reason = e.CloseReason

        ''Added 8/19/2019 td  
        dia_result = MessageBox.Show("Save your work?  (Currently, this does _NOT_ save your work permanently to your PC.) " &
                                     vbCrLf_Deux & "(Allows the window to be re-opened from the parent application, with your work retained.)", "ciLayout",
                                     MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

        If (dia_result = DialogResult.Cancel) Then e.Cancel = True
        If (dia_result = DialogResult.Yes) Then SaveControls()

    End Sub

    Private Sub SaveControls()
        ''
        ''Added 8/19/2019 td  
        ''
        Dim each_ctl_configure_field As CtlConfigFldStandard

        For Each each_control As Control In FlowLayoutPanel1.Controls

            If (TypeOf each_control Is CtlAddCustomField) Then Continue For
            If (TypeOf each_control Is CtlAddStandardField) Then Continue For

            each_ctl_configure_field = CType(each_control, CtlConfigFldStandard)

            With each_ctl_configure_field

                ''8/22/2019 TD''.Save_CustomControl()
                .Save_StandardControl()

                ''8/22/2019 td''If (.NewlyAdded) Then FormMain.GetCurrentPersonality_Fields_Custom().Add(.Model)
                If (.NewlyAdded) Then FormMain.GetCurrentPersonality_Fields_Standard().Add(.Model)

            End With ''End of "With each_ctl_configure_field"

        Next each_control

    End Sub

    Private Sub LinkLabelRefresh_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkLabelRefresh.LinkClicked

        ''Added 7/27/2019 td
        SaveControls()
        FlowLayoutPanel1.Controls.Clear()

        ''8/22/2019 td''LoadCustomFields_All()
        LoadStandardFields_All()

    End Sub

    Private Sub LinkLabelSave_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelSave.LinkClicked

        ''Added 7/30/2019 td
        SaveControls()

        MessageBox.Show("Saved.", "ciLayoutDesign", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub LinkLabelCancel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelCancel.LinkClicked
        ''
        ''Added 8/4/2019 thomas downes
        ''
        Dim dia_result As DialogResult

        ''Added 8/4/2019 td  
        dia_result = MessageBox.Show("Cancel your work? ", "ciLayout",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

        If (dia_result = DialogResult.Yes) Then ''LoadCustomFields_All()
            FlowLayoutPanel1.Controls.Clear()
            ''8/22/2019 td''LoadCustomFields_All()
            LoadStandardFields_All()
        End If ''End of "If (dia_result = DialogResult.Yes) Then"

    End Sub
End Class


