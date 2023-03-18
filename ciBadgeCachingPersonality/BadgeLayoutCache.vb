
''
''Added 10/11/2019 thomas downes
''
''//---Imports ciBadgeElements
Imports ciBadgeCachePersonality

Public Class BadgeLayoutCache
    ''
    ''Added 10/11/2019 thomas downes
    ''
    Public Property LayoutId_GUID As System.Guid ''Added 10/11/2019 td 

    Public Property LayoutName As String ''Added 10/11/2019 td 

    ''Needed here??? 3.2023 Public Property DoubleSided As Boolean ''Added 10/11/2019 td

    ''Added 3/17/2023 td  
    ''3/17/2023 td Public Property LayoutSide As ClassBadgeSideLayoutV1
    Public Property LayoutSide As ClassBadgeSideLayoutV2

    ''Needed here??? 3.2023 Public Property Side1orFirst_Cache As ClassElementsCache_Deprecated ''The Front side. ----Added 10/11/2019 td 
    ''Needed here??? 3.2023 Public Property Side2orSecond_Cache As ClassElementsCache_Deprecated ''The Back side of the badge, if applicable. ----Added 10/11/2019 td 

    ''
    ''Conditional-Expression Design, so that a Personality does not
    ''   to be needlessly delineated into subclasses with separate badge-layouts.  
    ''
    ''Instead of have multiple layouts, a Personality can have one layout (with 
    ''   conditional elements/sections).  
    ''
    ''
    Public Property HasConditionalSections As Boolean ''Added 10/11/2019 td
    Public Property HasConditionalElements As Boolean ''Added 10/11/2019 td

End Class ''ENd of "Public Class BadgeLayoutCache"
