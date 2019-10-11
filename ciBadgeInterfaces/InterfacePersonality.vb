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
    Property ConfigGUID As System.Guid ''Added 10/11/2019 td  

    Property ConfigID As Integer  '' 1 2 3 ... 99   This is essentially an index to easily distinguish among
    '' the personality configurations of a particular customer (who may have one, two, or several).  I am
    '' tempted to rename it to ConfigIndex, but I will stick with the legacy name of ConfigID. 
    ''  ----10/11/2019 TD 


    Property CustomerNumber As String ''E.g. CIS100.  Keep this, needed??   ---10/11/2019 td

    ''Probably not needed.  ---10/11/2019 td''Property CustomerName As String ''Keep this, needed??

    Property Name_PersonalityDescription As String ''E.g. Westboro High School Students, or perhaps just "Students" if feeling really lazy.  

    Property Name_ReferringToThem As String ''E.g. Students, Staff, Teachers, Police Officers, Members, etc. 

    ''Oops, this are at the Customer-level. ---10/11/2019 td''Property IncludeVisitorManagement As Boolean
    ''Oops, this are at the Customer-level. ---10/11/2019 td''Property OnlyVisitorManagement As Boolean

    Property IsVisitorManagement As Boolean ''Added 10/11/2019 td

End Interface ''End of "Public Interface InterfacePersonality"

