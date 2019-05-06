Option Explicit On
Option Strict On
''
''   Added 5/6/2019 thomas downes 
''
''   https://www.codeproject.com/articles/38137/easy-drag-and-drop-of-controls-at-run-time
''

Public Class Form1
    ''
    ''   https://www.codeproject.com/articles/38137/easy-drag-and-drop-of-controls-at-run-time
    ''
    Dim dragging As Boolean
    Dim startX As Integer
    Dim startY As Integer

    Private Sub Form1_Load(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles MyBase.Load

        'TODO: This line of code loads data into the 
        ''NorthwindDataSet.Employees' table. You can move, or remove it, as needed.
        ''Me.EmployeesTableAdapter.Fill(Me.NorthwindDataSet.Employees)

        ''5/6/2019 td''For Each Control As Control In Me.Controls
        For Each each_control As Control In Me.panelLayout.Controls
            AddHandler each_control.MouseDown, AddressOf startDrag
            AddHandler each_control.MouseMove, AddressOf whileDragging
            AddHandler each_control.MouseUp, AddressOf endDrag
        Next

        If (My.Settings.controlLocations Is Nothing) Then My.Settings.controlLocations = New Specialized.StringCollection

        ''5/6/2019 td''For Each Control As Control In Me.Controls
        For Each Control As Control In Me.panelLayout.Controls
            For Each itemString As String In My.Settings.controlLocations
                If Split(itemString, "!")(0) = Control.Name Then
                    Control.Location = New Point(Integer.Parse(Split(itemString, "!")(1)),
                        Integer.Parse(Split(itemString, "!")(2)))
                End If
            Next
        Next


    End Sub

    Private Sub startDrag(ByVal sender As Object,
        ByVal e As System.Windows.Forms.MouseEventArgs)
        dragging = True
        startX = e.X
        startY = e.Y
    End Sub

    Private Sub whileDragging(ByVal sender As System.Object,
        ByVal e As System.Windows.Forms.MouseEventArgs)

        Dim sender_control As Control = CType(sender, Control)

        If dragging = True Then
            sender_control.Location = New Point(sender_control.Location.X +
        e.X - startX, sender_control.Location.Y + e.Y - startY)
            Me.Refresh()
        End If
    End Sub

    Private Sub endDrag(ByVal sender As System.Object, ByVal e As System.EventArgs)
        dragging = False

        My.Settings.controlLocations.Clear()

        ''5/6/2019 td''For Each Control As Control In Me.Controls
        For Each each_control As Control In Me.panelLayout.Controls
            My.Settings.controlLocations.Add(each_control.Name & "!" _
            & each_control.Location.X & "!" & each_control.Location.Y)
        Next

        My.Settings.Save()

    End Sub



End Class
