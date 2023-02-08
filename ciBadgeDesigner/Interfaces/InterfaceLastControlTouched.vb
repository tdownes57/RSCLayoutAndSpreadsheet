''
'' Added 12/28/2021 thomas downes 
''
Public Interface ILastControlTouched_Deprecated
    ''
    '' Added 12/28/2021 thomas downes 
    ''
    ''  We don't want to rely on the Static Property of the MoveableControlVB class. 
    ''     Better to place the information within an instantiated object. 
    ''     ----12/28/2021 thomas d. 
    ''
    ''
    '' Oops!! Interfaces should not contain properties, but rather methods.
    '' ---2/07/2023 tcd
    ''
    Property LastControlTouched As Control ''MoveableControlVB  



End Interface
