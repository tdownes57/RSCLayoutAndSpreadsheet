''
''Added 9/9/2019 thomas downes  
''

Public Interface ISelectingElements_v90
    ''
    ''Added 7/31/2019 thomas downes  
    ''
    Sub LabelsDesignList_Add(par_control As CtlMainEntryBox_v90) ''Implements ISelectingElements.LabelsDesignList_Add

    Sub LabelsDesignList_Remove(par_control As CtlMainEntryBox_v90) ''Implements ISelectingElements.LabelsDesignList_Remove

    Function LabelsList_CountItems() As Integer ''Implements ISelectingElements.LabelsDesignList_CountItems
    Function LabelsList_OneOrMoreItems() As Boolean ''Implements ISelectingElements.LabelsDesignList_OneOrMoreItems
    Function LabelsList_TwoOrMoreItems() As Boolean ''Implements ISelectingElements.LabelsDesignList_TwoOrMoreItems
    Function LabelsList_IsItemIncluded(par_control As CtlMainEntryBox_v90) As Boolean ''Implements ISelectingElements.LabelsDesignList_IsItemIncluded
    Function LabelsList_IsItemUnselected(par_control As CtlMainEntryBox_v90) As Boolean ''Implements ISelectingElements.LabelsDesignList_IsItemIncluded

    ''
    ''Added 8/3/2019 thomas downes
    ''
    Property LabelsDesignList_AllItems As List(Of CtlMainEntryBox_v90)

    ''
    ''Added 9/9/2019 & 8/16/2019 thomas downes
    ''
    Function HasAtLeastOne__Up(par_control As CtlMainEntryBox_v90) As Boolean
    Function HasAtLeastOne_Down(par_control As CtlMainEntryBox_v90) As Boolean

    Sub SwitchControls___Up(par_control As CtlMainEntryBox_v90)
    Sub SwitchControls_Down(par_control As CtlMainEntryBox_v90)




End Interface ''ENd of "Public Interface ISelectingElements_v90"

