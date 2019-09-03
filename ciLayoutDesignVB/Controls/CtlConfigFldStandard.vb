Option Explicit On
Option Strict On
Option Infer Off

''
''Programming added 8/19/2019 thomas d. 
''
Imports ciBadgeInterfaces ''Added 8/29/2019 thomas downes 

Public Class CtlConfigFldStandard
    ''
    ''Added 8/19/2019 td
    ''
    ''8/29/2019 td''Public Model As ClassFieldStandard ''Added 8/19/2019 thomas d.
    Public ModelFieldInfo As ICIBFieldStandardOrCustom ''Added 8/29/2019 thomas d. 

    Public NewlyAdded As Boolean ''Add 8/19/2019 td 

    Private mod_model As ICIBFieldStandardOrCustom
    Private mod_model_copy As ClassFieldStandard ''Added 8/19/2019 thomas d. 

    Private mod_arrayOfValues As String() ''Added 8/19/2019 td 
    Private mod_s_CIBadgeField As String '' = .CIBadgeField_Optional
    Private mod_s_OtherDbField As String '' = .OtherDbField_Optional
    Private mod_s_ExampleValue As String '' = .ExampleValue

    Private mod_loading As Boolean = True ''Added 7/27/2019 td

    Public ReadOnly Property Field_Standard() As ClassFieldStandard
        Get
            ''Added 9/2/2019 thomas downes
            Return mod_model_copy
        End Get
    End Property

    Public Sub Load_StandardControl(par_info As ICIBFieldStandardOrCustom)
        ''
        ''Added 8/19/2019 Thomas DOWNES   
        ''
        mod_model = par_info

        mod_model_copy = New ClassFieldStandard
        mod_model_copy.Load_ByCopyingMembers(par_info)

        LabelHeaderTop.Text = mod_model_copy.FieldLabelCaption

        ''If a fieldname is missing, then display the field index. 
        ''
        If (LabelHeaderTop.Text = "") Then If (mod_model_copy.FieldIndex > 0) Then LabelHeaderTop.Text = "Field # " & CStr(mod_model_copy.FieldIndex)

        With par_info

            mod_arrayOfValues = .ArrayOfValues
            ''Me.CIBadgeField = .CIBadgeField_Optional

            mod_s_CIBadgeField = .CIBadgeField_Optional
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


        End With ''End of "With par_info"  

ExitHandler:
        ''Added 7/27/2019 thomas downes
        mod_loading = False

    End Sub ''End of "Public Sub Load_StandardControl"

    Public Sub Save_StandardControl()
        ''
        ''Added 8/22/2019 & 7/21/2019 Thomas DOWNES   
        ''
        With mod_model

            ''---.HasPresetValues = checkHasPresetValues.Checked
            .FieldLabelCaption = textFieldLabel.Text
            .IsFieldForDates = checkIsFieldForDates.Checked
            .IsLocked = checkIsLocked.Checked

            ''Added 8/22/2019 Thomas DOWNES
            .IsDisplayedOnBadge = checkDisplayOnBadge.Checked
            .IsDisplayedForEdits = checkDisplayForEdits.Checked

            ''---.IsAdditionalField = checkIsAdditionalField.Checked
            .ArrayOfValues = mod_arrayOfValues

            .CIBadgeField_Optional = mod_s_CIBadgeField '' = .CIBadgeField_Optional
            .OtherDbField_Optional = mod_s_OtherDbField '' = .OtherDbField_Optional
            .ExampleValue = mod_s_ExampleValue '' = .ExampleValue

        End With ''End of "With par_info"  

        ''Added 7/27/2019 td  
        ''8/29/2019 td''Me.Model = mod_model
        Me.ModelFieldInfo = mod_model

    End Sub ''End of "Public Sub Save_StandardControl()" 


End Class
