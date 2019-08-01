''
''Added 7/31/2019 thomas downes  
''

Public Interface ISelectingElements
    ''
    ''Added 7/31/2019 thomas downes  
    ''
    Sub LabelsDesignList_Add()

    Sub LabelsDesignList_Remove()

    Function LabelsList_CountItems() As Integer
    Function LabelsList_OneOrMoreItems() As Boolean
    Function LabelsList_TwoOrMoreItems() As Boolean
    Function LabelsList_IsItemIncluded() As Boolean

End Interface ''ENd of "Public Interface ISelectingElements"
