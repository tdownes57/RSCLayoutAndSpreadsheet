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

    ''
    ''Added 3/07/2023 Thomas Downes  
    ''
    Public Function ListOfElements_Base() As List(Of ClassElementBase)
        ''
        ''Added 3/07/2023 Thomas Downes  
        ''
        Dim objList As New List(Of ClassElementBase)

        objList.AddRange(_ListElementFieldsV4)
        objList.AddRange(_ListElementGraphics)
        objList.AddRange(_ListElementPortraits)
        objList.AddRange(_ListElementQRCodes)
        objList.AddRange(_ListElementSignatures)
        objList.AddRange(_ListElementStaticsV4)

        Return objList

    End Function ''ENd of ""Public Function ListOfElements_Base()""


    Public Shared Function CompareRSC(par1 As ClassElementBase, par2 As ClassElementBase) As Integer
        ''
        ''Added 3/18/2023 Thomas  
        ''
        If (par1.ZOrder > par2.ZOrder) Then Return 1
        If (par1.ZOrder < par2.ZOrder) Then Return -1
        Return 0

    End Function ''End of ""Public Shared Function CompareRSC""


    Public Function GetQueueOfAllElements() As Queue(Of ClassElementBase)
        ''
        ''Added 3/18/2023 Thomas  
        ''
        Dim objList As New List(Of ClassElementBase)

        objList.AddRange(_ListElementFieldsV4)
        objList.AddRange(_ListElementGraphics)
        objList.AddRange(_ListElementPortraits)
        objList.AddRange(_ListElementQRCodes)
        objList.AddRange(_ListElementSignatures)
        objList.AddRange(_ListElementStaticsV4)

        ''--++++This is a function & returns a new list. 
        ''--++objList.OrderBy(Function(x) x.ZOrder)

        objList.Sort(Function(x, y) CompareRSC(x, y))
        Return New Queue(Of ClassElementBase)(objList)

    End Function ''End of ""Public Function GetQueueOfAllElements()""



End Class
