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
        ClassFieldStandard.InitializeHardcodedList_Students(True)

        ''----------------------------------------------------------------------------------------------------
        ''Custom Fields (Initialize the list)  
        ''
        ClassFieldCustomized.InitializeHardcodedList_Students(True)

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
        For Each field_standard As ClassFieldStandard In ClassFieldStandard.ListOfFields_Students

            list_of_fields.Add(CType(field_standard, ICIBFieldStandardOrCustom))

        Next field_standard
        ''----------------------------------------------------------------------------------------------------

        ''----------------------------------------------------------------------------------------------------
        ''Custom Fields (Collect the list items) 
        ''
        For Each field_custom As ClassFieldCustomized In ClassFieldCustomized.ListOfFields_Students

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
