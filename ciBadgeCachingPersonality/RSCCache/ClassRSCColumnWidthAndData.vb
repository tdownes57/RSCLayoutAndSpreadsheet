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

        ''Added 5/10/2023   
        Private mod_controlAssociatedRSCColumn As Windows.Forms.Control


        Public Sub SetRSCColumnAsControl(par_column As System.Windows.Forms.Control)
            ''5/2023 Public Sub New(par_column As System.Windows.Forms.Control)
            ''
            ''Added 5/10/2023  
            ''
            ''The Public Properties of this class are (probably) unnecessary.
            ''   Replace them with private members?
            ''   Or is they needed for XML-serialization?  
            ''
            mod_controlAssociatedRSCColumn = par_column

        End Sub ''End of ""Public Sub SetRSCColumnAsControl""


        Public Function GetRSCColumnAsControl() As Windows.Forms.Control

            ''Added 5/10/2023  
            Return mod_controlAssociatedRSCColumn

        End Function ''End of ""Public Function GetRSCColumnAsControl()""


    End Class ''End of ""Public Class ClassRSCColumnWidthAndData""

End Namespace