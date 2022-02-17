Option Explicit On
Option Strict On
''
''Added 8/29/2019 thomas downes  
''
Public Class DialogDisplayColor

    Public LabelMessageAtTop As String ''Added 8/29/2019 thomas downes  

    Public ColorForBackground As Drawing.Color  ''Added 8/29/2019 thomas downes  

    Public Shared Sub ShowColor(par_strMessage As String, par_color As Color)
        ''
        ''Added 8/29/2019 thomas downes 
        ''
        Dim frm_ToShow As New DialogDisplayColor
        frm_ToShow.LabelMessageAtTop = par_strMessage
        frm_ToShow.ColorForBackground = par_color
        frm_ToShow.BackColor = par_color
        frm_ToShow.Show()

    End Sub ''End of "Public Shared Sub ShowColor(par_strMessage As String, par_color As Color)"


    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub FormDisplayColor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ''Added 8/29/2019 thomas downes  
        Label1.Text = Me.LabelMessageAtTop
        Me.BackColor = Me.ColorForBackground

    End Sub
End Class