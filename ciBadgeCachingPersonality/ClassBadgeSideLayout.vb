Option Strict On
Option Explicit On

Imports System.Drawing
Imports ciBadgeElements
Imports ciBadgeInterfaces

''
''Added 12/18/2021 td 
''
Public Class ClassBadgeSideLayout
    Implements IBadgeSideLayoutElements
    ''
    ''Added 12/18/2021 td 
    ''
    Public Property BackgroundImage As Image Implements IBadgeSideLayoutElements.BackgroundImage

    Public Property RecipientPic As Image Implements IBadgeSideLayoutElements.RecipientPic
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As Image)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property par_iRecipientInfo As IRecipient Implements IBadgeSideLayoutElements.par_iRecipientInfo
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As IRecipient)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property ListElementFields As HashSet(Of ClassElementField) Implements IBadgeSideLayoutElements.ListElementFields
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As HashSet(Of ClassElementField))
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property ListElementStaticTexts As HashSet(Of ClassElementStaticText) Implements IBadgeSideLayoutElements.ListElementStaticTexts
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As HashSet(Of ClassElementStaticText))
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property ListElementGraphics As HashSet(Of ClassElementGraphic) Implements IBadgeSideLayoutElements.ListElementGraphics
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As HashSet(Of ClassElementGraphic))
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property ElementPic As ClassElementPic Implements IBadgeSideLayoutElements.ElementPic
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As ClassElementPic)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property ElementQR As ClassElementQRCode Implements IBadgeSideLayoutElements.ElementQR
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As ClassElementQRCode)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property ElementSig As ClassElementSignature Implements IBadgeSideLayoutElements.ElementSig
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As ClassElementSignature)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

End Class
