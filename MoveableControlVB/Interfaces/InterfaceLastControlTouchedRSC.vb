﻿''
'' Added 12/28/2021 thomas downes 
''
Public Interface ILastControlTouched_MoveableControlVB ''1/15/2022 ILastControlTouched_Deprecated
    ''
    '' Added 12/28/2021 thomas downes 
    ''
    ''  We don't want to rely on the Static Property of the MoveableControlVB class. 
    ''     Better to place the information within an instantiated object. 
    ''     ----12/28/2021 thomas d. 
    ''
    Property LastControlTouched As MoveableControlVB



End Interface
