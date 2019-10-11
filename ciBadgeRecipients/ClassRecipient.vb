Option Explicit On
Option Strict On
Option Infer Off
''
''Added 10/1/2019 td  
''
Imports ciBadgeInterfaces
Imports System.Collections.Generic
Imports System.Drawing ''Added 10/11/2019 td

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

    Public Function GetPortraitImage() As System.Drawing.Image Implements IRecipient.GetPortraitImage
        ''
        ''Added 10/11/2019 td 
        ''




    End Function ''End of "Public Function GetPortraitImage() As System.Drawing.Image"

    Public Function GetTextValue(par_enum As EnumCIBFields) As String Implements IRecipient.GetTextValue
        ''
        ''Added 10/11/2019 td 
        ''
        Select Case par_enum

            ''Case EnumCIBFields.fstrAddress : Return Me.fstrAddress
            Case EnumCIBFields.fstrFirstName : Return Me.fstrFirstName
            Case EnumCIBFields.fstrID : Return Me.fstrID
            Case EnumCIBFields.fstrLastName : Return Me.fstrLastName
            Case EnumCIBFields.fstrMidName : Return Me.fstrMidName

            Case EnumCIBFields.DateField01 : Return Me.DateField01.ToShortDateString
            Case EnumCIBFields.DateField02 : Return Me.DateField01.ToShortDateString
            Case EnumCIBFields.DateField03 : Return Me.DateField01.ToShortDateString
            Case EnumCIBFields.DateField04 : Return Me.DateField01.ToShortDateString
            Case EnumCIBFields.DateField05 : Return Me.DateField01.ToShortDateString

            Case EnumCIBFields.TextField01 : Return Me.TextField01
            Case EnumCIBFields.TextField02 : Return Me.TextField02
            Case EnumCIBFields.TextField03 : Return Me.TextField03
            Case EnumCIBFields.TextField04 : Return Me.TextField04
            Case EnumCIBFields.TextField05 : Return Me.TextField05
            Case EnumCIBFields.TextField06 : Return Me.TextField06
            Case EnumCIBFields.TextField07 : Return Me.TextField07
            Case EnumCIBFields.TextField08 : Return Me.TextField08
            Case EnumCIBFields.TextField09 : Return Me.TextField09

            Case EnumCIBFields.TextField10 : Return Me.TextField10
            Case EnumCIBFields.TextField11 : Return Me.TextField11
            Case EnumCIBFields.TextField12 : Return Me.TextField12
            Case EnumCIBFields.TextField13 : Return Me.TextField13
            Case EnumCIBFields.TextField14 : Return Me.TextField14
            Case EnumCIBFields.TextField15 : Return Me.TextField15

            Case EnumCIBFields.fstrBarCode : Return Me.fstrBarCode
            Case EnumCIBFields.fstrRFID_Unique : Return Me.fstrRFID_Unique

            Case Else
                Return ""

        End Select ''End of "Select Case par_enum"

    End Function ''enD OF " Public Function GetTextValue(par_enum As EnumCIBFields) As String Implements IRecipient.GetTextValue"

    Public Function GetDateValue(par_enum As EnumCIBFields) As Date Implements IRecipient.GetDateValue
        ''Added 10/11/2019 td 

        Select Case par_enum

            Case EnumCIBFields.DateField01 : Return Me.DateField01 ''.ToShortDateString
            Case EnumCIBFields.DateField02 : Return Me.DateField02 ''.ToShortDateString
            Case EnumCIBFields.DateField03 : Return Me.DateField03 ''.ToShortDateString
            Case EnumCIBFields.DateField04 : Return Me.DateField04 ''.ToShortDateString
            Case EnumCIBFields.DateField05 : Return Me.DateField05 ''.ToShortDateString

            Case Else
                Return DateTime.MinValue

        End Select

    End Function

    Public Function RecipientID() As String Implements IRecipient.RecipientID
        ''Added 10/11/2019 td 

        Return fstrID

    End Function


    ''-------------------------------------------------------
    ''Standard fields 
    ''   ----10/11/2019 thomas d
    ''-------------------------------------------------------

    Property idsCardDataID As Integer Implements IRecipient.idsCardDataID
    Property idfConfigID As Integer Implements IRecipient.idfConfigID
    Property fstrLastName As String Implements IRecipient.fstrLastName
    Property fstrFirstName As String Implements IRecipient.fstrFirstName
    Property fstrMidName As String Implements IRecipient.fstrMidName
    Property fstrID As String Implements IRecipient.fstrID


    Property fstrBarcode As String Implements IRecipient.fstrBarcode
    Property fstrRFID_Unique As String Implements IRecipient.fstrRFID_Unique


    Property intTimesPrinted As Integer Implements IRecipient.intTimesPrinted

    ''-------------------------------------------------------
    ''Custom fields 
    ''   ----10/11/2019 thomas d
    ''-------------------------------------------------------
    Property DateField01 As DateTime Implements IRecipient.DateField01 ''   ----10/11/2019 thomas d
    Property DateField02 As DateTime Implements IRecipient.DateField02 ''   ----10/11/2019 thomas d
    Property DateField03 As DateTime Implements IRecipient.DateField03 ''   ----10/11/2019 thomas d
    Property DateField04 As DateTime Implements IRecipient.DateField04 ''   ----10/11/2019 thomas d
    Property DateField05 As DateTime Implements IRecipient.DateField05 ''   ----10/11/2019 thomas d


    Property TextField01 As String Implements IRecipient.TextField01 ''   ----10/11/2019 thomas d
    Property TextField02 As String Implements IRecipient.TextField02 ''   ----10/11/2019 thomas d
    Property TextField03 As String Implements IRecipient.TextField03
    Property TextField04 As String Implements IRecipient.TextField04
    Property TextField05 As String Implements IRecipient.TextField05
    Property TextField06 As String Implements IRecipient.TextField06
    Property TextField07 As String Implements IRecipient.TextField07
    Property TextField08 As String Implements IRecipient.TextField08
    Property TextField09 As String Implements IRecipient.TextField09
    Property TextField10 As String Implements IRecipient.TextField10
    Property TextField11 As String Implements IRecipient.TextField11
    Property TextField12 As String Implements IRecipient.TextField12
    Property TextField13 As String Implements IRecipient.TextField13
    Property TextField14 As String Implements IRecipient.TextField14
    Property TextField15 As String Implements IRecipient.TextField15


End Class
