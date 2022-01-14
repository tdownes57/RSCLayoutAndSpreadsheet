''-----Public Class ClassElementsCache_Bifurcated
Option Explicit On
Option Strict On
Option Infer Off
''
''Added 1/13/2022 thomas downes
''
Imports System.Drawing ''Added 9/18/2019 td
Imports System.Windows.Forms ''Added 9/18/2019 td
Imports ciBadgeInterfaces ''Added 9/16/2019 td 
Imports ciBadgeFields ''Added 9/18/2019 td
Imports ciBadgeRecipients ''Added 10/16/2019 thomas d. 
Imports ciBadgeElements ''Added 12/4/2021 thomas downes  

Namespace ciBadgeCachePersonality

    <Serializable>
    Public Class ClassElementsCache2_Bifurcated
        ''
        ''Added 1/13/2022 thomas downes
        ''
        Public Property Id_GUID As System.Guid
        Public Property Id_GUID6 As String
        Public Property Id_GUID6_CopiedFrom As String

        Public Property PathToXml_Saved As String
        Public Property PathToXml_Opened As String
        Public Property PathToXml_Binary As String

        Public Property Personality As ClassPersonalityConfig

        ''Moved below.''Public Property BadgeLayout As ciBadgeInterfaces.BadgeLayoutClass

        <Xml.Serialization.XmlIgnore>
        Public Property Pic_InitialDefault As Image

        Public Property DateAndTimeUpdated As DateTime

        ''
        ''Encapsulated 1/13/2022 thomas downes
        ''
        ''   This is where the Fields are stored.  
        ''
        Public Property Fields As ClassFieldCache

        ''
        ''Added 1/13/2022 Thomas Downes
        ''
        ''  Here is the sole reason for this new Cache (ClassElementsCacheV2_Bifurcated). 
        ''
        ''This list will have 1 or 2 items, representing the Front & possible Backside
        ''  of the ID Card Badge.   ----1/13/2022 td
        ''
        ''  Here is the sole reason for this new Cache (ClassElementsCacheV2_Bifurcated).  I feel
        ''    that this List of BadgeSideLayoutV2, having one or two items (one or two sides 
        ''    of the badge), can greatly simplify the cache (ClassElementsCacheV1_Deprectated).
        ''       ----1/13/2022 td
        ''
        Private mod_listBadgeSideLayoutV2s As New HashSet(Of ClassBadgeSideLayoutV2)
        Public Property BadgeLayout As ciBadgeInterfaces.BadgeLayoutClass
        Public Property BadgeHasTwoSidesOfCard As Boolean

        ''
        ''Added 1/13/2022 Thomas Downes
        ''
        ''  Here is the sole reason for this new Cache (ClassElementsCacheV2_Bifurcated).  I feel
        ''    that this List of BadgeSideLayoutV2, having one or two items (one or two sides 
        ''    of the badge), can greatly simplify the cache (ClassElementsCacheV1_Deprectated).
        ''       ----1/13/2022 td
        ''
        Public Property ListOfBadgeSideLayoutV2s As HashSet(Of ClassBadgeSideLayoutV2)
            ''
            ''This list will have 1 or 2 items, representing the Front & possible Backside
            ''  of the ID Card Badge.   ----1/13/2022 td
            ''
            Get
                ''Added 1/13/2022 td
                Return mod_listBadgeSideLayoutV2s
            End Get
            Set(value As HashSet(Of ClassBadgeSideLayoutV2))
                ''Added 1/13/2022 td
                mod_listBadgeSideLayoutV2s = value
            End Set
        End Property


    End Class

End Namespace