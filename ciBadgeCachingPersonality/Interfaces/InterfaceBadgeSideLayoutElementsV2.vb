''
''Added 12/18/2021 thomas downes  
''
Imports System.Drawing
Imports ciBadgeElements

Public Interface IBadgeSideLayoutElementsV2 ''Added 1/13/2022 thomas d
    ''
    ''Added 1/13/2022 thomas downes  
    ''
    Property BackgroundImage As Image
    Property RecipientPortrait1 As Image
    Property RecipientPortrait2_RarelyUsed As Image
    Property par_iRecipientInfo As ciBadgeInterfaces.IRecipient

    Property ListElementFields As HashSet(Of ClassElementField)

    ''Jan13 2022 td''Property ElementPic As ClassElementPic
    ''Jan13 2022 td''Property ElementQR As ClassElementQRCode
    ''Jan13 2022 td''Property ElementSig As ClassElementSignature ''par_elementSig = null,

    ''Added 1/13/2022 td
    Property ListElementPortraits As HashSet(Of ClassElementPortrait)
    Property ListElementQRCodes As HashSet(Of ClassElementQRCode)
    Property ListElementSignatures As HashSet(Of ClassElementSignature)
    Property ListElementStaticTexts As HashSet(Of ClassElementStaticText)
    Property ListElementGraphics As HashSet(Of ClassElementGraphic)

    ''Added 1/13/2022 td
    Property ListElementLaysections As HashSet(Of ClassElementLaysection)

End Interface

