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
Public Class CtlConfigFldSimpleCustom
    ''
    ''Added 5/11/2022 td
    ''
    Public ModelFieldInfo As ICIBFieldStandardOrCustom ''Added 8/29/2019 thomas d. 

    Public Event RelevancyChangedTo(pbRelevant As Boolean) ''Added 4/13/2022 td
    Public NewlyAdded As Boolean ''Add 7/23/2019 td 

    ''9/16/2019 td''Private mod_model As ICIBFieldStandardOrCustom
    Private mod_model As ClassFieldCustomized
    Private mod_model_copy As ClassFieldCustomized ''Added 7/23/2019 thomas d. 

    Private mod_arrayOfValues As String() ''Added 7/23/2019 td 
    Private mod_s_CIBadgeField As String '' = .CIBadgeField_Optional
    Private mod_s_OtherDbField As String '' = .OtherDbField_Optional
    Private mod_s_ExampleValue As String '' = .ExampleValue

    ''4/13/2022 ''Private mod_loading As Boolean = True ''Added 7/27/2019 td
    Private mod_isLoading As Boolean = True ''Added 7/27/2019 td

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
        ''LabelDateEdited.Text = mod_model.DateEdited.ToString("mm/dd/yy HH:mm")

        ''If a fieldname is missing, then display the field index. 
        If (LabelHeaderTop.Text = "") Then If (mod_model_copy.FieldIndex > 0) Then LabelHeaderTop.Text = "Field # " & CStr(mod_model_copy.FieldIndex)

        With par_field ''9/16 td''With par_info

            mod_arrayOfValues = .ArrayOfValues
            ''Me.CIBadgeField = .CIBadgeField_Optional

            mod_s_CIBadgeField = .CIBadgeField
            mod_s_OtherDbField = .OtherDbField_Optional
            mod_s_ExampleValue = .ExampleValue

            ''checkHasPresetValues.Checked = .HasPresetValues
            textFieldLabel.Text = .FieldLabelCaption
            ''checkIsFieldForDates.Checked = .IsFieldForDates
            ''checkIsLocked.Checked = .IsLocked
            ''checkIsAdditionalField.Checked = .IsAdditionalField

            ''If (.ArrayOfValues IsNot Nothing) Then
            ''    listPresetValues.Items.AddRange(.ArrayOfValues)
            ''End If ''End of "If (.ArrayOfValues IsNot Nothing) Then"

            ''
            ''Added 9/6/2019 thomas downes
            ''
            ''checkDisplayOnBadge.Checked = .IsDisplayedOnBadge
            ''checkDisplayForEdits.Checked = .IsDisplayedForEdits

            ''Added 12//3/2021 thomas downes
            ''5/11/2022 checkRelevantToPersonality.Checked = .IsRelevantToPersonality
            CheckBoxRelevant.Checked = .IsRelevantToPersonality

            ''Added 12/6/2021 thomas downes
            ''  Make it pretty clear to user that there's a ON-OFF relationship here. 
            ''checkDisplayForEdits.Enabled = .IsRelevantToPersonality ''False
            ''checkDisplayOnBadge.Enabled = .IsRelevantToPersonality ''False

        End With ''End of "With par_info"  

ExitHandler:
        ''Added 7/27/2019 thomas downes
        ''4/13/2022 mod_loading = False
        mod_isLoading = False ''Modified 4/2022

    End Sub ''End of "Public Sub Load_CustomControl"


    Public Sub Save_CustomControl()
        ''
        ''Added 7/21/2019 Thomas DOWNES   
        ''
        With mod_model

            ''.HasPresetValues = checkHasPresetValues.Checked
            .FieldLabelCaption = textFieldLabel.Text
            ''.IsFieldForDates = checkIsFieldForDates.Checked
            ''.IsLocked = checkIsLocked.Checked
            ''.IsAdditionalField = checkIsAdditionalField.Checked
            .ArrayOfValues = mod_arrayOfValues

            .CIBadgeField = mod_s_CIBadgeField '' = .CIBadgeField_Optional
            .OtherDbField_Optional = mod_s_OtherDbField '' = .OtherDbField_Optional

            .ExampleValue = mod_s_ExampleValue '' = .ExampleValue

            ''Added 9/6/2019 td
            ''
            ''.IsDisplayedForEdits = checkDisplayForEdits.Checked
            ''.IsDisplayedOnBadge = checkDisplayOnBadge.Checked

            ''Added 12//3/2021 thomas downes
            ''5/11/2022 .IsRelevantToPersonality = checkRelevantToPersonality.Checked
            .IsRelevantToPersonality = CheckBoxRelevant.Checked

            ''Added 12/5/2021 thomas downes
            .DateSaved = DateTime.Now

        End With ''End of "With mod_model"  

        ''Added 7/27/2019 td  
        ''8/29/2019 td''Me.Model = mod_model
        Me.ModelFieldInfo = mod_model

        ''Added 12/5/2021 thomas downes
        mod_model_copy = mod_model.Copy_FieldCustom()

    End Sub ''End of "Public Sub Save_CustomControl()" 


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

            Else

                Dim objFontStyle As New Drawing.FontStyle()
                ''objFontStyle.Bold = True
                ''objFontStyle.Underline = True
                .Font = New Drawing.Font(.Font, Drawing.FontStyle.Regular)

            End If
        End With

    End Sub ''end of Public Sub LoadCheckboxFontStyle()
    Private Sub CheckBoxRelevant_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxRelevant.CheckedChanged
        ''
        ''Added 5/11/2022 td
        ''
        LoadCheckboxFontStyle()

    End Sub
End Class
