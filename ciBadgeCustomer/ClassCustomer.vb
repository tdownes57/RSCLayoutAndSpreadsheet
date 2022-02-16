Option Explicit On
Option Strict On
''
''Added 10/11/2019 td  
''
Imports ciBadgeInterfaces ''Added 2/15/2022 thhomas downes  

Public Class ClassCustomer
    Implements ciBadgeInterfaces.InterfaceCustomer

    Public Property CustomerGUID As Guid Implements InterfaceCustomer.CustomerGUID

    Public Property CustomerGUID6char As String Implements InterfaceCustomer.CustomerGUID6char
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As Guid)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property AlphanumericCode As String Implements InterfaceCustomer.AlphanumericCode
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As String)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property NameFull As String Implements InterfaceCustomer.NameFull
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As String)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property NameShort As String Implements InterfaceCustomer.NameShort
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As String)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property Description As String Implements InterfaceCustomer.Description
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As String)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property PathToFilesFolder As String Implements InterfaceCustomer.PathToFilesFolder
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As String)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property IncludeVisitorManagement As Boolean Implements InterfaceCustomer.IncludeVisitorManagement
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As Boolean)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property OnlyVisitorManagement As Boolean Implements InterfaceCustomer.OnlyVisitorManagement
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As Boolean)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property
    ''
    ''Added 10/11/2019 td  
    ''



End Class
