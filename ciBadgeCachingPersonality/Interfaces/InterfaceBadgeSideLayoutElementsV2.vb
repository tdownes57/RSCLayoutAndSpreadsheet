''
''Added 12/18/2021 thomas downes  
''
Imports System.Drawing
Imports ciBadgeElements

Public Interface IBadgeSideLayoutElementsV2 ''Added 1/13/2022 thomas d
    ''
    ''Added 1/13/2022 thomas downes  
    ''
    ''  As of 3/2023, I think I recall the purpose of V2 is to leverage the following
    ''
    ''     Property ElementLists As ClassElementLists ''Added 2/10/2022 thomas downes
    ''
    ''  which replaces the following of V1:  
    ''
    ''     Property ListElementFieldsV3 As HashSet(Of ClassElementFieldV3)
    ''     Property ListElementFieldsV4 As HashSet(Of ClassElementFieldV4)
    ''     Property ListElementStaticTextsV3 As HashSet(Of ClassElementStaticTextV3)
    ''     Property ListElementStaticTextsV4 As HashSet(Of ClassElementStaticTextV4)
    ''     Property ListElementPortraits As HashSet(Of ClassElementPortrait)
    ''     Property ListElementQRCodes As HashSet(Of ClassElementQRCode)
    ''     Property ListElementSignatures As HashSet(Of ClassElementSignature)
    ''     Property ListElementStaticTexts As HashSet(Of ClassElementStaticTextV3)
    ''     Property ListElementGraphics As HashSet(Of ClassElementGraphic)
    ''     Property ListElementLaysections As HashSet(Of ClassElementLaysection)
    ''
    '' ---3/17/2023 td
    ''
    Property BackgroundImage As Image
    Property RecipientPortrait1 As Image
    Property RecipientPortrait2_RarelyUsed As Image
    Property par_iRecipientInfo As ciBadgeInterfaces.IRecipient

    Property ElementLists As ClassElementLists ''Added 2/10/2022 thomas downes

    ''Property ListElementFields As HashSet(Of ClassElementFieldV3)

    ''''Jan13 2022 td''Property ElementPic As ClassElementPic
    ''''Jan13 2022 td''Property ElementQR As ClassElementQRCode
    ''''Jan13 2022 td''Property ElementSig As ClassElementSignature ''par_elementSig = null,


End Interface

