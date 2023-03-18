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

    Private mod_listElementFieldsV3 As New HashSet(Of ClassElementFieldV3)
    Private mod_listElementFieldsV4 As New HashSet(Of ClassElementFieldV4)
    Private mod_listElementPics As New HashSet(Of ClassElementPortrait)
    Private mod_listElementStaticsV3 As New HashSet(Of ClassElementStaticTextV3)
    Private mod_listElementStaticsV4 As New HashSet(Of ClassElementStaticTextV4)
    Private mod_listElementGraphics As New HashSet(Of ClassElementGraphic) ''Added 1/8/2022 td
    Private mod_listElementLaysections As New HashSet(Of ClassElementLaysection) ''Added 9/17/2019
    Private mod_listElementQRCodes As HashSet(Of ClassElementQRCode) ''Added 3/18/2023
    Private mod_listElementSignatures As HashSet(Of ClassElementSignature) ''Added 3/18/2023

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

    Public Property ListElementFieldsV3 As HashSet(Of ClassElementFieldV3) Implements IBadgeSideLayoutElementsV1.ListElementFieldsV3
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As HashSet(Of ClassElementField))
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property ListElementFieldsV4 As HashSet(Of ClassElementFieldV4) Implements IBadgeSideLayoutElementsV1.ListElementFieldsV4
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As HashSet(Of ClassElementField))
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property ListElementStaticTextsV3 As HashSet(Of ClassElementStaticTextV3) Implements IBadgeSideLayoutElementsV1.ListElementStaticTextsV3
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As HashSet(Of ClassElementStaticText))
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property ListElementStaticTextsV4 As HashSet(Of ClassElementStaticTextV4) Implements IBadgeSideLayoutElementsV1.ListElementStaticTextsV4
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

    ''5/15/2022 td''Public Property ElementPortrait_1st As ClassElementPortrait Implements IBadgeSideLayoutElementsV1.ElementPortrait_1st
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As ClassElementPic)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    ''5/15/2022 td''Public Property ElementQRCode_1st As ClassElementQRCode Implements IBadgeSideLayoutElementsV1.ElementQRCode_1st
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As ClassElementQRCode)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    ''5/15/2022 td''Public Property ElementSignature_1st As ClassElementSignature Implements IBadgeSideLayoutElementsV1.ElementSignature_1st
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


    Public Shared Function CompareRSC(par1 As ClassElementBase, par2 As ClassElementBase) As Integer
        ''
        ''Added 3/18/2023 Thomas  
        ''
        If (par1.ZOrder > par2.ZOrder) Then Return 1
        If (par1.ZOrder < par2.ZOrder) Then Return -1
        Return 0

    End Function ''End of ""Public Shared Function CompareRSC""


    Public Function GetQueueOfAllElements_ByZOrder(Optional par_reverseOrder As Boolean = False) _
              As Queue(Of ClassElementBase)
        ''
        ''Added 3/18/2023 Thomas  
        ''
        Dim objList As New List(Of ClassElementBase)

        objList.AddRange(mod_listElementFieldsV3)
        objList.AddRange(mod_listElementFieldsV4)
        objList.AddRange(mod_listElementGraphics)
        objList.AddRange(mod_listElementPics)
        objList.AddRange(mod_listElementStaticsV3)
        objList.AddRange(mod_listElementStaticsV4)
        objList.AddRange(mod_listElementQRCodes)
        objList.AddRange(mod_listElementSignatures)

        ''--++++This is a function & returns a new list. 
        ''--++objList.OrderBy(Function(x) x.ZOrder)

        If (par_reverseOrder) Then
            objList.Sort(Function(x, y) (-1 * CompareRSC(x, y)))
        Else
            objList.Sort(Function(x, y) CompareRSC(x, y))
        End If

        Return New Queue(Of ClassElementBase)(objList)

    End Function ''End of ""Public Function GetQueueOfAllElements()""


End Class
