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
        ''Jan19 2022 td''Function HeightAnyRSCMoveableControl() As Integer ''Added 1/18/2022 thomas d
        Function SizeAnyRSCMoveableControl() As System.Drawing.Size ''Added 1/19/2022 thomas d

        ''Added 1/26/2022 thomas downes
        Sub ProceedToBackSide_SetupBacksideLabels()

        ''Added 5/12/2022 td
        ''5/17/2022 td''Sub BackgroundImage_Select()
        Sub BackgroundImage_Select(pboolDemoMode As Boolean)
        Sub BackgroundImage_Upload()
        Sub BackgroundImage_SelectOrUpload()  ''Added 5/13/2022 thomas downes


    End Interface

End Namespace



