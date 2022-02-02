''
''Added 1/19/2022 thomas downes
''
Imports ciBadgeInterfaces
Imports ciBadgeElements ''Added 1/19/2022 td

Public MustInherit Class ClassListOfElements
    ''
    ''Added 1/19/2022 thomas downes
    ''
    ''Public MustOverride Property ListOfElements_Front As Object ''List(Of ClassElementField)
    ''Public MustOverride Property ListOfElements_Back As Object ''List(Of ClassElementField)

    Public Shared ClassList_Fields As New ClassListOfElements_Fields
    Public Shared ClassList_Graphics As New ClassListOfElements_Graphics
    Public Shared ClassList_Portraits As New ClassListOfElements_Portraits
    Public Shared ClassList_QRCodes As New ClassListOfElements_QRCodes
    Public Shared ClassList_Signatures As New ClassListOfElements_Signatures
    ''Feb2 2022 ''Public Shared ClassList_StaticTexts As New ClassListOfElements_StaticTexts
    Public Shared ClassList_StaticTextsV3 As New ClassListOfElements_StaticTextsV3
    Public Shared ClassList_StaticTextsV4 As New ClassListOfElements_StaticTextsV4

    Public Shared Sub UnloadListReferences()
        ''
        ''Added 1/21/2022 thomas downes
        ''
        ''ClassList_Fields = Nothing
        ''ClassList_Graphics.  = Nothing
        ''ClassList_Portraits  = Nothing
        ''ClassList_QRCodes  = Nothing
        ''ClassList_Signatures = Nothing
        ''ClassList_StaticTexts = Nothing

        ''Added 1/21/2022
        ClassList_Fields.ListOfElements_Front = Nothing
        ClassList_Graphics.ListOfElements_Front = Nothing
        ClassList_Portraits.ListOfElements_Front = Nothing
        ClassList_QRCodes.ListOfElements_Front = Nothing
        ClassList_Signatures.ListOfElements_Front = Nothing
        ''Feb2 2022 td''ClassList_StaticTexts.ListOfElements_Front = Nothing
        ClassList_StaticTextsV3.ListOfElements_Front = Nothing
        ClassList_StaticTextsV4.ListOfElements_Front = Nothing

        ClassList_Fields.ListOfElements_Backside = Nothing
        ClassList_Graphics.ListOfElements_Backside = Nothing
        ClassList_Portraits.ListOfElements_Backside = Nothing
        ClassList_QRCodes.ListOfElements_Backside = Nothing
        ClassList_Signatures.ListOfElements_Backside = Nothing
        ''Feb2 2022 td''ClassList_StaticTexts.ListOfElements_Front = Nothing
        ClassList_StaticTextsV3.ListOfElements_Backside = Nothing
        ClassList_StaticTextsV4.ListOfElements_Backside = Nothing

    End Sub ''ENd of ''Public Shared Sub UnloadListReferences()"


    Public Shared Sub Initialize_IfNeeded(par_cache As ciBadgeCachePersonality.ClassElementsCache_Deprecated)
        ''
        ''Added 1/21/2022 thomas downes
        ''
        Dim bProbablyUnitialized As Boolean
        bProbablyUnitialized = (ClassList_Fields.ListOfElements_Backside Is Nothing)

        If (bProbablyUnitialized) Then
            With par_cache

                Load_AllLists(.ListOfElementFields_Front, .ListOfElementFields_Backside,
                              .ListOfElementGraphics_Front, .ListOfElementGraphics_Backside,
                              .ListOfElementPics_Front, .ListOfElementPics_Back,
                              .ListOfElementQRCodes_Front, .ListOfElementQRCodes_Back,
                              .ListOfElementSignatures_Front, .ListOfElementSignatures_Back,
                              .ListOfElementTextsV3_Front, .ListOfElementTextsV3_Backside,
                              .ListOfElementTextsV4_Front, .ListOfElementTextsV4_Backside)

            End With

        End If ''End of "If (bProbablyUnitialized) Then"

    End Sub ''ENd of "Public Shared Sub Initialize_IfNeeded()"


    Public Shared Sub Load_AllLists(par_listF_Fr As HashSet(Of ClassElementFieldV3),
                                    par_listF_Ba As HashSet(Of ClassElementFieldV3),
                                    par_listG_Fr As HashSet(Of ClassElementGraphic),
                                    par_listG_Ba As HashSet(Of ClassElementGraphic),
                                    par_listP_Fr As HashSet(Of ClassElementPortrait),
                                    par_listP_Ba As HashSet(Of ClassElementPortrait),
                                    par_listQ_Fr As HashSet(Of ClassElementQRCode),
                                    par_listQ_Ba As HashSet(Of ClassElementQRCode),
                                    par_listSi_Fr As HashSet(Of ClassElementSignature),
                                    par_listSi_Ba As HashSet(Of ClassElementSignature),
                                    par_listSt_Fr_V3 As HashSet(Of ClassElementStaticTextV3),
                                    par_listSt_Ba_V3 As HashSet(Of ClassElementStaticTextV3),
                                    par_listSt_Fr_V4 As HashSet(Of ClassElementStaticTextV4),
                                    par_listSt_Ba_V4 As HashSet(Of ClassElementStaticTextV4))
        ''
        ''Added 1/19/2022 td
        ''
        ClassList_Fields.ListOfElements_Backside = par_listF_Ba
        ClassList_Fields.ListOfElements_Front = par_listF_Fr

        ClassList_Graphics.ListOfElements_Backside = par_listG_Ba
        ClassList_Graphics.ListOfElements_Front = par_listG_Fr

        ClassList_Portraits.ListOfElements_Backside = par_listP_Ba
        ClassList_Portraits.ListOfElements_Front = par_listP_Fr

        ClassList_QRCodes.ListOfElements_Backside = par_listQ_Ba
        ClassList_QRCodes.ListOfElements_Front = par_listQ_Fr

        ClassList_Signatures.ListOfElements_Backside = par_listSi_Ba
        ClassList_Signatures.ListOfElements_Front = par_listSi_Fr

        ''2/2022 ''ClassList_StaticTexts.ListOfElements_Backside = par_listStB
        ''2/2022 ''ClassList_StaticTexts.ListOfElements_Front = par_listStF

        ClassList_StaticTextsV3.ListOfElements_Backside = par_listSt_Ba_V3
        ClassList_StaticTextsV3.ListOfElements_Front = par_listSt_Fr_V3

        ClassList_StaticTextsV4.ListOfElements_Backside = par_listSt_Ba_V4
        ClassList_StaticTextsV4.ListOfElements_Front = par_listSt_Fr_V4

    End Sub


    Public Shared Function GetListOfElements(par_enum As Enum_ElementType) As ClassListOfElements
        ''
        ''Added 1/19/2022 thomas downes
        ''
        Select Case par_enum
            Case Enum_ElementType.Field : Return ClassList_Fields
            Case Enum_ElementType.Portrait : Return ClassList_Portraits
            Case Enum_ElementType.QRCode : Return ClassList_QRCodes
            Case Enum_ElementType.Signature : Return ClassList_Signatures
            Case Enum_ElementType.StaticGraphic : Return ClassList_Graphics

            ''2/2/2022 td''Case Enum_ElementType.StaticText : Return ClassList_StaticTexts
            Case Enum_ElementType.StaticTextV3 : Return ClassList_StaticTextsV3
            Case Enum_ElementType.StaticTextV4 : Return ClassList_StaticTextsV4

        End Select


    End Function ''ENd of "ublic Shared Function GetListOfElements(par_enum As enum)"

    Public MustOverride Sub SwitchElementToOtherSideOfCard(par_infoBase As IElement_Base,
                                  Optional ByRef pref_bSuccess As Boolean = False)
    Public MustOverride Sub RemoveElement(par_infoBase As IElement_Base,
                                          Optional ByRef pref_bSuccess As Boolean = False,
                                          Optional pbSpecifySideOfCard As Boolean = False,
            Optional par_enumSide As EnumWhichSideOfCard = EnumWhichSideOfCard.Undetermined)



End Class
