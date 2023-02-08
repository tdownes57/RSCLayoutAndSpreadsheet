''
''Added 7/20/2019 thomas downes
''

Public Interface ICIBFieldStandardOrCustom
    ''7/26/2019 td''Public Interface ICIBFieldCustom
    ''
    ''Added 7/20/2019 thomas downes
    ''
    ''Fields cannot link outward to elements.---9/18/2019 td''Property ElementInfo_Base As IElement_Base ''Added 9/3/2019 thomas d.
    ''Fields cannot link outward to elements.---9/18/2019 td''Property ElementInfo_Text As IElement_TextField ''Added 9/3/2019 thomas d.

    ''
    '' Oops! Interfaces should not contain properties, but rather methods.
    '' ---2/07/2023 tcd
    ''
    Property FieldLabelCaption As String


    Property IsRelevantToPersonality As Boolean ''Added 11/18/2021 td
    Property IsDisplayedOnBadge As Boolean ''Added 8/29 & 8/22/2019 td
    Property IsDisplayedForEdits As Boolean ''Added 8/29 & 8/22/2019 td
    Property IsDisplayedOnBadge_Front As Boolean ''Added 12/8/2021 td
    Property IsDisplayedOnBadge_Backside As Boolean ''Added 12/8/2021 td

    Property IsStandard As Boolean ''Added 7/26/2019 thomas d. 
    Property IsCustomizable As Boolean ''Added 7/26/2019 thomas d. 

    Property IsDateField As Boolean ''Added 9/16/2019 td
    Property Text_OrDate As String ''Added 9/16/2019 td

    Property FieldType_TD As Char
    Property FieldIndex As Integer
    Property FieldEnumValue As ciBadgeInterfaces.EnumCIBFields ''Added 9/16/2019 td  

    Property IsFieldForDates As Boolean
    Property IsLocked As Boolean

    Property ExampleValue As String
    Property DefaultValue As String ''Added 12/1/2019 thomas downes

    Property HasPresetValues As Boolean

    ''Not needed here. ---9/16/2019 td''Property ArrayOfValues As String()

    Property IsAdditionalField As Boolean ''Added 7/21/2019 thomas downes
    Property IsBarcodeField As Boolean ''Added 7/31/2019 thomas downes

    ''9/16/2019 td''Property CIBadgeField_Optional As String ''Added 7/21/2019 thomas downes
    Property CIBadgeField As String ''Added 7/21/2019 thomas downes

    Property OtherDbField_Optional As String ''Added 7/21/2019 thomas downes

    ''Added 8/29 & 8/22/2019 td
    ''Moved above, on 11/18/2021 td''Property IsDisplayedOnBadge As Boolean
    ''Moved above, on 11/18/2021 td''Property IsDisplayedForEdits As Boolean

    Property DataEntryText As String ''Added 9/9/2019 td 

    Property IsLinkedToSections As Boolean ''Added 9/17/2019 td 
    Property SublayoutLookup As Dictionary(Of String, Integer) ''Added 9/17/2019 td

    ''Moved to InterfaceElementBase. ----9/19 td''Property Visible As Boolean ''Added 9/19/2019 td

    Property DateEdited As Date ''Added 12/5/2021 thomas downes  
    Property DateSaved As Date ''Added 12/5/2021 thomas downes  

End Interface
