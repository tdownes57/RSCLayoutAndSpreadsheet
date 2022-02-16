Option Explicit On
Option Strict On
Option Infer Off

''
''Added 2/10/2022 thomas downes
''
Imports ciBadgeInterfaces ''Added 9/16/2019 td 
Imports ciBadgeFields ''Added 9/18/2019 td
Imports ciBadgeCustomer ''Added 2/16/2022 thomas d. 

Namespace ciBadgeCachePersonality
    ''
    ''Added 2/16/2022 td
    ''

    <Serializable>
    Public Class ClassCacheListCustomers
        ''
        ''Added 2/16/2022 td
        ''
        Public Shared Singleton As ClassCacheListCustomers ''Let's use
        '' the pattern mentioned in https://en.wikipedia.org/wiki/Singleton_pattern
        Public Property Id_GUID As System.Guid ''Added 9/30/2019 td 
        Public Property Id_GUID6Char As String ''Added 12/12/2021 td 
        Public Property Id_GUID6_CopiedFrom As String ''Added 12/12/2021 td 

        ''10/10/2019 td''Public Property SaveToXmlPath As String ''Added 9/29/2019 td
        Public Property PathToXml_Saved As String ''Added 9/29/2019 td
        Public Property PathToXml_Opened As String ''Added 12/14/2021 td
        Public Property PathToXml_Binary As String ''Added 11/29/2019 td

        ''Public Property PersonalityId_GUID As System.Guid ''Added 12/14/2021 thomas
        ''Public Property PersonalityId_GUID6Char As String ''Added 12/14/2021 thomas

        Public Property DateAndTimeUpdated As DateTime ''Added 11/29/2021 thomas d. 

        Private mod_listCustomers As New HashSet(Of ciBadgeCustomer.ClassCustomer) ''Added 10/14/2019 td  


        Public Property ListOfCustomers As HashSet(Of ClassCustomer)


        Public Sub SaveToXML(Optional ByVal pstrPathToXML As String = "")
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


        Public Shared Function GetCache(pstrPathToXML As String) As ClassCacheListCustomers
            ''
            ''Copied & adapted 2/15/2022 from Startup.vb's Public Shared Function LoadCachedData_Elements_Deprecated
            ''
            ''Added 10/10/2019 td  
            Dim objDeserialize As New ciBadgeSerialize.ClassDeserial ''Added 10/10/2019 td  
            Dim obj_cache_customers As ClassCacheListCustomers

            objDeserialize.PathToXML = pstrPathToXML

            ''10/13/2019 td''Me.ElementsCache_Saved = CType(objDeserialize.DeserializeFromXML(Me.ElementsCache_Saved.GetType(), False), ClassElementsCache)
            ''-----Me.ElementsCache_Edits = CType(objDeserialize.DeserializeFromXML(Me.ElementsCache_Edits.GetType(), False), ClassElementsCache)

            obj_cache_customers = New ClassCacheListCustomers ''This may or may not be completely necessary,
            ''   but I know of no other way to pass the object type.  Simply expressing the Type
            ''   by typing its name doesn't work.  ---10/13/2019 td

            obj_cache_customers = CType(objDeserialize.DeserializeFromXML(obj_cache_customers.GetType(), False), ClassCacheListCustomers)

            Return obj_cache_customers

        End Function ''End of "Public Shared Function GetCache"


    End Class ''End of "Public Class ClassCacheListCustomers"

End Namespace

