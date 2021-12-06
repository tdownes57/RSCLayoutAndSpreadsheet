Option Explicit On
Option Strict On
Option Infer Off

''
''Added 7/21/2019 thomas downes 
''
Imports ciBadgeInterfaces ''Added 8/29/2019 thomas downes 
Imports ciBadgeFields ''Added 9/18/2019 td  

Public Class CtlConfigFldCustom
    ''
    ''Added 7/21/2019 td
    ''
    ''8/29/2019 td''Public Model As ClassFieldCustomized ''Added 7/23/2019 thomas d.
    Public ModelFieldInfo As ICIBFieldStandardOrCustom ''Added 8/29/2019 thomas d. 

    Public NewlyAdded As Boolean ''Add 7/23/2019 td 

    ''9/16/2019 td''Private mod_model As ICIBFieldStandardOrCustom
    Private mod_model As ClassFieldCustomized
    Private mod_model_copy As ClassFieldCustomized ''Added 7/23/2019 thomas d. 

    Private mod_arrayOfValues As String() ''Added 7/23/2019 td 
    Private mod_s_CIBadgeField As String '' = .CIBadgeField_Optional
    Private mod_s_OtherDbField As String '' = .OtherDbField_Optional
    Private mod_s_ExampleValue As String '' = .ExampleValue

    Private mod_loading As Boolean = True ''Added 7/27/2019 td

    Public ReadOnly Property Field_Customized() As ClassFieldCustomized
        Get
            ''Added 9/2/2019 thomas downes
            Return mod_model_copy
        End Get
    End Property

    Public Sub Load_CustomControl(par_field As ClassFieldCustomized)
        ''9/16/2019 td''Public Sub Load_CustomControl(par_info As ICIBFieldStandardOrCustom)
        ''
        ''Added 7/21/2019 Thomas DOWNES   
        ''
        ''9/16/2019 td''mod_model = par_info
        mod_model = par_field

        ''mod_model_copy = par_info.GetClone() ''Added 7/23/2019 td
        mod_model_copy = New ClassFieldCustomized
        ''9/16 td''mod_model_copy.Load_ByCopyingMembers(par_info)
        mod_model_copy.Load_ByCopyingMembers(par_field)

        LabelHeaderTop.Text = mod_model_copy.FieldLabelCaption
        LabelDatabaseFieldname.Text = mod_model_copy.CIBadgeField ''Added 12/5/2021 Thomas Downes 
        LabelDateEdited.Text = mod_model.DateEdited.ToString("mm/dd/yy HH:mm")

        ''If a fieldname is missing, then display the field index. 
        If (LabelHeaderTop.Text = "") Then If (mod_model_copy.FieldIndex > 0) Then LabelHeaderTop.Text = "Field # " & CStr(mod_model_copy.FieldIndex)

        With par_field ''9/16 td''With par_info

            mod_arrayOfValues = .ArrayOfValues
            ''Me.CIBadgeField = .CIBadgeField_Optional

            mod_s_CIBadgeField = .CIBadgeField
            mod_s_OtherDbField = .OtherDbField_Optional
            mod_s_ExampleValue = .ExampleValue

            checkHasPresetValues.Checked = .HasPresetValues
            textFieldLabel.Text = .FieldLabelCaption
            checkIsFieldForDates.Checked = .IsFieldForDates
            checkIsLocked.Checked = .IsLocked
            checkIsAdditionalField.Checked = .IsAdditionalField

            If (.ArrayOfValues IsNot Nothing) Then
                listPresetValues.Items.AddRange(.ArrayOfValues)
            End If ''End of "If (.ArrayOfValues IsNot Nothing) Then"

            ''
            ''Added 9/6/2019 thomas downes
            ''
            checkDisplayOnBadge.Checked = .IsDisplayedOnBadge
            checkDisplayForEdits.Checked = .IsDisplayedForEdits

            ''Added 12//3/2021 thomas downes
            checkRelevantToPersonality.Checked = .IsRelevantToPersonality

            ''Added 12/6/2021 thomas downes
            ''  Make it pretty clear to user that there's a ON-OFF relationship here. 
            checkDisplayForEdits.Enabled = .IsRelevantToPersonality ''False
            checkDisplayOnBadge.Enabled = .IsRelevantToPersonality ''False

        End With ''End of "With par_info"  

ExitHandler:
        ''Added 7/27/2019 thomas downes
        mod_loading = False

    End Sub ''End of "Public Sub Load_CustomControl"

    Public Sub Save_CustomControl()
        ''
        ''Added 7/21/2019 Thomas DOWNES   
        ''
        With mod_model

            .HasPresetValues = checkHasPresetValues.Checked
            .FieldLabelCaption = textFieldLabel.Text
            .IsFieldForDates = checkIsFieldForDates.Checked
            .IsLocked = checkIsLocked.Checked
            .IsAdditionalField = checkIsAdditionalField.Checked
            .ArrayOfValues = mod_arrayOfValues

            .CIBadgeField = mod_s_CIBadgeField '' = .CIBadgeField_Optional
            .OtherDbField_Optional = mod_s_OtherDbField '' = .OtherDbField_Optional

            .ExampleValue = mod_s_ExampleValue '' = .ExampleValue

            ''Added 9/6/2019 td
            ''
            .IsDisplayedForEdits = checkDisplayForEdits.Checked
            .IsDisplayedOnBadge = checkDisplayOnBadge.Checked

            ''Added 12//3/2021 thomas downes
            .IsRelevantToPersonality = checkRelevantToPersonality.Checked

            ''Added 12/5/2021 thomas downes
            .DateSaved = DateTime.Now

        End With ''End of "With mod_model"  

        ''Added 7/27/2019 td  
        ''8/29/2019 td''Me.Model = mod_model
        Me.ModelFieldInfo = mod_model

        ''Added 12/5/2021 thomas downes
        mod_model_copy = mod_model.Copy_FieldCustom()

    End Sub ''End of "Public Sub Save_CustomControl()" 

    Private Sub UserCustomFieldCtl_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub LabelFieldLabelCaption_Click(sender As Object, e As EventArgs) Handles LabelFieldLabelCaption.Click

    End Sub

    Private Sub Link_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkSupplementary.LinkClicked
        ''
        ''Added 7/21/2019 thomas downes
        ''
        Dim frm_showExampleEtc As New DialogExampleValueEtc

        With frm_showExampleEtc

            ''frm_show.Load_CustomField(mod_model)

            .Load_CustomField(mod_model_copy)

            ''frm_show.checkHasPresetValues.Checked = checkHasPresetValues.Checked
            ''frm_show.listPresetValues_NotInUse.Items.Clear()
            ''frm_show.listPresetValues_NotInUse.Items.Add(mod_arrayOfValues)

            .textExampleValue.Text = mod_model_copy.ExampleValue
            .textOtherDbField.Text = mod_model_copy.OtherDbField_Optional

            Dim boolSpecificCIBField As Boolean ''Added 7/23/2019 td
            boolSpecificCIBField = ("" <> mod_model_copy.CIBadgeField)

            If (boolSpecificCIBField) Then
                ''.dropdownCIBFields.SelectedValue = mod_model_copy.CIBadgeField_Optional
                .dropdownCIBFields.SelectedItem = mod_model_copy.CIBadgeField
            End If ''End of "If (boolSpecificCIBField) Then"

            .ShowDialog()

            ''
            ''Did the user press OK (rather than Cancel)?  
            ''
            If (.DialogResult = vbOK) Then

                mod_model_copy.ExampleValue = .textExampleValue.Text
                mod_model_copy.OtherDbField_Optional = .textOtherDbField.Text

                mod_s_ExampleValue = .textExampleValue.Text
                mod_s_OtherDbField = .textOtherDbField.Text

                boolSpecificCIBField = (-1 < .dropdownCIBFields.SelectedIndex)

                If (boolSpecificCIBField) Then
                    mod_s_CIBadgeField = .dropdownCIBFields.SelectedItem.ToString
                    mod_model_copy.CIBadgeField = mod_s_CIBadgeField
                Else
                    mod_s_CIBadgeField = ""
                    mod_model_copy.CIBadgeField = ""
                End If ''End of "If (boolSpecificCIBField) Then .... Else ...."

            End If ''ENd of "If (frm_show.DialogResult = vbOK) Then"

        End With ''end of "With frm_showExampleEtc"

    End Sub

    Private Sub LinkAddPresetValue_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkAddPresetValue.LinkClicked
        ''
        ''Added 7/21/2019 thomas downes
        ''
        Dim frm_show As New DialogPresetValues

        mod_model_copy.HasPresetValues = Me.checkHasPresetValues.Checked
        mod_model_copy.ArrayOfValues = mod_arrayOfValues

        frm_show.Load_CustomField(mod_model_copy)
        frm_show.checkHasPresetValues.Checked = Me.checkHasPresetValues.Checked
        frm_show.listPresetValues.Items.Clear()

        If (mod_arrayOfValues IsNot Nothing) Then
            frm_show.listPresetValues.Items.AddRange(mod_arrayOfValues)
        End If

        frm_show.ShowDialog()

        ''
        ''Did the user press OK (rather than Cancel)?  
        ''
        If (frm_show.DialogResult = vbOK) Then

            Me.checkHasPresetValues.Checked = frm_show.checkHasPresetValues.Checked
            listPresetValues.Items.Clear()
            frm_show.listPresetValues.Items.CopyTo(mod_arrayOfValues, 0)
            listPresetValues.Items.AddRange(mod_arrayOfValues)

        End If ''ENd of "If (frm_show.DialogResult = vbOK) Then"

    End Sub

    Private Sub ButtonAddField_Click(sender As Object, e As EventArgs) Handles buttonAddField.Click

    End Sub

    Private Sub LinkDeleteField_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkDeleteField.LinkClicked
        ''
        ''Added 7/22/2019 thomas downes
        ''
        Dim objFlowPanel As FlowLayoutPanel
        objFlowPanel = CType(Me.Parent, FlowLayoutPanel)
        objFlowPanel.Controls.Remove(Me)

    End Sub

    Private Sub TextFieldLabel_TextChanged(sender As Object, e As EventArgs) Handles textFieldLabel.TextChanged
        ''
        ''Added 7/27/2019
        ''
        If (mod_loading) Then Exit Sub ''Added 7//27/2019 td

        mod_model_copy.FieldLabelCaption = CType(sender, TextBox).Text

        ''Added 7/27/2019 td  
        ''7/27/ td''LabelFieldLabelCaption.Text = CType(sender, TextBox).Text

        LabelHeaderTop.Text = CType(sender, TextBox).Text

    End Sub

    Private Sub checkIsFieldForDates_CheckedChanged(sender As Object, e As EventArgs) Handles checkIsFieldForDates.CheckedChanged

        If (mod_model IsNot Nothing) Then mod_model.DateEdited = Now ''Added 12/5/2021 td 
    End Sub

    Private Sub checkIsLocked_CheckedChanged(sender As Object, e As EventArgs) Handles checkIsLocked.CheckedChanged

        If (mod_model IsNot Nothing) Then mod_model.DateEdited = Now ''Added 12/5/2021 td 
    End Sub

    Private Sub checkHasPresetValues_CheckedChanged(sender As Object, e As EventArgs) Handles checkHasPresetValues.CheckedChanged

        If (mod_model IsNot Nothing) Then mod_model.DateEdited = Now ''Added 12/5/2021 td 

    End Sub

    Private Sub checkRelevantToPersonality_CheckedChanged(sender As Object, e As EventArgs) Handles checkRelevantToPersonality.CheckedChanged

        ''Moved below.'''If (mod_model IsNot Nothing) Then mod_model.DateEdited = Now ''Added 12/5/2021 td 

        ''[[[[End Sub
        ''[[[[Private Sub checkRelevantToPersonality_Clicked(sender As Object, e As EventArgs) Handles checkRelevantToPersonality.Click

        ''Added 12/6/2021 thomas d.
        Dim dresult As DialogResult
        Dim boolPriorValueChecked As Boolean

        If (CType(sender, CheckBox).AutoCheck) Then
            ''
            ''Auto-check applies, so we have to programmatically decide whether to put the checkmark on the control. 
            ''
            boolPriorValueChecked = CType(sender, CheckBox).Checked
            If (boolPriorValueChecked) Then
                ''Added 12/6/2021 td 
                dresult = MessageBox.Show("Are you sure you want to remove this field from the Personality (both Badge & Edit)?", "Relevant?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            Else
                dresult = DialogResult.OK
            End If ''Endof "If boolPriorValueChecked Then... Else ..."

            If (boolPriorValueChecked And dresult = DialogResult.OK) Then
                CType(sender, CheckBox).Checked = False
                If (mod_model IsNot Nothing) Then mod_model.DateEdited = Now ''Added 12/5/2021 td
                checkDisplayForEdits.Enabled = False
                checkDisplayOnBadge.Enabled = False

            ElseIf (Not boolPriorValueChecked And dresult = DialogResult.OK) Then
                ''
                ''Check the Relevant checkboxes.
                ''
                ''Also turn on, or enable, the related, or relevant, checkboxes.  
                ''
                CType(sender, CheckBox).Checked = True ''False
                If (mod_model IsNot Nothing) Then mod_model.DateEdited = Now ''Added 12/5/2021 td
                checkDisplayForEdits.Enabled = True ''False
                checkDisplayOnBadge.Enabled = True ''False
            End If ''End of "If (boolPriorValueChecked And dresult = DialogResult.OK) Then"

        ElseIf (CType(sender, checkbox).Checked) Then
            ''
            ''Added 12/6/2021 td 
            ''
            MessageBox.Show("This field is removed from any operations in the current Personality Configuration (both Badge & Edit).",
                            "Not Relevant",
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        End If ''End of "If (CType(sender, CheckBox).AutoCheck) Then .... Else ...."

    End Sub

    Private Sub checkDisplayOnBadge_CheckedChanged(sender As Object, e As EventArgs) Handles checkDisplayOnBadge.CheckedChanged

        If (mod_model IsNot Nothing) Then mod_model.DateEdited = Now ''Added 12/5/2021 td 

    End Sub

    Private Sub checkDisplayForEdits_CheckedChanged(sender As Object, e As EventArgs) Handles checkDisplayForEdits.CheckedChanged

        If (mod_model IsNot Nothing) Then mod_model.DateEdited = Now ''Added 12/5/2021 td 

    End Sub
End Class
