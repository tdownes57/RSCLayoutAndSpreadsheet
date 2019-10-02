''
''Added 10/2/2019 thomas downes  
''

Public Class CacheMenuItems
    ''
    ''Added 10/2/2019 thomas downes  
    ''
    Public Shared List_EditElementMenu As New List(Of LinkLabel)
    Public Shared List_ManageGroupedCtls As New List(Of LinkLabel)
    Public Shared List_AlignmentFeatures As New List(Of LinkLabel)
    Public Shared List_EditBackgroundMenu As New List(Of LinkLabel)

    Public Shared Sub GenerateMenuItems()
        ''
        ''Added 10/2/2019 thomas downes  
        ''
        GenerateMenuItems_Basic()
        GenerateMenuItems_Grouped()
        GenerateMenuItems_Aligning()

    End Sub ''End of "Public Shared Sub GenerateMenuItems()"

    Private Shared Sub GenerateMenuItems_Basic()
        ''
        ''We will use Reflection to build this cache of menu controls. 
        ''
        ''   We will convert the procedures in class Methods_EditElement to clickable LinkLabels.
        ''

    End Sub
    Private Shared Sub GenerateMenuItems_Grouped()
        ''
        ''We will use Reflection to build this cache of menu controls. 
        ''
        ''   We will convert the procedures in class ElementEditingMethods to clickable LinkLabels.
        ''
        ''

    End Sub
    Private Shared Sub GenerateMenuItems_Aligning()
        ''
        ''We will use Reflection to build this cache of menu controls. 
        ''
        ''   We will convert the procedures in class Methods_EditElement to clickable LinkLabels.
        ''
        ''

    End Sub

End Class
