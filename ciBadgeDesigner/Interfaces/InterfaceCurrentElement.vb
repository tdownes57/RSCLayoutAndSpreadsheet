Option Explicit On
Option Strict On

Imports __RSCWindowsControlLibrary ''Added 12/30/2021 thomas d.
Imports ciBadgeCachePersonality ''Added 1/17/2022 thomas d. 
''
''Copied into the CIBadgeDesigner project, 12/30/2021 thomas 
''
Public Interface ICurrentElement ''Dec28 2021 ''InterfaceCurrentElement
    ''
    ''Added 12/28/2021 td 
    ''
    '' Oops!! Interfaces should not contain properties, but rather methods.
    '' ---2/07/2023 tcd
    ''
    Property CtlCurrentElement As RSCMoveableControlVB ''12/28/2021 td''Control
    Property ElementsCacheManager As ClassCacheManagement ''Added 1/17/2022 td

End Interface
