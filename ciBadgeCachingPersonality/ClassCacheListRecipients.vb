Option Explicit On
Option Strict On
Option Infer Off
''
''Added 2/10/2022 thomas downes
''
Imports ciBadgeInterfaces ''Added 9/16/2019 td 
Imports ciBadgeFields ''Added 9/18/2019 td
Imports ciBadgeRecipients ''Added 10/16/2019 thomas d. 

Namespace ciBadgeCachePersonality

    <Serializable>
    Public Class ClassCacheRecipients

        Public Shared Singleton As ClassElementsCache_Deprecated ''Let's use
        '' the pattern mentioned in https://en.wikipedia.org/wiki/Singleton_pattern
        Public Property Id_GUID As System.Guid ''Added 9/30/2019 td 
        Public Property Id_GUID6Char As String ''Added 12/12/2021 td 
        Public Property Id_GUID6_CopiedFrom As String ''Added 12/12/2021 td 

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
            ''Added 2/10/2022 &  11/29/2019 thomas downes
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



    End Class

End Namespace
