''
''Added 10/13/2019 td 
''
Imports ciBadgeInterfaces

Public Interface IDesignerForm
    ''
    ''Added 10/13/2019 td 
    ''
    ''----Sub RefreshElementsCache_Edited(par_cache As ClassElementsCache)
    Sub RefreshElementsCache_Saved(par_cache As ClassElementsCache_Deprecated)

    Property BadgeLayout As BadgeLayoutClass ''Added 10/13/2019 td 

End Interface
