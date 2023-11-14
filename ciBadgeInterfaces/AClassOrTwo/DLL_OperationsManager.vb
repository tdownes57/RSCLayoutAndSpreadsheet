''//
''//  Added 10/30/2023 t h o m a s d o w n e s  
''//
Public Class DLL_OperationsManager ''11/2/2023 (Of TControl)
    ''Moved to Partial Class. 11/2023  ---Implements IDoublyLinkedList
    ''11/2/2023 Implements IDoublyLinkedList(Of TControl)

    ''General question, is this sort of casting possible??  Probably not!!
    ''
    ''   (Impossible, since was are casting from parent to adult-child.)
    ''   (In contrast, yes it is permissible to cast from adult-child to parent. 
    ''   (I call it "adult-child" since it contains MORE knowledge than the parent... LOL)   
    ''
    ''   Dim rsc_item = CType(item_TControlToDelete, TControl)
    ''
    Private mod_itemNext As IDoublyLinkedItem ''11/2/2023  TControl
    Private mod_itemPrior As IDoublyLinkedItem ''11/2/2023   TControl
    Private mod_lastPriorOperation As DLL_Operation

    ''Added 11/14/2023 Thomas Downes  
    Private mod_modeColumnNotRow As Boolean ''Added 11/14/2023
    Private mod_bModeHasBeenSet As Boolean ''Added 11/14/2023
    Private mod_bTesting As Boolean = ciBadgeInterfaces.Testing.TestingByDefault
    Private mod_datetimeModeSet As DateTime ''Added 11/14/2023 
    Private mod_datetimeModeSetToRow As DateTime ''Added 11/14/2023 
    Private mod_datetimeModeSetToCol As DateTime ''Added 11/14/2023 

    ''Private mod_list As RSCDoublyLinkedList(Of TControl)
    ''#1 11/2/2023 Private mod_list As List(Of TControl)
    ''#2 11/2/2023 Private mod_list As IDoublyLinkedList ''RSCDoublyLinkedList
    Private mod_listRowHeaders As IDoublyLinkedList ''RSCDoublyLinkedList
    Private mod_listColumns As IDoublyLinkedList ''RSCDoublyLinkedList


    Public Sub SetModeToColumnOperations()
        ''Added 11/14/2023 
        mod_modeColumnNotRow = True
        mod_bModeHasBeenSet = True
        ''For testing.
        If (mod_bTesting) Then
            mod_datetimeModeSet = DateTime.Now
            mod_datetimeModeSetToCol = DateTime.Now
        End If ''End of ""If (mod_bTesting) Then""
    End Sub


    Public Sub SetModeToTesting()

        ''Added 11/14/2023 
        mod_bTesting = True

    End Sub


    Public Sub SetModeTo___RowOperations()
        ''Added 11/14/2023 
        mod_modeColumnNotRow = False
        mod_bModeHasBeenSet = True
        ''For testing.
        If (mod_bTesting) Then
            mod_datetimeModeSet = DateTime.Now
            mod_datetimeModeSetToRow = DateTime.Now
        End If ''End of ""If (mod_bTesting) Then""
    End Sub


    Private Sub ProcessOperation(param_operation As DLL_Operation) ''11/2/2023 TControl))
        ''
        '' Here we "parse" (process) the properties of the DLL_Operation, 
        ''  in order to call the appropriate IDoublyLinkedList functions
        ''  represented by mod_list. 
        ''
        ''
        If (mod_bModeHasBeenSet = False) Then System.Diagnostics.Debugger.Break()

        ''Check for population. 
        With param_operation
            If (.LefthandAnchor Is Nothing And .RighthandAnchor Is Nothing) Then
                Debugger.Break()
            ElseIf (.InsertRangeStart Is Nothing And .InsertSingly Is Nothing) Then
                If (.DeleteRangeStart Is Nothing And .DeleteSingly Is Nothing) Then
                    If (.MovedRangeStart Is Nothing) Then
                        Debugger.Break()
                    End If
                End If
            End If
        End With

        If (mod_bTesting) Then
            RaiseMessageIfModeNotRefreshed()
        End If ''ENd of ""If (mod_bTesting) Then""

        Select Case param_operation.OperationType
            Case "I"
                ''
                ''An insert operation. 
                ''
                If (param_operation.InsertSingly IsNot Nothing) Then
                    ''Is it a left-hand anchor, or a right-hand anchor?
                    ''  (Is it a prior-item anchor, or a next-item anchor?)
                    If (param_operation.LefthandAnchor IsNot Nothing) Then
                        ''Left-hand (Prior Item) Anchor
                        Me.DLL_InsertItemAfter(param_operation.InsertSingly,
                                        param_operation.LefthandAnchor)
                    Else
                        ''Left-hand (Next Item) Anchor
                        Me.DLL_InsertItemBefore(param_operation.InsertSingly,
                                        param_operation.RighthandAnchor)
                    End If

                ElseIf (param_operation.InsertRangeStart IsNot Nothing) Then
                    ''Is it a left-hand anchor, or a right-hand anchor?
                    ''  (Is it a prior-item anchor, or a next-item anchor?)
                    If (param_operation.LefthandAnchor IsNot Nothing) Then
                        ''Left-hand (Prior Item) Anchor
                        Me.DLL_InsertItemAfter(param_operation.InsertRangeStart,
                                        param_operation.LefthandAnchor)
                    Else
                        ''Right-hand (Next Item) Anchor
                        Me.DLL_InsertItemBefore(param_operation.InsertRangeStart,
                                        param_operation.RighthandAnchor)
                    End If
                End If

            Case "M"
                ''
                ''A moving operation. 
                ''
                ''Is it a left-hand anchor, or a right-hand anchor?
                ''  (Is it a prior-item anchor, or a next-item anchor?)
                If (param_operation.LefthandAnchor IsNot Nothing) Then
                    ''Left-hand (Prior Item) Anchor
                    Me.DLL_DeleteRange_Simpler(param_operation.MovedRangeStart,
                                       param_operation.MovedCount)
                Else
                    ''Right-hand (Next Item) Anchor
                    Me.DLL_(param_operation.InsertRangeStart,
                                        param_operation.RighthandAnchor)
                End If

            Case "D"
                ''
                ''A deleting operation. 
                ''
                If (param_operation.DeleteSingly IsNot Nothing) Then
                    ''Delete the single item.
                    Me.DLL_DeleteItem(param_operation.DeleteSingly)
                ElseIf (param_operation.DeleteRangeStart IsNot Nothing) Then
                    ''Delete the range.
                    Me.DLL_DeleteRange_Simply(param_operation.DeleteRangeStart,
                               param_operation.DeleteRangeStart)
                End If

        End Select




    End Sub ''End of ""Public Sub ProcessOperation""


    Public Function GetLastOperation() As DLL_Operation




    End Function



    Public Function GetRecentOperation() As DLL_Operation
        ''
        ''Allow the new operation to be stored on a stack of operations. 
        ''
        Return mod_lastPriorOperation

    End Function


    Public Sub RaiseMessageIfModeNotRefreshed(Optional pboolCheckIfTesting As Boolean = False)
        ''
        ''Added 11/14/2023  
        ''
        Dim timeDifference As TimeSpan = Now.Subtract(mod_datetimeModeSet)
        ''If (Now.) Then
        Dim bTooLongAgo As Boolean = False
        Dim bProgrammerForgotToSetMode As Boolean = False

        If (Me.mod_bTesting Or Not pboolCheckIfTesting) Then
            bTooLongAgo = (timeDifference.Milliseconds > 500)
            bProgrammerForgotToSetMode = bTooLongAgo
        End If

        If (bProgrammerForgotToSetMode Or bTooLongAgo) Then
            ''
            ''Check for the bug of the programmer not setting the 
            ''  mode--are we talking about Rows or Columns?
            ''
            Debugger.Break()

        End If ''End of ""If (bTooLongAgo) Then""

    End Sub ''End of ""Public Sub RaiseMessageIfModeNotRefreshed()""



End Class

