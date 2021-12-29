Public Interface ISelectedControls
    ''
    '' Added 12/28/2021 thomas downes 
    ''
    '' So that Controls can be grouped together and moved/resized as one.
    ''   (i.e. all controls in the selection list are moved (or resized)
    ''   in unison. ----12/28/2021 td 
    ''
    ''Dec 29 2021''Property LastControlSelected As MoveableControlVB
    Property LastControlSelected As RSCMoveableControlVB

    ''Dec29 2021''Property ListControlsSelected As List(Of MoveableControlVB)
    Property ListControlsSelected As List(Of RSCMoveableControlVB)

    Sub RemoveAllControlsFromList()
    Sub UnselectAllControls() ''This will be an Alias function.  

    Sub SelectControl(par_control As RSCMoveableControlVB)
    Sub UnselectControl(par_control As RSCMoveableControlVB)


    Sub IndicateVisiblyIfOrNotSelected(par_control As RSCMoveableControlVB)
    Sub IndicateVisiblyIfOrNotSelected_AllControls()


End Interface
