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
    Public Shared ClassList_StaticTexts As New ClassListOfElements_StaticTexts

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
        ClassList_StaticTexts.ListOfElements_Front = Nothing

        ClassList_Fields.ListOfElements_Backside = Nothing
        ClassList_Graphics.ListOfElements_Backside = Nothing
        ClassList_Portraits.ListOfElements_Backside = Nothing
        ClassList_QRCodes.ListOfElements_Backside = Nothing
        ClassList_Signatures.ListOfElements_Backside = Nothing
        ClassList_StaticTexts.ListOfElements_Backside = Nothing

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
                              .ListOfElementTexts_Front, .ListOfElementTexts_Backside)

            End With
        End If ''End of "If (bProbablyUnitialized) Then"

    End Sub ''ENd of "Public Shared Sub Initialize_IfNeeded()"


    Public Shared Sub Load_AllLists(par_listFF As HashSet(Of ClassElementFieldV3),
                                    par_listFB As HashSet(Of ClassElementFieldV3),
                                    par_listGF As HashSet(Of ClassElementGraphic),
                                    par_listGB As HashSet(Of ClassElementGraphic),
                                    par_listPF As HashSet(Of ClassElementPortrait),
                                    par_listPB As HashSet(Of ClassElementPortrait),
                                    par_listQF As HashSet(Of ClassElementQRCode),
                                    par_listQB As HashSet(Of ClassElementQRCode),
                                    par_listSiF As HashSet(Of ClassElementSignature),
                                    par_listSiB As HashSet(Of ClassElementSignature),
                                    par_listStF As HashSet(Of ClassElementStaticTextV3),
                                    par_listStB As HashSet(Of ClassElementStaticTextV3))
        ''
        ''Added 1/19/2022 td
        ''
        ClassList_Fields.ListOfElements_Backside = par_listFB
        ClassList_Fields.ListOfElements_Front = par_listFF

        ClassList_Graphics.ListOfElements_Backside = par_listGB
        ClassList_Graphics.ListOfElements_Front = par_listGF

        ClassList_Portraits.ListOfElements_Backside = par_listPB
        ClassList_Portraits.ListOfElements_Front = par_listPF

        ClassList_QRCodes.ListOfElements_Backside = par_listQB
        ClassList_QRCodes.ListOfElements_Front = par_listQF

        ClassList_Signatures.ListOfElements_Backside = par_listSiB
        ClassList_Signatures.ListOfElements_Front = par_listSiF

        ClassList_StaticTexts.ListOfElements_Backside = par_listStB
        ClassList_StaticTexts.ListOfElements_Front = par_listStF


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
            Case Enum_ElementType.StaticText : Return ClassList_StaticTexts

        End Select


    End Function ''ENd of "ublic Shared Function GetListOfElements(par_enum As enum)"

    Public MustOverride Sub SwitchElementToOtherSideOfCard(par_infoBase As IElement_Base,
                                  Optional ByRef pref_bSuccess As Boolean = False)
    Public MustOverride Sub RemoveElement(par_infoBase As IElement_Base,
                                          Optional ByRef pref_bSuccess As Boolean = False,
                                          Optional pbSpecifySideOfCard As Boolean = False,
            Optional par_enumSide As EnumWhichSideOfCard = EnumWhichSideOfCard.Undetermined)



End Class
