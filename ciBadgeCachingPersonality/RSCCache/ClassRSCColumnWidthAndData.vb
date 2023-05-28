Option Explicit On '' Added 3/15/2022 thomas downes 
Option Strict On '' Added 3/15/2022 thomas downes 
Imports System.Reflection
Imports System.Windows.Forms
''
'' Added 3/15/2022 thomas downes  
''
Namespace ciBadgeCachePersonality

    <Serializable>
    Public Class ClassRSCColumnWidthAndData
        ''
        '' Added 3/15/2022 thomas downes  
        ''
        ''Public for serialization. 
        Public Property Width As Integer

        ''Public for serialization. 
        Public Property Rows As Integer

        ''Public for serialization. 
        Public Property CIBField As ciBadgeInterfaces.EnumCIBFields

        ''Public for serialization. 
        Public Property ColumnData As List(Of String)

        ''Public for serialization.--Added 5/10/2023   
        Private mod_controlAssociatedRSCColumn As Windows.Forms.Control

        Public Sub New(par_infoRSCFieldColumn As InterfaceRSCColumnData,
                       par_controlRSCFieldColumn As Windows.Forms.Control)

            ''Added 5/25/2023 
            mod_controlAssociatedRSCColumn = par_controlRSCFieldColumn
            par_infoRSCFieldColumn.ColumnWidthAndData = Me

        End Sub ''End of ""Public Sub New"


        Public Sub New()
            ''Added 5/27/2023 
            ''
            ''  Needed for deserialization.  
            ''
        End Sub ''End of ""Public Sub New"


        Public Overrides Function ToString() As String

            ''Added 5/25/2023 thomas downes
            Return "Recipient data related to field " & CIBField.ToString() &
                "   " &
                 CStr(IIf(mod_controlAssociatedRSCColumn Is Nothing,
                          " (No RSCColumn)", ""))

        End Function ''End of ""Public Overrides Function ToString() As String""


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