Option Strict On
Option Explicit On
''
''Added 12/6/2021 thomas downes
''
Imports ciBadgeCachePersonality ''Added 12/6/2021 td 
Imports ciBadgeFields
Imports System.Windows.Forms ''Added 12/30/2021 td  

Public Interface InterfaceShowListFields
    ''
    ''Added 12/6/2021 thomas downes
    ''
    Property ListOfFields_Custom As HashSet(Of ClassFieldCustomized)
    Property ListOfFields_Standard As HashSet(Of ClassFieldStandard)
    Property CacheManager As ClassCacheManagement

    Property JustOneField_Index As Integer
    ''Dec.13 2021''Property JustOneField_Object As ClassFieldAny ''Added 12/13/2021 thomas downes
    Property JustOneField_Any As ClassFieldAny ''Added 12/13/2021 thomas downes
    Property JustOneField_Custom As ClassFieldCustomized ''Added 12/13/2021 thomas downes
    Property JustOneField_Standard As ClassFieldStandard ''Added 12/13/2021 thomas downes

    Property ClosingOK_SoSaveWork As Boolean

    ''Added 12/6/2021 thomas downes 
    Function ShowDialog() As DialogResult

    ''Added 12/14/2021 thomas downes 
    Sub Show() ''12/14 td''As DialogResult

End Interface
