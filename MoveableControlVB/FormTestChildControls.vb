Imports __RSCWindowsControlLibrary ''Added 1/3/2022 thomas d. 
Imports ciBadgeDesigner ''Added 1/3/2022 thomas d.
Public Class FormTestChildControls
    ''
    ''Added 1/3/2022 thomas d.
    ''
    Private mod_oLastControl As New ClassLastControlTouched
    Private mod_events As New ciBadgeDesigner.ClassGroupMoveEvents
    Private mod_designer As New ciBadgeDesigner.ClassDesigner

    Private Sub FormTestChildControls_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ''Added 1/3/2022 td
        SimpleChildOfRSCControl1.LastControlTouched_Info = mod_oLastControl
        ProportionalRSCControl1.LastControlTouched_Info = mod_oLastControl
        SimpleChildOfRSCControl21.LastControlTouched_Info = mod_oLastControl

        ''Added 1/3/2022 td
        mod_events.LayoutFunctions = mod_designer
        SimpleChildOfRSCControl1.MoveabilityEvents = mod_events
        ProportionalRSCControl1.MoveabilityEvents = mod_events
        SimpleChildOfRSCControl21.MoveabilityEvents = mod_events

    End Sub
End Class