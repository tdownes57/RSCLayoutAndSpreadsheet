''
''Added 12/18/2021 thomas downes  
''
Imports System.Drawing
Imports ciBadgeElements

Public Interface IBadgeSideLayoutElements ''Dec18 '' InterfaceBadgeSideLayout
    ''
    ''Added 12/18/2021 thomas downes  
    ''
    Property BackgroundImage As Image
    Property RecipientPic As Image
    Property par_iRecipientInfo As ciBadgeInterfaces.IRecipient

    Property ListElementFields As HashSet(Of ClassElementField)
    Property ListElementStaticTexts As HashSet(Of ClassElementStaticText)
    Property ListElementGraphics As HashSet(Of ClassElementGraphic)

    Property ElementPic As ClassElementPic
    Property ElementQR As ClassElementQRCode

    Property ElementSig As ClassElementSignature ''par_elementSig = null,

End Interface
