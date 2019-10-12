''
''Added 10/11/2019 td  
''
Imports ciBadgeFields ''Added 10/11/2019 td
Imports ciBadgeElements ''Added 10/11/2019 td
Imports ciBadgeRecipients ''Added 10/11/2019 td 

<Serializable>
Public Class PersonalityCache
    ''
    ''Added 10/11/2019 td  
    ''
    Public Property ConfigId_GUID As System.Guid ''Added 10/11/2019 td
    Public Property ConfigId_Int As Integer ''Added 10/11/2019 td 

    Public Property PathToXml_Saved As String ''Added 10/11/2019 td

    Public Property ListOfRecipients As List(Of ClassRecipient) ''Added 10/11/2019 td
    Public Property ListOfFields As List(Of ClassFieldAny) ''Added 10/11/2019 td

    Public Property ElementFields_DataEntry_V8 As List(Of ClassElementField)
    Public Property ElementFields_DataEntry_V9 As List(Of ClassElementField)

    Public Property ListOfLayouts As List(Of BadgeLayoutCache) ''Added 10/11/2019 td






End Class ''End of "Public Class ClassPersonalityCache"
