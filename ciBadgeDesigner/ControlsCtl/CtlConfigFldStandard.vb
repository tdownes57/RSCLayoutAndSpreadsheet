Option Explicit On
Option Strict On
Option Infer Off

''
''Programming added 8/19/2019 thomas d. 
''
Imports ciBadgeInterfaces ''Added 8/29/2019 thomas downes 
Imports ciBadgeFields ''Added 9/18/2019 td
Imports ciBadgeElements ''Added 9/18/2019 td 

Public Class CtlConfigFldStandard
    ''
    ''Added 8/19/2019 td
    ''
    ''8/29/2019 td''Public Model As ClassFieldStandard ''Added 8/19/2019 thomas d.
    Public ModelFieldInfo As ICIBFieldStandardOrCustom ''Added 8/29/2019 thomas d. 

    Public NewlyAdded As Boolean ''Add 8/19/2019 td 

    ''3/23/2022 ''Private mod_model As ICIBFieldStandardOrCustom
    Private mod_model_info As ICIBFieldStandardOrCustom
    Private mod_model_object As ClassFieldStandard ''Added 3/23/2022 td
    Private mod_model_copy As ClassFieldStandard ''Added 8/19/2019 thomas d. 

    ''9/16/2019 td''Private mod_arrayOfValues As String() ''Added 8/19/2019 td 
    Private mod_s_CIBadgeField As String '' = .CIBadgeField_Optional
    Private mod_s_OtherDbField As String '' = .OtherDbField_Optional
    Private mod_s_ExampleValue As String '' = .ExampleValue

    Private mod_isLoading As Boolean = True ''Added 7/27/2019 td

    Public ReadOnly Property Field_Standard() As ClassFieldStandard
        Get
            ''Added 9/2/2019 thomas downes
            Return mod_model_copy
        End Get
    End Property


    Public Sub Load_StandardControl(par_field As ClassFieldStandard)
        ''
        ''Added 3/23/2022 Thomas DOWNES   
        ''
        ''Added 3/23/2022 thomas downes''mod_model = par_field
        mod_model_object = par_field
        mod_model_info = CType(par_field, ICIBFieldStandardOrCustom)

        mod_model_copy = New ClassFieldStandard
        ''3/23/2022 TD''mod_model_copy.Load_ByCopyingMembers(par_info)
        mod_model_copy.Load_ByCopyingMembers(mod_model_info)

        LabelHeaderTop.Text = mod_model_copy.FieldLabelCaption

        ''If a fieldname is missing, then display the field index. 
        ''
        If (LabelHeaderTop.Text = "") Then If (mod_model_copy.FieldIndex > 0) Then LabelHeaderTop.Text = "Field # " & CStr(mod_model_copy.FieldIndex)

        With mod_model_info ''3/23/2022''par_info

            ''9/16/2019 td''mod_arrayOfValues = .ArrayOfValues
            ''Me.CIBadgeField = .CIBadgeField_Optional

            mod_s_CIBadgeField = .CIBadgeField
            mod_s_OtherDbField = .OtherDbField_Optional
            mod_s_ExampleValue = .ExampleValue

            ''checkHasPresetValues.Checked = .HasPresetValues
            textFieldLabel.Text = .FieldLabelCaption
            checkIsFieldForDates.Checked = .IsFieldForDates
            checkIsLocked.Checked = .IsLocked
            ''checkIsAdditionalField.Checked = .IsAdditionalField

            ''If (.ArrayOfValues IsNot Nothing) Then
            ''    listPresetValues.Items.AddRange(.ArrayOfValues)
            ''End If ''End of "If (.ArrayOfValues IsNot Nothing) Then"

            ''Added 8/22/2019 thomas d.
            checkDisplayOnBadge.Checked = .IsDisplayedOnBadge
            checkDisplayForEdits.Checked = .IsDisplayedForEdits

            ''Added 12/7/2021 thomas d.
            checkRelevantToPersonality.Checked = .IsRelevantToPersonality

            ''Added 12/6/2021 thomas downes
            ''  Make it pretty clear to user that there's a ON-OFF relationship here. 
            checkDisplayForEdits.Enabled = .IsRelevantToPersonality ''False
            checkDisplayOnBadge.Enabled = .IsRelevantToPersonality ''False

        End With ''End of "With par_info"  

ExitHandler:
        ''Added 7/27/2019 thomas downes
        mod_isLoading = False

    End Sub ''End of "Public Sub Load_StandardControl"


    Public Sub Load_StandardControl(par_info As ICIBFieldStandardOrCustom)
        ''
        ''Added 8/19/2019 Thomas DOWNES   
        ''
        ''3/23/2022 td''mod_model = par_info
        mod_model_info = par_info

        mod_model_copy = New ClassFieldStandard
        mod_model_copy.Load_ByCopyingMembers(par_info)

        LabelHeaderTop.Text = mod_model_copy.FieldLabelCaption

        ''If a fieldname is missing, then display the field index. 
        ''
        If (LabelHeaderTop.Text = "") Then If (mod_model_copy.FieldIndex > 0) Then LabelHeaderTop.Text = "Field # " & CStr(mod_model_copy.FieldIndex)

        With par_info

            ''9/16/2019 td''mod_arrayOfValues = .ArrayOfValues
            ''Me.CIBadgeField = .CIBadgeField_Optional

            mod_s_CIBadgeField = .CIBadgeField
            mod_s_OtherDbField = .OtherDbField_Optional
            mod_s_ExampleValue = .ExampleValue

            ''checkHasPresetValues.Checked = .HasPresetValues
            textFieldLabel.Text = .FieldLabelCaption
            checkIsFieldForDates.Checked = .IsFieldForDates
            checkIsLocked.Checked = .IsLocked
            ''checkIsAdditionalField.Checked = .IsAdditionalField

            ''If (.ArrayOfValues IsNot Nothing) Then
            ''    listPresetValues.Items.AddRange(.ArrayOfValues)
            ''End If ''End of "If (.ArrayOfValues IsNot Nothing) Then"

            ''Added 8/22/2019 thomas d.
            checkDisplayOnBadge.Checked = .IsDisplayedOnBadge
            checkDisplayForEdits.Checked = .IsDisplayedForEdits

            ''Added 12/7/2021 thomas d.
            checkRelevantToPersonality.Checked = .IsRelevantToPersonality

            ''Added 12/6/2021 thomas downes
            ''  Make it pretty clear to user that there's a ON-OFF relationship here. 
            checkDisplayForEdits.Enabled = .IsRelevantToPersonality ''False
            checkDisplayOnBadge.Enabled = .IsRelevantToPersonality ''False

        End With ''End of "With par_info"  

ExitHandler:
        ''Added 7/27/2019 thomas downes
        mod_isLoading = False

    End Sub ''End of "Public Sub Load_StandardControl"


    Public Sub Save_StandardControl()
        ''
        ''Added 8/22/2019 & 7/21/2019 Thomas DOWNES   
        ''
        With mod_model_info ''3/23/2022 ''With mod_model

            ''---.HasPresetValues = checkHasPresetValues.Checked
            .FieldLabelCaption = textFieldLabel.Text
            .IsFieldForDates = checkIsFieldForDates.Checked
            .IsLocked = checkIsLocked.Checked

            ''Added 12/7/2021 Thomas Downes
            .IsRelevantToPersonality = checkRelevantToPersonality.Checked

            ''Added 8/22/2019 Thomas DOWNES
            .IsDisplayedOnBadge = checkDisplayOnBadge.Checked
            .IsDisplayedForEdits = checkDisplayForEdits.Checked

            ''---.IsAdditionalField = checkIsAdditionalField.Checked
            ''9/16/2019 td''ArrayOfValues = mod_arrayOfValues

            .CIBadgeField = mod_s_CIBadgeField '' = .CIBadgeField_Optional
            .OtherDbField_Optional = mod_s_OtherDbField '' = .OtherDbField_Optional
            .ExampleValue = mod_s_ExampleValue '' = .ExampleValue

        End With ''End of "With mod_model_info"  

        ''Added 7/27/2019 td  
        ''8/29/2019 td''Me.Model = mod_model
        ''3/23/2022 td''Me.ModelFieldInfo = mod_model
        Me.ModelFieldInfo = mod_model_info

    End Sub ''End of "Public Sub Save_StandardControl()" 

    Private Sub CtlConfigFldStandard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Hello, my name is Thomas!
        ''

    End Sub

    Private Sub checkRelevantToPersonality_CheckedChanged(sender As Object, e As EventArgs) Handles checkRelevantToPersonality.Click

        ''Added 12/6/2021 thomas d.
        Dim dresult As DialogResult
        Dim boolPriorValueChecked As Boolean
        Dim checkboxSender As CheckBox = CType(sender, CheckBox)

        If (mod_isLoading) Then Exit Sub ''Added 12/7/2021 thomas downes

        If (checkboxSender.AutoCheck = False) Then
            ''
            ''Auto-check is False, so we have to programmatically decide whether to put the checkmark on the control. 
            ''
            boolPriorValueChecked = checkboxSender.Checked
            If (boolPriorValueChecked) Then
                ''Added 12/6/2021 td 
                dresult = MessageBox.Show("Are you sure you want to remove this field from the Personality (both Badge & Edit)?", "Relevant?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            Else
                dresult = DialogResult.OK
            End If ''Endof "If boolPriorValueChecked Then... Else ..."

            If (boolPriorValueChecked And dresult = DialogResult.OK) Then
                mod_isLoading = True ''Suppress this event. 
                checkboxSender.Checked = False
                Application.DoEvents()
                mod_isLoading = False ''Return to default. 

                ''3/23/2022 td''If (mod_model IsNot Nothing) Then mod_model.DateEdited = Now ''Added 12/5/2021 td
                If (mod_model_info IsNot Nothing) Then mod_model_info.DateEdited = Now ''Added 12/5/2021 td

                checkDisplayForEdits.Enabled = False
                checkDisplayOnBadge.Enabled = False

            ElseIf (Not boolPriorValueChecked And dresult = DialogResult.OK) Then
                ''
                ''Check the Relevant checkboxes.
                ''
                ''Also turn on, or enable, the related, or relevant, checkboxes.  
                ''
                mod_isLoading = True ''Suppress this event. 
                checkboxSender.Checked = True ''False
                Application.DoEvents()
                mod_isLoading = False ''Return to default.

                ''3/23/2022 td''If (mod_model IsNot Nothing) Then mod_model.DateEdited = Now ''Added 12/5/2021 td
                If (mod_model_info IsNot Nothing) Then mod_model_info.DateEdited = Now ''Added 12/5/2021 td

                checkDisplayForEdits.Enabled = True ''False
                checkDisplayOnBadge.Enabled = True ''False

            End If ''End of "If (boolPriorValueChecked And dresult = DialogResult.OK) Then"

        ElseIf (checkboxSender.Checked = False) Then
            ''
            ''Added 12/6/2021 td 
            ''
            MessageBox.Show("This field is removed from any operations in the current Personality Configuration (both Badge & Edit).",
                            "Not Relevant",
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        Else
            ''
            ''The user has turned the "Relevant" checkbox ---ON---.  That's fine. 
            ''

        End If ''End of "If (CType(sender, CheckBox).AutoCheck) Then .... Else ...."


    End Sub

    ''Private Sub checkRelevantToPersonality_CheckedChanged_1(sender As Object, e As EventArgs) Handles checkRelevantToPersonality.CheckedChanged

    ''End Sub
End Class
