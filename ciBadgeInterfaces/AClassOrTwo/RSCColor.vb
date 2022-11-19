Option Explicit On
Option Strict On

Imports System.Drawing
Imports System.Xml.Serialization ''Added 9/5/2022 & 9/24/2019 td

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

    Public Sub New(par_name As String, par_colorMS As System.Drawing.Color)

        ''Added 7/09/2022 
        Me.MSNetColor = par_colorMS
        Me.Name = par_name
        ''Added 10/28/2022 td
        Me.MSNetColorName = par_colorMS.Name

    End Sub


    Public Sub New(par_msColor As System.Drawing.Color,
                   par_name As String,
                   par_description As String)
        ''
        ''Added 7/09/2022
        ''
        Me.MSNetColor = par_msColor
        Me.Name = par_name
        Me.Description = par_description
        ''Added 10/28/2022 td
        Me.MSNetColorName = par_msColor.Name

    End Sub


    <XmlIgnore>
    Public Property MSNetColor As Drawing.Color ''Added 7/09/2022 thomas downes
    Public Property Name As String = "" ''Added 7/09/2022 thomas downes
    Public Property Description As String = "" ''Added 7/09/2022 thomas downes
    Public Property MSNetColorName As String = "" ''Added 9/30 /2022 thomas downes


    <XmlElement("MSNetColor")>
    Public Property Color_HTML As String
        Get
            ''Added 11/18/2022 td
            ''  https://stackoverflow.com/questions/376234/best-solution-for-xmlserializer-and-system-drawing-color
            Return ColorTranslator.ToHtml(MSNetColor)
        End Get
        Set(value As String)
            ''Added 11/18/2022 td
            ''  https://stackoverflow.com/questions/376234/best-solution-for-xmlserializer-and-system-drawing-color
            MSNetColor = ColorTranslator.FromHtml(value)
        End Set
    End Property


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


    Public Function Name_orMSColorName() As String

        ''Added 10/28/2022 
        If (Me.Name <> "") Then
            Return Me.Name
        ElseIf (Me.MSNetColor.Name <> "") Then
            Return Me.MSNetColor.Name
        Else
            Return Me.MSNetColorName
        End If

    End Function ''End of ""Public Function Name_orMSColorName() As String"


    Public Function Name_andDescription() As String

        ''Added 10/28/2022 
        Dim result As String

        result = Name_orMSColorName()

        If (Me.Description <> "") Then

            result &= (vbCrLf & Me.Description)

        End If ''End of ""If (Me.Description <> "") Then"

        Return result

    End Function ''End of ""Public Function Name_andDescription() As String"


End Class
