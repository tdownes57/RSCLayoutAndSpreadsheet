''
''Added 10/14/2019 thomas d. 
''
Imports ciBadgeCustomer ''Added 12/13/2021 td

Namespace ciBadgeCachePersonality
    Public Class ClassCacheOneCustomersConfigs
        ''
        ''Renamed 2/15/2022 from Public Class ClassCustomerCache 
        ''

        Public Property Customer As ciBadgeCustomer.ClassCustomer ''Added 12/13/2021 td 

        Public Property ListPersonalities As List(Of ClassPersonalityConfig) ''Added 12/13/2021 td

        Public Property PathToXml_Saved As String ''Added 2/15/2022 td
        Public Property PathToXml_Binary As String ''Added 2/15/2022 td


        Public Sub SaveToXML(Optional ByVal pstrPathToXML As String = "")
            ''
            ''Added 2/15/2022 & 11/29/2019 thomas downes
            ''
            ''This code was copied from ClassElementsCacheV1_Deprecated.vb, Public Sub SaveToXML(), on 02/15/2022 td
            ''
            Dim objSerializationClass As New ciBadgeSerialize.ClassSerial
            Dim boolSerializeToBinary As Boolean = False ''Added 9/30/2019 td

            With objSerializationClass

                .PathToXML = Me.PathToXml_Saved
                .PathToXML_Binary = Me.PathToXml_Binary ''Added 11/29/2019 thomas d. 

                If (pstrPathToXML <> "") Then .PathToXML = pstrPathToXML

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


        Public Shared Function GetCache(pstrPathToXML As String) As ClassElementsCacheV2_Bifurcated
            ''
            ''Copied & adapted 2/15/2022 from Startup.vb's Public Shared Function LoadCachedData_Elements_Deprecated
            ''
            ''Added 10/10/2019 td  
            Dim objDeserialize As New ciBadgeSerialize.ClassDeserial ''Added 10/10/2019 td  
            Dim obj_cache_elements As ClassElementsCacheV2_Bifurcated

            objDeserialize.PathToXML = pstrPathToXML

            ''10/13/2019 td''Me.ElementsCache_Saved = CType(objDeserialize.DeserializeFromXML(Me.ElementsCache_Saved.GetType(), False), ClassElementsCache)
            ''-----Me.ElementsCache_Edits = CType(objDeserialize.DeserializeFromXML(Me.ElementsCache_Edits.GetType(), False), ClassElementsCache)

            obj_cache_elements = New ClassElementsCacheV2_Bifurcated ''This may or may not be completely necessary,
            ''   but I know of no other way to pass the object type.  Simply expressing the Type
            ''   by typing its name doesn't work.  ---10/13/2019 td

            obj_cache_elements = CType(objDeserialize.DeserializeFromXML(obj_cache_elements.GetType(), False), ClassElementsCacheV2_Bifurcated)

            Return obj_cache_elements

        End Function ''End of "Public Shared Function GetCache"




    End Class

End Namespace
