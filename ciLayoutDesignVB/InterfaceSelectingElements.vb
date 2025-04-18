﻿''
''Added 7/31/2019 thomas downes  
''
Imports ciBadgeDesigner ''Added 10/3/2019 td   

Public Interface ISelectingElements
    ''
    ''Added 7/31/2019 thomas downes  
    ''
    Sub LabelsDesignList_Add(par_control As CtlGraphicFldLabel) ''Implements ISelectingElements.LabelsDesignList_Add

    Sub LabelsDesignList_Remove(par_control As CtlGraphicFldLabel) ''Implements ISelectingElements.LabelsDesignList_Remove

    Function LabelsList_CountItems() As Integer ''Implements ISelectingElements.LabelsDesignList_CountItems
    Function LabelsList_OneOrMoreItems() As Boolean ''Implements ISelectingElements.LabelsDesignList_OneOrMoreItems
    Function LabelsList_TwoOrMoreItems() As Boolean ''Implements ISelectingElements.LabelsDesignList_TwoOrMoreItems
    Function LabelsList_IsItemIncluded(par_control As CtlGraphicFldLabel) As Boolean ''Implements ISelectingElements.LabelsDesignList_IsItemIncluded
    Function LabelsList_IsItemUnselected(par_control As CtlGraphicFldLabel) As Boolean ''Implements ISelectingElements.LabelsDesignList_IsItemIncluded

    ''
    ''Added 8/3/2019 thomas downes
    ''
    Property LabelsDesignList_AllItems As List(Of CtlGraphicFldLabel)

    ''
    ''Added 8/16/2019 thomas downes
    ''
    Function HasAtLeastOne__Up(par_control As CtlGraphicFldLabel) As Boolean
    Function HasAtLeastOne_Down(par_control As CtlGraphicFldLabel) As Boolean

    Sub SwitchControls___Up(par_control As CtlGraphicFldLabel)
    Sub SwitchControls_Down(par_control As CtlGraphicFldLabel)




End Interface ''ENd of "Public Interface ISelectingElements"
