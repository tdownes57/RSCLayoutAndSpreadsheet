Option Explicit On
Option Strict On

''
'' A test object that needs to be serialized.
''
<Serializable()>
Public Class ClassChild

    ''<NonSerialized()>
    ''9/1/2019 td''Public Property Font_DrawingClass As System.Drawing.Font
    Public Property FontFamily As String ''Added 9/1/2019 td
    Public Property FontSize As Integer ''Added 9/1/2019 td

    Public Property FontColor As System.Drawing.Color

    Public Property BackColor As System.Drawing.Color



End Class
