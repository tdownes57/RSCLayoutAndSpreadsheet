''
''Added 10/11/2019 td  
''
Imports ciBadgeInterfaces ''Added 10/11/2019 td  

Public Class ClassPersonalityConfig
    Implements ciBadgeInterfaces.InterfacePersonality
    ''
    ''Added 10/11/2019 td  
    ''
    Public Property ConfigGUID As System.Guid Implements InterfacePersonality.ConfigGUID
    Public Property CustomerNumber As String Implements InterfacePersonality.CustomerNumber

    Public Property Name_ReferringToThem As String Implements InterfacePersonality.Name_ReferringToThem

    Public Property Name_PersonalityDescription As String Implements InterfacePersonality.Name_PersonalityDescription


    Public Property ConfigID As Integer Implements InterfacePersonality.ConfigID

    Public Property IsVisitorManagement As Boolean Implements InterfacePersonality.IsVisitorManagement





End Class ''ENd of "Public Class ClassPersonalityConfig"
