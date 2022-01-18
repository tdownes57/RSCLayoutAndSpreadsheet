''
''Added 10/13/2019 td 
''
Imports ciBadgeInterfaces

Namespace ciBadgeCachePersonality

    Public Interface IDesignerForm
        ''
        ''Added 10/13/2019 td 
        ''
        ''   This is making use of the Dependency Injection pattern.
        ''     
        ''----Sub RefreshElementsCache_Edited(par_cache As ClassElementsCache)
        Sub RefreshElementsCache_Saved(par_cache As ClassElementsCache_Deprecated)

        Property BadgeLayout As BadgeLayoutClass ''Added 10/13/2019 td 

        ''
        ''Added 12/27/2021 thomas downes
        ''
        ''   This is making use of the Dependency Injection pattern.
        ''
        Sub RefreshPreview() ''Added 12/27/2021 td

        ''Added 1/18/2022 td
        Function HeightAnyRSCMoveableControl() As Integer ''Added 1/18/2022 thomas d

    End Interface

End Namespace



