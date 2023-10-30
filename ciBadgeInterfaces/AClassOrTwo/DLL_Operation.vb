''
''Added 10/30/2023
''
Imports System.Windows.Forms

Public Class DLL_Operation(Of TControl)
    ''
    ''Added 10/30/2023
    ''
    ''Operations are "forward" ("Redo").
    ''
    Public ClassTypeToString As String

    ''Needed for consistency checks... 10/30/2023
    Public OperationType As Char = "?"

    Public InsertSingly As TControl
    Public DeleteSingly As TControl
    ''Not needed.Public MovedSingly As TControl

    Public DeleteRangeStart As TControl
    ''Needed for consistency checks...
    Public DeleteCount As Integer ''How many linked TControl objects?

    Public InsertRangeStart As TControl
    ''Needed for consistency checks...
    Public InsertCount As Integer ''How many linked TControl objects?

    Public MovedRangeStart As TControl
    Public MovedCount As TControl
    Public Move_LefthandStart As TControl
    Public Move_RighthandStart As TControl
    Public Move_LefthandEnd As TControl
    Public Move_RighthandEnd As TControl

    ''' <summary>
    ''' Only one of the following will likely be used, for any given operation. To anchor both sides, the TControl's Next property will be used. 
    ''' </summary>
    Public LefthandAnchor As TControl
    Public RighthandAnchor As TControl

    ''' <summary>
    ''' This creates the "Undo" version.
    ''' </summary>
    ''' <returns></returns>
    Public Function GetUndoVersion() As DLL_Operation(Of TControl)
        ''
        ''Added 10/30/2023
        ''
        Dim objUndo As New DLL_Operation(Of TControl)
        With objUndo

            .LefthandAnchor = Me.LefthandAnchor
            .RighthandAnchor = Me.RighthandAnchor

            If (Me.InsertSingly IsNot Nothing) Then
                ''
                ''Create an "Delete Singly" opertion (for our Undo op).
                ''
                If (Me.OperationType <> "I") Then Debugger.Break()
                .DeleteSingly = Me.InsertSingly ''The "Me." prefix matters.
                .InsertSingly = Nothing ''Important, remove ANY vestigial reference.  (Already Null, but good practice.)
                .OperationType = "D"

            ElseIf (Me.DeleteSingly IsNot Nothing) Then
                ''
                ''Create an "Insert Singly" opertion (for our Undo op).
                ''
                .InsertSingly = Me.DeleteSingly ''The "Me." prefix matters.
                .DeleteSingly = Nothing ''Let's remove ANY vestigial reference.  (Already Null, but good practice.)
                .OperationType = "I"

            ElseIf (Me.InsertRangeStart IsNot Nothing) Then
                ''
                ''Create an "Delete Range" operation (for our Undo op).
                ''
                .DeleteRangeStart = Me.InsertRangeStart ''The "Me." prefix matters.
                .InsertRangeStart = Nothing ''Let's remove ANY vestigial reference. (Already Null, but good practice.)
                .OperationType = "D"

            ElseIf (Me.DeleteRangeStart IsNot Nothing) Then
                ''
                ''Create an "Delete Range" operation (for our Undo op).
                ''
                .InsertRangeStart = Me.DeleteRangeStart ''The "Me." prefix matters.
                .DeleteRangeStart = Nothing ''Let's remove ANY vestigial reference. (Already Null, but good practice.)
                .OperationType = "D"

            ElseIf (Me.MovedRangeStart IsNot Nothing) Then

                Dim tempControlL As TControl ''Added 10/30/2023 td
                Dim tempControlR As TControl ''Added 10/30/2023 td

                .OperationType = "M" '' M for Move.

                ''Lefthand side 
                tempControlL = Me.Move_LefthandStart ''The "Me." prefix matters.
                .Move_LefthandStart = Me.Move_LefthandEnd ''The "Me." prefix matters.
                .Move_LefthandEnd = tempControlL
                ''Righthand side 
                tempControlR = Me.Move_RighthandStart ''The "Me." prefix matters.
                .Move_RighthandStart = Me.Move_RighthandEnd ''The "Me." prefix matters.
                .Move_RighthandEnd = tempControlR

            End If ''End of ""If (Me.InsertedSingly IsNot Nothing) Then... ElseIf..."

        End With ''End of ""With objUndo""

        Return objUndo

    End Function ''End of ""Public Function GetUndoVersion() As DLL_Operation(Of TControl)""


    Public Function Equals(lets_check As TControl) As Boolean
        ''
        ''This will check the Idempotency of a Undo(Undo()), i.e.
        ''   double-Undo.
        ''


    End Function


End Class
