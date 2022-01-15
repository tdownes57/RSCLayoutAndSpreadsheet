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

    Property ListElementFields As HashSet(Of ClassElementField)
    Property ListElementStaticTexts As HashSet(Of ClassElementStaticText)
    Property ListElementGraphics As HashSet(Of ClassElementGraphic)

    Property ElementPortrait As ClassElementPortrait ''Jan13 2022 ''As ClassElementPic  
    Property ElementQRCode As ClassElementQRCode
    Property ElementSignature As ClassElementSignature ''par_elementSig = null,

    ''
    ''Added 1/14/2022 thomas downes  
    ''
    Property ListElementPortraits As HashSet(Of ClassElementPortrait)
    Property ListElementQRCodes As HashSet(Of ClassElementQRCode)
    Property ListElementSignatures As HashSet(Of ClassElementSignature)

    ''Added 1/14/2022 td 
    Property ListAllElements_RSC As HashSet(Of ClassElementBase)

End Interface
