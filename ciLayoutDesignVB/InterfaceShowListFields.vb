Option Strict On
Option Explicit On
''
''Added 12/6/2021 thomas downes
''
Imports ciBadgeCachePersonality ''Added 12/6/2021 td 
Imports ciBadgeFields

Public Interface InterfaceShowListFields
    ''
    ''Added 12/6/2021 thomas downes
    ''
    Property ListOfFields_Custom As HashSet(Of ClassFieldCustomized)
    Property ListOfFields_Standard As HashSet(Of ClassFieldStandard)
    Property CacheManager As ClassCacheManagement

    Property JustOneField_Index As Integer
    Property ClosingOK_SoSaveWork As Boolean

    ''Added 12/6/2021 thomas downes 
    Function ShowDialog() As DialogResult

End Interface
