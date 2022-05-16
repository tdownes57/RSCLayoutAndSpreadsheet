''
''Added 12/18/2021 thomas downes  
''
Imports System.Drawing
Imports ciBadgeElements

Public Interface IBadgeSideLayoutElementsV1 ''Dec18 '' InterfaceBadgeSideLayout
    ''
    ''Added 12/18/2021 thomas downes  
    ''
    Property BackgroundImage As Image
    Property RecipientPic As Image
    Property par_iRecipientInfo As ciBadgeInterfaces.IRecipient

    Property ListElementFieldsV3 As HashSet(Of ClassElementFieldV3)
    Property ListElementFieldsV4 As HashSet(Of ClassElementFieldV4)

    Property ListElementStaticTextsV3 As HashSet(Of ClassElementStaticTextV3)
    Property ListElementStaticTextsV4 As HashSet(Of ClassElementStaticTextV4)

    Property ListElementGraphics As HashSet(Of ClassElementGraphic)

    ''5/15/2022 td ''Property ElementPortrait_1st As ClassElementPortrait ''Jan13 2022 ''As ClassElementPic  
    ''5/15/2022 td ''Property ElementQRCode_1st As ClassElementQRCode
    ''5/15/2022 td ''Property ElementSignature_1st As ClassElementSignature ''par_elementSig = null,

    ''
    ''Added 1/14/2022 thomas downes  
    ''
    Property ListElementPortraits As HashSet(Of ClassElementPortrait)
    Property ListElementQRCodes As HashSet(Of ClassElementQRCode)
    Property ListElementSignatures As HashSet(Of ClassElementSignature)

    ''Added 1/14/2022 td 
    Property ListAllElements_RSC As HashSet(Of ClassElementBase)

End Interface
