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

    Public Shared Sub Load_AllLists(par_listFF As List(Of ClassElementField),
                                    par_listFB As List(Of ClassElementField),
                                    par_listGF As List(Of ClassElementGraphic),
                                    par_listGB As List(Of ClassElementGraphic),
                                    par_listPF As List(Of ClassElementPortrait),
                                    par_listPB As List(Of ClassElementPortrait),
                                    par_listQF As List(Of ClassElementQRCode),
                                    par_listQB As List(Of ClassElementQRCode),
                                    par_listSiF As List(Of ClassElementSignature),
                                    par_listSiB As List(Of ClassElementSignature),
                                    par_listStF As List(Of ClassElementStaticText),
                                    par_listStB As List(Of ClassElementStaticText))
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

    Public MustOverride Sub SwitchElementToOtherSideOfCard(par_infoBase As IElement_Base)
    Public MustOverride Sub RemoveElement(par_infoBase As IElement_Base,
                                          Optional pboolBacksideOfCard As Boolean = False)



End Class
