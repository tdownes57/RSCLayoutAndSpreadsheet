Imports __RSCWindowsControlLibrary ''Added 1/3/2022 thomas d. 
Imports ciBadgeDesigner ''Added 1/3/2022 thomas d.
Public Class FormTestChildControls
    ''
    ''Added 1/3/2022 thomas d.
    ''
    Private mod_oLastControl As New ClassLastControlTouched
    Private mod_designer As New ciBadgeDesigner.ClassDesigner
    ''>>Jan3 2022 td''Private mod_events As New ciBadgeDesigner.ClassGroupMoveEvents
    ''Jan3 2022 td''Private mod_eventsMoveMaster As New ciBadgeInterfaces.ClassGroupMoveEvents
    Private mod_eventsMoveMaster As New ciBadgeInterfaces.GroupMoveEvents_Singleton(mod_designer, True)


    Private Sub FormTestChildControls_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ''Added 1/3/2022 td
        SimpleChildOfRSCControl1.LastControlTouched_Info = mod_oLastControl
        ProportionalRSCControl1.LastControlTouched_Info = mod_oLastControl
        SimpleChildOfRSCControl21.LastControlTouched_Info = mod_oLastControl

        ''Added 1/3/2022 td
        mod_eventsMoveMaster.LayoutFunctions = mod_designer
        SimpleChildOfRSCControl1.MoveabilityEvents = mod_eventsMoveMaster
        ProportionalRSCControl1.MoveabilityEvents = mod_eventsMoveMaster
        SimpleChildOfRSCControl21.MoveabilityEvents = mod_eventsMoveMaster

        ''Added 1/4/2022 td
        SimpleChildOfRSCControl1.RemoveMoveability(False)
        ProportionalRSCControl1.RemoveMoveability(False)
        SimpleChildOfRSCControl21.RemoveMoveability(False)

        ''Added 1/3/2022 td
        SimpleChildOfRSCControl1.AddMoveability(mod_eventsMoveMaster, mod_designer)
        ProportionalRSCControl1.AddMoveability(mod_eventsMoveMaster, mod_designer)
        SimpleChildOfRSCControl21.AddMoveability(mod_eventsMoveMaster, mod_designer)

        ''Added 1/4/2022 td
        ProportionalRSCControl1.AddMoveability_ViaLabel()


    End Sub
End Class