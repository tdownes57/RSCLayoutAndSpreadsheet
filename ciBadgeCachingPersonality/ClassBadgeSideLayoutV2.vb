Option Strict On
Option Explicit On

Imports System.Drawing
Imports ciBadgeElements
Imports ciBadgeInterfaces

''
''Added 1/13/2022 td 
''
Public Class ClassBadgeSideLayoutV2
    Implements IBadgeSideLayoutElementsV2
    ''
    ''Added 1/13/2022 td 
    ''
    <System.Xml.Serialization.XmlIgnore>
    Public Property BackgroundImage As Image Implements IBadgeSideLayoutElementsV2.BackgroundImage
    Public Property BackgroundImage_Path As String = "" ''Added 1/14/2020 td
    Public Property BackgroundImage_FTitle As String = "" ''Added 1/14/2020 td

    Private mod_listElementFields As New HashSet(Of ClassElementField)
    Private mod_listElementPics As New HashSet(Of ClassElementPortrait)
    Private mod_listElementStatics As New HashSet(Of ClassElementStaticText)
    Private mod_listElementGraphics As New HashSet(Of ClassElementGraphic) ''Added 1/8/2022 td
    Private mod_listElementLaysections As New HashSet(Of ClassElementLaysection) ''Added 9/17/2019

    <System.Xml.Serialization.XmlIgnore>
    Public Property RecipientPortrait1 As Image Implements IBadgeSideLayoutElementsV2.RecipientPortrait1

    <System.Xml.Serialization.XmlIgnore>
    Public Property RecipientPortrait2_RarelyUsed As Image Implements IBadgeSideLayoutElementsV2.RecipientPortrait2_RarelyUsed
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As Image)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property par_iRecipientInfo As IRecipient Implements IBadgeSideLayoutElementsV2.par_iRecipientInfo
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As IRecipient)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property ListElementFields As HashSet(Of ClassElementField) Implements IBadgeSideLayoutElementsV2.ListElementFields
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As HashSet(Of ClassElementField))
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property ListElementStaticTexts As HashSet(Of ClassElementStaticText) Implements IBadgeSideLayoutElementsV2.ListElementStaticTexts
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As HashSet(Of ClassElementStaticText))
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property ListElementGraphics As HashSet(Of ClassElementGraphic) Implements IBadgeSideLayoutElementsV2.ListElementGraphics
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As HashSet(Of ClassElementGraphic))
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property ListElementPortraits As HashSet(Of ClassElementPortrait) Implements IBadgeSideLayoutElementsV2.ListElementPortraits
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As ClassElementPic)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property ListElementQRCodes As HashSet(Of ClassElementQRCode) Implements IBadgeSideLayoutElementsV2.ListElementQRCodes
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As ClassElementQRCode)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property ListElementSignatures As HashSet(Of ClassElementSignature) Implements IBadgeSideLayoutElementsV2.ListElementSignatures
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As ClassElementSignature)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property ListElementLaysections As HashSet(Of ClassElementLaysection) Implements IBadgeSideLayoutElementsV2.ListElementLaysections
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As ClassElementSignature)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

End Class


