Option Explicit On
Option Strict On

Imports System.Runtime.InteropServices ''Added 9/2/2019 td
Imports System.Web.Script.Serialization
Imports System.Runtime.Serialization
Imports System.Xml

''
'' A test object that needs to be serialized.
''
<Serializable()>
Public Class ClassChild
    ''
    ''<NonSerialized()>
    ''     9/1/2019 td''Public Property Font_DrawingClass As System.Drawing.Font

    Public Property FontFamily As String ''Added 9/1/2019 td
    Public Property FontSize As Integer ''Added 9/1/2019 td

    ''9/2/2019 td''Public Property FontColor As System.Drawing.Color

    Public Property BackColor As System.Drawing.Color

    <NonSerialized()>
    Private _font_Color As Color '' = Nothing

    <NonSerialized()>
    Private _back_Color As Color '' = Nothing

    ''
    '' https://stackoverflow.com/questions/6746444/preventing-serialization-of-properties-in-vb-net
    ''
    <ScriptIgnore()>
    <IgnoreDataMember()>
    <Xmlignore()>
    Public Property FontColor() As Color
        Get
            Return _font_Color
        End Get
        Set(ByVal value As Color)
            _font_Color = value
        End Set
    End Property

    Public Property FontColor_Serializable As String '' 9/2/2019 td''System.Drawing.Color

    Public Property BackColor_Serializable As String '' 9/2/2019 td''System.Drawing.Color



End Class
