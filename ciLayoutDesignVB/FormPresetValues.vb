Option Explicit On
Option Infer On
Option Strict On

Public Class FormPresetValues

    Private mod_model As ICIBFieldCustom ''Added 7/21/2019 td

    Public Sub Load_CustomField(par_info As ICIBFieldCustom)
        ''
        ''Added 7/21/2019 Thomas DOWNES   
        ''
        mod_model = par_info

        With par_info





        End With ''End of "With par_info"  

    End Sub ''End of "Public Sub Load_CustomField"

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

    End Sub
End Class