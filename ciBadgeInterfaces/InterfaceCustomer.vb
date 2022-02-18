''
''Added 7/31/2019 td  
''

Public Interface InterfaceCustomer
    ''
    ''Added 7/31/2019 td  
    ''
    Property CustomerGUID As System.Guid ''Added 10/11/2019 td  
    Property CustomerGUID6char As String ''Added 02/15/2022 td  

    Property AlphanumericCode As String
    Property NameFull As String
    Property NameShort As String

    Property Description As String

    Property PathToFilesFolder As String

    Property IncludeVisitorManagement As Boolean  ''Added 10/11/2019 td 
    Property OnlyVisitorManagement As Boolean  ''Added 10/11/2019 td 

    Property Deactivated As Boolean ''Is the customer no longer viable?  2/17/2022 thomas downes

End Interface
