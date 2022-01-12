Imports ciBadgeInterfaces ''Added 1/11/2022 thomas d. 

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
        ''Jan11 2022''If (MyBase.mod_events Is Nothing) Then MyBase.mod_events = Me.MoveabilityEvents

        If (MyBase.mod_eventsForSingleMove Is Nothing) Then
            ''Unlikely to have any positive effect. ---Jan11 2022
            MyBase.mod_eventsForSingleMove = Me.MoveabilityEventsForSingleMove
        End If

        If (MyBase.mod_eventsForSingleMove Is Nothing) Then

            ''Added 1/11/2022 td
            mod_eventsForSingleMove = New GroupMoveEvents_Singleton(MyBase.mod_iLayoutFunctions, True)

        End If ''Endof "If (MyBase.mod_eventsForSingleMove Is Nothing) Then"

    End Sub

    Public Overrides Sub SaveToModel()
        ''Added 1/4/2022 td 

        ''MyBase.SaveToModel()

    End Sub


    Public Overrides Sub RemoveMouseEventHandlers_ChildClass()
        ''
        ''Added 1/12/2022 
        ''
        ''RemoveHandler pictureLabel.MouseDown, AddressOf pictureLabel_MouseDown
        ''RemoveHandler pictureLabel.MouseMove, AddressOf pictureLabel_MouseMove
        ''RemoveHandler pictureLabel.MouseUp, AddressOf pictureLabel_MouseUp

    End Sub ''End of "Public Overrides Sub RemoveMouseEventHandlers()"


    Public Overrides Sub AddMouseEventHandlers_ChildClass()
        ''
        ''Added 1/12/2022 
        ''
        ''RemoveHandler pictureLabel.MouseDown, AddressOf pictureLabel_MouseDown
        ''RemoveHandler pictureLabel.MouseMove, AddressOf pictureLabel_MouseMove
        ''RemoveHandler pictureLabel.MouseUp, AddressOf pictureLabel_MouseUp

        ''AddHandler pictureLabel.MouseDown, AddressOf pictureLabel_MouseDown
        ''AddHandler pictureLabel.MouseMove, AddressOf pictureLabel_MouseMove
        ''AddHandler pictureLabel.MouseUp, AddressOf pictureLabel_MouseUp

    End Sub ''End of "Public Overrides Sub AddMouseEventHandlers()"


End Class
