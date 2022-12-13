Imports __RSCElementSelectGraphics
Imports ciBadgeCachePersonality
Imports ciBadgeSerialize ''Added 11/22/2022 

''Public Structure Line
''    ''
''    ''Added 11/22/2022
''    ''
''    Public point1 As Point
''    Public point2 As Point
''End Structure


''Public Structure Triangle
''    ''
''    ''Added 11/22/2022
''    ''
''    Public line1 As Line
''    Public line2 As Line
''    Public line3 As Line
''End Structure

''Public Structure Arrow
''    ''
''    ''Added 11/22/2022
''    ''
''    Public NameOfArrow As String
''    Public triangle1 As Triangle
''    Public triangle2 As Triangle

''End Structure

<Serializable>
Public Class ClassListOfArrows
    ''
    ''Added 11/22/2025 
    ''
    ''---Public NamedArrows As New List(Of Arrow)
    Private mod_listArrows As New List(Of ArrowTriangleStructure)

    Public ReadOnly Property List() As List(Of ArrowTriangleStructure)
        Get
            Return mod_listArrows
        End Get
    End Property



    Public Sub Add(par_arrow As ArrowTriangleStructure)
        ''
        ''Added 11/26/2022 thomas  
        ''
        mod_listArrows.Add(par_arrow)


    End Sub


    Public Sub SaveToXML(pstrPathToXML As String) ''12/2022 (Optional ByVal pstrPathToXML As String = "")
        ''
        ''Added 12/13/2022 & 11/29/2019 thomas downes
        ''
        ''This code was copied from ciBadgeCachePersonalityEtc.ClassElementsCacheV1_Deprecated
        ''
        Dim objSerializationClass As New ciBadgeSerialize.ClassSerial

        With objSerializationClass

            ''12/13/2022 .PathToXML_Binary = Me.PathToXml_Binary ''Added 11/29/2019 thomas d. 
            ''12/13/2022 If (Me.PathToXml_Opened <> "") Then
            ''    .PathToXML = Me.PathToXml_Opened
            ''    .PathToXML_Alternate = Me.PathToXml_Saved ''Added 3/23/2022 thomas d. 
            ''Else
            ''    .PathToXML = Me.PathToXml_Saved
            ''    .PathToXML_Alternate = Me.PathToXml_Opened ''Added 3/23/2022 thomas d. 
            ''End If ''End of "If (Me.PathToXML_Opened <> "") Then ... Else"

            If (pstrPathToXML <> "") Then
                .PathToXML = pstrPathToXML
            End If


            Dim boolSerializeToBinary As Boolean = False ''Added 9/30/2019 td
            boolSerializeToBinary = ciBadgeSerialize.ClassSerial.UseBinaryFormat
            If (boolSerializeToBinary) Then
                .SerializeToBinary(Me.GetType, Me)
            Else
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


    Public Shared Function LoadFromXML(pstrPathToXML As String,
         Optional ByRef par_cache_arrows As ClassListOfArrows = Nothing)
        ''
        ''Added 12/13/2022 & 10/10/2019 thomas downes
        ''
        ''This code was copied from ciBadgeCachePersonalityEtc.ClassElementsCacheV1_Deprecated
        ''
        Dim objDeserialize As New ciBadgeSerialize.ClassDeserial ''Added 10/10/2019 td  
        objDeserialize.PathToXML = pstrPathToXML

        par_cache_arrows = New ClassListOfArrows ''This may or may not be completely necessary,
        ''   but I know of no other way to pass the object type.  Simply expressing the Type
        ''   by typing its name doesn't work.  ---10/13/2019 td

        ClassElementsCache_Deprecated.DeserializationCompleted = False ''Added 5/10/2022

        par_cache_arrows = CType(objDeserialize.DeserializeFromXML(par_cache_arrows.GetType(), False),
                                  ClassListOfArrows)

        Return par_cache_arrows

    End Function ''Public Shared Function LoadFromXML


End Class
