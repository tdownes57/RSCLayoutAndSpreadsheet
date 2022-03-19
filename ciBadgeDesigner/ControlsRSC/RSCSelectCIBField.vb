Option Explicit On '' Added 2/16/2022 thomas downes 
Option Strict On '' Added 2/16/2022 thomas downes 
''
'' Added 2/16/2022 thomas downes 
''
Imports ciBadgeFields
Imports ciBadgeInterfaces
Imports ciBadgeCachePersonality ''Added 3/13/2022 td

Public Class RSCSelectCIBField
    ''
    '' Added 2/16/2022 thomas downes 
    ''
    Private mod_fields As List(Of ciBadgeFields.ClassFieldAny)

    Public Property SelectedValue() As EnumCIBFields
        ''
        ''Added 3/15/2022 thomas downes 
        ''
        Get
            ''Added 3/15/2022 thomas downes 0
            ''----#1 3/18/2022  Return CType(Me.comboBoxRelevantFields.SelectedItem, EnumCIBFields)
            ''----#1 3/18/2022  Return CType(Me.comboBoxRelevantFields.SelectedValue, EnumCIBFields)
            Dim outputEnum As ciBadgeInterfaces.EnumCIBFields ''Added 3/18/2022 thomas downes
            outputEnum = CType(Me.comboBoxRelevantFields.SelectedValue, EnumCIBFields)
            Return outputEnum

        End Get
        Set(value As EnumCIBFields)
            ''Added 3/15/2022 thomas downes 
            ''----3/18/2022  Me.comboBoxRelevantFields.SelectedItem = value
            Me.comboBoxRelevantFields.SelectedValue = value
        End Set
    End Property


    Public Sub Load_FieldsFromCache(par_cache As ClassElementsCache_Deprecated)
        ''
        ''Added 2/16/2022 thomas downes
        ''
        ''Is this is an overload function? No, it's not. 
        ''
        ''Dim each_field As ClassFieldAny
        ''For Each each_field In par_cache.ListOfFields_ForEditing()
        ''    comboBoxRelevantFields.Items.Add(each_field.FieldLabelCaption)
        ''Next each_field

        Dim listOfFields As New List(Of ClassFieldAny)
        listOfFields = par_cache.ListOfFields_SC_ForEditing()

        ''Added 3/18/2022
        comboBoxRelevantFields.DisplayMember = "FieldLabelCaption"
        comboBoxRelevantFields.ValueMember = "FieldEnumValue"

        ''
        ''Calling this function's original overload!!
        ''
        ''Not needed.----3/18/2022 thomas d''Load_Control(listOfFields, EnumCIBFields.Undetermined)
        comboBoxRelevantFields.DataSource = listOfFields

    End Sub ''End of "Public Sub Load_Fields()"


    Public Sub Load_Control(par_list As List(Of ClassFieldAny), Optional par_enum _
                            As ciBadgeInterfaces.EnumCIBFields = EnumCIBFields.Undetermined)
        ''
        ''Added 2/16/2022 thomas downes
        ''
        Dim each_field As ClassFieldAny

        ''Added 3/18/2022
        ''---comboBoxRelevantFields.ValueMember = "FieldEnumValue"

        For Each each_field In par_list

            ''comboBoxRelevantFields.Items.Add(each_field.FieldLabelCaption)
            comboBoxRelevantFields.Items.Add(each_field)

        Next each_field

    End Sub ''End of "Public Sub Load_Control()"


    Private Sub LabelHeader_Click(sender As Object, e As EventArgs) Handles LabelHeader.Click
        ''
        '' Added 2/16/2022 thomas downes 
        ''

    End Sub

    Private Sub LinkLabelOnlyRelevant_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelOnlyRelevant.LinkClicked
        ''
        ''Added 3/17/2022 Thomas Downes
        ''
        Dim form_ToShow As New DialogListBothTypeFields
        form_ToShow.ShowDialog()


    End Sub
End Class
