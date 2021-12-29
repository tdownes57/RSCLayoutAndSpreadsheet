Public Interface ISelectedControls
    ''
    '' Added 12/28/2021 thomas downes 
    ''
    '' So that Controls can be grouped together and moved/resized as one.
    ''   (i.e. all controls in the selection list are moved (or resized)
    ''   in unison. ----12/28/2021 td 
    ''
    Property LastControlSelected As MoveableControlVB

    Property ListControlsSelected As List(Of MoveableControlVB)

    Sub RemoveAllControlsFromList()
    Sub UnselectAllControls() ''This will be an Alias function.  

    Sub SelectControl(par_control As MoveableControlVB)
    Sub UnselectControl(par_control As MoveableControlVB)


    Sub IndicateVisiblyIfOrNotSelected(par_control As MoveableControlVB)
    Sub IndicateVisiblyIfOrNotSelected_AllControls()


End Interface
