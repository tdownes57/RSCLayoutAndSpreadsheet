''
''Added 7/20/2019 thomas downes
''

Public Interface ICIBFieldCustom
    ''
    ''Added 7/20/2019 thomas downes
    ''
    Property FieldLabelCaption As String

    Property FieldType_TD As Char
    Property FieldIndex As Integer

    Property IsFieldForDates As Boolean
    Property IsLocked As Boolean

    Property ExampleValue As String

    Property HasPresetValues As Boolean

    Property ArrayOfValues As String()

    Property IsAdditionalField As Boolean ''Added 7/21/2019 thomas downes

    Property CIBadgeField_Optional As String ''Added 7/21/2019 thomas downes
    Property OtherDbField_Optional As String ''Added 7/21/2019 thomas downes

End Interface
