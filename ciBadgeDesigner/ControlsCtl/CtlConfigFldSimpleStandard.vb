Option Explicit On
Option Strict On
Option Infer Off

''
''Added 7/21/2019 thomas downes 
''
Imports ciBadgeInterfaces ''Added 8/29/2019 thomas downes 
Imports ciBadgeFields ''Added 9/18/2019 td 
''
''Added 5/11/2022 td
''
Public Class CtlConfigFldSimpleStandard
    ''
    ''Added 5/11/2022 td
    ''
    ''8/29/2019 td''Public Model As ClassFieldStandard ''Added 8/19/2019 thomas d.
    Public ModelFieldInfo As ICIBFieldStandardOrCustom ''Added 8/29/2019 thomas d. 

    Public Event ModifiedField(par_field As ClassFieldStandard) ''Added 5/12/2022 

    ''Added 8/27/2023 
    ''8/2023 Public Event RelevantFieldAdded(par_field As ClassFieldStandard) ''Added 5/12/2022 
    ''8/2023 Public Event RelevantFieldAdded_Text(par_strFieldCaption As String) ''Added 5/12/2022 
    Public Event RelevantFieldAdded_Enum(par_enum As EnumCIBFields) ''Added 8/2023 
    Public Event ModifiedField_Enum(par_enum As EnumCIBFields) ''Added 8/2023 

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
            ''textFieldLabel.Text = .FieldLabelCaption
            ''checkIsFieldForDates.Checked = .IsFieldForDates
            ''checkIsLocked.Checked = .IsLocked
            ''checkIsAdditionalField.Checked = .IsAdditionalField

            ''If (.ArrayOfValues IsNot Nothing) Then
            ''    listPresetValues.Items.AddRange(.ArrayOfValues)
            ''End If ''End of "If (.ArrayOfValues IsNot Nothing) Then"

            ''Added 8/22/2019 thomas d.
            ''checkDisplayOnBadge.Checked = .IsDisplayedOnBadge
            ''checkDisplayForEdits.Checked = .IsDisplayedForEdits

            ''Added 12/7/2021 thomas d.
            ''5/12/2022 td''checkRelevantToPersonality.Checked = .IsRelevantToPersonality
            CheckBoxRelevant.Checked = .IsRelevantToPersonality

            ''Added 12/6/2021 thomas downes
            ''  Make it pretty clear to user that there's a ON-OFF relationship here. 
            ''checkDisplayForEdits.Enabled = .IsRelevantToPersonality ''False
            ''checkDisplayOnBadge.Enabled = .IsRelevantToPersonality ''False

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
            ''textFieldLabel.Text = .FieldLabelCaption
            ''checkIsFieldForDates.Checked = .IsFieldForDates
            ''checkIsLocked.Checked = .IsLocked
            ''checkIsAdditionalField.Checked = .IsAdditionalField

            ''If (.ArrayOfValues IsNot Nothing) Then
            ''    listPresetValues.Items.AddRange(.ArrayOfValues)
            ''End If ''End of "If (.ArrayOfValues IsNot Nothing) Then"

            ''Added 8/22/2019 thomas d.
            ''checkDisplayOnBadge.Checked = .IsDisplayedOnBadge
            ''checkDisplayForEdits.Checked = .IsDisplayedForEdits

            ''Added  12/7/2021 thomas d.
            ''5/11/2022 checkRelevantToPersonality.Checked = .IsRelevantToPersonality
            CheckBoxRelevant.Checked = .IsRelevantToPersonality

            ''Added 12/6/2021 thomas downes
            ''  Make it pretty clear to user that there's a ON-OFF relationship here. 
            ''checkDisplayForEdits.Enabled = .IsRelevantToPersonality ''False
            ''checkDisplayOnBadge.Enabled = .IsRelevantToPersonality ''False

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
            ''.FieldLabelCaption = textFieldLabel.Text
            ''.IsFieldForDates = checkIsFieldForDates.Checked
            ''.IsLocked = checkIsLocked.Checked

            ''Added 12/7/2021 Thomas Downes
            ''5/11/2022 .IsRelevantToPersonality = checkRelevantToPersonality.Checked
            .IsRelevantToPersonality = CheckBoxRelevant.Checked

            ''Added 8/22/2019 Thomas DOWNES
            ''.IsDisplayedOnBadge = checkDisplayOnBadge.Checked
            ''.IsDisplayedForEdits = checkDisplayForEdits.Checked

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


    Public Sub LoadCheckboxFontStyle()
        ''
        ''Added 5/11/2022 td
        ''
        With CheckBoxRelevant
            If (.Checked) Then

                Dim objFontStyle As New Drawing.FontStyle()
                ''objFontStyle.Bold = True
                ''objFontStyle.Underline = True
                .Font = New Drawing.Font(.Font, Drawing.FontStyle.Underline Or
                                               Drawing.FontStyle.Bold)
                .Text = "Relevant ...yes" ''Added 5/12/2022

            Else

                Dim objFontStyle As New Drawing.FontStyle()
                ''objFontStyle.Bold = True
                ''objFontStyle.Underline = True
                .Font = New Drawing.Font(.Font, Drawing.FontStyle.Regular)

                .Text = "Relevant" ''Added 5/12/2022

            End If ''Endof ""If (.Checked) Then... Else....


        End With

    End Sub ''end of Public Sub LoadCheckboxFontStyle()



    Private Sub CheckBoxRelevant_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxRelevant.CheckedChanged
        ''
        ''Added 5/11/2022 td
        ''
        LoadCheckboxFontStyle() ''Add boldface and underlining.

        ''Added 5/12/2022 td
        ''8/2023 Dim new_field As New ClassFieldStandard ''Added 5/12/2022 td
        ''8/2023 new_field.IsRelevantToPersonality = CType(sender, CheckBox).Checked  ''CheckBoxRelevant.Checked
        ''8/2023 new_field.FieldEnumValue = mod_model_info.FieldEnumValue
        ''8/2023 new_field.DateEdited = Now

        ''Added 8/27/2023
        mod_model_copy.IsRelevantToPersonality = CType(sender, CheckBox).Checked  ''CheckBoxRelevant.Checked
        mod_model_copy.DateEdited = Now

        ''8/2023 RaiseEvent ModifiedField(new_field) ''Added 5/12/2022 td
        ''Added 8/27/2023
        ''#2 8/2023 RaiseEvent ModifiedField(mod_model_object)  
        RaiseEvent ModifiedField(mod_model_copy) ''Added 5/12/2022 td
        RaiseEvent ModifiedField_Enum(mod_model_info.FieldEnumValue) ''Added 8/27/2023 td

        ''Added 8/27/2023 td
        If (mod_model_copy.IsRelevantToPersonality) Then
            ''Added 8/27/2023 td
            RaiseEvent RelevantFieldAdded_Enum(mod_model_info.FieldEnumValue) ''Added 5/12/2022 td
        End If ''End of ""If (new_field.IsRelevantToPersonality) Then""

        ''With CheckBoxRelevant
        ''    If (.Checked) Then

        ''        Dim objFontStyle As New Drawing.FontStyle()
        ''        ''objFontStyle.Bold = True
        ''        ''objFontStyle.Underline = True
        ''        .Font = New Drawing.Font(.Font, Drawing.FontStyle.Underline Or
        ''                                       Drawing.FontStyle.Bold)

        ''    Else

        ''        Dim objFontStyle As New Drawing.FontStyle()
        ''        ''objFontStyle.Bold = True
        ''        ''objFontStyle.Underline = True
        ''        .Font = New Drawing.Font(.Font, Drawing.FontStyle.Regular)

        ''    End If
        ''End With

    End Sub
End Class
