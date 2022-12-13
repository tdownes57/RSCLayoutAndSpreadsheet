''
'' Added 12/28/2021 thomas downes 
''
Public Interface ILastControlTouched
    ''
    '' Added 12/28/2021 thomas downes 
    ''
    ''  We don't want to rely on the Static Property of the MoveableControlVB class. 
    ''     Better to place the information within an instantiated object. 
    ''     ----12/28/2021 thomas d. 
    ''
    ''Dec29 2021 td''Property LastControlTouched As MoveableControlVB
    ''Dec29 2021 td''Property LastControlTouched As RSCMoveableControlVB ''Dec29 2021 

    Property LastControlTouched As Control ''Dec29 2021''RSCMoveableControlVB ''Dec29 2021 


End Interface
