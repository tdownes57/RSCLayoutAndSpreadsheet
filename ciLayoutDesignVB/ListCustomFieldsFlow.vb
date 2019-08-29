''
''Added 7/21/2019 thomas downes
''

Public Class ListCustomFieldsFlow

    Public Property ListOfFields As List(Of ClassFieldCustomized) ''Added 7/23/2019 thomas downes 
    Public Property JustOneField_Index As Integer ''Added 7/30/2019 thomas d. 

    Private Const vbCrLf_Deux As String = (vbCrLf & vbCrLf)

    Public Sub AdjustHeightOfWindow()
        ''Added 7/23/2019 thomas downes
        Static s_bEveryOtherCall As Boolean

        If (s_bEveryOtherCall) Then Me.Height -= UserAddFieldControl1.Height / 2
        If (Not s_bEveryOtherCall) Then Me.Height += UserAddFieldControl1.Height / 2
        s_bEveryOtherCall = Not s_bEveryOtherCall

    End Sub ''End of "Public Sub AdjustHeightOfWindow()"

    Private Sub FormCustomFieldsFlow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 7/21/2019 thomas downes
        ''
        '' 7/21 td''ClassCustomField.InitializeHardcodedList_Students()

        LoadCustomFields_All()

    End Sub

    Private Sub LoadCustomFields_All()
        ''
        ''Added 7.21.2019
        ''
        Dim list_local As List(Of ClassFieldCustomized) = Nothing

        If (ListOfFields IsNot Nothing) Then list_local = ListOfFields

        If (list_local Is Nothing) Then
            ClassFieldCustomized.InitializeHardcodedList_Students(True)
            list_local = ClassFieldCustomized.ListOfFields_Students
        End If ''end of "If (list_local Is Nothing) Then"

        FlowLayoutPanel1.Controls.Clear()

        For Each each_customField In list_local ''ClassCustomField.ListOfFields_Students
            ''
            ''Add 7/21/2019
            ''
            LoadCustomField_Each(each_customField)

        Next each_customField

        ''
        ''Add 7/21/2019
        ''
        FlowLayoutPanel1.Controls.Add(New CtlAddCustomField())

    End Sub ''End of "Private Sub LoadFields()"  

    Private Sub LoadCustomField_Each(par_customfld As ClassFieldCustomized)
        ''
        ''Added 7/ 21/2019
        ''
        Dim userControl As New CtlConfigFldCustom

        ''7/21/2019 td''FlowLayoutPanel1.Controls.Add(New UserCustomFieldCtl())

        userControl.Load_CustomControl(CType(par_customfld, ICIBFieldStandardOrCustom))
        userControl.Visible = True

        FlowLayoutPanel1.Controls.Add(userControl)

    End Sub ''End of "Private Sub LoadCustomField_Each(par_customfld As ClassCustomField)"

    Private Sub FormCustomFieldsFlow_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ''
        ''Added 7/23/2019 td  
        ''Encapsulated 7/27/2019 td 
        ''
        ''8/4/2019 td''SaveControls()

        ''
        ''Added 7/31/2019 thomas downes
        ''
        Dim dia_result As DialogResult
        Dim closing_reason As CloseReason

        closing_reason = e.CloseReason

        ''Added 7/31/2019 td  
        dia_result = MessageBox.Show("Save your work?  (Currently, this does _NOT_ save your work permanently to your PC.) " &
                                     vbCrLf_Deux & "(Allows the window to be re-opened from the parent application, with your work retained.)", "ciLayout",
                                     MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

        If (dia_result = DialogResult.Cancel) Then e.Cancel = True
        If (dia_result = DialogResult.Yes) Then SaveControls()

    End Sub

    Private Sub SaveControls()
        ''
        ''Added 7/23/2019 td  
        ''Encapsulated 7/27/2019 td 
        ''
        Dim each_ctl_configure_field As CtlConfigFldCustom

        For Each each_control As Control In FlowLayoutPanel1.Controls

            If (TypeOf each_control Is CtlAddCustomField) Then Continue For

            ''7/27/2019 td''CType(each_control, CtlConfigFldCustom).Save_CustomControl()

            each_ctl_configure_field = CType(each_control, CtlConfigFldCustom)

            With each_ctl_configure_field

                .Save_CustomControl()

                If (.NewlyAdded) Then FormMain.GetCurrentPersonality_Fields_Custom().Add(.Model)


            End With ''End of "With each_ctl_configure_field"

        Next each_control

    End Sub

    Private Sub LinkLabelRefresh_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkLabelRefresh.LinkClicked

        ''Added 7/27/2019 td
        SaveControls()
        FlowLayoutPanel1.Controls.Clear()
        LoadCustomFields_All()

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
            LoadCustomFields_All()
        End If

    End Sub
End Class