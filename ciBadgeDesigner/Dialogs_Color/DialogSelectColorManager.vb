Public Class DialogSelectColorManager
    Private Sub DialogSelectColorManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        '' Added 9/30/2022 td
        ''
        RscColorFlowPanel1.AddColors_AllPossibleColors(True)
        RscColorFlowPanel1.Refresh()



    End Sub
End Class