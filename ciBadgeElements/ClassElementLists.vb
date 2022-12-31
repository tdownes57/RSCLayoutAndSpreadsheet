''
''Added 2/10/2022 td
''

<Serializable>
Public Class ClassElementLists
    ''
    ''Added 2/10/2022 td
    ''
    ''12/2022 td Public Property ListElementFieldsV4 As HashSet(Of ClassElementFieldV4)
    ''12/2022 td Public Property ListElementPortraits As HashSet(Of ClassElementPortrait)
    ''12/2022 td Public Property ListElementStaticsV4 As HashSet(Of ClassElementStaticTextV4)
    ''12/2022 td Public Property ListElementGraphics As HashSet(Of ClassElementGraphic)
    ''12/2022 td Public Property ListElementQRCodes As HashSet(Of ClassElementQRCode)
    ''12/2022 td Public Property ListElementSignatures As HashSet(Of ClassElementSignature)
    ''12/2022 td Public Property ListElementLaysections As HashSet(Of ClassElementLaysection)

    Public ReadOnly Property ListElementFieldsV4 As HashSet(Of ClassElementFieldV4)
        Get
            Return _ListElementFieldsV4
        End Get
    End Property

    Public ReadOnly Property ListElementPortraits As HashSet(Of ClassElementPortrait)
        Get
            Return _ListElementPortraits
        End Get
    End Property

    Public ReadOnly Property ListElementStaticsV4 As HashSet(Of ClassElementStaticTextV4)
        Get
            Return _ListElementStaticsV4
        End Get
    End Property

    Public ReadOnly Property ListElementGraphics As HashSet(Of ClassElementGraphic)
        Get
            Return _ListElementGraphics
        End Get
    End Property

    Public ReadOnly Property ListElementQRCodes As HashSet(Of ClassElementQRCode)
        Get
            Return _ListElementQRCodes
        End Get
    End Property

    Public ReadOnly Property ListElementSignatures As HashSet(Of ClassElementSignature)
        Get
            Return _ListElementSignatures
        End Get
    End Property

    Public ReadOnly Property ListElementLaysections As HashSet(Of ClassElementLaysection)
        Get
            Return _ListElementLaysections
        End Get
    End Property


    ''---Property ListElementFields As List(Of ClassElementFieldV4)

    Private _ListElementFieldsV4 As HashSet(Of ClassElementFieldV4)
    Private _ListElementPortraits As HashSet(Of ClassElementPortrait)
    Private _ListElementStaticsV4 As HashSet(Of ClassElementStaticTextV4)
    Private _ListElementGraphics As HashSet(Of ClassElementGraphic)
    Private _ListElementQRCodes As HashSet(Of ClassElementQRCode)
    Private _ListElementSignatures As HashSet(Of ClassElementSignature)
    Private _ListElementLaysections As HashSet(Of ClassElementLaysection)


End Class
