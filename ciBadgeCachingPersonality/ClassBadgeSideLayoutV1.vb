Option Strict On
Option Explicit On

Imports System.Drawing
Imports ciBadgeElements
Imports ciBadgeInterfaces

''
''Added 12/18/2021 td 
''
Public Class ClassBadgeSideLayoutV1
    Implements IBadgeSideLayoutElementsV1
    ''
    ''Added 12/18/2021 td 
    ''
    <System.Xml.Serialization.XmlIgnore>
    Public Property BackgroundImage As Image Implements IBadgeSideLayoutElementsV1.BackgroundImage
    Public Property BackgroundImage_Path As String = "" ''Added 1/14/2020 td
    Public Property BackgroundImage_FTitle As String = "" ''Added 1/14/2020 td

    Private mod_listElementFields As New HashSet(Of ClassElementField)
    Private mod_listElementPics As New HashSet(Of ClassElementPortrait)
    Private mod_listElementStatics As New HashSet(Of ClassElementStaticText)
    Private mod_listElementGraphics As New HashSet(Of ClassElementGraphic) ''Added 1/8/2022 td
    Private mod_listElementLaysections As New HashSet(Of ClassElementLaysection) ''Added 9/17/2019

    <System.Xml.Serialization.XmlIgnore>
    Public Property RecipientPic As Image Implements IBadgeSideLayoutElementsV1.RecipientPic
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As Image)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property par_iRecipientInfo As IRecipient Implements IBadgeSideLayoutElementsV1.par_iRecipientInfo
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As IRecipient)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property ListElementFields As HashSet(Of ClassElementField) Implements IBadgeSideLayoutElementsV1.ListElementFields
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As HashSet(Of ClassElementField))
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property ListElementStaticTexts As HashSet(Of ClassElementStaticText) Implements IBadgeSideLayoutElementsV1.ListElementStaticTexts
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As HashSet(Of ClassElementStaticText))
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property ListElementGraphics As HashSet(Of ClassElementGraphic) Implements IBadgeSideLayoutElementsV1.ListElementGraphics
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As HashSet(Of ClassElementGraphic))
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property ElementPortrait_1st As ClassElementPortrait Implements IBadgeSideLayoutElementsV1.ElementPortrait_1st
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As ClassElementPic)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property ElementQRCode_1st As ClassElementQRCode Implements IBadgeSideLayoutElementsV1.ElementQRCode_1st
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As ClassElementQRCode)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property ElementSignature_1st As ClassElementSignature Implements IBadgeSideLayoutElementsV1.ElementSignature_1st
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As ClassElementSignature)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property


    ''
    ''Added 1/14/2022 td  
    ''
    Public Property ListElementPortraits As HashSet(Of ClassElementPortrait) Implements IBadgeSideLayoutElementsV1.ListElementPortraits
    Public Property ListElementQRCodes As HashSet(Of ClassElementQRCode) Implements IBadgeSideLayoutElementsV1.ListElementQRCodes
    Public Property ListElementSignatures As HashSet(Of ClassElementSignature) Implements IBadgeSideLayoutElementsV1.ListElementSignatures

    ''Added 1/14/2022 td  
    Public Property ListAllElements_RSC As HashSet(Of ClassElementBase) Implements IBadgeSideLayoutElementsV1.ListAllElements_RSC

End Class
