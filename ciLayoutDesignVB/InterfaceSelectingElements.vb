''
''Added 7/31/2019 thomas downes  
''

Public Interface ISelectingElements
    ''
    ''Added 7/31/2019 thomas downes  
    ''
    Sub LabelsDesignList_Add() ''Implements ISelectingElements.LabelsDesignList_Add

    Sub LabelsDesignList_Remove() ''Implements ISelectingElements.LabelsDesignList_Remove

    Function LabelsList_CountItems() As Integer ''Implements ISelectingElements.LabelsDesignList_CountItems
    Function LabelsList_OneOrMoreItems() As Boolean ''Implements ISelectingElements.LabelsDesignList_OneOrMoreItems
    Function LabelsList_TwoOrMoreItems() As Boolean ''Implements ISelectingElements.LabelsDesignList_TwoOrMoreItems
    Function LabelsList_IsItemIncluded() As Boolean ''Implements ISelectingElements.LabelsDesignList_IsItemIncluded

End Interface ''ENd of "Public Interface ISelectingElements"
