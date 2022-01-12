''
''Added 7/31/2019 thomas downes  
''

Public Interface ISelectingElements
    ''
    ''Added 7/31/2019 thomas downes  
    ''
    Sub ElementsDesignList_Add(par_control As CtlGraphicFldLabel) ''Implements ISelectingElements.ElementsDesignList_Add

    Sub ElementsDesignList_Remove(par_control As CtlGraphicFldLabel) ''Implements ISelectingElements.ElementsDesignList_Remove

    Function ElementsList_CountItems() As Integer ''Implements ISelectingElements.ElementsDesignList_CountItems
    Function ElementsList_OneOrMoreItems() As Boolean ''Implements ISelectingElements.ElementsDesignList_OneOrMoreItems
    Function ElementsList_TwoOrMoreItems() As Boolean ''Implements ISelectingElements.ElementsDesignList_TwoOrMoreItems
    Function ElementsList_IsItemIncluded(par_control As CtlGraphicFldLabel) As Boolean ''Implements ISelectingElements.ElementsDesignList_IsItemIncluded
    Function ElementsList_IsItemUnselected(par_control As CtlGraphicFldLabel) As Boolean ''Implements ISelectingElements.ElementsDesignList_IsItemIncluded

    ''
    ''Added 8/3/2019 thomas downes
    ''
    ''10/17/2019 td''Property ElementsDesignList_AllItems As List(Of CtlGraphicFldLabel)
    Property ElementsDesignList_AllItems As HashSet(Of CtlGraphicFldLabel)

    ''
    ''Added 8/16/2019 thomas downes
    ''
    Function HasAtLeastOne__Up(par_control As CtlGraphicFldLabel) As Boolean
    Function HasAtLeastOne_Down(par_control As CtlGraphicFldLabel) As Boolean

    Sub SwitchControls___Up(par_control As CtlGraphicFldLabel)
    Sub SwitchControls_Down(par_control As CtlGraphicFldLabel)




End Interface ''ENd of "Public Interface ISelectingElements"
