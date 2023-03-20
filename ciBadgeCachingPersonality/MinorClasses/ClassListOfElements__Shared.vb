''
''Added 1/19/2022 thomas downes
''
Imports ciBadgeInterfaces
Imports ciBadgeElements ''Added 1/19/2022 td

Public MustInherit Class ClassListOfElementsShared
    ''
    ''Added 1/19/2022 thomas downes
    ''
    ''Public MustOverride Property ListOfElements_Front As Object ''List(Of ClassElementField)
    ''Public MustOverride Property ListOfElements_Back As Object ''List(Of ClassElementField)

    ''5/16/2022 td Public Shared ClassList_Fields As New ClassListOfElements_FieldsV3
    Public Shared ClassList_FieldsV3 As New ClassListOfElements_FieldsV3 ''Suffixed 5/16/2022
    Public Shared ClassList_FieldsV4 As New ClassListOfElements_FieldsV4 ''Added 5/16/2022

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
        ClassList_FieldsV3.ListOfElements_Front = Nothing
        ClassList_FieldsV4.ListOfElements_Front = Nothing ''Added 5/16/2022 

        ''Added 1/21/2022
        ClassList_Graphics.ListOfElements_Front = Nothing
        ClassList_Portraits.ListOfElements_Front = Nothing
        ClassList_QRCodes.ListOfElements_Front = Nothing
        ClassList_Signatures.ListOfElements_Front = Nothing
        ''Feb2 2022 td''ClassList_StaticTexts.ListOfElements_Front = Nothing
        ClassList_StaticTextsV3.ListOfElements_Front = Nothing
        ClassList_StaticTextsV4.ListOfElements_Front = Nothing

        ClassList_FieldsV3.ListOfElements_Backside = Nothing
        ClassList_FieldsV4.ListOfElements_Backside = Nothing ''Added 5/16/2022 

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
        bProbablyUnitialized = (ClassList_FieldsV3.ListOfElements_Backside Is Nothing)

        If (bProbablyUnitialized) Then
            With par_cache

                Load_AllLists(.ListOfElementFields_FrontV3, .ListOfElementFields_BacksideV3,
                              .ListOfElementFields_FrontV4, .ListOfElementFields_BacksideV4,
                              .ListOfElementGraphics_Front, .ListOfElementGraphics_Backside,
                              .ListOfElementPics_Front, .ListOfElementPics_Back,
                              .ListOfElementQRCodes_Front, .ListOfElementQRCodes_Back,
                              .ListOfElementSignatures_Front, .ListOfElementSignatures_Back,
                              .ListOfElementTextsV3_Front, .ListOfElementTextsV3_Backside,
                              .ListOfElementTextsV4_Front, .ListOfElementTextsV4_Backside)

            End With

        End If ''End of "If (bProbablyUnitialized) Then"

    End Sub ''ENd of "Public Shared Sub Initialize_IfNeeded()"


    Public Shared Sub Load_AllLists(par_listFv3_Fr As HashSet(Of ClassElementFieldV3),
                                    par_listFv3_Ba As HashSet(Of ClassElementFieldV3),
                                    par_listFv4_Fr As HashSet(Of ClassElementFieldV4),
                                    par_listFv4_Ba As HashSet(Of ClassElementFieldV4),
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
        ClassList_FieldsV3.ListOfElements_Backside = par_listFv3_Ba
        ClassList_FieldsV3.ListOfElements_Front = par_listFv3_Fr

        ''Added 5/16/2022 thomas d
        ClassList_FieldsV4.ListOfElements_Backside = par_listFv4_Ba
        ClassList_FieldsV4.ListOfElements_Front = par_listFv4_Fr

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


    Public Shared Function GetListOfElements(par_enum As Enum_ElementType,
            Optional pbUseOlderVersionOfField As Boolean = False) As ClassListOfElementsShared
        ''
        ''Added 1/19/2022 thomas downes
        ''
        Select Case par_enum
            Case Enum_ElementType.Field
                ''5/16/2022 td'' Return ClassList_FieldsV3
                If (pbUseOlderVersionOfField) Then Return ClassList_FieldsV3
                If (Not pbUseOlderVersionOfField) Then Return ClassList_FieldsV4
                Return ClassList_FieldsV4 ''Added 12/2022 td

            Case Enum_ElementType.Portrait : Return ClassList_Portraits
            Case Enum_ElementType.QRCode : Return ClassList_QRCodes
            Case Enum_ElementType.Signature : Return ClassList_Signatures
            Case Enum_ElementType.StaticGraphic : Return ClassList_Graphics

            ''2/2/2022 td''Case Enum_ElementType.StaticText : Return ClassList_StaticTexts
            Case Enum_ElementType.StaticTextV3 : Return ClassList_StaticTextsV3
            Case Enum_ElementType.StaticTextV4 : Return ClassList_StaticTextsV4

            Case Else
                ''Added 12/31/2022
                Throw New ArgumentException ''Added 12/31/2022

        End Select

    End Function ''ENd of "Public Shared Function GetListOfElements(par_enum As enum)"


    Public Shared Sub RemoveOrphanedElement(par_infoBase As IElement_Base,
                                          Optional ByRef pref_bSuccess As Boolean = False)
        ''
        ''Added 2/3/2022 thomas downes  
        ''
        If (Not pref_bSuccess) Then ClassList_FieldsV3.RemoveElement(par_infoBase, pref_bSuccess)
        If (Not pref_bSuccess) Then ClassList_Graphics.RemoveElement(par_infoBase, pref_bSuccess)
        If (Not pref_bSuccess) Then ClassList_Portraits.RemoveElement(par_infoBase, pref_bSuccess)
        If (Not pref_bSuccess) Then ClassList_QRCodes.RemoveElement(par_infoBase, pref_bSuccess)
        If (Not pref_bSuccess) Then ClassList_Signatures.RemoveElement(par_infoBase, pref_bSuccess)
        If (Not pref_bSuccess) Then ClassList_StaticTextsV3.RemoveElement(par_infoBase, pref_bSuccess)
        If (Not pref_bSuccess) Then ClassList_StaticTextsV4.RemoveElement(par_infoBase, pref_bSuccess)

    End Sub ''End of "Public Shared Sub RemoveElement"


    Public MustOverride Sub SwitchElementToOtherSideOfCard(par_infoBase As IElement_Base,
                                  Optional ByRef pref_bSuccess As Boolean = False)

    Public MustOverride Sub RemoveElement(par_infoBase As IElement_Base,
                                          Optional ByRef pref_bSuccess As Boolean = False,
                                          Optional pbSpecifySideOfCard As Boolean = False,
            Optional par_enumSide As EnumWhichSideOfCard = EnumWhichSideOfCard.Undetermined)


    Public Shared Sub SwitchOrphanedElement(par_infoBaseToMatch As IElement_Base,
                                          Optional ByRef pref_bSuccess As Boolean = False)
        ''
        ''Added 2/5/2022 thomas downes  
        ''
        If (Not pref_bSuccess) Then ClassList_FieldsV3.SwitchElementToOtherSideOfCard(par_infoBaseToMatch, pref_bSuccess)
        If (Not pref_bSuccess) Then ClassList_Graphics.SwitchElementToOtherSideOfCard(par_infoBaseToMatch, pref_bSuccess)
        If (Not pref_bSuccess) Then ClassList_Portraits.SwitchElementToOtherSideOfCard(par_infoBaseToMatch, pref_bSuccess)
        If (Not pref_bSuccess) Then ClassList_QRCodes.SwitchElementToOtherSideOfCard(par_infoBaseToMatch, pref_bSuccess)
        If (Not pref_bSuccess) Then ClassList_Signatures.SwitchElementToOtherSideOfCard(par_infoBaseToMatch, pref_bSuccess)
        If (Not pref_bSuccess) Then ClassList_StaticTextsV3.SwitchElementToOtherSideOfCard(par_infoBaseToMatch, pref_bSuccess)
        If (Not pref_bSuccess) Then ClassList_StaticTextsV4.SwitchElementToOtherSideOfCard(par_infoBaseToMatch, pref_bSuccess)

    End Sub ''End of "Public Shared Sub RemoveElement"





End Class
