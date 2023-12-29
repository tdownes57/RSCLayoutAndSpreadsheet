''
''Added 10/30/2023
''
Imports System.Windows.Forms


''-----------------------------------------------------------
''  Please see CIBadgeDesigner / Classes RSC / RSC_DLL_OperationsManager.
''
''    ---12/07/2023 thomas dow_nes 
''-----------------------------------------------------------

Public Class DLL_Operation_Deprecated(Of TControl)
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
    Public MovedCount As Integer ''TControl
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
    Public Function GetUndoVersion() As DLL_Operation_Deprecated(Of TControl)
        ''
        ''Added 10/30/2023
        ''
        Dim objUndo As New DLL_Operation_Deprecated(Of TControl)
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


    ''
    ''Important, check for equality.
    ''
    Private Overloads Function Equals(lets_check As DLL_Operation_Deprecated(Of TControl)) As Boolean
        ''Private Function Equals(lets_check As TControl) As Boolean
        ''
        ''This will check the Idempotency of a Undo(Undo()), i.e.
        ''   double-Undo.
        ''
        Dim boolEqual1 As Boolean
        Dim boolEqual2 As Boolean
        Dim boolEqual3 As Boolean
        Dim boolEqual4 As Boolean
        Dim boolEqual5 As Boolean
        Dim boolEqual6 As Boolean
        Dim boolEqual7 As Boolean
        Dim boolEqual8 As Boolean
        Dim boolEqual9 As Boolean

        Dim boolEqual91 As Boolean
        Dim boolEqual92 As Boolean
        Dim boolEqual93 As Boolean
        Dim boolEqual94 As Boolean
        Dim boolEqual95 As Boolean

        With lets_check

            boolEqual1 = (.ClassTypeToString = Me.ClassTypeToString)
            boolEqual2 = (.DeleteCount = Me.DeleteCount)
            ''Unfortunately, compiler won't let me compare directly. 
            boolEqual3 = ((.DeleteRangeStart Is Nothing) = (Me.DeleteRangeStart Is Nothing))
            ''Unfortunately, compiler won't let me compare directly. 
            boolEqual4 = ((.DeleteSingly Is Nothing) = (Me.DeleteSingly Is Nothing))
            boolEqual5 = (.InsertCount = Me.InsertCount)
            ''Unfortunately, compiler won't let me compare directly. 
            boolEqual6 = ((.InsertRangeStart Is Nothing) = (Me.InsertRangeStart Is Nothing))
            boolEqual7 = ((.InsertSingly Is Nothing) = (Me.InsertSingly Is Nothing))

            boolEqual8 = ((.LefthandAnchor Is Nothing) = (Me.LefthandAnchor Is Nothing))
            boolEqual9 = ((.RighthandAnchor Is Nothing) = (Me.RighthandAnchor Is Nothing))

            boolEqual91 = (.MovedCount = Me.MovedCount)
            boolEqual92 = ((.Move_LefthandEnd Is Nothing) = (Me.Move_LefthandEnd Is Nothing))
            boolEqual93 = ((.Move_LefthandEnd Is Nothing) = (Me.Move_LefthandEnd Is Nothing))
            boolEqual94 = ((.Move_LefthandEnd Is Nothing) = (Me.Move_LefthandEnd Is Nothing))
            boolEqual95 = ((.Move_LefthandEnd Is Nothing) = (Me.Move_LefthandEnd Is Nothing))

        End With ''End of ""With lets_check""

        Dim bEqual1to5 As Boolean
        Dim bEqual6to9 As Boolean
        Dim bEqual91to95 As Boolean

        bEqual1to5 = (boolEqual1 And boolEqual2 And boolEqual3 And
                      boolEqual4 And boolEqual5)
        bEqual6to9 = (boolEqual6 And boolEqual7 And boolEqual8 And boolEqual9)
        bEqual91to95 = (boolEqual91 And boolEqual92 And boolEqual93 And
                          boolEqual94 And boolEqual95)

        Dim bEqual_All As Boolean
        bEqual_All = (bEqual1to5 And bEqual6to9 And bEqual91to95)

        Return bEqual_All

    End Function ''End of Private Function Overrides Equals() as Boolean


    Private Function Undo2x_IsIdempotent(lets_check As DLL_Operation_Deprecated(Of TControl)) As Boolean
        ''
        ''This will check the Idempotency of a Undo(Undo()), i.e.
        ''   double-Undo.
        ''
        Dim objUndo_1st As DLL_Operation_Deprecated(Of TControl)
        Dim objUndo_2nd As DLL_Operation_Deprecated(Of TControl)

        objUndo_1st = lets_check.GetUndoVersion()
        objUndo_2nd = objUndo_1st.GetUndoVersion()

        Dim boolEqualMatch As Boolean

        boolEqualMatch = lets_check.Equals(objUndo_2nd)
        Return boolEqualMatch

    End Function ''End of ""Private Function Undo2x_IsIdempotent""



End Class
