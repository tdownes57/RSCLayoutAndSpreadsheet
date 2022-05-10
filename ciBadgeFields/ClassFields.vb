''
''Substantiated 9/3/2019 thomas downes. 
''
Imports ciBadgeInterfaces ''Added 9/3/2019 td  

Public Class ClassFields
    ''Inherits List(Of ClassFieldCustomized)

    Public Shared Function ListAllFields() As List(Of ICIBFieldStandardOrCustom)
        ''
        ''Added 9/3/2019 Thomas Downes  
        ''
        Dim list_of_fields As New List(Of ICIBFieldStandardOrCustom)

        ''----------------------------------------------------------------------------------------------------
        ''
        ''Part 1 of 2.  Initialize the lists. 
        ''
        ''----------------------------------------------------------------------------------------------------
        ''Standard Fields (Initialize the list) 
        ''
        ''5/3/2022 td''ClassFieldStandard.InitializeHardcodedList_Students(True)
        ''5/9/2022 td''ClassFieldStandard.InitializeHardcodedList_Students(True)
        Dim listStandard As HashSet(Of ClassFieldStandard)
        Dim dictStandard As New Dictionary(Of EnumCIBFields, ClassFieldStandard) ''Added 5/10/2022

        listStandard =
            ClassFieldStandard.GetInitializedList_Standard("Students", dictStandard)

        ''----------------------------------------------------------------------------------------------------
        ''Custom Fields (Initialize the list)  
        ''
        ''5/3/2022 td''ClassFieldCustomized.InitializeHardcodedList_Students(True)
        ''5/7/2022 td''ClassFieldCustomized.InitializeHardcodedList_Custom(True)
        Dim listCustomized As HashSet(Of ClassFieldCustomized)
        listCustomized =
            ClassFieldCustomized.GetInitializedList_Custom("Students")

        ''----------------------------------------------------------------------------------------------------
        ''
        ''End of "Part 1 of 2.  Initialize the lists." 
        ''
        ''----------------------------------------------------------------------------------------------------

        ''----------------------------------------------------------------------------------------------------
        ''
        ''Part 2 of 2.  Collect the list items. 
        ''
        ''----------------------------------------------------------------------------------------------------
        ''Standard Fields (Collect the list items)  
        ''
        For Each field_standard As ClassFieldStandard In listStandard ''5/9/2022 ClassFieldStandard.ListOfFields_Standard  ''5/7/2022 td _Students
            ''5/09/2022 td''For Each field_standard As ClassFieldStandard In ClassFieldStandard.ListOfFields_Standard ''5/7/2022 td _Students

            list_of_fields.Add(CType(field_standard, ICIBFieldStandardOrCustom))

        Next field_standard
        ''----------------------------------------------------------------------------------------------------

        ''----------------------------------------------------------------------------------------------------
        ''Custom Fields (Collect the list items) 
        ''
        For Each field_custom As ClassFieldCustomized In listCustomized ''5/9/2022 ClassFieldCustomized.ListOfFields_Custom
            ''5/09/2022 td''For Each field_custom As ClassFieldCustomized In ClassFieldCustomized.ListOfFields_Custom ''5/7/2022 td _Students
            ''5/07/2022 For Each field_custom As ClassFieldCustomized In ClassFieldCustomized.ListOfFields_Students

            list_of_fields.Add(CType(field_custom, ICIBFieldStandardOrCustom))

        Next field_custom
        ''----------------------------------------------------------------------------------------------------

        ''----------------------------------------------------------------------------------------------------
        ''
        ''End of "Part 2 of 2.  Collect the list items."  
        ''
        ''----------------------------------------------------------------------------------------------------

        Return list_of_fields

    End Function ''ENd of "Public Shared Function ListAllFields() As List(Of ICIBFieldStandardOrCustom)"

End Class
