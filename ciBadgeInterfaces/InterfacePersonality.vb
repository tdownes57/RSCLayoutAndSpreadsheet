''
''Added 10/11/2019 thomas d. 
''
''   A Personality Configuration is often referred to as:  
''
''             Personality
''             Configuration
''
''    as short-hand expressions. 
''
''    Most customers have just one Personality, but many customers have two (2) [Students & Staff]
''    and a few of them have several.  
''
''

Public Interface InterfacePersonality
    ''
    ''Added 10/11/2019 thomas d. 
    ''
    Property ConfigID As Integer

    Property CustomerID As String ''Keep this, needed??   ---10/11/2019 td
    Property CustomerName As String ''Keep this, needed??

    Property PersonalityName As String ''E.g. Westboro High School Students, or just "Students" 

    Property Name_ReferringToThem As String ''E.g. Students, Staff, Teachers, Police Officers, Members, etc. 

    Property IncludeVisitorManagement As Boolean
    Property OnlyVisitorManagement As Boolean


End Interface ''End of "Public Interface InterfacePersonality"

