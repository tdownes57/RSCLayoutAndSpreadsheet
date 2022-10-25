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
        Me.MSNetColor = par_color

    End Sub

    Public Sub New()
        ''
        ''Added 8/10/2022 
        ''
        ''  A parameterless constructor is needed for Serialization to take place. 
        ''

    End Sub

    Public Sub New(par_name As String, par_color As System.Drawing.Color)

        ''Added 7/09/2022 
        Me.MSNetColor = par_color
        Me.Name = par_name

    End Sub


    Public Sub New(par_color As System.Drawing.Color,
                   par_name As String,
                   par_description As String)
        ''
        ''Added 7/09/2022
        ''
        Me.MSNetColor = par_color
        Me.Name = par_name
        Me.Description = par_description

    End Sub


    Public Property MSNetColor As Drawing.Color ''Added 7/09/2022 thomas downes
    Public Property Name As String = "" ''Added 7/09/2022 thomas downes
    Public Property Description As String = "" ''Added 7/09/2022 thomas downes
    Public Property MSNetColorName As String ''Added 9/30 /2022 thomas downes

    Public Overrides Function ToString() As String
        ''
        ''Added 7/09/2022 td
        ''
        Dim strOutput As String ''Added 7/09/2022 td
        strOutput = Me.Name

        ''9/30/2022 If (Me.Name = "") Then strOutput = MSNetColor.ToString()
        If (Me.Name = "") Then
            strOutput = MSNetColorName ''MSNetColor.ToString()

        ElseIf (Me.MSNetColorName <> "") Then
            ''Added 9/30/2022
            strOutput = Me.Name & " (" & Me.MSNetColorName & ")"

        ElseIf (Me.Name <> "") Then
            ''Added 9/30/2022
            strOutput = Me.Name
        Else
            ''Added 9/30/2022
            strOutput = MSNetColor.Name
        End If

        Return strOutput ''Me.Name ''Added 7/09/2022 thomas downes

    End Function ''End of ""Public Overrides Function ToString() As String""


    Public Function Matches(par_color As RSCColor) As Boolean
        ''
        ''Added 10/24/2022 thomas
        ''
        If (par_color.MSNetColor = Me.MSNetColor) Then
            Return True
        End If
        Return False

    End Function ''End of ""Public Function Matches(par_color As RSCColor) As Boolean""



End Class
