Option Explicit On ''Added Jan1 2022 
Option Strict On ''Added Jan1 2022 
Imports __RSCWindowsControlLibrary
''
'' Added 12/28/2021 thomas downes 
''
Public Interface ILastControlTouchedRSC
    ''
    '' Added 12/28/2021 thomas downes 
    ''
    ''  We don't want to rely on the Static Property of the MoveableControlVB class. 
    ''     Better to place the information within an instantiated object. 
    ''     ----12/28/2021 thomas d. 
    ''
    ''1/2/2022 td''Property LastControlTouched As MoveableControlVB
    Property LastControlTouchedRSC As RSCMoveableControlVB



End Interface
