Option Explicit On
Option Strict On
''
'' Added 5/20/2022 thomas downes  
''
Imports System.Drawing ''Added 5/20/2022 thomas downes

Public Class PortraitClass
    ''
    '' Added 5/20/2022 thomas downes  
    ''
    Public Shared Function GetPortraitImageByID(pstrIDValue As String) As System.Drawing.Image
        ''
        '' Added 5/20/2022 thomas downes  
        ''
        If (pstrIDValue = "") Then Return Nothing

        Dim output_image As Image
        output_image = My.Resources.Liz_20_percent
        Return output_image

    End Function ''End of ""Public Shared Function GetPortraitImageByID""


End Class ''End of ""Public Class PortraitClass""
