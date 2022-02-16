''-----Public Class ClassElementsCache_Bifurcated
Option Explicit On
Option Strict On
Option Infer Off
''
''Added 1/13/2022 thomas downes
''
Imports System.Drawing ''Added 9/18/2019 td
Imports System.Windows.Forms ''Added 9/18/2019 td
Imports ciBadgeInterfaces ''Added 9/16/2019 td 
Imports ciBadgeFields ''Added 9/18/2019 td
Imports ciBadgeRecipients ''Added 10/16/2019 thomas d. 
Imports ciBadgeElements ''Added 12/4/2021 thomas downes  

Namespace ciBadgeCachePersonality

    <Serializable>
    Public Class ClassElementsCacheV2_Bifurcated
        ''
        ''Added 1/13/2022 thomas downes
        ''
        Public Property Id_GUID As System.Guid
        Public Property Id_GUID6 As String
        Public Property Id_GUID6_CopiedFrom As String

        Public Property PathToXml_Saved As String
        Public Property PathToXml_Opened As String
        Public Property PathToXml_Binary As String

        Public Property Personality As ClassPersonalityConfig

        ''Moved below.''Public Property BadgeLayout As ciBadgeInterfaces.BadgeLayoutClass

        <Xml.Serialization.XmlIgnore>
        Public Property Pic_InitialDefault As Image

        Public Property DateAndTimeUpdated As DateTime

        ''
        ''Encapsulated 1/13/2022 thomas downes
        ''
        ''   This is where the Fields are stored.  
        ''
        Public Property Fields As ClassFieldCache

        ''
        ''Added 1/13/2022 Thomas Downes
        ''
        ''  Here is the sole reason for this new Cache (ClassElementsCacheV2_Bifurcated). 
        ''
        ''This list will have 1 or 2 items, representing the Front & possible Backside
        ''  of the ID Card Badge.   ----1/13/2022 td
        ''
        ''  Here is the sole reason for this new Cache (ClassElementsCacheV2_Bifurcated).  I feel
        ''    that this List of BadgeSideLayoutV2, having one or two items (one or two sides 
        ''    of the badge), can greatly simplify the cache (ClassElementsCacheV1_Deprectated).
        ''       ----1/13/2022 td
        ''
        Private mod_listBadgeSideLayoutV2s As New HashSet(Of ClassBadgeSideLayoutV2)
        Public Property BadgeLayout As ciBadgeInterfaces.BadgeLayoutClass
        Public Property BadgeHasTwoSidesOfCard As Boolean

        ''
        ''Added 1/13/2022 Thomas Downes
        ''
        ''  Here is the sole reason for this new Cache (ClassElementsCacheV2_Bifurcated).  I feel
        ''    that this List of BadgeSideLayoutV2, having one or two items (one or two sides 
        ''    of the badge), can greatly simplify the cache (ClassElementsCacheV1_Deprectated).
        ''       ----1/13/2022 td
        ''
        Public Property ListOfBadgeSideLayoutV2s As HashSet(Of ClassBadgeSideLayoutV2)
            ''
            ''This list will have 1 or 2 items, representing the Front & possible Backside
            ''  of the ID Card Badge.   ----1/13/2022 td
            ''
            Get
                ''Added 1/13/2022 td
                Return mod_listBadgeSideLayoutV2s
            End Get
            Set(value As HashSet(Of ClassBadgeSideLayoutV2))
                ''Added 1/13/2022 td
                mod_listBadgeSideLayoutV2s = value
            End Set
        End Property


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