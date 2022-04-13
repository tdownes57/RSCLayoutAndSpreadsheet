Option Explicit On '' Added 3/15/2022 thomas downes 
Option Strict On '' Added 3/15/2022 thomas downes 
''
'' Added 3/15/2022 thomas downes  
''
Namespace ciBadgeCachePersonality

    <Serializable>
    Public Class ClassRSCColumnWidthAndData
        ''
        '' Added 3/15/2022 thomas downes  
        ''
        Public Property Width As Integer
        Public Property Rows As Integer

        Public Property CIBField As ciBadgeInterfaces.EnumCIBFields

        Public Property ColumnData As List(Of String)


    End Class ''End of ""Public Class ClassRSCColumnWidthAndData""

End Namespace