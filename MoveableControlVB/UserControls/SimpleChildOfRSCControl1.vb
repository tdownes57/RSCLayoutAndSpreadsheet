Public Class SimpleChildOfRSCControl1
    ''
    ''Added 1/3/2022 thomas downes
    ''
    ''//Public EventsSingleton As GroupMoveEvents_Singleton

    Private Sub SimpleChildOfRSCControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 1/3/2022 thomas downes
        ''
        ''Const c_RemoveMoveability_Full As Boolean = True
        ''Const c_RemoveMoveability_Partial As Boolean = False
        ''MyBase.RemoveMoveability(c_RemoveMoveability_Partial)

        ''Jan4 2022 ''If (MyBase.mod_events Is Nothing) Then MyBase.mod_events = Me.EventsSingleton
        If (MyBase.mod_events Is Nothing) Then MyBase.mod_events = Me.MoveabilityEvents


    End Sub

    Public Overrides Sub SaveToModel()
        ''Added 1/4/2022 td 

        ''MyBase.SaveToModel()

    End Sub


End Class
