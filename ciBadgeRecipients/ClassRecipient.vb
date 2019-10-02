Option Explicit On
Option Strict On
Option Infer Off
''
''Added 10/1/2019 td  
''
Imports ciBadgeInterfaces
Imports System.Collections.Generic

Public Class ClassRecipient
    Implements IRecipient
    ''
    ''Added 10/1/2019 td  
    ''
    ''        //
    ''        //Recipient = Student Or Employee receiving the Badge. 
    ''        //
    ''        Public Static IList<Models.CIRecipient> mod_recipientList = New List<Models.CIRecipient>() {
    ''                    New Models.CIRecipient(){ CustomerID="CIS100", ConfigID=1, RecipientID ="1", FirstName="Johnny", LastName = "Davidson", Picture = PictureExamples.GetExample()  },
    ''                    New Models.CIRecipient(){ CustomerID="CIS100", ConfigID=1, RecipientID ="2", FirstName="Stevie", LastName = "Austin", Picture = PictureExamples.GetExample() },
    ''
    Public Shared mod_recipientList As IList(Of ClassRecipient) = New List(Of ClassRecipient) ''{New ClassRecipient() }


    Public Property ID_Guid As System.Guid

    Public Property Customer_Guid As System.Guid

    Public Property Personality_Guid As System.Guid








End Class
