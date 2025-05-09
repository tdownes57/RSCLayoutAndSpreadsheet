﻿Option Explicit On
Option Strict On
Option Infer Off
''
''Added 3/14/2022 thomas downes
''
''Imports ciBadgeInterfaces ''Added 9/16/2019 td 
''Imports ciBadgeFields ''Added 9/18/2019 td
Imports ciBadgeRecipients ''Added 10/16/2019 thomas d. 



<Serializable>
Public Class ClassColumnWidthsEtc_NotInUse
    ''
    ''Added 3/14/2022 thomas downes
    ''Copy-pasted from ClassCacheListRecipients, 3/14/2022 t//d//
    ''
    '' This will hold Column Widths, Column Order, Column Fields, and Column Data. 
    ''
    ''
    ''10/10/2019 td''Public Property SaveToXmlPath As String ''Added 9/29/2019 td
    Public Property PathToXml_Saved As String ''Added 9/29/2019 td
    Public Property PathToXml_Opened As String ''Added 12/14/2021 td
    Public Property PathToXml_Binary As String ''Added 11/29/2019 td

    Public Property PersonalityId_GUID As System.Guid ''Added 12/14/2021 thomas
    Public Property PersonalityId_GUID6Char As String ''Added 12/14/2021 thomas

    Public Property DateAndTimeUpdated As DateTime ''Added 11/29/2021 thomas d. 

    Private mod_listRecipients As New HashSet(Of ClassRecipient) ''Added 10/14/2019 td  


    Public Property ListOfRecipients As List(Of ClassRecipient)


    Public Sub SaveToXML(Optional ByVal pstrPathToXML As String = "")
        ''
        ''Added 3/14/2022 thomas downes
        ''Copy-pasted from ClassCacheListRecipients, 3/14/2022 t//d//
        ''
        ''
        ''Added 2/10/2022 &  11/29/2019 thomas downes        
        ''

        ''
        ''This code was copied from ClassElementsCacheV1_Deprecated.
        ''
        Dim objSerializationClass As New ciBadgeSerialize.ClassSerial

        With objSerializationClass

            ''10/13/2019 td''.PathToXML = Me.ElementsCache_Saved.PathToXml_Saved
            .PathToXML = Me.PathToXml_Saved
            .PathToXML_Binary = Me.PathToXml_Binary ''Added 11/29/2019 thomas d. 

            ''Added 12/14/2021 td 
            If (pstrPathToXML <> "") Then .PathToXML = pstrPathToXML

            ''Added 9/24/2019 thomas 
            ''  ''11/29/2019 td''.SerializeToXML(Me.GetType, Me, False, True)

            Dim boolSerializeToBinary As Boolean = False ''Added 9/30/2019 td

            boolSerializeToBinary = ciBadgeSerialize.ClassSerial.UseBinaryFormat

            If (boolSerializeToBinary) Then
                .SerializeToBinary(Me.GetType, Me)
            Else
                ''//---4/22/2020 td //.SerializeToXML(Me.GetType, Me, False, True)
                Const c_boolAutoOpenByIE As Boolean = False ''Added 4/22/2020 thomas d.
                ''//
                ''// If the 2nd Boolean Is True, the following command
                ''//         System.Diagnostics.Process.Start(Me.PathToXML)
                ''//  will be used to open the file in Notepad.
                ''//     ---4/22/2020 thomas downes
                ''//
                .SerializeToXML(Me.GetType, Me, False, c_boolAutoOpenByIE)

            End If ''End of "If (boolSerializeToBinary) Then ... Else"

        End With ''End of "With objSerializationClass"

    End Sub ''End of "Public Sub SaveToXML()"


    Public Shared Function GetCache(pstrPathToXML As String) As ClassColumnWidthsEtc_NotInUse ''As ClassCacheListRecipients
        ''
        ''Added 3/14/2022 thomas downes
        ''
        ''Copy-pasted from ClassCacheListRecipients, 3/14/2022 t//d//
        ''
        ''
        ''Copied & adapted 2/15/2022 from Startup.vb's Public Shared Function LoadCachedData_Elements_Deprecated
        ''
        ''Added 10/10/2019 td  
        Dim objDeserialize As New ciBadgeSerialize.ClassDeserial ''Added 10/10/2019 td  
        ''March14 2922 td'' Dim obj_cache_customers As ClassCacheListRecipients
        Dim obj_cache_columns As ClassColumnWidthsEtc_NotInUse ''3/13/2022 ''As ClassCacheListRecipients

        objDeserialize.PathToXML = pstrPathToXML

        ''10/13/2019 td''Me.ElementsCache_Saved = CType(objDeserialize.DeserializeFromXML(Me.ElementsCache_Saved.GetType(), False), ClassElementsCache)
        ''-----Me.ElementsCache_Edits = CType(objDeserialize.DeserializeFromXML(Me.ElementsCache_Edits.GetType(), False), ClassElementsCache)

        obj_cache_columns = New ClassColumnWidthsEtc_NotInUse ''3/13/2022 ''ClassCacheListRecipients ''This may or may not be completely necessary,
        ''   but I know of no other way to pass the object type.  Simply expressing the Type
        ''   by typing its name doesn't work.  ---10/13/2019 td

        ''March14 2022 td''obj_cache_columns = CType(objDeserialize.DeserializeFromXML(obj_cache_customers.GetType(), False), ClassCacheListRecipients)
        obj_cache_columns = CType(objDeserialize.DeserializeFromXML(obj_cache_columns.GetType(), False),
            ClassColumnWidthsEtc_NotInUse)

        Return obj_cache_columns

    End Function ''End of "Public Shared Function GetCache"



End Class ''ENd of Public Class ClassCacheListRecipients



