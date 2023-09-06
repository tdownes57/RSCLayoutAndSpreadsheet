Option Explicit On
Option Strict On
Option Infer Off
''
''Added 10/1/2019 td  
''
Imports ciBadgeInterfaces
Imports ciBadgeFields ''Added 5/20/2022 td
Imports System.Collections.Generic
Imports System.Drawing ''Added 10/11/2019 td
Imports __RSC_Portrait_Pictures ''Added 5/20/2022 thomas downes

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

    Public Sub New()
        ''
        ''Added 6/28/2022 td 
        ''
        PopulateGuid_IfNeeded()

    End Sub ''End of ""Public Sub New()""

    Property PortraitPicture As Image Implements IRecipient.PortraitPicture ''Added 10/16/2019 thomas d.  
    Property BadgeImage As Image Implements IRecipient.BadgeImage ''Added 9/29/2021 thomas d.  

    Public Property ID_Guid As System.Guid
    Public Property ID_Guid6chars As String

    Public Property Customer_Guid As System.Guid
    Public Property CustomerCode As System.String ''Added 10/16/2019 td  

    Public Property Personality_Guid As System.Guid


    Public Function GetPortraitImage() _
        As System.Drawing.Image Implements IRecipient.GetPortraitImage
        ''
        ''Added 10/11/2019 td 
        ''
        Dim strBasicIDValue As String = ""
        Dim strPortraitID As String = ""
        Dim strLastName As String = ""
        Dim strFirstName As String = ""
        Dim strFinalIDValue As String = ""

        strPortraitID = GetTextValue(EnumCIBFields.PortraitPhotoID)
        strBasicIDValue = GetTextValue(EnumCIBFields.fstrID)
        strLastName = GetTextValue(EnumCIBFields.fstrLastName)
        strFirstName = GetTextValue(EnumCIBFields.fstrFirstName)

        If (strFinalIDValue = "") Then If (strPortraitID <> "") Then strFinalIDValue = strPortraitID
        If (strFinalIDValue = "") Then If (strBasicIDValue <> "") Then strFinalIDValue = strBasicIDValue
        If (strFinalIDValue = "") Then If (strLastName <> "") Then strFinalIDValue = strLastName
        If (strFinalIDValue = "") Then If (strFirstName <> "") Then strFinalIDValue = strFirstName

        ''
        ''Step 4 of 4.  Get the portrait image.  
        ''
        Return PortraitClass.GetPortraitImageByID(strFinalIDValue)

    End Function ''End of ""Public Function GetPortraitImage()""

    Public Function GetPortraitImage(par_enumFieldForPicFile As EnumCIBFields,
        Optional par_dictionaryFields As Dictionary(Of EnumCIBFields, ClassFieldAny) = Nothing) _
        As System.Drawing.Image ''5/20/2022 Implements IRecipient.GetPortraitImage
        ''
        ''Added 5/20/2022 td 
        ''
        ''
        ''Step 1 of 4. See if there is already a Portrait Picture image.   
        ''
        If (Me.PortraitPicture IsNot Nothing) Then
            Return Me.PortraitPicture
        End If ''End of ""If (Me.PortraitPicture IsNot Nothing) Then""

        ''Added 5/20/2022 thomas downes 
        Dim enumFieldForPullingPhotoFile As EnumCIBFields
        Dim fieldBasicID As ClassFieldAny
        Dim fieldPortraitID As ClassFieldAny

        ''
        ''Step 2 of 4. Check which field contains identifying information.  
        ''
        enumFieldForPullingPhotoFile = par_enumFieldForPicFile
        If (par_enumFieldForPicFile = EnumCIBFields.Undetermined) Then

            fieldBasicID = par_dictionaryFields.Item(EnumCIBFields.fstrID)
            fieldPortraitID = par_dictionaryFields.Item(EnumCIBFields.PortraitPhotoID)

            Select Case True

                Case (fieldPortraitID.IsRelevantToPersonality)

                    par_enumFieldForPicFile = EnumCIBFields.PortraitPhotoID

                Case (fieldBasicID.IsRelevantToPersonality)

                    par_enumFieldForPicFile = EnumCIBFields.fstrID

            End Select ''End of ""Select Case True""

        End If ''End of ""If (par_enumFieldForPicFile = EnumCIBFields.Undetermined) Then""

        ''
        ''Step 3 of 4.  Get the identifying value.  
        ''
        Dim strIDValue As String
        strIDValue = GetTextValue(par_enumFieldForPicFile)

        ''
        ''Step 4 of 4.  Get the portrait image.  
        ''
        Return PortraitClass.GetPortraitImageByID(strIDValue)


    End Function ''End of "Public Function GetPortraitImage() As System.Drawing.Image"

    Public Function GetTextValue(par_enum As EnumCIBFields) As String Implements IRecipient.GetTextValue
        ''
        ''Added 10/11/2019 td 
        ''
        Select Case par_enum

            ''Added 7/12/2022 thomas downes
            Case EnumCIBFields.Undetermined : Return "" ''Added 7/12/2022 

            ''Case EnumCIBFields.fstrAddress : Return Me.fstrAddress
            Case EnumCIBFields.fstrFirstName : Return Me.fstrFirstName
            Case EnumCIBFields.fstrID : Return Me.fstrID
            Case EnumCIBFields.fstrLastName : Return Me.fstrLastName
            Case EnumCIBFields.fstrMidName : Return Me.fstrMidName

            ''Added 3/30/2022 td
            Case EnumCIBFields.fstrNameAbbreviated : Return Me.fstrNameAbbreviated
            Case EnumCIBFields.fstrFullName : Return Me.fstrFullName

            ''4/2022 Case EnumCIBFields.DateField01 : Return Me.DateField01.ToShortDateString
            ''4/2022 Case EnumCIBFields.DateField02 : Return Me.DateField01.ToShortDateString
            ''4/2022 Case EnumCIBFields.DateField03 : Return Me.DateField01.ToShortDateString
            ''4/2022 Case EnumCIBFields.DateField04 : Return Me.DateField01.ToShortDateString
            ''4/2022 Case EnumCIBFields.DateField05 : Return Me.DateField01.ToShortDateString

            Case EnumCIBFields.DateField01 : Return Me.DateField01.ToShortDateString
            Case EnumCIBFields.DateField02 : Return Me.DateField02.ToShortDateString
            Case EnumCIBFields.DateField03 : Return Me.DateField03.ToShortDateString
            Case EnumCIBFields.DateField04 : Return Me.DateField04.ToShortDateString
            Case EnumCIBFields.DateField05 : Return Me.DateField05.ToShortDateString

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

            ''Added 11/25/2021 Thomas Downes 
            Case EnumCIBFields.fstrFullName : Return Me.fstrFullName

                ''Added 12/7/2021 Thomas Downes 
            Case EnumCIBFields.fstrAddress : Return Me.fstrAddress
            Case EnumCIBFields.fstrCity : Return Me.fstrCity
            Case EnumCIBFields.fstrState : Return Me.fstrState
            Case EnumCIBFields.fstrZip : Return Me.fstrZip

            Case EnumCIBFields.blnBatchPrint : Return "blnBatchPrint" ''False.ToString()

            Case Else
                ''#1 12/7/2021 td''Return ""
                ''#2 12/7/2021 td''Return "This Case Else."
                Throw New Exception("This Case Else should not be the case.... par_enum = " & par_enum.ToString)

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

    End Function ''end of ""Public Function GetDateValue""



    Public Sub SaveTextValue(par_enum As EnumCIBFields, par_value As String,
                             Optional ByRef pref_failure As Boolean = False) _
                             Implements IRecipient.SaveTextValue
        ''
        ''Added 4/12/2022 td 
        ''
        Select Case par_enum

            Case EnumCIBFields.fstrFirstName : Me.fstrFirstName = par_value
            Case EnumCIBFields.fstrID : Me.fstrID = par_value
            Case EnumCIBFields.fstrLastName : Me.fstrLastName = par_value
            Case EnumCIBFields.fstrMidName : Me.fstrMidName = par_value

            Case EnumCIBFields.fstrNameAbbreviated : Me.fstrNameAbbreviated = par_value
            Case EnumCIBFields.fstrFullName : Me.fstrFullName = par_value

            Case EnumCIBFields.DateField01 : Me.DateField01 = CDate(par_value)
            Case EnumCIBFields.DateField02 : Me.DateField02 = CDate(par_value)
            Case EnumCIBFields.DateField03 : Me.DateField03 = CDate(par_value)
            Case EnumCIBFields.DateField04 : Me.DateField04 = CDate(par_value)
            Case EnumCIBFields.DateField05 : Me.DateField05 = CDate(par_value)

            Case EnumCIBFields.TextField01 : Me.TextField01 = par_value
            Case EnumCIBFields.TextField02 : Me.TextField02 = par_value
            Case EnumCIBFields.TextField03 : Me.TextField03 = par_value
            Case EnumCIBFields.TextField04 : Me.TextField04 = par_value
            Case EnumCIBFields.TextField05 : Me.TextField05 = par_value
            Case EnumCIBFields.TextField06 : Me.TextField06 = par_value
            Case EnumCIBFields.TextField07 : Me.TextField07 = par_value
            Case EnumCIBFields.TextField08 : Me.TextField08 = par_value
            Case EnumCIBFields.TextField09 : Me.TextField09 = par_value

            Case EnumCIBFields.TextField10 : Me.TextField10 = par_value
            Case EnumCIBFields.TextField11 : Me.TextField11 = par_value
            Case EnumCIBFields.TextField12 : Me.TextField12 = par_value
            Case EnumCIBFields.TextField13 : Me.TextField13 = par_value
            Case EnumCIBFields.TextField14 : Me.TextField14 = par_value
            Case EnumCIBFields.TextField15 : Me.TextField15 = par_value

            Case EnumCIBFields.fstrBarCode : Me.fstrBarcode = par_value
            Case EnumCIBFields.fstrRFID_Unique : Me.fstrRFID_Unique = par_value

            ''Added 11/25/2021 Thomas Downes 
            Case EnumCIBFields.fstrFullName : Me.fstrFullName = par_value

                ''Added 12/7/2021 Thomas Downes 
            Case EnumCIBFields.fstrAddress : Me.fstrAddress = par_value
            Case EnumCIBFields.fstrCity : Me.fstrCity = par_value
            Case EnumCIBFields.fstrState : Me.fstrState = par_value
            Case EnumCIBFields.fstrZip : Me.fstrZip = par_value

            Case EnumCIBFields.blnBatchPrint
                ''
                ''
                ''

            Case Else
                ''#1 12/7/2021 td''Return ""
                ''#2 12/7/2021 td''Return "This Case Else."
                If ("" = par_value) Then
                    ''The value is blank.  It is probably from a column which is entirely blank, 
                    ''   without a selected field and without recipient values. ----5/25/2022
                Else
                    ''--5/23/2022--Throw New Exception("This Case Else should not be the case.... par_enum = " & par_enum.ToString)
                    pref_failure = True ''Added 5/25/2022

                End If ''End of ""If ("" = par_value) Then... Else..."

        End Select ''End of "Select Case par_enum"

    End Sub ''enD OF " Public Sub SaveTextValue(par_enum As EnumCIBFields) As String Implements IRecipient.GetTextValue"


    Public Function RecipientID() As String Implements IRecipient.RecipientID
        ''Added 10/11/2019 td 

        Return fstrID

    End Function ''ENd of ""Public Function RecipientID() As String""


    Public Function EqualsRecipient(par_recip As ClassRecipient,
                            par_listFieldEnums As List(Of EnumCIBFields),
                            Optional ByRef pref_singMatchPercent As Single = 0) As Boolean
        ''3/18/2023 td  Public Function EqualsRecipient(par_recip As ClassRecipient,
        ''
        ''Added 6/28/2022 thomas downes
        ''
        Const c_bStopIfMismatch As Boolean = False
        Dim each_enum As EnumCIBFields
        Dim each_value_Me As String
        Dim each_value_ParRecip As String
        Dim each_bMatches As Boolean
        Dim bMatches_aggregate As Boolean
        Dim intCountFieldMatches As Integer
        ''Unused. 3/2023 Dim intCountFieldUnmatch As Integer
        Dim intCountFieldsChecked As Integer

        For Each each_enum In par_listFieldEnums
            ''
            ''Check each field in the list.  
            ''
            each_value_Me = Me.GetTextValue(each_enum)
            each_value_ParRecip = par_recip.GetTextValue(each_enum)
            each_bMatches = (each_value_ParRecip.Equals(each_value_Me))
            intCountFieldsChecked += 1

            ''
            ''Conditional branching 
            ''
            If (each_bMatches) Then
                ''Catalog the accumulated results. 
                bMatches_aggregate = (bMatches_aggregate And each_bMatches)
                intCountFieldMatches += 1
            Else
                System.Diagnostics.Debugger.Break()
                bMatches_aggregate = False
                intCountFieldMatches += 1
                If (c_bStopIfMismatch) Then Exit For
            End If ''End of ""If (Not each_matches) Then""

        Next each_enum

ExitHandler:
        If (intCountFieldsChecked = 0) Then intCountFieldsChecked = 1
        pref_singMatchPercent = CSng(intCountFieldMatches / intCountFieldsChecked)
        Return bMatches_aggregate

    End Function ''End of ""Public Function Equals""








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

    ''Added 11/25/2021 thomas
    Property fstrFullName As String Implements IRecipient.fstrFullName

    ''Added 2/15/2022 thomas
    Property fstrNameAbbreviated As String Implements IRecipient.fstrNameAbbreviated
    Property fstrEmailAddress As String Implements IRecipient.fstrEmailAddress

    Property fstrBarcode As String Implements IRecipient.fstrBarcode
    Property fstrRFID_Unique As String Implements IRecipient.fstrRFID_Unique

    ''Added 5/20/2022 thomas d.
    Property PortraitPhotoID As String Implements IRecipient.PortraitPhotoID ''Added 5/20/2022 thomas d.


    Property fstrAddress As String Implements IRecipient.fstrAddress ''Added 12/7/2021 td 
    Property fstrCity As String Implements IRecipient.fstrCity ''Added 12/6/2021 td 
    Property fstrState As String Implements IRecipient.fstrState ''Added 12/7/2021 td 
    Property fstrZip As String Implements IRecipient.fstrZip ''Added 12/7/2021 td 

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


    Public Function IsEmpty() As Boolean
        ''
        ''Added 9/5/2023  
        ''
        Dim boolfstrEmpty As Boolean
        Dim bCustomTextEmpty As Boolean

        boolfstrEmpty = ((fstrAddress.TrimEnd() = "") And
          (fstrBarcode.TrimEnd() = "") And
          (fstrCity.TrimEnd() = "") And
          (fstrEmailAddress.TrimEnd() = "") And
          (fstrFirstName.TrimEnd() = "") And
          (fstrFullName.TrimEnd() = "") And
          (fstrID.TrimEnd() = "") And
          (fstrLastName.TrimEnd() = "") And
          (fstrMidName.TrimEnd() = "") And
          (fstrNameAbbreviated.TrimEnd() = "") And
          (fstrRFID_Unique.TrimEnd() = "") And
          (fstrState.TrimEnd() = "") And
          (fstrZip.TrimEnd() = ""))

        bCustomTextEmpty = ((TextField01.TrimEnd() = "") And
            (TextField01.TrimEnd() = "") And
            (TextField02.TrimEnd() = "") And
            (TextField03.TrimEnd() = "") And
            (TextField04.TrimEnd() = "") And
            (TextField05.TrimEnd() = "") And
            (TextField06.TrimEnd() = "") And
            (TextField07.TrimEnd() = "") And
            (TextField08.TrimEnd() = "") And
            (TextField09.TrimEnd() = "") And
            (TextField10.TrimEnd() = "") And
            (TextField11.TrimEnd() = "") And
            (TextField12.TrimEnd() = "") And
            (TextField13.TrimEnd() = "") And
            (TextField14.TrimEnd() = "") And
            (TextField15.TrimEnd() = ""))

        Return (boolfstrEmpty And bCustomTextEmpty)

    End Function ''End of ""Public Function IsEmpty()""


    Public Sub PopulateGuid_IfNeeded()
        ''
        ''Added 6/28/2022 thomas downes
        ''
        If (ID_Guid = Guid.Empty) Then

            ID_Guid = Guid.NewGuid()

        End If ''End of ""If (ID_Guid = Guid.Empty) Then""

        ''
        ''Populate the 6-character version. 
        ''
        If (True) Then ''In any case, we ought to refresh property var. ID_Guid6chars.
            ID_Guid6chars = ID_Guid.ToString().Substring(0, 6)
        End If ''End of ""If (True) Then""

    End Sub ''End of "" Public Sub PopulateGuid_IfNeeded()"" 


End Class
