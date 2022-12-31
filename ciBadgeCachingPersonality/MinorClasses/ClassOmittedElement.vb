''
''Added 2/28/2022 thomas downes
''
Imports ciBadgeInterfaces   ''Added March 3, 2022 t&h&o&m&a&s d&o&w&n&e&s 

Public Class ClassOmittedElement
    ''
    ''Added 2/28/2022 thomas downes
    ''
    Public OmittedElementType As ciBadgeInterfaces.Enum_ElementType
    Public OmittedFieldIfApplicable As ciBadgeInterfaces.EnumCIBFields

    ''3/3/2022 td''Private mod_strOmittedElement As String
    Private mod_strOmissionName As String ''Added 3/3/2022 td

    Public Sub New(par_enumElementType As Enum_ElementType, pstrOmissionName As String)

        ''Added 3/3/2022 td
        OmittedElementType = par_enumElementType
        mod_strOmissionName = pstrOmissionName

    End Sub


    Public Sub New(par_enumField As EnumCIBFields)

        ''Added 3/3/2022 td
        OmittedElementType = Enum_ElementType.Undetermined
        OmittedFieldIfApplicable = par_enumField
        mod_strOmissionName = par_enumField.ToString()

    End Sub



    Public Overrides Function ToString() As String

        ''March3 2022 td''Return mod_strOmittedElement '' As String
        Return mod_strOmissionName '' As String

    End Function



End Class
