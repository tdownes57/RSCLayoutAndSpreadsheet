Option Explicit On '' Added 2/16/2022 thomas downes 
Option Strict On '' Added 2/16/2022 thomas downes 
''
'' Added 2/16/2022 thomas downes 
''
Imports ciBadgeFields
Imports ciBadgeInterfaces

Public Class SelectCIBField_NotInUse
    ''
    '' Added 2/16/2022 thomas downes 
    ''
    Private mod_fields As List(Of ciBadgeFields.ClassFieldAny)

    Public Sub Load_Control(par_list As List(Of ClassFieldAny),
    Optional par_enum As ciBadgeInterfaces.EnumCIBFields = EnumCIBFields.Undetermined)
        ''
        ''Added 2/16/2022 thomas downes
        ''
        Dim each_field As ClassFieldAny

        For Each each_field In par_list

            comboBoxRelevantFields.Items.Add(each_field.FieldLabelCaption)

        Next each_field




    End Sub ''End of "Public Sub Load_Control()"


    Private Sub LabelHeader_Click(sender As Object, e As EventArgs) Handles LabelHeader.Click
        ''
        '' Added 2/16/2022 thomas downes 
        ''

    End Sub



End Class
