
''
''Added 10/11/2019 thomas downes
''
Imports ciBadgeElements

Public Class BadgeLayoutCache
    ''
    ''Added 10/11/2019 thomas downes
    ''
    Public Property LayoutId_GUID As System.Guid ''Added 10/11/2019 td 

    Public Property LayoutName As String ''Added 10/11/2019 td 

    Public Property DoubleSided As Boolean ''Added 10/11/2019 td

    Public Property Side1orFirst_Cache As ClassElementsCache ''The Front side. ----Added 10/11/2019 td 
    Public Property Side2orSecond_Cache As ClassElementsCache ''The Back side of the badge, if applicable. ----Added 10/11/2019 td 

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
