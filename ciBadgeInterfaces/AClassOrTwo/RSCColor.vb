Option Explicit On
Option Strict On
''
''Added 7/09/2022 thomas downes  
''
<Serializable>
Public Class RSCColor
    ''
    ''Added 7/09/2022 thomas downes  
    ''
    Public Sub New(par_color As System.Drawing.Color)

        ''Added 7/09/2022 
        Me.DColor = par_color

    End Sub


    Public Sub New(par_name As String, par_color As System.Drawing.Color)

        ''Added 7/09/2022 
        Me.DColor = par_color
        Me.Name = par_name

    End Sub


    Public Sub New(par_color As System.Drawing.Color,
                   par_name As String,
                   par_description As String)
        ''
        ''Added 7/09/2022
        ''
        Me.DColor = par_color
        Me.Name = par_name
        Me.Description = par_description

    End Sub


    Public Property DColor As Drawing.Color ''Added 7/09/2022 thomas downes
    Public Property Name As String = "" ''Added 7/09/2022 thomas downes
    Public Property Description As String = "" ''Added 7/09/2022 thomas downes

    Public Overrides Function ToString() As String
        ''
        ''Added 7/09/2022 td
        ''
        Dim strOutput As String ''Added 7/09/2022 td
        strOutput = Me.Name
        If (Me.Name = "") Then strOutput = DColor.ToString()
        Return strOutput ''Me.Name ''Added 7/09/2022 thomas downes

    End Function ''End of ""Public Overrides Function ToString() As String""


End Class
